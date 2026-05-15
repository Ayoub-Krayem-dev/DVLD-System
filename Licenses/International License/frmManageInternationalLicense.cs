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
    public partial class frmManageInternationalLicense : Form
    {
        public frmManageInternationalLicense()
        {
            InitializeComponent();
        }

        private DataTable _InternationalLicenseDatatable;
        private void _Refresh()
        {
            cbFilterBy.SelectedItem = "None";
            _InternationalLicenseDatatable = clsBuisnessInternationalLicense.GetAllInternationalLicense();
            dgvInternationalLicenseList.DataSource = _InternationalLicenseDatatable;
            dgvInternationalLicenseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvInternationalLicenseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lblRecordCount.Text = _InternationalLicenseDatatable.Rows.Count.ToString();
        }
        private void frmManageInternationalLicense_Load(object sender, EventArgs e)
        {
            cbFilterBy.Items.Add("DriverID");
            cbFilterBy.Items.Add("LicenseID");
            cbFilterBy.Items.Add("InternationalLicenseID");
            cbFilterBy.Items.Add("ApplicationID");
            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("IsActive");

            _Refresh();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frmAddNewInternationalLicense = new frmAddNewInternationalLicense();
            frmAddNewInternationalLicense.ShowDialog();
            _Refresh();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                frmInternationalLicenseDetails frmInternationalLicenseDetails = new frmInternationalLicenseDetails((int)dgvInternationalLicenseList.CurrentRow.Cells[0].Value);
                frmInternationalLicenseDetails.ShowDialog();
            

              
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

            clsBuisnessApplication App = clsBuisnessApplication.Find((int)dgvInternationalLicenseList.CurrentRow.Cells[1].Value);
            if (App != null)
            {
                frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(App.ApplicationPersonID);
                frmShowLicenseHistory.ShowDialog();
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBuisnessApplication App = clsBuisnessApplication.Find((int)dgvInternationalLicenseList.CurrentRow.Cells[1].Value);
            if (App != null)
            {
                frmPersonDetails frmPersonDetails = new frmPersonDetails(App.ApplicationPersonID);
                frmPersonDetails.ShowDialog();
            }
        }

        private void txtbFilterBy_TextChanged(object sender, EventArgs e)
        {
            int ID = -1;
      
            if (cbFilterBy.SelectedItem.ToString() == "DriverID")
            {

                if (int.TryParse(txtbFilterBy.Text, out int DriverID))
                {
                    ID = DriverID;
                    dgvInternationalLicenseList.DataSource = clsBuisnessInternationalLicense.FilterByInt("DriverID", ID);

                }
            }
            else if(cbFilterBy.SelectedItem.ToString() == "ApplicationID")
            {

                if (int.TryParse(txtbFilterBy.Text, out int ApplicationID))
                {
                    ID = ApplicationID;
                    dgvInternationalLicenseList.DataSource = clsBuisnessInternationalLicense.FilterByInt("ApplicationID", ID);

                }
            }

            else if (cbFilterBy.SelectedItem.ToString() == "LicenseID")
            {

                if (int.TryParse(txtbFilterBy.Text, out int LicenseID))
                {
                    ID = LicenseID;
                    dgvInternationalLicenseList.DataSource = clsBuisnessInternationalLicense.FilterByInt("IssuedUsingLocalLicenseID", ID);

                }
            }

            else if (cbFilterBy.SelectedItem.ToString() == "InternationalLicenseID")
            {

                if (int.TryParse(txtbFilterBy.Text, out int InternationalLicenseID))
                {
                    ID = InternationalLicenseID;
                    dgvInternationalLicenseList.DataSource = clsBuisnessInternationalLicense.FilterByInt("InternationalLicenseID", ID);

                }
            }

            else if (cbFilterBy.SelectedItem.ToString() == "None")
            {
               
                    txtbFilterBy.Enabled = false;
                    dgvInternationalLicenseList.DataSource = clsBuisnessInternationalLicense.GetAllInternationalLicense();

                
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedItem.ToString() == "None")
            {
                txtbFilterBy.Enabled = false;
                txtbFilterBy.Text = "";
            }
            else
            {
                txtbFilterBy.Enabled = true;
            }
            cbIsReleased.Visible = cbFilterBy.SelectedItem.ToString() == "IsActive";
            txtbFilterBy.Visible  = !cbIsReleased.Visible;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _InternationalLicenseDatatable.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _InternationalLicenseDatatable.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordCount.Text = _InternationalLicenseDatatable.Rows.Count.ToString();
        }

        private void txtbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
