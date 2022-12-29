using System;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace PipeViewer
{
    public delegate void FilterOKEventHandler(ListView i_listViewColumnFilter);
    public partial class FormColumnFilter : Form
    {
        private DataGridView m_DataGridView;
        public event FilterOKEventHandler FilterOKUpdate;
        public FormColumnFilter(ref ListView i_ListViewColumnFilter)
        {
            InitializeComponentWrapper();

            foreach (ListViewItem item in i_ListViewColumnFilter.Items)
            {
                ListViewItem clonedItem = (ListViewItem)item.Clone();
                this.listViewColumnFilters.Items.Add(clonedItem);
            }
        }

        public virtual void OnFilterOKUpdate(ListView i_listViewColumnFilter)
        {
            bool empty = true;
            foreach (ListViewItem item in i_listViewColumnFilter.Items)
            {
                if (item.Checked)
                {
                    empty = false;
                }
            }
            if (empty)
            {
                i_listViewColumnFilter = new ListView();
            }
            if (FilterOKUpdate != null)
            {
                FilterOKUpdate.Invoke(i_listViewColumnFilter);
            }
        }

        private void InitializeComponentWrapper()
        {
            InitializeComponent();
            this.comboBoxSearchByColumn.SelectedIndex = 0;
            this.comboBoxRelation.SelectedIndex = 0;
            this.comboBoxAction.SelectedIndex = 0;
            this.listViewColumnFilters.FullRowSelect = true;
        }

        public FormColumnFilter(ref DataGridView i_DataGridView)
        {
            m_DataGridView = i_DataGridView;
            InitializeComponentWrapper();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            buttonAdd_Click(sender, e);
            OnFilterOKUpdate(this.listViewColumnFilters);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // DUPLICATED function in FormHighlighting
        // Maybe create a shared function in Utils but it threw an exception for "type initializer"
        private bool isRowExist(string i_Column, string i_Relation, string i_Value, string i_Action)
        {
            bool isExist = false;
            string newRow = i_Column + i_Relation + i_Value + i_Action;
            foreach (ListViewItem item in listViewColumnFilters.Items)
            {
                string rawRow = "";
                foreach (ListViewSubItem subItem in item.SubItems)
                {
                    rawRow += subItem.Text;
                }

                if (newRow == rawRow)
                {
                    isExist = true;
                    break;
                }

            }

            return isExist;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!isRowExist(comboBoxSearchByColumn.Text, comboBoxRelation.Text, comboBoxValue.Text, comboBoxAction.Text))
            {
                ListViewItem item = new ListViewItem(comboBoxSearchByColumn.Text);
                item.SubItems.Add(comboBoxRelation.Text);
                item.SubItems.Add(comboBoxValue.Text);
                item.SubItems.Add(comboBoxAction.Text);
                item.Checked = true;
                this.listViewColumnFilters.Items.Add(item);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listViewColumnFilters.SelectedItems)
            {
                item.Remove();
            }
        }

        private void listViewColumnFilters_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in ((ListView)sender).SelectedItems)
            {
                this.comboBoxSearchByColumn.Text = item.SubItems[0].Text;
                this.comboBoxRelation.Text = item.SubItems[1].Text;
                this.comboBoxValue.Text = item.SubItems[2].Text;
                this.comboBoxAction.Text = item.SubItems[3].Text;
                item.Remove();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            listViewColumnFilters.Items.Clear();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            buttonAdd_Click(sender, e);
            OnFilterOKUpdate(this.listViewColumnFilters);
        }
    }
}
