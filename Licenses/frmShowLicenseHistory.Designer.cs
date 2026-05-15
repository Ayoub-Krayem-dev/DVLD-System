namespace DVLD
{
    partial class frmShowLicenseHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowLicenseHistory));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvLicenseHistory = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvInternationalLicenseList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInternationalLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEditPerson = new System.Windows.Forms.Label();
            this.ctrlPersonDetials1 = new DVLD.ctrlPersonDetials();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseHistory)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseList)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 378);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(915, 264);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvLicenseHistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(907, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvLicenseHistory
            // 
            this.dgvLicenseHistory.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicenseHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLicenseHistory.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvLicenseHistory.Location = new System.Drawing.Point(6, 6);
            this.dgvLicenseHistory.Name = "dgvLicenseHistory";
            this.dgvLicenseHistory.RowHeadersWidth = 51;
            this.dgvLicenseHistory.RowTemplate.Height = 26;
            this.dgvLicenseHistory.Size = new System.Drawing.Size(895, 223);
            this.dgvLicenseHistory.TabIndex = 0;
            this.dgvLicenseHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLicenseHistory_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(233, 42);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseDetailsToolStripMenuItem.Image")));
            this.showLicenseDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(232, 38);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvInternationalLicenseList);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(907, 235);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvInternationalLicenseList
            // 
            this.dgvInternationalLicenseList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvInternationalLicenseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenseList.ContextMenuStrip = this.contextMenuStrip2;
            this.dgvInternationalLicenseList.Location = new System.Drawing.Point(3, 6);
            this.dgvInternationalLicenseList.Name = "dgvInternationalLicenseList";
            this.dgvInternationalLicenseList.RowHeadersWidth = 51;
            this.dgvInternationalLicenseList.RowTemplate.Height = 26;
            this.dgvInternationalLicenseList.Size = new System.Drawing.Size(898, 219);
            this.dgvInternationalLicenseList.TabIndex = 0;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInternationalLicenseDetailsToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(321, 42);
            // 
            // showInternationalLicenseDetailsToolStripMenuItem
            // 
            this.showInternationalLicenseDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showInternationalLicenseDetailsToolStripMenuItem.Image")));
            this.showInternationalLicenseDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showInternationalLicenseDetailsToolStripMenuItem.Name = "showInternationalLicenseDetailsToolStripMenuItem";
            this.showInternationalLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(320, 38);
            this.showInternationalLicenseDetailsToolStripMenuItem.Text = "Show International License Details";
            this.showInternationalLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showInternationalLicenseDetailsToolStripMenuItem_Click);
            // 
            // lblEditPerson
            // 
            this.lblEditPerson.AutoSize = true;
            this.lblEditPerson.Font = new System.Drawing.Font("Tahoma", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditPerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblEditPerson.Location = new System.Drawing.Point(660, 295);
            this.lblEditPerson.Name = "lblEditPerson";
            this.lblEditPerson.Size = new System.Drawing.Size(110, 16);
            this.lblEditPerson.TabIndex = 2;
            this.lblEditPerson.Text = "Edit Person Info";
            this.lblEditPerson.Click += new System.EventHandler(this.lblEditPerson_Click);
            // 
            // ctrlPersonDetials1
            // 
            this.ctrlPersonDetials1.Location = new System.Drawing.Point(12, 12);
            this.ctrlPersonDetials1.Name = "ctrlPersonDetials1";
            this.ctrlPersonDetials1.Size = new System.Drawing.Size(915, 360);
            this.ctrlPersonDetials1.TabIndex = 0;
            this.ctrlPersonDetials1.Load += new System.EventHandler(this.ctrlPersonDetials1_Load);
            // 
            // frmShowLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(937, 654);
            this.Controls.Add(this.lblEditPerson);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ctrlPersonDetials1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowLicenseHistory";
            this.Text = "Show License History";
            this.Load += new System.EventHandler(this.frmShowLicenseHistory_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseHistory)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseList)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonDetials ctrlPersonDetials1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblEditPerson;
        private System.Windows.Forms.DataGridView dgvInternationalLicenseList;
        private System.Windows.Forms.DataGridView dgvLicenseHistory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem showInternationalLicenseDetailsToolStripMenuItem;
    }
}