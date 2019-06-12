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

    public partial class frmEquipSell : Form
    {
        private readonly clsLog LogControl = new clsLog();
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string iLoginUser;
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();

        public frmEquipSell(ToolStripStatusLabel iBusy, string LoginUser)
        {
            iLoginUser = LoginUser;
            isBusy = iBusy;
            InitializeComponent();
        }

        private void frmEquipSell_Load(object sender, EventArgs e)
        {
            cmbSeller.Items.Clear();
            cmbPayment.SelectedIndex = 0;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //这里判断输入值正确性


            if (txtPrice.Text == "" || !Regex.IsMatch(txtPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmEquipSell_cmdAdd_Click_请填写正确的配件销售价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtRealPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmEquipSell_cmdAdd_Click_请填写正确的配件成本价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show(Resources.frmEquipSell_cmdAdd_Click_请填写正确的配件名称_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            cmdAdd.Enabled = false;

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n配件名目:" + txtName.Text + "\r\n销售时间:" + dtpTime.Value.Year +
                dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                dtpTime.Value.Day.ToString().PadLeft(2, '0') + "\r\n销售价格:" + txtPrice.Text + "元\r\n实际成本:" +
                txtRealPrice.Text + "元\r\n供货商:" + txtSupplier.Text + "\r\n销售人:" + cmbSeller.Text + "\r\n支付类型:" +
                cmbPayment.Text + "\r\n备注:" +
                txtBackup.Text, Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                isBusy.Visible = true;
                var tempEquip = new MysqlController.LXEquip
                                    {
                                        EquipDate =
                                            dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                            dtpTime.Value.Day.ToString().PadLeft(2, '0'),
                                        EquipBackup = txtBackup.Text,
                                        EquipName = txtName.Text,
                                        EquipPrice = double.Parse(txtPrice.Text),
                                        EquipRealPrice = double.Parse(txtRealPrice.Text),
                                        EquipSellers = cmbSeller.Text,
                                        EquipSupplier = txtSupplier.Text,
                                        EquipPayment = cmbPayment.SelectedIndex,
                                        EquipBuyer = txtEquipBuyer.Text
                                    };

                DelegateAddSellEquip dn = MysqlControl.AddSellEquip;

                IAsyncResult iar = dn.BeginInvoke(tempEquip, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                if (iResult.isSuccess)
                {
                    if (cmbPayment.SelectedIndex != 0)
                    {
                        var iCustomDebt = new MysqlController.LXCustomDebt
                                              {
                                                  DebtCustom = txtName.Text,
                                                  DebtType = cmbPayment.SelectedIndex - 1,
                                                  DebtDate =
                                                      dtpTime.Value.Year +
                                                      dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                                      dtpTime.Value.Day.ToString().PadLeft(2, '0'),
                                                  DebtDetail = "购买配件:" + txtName.Text + " 备注:" + txtBackup.Text,
                                                  DebtisFix = false,
                                                  DebtEquipID = iResult.PhoneID,
                                                  DebtPrice =
                                                      Math.Round(
                                                          double.Parse(txtPrice.Text) - double.Parse(txtUnDebt.Text), 2),
                                                  DebtFixDate =
                                                      DateTime.Now.Year +
                                                      DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                                      DateTime.Now.Day.ToString().PadLeft(2, '0'),
                                                  DebtisInCircle = true,
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
                    iLog.LogDetail = @"增加配件销售记录:" + txtName.Text + "销售时间:" + dtpTime.Value.Year +
                                     dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                     dtpTime.Value.Day.ToString().PadLeft(2, '0');

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);


                    isBusy.Visible = false;


                    MessageBox.Show(Resources.frmEquipSell_cmdAdd_Click_添加配件销售记录成功_已经成功添加 + txtName.Text,
                                    Application.ProductName, MessageBoxButtons.OK);
                    CleanUI();
                    RefreshPayout();
                }
                else
                {
                    isBusy.Visible = false;
                    MessageBox.Show(Resources.frmEquipSell_cmdAdd_Click_添加配件销售记录失败_错误原因_ + iResult.ErrDesc,
                                    Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
            isBusy.Visible = false;
            cmdAdd.Enabled = true;
        }

        private void CleanUI()
        {
            txtName.Text = "";
            txtBackup.Text = "";
            txtPrice.Text = Resources.frmEquipSell_CleanUI__0;
            txtRealPrice.Text = Resources.frmEquipSell_CleanUI__0;
            txtSupplier.Text = "";
        }

        private void RefreshPayout()
        {
            isBusy.Visible = true;

            DelegateReadSoldEquip dn = MysqlControl.ReadSoldEquip;

            IAsyncResult iar = dn.BeginInvoke(dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                                              dtpTime.Value.Day.ToString().PadLeft(2, '0'), null, null);

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
                switch (tempPayout[i].EquipPayment)
                {
                    case 0:
                        lsvEquips.Items[i].SubItems.Add("现金支付");
                        break;

                    case 1:
                        lsvEquips.Items[i].SubItems.Add("刷卡支付");
                        break;
                    case 2:
                        lsvEquips.Items[i].SubItems.Add("欠款支付");
                        break;
                    case 3:
                        lsvEquips.Items[i].SubItems.Add("支付宝");
                        break;
                }
                lsvEquips.Items[i].SubItems.Add(tempPayout[i].EquipBuyer);
                Application.DoEvents();
            }
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
                    iLog.LogUser = iLoginUser;
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
                    RefreshPayout();
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

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            RefreshPayout();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                cmdEdit.Enabled = false;
                int tempID = int.Parse(lsvEquips.SelectedItems[0].Text);
                if (tempID.ToString() != "")
                {
                    var iAdd = new frmEquipSellEditor(isBusy) {Location = lsvEquips.Location};

                    Point p = PointToScreen(lsvEquips.Location);

                    iAdd.SetDesktopBounds(p.X + groupBox2.Location.X, p.Y + groupBox2.Location.Y, iAdd.Width,
                                          iAdd.Height);

                    DelegateReadSoldEquipByID dn = MysqlControl.ReadSoldEquipByID;

                    IAsyncResult iar = dn.BeginInvoke(tempID.ToString(), null, null);

                    while (iar.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    iAdd.iEquip = dn.EndInvoke(iar);

                    if (iAdd.ShowDialog() == DialogResult.OK)
                    {
                        isBusy.Visible = true;

                        DelegateEditSoldEquip dn1 = MysqlControl.EditSoldEquip;

                        IAsyncResult iar1 = dn1.BeginInvoke(iAdd.iEquip, null, null);

                        while (iar1.IsCompleted == false)
                        {
                            Application.DoEvents();
                        }

                        MysqlController.ReturnResult iResult = dn1.EndInvoke(iar1);

                        if (iResult.isSuccess)
                        {
                            //同时修改客户欠款

                            var iLog = new clsLog.LogPart();

                            iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                           DateTime.Now.Day.ToString().PadLeft(2, '0');
                            iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                            iLog.LogUser = iLoginUser;
                            iLog.LogDetail = @"修改配件销售,编号:" + tempID;

                            DelegateAddLog dnlog = LogControl.AddLog;

                            IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                            while (iarlog.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            dnlog.EndInvoke(iarlog);
                            MessageBox.Show("修改配件销售成功!", Application.ProductName, MessageBoxButtons.OK);
                            RefreshPayout();
                        }
                        else
                        {
                            MessageBox.Show("修改配件销售失败!错误原因" + iResult.ErrDesc, Application.ProductName,
                                            MessageBoxButtons.OK);
                        }
                        isBusy.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                cmdEdit.Enabled = true;
                isBusy.Visible = false;
                return;
            }
            isBusy.Visible = false;
            cmdEdit.Enabled = true;
        }

        private void frmEquipSell_Shown(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            try
            {
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
                        cmbSeller.Items.Add(Tempstr[i]);
                    }
                }
                cmbSeller.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.frmAddPhone_frmAddPhone_Load_数据库连接失败_, Application.ProductName,
                                MessageBoxButtons.OK);
                cmdAdd.Enabled = false;
                isBusy.Visible = false;
                return;
            }
            isBusy.Visible = false;
            RefreshPayout();
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayment.SelectedIndex == 0)
            {
                label9.Visible = false;
                txtUnDebt.Visible = false;
                txtUnDebt.Text = "0.0";
            }
            else
            {
                label9.Visible = true;
                txtUnDebt.Visible = true;
                txtUnDebt.Text = "0.0";
            }
        }

        #region Nested type: DelegateAddCustomDebt

        private delegate MysqlController.ReturnResult DelegateAddCustomDebt(MysqlController.LXCustomDebt iCustomDebt);

        #endregion

        #region Nested type: DelegateAddLog

        private delegate bool DelegateAddLog(clsLog.LogPart iLog);

        #endregion

        #region Nested type: DelegateAddSellEquip

        private delegate MysqlController.ReturnResult DelegateAddSellEquip(MysqlController.LXEquip iCustomDebt);

        #endregion

        #region Nested type: DelegateDeleteCustomDebtByEquipID

        private delegate MysqlController.ReturnResult DelegateDeleteCustomDebtByEquipID(int EquipID);

        #endregion

        #region Nested type: DelegateDeleteSellEquip

        private delegate MysqlController.ReturnResult DelegateDeleteSellEquip(int Debtid);

        #endregion

        #region Nested type: DelegateEditSoldEquip

        private delegate MysqlController.ReturnResult DelegateEditSoldEquip(MysqlController.LXEquip iEquip);

        #endregion

        #region Nested type: DelegateReadSoldEquip

        private delegate MysqlController.LXEquip[] DelegateReadSoldEquip(string reqDate);

        #endregion

        #region Nested type: DelegateReadSoldEquipByID

        private delegate MysqlController.LXEquip DelegateReadSoldEquipByID(string iID);

        #endregion

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion
    }
}