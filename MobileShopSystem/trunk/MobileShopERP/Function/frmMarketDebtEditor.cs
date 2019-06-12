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

    public partial class frmMarketDebtEditor : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        public MysqlController.LXMarketDebt iMarketDebt;

        public frmMarketDebtEditor(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtCash.Text == "" || !Regex.IsMatch(txtCash.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmMarketDebt_cmdAdd_Click_请填写正确的市场欠款金额_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtMaster.Text == "")
            {
                MessageBox.Show(Resources.frmMarketDebt_cmdAdd_Click_请填写正确的市场欠款债权人_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show(Resources.frmMarketDebt_cmdAdd_Click_请填写正确的市场欠款事项_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n欠款事项:" + txtName.Text + "\r\n欠款时间:" + dtpTime.Value.Year +
                dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                dtpTime.Value.Day.ToString().PadLeft(2, '0') + "\r\n欠款金额:" + txtCash.Text + "元\r\n经办人:" +
                cmbSellers.Text + "\r\n备注:" + txtBackup.Text, Application.ProductName, MessageBoxButtons.OKCancel) ==
                DialogResult.OK)
            {
                iMarketDebt.DebtDate =
                    dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                    dtpTime.Value.Day.ToString().PadLeft(2, '0');
                iMarketDebt.DebtMaster = txtMaster.Text;
                iMarketDebt.DebtDetail = txtName.Text;
                iMarketDebt.DebtPrice = double.Parse(txtCash.Text);
                iMarketDebt.DebtSeller = cmbSellers.Text;
                iMarketDebt.DebtBackup = txtBackup.Text;
                iMarketDebt.DebtFixDate =
                    dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                    dtpTime.Value.Day.ToString().PadLeft(2, '0');


                if (rbisDebt.Checked)
                {
                    iMarketDebt.DebtisFix = false;
                }
                else
                {
                    iMarketDebt.DebtisFix = true;
                    iMarketDebt.DebtFixDate = dtpAddFixDate.Value.Year +
                                              dtpAddFixDate.Value.Month.ToString().PadLeft(2, '0') +
                                              dtpAddFixDate.Value.Day.ToString().PadLeft(2, '0');
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void frmMarketDebtEditor_Load(object sender, EventArgs e)
        {
            cmbSellers.Items.Clear();
        }

        private void rbisFix_CheckedChanged(object sender, EventArgs e)
        {
            dtpAddFixDate.Enabled = rbisFix.Checked;
        }

        private void frmMarketDebtEditor_Shown(object sender, EventArgs e)
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

            dtpTime.Value = new DateTime(int.Parse(iMarketDebt.DebtDate.Substring(0, 4)),
                                         int.Parse(iMarketDebt.DebtDate.Substring(4, 2)),
                                         int.Parse(iMarketDebt.DebtDate.Substring(6, 2)));
            txtMaster.Text = iMarketDebt.DebtMaster;
            txtName.Text = iMarketDebt.DebtDetail;
            txtCash.Text = iMarketDebt.DebtPrice.ToString();
            cmbSellers.Text = iMarketDebt.DebtSeller;
            txtBackup.Text = iMarketDebt.DebtBackup;
            dtpAddFixDate.Value = new DateTime(int.Parse(iMarketDebt.DebtFixDate.Substring(0, 4)),
                                               int.Parse(iMarketDebt.DebtFixDate.Substring(4, 2)),
                                               int.Parse(iMarketDebt.DebtFixDate.Substring(6, 2)));
            rbisDebt.Checked = !iMarketDebt.DebtisFix;
            isBusy.Visible = false;
        }

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion
    }
}