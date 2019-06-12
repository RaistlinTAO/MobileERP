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
    using System.Data;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Log;
    using DataControler.Mysql;
    using LongXiangCRM.Properties;

    #endregion

    public partial class frmEditCustem : Form
    {
        private readonly clsLog LogControl = new clsLog();
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string iLoginUser;
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        private MysqlController.LXUser SetUser;
        //private bool isSFlag;
        private bool isSetFlag;
        //private int tempIndex = 0;

        private string[] tempBrand;

        private MysqlController.LXPhones[] tempCPhones = new MysqlController.LXPhones[10000];
        private string[] tempSeller;

        private MysqlController.LXUser[] tempUserInfo = new MysqlController.LXUser[20];
        private MysqlController.ReturnUsers tempUsers;

        public frmEditCustem(ToolStripStatusLabel iBusy, string LoginUser)
        {
            iLoginUser = LoginUser;
            isBusy = iBusy;
            InitializeComponent();
        }

        public void AddPhone(MysqlController.LXPhones tempPhoneAA, int PaymentType, string UnDebtPrice)
        {
            var iAdd = new frmAddPhone {Location = lsvPhones.Location};

            Point p = PointToScreen(lsvPhones.Location);
            iAdd.IsEditMode = true;
            iAdd.IsAddExist = true;
            iAdd.iPhones = tempPhoneAA;
            iAdd.SetDesktopBounds(p.X, p.Y, iAdd.Width, iAdd.Height);
            iAdd.PaymentType = PaymentType;
            iAdd.UnDebtPrice = UnDebtPrice;
            if (iAdd.ShowDialog() != DialogResult.OK) return;
            //iAdd.iPhones
            MysqlController.LXPhones tempPhone = iAdd.GetRespos();
            var iItem = new ListViewItem {Text = tempPhone.PhoneDate};

            iItem.SubItems.Add(tempBrand[int.Parse(tempPhone.PhoneBrand)]);
            iItem.SubItems.Add(tempPhone.PhoneName);
            iItem.SubItems.Add(tempPhone.PhoneIMEI);
            iItem.SubItems.Add(tempPhone.PhonePrice);
            iItem.SubItems.Add(tempPhone.PhoneRealPrice);
            iItem.SubItems.Add(tempPhone.PhoneHasEquip ? Resources.frmEditCustem_cmdUpdate_Click_有 : "无");
            iItem.SubItems.Add(tempSeller[int.Parse(tempPhone.PhoneSeller)]);

            iItem.SubItems.Add(tempPhone.PhoneHasWarranty ? Resources.frmEditCustem_cmdUpdate_Click_有 : "无");
            switch (tempPhone.PhoneWarrantyType)
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
            switch (tempPhone.PhoneWarrantyDuration)
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
            iItem.SubItems.Add("无");
            iItem.SubItems.Add(tempPhone.phone_supplier);
            iItem.SubItems.Add(tempPhone.PhoneEquipPrice);
            iItem.SubItems.Add(tempPhone.PhoneEquipRealPrice);
            if (tempPhone.PhoneIsLegal)
            {
                iItem.SubItems.Add("国行");
            }
            if (tempPhone.PhoneIsHKLegal)
            {
                iItem.SubItems.Add("港行");
            }
            if (tempPhone.PhoneIsUnLegal)
            {
                iItem.SubItems.Add("水货");
            }
            iItem.SubItems.Add(tempPhone.PhoneWarrantyPrice);
            //ID
            iItem.SubItems.Add("");
            iItem.SubItems.Add(tempPhone.PhonePayment.ToString());
            iItem.SubItems.Add(tempPhone.phoneUnDebtPrice);
            lsvPhones.Items.Add(iItem);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text == "" && txtBXKId.Text == "" && txtIMEI.Text == "")
            {
                MessageBox.Show(Resources.frmEditCustem_cmdSearch_Click_必须填写手机号_手机串号或保修卡任意一项_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            cmdSearch.Enabled = false;
            isBusy.Visible = true;
            if (txtPhone.Text != "" || txtBXKId.Text != "")
            {
                DelegateGetSingleUser dn = MysqlControl.GetSingleUser;

                IAsyncResult iar = dn.BeginInvoke(txtUserCName.Text, txtPhone.Text, txtBXKId.Text, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                tempUsers = dn.EndInvoke(iar);

                tempUserInfo = tempUsers.UserInfo;
            }
            else
            {
                tempUsers.isError = false;
                tempUsers.UserNum = 1;
                MysqlController.LXPhones[] tempPhone = MysqlControl.ReadPhoneByIMEI(txtIMEI.Text);
                if (tempPhone[0].PhoneID != null)
                {
                    tempUserInfo[0] = MysqlControl.ReadUserByPhoneID(tempPhone[0].PhoneID);
                }
                else
                {
                    MessageBox.Show(Resources.frmEditCustem_cmdSearch_Click_未搜索到任何用户资料_, Application.ProductName,
                                    MessageBoxButtons.OK);

                    isBusy.Visible = false;
                    cmdSearch.Enabled = true;
                    return;
                }
            }


            if (tempUsers.isError != true)
            {
                if (tempUsers.UserNum < 1)
                {
                    MessageBox.Show(Resources.frmEditCustem_cmdSearch_Click_未搜索到任何用户资料_, Application.ProductName,
                                    MessageBoxButtons.OK);
                    isBusy.Visible = false;
                    cmdSearch.Enabled = true;
                    return;
                }
                else
                {
                    //isSFlag = true;
                    /*
                    for (int i = 0; i < tempUserInfo.Length; i++)
                    {
                        if (tempUserInfo[i].iFlag)
                        {
                            cmbUser.Items.Add(txtUserName.Text == ""
                                                  ? tempUserInfo[i].UserName
                                                  : tempUserInfo[i].UserCName);
                        }
                    }
                    */
                    txtID.Text = tempUserInfo[0].UserID.ToString();
                    txtEmail.Text = tempUserInfo[0].Email;
                    txtPhone.Text = tempUserInfo[0].Phone;
                    txtTelephone.Text = tempUserInfo[0].Telephone;
                    txtQQ.Text = tempUserInfo[0].QQ;
                    txtContectAddress.Text = tempUserInfo[0].ContectAddress;
                    txtLXCredit.Text = tempUserInfo[0].LXCredit;
                    ckbIsBXK.Checked = tempUserInfo[0].haveBXK;
                    txtBXKId.Text = tempUserInfo[0].BXKid;
                    string tempYear = tempUserInfo[0].Birthday.Substring(0, 4);
                    string tempMonth = tempUserInfo[0].Birthday.Substring(4, 2);
                    string tempDay = tempUserInfo[0].Birthday.Substring(6, 2);

                    dtpBirthDay.Value = DateTime.Parse(tempYear + "-" + tempMonth + "-" + tempDay);
                    txtUserTip.Text = tempUserInfo[0].UserTip;
                    cmbUserType.SelectedIndex = tempUserInfo[0].userType;

                    switch (tempUserInfo[0].GroupID)
                    {
                        case 15:
                            cmbGroup.SelectedIndex = 0;
                            break;
                        case 16:
                            cmbGroup.SelectedIndex = 1;
                            break;
                        case 17:
                            cmbGroup.SelectedIndex = 2;
                            break;
                        case 18:
                            cmbGroup.SelectedIndex = 3;
                            break;
                    }
                    txtUserName.Text = tempUserInfo[0].UserName;
                    txtUserCName.Text = tempUserInfo[0].UserCName;

                    MysqlController.LXPhones[] tempPhones = tempUserInfo[0].BuyPhones;

                    tempCPhones = tempPhones;

                    lsvPhones.Items.Clear();
                    //dgvPhones.Rows.Clear();
                    var dt = new DataTable();
                    dt.Columns.Add("PhoneID");
                    dt.Columns.Add("PhoneData");
                    dt.Columns.Add("PhoneBrand");
                    dt.Columns.Add("PhoneName");
                    dt.Columns.Add("PhoneIMEI");
                    dt.Columns.Add("PhonePrice");
                    dt.Columns.Add("PhoneRealPrice");
                    dt.Columns.Add("PhoneHasEquip");
                    dt.Columns.Add("PhoneSeller");
                    dt.Columns.Add("PhoneHasWarranty");
                    dt.Columns.Add("PhoneHasWarrantyType");
                    dt.Columns.Add("PhoneHasWarrantyDuration");
                    dt.Columns.Add("PhoneisDelete");
                    dt.Columns.Add("Phone_supplier");
                    dt.Columns.Add("Phone_EquipPrice");
                    dt.Columns.Add("Phone_EquipRealPrice");
                    dt.Columns.Add("PhoneisLegal");
                    dt.Columns.Add("PhoneisHKLegal");
                    dt.Columns.Add("PhoneisUnLegal");
                    dt.Columns.Add("PhoneWarrantyPrice");


                    for (int i = 0; i < tempPhones.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(tempPhones[i].PhoneID))
                        {
                            DataRow dr = dt.NewRow();
                            dr["PhoneID"] = tempPhones[i].PhoneID;
                            dr["PhoneData"] = tempPhones[i].PhoneDate;
                            dr["PhoneBrand"] = tempBrand[int.Parse(tempPhones[i].PhoneBrand)];
                            dr["PhoneName"] = tempPhones[i].PhoneName;
                            dr["PhoneIMEI"] = tempPhones[i].PhoneIMEI;
                            dr["PhonePrice"] = tempPhones[i].PhonePrice;
                            dr["PhoneRealPrice"] = tempPhones[i].PhoneRealPrice;
                            dr["PhoneHasEquip"] = tempPhones[i].PhoneHasEquip;
                            dr["PhoneSeller"] = tempSeller[int.Parse(tempPhones[i].PhoneSeller)];
                            dr["PhoneHasWarranty"] = tempPhones[i].PhoneHasWarranty;
                            dr["PhoneHasWarrantyType"] = tempPhones[i].PhoneWarrantyType;
                            dr["PhoneHasWarrantyDuration"] = tempPhones[i].PhoneWarrantyDuration;
                            dr["PhoneisDelete"] = tempPhones[i].PhoneIsDelete;
                            dr["Phone_supplier"] = tempPhones[i].phone_supplier;
                            dr["Phone_EquipPrice"] = tempPhones[i].PhoneEquipPrice;
                            dr["Phone_EquipRealPrice"] = tempPhones[i].PhoneEquipRealPrice;
                            dr["PhoneisLegal"] = tempPhones[i].PhoneIsLegal;
                            dr["PhoneisHKLegal"] = tempPhones[i].PhoneIsHKLegal;
                            dr["PhoneisUnLegal"] = tempPhones[i].PhoneIsUnLegal;
                            dr["PhoneWarrantyPrice"] = tempPhones[i].PhoneWarrantyPrice;
                            dt.Rows.Add(dr);
                        }
                        Application.DoEvents();
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow drOperate = dt.Rows[i];
                        lsvPhones.Items.Add(drOperate["PhoneData"].ToString());
                        lsvPhones.Items[i].SubItems.Add(drOperate["PhoneBrand"].ToString());
                        lsvPhones.Items[i].SubItems.Add(drOperate["PhoneName"].ToString());
                        lsvPhones.Items[i].SubItems.Add(drOperate["PhoneIMEI"].ToString());
                        lsvPhones.Items[i].SubItems.Add(drOperate["PhonePrice"].ToString());
                        lsvPhones.Items[i].SubItems.Add(drOperate["PhoneRealPrice"].ToString());
                        lsvPhones.Items[i].SubItems.Add(drOperate["PhoneHasEquip"].ToString() == "True"
                                                            ? Resources.frmEditCustem_cmdUpdate_Click_有
                                                            : "无");
                        lsvPhones.Items[i].SubItems.Add(drOperate["PhoneSeller"].ToString());
                        lsvPhones.Items[i].SubItems.Add(drOperate["PhoneHasWarranty"].ToString() == "True"
                                                            ? Resources.frmEditCustem_cmdUpdate_Click_有
                                                            : "无");
                        switch (drOperate["PhoneHasWarrantyType"].ToString())
                        {
                            case "0":
                                lsvPhones.Items[i].SubItems.Add("软件保修");
                                break;
                            case "1":
                                lsvPhones.Items[i].SubItems.Add("软硬全保");
                                break;
                            case "2":
                                lsvPhones.Items[i].SubItems.Add("延长保修");
                                break;
                            case "3":
                                lsvPhones.Items[i].SubItems.Add("无敌保修");
                                break;
                        }
                        switch (drOperate["PhoneHasWarrantyDuration"].ToString())
                        {
                            case "0":
                                lsvPhones.Items[i].SubItems.Add("一年");
                                break;
                            case "1":
                                lsvPhones.Items[i].SubItems.Add("两年");
                                break;
                            case "2":
                                lsvPhones.Items[i].SubItems.Add("三年");
                                break;
                            case "3":
                                lsvPhones.Items[i].SubItems.Add("终身");
                                break;
                        }
                        lsvPhones.Items[i].SubItems.Add(drOperate["PhoneisDelete"].ToString() == "True"
                                                            ? Resources.frmEditCustem_cmdUpdate_Click_有
                                                            : "无");
                        lsvPhones.Items[i].SubItems.Add(drOperate["Phone_supplier"].ToString());
                        lsvPhones.Items[i].SubItems.Add(drOperate["Phone_EquipPrice"].ToString());
                        lsvPhones.Items[i].SubItems.Add(drOperate["Phone_EquipRealPrice"].ToString());
                        if (drOperate["PhoneisLegal"].ToString() == "True")
                        {
                            lsvPhones.Items[i].SubItems.Add("国行");
                        }
                        else
                        {
                            if (drOperate["PhoneisHKLegal"].ToString() == "True")
                            {
                                lsvPhones.Items[i].SubItems.Add("港行");
                            }
                            else
                            {
                                if (drOperate["PhoneisUnLegal"].ToString() == "True")
                                {
                                    lsvPhones.Items[i].SubItems.Add("水货");
                                }
                                else
                                {
                                    lsvPhones.Items[i].SubItems.Add("水货");
                                }
                            }
                        }

                        lsvPhones.Items[i].SubItems.Add(drOperate["PhoneWarrantyPrice"].ToString());
                        lsvPhones.Items[i].SubItems.Add(drOperate["PhoneID"].ToString());
                        Application.DoEvents();
                    }


                    cmdAddPhone.Enabled = true;
                    cmdDelete.Enabled = true;
                    cmdChange.Enabled = true;
                    cmdDeletePhone.Enabled = true;
                    cmdEdit.Enabled = true;
                    cmdDeleteCustom.Enabled = true;
                    cmdPhone.Enabled = true;
                    cmdUpdate.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(Resources.frmEditCustem_cmdSearch_Click_ + tempUsers.ErrString);
            }
            isBusy.Visible = false;
            cmdSearch.Enabled = true;
        }

        //private delegate MysqlController.ReturnResult DelegateUpdatePhoneByID(MysqlController.LXPhones tempPhone);

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            //判断输入项正确性
            if (txtPhone.Text == "" || !Regex.IsMatch(txtPhone.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmEditCustem_cmdUpdate_Click_请填写正确的手机号码_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            if (ckbIsBXK.Checked && txtBXKId.Text == "")
            {
                MessageBox.Show(Resources.frmEditCustem_cmdUpdate_Click_已经勾选保修卡_但未填写保修卡编号_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }


            cmdUpdate.Enabled = false;
            isBusy.Visible = true;
            var TempUser = new MysqlController.LXUser
                               {
                                   BXKid = txtBXKId.Text,
                                   ContectAddress = txtContectAddress.Text,
                                   Email = txtEmail.Text,
                                   haveBXK = ckbIsBXK.Checked,
                                   LXCredit = txtLXCredit.Text,
                                   Phone = txtPhone.Text,
                                   Telephone = txtTelephone.Text,
                                   QQ = txtQQ.Text,
                                   UserCName = txtUserCName.Text,
                                   UserName = txtUserName.Text,
                                   UserTip = txtUserTip.Text
                               };
            switch (cmbGroup.SelectedIndex)
            {
                case 0:
                    TempUser.GroupID = 15;
                    break;
                case 1:
                    TempUser.GroupID = 16;
                    break;
                case 2:
                    TempUser.GroupID = 17;
                    break;
                case 3:
                    TempUser.GroupID = 18;
                    break;
                default:
                    TempUser.GroupID = 0;
                    break;
            }
            TempUser.Birthday = dtpBirthDay.Value.Year + dtpBirthDay.Value.Month.ToString().PadLeft(2, '0') +
                                dtpBirthDay.Value.Day.ToString().PadLeft(2, '0');

            var iPhones = new MysqlController.LXPhones[lsvPhones.Items.Count];
            var iEPhones = new MysqlController.LXPhones[lsvPhones.Items.Count];

            int Creidt = 0;

            for (int i = 0; i < iPhones.Length; i++)
            {
                iPhones[i].PhoneDate = lsvPhones.Items[i].Text;

                for (int j = 0; j < tempBrand.Length; j++)
                {
                    if (tempBrand[j] == lsvPhones.Items[i].SubItems[1].Text)
                    {
                        iPhones[i].PhoneBrand = j.ToString();
                    }
                    Application.DoEvents();
                }

                iPhones[i].PhoneName = lsvPhones.Items[i].SubItems[2].Text;
                iPhones[i].PhoneIMEI = lsvPhones.Items[i].SubItems[3].Text;
                iPhones[i].PhonePrice = lsvPhones.Items[i].SubItems[4].Text;
                Creidt = Creidt + int.Parse(lsvPhones.Items[i].SubItems[4].Text);
                iPhones[i].PhoneRealPrice = lsvPhones.Items[i].SubItems[5].Text;
                iPhones[i].PhoneHasEquip = lsvPhones.Items[i].SubItems[6].Text ==
                                           Resources.frmEditCustem_cmdUpdate_Click_有;

                for (int j = 0; j < tempSeller.Length; j++)
                {
                    if (tempSeller[j] == lsvPhones.Items[i].SubItems[7].Text)
                    {
                        iPhones[i].PhoneSeller = j.ToString();
                    }
                    Application.DoEvents();
                }

                iPhones[i].PhoneHasWarranty = lsvPhones.Items[i].SubItems[8].Text ==
                                              Resources.frmEditCustem_cmdUpdate_Click_有;

                switch (lsvPhones.Items[i].SubItems[9].Text)
                {
                    case "软件保修":
                        iPhones[i].PhoneWarrantyType = "0";
                        break;
                    case "软硬全保":
                        iPhones[i].PhoneWarrantyType = "1";
                        break;
                    case "延长保修":
                        iPhones[i].PhoneWarrantyType = "2";
                        break;
                    case "无敌保修":
                        iPhones[i].PhoneWarrantyType = "3";
                        break;
                }

                switch (lsvPhones.Items[i].SubItems[10].Text)
                {
                    case "一年":
                        iPhones[i].PhoneWarrantyDuration = "0";
                        break;
                    case "两年":
                        iPhones[i].PhoneWarrantyDuration = "1";
                        break;
                    case "三年":
                        iPhones[i].PhoneWarrantyDuration = "2";
                        break;
                    case "终身":
                        iPhones[i].PhoneWarrantyDuration = "3";
                        break;
                }
                iPhones[i].PhoneWarrantyDate = iPhones[i].PhoneDate;
                iPhones[i].PhoneIsDelete = lsvPhones.Items[i].SubItems[11].Text ==
                                           Resources.frmEditCustem_cmdUpdate_Click_有;
                iPhones[i].phone_supplier = lsvPhones.Items[i].SubItems[12].Text;
                iPhones[i].PhoneEquipPrice = lsvPhones.Items[i].SubItems[13].Text;
                iPhones[i].PhoneEquipRealPrice = lsvPhones.Items[i].SubItems[14].Text;

                switch (lsvPhones.Items[i].SubItems[15].Text)
                {
                    case "国行":
                        iPhones[i].PhoneIsLegal = true;
                        iPhones[i].PhoneIsHKLegal = false;
                        iPhones[i].PhoneIsUnLegal = false;
                        break;
                    case "港行":
                        iPhones[i].PhoneIsLegal = false;
                        iPhones[i].PhoneIsHKLegal = true;
                        iPhones[i].PhoneIsUnLegal = false;
                        break;
                    case "水货":
                        iPhones[i].PhoneIsLegal = false;
                        iPhones[i].PhoneIsHKLegal = false;
                        iPhones[i].PhoneIsUnLegal = true;
                        break;
                    default:
                        iPhones[i].PhoneIsLegal = false;
                        iPhones[i].PhoneIsHKLegal = false;
                        iPhones[i].PhoneIsUnLegal = true;

                        break;
                }

                iPhones[i].PhoneWarrantyPrice = lsvPhones.Items[i].SubItems[16].Text;


                try
                {
                    iPhones[i].PhoneID = lsvPhones.Items[i].SubItems[17].Text;
                }
                catch (Exception)
                {
                    iPhones[i].PhoneID = "";
                }

                try
                {
                    iPhones[i].PhonePayment = int.Parse(lsvPhones.Items[i].SubItems[18].Text);
                }
                catch (Exception)
                {
                    iPhones[i].PhonePayment = 0;
                }

                try
                {
                    iPhones[i].phoneUnDebtPrice = lsvPhones.Items[i].SubItems[19].Text;
                }
                catch (Exception)
                {
                    iPhones[i].phoneUnDebtPrice = "0";
                }

                if (lsvPhones.Items[i].ForeColor == Color.DarkBlue)
                {
                    iEPhones[i] = iPhones[i];
                }
                Application.DoEvents();
            }
            TempUser.LXCredit = Creidt.ToString();
            TempUser.BuyPhones = iPhones;
            TempUser.UserID = int.Parse(txtID.Text);

            DelegateEditUser dn = MysqlControl.EditUser;

            IAsyncResult iar = dn.BeginInvoke(TempUser, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

            if (iResult.isSuccess)
            {
                var iEResult = new MysqlController.ReturnResult[iEPhones.Length];

                for (int i = 0; i < iEPhones.Length; i++)
                {
                    iEResult[i].isSuccess = true;
                    if (!string.IsNullOrEmpty(iEPhones[i].PhoneID))
                    {
                        DelegateUpdatePhoneByID dn1 = MysqlControl.UpdatePhoneByID;

                        IAsyncResult iar1 = dn1.BeginInvoke(iEPhones[i], null, null);

                        while (iar1.IsCompleted == false)
                        {
                            Application.DoEvents();
                        }

                        iEResult[i] = dn1.EndInvoke(iar1);
                    }
                    Application.DoEvents();
                }

                bool editOK = true;
                string ErrString = "";

                for (int i = 0; i < iEResult.Length; i++)
                {
                    if (iEResult[i].isSuccess) continue;
                    editOK = false;
                    ErrString = ErrString + iEResult[i].ErrDesc;
                }
                if (editOK)
                {
                    //这里核算盈亏
                    for (int i = 0; i < iEPhones.Length; i++)
                    {
                        if (string.IsNullOrEmpty(iEPhones[i].PhoneID)) continue;
                        int ChangePrice = (int.Parse(tempCPhones[i].PhonePrice) - int.Parse(iEPhones[i].PhonePrice)) +
                                          (int.Parse(tempCPhones[i].PhoneEquipPrice) -
                                           int.Parse(iEPhones[i].PhoneEquipPrice) +
                                           int.Parse(tempCPhones[i].PhoneWarrantyPrice) -
                                           int.Parse(iEPhones[i].PhoneWarrantyPrice));

                        int ChangePriceDebt = ChangePrice + int.Parse(iEPhones[i].phoneUnDebtPrice);
                        if (iEPhones[i].PhonePayment == 0 && ChangePrice != 0)
                        {
                            var iPayout = new MysqlController.Payout
                                              {
                                                  PayoutBackup =
                                                      "客户" + txtUserCName.Text + "进行了换机操作: 从" +
                                                      tempCPhones[i].PhoneName +
                                                      " 换至 " + iEPhones[i].PhoneName,
                                                  PayoutName = "换机操作",
                                                  PayoutPrice = ChangePrice.ToString(),
                                                  PayoutInCase = true
                                                  //PayoutType = cmbPayType.SelectedIndex.ToString()
                                              };

                            iPayout.PayoutType = iPayout.PayoutPrice.Substring(0, 1) == "-" ? "2" : "0";

                            iPayout.PayoutDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                                 DateTime.Now.Day.ToString().PadLeft(2, '0');
                            var iDResult = new MysqlController.ReturnResult {isSuccess = false};
                            while (!iDResult.isSuccess)
                            {
                                DelegateAddPayout dn2 = MysqlControl.AddPayout;

                                IAsyncResult iar2 = dn2.BeginInvoke(iPayout, null, null);

                                while (iar2.IsCompleted == false)
                                {
                                    Application.DoEvents();
                                }

                                iDResult = dn2.EndInvoke(iar2);
                            }
                        }

                            //MysqlController.ReturnResult iResult = MysqlControl.AddPayout(iPayout);
                        else
                        {
                            //if (iEPhones[i].PhonePayment == 0) continue;
                            if (ChangePriceDebt < 0)
                            {
                                var iCustomDebt = new MysqlController.LXCustomDebt
                                                      {
                                                          DebtCustom = txtUserCName.Text,
                                                          DebtType = iEPhones[i].PhonePayment - 1,
                                                          DebtDate =
                                                              DateTime.Now.Year +
                                                              DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                                              DateTime.Now.Day.ToString().PadLeft(2, '0'),
                                                          DebtDetail = "换机操作:" + iEPhones[i].PhoneName,
                                                          DebtisFix = false,
                                                          DebtPhoneID = int.Parse(iEPhones[i].PhoneID),
                                                          DebtPrice = -ChangePriceDebt,
                                                          DebtFixDate =
                                                              DateTime.Now.Year +
                                                              DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                                              DateTime.Now.Day.ToString().PadLeft(2, '0')
                                                      };
                                var iDResult = new MysqlController.ReturnResult {isSuccess = false};
                                while (!iDResult.isSuccess)
                                {
                                    DelegateAddCustomDebt dnac = MysqlControl.AddCustomDebt;

                                    IAsyncResult iarac = dnac.BeginInvoke(iCustomDebt, null, null);

                                    while (iarac.IsCompleted == false)
                                    {
                                        Application.DoEvents();
                                    }

                                    iDResult = dnac.EndInvoke(iarac);
                                }

                                var iPayout = new MysqlController.Payout
                                                  {
                                                      PayoutBackup =
                                                          "客户" + txtUserCName.Text + "进行了换机操作: 从" +
                                                          tempCPhones[i].PhoneName +
                                                          " 换至 " + iEPhones[i].PhoneName,
                                                      PayoutName = "换机操作",
                                                      PayoutPrice =
                                                          (-int.Parse(iEPhones[i].phoneUnDebtPrice)).ToString(),
                                                      PayoutInCase = true
                                                  };
                                iPayout.PayoutType = iPayout.PayoutPrice.Substring(0, 1) == "-" ? "2" : "0";
                                iPayout.PayoutDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                                     DateTime.Now.Day.ToString().PadLeft(2, '0');
                                var iXResult = new MysqlController.ReturnResult {isSuccess = false};
                                while (!iXResult.isSuccess)
                                {
                                    DelegateAddPayout dnap = MysqlControl.AddPayout;

                                    IAsyncResult iarap = dnap.BeginInvoke(iPayout, null, null);

                                    while (iarap.IsCompleted == false)
                                    {
                                        Application.DoEvents();
                                    }

                                    iXResult = dnap.EndInvoke(iarap);
                                }
                            }
                        }
                    }

                    //这里给新增的手机增加欠款

                    for (int i = 0; i < iPhones.Length; i++)
                    {
                        if (iPhones[i].PhoneID == "" && iPhones[i].PhonePayment != 0)
                        {
                            var iCustomDebt = new MysqlController.LXCustomDebt
                                                  {
                                                      DebtCustom = txtUserCName.Text,
                                                      DebtType = iPhones[i].PhonePayment - 1,
                                                      DebtDate = iPhones[i].PhoneDate,
                                                      DebtDetail = "购买手机:" + iPhones[i].PhoneName,
                                                      DebtisFix = false,
                                                      DebtPhoneID = 0,
                                                      DebtPrice = (int.Parse(iPhones[i].PhonePrice) +
                                                                   int.Parse(iPhones[i].PhoneWarrantyPrice) +
                                                                   int.Parse(iPhones[i].PhoneEquipPrice) -
                                                                   int.Parse(iPhones[i].phoneUnDebtPrice)),
                                                      DebtFixDate =
                                                          DateTime.Now.Year +
                                                          DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                                          DateTime.Now.Day.ToString().PadLeft(2, '0')
                                                  };
                            //iCustomDebt.DebtPhoneID = int.Parse(iEPhones[i].PhoneID);
                            var iDResult = new MysqlController.ReturnResult {isSuccess = false};

                            while (!iDResult.isSuccess)
                            {
                                DelegateAddCustomDebt dncd = MysqlControl.AddCustomDebt;

                                IAsyncResult iarcd = dncd.BeginInvoke(iCustomDebt, null, null);

                                while (iarcd.IsCompleted == false)
                                {
                                    Application.DoEvents();
                                }

                                iDResult = dncd.EndInvoke(iarcd);
                            }
                        }
                    }

                    var iLog = new clsLog.LogPart();

                    iLog.LogDate = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                   DateTime.Now.Day.ToString().PadLeft(2, '0');
                    iLog.LogTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                    iLog.LogUser = iLoginUser;
                    iLog.LogDetail = @"修改用户:" + txtUserCName.Text;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    MessageBox.Show(Resources.frmEditCustem_cmdUpdate_Click_修改用户成功_, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(Resources.frmEditCustem_cmdUpdate_Click_ + ErrString, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show(Resources.frmEditCustem_cmdUpdate_Click_ + iResult.ErrDesc, Application.ProductName,
                                MessageBoxButtons.OK);
            }

            cmdUpdate.Enabled = true;
            isBusy.Visible = false;
        }

        public void SetCustom(MysqlController.LXUser tempUser)
        {
            isSetFlag = true;
            SetUser = tempUser;
        }

        public void SetCustomCard(string CardID)
        {
            txtBXKId.Text = CardID;
            cmdSearch_Click(null, null);
        }

        private void frmEditCustem_Shown(object sender, EventArgs e)
        {
            isBusy.Visible = true;

            DelegateManufacturer dn = MysqlControl.Manufacturer;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempBrand = dn.EndInvoke(iar);

            DelegateSellers dn2 = MysqlControl.Sellers;

            IAsyncResult iar2 = dn2.BeginInvoke(null, null);

            while (iar2.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempSeller = dn2.EndInvoke(iar2);

            isBusy.Visible = false;

            if (!isSetFlag) return;
            txtPhone.Text = SetUser.Phone;
            txtUserCName.Text = SetUser.UserCName;
            txtBXKId.Text = SetUser.BXKid;
            cmdSearch_Click(sender, e);
        }

        private void cmdAddPhone_Click(object sender, EventArgs e)
        {
            //this.Enabled = false;
            var iAdd = new frmAddPhone {Location = lsvPhones.Location};

            Point p = PointToScreen(lsvPhones.Location);

            iAdd.SetDesktopBounds(p.X + groupBox3.Location.X, p.Y + groupBox3.Location.Y, iAdd.Width, iAdd.Height);
            if (iAdd.ShowDialog() != DialogResult.OK) return;
            //iAdd.iPhones
            MysqlController.LXPhones tempPhone = iAdd.GetRespos();
            var iItem = new ListViewItem {Text = tempPhone.PhoneDate};

            iItem.SubItems.Add(tempBrand[int.Parse(tempPhone.PhoneBrand)]);
            iItem.SubItems.Add(tempPhone.PhoneName);
            iItem.SubItems.Add(tempPhone.PhoneIMEI);
            iItem.SubItems.Add(tempPhone.PhonePrice);
            iItem.SubItems.Add(tempPhone.PhoneRealPrice);
            iItem.SubItems.Add(tempPhone.PhoneHasEquip ? Resources.frmEditCustem_cmdUpdate_Click_有 : "无");
            iItem.SubItems.Add(tempSeller[int.Parse(tempPhone.PhoneSeller)]);

            iItem.SubItems.Add(tempPhone.PhoneHasWarranty ? Resources.frmEditCustem_cmdUpdate_Click_有 : "无");
            switch (tempPhone.PhoneWarrantyType)
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
            switch (tempPhone.PhoneWarrantyDuration)
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
            iItem.SubItems.Add("无");
            iItem.SubItems.Add(tempPhone.phone_supplier);
            iItem.SubItems.Add(tempPhone.PhoneEquipPrice);
            iItem.SubItems.Add(tempPhone.PhoneEquipRealPrice);
            if (tempPhone.PhoneIsLegal)
            {
                iItem.SubItems.Add("国行");
            }
            if (tempPhone.PhoneIsHKLegal)
            {
                iItem.SubItems.Add("港行");
            }
            if (tempPhone.PhoneIsUnLegal)
            {
                iItem.SubItems.Add("水货");
            }
            iItem.SubItems.Add(tempPhone.PhoneWarrantyPrice);
            iItem.SubItems.Add("");
            iItem.SubItems.Add(tempPhone.PhonePayment.ToString());
            iItem.SubItems.Add(tempPhone.phoneUnDebtPrice);
            lsvPhones.Items.Add(iItem);
            //this.Enabled = true;
        }

        private void cmdPhone_Click(object sender, EventArgs e)
        {
            try
            {
                int tempID = int.Parse(lsvPhones.SelectedItems[0].SubItems[17].Text);
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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            //this.Enabled = false;
            cmdDelete.Enabled = false;
            try
            {
                lsvPhones.SelectedItems[0].Remove();
            }
            catch (Exception)
            {
                cmdDelete.Enabled = true;
                return;
            }
            cmdDelete.Enabled = true;
            //Enabled = true;
        }

        private void cmdChange_Click(object sender, EventArgs e)
        {
            //this.Enabled = false;
            cmdChange.Enabled = false;
            try
            {
                var iAdd = new frmAddPhone {Location = lsvPhones.Location};

                Point p = PointToScreen(lsvPhones.Location);
                iAdd.IsEditMode = true;
                iAdd.iPhones = tempCPhones[lsvPhones.SelectedItems[0].Index];
                //tempIndex = lsvPhones.SelectedItems[0].Index;
                iAdd.SetDesktopBounds(p.X + groupBox3.Location.X, p.Y + groupBox3.Location.Y, iAdd.Width, iAdd.Height);
                if (iAdd.ShowDialog() == DialogResult.OK)
                {
                    lsvPhones.SelectedItems[0].Remove();
                    MysqlController.LXPhones tempPhone = iAdd.GetRespos();


                    var iItem = new ListViewItem {Text = tempPhone.PhoneDate, ForeColor = Color.DarkBlue};

                    iItem.SubItems.Add(tempBrand[int.Parse(tempPhone.PhoneBrand)]);
                    iItem.SubItems.Add(tempPhone.PhoneName);
                    iItem.SubItems.Add(tempPhone.PhoneIMEI);
                    iItem.SubItems.Add(tempPhone.PhonePrice);
                    iItem.SubItems.Add(tempPhone.PhoneRealPrice);
                    iItem.SubItems.Add(tempPhone.PhoneHasEquip ? Resources.frmEditCustem_cmdUpdate_Click_有 : "无");
                    iItem.SubItems.Add(tempSeller[int.Parse(tempPhone.PhoneSeller)]);

                    iItem.SubItems.Add(tempPhone.PhoneHasWarranty ? Resources.frmEditCustem_cmdUpdate_Click_有 : "无");
                    switch (tempPhone.PhoneWarrantyType)
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
                    switch (tempPhone.PhoneWarrantyDuration)
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
                    iItem.SubItems.Add("无");
                    iItem.SubItems.Add(tempPhone.phone_supplier);
                    iItem.SubItems.Add(tempPhone.PhoneEquipPrice);
                    iItem.SubItems.Add(tempPhone.PhoneEquipRealPrice);
                    if (tempPhone.PhoneIsLegal)
                    {
                        iItem.SubItems.Add("国行");
                    }
                    if (tempPhone.PhoneIsHKLegal)
                    {
                        iItem.SubItems.Add("港行");
                    }
                    if (tempPhone.PhoneIsUnLegal)
                    {
                        iItem.SubItems.Add("水货");
                    }
                    iItem.SubItems.Add(tempPhone.PhoneWarrantyPrice);
                    iItem.SubItems.Add(tempPhone.PhoneID);
                    iItem.SubItems.Add(tempPhone.PhonePayment.ToString());
                    iItem.SubItems.Add(tempPhone.phoneUnDebtPrice);
                    lsvPhones.Items.Add(iItem);
                }
            }
            catch (Exception)
            {
                cmdChange.Enabled = true;
                return;
            }
            cmdChange.Enabled = true;
            // this.Enabled = true;
        }

        private void cmdDeletePhone_Click(object sender, EventArgs e)
        {
            cmdDeletePhone.Enabled = false;
            if (
                MessageBox.Show("是否在数据库中彻底删除选择的手机项目(连带其产生的客户欠款)?", Application.ProductName, MessageBoxButtons.OKCancel) ==
                DialogResult.OK)
            {
                try
                {
                    int PhoneID = int.Parse(lsvPhones.SelectedItems[0].SubItems[17].Text);

                    isBusy.Visible = true;

                    DelegateDeletePhone dn = MysqlControl.DeletePhone;

                    IAsyncResult iar = dn.BeginInvoke(PhoneID, int.Parse(txtID.Text), null, null);

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
                        iLog.LogDetail = @"删除客户" + txtUserCName.Text + "归属手机编号:" + PhoneID;

                        DelegateAddLog dnlog = LogControl.AddLog;

                        IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                        while (iarlog.IsCompleted == false)
                        {
                            Application.DoEvents();
                        }

                        dnlog.EndInvoke(iarlog);

                        MessageBox.Show(Resources.frmEditCustem_cmdDeletePhone_Click_永久删除该手机成功_, Application.ProductName,
                                        MessageBoxButtons.OK);
                        lsvPhones.SelectedItems[0].Remove();
                        cmdUpdate_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(Resources.frmEditCustem_cmdDeletePhone_Click_永久删除该手机失败__失败原因_ + iResult.ErrDesc,
                                        Application.ProductName, MessageBoxButtons.OK);
                    }
                }
                catch (Exception)
                {
                    cmdDeletePhone.Enabled = true;

                    isBusy.Visible = false;
                    return;
                }
            }
            //Enabled = true;
            cmdDeletePhone.Enabled = true;
        }

        private void cmdDeleteCustom_Click(object sender, EventArgs e)
        {
            cmdDeleteCustom.Enabled = false;
            try
            {
                int userID = int.Parse(txtID.Text);
                isBusy.Visible = true;
                DelegateDeleteUser dn = MysqlControl.DeleteUser;

                IAsyncResult iar = dn.BeginInvoke(userID, null, null);

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
                    iLog.LogDetail = @"删除客户" + txtUserCName.Text;

                    DelegateAddLog dnlog = LogControl.AddLog;

                    IAsyncResult iarlog = dnlog.BeginInvoke(iLog, null, null);

                    while (iarlog.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    dnlog.EndInvoke(iarlog);

                    MessageBox.Show(Resources.frmEditCustem_cmdDeleteCustom_Click_永久删除用户成功_, Application.ProductName,
                                    MessageBoxButtons.OK);
                    var iCustem = new frmEditCustem(isBusy, iLoginUser)
                                      {TopLevel = false, Dock = DockStyle.Fill, Parent = Parent};
                    iCustem.Show();
                    iCustem.BringToFront();
                    Parent.BringToFront();
                }
                else
                {
                    MessageBox.Show(Resources.frmEditCustem_cmdDeleteCustom_Click_永久删除用户失败__错误原因_ + iResult.ErrDesc,
                                    Application.ProductName, MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                cmdDeleteCustom.Enabled = true;
                isBusy.Visible = false;
                return;
            }
            cmdDeleteCustom.Enabled = true;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            cmdEdit.Enabled = false;
            try
            {
                var iAdd = new frmAddPhone {Location = lsvPhones.Location};

                Point p = PointToScreen(lsvPhones.Location);
                iAdd.IsEditMode = true;
                iAdd.iPhones = tempCPhones[lsvPhones.SelectedItems[0].Index];
                //tempIndex = lsvPhones.SelectedItems[0].Index;
                iAdd.SetDesktopBounds(p.X + groupBox3.Location.X, p.Y + groupBox3.Location.Y, iAdd.Width, iAdd.Height);
                if (iAdd.ShowDialog() == DialogResult.OK)
                {
                    //lsvPhones.SelectedItems[0].Remove();
                    isBusy.Visible = true;
                    MysqlController.LXPhones tempPhone = iAdd.GetRespos();
                    var iDResult = new MysqlController.ReturnResult {isSuccess = false};
                    while (!iDResult.isSuccess)
                    {
                        DelegateUpdatePhoneByID dn = MysqlControl.UpdatePhoneByID;

                        IAsyncResult iar = dn.BeginInvoke(tempPhone, null, null);

                        while (iar.IsCompleted == false)
                        {
                            Application.DoEvents();
                        }

                        iDResult = dn.EndInvoke(iar);
                    }
                    isBusy.Visible = false;
                    cmdSearch_Click(sender, e);
                }
                MessageBox.Show("修改该手机成功! (仅修改手机属性,不涉及其他操作)", Application.ProductName, MessageBoxButtons.OK);
            }
            catch (Exception)

            {
                cmdEdit.Enabled = true;
                isBusy.Visible = false;
                return;
            }
            cmdEdit.Enabled = true;
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

        #region Nested type: DelegateDeletePhone

        private delegate MysqlController.ReturnResult DelegateDeletePhone(int phone_id, int userid);

        #endregion

        #region Nested type: DelegateDeleteUser

        private delegate MysqlController.ReturnResult DelegateDeleteUser(int UserID);

        #endregion

        #region Nested type: DelegateEditUser

        private delegate MysqlController.ReturnResult DelegateEditUser(MysqlController.LXUser TempUser);

        #endregion

        #region Nested type: DelegateGetSingleUser

        private delegate MysqlController.ReturnUsers DelegateGetSingleUser(
            string UserCName, string UserPhone, string UserBXKId);

        #endregion

        #region Nested type: DelegateManufacturer

        private delegate string[] DelegateManufacturer();

        #endregion

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion

        #region Nested type: DelegateUpdatePhoneByID

        private delegate MysqlController.ReturnResult DelegateUpdatePhoneByID(MysqlController.LXPhones tempPhone);

        #endregion
    }
}