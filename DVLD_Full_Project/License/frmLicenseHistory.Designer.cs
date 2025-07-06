namespace DVLD_Full_Project
{
    partial class frmLicenseHistory
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ControlTab = new System.Windows.Forms.TabControl();
            this.tabLocal = new System.Windows.Forms.TabPage();
            this.labLocalNum = new System.Windows.Forms.Label();
            this.dgLocal = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabInternatonal = new System.Windows.Forms.TabPage();
            this.labIntNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgInt = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucFilterPerson1 = new DVLD_Full_Project.Use_Controller.ctrlPersonCardWithFilter();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ControlTab.SuspendLayout();
            this.tabLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocal)).BeginInit();
            this.tabInternatonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInt)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Full_Project.Properties.Resources.license_History72;
            this.pictureBox1.Location = new System.Drawing.Point(12, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ControlTab);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(886, 277);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver License";
            // 
            // ControlTab
            // 
            this.ControlTab.Controls.Add(this.tabLocal);
            this.ControlTab.Controls.Add(this.tabInternatonal);
            this.ControlTab.Location = new System.Drawing.Point(6, 31);
            this.ControlTab.Name = "ControlTab";
            this.ControlTab.SelectedIndex = 0;
            this.ControlTab.Size = new System.Drawing.Size(874, 235);
            this.ControlTab.TabIndex = 0;
            // 
            // tabLocal
            // 
            this.tabLocal.Controls.Add(this.labLocalNum);
            this.tabLocal.Controls.Add(this.dgLocal);
            this.tabLocal.Controls.Add(this.label1);
            this.tabLocal.Location = new System.Drawing.Point(4, 25);
            this.tabLocal.Name = "tabLocal";
            this.tabLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocal.Size = new System.Drawing.Size(866, 206);
            this.tabLocal.TabIndex = 0;
            this.tabLocal.Text = "Local";
            this.tabLocal.UseVisualStyleBackColor = true;
            // 
            // labLocalNum
            // 
            this.labLocalNum.AutoSize = true;
            this.labLocalNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLocalNum.Location = new System.Drawing.Point(120, 169);
            this.labLocalNum.Name = "labLocalNum";
            this.labLocalNum.Size = new System.Drawing.Size(20, 22);
            this.labLocalNum.TabIndex = 15;
            this.labLocalNum.Text = "0";
            // 
            // dgLocal
            // 
            this.dgLocal.AllowUserToAddRows = false;
            this.dgLocal.AllowUserToDeleteRows = false;
            this.dgLocal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgLocal.BackgroundColor = System.Drawing.Color.White;
            this.dgLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLocal.ContextMenuStrip = this.contextMenuStrip1;
            this.dgLocal.GridColor = System.Drawing.Color.White;
            this.dgLocal.Location = new System.Drawing.Point(17, 15);
            this.dgLocal.Name = "dgLocal";
            this.dgLocal.ReadOnly = true;
            this.dgLocal.RowHeadersWidth = 51;
            this.dgLocal.RowTemplate.Height = 24;
            this.dgLocal.RowTemplate.ReadOnly = true;
            this.dgLocal.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgLocal.Size = new System.Drawing.Size(829, 141);
            this.dgLocal.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "#Records:";
            // 
            // tabInternatonal
            // 
            this.tabInternatonal.Controls.Add(this.labIntNum);
            this.tabInternatonal.Controls.Add(this.label3);
            this.tabInternatonal.Controls.Add(this.dgInt);
            this.tabInternatonal.Location = new System.Drawing.Point(4, 25);
            this.tabInternatonal.Name = "tabInternatonal";
            this.tabInternatonal.Padding = new System.Windows.Forms.Padding(3);
            this.tabInternatonal.Size = new System.Drawing.Size(866, 206);
            this.tabInternatonal.TabIndex = 1;
            this.tabInternatonal.Text = "International";
            this.tabInternatonal.UseVisualStyleBackColor = true;
            // 
            // labIntNum
            // 
            this.labIntNum.AutoSize = true;
            this.labIntNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIntNum.Location = new System.Drawing.Point(122, 170);
            this.labIntNum.Name = "labIntNum";
            this.labIntNum.Size = new System.Drawing.Size(20, 22);
            this.labIntNum.TabIndex = 17;
            this.labIntNum.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "#Records:";
            // 
            // dgInt
            // 
            this.dgInt.AllowUserToAddRows = false;
            this.dgInt.AllowUserToDeleteRows = false;
            this.dgInt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInt.BackgroundColor = System.Drawing.Color.White;
            this.dgInt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInt.GridColor = System.Drawing.Color.White;
            this.dgInt.Location = new System.Drawing.Point(19, 17);
            this.dgInt.Name = "dgInt";
            this.dgInt.ReadOnly = true;
            this.dgInt.RowHeadersWidth = 51;
            this.dgInt.RowTemplate.Height = 24;
            this.dgInt.RowTemplate.ReadOnly = true;
            this.dgInt.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgInt.Size = new System.Drawing.Size(829, 141);
            this.dgInt.TabIndex = 9;
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
            this.btnClose.Location = new System.Drawing.Point(767, 599);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 38);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucFilterPerson1
            // 
            this.ucFilterPerson1.Location = new System.Drawing.Point(194, 12);
            this.ucFilterPerson1.Name = "ucFilterPerson1";
            this.ucFilterPerson1.Size = new System.Drawing.Size(704, 308);
            this.ucFilterPerson1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 70);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.ShowLicenss32;
            this.showLicenseInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 635);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucFilterPerson1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ControlTab.ResumeLayout(false);
            this.tabLocal.ResumeLayout(false);
            this.tabLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocal)).EndInit();
            this.tabInternatonal.ResumeLayout(false);
            this.tabInternatonal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInt)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Use_Controller.ctrlPersonCardWithFilter ucFilterPerson1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl ControlTab;
        private System.Windows.Forms.TabPage tabLocal;
        private System.Windows.Forms.TabPage tabInternatonal;
        private System.Windows.Forms.DataGridView dgLocal;
        private System.Windows.Forms.Label labLocalNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labIntNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgInt;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}