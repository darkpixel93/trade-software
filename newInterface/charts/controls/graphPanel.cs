using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Windows.Forms;

namespace Charts.Controls
{
    public partial class baseGraphPanel : common.controls.basePanel
    {
        //TUAN
        private const int cGripSize = 2;
        private bool mDragging;
        private Point mDragPos;
        //TUAN

        private common.RangeBar xRangeBar = new common.RangeBar();
        public baseGraphPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);            
            this.Controls.Add(myGraphObj);            
            this.Controls.Add(xRangeBar);
            this.haveCloseButton = true;
            myGraphObj.Location = new Point(cGripSize, cGripSize);
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
            updateCurveTitles();
            myGraphObj.AxisChange();
            myGraphObj.Invalidate();
        }

        public void updateCurveTitles()
        {
            string text = string.Empty;
            string lastName = string.Empty;
            foreach (var item in myGraphObj.myGraphPane.CurveList)
            {
                if (!item.Label.Text.Equals("pricePanel") && !item.Label.Text.Equals("volumePanel"))
                {
                    string temp = item.Label.Text;
                    temp = temp.Replace("Indicator-", "");
                    string[] arr = temp.Split('-');
                    if (arr.Count() >= 2)
                    {
                        if (arr[1].Length >= 1)
                        {
                            temp = arr[0] + "(" + arr[1] + ")";
                        }
                        else
                        {
                            temp = arr[0] ;
                        }
                    }
                    if (!lastName.Equals(temp))
                    {
                        text +=temp + " & ";
                        lastName = temp;
                    }                    
                }
            }
            string[] aString = text.Split('&');
            if (text.Length > 3)
            {
                text = text.Remove(text.Length - 3);                  
                if (!this.Name.Equals("pricePanel")&&!this.Name.Equals("volumePanel"))
                {
                    if (!text.Contains(this.Name))
                    {                       
                        int indexDeli=0;
                        int count = 0;
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (text[i].Equals('-'))
                            {
                                indexDeli = i;
                                count++;
                            }
                        }
                        if (count >= 2)
                        {
                            text = text.Substring(0, indexDeli);
                            if (text[text.Length - 1] == '-')
                            {
                                text = text.Remove(text.Length - 1);
                            }                                                  
                        }
                        else
                        {
                            if (text[text.Length - 1] == '-')
                            {
                                text = text.Remove(text.Length - 1);
                            }                            
                        }                        
                    }                    
                }
                setText(text);
            }
            else
            {
                clearText();
            }
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
            myGraphObj.Location = new Point(cGripSize, cGripSize);
            this.myGraphObj.myGraphPane.Margin.Right = 100;
            myGraphObj.Size = new Size(this.Width - cGripSize * 2, this.Height - cGripSize*2);
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
        public void setText(string s)
        {
            clearText();
            TextObj text = null;                       
            text = new TextObj(s, 0.05f, 0.95f, CoordType.ChartFraction, AlignH.Left, AlignV.Bottom);
            text.FontSpec.StringAlignment = StringAlignment.Near;            
            this.myGraphObj.GraphPane.GraphObjList.Add(text);
        }
        public void clearText()
        {
            for (int i = 0; i < this.myGraphObj.GraphPane.GraphObjList.Count; i++)
            {
                var item = this.myGraphObj.GraphPane.GraphObjList[i];
                if (item.GetType().Name==typeof(TextObj).Name)
                {
                    if ((item as TextObj).Text.Equals("B") || (item as TextObj).Text.Equals("S"))
                    {
                        continue;
                    }
                    else
                    {
                        this.myGraphObj.GraphPane.GraphObjList.Remove(item);
                        i--;
                    }
                }
            }            
        }
        public string getText()
        {
            updateCurveTitles();
            if (this.Name.Equals("pricePanel") && this.Name.Equals("volumePanel"))
            {
                return this.Name;
            }
            if (this.myGraphObj.GraphPane.GraphObjList.Count>0&&this.myGraphObj.GraphPane.GraphObjList[0]!=null)
            {
                return (this.myGraphObj.GraphPane.GraphObjList[0] as TextObj).Text;
            }
            return string.Empty;
        }

        //TUAN
        private bool IsOnGrip(Point pos)
        {
            return pos.Y <cGripSize &&
                   pos.Y >= 0;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            mDragging = IsOnGrip(e.Location);         
            mDragPos = e.Location;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mDragging = false;
            base.OnMouseUp(e);
        }
        
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mDragging)
            {
                this.Size = new Size(this.Width,
                  this.Height + mDragPos.Y - e.Y);
                mDragPos = e.Location;
            }
            else if (IsOnGrip(e.Location)) this.Cursor = Cursors.SizeNS;
            else this.Cursor = Cursors.Default;
            base.OnMouseMove(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {       
             base.OnPaint(e);                            
        }
        //Tuan- Fix bug Control resizing with no flicker
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }
        //Tuan- Fix bug Control resizing with no flicker
        //TUAN
    }

}