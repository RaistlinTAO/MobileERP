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
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmPrivatePay : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();

        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();

        public frmPrivatePay(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;

            if (txtName.Text == "" || txtCash.Text == "" || cmbPayType.SelectedIndex == -1) return;


            if (!Regex.IsMatch(txtCash.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmPrivatePay_cmdAdd_Click_请正确填写金额_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            cmdAdd.Enabled = false;

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n私人支出项目:" + txtName.Text + "\r\n支出时间:" + dtpTime.Value.Year +
                dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                dtpTime.Value.Day.ToString().PadLeft(2, '0') + "\r\n支出金额:" + txtCash.Text + "元\r\n支出类型:" +
                cmbPayType.Text + "\r\n备注:" + txtBackup.Text, Application.ProductName, MessageBoxButtons.OKCancel) ==
                DialogResult.OK)
            {
                var iPayout = new MysqlController.Payout
                                  {
                                      PayoutBackup = txtBackup.Text,
                                      PayoutName = txtName.Text,
                                      PayoutPrice = txtCash.Text,
                                      PayoutType = cmbPayType.SelectedIndex.ToString(),
                                      PayoutInCase = ckbisInCash.Checked
                                  };
                if (cmbPayType.SelectedIndex == 2)
                {
                    iPayout.PayoutPrice = "-" + iPayout.PayoutPrice;
                }

                iPayout.PayoutDate = dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                     dtpTime.Value.Day.ToString().PadLeft(2, '0');

                DelegateAddPrivatePayout dn = MysqlControl.AddPrivatePayout;

                IAsyncResult iar = dn.BeginInvoke(iPayout, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                if (iResult.isSuccess)
                {
                    MessageBox.Show(Resources.frmPayout_cmdAdd_Click_添加支出记录成功, Application.ProductName,
                                    MessageBoxButtons.OK);
                    CleanUI();
                    RefreshPayout();
                }
                else
                {
                    MessageBox.Show(Resources.frmPayout_cmdAdd_Click_ + iResult.ErrDesc, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
            cmdAdd.Enabled = true;
            isBusy.Visible = false;
        }

        private void frmPrivatePay_Load(object sender, EventArgs e)
        {
            cmbPayType.SelectedIndex = 0;
        }

        private void RefreshPayout()
        {
            isBusy.Visible = true;

            DelegateReadPrivatePayout dn = MysqlControl.ReadPrivatePayout;

            IAsyncResult iar = dn.BeginInvoke(dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                              dtpTime.Value.Day.ToString().PadLeft(2, '0'), null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.Payout[] tempPayout = dn.EndInvoke(iar);

            lsvPayout.Items.Clear();
            if (tempPayout == null) return;
            if (tempPayout.Length > 0)
            {
                for (int i = 0; i < tempPayout.Length; i++)
                {
                    if (string.IsNullOrEmpty(tempPayout[i].PayoutDate)) continue;
                    lsvPayout.Items.Add(tempPayout[i].PayoutDate);
                    lsvPayout.Items[i].SubItems.Add(tempPayout[i].PayoutName);
                    lsvPayout.Items[i].SubItems.Add(tempPayout[i].PayoutPrice);
                    /*
                         现金
信用卡
收入
                         */
                    switch (tempPayout[i].PayoutType)
                    {
                        case "0":
                            lsvPayout.Items[i].SubItems.Add("现金");
                            break;
                        case "1":
                            lsvPayout.Items[i].SubItems.Add("信用卡");
                            break;
                        case "2":
                            lsvPayout.Items[i].SubItems.Add("收入");
                            break;
                    }

                    lsvPayout.Items[i].SubItems.Add(tempPayout[i].PayoutBackup);
                    lsvPayout.Items[i].SubItems.Add(tempPayout[i].PayoutID.ToString());
                    lsvPayout.Items[i].SubItems.Add(tempPayout[i].PayoutInCase ? "是" : "否");
                    Application.DoEvents();
                }
            }
            isBusy.Visible = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            cmdDelete.Enabled = false;
            try
            {
                int tempID = int.Parse(lsvPayout.SelectedItems[0].SubItems[5].Text);

                DelegateDeletePrivatePayout dn = MysqlControl.DeletePrivatePayout;

                IAsyncResult iar = dn.BeginInvoke(tempID, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                if (iResult.isSuccess)
                {
                    MessageBox.Show(Resources.frmPayout_cmdDelete_Click_删除支出记录成功_, Application.ProductName,
                                    MessageBoxButtons.OK);
                    RefreshPayout();
                }
                else
                {
                    MessageBox.Show(Resources.frmPayout_cmdDelete_Click_ + iResult.ErrDesc, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                cmdDelete.Enabled = true;
                return;
            }
            cmdDelete.Enabled = true;
            isBusy.Visible = false;
        }

        private void CleanUI()
        {
            txtName.Text = "";
            txtBackup.Text = "";
            txtCash.Text = Resources.frmPrivatePay_CleanUI__0;
            cmbPayType.SelectedIndex = 0;
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            RefreshPayout();
        }

        private void frmPrivatePay_Shown(object sender, EventArgs e)
        {
            RefreshPayout();
        }

        #region Nested type: DelegateAddPrivatePayout

        private delegate MysqlController.ReturnResult DelegateAddPrivatePayout(MysqlController.Payout iPayout);

        #endregion

        #region Nested type: DelegateDeletePrivatePayout

        private delegate MysqlController.ReturnResult DelegateDeletePrivatePayout(int id);

        #endregion

        #region Nested type: DelegateReadPrivatePayout

        private delegate MysqlController.Payout[] DelegateReadPrivatePayout(string reqDate);

        #endregion
    }
}