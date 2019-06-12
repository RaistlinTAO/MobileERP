namespace LongXiangTools.View
{
    partial class frmOther
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOther));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdQA = new System.Windows.Forms.Button();
            this.cmdUpdateNews = new System.Windows.Forms.Button();
            this.cmdSecondHands = new System.Windows.Forms.Button();
            this.cmdCleanSCache = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdCheckMarketPrice = new System.Windows.Forms.Button();
            this.cmdChangePrice = new System.Windows.Forms.Button();
            this.cmdClearECache = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdResumeDB = new System.Windows.Forms.Button();
            this.cmdBackupDB = new System.Windows.Forms.Button();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdUCAdmin = new System.Windows.Forms.Button();
            this.cmdShopAdmin = new System.Windows.Forms.Button();
            this.cmdSiteAdmin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            this.picLoad = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmdQA);
            this.groupBox1.Controls.Add(this.cmdUpdateNews);
            this.groupBox1.Controls.Add(this.cmdSecondHands);
            this.groupBox1.Controls.Add(this.cmdCleanSCache);
            this.groupBox1.Controls.Add(this.cmdUpdate);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 91);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "龙翔网站操作";
            // 
            // cmdQA
            // 
            this.cmdQA.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdQA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdQA.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdQA.Location = new System.Drawing.Point(32, 51);
            this.cmdQA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdQA.Name = "cmdQA";
            this.cmdQA.Size = new System.Drawing.Size(127, 22);
            this.cmdQA.TabIndex = 6;
            this.cmdQA.Text = "用户咨询管理";
            this.cmdQA.UseVisualStyleBackColor = false;
            this.cmdQA.Click += new System.EventHandler(cmdQA_Click);
            // 
            // cmdUpdateNews
            // 
            this.cmdUpdateNews.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdUpdateNews.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUpdateNews.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdUpdateNews.Location = new System.Drawing.Point(359, 51);
            this.cmdUpdateNews.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdUpdateNews.Name = "cmdUpdateNews";
            this.cmdUpdateNews.Size = new System.Drawing.Size(127, 22);
            this.cmdUpdateNews.TabIndex = 5;
            this.cmdUpdateNews.Text = "核查网站新闻";
            this.cmdUpdateNews.UseVisualStyleBackColor = false;
            this.cmdUpdateNews.Click += new System.EventHandler(this.cmdUpdateNews_Click);
            // 
            // cmdSecondHands
            // 
            this.cmdSecondHands.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdSecondHands.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSecondHands.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdSecondHands.Location = new System.Drawing.Point(32, 21);
            this.cmdSecondHands.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSecondHands.Name = "cmdSecondHands";
            this.cmdSecondHands.Size = new System.Drawing.Size(127, 22);
            this.cmdSecondHands.TabIndex = 4;
            this.cmdSecondHands.Text = "二手信息管理";
            this.cmdSecondHands.UseVisualStyleBackColor = false;
            this.cmdSecondHands.Click += new System.EventHandler(cmdSecondHands_Click);
            // 
            // cmdCleanSCache
            // 
            this.cmdCleanSCache.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdCleanSCache.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCleanSCache.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdCleanSCache.Location = new System.Drawing.Point(359, 21);
            this.cmdCleanSCache.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCleanSCache.Name = "cmdCleanSCache";
            this.cmdCleanSCache.Size = new System.Drawing.Size(127, 22);
            this.cmdCleanSCache.TabIndex = 3;
            this.cmdCleanSCache.Text = "重置网站缓存";
            this.cmdCleanSCache.UseVisualStyleBackColor = false;
            this.cmdCleanSCache.Click += new System.EventHandler(this.cmdCleanSCache_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUpdate.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdUpdate.Location = new System.Drawing.Point(197, 21);
            this.cmdUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(127, 22);
            this.cmdUpdate.TabIndex = 2;
            this.cmdUpdate.Text = "采集网站新闻";
            this.cmdUpdate.UseVisualStyleBackColor = false;
            this.cmdUpdate.Click += new System.EventHandler(cmdUpdate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cmdCheckMarketPrice);
            this.groupBox2.Controls.Add(this.cmdChangePrice);
            this.groupBox2.Controls.Add(this.cmdClearECache);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(13, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 56);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "手机大全操作";
            // 
            // cmdCheckMarketPrice
            // 
            this.cmdCheckMarketPrice.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdCheckMarketPrice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCheckMarketPrice.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdCheckMarketPrice.Location = new System.Drawing.Point(197, 21);
            this.cmdCheckMarketPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCheckMarketPrice.Name = "cmdCheckMarketPrice";
            this.cmdCheckMarketPrice.Size = new System.Drawing.Size(127, 22);
            this.cmdCheckMarketPrice.TabIndex = 5;
            this.cmdCheckMarketPrice.Text = "核查市场价格";
            this.cmdCheckMarketPrice.UseVisualStyleBackColor = false;
            this.cmdCheckMarketPrice.Click += new System.EventHandler(this.cmdCheckMarketPrice_Click);
            // 
            // cmdChangePrice
            // 
            this.cmdChangePrice.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdChangePrice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdChangePrice.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdChangePrice.Location = new System.Drawing.Point(32, 21);
            this.cmdChangePrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdChangePrice.Name = "cmdChangePrice";
            this.cmdChangePrice.Size = new System.Drawing.Size(127, 22);
            this.cmdChangePrice.TabIndex = 4;
            this.cmdChangePrice.Text = "批量修改价格";
            this.cmdChangePrice.UseVisualStyleBackColor = false;
            this.cmdChangePrice.Click += new System.EventHandler(cmdChangePrice_Click);
            // 
            // cmdClearECache
            // 
            this.cmdClearECache.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdClearECache.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdClearECache.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdClearECache.Location = new System.Drawing.Point(358, 21);
            this.cmdClearECache.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdClearECache.Name = "cmdClearECache";
            this.cmdClearECache.Size = new System.Drawing.Size(127, 22);
            this.cmdClearECache.TabIndex = 3;
            this.cmdClearECache.Text = "重置手机大全缓存";
            this.cmdClearECache.UseVisualStyleBackColor = false;
            this.cmdClearECache.Click += new System.EventHandler(this.cmdClearECache_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.cmdResumeDB);
            this.groupBox3.Controls.Add(this.cmdBackupDB);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(488, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(516, 51);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据库操作";
            this.groupBox3.Visible = false;
            // 
            // cmdResumeDB
            // 
            this.cmdResumeDB.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdResumeDB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdResumeDB.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdResumeDB.Location = new System.Drawing.Point(197, 21);
            this.cmdResumeDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdResumeDB.Name = "cmdResumeDB";
            this.cmdResumeDB.Size = new System.Drawing.Size(127, 22);
            this.cmdResumeDB.TabIndex = 5;
            this.cmdResumeDB.Text = "还原数据库";
            this.cmdResumeDB.UseVisualStyleBackColor = false;
            this.cmdResumeDB.Visible = false;
            // 
            // cmdBackupDB
            // 
            this.cmdBackupDB.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdBackupDB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBackupDB.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdBackupDB.Location = new System.Drawing.Point(32, 21);
            this.cmdBackupDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdBackupDB.Name = "cmdBackupDB";
            this.cmdBackupDB.Size = new System.Drawing.Size(127, 22);
            this.cmdBackupDB.TabIndex = 4;
            this.cmdBackupDB.Text = "备份数据库";
            this.cmdBackupDB.UseVisualStyleBackColor = false;
            this.cmdBackupDB.Click += new System.EventHandler(this.cmdBackupDB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SandyBrown;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "LongXiang Operation Tools";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.cmdUCAdmin);
            this.groupBox4.Controls.Add(this.cmdShopAdmin);
            this.groupBox4.Controls.Add(this.cmdSiteAdmin);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(13, 29);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(516, 54);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "网站快捷";
            // 
            // cmdUCAdmin
            // 
            this.cmdUCAdmin.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdUCAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUCAdmin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdUCAdmin.Location = new System.Drawing.Point(358, 21);
            this.cmdUCAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdUCAdmin.Name = "cmdUCAdmin";
            this.cmdUCAdmin.Size = new System.Drawing.Size(127, 22);
            this.cmdUCAdmin.TabIndex = 7;
            this.cmdUCAdmin.Text = "龙翔客户后台";
            this.cmdUCAdmin.UseVisualStyleBackColor = false;
            this.cmdUCAdmin.Click += new System.EventHandler(cmdUCAdmin_Click);
            // 
            // cmdShopAdmin
            // 
            this.cmdShopAdmin.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdShopAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdShopAdmin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdShopAdmin.Location = new System.Drawing.Point(197, 21);
            this.cmdShopAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdShopAdmin.Name = "cmdShopAdmin";
            this.cmdShopAdmin.Size = new System.Drawing.Size(127, 22);
            this.cmdShopAdmin.TabIndex = 6;
            this.cmdShopAdmin.Text = "手机大全后台";
            this.cmdShopAdmin.UseVisualStyleBackColor = false;
            this.cmdShopAdmin.Click += new System.EventHandler(cmdShopAdmin_Click);
            // 
            // cmdSiteAdmin
            // 
            this.cmdSiteAdmin.BackColor = System.Drawing.Color.LavenderBlush;
            this.cmdSiteAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSiteAdmin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmdSiteAdmin.Location = new System.Drawing.Point(32, 21);
            this.cmdSiteAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSiteAdmin.Name = "cmdSiteAdmin";
            this.cmdSiteAdmin.Size = new System.Drawing.Size(127, 22);
            this.cmdSiteAdmin.TabIndex = 5;
            this.cmdSiteAdmin.Text = "龙翔网站后台";
            this.cmdSiteAdmin.UseVisualStyleBackColor = false;
            this.cmdSiteAdmin.Click += new System.EventHandler(cmdSiteAdmin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(514, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(cmdOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Location = new System.Drawing.Point(260, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Design for www.SkyMobile.com.cn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.LawnGreen;
            this.label4.Location = new System.Drawing.Point(135, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(394, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Copyright © 2011 ORG: D.E.M.O.N K9998(Wei Tao) All Rights Reserved";
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.BackColor = System.Drawing.Color.Transparent;
            this.lblLoad.Location = new System.Drawing.Point(278, 260);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(241, 15);
            this.lblLoad.TabIndex = 12;
            this.lblLoad.Text = "Operation is in progress...Please Waiting...";
            this.lblLoad.Visible = false;
            // 
            // picLoad
            // 
            this.picLoad.BackColor = System.Drawing.Color.Transparent;
            this.picLoad.Image = global::LongXiangTools.Properties.Resources.ajax_loader1;
            this.picLoad.Location = new System.Drawing.Point(12, 258);
            this.picLoad.Name = "picLoad";
            this.picLoad.Size = new System.Drawing.Size(220, 19);
            this.picLoad.TabIndex = 13;
            this.picLoad.TabStop = false;
            this.picLoad.Visible = false;
            // 
            // frmOther
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::LongXiangTools.Properties.Resources.windows7_innerlight_by_remixedcat;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(540, 314);
            this.ControlBox = false;
            this.Controls.Add(this.picLoad);
            this.Controls.Add(this.lblLoad);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOther";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Other Operation base on Website";
            this.Load += new System.EventHandler(this.frmOther_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmOther_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmOther_MouseDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdCleanSCache;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdClearECache;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdBackupDB;
        private System.Windows.Forms.SaveFileDialog sfdFile;
        private System.Windows.Forms.Button cmdChangePrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdResumeDB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdUCAdmin;
        private System.Windows.Forms.Button cmdShopAdmin;
        private System.Windows.Forms.Button cmdSiteAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSecondHands;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdCheckMarketPrice;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.PictureBox picLoad;
        private System.Windows.Forms.Button cmdUpdateNews;
        private System.Windows.Forms.Button cmdQA;
    }
}