using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.IO;

namespace data
{
    public class system
    {
        private static string _dbConnectionString = null;
        public static string dbConnectionString
        {
            get
            {
                return "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";

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
    }
}
