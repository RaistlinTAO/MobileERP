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

namespace LongXiangCRM.Function
{
    #region

    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using LongXiangCRM.Properties;

    #endregion

    public partial class frmAddPhone : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        public bool IsAddExist;
        public bool IsEditMode;
        public int PaymentType;
        public string UnDebtPrice;
        public MysqlController.LXPhones iPhones;

        public frmAddPhone()
        {
            InitializeComponent();
        }

        public MysqlController.LXPhones GetRespos()
        {
            return iPhones;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //这里判断输入值正确性

            if (txtUnDebt.Text == "" || !Regex.IsMatch(txtUnDebt.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmNewCustom_cmdAddUser_Click_请填写正确的已支付款额_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtPhonePrice.Text == "" || !Regex.IsMatch(txtPhonePrice.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmAddPhone_cmdOK_Click_请填写正确的手机销售价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtRealPrice.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmAddPhone_cmdOK_Click_请填写正确的手机成本价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtPhoneIMEI.Text == "")
            {
                MessageBox.Show(Resources.frmAddPhone_cmdOK_Click_请填写正确的手机IMEI_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtEquipPrice.Text == "" || !Regex.IsMatch(txtEquipPrice.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmAddPhone_cmdOK_Click_请填写正确的配件销售价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtEquipRealPrice.Text == "" || !Regex.IsMatch(txtEquipRealPrice.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmAddPhone_cmdOK_Click_请填写正确的配件成本价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtWarrantyPrice.Text == "" || !Regex.IsMatch(txtWarrantyPrice.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmAddPhone_cmdOK_Click_请填写正确的保修卡销售价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (cmbPhoneBrand.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.frmAddPhone_cmdOK_Click_请选择正确的生产厂商_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            if (cmbPhoneName.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.frmAddPhone_cmdOK_Click_请选择正确的手机型号_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            if (cmbSeller.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.frmAddPhone_cmdOK_Click_请选择正确的销售人员_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            iPhones.PhoneBrand = cmbPhoneBrand.SelectedIndex.ToString();
            iPhones.PhoneIMEI = txtPhoneIMEI.Text;
            iPhones.PhoneName = cmbPhoneName.Text;
            iPhones.PhonePrice = txtPhonePrice.Text;
            iPhones.PhoneRealPrice = txtRealPrice.Text;
            iPhones.PhoneSeller = cmbSeller.SelectedIndex.ToString();
            iPhones.PhoneHasEquip = ckbEquip.Checked;
            iPhones.PhoneDate = dtpBuyPhone.Value.Year + dtpBuyPhone.Value.Month.ToString().PadLeft(2, '0') +
                                dtpBuyPhone.Value.Day.ToString().PadLeft(2, '0');
            iPhones.PhoneHasWarranty = ckbWarranty.Checked;
            iPhones.PhoneWarrantyType = cmbWarrantyType.SelectedIndex.ToString();
            iPhones.PhoneWarrantyDuration = cmbWarrantyDuration.SelectedIndex.ToString();
            iPhones.PhoneWarrantyDate = iPhones.PhoneDate;
            iPhones.phone_supplier = txtSupplier.Text;
            iPhones.PhoneEquipPrice = txtEquipPrice.Text;
            iPhones.PhoneEquipRealPrice = txtEquipRealPrice.Text;
            iPhones.PhoneIsLegal = ckbisLegal.Checked;
            iPhones.PhoneIsHKLegal = ckbisHKLegal.Checked;
            iPhones.PhoneIsUnLegal = ckbisUnLegal.Checked;
            iPhones.PhoneWarrantyPrice = txtWarrantyPrice.Text;
            iPhones.PhonePayment = cmbPayment.SelectedIndex;
            iPhones.phoneUnDebtPrice = txtUnDebt.Text;

            DialogResult = DialogResult.OK;
        }

        private void frmAddPhone_Load(object sender, EventArgs e)
        {
            cmbPhoneBrand.Items.Clear();
            cmbSeller.Items.Clear();
            cmbWarrantyType.SelectedIndex = 0;
            cmbWarrantyDuration.SelectedIndex = 0;
            cmbPayment.SelectedIndex = 0;
            try
            {
                string[] Tempstr = MysqlControl.Manufacturer();
                for (int i = 0; i < Tempstr.Length; i++)
                {
                    if (Tempstr[i] != null && Tempstr[i] != "")
                    {
                        cmbPhoneBrand.Items.Add(Tempstr[i]);
                    }
                }
                Tempstr = MysqlControl.Sellers();
                for (int i = 0; i < Tempstr.Length; i++)
                {
                    if (Tempstr[i] != null && Tempstr[i] != "")
                    {
                        cmbSeller.Items.Add(Tempstr[i]);
                    }
                }
                //cmbPhoneBrand.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.frmAddPhone_frmAddPhone_Load_数据库连接失败_, Application.ProductName,
                                MessageBoxButtons.OK);
            }

            cmbPhoneBrand.SelectedIndex = 0;
            cmbWarrantyType.SelectedIndex = 0;
            cmbWarrantyDuration.SelectedIndex = 0;
            cmbPayment.SelectedIndex = 0;
            cmbSeller.SelectedIndex = 0;

            if (!IsEditMode) return;
            dtpBuyPhone.Value =
                DateTime.Parse(iPhones.PhoneDate.Substring(0, 4) + "-" + iPhones.PhoneDate.Substring(4, 2) + "-" +
                               iPhones.PhoneDate.Substring(6, 2));
            cmbPhoneBrand.SelectedIndex = int.Parse(iPhones.PhoneBrand);
            cmbPhoneName.Text = iPhones.PhoneName;
            txtPhonePrice.Text = iPhones.PhonePrice;
            txtRealPrice.Text = iPhones.PhoneRealPrice;
            cmbSeller.SelectedIndex = int.Parse(iPhones.PhoneSeller);
            txtPhoneIMEI.Text = iPhones.PhoneIMEI;
            ckbEquip.Checked = iPhones.PhoneHasEquip;
            txtEquipPrice.Text = iPhones.PhoneEquipPrice;
            txtEquipRealPrice.Text = iPhones.PhoneEquipRealPrice;
            txtSupplier.Text = iPhones.phone_supplier;
            ckbisLegal.Checked = iPhones.PhoneIsLegal;
            ckbisHKLegal.Checked = iPhones.PhoneIsHKLegal;
            ckbisUnLegal.Checked = iPhones.PhoneIsUnLegal;
            ckbWarranty.Checked = iPhones.PhoneHasWarranty;
            cmbWarrantyType.SelectedIndex = int.Parse(iPhones.PhoneWarrantyType);
            cmbWarrantyDuration.SelectedIndex = int.Parse(iPhones.PhoneWarrantyDuration);
            txtWarrantyPrice.Text = iPhones.PhoneWarrantyPrice;
            cmdOK.Text = Resources.frmAddPhone_frmAddPhone_Load_修改;
            if (IsAddExist)
            {
                cmdOK.Text = Resources.frmAddPhone_frmAddPhone_Load_增加;
                cmbPayment.SelectedIndex = PaymentType;
                txtUnDebt.Text = UnDebtPrice;
            }
        }

        private void cmbPhoneBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPhoneName.Items.Clear();
            DataTable tempBPhones = MysqlControl.ReadPhones(cmbPhoneBrand.SelectedIndex);

            cmbPhoneName.Items.Clear();
            for (int i = 0; i < tempBPhones.Rows.Count; i++)
            {
                DataRow drOperate = tempBPhones.Rows[i];
                cmbPhoneName.Items.Add(drOperate["PhoneName"]);
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
                txtWarrantyPrice.Enabled = false;
                cmbWarrantyType.SelectedIndex = 0;
                cmbWarrantyDuration.SelectedIndex = 0;
                txtWarrantyPrice.Text = Resources.frmAddPhone_ckbEquip_CheckedChanged__0;
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
                txtEquipPrice.Text = Resources.frmAddPhone_ckbEquip_CheckedChanged__0;
                txtEquipRealPrice.Text = Resources.frmAddPhone_ckbEquip_CheckedChanged__0;
            }
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayment.SelectedIndex == 0)
            {
                label24.Visible = false;
                txtUnDebt.Visible = false;
                txtUnDebt.Text = "0";
            }
            else
            {
                label24.Visible = true;
                txtUnDebt.Visible = true;
                txtUnDebt.Text = "0";
            }
        }
    }
}