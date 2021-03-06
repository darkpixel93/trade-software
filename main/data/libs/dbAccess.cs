using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using commonClass;

namespace data
{
    public class DbAccess
    {
        public static void ClearDbConnection() { }

        #region system
        private static data.baseDSTableAdapters.sysLogTA syslogTA = new data.baseDSTableAdapters.sysLogTA();
        private static data.baseDSTableAdapters.sysConfigTA sysConfigTA = new data.baseDSTableAdapters.sysConfigTA();
        private static data.baseDSTableAdapters.sysCodeCatTA sysCodeCatTA = new data.baseDSTableAdapters.sysCodeCatTA();
        private static data.baseDSTableAdapters.sysCodeTA sysCodeTA = new data.baseDSTableAdapters.sysCodeTA();
        private static data.baseDSTableAdapters.sysAutoKeyTA sysAutoKeyTA = new data.baseDSTableAdapters.sysAutoKeyTA();
        private static data.baseDSTableAdapters.sysAutoKeyPendingTA sysAutoKeyPendingTA = new data.baseDSTableAdapters.sysAutoKeyPendingTA();

        public static bool CheckSystemLog(string logType, string msg)
        {
            return false; 
            //data.baseDS.sysLogDataTable syslogTbl = syslogTA.GetDataByTypeMsg(logType, "'" + msg + common.Consts.SQL_CMD_ALL_MARKER + "'");
            //return (syslogTbl.Count > 0);
        }
        public static bool WriteSystemLog(string logType, string msg, double amt)
        {
            return false; //??
            //data.baseDS.sysLogDataTable syslogTbl = new data.baseDS.sysLogDataTable();
            //data.baseDS.sysLogRow syslogRow;
            //syslogRow = syslogTbl.NewsysLogRow();
            //syslogRow.workerId = sysLibs.sysLoginUserId;
            //syslogRow.locationId = sysLibs.sysLoginLocationId;
            //syslogRow.type = logType;
            //syslogRow.onDate = DateTime.Now;
            //syslogRow.message = msg;
            //syslogRow.amount = amt;
            //syslogTA.Update(syslogRow);
            //return true;
        }

        /// <summary>
        /// Return NULL if the [key] not found
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            data.baseDS.sysConfigDataTable tbl = sysConfigTA.GetByKey(key);
            if (tbl.Count <= 0) return "";
            return tbl[0].value;
        }
        public static void SaveConfig(string key, string value)
        {
            data.baseDS.sysConfigDataTable sysConfigTbl = sysConfigTA.GetByKey(key);
            data.baseDS.sysConfigRow row;
            if (sysConfigTbl.Count == 0)
            {
                row = sysConfigTbl.NewsysConfigRow();
                row.key = key; row.value = value;
                sysConfigTbl.AddsysConfigRow(row);
            }
            else
            {
                row = sysConfigTbl[0];
                row.value = value;
            }
            sysConfigTA.Update(row);
            row.AcceptChanges();
        }

        public static data.baseDS.sysAutoKeyPendingRow UpdateAutoKeyPending(string key, string value, DateTime timestamp)
        {
            data.baseDS.sysAutoKeyPendingDataTable tbl = sysAutoKeyPendingTA.GetByKeyValue(key, value);
            data.baseDS.sysAutoKeyPendingRow row;
            if (tbl.Count > 0)
            {
                row = tbl[0]; row.timeStamp = timestamp;
            }
            else
            {
                row = tbl.NewsysAutoKeyPendingRow();
                row.key = key; row.value = value; row.timeStamp = timestamp;
                tbl.AddsysAutoKeyPendingRow(row);
            }
            sysAutoKeyPendingTA.Update(row);
            row.AcceptChanges();
            return row;
        }
        public static data.baseDS.sysAutoKeyRow NewAutoKeyValue(string key)
        {
            data.baseDS.sysAutoKeyDataTable sysAutoKeyTbl = sysAutoKeyTA.GetByKey(key);
            data.baseDS.sysAutoKeyRow sysAutoKeyRow;
            if (sysAutoKeyTbl.Count == 0)
            {
                sysAutoKeyRow = sysAutoKeyTbl.NewsysAutoKeyRow();
                sysAutoKeyRow.key = key; sysAutoKeyRow.value = 0;
                sysAutoKeyTbl.AddsysAutoKeyRow(sysAutoKeyRow);
            }
            else sysAutoKeyRow = sysAutoKeyTbl[0];
            sysAutoKeyRow.value = sysAutoKeyRow.value + 1;
            sysAutoKeyTA.Update(sysAutoKeyRow);
            sysAutoKeyRow.AcceptChanges();
            return sysAutoKeyRow;
        }
        #endregion system

