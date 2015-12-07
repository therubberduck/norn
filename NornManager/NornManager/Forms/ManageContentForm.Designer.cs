namespace NornManager.Forms
{
    partial class ManageContentForm
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
            this.lstContent = new System.Windows.Forms.ListBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnAddLink = new System.Windows.Forms.Button();
            this.atxtLinkName = new NornManager.Views.AutoCompleteTextBox();
            this.imgBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lstContent
            // 
            this.lstContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstContent.FormattingEnabled = true;
            this.lstContent.Location = new System.Drawing.Point(12, 12);
            this.lstContent.Name = "lstContent";
            this.lstContent.Size = new System.Drawing.Size(196, 394);
            this.lstContent.TabIndex = 0;
            this.lstContent.SelectedIndexChanged += new System.EventHandler(this.lstContent_SelectedIndexChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Location = new System.Drawing.Point(214, 321);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(183, 23);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add New Content";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(214, 350);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(295, 350);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(102, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(214, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(183, 20);
            this.txtTitle.TabIndex = 4;
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.HideSelection = false;
            this.txtBody.Location = new System.Drawing.Point(214, 65);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(183, 201);
            this.txtBody.TabIndex = 5;
            // 
            // chkVisible
            // 
            this.chkVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(220, 272);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(56, 17);
            this.chkVisible.TabIndex = 6;
            this.chkVisible.Text = "Visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(214, 38);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(183, 21);
            this.cmbType.TabIndex = 7;
            // 
            // btnAddLink
            // 
            this.btnAddLink.Location = new System.Drawing.Point(374, 295);
            this.btnAddLink.Name = "btnAddLink";
            this.btnAddLink.Size = new System.Drawing.Size(23, 23);
            this.btnAddLink.TabIndex = 9;
            this.btnAddLink.Text = "+";
            this.btnAddLink.UseVisualStyleBackColor = true;
            this.btnAddLink.Click += new System.EventHandler(this.btnAddLink_Click);
            // 
            // atxtLinkName
            // 
            this.atxtLinkName.Location = new System.Drawing.Point(214, 295);
            this.atxtLinkName.Name = "atxtLinkName";
            this.atxtLinkName.Size = new System.Drawing.Size(154, 20);
            this.atxtLinkName.TabIndex = 8;
            this.atxtLinkName.Values = null;
            // 
            // imgBox
            // 
            this.imgBox.Location = new System.Drawing.Point(214, 379);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(183, 27);
            this.imgBox.TabIndex = 10;
            this.imgBox.TabStop = false;
            // 
            // ManageContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 422);
            this.Controls.Add(this.imgBox);
            this.Controls.Add(this.btnAddLink);
            this.Controls.Add(this.atxtLinkName);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.chkVisible);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lstContent);
            this.Name = "ManageContentForm";
            this.Text = "ManageContentForm";
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstContent;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.ComboBox cmbType;
        private Views.AutoCompleteTextBox atxtLinkName;
        private System.Windows.Forms.Button btnAddLink;
        private System.Windows.Forms.PictureBox imgBox;
    }
}