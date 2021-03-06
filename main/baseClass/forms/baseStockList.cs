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
    public partial class baseStockList : common.forms.baseForm
    {
        public baseStockList()
        {
            try
            {
                InitializeComponent();
                LoadPortfolioStock();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        public delegate void OnStockSeleted(data.baseDS.stockCodeRow row);
        public event OnStockSeleted myOnStockSeleted = null;
        public data.baseDS.stockCodeRow myStockRow
        {
            get
            {
                if (this.myStockCode == null) return null;
                return dataLibs.FindAndCache(this.myStockCodeTbl,this.myStockCode);
            }
        }
        public void Goto(string stockCode)
        {
            if(this.myStockCodeTbl.FindBycode(stockCode)==null) return;

            TreeNode rootNode;
            for (int idx1 = 0; idx1 < stockTV.Nodes.Count; idx1++)
            {
                rootNode = stockTV.Nodes[idx1];
                for (int idx2 = 0; idx2 < rootNode.Nodes.Count; idx2++)
                {
                    if (rootNode.Nodes[idx2].Text != stockCode) continue;
                    stockTV.SelectedNode = rootNode.Nodes[idx2]; 
                    break;
                }
            }
        }

        private string myStockCode = null;
        protected data.baseDS.stockCodeDataTable myStockCodeTbl = new data.baseDS.stockCodeDataTable();

        // Load stock list specified in the user's portfolio
        protected void LoadPortfolioStock()
        {
            StringCollection stockList = new StringCollection();
            TreeNode node;

            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            portfolioTbl.Clear();
            myStockCodeTbl.Clear();
            dataLibs.LoadPortfolioByInvestor(portfolioTbl, sysLibs.sysLoginCode, AppTypes.PortfolioTypes.Portfolio);
            stockTV.Nodes.Clear();
            DataView myStockView = new DataView(myStockCodeTbl);
            data.baseDS.stockCodeRow stockRow;
            myStockView.Sort = myStockCodeTbl.codeColumn.ColumnName;

            StringCollection list = new StringCollection();
            for (int idx1 = 0; idx1 < portfolioTbl.Count; idx1++)
            {
                node = stockTV.Nodes.Add(portfolioTbl[idx1].name);

                list.Clear();
                list.Add(portfolioTbl[idx1].code);
                myStockCodeTbl.Clear();
                if (portfolioTbl[idx1].type == (byte)AppTypes.PortfolioTypes.WatchList)
                    dataLibs.LoadStockCode_ByWatchList(myStockCodeTbl, list);
                else
                    dataLibs.LoadStockCode_ByPortfolios(myStockCodeTbl, list);

                stockList.Clear();
                for (int idx2 = 0; idx2 < myStockView.Count; idx2++)
                {
                    stockRow = (data.baseDS.stockCodeRow)myStockView[idx2].Row;  
                    //Ignore duplicate stocks
                    if (stockList.Contains(stockRow.tickerCode)) continue;
                    stockList.Add(stockRow.tickerCode);
                    node.Nodes.Add(stockRow.tickerCode);
                }
                node.Text = node.Text + "(" + node.Nodes.Count.ToString() + ")";
                node.ExpandAll();
            }
        }

        #region event handler
        private void stockTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e == null || e.Node.Level==0) this.myStockCode = null;
            else this.myStockCode = e.Node.Text;
        }
        private void stockTV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.myOnStockSeleted == null) return;
                this.myOnStockSeleted(myStockRow);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void baseStockList_Resize(object sender, EventArgs e)
        {
            try
            {
                stockTV.Size = this.ClientRectangle.Size;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}