        #region import
        private static data.importDSTableAdapters.importPriceTA importPriceTA = new data.importDSTableAdapters.importPriceTA();
        public static void InitData(data.importDS.importPriceRow row)
        {
            row.onDate = common.Consts.constNullDate;
            row.stockExchange = "";
            row.stockCode = "";
            row.closePrice = 0;
            row.volume = 0;
            row.openPrice = 0;
            row.highPrice = 0;
            row.closePrice = 0;
        }
        public static void UpdateData(data.importDS.importPriceDataTable tbl)
        {
            importPriceTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.importDS.importPriceRow row)
        {
            importPriceTA.Update(row);
            row.AcceptChanges();
        }

        #endregion

        #region access objects
        private static data.baseDSTableAdapters.bizIndustryTA bizIndustryTA = new data.baseDSTableAdapters.bizIndustryTA();
        private static data.baseDSTableAdapters.bizSuperSectorTA bizSuperSectorTA = new data.baseDSTableAdapters.bizSuperSectorTA();
        private static data.baseDSTableAdapters.bizSectorTA bizSectorTA = new data.baseDSTableAdapters.bizSectorTA();
        private static data.baseDSTableAdapters.bizSubSectorTA bizSubSectorTA = new data.baseDSTableAdapters.bizSubSectorTA();

        private static data.baseDSTableAdapters.countryTA countryTA = new data.baseDSTableAdapters.countryTA();
        private static data.baseDSTableAdapters.currencyTA currencyTA = new data.baseDSTableAdapters.currencyTA();
        private static data.baseDSTableAdapters.strategyCatTA strategyCatTA = new data.baseDSTableAdapters.strategyCatTA();
        private static data.baseDSTableAdapters.indicatorCatTA indicatorCatTA = new data.baseDSTableAdapters.indicatorCatTA();
        private static data.baseDSTableAdapters.investorCatTA investorCatTA = new data.baseDSTableAdapters.investorCatTA();
        private static data.baseDSTableAdapters.employeeRangeTA employeeRangeTA = new data.baseDSTableAdapters.employeeRangeTA();
        private static data.baseDSTableAdapters.stockExchangeTA stockExchangeTA = new data.baseDSTableAdapters.stockExchangeTA();

        private static data.tmpDSTableAdapters.stockCodeTA shortStockCodeTA = new data.tmpDSTableAdapters.stockCodeTA();

        private static data.baseDSTableAdapters.stockCodeTA stockCodeTA = new data.baseDSTableAdapters.stockCodeTA();
        private static data.baseDSTableAdapters.investorTA investorTA = new data.baseDSTableAdapters.investorTA();
        private static data.baseDSTableAdapters.investorStockTA investorStockTA = new data.baseDSTableAdapters.investorStockTA();
        private static data.baseDSTableAdapters.transactionsTA transactionsTA = new data.baseDSTableAdapters.transactionsTA();

        private static data.baseDSTableAdapters.portfolioTA portfolioTA = new data.baseDSTableAdapters.portfolioTA();
        private static data.baseDSTableAdapters.portfolioDetailTA portfolioDetailTA = new data.baseDSTableAdapters.portfolioDetailTA();

        private static data.baseDSTableAdapters.priceDataTA priceDataTA = new data.baseDSTableAdapters.priceDataTA();

        private static data.baseDSTableAdapters.priceDataSumTA priceDataSumTA = new data.baseDSTableAdapters.priceDataSumTA();
        private static data.baseDSTableAdapters.updateVolumeTA updateVolumeTA = new data.baseDSTableAdapters.updateVolumeTA();

        private static data.baseDSTableAdapters.tradeAlertTA tradeAlertTA = new data.baseDSTableAdapters.tradeAlertTA();
        #endregion access object
        
