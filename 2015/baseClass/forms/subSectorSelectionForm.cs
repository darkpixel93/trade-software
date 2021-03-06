using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;


namespace baseClass.forms
{
    public partial class subSectorSelectionForm : common.forms.baseListSelection  
    {
        public override StringCollection mySelectedCodes
        {
            get
            {
                if (!this.myFormStatus.isCloseClick) return codeSelection.myCheckedValues;
                return null;
            }
            set
            {
                codeSelection.myCheckedValues = value;
            }
        }
        public subSectorSelectionForm()
        {
            try
            {
                InitializeComponent();
                codeSelection.LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            codeSelection.SetLanguage();
        }
    }
}