namespace DVLD_Full_Project
{
    partial class frmNewLocalDrivingLicenseAPP
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
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ucFilterPerson1 = new DVLD_Full_Project.Use_Controller.ucFilterPerson();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCreatedby = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.labCreatedby = new System.Windows.Forms.Label();
            this.txtApplicationfees = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtDate = new System.Windows.Forms.Label();
            this.txtApplicationID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labApplicationfees = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.Label();
            this.labDate = new System.Windows.Forms.Label();
            this.labApplicationID = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.labHead = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_Full_Project.Properties.Resources.SaveIcon;
            this.btnSave.Location = new System.Drawing.Point(630, 445);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 40);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 47);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(736, 383);
            this.tabControl1.TabIndex = 55;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.ucFilterPerson1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(728, 354);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personal Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = global::DVLD_Full_Project.Properties.Resources.nextIcon;
            this.btnNext.Location = new System.Drawing.Point(597, 308);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(113, 40);
            this.btnNext.TabIndex = 54;
            this.btnNext.Text = "Next";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ucFilterPerson1
            // 
            this.ucFilterPerson1.Location = new System.Drawing.Point(6, 3);
            this.ucFilterPerson1.Name = "ucFilterPerson1";
            this.ucFilterPerson1.Size = new System.Drawing.Size(704, 303);
            this.ucFilterPerson1.TabIndex = 0;
            this.ucFilterPerson1.OnPersonSelected += new System.Action<int>(this.ucFilterPerson1_OnPersonSelected);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtCreatedby);
            this.tabPage2.Controls.Add(this.pictureBox5);
            this.tabPage2.Controls.Add(this.labCreatedby);
            this.tabPage2.Controls.Add(this.txtApplicationfees);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.txtDate);
            this.tabPage2.Controls.Add(this.txtApplicationID);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.labApplicationfees);
            this.tabPage2.Controls.Add(this.txtClass);
            this.tabPage2.Controls.Add(this.labDate);
            this.tabPage2.Controls.Add(this.labApplicationID);
            this.tabPage2.Enabled = false;
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtCreatedby
            // 
            this.txtCreatedby.AutoSize = true;
            this.txtCreatedby.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreatedby.Location = new System.Drawing.Point(364, 252);
            this.txtCreatedby.Name = "txtCreatedby";
            this.txtCreatedby.Size = new System.Drawing.Size(45, 25);
            this.txtCreatedby.TabIndex = 17;
            this.txtCreatedby.Text = "???";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Full_Project.Properties.Resources.login;
            this.pictureBox5.Location = new System.Drawing.Point(290, 250);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 29);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // labCreatedby
            // 
            this.labCreatedby.AutoSize = true;
            this.labCreatedby.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCreatedby.Location = new System.Drawing.Point(123, 250);
            this.labCreatedby.Name = "labCreatedby";
            this.labCreatedby.Size = new System.Drawing.Size(147, 29);
            this.labCreatedby.TabIndex = 15;
            this.labCreatedby.Text = "Created by:";
            // 
            // txtApplicationfees
            // 
            this.txtApplicationfees.AutoSize = true;
            this.txtApplicationfees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationfees.Location = new System.Drawing.Point(364, 204);
            this.txtApplicationfees.Name = "txtApplicationfees";
            this.txtApplicationfees.Size = new System.Drawing.Size(45, 25);
            this.txtApplicationfees.TabIndex = 14;
            this.txtApplicationfees.Text = "???";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Class1-Small Motorcycle",
            "Class2-Heavy Motorcycle License",
            "Class3-Ordinary driving license",
            "Class4-Commercial",
            "Class5-Agricultural",
            "Class6-Small and medium bus",
            "Class7-Truck and heavy vehicle"});
            this.comboBox1.Location = new System.Drawing.Point(369, 156);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 24);
            this.comboBox1.TabIndex = 13;
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(364, 108);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(45, 25);
            this.txtDate.TabIndex = 12;
            this.txtDate.Text = "???";
            // 
            // txtApplicationID
            // 
            this.txtApplicationID.AutoSize = true;
            this.txtApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationID.Location = new System.Drawing.Point(364, 58);
            this.txtApplicationID.Name = "txtApplicationID";
            this.txtApplicationID.Size = new System.Drawing.Size(52, 29);
            this.txtApplicationID.TabIndex = 8;
            this.txtApplicationID.Text = "???";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Full_Project.Properties.Resources.taxes;
            this.pictureBox4.Location = new System.Drawing.Point(290, 202);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 29);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Full_Project.Properties.Resources.id_reload;
            this.pictureBox3.Location = new System.Drawing.Point(290, 154);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Full_Project.Properties.Resources.DateIcon;
            this.pictureBox2.Location = new System.Drawing.Point(290, 106);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Full_Project.Properties.Resources.title;
            this.pictureBox1.Location = new System.Drawing.Point(290, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // labApplicationfees
            // 
            this.labApplicationfees.AutoSize = true;
            this.labApplicationfees.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labApplicationfees.Location = new System.Drawing.Point(63, 202);
            this.labApplicationfees.Name = "labApplicationfees";
            this.labApplicationfees.Size = new System.Drawing.Size(207, 29);
            this.labApplicationfees.TabIndex = 3;
            this.labApplicationfees.Text = "Application fees:";
            // 
            // txtClass
            // 
            this.txtClass.AutoSize = true;
            this.txtClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClass.Location = new System.Drawing.Point(87, 154);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(183, 29);
            this.txtClass.TabIndex = 2;
            this.txtClass.Text = "License Class:";
            // 
            // labDate
            // 
            this.labDate.AutoSize = true;
            this.labDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDate.Location = new System.Drawing.Point(59, 106);
            this.labDate.Name = "labDate";
            this.labDate.Size = new System.Drawing.Size(211, 29);
            this.labDate.TabIndex = 1;
            this.labDate.Text = "Application Date:";
            // 
            // labApplicationID
            // 
            this.labApplicationID.AutoSize = true;
            this.labApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labApplicationID.Location = new System.Drawing.Point(42, 58);
            this.labApplicationID.Name = "labApplicationID";
            this.labApplicationID.Size = new System.Drawing.Size(228, 29);
            this.labApplicationID.TabIndex = 0;
            this.labApplicationID.Text = "D.L Application ID:";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Full_Project.Properties.Resources.closeIcon;
            this.btnClose.Location = new System.Drawing.Point(510, 445);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 40);
            this.btnClose.TabIndex = 56;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labHead
            // 
            this.labHead.AutoSize = true;
            this.labHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHead.ForeColor = System.Drawing.Color.Red;
            this.labHead.Location = new System.Drawing.Point(36, 6);
            this.labHead.Name = "labHead";
            this.labHead.Size = new System.Drawing.Size(608, 38);
            this.labHead.TabIndex = 54;
            this.labHead.Text = "New Local Driving License Application";
            // 
            // frmNewLocalDrivingLicenseAPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 491);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labHead);
            this.Name = "frmNewLocalDrivingLicenseAPP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnNext;
        private Use_Controller.ucFilterPerson ucFilterPerson1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label txtApplicationID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labApplicationfees;
        private System.Windows.Forms.Label txtClass;
        private System.Windows.Forms.Label labDate;
        private System.Windows.Forms.Label labApplicationID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labHead;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label txtApplicationfees;
        private System.Windows.Forms.Label labCreatedby;
        private System.Windows.Forms.Label txtCreatedby;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}