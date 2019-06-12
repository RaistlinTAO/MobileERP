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
    using System.Data;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Log;
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmNewSell : Form
    {
        private readonly clsLog LogControl = new clsLog();
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string iLoginUser;
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();

        #region 窗体事件

        public frmNewSell(ToolStripStatusLabel iBusy, string LoginUser)
        {
            iLoginUser = LoginUser;
            isBusy = iBusy;
            InitializeComponent();
        }


        private void ckbWarranty_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbWarranty.Checked)
            {
                cmbWarrantyType.Enabled = true;
                cmbWarrantyDuration.Enabled = true;
                txtWarrantyPrice.Enabled = true;
                txtBXKid.Enabled = true;
            }
            else
            {
                txtBXKid.Enabled = false;
                txtBXKid.Text = "";
                cmbWarrantyType.Enabled = false;
                cmbWarrantyDuration.Enabled = false;
                txtWarrantyPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
                cmbWarrantyType.SelectedIndex = 0;
                cmbWarrantyDuration.SelectedIndex = 0;
                txtWarrantyPrice.Enabled = false;
            }
        }

        private void frmNewSell_Load(object sender, EventArgs e)
        {
            cmbPhoneBrand.Items.Clear();
            cmbSeller.Items.Clear();
            cmbType.SelectedIndex = 0;
            cmbWarrantyType.SelectedIndex = 0;
            cmbWarrantyDuration.SelectedIndex = 0;
            cmbPayment.SelectedIndex = 0;
        }

        private void frmNewSell_Shown(object sender, EventArgs e)
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
                        cmbPhoneBrand.Items.Add(Tempstr[i]);
                    }
                    Application.DoEvents();
                }
                cmbPhoneBrand.SelectedIndex = 0;

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
                        cmbSeller.Items.Add(Tempstr[i]);
                    }
                    Application.DoEvents();
                }
                cmbSeller.SelectedIndex = 0;
                //cmbPhoneBrand.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.frmNewCustom_frmNewCustom_Load_数据库连接失败_, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            isBusy.Visible = false;
        }

        private void cmbPhoneBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            cmbPhoneName.Items.Clear();

            DelegateReadPhones dn = MysqlControl.ReadPhones;

            IAsyncResult iar = dn.BeginInvoke(cmbPhoneBrand.SelectedIndex, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            DataTable tempBPhones = dn.EndInvoke(iar);

            cmbPhoneName.Items.Clear();
            for (int i = 0; i < tempBPhones.Rows.Count; i++)
            {
                DataRow drOperate = tempBPhones.Rows[i];
                cmbPhoneName.Items.Add(drOperate["PhoneName"]);
                Application.DoEvents();
            }
            isBusy.Visible = false;
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayment.SelectedIndex == 0)
            {
                label24.Visible = false;
                txtUnDebt.Visible = false;
                txtUnDebt.Text = Resources.frmNewCustom_cmbPayment_SelectedIndexChanged__0;
            }
            else
            {
                label24.Visible = true;
                txtUnDebt.Visible = true;
                txtUnDebt.Text = Resources.frmNewCustom_cmbPayment_SelectedIndexChanged__0;
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtUserCName.Text = "";
            //cmbGroup.SelectedIndex = 0;
            txtPhone.Text = "";
            txtPhone2.Text = "";
            txtContectAddress.Text = "";
            txtTelephone.Text = "";
            txtEmail.Text = "";
            txtQQ.Text = "";
            cmbType.SelectedIndex = 0;
            txtBXKid.Text = "";
            //ckbBXK.Checked = true;
            cmbPhoneBrand.SelectedIndex = 0;
            txtPhonePrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            txtRealPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            cmbSeller.SelectedIndex = 0;
            txtPhoneIMEI.Text = "";
            //ckbEquip.Checked = true;
            txtScreenGuardPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            txtBettaryPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            txtSDCardPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            txtShellPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            txtChargePrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            txtHeadPhonePrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            txtCardlePrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            txtOtherPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;

            txtSupplier.Text = "";
            ckbisUnLegal.Checked = true;
            ckbisHKLegal.Checked = false;
            ckbisLegal.Checked = false;
            ckbWarranty.Checked = true;
            cmbWarrantyType.SelectedIndex = 0;
            cmbWarrantyDuration.SelectedIndex = 0;
            txtWarrantyPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            cmbPayment.SelectedIndex = 0;
            txtUserTip.Text = Resources.frmNewCustom_CleanUI_N_A;
        }

        #endregion

        private void cmdAddUser_Click(object sender, EventArgs e)
        {
            //首先检测数据

            if (txtPhone.Text == "" || !Regex.IsMatch(txtPhone.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的手机号码_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtPhone2.Text != "" && !Regex.IsMatch(txtPhone2.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的手机号码_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            //txtUnDebt

            if (txtUnDebt.Text == "" || !Regex.IsMatch(txtUnDebt.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的已支付款额_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtPhonePrice.Text == "" || !Regex.IsMatch(txtPhonePrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的手机销售价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtRealPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的手机成本价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtScreenGuardPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show("请填写正确的屏贴成本价格", Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtBettaryPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show("请填写正确的电池成本价格", Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtSDCardPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show("请填写正确的SD卡成本价格", Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtShellPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show("请填写正确的保护套成本价格", Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtChargePrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show("请填写正确的车载充电器成本价格", Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtHeadPhonePrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show("请填写正确的耳机成本价格", Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtCardlePrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show("请填写正确的车载支架成本价格", Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtOtherPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show("请填写正确的其他(赠品)成本价格", Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtPhoneIMEI.Text == "")
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的手机IMEI_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }


            if (txtWarrantyPrice.Text == "" || !Regex.IsMatch(txtWarrantyPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的保修卡销售价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (ckbWarranty.Checked && txtBXKid.Text == "")
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_已经勾选保修卡_但未填写保修卡编号_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (cmbPhoneBrand.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请选择正确的生产厂商_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            if (cmbPhoneName.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请选择正确的手机型号_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            if (cmbSeller.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请选择正确的销售人员_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (
                MessageBox.Show(
                    "是否确认递交以下内容?\r\n客户名称:" + txtUserCName.Text + "\r\n手机号码:" + txtPhone.Text + "\r\n保修卡:" +
                    txtBXKid.Text + "\r\n购机时间:" + dtpBuyPhone.Value.Year +
                    dtpBuyPhone.Value.Month.ToString().PadLeft(2, '0') +
                    dtpBuyPhone.Value.Day.ToString().PadLeft(2, '0') + "\r\n手机品牌:" + cmbPhoneBrand.Text + "\r\n手机型号:" +
                    cmbPhoneName.Text + "\r\n手机购买价格:" + txtPhonePrice.Text + "\r\n实际成本:" + txtRealPrice.Text +
                    "\r\n销售人员:" + cmbSeller.Text + "\r\n手机串号:" + txtPhoneIMEI.Text + "\r\n供应商:" + txtSupplier.Text,
                    Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                cmdAddUser.Enabled = false;
                isBusy.Visible = true;

                var tempPhone = new MysqlController.LXSellPhone();

                tempPhone.PhoneBattery = double.Parse(txtBettaryPrice.Text);
                tempPhone.PhoneBrandid = cmbPhoneBrand.SelectedIndex;
                tempPhone.PhoneCarCharger = double.Parse(txtChargePrice.Text);
                tempPhone.PhoneCarCradle = double.Parse(txtCardlePrice.Text);
                tempPhone.PhoneDate = dtpBuyPhone.Value.Year + dtpBuyPhone.Value.Month.ToString().PadLeft(2, '0') +
                                      dtpBuyPhone.Value.Day.ToString().PadLeft(2, '0');
                tempPhone.PhoneHeadPhone = double.Parse(txtHeadPhonePrice.Text);
                tempPhone.PhoneIMEI = txtPhoneIMEI.Text;
                tempPhone.PhoneisDelete = false;
                tempPhone.PhoneisHKLegal = ckbisHKLegal.Checked;
                tempPhone.PhoneisLegal = ckbisLegal.Checked;
                tempPhone.PhoneisUnLegal = ckbisUnLegal.Checked;
                tempPhone.PhoneName = cmbPhoneName.Text;
                tempPhone.PhoneOther = double.Parse(txtOtherPrice.Text);
                tempPhone.PhonePayment = cmbPayment.SelectedIndex;
                tempPhone.PhonePrice = double.Parse(txtPhonePrice.Text);
                tempPhone.PhoneRealprice = double.Parse(txtRealPrice.Text);
                tempPhone.PhoneScreenGuard = double.Parse(txtScreenGuardPrice.Text);
                tempPhone.PhoneSDCARD = double.Parse(txtSDCardPrice.Text);
                tempPhone.PhoneSeller = cmbSeller.Text;
                tempPhone.PhoneShell = double.Parse(txtShellPrice.Text);
                tempPhone.PhoneSupplier = txtSupplier.Text;
                tempPhone.PhoneUserAddress = txtContectAddress.Text;
                tempPhone.PhoneUserBXKid = txtBXKid.Text;
                tempPhone.PhoneUsercellPhone = txtPhone.Text;
                tempPhone.PhoneUsercellPhoneback = txtPhone2.Text;
                tempPhone.PhoneUseremail = txtEmail.Text;
                tempPhone.PhoneUserName = txtUserCName.Text;
                tempPhone.PhoneUserQQ = txtQQ.Text;
                tempPhone.PhoneUserTelePhone = txtTelephone.Text;
                tempPhone.PhoneUserTip = txtUserTip.Text;
                tempPhone.PhoneUserType = cmbType.SelectedIndex;
                tempPhone.PhoneWarranty = ckbWarranty.Checked;
                tempPhone.PhoneWarrantyDate = dtpBuyPhone.Value.Year +
                                              dtpBuyPhone.Value.Month.ToString().PadLeft(2, '0') +
                                              dtpBuyPhone.Value.Day.ToString().PadLeft(2, '0');
                tempPhone.PhoneWarrantyDuration = cmbWarrantyDuration.SelectedIndex;
                tempPhone.PhoneWarrantyPrice = double.Parse(txtWarrantyPrice.Text);
                tempPhone.PhoneWarrantyType = cmbWarrantyType.SelectedIndex;

                //DelegateAddNewSell
                DelegateAddNewSell dnAdd = MysqlControl.AddNewSell;

                IAsyncResult iarAdd = dnAdd.BeginInvoke(tempPhone, null, null);

                while (iarAdd.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dnAdd.EndInvoke(iarAdd);

                if (iResult.isSuccess)
                {
                    //添加新销售成功 需要处理客户欠款及其余收尾工作

                    //添加欠款
                    /*
                     * 现金支付
                        刷卡支付
                        欠款支付
                        支付宝
                     */
                    if (cmbPayment.SelectedIndex != 0)
                    {
                        var iCustomDebt = new MysqlController.LXCustomDebt
                                              {
                                                  DebtCustom = txtUserCName.Text,
                                                  DebtType = cmbPayment.SelectedIndex - 1,
                                                  DebtDate =
                                                      dtpBuyPhone.Value.Year +
                                                      dtpBuyPhone.Value.Month.ToString().PadLeft(2, '0') +
                                                      dtpBuyPhone.Value.Day.ToString().PadLeft(2, '0'),
                                                  DebtDetail = "购买手机:" + cmbPhoneName.Text + " 备注:" + txtUserTip.Text,
                                                  DebtisFix = false,
                                                  DebtPhoneID = iResult.PhoneID,
                                                  DebtPrice =
                                                      Math.Round(
                                                          double.Parse(txtPhonePrice.Text) -
                                                          double.Parse(txtUnDebt.Text), 2),
                                                  DebtFixDate =
                                                      DateTime.Now.Year +
                                                      DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                                      DateTime.Now.Day.ToString().PadLeft(2, '0'),
                                                  DebtisInCircle = true,
                                              };
                        var iDResult = new MysqlController.ReturnResult {isSuccess = false};
                        while (!iDResult.isSuccess)
                        {
                            DelegateAddCustomDebt dn1 = MysqlControl.AddCustomDebt;

                            IAsyncResult iar1 = dn1.BeginInvoke(iCustomDebt, null, null);

                            while (iar1.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            iDResult = dn1.EndInvoke(iar1);
                        }
                    }

                    //扫尾工
                    MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_添加用户成功_已经添加用户_ + txtUserCName.Text,
                                    Application.ProductName, MessageBoxButtons.OK);
                    txtLastAdd.Text = Resources.frmNewCustom_cmdAddUser_Click_刚刚添加的用户为_ + txtUserCName.Text +
                                      Resources.frmNewCustom_cmdAddUser_Click___购买机型为 + cmbPhoneName.Text;
                    cmdClear_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_ + iResult.ErrDesc, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
                isBusy.Visible = false;
                cmdAddUser.Enabled = true;
            }
        }

        #region Nested type: DelegateAddCustomDebt

        private delegate MysqlController.ReturnResult DelegateAddCustomDebt(MysqlController.LXCustomDebt iCustomDebt);

        #endregion

        #region Nested type: DelegateAddNewSell

        private delegate MysqlController.ReturnResult DelegateAddNewSell(MysqlController.LXSellPhone tempPhone);

        #endregion

        #region Nested type: DelegateManufacturer

        private delegate string[] DelegateManufacturer();

        #endregion

        #region Nested type: DelegateReadPhones

        private delegate DataTable DelegateReadPhones(int iManu);

        #endregion

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion
    }
}