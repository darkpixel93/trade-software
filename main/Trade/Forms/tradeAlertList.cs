using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AdvancedDataGridView;
using application;
using commonClass;

namespace Trade.Forms
{
    public partial class  tradeAlertList : common.forms.baseForm
    {
        public tradeAlertList()
        {
            try
            {
                InitializeComponent();
                toolBarPnl.Visible = true;
                common.dialogs.SetFileDialogEXCEL(saveFileDialog);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("transaction");
            onDateColumn.HeaderText = Languages.Libs.GetString("onDate");
            codeColumn.HeaderText = Languages.Libs.GetString("code");
            strategyColumn.HeaderText = Languages.Libs.GetString("strategy");
            timeScaleColumn.HeaderText = Languages.Libs.GetString("timeScale");
            actionColumn.HeaderText = Languages.Libs.GetString("tradeAction");

            tradeActionSource.DataSource = application.AppLibs.GetTradeActions();
            timeScaleSource.DataSource = application.AppLibs.GetTimeScales();
            CommonStatusSource.DataSource = application.AppLibs.GetCommonStatus();

            SetDataGrid();
        }

        public enum gridColumnName { OnTime, TradeAction, StockCode, Strategy, TimeScale, Status, View, Cancel };
        public virtual void  Init()
        {
            data.tmpDS.codeListDataTable strategyTbl = new data.tmpDS.codeListDataTable();
            application.Strategy.Libs.LoadStrategy(strategyTbl, AppTypes.StrategyTypes.Strategy);
            strategySource.DataSource = strategyTbl;

            DateTime lastAlertDate = DataAccess.Libs.GetLastAlertTime(commonClass.SysLibs.sysLoginCode);
            DateTime onDate = DataAccess.Libs.GetServerDateTime();
            if (lastAlertDate == common.Consts.constNullDate) lastAlertDate = onDate;
            lastAlertDate = lastAlertDate.Date;

            SetFilterDateRange(lastAlertDate, onDate);
            SetFilterDateRangeStat(true, true);
            SetFilterStatus(AppTypes.CommonStatus.New);
            
        }

        public delegate void onCellClick(gridColumnName colName, data.baseDS.tradeAlertRow row);
        public event onCellClick myOnCellClick = null;

        public ContextMenuStrip myContextMenuStrip
        {
            get { return dataGrid.ContextMenuStrip; }
            set { this.dataGrid.ContextMenuStrip = value; }
        }        

        private string _myPortfolioCode = "";
        public string myPortfolioCode
        {
            get {return _myPortfolioCode; }
            set 
            {
                _myPortfolioCode = value; 
                myAlertFilterForm.myPortfolio = value; 
            }
        }
        private string _myStockCode = "";
        public string myStockCode
        {
            get {return _myStockCode; }
            set 
            {
                _myStockCode = value; 
                myAlertFilterForm.myStockCode = value; 
            }
        }
        public data.baseDS.tradeAlertRow CurrentRow
        {
            get
            {
                if (tradeAlertSource.Current == null) return null;
                return (data.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
            }
        }

        public void Export()
        {
            if (dataGrid.DataSource == null)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("noData"));
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel(myDataSet.tradeAlert, saveFileDialog.FileName);
        }
        public bool ToolBarShowState
        {
            get { return this.toolBarPnl.isExpanded; }
            set 
            {
                this.toolBarPnl.isExpanded = value;
                FormResize();
            }
        }
        public void FormResize()
        {
            toolBarPnl.Location = new Point(0, 0);
            toolBarPnl.Width = this.Width - toolBarPnl.Location.X-2*SystemInformation.BorderSize.Width-2;
            //toolBarPnl.Height = viewBtn.Location.Y + viewBtn.Height + 5;
            if (this.toolBarPnl.isExpanded)
            {
                dataGrid.Location = new Point(0, toolBarPnl.Location.Y + toolBarPnl.Height+2);
                toolBarPnl.BringToFront();
            }
            else
            {
                dataGrid.Location = new Point(0, 0);
            }
            dataGrid.Size  = new Size(this.Width-5,this.ClientRectangle.Height - dataGrid.Location.Y); // - SystemInformation.CaptionHeight);
            common.system.AutoFitGridColumn(dataGrid, strategyColumn.Name);
            toolBarPnl.BringToFront();
        }
        public void SetColumnVisible(string[] colName, bool visible)
        {
            dataGrid.SetColumnVisible(colName, visible);
            FormResize();
        }
        public void SetColumnVisible(string colName, bool visible)
        {
            dataGrid.SetColumnVisible(colName, visible);
            FormResize();
        }
        public void SetFilterDateRangeDefault()
        {
            myAlertFilterForm.myFromDate = DataAccess.Libs.GetServerDateTime();
            myAlertFilterForm.myToDate = myAlertFilterForm.myFromDate;
        }
        public void SetFilterDateRange(DateTime frDate,DateTime toDate)
        {
            myAlertFilterForm.myFromDate = frDate;
            myAlertFilterForm.myToDate = toDate;
        }
        public void SetFilterDateRangeStat(bool enable,bool check)
        {
            myAlertFilterForm.SetDateRange(enable,check);
        }
        public void SetFilterPortfolioStat(bool enable, bool check)
        {
            myAlertFilterForm.SetPortfolio(enable, check);
        }
        public void SetFilterStockStat(bool enable, bool check)
        {
            myAlertFilterForm.SetStockCode(enable, check);
        }
        public void SetFilterStatusStat(bool enable, bool check)
        {
            myAlertFilterForm.SetStatus(enable, check);
        }
        public void SetFilterStatus(AppTypes.CommonStatus status)
        {
            myAlertFilterForm.myStatus =  status;
        }
        public virtual void LoadData()
        {
            tradeAlertSource.DataSource = DataAccess.Libs.GetTradeAlert_BySQL(myAlertFilterForm.GetSQL());
            ShowReccount(myDataSet.tradeAlert.Count);
        }

        private Forms.tradeAlertEdit _myTradeAlertEditForm = null;
        private Forms.tradeAlertEdit myTradeAlertEditForm
        {
            get
            {
                if (_myTradeAlertEditForm == null || _myTradeAlertEditForm.IsDisposed)
                    _myTradeAlertEditForm = GetTradeAlertEditForm();
                return _myTradeAlertEditForm;
            }
        }
        protected virtual Forms.tradeAlertEdit GetTradeAlertEditForm()
        {
            return new Forms.tradeAlertEdit();
        }

        private Forms.alertFilter _myAlertFilterForm = null;
        private Forms.alertFilter myAlertFilterForm
        {
            get
            {
                if (_myAlertFilterForm == null || _myAlertFilterForm.IsDisposed)
                {
                    _myAlertFilterForm = GetAlertFilterForm();
                    _myAlertFilterForm.myOnProcess += new common.forms.baseDialogForm.onProcess(DoAlertFilter);
                }
                return _myAlertFilterForm;
            }
        }
        protected virtual Forms.alertFilter GetAlertFilterForm()
        {
            return new Forms.alertFilter();
        }

        private Forms.transactionFromAlert _myNewTradeOrderForm = null;
        private Forms.transactionFromAlert myNewTradeOrderForm
        {
            get
            {
                if (_myNewTradeOrderForm == null || _myNewTradeOrderForm.IsDisposed)
                    _myNewTradeOrderForm = GetNewTradeOrderForm();
                return _myNewTradeOrderForm;
            }
        }

        public override void Refresh()
        {
            LoadData();
            base.Refresh();
        }

        protected virtual Forms.transactionFromAlert GetNewTradeOrderForm()
        {
            return new Forms.transactionFromAlert();
        }
        
        private void DoAlertFilter(object sender,common.baseDialogEvent e)
        {
            try
            {
                common.system.ShowCurrorWait();
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                common.system.ShowCurrorDefault();
            }
        }
        private void EditTradeAlert(int rowId)
        {
            myTradeAlertEditForm.ShowForm(tradeAlertSource, rowId);
        }
        private void EditTradeAlert()
        {
            if (tradeAlertSource.Current == null) return;
            data.baseDS.tradeAlertRow row = (data.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
            EditTradeAlert(row.id);
        }
        private bool DeleteTradeAlert(int rowId)
        {
            if (common.system.ShowDialogYesNo(Languages.Libs.GetString("askDeleteAlert")) == DialogResult.No) return false;
            DataAccess.Libs.DeleteTradeAlert(rowId);
            return true;
        }
        private void DeleteTradeAlerts()
        {
            if (dataGrid.SelectedRows.Count == 0)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("pleaseSelectRows"));
                return;
            }
            if (common.system.ShowDialogYesNo(Languages.Libs.GetString("askDeleteAlert")) == DialogResult.No) return;
            int count = 0;
            data.baseDS.tradeAlertRow row;
            for (int idx = 0; idx < dataGrid.SelectedRows.Count; idx++)
            {
                row = (data.baseDS.tradeAlertRow)((DataRowView)dataGrid.SelectedRows[idx].DataBoundItem).Row;
                if (row == null) continue;
                DataAccess.Libs.DeleteTradeAlert(row.id);
                count++;
                dataGrid.Rows.RemoveAt(dataGrid.SelectedRows[idx].Index); 
            }
            common.system.ShowMessage(String.Format(Languages.Libs.GetString("alertDeleted"),count));
        }
        private void IgnnoreAlerts()
        {
            data.baseDS.tradeAlertRow alertRow;
            for (int idx = 0; idx < dataGrid.SelectedRows.Count; idx++)
            {
                alertRow = (data.baseDS.tradeAlertRow)((DataRowView)dataGrid.SelectedRows[idx].DataBoundItem).Row;
                if (alertRow == null) continue;
                alertRow.status = (byte)AppTypes.CommonStatus.Ignore;
                DataAccess.Libs.UpdateData(alertRow);
            }
        }
        private void RecoverAlerts()
        {
            data.baseDS.tradeAlertRow alertRow;
            for (int idx = 0; idx < dataGrid.SelectedRows.Count; idx++)
            {
                alertRow = (data.baseDS.tradeAlertRow)((DataRowView)dataGrid.SelectedRows[idx].DataBoundItem).Row;
                if (alertRow == null) continue;
                alertRow.status = (byte)AppTypes.CommonStatus.New;
                DataAccess.Libs.UpdateData(alertRow);
            }
        }
        public void PlaceOrder()
        {
            if (this.CurrentRow == null) return;
            this.myNewTradeOrderForm.ShowNew(this.CurrentRow);
        }
        protected void SetDataGrid()
        {
            data.baseDS.tradeAlertDataTable tbl = myDataSet.tradeAlert;
            // 
            // onTimeColumn
            // 
            this.onDateColumn.Name = gridColumnName.OnTime.ToString();
            this.onDateColumn.DataPropertyName = tbl.onTimeColumn.ColumnName;

            // 
            // stockCodeColumn
            // 
            this.codeColumn.Name = gridColumnName.StockCode.ToString();
            this.codeColumn.DataPropertyName = tbl.stockCodeColumn.ColumnName;
            // 
            // subjectColumn
            // 
            this.actionColumn.Name = gridColumnName.TradeAction.ToString();
            this.actionColumn.DataPropertyName = tbl.tradeActionColumn.ColumnName;

            // 
            // strategyColumn
            // 
            this.strategyColumn.Name = gridColumnName.Strategy.ToString();
            this.strategyColumn.DataPropertyName = tbl.strategyColumn.ColumnName;

            // 
            // statusColumn
            // 
            this.statusColumn.Name = gridColumnName.Status.ToString();
            this.statusColumn.DataPropertyName = tbl.statusColumn.ColumnName;

            // 
            // cancelColumn
            // 
            this.cancelColumn.Name = gridColumnName.Cancel.ToString();
            this.cancelColumn.ReadOnly = true;
            this.cancelColumn.Width = 25;
            this.cancelColumn.myImageType = common.controls.imageType.Cancel;
            this.cancelColumn.Visible = false;

            // 
            // viewColumn
            // 
            this.viewColumn.Name = gridColumnName.View.ToString();
            this.viewColumn.ReadOnly = true;
            this.viewColumn.Width = 25;
            this.viewColumn.myImageType = common.controls.imageType.Edit;

            // 
            // dataGrid
            // 
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.DisableReadOnlyColumn = false;
            this.dataGrid.Columns.Clear();
            this.dataGrid.Columns.AddRange(new DataGridViewColumn[]
                {this.onDateColumn,
                 this.codeColumn,
                 this.strategyColumn,
                 this.timeScaleColumn,
                 this.actionColumn,
                 this.statusColumn,
                 this.viewColumn,this.cancelColumn});
        }

