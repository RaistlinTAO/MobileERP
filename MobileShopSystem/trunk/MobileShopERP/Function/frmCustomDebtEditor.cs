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
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmCustomDebtEditor : Form
    {
        public MysqlController.LXCustomDebt iDebt;

        public frmCustomDebtEditor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtCash.Text == "" || !Regex.IsMatch(txtCash.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmCustomDebt_cmdAdd_Click_请填写正确的客户欠款金额_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            if (txtMaster.Text == "")
            {
                MessageBox.Show(Resources.frmCustomDebt_cmdAdd_Click_请填写正确的客户欠款人名称_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show(Resources.frmCustomDebt_cmdAdd_Click_请填写正确的客户欠款事项_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n欠款人:" + txtMaster.Text + "\r\n欠款时间:" + dtpTime.Value.Year +
                dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                dtpTime.Value.Day.ToString().PadLeft(2, '0') + "\r\n欠款金额:" + txtCash.Text + "元\r\n欠款事项:" + txtName.Text +
                "\r\n到帐方式:" + cmbPayment.Text, Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                iDebt.DebtDate =
                    dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                    dtpTime.Value.Day.ToString().PadLeft(2, '0');
                iDebt.DebtCustom = txtMaster.Text;
                iDebt.DebtDetail = txtName.Text;

                iDebt.DebtType = cmbPayment.SelectedIndex;
                iDebt.DebtUnFixPrice =
                    double.Parse(iDebt.DebtPrice != double.Parse(txtCash.Text) ? txtCash.Text : lblUnFixPrice.Text);
                iDebt.DebtPrice = double.Parse(txtCash.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void frmCustomDebtEditor_Load(object sender, EventArgs e)
        {
            dtpTime.Value = new DateTime(int.Parse(iDebt.DebtDate.Substring(0, 4)),
                                         int.Parse(iDebt.DebtDate.Substring(4, 2)),
                                         int.Parse(iDebt.DebtDate.Substring(6, 2)))
                ;
            txtMaster.Text = iDebt.DebtCustom;
            txtName.Text = iDebt.DebtDetail;
            txtCash.Text = iDebt.DebtPrice.ToString();
            cmbPayment.SelectedIndex = iDebt.DebtType;
            lblUnFixPrice.Text = iDebt.DebtUnFixPrice.ToString();
        }
    }
}