#region SOURCE INFORMATION

// COPYRIGHT LICENCE
// 
//  Copyright (c) 2011, D.E.M.O.N Organization
//  All rights reserved.
// 
//  Redistribution and use in source and binary forms, with or without modification,
//  are permitted provided that the following conditions are met:
// 
//      * Redistributions of source code must retain the above copyright notice,
//      this list of conditions and the following disclaimer.
//      * Redistributions in binary form must reproduce the above copyright notice,
//      this list of conditions and the following disclaimer in the documentation
//      and/or other materials provided with the distribution.
//      * Neither D.E.M.O.N Organization nor its contributors
//      may be used to endorse or promote products derived from this
//      software without specific prior written permission.
// 
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
//  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
//  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//  DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
//  FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
//  DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
//  SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
//  CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
//  OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
//  THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 
// 
// 
// CODE DESCRIPTION
// 
//        Created by Raistlin.K @ D.E.M.O.N at  23:47  09/10/2011 .
//        E-Mail:                         DemonVK@Gmail.com
// 
//        Project Name:                   LongXiangTools
//        Module  Name:                   frmSecondHands.cs
//        Part Of:                        LongXiangTools
//        Last Change Date:               4:10 27/12/2011

#endregion

#region

#endregion

namespace LongXiangTools.View
{
    #region

    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using LongXiangTools.Properties;

    #endregion

    public partial class frmSecondHands : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        private string[] tempPrices;
        private MysqlController.SecondHands[] tempSecondHands;

