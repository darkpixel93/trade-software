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
    public partial class reportViewerExtForm : reportViewerForm
    {
        public bool isPrinted = false;
        private ReportDocument reportDoc = null;
        private DataTable reportData = null;
        public string exportFileName = "export";
        private bool previewMode = false;
       
        public reportViewerExtForm()
        {
            InitializeComponent();
        }
        public void SetReport(ReportDocument myReport, DataTable tbl, bool preview)
        {
            this.reportData = tbl;
            this.reportDoc = myReport; this.previewMode = preview;
            this.reportDoc.SetDataSource(tbl);
        }
        public void ShowReport()
        {
            try
            {
                this.isPrinted = false;
                if (!this.previewMode)
                {
                    reportDoc.PrintToPrinter(this.nCopies, false, this.startPage, this.endPage);
                    this.isPrinted = true;
                }
                else
                {
                    reportViewer.ReportSource = reportDoc;
                    this.ShowDialog();
                }
            }
            catch (Exception er)
            {
                common.sysLibs.ShowErrorMessage(er.ToString());
            }
        }

        private void Zoom()
        {
            int zoomLevel = 0;
            if (!int.TryParse(zoomLevelEd.Text, out zoomLevel)) return;
            reportViewer.Zoom(zoomLevel);
        }
        private void GoToPage()
        {
            int toPage = 0;
            if (!int.TryParse(toPageEd.Text, out toPage)) return;
            reportViewer.ShowNthPage(toPage);
        }

        #region event handler
        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                reportDoc.PrintToPrinter(this.nCopies, false, this.startPage, this.endPage);
                this.Hide();
                this.isPrinted = true;
            }
            catch (Exception er)
            {
                common.sysLibs.ShowErrorMessage(er.ToString());
            }
        }

        private void firstBtn_Click(object sender, EventArgs e)
        {
            reportViewer.ShowFirstPage();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            reportViewer.ShowPreviousPage();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            reportViewer.ShowNextPage();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            reportViewer.ShowLastPage();
        }

        private void zoomBtn_Click(object sender, EventArgs e)
        {
            Zoom(); 
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            if (reportDoc != null && (this.reportData != null))
            {
                string fileName;
                if (exportFileName != null) fileName = exportFileName;  else reportDoc.ToString();
                fileName = System.IO.Path.GetTempPath() + exportFileName.Trim() + ".xls";
                common.Export.ExportToExcel(reportData,fileName);
                common.sysLibs.ShowMessage("Đã xuất dữ liệu ra tệp " + fileName);
                return;
            }
            reportViewer.ExportReport();
        }

        private void zoomLevelEd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zoom();
        }

        private void toPageEd_Validated(object sender, EventArgs e)
        {
            GoToPage();
        }

        private void zoomLevelEd_Validated(object sender, EventArgs e)
        {
            Zoom();
        }

        private void gotoBtn_Click(object sender, EventArgs e)
        {
            GoToPage();
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            //reportViewer.FindForm(); 
        }
        #endregion

        private void printSetupBtn_Click(object sender, EventArgs e)
        {
            printDialog.ShowDialog();
            reportDoc.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
        }
    }
}