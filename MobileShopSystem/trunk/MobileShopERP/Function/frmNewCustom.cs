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

#region

#endregion

namespace LongXiangCRM.Function
{
    #region

    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Log;
    using DataControler.Mysql;
    using LongXiangCRM.Properties;

    #endregion

    #region

    #endregion

    public partial class frmNewCustom : Form
    {
        private readonly clsLog LogControl = new clsLog();
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string iLoginUser;
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();

        public frmNewCustom(ToolStripStatusLabel iBusy, string LoginUser)
        {
            iLoginUser = LoginUser;
            isBusy = iBusy;
            InitializeComponent();
        }

        private void frmNewCustom_Load(object sender, EventArgs e)
        {
            cmbPhoneBrand.Items.Clear();
            cmbSeller.Items.Clear();
            cmbGroup.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbWarrantyType.SelectedIndex = 0;
            cmbWarrantyDuration.SelectedIndex = 0;
            cmbPayment.SelectedIndex = 0;
        }

        private void frmNewCustom_Shown(object sender, EventArgs e)
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

        private void cmdAddUser_Click(object sender, EventArgs e)
        {
            var tempUser = new MysqlController.LXUser();
            var tempPhone = new MysqlController.LXPhones[1];

            tempPhone[0].PhoneBrand = cmbPhoneBrand.SelectedIndex.ToString();
            tempPhone[0].PhoneIMEI = txtPhoneIMEI.Text;
            tempPhone[0].PhoneName = cmbPhoneName.Text;
            tempPhone[0].PhonePrice = txtPhonePrice.Text;
            tempPhone[0].PhoneRealPrice = txtRealPrice.Text;
            tempPhone[0].PhoneSeller = cmbSeller.SelectedIndex.ToString();
            tempPhone[0].PhoneHasEquip = ckbEquip.Checked;
            tempPhone[0].PhoneDate = dtpBuyPhone.Value.Year + dtpBuyPhone.Value.Month.ToString().PadLeft(2, '0') +
                                     dtpBuyPhone.Value.Day.ToString().PadLeft(2, '0');
            tempPhone[0].PhoneHasWarranty = ckbWarranty.Checked;
            tempPhone[0].PhoneWarrantyType = cmbWarrantyType.SelectedIndex.ToString();
            tempPhone[0].PhoneWarrantyDuration = cmbWarrantyDuration.SelectedIndex.ToString();
            tempPhone[0].PhoneWarrantyDate = tempPhone[0].PhoneDate;
            tempPhone[0].PhoneIsDelete = false;
            tempPhone[0].phone_supplier = txtSupplier.Text;
            tempPhone[0].PhoneEquipPrice = txtEquipPrice.Text;
            tempPhone[0].PhoneEquipRealPrice = txtEquipRealPrice.Text;
            tempPhone[0].PhoneIsLegal = ckbisLegal.Checked;
            tempPhone[0].PhoneIsHKLegal = ckbisHKLegal.Checked;
            tempPhone[0].PhoneIsUnLegal = ckbisUnLegal.Checked;
            tempPhone[0].PhoneWarrantyPrice = txtWarrantyPrice.Text;
            tempUser.BuyPhones = tempPhone;
            tempUser.Email = txtEmail.Text;
            tempUser.BXKid = txtBXKid.Text;
            tempUser.ContectAddress = txtContectAddress.Text;
            tempUser.haveBXK = ckbBXK.Checked;
            tempUser.LXCredit = txtPhonePrice.Text;

            tempUser.Phone = txtPhone.Text;
            tempUser.QQ = txtQQ.Text;
            tempUser.UserCName = txtUserCName.Text;
            tempUser.UserName = txtUserName.Text;
            tempUser.UserTip = txtUserTip.Text;
            tempUser.Telephone = txtTelephone.Text;
            tempUser.userType = cmbType.SelectedIndex;

            switch (cmbGroup.SelectedIndex)
            {
                case 0:
                    tempUser.GroupID = 15;
                    break;
                case 1:
                    tempUser.GroupID = 16;
                    break;
                case 2:
                    tempUser.GroupID = 17;
                    break;
                case 3:
                    tempUser.GroupID = 18;
                    break;
                default:
                    tempUser.GroupID = 0;
                    break;
            }

            tempUser.Birthday = dtpBirthday.Value.Year + dtpBirthday.Value.Month.ToString().PadLeft(2, '0') +
                                dtpBirthday.Value.Day.ToString().PadLeft(2, '0');
            //首先检测数据

            if (txtPhone.Text == "" || !Regex.IsMatch(txtPhone.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的手机号码_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            //txtUnDebt

            if (txtUnDebt.Text == "" || !Regex.IsMatch(txtUnDebt.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的已支付款额_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtPhonePrice.Text == "" || !Regex.IsMatch(txtPhonePrice.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的手机销售价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtRealPrice.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的手机成本价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtPhoneIMEI.Text == "")
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的手机IMEI_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtEquipPrice.Text == "" || !Regex.IsMatch(txtEquipPrice.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的配件销售价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtEquipRealPrice.Text == "" || !Regex.IsMatch(txtEquipRealPrice.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的配件成本价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtWarrantyPrice.Text == "" || !Regex.IsMatch(txtWarrantyPrice.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的保修卡销售价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (ckbBXK.Checked && txtBXKid.Text == "")
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
                //这里进行手机号验证;
                isBusy.Visible = true;

                DelegateGetSingleUser dn = MysqlControl.GetSingleUser;

                IAsyncResult iar = dn.BeginInvoke("", txtPhone.Text, "", null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnUsers tempUsers = dn.EndInvoke(iar);

                if (tempUsers.UserNum > 0)
                {
                    isBusy.Visible = false;

                    string BuyPhone = "";
                    for (int i = 0; i < tempUsers.UserInfo[0].BuyPhones.Length; i++)
                    {
                        BuyPhone = BuyPhone + "\r\n" + tempUsers.UserInfo[0].BuyPhones[i].PhoneName;
                    }
                    if (
                        MessageBox.Show(
                            Resources.frmNewCustom_cmdAddUser_Click_已经存在该用户_将跳转到用户修改页面进行操作_ + "\r\n用户详细信息:\r\n" +
                            tempUsers.UserInfo[0].UserCName + "\r\n手机号码:" + tempUsers.UserInfo[0].Phone + "\r\n保修卡号:" +
                            tempUsers.UserInfo[0].BXKid + "\r\n已经购买手机:" + BuyPhone, Application.ProductName,
                            MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        var iCustem = new frmEditCustem(isBusy, iLoginUser)
                                          {TopLevel = false, Dock = DockStyle.Fill, Parent = Parent};
                        iCustem.SetCustom(tempUsers.UserInfo[0]);
                        iCustem.Show();
                        iCustem.BringToFront();
                        Parent.BringToFront();

                        iCustem.AddPhone(tempPhone[0], cmbPayment.SelectedIndex, txtUnDebt.Text);

                        return;
                    }
                }

                //正常添加
                cmdAddUser.Enabled = false;
                isBusy.Visible = true;

                DelegateAddUser dnAdd = MysqlControl.AddUser;

                IAsyncResult iarAdd = dnAdd.BeginInvoke(tempUser, null, null);

                while (iarAdd.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dnAdd.EndInvoke(iarAdd);

                if (iResult.isSuccess)
                {
                    //这里去增加到客户欠款里
                    if (cmbPayment.SelectedIndex != 0)
                    {
                        var iDebt = new MysqlController.LXCustomDebt
                                        {
                                            DebtDate =
                                                dtpBuyPhone.Value.Year +
                                                dtpBuyPhone.Value.Month.ToString().PadLeft(2, '0') +
                                                dtpBuyPhone.Value.Day.ToString().PadLeft(2, '0'),
                                            DebtCustom = txtUserCName.Text,
                                            DebtDetail = "购买手机:" + cmbPhoneBrand.Text + " - " + cmbPhoneName.Text,
                                            DebtisFix = false,
                                            DebtPrice = int.Parse(txtPhonePrice.Text) + int.Parse(txtEquipPrice.Text) +
                                                        int.Parse(txtWarrantyPrice.Text) - int.Parse(txtUnDebt.Text),
                                            DebtType = cmbPayment.SelectedIndex - 1
                                        };

                        var iDResult = new MysqlController.ReturnResult {isSuccess = false};

                        while (!iDResult.isSuccess)
                        {
                            DelegateAddCustomDebt dnACD = MysqlControl.AddCustomDebt;
                            IAsyncResult iarACD = dnACD.BeginInvoke(iDebt, null, null);
                            while (iarACD.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }
                            iDResult = dnACD.EndInvoke(iarACD);
                        }
                    }

                    var iLog = new clsLog.LogPart();

                    iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                   DateTime.Now.Day.ToString().PadLeft(2, '0');
                    iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                    iLog.LogUser = iLoginUser;
                    iLog.LogDetail = @"添加客户:" + txtUserCName.Text;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_添加用户成功_已经添加用户_ + txtUserCName.Text,
                                    Application.ProductName, MessageBoxButtons.OK);
                    txtLastAdd.Text = Resources.frmNewCustom_cmdAddUser_Click_刚刚添加的用户为_ + txtUserCName.Text +
                                      Resources.frmNewCustom_cmdAddUser_Click___购买机型为 + cmbPhoneName.Text;

                    CleanUI();
                }
                else
                {
                    MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_ + iResult.ErrDesc, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
            isBusy.Visible = false;
            cmdAddUser.Enabled = true;
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

        private void ckbBXK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbBXK.Checked)
            {
                txtBXKid.Enabled = true;
            }
            else
            {
                txtBXKid.Enabled = false;
                txtBXKid.Text = "";
            }
        }

        private void ckbWarranty_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbWarranty.Checked)
            {
                cmbWarrantyType.Enabled = true;
                cmbWarrantyDuration.Enabled = true;
                txtWarrantyPrice.Enabled = true;
            }
            else
            {
                cmbWarrantyType.Enabled = false;
                cmbWarrantyDuration.Enabled = false;
                txtWarrantyPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
                cmbWarrantyType.SelectedIndex = 0;
                cmbWarrantyDuration.SelectedIndex = 0;
                txtWarrantyPrice.Enabled = false;
            }
        }

        private void ckbEquip_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEquip.Checked)
            {
                txtEquipPrice.Enabled = true;
                txtEquipRealPrice.Enabled = true;
            }
            else
            {
                txtEquipPrice.Enabled = false;
                txtEquipRealPrice.Enabled = false;
                txtEquipPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
                txtEquipRealPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            }
        }

        private void CleanUI()
        {
            txtUserCName.Text = "";
            cmbGroup.SelectedIndex = 0;
            txtPhone.Text = "";
            txtContectAddress.Text = "";
            txtTelephone.Text = "";
            txtEmail.Text = "";
            txtQQ.Text = "";
            cmbType.SelectedIndex = 0;
            txtBXKid.Text = "";
            ckbBXK.Checked = true;
            cmbPhoneBrand.SelectedIndex = 0;
            txtPhonePrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            txtRealPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            cmbSeller.SelectedIndex = 0;
            txtPhoneIMEI.Text = "";
            ckbEquip.Checked = true;
            txtEquipPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
            txtEquipRealPrice.Text = Resources.frmNewCustom_ckbEquip_CheckedChanged__0;
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

        #region Nested type: DelegateAddCustomDebt

        private delegate MysqlController.ReturnResult DelegateAddCustomDebt(MysqlController.LXCustomDebt iCustomDebt);

        #endregion

        #region Nested type: DelegateAddLog

        private delegate bool DelegateAddLog(clsLog.LogPart iLog);

        #endregion

        #region Nested type: DelegateAddUser

        private delegate MysqlController.ReturnResult DelegateAddUser(MysqlController.LXUser tempUser);

        #endregion

        #region Nested type: DelegateGetSingleUser

        private delegate MysqlController.ReturnUsers DelegateGetSingleUser(
            string UserCName, string UserPhone, string UserBXKId);

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