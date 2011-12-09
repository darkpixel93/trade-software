using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using LumenWorks.Framework.IO.Csv;


namespace application
{
    public class imports
    {
        #region import

        // string(0001 Oil & Gas) ->  (0001,Oil & Gas)
        public static common.myKeyValueItem GetKeyValue(string str)
        {
            int pos = str.IndexOf(' ');
            if (pos <= 0) return null;
            return new common.myKeyValueItem(str.Substring(0, pos).Trim(), str.Substring(pos + 1).Trim());
        }

        //Return common.Consts.constNullDate if not found
        private static DateTime FindLastUpdatePricedata(string stockCode)
        {
            int noToTry = 100;
            data.baseDS.priceDataDataTable priceDataTbl = new data.baseDS.priceDataDataTable();
            DateTime eDate = application.sysLibs.GetServerDateTime();
            DateTime sDate = eDate.AddDays(-1);
            while (noToTry > 0)
            {
                priceDataTbl.Clear();
                application.dataLibs.LoadData(priceDataTbl, sDate, eDate, stockCode, true);
                if (priceDataTbl.Count > 0)
                {
                    eDate = priceDataTbl[0].onDate;
                    return eDate;
                }
                eDate = eDate.AddDays(-1);
                sDate = eDate.AddDays(-1);
                noToTry--;
            }
            return common.Consts.constNullDate;
        }

        public delegate void onAggregateData(agrregateStat stat);
        public delegate void onGotData(importStat stat);
        public delegate void onUpdateData(data.baseDS.priceDataRow row);
        public delegate void onEndImport(data.baseDS ds);
        public enum processAction : byte { None=0, Ignore = 1, Added = 2,Error=3};
        public class importStat
        {
            public bool cancel = false;
            public processAction actions = processAction.None;
            public DateTime minUpdateDate = DateTime.MaxValue;
            public DateTime maxUpdateDate = DateTime.MinValue;
            public int dataCount = 0, updateCount = 0, errorCount = 0;
            public void Reset()
            {
                cancel = false;
                actions = processAction.None;

                dataCount = 0; 
                updateCount = 0;
                errorCount = 0;
                minUpdateDate = DateTime.MaxValue;
                maxUpdateDate = DateTime.MinValue;
            }
        }
        public class agrregateStat
        {
            public bool cancel = false;
            public int count = 0,maxCount=0;
            public void Reset()
            {
                cancel = false;
                count = 0;
                maxCount = 0;
            }
        }

