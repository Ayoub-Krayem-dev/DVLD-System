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
    public partial class frmPeopleManage : Form
    {
        public frmPeopleManage()
        {
            InitializeComponent();
        }
        public frmPeopleManage(int PersonID)
        {
            InitializeComponent();

        }
        private void _RefreshPeopleList()
        {
            dgvPeopleList.DataSource = clsBuisnessPerson.GetAllPeople();
            lblNumberOfPeople.Text = clsBuisnessPerson.GetAllPeople().Rows.Count.ToString();
            dgvPeopleList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPeopleList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPeopleList.Columns["NationalityCountryID"].HeaderText = "CountryName";
            

        }
        private void frmPeopleManage_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            cbFilterBy.Items.Add("FirstName");
            cbFilterBy.Items.Add("SecondName");
            cbFilterBy.Items.Add("ThirdName");
            cbFilterBy.Items.Add("LastNamt");
            cbFilterBy.Items.Add("PersonID");
            cbFilterBy.Items.Add("Gendor");
            cbFilterBy.Items.Add("Email");
            cbFilterBy.Items.Add("Phone");
            cbFilterBy.Items.Add("Nationality");
            cbFilterBy.Items.Add("NationalNo");
            cbFilterBy.Items.Add("None");

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNew frmAddNew = new frmAddNew(-1);
            frmAddNew.ShowDialog();
            _RefreshPeopleList();

        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNew frmAddNew = new frmAddNew();
            frmAddNew.ShowDialog();
            _RefreshPeopleList();

        }

        private void addNewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAddNew frmAddNew = new frmAddNew(-1);
            frmAddNew.ShowDialog();
            _RefreshPeopleList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNew frmAddNew = new frmAddNew((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frmAddNew.ShowDialog();
            _RefreshPeopleList();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsBuisnessPerson.DeletePerson((int)dgvPeopleList.CurrentRow.Cells[0].Value)){
                MessageBox.Show("_Person Deleted");
            }
            else
            {
                MessageBox.Show("_Person Not Deleted");

            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult resuslt = MessageBox.Show("Are you sure you want to Delete Person ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resuslt == DialogResult.Yes)
            {
                if (clsBuisnessPerson.DeletePerson((int)dgvPeopleList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Person Deleted Failed");

                }
                _RefreshPeopleList();
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbSearch.Visible = (cbFilterBy.Text != "None");

            if (txtbSearch.Visible)
            {
                txtbSearch.Text = "";
                txtbSearch.Focus();
            }

        }

        private void txtbSearch_TextChanged(object sender, EventArgs e)
        {
            int ID = 0;
            if (cbFilterBy.SelectedItem.ToString() == "PersonID")
            { 
                if( int.TryParse(txtbSearch.Text,out int PersonID)){
                    ID = PersonID;
                    dgvPeopleList.DataSource = clsBuisnessPerson.FilterByPersonID(cbFilterBy.Text, ID);

                }
            
            }
            else if(cbFilterBy.SelectedItem.ToString() == "None")

            {
                dgvPeopleList.DataSource = clsBuisnessPerson.GetAllPeople();
            }

            else if(cbFilterBy.SelectedItem.ToString() == "Gendor")
            {
                if(txtbSearch.Text == "Male"|| txtbSearch.Text == "male")
                {
                    dgvPeopleList.DataSource = clsBuisnessPerson.FilterByGendor(cbFilterBy.Text, 0);
                }
                else if(txtbSearch.Text == "Female"|| txtbSearch.Text == "female")
                {
                    dgvPeopleList.DataSource = clsBuisnessPerson.FilterByGendor(cbFilterBy.Text, 1);

                }
            }
            else
            {
                dgvPeopleList.DataSource = clsBuisnessPerson.FilterByString(cbFilterBy.Text, txtbSearch.Text);

            }
            lblNumberOfPeople.Text = (dgvPeopleList.RowCount-1).ToString();

        }

        private void dgvPeopleList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPeopleList.Columns[e.ColumnIndex].Name == "Gendor"&&e.Value != null)
            {
                if(e.Value.ToString() == "0")
                {
                    e.Value = "Male";
                }
                else if(e.Value.ToString() == "1")
                {
                    e.Value = "Female";
                }
            }
            else if (dgvPeopleList.Columns[e.ColumnIndex].Name == "NationalityCountryID" && e.Value != null)
            {
                int CountryID = 0;
                if(int.TryParse(e.Value.ToString(), out int ID)){
                    CountryID = ID;
                    e.Value = clsBuisnessCountry.Find(CountryID).CountryName;
                }
                
            }
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frmPersonDetails = new frmPersonDetails((int)dgvPeopleList.CurrentRow.Cells[0].Value);

            frmPersonDetails.ShowDialog();
            _RefreshPeopleList();
        }

        private void dgvPeopleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dgvPeopleList_DoubleClick(object sender, EventArgs e)
        {
            frmPersonDetails frmPersonDetails = new frmPersonDetails((int)dgvPeopleList.CurrentRow.Cells[0].Value);

            frmPersonDetails.ShowDialog();
            _RefreshPeopleList();
        }
    }
}
