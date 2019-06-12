namespace LongXiangTools.View
{
    partial class frmQnA
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
            this.cmdSearchK = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.dtpSecondHands = new System.Windows.Forms.DateTimePicker();
            this.picWait = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.S = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvSecondHands = new System.Windows.Forms.ListView();
            this.cmdViewDetail = new System.Windows.Forms.Button();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblEnd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSearchK
            // 
            this.cmdSearchK.BackColor = System.Drawing.Color.Transparent;
            this.cmdSearchK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSearchK.ForeColor = System.Drawing.Color.GhostWhite;
            this.cmdSearchK.Location = new System.Drawing.Point(467, 9);
            this.cmdSearchK.Name = "cmdSearchK";
            this.cmdSearchK.Size = new System.Drawing.Size(109, 22);
            this.cmdSearchK.TabIndex = 14;
            this.cmdSearchK.Text = "查询前1000条";
            this.cmdSearchK.UseVisualStyleBackColor = false;
            this.cmdSearchK.Click += new System.EventHandler(this.cmdSearchK_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackColor = System.Drawing.Color.Transparent;
            this.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSearch.ForeColor = System.Drawing.Color.GhostWhite;
            this.cmdSearch.Location = new System.Drawing.Point(398, 9);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(63, 22);
            this.cmdSearch.TabIndex = 13;
            this.cmdSearch.Text = "查询";
            this.cmdSearch.UseVisualStyleBackColor = false;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dtpSecondHands
            // 
            this.dtpSecondHands.Location = new System.Drawing.Point(237, 9);
            this.dtpSecondHands.Name = "dtpSecondHands";
            this.dtpSecondHands.Size = new System.Drawing.Size(155, 21);
            this.dtpSecondHands.TabIndex = 12;
            // 
            // picWait
            // 
            this.picWait.BackColor = System.Drawing.Color.Transparent;
            this.picWait.Image = global::LongXiangTools.Properties.Resources.ajax_loader3;
            this.picWait.Location = new System.Drawing.Point(12, 359);
            this.picWait.Name = "picWait";
            this.picWait.Size = new System.Drawing.Size(56, 19);
            this.picWait.TabIndex = 16;
            this.picWait.TabStop = false;
            this.picWait.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "龙翔用户咨询管理";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(12, 226);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(593, 123);
            this.txtAnswer.TabIndex = 18;
            this.txtAnswer.TextChanged += new System.EventHandler(this.txtAnswer_TextChanged);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDelete.ForeColor = System.Drawing.Color.GhostWhite;
            this.cmdDelete.Location = new System.Drawing.Point(394, 355);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(96, 23);
            this.cmdDelete.TabIndex = 20;
            this.cmdDelete.Text = "删除选中";
            this.cmdDelete.UseVisualStyleBackColor = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // S
            // 
            this.S.BackColor = System.Drawing.Color.Transparent;
            this.S.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.S.ForeColor = System.Drawing.Color.GhostWhite;
            this.S.Location = new System.Drawing.Point(509, 355);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(96, 23);
            this.S.TabIndex = 19;
            this.S.Text = "全部更新";
            this.S.UseVisualStyleBackColor = false;
            this.S.Click += new System.EventHandler(this.S_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(12, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "龙翔回复:";
            // 
            // lsvSecondHands
            // 
            this.lsvSecondHands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader8});
            this.lsvSecondHands.FullRowSelect = true;
            this.lsvSecondHands.GridLines = true;
            this.lsvSecondHands.Location = new System.Drawing.Point(12, 36);
            this.lsvSecondHands.Name = "lsvSecondHands";
            this.lsvSecondHands.Size = new System.Drawing.Size(593, 171);
            this.lsvSecondHands.TabIndex = 22;
            this.lsvSecondHands.UseCompatibleStateImageBehavior = false;
            this.lsvSecondHands.View = System.Windows.Forms.View.Details;
            this.lsvSecondHands.SelectedIndexChanged += new System.EventHandler(this.lsvSecondHands_SelectedIndexChanged);
            // 
            // cmdViewDetail
            // 
            this.cmdViewDetail.BackColor = System.Drawing.Color.Transparent;
            this.cmdViewDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetail.ForeColor = System.Drawing.Color.GhostWhite;
            this.cmdViewDetail.Location = new System.Drawing.Point(278, 355);
            this.cmdViewDetail.Name = "cmdViewDetail";
            this.cmdViewDetail.Size = new System.Drawing.Size(96, 23);
            this.cmdViewDetail.TabIndex = 23;
            this.cmdViewDetail.Text = "查看详细";
            this.cmdViewDetail.UseVisualStyleBackColor = false;
            this.cmdViewDetail.Click += new System.EventHandler(this.cmdViewDetail_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID";
            this.columnHeader4.Width = 40;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "发布时间";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "发布人";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "问题标题";
            this.columnHeader7.Width = 300;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "用户邮件";
            this.columnHeader1.Width = 100;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.BackColor = System.Drawing.Color.Transparent;
            this.lblEnd.ForeColor = System.Drawing.Color.Snow;
            this.lblEnd.Location = new System.Drawing.Point(603, 5);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(11, 12);
            this.lblEnd.TabIndex = 24;
            this.lblEnd.Text = "X";
            this.lblEnd.Click += new System.EventHandler(this.lblEnd_Click);
            // 
            // frmQnA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LongXiangTools.Properties.Resources._123;
            this.ClientSize = new System.Drawing.Size(617, 390);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.cmdViewDetail);
            this.Controls.Add(this.lsvSecondHands);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.S);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.picWait);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSearchK);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.dtpSecondHands);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQnA";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmQnA";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmQnA_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSearchK;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.DateTimePicker dtpSecondHands;
        private System.Windows.Forms.PictureBox picWait;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button S;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvSecondHands;
        private System.Windows.Forms.Button cmdViewDetail;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblEnd;
    }
}