        //Based on work from http://www.codeproject.com/KB/database/CsvReader.aspx by Sebastien Lorion 
        public static bool ImportPricedata_CSV(string csvFileName, string stockExCode, string cultureCode,
                                               data.baseDS destDS, 
                                               onGotData onGotDataFunc, onUpdateData onUpdateDataFunc, onEndImport onEndImportFunc)
        {
            importStat myImportStat = new importStat();
            myImportStat.Reset();
            data.baseDS.stockCodeDataTable stockCodeTbl = destDS.stockCode;
            data.baseDS.priceDataDataTable priceDataTbl = destDS.priceData;
            data.baseDS.priceDataRow priceDataRow;
            data.baseDS.stockCodeRow stockCodeRow;

            stockCodeTbl.Clear();
            priceDataTbl.Clear();

            DataRowView[] foundRows; 
            application.dataLibs.LoadData(stockCodeTbl);
            DataView stockCodeView = new DataView(stockCodeTbl);
            stockCodeView.RowFilter = stockCodeTbl.stockExchangeColumn.ColumnName + "='" + stockExCode + "'";   
            stockCodeView.Sort = stockCodeTbl.codeColumn.ColumnName;

            //<Ticker>,<DTYYYYMMDD>,<Open>,<High>,<Low>,<Close>,<Volume>
            decimal openPrice = 0, highPrice = 0, lowPrice = 0, closePrice = 0;
            int volume = 0;
            bool fError = false;
            DateTime onDate = DateTime.Today;
            CultureInfo dateCultureInfo = new CultureInfo(cultureCode);

            bool fCanceled = false;
            bool foundLastPriceDate = false;
            DateTime lastPriceDate = common.Consts.constNullDate;

            // open the file "data.csv" which is a CSV file with headers
            using (CsvReader csv = new CsvReader(new StreamReader(csvFileName), true))
            {
                // missing fields will not throw an exception,
                // but will instead be treated as if there was a null value
                csv.MissingFieldAction = MissingFieldAction.ReplaceByNull;

                int fieldCount = csv.FieldCount;
                if (fieldCount != 7) return false;
                while (csv.ReadNextRecord())
                {
                    Application.DoEvents();
                    myImportStat.dataCount++;

                    if (csv[0]==null) fError = false;
                    if (csv[1]==null || !DateTime.TryParse(csv[1], dateCultureInfo, DateTimeStyles.NoCurrentDateDefault, out onDate)) fError = true;
                    if (csv[2] == null || !Decimal.TryParse(csv[2], NumberStyles.Number, dateCultureInfo, out openPrice)) fError = true;
                    if (csv[3] == null || !Decimal.TryParse(csv[3], NumberStyles.Number, dateCultureInfo, out highPrice)) fError = true;
                    if (csv[4] == null || !Decimal.TryParse(csv[4], NumberStyles.Number, dateCultureInfo, out lowPrice)) fError = true;
                    if (csv[5] == null || !Decimal.TryParse(csv[5], NumberStyles.Number, dateCultureInfo, out closePrice)) fError = true;
                    if (csv[6] == null || !int.TryParse(csv[6], NumberStyles.Number, dateCultureInfo, out volume)) fError = true;
                    if (fError)
                    {
                        myImportStat.errorCount++;
                        if (onGotDataFunc != null)
                        {
                            myImportStat.actions = processAction.Error;
                            onGotDataFunc(myImportStat);
                            if (myImportStat.cancel)
                            {
                                fCanceled = true; break;
                            }
                        }
                        continue;
                    }
                    foundRows = stockCodeView.FindRows(csv[0]);
                    if (foundRows.Length == 0)
                    {
                        if (onGotDataFunc != null)
                        {
                            myImportStat.actions = processAction.Error;
                            onGotDataFunc(myImportStat);
                            if (myImportStat.cancel)
                            {
                                fCanceled = true; break;
                            }
                        }
                        continue;
                    }
                    stockCodeRow = (data.baseDS.stockCodeRow)foundRows[0].Row;

                    // Ignore all data that was in database
                    if (!foundLastPriceDate)
                    {
                        lastPriceDate = FindLastUpdatePricedata(stockCodeRow.code);
                        foundLastPriceDate = true;
                    }
                    if (lastPriceDate != common.Consts.constNullDate && onDate <= lastPriceDate)
                    {
                        if (onGotDataFunc != null)
                        {
                            myImportStat.actions = processAction.Ignore;
                            onGotDataFunc(myImportStat);
                            if (myImportStat.cancel)
                            {
                                fCanceled = true;break;
                            }
                        }
                        continue;
                    }

                    if (priceDataTbl.FindBystockCodeonDate(stockCodeRow.code, onDate) != null)
                    {
                        myImportStat.errorCount++;
                        if (onGotDataFunc != null)
                        {
                            myImportStat.actions = processAction.Error;
                            onGotDataFunc(myImportStat);
                            if (myImportStat.cancel)
                            {
                                fCanceled = true; break;
                            }
                        }
                        continue;
                    }
                    myImportStat.updateCount++;
                    priceDataRow = priceDataTbl.NewpriceDataRow();
                    application.dataLibs.InitData(priceDataRow);
                    priceDataRow.stockCode = stockCodeRow.code;
                    priceDataRow.onDate = onDate;
                    priceDataRow.openPrice = openPrice;
                    priceDataRow.highPrice = highPrice;
                    priceDataRow.lowPrice = lowPrice;
                    priceDataRow.closePrice = closePrice;
                    priceDataRow.volumne = volume;
                    priceDataTbl.AddpriceDataRow(priceDataRow);
                    if (onGotDataFunc != null)
                    {
                        myImportStat.actions = processAction.Added;
                        onGotDataFunc(myImportStat);
                        if (myImportStat.cancel)
                        {
                            fCanceled = true;break;
                        }
                    }
                    if (onUpdateDataFunc != null) onUpdateDataFunc(priceDataRow);
                    if (myImportStat.minUpdateDate > onDate) myImportStat.minUpdateDate = onDate;
                    if (myImportStat.maxUpdateDate < onDate) myImportStat.maxUpdateDate = onDate;
                }
            }
            if (fCanceled)
            {
                priceDataTbl.Clear();
                return false;
            }
            if (onEndImportFunc != null) onEndImportFunc(destDS);
            return true;
        }

