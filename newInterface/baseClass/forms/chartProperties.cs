using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using commonTypes;

namespace baseClass.forms
{
    public partial class chartProperties : baseDialogForm  
    {
        public chartProperties()
        {
            try
            {
                InitializeComponent();
                this.myOnProcess += new onProcess(ProcessHandler);  
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("property");

            colorPg.Text = Languages.Libs.GetString("color");
            backgroundLbl.Text = Languages.Libs.GetString("background");
            foreGroundLbl.Text = Languages.Libs.GetString("foreground");
            gridLbl.Text = Languages.Libs.GetString("grid");
            barUpLbl.Text = Languages.Libs.GetString("barUp");
            barDnLbl.Text = Languages.Libs.GetString("barDn");

            bullCandleLbl.Text = Languages.Libs.GetString("bullCandle");
            bullBorderLbl.Text = Languages.Libs.GetString("bullBorder");

            bearCandleLbl.Text = Languages.Libs.GetString("bearCandle");
            bearBorderLbl.Text = Languages.Libs.GetString("bearBorder");

            lineGraphLbl.Text = Languages.Libs.GetString("lineGraph");
            volumeLbl.Text = Languages.Libs.GetString("volume");

            chartPg.Text = Languages.Libs.GetString("system");
            showGridChk.Text = Languages.Libs.GetString("showGrid");
            showVolumeChk.Text = Languages.Libs.GetString("showVolume");
            showDescriptionChk.Text = Languages.Libs.GetString("showDescription");
            showLegendChk.Text = Languages.Libs.GetString("showLegend");

            zoomRateLbl.Text = Languages.Libs.GetString("zoomRate");
            panRateLbl.Text = Languages.Libs.GetString("panRate");

            panMouseRateLbl.Text = Languages.Libs.GetString("mouseRate");
            movePerPanLbl.Text = Languages.Libs.GetString("movesPerPan");

            marginLbl.Text = Languages.Libs.GetString("margin");
            leftMarginLbl.Text = Languages.Libs.GetString("left");
            rightMarginLbl.Text = Languages.Libs.GetString("right");
            topMarginLbl.Text = Languages.Libs.GetString("top");
            bottomMarginLbl.Text = Languages.Libs.GetString("bottom");

            spaceLbl.Text = Languages.Libs.GetString("padding");
            leftSpaceLbl.Text = Languages.Libs.GetString("left");
            rightSpaceLbl.Text = Languages.Libs.GetString("right");
            topSpaceLbl.Text = Languages.Libs.GetString("top");
            bottomSpaceLbl.Text = Languages.Libs.GetString("bottom");
        }

        public static chartProperties GetForm(string formName)
        {
            string cacheKey = typeof(chartProperties).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            chartProperties form = (chartProperties)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new chartProperties();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        protected override bool LoadConfigure()
        {
            bgColorCb.Color = Settings.sysChartBgColor;
            fgColorCb.Color = Settings.sysChartFgColor;
            gridColorCb.Color = Settings.sysChartGridColor;

            volumesColorCb.Color = Settings.sysChartVolumesColor;
            lineCandleColorCb.Color = Settings.sysChartLineCandleColor;

            bearCandleColorCb.Color = Settings.sysChartBearCandleColor;
            bearBorderColorCb.Color = Settings.sysChartBearBorderColor;

            bullCandleColorCb.Color = Settings.sysChartBullCandleColor;
            bullBorderColorCb.Color = Settings.sysChartBullBorderColor;

            barDnColorCb.Color = Settings.sysChartBarDnColor;
            barUpColorCb.Color = Settings.sysChartBarUpColor;

            showDescriptionChk.Checked = Settings.sysChartShowDescription;
            showVolumeChk.Checked = Settings.sysChartShowVolume;
            showGridChk.Checked = Settings.sysChartShowGrid;
            showLegendChk.Checked = Settings.sysChartShowLegend;

            zoomPercEd.Value = Charts.Settings.sysZoom_Percent;
            zoomMinCountEd.Value = Charts.Settings.sysZoom_MinCount;

            panMouseRateEd.Value = Charts.Settings.sysPAN_MouseRate;
            panMoveMinCountEd.Value = Charts.Settings.sysPAN_MovePercent;
            panMoveMinCountEd.Value = Charts.Settings.sysPAN_MoveMinCount;

            leftMarginEd.Value =  Charts.Settings.sysChartMarginLEFT;
            rightMarginEd.Value = Charts.Settings.sysChartMarginRIGHT;
            topMarginEd.Value = Charts.Settings.sysChartMarginTOP;
            bottomMarginEd.Value = Charts.Settings.sysChartMarginBOT;

            rightSpaceEd.Value = Charts.Settings.sysViewSpaceAtRIGHT;
            leftSpaceEd.Value = Charts.Settings.sysViewSpaceAtLEFT;

            topSpaceEd.Value = Charts.Settings.sysViewSpaceAtTOP;
            bottomSpaceEd.Value = Charts.Settings.sysViewSpaceAtBOT;

            return true;
        }
        protected bool SaveSettings()
        {
            Settings.sysChartBgColor = bgColorCb.Color;
            Settings.sysChartFgColor = fgColorCb.Color;
            Settings.sysChartGridColor = gridColorCb.Color;

            Settings.sysChartVolumesColor = volumesColorCb.Color;
            Settings.sysChartLineCandleColor = lineCandleColorCb.Color;

            Settings.sysChartBearCandleColor = bearCandleColorCb.Color;
            Settings.sysChartBearBorderColor = bearBorderColorCb.Color;

            Settings.sysChartBullCandleColor = bullCandleColorCb.Color;
            Settings.sysChartBullBorderColor = bullBorderColorCb.Color;

            Settings.sysChartBarDnColor = barDnColorCb.Color;
            Settings.sysChartBarUpColor = barUpColorCb.Color;

            Settings.sysChartShowDescription = showDescriptionChk.Checked;
            Settings.sysChartShowVolume = showVolumeChk.Checked;
            Settings.sysChartShowGrid = showGridChk.Checked;
            Settings.sysChartShowLegend = showLegendChk.Checked;

            Charts.Settings.sysZoom_Percent = (int)zoomPercEd.Value;
            Charts.Settings.sysZoom_MinCount = (int)zoomMinCountEd.Value;

            Charts.Settings.sysPAN_MouseRate = (int)panMouseRateEd.Value;
            Charts.Settings.sysPAN_MovePercent = (int)panMovePercEd.Value;
            Charts.Settings.sysPAN_MoveMinCount = (int)panMoveMinCountEd.Value;

            Charts.Settings.sysChartMarginLEFT = (int)leftMarginEd.Value;
            Charts.Settings.sysChartMarginRIGHT = (int)rightMarginEd.Value;
            Charts.Settings.sysChartMarginTOP = (int)topMarginEd.Value;
            Charts.Settings.sysChartMarginBOT = (int)bottomMarginEd.Value;

            Charts.Settings.sysViewSpaceAtTOP = (int)topSpaceEd.Value;
            Charts.Settings.sysViewSpaceAtBOT = (int)bottomSpaceEd.Value;
            Charts.Settings.sysViewSpaceAtRIGHT = (int)rightSpaceEd.Value;
            Charts.Settings.sysViewSpaceAtLEFT = (int)leftSpaceEd.Value;

            return application.Configuration.Save_Local_UserSettings_CHART();
        }

        protected override bool BeforeAcceptProcess()
        {
            bool retVal = true;
            ClearNotifyError();
            return retVal;
        }
        private void ProcessHandler(object sender,common.baseDialogEvent e)
        {
            if (e.isCloseClick) return;
            myFormStatus.acceptClose = true;
            SaveSettings();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }
    }    
}