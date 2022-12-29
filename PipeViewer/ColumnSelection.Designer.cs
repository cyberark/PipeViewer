namespace PipeViewer
{
    partial class ColumnSelection
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
            this.groupBoxNamedPipe = new System.Windows.Forms.GroupBox();
            this.checkBoxReadMode = new System.Windows.Forms.CheckBox();
            this.checkBoxNumberOfLinks = new System.Windows.Forms.CheckBox();
            this.checkBoxPipeType = new System.Windows.Forms.CheckBox();
            this.checkBoxConfiguration = new System.Windows.Forms.CheckBox();
            this.checkBoxClientProcessId = new System.Windows.Forms.CheckBox();
            this.checkBoxEndpointType = new System.Windows.Forms.CheckBox();
            this.checkBoxSddl = new System.Windows.Forms.CheckBox();
            this.checkBoxName = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxTimeStamp = new System.Windows.Forms.GroupBox();
            this.checkBoxCreationTime = new System.Windows.Forms.CheckBox();
            this.checkBoxChangeTime = new System.Windows.Forms.CheckBox();
            this.checkBoxLastWriteTime = new System.Windows.Forms.CheckBox();
            this.checkBoxLastAccessTime = new System.Windows.Forms.CheckBox();
            this.checkBoxFileCreationTime = new System.Windows.Forms.CheckBox();
            this.checkBoxIntegrityLevel = new System.Windows.Forms.CheckBox();
            this.checkBoxPermissions = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxSecurityDescriptor = new System.Windows.Forms.GroupBox();
            this.checkBoxGroupSid = new System.Windows.Forms.CheckBox();
            this.checkBoxOwnerSid = new System.Windows.Forms.CheckBox();
            this.checkBoxOwnerName = new System.Windows.Forms.CheckBox();
            this.checkBoxGroupName = new System.Windows.Forms.CheckBox();
            this.checkBoxDirectoryGrantedAccess = new System.Windows.Forms.CheckBox();
            this.groupBoxAccess = new System.Windows.Forms.GroupBox();
            this.checkBoxGrantedAccess = new System.Windows.Forms.CheckBox();
            this.checkBoxGrantedAccessGeneric = new System.Windows.Forms.CheckBox();
            this.checkBoxHandle = new System.Windows.Forms.CheckBox();
            this.groupBoxNamedPipe.SuspendLayout();
            this.groupBoxTimeStamp.SuspendLayout();
            this.groupBoxSecurityDescriptor.SuspendLayout();
            this.groupBoxAccess.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxNamedPipe
            // 
            this.groupBoxNamedPipe.Controls.Add(this.checkBoxHandle);
            this.groupBoxNamedPipe.Controls.Add(this.checkBoxReadMode);
            this.groupBoxNamedPipe.Controls.Add(this.checkBoxNumberOfLinks);
            this.groupBoxNamedPipe.Controls.Add(this.checkBoxPipeType);
            this.groupBoxNamedPipe.Controls.Add(this.checkBoxConfiguration);
            this.groupBoxNamedPipe.Controls.Add(this.checkBoxClientProcessId);
            this.groupBoxNamedPipe.Controls.Add(this.checkBoxEndpointType);
            this.groupBoxNamedPipe.Controls.Add(this.checkBoxSddl);
            this.groupBoxNamedPipe.Controls.Add(this.checkBoxName);
            this.groupBoxNamedPipe.Location = new System.Drawing.Point(12, 47);
            this.groupBoxNamedPipe.Name = "groupBoxNamedPipe";
            this.groupBoxNamedPipe.Size = new System.Drawing.Size(272, 145);
            this.groupBoxNamedPipe.TabIndex = 0;
            this.groupBoxNamedPipe.TabStop = false;
            this.groupBoxNamedPipe.Text = "Named Pipe";
            // 
            // checkBoxReadMode
            // 
            this.checkBoxReadMode.AutoSize = true;
            this.checkBoxReadMode.Checked = true;
            this.checkBoxReadMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReadMode.Location = new System.Drawing.Point(6, 99);
            this.checkBoxReadMode.Name = "checkBoxReadMode";
            this.checkBoxReadMode.Size = new System.Drawing.Size(82, 17);
            this.checkBoxReadMode.TabIndex = 7;
            this.checkBoxReadMode.Text = "Read Mode";
            this.checkBoxReadMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxNumberOfLinks
            // 
            this.checkBoxNumberOfLinks.AutoSize = true;
            this.checkBoxNumberOfLinks.Checked = true;
            this.checkBoxNumberOfLinks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNumberOfLinks.Location = new System.Drawing.Point(132, 99);
            this.checkBoxNumberOfLinks.Name = "checkBoxNumberOfLinks";
            this.checkBoxNumberOfLinks.Size = new System.Drawing.Size(103, 17);
            this.checkBoxNumberOfLinks.TabIndex = 6;
            this.checkBoxNumberOfLinks.Text = "Number of Links";
            this.checkBoxNumberOfLinks.UseVisualStyleBackColor = true;
            // 
            // checkBoxPipeType
            // 
            this.checkBoxPipeType.AutoSize = true;
            this.checkBoxPipeType.Checked = true;
            this.checkBoxPipeType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPipeType.Location = new System.Drawing.Point(132, 76);
            this.checkBoxPipeType.Name = "checkBoxPipeType";
            this.checkBoxPipeType.Size = new System.Drawing.Size(74, 17);
            this.checkBoxPipeType.TabIndex = 5;
            this.checkBoxPipeType.Text = "Pipe Type";
            this.checkBoxPipeType.UseVisualStyleBackColor = true;
            // 
            // checkBoxConfiguration
            // 
            this.checkBoxConfiguration.AutoSize = true;
            this.checkBoxConfiguration.Checked = true;
            this.checkBoxConfiguration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConfiguration.Location = new System.Drawing.Point(6, 76);
            this.checkBoxConfiguration.Name = "checkBoxConfiguration";
            this.checkBoxConfiguration.Size = new System.Drawing.Size(88, 17);
            this.checkBoxConfiguration.TabIndex = 4;
            this.checkBoxConfiguration.Text = "Configuration";
            this.checkBoxConfiguration.UseVisualStyleBackColor = true;
            // 
            // checkBoxClientProcessId
            // 
            this.checkBoxClientProcessId.AutoSize = true;
            this.checkBoxClientProcessId.Checked = true;
            this.checkBoxClientProcessId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxClientProcessId.Location = new System.Drawing.Point(132, 53);
            this.checkBoxClientProcessId.Name = "checkBoxClientProcessId";
            this.checkBoxClientProcessId.Size = new System.Drawing.Size(78, 17);
            this.checkBoxClientProcessId.TabIndex = 3;
            this.checkBoxClientProcessId.Text = "Client PIDs";
            this.checkBoxClientProcessId.UseVisualStyleBackColor = true;
            // 
            // checkBoxEndpointType
            // 
            this.checkBoxEndpointType.AutoSize = true;
            this.checkBoxEndpointType.Checked = true;
            this.checkBoxEndpointType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEndpointType.Location = new System.Drawing.Point(6, 53);
            this.checkBoxEndpointType.Name = "checkBoxEndpointType";
            this.checkBoxEndpointType.Size = new System.Drawing.Size(95, 17);
            this.checkBoxEndpointType.TabIndex = 2;
            this.checkBoxEndpointType.Text = "Endpoint Type";
            this.checkBoxEndpointType.UseVisualStyleBackColor = true;
            // 
            // checkBoxSddl
            // 
            this.checkBoxSddl.AutoSize = true;
            this.checkBoxSddl.Checked = true;
            this.checkBoxSddl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSddl.Location = new System.Drawing.Point(132, 30);
            this.checkBoxSddl.Name = "checkBoxSddl";
            this.checkBoxSddl.Size = new System.Drawing.Size(47, 17);
            this.checkBoxSddl.TabIndex = 1;
            this.checkBoxSddl.Text = "Sddl";
            this.checkBoxSddl.UseVisualStyleBackColor = true;
            // 
            // checkBoxName
            // 
            this.checkBoxName.AutoSize = true;
            this.checkBoxName.Checked = true;
            this.checkBoxName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxName.Location = new System.Drawing.Point(7, 30);
            this.checkBoxName.Name = "checkBoxName";
            this.checkBoxName.Size = new System.Drawing.Size(54, 17);
            this.checkBoxName.TabIndex = 0;
            this.checkBoxName.Text = "Name";
            this.checkBoxName.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select columns to appear in the Procnoid window:";
            // 
            // groupBoxTimeStamp
            // 
            this.groupBoxTimeStamp.Controls.Add(this.checkBoxCreationTime);
            this.groupBoxTimeStamp.Controls.Add(this.checkBoxChangeTime);
            this.groupBoxTimeStamp.Controls.Add(this.checkBoxLastWriteTime);
            this.groupBoxTimeStamp.Controls.Add(this.checkBoxLastAccessTime);
            this.groupBoxTimeStamp.Controls.Add(this.checkBoxFileCreationTime);
            this.groupBoxTimeStamp.Location = new System.Drawing.Point(12, 410);
            this.groupBoxTimeStamp.Name = "groupBoxTimeStamp";
            this.groupBoxTimeStamp.Size = new System.Drawing.Size(272, 95);
            this.groupBoxTimeStamp.TabIndex = 3;
            this.groupBoxTimeStamp.TabStop = false;
            this.groupBoxTimeStamp.Text = "Time Stamp";
            // 
            // checkBoxCreationTime
            // 
            this.checkBoxCreationTime.AutoSize = true;
            this.checkBoxCreationTime.Checked = true;
            this.checkBoxCreationTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCreationTime.Location = new System.Drawing.Point(7, 28);
            this.checkBoxCreationTime.Name = "checkBoxCreationTime";
            this.checkBoxCreationTime.Size = new System.Drawing.Size(91, 17);
            this.checkBoxCreationTime.TabIndex = 3;
            this.checkBoxCreationTime.Text = "Creation Time";
            this.checkBoxCreationTime.UseVisualStyleBackColor = true;
            // 
            // checkBoxChangeTime
            // 
            this.checkBoxChangeTime.AutoSize = true;
            this.checkBoxChangeTime.Location = new System.Drawing.Point(7, 72);
            this.checkBoxChangeTime.Name = "checkBoxChangeTime";
            this.checkBoxChangeTime.Size = new System.Drawing.Size(89, 17);
            this.checkBoxChangeTime.TabIndex = 6;
            this.checkBoxChangeTime.Text = "Change Time";
            this.checkBoxChangeTime.UseVisualStyleBackColor = true;
            // 
            // checkBoxLastWriteTime
            // 
            this.checkBoxLastWriteTime.AutoSize = true;
            this.checkBoxLastWriteTime.Location = new System.Drawing.Point(133, 51);
            this.checkBoxLastWriteTime.Name = "checkBoxLastWriteTime";
            this.checkBoxLastWriteTime.Size = new System.Drawing.Size(100, 17);
            this.checkBoxLastWriteTime.TabIndex = 5;
            this.checkBoxLastWriteTime.Text = "Last Write Time";
            this.checkBoxLastWriteTime.UseVisualStyleBackColor = true;
            // 
            // checkBoxLastAccessTime
            // 
            this.checkBoxLastAccessTime.AutoSize = true;
            this.checkBoxLastAccessTime.Location = new System.Drawing.Point(7, 51);
            this.checkBoxLastAccessTime.Name = "checkBoxLastAccessTime";
            this.checkBoxLastAccessTime.Size = new System.Drawing.Size(110, 17);
            this.checkBoxLastAccessTime.TabIndex = 4;
            this.checkBoxLastAccessTime.Text = "Last Access Time";
            this.checkBoxLastAccessTime.UseVisualStyleBackColor = true;
            // 
            // checkBoxFileCreationTime
            // 
            this.checkBoxFileCreationTime.AutoSize = true;
            this.checkBoxFileCreationTime.Location = new System.Drawing.Point(133, 28);
            this.checkBoxFileCreationTime.Name = "checkBoxFileCreationTime";
            this.checkBoxFileCreationTime.Size = new System.Drawing.Size(110, 17);
            this.checkBoxFileCreationTime.TabIndex = 3;
            this.checkBoxFileCreationTime.Text = "File Creation Time";
            this.checkBoxFileCreationTime.UseVisualStyleBackColor = true;
            // 
            // checkBoxIntegrityLevel
            // 
            this.checkBoxIntegrityLevel.AutoSize = true;
            this.checkBoxIntegrityLevel.Checked = true;
            this.checkBoxIntegrityLevel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIntegrityLevel.Location = new System.Drawing.Point(132, 76);
            this.checkBoxIntegrityLevel.Name = "checkBoxIntegrityLevel";
            this.checkBoxIntegrityLevel.Size = new System.Drawing.Size(92, 17);
            this.checkBoxIntegrityLevel.TabIndex = 1;
            this.checkBoxIntegrityLevel.Text = "Integrity Level";
            this.checkBoxIntegrityLevel.UseVisualStyleBackColor = true;
            // 
            // checkBoxPermissions
            // 
            this.checkBoxPermissions.AutoSize = true;
            this.checkBoxPermissions.Checked = true;
            this.checkBoxPermissions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPermissions.Location = new System.Drawing.Point(6, 30);
            this.checkBoxPermissions.Name = "checkBoxPermissions";
            this.checkBoxPermissions.Size = new System.Drawing.Size(81, 17);
            this.checkBoxPermissions.TabIndex = 0;
            this.checkBoxPermissions.Text = "Permissions";
            this.checkBoxPermissions.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(113, 521);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(209, 521);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxSecurityDescriptor
            // 
            this.groupBoxSecurityDescriptor.Controls.Add(this.checkBoxGroupSid);
            this.groupBoxSecurityDescriptor.Controls.Add(this.checkBoxOwnerSid);
            this.groupBoxSecurityDescriptor.Controls.Add(this.checkBoxOwnerName);
            this.groupBoxSecurityDescriptor.Controls.Add(this.checkBoxGroupName);
            this.groupBoxSecurityDescriptor.Controls.Add(this.checkBoxPermissions);
            this.groupBoxSecurityDescriptor.Controls.Add(this.checkBoxIntegrityLevel);
            this.groupBoxSecurityDescriptor.Location = new System.Drawing.Point(12, 294);
            this.groupBoxSecurityDescriptor.Name = "groupBoxSecurityDescriptor";
            this.groupBoxSecurityDescriptor.Size = new System.Drawing.Size(272, 108);
            this.groupBoxSecurityDescriptor.TabIndex = 3;
            this.groupBoxSecurityDescriptor.TabStop = false;
            this.groupBoxSecurityDescriptor.Text = "Security Descriptor";
            // 
            // checkBoxGroupSid
            // 
            this.checkBoxGroupSid.AutoSize = true;
            this.checkBoxGroupSid.Location = new System.Drawing.Point(7, 76);
            this.checkBoxGroupSid.Name = "checkBoxGroupSid";
            this.checkBoxGroupSid.Size = new System.Drawing.Size(73, 17);
            this.checkBoxGroupSid.TabIndex = 3;
            this.checkBoxGroupSid.Text = "Group Sid";
            this.checkBoxGroupSid.UseVisualStyleBackColor = true;
            // 
            // checkBoxOwnerSid
            // 
            this.checkBoxOwnerSid.AutoSize = true;
            this.checkBoxOwnerSid.Location = new System.Drawing.Point(6, 53);
            this.checkBoxOwnerSid.Name = "checkBoxOwnerSid";
            this.checkBoxOwnerSid.Size = new System.Drawing.Size(75, 17);
            this.checkBoxOwnerSid.TabIndex = 2;
            this.checkBoxOwnerSid.Text = "Owner Sid";
            this.checkBoxOwnerSid.UseVisualStyleBackColor = true;
            // 
            // checkBoxOwnerName
            // 
            this.checkBoxOwnerName.AutoSize = true;
            this.checkBoxOwnerName.Checked = true;
            this.checkBoxOwnerName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOwnerName.Location = new System.Drawing.Point(132, 30);
            this.checkBoxOwnerName.Name = "checkBoxOwnerName";
            this.checkBoxOwnerName.Size = new System.Drawing.Size(88, 17);
            this.checkBoxOwnerName.TabIndex = 1;
            this.checkBoxOwnerName.Text = "Owner Name";
            this.checkBoxOwnerName.UseVisualStyleBackColor = true;
            // 
            // checkBoxGroupName
            // 
            this.checkBoxGroupName.AutoSize = true;
            this.checkBoxGroupName.Location = new System.Drawing.Point(132, 53);
            this.checkBoxGroupName.Name = "checkBoxGroupName";
            this.checkBoxGroupName.Size = new System.Drawing.Size(86, 17);
            this.checkBoxGroupName.TabIndex = 0;
            this.checkBoxGroupName.Text = "Group Name";
            this.checkBoxGroupName.UseVisualStyleBackColor = true;
            // 
            // checkBoxDirectoryGrantedAccess
            // 
            this.checkBoxDirectoryGrantedAccess.AutoSize = true;
            this.checkBoxDirectoryGrantedAccess.Checked = true;
            this.checkBoxDirectoryGrantedAccess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDirectoryGrantedAccess.Location = new System.Drawing.Point(11, 30);
            this.checkBoxDirectoryGrantedAccess.Name = "checkBoxDirectoryGrantedAccess";
            this.checkBoxDirectoryGrantedAccess.Size = new System.Drawing.Size(147, 17);
            this.checkBoxDirectoryGrantedAccess.TabIndex = 8;
            this.checkBoxDirectoryGrantedAccess.Text = "Directory Granted Access";
            this.checkBoxDirectoryGrantedAccess.UseVisualStyleBackColor = true;
            // 
            // groupBoxAccess
            // 
            this.groupBoxAccess.Controls.Add(this.checkBoxGrantedAccess);
            this.groupBoxAccess.Controls.Add(this.checkBoxDirectoryGrantedAccess);
            this.groupBoxAccess.Controls.Add(this.checkBoxGrantedAccessGeneric);
            this.groupBoxAccess.Location = new System.Drawing.Point(12, 198);
            this.groupBoxAccess.Name = "groupBoxAccess";
            this.groupBoxAccess.Size = new System.Drawing.Size(272, 91);
            this.groupBoxAccess.TabIndex = 4;
            this.groupBoxAccess.TabStop = false;
            this.groupBoxAccess.Text = "Access";
            // 
            // checkBoxGrantedAccess
            // 
            this.checkBoxGrantedAccess.AutoSize = true;
            this.checkBoxGrantedAccess.Checked = true;
            this.checkBoxGrantedAccess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGrantedAccess.Location = new System.Drawing.Point(164, 30);
            this.checkBoxGrantedAccess.Name = "checkBoxGrantedAccess";
            this.checkBoxGrantedAccess.Size = new System.Drawing.Size(102, 17);
            this.checkBoxGrantedAccess.TabIndex = 1;
            this.checkBoxGrantedAccess.Text = "Granted Access";
            this.checkBoxGrantedAccess.UseVisualStyleBackColor = true;
            // 
            // checkBoxGrantedAccessGeneric
            // 
            this.checkBoxGrantedAccessGeneric.AutoSize = true;
            this.checkBoxGrantedAccessGeneric.Checked = true;
            this.checkBoxGrantedAccessGeneric.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGrantedAccessGeneric.Location = new System.Drawing.Point(11, 53);
            this.checkBoxGrantedAccessGeneric.Name = "checkBoxGrantedAccessGeneric";
            this.checkBoxGrantedAccessGeneric.Size = new System.Drawing.Size(142, 17);
            this.checkBoxGrantedAccessGeneric.TabIndex = 0;
            this.checkBoxGrantedAccessGeneric.Text = "Granted Access Generic";
            this.checkBoxGrantedAccessGeneric.UseVisualStyleBackColor = true;
            // 
            // checkBoxHandle
            // 
            this.checkBoxHandle.AutoSize = true;
            this.checkBoxHandle.Checked = true;
            this.checkBoxHandle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHandle.Location = new System.Drawing.Point(5, 122);
            this.checkBoxHandle.Name = "checkBoxHandle";
            this.checkBoxHandle.Size = new System.Drawing.Size(60, 17);
            this.checkBoxHandle.TabIndex = 8;
            this.checkBoxHandle.Text = "Handle";
            this.checkBoxHandle.UseVisualStyleBackColor = true;
            // 
            // ColumnSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 557);
            this.Controls.Add(this.groupBoxAccess);
            this.Controls.Add(this.groupBoxSecurityDescriptor);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxTimeStamp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxNamedPipe);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColumnSelection";
            this.ShowIcon = false;
            this.Text = "PipeViewer Column Selection";
            this.groupBoxNamedPipe.ResumeLayout(false);
            this.groupBoxNamedPipe.PerformLayout();
            this.groupBoxTimeStamp.ResumeLayout(false);
            this.groupBoxTimeStamp.PerformLayout();
            this.groupBoxSecurityDescriptor.ResumeLayout(false);
            this.groupBoxSecurityDescriptor.PerformLayout();
            this.groupBoxAccess.ResumeLayout(false);
            this.groupBoxAccess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxNamedPipe;
        private System.Windows.Forms.CheckBox checkBoxEndpointType;
        private System.Windows.Forms.CheckBox checkBoxSddl;
        private System.Windows.Forms.CheckBox checkBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxTimeStamp;
        private System.Windows.Forms.CheckBox checkBoxChangeTime;
        private System.Windows.Forms.CheckBox checkBoxLastWriteTime;
        private System.Windows.Forms.CheckBox checkBoxLastAccessTime;
        private System.Windows.Forms.CheckBox checkBoxFileCreationTime;
        private System.Windows.Forms.CheckBox checkBoxIntegrityLevel;
        private System.Windows.Forms.CheckBox checkBoxPermissions;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxSecurityDescriptor;
        private System.Windows.Forms.CheckBox checkBoxGroupSid;
        private System.Windows.Forms.CheckBox checkBoxOwnerSid;
        private System.Windows.Forms.CheckBox checkBoxOwnerName;
        private System.Windows.Forms.CheckBox checkBoxGroupName;
        private System.Windows.Forms.CheckBox checkBoxCreationTime;
        private System.Windows.Forms.CheckBox checkBoxClientProcessId;
        private System.Windows.Forms.CheckBox checkBoxConfiguration;
        private System.Windows.Forms.CheckBox checkBoxPipeType;
        private System.Windows.Forms.CheckBox checkBoxDirectoryGrantedAccess;
        private System.Windows.Forms.CheckBox checkBoxReadMode;
        private System.Windows.Forms.CheckBox checkBoxNumberOfLinks;
        private System.Windows.Forms.GroupBox groupBoxAccess;
        private System.Windows.Forms.CheckBox checkBoxGrantedAccess;
        private System.Windows.Forms.CheckBox checkBoxGrantedAccessGeneric;
        private System.Windows.Forms.CheckBox checkBoxHandle;
    }
}