        #region get/load method 
        public static void LoadFromSQL(DataTable tbl, string sqlCmd)
        {
            SqlDataAdapter dataTA = new SqlDataAdapter(sqlCmd, data.system.dbConnectionString);
            dataTA.Fill(tbl);
        }

        public static void LoadData(data.baseDS.sysAutoKeyDataTable tbl)
        {
            sysAutoKeyTA.ClearBeforeFill = false;
            sysAutoKeyTA.Fill(tbl);
        }

        public static void LoadData(data.baseDS.stockExchangeDataTable tbl)
        {
            stockExchangeTA.ClearBeforeFill = false;
            stockExchangeTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.employeeRangeDataTable tbl)
        {
            employeeRangeTA.ClearBeforeFill = false;
            employeeRangeTA.Fill(tbl);
        }

        public static void LoadData(data.baseDS.bizIndustryDataTable tbl)
        {
            bizIndustryTA.ClearBeforeFill = false;
            bizIndustryTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.bizSuperSectorDataTable tbl)
        {
            bizSuperSectorTA.ClearBeforeFill = false;
            bizSuperSectorTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.bizSectorDataTable tbl)
        {
            bizSectorTA.ClearBeforeFill = false;
            bizSectorTA.Fill(tbl);
        }
        
        public static void LoadData(data.baseDS.bizSubSectorDataTable tbl)
        {
            bizSubSectorTA.ClearBeforeFill = false;
            bizSubSectorTA.Fill(tbl);
        }
        public static void LoadDataByIndustryCode(data.baseDS.bizSubSectorDataTable tbl, string industryCode)
        {
            bizSubSectorTA.ClearBeforeFill = false;
            bizSubSectorTA.FillByIndustryCode(tbl, industryCode);
        }
        public static void LoadDataBySuperSectorCode(data.baseDS.bizSubSectorDataTable tbl, string superSectorCode)
        {
            bizSubSectorTA.ClearBeforeFill = false;
            bizSubSectorTA.FillBySuperSector(tbl, superSectorCode);
        }
        public static void LoadDataBySectorCode(data.baseDS.bizSubSectorDataTable tbl, string sectorCode)
        {
            bizSubSectorTA.ClearBeforeFill = false;
            bizSubSectorTA.FillBySectorCode(tbl, sectorCode);
        }

        public static void LoadData(data.baseDS.strategyCatDataTable tbl)
        {
            strategyCatTA.ClearBeforeFill = false;
            strategyCatTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.indicatorCatDataTable tbl)
        {
            indicatorCatTA.ClearBeforeFill = false;
            indicatorCatTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.countryDataTable tbl)
        {
            countryTA.ClearBeforeFill = false;
            countryTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.currencyDataTable tbl)
        {
            currencyTA.ClearBeforeFill = false;
            currencyTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.investorCatDataTable tbl)
        {
            investorCatTA.ClearBeforeFill = false;
            investorCatTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.sysAutoKeyPendingDataTable tbl,string key)
        {
            sysAutoKeyPendingTA.ClearBeforeFill = false;
            sysAutoKeyPendingTA.FillByKey(tbl, key);
        }

        public static void LoadData(data.baseDS.sysCodeDataTable tbl,string catCode)
        {
            sysCodeTA.ClearBeforeFill = false;
            sysCodeTA.FillByCat(tbl,catCode);
        }
        public static void LoadData(data.baseDS.sysCodeCatDataTable tbl)
        {
            sysCodeCatTA.ClearBeforeFill = false;
            sysCodeCatTA.Fill(tbl);
        }

        public static void LoadData(data.baseDS.stockCodeDataTable tbl, string code)
        {
            stockCodeTA.ClearBeforeFill = false;
            if (code == null) stockCodeTA.Fill(tbl);
            else stockCodeTA.FillByCode(tbl, code);
        }
        public static void LoadData(data.baseDS.stockCodeDataTable tbl)
        {
            stockCodeTA.ClearBeforeFill = false;
            stockCodeTA.Fill(tbl);
        }

