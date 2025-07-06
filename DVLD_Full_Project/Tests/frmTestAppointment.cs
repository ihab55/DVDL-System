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
    public partial class frmTestAppointment : Form
    {
        private int _localAppId = -99;
        private enum _enMode { _enVison =1, _enWritten = 2, _enStreet =3 };
        private _enMode _Mode; 
        public frmTestAppointment(int localAppId, int TestType)
        {
            InitializeComponent();
            ucDLAppInfo1.FillLocalAppInfo(localAppId);
            _localAppId = localAppId;
            _Mode = (_enMode)TestType;
            LoadTestVisionData();
        }
        private void LoadTestVisionData()
        {
            dataGridView1.DataSource = clsTestAppointment.GetTestTimeByLocalIDAndTestID(_localAppId,(int)_Mode);
            labNum.Text = dataGridView1.Rows.Count.ToString();
            switch(_Mode)
            {
                case _enMode._enVison:
                    labHead.Text = "Vison Test Appoitment  ";
                    break;
                case _enMode._enWritten:
                    labHead.Text = "Written Test Appoitment";
                    pictureBox1.Image = Properties.Resources.exam72;
                    break;
                case _enMode._enStreet:
                    labHead.Text = "Street Test Appoitment ";
                    pictureBox1.Image = Properties.Resources.car_check72;
                    break;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!clsTestAppointment.IsExists(_localAppId))
            {
                if (clsTestTaken.GetPassTestByAppID(_localAppId) == (int)_Mode)
                {
                    MessageBox.Show($"This AppLiaction {_localAppId} is commpleted this test","Information",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    frmAddEditTest editVison = new frmAddEditTest(_localAppId,(int) _Mode);
                    editVison.ShowDialog();
                    LoadTestVisionData();
                }
            }
            else
            {
                MessageBox.Show($"This Application {_localAppId} Is Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditTest editVison = new frmAddEditTest((int)dataGridView1.CurrentRow.Cells[0].Value,(int) _Mode, (bool)dataGridView1.CurrentRow.Cells[3].Value, true);
            editVison.ShowDialog();
            LoadTestVisionData();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest takeTest = new frmTakeTest((int)dataGridView1.CurrentRow.Cells[0].Value, (bool)dataGridView1.CurrentRow.Cells[3].Value);
            takeTest.ShowDialog();
            LoadTestVisionData();
        }
    }
}
