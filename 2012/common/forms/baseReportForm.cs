using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace common.forms
{
    public partial class baseReportForm : forms.baseForm
    {
        public bool ShowReport(string[] reportTitle, string[] reportData, DataTable dataTbl,
                                CrystalDecisions.CrystalReports.Engine.ReportClass myReport)
        {
            try
            {
                //==============================
                //  Make report
                //==============================
                if (this.ExportOutput != Export.ExportFormat.None)
                    this.ExportData(dataTbl, this.ExportOutput);
                else
                {
                    myReport.SetDataSource(dataTbl);
                    reportViewer.SetReportPara(myReport.ParameterFields, reportTitle, "reportTitle");
                    reportViewer.SetReportPara(myReport.ParameterFields, reportData, "reportData");
                    reportViewer.ShowReport(myReport);
                    myReport.Dispose();
                }
            }
            catch (Exception er)
            {
                common.errorHandler.lastErrorMessage = er.Message.ToString();
                return false;
            }
            return true;
        }
        
       
        public baseReportForm()
        {
            InitializeComponent();
            this.exportCbMenuItem.SelectedIndex = 1;
        }

        public Export.ExportFormat ExportOutput
        {
            get
            {
                switch (this.exportCbMenuItem.SelectedIndex)
                {
                    case 0: return Export.ExportFormat.Excel;
                    //case 1: return Export.ExportFormat.CSV;
                    //case 2: return Export.ExportFormat.XML;
                }
                return Export.ExportFormat.None;
            }
        }

        protected virtual void ExportData(DataTable dataTbl, Export.ExportFormat outputFormat)
        {
            ExportData(dataTbl, outputFormat,null,null);
        }
        protected virtual void ExportData(DataTable dataTbl, Export.ExportFormat outputFormat, int[]  columnList)
        {
            ExportData(dataTbl, outputFormat, columnList, null);
        }
       
        protected virtual void ExportData(DataTable dataTbl, Export.ExportFormat outputFormat,int[] columnList,string[] headerList)
        {
            try
            {
                switch (outputFormat)
                {
                    case Export.ExportFormat.Excel:
                        this.saveFileDialog.DefaultExt = "xls";
                        this.saveFileDialog.Filter = "Microsoft Excel(*.xls)|*.xls";
                        break;
                    case Export.ExportFormat.CSV:
                        this.saveFileDialog.DefaultExt = "csv";
                        this.saveFileDialog.Filter = "Van ban(*.csv)|*.csv";
                        break;
                    case Export.ExportFormat.XML:
                        this.saveFileDialog.DefaultExt = "html";
                        this.saveFileDialog.Filter = "Trang web(*.html)|*.html";
                        break;
                    default: return;
                }
                this.saveFileDialog.CheckPathExists = true;
                this.saveFileDialog.AddExtension = true;
                this.saveFileDialog.RestoreDirectory = true;
                this.saveFileDialog.Title = "Thu muc luu tap tin ?";
                if (this.saveFileDialog.ShowDialog() != DialogResult.OK) return;

                // Get the datatable to export			
                DataTable dtTbl = dataTbl.Copy();
                common.Export.ExportToExcel(dtTbl, this.saveFileDialog.FileName,columnList,headerList);
                dtTbl.Dispose();
                common.sysLibs.ShowMessage("Đã xuất dữ liệu ra tập tin : " + this.saveFileDialog.FileName);
            }
            catch(Exception er) 
            {
                common.sysLibs.ShowMessage("Xuất dữ liệu gặp lỗi.\n\r\n\r" + er.Message.ToString());
            }
        }

        private void baseReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reportViewer != null && !reportViewer.IsDisposed) reportViewer.Dispose(); 
        }

        private void printerMenuItem_Click(object sender, EventArgs e)
        {
            printDialog.ShowDialog(); 
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}

