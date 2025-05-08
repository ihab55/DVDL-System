namespace DVLD_Full_Project.Use_Controller
{
    partial class ucFilterPerson
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnSearchPerson = new System.Windows.Forms.Button();
            this.ucPersonCard1 = new DVLD_Full_Project.ucPersonCard();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find By: ";
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "ID",
            "National No"});
            this.cbFilter.Location = new System.Drawing.Point(127, 22);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(188, 24);
            this.cbFilter.TabIndex = 2;
            this.cbFilter.Text = "( None )";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(336, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 22);
            this.textBox1.TabIndex = 3;
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackgroundImage = global::DVLD_Full_Project.Properties.Resources.AddIcon;
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewPerson.FlatAppearance.BorderSize = 0;
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPerson.Location = new System.Drawing.Point(623, 20);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(52, 33);
            this.btnAddNewPerson.TabIndex = 5;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnSearchPerson
            // 
            this.btnSearchPerson.BackgroundImage = global::DVLD_Full_Project.Properties.Resources.FindIcon;
            this.btnSearchPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchPerson.FlatAppearance.BorderSize = 0;
            this.btnSearchPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPerson.Location = new System.Drawing.Point(551, 20);
            this.btnSearchPerson.Name = "btnSearchPerson";
            this.btnSearchPerson.Size = new System.Drawing.Size(52, 33);
            this.btnSearchPerson.TabIndex = 4;
            this.btnSearchPerson.UseVisualStyleBackColor = true;
            this.btnSearchPerson.Click += new System.EventHandler(this.btnSearchPerson_Click);
            // 
            // ucPersonCard1
            // 
            this.ucPersonCard1.Location = new System.Drawing.Point(3, 57);
            this.ucPersonCard1.Name = "ucPersonCard1";
            this.ucPersonCard1.Size = new System.Drawing.Size(718, 248);
            this.ucPersonCard1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAddNewPerson);
            this.groupBox1.Controls.Add(this.cbFilter);
            this.groupBox1.Controls.Add(this.btnSearchPerson);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 62);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // ucFilterPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucPersonCard1);
            this.Name = "ucFilterPerson";
            this.Size = new System.Drawing.Size(704, 303);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucPersonCard ucPersonCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSearchPerson;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
