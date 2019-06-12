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
    using System.Configuration.Install;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.ServiceProcess;
    using System.Windows.Forms;
    using Microsoft.Win32;

    #endregion

    public partial class frmMain : Form
    {
        private ServiceController[] iServices;


        public frmMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //发送消息//winuser.h 中有函数原型定义
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 274, 61449, 0);
        }

        private void cmdInstallService_Click(object sender, EventArgs e)
        {
            //安装服务
            var iPrices = new frmInstallService();
            iPrices.ShowDialog();
        }

        private void cmdViewSoftware_Click(object sender, EventArgs e)
        {
            //网站及本地的软件更新服务
            var iPrices = new frmSoftware();
            iPrices.ShowDialog();
        }

        private void cmdViewTutorial_Click(object sender, EventArgs e)
        {
            //网站及本地的教程设置
            var iPrices = new frmTutorial();
            iPrices.ShowDialog();
        }

        private void cmdMakeISO_Click(object sender, EventArgs e)
        {
            //制作光盘
            var iPrices = new frmMakeCD();
            iPrices.ShowDialog();
        }

        /*
         ZhuDongFangYu 主动防御
         */

        private void frmMain_Load(object sender, EventArgs e)
        {
            //判断是否存在

            iServices = ServiceController.GetServices();
            foreach (ServiceController iService in iServices)
            {
                if (iService.DisplayName == "1主动防御")
                {
                    if (iService.ServiceName == "1ZhuDongFangYu")
                    {
                        //服务存在
                        cmdInstallService.Visible = false;
                        cmdUninstallService.Visible = true;
                    }
                }
            }
        }

        private void cmdUninstallService_Click(object sender, EventArgs e)
        {
            //卸载服务
            //iServices = ServiceController.GetServices();
            foreach (ServiceController iService in iServices)
            {
                if (iService.DisplayName == "1主动防御")
                {
                    if (iService.ServiceName == "1ZhuDongFangYu")
                    {
                        while (iService.Status == ServiceControllerStatus.Stopped)
                        {
                            iService.Stop();
                        }

                        //iService.WaitForStatus(ServiceControllerStatus.Stopped);
                        UnInstallmyService(ReadRegFilePath(iService.ServiceName));
                    }
                }
            }
        }

        //通过注册表读取服务程序位置
        private static string ReadRegFilePath(string ServicesName)
        {
            string temp;
            try
            {
                RegistryKey iKey = Registry.LocalMachine; //Registry参数自己选择
                RegistryKey subKey = iKey.OpenSubKey("SYSTEM\\ControlSet001\\services"); //注册表位置
                temp = subKey.OpenSubKey(ServicesName).GetValue("ImagePath").ToString();

                subKey.Close();
                iKey.Close();
                return temp;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //根据文件路径卸载服务
        private static void UnInstallmyService(string filepath)
        {
            var iAS = new AssemblyInstaller();
            iAS.UseNewContext = true;
            iAS.Path = filepath;
            iAS.Uninstall(null);
            iAS.Dispose();
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
//
        }

        public void SetWindowRegion()
        {
            GraphicsPath FormPath;
            FormPath = new GraphicsPath();
            var rect = new Rectangle(0, 10, Width, Height - 10);
            //this.Left-10,this.Top-10,this.Width-10,this.Height-10);                 
            FormPath = GetRoundedRectPath(rect, 10);
            Region = new Region(FormPath);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
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