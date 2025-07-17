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
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID);
            }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled { set { _FilterEnabled = value; 
            gbFilter.Enabled = _FilterEnabled;}
            get { return _FilterEnabled; } }
        public int LicenseID
        {
            get { return ctrlDriverLicenseInfo1.LicenseID; }
        }
        public clsLicense LicenseInfo
        {
            get { return ctrlDriverLicenseInfo1.License; }
        }
        public void RestAllValue() { ctrlDriverLicenseInfo1.RestAllValue(); }
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        public void LoadLicenseInfo(int LicenseID)
        {

            txtSearch.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.LoadInfo(LicenseID);
            if (OnLicenseSelected != null && gbFilter.Enabled)
            {
                OnLicenseSelected(LicenseID);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Focus();
                return;
            }
            LoadLicenseInfo(int.Parse(txtSearch.Text.Trim()));
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            if(e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }
        public void txtLicenseIDFocus()
        {
            txtSearch.Focus();
        }
        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            if (txtSearch.Text.Trim()=="")
            {
                txtSearch.Focus();
                e.Cancel = true;
                errorProvider1.SetError(txtSearch, "Must put a value!!");
            }
            else
            {
                errorProvider1.SetError(txtSearch, null);
            }
        }
    }
}
