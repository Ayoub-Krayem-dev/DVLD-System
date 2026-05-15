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
    public partial class frmIssueLicense : Form
    {
        public frmIssueLicense()
        {
            InitializeComponent();
        }
         private int _LocalAppID { get; set; }

        public frmIssueLicense(int ID)
        {
            _LocalAppID = ID;
            InitializeComponent();

            ctrlApplicationDetails1.LoadCtrl(_LocalAppID, 3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsBuisnessLicense License = new clsBuisnessLicense();
            clsBuisnessLocalDrivingApplicationLicense LocalApp = clsBuisnessLocalDrivingApplicationLicense.Find(_LocalAppID);
            clsBuisnessDriver Driver = new clsBuisnessDriver();
            Driver.CreatedByUserID = frmDVLD.User.UserID;
            Driver.CreatedDate = DateTime.Now;

            
            
            if(LocalApp!= null)
            {
                clsBuisnessLicenseClasses LicenseClass = clsBuisnessLicenseClasses.Find(LocalApp.licenseClassID);

                clsBuisnessApplication app = clsBuisnessApplication.Find(LocalApp.ApplicaitonID);
                if (app != null)
                {
                    
                    Driver.PersonID = app.ApplicationPersonID;

                    if (clsBuisnessDriver.FindByPersonID(app.ApplicationPersonID) == null)
                    {
                        if (Driver.AddNewDriver())
                        {
                            License.DriverID = Driver.DriverID;
                            app.CompleteApplication();
                        }
                    }
                    else
                    {
                        Driver = clsBuisnessDriver.FindByPersonID(app.ApplicationPersonID);
                        if(Driver != null)
                        {
                            License.DriverID = Driver.DriverID;
                            app.CompleteApplication();

                        }
                    }
                   
                }
                if(LicenseClass != null)
                {
                    License.PaidFees = LicenseClass.ClassFees;

                }
                License.ApplicationID = LocalApp.ApplicaitonID;
                License.LicenseClassID = LocalApp.licenseClassID;
                License.CreatedByUserID = frmDVLD.User.UserID;
                License.IssueDate = DateTime.Now;
                License.Notes = txtbNotes.Text;
                License.IsActive = true;
                License.IssueReason = 1;//FirstTime
                License.ExpirationDate = DateTime.Now.AddYears(clsBuisnessLicenseClasses.Find(License.LicenseClassID).DefaultValidityLength);

                if (License.AddNewLicense())
                {
                    app.CompleteApplication();
                    MessageBox.Show($"Done successfully with Liscense ID = {License.LicenseID}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show($"Issue Failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                this.Close();


            }

        }

        private void ctrlApplicationDetails1_Load(object sender, EventArgs e)
        {

        }

        private void frmIssueLicense_Load(object sender, EventArgs e)
        {


            clsBuisnessLocalDrivingApplicationLicense LocalApp = clsBuisnessLocalDrivingApplicationLicense.Find(_LocalAppID);

            if(LocalApp != null)
            {
                clsBuisnessApplication app = clsBuisnessApplication.Find(LocalApp.ApplicaitonID);
                if(app!= null)
                {
                    int LicenseID = clsBuisnessLicense.GetActiveLicenseIDByPersonID(app.ApplicationPersonID, LocalApp.licenseClassID);
                if (LicenseID != -1)
                    {

                        MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;

                    }
                }
               
                clsBuisnessLicenseClasses LicenseClass = clsBuisnessLicenseClasses.Find(LocalApp.licenseClassID);

                if(LicenseClass != null)
                {
                    lblLicenseClassFees.Text = LicenseClass.ClassFees.ToString();
                }
            }
            else
            {
                MessageBox.Show("No Applicaiton with ID=" + _LocalAppID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }
    }
}
