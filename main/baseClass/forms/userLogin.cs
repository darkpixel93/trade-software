using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass
{
    public partial class userLogin : common.forms.baseForm
    {
        private data.baseDS.investorDataTable investorTbl = new data.baseDS.investorDataTable();
        public bool isLoginOk = false;
        public userLogin()
        {
            InitializeComponent();
            this.myStatusStrip.Visible = false;
        }

        private void userLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.loginEd.Text = application.sysLibs.sysLoginName;
            }
            catch( Exception er)
            {
                common.system.ShowErrorMessage(er.Message.ToString()); 
            }
         }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                isLoginOk = false;
                if (DoLogin())
                {
                    isLoginOk = true;
                    this.Close();
                }
            }
            catch (Exception er)
            {
                common.system.ShowErrorMessage(er.Message.ToString());
            }
        }

        public  bool DoLogin()
        {
            string account = this.loginEd.Text.Trim();
            string password = this.passwordEd.Text.Trim();
            if (account == "")
            {
                common.system.ShowErrorMessage("Chưa nhập tài khoản đăng nhập.");
                return false;
            }
            investorTbl.Clear();
            application.dataLibs.LoadData(investorTbl, account);
            if (investorTbl.Count==0)
            {
                common.system.ShowErrorMessage("Đăng nhập không hợp lệ.Xin vui lòng kiểm tra lại [Tài khoản] và [Mật khẩu]");
                return false;
            }
            if (investorTbl[0].password.Trim() != password.Trim())
            {
                common.system.ShowErrorMessage("Đăng nhập không hợp lệ.Xin vui lòng kiểm tra lại [Tài khoản] và [Mật khẩu]");
                return false;
            }
            if (!application.sysLibs.isSupperAdminLogin(investorTbl[0].account) && row.expireDate < application.sysLibs.GetServerDateTime())
            {
                common.system.ShowErrorMessage("Tài khỏan đã hết hạn sử dụng.");
                return false;
            }
            application.sysLibs.sysLoginName = investorTbl[0].account.Trim();
            application.sysLibs.sysLoginInterestedBizSectors = common.system.String2Collection(investorTbl[0].interestedSector,
                                                                                               common.settings.sysListSeparatorPrefix,
                                                                                               common.settings.sysListSeparatorPostfix);
            application.sysLibs.sysLoginInterestedStockCode = common.system.String2Collection(investorTbl[0].interestedStock,
                                                                                               common.settings.sysListSeparatorPrefix,
                                                                                               common.settings.sysListSeparatorPostfix);
            application.sysLibs.sysLoginInterestedStrategy = common.system.String2Collection(investorTbl[0].requiredStrategy,
                                                                                               common.settings.sysListSeparatorPrefix,
                                                                                               common.settings.sysListSeparatorPostfix);
           
            return true;
        }

        private void userLogin_Activated(object sender, EventArgs e)
        {
            if (this.loginEd.Text.Trim() != "") this.passwordEd.Focus();
        }
    }
}