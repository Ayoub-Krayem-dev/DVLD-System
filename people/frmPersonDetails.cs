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
    public partial class frmPersonDetails : Form
    {
        public frmPersonDetails()
        {
            InitializeComponent();
        }

        private int _PersonID { set; get; }
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            ctrlPersonDetials1.LoadCtrl(_PersonID);
        }
        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            
            
        }

        private void lblEditPersonInfo_Click(object sender, EventArgs e)
        {
            frmAddNew frm = new frmAddNew(_PersonID);
            frm.ShowDialog();
            ctrlPersonDetials1.FillDetails(_PersonID);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonDetials1_Load(object sender, EventArgs e)
        {

        }
    }
}
