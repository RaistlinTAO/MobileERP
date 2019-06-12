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
    using System.Drawing;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using Dundas.Charting.WinControl;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmProfit : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        private readonly double[] tempCommision = new double[100];
        private readonly double[] tempPrice = new double[100];

        #region 窗体

        public frmProfit(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void frmProfit_Load(object sender, EventArgs e)
        {
            txtBProfit.Text = Resources.frmProfit_frmProfit_Load__0;
            txtProfit.Text = Resources.frmProfit_frmProfit_Load__0;
            txtTProfit.Text = Resources.frmProfit_frmProfit_Load__0;
            txtYProfit.Text = Resources.frmProfit_frmProfit_Load__0;

            txtCommision.Text = Resources.frmProfit_frmProfit_Load__0;
            txtBCommision.Text = Resources.frmProfit_frmProfit_Load__0;
            txtTCommision.Text = Resources.frmProfit_frmProfit_Load__0;
            txtYCommision.Text = Resources.frmProfit_frmProfit_Load__0;

            txtPayout.Text = Resources.frmProfit_frmProfit_Load__0;
            txtTPayout.Text = Resources.frmProfit_frmProfit_Load__0;
            txtYPayout.Text = Resources.frmProfit_frmProfit_Load__0;
        }

        private void cmdBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBProfit.Text = tempPrice[cmdBrand.SelectedIndex].ToString();
            txtBCommision.Text = tempCommision[cmdBrand.SelectedIndex].ToString();
        }

        #endregion

        private void frmProfit_Shown(object sender, EventArgs e)
        {
            isBusy.Visible = true;

            #region 数据准备

            double TPrice = 0;
            double YPrice = 0;
            double AllPrice = 0;

            for (int i = 0; i < tempPrice.Length; i++)
            {
                tempPrice[i] = 0;
            }
            cmdBrand.Items.Clear();

            DelegateManufacturer dn = MysqlControl.Manufacturer;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            string[] Tempstr = dn.EndInvoke(iar);

            if (Tempstr != null)
            {
                for (int i = 0; i < Tempstr.Length; i++)
                {
                    if (Tempstr[i] != null && Tempstr[i] != "")
                    {
                        cmdBrand.Items.Add(Tempstr[i]);
                    }
                }
            }
            else
            {
                MessageBox.Show(Resources.frmProfit_frmProfit_Load_下载厂商列表失败_, Application.ProductName,
                                MessageBoxButtons.OK);
            }

            #endregion

            #region 请求手机销售

            DelegateReadPhoneSell dnrp = MysqlControl.ReadPhoneSell;

            IAsyncResult iarrp = dnrp.BeginInvoke(DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0'),
                                                  null, null);

            while (iarrp.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.LXSellPhone[] tempPhones = dnrp.EndInvoke(iarrp);

            if (tempPhones != null)
            {
                for (int i = 0; i < tempPhones.Length; i++)
                {
                    if (tempPhones[i].PhoneIMEI == null) continue;
                    //先算今天,再算昨天,最后算总价格

                    if (tempPhones[i].PhoneDate.Substring(6, 2) ==
                        DateTime.Now.Day.ToString().PadLeft(2, '0'))
                    {
                        //if (tempPhones[i].PhonePayment == 0)
                        //{
                        TPrice = Math.Round(TPrice + tempPhones[i].PhonePrice, 2);
                        //}

                        txtTProfit.Text =
                            Math.Round(double.Parse(txtTProfit.Text) + tempPhones[i].PhoneProfit, 2).ToString();
                        txtTCommision.Text =
                            Math.Round(double.Parse(txtTCommision.Text) + tempPhones[i].PhoneCommision, 2).ToString();
                    }
                    if (tempPhones[i].PhoneDate.Substring(6, 2) ==
                        DateTime.Now.AddDays(-1).Day.ToString().PadLeft(2, '0'))
                    {
                        //if (tempPhones[i].PhonePayment == 0)
                        //{
                        YPrice = Math.Round(YPrice + tempPhones[i].PhonePrice, 2);
                        //}
                        txtYProfit.Text =
                            Math.Round(double.Parse(txtYProfit.Text) + tempPhones[i].PhoneProfit, 2).ToString();
                        txtYCommision.Text =
                            Math.Round(double.Parse(txtYCommision.Text) + tempPhones[i].PhoneCommision, 2).ToString();
                    }
                    //if (tempPhones[i].PhonePayment == 0)
                    //{
                    AllPrice = Math.Round(AllPrice + tempPhones[i].PhonePrice, 2);
                    //}

                    tempPrice[tempPhones[i].PhoneBrandid] =
                        Math.Round(tempPrice[tempPhones[i].PhoneBrandid] + tempPhones[i].PhoneProfit, 2);

                    tempCommision[tempPhones[i].PhoneBrandid] =
                        Math.Round(tempCommision[tempPhones[i].PhoneBrandid] + tempPhones[i].PhoneCommision, 2);

                    txtProfit.Text = Math.Round(double.Parse(txtProfit.Text) + tempPhones[i].PhoneProfit, 2).ToString();
                    txtCommision.Text =
                        Math.Round(double.Parse(txtCommision.Text) + tempPhones[i].PhoneCommision, 2).ToString();
                    Application.DoEvents();
                }
            }
            else
            {
                MessageBox.Show(Resources.frmProfit_frmProfit_Load_读取利润及提成错误_, Application.ProductName,
                                MessageBoxButtons.OK);
            }

            #endregion

            #region 请求配件销售

            DelegateReadSoldEquip dnse = MysqlControl.ReadSoldEquip;

            IAsyncResult iarse = dnse.BeginInvoke(DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0'),
                                                  null, null);

            while (iarse.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.LXEquip[] tempEquipSell = dnse.EndInvoke(iarse);

            if (tempEquipSell != null)
            {
                if (tempEquipSell.Length <= 0) return;
                for (int i = 0; i < tempEquipSell.Length; i++)
                {
                    if (string.IsNullOrEmpty(tempEquipSell[i].EquipDate)) continue;

                    if (tempEquipSell[i].EquipDate.Substring(6, 2) ==
                        DateTime.Now.Day.ToString().PadLeft(2, '0'))
                    {
                        //if (tempEquipSell[i].EquipPayment == 0)
                        //{
                        TPrice = Math.Round(TPrice + tempEquipSell[i].EquipPrice, 2);
                        //}

                        txtTEProfit.Text =
                            Math.Round(double.Parse(txtTEProfit.Text) + tempEquipSell[i].EquipProfit, 2).ToString();
                        txtTCommision.Text = Math.Round(double.Parse(txtTCommision.Text) +
                                                        tempEquipSell[i].EquipCommision, 2).ToString();
                    }
                    if (tempEquipSell[i].EquipDate.Substring(6, 2) ==
                        DateTime.Now.AddDays(-1).Day.ToString().PadLeft(2, '0'))
                    {
                        //if (tempEquipSell[i].EquipPayment == 0)
                        //{
                        YPrice = Math.Round(YPrice + tempEquipSell[i].EquipPrice, 2);
                        //}

                        txtYEProfit.Text =
                            Math.Round(double.Parse(txtYEProfit.Text) + tempEquipSell[i].EquipProfit, 2).ToString();
                        txtYCommision.Text =
                            Math.Round(double.Parse(txtYCommision.Text) + tempEquipSell[i].EquipCommision, 2).ToString();
                    }
                    //if (tempEquipSell[i].EquipPayment == 0)
                    //{
                    AllPrice = Math.Round(AllPrice + tempEquipSell[i].EquipPrice, 2);
                    //}

                    txtEProfit.Text =
                        Math.Round(double.Parse(txtEProfit.Text) + tempEquipSell[i].EquipProfit, 2).ToString();
                    txtCommision.Text =
                        Math.Round(double.Parse(txtCommision.Text) + tempEquipSell[i].EquipCommision, 2).ToString();
                    Application.DoEvents();
                }
            }
            else
            {
                MessageBox.Show(Resources.frmProfit_frmProfit_Load_读取利润及提成错误_, Application.ProductName,
                                MessageBoxButtons.OK);
            }

            #endregion

            #region 请求返收销售

            DelegateReadRefundPhone dnrrp = MysqlControl.ReadRefundPhone;

            IAsyncResult iarrrp = dnrrp.BeginInvoke(DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0'),
                                                    null, null);

            while (iarrrp.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.RefundPhone[] tempBinPhone = dnrrp.EndInvoke(iarrrp);

            if (tempBinPhone != null)
            {
                if (tempBinPhone.Length > 0)
                {
                    for (int i = 0; i < tempBinPhone.Length; i++)
                    {
                        if (string.IsNullOrEmpty(tempBinPhone[i].RefundDate)) continue;
                        //这里求卖出的机器,注意 现金流的操作只限制于卖价 收取费用在下面结算
                        if (tempBinPhone[i].RefundIsFix)
                        {
                            if (tempBinPhone[i].RefundFixDate.Substring(6, 2) ==
                                DateTime.Now.Day.ToString().PadLeft(2, '0'))
                            {
                                //if (tempBinPhone[i].RefundFixType == 0)
                                //{
                                TPrice = Math.Round(TPrice + tempBinPhone[i].RefundFixPrice, 2);
                                //}

                                txtTBPProfit.Text =
                                    Math.Round(double.Parse(txtTBPProfit.Text) + tempBinPhone[i].RefundFixProfit, 2).
                                        ToString();
                                txtTCommision.Text = Math.Round(double.Parse(txtTCommision.Text) +
                                                                tempBinPhone[i].RefundFixCommision, 2).ToString();
                            }
                            if (tempBinPhone[i].RefundFixDate.Substring(6, 2) ==
                                DateTime.Now.AddDays(-1).Day.ToString().PadLeft(2, '0'))
                            {
                                //if (tempBinPhone[i].RefundFixType == 0)
                                //{
                                YPrice = Math.Round(YPrice + tempBinPhone[i].RefundFixPrice, 2);
                                //}

                                txtYBPProfit.Text =
                                    Math.Round(double.Parse(txtYEProfit.Text) + tempBinPhone[i].RefundFixProfit, 2).
                                        ToString();
                                txtYCommision.Text =
                                    Math.Round(double.Parse(txtYCommision.Text) + tempBinPhone[i].RefundFixCommision, 2)
                                        .ToString();
                            }
                            //if (tempBinPhone[i].RefundFixType == 0)
                            //{
                            AllPrice = Math.Round(AllPrice + tempBinPhone[i].RefundFixPrice, 2);
                            //}

                            txtBPProfit.Text =
                                Math.Round(double.Parse(txtBPProfit.Text) + tempBinPhone[i].RefundFixProfit, 2).ToString
                                    ();
                            txtCommision.Text =
                                Math.Round(double.Parse(txtCommision.Text) + tempBinPhone[i].RefundFixCommision, 2).
                                    ToString();
                        }
                        //没有卖出和卖出的共同进行成本核算
                        if (tempBinPhone[i].RefundDate.Substring(6, 2) ==
                            DateTime.Now.Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempBinPhone[i].RefundRefundType == 0)
                            {
                                TPrice = Math.Round(TPrice - tempBinPhone[i].RefundPrice, 2);
                                TPrice = Math.Round(TPrice - tempBinPhone[i].RefundRepairPrice, 2);
                            }
                        }

                        if (tempBinPhone[i].RefundDate.Substring(6, 2) ==
                            DateTime.Now.AddDays(-1).Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempBinPhone[i].RefundRefundType == 0)
                            {
                                YPrice = Math.Round(YPrice - tempBinPhone[i].RefundPrice, 2);
                                YPrice = Math.Round(YPrice - tempBinPhone[i].RefundRepairPrice, 2);
                            }
                        }
                        AllPrice = Math.Round(AllPrice - tempBinPhone[i].RefundPrice, 2);
                        AllPrice = Math.Round(AllPrice - tempBinPhone[i].RefundRepairPrice, 2);
                        Application.DoEvents();
                    }
                }
            }
            else
            {
                MessageBox.Show(Resources.frmProfit_frmProfit_Load_读取利润及提成错误_, Application.ProductName,
                                MessageBoxButtons.OK);
            }

            /////////////////////////////////////////////////////////////////////////////////////////

            GetBinPhonesByFixDateDelegate dngbpf = MysqlControl.ReadRefundPhoneByFixDate;

            IAsyncResult iargbpf = dngbpf.BeginInvoke(DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0'),
                                                      null, null);

            while (iargbpf.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.RefundPhone[] tempBinPhoneByFix = dngbpf.EndInvoke(iargbpf);

            if (tempBinPhoneByFix != null)
            {
                if (tempBinPhoneByFix.Length > 0)
                {
                    for (int i = 0; i < tempBinPhoneByFix.Length; i++)
                    {
                        if (string.IsNullOrEmpty(tempBinPhoneByFix[i].RefundDate)) continue;
                        //这里求卖出的机器,注意 现金流的操作只限制于卖价 收取费用在下面结算
                        if (tempBinPhoneByFix[i].RefundIsFix)
                        {
                            if (tempBinPhoneByFix[i].RefundFixDate.Substring(6, 2) ==
                                DateTime.Now.Day.ToString().PadLeft(2, '0'))
                            {
                                //if (tempBinPhone[i].RefundFixType == 0)
                                //{
                                TPrice = Math.Round(TPrice + tempBinPhoneByFix[i].RefundFixPrice, 2);
                                //}

                                txtTBPProfit.Text =
                                    Math.Round(double.Parse(txtTBPProfit.Text) + tempBinPhoneByFix[i].RefundFixProfit, 2)
                                        .
                                        ToString();
                                txtTCommision.Text = Math.Round(double.Parse(txtTCommision.Text) +
                                                                tempBinPhoneByFix[i].RefundFixCommision, 2).ToString();
                            }
                            if (tempBinPhoneByFix[i].RefundFixDate.Substring(6, 2) ==
                                DateTime.Now.AddDays(-1).Day.ToString().PadLeft(2, '0'))
                            {
                                //if (tempBinPhone[i].RefundFixType == 0)
                                //{
                                YPrice = Math.Round(YPrice + tempBinPhoneByFix[i].RefundFixPrice, 2);
                                //}

                                txtYBPProfit.Text =
                                    Math.Round(double.Parse(txtYEProfit.Text) + tempBinPhoneByFix[i].RefundFixProfit, 2)
                                        .
                                        ToString();
                                txtYCommision.Text =
                                    Math.Round(
                                        double.Parse(txtYCommision.Text) + tempBinPhoneByFix[i].RefundFixCommision, 2)
                                        .ToString();
                            }
                            //if (tempBinPhone[i].RefundFixType == 0)
                            //{
                            AllPrice = Math.Round(AllPrice + tempBinPhoneByFix[i].RefundFixPrice, 2);
                            //}

                            txtBPProfit.Text =
                                Math.Round(double.Parse(txtBPProfit.Text) + tempBinPhoneByFix[i].RefundFixProfit, 2).
                                    ToString
                                    ();
                            txtCommision.Text =
                                Math.Round(double.Parse(txtCommision.Text) + tempBinPhoneByFix[i].RefundFixCommision, 2)
                                    .
                                    ToString();
                        }
                        //没有卖出和卖出的共同进行成本核算
                        if (tempBinPhoneByFix[i].RefundDate.Substring(6, 2) ==
                            DateTime.Now.Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempBinPhoneByFix[i].RefundRefundType == 0)
                            {
                                TPrice = Math.Round(TPrice - tempBinPhoneByFix[i].RefundPrice, 2);
                                TPrice = Math.Round(TPrice - tempBinPhoneByFix[i].RefundRepairPrice, 2);
                            }
                        }

                        if (tempBinPhoneByFix[i].RefundDate.Substring(6, 2) ==
                            DateTime.Now.AddDays(-1).Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempBinPhoneByFix[i].RefundRefundType == 0)
                            {
                                YPrice = Math.Round(YPrice - tempBinPhoneByFix[i].RefundPrice, 2);
                                YPrice = Math.Round(YPrice - tempBinPhoneByFix[i].RefundRepairPrice, 2);
                            }
                        }
                        AllPrice = Math.Round(AllPrice - tempBinPhoneByFix[i].RefundPrice, 2);
                        AllPrice = Math.Round(AllPrice - tempBinPhoneByFix[i].RefundRepairPrice, 2);
                        Application.DoEvents();
                    }
                }
            }
            else
            {
                MessageBox.Show(Resources.frmProfit_frmProfit_Load_读取利润及提成错误_, Application.ProductName,
                                MessageBoxButtons.OK);
            }

            #endregion

            #region 请求客户欠款

            DelegateReadCustomDebt dncd = MysqlControl.ReadCustomDebt;

            IAsyncResult iarcd = dncd.BeginInvoke(DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0'),
                                                  null, null);

            while (iarcd.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.LXCustomDebt[] tempCustomDebt = dncd.EndInvoke(iarcd);

            if (tempCustomDebt != null)
            {
                if (tempCustomDebt.Length <= 0) return;
                for (int i = 0; i < tempCustomDebt.Length; i++)
                {
                    if (string.IsNullOrEmpty(tempCustomDebt[i].DebtDate)) continue;
                    if (tempCustomDebt[i].DebtisFix) //已经结款
                    {
                        //根据结款时间 得出费用
                        if (tempCustomDebt[i].DebtFixDate.Substring(6, 2) ==
                            DateTime.Now.Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempCustomDebt[i].DebtFixType == 1) //类型1为现金
                            {
                                if (tempCustomDebt[i].DebtisInCircle)
                                {
                                    TPrice = Math.Round(TPrice + tempCustomDebt[i].DebtPrice, 2);
                                }
                            }
                            txtTCustomDebt.Text =
                                Math.Round(double.Parse(txtTCustomDebt.Text) + tempCustomDebt[i].DebtPrice, 2).ToString();
                        }
                        if (tempCustomDebt[i].DebtFixDate.Substring(6, 2) ==
                            DateTime.Now.AddDays(-1).Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempCustomDebt[i].DebtFixType == 1)
                            {
                                if (tempCustomDebt[i].DebtisInCircle)
                                {
                                    YPrice = Math.Round(YPrice + tempCustomDebt[i].DebtPrice, 2);
                                }
                            }

                            txtYCustomDebt.Text =
                                Math.Round(double.Parse(txtYCustomDebt.Text) + tempCustomDebt[i].DebtPrice, 2).ToString();
                        }
                        if (tempCustomDebt[i].DebtFixType == 1)
                        {
                            if (tempCustomDebt[i].DebtisInCircle)
                            {
                                AllPrice = Math.Round(AllPrice + tempCustomDebt[i].DebtPrice, 2);
                            }
                        }
                        txtBPProfit.Text =
                            Math.Round(double.Parse(txtCustomDebt.Text) + tempCustomDebt[i].DebtPrice, 2).ToString();
                    }
                    else //未结帐 
                    {
                        //根据欠款时间决定
                        if (tempCustomDebt[i].DebtDate.Substring(6, 2) ==
                            DateTime.Now.Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempCustomDebt[i].DebtisInCircle)
                            {
                                TPrice = Math.Round(TPrice - tempCustomDebt[i].DebtUnFixPrice, 2);
                            }
                        }
                        if (tempCustomDebt[i].DebtDate.Substring(6, 2) ==
                            DateTime.Now.AddDays(-1).Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempCustomDebt[i].DebtisInCircle)
                            {
                                YPrice = Math.Round(YPrice - tempCustomDebt[i].DebtUnFixPrice, 2);
                            }
                        }
                        if (tempCustomDebt[i].DebtisInCircle)
                        {
                            AllPrice = Math.Round(AllPrice - tempCustomDebt[i].DebtUnFixPrice, 2);
                        }
                    }
                    Application.DoEvents();
                }
            }
            else
            {
                MessageBox.Show(Resources.frmProfit_frmProfit_Load_读取利润及提成错误_, Application.ProductName,
                                MessageBoxButtons.OK);
            }

            #endregion

            #region 请求市场欠款

            DelegateReadMarketDebt dnmd = MysqlControl.ReadMarketDebt;

            IAsyncResult iarmd = dnmd.BeginInvoke(DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0'),
                                                  null, null);

            while (iarmd.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.LXMarketDebt[] tempMarketDebt = dnmd.EndInvoke(iarmd);

            if (tempMarketDebt != null)
            {
                if (tempMarketDebt.Length <= 0) return;
                for (int i = 0; i < tempMarketDebt.Length; i++)
                {
                    if (string.IsNullOrEmpty(tempMarketDebt[i].DebtDate)) continue;
                    if (tempMarketDebt[i].DebtisFix)
                    {
                        if (tempMarketDebt[i].DebtFixDate.Substring(6, 2) ==
                            DateTime.Now.Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempMarketDebt[i].DebtisCashCircle)
                            {
                                TPrice = Math.Round(TPrice - tempMarketDebt[i].DebtPrice, 2);
                            }
                            txtTMarketDebt.Text =
                                Math.Round(double.Parse(txtTMarketDebt.Text) + tempMarketDebt[i].DebtPrice, 2).ToString();
                        }
                        if (tempMarketDebt[i].DebtFixDate.Substring(6, 2) ==
                            DateTime.Now.AddDays(-1).Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempMarketDebt[i].DebtisCashCircle)
                            {
                                YPrice = Math.Round(YPrice - tempMarketDebt[i].DebtPrice, 2);
                            }

                            txtYMarketDebt.Text =
                                Math.Round(double.Parse(txtYMarketDebt.Text) + tempMarketDebt[i].DebtPrice, 2).ToString();
                        }
                        if (tempMarketDebt[i].DebtisCashCircle)
                        {
                            AllPrice = Math.Round(AllPrice - tempMarketDebt[i].DebtPrice, 2);
                        }

                        txtMarketDebt.Text =
                            Math.Round(double.Parse(txtMarketDebt.Text) + tempMarketDebt[i].DebtPrice, 2).ToString();
                    }
                    else //清算未结帐的 那么这意味着钱是多出来的
                    {
                        if (tempMarketDebt[i].DebtDate.Substring(6, 2) ==
                            DateTime.Now.Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempMarketDebt[i].DebtisCashCircle)
                            {
                                TPrice = Math.Round(TPrice + tempMarketDebt[i].DebtPrice, 2);
                            }
                        }
                        if (tempMarketDebt[i].DebtDate.Substring(6, 2) ==
                            DateTime.Now.AddDays(-1).Day.ToString().PadLeft(2, '0'))
                        {
                            if (tempMarketDebt[i].DebtisCashCircle)
                            {
                                YPrice = Math.Round(YPrice + tempMarketDebt[i].DebtPrice, 2);
                            }
                        }
                        if (tempMarketDebt[i].DebtisCashCircle)
                        {
                            AllPrice = Math.Round(AllPrice + tempMarketDebt[i].DebtPrice, 2);
                        }
                    }
                    Application.DoEvents();
                }
            }
            else
            {
                MessageBox.Show(Resources.frmProfit_frmProfit_Load_读取利润及提成错误_, Application.ProductName,
                                MessageBoxButtons.OK);
            }

            #endregion

            #region 请求固定支出

            DelegateReadPayout dnpayout1 = MysqlControl.ReadPayout;
            IAsyncResult iarpayout1 =
                dnpayout1.BeginInvoke(DateTime.Today.Year + DateTime.Today.Month.ToString().PadLeft(2, '0') +
                                      DateTime.Today.Day.ToString().PadLeft(2, '0'), null, null);
            while (iarpayout1.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.Payout[] tempTPayout = dnpayout1.EndInvoke(iarpayout1);

            DelegateReadPayout dnpayout2 = MysqlControl.ReadPayout;
            IAsyncResult iarpayout2 =
                dnpayout2.BeginInvoke(DateTime.Today.Year + DateTime.Today.Month.ToString().PadLeft(2, '0') +
                                      DateTime.Today.AddDays(-1).Day.ToString().PadLeft(2, '0'), null, null);
            while (iarpayout2.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.Payout[] tempYPayout = dnpayout2.EndInvoke(iarpayout2);

            DelegateReadPayout dnpayout3 = MysqlControl.ReadPayout;
            IAsyncResult iarpayout3 =
                dnpayout3.BeginInvoke(DateTime.Today.Year + DateTime.Today.Month.ToString().PadLeft(2, '0'), null, null);
            while (iarpayout3.IsCompleted == false)
            {
                Application.DoEvents();
            }
            MysqlController.Payout[] tempPayout = dnpayout3.EndInvoke(iarpayout3);

            if (tempTPayout != null && tempYPayout != null && tempPayout != null)
            {
                for (int i = 0; i < tempTPayout.Length; i++)
                {
                    if (tempTPayout[i].PayoutPrice != null)
                    {
                        if (tempTPayout[i].PayoutInCase)
                        {
                            txtTPayout.Text =
                                Math.Round(double.Parse(txtTPayout.Text) + double.Parse(tempTPayout[i].PayoutPrice), 2).
                                    ToString();
                        }
                    }
                    Application.DoEvents();
                }

                for (int i = 0; i < tempYPayout.Length; i++)
                {
                    if (tempYPayout[i].PayoutPrice != null)
                    {
                        if (tempYPayout[i].PayoutInCase)
                        {
                            txtYPayout.Text =
                                Math.Round(double.Parse(txtYPayout.Text) + double.Parse(tempYPayout[i].PayoutPrice), 2).
                                    ToString();
                        }
                    }
                    Application.DoEvents();
                }

                for (int i = 0; i < tempPayout.Length; i++)
                {
                    if (tempPayout[i].PayoutPrice != null)
                    {
                        if (tempPayout[i].PayoutInCase)
                        {
                            txtPayout.Text =
                                Math.Round(double.Parse(txtPayout.Text) + double.Parse(tempPayout[i].PayoutPrice), 2).
                                    ToString();
                        }
                    }
                    Application.DoEvents();
                }
            }
            else
            {
                MessageBox.Show(Resources.frmProfit_frmProfit_Load_读取固定支出错误_, Application.ProductName,
                                MessageBoxButtons.OK);
            }

            #endregion

            #region 计算真实利润

            txtTTrueProfit.Text =
                Math.Round(double.Parse(txtTProfit.Text) + double.Parse(txtTEProfit.Text), 2).ToString();

            txtTTrueProfit.Text =
                Math.Round(double.Parse(txtTTrueProfit.Text) + double.Parse(txtTBPProfit.Text), 2).ToString();

            txtTTrueProfit.Text =
                Math.Round(double.Parse(txtTTrueProfit.Text) - double.Parse(txtTCommision.Text), 2).ToString();

            txtTTrueProfit.Text =
                Math.Round(double.Parse(txtTTrueProfit.Text) - double.Parse(txtTPayout.Text), 2).ToString();
            //
            txtYTrueProfit.Text =
                Math.Round(double.Parse(txtYProfit.Text) + double.Parse(txtYEProfit.Text), 2).ToString();

            txtYTrueProfit.Text =
                Math.Round(double.Parse(txtYTrueProfit.Text) + double.Parse(txtYBPProfit.Text), 2).ToString();

            txtYTrueProfit.Text =
                Math.Round(double.Parse(txtYTrueProfit.Text) - double.Parse(txtYCommision.Text), 2).ToString();

            txtYTrueProfit.Text =
                Math.Round(double.Parse(txtYTrueProfit.Text) - double.Parse(txtYPayout.Text), 2).ToString();
            /////////////////
            txtTrueProfit.Text =
                Math.Round(double.Parse(txtProfit.Text) + double.Parse(txtEProfit.Text), 2).ToString();

            txtTrueProfit.Text =
                Math.Round(double.Parse(txtTrueProfit.Text) + double.Parse(txtBPProfit.Text), 2).ToString();

            txtTrueProfit.Text =
                Math.Round(double.Parse(txtTrueProfit.Text) - double.Parse(txtCommision.Text), 2).ToString();

            txtTrueProfit.Text =
                Math.Round(double.Parse(txtTrueProfit.Text) - double.Parse(txtPayout.Text), 2).ToString();

            #endregion

            #region 计算店铺剩余金额

            txtTShopValue.Text =
                Math.Round(TPrice - double.Parse(txtTPayout.Text), 2).
                    ToString();

            ////

            txtYShopValue.Text =
                Math.Round(YPrice - double.Parse(txtYPayout.Text), 2).
                    ToString();

            ////

            txtShopValue.Text =
                Math.Round(AllPrice - double.Parse(txtPayout.Text), 2)
                    .ToString
                    ();

            #endregion

            #region 填充数据到图表

            chartBrand.Series.Clear();
            chartBrand.ChartAreas.Clear();
            var chartArea1 = new ChartArea {Area3DStyle = {Enable3D = true, Light = LightStyle.Realistic}};
            chartArea1.AxisX.LabelStyle.FontColor = Color.FromArgb(((((220)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisX.LineColor = Color.FromArgb(((((220)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisX.MajorGrid.LineColor = Color.FromArgb(((((40)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisX.MajorGrid.LineWidth = 2;
            chartArea1.AxisX.MajorTickMark.LineColor = Color.FromArgb(((((100)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisX.MinorGrid.LineColor = Color.FromArgb(((((70)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisX.MinorTickMark.LineColor = Color.FromArgb(((((100)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisX.MinorTickMark.Size = 2F;
            chartArea1.AxisX2.LabelStyle.FontColor = Color.White;
            chartArea1.AxisX2.LineColor = Color.White;
            chartArea1.AxisX2.MajorGrid.LineColor = Color.FromArgb(((((150)))), ((((255)))), ((((255)))),
                                                                   ((((255)))));
            chartArea1.AxisX2.MajorTickMark.LineColor = Color.White;
            chartArea1.AxisX2.MinorGrid.LineColor = Color.FromArgb(((((100)))), ((((255)))), ((((255)))),
                                                                   ((((255)))));
            chartArea1.AxisX2.MinorTickMark.LineColor = Color.White;
            chartArea1.AxisY.LabelStyle.FontColor = Color.FromArgb(((((220)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisY.LineColor = Color.FromArgb(((((220)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisY.MajorGrid.LineColor = Color.FromArgb(((((40)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisY.MajorGrid.LineWidth = 2;
            chartArea1.AxisY.MajorTickMark.LineColor = Color.FromArgb(((((100)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisY.MinorGrid.LineColor = Color.FromArgb(((((70)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisY.MinorTickMark.LineColor = Color.FromArgb(((((100)))), ((((0)))), ((((0)))), ((((0)))));
            chartArea1.AxisY.MinorTickMark.Size = 2F;
            chartArea1.AxisY2.LabelStyle.FontColor = Color.White;
            chartArea1.AxisY2.LineColor = Color.White;
            chartArea1.AxisY2.MajorGrid.LineColor = Color.FromArgb(((((150)))), ((((255)))), ((((255)))),
                                                                   ((((255)))));
            chartArea1.AxisY2.MajorTickMark.LineColor = Color.White;
            chartArea1.AxisY2.MinorGrid.LineColor = Color.FromArgb(((((100)))), ((((255)))), ((((255)))),
                                                                   ((((255)))));
            chartArea1.AxisY2.MinorTickMark.LineColor = Color.White;
            chartArea1.BackColor = Color.White;
            chartArea1.BackGradientEndColor = Color.AntiqueWhite;
            chartArea1.BackGradientType = GradientType.TopBottom;
            chartArea1.BorderColor = Color.FromArgb(((((50)))), ((((255)))), ((((255)))), ((((255)))));
            chartArea1.BorderStyle = ChartDashStyle.Solid;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "Default";
            chartBrand.ChartAreas.Add(chartArea1);

            var SeriesBrand = new Series {ChartType = "Pie", ShowLabelAsValue = true, SmartLabels = {Enabled = true}};

            for (int i = 0; i < cmdBrand.Items.Count; i++)
            {
                SeriesBrand.Points.AddXY(cmdBrand.Items[i].ToString(), tempPrice[i]);
                Application.DoEvents();
            }
            chartBrand.Series.Add(SeriesBrand);

            chartMoney.Series[0].Points.Add(int.Parse(txtProfit.Text));
            chartMoney.Series[0].Points.Add(int.Parse(txtProfit.Text));
            chartMoney.Series[0].Points.Add(int.Parse(txtProfit.Text));

            chartMoney.Series[1].Points.Add(double.Parse(txtTProfit.Text));
            chartMoney.Series[1].Points.Add(double.Parse(txtTProfit.Text));
            chartMoney.Series[1].Points.Add(double.Parse(txtTProfit.Text));
            chartMoney.Series[2].Points.Add(double.Parse(txtPayout.Text));
            chartMoney.Series[2].Points.Add(double.Parse(txtPayout.Text));
            chartMoney.Series[2].Points.Add(double.Parse(txtPayout.Text));
            chartMoney.Series[3].Points.Add(int.Parse(txtCommision.Text));
            chartMoney.Series[3].Points.Add(int.Parse(txtCommision.Text));
            chartMoney.Series[3].Points.Add(int.Parse(txtCommision.Text));
            chartMoney.Series[4].Points.Add(double.Parse(txtTrueProfit.Text));
            chartMoney.Series[4].Points.Add(double.Parse(txtTrueProfit.Text));
            chartMoney.Series[4].Points.Add(double.Parse(txtTrueProfit.Text));

            #endregion

            isBusy.Visible = false;
        }

        #region Nested type: DelegateManufacturer

        private delegate string[] DelegateManufacturer();

        #endregion

        #region Nested type: DelegateReadCustomDebt

        private delegate MysqlController.LXCustomDebt[] DelegateReadCustomDebt(string reqDate);

        #endregion

        #region Nested type: DelegateReadMarketDebt

        private delegate MysqlController.LXMarketDebt[] DelegateReadMarketDebt(string reqDate);

        #endregion

        #region Nested type: DelegateReadPayout

        private delegate MysqlController.Payout[] DelegateReadPayout(string reqDate);

        #endregion

        #region Nested type: DelegateReadPhoneSell

        private delegate MysqlController.LXSellPhone[] DelegateReadPhoneSell(string Smonth);

        #endregion

        #region Nested type: DelegateReadRefundPhone

        private delegate MysqlController.RefundPhone[] DelegateReadRefundPhone(string reqDate);

        #endregion

        #region Nested type: DelegateReadSoldEquip

        private delegate MysqlController.LXEquip[] DelegateReadSoldEquip(string reqDate);

        #endregion

        #region Nested type: GetBinPhonesByFixDateDelegate

        private delegate MysqlController.RefundPhone[] GetBinPhonesByFixDateDelegate(string SetDate);

        #endregion
    }
}