namespace baseClass.forms
{
    partial class baseStockList2
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseStockList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.stockCodeGrid = new common.control.baseDataGridView();
            this.tickerCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockExchange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noOpenShares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataSet = new data.baseDS();
            this.stockListFilterCb = new common.control.baseComboBox();
            this.stockCodeNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPnl = new System.Windows.Forms.Panel();
            this.stockCountlbl = new common.control.baseLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockTV = new System.Windows.Forms.TreeView();
            this.closeBtn = new baseClass.controls.baseButton();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeNavigator)).BeginInit();
            this.stockCodeNavigator.SuspendLayout();
            this.toolPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1018, 76);
            this.TitleLbl.Size = new System.Drawing.Size(62, 46);
            this.TitleLbl.Visible = false;
            // 
            // stockCodeGrid
            // 
            this.stockCodeGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.stockCodeGrid.AllowUserToAddRows = false;
            this.stockCodeGrid.AllowUserToDeleteRows = false;
            this.stockCodeGrid.AutoGenerateColumns = false;
            this.stockCodeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockCodeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tickerCodeDataGridViewTextBoxColumn,
            this.stockExchange,
            this.noOpenShares});
            this.stockCodeGrid.DataSource = this.stockCodeSource;
            this.stockCodeGrid.Location = new System.Drawing.Point(387, 38);
            this.stockCodeGrid.Name = "stockCodeGrid";
            this.stockCodeGrid.ReadOnly = true;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.stockCodeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stockCodeGrid.Size = new System.Drawing.Size(334, 400);
            this.stockCodeGrid.TabIndex = 232;
            this.stockCodeGrid.DoubleClick += new System.EventHandler(this.stockCodeGrid_DoubleClick);
            // 
            // tickerCodeDataGridViewTextBoxColumn
            // 
            this.tickerCodeDataGridViewTextBoxColumn.DataPropertyName = "tickerCode";
            this.tickerCodeDataGridViewTextBoxColumn.HeaderText = "Mã";
            this.tickerCodeDataGridViewTextBoxColumn.Name = "tickerCodeDataGridViewTextBoxColumn";
            this.tickerCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tickerCodeDataGridViewTextBoxColumn.Width = 70;
            // 
            // stockExchange
            // 
            this.stockExchange.DataPropertyName = "stockExchange";
            this.stockExchange.HeaderText = "Sàn ";
            this.stockExchange.Name = "stockExchange";
            this.stockExchange.ReadOnly = true;
            // 
            // noOpenShares
            // 
            this.noOpenShares.DataPropertyName = "noOpenShares";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.noOpenShares.DefaultCellStyle = dataGridViewCellStyle4;
            this.noOpenShares.HeaderText = "S.Lượng";
            this.noOpenShares.Name = "noOpenShares";
            this.noOpenShares.ReadOnly = true;
            // 
            // stockCodeSource
            // 
            this.stockCodeSource.DataMember = "stockCode";
            this.stockCodeSource.DataSource = this.myDataSet;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stockListFilterCb
            // 
            this.stockListFilterCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockListFilterCb.FormattingEnabled = true;
            this.stockListFilterCb.Items.AddRange(new object[] {
            "Tất cả",
            "Mã ưa thích",
            "Ngành ưa thích"});
            this.stockListFilterCb.Location = new System.Drawing.Point(388, 12);
            this.stockListFilterCb.myValue = "";
            this.stockListFilterCb.Name = "stockListFilterCb";
            this.stockListFilterCb.Size = new System.Drawing.Size(333, 26);
            this.stockListFilterCb.TabIndex = 233;
            this.stockListFilterCb.SelectedIndexChanged += new System.EventHandler(this.stockListFilterCb_SelectedIndexChanged);
            // 
            // stockCodeNavigator
            // 
            this.stockCodeNavigator.AddNewItem = null;
            this.stockCodeNavigator.BindingSource = this.stockCodeSource;
            this.stockCodeNavigator.CountItem = null;
            this.stockCodeNavigator.DeleteItem = null;
            this.stockCodeNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.stockCodeNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.stockCodeNavigator.Location = new System.Drawing.Point(4, 5);
            this.stockCodeNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.stockCodeNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.stockCodeNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.stockCodeNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.stockCodeNavigator.Name = "stockCodeNavigator";
            this.stockCodeNavigator.PositionItem = null;
            this.stockCodeNavigator.Size = new System.Drawing.Size(114, 25);
            this.stockCodeNavigator.Stretch = true;
            this.stockCodeNavigator.TabIndex = 235;
            this.stockCodeNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolPnl
            // 
            this.toolPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolPnl.Controls.Add(this.closeBtn);
            this.toolPnl.Controls.Add(this.stockCodeNavigator);
            this.toolPnl.Controls.Add(this.stockCountlbl);
            this.toolPnl.Location = new System.Drawing.Point(388, 444);
            this.toolPnl.Name = "toolPnl";
            this.toolPnl.Size = new System.Drawing.Size(335, 34);
            this.toolPnl.TabIndex = 237;
            // 
            // stockCountlbl
            // 
            this.stockCountlbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCountlbl.Location = new System.Drawing.Point(135, 4);
            this.stockCountlbl.Name = "stockCountlbl";
            this.stockCountlbl.Size = new System.Drawing.Size(62, 23);
            this.stockCountlbl.TabIndex = 238;
            this.stockCountlbl.Text = "....";
            this.stockCountlbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "SL niêm yết";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // stockTV
            // 
            this.stockTV.Location = new System.Drawing.Point(0, 0);
            this.stockTV.Name = "stockTV";
            this.stockTV.Size = new System.Drawing.Size(260, 420);
            this.stockTV.TabIndex = 238;
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.Location = new System.Drawing.Point(242, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(68, 24);
            this.closeBtn.TabIndex = 239;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // baseStockList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 441);
            this.Controls.Add(this.stockTV);
            this.Controls.Add(this.toolPnl);
            this.Controls.Add(this.stockListFilterCb);
            this.Controls.Add(this.stockCodeGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.Name = "baseStockList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ma chung khoan";
            this.Load += new System.EventHandler(this.baseStockList_Load);
            this.Controls.SetChildIndex(this.stockCodeGrid, 0);
            this.Controls.SetChildIndex(this.stockListFilterCb, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.toolPnl, 0);
            this.Controls.SetChildIndex(this.stockTV, 0);
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeNavigator)).EndInit();
            this.stockCodeNavigator.ResumeLayout(false);
            this.stockCodeNavigator.PerformLayout();
            this.toolPnl.ResumeLayout(false);
            this.toolPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected data.baseDS myDataSet;
        protected common.control.baseDataGridView stockCodeGrid;
        private System.Windows.Forms.BindingSource stockCodeSource;
        protected common.control.baseComboBox stockListFilterCb;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingNavigator stockCodeNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        protected System.Windows.Forms.Panel toolPnl;
        protected common.control.baseLabel stockCountlbl;
        private baseClass.controls.baseButton closeBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tickerCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockExchange;
        private System.Windows.Forms.DataGridViewTextBoxColumn noOpenShares;
        private System.Windows.Forms.TreeView stockTV;

    }
}