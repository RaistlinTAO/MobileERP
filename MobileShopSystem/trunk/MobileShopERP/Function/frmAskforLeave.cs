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
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmAskforLeave : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();

        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();

        public frmAskforLeave(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void frmAskforLeave_Load(object sender, EventArgs e)
        {
            cmbSellers.Items.Clear();

            cmbAskType.SelectedIndex = 0;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (cmbSellers.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.frmAskforLeave_cmdSearch_Click_必须选择一个销售人员进行查看_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }
            isBusy.Visible = true;
            cmdSearch.Enabled = false;
            lsvResult.Items.Clear();

            DelegateReadAsk dn = MysqlControl.ReadAsk;

            IAsyncResult iar = dn.BeginInvoke(cmbSellers.Text, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.AskForLeave[] iResult = dn.EndInvoke(iar);

            if (iResult != null)
            {
                for (int i = 0; i < iResult.Length; i++)
                {
                    if (string.IsNullOrEmpty(iResult[i].AskDate)) continue;
                    lsvResult.Items.Add(iResult[i].AskID.ToString());
                    lsvResult.Items[i].SubItems.Add(iResult[i].AskDate.Substring(0, 4) + "年" +
                                                    iResult[i].AskDate.Substring(4, 2) + "月" +
                                                    iResult[i].AskDate.Substring(6, 2) + "日");
                    switch (iResult[i].AskType)
                    {
                        case 0:
                            lsvResult.Items[i].SubItems.Add("事假");
                            break;
                        case 1:
                            lsvResult.Items[i].SubItems.Add("病假");
                            break;
                        case 2:
                            lsvResult.Items[i].SubItems.Add("丧假");
                            break;
                        case 3:
                            lsvResult.Items[i].SubItems.Add("产假");
                            break;
                    }

                    lsvResult.Items[i].SubItems.Add(iResult[i].AskDuration);
                    lsvResult.Items[i].SubItems.Add(iResult[i].AskTip);
                    Application.DoEvents();
                }
            }
            else
            {
                MessageBox.Show(Resources.frmAskforLeave_cmdSearch_Click_查询不到任何记录_, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            cmdSearch.Enabled = true;
            isBusy.Visible = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                isBusy.Visible = true;
                cmdDelete.Enabled = false;
                int tempID = int.Parse(lsvResult.SelectedItems[0].Text);
                if (tempID.ToString() != "")
                {
                    DelegateDeleteAsk dn = MysqlControl.DeleteAsk;

                    IAsyncResult iar = dn.BeginInvoke(tempID.ToString(), null, null);

                    while (iar.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                    if (iResult.isSuccess)
                    {
                        MessageBox.Show(Resources.frmAskforLeave_cmdDelete_Click_删除记录成功_, Application.ProductName,
                                        MessageBoxButtons.OK);
                        lsvResult.SelectedItems[0].Remove();
                    }
                    else
                    {
                        MessageBox.Show(Resources.frmAskforLeave_cmdDelete_Click_ + iResult.ErrDesc,
                                        Application.ProductName,
                                        MessageBoxButtons.OK);
                    }
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

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (cmbSellers.SelectedIndex == -1 || txtAskDuration.Text == "") return;

            if (txtAskDuration.Text == "" || !Regex.IsMatch(txtAskDuration.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show("请填写正确的请假时间!", Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            cmdAdd.Enabled = false;
            isBusy.Visible = true;

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n请假人员:" + cmbSellers.Text + "\r\n请假时间:" + dtpAskDate.Value.Year +
                dtpAskDate.Value.Month.ToString().PadLeft(2, '0') +
                dtpAskDate.Value.Day.ToString().PadLeft(2, '0') + "\r\n请假类型:" + cmbAskType.Text + "\r\n请假天数:" +
                txtAskDuration.Text + "\r\n请假原因:" + txtAskResult.Text, Application.ProductName,
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var tempAsk = new MysqlController.AskForLeave
                                  {
                                      AskDate =
                                          dtpAskDate.Value.Year + dtpAskDate.Value.Month.ToString().PadLeft(2, '0') +
                                          dtpAskDate.Value.Day.ToString().PadLeft(2, '0'),
                                      AskSeller = cmbSellers.Text,
                                      AskType = cmbAskType.SelectedIndex,
                                      AskDuration = txtAskDuration.Text,
                                      AskTip = txtAskResult.Text
                                  };

                DelegateAddAsk dn = MysqlControl.AddAsk;

                IAsyncResult iar = dn.BeginInvoke(tempAsk, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                if (iResult.isSuccess)
                {
                    MessageBox.Show(Resources.frmAskforLeave_cmdAdd_Click_添加请假记录成功_, Application.ProductName,
                                    MessageBoxButtons.OK);
                    CleanUI();
                    cmdSearch_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(Resources.frmAskforLeave_cmdAdd_Click_ + iResult.ErrDesc, Application.ProductName,
                                    MessageBoxButtons.OK);
                }
            }
            isBusy.Visible = false;
            cmdAdd.Enabled = true;
        }

        private void CleanUI()
        {
            txtAskDuration.Text = "";
            txtAskResult.Text = "";
        }

        private void cmdEditData_Click(object sender, EventArgs e)
        {
            try
            {
                isBusy.Visible = true;
                cmdEditData.Enabled = false;
                int tempID = int.Parse(lsvResult.SelectedItems[0].Text);
                if (tempID.ToString() != "")
                {
                    var iAdd = new frmAskforLeaveEditor {Location = lsvResult.Location};

                    Point p = PointToScreen(lsvResult.Location);
                    iAdd.tempSeller = cmbSellers.Text;
                    iAdd.iAsk = MysqlControl.ReadAskByID(tempID.ToString());
                    iAdd.SetDesktopBounds(p.X + groupBox2.Location.X + groupBox3.Location.X,
                                          p.Y + groupBox2.Location.Y + groupBox3.Location.Y, iAdd.Width,
                                          iAdd.Height);
                    if (iAdd.ShowDialog() == DialogResult.OK)
                    {
                        DelegateEditAsk dn = MysqlControl.EditAsk;

                        IAsyncResult iar = dn.BeginInvoke(iAdd.iAsk, null, null);

                        while (iar.IsCompleted == false)
                        {
                            Application.DoEvents();
                        }

                        MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

                        if (iResult.isSuccess)
                        {
                            MessageBox.Show("修改请假记录成功!", Application.ProductName, MessageBoxButtons.OK);
                            cmdSearch_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("修改请假记录失败!错误原因" + iResult.ErrDesc, Application.ProductName,
                                            MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch (Exception)
            {
                isBusy.Visible = false;
                cmdEditData.Enabled = true;
                return;
            }
            isBusy.Visible = false;
            cmdEditData.Enabled = true;
        }

        private void frmAskforLeave_Shown(object sender, EventArgs e)
        {
            isBusy.Visible = true;
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
            }
            isBusy.Visible = false;
        }

        private void cmbSellers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsvResult.Items.Clear();
        }

        #region Nested type: DelegateAddAsk

        private delegate MysqlController.ReturnResult DelegateAddAsk(MysqlController.AskForLeave iAsk);

        #endregion

        #region Nested type: DelegateDeleteAsk

        private delegate MysqlController.ReturnResult DelegateDeleteAsk(string iID);

        #endregion

        #region Nested type: DelegateEditAsk

        private delegate MysqlController.ReturnResult DelegateEditAsk(MysqlController.AskForLeave iAsk);

        #endregion

        #region Nested type: DelegateReadAsk

        private delegate MysqlController.AskForLeave[] DelegateReadAsk(string Seller);

        #endregion

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion
    }
}