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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        public frmChangePassword(int ID)
        {
            InitializeComponent();

            _User = clsUserBuisness.FindByUserID(ID);
        }

        public void LoadCltr()
        {
            if(_User == null)
            {
                MessageBox.Show($"User is not found ","Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            ctrlPersonDetials1.FillDetails(_User.PersonID);
           // ctrlPersonDetials1.LoadCtrl(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName;
            lblIsActive.Text = _User.IsActive == true ? "yes" : "No";

        }
        private clsUserBuisness _User { set; get; }
        private void lblUserIDT_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblConfirmNewPassword_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtbCurrentPassword.Text.Trim() == ""||txtbCurrentPassword.Text.Trim() != _User.Password.ToString())
            {
                errorProvider1.SetError(txtbCurrentPassword, "Incorrect Password or blank");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtbCurrentPassword, "");
                e.Cancel = false;
            }
        }

        private void txtbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtbNewPassword.Text.Trim() == "" )
            {
                errorProvider1.SetError(txtbNewPassword, "New Password cant be blank");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtbNewPassword, "");
                e.Cancel = false;
            }
        }

        private void txtbConfirmNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtbConfirmNewPassword.Text.Trim() == ""||txtbConfirmNewPassword.Text.Trim() != txtbNewPassword.Text.Trim())
            {
                errorProvider1.SetError(txtbConfirmNewPassword, "confirm Password does not match the new password ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtbConfirmNewPassword, "");
                e.Cancel = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            _User.Password = txtbNewPassword.Text.Trim();

            if (_User.Save())
            {
                MessageBox.Show("Password Changed successfully");            }
            else
            {
                MessageBox.Show("Password Changed failed");
            }

        }

        private void ctrlPersonDetials1_Load(object sender, EventArgs e)
        {

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
        

    }
