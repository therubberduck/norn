﻿using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using NornManager.Model;
using System.Collections.Generic;
using NornManager.Network;
using NornManager.Forms;
using System.Linq;

namespace NornManager
{
    public partial class CampaignForm : Form
    {
        public CampaignForm()
        {
            InitializeComponent();

            var store = Store.Get();
            store.Users = NetworkHandler.GetUsers();
            store.Content = NetworkHandler.GetContent();

            lstUsers.Items.AddRange(store.UsersArray);
        }

        private void lstUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var userContent = NetworkHandler.GetUserContent(SelectedUser().id);
            object[] contentArray = userContent.ToArray();

            lstContent.Items.Clear();
            lstContent.Items.AddRange(contentArray);
        }

        private void btnAddContent_Click(object sender, System.EventArgs e)
        {
            if(SelectedUser() != null)
            {
                var addContentForm = new AddContentForm(SelectedUser().id);
                addContentForm.ShowDialog();
                lstUsers_SelectedIndexChanged(null, null);
            }            
        }

        private void btnEditContent_Click(object sender, System.EventArgs e)
        {
            var contentOnUser = (ContentOnUser)lstContent.SelectedItem;
            if(SelectedUser() != null && contentOnUser != null)
            {
                var addContentForm = new AddContentForm(contentOnUser.id, contentOnUser.title, contentOnUser.detail);
                addContentForm.ShowDialog();
                lstUsers_SelectedIndexChanged(null, null);
            }            
        }

        private void btnRemoveContent_Click(object sender, System.EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item?",
                                     "Confirm Deletetion",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var contentOnUser = (ContentOnUser)lstContent.SelectedItem;
                if (SelectedUser() != null && contentOnUser != null)
                {
                    NetworkHandler.RemoveContentFromUser(contentOnUser.id);
                    lstUsers_SelectedIndexChanged(null, null);
                }
            }
        }

        private void btnManageContent_Click(object sender, System.EventArgs e)
        {
            var manageContentForm = new ManageContentForm();
            manageContentForm.ShowDialog();
        }

        private User SelectedUser()
        {
            return (User)lstUsers.SelectedItem;
        }
    }
}
