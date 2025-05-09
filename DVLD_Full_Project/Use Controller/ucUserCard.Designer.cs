namespace DVLD_Full_Project.Use_Controller
{
    partial class ucUserCard
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clabIsActive = new System.Windows.Forms.Label();
            this.labActive = new System.Windows.Forms.Label();
            this.clabUserName = new System.Windows.Forms.Label();
            this.labUserName = new System.Windows.Forms.Label();
            this.clabUserID = new System.Windows.Forms.Label();
            this.labUserID = new System.Windows.Forms.Label();
            this.ucPersonCard1 = new DVLD_Full_Project.ucPersonCard();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clabIsActive);
            this.groupBox1.Controls.Add(this.labActive);
            this.groupBox1.Controls.Add(this.clabUserName);
            this.groupBox1.Controls.Add(this.labUserName);
            this.groupBox1.Controls.Add(this.clabUserID);
            this.groupBox1.Controls.Add(this.labUserID);
            this.groupBox1.Location = new System.Drawing.Point(3, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 61);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            // 
            // clabIsActive
            // 
            this.clabIsActive.AutoSize = true;
            this.clabIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clabIsActive.Location = new System.Drawing.Point(606, 31);
            this.clabIsActive.Name = "clabIsActive";
            this.clabIsActive.Size = new System.Drawing.Size(28, 16);
            this.clabIsActive.TabIndex = 8;
            this.clabIsActive.Text = "???";
            // 
            // labActive
            // 
            this.labActive.AutoSize = true;
            this.labActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labActive.Location = new System.Drawing.Point(504, 28);
            this.labActive.Name = "labActive";
            this.labActive.Size = new System.Drawing.Size(96, 20);
            this.labActive.TabIndex = 7;
            this.labActive.Text = "IS Active :";
            // 
            // clabUserName
            // 
            this.clabUserName.AutoSize = true;
            this.clabUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clabUserName.Location = new System.Drawing.Point(387, 32);
            this.clabUserName.Name = "clabUserName";
            this.clabUserName.Size = new System.Drawing.Size(28, 16);
            this.clabUserName.TabIndex = 6;
            this.clabUserName.Text = "???";
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUserName.Location = new System.Drawing.Point(266, 29);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(115, 20);
            this.labUserName.TabIndex = 5;
            this.labUserName.Text = "User Name :";
            // 
            // clabUserID
            // 
            this.clabUserID.AutoSize = true;
            this.clabUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clabUserID.Location = new System.Drawing.Point(161, 33);
            this.clabUserID.Name = "clabUserID";
            this.clabUserID.Size = new System.Drawing.Size(28, 16);
            this.clabUserID.TabIndex = 4;
            this.clabUserID.Text = "???";
            // 
            // labUserID
            // 
            this.labUserID.AutoSize = true;
            this.labUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUserID.Location = new System.Drawing.Point(63, 30);
            this.labUserID.Name = "labUserID";
            this.labUserID.Size = new System.Drawing.Size(92, 20);
            this.labUserID.TabIndex = 3;
            this.labUserID.Text = "User ID : ";
            // 
            // ucPersonCard1
            // 
            this.ucPersonCard1.Location = new System.Drawing.Point(3, 3);
            this.ucPersonCard1.Name = "ucPersonCard1";
            this.ucPersonCard1.Size = new System.Drawing.Size(721, 250);
            this.ucPersonCard1.TabIndex = 0;
            // 
            // ucUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucPersonCard1);
            this.Name = "ucUserCard";
            this.Size = new System.Drawing.Size(710, 323);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucPersonCard ucPersonCard1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label clabUserName;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Label clabUserID;
        private System.Windows.Forms.Label labUserID;
        private System.Windows.Forms.Label clabIsActive;
        private System.Windows.Forms.Label labActive;
    }
}
