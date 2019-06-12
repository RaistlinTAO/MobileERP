namespace LongXiangTools.View
{
    partial class frmViewPicture
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPhoneName = new System.Windows.Forms.Label();
            this.picView = new System.Windows.Forms.PictureBox();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdPreview = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "二手机图片查看";
            // 
            // lblPhoneName
            // 
            this.lblPhoneName.AutoSize = true;
            this.lblPhoneName.Location = new System.Drawing.Point(128, 9);
            this.lblPhoneName.Name = "lblPhoneName";
            this.lblPhoneName.Size = new System.Drawing.Size(0, 12);
            this.lblPhoneName.TabIndex = 1;
            // 
            // picView
            // 
            this.picView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picView.Location = new System.Drawing.Point(12, 37);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(513, 291);
            this.picView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picView.TabIndex = 2;
            this.picView.TabStop = false;
            // 
            // cmdNext
            // 
            this.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNext.Location = new System.Drawing.Point(316, 346);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(69, 21);
            this.cmdNext.TabIndex = 3;
            this.cmdNext.Text = "下一张";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdPreview
            // 
            this.cmdPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPreview.Location = new System.Drawing.Point(155, 346);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(69, 21);
            this.cmdPreview.TabIndex = 4;
            this.cmdPreview.Text = "上一张";
            this.cmdPreview.UseVisualStyleBackColor = true;
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.AutoSize = true;
            this.txtInfo.Location = new System.Drawing.Point(395, 9);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(0, 12);
            this.txtInfo.TabIndex = 6;
            // 
            // frmViewPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(537, 379);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.picView);
            this.Controls.Add(this.lblPhoneName);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewPicture";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A";
            this.Load += new System.EventHandler(this.frmViewPicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPhoneName;
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdPreview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtInfo;
    }
}