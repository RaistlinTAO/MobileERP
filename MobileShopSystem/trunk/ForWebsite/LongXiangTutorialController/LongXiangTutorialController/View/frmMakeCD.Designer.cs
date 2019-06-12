namespace LongXiangTutorialController.View
{
    partial class frmMakeCD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMakeCD));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbisHaveFlashRom = new System.Windows.Forms.CheckBox();
            this.ckbisHaveFlashTutorial = new System.Windows.Forms.CheckBox();
            this.ckbisHash = new System.Windows.Forms.CheckBox();
            this.ckbisHaveCrack = new System.Windows.Forms.CheckBox();
            this.ckbisRAR = new System.Windows.Forms.CheckBox();
            this.ckbisHaveSoftware = new System.Windows.Forms.CheckBox();
            this.ckbisHaveTutorial = new System.Windows.Forms.CheckBox();
            this.ckbisHavePCSuite = new System.Windows.Forms.CheckBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOS = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdMakeUp = new System.Windows.Forms.Button();
            this.fbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSavePath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdSelect);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本设置";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Enabled = false;
            this.txtSavePath.Location = new System.Drawing.Point(71, 20);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(410, 21);
            this.txtSavePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "生成目录:";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(487, 20);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(61, 21);
            this.cmdSelect.TabIndex = 3;
            this.cmdSelect.Text = "选择";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckbisHaveFlashRom);
            this.groupBox2.Controls.Add(this.ckbisHaveFlashTutorial);
            this.groupBox2.Controls.Add(this.ckbisHash);
            this.groupBox2.Controls.Add(this.ckbisHaveCrack);
            this.groupBox2.Controls.Add(this.ckbisRAR);
            this.groupBox2.Controls.Add(this.ckbisHaveSoftware);
            this.groupBox2.Controls.Add(this.ckbisHaveTutorial);
            this.groupBox2.Controls.Add(this.ckbisHavePCSuite);
            this.groupBox2.Controls.Add(this.txtAccountName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbOS);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 141);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本设置";
            // 
            // ckbisHaveFlashRom
            // 
            this.ckbisHaveFlashRom.AutoSize = true;
            this.ckbisHaveFlashRom.Checked = true;
            this.ckbisHaveFlashRom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbisHaveFlashRom.ForeColor = System.Drawing.Color.RosyBrown;
            this.ckbisHaveFlashRom.Location = new System.Drawing.Point(391, 81);
            this.ckbisHaveFlashRom.Name = "ckbisHaveFlashRom";
            this.ckbisHaveFlashRom.Size = new System.Drawing.Size(90, 16);
            this.ckbisHaveFlashRom.TabIndex = 11;
            this.ckbisHaveFlashRom.Text = "包含刷机ROM";
            this.ckbisHaveFlashRom.UseVisualStyleBackColor = true;
            // 
            // ckbisHaveFlashTutorial
            // 
            this.ckbisHaveFlashTutorial.AutoSize = true;
            this.ckbisHaveFlashTutorial.Checked = true;
            this.ckbisHaveFlashTutorial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbisHaveFlashTutorial.ForeColor = System.Drawing.Color.RosyBrown;
            this.ckbisHaveFlashTutorial.Location = new System.Drawing.Point(218, 81);
            this.ckbisHaveFlashTutorial.Name = "ckbisHaveFlashTutorial";
            this.ckbisHaveFlashTutorial.Size = new System.Drawing.Size(96, 16);
            this.ckbisHaveFlashTutorial.TabIndex = 10;
            this.ckbisHaveFlashTutorial.Text = "包含刷机教程";
            this.ckbisHaveFlashTutorial.UseVisualStyleBackColor = true;
            // 
            // ckbisHash
            // 
            this.ckbisHash.AutoSize = true;
            this.ckbisHash.Checked = true;
            this.ckbisHash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbisHash.Location = new System.Drawing.Point(8, 105);
            this.ckbisHash.Name = "ckbisHash";
            this.ckbisHash.Size = new System.Drawing.Size(96, 16);
            this.ckbisHash.TabIndex = 9;
            this.ckbisHash.Text = "加密光盘信息";
            this.ckbisHash.UseVisualStyleBackColor = true;
            // 
            // ckbisHaveCrack
            // 
            this.ckbisHaveCrack.AutoSize = true;
            this.ckbisHaveCrack.Checked = true;
            this.ckbisHaveCrack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbisHaveCrack.ForeColor = System.Drawing.Color.Red;
            this.ckbisHaveCrack.Location = new System.Drawing.Point(8, 81);
            this.ckbisHaveCrack.Name = "ckbisHaveCrack";
            this.ckbisHaveCrack.Size = new System.Drawing.Size(96, 16);
            this.ckbisHaveCrack.TabIndex = 8;
            this.ckbisHaveCrack.Text = "包含破解软件";
            this.ckbisHaveCrack.UseVisualStyleBackColor = true;
            // 
            // ckbisRAR
            // 
            this.ckbisRAR.AutoSize = true;
            this.ckbisRAR.Location = new System.Drawing.Point(218, 105);
            this.ckbisRAR.Name = "ckbisRAR";
            this.ckbisRAR.Size = new System.Drawing.Size(156, 16);
            this.ckbisRAR.TabIndex = 7;
            this.ckbisRAR.Text = "不生成光盘镜像(仅压缩)";
            this.ckbisRAR.UseVisualStyleBackColor = true;
            // 
            // ckbisHaveSoftware
            // 
            this.ckbisHaveSoftware.AutoSize = true;
            this.ckbisHaveSoftware.Checked = true;
            this.ckbisHaveSoftware.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbisHaveSoftware.Location = new System.Drawing.Point(391, 57);
            this.ckbisHaveSoftware.Name = "ckbisHaveSoftware";
            this.ckbisHaveSoftware.Size = new System.Drawing.Size(96, 16);
            this.ckbisHaveSoftware.TabIndex = 6;
            this.ckbisHaveSoftware.Text = "包含常用软件";
            this.ckbisHaveSoftware.UseVisualStyleBackColor = true;
            // 
            // ckbisHaveTutorial
            // 
            this.ckbisHaveTutorial.AutoSize = true;
            this.ckbisHaveTutorial.Checked = true;
            this.ckbisHaveTutorial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbisHaveTutorial.Location = new System.Drawing.Point(218, 57);
            this.ckbisHaveTutorial.Name = "ckbisHaveTutorial";
            this.ckbisHaveTutorial.Size = new System.Drawing.Size(96, 16);
            this.ckbisHaveTutorial.TabIndex = 5;
            this.ckbisHaveTutorial.Text = "包含软件教程";
            this.ckbisHaveTutorial.UseVisualStyleBackColor = true;
            // 
            // ckbisHavePCSuite
            // 
            this.ckbisHavePCSuite.AutoSize = true;
            this.ckbisHavePCSuite.Checked = true;
            this.ckbisHavePCSuite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbisHavePCSuite.Location = new System.Drawing.Point(8, 57);
            this.ckbisHavePCSuite.Name = "ckbisHavePCSuite";
            this.ckbisHavePCSuite.Size = new System.Drawing.Size(204, 16);
            this.ckbisHavePCSuite.TabIndex = 4;
            this.ckbisHavePCSuite.Text = "包含PC端工具(将会增加光盘大小)";
            this.ckbisHavePCSuite.UseVisualStyleBackColor = true;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(391, 20);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(145, 21);
            this.txtAccountName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "客户姓名:";
            // 
            // cmbOS
            // 
            this.cmbOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOS.FormattingEnabled = true;
            this.cmbOS.Items.AddRange(new object[] {
            "Symbian OS S60 3rd",
            "Symbian OS S60 5nd",
            "Android OS",
            "Iphone OS",
            "Windows Mobile"});
            this.cmbOS.Location = new System.Drawing.Point(71, 20);
            this.cmbOS.Name = "cmbOS";
            this.cmbOS.Size = new System.Drawing.Size(160, 20);
            this.cmbOS.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "手机平台:";
            // 
            // cmdMakeUp
            // 
            this.cmdMakeUp.Location = new System.Drawing.Point(481, 222);
            this.cmdMakeUp.Name = "cmdMakeUp";
            this.cmdMakeUp.Size = new System.Drawing.Size(85, 21);
            this.cmdMakeUp.TabIndex = 4;
            this.cmdMakeUp.Text = "生成";
            this.cmdMakeUp.UseVisualStyleBackColor = true;
            // 
            // frmMakeCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(578, 255);
            this.Controls.Add(this.cmdMakeUp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMakeCD";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Make LongXiang Tutorial CD Image";
            this.Load += new System.EventHandler(this.frmMakeCD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.Button cmdMakeUp;
        private System.Windows.Forms.ComboBox cmbOS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbisHaveSoftware;
        private System.Windows.Forms.CheckBox ckbisHaveTutorial;
        private System.Windows.Forms.CheckBox ckbisHavePCSuite;
        private System.Windows.Forms.CheckBox ckbisRAR;
        private System.Windows.Forms.CheckBox ckbisHaveCrack;
        private System.Windows.Forms.CheckBox ckbisHash;
        private System.Windows.Forms.CheckBox ckbisHaveFlashTutorial;
        private System.Windows.Forms.CheckBox ckbisHaveFlashRom;
        private System.Windows.Forms.FolderBrowserDialog fbdPath;
    }
}