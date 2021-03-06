using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using HtmlAgilityPack;
using System.Linq;
using commonClass;

namespace imports
{
    public class gold
    {
        public static bool ImportOHLCV_CSV(string csvFileName, string stockExchangeForNewCode,
                                            data.baseDS.priceDataDataTable priceDataTbl,
                                            libs.OnUpdatePriceData onUpdateDataFunc)
        {

            return libs.ImportOHLCV_CSV(csvFileName, ',', common.dateTimeLibs.DateTimeFormats.YYMMDDhhmmss,
                                        stockExchangeForNewCode, libs.CultureInfoUS,
                                        priceDataTbl, DoImportRow, onUpdateDataFunc, null);

        }
        static DateTime tmpDate = common.Consts.constNullDate;
        static double tmpVal = 0;
        private static libs.importOHLCV DoImportRow(LumenWorks.Framework.IO.Csv.CsvReader csv, libs.importStat importStat)
        {
            libs.importOHLCV data = new libs.importOHLCV();
            if (csv[0] == null) return null;
            data.code = csv[0];

            if (!common.dateTimeLibs.Str2Date(csv[1] + csv[2], importStat.dateFormat, out tmpDate)) return null;
            data.dateTime = tmpDate;

            if (!double.TryParse(csv[3], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Open = tmpVal;

            if (!double.TryParse(csv[4], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.High = tmpVal;

            if (!double.TryParse(csv[5], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Low = tmpVal;

            if (!double.TryParse(csv[6], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Close = tmpVal;

            if (!double.TryParse(csv[7], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Volume = tmpVal;
            return data;
        }

        //Update from http://www.forex.com/uk/index.html
        private class ForexData
        {
            public string code = "";
            public decimal last = 0, high = 0, low = 0, changed = 0;
        }
        private static ForexData[] ImportForex(string url)
        {
            System.Net.WebRequest webReq = System.Net.WebRequest.Create(url);
            System.Net.WebResponse webRes = webReq.GetResponse();
            System.IO.Stream mystream = webRes.GetResponseStream();
            if (mystream == null) return null;

            HtmlAgilityPack.HtmlDocument myHtmlDoc = new HtmlAgilityPack.HtmlDocument();
            myHtmlDoc.Load(mystream);

            int iColumn = 0;
            var myNode = myHtmlDoc.DocumentNode.SelectNodes("//table[@id='fund_list_table']/tr/td[1]");

            List<string> anchorTags = new List<string>();
            if (myNode == null) return null;

            ForexData[] result = new ForexData[0];
            foreach (HtmlNode link in myNode)
            {
                ++iColumn;
                string att = link.InnerText;
                HtmlNode thuxem = link.ParentNode;
                String attt = thuxem.InnerHtml;
                if (att == "Pair")
                {
                    HtmlNode nodeOfDataRow = link.ParentNode;   //Lấy node tên column
                    nodeOfDataRow = nodeOfDataRow.NextSibling;  // Lấy hàng dữ liệu đầu tiên
                    string asdf = nodeOfDataRow.InnerHtml;

                    while (nodeOfDataRow != null)
                    {
                        HtmlNode nodeOfRow = nodeOfDataRow.FirstChild;  //Lấy ô dữ liệu đầu tiên
                        List<String> row = new List<string>();
                        while (nodeOfRow != null)   // Lấy các ô dữ liệu tiếp theo
                        {
                            //Kiem tra xem chuoi co hop le
                            if (!nodeOfRow.InnerText.Contains("<!--") && nodeOfRow.InnerText.Length > 0)
                                row.Add(nodeOfRow.InnerText);
                            nodeOfRow = nodeOfRow.NextSibling;
                        }
                        if (row.Count >= 4)
                        {
                            ForexData data = Convert2ForexData(row);
                            if (data != null)
                            {
                                Array.Resize(ref result, result.Length + 1);
                                result[result.Length - 1] = data;
                            }
                        }
                        nodeOfDataRow = nodeOfDataRow.NextSibling;  // Lay Du Lieu Dong Tiep theo
                    }
                }
            }
            return result;
        }
        private static ForexData Convert2ForexData(List<string> row)
        {
            decimal last = 0, high = 0, low = 0, changed = 0;
            if (!common.system.StrToDecimal(row[1].Trim(), libs.CultureInfoUS, out last)) return null;
            string[] parts = row[2].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) return null;
            if (!common.system.StrToDecimal(parts[0].Trim(), libs.CultureInfoUS, out high)) return null;
            if (!common.system.StrToDecimal(parts[1].Trim(), libs.CultureInfoUS, out low)) return null;
            if (!common.system.StrToDecimal(row[3].Trim(), libs.CultureInfoUS, out changed)) return null;
            ForexData data = new ForexData();
            data.code = row[0].Replace("/", "").Replace(" ", "");
            data.last = last;
            data.high = high;
            data.low = low;
            data.changed = changed;
            return data;
        }
        private static ForexData lastForexData = null;
        private static DateTime goldOpenPriceDate = DateTime.Today;  
        private static decimal goldOpenPrice = decimal.MinValue;
        public static void ResetGetPrice()
        { 
            goldOpenPriceDate = DateTime.Today;  
            goldOpenPrice = decimal.MinValue;
        }
        private static data.importDS.importPriceDataTable GetPrice(DateTime updateTime, string url, string marketCode)
        {
            data.importDS.importPriceDataTable importPriceTbl = new data.importDS.importPriceDataTable();
            ForexData[] frData = ImportForex(url);
            ForexData goldData = frData[3]; //Gold at price 4
            if (lastForexData != null)
            {
                if (lastForexData.last == goldData.last && 
                    lastForexData.high == goldData.high &&
                    lastForexData.low  == goldData.low) return importPriceTbl;
            }
            else lastForexData = new ForexData();
            lastForexData.last = goldData.last;
            lastForexData.high = goldData.high;
            lastForexData.low = goldData.low;
            
            data.importDS.importPriceRow importRow;
            importRow = importPriceTbl.NewimportPriceRow();
            application.DbAccess.InitData(importRow);
            importRow.onDate = updateTime;
            importRow.stockExchange = marketCode;
            importRow.stockCode = goldData.code;
            importRow.closePrice = goldData.last;
            importRow.highPrice = goldData.high;
            importRow.lowPrice = goldData.low;

            if (goldOpenPriceDate != updateTime.Date || goldOpenPrice == decimal.MinValue)
            {
                data.baseDS.priceDataRow row  = application.DbAccess.GetLastPriceData(importRow.stockCode);
                if (row != null) goldOpenPrice = row.closePrice;
                else  goldOpenPrice = importRow.closePrice;
                goldOpenPriceDate = updateTime.Date;
            }
            importRow.openPrice = goldOpenPrice;
            importPriceTbl.AddimportPriceRow(importRow);
            return importPriceTbl;
        }
        public static void ImportPrice_URL(DateTime updateTime, string url, string marketCode)
        {
            data.importDS.importPriceDataTable importPriceTbl = GetPrice(updateTime, url, marketCode);
            libs.AddNewCode(importPriceTbl, null);
            application.DbAccess.UpdateData(importPriceTbl);

            data.baseDS.priceDataDataTable priceTbl = new data.baseDS.priceDataDataTable();
            libs.AddImportPrice(importPriceTbl, priceTbl);
            application.DbAccess.UpdateData(priceTbl);
            // Gold use US culture 
            libs.AggregatePriceData(priceTbl, libs.CultureInfoUS, null);
        }
    }
}
