using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace DVLD
{

    public partial class frmAddNew : Form
    {
        public frmAddNew()
        {
            InitializeComponent();
        }

        public delegate void DataSender(int ID);
        public event DataSender DataBack;
        public int PersonID { set; get; }
        public void DataGet(int ID)
        {
            PersonID = ID;
            DataBack?.Invoke(PersonID);

        }
        public frmAddNew(int PersonID)
        {
            InitializeComponent();
            ctrlPeopleManage1.Databack += DataGet;
            ctrlPeopleManage1.LoadCtrl(PersonID);
           
        }
        private void ctrlPeopleManage1_Load(object sender, EventArgs e)
        {
            
        }

        private void frmAddNew_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
