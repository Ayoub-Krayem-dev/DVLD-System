namespace DVLD
{
    partial class frmIssueLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIssueLicense));
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtbNotes = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlApplicationDetails1 = new DVLD.ctrlApplicationDetails();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLicenseClassFees = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(36, 408);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(48, 17);
            this.lblNotes.TabIndex = 1;
            this.lblNotes.Text = "Notes:";
            // 
            // txtbNotes
            // 
            this.txtbNotes.Location = new System.Drawing.Point(108, 408);
            this.txtbNotes.Multiline = true;
            this.txtbNotes.Name = "txtbNotes";
            this.txtbNotes.Size = new System.Drawing.Size(442, 116);
            this.txtbNotes.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(579, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(159, 44);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(756, 512);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 43);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlApplicationDetails1
            // 
            this.ctrlApplicationDetails1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlApplicationDetails1.Location = new System.Drawing.Point(12, 12);
            this.ctrlApplicationDetails1.Name = "ctrlApplicationDetails1";
            this.ctrlApplicationDetails1.Size = new System.Drawing.Size(919, 348);
            this.ctrlApplicationDetails1.TabIndex = 0;
            this.ctrlApplicationDetails1.Load += new System.EventHandler(this.ctrlApplicationDetails1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "License Class Fees:";
            // 
            // lblLicenseClassFees
            // 
            this.lblLicenseClassFees.AutoSize = true;
            this.lblLicenseClassFees.Location = new System.Drawing.Point(164, 363);
            this.lblLicenseClassFees.Name = "lblLicenseClassFees";
            this.lblLicenseClassFees.Size = new System.Drawing.Size(29, 17);
            this.lblLicenseClassFees.TabIndex = 32;
            this.lblLicenseClassFees.Text = "???";
            // 
            // frmIssueLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(938, 567);
            this.Controls.Add(this.lblLicenseClassFees);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtbNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.ctrlApplicationDetails1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIssueLicense";
            this.Text = "Issue License";
            this.Load += new System.EventHandler(this.frmIssueLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlApplicationDetails ctrlApplicationDetails1;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtbNotes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLicenseClassFees;
    }
}