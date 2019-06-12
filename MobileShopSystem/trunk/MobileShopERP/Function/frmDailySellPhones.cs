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
namespace MobileShopERP.Function
{
    #region

    using System;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmDailySellPhones : Form
    {
        private readonly string[] ArrBrand = new string[100];
        private readonly string[] ArrSeller = new string[100];
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string iLoginUser;
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();

        public frmDailySellPhones(ToolStripStatusLabel iBusy, string LoginUser)
        {
            iLoginUser = LoginUser;
            isBusy = iBusy;
            InitializeComponent();
        }

        private void cmdViewDaily_Click(object sender, EventArgs e)
        {
            cmdViewDaily.Enabled = false;
            RefreshCustom(dtpDaily.Value.Year + dtpDaily.Value.Month.ToString().PadLeft(2, '0') +
                          dtpDaily.Value.Day.ToString().PadLeft(2, '0'));
            cmdViewDaily.Enabled = true;
        }

        private void cmdViewMonth_Click(object sender, EventArgs e)
        {
            cmdViewMonth.Enabled = false;
            RefreshCustom(dtpDaily.Value.Year + dtpDaily.Value.Month.ToString().PadLeft(2, '0'));
            cmdViewMonth.Enabled = true;
        }

        private void RefreshCustom(string DataString)
        {
            isBusy.Visible = true;
            DelegateReadPhoneSell dn = MysqlControl.ReadPhoneSell;

            IAsyncResult iar = dn.BeginInvoke(DataString, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.LXSellPhone[] tempPhones = dn.EndInvoke(iar);

            lsvPhones.Items.Clear();
            if (tempPhones == null) return;
            if (tempPhones.Length <= 0) return;
            for (int i = 0; i < tempPhones.Length; i++)
            {
                if (string.IsNullOrEmpty(tempPhones[i].Phoneid)) continue;
                lsvPhones.Items.Add(tempPhones[i].Phoneid);
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneDate);
                lsvPhones.Items[i].SubItems.Add(ArrBrand[tempPhones[i].PhoneBrandid]); //
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneName);
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneIMEI);
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhonePrice.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneSeller); //
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneRealprice.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneSupplier);
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneScreenGuard.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneBattery.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneSDCARD.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneShell.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneCarCradle.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneCarCharger.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneHeadPhone.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneOther.ToString());

                if (tempPhones[i].PhoneWarranty)
                {
                    lsvPhones.Items[i].SubItems.Add("有");
                    lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneWarrantyPrice.ToString());
                    /*
                     软件保修
软硬全保
延长保修
无敌保修*/
                    switch (tempPhones[i].PhoneWarrantyType)
                    {
                        case 0:
                            lsvPhones.Items[i].SubItems.Add("软件保修");
                            break;
                        case 1:
                            lsvPhones.Items[i].SubItems.Add("软硬全保");
                            break;
                        case 2:
                            lsvPhones.Items[i].SubItems.Add("延长保修");
                            break;
                        case 3:
                            lsvPhones.Items[i].SubItems.Add("无敌保修");
                            break;
                    }
                    lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneWarrantyDate);
                    /*
                     一年

三年
终身*/
                    switch (tempPhones[i].PhoneWarrantyDuration)
                    {
                        case 0:
                            lsvPhones.Items[i].SubItems.Add("一年");
                            break;
                        case 1:
                            lsvPhones.Items[i].SubItems.Add("两年");
                            break;
                        case 2:
                            lsvPhones.Items[i].SubItems.Add("三年");
                            break;
                        case 3:
                            lsvPhones.Items[i].SubItems.Add("终身");
                            break;
                    }
                }
                else
                {
                    lsvPhones.Items[i].SubItems.Add("无");
                    lsvPhones.Items[i].SubItems.Add("N/A");
                    lsvPhones.Items[i].SubItems.Add("N/A");
                    lsvPhones.Items[i].SubItems.Add("N/A");
                    lsvPhones.Items[i].SubItems.Add("N/A");
                }

                if (tempPhones[i].PhoneisLegal)
                {
                    lsvPhones.Items[i].SubItems.Add("行货");
                }
                if (tempPhones[i].PhoneisHKLegal)
                {
                    lsvPhones.Items[i].SubItems.Add("港行");
                }
                if (tempPhones[i].PhoneisUnLegal)
                {
                    lsvPhones.Items[i].SubItems.Add("水货");
                }
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneUserName);
                /*
                 普通客户
优质客户
劣质客户
                 */
                switch (tempPhones[i].PhoneUserType)
                {
                    case 0:
                        lsvPhones.Items[i].SubItems.Add("普通客户");
                        break;
                    case 1:
                        lsvPhones.Items[i].SubItems.Add("优质客户");
                        break;
                    case 2:
                        lsvPhones.Items[i].SubItems.Add("劣质客户");
                        break;
                }
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneUseremail);
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneUsercellPhone);
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneUsercellPhoneback);
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneUserTelePhone);
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneUserQQ);
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneUserAddress);
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneUserBXKid);
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneUserTip);
                /*
                 现金支付
刷卡支付
欠款支付
支付宝
                 
                 */
                switch (tempPhones[i].PhonePayment)
                {
                    case 0:
                        lsvPhones.Items[i].SubItems.Add("现金支付");
                        break;
                    case 1:
                        lsvPhones.Items[i].SubItems.Add("刷卡支付");
                        break;
                    case 2:
                        lsvPhones.Items[i].SubItems.Add("欠款支付");
                        break;
                    case 3:
                        lsvPhones.Items[i].SubItems.Add("支付宝");
                        break;
                }
                //lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneisDelete ? "是" : "否");
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneProfit.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPhones[i].PhoneCommision.ToString());
                Application.DoEvents();
            }
            isBusy.Visible = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            cmdDelete.Enabled = false;

            try
            {
                int tempID = int.Parse(lsvPhones.SelectedItems[0].Text);
                if (tempID.ToString() != "")
                {
                    isBusy.Visible = true;
                    DelegateDeletePhoneSell dn = MysqlControl.DeletePhoneSell;

                    IAsyncResult iar = dn.BeginInvoke(tempID, null, null);

                    while (iar.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                    if (iResult.isSuccess)
                    {
                        var iDResult = new MysqlController.ReturnResult {isSuccess = false};
                        while (!iDResult.isSuccess)
                        {
                            DelegateDeleteCustomDebtByPhoneID dn1 = MysqlControl.DeleteCustomDebtByPhoneID;

                            IAsyncResult iar1 = dn1.BeginInvoke(tempID, null, null);

                            while (iar1.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            iDResult = dn1.EndInvoke(iar1);
                        }

                        MessageBox.Show("删除销售记录成功!", Application.ProductName, MessageBoxButtons.OK);
                        RefreshCustom(dtpDaily.Value.Year + dtpDaily.Value.Month.ToString().PadLeft(2, '0') +
                                      dtpDaily.Value.Day.ToString().PadLeft(2, '0'));
                    }
                    else
                    {
                        MessageBox.Show("删除销售记录失败!错误原因" + iResult.ErrDesc, Application.ProductName,
                                        MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception)
            {
                isBusy.Visible = false;
                cmdDelete.Enabled = true;
                return;
            }
            isBusy.Visible = false;
            cmdDelete.Enabled = true;
        }

        private void frmDailySellPhones_Shown(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            try
            {
                DelegateManufacturer dn = MysqlControl.Manufacturer;

                IAsyncResult iar = dn.BeginInvoke(null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                string[] Tempstr = dn.EndInvoke(iar);

                for (int i = 0; i < Tempstr.Length; i++)
                {
                    if (Tempstr[i] != null && Tempstr[i] != "")
                    {
                        ArrBrand[i] = Tempstr[i];
                    }
                    Application.DoEvents();
                }

                DelegateSellers dn2 = MysqlControl.Sellers;

                IAsyncResult iar2 = dn2.BeginInvoke(null, null);

                while (iar2.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                Tempstr = dn2.EndInvoke(iar2);

                for (int i = 0; i < Tempstr.Length; i++)
                {
                    if (Tempstr[i] != null && Tempstr[i] != "")
                    {
                        ArrSeller[i] = Tempstr[i];
                    }
                    Application.DoEvents();
                }
                //cmbPhoneBrand.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.frmNewCustom_frmNewCustom_Load_数据库连接失败_, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            isBusy.Visible = false;
        }

        #region Nested type: DelegateDeleteCustomDebtByPhoneID

        private delegate MysqlController.ReturnResult DelegateDeleteCustomDebtByPhoneID(int EquipID);

        #endregion

        #region Nested type: DelegateDeletePhoneSell

        private delegate MysqlController.ReturnResult DelegateDeletePhoneSell(int PhoneID);

        #endregion

        #region Nested type: DelegateManufacturer

        private delegate string[] DelegateManufacturer();

        #endregion

        #region Nested type: DelegateReadPhoneSell

        private delegate MysqlController.LXSellPhone[] DelegateReadPhoneSell(string reqDate);

        #endregion

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion
    }
}