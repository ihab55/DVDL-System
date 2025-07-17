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
    public partial class frmTakeTest : Form
    {
        private clsTestTaken _TestTaken ;
        private int _TestAppointmentID;
        public frmTakeTest(int TestAppointmentID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
           ctrlSecheduledTest1.TestTypeID = TestTypeID;
           _TestAppointmentID = TestAppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
             )
            {
                return;
            }
            _TestTaken.TestAppointmentID = _TestAppointmentID;
            _TestTaken.TestResult = rbPass.Checked;
            _TestTaken.Notes = txtNotes.Text;
            _TestTaken.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestTaken.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else{
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
            this.Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSecheduledTest1.LoadInfo(_TestAppointmentID);
            int TestID = ctrlSecheduledTest1.TestID;
            if (TestID == -99)
            {
                _TestTaken = new clsTestTaken();
            }
            else
            {
                _TestTaken = clsTestTaken.Find(TestID);
                rbFail.Checked = !_TestTaken.TestResult;
                txtNotes.Text = _TestTaken.Notes;
                btnSave.Enabled = rbFail.Enabled = rbPass.Enabled = txtNotes.Enabled = false;
                lblUserMessage.Visible = true;
            }
        }
    }
}
