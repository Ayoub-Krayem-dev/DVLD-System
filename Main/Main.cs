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
using System.IO;

namespace DVLD
{
    public partial class frmDVLD : Form
    {
        public frmDVLD()
        {
            InitializeComponent();
        }
        private frmLogin _frmLogin;
        public static clsUserBuisness User;
        public frmDVLD(int UserID,frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
            User = clsUserBuisness.FindByUserID(UserID);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            
        }

        private void ctrlPeopleManage1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void klToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();
        }

        private void managePeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeopleManage frmPeopleManage = new frmPeopleManage();
            frmPeopleManage.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User = null;
            _frmLogin.Show();
            this.Close();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (User != null)
            {
                frmShowDetails frmShowDetails = new frmShowDetails(User.UserID);
                frmShowDetails.ShowDialog();
            }
          
            
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(User.UserID);
            frmChangePassword.LoadCltr();

            frmChangePassword.ShowDialog();
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationTypesManage frmApplicationManage = new frmApplicationTypesManage();
            frmApplicationManage.ShowDialog();
        }

        private void manageTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTests frmManageTests = new frmManageTests();
            frmManageTests.ShowDialog();
        }

        private void drivingLicensesServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplications frmManageApplications = new frmManageApplications();

            frmManageApplications.ShowDialog();
        }

        private void newDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLisence frmNewLocalDrivingLisence = new frmNewLocalDrivingLisence(-1);
            frmNewLocalDrivingLisence.ShowDialog();
        }

        private void manageDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers frmManageDrivers = new frmManageDrivers();
           
            frmManageDrivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frmAddNewInternationalLicense = new frmAddNewInternationalLicense();
            frmAddNewInternationalLicense.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicense frmManageInternationalLicense = new frmManageInternationalLicense();
            frmManageInternationalLicense.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicense frmRenewLicense = new frmRenewLicense();
            frmRenewLicense.ShowDialog();
        }

        private void replacementForDamagedOrLostLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacement frmReplacement = new frmReplacement();
            frmReplacement.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDetainLicense = new frmDetainLicense();
            frmDetainLicense.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frmReleaseLicense = new frmReleaseLicense();
            frmReleaseLicense.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frmManageDetainReleaseLicenses = new frmManageDetainedLicenses();
            frmManageDetainReleaseLicenses.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frmReleaseLicense = new frmReleaseLicense();
            frmReleaseLicense.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplications frmManageApplications = new frmManageApplications();

            frmManageApplications.ShowDialog();
        }
    }
}
