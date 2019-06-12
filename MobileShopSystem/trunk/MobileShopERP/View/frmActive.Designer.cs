namespace MobileShopERP.View
{
    partial class frmActive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActive));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdCopyCDKEY = new System.Windows.Forms.Button();
            this.txtCDKEY = new System.Windows.Forms.TextBox();
            this.cmdCopy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReqInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdPaste = new System.Windows.Forms.Button();
            this.cmdQQ = new System.Windows.Forms.Button();
            this.cmdBuy = new System.Windows.Forms.Button();
            this.cmdTaoBao = new System.Windows.Forms.Button();
            this.cmdActive = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtActiveInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdTry = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdCopyCDKEY);
            this.groupBox1.Controls.Add(this.txtCDKEY);
            this.groupBox1.Controls.Add(this.cmdCopy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtReqInfo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "注册信息";
            // 
            // cmdCopyCDKEY
            // 
            this.cmdCopyCDKEY.Location = new System.Drawing.Point(490, 19);
            this.cmdCopyCDKEY.Name = "cmdCopyCDKEY";
            this.cmdCopyCDKEY.Size = new System.Drawing.Size(90, 22);
            this.cmdCopyCDKEY.TabIndex = 7;
            this.cmdCopyCDKEY.Text = "复制CD-KEY";
            this.cmdCopyCDKEY.UseVisualStyleBackColor = true;
            this.cmdCopyCDKEY.Click += new System.EventHandler(this.cmdCopyCDKEY_Click);
            // 
            // txtCDKEY
            // 
            this.txtCDKEY.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCDKEY.ForeColor = System.Drawing.Color.Maroon;
            this.txtCDKEY.Location = new System.Drawing.Point(59, 20);
            this.txtCDKEY.Name = "txtCDKEY";
            this.txtCDKEY.Size = new System.Drawing.Size(425, 21);
            this.txtCDKEY.TabIndex = 6;
            this.txtCDKEY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdCopy
            // 
            this.cmdCopy.Location = new System.Drawing.Point(490, 48);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(90, 22);
            this.cmdCopy.TabIndex = 5;
            this.cmdCopy.Text = "复制请求码";
            this.cmdCopy.UseVisualStyleBackColor = true;
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "请求码:";
            // 
            // txtReqInfo
            // 
            this.txtReqInfo.ForeColor = System.Drawing.Color.DimGray;
            this.txtReqInfo.Location = new System.Drawing.Point(6, 76);
            this.txtReqInfo.Multiline = true;
            this.txtReqInfo.Name = "txtReqInfo";
            this.txtReqInfo.Size = new System.Drawing.Size(574, 65);
            this.txtReqInfo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "CD-KEY:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdTry);
            this.groupBox2.Controls.Add(this.cmdPaste);
            this.groupBox2.Controls.Add(this.cmdQQ);
            this.groupBox2.Controls.Add(this.cmdBuy);
            this.groupBox2.Controls.Add(this.cmdTaoBao);
            this.groupBox2.Controls.Add(this.cmdActive);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtActiveInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(586, 162);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "激活信息";
            // 
            // cmdPaste
            // 
            this.cmdPaste.Location = new System.Drawing.Point(490, 22);
            this.cmdPaste.Name = "cmdPaste";
            this.cmdPaste.Size = new System.Drawing.Size(90, 22);
            this.cmdPaste.TabIndex = 8;
            this.cmdPaste.Text = "粘贴激活码";
            this.cmdPaste.UseVisualStyleBackColor = true;
            this.cmdPaste.Click += new System.EventHandler(this.cmdPaste_Click);
            // 
            // cmdQQ
            // 
            this.cmdQQ.Image = global::MobileShopERP.Properties.Resources.QQ;
            this.cmdQQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdQQ.Location = new System.Drawing.Point(240, 134);
            this.cmdQQ.Name = "cmdQQ";
            this.cmdQQ.Size = new System.Drawing.Size(111, 22);
            this.cmdQQ.TabIndex = 7;
            this.cmdQQ.Text = "技术支持";
            this.cmdQQ.UseVisualStyleBackColor = true;
            this.cmdQQ.Click += new System.EventHandler(this.cmdQQ_Click);
            // 
            // cmdBuy
            // 
            this.cmdBuy.Image = global::MobileShopERP.Properties.Resources.taobao;
            this.cmdBuy.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdBuy.Location = new System.Drawing.Point(6, 134);
            this.cmdBuy.Name = "cmdBuy";
            this.cmdBuy.Size = new System.Drawing.Size(111, 22);
            this.cmdBuy.TabIndex = 6;
            this.cmdBuy.Text = "购买通道";
            this.cmdBuy.UseVisualStyleBackColor = true;
            this.cmdBuy.Click += new System.EventHandler(this.cmdBuy_Click);
            // 
            // cmdTaoBao
            // 
            this.cmdTaoBao.Image = global::MobileShopERP.Properties.Resources.Untitled;
            this.cmdTaoBao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdTaoBao.Location = new System.Drawing.Point(123, 134);
            this.cmdTaoBao.Name = "cmdTaoBao";
            this.cmdTaoBao.Size = new System.Drawing.Size(111, 22);
            this.cmdTaoBao.TabIndex = 5;
            this.cmdTaoBao.Text = "获得激活码";
            this.cmdTaoBao.UseVisualStyleBackColor = true;
            this.cmdTaoBao.Click += new System.EventHandler(this.cmdTaoBao_Click);
            // 
            // cmdActive
            // 
            this.cmdActive.Enabled = false;
            this.cmdActive.Image = global::MobileShopERP.Properties.Resources._1303232260_system_software_update;
            this.cmdActive.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdActive.Location = new System.Drawing.Point(490, 134);
            this.cmdActive.Name = "cmdActive";
            this.cmdActive.Size = new System.Drawing.Size(90, 22);
            this.cmdActive.TabIndex = 4;
            this.cmdActive.Text = "激活";
            this.cmdActive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "激活码:";
            // 
            // txtActiveInfo
            // 
            this.txtActiveInfo.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtActiveInfo.Location = new System.Drawing.Point(6, 50);
            this.txtActiveInfo.Multiline = true;
            this.txtActiveInfo.Name = "txtActiveInfo";
            this.txtActiveInfo.Size = new System.Drawing.Size(574, 78);
            this.txtActiveInfo.TabIndex = 2;
            this.txtActiveInfo.TextChanged += new System.EventHandler(this.txtActiveInfo_TextChanged);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(13, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(585, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "请在点击\"购买通道\"进入淘宝拍下后 点击\"获得激活码\"按钮, 发送您的CDKEY和请求码给我们的客服, 就可以\r\n\r\n获得指定的激活码 完成程序激活";
            // 
            // cmdTry
            // 
            this.cmdTry.Enabled = false;
            this.cmdTry.Image = global::MobileShopERP.Properties.Resources._1303232260_system_software_update;
            this.cmdTry.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdTry.Location = new System.Drawing.Point(394, 134);
            this.cmdTry.Name = "cmdTry";
            this.cmdTry.Size = new System.Drawing.Size(90, 22);
            this.cmdTry.TabIndex = 9;
            this.cmdTry.Text = "试用";
            this.cmdTry.UseVisualStyleBackColor = true;
            // 
            // frmActive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 383);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmActive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件注册";
            this.Load += new System.EventHandler(this.frmActive_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtReqInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtActiveInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdActive;
        private System.Windows.Forms.Button cmdBuy;
        private System.Windows.Forms.Button cmdTaoBao;
        private System.Windows.Forms.Button cmdQQ;
        private System.Windows.Forms.Button cmdCopy;
        private System.Windows.Forms.Button cmdPaste;
        private System.Windows.Forms.Button cmdCopyCDKEY;
        private System.Windows.Forms.TextBox txtCDKEY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdTry;
    }
}