        #region event handler
        private void tradeAlertList_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.fOnProccessing) return;
                this.fOnProccessing = true;
                dataGrid.Size = this.Size;
                FormResize();
                this.fOnProccessing = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
                this.fOnProccessing = false;
            }
        }
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                data.baseDS.tradeAlertRow alertRow; 
                if (this.tradeAlertSource.Current == null || e == null) return;

                if (dataGrid.Columns[e.ColumnIndex].Name == gridColumnName.View.ToString())
                {
                    alertRow = (data.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
                    EditTradeAlert(alertRow.id);
                    return;
                }
                if (dataGrid.Columns[e.ColumnIndex].Name == gridColumnName.Cancel.ToString())
                {
                    alertRow = (data.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
                    if(!DeleteTradeAlert(alertRow.id)) return;
                    dataGrid.Rows.RemoveAt(e.RowIndex); 
                    return;
                }

                if (this.tradeAlertSource.Current == null || e == null || myOnCellClick == null) return;
                foreach (gridColumnName item in Enum.GetValues(typeof(gridColumnName)))
                {
                    if (item.ToString() != dataGrid.Columns[e.ColumnIndex].Name) continue;
                    myOnCellClick(item, (data.baseDS.tradeAlertRow)((DataRowView)this.tradeAlertSource.Current).Row);
                    break;
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteTradeAlerts();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void viewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                EditTradeAlert();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void orderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PlaceOrder();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void showFilterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                myAlertFilterForm.ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void ignoreBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid.RowCount == 0) return;
                if (dataGrid.SelectedRows.Count == 0)
                {
                    common.system.ShowErrorMessage(Languages.Libs.GetString("pleaseSelectRows"));
                    return;
                }
                IgnnoreAlerts();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void recoverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid.RowCount == 0) return;

                if (dataGrid.SelectedRows.Count == 0)
                {
                    common.system.ShowErrorMessage(Languages.Libs.GetString("pleaseSelectRows"));
                    return;
                }
                RecoverAlerts();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void toolBarPnl_myOnShowStateChanged(object sender)
        {
            try
            {
                FormResize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void strategySource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion event handler
    }
}