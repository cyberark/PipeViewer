namespace PipeViewer
{
    partial class FormColumnFilter
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSearchByColumn = new System.Windows.Forms.ComboBox();
            this.comboBoxRelation = new System.Windows.Forms.ComboBox();
            this.comboBoxValue = new System.Windows.Forms.ComboBox();
            this.listViewColumnFilters = new System.Windows.Forms.ListView();
            this.columnHeaderColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRelation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxAction = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.labelThen = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Display entried matching these conditions:";
            // 
            // comboBoxSearchByColumn
            // 
            this.comboBoxSearchByColumn.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxSearchByColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchByColumn.FormattingEnabled = true;
            this.comboBoxSearchByColumn.Items.AddRange(new object[] {
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
            "ChangeTime"});
            this.comboBoxSearchByColumn.Location = new System.Drawing.Point(12, 25);
            this.comboBoxSearchByColumn.Name = "comboBoxSearchByColumn";
            this.comboBoxSearchByColumn.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSearchByColumn.TabIndex = 1;
            // 
            // comboBoxRelation
            // 
            this.comboBoxRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRelation.FormattingEnabled = true;
            this.comboBoxRelation.Items.AddRange(new object[] {
            "contains",
            "is",
            "begins with",
            "ends with"});
            this.comboBoxRelation.Location = new System.Drawing.Point(140, 26);
            this.comboBoxRelation.Name = "comboBoxRelation";
            this.comboBoxRelation.Size = new System.Drawing.Size(87, 21);
            this.comboBoxRelation.TabIndex = 2;
            // 
            // comboBoxValue
            // 
            this.comboBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxValue.FormattingEnabled = true;
            this.comboBoxValue.Location = new System.Drawing.Point(244, 25);
            this.comboBoxValue.Name = "comboBoxValue";
            this.comboBoxValue.Size = new System.Drawing.Size(428, 21);
            this.comboBoxValue.TabIndex = 3;
            // 
            // listViewColumnFilters
            // 
            this.listViewColumnFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewColumnFilters.CheckBoxes = true;
            this.listViewColumnFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderColumn,
            this.columnHeaderRelation,
            this.columnHeaderValue,
            this.columnHeaderAction});
            this.listViewColumnFilters.HideSelection = false;
            this.listViewColumnFilters.Location = new System.Drawing.Point(15, 85);
            this.listViewColumnFilters.Name = "listViewColumnFilters";
            this.listViewColumnFilters.Size = new System.Drawing.Size(792, 351);
            this.listViewColumnFilters.TabIndex = 4;
            this.listViewColumnFilters.UseCompatibleStateImageBehavior = false;
            this.listViewColumnFilters.View = System.Windows.Forms.View.Details;
            this.listViewColumnFilters.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewColumnFilters_MouseDoubleClick);
            // 
            // columnHeaderColumn
            // 
            this.columnHeaderColumn.Text = "Column";
            this.columnHeaderColumn.Width = 92;
            // 
            // columnHeaderRelation
            // 
            this.columnHeaderRelation.Text = "Relation";
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            // 
            // columnHeaderAction
            // 
            this.columnHeaderAction.Text = "Action";
            // 
            // comboBoxAction
            // 
            this.comboBoxAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAction.FormattingEnabled = true;
            this.comboBoxAction.Items.AddRange(new object[] {
            "Include",
            "Exclude"});
            this.comboBoxAction.Location = new System.Drawing.Point(720, 25);
            this.comboBoxAction.Name = "comboBoxAction";
            this.comboBoxAction.Size = new System.Drawing.Size(84, 21);
            this.comboBoxAction.TabIndex = 5;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(567, 454);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(648, 454);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(639, 56);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Location = new System.Drawing.Point(729, 56);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 9;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // labelThen
            // 
            this.labelThen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelThen.AutoSize = true;
            this.labelThen.Location = new System.Drawing.Point(678, 28);
            this.labelThen.Name = "labelThen";
            this.labelThen.Size = new System.Drawing.Size(28, 13);
            this.labelThen.TabIndex = 10;
            this.labelThen.Text = "then";
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(31, 56);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 11;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(732, 454);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 13;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // FormColumnFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 489);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelThen);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxAction);
            this.Controls.Add(this.listViewColumnFilters);
            this.Controls.Add(this.comboBoxValue);
            this.Controls.Add(this.comboBoxRelation);
            this.Controls.Add(this.comboBoxSearchByColumn);
            this.Controls.Add(this.label1);
            this.Name = "FormColumnFilter";
            this.ShowIcon = false;
            this.Text = "PipeViewer Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSearchByColumn;
        private System.Windows.Forms.ComboBox comboBoxRelation;
        private System.Windows.Forms.ComboBox comboBoxValue;
        private System.Windows.Forms.ListView listViewColumnFilters;
        private System.Windows.Forms.ColumnHeader columnHeaderColumn;
        private System.Windows.Forms.ColumnHeader columnHeaderRelation;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.ColumnHeader columnHeaderAction;
        private System.Windows.Forms.ComboBox comboBoxAction;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Label labelThen;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonApply;
    }
}