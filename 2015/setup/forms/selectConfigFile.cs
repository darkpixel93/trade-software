using System;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO; 
using System.Xml;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace setup.forms
{
    public partial class selectConfigFile : common.forms.baseForm
    {
        public selectConfigFile()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (this.openFileDialog.ShowDialog() != DialogResult.OK) return;
                fileConfEd.Text = this.openFileDialog.FileName;
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
                common.system.ShowMessage("Lưu dữ liệu gặp lỗi");
            }
        }

        private void checkConnBtn_Click(object sender, EventArgs e)
        {
            string saveConfFile  = common.Settings.sysConfigFile;
            common.Settings.sysConfigFile = fileConfEd.Text;
            try
            {
                common.dbConnectionInfo dbConInfo = common.configuration.GetDbConectionInfo();
                string tmp = common.database.BuidConnectionString(dbConInfo);
                string errorMsg = "";
                if (common.database.CheckDbConnection(tmp, out errorMsg))
                {
                    common.system.ShowMessage("Kết nối thành công đến máy chủ");
                }
                else
                {
                    common.system.ShowErrorMessage("Không thể kết nối đến máy chủ");
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally 
            {
                common.Settings.sysConfigFile = saveConfFile;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            common.Settings.sysConfigFile = fileConfEd.Text;
            databases.DbAccess.ClearDbConnection();
            this.Close();
        }      
    }
}