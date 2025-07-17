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
    public partial class frmEditTestType : Form
    {
        private clsTestType _TestType;
        public frmEditTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestType = clsTestType.Find(TestTypeID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            errorProvider1 = null;
            this.Close();
        }

        private void frmEditManageTest_Load(object sender, EventArgs e)
        {
            
            txtID.Text = ((int) _TestType.TestTypeID).ToString();
            txtTitle.Text = _TestType.TestTitle;
            txtDescription.Text = _TestType.TestDescription;
            txtFees.Text = _TestType.TestFees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some input are invalied, Checked it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            _TestType.TestTitle = txtTitle.Text;
            _TestType.TestDescription = txtDescription.Text;
            _TestType.TestFees = float.Parse(txtFees.Text);
            if (_TestType.Save())
            {
                MessageBox.Show("Test updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNotNull_Validating(object sender, CancelEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (string.IsNullOrEmpty(text.Text.Trim()))
            {
                e.Cancel = false;
                errorProvider1.SetError(text, "you must enter a value");
            }
            else
            {
                errorProvider1.SetError(text,null);
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            txtNotNull_Validating(sender, e);
            if (clsValidatoin.IsNumber(txtFees.Text))
            {
                errorProvider1.SetError(txtFees, null);
            }
            else
            {
                errorProvider1.SetError(txtFees, "you must enter a number");
                e.Cancel = false;
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == '.')
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
