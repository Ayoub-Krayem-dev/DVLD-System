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
    public partial class ctrlDetainLicense : UserControl
    {
        public ctrlDetainLicense()
        {
            InitializeComponent();
        }

        private clsBuisnessLicense _License { get; set; }

        private int _LicenseID { get; set; }

        private clsBuisnessApplication _App { get; set; }
        private void LoadCtrl()
        {
            // _InternationalLicense = clsBuisnessLicense.FindByPersonID(_InternationalLicenseID);

            if (_License != null)
            {
                lbLicenseID2.Text = _License.LicenseID.ToString();

                lblIsDetained.Text = clsBuisnessDetainedLicense.IsDetainedByLicense(_LicenseID) == true ? "Yes" : "No";
                clsBuisnessLicenseClasses LicenseClass = clsBuisnessLicenseClasses.Find(_License.LicenseClassID);
                lblLicenseID.Text = _License.LicenseID.ToString();
                lblIssueDate.Text = _License.IssueDate.ToString();

                lblIssueReason.Text = _License.IssueReason == 1 ? "First Time" :
                    _License.IssueReason == 2 ? "Renew" : _License.IssueReason == 3 ? "Replacement for Damaged" : "Replacement for Lost";


                lblNotes.Text = _License.Notes.ToString();
                if (LicenseClass != null)
                {
                    lblClassLicense.Text = LicenseClass.ClassName.ToString();

                    lblExpirationDate.Text = _License.IssueDate.AddYears(LicenseClass.DefaultValidityLength).ToString();


                }

                lblIsActive.Text = _License.IsActive == true ? "Yes" : "No";

                lblDriverID.Text = _License.DriverID.ToString();

                _App = clsBuisnessApplication.Find(_License.ApplicationID);

                if (_App != null)
                {
                    clsBuisnessPerson Person = clsBuisnessPerson.Find(_App.ApplicationPersonID);
                    if (Person != null)
                    {
                        lblName.Text = Person.GetFullName();
                        lblDateOfBirth.Text = Person.DateOfBirth.ToString();
                        lblNationalNo.Text = Person.NationalNo.ToString();
                        lblGender.Text = Person.Gendor == 1 ? "Female" : "Male";

                    }


                }
            }
        }

        private void ctrlDetainLicense_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            lblShowLIcenseHisroty.Enabled = false;
            lblShowLIcenseInfo.Enabled = false;
            if (frmDVLD.User != null) lblCreatedByUser.Text = frmDVLD.User.UserName.ToString();
            lblDetainDate.Text = DateTime.Now.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                return;
            }
            if (_License.IsActive == false)
            {
                MessageBox.Show("Local License Must be Active", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           

        
            


                clsBuisnessDetainedLicense DetainedLicense = new clsBuisnessDetainedLicense();
                DetainedLicense.LicneseID = _License.LicenseID;
                DetainedLicense.IsRealesed = false;
                DetainedLicense.DetainDate = DateTime.Now;
                DetainedLicense.FineFees = Convert.ToDecimal(txtbFineFees.Text);
                DetainedLicense.CreatedByUserID = frmDVLD.User.UserID;

                if (DetainedLicense.AddNewDetainApplication())
                {
                    lblDetainAppID.Text = DetainedLicense.DetainID.ToString();
                    btnSave.Enabled = false;
                   
                    MessageBox.Show(" License Detained Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblShowLIcenseInfo.Enabled = true;


                }


            }
          
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtbFindLicense.Text, out int LicenseID))
            {

                _LicenseID = LicenseID;
                _License = clsBuisnessLicense.Find(_LicenseID);

                if (_License != null)
                {
                    if (_License.IsActive == false)
                    {
                        MessageBox.Show("License is not Active !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnSave.Enabled = false;
                        LoadCtrl();



                    }
                    else
                    {
                        if (clsBuisnessDetainedLicense.IsDetainedByLicense(_LicenseID))
                        {
                            MessageBox.Show("License is Already Detained !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LoadCtrl();
                            lblShowLIcenseHisroty.Enabled = true;
                            btnSave.Enabled = false;

                        }
                        else
                        {
                            btnSave.Enabled = true;
                            LoadCtrl();
                            lblShowLIcenseHisroty.Enabled = true;

                        }
                    }
                   
                 

                }

            }
        }
        private clsBuisnessInternationalLicense _internationalLicense { get; set; }

        private void lblShowLIcenseHisroty_Click(object sender, EventArgs e)
        {

            clsBuisnessApplication app = clsBuisnessApplication.Find(_License.ApplicationID);
            if (app != null)
            {
                frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(app.ApplicationPersonID);
                frmShowLicenseHistory.ShowDialog();
            }

        }

        private void lblShowLIcenseInfo_Click(object sender, EventArgs e)
        {
            frmShowLicenseDetails frmShowLicenseDetails = new frmShowLicenseDetails(_License.LicenseID);
            frmShowLicenseDetails.ShowDialog();
        }

        private void txtbFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbFineFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbFineFees, null);

            };

            if (!clsValidation.IsNumber(txtbFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbFineFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtbFineFees, null);
            };

        }

        private void txtbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

            
        }
    }
}
