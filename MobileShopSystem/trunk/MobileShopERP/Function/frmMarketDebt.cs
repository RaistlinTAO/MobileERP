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

    public partial class frmMarketDebt : Form
    {
        private readonly clsLog LogControl = new clsLog();
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string iLoginUser;
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        private string iSavestrDate;
        private bool isSearchFix;

        public frmMarketDebt(ToolStripStatusLabel iBusy, string LoginUser)
        {
            iLoginUser = LoginUser;
            isBusy = iBusy;
            InitializeComponent();
        }

        public void MarketDebtInOut(bool iOut)
        {
            isSearchFix = iOut;
            if (iOut)
            {
                rbisDebt.Checked = true;
                rbisFix.Checked = false;
            }
            else
            {
                rbisDebt.Checked = false;
                rbisFix.Checked = true;
            }
            rbisDebt.Enabled = false;
            rbisFix.Enabled = false;
        }

        private void frmMarketDebt_Load(object sender, EventArgs e)
        {
            cmbSellers.Items.Clear();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
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

            cmdAdd.Enabled = false;
            isBusy.Visible = true;

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n欠款事项:" + txtName.Text + "\r\n欠款时间:" + dtpTime.Value.Year +
                dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                dtpTime.Value.Day.ToString().PadLeft(2, '0') + "\r\n欠款金额:" + txtCash.Text + "元\r\n经办人:" +
                cmbSellers.Text + "\r\n备注:" + txtBackup.Text, Application.ProductName, MessageBoxButtons.OKCancel) ==
                DialogResult.OK)
            {
                var iMarketDebt = new MysqlController.LXMarketDebt
                                      {
                                          DebtDate =
                                              dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                              dtpTime.Value.Day.ToString().PadLeft(2, '0'),
                                          DebtMaster = txtMaster.Text,
                                          DebtDetail = txtName.Text,
                                          DebtPrice = double.Parse(txtCash.Text),
                                          DebtSeller = cmbSellers.Text,
                                          DebtBackup = txtBackup.Text,
                                          DebtisCashCircle = ckbInCircle.Checked,
                                          DebtFixDate =
                                              dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                              dtpTime.Value.Day.ToString().PadLeft(2, '0')
                                      };

                if (rbisDebt.Checked)
                {
                    iMarketDebt.DebtisFix = false;
                    //iMarketDebt.DebtFixDate = dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                    //                          dtpTime.Value.Day.ToString().PadLeft(2, '0');
                }
                else
                {
                    iMarketDebt.DebtisFix = true;
                    iMarketDebt.DebtFixDate = dtpAddFixDate.Value.Year +
                                              dtpAddFixDate.Value.Month.ToString().PadLeft(2, '0') +
                                              dtpAddFixDate.Value.Day.ToString().PadLeft(2, '0');
                }

                DelegateAddMarketDebt dn = MysqlControl.AddMarketDebt;

                IAsyncResult iar = dn.BeginInvoke(iMarketDebt, null, null);

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
                    iLog.LogDetail = @"添加市场欠款:" + txtName.Text + "欠款时间:" + dtpTime.Value.Year +
                                     dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                     dtpTime.Value.Day.ToString().PadLeft(2, '0') + "欠款金额:" + txtCash.Text;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    isBusy.Visible = false;

                    MessageBox.Show(Resources.frmMarketDebt_cmdAdd_Click_添加市场欠款成功_, Application.ProductName,
                                    MessageBoxButtons.OK);
                    CleanUI();
                    RefreshMarketDebt(dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                      dtpTime.Value.Day.ToString().PadLeft(2, '0'));
                }
                else
                {
                    MessageBox.Show(Resources.frmMarketDebt_cmdAdd_Click_添加市场欠款失败__错误原因_ + iResult.ErrDesc,
                                    Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
            cmdAdd.Enabled = true;
            isBusy.Visible = false;
        }

        private void CleanUI()
        {
            txtMaster.Text = "";
            txtName.Text = "";
            txtCash.Text = Resources.frmMarketDebt_CleanUI__0;
            txtBackup.Text = "";
            rbisFix.Checked = true;
        }

        private void RefreshMarketDebt(string DataString)
        {
            iSavestrDate = DataString;

            isBusy.Visible = true;

            DelegateReadMarketDebt dn = MysqlControl.ReadMarketDebt;

            IAsyncResult iar = dn.BeginInvoke(DataString, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.LXMarketDebt[] tempPayout = dn.EndInvoke(iar);

            lsvMarketDebt.Items.Clear();
            if (tempPayout == null) return;
            if (tempPayout.Length <= 0) return;
            for (int i = 0; i < tempPayout.Length; i++)
            {
                if (string.IsNullOrEmpty(tempPayout[i].DebtDate)) continue;

                if (isSearchFix)
                {
                    if (!tempPayout[i].DebtisFix)
                    {
                        lsvMarketDebt.Items.Add(tempPayout[i].DebtID.ToString());
                        lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtDate);
                        lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtMaster);
                        lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtDetail);
                        lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtPrice.ToString());
                        lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtSeller);
                        lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtBackup);
                        if (tempPayout[i].DebtisFix)
                        {
                            lsvMarketDebt.Items[i].SubItems.Add("已结款");
                            lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtFixDate);
                            lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtisCashCircle ? "否" : "是");
                        }
                        else
                        {
                            lsvMarketDebt.Items[i].SubItems.Add("未结款");
                            lsvMarketDebt.Items[i].SubItems.Add("N/A");
                            lsvMarketDebt.Items[i].SubItems.Add("N/A");
                        }
                    }
                }
                else
                {
                    lsvMarketDebt.Items.Add(tempPayout[i].DebtID.ToString());
                    lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtDate);
                    lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtMaster);
                    lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtDetail);
                    lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtPrice.ToString());
                    lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtSeller);
                    lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtBackup);
                    if (tempPayout[i].DebtisFix)
                    {
                        lsvMarketDebt.Items[i].SubItems.Add("已结款");
                        lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtFixDate);
                        lsvMarketDebt.Items[i].SubItems.Add(tempPayout[i].DebtisCashCircle ? "否" : "是");
                    }
                    else
                    {
                        lsvMarketDebt.Items[i].SubItems.Add("未结款");
                        lsvMarketDebt.Items[i].SubItems.Add("N/A");
                        lsvMarketDebt.Items[i].SubItems.Add("N/A");
                    }
                }


                Application.DoEvents();
            }
            isBusy.Visible = false;
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            cmdView.Enabled = false;
            RefreshMarketDebt(dtpViewTime.Value.Year + dtpViewTime.Value.Month.ToString().PadLeft(2, '0') +
                              dtpViewTime.Value.Day.ToString().PadLeft(2, '0'));
            cmdView.Enabled = true;
        }

        private void cmdViewMonth_Click(object sender, EventArgs e)
        {
            cmdViewMonth.Enabled = false;
            RefreshMarketDebt(dtpViewTime.Value.Year + dtpViewTime.Value.Month.ToString().PadLeft(2, '0'));
            cmdViewMonth.Enabled = true;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            cmdDelete.Enabled = false;
            try
            {
                int tempID = int.Parse(lsvMarketDebt.SelectedItems[0].Text);

                DelegateDeleteMarketDebt dn = MysqlControl.DeleteMarketDebt;

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
                    iLog.LogDetail = @"删除市场欠款 编号为:" + tempID;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    isBusy.Visible = false;

                    MessageBox.Show(Resources.frmMarketDebt_cmdDelete_Click_删除指定的市场欠款成功, Application.ProductName,
                                    MessageBoxButtons.OK);
                    RefreshMarketDebt(iSavestrDate);
                }
                else
                {
                    MessageBox.Show(Resources.frmMarketDebt_cmdDelete_Click_删除指定的市场欠款失败_失败原因_ + iResult.ErrDesc,
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

        private void cmdFix_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            cmdFix.Enabled = false;
            try
            {
                int tempID = int.Parse(lsvMarketDebt.SelectedItems[0].Text);

                DelegateFixMarketDebt dn = MysqlControl.FixMarketDebt;

                IAsyncResult iar = dn.BeginInvoke(tempID.ToString(),
                                                  dtpFixDate.Value.Year +
                                                  dtpFixDate.Value.Month.ToString().
                                                      PadLeft(2, '0') +
                                                  dtpFixDate.Value.Day.ToString().
                                                      PadLeft(2, '0'), null, null);

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
                    iLog.LogDetail = @"更新市场欠款 编号为:" + tempID;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    isBusy.Visible = false;

                    MessageBox.Show(Resources.frmMarketDebt_cmdFix_Click_指定的市场结款成功_, Application.ProductName,
                                    MessageBoxButtons.OK);
                    RefreshMarketDebt(iSavestrDate);
                }
                else
                {
                    MessageBox.Show(Resources.frmMarketDebt_cmdFix_Click_指定的市场结款失败_失败原因_ + iResult.ErrDesc,
                                    Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                cmdFix.Enabled = true;
                return;
            }
            cmdFix.Enabled = true;
            isBusy.Visible = false;
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            RefreshMarketDebt(dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                              dtpTime.Value.Day.ToString().PadLeft(2, '0'));
        }

        private void rbisFix_CheckedChanged(object sender, EventArgs e)
        {
            dtpAddFixDate.Enabled = rbisFix.Checked;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            cmdEdit.Enabled = false;
            try
            {
                int tempID = int.Parse(lsvMarketDebt.SelectedItems[0].Text);
                if (tempID.ToString() != "")
                {
                    var iAdd = new frmMarketDebtEditor(isBusy) {Location = lsvMarketDebt.Location};

                    Point p = PointToScreen(lsvMarketDebt.Location);

                    iAdd.SetDesktopBounds(p.X + groupBox2.Location.X + groupBox4.Location.X,
                                          p.Y + groupBox2.Location.Y + groupBox4.Location.Y, iAdd.Width,
                                          iAdd.Height);

                    DelegateReadMarketDebtByID dn1 = MysqlControl.ReadMarketDebtByID;

                    IAsyncResult iar1 = dn1.BeginInvoke(tempID.ToString(), null, null);

                    while (iar1.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    iAdd.iMarketDebt = dn1.EndInvoke(iar1);

                    if (iAdd.ShowDialog() == DialogResult.OK)
                    {
                        DelegateEditMarketDebt dn = MysqlControl.EditMarketDebt;

                        IAsyncResult iar = dn.BeginInvoke(iAdd.iMarketDebt, null, null);

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
                            iLog.LogDetail = @"修改市场欠款 编号为:" + tempID;

                            DelegateAddLog dnlog = LogControl.AddLog;

                            IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                            while (iarlog.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            dnlog.EndInvoke(iarlog);

                            isBusy.Visible = false;

                            MessageBox.Show("修改市场欠款成功!", Application.ProductName, MessageBoxButtons.OK);
                            RefreshMarketDebt(iSavestrDate);
                        }
                        else
                        {
                            MessageBox.Show("修改市场欠款失败!错误原因" + iResult.ErrDesc, Application.ProductName,
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

        private void frmMarketDebt_Shown(object sender, EventArgs e)
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
            isBusy.Visible = false;
        }

        #region Nested type: DelegateAddLog

        private delegate bool DelegateAddLog(clsLog.LogPart iLog);

        #endregion

        #region Nested type: DelegateAddMarketDebt

        private delegate MysqlController.ReturnResult DelegateAddMarketDebt(MysqlController.LXMarketDebt iMarketDebt);

        #endregion

        #region Nested type: DelegateDeleteMarketDebt

        private delegate MysqlController.ReturnResult DelegateDeleteMarketDebt(int Debtid);

        #endregion

        #region Nested type: DelegateEditMarketDebt

        private delegate MysqlController.ReturnResult DelegateEditMarketDebt(MysqlController.LXMarketDebt iDebt);

        #endregion

        #region Nested type: DelegateFixMarketDebt

        private delegate MysqlController.ReturnResult DelegateFixMarketDebt(string DebtID, string FixDate);

        #endregion

        #region Nested type: DelegateReadMarketDebt

        private delegate MysqlController.LXMarketDebt[] DelegateReadMarketDebt(string reqDate);

        #endregion

        #region Nested type: DelegateReadMarketDebtByID

        private delegate MysqlController.LXMarketDebt DelegateReadMarketDebtByID(string iID);

        #endregion

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion
    }
}