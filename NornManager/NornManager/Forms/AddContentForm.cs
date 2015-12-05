using NornManager.Model;
using NornManager.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NornManager.Forms
{
    public partial class AddContentForm : Form
    {
        private string _id; //contentOnUser or userId

        private bool _isEditing = false;

        public AddContentForm(string id, string selectedContent = "", string existingDetails = "")
        {
            InitializeComponent();

            _id = id;            

            //Autocompletion
            atxtContent.Values = Store.Get().VisibleContentTitles.ToArray();

            if (!selectedContent.Equals(""))
            {
                _isEditing = true;
                atxtContent.Text = selectedContent;
                atxtContent.Enabled = false;
                txtDetails.Text = existingDetails;
                btnAdd.Text = "Edit";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            var selectedContent = Store.Get().VisibleContent.FirstOrDefault(c => c.title.Equals(atxtContent.Text));
            if(selectedContent != null)
            {
                if (_isEditing) //Edit item
                {
                    DbUsers.EditContentOnUser(_id, txtDetails.Text);
                }
                else //New item
                {
                    DbUsers.AddContentToUser(selectedContent.id, _id, txtDetails.Text);
                }
                Close();
            }            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