        //For command-line update
        private static void UpdatePriceData(data.baseDS ds) 
        { 
            application.dataLibs.UpdateData(ds.priceData);
            application.dataLibs.UpdateData(ds.priceDataDay);
            application.dataLibs.UpdateData(ds.priceDataWeek);
            application.dataLibs.UpdateData(ds.priceDataMonth);
            application.dataLibs.UpdateData(ds.priceDataYear); 
        }
        public static bool ImportPricedata_CSV(string csvFileName, string stockExCode, string cultureCode)
        {
            return ImportPricedata_CSV(csvFileName, stockExCode, cultureCode,new data.baseDS(),null,null, UpdatePriceData);
        }

        public static void AggregatePriceData(data.baseDS myDataDS, string cultureCode, onAggregateData onAggregateDataFunc) 
        {
            data.baseDS.priceDataDayRow priceDataDayRow;
            data.baseDS.priceDataWeekRow priceDataWeekRow;
            data.baseDS.priceDataMonthRow priceDataMonthRow;
            data.baseDS.priceDataYearRow priceDataYearRow;

            CultureInfo cultureInfo = new CultureInfo(cultureCode);
            byte week=0,month=0;
            short year=0;
            int dataTimeOffsetDay = 0, dataTimeOffsetWeek = 0, dataTimeOffsetMonth = 0, dataTimeOffsetYear = 0;
            DateTime dataDate, lastDataDate = common.Consts.constNullDate;

            myDataDS.priceDataDay.Clear();
            myDataDS.priceDataWeek.Clear();
            myDataDS.priceDataMonth.Clear();
            myDataDS.priceDataYear.Clear();
            data.baseDS.priceDataDataTable dataTbl = myDataDS.priceData;
            agrregateStat myAgrregateStat = new agrregateStat();
            myAgrregateStat.maxCount = dataTbl.Count;
            for (int idx = 0; idx < dataTbl.Count; idx++)
            {
                myAgrregateStat.count = idx;
                if (onAggregateDataFunc != null) onAggregateDataFunc(myAgrregateStat);
                if (myAgrregateStat.cancel) break;
                Application.DoEvents();

                dataDate = dataTbl[idx].onDate;
                if (dataDate != lastDataDate)
                {
                    week = common.dateTimeLibs.WeekOfYear(dataDate);
                    month = (byte)dataDate.Month;
                    year = (short)dataDate.Year;
                    dataTimeOffsetDay = common.dateTimeLibs.DateDiffInMins(dataDate.Date, dataDate);
                    dataTimeOffsetWeek = common.dateTimeLibs.DateDiffInMins(common.dateTimeLibs.StartOfWeek(dataDate, cultureInfo), dataDate);
                    dataTimeOffsetMonth = common.dateTimeLibs.DateDiffInMins(common.dateTimeLibs.MakeDate(1, month, year), dataDate);
                    dataTimeOffsetYear = common.dateTimeLibs.DateDiffInMins(common.dateTimeLibs.MakeDate(1, 1, year), dataDate);
                    lastDataDate = dataDate;
                }

                //Day aggregation
                priceDataDayRow = application.dataLibs.FindAndCache(myDataDS.priceDataDay, dataTbl[idx].stockCode, dataDate.Date);
                if (priceDataDayRow == null)
                {
                    priceDataDayRow = myDataDS.priceDataDay.NewpriceDataDayRow();
                    application.dataLibs.InitData(priceDataDayRow);
                    priceDataDayRow.stockCode = dataTbl[idx].stockCode;
                    priceDataDayRow.onDate = dataDate.Date;
                    priceDataDayRow.openPrice = dataTbl[idx].openPrice;
                    priceDataDayRow.closePrice = dataTbl[idx].closePrice;
                    priceDataDayRow.openTimeOffset = short.MaxValue;
                    priceDataDayRow.closeTimeOffset = short.MinValue;
                    myDataDS.priceDataDay.AddpriceDataDayRow(priceDataDayRow);
                }
                if (priceDataDayRow.openTimeOffset > dataTimeOffsetDay)
                {
                    priceDataDayRow.openPrice = dataTbl[idx].openPrice;
                    priceDataDayRow.openTimeOffset = (short)dataTimeOffsetDay;
                }
                if (priceDataDayRow.closeTimeOffset < dataTimeOffsetDay)
                {
                    priceDataDayRow.closePrice = dataTbl[idx].closePrice;
                    priceDataDayRow.closeTimeOffset = (short)dataTimeOffsetDay;
                }
                if (priceDataDayRow.highPrice < dataTbl[idx].highPrice) priceDataDayRow.highPrice = dataTbl[idx].highPrice;
                if (priceDataDayRow.lowPrice < dataTbl[idx].lowPrice) priceDataDayRow.lowPrice = dataTbl[idx].lowPrice;
                priceDataDayRow.volumne += dataTbl[idx].volumne;

                //Week aggregation
                priceDataWeekRow = application.dataLibs.FindAndCache(myDataDS.priceDataWeek, dataTbl[idx].stockCode, year, week);
                if (priceDataWeekRow == null)
                {
                    priceDataWeekRow = myDataDS.priceDataWeek.NewpriceDataWeekRow();
                    application.dataLibs.InitData(priceDataWeekRow);
                    priceDataWeekRow.stockCode = dataTbl[idx].stockCode;
                    priceDataWeekRow.onYear = year;
                    priceDataWeekRow.onWeek = week;
                    priceDataWeekRow.openPrice = dataTbl[idx].openPrice;
                    priceDataWeekRow.closePrice = dataTbl[idx].closePrice;
                    priceDataWeekRow.openTimeOffset = short.MaxValue;
                    priceDataWeekRow.closeTimeOffset = short.MinValue;
                    myDataDS.priceDataWeek.AddpriceDataWeekRow(priceDataWeekRow);
                }
                if (priceDataWeekRow.openTimeOffset > dataTimeOffsetWeek)
                {
                    priceDataWeekRow.openPrice = dataTbl[idx].openPrice;
                    priceDataWeekRow.openTimeOffset = (short)dataTimeOffsetWeek;
                }
                if (priceDataWeekRow.closeTimeOffset < dataTimeOffsetWeek)
                {
                    priceDataWeekRow.closePrice = dataTbl[idx].closePrice;
                    priceDataWeekRow.closeTimeOffset = (short)dataTimeOffsetWeek;
                }
                if (priceDataWeekRow.highPrice < dataTbl[idx].highPrice) priceDataWeekRow.highPrice = dataTbl[idx].highPrice;
                if (priceDataWeekRow.lowPrice < dataTbl[idx].lowPrice) priceDataWeekRow.lowPrice = dataTbl[idx].lowPrice;
                priceDataWeekRow.volumne += dataTbl[idx].volumne;

                //Month aggregation
                priceDataMonthRow = application.dataLibs.FindAndCache(myDataDS.priceDataMonth, dataTbl[idx].stockCode, year, month);
                if (priceDataMonthRow == null)
                {
                    priceDataMonthRow = myDataDS.priceDataMonth.NewpriceDataMonthRow();
                    application.dataLibs.InitData(priceDataMonthRow);
                    priceDataMonthRow.stockCode = dataTbl[idx].stockCode;
                    priceDataMonthRow.onYear = year;
                    priceDataMonthRow.onMonth = month;
                    priceDataMonthRow.openPrice = dataTbl[idx].openPrice;
                    priceDataMonthRow.closePrice = dataTbl[idx].closePrice;
                    priceDataMonthRow.openTimeOffset = int.MaxValue;
                    priceDataMonthRow.closeTimeOffset = int.MinValue;
                    myDataDS.priceDataMonth.AddpriceDataMonthRow(priceDataMonthRow);
                }
                if (priceDataMonthRow.openTimeOffset > dataTimeOffsetMonth)
                {
                    priceDataMonthRow.openPrice = dataTbl[idx].openPrice;
                    priceDataMonthRow.openTimeOffset = dataTimeOffsetMonth;
                }
                if (priceDataMonthRow.closeTimeOffset < dataTimeOffsetMonth)
                {
                    priceDataMonthRow.closePrice = dataTbl[idx].closePrice;
                    priceDataMonthRow.closeTimeOffset = dataTimeOffsetMonth;
                }
                if (priceDataMonthRow.highPrice < dataTbl[idx].highPrice) priceDataMonthRow.highPrice = dataTbl[idx].highPrice;
                if (priceDataMonthRow.lowPrice < dataTbl[idx].lowPrice) priceDataMonthRow.lowPrice = dataTbl[idx].lowPrice;
                priceDataMonthRow.volumne += dataTbl[idx].volumne;

                //Year aggregation
                priceDataYearRow = application.dataLibs.FindAndCache(myDataDS.priceDataYear, dataTbl[idx].stockCode, year);
                if (priceDataYearRow == null)
                {
                    priceDataYearRow = myDataDS.priceDataYear.NewpriceDataYearRow();
                    application.dataLibs.InitData(priceDataYearRow);
                    priceDataYearRow.stockCode = dataTbl[idx].stockCode;
                    priceDataYearRow.onYear = year;
                    priceDataYearRow.openPrice = dataTbl[idx].openPrice;
                    priceDataYearRow.closePrice = dataTbl[idx].closePrice;
                    priceDataYearRow.openTimeOffset = int.MaxValue;
                    priceDataYearRow.closeTimeOffset = int.MinValue;
                    myDataDS.priceDataYear.AddpriceDataYearRow(priceDataYearRow);
                }
                if (priceDataYearRow.openTimeOffset > dataTimeOffsetYear)
                {
                    priceDataYearRow.openPrice = dataTbl[idx].openPrice;
                    priceDataYearRow.openTimeOffset = dataTimeOffsetYear;
                }
                if (priceDataYearRow.closeTimeOffset < dataTimeOffsetYear)
                {
                    priceDataYearRow.closePrice = dataTbl[idx].closePrice;
                    priceDataYearRow.closeTimeOffset = dataTimeOffsetYear;
                }
                if (priceDataYearRow.highPrice < dataTbl[idx].highPrice) priceDataYearRow.highPrice = dataTbl[idx].highPrice;
                if (priceDataYearRow.lowPrice < dataTbl[idx].lowPrice) priceDataYearRow.lowPrice = dataTbl[idx].lowPrice;
                priceDataYearRow.volumne += dataTbl[idx].volumne;
            }
        }
        
        #endregion
    }
}
