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
            this.ucFilterPerson2 = new DVLD_Full_Project.Use_Controller.ucFilterPerson();
            this.SuspendLayout();
            // 
            // ucFilterPerson2
            // 
            this.ucFilterPerson2.Location = new System.Drawing.Point(244, 87);
            this.ucFilterPerson2.Name = "ucFilterPerson2";
            this.ucFilterPerson2.Size = new System.Drawing.Size(704, 303);
            this.ucFilterPerson2.TabIndex = 0;
            this.ucFilterPerson2.OnPersonSelected += new System.Action<int>(this.ucFilterPerson2_OnPersonSelected);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 569);
            this.Controls.Add(this.ucFilterPerson2);
            this.Name = "Test";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private Use_Controller.ucFilterPerson ucFilterPerson1;
        private Use_Controller.ucFilterPerson ucFilterPerson2;
    }
}

