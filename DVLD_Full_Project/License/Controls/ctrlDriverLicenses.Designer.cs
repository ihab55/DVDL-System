namespace DVLD_Full_Project.License.Controls
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbListLicense = new System.Windows.Forms.GroupBox();
            this.ControlTab = new System.Windows.Forms.TabControl();
            this.tabLocal = new System.Windows.Forms.TabPage();
            this.lbCountLocal = new System.Windows.Forms.Label();
            this.dgLocalLicense = new System.Windows.Forms.DataGridView();
            this.lbRecordLocal = new System.Windows.Forms.Label();
            this.tabInternatonal = new System.Windows.Forms.TabPage();
            this.lbCountInt = new System.Windows.Forms.Label();
            this.lbRecordInt = new System.Windows.Forms.Label();
            this.dgInternationalLicense = new System.Windows.Forms.DataGridView();
            this.cmsInterenationalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.InternationalLicenseHistorytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbListLicense.SuspendLayout();
            this.ControlTab.SuspendLayout();
            this.tabLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocalLicense)).BeginInit();
            this.tabInternatonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInternationalLicense)).BeginInit();
            this.cmsInterenationalLicenseHistory.SuspendLayout();
            this.cmsLocalLicenseHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbListLicense
            // 
            this.gbListLicense.Controls.Add(this.ControlTab);
            this.gbListLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListLicense.Location = new System.Drawing.Point(3, 3);
            this.gbListLicense.Name = "gbListLicense";
            this.gbListLicense.Size = new System.Drawing.Size(930, 277);
            this.gbListLicense.TabIndex = 3;
            this.gbListLicense.TabStop = false;
            this.gbListLicense.Text = "Driver License";
            // 
            // ControlTab
            // 
            this.ControlTab.Controls.Add(this.tabLocal);
            this.ControlTab.Controls.Add(this.tabInternatonal);
            this.ControlTab.Location = new System.Drawing.Point(6, 31);
            this.ControlTab.Name = "ControlTab";
            this.ControlTab.SelectedIndex = 0;
            this.ControlTab.Size = new System.Drawing.Size(918, 235);
            this.ControlTab.TabIndex = 0;
            // 
            // tabLocal
            // 
            this.tabLocal.Controls.Add(this.lbCountLocal);
            this.tabLocal.Controls.Add(this.dgLocalLicense);
            this.tabLocal.Controls.Add(this.lbRecordLocal);
            this.tabLocal.Location = new System.Drawing.Point(4, 25);
            this.tabLocal.Name = "tabLocal";
            this.tabLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocal.Size = new System.Drawing.Size(910, 206);
            this.tabLocal.TabIndex = 0;
            this.tabLocal.Text = "Local";
            this.tabLocal.UseVisualStyleBackColor = true;
            // 
            // lbCountLocal
            // 
            this.lbCountLocal.AutoSize = true;
            this.lbCountLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountLocal.Location = new System.Drawing.Point(120, 169);
            this.lbCountLocal.Name = "lbCountLocal";
            this.lbCountLocal.Size = new System.Drawing.Size(20, 22);
            this.lbCountLocal.TabIndex = 15;
            this.lbCountLocal.Text = "0";
            // 
            // dgLocalLicense
            // 
            this.dgLocalLicense.AllowUserToAddRows = false;
            this.dgLocalLicense.AllowUserToDeleteRows = false;
            this.dgLocalLicense.BackgroundColor = System.Drawing.Color.White;
            this.dgLocalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLocalLicense.ContextMenuStrip = this.cmsLocalLicenseHistory;
            this.dgLocalLicense.GridColor = System.Drawing.Color.White;
            this.dgLocalLicense.Location = new System.Drawing.Point(17, 15);
            this.dgLocalLicense.Name = "dgLocalLicense";
            this.dgLocalLicense.ReadOnly = true;
            this.dgLocalLicense.RowHeadersWidth = 51;
            this.dgLocalLicense.RowTemplate.Height = 24;
            this.dgLocalLicense.RowTemplate.ReadOnly = true;
            this.dgLocalLicense.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgLocalLicense.Size = new System.Drawing.Size(874, 141);
            this.dgLocalLicense.TabIndex = 8;
            // 
            // lbRecordLocal
            // 
            this.lbRecordLocal.AutoSize = true;
            this.lbRecordLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordLocal.Location = new System.Drawing.Point(13, 169);
            this.lbRecordLocal.Name = "lbRecordLocal";
            this.lbRecordLocal.Size = new System.Drawing.Size(92, 22);
            this.lbRecordLocal.TabIndex = 14;
            this.lbRecordLocal.Text = "#Records:";
            // 
            // tabInternatonal
            // 
            this.tabInternatonal.Controls.Add(this.lbCountInt);
            this.tabInternatonal.Controls.Add(this.lbRecordInt);
            this.tabInternatonal.Controls.Add(this.dgInternationalLicense);
            this.tabInternatonal.Location = new System.Drawing.Point(4, 25);
            this.tabInternatonal.Name = "tabInternatonal";
            this.tabInternatonal.Padding = new System.Windows.Forms.Padding(3);
            this.tabInternatonal.Size = new System.Drawing.Size(910, 206);
            this.tabInternatonal.TabIndex = 1;
            this.tabInternatonal.Text = "International";
            this.tabInternatonal.UseVisualStyleBackColor = true;
            // 
            // lbCountInt
            // 
            this.lbCountInt.AutoSize = true;
            this.lbCountInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountInt.Location = new System.Drawing.Point(120, 169);
            this.lbCountInt.Name = "lbCountInt";
            this.lbCountInt.Size = new System.Drawing.Size(20, 22);
            this.lbCountInt.TabIndex = 17;
            this.lbCountInt.Text = "0";
            // 
            // lbRecordInt
            // 
            this.lbRecordInt.AutoSize = true;
            this.lbRecordInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordInt.Location = new System.Drawing.Point(13, 169);
            this.lbRecordInt.Name = "lbRecordInt";
            this.lbRecordInt.Size = new System.Drawing.Size(92, 22);
            this.lbRecordInt.TabIndex = 16;
            this.lbRecordInt.Text = "#Records:";
            // 
            // dgInternationalLicense
            // 
            this.dgInternationalLicense.AllowUserToAddRows = false;
            this.dgInternationalLicense.AllowUserToDeleteRows = false;
            this.dgInternationalLicense.BackgroundColor = System.Drawing.Color.White;
            this.dgInternationalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInternationalLicense.ContextMenuStrip = this.cmsInterenationalLicenseHistory;
            this.dgInternationalLicense.GridColor = System.Drawing.Color.White;
            this.dgInternationalLicense.Location = new System.Drawing.Point(17, 15);
            this.dgInternationalLicense.Name = "dgInternationalLicense";
            this.dgInternationalLicense.ReadOnly = true;
            this.dgInternationalLicense.RowHeadersWidth = 51;
            this.dgInternationalLicense.RowTemplate.Height = 24;
            this.dgInternationalLicense.RowTemplate.ReadOnly = true;
            this.dgInternationalLicense.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgInternationalLicense.Size = new System.Drawing.Size(874, 141);
            this.dgInternationalLicense.TabIndex = 9;
            // 
            // cmsInterenationalLicenseHistory
            // 
            this.cmsInterenationalLicenseHistory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInterenationalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InternationalLicenseHistorytoolStripMenuItem});
            this.cmsInterenationalLicenseHistory.Name = "cmsLocalLicenseHistory";
            this.cmsInterenationalLicenseHistory.Size = new System.Drawing.Size(213, 42);
            // 
            // InternationalLicenseHistorytoolStripMenuItem
            // 
            this.InternationalLicenseHistorytoolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.ShowLicenss32;
            this.InternationalLicenseHistorytoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InternationalLicenseHistorytoolStripMenuItem.Name = "InternationalLicenseHistorytoolStripMenuItem";
            this.InternationalLicenseHistorytoolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.InternationalLicenseHistorytoolStripMenuItem.Text = "Show License Info";
            this.InternationalLicenseHistorytoolStripMenuItem.Click += new System.EventHandler(this.InternationalLicenseHistorytoolStripMenuItem_Click);
            // 
            // cmsLocalLicenseHistory
            // 
            this.cmsLocalLicenseHistory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLocalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLocalLicenseHistory.Name = "cmsLocalLicenseHistory";
            this.cmsLocalLicenseHistory.Size = new System.Drawing.Size(227, 70);
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
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbListLicense);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(958, 284);
            this.gbListLicense.ResumeLayout(false);
            this.ControlTab.ResumeLayout(false);
            this.tabLocal.ResumeLayout(false);
            this.tabLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocalLicense)).EndInit();
            this.tabInternatonal.ResumeLayout(false);
            this.tabInternatonal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInternationalLicense)).EndInit();
            this.cmsInterenationalLicenseHistory.ResumeLayout(false);
            this.cmsLocalLicenseHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbListLicense;
        private System.Windows.Forms.TabControl ControlTab;
        private System.Windows.Forms.TabPage tabLocal;
        private System.Windows.Forms.Label lbCountLocal;
        private System.Windows.Forms.DataGridView dgLocalLicense;
        private System.Windows.Forms.Label lbRecordLocal;
        private System.Windows.Forms.TabPage tabInternatonal;
        private System.Windows.Forms.Label lbCountInt;
        private System.Windows.Forms.Label lbRecordInt;
        private System.Windows.Forms.DataGridView dgInternationalLicense;
        private System.Windows.Forms.ContextMenuStrip cmsInterenationalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem InternationalLicenseHistorytoolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}
