using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;
using commonTypes;
using commonClass;

namespace Trade.Forms
{
    public partial class tradeAlertEdit : baseClass.forms.baseDialogForm 
    {
        public tradeAlertEdit()
        {
            try
            {
                InitializeComponent();
                Init();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        public void Init()
        {
            strategyCb.LoadData();
            statusCb.LoadData();
            actionCb.LoadData();
            timeScaleCb.LoadData();
            portfolioCb.LoadData(commonClass.SysLibs.sysLoginCode, false);
            onDateEd.BackColor = common.Settings.sysColorDisableBG; 
            onDateEd.ForeColor = common.Settings.sysColorDisableFG;

            alertCodeEd.BackColor = common.Settings.sysColorDisableBG; 
            alertCodeEd.ForeColor = common.Settings.sysColorDisableFG;

            codeEd.BackColor = common.Settings.sysColorDisableBG; 
            codeEd.ForeColor = common.Settings.sysColorDisableFG;

            subjectEd.BackColor = common.Settings.sysColorDisableBG; 
            subjectEd.ForeColor = common.Settings.sysColorDisableFG;

            informationEd.BackColor = common.Settings.sysColorDisableBG; 
            informationEd.ForeColor = common.Settings.sysColorDisableFG;

            statusCb.BackColor = common.Settings.sysColorDisableBG;
            statusCb.ForeColor = common.Settings.sysColorDisableFG;

            portfolioCb.BackColor = common.Settings.sysColorDisableBG; 
            portfolioCb.ForeColor = common.Settings.sysColorDisableFG;

            strategyCb.BackColor = common.Settings.sysColorDisableBG; 
            strategyCb.ForeColor = common.Settings.sysColorDisableFG;

            timeScaleCb.BackColor = common.Settings.sysColorDisableBG;
            timeScaleCb.ForeColor = common.Settings.sysColorDisableFG;

            onDateEd.BackColor = common.Settings.sysColorDisableBG;
            onDateEd.ForeColor = common.Settings.sysColorDisableFG;

            onDateEd.LockEdit(true);
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("tradeAlert");
            
            this.codeLbl.Text = Languages.Libs.GetString("code");
            this.onDateLbl.Text = Languages.Libs.GetString("onDate");
            this.subjectLbl.Text = Languages.Libs.GetString("subject");
            this.actionLbl.Text = Languages.Libs.GetString("tradeAction");
            this.statusLbl.Text = Languages.Libs.GetString("status");
            this.portfolioLbl.Text = Languages.Libs.GetString("portfolio");
            this.strategyLbl.Text = Languages.Libs.GetString("strategy");
            this.informationLbl.Text = Languages.Libs.GetString("information");

            this.orderBtn.Text = Languages.Libs.GetString("order");
            this.disableAlertBtn.Text = Languages.Libs.GetString("disableAlert");
            this.enableAlertBtn.Text = Languages.Libs.GetString("enableAlert");
            this.closeBtn.Text = Languages.Libs.GetString("close");

            this.actionCb.SetLanguage();
            this.statusCb.SetLanguage();
            this.portfolioCb.SetLanguage();
            this.strategyCb.SetLanguage();
            this.timeScaleCb.SetLanguage();
        }

        public virtual void SetFocus()
        {
            this.Focus();
            onDateEd.Focus();
        }

        private transactionFromAlert _myNewTradeOrderForm = null;
        private transactionFromAlert myNewTradeOrderForm
        {
            get
            {
                if (_myNewTradeOrderForm == null || _myNewTradeOrderForm.IsDisposed)
                    _myNewTradeOrderForm = GetNewTradeOrderForm();
                return _myNewTradeOrderForm;
            }
        }
        protected virtual transactionFromAlert GetNewTradeOrderForm()
        {
            return new transactionFromAlert();
        }

        public void ShowForm(BindingSource dataSource,int rowId)
        {
            this.myDataSource = dataSource;
            for (int idx = 0; idx < dataSource.Count; idx++)
            {
                if (((databases.baseDS.tradeAlertRow)((DataRowView)this.myDataSource[idx]).Row).id != rowId) continue;
                this.myDataSource.Position = idx;
                break;
            }
            SetFocus();
            ShowDialog();
        }
        private BindingSource myDataSource
        {
            get { return alertSource; }
            set
            {
                databases.baseDS.tradeAlertDataTable tbl = (databases.baseDS.tradeAlertDataTable)value.DataSource;
                this.alertSource.DataSource = tbl;

                this.onDateEd.DataBindings.Clear();
                this.onDateEd.DataBindings.Add(new System.Windows.Forms.Binding("myValue", this.alertSource, tbl.onTimeColumn.ColumnName, true));

                this.alertCodeEd.DataBindings.Clear();
                this.alertCodeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alertSource, tbl.idColumn.ColumnName, true));

                this.codeEd.DataBindings.Clear();
                this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alertSource, tbl.stockCodeColumn.ColumnName, true));

                this.subjectEd.DataBindings.Clear();
                this.subjectEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alertSource, tbl.subjectColumn.ColumnName, true));

                this.strategyCb.DataBindings.Clear();
                this.strategyCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", this.alertSource, tbl.strategyColumn.ColumnName, true));

                this.timeScaleCb.DataBindings.Clear();
                this.timeScaleCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.alertSource, tbl.timeScaleColumn.ColumnName, true));

                this.portfolioCb.DataBindings.Clear();
                this.portfolioCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", this.alertSource, tbl.portfolioColumn.ColumnName, true));

                this.statusCb.DataBindings.Clear();
                this.statusCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.alertSource, tbl.statusColumn.ColumnName, true));

                this.actionCb.DataBindings.Clear();
                this.actionCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.alertSource, tbl.tradeActionColumn.ColumnName, true));
            }
        }

        private databases.baseDS.tradeAlertRow myCurrentRow 
        {
            get
            {
                if (this.myDataSource == null || this.myDataSource.Current == null) return null;
                return (databases.baseDS.tradeAlertRow)((DataRowView)this.myDataSource.Current).Row;
            }
        }

        #region event handler
        private void orderBtn_Click(object sender, EventArgs e)
        {
            this.ShowMessage("");
            if (this.myCurrentRow == null)
            {
                this.ShowMessage(Languages.Libs.GetString("noData"));
                return;
            }
            //Trade order 
            databases.baseDS.tradeAlertRow row = this.myCurrentRow;
            myNewTradeOrderForm.ShowNew(row);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (this.myCurrentRow==null) 
                {
                    this.ShowMessage(Languages.Libs.GetString("noData"));
                    return;
                }
                if (this.myCurrentRow.status == (byte)AppTypes.CommonStatus.Close)
                {
                    return;
                }
                databases.baseDS.tradeAlertRow row = this.myCurrentRow;
                row.status = (byte)AppTypes.CommonStatus.Close;
                DataAccess.Libs.UpdateData(row);
                this.ShowMessage(Languages.Libs.GetString("alertClosed"));
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void recoverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (this.myCurrentRow == null)
                {
                    this.ShowMessage(Languages.Libs.GetString("noData"));
                    return;
                }
                databases.baseDS.tradeAlertRow row = this.myCurrentRow;
                if (row.status == (byte)AppTypes.CommonStatus.New) return;
                row.status = (byte)AppTypes.CommonStatus.New;
                DataAccess.Libs.UpdateData(row);
                this.ShowMessage(Languages.Libs.GetString("alertRecovered"));
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void alertSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                informationEd.Text = "";
                if (this.alertSource.Current == null) return;
                informationEd.Text = AppLibs.AlertMessageText(this.myCurrentRow.msg);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}