﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace admin.forms
{
    public partial class sysWatchList : baseClass.forms.watchListEdit
    {
        public sysWatchList()
        {
            InitializeComponent();
            this.myWatchListType = application.AppTypes.PortfolioTypes.SysWatchList;
            this.myInvestorCode = application.sysLibs.sysLoginCode;
        }
        public new static sysWatchList GetForm(string formName)
        {
            string cacheKey = typeof(sysWatchList).FullName + (formName != null && formName.Trim() == "" ? "-" + formName.Trim() : "");
            sysWatchList form = (sysWatchList)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new sysWatchList();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
    }
}
