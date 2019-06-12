namespace MobileShopERP.Function
{
    partial class frmViewProfit
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
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFromTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvPayout = new System.Windows.Forms.ListView();
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBack = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdMonthSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMerge = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "查询时间";
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Location = new System.Drawing.Point(85, 20);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.Size = new System.Drawing.Size(112, 21);
            this.dtpFromTime.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = ":";
            // 
            // lsvPayout
            // 
            this.lsvPayout.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTime,
            this.colName,
            this.colPrice,
            this.colType,
            this.colBack,
            this.colID,
            this.columnHeader1});
            this.lsvPayout.FullRowSelect = true;
            this.lsvPayout.GridLines = true;
            this.lsvPayout.Location = new System.Drawing.Point(6, 20);
            this.lsvPayout.MultiSelect = false;
            this.lsvPayout.Name = "lsvPayout";
            this.lsvPayout.Size = new System.Drawing.Size(772, 348);
            this.lsvPayout.TabIndex = 16;
            this.lsvPayout.UseCompatibleStateImageBehavior = false;
            this.lsvPayout.View = System.Windows.Forms.View.Details;
            // 
            // colTime
            // 
            this.colTime.Text = "支出时间";
            // 
            // colName
            // 
            this.colName.Text = "支出项目";
            this.colName.Width = 150;
            // 
            // colPrice
            // 
            this.colPrice.Text = "支出金额";
            // 
            // colType
            // 
            this.colType.Text = "支出类型";
            // 
            // colBack
            // 
            this.colBack.Text = "备注";
            this.colBack.Width = 260;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            // 
            // cmdSearch
            // 
            this.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSearch.Location = new System.Drawing.Point(552, 20);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(110, 21);
            this.cmdSearch.TabIndex = 17;
            this.cmdSearch.Text = "查询指定日";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDelete.Location = new System.Drawing.Point(675, 374);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(103, 21);
            this.cmdDelete.TabIndex = 18;
            this.cmdDelete.Text = "删除选定记录";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdMonthSearch
            // 
            this.cmdMonthSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMonthSearch.Location = new System.Drawing.Point(668, 20);
            this.cmdMonthSearch.Name = "cmdMonthSearch";
            this.cmdMonthSearch.Size = new System.Drawing.Size(110, 21);
            this.cmdMonthSearch.TabIndex = 19;
            this.cmdMonthSearch.Text = "查询指定月";
            this.cmdMonthSearch.UseVisualStyleBackColor = true;
            this.cmdMonthSearch.Click += new System.EventHandler(this.cmdMonthSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "合计:";
            // 
            // txtMerge
            // 
            this.txtMerge.AutoSize = true;
            this.txtMerge.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMerge.ForeColor = System.Drawing.Color.Crimson;
            this.txtMerge.Location = new System.Drawing.Point(47, 378);
            this.txtMerge.Name = "txtMerge";
            this.txtMerge.Size = new System.Drawing.Size(26, 12);
            this.txtMerge.TabIndex = 21;
            this.txtMerge.Text = "0.0";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dtpFromTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdMonthSearch);
            this.groupBox1.Controls.Add(this.cmdSearch);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 53);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lsvPayout);
            this.groupBox2.Controls.Add(this.cmdDelete);
            this.groupBox2.Controls.Add(this.txtMerge);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 401);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(796, 486);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "计入现金流";
            this.columnHeader1.Width = 90;
            // 
            // frmViewProfit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::MobileShopERP.Properties.Resources._22;
            this.ClientSize = new System.Drawing.Size(820, 510);
            this.Controls.Add(this.groupBox3);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewProfit";
            this.Text = "frmViewProfit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFromTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvPayout;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colBack;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdMonthSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtMerge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}