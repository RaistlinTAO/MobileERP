namespace MobileShopERP.Function
{
    partial class frmReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.pgbSaveDaily = new System.Windows.Forms.ProgressBar();
            this.cmdSaveDaily = new System.Windows.Forms.Button();
            this.cmdDailyPath = new System.Windows.Forms.Button();
            this.txtDailyPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.pgbSaveYear = new System.Windows.Forms.ProgressBar();
            this.cmdSaveYear = new System.Windows.Forms.Button();
            this.cmdYearPath = new System.Windows.Forms.Button();
            this.txtYearPath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.pgbSaveMonth = new System.Windows.Forms.ProgressBar();
            this.cmdMonthPath = new System.Windows.Forms.Button();
            this.cmdSaveMonth = new System.Windows.Forms.Button();
            this.txtMonthPath = new System.Windows.Forms.TextBox();
            this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.pgbSaveDaily);
            this.groupBox1.Controls.Add(this.cmdSaveDaily);
            this.groupBox1.Controls.Add(this.cmdDailyPath);
            this.groupBox1.Controls.Add(this.txtDailyPath);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "指定日报表";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(6, 96);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(122, 21);
            this.dtpDate.TabIndex = 4;
            // 
            // pgbSaveDaily
            // 
            this.pgbSaveDaily.Location = new System.Drawing.Point(6, 57);
            this.pgbSaveDaily.Name = "pgbSaveDaily";
            this.pgbSaveDaily.Size = new System.Drawing.Size(772, 19);
            this.pgbSaveDaily.TabIndex = 3;
            // 
            // cmdSaveDaily
            // 
            this.cmdSaveDaily.Enabled = false;
            this.cmdSaveDaily.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSaveDaily.Location = new System.Drawing.Point(650, 97);
            this.cmdSaveDaily.Name = "cmdSaveDaily";
            this.cmdSaveDaily.Size = new System.Drawing.Size(128, 23);
            this.cmdSaveDaily.TabIndex = 2;
            this.cmdSaveDaily.Text = "生成";
            this.cmdSaveDaily.UseVisualStyleBackColor = true;
            this.cmdSaveDaily.Visible = false;
            this.cmdSaveDaily.Click += new System.EventHandler(this.cmdSaveDaily_Click);
            // 
            // cmdDailyPath
            // 
            this.cmdDailyPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDailyPath.Location = new System.Drawing.Point(680, 20);
            this.cmdDailyPath.Name = "cmdDailyPath";
            this.cmdDailyPath.Size = new System.Drawing.Size(98, 21);
            this.cmdDailyPath.TabIndex = 1;
            this.cmdDailyPath.Tag = "";
            this.cmdDailyPath.Text = "设置目录";
            this.cmdDailyPath.UseVisualStyleBackColor = true;
            this.cmdDailyPath.Click += new System.EventHandler(this.cmdDailyPath_Click);
            // 
            // txtDailyPath
            // 
            this.txtDailyPath.Enabled = false;
            this.txtDailyPath.Location = new System.Drawing.Point(6, 20);
            this.txtDailyPath.Name = "txtDailyPath";
            this.txtDailyPath.Size = new System.Drawing.Size(668, 21);
            this.txtDailyPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dtpYear);
            this.groupBox2.Controls.Add(this.pgbSaveYear);
            this.groupBox2.Controls.Add(this.cmdSaveYear);
            this.groupBox2.Controls.Add(this.cmdYearPath);
            this.groupBox2.Controls.Add(this.txtYearPath);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 351);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 119);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "年度报表";
            this.groupBox2.Visible = false;
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(6, 89);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(122, 21);
            this.dtpYear.TabIndex = 6;
            // 
            // pgbSaveYear
            // 
            this.pgbSaveYear.Location = new System.Drawing.Point(6, 58);
            this.pgbSaveYear.Name = "pgbSaveYear";
            this.pgbSaveYear.Size = new System.Drawing.Size(772, 19);
            this.pgbSaveYear.TabIndex = 5;
            // 
            // cmdSaveYear
            // 
            this.cmdSaveYear.Enabled = false;
            this.cmdSaveYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSaveYear.Location = new System.Drawing.Point(650, 90);
            this.cmdSaveYear.Name = "cmdSaveYear";
            this.cmdSaveYear.Size = new System.Drawing.Size(128, 23);
            this.cmdSaveYear.TabIndex = 4;
            this.cmdSaveYear.Text = "生成";
            this.cmdSaveYear.UseVisualStyleBackColor = true;
            this.cmdSaveYear.Click += new System.EventHandler(this.cmdSaveYear_Click);
            // 
            // cmdYearPath
            // 
            this.cmdYearPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdYearPath.Location = new System.Drawing.Point(680, 20);
            this.cmdYearPath.Name = "cmdYearPath";
            this.cmdYearPath.Size = new System.Drawing.Size(98, 21);
            this.cmdYearPath.TabIndex = 3;
            this.cmdYearPath.Tag = "";
            this.cmdYearPath.Text = "设置目录";
            this.cmdYearPath.UseVisualStyleBackColor = true;
            this.cmdYearPath.Click += new System.EventHandler(this.cmdYearPath_Click);
            // 
            // txtYearPath
            // 
            this.txtYearPath.Enabled = false;
            this.txtYearPath.Location = new System.Drawing.Point(6, 20);
            this.txtYearPath.Name = "txtYearPath";
            this.txtYearPath.Size = new System.Drawing.Size(668, 21);
            this.txtYearPath.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dtpMonth);
            this.groupBox3.Controls.Add(this.pgbSaveMonth);
            this.groupBox3.Controls.Add(this.cmdMonthPath);
            this.groupBox3.Controls.Add(this.cmdSaveMonth);
            this.groupBox3.Controls.Add(this.txtMonthPath);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(6, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(784, 131);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "按月报表";
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "yyyy-MM";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(6, 95);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(122, 21);
            this.dtpMonth.TabIndex = 5;
            // 
            // pgbSaveMonth
            // 
            this.pgbSaveMonth.BackColor = System.Drawing.SystemColors.Control;
            this.pgbSaveMonth.Location = new System.Drawing.Point(6, 57);
            this.pgbSaveMonth.Name = "pgbSaveMonth";
            this.pgbSaveMonth.Size = new System.Drawing.Size(772, 19);
            this.pgbSaveMonth.TabIndex = 4;
            // 
            // cmdMonthPath
            // 
            this.cmdMonthPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMonthPath.Location = new System.Drawing.Point(680, 20);
            this.cmdMonthPath.Name = "cmdMonthPath";
            this.cmdMonthPath.Size = new System.Drawing.Size(98, 21);
            this.cmdMonthPath.TabIndex = 3;
            this.cmdMonthPath.Tag = "";
            this.cmdMonthPath.Text = "设置目录";
            this.cmdMonthPath.UseVisualStyleBackColor = true;
            this.cmdMonthPath.Click += new System.EventHandler(this.cmdMonthPath_Click);
            // 
            // cmdSaveMonth
            // 
            this.cmdSaveMonth.Enabled = false;
            this.cmdSaveMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSaveMonth.Location = new System.Drawing.Point(650, 93);
            this.cmdSaveMonth.Name = "cmdSaveMonth";
            this.cmdSaveMonth.Size = new System.Drawing.Size(128, 23);
            this.cmdSaveMonth.TabIndex = 3;
            this.cmdSaveMonth.Text = "生成";
            this.cmdSaveMonth.UseVisualStyleBackColor = true;
            this.cmdSaveMonth.Visible = false;
            this.cmdSaveMonth.Click += new System.EventHandler(this.cmdSaveMonth_Click);
            // 
            // txtMonthPath
            // 
            this.txtMonthPath.Enabled = false;
            this.txtMonthPath.Location = new System.Drawing.Point(6, 20);
            this.txtMonthPath.Name = "txtMonthPath";
            this.txtMonthPath.Size = new System.Drawing.Size(668, 21);
            this.txtMonthPath.TabIndex = 2;
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
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // frmReport
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
            this.Name = "frmReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.Shown += new System.EventHandler(this.frmReport_Shown);
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

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdDailyPath;
        private System.Windows.Forms.TextBox txtDailyPath;
        private System.Windows.Forms.Button cmdYearPath;
        private System.Windows.Forms.TextBox txtYearPath;
        private System.Windows.Forms.Button cmdMonthPath;
        private System.Windows.Forms.TextBox txtMonthPath;
        private System.Windows.Forms.FolderBrowserDialog fbdMain;
        private System.Windows.Forms.Button cmdSaveDaily;
        private System.Windows.Forms.Button cmdSaveYear;
        private System.Windows.Forms.Button cmdSaveMonth;
        private System.Windows.Forms.ProgressBar pgbSaveDaily;
        private System.Windows.Forms.ProgressBar pgbSaveYear;
        private System.Windows.Forms.ProgressBar pgbSaveMonth;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}