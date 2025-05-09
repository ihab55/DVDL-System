namespace DVLD_Full_Project.UsersForm
{
    partial class frmUsersCard
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
            this.button1 = new System.Windows.Forms.Button();
            this.ucUserCard1 = new DVLD_Full_Project.Use_Controller.ucUserCard();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::DVLD_Full_Project.Properties.Resources.closeIcon;
            this.button1.Location = new System.Drawing.Point(566, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucUserCard1
            // 
            this.ucUserCard1.Location = new System.Drawing.Point(7, 2);
            this.ucUserCard1.Name = "ucUserCard1";
            this.ucUserCard1.Size = new System.Drawing.Size(699, 321);
            this.ucUserCard1.TabIndex = 0;
            // 
            // frmUsersCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 377);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ucUserCard1);
            this.Name = "frmUsersCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private Use_Controller.ucUserCard ucUserCard1;
        private System.Windows.Forms.Button button1;
    }
}