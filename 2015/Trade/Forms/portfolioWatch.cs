using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;
using commonTypes;
using commonClass;

namespace Trade.Forms
{
    public partial class  portfolioWatch : baseClass.forms.baseForm
    {
        private Size lastSize = new Size(0,0);
        private Color headerBG1 = Color.Aqua, headerFG1 = Color.Black;
        private Color headerBG2 = Color.Green, headerFG2 = Color.White;
        private Color headerBG3 = Color.Pink, headerFG3 = Color.Black;

        public enum gridColumnName 
        {
            Code, MarketCode, Qty,Name, BoughtPrice, Price, BoughtAmt, CurrentAmt, 
            ProfitVariantAmt, ProfitVariantPerc, PriceVariant  
        }
        // See Making Thread-Safe Calls by using BackgroundWorker
        // http://msdn.microsoft.com/en-us/library/ms171728.aspx
        private BackgroundWorker bgWorker = new BackgroundWorker();
        public portfolioWatch()
        {
            try
            {
                this.fOnProccessing = true;
                InitializeComponent();
                Init();
                SetDetailGrid();
                common.dialogs.SetFileDialogEXCEL(saveFileDialog);
                LoadData(true);
                
                this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
                this.fOnProccessing = false;                
            }
            catch (Exception er)
            {
                this.fOnProccessing = false;
                this.ShowError(er);
            }
        }

        public ContextMenuStrip myContextMenuStrip
        {
            get { return dataGV.ContextMenuStrip; }
            set { this.dataGV.ContextMenuStrip = value; }
        }
        public databases.tmpDS.porfolioWatchRow myCurrentRow
        {
            get
            {
                if (portfolioWatchSource.Current == null) return null;
                return (databases.tmpDS.porfolioWatchRow)((DataRowView)portfolioWatchSource.Current).Row;
            }
        }

