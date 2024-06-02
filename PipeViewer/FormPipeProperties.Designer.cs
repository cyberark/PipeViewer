namespace PipeViewer
{
    partial class PipePropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PipePropertiesForm));
            this.propertiesTab = new System.Windows.Forms.TabControl();
            this.GeneralTab = new System.Windows.Forms.TabPage();
            this.GroupBoxBasicInfo = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblGrantedAccess = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblObjectAddress = new System.Windows.Forms.Label();
            this.SecurityTab = new System.Windows.Forms.TabPage();
            this.groupBoxPermissions = new System.Windows.Forms.GroupBox();
            this.checkBoxDenyExecute = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowedExecute = new System.Windows.Forms.CheckBox();
            this.lblExecute = new System.Windows.Forms.Label();
            this.checkBoxDenySpecial = new System.Windows.Forms.CheckBox();
            this.checkBoxDenyWrite = new System.Windows.Forms.CheckBox();
            this.checkBoxDenyRead = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowedSpecial = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowedWrite = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowedRead = new System.Windows.Forms.CheckBox();
            this.checkBoxDenyFull = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowedFull = new System.Windows.Forms.CheckBox();
            this.lblSpecial = new System.Windows.Forms.Label();
            this.lblDeny = new System.Windows.Forms.Label();
            this.lblAllow = new System.Windows.Forms.Label();
            this.lblWrite = new System.Windows.Forms.Label();
            this.lblRead = new System.Windows.Forms.Label();
            this.lblFullControl = new System.Windows.Forms.Label();
            this.listViewPermissions = new System.Windows.Forms.ListView();
            this.lblName2 = new System.Windows.Forms.Label();
            this.groupBoxSecurity = new System.Windows.Forms.GroupBox();
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.propertiesTab.SuspendLayout();
            this.GeneralTab.SuspendLayout();
            this.GroupBoxBasicInfo.SuspendLayout();
            this.SecurityTab.SuspendLayout();
            this.groupBoxPermissions.SuspendLayout();
            this.groupBoxSecurity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // propertiesTab
            // 
            this.propertiesTab.Controls.Add(this.GeneralTab);
            this.propertiesTab.Controls.Add(this.SecurityTab);
            this.propertiesTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertiesTab.Location = new System.Drawing.Point(12, 12);
            this.propertiesTab.Name = "propertiesTab";
            this.propertiesTab.SelectedIndex = 0;
            this.propertiesTab.Size = new System.Drawing.Size(715, 588);
            this.propertiesTab.TabIndex = 0;
            // 
            // GeneralTab
            // 
            this.GeneralTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GeneralTab.Controls.Add(this.GroupBoxBasicInfo);
            this.GeneralTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralTab.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GeneralTab.Location = new System.Drawing.Point(4, 31);
            this.GeneralTab.Name = "GeneralTab";
            this.GeneralTab.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTab.Size = new System.Drawing.Size(707, 553);
            this.GeneralTab.TabIndex = 0;
            this.GeneralTab.Text = "General";
            // 
            // GroupBoxBasicInfo
            // 
            this.GroupBoxBasicInfo.Controls.Add(this.lblName);
            this.GroupBoxBasicInfo.Controls.Add(this.lblGrantedAccess);
            this.GroupBoxBasicInfo.Controls.Add(this.lblType);
            this.GroupBoxBasicInfo.Controls.Add(this.lblObjectAddress);
            this.GroupBoxBasicInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBoxBasicInfo.Location = new System.Drawing.Point(6, 6);
            this.GroupBoxBasicInfo.Name = "GroupBoxBasicInfo";
            this.GroupBoxBasicInfo.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBoxBasicInfo.Size = new System.Drawing.Size(695, 285);
            this.GroupBoxBasicInfo.TabIndex = 4;
            this.GroupBoxBasicInfo.TabStop = false;
            this.GroupBoxBasicInfo.Text = "Basic Information";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 48);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(58, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // lblGrantedAccess
            // 
            this.lblGrantedAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrantedAccess.AutoSize = true;
            this.lblGrantedAccess.Location = new System.Drawing.Point(23, 216);
            this.lblGrantedAccess.Name = "lblGrantedAccess";
            this.lblGrantedAccess.Size = new System.Drawing.Size(135, 20);
            this.lblGrantedAccess.TabIndex = 3;
            this.lblGrantedAccess.Text = "Granted Access:";
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(23, 102);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(50, 20);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type:";
            // 
            // lblObjectAddress
            // 
            this.lblObjectAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblObjectAddress.AutoSize = true;
            this.lblObjectAddress.Location = new System.Drawing.Point(23, 157);
            this.lblObjectAddress.Margin = new System.Windows.Forms.Padding(2);
            this.lblObjectAddress.Name = "lblObjectAddress";
            this.lblObjectAddress.Size = new System.Drawing.Size(130, 20);
            this.lblObjectAddress.TabIndex = 2;
            this.lblObjectAddress.Text = "Object Address:";
            // 
            // SecurityTab
            // 
            this.SecurityTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SecurityTab.Controls.Add(this.groupBoxPermissions);
            this.SecurityTab.Controls.Add(this.lblName2);
            this.SecurityTab.Controls.Add(this.groupBoxSecurity);
            this.SecurityTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecurityTab.Location = new System.Drawing.Point(4, 31);
            this.SecurityTab.Name = "SecurityTab";
            this.SecurityTab.Padding = new System.Windows.Forms.Padding(3);
            this.SecurityTab.Size = new System.Drawing.Size(707, 553);
            this.SecurityTab.TabIndex = 1;
            this.SecurityTab.Text = "Security";
            // 
            // groupBoxPermissions
            // 
            this.groupBoxPermissions.Controls.Add(this.checkBoxDenyExecute);
            this.groupBoxPermissions.Controls.Add(this.checkBoxAllowedExecute);
            this.groupBoxPermissions.Controls.Add(this.lblExecute);
            this.groupBoxPermissions.Controls.Add(this.checkBoxDenySpecial);
            this.groupBoxPermissions.Controls.Add(this.checkBoxDenyWrite);
            this.groupBoxPermissions.Controls.Add(this.checkBoxDenyRead);
            this.groupBoxPermissions.Controls.Add(this.checkBoxAllowedSpecial);
            this.groupBoxPermissions.Controls.Add(this.checkBoxAllowedWrite);
            this.groupBoxPermissions.Controls.Add(this.checkBoxAllowedRead);
            this.groupBoxPermissions.Controls.Add(this.checkBoxDenyFull);
            this.groupBoxPermissions.Controls.Add(this.checkBoxAllowedFull);
            this.groupBoxPermissions.Controls.Add(this.lblSpecial);
            this.groupBoxPermissions.Controls.Add(this.lblDeny);
            this.groupBoxPermissions.Controls.Add(this.lblAllow);
            this.groupBoxPermissions.Controls.Add(this.lblWrite);
            this.groupBoxPermissions.Controls.Add(this.lblRead);
            this.groupBoxPermissions.Controls.Add(this.lblFullControl);
            this.groupBoxPermissions.Controls.Add(this.listViewPermissions);
            this.groupBoxPermissions.Location = new System.Drawing.Point(42, 235);
            this.groupBoxPermissions.Name = "groupBoxPermissions";
            this.groupBoxPermissions.Size = new System.Drawing.Size(616, 276);
            this.groupBoxPermissions.TabIndex = 3;
            this.groupBoxPermissions.TabStop = false;
            this.groupBoxPermissions.Text = "Permissions";
            // 
            // checkBoxDenyExecute
            // 
            this.checkBoxDenyExecute.AutoSize = true;
            this.checkBoxDenyExecute.Enabled = false;
            this.checkBoxDenyExecute.Location = new System.Drawing.Point(451, 98);
            this.checkBoxDenyExecute.Name = "checkBoxDenyExecute";
            this.checkBoxDenyExecute.Size = new System.Drawing.Size(18, 17);
            this.checkBoxDenyExecute.TabIndex = 17;
            this.checkBoxDenyExecute.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowedExecute
            // 
            this.checkBoxAllowedExecute.AutoSize = true;
            this.checkBoxAllowedExecute.Enabled = false;
            this.checkBoxAllowedExecute.Location = new System.Drawing.Point(307, 98);
            this.checkBoxAllowedExecute.Name = "checkBoxAllowedExecute";
            this.checkBoxAllowedExecute.Size = new System.Drawing.Size(18, 17);
            this.checkBoxAllowedExecute.TabIndex = 16;
            this.checkBoxAllowedExecute.UseVisualStyleBackColor = true;
            // 
            // lblExecute
            // 
            this.lblExecute.AutoSize = true;
            this.lblExecute.BackColor = System.Drawing.Color.White;
            this.lblExecute.Location = new System.Drawing.Point(48, 96);
            this.lblExecute.Name = "lblExecute";
            this.lblExecute.Size = new System.Drawing.Size(127, 20);
            this.lblExecute.TabIndex = 15;
            this.lblExecute.Text = "Read n Execute";
            // 
            // checkBoxDenySpecial
            // 
            this.checkBoxDenySpecial.AutoSize = true;
            this.checkBoxDenySpecial.Enabled = false;
            this.checkBoxDenySpecial.Location = new System.Drawing.Point(451, 200);
            this.checkBoxDenySpecial.Name = "checkBoxDenySpecial";
            this.checkBoxDenySpecial.Size = new System.Drawing.Size(18, 17);
            this.checkBoxDenySpecial.TabIndex = 14;
            this.checkBoxDenySpecial.UseVisualStyleBackColor = true;
            // 
            // checkBoxDenyWrite
            // 
            this.checkBoxDenyWrite.AutoSize = true;
            this.checkBoxDenyWrite.Enabled = false;
            this.checkBoxDenyWrite.Location = new System.Drawing.Point(451, 166);
            this.checkBoxDenyWrite.Name = "checkBoxDenyWrite";
            this.checkBoxDenyWrite.Size = new System.Drawing.Size(18, 17);
            this.checkBoxDenyWrite.TabIndex = 13;
            this.checkBoxDenyWrite.UseVisualStyleBackColor = true;
            // 
            // checkBoxDenyRead
            // 
            this.checkBoxDenyRead.AutoSize = true;
            this.checkBoxDenyRead.Enabled = false;
            this.checkBoxDenyRead.Location = new System.Drawing.Point(451, 133);
            this.checkBoxDenyRead.Name = "checkBoxDenyRead";
            this.checkBoxDenyRead.Size = new System.Drawing.Size(18, 17);
            this.checkBoxDenyRead.TabIndex = 12;
            this.checkBoxDenyRead.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowedSpecial
            // 
            this.checkBoxAllowedSpecial.AutoSize = true;
            this.checkBoxAllowedSpecial.Enabled = false;
            this.checkBoxAllowedSpecial.Location = new System.Drawing.Point(307, 200);
            this.checkBoxAllowedSpecial.Name = "checkBoxAllowedSpecial";
            this.checkBoxAllowedSpecial.Size = new System.Drawing.Size(18, 17);
            this.checkBoxAllowedSpecial.TabIndex = 11;
            this.checkBoxAllowedSpecial.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowedWrite
            // 
            this.checkBoxAllowedWrite.AutoSize = true;
            this.checkBoxAllowedWrite.Enabled = false;
            this.checkBoxAllowedWrite.Location = new System.Drawing.Point(307, 166);
            this.checkBoxAllowedWrite.Name = "checkBoxAllowedWrite";
            this.checkBoxAllowedWrite.Size = new System.Drawing.Size(18, 17);
            this.checkBoxAllowedWrite.TabIndex = 10;
            this.checkBoxAllowedWrite.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowedRead
            // 
            this.checkBoxAllowedRead.AutoSize = true;
            this.checkBoxAllowedRead.Enabled = false;
            this.checkBoxAllowedRead.Location = new System.Drawing.Point(307, 133);
            this.checkBoxAllowedRead.Name = "checkBoxAllowedRead";
            this.checkBoxAllowedRead.Size = new System.Drawing.Size(18, 17);
            this.checkBoxAllowedRead.TabIndex = 9;
            this.checkBoxAllowedRead.UseVisualStyleBackColor = true;
            // 
            // checkBoxDenyFull
            // 
            this.checkBoxDenyFull.AutoSize = true;
            this.checkBoxDenyFull.Enabled = false;
            this.checkBoxDenyFull.Location = new System.Drawing.Point(451, 64);
            this.checkBoxDenyFull.Name = "checkBoxDenyFull";
            this.checkBoxDenyFull.Size = new System.Drawing.Size(18, 17);
            this.checkBoxDenyFull.TabIndex = 8;
            this.checkBoxDenyFull.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowedFull
            // 
            this.checkBoxAllowedFull.AutoSize = true;
            this.checkBoxAllowedFull.Enabled = false;
            this.checkBoxAllowedFull.Location = new System.Drawing.Point(307, 64);
            this.checkBoxAllowedFull.Name = "checkBoxAllowedFull";
            this.checkBoxAllowedFull.Size = new System.Drawing.Size(18, 17);
            this.checkBoxAllowedFull.TabIndex = 7;
            this.checkBoxAllowedFull.UseVisualStyleBackColor = true;
            // 
            // lblSpecial
            // 
            this.lblSpecial.AutoSize = true;
            this.lblSpecial.BackColor = System.Drawing.Color.White;
            this.lblSpecial.Location = new System.Drawing.Point(49, 198);
            this.lblSpecial.Name = "lblSpecial";
            this.lblSpecial.Size = new System.Drawing.Size(162, 20);
            this.lblSpecial.TabIndex = 6;
            this.lblSpecial.Text = "Special Permissions";
            // 
            // lblDeny
            // 
            this.lblDeny.AutoSize = true;
            this.lblDeny.Location = new System.Drawing.Point(434, 23);
            this.lblDeny.Name = "lblDeny";
            this.lblDeny.Size = new System.Drawing.Size(48, 20);
            this.lblDeny.TabIndex = 5;
            this.lblDeny.Text = "Deny";
            // 
            // lblAllow
            // 
            this.lblAllow.AutoSize = true;
            this.lblAllow.Location = new System.Drawing.Point(294, 23);
            this.lblAllow.Name = "lblAllow";
            this.lblAllow.Size = new System.Drawing.Size(49, 20);
            this.lblAllow.TabIndex = 4;
            this.lblAllow.Text = "Allow";
            // 
            // lblWrite
            // 
            this.lblWrite.AutoSize = true;
            this.lblWrite.BackColor = System.Drawing.Color.White;
            this.lblWrite.Location = new System.Drawing.Point(49, 164);
            this.lblWrite.Name = "lblWrite";
            this.lblWrite.Size = new System.Drawing.Size(49, 20);
            this.lblWrite.TabIndex = 3;
            this.lblWrite.Text = "Write";
            // 
            // lblRead
            // 
            this.lblRead.AutoSize = true;
            this.lblRead.BackColor = System.Drawing.Color.White;
            this.lblRead.Location = new System.Drawing.Point(49, 131);
            this.lblRead.Name = "lblRead";
            this.lblRead.Size = new System.Drawing.Size(48, 20);
            this.lblRead.TabIndex = 2;
            this.lblRead.Text = "Read";
            // 
            // lblFullControl
            // 
            this.lblFullControl.AutoSize = true;
            this.lblFullControl.BackColor = System.Drawing.Color.White;
            this.lblFullControl.Location = new System.Drawing.Point(49, 62);
            this.lblFullControl.Name = "lblFullControl";
            this.lblFullControl.Size = new System.Drawing.Size(95, 20);
            this.lblFullControl.TabIndex = 1;
            this.lblFullControl.Text = "Full Control";
            // 
            // listViewPermissions
            // 
            this.listViewPermissions.HideSelection = false;
            this.listViewPermissions.Location = new System.Drawing.Point(22, 46);
            this.listViewPermissions.Name = "listViewPermissions";
            this.listViewPermissions.Size = new System.Drawing.Size(582, 202);
            this.listViewPermissions.TabIndex = 0;
            this.listViewPermissions.UseCompatibleStateImageBehavior = false;
            this.listViewPermissions.View = System.Windows.Forms.View.List;
            // 
            // lblName2
            // 
            this.lblName2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName2.AutoSize = true;
            this.lblName2.Location = new System.Drawing.Point(21, 16);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(73, 20);
            this.lblName2.TabIndex = 1;
            this.lblName2.Text = "Name:   ";
            // 
            // groupBoxSecurity
            // 
            this.groupBoxSecurity.Controls.Add(this.listViewUsers);
            this.groupBoxSecurity.Location = new System.Drawing.Point(42, 50);
            this.groupBoxSecurity.Name = "groupBoxSecurity";
            this.groupBoxSecurity.Size = new System.Drawing.Size(616, 179);
            this.groupBoxSecurity.TabIndex = 2;
            this.groupBoxSecurity.TabStop = false;
            this.groupBoxSecurity.Text = " Group or User Names:";
            // 
            // listViewUsers
            // 
            this.listViewUsers.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listViewUsers.AllowColumnReorder = true;
            this.listViewUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.HideSelection = false;
            this.listViewUsers.Location = new System.Drawing.Point(22, 40);
            this.listViewUsers.MultiSelect = false;
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(582, 122);
            this.listViewUsers.TabIndex = 1;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.List;
            // 
            // PipePropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 612);
            this.Controls.Add(this.propertiesTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PipePropertiesForm";
            this.Text = "Properties";
            this.Load += new System.EventHandler(this.PipeProperties_Load);
            this.propertiesTab.ResumeLayout(false);
            this.GeneralTab.ResumeLayout(false);
            this.GroupBoxBasicInfo.ResumeLayout(false);
            this.GroupBoxBasicInfo.PerformLayout();
            this.SecurityTab.ResumeLayout(false);
            this.SecurityTab.PerformLayout();
            this.groupBoxPermissions.ResumeLayout(false);
            this.groupBoxPermissions.PerformLayout();
            this.groupBoxSecurity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl propertiesTab;
        private System.Windows.Forms.TabPage GeneralTab;
        private System.Windows.Forms.TabPage SecurityTab;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblObjectAddress;
        private System.Windows.Forms.Label lblGrantedAccess;
        private System.Windows.Forms.GroupBox GroupBoxBasicInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.GroupBox groupBoxPermissions;
        private System.Windows.Forms.ListView listViewPermissions;
        private System.Windows.Forms.GroupBox groupBoxSecurity;
        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.Label lblFullControl;
        private System.Windows.Forms.Label lblWrite;
        private System.Windows.Forms.Label lblRead;
        private System.Windows.Forms.Label lblDeny;
        private System.Windows.Forms.Label lblAllow;
        private System.Windows.Forms.Label lblSpecial;
        private System.Windows.Forms.CheckBox checkBoxDenyFull;
        private System.Windows.Forms.CheckBox checkBoxAllowedFull;
        private System.Windows.Forms.CheckBox checkBoxAllowedRead;
        private System.Windows.Forms.CheckBox checkBoxAllowedSpecial;
        private System.Windows.Forms.CheckBox checkBoxAllowedWrite;
        private System.Windows.Forms.CheckBox checkBoxDenySpecial;
        private System.Windows.Forms.CheckBox checkBoxDenyWrite;
        private System.Windows.Forms.CheckBox checkBoxDenyRead;
        private System.Windows.Forms.Label lblExecute;
        private System.Windows.Forms.CheckBox checkBoxAllowedExecute;
        private System.Windows.Forms.CheckBox checkBoxDenyExecute;
    }
}