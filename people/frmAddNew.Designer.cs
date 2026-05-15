namespace DVLD
{
    partial class frmAddNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNew));
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlPeopleManage1 = new DVLD.ctrlPeopleManage();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(317, 384);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 48);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlPeopleManage1
            // 
            this.ctrlPeopleManage1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlPeopleManage1.Location = new System.Drawing.Point(12, 20);
            this.ctrlPeopleManage1.Name = "ctrlPeopleManage1";
            this.ctrlPeopleManage1.Size = new System.Drawing.Size(1020, 494);
            this.ctrlPeopleManage1.TabIndex = 0;
            this.ctrlPeopleManage1.Load += new System.EventHandler(this.ctrlPeopleManage1_Load);
            // 
            // frmAddNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1036, 526);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlPeopleManage1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNew";
            this.Text = "Add/Edit Person";
            this.Load += new System.EventHandler(this.frmAddNew_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPeopleManage ctrlPeopleManage1;
        private System.Windows.Forms.Button btnClose;
    }
}