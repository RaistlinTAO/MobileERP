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
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmEditSellEditor : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        public MysqlController.LXSellPhone iPhone;


        public frmEditSellEditor()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void frmEditSellEditor_Load(object sender, EventArgs e)
        {
            //nothing to do
            cmbPhoneBrand.Items.Clear();
            cmbSeller.Items.Clear();
        }

        private void frmEditSellEditor_Shown(object sender, EventArgs e)
        {
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

                //LOAD DATA....
                LoadData();

                //cmbPhoneBrand.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.frmNewCustom_frmNewCustom_Load_数据库连接失败_, Application.ProductName,
                                MessageBoxButtons.OK);
            }
        }

        private void LoadData()
        {
            txtUserCName.Text = iPhone.PhoneUserName;
            cmbType.SelectedIndex = iPhone.PhoneUserType;
            txtPhone.Text = iPhone.PhoneUsercellPhone;
            txtPhone2.Text = iPhone.PhoneUsercellPhoneback;
            txtContectAddress.Text = iPhone.PhoneUserAddress;
            txtEmail.Text = iPhone.PhoneUseremail;
            txtQQ.Text = iPhone.PhoneUserQQ;
            txtTelephone.Text = iPhone.PhoneUserTelePhone;
            dtpBuyPhone.Value = new DateTime(int.Parse(iPhone.PhoneDate.Substring(0, 4)),
                                             int.Parse(iPhone.PhoneDate.Substring(4, 2)),
                                             int.Parse(iPhone.PhoneDate.Substring(6, 2)))
                ;
            cmbPhoneBrand.SelectedIndex = iPhone.PhoneBrandid;
            cmbPhoneName.Text = iPhone.PhoneName;
            cmbSeller.Text = iPhone.PhoneSeller;
            txtPhoneIMEI.Text = iPhone.PhoneIMEI;
            txtSupplier.Text = iPhone.PhoneSupplier;
            txtPhonePrice.Text = iPhone.PhonePrice.ToString();
            txtRealPrice.Text = iPhone.PhoneRealprice.ToString();
            txtScreenGuardPrice.Text = iPhone.PhoneScreenGuard.ToString();
            txtBettaryPrice.Text = iPhone.PhoneBattery.ToString();
            txtSDCardPrice.Text = iPhone.PhoneSDCARD.ToString();
            txtShellPrice.Text = iPhone.PhoneShell.ToString();
            txtChargePrice.Text = iPhone.PhoneCarCharger.ToString();
            txtHeadPhonePrice.Text = iPhone.PhoneHeadPhone.ToString();
            txtCardlePrice.Text = iPhone.PhoneCarCradle.ToString();
            txtOtherPrice.Text = iPhone.PhoneOther.ToString();
            if (iPhone.PhoneWarranty)
            {
                ckbWarranty.Checked = true;
                cmbWarrantyType.SelectedIndex = iPhone.PhoneWarrantyType;
                cmbWarrantyDuration.SelectedIndex = iPhone.PhoneWarrantyDuration;
                txtWarrantyPrice.Text = iPhone.PhoneWarrantyPrice.ToString();
            }
            else
            {
                ckbWarranty.Checked = false;
                //do nothing
            }
            txtBXKid.Text = iPhone.PhoneUserBXKid;
            cmbPayment.SelectedIndex = iPhone.PhonePayment;
            if (iPhone.PhoneisLegal)
            {
                ckbisLegal.Checked = true;
            }
            if (iPhone.PhoneisUnLegal)
            {
                ckbisUnLegal.Checked = true;
            }
            if (iPhone.PhoneisHKLegal)
            {
                ckbisHKLegal.Checked = true;
            }
            txtUserTip.Text = iPhone.PhoneUserTip;
        }

        private void cmbPhoneBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            //首先检测数据

            if (txtPhone.Text == "" || !Regex.IsMatch(txtPhone.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的手机号码_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtPhone.Text == "" || !Regex.IsMatch(txtPhone2.Text.Trim(), @"^[0-9]+$"))
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
                iPhone.PhoneBattery = double.Parse(txtBettaryPrice.Text);
                iPhone.PhoneBrandid = cmbPhoneBrand.SelectedIndex;
                iPhone.PhoneCarCharger = double.Parse(txtChargePrice.Text);
                iPhone.PhoneCarCradle = double.Parse(txtCardlePrice.Text);
                iPhone.PhoneDate = dtpBuyPhone.Value.Year + dtpBuyPhone.Value.Month.ToString().PadLeft(2, '0') +
                                   dtpBuyPhone.Value.Day.ToString().PadLeft(2, '0');

                iPhone.PhoneHeadPhone = double.Parse(txtHeadPhonePrice.Text);
                iPhone.PhoneIMEI = txtPhoneIMEI.Text;
                iPhone.PhoneisDelete = false;
                iPhone.PhoneisHKLegal = ckbisHKLegal.Checked;
                iPhone.PhoneisLegal = ckbisLegal.Checked;
                //
                iPhone.PhoneisUnLegal = ckbisUnLegal.Checked;
                iPhone.PhoneName = cmbPhoneName.Text;
                iPhone.PhoneOther = double.Parse(txtOtherPrice.Text);
                iPhone.PhonePayment = cmbPayment.SelectedIndex;
                iPhone.PhonePrice = double.Parse(txtPhonePrice.Text);

                iPhone.PhoneRealprice = double.Parse(txtRealPrice.Text);
                iPhone.PhoneScreenGuard = double.Parse(txtScreenGuardPrice.Text);
                iPhone.PhoneSDCARD = double.Parse(txtSDCardPrice.Text);
                iPhone.PhoneSeller = cmbSeller.Text;
                iPhone.PhoneShell = double.Parse(txtShellPrice.Text);
                //
                iPhone.PhoneSupplier = txtSupplier.Text;
                iPhone.PhoneUserAddress = txtContectAddress.Text;
                iPhone.PhoneUserBXKid = txtBXKid.Text;
                iPhone.PhoneUsercellPhone = txtPhone.Text;
                iPhone.PhoneUsercellPhoneback = txtPhone2.Text;

                iPhone.PhoneUseremail = txtEmail.Text;
                iPhone.PhoneUserName = txtUserCName.Text;
                iPhone.PhoneUserQQ = txtQQ.Text;
                iPhone.PhoneUserTelePhone = txtTelephone.Text;
                iPhone.PhoneUserTip = txtUserTip.Text;
                //
                iPhone.PhoneUserType = cmbType.SelectedIndex;
                iPhone.PhoneWarranty = ckbWarranty.Checked;
                iPhone.PhoneWarrantyDate = dtpBuyPhone.Value.Year +
                                           dtpBuyPhone.Value.Month.ToString().PadLeft(2, '0') +
                                           dtpBuyPhone.Value.Day.ToString().PadLeft(2, '0');
                iPhone.PhoneWarrantyDuration = cmbWarrantyDuration.SelectedIndex;
                iPhone.PhoneWarrantyPrice = double.Parse(txtWarrantyPrice.Text);

                iPhone.PhoneWarrantyType = cmbWarrantyType.SelectedIndex;

                DialogResult = DialogResult.OK;
            }
        }

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