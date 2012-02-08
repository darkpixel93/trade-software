using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Charts.Controls
{
    public partial class baseGraphPanel : common.controls.basePanel
    {
        private common.RangeBar xRangeBar = new common.RangeBar();
        public baseGraphPanel()
        {
            this.Controls.Add(myGraphObj);
            this.Controls.Add(xRangeBar);
            this.haveCloseButton = true;
            myGraphObj.Location = new Point(0, 0);
            xRangeBar.Visible = false;
            this.xRangeBar.RangeChanging += new common.RangeBar.RangeChangedEventHandler(this.xRangeBarRangeChanging);
            this.myGraphObj.myOnViewportChanged += new myGraphControl.OnViewportChanged(graphViewportChanged);
            this.myGraphObj.myOnDataRangeChanged += new myGraphControl.OnDataRangeChanged(graphDataRangeChanged); 
        }
        public bool HaveRangeBarX
        {
            get
            {
                return xRangeBar.Visible;
            }
            set
            {
                xRangeBar.Visible = value;
                if (!value || this.myGraphObj.mySeriesX==null) return;

                xRangeBar.BringToFront();
                xRangeBar.Height = 25;
                xRangeBar.HeightOfMark = 0;
                xRangeBar.HeightOfTick = 6;
                xRangeBar.ScaleOrientation = common.RangeBar.TopBottomOrientation.both;
                xRangeBar.Width = this.Width;
                xRangeBar.Location = new Point((int)this.myGraphObj.myGraphPane.Chart.Rect.X, this.Height - xRangeBar.Height);
                xRangeBar.Width = this.Width - xRangeBar.Location.X;

                xRangeBar.TotalMinimum = 0;
                xRangeBar.TotalMaximum = this.myGraphObj.mySeriesX.Length-1;
                Graph2XRangeBar();
            }
        }

        public myGraphControl myGraphObj = new myGraphControl();
        public event myGraphControl.OnGetMoreData myGetMoreData
        {
            add
            {
                myGraphObj.myOnGetMoreData += value;
            }
            remove
            {
                myGraphObj.myOnGetMoreData -= value;
            }
        }
        
        public void ResetGraph()
        {
            myGraphObj.DefaultViewport();
        }

        public void PlotGraph()
        {
            // Tell ZedGraph to calculate the axis ranges
            myGraphObj.AxisChange();
            myGraphObj.Invalidate();
        }
        public void RemoveAllCurves()
        {
            while (myGraphObj.myGraphPane.CurveList.Count > 0)
                myGraphObj.myGraphPane.CurveList.Remove(myGraphObj.myGraphPane.CurveList[0]);
        }
        public void RemoveCurve(CurveItem item)
        {
            myGraphObj.myGraphPane.CurveList.Remove(item);
        }

        #region override functions
        protected override void OnResize(EventArgs e)
        {
            myGraphObj.Location = new Point(0, 0);
            this.myGraphObj.myGraphPane.Margin.Right = 100;
            myGraphObj.Size = new Size(this.Width, this.Height);
            myGraphObj.CalcGraphSize();
            base.OnResize(e);
        }
        #endregion override functions

        private void graphDataRangeChanged(object sender)
        {
            if (this.HaveRangeBarX)
            {
                xRangeBar.TotalMinimum = 0;
                xRangeBar.TotalMaximum = this.myGraphObj.mySeriesX.Length - 1;
                Graph2XRangeBar();
            }
        }
        private void graphViewportChanged(object sender, ViewportState state)
        {
            try
            {
                if (this.HaveRangeBarX) Graph2XRangeBar();
            }
            catch {}
        }
        private void xRangeBarRangeChanging(object sender, EventArgs e)
        {
            try
            {
                xRangeBar2Graph();
            }
            catch {}
        }

        private void xRangeBar2Graph()
        {
            this.myGraphObj.myViewportX = new IntRange(xRangeBar.RangeMinimum, xRangeBar.RangeMaximum);
        }
        private void Graph2XRangeBar()
        {
            xRangeBar.RangeMaximum = this.myGraphObj.myViewportX.Max;
            xRangeBar.RangeMinimum = this.myGraphObj.myViewportX.Min;
        }
    }

}