        public static void LoadData(data.tmpDS.stockCodeDataTable tbl, string code)
        {
            shortStockCodeTA.ClearBeforeFill = false;
            shortStockCodeTA.FillByCode(tbl, code);
        }
        public static void LoadData(data.tmpDS.stockCodeDataTable tbl, AppTypes.CommonStatus status)
        {
            shortStockCodeTA.ClearBeforeFill = false;
            shortStockCodeTA.FillByStatusMask(tbl, ((byte)status).ToString());
        }
        public static void LoadData(data.tmpDS.stockCodeDataTable stockCodeTbl, data.baseDS.portfolioRow row)
        {
            StringCollection list;
            list = common.MultiValueString.String2List(row.interestedSector);
            if (list.Count > 0) LoadStockCode_ByBizSectors(stockCodeTbl, list);

            list = common.MultiValueString.String2List(row.interestedStock);
            if (list.Count > 0)
            {
                data.tmpDS.stockCodeDataTable tmpTbl = new data.tmpDS.stockCodeDataTable();
                LoadStockCode_ByCodeList(tmpTbl, list);
                for (int idx = 0; idx < tmpTbl.Count; idx++)
                {
                    system.FindAndCache(stockCodeTbl, tmpTbl[idx].code);
                }
            }
        }

        public static void LoadData(data.baseDS.investorDataTable tbl, string code)
        {
            investorTA.ClearBeforeFill = false;
            if (code == null) investorTA.Fill(tbl);
            else investorTA.FillByCode(tbl, code);
        }

        public static void LoadData(data.baseDS.investorStockDataTable tbl, string portfolioCode)
        {
            investorStockTA.ClearBeforeFill = false;
            investorStockTA.FillByPortfolio(tbl, portfolioCode);
        }
        public static void LoadData(data.baseDS.investorStockDataTable tbl, string stockCode, string portfolio)
        {
            investorStockTA.ClearBeforeFill = false;
            investorStockTA.FillByPortfolioStock(tbl, portfolio, stockCode);
        }
        public static void LoadData(data.baseDS.investorStockDataTable tbl, string stockCode, string portfolio,DateTime buyDate)
        {
            investorStockTA.ClearBeforeFill = false;
            investorStockTA.FillByPortfolioStockBuyDate(tbl, portfolio, stockCode,buyDate);
        }

        public static void LoadData(data.baseDS.transactionsDataTable tbl,string portfolio,string stockCode)
        {
            transactionsTA.ClearBeforeFill = false;
            transactionsTA.FillByPortfolioStockCode(tbl, portfolio,stockCode);
        }

        public static void LoadData(data.baseDS.portfolioDataTable tbl, AppTypes.PortfolioTypes type)
        {
            portfolioTA.ClearBeforeFill = false;
            portfolioTA.FillByTypeMask(tbl, ((byte)type).ToString());
        }
        public static void LoadData(data.baseDS.portfolioDataTable tbl, string code)
        {
            portfolioTA.ClearBeforeFill = false;
            portfolioTA.FillByCode(tbl, code);
        }

        public static void LoadData(data.baseDS.portfolioDetailDataTable tbl, string portfolioCode)
        {
            portfolioDetailTA.ClearBeforeFill = false;
            portfolioDetailTA.FillByPortfolio(tbl, portfolioCode);
        }
        public static void LoadData(data.baseDS.portfolioDetailDataTable tbl, byte typeMask)
        {
            portfolioDetailTA.ClearBeforeFill = false;
            portfolioDetailTA.FillByTypeMask(tbl, ((byte)typeMask).ToString());
        }


        public static void LoadData(data.baseDS.priceDataDataTable tbl, string stockCode)
        {
            priceDataTA.ClearBeforeFill = false;
            priceDataTA.FillByCode(tbl, stockCode); 
        }
        public static void LoadData(data.baseDS.priceDataDataTable tbl,string timeScale,DateTime frDate,DateTime toDate,string stockCode)
        {
            priceDataTA.ClearBeforeFill = false;
            if (timeScale == AppTypes.MainDataTimeScale.Code)
            {
                if (frDate == DateTime.MinValue && toDate == DateTime.MaxValue)
                     priceDataTA.FillByCode(tbl, stockCode);
                else priceDataTA.FillByDateCode(tbl, frDate, toDate, stockCode);
            }            else
            {
                if (frDate == DateTime.MinValue && toDate == DateTime.MaxValue)
                     priceDataTA.FillByTypeCode(tbl, timeScale, stockCode);
                else priceDataTA.FillByTypeDateCode(tbl, timeScale, frDate, toDate, stockCode);
            }
        }
        public static void LoadData(data.baseDS.priceDataDataTable tbl, string timeScale, DateTime frDate,string stockCode)
        {
            priceDataTA.ClearBeforeFill = false;
            if (timeScale == AppTypes.MainDataTimeScale.Code)
            {
                priceDataTA.FillByCodeFromDate(tbl, stockCode, frDate);
            }
            else
            {
                priceDataTA.FillByTypeCodeFromDate(tbl, timeScale,stockCode,frDate);
            }
        }

