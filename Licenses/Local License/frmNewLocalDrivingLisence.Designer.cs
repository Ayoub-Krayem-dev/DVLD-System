namespace DVLD
{
    partial class frmNewLocalDrivingLisence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewLocalDrivingLisence));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblCreatedByUserIDT = new System.Windows.Forms.Label();
            this.lblAppID = new System.Windows.Forms.Label();
            this.lblAppIDT = new System.Windows.Forms.Label();
            this.lblAppFeesT = new System.Windows.Forms.Label();
            this.lblLicenseClassT = new System.Windows.Forms.Label();
            this.lblAppDateT = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblEditPersonInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.txtbFindBy = new System.Windows.Forms.TextBox();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.lblFindByT = new System.Windows.Forms.Label();
            this.Tab1 = new System.Windows.Forms.TabControl();
            this.button2 = new System.Windows.Forms.Button();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonDetials1 = new DVLD.ctrlPersonDetials();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Tab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(490, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(309, 36);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "New Diving License";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1069, 548);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(174, 48);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbLicenseClasses);
            this.tabPage2.Controls.Add(this.lblCreatedBy);
            this.tabPage2.Controls.Add(this.lblApplicationFees);
            this.tabPage2.Controls.Add(this.lblApplicationDate);
            this.tabPage2.Controls.Add(this.lblCreatedByUserIDT);
            this.tabPage2.Controls.Add(this.lblAppID);
            this.tabPage2.Controls.Add(this.lblAppIDT);
            this.tabPage2.Controls.Add(this.lblAppFeesT);
            this.tabPage2.Controls.Add(this.lblLicenseClassT);
            this.tabPage2.Controls.Add(this.lblAppDateT);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1112, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(187, 117);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(216, 24);
            this.cbLicenseClasses.TabIndex = 13;
            this.cbLicenseClasses.Validating += new System.ComponentModel.CancelEventHandler(this.cbLicenseClasses_Validating);
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(184, 195);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(29, 17);
            this.lblCreatedBy.TabIndex = 12;
            this.lblCreatedBy.Text = "???";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(184, 155);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(29, 17);
            this.lblApplicationFees.TabIndex = 11;
            this.lblApplicationFees.Text = "???";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Location = new System.Drawing.Point(184, 85);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(29, 17);
            this.lblApplicationDate.TabIndex = 9;
            this.lblApplicationDate.Text = "???";
            // 
            // lblCreatedByUserIDT
            // 
            this.lblCreatedByUserIDT.AutoSize = true;
            this.lblCreatedByUserIDT.Location = new System.Drawing.Point(40, 195);
            this.lblCreatedByUserIDT.Name = "lblCreatedByUserIDT";
            this.lblCreatedByUserIDT.Size = new System.Drawing.Size(81, 17);
            this.lblCreatedByUserIDT.TabIndex = 8;
            this.lblCreatedByUserIDT.Text = "Created By:";
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Location = new System.Drawing.Point(184, 48);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(29, 17);
            this.lblAppID.TabIndex = 7;
            this.lblAppID.Text = "???";
            // 
            // lblAppIDT
            // 
            this.lblAppIDT.AutoSize = true;
            this.lblAppIDT.Location = new System.Drawing.Point(24, 48);
            this.lblAppIDT.Name = "lblAppIDT";
            this.lblAppIDT.Size = new System.Drawing.Size(143, 17);
            this.lblAppIDT.TabIndex = 3;
            this.lblAppIDT.Text = "L . D . L Application ID";
            // 
            // lblAppFeesT
            // 
            this.lblAppFeesT.AutoSize = true;
            this.lblAppFeesT.Location = new System.Drawing.Point(40, 155);
            this.lblAppFeesT.Name = "lblAppFeesT";
            this.lblAppFeesT.Size = new System.Drawing.Size(109, 17);
            this.lblAppFeesT.TabIndex = 2;
            this.lblAppFeesT.Text = "Application Fees:";
            // 
            // lblLicenseClassT
            // 
            this.lblLicenseClassT.AutoSize = true;
            this.lblLicenseClassT.Location = new System.Drawing.Point(40, 120);
            this.lblLicenseClassT.Name = "lblLicenseClassT";
            this.lblLicenseClassT.Size = new System.Drawing.Size(95, 17);
            this.lblLicenseClassT.TabIndex = 1;
            this.lblLicenseClassT.Text = "License Class :";
            // 
            // lblAppDateT
            // 
            this.lblAppDateT.AutoSize = true;
            this.lblAppDateT.Location = new System.Drawing.Point(40, 85);
            this.lblAppDateT.Name = "lblAppDateT";
            this.lblAppDateT.Size = new System.Drawing.Size(111, 17);
            this.lblAppDateT.TabIndex = 0;
            this.lblAppDateT.Text = "Application Date:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblEditPersonInfo);
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.btnSearch);
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
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lblEditPersonInfo
            // 
            this.lblEditPersonInfo.AutoSize = true;
            this.lblEditPersonInfo.Font = new System.Drawing.Font("Tahoma", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditPersonInfo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblEditPersonInfo.Location = new System.Drawing.Point(741, 370);
            this.lblEditPersonInfo.Name = "lblEditPersonInfo";
            this.lblEditPersonInfo.Size = new System.Drawing.Size(110, 16);
            this.lblEditPersonInfo.TabIndex = 5;
            this.lblEditPersonInfo.Text = "Edit Person Info";
            this.lblEditPersonInfo.Click += new System.EventHandler(this.lblEditPersonInfo_Click_1);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(989, 379);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(117, 45);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(894, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 82);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackColor = System.Drawing.Color.White;
            this.btnAddNewPerson.FlatAppearance.BorderSize = 0;
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPerson.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewPerson.Image")));
            this.btnAddNewPerson.Location = new System.Drawing.Point(1003, 6);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(103, 82);
            this.btnAddNewPerson.TabIndex = 4;
            this.btnAddNewPerson.UseVisualStyleBackColor = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click_1);
            // 
            // txtbFindBy
            // 
            this.txtbFindBy.Location = new System.Drawing.Point(347, 50);
            this.txtbFindBy.Name = "txtbFindBy";
            this.txtbFindBy.Size = new System.Drawing.Size(181, 24);
            this.txtbFindBy.TabIndex = 3;
            this.txtbFindBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFindBy_KeyPress_1);
            this.txtbFindBy.Validating += new System.ComponentModel.CancelEventHandler(this.txtbFindBy_Validating);
            // 
            // cbFindBy
            // 
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Location = new System.Drawing.Point(163, 50);
            this.cbFindBy.Name = "cbFindBy";
            this.cbFindBy.Size = new System.Drawing.Size(167, 24);
            this.cbFindBy.TabIndex = 2;
            this.cbFindBy.SelectedIndexChanged += new System.EventHandler(this.cbFindBy_SelectedIndexChanged_1);
            // 
            // lblFindByT
            // 
            this.lblFindByT.AutoSize = true;
            this.lblFindByT.Location = new System.Drawing.Point(27, 53);
            this.lblFindByT.Name = "lblFindByT";
            this.lblFindByT.Size = new System.Drawing.Size(130, 17);
            this.lblFindByT.TabIndex = 1;
            this.lblFindByT.Text = "FindByPersonID By:";
            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.tabPage1);
            this.Tab1.Controls.Add(this.tabPage2);
            this.Tab1.Location = new System.Drawing.Point(98, 52);
            this.Tab1.Name = "Tab1";
            this.Tab1.SelectedIndex = 0;
            this.Tab1.Size = new System.Drawing.Size(1120, 492);
            this.Tab1.TabIndex = 2;
            this.Tab1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.Tab1_Selecting);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(878, 548);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 48);
            this.button2.TabIndex = 5;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // ctrlPersonDetials1
            // 
            this.ctrlPersonDetials1.Location = new System.Drawing.Point(30, 85);
            this.ctrlPersonDetials1.Name = "ctrlPersonDetials1";
            this.ctrlPersonDetials1.Size = new System.Drawing.Size(948, 372);
            this.ctrlPersonDetials1.TabIndex = 0;
            this.ctrlPersonDetials1.Load += new System.EventHandler(this.ctrlPersonDetials1_Load);
            // 
            // frmNewLocalDrivingLisence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1274, 610);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.Tab1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewLocalDrivingLisence";
            this.Text = "New Local Driving Lisence";
            this.Activated += new System.EventHandler(this.frmNewLocalDrivingLisence_Activated);
            this.Load += new System.EventHandler(this.frmNewLocalDrivingLisence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.Tab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl Tab1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblEditPersonInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.TextBox txtbFindBy;
        private System.Windows.Forms.ComboBox cbFindBy;
        private System.Windows.Forms.Label lblFindByT;
        private ctrlPersonDetials ctrlPersonDetials1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblCreatedByUserIDT;
        private System.Windows.Forms.Label lblAppID;
        private System.Windows.Forms.Label lblAppIDT;
        private System.Windows.Forms.Label lblAppFeesT;
        private System.Windows.Forms.Label lblLicenseClassT;
        private System.Windows.Forms.Label lblAppDateT;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}