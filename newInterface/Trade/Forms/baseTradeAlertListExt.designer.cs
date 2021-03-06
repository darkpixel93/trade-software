namespace stockTrade.forms
{
    partial class baseTradeAlertListExt
    {

        //common.libs.appAvailable myAvail = new common.libs.appAvailable();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseTradeAlertListExt));
            this.filterPnl = new common.control.basePanel();
            this.tradeAlertCriteria = new stockTrade.controls.tradeAlertCriteria();
            this.filterBtn = new common.control.baseButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolbarPnl = new common.control.basePanel();
            this.refreshBtn = new common.control.baseButton();
            this.deleteBtn = new common.control.baseButton();
            this.showFilterBtn = new common.control.baseButton();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).BeginInit();
            this.filterPnl.SuspendLayout();
            this.toolbarPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterPnl
            // 
            this.filterPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filterPnl.Controls.Add(this.tradeAlertCriteria);
            this.filterPnl.Controls.Add(this.filterBtn);
            this.filterPnl.haveCloseButton = true;
            this.filterPnl.Location = new System.Drawing.Point(13, 29);
            this.filterPnl.Name = "filterPnl";
            this.filterPnl.Size = new System.Drawing.Size(555, 67);
            this.filterPnl.TabIndex = 239;
            this.filterPnl.Visible = false;
            // 
            // tradeAlertCriteria
            // 
            this.tradeAlertCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tradeAlertCriteria.Location = new System.Drawing.Point(18, 4);
            this.tradeAlertCriteria.Name = "tradeAlertCriteria";
            this.tradeAlertCriteria.Size = new System.Drawing.Size(488, 49);
            this.tradeAlertCriteria.TabIndex = 1;
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Image = global::stockTrade.Properties.Resources.filter;
            this.filterBtn.Location = new System.Drawing.Point(506, 28);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(29, 25);
            this.filterBtn.TabIndex = 20;
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "tickerCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "stockExchange";
            this.dataGridViewTextBoxColumn2.HeaderText = "Sàn ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "noOpenShares";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "SL niêm yết";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // toolbarPnl
            // 
            this.toolbarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolbarPnl.Controls.Add(this.refreshBtn);
            this.toolbarPnl.Controls.Add(this.deleteBtn);
            this.toolbarPnl.Controls.Add(this.showFilterBtn);
            this.toolbarPnl.haveCloseButton = false;
            this.toolbarPnl.Location = new System.Drawing.Point(0, 0);
            this.toolbarPnl.Name = "toolbarPnl";
            this.toolbarPnl.Size = new System.Drawing.Size(642, 27);
            this.toolbarPnl.TabIndex = 240;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Image = global::stockTrade.Properties.Resources.refresh;
            this.refreshBtn.Location = new System.Drawing.Point(26, 1);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(24, 21);
            this.refreshBtn.TabIndex = 2;
            this.myToolTip.SetToolTip(this.refreshBtn, "Tải lại dữ liệu");
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Image = global::stockTrade.Properties.Resources.cancel;
            this.deleteBtn.Location = new System.Drawing.Point(2, 1);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(24, 21);
            this.deleteBtn.TabIndex = 1;
            this.myToolTip.SetToolTip(this.deleteBtn, "Tạm hủy");
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // showFilterBtn
            // 
            this.showFilterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFilterBtn.Image = global::stockTrade.Properties.Resources.filter;
            this.showFilterBtn.Location = new System.Drawing.Point(50, 1);
            this.showFilterBtn.Name = "showFilterBtn";
            this.showFilterBtn.Size = new System.Drawing.Size(24, 21);
            this.showFilterBtn.TabIndex = 3;
            this.myToolTip.SetToolTip(this.showFilterBtn, "Lọc dữ liệu");
            this.showFilterBtn.UseVisualStyleBackColor = true;
            this.showFilterBtn.Click += new System.EventHandler(this.showFilterBtn_Click);
            // 
            // baseTradeAlertListExt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 366);
            this.Controls.Add(this.filterPnl);
            this.Controls.Add(this.toolbarPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baseTradeAlertListExt";
            this.Controls.SetChildIndex(this.toolbarPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.filterPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).EndInit();
            this.filterPnl.ResumeLayout(false);
            this.toolbarPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        protected common.control.basePanel filterPnl;
        protected common.control.baseButton filterBtn;
        protected common.control.basePanel toolbarPnl;
        protected common.control.baseButton deleteBtn;
        protected common.control.baseButton showFilterBtn;
        protected common.control.baseButton refreshBtn;
        protected stockTrade.controls.tradeAlertCriteria tradeAlertCriteria;

    }
}