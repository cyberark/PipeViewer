using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Be.Windows.Forms;


namespace PipeViewer
{
    public partial class PipeChatForm : Form
    {
        private delegate void startClientDelgation();
        private string m_PipeName;
        private NamedPipeClientStream m_Client;
        private List<byte> m_ByteList = new List<byte>();
        private bool m_Closed = false;
        private string m_LastSearchValue = string.Empty;

        public PipeChatForm(string i_PipeName)
        {            
            InitializeComponent();
            this.Text += " - Chating with " + i_PipeName;
            m_PipeName = i_PipeName.Replace(@"\\.\pipe\", "");
           // m_PipeName = "Foo";
            dataGridView1.Columns["ColumnText"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["ColumnBinary"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            chatHexBox.ByteProvider = new DynamicByteProvider(m_ByteList);
            startClient();
        }

        private void startClient()
        {
            if (this.InvokeRequired)
            {
                startClientDelgation s = new startClientDelgation(startClient);
                this.Invoke(s);
            }
            else
            {
                // Get the synchronization context for the UI thread
                var uiContext = SynchronizationContext.Current;
                m_Client = new NamedPipeClientStream(".", m_PipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
                addRowToDataGridView("Trying to connect...", i_Icon: global::PipeViewer.Properties.Resources.loading);
                m_Client.ConnectAsync();
                Task task = Task.Run(() =>
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    string dataFromPipe;
                    while (!m_Closed)
                    {

                        if (!m_Client.IsConnected)
                        {
                            if (isConnectedLabel.Text == "Connected")
                            {
                                uiContext.Post(new SendOrPostCallback((_) =>
                                {
                                    Color myRedColor = Color.FromArgb(255, 228, 226);
                                    addRowToDataGridView("Disconnected", i_BackColor: myRedColor, i_Icon: global::PipeViewer.Properties.Resources.disconnected);
                                    isConnectedLabel.Text = "Not Connected";
                                    isConnectedLabel.ForeColor = Color.Red;
                                    enableOrDisableChat(false);
                                }), null);
                            }
                            continue;
                        }
                        if (isConnectedLabel.Text != "Connected")
                        {
                            uiContext.Post(new SendOrPostCallback((_) =>
                            {
                                Color myGreenColor = Color.FromArgb(227, 252, 191);
                                addRowToDataGridView("Connected", i_BackColor: myGreenColor, i_Icon: global::PipeViewer.Properties.Resources.connected);
                                isConnectedLabel.Text = "Connected";
                                isConnectedLabel.ForeColor = Color.Green;
                                enableOrDisableChat(true);
                            }), null);
                        }

                        bytesRead = m_Client.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            continue;
                        }

                        dataFromPipe = encodeByteToString(buffer, bytesRead);
                        string dataFromPipeWithNewLines = splitStringEvery16Bytes(dataFromPipe);
                        uiContext.Post(new SendOrPostCallback((_) =>
                        {
                            string binaryText = convertByteArrayAndSplit(buffer, bytesRead);
                            addRowToDataGridView(dataFromPipeWithNewLines, i_BinaryText: binaryText, i_ForeColor: Color.Green, i_Icon: global::PipeViewer.Properties.Resources.recieve);
                        }), null);
                    }
                });
            }
        }

        private string encodeByteToString(byte[] i_Buffer, int i_BytesRead)
        {
            StringBuilder encodedString = new StringBuilder();
            for (int i = 0; i < i_BytesRead; i++)
            {
                char charToAppend = (int)i_Buffer[i] > 126 || (int)i_Buffer[i] < 21 ? '.' : (char)i_Buffer[i];
                encodedString.Append(charToAppend);
            }

            return encodedString.ToString();
        }

        private void enableOrDisableChat(bool i_EnabledOrDisabled)
        {
            textBox.Enabled = i_EnabledOrDisabled;
            chatHexBox.Enabled = i_EnabledOrDisabled;
            sendButton.Enabled = i_EnabledOrDisabled;
        }

        private void addRowToDataGridView(string i_Text, string i_BinaryText = "", Color i_ForeColor = default(Color), Color i_BackColor = default(Color), Bitmap i_Icon = null)
        {
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            StringBuilder rowCounter = new StringBuilder();
            int count = 0;
            int index = i_BinaryText.IndexOf("\r\n");

            while (index != -1)
            {
                count++;
                index = i_BinaryText.IndexOf("\r\n", index + 1);
            }
            if (i_BinaryText != "")
            {
                for (int i = 0; i <= count; i++)
                {
                    int bytescount = i * 16;
                    rowCounter.AppendLine("0x" + bytescount.ToString("X"));
                }
            }
            string resRowHex = rowCounter.ToString();
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = DateTime.Now.ToString("HH:mm:ss:fff"), Style = { ForeColor = Color.LightSlateGray, Font = new Font("Courier New", 12) } });
            dataGridViewRow.Cells.Add(new DataGridViewImageCell { Value = i_Icon });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = i_Text, Style = { ForeColor = i_ForeColor, Font = new Font("Courier New", 12) } });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = i_BinaryText !="" ? resRowHex.Substring(0, resRowHex.LastIndexOf("\r\n")) : "", Style = { Font = new Font("Courier New", 12) } });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = i_BinaryText, Style = { Font = new Font("Courier New", 12) } });
            dataGridViewRow.DefaultCellStyle.BackColor = i_BackColor;
            dataGridView1.Rows.Add(dataGridViewRow);
            //Show the last row
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex + 1;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && !ModifierKeys.HasFlag(Keys.Shift) && tabControl1.SelectedTab == TextTab)
            {
                sendText();
                e.Handled = true;
                textBox.SelectionStart = 0;
            }
        }

        private void sendText()
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) || !m_Client.IsConnected)
            {
                return;
            }
            byte[] buffer = Encoding.ASCII.GetBytes(textBox.Text);

            string splitedText = splitStringEvery16Bytes(textBox.Text);
            string binaryText = convertByteArrayAndSplit(buffer, buffer.Length);
            addRowToDataGridView(splitedText, i_BinaryText: binaryText, i_ForeColor: Color.Blue, i_Icon: global::PipeViewer.Properties.Resources.send);
            m_Client.Write(buffer, 0, textBox.Text.Length);
            textBox.Clear();
        }

        private string convertByteArrayAndSplit(byte[] i_ByteArray, int i_BufferSize)
        {
            string binaryText = "";

            for (int i = 0; i < i_BufferSize; ++i)
            {
                binaryText += i_ByteArray[i].ToString("X2");
                binaryText += i > 1 && (i + 1) % 16 == 0 && i != i_BufferSize - 1 ? Environment.NewLine : " ";
            }

            return binaryText;
        }

        private string splitStringEvery16Bytes(string i_Str)
        {
            string splitedString = String.Empty;

            for (int i = 0; i < i_Str.Length; i++)
            {
                splitedString += i_Str[i];
                if (i > 1 && (i + 1) % 16 == 0 && i !=i_Str.Length - 1)
                {
                    splitedString += Environment.NewLine;
                }
            }

            return splitedString;
        }

        private string splitStringEvery16Bytes(List <byte> i_ByteList)
        {
            StringBuilder modifiedString = new StringBuilder();

            for (int i = 0; i < i_ByteList.Count; i++)
            {
                char charToAppend = (int)i_ByteList[i] > 126 || (int)i_ByteList[i] < 21 ? '.' : (char)i_ByteList[i];
                modifiedString.Append(charToAppend);

                if (i > 1 && (i + 1) % 16 == 0 && i != i_ByteList.Count - 1)
                {
                    modifiedString.AppendLine();
                }
            }

            return modifiedString.ToString();
        }

        private void exportToCsvButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.Title = "Export to CSV";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                exportToCSV(saveFileDialog.FileName);
                MessageBox.Show("CSV file exported successfully.", "Export to CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exportToCSV(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // Append column names
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if(column.Name != "ColumnIcon")
                {
                    sb.Append(column.HeaderText);
                    sb.Append(",");
                }
            }

            sb.AppendLine();

            // Append rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != dataGridView1.Columns["ColumnIcon"].Index)
                    {
                        sb.Append(cell.Value);
                        sb.Append(",");
                    }
                }

                sb.AppendLine();
            }

            // Write to file
            File.WriteAllText(filePath, sb.ToString());
        }


        private void CopySelectedCellsToClipboard()
        {
            // Get selected cells in the DataGridView
            DataGridViewSelectedCellCollection selectedCells = dataGridView1.SelectedCells;

            if (selectedCells.Count > 0)
            {
                // Copy selected cells to the clipboard
                StringBuilder sb = new StringBuilder();

                foreach (DataGridViewCell cell in selectedCells)
                {
                    if (cell.ColumnIndex != dataGridView1.Columns["ColumnIcon"].Index)
                    {
                        sb.Append(cell.Value);
                        sb.Append('\t'); // Use tab as delimiter
                    }
                }

                // Remove last tab character
                sb.Remove(sb.Length - 1, 1);
                Clipboard.SetText(sb.ToString());
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopySelectedCellsToClipboard();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                copyTextToolStripMenuItem.Text = dataGridView1.SelectedRows.Count > 1 ? "Copy texts" : "Copy text";
                copyBinaryToolStripMenuItem.Text = dataGridView1.SelectedRows.Count > 1 ? "Copy binaries" : "Copy binary";
                copyRowToolStripMenuItem.Text = dataGridView1.SelectedRows.Count > 1 ? "Copy rows" : "Copy row";
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copySelectedItems("ColumnText");
        }

        private void copyBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copySelectedItems("ColumnBinary");
        }

        private void copySelectedItems(string i_ColumnName)
        {
            StringBuilder copiedString = new StringBuilder();

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                copiedString.AppendLine(row.Cells[dataGridView1.Columns[i_ColumnName].Index].Value.ToString().Replace("\r\n", ""));
            }

            Clipboard.SetText(copiedString.ToString());
        }

        private void copyRowToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StringBuilder copiedString = new StringBuilder();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != dataGridView1.Columns["ColumnIcon"].Index)
                    {
                        copiedString.Append(cell.Value + " ");
                    }
                }

                copiedString.AppendLine();
            }

            Clipboard.SetText(copiedString.ToString());
        }

        private void refresToolStripButton_Click(object sender, EventArgs e)
        {
            if (m_Client.IsConnected)
            {
                m_Client.Close();
                Color myRedColor = Color.FromArgb(255, 228, 226);
                addRowToDataGridView("Disconnected", i_BackColor: myRedColor, i_Icon: global::PipeViewer.Properties.Resources.disconnected);
                isConnectedLabel.Text = "Not Connected";
                isConnectedLabel.ForeColor = Color.Red;
                enableOrDisableChat(false);
                m_Client = new NamedPipeClientStream(".", m_PipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
            }

            m_Client.ConnectAsync();
            addRowToDataGridView("Trying to reconnect...", i_Icon: global::PipeViewer.Properties.Resources.loading);
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Make a new line without sending it
            if (e.Shift && e.KeyCode == Keys.Enter && tabControl1.SelectedTab == TextTab)
            {
                e.Handled = true;
                return;
            }
        }

        private void rawExportToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt file (*.txt)|*.txt";
            saveFileDialog.Title = "Export raw";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                rawExport(saveFileDialog.FileName);
            }
        }

        private void rawExport(string i_FileName)
        {
            StringBuilder rawData = new StringBuilder();
            string iconSymbol = string.Empty;
            string time = string.Empty;
            string[] splitedText = new string[] { };
            string[] splitedBinary = new string[] { };
            string[] splitedRowCounter = new string[] { };
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value is Image icon)
                    {
                        byte[] resourceImageBytesRecieve = imageToByteArray(global::PipeViewer.Properties.Resources.recieve);
                        byte[] dataGridViewImageBytes = imageToByteArray(icon);
                        byte[] resourceImageBytesSend = imageToByteArray(global::PipeViewer.Properties.Resources.send);
                        if (compareByteArrays(resourceImageBytesRecieve, dataGridViewImageBytes))
                        {
                            iconSymbol = "<";
                        }
                        else if (compareByteArrays(resourceImageBytesSend, dataGridViewImageBytes))
                        {
                            iconSymbol = ">";
                        }
                        else
                        {
                            iconSymbol = " ";
                        }
                    }
                    else if (cell.ColumnIndex == dataGridView1.Columns["ColumnText"].Index)
                    {
                        string textValue = cell.Value.ToString().Replace("\r\n", "\n");
                        splitedText = cell.Value.ToString().Split('\n');
                    }
                    else if (cell.ColumnIndex == dataGridView1.Columns["ColumnBinary"].Index)
                    {
                        string binaryValue = cell.Value.ToString().Replace("\r\n", "\n");
                        splitedBinary = cell.Value.ToString().Split('\n');
                    }
                    else if (cell.ColumnIndex == dataGridView1.Columns["ColumnRowNumber"].Index)
                    {
                        string rowCounterValue = cell.Value.ToString().Replace("\r\n", "\n");
                        splitedRowCounter = cell.Value.ToString().Split('\n');
                    }
                    else
                    {
                        time = cell.Value.ToString();
                    }
                }
                rawData.Append(time + "\t");
                rawData.Append(iconSymbol + "\t");
                for (int i = 0; i < splitedBinary.Length; ++i)
                {
                    if (i != 0)
                    {
                        rawData.Append("\t\t\t\t");
                    }
                    rawData.Append(splitedText[i].Replace("\r", "") + "\t");
                    if (splitedText[i].Length < 6)
                    {
                        rawData.Append("\t\t");
                    }
                    else if (splitedText[i].Length < 12)
                    {
                        rawData.Append("\t");
                    }
                    rawData.Append(splitedRowCounter[i].Replace("\r", "") + "\t");
                    rawData.Append(splitedBinary[i].Replace("\r", "") + "\t");
                    rawData.AppendLine();
                }
                rawData.AppendLine();
            }
            File.WriteAllText(i_FileName, rawData.ToString());
        }

        private byte[] imageToByteArray(Image i_Image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                i_Image.Save(memoryStream, ImageFormat.Png); // Adjust the format as needed
                return memoryStream.ToArray();
            }
        }

        // Helper method to compare two byte arrays
        private bool compareByteArrays(byte[] i_Array1, byte[] i_Array2)
        {
            if (i_Array1.Length != i_Array2.Length)
            {
                return false;
            }

            for (int i = 0; i < i_Array1.Length; i++)
            {
                if (i_Array1[i] != i_Array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void ChatHexBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && tabControl1.SelectedTab == BinaryTab)
            {
                sendBinary();
                e.Handled = true;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == TextTab)
            {
                sendText();
            }
            else if(tabControl1.SelectedTab == BinaryTab)
            {
                sendBinary();
            }
        }

        private void sendBinary()
        {
            if (chatHexBox.ByteProvider.Length == 0 || !m_Client.IsConnected)
            {
                return;
            }
            string splitedText = splitStringEvery16Bytes(m_ByteList);
            string binaryText = convertByteArrayAndSplit(m_ByteList.ToArray(), m_ByteList.Count);
            addRowToDataGridView(splitedText, i_BinaryText: binaryText, i_ForeColor: Color.Blue, i_Icon: global::PipeViewer.Properties.Resources.send);
            m_Client.Write(m_ByteList.ToArray(), 0, m_ByteList.Count);
            m_ByteList.Clear();
            chatHexBox.ByteProvider = new DynamicByteProvider(m_ByteList);
        }

        private void PipeChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_Closed = true;
            if (m_Client.IsConnected)
            {
                m_Client.Close();
            }
        }

        private void importStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    m_ByteList = File.ReadAllBytes(filePath).ToList();
                    chatHexBox.ByteProvider = new DynamicByteProvider(m_ByteList);
                    //Display the binary tab.
                    tabControl1.SelectedIndex = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            FormSearch findWindow = new FormSearch();
            findWindow.searchForMatch += new FormSearch.searchEventHandler(FindWindow_searchForMatch);
            findWindow.Show();
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
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;
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
    }
}