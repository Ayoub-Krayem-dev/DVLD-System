using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuisnessAccessLayer2;

namespace DVLD
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmManageDetainReleaseLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.Items.Add("NationalNo");
            cbFilterBy.Items.Add("FullName");
            cbFilterBy.Items.Add("DetainID");
            cbFilterBy.Items.Add("IsReleased");
            cbFilterBy.Items.Add("ReleaseApplicationID");
            cbFilterBy.Items.Add("None");


            cbIsReleased.Items.Add("Yes");
            cbIsReleased.Items.Add("No");
            cbIsReleased.Items.Add("All");
            txtbFilterBy.Visible = false;


            _Refresh();

        }

        private void _Refresh()
        {
            cbFilterBy.SelectedItem = "None";
            DataTable dt = clsBuisnessDetainedLicense.GetAllDetainedLicense();
            dgvDetainReleaseLicenseList.DataSource = dt;
            dgvDetainReleaseLicenseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDetainReleaseLicenseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lblRecordsNumbers.Text = dt.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBuisnessLicense License = clsBuisnessLicense.Find((int)dgvDetainReleaseLicenseList.CurrentRow.Cells[1].Value);
            if (License != null)
            {
                clsBuisnessDriver Driver =clsBuisnessDriver.FindByDriverID(License.DriverID);

                if(Driver != null)
                {
                    frmPersonDetails frmPersonDetails = new frmPersonDetails(Driver.PersonID);
                    frmPersonDetails.ShowDialog();
                    _Refresh();

                }


            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBuisnessLicense License = clsBuisnessLicense.Find((int)dgvDetainReleaseLicenseList.CurrentRow.Cells[1].Value);
            if (License != null)
            {
                clsBuisnessDriver Driver = clsBuisnessDriver.FindByDriverID(License.DriverID);

                if (Driver != null)
                {
                    frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(Driver.PersonID);
                    frmShowLicenseHistory.ShowDialog();
                    _Refresh();

                }


            }
            
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseDetails frmShowLicenseDetails = new frmShowLicenseDetails((int)dgvDetainReleaseLicenseList.CurrentRow.Cells[1].Value);
            frmShowLicenseDetails.ShowDialog();
            _Refresh();

        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frmReleaseLicense = new frmReleaseLicense((int)dgvDetainReleaseLicenseList.CurrentRow.Cells[1].Value);
            frmReleaseLicense.ShowDialog();
            _Refresh();
        }

        private void dgvDetainReleaseLicenseList_SelectionChanged(object sender, EventArgs e)
        {
            if (clsBuisnessDetainedLicense.IsDetained((int)dgvDetainReleaseLicenseList.CurrentRow.Cells[0].Value))
            {
                tsmreleaseDetainedLicense.Enabled = true;
            }
            else
            {
                tsmreleaseDetainedLicense.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDetainLicense = new frmDetainLicense();
            frmDetainLicense.ShowDialog();
            _Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frmReleaseLicense = new frmReleaseLicense();
            frmReleaseLicense.ShowDialog();
            _Refresh();

        }

        private void txtbFilterBy_TextChanged(object sender, EventArgs e)
        {
            int ID = -1;
                if (cbFilterBy.SelectedItem.ToString() == "DetainID")
            {
                if (int.TryParse(txtbFilterBy.Text, out int DetainID))
                {
                    ID = DetainID;
                    dgvDetainReleaseLicenseList.DataSource = clsBuisnessDetainedLicense.FilterByInt("DetainID", ID);

                }
            }
            else if (cbFilterBy.SelectedItem.ToString() == "ReleaseApplicationID")
            {
                if (int.TryParse(txtbFilterBy.Text, out int ReleasedApplicationID))
                {
                    ID = ReleasedApplicationID;
                    dgvDetainReleaseLicenseList.DataSource = clsBuisnessDetainedLicense.FilterByInt("ReleaseApplicationID", ID);

                }
            }
            else if (cbFilterBy.SelectedItem.ToString() == "FullName")
            {
                dgvDetainReleaseLicenseList.DataSource = clsBuisnessDetainedLicense.FilterByFullName("FullName", txtbFilterBy.Text);
            }
            else if (cbFilterBy.SelectedItem.ToString() == "NationalNo")
            {
                dgvDetainReleaseLicenseList.DataSource = clsBuisnessDetainedLicense.FilterByNationalNo("NationalNo", txtbFilterBy.Text);

            }
            else if (cbFilterBy.SelectedItem.ToString() == "None")

            {
                dgvDetainReleaseLicenseList.DataSource = clsBuisnessDetainedLicense.GetAllDetainedLicense();
            }

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "None")
            {
                txtbFilterBy.Visible = false;
                cbIsReleased.Visible = false;
            }
            

          
            else if (cbFilterBy.SelectedItem.ToString() == "IsReleased")
            {
                txtbFilterBy.Visible = false;

                cbIsReleased.Visible = true;
            }
            else
            {
                txtbFilterBy.Visible = true;

                cbIsReleased.Visible = false;
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsReleased.SelectedItem.ToString() == "Yes")
            {
                dgvDetainReleaseLicenseList.DataSource = clsBuisnessDetainedLicense.FilterByIsReleased(cbFilterBy.Text, true);
            }

            else if (cbIsReleased.SelectedItem.ToString() == "No")
            {
                dgvDetainReleaseLicenseList.DataSource = clsBuisnessDetainedLicense.FilterByIsReleased(cbFilterBy.Text, false);
            }

            else
            {
                dgvDetainReleaseLicenseList.DataSource = clsBuisnessDetainedLicense.GetAllDetainedLicense();

            }
        }
    }
}
