﻿namespace DVLD_Full_Project
{
    partial class Test
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
            this.ucUserCard1 = new DVLD_Full_Project.Use_Controller.ucUserCard();
            this.SuspendLayout();
            // 
            // ucUserCard1
            // 
            this.ucUserCard1.Location = new System.Drawing.Point(135, 45);
            this.ucUserCard1.Name = "ucUserCard1";
            this.ucUserCard1.Size = new System.Drawing.Size(715, 325);
            this.ucUserCard1.TabIndex = 0;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 569);
            this.Controls.Add(this.ucUserCard1);
            this.Name = "Test";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private Use_Controller.ucFilterPerson ucFilterPerson1;
        private Use_Controller.ucUserCard ucUserCard1;
    }
}

