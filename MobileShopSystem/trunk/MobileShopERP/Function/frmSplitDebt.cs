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

namespace MobileShopERP.Function
{
    #region

    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    #region

    #endregion

    public partial class frmSplitDebt : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        public MysqlController.LXCustomDebt iDebt;
        public string iLastFixDate;
        public String iUnFixPrice;
        public bool isHaveChange;

        public frmSplitDebt(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void frmSplitDebt_Load(object sender, EventArgs e)
        {
            lblID.Text = iDebt.DebtID.ToString();
            lblDebtDate.Text = iDebt.DebtDate;
            lblDebtCustom.Text = iDebt.DebtCustom;
            lblDebtDetail.Text = iDebt.DebtDetail;
            lblPrice.Text = iDebt.DebtPrice + Resources.frmSplitDebt_frmSplitDebt_Load_元;
            switch (iDebt.DebtType)
            {
                case 0:
                    lblDebtType.Text = Resources.frmSplitDebt_frmSplitDebt_Load_信用卡;
                    break;
                case 1:
                    lblDebtType.Text = Resources.frmSplitDebt_frmSplitDebt_Load_欠款;
                    break;
            }
            cmbSplitType.SelectedIndex = 0;
        }

        private void RefreshSplitDebt()
        {
            lsvSplit.Items.Clear();

            isBusy.Visible = true;

            var iSplitDebt = new MysqlController.LXSplitDebt[50];

            DelegateReadSplitDebt dn = MysqlControl.ReadSplitDebt;

            IAsyncResult iar = dn.BeginInvoke(int.Parse(lblID.Text), null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            iSplitDebt = dn.EndInvoke(iar);

            isBusy.Visible = false;

            if (iSplitDebt != null)
            {
                if (iSplitDebt.Length > 0)
                {
                    double SplitAllPrice = 0;
                    for (int i = 0; i < iSplitDebt.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(iSplitDebt[i].SplitDebtDate))
                        {
                            lsvSplit.Items.Add(iSplitDebt[i].SplitID.ToString());
                            lsvSplit.Items[i].SubItems.Add(iSplitDebt[i].SplitDebtDate);
                            iLastFixDate = iSplitDebt[i].SplitDebtDate;
                            lsvSplit.Items[i].SubItems.Add(iSplitDebt[i].SplitDebtPrice.ToString());
                            lsvSplit.Items[i].SubItems.Add(iSplitDebt[i].SplitDebtBackup);
                            switch (iSplitDebt[i].SplitDebtType)
                            {
                                case 0:
                                    lsvSplit.Items[i].SubItems.Add("转帐还款");
                                    break;
                                case 1:
                                    lsvSplit.Items[i].SubItems.Add("现金还款");
                                    break;
                                case 2:
                                    lsvSplit.Items[i].SubItems.Add("支付宝还款");
                                    break;
                            }
                            SplitAllPrice = SplitAllPrice + iSplitDebt[i].SplitDebtPrice;
                        }
                    }
                    iUnFixPrice =
                        (double.Parse(lblPrice.Text.Replace(Resources.frmSplitDebt_frmSplitDebt_Load_元, "")) -
                         SplitAllPrice).ToString();
                    if (double.Parse(iUnFixPrice) < 0)
                    {
                        button1.Enabled = false;
                        lblUnPrice.Text = Resources.frmSplitDebt_RefreshSplitDebt_金额错误;
                        MessageBox.Show(Resources.frmSplitDebt_RefreshSplitDebt_分期付款的金额超出总额_请检查录入__确认键将在修改成正确金额后恢复_,
                                        Application.ProductName, MessageBoxButtons.OK);
                    }
                    else
                    {
                        button1.Enabled = true;
                        lblUnPrice.Text = iUnFixPrice;
                    }
                }
            }
            else
            {
                MessageBox.Show(Resources.frmSplitDebt_RefreshSplitDebt_读取分期付款数据失败_);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (isHaveChange)
            {
                return;
            }
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            cmdDelete.Enabled = false;

            try
            {
                isBusy.Visible = true;
                int tempID = int.Parse(lsvSplit.SelectedItems[0].Text);
                DelegateDeleteSplitDebt dn = MysqlControl.DeleteSplitDebt;

                IAsyncResult iar = dn.BeginInvoke(tempID, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);
                isBusy.Visible = false;
                if (iResult.isSuccess)
                {
                    MessageBox.Show(Resources.frmSplitDebt_cmdDelete_Click_删除用户分期付款成功_, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(Resources.frmSplitDebt_cmdDelete_Click_删除用户分期付款失败__错误原因_ + iResult.ErrDesc,
                                    Application.ProductName, MessageBoxButtons.OK);
                }
                RefreshSplitDebt();
            }
            catch (Exception)
            {
                cmdDelete.Enabled = true;
                return;
            }
            isHaveChange = true;
            cmdDelete.Enabled = true;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            cmdAdd.Enabled = false;

            if (txtSplitPrice.Text == "" || !Regex.IsMatch(txtSplitPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmCustomDebt_cmdAdd_Click_请填写正确的客户欠款金额_, Application.ProductName,
                                MessageBoxButtons.OK);
                cmdAdd.Enabled = true;
                return;
            }

            if (MessageBox.Show(
                Resources.frmSplitDebt_cmdAdd_Click_ + Resources.frmSplitDebt_cmdAdd_Click_还款日期_ +
                dtpSplitDate.Value.Year +
                dtpSplitDate.Value.Month.ToString().PadLeft(2, '0') +
                dtpSplitDate.Value.Day.ToString().PadLeft(2, '0') + Resources.frmSplitDebt_cmdAdd_Click_ +
                txtSplitPrice.Text + Resources.frmSplitDebt_cmdAdd_Click_ +
                txtBackup.Text, Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var iSplitDebt = new MysqlController.LXSplitDebt();
                iSplitDebt.SplitDebtID = int.Parse(lblID.Text);
                iSplitDebt.SplitDebtType = cmbSplitType.SelectedIndex;
                iSplitDebt.SplitDebtPrice = double.Parse(txtSplitPrice.Text);
                iSplitDebt.SplitDebtBackup = txtBackup.Text;
                iSplitDebt.SplitDebtDate = dtpSplitDate.Value.Year + dtpSplitDate.Value.Month.ToString().PadLeft(2, '0') +
                                           dtpSplitDate.Value.Day.ToString().PadLeft(2, '0');
                isBusy.Visible = true;
                DelegateAddSplitDebt dn = MysqlControl.AddSplitDebt;

                IAsyncResult iar = dn.BeginInvoke(iSplitDebt, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                isBusy.Visible = false;
                if (iResult.isSuccess)
                {
                    MessageBox.Show(Resources.frmSplitDebt_cmdAdd_Click_增加用户分期付款成功_, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(Resources.frmSplitDebt_cmdAdd_Click_增加用户分期付款失败__错误原因_ + iResult.ErrDesc,
                                    Application.ProductName, MessageBoxButtons.OK);
                }
                RefreshSplitDebt();
            }
            cmdAdd.Enabled = true;
            isHaveChange = true;
        }

        private void frmSplitDebt_Shown(object sender, EventArgs e)
        {
            RefreshSplitDebt();
            isHaveChange = false;
        }

        #region Nested type: DelegateAddSplitDebt

        private delegate MysqlController.ReturnResult DelegateAddSplitDebt(MysqlController.LXSplitDebt iCustomDebt);

        #endregion

        #region Nested type: DelegateDeleteSplitDebt

        private delegate MysqlController.ReturnResult DelegateDeleteSplitDebt(int Debtid);

        #endregion

        #region Nested type: DelegateReadSplitDebt

        private delegate MysqlController.LXSplitDebt[] DelegateReadSplitDebt(int SplitDebtID);

        #endregion
    }
}