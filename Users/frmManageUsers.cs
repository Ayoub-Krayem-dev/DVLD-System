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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            Refresh();

            txtbFilterBy.Visible = false;
            cbIsActive.Visible = false;
            cbFilterBy.SelectedText = "None";
            cbFilterBy.Items.Add("PersonID");
            cbFilterBy.Items.Add("UserID");
            cbFilterBy.Items.Add("IsActive");
            cbFilterBy.Items.Add("FullName");
            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("UserName");
            cbIsActive.Visible = false;
    

            cbIsActive.Items.Add("Yes");
            cbIsActive.Items.Add("No");
            cbIsActive.Items.Add("All");




        }
        private void Refresh()
        {
            dgvUserList.DataSource = clsUserBuisness.GetAllUsers();

            lblRecordsNumber.Text = clsUserBuisness.GetAllUsers().Rows.Count.ToString();

            dgvUserList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUserList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void lblManageUsers_Click(object sender, EventArgs e)
        {

        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddEditUser = new frmAddEditUser(-1);

            frmAddEditUser.ShowDialog();

            Refresh();
        }
        private void txtbFilterBy_TextChanged(object sender, EventArgs e)
        {
            int ID = 0;
            if (cbFilterBy.SelectedItem.ToString() == "PersonID"|| cbFilterBy.SelectedItem.ToString() == "UserID")
            {
               
                if (int.TryParse(txtbFilterBy.Text, out int PersonID))
                {
                    ID = PersonID;
                    dgvUserList.DataSource = clsUserBuisness.FilterByInt(cbFilterBy.Text, ID);

                }

               

            }
            else if (cbFilterBy.SelectedItem.ToString() == "UserName")
            {
                dgvUserList.DataSource = clsUserBuisness.FilterByUserName(cbFilterBy.Text, txtbFilterBy.Text);
            }

            else if (cbFilterBy.SelectedItem.ToString() == "FullName")
            {
                dgvUserList.DataSource = clsUserBuisness.FilterByFullName(cbFilterBy.Text, txtbFilterBy.Text);
            }

            
            else if (cbFilterBy.SelectedItem.ToString() == "None")

            {
                
                dgvUserList.DataSource = clsUserBuisness.GetAllUsers();
            }

            lblRecordsNumber.Text = (dgvUserList.RowCount-1).ToString();

        }

        private void txtbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "UserID" || cbFilterBy.Text == "PersonID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
               
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "None")
            {
                txtbFilterBy.Visible = false;
                cbIsActive.Visible = false;
            }

         
             else if (cbFilterBy.SelectedItem.ToString() == "IsActive")
            {
                txtbFilterBy.Visible = false;

                cbIsActive.Visible = true;
            }
            else
            {
                txtbFilterBy.Visible = true;

                cbIsActive.Visible = false;
            }


        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.SelectedItem.ToString() == "Yes")
            {
                dgvUserList.DataSource = clsUserBuisness.FilterByIsActive(cbFilterBy.Text, true);
            }

            else if (cbIsActive.SelectedItem.ToString() == "No")
            {
                dgvUserList.DataSource = clsUserBuisness.FilterByIsActive(cbFilterBy.Text, false);
            }

            else
            {
                dgvUserList.DataSource = clsUserBuisness.GetAllUsers();

            }
            lblRecordsNumber.Text = (dgvUserList.RowCount-1).ToString();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddEditUser = new frmAddEditUser((int)dgvUserList.CurrentRow.Cells[0].Value);

            frmAddEditUser.ShowDialog();

            Refresh();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resuslt = MessageBox.Show("Are you sure you want to Delete User ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resuslt == DialogResult.Yes)
            {
                if (clsUserBuisness.DeleteUser((int)dgvUserList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User deleted successfully");
                }
                else
                {
                    MessageBox.Show("User deleted failed");

                }
                Refresh();
            }

        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword((int)dgvUserList.CurrentRow.Cells[0].Value);
            frmChangePassword.LoadCltr();
            frmChangePassword.ShowDialog();
            Refresh();
        }

        private void detailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowDetails frmShowDetails = new frmShowDetails((int)dgvUserList.CurrentRow.Cells[0].Value);
            frmShowDetails.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddEditUser = new frmAddEditUser(-1);

            frmAddEditUser.ShowDialog();

            Refresh();
        }

        private void dgvUserList_DoubleClick(object sender, EventArgs e)
        {
            frmShowDetails frmShowDetails = new frmShowDetails((int)dgvUserList.CurrentRow.Cells[0].Value);
            frmShowDetails.ShowDialog();
        }
    }
}
