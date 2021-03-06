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

namespace stockTrade.forms
{
    public partial class basePortfolioView : common.forms.baseForm
    {
        private Color headerBG1 = Color.Aqua, headerFG1 = Color.Black;
        private Color headerBG2 = Color.Green, headerFG2 = Color.White;
        private Color headerBG3 = Color.Pink, headerFG3 = Color.Black;
        public enum gridColumnName 
        {
            StockCode, StockExCode, Qty, BoughtPrice, Price, BoughtAmt, CurrentAmt, 
            ProfitVariantAmt, ProfitVariantPerc, PriceVariant, Volume, Notes
        };

        public basePortfolioView()
        {
            try
            {
                InitializeComponent();

                headerBG1 = stockGV.ColumnHeadersDefaultCellStyle.BackColor;
                headerFG1 = stockGV.ColumnHeadersDefaultCellStyle.ForeColor;

                stockCodeColumn.HeaderText="";
                stockCodeColumn.Name = gridColumnName.StockCode.ToString();

                stockExCodeColumn.HeaderText = "";
                stockExCodeColumn.Name = gridColumnName.StockExCode.ToString();

                qtyColumn.HeaderText = "";
                qtyColumn.Name = gridColumnName.Qty.ToString();

                boughtPriceColumn.HeaderText = "";
                boughtPriceColumn.Name = gridColumnName.BoughtPrice.ToString();

                priceColumn.HeaderText = "";
                priceColumn.Name = gridColumnName.Price.ToString();

                boughtAmtColumn.HeaderText = "";
                boughtAmtColumn.Name = gridColumnName.BoughtAmt.ToString();

                amtColumn.HeaderText = "";
                amtColumn.Name = gridColumnName.CurrentAmt.ToString();

                profitVariantAmtColumn.HeaderText = "";
                profitVariantAmtColumn.Name = gridColumnName.ProfitVariantAmt.ToString();

                profitVariantPercColumn.HeaderText = "";
                profitVariantPercColumn.Name = gridColumnName.ProfitVariantPerc.ToString();

                priceVariantColumn.HeaderText = "";
                priceVariantColumn.Name = gridColumnName.PriceVariant.ToString();

                notesColumn.HeaderText = "";
                notesColumn.Name = gridColumnName.Notes.ToString();
                notesColumn.DefaultCellStyle.ForeColor = common.settings.sysColorHiLightFG1; 

                volumeColumn.Name = gridColumnName.Volume.ToString();

                porfolioCb.LoadData(application.sysLibs.sysLoginCode,true);
                ResizeForm();

                stockGV.DisableReadOnlyColumn = false;

                myTradeAlertListForm.InitForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private forms.baseTradeAlertList _myTradeAlertListForm = null;
        private forms.baseTradeAlertList myTradeAlertListForm
        {
            get
            {
                if (_myTradeAlertListForm == null || _myTradeAlertListForm.IsDisposed)
                    _myTradeAlertListForm = GetTradeAlertListForm();
                return _myTradeAlertListForm;
            }
        }
        protected virtual forms.baseTradeAlertList GetTradeAlertListForm()
        {
            forms.baseTradeAlertList myForm = new forms.baseTradeAlertList();
            myForm.InitForm();
            myForm.SetColumnVisible(baseTradeAlertList.gridColumnName.StockCode.ToString(), false);
            return myForm;
        }
        public delegate void onShowChart(data.baseDS.stockCodeExtRow stockRow);
        public event onShowChart myOnShowChart = null;

        protected bool myUseCustomHeader = true;
        public void LoadData()
        {
            myTmpDS.portfolioList.Clear();
            LoadData(myTmpDS.portfolioList, porfolioCb.GetValues());
        }
        protected virtual void LoadData(data.tmpDS.portfolioListDataTable toTbl, string[] portfolioCodes)
        {
            LoadStockList(portfolioCodes, toTbl);
            UpdateRealTime(toTbl, portfolioCodes);
        }
        protected void LoadStockList(string[] portfolioCodes, data.tmpDS.portfolioListDataTable toTbl)
        {
            //Load stocks in portfolio
            data.baseDS.stockCodeExtDataTable myStockCodeTbl = new data.baseDS.stockCodeExtDataTable();
            dataLibs.LoadData(myStockCodeTbl, portfolioCodes);

            DataView myStockView = new DataView(myStockCodeTbl);
            data.baseDS.stockCodeExtRow stockRow;
            myStockView.Sort = myStockCodeTbl.codeColumn.ColumnName + "," + myStockCodeTbl.stockExchangeColumn.ColumnName;
            data.tmpDS.portfolioListRow reportRow;
            for (int idx1 = 0; idx1 < myStockView.Count; idx1++)
            {
                stockRow = (data.baseDS.stockCodeExtRow)myStockView[idx1].Row;
                //Ignore duplicate stocks
                reportRow = toTbl.FindBystockCode(stockRow.code);
                if (reportRow != null) continue;
                reportRow = toTbl.NewportfolioListRow();
                dataLibs.InitData(reportRow);
                reportRow.stockCode = stockRow.code;
                reportRow.stockExCode = stockRow.stockExchange;
                toTbl.AddportfolioListRow(reportRow);
            }
        }
        protected void UpdateRealTime(data.tmpDS.portfolioListDataTable reportTbl, string[] portfolioCodes)
        {
            DateTime onTime = application.sysLibs.GetServerDateTime();

            data.baseDS.priceDataRow priceRow;
            data.tmpDS.portfolioListRow reportRow;
            decimal qty = 0, boughtAmt = 0;

            //Prepare data to get Alert sumary data in AlertSummaryInfo()
            data.baseDS.tradeAlertDataTable tradeAlertTbl = new data.baseDS.tradeAlertDataTable();
            for (int idx = 0; idx < portfolioCodes.Length; idx++)
            {
                dataLibs.LoadData(tradeAlertTbl, portfolioCodes[idx], onTime.Date, onTime, (byte)application.myTypes.commonStatus.New);
            }
            DataView tradeAlertView = new DataView(tradeAlertTbl);
            tradeAlertView.Sort = tradeAlertTbl.stockCodeColumn.ColumnName;
            for (int idx1 = 0; idx1 < reportTbl.Count; idx1++)
            {
                reportRow = reportTbl[idx1];
                reportRow.qty = 0; reportRow.boughtAmt = 0;
                for (int idx2 = 0; idx2 < portfolioCodes.Length; idx2++)
                {
                    dataLibs.GetOwnStock(reportRow.stockCode, portfolioCodes[idx2], 0, onTime, out qty, out boughtAmt);
                    reportRow.qty += qty; reportRow.boughtAmt += boughtAmt;
                }
                reportRow.boughtPrice = (reportRow.qty == 0 ? 0 : reportRow.boughtAmt / reportRow.qty) / application.Settings.sysStockPriceWeight;

                priceRow = application.dataLibs.GetPriceData(onTime.Date, onTime, reportRow.stockCode);
                reportRow.price = (priceRow == null ? 0 : priceRow.closePrice);
                reportRow.priceVariant = (priceRow == null ? 0 : reportRow.price - priceRow.openPrice);
                reportRow.volume = (priceRow == null ? 0 : priceRow.volume);
                reportRow.amt = reportRow.qty * reportRow.price * application.Settings.sysStockPriceWeight;
                reportRow.profitVariantAmt = reportRow.amt - reportRow.boughtAmt;
                reportRow.profitVariantPerc = (reportRow.boughtAmt == 0 ? 0 : reportRow.profitVariantAmt / reportRow.boughtAmt) * 100;

                //Alert summary info
                reportRow.notes = AlertSummaryInfo(reportRow.stockCode, tradeAlertView);
            }
        }
        protected string AlertSummaryInfo(string stockCode, DataView tradeAlertView)
        {
            data.baseDS.tradeAlertRow tradeAlertRow;
            DataRowView[] foundRows = tradeAlertView.FindRows(stockCode);
            StringCollection list = new StringCollection(); 
            for (int idx = 0; idx < foundRows.Length; idx++)
            {
                tradeAlertRow = (data.baseDS.tradeAlertRow)foundRows[idx].Row;
                if (list.Contains(((application.analysis.tradeActions)tradeAlertRow.tradeAction).ToString())) continue;
                list.Add(((application.analysis.tradeActions)tradeAlertRow.tradeAction).ToString());
            }
            string msg = "";
            for (int idx = 0; idx < list.Count; idx++)
            {
                msg += (msg == "" ? "" : " / ") + list[idx];
            }
            return msg;
        }
        protected void PortfolioStockColor()
        {
            decimal variant = 0;
            for (int idx = 0; idx < stockGV.RowCount; idx++)
            {
                variant = (decimal)stockGV.Rows[idx].Cells[priceVariantColumn.Name].Value;
                if (variant < 0)
                {
                    stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Color.Red;
                    continue;
                }
                if (variant > 0)
                {
                    stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Color.SkyBlue;
                    continue;
                }
                stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Color.Yellow;
            }
        }
        protected virtual void ResizeForm()
        {
            this.Width = this.stockGV.Width + 10;
            this.stockGV.Height = this.ClientRectangle.Height - SystemInformation.CaptionHeight - toolBarPnl.Height-1;
        }
        protected void ShowTradeAlert()
        {
            if (portfolioListSource.Current == null) return;
            string stockCode = ((data.tmpDS.portfolioListRow)((DataRowView)portfolioListSource.Current).Row).stockCode.Trim();
            myTradeAlertListForm.myPortfolioCode = porfolioCb.myValue;
            myTradeAlertListForm.myStockCode  =  stockCode;
            myTradeAlertListForm.LoadData();
            common.system.ShowForm(myTradeAlertListForm, false);
        }
        private void ShowChart()
        {
            if (this.myOnShowChart==null || portfolioListSource.Current == null) return;
            string stockCode = ((data.tmpDS.portfolioListRow)((DataRowView)portfolioListSource.Current).Row).stockCode.Trim();
            data.baseDS.stockCodeExtRow stockRow = dataLibs.FindAndCache(myDataSet.stockCodeExt,stockCode);  
            if (stockRow==null) return;
            myOnShowChart(stockRow);
        }

        #region event handler
        private void baseTradeAlert_Resize(object sender, EventArgs e)
        {
            try
            {
                ResizeForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void baseTradeAlertList_Shown(object sender, EventArgs e)
        {
            {
                try
                {
                    this.ShowCurrorWait();
                    porfolioCb.SelectFirstIfNull();
                    LoadData();
                    ResizeForm();
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
        }
       
        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
        private void dataGV1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = stockGV.DisplayRectangle;
            rtHeader.Height = stockGV.ColumnHeadersHeight / 2;
            stockGV.Invalidate(rtHeader);
        }
        private void dataGV1_Paint(object sender, PaintEventArgs e)
        {
            if (!myUseCustomHeader) return;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center; format.LineAlignment = StringAlignment.Center;
            Font font = stockGV.ColumnHeadersDefaultCellStyle.Font;

            common.gridView.DrawGridCell("Mã", format, font, headerFG1, headerBG1, e.Graphics, stockGV, 0, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell("Sàn", format, font, headerFG1, headerBG1,e.Graphics, stockGV, 1, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell("Số.lượng", format, font, headerFG1, headerBG1, e.Graphics, stockGV, 2, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell("+/-Giá", format, font, headerFG1, headerBG1, e.Graphics, stockGV, 9, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell("Tổng KL", format, font, headerFG1, headerBG1, e.Graphics, stockGV, 10, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell("Đề nghị", format, font, headerFG1, headerBG1, e.Graphics, stockGV, 11, -1, 1, 1, 0, 0);
            
            int startColIdx = 3;
            string[] header11 = new string[] { "Giá", "Giá trị", "Lãi lỗ" };
            string[] header12 = new string[] { "Mua", "Hiện.tại", "Mua", "Hiện.tại", "Giá trị", "%", };
            for (int idx1 = 0, idx2 = 0; idx2 < header12.Length; idx1++, idx2 += 2)
            {
                common.gridView.DrawGridCell(header11[idx1], format, font, headerFG2, headerBG2,
                             e.Graphics, stockGV, startColIdx + idx2, -1, 2, 0.5m, 0, 0);

                //Retangle r2,r3 under r1 and for each column. 
                common.gridView.DrawGridCell(header12[idx2], format, font, headerFG3, headerBG3,
                             e.Graphics, stockGV, startColIdx + idx2, -1, 1, 0.5m, 0, 0.5m);

                common.gridView.DrawGridCell(header12[idx2 + 1], format, font, headerFG3, headerBG3,
                                             e.Graphics, stockGV, startColIdx + idx2 + 1, -1, 1, 0.5m, 0, 0.5m);
            }
        }
        private void dataGV1_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = stockGV.DisplayRectangle;
            rtHeader.Height = stockGV.ColumnHeadersHeight / 2;
            stockGV.Invalidate(rtHeader);
        }
        private void porfolioCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ShowCurrorWait();
                LoadData();
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
       
        private void stockGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                PortfolioStockColor();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void myTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("Auto refresh...");
                LoadData();
                this.ShowMessage("");
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
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
       
        private void stockGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (stockGV.Columns[e.ColumnIndex].Name == notesColumn.Name)
                {
                    ShowTradeAlert();
                    return;
                }
                if (stockGV.Columns[e.ColumnIndex].Name == stockCodeColumn.Name)
                {
                    ShowChart();
                    return;
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}