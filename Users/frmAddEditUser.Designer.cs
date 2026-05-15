namespace DVLD
{
    partial class frmAddEditUser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditUser));
            this.Tab1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblEditPersonInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.txtbFindBy = new System.Windows.Forms.TextBox();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.lblFindByT = new System.Windows.Forms.Label();
            this.ctrlPersonDetials1 = new DVLD.ctrlPersonDetials();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chbIsActive = new System.Windows.Forms.CheckBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtbConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.txtbUserName = new System.Windows.Forms.TextBox();
            this.lblUserIDT = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Tab1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.tabPage1);
            this.Tab1.Controls.Add(this.tabPage2);
            this.Tab1.Location = new System.Drawing.Point(79, 49);
            this.Tab1.Name = "Tab1";
            this.Tab1.SelectedIndex = 0;
            this.Tab1.Size = new System.Drawing.Size(1120, 492);
            this.Tab1.TabIndex = 1;
            this.Tab1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.Tab1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblEditPersonInfo);
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.btnFind);
            this.tabPage1.Controls.Add(this.btnAddNewPerson);
            this.tabPage1.Controls.Add(this.txtbFindBy);
            this.tabPage1.Controls.Add(this.cbFindBy);
            this.tabPage1.Controls.Add(this.lblFindByT);
            this.tabPage1.Controls.Add(this.ctrlPersonDetials1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1112, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Person Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblEditPersonInfo
            // 
            this.lblEditPersonInfo.AutoSize = true;
            this.lblEditPersonInfo.Font = new System.Drawing.Font("Tahoma", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditPersonInfo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblEditPersonInfo.Location = new System.Drawing.Point(748, 368);
            this.lblEditPersonInfo.Name = "lblEditPersonInfo";
            this.lblEditPersonInfo.Size = new System.Drawing.Size(110, 16);
            this.lblEditPersonInfo.TabIndex = 5;
            this.lblEditPersonInfo.Text = "Edit Person Info";
            this.lblEditPersonInfo.Click += new System.EventHandler(this.lblEditPersonInfo_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(944, 396);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(134, 45);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(889, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(89, 78);
            this.btnFind.TabIndex = 2;
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackColor = System.Drawing.Color.White;
            this.btnAddNewPerson.FlatAppearance.BorderSize = 0;
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPerson.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewPerson.Image")));
            this.btnAddNewPerson.Location = new System.Drawing.Point(984, 6);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(94, 84);
            this.btnAddNewPerson.TabIndex = 4;
            this.btnAddNewPerson.UseVisualStyleBackColor = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // txtbFindBy
            // 
            this.txtbFindBy.Location = new System.Drawing.Point(352, 46);
            this.txtbFindBy.Name = "txtbFindBy";
            this.txtbFindBy.Size = new System.Drawing.Size(181, 24);
            this.txtbFindBy.TabIndex = 3;
            this.txtbFindBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFindBy_KeyPress);
            // 
            // cbFindBy
            // 
            this.cbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Location = new System.Drawing.Point(168, 46);
            this.cbFindBy.Name = "cbFindBy";
            this.cbFindBy.Size = new System.Drawing.Size(167, 24);
            this.cbFindBy.TabIndex = 2;
            this.cbFindBy.SelectedIndexChanged += new System.EventHandler(this.cbFindBy_SelectedIndexChanged);
            // 
            // lblFindByT
            // 
            this.lblFindByT.AutoSize = true;
            this.lblFindByT.Location = new System.Drawing.Point(27, 53);
            this.lblFindByT.Name = "lblFindByT";
            this.lblFindByT.Size = new System.Drawing.Size(130, 17);
            this.lblFindByT.TabIndex = 1;
            this.lblFindByT.Text = "FindByPersonID By:";
            this.lblFindByT.Click += new System.EventHandler(this.label1_Click);
            // 
            // ctrlPersonDetials1
            // 
            this.ctrlPersonDetials1.Location = new System.Drawing.Point(30, 96);
            this.ctrlPersonDetials1.Name = "ctrlPersonDetials1";
            this.ctrlPersonDetials1.Size = new System.Drawing.Size(917, 359);
            this.ctrlPersonDetials1.TabIndex = 0;
            this.ctrlPersonDetials1.Load += new System.EventHandler(this.ctrlPersonDetials1_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chbIsActive);
            this.tabPage2.Controls.Add(this.lblUserID);
            this.tabPage2.Controls.Add(this.txtbConfirmPassword);
            this.tabPage2.Controls.Add(this.txtbPassword);
            this.tabPage2.Controls.Add(this.txtbUserName);
            this.tabPage2.Controls.Add(this.lblUserIDT);
            this.tabPage2.Controls.Add(this.lblConfirmPassword);
            this.tabPage2.Controls.Add(this.lblUserPassword);
            this.tabPage2.Controls.Add(this.lblUserName);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1112, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chbIsActive
            // 
            this.chbIsActive.AutoSize = true;
            this.chbIsActive.Location = new System.Drawing.Point(178, 205);
            this.chbIsActive.Name = "chbIsActive";
            this.chbIsActive.Size = new System.Drawing.Size(81, 21);
            this.chbIsActive.TabIndex = 8;
            this.chbIsActive.Text = "Is Active";
            this.chbIsActive.UseVisualStyleBackColor = true;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(184, 48);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(29, 17);
            this.lblUserID.TabIndex = 7;
            this.lblUserID.Text = "???";
            // 
            // txtbConfirmPassword
            // 
            this.txtbConfirmPassword.Location = new System.Drawing.Point(178, 155);
            this.txtbConfirmPassword.Name = "txtbConfirmPassword";
            this.txtbConfirmPassword.Size = new System.Drawing.Size(206, 24);
            this.txtbConfirmPassword.TabIndex = 6;
            this.txtbConfirmPassword.UseSystemPasswordChar = true;
            this.txtbConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtbConfirmPassword_Validating);
            // 
            // txtbPassword
            // 
            this.txtbPassword.Location = new System.Drawing.Point(178, 120);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.Size = new System.Drawing.Size(206, 24);
            this.txtbPassword.TabIndex = 5;
            this.txtbPassword.UseSystemPasswordChar = true;
            this.txtbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtbPassword_Validating);
            // 
            // txtbUserName
            // 
            this.txtbUserName.Location = new System.Drawing.Point(178, 85);
            this.txtbUserName.Name = "txtbUserName";
            this.txtbUserName.Size = new System.Drawing.Size(206, 24);
            this.txtbUserName.TabIndex = 4;
            this.txtbUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtbUserName_Validating);
            // 
            // lblUserIDT
            // 
            this.lblUserIDT.AutoSize = true;
            this.lblUserIDT.Location = new System.Drawing.Point(40, 48);
            this.lblUserIDT.Name = "lblUserIDT";
            this.lblUserIDT.Size = new System.Drawing.Size(62, 17);
            this.lblUserIDT.TabIndex = 3;
            this.lblUserIDT.Text = "User ID :";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(40, 155);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(127, 17);
            this.lblConfirmPassword.TabIndex = 2;
            this.lblConfirmPassword.Text = "Confirm Password :";
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Location = new System.Drawing.Point(40, 120);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(106, 17);
            this.lblUserPassword.TabIndex = 1;
            this.lblUserPassword.Text = "User Password :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(40, 85);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(79, 17);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name:";
            this.lblUserName.Click += new System.EventHandler(this.lblUserName_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(497, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(281, 45);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Add New User";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1067, 560);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 44);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(926, 560);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 44);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1261, 638);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.Tab1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditUser";
            this.Text = "Add/Edit User";
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            this.Tab1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Tab1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbFindBy;
        private System.Windows.Forms.Label lblFindByT;
        private ctrlPersonDetials ctrlPersonDetials1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtbFindBy;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.CheckBox chbIsActive;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtbConfirmPassword;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.TextBox txtbUserName;
        private System.Windows.Forms.Label lblUserIDT;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEditPersonInfo;
    }
}