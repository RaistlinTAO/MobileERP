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

namespace LongXiangTutorialController.View
{
    #region

    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using LongXiangTutorialController.Properties;

    #endregion

    public partial class frmSoftware : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        private MysqlController.LXDownload[] tempDownload;

        public frmSoftware()
        {
            InitializeComponent();
        }

        private static void cmdAdd_Click(object sender, EventArgs e)
        {
            //
            Process.Start(
                "http://www.skymobile.com.cn/admincp.php?action=modelmanages&mid=5&catid=0&order=&sc=DESC&subtype=&searchkey=&page=1&op=add");
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            cmdView.Enabled = false;
            lsvDownload.Items.Clear();
            DelegateGetLXDownload dn = MysqlControl.GetLXDownload;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempDownload = dn.EndInvoke(iar);

            if (tempDownload != null)
            {
                for (int i = 0; i < tempDownload.Length; i++)
                {
                    var tempItem = new ListViewItem {Text = tempDownload[i].iTID};
                    tempItem.SubItems.Add(tempDownload[i].iTTitle);
                    tempItem.SubItems.Add(tempDownload[i].iTContent);
                    tempItem.SubItems.Add(tempDownload[i].iDownloadlink);

                    lsvDownload.Items.Add(tempItem);
                }
            }
            else
            {
                MessageBox.Show(Resources.frmSoftware_cmdView_Click_查询龙翔常用软件数据错误_, Application.ProductName, MessageBoxButtons.OK);
            }
            cmdView.Enabled = true;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvDownload.SelectedItems[0].Text != null)
                {
                    if (lsvDownload.SelectedItems[0].Text != "")
                    {
                        MysqlController.ReturnResult iResult =
                            MysqlControl.DelLXDownload(int.Parse(lsvDownload.SelectedItems[0].Text));
                        if (iResult.isSuccess)
                        {
                            MessageBox.Show(Resources.frmSoftware_cmdDelete_Click_删除该软件成功_, Application.ProductName, MessageBoxButtons.OK);
                            lsvDownload.SelectedItems[0].Remove();
                        }
                        else
                        {
                            MessageBox.Show(Resources.frmSoftware_cmdDelete_Click_ + iResult.ErrDesc, Application.ProductName,
                                            MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void cmdIE_Click(object sender, EventArgs e)
        {
            //http://www.skymobile.com.cn/index.php/action-model-name-download-itemid-1
            try
            {
                if (lsvDownload.SelectedItems[0].Text != null)
                {
                    if (lsvDownload.SelectedItems[0].Text != "")
                    {
                        Process.Start("http://www.skymobile.com.cn/index.php/action-model-name-download-itemid-" +
                                      lsvDownload.SelectedItems[0].Text);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        #region Nested type: DelegateGetLXDownload

        private delegate MysqlController.LXDownload[] DelegateGetLXDownload();

        #endregion
    }
}