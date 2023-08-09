using System;
using System.IO;
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace PipeViewer
{
    public class Utils
    {
        public enum eFormNames
        {
            FormColumnFilter,
            FormHighlighFilter
        }

        public enum eFilterNames
        {
            Column, Relation, Value, Action
        }

        //public enum eColumnNames
        //{
        //    Name = 0,
        //    IntegrityLevel,
        //    Permissions,
        //    Sddl,
        //    ClientPID,
        //    PipeType,
        //    Configuration,
        //    ReadMode,
        //    NumberOfLinks,
        //    DirectoryGrantedAccess,
        //    GrantedAccess,
        //    GrantedAccessGeneric,
        //    CreationTime,
        //    OwnerSid,
        //    OwnerName,
        //    GroupSid,
        //    GroupName,
        //    EndPointType,
        //    Handle,
        //    FileCreationTime,
        //    LastAccessTime,
        //    LastWriteTime,
        //    ChangeTime,
        //}

        public static string[] ColumnNames = new string[]
        {
            "Name",
            "IntegrityLevel",
            "Permissions",
            "SDDL",
            "ClientPID",
            "PipeType",
            "Configuration",
            "ReadMode",
            "NumberOfLinks",
            "DirectoryGrantedAccess",
            "GrantedAccess",
            "GrantedAccessGeneric",
            "OwnerSid",
            "OwnerName",
            "GroupSid",
            "GroupName",
            "EndPointType",
            "Handle",
            "CreationTime",
            "FileCreationTime",
            "LastAccessTime",
            "LastWriteTime",
            "ChangeTime"
        };

        public static ListView CopyListView(ListView originalListView)
        {
            ListView copiedListView = new ListView();

            // Copy properties from the original ListView
            copiedListView.View = originalListView.View;
            copiedListView.FullRowSelect = originalListView.FullRowSelect;

            // Copy columns
            foreach (ColumnHeader column in originalListView.Columns)
            {
                copiedListView.Columns.Add((ColumnHeader)column.Clone());
            }

            // Copy items
            foreach (ListViewItem item in originalListView.Items)
            {
                ListViewItem copiedItem = (ListViewItem)item.Clone();
                copiedListView.Items.Add(copiedItem);
            }

            return copiedListView;
        }

        //static Utils()
        //{
        //    m_ColumnMapToIndex = new Dictionary<string, int>();

        //    // Populate the dictionary with the values of the eColumnNames enum
        //    foreach (eColumnNames column in Enum.GetValues(typeof(eColumnNames)))
        //    {
        //        m_ColumnMapToIndex.Add(column.ToString(), (int)column);
        //    }
        //}

        // TODO: Can we make it dynamic? like use a static constructor?
        //public static readonly Dictionary<string, int> m_ColumnMapToIndex = new Dictionary<string, int>()
        //{
        //    { eColumnNames.Name.ToString(), (int)eColumnNames.Name },
        //    { eColumnNames.IntegrityLevel.ToString(), (int)eColumnNames.IntegrityLevel },
        //    { eColumnNames.Permissions.ToString(), (int)eColumnNames.Permissions },
        //    { eColumnNames.Sddl.ToString(), (int)eColumnNames.Sddl },
        //    { eColumnNames.ClientPID.ToString(), (int)eColumnNames.ClientPID },
        //    { eColumnNames.PipeType.ToString(), (int)eColumnNames.PipeType },
        //    { eColumnNames.Configuration.ToString(), (int)eColumnNames.Configuration },
        //    { eColumnNames.ReadMode.ToString(), (int)eColumnNames.ReadMode },
        //    { eColumnNames.NumberOfLinks.ToString(), (int)eColumnNames.NumberOfLinks },
        //    { eColumnNames.DirectoryGrantedAccess.ToString(), (int)eColumnNames.DirectoryGrantedAccess },
        //    { eColumnNames.GrantedAccess.ToString(), (int)eColumnNames.GrantedAccess },
        //    { eColumnNames.GrantedAccessGeneric.ToString(), (int)eColumnNames.GrantedAccessGeneric },
        //    { eColumnNames.CreationTime.ToString(), (int)eColumnNames.CreationTime },
        //    { eColumnNames.OwnerSid.ToString(), (int)eColumnNames.OwnerSid },
        //    { eColumnNames.OwnerName.ToString(), (int)eColumnNames.OwnerName },
        //    { eColumnNames.GroupSid.ToString(), (int)eColumnNames.GroupSid },
        //    { eColumnNames.GroupName.ToString(), (int)eColumnNames.GroupName },
        //    { eColumnNames.EndPointType.ToString(), (int)eColumnNames.EndPointType },
        //    { eColumnNames.Handle.ToString(), (int)eColumnNames.Handle },
        //    { eColumnNames.FileCreationTime.ToString(), (int)eColumnNames.FileCreationTime },
        //    { eColumnNames.LastAccessTime.ToString(), (int)eColumnNames.LastAccessTime },
        //    { eColumnNames.LastWriteTime.ToString(), (int)eColumnNames.LastWriteTime},
        //    { eColumnNames.ChangeTime.ToString(), (int)eColumnNames.ChangeTime}
        //};


        public static void CreateDummyPipeForTesting()
        {
            // Create a new named pipe server
            //NamedPipeServerStream pipeServer = new NamedPipeServerStream("MyPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
            /**
             * This will create a named pipe with the name "myPipe" and full privileges for everyone. 
             * The PipeAccessRights.FullControl flag grants full control over the named pipe to all users, 
             * including the ability to read, write, and execute. 
             * The PipeAccessRights.AccessSystemSecurity flag grants the ability to access the system security descriptor associated with the named pipe.
             * */

            // get the pipe security object and add an access rule granting full control to everyone
            PipeSecurity pipeSecurity = new PipeSecurity();
            //pipeSecurity.AddAccessRule(new PipeAccessRule("Everyone", PipeAccessRights.FullControl, AccessControlType.Allow));
            // Set DACL to NULL.
            /*
             * The SetAccessRuleProtection method is used to set the DACL to NULL. 
             * The first argument specifies whether to protect the DACL from inheriting access control entries (ACEs) from the parent object. 
             * The second argument specifies whether to protect the DACL from being modified. 
             * Setting both arguments to true will set the DACL to NULL.
             * */
            pipeSecurity.SetAccessRuleProtection(true, true);

            NamedPipeServerStream pipeServer = new NamedPipeServerStream("myPipe", PipeDirection.InOut,
                                                -1, PipeTransmissionMode.Byte, PipeOptions.None, 4096, 4096, pipeSecurity);

            // Wait for a client to connect
            Console.WriteLine("Waiting for client connection...");
            pipeServer.WaitForConnection();

            Console.WriteLine("Client connected.");

            // Read and write to the pipe
            using (StreamReader reader = new StreamReader(pipeServer))
            using (StreamWriter writer = new StreamWriter(pipeServer))
            {
                while (true)
                {
                    // Read a message from the client
                    string message = reader.ReadLine();
                    Console.WriteLine("Received message: " + message);

                    // Write a message to the client
                    writer.WriteLine("Hello from the server!");
                    writer.Flush();
                }
            }
        }


        //public static void dummyLoopRowsForDebug()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Thread.Sleep(500);
        //        DataGridViewRow row = new DataGridViewRow();
        //        row.CreateCells(dataGridView1);

        //        row.Cells[m_ColumnIndexes[ColumnName.HeaderText]].Value = @"\\.\pipe\mypipe";
        //        row.Cells[m_ColumnIndexes[ColumnSddl.HeaderText]].Value = "";
        //        row.Cells[m_ColumnIndexes[ColumnOwnerSid.HeaderText]].Value = "1";
        //        row.Cells[m_ColumnIndexes[ColumnOwnerName.HeaderText]].Value = "SidName";
        //        row.Cells[m_ColumnIndexes[ColumnGroupSid.HeaderText]].Value = "1";
        //        row.Cells[m_ColumnIndexes[ColumnGroupName.HeaderText]].Value = "GroupName";
        //        row.Cells[m_ColumnIndexes[ColumnIntegrityLevel.HeaderText]].Value = "Medium";
        //        row.Cells[m_ColumnIndexes[ColumnEndPointType.HeaderText]].Value = "Client";
        //        row.Cells[m_ColumnIndexes[ColumnConfiguration.HeaderText]].Value = "FullDuplex";
        //        row.Cells[m_ColumnIndexes[ColumnClientPID.HeaderText]].Value = "lsass (1)";
        //        row.Cells[m_ColumnIndexes[ColumnPipeType.HeaderText]].Value = "Client";
        //        row.Cells[m_ColumnIndexes[ColumnReadMode.HeaderText]].Value = "";
        //        row.Cells[m_ColumnIndexes[ColumnNumberOfLinks.HeaderText]].Value = "1";
        //        row.Cells[m_ColumnIndexes[ColumnDirectoryGrantedAccess.HeaderText]].Value = "";
        //        row.Cells[m_ColumnIndexes[ColumnGrantedAccess.HeaderText]].Value = "";
        //        row.Cells[m_ColumnIndexes[ColumnGrantedAccessGeneric.HeaderText]].Value = "";

        //        row.Cells[m_ColumnIndexes[ColumnHandle.HeaderText]].Value = "0x1";
        //        row.Cells[m_ColumnIndexes[ColumnCreationTime.HeaderText]].Value = "";
        //        row.Cells[m_ColumnIndexes[ColumnFileCreationTime.HeaderText]].Value = "";
        //        row.Cells[m_ColumnIndexes[ColumnLastAccessTime.HeaderText]].Value = "";
        //        row.Cells[m_ColumnIndexes[ColumnLastWriteTime.HeaderText]].Value = "";
        //        row.Cells[m_ColumnIndexes[ColumnChangeTime.HeaderText]].Value = "";
        //        row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Regular);
        //        dataGridView1.Rows.Add(row);
        //    }
        //}
        //private void dummRowsForDebug()
        //{
        //    DataGridViewRow row = new DataGridViewRow();
        //    row.CreateCells(dataGridView1);

        //    row.Cells[m_ColumnIndexes[ColumnName.HeaderText]].Value = @"\\.\pipe\mypipe";
        //    row.Cells[m_ColumnIndexes[ColumnSddl.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerName.HeaderText]].Value = "SidName";
        //    row.Cells[m_ColumnIndexes[ColumnGroupSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnGroupName.HeaderText]].Value = "GroupName";
        //    row.Cells[m_ColumnIndexes[ColumnIntegrityLevel.HeaderText]].Value = "Medium";
        //    row.Cells[m_ColumnIndexes[ColumnEndPointType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnConfiguration.HeaderText]].Value = "FullDuplex";
        //    row.Cells[m_ColumnIndexes[ColumnClientPID.HeaderText]].Value = "lsass (1)";
        //    row.Cells[m_ColumnIndexes[ColumnPipeType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnReadMode.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnNumberOfLinks.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnDirectoryGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccessGeneric.HeaderText]].Value = "";

        //    row.Cells[m_ColumnIndexes[ColumnHandle.HeaderText]].Value = "0x1";
        //    row.Cells[m_ColumnIndexes[ColumnCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnFileCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastAccessTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastWriteTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnChangeTime.HeaderText]].Value = "";
        //    row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Regular);
        //    dataGridView1.Rows.Add(row);

        //    row = new DataGridViewRow();
        //    row.CreateCells(dataGridView1);

        //    row.Cells[m_ColumnIndexes[ColumnName.HeaderText]].Value = @"\\.\pipe\mypipe";
        //    row.Cells[m_ColumnIndexes[ColumnSddl.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerName.HeaderText]].Value = "SidName";
        //    row.Cells[m_ColumnIndexes[ColumnGroupSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnGroupName.HeaderText]].Value = "GroupName";
        //    row.Cells[m_ColumnIndexes[ColumnIntegrityLevel.HeaderText]].Value = "Medium";
        //    row.Cells[m_ColumnIndexes[ColumnEndPointType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnConfiguration.HeaderText]].Value = "FullDuplex";
        //    row.Cells[m_ColumnIndexes[ColumnClientPID.HeaderText]].Value = "lsass (1)";
        //    row.Cells[m_ColumnIndexes[ColumnPipeType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnReadMode.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnNumberOfLinks.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnDirectoryGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccessGeneric.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnHandle.HeaderText]].Value = "0x1";
        //    row.Cells[m_ColumnIndexes[ColumnCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnFileCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastAccessTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastWriteTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnChangeTime.HeaderText]].Value = "";
        //    row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Regular);
        //    dataGridView1.Rows.Add(row);

        //    row = new DataGridViewRow();
        //    row.CreateCells(dataGridView1);

        //    row.Cells[m_ColumnIndexes[ColumnName.HeaderText]].Value = @"\\.\pipe\mypipe";
        //    row.Cells[m_ColumnIndexes[ColumnSddl.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerName.HeaderText]].Value = "SidName";
        //    row.Cells[m_ColumnIndexes[ColumnGroupSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnGroupName.HeaderText]].Value = "GroupName";
        //    row.Cells[m_ColumnIndexes[ColumnIntegrityLevel.HeaderText]].Value = "Medium";
        //    row.Cells[m_ColumnIndexes[ColumnEndPointType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnConfiguration.HeaderText]].Value = "FullDuplex";
        //    row.Cells[m_ColumnIndexes[ColumnClientPID.HeaderText]].Value = "lsass (1)";
        //    row.Cells[m_ColumnIndexes[ColumnPipeType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnReadMode.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnNumberOfLinks.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnDirectoryGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccessGeneric.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnHandle.HeaderText]].Value = "0x1";
        //    row.Cells[m_ColumnIndexes[ColumnCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnFileCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastAccessTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastWriteTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnChangeTime.HeaderText]].Value = "";
        //    row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Regular);
        //    dataGridView1.Rows.Add(row);

        //    row = new DataGridViewRow();
        //    row.CreateCells(dataGridView1);

        //    row.Cells[m_ColumnIndexes[ColumnName.HeaderText]].Value = @"\\.\pipe\mypipe";
        //    row.Cells[m_ColumnIndexes[ColumnSddl.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerName.HeaderText]].Value = "SidName";
        //    row.Cells[m_ColumnIndexes[ColumnGroupSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnGroupName.HeaderText]].Value = "GroupName";
        //    row.Cells[m_ColumnIndexes[ColumnIntegrityLevel.HeaderText]].Value = "Medium";
        //    row.Cells[m_ColumnIndexes[ColumnEndPointType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnConfiguration.HeaderText]].Value = "FullDuplex";
        //    row.Cells[m_ColumnIndexes[ColumnClientPID.HeaderText]].Value = "lsass (1)";
        //    row.Cells[m_ColumnIndexes[ColumnPipeType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnReadMode.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnNumberOfLinks.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnDirectoryGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccessGeneric.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnHandle.HeaderText]].Value = "0x1";
        //    row.Cells[m_ColumnIndexes[ColumnCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnFileCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastAccessTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastWriteTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnChangeTime.HeaderText]].Value = "";
        //    row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Regular);
        //    dataGridView1.Rows.Add(row);

        //    row = new DataGridViewRow();
        //    row.CreateCells(dataGridView1);

        //    row.Cells[m_ColumnIndexes[ColumnName.HeaderText]].Value = @"\\.\pipe\mypipe";
        //    row.Cells[m_ColumnIndexes[ColumnSddl.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerName.HeaderText]].Value = "SidName";
        //    row.Cells[m_ColumnIndexes[ColumnGroupSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnGroupName.HeaderText]].Value = "GroupName";
        //    row.Cells[m_ColumnIndexes[ColumnIntegrityLevel.HeaderText]].Value = "Medium";
        //    row.Cells[m_ColumnIndexes[ColumnEndPointType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnConfiguration.HeaderText]].Value = "";


        //    row.Cells[m_ColumnIndexes[ColumnClientPID.HeaderText]].Value = "lsass (1)";
        //    row.Cells[m_ColumnIndexes[ColumnPipeType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnReadMode.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnNumberOfLinks.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnDirectoryGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccessGeneric.HeaderText]].Value = "";

        //    row.Cells[m_ColumnIndexes[ColumnHandle.HeaderText]].Value = "0x1";
        //    row.Cells[m_ColumnIndexes[ColumnCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnFileCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastAccessTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastWriteTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnChangeTime.HeaderText]].Value = "";
        //    row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Regular);
        //    dataGridView1.Rows.Add(row);

        //    row = new DataGridViewRow();
        //    row.CreateCells(dataGridView1);

        //    row.Cells[m_ColumnIndexes[ColumnName.HeaderText]].Value = @"\\.\pipe\mypipe";
        //    row.Cells[m_ColumnIndexes[ColumnSddl.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerName.HeaderText]].Value = "SidName";
        //    row.Cells[m_ColumnIndexes[ColumnGroupSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnGroupName.HeaderText]].Value = "GroupName";
        //    row.Cells[m_ColumnIndexes[ColumnIntegrityLevel.HeaderText]].Value = "Medium";
        //    row.Cells[m_ColumnIndexes[ColumnEndPointType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnConfiguration.HeaderText]].Value = "FullDuplex";


        //    row.Cells[m_ColumnIndexes[ColumnClientPID.HeaderText]].Value = "lsass (1)";
        //    row.Cells[m_ColumnIndexes[ColumnPipeType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnReadMode.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnNumberOfLinks.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnDirectoryGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccessGeneric.HeaderText]].Value = "";

        //    row.Cells[m_ColumnIndexes[ColumnHandle.HeaderText]].Value = "0x1";
        //    row.Cells[m_ColumnIndexes[ColumnCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnFileCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastAccessTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastWriteTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnChangeTime.HeaderText]].Value = "";
        //    row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Regular);
        //    dataGridView1.Rows.Add(row);

        //    row = new DataGridViewRow();
        //    row.CreateCells(dataGridView1);

        //    row.Cells[m_ColumnIndexes[ColumnName.HeaderText]].Value = @"\\.\pipe\mypipe";
        //    row.Cells[m_ColumnIndexes[ColumnSddl.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnOwnerName.HeaderText]].Value = "SidName";
        //    row.Cells[m_ColumnIndexes[ColumnGroupSid.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnGroupName.HeaderText]].Value = "GroupName";
        //    row.Cells[m_ColumnIndexes[ColumnIntegrityLevel.HeaderText]].Value = "Medium";
        //    row.Cells[m_ColumnIndexes[ColumnEndPointType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnConfiguration.HeaderText]].Value = "FullDuplex";


        //    row.Cells[m_ColumnIndexes[ColumnClientPID.HeaderText]].Value = "lsass (1)";
        //    row.Cells[m_ColumnIndexes[ColumnPipeType.HeaderText]].Value = "Client";
        //    row.Cells[m_ColumnIndexes[ColumnReadMode.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnNumberOfLinks.HeaderText]].Value = "1";
        //    row.Cells[m_ColumnIndexes[ColumnDirectoryGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccess.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnGrantedAccessGeneric.HeaderText]].Value = "";

        //    row.Cells[m_ColumnIndexes[ColumnHandle.HeaderText]].Value = "0x1";
        //    row.Cells[m_ColumnIndexes[ColumnCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnFileCreationTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastAccessTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnLastWriteTime.HeaderText]].Value = "";
        //    row.Cells[m_ColumnIndexes[ColumnChangeTime.HeaderText]].Value = "";
        //    row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Regular);
        //    dataGridView1.Rows.Add(row);
        //}
    }
}
