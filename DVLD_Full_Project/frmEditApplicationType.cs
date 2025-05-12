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
    public partial class frmEditApplicationType : Form
    {
        private clsApplicationTypes _applicationTypes;
        public frmEditApplicationType(int id)
        {
            InitializeComponent();
            _applicationTypes = clsApplicationTypes.Find(id);
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
           txtID.Text = _applicationTypes.ID.ToString();
           txtTitle.Text = _applicationTypes.Title.ToString();
            txtFees.Text = _applicationTypes.Fees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _applicationTypes.Fees = decimal.Parse(txtFees.Text);
            _applicationTypes.Title = txtTitle.Text;
            if (_applicationTypes.Save())
            {
                MessageBox.Show("Application Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to Update Application Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
