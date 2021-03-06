namespace baseClass.controls
{
    partial class transactionCriteria
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
            this.stockCodeEd = new common.controls.baseTextBox();
            this.dateRange = new common.controls.dateRange2();
            this.dummyLbl = new common.controls.baseLabel();
            this.dateRangeChk = new baseClass.controls.baseCheckBox();
            this.stockExchangeChk = new baseClass.controls.baseCheckBox();
            this.stockExchangeCb = new baseClass.controls.cbStockExchange();
            this.stockCodeChk = new baseClass.controls.baseCheckBox();
            this.portfolioCb = new baseClass.controls.cbWatchList();
            this.portfolioChk = new baseClass.controls.baseCheckBox();
            this.SuspendLayout();
            // 
            // stockCodeEd
            // 
            this.stockCodeEd.BackColor = System.Drawing.Color.White;
            this.stockCodeEd.Enabled = false;
            this.stockCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeEd.ForeColor = System.Drawing.Color.Black;
            this.stockCodeEd.Location = new System.Drawing.Point(519, 25);
            this.stockCodeEd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockCodeEd.Name = "stockCodeEd";
            this.stockCodeEd.Size = new System.Drawing.Size(96, 24);
            this.stockCodeEd.TabIndex = 12;
            // 
            // dateRange
            // 
            this.dateRange.Enabled = false;
            this.dateRange.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRange.frDate = new System.DateTime(((long)(0)));
            this.dateRange.Location = new System.Drawing.Point(1, 4);
            this.dateRange.Margin = new System.Windows.Forms.Padding(4);
            this.dateRange.Name = "dateRange";
            this.dateRange.Size = new System.Drawing.Size(160, 45);
            this.dateRange.TabIndex = 4;
            this.dateRange.toDate = new System.DateTime(((long)(0)));
            // 
            // dummyLbl
            // 
            this.dummyLbl.Location = new System.Drawing.Point(3, 6);
            this.dummyLbl.Name = "dummyLbl";
            this.dummyLbl.Size = new System.Drawing.Size(148, 18);
            this.dummyLbl.TabIndex = 8;
            // 
            // dateRangeChk
            // 
            this.dateRangeChk.AutoSize = true;
            this.dateRangeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeChk.Location = new System.Drawing.Point(-1, 1);
            this.dateRangeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateRangeChk.Name = "dateRangeChk";
            this.dateRangeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateRangeChk.Size = new System.Drawing.Size(91, 20);
            this.dateRangeChk.TabIndex = 3;
            this.dateRangeChk.Text = "Date Time";
            this.dateRangeChk.UseVisualStyleBackColor = true;
            this.dateRangeChk.CheckedChanged += new System.EventHandler(this.dateRangeChk_CheckedChanged);
            // 
            // stockExchangeChk
            // 
            this.stockExchangeChk.AutoSize = true;
            this.stockExchangeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockExchangeChk.Location = new System.Drawing.Point(161, 2);
            this.stockExchangeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockExchangeChk.Name = "stockExchangeChk";
            this.stockExchangeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stockExchangeChk.Size = new System.Drawing.Size(88, 20);
            this.stockExchangeChk.TabIndex = 5;
            this.stockExchangeChk.Text = "Exchange";
            this.stockExchangeChk.UseVisualStyleBackColor = true;
            this.stockExchangeChk.CheckedChanged += new System.EventHandler(this.stockExchangeChk_CheckedChanged);
            // 
            // stockExchangeCb
            // 
            this.stockExchangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockExchangeCb.Enabled = false;
            this.stockExchangeCb.FormattingEnabled = true;
            this.stockExchangeCb.Location = new System.Drawing.Point(162, 25);
            this.stockExchangeCb.Margin = new System.Windows.Forms.Padding(2);
            this.stockExchangeCb.myValue = "";
            this.stockExchangeCb.Name = "stockExchangeCb";
            this.stockExchangeCb.Size = new System.Drawing.Size(157, 21);
            this.stockExchangeCb.TabIndex = 6;
            // 
            // stockCodeChk
            // 
            this.stockCodeChk.AutoSize = true;
            this.stockCodeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeChk.Location = new System.Drawing.Point(515, 3);
            this.stockCodeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockCodeChk.Name = "stockCodeChk";
            this.stockCodeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stockCodeChk.Size = new System.Drawing.Size(59, 20);
            this.stockCodeChk.TabIndex = 11;
            this.stockCodeChk.Text = "Code";
            this.stockCodeChk.UseVisualStyleBackColor = true;
            this.stockCodeChk.CheckedChanged += new System.EventHandler(this.stockCodeChk_CheckedChanged);
            // 
            // portfolioCb
            // 
            this.portfolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portfolioCb.Enabled = false;
            this.portfolioCb.FormattingEnabled = true;
            this.portfolioCb.Location = new System.Drawing.Point(316, 25);
            this.portfolioCb.myValue = "";
            this.portfolioCb.Name = "portfolioCb";
            this.portfolioCb.Size = new System.Drawing.Size(204, 21);
            this.portfolioCb.TabIndex = 9;
            // 
            // portfolioChk
            // 
            this.portfolioChk.AutoSize = true;
            this.portfolioChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioChk.Location = new System.Drawing.Point(316, 3);
            this.portfolioChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.portfolioChk.Name = "portfolioChk";
            this.portfolioChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.portfolioChk.Size = new System.Drawing.Size(82, 20);
            this.portfolioChk.TabIndex = 7;
            this.portfolioChk.Text = "Portfolio";
            this.portfolioChk.UseVisualStyleBackColor = true;
            this.portfolioChk.CheckedChanged += new System.EventHandler(this.portfolioChk_CheckedChanged);
            // 
            // transactionCriteria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.portfolioChk);
            this.Controls.Add(this.portfolioCb);
            this.Controls.Add(this.dateRangeChk);
            this.Controls.Add(this.dummyLbl);
            this.Controls.Add(this.dateRange);
            this.Controls.Add(this.stockExchangeChk);
            this.Controls.Add(this.stockExchangeCb);
            this.Controls.Add(this.stockCodeChk);
            this.Controls.Add(this.stockCodeEd);
            this.Name = "transactionCriteria";
            this.Size = new System.Drawing.Size(616, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox commonNameEd;
        protected baseCheckBox stockCodeChk;
        protected common.controls.baseTextBox stockCodeEd;
        protected baseCheckBox stockExchangeChk;
        protected cbStockExchange stockExchangeCb;
        protected common.controls.dateRange2 dateRange;
        private common.controls.baseLabel dummyLbl;
        protected baseCheckBox dateRangeChk;
        private cbWatchList portfolioCb;
        protected baseCheckBox portfolioChk;
    }
}
