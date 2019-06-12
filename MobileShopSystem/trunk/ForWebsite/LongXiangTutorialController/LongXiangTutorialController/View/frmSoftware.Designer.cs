namespace LongXiangTutorialController.View
{
    partial class frmSoftware
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoftware));
            this.lsvDownload = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdIE = new System.Windows.Forms.Button();
            this.cmdLocal = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdView = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvDownload
            // 
            this.lsvDownload.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvDownload.FullRowSelect = true;
            this.lsvDownload.GridLines = true;
            this.lsvDownload.HideSelection = false;
            this.lsvDownload.Location = new System.Drawing.Point(12, 12);
            this.lsvDownload.MultiSelect = false;
            this.lsvDownload.Name = "lsvDownload";
            this.lsvDownload.Size = new System.Drawing.Size(585, 301);
            this.lsvDownload.TabIndex = 1;
            this.lsvDownload.UseCompatibleStateImageBehavior = false;
            this.lsvDownload.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "软件名称";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "软件介绍";
            this.columnHeader3.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "下载地址";
            this.columnHeader4.Width = 160;
            // 
            // cmdIE
            // 
            this.cmdIE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdIE.Location = new System.Drawing.Point(501, 321);
            this.cmdIE.Name = "cmdIE";
            this.cmdIE.Size = new System.Drawing.Size(96, 22);
            this.cmdIE.TabIndex = 3;
            this.cmdIE.Text = "查看软件(IE)";
            this.cmdIE.UseVisualStyleBackColor = true;
            this.cmdIE.Click += new System.EventHandler(this.cmdIE_Click);
            // 
            // cmdLocal
            // 
            this.cmdLocal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLocal.Location = new System.Drawing.Point(399, 321);
            this.cmdLocal.Name = "cmdLocal";
            this.cmdLocal.Size = new System.Drawing.Size(96, 22);
            this.cmdLocal.TabIndex = 4;
            this.cmdLocal.Text = "本地查看软件";
            this.cmdLocal.UseVisualStyleBackColor = true;
            this.cmdLocal.Visible = false;
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.Transparent;
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdd.Location = new System.Drawing.Point(221, 321);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(172, 22);
            this.cmdAdd.TabIndex = 7;
            this.cmdAdd.Text = "添加软件(IE已经管理员登录)";
            this.cmdAdd.UseVisualStyleBackColor = false;
            this.cmdAdd.Click += new System.EventHandler(cmdAdd_Click);
            // 
            // cmdView
            // 
            this.cmdView.BackColor = System.Drawing.Color.Transparent;
            this.cmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdView.Location = new System.Drawing.Point(12, 321);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(74, 22);
            this.cmdView.TabIndex = 8;
            this.cmdView.Text = "查看所有";
            this.cmdView.UseVisualStyleBackColor = false;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDelete.Location = new System.Drawing.Point(102, 321);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(92, 22);
            this.cmdDelete.TabIndex = 9;
            this.cmdDelete.Text = "删除选中软件";
            this.cmdDelete.UseVisualStyleBackColor = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // frmSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LongXiangTutorialController.Properties.Resources.install;
            this.ClientSize = new System.Drawing.Size(609, 355);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdView);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdLocal);
            this.Controls.Add(this.cmdIE);
            this.Controls.Add(this.lsvDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSoftware";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Website Software Download";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvDownload;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button cmdIE;
        private System.Windows.Forms.Button cmdLocal;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdView;
        private System.Windows.Forms.Button cmdDelete;
    }
}