        public static int GetTotalPriceRow(AppTypes.TimeScale timeScale, DateTime frDate, DateTime toDate, string stockCode)
        {
            switch (timeScale.Type)
            {
                case AppTypes.TimeScaleTypes.RealTime:
                    return (int)priceDataTA.GetTotalRow(frDate, toDate, stockCode);
                default:
                    return (int)priceDataTA.GetTotalSumRow(timeScale.Code, frDate, toDate, stockCode);
            }
        }

        public static void LoadDataOneRow(data.baseDS.priceDataDataTable tbl,DateTime frDate, DateTime toDate, string stockCode)
        {
            priceDataTA.ClearBeforeFill = false;
            priceDataTA.FillOneByDateStockCode(tbl, frDate, toDate, stockCode);
        }
        
        public static void LoadData(data.baseDS.tradeAlertDataTable tbl, string portfolio, DateTime frDate, DateTime toDate,byte statusMask)
        {
            tradeAlertTA.ClearBeforeFill = false;
            tradeAlertTA.Fill(tbl,portfolio,frDate,toDate,statusMask.ToString());
        }
        public static data.baseDS.tradeAlertRow GetLastAlert(DateTime frDate, DateTime toDate,string portfolio,
                                                             string stockCode,string strategy,string timeScale,byte statusMask)
        {
            data.baseDS.tradeAlertDataTable tbl = tradeAlertTA.GetOne(frDate, toDate, portfolio, stockCode,strategy,timeScale,statusMask.ToString());
            if (tbl == null || tbl.Count == 0) return null;
            return tbl[0];
        }

        public static data.baseDS.tradeAlertDataTable GetLastTradeAlert(DateTime frDate, DateTime toDate, 
                                                                        string stockCode, string investor, string timeScale, byte statusMask)
        {
            return tradeAlertTA.GetOneByInvestor(frDate, toDate,stockCode,timeScale,statusMask.ToString(),investor);
        }

        public static void LoadPortfolioByInvestor(data.baseDS.portfolioDataTable tbl, string investorCode,AppTypes.PortfolioTypes type)
        {
            portfolioTA.ClearBeforeFill = false;
            portfolioTA.FillByInvestorCodeAndTypeMask(tbl, investorCode,((byte)type).ToString());
        }
        public static void LoadPortfolioByInvestor(data.baseDS.portfolioDataTable tbl, string investorCode)
        {
            portfolioTA.ClearBeforeFill = false;
            portfolioTA.FillByInvestorCode(tbl, investorCode);
        }

        public static void LoadStockByInvestor(data.baseDS.investorStockDataTable tbl, string investorCode)
        {
            investorStockTA.ClearBeforeFill = false;
            investorStockTA.FillByInvestor(tbl, investorCode);
        }

        public static void LoadInvestorByAccount(data.baseDS.investorDataTable tbl, string account)
        {
            investorTA.ClearBeforeFill = false;
            investorTA.FillByAccount(tbl, account);
        }
        public static void LoadInvestor(data.baseDS.investorDataTable tbl, string cond)
        {
            string sqlCmd = "SELECT * FROM investor WHERE " + cond;
            LoadFromSQL(tbl, sqlCmd);
        }

        public static void LoadStockCode_ByStatus(data.baseDS.stockCodeDataTable tbl,AppTypes.CommonStatus status)
        {
            stockCodeTA.FillByStatusMask(tbl, ((byte)status).ToString());
        }

