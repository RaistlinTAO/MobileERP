namespace MobileShopERP.Function
{
    partial class frmMarketDebtEditor
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
            this.label7 = new System.Windows.Forms.Label();
            this.dtpAddFixDate = new System.Windows.Forms.DateTimePicker();
            this.rbisDebt = new System.Windows.Forms.RadioButton();
            this.rbisFix = new System.Windows.Forms.RadioButton();
            this.txtMaster = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtBackup = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSellers = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 57;
            this.label7.Text = "结帐时间";
            // 
            // dtpAddFixDate
            // 
            this.dtpAddFixDate.Location = new System.Drawing.Point(353, 137);
            this.dtpAddFixDate.Name = "dtpAddFixDate";
            this.dtpAddFixDate.Size = new System.Drawing.Size(103, 21);
            this.dtpAddFixDate.TabIndex = 56;
            // 
            // rbisDebt
            // 
            this.rbisDebt.AutoSize = true;
            this.rbisDebt.Location = new System.Drawing.Point(518, 102);
            this.rbisDebt.Name = "rbisDebt";
            this.rbisDebt.Size = new System.Drawing.Size(47, 16);
            this.rbisDebt.TabIndex = 55;
            this.rbisDebt.Text = "欠款";
            this.rbisDebt.UseVisualStyleBackColor = true;
            // 
            // rbisFix
            // 
            this.rbisFix.AutoSize = true;
            this.rbisFix.Checked = true;
            this.rbisFix.Location = new System.Drawing.Point(581, 102);
            this.rbisFix.Name = "rbisFix";
            this.rbisFix.Size = new System.Drawing.Size(47, 16);
            this.rbisFix.TabIndex = 54;
            this.rbisFix.TabStop = true;
            this.rbisFix.Text = "结帐";
            this.rbisFix.UseVisualStyleBackColor = true;
            this.rbisFix.CheckedChanged += new System.EventHandler(this.rbisFix_CheckedChanged);
            // 
            // txtMaster
            // 
            this.txtMaster.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtMaster.Location = new System.Drawing.Point(353, 59);
            this.txtMaster.Name = "txtMaster";
            this.txtMaster.Size = new System.Drawing.Size(103, 21);
            this.txtMaster.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 52;
            this.label3.Text = "债权人:";
            // 
            // cmdOK
            // 
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(658, 215);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(84, 21);
            this.cmdOK.TabIndex = 51;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtBackup
            // 
            this.txtBackup.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtBackup.Location = new System.Drawing.Point(353, 97);
            this.txtBackup.Name = "txtBackup";
            this.txtBackup.Size = new System.Drawing.Size(103, 21);
            this.txtBackup.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "备注:";
            // 
            // cmbSellers
            // 
            this.cmbSellers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSellers.FormattingEnabled = true;
            this.cmbSellers.Location = new System.Drawing.Point(112, 98);
            this.cmbSellers.Name = "cmbSellers";
            this.cmbSellers.Size = new System.Drawing.Size(112, 20);
            this.cmbSellers.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "经办人:";
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtName.Location = new System.Drawing.Point(581, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(114, 21);
            this.txtName.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "欠款事项:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 44;
            this.label4.Text = "欠款时间";
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(112, 59);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(112, 21);
            this.dtpTime.TabIndex = 43;
            // 
            // txtCash
            // 
            this.txtCash.Location = new System.Drawing.Point(112, 137);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(112, 21);
            this.txtCash.TabIndex = 42;
            this.txtCash.Text = "0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "欠款金额:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(761, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 58;
            this.label8.Text = "X";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
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
            this.groupBox1.Controls.Add(this.txtMaster);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbSellers);
            this.groupBox1.Controls.Add(this.cmdOK);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBackup);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 242);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改市场欠款";
            // 
            // frmMarketDebtEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImage = global::MobileShopERP.Properties.Resources.frmMarketDebtEditor;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(772, 266);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMarketDebtEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmMarketDebtEditor";
            this.Load += new System.EventHandler(this.frmMarketDebtEditor_Load);
            this.Shown += new System.EventHandler(this.frmMarketDebtEditor_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpAddFixDate;
        private System.Windows.Forms.RadioButton rbisDebt;
        private System.Windows.Forms.RadioButton rbisFix;
        private System.Windows.Forms.TextBox txtMaster;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TextBox txtBackup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSellers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}