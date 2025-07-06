namespace DVLD_Full_Project
{
    partial class frmAddUpdatePerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdatePerson));
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labID = new System.Windows.Forms.Label();
            this.clabID = new System.Windows.Forms.Label();
            this.gpPersonCard = new System.Windows.Forms.GroupBox();
            this.linRemove = new System.Windows.Forms.LinkLabel();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.linUpload = new System.Windows.Forms.LinkLabel();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.dtDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNationalNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.txtThird = new System.Windows.Forms.TextBox();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.pbPerson = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.labCountry = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.labPhone = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labName = new System.Windows.Forms.Label();
            this.labNationID = new System.Windows.Forms.Label();
            this.labDateOfBirth = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gpPersonCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(287, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add New Person";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClose.Image = global::DVLD_Full_Project.Properties.Resources.closeIcon;
            this.btnClose.Location = new System.Drawing.Point(417, 277);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 37);
            this.btnClose.TabIndex = 50;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.Image = global::DVLD_Full_Project.Properties.Resources.SaveIcon;
            this.btnSave.Location = new System.Drawing.Point(548, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 37);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(132, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // labID
            // 
            this.labID.AutoSize = true;
            this.labID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labID.Location = new System.Drawing.Point(12, 48);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(117, 20);
            this.labID.TabIndex = 52;
            this.labID.Text = "Person ID  : ";
            // 
            // clabID
            // 
            this.clabID.AutoSize = true;
            this.clabID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clabID.Location = new System.Drawing.Point(156, 52);
            this.clabID.Name = "clabID";
            this.clabID.Size = new System.Drawing.Size(30, 16);
            this.clabID.TabIndex = 55;
            this.clabID.Text = "N/A";
            // 
            // gpPersonCard
            // 
            this.gpPersonCard.Controls.Add(this.linRemove);
            this.gpPersonCard.Controls.Add(this.rbFemale);
            this.gpPersonCard.Controls.Add(this.rbMale);
            this.gpPersonCard.Controls.Add(this.linUpload);
            this.gpPersonCard.Controls.Add(this.btnClose);
            this.gpPersonCard.Controls.Add(this.btnSave);
            this.gpPersonCard.Controls.Add(this.cmbCountry);
            this.gpPersonCard.Controls.Add(this.dtDateOfBirth);
            this.gpPersonCard.Controls.Add(this.txtPhone);
            this.gpPersonCard.Controls.Add(this.txtAddress);
            this.gpPersonCard.Controls.Add(this.txtEmail);
            this.gpPersonCard.Controls.Add(this.txtNationalNum);
            this.gpPersonCard.Controls.Add(this.label4);
            this.gpPersonCard.Controls.Add(this.label3);
            this.gpPersonCard.Controls.Add(this.label2);
            this.gpPersonCard.Controls.Add(this.label5);
            this.gpPersonCard.Controls.Add(this.txtLast);
            this.gpPersonCard.Controls.Add(this.txtThird);
            this.gpPersonCard.Controls.Add(this.txtSecond);
            this.gpPersonCard.Controls.Add(this.txtFirst);
            this.gpPersonCard.Controls.Add(this.pbPerson);
            this.gpPersonCard.Controls.Add(this.pictureBox7);
            this.gpPersonCard.Controls.Add(this.pictureBox3);
            this.gpPersonCard.Controls.Add(this.pictureBox9);
            this.gpPersonCard.Controls.Add(this.labCountry);
            this.gpPersonCard.Controls.Add(this.pictureBox8);
            this.gpPersonCard.Controls.Add(this.labPhone);
            this.gpPersonCard.Controls.Add(this.pictureBox6);
            this.gpPersonCard.Controls.Add(this.label10);
            this.gpPersonCard.Controls.Add(this.pictureBox5);
            this.gpPersonCard.Controls.Add(this.label8);
            this.gpPersonCard.Controls.Add(this.pictureBox4);
            this.gpPersonCard.Controls.Add(this.label6);
            this.gpPersonCard.Controls.Add(this.pictureBox2);
            this.gpPersonCard.Controls.Add(this.labName);
            this.gpPersonCard.Controls.Add(this.labNationID);
            this.gpPersonCard.Controls.Add(this.labDateOfBirth);
            this.gpPersonCard.Location = new System.Drawing.Point(12, 71);
            this.gpPersonCard.Name = "gpPersonCard";
            this.gpPersonCard.Size = new System.Drawing.Size(854, 314);
            this.gpPersonCard.TabIndex = 54;
            this.gpPersonCard.TabStop = false;
            // 
            // linRemove
            // 
            this.linRemove.AutoSize = true;
            this.linRemove.Enabled = false;
            this.linRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linRemove.Location = new System.Drawing.Point(717, 255);
            this.linRemove.Name = "linRemove";
            this.linRemove.Size = new System.Drawing.Size(82, 22);
            this.linRemove.TabIndex = 54;
            this.linRemove.TabStop = true;
            this.linRemove.Text = "Remove";
            this.linRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linRemove_LinkClicked);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(264, 121);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(74, 20);
            this.rbFemale.TabIndex = 53;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(188, 121);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(58, 20);
            this.rbMale.TabIndex = 52;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // linUpload
            // 
            this.linUpload.AutoSize = true;
            this.linUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linUpload.Location = new System.Drawing.Point(709, 227);
            this.linUpload.Name = "linUpload";
            this.linUpload.Size = new System.Drawing.Size(99, 22);
            this.linUpload.TabIndex = 51;
            this.linUpload.TabStop = true;
            this.linUpload.Text = "Set Image";
            this.linUpload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linUpload_LinkClicked);
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountry.Location = new System.Drawing.Point(534, 162);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(140, 30);
            this.cmbCountry.TabIndex = 48;
            // 
            // dtDateOfBirth
            // 
            this.dtDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateOfBirth.Location = new System.Drawing.Point(534, 79);
            this.dtDateOfBirth.Name = "dtDateOfBirth";
            this.dtDateOfBirth.Size = new System.Drawing.Size(140, 28);
            this.dtDateOfBirth.TabIndex = 47;
            this.dtDateOfBirth.Value = new System.DateTime(2004, 1, 21, 0, 0, 0, 0);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(534, 121);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(140, 28);
            this.txtPhone.TabIndex = 46;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.textFirst_Validating);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(188, 208);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(487, 62);
            this.txtAddress.TabIndex = 44;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.textFirst_Validating);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(188, 162);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 28);
            this.txtEmail.TabIndex = 43;
            this.txtEmail.Tag = "null";
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtNationalNum
            // 
            this.txtNationalNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNationalNum.Location = new System.Drawing.Point(188, 78);
            this.txtNationalNum.Name = "txtNationalNum";
            this.txtNationalNum.Size = new System.Drawing.Size(150, 28);
            this.txtNationalNum.TabIndex = 41;
            this.txtNationalNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNationalNum.Validating += new System.ComponentModel.CancelEventHandler(this.txtNoNum_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(737, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 22);
            this.label4.TabIndex = 40;
            this.label4.Text = "Last";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(572, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.TabIndex = 39;
            this.label3.Text = "Third";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(391, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 38;
            this.label2.Text = "Second";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(238, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 22);
            this.label5.TabIndex = 37;
            this.label5.Text = "First";
            // 
            // txtLast
            // 
            this.txtLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLast.Location = new System.Drawing.Point(683, 37);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(150, 28);
            this.txtLast.TabIndex = 36;
            this.txtLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLast.Validating += new System.ComponentModel.CancelEventHandler(this.textFirst_Validating);
            // 
            // txtThird
            // 
            this.txtThird.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThird.Location = new System.Drawing.Point(525, 37);
            this.txtThird.Name = "txtThird";
            this.txtThird.Size = new System.Drawing.Size(150, 28);
            this.txtThird.TabIndex = 35;
            this.txtThird.Tag = "null";
            this.txtThird.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSecond
            // 
            this.txtSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecond.Location = new System.Drawing.Point(354, 36);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(150, 28);
            this.txtSecond.TabIndex = 34;
            this.txtSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSecond.Validating += new System.ComponentModel.CancelEventHandler(this.textFirst_Validating);
            // 
            // txtFirst
            // 
            this.txtFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirst.Location = new System.Drawing.Point(188, 36);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(150, 28);
            this.txtFirst.TabIndex = 33;
            this.txtFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFirst.Validating += new System.ComponentModel.CancelEventHandler(this.textFirst_Validating);
            // 
            // pbPerson
            // 
            this.pbPerson.Image = global::DVLD_Full_Project.Properties.Resources.person_boy;
            this.pbPerson.Location = new System.Drawing.Point(683, 79);
            this.pbPerson.Name = "pbPerson";
            this.pbPerson.Size = new System.Drawing.Size(150, 145);
            this.pbPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPerson.TabIndex = 30;
            this.pbPerson.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD_Full_Project.Properties.Resources.DateIcon;
            this.pictureBox7.Location = new System.Drawing.Point(504, 80);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(21, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 19;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Full_Project.Properties.Resources.NationalIdIcon;
            this.pictureBox3.Location = new System.Drawing.Point(153, 79);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(21, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLD_Full_Project.Properties.Resources.worldIcon;
            this.pictureBox9.Location = new System.Drawing.Point(504, 164);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(21, 20);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 25;
            this.pictureBox9.TabStop = false;
            // 
            // labCountry
            // 
            this.labCountry.AutoSize = true;
            this.labCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCountry.Location = new System.Drawing.Point(357, 163);
            this.labCountry.Name = "labCountry";
            this.labCountry.Size = new System.Drawing.Size(140, 22);
            this.labCountry.TabIndex = 24;
            this.labCountry.Text = "Country        : ";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD_Full_Project.Properties.Resources.phoneIcon;
            this.pictureBox8.Location = new System.Drawing.Point(504, 122);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(21, 20);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 22;
            this.pictureBox8.TabStop = false;
            // 
            // labPhone
            // 
            this.labPhone.AutoSize = true;
            this.labPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPhone.Location = new System.Drawing.Point(357, 121);
            this.labPhone.Name = "labPhone";
            this.labPhone.Size = new System.Drawing.Size(139, 22);
            this.labPhone.TabIndex = 21;
            this.labPhone.Text = "Phone          : ";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD_Full_Project.Properties.Resources.addressIcon;
            this.pictureBox6.Location = new System.Drawing.Point(153, 208);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(21, 20);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 16;
            this.pictureBox6.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 22);
            this.label10.TabIndex = 15;
            this.label10.Text = "Address:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Full_Project.Properties.Resources.EmailIcon;
            this.pictureBox5.Location = new System.Drawing.Point(153, 163);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(21, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 22);
            this.label8.TabIndex = 12;
            this.label8.Text = "Email: ";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Full_Project.Properties.Resources.Gendor;
            this.pictureBox4.Location = new System.Drawing.Point(153, 121);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(21, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "Gendor:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Full_Project.Properties.Resources.NameIcon;
            this.pictureBox2.Location = new System.Drawing.Point(153, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labName.Location = new System.Drawing.Point(21, 37);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(67, 22);
            this.labName.TabIndex = 3;
            this.labName.Text = "Name:";
            // 
            // labNationID
            // 
            this.labNationID.AutoSize = true;
            this.labNationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNationID.Location = new System.Drawing.Point(21, 79);
            this.labNationID.Name = "labNationID";
            this.labNationID.Size = new System.Drawing.Size(121, 22);
            this.labNationID.TabIndex = 6;
            this.labNationID.Text = "National No:";
            // 
            // labDateOfBirth
            // 
            this.labDateOfBirth.AutoSize = true;
            this.labDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDateOfBirth.Location = new System.Drawing.Point(357, 80);
            this.labDateOfBirth.Name = "labDateOfBirth";
            this.labDateOfBirth.Size = new System.Drawing.Size(133, 22);
            this.labDateOfBirth.TabIndex = 18;
            this.labDateOfBirth.Text = "Date Of Birth:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAddUpdatePerson
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(878, 391);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labID);
            this.Controls.Add(this.clabID);
            this.Controls.Add(this.gpPersonCard);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdatePerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddUpdatePerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gpPersonCard.ResumeLayout(false);
            this.gpPersonCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.Label clabID;
        private System.Windows.Forms.GroupBox gpPersonCard;
        private System.Windows.Forms.LinkLabel linRemove;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.LinkLabel linUpload;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.DateTimePicker dtDateOfBirth;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNationalNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.TextBox txtThird;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.PictureBox pbPerson;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label labCountry;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label labPhone;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labNationID;
        private System.Windows.Forms.Label labDateOfBirth;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}