namespace NornManager
{
    partial class CampaignForm
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
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.lstContent = new System.Windows.Forms.ListBox();
            this.btnAddContent = new System.Windows.Forms.Button();
            this.btnRemoveContent = new System.Windows.Forms.Button();
            this.btnEditContent = new System.Windows.Forms.Button();
            this.btnManageContent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(12, 12);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(157, 433);
            this.lstUsers.TabIndex = 0;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // lstContent
            // 
            this.lstContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstContent.FormattingEnabled = true;
            this.lstContent.Location = new System.Drawing.Point(175, 12);
            this.lstContent.Name = "lstContent";
            this.lstContent.Size = new System.Drawing.Size(318, 368);
            this.lstContent.TabIndex = 1;
            // 
            // btnAddContent
            // 
            this.btnAddContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddContent.Location = new System.Drawing.Point(285, 393);
            this.btnAddContent.Name = "btnAddContent";
            this.btnAddContent.Size = new System.Drawing.Size(100, 23);
            this.btnAddContent.TabIndex = 2;
            this.btnAddContent.Text = "Add Content";
            this.btnAddContent.UseVisualStyleBackColor = true;
            this.btnAddContent.Click += new System.EventHandler(this.btnAddContent_Click);
            // 
            // btnRemoveContent
            // 
            this.btnRemoveContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveContent.Location = new System.Drawing.Point(285, 422);
            this.btnRemoveContent.Name = "btnRemoveContent";
            this.btnRemoveContent.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveContent.TabIndex = 3;
            this.btnRemoveContent.Text = "Remove Content";
            this.btnRemoveContent.UseVisualStyleBackColor = true;
            this.btnRemoveContent.Click += new System.EventHandler(this.btnRemoveContent_Click);
            // 
            // btnEditContent
            // 
            this.btnEditContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditContent.Location = new System.Drawing.Point(391, 393);
            this.btnEditContent.Name = "btnEditContent";
            this.btnEditContent.Size = new System.Drawing.Size(102, 23);
            this.btnEditContent.TabIndex = 4;
            this.btnEditContent.Text = "Edit Content";
            this.btnEditContent.UseVisualStyleBackColor = true;
            this.btnEditContent.Click += new System.EventHandler(this.btnEditContent_Click);
            // 
            // btnManageContent
            // 
            this.btnManageContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManageContent.Location = new System.Drawing.Point(391, 422);
            this.btnManageContent.Name = "btnManageContent";
            this.btnManageContent.Size = new System.Drawing.Size(102, 23);
            this.btnManageContent.TabIndex = 5;
            this.btnManageContent.Text = "Manage Content";
            this.btnManageContent.UseVisualStyleBackColor = true;
            this.btnManageContent.Click += new System.EventHandler(this.btnManageContent_Click);
            // 
            // CampaignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 457);
            this.Controls.Add(this.btnManageContent);
            this.Controls.Add(this.btnEditContent);
            this.Controls.Add(this.btnRemoveContent);
            this.Controls.Add(this.btnAddContent);
            this.Controls.Add(this.lstContent);
            this.Controls.Add(this.lstUsers);
            this.Name = "CampaignForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.ListBox lstContent;
        private System.Windows.Forms.Button btnAddContent;
        private System.Windows.Forms.Button btnRemoveContent;
        private System.Windows.Forms.Button btnEditContent;
        private System.Windows.Forms.Button btnManageContent;
    }
}

