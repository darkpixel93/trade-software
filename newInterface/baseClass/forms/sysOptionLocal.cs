using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using commonTypes;
using commonClass;

namespace baseClass.forms
{
    public partial class sysOptionLocal : baseClass.forms.baseDialogForm    
    {
        public sysOptionLocal()
        {
            try
            {
                InitializeComponent();
                mainFontEd.BackColor = bgImgFileEd.BackColor;
                mainFontEd.ForeColor = bgImgFileEd.ForeColor;

                menuFontEd.BackColor = bgImgFileEd.BackColor;
                menuFontEd.ForeColor = bgImgFileEd.ForeColor;

                optionTab.SendToBack();
                languageCb.LoadData();
                this.myOnProcess += new onProcess(ProcessHandler);
                this.myStatusStrip.Visible = true;
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("option");

            //investment
            investmentPg.Text = Languages.Libs.GetString("investment");
            totalCapitalLbl.Text = Languages.Libs.GetString("totalCapital");
            maxBuyAmtPercLbl.Text = Languages.Libs.GetString("maxBuyAmtPercent");
            maxBuyAmtPercLbl2.Text = Languages.Libs.GetString("totalAmt");
            qtyReducePercLbl.Text = Languages.Libs.GetString("maxQtyReducePercent");
            qtyAccumulatePercLbl.Text = Languages.Libs.GetString("maxQtyAccumulatePercent");
            maxBuyQtyPercLbl.Text = Languages.Libs.GetString("maxBuyQtyPercent");

            //Color
            colorPg.Text = Languages.Libs.GetString("color");
            foreColorLbl.Text = Languages.Libs.GetString("foreground");
            backColorLbl.Text = Languages.Libs.GetString("background");
            colorPg.Text = Languages.Libs.GetString("color");
            colorIncreaseLbl.Text = Languages.Libs.GetString("increase");
            colorDecreaseLbl.Text = Languages.Libs.GetString("decrease");
            colorNotChangeLbl.Text = Languages.Libs.GetString("notChange");

            //Format
            formatPg.Text = Languages.Libs.GetString("format");
            generalAmtMaskLbl.Text = Languages.Libs.GetString("generalAmtMask");
            localAmtMaskLbl.Text = Languages.Libs.GetString("localAmtMask");
            foreignAmtMaskLbl.Text = Languages.Libs.GetString("foreignAmtMask");
            qtyMaskLbl.Text = Languages.Libs.GetString("qtyMask");
            priceMaskLbl.Text = Languages.Libs.GetString("priceMask");
            percentMaskLbl.Text = Languages.Libs.GetString("percentMask");

            //Apearance
            appearancePg.Text = Languages.Libs.GetString("appearance");
            bgImgFileLbl.Text = Languages.Libs.GetString("background");
            iconImgFileLbl.Text = Languages.Libs.GetString("icon");
            logoImgFileLbl1.Text = Languages.Libs.GetString("logo") + " 1";
            logoImgFileLbl2.Text = Languages.Libs.GetString("logo") + " 2";
            
            mainFontLbl.Text = Languages.Libs.GetString("mainFont");
            menuFontLbl.Text = Languages.Libs.GetString("menuFont");

            //System
            systemPg.Text = Languages.Libs.GetString("system");
            languageLbl.Text = Languages.Libs.GetString("language");
            timeServerLbl.Text = Languages.Libs.GetString("timeServer");
            autoRefreshTextLbl.Text = " ("+Settings.sysGlobal.RefreshDataInSecs.ToString()+ " "+ Languages.Libs.GetString("seconds")+" )";

            autoRefreshChk.Text = Languages.Libs.GetString("autoRefresh");
        }
        public static sysOptionLocal GetForm(string formName)
        {
            string cacheKey = typeof(sysOptionLocal).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            sysOptionLocal form = (sysOptionLocal)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new sysOptionLocal();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
        static Font mainFont=Settings.sysFontMain, menuFont=Settings.sysFontMenu;

        protected override bool LoadConfigure()
        {
            //investment
            totalCapitalEd.Value = Settings.sysStockTotalCapAmt;
            maxBuyAmtPercEd.Value = Settings.sysStockMaxBuyAmtPerc;
            qtyAccumulatePercEd.Value = Settings.sysStockAccumulateQtyPerc;
            qtyReducePercEd.Value = Settings.sysStockReduceQtyPerc;
            maxBuyQtyPercEd.Value = Settings.sysStockMaxBuyQtyPerc;

            //Format
            generalAmtMaskEd.Text = Settings.sysMaskGeneralValue;
            localAmtMaskEd.Text = Settings.sysMaskLocalAmt;
            foreignAmtMaskEd.Text = Settings.sysMaskForeignAmt;
            qtyMaskEd.Text = Settings.sysMaskQty;
            priceMaskEd.Text = Settings.sysMaskPrice;
            percentMaskEd.Text = Settings.sysMaskPercent;

            //Color
            fgColorDecreaseCb.Color = Settings.sysPriceColor_Decrease_FG;
            bgColorDecreaseCb.Color = Settings.sysPriceColor_Decrease_BG;
            bgColorIncreaseCb.Color = Settings.sysPriceColor_Increase_BG;
            fgColorIncreaseCb.Color = Settings.sysPriceColor_Increase_FG;
            bgColorNotChangeCb.Color = Settings.sysPriceColor_NotChange_BG;
            fgColorNotChangeCb.Color = Settings.sysPriceColor_NotChange_FG;
            
            //Appearance
            this.logoImgFileEd1.Text = common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathCompanyLogo1);
            this.logoImgFileEd2.Text = common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathCompanyLogo2);
            this.iconImgFileEd.Text = common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathIcon);
            this.bgImgFileEd.Text = common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathBackGround);

