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

namespace DVLD_Full_Project.ApplicationForm.Applications_Types
{
    public partial class frmListApplicationTypes : Form
    {
        private DataTable _dtApplicationsType;
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtApplicationsType = clsApplicationTypes.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = _dtApplicationsType;
            lblRecordsCount.Text = dgvApplicationTypes.Rows.Count.ToString();

            dgvApplicationTypes.Columns[0].HeaderText = "ID";
            dgvApplicationTypes.Columns[0].Width = 50;

            dgvApplicationTypes.Columns[1].HeaderText = "Title";
            dgvApplicationTypes.Columns[1].Width = 300;

            dgvApplicationTypes.Columns[2].HeaderText = "Fees";
            dgvApplicationTypes.Columns[2].Width = 80;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frmEdit = new frmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frmEdit.ShowDialog();
            frmListApplicationTypes_Load(null, null);
        }
    }
}
