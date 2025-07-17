using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;

namespace DVLD_Full_Project
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _PersonID = -99;
        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
        }
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -99)
            {
                ucFilterPerson1.LoadPersonInfo(_PersonID);
                ucFilterPerson1.EnableFilter = false;
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ucFilterPerson1.FocusOnFilter();
                ucFilterPerson1.EnableFilter = true;
            }
        }

        private void ucFilterPerson1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
        }
    }
}
