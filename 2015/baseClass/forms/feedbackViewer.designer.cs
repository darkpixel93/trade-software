namespace baseClass.forms
{
    partial class feedbackViewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(feedbackViewer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateRange = new common.controls.dateRange0();
            this.dataGrid = new common.controls.baseDataGridView();
            this.onDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senderColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.investorSource = new System.Windows.Forms.BindingSource(this.components);
            this.myTempDS = new databases.tmpDS();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.contentEd2 = new common.controls.baseTextBox();
            this.contentChk2 = new common.controls.baseCheckBox();
            this.accountEd = new baseClass.controls.txtInvestor();
            this.feedbackTypeCb2 = new baseClass.controls.cbFeedbackCat();
            this.accountChk = new common.controls.baseCheckBox();
            this.feedbackTypeChk2 = new common.controls.baseCheckBox();
            this.infoPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messagesSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTempDS)).BeginInit();
            this.optionPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimeLbl
            // 
            this.dateTimeLbl.Location = new System.Drawing.Point(148, 5);
            this.dateTimeLbl.Size = new System.Drawing.Size(72, 16);
            this.dateTimeLbl.Text = "Date Time";
            // 
            // feedbackTypeLbl
            // 
            this.feedbackTypeLbl.Location = new System.Drawing.Point(15, 99);
            this.feedbackTypeLbl.Size = new System.Drawing.Size(57, 16);
            this.feedbackTypeLbl.Text = "Subject";
            // 
            // contentEd
            // 
            this.contentEd.Location = new System.Drawing.Point(15, 169);
            this.contentEd.Size = new System.Drawing.Size(483, 255);
            // 
            // contentLbl
            // 
            this.contentLbl.Location = new System.Drawing.Point(12, 149);
            this.contentLbl.Size = new System.Drawing.Size(67, 16);
            this.contentLbl.Text = "Contents";
            // 
            // codeLbl
            // 
            this.codeLbl.Location = new System.Drawing.Point(18, 8);
            this.codeLbl.Size = new System.Drawing.Size(40, 16);
            this.codeLbl.Text = "Code";
            this.codeLbl.Visible = true;
            // 
            // codeEd
            // 
            this.codeEd.Location = new System.Drawing.Point(18, 25);
            this.codeEd.Size = new System.Drawing.Size(129, 23);
            this.codeEd.Visible = true;
            // 
            // senderNameLbl
            // 
            this.senderNameLbl.Location = new System.Drawing.Point(15, 55);
            // 
            // infoPnl
            // 
            this.infoPnl.Location = new System.Drawing.Point(560, 2);
            this.infoPnl.Size = new System.Drawing.Size(518, 437);
            // 
            // dateTimeEd
            // 
            this.dateTimeEd.Location = new System.Drawing.Point(147, 25);
            this.dateTimeEd.Size = new System.Drawing.Size(113, 23);
            // 
            // senderEd
            // 
            this.senderEd.Location = new System.Drawing.Point(17, 71);
            this.senderEd.Size = new System.Drawing.Size(481, 23);
            // 
            // messagesSource
            // 
            this.messagesSource.CurrentChanged += new System.EventHandler(this.messagesSource_CurrentChanged);
            // 
            // feedbackTypeCb
            // 
            this.feedbackTypeCb.Location = new System.Drawing.Point(17, 119);
            this.feedbackTypeCb.Size = new System.Drawing.Size(481, 24);
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(426, 25);
            this.toolBox.Size = new System.Drawing.Size(104, 76);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(7, 39);
            this.exitBtn.Size = new System.Drawing.Size(92, 31);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(789, 44);
            this.saveBtn.Text = "Send";
            this.saveBtn.Visible = false;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(861, 74);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(927, 74);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(791, 74);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(707, 31);
            // 
            // reloadBtn
            // 
            this.reloadBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reloadBtn.Location = new System.Drawing.Point(7, 4);
            this.reloadBtn.Size = new System.Drawing.Size(92, 31);
            this.reloadBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.reloadBtn.Visible = true;
            // 
            // dateRange
            // 
            this.dateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRange.Location = new System.Drawing.Point(19, 3);
            this.dateRange.Margin = new System.Windows.Forms.Padding(4);
            this.dateRange.Name = "dateRange";
            this.dateRange.Size = new System.Drawing.Size(394, 50);
            this.dateRange.TabIndex = 1;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.onDateColumn,
            this.contentColumn,
            this.senderColumn});
            this.dataGrid.DataSource = this.messagesSource;
            this.dataGrid.Location = new System.Drawing.Point(0, 114);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersWidth = 40;
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(559, 325);
            this.dataGrid.TabIndex = 1;
            // 
            // onDateColumn
            // 
            this.onDateColumn.DataPropertyName = "OnDate";
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.onDateColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.onDateColumn.HeaderText = "OnDate";
            this.onDateColumn.Name = "onDateColumn";
            this.onDateColumn.ReadOnly = true;
            this.onDateColumn.Width = 120;
            // 
            // contentColumn
            // 
            this.contentColumn.DataPropertyName = "MsgBody";
            this.contentColumn.HeaderText = "MsgBody";
            this.contentColumn.Name = "contentColumn";
            this.contentColumn.ReadOnly = true;
            this.contentColumn.Width = 250;
            // 
            // senderColumn
            // 
            this.senderColumn.DataPropertyName = "SenderId";
            this.senderColumn.DataSource = this.investorSource;
            this.senderColumn.DisplayMember = "account";
            this.senderColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.senderColumn.HeaderText = "SenderId";
            this.senderColumn.Name = "senderColumn";
            this.senderColumn.ReadOnly = true;
            this.senderColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.senderColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.senderColumn.ValueMember = "code";
            // 
            // investorSource
            // 
            this.investorSource.DataMember = "investor";
            this.investorSource.DataSource = this.myTempDS;
            // 
            // myTempDS
            // 
            this.myTempDS.DataSetName = "tempDS";
            this.myTempDS.EnforceConstraints = false;
            this.myTempDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // optionPnl
            // 
            this.optionPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.optionPnl.Controls.Add(this.contentEd2);
            this.optionPnl.Controls.Add(this.contentChk2);
            this.optionPnl.Controls.Add(this.accountEd);
            this.optionPnl.Controls.Add(this.feedbackTypeCb2);
            this.optionPnl.Controls.Add(this.accountChk);
            this.optionPnl.Controls.Add(this.feedbackTypeChk2);
            this.optionPnl.Controls.Add(this.dateRange);
            this.optionPnl.Location = new System.Drawing.Point(0, 2);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(559, 110);
            this.optionPnl.TabIndex = 1;
            // 
            // contentEd2
            // 
            this.contentEd2.Enabled = false;
            this.contentEd2.isRequired = true;
            this.contentEd2.isToUpperCase = true;
            this.contentEd2.Location = new System.Drawing.Point(285, 78);
            this.contentEd2.MaxLength = 20;
            this.contentEd2.Name = "contentEd2";
            this.contentEd2.Size = new System.Drawing.Size(128, 23);
            this.contentEd2.TabIndex = 9;
            // 
            // contentChk2
            // 
            this.contentChk2.AutoSize = true;
            this.contentChk2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentChk2.Location = new System.Drawing.Point(287, 56);
            this.contentChk2.Name = "contentChk2";
            this.contentChk2.Size = new System.Drawing.Size(82, 20);
            this.contentChk2.TabIndex = 8;
            this.contentChk2.Text = "Nội dung";
            this.contentChk2.UseVisualStyleBackColor = true;
            this.contentChk2.CheckedChanged += new System.EventHandler(this.contentChk2_CheckedChanged);
            // 
            // accountEd
            // 
            this.accountEd.Enabled = false;
            this.accountEd.isRequired = true;
            this.accountEd.isToUpperCase = true;
            this.accountEd.Location = new System.Drawing.Point(188, 78);
            this.accountEd.MaxLength = 20;
            this.accountEd.Name = "accountEd";
            this.accountEd.Size = new System.Drawing.Size(96, 23);
            this.accountEd.TabIndex = 5;
            // 
            // feedbackTypeCb2
            // 
            this.feedbackTypeCb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.feedbackTypeCb2.Enabled = false;
            this.feedbackTypeCb2.FormattingEnabled = true;
            this.feedbackTypeCb2.Location = new System.Drawing.Point(21, 78);
            this.feedbackTypeCb2.myValue = "";
            this.feedbackTypeCb2.Name = "feedbackTypeCb2";
            this.feedbackTypeCb2.Size = new System.Drawing.Size(169, 24);
            this.feedbackTypeCb2.TabIndex = 7;
            // 
            // accountChk
            // 
            this.accountChk.AutoSize = true;
            this.accountChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountChk.Location = new System.Drawing.Point(189, 55);
            this.accountChk.Name = "accountChk";
            this.accountChk.Size = new System.Drawing.Size(88, 20);
            this.accountChk.TabIndex = 4;
            this.accountChk.Text = "Tài khỏan";
            this.accountChk.UseVisualStyleBackColor = true;
            this.accountChk.CheckedChanged += new System.EventHandler(this.accountChk_CheckedChanged);
            // 
            // feedbackTypeChk2
            // 
            this.feedbackTypeChk2.AutoSize = true;
            this.feedbackTypeChk2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedbackTypeChk2.Location = new System.Drawing.Point(23, 55);
            this.feedbackTypeChk2.Name = "feedbackTypeChk2";
            this.feedbackTypeChk2.Size = new System.Drawing.Size(53, 20);
            this.feedbackTypeChk2.TabIndex = 6;
            this.feedbackTypeChk2.Text = "Loại";
            this.feedbackTypeChk2.UseVisualStyleBackColor = true;
            this.feedbackTypeChk2.CheckedChanged += new System.EventHandler(this.feedbackTypeChk2_CheckedChanged);
            // 
            // feedbackViewer
            // 
            this.ClientSize = new System.Drawing.Size(1079, 461);
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.dataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "feedbackViewer";
            this.ResizeEnd += new System.EventHandler(this.Form_ResizeEnd);
            this.Controls.SetChildIndex(this.infoPnl, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.optionPnl, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.infoPnl.ResumeLayout(false);
            this.infoPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messagesSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTempDS)).EndInit();
            this.optionPnl.ResumeLayout(false);
            this.optionPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.controls.baseDataGridView dataGrid;
        protected baseClass.controls.cbFeedbackCat feedbackTypeCb2;
        protected common.controls.dateRange0 dateRange;
        protected System.Windows.Forms.Panel optionPnl;
        protected common.controls.baseCheckBox feedbackTypeChk2;
        protected common.controls.baseCheckBox accountChk;
        protected baseClass.controls.txtInvestor accountEd;
        protected databases.tmpDS myTempDS;
        private System.Windows.Forms.BindingSource investorSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn onDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn senderColumn;
        protected common.controls.baseTextBox contentEd2;
        protected common.controls.baseCheckBox contentChk2;
    }
}