            mainFont = Settings.sysFontMain;
            this.mainFontEd.Text = mainFont.Name;

            menuFont = Settings.sysFontMenu;
            this.menuFontEd.Text = menuFont.Name;

            //System
            autoRefreshChk.Checked = Settings.sysAutoRefreshData;
            timeServerEd.Text = Settings.sysTimeServer;
            languageCb.myValue = Settings.sysLanguage;
            return true;
        }
        // Do not use SaveConfigure because it always run when the form is closed.
        // But heare we only want settings to be saves when Save is clicked
        protected bool SaveSettings()
        {
            //investment
            Settings.sysStockTotalCapAmt = totalCapitalEd.Value;
            Settings.sysStockMaxBuyAmtPerc = maxBuyAmtPercEd.Value;
            Settings.sysStockAccumulateQtyPerc = qtyAccumulatePercEd.Value;
            Settings.sysStockReduceQtyPerc = qtyReducePercEd.Value;
            Settings.sysStockMaxBuyQtyPerc = maxBuyQtyPercEd.Value;

            //Format
            Settings.sysMaskGeneralValue = generalAmtMaskEd.Text;
            Settings.sysMaskLocalAmt = localAmtMaskEd.Text;
            Settings.sysMaskForeignAmt = foreignAmtMaskEd.Text;
            Settings.sysMaskQty = qtyMaskEd.Text;
            Settings.sysMaskPrice = priceMaskEd.Text;
            Settings.sysMaskPercent = percentMaskEd.Text;

            //Color
            Settings.sysPriceColor_Decrease_BG = bgColorDecreaseCb.Color;
            Settings.sysPriceColor_Decrease_FG = fgColorDecreaseCb.Color;

            Settings.sysPriceColor_Increase_BG = bgColorIncreaseCb.Color;
            Settings.sysPriceColor_Increase_FG = fgColorIncreaseCb.Color;

            Settings.sysPriceColor_NotChange_BG = bgColorNotChangeCb.Color;
            Settings.sysPriceColor_NotChange_FG = fgColorNotChangeCb.Color;

            // Appearance
            Settings.sysImgFilePathIcon = this.iconImgFileEd.Text.Trim();
            Settings.sysImgFilePathBackGround = this.bgImgFileEd.Text.Trim();
            Settings.sysImgFilePathCompanyLogo1 = this.logoImgFileEd1.Text.Trim();
            Settings.sysImgFilePathCompanyLogo2 = this.logoImgFileEd2.Text.Trim();
            Settings.sysFontMain = mainFont;
            Settings.sysFontMenu = menuFont;

            //System
            Settings.sysLanguage  = languageCb.myValue;
            Settings.sysTimeServer = timeServerEd.Text;
            Settings.sysAutoRefreshData = autoRefreshChk.Checked;

            bool retVal = true;
            if (!application.Configuration.Save_Local_Settings()) retVal = false;
            if (!application.Configuration.Save_Local_UserSettings_SYSTEM1()) retVal = false;
            if (!application.Configuration.Save_Local_UserSettings_SYSTEM2()) retVal = false;
            if (retVal)
            {
                this.ShowMessage(Languages.Libs.GetString("dataSaved"));
                return true;
            }
            return false;
        }

        protected override bool BeforeAcceptProcess()
        {
            bool retVal = true;
            ClearNotifyError();
            if (totalCapitalEd.Value <= 0)
            {
                NotifyError(totalCapitalEd);
                retVal = false;
            }
            if (maxBuyAmtPercEd.Value <= 0)
            {
                NotifyError(maxBuyAmtPercEd);
                retVal = false;
            }

            if (qtyAccumulatePercEd.Value <= 0)
            {
                NotifyError(qtyAccumulatePercEd);
                retVal = false;
            }

            if (qtyReducePercEd.Value <= 0)
            {
                NotifyError(qtyReducePercEd);
                retVal = false;
            }
            if (maxBuyQtyPercEd.Value <= 0)
            {
                NotifyError(maxBuyQtyPercEd);
                retVal = false;
            }
            return retVal;
        }
        private void ProcessHandler(object sender,common.baseDialogEvent e)
        {
            try
            {
                if (e.isCloseClick) return;
                SaveSettings();
                this.Close();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private string SelectImgFile(string extFilter)
        {
            openFileDialog.Filter = extFilter;
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        private void iconImgFileEd_DoubleClick(object sender, EventArgs e)
        {
            ((common.controls.baseTextBox)sender).Text = SelectImgFile("Icon(*.ico)|*.ico;| Tat ca(*.*)|*.*");
        }

        private void bgImgFileEd_DoubleClick(object sender, EventArgs e)
        {
            ((common.controls.baseTextBox)sender).Text = SelectImgFile("JPEG (*.JPG,*.JPEG)|*.JPG;*.JPEG|GIF(*.GIF)|*.GIF|Tat ca(*.*)|*.*");
        }

        private void logoImgFileEd_DoubleClick(object sender, EventArgs e)
        {
            bgImgFileEd_DoubleClick(sender, e);
        }

        private void logoImgFileEd2_DoubleClick(object sender, EventArgs e)
        {
            bgImgFileEd_DoubleClick(sender, e);
        }

        private void mainFontBtn_Click(object sender, EventArgs e)
        {
            fontDialog.Font = mainFont;
            if (fontDialog.ShowDialog() != DialogResult.OK) return;
            mainFont = fontDialog.Font;
            mainFontEd.Text = fontDialog.Font.Name;
        }
        private void menuFontBtn_Click(object sender, EventArgs e)
        {
            fontDialog.Font = menuFont;
            if (fontDialog.ShowDialog() != DialogResult.OK) return;
            menuFont = fontDialog.Font;
            menuFontEd.Text = fontDialog.Font.Name;
        }
   }    
}