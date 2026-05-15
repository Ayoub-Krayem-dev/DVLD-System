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
    public partial class ctrlPersonDetials : UserControl
    {

      
        private int _PersonID { set; get; } 
        public void LoadCtrl(int PersonID)
        {
            _PersonID = PersonID;

            
        }

        public void FillDetails(int PersonID)
        {
            clsBuisnessPerson person = clsBuisnessPerson.Find(PersonID);

            if (person != null)
            {
                
                lblPerson.Text = person.PersonID.ToString();
                lblAddress.Text = person.Address;
                lblName.Text = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}";
                lblNationalNo.Text = person.NationalNo;
                lblPhone.Text = person.Phone;
                lblGendor.Text = person.Gendor == 0 ? "Male" : "Female";
                lblCountry.Text = clsBuisnessCountry.Find(person.NationalityCountryID).CountryName;
                lblEmail.Text = person.Email;
                lblDateOfBirth.Text = person.DateOfBirth.ToString();
                string ImagePath = person.ImagePath;
                if (ImagePath != "")
                {
                    if (File.Exists(ImagePath))
                    {
                        pictureBox1.ImageLocation = ImagePath;
                    }
                }
                else
                {
                    if(person.Gendor == 0)
                    {
                        pictureBox1.Image = imageList1.Images[0];
                    }
                    else
                    {
                        pictureBox1.Image = imageList1.Images[1];

                    }
                }
            }
        }
        public ctrlPersonDetials()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonDetials_Load(object sender, EventArgs e)
        {
            clsBuisnessPerson person = clsBuisnessPerson.Find(_PersonID);

            if(person != null)
            {
                lblPerson.Text = person.PersonID.ToString();
                lblAddress.Text = person.Address;
                lblName.Text = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}";
                lblNationalNo.Text = person.NationalNo;
                lblPhone.Text = person.Phone;
                lblGendor.Text = person.Gendor == 0 ? "Male" : "Female";
                lblCountry.Text = clsBuisnessCountry.Find(person.NationalityCountryID).CountryName;
                lblEmail.Text = person.Email;
                lblDateOfBirth.Text = person.DateOfBirth.ToString();
                string ImagePath = person.ImagePath;
                if (ImagePath != "")
                {
                    if (File.Exists(ImagePath))
                    {
                        pictureBox1.ImageLocation = ImagePath;
                    }
                }
                else
                {
                    if (person.Gendor == 0)
                    {
                        pictureBox1.Image = imageList1.Images[0];
                    }
                    else
                    {
                        pictureBox1.Image = imageList1.Images[1];

                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlPersonDetials_Enter(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblEditPersonInfo_Click(object sender, EventArgs e)
        {
            frmAddNew frmAddNew = new frmAddNew(_PersonID);
            frmAddNew.ShowDialog();


        }
    }
}
