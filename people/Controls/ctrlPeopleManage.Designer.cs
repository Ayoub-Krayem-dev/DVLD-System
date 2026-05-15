namespace DVLD
{
    partial class ctrlPeopleManage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlPeopleManage));
            this.lblTitleAddEditPerson = new System.Windows.Forms.Label();
            this.gbAddNewPerson = new System.Windows.Forms.GroupBox();
            this.lblRemoveImage = new System.Windows.Forms.Label();
            this.mtxtbEmail = new System.Windows.Forms.MaskedTextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSetImage = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.txtbAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtbPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.rdbFemale = new System.Windows.Forms.RadioButton();
            this.rdbMale = new System.Windows.Forms.RadioButton();
            this.lblGendor = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.txtbNationalNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.txtbLastName = new System.Windows.Forms.TextBox();
            this.txtbThirdName = new System.Windows.Forms.TextBox();
            this.txtbSecondName = new System.Windows.Forms.TextBox();
            this.txtbFirstName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblPersonIDtitle = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.gbAddNewPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleAddEditPerson
            // 
            this.lblTitleAddEditPerson.AutoSize = true;
            this.lblTitleAddEditPerson.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleAddEditPerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitleAddEditPerson.Location = new System.Drawing.Point(349, 14);
            this.lblTitleAddEditPerson.Name = "lblTitleAddEditPerson";
            this.lblTitleAddEditPerson.Size = new System.Drawing.Size(264, 34);
            this.lblTitleAddEditPerson.TabIndex = 1;
            this.lblTitleAddEditPerson.Text = "Add New _Person";
            // 
            // gbAddNewPerson
            // 
            this.gbAddNewPerson.Controls.Add(this.lblRemoveImage);
            this.gbAddNewPerson.Controls.Add(this.mtxtbEmail);
            this.gbAddNewPerson.Controls.Add(this.dtpDateOfBirth);
            this.gbAddNewPerson.Controls.Add(this.btnClose);
            this.gbAddNewPerson.Controls.Add(this.btnSave);
            this.gbAddNewPerson.Controls.Add(this.lblSetImage);
            this.gbAddNewPerson.Controls.Add(this.pbImage);
            this.gbAddNewPerson.Controls.Add(this.txtbAddress);
            this.gbAddNewPerson.Controls.Add(this.lblAddress);
            this.gbAddNewPerson.Controls.Add(this.cbCountry);
            this.gbAddNewPerson.Controls.Add(this.lblCountry);
            this.gbAddNewPerson.Controls.Add(this.txtbPhone);
            this.gbAddNewPerson.Controls.Add(this.lblPhone);
            this.gbAddNewPerson.Controls.Add(this.lblEmail);
            this.gbAddNewPerson.Controls.Add(this.rdbFemale);
            this.gbAddNewPerson.Controls.Add(this.rdbMale);
            this.gbAddNewPerson.Controls.Add(this.lblGendor);
            this.gbAddNewPerson.Controls.Add(this.lblDateOfBirth);
            this.gbAddNewPerson.Controls.Add(this.txtbNationalNo);
            this.gbAddNewPerson.Controls.Add(this.label4);
            this.gbAddNewPerson.Controls.Add(this.label3);
            this.gbAddNewPerson.Controls.Add(this.label2);
            this.gbAddNewPerson.Controls.Add(this.label1);
            this.gbAddNewPerson.Controls.Add(this.lblNationalNo);
            this.gbAddNewPerson.Controls.Add(this.txtbLastName);
            this.gbAddNewPerson.Controls.Add(this.txtbThirdName);
            this.gbAddNewPerson.Controls.Add(this.txtbSecondName);
            this.gbAddNewPerson.Controls.Add(this.txtbFirstName);
            this.gbAddNewPerson.Controls.Add(this.lblName);
            this.gbAddNewPerson.Location = new System.Drawing.Point(43, 66);
            this.gbAddNewPerson.Name = "gbAddNewPerson";
            this.gbAddNewPerson.Size = new System.Drawing.Size(898, 359);
            this.gbAddNewPerson.TabIndex = 2;
            this.gbAddNewPerson.TabStop = false;
            this.gbAddNewPerson.Enter += new System.EventHandler(this.gbAddNewPerson_Enter);
            // 
            // lblRemoveImage
            // 
            this.lblRemoveImage.AutoSize = true;
            this.lblRemoveImage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
            this.lblRemoveImage.ForeColor = System.Drawing.Color.Red;
            this.lblRemoveImage.Location = new System.Drawing.Point(751, 224);
            this.lblRemoveImage.Name = "lblRemoveImage";
            this.lblRemoveImage.Size = new System.Drawing.Size(97, 17);
            this.lblRemoveImage.TabIndex = 32;
            this.lblRemoveImage.Text = "RemoveImage";
            this.lblRemoveImage.Click += new System.EventHandler(this.lblRemoveImage_Click);
            // 
            // mtxtbEmail
            // 
            this.mtxtbEmail.Location = new System.Drawing.Point(155, 154);
            this.mtxtbEmail.Name = "mtxtbEmail";
            this.mtxtbEmail.Size = new System.Drawing.Size(158, 24);
            this.mtxtbEmail.TabIndex = 31;
            this.mtxtbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.mtxtbEmail_Validating);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(545, 76);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(159, 24);
            this.dtpDateOfBirth.TabIndex = 30;
            this.dtpDateOfBirth.ValueChanged += new System.EventHandler(this.dtpDateOfBirth_ValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(262, 297);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 49);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(410, 297);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 49);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSetImage
            // 
            this.lblSetImage.AutoSize = true;
            this.lblSetImage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
            this.lblSetImage.ForeColor = System.Drawing.Color.Blue;
            this.lblSetImage.Location = new System.Drawing.Point(751, 197);
            this.lblSetImage.Name = "lblSetImage";
            this.lblSetImage.Size = new System.Drawing.Size(66, 17);
            this.lblSetImage.TabIndex = 24;
            this.lblSetImage.Text = "SetImage";
            this.lblSetImage.Click += new System.EventHandler(this.lblSetImage_Click);
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Image = ((System.Drawing.Image)(resources.GetObject("pbImage.Image")));
            this.pbImage.Location = new System.Drawing.Point(754, 82);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(97, 100);
            this.pbImage.TabIndex = 23;
            this.pbImage.TabStop = false;
            // 
            // txtbAddress
            // 
            this.txtbAddress.Location = new System.Drawing.Point(155, 194);
            this.txtbAddress.Multiline = true;
            this.txtbAddress.Name = "txtbAddress";
            this.txtbAddress.Size = new System.Drawing.Size(508, 85);
            this.txtbAddress.TabIndex = 22;
            this.txtbAddress.Validating += new System.ComponentModel.CancelEventHandler(this.Validating_TextBox);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(6, 194);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(61, 17);
            this.lblAddress.TabIndex = 21;
            this.lblAddress.Text = "Address:";
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(545, 158);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(159, 24);
            this.cbCountry.TabIndex = 20;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(352, 161);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(64, 17);
            this.lblCountry.TabIndex = 19;
            this.lblCountry.Text = "Country:";
            // 
            // txtbPhone
            // 
            this.txtbPhone.Location = new System.Drawing.Point(545, 116);
            this.txtbPhone.MaxLength = 10;
            this.txtbPhone.Name = "txtbPhone";
            this.txtbPhone.Size = new System.Drawing.Size(158, 24);
            this.txtbPhone.TabIndex = 18;
            this.txtbPhone.Validating += new System.ComponentModel.CancelEventHandler(this.Validating_TextBox);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(352, 119);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(52, 17);
            this.lblPhone.TabIndex = 17;
            this.lblPhone.Text = "Phone:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 154);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 17);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email:";
            // 
            // rdbFemale
            // 
            this.rdbFemale.AutoSize = true;
            this.rdbFemale.Location = new System.Drawing.Point(224, 121);
            this.rdbFemale.Name = "rdbFemale";
            this.rdbFemale.Size = new System.Drawing.Size(71, 21);
            this.rdbFemale.TabIndex = 14;
            this.rdbFemale.TabStop = true;
            this.rdbFemale.Text = "Female";
            this.rdbFemale.UseVisualStyleBackColor = true;
            this.rdbFemale.CheckedChanged += new System.EventHandler(this.rdbFemale_CheckedChanged);
            // 
            // rdbMale
            // 
            this.rdbMale.AutoSize = true;
            this.rdbMale.Location = new System.Drawing.Point(155, 121);
            this.rdbMale.Name = "rdbMale";
            this.rdbMale.Size = new System.Drawing.Size(55, 21);
            this.rdbMale.TabIndex = 13;
            this.rdbMale.TabStop = true;
            this.rdbMale.Text = "Male";
            this.rdbMale.UseVisualStyleBackColor = true;
            this.rdbMale.CheckedChanged += new System.EventHandler(this.rdbMale_CheckedChanged);
            // 
            // lblGendor
            // 
            this.lblGendor.AutoSize = true;
            this.lblGendor.Location = new System.Drawing.Point(6, 116);
            this.lblGendor.Name = "lblGendor";
            this.lblGendor.Size = new System.Drawing.Size(58, 17);
            this.lblGendor.TabIndex = 12;
            this.lblGendor.Text = "Gendor:";
            this.lblGendor.Click += new System.EventHandler(this.lblGendor_Click);
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(350, 82);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(92, 17);
            this.lblDateOfBirth.TabIndex = 10;
            this.lblDateOfBirth.Text = "Date Of Birth:";
            // 
            // txtbNationalNo
            // 
            this.txtbNationalNo.Location = new System.Drawing.Point(155, 69);
            this.txtbNationalNo.Name = "txtbNationalNo";
            this.txtbNationalNo.Size = new System.Drawing.Size(158, 24);
            this.txtbNationalNo.TabIndex = 9;
            this.txtbNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtbNationalNo_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(731, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Last";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Third";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Second";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "First";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.Location = new System.Drawing.Point(6, 75);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(78, 17);
            this.lblNationalNo.TabIndex = 5;
            this.lblNationalNo.Text = "NationalNo:";
            // 
            // txtbLastName
            // 
            this.txtbLastName.Location = new System.Drawing.Point(734, 36);
            this.txtbLastName.Name = "txtbLastName";
            this.txtbLastName.Size = new System.Drawing.Size(158, 24);
            this.txtbLastName.TabIndex = 4;
            this.txtbLastName.TextChanged += new System.EventHandler(this.txtbLastName_TextChanged);
            this.txtbLastName.Validating += new System.ComponentModel.CancelEventHandler(this.Validating_TextBox);
            this.txtbLastName.Validated += new System.EventHandler(this.txtbLastName_Validated);
            // 
            // txtbThirdName
            // 
            this.txtbThirdName.Location = new System.Drawing.Point(545, 36);
            this.txtbThirdName.Name = "txtbThirdName";
            this.txtbThirdName.Size = new System.Drawing.Size(158, 24);
            this.txtbThirdName.TabIndex = 3;
            // 
            // txtbSecondName
            // 
            this.txtbSecondName.Location = new System.Drawing.Point(353, 36);
            this.txtbSecondName.Name = "txtbSecondName";
            this.txtbSecondName.Size = new System.Drawing.Size(158, 24);
            this.txtbSecondName.TabIndex = 2;
            this.txtbSecondName.TextChanged += new System.EventHandler(this.txtbLastName_TextChanged);
            this.txtbSecondName.Validating += new System.ComponentModel.CancelEventHandler(this.Validating_TextBox);
            // 
            // txtbFirstName
            // 
            this.txtbFirstName.Location = new System.Drawing.Point(155, 36);
            this.txtbFirstName.Name = "txtbFirstName";
            this.txtbFirstName.Size = new System.Drawing.Size(158, 24);
            this.txtbFirstName.TabIndex = 1;
            this.txtbFirstName.TextChanged += new System.EventHandler(this.txtbFirstName_TextChanged);
            this.txtbFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.Validating_TextBox);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 36);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "patient.png");
            this.imageList1.Images.SetKeyName(1, "patient_female (1).png");
            // 
            // lblPersonIDtitle
            // 
            this.lblPersonIDtitle.AutoSize = true;
            this.lblPersonIDtitle.Location = new System.Drawing.Point(49, 46);
            this.lblPersonIDtitle.Name = "lblPersonIDtitle";
            this.lblPersonIDtitle.Size = new System.Drawing.Size(73, 17);
            this.lblPersonIDtitle.TabIndex = 32;
            this.lblPersonIDtitle.Text = "Person ID:";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Location = new System.Drawing.Point(143, 46);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(30, 17);
            this.lblPersonID.TabIndex = 33;
            this.lblPersonID.Text = "N/A";
            // 
            // ctrlPeopleManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.lblPersonIDtitle);
            this.Controls.Add(this.gbAddNewPerson);
            this.Controls.Add(this.lblTitleAddEditPerson);
            this.Name = "ctrlPeopleManage";
            this.Size = new System.Drawing.Size(957, 441);
            this.Load += new System.EventHandler(this.ctrlPeopleManage_Load);
            this.gbAddNewPerson.ResumeLayout(false);
            this.gbAddNewPerson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitleAddEditPerson;
        private System.Windows.Forms.GroupBox gbAddNewPerson;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.TextBox txtbLastName;
        private System.Windows.Forms.TextBox txtbThirdName;
        private System.Windows.Forms.TextBox txtbSecondName;
        private System.Windows.Forms.TextBox txtbFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSetImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.TextBox txtbAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtbPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.RadioButton rdbFemale;
        private System.Windows.Forms.RadioButton rdbMale;
        private System.Windows.Forms.Label lblGendor;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.TextBox txtbNationalNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.MaskedTextBox mtxtbEmail;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblRemoveImage;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Label lblPersonIDtitle;
    }
}
