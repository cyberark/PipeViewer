using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace PipeViewer
{
    public partial class PipePropertiesForm : Form
    {
        private Dictionary<string, PermissionDetails> userPermissions = new Dictionary<string, PermissionDetails>();
        private ImageList userImageList;

        public class PermissionDetails
        {
            public string CanFull { get; set; } = "";
            public string CanExecute{ get; set; } = "";
            public string CanRead { get; set; } = "";
            public string CanWrite { get; set; } = "";
            public string CanSpecial { get; set; } = "";

        }
        public PipePropertiesForm(Dictionary<string, string> pipeData)
        {
            InitializeComponent();
            // Initialize ImageList
            userImageList = new ImageList();
            userImageList.Images.Add("user", Properties.Resources.User_icon_256_blue);
            listViewUsers.SmallImageList = userImageList;

            //General Tab
            lblName.Text = "Name: ";
            textBoxName.Text = pipeData["ColumnName"];
            lblType.Text = "Type: ";
            textBoxType.Text = pipeData["ColumnPipeType"];
            lblObjectAddress.Text = "Handle: ";
            textBoxObjectAddress.Text = pipeData["ColumnHandle"];
            lblGrantedAccess.Text = "Granted Access: ";
            textBoxGrantedAccess.Text = pipeData["ColumnGrantedAccess"];

            //Security Tab
            lblName2.Text = "Name: ";
            textBoxName2.Text = pipeData["ColumnName"];
            ParsePermissions(pipeData["ColumnPermissions"]);
            PopulateUsersListView();
            listViewUsers.SelectedIndexChanged += listViewUsers_SelectedIndexChanged;
        }

        private void ParsePermissions(string permissionsText)
        {
            if (string.IsNullOrEmpty(permissionsText))
            {
                return;
            }
            string[] permissionEntries = permissionsText.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            Regex regex = new Regex(@"(Allowed [^\s]+|Denied [^\s]+) (.+)", RegexOptions.IgnoreCase);

            foreach (string entry in permissionEntries)
            {
                string trimmedEntry = entry.Trim();

                // Use Regex to match the pattern
                Match match = regex.Match(trimmedEntry);
                if (match.Success)
                {
                    string permissionType = match.Groups[1].Value;  // This captures "Allowed ___" or "Denied ___"
                    string user = match.Groups[2].Value;           // This captures the user name, handling spaces within names

                    // Assign the permission type to the user in the dictionary
                    // Initialize the list if the user doesn't already exist in the dictionary
                    if (!userPermissions.ContainsKey(user))
                    {
                        userPermissions[user] = new PermissionDetails();
                    }
                    PermissionSetup(permissionType, user);
                }
            }
        }
        private void PopulateUsersListView()
        {
            listViewUsers.Items.Clear();
            listViewUsers.View = View.List;

            // Add items to the ListView
            foreach (var user in userPermissions.Keys)
            {
                ListViewItem item = new ListViewItem(user); // Declare and initialize the item
                item.ImageKey = "user"; // Set the image key for the item
                listViewUsers.Items.Add(item); // Add the item to the ListView
            }

            // Auto resize columns to fit the content
            //listViewUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }


        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count > 0)
            {
                var selectedUser = listViewUsers.SelectedItems[0].Text;
                PopulatePermissionsListView(selectedUser);
            }
        }
        private void PermissionSetup(string permissionType, string user)
        {
            // Determine the new value based on the permission type
            string newValue;
            if (permissionType.Contains("Allowed"))
            {
                newValue = "true";
            }
            else if (permissionType.Contains("Denied"))
            {
                newValue = "false";
            }
            else
            {
                newValue = null; // Default to null if neither Allowed nor Denied
            }

            // Check and set permissions for Full, Read, Write, Execute, and Special
            if (permissionType.Contains("Full"))
            {
                userPermissions[user].CanFull = newValue;
            }
            if (permissionType.Contains("R"))
            {
                userPermissions[user].CanRead = newValue;
            }
            if (permissionType.Contains("W"))
            {
                userPermissions[user].CanWrite = newValue;
            }
            if (permissionType.Contains("X"))
            {
                userPermissions[user].CanExecute = newValue;
            }
            if (permissionType.Contains("Special"))
            {
                userPermissions[user].CanSpecial = newValue;
            }
        }

        private void PopulatePermissionsListView(string user)
        {
            // Clear all items from listViewPermissions and reset all checkboxes
            listViewPermissions.Items.Clear();
            checkBoxAllowedFull.Checked = false;
            checkBoxAllowedRead.Checked = false;
            checkBoxAllowedWrite.Checked = false;
            checkBoxAllowedExecute.Checked = false;
            checkBoxAllowedSpecial.Checked = false;
            checkBoxDenyFull.Checked = false;
            checkBoxDenyRead.Checked = false;
            checkBoxDenyWrite.Checked = false;
            checkBoxDenyExecute.Checked = false;
            checkBoxDenySpecial.Checked = false;

            // Set checkboxes based on the permissions settings for the user
            SetCheckBox(checkBoxAllowedFull, checkBoxDenyFull, userPermissions[user].CanFull);
            SetCheckBox(checkBoxAllowedRead, checkBoxDenyRead, userPermissions[user].CanRead);
            SetCheckBox(checkBoxAllowedWrite, checkBoxDenyWrite, userPermissions[user].CanWrite);
            SetCheckBox(checkBoxAllowedExecute, checkBoxDenyExecute, userPermissions[user].CanExecute);
            SetCheckBox(checkBoxAllowedSpecial, checkBoxDenySpecial, userPermissions[user].CanSpecial);
        }

        private void SetCheckBox(CheckBox allowedCheckBox, CheckBox deniedCheckBox, string permissionValue)
        {
            if (permissionValue == "true")
            {
                allowedCheckBox.Checked = true;
                deniedCheckBox.Checked = false;
            }
            else if (permissionValue == "false")
            {
                deniedCheckBox.Checked = true;
                allowedCheckBox.Checked = false;
            }
            else // Handle null or empty string by ensuring both checkboxes are unchecked
            {
                allowedCheckBox.Checked = false;
                deniedCheckBox.Checked = false;
            }
        }

    }
}
