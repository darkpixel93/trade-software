using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using application;
using databases;
using commonTypes;
using common;

namespace baseClass.forms
{
    public partial class feedbackViewer : feedbackEdit   
    {

        private bool _fullMode = false;
        private bool fullMode
        {
            get { return _fullMode; }
            set
            {
                _fullMode = value;
                this.Height = dataGrid.Location.Y + 7 + 2 * SystemInformation.CaptionHeight + (_fullMode ? dataGrid.Height : 0);
                this.Width = optionPnl.Location.X + optionPnl.Width + (_fullMode ? infoPnl.Width : 0) + 5;

                infoPnl.Visible = _fullMode;
                dataGrid.Visible = _fullMode;
                Application.DoEvents();
            }
        }
        public feedbackViewer()
        {
            try
            {
                InitializeComponent();
                fullMode = false;
                feedbackTypeCb2.LoadData();
                //common.system.AutoFitGridColumn(syslogGrid, descriptionColumn.Name);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
        public override void LockEdit(bool l)
        {
            base.LockEdit(true);
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("feedback");

            feedbackTypeChk2.Text = feedbackTypeLbl.Text;
            accountChk.Text = Languages.Libs.GetString("account");
            codeLbl.Text = Languages.Libs.GetString("account");

            onDateColumn.HeaderText = Languages.Libs.GetString("dateTime");
            contentColumn.HeaderText = contentLbl.Text;
            senderColumn.HeaderText = Languages.Libs.GetString("account");
        }

        protected override void ReLoadData()
        {
            try
            {
                ClearNotifyError();
                if (!dateRange.GetDateRange())
                {
                    NotifyError(dateRange);
                    return;
                }
                fullMode = false;
                DoLoadData();
                fullMode = true;
                fProcessing = false;
                this.ShowReccount(messagesSource.Count);
            }
            catch (Exception er)
            {
                fProcessing = false;
                this.ShowError(er);
            }
        }
        private void DoLoadData()
        {
            DataAccess.AppLibs.LoadInvestor(DataAccess.AppLibs.myCacheBaseDS.investor, false);
            investorSource.DataSource = DataAccess.AppLibs.myCacheBaseDS.investor;

            string filter = myDataSet.messages.OnDateColumn.ColumnName + " BETWEEN '" +
                                            common.system.ConvertToSQLDateString(dateRange.frDate) + "' AND '" +
                                            common.system.ConvertToSQLDateString(dateRange.toDate) + "'";

            if (feedbackTypeChk2.Checked)
            {
                filter += (filter == "" ? "" : " AND ") + common.system.MakeSearchExpression(myDataSet.messages.CategoryColumn.ColumnName, feedbackTypeCb2.myValue, system.searchOptions.Exact, true);
            }            
            if (accountChk.Checked && accountEd.Text.Trim() != "")
            {
                databases.tmpDS.investorRow row = DataAccess.AppLibs.GetInvestorByAccount(accountEd.Text.Trim());
                if (row != null)
                    filter += (filter == "" ? "" : " AND ") + common.system.MakeSearchExpression(myDataSet.messages.SenderIdColumn.ColumnName, row.code, system.searchOptions.Exact, true);
            }

            if (contentChk2.Checked && contentEd2.Text.Trim() != "")
            {
                filter += (filter == "" ? "" : " AND ") + common.system.MakeSearchExpression(myDataSet.messages.MsgBodyColumn.ColumnName, contentEd2.Text.Trim(), system.searchOptions.Contain, true);
            }
            string sqlCmd = "SELECT * FROM " + myDataSet.messages.TableName + (filter == "" ? "" : " WHERE " + filter);
            messagesSource.DataSource = DataAccess.Libs.GetMesssage_BySql(sqlCmd);
        }

        #region event handler
      
        private void feedbackTypeChk2_CheckedChanged(object sender, EventArgs e)
        {
            feedbackTypeCb2.Enabled = feedbackTypeChk2.Checked;
        }
        private void accountChk_CheckedChanged(object sender, EventArgs e)
        {
            accountEd.Enabled = accountChk.Checked;
        }
        private void contentChk2_CheckedChanged(object sender, EventArgs e)
        {
            contentEd2.Enabled = contentChk2.Checked;
        }

        private void Form_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                //fullMode = fullMode;
                common.system.AutoFitGridColumn(dataGrid, contentColumn.Name);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }


        private void messagesSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (fProcessing || messagesSource.Current == null) return;
                databases.baseDS.messagesRow row = (databases.baseDS.messagesRow)((DataRowView)messagesSource.Current).Row;
                senderEd.Text = "";
                databases.tmpDS.investorRow investorRow = DataAccess.AppLibs.FindAndCache_Investor(row.SenderId);
                if (row != null) senderEd.Text = investorRow.displayName;
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        #endregion event handler
    }
}