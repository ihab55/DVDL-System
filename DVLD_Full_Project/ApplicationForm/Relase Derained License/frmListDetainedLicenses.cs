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
    public partial class frmListDetainedLicenses : Form
    {
        private DataTable _dtDetainedLicenses;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            cbIsReleased.SelectedIndex = 0;
            if (cmbFilter.SelectedIndex == 0)
            {
                textBox1.Visible = cbIsReleased.Visible = false;
                _dtDetainedLicenses.DefaultView.RowFilter = null;
                labNum.Text = dataGridView1.Rows.Count.ToString();
                return;
            }
            if (cmbFilter.Text == "Is Released")
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
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    {
                        FilterColumn = "IsReleased";
                        break;
                    }
                    ;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                labNum.Text = dataGridView1.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                //in this case we deal with numbers not string.
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            labNum.Text = dataGridView1.Rows.Count.ToString();
        }
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((string)dataGridView1.CurrentRow.Cells[6].Value);
            frm.ShowDialog();
        }
        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo showLicesnse = new frmShowLicenseInfo((int)dataGridView1.CurrentRow.Cells[1].Value);
            showLicesnse.ShowDialog();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int _LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(
                clsLicense.Find(_LicenseID).DriverInfo.PersonID);
            frm.ShowDialog();
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null); // Refresh the list after detaining a license
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null,null);
        }

        private void relaseDetaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

            frmListDetainedLicenses_Load(null, null);
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
 _dtDetainedLicenses = clsDetainedLicenses.GetAllDetainedLicenses();

            cmbFilter.SelectedIndex = 0;

            dataGridView1.DataSource = _dtDetainedLicenses;
            labNum.Text = dataGridView1.Rows.Count.ToString();

            dataGridView1.Columns[0].HeaderText = "D.ID";
            dataGridView1.Columns[0].Width = 90;

            dataGridView1.Columns[1].HeaderText = "L.ID";
            dataGridView1.Columns[1].Width = 90;

            dataGridView1.Columns[2].HeaderText = "D.Date";
            dataGridView1.Columns[2].Width = 160;

            dataGridView1.Columns[3].HeaderText = "Is Released";
            dataGridView1.Columns[3].Width = 110;

            dataGridView1.Columns[4].HeaderText = "Fine Fees";
            dataGridView1.Columns[4].Width = 110;

            dataGridView1.Columns[5].HeaderText = "Release Date";
            dataGridView1.Columns[5].Width = 160;

            dataGridView1.Columns[6].HeaderText = "N.No.";
            dataGridView1.Columns[6].Width = 90;

            dataGridView1.Columns[7].HeaderText = "Full Name";
            dataGridView1.Columns[7].Width = 330;

            dataGridView1.Columns[8].HeaderText = "Rlease App.ID";
            dataGridView1.Columns[8].Width = 150;

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
                _dtDetainedLicenses.DefaultView.RowFilter = null;
            else
                //in this case we deal with numbers not string.
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsReleased", FilterValue);

            labNum.Text = dataGridView1.Rows.Count.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cmbFilter.Text == "Detain ID" || cmbFilter.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
