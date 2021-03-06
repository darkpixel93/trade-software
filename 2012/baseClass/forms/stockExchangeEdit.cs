using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace baseClass.forms
{
    public partial class stockExchangeEdit : baseMasterEdit   
    {
        public stockExchangeEdit()
        {
            try
            {
                InitializeComponent();
                codeEd.isToUpperCase = true;
                codeEd.MaxLength = myDataSet.stockExchange.codeColumn.MaxLength;
                nameEd.MaxLength = myDataSet.stockExchange.descriptionColumn.MaxLength;
                myMasterSource = stockExchangeSource;
                countryCb.LoadData();
                LockEdit(true);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("market");

            codeLbl.Text = Languages.Libs.GetString("code");
            nameLbl.Text = Languages.Libs.GetString("name");
            countryLbl.Text = Languages.Libs.GetString("country");
            weightLbl.Text = Languages.Libs.GetString("weight");

            workTimeLbl.Text = Languages.Libs.GetString("workTime");
            hodidayLbl.Text = Languages.Libs.GetString("hodidays");

            buy2SellInDaysLbl.Text = Languages.Libs.GetString("buy2SellInterval") + 
                                    " (" + Languages.Libs.GetString("days") + ")";
            priceWeightLbl.Text = Languages.Libs.GetString("priceWeight");
            volumeWeightLbl.Text = Languages.Libs.GetString("volumeWeight");
            transFeePercLbl.Text = Languages.Libs.GetString("transFeePerc");

            codeColumn.HeaderText = Languages.Libs.GetString("code");
            nameColumn.HeaderText = Languages.Libs.GetString("name");

            countryCb.SetLanguage();
        }

        protected override void SetFirstFocus()
        {
            this.codeEd.Focus();
        }

        protected override void ReLoadData()
        {
            LoadData();
        }
        protected override void LoadData()
        {
            stockExchangeSource.DataSource = DataAccess.Libs.myStockExchangeTbl;
            LoadDetail(codeEd.Text);
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            this.codeEd.Enabled = !lockState;
            this.nameEd.Enabled = !lockState;
            this.countryCb.Enabled = !lockState;

            this.workTimeEd.Enabled = !lockState;
            this.hodidayEd.Enabled = !lockState;

            this.transFeePercEd.Enabled = !lockState;
            this.priceWeightEd.Enabled = !lockState;
            this.volumeWeightEd.Enabled = !lockState;
            this.priceAmplitudeEd.Enabled = !lockState;

            this.buy2SellIntervalEd.Enabled = !lockState;
            this.weightEd.Enabled = !lockState;

            this.dataSourceGrid.ReadOnly = lockState;
        }
        protected override bool DataValid(bool showMsg)
        {
            ClearNotifyError();
            bool retVal = base.DataValid(showMsg);
            if (codeEd.Text.Trim() == "") 
            {
                NotifyError(codeLbl);
                retVal = false; 
            }
            if (nameEd.Text.Trim() == "")
            {
                NotifyError(nameLbl);
                retVal = false;
            }
            if (countryCb.myValue.Trim() == "")
            {
                NotifyError(countryLbl);
                retVal = false;
            }
            return retVal;
        }
        public override void AddNew(string code)
        {
            this.AddNewRow();
            databases.baseDS.stockExchangeRow row = (databases.baseDS.stockExchangeRow)((DataRowView)myMasterSource.Current).Row;
            if (row == null) return;
            databases.AppLibs.InitData(row);
            row.code = code;
            int position = myMasterSource.Position;
            myMasterSource.Position = -1;
            myMasterSource.Position = position;
        }
        protected override void RemoveCurrent()
        {
            this.ShowMessage("");
            if (myMasterSource.Current == null) return;
            databases.baseDS.stockExchangeRow row = (databases.baseDS.stockExchangeRow)(myMasterSource.Current as DataRowView).Row;
            if (row.HasVersion(DataRowVersion.Original))
                DataAccess.Libs.DeleteData(row);
            myMasterSource.RemoveCurrent();
            this.ShowMessage(Languages.Libs.GetString("dataWasDeleted"));
        }
        protected override void UpdateData(DataRow row )
        {
            if (row == null) return;
            DataAccess.Libs.UpdateData((databases.baseDS.stockExchangeRow)row);
            for (int idx = 0; idx < myDataSet.exchangeDetail.Count; idx++)
            {
                if (myDataSet.exchangeDetail[idx].RowState == DataRowState.Deleted) continue;
                myDataSet.exchangeDetail[idx].marketCode = codeEd.Text;
            }
            DataAccess.Libs.UpdateData(myDataSet.exchangeDetail);
        }

        private void LoadDetail(string code)
        {
            myDataSet.exchangeDetail.Clear();
            DataAccess.Libs.LoadData(myDataSet.exchangeDetail, code);
        }

        private void listGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowError(e.Exception);  
            return;
        }
        private void codeEd_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = this.CheckDuplicateKey(codeEd.Text.Trim(),myDataSet.stockExchange.codeColumn.ColumnName);
        }
        private void stockExchangeSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (fOnProccessing) return;
                LoadDetail(codeEd.Text); 
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        private void dataSourceGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (exchangeDetailSource.Current != null)
                {
                    databases.AppLibs.InitData((databases.baseDS.exchangeDetailRow)((DataRowView)exchangeDetailSource.Current).Row);
                } 
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
    }    
}