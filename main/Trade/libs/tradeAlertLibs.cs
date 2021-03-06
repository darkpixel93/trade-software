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

namespace Trade
{
    public class AlertLibs
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
            aFields.Add(Configuration.configKeys.sysTradeAlertLastRun.ToString());
            aValues.Add(onTime.ToString());
            application.Configuration.SaveConfig(aFields, aValues);
        }
        
        //withAplicableCheckInAlert = true : Sell alerts only create when user owned stock that is applible to sell
        private static bool withAplicableCheckInAlert = false;

        //Merge alert message with specified-language text
        public static string AlertMessageText(string msg)
        {
            common.myKeyValueItem[] tags = new common.myKeyValueItem[4];
            tags[0] = CreateAlertMessageTag("price");
            tags[1] = CreateAlertMessageTag("volume");
            tags[2] = CreateAlertMessageTag("marketInfo");
            tags[3] = CreateAlertMessageTag("ownedQty");
            return common.system.MergeText(msg, tags);
        }
        private static common.myKeyValueItem CreateAlertMessageTag(string key)
        {
            return new common.myKeyValueItem(Consts.constTextMergeMarkerLEFT + key + Consts.constTextMergeMarkerRIGHT, Languages.Libs.GetString(key));
        }


        /// <summary>
        /// Create alerts for all stock in portfolio
        /// </summary>
        /// <param name="alertList"> all alert resulted from analysis </param>
        private static void CreateTradeAlert(TradeAlert[] alertList)
        {
            decimal availabeQty;
            string msg;
            StringCollection timeScaleList;

            data.baseDS.tradeAlertRow tradeAlertRow;
            data.baseDS.tradeAlertDataTable tradeAlertTbl = new data.baseDS.tradeAlertDataTable();
            data.baseDS.portfolioDetailDataTable portfolioDetailTbl = application.DbAccess.GetPortfolioDetail_ByType(new AppTypes.PortfolioTypes[] { AppTypes.PortfolioTypes.WatchList, AppTypes.PortfolioTypes.Portfolio }); 
            DataView portfolioDetailView = new DataView(portfolioDetailTbl);

            //Sort by  Stock code + Strategy code
            portfolioDetailView.Sort = portfolioDetailTbl.codeColumn.ColumnName + "," + portfolioDetailTbl.subCodeColumn.ColumnName;
            DataRowView[] portfolioDetailFound;
            data.baseDS.portfolioDetailRow portfolioDataRow;

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
                    
                    //Ignore duplicate alerts.
                    tradeAlertRow = application.DbAccess.GetAlert(alertList[alertId].OnDateTime, 
                                                                  portfolioDataRow.portfolio,
                                                                  alertList[alertId].StockCode,
                                                                  alertList[alertId].Strategy,
                                                                  alertList[alertId].TimeScale.Code,
                                                                  AppTypes.CommonStatus.All);
                    if (tradeAlertRow != null) continue;

                    //Availabe stock
                    if (withAplicableCheckInAlert)
                    {
                        data.baseDS.stockExchangeRow stockExchangeRow = application.AppLibs.GetStockExchange(alertList[alertId].StockCode);
                        int sell2BuyInterval = (stockExchangeRow==null?0:stockExchangeRow.minBuySellDay);
                        availabeQty = application.DbAccess.GetAvailableStock(alertList[alertId].StockCode, portfolioDataRow.portfolio,
                                                                             sell2BuyInterval, alertList[alertId].OnDateTime);
                    }
                    else availabeQty = 0;

                    //Aplicable to sell
                    if ((alertList[alertId].TradePoint.TradeAction == AppTypes.TradeActions.Sell ||
                          alertList[alertId].TradePoint.TradeAction == AppTypes.TradeActions.ClearAll) && (availabeQty <= 0)) continue;

                    string infoText = alertList[alertId].TradePoint.BusinessInfo.ToText().Trim();
                    infoText = (infoText != "" ? infoText : common.Consts.constNotAvailable);

                    //Create alert template message, AlertMessageText() will convert it to specified-language text.
                    msg = commonClass.Consts.constTextMergeMarkerLEFT + "price" + commonClass.Consts.constTextMergeMarkerRIGHT + " : " + alertList[alertId].Price.ToString() + common.Consts.constCRLF +
                          commonClass.Consts.constTextMergeMarkerLEFT + "volume" + commonClass.Consts.constTextMergeMarkerRIGHT + " : " + alertList[alertId].Volume.ToString() + common.Consts.constCRLF +
                          commonClass.Consts.constTextMergeMarkerLEFT + "marketInfo" + commonClass.Consts.constTextMergeMarkerRIGHT + " : " + infoText + common.Consts.constCRLF;
                    if (availabeQty >0)
                    {
                        msg += commonClass.Consts.constTextMergeMarkerLEFT + "ownedQty" + commonClass.Consts.constTextMergeMarkerRIGHT + " : " + availabeQty.ToString() + common.Consts.constCRLF;
                    }

                    CreateTradeAlert(tradeAlertTbl, portfolioDataRow.portfolio, alertList[alertId].StockCode, alertList[alertId].Strategy,
                                     alertList[alertId].TimeScale, alertList[alertId].TradePoint, alertList[alertId].OnDateTime, msg);
                }
            }
            application.DbAccess.UpdateData(tradeAlertTbl);
        }

        private static void CreateTradeAlert(data.baseDS.tradeAlertDataTable tradeAlertTbl,string portfolioCode,
                                             string stockCode, string strategy, AppTypes.TimeScale timeScale, TradePointInfo info, DateTime onTime, string msg)
        {
            data.baseDS.tradeAlertRow row = tradeAlertTbl.NewtradeAlertRow();
            commonClass.AppLibs.InitData(row);
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
            DateTime frDate = common.Consts.constNullDate;
            DateTime toDate = DateTime.Now;
            
            //Run all strategy analysis for all stocks.
            data.tmpDS.stockCodeDataTable stockCodeTbl = new data.tmpDS.stockCodeDataTable();
            application.DbAccess.LoadData(stockCodeTbl, AppTypes.CommonStatus.Enable);

            application.AnalysisData data = new application.AnalysisData();

            TradeAlert[] tradeAlertList = new TradeAlert[0];
            StringCollection strategyList = new StringCollection();
            for (int idx = 0; idx < application.Strategy.Data.MetaList.Values.Length; idx++)
            {
                application.Strategy.Meta meta = (application.Strategy.Meta)application.Strategy.Data.MetaList.Values[idx];
                if (meta.Type != AppTypes.StrategyTypes.Strategy) continue;
                strategyList.Add(((application.Strategy.Meta)application.Strategy.Data.MetaList.Values[idx]).Code);
            }

            if (onStartFunc != null) onStartFunc(stockCodeTbl.Count);
            
            //Alert on last month data
            data.DataTimeRange = Settings.sysAlertTimeRange; ;
            DateTime alertDate;
            DateTime alertFrDate = toDate.Date;
            DateTime alertToDate = toDate;
            for (int stockCodeIdx = 0; stockCodeIdx < stockCodeTbl.Count; stockCodeIdx++)
            {
                if (onProcessItemFunc != null)
                    if (!onProcessItemFunc(stockCodeTbl[stockCodeIdx].code)) break;

                foreach (AppTypes.TimeScale timeScale in AppTypes.myTimeScales) //??
                {
                    data.DataStockCode = stockCodeTbl[stockCodeIdx].code;
                    data.DataTimeScale = timeScale;
                    data.LoadData();
                    for (int strategyIdx = 0; strategyIdx < strategyList.Count; strategyIdx++)
                    {
                        application.Strategy.Data.ClearCache();
                        application.Strategy.Data.TradePoints advices = application.Strategy.Libs.Analysis(data, strategyList[strategyIdx].Trim());
                        if (advices == null) continue;
                        for (int idx3 = 0; idx3 < advices.Count; idx3++)
                        {
                            TradePointInfo tradeInfo = (TradePointInfo)advices[idx3];
                            alertDate = DateTime.FromOADate(data.DateTime[tradeInfo.DataIdx]);
                            //Ignore alerts that out of date range.
                            if (alertDate < alertFrDate || alertDate > alertToDate) continue;
                            Array.Resize(ref tradeAlertList, tradeAlertList.Length + 1);

                            tradeAlertList[tradeAlertList.Length-1] = new TradeAlert(stockCodeTbl[stockCodeIdx].code.Trim(), strategyList[strategyIdx].Trim(),
                                                                                     timeScale, alertDate,
                                                                                     data.Close[tradeInfo.DataIdx],
                                                                                     data.Volume[tradeInfo.DataIdx],tradeInfo);
                        }
                    }
                }
            }
            stockCodeTbl.Dispose();

            //Create alerts in the day
            CreateTradeAlert(tradeAlertList);

            //Save last lun date
            SaveLastRunTime(toDate);
            if (onEndFunc != null) onEndFunc();
        }
        #endregion
    }
}
