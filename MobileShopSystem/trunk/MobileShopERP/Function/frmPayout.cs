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

    public partial class frmPayout : Form
    {
        private readonly clsLog LogControl = new clsLog();
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string iLoginUser;
        private readonly bool iPayin;
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        //private int iPayoutType;

        public frmPayout(ToolStripStatusLabel iBusy, string LoginUser, bool isPayin)
        {
            iLoginUser = LoginUser;
            isBusy = iBusy;
            iPayin = isPayin;
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;

            if (txtName.Text == "" || txtCash.Text == "" || cmbPayType.SelectedIndex == -1) return;


            if (!Regex.IsMatch(txtCash.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmPayout_cmdAdd_Click_请正确填写金额_, Application.ProductName, MessageBoxButtons.OK);
                return;
            }

            cmdAdd.Enabled = false;

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n支出项目:" + txtName.Text + "\r\n支出时间:" + dtpTime.Value.Year +
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

                DelegateAddPayout dn = MysqlControl.AddPayout;

                IAsyncResult iar = dn.BeginInvoke(iPayout, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                if (iResult.isSuccess)
                {
                    isBusy.Visible = true;
                    var iLog = new clsLog.LogPart();

                    iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                   DateTime.Now.Day.ToString().PadLeft(2, '0');
                    iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                    iLog.LogUser = iLoginUser;
                    iLog.LogDetail = @"添加固定支出:" + txtName.Text + "支出时间:" + dtpTime.Value.Year +
                                     dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                     dtpTime.Value.Day.ToString().PadLeft(2, '0') + "支出金额:" + txtCash.Text;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    isBusy.Visible = false;

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
            isBusy.Visible = false;
            cmdAdd.Enabled = true;
        }

        private void frmPayout_Load(object sender, EventArgs e)
        {
            cmbPayType.SelectedIndex = 0;
            if (iPayin)
            {
                cmbPayType.SelectedIndex = 2;
                cmbPayType.Enabled = false;
            }
            else
            {
                cmbPayType.Enabled = true;
            }
        }

        private void RefreshPayout()
        {
            isBusy.Visible = true;

            DelegateReadPayout dn = MysqlControl.ReadPayout;

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
                    //if ((cmbPayType.SelectedIndex == 2 && tempPayout[i].PayoutType == "2") || cmbPayType.SelectedIndex!=2)
                    //{

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
            cmdDelete.Enabled = false;
            isBusy.Visible = true;
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
                    isBusy.Visible = true;
                    var iLog = new clsLog.LogPart();

                    iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                   DateTime.Now.Day.ToString().PadLeft(2, '0');
                    iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                    iLog.LogUser = iLoginUser;
                    iLog.LogDetail = @"删除固定支出 编号为:" + tempID;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    isBusy.Visible = false;
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
                isBusy.Visible = false;
                cmdDelete.Enabled = true;
                return;
            }
            isBusy.Visible = false;
            cmdDelete.Enabled = true;
        }

        private void CleanUI()
        {
            txtName.Text = "";
            txtBackup.Text = "";
            txtCash.Text = Resources.frmPayout_CleanUI__0;
            cmbPayType.SelectedIndex = 0;
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            RefreshPayout();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            try
            {
                cmdEdit.Enabled = false;

                int tempID = int.Parse(lsvPayout.SelectedItems[0].SubItems[5].Text);
                if (tempID.ToString() != "")
                {
                    var iAdd = new frmPayoutEditor {Location = lsvPayout.Location};

                    Point p = PointToScreen(lsvPayout.Location);

                    DelegateReadPayoutByID dn = MysqlControl.ReadPayoutByID;

                    IAsyncResult iar = dn.BeginInvoke(tempID.ToString(), null, null);

                    while (iar.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    iAdd.iPayout = dn.EndInvoke(iar);

                    iAdd.SetDesktopBounds(p.X + groupBox2.Location.X + groupBox3.Location.X,
                                          p.Y + groupBox2.Location.Y + groupBox3.Location.Y, iAdd.Width,
                                          iAdd.Height);
                    if (iAdd.ShowDialog() == DialogResult.OK)
                    {
                        DelegateEditPayout dnep = MysqlControl.EditPayout;

                        IAsyncResult iarep = dnep.BeginInvoke(iAdd.iPayout, null, null);

                        while (iarep.IsCompleted == false)
                        {
                            Application.DoEvents();
                        }

                        MysqlController.ReturnResult iResult = dnep.EndInvoke(iarep);

                        if (iResult.isSuccess)
                        {
                            isBusy.Visible = true;
                            var iLog = new clsLog.LogPart();

                            iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                           DateTime.Now.Day.ToString().PadLeft(2, '0');
                            iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                            iLog.LogUser = iLoginUser;
                            iLog.LogDetail = @"修改固定支出 编号为:" + tempID;

                            DelegateAddLog dnlog = LogControl.AddLog;

                            IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                            while (iarlog.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            dnlog.EndInvoke(iarlog);

                            isBusy.Visible = false;

                            MessageBox.Show("修改固定支出成功!", Application.ProductName, MessageBoxButtons.OK);
                            RefreshPayout();
                        }
                        else
                        {
                            MessageBox.Show("修改固定支出失败!错误原因" + iResult.ErrDesc, Application.ProductName,
                                            MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch (Exception)
            {
                isBusy.Visible = false;
                cmdEdit.Enabled = true;
                return;
            }
            isBusy.Visible = false;
            cmdEdit.Enabled = true;
        }

        private void frmPayout_Shown(object sender, EventArgs e)
        {
            RefreshPayout();
        }

        #region Nested type: DelegateAddLog

        private delegate bool DelegateAddLog(clsLog.LogPart iLog);

        #endregion

        #region Nested type: DelegateAddPayout

        private delegate MysqlController.ReturnResult DelegateAddPayout(MysqlController.Payout iPayout);

        #endregion

        #region Nested type: DelegateDeletePayout

        private delegate MysqlController.ReturnResult DelegateDeletePayout(int id);

        #endregion

        #region Nested type: DelegateEditPayout

        private delegate MysqlController.ReturnResult DelegateEditPayout(MysqlController.Payout iPayout);

        #endregion

        #region Nested type: DelegateReadPayout

        private delegate MysqlController.Payout[] DelegateReadPayout(string reqDate);

        #endregion

        #region Nested type: DelegateReadPayoutByID

        private delegate MysqlController.Payout DelegateReadPayoutByID(string iID);

        #endregion
    }
}