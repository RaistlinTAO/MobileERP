namespace MobileShopERP.Function
{
    partial class frmSearchCustom
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
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmbNetwork = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdSendSMS = new System.Windows.Forms.Button();
            this.cmdSMSAPI = new System.Windows.Forms.Button();
            this.lsvUser = new System.Windows.Forms.ListView();
            this.colUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLike = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLXCredit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBXK = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBXKid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBXK = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPhoneName = new System.Windows.Forms.ComboBox();
            this.cmbPhoneType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Items.AddRange(new object[] {
            "不定义",
            "普通客户",
            "大客户",
            "VIP客户",
            "至尊客户"});
            this.cmbGroup.Location = new System.Drawing.Point(83, 20);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(114, 20);
            this.cmbGroup.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择客户组:";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Enabled = false;
            this.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSearch.ForeColor = System.Drawing.Color.Black;
            this.cmdSearch.Location = new System.Drawing.Point(653, 46);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(125, 20);
            this.cmdSearch.TabIndex = 4;
            this.cmdSearch.Text = "搜索";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmbNetwork
            // 
            this.cmbNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetwork.FormattingEnabled = true;
            this.cmbNetwork.Items.AddRange(new object[] {
            "不定义",
            "中国移动",
            "中国联通",
            "中国电信"});
            this.cmbNetwork.Location = new System.Drawing.Point(83, 46);
            this.cmbNetwork.Name = "cmbNetwork";
            this.cmbNetwork.Size = new System.Drawing.Size(114, 20);
            this.cmbNetwork.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "选择运营商:";
            // 
            // cmdSendSMS
            // 
            this.cmdSendSMS.BackColor = System.Drawing.Color.Transparent;
            this.cmdSendSMS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSendSMS.ForeColor = System.Drawing.Color.Maroon;
            this.cmdSendSMS.Location = new System.Drawing.Point(682, 457);
            this.cmdSendSMS.Name = "cmdSendSMS";
            this.cmdSendSMS.Size = new System.Drawing.Size(108, 23);
            this.cmdSendSMS.TabIndex = 13;
            this.cmdSendSMS.Text = "批量发送消息";
            this.cmdSendSMS.UseVisualStyleBackColor = false;
            // 
            // cmdSMSAPI
            // 
            this.cmdSMSAPI.BackColor = System.Drawing.Color.Transparent;
            this.cmdSMSAPI.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSMSAPI.ForeColor = System.Drawing.Color.Black;
            this.cmdSMSAPI.Location = new System.Drawing.Point(6, 457);
            this.cmdSMSAPI.Name = "cmdSMSAPI";
            this.cmdSMSAPI.Size = new System.Drawing.Size(110, 23);
            this.cmdSMSAPI.TabIndex = 14;
            this.cmdSMSAPI.Text = "短信API设定";
            this.cmdSMSAPI.UseVisualStyleBackColor = false;
            // 
            // lsvUser
            // 
            this.lsvUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUserName,
            this.colUser,
            this.colPhone,
            this.colLike,
            this.colNumber,
            this.colLXCredit,
            this.colBXK,
            this.colBXKid});
            this.lsvUser.Location = new System.Drawing.Point(6, 20);
            this.lsvUser.Name = "lsvUser";
            this.lsvUser.Size = new System.Drawing.Size(772, 323);
            this.lsvUser.TabIndex = 15;
            this.lsvUser.UseCompatibleStateImageBehavior = false;
            this.lsvUser.View = System.Windows.Forms.View.Details;
            // 
            // colUserName
            // 
            this.colUserName.Text = "用户姓名";
            this.colUserName.Width = 80;
            // 
            // colUser
            // 
            this.colUser.Text = "用户名";
            this.colUser.Width = 70;
            // 
            // colPhone
            // 
            this.colPhone.Text = "用户手机号";
            this.colPhone.Width = 100;
            // 
            // colLike
            // 
            this.colLike.Text = "最喜好品牌";
            this.colLike.Width = 100;
            // 
            // colNumber
            // 
            this.colNumber.Text = "已购手机数量";
            this.colNumber.Width = 100;
            // 
            // colLXCredit
            // 
            this.colLXCredit.Text = "龙翔积分";
            // 
            // colBXK
            // 
            this.colBXK.Text = "保修卡用户";
            this.colBXK.Width = 80;
            // 
            // colBXKid
            // 
            this.colBXKid.Text = "保修卡ID";
            this.colBXKid.Width = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "保修卡用户";
            // 
            // cmbBXK
            // 
            this.cmbBXK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBXK.FormattingEnabled = true;
            this.cmbBXK.Items.AddRange(new object[] {
            "不定义",
            "有保修卡",
            "无保修卡"});
            this.cmbBXK.Location = new System.Drawing.Point(380, 46);
            this.cmbBXK.Name = "cmbBXK";
            this.cmbBXK.Size = new System.Drawing.Size(109, 20);
            this.cmbBXK.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbBXK);
            this.groupBox1.Controls.Add(this.cmbGroup);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbPhoneName);
            this.groupBox1.Controls.Add(this.cmbPhoneType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbNetwork);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmdSearch);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 76);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件设定";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "选择手机品牌:";
            // 
            // cmbPhoneName
            // 
            this.cmbPhoneName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhoneName.FormattingEnabled = true;
            this.cmbPhoneName.Location = new System.Drawing.Point(653, 20);
            this.cmbPhoneName.Name = "cmbPhoneName";
            this.cmbPhoneName.Size = new System.Drawing.Size(125, 20);
            this.cmbPhoneName.TabIndex = 17;
            // 
            // cmbPhoneType
            // 
            this.cmbPhoneType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhoneType.FormattingEnabled = true;
            this.cmbPhoneType.Items.AddRange(new object[] {
            "不定义"});
            this.cmbPhoneType.Location = new System.Drawing.Point(380, 20);
            this.cmbPhoneType.Name = "cmbPhoneType";
            this.cmbPhoneType.Size = new System.Drawing.Size(109, 20);
            this.cmbPhoneType.TabIndex = 6;
            this.cmbPhoneType.SelectedIndexChanged += new System.EventHandler(this.cmbPhoneType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "选择手机型号:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lsvUser);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 349);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "搜索结果";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.cmdSendSMS);
            this.groupBox3.Controls.Add(this.cmdSMSAPI);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(796, 486);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            // 
            // frmSearchCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::MobileShopERP.Properties.Resources._22;
            this.ClientSize = new System.Drawing.Size(820, 510);
            this.Controls.Add(this.groupBox3);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSearchCustom";
            this.Load += new System.EventHandler(this.frmSearchCustom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.ComboBox cmbNetwork;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdSendSMS;
        private System.Windows.Forms.Button cmdSMSAPI;
        private System.Windows.Forms.ListView lsvUser;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.ColumnHeader colLike;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colLXCredit;
        private System.Windows.Forms.ColumnHeader colBXK;
        private System.Windows.Forms.ColumnHeader colBXKid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBXK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPhoneName;
        private System.Windows.Forms.ComboBox cmbPhoneType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}