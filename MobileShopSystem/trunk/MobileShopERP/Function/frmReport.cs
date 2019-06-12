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

namespace MobileShopERP.Function
{
    #region

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using SystemControl.ini;
    using DataControler.Crype;
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmReport : Form
    {
        private readonly EnDeCrype iCrype = new EnDeCrype();
        private readonly clsINI iniControl = new clsINI(Application.StartupPath + @"\BoxSetting.sys");

        #region 全局

        private static readonly MysqlController MysqlControl = new MysqlController();

        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        /*
        private readonly GetAskForLeaveDelegate GAFLD = GetAskForLeave;
        private readonly GetBinPhonesDelegate GBPD = GetBinPhones;
        private readonly GetCustomDebtDelegate GCDD = GetCustomDebt;
        private readonly GetEquipSoldDelegate GESD = GetEquipSold;
        private readonly GetMarketDebtDelegate GMDD = GetMarketDebt;
        private readonly GetPhonesDelegate GPD = GetPhones;
        private readonly GetPayoutDelegate GPOD = GetPayout;
        */
        //private string[] tempBrand;
        private string P1;
        private string P2;
        private string P3;
        private string P4;
        private string P5;
        private string P6;
        private string P7;
        private string[] tempSellIndex;
        private string[] tempSeller;

        #endregion

        #region 窗体事件

        public frmReport(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            txtDailyPath.Text = Application.StartupPath + @"\";
            txtMonthPath.Text = Application.StartupPath + @"\";
            txtYearPath.Text = Application.StartupPath + @"\";
            //tempBrand = MysqlControl.Manufacturer();
            P1 = iCrype.CryptString(iniControl.IniReadValue("Pay", "P1"));
            P2 = iCrype.CryptString(iniControl.IniReadValue("Pay", "P2"));
            P3 = iCrype.CryptString(iniControl.IniReadValue("Pay", "P3"));
            P4 = iCrype.CryptString(iniControl.IniReadValue("Pay", "P4"));
            P5 = iCrype.CryptString(iniControl.IniReadValue("Pay", "P5"));
            P6 = iCrype.CryptString(iniControl.IniReadValue("Pay", "P6"));
            P7 = iCrype.CryptString(iniControl.IniReadValue("Pay", "P7"));
        }

        private void cmdDailyPath_Click(object sender, EventArgs e)
        {
            fbdMain.Reset();
            fbdMain.ShowNewFolderButton = true;
            fbdMain.Description = Resources.frmReport_cmdDailyPath_Click_选择一个用于输出的文件夹;
            if (fbdMain.ShowDialog() != DialogResult.OK) return;
            if (fbdMain.SelectedPath.Substring(fbdMain.SelectedPath.Length - 1, 0) == @"\")
            {
                txtDailyPath.Text = fbdMain.SelectedPath;
            }
            else
            {
                txtDailyPath.Text = fbdMain.SelectedPath + @"\";
            }
        }

        private void cmdMonthPath_Click(object sender, EventArgs e)
        {
            fbdMain.Reset();
            fbdMain.ShowNewFolderButton = true;
            fbdMain.Description = Resources.frmReport_cmdDailyPath_Click_选择一个用于输出的文件夹;
            if (fbdMain.ShowDialog() != DialogResult.OK) return;
            if (fbdMain.SelectedPath.Substring(fbdMain.SelectedPath.Length - 1, 0) == @"\")
            {
                txtMonthPath.Text = fbdMain.SelectedPath;
            }
            else
            {
                txtMonthPath.Text = fbdMain.SelectedPath + @"\";
            }
        }

        private void cmdYearPath_Click(object sender, EventArgs e)
        {
            fbdMain.Reset();
            fbdMain.ShowNewFolderButton = true;
            fbdMain.Description = Resources.frmReport_cmdDailyPath_Click_选择一个用于输出的文件夹;
            if (fbdMain.ShowDialog() != DialogResult.OK) return;
            if (fbdMain.SelectedPath.Substring(fbdMain.SelectedPath.Length - 1, 0) == @"\")
            {
                txtYearPath.Text = fbdMain.SelectedPath;
            }
            else
            {
                txtYearPath.Text = fbdMain.SelectedPath + @"\";
            }
        }

        #endregion

        #region 保存按钮事件

        private void cmdSaveDaily_Click(object sender, EventArgs e)
        {
            if (txtDailyPath.Text == "") return;
            cmdSaveDaily.Enabled = false;
            dtpDate.Enabled = false;
            isBusy.Visible = true;
            cmdDailyPath.Enabled = false;
            //
            GetPhonesDelegate dn = GetPhones;
            IAsyncResult iar = dn.BeginInvoke(dtpDate.Value.Year +
                                              dtpDate.Value.Month.ToString().PadLeft(2, '0') +
                                              dtpDate.Value.Day.ToString().PadLeft(2, '0'), null, null);
            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXSellPhone[] tempPhones = dn.EndInvoke(iar);
            pgbSaveDaily.Value = 15;
            //
            GetPayoutDelegate dn1 = GetPayout;
            IAsyncResult iar1 = dn1.BeginInvoke(dtpDate.Value.Year +
                                                dtpDate.Value.Month.ToString().PadLeft(2, '0') +
                                                dtpDate.Value.Day.ToString().PadLeft(2, '0'), null, null);
            while (iar1.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.Payout[] tempPayout = dn1.EndInvoke(iar1);
            pgbSaveDaily.Value = 30;
            //
            GetEquipSoldDelegate dn2 = GetEquipSold;
            IAsyncResult iar2 = dn2.BeginInvoke(dtpDate.Value.Year +
                                                dtpDate.Value.Month.ToString().PadLeft(2, '0') +
                                                dtpDate.Value.Day.ToString().PadLeft(2, '0'), null, null);
            while (iar2.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXEquip[] tempEquipSold = dn2.EndInvoke(iar2);
            pgbSaveDaily.Value = 45;
            //
            GetBinPhonesDelegate dn3 = GetBinPhones;
            IAsyncResult iar3 = dn3.BeginInvoke(dtpDate.Value.Year +
                                                dtpDate.Value.Month.ToString().PadLeft(2, '0') +
                                                dtpDate.Value.Day.ToString().PadLeft(2, '0'), null, null);
            while (iar3.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.RefundPhone[] tempRefundPhone = dn3.EndInvoke(iar3);


            GetBinPhonesByFixDateDelegate dnfix = GetBinPhonesByFixDate;
            IAsyncResult iarfix = dnfix.BeginInvoke(dtpDate.Value.Year +
                                                    dtpDate.Value.Month.ToString().PadLeft(2, '0') +
                                                    dtpDate.Value.Day.ToString().PadLeft(2, '0'), null, null);
            while (iarfix.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.RefundPhone[] tempRefundPhoneFix = dnfix.EndInvoke(iarfix);

            pgbSaveDaily.Value = 60;
            //
            GetCustomDebtDelegate dn4 = GetCustomDebt;
            IAsyncResult iar4 = dn4.BeginInvoke(dtpDate.Value.Year +
                                                dtpDate.Value.Month.ToString().PadLeft(2, '0') +
                                                dtpDate.Value.Day.ToString().PadLeft(2, '0'), null, null);
            while (iar4.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXCustomDebt[] tempCustomDebt = dn4.EndInvoke(iar4);
            pgbSaveDaily.Value = 75;
            //
            GetMarketDebtDelegate dn5 = GetMarketDebt;
            IAsyncResult iar5 = dn5.BeginInvoke(dtpDate.Value.Year +
                                                dtpDate.Value.Month.ToString().PadLeft(2, '0') +
                                                dtpDate.Value.Day.ToString().PadLeft(2, '0'), null, null);
            while (iar5.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXMarketDebt[] tempMarketDebt = dn5.EndInvoke(iar5);
            //
            pgbSaveDaily.Value = 90;
            DelegateSaveData dnx = SaveData;

            IAsyncResult iarx = dnx.BeginInvoke(0, tempPhones, null, tempPayout, tempEquipSold, tempRefundPhone,
                                                tempRefundPhoneFix,
                                                tempCustomDebt,
                                                tempMarketDebt, null, null);

            while (iarx.IsCompleted == false)
            {
                Application.DoEvents();
            }

            bool isSaveOK = dnx.EndInvoke(iarx);
            pgbSaveDaily.Value = 100;
            MessageBox.Show(
                isSaveOK
                    ? "生成报表成功!"
                    : "生成报表失败!",
                Application.ProductName,
                MessageBoxButtons.OK);
            cmdSaveDaily.Enabled = true;
            dtpDate.Enabled = true;
            isBusy.Visible = false;
            cmdDailyPath.Enabled = true;
            pgbSaveDaily.Value = 0;
        }

        private void cmdSaveMonth_Click(object sender, EventArgs e)
        {
            if (txtMonthPath.Text == "") return;
            cmdSaveMonth.Enabled = false;
            isBusy.Visible = true;
            dtpMonth.Enabled = false;
            cmdMonthPath.Enabled = false;

            GetPhonesDelegate dn = GetPhones;
            IAsyncResult iar = dn.BeginInvoke(dtpMonth.Value.Year +
                                              dtpMonth.Value.Month.ToString().PadLeft(2, '0'), null, null);
            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXSellPhone[] tempPhones = dn.EndInvoke(iar);
            pgbSaveMonth.Value = 15;
            //
            var tempLeave = new MysqlController.AskForLeave[tempSeller.Length][];
            for (int i = 0; i < tempSeller.Length; i++)
            {
                GetAskForLeaveDelegate dna = GetAskForLeave;
                IAsyncResult iara = dna.BeginInvoke(dtpMonth.Value.Year +
                                                    dtpMonth.Value.Month.ToString().PadLeft(2, '0'), i, null, null);

                while (iara.IsCompleted == false)
                {
                    Application.DoEvents();
                }
                tempLeave[i] = dna.EndInvoke(iara);
                Application.DoEvents();
            }
            pgbSaveMonth.Value = 30;
            //
            GetPayoutDelegate dn1 = GetPayout;
            IAsyncResult iar1 = dn1.BeginInvoke(dtpMonth.Value.Year +
                                                dtpMonth.Value.Month.ToString().PadLeft(2, '0'), null, null);
            while (iar1.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.Payout[] tempPayout = dn1.EndInvoke(iar1);
            pgbSaveMonth.Value = 40;
            GetEquipSoldDelegate dn2 = GetEquipSold;
            IAsyncResult iar2 = dn2.BeginInvoke(dtpMonth.Value.Year +
                                                dtpMonth.Value.Month.ToString().PadLeft(2, '0'), null, null);
            while (iar2.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXEquip[] tempEquipSold = dn2.EndInvoke(iar2);
            pgbSaveMonth.Value = 50;
            GetBinPhonesDelegate dn3 = GetBinPhones;
            IAsyncResult iar3 = dn3.BeginInvoke(dtpMonth.Value.Year +
                                                dtpMonth.Value.Month.ToString().PadLeft(2, '0'), null, null);
            while (iar3.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.RefundPhone[] tempRefundPhone = dn3.EndInvoke(iar3);

            GetBinPhonesByFixDateDelegate dnfix = GetBinPhonesByFixDate;
            IAsyncResult iarfix = dnfix.BeginInvoke(dtpDate.Value.Year +
                                                    dtpDate.Value.Month.ToString().PadLeft(2, '0') +
                                                    dtpDate.Value.Day.ToString().PadLeft(2, '0'), null, null);
            while (iarfix.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.RefundPhone[] tempRefundPhoneFix = dnfix.EndInvoke(iarfix);

            pgbSaveMonth.Value = 60;
            GetCustomDebtDelegate dn4 = GetCustomDebt;
            IAsyncResult iar4 = dn4.BeginInvoke(dtpMonth.Value.Year +
                                                dtpMonth.Value.Month.ToString().PadLeft(2, '0'), null, null);
            while (iar4.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXCustomDebt[] tempCustomDebt = dn4.EndInvoke(iar4);
            pgbSaveMonth.Value = 75;
            GetMarketDebtDelegate dn5 = GetMarketDebt;
            IAsyncResult iar5 = dn5.BeginInvoke(dtpMonth.Value.Year +
                                                dtpMonth.Value.Month.ToString().PadLeft(2, '0'), null, null);
            while (iar5.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXMarketDebt[] tempMarketDebt = dn5.EndInvoke(iar5);
            pgbSaveMonth.Value = 85;
            DelegateSaveData dnx = SaveData;

            IAsyncResult iarx = dnx.BeginInvoke(1, tempPhones, tempLeave, tempPayout, tempEquipSold, tempRefundPhone,
                                                tempRefundPhoneFix,
                                                tempCustomDebt,
                                                tempMarketDebt, null, null);

            while (iarx.IsCompleted == false)
            {
                Application.DoEvents();
            }

            bool isSaveOK = dnx.EndInvoke(iarx);
            pgbSaveMonth.Value = 100;
            MessageBox.Show(
                isSaveOK
                    ? "生成报表成功!"
                    : "生成报表失败!",
                Application.ProductName, MessageBoxButtons.OK);
            cmdSaveMonth.Enabled = true;
            isBusy.Visible = false;
            dtpMonth.Enabled = true;
            cmdMonthPath.Enabled = true;
            pgbSaveMonth.Value = 0;
        }

        private void cmdSaveYear_Click(object sender, EventArgs e)
        {
            if (txtYearPath.Text == "") return;
            cmdSaveYear.Enabled = false;
            isBusy.Visible = true;
            cmdYearPath.Enabled = false;
            dtpYear.Enabled = false;
            GetPhonesDelegate dn = GetPhones;
            IAsyncResult iar = dn.BeginInvoke(dtpYear.Value.Year.ToString(), null, null);
            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXSellPhone[] tempPhones = dn.EndInvoke(iar);
            pgbSaveYear.Value = 15;
            var tempLeave = new MysqlController.AskForLeave[tempSeller.Length][];
            for (int i = 0; i < tempSeller.Length; i++)
            {
                GetAskForLeaveDelegate dna = GetAskForLeave;
                IAsyncResult iara = dna.BeginInvoke(dtpYear.Value.Year.ToString(), i, null, null);

                while (iara.IsCompleted == false)
                {
                    Application.DoEvents();
                }
                tempLeave[i] = dna.EndInvoke(iara);
                Application.DoEvents();
            }
            pgbSaveYear.Value = 25;
            GetPayoutDelegate dn1 = GetPayout;
            IAsyncResult iar1 = dn1.BeginInvoke(dtpYear.Value.Year.ToString(), null, null);
            while (iar1.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.Payout[] tempPayout = dn1.EndInvoke(iar1);
            pgbSaveYear.Value = 35;
            GetEquipSoldDelegate dn2 = GetEquipSold;
            IAsyncResult iar2 = dn2.BeginInvoke(dtpYear.Value.Year.ToString(), null, null);
            while (iar2.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXEquip[] tempEquipSold = dn2.EndInvoke(iar2);
            pgbSaveYear.Value = 45;
            GetBinPhonesDelegate dn3 = GetBinPhones;
            IAsyncResult iar3 = dn3.BeginInvoke(dtpYear.Value.Year.ToString(), null, null);
            while (iar3.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.RefundPhone[] tempRefundPhone = dn3.EndInvoke(iar3);

            GetBinPhonesByFixDateDelegate dnfix = GetBinPhonesByFixDate;
            IAsyncResult iarfix = dnfix.BeginInvoke(dtpDate.Value.Year +
                                                    dtpDate.Value.Month.ToString().PadLeft(2, '0') +
                                                    dtpDate.Value.Day.ToString().PadLeft(2, '0'), null, null);
            while (iarfix.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.RefundPhone[] tempRefundPhoneFix = dnfix.EndInvoke(iarfix);

            pgbSaveYear.Value = 55;
            GetCustomDebtDelegate dn4 = GetCustomDebt;
            IAsyncResult iar4 = dn4.BeginInvoke(dtpYear.Value.Year.ToString(), null, null);
            while (iar4.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXCustomDebt[] tempCustomDebt = dn4.EndInvoke(iar4);
            pgbSaveYear.Value = 70;
            GetMarketDebtDelegate dn5 = GetMarketDebt;
            IAsyncResult iar5 = dn5.BeginInvoke(dtpYear.Value.Year.ToString(), null, null);
            while (iar5.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.LXMarketDebt[] tempMarketDebt = dn5.EndInvoke(iar5);
            pgbSaveYear.Value = 85;
            DelegateSaveData dnx = SaveData;

            IAsyncResult iarx = dnx.BeginInvoke(2, tempPhones, tempLeave, tempPayout, tempEquipSold, tempRefundPhone,
                                                tempRefundPhoneFix,
                                                tempCustomDebt,
                                                tempMarketDebt, null, null);

            while (iarx.IsCompleted == false)
            {
                Application.DoEvents();
            }

            bool isSaveOK = dnx.EndInvoke(iarx);
            pgbSaveYear.Value = 100;
            MessageBox.Show(
                isSaveOK
                    ? "生成报表成功!"
                    : "生成报表失败!",
                Application.ProductName, MessageBoxButtons.OK);
            cmdSaveYear.Enabled = true;
            dtpYear.Enabled = true;
            isBusy.Visible = false;
            cmdYearPath.Enabled = true;
            pgbSaveYear.Value = 0;
        }

        #endregion

        #region 保存private

        private MysqlController.LXCustomDebt SearchCustomDebt(string reqdate, string customdebt, string customdetail)
        {
            var iCustomDebt = new MysqlController.LXCustomDebt();

            isBusy.Visible = true;
            DelegateSearchCustomDebt dn = MysqlControl.SearchCustomDebt;

            IAsyncResult iar = dn.BeginInvoke(reqdate, customdebt, customdetail, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            iCustomDebt = dn.EndInvoke(iar);

            isBusy.Visible = false;

            return iCustomDebt;
        }

        private int SellerIndex(string SellerID)
        {
            int iIndex = 0;
            for (int i = 0; i < tempSellIndex.Length; i++)
            {
                if (tempSellIndex[i] == SellerID)
                {
                    iIndex = i;
                }
            }
            return iIndex;
        }


        private bool SaveData(int iType, IList<MysqlController.LXSellPhone> tempPhones,
                              IList<MysqlController.AskForLeave[]> tempLeave, IList<MysqlController.Payout> tempPayout,
                              IList<MysqlController.LXEquip> tempEquip,
                              IList<MysqlController.RefundPhone> tempRefundPhone,
                              IList<MysqlController.RefundPhone> tempRefundPhoneFix,
                              IList<MysqlController.LXCustomDebt> tempCustomDebt,
                              IList<MysqlController.LXMarketDebt> tempMarketDebt)
        {
            //String tempHTML;
            try
            {
                //这里生成HTML文件开始

                #region CSS头

                string tempHTML = "<HTML><Head>" +
                                  @"<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />" +
                                  @"<meta http-equiv=""Content-Language"" content=""zh-cn"" />" +
                                  @"<style type=""text/css"">" +
                                  @"body { " +
                                  @"font: normal 11px auto ""Trebuchet MS"", Verdana, Arial, Helvetica, sans-serif; " +
                                  @"color: #4f6b72; " +
                                  @"background: #E6EAE9; " +
                                  @"} " +
                                  @"a {" +
                                  "color: #c75f3e; " +
                                  "}" +
                                  "#mytable { " +
                                  "width: 950px;" +
                                  "padding: 0;" +
                                  "margin: 0;" +
                                  "}" +
                                  "caption { " +
                                  "padding: 0 0 5px 0; " +
                                  "width: 700px; " +
                                  @"font: italic 11px ""Trebuchet MS"", Verdana, Arial, Helvetica, sans-serif; " +
                                  "text-align: right; " +
                                  "}" +
                                  "th {" +
                                  @"font: bold 11px ""Trebuchet MS"", Verdana, Arial, Helvetica, sans-serif; " +
                                  "color: #4f6b72; " +
                                  "border-right: 1px solid #C1DAD7; " +
                                  "border-bottom: 1px solid #C1DAD7; " +
                                  "border-top: 1px solid #C1DAD7; " +
                                  "letter-spacing: 2px; " +
                                  "text-transform: uppercase; " +
                                  "text-align: left; " +
                                  "padding: 6px 6px 6px 12px; " +
                                  "background: #CAE8EA  no-repeat; " +
                                  "} " +
                                  "th.nobg { " +
                                  "border-top: 0; " +
                                  "border-left: 0; " +
                                  "border-right: 1px solid #C1DAD7; " +
                                  "background: none; " +
                                  "} " +
                                  "td { " +
                                  "border-right: 1px solid #C1DAD7; " +
                                  "border-bottom: 1px solid #C1DAD7; " +
                                  "background: #fff; " +
                                  "font-size:11px; " +
                                  "padding: 6px 6px 6px 12px; " +
                                  "color: #4f6b72; " +
                                  "} " +
                                  "td.alt { " +
                                  "background: #F5FAFA; " +
                                  "color: #797268; " +
                                  "} " +
                                  "th.spec { " +
                                  "border-left: 1px solid #C1DAD7; " +
                                  "border-top: 0; " +
                                  "background: #fff no-repeat; " +
                                  @"font: bold 10px ""Trebuchet MS"", Verdana, Arial, Helvetica, sans-serif; " +
                                  "}" +
                                  "th.specalt { " +
                                  "border-left: 1px solid #C1DAD7; " +
                                  "border-top: 0; " +
                                  "background: #f5fafa no-repeat; " +
                                  @"font: bold 10px ""Trebuchet MS"", Verdana, Arial, Helvetica, sans-serif; " +
                                  "color: #797268; " +
                                  "} " +
                                  "/*---------for IE 5.x bug*/ " +
                                  "html>body td{ font-size:11px;} " +
                                  "body,td,th { " +
                                  "font-family: 宋体, Arial; " +
                                  "font-size: 12px; " +
                                  "} " +
                                  "</style> " +
                                  @"<Title>龙翔通讯 - 店铺报表</Title></Head>";
                tempHTML = tempHTML + "<body>";
                tempHTML = tempHTML + "<center><h2>龙翔通讯</h2></center><br>";

                #endregion

                #region 数据准备

                string iPath = "";
                double AllPrice = 0;
                double AllEquipPrice = 0;
                double AllRefundPrice = 0;
                double AllCommision = 0;
                double AllEquipCommision = 0;
                double AllRefundCommision = 0;
                double AllProfit = 0;
                double AllEquipAllProfit = 0;
                double AllRefundAllProfit = 0;

                double AllRealProfit = 0;
                double AllEquipRealProfit = 0;
                double AllRefundRealProfit = 0;

                double AllSellPhones = 0;
                double AllSellEquip = 0;
                double AllSellRefund = 0;

                var AllSellersProfit = new double[tempSeller.Length];
                var AllSellersCommision = new double[tempSeller.Length];
                var AllSellersPhones = new double[tempSeller.Length];

                var AllEquipSellersProfit = new double[tempSeller.Length];
                var AllEquipSellersCommision = new double[tempSeller.Length];
                var AllEquipSellersPhones = new double[tempSeller.Length];

                var AllRefundSellersProfit = new double[tempSeller.Length];
                var AllRefundSellersCommision = new double[tempSeller.Length];
                var AllRefundSellersPhones = new double[tempSeller.Length];

                double AllCustomDebt = 0;
                double AllMarketDebt = 0;
                double AllPayout = 0;
                double AllPayin = 0;

                double DayShopValue = 0;
                //double MonthShopValue = 0;

                var iCustomDebt = new MysqlController.LXCustomDebt();

                #endregion

                switch (iType)
                {
                        #region 每日报表

                    case 0:
                        iPath = txtDailyPath.Text + @"龙翔通讯财务报表" + dtpDate.Value.Year + "-" + dtpDate.Value.Month + "-" +
                                dtpDate.Value.Day + ".html";
                        tempHTML = tempHTML + "<center><h3>按日财务报表 " + dtpDate.Value.Year + "-" + dtpDate.Value.Month +
                                   "-" +
                                   dtpDate.Value.Day + "</h3></center><br><br><hr>";
                        //

                        #region 手机销售

                        tempHTML = tempHTML + "<center><h4>手机销售</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>客户姓名</th>" +
                                   "<th>手机号码</th>" +
                                   "<th>手机型号</th>" +
                                   "<th>手机串号</th>" +
                                   "<th>销售价格</th>" +
                                   "<th>销售利润</th>" +
                                   "<th>销售提成</th>" +
                                   "<th>销售人员</th>" +
                                   "<th>保修</th>" +
                                   "<th>支付方式</th>" +
                                   "<th>剩余欠款</th>" +
                                   "<th>供货商</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempPhones.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempPhones[i].PhoneIMEI)) continue;
                            AllSellPhones++;
                            tempHTML = tempHTML + "<tr>";
                            //MysqlController.lxs tempUser = MysqlControl.ReadUserByPhoneID(tempPhones[i].PhoneID);
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneUserName + "</td>";
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneUsercellPhone + "</td>";
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneName + "</td>";
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneIMEI + "</td>";
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhonePrice + "</td>";
                            AllPrice = Math.Round(AllPrice + tempPhones[i].PhonePrice, 2);
                            DayShopValue = Math.Round(DayShopValue + tempPhones[i].PhonePrice, 2);
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneProfit + "</td>";
                            AllProfit = Math.Round(AllProfit + tempPhones[i].PhoneProfit, 2);
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneCommision + "</td>";
                            AllCommision = Math.Round(AllCommision + tempPhones[i].PhoneCommision, 2);
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneSeller +
                                       "</td>";
                            AllSellersPhones[SellerIndex(tempPhones[i].PhoneSeller)]++;
                            AllSellersProfit[SellerIndex(tempPhones[i].PhoneSeller)] = Math.Round(
                                AllSellersProfit[SellerIndex(tempPhones[i].PhoneSeller)] +
                                tempPhones[i].PhoneProfit, 2);

                            AllSellersCommision[SellerIndex(tempPhones[i].PhoneSeller)] = Math.Round(
                                AllSellersCommision[SellerIndex(tempPhones[i].PhoneSeller)] +
                                tempPhones[i].PhoneCommision, 2);
                            AllRealProfit = Math.Round(AllRealProfit +
                                                       Math.Round(tempPhones[i].PhoneProfit -
                                                                  tempPhones[i].PhoneCommision, 2), 2);

                            if (tempPhones[i].PhoneWarranty)
                            {
                                tempHTML = tempHTML + "<td>有</td>";
                            }
                            else
                            {
                                tempHTML = tempHTML + "<td>无</td>";
                            }
                            /*现金支付
刷卡支付
欠款支付
支付宝*/

                            switch (tempPhones[i].PhonePayment)
                            {
                                case 0:
                                    tempHTML = tempHTML + "<td>现金支付</td>";
                                    tempHTML = tempHTML + "<td>0</td>";
                                    break;
                                case 1:

                                    tempHTML = tempHTML + "<td>刷卡支付</td>";
                                    iCustomDebt = SearchCustomDebt(tempPhones[i].PhoneDate, tempPhones[i].PhoneUserName,
                                                                   "购买手机:" + tempPhones[i].PhoneName + " 备注:" +
                                                                   tempPhones[i].PhoneUserTip);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                                case 2:
                                    tempHTML = tempHTML + "<td>欠款支付</td>";
                                    iCustomDebt = SearchCustomDebt(tempPhones[i].PhoneDate, tempPhones[i].PhoneUserName,
                                                                   "购买手机:" + tempPhones[i].PhoneName + " 备注:" +
                                                                   tempPhones[i].PhoneUserTip);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                                case 3:
                                    tempHTML = tempHTML + "<td>支付宝</td>";
                                    iCustomDebt = SearchCustomDebt(tempPhones[i].PhoneDate, tempPhones[i].PhoneUserName,
                                                                   "购买手机:" + tempPhones[i].PhoneName + " 备注:" +
                                                                   tempPhones[i].PhoneUserTip);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                            }
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneSupplier + "</td>";
                            tempHTML = tempHTML + "</tr>";
                        }
                        tempHTML = tempHTML + "</table></center>" +
                                   "<br><center><p width = 950px align = center><font color = red>合计: 本日总销售台数:" +
                                   AllSellPhones +
                                   "台 本日总销售额为:" + AllPrice + "元 总利润为:" + AllProfit + "元<br>" +
                                   "本日总需要支付提成为:" + AllCommision + "元, 合计总实际利润为:" + AllRealProfit +
                                   "元</font></p></center><br>";

                        for (int i = 0; i < tempSeller.Length; i++)
                        {
                            if (tempSeller[i] != "" && tempSeller[i] != null)
                            {
                                tempHTML = tempHTML + "<center><p width = 950px align = center><font color = blue>" +
                                           tempSeller[i] + "总销售台数" + AllSellersPhones[i] + " 总创造利润:" +
                                           AllSellersProfit[i] + "元, 应支付提成为:" + AllSellersCommision[i] +
                                           "元</font></p></center>";
                            }
                        }

                        #endregion

                        #region 配件销售

                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>配件销售</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>配件名目</th>" +
                                   "<th>销售价格</th>" +
                                   "<th>配件成本</th>" +
                                   "<th>销售利润</th>" +
                                   "<th>销售提成</th>" +
                                   "<th>销售人员</th>" +
                                   "<th>支付方式</th>" +
                                   "<th>剩余欠款</th>" +
                                   "<th>供货商</th>" +
                                   "<th>备注</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempEquip.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempEquip[i].EquipDate)) continue;
                            AllSellEquip++;
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipName + "</td>";
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipPrice + "</td>";
                            AllEquipPrice = Math.Round(AllEquipPrice + tempEquip[i].EquipPrice, 2);
                            DayShopValue = Math.Round(DayShopValue + tempEquip[i].EquipPrice, 2);
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipRealPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipProfit + "</td>";
                            AllEquipAllProfit = Math.Round(AllEquipAllProfit + tempEquip[i].EquipProfit, 2);
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipCommision + "</td>";
                            AllEquipCommision = Math.Round(AllEquipCommision + tempEquip[i].EquipCommision, 2);
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipSellers + "</td>";

                            switch (tempEquip[i].EquipPayment)
                            {
                                case 0:
                                    tempHTML = tempHTML + "<td>现金支付</td>";
                                    tempHTML = tempHTML + "<td>0</td>";
                                    break;
                                case 1:
                                    tempHTML = tempHTML + "<td>刷卡支付</td>";
                                    iCustomDebt = SearchCustomDebt(tempEquip[i].EquipDate, tempEquip[i].EquipName,
                                                                   "购买配件:" + tempEquip[i].EquipName + " 备注:" +
                                                                   tempEquip[i].EquipBackup);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                                case 2:
                                    tempHTML = tempHTML + "<td>欠款支付</td>";
                                    iCustomDebt = SearchCustomDebt(tempEquip[i].EquipDate, tempEquip[i].EquipName,
                                                                   "购买配件:" + tempEquip[i].EquipName + " 备注:" +
                                                                   tempEquip[i].EquipBackup);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                                case 3:
                                    tempHTML = tempHTML + "<td>支付宝</td>";
                                    iCustomDebt = SearchCustomDebt(tempEquip[i].EquipDate, tempEquip[i].EquipName,
                                                                   "购买配件:" + tempEquip[i].EquipName + " 备注:" +
                                                                   tempEquip[i].EquipBackup);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                            }

                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipSupplier + "</td>";
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipBackup + "</td>";
                            tempHTML = tempHTML + "</tr>";
                            AllEquipRealProfit = Math.Round(AllEquipRealProfit +
                                                            Math.Round(
                                                                tempEquip[i].EquipProfit - tempEquip[i].EquipCommision,
                                                                2), 2);

                            AllEquipSellersPhones[SellerIndex(tempEquip[i].EquipSellers)]++;
                            AllEquipSellersProfit[SellerIndex(tempEquip[i].EquipSellers)] =
                                Math.Round(AllEquipSellersProfit[SellerIndex(tempEquip[i].EquipSellers)] +
                                           tempEquip[i].EquipProfit, 2);
                            AllEquipSellersCommision[SellerIndex(tempEquip[i].EquipSellers)] =
                                Math.Round(AllEquipSellersCommision[SellerIndex(tempEquip[i].EquipSellers)] +
                                           tempEquip[i].EquipCommision, 2);
                        }

                        tempHTML = tempHTML + "</table></center>" +
                                   "<p width = 950px align = center><font color = red>合计: 本日总销售配件数:" + AllSellEquip +
                                   "台 本日配件总销售额为:" + AllEquipPrice + "元 总利润为:" + AllEquipAllProfit + "元<br>" +
                                   "本日总需要支付提成为:" + AllEquipCommision + "元, 合计总实际利润为:" + AllEquipRealProfit +
                                   "元</font></p><br>";

                        for (int i = 0; i < tempSeller.Length; i++)
                        {
                            if (tempSeller[i] != "" && tempSeller[i] != null)
                            {
                                tempHTML = tempHTML + "<p width = 950px align = center><font color = blue>" +
                                           tempSeller[i] + "总销售配件数" + AllEquipSellersPhones[i] + " 总创造利润:" +
                                           AllEquipSellersProfit[i] + "元, 应支付提成为:" + AllEquipSellersCommision[i] +
                                           "元</font></p>";
                            }
                        }

                        #endregion

                        #region 返收销售

                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>返收销售</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>手机名称</th>" +
                                   "<th>收取价格</th>" +
                                   "<th>维修价格</th>" +
                                   "<th>手机串号</th>" +
                                   "<th>经办人</th>" +
                                   "<th>出售状态</th>" +
                                   "<th>出售价格</th>" +
                                   "<th>支付方式</th>" +
                                   "<th>利润</th>" +
                                   "<th>提成</th>" +
                                   "<th>备注</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempRefundPhone.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempRefundPhone[i].RefundDate)) continue;
                            AllSellRefund++;
                            AllRefundSellersPhones[SellerIndex(tempRefundPhone[i].RefundSeller)]++;
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundName + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundRepairPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundIMEI + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundSeller + "</td>";
                            AllRefundPrice = Math.Round(AllRefundPrice + tempRefundPhone[i].RefundFixPrice, 2);
                            AllRefundPrice = Math.Round(AllRefundPrice - tempRefundPhone[i].RefundPrice, 2);
                            AllRefundPrice = Math.Round(AllRefundPrice - tempRefundPhone[i].RefundRepairPrice, 2);

                            if (!tempRefundPhone[i].RefundIsFix)
                            {
                                tempHTML = tempHTML + "<td>" + "未出售" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                if (tempRefundPhone[i].RefundRefundType == 0)
                                {
                                    DayShopValue = Math.Round(DayShopValue - tempRefundPhone[i].RefundPrice, 2);
                                    DayShopValue = Math.Round(DayShopValue - tempRefundPhone[i].RefundRepairPrice, 2);
                                }
                            }
                            else
                            {
                                tempHTML = tempHTML + "<td>" + "已出售" + "</td>";
                                tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundFixPrice + "</td>";
                                switch (tempRefundPhone[i].RefundRefundType)
                                {
                                    case 0:
                                        tempHTML = tempHTML + "<td>现金支付</td>";
                                        break;
                                    case 1:
                                        tempHTML = tempHTML + "<td>刷卡支付</td>";
                                        break;
                                    case 2:
                                        tempHTML = tempHTML + "<td>欠款支付</td>";
                                        break;
                                    case 3:
                                        tempHTML = tempHTML + "<td>支付宝</td>";
                                        break;
                                }
                                tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundFixProfit + "</td>";
                                //if (tempRefundPhone[i].RefundFixType == 0)
                                //{
                                DayShopValue = Math.Round(DayShopValue + tempRefundPhone[i].RefundFixPrice, 2);
                                //}

                                AllRefundAllProfit = Math.Round(
                                    AllRefundAllProfit + tempRefundPhone[i].RefundFixProfit, 2);
                                tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundFixCommision + "</td>";
                                AllRefundCommision =
                                    Math.Round(AllRefundCommision + tempRefundPhone[i].RefundFixCommision, 2);
                                AllRefundRealProfit = Math.Round(AllRefundRealProfit +
                                                                 Math.Round(tempRefundPhone[i].RefundFixProfit -
                                                                            tempRefundPhone[i].RefundFixCommision, 2), 2);

                                AllRefundSellersProfit[SellerIndex(tempRefundPhone[i].RefundSeller)] =
                                    Math.Round(AllEquipSellersProfit[SellerIndex(tempRefundPhone[i].RefundSeller)] +
                                               tempRefundPhone[i].RefundFixProfit, 2);
                                AllRefundSellersCommision[SellerIndex(tempRefundPhone[i].RefundSeller)] =
                                    Math.Round(AllRefundSellersCommision[SellerIndex(tempRefundPhone[i].RefundSeller)] +
                                               tempRefundPhone[i].RefundFixCommision, 2);
                            }
                            tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundBackup + "</td>";
                            tempHTML = tempHTML + "</tr>";
                        }

                        for (int i = 0; i < tempRefundPhoneFix.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempRefundPhoneFix[i].RefundDate)) continue;
                            AllSellRefund++;
                            AllRefundSellersPhones[SellerIndex(tempRefundPhoneFix[i].RefundSeller)]++;
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundName + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundRepairPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundIMEI + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundSeller + "</td>";
                            AllRefundPrice = AllRefundPrice + tempRefundPhoneFix[i].RefundFixPrice -
                                             tempRefundPhoneFix[i].RefundPrice - tempRefundPhoneFix[i].RefundRepairPrice;
                            if (!tempRefundPhoneFix[i].RefundIsFix)
                            {
                                tempHTML = tempHTML + "<td>" + "未出售" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                if (tempRefundPhoneFix[i].RefundRefundType == 0)
                                {
                                    if (tempRefundPhoneFix[i].RefundDate == tempRefundPhoneFix[i].RefundFixDate)
                                    {
                                        DayShopValue = Math.Round(DayShopValue - tempRefundPhoneFix[i].RefundPrice, 2);
                                        DayShopValue = Math.Round(
                                            DayShopValue - tempRefundPhoneFix[i].RefundRepairPrice, 2);
                                    }
                                }
                            }
                            else
                            {
                                tempHTML = tempHTML + "<td>" + "已出售" + "</td>";
                                tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundFixPrice + "</td>";
                                switch (tempRefundPhoneFix[i].RefundRefundType)
                                {
                                    case 0:
                                        tempHTML = tempHTML + "<td>现金支付</td>";
                                        break;
                                    case 1:
                                        tempHTML = tempHTML + "<td>刷卡支付</td>";
                                        break;
                                    case 2:
                                        tempHTML = tempHTML + "<td>欠款支付</td>";
                                        break;
                                    case 3:
                                        tempHTML = tempHTML + "<td>支付宝</td>";
                                        break;
                                }
                                tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundFixProfit + "</td>";
                                //if (tempRefundPhone[i].RefundFixType == 0)
                                //{
                                DayShopValue = Math.Round(DayShopValue + tempRefundPhoneFix[i].RefundFixPrice, 2);
                                //}

                                AllRefundAllProfit =
                                    Math.Round(AllRefundAllProfit + tempRefundPhoneFix[i].RefundFixProfit, 2);
                                tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundFixCommision + "</td>";
                                AllRefundCommision =
                                    Math.Round(AllRefundCommision + tempRefundPhoneFix[i].RefundFixCommision, 2);
                                AllRefundRealProfit = Math.Round(AllRefundRealProfit +
                                                                 Math.Round(tempRefundPhoneFix[i].RefundFixProfit -
                                                                            tempRefundPhoneFix[i].RefundFixCommision, 2),
                                                                 2);

                                AllRefundSellersProfit[SellerIndex(tempRefundPhoneFix[i].RefundSeller)] =
                                    Math.Round(AllEquipSellersProfit[SellerIndex(tempRefundPhoneFix[i].RefundSeller)] +
                                               tempRefundPhoneFix[i].RefundFixProfit, 2);
                                AllRefundSellersCommision[SellerIndex(tempRefundPhoneFix[i].RefundSeller)] =
                                    Math.Round(
                                        AllRefundSellersCommision[SellerIndex(tempRefundPhoneFix[i].RefundSeller)] +
                                        tempRefundPhoneFix[i].RefundFixCommision, 2);
                            }
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundBackup + "</td>";
                            tempHTML = tempHTML + "</tr>";
                        }

                        tempHTML = tempHTML + "</table></center>" +
                                   "<p width = 950px align = center><font color = red>合计: 本日总进行返收数:" + AllSellRefund +
                                   "台  总利润为:" + AllRefundAllProfit + "元<br>" +
                                   "本日总需要支付提成为:" + AllRefundCommision + "元, 合计总实际利润为:" + AllRefundRealProfit +
                                   "元</font></p><br>";
                        //本日返收总销售额为:" + AllRefundPrice + "元
                        for (int i = 0; i < tempSeller.Length; i++)
                        {
                            if (tempSeller[i] != "" && tempSeller[i] != null)
                            {
                                tempHTML = tempHTML + "<p width = 950px align = center><font color = blue>" +
                                           tempSeller[i] + "总仅售返收数" + AllRefundSellersPhones[i] + " 总创造利润:" +
                                           AllRefundSellersProfit[i] + "元, 应支付提成为:" + AllRefundSellersCommision[i] +
                                           "元</font></p>";
                            }
                        }

                        #endregion

                        #region 客户欠款

                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>客户欠款 - 计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>欠款人</th>" +
                                   "<th>欠款详情</th>" +
                                   "<th>欠款额</th>" +
                                   "<th>到帐方式</th>" +
                                   "<th>欠款状态</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempCustomDebt.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempCustomDebt[i].DebtDate)) continue;
                            if (tempCustomDebt[i].DebtisInCircle)
                            {
                                tempHTML = tempHTML + "<tr>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtCustom + "</td>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtDetail + "</td>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtPrice + "</td>";
                                //DayShopValue
                                switch (tempCustomDebt[i].DebtType)
                                {
                                        /*
                             */
                                    case 0:
                                        tempHTML = tempHTML + "<td>刷卡支付</td>";
                                        break;
                                    case 1:
                                        tempHTML = tempHTML + "<td>欠款支付</td>";
                                        break;
                                    case 2:
                                        tempHTML = tempHTML + "<td>支付宝支付</td>";
                                        break;
                                }

                                if (!tempCustomDebt[i].DebtisFix)
                                {
                                    tempHTML = tempHTML + "<td>" + "未到帐" + "</td>";


                                    if (tempCustomDebt[i].DebtisInCircle)
                                    {
                                        //tempHTML = tempHTML + "<td>" + "是" + "</td>";
                                        DayShopValue = Math.Round(DayShopValue - tempCustomDebt[i].DebtUnFixPrice, 2);
                                    }
                                    else
                                    {
                                        //tempHTML = tempHTML + "<td>" + "否" + "</td>";
                                    }
                                    AllCustomDebt = Math.Round(AllCustomDebt + tempCustomDebt[i].DebtPrice, 2);
                                }
                                else
                                {
                                    if (tempCustomDebt[i].DebtFixType == 1) //类型1为现金
                                    {
                                        if (tempCustomDebt[i].DebtisInCircle)
                                        {
                                            DayShopValue = Math.Round(DayShopValue + tempCustomDebt[i].DebtPrice, 2);
                                        }
                                    }

                                    tempHTML = tempHTML + "<td>" + "已到帐" + "</td>";
                                    if (tempCustomDebt[i].DebtisInCircle)
                                    {
                                        //tempHTML = tempHTML + "<td>" + "是" + "</td>";
                                    }
                                    else
                                    {
                                        //tempHTML = tempHTML + "<td>" + "否" + "</td>";
                                    }
                                }
                                tempHTML = tempHTML + "</tr>";
                            }
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML + "<br><br><center><h4>客户欠款 - 不计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>欠款人</th>" +
                                   "<th>欠款详情</th>" +
                                   "<th>欠款额</th>" +
                                   "<th>到帐方式</th>" +
                                   "<th>欠款状态</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempCustomDebt.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempCustomDebt[i].DebtDate)) continue;
                            if (!tempCustomDebt[i].DebtisInCircle)
                            {
                                tempHTML = tempHTML + "<tr>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtCustom + "</td>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtDetail + "</td>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtPrice + "</td>";
                                //DayShopValue
                                switch (tempCustomDebt[i].DebtType)
                                {
                                        /*
                             */
                                    case 0:
                                        tempHTML = tempHTML + "<td>刷卡支付</td>";
                                        break;
                                    case 1:
                                        tempHTML = tempHTML + "<td>欠款支付</td>";
                                        break;
                                    case 2:
                                        tempHTML = tempHTML + "<td>支付宝支付</td>";
                                        break;
                                }

                                if (!tempCustomDebt[i].DebtisFix)
                                {
                                    tempHTML = tempHTML + "<td>" + "未到帐" + "</td>";


                                    if (tempCustomDebt[i].DebtisInCircle)
                                    {
                                        //tempHTML = tempHTML + "<td>" + "是" + "</td>";
                                        //DayShopValue = Math.Round(DayShopValue - tempCustomDebt[i].DebtUnFixPrice, 2);
                                    }
                                    else
                                    {
                                        //tempHTML = tempHTML + "<td>" + "否" + "</td>";
                                    }
                                    //AllCustomDebt = AllCustomDebt + tempCustomDebt[i].DebtPrice;
                                }
                                else
                                {
                                    if (tempCustomDebt[i].DebtFixType == 1) //类型1为现金
                                    {
                                        if (tempCustomDebt[i].DebtisInCircle)
                                        {
                                            //DayShopValue = Math.Round(DayShopValue + tempCustomDebt[i].DebtPrice, 2);
                                        }
                                    }

                                    tempHTML = tempHTML + "<td>" + "已到帐" + "</td>";
                                    if (tempCustomDebt[i].DebtisInCircle)
                                    {
                                        //tempHTML = tempHTML + "<td>" + "是" + "</td>";
                                    }
                                    else
                                    {
                                        //tempHTML = tempHTML + "<td>" + "否" + "</td>";
                                    }
                                }

                                tempHTML = tempHTML + "</tr>";
                            }
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML +
                                   "<p width = 950px align = center><font color = red>合计: 本日未到账客户欠款总额为:" + AllCustomDebt +
                                   "元</font></p><br>";

                        #endregion

                        #region 市场欠款

                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>市场欠款 - 计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>债权人</th>" +
                                   "<th>欠款详情</th>" +
                                   "<th>欠款额</th>" +
                                   "<th>经办人</th>" +
                                   "<th>备注</th>" +
                                   "<th>还款状态</th>" +
                                   "<th>还款时间</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempMarketDebt.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempMarketDebt[i].DebtDate)) continue;
                            if (!tempMarketDebt[i].DebtisCashCircle) continue;
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtMaster + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtDetail + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtSeller + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtBackup + "</td>";

                            if (!tempMarketDebt[i].DebtisFix)
                            {
                                tempHTML = tempHTML + "<td>" + "未还款" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                if (tempMarketDebt[i].DebtisCashCircle)
                                {
                                    DayShopValue = Math.Round(DayShopValue + tempMarketDebt[i].DebtPrice, 2);
                                }
                            }
                            else
                            {
                                tempHTML = tempHTML + "<td>" + "已还款" + "</td>";
                                tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtFixDate + "</td>";
                                if (tempMarketDebt[i].DebtisCashCircle)
                                {
                                    DayShopValue = Math.Round(DayShopValue - tempMarketDebt[i].DebtPrice, 2);
                                }
                                AllMarketDebt = Math.Round(AllMarketDebt + tempMarketDebt[i].DebtPrice, 2);
                            }
                            if (tempMarketDebt[i].DebtisCashCircle)
                            {
                                //tempHTML = tempHTML + "<td>" + "是" + "</td>";
                            }
                            else
                            {
                                //tempHTML = tempHTML + "<td>" + "否" + "</td>";
                            }
                            tempHTML = tempHTML + "</tr>";
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML + "<br><br><center><h4>市场欠款 - 不计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>债权人</th>" +
                                   "<th>欠款详情</th>" +
                                   "<th>欠款额</th>" +
                                   "<th>经办人</th>" +
                                   "<th>备注</th>" +
                                   "<th>还款状态</th>" +
                                   "<th>还款时间</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempMarketDebt.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempMarketDebt[i].DebtDate)) continue;
                            if (tempMarketDebt[i].DebtisCashCircle) continue;
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtMaster + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtDetail + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtSeller + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtBackup + "</td>";

                            if (!tempMarketDebt[i].DebtisFix)
                            {
                                tempHTML = tempHTML + "<td>" + "未还款" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                if (tempMarketDebt[i].DebtisCashCircle)
                                {
                                    //DayShopValue = Math.Round(DayShopValue + tempMarketDebt[i].DebtPrice, 2);
                                }
                            }
                            else
                            {
                                tempHTML = tempHTML + "<td>" + "已还款" + "</td>";
                                tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtFixDate + "</td>";
                                if (tempMarketDebt[i].DebtisCashCircle)
                                {
                                    //DayShopValue = Math.Round(DayShopValue - tempMarketDebt[i].DebtPrice, 2);
                                }
                                //AllMarketDebt = AllMarketDebt + tempMarketDebt[i].DebtPrice;
                            }
                            if (tempMarketDebt[i].DebtisCashCircle)
                            {
                                //tempHTML = tempHTML + "<td>" + "是" + "</td>";
                            }
                            else
                            {
                                //tempHTML = tempHTML + "<td>" + "否" + "</td>";
                            }
                            tempHTML = tempHTML + "</tr>";
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML +
                                   "<p width = 950px align = center><font color = red>合计: 本日已还款市场欠款总额为:" + AllMarketDebt +
                                   "元</font></p><br>";

                        #endregion

                        #region 固定支出

                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>固定支出 - 计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>支出时间</th>" +
                                   "<th>支出明细</th>" +
                                   "<th>金额</th>" +
                                   "<th>支出方式</th>" +
                                   "<th>备注</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";

                        //int AllPayout = 0;
                        for (int i = 0; i < tempPayout.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(tempPayout[i].PayoutPrice))
                            {
                                if (tempPayout[i].PayoutPrice.Substring(0, 1) != "-")
                                {
                                    if (tempPayout[i].PayoutInCase)
                                    {
                                        tempHTML = tempHTML + "<tr>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutDate.Substring(0, 4) + "年" +
                                                   tempPayout[i].PayoutDate.Substring(4, 2) + "月" +
                                                   tempPayout[i].PayoutDate.Substring(6, 2) + "日" + "</td>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutName + "</td>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutPrice + "</td>";
                                        AllPayout = Math.Round(AllPayout + double.Parse(tempPayout[i].PayoutPrice), 2);
                                        switch (tempPayout[i].PayoutType)
                                        {
                                            case "0":
                                                tempHTML = tempHTML + "<td>现金</td>";
                                                break;
                                            case "1":
                                                tempHTML = tempHTML + "<td>信用卡</td>";
                                                break;
                                            case "2":
                                                tempHTML = tempHTML + "<td>收入</td>";
                                                break;
                                        }

                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutBackup + "</td>";
                                        //tempHTML = tempHTML + "<td>是</td>";
                                        tempHTML = tempHTML + "</tr>";
                                    }
                                }
                            }
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML + "<br><br><center><h4>固定支出 - 不计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>支出时间</th>" +
                                   "<th>支出明细</th>" +
                                   "<th>金额</th>" +
                                   "<th>支出方式</th>" +
                                   "<th>备注</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";

                        //int AllPayout = 0;
                        for (int i = 0; i < tempPayout.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(tempPayout[i].PayoutPrice))
                            {
                                if (tempPayout[i].PayoutPrice.Substring(0, 1) != "-")
                                {
                                    if (!tempPayout[i].PayoutInCase)
                                    {
                                        tempHTML = tempHTML + "<tr>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutDate.Substring(0, 4) + "年" +
                                                   tempPayout[i].PayoutDate.Substring(4, 2) + "月" +
                                                   tempPayout[i].PayoutDate.Substring(6, 2) + "日" + "</td>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutName + "</td>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutPrice + "</td>";
                                        //AllPayout = AllPayout + double.Parse(tempPayout[i].PayoutPrice);
                                        switch (tempPayout[i].PayoutType)
                                        {
                                            case "0":
                                                tempHTML = tempHTML + "<td>现金</td>";
                                                break;
                                            case "1":
                                                tempHTML = tempHTML + "<td>信用卡</td>";
                                                break;
                                            case "2":
                                                tempHTML = tempHTML + "<td>收入</td>";
                                                break;
                                        }

                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutBackup + "</td>";
                                        //tempHTML = tempHTML + "<td>是</td>";
                                        tempHTML = tempHTML + "</tr>";
                                    }
                                }
                            }
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" +
                                   "本日固定支出为:" + AllPayout + "元</font></p></center><br>";

                        #endregion

                        #region 固定收入

                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>固定收入 - 计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>收入时间</th>" +
                                   "<th>收入明细</th>" +
                                   "<th>金额</th>" +
                                   "<th>备注</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";

                        //int AllPayin = 0;
                        for (int i = 0; i < tempPayout.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempPayout[i].PayoutPrice)) continue;
                            if (tempPayout[i].PayoutPrice.Substring(0, 1) == "-")
                            {
                                if (tempPayout[i].PayoutInCase)
                                {
                                    tempHTML = tempHTML + "<tr>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutDate.Substring(0, 4) + "年" +
                                               tempPayout[i].PayoutDate.Substring(4, 2) + "月" +
                                               tempPayout[i].PayoutDate.Substring(6, 2) + "日" + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutName + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutPrice + "</td>";
                                    AllPayin = Math.Round(AllPayin + double.Parse(tempPayout[i].PayoutPrice), 2);
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutBackup + "</td>";
                                    //tempHTML = tempHTML + "<td>是</td>";
                                    tempHTML = tempHTML + "</tr>";
                                }
                            }
                        }

                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML + "<br><br><center><h4>固定收入 - 不计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>收入时间</th>" +
                                   "<th>收入明细</th>" +
                                   "<th>金额</th>" +
                                   "<th>备注</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";

                        //int AllPayin = 0;
                        for (int i = 0; i < tempPayout.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempPayout[i].PayoutPrice)) continue;
                            if (tempPayout[i].PayoutPrice.Substring(0, 1) == "-")
                            {
                                if (!tempPayout[i].PayoutInCase)
                                {
                                    tempHTML = tempHTML + "<tr>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutDate.Substring(0, 4) + "年" +
                                               tempPayout[i].PayoutDate.Substring(4, 2) + "月" +
                                               tempPayout[i].PayoutDate.Substring(6, 2) + "日" + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutName + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutPrice + "</td>";
                                    //AllPayin = AllPayin + double.Parse(tempPayout[i].PayoutPrice);
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutBackup + "</td>";
                                    //tempHTML = tempHTML + "<td>是</td>";
                                    tempHTML = tempHTML + "</tr>";
                                }
                            }
                        }

                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" +
                                   "本日固定收入为:" + AllPayin + "元</font></p></center><br>";

                        tempHTML = tempHTML + "<hr><br><center><p width = 850px><font color = red>" +
                                   "本日店铺实际拥有金额为:" +
                                   Math.Round(Math.Round(DayShopValue - AllPayout, 2) - AllPayin, 2) +
                                   "元</font></p></center><br>";

                        break;

                        #endregion

                        #endregion

                        #region 每月报表

                    case 1:
                        iPath = txtMonthPath.Text + "龙翔通讯财务报表-月表-" + dtpMonth.Value.Year + "-" + dtpMonth.Value.Month +
                                ".html";
                        tempHTML = tempHTML + "<center><h3>月度财务报表 " + dtpMonth.Value.Year + "-" + dtpMonth.Value.Month +
                                   "</h3></center><br><br><hr>";

                        #region 手机销售

                        tempHTML = tempHTML + "<center><h4>手机销售</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>客户姓名</th>" +
                                   "<th>手机号码</th>" +
                                   "<th>手机型号</th>" +
                                   "<th>手机串号</th>" +
                                   "<th>销售价格</th>" +
                                   "<th>销售利润</th>" +
                                   "<th>销售提成</th>" +
                                   "<th>销售人员</th>" +
                                   "<th>保修</th>" +
                                   "<th>支付方式</th>" +
                                   "<th>剩余欠款</th>" +
                                   "<th>供货商</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempPhones.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempPhones[i].PhoneIMEI)) continue;
                            AllSellPhones++;
                            tempHTML = tempHTML + "<tr>";
                            //MysqlController.lxs tempUser = MysqlControl.ReadUserByPhoneID(tempPhones[i].PhoneID);
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneUserName + "</td>";
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneUsercellPhone + "</td>";
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneName + "</td>";
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneIMEI + "</td>";
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhonePrice + "</td>";
                            AllPrice = Math.Round(AllPrice + tempPhones[i].PhonePrice, 2);
                            DayShopValue = Math.Round(DayShopValue + tempPhones[i].PhonePrice, 2);
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneProfit + "</td>";
                            AllProfit = Math.Round(AllProfit + tempPhones[i].PhoneProfit, 2);
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneCommision + "</td>";
                            AllCommision = Math.Round(AllCommision + tempPhones[i].PhoneCommision, 2);
                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneSeller +
                                       "</td>";
                            AllSellersPhones[SellerIndex(tempPhones[i].PhoneSeller)]++;
                            AllSellersProfit[SellerIndex(tempPhones[i].PhoneSeller)] = Math.Round(
                                AllSellersProfit[SellerIndex(tempPhones[i].PhoneSeller)] +
                                tempPhones[i].PhoneProfit, 2);

                            AllSellersCommision[SellerIndex(tempPhones[i].PhoneSeller)] = Math.Round(
                                AllSellersCommision[SellerIndex(tempPhones[i].PhoneSeller)] +
                                tempPhones[i].PhoneCommision, 2);
                            AllRealProfit = Math.Round(AllRealProfit +
                                                       Math.Round(tempPhones[i].PhoneProfit -
                                                                  tempPhones[i].PhoneCommision, 2), 2);

                            if (tempPhones[i].PhoneWarranty)
                            {
                                tempHTML = tempHTML + "<td>有</td>";
                            }
                            else
                            {
                                tempHTML = tempHTML + "<td>无</td>";
                            }

                            switch (tempPhones[i].PhonePayment)
                            {
                                case 0:
                                    tempHTML = tempHTML + "<td>现金支付</td>";
                                    tempHTML = tempHTML + "<td>0</td>";
                                    break;
                                case 1:
                                    tempHTML = tempHTML + "<td>刷卡支付</td>";
                                    iCustomDebt = SearchCustomDebt(tempPhones[i].PhoneDate, tempPhones[i].PhoneUserName,
                                                                   "购买手机:" + tempPhones[i].PhoneName + " 备注:" +
                                                                   tempPhones[i].PhoneUserTip);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                                case 2:
                                    tempHTML = tempHTML + "<td>欠款支付</td>";
                                    iCustomDebt = SearchCustomDebt(tempPhones[i].PhoneDate, tempPhones[i].PhoneUserName,
                                                                   "购买手机:" + tempPhones[i].PhoneName + " 备注:" +
                                                                   tempPhones[i].PhoneUserTip);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                                case 3:
                                    tempHTML = tempHTML + "<td>支付宝</td>";
                                    iCustomDebt = SearchCustomDebt(tempPhones[i].PhoneDate, tempPhones[i].PhoneUserName,
                                                                   "购买手机:" + tempPhones[i].PhoneName + " 备注:" +
                                                                   tempPhones[i].PhoneUserTip);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                            }

                            tempHTML = tempHTML + "<td>" + tempPhones[i].PhoneSupplier + "</td>";
                            tempHTML = tempHTML + "</tr>";
                        }
                        tempHTML = tempHTML + "</table></center>" +
                                   "<br><center><p width = 950px align = center><font color = red>合计: 本月总销售台数:" +
                                   AllSellPhones +
                                   "台 本月总销售额为:" + AllPrice + "元 总利润为:" + AllProfit + "元<br>" +
                                   "本月总需要支付提成为:" + AllCommision + "元, 合计总实际利润为:" + AllRealProfit +
                                   "元</font></p></center><br>";

                        for (int i = 0; i < tempSeller.Length; i++)
                        {
                            if (tempSeller[i] != "" && tempSeller[i] != null)
                            {
                                tempHTML = tempHTML + "<center><p width = 950px align = center><font color = blue>" +
                                           tempSeller[i] + "总销售台数" + AllSellersPhones[i] + " 总创造利润:" +
                                           AllSellersProfit[i] + "元, 应支付提成为:" + AllSellersCommision[i] +
                                           "元</font></p></center>";
                            }
                        }

                        #endregion

                        #region 配件销售

                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>配件销售</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>配件名目</th>" +
                                   "<th>销售价格</th>" +
                                   "<th>配件成本</th>" +
                                   "<th>销售利润</th>" +
                                   "<th>销售提成</th>" +
                                   "<th>销售人员</th>" +
                                   "<th>支付方式</th>" +
                                   "<th>剩余欠款</th>" +
                                   "<th>供货商</th>" +
                                   "<th>备注</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempEquip.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempEquip[i].EquipDate)) continue;
                            AllSellEquip++;
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipName + "</td>";
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipPrice + "</td>";
                            AllEquipPrice = Math.Round(AllEquipPrice + tempEquip[i].EquipPrice, 2);
                            DayShopValue = Math.Round(DayShopValue + tempEquip[i].EquipPrice, 2);
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipRealPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipProfit + "</td>";
                            AllEquipAllProfit = Math.Round(AllEquipAllProfit + tempEquip[i].EquipProfit, 2);
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipCommision + "</td>";
                            AllEquipCommision = Math.Round(AllEquipCommision + tempEquip[i].EquipCommision, 2);
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipSellers + "</td>";

                            switch (tempEquip[i].EquipPayment)
                            {
                                case 0:
                                    tempHTML = tempHTML + "<td>现金支付</td>";
                                    tempHTML = tempHTML + "<td>0</td>";
                                    break;
                                case 1:
                                    tempHTML = tempHTML + "<td>刷卡支付</td>";
                                    iCustomDebt = SearchCustomDebt(tempEquip[i].EquipDate, tempEquip[i].EquipName,
                                                                   "购买配件:" + tempEquip[i].EquipName + " 备注:" +
                                                                   tempEquip[i].EquipBackup);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                                case 2:
                                    tempHTML = tempHTML + "<td>欠款支付</td>";
                                    iCustomDebt = SearchCustomDebt(tempEquip[i].EquipDate, tempEquip[i].EquipName,
                                                                   "购买配件:" + tempEquip[i].EquipName + " 备注:" +
                                                                   tempEquip[i].EquipBackup);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                                case 3:
                                    tempHTML = tempHTML + "<td>支付宝</td>";
                                    iCustomDebt = SearchCustomDebt(tempEquip[i].EquipDate, tempEquip[i].EquipName,
                                                                   "购买配件:" + tempEquip[i].EquipName + " 备注:" +
                                                                   tempEquip[i].EquipBackup);
                                    tempHTML = tempHTML + "<td>" + iCustomDebt.DebtUnFixPrice + "</td>";
                                    break;
                            }

                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipSupplier + "</td>";
                            tempHTML = tempHTML + "<td>" + tempEquip[i].EquipBackup + "</td>";
                            tempHTML = tempHTML + "</tr>";
                            AllEquipRealProfit = Math.Round(AllEquipRealProfit +
                                                            Math.Round(
                                                                tempEquip[i].EquipProfit - tempEquip[i].EquipCommision,
                                                                2), 2);

                            AllEquipSellersPhones[SellerIndex(tempEquip[i].EquipSellers)]++;
                            AllEquipSellersProfit[SellerIndex(tempEquip[i].EquipSellers)] =
                                Math.Round(AllEquipSellersProfit[SellerIndex(tempEquip[i].EquipSellers)] +
                                           tempEquip[i].EquipProfit, 2);
                            AllEquipSellersCommision[SellerIndex(tempEquip[i].EquipSellers)] =
                                Math.Round(AllEquipSellersCommision[SellerIndex(tempEquip[i].EquipSellers)] +
                                           tempEquip[i].EquipCommision, 2);
                        }

                        tempHTML = tempHTML + "</table></center>" +
                                   "<p width = 950px align = center><font color = red>合计: 本月总销售配件数:" + AllSellEquip +
                                   "件 本月配件总销售额为:" + AllEquipPrice + "元 总利润为:" + AllEquipAllProfit + "元<br>" +
                                   "本月总需要支付提成为:" + AllEquipCommision + "元, 合计总实际利润为:" + AllEquipRealProfit +
                                   "元</font></p><br>";

                        for (int i = 0; i < tempSeller.Length; i++)
                        {
                            if (tempSeller[i] != "" && tempSeller[i] != null)
                            {
                                tempHTML = tempHTML + "<p width = 950px align = center><font color = blue>" +
                                           tempSeller[i] + "总销售配件数" + AllEquipSellersPhones[i] + " 总创造利润:" +
                                           AllEquipSellersProfit[i] + "元, 应支付提成为:" + AllEquipSellersCommision[i] +
                                           "元</font></p>";
                            }
                        }

                        #endregion

                        //返收销售
                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>返收销售</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>手机名称</th>" +
                                   "<th>收取价格</th>" +
                                   "<th>维修价格</th>" +
                                   "<th>手机串号</th>" +
                                   "<th>经办人</th>" +
                                   "<th>出售状态</th>" +
                                   "<th>出售价格</th>" +
                                   "<th>支付方式</th>" +
                                   "<th>利润</th>" +
                                   "<th>提成</th>" +
                                   "<th>备注</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempRefundPhone.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempRefundPhone[i].RefundDate)) continue;
                            AllSellRefund++;
                            AllRefundSellersPhones[SellerIndex(tempRefundPhone[i].RefundSeller)]++;
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundName + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundRepairPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundIMEI + "</td>";
                            tempHTML = tempHTML + "<td>" + tempSeller[SellerIndex(tempRefundPhone[i].RefundSeller)] +
                                       "</td>";
                            AllRefundPrice = AllRefundPrice + tempRefundPhone[i].RefundFixPrice -
                                             tempRefundPhone[i].RefundPrice - tempRefundPhone[i].RefundRepairPrice;
                            if (!tempRefundPhone[i].RefundIsFix)
                            {
                                tempHTML = tempHTML + "<td>" + "未出售" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                if (tempRefundPhone[i].RefundRefundType == 0)
                                {
                                    DayShopValue = Math.Round(DayShopValue - tempRefundPhone[i].RefundPrice, 2);
                                    DayShopValue = Math.Round(DayShopValue - tempRefundPhone[i].RefundRepairPrice, 2);
                                }
                            }
                            else
                            {
                                tempHTML = tempHTML + "<td>" + "已出售" + "</td>";
                                tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundFixPrice + "</td>";
                                switch (tempRefundPhone[i].RefundRefundType)
                                {
                                    case 0:
                                        tempHTML = tempHTML + "<td>现金支付</td>";
                                        break;
                                    case 1:
                                        tempHTML = tempHTML + "<td>刷卡支付</td>";
                                        break;
                                    case 2:
                                        tempHTML = tempHTML + "<td>欠款支付</td>";
                                        break;
                                    case 3:
                                        tempHTML = tempHTML + "<td>支付宝</td>";
                                        break;
                                }
                                tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundFixProfit + "</td>";
                                DayShopValue = Math.Round(DayShopValue + tempRefundPhone[i].RefundFixPrice, 2);
                                AllRefundAllProfit = Math.Round(
                                    AllRefundAllProfit + tempRefundPhone[i].RefundFixProfit, 2);
                                tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundFixCommision + "</td>";
                                AllRefundCommision =
                                    Math.Round(AllRefundCommision + tempRefundPhone[i].RefundFixCommision, 2);
                                AllRefundRealProfit = Math.Round(AllRefundRealProfit +
                                                                 Math.Round(tempRefundPhone[i].RefundFixProfit -
                                                                            tempRefundPhone[i].RefundFixCommision, 2), 2);

                                AllRefundSellersProfit[SellerIndex(tempRefundPhone[i].RefundSeller)] =
                                    Math.Round(AllEquipSellersProfit[SellerIndex(tempRefundPhone[i].RefundSeller)] +
                                               tempRefundPhone[i].RefundFixProfit, 2);
                                AllRefundSellersCommision[SellerIndex(tempRefundPhone[i].RefundSeller)] =
                                    Math.Round(AllRefundSellersCommision[SellerIndex(tempRefundPhone[i].RefundSeller)] +
                                               tempRefundPhone[i].RefundFixCommision, 2);
                            }
                            tempHTML = tempHTML + "<td>" + tempRefundPhone[i].RefundBackup + "</td>";
                            tempHTML = tempHTML + "</tr>";
                        }

                        for (int i = 0; i < tempRefundPhoneFix.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempRefundPhoneFix[i].RefundDate)) continue;
                            AllSellRefund++;
                            AllRefundSellersPhones[SellerIndex(tempRefundPhoneFix[i].RefundSeller)]++;
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundName + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundRepairPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundIMEI + "</td>";
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundSeller + "</td>";
                            AllRefundPrice = AllRefundPrice + tempRefundPhoneFix[i].RefundFixPrice -
                                             tempRefundPhoneFix[i].RefundPrice - tempRefundPhoneFix[i].RefundRepairPrice;
                            if (!tempRefundPhoneFix[i].RefundIsFix)
                            {
                                tempHTML = tempHTML + "<td>" + "未出售" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                if (tempRefundPhoneFix[i].RefundRefundType == 0)
                                {
                                    if (tempRefundPhoneFix[i].RefundDate == tempRefundPhoneFix[i].RefundFixDate)
                                    {
                                        DayShopValue = Math.Round(DayShopValue - tempRefundPhoneFix[i].RefundPrice, 2);
                                        DayShopValue = Math.Round(
                                            DayShopValue - tempRefundPhoneFix[i].RefundRepairPrice, 2);
                                    }
                                }
                            }
                            else
                            {
                                tempHTML = tempHTML + "<td>" + "已出售" + "</td>";
                                tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundFixPrice + "</td>";
                                switch (tempRefundPhoneFix[i].RefundRefundType)
                                {
                                    case 0:
                                        tempHTML = tempHTML + "<td>现金支付</td>";
                                        break;
                                    case 1:
                                        tempHTML = tempHTML + "<td>刷卡支付</td>";
                                        break;
                                    case 2:
                                        tempHTML = tempHTML + "<td>欠款支付</td>";
                                        break;
                                    case 3:
                                        tempHTML = tempHTML + "<td>支付宝</td>";
                                        break;
                                }
                                tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundFixProfit + "</td>";
                                DayShopValue = Math.Round(DayShopValue + tempRefundPhoneFix[i].RefundFixPrice, 2);
                                AllRefundAllProfit =
                                    Math.Round(AllRefundAllProfit + tempRefundPhoneFix[i].RefundFixProfit, 2);
                                tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundFixCommision + "</td>";
                                AllRefundCommision =
                                    Math.Round(AllRefundCommision + tempRefundPhoneFix[i].RefundFixCommision, 2);
                                AllRefundRealProfit = Math.Round(AllRefundRealProfit +
                                                                 Math.Round(tempRefundPhoneFix[i].RefundFixProfit -
                                                                            tempRefundPhoneFix[i].RefundFixCommision, 2),
                                                                 2);

                                AllRefundSellersProfit[SellerIndex(tempRefundPhoneFix[i].RefundSeller)] =
                                    Math.Round(AllEquipSellersProfit[SellerIndex(tempRefundPhoneFix[i].RefundSeller)] +
                                               tempRefundPhoneFix[i].RefundFixProfit, 2);
                                AllRefundSellersCommision[SellerIndex(tempRefundPhoneFix[i].RefundSeller)] =
                                    Math.Round(
                                        AllRefundSellersCommision[SellerIndex(tempRefundPhoneFix[i].RefundSeller)] +
                                        tempRefundPhoneFix[i].RefundFixCommision, 2);
                            }
                            tempHTML = tempHTML + "<td>" + tempRefundPhoneFix[i].RefundBackup + "</td>";
                            tempHTML = tempHTML + "</tr>";
                        }

                        tempHTML = tempHTML + "</table></center>" +
                                   "<p width = 950px align = center><font color = red>合计: 本月总进行返收数:" + AllSellRefund +
                                   "件  总利润为:" + AllRefundAllProfit + "元<br>" +
                                   "本月总需要支付提成为:" + AllRefundCommision + "元, 合计总实际利润为:" + AllRefundRealProfit +
                                   "元</font></p><br>";
                        //本月返收总销售额为:" + AllRefundPrice + "元
                        for (int i = 0; i < tempSeller.Length; i++)
                        {
                            if (tempSeller[i] != "" && tempSeller[i] != null)
                            {
                                tempHTML = tempHTML + "<p width = 950px align = center><font color = blue>" +
                                           tempSeller[i] + "总仅售返收数" + AllRefundSellersPhones[i] + " 总创造利润:" +
                                           AllRefundSellersProfit[i] + "元, 应支付提成为:" + AllRefundSellersCommision[i] +
                                           "元</font></p>";
                            }
                        }

                        //客户欠款
                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>客户欠款 - 计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>欠款人</th>" +
                                   "<th>欠款详情</th>" +
                                   "<th>欠款额</th>" +
                                   "<th>到帐方式</th>" +
                                   "<th>欠款状态</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempCustomDebt.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempCustomDebt[i].DebtDate)) continue;
                            if (tempCustomDebt[i].DebtisInCircle)
                            {
                                tempHTML = tempHTML + "<tr>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtCustom + "</td>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtDetail + "</td>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtPrice + "</td>";

                                switch (tempCustomDebt[i].DebtType)
                                {
                                    case 0:
                                        tempHTML = tempHTML + "<td>刷卡支付</td>";
                                        break;
                                    case 1:
                                        tempHTML = tempHTML + "<td>欠款支付</td>";
                                        break;
                                    case 2:
                                        tempHTML = tempHTML + "<td>支付宝支付</td>";
                                        break;
                                }

                                if (!tempCustomDebt[i].DebtisFix)
                                {
                                    tempHTML = tempHTML + "<td>" + "未到帐" + "</td>";
                                    if (tempCustomDebt[i].DebtisInCircle)
                                    {
                                        //tempHTML = tempHTML + "<td>" + "是" + "</td>";
                                        DayShopValue = Math.Round(DayShopValue - tempCustomDebt[i].DebtUnFixPrice, 2);
                                    }
                                    AllCustomDebt = Math.Round(AllCustomDebt + tempCustomDebt[i].DebtPrice, 2);
                                }
                                else
                                {
                                    if (tempCustomDebt[i].DebtFixType == 1) //类型1为现金
                                    {
                                        if (tempCustomDebt[i].DebtisInCircle)
                                        {
                                            DayShopValue = Math.Round(DayShopValue + tempCustomDebt[i].DebtPrice, 2);
                                        }
                                    }
                                    tempHTML = tempHTML + "<td>" + "已到帐" + "</td>";
                                }
                                tempHTML = tempHTML + "</tr>";
                            }
                        }
                        tempHTML = tempHTML + "</table></center>";


                        tempHTML = tempHTML + "<br><br><center><h4>客户欠款 - 不计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>欠款人</th>" +
                                   "<th>欠款详情</th>" +
                                   "<th>欠款额</th>" +
                                   "<th>到帐方式</th>" +
                                   "<th>欠款状态</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempCustomDebt.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempCustomDebt[i].DebtDate)) continue;
                            if (!tempCustomDebt[i].DebtisInCircle)
                            {
                                tempHTML = tempHTML + "<tr>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtCustom + "</td>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtDetail + "</td>";
                                tempHTML = tempHTML + "<td>" + tempCustomDebt[i].DebtPrice + "</td>";
                                //DayShopValue
                                switch (tempCustomDebt[i].DebtType)
                                {
                                        /*
                             */
                                    case 0:
                                        tempHTML = tempHTML + "<td>刷卡支付</td>";
                                        break;
                                    case 1:
                                        tempHTML = tempHTML + "<td>欠款支付</td>";
                                        break;
                                    case 2:
                                        tempHTML = tempHTML + "<td>支付宝支付</td>";
                                        break;
                                }

                                if (!tempCustomDebt[i].DebtisFix)
                                {
                                    tempHTML = tempHTML + "<td>" + "未到帐" + "</td>";

                                    //AllCustomDebt = AllCustomDebt + tempCustomDebt[i].DebtPrice;
                                }
                                else
                                {
                                    tempHTML = tempHTML + "<td>" + "已到帐" + "</td>";
                                }

                                tempHTML = tempHTML + "</tr>";
                            }
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML +
                                   "<p width = 950px align = center><font color = red>合计: 本月未到账客户欠款总额为:" + AllCustomDebt +
                                   "元</font></p><br>";

                        //市场欠款
                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>市场欠款 - 计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>债权人</th>" +
                                   "<th>欠款详情</th>" +
                                   "<th>欠款额</th>" +
                                   "<th>经办人</th>" +
                                   "<th>备注</th>" +
                                   "<th>还款状态</th>" +
                                   "<th>还款时间</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempMarketDebt.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempMarketDebt[i].DebtDate)) continue;
                            if (!tempMarketDebt[i].DebtisCashCircle) continue;
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtMaster + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtDetail + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtSeller + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtBackup + "</td>";

                            if (!tempMarketDebt[i].DebtisFix)
                            {
                                tempHTML = tempHTML + "<td>" + "未还款" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                                if (tempMarketDebt[i].DebtisCashCircle)
                                {
                                    DayShopValue = Math.Round(DayShopValue + tempMarketDebt[i].DebtPrice, 2);
                                }
                            }
                            else
                            {
                                tempHTML = tempHTML + "<td>" + "已还款" + "</td>";
                                tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtFixDate + "</td>";
                                if (tempMarketDebt[i].DebtisCashCircle)
                                {
                                    DayShopValue = Math.Round(DayShopValue - tempMarketDebt[i].DebtPrice, 2);
                                }
                                AllMarketDebt = Math.Round(AllMarketDebt + tempMarketDebt[i].DebtPrice, 2);
                            }
                            tempHTML = tempHTML + "</tr>";
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML + "<br><br><center><h4>市场欠款 - 不计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>债权人</th>" +
                                   "<th>欠款详情</th>" +
                                   "<th>欠款额</th>" +
                                   "<th>经办人</th>" +
                                   "<th>备注</th>" +
                                   "<th>还款状态</th>" +
                                   "<th>还款时间</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempMarketDebt.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempMarketDebt[i].DebtDate)) continue;
                            if (tempMarketDebt[i].DebtisCashCircle) continue;
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtMaster + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtDetail + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtPrice + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtSeller + "</td>";
                            tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtBackup + "</td>";

                            if (!tempMarketDebt[i].DebtisFix)
                            {
                                tempHTML = tempHTML + "<td>" + "未还款" + "</td>";
                                tempHTML = tempHTML + "<td>" + "N/A" + "</td>";
                            }
                            else
                            {
                                tempHTML = tempHTML + "<td>" + "已还款" + "</td>";
                                tempHTML = tempHTML + "<td>" + tempMarketDebt[i].DebtFixDate + "</td>";

                                //AllMarketDebt = AllMarketDebt + tempMarketDebt[i].DebtPrice;
                            }
                            if (tempMarketDebt[i].DebtisCashCircle)
                            {
                                //tempHTML = tempHTML + "<td>" + "是" + "</td>";
                            }
                            else
                            {
                                //tempHTML = tempHTML + "<td>" + "否" + "</td>";
                            }
                            tempHTML = tempHTML + "</tr>";
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML +
                                   "<p width = 950px align = center><font color = red>合计: 本月已还款市场欠款总额为:" + AllMarketDebt +
                                   "元</font></p><br>";

                        //固定支出
                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>固定支出 - 计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>支出时间</th>" +
                                   "<th>支出明细</th>" +
                                   "<th>金额</th>" +
                                   "<th>支出方式</th>" +
                                   "<th>备注</th>" +
                                   "</tr>";

                        //int AllPayout = 0;
                        for (int i = 0; i < tempPayout.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(tempPayout[i].PayoutPrice))
                            {
                                if (tempPayout[i].PayoutPrice.Substring(0, 1) != "-")
                                {
                                    if (tempPayout[i].PayoutInCase)
                                    {
                                        tempHTML = tempHTML + "<tr>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutDate.Substring(0, 4) + "年" +
                                                   tempPayout[i].PayoutDate.Substring(4, 2) + "月" +
                                                   tempPayout[i].PayoutDate.Substring(6, 2) + "日" + "</td>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutName + "</td>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutPrice + "</td>";
                                        AllPayout = Math.Round(AllPayout + double.Parse(tempPayout[i].PayoutPrice), 2);
                                        switch (tempPayout[i].PayoutType)
                                        {
                                            case "0":
                                                tempHTML = tempHTML + "<td>现金</td>";
                                                break;
                                            case "1":
                                                tempHTML = tempHTML + "<td>信用卡</td>";
                                                break;
                                            case "2":
                                                tempHTML = tempHTML + "<td>收入</td>";
                                                break;
                                        }

                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutBackup + "</td>";
                                        tempHTML = tempHTML + "</tr>";
                                    }
                                }
                            }
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML + "<br><br><center><h4>固定支出 - 不计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>支出时间</th>" +
                                   "<th>支出明细</th>" +
                                   "<th>金额</th>" +
                                   "<th>支出方式</th>" +
                                   "<th>备注</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";

                        //int AllPayout = 0;
                        for (int i = 0; i < tempPayout.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(tempPayout[i].PayoutPrice))
                            {
                                if (tempPayout[i].PayoutPrice.Substring(0, 1) != "-")
                                {
                                    if (!tempPayout[i].PayoutInCase)
                                    {
                                        tempHTML = tempHTML + "<tr>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutDate.Substring(0, 4) + "年" +
                                                   tempPayout[i].PayoutDate.Substring(4, 2) + "月" +
                                                   tempPayout[i].PayoutDate.Substring(6, 2) + "日" + "</td>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutName + "</td>";
                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutPrice + "</td>";
                                        //AllPayout = AllPayout + double.Parse(tempPayout[i].PayoutPrice);
                                        switch (tempPayout[i].PayoutType)
                                        {
                                            case "0":
                                                tempHTML = tempHTML + "<td>现金</td>";
                                                break;
                                            case "1":
                                                tempHTML = tempHTML + "<td>信用卡</td>";
                                                break;
                                            case "2":
                                                tempHTML = tempHTML + "<td>收入</td>";
                                                break;
                                        }

                                        tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutBackup + "</td>";
                                        //tempHTML = tempHTML + "<td>是</td>";
                                        tempHTML = tempHTML + "</tr>";
                                    }
                                }
                            }
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" +
                                   "本月固定支出为:" + AllPayout + "元</font></p></center><br>";

                        //固定收入
                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>固定收入 - 计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>收入时间</th>" +
                                   "<th>收入明细</th>" +
                                   "<th>金额</th>" +
                                   "<th>备注</th>" +
                                   "</tr>";

                        //int AllPayin = 0;
                        for (int i = 0; i < tempPayout.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempPayout[i].PayoutPrice)) continue;
                            if (tempPayout[i].PayoutPrice.Substring(0, 1) == "-")
                            {
                                if (tempPayout[i].PayoutInCase)
                                {
                                    tempHTML = tempHTML + "<tr>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutDate.Substring(0, 4) + "年" +
                                               tempPayout[i].PayoutDate.Substring(4, 2) + "月" +
                                               tempPayout[i].PayoutDate.Substring(6, 2) + "日" + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutName + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutPrice + "</td>";
                                    AllPayin = Math.Round(AllPayin + double.Parse(tempPayout[i].PayoutPrice), 2);
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutBackup + "</td>";
                                    tempHTML = tempHTML + "</tr>";
                                }
                            }
                        }
                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML + "<br><br><center><h4>固定收入 - 不计入现金流</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>收入时间</th>" +
                                   "<th>收入明细</th>" +
                                   "<th>金额</th>" +
                                   "<th>备注</th>" +
                                   //"<th>计入现金流</th>" +
                                   "</tr>";

                        //int AllPayin = 0;
                        for (int i = 0; i < tempPayout.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempPayout[i].PayoutPrice)) continue;
                            if (tempPayout[i].PayoutPrice.Substring(0, 1) == "-")
                            {
                                if (!tempPayout[i].PayoutInCase)
                                {
                                    tempHTML = tempHTML + "<tr>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutDate.Substring(0, 4) + "年" +
                                               tempPayout[i].PayoutDate.Substring(4, 2) + "月" +
                                               tempPayout[i].PayoutDate.Substring(6, 2) + "日" + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutName + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutPrice + "</td>";
                                    //AllPayin = AllPayin + double.Parse(tempPayout[i].PayoutPrice);
                                    tempHTML = tempHTML + "<td>" + tempPayout[i].PayoutBackup + "</td>";
                                    //tempHTML = tempHTML + "<td>是</td>";
                                    tempHTML = tempHTML + "</tr>";
                                }
                            }
                        }

                        tempHTML = tempHTML + "</table></center>";

                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" +
                                   "本月固定收入为:" + AllPayin + "元</font></p></center><br>";

                        tempHTML = tempHTML + "<hr><br><center><p width = 850px><font color = red>" +
                                   "本月店铺实际拥有金额为:" +
                                   Math.Round(Math.Round(DayShopValue - AllPayout, 2) - AllPayin, 2) +
                                   "元</font></p></center><br>";

                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" +
                                   "本月店铺租金为:" + P1 + "元</font></p></center>";
                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" +
                                   "本月市场管理费为:" + P2 + "元</font></p></center>";
                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" +
                                   "本月物业管理费为:" + P3 + "元</font></p></center>";
                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" +
                                   "本月电话费为:" + P4 + "元</font></p></center>";
                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" +
                                   "本月税收为:" + P5 + "元</font></p></center>";
                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" +
                                   "本月电费为:" + P6 + "元</font></p></center>";
                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" +
                                   "本月其他杂项为:" + P7 + "元</font></p></center>";

                        //请假
                        tempHTML = tempHTML + "<br><br><hr><br><br><center><h4>请假</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1"" id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>请假时间</th>" +
                                   "<th>请假人员</th>" +
                                   "<th>请假类型</th>" +
                                   "<th>请假时长</th>" +
                                   "<th>请假备注</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempSeller.Length; i++)
                        {
                            if (tempSeller[i] != null && tempSeller[i] != "")
                            {
                                for (int j = 0; j < tempLeave[i].Length; j++)
                                {
                                    if (string.IsNullOrEmpty(tempLeave[i][j].AskDate)) continue;
                                    tempHTML = tempHTML + "<tr>";

                                    tempHTML = tempHTML + "<td>" + tempLeave[i][j].AskDate.Substring(0, 4) + "年" +
                                               tempLeave[i][j].AskDate.Substring(4, 2) + "月" +
                                               tempLeave[i][j].AskDate.Substring(6, 2) + "日" + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempLeave[i][j].AskSeller + "</td>";
                                    switch (tempLeave[i][j].AskType)
                                    {
                                        case 0:
                                            tempHTML = tempHTML + "<td>事假</td>";
                                            break;
                                        case 1:
                                            tempHTML = tempHTML + "<td>病假</td>";
                                            break;
                                        case 2:
                                            tempHTML = tempHTML + "<td>丧假</td>";
                                            break;
                                        case 3:
                                            tempHTML = tempHTML + "<td>产假</td>";
                                            break;
                                    }
                                    tempHTML = tempHTML + "<td>" + tempLeave[i][j].AskDuration + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempLeave[i][j].AskTip + "</td>";
                                    tempHTML = tempHTML + "</tr>";
                                }
                            }
                        }

                        tempHTML = tempHTML + "</table></center><br><hr>";

                        break;

                        #endregion

                        #region 年度财务报表

                        /*
                    case 2:
                        iPath = txtYearPath.Text + "龙翔通讯财务报表-年表-" + dtpYear.Value.Year + ".html";
                        tempHTML = tempHTML + "<center><h3>年度财务报表 " + dtpYear.Value.Year + "</h3></center><br><br><hr>";
                        var tempMonthPrice = new int[12];
                        var tempMonthPrifit = new int[12];
                        var tempMonthCommision = new int[12];
                        var tempMonthPhones = new int[12];
                        var tempSellersPhones = new int[tempSeller.Length][];
                        var tempSellersProfit = new int[tempSeller.Length][];
                        var tempSellersCommision = new int[tempSeller.Length][];
                        var tempRealProfit = new int[12];

                        for (int i = 0; i < tempSellersPhones.Length; i++)
                        {
                            tempSellersPhones[i] = new int[12];
                            tempSellersProfit[i] = new int[12];
                            tempSellersCommision[i] = new int[12];
                        }

                        for (int i = 0; i < tempPhones.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempPhones[i].PhoneIMEI)) continue;
                            AllSellPhones++;
                            AllSellersPhones[int.Parse(tempPhones[i].PhoneSeller)]++;
                            tempMonthPhones[int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1]++;
                            tempSellersPhones[int.Parse(tempPhones[i].PhoneSeller)][
                                int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1]++;
                            //台数
                            AllPrice = AllPrice + int.Parse(tempPhones[i].PhonePrice);
                            tempMonthPrice[int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] =
                                tempMonthPrice[int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] +
                                int.Parse(tempPhones[i].PhonePrice);
                            //销售价格
                            tempMonthPrifit[int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] =
                                tempMonthPrifit[int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] +
                                int.Parse(tempPhones[i].PhoneProfit);
                            AllProfit = AllProfit + int.Parse(tempPhones[i].PhoneProfit);
                            AllSellersProfit[int.Parse(tempPhones[i].PhoneSeller)] =
                                AllSellersProfit[int.Parse(tempPhones[i].PhoneSeller)] +
                                int.Parse(tempPhones[i].PhoneProfit);
                            tempSellersProfit[int.Parse(tempPhones[i].PhoneSeller)][
                                int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] =
                                tempSellersProfit[int.Parse(tempPhones[i].PhoneSeller)][
                                    int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] +
                                int.Parse(tempPhones[i].PhoneProfit);
                            //销售利润
                            tempMonthCommision[int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] =
                                tempMonthCommision[int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] +
                                int.Parse(tempPhones[i].PhoneCommision);
                            AllCommision = AllCommision + int.Parse(tempPhones[i].PhoneCommision);

                            AllSellersCommision[int.Parse(tempPhones[i].PhoneSeller)] =
                                AllSellersCommision[int.Parse(tempPhones[i].PhoneSeller)] +
                                int.Parse(tempPhones[i].PhoneCommision);
                            tempSellersCommision[int.Parse(tempPhones[i].PhoneSeller)][
                                int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] =
                                tempSellersCommision[int.Parse(tempPhones[i].PhoneSeller)][
                                    int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] +
                                int.Parse(tempPhones[i].PhoneCommision);
                            //提成
                            AllRealProfit = AllRealProfit +
                                            (int.Parse(tempPhones[i].PhoneProfit) -
                                             int.Parse(tempPhones[i].PhoneCommision));
                            tempRealProfit[int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] =
                                tempRealProfit[int.Parse(tempPhones[i].PhoneDate.Substring(4, 2)) - 1] +
                                (int.Parse(tempPhones[i].PhoneProfit) - int.Parse(tempPhones[i].PhoneCommision));
                        }

                        tempHTML = tempHTML + "<br><br><center><h4>手机销售</h4></center>";
                        for (int i = 0; i < 12; i++)
                        {
                            tempHTML = tempHTML + @"<br><center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                            tempHTML = tempHTML + "<tr>" +
                                       "<th>第" + (i + 1) + "月份合计</th>" +
                                       "</tr>";
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>总销售台数为:" + tempMonthPhones[i] + ", 总销售额为" + tempMonthPrice[i] +
                                       "元,总利润为" + tempMonthPrifit[i] + "元,总提成支出为" + tempMonthCommision[i] + "元,总实际利润为" +
                                       tempRealProfit[i] + "元.</td></tr>";
                            for (int j = 0; j < tempSeller.Length; j++)
                            {
                                if (tempSeller[j] == "" || tempSeller[j] == null) continue;
                                tempHTML = tempHTML + "<tr>";
                                tempHTML = tempHTML + "<td>" + tempSeller[j] + "总销售台数" + tempSellersPhones[j][i] +
                                           " 总创造利润:" + tempSellersProfit[j][i] + "元, 应支付提成为:" +
                                           tempSellersCommision[j][i] + "元</td>";
                                tempHTML = tempHTML + "</tr>";
                            }
                        }
                        tempHTML = tempHTML + "</table></center><br>";
                        tempHTML = tempHTML +
                                   "<p width = 850px align = center><font color = red>合计: 本年度总销售台数:" + AllSellPhones +
                                   "台 本年度总销售额为:" + AllPrice + "元 总利润为:" + AllProfit + "元<br>" +
                                   "本年度总需要支付提成为:" + AllCommision + "元, 合计总实际利润为:" + AllRealProfit +
                                   "元</font></p><br>";

                        for (int i = 0; i < tempSeller.Length; i++)
                        {
                            if (tempSeller[i] != "" && tempSeller[i] != null)
                            {
                                tempHTML = tempHTML + "<p width = 850px align = center><font color = blue>" +
                                           tempSeller[i] + "总销售台数" + AllSellersPhones[i] + " 总创造利润:" +
                                           AllSellersProfit[i] + "元, 应支付提成为:" + AllSellersCommision[i] + "元</font></p>";
                            }
                        }
                        tempHTML = tempHTML + "<hr><br><br>";

                        tempMonthPrice = new int[12];
                        tempMonthPrifit = new int[12];
                        tempMonthCommision = new int[12];
                        tempMonthPhones = new int[12];
                        tempSellersPhones = new int[tempSeller.Length][];
                        tempSellersProfit = new int[tempSeller.Length][];
                        tempSellersCommision = new int[tempSeller.Length][];
                        tempRealProfit = new int[12];
                        AllSellPhones = 0;
                        AllPrice = 0;
                        AllProfit = 0;
                        AllRealProfit = 0;

                        for (int i = 0; i < tempSellersPhones.Length; i++)
                        {
                            tempSellersPhones[i] = new int[12];
                            tempSellersProfit[i] = new int[12];
                            tempSellersCommision[i] = new int[12];
                        }

                        for (int i = 0; i < tempEquip.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempEquip[i].EquipDate)) continue;
                            AllSellPhones++;
                            AllSellersPhones[tempEquip[i].EquipSellers]++;
                            tempMonthPhones[int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1]++;
                            tempSellersPhones[tempEquip[i].EquipSellers][
                                int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1]++;
                            //台数
                            AllPrice = AllPrice + tempEquip[i].EquipPrice;
                            tempMonthPrice[int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] =
                                tempMonthPrice[int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] +
                                tempEquip[i].EquipPrice;
                            //销售价格
                            tempMonthPrifit[int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] =
                                tempMonthPrifit[int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] +
                                tempEquip[i].EquipProfit;
                            AllProfit = AllProfit + tempEquip[i].EquipProfit;
                            AllSellersProfit[tempEquip[i].EquipSellers] =
                                AllSellersProfit[tempEquip[i].EquipSellers] +
                                tempEquip[i].EquipProfit;
                            tempSellersProfit[tempEquip[i].EquipSellers][
                                int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] =
                                tempSellersProfit[tempEquip[i].EquipSellers][
                                    int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] +
                                tempEquip[i].EquipProfit;
                            //销售利润
                            tempMonthCommision[int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] =
                                tempMonthCommision[int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] +
                                tempEquip[i].EquipCommision;
                            AllCommision = AllCommision + tempEquip[i].EquipCommision;

                            AllSellersCommision[tempEquip[i].EquipSellers] =
                                AllSellersCommision[tempEquip[i].EquipSellers] +
                                tempEquip[i].EquipCommision;
                            tempSellersCommision[tempEquip[i].EquipSellers][
                                int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] =
                                tempSellersCommision[tempEquip[i].EquipSellers][
                                    int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] +
                                tempEquip[i].EquipCommision;
                            //提成
                            AllRealProfit = AllRealProfit +
                                            (tempEquip[i].EquipProfit -
                                             tempEquip[i].EquipCommision);
                            tempRealProfit[int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] =
                                tempRealProfit[int.Parse(tempEquip[i].EquipDate.Substring(4, 2)) - 1] +
                                (tempEquip[i].EquipProfit - tempEquip[i].EquipCommision);
                        }
                        tempHTML = tempHTML + "<br><br><center><h4>配件销售</h4></center>";
                        for (int i = 0; i < 12; i++)
                        {
                            tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                            tempHTML = tempHTML + "<tr>" +
                                       "<th>第" + (i + 1) + "月份合计</th>" +
                                       "</tr>";
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>总销售配件数为:" + tempMonthPhones[i] + ", 总销售额为" + tempMonthPrice[i] +
                                       "元,总利润为" + tempMonthPrifit[i] + "元,总提成支出为" + tempMonthCommision[i] + "元,总实际利润为" +
                                       tempRealProfit[i] + "元.</td></tr>";
                            for (int j = 0; j < tempSeller.Length; j++)
                            {
                                if (tempSeller[j] == "" || tempSeller[j] == null) continue;
                                tempHTML = tempHTML + "<tr>";
                                tempHTML = tempHTML + "<td>" + tempSeller[j] + "总销售件数" + tempSellersPhones[j][i] +
                                           " 总创造利润:" + tempSellersProfit[j][i] + "元, 应支付提成为:" +
                                           tempSellersCommision[j][i] + "元</td>";
                                tempHTML = tempHTML + "</tr>";
                            }
                        }
                        tempHTML = tempHTML + "</table></center><br>";
                        tempHTML = tempHTML +
                                   "<p width = 850px align = center><font color = red>合计: 本年度总销售配件:" + AllSellPhones +
                                   "件 本年度总销售额为:" + AllPrice + "元 总利润为:" + AllProfit + "元<br>" +
                                   "本年度总需要支付提成为:" + AllCommision + "元, 合计总实际利润为:" + AllRealProfit +
                                   "元</font></p><br>";

                        for (int i = 0; i < tempSeller.Length; i++)
                        {
                            if (tempSeller[i] != "" && tempSeller[i] != null)
                            {
                                tempHTML = tempHTML + "<p width = 850px align = center><font color = blue>" +
                                           tempSeller[i] + "总销售件数" + AllSellersPhones[i] + " 总创造利润:" +
                                           AllSellersProfit[i] + "元, 应支付提成为:" + AllSellersCommision[i] + "元</font></p>";
                            }
                        }
                        tempHTML = tempHTML + "<hr><br><br>";

                        //返收销售
                        tempMonthPrice = new int[12];
                        tempMonthPrifit = new int[12];
                        tempMonthCommision = new int[12];
                        tempMonthPhones = new int[12];
                        tempSellersPhones = new int[tempSeller.Length][];
                        tempSellersProfit = new int[tempSeller.Length][];
                        tempSellersCommision = new int[tempSeller.Length][];
                        tempRealProfit = new int[12];
                        AllSellPhones = 0;
                        AllPrice = 0;
                        AllProfit = 0;
                        AllRealProfit = 0;

                        for (int i = 0; i < tempSellersPhones.Length; i++)
                        {
                            tempSellersPhones[i] = new int[12];
                            tempSellersProfit[i] = new int[12];
                            tempSellersCommision[i] = new int[12];
                        }
                        int RefundPhoneSold = 0;
                        for (int i = 0; i < tempRefundPhone.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempRefundPhone[i].RefundDate)) continue;
                            AllSellPhones++;
                            if (!tempRefundPhone[i].RefundIsFix) continue;
                            RefundPhoneSold++;
                            AllSellersPhones[tempRefundPhone[i].RefundSeller]++;
                            tempMonthPhones[int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1]++;
                            tempSellersPhones[tempRefundPhone[i].RefundSeller][
                                int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1]++;
                            //台数
                            AllPrice = AllPrice + tempRefundPhone[i].RefundPrice;
                            tempMonthPrice[int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] =
                                tempMonthPrice[int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] +
                                tempEquip[i].EquipPrice;
                            //销售价格
                            tempMonthPrifit[int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] =
                                tempMonthPrifit[int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] +
                                tempRefundPhone[i].RefundFixProfit;
                            AllProfit = AllProfit + tempRefundPhone[i].RefundFixProfit;
                            AllSellersProfit[tempRefundPhone[i].RefundSeller] =
                                AllSellersProfit[tempRefundPhone[i].RefundSeller] +
                                tempRefundPhone[i].RefundFixProfit;
                            tempSellersProfit[tempRefundPhone[i].RefundSeller][
                                int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] =
                                tempSellersProfit[tempRefundPhone[i].RefundSeller][
                                    int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] +
                                tempRefundPhone[i].RefundFixProfit;
                            //销售利润
                            tempMonthCommision[int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] =
                                tempMonthCommision[int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] +
                                tempRefundPhone[i].RefundFixCommision;
                            AllCommision = AllCommision + tempRefundPhone[i].RefundFixCommision;

                            AllSellersCommision[tempRefundPhone[i].RefundSeller] =
                                AllSellersCommision[tempRefundPhone[i].RefundSeller] +
                                tempRefundPhone[i].RefundFixCommision;
                            tempSellersCommision[tempRefundPhone[i].RefundSeller][
                                int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] =
                                tempSellersCommision[tempRefundPhone[i].RefundSeller][
                                    int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] +
                                tempRefundPhone[i].RefundFixCommision;
                            //提成
                            AllRealProfit = AllRealProfit +
                                            (tempRefundPhone[i].RefundFixProfit -
                                             tempRefundPhone[i].RefundFixCommision);
                            tempRealProfit[int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] =
                                tempRealProfit[int.Parse(tempRefundPhone[i].RefundDate.Substring(4, 2)) - 1] +
                                (tempRefundPhone[i].RefundFixProfit - tempRefundPhone[i].RefundFixCommision);
                        }
                        tempHTML = tempHTML + "<br><br><center><h4>返收销售</h4></center>";
                        for (int i = 0; i < 12; i++)
                        {
                            tempHTML = tempHTML + @"<center><table border=""1""  id=""mytable"" cellspacing=""0"">";
                            tempHTML = tempHTML + "<tr>" +
                                       "<th>第" + (i + 1) + "月份合计</th>" +
                                       "</tr>";
                            tempHTML = tempHTML + "<tr>";
                            tempHTML = tempHTML + "<td>总销售返收数为:" + tempMonthPhones[i] + ", 总销售额为" + tempMonthPrice[i] +
                                       "元,总利润为" + tempMonthPrifit[i] + "元,总提成支出为" + tempMonthCommision[i] + "元,总实际利润为" +
                                       tempRealProfit[i] + "元.</td></tr>";
                            for (int j = 0; j < tempSeller.Length; j++)
                            {
                                if (tempSeller[j] == "" || tempSeller[j] == null) continue;
                                tempHTML = tempHTML + "<tr>";
                                tempHTML = tempHTML + "<td>" + tempSeller[j] + "总销售件数" + tempSellersPhones[j][i] +
                                           " 总创造利润:" + tempSellersProfit[j][i] + "元, 应支付提成为:" +
                                           tempSellersCommision[j][i] + "元</td>";
                                tempHTML = tempHTML + "</tr>";
                            }
                        }
                        tempHTML = tempHTML + "</table></center><br>";
                        tempHTML = tempHTML +
                                   "<p width = 850px align = center><font color = red>合计: 本年度总收取返收:" + AllSellPhones +
                                   "台 共销售了" + RefundPhoneSold + "台 本年度总销售额为:" + AllPrice + "元 总利润为:" + AllProfit +
                                   "元<br>" +
                                   "本年度总需要支付提成为:" + AllCommision + "元, 合计总实际利润为:" + AllRealProfit +
                                   "元</font></p><br>";

                        for (int i = 0; i < tempSeller.Length; i++)
                        {
                            if (tempSeller[i] != "" && tempSeller[i] != null)
                            {
                                tempHTML = tempHTML + "<p width = 850px align = center><font color = blue>" +
                                           tempSeller[i] + "总销售件数" + AllSellersPhones[i] + " 总创造利润:" +
                                           AllSellersProfit[i] + "元, 应支付提成为:" + AllSellersCommision[i] + "元</font></p>";
                            }
                        }
                        tempHTML = tempHTML + "<hr><br><br>";
                        //固定支出
                        //int AllPayout = 0;
                        for (int i = 0; i < tempPayout.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempPayout[i].PayoutPrice)) continue;
                            if (tempPayout[i].PayoutPrice.Substring(0, 1) != "-")
                            {
                                if (tempPayout[i].PayoutInCase)
                                {
                                    AllPayout = AllPayout + double.Parse(tempPayout[i].PayoutPrice);
                                }
                            }
                        }
                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" + "本年度固定支出为:" +
                                   AllPayout + "元</font></p></center><br><hr>";


                        //固定收入
                        //int AllPayin = 0;
                        for (int i = 0; i < tempPayout.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tempPayout[i].PayoutPrice)) continue;
                            if (tempPayout[i].PayoutPrice.Substring(0, 1) == "-")
                            {
                                if (tempPayout[i].PayoutInCase)
                                {
                                    AllPayin = AllPayin + double.Parse(tempPayout[i].PayoutPrice);
                                }
                            }
                        }
                        tempHTML = tempHTML + "<br><center><p width = 850px><font color = red>" + "本年度固定收入为:" + AllPayin +
                                   "元</font></p></center><br><hr>";

                        //请假
                        tempHTML = tempHTML + "<br><br><center><h4>请假</h4></center>";
                        tempHTML = tempHTML + @"<center><table border=""1"" id=""mytable"" cellspacing=""0"">";
                        tempHTML = tempHTML + "<tr>" +
                                   "<th>请假时间</th>" +
                                   "<th>请假人员</th>" +
                                   "<th>请假类型</th>" +
                                   "<th>请假时长</th>" +
                                   "<th>请假备注</th>" +
                                   "</tr>";
                        for (int i = 0; i < tempSeller.Length; i++)
                        {
                            if (tempSeller[i] != null && tempSeller[i] != "")
                            {
                                for (int j = 0; j < tempLeave[i].Length; j++)
                                {
                                    if (string.IsNullOrEmpty(tempLeave[i][j].AskDate)) continue;
                                    tempHTML = tempHTML + "<tr>";

                                    tempHTML = tempHTML + "<td>" + tempLeave[i][j].AskDate.Substring(0, 4) + "年" +
                                               tempLeave[i][j].AskDate.Substring(4, 2) + "月" +
                                               tempLeave[i][j].AskDate.Substring(6, 2) + "日" + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempSeller[tempLeave[i][j].AskSeller] + "</td>";
                                    switch (tempLeave[i][j].AskType)
                                    {
                                        case 0:
                                            tempHTML = tempHTML + "<td>事假</td>";
                                            break;
                                        case 1:
                                            tempHTML = tempHTML + "<td>病假</td>";
                                            break;
                                        case 2:
                                            tempHTML = tempHTML + "<td>丧假</td>";
                                            break;
                                        case 3:
                                            tempHTML = tempHTML + "<td>产假</td>";
                                            break;
                                    }
                                    tempHTML = tempHTML + "<td>" + tempLeave[i][j].AskDuration + "</td>";
                                    tempHTML = tempHTML + "<td>" + tempLeave[i][j].AskTip + "</td>";
                                    tempHTML = tempHTML + "</tr>";
                                }
                            }
                        }

                        tempHTML = tempHTML + "</table></center><br><hr>";

                        break;
                        */

                        #endregion
                }

                tempHTML = tempHTML + @"</body></html>";

                if (File.Exists(iPath))
                {
                    File.Delete(iPath);
                }

                var fs = new FileStream(iPath, FileMode.CreateNew);
                byte[] info = new UTF8Encoding(true).GetBytes(tempHTML);
                fs.Write(info, 0, info.Length);
                fs.Flush();
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        private delegate bool DelegateSaveData(int iType, IList<MysqlController.LXSellPhone> tempPhones,
                                               IList<MysqlController.AskForLeave[]> tempLeave,
                                               IList<MysqlController.Payout> tempPayout,
                                               IList<MysqlController.LXEquip> tempEquip,
                                               IList<MysqlController.RefundPhone> tempRefundPhone,
                                               IList<MysqlController.RefundPhone> tempRefundPhoneFix,
                                               IList<MysqlController.LXCustomDebt> tempCustomDebt,
                                               IList<MysqlController.LXMarketDebt> tempMarketDebt);

        #endregion

        #region 从数据库里抽取数据

        private static MysqlController.LXSellPhone[] GetPhones(string SetDate)
        {
            MysqlController.LXSellPhone[] tempPhones = MysqlControl.ReadPhoneSell(SetDate);
            return tempPhones;
        }

        private static MysqlController.AskForLeave[] GetAskForLeave(string SetDate, int SellerID)
        {
            var returnLeave = new MysqlController.AskForLeave[50000];
            MysqlController.AskForLeave[] tempLeave = MysqlControl.ReadAsk(SellerID.ToString());
            if (tempLeave != null)
            {
                for (int i = 0; i < tempLeave.Length; i++)
                {
                    if (string.IsNullOrEmpty(tempLeave[i].AskDate)) continue;
                    if (tempLeave[i].AskDate.IndexOf(SetDate) > -1)
                    {
                        returnLeave[i] = tempLeave[i];
                    }
                }
            }

            return returnLeave;
        }

        private static MysqlController.Payout[] GetPayout(string SetDate)
        {
            MysqlController.Payout[] tempPayout = MysqlControl.ReadPayout(SetDate);
            return tempPayout;
        }

        private static MysqlController.LXEquip[] GetEquipSold(string SetDate)
        {
            MysqlController.LXEquip[] tempEquip = MysqlControl.ReadSoldEquip(SetDate);

            return tempEquip;
        }

        private static MysqlController.RefundPhone[] GetBinPhonesByFixDate(string SetDate)
        {
            MysqlController.RefundPhone[] tempRefundPhone = MysqlControl.ReadRefundPhoneByFixDate(SetDate);

            return tempRefundPhone;
        }

        private static MysqlController.RefundPhone[] GetBinPhones(string SetDate)
        {
            MysqlController.RefundPhone[] tempRefundPhone = MysqlControl.ReadRefundPhone(SetDate);

            return tempRefundPhone;
        }

        private static MysqlController.LXCustomDebt[] GetCustomDebt(string SetDate)
        {
            MysqlController.LXCustomDebt[] tempCustomDebt = MysqlControl.ReadCustomDebt(SetDate);

            return tempCustomDebt;
        }

        private static MysqlController.LXMarketDebt[] GetMarketDebt(string SetDate)
        {
            MysqlController.LXMarketDebt[] tempMarketDebt = MysqlControl.ReadMarketDebt(SetDate);

            return tempMarketDebt;
        }

        private void frmReport_Shown(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            DelegateSellers dn = MysqlControl.Sellers;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempSeller = dn.EndInvoke(iar);
            ////
            DelegateSellersIndex dn1 = MysqlControl.SellersIndex;

            IAsyncResult iar1 = dn1.BeginInvoke(null, null);

            while (iar1.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempSellIndex = dn1.EndInvoke(iar1);
            //DelegateSellersIndex
            cmdSaveDaily.Enabled = true;
            cmdSaveMonth.Enabled = true;
            cmdSaveYear.Enabled = true;
            isBusy.Visible = false;

            cmdSaveDaily.Visible = true;
            cmdSaveMonth.Visible = true;
        }

        #region Nested type: DelegateSearchCustomDebt

        private delegate MysqlController.LXCustomDebt DelegateSearchCustomDebt(
            string reqdate, string customdebt, string DebtDetail);

        #endregion

        //OK

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion

        #region Nested type: DelegateSellersIndex

        private delegate string[] DelegateSellersIndex();

        #endregion

        #region Nested type: GetAskForLeaveDelegate

        private delegate MysqlController.AskForLeave[] GetAskForLeaveDelegate(string SetDate, int SellerID);

        #endregion

        //

        #region Nested type: GetBinPhonesByFixDateDelegate

        private delegate MysqlController.RefundPhone[] GetBinPhonesByFixDateDelegate(string SetDate);

        #endregion

        #region Nested type: GetBinPhonesDelegate

        private delegate MysqlController.RefundPhone[] GetBinPhonesDelegate(string SetDate);

        #endregion

        #region Nested type: GetCustomDebtDelegate

        private delegate MysqlController.LXCustomDebt[] GetCustomDebtDelegate(string SetDate);

        #endregion

        #region Nested type: GetEquipSoldDelegate

        private delegate MysqlController.LXEquip[] GetEquipSoldDelegate(string SetDate);

        #endregion

        #region Nested type: GetMarketDebtDelegate

        private delegate MysqlController.LXMarketDebt[] GetMarketDebtDelegate(string SetDate);

        #endregion

        #region Nested type: GetPayoutDelegate

        private delegate MysqlController.Payout[] GetPayoutDelegate(string SetDate);

        #endregion

        //private delegate MysqlController.LXPhones[] GetPhonesDelegate(string SetDate);

        #region Nested type: GetPhonesDelegate

        private delegate MysqlController.LXSellPhone[] GetPhonesDelegate(string SetDate);

        #endregion

        #endregion
    }
}