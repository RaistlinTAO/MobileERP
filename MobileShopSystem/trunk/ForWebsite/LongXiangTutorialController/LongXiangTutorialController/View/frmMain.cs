// ######################################################################################################################
// #  Redistribution and use in source and binary forms, with or without modification, are permitted provided that the  #
// #  following conditions are met:                                                                                     #
// #    1、Redistributions of source code must retain the above copyright notice, this list of conditions and the       #
// #       following disclaimer.                                                                                        #
// #    2、Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the    #
// #       following disclaimer in the documentation and/or other materials provided with the distribution.             #
// #    3、Neither the name of the D.E.M.O.N, K9998(Wei Tao) nor the names of its contributors may be used to endorse   #
// #       or promote products derived from this software without specific prior written permission.                    #
// #                                                                                                                    #
// #       Project Name:                                                                                                #
// #       Module  Name:                                                                                                #
// #       Part of:                                                                                                     #
// #       Date:                                                                                                        #
// #       Version:                                                                                                     #
// #                                                                                                                    #
// #                                           Copyright © 2011 ORG: D.E.M.O.N K9998(Wei Tao) All Rights Reserved      #
// ######################################################################################################################

#region

#endregion

namespace LongXiangTutorialController.View
{
    #region

    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using SystemControl.ini;
    using DataControler.Crype;
    using DataControler.Mysql;

    #endregion

    public partial class frmMain : Form
    {
        private readonly EnDeCrype iCrype = new EnDeCrype();
        private readonly clsINI iniControl = new clsINI(Application.StartupPath + @"\BoxSetting.sys");
        //private string iFTPAccount;
//private string iFTPIP;
        //private string iFTPPassword;
        //private string iPassword;

        public frmMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //发送消息//winuser.h 中有函数原型定义
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private static void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 274, 61449, 0);
        }

        private static void cmdViewSoftware_Click(object sender, EventArgs e)
        {
            //网站及本地的软件更新服务
            var iPrices = new frmSoftware();
            iPrices.ShowDialog();
        }

        private static void cmdViewTutorial_Click(object sender, EventArgs e)
        {
            //网站及本地的教程设置
            var iPrices = new frmTutorial();
            iPrices.ShowDialog();
        }

        private static void cmdMakeISO_Click(object sender, EventArgs e)
        {
            //制作光盘
            var iPrices = new frmMakeCD();
            iPrices.ShowDialog();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            MysqlController.MySQLIP = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlURL"));
            MysqlController.MySQLAccount = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlAccount"));
            MysqlController.MySQLPassword = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlPassword"));
            MysqlController.MySQLDatabase = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlDatabase"));
            //iFTPIP = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPURL"));
            //iFTPAccount = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPAccount"));
            //iFTPPassword = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPPassword"));
        }


        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 274, 61449, 0);
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 274, 61449, 0);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 274, 61449, 0);
        }

        public void SetWindowRegion()
        {
            var rect = new Rectangle(0, 10, Width, Height - 10);
            //this.Left-10,this.Top-10,this.Width-10,this.Height-10);                 
            GraphicsPath FormPath = GetRoundedRectPath(rect, 10);
            Region = new Region(FormPath);
        }

        private static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            var arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            var path = new GraphicsPath();
            //   左上角   
            path.AddArc(arcRect, 180, 90);
            //   右上角   
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            //   右下角   
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            //   左下角   
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Region = null;
            SetWindowRegion();
        }
    }
}