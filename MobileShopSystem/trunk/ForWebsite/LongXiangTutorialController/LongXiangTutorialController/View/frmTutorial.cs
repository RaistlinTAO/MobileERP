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

    public partial class frmTutorial : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        private MysqlController.LXTutorial[] tempTutorial;


        public frmTutorial()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            cmdSearch.Enabled = false;
            lsvTutorial.Items.Clear();
            DelegateGetLXTutorial dn = MysqlControl.GetLXTutorial;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempTutorial = dn.EndInvoke(iar);

            if (tempTutorial != null)
            {
                for (int i = 0; i < tempTutorial.Length; i++)
                {
                    var tempItem = new ListViewItem {Text = tempTutorial[i].iTID};
                    tempItem.SubItems.Add(tempTutorial[i].iTPublicTime);
                    tempItem.SubItems.Add(tempTutorial[i].iType);
                    tempItem.SubItems.Add(tempTutorial[i].iSubType);
                    tempItem.SubItems.Add(tempTutorial[i].iTTitle);

                    lsvTutorial.Items.Add(tempItem);
                }
            }
            else
            {
                MessageBox.Show(Resources.frmTutorial_cmdSearch_Click_查询龙翔教程数据错误_, Application.ProductName, MessageBoxButtons.OK);
            }
            cmdSearch.Enabled = true;
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvTutorial.SelectedItems[0].Text != null)
                {
                    if (lsvTutorial.SelectedItems[0].Text != "")
                    {
                        MysqlController.ReturnResult iResult =
                            MysqlControl.DelLXTutorial(int.Parse(lsvTutorial.SelectedItems[0].Text));
                        if (iResult.isSuccess)
                        {
                            MessageBox.Show(Resources.frmTutorial_cmdDel_Click_删除该教程成功_, Application.ProductName, MessageBoxButtons.OK);
                            lsvTutorial.SelectedItems[0].Remove();
                        }
                        else
                        {
                            MessageBox.Show(Resources.frmTutorial_cmdDel_Click_ + iResult.ErrDesc, Application.ProductName,
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

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvTutorial.SelectedItems[0].Text != null)
                {
                    if (lsvTutorial.SelectedItems[0].Text != "")
                    {
                        var iForm = new frmTutorialDetail(true, tempTutorial[lsvTutorial.SelectedItems[0].Index]);
                        iForm.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            //http://www.skymobile.com.cn/index.php/action-model-name-course-itemid-1
            try
            {
                if (lsvTutorial.SelectedItems[0].Text != null)
                {
                    if (lsvTutorial.SelectedItems[0].Text != "")
                    {
                        Process.Start("http://www.skymobile.com.cn/index.php/action-model-name-course-itemid-" +
                                      lsvTutorial.SelectedItems[0].Text);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private static void cmdAdd_Click(object sender, EventArgs e)
        {
            /*
            var iForm = new frmTutorialDetail(false,new MysqlController.LXTutorial());
            iForm.ShowDialog();
        
             */
            //http://www.skymobile.com.cn/cp.php?ac=models&op=add&nameid=course
            Process.Start(
                "http://www.skymobile.com.cn/admincp.php?action=modelmanages&mid=4&catid=0&order=&sc=DESC&subtype=&searchkey=&page=1&op=add");
        }

        #region Nested type: DelegateGetLXTutorial

        private delegate MysqlController.LXTutorial[] DelegateGetLXTutorial();

        #endregion
    }
}