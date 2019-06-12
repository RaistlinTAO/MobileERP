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
    using MobileShopERP.Properties;

    #endregion

    public partial class frmEditPhone : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string iLoginUser;
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        private string PhoneIMEI;
        private string UserBXKid;
        private bool isPhoneSet;
        private bool isPhoneUserSet;
        private string[] tempBrand;

        private MysqlController.LXSellPhone[] tempPhone;
        private string[] tempSeller;
        //private MysqlController.LXUser tempUser;

        public frmEditPhone(ToolStripStatusLabel iBusy, string LoginUser)
        {
            iLoginUser = LoginUser;
            isBusy = iBusy;
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            /*
            if (txtIMEI.Text == "")
            {
                txtIMEI.Text = "";
                MessageBox.Show(Resources.frmEditPhone_cmdSearch_Click_请填写正确的串号再进行查询_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            */
            if (txtIMEI.Text != "")
            {
                isBusy.Visible = true;
                cmdSearch.Enabled = false;
                cmbBuyer.Items.Clear();

                DelegateReadPhoneSellByIMEI dn = MysqlControl.ReadPhoneSellByIMEI;

                IAsyncResult iar = dn.BeginInvoke(txtIMEI.Text, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                tempPhone = dn.EndInvoke(iar);

                if (tempPhone != null)
                {
                    int j = 0;
                    for (int i = 0; i < tempPhone.Length; i++)
                    {
                        if (tempPhone[i].Phoneid == null) continue;

                        j++;

                        /*
                        DelegateReadUserByPhoneID dnRUBP = MysqlControl.ReadUserByPhoneID;

                        IAsyncResult iarRUBP = dnRUBP.BeginInvoke(tempPhone[i].PhoneID, null, null);

                        while (iarRUBP.IsCompleted == false)
                        {
                            Application.DoEvents();
                        }

                        tempUser = dnRUBP.EndInvoke(iarRUBP);
                    
                        if (!string.IsNullOrEmpty(tempPhone[i].PhoneUserName))
                        {
                            //txtPhoneBuyer.Text = tempUser.UserCName;
                            //cmdUser.Enabled = true;
                            cmdDeltePhone.Enabled = true;
                        }
                        */
                        cmbBuyer.Items.Add(tempPhone[i].PhoneUserName + " 购机时间:" +
                                           tempPhone[i].PhoneDate.Substring(0, 4) +
                                           Resources.frmEditPhone_cmdSearch_Click_年 +
                                           tempPhone[i].PhoneDate.Substring(4, 2) +
                                           Resources.frmEditPhone_cmdSearch_Click_月 +
                                           tempPhone[i].PhoneDate.Substring(6, 2) +
                                           Resources.frmEditPhone_cmdSearch_Click_日);


                        cmdDeltePhone.Enabled = true;
                        Application.DoEvents();
                    }
                    if (j > 0)
                    {
                        cmbBuyer.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show(
                            Resources.frmEditPhone_cmdSearch_Click_没有在数据库里找到串号为 + txtIMEI.Text +
                            Resources.frmEditPhone_cmdSearch_Click_的手机, Application.ProductName, MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show(
                        Resources.frmEditPhone_cmdSearch_Click_没有在数据库里找到串号为 + txtIMEI.Text +
                        Resources.frmEditPhone_cmdSearch_Click_的手机, Application.ProductName, MessageBoxButtons.OK);
                }

                cmdSearch.Enabled = true;
                isBusy.Visible = false;
            }
            else if (txtBXKid.Text != "")
            {
                isBusy.Visible = true;
                cmdSearch.Enabled = false;
                cmbBuyer.Items.Clear();

                DelegateReadPhoneSellByBXKid dn = MysqlControl.ReadPhoneSellByBXKid;

                IAsyncResult iar = dn.BeginInvoke(txtBXKid.Text, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                tempPhone = dn.EndInvoke(iar);

                if (tempPhone != null)
                {
                    int j = 0;
                    for (int i = 0; i < tempPhone.Length; i++)
                    {
                        if (tempPhone[i].Phoneid == null) continue;
                        j++;
                        cmbBuyer.Items.Add(tempPhone[i].PhoneUserName + " 购机时间:" +
                                           tempPhone[i].PhoneDate.Substring(0, 4) +
                                           Resources.frmEditPhone_cmdSearch_Click_年 +
                                           tempPhone[i].PhoneDate.Substring(4, 2) +
                                           Resources.frmEditPhone_cmdSearch_Click_月 +
                                           tempPhone[i].PhoneDate.Substring(6, 2) +
                                           Resources.frmEditPhone_cmdSearch_Click_日);


                        cmdDeltePhone.Enabled = true;
                        Application.DoEvents();
                    }
                    if (j > 0)
                    {
                        cmbBuyer.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show(
                            Resources.frmEditPhone_cmdSearch_Click_没有在数据库里找到串号为 + txtIMEI.Text +
                            Resources.frmEditPhone_cmdSearch_Click_的手机, Application.ProductName, MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show(
                        Resources.frmEditPhone_cmdSearch_Click_没有在数据库里找到串号为 + txtIMEI.Text +
                        Resources.frmEditPhone_cmdSearch_Click_的手机, Application.ProductName, MessageBoxButtons.OK);
                }
                cmdSearch.Enabled = true;
                isBusy.Visible = false;
            }
        }

        public void SetupPhone(string iPhoneIMEI)
        {
            PhoneIMEI = iPhoneIMEI;
            isPhoneSet = true;
        }

        public void SetupUser(string iUserBXKid)
        {
            UserBXKid = iUserBXKid;
            isPhoneUserSet = true;
        }

        private void frmEditPhone_Load(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            DelegateManufacturer dn = MysqlControl.Manufacturer;
            IAsyncResult iar = dn.BeginInvoke(null, null);
            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }
            tempBrand = dn.EndInvoke(iar);

            DelegateSellers dn1 = MysqlControl.Sellers;
            IAsyncResult iar1 = dn1.BeginInvoke(null, null);
            while (iar1.IsCompleted == false)
            {
                Application.DoEvents();
            }
            tempSeller = dn1.EndInvoke(iar1);

            cmbWarrantyDuration.SelectedIndex = 0;
            cmbWarrantyType.SelectedIndex = 0;
            dtpWarrantyStartDate.Enabled = false;
            cmbWarrantyType.Enabled = false;
            cmbWarrantyDuration.Enabled = false;

            isBusy.Visible = false;

            if (isPhoneSet)
            {
                txtIMEI.Text = PhoneIMEI;
                cmdSearch_Click(sender, e);
            }

            if (isPhoneUserSet)
            {
                txtBXKid.Text = UserBXKid;
                cmdSearch_Click(sender, e);
            }
        }

        private void chkChangeWarranty_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChangeWarranty.Checked)
            {
                dtpWarrantyStartDate.Enabled = true;
                cmbWarrantyType.Enabled = true;
                cmbWarrantyDuration.Enabled = true;
                cmdUpdate.Enabled = true;
            }
            else
            {
                dtpWarrantyStartDate.Enabled = false;
                cmbWarrantyType.Enabled = false;
                cmbWarrantyDuration.Enabled = false;
                cmdUpdate.Enabled = false;
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (!chkChangeWarranty.Checked)
            {
                return;
            }
            isBusy.Visible = true;
            cmdUpdate.Enabled = false;

            tempPhone[cmbBuyer.SelectedIndex].PhoneWarranty = true;
            tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyType = cmbWarrantyType.SelectedIndex;
            tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyDuration = cmbWarrantyDuration.SelectedIndex;
            tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyDate = dtpWarrantyStartDate.Value.Year +
                                                                  dtpWarrantyStartDate.Value.Month.ToString().PadLeft(
                                                                      2, '0') +
                                                                  dtpWarrantyStartDate.Value.Day.ToString().PadLeft(2,
                                                                                                                    '0');

            DelegateUpdatePhoneWarrantyByID dn = MysqlControl.UpdatePhoneWarrantyByID;

            IAsyncResult iar = dn.BeginInvoke(tempPhone[cmbBuyer.SelectedIndex], null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

            if (iResult.isSuccess)
            {
                MessageBox.Show(Resources.frmEditPhone_cmdUpdate_Click_修改手机保修成功_, Application.ProductName,
                                MessageBoxButtons.OK);
                txtPhoneWarranty.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneWarranty ? "有" : "无";
                txtWarrantDate.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyDate.Substring(0, 4) +
                                      Resources.frmEditPhone_cmdSearch_Click_年 +
                                      tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyDate.Substring(4, 2) +
                                      Resources.frmEditPhone_cmdSearch_Click_月 +
                                      tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyDate.Substring(6, 2) +
                                      Resources.frmEditPhone_cmdSearch_Click_日;
                switch (tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyType.ToString())
                {
                    case "0":
                        txtPhoneWarrantyType.Text = Resources.frmEditPhone_cmdSearch_Click_软件保修;
                        break;
                    case "1":
                        txtPhoneWarrantyType.Text = Resources.frmEditPhone_cmdSearch_Click_软硬全保;
                        break;
                    case "2":
                        txtPhoneWarrantyType.Text = Resources.frmEditPhone_cmdSearch_Click_延长保修;
                        break;
                    case "3":
                        txtPhoneWarrantyType.Text = Resources.frmEditPhone_cmdSearch_Click_无敌保修;
                        break;
                }
                switch (tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyDuration.ToString())
                {
                    case "0":
                        txtPhoneWarrantyDuration.Text = Resources.frmEditPhone_cmdSearch_Click_一年;
                        break;
                    case "1":
                        txtPhoneWarrantyDuration.Text = Resources.frmEditPhone_cmdSearch_Click_两年;
                        break;
                    case "2":
                        txtPhoneWarrantyDuration.Text = Resources.frmEditPhone_cmdSearch_Click_三年;
                        break;
                    case "3":
                        txtPhoneWarrantyDuration.Text = Resources.frmEditPhone_cmdSearch_Click_终身;
                        break;
                }
            }
            else
            {
                MessageBox.Show(Resources.frmEditPhone_cmdUpdate_Click_ + iResult.ErrDesc, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            cmdUpdate.Enabled = true;
            isBusy.Visible = false;
        }

        private void cmdUser_Click(object sender, EventArgs e)
        {
            /*
            var iCustem = new frmEditCustem(isBusy, iLoginUser)
                              {TopLevel = false, Dock = DockStyle.Fill, Parent = Parent};
            iCustem.SetCustom(tempUser);
            iCustem.Show();
            iCustem.BringToFront();
            Parent.BringToFront();
        
             */
        }

        //private delegate MysqlController.LXUser DelegateReadUserByPhoneID(string iPhoneID);

        private void cmbBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblID.Text = tempPhone[cmbBuyer.SelectedIndex].Phoneid;
            txtPhoneDate.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneDate.Substring(0, 4) +
                                Resources.frmEditPhone_cmdSearch_Click_年 +
                                tempPhone[cmbBuyer.SelectedIndex].PhoneDate.Substring(4, 2) +
                                Resources.frmEditPhone_cmdSearch_Click_月 +
                                tempPhone[cmbBuyer.SelectedIndex].PhoneDate.Substring(6, 2) +
                                Resources.frmEditPhone_cmdSearch_Click_日;
            txtSeller.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneSeller;
            txtPhoneBrand.Text = tempBrand[tempPhone[cmbBuyer.SelectedIndex].PhoneBrandid];
            txtPhoneName.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneName;
            //txtPhoneEquip.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneHasEquip ? "有" : "无";
            txtPhoneWarranty.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneWarranty ? "有" : "无";
            txtWarrantDate.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyDate.Substring(0, 4) +
                                  Resources.frmEditPhone_cmdSearch_Click_年 +
                                  tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyDate.Substring(4, 2) +
                                  Resources.frmEditPhone_cmdSearch_Click_月 +
                                  tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyDate.Substring(6, 2) +
                                  Resources.frmEditPhone_cmdSearch_Click_日;
            switch (tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyType.ToString())
            {
                case "0":
                    txtPhoneWarrantyType.Text = Resources.frmEditPhone_cmdSearch_Click_软件保修;
                    break;
                case "1":
                    txtPhoneWarrantyType.Text = Resources.frmEditPhone_cmdSearch_Click_软硬全保;
                    break;
                case "2":
                    txtPhoneWarrantyType.Text = Resources.frmEditPhone_cmdSearch_Click_延长保修;
                    break;
                case "3":
                    txtPhoneWarrantyType.Text = Resources.frmEditPhone_cmdSearch_Click_无敌保修;
                    break;
            }
            switch (tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyDuration.ToString())
            {
                case "0":
                    txtPhoneWarrantyDuration.Text = Resources.frmEditPhone_cmdSearch_Click_一年;
                    break;
                case "1":
                    txtPhoneWarrantyDuration.Text = Resources.frmEditPhone_cmdSearch_Click_两年;
                    break;
                case "2":
                    txtPhoneWarrantyDuration.Text = Resources.frmEditPhone_cmdSearch_Click_三年;
                    break;
                case "3":
                    txtPhoneWarrantyDuration.Text = Resources.frmEditPhone_cmdSearch_Click_终身;
                    break;
            }


            if (tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyDuration.ToString() != "3")
            {
                var DtDeadTime = new DateTime(int.Parse(tempPhone[cmbBuyer.SelectedIndex].PhoneDate.Substring(0, 4)),
                                              int.Parse(tempPhone[cmbBuyer.SelectedIndex].PhoneDate.Substring(4, 2)),
                                              int.Parse(tempPhone[cmbBuyer.SelectedIndex].PhoneDate.Substring(6, 2)));
                var DtNowTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                txtPhoneisOut.Text = DateTime.Compare(DtDeadTime, DtNowTime) > 0 ? "在保" : "过保";
            }
            else
            {
                txtPhoneisOut.Text = "永不过保";
            }

            txtPhonePrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhonePrice.ToString();
            //成本
            txtPhoneRealPrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneRealprice.ToString();
            lblScreenGuardPrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneScreenGuard.ToString();
            lblBettaryPrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneBattery.ToString();
            lblCardlePrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneCarCradle.ToString();
            lblChargePrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneCarCharger.ToString();
            lblHeadPhonePrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneHeadPhone.ToString();
            lblOtherPrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneOther.ToString();
            //lblScreenGuardPrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneScreenGuard.ToString();
            lblSDCardPrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneSDCARD.ToString();
            lblShellPrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneShell.ToString();
            //
            txtPhoneProfit.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneProfit.ToString();
            txtPhoneCommision.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneCommision.ToString();
            txtCommin.Text = Math.Round(
                (tempPhone[cmbBuyer.SelectedIndex].PhoneProfit -
                 tempPhone[cmbBuyer.SelectedIndex].PhoneCommision), 2).ToString();
            txtSupplier.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneSupplier;

            //DelegateReadUserByPhoneID
            /*
            DelegateReadUserByPhoneID dn = MysqlControl.ReadUserByPhoneID;

            IAsyncResult iar = dn.BeginInvoke(tempPhone[cmbBuyer.SelectedIndex].PhoneID, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempUser = dn.EndInvoke(iar);

            if (!string.IsNullOrEmpty(tempUser.UserCName))
            {
                txtPhoneBuyer.Text = tempUser.UserCName;
                cmdUser.Enabled = true;
            }
            else
            {
                txtPhoneBuyer.Text = Resources.frmEditPhone_cmdSearch_Click_该手机已退货;
            }
            */
            txtPhoneBuyer.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneUserName;
            if (tempPhone[cmbBuyer.SelectedIndex].PhoneisHKLegal)
            {
                txtType.Text = Resources.frmEditPhone_cmbBuyer_SelectedIndexChanged_港行;
            }
            if (tempPhone[cmbBuyer.SelectedIndex].PhoneisLegal)
            {
                txtType.Text = Resources.frmEditPhone_cmbBuyer_SelectedIndexChanged_国行;
            }
            if (tempPhone[cmbBuyer.SelectedIndex].PhoneisUnLegal)
            {
                txtType.Text = Resources.frmEditPhone_cmbBuyer_SelectedIndexChanged_水货;
            }
            txtWarrantyPrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneWarrantyPrice.ToString();
            //txtEquipPrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneEquipPrice;
            //txtEquipRealPrice.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneEquipRealPrice;
            txtBXKid.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneUserBXKid;
            txtIMEI.Text = tempPhone[cmbBuyer.SelectedIndex].PhoneIMEI;
            cmdDeltePhone.Enabled = true;
        }

        private void cmdDeltePhone_Click(object sender, EventArgs e)
        {
            DelegateDeletePhoneSell dn = MysqlControl.DeletePhoneSell;

            IAsyncResult iar = dn.BeginInvoke(int.Parse(lblID.Text), null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

            if (iResult.isSuccess)
            {
                MessageBox.Show(Resources.frmEditPhone_cmdDeltePhone_Click_删除该部手机成功_, Application.ProductName,
                                MessageBoxButtons.OK);
                var iCustem = new frmEditPhone(isBusy, iLoginUser)
                                  {TopLevel = false, Dock = DockStyle.Fill, Parent = Parent};
                iCustem.Show();
                iCustem.BringToFront();
                Parent.BringToFront();
            }
            else
            {
                MessageBox.Show(Resources.frmEditPhone_cmdDeltePhone_Click_删除该部手机失败__错误原因_ + iResult.ErrDesc,
                                Application.ProductName, MessageBoxButtons.OK);
            }
        }

        #region Nested type: DelegateDeletePhoneSell

        private delegate MysqlController.ReturnResult DelegateDeletePhoneSell(int PhoneID);

        #endregion

        #region Nested type: DelegateManufacturer

        private delegate string[] DelegateManufacturer();

        #endregion

        #region Nested type: DelegateReadPhoneSellByBXKid

        private delegate MysqlController.LXSellPhone[] DelegateReadPhoneSellByBXKid(string iBXKid);

        #endregion

        #region Nested type: DelegateReadPhoneSellByIMEI

        private delegate MysqlController.LXSellPhone[] DelegateReadPhoneSellByIMEI(string strIMEI);

        #endregion

        //#region Nested type: DelegateReadUserByPhoneID

        //private delegate MysqlController.LXSellPhone DelegateReadUserByPhoneID(string iPhoneID);

        // #endregion

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion

        #region Nested type: DelegateUpdatePhoneWarrantyByID

        private delegate MysqlController.ReturnResult DelegateUpdatePhoneWarrantyByID(
            MysqlController.LXSellPhone tempPhone);

        #endregion
    }
}