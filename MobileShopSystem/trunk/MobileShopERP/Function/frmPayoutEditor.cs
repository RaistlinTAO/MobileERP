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

    public partial class frmPayoutEditor : Form
    {
        public MysqlController.Payout iPayout;

        public frmPayoutEditor()
        {
            InitializeComponent();
        }

        private void frmPayoutEditor_Load(object sender, EventArgs e)
        {
            dtpTime.Value = new DateTime(int.Parse(iPayout.PayoutDate.Substring(0, 4)),
                                         int.Parse(iPayout.PayoutDate.Substring(4, 2)),
                                         int.Parse(iPayout.PayoutDate.Substring(6, 2)));
            txtName.Text = iPayout.PayoutName;
            txtCash.Text = iPayout.PayoutPrice;
            cmbPayType.SelectedIndex = int.Parse(iPayout.PayoutType);
            txtBackup.Text = iPayout.PayoutBackup;
            ckbisInCash.Checked = iPayout.PayoutInCase;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCash.Text == "" || cmbPayType.SelectedIndex == -1) return;


            if (!Regex.IsMatch(txtCash.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmPayout_cmdAdd_Click_请正确填写金额_, Application.ProductName, MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n支出项目:" + txtName.Text + "\r\n支出时间:" + dtpTime.Value.Year +
                dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                dtpTime.Value.Day.ToString().PadLeft(2, '0') + "\r\n支出金额:" + txtCash.Text + "元\r\n支出类型:" +
                cmbPayType.Text + "\r\n备注:" + txtBackup.Text, Application.ProductName, MessageBoxButtons.OKCancel) ==
                DialogResult.OK)
            {
                iPayout.PayoutBackup = txtBackup.Text;
                iPayout.PayoutName = txtName.Text;
                iPayout.PayoutPrice = txtCash.Text;
                iPayout.PayoutType = cmbPayType.SelectedIndex.ToString();
                iPayout.PayoutInCase = ckbisInCash.Checked;
                /*
                if (cmbPayType.SelectedIndex == 2)
                {
                    iPayout.PayoutPrice = "-" + iPayout.PayoutPrice;
                }
                */
                //考虑到如果是负值 在这里可能会出现两个负号
                iPayout.PayoutDate = dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                     dtpTime.Value.Day.ToString().PadLeft(2, '0');
                DialogResult = DialogResult.OK;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}