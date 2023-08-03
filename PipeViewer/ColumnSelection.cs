using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PipeViewer
{

    public delegate void selectColumnsEventHandler(GroupBox i_NamedPipe, GroupBox i_Access, GroupBox i_SecurityDescriptor, GroupBox TimeStamp);
    public partial class ColumnSelection : Form
    {
        public event selectColumnsEventHandler selectColumnsUpdate;
        public ColumnSelection(System.Windows.Forms.DataGridView dataGridView1)
        {
            InitializeComponent();

            List<string> visableColumns = new List<string>();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Visible)
                {
                    visableColumns.Add(column.HeaderText);
                }
            }

            initializeCheckboxes(visableColumns);
        }

        // The name of the CheckBox header MUST be the same as the Column header.
        private void initializeCheckboxes(List<string> visableColumns)
        {
            this.checkBoxEndpointType.Checked = visableColumns.Contains(this.checkBoxEndpointType.Text);
            this.checkBoxSddl.Checked = visableColumns.Contains(this.checkBoxSddl.Text);
            this.checkBoxName.Checked = visableColumns.Contains(this.checkBoxName.Text);
            this.checkBoxChangeTime.Checked = visableColumns.Contains(this.checkBoxChangeTime.Text);
            this.checkBoxLastWriteTime.Checked = visableColumns.Contains(this.checkBoxLastWriteTime.Text);
            this.checkBoxLastAccessTime.Checked = visableColumns.Contains(this.checkBoxLastAccessTime.Text);
            this.checkBoxFileCreationTime.Checked = visableColumns.Contains(this.checkBoxFileCreationTime.Text);
            this.checkBoxIntegrityLevel.Checked = visableColumns.Contains(this.checkBoxIntegrityLevel.Text);
            this.checkBoxPermissions.Checked = visableColumns.Contains(this.checkBoxPermissions.Text);
            this.checkBoxGroupSid.Checked = visableColumns.Contains(this.checkBoxGroupSid.Text);
            this.checkBoxOwnerSid.Checked = visableColumns.Contains(this.checkBoxOwnerSid.Text);
            this.checkBoxOwnerName.Checked = visableColumns.Contains(this.checkBoxOwnerName.Text);
            this.checkBoxGroupName.Checked = visableColumns.Contains(this.checkBoxGroupName.Text);
            this.checkBoxCreationTime.Checked = visableColumns.Contains(this.checkBoxCreationTime.Text);
            this.checkBoxClientProcessId.Checked = visableColumns.Contains(this.checkBoxClientProcessId.Text);
            this.checkBoxConfiguration.Checked = visableColumns.Contains(this.checkBoxConfiguration.Text);
            this.checkBoxPipeType.Checked = visableColumns.Contains(this.checkBoxPipeType.Text);
            this.checkBoxDirectoryGrantedAccess.Checked = visableColumns.Contains(this.checkBoxDirectoryGrantedAccess.Text);
            this.checkBoxReadMode.Checked = visableColumns.Contains(this.checkBoxReadMode.Text);
            this.checkBoxNumberOfLinks.Checked = visableColumns.Contains(this.checkBoxNumberOfLinks.Text);
            this.checkBoxGrantedAccess.Checked = visableColumns.Contains(this.checkBoxGrantedAccess.Text);
            this.checkBoxGrantedAccessGeneric.Checked = visableColumns.Contains(this.checkBoxGrantedAccessGeneric.Text);
            this.checkBoxHandle.Checked = visableColumns.Contains(this.checkBoxHandle.Text);
        }


        public virtual void OnselectColumnsUpdate(GroupBox i_NamedPipe, GroupBox i_Access, GroupBox i_SecurityDescriptor, GroupBox i_TimeStamp)
        {
            if (selectColumnsUpdate != null)
            {
                selectColumnsUpdate.Invoke(i_NamedPipe, i_Access, i_SecurityDescriptor, i_TimeStamp);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            OnselectColumnsUpdate(groupBoxNamedPipe, groupBoxAccess, groupBoxSecurityDescriptor, groupBoxTimeStamp);
            this.Close();
        }

        private void ColumnSelection_Load(object sender, EventArgs e)
        {

        }
    }
}
