namespace setup
{
    partial class main
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
            this.phanLoaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myMenu = new System.Windows.Forms.MenuStrip();
            this.systemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.selectConfFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.utilityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // phanLoaiToolStripMenuItem
            // 
            this.phanLoaiToolStripMenuItem.Name = "phanLoaiToolStripMenuItem";
            this.phanLoaiToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.phanLoaiToolStripMenuItem.Text = "Phân loại";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.userToolStripMenuItem.Text = "Người sử dụng";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.loginToolStripMenuItem.Text = "Đăng nhập";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(199, 6);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.setupToolStripMenuItem.Text = "Thiết lập hệ thống";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(199, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "Kết thúc";
            // 
            // myMenu
            // 
            this.myMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemMenuItem,
            this.utilityMenuItem,
            this.aboutMenuItem});
            this.myMenu.Location = new System.Drawing.Point(0, 0);
            this.myMenu.Name = "myMenu";
            this.myMenu.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.myMenu.Size = new System.Drawing.Size(1284, 26);
            this.myMenu.TabIndex = 13;
            this.myMenu.Text = "menuStrip";
            // 
            // systemMenuItem
            // 
            this.systemMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbConfigMenuItem,
            this.toolStripSeparator8,
            this.selectConfFileMenuItem,
            this.toolStripSeparator7,
            this.toolStripMenuItem5});
            this.systemMenuItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemMenuItem.Name = "systemMenuItem";
            this.systemMenuItem.Size = new System.Drawing.Size(77, 20);
            this.systemMenuItem.Text = "Hệ thống";
            // 
            // dbConfigMenuItem
            // 
            this.dbConfigMenuItem.Image = global::setup.Properties.Resources.save;
            this.dbConfigMenuItem.Name = "dbConfigMenuItem";
            this.dbConfigMenuItem.Size = new System.Drawing.Size(202, 22);
            this.dbConfigMenuItem.Text = "Tạo tệp cấu hình";
            this.dbConfigMenuItem.Click += new System.EventHandler(this.dbConfigMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(199, 6);
            // 
            // selectConfFileMenuItem
            // 
            this.selectConfFileMenuItem.Enabled = false;
            this.selectConfFileMenuItem.Image = global::setup.Properties.Resources.open;
            this.selectConfFileMenuItem.Name = "selectConfFileMenuItem";
            this.selectConfFileMenuItem.Size = new System.Drawing.Size(202, 22);
            this.selectConfFileMenuItem.Text = "Chọn tệp cấu hình";
            this.selectConfFileMenuItem.Click += new System.EventHandler(this.selectConfFileMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(199, 6);
            this.toolStripSeparator7.Visible = false;
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::setup.Properties.Resources.close;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem5.Text = "Kết thúc";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // utilityMenuItem
            // 
            this.utilityMenuItem.Enabled = false;
            this.utilityMenuItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilityMenuItem.Name = "utilityMenuItem";
            this.utilityMenuItem.Size = new System.Drawing.Size(71, 20);
            this.utilityMenuItem.Text = "Tiện ích";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(80, 20);
            this.aboutMenuItem.Text = "Thông tin";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // main
            // 
            this.ClientSize = new System.Drawing.Size(1284, 746);
            this.Controls.Add(this.myMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Name = "main";
            this.Tag = "setup 04Sept07";
            this.Text = "Thiet lap he thong";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.myMenu, 0);
            this.myMenu.ResumeLayout(false);
            this.myMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem phanLoaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip myMenu;
        private System.Windows.Forms.ToolStripMenuItem systemMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dbConfigMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilityMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem selectConfFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}

