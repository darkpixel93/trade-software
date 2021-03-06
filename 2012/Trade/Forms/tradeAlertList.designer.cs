namespace Trade.Forms
{
    partial class tradeAlertList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tradeAlertList));
            this.strategySource = new System.Windows.Forms.BindingSource(this.components);
            this.myTmpDS = new databases.tmpDS();
            this.timeScaleSource = new System.Windows.Forms.BindingSource(this.components);
            this.tradeActionSource = new System.Windows.Forms.BindingSource(this.components);
            this.CommonStatusSource = new System.Windows.Forms.BindingSource(this.components);
            this.tradeAlertSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataSet = new databases.baseDS();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.summaryPg = new System.Windows.Forms.TabPage();
            this.summaryGrid = new common.controls.baseDataGridView();
            this.sumOnDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumNameColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.stockCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.sumMessageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toDetailBtn = new common.controls.gridViewImageColumn();
            this.alertSummarySource = new System.Windows.Forms.BindingSource(this.components);
            this.detailPg = new System.Windows.Forms.TabPage();
            this.detailGrid = new common.controls.baseDataGridView();
            this.onDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strategyColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.msgColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeScaleColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.actionColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.viewColumn = new common.controls.gridViewImageColumn();
            this.toSummaryBtn = new common.controls.gridViewImageColumn();
            this.filterBtn = new common.controls.baseButton();
            ((System.ComponentModel.ISupportInitialize)(this.strategySource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeScaleSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeActionSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommonStatusSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.mainTab.SuspendLayout();
            this.summaryPg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.summaryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertSummarySource)).BeginInit();
            this.detailPg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1527, 105);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.TitleLbl.Size = new System.Drawing.Size(93, 64);
            this.TitleLbl.Visible = false;
            // 
            // strategySource
            // 
            this.strategySource.DataMember = "codeList";
            this.strategySource.DataSource = this.myTmpDS;
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.EnforceConstraints = false;
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timeScaleSource
            // 
            this.timeScaleSource.DataMember = "codeList";
            this.timeScaleSource.DataSource = this.myTmpDS;
            // 
            // tradeActionSource
            // 
            this.tradeActionSource.DataMember = "codeList";
            this.tradeActionSource.DataSource = this.myTmpDS;
            // 
            // CommonStatusSource
            // 
            this.CommonStatusSource.DataMember = "codeList";
            this.CommonStatusSource.DataSource = this.myTmpDS;
            // 
            // tradeAlertSource
            // 
            this.tradeAlertSource.DataMember = "tradeAlert";
            this.tradeAlertSource.DataSource = this.myDataSet;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.summaryPg);
            this.mainTab.Controls.Add(this.detailPg);
            this.mainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTab.Location = new System.Drawing.Point(0, 0);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(1162, 508);
            this.mainTab.TabIndex = 1;
            this.mainTab.SelectedIndexChanged += new System.EventHandler(this.mainTab_SelectedIndexChanged);
            // 
            // summaryPg
            // 
            this.summaryPg.Controls.Add(this.summaryGrid);
            this.summaryPg.Location = new System.Drawing.Point(4, 25);
            this.summaryPg.Name = "summaryPg";
            this.summaryPg.Padding = new System.Windows.Forms.Padding(3);
            this.summaryPg.Size = new System.Drawing.Size(1154, 479);
            this.summaryPg.TabIndex = 0;
            this.summaryPg.Text = "Alerts";
            this.summaryPg.UseVisualStyleBackColor = true;
            // 
            // summaryGrid
            // 
            this.summaryGrid.AllowUserToAddRows = false;
            this.summaryGrid.AllowUserToDeleteRows = false;
            this.summaryGrid.AutoGenerateColumns = false;
            this.summaryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sumOnDateColumn,
            this.sumCodeColumn,
            this.sumNameColumn,
            this.sumMessageColumn,
            this.toDetailBtn});
            this.summaryGrid.DataSource = this.alertSummarySource;
            this.summaryGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summaryGrid.Location = new System.Drawing.Point(3, 3);
            this.summaryGrid.Name = "summaryGrid";
            this.summaryGrid.ReadOnly = true;
            this.summaryGrid.RowTemplate.Height = 24;
            this.summaryGrid.Size = new System.Drawing.Size(1148, 473);
            this.summaryGrid.TabIndex = 154;
            this.summaryGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.summaryGrid_CellClick);
            // 
            // sumOnDateColumn
            // 
            this.sumOnDateColumn.DataPropertyName = "onTime";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.sumOnDateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.sumOnDateColumn.HeaderText = "onTime";
            this.sumOnDateColumn.Name = "sumOnDateColumn";
            this.sumOnDateColumn.ReadOnly = true;
            this.sumOnDateColumn.Width = 120;
            // 
            // sumCodeColumn
            // 
            this.sumCodeColumn.DataPropertyName = "stockCode";
            this.sumCodeColumn.HeaderText = "stockCode";
            this.sumCodeColumn.Name = "sumCodeColumn";
            this.sumCodeColumn.ReadOnly = true;
            this.sumCodeColumn.Width = 90;
            // 
            // sumNameColumn
            // 
            this.sumNameColumn.DataPropertyName = "stockCode";
            this.sumNameColumn.DataSource = this.stockCodeSource;
            this.sumNameColumn.DisplayMember = "name";
            this.sumNameColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.sumNameColumn.HeaderText = "sumName";
            this.sumNameColumn.Name = "sumNameColumn";
            this.sumNameColumn.ReadOnly = true;
            this.sumNameColumn.ValueMember = "code";
            this.sumNameColumn.Width = 450;
            // 
            // stockCodeSource
            // 
            this.stockCodeSource.DataMember = "stockCode";
            this.stockCodeSource.DataSource = this.myTmpDS;
            // 
            // sumMessageColumn
            // 
            this.sumMessageColumn.DataPropertyName = "msg";
            this.sumMessageColumn.HeaderText = "msg";
            this.sumMessageColumn.Name = "sumMessageColumn";
            this.sumMessageColumn.ReadOnly = true;
            this.sumMessageColumn.Width = 350;
            // 
            // toDetailBtn
            // 
            this.toDetailBtn.DataPropertyName = "id";
            this.toDetailBtn.HeaderText = "";
            this.toDetailBtn.myValue = "";
            this.toDetailBtn.Name = "toDetailBtn";
            this.toDetailBtn.ReadOnly = true;
            this.toDetailBtn.Width = 25;
            // 
            // alertSummarySource
            // 
            this.alertSummarySource.DataMember = "tradeAlert";
            this.alertSummarySource.DataSource = this.myDataSet;
            // 
            // detailPg
            // 
            this.detailPg.Controls.Add(this.detailGrid);
            this.detailPg.Location = new System.Drawing.Point(4, 22);
            this.detailPg.Name = "detailPg";
            this.detailPg.Padding = new System.Windows.Forms.Padding(3);
            this.detailPg.Size = new System.Drawing.Size(1154, 482);
            this.detailPg.TabIndex = 1;
            this.detailPg.Text = "Detail";
            this.detailPg.UseVisualStyleBackColor = true;
            // 
            // detailGrid
            // 
            this.detailGrid.AllowUserToAddRows = false;
            this.detailGrid.AllowUserToDeleteRows = false;
            this.detailGrid.AutoGenerateColumns = false;
            this.detailGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.onDateColumn,
            this.codeColumn,
            this.strategyColumn,
            this.msgColumn,
            this.timeScaleColumn,
            this.actionColumn,
            this.statusColumn,
            this.viewColumn,
            this.toSummaryBtn});
            this.detailGrid.DataSource = this.tradeAlertSource;
            this.detailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailGrid.Location = new System.Drawing.Point(3, 3);
            this.detailGrid.Name = "detailGrid";
            this.detailGrid.ReadOnly = true;
            this.detailGrid.RowTemplate.Height = 24;
            this.detailGrid.Size = new System.Drawing.Size(1148, 476);
            this.detailGrid.TabIndex = 154;
            this.detailGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailGrid_CellClick);
            // 
            // onDateColumn
            // 
            this.onDateColumn.DataPropertyName = "onTime";
            this.onDateColumn.HeaderText = "Date/Time";
            this.onDateColumn.Name = "onDateColumn";
            this.onDateColumn.ReadOnly = true;
            this.onDateColumn.Width = 140;
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "stockCode";
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 90;
            // 
            // strategyColumn
            // 
            this.strategyColumn.DataPropertyName = "strategy";
            this.strategyColumn.DataSource = this.strategySource;
            this.strategyColumn.DisplayMember = "description";
            this.strategyColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.strategyColumn.HeaderText = "Strategy";
            this.strategyColumn.Name = "strategyColumn";
            this.strategyColumn.ReadOnly = true;
            this.strategyColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.strategyColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.strategyColumn.ValueMember = "code";
            this.strategyColumn.Width = 160;
            // 
            // msgColumn
            // 
            this.msgColumn.DataPropertyName = "msg";
            this.msgColumn.HeaderText = "Info";
            this.msgColumn.Name = "msgColumn";
            this.msgColumn.ReadOnly = true;
            this.msgColumn.Width = 350;
            // 
            // timeScaleColumn
            // 
            this.timeScaleColumn.DataPropertyName = "timeScale";
            this.timeScaleColumn.DataSource = this.timeScaleSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.timeScaleColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.timeScaleColumn.DisplayMember = "description";
            this.timeScaleColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.timeScaleColumn.HeaderText = "Time Scale";
            this.timeScaleColumn.Name = "timeScaleColumn";
            this.timeScaleColumn.ReadOnly = true;
            this.timeScaleColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.timeScaleColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.timeScaleColumn.ValueMember = "code";
            this.timeScaleColumn.Width = 70;
            // 
            // actionColumn
            // 
            this.actionColumn.DataPropertyName = "tradeAction";
            this.actionColumn.DataSource = this.tradeActionSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.actionColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.actionColumn.DisplayMember = "description";
            this.actionColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.actionColumn.HeaderText = "Action";
            this.actionColumn.Name = "actionColumn";
            this.actionColumn.ReadOnly = true;
            this.actionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.actionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.actionColumn.ValueMember = "byteValue";
            this.actionColumn.Width = 55;
            // 
            // statusColumn
            // 
            this.statusColumn.DataPropertyName = "status";
            this.statusColumn.DataSource = this.CommonStatusSource;
            this.statusColumn.DisplayMember = "description";
            this.statusColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.statusColumn.HeaderText = "";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            this.statusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.statusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.statusColumn.ValueMember = "byteValue";
            this.statusColumn.Width = 50;
            // 
            // viewColumn
            // 
            this.viewColumn.HeaderText = "";
            this.viewColumn.myValue = "";
            this.viewColumn.Name = "viewColumn";
            this.viewColumn.ReadOnly = true;
            this.viewColumn.Width = 25;
            // 
            // toSummaryBtn
            // 
            this.toSummaryBtn.HeaderText = "";
            this.toSummaryBtn.myValue = "";
            this.toSummaryBtn.Name = "toSummaryBtn";
            this.toSummaryBtn.ReadOnly = true;
            this.toSummaryBtn.Width = 25;
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Image = global::Trade.Properties.Resources.filter;
            this.filterBtn.isDownState = false;
            this.filterBtn.Location = new System.Drawing.Point(100, 2);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(24, 21);
            this.filterBtn.TabIndex = 10;
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // tradeAlertList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1162, 530);
            this.Controls.Add(this.filterBtn);
            this.Controls.Add(this.mainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Name = "tradeAlertList";
            this.Text = "Trade alerts";
            this.Resize += new System.EventHandler(this.tradeAlertList_Resize);
            this.Controls.SetChildIndex(this.mainTab, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.filterBtn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.strategySource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeScaleSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeActionSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommonStatusSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.mainTab.ResumeLayout(false);
            this.summaryPg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.summaryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertSummarySource)).EndInit();
            this.detailPg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected databases.baseDS myDataSet;
        protected System.Windows.Forms.BindingSource tradeAlertSource;
        protected System.Windows.Forms.BindingSource CommonStatusSource;
        protected System.Windows.Forms.BindingSource timeScaleSource;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected databases.tmpDS myTmpDS;
        protected System.Windows.Forms.BindingSource strategySource;
        protected System.Windows.Forms.BindingSource tradeActionSource;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage summaryPg;
        private System.Windows.Forms.TabPage detailPg;
        protected System.Windows.Forms.BindingSource stockCodeSource;
        protected System.Windows.Forms.BindingSource alertSummarySource;
        protected common.controls.baseDataGridView summaryGrid;
        protected common.controls.baseDataGridView detailGrid;
        private common.controls.baseButton filterBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumOnDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumCodeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn sumNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumMessageColumn;
        private common.controls.gridViewImageColumn toDetailBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn strategyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msgColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn timeScaleColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn actionColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn statusColumn;
        private common.controls.gridViewImageColumn viewColumn;
        private common.controls.gridViewImageColumn toSummaryBtn;

    }
}