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
    public partial class frmEditManageTest : Form
    {
        clsManageTests currentTest;
        public frmEditManageTest(int id)
        {
            InitializeComponent();
            currentTest = clsManageTests.Find(id);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditManageTest_Load(object sender, EventArgs e)
        {
            
            txtID.Text = currentTest.id.ToString();
            txtTitle.Text = currentTest.Title;
            txtDescription.Text = currentTest.Description;
            txtFees.Text = currentTest.Fees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            currentTest.Title = txtTitle.Text;
            currentTest.Description = txtDescription.Text;
            currentTest.Fees = decimal.Parse(txtFees.Text);
            if (currentTest.save())
            {
                MessageBox.Show("Test updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
