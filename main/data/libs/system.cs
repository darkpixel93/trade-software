using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.IO;
using commonClass;

namespace data
{
    public class system
    {
        private static string _dbConnectionString = null;
        public static string dbConnectionString
        {
            get
            {
                //return "Data Source=localhost\\SQL08;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
                return "Data Source=(local);Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";

                if (_dbConnectionString == null) _dbConnectionString = common.configuration.GetDbConnectionString();
                return _dbConnectionString;
            }
            set
            {
                _dbConnectionString = value;
            }
        }
        public static bool CheckAllDbConnection()
        {
            if ( !common.database.CheckDbConnection(dbConnectionString) ) return false;
            return true;
        }
        public static void ClearConnectionString()
        {
            _dbConnectionString = null;
        }

        #region FindAndCache
        private static data.baseDS myCachedDS = new data.baseDS();
        private static data.tmpDS myCachedTmpDS = new data.tmpDS();
        public static void ClearCache()
        {
            myCachedDS.Clear();
            myCachedTmpDS.Clear();
        }

        public static data.baseDS.strategyCatRow FindAndCache_StrategyCat(string catCode)
        {
            data.baseDS.strategyCatRow row = myCachedDS.strategyCat.FindBycode(catCode);
            if (row != null) return row;
            data.baseDSTableAdapters.strategyCatTA dataTA = new data.baseDSTableAdapters.strategyCatTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(myCachedDS.strategyCat);
            row = myCachedDS.strategyCat.FindBycode(catCode);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.indicatorCatRow FindAndCache_IndicatorCat(string catCode)
        {
            data.baseDS.indicatorCatRow row = myCachedDS.indicatorCat.FindBycode(catCode);
            if (row != null) return row;
            data.baseDSTableAdapters.indicatorCatTA dataTA = new data.baseDSTableAdapters.indicatorCatTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(myCachedDS.indicatorCat);
            row = myCachedDS.indicatorCat.FindBycode(catCode);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.stockExchangeRow FindAndCache_StockExchange(string code)
        {
            data.baseDS.stockExchangeRow row = myCachedDS.stockExchange.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.stockExchangeTA dataTA = new data.baseDSTableAdapters.stockExchangeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(myCachedDS.stockExchange);
            row = myCachedDS.stockExchange.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.stockCodeRow FindAndCache_StockCode(string code)
        {
            data.baseDS.stockCodeRow row = myCachedDS.stockCode.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.stockCodeTA dataTA = new data.baseDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(myCachedDS.stockCode, code);
            row = myCachedDS.stockCode.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static data.baseDS.portfolioRow FindAndCache(data.baseDS.portfolioDataTable tbl, string code)
        {
            data.baseDS.portfolioRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.portfolioTA dataTA = new data.baseDSTableAdapters.portfolioTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static data.baseDS.bizSubSectorRow FindAndCache(data.baseDS.bizSubSectorDataTable tbl, string code)
        {
            data.baseDS.bizSubSectorRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.bizSubSectorTA dataTA = new data.baseDSTableAdapters.bizSubSectorTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.bizSubSectorRow FindAndCache_BizSubSector(string code)
        {
            return FindAndCache(myCachedDS.bizSubSector, code);
        }

        public static data.tmpDS.stockCodeRow FindAndCache_StockCodeShort(string code)
        {
            data.tmpDS.stockCodeRow row = myCachedTmpDS.stockCode.FindBycode(code);
            if (row != null) return row;
            data.tmpDSTableAdapters.stockCodeTA dataTA = new data.tmpDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(myCachedTmpDS.stockCode, code);
            row = myCachedTmpDS.stockCode.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.tmpDS.stockCodeRow FindAndCache(data.tmpDS.stockCodeDataTable tbl, string code)
        {
            data.tmpDS.stockCodeRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.tmpDSTableAdapters.stockCodeTA dataTA = new data.tmpDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        #endregion

       
        #region Init data
        public static void InitData(data.baseDS.sysCodeRow row)
        {
            row.category = "";
            row.code = "";
            row.description1 = "";
            row.isSystem = false; row.isVisible = true;
        }
        public static void InitData(data.baseDS.sysCodeCatRow row)
        {
            row.category = "";
            row.description = "";
            row.isSystem = false; 
            row.isVisible = true;
        }

        public static void InitData(data.baseDS.stockCodeRow row)
        {
            row.code = "";
            row.tickerCode = "";
            row.stockExchange = "";
            row.name = "";
            row.address1 = "";
            row.email = "";
            row.website = "";
            row.phone = "";
            row.fax = "";
            row.country = Settings.sysDefaultCountry;
            row.bizSectors = "";

            row.regDate = DateTime.Today;
            row.capitalUnit = Settings.sysMainCurrency;
            row.workingCap = 0;
            row.equity = 0;
            row.totalDebt = 0;
            row.totaAssets = 0;
            row.noOutstandingStock = 0;
            row.noListedStock = 0;
            row.noTreasuryStock = 0;
            row.noForeignOwnedStock = 0;
            row.bookPrice = 0;
            row.targetPrice = 0;
            row.targetPriceVariant = 0;
            row.sales = 0;
            row.profit = 0;
            row.equity = 0;
            row.totalDebt = 0;
            row.totaAssets = 0;
            row.PB = 0;
            row.EPS = 0;
            row.PE = 0;
            row.ROA = 0;
            row.ROE = 0;
            row.BETA = 0;
            row.status = (byte)AppTypes.CommonStatus.Enable;
        }
        public static void InitData(data.baseDS.investorRow row)
        {
            row.code = "";
            row.type = 0;
            row.firstName = "";
            row.lastName = "";
            row.displayName = "";
            row.sex = (byte)AppTypes.Sex.Unspecified;
            row.address1 = "";
            row.email = "";
            row.displayName = "";
            row.account = "";
            row.password = "";
            row.catCode = "";
            row.expireDate = DateTime.Today.AddDays(Settings.sysDefaultLoginAccountDayToExpire);
            row.status = (byte)AppTypes.CommonStatus.Enable;
        }
        public static void InitData(data.baseDS.investorStockRow row)
        {
            row.stockCode = "";
            row.portfolio = "";
            row.buyDate = DateTime.Today;
            row.qty = 0;
            row.buyAmt = 0;
        }
        public static void InitData(data.baseDS.transactionsRow row)
        {
            row.stockCode = "";
            row.portfolio = "";
            row.onTime = DateTime.Today;
            row.tranType = (byte)AppTypes.TradeActions.None;
            row.qty = 0; row.amt = 0; row.feeAmt = 0;
            row.status = (byte)AppTypes.CommonStatus.None;
        }
        public static void InitData(data.baseDS.portfolioRow row)
        {
            row.type = (byte)AppTypes.PortfolioTypes.WatchList;
            row.code = "";
            row.name = "";
            row.description = "";

            row.startCapAmt = 0;
            row.usedCapAmt = 0;

            row.maxBuyAmtPerc = 100;
            row.stockReducePerc = 50;
            row.stockAccumulatePerc = 50;

            row.interestedSector = "";
            row.interestedStock = "";
        }

        public static void InitData(data.baseDS.portfolioDetailRow row)
        {
            row.portfolio = "";
            row.code = "";
            row.subCode = "";
            row.data = "";
        }
        public static void InitData(data.baseDS.stockExchangeRow row)
        {
            row.code = "";
            row.description = "";
            row.country = "";
            row.weight = 0;
        }
        public static void InitData(data.baseDS.priceDataRow row)
        {
            row.stockCode = "";
            row.onDate = DateTime.Today;
            row.openPrice = 0;
            row.highPrice = 0;
            row.lowPrice = 0;
            row.closePrice = 0;
            row.volume = 0;
            row.isUpdate = false;
        }
        public static void InitData(data.baseDS.priceDataSumRow row)
        {
            row.type = "";
            row.stockCode = "";
            row.onDate = DateTime.Today;
            row.openPrice = 0;
            row.closePrice = 0;
            row.volume = 0;
            row.highPrice = decimal.MinValue;
            row.lowPrice = decimal.MaxValue;
            row.openTimeOffset = short.MaxValue;
            row.closeTimeOffset = short.MinValue;
            row.isUpdate = false;
        }
        public static void InitData(data.baseDS.updateVolumeRow row)
        {
            row.stockCode = "";
            row.onDate = DateTime.Today;
            row.volume = 0;
        }

        public static void InitData(data.baseDS.tradeAlertRow row)
        {
            row.type = "";
            row.portfolio = "";
            row.stockCode = "";
            row.strategy = "";
            row.timeScale = "";
            row.onTime = DateTime.Today;
            row.status = 0;
            row.tradeAction = (byte)AppTypes.TradeActions.None;
            row.subject = common.settings.sysNewDataText;
            row.msg = "";
        }

        public static void InitData(data.tmpDS.stockCodeRow row)
        {
            row.qty = 0; row.boughtAmt = 0;
            row.boughtPrice = 0;
            row.price = 0;
            row.priceVariant = 0;
            row.volume = 0;
            row.amt = 0;
            row.profitVariantAmt = 0;
            row.profitVariantPerc = 0;
        }

        #endregion

        
        /// <summary>
        /// Copy data from one portfolioDetail data table to another
        /// </summary>
        /// <param name="frDataTbl">Source data</param>
        /// <param name="toDataTbl">Destination data</param>
        /// <param name="porfolioCode">Porfolio code of the data added to destination</param>
        /// <param name="stockCode">Stock code of the data added to destination</param>
        public static void CopyPortfolioData(data.baseDS.portfolioDetailDataTable frDataTbl,
                                             data.baseDS.portfolioDetailDataTable toDataTbl,
                                             string porfolioCode, string stockCode)
        {
            data.baseDS.portfolioDetailRow row;
            for (int idx = 0; idx < frDataTbl.Rows.Count; idx++)
            {
                row = toDataTbl.NewportfolioDetailRow();
                InitData(row);
                row.portfolio = porfolioCode;
                row.code = stockCode;
                row.subCode = frDataTbl[idx].subCode; ;
                row.data = frDataTbl[idx].data;
                toDataTbl.AddportfolioDetailRow(row);
            }
        }


        public static common.myAutoKeyInfo GetAutoKey(string key, bool usePending)
        {
            DateTime curTimeStamp = common.Consts.constNullDate;
            data.baseDS.sysAutoKeyPendingDataTable sysAutoKeyPendingTbl = new data.baseDS.sysAutoKeyPendingDataTable();
            //First try to re-used unused keys if required
            if (usePending)
            {
                curTimeStamp = DateTime.Now;
                DateTime minTimeStamp = curTimeStamp.AddSeconds(-Settings.sysTimeOut_AutoKey);
                sysAutoKeyPendingTbl.Clear();
                DbAccess.LoadData(sysAutoKeyPendingTbl, key);
                if (sysAutoKeyPendingTbl.Count > 0)
                {
                    for (int idx = 0; idx < sysAutoKeyPendingTbl.Count; idx++)
                    {
                        //Still valid : ignore it
                        if (sysAutoKeyPendingTbl[idx].timeStamp > minTimeStamp) continue;

                        //The the first invalid key will be used. Updating the timestamp to make it valid again.
                        sysAutoKeyPendingTbl[idx].timeStamp = curTimeStamp;
                        DbAccess.UpdateData(sysAutoKeyPendingTbl[idx]);
                        return new common.myAutoKeyInfo(key, sysAutoKeyPendingTbl[idx].value, sysAutoKeyPendingTbl[idx].value.Trim());
                    }
                }
            }
            //Then, create a new key and pending key if required
            data.baseDS.sysAutoKeyRow sysAutoKeyRow = DbAccess.NewAutoKeyValue(key);
            if (usePending) DbAccess.CreateAutoPendingKey(sysAutoKeyRow.key, sysAutoKeyRow.value.ToString(), curTimeStamp);
            string valueStr = sysAutoKeyRow.value.ToString().Trim();
            return new common.myAutoKeyInfo(key, valueStr, valueStr);
        }
        public static void DeleteKeyPending(common.myAutoKeyInfo autoKeyInfo)
        {
            //Remove the used key in pending list
            DbAccess.DeleteAutoKeyPending(autoKeyInfo.key, autoKeyInfo.value);
        }

        public static string GetAutoDataKey(string tblName)
        {
            return GetAutoDataKey(tblName, Settings.sysDataKeyPrefix, Settings.sysDataKeySize, false);
        }
        public static string GetAutoDataKey(string tblName, string prefix, int maxLen, bool usePending)
        {
            common.myAutoKeyInfo keyInfo = GetAutoKey(tblName, usePending);
            if (keyInfo == null) return null;
            return prefix + keyInfo.value.PadLeft(maxLen - prefix.Length, '0');
        }

        /// <summary>
        /// Get the QTY that available to sell. 
        /// Stock applicable to sell is the ones that had bought [buySellInterval] days before (or later) the [sellDate] data
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="portfolio"></param>
        /// <param name="buySellInterval"></param>
        /// <param name="sellDate"></param>
        /// <returns></returns>
        public static decimal GetAvailableStock(string stockCode, string portfolio, int buySellInterval, DateTime sellDate)
        {
            decimal qty = 0;
            decimal buyAmt = 0;
            GetOwnStock(stockCode, portfolio, buySellInterval, sellDate, out qty, out buyAmt);
            return qty;
        }
        public static bool GetOwnStock(string stockCode, string portfolio, int buySellInterval, DateTime sellDate,
                                              out decimal qty, out decimal buyAmt)
        {
            qty = 0; buyAmt = 0;
            data.baseDS.investorStockDataTable dataTbl = new data.baseDS.investorStockDataTable();
            DbAccess.LoadData(dataTbl, stockCode, portfolio);
            if (dataTbl.Count == 0) return false;
            DateTime applicableDate = sellDate.AddDays(-Settings.sysStockSell2BuyInterval);
            for (int idx = 0; idx < dataTbl.Count; idx++)
            {
                if (dataTbl[idx].buyDate > applicableDate) continue;
                qty += dataTbl[idx].qty;
                buyAmt += dataTbl[idx].buyAmt;
            }
            return true;
        }
    }
}
