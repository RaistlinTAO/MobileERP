namespace LongXiangBox.View
{
    partial class frmPhotos
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
            picPhoneMain.Image = null;
            picPhoneMain.Dispose();
            imlistPhotos.Images.Clear();
            imlistPhotos = null;
            //imlistPhotos.Dispose();
            lsvPhotos.Items.Clear();
            lsvPhotos = null;
            //lsvPhotos.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.picPhoneMain = new System.Windows.Forms.PictureBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lsvPhotos = new System.Windows.Forms.ListView();
            this.cmdMain = new System.Windows.Forms.Button();
            this.cmdPhotos = new System.Windows.Forms.Button();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.imlistPhotos = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoneMain)).BeginInit();
            this.SuspendLayout();
            // 
            // picPhoneMain
            // 
            this.picPhoneMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoneMain.Location = new System.Drawing.Point(12, 13);
            this.picPhoneMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picPhoneMain.Name = "picPhoneMain";
            this.picPhoneMain.Size = new System.Drawing.Size(176, 169);
            this.picPhoneMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoneMain.TabIndex = 0;
            this.picPhoneMain.TabStop = false;
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdOK.Location = new System.Drawing.Point(308, 209);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(78, 22);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdCancel.Location = new System.Drawing.Point(392, 209);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(78, 22);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lsvPhotos
            // 
            this.lsvPhotos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvPhotos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvPhotos.Location = new System.Drawing.Point(194, 13);
            this.lsvPhotos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsvPhotos.MultiSelect = false;
            this.lsvPhotos.Name = "lsvPhotos";
            this.lsvPhotos.Size = new System.Drawing.Size(276, 169);
            this.lsvPhotos.TabIndex = 3;
            this.lsvPhotos.UseCompatibleStateImageBehavior = false;
            // 
            // cmdMain
            // 
            this.cmdMain.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.cmdMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMain.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdMain.Location = new System.Drawing.Point(12, 209);
            this.cmdMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdMain.Name = "cmdMain";
            this.cmdMain.Size = new System.Drawing.Size(134, 22);
            this.cmdMain.TabIndex = 5;
            this.cmdMain.Text = "选择手机主图片";
            this.cmdMain.UseVisualStyleBackColor = false;
            this.cmdMain.Click += new System.EventHandler(this.cmdMain_Click);
            // 
            // cmdPhotos
            // 
            this.cmdPhotos.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.cmdPhotos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPhotos.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdPhotos.Location = new System.Drawing.Point(152, 209);
            this.cmdPhotos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdPhotos.Name = "cmdPhotos";
            this.cmdPhotos.Size = new System.Drawing.Size(134, 22);
            this.cmdPhotos.TabIndex = 6;
            this.cmdPhotos.Text = "选择手机相册图片";
            this.cmdPhotos.UseVisualStyleBackColor = false;
            this.cmdPhotos.Click += new System.EventHandler(this.cmdPhotos_Click);
            // 
            // ofdMain
            // 
            this.ofdMain.FileName = "openFileDialog1";
            // 
            // imlistPhotos
            // 
            this.imlistPhotos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlistPhotos.ImageSize = new System.Drawing.Size(16, 16);
            this.imlistPhotos.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmPhotos
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(482, 244);
            this.Controls.Add(this.cmdPhotos);
            this.Controls.Add(this.cmdMain);
            this.Controls.Add(this.lsvPhotos);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.picPhoneMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPhotos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPhotos";
            this.Load += new System.EventHandler(this.frmPhotos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoneMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPhoneMain;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ListView lsvPhotos;
        private System.Windows.Forms.Button cmdMain;
        private System.Windows.Forms.Button cmdPhotos;
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.ImageList imlistPhotos;
    }
}