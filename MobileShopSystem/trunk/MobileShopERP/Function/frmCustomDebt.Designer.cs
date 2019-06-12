namespace MobileShopERP.Function
{
    partial class frmCustomDebt
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
            this.lsvDebt = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdFinish = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdMonthSearch = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.dtpFromTime = new System.Windows.Forms.DateTimePicker();
            this.cmdConvert2Payout = new System.Windows.Forms.Button();
            this.txtMaster = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmdViewAll = new System.Windows.Forms.Button();
            this.cmdSplitFix = new System.Windows.Forms.Button();
            this.dtpFixDate = new System.Windows.Forms.DateTimePicker();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBackDebtBackup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBackDebtType = new System.Windows.Forms.ComboBox();
            this.cmdViewAllUnFix = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSearchUser = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckbinCircle = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvDebt
            // 
            this.lsvDebt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lsvDebt.FullRowSelect = true;
            this.lsvDebt.GridLines = true;
            this.lsvDebt.Location = new System.Drawing.Point(6, 47);
            this.lsvDebt.Name = "lsvDebt";
            this.lsvDebt.Size = new System.Drawing.Size(772, 241);
            this.lsvDebt.TabIndex = 0;
            this.lsvDebt.UseCompatibleStateImageBehavior = false;
            this.lsvDebt.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "欠款日期";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "欠款人";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "欠款详情";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "欠款额";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "到帐方式";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "欠款状态";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "还款时间";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "剩余金额";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "还款方式";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "还款备注";
            this.columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "现金流";
            this.columnHeader12.Width = 50;
            // 
            // cmdFinish
            // 
            this.cmdFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFinish.ForeColor = System.Drawing.Color.Black;
            this.cmdFinish.Location = new System.Drawing.Point(692, 20);
            this.cmdFinish.Name = "cmdFinish";
            this.cmdFinish.Size = new System.Drawing.Size(86, 21);
            this.cmdFinish.TabIndex = 1;
            this.cmdFinish.Text = "标记为到帐";
            this.cmdFinish.UseVisualStyleBackColor = true;
            this.cmdFinish.Click += new System.EventHandler(this.cmdFinish_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDelete.ForeColor = System.Drawing.Color.Black;
            this.cmdDelete.Location = new System.Drawing.Point(530, 294);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(86, 21);
            this.cmdDelete.TabIndex = 9;
            this.cmdDelete.Text = "删除选定记录";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdMonthSearch
            // 
            this.cmdMonthSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMonthSearch.Location = new System.Drawing.Point(208, 20);
            this.cmdMonthSearch.Name = "cmdMonthSearch";
            this.cmdMonthSearch.Size = new System.Drawing.Size(86, 21);
            this.cmdMonthSearch.TabIndex = 24;
            this.cmdMonthSearch.Text = "查询指定月份";
            this.cmdMonthSearch.UseVisualStyleBackColor = true;
            this.cmdMonthSearch.Click += new System.EventHandler(this.cmdMonthSearch_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSearch.Location = new System.Drawing.Point(116, 20);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(86, 21);
            this.cmdSearch.TabIndex = 23;
            this.cmdSearch.Text = "查询指定日期";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Location = new System.Drawing.Point(6, 20);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.Size = new System.Drawing.Size(104, 21);
            this.dtpFromTime.TabIndex = 20;
            // 
            // cmdConvert2Payout
            // 
            this.cmdConvert2Payout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConvert2Payout.ForeColor = System.Drawing.Color.Black;
            this.cmdConvert2Payout.Location = new System.Drawing.Point(359, 294);
            this.cmdConvert2Payout.Name = "cmdConvert2Payout";
            this.cmdConvert2Payout.Size = new System.Drawing.Size(85, 21);
            this.cmdConvert2Payout.TabIndex = 25;
            this.cmdConvert2Payout.Text = "转为固定支出";
            this.cmdConvert2Payout.UseVisualStyleBackColor = true;
            this.cmdConvert2Payout.Click += new System.EventHandler(this.cmdConvert2Payout_Click);
            // 
            // txtMaster
            // 
            this.txtMaster.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtMaster.Location = new System.Drawing.Point(290, 20);
            this.txtMaster.Name = "txtMaster";
            this.txtMaster.Size = new System.Drawing.Size(200, 21);
            this.txtMaster.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "欠款人:";
            // 
            // cmdAdd
            // 
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdd.Location = new System.Drawing.Point(699, 47);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(79, 21);
            this.cmdAdd.TabIndex = 46;
            this.cmdAdd.Text = "增加";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtName.Location = new System.Drawing.Point(290, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 21);
            this.txtName.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "欠款事项:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "欠款时间";
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(71, 20);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(115, 21);
            this.dtpTime.TabIndex = 38;
            this.dtpTime.ValueChanged += new System.EventHandler(this.dtpTime_ValueChanged);
            // 
            // txtCash
            // 
            this.txtCash.Location = new System.Drawing.Point(71, 47);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(115, 21);
            this.txtCash.TabIndex = 37;
            this.txtCash.Text = "0.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "欠款金额:";
            // 
            // cmbPayment
            // 
            this.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayment.FormattingEnabled = true;
            this.cmbPayment.Items.AddRange(new object[] {
            "刷卡支付",
            "欠款支付",
            "支付宝"});
            this.cmbPayment.Location = new System.Drawing.Point(663, 20);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(115, 20);
            this.cmbPayment.TabIndex = 84;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(598, 26);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 12);
            this.label23.TabIndex = 83;
            this.label23.Text = "到帐方式:";
            // 
            // cmdViewAll
            // 
            this.cmdViewAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewAll.Location = new System.Drawing.Point(300, 20);
            this.cmdViewAll.Name = "cmdViewAll";
            this.cmdViewAll.Size = new System.Drawing.Size(86, 21);
            this.cmdViewAll.TabIndex = 85;
            this.cmdViewAll.Text = "查看全部";
            this.cmdViewAll.UseVisualStyleBackColor = true;
            this.cmdViewAll.Click += new System.EventHandler(this.cmdViewAll_Click);
            // 
            // cmdSplitFix
            // 
            this.cmdSplitFix.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSplitFix.ForeColor = System.Drawing.Color.Black;
            this.cmdSplitFix.Location = new System.Drawing.Point(6, 19);
            this.cmdSplitFix.Name = "cmdSplitFix";
            this.cmdSplitFix.Size = new System.Drawing.Size(86, 21);
            this.cmdSplitFix.TabIndex = 86;
            this.cmdSplitFix.Text = "分期付款";
            this.cmdSplitFix.UseVisualStyleBackColor = true;
            this.cmdSplitFix.Click += new System.EventHandler(this.cmdSplitFix_Click);
            // 
            // dtpFixDate
            // 
            this.dtpFixDate.Location = new System.Drawing.Point(300, 19);
            this.dtpFixDate.Name = "dtpFixDate";
            this.dtpFixDate.Size = new System.Drawing.Size(105, 21);
            this.dtpFixDate.TabIndex = 88;
            // 
            // cmdEdit
            // 
            this.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEdit.ForeColor = System.Drawing.Color.Black;
            this.cmdEdit.Location = new System.Drawing.Point(692, 294);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(86, 21);
            this.cmdEdit.TabIndex = 89;
            this.cmdEdit.Text = "修改选定记录";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Visible = false;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtBackDebtBackup);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbBackDebtType);
            this.groupBox1.Controls.Add(this.cmdFinish);
            this.groupBox1.Controls.Add(this.dtpFixDate);
            this.groupBox1.Controls.Add(this.cmdSplitFix);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(6, 429);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 51);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "还款选项";
            // 
            // txtBackDebtBackup
            // 
            this.txtBackDebtBackup.Location = new System.Drawing.Point(544, 19);
            this.txtBackDebtBackup.Name = "txtBackDebtBackup";
            this.txtBackDebtBackup.Size = new System.Drawing.Size(142, 21);
            this.txtBackDebtBackup.TabIndex = 91;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(503, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 90;
            this.label4.Text = "备注:";
            // 
            // cmbBackDebtType
            // 
            this.cmbBackDebtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackDebtType.FormattingEnabled = true;
            this.cmbBackDebtType.Items.AddRange(new object[] {
            "转帐还款",
            "现金还款",
            "支付宝还款"});
            this.cmbBackDebtType.Location = new System.Drawing.Point(411, 20);
            this.cmbBackDebtType.Name = "cmbBackDebtType";
            this.cmbBackDebtType.Size = new System.Drawing.Size(86, 20);
            this.cmbBackDebtType.TabIndex = 89;
            // 
            // cmdViewAllUnFix
            // 
            this.cmdViewAllUnFix.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewAllUnFix.Location = new System.Drawing.Point(392, 20);
            this.cmdViewAllUnFix.Name = "cmdViewAllUnFix";
            this.cmdViewAllUnFix.Size = new System.Drawing.Size(103, 21);
            this.cmdViewAllUnFix.TabIndex = 90;
            this.cmdViewAllUnFix.Text = "查看全部未到账";
            this.cmdViewAllUnFix.UseVisualStyleBackColor = true;
            this.cmdViewAllUnFix.Click += new System.EventHandler(this.cmdViewAllUnFix_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cmdEdit);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmdDelete);
            this.groupBox2.Controls.Add(this.cmdSearchUser);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.cmdViewAllUnFix);
            this.groupBox2.Controls.Add(this.lsvDebt);
            this.groupBox2.Controls.Add(this.cmdConvert2Payout);
            this.groupBox2.Controls.Add(this.dtpFromTime);
            this.groupBox2.Controls.Add(this.cmdMonthSearch);
            this.groupBox2.Controls.Add(this.cmdViewAll);
            this.groupBox2.Controls.Add(this.cmdSearch);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 321);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "欠款记录";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(569, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 93;
            this.label1.Text = "欠款人:";
            // 
            // cmdSearchUser
            // 
            this.cmdSearchUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSearchUser.Location = new System.Drawing.Point(719, 20);
            this.cmdSearchUser.Name = "cmdSearchUser";
            this.cmdSearchUser.Size = new System.Drawing.Size(59, 21);
            this.cmdSearchUser.TabIndex = 92;
            this.cmdSearchUser.Text = "查询";
            this.cmdSearchUser.UseVisualStyleBackColor = true;
            this.cmdSearchUser.Click += new System.EventHandler(this.cmdSearchUser_Click);
            // 
            // txtUser
            // 
            this.txtUser.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtUser.Location = new System.Drawing.Point(622, 20);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(91, 21);
            this.txtUser.TabIndex = 91;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.ckbinCircle);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtCash);
            this.groupBox3.Controls.Add(this.cmbPayment);
            this.groupBox3.Controls.Add(this.dtpTime);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMaster);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmdAdd);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(6, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(784, 76);
            this.groupBox3.TabIndex = 92;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "手工添加欠款";
            // 
            // ckbinCircle
            // 
            this.ckbinCircle.AutoSize = true;
            this.ckbinCircle.Checked = true;
            this.ckbinCircle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbinCircle.Location = new System.Drawing.Point(600, 49);
            this.ckbinCircle.Name = "ckbinCircle";
            this.ckbinCircle.Size = new System.Drawing.Size(84, 16);
            this.ckbinCircle.TabIndex = 85;
            this.ckbinCircle.Text = "计入现金流";
            this.ckbinCircle.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(796, 486);
            this.groupBox4.TabIndex = 93;
            this.groupBox4.TabStop = false;
            // 
            // frmCustomDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::MobileShopERP.Properties.Resources._22;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(820, 510);
            this.Controls.Add(this.groupBox4);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCustomDebt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmCustomDebt";
            this.Load += new System.EventHandler(this.frmCustomDebt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvDebt;
        private System.Windows.Forms.Button cmdFinish;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button cmdMonthSearch;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.DateTimePicker dtpFromTime;
        private System.Windows.Forms.Button cmdConvert2Payout;
        private System.Windows.Forms.TextBox txtMaster;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button cmdViewAll;
        private System.Windows.Forms.Button cmdSplitFix;
        private System.Windows.Forms.DateTimePicker dtpFixDate;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdViewAllUnFix;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSearchUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.ComboBox cmbBackDebtType;
        private System.Windows.Forms.TextBox txtBackDebtBackup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.CheckBox ckbinCircle;
        private System.Windows.Forms.ColumnHeader columnHeader12;
    }
}