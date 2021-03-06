using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace stockTrade.forms
{
    public partial class baseTradeAlertNotify : basePortfolioView
    {
        public baseTradeAlertNotify()
        {
            try
            {
                InitializeComponent();
                this.myStatusStrip.Visible = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        protected override void ResizeForm()
        {
            //tradeAlertList.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height - tradeAlertList.Location.Y);
        }

        #region event handler
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}