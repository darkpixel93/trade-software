using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace common.forms
{
    public partial class baseLicense : baseDialogForm
    {
        public delegate string CodeValidate(string code,bool showListIfNotfound);
        public CodeValidate myOnToCodeValidated = null;

        public baseLicense()
        {
            InitializeComponent();
            toDateEd.myDateTime = DateTime.Today.AddYears(5);
            this.myLicense.Clear();
            this.myStatusStrip.Visible = true;
        }

        public string myProductCode
        {
            get { return prodCodeEd.Text.Trim(); }
            set 
            { 
                prodCodeEd.Text = value;
            }
        }
        public string myVendorName
        {
            get { return vendorNameEd.Text.Trim(); }
            set
            {
                vendorNameEd.Text = value;
            }
        }

        protected license.myLicenseItem myLicense
        {
            get
            {
                license.myLicenseItem lic = new license.myLicenseItem();
                lic.prodVendorName = vendorNameEd.Text.Trim();
                lic.productCode = prodCodeEd.Text.Trim();
                lic.companyName = companyEd.Text.Trim();
                lic.address = addressEd.Text.Trim();
                lic.companyEmail = emailEd.Text.Trim();
                lic.phone = phoneEd.Text.Trim();
                lic.fax = faxEd.Text.Trim();
                lic.validToDate = toDateEd.myDateTime;
                lic.serialKey = serialEd.Text.Trim();
                return lic;
            }
            set
            {
                vendorNameEd.Text = value.prodVendorName;
                prodCodeEd.Text = value.productCode;
                companyEd.Text = value.companyName;
                addressEd.Text = value.address.Trim();
                emailEd.Text = value.companyEmail.Trim();
                phoneEd.Text = value.phone.Trim();
                faxEd.Text = value.fax.Trim();
                emailEd.Text = value.companyEmail;
                toDateEd.myDateTime = value.validToDate;
                serialEd.Text = value.serialKey;
            }
        }

        protected license.myLicenseItem GetLicence()
        {
            this.openFileDialog.DefaultExt = "Txt";
            this.openFileDialog.Filter = "Van ban(*.txt)|*.txt";
            this.openFileDialog.CheckPathExists = true;
            this.openFileDialog.AddExtension = true;
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Thu muc ?";
            if (this.openFileDialog.ShowDialog() != DialogResult.OK) return null;

            license.myLicenseItem lic = common.license.GetLicenceFromFile(this.openFileDialog.FileName);
            if (lic==null) common.sysLibs.ShowErrorMessage("Dữ liệu không hợp lệ.");
            return lic;
        }
        protected void LoadLicenceFromReg()
        {
            license.myLicenseItem lic = common.license.GetLicenceFromReg(this.myVendorName, this.myProductCode);
            if (lic==null || !common.license.LicenceIsOk(lic))
            {
                common.sysLibs.ShowErrorMessage("Bản quyền không hợp lệ.");
                return;
            }
            this.myLicense = lic;
        }
        protected void SaveLicenceToReg()
        {
            if (!common.license.LicenceIsOk(this.myLicense)) 
            {
                common.sysLibs.ShowErrorMessage("Bản quyền không hợp lệ.");
                return;
            }
            common.license.SaveLicenceToReg(this.myLicense);
        }
        protected void SaveLicence(license.myLicenseItem lic)
        {
            this.saveFileDialog.DefaultExt = "Txt";
            this.saveFileDialog.Filter = "Van ban(*.txt)|*.txt";
            this.saveFileDialog.CheckPathExists = true;
            this.saveFileDialog.AddExtension = true;
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.Title = "Thu muc luu ?";
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK) return;
            common.license.SaveLicence(lic, this.saveFileDialog.FileName);
            common.sysLibs.ShowMessage("Đã lưu ra tập tin : " + this.saveFileDialog.FileName);
        }
        protected bool GenerateLicence()
        {
            if (vendorNameEd.Text.Trim() == "")
            {
                common.sysLibs.ShowErrorMessage("Chưa nhập [Mã nhà sản xuất]"); vendorNameEd.Focus();
                return false;
            }
            if (prodCodeEd.Text.Trim() == "")
            {
                common.sysLibs.ShowErrorMessage("Chưa nhập [Mã sản phẩm]"); prodCodeEd.Focus();
                return false;
            }
            if (companyEd.Text.Trim() == "")
            {
                common.sysLibs.ShowErrorMessage("Chưa nhập [Công ty]"); companyEd.Focus();
                return false;
            }
            if (addressEd.Text.Trim() == "")
            {
                common.sysLibs.ShowErrorMessage("Chưa nhập [Địa chỉ]"); addressEd.Focus();
                return false;
            }
            if (emailEd.Text.Trim() == "")
            {
                common.sysLibs.ShowErrorMessage("Chưa nhập [Email]"); emailEd.Focus();
                return false;
            }
            DateTime dt = toDateEd.myDateTime;
            if (dt == common.Consts.constNullDate)
            {
                common.sysLibs.ShowErrorMessage("Ngày không hợp lệ"); toDateEd.Focus();
                return false;
            }
            serialEd.Text = common.license.MakeKey(prodCodeEd.Text, companyEd.Text, emailEd.Text, dt);
            this.ShowMessage("Đã tạo mã khóa"); 
            return false;
        }
    }
}

