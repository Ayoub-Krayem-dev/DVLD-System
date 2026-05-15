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
    public partial class frmAddEditStreetTest : Form
    {
        public frmAddEditStreetTest()
        {
            InitializeComponent();
        }


        public frmAddEditStreetTest(int LocalAppID, bool status, int TestAppointmentID = -1)
        {
            InitializeComponent();
            _LocalAppID = LocalAppID;
            if (status)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _TestAppointmentID = TestAppointmentID;
                _Mode = enMode.Update;
            }
        }



        enum enMode { AddNew = 1, Update = 2 }

        enMode _Mode = enMode.AddNew;
        private clsBuisnessApplication _App { set; get; }

        private clsBuisnessLocalDrivingApplicationLicense _LocalApp { set; get; }

        private clsBuisnessLicenseClasses _LicenseClass { set; get; }

        private clsBuisnessApplicationTypes _AppType { set; get; }

        private clsBuisnessPerson _Person { set; get; }

        private clsBuinessTestTypes _TestType { set; get; }

        private int _TestAppointmentID { set; get; }


        private int _LocalAppID { set; get; }
        private void frmAddEditStreetTest_Load(object sender, EventArgs e)
        {

            if (clsBuisnessTests.IsTestFailed(_LocalAppID, 3))
            {
                lblTestID.Visible = false;
                lblTestIDT.Visible = false;
                lblRetakeFees.Text = clsBuisnessApplicationTypes.Find(7).ApplicationFees.ToString();
                lblRetakeTestID.Text = "Not Taken Yet";
            }
            else
            {
                groupBox2.Visible = false;
            }
            _LocalApp = clsBuisnessLocalDrivingApplicationLicense.Find(_LocalAppID);
            if (_LocalApp != null)
            {



                _App = clsBuisnessApplication.Find(_LocalApp.ApplicaitonID);
                if (_LocalApp != null)
                {
                    _LicenseClass = clsBuisnessLicenseClasses.Find(_LocalApp.licenseClassID);

                    lblLocatAppID.Text = _LocalApp.LocalDrivingApplicationID.ToString();
                    if (_LicenseClass != null)
                    {
                        lblLicenseClass.Text = _LicenseClass.ClassName;
                    }
                    dtpDate.MinDate = DateTime.Now;
                    if (_App != null)
                    {
                        _Person = clsBuisnessPerson.Find(_App.ApplicationPersonID);
                        if (_Person != null)
                        {
                            lblName.Text = _Person.GetFullName();

                        }

                        _TestType = clsBuinessTestTypes.Find(3);

                        if (_TestType != null)
                        {
                            lblFees.Text = _TestType.TestTypeFees.ToString();
                        }

                        if (_TestType != null && groupBox2.Enabled)
                        {
                            
                            lblTotalFees.Text = (clsBuisnessApplicationTypes.Find(7).ApplicationFees + _TestType.TestTypeFees).ToString();
                        }

                        lblTestID.Text = "Not Taken Yet";

                        lblTrial.Text = clsBuisnessTestAppoinment.GetTrials(_LocalAppID, 3).Rows.Count.ToString();
                    }

                }
            }
            else
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalAppID.ToString(),
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (_Mode == enMode.Update)
            {

                clsBuisnessTestAppoinment TestAppointment = clsBuisnessTestAppoinment.Find(_TestAppointmentID);

                if (TestAppointment == null)
                {
                    MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    return;
                }
                if (DateTime.Compare(DateTime.Now, TestAppointment.AppoinmentDate) < 0)
                    dtpDate.MinDate = DateTime.Now;
                else
                    dtpDate.MinDate = TestAppointment.AppoinmentDate;

                dtpDate.Value = TestAppointment.AppoinmentDate;


            }
            if (clsBuisnessTests.IsTestLocked(_TestAppointmentID, 3))
            {
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            clsBuisnessTestAppoinment TestAppointment = new clsBuisnessTestAppoinment();
            TestAppointment.TestTypeID = 3;
            TestAppointment.LocalDrivingLicenseID = _LocalApp.LocalDrivingApplicationID;
            TestAppointment.AppoinmentDate = dtpDate.Value;
            TestAppointment.CreatedByUserID = frmDVLD.User.UserID;

            if (clsBuisnessTests.IsTestFailed(_LocalAppID, 3))
            {

                TestAppointment.paidFees = _TestType.TestTypeFees + clsBuisnessApplicationTypes.Find(7).ApplicationFees;
                clsBuisnessApplication app = new clsBuisnessApplication();
                app.PaidFees = clsBuisnessApplicationTypes.Find(7).ApplicationFees;
                app.ApplicationDate = DateTime.Now;
                app.CreatedByUserID = frmDVLD.User.UserID;
                app.ApplicationPersonID = _Person.PersonID;
                app.ApplicationTypeID = 7;// Retake Test
                app.LastStatusDate = DateTime.Now;
                app.ApplicationStatus = 1; //New
                if (app.AddNewApplication())
                {
                    TestAppointment.RetakeTestApplicationID = app.ApplicationID;
                }
            }
            else
            {
                TestAppointment.paidFees = _TestType.TestTypeFees;
            }
            TestAppointment.IsLocked = false;
            if (_Mode == enMode.AddNew)
            {
                if (TestAppointment.AddNewAppointmentTest())
                {

                    if (clsBuisnessTests.IsTestFailed(_LocalAppID, 3))
                    {
                        lblRetakeTestID.Text = TestAppointment.TestAppoinmentID.ToString();
                    }
                    else
                    {
                        lblTestID.Text = TestAppointment.TestAppoinmentID.ToString();
                    }
                    MessageBox.Show("Test Appointment Added Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Test Appointment Added Failed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                TestAppointment.TestAppoinmentID = _TestAppointmentID;
                if (TestAppointment.UpdateTestAppointment())
                {
                    MessageBox.Show("Test Appointment Updated Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Test Appointment Updated Failed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
