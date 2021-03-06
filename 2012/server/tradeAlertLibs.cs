using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using commonClass;

namespace server
{
    public class TradeAlertLibs
    {
        #region strategy estimation
        public delegate void onProcessStart(int stockCodeCount);
        public delegate bool onProcessItem(string stockcode);
        public delegate void onProcessEnd();

        private class TradeAlert
        {
            public TradePointInfo TradePoint = null;
            public AppTypes.TimeScale TimeScale =  AppTypes.MainDataTimeScale;
            public string StockCode="", Strategy="";
            public DateTime OnDateTime = common.Consts.constNullDate;
            public double Price=0,Volume=0;
            public TradeAlert(string stockCode, string strategy, AppTypes.TimeScale timeScale, DateTime onDateTime,
                               double price, double volume, TradePointInfo tradePoint)
            {
                this.StockCode = stockCode;
                this.TimeScale = timeScale;
                this.Strategy = strategy;
                this.OnDateTime = onDateTime;
                this.Price = price;
                this.Volume = volume;
                this.TradePoint = tradePoint;
            }
        }

        private static void SaveLastRunTime(DateTime onTime)
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Add(configuration.configKeys.sysTradeAlertLastRun.ToString());
            aValues.Add(onTime.ToString());
            data.configuration.SaveConfig(aFields, aValues);
        }
        
        //withAplicableCheckInAlert = true : Sell alerts only create when user owned stock that is applible to sell
        private static bool withAplicableCheckInAlert = false;

        /// <summary>
        /// Create alerts for all stock in portfolio
        /// </summary>
        /// <param name="alertList"> all alert resulted from analysis </param>
        /// <param name="frDate">Alert will only create alert in range [frDate,toDate].
        /// It also ensure that in the same day,there in ONLY one new alert of the same type</param>
        /// <param name="toDate"></param>
        private static void CreateTradeAlert(TradeAlert[] alertList,DateTime frDate,DateTime toDate)
        {
            decimal availabeQty;
            string msg;
            StringCollection timeScaleList;

            data.baseDS.tradeAlertRow tradeAlertRow;
            data.baseDS.tradeAlertDataTable tradeAlertTbl = new data.baseDS.tradeAlertDataTable();
            data.baseDS.portfolioDetailDataTable portfolioDetailTbl = new data.baseDS.portfolioDetailDataTable();
            DataView portfolioDetailView = new DataView(portfolioDetailTbl);

            //Sort by  Stock code + Strategy code
            portfolioDetailView.Sort = portfolioDetailTbl.codeColumn.ColumnName + "," + portfolioDetailTbl.subCodeColumn.ColumnName;
            DataRowView[] portfolioDetailFound;
            data.baseDS.portfolioDetailRow portfolioDataRow;

            portfolioDetailTbl = data.DbAccess.GetPortfolioDetail_ByType(new AppTypes.PortfolioTypes[] { AppTypes.PortfolioTypes.WatchList, AppTypes.PortfolioTypes.Portfolio });
            // Only alert on stock codes that were selected by user. 
            for (int alertId = 0; alertId < alertList.Length; alertId++)
            {
                // Check if alert's strategy in user's wish list ??
                portfolioDetailFound = portfolioDetailView.FindRows(new object[] { alertList[alertId].StockCode, alertList[alertId].Strategy.Trim() });
                for (int dataIdx = 0; dataIdx < portfolioDetailFound.Length; dataIdx++)
                {
                    // Check if time alert's time scale in user's wish list ??
                    portfolioDataRow = ((data.baseDS.portfolioDetailRow)portfolioDetailFound[dataIdx].Row);
                    timeScaleList = common.MultiValueString.String2List(portfolioDataRow.data.Trim());
                    if (!timeScaleList.Contains(alertList[alertId].TimeScale.Code)) continue;
                    
                    //Do not crete alert if there is a NEW one.
                    tradeAlertRow = data.DbAccess.GetLastAlert( frDate, toDate, portfolioDataRow.portfolio,
                                                                alertList[alertId].StockCode,
                                                                alertList[alertId].Strategy,
                                                                alertList[alertId].TimeScale.Code,
                                                            (byte)AppTypes.CommonStatus.New);
                    if (tradeAlertRow != null) continue;

                    //Availabe stock
                    if (withAplicableCheckInAlert)
                    {
                        availabeQty = data.AppLibs.GetAvailableStock(alertList[alertId].StockCode, portfolioDataRow.portfolio,
                                                                    Settings.sysStockSell2BuyInterval, alertList[alertId].OnDateTime);
                    }
                    else availabeQty = int.MaxValue;

                    //Aplicable to sell
                    if ((alertList[alertId].TradePoint.TradeAction == AppTypes.TradeActions.Sell ||
                          alertList[alertId].TradePoint.TradeAction == AppTypes.TradeActions.ClearAll) && (availabeQty <= 0)) continue;
                    msg = " - Giá : " + alertList[alertId].Price.ToString() + common.Consts.constCRLF +
                          " - K/L giao dịch : " + alertList[alertId].Volume.ToString() + common.Consts.constCRLF +
                          " - Xu hướng : (" + alertList[alertId].TradePoint.BusinessInfo.ToString() + "," +
                                              alertList[alertId].TradePoint.BusinessInfo.LongTermTrend + ")" + common.Consts.constCRLF +
                          " - K/L sở hữu hợp lệ : " + availabeQty.ToString() + common.Consts.constCRLF;

                    CreateTradeAlert(tradeAlertTbl, portfolioDataRow.portfolio, alertList[alertId].StockCode, alertList[alertId].Strategy,
                                     alertList[alertId].TimeScale, alertList[alertId].TradePoint, toDate, msg);
                }
            }
            data.DbAccess.UpdateData(tradeAlertTbl);
        }

