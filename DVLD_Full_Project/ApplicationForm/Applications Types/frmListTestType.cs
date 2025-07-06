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
    public partial class frmListTestTypes : Form
    {
        public frmListTestTypes()
        {
            InitializeComponent();
            CustomizeDataGridView();
            LoadTestTypes();
        }

        private void CustomizeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Add columns
            dataGridView1.Columns.Add("TestTypeID", "ID");
            dataGridView1.Columns.Add("TestTypeTitle", "Test Title");
            dataGridView1.Columns.Add("TestTypeDescription", "Description");
            dataGridView1.Columns.Add("TestTypeFees", "Fees");

            // Customize appearance
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadTestTypes()
        {
            // Add your data loading logic here
            // Example: dataGridView1.DataSource = YourDataAccessLayer.GetTestTypes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _RefreashForm()
        {
            dataGridView1.DataSource = clsApplicationTypes.GetAllApplicationTypes();
            labNum.Text = dataGridView1.RowCount.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreashForm();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frmEditApplicationType = new frmEditApplicationType((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmEditApplicationType.ShowDialog();
            _RefreashForm();
        }
    }
}
