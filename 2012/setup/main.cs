using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using commonTypes;
using commonClass;

namespace setup
{
    //public partial class main : baseClass.forms.baseApplication
    public partial class main : common.forms.baseApplication
    {
        //private bool fullMode = false;
        public main()
        {
            try
            {
                InitializeComponent();
                this.loginRequired = false;
            }
            catch (Exception er)
            {
                common.system.ShowErrorMessage(er.Message);
            }
        }

        protected override bool LoadAppConfig()
        {
            //Product code and owner
            common.Settings.sysProductCode = "FMSETUP";
            common.Settings.sysProductOwner = Consts.constProductOwner;
            

            //Consider as super admin login
            commonClass.SysLibs.sysLoginAccount = Settings.sysSuperAdminName;
            //Turn off debug mode to ensure that users cannot bypass some system check
            common.Settings.sysDebugMode = false;

            //common.Settings.sysConfigFile = this.myConfigFileName;
            //Encryption key should be set before the below commands
            common.configuration.withEncryption = true;
            common.configuration.withEncryption = true;

            //Image
            if (common.fileFuncs.FileExist( Settings.sysImgFilePathBackGround))
                this.BackgroundImage = common.images.LoadImage(Settings.sysImgFilePathBackGround);
            else this.BackgroundImage = null;
            if (common.fileFuncs.FileExist(Settings.sysImgFilePathIcon))
                this.Icon = common.images.LoadIcon(Settings.sysImgFilePathIcon);
            else this.Icon = null;
            return true;
        }
        protected override bool CheckLicense()
        {
            //system.sysCompanyName = "";
            //common.license.myLicenseItem lic;
            //string licFile = LicenseFileName();

            //if (common.fileFuncs.FileExist(licFile))
            //{
            //    lic = common.license.GetLicence(licFile);
            //    if ((lic != null) && (lic.productCode == common.Settings.sysProductCode) && common.license.isSerialOk(lic))
            //    {
            //        // Set the company name from licence file
            //        system.sysCompanyName = lic.companyName;
            //        this.fullMode = true;
            //    }
            //}
            return true;
        }
     
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form myForm = this.FindForm("workerEdit");
            //if (myForm == null || myForm.IsDisposed)
            //{
            //    myForm = new baseClass.workerList();
            //    myForm.Name = "workerEdit";
            //}
            //this.ShowForm(myForm);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kết thúc sử dụng chương trình", Consts.constApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("aboutBox");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new AboutBox();
                myForm.Name = "aboutBox";
            }
            this.ShowForm(myForm,false);
        }


        private void dbConfigMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("configure");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new forms.configure();
                ((forms.configure)myForm).SetTitle("TỆP CẤU HÌNH", "Tep cau hinh");
                myForm.Name = "configure";
            }
            this.ShowForm(myForm,true);
        }

        private void selectConfFileMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("configFile");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new setup.forms.selectConfigFile();
                ((setup.forms.selectConfigFile)myForm).SetTitle("CHỌN TỆP CẤU HÌNH", "Chon tep cau hinh");
                myForm.Name = "configFile";
            }
            this.ShowForm(myForm, true);
        }
    }
}