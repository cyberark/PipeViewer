namespace PipeViewer
{
    partial class PipeChat
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.process1 = new System.Diagnostics.Process();
            this.chatListView = new System.Windows.Forms.ListView();
            this.isConnectedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox.Enabled = false;
            this.textBox.Location = new System.Drawing.Point(0, 377);
            this.textBox.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(800, 73);
            this.textBox.TabIndex = 1;
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
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
            // chatListView
            // 
            this.chatListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.chatListView.AutoArrange = false;
            this.chatListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.chatListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatListView.GridLines = true;
            this.chatListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.chatListView.HideSelection = false;
            this.chatListView.HoverSelection = true;
            this.chatListView.LabelEdit = true;
            this.chatListView.LabelWrap = false;
            this.chatListView.Location = new System.Drawing.Point(0, 0);
            this.chatListView.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.chatListView.MultiSelect = false;
            this.chatListView.Name = "chatListView";
            this.chatListView.Size = new System.Drawing.Size(800, 326);
            this.chatListView.TabIndex = 2;
            this.chatListView.UseCompatibleStateImageBehavior = false;
            this.chatListView.View = System.Windows.Forms.View.Details;
            // 
            // isConnectedLabel
            // 
            this.isConnectedLabel.AutoSize = true;
            this.isConnectedLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.isConnectedLabel.ForeColor = System.Drawing.Color.Red;
            this.isConnectedLabel.Location = new System.Drawing.Point(0, 332);
            this.isConnectedLabel.Margin = new System.Windows.Forms.Padding(4);
            this.isConnectedLabel.Name = "isConnectedLabel";
            this.isConnectedLabel.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.isConnectedLabel.Size = new System.Drawing.Size(109, 45);
            this.isConnectedLabel.TabIndex = 3;
            this.isConnectedLabel.Text = "Not Connected";
            // 
            // PipeChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chatListView);
            this.Controls.Add(this.isConnectedLabel);
            this.Controls.Add(this.textBox);
            this.Name = "PipeChat";
            this.Text = "PipeChat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PipeChat_FormClosed);
            this.SizeChanged += new System.EventHandler(this.PipeChat_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.ListView chatListView;
        private System.Windows.Forms.Label isConnectedLabel;
    }
}