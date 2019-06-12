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
    using System.Windows.Forms;
    using DataControler.Log;
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmDailyEquip : Form
    {
        private readonly clsLog LogControl = new clsLog();
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        private string[] tempSellers;

        public frmDailyEquip(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void cmdViewDaily_Click(object sender, EventArgs e)
        {
            cmdViewDaily.Enabled = false;
            RefreshCustom(dtpDaily.Value.Year + dtpDaily.Value.Month.ToString().PadLeft(2, '0') +
                          dtpDaily.Value.Day.ToString().PadLeft(2, '0'));
            cmdViewDaily.Enabled = true;
        }

        private void cmdViewMonth_Click(object sender, EventArgs e)
        {
            cmdViewMonth.Enabled = false;
            RefreshCustom(dtpDaily.Value.Year + dtpDaily.Value.Month.ToString().PadLeft(2, '0'));
            cmdViewMonth.Enabled = true;
        }

        private void RefreshCustom(string DataString)
        {
            isBusy.Visible = true;
            DelegateReadSoldEquip dn = MysqlControl.ReadSoldEquip;

            IAsyncResult iar = dn.BeginInvoke(DataString, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.LXEquip[] tempPayout = dn.EndInvoke(iar);

            lsvEquips.Items.Clear();
            if (tempPayout == null) return;
            if (tempPayout.Length <= 0) return;
            for (int i = 0; i < tempPayout.Length; i++)
            {
                if (string.IsNullOrEmpty(tempPayout[i].EquipDate)) continue;
                lsvEquips.Items.Add(tempPayout[i].EquipID.ToString());
                lsvEquips.Items[i].SubItems.Add(tempPayout[i].EquipDate);
                lsvEquips.Items[i].SubItems.Add(tempPayout[i].EquipName);
                lsvEquips.Items[i].SubItems.Add(tempPayout[i].EquipPrice.ToString());
                lsvEquips.Items[i].SubItems.Add(tempPayout[i].EquipRealPrice.ToString());
                lsvEquips.Items[i].SubItems.Add(tempPayout[i].EquipSupplier);
                lsvEquips.Items[i].SubItems.Add(tempPayout[i].EquipBackup);
                lsvEquips.Items[i].SubItems.Add(tempPayout[i].EquipSellers);
                lsvEquips.Items[i].SubItems.Add(tempPayout[i].EquipProfit.ToString());
                lsvEquips.Items[i].SubItems.Add(tempPayout[i].EquipCommision.ToString());
                Application.DoEvents();
            }
            isBusy.Visible = false;
        }

        private void frmDailyEquip_Shown(object sender, EventArgs e)
        {
            isBusy.Visible = true;

            DelegateSellers dn = MysqlControl.Sellers;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempSellers = dn.EndInvoke(iar);

            isBusy.Visible = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            cmdDelete.Enabled = false;
            try
            {
                int tempID = int.Parse(lsvEquips.SelectedItems[0].Text);

                DelegateDeleteSellEquip dn = MysqlControl.DeleteSellEquip;

                IAsyncResult iar = dn.BeginInvoke(tempID, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                if (iResult.isSuccess)
                {
                    var iDResult = new MysqlController.ReturnResult {isSuccess = false};
                    while (!iDResult.isSuccess)
                    {
                        DelegateDeleteCustomDebtByEquipID dn1 = MysqlControl.DeleteCustomDebtByEquipID;

                        IAsyncResult iar1 = dn1.BeginInvoke(tempID, null, null);

                        while (iar1.IsCompleted == false)
                        {
                            Application.DoEvents();
                        }

                        iDResult = dn1.EndInvoke(iar1);
                    }

                    var iLog = new clsLog.LogPart();

                    iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                   DateTime.Now.Day.ToString().PadLeft(2, '0');
                    iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                    iLog.LogUser = "ERP OWNER";
                    iLog.LogDetail = @"删除配件销售记录编号:" + tempID;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    MessageBox.Show(Resources.frmEquipSell_cmdDelete_Click_删除指定配件销售记录成功_, Application.ProductName,
                                    MessageBoxButtons.OK);
                    RefreshCustom(dtpDaily.Value.Year + dtpDaily.Value.Month.ToString().PadLeft(2, '0') +
                                  dtpDaily.Value.Day.ToString().PadLeft(2, '0'));
                }
                else
                {
                    MessageBox.Show(Resources.frmEquipSell_cmdDelete_Click_删除指定配件销售记录失败__错误原因_ + iResult.ErrDesc,
                                    Application.ProductName,
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

        #region Nested type: DelegateAddLog

        private delegate bool DelegateAddLog(clsLog.LogPart iLog);

        #endregion

        #region Nested type: DelegateDeleteCustomDebtByEquipID

        private delegate MysqlController.ReturnResult DelegateDeleteCustomDebtByEquipID(int EquipID);

        #endregion

        #region Nested type: DelegateDeleteSellEquip

        private delegate MysqlController.ReturnResult DelegateDeleteSellEquip(int Debtid);

        #endregion

        #region Nested type: DelegateReadSoldEquip

        private delegate MysqlController.LXEquip[] DelegateReadSoldEquip(string reqDate);

        #endregion

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion
    }
}