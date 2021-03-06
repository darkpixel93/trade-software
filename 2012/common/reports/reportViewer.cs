using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace common.reports
{
    public partial class reportViewerForm : Form
    {
        public static string[] repoHeaders = new string[10];
        protected int nCopies=1,startPage=0,endPage=0;

        CrystalDecisions.Shared.ParameterValues pvCollection = new CrystalDecisions.Shared.ParameterValues();
        CrystalDecisions.Shared.ParameterDiscreteValue pdvHeader = new CrystalDecisions.Shared.ParameterDiscreteValue();

        public reportViewerForm()
        {
            InitializeComponent();
        }

        public void ShowReport(object myReport)
        {
            ShowReport(myReport, true);
        }

        public void ShowReport(object myReport, bool preview)
        {
            ShowReport(myReport, preview, null); 
        }

        public void ShowReport(object myReport, bool preview,string printerName)
        {
            try
            {
                if (printerName != null) ((ReportDocument)myReport).PrintOptions.PrinterName = printerName;
                if (!preview)
                {
                    ((ReportDocument)myReport).PrintToPrinter(this.nCopies, false, this.startPage, this.endPage);
                }
                else
                {
                    //reportViewer is the name of the Viewer (set by Name property)
                    reportViewer.ReportSource = myReport;
                    this.ShowDialog();
                }
            }
            catch (Exception er)
            {
                common.sysLibs.ShowErrorMessage(er.ToString());
            }
        }


        public void SetPrintOptions(int nCopies,int startPage,int endPage)
        {
            this.nCopies = nCopies; 
            this.startPage=startPage; this.endPage=endPage;
        }

        public void SetPrintOptions()
        {
            this.nCopies=1; this.startPage=0; this.endPage=0;
        }

        public void SetReportPara(CrystalDecisions.Shared.ParameterFields paraDef, string[] repoTitles, string prefix)
        {
            CrystalDecisions.Shared.ParameterValues pvCollection = new CrystalDecisions.Shared.ParameterValues();
            CrystalDecisions.Shared.ParameterDiscreteValue pdvHeader = new CrystalDecisions.Shared.ParameterDiscreteValue();
            pvCollection.Clear();
            //Title 
            string tmp;
            for (int idx = 0; idx < repoTitles.Length; idx++)
            {
                tmp = prefix + idx.ToString().Trim();
                if (paraDef[tmp] != null && repoTitles[idx] != null)
                {
                    pdvHeader.Value = repoTitles[idx]; pvCollection.Add(pdvHeader);
                    paraDef[tmp].CurrentValues = pvCollection;
                }
            }
        }
 

    }
}