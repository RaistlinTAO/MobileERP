namespace MobileShopERP.Function
{
    partial class frmMarketDebt
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBackup = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSellers = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lsvMarketDebt = new System.Windows.Forms.ListView();
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
            this.cmdView = new System.Windows.Forms.Button();
            this.cmdViewMonth = new System.Windows.Forms.Button();
            this.cmdFix = new System.Windows.Forms.Button();
            this.dtpFixDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaster = new System.Windows.Forms.TextBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.rbisFix = new System.Windows.Forms.RadioButton();
            this.rbisDebt = new System.Windows.Forms.RadioButton();
            this.dtpViewTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpAddFixDate = new System.Windows.Forms.DateTimePicker();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbInCircle = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtName.Location = new System.Drawing.Point(428, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(186, 21);
            this.txtName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "欠款事项:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "欠款时间";
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(65, 20);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(112, 21);
            this.dtpTime.TabIndex = 19;
            this.dtpTime.ValueChanged += new System.EventHandler(this.dtpTime_ValueChanged);
            // 
            // txtCash
            // 
            this.txtCash.Location = new System.Drawing.Point(735, 20);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(43, 21);
            this.txtCash.TabIndex = 18;
            this.txtCash.Text = "0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(670, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "欠款金额:";
            // 
            // txtBackup
            // 
            this.txtBackup.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtBackup.Location = new System.Drawing.Point(195, 48);
            this.txtBackup.Name = "txtBackup";
            this.txtBackup.Size = new System.Drawing.Size(131, 21);
            this.txtBackup.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(154, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "备注:";
            // 
            // cmbSellers
            // 
            this.cmbSellers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSellers.FormattingEnabled = true;
            this.cmbSellers.Location = new System.Drawing.Point(65, 47);
            this.cmbSellers.Name = "cmbSellers";
            this.cmbSellers.Size = new System.Drawing.Size(73, 20);
            this.cmbSellers.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "经办人:";
            // 
            // cmdAdd
            // 
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdd.Location = new System.Drawing.Point(714, 48);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(64, 21);
            this.cmdAdd.TabIndex = 27;
            this.cmdAdd.Text = "增加";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lsvMarketDebt
            // 
            this.lsvMarketDebt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lsvMarketDebt.FullRowSelect = true;
            this.lsvMarketDebt.GridLines = true;
            this.lsvMarketDebt.Location = new System.Drawing.Point(6, 20);
            this.lsvMarketDebt.MultiSelect = false;
            this.lsvMarketDebt.Name = "lsvMarketDebt";
            this.lsvMarketDebt.Size = new System.Drawing.Size(772, 266);
            this.lsvMarketDebt.TabIndex = 28;
            this.lsvMarketDebt.UseCompatibleStateImageBehavior = false;
            this.lsvMarketDebt.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "欠款时间";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "债权人";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "欠款事项";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "欠款金额";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "经办人";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "备注";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "还款状态";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "还款时间";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "非现金还款";
            this.columnHeader10.Width = 75;
            // 
            // cmdView
            // 
            this.cmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdView.Location = new System.Drawing.Point(125, 20);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(92, 21);
            this.cmdView.TabIndex = 29;
            this.cmdView.Text = "查看指定日";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // cmdViewMonth
            // 
            this.cmdViewMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewMonth.Location = new System.Drawing.Point(223, 20);
            this.cmdViewMonth.Name = "cmdViewMonth";
            this.cmdViewMonth.Size = new System.Drawing.Size(92, 21);
            this.cmdViewMonth.TabIndex = 31;
            this.cmdViewMonth.Text = "查看指定月";
            this.cmdViewMonth.UseVisualStyleBackColor = true;
            this.cmdViewMonth.Click += new System.EventHandler(this.cmdViewMonth_Click);
            // 
            // cmdFix
            // 
            this.cmdFix.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFix.Location = new System.Drawing.Point(656, 52);
            this.cmdFix.Name = "cmdFix";
            this.cmdFix.Size = new System.Drawing.Size(122, 21);
            this.cmdFix.TabIndex = 32;
            this.cmdFix.Text = "标记选中项为已还款";
            this.cmdFix.UseVisualStyleBackColor = true;
            this.cmdFix.Click += new System.EventHandler(this.cmdFix_Click);
            // 
            // dtpFixDate
            // 
            this.dtpFixDate.Location = new System.Drawing.Point(547, 52);
            this.dtpFixDate.Name = "dtpFixDate";
            this.dtpFixDate.Size = new System.Drawing.Size(103, 21);
            this.dtpFixDate.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 34;
            this.label3.Text = "债权人:";
            // 
            // txtMaster
            // 
            this.txtMaster.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtMaster.Location = new System.Drawing.Point(252, 20);
            this.txtMaster.Name = "txtMaster";
            this.txtMaster.Size = new System.Drawing.Size(83, 21);
            this.txtMaster.TabIndex = 35;
            // 
            // cmdDelete
            // 
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDelete.Location = new System.Drawing.Point(106, 52);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(92, 21);
            this.cmdDelete.TabIndex = 36;
            this.cmdDelete.Text = "删除选中项";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // rbisFix
            // 
            this.rbisFix.AutoSize = true;
            this.rbisFix.Checked = true;
            this.rbisFix.ForeColor = System.Drawing.Color.Crimson;
            this.rbisFix.Location = new System.Drawing.Point(492, 51);
            this.rbisFix.Name = "rbisFix";
            this.rbisFix.Size = new System.Drawing.Size(47, 16);
            this.rbisFix.TabIndex = 37;
            this.rbisFix.TabStop = true;
            this.rbisFix.Text = "结帐";
            this.rbisFix.UseVisualStyleBackColor = true;
            this.rbisFix.CheckedChanged += new System.EventHandler(this.rbisFix_CheckedChanged);
            // 
            // rbisDebt
            // 
            this.rbisDebt.AutoSize = true;
            this.rbisDebt.ForeColor = System.Drawing.Color.Crimson;
            this.rbisDebt.Location = new System.Drawing.Point(439, 51);
            this.rbisDebt.Name = "rbisDebt";
            this.rbisDebt.Size = new System.Drawing.Size(47, 16);
            this.rbisDebt.TabIndex = 38;
            this.rbisDebt.Text = "欠款";
            this.rbisDebt.UseVisualStyleBackColor = true;
            // 
            // dtpViewTime
            // 
            this.dtpViewTime.Location = new System.Drawing.Point(8, 20);
            this.dtpViewTime.Name = "dtpViewTime";
            this.dtpViewTime.Size = new System.Drawing.Size(111, 21);
            this.dtpViewTime.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(546, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 40;
            this.label7.Text = "结帐时间";
            // 
            // dtpAddFixDate
            // 
            this.dtpAddFixDate.Location = new System.Drawing.Point(605, 48);
            this.dtpAddFixDate.Name = "dtpAddFixDate";
            this.dtpAddFixDate.Size = new System.Drawing.Size(103, 21);
            this.dtpAddFixDate.TabIndex = 39;
            // 
            // cmdEdit
            // 
            this.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEdit.Location = new System.Drawing.Point(8, 52);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(92, 21);
            this.cmdEdit.TabIndex = 41;
            this.cmdEdit.Text = "修改选中项";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.ckbInCircle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCash);
            this.groupBox1.Controls.Add(this.dtpAddFixDate);
            this.groupBox1.Controls.Add(this.dtpTime);
            this.groupBox1.Controls.Add(this.rbisDebt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbisFix);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaster);
            this.groupBox1.Controls.Add(this.cmbSellers);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBackup);
            this.groupBox1.Controls.Add(this.cmdAdd);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 77);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加欠款";
            // 
            // ckbInCircle
            // 
            this.ckbInCircle.AutoSize = true;
            this.ckbInCircle.Checked = true;
            this.ckbInCircle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbInCircle.Location = new System.Drawing.Point(338, 51);
            this.ckbInCircle.Name = "ckbInCircle";
            this.ckbInCircle.Size = new System.Drawing.Size(72, 16);
            this.ckbInCircle.TabIndex = 41;
            this.ckbInCircle.Text = "现金还款";
            this.ckbInCircle.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lsvMarketDebt);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 292);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "欠款条目";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dtpViewTime);
            this.groupBox3.Controls.Add(this.cmdView);
            this.groupBox3.Controls.Add(this.cmdViewMonth);
            this.groupBox3.Controls.Add(this.cmdEdit);
            this.groupBox3.Controls.Add(this.cmdFix);
            this.groupBox3.Controls.Add(this.cmdDelete);
            this.groupBox3.Controls.Add(this.dtpFixDate);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(6, 401);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(784, 79);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作选项";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(796, 486);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            // 
            // frmMarketDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::MobileShopERP.Properties.Resources._22;
            this.ClientSize = new System.Drawing.Size(820, 510);
            this.Controls.Add(this.groupBox4);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMarketDebt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmMarketDebt_Load);
            this.Shown += new System.EventHandler(this.frmMarketDebt_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBackup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSellers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ListView lsvMarketDebt;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button cmdView;
        private System.Windows.Forms.Button cmdViewMonth;
        private System.Windows.Forms.Button cmdFix;
        private System.Windows.Forms.DateTimePicker dtpFixDate;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaster;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.RadioButton rbisFix;
        private System.Windows.Forms.RadioButton rbisDebt;
        private System.Windows.Forms.DateTimePicker dtpViewTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpAddFixDate;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ckbInCircle;
        private System.Windows.Forms.ColumnHeader columnHeader10;

    }
}