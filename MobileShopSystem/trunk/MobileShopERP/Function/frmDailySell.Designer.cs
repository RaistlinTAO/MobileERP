namespace LongXiangCRM.Function
{
    partial class frmDailySell
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
            this.cmdViewPhone = new System.Windows.Forms.Button();
            this.cmdViewBuyer = new System.Windows.Forms.Button();
            this.lsvPhones = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdViewDaily = new System.Windows.Forms.Button();
            this.cmdViewMonth = new System.Windows.Forms.Button();
            this.dtpDaily = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdViewPhone
            // 
            this.cmdViewPhone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewPhone.Location = new System.Drawing.Point(668, 20);
            this.cmdViewPhone.Name = "cmdViewPhone";
            this.cmdViewPhone.Size = new System.Drawing.Size(110, 23);
            this.cmdViewPhone.TabIndex = 1;
            this.cmdViewPhone.Text = "查看该手机";
            this.cmdViewPhone.UseVisualStyleBackColor = true;
            this.cmdViewPhone.Click += new System.EventHandler(this.cmdViewPhone_Click);
            // 
            // cmdViewBuyer
            // 
            this.cmdViewBuyer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewBuyer.Location = new System.Drawing.Point(552, 20);
            this.cmdViewBuyer.Name = "cmdViewBuyer";
            this.cmdViewBuyer.Size = new System.Drawing.Size(110, 23);
            this.cmdViewBuyer.TabIndex = 2;
            this.cmdViewBuyer.Text = "查看该用户";
            this.cmdViewBuyer.UseVisualStyleBackColor = true;
            this.cmdViewBuyer.Click += new System.EventHandler(this.cmdViewBuyer_Click);
            // 
            // lsvPhones
            // 
            this.lsvPhones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader9,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21});
            this.lsvPhones.FullRowSelect = true;
            this.lsvPhones.GridLines = true;
            this.lsvPhones.Location = new System.Drawing.Point(6, 52);
            this.lsvPhones.MultiSelect = false;
            this.lsvPhones.Name = "lsvPhones";
            this.lsvPhones.Size = new System.Drawing.Size(772, 342);
            this.lsvPhones.TabIndex = 50;
            this.lsvPhones.UseCompatibleStateImageBehavior = false;
            this.lsvPhones.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "购买时间";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "手机厂商";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "手机型号";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "IMEI";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "销售价格";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "手机成本";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "配件";
            this.columnHeader7.Width = 38;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "销售人员";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "保修";
            this.columnHeader10.Width = 38;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "保修类型";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "保修时间";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "退货";
            this.columnHeader13.Width = 0;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "供货商";
            this.columnHeader14.Width = 50;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "配件价格";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "配件成本";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "行货";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "ID";
            this.columnHeader9.Width = 30;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "客户姓名";
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "手机号";
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "保修卡号";
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "支付方式";
            this.columnHeader21.Width = 0;
            // 
            // cmdViewDaily
            // 
            this.cmdViewDaily.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDaily.Location = new System.Drawing.Point(204, 20);
            this.cmdViewDaily.Name = "cmdViewDaily";
            this.cmdViewDaily.Size = new System.Drawing.Size(112, 23);
            this.cmdViewDaily.TabIndex = 51;
            this.cmdViewDaily.Text = "查看指定日销售";
            this.cmdViewDaily.UseVisualStyleBackColor = true;
            this.cmdViewDaily.Click += new System.EventHandler(this.cmdViewDaily_Click);
            // 
            // cmdViewMonth
            // 
            this.cmdViewMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewMonth.Location = new System.Drawing.Point(322, 20);
            this.cmdViewMonth.Name = "cmdViewMonth";
            this.cmdViewMonth.Size = new System.Drawing.Size(112, 23);
            this.cmdViewMonth.TabIndex = 52;
            this.cmdViewMonth.Text = "查看指定月销售";
            this.cmdViewMonth.UseVisualStyleBackColor = true;
            this.cmdViewMonth.Click += new System.EventHandler(this.cmdViewMonth_Click);
            // 
            // dtpDaily
            // 
            this.dtpDaily.Location = new System.Drawing.Point(22, 22);
            this.dtpDaily.Name = "dtpDaily";
            this.dtpDaily.Size = new System.Drawing.Size(123, 21);
            this.dtpDaily.TabIndex = 53;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dtpDaily);
            this.groupBox1.Controls.Add(this.cmdViewPhone);
            this.groupBox1.Controls.Add(this.cmdViewBuyer);
            this.groupBox1.Controls.Add(this.cmdViewMonth);
            this.groupBox1.Controls.Add(this.cmdViewDaily);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 54);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能选择";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lsvPhones);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 400);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(683, 28);
            this.label1.TabIndex = 51;
            this.label1.Text = "若需要删除销售记录,请使用查看该用户后,删除用户下的手机记录.如果需要删除用户,则必须先删除所有绑定的手机后进行删除用户操作.否则系统默认为手机为退货,而不是直接" +
    "删除";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(796, 486);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            // 
            // frmDailySell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::LongXiangCRM.Properties.Resources._22;
            this.ClientSize = new System.Drawing.Size(820, 510);
            this.Controls.Add(this.groupBox3);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDailySell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmDailySell";
            this.Load += new System.EventHandler(this.frmDailySell_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdViewPhone;
        private System.Windows.Forms.Button cmdViewBuyer;
        private System.Windows.Forms.ListView lsvPhones;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button cmdViewDaily;
        private System.Windows.Forms.Button cmdViewMonth;
        private System.Windows.Forms.DateTimePicker dtpDaily;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}