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

    public partial class frmBinPhonesEditor : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();

        public MysqlController.RefundPhone iRefundPhone;

        public frmBinPhonesEditor(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmBinPhonesEditor_Load(object sender, EventArgs e)
        {
            cmbSellers.Items.Clear();
        }

        private void frmBinPhonesEditor_Shown(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            DelegateSellers dn = MysqlControl.Sellers;

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
                    cmbSellers.Items.Add(Tempstr[i]);
                }
            }
            cmbSellers.SelectedIndex = 0;

            dtpTime.Value = new DateTime(int.Parse(iRefundPhone.RefundDate.Substring(0, 4)),
                                         int.Parse(iRefundPhone.RefundDate.Substring(4, 2)),
                                         int.Parse(iRefundPhone.RefundDate.Substring(6, 2)));
            txtName.Text = iRefundPhone.RefundName;
            txtIMEI.Text = iRefundPhone.RefundIMEI;
            txtCash.Text = iRefundPhone.RefundPrice.ToString();
            txtRepairPrice.Text = iRefundPhone.RefundRepairPrice.ToString();
            txtBackup.Text = iRefundPhone.RefundBackup;
            cmbSellers.Text = iRefundPhone.RefundSeller;
            cmbBinType.SelectedIndex = iRefundPhone.RefundRefundType;
            isBusy.Visible = false;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtCash.Text == "" || !Regex.IsMatch(txtCash.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmBinPhone_cmdAdd_Click_请填写正确的手机收取价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRepairPrice.Text == "" || !Regex.IsMatch(txtRepairPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmBinPhone_cmdAdd_Click_请填写正确的手机维修价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show(Resources.frmBinPhone_cmdAdd_Click_请填写正确的手机名称_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtIMEI.Text == "")
            {
                MessageBox.Show(Resources.frmBinPhone_cmdAdd_Click_请填写正确的手机IMEI_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n收取手机:" + txtName.Text + "\r\n收取时间:" + dtpTime.Value.Year +
                dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                dtpTime.Value.Day.ToString().PadLeft(2, '0') + "\r\n收取金额:" + txtCash.Text + "元\r\n维修金额:" +
                txtRepairPrice.Text + "元\r\n手机串号:" + txtIMEI.Text + "\r\n经办人:" + cmbSellers.Text + "\r\n备注:" +
                txtBackup.Text, Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                iRefundPhone.RefundBackup = txtBackup.Text;
                iRefundPhone.RefundDate = dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                          dtpTime.Value.Day.ToString().PadLeft(2, '0');
                //iRefundPhone.RefundFixCommision = 0;
                //iRefundPhone.RefundFixPrice = 0;
                //iRefundPhone.RefundFixProfit = 0;
                iRefundPhone.RefundIMEI = txtIMEI.Text;
                //iRefundPhone.RefundIsFix = false;
                iRefundPhone.RefundName = txtName.Text;
                iRefundPhone.RefundPrice = double.Parse(txtCash.Text);
                iRefundPhone.RefundRepairPrice = double.Parse(txtRepairPrice.Text);
                iRefundPhone.RefundSeller = cmbSellers.Text;
                iRefundPhone.RefundRefundType = cmbBinType.SelectedIndex;
                DialogResult = DialogResult.OK;
            }
        }

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion
    }
}