namespace common.controls
{
    partial class monthRange
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
            this.frMonthCb = new System.Windows.Forms.ComboBox();
            this.yearEd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.frMonthLbl = new System.Windows.Forms.Label();
            this.timeTypeCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toMonthCb = new System.Windows.Forms.ComboBox();
            this.toMonthLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // frMonthCb
            // 
            this.frMonthCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frMonthCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frMonthCb.FormattingEnabled = true;
            this.frMonthCb.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.frMonthCb.Location = new System.Drawing.Point(130, 19);
            this.frMonthCb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.frMonthCb.MaxDropDownItems = 20;
            this.frMonthCb.Name = "frMonthCb";
            this.frMonthCb.Size = new System.Drawing.Size(54, 26);
            this.frMonthCb.TabIndex = 2;
            // 
            // yearEd
            // 
            this.yearEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearEd.Location = new System.Drawing.Point(236, 19);
            this.yearEd.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.yearEd.Name = "yearEd";
            this.yearEd.Size = new System.Drawing.Size(55, 26);
            this.yearEd.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(239, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 18);
            this.label7.TabIndex = 59;
            this.label7.Text = "Năm";
            // 
            // frMonthLbl
            // 
            this.frMonthLbl.AutoSize = true;
            this.frMonthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frMonthLbl.Location = new System.Drawing.Point(129, 0);
            this.frMonthLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.frMonthLbl.Name = "frMonthLbl";
            this.frMonthLbl.Size = new System.Drawing.Size(25, 18);
            this.frMonthLbl.TabIndex = 58;
            this.frMonthLbl.Text = "Từ";
            // 
            // timeTypeCb
            // 
            this.timeTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeTypeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTypeCb.FormattingEnabled = true;
            this.timeTypeCb.Items.AddRange(new object[] {
            "Tháng",
            "Quý 1",
            "Quý 2",
            "Quý 3",
            "Quý 4",
            "Sáu tháng",
            "Chín tháng",
            "Năm",
            "Tùy chọn"});
            this.timeTypeCb.Location = new System.Drawing.Point(0, 19);
            this.timeTypeCb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.timeTypeCb.MaxDropDownItems = 20;
            this.timeTypeCb.Name = "timeTypeCb";
            this.timeTypeCb.Size = new System.Drawing.Size(132, 26);
            this.timeTypeCb.TabIndex = 1;
            this.timeTypeCb.SelectedIndexChanged += new System.EventHandler(this.timeTypeCb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-2, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 57;
            this.label5.Text = "Thời gian";
            // 
            // toMonthCb
            // 
            this.toMonthCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toMonthCb.Enabled = false;
            this.toMonthCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toMonthCb.FormattingEnabled = true;
            this.toMonthCb.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.toMonthCb.Location = new System.Drawing.Point(183, 19);
            this.toMonthCb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.toMonthCb.MaxDropDownItems = 20;
            this.toMonthCb.Name = "toMonthCb";
            this.toMonthCb.Size = new System.Drawing.Size(54, 26);
            this.toMonthCb.TabIndex = 3;
            // 
            // toMonthLbl
            // 
            this.toMonthLbl.AutoSize = true;
            this.toMonthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toMonthLbl.Location = new System.Drawing.Point(183, 0);
            this.toMonthLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.toMonthLbl.Name = "toMonthLbl";
            this.toMonthLbl.Size = new System.Drawing.Size(35, 18);
            this.toMonthLbl.TabIndex = 61;
            this.toMonthLbl.Text = "Đến";
            // 
            // monthRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toMonthCb);
            this.Controls.Add(this.toMonthLbl);
            this.Controls.Add(this.frMonthCb);
            this.Controls.Add(this.yearEd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.frMonthLbl);
            this.Controls.Add(this.timeTypeCb);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "monthRange";
            this.Size = new System.Drawing.Size(291, 45);
            this.Load += new System.EventHandler(this.monthRange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ComboBox frMonthCb;
        protected System.Windows.Forms.TextBox yearEd;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label frMonthLbl;
        protected System.Windows.Forms.ComboBox timeTypeCb;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.ComboBox toMonthCb;
        protected System.Windows.Forms.Label toMonthLbl;

    }
}
