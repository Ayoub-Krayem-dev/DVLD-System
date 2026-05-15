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
using System.Text.RegularExpressions;
using System.IO;


namespace DVLD
{
    public partial class ctrlPeopleManage : UserControl
    {
        public delegate void DataSender(int PersonID);
        public event DataSender Databack;

        //private string _ImagePath = "";
        //private string _ImagesFolder = @"C:\DVLD_People_Image";
        public ctrlPeopleManage()
        {
            InitializeComponent();
        }
        enum enMode { AddNew = 1, Update = 2 }

        private int _PersonID { get; set; }

        enMode _Mode = enMode.AddNew;
        public void LoadCtrl(int PersonID)
        {
            _PersonID = PersonID;

            if (PersonID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
               // Person = clsBuisnessPerson.Find(PersonID);

            }
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void txtbFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gbAddNewPerson_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        private clsBuisnessPerson Person { get; set; }
        private void ctrlPeopleManage_Load(object sender, EventArgs e)
        {

            txtbFirstName.Focus();
            if (_Mode == enMode.AddNew)
            {
                dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
                dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

                rdbMale.Checked = true;

                DataTable dt = clsBuisnessCountry.GetAllCountries();

                foreach (DataRow row in dt.Rows)
                {
                    cbCountry.Items.Add(row["CountryName"]);
                }

                cbCountry.SelectedItem = "Libya";

                lblTitleAddEditPerson.Text = "Add New Person";
                Person = new clsBuisnessPerson();


            }

            else
            {
                DataTable dt = clsBuisnessCountry.GetAllCountries();

                foreach (DataRow row in dt.Rows)
                {
                    cbCountry.Items.Add(row["CountryName"]);
                }

                lblTitleAddEditPerson.Text = "Edit Person";

                Person = clsBuisnessPerson.Find(_PersonID);

                if (Person != null)
                {
                    lblPersonID.Text = Person.PersonID.ToString();
                    txtbNationalNo.Text = Person.NationalNo.ToString();
                    txtbFirstName.Text = Person.FirstName;
                    txtbSecondName.Text = Person.SecondName;
                    txtbThirdName.Text = Person.ThirdName;
                    txtbLastName.Text = Person.LastName;
                    txtbAddress.Text = Person.Address;
                    dtpDateOfBirth.Value = Person.DateOfBirth;
                    if (Person.Gendor == 0)
                    {
                        rdbMale.Checked = true;
                    }
                    else
                    {
                        rdbFemale.Checked = true;
                    }

                    txtbPhone.Text = Person.Phone;
                    if (Person.Email != "")
                    {
                        mtxtbEmail.Text = Person.Email;
                    }
                    else
                    {
                        mtxtbEmail.Text = "";
                    }
                    if (Person.ImagePath != "")
                    {
                        pbImage.ImageLocation = Person.ImagePath;

                    }
                    lblRemoveImage.Visible = Person.ImagePath != "";


                    cbCountry.SelectedIndex = cbCountry.FindString(clsBuisnessCountry.Find(Person.NationalityCountryID).CountryName);
                }

            }


        }

        private void lblGendor_Click(object sender, EventArgs e)
        {

        }

        private void txtbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbFirstName.Text))
            {
                errorProvider1.SetError(txtbFirstName, "You must enter a Name");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(txtbFirstName, "");
                e.Cancel = false;
            }
        }

        private void txtbLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbSecondName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbSecondName.Text))
            {
                errorProvider1.SetError(txtbSecondName, "You must enter a Name");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(txtbSecondName, "");
                e.Cancel = false;
            }
        }

        private void txtbLastName_Validated(object sender, EventArgs e)
        {

        }

        private void txtbLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbLastName.Text))
            {
                errorProvider1.SetError(txtbLastName, "You must enter a Name");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(txtbLastName, "");
                e.Cancel = false;
            }
        }

        private void txtbNationalNo_Validating(object sender, CancelEventArgs e)
        {






            if (string.IsNullOrWhiteSpace(txtbNationalNo.Text))
            {
                errorProvider1.SetError(txtbNationalNo, "You must enter a NationalNo");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(txtbNationalNo, "");
                e.Cancel = false;
                int ID = -1;
                if (int.TryParse(lblPersonID.Text, out int PersonID))
                {
                    ID = PersonID;
                }
                if (clsBuisnessPerson.IsExist(txtbNationalNo.Text, ID))
                {
                    errorProvider1.SetError(txtbNationalNo, "National No is already used");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtbNationalNo, "");
                    e.Cancel = false;

                }
            }






        }
        private bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }

            }
            return true;
        }

        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }
        private string ReplaceFileNameWithGUID(string SourceFile)
        {
            string FileName = SourceFile;
            FileInfo fi = new FileInfo(FileName);
            string extn = fi.Extension.ToString();
            return GenerateGUID() + extn;
        }
        private bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string DestinationFolder = @"C:\DVLD-People-Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }


            string DestinationFile = Path.Combine( DestinationFolder , ReplaceFileNameWithGUID(SourceFile));

            try
            {
           
                File.Copy(SourceFile, DestinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            SourceFile = DestinationFile;
            return true;


        }
        private bool _HandlePersonImage()
        {
            if(Person != null)
            {
                if (Person.ImagePath != pbImage.ImageLocation)
                {
                    if (Person.ImagePath != "")
                    {
                        try
                        {
                            pbImage.Image = null;
                            File.Delete(Person.ImagePath);

                        }
                        catch (IOException)
                        {

                        }
                    }


                }
            }
           

            if (pbImage.ImageLocation != null)
            {
                string sourceDistinaitonFile = pbImage.ImageLocation.ToString();
                if (CopyImageToProjectImagesFolder(ref sourceDistinaitonFile))
                {
                    pbImage.ImageLocation = sourceDistinaitonFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;

        }
        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null || pbImage.ImageLocation == "")
                pbImage.Image = imageList1.Images[0];
        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null || pbImage.ImageLocation == "")
                pbImage.Image = imageList1.Images[1];

        }

        private void txtbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbPhone.Text))
            {
                errorProvider1.SetError(txtbPhone, "You must enter a Phone Number");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(txtbPhone, "");
                e.Cancel = false;
            }
        }

        private void Validating_TextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                errorProvider1.SetError(Temp, "This field is required!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(Temp, null);

            }
        }
        private void txtbAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbAddress.Text))
            {
                errorProvider1.SetError(txtbAddress, "You must enter an address");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(txtbAddress, "");
                e.Cancel = false;
            }
        }

        private void lblSetImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = ofd.FileName;
                pbImage.ImageLocation =selectedFilePath;
                lblRemoveImage.Visible = true;
            }
        }
        private void _SaveImage(string FileName)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            if (!_HandlePersonImage())
            {
                return;
            }
            if (_Mode == enMode.AddNew)
            {
                Person = new clsBuisnessPerson();
                Person.NationalNo = txtbNationalNo.Text.Trim();
                Person.FirstName = txtbFirstName.Text.Trim();
                Person.SecondName = txtbSecondName.Text.Trim();
                if (txtbThirdName.Text != "")
                {
                    Person.ThirdName = txtbThirdName.Text.Trim();
                }
                else
                {
                    Person.ThirdName = "";
                }
                Person.LastName = txtbLastName.Text.Trim();
                Person.Phone = txtbPhone.Text.Trim();
                if (mtxtbEmail.Text != "")
                {
                    Person.Email = mtxtbEmail.Text.Trim();
                }
                else
                {
                    Person.Email = "";
                }
                if(pbImage.ImageLocation != null)
                {
                    Person.ImagePath = pbImage.ImageLocation.ToString();

                }
                else
                {
                    Person.ImagePath = "";
                }
                Person.Address = txtbAddress.Text.Trim();
                Person.DateOfBirth = dtpDateOfBirth.Value;
                Person.NationalityCountryID = clsBuisnessCountry.Find(cbCountry.SelectedItem.ToString()).CountryID;
                if (rdbFemale.Checked)
                {
                    Person.Gendor = 1;
                }
                else
                {
                    Person.Gendor = 0;
                }

                if (Person.Save())
                {
                    MessageBox.Show("Added Successfully");
                    lblPersonID.Text = Person.PersonID.ToString();
                    lblTitleAddEditPerson.Text = "Update Person";
                    _Mode = enMode.Update;

                    Databack?.Invoke(Person.PersonID);


                }
                else
                {
                    MessageBox.Show("added Failed");
                }
            }
            else
            {
                int gender = 0;
                if (rdbMale.Checked)
                {
                    gender = 0;
                }

                else
                {
                    gender = 1;
                }
                string ImagePath = pbImage.ImageLocation != null ? pbImage.ImageLocation : "";
                int CountryID = clsBuisnessCountry.Find(cbCountry.SelectedItem.ToString()).CountryID;
                Person = new clsBuisnessPerson(int.Parse(lblPersonID.Text), txtbNationalNo.Text,
                   txtbFirstName.Text, txtbSecondName.Text, txtbThirdName.Text, txtbLastName.Text, dtpDateOfBirth.Value, gender, txtbAddress.Text, txtbPhone.Text,
                   mtxtbEmail.Text, CountryID, ImagePath);

                if (Person.Save())
                {
                    MessageBox.Show("Updated Successfully");

                    Databack?.Invoke(Person.PersonID);

                }
                else
                {
                    MessageBox.Show("Updated Failed");
                }
            }
        }

        private void mtxtbEmail_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            Regex regex = new Regex(pattern);


            if (string.IsNullOrEmpty(mtxtbEmail.Text))
            {
                errorProvider1.SetError(mtxtbEmail, "");
                return;
            }

            if (!regex.IsMatch(mtxtbEmail.Text))
            {
                errorProvider1.SetError(mtxtbEmail, "Invalid Format");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(mtxtbEmail, "");
                e.Cancel = false;
            }

        }

        private void lblRemoveImage_Click(object sender, EventArgs e)
        {



            if(pbImage.Image != null)
            {
                pbImage.Image.Dispose();
                pbImage.ImageLocation = null;
            }
               



                if (rdbMale.Checked)
                    pbImage.Image = imageList1.Images[0];
                else
                    pbImage.Image = imageList1.Images[1];
                lblRemoveImage.Visible = false;





               
            
        }
    }
}
