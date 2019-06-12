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
    using DataControler.Mysql;
    using Dundas.Charting.WinControl;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmCommision : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();

        private readonly double[] mCommision = new double[31];
        private readonly double[] mProfit = new double[31];
        private string[] Brands;
        //private string[] SellersPosition;
        private int sHasBX;
        //private int sHasEquip;

        public frmCommision(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void RefreshChart()
        {
            isBusy.Visible = true;
            chartSellers.Series.Clear();

            var series1 = new Series();
            var series2 = new Series();

            for (int i = 1; i < 32; i++)
            {
                series1.Points.Add(mProfit[i - 1]);
                series2.Points.Add(mCommision[i - 1]);
                Application.DoEvents();
            }

            series1.Name = "利润";
            series2.Name = "提成";
            series1.Type = SeriesChartType.Line;
            series2.Type = SeriesChartType.Line;

            series1.ShowLabelAsValue = true;
            series1.SmartLabels.Enabled = true;

            series2.ShowLabelAsValue = true;
            series2.SmartLabels.Enabled = true;

            chartSellers.Series.Add(series1);
            chartSellers.Series.Add(series2);
            isBusy.Visible = false;
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            if (cmbSellers.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.frmCommision_cmdView_Click_必须选择一个销售人员再进行查看_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (MysqlControl.ReadSellerPosition(cmbSellers.Text) != "销售" &&
                MysqlControl.ReadSellerPosition(cmbSellers.Text) != "店长")
            {
                MessageBox.Show(Resources.frmCommision_cmdView_Click_非销售人员或店员没有提成_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            isBusy.Visible = true;
            cmdView.Enabled = false;
            cmbSellers.Enabled = false;
            lsvCommision.Items.Clear();
            txtPhoneCommision.Text = Resources.frmCommision_cmdView_Click__0;
            txtPhoneProfit.Text = Resources.frmCommision_cmdView_Click__0;
            sHasBX = 0;
            //sHasEquip = 0;

            for (int i = 0; i < mCommision.Length; i++)
            {
                mCommision[i] = 0;
            }

            for (int i = 0; i < mProfit.Length; i++)
            {
                mProfit[i] = 0;
            }

            if (cmbSellers.SelectedIndex != -1)
            {
                DelegateReadCommision dn = MysqlControl.ReadPhoneSell;

                IAsyncResult iar = dn.BeginInvoke(cmbSellers.Text,
                                                  dtpMonth.Value.Year +
                                                  dtpMonth.Value.Month.ToString().PadLeft
                                                      (2, '0'), null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.LXSellPhone[] tempPhones = dn.EndInvoke(iar);

                int j = 0;
                if (tempPhones != null)
                {
                    for (int i = 0; i < tempPhones.Length; i++)
                    {
                        if (tempPhones[i].PhoneIMEI == null) continue;
                        lsvCommision.Items.Add(tempPhones[i].PhoneDate);

                        lsvCommision.Items[j].SubItems.Add(Brands[tempPhones[i].PhoneBrandid]);
                        lsvCommision.Items[j].SubItems.Add(tempPhones[i].PhoneName);
                        lsvCommision.Items[j].SubItems.Add(tempPhones[i].PhoneIMEI);
                        /*
                        lsvCommision.Items[j].SubItems.Add(tempPhones[i].PhoneHasEquip ? "有" : "无");
                        if (tempPhones[i].PhoneHasEquip)
                        {
                            sHasEquip = sHasEquip + 1;
                        }
                        */
                        lsvCommision.Items[j].SubItems.Add(tempPhones[i].PhonePrice.ToString());
                        lsvCommision.Items[j].SubItems.Add(tempPhones[i].PhoneRealprice.ToString());
                        lsvCommision.Items[j].SubItems.Add(tempPhones[i].PhoneProfit.ToString());
                        lsvCommision.Items[j].SubItems.Add(tempPhones[i].PhoneCommision.ToString());
                        lsvCommision.Items[j].SubItems.Add(tempPhones[i].PhoneWarranty ? "有" : "无");
                        if (tempPhones[i].PhoneWarranty)
                        {
                            sHasBX = sHasBX + 1;
                        }
                        switch (tempPhones[i].PhoneWarrantyType)
                        {
                            case 0:
                                lsvCommision.Items[j].SubItems.Add("软件保修");
                                break;
                            case 1:
                                lsvCommision.Items[j].SubItems.Add("软硬全保");
                                break;
                            case 2:
                                lsvCommision.Items[j].SubItems.Add("延长保修");
                                break;
                            case 3:
                                lsvCommision.Items[j].SubItems.Add("无敌保修");
                                break;
                        }
                        switch (tempPhones[i].PhoneWarrantyDuration)
                        {
                            case 0:
                                lsvCommision.Items[j].SubItems.Add("一年");
                                break;
                            case 1:
                                lsvCommision.Items[j].SubItems.Add("两年");
                                break;
                            case 2:
                                lsvCommision.Items[j].SubItems.Add("三年");
                                break;
                            case 3:
                                lsvCommision.Items[j].SubItems.Add("终身");
                                break;
                        }

                        j++;
                        txtPhoneProfit.Text =
                            Math.Round(double.Parse(txtPhoneProfit.Text) + tempPhones[i].PhoneProfit, 2).ToString();
                        txtPhoneCommision.Text =
                            Math.Round(double.Parse(txtPhoneCommision.Text) + tempPhones[i].PhoneCommision, 2).ToString();

                        mCommision[int.Parse(tempPhones[i].PhoneDate.Substring(6, 2))] =
                            Math.Round(mCommision[int.Parse(tempPhones[i].PhoneDate.Substring(6, 2))] +
                                       tempPhones[i].PhoneCommision, 2);
                        mProfit[int.Parse(tempPhones[i].PhoneDate.Substring(6, 2))] =
                            Math.Round(mProfit[int.Parse(tempPhones[i].PhoneDate.Substring(6, 2))] +
                                       tempPhones[i].PhoneProfit, 2);
                        Application.DoEvents();
                    }


                    //txtEquip.Text = (sHasEquip/(double) j).ToString("p");
                    txtBX.Text = (sHasBX/(double) j).ToString("p");

                    //这里填充配件销售

                    DelegateReadSoldEquip dn1 = MysqlControl.ReadSoldEquip;

                    IAsyncResult iar1 = dn1.BeginInvoke(dtpMonth.Value.Year +
                                                        dtpMonth.Value.Month.ToString().
                                                            PadLeft
                                                            (2, '0'), null, null);

                    while (iar1.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    MysqlController.LXEquip[] tempPayout = dn1.EndInvoke(iar1);

                    lsvEquips.Items.Clear();
                    if (tempPayout == null) return;
                    if (tempPayout.Length <= 0) return;
                    j = 0;
                    for (int i = 0; i < tempPayout.Length; i++)
                    {
                        if (string.IsNullOrEmpty(tempPayout[i].EquipDate)) continue;
                        if (tempPayout[i].EquipSellers != cmbSellers.Text) continue;
                        lsvEquips.Items.Add(tempPayout[i].EquipID.ToString());
                        lsvEquips.Items[j].SubItems.Add(tempPayout[i].EquipDate);
                        lsvEquips.Items[j].SubItems.Add(tempPayout[i].EquipName);
                        lsvEquips.Items[j].SubItems.Add(tempPayout[i].EquipPrice.ToString());
                        lsvEquips.Items[j].SubItems.Add(tempPayout[i].EquipRealPrice.ToString());
                        lsvEquips.Items[j].SubItems.Add(tempPayout[i].EquipSupplier);
                        lsvEquips.Items[j].SubItems.Add(tempPayout[i].EquipBackup);
                        lsvEquips.Items[j].SubItems.Add(cmbSellers.Text);
                        lsvEquips.Items[j].SubItems.Add(tempPayout[i].EquipProfit.ToString());
                        lsvEquips.Items[j].SubItems.Add(tempPayout[i].EquipCommision.ToString());
                        txtEquipProfit.Text =
                            (int.Parse(txtEquipProfit.Text) + tempPayout[i].EquipProfit).ToString();
                        txtEquipCommision.Text =
                            (int.Parse(txtEquipCommision.Text) + tempPayout[i].EquipCommision).ToString();
                        j++;
                        Application.DoEvents();
                    }

                    //这里填充返收销售
                    DelegateReadRefundPhone dn2 = MysqlControl.ReadRefundPhone;

                    IAsyncResult iar2 = dn2.BeginInvoke(dtpMonth.Value.Year +
                                                        dtpMonth.Value.Month.ToString().PadLeft
                                                            (2, '0'), null, null);

                    while (iar2.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    MysqlController.RefundPhone[] tempRefundPhone = dn2.EndInvoke(iar2);

                    lsvPhones.Items.Clear();
                    j = 0;
                    if (tempRefundPhone != null)
                    {
                        if (tempRefundPhone.Length > 0)
                        {
                            for (int i = 0; i < tempRefundPhone.Length; i++)
                            {
                                if (string.IsNullOrEmpty(tempRefundPhone[i].RefundDate)) continue;
                                if (!tempRefundPhone[i].RefundIsFix) continue;
                                if (tempRefundPhone[i].RefundFixSeller != cmbSellers.Text) continue;
                                lsvPhones.Items.Add(tempRefundPhone[i].RefundID.ToString());
                                lsvPhones.Items[j].SubItems.Add(tempRefundPhone[i].RefundDate);
                                lsvPhones.Items[j].SubItems.Add(tempRefundPhone[i].RefundName);
                                lsvPhones.Items[j].SubItems.Add(tempRefundPhone[i].RefundPrice.ToString());
                                lsvPhones.Items[j].SubItems.Add(cmbSellers.Text);
                                lsvPhones.Items[j].SubItems.Add(tempRefundPhone[i].RefundIMEI);
                                lsvPhones.Items[j].SubItems.Add(tempRefundPhone[i].RefundBackup);
                                lsvPhones.Items[j].SubItems.Add(
                                    tempRefundPhone[i].RefundRepairPrice.ToString());
                                lsvPhones.Items[j].SubItems.Add("已出售");
                                lsvPhones.Items[j].SubItems.Add(tempRefundPhone[i].RefundFixPrice.ToString());
                                txtBinPhoneProfit.Text =
                                    (int.Parse(txtBinPhoneProfit.Text) + tempRefundPhone[i].RefundFixProfit)
                                        .ToString();
                                txtBinPhoneCommision.Text =
                                    (int.Parse(txtBinPhoneCommision.Text) +
                                     tempRefundPhone[i].RefundFixCommision).ToString();
                                j++;
                                Application.DoEvents();
                            }
                        }
                    }

                    txtProfit.Text =
                        (int.Parse(txtPhoneProfit.Text) + int.Parse(txtEquipProfit.Text) +
                         int.Parse(txtBinPhoneProfit.Text)).ToString();

                    txtCommision.Text =
                        (int.Parse(txtPhoneCommision.Text) + int.Parse(txtEquipCommision.Text) +
                         int.Parse(txtBinPhoneCommision.Text)).ToString();

                    //这里填充图表
                    RefreshChart();
                }

                else
                {
                    MessageBox.Show(Resources.frmCommision_cmdView_Click_查询提成失败_, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
            else
            {
                isBusy.Visible = false;
                cmbSellers.Enabled = true;
                cmdView.Enabled = true;
                return;
            }
            isBusy.Visible = false;
            cmbSellers.Enabled = true;
            cmdView.Enabled = true;
        }

        private void frmCommision_Shown(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            cmbSellers.Items.Clear();

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
                Application.DoEvents();
            }
            DelegateManufacturer dn1 = MysqlControl.Manufacturer;

            IAsyncResult iar1 = dn1.BeginInvoke(null, null);

            while (iar1.IsCompleted == false)
            {
                Application.DoEvents();
            }

            Brands = dn1.EndInvoke(iar1);

            /*
            DelegateSellersPosition dn2 = MysqlControl.SellersPosition;

            IAsyncResult iar2 = dn2.BeginInvoke(null, null);

            while (iar2.IsCompleted == false)
            {
                Application.DoEvents();
            }

            SellersPosition = dn2.EndInvoke(iar2);
            */
            isBusy.Visible = false;
        }

        #region Nested type: DelegateManufacturer

        private delegate string[] DelegateManufacturer();

        #endregion

        #region Nested type: DelegateReadCommision

        private delegate MysqlController.LXSellPhone[] DelegateReadCommision(string SellerName, string reqDate);

        #endregion

        #region Nested type: DelegateReadRefundPhone

        private delegate MysqlController.RefundPhone[] DelegateReadRefundPhone(string reqDate);

        #endregion

        #region Nested type: DelegateReadSoldEquip

        private delegate MysqlController.LXEquip[] DelegateReadSoldEquip(string reqDate);

        #endregion

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion

        //private delegate string[] DelegateSellersPosition();

        //private delegate string DelegateReadSellerPosition(string SellerName);
    }
}