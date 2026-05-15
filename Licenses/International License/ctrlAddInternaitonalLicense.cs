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
    public partial class ctrlAddInternaitonalLicense : UserControl
    {
        public ctrlAddInternaitonalLicense()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private clsBuisnessLicense _License { get; set; }

        private int _LicenseID { get; set; }

        private clsBuisnessApplication _App { get; set; }




        private void LoadCtrl()
        {
            // _InternationalLicense = clsBuisnessLicense.FindByPersonID(_InternationalLicenseID);
          
            if (_License != null)
            {
                lblIsDetained.Text = clsBuisnessDetainedLicense.IsDetained(_LicenseID) == true ? "Yes" : "No";

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtbFindLicense.Text,out int LicenseID)){

                _LicenseID = LicenseID;
                _License = clsBuisnessLicense.Find(_LicenseID);
                if (_License != null) {

                    btnSave.Enabled = true;
                    LoadCtrl();
                    lblShowLIcenseHisroty.Enabled = true;

                }
               
            }
       
        }
        private clsBuisnessInternationalLicense _internationalLicense { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_License.IsActive == false)
            {
                MessageBox.Show("Local License Must be Active", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsBuisnessLicense.IsThirdClassLicense(_License.LicenseID))
            {
                MessageBox.Show("Local License must be from third Class", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsBuisnessInternationalLicense.IsThereInternationalLicenseActive(_License.DriverID)){
                MessageBox.Show("Driver Already has an Active InternationalLicense", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsBuisnessApplication app = new clsBuisnessApplication();

            app.PaidFees = clsBuisnessApplicationTypes.Find(6).ApplicationFees;
            app.ApplicationTypeID = 6;
            app.ApplicationDate = DateTime.Now;
            app.ApplicationStatus = 1; // New
            if(frmDVLD.User != null)
            {
                app.CreatedByUserID = frmDVLD.User.UserID;

            }
            app.ApplicationPersonID = _App.ApplicationPersonID;
            app.LastStatusDate = DateTime.Now;
            if (app.AddNewApplication())
            {
                lblInternationalLicenseApp.Text = app.ApplicationID.ToString();

                _internationalLicense = new clsBuisnessInternationalLicense();
                _internationalLicense.ApplicationID = app.ApplicationID;
                _internationalLicense.IssuedUsingLocalLicenseID = _License.LicenseID;
                _internationalLicense.IssueDate = DateTime.Now;
                _internationalLicense.IsActive = true;
                _internationalLicense.DriverID = _License.DriverID;
                _internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
                _internationalLicense.CreatedByUserID = frmDVLD.User.UserID;
               if( _internationalLicense.AddNewLicense()){
                    btnSave.Enabled = false;
                    app.ApplicationStatus = 3; // Completed
                    app.CompleteApplication();
                    MessageBox.Show("International License Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblShowLIcenseInfo.Enabled = true;
                    btnSave.Enabled = false;
                    groupBox1.Enabled = false;


                }


            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(clsBuisnessDriver.FindByDriverID(_License.DriverID).PersonID);
            frmShowLicenseHistory.ShowDialog();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
           
        }

        private void lblShowLIcenseInfo_Click(object sender, EventArgs e)
        {
            frmShowLicenseDetails frmShowLicenseDetails = new frmShowLicenseDetails(_internationalLicense.InternationalLicenseID);
            frmShowLicenseDetails.ShowDialog();
        }

        private void UserControl1_Load_1(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            lblShowLIcenseHisroty.Enabled = false;
            lblShowLIcenseInfo.Enabled = false;
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate2.Text = DateTime.Now.ToString();
            if (frmDVLD.User != null)  lblCreatedByUser.Text = frmDVLD.User.UserName.ToString();
            lblFees.Text = clsBuisnessApplicationTypes.Find(6).ApplicationFees.ToString();
            lblExpirationDate2.Text = DateTime.Now.AddYears(1).ToString();
        }

        private void lblShowLIcenseInfo_Click_1(object sender, EventArgs e)
        {
            frmInternationalLicenseDetails frmInternationalLicenseDetails = new frmInternationalLicenseDetails(_internationalLicense.InternationalLicenseID);
            frmInternationalLicenseDetails.ShowDialog();
        }

        private void lblShowLIcenseHisroty_Click(object sender, EventArgs e)
        {
            clsBuisnessApplication app = clsBuisnessApplication.Find(_License.ApplicationID);
            if(app != null)
            {
                frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(app.ApplicationPersonID);
                frmShowLicenseHistory.ShowDialog();
            }

           
        }
    }
}
