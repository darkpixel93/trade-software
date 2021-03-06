namespace baseClass.forms
{
    partial class feedbackEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(feedbackEdit));
            this.infoPnl = new System.Windows.Forms.Panel();
            this.feedbackTypeCb = new baseClass.controls.cbFeedbackCat();
            this.messagesSource = new System.Windows.Forms.BindingSource(this.components);
            this.senderEd = new common.controls.baseTextBox();
            this.senderNameLbl = new common.controls.baseLabel();
            this.dateTimeEd = new common.controls.baseDate();
            this.dateTimeLbl = new common.controls.baseLabel();
            this.feedbackTypeLbl = new common.controls.baseLabel();
            this.contentEd = new common.controls.baseTextBox();
            this.contentLbl = new common.controls.baseLabel();
            this.codeLbl = new common.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            this.infoPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messagesSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolBox.Location = new System.Drawing.Point(20, 430);
            this.toolBox.Size = new System.Drawing.Size(309, 44);
            this.toolBox.TabIndex = 10;
            // 
            // exitBtn
            // 
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.Location = new System.Drawing.Point(146, 5);
            this.exitBtn.Size = new System.Drawing.Size(131, 35);
            this.exitBtn.Text = "Close";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveBtn
            // 
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.Location = new System.Drawing.Point(15, 5);
            this.saveBtn.Size = new System.Drawing.Size(131, 35);
            this.saveBtn.Text = "Save";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(764, 7);
            this.deleteBtn.Visible = false;
            // 
            // editBtn
            // 
            this.editBtn.Image = null;
            this.editBtn.Location = new System.Drawing.Point(834, 7);
            this.editBtn.Text = "Lock";
            this.editBtn.Visible = false;
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(694, 7);
            this.addNewBtn.Visible = false;
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(971, 7);
            this.toExcelBtn.Text = "Export";
            this.toExcelBtn.Visible = false;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(904, 7);
            this.findBtn.Visible = false;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(974, 7);
            this.reloadBtn.Visible = false;
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(812, 353);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(812, 312);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(1044, 7);
            this.printBtn.Text = "&Print";
            this.printBtn.Visible = false;
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(1079, 5);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(884, 2);
            this.TitleLbl.Size = new System.Drawing.Size(10, 27);
            this.TitleLbl.Text = "NHẬT KÝ HỆ THỐNG";
            // 
            // infoPnl
            // 
            this.infoPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.infoPnl.Controls.Add(this.feedbackTypeCb);
            this.infoPnl.Controls.Add(this.senderEd);
            this.infoPnl.Controls.Add(this.senderNameLbl);
            this.infoPnl.Controls.Add(this.dateTimeEd);
            this.infoPnl.Controls.Add(this.dateTimeLbl);
            this.infoPnl.Controls.Add(this.feedbackTypeLbl);
            this.infoPnl.Controls.Add(this.contentEd);
            this.infoPnl.Controls.Add(this.contentLbl);
            this.infoPnl.Controls.Add(this.codeLbl);
            this.infoPnl.Controls.Add(this.codeEd);
            this.infoPnl.Location = new System.Drawing.Point(0, 0);
            this.infoPnl.Name = "infoPnl";
            this.infoPnl.Size = new System.Drawing.Size(600, 480);
            this.infoPnl.TabIndex = 1;
            // 
            // feedbackTypeCb
            // 
            this.feedbackTypeCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", this.messagesSource, "Category", true));
            this.feedbackTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.feedbackTypeCb.ItemHeight = 16;
            this.feedbackTypeCb.Location = new System.Drawing.Point(31, 119);
            this.feedbackTypeCb.myValue = "";
            this.feedbackTypeCb.Name = "feedbackTypeCb";
            this.feedbackTypeCb.Size = new System.Drawing.Size(540, 24);
            this.feedbackTypeCb.TabIndex = 20;
            // 
            // messagesSource
            // 
            this.messagesSource.DataMember = "messages";
            this.messagesSource.DataSource = this.myDataSet;
            // 
            // senderEd
            // 
            this.senderEd.Enabled = false;
            this.senderEd.ForeColor = System.Drawing.Color.Black;
            this.senderEd.isRequired = true;
            this.senderEd.isToUpperCase = false;
            this.senderEd.Location = new System.Drawing.Point(31, 73);
            this.senderEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.senderEd.Name = "senderEd";
            this.senderEd.Size = new System.Drawing.Size(540, 23);
            this.senderEd.TabIndex = 10;
            // 
            // senderNameLbl
            // 
            this.senderNameLbl.AutoSize = true;
            this.senderNameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.senderNameLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.senderNameLbl.Location = new System.Drawing.Point(28, 54);
            this.senderNameLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.senderNameLbl.Name = "senderNameLbl";
            this.senderNameLbl.Size = new System.Drawing.Size(79, 16);
            this.senderNameLbl.TabIndex = 265;
            this.senderNameLbl.Text = "Nhà đầu tư";
            // 
            // dateTimeEd
            // 
            this.dateTimeEd.BeepOnError = true;
            this.dateTimeEd.DataBindings.Add(new System.Windows.Forms.Binding("myDateTime", this.messagesSource, "OnDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "G"));
            this.dateTimeEd.Enabled = false;
            this.dateTimeEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dateTimeEd.Location = new System.Drawing.Point(31, 25);
            this.dateTimeEd.Mask = "00/00/0000";
            this.dateTimeEd.myDateTime = new System.DateTime(((long)(0)));
            this.dateTimeEd.Name = "dateTimeEd";
            this.dateTimeEd.Size = new System.Drawing.Size(144, 23);
            this.dateTimeEd.TabIndex = 1;
            // 
            // dateTimeLbl
            // 
            this.dateTimeLbl.AutoSize = true;
            this.dateTimeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.dateTimeLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimeLbl.Location = new System.Drawing.Point(31, 5);
            this.dateTimeLbl.Name = "dateTimeLbl";
            this.dateTimeLbl.Size = new System.Drawing.Size(67, 16);
            this.dateTimeLbl.TabIndex = 262;
            this.dateTimeLbl.Text = "Ngày/Giờ";
            // 
            // feedbackTypeLbl
            // 
            this.feedbackTypeLbl.AutoSize = true;
            this.feedbackTypeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.feedbackTypeLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.feedbackTypeLbl.Location = new System.Drawing.Point(31, 99);
            this.feedbackTypeLbl.Name = "feedbackTypeLbl";
            this.feedbackTypeLbl.Size = new System.Drawing.Size(52, 16);
            this.feedbackTypeLbl.TabIndex = 257;
            this.feedbackTypeLbl.Text = "Chủ đề";
            // 
            // contentEd
            // 
            this.contentEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.messagesSource, "MsgBody", true));
            this.contentEd.ForeColor = System.Drawing.Color.Black;
            this.contentEd.isRequired = true;
            this.contentEd.isToUpperCase = false;
            this.contentEd.Location = new System.Drawing.Point(31, 169);
            this.contentEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.contentEd.Multiline = true;
            this.contentEd.Name = "contentEd";
            this.contentEd.Size = new System.Drawing.Size(540, 255);
            this.contentEd.TabIndex = 30;
            // 
            // contentLbl
            // 
            this.contentLbl.AutoSize = true;
            this.contentLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.contentLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.contentLbl.Location = new System.Drawing.Point(28, 149);
            this.contentLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.contentLbl.Name = "contentLbl";
            this.contentLbl.Size = new System.Drawing.Size(63, 16);
            this.contentLbl.TabIndex = 260;
            this.contentLbl.Text = "Nội dung";
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.codeLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.codeLbl.Location = new System.Drawing.Point(173, 5);
            this.codeLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(28, 16);
            this.codeLbl.TabIndex = 258;
            this.codeLbl.Text = "Số ";
            this.codeLbl.Visible = false;
            // 
            // codeEd
            // 
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.messagesSource, "MsgId", true));
            this.codeEd.Enabled = false;
            this.codeEd.ForeColor = System.Drawing.Color.Black;
            this.codeEd.isRequired = true;
            this.codeEd.isToUpperCase = false;
            this.codeEd.Location = new System.Drawing.Point(175, 25);
            this.codeEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(146, 23);
            this.codeEd.TabIndex = 2;
            this.codeEd.Visible = false;
            // 
            // feedbackEdit
            // 
            this.ClientSize = new System.Drawing.Size(600, 506);
            this.Controls.Add(this.infoPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "feedbackEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Phan hoi";
            this.Controls.SetChildIndex(this.infoPnl, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            this.infoPnl.ResumeLayout(false);
            this.infoPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messagesSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.controls.baseLabel dateTimeLbl;
        protected common.controls.baseLabel feedbackTypeLbl;
        protected common.controls.baseTextBox contentEd;
        protected common.controls.baseLabel contentLbl;
        protected common.controls.baseLabel codeLbl;
        protected common.controls.baseTextBox codeEd;
        protected common.controls.baseLabel senderNameLbl;
        protected System.Windows.Forms.Panel infoPnl;
        protected common.controls.baseDate dateTimeEd;
        protected common.controls.baseTextBox senderEd;
        protected System.Windows.Forms.BindingSource messagesSource;
        protected baseClass.controls.cbFeedbackCat feedbackTypeCb;
    }
}

