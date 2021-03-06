namespace baseClass.controls
{
    partial class investorCriteria
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
            this.address1Ed = new common.controls.baseTextBox();
            this.firstNameEd = new common.controls.baseTextBox();
            this.firstNameChk = new baseClass.controls.baseCheckBox();
            this.address1Chk = new baseClass.controls.baseCheckBox();
            this.phoneChk = new baseClass.controls.baseCheckBox();
            this.phoneEd = new common.controls.baseTextBox();
            this.countryChk = new baseClass.controls.baseCheckBox();
            this.emailChk = new baseClass.controls.baseCheckBox();
            this.emailEd = new common.controls.baseTextBox();
            this.catCodeCb = new baseClass.controls.cbInvestorCat();
            this.countryCb = new baseClass.controls.cbCountry();
            this.catCodeChk = new baseClass.controls.baseCheckBox();
            this.SuspendLayout();
            // 
            // address1Ed
            // 
            this.address1Ed.Enabled = false;
            this.address1Ed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Ed.Location = new System.Drawing.Point(196, 26);
            this.address1Ed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.address1Ed.Name = "address1Ed";
            this.address1Ed.Size = new System.Drawing.Size(194, 22);
            this.address1Ed.TabIndex = 4;
            // 
            // firstNameEd
            // 
            this.firstNameEd.Enabled = false;
            this.firstNameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameEd.Location = new System.Drawing.Point(-1, 26);
            this.firstNameEd.Name = "firstNameEd";
            this.firstNameEd.Size = new System.Drawing.Size(197, 22);
            this.firstNameEd.TabIndex = 2;
            // 
            // firstNameChk
            // 
            this.firstNameChk.AutoSize = true;
            this.firstNameChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameChk.Location = new System.Drawing.Point(-2, 3);
            this.firstNameChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.firstNameChk.Name = "firstNameChk";
            this.firstNameChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.firstNameChk.Size = new System.Drawing.Size(62, 20);
            this.firstNameChk.TabIndex = 1;
            this.firstNameChk.Text = "Name";
            this.firstNameChk.UseVisualStyleBackColor = true;
            this.firstNameChk.CheckedChanged += new System.EventHandler(this.firstNameChk_CheckedChanged);
            // 
            // address1Chk
            // 
            this.address1Chk.AutoSize = true;
            this.address1Chk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Chk.Location = new System.Drawing.Point(194, 3);
            this.address1Chk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.address1Chk.Name = "address1Chk";
            this.address1Chk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.address1Chk.Size = new System.Drawing.Size(81, 20);
            this.address1Chk.TabIndex = 3;
            this.address1Chk.Text = "Address";
            this.address1Chk.UseVisualStyleBackColor = true;
            this.address1Chk.CheckedChanged += new System.EventHandler(this.address1Chk_CheckedChanged);
            // 
            // phoneChk
            // 
            this.phoneChk.AutoSize = true;
            this.phoneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneChk.Location = new System.Drawing.Point(-2, 50);
            this.phoneChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phoneChk.Name = "phoneChk";
            this.phoneChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.phoneChk.Size = new System.Drawing.Size(71, 20);
            this.phoneChk.TabIndex = 10;
            this.phoneChk.Text = "Phone ";
            this.phoneChk.UseVisualStyleBackColor = true;
            this.phoneChk.CheckedChanged += new System.EventHandler(this.phoneChk_CheckedChanged);
            // 
            // phoneEd
            // 
            this.phoneEd.BackColor = System.Drawing.Color.White;
            this.phoneEd.Enabled = false;
            this.phoneEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneEd.ForeColor = System.Drawing.Color.Black;
            this.phoneEd.Location = new System.Drawing.Point(0, 73);
            this.phoneEd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phoneEd.Name = "phoneEd";
            this.phoneEd.Size = new System.Drawing.Size(143, 24);
            this.phoneEd.TabIndex = 11;
            // 
            // countryChk
            // 
            this.countryChk.AutoSize = true;
            this.countryChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryChk.Location = new System.Drawing.Point(-2, 99);
            this.countryChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.countryChk.Name = "countryChk";
            this.countryChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.countryChk.Size = new System.Drawing.Size(96, 20);
            this.countryChk.TabIndex = 20;
            this.countryChk.Text = "Nationality";
            this.countryChk.UseVisualStyleBackColor = true;
            this.countryChk.CheckedChanged += new System.EventHandler(this.countryChk_CheckedChanged);
            // 
            // emailChk
            // 
            this.emailChk.AutoSize = true;
            this.emailChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailChk.Location = new System.Drawing.Point(142, 50);
            this.emailChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.emailChk.Name = "emailChk";
            this.emailChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.emailChk.Size = new System.Drawing.Size(59, 20);
            this.emailChk.TabIndex = 12;
            this.emailChk.Text = "Email";
            this.emailChk.UseVisualStyleBackColor = true;
            this.emailChk.CheckedChanged += new System.EventHandler(this.emailChk_CheckedChanged);
            // 
            // emailEd
            // 
            this.emailEd.BackColor = System.Drawing.Color.White;
            this.emailEd.Enabled = false;
            this.emailEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailEd.ForeColor = System.Drawing.Color.Black;
            this.emailEd.Location = new System.Drawing.Point(142, 73);
            this.emailEd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.emailEd.Name = "emailEd";
            this.emailEd.Size = new System.Drawing.Size(248, 24);
            this.emailEd.TabIndex = 13;
            // 
            // catCodeCb
            // 
            this.catCodeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.catCodeCb.FormattingEnabled = true;
            this.catCodeCb.Location = new System.Drawing.Point(196, 122);
            this.catCodeCb.myValue = "";
            this.catCodeCb.Name = "catCodeCb";
            this.catCodeCb.Size = new System.Drawing.Size(197, 21);
            this.catCodeCb.TabIndex = 23;
            // 
            // countryCb
            // 
            this.countryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryCb.FormattingEnabled = true;
            this.countryCb.Location = new System.Drawing.Point(-1, 122);
            this.countryCb.myValue = "";
            this.countryCb.Name = "countryCb";
            this.countryCb.Size = new System.Drawing.Size(199, 21);
            this.countryCb.TabIndex = 21;
            // 
            // catCodeChk
            // 
            this.catCodeChk.AutoSize = true;
            this.catCodeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catCodeChk.Location = new System.Drawing.Point(196, 99);
            this.catCodeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.catCodeChk.Name = "catCodeChk";
            this.catCodeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.catCodeChk.Size = new System.Drawing.Size(87, 20);
            this.catCodeChk.TabIndex = 22;
            this.catCodeChk.Text = "Category";
            this.catCodeChk.UseVisualStyleBackColor = true;
            this.catCodeChk.CheckedChanged += new System.EventHandler(this.catCodeChk_CheckedChanged);
            // 
            // investorCriteria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.catCodeChk);
            this.Controls.Add(this.countryCb);
            this.Controls.Add(this.catCodeCb);
            this.Controls.Add(this.emailChk);
            this.Controls.Add(this.emailEd);
            this.Controls.Add(this.countryChk);
            this.Controls.Add(this.phoneChk);
            this.Controls.Add(this.phoneEd);
            this.Controls.Add(this.firstNameChk);
            this.Controls.Add(this.address1Chk);
            this.Controls.Add(this.address1Ed);
            this.Controls.Add(this.firstNameEd);
            this.Name = "investorCriteria";
            this.Size = new System.Drawing.Size(390, 145);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox commonNameEd;
        protected baseClass.controls.baseCheckBox address1Chk;
        protected common.controls.baseTextBox firstNameEd;
        protected common.controls.baseTextBox address1Ed;
        protected baseClass.controls.baseCheckBox firstNameChk;
        protected baseCheckBox phoneChk;
        protected common.controls.baseTextBox phoneEd;
        protected baseCheckBox countryChk;
        protected baseCheckBox emailChk;
        protected common.controls.baseTextBox emailEd;
        private cbInvestorCat catCodeCb;
        private cbCountry countryCb;
        protected baseCheckBox catCodeChk;
    }
}