        public static void LoadStockCode_ByStockExchange(data.tmpDS.stockCodeDataTable tbl, string stockExchange, AppTypes.CommonStatus status)
        {
            shortStockCodeTA.FillByStockExchange(tbl, stockExchange,((byte)status).ToString()); 
        }
        public static void LoadStockCode_ByBizSectors(data.tmpDS.stockCodeDataTable tbl, StringCollection bizSectors)
        {
            data.baseDS.stockCodeDataTable comTbl = new data.baseDS.stockCodeDataTable();
            string cond = common.system.MakeConditionStr(bizSectors,
                                                         comTbl.bizSectorsColumn.ColumnName + " LIKE N'" +
                                                         common.Consts.SQL_CMD_ALL_MARKER + common.settings.sysListSeparatorPrefix,
                                                         common.settings.sysListSeparatorPostfix + common.Consts.SQL_CMD_ALL_MARKER + "'",
                                                         "OR");
            string sqlCmd = "SELECT code, stockExchange, tickerCode, name,nameEn,0 AS price,0 AS priceVariant FROM stockCode WHERE " + cond;
            LoadFromSQL(tbl, sqlCmd);
        }

        public static void LoadStockCode_ByCodeList(data.tmpDS.stockCodeDataTable tbl, StringCollection stockCode)
        {
            string cond = common.system.MakeConditionStr(stockCode,""+tbl.codeColumn.ColumnName + "=N'","'", "OR");
            string sqlCmd = "SELECT * FROM stockCode WHERE " + cond;
            LoadFromSQL(tbl, sqlCmd);
        }
        public static void LoadStockCode_ByPortfolios(data.tmpDS.stockCodeDataTable tbl, StringCollection portfolios)
        {
            data.baseDS.investorStockDataTable tmpTbl = new data.baseDS.investorStockDataTable();
            string cond = common.system.MakeConditionStr(portfolios, "b." + tmpTbl.portfolioColumn.ColumnName + "=N'", "'", "OR");
            if (cond.Trim() == "") return;

            tmpTbl.Dispose();

            string sqlCmd = "SELECT DISTINCT a.*" +
                            " FROM stockCode a" +
                            " INNER JOIN investorStock b ON a.code = b.stockCode"+
                            " WHERE " + cond;
            LoadFromSQL(tbl, sqlCmd);
        }

        public static void LoadStockCode_ByWatchList(data.tmpDS.stockCodeDataTable stockCodeTbl, StringCollection codes)
        {
            StringCollection retList = new StringCollection();
            StringCollection list;

            data.tmpDS.stockCodeDataTable tmpTbl = new data.tmpDS.stockCodeDataTable();
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            data.baseDS.portfolioRow portfolioRow;
            for (int idx1 = 0; idx1 < codes.Count; idx1++)
            {
                portfolioRow = system.FindAndCache(portfolioTbl, codes[idx1]);
                if (portfolioRow == null) continue;
                list = common.MultiValueString.String2List(portfolioRow.interestedStock);
                if (list.Count <= 0) continue;
                tmpTbl.Clear();
                LoadStockCode_ByCodeList(tmpTbl, list);
                for (int idx2 = 0; idx2 < tmpTbl.Count; idx2++)
                {
                    if (stockCodeTbl.FindBycode(tmpTbl[idx2].code)==null) stockCodeTbl.ImportRow(tmpTbl[idx2]);
                }
            }
            portfolioTbl.Dispose();
        }

        public static data.baseDS.portfolioRow GetPortfolio(string portfolioCode)
        {
            data.baseDS.portfolioDataTable tbl = portfolioTA.GetByCode(portfolioCode);
            if (tbl.Count == 0) return null;
            return tbl[0];
        }
        public static DateTime GetLastAlertTime(string investorCode)
        {
            object obj = tradeAlertTA.GetLastTimeByInvestor(investorCode);
            if (obj == null) return common.Consts.constNullDate;
            return (DateTime)obj;
        }
        #endregion

        #region Others
        public static data.baseDS.sysAutoKeyPendingRow CreateAutoPendingKey(string key, string value, DateTime timeStamp)
        {
            data.baseDS.sysAutoKeyPendingDataTable tbl = sysAutoKeyPendingTA.GetByKeyValue(key, value);
            data.baseDS.sysAutoKeyPendingRow row;
            if (tbl.Count == 0)
            {
                row = tbl.NewsysAutoKeyPendingRow();
                row.key = key; row.value = value;
                row.timeStamp = timeStamp;
                tbl.AddsysAutoKeyPendingRow(row);
            }
            else
            {
                row = tbl[0];
                row.timeStamp = timeStamp;
            }
            sysAutoKeyPendingTA.Update(row);
            return row;
        }

