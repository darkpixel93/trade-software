using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using commonTypes;

namespace baseClass.forms
{
    public partial class changePassword : baseDialogForm
    {
        public changePassword()
        {
            InitializeComponent();
            this.myStatusStrip.Visible = true;
            passwordMatchLbl.BackColor = common.Settings.sysColorHiLightBG1;
            //passwordMatchLbl.ForeColor = common.Settings.sysColorHiLightFG1;
            passwordMatchLbl.Text = "";
        }
        public string loginAccount
        {
            set 
            {
                this.loginEd.Text = value; 
            }
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("changePassword");
            this.loginLbl.Text  = Languages.Libs.GetString("account");
            this.oldPasswordLbl.Text = Languages.Libs.GetString("oldPassword");
            this.newPassword1Lbl.Text = Languages.Libs.GetString("password");
            this.newPassword2Lbl.Text = Languages.Libs.GetString("rePassword");
        }

        private void CheckPasswordStrenght()
        {
            common.Password.PasswordAttrib pwdAttrib = common.Password.GetPasswordAttrib(newPassword1Ed.Text.Trim());
            passStrenghtLbl.Text = pwdAttrib.ScoreText;
            passStrenghtLbl.ForeColor = pwdAttrib.TextForeColor;
            passStrenghtLbl.BackColor = pwdAttrib.TextBackColor;
        }
        private void CheckPasswordMatch()
        {
            this.passwordMatchLbl.Text = (newPassword1Ed.Text.Trim()  != newPassword2Ed.Text.Trim() ?
                Languages.Libs.GetString("notMatched") : Languages.Libs.GetString("matched"));
        }

        protected bool DataValid()
        {
            this.ShowMessage("");
            bool retVal = true;
            string loginName = this.loginEd.Text.Trim();
            string oldPassword = this.oldPasswordEd.Text.Trim();
            string newPassword1 = this.newPassword1Ed.Text;
            string newPassword2 = this.newPassword2Ed.Text;
            if (loginName == "")
            {
                NotifyError(newPassword1Lbl);
                retVal = false;
            }
            bool checkWeakPass = true;
            if (checkWeakPass && Settings.sysGlobal.UseStrongPassword)
            {
                common.Password.PasswordAttrib pwdAttrib = common.Password.GetPasswordAttrib(newPassword1Ed.Text.Trim());
                if (pwdAttrib.score != common.Password.PasswordScore.Strong && pwdAttrib.score != common.Password.PasswordScore.VeryStrong)
                {
                    this.ShowMessage(Languages.Libs.GetString("weakPassReEnter"));
                    NotifyError(newPassword1Ed);
                    checkWeakPass = false;
                    retVal = false;
                }
            }
            if (checkWeakPass && newPassword1Ed.Text.Trim().Length < Settings.sysGlobal.PasswordMinLen)
            {
                this.ShowMessage(Languages.Libs.GetString("weakPassReEnter"));
                NotifyError(newPassword1Lbl);
                retVal = false;
            }

            if (newPassword1 != newPassword2)
            {
                this.ShowMessage(Languages.Libs.GetString("passwordNotMatched"));
                NotifyError(newPassword1Lbl);
                NotifyError(newPassword2Lbl);
                retVal = false;
            }
            databases.baseDS.investorDataTable investorTbl = DataAccess.Libs.GetInvestor_ByAccount(loginName);
            if (investorTbl.Count == 0)
            {
                this.ShowMessage(String.Format(Languages.Libs.GetString("loginNotFount"), loginName)); 
                NotifyError(loginLbl);
                retVal = false;
            }
            else
            {
                if (oldPasswordEd.Enabled && oldPassword != investorTbl[0].password.Trim())
                {
                    NotifyError(oldPasswordLbl);
                    retVal = false;
                }
            }
            if (retVal)
            {
                investorTbl[0].password = this.newPassword1Ed.Text.Trim();
                DataAccess.Libs.UpdateData(investorTbl[0]);
                this.ShowMessage(Languages.Libs.GetString("dataSaved")); 
            }
            return retVal;
        }

        protected override bool BeforeAcceptProcess()
        {
            if (!base.BeforeAcceptProcess()) return false;
            if (this.myFormStatus.isCloseClick)
            {
                this.myFormStatus.acceptClose = true;
                return true;
            }
            return DataValid();
        }

        private void newPassword1Ed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckPasswordStrenght();
                CheckPasswordMatch();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void newPassword2Ed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckPasswordMatch();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}