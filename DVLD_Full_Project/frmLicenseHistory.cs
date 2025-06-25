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
    public partial class frmLicenseHistory : Form
    {
        private int personID;
        public frmLicenseHistory(string NationalNum)
        {
            InitializeComponent();
           ucFilterPerson1.EnableCardWithPersonID(NationalNum, out personID);
        }
        public frmLicenseHistory(int personID)
        {
            InitializeComponent();
            ucFilterPerson1.EnableCardWithPersonID( personID);
            this.personID = personID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            dgLocal.DataSource = clsLicense.GetAllLicebseByPersonID(personID);
            labLocalNum.Text = dgLocal.RowCount.ToString();

            dgInt.DataSource = clsInternationalLicense.GetAllInternationalLicenseByPersonID(personID);
            labIntNum.Text = dgInt.RowCount.ToString();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicesnse showLicesnse = new frmShowLicesnse((int)dgLocal.CurrentRow.Cells[0].Value,true);
            showLicesnse.ShowDialog();
        }
    }
}
