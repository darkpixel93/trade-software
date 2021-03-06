using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace baseClass.forms
{
    public partial class baseTradeAlert : common.forms.baseForm
    {
        public baseTradeAlert()
        {
            try
            {
                InitializeComponent();
                tradeAlertStatusCb.LoadData();
                portpolioCb.LoadData();
                cancelColumn.myImageType = common.control.imageType.Cancel;
                viewColumn.myImageType = common.control.imageType.Edit;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        protected void ShowReccount()
        {
            this.countLbl.Text = tradeAlertSource.Count.ToString();
        }

        protected void LoadData()
        {
            application.dataLibs.LoadData(myDataSet.tradeAlert, application.sysLibs.sysLoginCode, (byte)application.myTypes.commonStatus.New);
            ShowReccount();
        }

        protected void LoadDataForFilter()
        {
            string condCmd ="";
            condCmd += (condCmd == "" ? "" : " AND ") +
                "(" + myDataSet.tradeAlert.investorCodeColumn.ColumnName + " =N'" + application.sysLibs.sysLoginCode + "')"; 
            
            if (frDateEd.Enabled && !frDateEd.isDateNull())
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + myDataSet.tradeAlert.onTimeColumn.ColumnName + ">='" + common.system.ConvertToSQLDateString(frDateEd.myDateTime) + "')";
            if (tradeAlertStatusCb.Enabled)
                condCmd += (condCmd == "" ? "" : " AND ") + 
                    "(" + myDataSet.tradeAlert.statusColumn.ColumnName + " & " + ((byte)tradeAlertStatusCb.myValue).ToString() +">0)";
            
            if (portpolioCb.Enabled)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + myDataSet.tradeAlert.portpolioCodeColumn.ColumnName + "=N'" + portpolioCb.myValue + "')";

            string sqlCmd = " SELECT * FROM " + myDataSet.tradeAlert.TableName + (condCmd == "" ? "" : " WHERE " + condCmd);
            myDataSet.tradeAlert.Clear();
            application.dataLibs.LoadFromSQL(myDataSet.tradeAlert, sqlCmd);
            ShowReccount();
        }

        #region event handler
        private void showFilterBtn_Click(object sender, EventArgs e)
        {
            if (filterPnl.Visible) filterPnl.Hide();
            else filterPnl.Show();
        }

        private void tradeAlertStatusChk_CheckedChanged(object sender, EventArgs e)
        {
            tradeAlertStatusCb.Enabled = tradeAlertStatusChk.Checked;
        }

        private void portpolioChk_CheckedChanged(object sender, EventArgs e)
        {
            portpolioCb.Enabled = portpolioChk.Checked;
        }

        private void frDateChk_CheckedChanged(object sender, EventArgs e)
        {
            frDateEd.Enabled = frDateChk.Checked;
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDataForFilter();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        
        private void baseTradeAlert_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
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
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}