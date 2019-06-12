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

namespace LongXiangCRM.Function
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using LongXiangCRM.Properties;

    #endregion

    public partial class frmDailySell : Form
    {
        private static readonly MysqlController MysqlControl = new MysqlController();
        private readonly string iLoginUser;
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        private string[] tempBrand;
        private string[] tempSeller;

        public frmDailySell(ToolStripStatusLabel iBusy, string LoginUser)
        {
            iLoginUser = LoginUser;
            isBusy = iBusy;
            InitializeComponent();
        }

        private void cmdViewDaily_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            cmdViewDaily.Enabled = false;

            DelegateGetPhones dn = GetPhones;

            IAsyncResult iar = dn.BeginInvoke(
                dtpDaily.Value.Year +
                dtpDaily.Value.Month.ToString().PadLeft(2, '0') +
                dtpDaily.Value.Day.ToString().PadLeft(2, '0'), null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.LXPhones[] tempPhones = dn.EndInvoke(iar);

            if (tempPhones.Length < 1)
            {
                MessageBox.Show(Resources.frmDailySell_cmdViewDaily_Click_未查询到任何数据_, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            else
            {
                RefreshList(tempPhones);
            }
            cmdViewDaily.Enabled = true;
            isBusy.Visible = false;
        }

        private void frmDailySell_Load(object sender, EventArgs e)
        {
            isBusy.Visible = true;

            DelegateSellers dn = MysqlControl.Sellers;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempSeller = dn.EndInvoke(iar);

            DelegateManufacturer dn1 = MysqlControl.Manufacturer;

            IAsyncResult iar1 = dn1.BeginInvoke(null, null);

            while (iar1.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempBrand = dn1.EndInvoke(iar1);

            isBusy.Visible = false;
        }

        private void cmdViewMonth_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            cmdViewMonth.Enabled = false;
            DelegateGetPhones dn = GetPhones;

            IAsyncResult iar = dn.BeginInvoke(dtpDaily.Value.Year + dtpDaily.Value.Month.ToString().PadLeft(2, '0'),
                                              null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.LXPhones[] tempPhones = dn.EndInvoke(iar);

            if (tempPhones == null || tempPhones.Length < 1)
            {
                MessageBox.Show(Resources.frmDailySell_cmdViewDaily_Click_未查询到任何数据_, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            else
            {
                RefreshList(tempPhones);
            }
            cmdViewMonth.Enabled = true;
            isBusy.Visible = false;
        }

        private void RefreshList(IList<MysqlController.LXPhones> tempPhones)
        {
            isBusy.Visible = true;
            lsvPhones.Items.Clear();
            for (int i = 0; i < tempPhones.Count; i++)
            {
                if (string.IsNullOrEmpty(tempPhones[i].PhoneID)) continue;

                var iItem = new ListViewItem(tempPhones[i].PhoneDate);
                iItem.SubItems.Add(tempBrand[int.Parse(tempPhones[i].PhoneBrand)]);
                iItem.SubItems.Add(tempPhones[i].PhoneName);
                iItem.SubItems.Add(tempPhones[i].PhoneIMEI);
                iItem.SubItems.Add(tempPhones[i].PhonePrice);
                iItem.SubItems.Add(tempPhones[i].PhoneRealPrice);
                iItem.SubItems.Add(tempPhones[i].PhoneHasEquip ? "有" : "无");
                iItem.SubItems.Add(tempSeller[int.Parse(tempPhones[i].PhoneSeller)]);
                iItem.SubItems.Add(tempPhones[i].PhoneHasWarranty ? "有" : "无");
                switch (tempPhones[i].PhoneWarrantyType)
                {
                    case "0":
                        iItem.SubItems.Add("软件保修");
                        break;
                    case "1":
                        iItem.SubItems.Add("软硬全保");
                        break;
                    case "2":
                        iItem.SubItems.Add("延长保修");
                        break;
                    case "3":
                        iItem.SubItems.Add("无敌保修");
                        break;
                }
                switch (tempPhones[i].PhoneWarrantyDuration)
                {
                    case "0":
                        iItem.SubItems.Add("一年");
                        break;
                    case "1":
                        iItem.SubItems.Add("两年");
                        break;
                    case "2":
                        iItem.SubItems.Add("三年");
                        break;
                    case "3":
                        iItem.SubItems.Add("终身");
                        break;
                }
                iItem.SubItems.Add(tempPhones[i].PhoneIsDelete ? "有" : "无");
                iItem.SubItems.Add(tempPhones[i].phone_supplier);
                iItem.SubItems.Add(tempPhones[i].PhoneEquipPrice);
                iItem.SubItems.Add(tempPhones[i].PhoneEquipRealPrice);
                iItem.SubItems.Add(tempPhones[i].PhoneIsLegal ? "有" : "无");
                iItem.SubItems.Add(tempPhones[i].PhoneID);
                //DelegateReadUserByPhoneID
                DelegateReadUserByPhoneID dn = MysqlControl.ReadUserByPhoneID;

                IAsyncResult iar = dn.BeginInvoke(tempPhones[i].PhoneID, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.LXUser iUser = dn.EndInvoke(iar);

                try
                {
                    iItem.SubItems.Add(iUser.UserCName);
                }
                catch (Exception)
                {
                    iItem.SubItems.Add("");
                }
                try
                {
                    iItem.SubItems.Add(iUser.Phone);
                }
                catch (Exception)
                {
                    iItem.SubItems.Add("");
                }
                try
                {
                    iItem.SubItems.Add(iUser.BXKid);
                }
                catch (Exception)
                {
                    iItem.SubItems.Add("");
                }

                lsvPhones.Items.Add(iItem);
                Application.DoEvents();
            }
            isBusy.Visible = false;
        }

        private static MysqlController.LXPhones[] GetPhones(string DateStr)
        {
            var tempPhones = new MysqlController.LXPhones[50000];

            DelegateReadProfit dn = MysqlControl.ReadProfit;

            IAsyncResult iar = dn.BeginInvoke(DateStr, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempPhones = dn.EndInvoke(iar);

            return tempPhones;
        }

        private void cmdViewPhone_Click(object sender, EventArgs e)
        {
            try
            {
                int tempID = int.Parse(lsvPhones.SelectedItems[0].SubItems[16].Text);
                if (tempID.ToString() != "")
                {
                    var iCustem = new frmEditPhone(isBusy, iLoginUser)
                                      {TopLevel = false, Dock = DockStyle.Fill, Parent = Parent};
                    iCustem.SetupPhone(lsvPhones.SelectedItems[0].SubItems[3].Text);
                    iCustem.Show();
                    iCustem.BringToFront();
                    Parent.BringToFront();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void cmdViewBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                int tempID = int.Parse(lsvPhones.SelectedItems[0].SubItems[16].Text);
                if (tempID.ToString() != "")
                {
                    DelegateReadUserByPhoneID dn = MysqlControl.ReadUserByPhoneID;

                    IAsyncResult iar = dn.BeginInvoke(lsvPhones.SelectedItems[0].SubItems[16].Text, null, null);

                    while (iar.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    MysqlController.LXUser tempUser = dn.EndInvoke(iar);

                    var iCustem = new frmEditCustem(isBusy, iLoginUser)
                                      {TopLevel = false, Dock = DockStyle.Fill, Parent = Parent};
                    iCustem.SetCustom(tempUser);
                    iCustem.Show();
                    iCustem.BringToFront();
                    Parent.BringToFront();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        #region Nested type: DelegateGetPhones

        private delegate MysqlController.LXPhones[] DelegateGetPhones(string DateStr);

        #endregion

        #region Nested type: DelegateManufacturer

        private delegate string[] DelegateManufacturer();

        #endregion

        #region Nested type: DelegateReadProfit

        private delegate MysqlController.LXPhones[] DelegateReadProfit(string Smonth);

        #endregion

        #region Nested type: DelegateReadUserByPhoneID

        private delegate MysqlController.LXUser DelegateReadUserByPhoneID(string iPhoneID);

        #endregion

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion
    }
}