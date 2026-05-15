namespace DVLD
{
    partial class frmShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowDetails));
            this.ctrlPersonDetials1 = new DVLD.ctrlPersonDetials();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.lblIsActiveT = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUserIDT = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserNameT = new System.Windows.Forms.Label();
            this.lblEditPersonInfo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonDetials1
            // 
            this.ctrlPersonDetials1.Location = new System.Drawing.Point(2, 12);
            this.ctrlPersonDetials1.Name = "ctrlPersonDetials1";
            this.ctrlPersonDetials1.Size = new System.Drawing.Size(919, 362);
            this.ctrlPersonDetials1.TabIndex = 0;
            this.ctrlPersonDetials1.Load += new System.EventHandler(this.ctrlPersonDetials1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblIsActive);
            this.groupBox1.Controls.Add(this.lblIsActiveT);
            this.groupBox1.Controls.Add(this.lblUserID);
            this.groupBox1.Controls.Add(this.lblUserIDT);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.lblUserNameT);
            this.groupBox1.Location = new System.Drawing.Point(2, 371);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(908, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Info";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(757, 45);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(33, 17);
            this.lblIsActive.TabIndex = 5;
            this.lblIsActive.Text = " ???";
            // 
            // lblIsActiveT
            // 
            this.lblIsActiveT.AutoSize = true;
            this.lblIsActiveT.Location = new System.Drawing.Point(675, 45);
            this.lblIsActiveT.Name = "lblIsActiveT";
            this.lblIsActiveT.Size = new System.Drawing.Size(64, 17);
            this.lblIsActiveT.TabIndex = 4;
            this.lblIsActiveT.Text = "Is Active:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(421, 45);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(29, 17);
            this.lblUserID.TabIndex = 3;
            this.lblUserID.Text = "???";
            // 
            // lblUserIDT
            // 
            this.lblUserIDT.AutoSize = true;
            this.lblUserIDT.Location = new System.Drawing.Point(348, 45);
            this.lblUserIDT.Name = "lblUserIDT";
            this.lblUserIDT.Size = new System.Drawing.Size(58, 17);
            this.lblUserIDT.TabIndex = 2;
            this.lblUserIDT.Text = "User ID:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(131, 45);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(29, 17);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "???";
            // 
            // lblUserNameT
            // 
            this.lblUserNameT.AutoSize = true;
            this.lblUserNameT.Location = new System.Drawing.Point(25, 45);
            this.lblUserNameT.Name = "lblUserNameT";
            this.lblUserNameT.Size = new System.Drawing.Size(79, 17);
            this.lblUserNameT.TabIndex = 0;
            this.lblUserNameT.Text = "User Name:";
            // 
            // lblEditPersonInfo
            // 
            this.lblEditPersonInfo.AutoSize = true;
            this.lblEditPersonInfo.Font = new System.Drawing.Font("Tahoma", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditPersonInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblEditPersonInfo.Location = new System.Drawing.Point(640, 332);
            this.lblEditPersonInfo.Name = "lblEditPersonInfo";
            this.lblEditPersonInfo.Size = new System.Drawing.Size(118, 16);
            this.lblEditPersonInfo.TabIndex = 2;
            this.lblEditPersonInfo.Text = "Edit _Person Info";
            this.lblEditPersonInfo.Click += new System.EventHandler(this.lblEditPersonInfo_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 45);
            this.button1.TabIndex = 9;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(919, 480);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblEditPersonInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlPersonDetials1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowDetails";
            this.Text = "User Details";
            this.Load += new System.EventHandler(this.frmShowDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonDetials ctrlPersonDetials1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblIsActiveT;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblUserIDT;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserNameT;
        private System.Windows.Forms.Label lblEditPersonInfo;
        private System.Windows.Forms.Button button1;
    }
}