        private static void CreateTradeAlert(data.baseDS.tradeAlertDataTable tradeAlertTbl,string portfolioCode,
                                             string stockCode, string strategy, AppTypes.TimeScale timeScale, TradePointInfo info, DateTime onTime, string msg)
        {
            data.baseDS.tradeAlertRow row = tradeAlertTbl.NewtradeAlertRow();
            data.AppLibs.InitData(row);
            row.onTime = onTime;
            row.portfolio = portfolioCode;
            row.stockCode = stockCode;
            row.timeScale = timeScale.Code; 
            row.strategy = strategy; 
            row.status = (byte)AppTypes.CommonStatus.New; 
            row.tradeAction = (byte)info.TradeAction;
            row.subject = info.TradeAction.ToString();
            row.msg = msg;
            tradeAlertTbl.AddtradeAlertRow(row);
        }

        public static void CreateTradeAlert()
        {
            CreateTradeAlert(null, null, null);
        }
        public static void CreateTradeAlert(onProcessStart onStartFunc, onProcessItem onProcessItemFunc, onProcessEnd onEndFunc)
        {
            CultureInfo cultureInfo = new CultureInfo(Settings.sysCultureCode);
            DateTime frDate = common.Consts.constNullDate;
            DateTime toDate = DateTime.Now;
            
            //Run all strategy analysis for all stocks.
            data.tmpDS.stockCodeDataTable stockCodeTbl = new data.tmpDS.stockCodeDataTable();
            global::data.DbAccess.LoadData(stockCodeTbl, AppTypes.CommonStatus.Enable);

            application.Data data = new application.Data();

            TradeAlert[] tradeAlertList = new TradeAlert[0];
            StringCollection strategyList = new StringCollection();
            for (int idx = 0; idx < Strategy.Data.MetaList.Values.Length; idx++)
            {
                Strategy.Meta meta = (Strategy.Meta)Strategy.Data.MetaList.Values[idx];
                if (meta.Type != AppTypes.StrategyTypes.Strategy) continue;
                strategyList.Add(((Strategy.Meta)Strategy.Data.MetaList.Values[idx]).Code);
            }

            if (onStartFunc != null) onStartFunc(stockCodeTbl.Count);

            for (int stockCodeIdx = 0; stockCodeIdx < stockCodeTbl.Count; stockCodeIdx++)
            {
                if (onProcessItemFunc != null)
                    if (!onProcessItemFunc(stockCodeTbl[stockCodeIdx].code)) break;

                foreach (AppTypes.TimeScale timeScale in AppTypes.myTimeScales)
                {
                    //Move date ahead to ensure that there are sufficient data need in analysis process
                    switch (timeScale.Type)
                    {
                        case AppTypes.TimeScaleTypes.RealTime:
                            frDate = toDate.AddHours(-1);
                            break;
                        case AppTypes.TimeScaleTypes.Hour:
                            frDate = toDate.Date;
                            break;
                        case AppTypes.TimeScaleTypes.Day:
                            frDate = toDate.Date;
                            break;
                        case AppTypes.TimeScaleTypes.Week:
                            frDate = common.dateTimeLibs.StartOfWeek(toDate, cultureInfo).AddSeconds(-1);
                            break;
                        case AppTypes.TimeScaleTypes.Month:
                            frDate = common.dateTimeLibs.MakeDate(1, toDate.Month, toDate.Year).AddSeconds(-1);
                            break;
                        case AppTypes.TimeScaleTypes.Year:
                            frDate = common.dateTimeLibs.MakeDate(1, 1, toDate.Year).AddSeconds(-1);
                            break;
                        default:
                            common.system.ThrowException("Invalid parametter in calling to LoadStockPrice()");
                            break;
                    }

                    data.Reload(stockCodeTbl[stockCodeIdx].code,timeScale,frDate, toDate);

                    for (int strategyIdx = 0; strategyIdx < strategyList.Count; strategyIdx++)
                    {
                        Strategy.Data.ClearCache();
                        Strategy.Data.TradePoints advices = Strategy.Libs.Analysis(data, strategyList[strategyIdx].Trim());
                        if (advices == null) continue;
                        for (int idx3 = 0; idx3 < advices.Count; idx3++)
                        {
                            TradePointInfo tradeInfo = (TradePointInfo)advices[idx3];
                            Array.Resize(ref tradeAlertList, tradeAlertList.Length + 1);
                            tradeAlertList[tradeAlertList.Length - 1]=
                                new TradeAlert(stockCodeTbl[stockCodeIdx].code.Trim(), strategyList[strategyIdx].Trim(),
                                               timeScale, DateTime.FromOADate(data.DateTime[tradeInfo.DataIdx]),
                                               data.Close[tradeInfo.DataIdx],
                                               data.Volume[tradeInfo.DataIdx],
                                               tradeInfo);

                        }
                    }
                }
            }
            stockCodeTbl.Dispose();

            //Create alerts in the day
            CreateTradeAlert(tradeAlertList,toDate.Date,toDate);

            //Save last lun date
            SaveLastRunTime(toDate);
            if (onEndFunc != null) onEndFunc();
        }
        #endregion
    }
}
