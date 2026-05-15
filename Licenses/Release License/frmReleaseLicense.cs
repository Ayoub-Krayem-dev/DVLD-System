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
    public partial class frmReleaseLicense : Form
    {
        public frmReleaseLicense()
        {
            InitializeComponent();
        }

        private int _LicenseID { get; set; }

        public frmReleaseLicense(int licenseID)
        {
            InitializeComponent();
            _LicenseID = licenseID;
            ctrlReleaseLicense1.FillDetails(_LicenseID);
        }

        private void ctrlReleaseLicense1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlReleaseLicense1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
