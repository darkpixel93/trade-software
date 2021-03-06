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
            bearCandleLbl.Text = Languages.Libs.GetString("bearCandle");
            lineGraphLbl.Text = Languages.Libs.GetString("lineGraph");
            volumeLbl.Text = Languages.Libs.GetString("volume");

            chartPg.Text = Languages.Libs.GetString("system");
            showGridChk.Text = Languages.Libs.GetString("showGrid");
            showVolumeChk.Text = Languages.Libs.GetString("showVolume");
            showDescriptionChk.Text = Languages.Libs.GetString("showDescription");
            showLegendChk.Text = Languages.Libs.GetString("showLegend");
            zoomRateLbl.Text = Languages.Libs.GetString("zoomRate");
            panRateLbl.Text = Languages.Libs.GetString("panRate");
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
            bgColorCb.Color = commonClass.Settings.sysChartBgColor;
            fgColorCb.Color = commonClass.Settings.sysChartFgColor;
            gridColorCb.Color = commonClass.Settings.sysChartGridColor;

            volumesColorCb.Color = commonClass.Settings.sysChartVolumesColor;
            lineCandleColorCb.Color = commonClass.Settings.sysChartLineCandleColor;
            bearCandleColorCb.Color = commonClass.Settings.sysChartBearCandleColor;
            bullCandleColorCb.Color = commonClass.Settings.sysChartBullCandleColor;
            barDnColorCb.Color = commonClass.Settings.sysChartBarDnColor;
            barUpColorCb.Color = commonClass.Settings.sysChartBarUpColor;

            showDescriptionChk.Checked = commonClass.Settings.sysChartShowDescription;
            showVolumeChk.Checked = commonClass.Settings.sysChartShowVolume;
            showGridChk.Checked = commonClass.Settings.sysChartShowGrid;
            showLegendChk.Checked = commonClass.Settings.sysChartShowLegend;

            zoomRateEd.Value = Charts.Settings.sysZoomRate;
            PAN_MouseRateEd.Value = Charts.Settings.sysPAN_MouseRate;
            PAN_MoveCountEd.Value = Charts.Settings.sysPAN_MoveCount;

            spaceAtLeftEd.Value =  Charts.Settings.sysViewSpaceAtLEFT;
            spaceAtRightEd.Value = Charts.Settings.sysViewSpaceAtRIGHT;

            return true;
        }
        protected override bool SaveConfigure()
        {
            commonClass.Settings.sysChartBgColor = bgColorCb.Color;
            commonClass.Settings.sysChartFgColor = fgColorCb.Color;
            commonClass.Settings.sysChartGridColor = gridColorCb.Color;

            commonClass.Settings.sysChartVolumesColor = volumesColorCb.Color;
            commonClass.Settings.sysChartLineCandleColor = lineCandleColorCb.Color;
            commonClass.Settings.sysChartBearCandleColor = bearCandleColorCb.Color;
            commonClass.Settings.sysChartBullCandleColor = bullCandleColorCb.Color;
            commonClass.Settings.sysChartBarDnColor = barDnColorCb.Color;
            commonClass.Settings.sysChartBarUpColor = barUpColorCb.Color;

            commonClass.Settings.sysChartShowDescription = showDescriptionChk.Checked;
            commonClass.Settings.sysChartShowVolume = showVolumeChk.Checked;
            commonClass.Settings.sysChartShowGrid = showGridChk.Checked;
            commonClass.Settings.sysChartShowLegend = showLegendChk.Checked;

            Charts.Settings.sysZoomRate = (int)zoomRateEd.Value;
            Charts.Settings.sysPAN_MouseRate = (int)PAN_MouseRateEd.Value;
            Charts.Settings.sysPAN_MoveCount = (int)PAN_MoveCountEd.Value;

            Charts.Settings.sysViewSpaceAtLEFT = (int)spaceAtLeftEd.Value;
            Charts.Settings.sysViewSpaceAtRIGHT = (int)spaceAtRightEd.Value;

            application.Configuration.Save_Local_Settings_CHART();
            return true;
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
            SaveConfigure();
        }
    }    
}