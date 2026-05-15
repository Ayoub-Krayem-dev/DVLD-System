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

    public partial class frmAddEditUser : Form
    {
        public frmAddEditUser()
        {
            InitializeComponent();
        }

        public frmAddEditUser(int ID)
        {
            InitializeComponent();
            UserID = ID;

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

        public int UserID { set; get; }

        private clsBuisnessPerson _Person { set; get; }

        private clsUserBuisness _User { set; get; }

        private bool AllowTab2 = false;

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            cbFindBy.Items.Add("PersonID");
            cbFindBy.Items.Add("NationalNo");
            cbFindBy.Items.Add("None");
            cbFindBy.SelectedItem = "None";

            if(_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";

            }

            else
            {
                txtbFindBy.Enabled = false;
                cbFindBy.Enabled = false;
                lblFindByT.Enabled = false;
                btnFind.Enabled = false;
                btnAddNewPerson.Enabled = false;
                lblTitle.Text = "Edit User";
                _User = clsUserBuisness.FindByUserID(UserID);
                if (_User != null)
                {
                    ctrlPersonDetials1.FillDetails(_User.PersonID);
                    _Person = clsBuisnessPerson.Find(_User.PersonID);

                    txtbPassword.Text = _User.Password;
                    txtbConfirmPassword.Text = _User.Password;
                    txtbUserName.Text = _User.UserName;
                    chbIsActive.Checked = _User.IsActive;

                    lblUserID.Text = _User.UserID.ToString();

    }



}

        }

     
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            if (cbFindBy.SelectedItem.ToString() == "None")
            {
                txtbFindBy.Enabled = false;
            }
            else
            {
                txtbFindBy.Enabled = true;
            }
        }
        private void DataGet(int ID)
        {
            PersonID = ID;
            ctrlPersonDetials1.FillDetails(PersonID);
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNew frmAddNew = new frmAddNew(-1);
            frmAddNew.DataBack += DataGet;
            frmAddNew.ShowDialog();

           

        }

        
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {

                if (_Person != null)
                {
                    if (clsUserBuisness.FindByPersonID(_Person.PersonID) != null)
                    {
                        MessageBox.Show("Person is already an User", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (_Person != null)
                {
                    AllowTab2 = true;
                    Tab1.SelectedTab = tabPage2;
                }
                else
                {
                    MessageBox.Show("You must Choose a person", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                if (_Person != null&& _User !=null)
                {
                    AllowTab2 = true;
                    Tab1.SelectedTab = tabPage2;
                  
                }




            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPage2 && !AllowTab2)
            {
                e.Cancel = true;
            }

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
            if (!this.ValidateChildren())
            {
                return;
            }
            if (_Mode == enMode.AddNew)
            {
                clsUserBuisness User = new clsUserBuisness();
                User.UserName = txtbUserName.Text.Trim();
                User.IsActive = chbIsActive.Checked == true ? true : false;
                User.PersonID = _Person.PersonID;
                User.Password = txtbPassword.Text.Trim();

                if (User.Save())
                {
                    lblUserID.Text = User.UserID.ToString();
                    MessageBox.Show("User Added successfully");
                }
                else
                {
                    MessageBox.Show("User Added failed");
                }
            }
            else
            {
                _User.UserName = txtbUserName.Text;
                _User.IsActive = chbIsActive.Checked == true ? true : false;
                _User.PersonID = _Person.PersonID;
                _User.Password = txtbPassword.Text;

                if (_User.Save())
                {
                    MessageBox.Show("User Updated successfully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("User Updated failed");
                }

            }



        }

        private void txtbUserName_Validating(object sender, CancelEventArgs e)
        {
            if( txtbUserName.Text == "")
            {
                errorProvider1.SetError(txtbUserName, "You must enter a UserName");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtbUserName, "");
                e.Cancel = false;
            }

            if (_Mode == enMode.AddNew)
            {

                if (clsUserBuisness.isUserExist(txtbUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtbUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtbUserName, null);
                };
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != txtbUserName.Text.Trim())
                {
                    if (clsUserBuisness.isUserExist(txtbUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtbUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtbUserName, null);
                    };
                }
            }


        }

        private void txtbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtbPassword.Text == "")
            {
                errorProvider1.SetError(txtbPassword, "You must enter a Password");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtbPassword, "");
                e.Cancel = false;
            }
        }

        private void txtbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtbConfirmPassword.Text.Trim() != txtbPassword.Text.Trim())
            {
                errorProvider1.SetError(txtbConfirmPassword, "Password Confirm Must be equal to the password");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtbConfirmPassword, "");
                e.Cancel = false;
            }
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

        private void ctrlPersonDetials1_Load(object sender, EventArgs e)
        {

        }
    }
}
