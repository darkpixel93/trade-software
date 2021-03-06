using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Xml; 
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Management;
using System.Net.Mail;
using System.Drawing;

namespace common
{
    public class myString
    {
        public myString(){}
        private string myStr = "";
        public override string ToString()
        {
            return this.myStr;
        }
        public static myString operator +(myString a, myString b)
        {
            myString c = new myString();
            c.myStr = a.myStr + b.myStr;
            return c;
        }
        public void Add(string str) 
        {
            this.myStr = (String.IsNullOrEmpty(this.myStr) ? "" : this.myStr + Consts.constCRLF) + str;
        }
        public void Clear()
        {
            this.myStr = "";
        }
    }
    public class myStringCollection : StringCollection
    {
        public static myStringCollection operator +(myStringCollection list1, myStringCollection list2)
        {
            myStringCollection retList = new myStringCollection();
            retList.Add(list1);
            retList.Add(list2);
            return retList;
        }
        public void Add(myStringCollection list)
        {
            if (list == null) return;
            for (int idx = 0; idx < this.Count; idx++)
            {
                if (this.Contains(list[idx]) == false) this.Add(list[idx]);
            }
        }
    }

    public static class StringLibs
    {
        public static StringCollection Clone(StringCollection list)
        {
            if (list == null) return null;
            StringCollection retList = new StringCollection();
            for (int idx = 0; idx < list.Count; idx++)
            {
                if (retList.Contains(list[idx]) == false) retList.Add(list[idx]);
            }
            return retList;
        }
        public static void Copy(StringCollection frList, StringCollection toList)
        {
            if (frList == null) return;
            for (int idx = 0; idx < frList.Count; idx++)
            {
                if (toList.Contains(frList[idx]) == false) toList.Add(frList[idx]);
            }
        }

      
        public static string RemoveStartWith(string str, char[] removeChars)
        {
            for (int idx = 0; idx < removeChars.Length; idx++)
                if (str.StartsWith(removeChars[idx].ToString())) str = str.Substring(1);
            return str;
        }
        public static string RemoveEndWith(string str, char[] removeChars)
        {
            for (int idx = 0; idx < removeChars.Length; idx++)
                if (str.EndsWith(removeChars[idx].ToString())) str = str.Substring(0, str.Length - 1);
            return str;
        }

        public static bool InList(string[] list, string item)
        {
            return InList(list, item, false);
        }
        public static bool InList(string[] list, string item, bool force)
        {
            item = item.Trim();
            if (list == null) return true;
            if (force)
            {
                for (int idx = 0; idx < list.Length; idx++)
                {
                    if (item == list[idx]) return true;
                }
            }
            else
            {
                for (int idx = 0; idx < list.Length; idx++)
                {
                    if (item.Contains(list[idx])) return true;
                }
            }
            return false;
        }

        public static string[] Collection2List(StringCollection list, int startIdx, int endIdx)
        {
            string[] toList = new string[endIdx - startIdx + 1];
            for (int idx1 = startIdx, idx2 = 0; idx1 <= endIdx; idx1++, idx2++) toList[idx2] = list[idx1];
            return toList;
        }
        public static string[] Collection2List(StringCollection list)
        {
            return Collection2List(list, 0, list.Count - 1);
        }
        public static StringCollection List2Collection(string[] list)
        {
            StringCollection collection = new StringCollection();
            for (int idx = 0; idx < list.Length; idx++) collection.Add(list[idx]);
            return collection;
        }

        public static StringCollection Str2Collection(string str, string addPrefix, string addPostfix, string separator)
        {
            return Str2Collection(Str2List(str, separator), addPrefix, addPostfix);
        }
        public static StringCollection Str2Collection(string[] arr, string addPrefix, string addPostfix)
        {
            StringCollection strList = new StringCollection();
            for (int idx = 0; idx < arr.Length; idx++) strList.Add(addPrefix + arr[idx] + addPostfix);
            return strList;
        }

        /// <summary>
        /// Convert a formated-string to a double number
        /// </summary>
        /// <param name="doublStr">a formated-string of a double numer</param>
        /// <param name="db"> double nubmer converted form [doublStr]</param>
        /// <returns></returns>
        public static bool Str2Double(string str, CultureInfo cultureInfo, out double num)
        {
            if (!double.TryParse(str, NumberStyles.Float | NumberStyles.AllowThousands, cultureInfo, out num))
            {
                num = 0;
                return false;
            }
            return true;
        }
        public static bool Str2Decimal(string str, CultureInfo cultureInfo, out decimal num)
        {
            if (!decimal.TryParse(str, NumberStyles.Float | NumberStyles.AllowThousands, cultureInfo, out num))
            {
                num = 0;
                return false;
            }
            return true;
        }
        public static bool Str2Int(string str, CultureInfo cultureInfo, out int num)
        {
            if (!int.TryParse(str, NumberStyles.Float | NumberStyles.AllowThousands, cultureInfo, out num))
            {
                num = 0;
                return false;
            }
            return true;
        }

