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
    public partial class frmListInternationalLicesnseApplications : Form
    {
        private DataTable _PrintDv;
        private clsInternationalLicense IntLic ;
        public frmListInternationalLicesnseApplications()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmInternationalLicenses_Load(object sender, EventArgs e)
        {
            _PrintDv = clsInternationalLicense.GetAllIntLicense();

            dataGridView1.DataSource = _PrintDv;
            cmbFilter.SelectedIndex = 0;
            labNum.Text = dataGridView1.Rows.Count.ToString();

            dataGridView1.Columns[0].HeaderText = "Int.License ID";
            dataGridView1.Columns[0].Width = 160;

            dataGridView1.Columns[1].HeaderText = "Application ID";
            dataGridView1.Columns[1].Width = 150;

            dataGridView1.Columns[2].HeaderText = "Driver ID";
            dataGridView1.Columns[2].Width = 130;

            dataGridView1.Columns[3].HeaderText = "L.License ID";
            dataGridView1.Columns[3].Width = 130;

            dataGridView1.Columns[4].HeaderText = "Issue Date";
            dataGridView1.Columns[4].Width = 180;

            dataGridView1.Columns[5].HeaderText = "Expiration Date";
            dataGridView1.Columns[5].Width = 180;

            dataGridView1.Columns[6].HeaderText = "Is Active";
            dataGridView1.Columns[6].Width = 120;
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            cbIsReleased.SelectedIndex = 0;
            if (cmbFilter.SelectedIndex == 0)
            {
                textBox1.Visible = cbIsReleased.Visible = false;
                _PrintDv.DefaultView.RowFilter = "";
                labNum.Text = dataGridView1.Rows.Count.ToString();
                return;
            }
            if (cmbFilter.Text == "Is Active")
            {
                textBox1.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {
                textBox1.Visible = true;
                cbIsReleased.Visible = false;
                textBox1.Focus();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cmbFilter.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    }
                    ;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                _PrintDv.DefaultView.RowFilter = "";
                labNum.Text = dataGridView1.Rows.Count.ToString();
                return;
            }



            _PrintDv.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());

            labNum.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication newInternational = new frmNewInternationalLicenseApplication();
            newInternational.ShowDialog();
        }

        private void showPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IntLic = clsInternationalLicense.Find((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmShowPersonLicenseHistory frmLicenseHistory = new frmShowPersonLicenseHistory(IntLic.DriverInfo.PersonInfo.PersonID);
            frmLicenseHistory.ShowDialog();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntLic = clsInternationalLicense.Find((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmShowPersonInfo frmCardDetails = new frmShowPersonInfo(IntLic.DriverInfo.PersonInfo.PersonID);
            frmCardDetails.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo frmInternationalLicenseInfo = new frmInternationalLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmInternationalLicenseInfo.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _PrintDv.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _PrintDv.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsActive", FilterValue);

            labNum.Text = dataGridView1.Rows.Count.ToString();

        }
    }
}