        public static System.DateTime GetLastPriceDate(string timeScale)
        {
            if (timeScale == AppTypes.MainDataTimeScale.Code)
                return (System.DateTime)priceDataTA.GetMaxDate();

            return (System.DateTime)priceDataSumTA.GetMaxDate(timeScale);
        }
        public static data.baseDS.priceDataDataTable GetPrice(DateTime onDate, string timeScale)
        {
            if (timeScale == AppTypes.MainDataTimeScale.Code)
                return priceDataTA.GetByDate(onDate);
            return priceDataTA.GetByTypeDate(timeScale, onDate);
        }

        #endregion

        //Update
        #region Update
        public static void UpdateData(data.baseDS.priceDataSumDataTable tbl)
        {
            priceDataSumTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.priceDataSumRow row)
        {
            priceDataSumTA.Update(row);
            row.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.priceDataDataTable tbl)
        {
            priceDataTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.priceDataRow row)
        {
            priceDataTA.Update(row);
            row.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.updateVolumeDataTable tbl)
        {
            updateVolumeTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.updateVolumeRow row)
        {
            updateVolumeTA.Update(row);
            row.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.stockExchangeDataTable tbl)
        {
            stockExchangeTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.stockCodeDataTable tbl)
        {
            stockCodeTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.investorDataTable tbl)
        {
            investorTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.transactionsDataTable tbl)
        {
            transactionsTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.investorStockDataTable tbl)
        {
            investorStockTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.portfolioDataTable tbl)
        {
            portfolioTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.portfolioDetailDataTable tbl)
        {
            portfolioDetailTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.tradeAlertDataTable tbl)
        {
            tradeAlertTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.sysCodeCatDataTable tbl)
        {
            sysCodeCatTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.sysCodeDataTable tbl)
        {
            sysCodeTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.sysAutoKeyPendingDataTable data)
        {
            sysAutoKeyPendingTA.Update(data);
            data.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.sysAutoKeyPendingRow data)
        {
            sysAutoKeyPendingTA.Update(data);
            data.AcceptChanges();
        }
        #endregion Update

        #region Set data
        //private static void SetTradeAlertStatus(data.baseDS.tradeAlertRow row, AppTypes.CommonStatus stat)
        //{
        //    row.status = (byte)stat;
        //}
        //public static void CancelTradeAlert(data.baseDS.tradeAlertRow row)
        //{
        //    SetTradeAlertStatus(row, AppTypes.CommonStatus.Ignore);
        //}
        //public static void RenewTradeAlert(data.baseDS.tradeAlertRow row)
        //{
        //    SetTradeAlertStatus(row, AppTypes.CommonStatus.New);
        //}
        //public static void CloseTradeAlert(data.baseDS.tradeAlertRow row)
        //{
        //    SetTradeAlertStatus(row, AppTypes.CommonStatus.Close);
        //}

        #endregion
        #region delete
        public static void DeleteSysCode(string category, string code)
        {
            sysCodeTA.Delete(category, code);
        }
        public static void DeleteSysCodeCat(string category)
        {
            sysCodeCatTA.Delete(category);
        }

        public static void DeleteStock(string stockCode)
        {
            stockCodeTA.Delete(stockCode);
        }
        public static void DeleteInvestor(string code)
        {
            investorTA.Delete(code);
        }
        public static void DeletePortfolio(string code)
        {
            portfolioTA.Delete(code);
        }
        public static void DeletePriceSumData()
        {
            priceDataSumTA.DeleteAll();
        }
        public static void DeletePriceSumData(string stockCode)
        {
            priceDataSumTA.DeleteByStockCode(stockCode);
        }
        public static void DeleteLastUpdateVolume(DateTime endDate)
        {
            updateVolumeTA.DeleteToEndDate(endDate);
        }
        public static void DeletePortfolioData(string porfolioCode, string stockCode)
        {
            portfolioDetailTA.DeleteByPortfolioAndCode(porfolioCode, stockCode);
        }

       


        public static void DeleteTradeAlert(int id)
        {
            tradeAlertTA.Delete(id);
        }
        //Remove the used key in pending list
        public static void DeleteAutoKeyPending(string key,string value)
        {
            sysAutoKeyPendingTA.DeleteByKeyValue(key, value);
        }

        #endregion
    }
}
