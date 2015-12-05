﻿using NornManager.Model;
using System;
using System.Windows.Forms;
using NornManager.Network;

namespace NornManager.Forms
{
    public partial class ManageContentForm : Form
    {
        public ManageContentForm()
        {
            InitializeComponent();

            lstContent.Items.AddRange(Store.Get().ContentArray);
            cmbType.Items.AddRange(Store.Get().ContentTypesArray);
            cmbType.SelectedIndex = 0;
        }

        private void lstContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstContent.SelectedItem != null)
            {
                var selectedContent = (Content)lstContent.SelectedItem;
                txtTitle.Text = selectedContent.title;
                txtBody.Text = selectedContent.content;
                chkVisible.Checked = selectedContent.Visible();
                foreach (ContentType type in cmbType.Items)
                {
                    if (type.id == selectedContent.typeid)
                    {
                        cmbType.SelectedItem = type;
                        break;
                    }
                }
                btnAddNew.Text = "Clear";
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (btnAddNew.Text.Equals("Clear"))
            {
                ClearItem();
            }
            else if(!txtTitle.Text.Equals(""))
            {
                btnAddNew.Text = "Clear";
                if (cmbType.SelectedItem == null)
                {
                    return;
                }
                var type = (ContentType)cmbType.SelectedItem;
                var newContent = DbContent.AddContent(txtTitle.Text, txtBody.Text, chkVisible.Checked, type.id);

                //Add the new content item
                Store.Get().AddContent(newContent);
                RefreshList();
                lstContent.SelectedItem = newContent;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstContent.SelectedItem != null && !txtTitle.Text.Equals(""))
            {
                var content = (Content)lstContent.SelectedItem;
                var type = (ContentType)cmbType.SelectedItem;
                DbContent.EditContent(content.id, txtTitle.Text, txtBody.Text, chkVisible.Checked, type.id);

                //Edit the content item
                var visible = chkVisible.Checked ? "1" : "0";
                var editedContent = new Content
                {
                    id = content.id,
                    typeid = "1",
                    title = txtTitle.Text,
                    content = txtBody.Text,
                    visible = visible
                };
                Store.Get().Content.Remove(content);//We use the standard remove function, so the arrays do not get updated (since they will be so on the next line)
                Store.Get().AddContent(editedContent);//We use the custom add function, so the arrays do get updated
                RefreshList();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstContent.SelectedItem != null)
            {
                var content = (Content) lstContent.SelectedItem;
                DbContent.RemoveContent(content.id);

                Store.Get().RemoveContent(content);
                RefreshList();

                ClearItem();
            }
        }

        private void ClearItem()
        {
            lstContent.ClearSelected();
            txtTitle.Text = "";
            txtBody.Text = "";
            chkVisible.Checked = false;
            btnAddNew.Text = "Add New Content";
        }

        private void RefreshList()
        {
            lstContent.Items.Clear();
            lstContent.Items.AddRange(Store.Get().ContentArray);
        }
    }
}
