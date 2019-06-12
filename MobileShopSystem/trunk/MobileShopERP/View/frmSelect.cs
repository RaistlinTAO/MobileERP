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

namespace MobileShopERP.View
{
    #region

    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmSelect : Form
    {
        public frmSelect()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //发送消息//winuser.h 中有函数原型定义
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        //释放鼠标捕捉winuser.h


        private void button2_Click(object sender, EventArgs e)
        {
            //"LongXiangBox.exe"
            /*
             Dim sysFolder As String = _
                     Environment.GetFoldERPath(Environment.SpecialFolder.System)
         '创建一个新的进程结构
         Dim pInfo As New ProcessStartInfo()
         '设置其成员FileName为系统资料的Eula.txt
         pInfo.FileName = sysFolder & "\eula.txt"
         '运行该文件
         Dim p As Process = Process.Start(pInfo)
         '等待程序装载完成
         p.WaitForInputIdle()
         '等待进行程退出
         p.WaitForExit()
         '继续执行下面的代码
         MessageBox.Show("继续执行代码")
             */
            try
            {
                Hide();
                var pInfo = new ProcessStartInfo(Application.StartupPath + @"\LongXiangBox.exe");
                Process p = Process.Start(pInfo);
                p.WaitForExit();
                Show();
            }
            catch (Exception)
            {
                Show();
                return;
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Image = Resources._1290172338_arrow;
            button2.Image = null;
            button3.Image = null;
            button4.Image = null;
            button5.Image = null;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.Image = Resources._1290172338_arrow;
            button1.Image = null;
            button3.Image = null;
            button4.Image = null;
            button5.Image = null;
        }


        private void frmSelect_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 161, 2, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 161, 2, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var iMain = new frmLogin();
            iMain.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
                var pInfo = new ProcessStartInfo(Application.StartupPath + @"\LongXiangTools.exe", "K9998");
                Process p = Process.Start(pInfo);
                p.WaitForExit();
                Show();
            }
            catch (Exception)
            {
                Show();
                return;
            }
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.Image = Resources._1290172338_arrow;
            button1.Image = null;
            button2.Image = null;
            button4.Image = null;
            button5.Image = null;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.Image = Resources._1290172338_arrow;
            button1.Image = null;
            button2.Image = null;
            button3.Image = null;
            button5.Image = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
                var pInfo = new ProcessStartInfo(Application.StartupPath + @"\LongXiangTC.exe");
                Process p = Process.Start(pInfo);
                p.WaitForExit();
                Show();
            }
            catch (Exception)
            {
                Show();
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
                var pInfo = new ProcessStartInfo(Application.StartupPath + @"\MobileShopERP.exe");
                Process p = Process.Start(pInfo);
                p.WaitForExit();
                Show();
            }
            catch (Exception)
            {
                Show();
                return;
            }
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.Image = Resources._1290172338_arrow;
            button1.Image = null;
            button2.Image = null;
            button3.Image = null;
            button4.Image = null;
        }
    }
}