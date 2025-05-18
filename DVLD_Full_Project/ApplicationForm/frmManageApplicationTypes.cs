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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
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
