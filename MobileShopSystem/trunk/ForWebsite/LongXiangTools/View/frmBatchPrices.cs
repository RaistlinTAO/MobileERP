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
//        Module  Name:                   frmBatchPrices.cs
//        Part Of:                        LongXiangTools
//        Last Change Date:               4:10 27/12/2011

#endregion

#region

#endregion

namespace LongXiangTools.View
{
    #region

    using System;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using LongXiangTools.Properties;

    #endregion

    public partial class frmBatchPrices : Form
    {
        //释放鼠标捕捉winuser.h


        private readonly MysqlController MysqlControl = new MysqlController();
        private string[][] tempID;


        public frmBatchPrices()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //发送消息//winuser.h 中有函数原型定义
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        private void frmBatchPrices_Load(object sender, EventArgs e)
        {
            try
            {
                string[] tempBrand = MysqlControl.Manufacturer();

                for (int i = 0; i < tempBrand.Length; i++)
                {
                    if (tempBrand[i] == null || tempBrand[i] == "") continue;
                    tcPrices.TabPages.Add(tempBrand[i]);
                    tcPrices.TabPages[i].BorderStyle = BorderStyle.FixedSingle;
                    tcPrices.TabPages[i].BackColor = Color.DarkSlateGray;
                    tcPrices.TabPages[i].Location = new Point(4, 22);
                    tcPrices.TabPages[i].Padding = new Padding(3);
                    tcPrices.TabPages[i].Size = new Size(697, 486);
                    tcPrices.TabPages[i].Name = "tbBrand" + i;

                    var iListViewName = new ColumnHeader();
                    var iListViewValue = new ColumnHeader();
                    var iListViewPrice = new ColumnHeader();
                    iListViewName.Text = Resources.frmBatchPrices_frmBatchPrices_Load_机型;
                    iListViewName.Width = 380;
                    iListViewValue.Text = Resources.frmBatchPrices_frmBatchPrices_Load_颜色产地;
                    iListViewValue.Width = 180;
                    iListViewPrice.Text = Resources.frmBatchPrices_frmBatchPrices_Load_价格;
                    iListViewPrice.Width = 100;

                    var iListView = new ListView();
                    iListView.Columns.AddRange(new[]
                                                   {
                                                       iListViewName,
                                                       iListViewValue,
                                                       iListViewPrice
                                                   });
                    iListView.BorderStyle = BorderStyle.FixedSingle;
                    iListView.Location = new Point(6, 6);
                    iListView.Name = "lsvBrand" + i;
                    iListView.Size = new Size(683, 472);
                    iListView.MouseDown += lsvBrand_MouseDown;
                    iListView.BackColor = Color.DarkSlateGray;
                    iListView.ForeColor = Color.WhiteSmoke;
                    iListView.GridLines = true;
                    iListView.FullRowSelect = true;

                    //iListView.HotTracking = true;
                    //iListView.HoverSelection = true;
                    iListView.MultiSelect = false;
                    iListView.View = View.Details;
                    //iListView.LabelEdit = true;

                    tcPrices.TabPages[i].Controls.Add(iListView);

                    //tcPrices.TabPages[i].UseVisualStyleBackColor = true;
                }
                var tempPhone = new DataTable[tcPrices.TabPages.Count];
                for (int i = 0; i < tcPrices.TabPages.Count; i++)
                {
                    tempPhone[i] = MysqlControl.ReadPhones(i);
                }

                tempID = new string[tempPhone.Length][];

                for (int i = 0; i < tempPhone.Length; i++)
                {
                    tempID[i] = new string[tempPhone[i].Rows.Count];
                    for (int j = 0; j < tempPhone[i].Rows.Count; j++)
                    {
                        DataRow drOperate = tempPhone[i].Rows[j];
                        tempID[i][j] = drOperate["PhoneID"].ToString();
                    }
                }

                var iTempInfo = new MysqlController.SPhoneInfo[tempPhone.Length][];

                for (int i = 0; i < tempPhone.Length; i++)
                {
                    iTempInfo[i] = new MysqlController.SPhoneInfo[tempPhone[i].Rows.Count];
                    for (int j = 0; j < tempPhone[i].Rows.Count; j++)
                    {
                        DataRow drOperate = tempPhone[i].Rows[j];
                        iTempInfo[i][j] = MysqlControl.ReadExistPhone(drOperate["PhoneID"].ToString());
                    }
                }

                for (int i = 0; i < tempPhone.Length; i++)
                {
                    for (int j = 0; j < tempPhone[i].Rows.Count; j++)
                    {
                        DataRow drOperate = tempPhone[i].Rows[j];
                        ((ListView)
                         tcPrices.Controls.Find("tbBrand" + i, false)[0].Controls.Find("lsvBrand" + i, false)[0]).Items.
                            Add(drOperate["PhoneName"].ToString());
                        //MessageBox.Show(((ListView)tcPrices.Controls.Find("tbBrand" + i, false)[0].Controls.Find("lsvBrand" + i, false)[0]).Items[0].Text);
                        //((ListView)tcPrices.Controls.Find("tbBrand" + i, false)[0].Controls.Find("lsvBrand" + i, false)[0]).Items[j].SubItems[0].ForeColor = System.Drawing.Color.WhiteSmoke;)
                        for (int k = 0; k < iTempInfo[i][j].ColorPrice.Length; k++)
                        {
                            if (string.IsNullOrEmpty(iTempInfo[i][j].ColorPrice[k].Color)) continue;
                            var iTempStr = new string[3];
                            iTempStr[0] = Resources.frmBatchPrices_cmdUpdate_Click___;
                            iTempStr[1] = iTempInfo[i][j].ColorPrice[k].Color;
                            iTempStr[2] = iTempInfo[i][j].ColorPrice[k].Price;
                            var iItem = new ListViewItem(iTempStr);
                            ((ListView)
                             tcPrices.Controls.Find("tbBrand" + i, false)[0].Controls.Find("lsvBrand" + i, false)[0])
                                .Items.Add(iItem);
                            //((ListView)tcPrices.Controls.Find("tbBrand" + i, false)[0].Controls.Find("lsvBrand" + i, false)[0]).Items[((ListView)tcPrices.Controls.Find("tbBrand" + i, false)[0].Controls.Find("lsvBrand" + i, false)[0]).Items.Count-2].SubItems[1].Text = iTempInfo[i][j].ColorPrice[k].Color;
                            //((ListView)tcPrices.Controls.Find("tbBrand" + i, false)[0].Controls.Find("lsvBrand" + i, false)[0]).Items[((ListView)tcPrices.Controls.Find("tbBrand" + i, false)[0].Controls.Find("lsvBrand" + i, false)[0]).Items.Count-2].SubItems[2].Text = iTempInfo[i][j].ColorPrice[k].Price;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.frmBatchPrices_frmBatchPrices_Load_数据库访问异常_请关闭后重试_, Application.ProductName,
                                MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void lsvBrand_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (((ListView) sender).GetItemAt(e.X, e.Y).SubItems[2].Text == "")
                {
                    return;
                }
                var iPopUp = new frmPopup
                                 {
                                     Top = ((ListView) sender).GetItemAt(e.X, e.Y).SubItems[2].Bounds.Top + Top + 40,
                                     Left = ((ListView) sender).GetItemAt(e.X, e.Y).SubItems[2].Bounds.Left + Left + 20,
                                     Pricestr = ((ListView) sender).GetItemAt(e.X, e.Y).SubItems[2].Text
                                 };

                iPopUp.ShowDialog();
                if (iPopUp.Pricestr != "" && Regex.IsMatch(iPopUp.Pricestr, @"^[0-9]+$"))
                {
                    ((ListView) sender).GetItemAt(e.X, e.Y).SubItems[2].Text = iPopUp.Pricestr;
                }
                //MessageBox.Show(((ListView)sender).GetItemAt(e.X, e.Y).SubItems[2].Text);
                //((ListView)sender).GetItemAt(e.X, e.Y).BeginEdit();
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
                return;
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            Enabled = false;

            var tempPhones = new MysqlController.SPhoneInfo[tcPrices.TabPages.Count][];

            for (int i = 0; i < tcPrices.TabPages.Count - 1; i++)
            {
                if (((ListView) tcPrices.TabPages[i].Controls.Find("lsvBrand" + i, false)[0]).Items.Count <= 0)
                    continue;
                //只考虑颜色价格
                int Phonenum = 0;
                string PhoneName = "";
                string PhoneSplit = "";
                for (int j = 0;
                     j < ((ListView) tcPrices.TabPages[i].Controls.Find("lsvBrand" + i, false)[0]).Items.Count;
                     j++)
                {
                    if (((ListView) tcPrices.TabPages[i].Controls.Find("lsvBrand" + i, false)[0]).Items[j].Text ==
                        Resources.frmBatchPrices_cmdUpdate_Click___)
                        continue;
                    //这里是手机型号
                    PhoneName = PhoneName + "＼" +
                                ((ListView) tcPrices.TabPages[i].Controls.Find("lsvBrand" + i, false)[0]).Items[
                                    j].Text;
                    Phonenum++;
                    PhoneSplit = PhoneSplit +
                                 "＼" + j;
                }
                tempPhones[i] = new MysqlController.SPhoneInfo[Phonenum];
                //string[] tempArr = PhoneName.Split('＼');
                string[] tempSplit = PhoneSplit.Split('＼');
                /*
                    for (int j = 0; j < tempPhones[i].Length; j++)
                    {
                        tempPhones[i][j]. = tempArr[j + 1];
                    }
                     */
                MysqlController.PhoneColor[] iColor;
                for (int j = 0; j < tempPhones[i].Length; j++)
                {
                    try
                    {
                        iColor =
                            new MysqlController.PhoneColor[
                                int.Parse(tempSplit[j + 2]) - int.Parse(tempSplit[j + 1]) - 1];
                    }
                    catch (Exception)
                    {
                        iColor =
                            new MysqlController.PhoneColor[
                                ((ListView) tcPrices.TabPages[i].Controls.Find("lsvBrand" + i, false)[0]).Items.
                                    Count - int.Parse(tempSplit[j + 1]) - 1];
                    }


                    for (int k = 0; k < iColor.Length; k++)
                    {
                        iColor[k].Color =
                            ((ListView) tcPrices.TabPages[i].Controls.Find("lsvBrand" + i, false)[0]).Items[
                                int.Parse(tempSplit[j + 1]) + 1 + k].SubItems[1].Text;
                        iColor[k].Price =
                            ((ListView) tcPrices.TabPages[i].Controls.Find("lsvBrand" + i, false)[0]).Items[
                                int.Parse(tempSplit[j + 1]) + 1 + k].SubItems[2].Text;
                    }

                    tempPhones[i][j].ColorPrice = iColor;
                }
            }

            //这里开始递交
            string tempRetrun = "";
            for (int i = 0; i < tempPhones.Length; i++)
            {
                if (tempPhones[i] == null) continue;
                for (int j = 0; j < tempPhones[i].Length; j++)
                {
                    tempRetrun = tempRetrun + "|" + MysqlControl.UpdataPhonePrice(tempPhones[i][j], tempID[i][j]);
                }
            }
            tempRetrun = tempRetrun.Replace("|", "");
            if (tempRetrun.Length < 1)
            {
                MessageBox.Show(Resources.frmBatchPrices_cmdUpdate_Click_递交价格报表成功, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(Resources.frmBatchPrices_cmdUpdate_Click_递交价格报表失败_失败原因__r_n + tempRetrun,
                                Application.ProductName, MessageBoxButtons.OK);
            }


            Enabled = true;
        }

        private void frmBatchPrices_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 274, 61449, 0);
        }
    }
}