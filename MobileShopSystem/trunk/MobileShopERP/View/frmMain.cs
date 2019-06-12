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
    using System.Windows.Forms;
    using SystemControl.ini;
    using SystemControl.Network;
    using DataControler.Crype;
    using DataControler.Log;
    using DataControler.Mysql;
    using MobileShopERP.Function;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmMain : Form
    {
        //private readonly FTPclient FTPControl = new FTPclient();
        private readonly clsLog LogControl = new clsLog();
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly clsNetwork NetWorkControl = new clsNetwork();
        private readonly EnDeCrype iCrype = new EnDeCrype();
        private readonly clsINI iniControl = new clsINI(Application.StartupPath + @"\BoxSetting.sys");
        public bool LoginType;
        public string LoginUser;
        /*
        private string FTPAccount;
        private string FTPPassword;
        private string FTPURL;
        
         */
        private string MysqlAccount;
        private string MysqlDatabase;
        private string MysqlPassword;
        private string MysqlURL;

        /*
        private string PassCRM;
        private string PassCMS;
        private string PassTool;
        */

        public frmMain()
        {
            InitializeComponent();
        }

        private void ReadSetting()
        {
            MysqlController.MySQLIP = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlURL"));
            MysqlController.MySQLAccount = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlAccount"));
            MysqlController.MySQLPassword = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlPassword"));
            MysqlController.MySQLDatabase = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlDatabase"));
            MysqlURL = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlURL"));
            MysqlAccount = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlAccount"));
            MysqlPassword = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlPassword"));
            MysqlDatabase = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlDatabase"));
            clsLog.iMySQLIP = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlURL"));
            clsLog.iMySQLAccount = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlAccount"));
            clsLog.iMySQLPassword = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlPassword"));
            clsLog.iMySQLDatabase = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlDatabase"));
            /*
            FTPURL = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPURL"));
            FTPAccount = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPAccount"));
            FTPPassword = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPPassword"));
             */
            //FTPControl.Hostname = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPURL"));
            //FTPControl.Username = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPAccount"));
            //FTPControl.Password = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPPassword"));

            /*
            PassCRM = iCrype.CryptString(iniControl.IniReadValue("System", "CRMPassword"));
            PassCMS = iCrype.CryptString(iniControl.IniReadValue("System", "CMSPassword"));
            PassTool = iCrype.CryptString(iniControl.IniReadValue("System", "TOOLSPassword"));
            */
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ReadSetting();
            panelDefault.Parent = this;
            panelFunctiron.Parent = this;
            panelFunctiron.Left = panelDefault.Left;
            panelFunctiron.Top = panelDefault.Top;
            panelDefault.BringToFront();
            txtLoginUser.Text = LoginUser;

            var iLog = new clsLog.LogPart();

            iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                           DateTime.Now.Day.ToString().PadLeft(2, '0');
            iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
            iLog.LogUser = LoginUser;
            iLog.LogDetail = @"成功登录CRM";

            DelegateAddLog dn = LogControl.AddLog;

            IAsyncResult iar = dn.BeginInvoke(iLog, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            dn.EndInvoke(iar);

            if (LoginType) return;
            利润核算ToolStripMenuItem.Visible = false;
            groupBox4.Visible = false;
            groupBox3.Visible = false;
            其他功能ToolStripMenuItem.Visible = false;
            picDailySell.Visible = false;
            picDailyEquip.Visible = false;
            picReport.Visible = false;
            picTotel.Visible = false;
            picAskforLeave.Visible = false;
            picGoods.Visible = false;
            picSearchUser.Visible = false;
            picSalers.Visible = false;
            picSetting.Visible = false;
        }

        private void cmdRetrun_Click(object sender, EventArgs e)
        {
            panelDefault.BringToFront();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iAbout = new frmAbout();
            iAbout.ShowDialog();
        }

        private void 添加账目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmPrivatePay(ssNetwork)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 查询长木ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmViewPrivatePay(ssNetwork)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 今日销售ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmDailySellPhones(ssNetwork, LoginUser)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void picDailySell_Click(object sender, EventArgs e)
        {
            今日销售ToolStripMenuItem_Click(sender, e);
        }

        private void picDailySell_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(13);
        }

        private void picEquipSell_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(14);
        }

        private void picContectDebt_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(15);
        }

        private void picBinPhones_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(16);
        }

        private void picMarketDebt_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(17);
        }

        private void picDailyEquip_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(18);
        }

        private void picReadCard_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(19);
        }

        private void picMarketDebtOut_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(20);
        }

        private void picBinPhonesSell_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(21);
        }

        private void picDailyEquip_Click(object sender, EventArgs e)
        {
            今日配件销售ToolStripMenuItem_Click(sender, e);
        }

        private void 今日配件销售ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmDailyEquip(ssNetwork)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void picMarketDebt_Click(object sender, EventArgs e)
        {
            市场收支结算ToolStripMenuItem_Click(sender, e);
        }

        private void picMarketDebtOut_Click(object sender, EventArgs e)
        {
            市场收支结帐OToolStripMenuItem_Click(sender, e);
        }

        private void 新配件销售ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmEquipSell(ssNetwork, LoginUser)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 客户欠款处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmCustomDebt(ssNetwork, LoginUser)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 客户手机返收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmBinPhone(ssNetwork, LoginUser)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 收取手机销售LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmBinPhonesSell(ssNetwork, LoginUser)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 市场收支结算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmMarketDebt(ssNetwork, LoginUser)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.MarketDebtInOut(true);
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 市场收支结帐OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmMarketDebt(ssNetwork, LoginUser)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.MarketDebtInOut(false);
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void picEquipSell_Click(object sender, EventArgs e)
        {
            新配件销售ToolStripMenuItem_Click(sender, e);
        }

        private void picContectDebt_Click(object sender, EventArgs e)
        {
            客户欠款处理ToolStripMenuItem_Click(sender, e);
        }

        private void picBinPhones_Click(object sender, EventArgs e)
        {
            客户手机返收ToolStripMenuItem_Click(sender, e);
        }

        private void picBinPhonesSell_Click(object sender, EventArgs e)
        {
            收取手机销售LToolStripMenuItem_Click(sender, e);
        }

        private void picReadCard_Click(object sender, EventArgs e)
        {
            var iAdd = new frmReadCard {Location = panelFunctiron.Location};

            if (iAdd.ShowDialog() == DialogResult.OK)
            {
                var iEdit = new frmEditPhone(ssNetwork, LoginUser)
                                {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
                iEdit.SetupUser(iAdd.iCardNum);
                iEdit.Show();
                iEdit.BringToFront();
                panelFunctiron.BringToFront();
            }
        }

        #region Defalut页面事件

        private void ShowInfo(int index)
        {
            switch (index)
            {
                case 0:
                    lblInfo.Text = Resources.frmMain_ShowInfo_添加客户;
                    break;
                case 1:
                    lblInfo.Text = Resources.frmMain_ShowInfo_修改客户;
                    break;
                case 2:
                    lblInfo.Text = Resources.frmMain_ShowInfo_批量查询客户;
                    break;
                case 3:
                    lblInfo.Text = Resources.frmMain_ShowInfo_查看利润;
                    break;
                case 4:
                    lblInfo.Text = Resources.frmMain_ShowInfo_销售人员;
                    break;
                case 5:
                    lblInfo.Text = Resources.frmMain_ShowInfo_销售人员提成;
                    break;
                case 6:
                    lblInfo.Text = Resources.frmMain_ShowInfo_查看支出收益;
                    break;
                case 7:
                    lblInfo.Text = Resources.frmMain_ShowInfo_系统设置;
                    break;
                case 8:
                    lblInfo.Text = Resources.frmMain_ShowInfo_检测数据库;
                    break;
                case 9:
                    lblInfo.Text = Resources.frmMain_ShowInfo_检测网络;
                    break;
                case 10:
                    lblInfo.Text = Resources.frmMain_ShowInfo_今日支出收益;
                    break;
                case 11:
                    lblInfo.Text = Resources.frmMain_ShowInfo_查询手机;
                    break;
                case 12:
                    lblInfo.Text = Resources.frmMain_ShowInfo_查看销售人员请假记录;
                    break;
                case 13:
                    lblInfo.Text = Resources.frmMain_ShowInfo_查看今日销售;
                    break;
                case 14:
                    lblInfo.Text = Resources.frmMain_ShowInfo_配件销售;
                    break;
                case 15:
                    lblInfo.Text = Resources.frmMain_ShowInfo_客户欠款管理;
                    break;
                case 16:
                    lblInfo.Text = Resources.frmMain_ShowInfo_返收客户手机;
                    break;
                case 17:
                    lblInfo.Text = Resources.frmMain_ShowInfo_市场欠款;
                    break;
                case 18:
                    lblInfo.Text = Resources.frmMain_ShowInfo_查看今日配件销售;
                    break;
                case 19:
                    lblInfo.Text = Resources.frmMain_ShowInfo_刷卡识别;
                    break;
                case 20:
                    lblInfo.Text = Resources.frmMain_ShowInfo_市场结帐;
                    break;
                case 21:
                    lblInfo.Text = Resources.frmMain_ShowInfo_返收手机销售;
                    break;
                case 22:
                    lblInfo.Text = "增加收益";
                    break;
            }
        }

        private void picPayin_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(22);
        }

        private void picAskforLeave_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(12);
        }

        private void picAddUser_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(0);
        }

        private void picEditUser_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(1);
        }

        private void picPhones_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(11);
        }

        private void picSearchUser_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(2);
        }

        private void picGoods_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(3);
        }

        private void picSalers_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(4);
        }

        private void picTotel_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(5);
        }

        private void picReport_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(6);
        }

        private void picSetting_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(7);
        }

        private void picSQL_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(8);
        }

        private void picNetwork_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(9);
        }

        private void picPayout_MouseMove(object sender, MouseEventArgs e)
        {
            ShowInfo(10);
        }

        private void picSQL_Click(object sender, EventArgs e)
        {
            数据库ToolStripMenuItem_Click(sender, e);
        }

        private void picPayout_Click(object sender, EventArgs e)
        {
            今日支出收益ToolStripMenuItem_Click(sender, e);
        }

        private void picPayin_Click(object sender, EventArgs e)
        {
            toolStripMenuItem5_Click(sender, e);
        }

        private void picNetwork_Click(object sender, EventArgs e)
        {
            网站FTPToolStripMenuItem_Click(sender, e);
        }

        private void picAddUser_Click(object sender, EventArgs e)
        {
            添加新用户ToolStripMenuItem_Click(sender, e);
        }

        private void picEditUser_Click(object sender, EventArgs e)
        {
            修改用户ToolStripMenuItem_Click(sender, e);
        }

        private void picPhones_Click(object sender, EventArgs e)
        {
            查询手机ToolStripMenuItem_Click(sender, e);
        }


        private void picSearchUser_Click(object sender, EventArgs e)
        {
            查找用户ToolStripMenuItem_Click(sender, e);
        }

        private void picAskforLeave_Click(object sender, EventArgs e)
        {
            销售人员请假记录ToolStripMenuItem_Click(sender, e);
        }

        private void picGoods_Click(object sender, EventArgs e)
        {
            查看利润ToolStripMenuItem_Click(sender, e);
        }

        private void picSalers_Click(object sender, EventArgs e)
        {
            销售人员ToolStripMenuItem_Click(sender, e);
        }

        private void picTotel_Click(object sender, EventArgs e)
        {
            销售人员提成ToolStripMenuItem_Click(sender, e);
        }

        private void picReport_Click(object sender, EventArgs e)
        {
            查看支出收益ToolStripMenuItem_Click(sender, e);
        }

        private void picSetting_Click(object sender, EventArgs e)
        {
            系统设置ToolStripMenuItem_Click(sender, e);
        }

        #endregion

        #region 菜单项

        private void 数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ssNetwork.Visible = true;

            DelegateTestConnect dn = MysqlControl.TestConnect;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            bool tempC = dn.EndInvoke(iar);

            ssNetwork.Visible = false;

            if (tempC)
            {
                MessageBox.Show(Resources.frmMain_数据库ToolStripMenuItem_Click_龙翔数据库连接正常_, Text, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Resources.frmMain_数据库ToolStripMenuItem_Click_龙翔数据库连接失败_, Text, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void 网站FTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ssNetwork.Visible = true;

            DelegateIsConnected dn = NetWorkControl.IsConnected;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            bool tempC = dn.EndInvoke(iar);

            ssNetwork.Visible = false;

            if (tempC)
            {
                MessageBox.Show(Resources.frmMain_网站FTPToolStripMenuItem_Click_龙翔服务器网络连接正常_, Text, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Resources.frmMain_网站FTPToolStripMenuItem_Click_龙翔服务器网络连接失败_, Text, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void 查询手机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmEditPhone(ssNetwork, LoginUser)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 添加新用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmNewSell(ssNetwork, LoginUser)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 修改用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmEditSell(ssNetwork, LoginUser)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmSetting {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            /*
            iCustem.MysqlAccount = MysqlAccount;
            iCustem.MysqlDatabase = MysqlDatabase;
            iCustem.MysqlPassword = MysqlPassword;
            iCustem.MysqlURL = MysqlURL;
            iCustem.FTPAccount = FTPAccount;
            iCustem.FTPPassword = FTPPassword;
            iCustem.FTPURL = FTPURL;
            iCustem.PassCMS = PassCMS;
            iCustem.PassCRM = PassCRM;
            iCustem.PassTool = PassTool;
            */
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
            //ReadSetting();
        }

        private void 查找用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmSearchCustom {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 查看利润ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmProfit(ssNetwork) {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 销售人员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmSellers
                              {
                                  MysqlAccount = MysqlAccount,
                                  MysqlDatabase = MysqlDatabase,
                                  MysqlPassword = MysqlPassword,
                                  MysqlURL = MysqlURL,
                                  TopLevel = false,
                                  Dock = DockStyle.Fill,
                                  Parent = panelFunctiron
                              };
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 销售人员提成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmCommision(ssNetwork) {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }


        private void 查看支出收益ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmViewProfit(ssNetwork)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }


        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var iCustem = new frmPayout(ssNetwork, LoginUser, true)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 今日支出收益ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmPayout(ssNetwork, LoginUser, false)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 销售人员请假记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmAskforLeave(ssNetwork)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 生成报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmReport(ssNetwork) {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        private void 查看操作记录LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var iCustem = new frmLog(ssNetwork) {TopLevel = false, Dock = DockStyle.Fill, Parent = panelFunctiron};
            iCustem.Show();
            iCustem.BringToFront();
            panelFunctiron.BringToFront();
        }

        #region Nested type: DelegateIsConnected

        private delegate bool DelegateIsConnected();

        #endregion

        #region Nested type: DelegateTestConnect

        private delegate bool DelegateTestConnect();

        #endregion

        #endregion

        #region Nested type: DelegateAddLog

        private delegate bool DelegateAddLog(clsLog.LogPart iLog);

        #endregion
    }
}