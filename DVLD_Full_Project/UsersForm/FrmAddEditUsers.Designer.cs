namespace DVLD_Full_Project.Use_Controller
{
    partial class FrmAddEditUsers
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
            this.labHead = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chbIsActive = new System.Windows.Forms.CheckBox();
            this.txtCopyPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lacConfPassword = new System.Windows.Forms.Label();
            this.labPassword = new System.Windows.Forms.Label();
            this.labUsername = new System.Windows.Forms.Label();
            this.labUserId = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucFilterPerson1 = new DVLD_Full_Project.Use_Controller.ucFilterPerson();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labHead
            // 
            this.labHead.AutoSize = true;
            this.labHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHead.ForeColor = System.Drawing.Color.Red;
            this.labHead.Location = new System.Drawing.Point(270, 9);
            this.labHead.Name = "labHead";
            this.labHead.Size = new System.Drawing.Size(259, 38);
            this.labHead.TabIndex = 2;
            this.labHead.Text = "Add New Users";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(736, 383);
            this.tabControl1.TabIndex = 3;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chbIsActive);
            this.tabPage2.Controls.Add(this.txtCopyPassword);
            this.tabPage2.Controls.Add(this.txtPassword);
            this.tabPage2.Controls.Add(this.txtUsername);
            this.tabPage2.Controls.Add(this.txtUserID);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.lacConfPassword);
            this.tabPage2.Controls.Add(this.labPassword);
            this.tabPage2.Controls.Add(this.labUsername);
            this.tabPage2.Controls.Add(this.labUserId);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LoginInfo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chbIsActive
            // 
            this.chbIsActive.AutoSize = true;
            this.chbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbIsActive.Location = new System.Drawing.Point(345, 226);
            this.chbIsActive.Name = "chbIsActive";
            this.chbIsActive.Size = new System.Drawing.Size(79, 20);
            this.chbIsActive.TabIndex = 12;
            this.chbIsActive.Text = "Is Active";
            this.chbIsActive.UseVisualStyleBackColor = true;
            // 
            // txtCopyPassword
            // 
            this.txtCopyPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Bold);
            this.txtCopyPassword.Location = new System.Drawing.Point(345, 173);
            this.txtCopyPassword.Name = "txtCopyPassword";
            this.txtCopyPassword.PasswordChar = '*';
            this.txtCopyPassword.Size = new System.Drawing.Size(228, 29);
            this.txtCopyPassword.TabIndex = 11;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Bold);
            this.txtPassword.Location = new System.Drawing.Point(345, 127);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(228, 29);
            this.txtPassword.TabIndex = 10;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Bold);
            this.txtUsername.Location = new System.Drawing.Point(345, 81);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(228, 29);
            this.txtUsername.TabIndex = 9;
            // 
            // txtUserID
            // 
            this.txtUserID.AutoSize = true;
            this.txtUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(345, 35);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(52, 29);
            this.txtUserID.TabIndex = 8;
            this.txtUserID.Text = "???";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Full_Project.Properties.Resources.login;
            this.pictureBox4.Location = new System.Drawing.Point(271, 173);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 29);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Full_Project.Properties.Resources.password;
            this.pictureBox3.Location = new System.Drawing.Point(271, 127);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Full_Project.Properties.Resources.NameIcon;
            this.pictureBox2.Location = new System.Drawing.Point(271, 81);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Full_Project.Properties.Resources.NationalIdIcon;
            this.pictureBox1.Location = new System.Drawing.Point(271, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lacConfPassword
            // 
            this.lacConfPassword.AutoSize = true;
            this.lacConfPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lacConfPassword.Location = new System.Drawing.Point(19, 173);
            this.lacConfPassword.Name = "lacConfPassword";
            this.lacConfPassword.Size = new System.Drawing.Size(233, 29);
            this.lacConfPassword.TabIndex = 3;
            this.lacConfPassword.Text = "Confirm Password:";
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPassword.Location = new System.Drawing.Point(117, 127);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(135, 29);
            this.labPassword.TabIndex = 2;
            this.labPassword.Text = "Password:";
            // 
            // labUsername
            // 
            this.labUsername.AutoSize = true;
            this.labUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUsername.Location = new System.Drawing.Point(108, 81);
            this.labUsername.Name = "labUsername";
            this.labUsername.Size = new System.Drawing.Size(144, 29);
            this.labUsername.TabIndex = 1;
            this.labUsername.Text = "UserName:";
            // 
            // labUserId
            // 
            this.labUserId.AutoSize = true;
            this.labUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUserId.Location = new System.Drawing.Point(152, 35);
            this.labUserId.Name = "labUserId";
            this.labUserId.Size = new System.Drawing.Size(100, 29);
            this.labUserId.TabIndex = 0;
            this.labUserId.Text = "UserID:";
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_Full_Project.Properties.Resources.SaveIcon;
            this.btnSave.Location = new System.Drawing.Point(629, 448);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 40);
            this.btnSave.TabIndex = 53;
            this.btnSave.Text = "Save";
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
            this.btnClose.Location = new System.Drawing.Point(509, 448);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 40);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucFilterPerson1
            // 
            this.ucFilterPerson1.Location = new System.Drawing.Point(6, 3);
            this.ucFilterPerson1.Name = "ucFilterPerson1";
            this.ucFilterPerson1.Size = new System.Drawing.Size(704, 303);
            this.ucFilterPerson1.TabIndex = 0;
            this.ucFilterPerson1.OnPersonSelected += new System.Action<int>(this.ucFilterPerson1_OnPersonSelected);
            // 
            // FrmAddEditUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 491);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labHead);
            this.Name = "FrmAddEditUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmAddEditUsers_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labHead;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ucFilterPerson ucFilterPerson1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lacConfPassword;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.Label labUsername;
        private System.Windows.Forms.Label labUserId;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label txtUserID;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtCopyPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chbIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}