using System;

namespace PipeViewer
{
    partial class PipeChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PipeChatForm));
            this.process1 = new System.Diagnostics.Process();
            this.isConnectedLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBinary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.refresToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.exportToCsvButton = new System.Windows.Forms.ToolStripButton();
            this.rawExportToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.importStripButton = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TextTab = new System.Windows.Forms.TabPage();
            this.textBox = new System.Windows.Forms.TextBox();
            this.BinaryTab = new System.Windows.Forms.TabPage();
            this.chatHexBox = new Be.Windows.Forms.HexBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.sendButton = new System.Windows.Forms.Button();
            this.findButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TextTab.SuspendLayout();
            this.BinaryTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // isConnectedLabel
            // 
            this.isConnectedLabel.AutoSize = true;
            this.isConnectedLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.isConnectedLabel.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isConnectedLabel.ForeColor = System.Drawing.Color.Red;
            this.isConnectedLabel.Location = new System.Drawing.Point(0, 461);
            this.isConnectedLabel.Margin = new System.Windows.Forms.Padding(0);
            this.isConnectedLabel.Name = "isConnectedLabel";
            this.isConnectedLabel.Padding = new System.Windows.Forms.Padding(11);
            this.isConnectedLabel.Size = new System.Drawing.Size(124, 38);
            this.isConnectedLabel.TabIndex = 3;
            this.isConnectedLabel.Text = "Not Connected";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTime,
            this.ColumnIcon,
            this.ColumnText,
            this.ColumnRowNumber,
            this.ColumnBinary});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(926, 282);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // ColumnTime
            // 
            this.ColumnTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnTime.HeaderText = "Time";
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            this.ColumnTime.Width = 68;
            // 
            // ColumnIcon
            // 
            this.ColumnIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnIcon.HeaderText = "";
            this.ColumnIcon.Name = "ColumnIcon";
            this.ColumnIcon.ReadOnly = true;
            this.ColumnIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIcon.Width = 19;
            // 
            // ColumnText
            // 
            this.ColumnText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnText.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnText.HeaderText = "Text";
            this.ColumnText.Name = "ColumnText";
            this.ColumnText.ReadOnly = true;
            this.ColumnText.Width = 64;
            // 
            // ColumnRowNumber
            // 
            this.ColumnRowNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnRowNumber.HeaderText = "Byte";
            this.ColumnRowNumber.Name = "ColumnRowNumber";
            this.ColumnRowNumber.ReadOnly = true;
            this.ColumnRowNumber.Width = 65;
            // 
            // ColumnBinary
            // 
            this.ColumnBinary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnBinary.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnBinary.HeaderText = "Binary";
            this.ColumnBinary.Name = "ColumnBinary";
            this.ColumnBinary.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refresToolStripButton,
            this.exportToCsvButton,
            this.rawExportToolStripButton,
            this.importStripButton,
            this.findButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(926, 27);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // refresToolStripButton
            // 
            this.refresToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refresToolStripButton.Image = global::PipeViewer.Properties.Resources.refresh;
            this.refresToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refresToolStripButton.Name = "refresToolStripButton";
            this.refresToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.refresToolStripButton.Text = "Reconnect";
            this.refresToolStripButton.Click += new System.EventHandler(this.refresToolStripButton_Click);
            // 
            // exportToCsvButton
            // 
            this.exportToCsvButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportToCsvButton.Image = global::PipeViewer.Properties.Resources.csv_export;
            this.exportToCsvButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportToCsvButton.Name = "exportToCsvButton";
            this.exportToCsvButton.Size = new System.Drawing.Size(24, 24);
            this.exportToCsvButton.Text = "Expot To CSV";
            this.exportToCsvButton.Click += new System.EventHandler(this.exportToCsvButton_Click);
            // 
            // rawExportToolStripButton
            // 
            this.rawExportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rawExportToolStripButton.Image = global::PipeViewer.Properties.Resources.export;
            this.rawExportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rawExportToolStripButton.Name = "rawExportToolStripButton";
            this.rawExportToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.rawExportToolStripButton.Text = "Raw export";
            this.rawExportToolStripButton.Click += new System.EventHandler(this.rawExportToolStripButton_Click);
            // 
            // importStripButton
            // 
            this.importStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importStripButton.Image = global::PipeViewer.Properties.Resources.import;
            this.importStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importStripButton.Name = "importStripButton";
            this.importStripButton.Size = new System.Drawing.Size(24, 24);
            this.importStripButton.Text = "Import from file";
            this.importStripButton.Click += new System.EventHandler(this.importStripButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyTextToolStripMenuItem,
            this.copyBinaryToolStripMenuItem,
            this.copyRowToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 70);
            // 
            // copyTextToolStripMenuItem
            // 
            this.copyTextToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.copyTextToolStripMenuItem.Name = "copyTextToolStripMenuItem";
            this.copyTextToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.copyTextToolStripMenuItem.Text = "Copy Text";
            this.copyTextToolStripMenuItem.Click += new System.EventHandler(this.copyTextToolStripMenuItem_Click);
            // 
            // copyBinaryToolStripMenuItem
            // 
            this.copyBinaryToolStripMenuItem.Name = "copyBinaryToolStripMenuItem";
            this.copyBinaryToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.copyBinaryToolStripMenuItem.Text = "Copy Binary";
            this.copyBinaryToolStripMenuItem.Click += new System.EventHandler(this.copyBinaryToolStripMenuItem_Click);
            // 
            // copyRowToolStripMenuItem
            // 
            this.copyRowToolStripMenuItem.Name = "copyRowToolStripMenuItem";
            this.copyRowToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.copyRowToolStripMenuItem.Text = "Copy row";
            this.copyRowToolStripMenuItem.Click += new System.EventHandler(this.copyRowToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TextTab);
            this.tabControl1.Controls.Add(this.BinaryTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 309);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(926, 152);
            this.tabControl1.TabIndex = 6;
            // 
            // TextTab
            // 
            this.TextTab.Controls.Add(this.textBox);
            this.TextTab.Location = new System.Drawing.Point(4, 22);
            this.TextTab.Name = "TextTab";
            this.TextTab.Padding = new System.Windows.Forms.Padding(3);
            this.TextTab.Size = new System.Drawing.Size(918, 126);
            this.TextTab.TabIndex = 0;
            this.TextTab.Text = "Text";
            this.TextTab.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Enabled = false;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(3, 3);
            this.textBox.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(912, 120);
            this.textBox.TabIndex = 2;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // BinaryTab
            // 
            this.BinaryTab.Controls.Add(this.chatHexBox);
            this.BinaryTab.Location = new System.Drawing.Point(4, 22);
            this.BinaryTab.Name = "BinaryTab";
            this.BinaryTab.Padding = new System.Windows.Forms.Padding(3);
            this.BinaryTab.Size = new System.Drawing.Size(918, 126);
            this.BinaryTab.TabIndex = 1;
            this.BinaryTab.Text = "Binary";
            this.BinaryTab.UseVisualStyleBackColor = true;
            // 
            // chatHexBox
            // 
            this.chatHexBox.ColumnInfoVisible = true;
            this.chatHexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatHexBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatHexBox.LineInfoVisible = true;
            this.chatHexBox.Location = new System.Drawing.Point(3, 3);
            this.chatHexBox.Name = "chatHexBox";
            this.chatHexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.chatHexBox.Size = new System.Drawing.Size(912, 120);
            this.chatHexBox.StringViewVisible = true;
            this.chatHexBox.TabIndex = 0;
            this.chatHexBox.UseFixedBytesPerLine = true;
            this.chatHexBox.VScrollBarVisible = true;
            this.chatHexBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChatHexBox_KeyPress);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendButton.BackColor = System.Drawing.SystemColors.Control;
            this.sendButton.BackgroundImage = global::PipeViewer.Properties.Resources.send__button_icon_small;
            this.sendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sendButton.Enabled = false;
            this.sendButton.FlatAppearance.BorderSize = 0;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Location = new System.Drawing.Point(885, 463);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(29, 29);
            this.sendButton.TabIndex = 7;
            this.sendButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // findButton
            // 
            this.findButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.findButton.Image = global::PipeViewer.Properties.Resources.find;
            this.findButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(24, 24);
            this.findButton.Text = "Search";
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // PipeChatForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(926, 499);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.isConnectedLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(922, 526);
            this.Name = "PipeChatForm";
            this.Text = "PipeChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PipeChat_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TextTab.ResumeLayout(false);
            this.TextTab.PerformLayout();
            this.BinaryTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.Label isConnectedLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton exportToCsvButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton refresToolStripButton;
        private System.Windows.Forms.ToolStripButton rawExportToolStripButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TextTab;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TabPage BinaryTab;
        private Be.Windows.Forms.HexBox chatHexBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewImageColumn ColumnIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBinary;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ToolStripButton importStripButton;
        private System.Windows.Forms.ToolStripButton findButton;
    }
}