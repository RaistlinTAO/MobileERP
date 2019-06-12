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
    using System.Data;
    using System.Windows.Forms;
    using DataControler.Mysql;

    #endregion

    public partial class frmSearchCustom : Form
    {
        private readonly string[] MixUser = new string[100000];
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string[] SecMixUser = new string[100000];

        public frmSearchCustom()
        {
            InitializeComponent();
        }

        private void frmSearchCustom_Load(object sender, EventArgs e)
        {
            try
            {
                string[] tempManu = MysqlControl.Manufacturer();
                for (int i = 0; i < tempManu.Length; i++)
                {
                    if (tempManu[i] != null)
                    {
                        cmbPhoneType.Items.Add(tempManu[i]);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("!", Application.ProductName, MessageBoxButtons.OK);
            }
            cmbGroup.SelectedIndex = 0;
            cmbPhoneType.SelectedIndex = 0;
            cmbPhoneName.SelectedIndex = 0;
            cmbNetwork.SelectedIndex = 0;
            cmbBXK.SelectedIndex = 0;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            lsvUser.Items.Clear();


            MysqlController.ReturnUsers tempUser = MysqlControl.SearchUser(cmbGroup.SelectedIndex, cmbBXK.SelectedIndex);

            int pos = 0;

            if (tempUser.isError != true)
            {
                if (tempUser.UserNum > 0)
                {
                    for (int i = 0; i < tempUser.UserNum; i++)
                    {
                        if (tempUser.UserInfo[i].iFlag)
                        {
                            //开始筛选
                            for (int j = 0; j < tempUser.UserInfo[i].BuyPhones.Length; j++)
                            {
                                if (cmbPhoneType.SelectedIndex != 0 || cmbPhoneType.SelectedIndex != -1)
                                {
                                    //筛选制定品牌
                                    if (tempUser.UserInfo[i].BuyPhones[j].PhoneBrand ==
                                        (cmbPhoneType.SelectedIndex - 1).ToString())
                                    {
                                        //筛选具体手机型号
                                        if (cmbPhoneType.SelectedIndex != -1)
                                        {
                                            if (tempUser.UserInfo[i].BuyPhones[j].PhoneName == cmbPhoneName.Text)
                                            {
                                                MixUser[pos] = i.ToString();
                                            }
                                        }
                                        else
                                        {
                                            MixUser[pos] = i.ToString();
                                        }
                                    }
                                }
                            }
                            pos++;
                        }

                        pos = 0;

                        if (cmbNetwork.SelectedIndex != 0 || cmbNetwork.SelectedIndex != -1)
                        {
                            switch (cmbNetwork.SelectedIndex)
                            {
                                case 1:
                                    for (int j = 0; j < MixUser.Length; j++)
                                    {
                                        if (MixUser[j] != null && MixUser[j] != "")
                                        {
                                            if (!string.IsNullOrEmpty(tempUser.UserInfo[int.Parse(MixUser[j])].Phone))
                                            {
                                                switch (tempUser.UserInfo[int.Parse(MixUser[j])].Phone.Substring(0, 3))
                                                {
                                                    case "135":
                                                    case "136":
                                                    case "137":
                                                    case "138":
                                                    case "139":
                                                    case "150":
                                                    case "151":
                                                    case "157":
                                                    case "158":
                                                    case "159":
                                                    case "188":
                                                        SecMixUser[pos] = j.ToString();
                                                        break;
                                                }
                                                switch (tempUser.UserInfo[int.Parse(MixUser[j])].Phone.Substring(0, 4))
                                                {
                                                    case "1340":
                                                    case "1341":
                                                    case "1342":
                                                    case "1343":
                                                    case "1344":
                                                    case "1345":
                                                    case "1346":
                                                    case "1347":
                                                    case "1348":
                                                        SecMixUser[pos] = j.ToString();
                                                        break;
                                                }

                                                pos++;
                                            }
                                        }
                                    }
                                    break;
                                case 2:
                                    for (int j = 0; j < MixUser.Length; j++)
                                    {
                                        if (MixUser[j] != null && MixUser[j] != "")
                                        {
                                            if (!string.IsNullOrEmpty(tempUser.UserInfo[int.Parse(MixUser[j])].Phone))
                                            {
                                                switch (tempUser.UserInfo[int.Parse(MixUser[j])].Phone.Substring(0, 3))
                                                {
                                                    case "130":
                                                    case "131":
                                                    case "132":
                                                    case "156":
                                                        SecMixUser[pos] = j.ToString();
                                                        break;
                                                }
                                                switch (tempUser.UserInfo[int.Parse(MixUser[j])].Phone.Substring(0, 4))
                                                {
                                                    case "1349":
                                                        SecMixUser[pos] = j.ToString();
                                                        break;
                                                }
                                                pos++;
                                            }
                                        }
                                    }
                                    break;
                                case 3:
                                    for (int j = 0; j < MixUser.Length; j++)
                                    {
                                        if (MixUser[j] != null && MixUser[j] != "")
                                        {
                                            if (!string.IsNullOrEmpty(tempUser.UserInfo[int.Parse(MixUser[j])].Phone))
                                            {
                                                switch (tempUser.UserInfo[int.Parse(MixUser[j])].Phone.Substring(0, 3))
                                                {
                                                    case "133":
                                                    case "153":
                                                    case "187":
                                                    case "189":
                                                        SecMixUser[pos] = j.ToString();
                                                        break;
                                                }
                                                pos++;
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                    }

                    /*
                     移动：1340-1348，135，136，137，138，139，150，151，159，158，157（3G号码段），188（3G号码段已经审批下来了）
联通：130，131，131，156，1349
中国电信（CDMA号码段已经是它的了）133，153，187，189 
                     */

                    for (int i = 0; i < SecMixUser.Length; i++)
                    {
                        if (SecMixUser[i] != null && SecMixUser[i] != "")
                        {
                            lsvUser.Items.Add(tempUser.UserInfo[i].UserCName);
                            lsvUser.Items[i].SubItems.Add(tempUser.UserInfo[i].UserName);
                            lsvUser.Items[i].SubItems.Add(tempUser.UserInfo[i].Phone);
                            lsvUser.Items[i].SubItems.Add("");
                            lsvUser.Items[i].SubItems.Add("");
                            lsvUser.Items[i].SubItems.Add(tempUser.UserInfo[i].LXCredit);
                            lsvUser.Items[i].SubItems.Add(tempUser.UserInfo[i].haveBXK ? "有" : "没有");
                            lsvUser.Items[i].SubItems.Add(tempUser.UserInfo[i].BXKid);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("搜索不到任何符合条件的用户,请重试!", Application.ProductName, MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("搜索用户失败!请重试", Application.ProductName, MessageBoxButtons.OK);
            }
        }

        private void cmbPhoneType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPhoneName.Items.Clear();
            DataTable tempBPhones = MysqlControl.ReadPhones(cmbPhoneType.SelectedIndex);

            cmbPhoneName.Items.Clear();
            cmbPhoneName.Items.Add("不定义");
            for (int i = 0; i < tempBPhones.Rows.Count; i++)
            {
                DataRow drOperate = tempBPhones.Rows[i];
                cmbPhoneName.Items.Add(drOperate["PhoneName"]);
            }
        }
    }
}