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

namespace baseClass.forms
{
    /// <summary>
    /// Form for the configuration
    /// </summary>
    public partial class configure : baseForm
    {
        public configure()
        {
            try
            {
                InitializeComponent();
                this.LogAccess = false;
                configureTab.SendToBack();
                fShowError = false;
                toolBarPnl.BorderStyle = BorderStyle.None;
                errorMsgEd.Location = new Point(0, toolBarPnl.Location.Y + toolBarPnl.Height);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            wsConnection.SetLanguage();
            this.Text = Languages.Libs.GetString("configure");

            connectionPg.Text = Languages.Libs.GetString("connection");
            checkConnBtn.Text = Languages.Libs.GetString("test");
            
            saveBtn.Text = Languages.Libs.GetString("save");
            exitBtn.Text = Languages.Libs.GetString("close");
        }
        bool fShowError
        {
            get 
            {
                return errorMsgEd.Visible;
            }
            set 
            {
                errorMsgEd.Visible = value;
                errorMsgEd.BringToFront();
                errorMsgEd.Height = 150;
                if (value) configureTab.Height = errorMsgEd.Location.Y + errorMsgEd.Height;
                else configureTab.Height = toolBarPnl.Location.Y + toolBarPnl.Height + SystemInformation.CaptionHeight + 3;
                this.Height = configureTab.Height + configureTab.Location.Y + 2 * SystemInformation.CaptionHeight+5;
            }
        }

        private void ReadConfiguration()
        {
            wsConnection.myInfo = common.configuration.GetWebServiceInfo();
        }

        private bool SaveConfiguration()
        {
            //Save configuration
            return  application.Configuration.Save_Local_Settings() &&
                    common.configuration.SaveWebServiceInfo(wsConnection.myInfo);
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if(SaveConfiguration())  this.ShowMessage(Languages.Libs.GetString("dataSaved"));
                this.Close();
            }
            catch(Exception er)
            {
                this.ShowError(er);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void configure_Load(object sender, EventArgs e)
        {
            try
            {
                ReadConfiguration();
                wsConnection.LockWebServiceSettings(!commonClass.SysLibs.isSystemUserLogin());
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }            
        }

        private void checkConnBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (wsConnection.myInfo == null)
                {
                    return;
                }
                toolBarPnl.Enabled = false;
                string errorMsg = "";
                if (DataAccess.Libs.TestConnection(wsConnection.myInfo, out errorMsg))
                {
                    this.ShowMessage(Languages.Libs.GetString("connectionOk"));
                    errorMsgEd.Text = "";
                    fShowError = false;
                }
                else
                {
                    this.ShowMessage(Languages.Libs.GetString("connectionFail"));
                    errorMsgEd.Text = errorMsg;
                    fShowError = true;
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                toolBarPnl.Enabled = true;
            }
        }

        private bool errorPnl_myOnClosing(object sender)
        {
            fShowError = false;
            return true;
        }
    }
}