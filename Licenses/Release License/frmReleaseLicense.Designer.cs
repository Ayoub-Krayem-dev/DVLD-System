namespace DVLD
{
    partial class frmReleaseLicense
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
            this.ctrlReleaseLicense1 = new DVLD.ctrlReleaseLicense();
            this.SuspendLayout();
            // 
            // ctrlReleaseLicense1
            // 
            this.ctrlReleaseLicense1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlReleaseLicense1.Location = new System.Drawing.Point(12, 2);
            this.ctrlReleaseLicense1.Name = "ctrlReleaseLicense1";
            this.ctrlReleaseLicense1.Size = new System.Drawing.Size(727, 843);
            this.ctrlReleaseLicense1.TabIndex = 0;
            this.ctrlReleaseLicense1.Load += new System.EventHandler(this.ctrlReleaseLicense1_Load_1);
            // 
            // frmReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(742, 857);
            this.Controls.Add(this.ctrlReleaseLicense1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReleaseLicense";
            this.Text = "Release License";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlReleaseLicense ctrlReleaseLicense1;
    }
}