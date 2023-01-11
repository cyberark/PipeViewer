using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using PipeViewer.Control;
using NtApiDotNet;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace PipeViewer
{
    public partial class Form1 : Form
    {

        private int m_NamedPipesNumber;
        private ListView m_LastListViewColumnFilter = new ListView();
        private ListView m_LastListViewHighlighFilter = new ListView();
        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;
        private string m_LastSearchValue;
        private bool m_IsGridButtonPressed = false;
        private static Dictionary<string, int> m_ColumnIndexes = new Dictionary<string, int>();
        private static Dictionary<int, string> m_ProcessPIDsDictionary = new Dictionary<int, string>();
        int m_CurrentRowIndexRightClick, m_CurrentColumnIndexRightClick;
        private IDictionary<string, List<ListViewItem>> m_IncludeFilterDict = new Dictionary<string, List<ListViewItem>>();
        private IDictionary<string, List<ListViewItem>> m_ExcludeFilterDict = new Dictionary<string, List<ListViewItem>>();
        private IDictionary<string, List<ListViewItem>> m_IncludeHighlightDict = new Dictionary<string, List<ListViewItem>>();
        private IDictionary<string, List<ListViewItem>> m_ExcludeHighlightDict = new Dictionary<string, List<ListViewItem>>();

        // https://stackoverflow.com/questions/1936682/how-do-i-display-a-files-properties-dialog-from-c
        // https://stackoverflow.com/a/32503655/2153777
        // https://stackoverflow.com/a/28297300/2153777
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }


        public static bool ShowFileProperties(string Filename)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = Filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            info.lpParameters = "Security";
            return ShellExecuteEx(ref info);
        }

        public Form1()
        {
            InitializeComponent();
            InitalizeColumnsHeaderDictionary();

            typeof(DataGridView).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               dataGridView1,
               new object[] { true });

           //Task.Run(() => Utils.CreateDummyPipeForTesting());

            //dummRowsForDebug();
            //dummyLoopRowsForDebug();
            //Task.Run(() => dummyLoopRowsForDebug());
            Task.Run(() => InitializePipeListWithProcesses());

            //Thread t = new Thread(new ThreadStart(InitializePipeListWithProcesses));
            //t.Start();
        }



        //private delegate void InitializePipeListWithProcessesCallBack();
        //private void InitializePipeListWithProcesses()
        //{
        //    if (this.InvokeRequired)
        //    {
        //        InitializePipeListWithProcessesCallBack s = new InitializePipeListWithProcessesCallBack(InitializePipeListWithProcesses);
        //        this.Invoke(s);
        //    }
        //    else
        //    {
        //        Process[] processCollection = Process.GetProcesses();
        //        foreach (Process p in processCollection)
        //        {
        //            m_ProcessPIDsDictionary.Add(p.Id, p.ProcessName);
        //        }

        //        initializePipeList();
        //    }
        //}

        private void InitializePipeListWithProcesses()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                m_ProcessPIDsDictionary.Add(p.Id, p.ProcessName);
            }

            initializePipeList();
        }

        private delegate void addNamedPipeToDataGridViewCallBack(string i_NamedPipe);

        private void InitalizeColumnsHeaderDictionary()
        {
            // Populate the dictionary with the column header text and its index
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                m_ColumnIndexes[dataGridView1.Columns[i].HeaderText] = i;
            }
        }

        private void initializePipeList()
        {
            String[] listOfPipes = System.IO.Directory.GetFiles(@"\\.\pipe\");
            foreach (var namedPipe in listOfPipes)
            {
                addNamedPipeToDataGridView(namedPipe);
            }

        }

        //private delegate void initializePipeListCallBack();
        //private void initializePipeList()
        //{
        //    if (this.InvokeRequired)
        //    {
        //        initializePipeListCallBack s = new initializePipeListCallBack(initializePipeList);
        //        this.Invoke(s);
        //    }else
        //    {
        //        String[] listOfPipes = System.IO.Directory.GetFiles(@"\\.\pipe\");
        //        foreach (var namedPipe in listOfPipes)
        //        {
        //            addNamedPipeToDataGridView(namedPipe);
        //        }
        //    }
        //}

        // https://blog.cjwdev.co.uk/2011/06/28/permissions-not-included-in-net-accessrule-filesystemrights-enum/
        private void addNamedPipeToDataGridView(string i_NamedPipe)
        {
           // i_NamedPipe = @"\\.\pipe\myPipe";
            string permissions;
            if (this.InvokeRequired)
            {
                addNamedPipeToDataGridViewCallBack s = new addNamedPipeToDataGridViewCallBack(addNamedPipeToDataGridView);
                this.Invoke(s, i_NamedPipe);
            }
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[m_ColumnIndexes[ColumnName.HeaderText]].Value = i_NamedPipe;

                row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Regular);

                NtNamedPipeFileBase namedPipeObject = Engine.GetNamedPipeObject(i_NamedPipe, Engine.NamedPipeFunctionEndType.Client);
                if (namedPipeObject == null)
                {
                    namedPipeObject = Engine.GetNamedPipeObject(i_NamedPipe, Engine.NamedPipeFunctionEndType.Server);
                }

                // NtNamedPipeFileBase namedPipeObjectClient = Engine.GetNamedPipeClientObject(i_NamedPipe);
                // We added a check for empty name because it caused an exception with named pipe \\.\pipe\dbxsvc which wasn't NULL
                // but add partial value exist on one machine.

                // We added try\catch because one specific bug with \\.\pipe\dbxsvc (DropBox). Maybe there is a better way to handle it?
                try
                {
                    if (namedPipeObject != null)
                    {
                        row.Cells[m_ColumnIndexes[ColumnSddl.HeaderText]].Value = namedPipeObject.Sddl;


                        if (namedPipeObject.SecurityDescriptor.Dacl.Count != 0)
                        {
                            permissions = "";

                            foreach (Ace dacl in namedPipeObject.SecurityDescriptor.Dacl)
                            {
                                permissions += dacl.Type.ToString() + " ";
                                permissions += Engine.ConvertAccessMaskToSimplePermissions(dacl.Mask.Access);
                                permissions += " " + dacl.Sid.Name + "; \n";
                            }

                            row.Cells[m_ColumnIndexes[ColumnPermissions.HeaderText]].Value = permissions;
                        } else
                        {
                            row.Cells[m_ColumnIndexes[ColumnPermissions.HeaderText]].Value = "NO DACL -> FULL permissions";
                            //row.Cells[m_ColumnIndexes[ColumnPermissions.HeaderText]].Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                            row.Cells[m_ColumnIndexes[ColumnPermissions.HeaderText]].Style.BackColor = Color.Red;
                        }

                        row.Cells[m_ColumnIndexes[ColumnOwnerSid.HeaderText]].Value = namedPipeObject.SecurityDescriptor.Owner.Sid.ToString();
                        row.Cells[m_ColumnIndexes[ColumnOwnerName.HeaderText]].Value = namedPipeObject.SecurityDescriptor.Owner.Sid.Name;
                        row.Cells[m_ColumnIndexes[ColumnGroupSid.HeaderText]].Value = namedPipeObject.SecurityDescriptor.Group.Sid.ToString();
                        row.Cells[m_ColumnIndexes[ColumnGroupName.HeaderText]].Value = namedPipeObject.SecurityDescriptor.Group.Sid.Name;
                        row.Cells[m_ColumnIndexes[ColumnIntegrityLevel.HeaderText]].Value = namedPipeObject.SecurityDescriptor.IntegrityLevel;
                        row.Cells[m_ColumnIndexes[ColumnEndPointType.HeaderText]].Value = namedPipeObject.EndPointType;
                        row.Cells[m_ColumnIndexes[ColumnConfiguration.HeaderText]].Value = namedPipeObject.Configuration;

                        row.Cells[m_ColumnIndexes[ColumnPipeType.HeaderText]].Value = namedPipeObject.PipeType;
                        row.Cells[m_ColumnIndexes[ColumnReadMode.HeaderText]].Value = namedPipeObject.ReadMode;
                        row.Cells[m_ColumnIndexes[ColumnDirectoryGrantedAccess.HeaderText]].Value = namedPipeObject.DirectoryGrantedAccess;
                        row.Cells[m_ColumnIndexes[ColumnGrantedAccess.HeaderText]].Value = namedPipeObject.GrantedAccess;
                        row.Cells[m_ColumnIndexes[ColumnGrantedAccessGeneric.HeaderText]].Value = namedPipeObject.GrantedAccessGeneric;
                        row.Cells[m_ColumnIndexes[ColumnHandle.HeaderText]].Value = namedPipeObject.Handle.ToString();
                        row.Cells[m_ColumnIndexes[ColumnCreationTime.HeaderText]].Value = namedPipeObject.CreationTime;

                        row.Cells[m_ColumnIndexes[ColumnClientPID.HeaderText]].Value = getProcessNameWithProcessPIDs(namedPipeObject);
                        row.Cells[m_ColumnIndexes[ColumnNumberOfLinks.HeaderText]].Value = namedPipeObject.NumberOfLinks;
                        row.Cells[m_ColumnIndexes[ColumnFileCreationTime.HeaderText]].Value = namedPipeObject.FileCreationTime;
                        row.Cells[m_ColumnIndexes[ColumnLastAccessTime.HeaderText]].Value = namedPipeObject.LastAccessTime;
                        row.Cells[m_ColumnIndexes[ColumnLastWriteTime.HeaderText]].Value = namedPipeObject.LastWriteTime;
                        row.Cells[m_ColumnIndexes[ColumnChangeTime.HeaderText]].Value = namedPipeObject.ChangeTime;
                    }
                }
                catch (Exception)
                {
                    // TODO: write to log
                }


                dataGridView1.Rows.Add(row);
                this.m_NamedPipesNumber += 1;
                this.toolStripStatusLabelTotalNamedPipes.Text = "Total Named Pipes: " + this.m_NamedPipesNumber;
            }
        }

        private string getProcessNameWithProcessPIDs(NtNamedPipeFileBase i_NamedPipe)
        {
            var processNames = i_NamedPipe.GetUsingProcessIds()
                .Select(pid =>
                {
                    if (m_ProcessPIDsDictionary.TryGetValue(pid, out string processName))
                    {
                        return processName + " ("+ pid.ToString() + ")";
                    }
                    else
                    {
                        try
                        {
                            using (var p = Process.GetProcessById(pid))
                            {
                                m_ProcessPIDsDictionary.Add(p.Id, p.ProcessName);
                                return p.ProcessName + " (" + pid.ToString() + ")";
                            }
                        }
                        catch
                        {
                            m_ProcessPIDsDictionary.Add(pid, "<no_process>");
                            return "<no_process>" + "(" + pid.ToString() + ")";
                        }
                    }
                });
            
            return string.Join("; ", processNames.Select(nameAndPid => nameAndPid));
        }


        //private string getProcessNameWithProcessPIDs(NtNamedPipeFileBase i_NamedPipe)
        //{
        //    string clientPids = "";
        //    foreach (int pid in i_NamedPipe.GetUsingProcessIds())
        //    {

        //        if (m_ProcessPIDsDictionary.ContainsKey(pid))
        //        {
        //            clientPids += m_ProcessPIDsDictionary[pid] + " (" + pid.ToString() + "); ";
        //        }
        //        else
        //        {
        //            try
        //            {
        //                using (var p = Process.GetProcessById(pid))
        //                {
        //                    clientPids += p.ProcessName + " (" + pid.ToString() + "); ";
        //                    m_ProcessPIDsDictionary.Add(p.Id, p.ProcessName);
        //                }
        //            }
        //            catch
        //            {
        //                clientPids += "<no_process>" + " (" + pid.ToString() + "); ";
        //                m_ProcessPIDsDictionary.Add(pid, "<no_process>");
        //            }
        //        }
        //    }

        //    return clientPids;
        //}

        // TODO: For testing right click on named pipe and display permissions
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string path = @"\\.\pipe\InitShutdown";
        //    //path = @"\Device\NamedPipe\InitShutdown";
        //    //path = @"C:\tmp";
        //    //ShowFileProperties(path);
        //    PermissionDialog.Show(IntPtr.Zero, path);
        //}

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            m_NamedPipesNumber = 0;
            toolStripStatusLabelTotalNamedPipes.Text = "Total Named Pipes: 0";
        }

        private void toolStripButtonGrid_Click(object sender, EventArgs e)
        {
            if (!m_IsGridButtonPressed)
            {
                toolStripButtonGrid.Image = global::PipeViewer.Properties.Resources.grid;
                m_IsGridButtonPressed = true;
                this.dataGridView1.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            }
            else
            {
                toolStripButtonGrid.Image = global::PipeViewer.Properties.Resources.grid_disable;
                m_IsGridButtonPressed = false;
                this.dataGridView1.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            }
        }

        private void toolStripButtonFind_Click(object sender, EventArgs e)
        {
            openFindWindow();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool result = false;

            if (keyData == (Keys.Control | Keys.L))
            {
                openColumnFilterWindow();
                result = true;
            }
            else if (keyData == (Keys.Control | Keys.B))
            {
                Font boldFont = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                Font font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Regular);

                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {

                    if (!dataGridView1.Rows[cell.RowIndex].DefaultCellStyle.Font.Bold)
                    {
                        font = boldFont;
                    }

                    dataGridView1.Rows[cell.RowIndex].DefaultCellStyle.Font = font;
                }

                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {

                    if (!selectedRow.DefaultCellStyle.Font.Bold)
                    {
                        font = boldFont;
                    }

                    dataGridView1.Rows[selectedRow.Index].DefaultCellStyle.Font = font;

                }
                result = true;
            }
            else if (keyData == (Keys.Control | Keys.F))
            {
                openFindWindow();
                result = true;
            }
            else if (keyData == (Keys.Control | Keys.H))
            {
                openHighlightWindows();
                result = true;
            }
            else if (keyData == (Keys.F3))
            {
                // We need to implement the options for the search
                FindWindow_searchForMatch(m_LastSearchValue, true, false, false);
            }
            else if (keyData == (Keys.Shift | Keys.F3))
            {
                // We need to implement the options for the search
                FindWindow_searchForMatch(m_LastSearchValue, false, false, false);
            }

            return result;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            m_NamedPipesNumber = 0;
            Task.Run(() => initializePipeList());
        }

        private void openFindWindow()
        {
            FormSearch findWindow = new FormSearch();
            findWindow.searchForMatch += new FormSearch.searchEventHandler(FindWindow_searchForMatch);
            findWindow.ShowDialog();
        }

        private void FindWindow_searchForMatch(string i_SearchString, bool i_SearchDown, bool i_MatchWholeWord, bool i_MatchSensitive)
        {
            int startIndex = 0;
            m_LastSearchValue = i_SearchString;
            bool foundMatch = false;
            int step = 1;
            if (!i_SearchDown)
            {
                step = -1;
            }

            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                startIndex = selectedRow.Index;
            }

            if (dataGridView1.SelectedCells != null && dataGridView1.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
                startIndex = selectedCell.RowIndex;
            }

            startIndex += step;
            for (int i = startIndex; i < dataGridView1.Rows.Count; i += step)
            {

                if (i < 0)
                {
                    break;
                }

                foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                {
                    // TODO: Add support in Case Sensitive, replicate to RPCMon.
                    if (dataGridView1.Rows[i].Visible && cell.Value != null && cell.Value.ToString().ToLower().Contains(i_SearchString.ToLower()))
                    {
                        cleanAllSelectedCells();
                        dataGridView1.Rows[i].Selected = true;
                        foundMatch = true;
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                        break;
                    }
                }

                if (foundMatch)
                {
                    break;
                }

            }

            if (!foundMatch)
            {
                MessageBox.Show(string.Format("Cannot find string \"{0}\"", i_SearchString), "PipeViewer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cleanAllSelectedCells()
        {
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                dataGridView1.SelectedCells[i].Selected = false;
            }
        }

        private void openColumnSelectionWindow()
        {
            ColumnSelection columnSelection = new ColumnSelection(dataGridView1);
            columnSelection.selectColumnsUpdate += new selectColumnsEventHandler(this.ColumnSelection_selectColumnsUpdate);
            columnSelection.ShowDialog();
        }

        private void ColumnSelection_selectColumnsUpdate(GroupBox i_NamedPipe, GroupBox i_Access, GroupBox i_SecurityDescriptor, GroupBox i_TimeStamp)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                modifyColumnSelection(column, i_NamedPipe);
                modifyColumnSelection(column, i_Access);
                modifyColumnSelection(column, i_SecurityDescriptor);
                modifyColumnSelection(column, i_TimeStamp);
            }
        }

        private void modifyColumnSelection(DataGridViewColumn i_Column, GroupBox i_GroupBox)
        {
            foreach (CheckBox checkBox in i_GroupBox.Controls)
            {
                if (checkBox.Text == i_Column.HeaderText)
                {
                    if (checkBox.Checked)
                    {
                        dataGridView1.Columns[i_Column.Index].Visible = true;
                    }
                    else
                    {
                        dataGridView1.Columns[i_Column.Index].Visible = false;
                    }
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                openColumnSelectionWindow();
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // TODO: Whenimplement...
        }

        #region Column Filter

        private void toolStripButtonFilter_Click(object sender, EventArgs e)
        {
            openColumnFilterWindow();
        }

        private void openColumnFilterWindow()
        {
            FormColumnFilter columnFilter = new FormColumnFilter(ref m_LastListViewColumnFilter);
            columnFilter.FilterOKUpdate += new FilterOKEventHandler(ColumnFilter_OKFilter);
            columnFilter.ShowDialog();
        }

        private void openHighlightWindows()
        {
            FormHighlighting hightlightWindow = new FormHighlighting(ref m_LastListViewHighlighFilter);
            hightlightWindow.hightlightRowsUpdate += HightlightWindow_hightlightRowsUpdate;
            hightlightWindow.ShowDialog();
        }

        private void HightlightWindow_hightlightRowsUpdate(ListView i_ListView)
        {
            m_LastListViewHighlighFilter = i_ListView;
            updateFilterDicts(i_ListView, Utils.eFormNames.FormHighlighFilter);
            if (m_IncludeHighlightDict.Count.Equals(0))
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    this.dataGridView1.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;
                }
                return;
            }
            filterRowsByFilterRules(Utils.eFormNames.FormHighlighFilter);
        }

        private void ColumnFilter_OKFilter(ListView i_ListView)
        {
            m_LastListViewColumnFilter = i_ListView;
            updateFilterDicts(i_ListView, Utils.eFormNames.FormColumnFilter);
            if (m_IncludeFilterDict.Count.Equals(0))
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    row.Visible = true;
                }
            }
            filterRowsByFilterRules(Utils.eFormNames.FormColumnFilter);
        }

        private void filterRowsByFilterRules(Utils.eFormNames i_FormName)
        {

            // TODO: What happens if one row is already Filtered\Highlight? It will hide it. Need to fix it
            // so there will be OR between the rules
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                filterSingleRowByFilterRules(i_FormName, row);
            }
        }

        private void filterSingleRowByFilterRules(Utils.eFormNames i_FormName, DataGridViewRow row)
        {
            if (i_FormName == Utils.eFormNames.FormColumnFilter)
            {
                filterRow(i_FormName, row, m_IncludeFilterDict, m_ExcludeFilterDict);
            }
            else
            {
                filterRow(i_FormName, row, m_IncludeHighlightDict, m_ExcludeHighlightDict);
            }
        }
        private void filterRow(Utils.eFormNames i_FormName, DataGridViewRow row, IDictionary<string, List<ListViewItem>> includeDict, IDictionary<string, List<ListViewItem>> excludeDict)
        {
            bool visable = false;
            foreach (var pair in excludeDict)
            {
                foreach (var rule in pair.Value)
                {
                    if (checkIfShouldBeVisable(rule, row, pair.Key))
                    {
                        hideFilterRowBasedOnForm(i_FormName, row.Index);
                        return;
                    }
                }
            }
            if (!excludeDict.Count.Equals(0))
            {
                filterRowBasedOnForm(i_FormName, row.Index, "Include");
            }


            foreach (var pair in includeDict)
            {
                foreach (var rule in pair.Value)
                {
                    if (checkIfShouldBeVisable(rule, row, pair.Key))
                    {
                        visable = true;
                        break;
                    }
                }
                if (!visable)
                {
                    hideFilterRowBasedOnForm(i_FormName, row.Index);
                    return;
                }
                visable = false;
            }
            if (!includeDict.Count.Equals(0))
            {
                filterRowBasedOnForm(i_FormName, row.Index, "Include");
            }
        }

        private bool checkIfShouldBeVisable(ListViewItem rule, DataGridViewRow row, String key)
        {
            DataGridViewCell cellValueFromGridViewCell = row.Cells["Column" + rule.SubItems[0].Text];
            string valueFromFilter = rule.SubItems[(int)Utils.eFilterNames.Value].Text;
            if (rule.SubItems[(int)Utils.eFilterNames.Relation].Text == "contains")
            {
                if (row.Cells["Column" + key].Value != null && row.Cells["Column" + key].Value.ToString().Contains(rule.SubItems[(int)Utils.eFilterNames.Value].Text))
                {
                    if (cellValueFromGridViewCell.Value.ToString().Contains(valueFromFilter))
                    {
                        return true;
                    }
                }
            }
            else if (rule.SubItems[(int)Utils.eFilterNames.Relation].Text == "is")
            {
                if (cellValueFromGridViewCell.Value.ToString() == valueFromFilter)
                {
                    return true;
                }
            }
            else if (rule.SubItems[(int)Utils.eFilterNames.Relation].Text == "begins with")
            {
                if (cellValueFromGridViewCell.Value.ToString().StartsWith(valueFromFilter))
                {
                    return true;
                }
            }
            else if (rule.SubItems[(int)Utils.eFilterNames.Relation].Text == "ends with")
            {

                if (cellValueFromGridViewCell.Value.ToString().EndsWith(valueFromFilter))
                {
                    return true;
                }
            }
            return false;
        }

        private void updateFilterDicts(ListView i_ListView, Utils.eFormNames i_FormName)
        {
            if (i_FormName == Utils.eFormNames.FormColumnFilter)
            {
                m_IncludeFilterDict.Clear();
                m_ExcludeFilterDict.Clear();
            }
            else
            {
                m_IncludeHighlightDict.Clear();
                m_ExcludeHighlightDict.Clear();
            }
            foreach (ListViewItem rule in i_ListView.Items)
            {
                if (rule.Checked)
                {
                    addItemToFilterDict(rule, rule.SubItems[(int)Utils.eFilterNames.Action].Text == "Exclude", i_FormName);
                }
            }
        }

        private void addItemToFilterDict(ListViewItem rule, bool addToExcludeList, Utils.eFormNames i_FormName)
        {
            if (i_FormName == Utils.eFormNames.FormColumnFilter)
            {
                if (addToExcludeList)
                {
                    if (!m_ExcludeFilterDict.ContainsKey(rule.SubItems[0].Text))
                    {
                        m_ExcludeFilterDict.Add(rule.SubItems[0].Text, new List<ListViewItem>());
                    }
                    m_ExcludeFilterDict[rule.SubItems[0].Text].Add(rule);
                }
                else
                {
                    if (!m_IncludeFilterDict.ContainsKey(rule.SubItems[0].Text))
                    {
                        m_IncludeFilterDict.Add(rule.SubItems[0].Text, new List<ListViewItem>());
                    }
                    m_IncludeFilterDict[rule.SubItems[0].Text].Add(rule);
                }
            }
            else
            {
                if (addToExcludeList)
                {
                    if (!m_ExcludeHighlightDict.ContainsKey(rule.SubItems[0].Text))
                    {
                        m_ExcludeHighlightDict.Add(rule.SubItems[0].Text, new List<ListViewItem>());
                    }
                    m_ExcludeHighlightDict[rule.SubItems[0].Text].Add(rule);
                }
                else
                {
                    if (!m_IncludeHighlightDict.ContainsKey(rule.SubItems[0].Text))
                    {
                        m_IncludeHighlightDict.Add(rule.SubItems[0].Text, new List<ListViewItem>());
                    }
                    m_IncludeHighlightDict[rule.SubItems[0].Text].Add(rule);
                }
            }
        }


        private void filterRowBasedOnForm(Utils.eFormNames i_FormName, int i_RowIndex, string i_Action)
        {
            if (i_FormName == Utils.eFormNames.FormColumnFilter)
            {
                this.dataGridView1.Rows[i_RowIndex].Visible = (i_Action == "Include");
            }
            else
            {
                this.dataGridView1.Rows[i_RowIndex].DefaultCellStyle.BackColor = getHighlighColorIfRequired(i_Action);
            }
        }

        private void hideFilterRowBasedOnForm(Utils.eFormNames i_FormName, int i_RowIndex)
        {
            if (i_FormName == Utils.eFormNames.FormColumnFilter)
            {
                this.dataGridView1.Rows[i_RowIndex].Visible = false;
            }
            else
            {
                this.dataGridView1.Rows[i_RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private Color getHighlighColorIfRequired(string i_Action)
        {
            Color resultColor = Color.White;
            if (i_Action == "Include")
            {
                resultColor = Color.Cyan;
            }

            return resultColor;
        }

        #endregion Column Filter

        private void toolStripButtonHighLight_Click(object sender, EventArgs e)
        {
            openHighlightWindows();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog();
            //            MessageBox.Show(@"Author: Eviatar Gerzi (@g3rzi)
            //Contributers: Natan Tunik
            //Version: 1.0
            //Link: https://github.com/cyberark/PipeViewer
            //Copyright (c) 2022 CyberArk Software Ltd. All rights reserved", "About");
        }

        #region Cell Mouse Click


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                m_CurrentRowIndexRightClick = e.RowIndex;
                m_CurrentColumnIndexRightClick = e.ColumnIndex;
                contextMenuStripRightClickGridView.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void copyRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string copiedRow = "";

            foreach (DataGridViewCell cell in dataGridView1.Rows[m_CurrentRowIndexRightClick].Cells)
            {
                copiedRow += cell.Value + " ";
            }

            if (copiedRow != "")
            {
                System.Windows.Forms.Clipboard.SetText(copiedRow);
            }
        }

        #endregion

        #region Save

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save results as CSV";
            saveDialog.InitialDirectory = @"c:\";
            saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveDialog.FilterIndex = 2;
            saveDialog.RestoreDirectory = true;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                saveDataGridViewToCSV(saveDialog.FileName);
            }
        }

        // Taken from https://stackoverflow.com/a/26259909/2153777
        private void saveDataGridViewToCSV(string filename)
        {
            DataGridView tempDataGridView = dataGridView1;
            foreach (DataGridViewColumn column in tempDataGridView.Columns)
            {
                tempDataGridView.Columns[column.Index].Visible = true;
            }
            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            tempDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            // Select all the cells
            tempDataGridView.SelectAll();
            // Copy selected cells to DataObject
            DataObject dataObject = tempDataGridView.GetClipboardContent();
            // Get the text of the DataObject, and serialize it to a file
            File.WriteAllText(filename, dataObject.GetText(TextDataFormat.CommaSeparatedValue).Replace("\n", ""));
        }

        private void copyCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string copiedCell = "";
            if (dataGridView1.Rows[m_CurrentRowIndexRightClick] != null)
            {
                if (dataGridView1.Rows[m_CurrentRowIndexRightClick].Cells[m_CurrentColumnIndexRightClick].Value != null)
                {
                    copiedCell = dataGridView1.Rows[m_CurrentRowIndexRightClick].Cells[m_CurrentColumnIndexRightClick].Value.ToString();
                }
            }

            if (copiedCell != "")
            {
                System.Windows.Forms.Clipboard.SetText(copiedCell);
            }
        }


        #endregion

    }
}
