using System;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace PipeViewer
{
    public delegate void highlightRowsEventHandler(ListView i_ListView);
    public partial class FormHighlighting : Form
    {
        public event highlightRowsEventHandler hightlightRowsUpdate;

        public FormHighlighting(ref ListView i_ListViewHighlighFilter)
        {
            InitializeComponentWrapper();

            foreach (ListViewItem item in i_ListViewHighlighFilter.Items)
            {
                ListViewItem clonedItem = (ListViewItem)item.Clone();
                this.listViewHighlights.Items.Add(clonedItem);
            }
        }

        private void InitializeComponentWrapper()
        {
            InitializeComponent();
            this.comboBoxColumn.SelectedIndex = 0;
            this.comboBoxRelation.SelectedIndex = 0;
            this.comboBoxAction.SelectedIndex = 0;
            this.listViewHighlights.FullRowSelect = true;
        }


        // DUPLICATED function in ColumnFilter
        // Maybe create a shared function in Utils but it threw an exception for "type initializer"
        private bool isRowExist(string i_Column, string i_Relation, string i_Value, string i_Action)
        {
            bool isExist = false;
            string newRow = i_Column + i_Relation + i_Value + i_Action;
            foreach (ListViewItem item in listViewHighlights.Items)
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
            if (!isRowExist(comboBoxColumn.Text, comboBoxRelation.Text, comboBoxValue.Text, comboBoxAction.Text) && !comboBoxValue.Text.Equals(""))
            {
                ListViewItem item = new ListViewItem(comboBoxColumn.Text);
                item.SubItems.Add(comboBoxRelation.Text);
                item.SubItems.Add(comboBoxValue.Text);
                item.SubItems.Add(comboBoxAction.Text);
                item.Checked = true;
                this.listViewHighlights.Items.Add(item);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listViewHighlights.SelectedItems)
            {
                item.Remove();
            }
        }

        private void listViewHighlights_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in ((ListView)sender).SelectedItems)
            {
                this.comboBoxColumn.Text = item.SubItems[0].Text;
                this.comboBoxRelation.Text = item.SubItems[1].Text;
                this.comboBoxValue.Text = item.SubItems[2].Text;
                this.comboBoxAction.Text = item.SubItems[3].Text;
                item.Remove();
            }
        }

        public virtual void OnHighlightRowsUpdate(ListView i_ListView)
        {
            if (hightlightRowsUpdate != null)
            {
                hightlightRowsUpdate.Invoke(i_ListView);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            buttonAdd_Click(sender, e);
            OnHighlightRowsUpdate(listViewHighlights);
            this.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.listViewHighlights.Clear();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            buttonAdd_Click(sender, e);
            OnHighlightRowsUpdate(listViewHighlights);
        }
    }
}
