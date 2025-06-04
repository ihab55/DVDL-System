namespace DVLD_Full_Project
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
            this.ucDLAppInfo1 = new DVLD_Full_Project.ucDLAppInfo();
            this.SuspendLayout();
            // 
            // ucDLAppInfo1
            // 
            this.ucDLAppInfo1.Location = new System.Drawing.Point(194, 12);
            this.ucDLAppInfo1.Name = "ucDLAppInfo1";
            this.ucDLAppInfo1.Size = new System.Drawing.Size(782, 523);
            this.ucDLAppInfo1.TabIndex = 0;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 569);
            this.Controls.Add(this.ucDLAppInfo1);
            this.Name = "Test";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Use_Controller.ucFilterPerson ucFilterPerson1;
        private ucDLAppInfo ucDLAppInfo1;
    }
}

