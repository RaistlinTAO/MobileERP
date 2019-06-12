#region SOURCE INFORMATION

// COPYRIGHT LICENCE
// 
//  Copyright (c) 2011, D.E.M.O.N Organization
//  All rights reserved.
// 
//  Redistribution and use in source and binary forms, with or without modification,
//  are permitted provided that the following conditions are met:
// 
//      * Redistributions of source code must retain the above copyright notice,
//      this list of conditions and the following disclaimer.
//      * Redistributions in binary form must reproduce the above copyright notice,
//      this list of conditions and the following disclaimer in the documentation
//      and/or other materials provided with the distribution.
//      * Neither D.E.M.O.N Organization nor its contributors
//      may be used to endorse or promote products derived from this
//      software without specific prior written permission.
// 
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
//  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
//  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//  DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
//  FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
//  DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
//  SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
//  CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
//  OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
//  THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 
// 
// 
// CODE DESCRIPTION
// 
//        Created by Raistlin.K @ D.E.M.O.N at  23:47  09/10/2011 .
//        E-Mail:                         DemonVK@Gmail.com
// 
//        Project Name:                   LongXiangTools
//        Module  Name:                   frmOther.cs
//        Part Of:                        LongXiangTools
//        Last Change Date:               4:10 27/12/2011

#endregion

#region

#endregion

