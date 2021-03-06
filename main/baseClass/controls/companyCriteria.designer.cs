namespace baseClass.controls
{
    partial class companyCriteria
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
            this.nameEd = new common.controls.baseTextBox();
            this.tickerCodeEd = new common.controls.baseTextBox();
            this.statusChk = new baseClass.controls.baseCheckBox();
            this.statusCb = new baseClass.controls.cbStockStatus();
            this.stockExchangeChk = new baseClass.controls.baseCheckBox();
            this.stockExchangeCb = new baseClass.controls.cbStockExchange();
            this.tickerCodeChk = new baseClass.controls.baseCheckBox();
            this.nameChk = new baseClass.controls.baseCheckBox();
            this.address1Chk = new baseClass.controls.baseCheckBox();
            this.SuspendLayout();
            // 
            // address1Ed
            // 
            this.address1Ed.Enabled = false;
            this.address1Ed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Ed.isToUpperCase = false;
            this.address1Ed.Location = new System.Drawing.Point(192, 78);
            this.address1Ed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.address1Ed.Name = "address1Ed";
            this.address1Ed.Size = new System.Drawing.Size(190, 22);
            this.address1Ed.TabIndex = 10;
            // 
            // nameEd
            // 
            this.nameEd.Enabled = false;
            this.nameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameEd.isToUpperCase = false;
            this.nameEd.Location = new System.Drawing.Point(-1, 78);
            this.nameEd.Name = "nameEd";
            this.nameEd.Size = new System.Drawing.Size(193, 22);
            this.nameEd.TabIndex = 8;
            // 
            // tickerCodeEd
            // 
            this.tickerCodeEd.BackColor = System.Drawing.Color.White;
            this.tickerCodeEd.Enabled = false;
            this.tickerCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickerCodeEd.ForeColor = System.Drawing.Color.Black;
            this.tickerCodeEd.isToUpperCase = false;
            this.tickerCodeEd.Location = new System.Drawing.Point(137, 24);
            this.tickerCodeEd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tickerCodeEd.Name = "tickerCodeEd";
            this.tickerCodeEd.Size = new System.Drawing.Size(135, 24);
            this.tickerCodeEd.TabIndex = 4;
            // 
            // statusChk
            // 
            this.statusChk.AutoSize = true;
            this.statusChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusChk.Location = new System.Drawing.Point(271, 1);
            this.statusChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statusChk.Name = "statusChk";
            this.statusChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusChk.Size = new System.Drawing.Size(70, 20);
            this.statusChk.TabIndex = 5;
            this.statusChk.Text = "Status";
            this.statusChk.UseVisualStyleBackColor = true;
            this.statusChk.CheckedChanged += new System.EventHandler(this.statusChk_CheckedChanged);
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.Enabled = false;
            this.statusCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCb.FormattingEnabled = true;
            this.statusCb.Location = new System.Drawing.Point(273, 24);
            this.statusCb.Margin = new System.Windows.Forms.Padding(2);
            this.statusCb.myValue = commonClass.AppTypes.CommonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(110, 24);
            this.statusCb.TabIndex = 6;
            // 
            // stockExchangeChk
            // 
            this.stockExchangeChk.AutoSize = true;
            this.stockExchangeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockExchangeChk.Location = new System.Drawing.Point(0, 1);
            this.stockExchangeChk.Name = "stockExchangeChk";
            this.stockExchangeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stockExchangeChk.Size = new System.Drawing.Size(88, 20);
            this.stockExchangeChk.TabIndex = 1;
            this.stockExchangeChk.Text = "Exchange";
            this.stockExchangeChk.UseVisualStyleBackColor = true;
            this.stockExchangeChk.CheckedChanged += new System.EventHandler(this.stockExchangeChk_CheckedChanged);
            // 
            // stockExchangeCb
            // 
            this.stockExchangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockExchangeCb.Enabled = false;
            this.stockExchangeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockExchangeCb.FormattingEnabled = true;
            this.stockExchangeCb.Location = new System.Drawing.Point(1, 24);
            this.stockExchangeCb.myValue = "";
            this.stockExchangeCb.Name = "stockExchangeCb";
            this.stockExchangeCb.Size = new System.Drawing.Size(137, 24);
            this.stockExchangeCb.TabIndex = 2;
            // 
            // tickerCodeChk
            // 
            this.tickerCodeChk.AutoSize = true;
            this.tickerCodeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickerCodeChk.Location = new System.Drawing.Point(135, 1);
            this.tickerCodeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tickerCodeChk.Name = "tickerCodeChk";
            this.tickerCodeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tickerCodeChk.Size = new System.Drawing.Size(59, 20);
            this.tickerCodeChk.TabIndex = 3;
            this.tickerCodeChk.Text = "Code";
            this.tickerCodeChk.UseVisualStyleBackColor = true;
            this.tickerCodeChk.CheckedChanged += new System.EventHandler(this.tickerCodeChk_CheckedChanged);
            // 
            // nameChk
            // 
            this.nameChk.AutoSize = true;
            this.nameChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameChk.Location = new System.Drawing.Point(-1, 55);
            this.nameChk.Name = "nameChk";
            this.nameChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nameChk.Size = new System.Drawing.Size(62, 20);
            this.nameChk.TabIndex = 7;
            this.nameChk.Text = "Name";
            this.nameChk.UseVisualStyleBackColor = true;
            this.nameChk.CheckedChanged += new System.EventHandler(this.nameChk_CheckedChanged);
            // 
            // address1Chk
            // 
            this.address1Chk.AutoSize = true;
            this.address1Chk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Chk.Location = new System.Drawing.Point(189, 55);
            this.address1Chk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.address1Chk.Name = "address1Chk";
            this.address1Chk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.address1Chk.Size = new System.Drawing.Size(81, 20);
            this.address1Chk.TabIndex = 9;
            this.address1Chk.Text = "Address";
            this.address1Chk.UseVisualStyleBackColor = true;
            this.address1Chk.CheckedChanged += new System.EventHandler(this.address1Chk_CheckedChanged);
            // 
            // companyCriteria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.statusChk);
            this.Controls.Add(this.statusCb);
            this.Controls.Add(this.stockExchangeChk);
            this.Controls.Add(this.stockExchangeCb);
            this.Controls.Add(this.tickerCodeChk);
            this.Controls.Add(this.tickerCodeEd);
            this.Controls.Add(this.nameChk);
            this.Controls.Add(this.address1Chk);
            this.Controls.Add(this.address1Ed);
            this.Controls.Add(this.nameEd);
            this.Name = "companyCriteria";
            this.Size = new System.Drawing.Size(383, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox commonNameEd;
        protected baseClass.controls.baseCheckBox address1Chk;
        protected common.controls.baseTextBox nameEd;
        protected common.controls.baseTextBox address1Ed;
        protected baseClass.controls.baseCheckBox nameChk;
        protected baseCheckBox tickerCodeChk;
        protected common.controls.baseTextBox tickerCodeEd;
        protected cbStockExchange stockExchangeCb;
        protected baseCheckBox stockExchangeChk;
        protected cbStockStatus statusCb;
        protected baseCheckBox statusChk;
    }
}
