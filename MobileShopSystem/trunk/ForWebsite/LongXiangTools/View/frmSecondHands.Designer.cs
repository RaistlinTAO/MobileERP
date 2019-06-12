namespace LongXiangTools.View
{
    partial class frmSecondHands
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
            this.lsvSecondHands = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.S = new System.Windows.Forms.Button();
            this.cmdViewPicture = new System.Windows.Forms.Button();
            this.cmdViewDetail = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.dtpSecondHands = new System.Windows.Forms.DateTimePicker();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdSearchK = new System.Windows.Forms.Button();
            this.picWait = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
            this.SuspendLayout();
            // 
            // lsvSecondHands
            // 
            this.lsvSecondHands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lsvSecondHands.FullRowSelect = true;
            this.lsvSecondHands.GridLines = true;
            this.lsvSecondHands.Location = new System.Drawing.Point(12, 52);
            this.lsvSecondHands.Name = "lsvSecondHands";
            this.lsvSecondHands.Size = new System.Drawing.Size(747, 349);
            this.lsvSecondHands.TabIndex = 0;
            this.lsvSecondHands.UseCompatibleStateImageBehavior = false;
            this.lsvSecondHands.View = System.Windows.Forms.View.Details;
            this.lsvSecondHands.Click += new System.EventHandler(this.lsvSecondHands_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "机器名称";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "添加人";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "手机品牌";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "手机新旧";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "有无发票";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "包装配件";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "购机地点";
            this.columnHeader11.Width = 120;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "购机时间";
            this.columnHeader12.Width = 80;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "龙翔报价";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "龙翔二手平台管理";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(757, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(14, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "龙翔报价:";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPrice.Location = new System.Drawing.Point(77, 407);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(67, 21);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // S
            // 
            this.S.BackColor = System.Drawing.Color.Transparent;
            this.S.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.S.ForeColor = System.Drawing.Color.White;
            this.S.Location = new System.Drawing.Point(663, 405);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(96, 23);
            this.S.TabIndex = 5;
            this.S.Text = "全部更新";
            this.S.UseVisualStyleBackColor = false;
            this.S.Click += new System.EventHandler(this.S_Click);
            // 
            // cmdViewPicture
            // 
            this.cmdViewPicture.BackColor = System.Drawing.Color.Transparent;
            this.cmdViewPicture.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewPicture.ForeColor = System.Drawing.Color.White;
            this.cmdViewPicture.Location = new System.Drawing.Point(497, 405);
            this.cmdViewPicture.Name = "cmdViewPicture";
            this.cmdViewPicture.Size = new System.Drawing.Size(96, 23);
            this.cmdViewPicture.TabIndex = 6;
            this.cmdViewPicture.Text = "查看图片";
            this.cmdViewPicture.UseVisualStyleBackColor = false;
            this.cmdViewPicture.Click += new System.EventHandler(this.cmdViewPicture_Click);
            // 
            // cmdViewDetail
            // 
            this.cmdViewDetail.BackColor = System.Drawing.Color.Transparent;
            this.cmdViewDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetail.ForeColor = System.Drawing.Color.White;
            this.cmdViewDetail.Location = new System.Drawing.Point(395, 405);
            this.cmdViewDetail.Name = "cmdViewDetail";
            this.cmdViewDetail.Size = new System.Drawing.Size(96, 23);
            this.cmdViewDetail.TabIndex = 7;
            this.cmdViewDetail.Text = "查看详细";
            this.cmdViewDetail.UseVisualStyleBackColor = false;
            this.cmdViewDetail.Click += new System.EventHandler(this.cmdViewDetail_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDelete.ForeColor = System.Drawing.Color.White;
            this.cmdDelete.Location = new System.Drawing.Point(279, 405);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(96, 23);
            this.cmdDelete.TabIndex = 8;
            this.cmdDelete.Text = "删除选中";
            this.cmdDelete.UseVisualStyleBackColor = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // dtpSecondHands
            // 
            this.dtpSecondHands.Location = new System.Drawing.Point(420, 25);
            this.dtpSecondHands.Name = "dtpSecondHands";
            this.dtpSecondHands.Size = new System.Drawing.Size(155, 21);
            this.dtpSecondHands.TabIndex = 9;
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackColor = System.Drawing.Color.Transparent;
            this.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSearch.ForeColor = System.Drawing.Color.GhostWhite;
            this.cmdSearch.Location = new System.Drawing.Point(581, 24);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(63, 22);
            this.cmdSearch.TabIndex = 10;
            this.cmdSearch.Text = "查询";
            this.cmdSearch.UseVisualStyleBackColor = false;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdSearchK
            // 
            this.cmdSearchK.BackColor = System.Drawing.Color.Transparent;
            this.cmdSearchK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSearchK.ForeColor = System.Drawing.Color.GhostWhite;
            this.cmdSearchK.Location = new System.Drawing.Point(650, 24);
            this.cmdSearchK.Name = "cmdSearchK";
            this.cmdSearchK.Size = new System.Drawing.Size(109, 22);
            this.cmdSearchK.TabIndex = 11;
            this.cmdSearchK.Text = "查询前1000条";
            this.cmdSearchK.UseVisualStyleBackColor = false;
            this.cmdSearchK.Click += new System.EventHandler(this.cmdSearchK_Click);
            // 
            // picWait
            // 
            this.picWait.BackColor = System.Drawing.Color.Transparent;
            this.picWait.Image = global::LongXiangTools.Properties.Resources.ajax_loader3;
            this.picWait.Location = new System.Drawing.Point(12, 27);
            this.picWait.Name = "picWait";
            this.picWait.Size = new System.Drawing.Size(56, 19);
            this.picWait.TabIndex = 12;
            this.picWait.TabStop = false;
            this.picWait.Visible = false;
            // 
            // frmSecondHands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::LongXiangTools.Properties.Resources._123;
            this.ClientSize = new System.Drawing.Size(771, 437);
            this.Controls.Add(this.picWait);
            this.Controls.Add(this.cmdSearchK);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.dtpSecondHands);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdViewDetail);
            this.Controls.Add(this.cmdViewPicture);
            this.Controls.Add(this.S);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsvSecondHands);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSecondHands";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "二手平台管理";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmSecondHands_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvSecondHands;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button S;
        private System.Windows.Forms.Button cmdViewPicture;
        private System.Windows.Forms.Button cmdViewDetail;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.DateTimePicker dtpSecondHands;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdSearchK;
        private System.Windows.Forms.PictureBox picWait;

    }
}