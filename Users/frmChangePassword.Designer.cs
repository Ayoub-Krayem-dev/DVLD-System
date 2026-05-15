namespace DVLD
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.ctrlPersonDetials1 = new DVLD.ctrlPersonDetials();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.lblIsActiveT = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserNameT = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUserIDT = new System.Windows.Forms.Label();
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblConfirmNewPassword = new System.Windows.Forms.Label();
            this.txtbCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtbNewPassword = new System.Windows.Forms.TextBox();
            this.txtbConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPersonDetials1
            // 
            this.ctrlPersonDetials1.Location = new System.Drawing.Point(12, 12);
            this.ctrlPersonDetials1.Name = "ctrlPersonDetials1";
            this.ctrlPersonDetials1.Size = new System.Drawing.Size(974, 392);
            this.ctrlPersonDetials1.TabIndex = 0;
            this.ctrlPersonDetials1.Load += new System.EventHandler(this.ctrlPersonDetials1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblIsActive);
            this.groupBox1.Controls.Add(this.lblIsActiveT);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.lblUserNameT);
            this.groupBox1.Controls.Add(this.lblUserID);
            this.groupBox1.Controls.Add(this.lblUserIDT);
            this.groupBox1.Location = new System.Drawing.Point(12, 379);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Info";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(676, 43);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(29, 17);
            this.lblIsActive.TabIndex = 5;
            this.lblIsActive.Text = "???";
            // 
            // lblIsActiveT
            // 
            this.lblIsActiveT.AutoSize = true;
            this.lblIsActiveT.Location = new System.Drawing.Point(602, 43);
            this.lblIsActiveT.Name = "lblIsActiveT";
            this.lblIsActiveT.Size = new System.Drawing.Size(68, 17);
            this.lblIsActiveT.TabIndex = 4;
            this.lblIsActiveT.Text = "Is Active :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(443, 43);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(29, 17);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "???";
            // 
            // lblUserNameT
            // 
            this.lblUserNameT.AutoSize = true;
            this.lblUserNameT.Location = new System.Drawing.Point(306, 43);
            this.lblUserNameT.Name = "lblUserNameT";
            this.lblUserNameT.Size = new System.Drawing.Size(79, 17);
            this.lblUserNameT.TabIndex = 2;
            this.lblUserNameT.Text = "User Name:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(112, 43);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(29, 17);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "???";
            // 
            // lblUserIDT
            // 
            this.lblUserIDT.AutoSize = true;
            this.lblUserIDT.Location = new System.Drawing.Point(6, 43);
            this.lblUserIDT.Name = "lblUserIDT";
            this.lblUserIDT.Size = new System.Drawing.Size(58, 17);
            this.lblUserIDT.TabIndex = 0;
            this.lblUserIDT.Text = "User ID:";
            this.lblUserIDT.Click += new System.EventHandler(this.lblUserIDT_Click);
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Location = new System.Drawing.Point(24, 498);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(126, 17);
            this.lblCurrentPassword.TabIndex = 2;
            this.lblCurrentPassword.Text = "Current Password: ";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(24, 545);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(101, 17);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "New Password:";
            this.lblNewPassword.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblConfirmNewPassword
            // 
            this.lblConfirmNewPassword.AutoSize = true;
            this.lblConfirmNewPassword.Location = new System.Drawing.Point(24, 592);
            this.lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            this.lblConfirmNewPassword.Size = new System.Drawing.Size(153, 17);
            this.lblConfirmNewPassword.TabIndex = 4;
            this.lblConfirmNewPassword.Text = "Confirm New Password:";
            this.lblConfirmNewPassword.Click += new System.EventHandler(this.lblConfirmNewPassword_Click);
            // 
            // txtbCurrentPassword
            // 
            this.txtbCurrentPassword.Location = new System.Drawing.Point(209, 498);
            this.txtbCurrentPassword.Name = "txtbCurrentPassword";
            this.txtbCurrentPassword.Size = new System.Drawing.Size(188, 24);
            this.txtbCurrentPassword.TabIndex = 5;
            this.txtbCurrentPassword.UseSystemPasswordChar = true;
            this.txtbCurrentPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtbCurrentPassword_Validating);
            // 
            // txtbNewPassword
            // 
            this.txtbNewPassword.Location = new System.Drawing.Point(209, 545);
            this.txtbNewPassword.Name = "txtbNewPassword";
            this.txtbNewPassword.Size = new System.Drawing.Size(188, 24);
            this.txtbNewPassword.TabIndex = 6;
            this.txtbNewPassword.UseSystemPasswordChar = true;
            this.txtbNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtbNewPassword_Validating);
            // 
            // txtbConfirmNewPassword
            // 
            this.txtbConfirmNewPassword.Location = new System.Drawing.Point(209, 589);
            this.txtbConfirmNewPassword.Name = "txtbConfirmNewPassword";
            this.txtbConfirmNewPassword.Size = new System.Drawing.Size(188, 24);
            this.txtbConfirmNewPassword.TabIndex = 7;
            this.txtbConfirmNewPassword.UseSystemPasswordChar = true;
            this.txtbConfirmNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtbConfirmNewPassword_Validating);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(590, 578);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 45);
            this.button1.TabIndex = 8;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(768, 578);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 45);
            this.button2.TabIndex = 9;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(956, 636);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtbConfirmNewPassword);
            this.Controls.Add(this.txtbNewPassword);
            this.Controls.Add(this.txtbCurrentPassword);
            this.Controls.Add(this.lblConfirmNewPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblCurrentPassword);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlPersonDetials1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonDetials ctrlPersonDetials1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblUserIDT;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblIsActiveT;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserNameT;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblConfirmNewPassword;
        private System.Windows.Forms.TextBox txtbCurrentPassword;
        private System.Windows.Forms.TextBox txtbNewPassword;
        private System.Windows.Forms.TextBox txtbConfirmNewPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}