        public void Init()
        {
            this.fOnProccessing = true;
            try
            {
                portfolioListCb.LoadData(AppTypes.PortfolioTypes.Portfolio, commonClass.SysLibs.sysLoginCode, true);
                portfolioListCb.SelectFirstIfNull();

                headerBG1 = dataGV.ColumnHeadersDefaultCellStyle.BackColor;
                headerFG1 = dataGV.ColumnHeadersDefaultCellStyle.ForeColor;
                //this.dataGV.ColumnHeadersHeight = SystemInformation.CaptionHeight * 2;
                this.fOnProccessing = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
                this.fOnProccessing = false;
            }
        }
        protected void SetDetailGrid()
        {
            this.dataGV.ColumnHeadersHeight = SystemInformation.CaptionHeight * 2;
            byte amtPrecision = common.system.GetPrecisionFromMask(commonTypes.Settings.sysMaskLocalAmt);
            byte pricePrecision = common.system.GetPrecisionFromMask(commonTypes.Settings.sysMaskPrice);
            byte percPrecision = common.system.GetPrecisionFromMask(commonTypes.Settings.sysMaskPercent);
            byte qtyPrecision = common.system.GetPrecisionFromMask(commonTypes.Settings.sysMaskQty);

            codeColumn.HeaderText = "";
            codeColumn.Name = gridColumnName.Code.ToString();

            marketColumn.Name = gridColumnName.MarketCode.ToString();

            nameColumn.Name = gridColumnName.Name.ToString();

            qtyColumn.Name = gridColumnName.Qty.ToString();
            qtyColumn.DefaultCellStyle.Format = "N" + qtyPrecision;
            qtyColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            boughtPriceColumn.Name = gridColumnName.BoughtPrice.ToString();
            boughtPriceColumn.DefaultCellStyle.Format = "N" + pricePrecision;
            boughtPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            priceColumn.Name = gridColumnName.Price.ToString();
            priceColumn.DefaultCellStyle.Format = "N" + pricePrecision;
            priceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            boughtAmtColumn.Name = gridColumnName.BoughtAmt.ToString();
            boughtAmtColumn.DefaultCellStyle.Format = "N" + amtPrecision;
            boughtAmtColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            amtColumn.Name = gridColumnName.CurrentAmt.ToString();
            amtColumn.DefaultCellStyle.Format = "N" + amtPrecision;
            amtColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            profitVariantAmtColumn.Name = gridColumnName.ProfitVariantAmt.ToString();
            profitVariantAmtColumn.DefaultCellStyle.Format = "N" + amtPrecision;
            profitVariantAmtColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            profitVariantPercColumn.Name = gridColumnName.ProfitVariantPerc.ToString();
            profitVariantPercColumn.DefaultCellStyle.Format = "N" + percPrecision;
            profitVariantPercColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            priceVariantColumn.Name = gridColumnName.PriceVariant.ToString();
            priceVariantColumn.DefaultCellStyle.Format = "N" + amtPrecision;
            priceVariantColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        private Forms.tradeAlertList _myTradeAlertListForm = null;
        private Forms.tradeAlertList myTradeAlertListForm
        {
            get
            {
                if (_myTradeAlertListForm == null || _myTradeAlertListForm.IsDisposed)
                    _myTradeAlertListForm = GetTradeAlertListForm();
                return _myTradeAlertListForm;
            }
        }
        protected virtual Forms.tradeAlertList GetTradeAlertListForm()
        {
            Forms.tradeAlertList myForm = new Forms.tradeAlertList();
            myForm.SetColumnVisible(tradeAlertList.gridColumnName.StockCode.ToString(), false);
            return myForm;
        }

        public void RefreshData(bool force)
        {
            if (this.bgWorker.IsBusy)
                return;            
            this.bgWorker.RunWorkerAsync(force);
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            portfolioListCb.SetLanguage();
            nameColumn.DataPropertyName = (commonClass.SysLibs.IsUseVietnamese() ? myTmpDS.porfolioWatch.nameColumn.ColumnName :
                                            myTmpDS.porfolioWatch.nameEnColumn.ColumnName);

            codeColumn.HeaderText  = Languages.Libs.GetString("code");
            marketColumn.HeaderText = Languages.Libs.GetString("exchange");
            nameColumn.HeaderText = Languages.Libs.GetString("name");
            qtyColumn.HeaderText = Languages.Libs.GetString("qty");
            priceColumn.HeaderText = Languages.Libs.GetString("currentPrice");
            amtColumn.HeaderText = Languages.Libs.GetString("currentAmt");
            boughtPriceColumn.HeaderText = Languages.Libs.GetString("boughtPrice");
            boughtAmtColumn.HeaderText = Languages.Libs.GetString("boughtAmt");
            profitVariantAmtColumn.HeaderText = Languages.Libs.GetString("profit");
            string title = Languages.Libs.GetString("portfolioWatch");
            this.SetTitle(title,title);
            
            Refresh();
        }

        public void Export()
        {
            if (dataGV.DataSource == null)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("noData"));
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel(myTmpDS.stockCode, saveFileDialog.FileName);
        }

