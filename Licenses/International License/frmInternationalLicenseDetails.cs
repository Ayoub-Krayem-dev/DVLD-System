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
    public partial class frmInternationalLicenseDetails : Form
    {
        public frmInternationalLicenseDetails()
        {
            InitializeComponent();
        }

        public frmInternationalLicenseDetails(int ID)
        {
            InitializeComponent();
            _InternationalLicenseID = ID;
        }

        private void _LoadPersonImage()
        {
            if (_InternationalLicense != null)
            {


                clsBuisnessApplication app = clsBuisnessApplication.Find(_InternationalLicense.ApplicationID);
                {

                    string ImagePath = "";
                    clsBuisnessPerson person = clsBuisnessPerson.Find(app.ApplicationPersonID);
                    if (person != null)
                    {
                        if (person.Gendor == 0)
                            pictureBox2.Image = imageList1.Images[0];
                        else
                            pictureBox2.Image = imageList1.Images[1];
                        ImagePath = person.ImagePath;


                    }


                  

                    if (ImagePath != "")
                        if (File.Exists(ImagePath))
                            pictureBox2.ImageLocation = (ImagePath);
                        else
                            MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                } } }
        private void lblClassLicense_Click(object sender, EventArgs e)
        {

        }
        private clsBuisnessInternationalLicense _InternationalLicense { get; set; }

        private int _InternationalLicenseID { get; set; }
        private void frmInternationalLicenseDetails_Load(object sender, EventArgs e)
        {

            _InternationalLicense = clsBuisnessInternationalLicense.Find(_InternationalLicenseID);

            if (_InternationalLicense != null)
            {
                lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();

                lblIssueDate.Text = _InternationalLicense.IssueDate.ToString();

                lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();

                 lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString();


                

                lblIsActive.Text = _InternationalLicense.IsActive == true ? "Yes" : "No";

                lblDriverID.Text = _InternationalLicense.DriverID.ToString();

                clsBuisnessApplication App = clsBuisnessApplication.Find(_InternationalLicense.ApplicationID);

                if (App != null)
                {
                    clsBuisnessPerson Person = clsBuisnessPerson.Find(App.ApplicationPersonID);
                    if (Person != null)
                    {
                        lblName.Text = Person.GetFullName();
                        lblDateOfBirth.Text = Person.DateOfBirth.ToString();
                        lblNationalNo.Text = Person.NationalNo.ToString();
                        lblGender.Text = Person.Gendor == 1 ? "Female" : "Male";
                        _LoadPersonImage();


                    }


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
