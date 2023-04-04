using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipeViewer
{
    public partial class PipeChat : Form
    {
        private delegate void startClientDelgation();
        private string m_PipeName;
        private NamedPipeClientStream m_Client;
        public PipeChat(string i_PipeName)
        {
            m_PipeName = i_PipeName.Replace(@"\\.\pipe\", "");
            InitializeComponent();
            chatListView.HeaderStyle = ColumnHeaderStyle.None;
            chatListView.Columns.Add("Time");
            chatListView.Columns[0].Width = -2;
            chatListView.Columns.Add("Chatting with pipe " + "\"" + m_PipeName + "\"");
            chatListView.Columns[1].Width = -2;
            chatListView.HeaderStyle = ColumnHeaderStyle.None;
            chatListView.BorderStyle = BorderStyle.FixedSingle;
            chatListView.Dock = DockStyle.Fill;
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
                string[] row = new string[2];
                row[0] = DateTime.Now.ToString("HH:mm:ss:fff");
                row[1] = "Trying to connect...";
                var listViewItemRow = new ListViewItem(row);
                listViewItemRow.BackColor = Color.LightGray;
                listViewItemRow.ForeColor = Color.LightSeaGreen;
                chatListView.Items.Add(listViewItemRow);
                m_Client.ConnectAsync();
                Task task = Task.Run(() =>
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    string dataFromPipe;
                    while (true)
                    {

                        if (!m_Client.IsConnected)
                        {
                            if (isConnectedLabel.Text == "Connected")
                            {
                                uiContext.Post(new SendOrPostCallback((_) =>
                                {
                                    row[0] = DateTime.Now.ToString("HH:mm:ss:fff");
                                    row[1] = "Disconnected";
                                    listViewItemRow = new ListViewItem(row);
                                    listViewItemRow.SubItems[1].ForeColor = Color.LightGray;
                                    listViewItemRow.ForeColor = Color.Red;
                                    chatListView.Items.Add(listViewItemRow);
                                    isConnectedLabel.Text = "Not Connected";
                                    isConnectedLabel.ForeColor = Color.Red;
                                    textBox.Enabled = false;
                                }), null);
                            }
                            continue;
                        }
                        if (isConnectedLabel.Text != "Connected")
                        {
                            uiContext.Post(new SendOrPostCallback((_) =>
                            {
                                row[0] = DateTime.Now.ToString("HH:mm:ss:fff");
                                row[1] = "Connected";
                                listViewItemRow = new ListViewItem(row);
                                listViewItemRow.SubItems[1].BackColor = Color.LightGray;
                                listViewItemRow.SubItems[0].ForeColor = Color.LightSeaGreen;
                                listViewItemRow.SubItems[0].ForeColor = Color.Gray;
                                chatListView.Items.Add(listViewItemRow);
                                chatListView.Items[0].SubItems[0].ForeColor = Color.HotPink;

                                isConnectedLabel.Text = "Connected";
                                isConnectedLabel.ForeColor = Color.Green;
                                textBox.Enabled = true;
                            }), null);
                        }

                        bytesRead = m_Client.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            continue;
                        }

                        dataFromPipe = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        uiContext.Post(new SendOrPostCallback((_) =>
                        {
                            //row = "[" + DateTime.Now.ToString("HH:mm:ss") + "]: ";
                            //row += dataFromPipe + "     ";
                            //for (int i = 0; i < bytesRead; ++i)
                            //{
                            //    row += buffer[i].ToString("X2") + " ";
                            //}
                            //row += "\n";
                            //listViewItemRow = new ListViewItem(row);
                            //chatListView.Items.Add(listViewItemRow);
                        }), null);
                    }
                });
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (textBox.Text == "" || !m_Client.IsConnected)
                {
                    return;
                }
                byte[] buffer = Encoding.ASCII.GetBytes(textBox.Text);
                var listViewItemRow = new ListViewItem("[" + DateTime.Now.ToString("HH:mm:ss") + "]: " + textBox.Text);
                listViewItemRow.ForeColor = Color.Green;
                chatListView.Items.Add(listViewItemRow);
                m_Client.Write(buffer, 0, textBox.Text.Length);
                textBox.Text = "";
            }
        }

        private void PipeChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_Client.Close();
        }

        private void chatTextBox_TextChanged(object sender, EventArgs e)
        {
            chatListView.Items[chatListView.Items.Count - 1].EnsureVisible();
        }

        private void PipeChat_SizeChanged(object sender, EventArgs e)
        {
            if (chatListView.Columns.Count > 0)
            {
                chatListView.Columns[0].Width = -2;
                chatListView.Columns[1].Width = -2;

            }

        }
    }
}