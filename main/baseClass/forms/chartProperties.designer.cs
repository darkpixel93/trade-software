namespace baseClass.forms
{
    partial class chartProperties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chartProperties));
            this.charTab = new System.Windows.Forms.TabControl();
            this.chartPg = new System.Windows.Forms.TabPage();
            this.marginGb = new System.Windows.Forms.GroupBox();
            this.percentLb2 = new baseClass.controls.baseLabel();
            this.percentLb1 = new baseClass.controls.baseLabel();
            this.spaceAtRightLbl = new baseClass.controls.baseLabel();
            this.spaceAtRightEd = new System.Windows.Forms.NumericUpDown();
            this.spaceAtLeftLbl = new baseClass.controls.baseLabel();
            this.spaceAtLeftEd = new System.Windows.Forms.NumericUpDown();
            this.chartGb = new System.Windows.Forms.GroupBox();
            this.showGridChk = new common.controls.baseCheckBox();
            this.showLegendChk = new common.controls.baseCheckBox();
            this.showVolumeChk = new common.controls.baseCheckBox();
            this.showDescriptionChk = new common.controls.baseCheckBox();
            this.panZoomGb = new System.Windows.Forms.GroupBox();
            this.PAN_MouseRateEd = new common.controls.numberTextBox();
            this.panRateLbl = new baseClass.controls.baseLabel();
            this.PAN_MoveCountEd = new common.controls.numberTextBox();
            this.zoomRateLbl = new baseClass.controls.baseLabel();
            this.zoomRateEd = new common.controls.numberTextBox();
            this.colorPg = new System.Windows.Forms.TabPage();
            this.backgroundLbl = new baseClass.controls.baseLabel();
            this.volumeLbl = new baseClass.controls.baseLabel();
            this.volumesColorCb = new common.controls.ColorComboBox();
            this.lineGraphLbl = new baseClass.controls.baseLabel();
            this.lineCandleColorCb = new common.controls.ColorComboBox();
            this.bearCandleLbl = new baseClass.controls.baseLabel();
            this.bearCandleColorCb = new common.controls.ColorComboBox();
            this.bullCandleLbl = new baseClass.controls.baseLabel();
            this.bullCandleColorCb = new common.controls.ColorComboBox();
            this.barDnLbl = new baseClass.controls.baseLabel();
            this.barDnColorCb = new common.controls.ColorComboBox();
            this.barUpLbl = new baseClass.controls.baseLabel();
            this.barUpColorCb = new common.controls.ColorComboBox();
            this.gridLbl = new baseClass.controls.baseLabel();
            this.gridColorCb = new common.controls.ColorComboBox();
            this.foreGroundLbl = new baseClass.controls.baseLabel();
            this.fgColorCb = new common.controls.ColorComboBox();
            this.bgColorCb = new common.controls.ColorComboBox();
            this.charTab.SuspendLayout();
            this.chartPg.SuspendLayout();
            this.marginGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spaceAtRightEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spaceAtLeftEd)).BeginInit();
            this.chartGb.SuspendLayout();
            this.panZoomGb.SuspendLayout();
            this.colorPg.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(206, 294);
            this.closeBtn.Size = new System.Drawing.Size(92, 26);
            this.closeBtn.Visible = false;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(114, 293);
            this.okBtn.Size = new System.Drawing.Size(92, 27);
            this.okBtn.Text = "Ok";
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(634, 163);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // charTab
            // 
            this.charTab.Controls.Add(this.chartPg);
            this.charTab.Controls.Add(this.colorPg);
            this.charTab.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charTab.Location = new System.Drawing.Point(0, 1);
            this.charTab.Name = "charTab";
            this.charTab.SelectedIndex = 0;
            this.charTab.Size = new System.Drawing.Size(328, 345);
            this.charTab.TabIndex = 150;
            // 
            // chartPg
            // 
            this.chartPg.Controls.Add(this.marginGb);
            this.chartPg.Controls.Add(this.chartGb);
            this.chartPg.Controls.Add(this.panZoomGb);
            this.chartPg.Location = new System.Drawing.Point(4, 25);
            this.chartPg.Name = "chartPg";
            this.chartPg.Padding = new System.Windows.Forms.Padding(3);
            this.chartPg.Size = new System.Drawing.Size(320, 316);
            this.chartPg.TabIndex = 3;
            this.chartPg.Text = "System";
            this.chartPg.UseVisualStyleBackColor = true;
            // 
            // marginGb
            // 
            this.marginGb.Controls.Add(this.percentLb2);
            this.marginGb.Controls.Add(this.percentLb1);
            this.marginGb.Controls.Add(this.spaceAtRightLbl);
            this.marginGb.Controls.Add(this.spaceAtRightEd);
            this.marginGb.Controls.Add(this.spaceAtLeftLbl);
            this.marginGb.Controls.Add(this.spaceAtLeftEd);
            this.marginGb.Location = new System.Drawing.Point(7, 174);
            this.marginGb.Name = "marginGb";
            this.marginGb.Size = new System.Drawing.Size(311, 83);
            this.marginGb.TabIndex = 3;
            this.marginGb.TabStop = false;
            // 
            // percentLb2
            // 
            this.percentLb2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLb2.Location = new System.Drawing.Point(181, 45);
            this.percentLb2.Name = "percentLb2";
            this.percentLb2.Size = new System.Drawing.Size(19, 16);
            this.percentLb2.TabIndex = 25;
            this.percentLb2.Text = "%";
            this.percentLb2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // percentLb1
            // 
            this.percentLb1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLb1.Location = new System.Drawing.Point(181, 20);
            this.percentLb1.Name = "percentLb1";
            this.percentLb1.Size = new System.Drawing.Size(19, 16);
            this.percentLb1.TabIndex = 24;
            this.percentLb1.Text = "%";
            this.percentLb1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spaceAtRightLbl
            // 
            this.spaceAtRightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spaceAtRightLbl.Location = new System.Drawing.Point(24, 44);
            this.spaceAtRightLbl.Name = "spaceAtRightLbl";
            this.spaceAtRightLbl.Size = new System.Drawing.Size(92, 16);
            this.spaceAtRightLbl.TabIndex = 23;
            this.spaceAtRightLbl.Text = "Right margin";
            this.spaceAtRightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spaceAtRightEd
            // 
            this.spaceAtRightEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spaceAtRightEd.Location = new System.Drawing.Point(123, 42);
            this.spaceAtRightEd.Name = "spaceAtRightEd";
            this.spaceAtRightEd.Size = new System.Drawing.Size(52, 26);
            this.spaceAtRightEd.TabIndex = 2;
            this.spaceAtRightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spaceAtRightEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // spaceAtLeftLbl
            // 
            this.spaceAtLeftLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spaceAtLeftLbl.Location = new System.Drawing.Point(24, 18);
            this.spaceAtLeftLbl.Name = "spaceAtLeftLbl";
            this.spaceAtLeftLbl.Size = new System.Drawing.Size(92, 16);
            this.spaceAtLeftLbl.TabIndex = 21;
            this.spaceAtLeftLbl.Text = "Left margin";
            this.spaceAtLeftLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spaceAtLeftEd
            // 
            this.spaceAtLeftEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spaceAtLeftEd.Location = new System.Drawing.Point(123, 14);
            this.spaceAtLeftEd.Name = "spaceAtLeftEd";
            this.spaceAtLeftEd.Size = new System.Drawing.Size(52, 26);
            this.spaceAtLeftEd.TabIndex = 1;
            this.spaceAtLeftEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spaceAtLeftEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chartGb
            // 
            this.chartGb.Controls.Add(this.showGridChk);
            this.chartGb.Controls.Add(this.showLegendChk);
            this.chartGb.Controls.Add(this.showVolumeChk);
            this.chartGb.Controls.Add(this.showDescriptionChk);
            this.chartGb.Location = new System.Drawing.Point(6, 5);
            this.chartGb.Name = "chartGb";
            this.chartGb.Size = new System.Drawing.Size(312, 77);
            this.chartGb.TabIndex = 1;
            this.chartGb.TabStop = false;
            // 
            // showGridChk
            // 
            this.showGridChk.AutoSize = true;
            this.showGridChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showGridChk.Location = new System.Drawing.Point(18, 16);
            this.showGridChk.Name = "showGridChk";
            this.showGridChk.Size = new System.Drawing.Size(91, 20);
            this.showGridChk.TabIndex = 0;
            this.showGridChk.Text = "Show grid";
            this.showGridChk.UseVisualStyleBackColor = true;
            // 
            // showLegendChk
            // 
            this.showLegendChk.AutoSize = true;
            this.showLegendChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLegendChk.Location = new System.Drawing.Point(163, 44);
            this.showLegendChk.Name = "showLegendChk";
            this.showLegendChk.Size = new System.Drawing.Size(116, 20);
            this.showLegendChk.TabIndex = 3;
            this.showLegendChk.Text = "Show legends";
            this.showLegendChk.UseVisualStyleBackColor = true;
            // 
            // showVolumeChk
            // 
            this.showVolumeChk.AutoSize = true;
            this.showVolumeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showVolumeChk.Location = new System.Drawing.Point(18, 44);
            this.showVolumeChk.Name = "showVolumeChk";
            this.showVolumeChk.Size = new System.Drawing.Size(119, 20);
            this.showVolumeChk.TabIndex = 1;
            this.showVolumeChk.Text = "Show volumes";
            this.showVolumeChk.UseVisualStyleBackColor = true;
            // 
            // showDescriptionChk
            // 
            this.showDescriptionChk.AutoSize = true;
            this.showDescriptionChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDescriptionChk.Location = new System.Drawing.Point(163, 16);
            this.showDescriptionChk.Name = "showDescriptionChk";
            this.showDescriptionChk.Size = new System.Drawing.Size(145, 20);
            this.showDescriptionChk.TabIndex = 2;
            this.showDescriptionChk.Text = "Show descriptions";
            this.showDescriptionChk.UseVisualStyleBackColor = true;
            // 
            // panZoomGb
            // 
            this.panZoomGb.Controls.Add(this.PAN_MouseRateEd);
            this.panZoomGb.Controls.Add(this.panRateLbl);
            this.panZoomGb.Controls.Add(this.PAN_MoveCountEd);
            this.panZoomGb.Controls.Add(this.zoomRateLbl);
            this.panZoomGb.Controls.Add(this.zoomRateEd);
            this.panZoomGb.Location = new System.Drawing.Point(6, 89);
            this.panZoomGb.Name = "panZoomGb";
            this.panZoomGb.Size = new System.Drawing.Size(312, 85);
            this.panZoomGb.TabIndex = 2;
            this.panZoomGb.TabStop = false;
            // 
            // PAN_MouseRateEd
            // 
            this.PAN_MouseRateEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAN_MouseRateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.PAN_MouseRateEd.Location = new System.Drawing.Point(175, 43);
            this.PAN_MouseRateEd.myFormat = "###.##";
            this.PAN_MouseRateEd.Name = "PAN_MouseRateEd";
            this.PAN_MouseRateEd.Size = new System.Drawing.Size(52, 26);
            this.PAN_MouseRateEd.TabIndex = 3;
            this.PAN_MouseRateEd.Text = "3";
            this.PAN_MouseRateEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PAN_MouseRateEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.PAN_MouseRateEd.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // panRateLbl
            // 
            this.panRateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panRateLbl.Location = new System.Drawing.Point(24, 45);
            this.panRateLbl.Name = "panRateLbl";
            this.panRateLbl.Size = new System.Drawing.Size(92, 16);
            this.panRateLbl.TabIndex = 23;
            this.panRateLbl.Text = "Pan rate";
            this.panRateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PAN_MoveCountEd
            // 
            this.PAN_MoveCountEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAN_MoveCountEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.PAN_MoveCountEd.Location = new System.Drawing.Point(122, 43);
            this.PAN_MoveCountEd.myFormat = "###.##";
            this.PAN_MoveCountEd.Name = "PAN_MoveCountEd";
            this.PAN_MoveCountEd.Size = new System.Drawing.Size(52, 26);
            this.PAN_MoveCountEd.TabIndex = 2;
            this.PAN_MoveCountEd.Text = "10";
            this.PAN_MoveCountEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PAN_MoveCountEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.PAN_MoveCountEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // zoomRateLbl
            // 
            this.zoomRateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomRateLbl.Location = new System.Drawing.Point(24, 19);
            this.zoomRateLbl.Name = "zoomRateLbl";
            this.zoomRateLbl.Size = new System.Drawing.Size(92, 16);
            this.zoomRateLbl.TabIndex = 21;
            this.zoomRateLbl.Text = "Zoom rate";
            this.zoomRateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // zoomRateEd
            // 
            this.zoomRateEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomRateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.zoomRateEd.Location = new System.Drawing.Point(122, 15);
            this.zoomRateEd.myFormat = "###.##";
            this.zoomRateEd.Name = "zoomRateEd";
            this.zoomRateEd.Size = new System.Drawing.Size(52, 26);
            this.zoomRateEd.TabIndex = 1;
            this.zoomRateEd.Text = "10";
            this.zoomRateEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.zoomRateEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.zoomRateEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // colorPg
            // 
            this.colorPg.Controls.Add(this.backgroundLbl);
            this.colorPg.Controls.Add(this.volumeLbl);
            this.colorPg.Controls.Add(this.volumesColorCb);
            this.colorPg.Controls.Add(this.lineGraphLbl);
            this.colorPg.Controls.Add(this.lineCandleColorCb);
            this.colorPg.Controls.Add(this.bearCandleLbl);
            this.colorPg.Controls.Add(this.bearCandleColorCb);
            this.colorPg.Controls.Add(this.bullCandleLbl);
            this.colorPg.Controls.Add(this.bullCandleColorCb);
            this.colorPg.Controls.Add(this.barDnLbl);
            this.colorPg.Controls.Add(this.barDnColorCb);
            this.colorPg.Controls.Add(this.barUpLbl);
            this.colorPg.Controls.Add(this.barUpColorCb);
            this.colorPg.Controls.Add(this.gridLbl);
            this.colorPg.Controls.Add(this.gridColorCb);
            this.colorPg.Controls.Add(this.foreGroundLbl);
            this.colorPg.Controls.Add(this.fgColorCb);
            this.colorPg.Controls.Add(this.bgColorCb);
            this.colorPg.Location = new System.Drawing.Point(4, 25);
            this.colorPg.Name = "colorPg";
            this.colorPg.Padding = new System.Windows.Forms.Padding(3);
            this.colorPg.Size = new System.Drawing.Size(320, 316);
            this.colorPg.TabIndex = 2;
            this.colorPg.Text = "Colors";
            this.colorPg.UseVisualStyleBackColor = true;
            // 
            // backgroundLbl
            // 
            this.backgroundLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundLbl.Location = new System.Drawing.Point(6, 16);
            this.backgroundLbl.Name = "backgroundLbl";
            this.backgroundLbl.Size = new System.Drawing.Size(100, 23);
            this.backgroundLbl.TabIndex = 43;
            this.backgroundLbl.Text = "Background";
            this.backgroundLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // volumeLbl
            // 
            this.volumeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeLbl.Location = new System.Drawing.Point(6, 230);
            this.volumeLbl.Name = "volumeLbl";
            this.volumeLbl.Size = new System.Drawing.Size(100, 23);
            this.volumeLbl.TabIndex = 26;
            this.volumeLbl.Text = "Volumes";
            this.volumeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // volumesColorCb
            // 
            this.volumesColorCb.Color = System.Drawing.Color.Black;
            this.volumesColorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.volumesColorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.volumesColorCb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumesColorCb.isColorListLoaded = true;
            this.volumesColorCb.Location = new System.Drawing.Point(109, 225);
            this.volumesColorCb.Name = "volumesColorCb";
            this.volumesColorCb.Size = new System.Drawing.Size(186, 27);
            this.volumesColorCb.TabIndex = 40;
            // 
            // lineGraphLbl
            // 
            this.lineGraphLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineGraphLbl.Location = new System.Drawing.Point(6, 204);
            this.lineGraphLbl.Name = "lineGraphLbl";
            this.lineGraphLbl.Size = new System.Drawing.Size(100, 23);
            this.lineGraphLbl.TabIndex = 24;
            this.lineGraphLbl.Text = "Line Graph";
            this.lineGraphLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lineCandleColorCb
            // 
            this.lineCandleColorCb.Color = System.Drawing.Color.Black;
            this.lineCandleColorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lineCandleColorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lineCandleColorCb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineCandleColorCb.isColorListLoaded = true;
            this.lineCandleColorCb.Location = new System.Drawing.Point(109, 201);
            this.lineCandleColorCb.Name = "lineCandleColorCb";
            this.lineCandleColorCb.Size = new System.Drawing.Size(186, 27);
            this.lineCandleColorCb.TabIndex = 35;
            // 
            // bearCandleLbl
            // 
            this.bearCandleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bearCandleLbl.Location = new System.Drawing.Point(6, 179);
            this.bearCandleLbl.Name = "bearCandleLbl";
            this.bearCandleLbl.Size = new System.Drawing.Size(100, 23);
            this.bearCandleLbl.TabIndex = 22;
            this.bearCandleLbl.Text = "Bear Candle";
            this.bearCandleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bearCandleColorCb
            // 
            this.bearCandleColorCb.Color = System.Drawing.Color.Black;
            this.bearCandleColorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bearCandleColorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bearCandleColorCb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bearCandleColorCb.isColorListLoaded = true;
            this.bearCandleColorCb.Location = new System.Drawing.Point(109, 176);
            this.bearCandleColorCb.Name = "bearCandleColorCb";
            this.bearCandleColorCb.Size = new System.Drawing.Size(186, 27);
            this.bearCandleColorCb.TabIndex = 30;
            // 
            // bullCandleLbl
            // 
            this.bullCandleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bullCandleLbl.Location = new System.Drawing.Point(6, 152);
            this.bullCandleLbl.Name = "bullCandleLbl";
            this.bullCandleLbl.Size = new System.Drawing.Size(100, 23);
            this.bullCandleLbl.TabIndex = 20;
            this.bullCandleLbl.Text = "Bull Candle";
            this.bullCandleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bullCandleColorCb
            // 
            this.bullCandleColorCb.Color = System.Drawing.Color.Black;
            this.bullCandleColorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bullCandleColorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bullCandleColorCb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bullCandleColorCb.isColorListLoaded = true;
            this.bullCandleColorCb.Location = new System.Drawing.Point(109, 148);
            this.bullCandleColorCb.Name = "bullCandleColorCb";
            this.bullCandleColorCb.Size = new System.Drawing.Size(186, 27);
            this.bullCandleColorCb.TabIndex = 25;
            // 
            // barDnLbl
            // 
            this.barDnLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barDnLbl.Location = new System.Drawing.Point(6, 126);
            this.barDnLbl.Name = "barDnLbl";
            this.barDnLbl.Size = new System.Drawing.Size(100, 23);
            this.barDnLbl.TabIndex = 18;
            this.barDnLbl.Text = "Bar Down";
            this.barDnLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // barDnColorCb
            // 
            this.barDnColorCb.Color = System.Drawing.Color.Black;
            this.barDnColorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.barDnColorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.barDnColorCb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barDnColorCb.isColorListLoaded = true;
            this.barDnColorCb.Location = new System.Drawing.Point(109, 122);
            this.barDnColorCb.Name = "barDnColorCb";
            this.barDnColorCb.Size = new System.Drawing.Size(186, 27);
            this.barDnColorCb.TabIndex = 20;
            // 
            // barUpLbl
            // 
            this.barUpLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barUpLbl.Location = new System.Drawing.Point(6, 99);
            this.barUpLbl.Name = "barUpLbl";
            this.barUpLbl.Size = new System.Drawing.Size(100, 23);
            this.barUpLbl.TabIndex = 16;
            this.barUpLbl.Text = "Bar Up";
            this.barUpLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // barUpColorCb
            // 
            this.barUpColorCb.Color = System.Drawing.Color.Black;
            this.barUpColorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.barUpColorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.barUpColorCb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barUpColorCb.isColorListLoaded = true;
            this.barUpColorCb.Location = new System.Drawing.Point(109, 94);
            this.barUpColorCb.Name = "barUpColorCb";
            this.barUpColorCb.Size = new System.Drawing.Size(186, 27);
            this.barUpColorCb.TabIndex = 15;
            // 
            // gridLbl
            // 
            this.gridLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridLbl.Location = new System.Drawing.Point(6, 72);
            this.gridLbl.Name = "gridLbl";
            this.gridLbl.Size = new System.Drawing.Size(100, 23);
            this.gridLbl.TabIndex = 14;
            this.gridLbl.Text = "Grid";
            this.gridLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridColorCb
            // 
            this.gridColorCb.Color = System.Drawing.Color.Black;
            this.gridColorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gridColorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gridColorCb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColorCb.isColorListLoaded = true;
            this.gridColorCb.Location = new System.Drawing.Point(109, 68);
            this.gridColorCb.Name = "gridColorCb";
            this.gridColorCb.Size = new System.Drawing.Size(186, 27);
            this.gridColorCb.TabIndex = 10;
            // 
            // foreGroundLbl
            // 
            this.foreGroundLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreGroundLbl.Location = new System.Drawing.Point(6, 45);
            this.foreGroundLbl.Name = "foreGroundLbl";
            this.foreGroundLbl.Size = new System.Drawing.Size(100, 23);
            this.foreGroundLbl.TabIndex = 12;
            this.foreGroundLbl.Text = "Foreground";
            this.foreGroundLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fgColorCb
            // 
            this.fgColorCb.Color = System.Drawing.Color.Black;
            this.fgColorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.fgColorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fgColorCb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgColorCb.isColorListLoaded = true;
            this.fgColorCb.Location = new System.Drawing.Point(109, 40);
            this.fgColorCb.Name = "fgColorCb";
            this.fgColorCb.Size = new System.Drawing.Size(186, 27);
            this.fgColorCb.TabIndex = 41;
            // 
            // bgColorCb
            // 
            this.bgColorCb.Color = System.Drawing.Color.Black;
            this.bgColorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bgColorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bgColorCb.isColorListLoaded = false;
            this.bgColorCb.Location = new System.Drawing.Point(109, 15);
            this.bgColorCb.Name = "bgColorCb";
            this.bgColorCb.Size = new System.Drawing.Size(186, 24);
            this.bgColorCb.TabIndex = 1;
            // 
            // chartProperties
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(326, 345);
            this.Controls.Add(this.charTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "chartProperties";
            this.Text = "Properties";
            this.Controls.SetChildIndex(this.charTab, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.charTab.ResumeLayout(false);
            this.chartPg.ResumeLayout(false);
            this.marginGb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spaceAtRightEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spaceAtLeftEd)).EndInit();
            this.chartGb.ResumeLayout(false);
            this.chartGb.PerformLayout();
            this.panZoomGb.ResumeLayout(false);
            this.panZoomGb.PerformLayout();
            this.colorPg.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl charTab;
        private System.Windows.Forms.TabPage colorPg;
        protected common.controls.ColorComboBox bgColorCb;
        private baseClass.controls.baseLabel foreGroundLbl;
        protected common.controls.ColorComboBox fgColorCb;
        private baseClass.controls.baseLabel volumeLbl;
        protected common.controls.ColorComboBox volumesColorCb;
        private baseClass.controls.baseLabel lineGraphLbl;
        protected common.controls.ColorComboBox lineCandleColorCb;
        private baseClass.controls.baseLabel bearCandleLbl;
        protected common.controls.ColorComboBox bearCandleColorCb;
        private baseClass.controls.baseLabel bullCandleLbl;
        protected common.controls.ColorComboBox bullCandleColorCb;
        private baseClass.controls.baseLabel barDnLbl;
        protected common.controls.ColorComboBox barDnColorCb;
        private baseClass.controls.baseLabel barUpLbl;
        protected common.controls.ColorComboBox barUpColorCb;
        private baseClass.controls.baseLabel gridLbl;
        protected common.controls.ColorComboBox gridColorCb;
        private System.Windows.Forms.TabPage chartPg;
        private common.controls.baseCheckBox showDescriptionChk;
        private common.controls.baseCheckBox showVolumeChk;
        private common.controls.baseCheckBox showGridChk;
        private System.Windows.Forms.GroupBox panZoomGb;
        private System.Windows.Forms.GroupBox chartGb;
        private common.controls.baseCheckBox showLegendChk;
        private baseClass.controls.baseLabel panRateLbl;
        private common.controls.numberTextBox PAN_MoveCountEd;
        private baseClass.controls.baseLabel zoomRateLbl;
        private common.controls.numberTextBox zoomRateEd;
        private common.controls.numberTextBox PAN_MouseRateEd;
        private System.Windows.Forms.GroupBox marginGb;
        private baseClass.controls.baseLabel spaceAtRightLbl;
        private baseClass.controls.baseLabel spaceAtLeftLbl;
        private baseClass.controls.baseLabel percentLb2;
        private baseClass.controls.baseLabel percentLb1;
        private System.Windows.Forms.NumericUpDown spaceAtRightEd;
        private System.Windows.Forms.NumericUpDown spaceAtLeftEd;
        private baseClass.controls.baseLabel backgroundLbl;

    }
}