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
    public partial class ctrlReleaseLicense : UserControl
    {
        public ctrlReleaseLicense()
        {
            _flag = true;
            InitializeComponent();
        }
        private bool _flag { get; set; }
        private clsBuisnessLicense _License { get; set; }

        private int _LicenseID { get; set; }

 
        private clsBuisnessApplication _App { get; set; }
        private void ctrlReleaseLicense_Load(object sender, EventArgs e)
        {
            if( _flag)
            {
                btnSave.Enabled = false;
                lblShowLIcenseHisroty.Enabled = false;

            }
            lblShowLIcenseInfo.Enabled = false;

            lblApplicationDate.Text = DateTime.Now.ToString();
            if (frmDVLD.User != null) lblCreatedByUser.Text = frmDVLD.User.UserName.ToString();
            lblFees.Text = clsBuisnessApplicationTypes.Find(6).ApplicationFees.ToString();

        }

        public void FillDetails(int ID)
        {
            _flag = false;
            _License = clsBuisnessLicense.Find(ID);
            if(_License != null)
            {
                DetainedLicenseID = clsBuisnessDetainedLicense.GetID(_License.LicenseID);
                if (DetainedLicenseID != -1)
                {
                    lblDetaineID.Text = DetainedLicenseID.ToString();
                }
                LoadCtrl();
                TxtbFindLicense.Text = ID.ToString();
                groupBox1.Enabled = false;
                btnSave.Enabled = true;
                lblShowLIcenseHisroty.Enabled = true;
                
            }
        }

        private void LoadCtrl()
        {
            // _InternationalLicense = clsBuisnessLicense.FindByPersonID(_InternationalLicenseID);

            if (_License != null)
            {

                lblIsDetained.Text = clsBuisnessDetainedLicense.IsDetainedByLicense(_License.LicenseID) == true ? "Yes" : "No";
                lblLicenseID2.Text = _License.LicenseID.ToString();
                clsBuisnessLicenseClasses LicenseClass = clsBuisnessLicenseClasses.Find(_License.LicenseClassID);
                lblLicenseID.Text = _License.LicenseID.ToString();
                lblIssueDate.Text = _License.IssueDate.ToString();

                lblIssueReason.Text = _License.IssueReason == 1 ? "First Time" :
                    _License.IssueReason == 2 ? "Renew" : _License.IssueReason == 3 ? "Replacement for Damaged" : "Replacement for Lost";

                lblFees.Text = clsBuisnessApplicationTypes.Find(5).ApplicationFees.ToString();
                decimal FineFees = clsBuisnessDetainedLicense.GetFineFees(DetainedLicenseID);
                if (FineFees != -1)
                {
                    lblFineFees.Text = FineFees.ToString();

                    lblTotalFees.Text = (clsBuisnessApplicationTypes.Find(5).ApplicationFees + FineFees).ToString();

                }

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

        private int DetainedLicenseID { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtbFindLicense.Text, out int LicenseID))
            {
               
                _LicenseID = LicenseID;
                _License = clsBuisnessLicense.Find(_LicenseID);
                if (_License != null)
                {
                     

                    if (clsBuisnessDetainedLicense.IsDetainedByLicense(LicenseID))
                    {
                        
                        DetainedLicenseID = clsBuisnessDetainedLicense.GetID(_License.LicenseID);
                        if(DetainedLicenseID!= -1)
                        {
                            lblDetaineID.Text = DetainedLicenseID.ToString();
                        }
                        LoadCtrl();
                        lblShowLIcenseHisroty.Enabled = true;
                        btnSave.Enabled = true;

                    }
                    else
                    {
                        MessageBox.Show("License is not Detained !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadCtrl();
                        lblShowLIcenseHisroty.Enabled = true;
                        btnSave.Enabled = false;

                    }




                }

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_License.IsActive == false)
            {
                MessageBox.Show("Local License Must be Active", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
            clsBuisnessApplication app = new clsBuisnessApplication();

            app.PaidFees = clsBuisnessApplicationTypes.Find(5).ApplicationFees;
            app.ApplicationTypeID = 5;
            app.ApplicationDate = DateTime.Now;
            app.ApplicationStatus = 1; // New
            if (frmDVLD.User != null)
            {
                app.CreatedByUserID = frmDVLD.User.UserID;

            }
            app.ApplicationPersonID = _App.ApplicationPersonID;
            app.LastStatusDate = DateTime.Now;
            if (app.AddNewApplication())
            {
                

                
                    clsBuisnessDetainedLicense detainedLicense = new clsBuisnessDetainedLicense();
                
                    detainedLicense.DetainID = DetainedLicenseID;
                    detainedLicense.ReleaseApplicationID = app.ApplicationID;
                    detainedLicense.ReleaseDate = DateTime.Now;
                    detainedLicense.ReleasedByUserID = frmDVLD.User.UserID;
                    detainedLicense.ReleaseLicense();
                    btnSave.Enabled = false;
                    app.ApplicationStatus = 3; // Completed
                    app.CompleteApplication();
                    MessageBox.Show(" License Released Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblShowLIcenseInfo.Enabled = true;
                    



            }
        }

        private void lblShowLIcenseInfo_Click(object sender, EventArgs e)
        {
            frmShowLicenseDetails frmShowLicenseDetails = new frmShowLicenseDetails(_License.LicenseID);
            frmShowLicenseDetails.ShowDialog();
        }

        private void lblShowLIcenseHisroty_Click(object sender, EventArgs e)
        {
            clsBuisnessApplication app = clsBuisnessApplication.Find(_License.ApplicationID);
            if (app != null)
            {
                frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(app.ApplicationPersonID);
                frmShowLicenseHistory.ShowDialog();
            }
        }
    }
}
