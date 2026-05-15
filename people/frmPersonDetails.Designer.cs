namespace DVLD
{
    partial class frmPersonDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonDetails));
            this.button1 = new System.Windows.Forms.Button();
            this.lblEditPersonInfo = new System.Windows.Forms.Label();
            this.ctrlPersonDetials1 = new DVLD.ctrlPersonDetials();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(32, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblEditPersonInfo
            // 
            this.lblEditPersonInfo.AutoSize = true;
            this.lblEditPersonInfo.Font = new System.Drawing.Font("Tahoma", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditPersonInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblEditPersonInfo.Location = new System.Drawing.Point(658, 288);
            this.lblEditPersonInfo.Name = "lblEditPersonInfo";
            this.lblEditPersonInfo.Size = new System.Drawing.Size(118, 16);
            this.lblEditPersonInfo.TabIndex = 1;
            this.lblEditPersonInfo.Text = "Edit _Person Info";
            this.lblEditPersonInfo.Click += new System.EventHandler(this.lblEditPersonInfo_Click);
            // 
            // ctrlPersonDetials1
            // 
            this.ctrlPersonDetials1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlPersonDetials1.Location = new System.Drawing.Point(12, 12);
            this.ctrlPersonDetials1.Name = "ctrlPersonDetials1";
            this.ctrlPersonDetials1.Size = new System.Drawing.Size(909, 362);
            this.ctrlPersonDetials1.TabIndex = 0;
            this.ctrlPersonDetials1.Load += new System.EventHandler(this.ctrlPersonDetials1_Load);
            // 
            // frmPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(943, 374);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblEditPersonInfo);
            this.Controls.Add(this.ctrlPersonDetials1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonDetails";
            this.Text = "Person Details";
            this.Load += new System.EventHandler(this.frmPersonDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonDetials ctrlPersonDetials1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblEditPersonInfo;
    }
}