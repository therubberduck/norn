using NornManager.Model;
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
        }

        private void lstContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstContent.SelectedItem != null)
            {
                var selectedContent = (Content)lstContent.SelectedItem;
                txtTitle.Text = selectedContent.title;
                txtBody.Text = selectedContent.content;
                chkVisible.Checked = selectedContent.Visible();
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
                var newContent = NetworkHandler.AddContent(txtTitle.Text, txtBody.Text, chkVisible.Checked);

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
                NetworkHandler.EditContent(content.id, txtTitle.Text, txtBody.Text, chkVisible.Checked);

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
                NetworkHandler.RemoveContent(content.id);

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
