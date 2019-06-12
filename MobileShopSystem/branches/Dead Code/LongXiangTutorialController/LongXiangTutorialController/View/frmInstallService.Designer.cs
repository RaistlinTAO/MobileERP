namespace LongXiangTutorialController.View
{
    partial class frmInstallService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstallService));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckbAutoUpdateNotify = new System.Windows.Forms.CheckBox();
            this.ckbAutoUpdate = new System.Windows.Forms.CheckBox();
            this.ckbUpdateNotify = new System.Windows.Forms.CheckBox();
            this.ckbHighClass = new System.Windows.Forms.CheckBox();
            this.ckbStartWithWindows = new System.Windows.Forms.CheckBox();
            this.ckbNoBusy = new System.Windows.Forms.CheckBox();
            this.cmdInstall = new System.Windows.Forms.Button();
            this.fbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbJAVA = new System.Windows.Forms.RadioButton();
            this.lsvSoftware = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rbWP7 = new System.Windows.Forms.RadioButton();
            this.rbAndroid = new System.Windows.Forms.RadioButton();
            this.rbSymbian3 = new System.Windows.Forms.RadioButton();
            this.rbWM65 = new System.Windows.Forms.RadioButton();
            this.rbiOS = new System.Windows.Forms.RadioButton();
            this.rbSymbian5 = new System.Windows.Forms.RadioButton();
            this.x = new System.Windows.Forms.GroupBox();
            this.cmdCVSPath = new System.Windows.Forms.Button();
            this.txtCVSPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.x.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmdSelect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSavePath);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "更新设置";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(656, 20);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(54, 21);
            this.cmdSelect.TabIndex = 2;
            this.cmdSelect.Text = "选择";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "小时";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Enabled = false;
            this.txtSavePath.Location = new System.Drawing.Point(278, 20);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(372, 21);
            this.txtSavePath.TabIndex = 1;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(82, 20);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(44, 21);
            this.txtTime.TabIndex = 1;
            this.txtTime.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "本地保存目录:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "更新间隔:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.ckbAutoUpdateNotify);
            this.groupBox3.Controls.Add(this.ckbAutoUpdate);
            this.groupBox3.Controls.Add(this.ckbUpdateNotify);
            this.groupBox3.Controls.Add(this.ckbHighClass);
            this.groupBox3.Controls.Add(this.ckbStartWithWindows);
            this.groupBox3.Controls.Add(this.ckbNoBusy);
            this.groupBox3.Location = new System.Drawing.Point(12, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(716, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "高级设置";
            // 
            // ckbAutoUpdateNotify
            // 
            this.ckbAutoUpdateNotify.AutoSize = true;
            this.ckbAutoUpdateNotify.Checked = true;
            this.ckbAutoUpdateNotify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAutoUpdateNotify.Location = new System.Drawing.Point(525, 42);
            this.ckbAutoUpdateNotify.Name = "ckbAutoUpdateNotify";
            this.ckbAutoUpdateNotify.Size = new System.Drawing.Size(168, 16);
            this.ckbAutoUpdateNotify.TabIndex = 8;
            this.ckbAutoUpdateNotify.Text = "更新网站数据完成后通知我";
            this.ckbAutoUpdateNotify.UseVisualStyleBackColor = true;
            // 
            // ckbAutoUpdate
            // 
            this.ckbAutoUpdate.AutoSize = true;
            this.ckbAutoUpdate.Checked = true;
            this.ckbAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAutoUpdate.Location = new System.Drawing.Point(288, 42);
            this.ckbAutoUpdate.Name = "ckbAutoUpdate";
            this.ckbAutoUpdate.Size = new System.Drawing.Size(120, 16);
            this.ckbAutoUpdate.TabIndex = 7;
            this.ckbAutoUpdate.Text = "自动更新网站数据";
            this.ckbAutoUpdate.UseVisualStyleBackColor = true;
            this.ckbAutoUpdate.Visible = false;
            // 
            // ckbUpdateNotify
            // 
            this.ckbUpdateNotify.AutoSize = true;
            this.ckbUpdateNotify.Checked = true;
            this.ckbUpdateNotify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbUpdateNotify.Location = new System.Drawing.Point(19, 42);
            this.ckbUpdateNotify.Name = "ckbUpdateNotify";
            this.ckbUpdateNotify.Size = new System.Drawing.Size(120, 16);
            this.ckbUpdateNotify.TabIndex = 6;
            this.ckbUpdateNotify.Text = "当有更新时通知我";
            this.ckbUpdateNotify.UseVisualStyleBackColor = true;
            // 
            // ckbHighClass
            // 
            this.ckbHighClass.AutoSize = true;
            this.ckbHighClass.Checked = true;
            this.ckbHighClass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbHighClass.Location = new System.Drawing.Point(525, 20);
            this.ckbHighClass.Name = "ckbHighClass";
            this.ckbHighClass.Size = new System.Drawing.Size(72, 16);
            this.ckbHighClass.TabIndex = 5;
            this.ckbHighClass.Text = "高优先级";
            this.ckbHighClass.UseVisualStyleBackColor = true;
            // 
            // ckbStartWithWindows
            // 
            this.ckbStartWithWindows.AutoSize = true;
            this.ckbStartWithWindows.Checked = true;
            this.ckbStartWithWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbStartWithWindows.Location = new System.Drawing.Point(288, 20);
            this.ckbStartWithWindows.Name = "ckbStartWithWindows";
            this.ckbStartWithWindows.Size = new System.Drawing.Size(84, 16);
            this.ckbStartWithWindows.TabIndex = 4;
            this.ckbStartWithWindows.Text = "开机自启动";
            this.ckbStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // ckbNoBusy
            // 
            this.ckbNoBusy.AutoSize = true;
            this.ckbNoBusy.Checked = true;
            this.ckbNoBusy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbNoBusy.Location = new System.Drawing.Point(19, 20);
            this.ckbNoBusy.Name = "ckbNoBusy";
            this.ckbNoBusy.Size = new System.Drawing.Size(132, 16);
            this.ckbNoBusy.TabIndex = 3;
            this.ckbNoBusy.Text = "当网络紧张时不更新";
            this.ckbNoBusy.UseVisualStyleBackColor = true;
            // 
            // cmdInstall
            // 
            this.cmdInstall.Location = new System.Drawing.Point(326, 473);
            this.cmdInstall.Name = "cmdInstall";
            this.cmdInstall.Size = new System.Drawing.Size(85, 21);
            this.cmdInstall.TabIndex = 3;
            this.cmdInstall.Text = "安装";
            this.cmdInstall.UseVisualStyleBackColor = true;
            this.cmdInstall.Click += new System.EventHandler(this.cmdInstall_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Install LongXiang Software Service";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label4_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(729, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "X";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.rbJAVA);
            this.groupBox2.Controls.Add(this.lsvSoftware);
            this.groupBox2.Controls.Add(this.rbWP7);
            this.groupBox2.Controls.Add(this.rbAndroid);
            this.groupBox2.Controls.Add(this.rbSymbian3);
            this.groupBox2.Controls.Add(this.rbWM65);
            this.groupBox2.Controls.Add(this.rbiOS);
            this.groupBox2.Controls.Add(this.rbSymbian5);
            this.groupBox2.Location = new System.Drawing.Point(12, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(716, 255);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "更新软件";
            // 
            // rbJAVA
            // 
            this.rbJAVA.AutoSize = true;
            this.rbJAVA.Location = new System.Drawing.Point(603, 233);
            this.rbJAVA.Name = "rbJAVA";
            this.rbJAVA.Size = new System.Drawing.Size(47, 16);
            this.rbJAVA.TabIndex = 8;
            this.rbJAVA.Text = "Java";
            this.rbJAVA.UseVisualStyleBackColor = true;
            // 
            // lsvSoftware
            // 
            this.lsvSoftware.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.lsvSoftware.FullRowSelect = true;
            this.lsvSoftware.GridLines = true;
            this.lsvSoftware.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvSoftware.Location = new System.Drawing.Point(6, 20);
            this.lsvSoftware.MultiSelect = false;
            this.lsvSoftware.Name = "lsvSoftware";
            this.lsvSoftware.Size = new System.Drawing.Size(704, 207);
            this.lsvSoftware.TabIndex = 0;
            this.lsvSoftware.UseCompatibleStateImageBehavior = false;
            this.lsvSoftware.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "软件名称";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "查询页面";
            this.columnHeader4.Width = 250;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "下载地址";
            this.columnHeader5.Width = 270;
            // 
            // rbWP7
            // 
            this.rbWP7.AutoSize = true;
            this.rbWP7.Location = new System.Drawing.Point(484, 233);
            this.rbWP7.Name = "rbWP7";
            this.rbWP7.Size = new System.Drawing.Size(113, 16);
            this.rbWP7.TabIndex = 7;
            this.rbWP7.Text = "Windows Phone 7";
            this.rbWP7.UseVisualStyleBackColor = true;
            // 
            // rbAndroid
            // 
            this.rbAndroid.AutoSize = true;
            this.rbAndroid.Checked = true;
            this.rbAndroid.Location = new System.Drawing.Point(51, 233);
            this.rbAndroid.Name = "rbAndroid";
            this.rbAndroid.Size = new System.Drawing.Size(65, 16);
            this.rbAndroid.TabIndex = 4;
            this.rbAndroid.TabStop = true;
            this.rbAndroid.Text = "Android";
            this.rbAndroid.UseVisualStyleBackColor = true;
            // 
            // rbSymbian3
            // 
            this.rbSymbian3.AutoSize = true;
            this.rbSymbian3.Location = new System.Drawing.Point(264, 233);
            this.rbSymbian3.Name = "rbSymbian3";
            this.rbSymbian3.Size = new System.Drawing.Size(77, 16);
            this.rbSymbian3.TabIndex = 1;
            this.rbSymbian3.Text = "Symbian^3";
            this.rbSymbian3.UseVisualStyleBackColor = true;
            // 
            // rbWM65
            // 
            this.rbWM65.AutoSize = true;
            this.rbWM65.Location = new System.Drawing.Point(347, 233);
            this.rbWM65.Name = "rbWM65";
            this.rbWM65.Size = new System.Drawing.Size(131, 16);
            this.rbWM65.TabIndex = 6;
            this.rbWM65.Text = "Windows Mobile 6.5";
            this.rbWM65.UseVisualStyleBackColor = true;
            // 
            // rbiOS
            // 
            this.rbiOS.AutoSize = true;
            this.rbiOS.Location = new System.Drawing.Point(122, 233);
            this.rbiOS.Name = "rbiOS";
            this.rbiOS.Size = new System.Drawing.Size(41, 16);
            this.rbiOS.TabIndex = 3;
            this.rbiOS.Text = "iOS";
            this.rbiOS.UseVisualStyleBackColor = true;
            // 
            // rbSymbian5
            // 
            this.rbSymbian5.AutoSize = true;
            this.rbSymbian5.Location = new System.Drawing.Point(169, 233);
            this.rbSymbian5.Name = "rbSymbian5";
            this.rbSymbian5.Size = new System.Drawing.Size(89, 16);
            this.rbSymbian5.TabIndex = 5;
            this.rbSymbian5.Text = "Symbian 5th";
            this.rbSymbian5.UseVisualStyleBackColor = true;
            // 
            // x
            // 
            this.x.BackColor = System.Drawing.Color.Transparent;
            this.x.Controls.Add(this.cmdCVSPath);
            this.x.Controls.Add(this.txtCVSPath);
            this.x.Controls.Add(this.label7);
            this.x.Location = new System.Drawing.Point(12, 84);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(716, 50);
            this.x.TabIndex = 7;
            this.x.TabStop = false;
            this.x.Text = "软件配置设置";
            // 
            // cmdCVSPath
            // 
            this.cmdCVSPath.Location = new System.Drawing.Point(656, 20);
            this.cmdCVSPath.Name = "cmdCVSPath";
            this.cmdCVSPath.Size = new System.Drawing.Size(54, 21);
            this.cmdCVSPath.TabIndex = 2;
            this.cmdCVSPath.Text = "选择";
            this.cmdCVSPath.UseVisualStyleBackColor = true;
            this.cmdCVSPath.Click += new System.EventHandler(this.cmdCVSPath_Click);
            // 
            // txtCVSPath
            // 
            this.txtCVSPath.Enabled = false;
            this.txtCVSPath.Location = new System.Drawing.Point(82, 20);
            this.txtCVSPath.Name = "txtCVSPath";
            this.txtCVSPath.Size = new System.Drawing.Size(568, 21);
            this.txtCVSPath.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "目录:";
            // 
            // frmInstallService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::LongXiangTutorialController.Properties.Resources.install;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(740, 498);
            this.Controls.Add(this.x);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdInstall);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInstallService";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Install LongXiang Software Service";
            this.Load += new System.EventHandler(this.frmInstallService_Load);
            this.Shown += new System.EventHandler(this.frmInstallService_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmInstallService_MouseDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.x.ResumeLayout(false);
            this.x.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.CheckBox ckbNoBusy;
        private System.Windows.Forms.CheckBox ckbStartWithWindows;
        private System.Windows.Forms.Button cmdInstall;
        private System.Windows.Forms.CheckBox ckbHighClass;
        private System.Windows.Forms.CheckBox ckbUpdateNotify;
        private System.Windows.Forms.CheckBox ckbAutoUpdate;
        private System.Windows.Forms.CheckBox ckbAutoUpdateNotify;
        private System.Windows.Forms.FolderBrowserDialog fbdPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lsvSoftware;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.RadioButton rbSymbian5;
        private System.Windows.Forms.RadioButton rbAndroid;
        private System.Windows.Forms.RadioButton rbiOS;
        private System.Windows.Forms.RadioButton rbSymbian3;
        private System.Windows.Forms.RadioButton rbWP7;
        private System.Windows.Forms.RadioButton rbWM65;
        private System.Windows.Forms.RadioButton rbJAVA;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox x;
        private System.Windows.Forms.Button cmdCVSPath;
        private System.Windows.Forms.TextBox txtCVSPath;
        private System.Windows.Forms.Label label7;

    }
}