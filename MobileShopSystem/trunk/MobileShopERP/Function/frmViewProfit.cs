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
    using System.Windows.Forms;
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    #region

    #endregion

    public partial class frmViewProfit : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();

        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();

        public frmViewProfit(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            cmdSearch.Enabled = false;
            dtpFromTime.Enabled = false;
            RefreshPayout(dtpFromTime.Value.Year + dtpFromTime.Value.Month.ToString().PadLeft(2, '0') +
                          dtpFromTime.Value.Day.ToString().PadLeft(2, '0'));
            cmdSearch.Enabled = true;
            dtpFromTime.Enabled = true;
        }

        private void RefreshPayout(string DataString)
        {
            isBusy.Visible = true;
            DelegateReadPayout dn = MysqlControl.ReadPayout;

            IAsyncResult iar = dn.BeginInvoke(DataString, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.Payout[] tempPayout = dn.EndInvoke(iar);

            lsvPayout.Items.Clear();
            if (tempPayout == null) return;
            if (tempPayout.Length <= 0) return;
            double MergeInt = 0;
            for (int i = 0; i < tempPayout.Length; i++)
            {
                if (string.IsNullOrEmpty(tempPayout[i].PayoutDate)) continue;
                lsvPayout.Items.Add(tempPayout[i].PayoutDate);
                lsvPayout.Items[i].SubItems.Add(tempPayout[i].PayoutName);
                lsvPayout.Items[i].SubItems.Add(tempPayout[i].PayoutPrice);
                MergeInt = Math.Round(MergeInt + double.Parse(tempPayout[i].PayoutPrice));
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
                    case "3":
                        lsvPayout.Items[i].SubItems.Add("工资");
                        break;
                }

                lsvPayout.Items[i].SubItems.Add(tempPayout[i].PayoutBackup);
                lsvPayout.Items[i].SubItems.Add(tempPayout[i].PayoutID.ToString());

                lsvPayout.Items[i].SubItems.Add(tempPayout[i].PayoutInCase ? "是" : "否");

                Application.DoEvents();
            }
            txtMerge.Text = MergeInt + "元";
            isBusy.Visible = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            cmdDelete.Enabled = false;
            try
            {
                int tempID = int.Parse(lsvPayout.SelectedItems[0].SubItems[5].Text);

                DelegateDeletePayout dn = MysqlControl.DeletePayout;

                IAsyncResult iar = dn.BeginInvoke(tempID, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                if (iResult.isSuccess)
                {
                    MessageBox.Show(Resources.frmViewProfit_cmdDelete_Click_删除支出记录成功_, Application.ProductName,
                                    MessageBoxButtons.OK);
                    RefreshPayout(dtpFromTime.Value.Year + dtpFromTime.Value.Month.ToString().PadLeft(2, '0') +
                                  dtpFromTime.Value.Day.ToString().PadLeft(2, '0'));
                }
                else
                {
                    MessageBox.Show(Resources.frmViewProfit_cmdDelete_Click_ + iResult.ErrDesc, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                isBusy.Visible = false;
                cmdDelete.Enabled = true;

                return;
            }
            isBusy.Visible = false;
            cmdDelete.Enabled = true;
        }

        private void cmdMonthSearch_Click(object sender, EventArgs e)
        {
            cmdMonthSearch.Enabled = false;
            RefreshPayout(dtpFromTime.Value.Year + dtpFromTime.Value.Month.ToString().PadLeft(2, '0'));
            cmdMonthSearch.Enabled = true;
        }

        #region Nested type: DelegateDeletePayout

        private delegate MysqlController.ReturnResult DelegateDeletePayout(int id);

        #endregion

        #region Nested type: DelegateReadPayout

        private delegate MysqlController.Payout[] DelegateReadPayout(string reqDate);

        #endregion
    }
}