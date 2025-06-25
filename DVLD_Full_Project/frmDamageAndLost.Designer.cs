namespace DVLD_Full_Project
{
    partial class frmDamageAndLost
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lnkShowInfo = new System.Windows.Forms.LinkLabel();
            this.lnkShowHistory = new System.Windows.Forms.LinkLabel();
            this.labHead = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLostLicemse = new System.Windows.Forms.RadioButton();
            this.rbDamagedLicense = new System.Windows.Forms.RadioButton();
            this.ucNewInternational1 = new DVLD_Full_Project.ucNewInternational();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.labCreatedBy = new System.Windows.Forms.Label();
            this.txtOldLicenseID = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.labOldLicenseID = new System.Windows.Forms.Label();
            this.txtID_IntLicense = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.labID_RLicense = new System.Windows.Forms.Label();
            this.txtFees = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.labFees = new System.Windows.Forms.Label();
            this.txtAppDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labAppDate = new System.Windows.Forms.Label();
            this.txtID_RApp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labID_IntApp = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_Full_Project.Properties.Resources.id_reload;
            this.btnSave.Location = new System.Drawing.Point(786, 739);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(306, 40);
            this.btnSave.TabIndex = 76;
            this.btnSave.Text = "Issue Replacment";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Full_Project.Properties.Resources.closeIcon;
            this.btnClose.Location = new System.Drawing.Point(612, 739);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 40);
            this.btnClose.TabIndex = 77;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lnkShowInfo
            // 
            this.lnkShowInfo.AutoSize = true;
            this.lnkShowInfo.Enabled = false;
            this.lnkShowInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowInfo.Location = new System.Drawing.Point(233, 739);
            this.lnkShowInfo.Name = "lnkShowInfo";
            this.lnkShowInfo.Size = new System.Drawing.Size(197, 22);
            this.lnkShowInfo.TabIndex = 75;
            this.lnkShowInfo.TabStop = true;
            this.lnkShowInfo.Text = "Show New License Info";
            this.lnkShowInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowInfo_LinkClicked);
            // 
            // lnkShowHistory
            // 
            this.lnkShowHistory.AutoSize = true;
            this.lnkShowHistory.Enabled = false;
            this.lnkShowHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowHistory.Location = new System.Drawing.Point(12, 739);
            this.lnkShowHistory.Name = "lnkShowHistory";
            this.lnkShowHistory.Size = new System.Drawing.Size(183, 22);
            this.lnkShowHistory.TabIndex = 74;
            this.lnkShowHistory.TabStop = true;
            this.lnkShowHistory.Text = "Show License History";
            this.lnkShowHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowHistory_LinkClicked);
            // 
            // labHead
            // 
            this.labHead.AutoSize = true;
            this.labHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHead.ForeColor = System.Drawing.Color.Brown;
            this.labHead.Location = new System.Drawing.Point(164, -4);
            this.labHead.Name = "labHead";
            this.labHead.Size = new System.Drawing.Size(759, 54);
            this.labHead.TabIndex = 73;
            this.labHead.Text = "Replacment for Damaged License";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLostLicemse);
            this.groupBox1.Controls.Add(this.rbDamagedLicense);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(722, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 88);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacment for";
            // 
            // rbLostLicemse
            // 
            this.rbLostLicemse.AutoSize = true;
            this.rbLostLicemse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLostLicemse.Location = new System.Drawing.Point(104, 49);
            this.rbLostLicemse.Name = "rbLostLicemse";
            this.rbLostLicemse.Size = new System.Drawing.Size(130, 22);
            this.rbLostLicemse.TabIndex = 1;
            this.rbLostLicemse.Text = "Lost Licemse";
            this.rbLostLicemse.UseVisualStyleBackColor = true;
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.Checked = true;
            this.rbDamagedLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDamagedLicense.Location = new System.Drawing.Point(104, 21);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(163, 22);
            this.rbDamagedLicense.TabIndex = 0;
            this.rbDamagedLicense.TabStop = true;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UseVisualStyleBackColor = true;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // ucNewInternational1
            // 
            this.ucNewInternational1.Location = new System.Drawing.Point(-5, 44);
            this.ucNewInternational1.Name = "ucNewInternational1";
            this.ucNewInternational1.Size = new System.Drawing.Size(1097, 518);
            this.ucNewInternational1.TabIndex = 78;
            this.ucNewInternational1.OnLicenseSelected += new System.Action<int>(this.ucNewInternational1_OnLicenseSelected);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCreatedBy);
            this.groupBox2.Controls.Add(this.pictureBox8);
            this.groupBox2.Controls.Add(this.labCreatedBy);
            this.groupBox2.Controls.Add(this.txtOldLicenseID);
            this.groupBox2.Controls.Add(this.pictureBox6);
            this.groupBox2.Controls.Add(this.labOldLicenseID);
            this.groupBox2.Controls.Add(this.txtID_IntLicense);
            this.groupBox2.Controls.Add(this.pictureBox5);
            this.groupBox2.Controls.Add(this.labID_RLicense);
            this.groupBox2.Controls.Add(this.txtFees);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.labFees);
            this.groupBox2.Controls.Add(this.txtAppDate);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.labAppDate);
            this.groupBox2.Controls.Add(this.txtID_RApp);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.labID_IntApp);
            this.groupBox2.Location = new System.Drawing.Point(5, 563);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1081, 170);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.AutoSize = true;
            this.txtCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreatedBy.Location = new System.Drawing.Point(829, 131);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Size = new System.Drawing.Size(48, 25);
            this.txtCreatedBy.TabIndex = 26;
            this.txtCreatedBy.Text = "???";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD_Full_Project.Properties.Resources.login;
            this.pictureBox8.Location = new System.Drawing.Point(782, 131);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(23, 25);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 25;
            this.pictureBox8.TabStop = false;
            // 
            // labCreatedBy
            // 
            this.labCreatedBy.AutoSize = true;
            this.labCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCreatedBy.Location = new System.Drawing.Point(649, 131);
            this.labCreatedBy.Name = "labCreatedBy";
            this.labCreatedBy.Size = new System.Drawing.Size(127, 25);
            this.labCreatedBy.TabIndex = 24;
            this.labCreatedBy.Text = "Created By:";
            // 
            // txtOldLicenseID
            // 
            this.txtOldLicenseID.AutoSize = true;
            this.txtOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldLicenseID.Location = new System.Drawing.Point(829, 85);
            this.txtOldLicenseID.Name = "txtOldLicenseID";
            this.txtOldLicenseID.Size = new System.Drawing.Size(48, 25);
            this.txtOldLicenseID.TabIndex = 20;
            this.txtOldLicenseID.Text = "???";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD_Full_Project.Properties.Resources.id_32;
            this.pictureBox6.Location = new System.Drawing.Point(782, 85);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(23, 25);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 19;
            this.pictureBox6.TabStop = false;
            // 
            // labOldLicenseID
            // 
            this.labOldLicenseID.AutoSize = true;
            this.labOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labOldLicenseID.Location = new System.Drawing.Point(615, 85);
            this.labOldLicenseID.Name = "labOldLicenseID";
            this.labOldLicenseID.Size = new System.Drawing.Size(161, 25);
            this.labOldLicenseID.TabIndex = 18;
            this.labOldLicenseID.Text = "Old License ID:";
            // 
            // txtID_IntLicense
            // 
            this.txtID_IntLicense.AutoSize = true;
            this.txtID_IntLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID_IntLicense.Location = new System.Drawing.Point(829, 39);
            this.txtID_IntLicense.Name = "txtID_IntLicense";
            this.txtID_IntLicense.Size = new System.Drawing.Size(48, 25);
            this.txtID_IntLicense.TabIndex = 17;
            this.txtID_IntLicense.Text = "???";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Full_Project.Properties.Resources.id_reload;
            this.pictureBox5.Location = new System.Drawing.Point(782, 39);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(23, 25);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // labID_RLicense
            // 
            this.labID_RLicense.AutoSize = true;
            this.labID_RLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labID_RLicense.Location = new System.Drawing.Point(536, 39);
            this.labID_RLicense.Name = "labID_RLicense";
            this.labID_RLicense.Size = new System.Drawing.Size(240, 25);
            this.labID_RLicense.TabIndex = 15;
            this.labID_RLicense.Text = "Replacment License ID:";
            // 
            // txtFees
            // 
            this.txtFees.AutoSize = true;
            this.txtFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFees.Location = new System.Drawing.Point(279, 131);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(48, 25);
            this.txtFees.TabIndex = 14;
            this.txtFees.Text = "???";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Full_Project.Properties.Resources.taxes;
            this.pictureBox4.Location = new System.Drawing.Point(232, 131);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(23, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // labFees
            // 
            this.labFees.AutoSize = true;
            this.labFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFees.Location = new System.Drawing.Point(155, 131);
            this.labFees.Name = "labFees";
            this.labFees.Size = new System.Drawing.Size(67, 25);
            this.labFees.TabIndex = 12;
            this.labFees.Text = "Fees:";
            // 
            // txtAppDate
            // 
            this.txtAppDate.AutoSize = true;
            this.txtAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppDate.Location = new System.Drawing.Point(278, 85);
            this.txtAppDate.Name = "txtAppDate";
            this.txtAppDate.Size = new System.Drawing.Size(48, 25);
            this.txtAppDate.TabIndex = 8;
            this.txtAppDate.Text = "???";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Full_Project.Properties.Resources.DateIcon;
            this.pictureBox2.Location = new System.Drawing.Point(231, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // labAppDate
            // 
            this.labAppDate.AutoSize = true;
            this.labAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAppDate.Location = new System.Drawing.Point(45, 85);
            this.labAppDate.Name = "labAppDate";
            this.labAppDate.Size = new System.Drawing.Size(177, 25);
            this.labAppDate.TabIndex = 6;
            this.labAppDate.Text = "Application Date:";
            // 
            // txtID_RApp
            // 
            this.txtID_RApp.AutoSize = true;
            this.txtID_RApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID_RApp.Location = new System.Drawing.Point(279, 39);
            this.txtID_RApp.Name = "txtID_RApp";
            this.txtID_RApp.Size = new System.Drawing.Size(48, 25);
            this.txtID_RApp.TabIndex = 5;
            this.txtID_RApp.Text = "???";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Full_Project.Properties.Resources.title;
            this.pictureBox1.Location = new System.Drawing.Point(232, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // labID_IntApp
            // 
            this.labID_IntApp.AutoSize = true;
            this.labID_IntApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labID_IntApp.Location = new System.Drawing.Point(37, 39);
            this.labID_IntApp.Name = "labID_IntApp";
            this.labID_IntApp.Size = new System.Drawing.Size(185, 25);
            this.labID_IntApp.TabIndex = 3;
            this.labID_IntApp.Text = "I.R.Application ID:";
            // 
            // frmDamageAndLost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 788);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labHead);
            this.Controls.Add(this.ucNewInternational1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lnkShowInfo);
            this.Controls.Add(this.lnkShowHistory);
            this.Name = "frmDamageAndLost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDamageAndLost_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucNewInternational ucNewInternational1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lnkShowInfo;
        private System.Windows.Forms.LinkLabel lnkShowHistory;
        private System.Windows.Forms.Label labHead;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLostLicemse;
        private System.Windows.Forms.RadioButton rbDamagedLicense;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label txtCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label labCreatedBy;
        private System.Windows.Forms.Label txtOldLicenseID;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label labOldLicenseID;
        private System.Windows.Forms.Label txtID_IntLicense;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label labID_RLicense;
        private System.Windows.Forms.Label txtFees;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label labFees;
        private System.Windows.Forms.Label txtAppDate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labAppDate;
        private System.Windows.Forms.Label txtID_RApp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labID_IntApp;
    }
}