        public static decimal Str2Decimal(string str)
        {
            decimal d = 0;
            decimal.TryParse(str, out d);
            return d;
        }

        public static string[] Str2List(string str, string separator)
        {
            return Str2List(str, separator, StringSplitOptions.RemoveEmptyEntries);
        }
        public static string[] Str2List(string str, string separator, StringSplitOptions options)
        {
            string[] items = str.Split(new string[] { separator }, options);
            for (int idx = 0; idx < items.Length; idx++) items[idx] = items[idx].Trim();
            return items;
        }
        /// <summary>
        /// In SQL command, a date is a string of MM/DD/YYYY hh:mm:ss. The function convert any date to SQL Date-stype.
        /// Return "" if the date is invalid
        /// </summary>
        /// <param name="date">DateTime in current format</param>
        /// <returns></returns>
        public static string Date2SqlString(DateTime date, bool dateOnly)
        {
            string tmp = date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString();
            if (!dateOnly) tmp += " " + date.Hour.ToString() + ":" + date.Minute.ToString() + ":" + date.Second.ToString();
            return tmp;
        }
        public static string Date2SqlString(DateTime date)
        {
            return Date2SqlString(date, true);
        }

        public static string HideString(string str,char maskChar)
        {
            return new string(maskChar, str.Length);
        }
        public static string[] Concat(string[] str1, string[] str2)
        {
            string[] retStr = new string[str1.Length + str2.Length];
            str1.CopyTo(retStr, 0);
            for (int idx = 0; idx < str2.Length; idx++) retStr[str1.Length + idx] = str2[idx];
            return retStr;
        }

        public static string MakeString(string connector, params string[] list)
        {
            string retStr = "";
            foreach (string arg in list)
            {
                if (arg == null || arg.Trim() == "") continue;
                string str = arg.Trim();
                retStr += (retStr == "" || retStr.EndsWith(connector) ? "" : connector);
                retStr += (str.StartsWith(connector) ? str.Substring(connector.Length) : str);
            }
            return retStr;
        }
        public static string MakeString(string prefixStr, string postfixStr, string operatorStr, params string[] list)
        {
            StringCollection items = new StringCollection();
            foreach (string arg in list)
            {
                if (arg == null || arg.Trim() == "") continue;
                items.Add(arg);
            }
            return ToString(items, operatorStr, prefixStr, postfixStr);
        }

        public static string[] MakeList(params string[] list)
        {
            string[] retList = new string[0];
            for (int idx = 0; idx < list.Length; idx++)
            {
                if (list[idx] == null || list[idx].Trim() == "") continue;
                Array.Resize(ref retList, retList.Length + 1);
                retList[retList.Length - 1] = list[idx];
            }
            return retList;
        }

        public static string ToString(IList<string> list, string separator, string prefix, string postfix)
        {
            if (list == null) return "";
            string retStr = "";
            foreach (string str in list)
            {
                if (str == null || str.Trim() == "") continue;
                retStr += (retStr == "" ? "" : separator) + prefix + str + postfix;
            }
            return retStr;
        }
        public static string ToString(object[] list, string separator, string prefix, string postfix)
        {
            if (list == null) return "";
            string retStr = "";
            foreach (string obj in list)
            {
                if (obj == null) continue;
                retStr += (retStr == "" ? "" : separator) + prefix + obj + postfix;
            }
            return retStr;
        }
        public static string ToString(int[] list, string separator, string prefix, string postfix)
        {
            if (list == null) return "";
            string retStr = "";
            foreach (int obj in list)
            {
                retStr += (retStr == "" ? "" : separator) + prefix + obj + postfix;
            }
            return retStr;
        }
        public static string ToString(string[] list, string separator, string prefix, string postfix)
        {
            if (list == null) return "";
            string retStr = "";
            foreach (string obj in list)
            {
                if (obj == null || obj.Trim() == "") continue;
                retStr += (retStr == "" ? "" : separator) + prefix + obj.Trim() + postfix;
            }
            return retStr;
        }
        public static string ToString(StringCollection list, string separator, string prefix, string postfix)
        {
            if (list == null) return "";
            string retStr = "";
            foreach (string str in list)
            {
                if (str == null || str.Trim()=="") continue;
                retStr += (retStr == "" ? "" : separator) + prefix + str + postfix;
            }
            return retStr;
        }
        public static StringCollection MultivalueStr2List(string mvString, string prefix, string postfix, string separator)
        {
            string[] arr = StringLibs.Str2List(mvString, separator);
            StringCollection list = new StringCollection();
            int tmpLen;
            for (int idx = 0; idx < arr.Length; idx++)
            {
                arr[idx] = arr[idx].Trim();
                if (arr[idx].StartsWith(prefix)) arr[idx] = arr[idx].Remove(0, prefix.Length);
                tmpLen = arr[idx].LastIndexOf(postfix);
                if (tmpLen > 0) arr[idx] = arr[idx].Remove(tmpLen);
                list.Add(arr[idx]);
            }
            return list;
        }
    }
}


