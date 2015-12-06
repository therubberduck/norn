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
        private ContentOnUser _contentOnUser;
        private string _userId;

        public AddContentForm(string userId, ContentOnUser contentOnUser)
        {
            InitializeComponent();

            _userId = userId;
            _contentOnUser = contentOnUser;

            //Autocompletion
            atxtContent.Values = Store.Get().VisibleContentTitles.ToArray();

            if (contentOnUser != null)
            {
                atxtContent.Text = contentOnUser.title;
                atxtContent.Enabled = false;
                txtDetails.Text = contentOnUser.detail;
                txtNumber.Text = contentOnUser.number;
                btnAdd.Text = "Edit";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            var selectedContent = Store.Get().VisibleContent.FirstOrDefault(c => c.title.Equals(atxtContent.Text));
            if(selectedContent != null)
            {
                if (_contentOnUser != null) //Edit item
                {
                    DbUsers.EditContentOnUser(_contentOnUser.id, txtDetails.Text, txtNumber.Text);
                }
                else //New item
                {
                    DbUsers.AddContentToUser(selectedContent.id, _userId, txtDetails.Text, txtNumber.Text);
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
