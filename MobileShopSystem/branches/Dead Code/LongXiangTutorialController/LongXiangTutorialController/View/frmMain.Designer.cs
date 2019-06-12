namespace LongXiangTutorialController.View
{
    partial class frmMain
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdViewTutorial = new System.Windows.Forms.Button();
            this.cmdMakeISO = new System.Windows.Forms.Button();
            this.cmdViewSoftware = new System.Windows.Forms.Button();
            this.cmdInstallService = new System.Windows.Forms.Button();
            this.cmdUninstallService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(504, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "LongXiang Software Controller";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(92, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Copyright © 2011 ORG: D.E.M.O.N Raistlin.K(Wei Tao) All Rights Reserved";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label3_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(280, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Design for www.SkyMobile.com.cn";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label4_MouseDown);
            // 
            // cmdViewTutorial
            // 
            this.cmdViewTutorial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdViewTutorial.Image = global::LongXiangTutorialController.Properties.Resources.web;
            this.cmdViewTutorial.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdViewTutorial.Location = new System.Drawing.Point(41, 143);
            this.cmdViewTutorial.Name = "cmdViewTutorial";
            this.cmdViewTutorial.Size = new System.Drawing.Size(433, 35);
            this.cmdViewTutorial.TabIndex = 7;
            this.cmdViewTutorial.Text = "Check LongXiang Website Tutorial     (&T)";
            this.cmdViewTutorial.UseVisualStyleBackColor = true;
            this.cmdViewTutorial.Click += new System.EventHandler(this.cmdViewTutorial_Click);
            // 
            // cmdMakeISO
            // 
            this.cmdMakeISO.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMakeISO.Image = global::LongXiangTutorialController.Properties.Resources.cdrom_mount;
            this.cmdMakeISO.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdMakeISO.Location = new System.Drawing.Point(41, 190);
            this.cmdMakeISO.Name = "cmdMakeISO";
            this.cmdMakeISO.Size = new System.Drawing.Size(433, 35);
            this.cmdMakeISO.TabIndex = 4;
            this.cmdMakeISO.Text = "Make LongXiang Software CD             (&M)";
            this.cmdMakeISO.UseVisualStyleBackColor = true;
            this.cmdMakeISO.Click += new System.EventHandler(this.cmdMakeISO_Click);
            // 
            // cmdViewSoftware
            // 
            this.cmdViewSoftware.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdViewSoftware.Image = global::LongXiangTutorialController.Properties.Resources.internet_networking;
            this.cmdViewSoftware.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdViewSoftware.Location = new System.Drawing.Point(41, 96);
            this.cmdViewSoftware.Name = "cmdViewSoftware";
            this.cmdViewSoftware.Size = new System.Drawing.Size(433, 35);
            this.cmdViewSoftware.TabIndex = 1;
            this.cmdViewSoftware.Text = "Check LongXiang Website Software (&S)";
            this.cmdViewSoftware.UseVisualStyleBackColor = true;
            this.cmdViewSoftware.Click += new System.EventHandler(this.cmdViewSoftware_Click);
            // 
            // cmdInstallService
            // 
            this.cmdInstallService.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInstallService.Image = global::LongXiangTutorialController.Properties.Resources.Service_Manager;
            this.cmdInstallService.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdInstallService.Location = new System.Drawing.Point(41, 49);
            this.cmdInstallService.Name = "cmdInstallService";
            this.cmdInstallService.Size = new System.Drawing.Size(433, 35);
            this.cmdInstallService.TabIndex = 0;
            this.cmdInstallService.Text = "Install LongXiang Updater Service      (&I)";
            this.cmdInstallService.UseVisualStyleBackColor = true;
            this.cmdInstallService.Click += new System.EventHandler(this.cmdInstallService_Click);
            // 
            // cmdUninstallService
            // 
            this.cmdUninstallService.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUninstallService.Image = global::LongXiangTutorialController.Properties.Resources.Service_Manager;
            this.cmdUninstallService.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdUninstallService.Location = new System.Drawing.Point(41, 49);
            this.cmdUninstallService.Name = "cmdUninstallService";
            this.cmdUninstallService.Size = new System.Drawing.Size(433, 35);
            this.cmdUninstallService.TabIndex = 8;
            this.cmdUninstallService.Text = "Uninstall LongXiang Updater Service (&U)";
            this.cmdUninstallService.UseVisualStyleBackColor = true;
            this.cmdUninstallService.Visible = false;
            this.cmdUninstallService.Click += new System.EventHandler(this.cmdUninstallService_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::LongXiangTutorialController.Properties.Resources.Back;
            this.ClientSize = new System.Drawing.Size(515, 268);
            this.Controls.Add(this.cmdUninstallService);
            this.Controls.Add(this.cmdViewTutorial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdMakeISO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdViewSoftware);
            this.Controls.Add(this.cmdInstallService);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdInstallService;
        private System.Windows.Forms.Button cmdViewSoftware;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdMakeISO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdViewTutorial;
        private System.Windows.Forms.Button cmdUninstallService;
    }
}