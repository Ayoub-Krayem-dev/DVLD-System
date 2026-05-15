using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using BuisnessAccessLayer2;

namespace DVLD
{
    public partial class frmShowLicenseHistory : Form
    {
        public frmShowLicenseHistory()
        {
            InitializeComponent();
        }

        public frmShowLicenseHistory(int ID)
        {
            InitializeComponent();

            _PersonID = ID;
            ctrlPersonDetials1.LoadCtrl(_PersonID);
        }
        private int _PersonID { get; set; }
        private void ctrlPersonDetials1_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _Refresh()
        {
            tabPage1.Text = "International License";
            tabPage2.Text = "Local License";
            dgvLicenseHistory.DataSource = clsBuisnessLicense.GetLicenseHistory(_PersonID);
            dgvLicenseHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLicenseHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInternationalLicenseList.DataSource = clsBuisnessInternationalLicense.GetLicenseHistory(_PersonID);
            dgvInternationalLicenseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvInternationalLicenseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void frmShowLicenseHistory_Load(object sender, EventArgs e)
        {

        }

        private void lblEditPerson_Click(object sender, EventArgs e)
        {

            frmAddNew frmAddNew = new frmAddNew(_PersonID);
            frmAddNew.ShowDialog();
            this.Close();
        }

        private void dgvLicenseHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseDetails frmShowLicenseDetails = new frmShowLicenseDetails((int)dgvLicenseHistory.CurrentRow.Cells[0].Value);
            frmShowLicenseDetails.ShowDialog();
        }

        private void showInternationalLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseDetails frmInternationalLicenseDetails = new frmInternationalLicenseDetails((int)dgvInternationalLicenseList.CurrentRow.Cells[0].Value);
            frmInternationalLicenseDetails.ShowDialog();
        }
    }

}
