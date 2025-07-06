namespace DVLD_Full_Project
{
    partial class frmListLocalDrivingLicesnseApplications
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.labHead = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmsShowApp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditApp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteApp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCancelApp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSechduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsStrretTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsIssueDrivingLic = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShowPersonLicense = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labNum
            // 
            this.labNum.AutoSize = true;
            this.labNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNum.Location = new System.Drawing.Point(119, 556);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(23, 25);
            this.labNum.TabIndex = 29;
            this.labNum.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 556);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "#Records:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBox1.Location = new System.Drawing.Point(421, 247);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(291, 34);
            this.textBox1.TabIndex = 26;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cmbFilter
            // 
            this.cmbFilter.BackColor = System.Drawing.Color.Silver;
            this.cmbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "(None)",
            "L.D.LAppID",
            "Driving Class",
            "NationalNo",
            "FULL Name",
            "Passed Tests"});
            this.cmbFilter.Location = new System.Drawing.Point(169, 244);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(225, 37);
            this.cmbFilter.TabIndex = 25;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // labHead
            // 
            this.labHead.AutoSize = true;
            this.labHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHead.ForeColor = System.Drawing.Color.Brown;
            this.labHead.Location = new System.Drawing.Point(328, 150);
            this.labHead.Name = "labHead";
            this.labHead.Size = new System.Drawing.Size(765, 54);
            this.labHead.TabIndex = 23;
            this.labHead.Text = "Local Driving License Applications";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 38);
            this.label2.TabIndex = 24;
            this.label2.Text = "Filter By:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 297);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1397, 239);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsShowApp,
            this.toolStripMenuItem1,
            this.cmsEditApp,
            this.cmsDeleteApp,
            this.toolStripMenuItem2,
            this.cmsCancelApp,
            this.toolStripMenuItem3,
            this.cmsSechduleTest,
            this.toolStripMenuItem4,
            this.cmsIssueDrivingLic,
            this.toolStripMenuItem5,
            this.cmsShowLicense,
            this.toolStripMenuItem6,
            this.cmsShowPersonLicense});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(309, 344);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(305, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(305, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(305, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(305, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(305, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(305, 6);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Full_Project.Properties.Resources.home;
            this.pictureBox2.Location = new System.Drawing.Point(805, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = global::DVLD_Full_Project.Properties.Resources.papersADDApp;
            this.btnAdd.Location = new System.Drawing.Point(1310, 224);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 57);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DVLD_Full_Project.Properties.Resources.papers_72;
            this.pictureBox1.Location = new System.Drawing.Point(588, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Full_Project.Properties.Resources.closeIcon;
            this.btnClose.Location = new System.Drawing.Point(1284, 556);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 38);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmsShowApp
            // 
            this.cmsShowApp.Image = global::DVLD_Full_Project.Properties.Resources.ShowDetails;
            this.cmsShowApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsShowApp.Name = "cmsShowApp";
            this.cmsShowApp.Size = new System.Drawing.Size(308, 38);
            this.cmsShowApp.Text = "Show Application Details";
            this.cmsShowApp.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // cmsEditApp
            // 
            this.cmsEditApp.Enabled = false;
            this.cmsEditApp.Image = global::DVLD_Full_Project.Properties.Resources.EditManage_test;
            this.cmsEditApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsEditApp.Name = "cmsEditApp";
            this.cmsEditApp.Size = new System.Drawing.Size(308, 38);
            this.cmsEditApp.Text = "Edit Application";
            this.cmsEditApp.Click += new System.EventHandler(this.eDitApplicationToolStripMenuItem_Click);
            // 
            // cmsDeleteApp
            // 
            this.cmsDeleteApp.Enabled = false;
            this.cmsDeleteApp.Image = global::DVLD_Full_Project.Properties.Resources.deleteApp_32;
            this.cmsDeleteApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsDeleteApp.Name = "cmsDeleteApp";
            this.cmsDeleteApp.Size = new System.Drawing.Size(308, 38);
            this.cmsDeleteApp.Text = "Delete Application";
            this.cmsDeleteApp.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // cmsCancelApp
            // 
            this.cmsCancelApp.Enabled = false;
            this.cmsCancelApp.Image = global::DVLD_Full_Project.Properties.Resources.Cancel_row32;
            this.cmsCancelApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsCancelApp.Name = "cmsCancelApp";
            this.cmsCancelApp.Size = new System.Drawing.Size(308, 38);
            this.cmsCancelApp.Text = "Canel Application";
            this.cmsCancelApp.Click += new System.EventHandler(this.canelApplicationToolStripMenuItem_Click);
            // 
            // cmsSechduleTest
            // 
            this.cmsSechduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsVisionTest,
            this.cmsWrittenTest,
            this.cmsStrretTest});
            this.cmsSechduleTest.Enabled = false;
            this.cmsSechduleTest.Image = global::DVLD_Full_Project.Properties.Resources.test_32;
            this.cmsSechduleTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsSechduleTest.Name = "cmsSechduleTest";
            this.cmsSechduleTest.Size = new System.Drawing.Size(308, 38);
            this.cmsSechduleTest.Text = "Sechdule Tests";
            // 
            // cmsVisionTest
            // 
            this.cmsVisionTest.Enabled = false;
            this.cmsVisionTest.Image = global::DVLD_Full_Project.Properties.Resources.eye32;
            this.cmsVisionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsVisionTest.Name = "cmsVisionTest";
            this.cmsVisionTest.Size = new System.Drawing.Size(247, 38);
            this.cmsVisionTest.Text = "Schedule Vision Test";
            this.cmsVisionTest.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // cmsWrittenTest
            // 
            this.cmsWrittenTest.Enabled = false;
            this.cmsWrittenTest.Image = global::DVLD_Full_Project.Properties.Resources.exam32;
            this.cmsWrittenTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsWrittenTest.Name = "cmsWrittenTest";
            this.cmsWrittenTest.Size = new System.Drawing.Size(247, 38);
            this.cmsWrittenTest.Text = "Schedule Written Test";
            this.cmsWrittenTest.Click += new System.EventHandler(this.sToolStripMenuItem_Click);
            // 
            // cmsStrretTest
            // 
            this.cmsStrretTest.Enabled = false;
            this.cmsStrretTest.Image = global::DVLD_Full_Project.Properties.Resources.car_check_32;
            this.cmsStrretTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsStrretTest.Name = "cmsStrretTest";
            this.cmsStrretTest.Size = new System.Drawing.Size(247, 38);
            this.cmsStrretTest.Text = "Schedule Street Test";
            this.cmsStrretTest.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // cmsIssueDrivingLic
            // 
            this.cmsIssueDrivingLic.Enabled = false;
            this.cmsIssueDrivingLic.Image = global::DVLD_Full_Project.Properties.Resources.IssueBtn;
            this.cmsIssueDrivingLic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsIssueDrivingLic.Name = "cmsIssueDrivingLic";
            this.cmsIssueDrivingLic.Size = new System.Drawing.Size(308, 38);
            this.cmsIssueDrivingLic.Text = "Issue Driving License (First Time)";
            this.cmsIssueDrivingLic.Click += new System.EventHandler(this.issueDrivingLicToolStripMenuItem_Click);
            // 
            // cmsShowLicense
            // 
            this.cmsShowLicense.Image = global::DVLD_Full_Project.Properties.Resources.ShowLicenss32;
            this.cmsShowLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsShowLicense.Name = "cmsShowLicense";
            this.cmsShowLicense.Size = new System.Drawing.Size(308, 38);
            this.cmsShowLicense.Text = "Show License";
            this.cmsShowLicense.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // cmsShowPersonLicense
            // 
            this.cmsShowPersonLicense.Image = global::DVLD_Full_Project.Properties.Resources.license_History32;
            this.cmsShowPersonLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsShowPersonLicense.Name = "cmsShowPersonLicense";
            this.cmsShowPersonLicense.Size = new System.Drawing.Size(308, 38);
            this.cmsShowPersonLicense.Text = "Show Person License History";
            this.cmsShowPersonLicense.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // frmLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 598);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.labHead);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmLocalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label labHead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmsShowApp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmsEditApp;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteApp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cmsCancelApp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem cmsSechduleTest;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem cmsIssueDrivingLic;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem cmsShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem cmsShowPersonLicense;
        private System.Windows.Forms.ToolStripMenuItem cmsVisionTest;
        private System.Windows.Forms.ToolStripMenuItem cmsWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem cmsStrretTest;
    }
}