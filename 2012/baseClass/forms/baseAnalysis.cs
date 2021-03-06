using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; 

namespace baseClass.forms
{
    public partial class baseAnalysis : common.forms.baseForm
    {
        private baseEstimateAdvice _myAdviceEstimateForm = null;
        protected baseEstimateAdvice myAdviceEstimateForm
        {
            get
            {
                if (_myAdviceEstimateForm == null || _myAdviceEstimateForm.IsDisposed)
                {
                    _myAdviceEstimateForm = new baseEstimateAdvice();
                }
                return _myAdviceEstimateForm;
            }
        }

        public baseAnalysis()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}