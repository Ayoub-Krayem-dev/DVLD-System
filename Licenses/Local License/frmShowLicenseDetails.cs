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
    public partial class frmShowLicenseDetails : Form
    {
        public frmShowLicenseDetails()
        {
            InitializeComponent();
        }

        public frmShowLicenseDetails(int ID)
        {
            InitializeComponent();

            _LicenseID = ID;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private clsBuisnessLicense _License;
        private int _LicenseID;
        private void frmShowLicenseDetails_Load(object sender, EventArgs e)
        {
            _License = clsBuisnessLicense.Find(_LicenseID);

            if( _License != null )
            {
                lblIsDetained.Text = clsBuisnessDetainedLicense.IsDetainedByLicense(_LicenseID) == true ? "Yes" : "No";

                clsBuisnessLicenseClasses LicenseClass = clsBuisnessLicenseClasses.Find(_License.LicenseClassID);
                lblLicenseID.Text = _License.LicenseID.ToString();
                lblIssueDate.Text = _License.IssueDate.ToString();

                lblIssueReason.Text = _License.IssueReason == 1 ? "First Time" :
                    _License.IssueReason == 2 ? "Renew" : _License.IssueReason == 3 ? "Replacement for Lost" : "Replacement for Damaged";


                lblNotes.Text = _License.Notes.ToString();
                if (LicenseClass != null)
                {
                    lblClassLicense.Text = LicenseClass.ClassName.ToString();

                    lblExpirationDate.Text = _License.IssueDate.AddYears(LicenseClass.DefaultValidityLength).ToString();


                }

                lblIsActive.Text = _License.IsActive == true ? "Yes" : "No";

                lblDriverID.Text = _License.DriverID.ToString();

                clsBuisnessApplication App = clsBuisnessApplication.Find(_License.ApplicationID);

                if(App != null)
                {
                    clsBuisnessPerson Person = clsBuisnessPerson.Find(App.ApplicationPersonID);
                    if(Person!= null)
                    {
                        lblName.Text = Person.GetFullName();
                        lblDateOfBirth.Text = Person.DateOfBirth.ToString();
                        lblNationalNo.Text = Person.NationalNo.ToString();
                        lblGender.Text = Person.Gendor == 1 ? "Female" : "Male";
                        _LoadPersonImage(Person);
;                    }

                    
                }
            }
            
        }

        private void _LoadPersonImage(clsBuisnessPerson Person)
        {
            if (Person.Gendor == 0)
                pictureBox2.Image = imageList1.Images[1];
            else
                pictureBox2.Image = imageList1.Images[0];

            string ImagePath = Person.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pictureBox2.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
