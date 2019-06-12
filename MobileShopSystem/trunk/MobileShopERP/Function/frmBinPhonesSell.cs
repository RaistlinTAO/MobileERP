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
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Log;
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmBinPhonesSell : Form
    {
        private readonly clsLog LogControl = new clsLog();
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string iLoginUser;
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        private int iSaveType;
        private bool iSaveisSold;
        private string iSavestrDate;
        //private string LoginUser;

        public frmBinPhonesSell(ToolStripStatusLabel iBusy, string LoginUser)
        {
            iLoginUser = LoginUser;
            isBusy = iBusy;
            InitializeComponent();
        }

        private void cmdViewMonth_Click(object sender, EventArgs e)
        {
            cmdViewMonth.Enabled = false;
            RefreshPayout(0, dtpView.Value.Year + dtpView.Value.Month.ToString().PadLeft(2, '0'), false);
            cmdViewMonth.Enabled = true;
        }

        private void cmdUnSold_Click(object sender, EventArgs e)
        {
            cmdUnSold.Enabled = false;
            RefreshPayout(1, dtpView.Value.Year + dtpView.Value.Month.ToString().PadLeft(2, '0'), false);
            cmdUnSold.Enabled = true;
        }

        private void cmdIsSold_Click(object sender, EventArgs e)
        {
            cmdIsSold.Enabled = false;
            RefreshPayout(1, dtpView.Value.Year + dtpView.Value.Month.ToString().PadLeft(2, '0'), true);
            cmdIsSold.Enabled = true;
        }

        private void RefreshPayout(int iType, string strDate, bool isSold)
        {
            iSaveType = iType;
            iSavestrDate = strDate;
            iSaveisSold = isSold;
            isBusy.Visible = true;
            var tempPayout = new MysqlController.RefundPhone[1000];
            switch (iType)
            {
                case 0:
                    DelegateReadRefundPhoneS dn = MysqlControl.ReadRefundPhone;

                    IAsyncResult iar = dn.BeginInvoke(strDate, null, null);

                    while (iar.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    tempPayout = dn.EndInvoke(iar);

                    break;
                case 1:

                    DelegateReadRefundPhoneB dn1 = MysqlControl.ReadRefundPhone;

                    IAsyncResult iar1 = dn1.BeginInvoke(strDate, isSold, null, null);

                    while (iar1.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    tempPayout = dn1.EndInvoke(iar1);

                    break;
            }
            isBusy.Visible = false;
            lsvPhones.Items.Clear();

            if (tempPayout == null) return;
            if (tempPayout.Length <= 0) return;
            isBusy.Visible = true;
            for (int i = 0; i < tempPayout.Length; i++)
            {
                if (string.IsNullOrEmpty(tempPayout[i].RefundDate)) continue;
                lsvPhones.Items.Add(tempPayout[i].RefundID.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPayout[i].RefundDate);
                lsvPhones.Items[i].SubItems.Add(tempPayout[i].RefundName);
                lsvPhones.Items[i].SubItems.Add(tempPayout[i].RefundPrice.ToString());
                lsvPhones.Items[i].SubItems.Add(tempPayout[i].RefundSeller);
                lsvPhones.Items[i].SubItems.Add(tempPayout[i].RefundIMEI);
                lsvPhones.Items[i].SubItems.Add(tempPayout[i].RefundBackup);
                lsvPhones.Items[i].SubItems.Add(tempPayout[i].RefundRepairPrice.ToString());

                if (tempPayout[i].RefundIsFix)
                {
                    lsvPhones.Items[i].SubItems.Add(Resources.frmBinPhone_ckbisSold_CheckedChanged_已出售);
                    lsvPhones.Items[i].SubItems.Add(tempPayout[i].RefundFixDate);
                    lsvPhones.Items[i].SubItems.Add(tempPayout[i].RefundFixPrice.ToString());
                    switch (tempPayout[i].RefundRefundType)
                    {
                        case 0:
                            lsvPhones.Items[i].SubItems.Add("现金收取");
                            break;
                        case 1:
                            lsvPhones.Items[i].SubItems.Add("刷卡收取");
                            break;
                        case 2:
                            lsvPhones.Items[i].SubItems.Add("支付宝收取");
                            break;
                    }
                    switch (tempPayout[i].RefundFixType)
                    {
                        case 0:
                            lsvPhones.Items[i].SubItems.Add("现金购买");
                            break;
                        case 1:
                            lsvPhones.Items[i].SubItems.Add("转帐购买");
                            break;
                        case 2:
                            lsvPhones.Items[i].SubItems.Add("欠款购买");
                            break;
                        case 3:
                            lsvPhones.Items[i].SubItems.Add("支付宝购买");
                            break;
                    }
                    lsvPhones.Items[i].SubItems.Add(tempPayout[i].RefundFixSeller);
                }
                else
                {
                    lsvPhones.Items[i].SubItems.Add(Resources.frmBinPhone_ckbisSold_CheckedChanged_未出售);
                    lsvPhones.Items[i].SubItems.Add("N/A");
                    lsvPhones.Items[i].SubItems.Add("N/A");
                    switch (tempPayout[i].RefundRefundType)
                    {
                        case 0:
                            lsvPhones.Items[i].SubItems.Add("现金收取");
                            break;
                        case 1:
                            lsvPhones.Items[i].SubItems.Add("刷卡收取");
                            break;
                        case 2:
                            lsvPhones.Items[i].SubItems.Add("支付宝收取");
                            break;
                    }
                    lsvPhones.Items[i].SubItems.Add("N/A");
                    lsvPhones.Items[i].SubItems.Add("N/A");
                }


                Application.DoEvents();
            }
            isBusy.Visible = false;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                cmdEdit.Enabled = false;
                string tempID = lsvPhones.SelectedItems[0].Text;
                if (tempID != "" && lsvPhones.SelectedItems[8].Text != "已销售")
                {
                    var iAdd = new frmBinPhonesEditor(isBusy) {Location = lsvPhones.Location};

                    Point p = PointToScreen(lsvPhones.Location);
                    isBusy.Visible = true;
                    DelegateReadRefundPhoneByID dnr = MysqlControl.ReadRefundPhoneByID;

                    IAsyncResult iarr = dnr.BeginInvoke(tempID, null, null);

                    while (iarr.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    iAdd.iRefundPhone = dnr.EndInvoke(iarr);
                    isBusy.Visible = false;
                    iAdd.SetDesktopBounds(p.X + groupBox2.Location.X + groupBox1.Location.X,
                                          p.Y + groupBox2.Location.Y + groupBox1.Location.Y, iAdd.Width,
                                          iAdd.Height);
                    if (iAdd.ShowDialog() == DialogResult.OK)
                    {
                        isBusy.Visible = true;
                        DelegateEditRefundPhone dn = MysqlControl.EditRefundPhone;

                        IAsyncResult iar = dn.BeginInvoke(iAdd.iRefundPhone, null, null);

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
                            iLog.LogDetail = @"修改用户返收手机,编号为:" + tempID;

                            DelegateAddLog dnlog = LogControl.AddLog;

                            IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                            while (iarlog.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            dnlog.EndInvoke(iarlog);

                            isBusy.Visible = false;

                            MessageBox.Show("修改回收手机记录成功!", Application.ProductName, MessageBoxButtons.OK);
                            RefreshPayout(iSaveType, iSavestrDate, iSaveisSold);
                        }
                        else
                        {
                            MessageBox.Show("修改回收手机记录失败!错误原因" + iResult.ErrDesc, Application.ProductName,
                                            MessageBoxButtons.OK);
                        }
                        isBusy.Visible = false;
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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            cmdDelete.Enabled = false;
            isBusy.Visible = true;
            try
            {
                int iPhone = int.Parse(lsvPhones.SelectedItems[0].Text);

                DelegateDeleteRefundPhone dn = MysqlControl.DeleteRefundPhone;

                IAsyncResult iar = dn.BeginInvoke(iPhone, null, null);

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
                    iLog.LogDetail = @"删除用户手机返收 编号为:" + iPhone;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    isBusy.Visible = false;

                    MessageBox.Show(Resources.frmBinPhone_cmdDelete_Click_删除二手机回收完成_已成功添加_,
                                    Application.ProductName, MessageBoxButtons.OK);
                    //CleanUI();
                    RefreshPayout(iSaveType, iSavestrDate, iSaveisSold);
                }
                else
                {
                    MessageBox.Show(Resources.frmBinPhone_cmdDelete_Click_删除二手机回收失败_失败原因_ + iResult.ErrDesc,
                                    Application.ProductName, MessageBoxButtons.OK);
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

        private void ckbisSold_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbisSold.Checked)
            {
                try
                {
                    lsvPhones.SelectedItems[0].SubItems[8].Text = Resources.frmBinPhone_ckbisSold_CheckedChanged_已出售;
                    lsvPhones.SelectedItems[0].SubItems[9].Text = dtpFixDate.Value.Year +
                                                                  dtpFixDate.Value.Month.ToString().PadLeft(2, '0') +
                                                                  dtpFixDate.Value.Day.ToString().PadLeft(2, '0');
                    lsvPhones.SelectedItems[0].SubItems[10].Text = txtFixPrice.Text;
                    dtpFixDate.Enabled = true;
                    txtFixPrice.Enabled = true;
                    cmbSellType.Enabled = true;
                    txtFixPrice.Enabled = true;
                    cmbSellers.Enabled = true;
                }
                catch (Exception)
                {
                    return;
                }
            }
            else
            {
                try
                {
                    lsvPhones.SelectedItems[0].SubItems[8].Text = Resources.frmBinPhone_ckbisSold_CheckedChanged_未出售;
                    lsvPhones.SelectedItems[0].SubItems[9].Text = "";
                    lsvPhones.SelectedItems[0].SubItems[10].Text = Resources.frmBinPhone_ckbisSold_CheckedChanged__0;
                    txtFixPrice.Text = Resources.frmBinPhone_ckbisSold_CheckedChanged__0;
                    txtFixPrice.Enabled = false;
                    dtpFixDate.Enabled = false;
                    cmbSellType.Enabled = false;
                    txtFixPrice.Enabled = false;
                    cmbSellers.Enabled = false;
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            cmdUpdate.Enabled = false;
            isBusy.Visible = true;
            try
            {
                int RefundID = int.Parse(lsvPhones.SelectedItems[0].Text);
                double RefundFixPrice = 0;
                try
                {
                    RefundFixPrice = double.Parse(lsvPhones.SelectedItems[0].SubItems[10].Text);
                }
                catch (Exception)
                {
                    RefundFixPrice = 0;
                }
                string FixDate = "";
                if (ckbisSold.Checked)
                {
                    FixDate = dtpFixDate.Value.Year +
                              dtpFixDate.Value.Month.ToString().PadLeft(2, '0') +
                              dtpFixDate.Value.Day.ToString().PadLeft(2, '0');
                }
                else
                {
                    RefundFixPrice = 0;
                    FixDate = "";
                }


                DelegateFixRefundPhone dn = MysqlControl.FixRefundPhone;

                IAsyncResult iar = dn.BeginInvoke(ckbisSold.Checked, FixDate, RefundFixPrice,
                                                  RefundID, cmbSellType.SelectedIndex, cmbSellers.Text, null,
                                                  null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                if (iResult.isSuccess)
                {
                    isBusy.Visible = true;

                    if (cmbSellType.SelectedIndex != 0)
                    {
                        var iCustomDebt = new MysqlController.LXCustomDebt
                                              {
                                                  DebtCustom = txtUserName.Text,
                                                  DebtType = cmbSellType.SelectedIndex - 1,
                                                  DebtDate =
                                                      dtpFixDate.Value.Year +
                                                      dtpFixDate.Value.Month.ToString().PadLeft(2, '0') +
                                                      dtpFixDate.Value.ToString().PadLeft(2, '0'),
                                                  DebtDetail = "购买二手机:" + txtUserName.Text,
                                                  DebtisFix = false,
                                                  DebtBinID = RefundID,
                                                  DebtPrice =
                                                      Math.Round(
                                                          double.Parse(txtFixPrice.Text) - double.Parse(txtUnDebt.Text),
                                                          2),
                                                  DebtFixDate =
                                                      DateTime.Now.Year +
                                                      DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                                      DateTime.Now.Day.ToString().PadLeft(2, '0'),
                                                  DebtisInCircle = true
                                              };
                        var iDResult = new MysqlController.ReturnResult {isSuccess = false};
                        while (!iDResult.isSuccess)
                        {
                            DelegateAddCustomDebt dn1 = MysqlControl.AddCustomDebt;

                            IAsyncResult iar1 = dn1.BeginInvoke(iCustomDebt, null, null);

                            while (iar1.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            iDResult = dn1.EndInvoke(iar1);
                        }
                    }

                    var iLog = new clsLog.LogPart();

                    iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                   DateTime.Now.Day.ToString().PadLeft(2, '0');
                    iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                    iLog.LogUser = iLoginUser;
                    iLog.LogDetail = @"更新用户手机返收记录 编号为" + RefundID;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    isBusy.Visible = false;

                    MessageBox.Show(
                        Resources.frmBinPhone_cmdUpdate_Click_修改二手机回收完成_已成功更改_ +
                        lsvPhones.SelectedItems[0].SubItems[2].Text,
                        Application.ProductName, MessageBoxButtons.OK);
                    //CleanUI();
                    RefreshPayout(iSaveType, iSavestrDate, iSaveisSold);
                }
                else
                {
                    MessageBox.Show(Resources.frmBinPhone_cmdUpdate_Click_修改二手机回收失败_失败原因_ + iResult.ErrDesc,
                                    Application.ProductName, MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                isBusy.Visible = false;
                cmdUpdate.Enabled = true;
                return;
            }
            isBusy.Visible = false;
            cmdUpdate.Enabled = true;
        }

        private void txtFixPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lsvPhones.SelectedItems[0].SubItems[10].Text = txtFixPrice.Text;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void dtpFixDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lsvPhones.SelectedItems[0].SubItems[9].Text = dtpFixDate.Value.Year +
                                                              dtpFixDate.Value.Month.ToString().PadLeft(2, '0') +
                                                              dtpFixDate.Value.Day.ToString().PadLeft(2, '0');
            }
            catch (Exception)
            {
                return;
            }
        }

        private void frmBinPhonesSell_Load(object sender, EventArgs e)
        {
            //cmbBinType.SelectedIndex = 0;
            cmbSellers.Items.Clear();
            cmdIndieSeller1.Items.Clear();
            cmdIndieSeller2.Items.Clear();
            cmdIndieSelltype.SelectedIndex = 0;
            cmbSellType.SelectedIndex = 0;
        }

        private void frmBinPhonesSell_Shown(object sender, EventArgs e)
        {
            isBusy.Visible = true;

            DelegateSellers dn = MysqlControl.Sellers;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            string[] Tempstr = dn.EndInvoke(iar);

            isBusy.Visible = false;

            for (int i = 0; i < Tempstr.Length; i++)
            {
                if (Tempstr[i] != null && Tempstr[i] != "")
                {
                    cmbSellers.Items.Add(Tempstr[i]);
                    cmdIndieSeller1.Items.Add(Tempstr[i]);
                    cmdIndieSeller2.Items.Add(Tempstr[i]);
                }
            }
            cmbSellers.SelectedIndex = 0;
            cmdIndieSeller1.SelectedIndex = 0;
            cmdIndieSeller2.SelectedIndex = 0;
            //RefreshPayout(0, dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
            //dtpTime.Value.Day.ToString().PadLeft(2, '0'), false);
        }

        private void cmbSellType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSellType.SelectedIndex == 0)
            {
                label2.Visible = false;
                txtUnDebt.Visible = false;
                txtUnDebt.Text = "0.0";
            }
            else
            {
                label2.Visible = true;
                txtUnDebt.Visible = true;
                txtUnDebt.Text = "0.0";
            }
        }

        private void cmdIndieSelltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSellType.SelectedIndex == 0)
            {
                label13.Visible = false;
                txtIndieUnDebt.Visible = false;
                txtIndieUnDebt.Text = "0.0";
            }
            else
            {
                label13.Visible = true;
                txtIndieUnDebt.Visible = true;
                txtIndieUnDebt.Text = "0.0";
            }
        }

        private void CleanUI()
        {
            txtName.Text = "";
            txtBackup.Text = "";
            txtCash.Text = Resources.frmBinPhone_ckbisSold_CheckedChanged__0;
            txtIMEI.Text = "";
            txtIndieUserName.Text = "";
            txtIndieFixPrice.Text = Resources.frmBinPhone_ckbisSold_CheckedChanged__0;
            cmdIndieSelltype.SelectedIndex = 0;
            txtIndieUnDebt.Text = Resources.frmBinPhone_ckbisSold_CheckedChanged__0;
            txtRepairPrice.Text = Resources.frmBinPhone_ckbisSold_CheckedChanged__0;
            //ckbisSold.Checked = false;
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

            if (txtIndieFixPrice.Text == "" || !Regex.IsMatch(txtIndieFixPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show("请填写正确的手机销售价格", Application.ProductName,
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

            cmdAdd.Enabled = false;

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n收取手机:" + txtName.Text + "\r\n收取时间:" + dtpTime.Value.Year +
                dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                dtpTime.Value.Day.ToString().PadLeft(2, '0') + "\r\n收取金额:" + txtCash.Text + "元\r\n维修金额:" +
                txtRepairPrice.Text + "元\r\n手机串号:" + txtIMEI.Text + "\r\n经办人:" + cmbSellers.Text + "\r\n备注:" +
                txtBackup.Text, Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var iPhone = new MysqlController.RefundPhone
                                 {
                                     RefundBackup = txtBackup.Text,
                                     RefundDate = dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                                  dtpTime.Value.Day.ToString().PadLeft(2, '0'),
                                     RefundIMEI = txtIMEI.Text,
                                     RefundName = txtName.Text,
                                     RefundPrice = double.Parse(txtCash.Text),
                                     RefundRepairPrice = double.Parse(txtRepairPrice.Text),
                                     RefundSeller = cmdIndieSeller1.Text,
                                     RefundRefundType = cmbBinType.SelectedIndex,
                                     RefundIsFix = true,
                                     RefundFixCommision = 0,
                                     RefundFixPrice = double.Parse(txtIndieFixPrice.Text),
                                     RefundFixProfit = 0,
                                     RefundFixDate =
                                         dtpIndieFixDate.Value.Year +
                                         dtpIndieFixDate.Value.Month.ToString().PadLeft(2, '0') +
                                         dtpIndieFixDate.Value.Day.ToString().PadLeft(2, '0'),
                                     RefundFixType = cmdIndieSelltype.SelectedIndex,
                                     RefundFixSeller = cmdIndieSeller2.Text
                                 };
                isBusy.Visible = true;
                DelegateAddRefundPhone dn = MysqlControl.AddIndieRefundPhone;

                IAsyncResult iar = dn.BeginInvoke(iPhone, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);
                isBusy.Visible = false;
                if (iResult.isSuccess)
                {
                    isBusy.Visible = true;

                    if (cmbSellType.SelectedIndex != 0)
                    {
                        var iCustomDebt = new MysqlController.LXCustomDebt
                                              {
                                                  DebtCustom = txtUserName.Text,
                                                  DebtType = cmbSellType.SelectedIndex - 1,
                                                  DebtDate =
                                                      dtpFixDate.Value.Year +
                                                      dtpFixDate.Value.Month.ToString().PadLeft(2, '0') +
                                                      dtpFixDate.Value.ToString().PadLeft(2, '0'),
                                                  DebtDetail = "购买二手机:" + txtUserName.Text,
                                                  DebtisFix = false,
                                                  DebtBinID = 0,
                                                  DebtPrice =
                                                      Math.Round(
                                                          double.Parse(txtFixPrice.Text) - double.Parse(txtUnDebt.Text),
                                                          2),
                                                  DebtFixDate =
                                                      DateTime.Now.Year +
                                                      DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                                      DateTime.Now.Day.ToString().PadLeft(2, '0'),
                                                  DebtisInCircle = true
                                              };
                        var iDResult = new MysqlController.ReturnResult {isSuccess = false};
                        while (!iDResult.isSuccess)
                        {
                            DelegateAddCustomDebt dn1 = MysqlControl.AddCustomDebt;

                            IAsyncResult iar1 = dn1.BeginInvoke(iCustomDebt, null, null);

                            while (iar1.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            iDResult = dn1.EndInvoke(iar1);
                        }
                    }
                    var iLog = new clsLog.LogPart();

                    iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                   DateTime.Now.Day.ToString().PadLeft(2, '0');
                    iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                    iLog.LogUser = iLoginUser;
                    iLog.LogDetail = @"添加用户手机返收:" + txtName.Text + "收取时间:" + dtpTime.Value.Year +
                                     dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                     dtpTime.Value.Day.ToString().PadLeft(2, '0') + "收取金额:" + txtCash.Text + "元";

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    isBusy.Visible = false;

                    MessageBox.Show(Resources.frmBinPhone_cmdAdd_Click_添加二手机回收完成_已成功添加_ + txtName.Text,
                                    Application.ProductName, MessageBoxButtons.OK);
                    CleanUI();
                    RefreshPayout(0, dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                     dtpTime.Value.Day.ToString().PadLeft(2, '0'), false);
                }
                else
                {
                    MessageBox.Show(Resources.frmBinPhone_cmdAdd_Click_添加二手机回收失败_失败原因_ + iResult.ErrDesc,
                                    Application.ProductName, MessageBoxButtons.OK);
                }
            }
            cmdAdd.Enabled = true;
        }

        #region Nested type: DelegateAddCustomDebt

        private delegate MysqlController.ReturnResult DelegateAddCustomDebt(MysqlController.LXCustomDebt iCustomDebt);

        #endregion

        #region Nested type: DelegateAddLog

        private delegate bool DelegateAddLog(clsLog.LogPart iLog);

        #endregion

        #region Nested type: DelegateAddRefundPhone

        private delegate MysqlController.ReturnResult DelegateAddRefundPhone(MysqlController.RefundPhone iRefundPhone);

        #endregion

        #region Nested type: DelegateDeleteRefundPhone

        private delegate MysqlController.ReturnResult DelegateDeleteRefundPhone(int RefundID);

        #endregion

        #region Nested type: DelegateEditRefundPhone

        private delegate MysqlController.ReturnResult DelegateEditRefundPhone(MysqlController.RefundPhone iRefundPhone);

        #endregion

        #region Nested type: DelegateFixRefundPhone

        private delegate MysqlController.ReturnResult DelegateFixRefundPhone(
            bool isFix, string FixDate, double FixPrice, int RefundID, int FixType, string FixSeller);

        #endregion

        #region Nested type: DelegateReadRefundPhoneB

        private delegate MysqlController.RefundPhone[] DelegateReadRefundPhoneB(string reqDate, bool reqFix);

        #endregion

        #region Nested type: DelegateReadRefundPhoneByID

        private delegate MysqlController.RefundPhone DelegateReadRefundPhoneByID(string iID);

        #endregion

        #region Nested type: DelegateReadRefundPhoneS

        private delegate MysqlController.RefundPhone[] DelegateReadRefundPhoneS(string reqDate);

        #endregion

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion
    }
}