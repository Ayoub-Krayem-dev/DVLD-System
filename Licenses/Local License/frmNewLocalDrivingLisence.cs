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
    public partial class frmNewLocalDrivingLisence : Form
    {
        public frmNewLocalDrivingLisence()
        {
            InitializeComponent();
        }
        private bool AllowTab2 = false;
        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses = clsBuisnessLicenseClasses.GetAllLicensesClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClasses.Items.Add(row["ClassName"]);
            }
        }
        private void frmNewLocalDrivingLisence_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "Person Info";
            tabPage2.Text = "Application Info";
            cbFindBy.Items.Add("PersonID");
            cbFindBy.Items.Add("NationalNo");
            cbFindBy.Items.Add("None");
            cbFindBy.SelectedItem = "NationalNo";
            btnSave.Visible = false;
            _FillLicenseClassesInComoboBox();

            cbLicenseClasses.SelectedIndex = 2;

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";

            }

            else
            {
                txtbFindBy.Enabled = false;
                cbFindBy.Enabled = false;
                lblFindByT.Enabled = false;
                btnSearch.Enabled = false;
                btnAddNewPerson.Enabled = false;
                lblTitle.Text = "Edit User";
                _LocalApp = clsBuisnessLocalDrivingApplicationLicense.Find(LocalAppID);
                if (_LocalApp != null)
                {
                    clsBuisnessApplication app = clsBuisnessApplication.Find(_LocalApp.ApplicaitonID);
                    if(app!= null)
                    {
                        ctrlPersonDetials1.FillDetails(app.ApplicationPersonID);
                        _Person = clsBuisnessPerson.Find(app.ApplicationPersonID);
                    }
                  


                }



            }
        }

      

        public frmNewLocalDrivingLisence(int ID)
        {
            InitializeComponent();
            LocalAppID = ID;

            if (ID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }
        }
        enum enMode { AddNew = 1, Update = 2 }

        enMode _Mode = enMode.AddNew;


        public int PersonID { set; get; }

        public int LocalAppID { set; get; }

        private clsBuisnessPerson _Person { set; get; }



        private clsBuisnessLocalDrivingApplicationLicense  _LocalApp { set; get; }



   

   
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void txtbFindBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFindBy.SelectedItem.ToString() == "PersonID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void DataGet(int ID)
        {
            PersonID = ID;
            _Person = clsBuisnessPerson.Find(PersonID);
            ctrlPersonDetials1.FillDetails(PersonID);
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNew frmAddNew = new frmAddNew(-1);
            frmAddNew.DataBack += DataGet;
            frmAddNew.ShowDialog();



        }


       
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            



        }

      

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblEditPersonInfo_Click(object sender, EventArgs e)
        {

            if (_Person != null)
            {
                frmAddNew frmAddNew = new frmAddNew(_Person.PersonID);
                frmAddNew.ShowDialog();
                ctrlPersonDetials1.FillDetails(_Person.PersonID);

            }
            else
            {
                MessageBox.Show("you must choose a person", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private static int CalculateAge(DateTime birthdate)
        {
            int age = DateTime.Now.Year - birthdate.Year;
            if(DateTime.Now < birthdate.AddYears(age))
            {
                age--;
            }
            return age;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            int LicenseclassID = clsBuisnessLicenseClasses.Find(cbLicenseClasses.SelectedItem.ToString()).LicenseClassID;
            int LimitAge = clsBuisnessLicenseClasses.Find(cbLicenseClasses.SelectedItem.ToString()).MinimumAllowedAge;

            if (clsBuisnessLocalDrivingApplicationLicense.IsAppExist(LicenseclassID, _Person.PersonID))
            {
                MessageBox.Show("Person Has already done this application before", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;








            }

            //int ActiveApplicationID = clsBuisnessApplication.GetActiveApplicationIDForLicenseClass(_Person.PersonID, 1, LicenseclassID);

            //if (ActiveApplicationID != -1)
            //{
            //    MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cbLicenseClasses.Focus();
            //    return;
            //}

            if (clsBuisnessLicense.GetActiveLicenseIDByPersonID(_Person.PersonID, LicenseclassID)!= -1)
            {
                MessageBox.Show("Person Has already this License", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }

            if (_Mode == enMode.AddNew)
            {



                if (!app.AddNewApplication())
                {
                    MessageBox.Show("Application Added Failed", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (app != null)
                {
                    int PersonAge = CalculateAge(clsBuisnessPerson.Find(app.ApplicationPersonID).DateOfBirth);

                    if(PersonAge < LimitAge)
                    {
                        MessageBox.Show("Age not allowed","Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    clsBuisnessLocalDrivingApplicationLicense LocalApp = new clsBuisnessLocalDrivingApplicationLicense();

                    LocalApp.ApplicaitonID = app.ApplicationID;
                    LocalApp.licenseClassID = clsBuisnessLicenseClasses.Find(cbLicenseClasses.SelectedItem.ToString()).LicenseClassID;




                    if (LocalApp.AddNewLocalDrivingApp())
                    {
                        MessageBox.Show("Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblAppID.Text = LocalApp.ApplicaitonID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Added Failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                if (_LocalApp != null)
                {
                    _LocalApp.licenseClassID = clsBuisnessLicenseClasses.Find(cbLicenseClasses.SelectedItem.ToString()).LicenseClassID;

                    if (_LocalApp.UpdateLocalApp())
                    {
                        MessageBox.Show("Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    else
                    {
                        MessageBox.Show("Updated Failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
            }

            this.Close();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblEditPersonInfo_Click_1(object sender, EventArgs e)
        {
            if (_Person != null)
            {
                frmAddNew frmAddNew = new frmAddNew(_Person.PersonID);
                frmAddNew.ShowDialog();
                ctrlPersonDetials1.FillDetails(_Person.PersonID);

            }
            else
            {
                MessageBox.Show("you must choose a person", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (cbFindBy.SelectedItem.ToString() == "PersonID")
            {
                int PersonID = -1;
                if (int.TryParse(txtbFindBy.Text, out int ID))
                {
                    PersonID = ID;
                }

                _Person = clsBuisnessPerson.Find(PersonID);

                if (_Person != null)
                {
                    ctrlPersonDetials1.FillDetails(_Person.PersonID);

                }

                else
                {

                    MessageBox.Show("Person Not Found", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (cbFindBy.SelectedItem.ToString() == "NationalNo")

            {
                _Person = clsBuisnessPerson.Find(txtbFindBy.Text);



                if (_Person != null)
                {
                    ctrlPersonDetials1.FillDetails(_Person.PersonID);
                }
                else
                {
                    MessageBox.Show("Person Not Found", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            frmAddNew frmAddNew = new frmAddNew(-1);
            frmAddNew.DataBack += DataGet;
            frmAddNew.ShowDialog();
            Refresh();
        }

        private clsBuisnessApplication app { set; get; }
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (_Person != null)
                {
                    clsBuisnessApplicationTypes AppType = clsBuisnessApplicationTypes.Find(1);

                    app = new clsBuisnessApplication();

                    app.ApplicationTypeID = AppType.ApplicationTypeID;
                    app.PaidFees = AppType.ApplicationFees;
                    app.ApplicationDate = DateTime.Now;
                    app.LastStatusDate = DateTime.Now;
                    app.ApplicationPersonID = _Person.PersonID;
                    app.ApplicationStatus = 1;
                    app.CreatedByUserID = frmDVLD.User.UserID;

                    lblApplicationDate.Text = DateTime.Now.ToString();
                    lblApplicationFees.Text = app.PaidFees.ToString();
                    lblCreatedBy.Text = app.CreatedByUserID.ToString();

                    DataTable dt = clsBuisnessLicenseClasses.GetAllLicensesClasses();

                   


                }
                if (_Person != null)
                {
                    AllowTab2 = true;
                    Tab1.SelectedTab = tabPage2;
                    btnSave.Visible = true;



                }
                else
                {
                    MessageBox.Show("You must Choose a person", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                app = clsBuisnessApplication.Find(_LocalApp.ApplicaitonID);

                if (app != null)
                {
                    lblAppID.Text = _LocalApp.LocalDrivingApplicationID.ToString();
                    lblApplicationDate.Text = DateTime.Now.ToString();
                    lblApplicationFees.Text = app.PaidFees.ToString();
                    lblCreatedBy.Text = app.CreatedByUserID.ToString();

                    DataTable dt = clsBuisnessLicenseClasses.GetAllLicensesClasses();

                    foreach (DataRow row in dt.Rows)
                    {
                        cbLicenseClasses.Items.Add(row["ClassName"]);
                    }
                    cbLicenseClasses.SelectedIndex = 0;
                }

                if (_Person != null)
                {
                    AllowTab2 = true;
                    Tab1.SelectedTab = tabPage2;
                    btnSave.Visible = true;



                }
            }
           
        }

        private void Tab1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPage2 && !AllowTab2)
            {
                e.Cancel = true;
            }
        }

        private void cbLicenseClasses_Validating(object sender, CancelEventArgs e)
        {
            if(cbLicenseClasses.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbLicenseClasses, "You must Choose a License Class");
            }
            else
            {
                errorProvider1.SetError(cbLicenseClasses, "");

            }
        }

        private void ctrlPersonDetials1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtbFindBy_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
            if (cbFindBy.SelectedItem.ToString() == "PersonID")
            {
                e.Handled = !char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);

            }
        }

        private void txtbFindBy_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtbFindBy.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbFindBy, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtbFindBy, null);
            }
        }

        private void cbFindBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
             if (cbFindBy.SelectedItem.ToString() == "None")
            {
                txtbFindBy.Enabled = false;
            }
            else
            {
                txtbFindBy.Enabled = true;
            }
        }

        private void frmNewLocalDrivingLisence_Activated(object sender, EventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
