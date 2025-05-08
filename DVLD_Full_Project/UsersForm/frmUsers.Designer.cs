namespace DVLD_Full_Project
{
    partial class frmUsers
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.addNewPersonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sendMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.labHead = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 305);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1397, 239);
            this.dataGridView1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.addNewPersonToolStripMenuItem,
            this.addNewPersonToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sendMailToolStripMenuItem,
            this.phoneToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 272);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.ShowDetails;
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(203, 38);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(200, 6);
            // 
            // addNewPersonToolStripMenuItem1
            // 
            this.addNewPersonToolStripMenuItem1.Image = global::DVLD_Full_Project.Properties.Resources.AddPeropleIcon;
            this.addNewPersonToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewPersonToolStripMenuItem1.Name = "addNewPersonToolStripMenuItem1";
            this.addNewPersonToolStripMenuItem1.Size = new System.Drawing.Size(203, 38);
            this.addNewPersonToolStripMenuItem1.Text = "Add New Person";
            this.addNewPersonToolStripMenuItem1.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.EditImageIcon;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(203, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.DeleteImageIcon;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(200, 6);
            // 
            // sendMailToolStripMenuItem
            // 
            this.sendMailToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.mailImageIcon;
            this.sendMailToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendMailToolStripMenuItem.Name = "sendMailToolStripMenuItem";
            this.sendMailToolStripMenuItem.Size = new System.Drawing.Size(203, 38);
            this.sendMailToolStripMenuItem.Text = "Send Mail";
            // 
            // phoneToolStripMenuItem
            // 
            this.phoneToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.PhoneImageIcon;
            this.phoneToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.phoneToolStripMenuItem.Name = "phoneToolStripMenuItem";
            this.phoneToolStripMenuItem.Size = new System.Drawing.Size(203, 38);
            this.phoneToolStripMenuItem.Text = "Phone";
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
            this.btnClose.Location = new System.Drawing.Point(1284, 564);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 38);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = global::DVLD_Full_Project.Properties.Resources.AddPeropleIcon;
            this.btnAdd.Location = new System.Drawing.Point(1310, 232);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 57);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBox1.Location = new System.Drawing.Point(421, 255);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(291, 34);
            this.textBox1.TabIndex = 15;
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
            "UserID",
            "PersonID",
            "FullName",
            "UserName",
            "IsActive"});
            this.cmbFilter.Location = new System.Drawing.Point(169, 252);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(225, 37);
            this.cmbFilter.TabIndex = 14;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // labHead
            // 
            this.labHead.AutoSize = true;
            this.labHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHead.ForeColor = System.Drawing.Color.Brown;
            this.labHead.Location = new System.Drawing.Point(540, 158);
            this.labHead.Name = "labHead";
            this.labHead.Size = new System.Drawing.Size(340, 54);
            this.labHead.TabIndex = 12;
            this.labHead.Text = "Manage Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 38);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filter By:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DVLD_Full_Project.Properties.Resources.programmer_config;
            this.pictureBox1.Location = new System.Drawing.Point(588, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // labNum
            // 
            this.labNum.AutoSize = true;
            this.labNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNum.Location = new System.Drawing.Point(119, 564);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(23, 25);
            this.labNum.TabIndex = 18;
            this.labNum.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 564);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "#Records:";
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 598);
            this.ControlBox = false;
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
            this.Name = "frmUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label labHead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sendMailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneToolStripMenuItem;
    }
}