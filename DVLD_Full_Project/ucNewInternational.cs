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
    public partial class ucNewInternational : UserControl
    {
        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int Licenseid)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(Licenseid);
            }
        }
        public ucNewInternational()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            int LicenseID = int.Parse(textBox1.Text.Trim());

            // Add null check to avoid NullReferenceException
            if (clsLicense.IsExists(LicenseID))
            {
                ucLicenseInfo1.LoadDataByLicenseID(LicenseID);
                if (OnLicenseSelected != null && groupBox2.Enabled)
                {
                    OnLicenseSelected(LicenseID);
                }
            }
            else
            {
                MessageBox.Show("License not found or invalid license ID.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void LoadDataByLicenseID(int LicenseID)
        {
            textBox1.Text = LicenseID.ToString();
            EnableFilter(false);
            if (clsLicense.IsExists(LicenseID))
            {
                ucLicenseInfo1.LoadDataByLicenseID(LicenseID);
                if (OnLicenseSelected != null && groupBox2.Enabled)
                {
                    OnLicenseSelected(LicenseID);
                }
            }
            else
            {
                MessageBox.Show("License not found or invalid license ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void EnableFilter(bool enable)
        {
            groupBox2.Enabled = enable;
        }
    }
}
