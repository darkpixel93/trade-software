using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ZedGraph;
using application;

namespace test
{
    public partial class test : baseClass.forms.baseGraphForm 
    {
        Indicators.Data myData = null; 
        
        private const string constPricePaneName = "pricePane", constVolumePaneName = "volume";
        private const byte constPricePaneWeight = 100;
        public test()
        {
            try
            {
                InitializeComponent();
                
                //For testing
                LoadAppConfig();

                cbStrategy.LoadData();
                timeScaleCb.LoadData();

                cbStrategy.SelectFirstIfNull();
                timeScaleCb.SelectFirstIfNull();

                this.pricePane = CreatePane(constPricePaneName,constPricePaneWeight);
                pricePane.haveCloseButton = false;
                //this.volumePane = CreateVolumePane();
                //volumePane.haveCloseButton = true;

                mainContainer.Location = new Point(0, toolBarPnl.Location.Y + toolBarPnl.Height);
                
                
                mainContainer.ArrangeChildren();

                Init();

                //For testing
                //data.baseDS.stockCodeExtDataTable tbl = new data.baseDS.stockCodeExtDataTable();
                //myStockCodeRow = application.dataLibs.GetStockData("SSI");
                //ShowForm(myStockCodeRow);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private baseClass.controls.graphPane CreateVolumePane()
        {
            baseClass.controls.graphPane myPane = CreatePane(constVolumePaneName, 0);
            myPane.Height = this.ClientRectangle.Height / 3;
            myPane.mySizingOptions = common.control.basePanel.SizingOptions.Top;
            myPane.minSizingHeight = 50;
            return myPane;
        }

        private bool LoadAppConfig()
        {
            data.system.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";

            application.sysLibs.sysProductOwner = application.Consts.constProductOwner;
            application.sysLibs.sysProductCode = application.Consts.constProductCode;

            //common.settings.sysConfigFile = common.system.myConfigFileName;
            application.configuration.withEncryption = true;
            application.configuration.Load_User_Envir();
            
            //Check data connection after db-setting were loaded
            application.configuration.Load_Sys_Settings();
            application.configuration.Load_User_Config(application.sysLibs.sysUseLocalConfigFile);
            
            application.sysLibs.SetAppEnvironment();
            return true;
        }

        protected baseClass.controls.graphPane pricePane = null;
        //protected baseClass.controls.graphPane volumePane = null;
        //protected baseClass.controls.graphPane newPane = null;
        
        protected enum chartTypeEnum : byte {Line, Bar,CandelStick};
        protected chartTypeEnum myChartType
        {
            get
            {
                if (chartBarBtn.isDownState) return chartTypeEnum.Bar;
                if (chartCandelBtn.isDownState) return chartTypeEnum.CandelStick;
                return chartTypeEnum.Line;
            }
            set
            {
                switch (value)
                {
                    case chartTypeEnum.Bar:
                         chartBarBtn.isDownState = true;
                         chartLineBtn.isDownState = false;
                         chartCandelBtn.isDownState = false;
                         break;
                    case chartTypeEnum.CandelStick:
                         chartBarBtn.isDownState = false;
                         chartLineBtn.isDownState = false;
                         chartCandelBtn.isDownState = true;
                         break;
                    default:
                         chartBarBtn.isDownState = false;
                         chartLineBtn.isDownState = true;
                         chartCandelBtn.isDownState = false;
                         break;
                }
            }

        }

        protected data.baseDS.stockCodeExtRow myStockCodeRow = null;

        private void Init()
        {
            //Test
            this.myStockCodeRow = application.dataLibs.GetStockData("SSI");

            myData = new Indicators.Data(new data.baseDS.priceDataDataTable());
            LoadData();
            PlotChart();
        }
        private void LoadData()
        {
            myData.DataTimeScale = timeScaleCb.myValue;
            myData.DataEndDate = DateTime.Today;
            myData.DataStartDate = DateTime.Today.AddYears(-2);

            myData.DataStartDate = myChartDataOptionForm.frDate;
            myData.DataEndDate = myChartDataOptionForm.toDate;

            myData.DataStockCode = this.myStockCodeRow.code;
            myData.Reload();

            //DataTable tbl = common.system.MakeTable(myData.Close.Values, myData.DateTime.Values);
            //common.Export.ExportToExcel(tbl,@"d:\tmp2.xls");
            PlotChart();
        }

       
        private void PlotChart()
        {
            pricePane.RemoveAllCurves();
            chartLibs.PlotChartBar(pricePane.myGraphPane, myData.DateTime, myData.Close, "Bar", Color.Blue, Color.Black, 1);

            pricePane.myGraphPane.XAxis.Type = AxisType.DateAsOrdinal;
            pricePane.PlotGraph();
        }
        private baseClass.forms.baseChartDataOptions _myChartDataOptionForm = null;
        protected baseClass.forms.baseChartDataOptions myChartDataOptionForm
        {
            get
            {
                if (_myChartDataOptionForm == null)
                {
                    _myChartDataOptionForm = CreateChartDataOptionForm();
                    _myChartDataOptionForm.InitData();
                    _myChartDataOptionForm.myOnProcess += new common.forms.baseDialogForm.onProcess(ChartDataOptionHandler);
                }
                return _myChartDataOptionForm;
            }
        }
        protected virtual baseClass.forms.baseChartDataOptions CreateChartDataOptionForm()
        {
            return new baseClass.forms.baseChartDataOptions();
        }


        private bool Validate_StockChart()
        {
            bool retVal = true;
            ClearNotifyError();
            if (this.myStockCodeRow == null)
            {
                retVal = false;
            }
            if (!myChartDataOptionForm.GetDate())
            {
                retVal = false;
            }
            return retVal;
        }
        private void ChartDataOptionHandler(object sender, common.baseDialogEvent e)
        {
            if (e != null && e.isCloseClick) return;
            if (!Validate_StockChart()) return;
            LoadData();
            PlotChart();
        }

        private void dataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                myChartDataOptionForm.ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }            
        }
    }
}