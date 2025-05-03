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
    public partial class frmPeople : Form
    {
        private DataTable Printdt;
        private string _FilterSearch = "";
        public frmPeople()
        {
            InitializeComponent();
        }
        private string _GendorTypeString(byte x)
        {
            return (x == 0) ? "Male" : "Female";
        }
        private void _RefreashData()
        {
            DataTable Getdt = clsPerson.GetAllPeople();
            Printdt = new DataTable();
            Printdt.Columns.Add("PersonID", typeof(int));
            Printdt.Columns.Add("National No", typeof(string));
            Printdt.Columns.Add("First Name", typeof(string));
            Printdt.Columns.Add("Second Name", typeof(string));
            Printdt.Columns.Add("Third Name", typeof(string));
            Printdt.Columns.Add("Last Name", typeof(string));
            Printdt.Columns.Add("Gendor", typeof(string));
            Printdt.Columns.Add("Date Of Birth", typeof(DateTime));
            Printdt.Columns.Add("Nationality", typeof(string));
            Printdt.Columns.Add("Phone", typeof(string));
            Printdt.Columns.Add("Email", typeof(string));
            foreach (DataRow row in Getdt.Rows) {
                Printdt.Rows.Add(row["PersonID"], row["NationalNo"], row["FirstName"], row["SecondName"], 
                    row["ThirdName"], row["LastName"],_GendorTypeString((byte)row["Gendor"]), 
                    row["DateOfBirth"],clsCountry.Find(int.Parse(row["NationalityCountryID"].ToString())).CountryName, row["Phone"], row["Email"]);
            }
            dataGridView1.DataSource = Printdt;
            labNum.Text = Getdt.Rows.Count.ToString();
            cmbFilter.SelectedIndex = 0;
        }
        private void frmPeople_Load(object sender, EventArgs e)
        {
            _RefreashData();
        }


        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex==0)
            {
                textBox1.Visible = false;
                _RefreashData();
                return;
            }
            textBox1.Visible = true;
            switch (cmbFilter.Text)
            {
                case "Person ID":
                    _FilterSearch = "PersonID";
                    break;
                case "National ID":
                    _FilterSearch = "National No";
                    break;
                case "First Name":
                    _FilterSearch = "First Name";
                    break;
                case "Second Name":
                    _FilterSearch = "Second Name";
                    break;
                case "Third Name":
                    _FilterSearch = "Third Name";
                    break;
                case "Last Name":
                    _FilterSearch = "Last Name";
                    break;
                case "Email":
                    _FilterSearch = "Email";
                    break;
                case "Phone ":
                    _FilterSearch = "Phone";
                    break;
                case "Gendor":
                    _FilterSearch = "Gendor";
                    break;
                default:
                    break;
            }
        }
        private void FilterDataGridView(string columnName,string searchText)
        {
            DataView dataTable = Printdt.DefaultView;

            if (Printdt.Columns[columnName].DataType == typeof(string))
            {
                dataTable.RowFilter = $"[{columnName}] LIKE '%{searchText}%'";
            }
            else
            {
                // For non-string columns, use an equality filter or other appropriate logic
                if (int.TryParse(searchText, out int numericValue))
                {
                    dataTable.RowFilter = $"[{columnName}] = {numericValue}";
                }
            }

            }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit(-1);
            frm.ShowDialog();
            _RefreashData();
        }

        private void addNewPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit(-1);
            frm.ShowDialog();

            _RefreashData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreashData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsPerson.Delete((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreashData();
            }
            else
            {
                MessageBox.Show("Error in Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this futer Will Implament in futur", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this futer Will Implament in futur", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCardDetailsPerson frm = new frmCardDetailsPerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreashData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView(_FilterSearch, textBox1.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
