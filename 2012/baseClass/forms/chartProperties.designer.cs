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
            this.bottomMarginLbl = new baseClass.controls.baseLabel();
            this.trailingSpaceLbl = new baseClass.controls.baseLabel();
            this.bottomMarginEd = new System.Windows.Forms.NumericUpDown();
            this.trailingSpaceEd = new System.Windows.Forms.NumericUpDown();
            this.topMarginLbl = new baseClass.controls.baseLabel();
            this.leadingSpaceLbl = new baseClass.controls.baseLabel();
            this.topMarginEd = new System.Windows.Forms.NumericUpDown();
            this.leadingSpaceEd = new System.Windows.Forms.NumericUpDown();
            this.marginAndSpaceLbl = new baseClass.controls.baseLabel();
            this.rightMarginLbl = new baseClass.controls.baseLabel();
            this.rightMarginEd = new System.Windows.Forms.NumericUpDown();
            this.leftMarginLbl = new baseClass.controls.baseLabel();
            this.leftMarginEd = new System.Windows.Forms.NumericUpDown();
            this.chartGb = new System.Windows.Forms.GroupBox();
            this.showGridChk = new common.controls.baseCheckBox();
            this.showLegendChk = new common.controls.baseCheckBox();
            this.showVolumeChk = new common.controls.baseCheckBox();
            this.showDescriptionChk = new common.controls.baseCheckBox();
            this.panZoomGb = new System.Windows.Forms.GroupBox();
            this.movePerPanLbl = new baseClass.controls.baseLabel();
            this.zoomPercEd = new System.Windows.Forms.NumericUpDown();
            this.panMouseRateLbl = new baseClass.controls.baseLabel();
            this.panMovePercEd = new System.Windows.Forms.NumericUpDown();
            this.panMouseRateEd = new common.controls.numberTextBox();
            this.panRateLbl = new baseClass.controls.baseLabel();
            this.panMoveMinCountEd = new common.controls.numberTextBox();
            this.zoomRateLbl = new baseClass.controls.baseLabel();
            this.zoomMinCountEd = new common.controls.numberTextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.bottomMarginEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trailingSpaceEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMarginEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leadingSpaceEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightMarginEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftMarginEd)).BeginInit();
            this.chartGb.SuspendLayout();
            this.panZoomGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomPercEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panMovePercEd)).BeginInit();
            this.colorPg.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(214, 330);
            this.closeBtn.Size = new System.Drawing.Size(92, 26);
            this.closeBtn.Visible = false;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(121, 330);
            this.okBtn.Size = new System.Drawing.Size(92, 26);
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
            this.charTab.Size = new System.Drawing.Size(372, 385);
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
            this.chartPg.Size = new System.Drawing.Size(364, 356);
            this.chartPg.TabIndex = 3;
            this.chartPg.Text = "System";
            this.chartPg.UseVisualStyleBackColor = true;
            // 
            // marginGb
            // 
            this.marginGb.Controls.Add(this.bottomMarginLbl);
            this.marginGb.Controls.Add(this.trailingSpaceLbl);
            this.marginGb.Controls.Add(this.bottomMarginEd);
            this.marginGb.Controls.Add(this.trailingSpaceEd);
            this.marginGb.Controls.Add(this.topMarginLbl);
            this.marginGb.Controls.Add(this.leadingSpaceLbl);
            this.marginGb.Controls.Add(this.topMarginEd);
            this.marginGb.Controls.Add(this.leadingSpaceEd);
            this.marginGb.Controls.Add(this.marginAndSpaceLbl);
            this.marginGb.Controls.Add(this.rightMarginLbl);
            this.marginGb.Controls.Add(this.rightMarginEd);
            this.marginGb.Controls.Add(this.leftMarginLbl);
            this.marginGb.Controls.Add(this.leftMarginEd);
            this.marginGb.Location = new System.Drawing.Point(10, 187);
            this.marginGb.Name = "marginGb";
            this.marginGb.Size = new System.Drawing.Size(322, 109);
            this.marginGb.TabIndex = 3;
            this.marginGb.TabStop = false;
            // 
            // bottomMarginLbl
            // 
            this.bottomMarginLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomMarginLbl.Location = new System.Drawing.Point(180, 51);
            this.bottomMarginLbl.Name = "bottomMarginLbl";
            this.bottomMarginLbl.Size = new System.Drawing.Size(60, 16);
            this.bottomMarginLbl.TabIndex = 27;
            this.bottomMarginLbl.Text = "Bottom";
            this.bottomMarginLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trailingSpaceLbl
            // 
            this.trailingSpaceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trailingSpaceLbl.Location = new System.Drawing.Point(180, 78);
            this.trailingSpaceLbl.Name = "trailingSpaceLbl";
            this.trailingSpaceLbl.Size = new System.Drawing.Size(60, 18);
            this.trailingSpaceLbl.TabIndex = 23;
            this.trailingSpaceLbl.Text = "Trailing";
            this.trailingSpaceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bottomMarginEd
            // 
            this.bottomMarginEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomMarginEd.Location = new System.Drawing.Point(243, 46);
            this.bottomMarginEd.Name = "bottomMarginEd";
            this.bottomMarginEd.Size = new System.Drawing.Size(52, 26);
            this.bottomMarginEd.TabIndex = 4;
            this.bottomMarginEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bottomMarginEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // trailingSpaceEd
            // 
            this.trailingSpaceEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trailingSpaceEd.Location = new System.Drawing.Point(243, 74);
            this.trailingSpaceEd.Name = "trailingSpaceEd";
            this.trailingSpaceEd.Size = new System.Drawing.Size(52, 26);
            this.trailingSpaceEd.TabIndex = 11;
            this.trailingSpaceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trailingSpaceEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.trailingSpaceEd.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // topMarginLbl
            // 
            this.topMarginLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topMarginLbl.Location = new System.Drawing.Point(180, 23);
            this.topMarginLbl.Name = "topMarginLbl";
            this.topMarginLbl.Size = new System.Drawing.Size(60, 16);
            this.topMarginLbl.TabIndex = 26;
            this.topMarginLbl.Text = "Top";
            this.topMarginLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leadingSpaceLbl
            // 
            this.leadingSpaceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leadingSpaceLbl.Location = new System.Drawing.Point(47, 79);
            this.leadingSpaceLbl.Name = "leadingSpaceLbl";
            this.leadingSpaceLbl.Size = new System.Drawing.Size(63, 16);
            this.leadingSpaceLbl.TabIndex = 21;
            this.leadingSpaceLbl.Text = "Leading";
            this.leadingSpaceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // topMarginEd
            // 
            this.topMarginEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topMarginEd.Location = new System.Drawing.Point(243, 18);
            this.topMarginEd.Name = "topMarginEd";
            this.topMarginEd.Size = new System.Drawing.Size(52, 26);
            this.topMarginEd.TabIndex = 3;
            this.topMarginEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.topMarginEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // leadingSpaceEd
            // 
            this.leadingSpaceEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leadingSpaceEd.Location = new System.Drawing.Point(112, 74);
            this.leadingSpaceEd.Name = "leadingSpaceEd";
            this.leadingSpaceEd.Size = new System.Drawing.Size(52, 26);
            this.leadingSpaceEd.TabIndex = 10;
            this.leadingSpaceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.leadingSpaceEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // marginAndSpaceLbl
            // 
            this.marginAndSpaceLbl.AutoSize = true;
            this.marginAndSpaceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marginAndSpaceLbl.Location = new System.Drawing.Point(15, -2);
            this.marginAndSpaceLbl.Name = "marginAndSpaceLbl";
            this.marginAndSpaceLbl.Size = new System.Drawing.Size(130, 16);
            this.marginAndSpaceLbl.TabIndex = 22;
            this.marginAndSpaceLbl.Text = " Margin and space ";
            this.marginAndSpaceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rightMarginLbl
            // 
            this.rightMarginLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightMarginLbl.Location = new System.Drawing.Point(47, 51);
            this.rightMarginLbl.Name = "rightMarginLbl";
            this.rightMarginLbl.Size = new System.Drawing.Size(63, 16);
            this.rightMarginLbl.TabIndex = 23;
            this.rightMarginLbl.Text = "Right";
            this.rightMarginLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rightMarginEd
            // 
            this.rightMarginEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightMarginEd.Location = new System.Drawing.Point(112, 46);
            this.rightMarginEd.Name = "rightMarginEd";
            this.rightMarginEd.Size = new System.Drawing.Size(52, 26);
            this.rightMarginEd.TabIndex = 2;
            this.rightMarginEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rightMarginEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // leftMarginLbl
            // 
            this.leftMarginLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftMarginLbl.Location = new System.Drawing.Point(47, 23);
            this.leftMarginLbl.Name = "leftMarginLbl";
            this.leftMarginLbl.Size = new System.Drawing.Size(63, 16);
            this.leftMarginLbl.TabIndex = 21;
            this.leftMarginLbl.Text = "Left ";
            this.leftMarginLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leftMarginEd
            // 
            this.leftMarginEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftMarginEd.Location = new System.Drawing.Point(112, 18);
            this.leftMarginEd.Name = "leftMarginEd";
            this.leftMarginEd.Size = new System.Drawing.Size(52, 26);
            this.leftMarginEd.TabIndex = 1;
            this.leftMarginEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.leftMarginEd.Value = new decimal(new int[] {
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
            this.chartGb.Location = new System.Drawing.Point(9, 5);
            this.chartGb.Name = "chartGb";
            this.chartGb.Size = new System.Drawing.Size(323, 77);
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
            this.panZoomGb.Controls.Add(this.movePerPanLbl);
            this.panZoomGb.Controls.Add(this.zoomPercEd);
            this.panZoomGb.Controls.Add(this.panMouseRateLbl);
            this.panZoomGb.Controls.Add(this.panMovePercEd);
            this.panZoomGb.Controls.Add(this.panMouseRateEd);
            this.panZoomGb.Controls.Add(this.panRateLbl);
            this.panZoomGb.Controls.Add(this.panMoveMinCountEd);
            this.panZoomGb.Controls.Add(this.zoomRateLbl);
            this.panZoomGb.Controls.Add(this.zoomMinCountEd);
            this.panZoomGb.Location = new System.Drawing.Point(9, 78);
            this.panZoomGb.Name = "panZoomGb";
            this.panZoomGb.Size = new System.Drawing.Size(323, 102);
            this.panZoomGb.TabIndex = 2;
            this.panZoomGb.TabStop = false;
            // 
            // movePerPanLbl
            // 
            this.movePerPanLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movePerPanLbl.Location = new System.Drawing.Point(168, 75);
            this.movePerPanLbl.Name = "movePerPanLbl";
            this.movePerPanLbl.Size = new System.Drawing.Size(126, 16);
            this.movePerPanLbl.TabIndex = 26;
            this.movePerPanLbl.Text = "moves per pan";
            this.movePerPanLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // zoomPercEd
            // 
            this.zoomPercEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomPercEd.Location = new System.Drawing.Point(113, 16);
            this.zoomPercEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoomPercEd.Name = "zoomPercEd";
            this.zoomPercEd.Size = new System.Drawing.Size(52, 26);
            this.zoomPercEd.TabIndex = 1;
            this.zoomPercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.zoomPercEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // panMouseRateLbl
            // 
            this.panMouseRateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panMouseRateLbl.Location = new System.Drawing.Point(16, 75);
            this.panMouseRateLbl.Name = "panMouseRateLbl";
            this.panMouseRateLbl.Size = new System.Drawing.Size(92, 16);
            this.panMouseRateLbl.TabIndex = 25;
            this.panMouseRateLbl.Text = "Mouse rate";
            this.panMouseRateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panMovePercEd
            // 
            this.panMovePercEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panMovePercEd.Location = new System.Drawing.Point(113, 43);
            this.panMovePercEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.panMovePercEd.Name = "panMovePercEd";
            this.panMovePercEd.Size = new System.Drawing.Size(52, 26);
            this.panMovePercEd.TabIndex = 10;
            this.panMovePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.panMovePercEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panMouseRateEd
            // 
            this.panMouseRateEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panMouseRateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.panMouseRateEd.Location = new System.Drawing.Point(113, 70);
            this.panMouseRateEd.myFormat = "###.##";
            this.panMouseRateEd.Name = "panMouseRateEd";
            this.panMouseRateEd.Size = new System.Drawing.Size(52, 26);
            this.panMouseRateEd.TabIndex = 20;
            this.panMouseRateEd.TabStop = false;
            this.panMouseRateEd.Text = "3";
            this.panMouseRateEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.panMouseRateEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.panMouseRateEd.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // panRateLbl
            // 
            this.panRateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panRateLbl.Location = new System.Drawing.Point(18, 47);
            this.panRateLbl.Name = "panRateLbl";
            this.panRateLbl.Size = new System.Drawing.Size(92, 16);
            this.panRateLbl.TabIndex = 23;
            this.panRateLbl.Text = "Pan rate";
            this.panRateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panMoveMinCountEd
            // 
            this.panMoveMinCountEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panMoveMinCountEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.panMoveMinCountEd.Location = new System.Drawing.Point(164, 43);
            this.panMoveMinCountEd.myFormat = "###.##";
            this.panMoveMinCountEd.Name = "panMoveMinCountEd";
            this.panMoveMinCountEd.Size = new System.Drawing.Size(52, 26);
            this.panMoveMinCountEd.TabIndex = 11;
            this.panMoveMinCountEd.Text = "10";
            this.panMoveMinCountEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.panMoveMinCountEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.panMoveMinCountEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // zoomRateLbl
            // 
            this.zoomRateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomRateLbl.Location = new System.Drawing.Point(15, 19);
            this.zoomRateLbl.Name = "zoomRateLbl";
            this.zoomRateLbl.Size = new System.Drawing.Size(92, 16);
            this.zoomRateLbl.TabIndex = 21;
            this.zoomRateLbl.Text = "Zoom rate";
            this.zoomRateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // zoomMinCountEd
            // 
            this.zoomMinCountEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomMinCountEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.zoomMinCountEd.Location = new System.Drawing.Point(164, 16);
            this.zoomMinCountEd.myFormat = "###.##";
            this.zoomMinCountEd.Name = "zoomMinCountEd";
            this.zoomMinCountEd.Size = new System.Drawing.Size(52, 26);
            this.zoomMinCountEd.TabIndex = 2;
            this.zoomMinCountEd.Text = "10";
            this.zoomMinCountEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.zoomMinCountEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.zoomMinCountEd.Value = new decimal(new int[] {
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
            this.colorPg.Size = new System.Drawing.Size(364, 356);
            this.colorPg.TabIndex = 2;
            this.colorPg.Text = "Colors";
            this.colorPg.UseVisualStyleBackColor = true;
            // 
            // backgroundLbl
            // 
            this.backgroundLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundLbl.Location = new System.Drawing.Point(15, 29);
            this.backgroundLbl.Name = "backgroundLbl";
            this.backgroundLbl.Size = new System.Drawing.Size(100, 23);
            this.backgroundLbl.TabIndex = 43;
            this.backgroundLbl.Text = "Background";
            this.backgroundLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // volumeLbl
            // 
            this.volumeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeLbl.Location = new System.Drawing.Point(15, 243);
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
            this.volumesColorCb.Location = new System.Drawing.Point(128, 238);
            this.volumesColorCb.Name = "volumesColorCb";
            this.volumesColorCb.Size = new System.Drawing.Size(218, 27);
            this.volumesColorCb.TabIndex = 40;
            // 
            // lineGraphLbl
            // 
            this.lineGraphLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineGraphLbl.Location = new System.Drawing.Point(15, 217);
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
            this.lineCandleColorCb.Location = new System.Drawing.Point(128, 214);
            this.lineCandleColorCb.Name = "lineCandleColorCb";
            this.lineCandleColorCb.Size = new System.Drawing.Size(218, 27);
            this.lineCandleColorCb.TabIndex = 35;
            // 
            // bearCandleLbl
            // 
            this.bearCandleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bearCandleLbl.Location = new System.Drawing.Point(15, 192);
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
            this.bearCandleColorCb.Location = new System.Drawing.Point(128, 189);
            this.bearCandleColorCb.Name = "bearCandleColorCb";
            this.bearCandleColorCb.Size = new System.Drawing.Size(218, 27);
            this.bearCandleColorCb.TabIndex = 30;
            // 
            // bullCandleLbl
            // 
            this.bullCandleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bullCandleLbl.Location = new System.Drawing.Point(15, 165);
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
            this.bullCandleColorCb.Location = new System.Drawing.Point(128, 161);
            this.bullCandleColorCb.Name = "bullCandleColorCb";
            this.bullCandleColorCb.Size = new System.Drawing.Size(218, 27);
            this.bullCandleColorCb.TabIndex = 25;
            // 
            // barDnLbl
            // 
            this.barDnLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barDnLbl.Location = new System.Drawing.Point(15, 139);
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
            this.barDnColorCb.Location = new System.Drawing.Point(128, 135);
            this.barDnColorCb.Name = "barDnColorCb";
            this.barDnColorCb.Size = new System.Drawing.Size(218, 27);
            this.barDnColorCb.TabIndex = 20;
            // 
            // barUpLbl
            // 
            this.barUpLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barUpLbl.Location = new System.Drawing.Point(15, 112);
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
            this.barUpColorCb.Location = new System.Drawing.Point(128, 107);
            this.barUpColorCb.Name = "barUpColorCb";
            this.barUpColorCb.Size = new System.Drawing.Size(218, 27);
            this.barUpColorCb.TabIndex = 15;
            // 
            // gridLbl
            // 
            this.gridLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridLbl.Location = new System.Drawing.Point(15, 85);
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
            this.gridColorCb.Location = new System.Drawing.Point(128, 81);
            this.gridColorCb.Name = "gridColorCb";
            this.gridColorCb.Size = new System.Drawing.Size(218, 27);
            this.gridColorCb.TabIndex = 10;
            // 
            // foreGroundLbl
            // 
            this.foreGroundLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreGroundLbl.Location = new System.Drawing.Point(15, 58);
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
            this.fgColorCb.Location = new System.Drawing.Point(128, 53);
            this.fgColorCb.Name = "fgColorCb";
            this.fgColorCb.Size = new System.Drawing.Size(218, 27);
            this.fgColorCb.TabIndex = 41;
            // 
            // bgColorCb
            // 
            this.bgColorCb.Color = System.Drawing.Color.Black;
            this.bgColorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bgColorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bgColorCb.isColorListLoaded = false;
            this.bgColorCb.Location = new System.Drawing.Point(128, 28);
            this.bgColorCb.Name = "bgColorCb";
            this.bgColorCb.Size = new System.Drawing.Size(218, 24);
            this.bgColorCb.TabIndex = 1;
            // 
            // chartProperties
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(341, 383);
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
            this.marginGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomMarginEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trailingSpaceEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMarginEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leadingSpaceEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightMarginEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftMarginEd)).EndInit();
            this.chartGb.ResumeLayout(false);
            this.chartGb.PerformLayout();
            this.panZoomGb.ResumeLayout(false);
            this.panZoomGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomPercEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panMovePercEd)).EndInit();
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
        private common.controls.numberTextBox panMoveMinCountEd;
        private baseClass.controls.baseLabel zoomRateLbl;
        private common.controls.numberTextBox zoomMinCountEd;
        private common.controls.numberTextBox panMouseRateEd;
        private System.Windows.Forms.GroupBox marginGb;
        private baseClass.controls.baseLabel rightMarginLbl;
        private baseClass.controls.baseLabel leftMarginLbl;
        private System.Windows.Forms.NumericUpDown rightMarginEd;
        private System.Windows.Forms.NumericUpDown leftMarginEd;
        private baseClass.controls.baseLabel backgroundLbl;
        private baseClass.controls.baseLabel panMouseRateLbl;
        private System.Windows.Forms.NumericUpDown panMovePercEd;
        private System.Windows.Forms.NumericUpDown zoomPercEd;
        private baseClass.controls.baseLabel movePerPanLbl;
        private baseClass.controls.baseLabel bottomMarginLbl;
        private System.Windows.Forms.NumericUpDown bottomMarginEd;
        private baseClass.controls.baseLabel topMarginLbl;
        private System.Windows.Forms.NumericUpDown topMarginEd;
        private baseClass.controls.baseLabel marginAndSpaceLbl;
        private baseClass.controls.baseLabel trailingSpaceLbl;
        private System.Windows.Forms.NumericUpDown trailingSpaceEd;
        private baseClass.controls.baseLabel leadingSpaceLbl;
        private System.Windows.Forms.NumericUpDown leadingSpaceEd;

    }
}