namespace LongXiangTools.View
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using SystemControl.ini;
    using DataControler.Crype;
    using DataControler.Mysql;
    using FTP;
    using LongXiangTools.Properties;

    #endregion

    public partial class frmOther : Form
    {
        #region API和静态变量

        //释放鼠标捕捉winuser.h
        private readonly MysqlController MysqlControl = new MysqlController();
        //private readonly clsNetwork NetWorkControl = new clsNetwork();
        private readonly EnDeCrype iCrype = new EnDeCrype();
        private readonly clsINI iniControl = new clsINI(Application.StartupPath + @"\BoxSetting.sys");
        //private string[] StartCMD = new string[1];
        private string iFTPAccount;
        private string iFTPIP;
        private string iFTPPassword;
        private string iPassword;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //发送消息//winuser.h 中有函数原型定义
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        #endregion

        #region 页面操作

        public frmOther()
        {
            InitializeComponent();
            //StartCMD = CMD;
        }

        private void frmOther_Load(object sender, EventArgs e)
        {
            iPassword = iCrype.CryptString(iniControl.IniReadValue("System", "TOOLSPassword"));
            MysqlController.MySQLIP = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlURL"));
            MysqlController.MySQLAccount = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlAccount"));
            MysqlController.MySQLPassword = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlPassword"));
            MysqlController.MySQLDatabase = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlDatabase"));
            iFTPIP = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPURL"));
            iFTPAccount = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPAccount"));
            iFTPPassword = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPPassword"));

            using (var iLogin = new frmLogin())
            {
                iLogin.iPassword = iPassword;

                if (iLogin.ShowDialog() != DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void frmOther_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 274, 61449, 0);
        }

        private static void cmdOK_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

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

        private static void cmdSecondHands_Click(object sender, EventArgs e)
        {
            var iPrices = new frmSecondHands();
            iPrices.ShowDialog();
        }

        private void goWait()
        {
            cmdCheckMarketPrice.Enabled = false;
            picLoad.Visible = true;
            lblLoad.Visible = true;
            cmdCleanSCache.Enabled = false;
            cmdClearECache.Enabled = false;
        }

        private void goNormal()
        {
            picLoad.Visible = false;
            lblLoad.Visible = false;
            cmdClearECache.Enabled = true;
            cmdCleanSCache.Enabled = true;
            cmdCheckMarketPrice.Enabled = true;
        }

        private void frmOther_Paint(object sender, PaintEventArgs e)
        {
            Region = null;
            SetWindowRegion();
        }

        private static void cmdQA_Click(object sender, EventArgs e)
        {
            var iPrices = new frmQnA();
            iPrices.ShowDialog();
        }

        #region 核查市场价格

        private void cmdCheckMarketPrice_Click(object sender, EventArgs e)
        {
            goWait();
            DelegateCheckMarketPrice dn = MysqlControl.CheckMarketPrice;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.ReturnResult iResult = dn.EndInvoke(iar);
            if (iResult.isSuccess)
            {
                MessageBox.Show(Resources.frmOther_cmdCheckMarketPrice_Click_核查网站市场价格成功_, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(Resources.frmOther_cmdCheckMarketPrice_Click_核查网站市场价格失败__错误原因_ + iResult.ErrDesc,
                                Application.ProductName, MessageBoxButtons.OK);
            }

            goNormal();
        }

        #endregion

        #region 基本页面操作

        #region 更新新闻

        private static void cmdUpdate_Click(object sender, EventArgs e)
        {
            //Application.DoEvents();

            var myStartInfo = new ProcessStartInfo
                                  {
                                      FileName = "http://www.skymobile.com.cn",
                                      WindowStyle = ProcessWindowStyle.Maximized
                                  };
            var myProcessB = new Process {StartInfo = myStartInfo};
            myProcessB.Start();

            Thread.Sleep(3000);

            myStartInfo = new ProcessStartInfo
                              {
                                  FileName =
                                      "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=22",
                                  WindowStyle = ProcessWindowStyle.Maximized
                              };
            var myProcess = new Process {StartInfo = myStartInfo};
            myProcess.Start();

            Thread.Sleep(3000);


            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=13";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess2 = new Process {StartInfo = myStartInfo};
            myProcess2.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=14";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess3 = new Process {StartInfo = myStartInfo};
            myProcess3.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=15";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess4 = new Process {StartInfo = myStartInfo};
            myProcess4.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=16";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess5 = new Process {StartInfo = myStartInfo};
            myProcess5.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=17";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess6 = new Process {StartInfo = myStartInfo};
            myProcess6.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=18";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess7 = new Process {StartInfo = myStartInfo};
            myProcess7.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=19";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess8 = new Process {StartInfo = myStartInfo};
            myProcess8.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=20";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess9 = new Process {StartInfo = myStartInfo};
            myProcess9.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=21";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess10 = new Process {StartInfo = myStartInfo};
            myProcess10.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=52";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess11 = new Process {StartInfo = myStartInfo};
            myProcess11.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=53";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess12 = new Process {StartInfo = myStartInfo};
            myProcess12.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=54";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess13 = new Process {StartInfo = myStartInfo};
            myProcess13.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=55";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess14 = new Process {StartInfo = myStartInfo};
            myProcess14.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=56";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess15 = new Process {StartInfo = myStartInfo};
            myProcess15.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=57";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess16 = new Process {StartInfo = myStartInfo};
            myProcess16.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=58";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess17 = new Process {StartInfo = myStartInfo};
            myProcess17.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=59";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess18 = new Process {StartInfo = myStartInfo};
            myProcess18.Start();

            /*
            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=23";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess11 = new Process { StartInfo = myStartInfo };
            myProcess11.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=24";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess12 = new Process { StartInfo = myStartInfo };
            myProcess12.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=25";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess13 = new Process { StartInfo = myStartInfo };
            myProcess13.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=26";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess14 = new Process { StartInfo = myStartInfo };
            myProcess14.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=32";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess15 = new Process { StartInfo = myStartInfo };
            myProcess15.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=33";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess16 = new Process { StartInfo = myStartInfo };
            myProcess16.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=34";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess17 = new Process { StartInfo = myStartInfo };
            myProcess17.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=35";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess18 = new Process { StartInfo = myStartInfo };
            myProcess18.Start();
            
            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=36";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess19 = new Process { StartInfo = myStartInfo };
            myProcess19.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=37";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess20 = new Process { StartInfo = myStartInfo };
            myProcess20.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=38";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess21 = new Process { StartInfo = myStartInfo };
            myProcess21.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=39";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess22 = new Process { StartInfo = myStartInfo };
            myProcess22.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=40";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess23 = new Process { StartInfo = myStartInfo };
            myProcess23.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=41";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess24 = new Process { StartInfo = myStartInfo };
            myProcess24.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=47";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess25 = new Process { StartInfo = myStartInfo };
            myProcess25.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=48";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess26 = new Process { StartInfo = myStartInfo };
            myProcess26.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=49";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess27 = new Process { StartInfo = myStartInfo };
            myProcess27.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=50";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess28 = new Process { StartInfo = myStartInfo };
            myProcess28.Start();

            Thread.Sleep(3000);

            myStartInfo.FileName =
                "http://www.skymobile.com.cn/lol_admincp.php?action=robots&op=robot&clearcache=1&robotid=51";
            myStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            var myProcess29 = new Process { StartInfo = myStartInfo };
            myProcess29.Start();

            */
            //MessageBox.Show("更新新闻完毕!", Application.ProductName, MessageBoxButtons.OK);
            //Application.DoEvents();
        }

        #endregion

        #region 清空Supesite缓存

        private void cmdCleanSCache_Click(object sender, EventArgs e)
        {
            goWait();

            DelegateCleanDB dn = MysqlControl.CleanDB;

            var Paths = new string[34];

            Paths[0] = "site_cache";
            Paths[1] = "site_cache_0";
            Paths[2] = "site_cache_1";
            Paths[3] = "site_cache_2";
            Paths[4] = "site_cache_3";
            Paths[5] = "site_cache_4";
            Paths[6] = "site_cache_5";
            Paths[7] = "site_cache_6";
            Paths[8] = "site_cache_7";
            Paths[9] = "site_cache_8";
            Paths[10] = "site_cache_9";
            Paths[11] = "site_cache_a";
            Paths[12] = "site_cache_b";
            Paths[13] = "site_cache_c";
            Paths[14] = "site_cache_d";
            Paths[15] = "site_cache_e";
            Paths[16] = "site_cache_f";

            Paths[17] = "site_tagcache";
            Paths[18] = "site_tagcache_0";
            Paths[19] = "site_tagcache_1";
            Paths[20] = "site_tagcache_2";
            Paths[21] = "site_tagcache_3";
            Paths[22] = "site_tagcache_4";
            Paths[23] = "site_tagcache_5";
            Paths[24] = "site_tagcache_6";
            Paths[25] = "site_tagcache_7";
            Paths[26] = "site_tagcache_8";
            Paths[27] = "site_tagcache_9";
            Paths[28] = "site_tagcache_a";
            Paths[29] = "site_tagcache_b";
            Paths[30] = "site_tagcache_c";
            Paths[31] = "site_tagcache_d";
            Paths[32] = "site_tagcache_e";
            Paths[33] = "site_tagcache_f";

            for (int i = 0; i < Paths.Length; i++)
            {
                if (Paths[i] == "" || Paths[i] == null) continue;
                IAsyncResult iar = dn.BeginInvoke(Paths[i], null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                dn.EndInvoke(iar);
            }

            MessageBox.Show(Resources.frmOther_cmdCleanSCache_Click_更新网站缓存完毕_, Application.ProductName,
                            MessageBoxButtons.OK);
            goNormal();
        }

        private delegate MysqlController.ReturnResult DelegateCleanDB(string iPath);

        #endregion

        #region 清空ECSHOP缓存

        private void cmdClearECache_Click(object sender, EventArgs e)
        {
            goWait();

            var FTPController = new FTPclient(iFTPIP, iFTPAccount, iFTPPassword);

            List<string> iReturn = FTPController.ListDirectory("/shop/temp/caches/");
            Application.DoEvents();

            for (int i = 0; i < iReturn.Count - 1; i++)
            {
                FTPController.CurrentDirectory = "/shop/temp/caches/" + iReturn[i];
                List<string> iTemp = FTPController.ListDirectory(FTPController.CurrentDirectory);
                for (int j = 0; j < iTemp.Count; j++)
                {
                    FTPController.FtpDelete(iTemp[j]);
                    Application.DoEvents();
                }
                Application.DoEvents();
            }

            /*
            FTPController.CurrentDirectory = "/shop/temp/caches/0";
            //FTPController.FtpDeleteDirectory()
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/1");
            FTPController.CurrentDirectory = "/shop/temp/caches/1";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/2");
            FTPController.CurrentDirectory = "/shop/temp/caches/2";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/3");
            FTPController.CurrentDirectory = "/shop/temp/caches/3";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }
            iReturn = FTPController.ListDirectory("/shop/temp/caches/4");
            FTPController.CurrentDirectory = "/shop/temp/caches/4";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/5");
            FTPController.CurrentDirectory = "/shop/temp/caches/5";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/6");
            FTPController.CurrentDirectory = "/shop/temp/caches/6";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/7");
            FTPController.CurrentDirectory = "/shop/temp/caches/7";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/8");
            FTPController.CurrentDirectory = "/shop/temp/caches/8";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/9");
            FTPController.CurrentDirectory = "/shop/temp/caches/9";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/a");
            FTPController.CurrentDirectory = "/shop/temp/caches/a";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/b");
            FTPController.CurrentDirectory = "/shop/temp/caches/b";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/c");
            FTPController.CurrentDirectory = "/shop/temp/caches/c";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/d");
            FTPController.CurrentDirectory = "/shop/temp/caches/d";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/e");
            FTPController.CurrentDirectory = "/shop/temp/caches/e";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }

            iReturn = FTPController.ListDirectory("/shop/temp/caches/f");
            FTPController.CurrentDirectory = "/shop/temp/caches/f";
            for (int i = 0; i < iReturn.Count; i++)
            {
                FTPController.FtpDelete(iReturn[i]);
                Application.DoEvents();
            }
            */


            MessageBox.Show(Resources.frmOther_cmdClearECache_Click_更新手机大全缓存完毕_, Application.ProductName,
                            MessageBoxButtons.OK);

            goNormal();
        }

        //private delegate bool DelegateFtpDelete(string iPath);

        //private delegate List<string> DelegateListDirectory(string iPath);

        #endregion

        #endregion

        #region 网站快捷

        private static void cmdSiteAdmin_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.skymobile.com.cn/admincp.php");
        }

        private static void cmdShopAdmin_Click(object sender, EventArgs e)
        {
            Process.Start("http://skymobile.com.cn/shop/ToT");
        }

        private static void cmdUCAdmin_Click(object sender, EventArgs e)
        {
            Process.Start("http://skymobile.com.cn/core");
        }

        #endregion

        #region 数据操作

        private static void cmdChangePrice_Click(object sender, EventArgs e)
        {
            var iPrices = new frmBatchPrices();
            iPrices.ShowDialog();
        }

        private void cmdBackupDB_Click(object sender, EventArgs e)
        {
            sfdFile.FileName = "DBBackup" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".sql";
            sfdFile.Filter = Resources.frmOther_cmdBackupDB_Click_SQL_Dump___sql;
            sfdFile.Title = Resources.frmOther_cmdBackupDB_Click_Backup_Database;

            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                string tempFileName = sfdFile.FileName;

                string tempCompass =
                    @" -h 114.80.67.102 -u a1012131848 --password=52846151 --database a1012131848 --table ecs_goods --table  ecs_goods_attr --table  ecs_goods_gallery --table  site_members core_members  --default-character-set=GBK --quick --compress  > """ +
                    tempFileName + @"""";

                /*
                if (File.Exists(Application.StartupPath + @"\temp.bat"))
                {
                    File.Delete(Application.StartupPath + @"\temp.bat");
                }

                var fs = new FileStream(Application.StartupPath + @"\temp.bat", FileMode.Append);
                var streamWriter = new StreamWriter(fs);
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                streamWriter.WriteLine(Application.StartupPath + @"\mysqldump.exe" + tempCompass);
                streamWriter.Flush();
                streamWriter.Close();
                fs.Close();
                */
                var p = new Process
                            {
                                StartInfo =
                                    {
                                        FileName = "cmd.exe",
                                        UseShellExecute = false,
                                        RedirectStandardInput = true,
                                        RedirectStandardOutput = true,
                                        RedirectStandardError = true,
                                        CreateNoWindow = false
                                    }
                            };
                p.Start();


                //p.StandardInput.WriteLine(string.Format(@"echo on", 200));

                p.StandardInput.WriteLine(string.Format(@"cd """ + Application.StartupPath + @"""", 200));

                p.StandardInput.WriteLine(string.Format(@"mysqldump.exe" + tempCompass, 200));

                p.StandardInput.WriteLine("exit");
                string strOutput = p.StandardOutput.ReadToEnd();
                Console.WriteLine(strOutput);
                p.WaitForExit();
                p.Close();

                //Process.Start(Application.StartupPath + @"\temp.bat");
            }
            MessageBox.Show(Resources.frmOther_cmdBackupDB_Click_请等待一会CMD窗体完成后检视SQL文件, Application.ProductName,
                            MessageBoxButtons.OK);
        }

        #endregion

        #region Nested type: DelegateCheckMarketPrice

        private delegate MysqlController.ReturnResult DelegateCheckMarketPrice();

        #endregion

        #region Nested type: DelegateCheckSiteNews

        private delegate MysqlController.ReturnResult DelegateCheckSiteNews();

        #endregion

        #region 核查网站新闻

        private void cmdUpdateNews_Click(object sender, EventArgs e)
        {
            goWait();
            DelegateCheckSiteNews dn = MysqlControl.CheckSiteNews;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.ReturnResult iResult = dn.EndInvoke(iar);
            if (iResult.isSuccess)
            {
                MessageBox.Show(Resources.frmOther_cmdUpdateNews_Click_核查网站新闻成功_, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(Resources.frmOther_cmdUpdateNews_Click_核查网站新闻失败_错误原因_ + iResult.ErrDesc,
                                Application.ProductName, MessageBoxButtons.OK);
            }

            goNormal();
        }

        #endregion
    }
}