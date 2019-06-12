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
namespace LongXiangTutorialController.View
{
    #region

    using System;
    using System.Windows.Forms;
    using DataControler.Mysql;

    #endregion

    public partial class frmTutorialDetail : Form
    {
        //private bool iEditMode;
        private MysqlController.LXTutorial iTutorial;

        public frmTutorialDetail(bool iEdit, MysqlController.LXTutorial tempTutorial)
        {
            //iEditMode = iEdit;
            iTutorial = tempTutorial;
            InitializeComponent();
        }

        private void frmTutorialDetail_Shown(object sender, EventArgs e)
        {
            cmbType.Text = iTutorial.iType;
            if (cmbType.SelectedIndex != 4)
            {
                cmbSubType.Text = iTutorial.iSubType;
            }
            txtTitle.Text = iTutorial.iTTitle;
            wbContent.DocumentText = iTutorial.iTContent;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSubType.Items.Clear();
            switch (cmbType.SelectedIndex)
            {
                case 0:
                    cmbSubType.Items.Add("新手入门");
                    cmbSubType.Items.Add("刷机破解");
                    cmbSubType.Items.Add("软件游戏安装");
                    cmbSubType.Items.Add("使用技巧");
                    cmbSubType.Items.Add("错误分析");
                    break;
                case 1:
                    cmbSubType.Items.Add("越狱教程");
                    cmbSubType.Items.Add("解锁教程");
                    cmbSubType.Items.Add("备份SHSH");
                    cmbSubType.Items.Add("软件游戏安装");
                    cmbSubType.Items.Add("使用技巧");
                    cmbSubType.Items.Add("错误分析");
                    break;
                case 2:
                    cmbSubType.Items.Add("系统美化");
                    cmbSubType.Items.Add("刷机教程");
                    cmbSubType.Items.Add("手机优化");
                    cmbSubType.Items.Add("软件游戏安装");
                    cmbSubType.Items.Add("使用技巧");
                    cmbSubType.Items.Add("错误分析");
                    break;
                case 3:
                    cmbSubType.Items.Add("证书申请");
                    cmbSubType.Items.Add("签名工具");
                    cmbSubType.Items.Add("刷机教程");
                    cmbSubType.Items.Add("格机教程");
                    cmbSubType.Items.Add("软件游戏安装");
                    cmbSubType.Items.Add("使用技巧");
                    cmbSubType.Items.Add("错误分析");
                    break;
                case 4:
                    cmbSubType.Items.Add("N/A");
                    break;
            }
            cmbSubType.SelectedIndex = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}