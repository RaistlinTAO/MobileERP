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
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Log;
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmCustomDebt : Form
    {
        private readonly clsLog LogControl = new clsLog();
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string iLoginUser;
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        private string iSavestrDate;

        private int iViewType;

        public frmCustomDebt(ToolStripStatusLabel iBusy, string LoginUser)
        {
            iLoginUser = LoginUser;
            isBusy = iBusy;
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            cmdSearch.Enabled = false;
            iViewType = 0;
            RefreshCustom(dtpFromTime.Value.Year + dtpFromTime.Value.Month.ToString().PadLeft(2, '0') +
                          dtpFromTime.Value.Day.ToString().PadLeft(2, '0'), false);
            cmdSearch.Enabled = true;
        }

        private void cmdMonthSearch_Click(object sender, EventArgs e)
        {
            cmdMonthSearch.Enabled = false;
            iViewType = 1;
            RefreshCustom(dtpFromTime.Value.Year + dtpFromTime.Value.Month.ToString().PadLeft(2, '0'), false);
            cmdMonthSearch.Enabled = true;
        }

        private void RefreshCustom(string DataString, bool isFix)
        {
            iSavestrDate = DataString;
            isBusy.Visible = true;
            DelegateReadCustomDebt dn = MysqlControl.ReadCustomDebt;

            IAsyncResult iar = dn.BeginInvoke(DataString, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.LXCustomDebt[] tempPayout = dn.EndInvoke(iar);

            lsvDebt.Items.Clear();
            if (tempPayout == null) return;
            if (tempPayout.Length <= 0) return;
            int j = 0;
            if (isFix)
            {
                for (int i = 0; i < tempPayout.Length; i++)
                {
                    if (string.IsNullOrEmpty(tempPayout[i].DebtDate)) continue;
                    if (tempPayout[i].DebtisFix) continue;

                    lsvDebt.Items.Add(tempPayout[i].DebtID.ToString());
                    lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtDate);
                    lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtCustom);
                    lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtDetail);
                    lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtPrice.ToString());

                    switch (tempPayout[i].DebtType)
                    {
                        case 0:
                            lsvDebt.Items[j].SubItems.Add("信用卡");
                            break;
                        case 1:
                            lsvDebt.Items[j].SubItems.Add("欠款");
                            break;
                        case 2:
                            lsvDebt.Items[j].SubItems.Add("支付宝");
                            break;
                    }

                    if (tempPayout[i].DebtisFix)
                    {
                        lsvDebt.Items[j].SubItems.Add("已到帐");
                        lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtFixDate);
                        lsvDebt.Items[j].SubItems.Add("0");
                        switch (tempPayout[i].DebtFixType)
                        {
                            case 0:
                                lsvDebt.Items[j].SubItems.Add("转帐还款");
                                break;
                            case 1:
                                lsvDebt.Items[j].SubItems.Add("现金还款");
                                break;
                            case 2:
                                lsvDebt.Items[j].SubItems.Add("支付宝还款");
                                break;
                        }
                        lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtFixBackup);
                    }
                    else
                    {
                        lsvDebt.Items[j].SubItems.Add("未到帐");
                        lsvDebt.Items[j].SubItems.Add("N/A");
                        lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtUnFixPrice.ToString());
                        lsvDebt.Items[j].SubItems.Add("N/A");
                        lsvDebt.Items[j].SubItems.Add("N/A");
                    }

                    lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtisInCircle ? "计入" : "不计入");
                    j = j + 1;
                    Application.DoEvents();
                }
            }
            else
            {
                for (int i = 0; i < tempPayout.Length; i++)
                {
                    if (string.IsNullOrEmpty(tempPayout[i].DebtDate)) continue;

                    lsvDebt.Items.Add(tempPayout[i].DebtID.ToString());
                    lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtDate);
                    lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtCustom);
                    lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtDetail);
                    lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtPrice.ToString());

                    switch (tempPayout[i].DebtType)
                    {
                        case 0:
                            lsvDebt.Items[j].SubItems.Add("信用卡");
                            break;
                        case 1:
                            lsvDebt.Items[j].SubItems.Add("欠款");
                            break;
                    }

                    if (tempPayout[i].DebtisFix)
                    {
                        lsvDebt.Items[j].SubItems.Add("已到帐");
                        lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtFixDate);
                        lsvDebt.Items[j].SubItems.Add("0");
                        switch (tempPayout[i].DebtFixType)
                        {
                            case 0:
                                lsvDebt.Items[j].SubItems.Add("转帐还款");
                                break;
                            case 1:
                                lsvDebt.Items[j].SubItems.Add("现金还款");
                                break;
                            case 2:
                                lsvDebt.Items[j].SubItems.Add("支付宝还款");
                                break;
                        }
                        lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtFixBackup);
                    }
                    else
                    {
                        lsvDebt.Items[j].SubItems.Add("未到帐");
                        lsvDebt.Items[j].SubItems.Add("N/A");
                        lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtUnFixPrice.ToString());
                        lsvDebt.Items[j].SubItems.Add("N/A");
                        lsvDebt.Items[j].SubItems.Add("N/A");
                    }
                    lsvDebt.Items[j].SubItems.Add(tempPayout[i].DebtisInCircle ? "计入" : "不计入");
                    j = j + 1;
                    Application.DoEvents();
                }
            }

            isBusy.Visible = false;
        }

        private void cmdFinish_Click(object sender, EventArgs e)
        {
            cmdFinish.Enabled = false;

            try
            {
                for (int i = 0; i < lsvDebt.SelectedItems.Count; i++)
                {
                    int tempID = int.Parse(lsvDebt.SelectedItems[i].Text);

                    isBusy.Visible = true;

                    DelegateFixCustomDebt dn = MysqlControl.FixCustomDebt;

                    IAsyncResult iar = dn.BeginInvoke(tempID.ToString(), iSavestrDate, cmbBackDebtType.SelectedIndex,
                                                      txtBackDebtBackup.Text, null, null);

                    while (iar.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    MysqlController.ReturnResult iResult = dn.EndInvoke(iar);


                    if (iResult.isSuccess)
                    {
                        var iLog = new clsLog.LogPart();

                        iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                       DateTime.Now.Day.ToString().PadLeft(2, '0');
                        iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                        iLog.LogUser = iLoginUser;
                        iLog.LogDetail = @"标记客户欠款到帐 编号为:" + tempID;

                        DelegateAddLog dnlog = LogControl.AddLog;

                        IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                        while (iarlog.IsCompleted == false)
                        {
                            Application.DoEvents();
                        }

                        dnlog.EndInvoke(iarlog);

                        MessageBox.Show(Resources.frmCustomDebt_cmdFinish_Click_修改指定欠款到帐成功_, Application.ProductName,
                                        MessageBoxButtons.OK);
                        RefreshCustom(iSavestrDate, false);
                    }
                    else
                    {
                        MessageBox.Show(Resources.frmCustomDebt_cmdFinish_Click_修改指定欠款到帐失败_, Application.ProductName,
                                        MessageBoxButtons.OK);
                    }
                    isBusy.Visible = false;
                }
            }
            catch (Exception)
            {
                cmdFinish.Enabled = true;
                return;
            }

            cmdFinish.Enabled = true;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            cmdDelete.Enabled = false;

            try
            {
                for (int i = 0; i < lsvDebt.SelectedItems.Count; i++)
                {
                    int tempID = int.Parse(lsvDebt.SelectedItems[i].Text);

                    isBusy.Visible = true;

                    DelegateDeleteCustomDebt dn = MysqlControl.DeleteCustomDebt;

                    IAsyncResult iar = dn.BeginInvoke(tempID, null, null);

                    while (iar.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                    isBusy.Visible = false;

                    if (iResult.isSuccess)
                    {
                        var iLog = new clsLog.LogPart();

                        iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                       DateTime.Now.Day.ToString().PadLeft(2, '0');
                        iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                        iLog.LogUser = iLoginUser;
                        iLog.LogDetail = @"删除客户欠款 编号为:" + tempID;

                        DelegateAddLog dnlog = LogControl.AddLog;

                        IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                        while (iarlog.IsCompleted == false)
                        {
                            Application.DoEvents();
                        }

                        dnlog.EndInvoke(iarlog);

                        MessageBox.Show(Resources.frmCustomDebt_cmdDelete_Click_删除指定欠款成功_, Application.ProductName,
                                        MessageBoxButtons.OK);
                        RefreshCustom(iSavestrDate, false);
                    }
                    else
                    {
                        MessageBox.Show(Resources.frmCustomDebt_cmdDelete_Click_删除指定欠款失败__错误原因_ + iResult.ErrDesc,
                                        Application.ProductName,
                                        MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception)
            {
                cmdDelete.Enabled = true;
                return;
            }

            cmdDelete.Enabled = true;
        }


        private void cmdConvert2Payout_Click(object sender, EventArgs e)
        {
            int tempID = int.Parse(lsvDebt.SelectedItems[0].Text);

            var iPayout = new MysqlController.Payout
                              {
                                  PayoutBackup =
                                      lsvDebt.SelectedItems[0].SubItems[1].Text + " " +
                                      lsvDebt.SelectedItems[0].SubItems[2].Text + ",欠款原因:" +
                                      lsvDebt.SelectedItems[0].SubItems[3].Text,
                                  PayoutName = "客户欠款",
                                  PayoutPrice = lsvDebt.SelectedItems[0].SubItems[4].Text,
                                  PayoutType = Resources.frmCustomDebt_CleanUI__0,
                                  PayoutDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                               DateTime.Now.Day.ToString().PadLeft(2, '0')
                              };
            isBusy.Visible = true;
            DelegateAddPayout dn = MysqlControl.AddPayout;

            IAsyncResult iar = dn.BeginInvoke(iPayout, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.ReturnResult iResult = dn.EndInvoke(iar);
            isBusy.Visible = false;
            if (iResult.isSuccess)
            {
                var iLog = new clsLog.LogPart();

                iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                               DateTime.Now.Day.ToString().PadLeft(2, '0');
                iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                iLog.LogUser = iLoginUser;
                iLog.LogDetail = @"转换客户欠款到固定支出 编号为:" + tempID;

                DelegateAddLog dnlog = LogControl.AddLog;

                IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                while (iarlog.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                dnlog.EndInvoke(iarlog);

                MessageBox.Show(Resources.frmPayout_cmdAdd_Click_添加支出记录成功, Application.ProductName, MessageBoxButtons.OK);

                MysqlController.ReturnResult iDResult;
                iDResult.isSuccess = false;
                isBusy.Visible = true;
                while (iDResult.isSuccess != true)
                {
                    DelegateDeleteCustomDebt dnd = MysqlControl.DeleteCustomDebt;

                    IAsyncResult iard = dnd.BeginInvoke(tempID, null, null);

                    while (iard.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    iDResult = dnd.EndInvoke(iard);
                }
                isBusy.Visible = false;
                RefreshCustom(iSavestrDate, false);
            }
            else
            {
                MessageBox.Show(Resources.frmPayout_cmdAdd_Click_ + iResult.ErrDesc, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            isBusy.Visible = false;
        }

        private void frmCustomDebt_Load(object sender, EventArgs e)
        {
            cmbPayment.SelectedIndex = 1;
            cmbBackDebtType.SelectedIndex = 1;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
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

            cmdAdd.Enabled = false;

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n欠款人:" + txtMaster.Text + "\r\n欠款时间:" + dtpTime.Value.Year +
                dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                dtpTime.Value.Day.ToString().PadLeft(2, '0') + "\r\n欠款金额:" + txtCash.Text + "元\r\n欠款事项:" + txtName.Text +
                "\r\n到帐方式:" + cmbPayment.Text, Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var iCustemDebt = new MysqlController.LXCustomDebt
                                      {
                                          DebtDate =
                                              dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                              dtpTime.Value.Day.ToString().PadLeft(2, '0'),
                                          DebtCustom = txtMaster.Text,
                                          DebtDetail = txtName.Text,
                                          DebtPrice = double.Parse(txtCash.Text),
                                          DebtisFix = false,
                                          DebtType = cmbPayment.SelectedIndex,
                                          DebtFixDate =
                                              dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                              dtpTime.Value.Day.ToString().PadLeft(2, '0'),
                                          DebtisInCircle = ckbinCircle.Checked
                                      };
                isBusy.Visible = true;
                DelegateAddCustomDebt dn = MysqlControl.AddCustomDebt;

                IAsyncResult iar = dn.BeginInvoke(iCustemDebt, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);
                isBusy.Visible = false;
                if (iResult.isSuccess)
                {
                    var iLog = new clsLog.LogPart();

                    iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                   DateTime.Now.Day.ToString().PadLeft(2, '0');
                    iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                    iLog.LogUser = iLoginUser;
                    iLog.LogDetail = @"增加客户欠款记录" + txtMaster + txtName + txtCash;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    MessageBox.Show(Resources.frmCustomDebt_cmdAdd_Click_添加客户欠款成功_, Application.ProductName,
                                    MessageBoxButtons.OK);
                    CleanUI();
                    RefreshCustom(dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                  dtpTime.Value.Day.ToString().PadLeft(2, '0'), false);
                }
                else
                {
                    MessageBox.Show(Resources.frmCustomDebt_cmdAdd_Click_添加客户欠款失败_失败原因_ + iResult.ErrDesc,
                                    Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
            cmdAdd.Enabled = true;
        }

        private void CleanUI()
        {
            txtMaster.Text = "";
            txtCash.Text = Resources.frmCustomDebt_CleanUI__0;
            txtName.Text = "";
            cmbPayment.SelectedIndex = 1;
        }

        private void cmdViewAll_Click(object sender, EventArgs e)
        {
            cmdViewAll.Enabled = false;
            iViewType = 2;
            RefreshCustom("20", false);
            cmdViewAll.Enabled = true;
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            RefreshCustom(dtpFromTime.Value.Year + dtpFromTime.Value.Month.ToString().PadLeft(2, '0') +
                          dtpFromTime.Value.Day.ToString().PadLeft(2, '0'), false);
        }

        //private delegate MysqlController.ReturnResult DelegateFixCustomDebt(string DebtID, string FixDate);
        private void cmdSplitFix_Click(object sender, EventArgs e)
        {
            cmdSplitFix.Enabled = false;

            try
            {
                if (lsvDebt.SelectedItems[0].SubItems[6].Text == "已到帐")
                {
                    cmdSplitFix.Enabled = true;
                    return;
                }
                int tempID = int.Parse(lsvDebt.SelectedItems[0].Text);
                var iAdd = new frmSplitDebt(isBusy) {Location = lsvDebt.Location};
                MysqlController.LXCustomDebt[] iDebt = MysqlControl.ReadCustomDebt(tempID);

                if (iDebt != null || iDebt.Length > 0)
                {
                    Point p = PointToScreen(lsvDebt.Location);

                    iAdd.SetDesktopBounds(p.X + groupBox2.Location.X + groupBox4.Location.X,
                                          p.Y + groupBox2.Location.Y + groupBox4.Location.Y, iAdd.Width,
                                          iAdd.Height);
                    iAdd.iDebt = iDebt[0];
                    if (iAdd.ShowDialog() == DialogResult.OK)
                    {
                        isBusy.Visible = true;
                        MysqlController.ReturnResult iDResult;
                        iDResult.isSuccess = false;

                        while (iDResult.isSuccess != true)
                        {
                            DelegateChangeSplitDebt dn = MysqlControl.ChangeSplitDebt;

                            IAsyncResult iar = dn.BeginInvoke(tempID.ToString(), double.Parse(iAdd.iUnFixPrice), null,
                                                              null);

                            while (iar.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            iDResult = dn.EndInvoke(iar);
                        }
                        isBusy.Visible = false;
                        if (int.Parse(iAdd.iUnFixPrice) == 0)
                        {
                            //已经没有欠款了.这里需要递交一次还款结束
                            iDResult.isSuccess = false;
                            isBusy.Visible = true;
                            while (iDResult.isSuccess != true)
                            {
                                DelegateFixCustomDebt dn = MysqlControl.FixCustomDebt;

                                IAsyncResult iar = dn.BeginInvoke(tempID.ToString(), iAdd.iLastFixDate,
                                                                  cmbBackDebtType.SelectedIndex, txtBackDebtBackup.Text,
                                                                  null, null);

                                while (iar.IsCompleted == false)
                                {
                                    Application.DoEvents();
                                }

                                iDResult = dn.EndInvoke(iar);
                            }

                            var iLog = new clsLog.LogPart();

                            iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                           DateTime.Now.Day.ToString().PadLeft(2, '0');
                            iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                            iLog.LogUser = iLoginUser;
                            iLog.LogDetail = @"修改客户欠款-分期分款记录 编号:" + tempID;

                            DelegateAddLog dnlog = LogControl.AddLog;

                            IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                            while (iarlog.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            dnlog.EndInvoke(iarlog);

                            isBusy.Visible = false;
                        }

                        switch (iViewType)
                        {
                            case 0:
                                RefreshCustom(dtpFromTime.Value.Year +
                                              dtpFromTime.Value.Month.ToString().PadLeft(2, '0') +
                                              dtpFromTime.Value.Day.ToString().PadLeft(2, '0'), false);
                                break;
                            case 1:
                                RefreshCustom(dtpFromTime.Value.Year +
                                              dtpFromTime.Value.Month.ToString().PadLeft(2, '0'), false);
                                break;
                            case 2:
                                RefreshCustom("20", false);
                                break;
                        }
                        //lsvDebt.SelectedItems[0].SubItems[8].Text = "已到帐";
                    }
                }
            }
            catch (Exception)
            {
                cmdSplitFix.Enabled = true;
                return;
            }
            cmdSplitFix.Enabled = true;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                cmdEdit.Enabled = false;
                int tempID = int.Parse(lsvDebt.SelectedItems[0].Text);
                if (tempID.ToString() != "")
                {
                    var iAdd = new frmCustomDebtEditor {Location = lsvDebt.Location};

                    Point p = PointToScreen(lsvDebt.Location);

                    iAdd.SetDesktopBounds(p.X + groupBox2.Location.X + groupBox4.Location.X,
                                          p.Y + groupBox2.Location.Y + groupBox4.Location.Y, iAdd.Width,
                                          iAdd.Height);

                    isBusy.Visible = true;

                    DelegateReadCustomDebtByID dn = MysqlControl.ReadCustomDebt;

                    IAsyncResult iar = dn.BeginInvoke(tempID, null, null);

                    while (iar.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    MysqlController.LXCustomDebt[] tempDebt = dn.EndInvoke(iar);
                    iAdd.iDebt = tempDebt[0];

                    isBusy.Visible = false;

                    if (iAdd.ShowDialog() == DialogResult.OK)
                    {
                        MysqlController.ReturnResult iResult = MysqlControl.EditCustomDebt(iAdd.iDebt);
                        if (iResult.isSuccess)
                        {
                            var iLog = new clsLog.LogPart();

                            iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                           DateTime.Now.Day.ToString().PadLeft(2, '0');
                            iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                            iLog.LogUser = iLoginUser;
                            iLog.LogDetail = @"修改客户欠款记录 编号为:" + tempID;

                            DelegateAddLog dnlog = LogControl.AddLog;

                            IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                            while (iarlog.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            dnlog.EndInvoke(iarlog);

                            MessageBox.Show("修改客户欠款成功!", Application.ProductName, MessageBoxButtons.OK);
                            RefreshCustom(iSavestrDate, false);
                        }
                        else
                        {
                            MessageBox.Show("修改客户欠款失败!错误原因" + iResult.ErrDesc, Application.ProductName,
                                            MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch (Exception)
            {
                cmdEdit.Enabled = true;
                return;
            }
            cmdEdit.Enabled = true;
        }

        private void cmdViewAllUnFix_Click(object sender, EventArgs e)
        {
            cmdViewAllUnFix.Enabled = false;
            iViewType = 2;
            RefreshCustom("20", true);
            cmdViewAllUnFix.Enabled = true;
        }

        private void cmdSearchUser_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            DelegateReadCustomDebtByName dn = MysqlControl.ReadCustomDebtByName;

            IAsyncResult iar = dn.BeginInvoke(txtUser.Text, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.LXCustomDebt[] tempPayout = dn.EndInvoke(iar);

            lsvDebt.Items.Clear();
            if (tempPayout == null) return;
            if (tempPayout.Length <= 0) return;

            for (int i = 0; i < tempPayout.Length; i++)
            {
                if (string.IsNullOrEmpty(tempPayout[i].DebtDate)) continue;

                lsvDebt.Items.Add(tempPayout[i].DebtID.ToString());
                lsvDebt.Items[i].SubItems.Add(tempPayout[i].DebtDate);
                lsvDebt.Items[i].SubItems.Add(tempPayout[i].DebtCustom);
                lsvDebt.Items[i].SubItems.Add(tempPayout[i].DebtDetail);
                lsvDebt.Items[i].SubItems.Add(tempPayout[i].DebtPrice.ToString());

                switch (tempPayout[i].DebtType)
                {
                    case 0:
                        lsvDebt.Items[i].SubItems.Add("信用卡");
                        break;
                    case 1:
                        lsvDebt.Items[i].SubItems.Add("欠款");
                        break;
                }

                if (tempPayout[i].DebtisFix)
                {
                    lsvDebt.Items[i].SubItems.Add("已到帐");
                    lsvDebt.Items[i].SubItems.Add(tempPayout[i].DebtFixDate);
                    lsvDebt.Items[i].SubItems.Add("0");
                    switch (tempPayout[i].DebtFixType)
                    {
                        case 0:
                            lsvDebt.Items[i].SubItems.Add("转帐还款");
                            break;
                        case 1:
                            lsvDebt.Items[i].SubItems.Add("现金还款");
                            break;
                        case 2:
                            lsvDebt.Items[i].SubItems.Add("支付宝还款");
                            break;
                    }
                    lsvDebt.Items[i].SubItems.Add(tempPayout[i].DebtFixBackup);
                }
                else
                {
                    lsvDebt.Items[i].SubItems.Add("未到帐");
                    lsvDebt.Items[i].SubItems.Add("N/A");
                    lsvDebt.Items[i].SubItems.Add(tempPayout[i].DebtUnFixPrice.ToString());
                    lsvDebt.Items[i].SubItems.Add("N/A");
                    lsvDebt.Items[i].SubItems.Add("N/A");
                }
                Application.DoEvents();
            }

            isBusy.Visible = false;
        }

        #region Nested type: DelegateAddCustomDebt

        private delegate MysqlController.ReturnResult DelegateAddCustomDebt(MysqlController.LXCustomDebt iCustomDebt);

        #endregion

        #region Nested type: DelegateAddLog

        private delegate bool DelegateAddLog(clsLog.LogPart iLog);

        #endregion

        #region Nested type: DelegateAddPayout

        private delegate MysqlController.ReturnResult DelegateAddPayout(MysqlController.Payout iPayout);

        #endregion

        #region Nested type: DelegateChangeSplitDebt

        private delegate MysqlController.ReturnResult DelegateChangeSplitDebt(string DebtID, double UnPrice);

        #endregion

        #region Nested type: DelegateDeleteCustomDebt

        private delegate MysqlController.ReturnResult DelegateDeleteCustomDebt(int Debtid);

        #endregion

        #region Nested type: DelegateFixCustomDebt

        private delegate MysqlController.ReturnResult DelegateFixCustomDebt(
            string DebtID, string FixDate, int FixType, string FixBackup);

        #endregion

        #region Nested type: DelegateReadCustomDebt

        private delegate MysqlController.LXCustomDebt[] DelegateReadCustomDebt(string reqDate);

        #endregion

        #region Nested type: DelegateReadCustomDebtByID

        private delegate MysqlController.LXCustomDebt[] DelegateReadCustomDebtByID(int DebtID);

        #endregion

        #region Nested type: DelegateReadCustomDebtByName

        private delegate MysqlController.LXCustomDebt[] DelegateReadCustomDebtByName(string iName);

        #endregion
    }
}