        protected void LoadData(bool force)
        {
            if (dataGV.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    DoLoadData(force);
                });
            }
            else
            {
                DoLoadData(force);
            }
        }

        protected void DoLoadData(bool force)
        {
            int savePossition = portfolioWatchSource.Position;
            //TUAN - 29 Sept 2012 remove for no flicker when refresh data
            //myTmpDS.porfolioWatch.Clear();
            LoadPorfolioWatch(myTmpDS.porfolioWatch, commonClass.SysLibs.sysLoginCode);
            if (savePossition >= 0) portfolioWatchSource.Position = savePossition;
        }
        
        protected void SetListColor()
        {
            decimal variant = 0;
            for (int idx = 0; idx < dataGV.RowCount; idx++)
            {
                variant = (decimal)dataGV.Rows[idx].Cells[priceVariantColumn.Name].Value;
                if (variant < 0)
                {
                    dataGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Settings.sysPriceColor_Decrease_BG;
                    dataGV.Rows[idx].Cells[priceVariantColumn.Name].Style.ForeColor = Settings.sysPriceColor_Decrease_FG;
                    continue;
                }
                if (variant > 0)
                {
                    dataGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Settings.sysPriceColor_Increase_BG;
                    dataGV.Rows[idx].Cells[priceVariantColumn.Name].Style.ForeColor = Settings.sysPriceColor_Increase_FG;
                    continue;
                }
                dataGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Settings.sysPriceColor_NotChange_BG;
                dataGV.Rows[idx].Cells[priceVariantColumn.Name].Style.ForeColor = Settings.sysPriceColor_NotChange_FG;
            }
        }
        
        protected void FormResize()
        {
            dataGV.Location = new Point(0, portfolioListCb.Location.Y + portfolioListCb.Height);
            dataGV.Size = new Size(this.ClientSize.Width - dataGV.Location.X, this.ClientSize.Height - dataGV.Location.Y);
            common.system.AutoFitGridColumn(dataGV,nameColumn.Name);
        }
        protected void LoadPorfolioWatch(databases.tmpDS.porfolioWatchDataTable tbl,string investorCode)
        {
            databases.tmpDS.investorStockDataTable investorStockTbl = DataAccess.Libs.GetOwnedStockSum_ByInvestor(investorCode);
            if (investorStockTbl == null) return;

            databases.tmpDS.porfolioWatchRow porfolioWatchRow;
            for (int idx1 = 0; idx1 < investorStockTbl.Count; idx1++)
            {
                porfolioWatchRow = tbl.FindBycode(investorStockTbl[idx1].stockCode);
                if (porfolioWatchRow == null)
                {
                    databases.tmpDS.stockCodeRow stockCodeRow = DataAccess.Libs.myStockCodeTbl.FindBycode(investorStockTbl[idx1].stockCode);
                    if (stockCodeRow == null) continue;

                    porfolioWatchRow = tbl.NewporfolioWatchRow();
                    databases.AppLibs.InitData(porfolioWatchRow);
                    porfolioWatchRow.code = investorStockTbl[idx1].stockCode;
                    porfolioWatchRow.stockExchange = stockCodeRow.stockExchange;
                    porfolioWatchRow.name = stockCodeRow.name;
                    porfolioWatchRow.nameEn = stockCodeRow.nameEn;
                    tbl.AddporfolioWatchRow(porfolioWatchRow);
                }
                //TUAN - 29 Sept 2012 remove for no flicker when refresh data
                else
                {
                    databases.tmpDS.stockCodeRow stockCodeRow = DataAccess.Libs.myStockCodeTbl.FindBycode(investorStockTbl[idx1].stockCode);
                    if (stockCodeRow == null) continue;
                    porfolioWatchRow = tbl.NewporfolioWatchRow();
                    databases.AppLibs.InitData(porfolioWatchRow);
                    porfolioWatchRow.code = investorStockTbl[idx1].stockCode;
                    porfolioWatchRow.stockExchange = stockCodeRow.stockExchange;
                    porfolioWatchRow.name = stockCodeRow.name;
                    porfolioWatchRow.nameEn = stockCodeRow.nameEn;                    
                }
                //TUAN - 29 Sept 2012 remove for no flicker when refresh data
                porfolioWatchRow.qty += investorStockTbl[idx1].qty;
                porfolioWatchRow.boughtAmt += investorStockTbl[idx1].buyAmt;
            }
            UpdatePrice(tbl);
            SetListColor();
        }

        protected void UpdatePrice(databases.tmpDS.porfolioWatchDataTable reportTbl)
        {
            databases.baseDS.lastPriceDataDataTable lastOpenPriceTbl = DataAccess.Libs.myLastDailyOpenPrice;
            databases.baseDS.lastPriceDataDataTable lastClosePriceTbl = DataAccess.Libs.myLastDailyClosePrice;

            databases.tmpDS.porfolioWatchRow reportRow;
            databases.baseDS.lastPriceDataRow priceRow;
            databases.baseDS.stockExchangeRow stockExchangeRow;
            for (int idx1 = 0; idx1 < reportTbl.Count; idx1++)
            {
                reportRow = reportTbl[idx1];
                
                stockExchangeRow = DataAccess.Libs.myStockExchangeTbl.FindBycode(reportRow.stockExchange);
                if (stockExchangeRow == null || stockExchangeRow.priceRatio == 0) continue;

                decimal priceWeight = stockExchangeRow.priceRatio;
                decimal volumeWeight = stockExchangeRow.volumeRatio;
                reportRow.boughtPrice = (reportRow.qty == 0 ? 0 : reportRow.boughtAmt / reportRow.qty) / priceWeight;

                priceRow = lastClosePriceTbl.FindBystockCode(reportRow.code);
                if (priceRow != null)
                {
                    reportRow.price = priceRow.value;
                    priceRow = lastOpenPriceTbl.FindBystockCode(reportRow.code);
                    if (priceRow != null) reportRow.priceVariant = reportRow.price - priceRow.value;
                    else reportRow.priceVariant = 0;
                }

                reportRow.amt = reportRow.qty * reportRow.price * priceWeight;
                reportRow.profitVariantAmt = reportRow.amt - reportRow.boughtAmt;
                reportRow.profitVariantPerc = (reportRow.boughtAmt == 0 ? 0 : reportRow.profitVariantAmt / reportRow.boughtAmt) * 100;
            }
        }
        
        #region event handler
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (this.fOnProccessing) return;
                this.fOnProccessing = true;
                LoadData((bool)e.Argument);
                this.fOnProccessing = false;
            }
            catch (Exception er)
            {
                //this.fOnProccessing = false;
                this.ShowError(er);
            }
        }

        private void dataGV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                Rectangle rtHeader = dataGV.DisplayRectangle;
                rtHeader.Height = dataGV.ColumnHeadersHeight / 2;
                dataGV.Invalidate(rtHeader);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        //??
        private void dataGV_Paint(object sender, PaintEventArgs e)
        {
            if (this.fOnProccessing) return;
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center; format.LineAlignment = StringAlignment.Center;
            Font font = dataGV.ColumnHeadersDefaultCellStyle.Font;

            common.gridView.DrawGridCell(Languages.Libs.GetString("code"), format, font, headerFG1, headerBG1, e.Graphics, dataGV, 0, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell(Languages.Libs.GetString("exchange"), format, font, headerFG1, headerBG1, e.Graphics, dataGV, 1, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell(Languages.Libs.GetString("name"), format, font, headerFG1, headerBG1, e.Graphics, dataGV, 2, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell(Languages.Libs.GetString("qty"), format, font, headerFG1, headerBG1, e.Graphics, dataGV, 3, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell(Languages.Libs.GetString("price") + common.Consts.constCRLF + "(+/-)", format, font, headerFG1, headerBG1, e.Graphics, dataGV, 10, -1, 1, 1, 0, 0);

            int startColIdx = 4;
            string[] header11 = new string[] { Languages.Libs.GetString("price"), Languages.Libs.GetString("value"), Languages.Libs.GetString("revennue") };
            string[] header12 = new string[] { Languages.Libs.GetString("buy"), Languages.Libs.GetString("current"), 
                                               Languages.Libs.GetString("buy"), Languages.Libs.GetString("current"), 
                                               Languages.Libs.GetString("value"), "%", };
            for (int idx1 = 0, idx2 = 0; idx2 < header12.Length; idx1++, idx2 += 2)
            {
                common.gridView.DrawGridCell(header11[idx1], format, font, headerFG2, headerBG2,
                             e.Graphics, dataGV, startColIdx + idx2, -1, 2, 0.55m, 0, 0);

                //Rectangle r2,r3 under r1 and for each column. 
                common.gridView.DrawGridCell(header12[idx2], format, font, headerFG3, headerBG3,
                             e.Graphics, dataGV, startColIdx + idx2, -1, 1, 0.5m, 0, 0.5m);

                common.gridView.DrawGridCell(header12[idx2 + 1], format, font, headerFG3, headerBG3,
                                             e.Graphics, dataGV, startColIdx + idx2 + 1, -1, 1, 0.5m, 0, 0.5m);
            }
            lastSize = this.Size;
        }
        private void dataGV_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                return;
                Rectangle rtHeader = dataGV.DisplayRectangle;
                rtHeader.Height = dataGV.ColumnHeadersHeight / 2;
                dataGV.Invalidate(rtHeader);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void dataGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //SetListColor();
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
                this.ShowMessage("");
                LoadData(true);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void watchListCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.fOnProccessing) return;
                if (portfolioListCb.myValue == portfolioListCb.lastValue) return;
                this.ShowCurrorWait();
                LoadData(true);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                this.ShowCurrorDefault();
            }
        }
        private void basePortfolioView_Resize(object sender, EventArgs e)
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

        #endregion
    }
}