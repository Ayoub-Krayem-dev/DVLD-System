namespace DVLD
{
    partial class frmDetainLicense
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
            this.ctrlDetainLicense1 = new DVLD.ctrlDetainLicense();
            this.SuspendLayout();
            // 
            // ctrlDetainLicense1
            // 
            this.ctrlDetainLicense1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlDetainLicense1.Location = new System.Drawing.Point(12, 12);
            this.ctrlDetainLicense1.Name = "ctrlDetainLicense1";
            this.ctrlDetainLicense1.Size = new System.Drawing.Size(767, 811);
            this.ctrlDetainLicense1.TabIndex = 0;
            this.ctrlDetainLicense1.Load += new System.EventHandler(this.ctrlDetainLicense1_Load);
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(756, 858);
            this.Controls.Add(this.ctrlDetainLicense1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetainLicense";
            this.Text = "Detain License";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDetainLicense ctrlDetainLicense1;
    }
}