        public frmSecondHands()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //发送消息//winuser.h 中有函数原型定义
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void RefreshSecondHands()
        {
            lsvSecondHands.Items.Clear();
            picWait.Visible = true;
            DelegateGetSecondHands dn = MysqlControl.GetSecondHands;

            IAsyncResult iar = dn.BeginInvoke(1000, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempSecondHands = dn.EndInvoke(iar);

            if (tempSecondHands != null)
            {
                tempPrices = new string[tempSecondHands.Length];
                for (int i = 0; i < tempSecondHands.Length; i++)
                {
                    tempPrices[i] = tempSecondHands[i].PhonePrice;
                    var tempItem = new ListViewItem {Text = tempSecondHands[i].PhoneID};
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneName);
                    tempItem.SubItems.Add(tempSecondHands[i].PublicName);
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneBrand);
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneNew);

                    //tempItem.SubItems.Add(tempSecondHands[i].PhoneType);
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneHasCheck ? "是" : "无");
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneEquip);
                    //tempItem.SubItems.Add(tempSecondHands[i].PhoneContect);
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneBuyPlace);

                    tempItem.SubItems.Add(tempSecondHands[i].PhoneBuyTime);
                    //tempItem.SubItems.Add(tempSecondHands[i].PhoneQQ);
                    tempItem.SubItems.Add(tempSecondHands[i].PhonePrice);
                    lsvSecondHands.Items.Add(tempItem);
                }
            }
            else
            {
                MessageBox.Show(Resources.frmSecondHands_RefreshSecondHands_查询二手机型数据错误_, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            picWait.Visible = false;
        }

        private void RefreshSecondHands(DateTime FliterDate)
        {
            lsvSecondHands.Items.Clear();
            picWait.Visible = true;
            DelegateGetSecondHands dn = MysqlControl.GetSecondHands;

            IAsyncResult iar = dn.BeginInvoke(1000, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            tempSecondHands = dn.EndInvoke(iar);
            if (tempSecondHands != null)
            {
                tempPrices = new string[tempSecondHands.Length];
                for (int i = 0; i < tempSecondHands.Length; i++)
                {
                    if (tempSecondHands[i].PhonePublicTime.Substring(0, 4) != FliterDate.Year.ToString()) continue;
                    if (tempSecondHands[i].PhonePublicTime.Substring(4, 2) != FliterDate.Month.ToString("00"))
                        continue;
                    if (tempSecondHands[i].PhonePublicTime.Substring(6, 2) != FliterDate.Day.ToString("00"))
                        continue;

                    tempPrices[i] = tempSecondHands[i].PhonePrice;
                    var tempItem = new ListViewItem {Text = tempSecondHands[i].PhoneID};
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneName);
                    tempItem.SubItems.Add(tempSecondHands[i].PublicName);
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneBrand);
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneNew);

                    //tempItem.SubItems.Add(tempSecondHands[i].PhoneType);
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneHasCheck ? "是" : "无");
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneEquip);
                    //tempItem.SubItems.Add(tempSecondHands[i].PhoneContect);
                    tempItem.SubItems.Add(tempSecondHands[i].PhoneBuyPlace);

                    tempItem.SubItems.Add(tempSecondHands[i].PhoneBuyTime);
                    //tempItem.SubItems.Add(tempSecondHands[i].PhoneQQ);
                    tempItem.SubItems.Add(tempSecondHands[i].PhonePrice);
                    lsvSecondHands.Items.Add(tempItem);
                }
            }
            else
            {
                MessageBox.Show(Resources.frmSecondHands_RefreshSecondHands_查询二手机型数据错误_, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            picWait.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cmdViewPicture_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvSecondHands.SelectedItems[0].Text != null)
                {
                    var iView = new frmViewPicture
                                    {
                                        tempPhone = tempSecondHands[lsvSecondHands.SelectedItems[0].Index]
                                    };
                    iView.ShowDialog();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void cmdViewDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvSecondHands.SelectedItems[0].Text != null)
                {
                    var iView = new frmViewDetail
                                    {
                                        tempPhone = tempSecondHands[lsvSecondHands.SelectedItems[0].Index]
                                    };
                    iView.ShowDialog();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvSecondHands.SelectedItems[0].Text != null)
                {
                    if (lsvSecondHands.SelectedItems[0].Text != "")
                    {
                        MysqlController.ReturnResult iResult =
                            MysqlControl.DelSecondHands(int.Parse(lsvSecondHands.SelectedItems[0].Text));
                        if (iResult.isSuccess)
                        {
                            MessageBox.Show(Resources.frmSecondHands_cmdDelete_Click_删除该二手信息成功_, Application.ProductName,
                                            MessageBoxButtons.OK);
                            lsvSecondHands.SelectedItems[0].Remove();
                        }
                        else
                        {
                            MessageBox.Show(Resources.frmSecondHands_cmdDelete_Click_ + iResult.ErrDesc,
                                            Application.ProductName,
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


        private void lsvSecondHands_Click(object sender, EventArgs e)
        {
            try
            {
                txtPrice.Text = tempPrices[lsvSecondHands.SelectedItems[0].Index];
            }
            catch (Exception)
            {
                return;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tempPrices[lsvSecondHands.SelectedItems[0].Index] = txtPrice.Text;
                lsvSecondHands.SelectedItems[0].SubItems[9].Text = txtPrice.Text;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void S_Click(object sender, EventArgs e)
        {
            S.Enabled = false;
            picWait.Visible = true;
            DelegateChangeSecondHands dn = MysqlControl.ChangeSecondHands;

            bool tempResult = true;
            string tempReason = "";
            var iResult = new MysqlController.ReturnResult[lsvSecondHands.Items.Count];
            for (int i = 0; i < lsvSecondHands.Items.Count; i++)
            {
                IAsyncResult iar = dn.BeginInvoke(lsvSecondHands.Items[i].Text,
                                                  lsvSecondHands.Items[i].SubItems[9].Text, null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                iResult[i] = dn.EndInvoke(iar);
            }

            for (int i = 0; i < iResult.Length; i++)
            {
                if (!iResult[i].isSuccess)
                {
                    tempResult = false;
                    tempReason = iResult[i].ErrDesc;
                }
                else
                {
                    tempResult = true;
                }
            }
            if (tempResult)
            {
                MessageBox.Show(Resources.frmSecondHands_S_Click_修改价格成功_, Application.ProductName, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(Resources.frmSecondHands_S_Click_ + tempReason, Application.ProductName,
                                MessageBoxButtons.OK);
            }

            picWait.Visible = false;
            S.Enabled = true;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            cmdSearch.Enabled = false;
            RefreshSecondHands(dtpSecondHands.Value);
            cmdSearch.Enabled = true;
        }

        private void cmdSearchK_Click(object sender, EventArgs e)
        {
            cmdSearchK.Enabled = false;
            RefreshSecondHands();
            cmdSearchK.Enabled = true;
        }

        private void frmSecondHands_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 274, 61449, 0);
        }

        #region Nested type: DelegateChangeSecondHands

        private delegate MysqlController.ReturnResult DelegateChangeSecondHands(string id, string iPrice);

        #endregion

        #region Nested type: DelegateGetSecondHands

        private delegate MysqlController.SecondHands[] DelegateGetSecondHands(int Limit);

        #endregion
    }
}