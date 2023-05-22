using System;
using System.Windows.Forms;

namespace PipeViewer
{
    public partial class FormSearch : Form
    {
        public delegate void searchEventHandler(string i_SearchString, bool i_SearchDown, bool i_MatchWholeWord, bool i_MatchSensitive);

        public event searchEventHandler searchForMatch;

        public FormSearch()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void OnSearchForMatch(string i_SearchString, bool i_SearchDown, bool i_MatchWholeWord, bool i_MatchSensitive)
        {
            if (!isWordInComboBox(i_SearchString))
            {
                comboBox1.Items.Add(i_SearchString);
            }

            if (searchForMatch != null)
            {
                searchForMatch.Invoke(i_SearchString, i_SearchDown, i_MatchWholeWord, i_MatchSensitive);
            }
        }

        private bool isWordInComboBox(string i_SearchString)
        {
            bool isInside = false;

            foreach (var item in comboBox1.Items)
            {
                if (i_SearchString.Equals(item.ToString()))
                {
                    isInside = true;
                }
            }

            return isInside;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            OnSearchForMatch(comboBox1.Text, radioButtonDown.Checked, false, false);
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Simulate a button click
                buttonFind.PerformClick();
                e.Handled = true;
            }
        }
    }
}
