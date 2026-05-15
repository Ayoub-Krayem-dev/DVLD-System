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
    public partial class frmShowDetails : Form
    {
        public frmShowDetails()
        {
            InitializeComponent();
        }
        private int _UserID { set; get; }

        private int _PersonID { set; get; }
       
        public frmShowDetails(int UserID)
        {
            this._UserID = UserID;
            InitializeComponent();
        }
        private clsUserBuisness _User;
       
        private void frmShowDetails_Load(object sender, EventArgs e)
        {
            _User = clsUserBuisness.FindByUserID(_UserID);
           
          

            if(_User != null)
            {
                if (_User.PersonID != -1)
                {
                    ctrlPersonDetials1.FillDetails(_User.PersonID);

                }
                lblIsActive.Text = _User.IsActive == true ? "Yes" : "No";
                lblUserID.Text = _User.UserID.ToString();

                lblUserName.Text = _User.UserName;
            }
            

        }

        private void ctrlPersonDetials1_Load(object sender, EventArgs e)
        {

        }

        private void DataGet(int PersonID)
        {
            _PersonID = PersonID;
            ctrlPersonDetials1.FillDetails(_PersonID);
        }

        private void lblEditPersonInfo_Click(object sender, EventArgs e)
        {
            if (_User != null)
            {
                frmAddNew frm = new frmAddNew(_User.PersonID);
                frm.DataBack += DataGet;
                frm.ShowDialog();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
