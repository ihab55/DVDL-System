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
using DVLD_Full_Project.Global_Class;

namespace DVLD_Full_Project
{
    public partial class frmEditApplicationType : Form
    {
        private clsApplicationTypes _ApplicationTypes;
        public frmEditApplicationType(int ApplicationTypesID)
        {
            InitializeComponent();
            _ApplicationTypes = clsApplicationTypes.Find(ApplicationTypesID);
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
           txtID.Text = _ApplicationTypes.ApplicationTypeID.ToString();
           txtTitle.Text = _ApplicationTypes.Title.ToString();
            txtFees.Text = _ApplicationTypes.Fees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            errorProvider1 = null;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationTypes.Fees = float.Parse(txtFees.Text);
            _ApplicationTypes.Title = txtTitle.Text;
            if (_ApplicationTypes.Save())
            {
                MessageBox.Show("Application Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to Update Application Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (string.IsNullOrEmpty(text.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(text, "must Enter a value");
            }
            else
            {
                errorProvider1.SetError(text, null);
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            txtTitle_Validating(sender, e);
            if (clsValidatoin.IsNumber(txtFees.Text))
            {
                errorProvider1.SetError(txtFees, null);
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Enter a number");
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)|| e.KeyChar == '.' || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
    }
}
