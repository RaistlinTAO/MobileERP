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

namespace LongXiangBox.View
{
    #region

    using System;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using SystemControl.ini;
    using SystemControl.Network;
    using DataControler.Crype;
    using DataControler.Mysql;
    using FTP;
    using LongXiangBox.Properties;
    using WebContentAnalyser;

    #endregion

    public partial class frmMain : Form
    {
        #region API

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //发送消息//winuser.h 中有函数原型定义
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //释放鼠标捕捉winuser.h

        #endregion

        #region 全局变量

        private readonly clsAnalyser CheckWeb = new clsAnalyser();
        private readonly MysqlController DataController = new MysqlController();
        private readonly EnDeCrype iCrype = new EnDeCrype();

        private DataTable EditPhoneDT;
        private FTPclient FTPController;
        private int iAddedPhoneID;
        private string iEPhoneDetail;
        private string iEnvHTML;
        private string iFTPAccount;
        private string iFTPIP;
        private string iFTPPassword;
        private string iMainPhoto;
        private string iMySQLAccount;
        private string iMySQLDatabase;
        private string iMySQLIP;
        private string iMySQLPassword;
        private string iPhoneImg;
        private string[] iPhonePhotos;
        private string[] iPhotos;
        private bool isAddFlag = true;

        #endregion

        #region 从网络数据库载入控件属性

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //检测网络
            var CheckNetWork = new clsNetwork();
            if (!CheckNetWork.IsConnected())
            {
                MessageBox.Show(Resources.frmMain_frmMain_Load_No_Network_Connected_);
                Hide();
                Application.Exit();
            }
            else
            {
                MysqlController.MySQLAccount = iMySQLAccount;
                MysqlController.MySQLIP = iMySQLIP;
                MysqlController.MySQLPassword = iMySQLPassword;
                MysqlController.MySQLDatabase = iMySQLDatabase;

                DelegateTestConnect dn = DataController.TestConnect;

                IAsyncResult iar = dn.BeginInvoke(null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                bool iConnectFlag = dn.EndInvoke(iar);

                if (iConnectFlag != true)
                {
                    Hide();
                    MessageBox.Show(
                        Resources.
                            frmMain_frmMain_Load_Can_not_open_Mysql_Connection_Check_your_Network_Connection_or_BoxSetting_ini);
                    Application.Exit();
                }

                ReadManufacturer();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //建立文件夹
            /*
            if (Directory.Exists(Application.StartupPath + @"\Temp")) //判断文件夹是否已经存在
            {
                Directory.Delete(Application.StartupPath + @"\Temp", true);
            }
            Directory.CreateDirectory(Application.StartupPath + @"\Temp"); //创建文件夹
            */
            //载入配置

            cmbWebUrl.SelectedIndex = 0;

            Text = Text + Resources.frmMain_frmMain_Load__Version_ + Application.ProductVersion;
            gpAdd.Parent = this;
            gpEdit.Parent = this;
            gpEdit.Visible = false;
            gpEdit.Top = gpAdd.Top;
            gpEdit.Left = gpAdd.Left;
            var iSetting = new clsINI(Application.StartupPath + @"\BoxSetting.sys");
            iMySQLIP = iCrype.CryptString(iSetting.IniReadValue("Network", "MysqlURL"));
            iMySQLAccount = iCrype.CryptString(iSetting.IniReadValue("Network", "MysqlAccount"));
            iMySQLPassword = iCrype.CryptString(iSetting.IniReadValue("Network", "MysqlPassword"));
            iMySQLDatabase = iCrype.CryptString(iSetting.IniReadValue("Network", "MysqlDatabase"));
            iFTPIP = iCrype.CryptString(iSetting.IniReadValue("Network", "FTPURL"));
            iFTPAccount = iCrype.CryptString(iSetting.IniReadValue("Network", "FTPAccount"));
            iFTPPassword = iCrype.CryptString(iSetting.IniReadValue("Network", "FTPPassword"));
        }

        private void ReadManufacturer()
        {
            DelegateManufacturer dn = DataController.Manufacturer;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            string[] tempArray = dn.EndInvoke(iar);

            if (tempArray == null) return;
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] == null) continue;
                cmbAManu.Items.Add(tempArray[i]);
                cmbManufacturer.Items.Add(tempArray[i]);
            }
            cmbManufacturer.SelectedIndex = 0;
            //cmbAManu.SelectedIndex = 0;
        }

        #region Nested type: DelegateManufacturer

        private delegate string[] DelegateManufacturer();

        #endregion

        #region Nested type: DelegateTestConnect

        private delegate bool DelegateTestConnect();

        #endregion

        #endregion

        #region 界面事件

        #region 普通页面事件

        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdPCPaste_MouseEnter(object sender, EventArgs e)
        {
            switch (cmbWebUrl.SelectedIndex)
            {
                case 0:
                    ttMain.Tag = @"请输入类似: http://product.pconline.com.cn/mobile/nokia/364844.html 的网址";
                    break;
                case 1:
                    ttMain.Tag = @"请输入类似: http://product.pcpop.com/000197677/Index.html 的网址";
                    break;
                case 2:
                    ttMain.Tag = @"请输入类似: http://detail.zol.com.cn/cell_phone/index207959.shtml 的网址";
                    break;
                case 3:
                    ttMain.Tag = @"请输入类似: http://product.it168.com/detail/doc/405927/index.shtml 的网址";
                    break;
            }
            ttMain.Show(ttMain.Tag.ToString(), cmdPCPaste);
        }

        private void cmdPCPaste_MouseLeave(object sender, EventArgs e)
        {
            ttMain.Tag = "";
            ttMain.Hide(this);
        }

        private void cmdOther_Click(object sender, EventArgs e)
        {
            var pInfo = new ProcessStartInfo(Application.StartupPath + @"\LongXiangTools.exe", "K9998");
            Process p = Process.Start(pInfo);
            p.WaitForExit();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void label20_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 161, 2, 0);
        }

        private void label22_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 161, 2, 0);
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 161, 2, 0);
        }

        private void cmdYRPaste_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData != null)
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    txtYRUrl.Text = (String) iData.GetData(DataFormats.Text);
                }
        }

        private void cmdEquipment_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData != null)
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    txtEquipment.Text = (String) iData.GetData(DataFormats.Text);
                }
        }

        private void cmdPCPaste_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData != null)
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    txtPCUrl.Text = (String) iData.GetData(DataFormats.Text);
                }
        }

        private void cmdTBURLPaste_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData != null)
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    txtTBURL.Text = (String) iData.GetData(DataFormats.Text);
                }
        }

        private void cmdKWordsPaste_Click(object sender, EventArgs e)
        {
            txtKeywords.Text = Resources.frmMain_cmdKWordsPaste_Click_手机_龙翔_手机报价_手机大全_手机评测_龙翔评测_龙翔报价_ +
                               txtPhoneName.Text;
        }

        #endregion

        #region 修改价格颜色的逻辑

        private void changeCKB(CheckBox iCheck)
        {
            string index = iCheck.Name.Replace("ckbCA", "");
            //得到序号index
            if (iCheck.Checked)
            {
                gpCAP.Controls.Find("txtCAA" + index, false)[0].Enabled = true;
                gpCAP.Controls.Find("txtCAP" + index, false)[0].Enabled = true;
                Application.DoEvents();
            }
            else
            {
                gpCAP.Controls.Find("txtCAA" + index, false)[0].Enabled = false;
                gpCAP.Controls.Find("txtCAP" + index, false)[0].Enabled = false;
                gpCAP.Controls.Find("txtCAA" + index, false)[0].Text = "";
                gpCAP.Controls.Find("txtCAP" + index, false)[0].Text = "";
                Application.DoEvents();
            }
        }

        private void changeACKB(CheckBox iCheck)
        {
            string index = iCheck.Name.Replace("ckbACA", "");
            //得到序号index
            if (iCheck.Checked)
            {
                gpACAP.Controls.Find("txtACAA" + index, false)[0].Enabled = true;
                gpACAP.Controls.Find("txtACAP" + index, false)[0].Enabled = true;
                Application.DoEvents();
            }
            else
            {
                gpACAP.Controls.Find("txtACAA" + index, false)[0].Enabled = false;
                gpACAP.Controls.Find("txtACAP" + index, false)[0].Enabled = false;
                gpACAP.Controls.Find("txtACAA" + index, false)[0].Text = "";
                gpACAP.Controls.Find("txtACAP" + index, false)[0].Text = "";
                Application.DoEvents();
            }
        }

        private void ckbACA16_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA16);
        }

        private void ckbACA17_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA17);
        }

        private void ckbACA18_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA18);
        }

        private void ckbACA19_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA19);
        }

        private void ckbACA20_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA20);
        }

        private void ckbACA21_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA21);
        }

        private void ckbCA16_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA16);
        }

        private void ckbCA17_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA17);
        }

        private void ckbCA18_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA18);
        }

        private void ckbCA19_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA19);
        }

        private void ckbCA20_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA20);
        }

        private void ckbCA21_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA21);
        }

        private void ckbACA1_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA1);
        }

        private void ckbACA2_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA2);
        }

        private void ckbACA3_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA3);
        }

        private void ckbACA4_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA4);
        }

        private void ckbACA5_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA5);
        }

        private void ckbACA6_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA6);
        }

        private void ckbACA7_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA7);
        }

        private void ckbACA8_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA8);
        }

        private void ckbACA9_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA9);
        }

        private void ckbACA10_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA10);
        }

        private void ckbACA11_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA11);
        }

        private void ckbACA12_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA12);
        }

        private void ckbACA13_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA13);
        }

        private void ckbACA14_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA14);
        }

        private void ckbACA15_CheckedChanged(object sender, EventArgs e)
        {
            changeACKB(ckbACA15);
        }

        private void ckbCA1_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA1);
        }

        private void ckbCA2_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA2);
        }

        private void ckbCA3_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA3);
        }

        private void ckbCA4_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA4);
        }

        private void ckbCA5_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA5);
        }

        private void ckbCA6_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA6);
        }

        private void ckbCA7_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA7);
        }

        private void ckbCA8_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA8);
        }

        private void ckbCA9_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA9);
        }

        private void ckbCA10_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA10);
        }

        private void ckbCA11_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA11);
        }

        private void ckbCA12_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA12);
        }

        private void ckbCA15_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA15);
        }

        private void ckbCA14_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA14);
        }

        private void ckbCA13_CheckedChanged(object sender, EventArgs e)
        {
            changeCKB(ckbCA13);
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            CleanBox(); //gpAdd.Visible = true;
            gpAdd.Visible = true;
            gpEdit.Visible = false;
            //gpAdd.BringToFront();
            Application.DoEvents();
            isAddFlag = true;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            CleanBox();
            gpEdit.Visible = true;
            gpAdd.Visible = false;
            Application.DoEvents();
            //gpAdd.Visible = false;
            //gpEdit.BringToFront();
            isAddFlag = false;
        }

        #endregion

        #region 全局 Execute 按钮事件

        private void cmdExecute_Click(object sender, EventArgs e)
        {
            //判断
            picWait.Visible = true;

            if (isAddFlag)

                #region 添加一部手机

            {
                cmdExecute.Enabled = false;
                //Application.DoEvents();
                if (cmbManufacturer.Text != Resources.frmMain_cmbAManu_SelectedIndexChanged_其它)
                {
                    //判断
                    if (txtPhoneName.Text == "")
                    {
                        MessageBox.Show(Resources.frmMain_cmdExecute_Click_请填写具体的手机信息_, Application.ProductName,
                                        MessageBoxButtons.OK);
                        picWait.Visible = false;
                        cmdExecute.Enabled = true;
                        return;
                    }

                    if (txtPhoneShortName.Text == "")
                    {
                        MessageBox.Show(Resources.frmMain_cmdExecute_Click_请填写具体的手机信息_, Application.ProductName,
                                        MessageBoxButtons.OK);
                        picWait.Visible = false;
                        cmdExecute.Enabled = true;
                        return;
                    }

                    if (txtEquipment.Text == "")
                    {
                        MessageBox.Show(Resources.frmMain_cmdExecute_Click_请填写具体的手机配置信息_, Application.ProductName,
                                        MessageBoxButtons.OK);
                        picWait.Visible = false;
                        cmdExecute.Enabled = true;
                        return;
                    }

                    if (txtKeywords.Text == "")
                    {
                        MessageBox.Show(Resources.frmMain_cmdExecute_Click_请填写具体的手机SEO优化信息_, Application.ProductName,
                                        MessageBoxButtons.OK);
                        picWait.Visible = false;
                        cmdExecute.Enabled = true;
                        return;
                    }

                    bool foundYRMatch = Regex.IsMatch(txtYRUrl.Text,
                                                      @"\A(?:(https?|ftp|file)://[-A-Z0-9+&@#/%?=~_|$!:,.;]*[A-Z0-9+&@#/%=~_|$])\Z",
                                                      RegexOptions.IgnoreCase);
                    bool foundPCMatch = Regex.IsMatch(txtPCUrl.Text,
                                                      @"\A(?:(https?|ftp|file)://[-A-Z0-9+&@#/%?=~_|$!:,.;]*[A-Z0-9+&@#/%=~_|$])\Z",
                                                      RegexOptions.IgnoreCase);
                    if (foundYRMatch && foundPCMatch && txtPhoneName.Text != "")
                    {
                        //
                        DelegateCheckInfo dn = CheckWeb.CheckInfo;

                        IAsyncResult iar = dn.BeginInvoke(txtYRUrl.Text, txtPCUrl.Text,
                                                          cmbWebUrl.SelectedIndex, null, null);

                        while (iar.IsCompleted == false)
                        {
                            Application.DoEvents();
                        }

                        clsAnalyser.WebPhoneInfo iPhoneInfo = dn.EndInvoke(iar);

                        if (iPhoneInfo.Error == false)
                        {
                            var dPhoneInfo = new MysqlController.PhoneInfo();
                            var iPhoneColor = new MysqlController.PhoneColor[21];


                            for (int i = 0; i < iPhoneColor.Length; i++)
                            {
                                iPhoneColor[i].Color = gpCAP.Controls.Find("txtCAA" + (i + 1), false)[0].Text;
                                iPhoneColor[i].Price = gpCAP.Controls.Find("txtCAP" + (i + 1), false)[0].Text;
                                Application.DoEvents();
                            }

                            dPhoneInfo.Color = iPhoneColor;

                            dPhoneInfo.PhoneName = txtPhoneName.Text;
                            dPhoneInfo.PhoneShortName = txtPhoneShortName.Text;
                            dPhoneInfo.PhoneManufacturer = cmbManufacturer.SelectedIndex;
                            dPhoneInfo.MarketTime = iPhoneInfo.YRInfo.MarketTime;
                            dPhoneInfo.NetworkType = iPhoneInfo.YRInfo.NetworkType;
                            dPhoneInfo.HzType = iPhoneInfo.YRInfo.HzType;

                            dPhoneInfo.Weight = iPhoneInfo.YRInfo.Weight;
                            dPhoneInfo.Size = iPhoneInfo.YRInfo.Size;
                            dPhoneInfo.Look = iPhoneInfo.YRInfo.Look;
                            dPhoneInfo.Screen = iPhoneInfo.YRInfo.Screen;

                            dPhoneInfo.OS = iPhoneInfo.YRInfo.OS;
                            dPhoneInfo.CPU = iPhoneInfo.YRInfo.CPU;
                            dPhoneInfo.Memory = iPhoneInfo.YRInfo.Memory;
                            dPhoneInfo.PhoneTime = iPhoneInfo.YRInfo.PhoneTime;
                            dPhoneInfo.HoldTime = iPhoneInfo.YRInfo.HoldTime;

                            dPhoneInfo.CommonEquip = iPhoneInfo.YRInfo.CommonEquip;
                            dPhoneInfo.TaoBaoURL = txtTBURL.Text;
                            dPhoneInfo.Detail = iPhoneInfo.Detail;
                            dPhoneInfo.Keywords = txtKeywords.Text;
                            dPhoneInfo.Equipment = txtEquipment.Text;
                            dPhoneInfo.LongXiangPC = iEnvHTML;

                            dPhoneInfo.PhonePic = iMainPhoto;
                            dPhoneInfo.PhoneGallery = iPhotos;
                            //FTP + sql
                            string tempPicName = txtPhoneName.Text;
                            //|:|=|%|&|$|#|@|+|-|*|/|\|<|>|;|,|^|" 
                            tempPicName = tempPicName.Replace(@"\", @"");
                            tempPicName = tempPicName.Replace(@"/", @"");
                            tempPicName = tempPicName.Replace(@"?", @"");
                            tempPicName = tempPicName.Replace(@"!", @"");
                            tempPicName = tempPicName.Replace(@".", @"");
                            tempPicName = tempPicName.Replace(@"!", @"");
                            tempPicName = tempPicName.Replace(@":", @"");
                            tempPicName = tempPicName.Replace(@"=", @"");
                            tempPicName = tempPicName.Replace(@"%", @"");
                            tempPicName = tempPicName.Replace(@"&", @"");
                            tempPicName = tempPicName.Replace(@"$", @"");
                            tempPicName = tempPicName.Replace(@"#", @"");
                            tempPicName = tempPicName.Replace(@"*", @"");
                            tempPicName = tempPicName.Replace(@"+", @"");
                            tempPicName = tempPicName.Replace(@"-", @"");
                            tempPicName = tempPicName.Replace(@"*", @"");
                            tempPicName = tempPicName.Replace(@"|", @"");
                            tempPicName = tempPicName.Replace(@"<", @"");
                            tempPicName = tempPicName.Replace(@">", @"");

                            if (!string.IsNullOrEmpty(iMainPhoto))
                            {
                                FTPController = new FTPclient(iFTPIP, iFTPAccount, iFTPPassword)
                                                    {
                                                        CurrentDirectory = "/shop/images/BoxImage/"
                                                    };
                                //FTPController.FtpCreateDirectory(txtPhoneName.Text);
                                DelegateUpload dnFTP = FTPController.Upload;

                                IAsyncResult iarFTP = dnFTP.BeginInvoke(iMainPhoto,
                                                                        "/shop/images/BoxImage/" + tempPicName +
                                                                        "_Main.jpg", null,
                                                                        null);

                                while (iarFTP.IsCompleted == false)
                                {
                                    Application.DoEvents();
                                }

                                dnFTP.EndInvoke(iarFTP);

                                //FTPController.Upload(iMainPhoto, "/web/LongXiang/shop/images/BoxImage/" + txtPhoneName.Text + "/Main.jpg");
                                if (iPhotos != null)
                                {
                                    if (iPhotos.Length > 0)
                                    {
                                        for (int i = 0; i < iPhotos.Length; i++)
                                        {
                                            IAsyncResult iarFTPcos = dnFTP.BeginInvoke(iPhotos[i],
                                                                                       "/shop/images/BoxImage/" +
                                                                                       tempPicName + "_" + i + ".jpg",
                                                                                       null, null);

                                            while (iarFTPcos.IsCompleted == false)
                                            {
                                                Application.DoEvents();
                                            }

                                            dnFTP.EndInvoke(iarFTPcos);
                                        }
                                    }
                                }
                            }

                            DelegateAddNewPhone dnAdd = DataController.AddNewPhone;

                            IAsyncResult iarAdd = dnAdd.BeginInvoke(dPhoneInfo, false, null, null);

                            while (iarAdd.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }

                            MysqlController.ReturnResult iResult = dnAdd.EndInvoke(iarAdd);


                            if (iResult.isSuccess)
                            {
                                //上传成功
                                picWait.Visible = false;

                                MessageBox.Show(Resources.frmMain_cmdExecute_Click_ + txtPhoneName.Text, Text,
                                                MessageBoxButtons.OK);
                                iAddedPhoneID = iResult.PhoneID;
                                CleanBox();
                                cmdSeePhone.Visible = true;
                            }
                            else
                            {
                                picWait.Visible = false;

                                MessageBox.Show(Resources.frmMain_cmdExecute_Click_Error + iResult.ErrDesc, Text,
                                                MessageBoxButtons.OK);
                                //上传失败
                            }
                        }
                    }
                    else
                    {
                        picWait.Visible = false;

                        MessageBox.Show(Resources.frmMain_cmdExecute_Click_Error_URL_Please_check_them_again_, Text,
                                        MessageBoxButtons.OK);
                    }
                }
                else
                {
                    if (txtPhoneName.Text == "")
                    {
                        MessageBox.Show(Resources.frmMain_cmdExecute_Click_请填写具体的手机信息_, Application.ProductName,
                                        MessageBoxButtons.OK);
                        picWait.Visible = false;
                        cmdExecute.Enabled = true;
                        return;
                    }

                    var xPhoneInfo = new MysqlController.PhoneInfo
                                         {
                                             PhoneName = txtPhoneName.Text,
                                             PhoneShortName = txtPhoneShortName.Text,
                                             PhoneManufacturer = cmbManufacturer.SelectedIndex
                                         };

                    DelegateAddNewPhone dnAdd = DataController.AddNewPhone;

                    IAsyncResult iarAdd = dnAdd.BeginInvoke(xPhoneInfo, true, null, null);

                    while (iarAdd.IsCompleted == false)
                    {
                        Application.DoEvents();
                    }

                    MysqlController.ReturnResult iResult = dnAdd.EndInvoke(iarAdd);

                    //Application.DoEvents();
                    if (iResult.isSuccess)
                    {
                        //上传成功
                        picWait.Visible = false;

                        MessageBox.Show(Resources.frmMain_cmdExecute_Click_ + txtPhoneName.Text, Text,
                                        MessageBoxButtons.OK);
                        //iAddedPhoneID = iResult.PhoneID;
                        //cmdSeePhone.Visible = true;
                        CleanBox();
                    }
                    else
                    {
                        picWait.Visible = false;

                        MessageBox.Show(Resources.frmMain_cmdExecute_Click_Error + iResult.ErrDesc, Text,
                                        MessageBoxButtons.OK);
                        //上传失败
                    }
                }
                cmdExecute.Enabled = true;
            }
                #endregion

            else
                #region 修改一部手机

            {
                //Edit Phone
                //Application.DoEvents();
                if (cmbPhone.Text != "")
                {
                    if (cmbAManu.Text != Resources.frmMain_cmbAManu_SelectedIndexChanged_其它)
                    {
                        cmdExecute.Enabled = false;
                        var iResult = new MysqlController.ReturnResult();
                        var tempInfo = new MysqlController.SPhoneInfo
                                           {
                                               PhoneClick = txtCount.Text,
                                               isNEW = ckbisNew.Checked,
                                               isBest = ckbisBest.Checked,
                                               isHot = ckbisHot.Checked,
                                               Keywords = txtEKeywords.Text,
                                               TBURL = txtETBURL.Text,
                                               Equipment = txtEEquipment.Text,
                                               Detail = iEPhoneDetail,
                                               PhoneShortName = txtEPhoneShortName.Text
                                           };

                        var iPhoneColor = new MysqlController.PhoneColor[21];

                        for (int i = 0; i < iPhoneColor.Length; i++)
                        {
                            iPhoneColor[i].Color = gpACAP.Controls.Find("txtACAA" + (i + 1), false)[0].Text;
                            iPhoneColor[i].Price = gpACAP.Controls.Find("txtACAP" + (i + 1), false)[0].Text;
                            Application.DoEvents();
                        }

                        tempInfo.ColorPrice = iPhoneColor;

                        for (int i = 0; i < EditPhoneDT.Rows.Count; i++)
                        {
                            DataRow drOperate = EditPhoneDT.Rows[i];
                            if (cmbPhone.Text != drOperate["PhoneName"].ToString()) continue;
                            DelegateUpdataPhone dn = DataController.UpdataPhone;

                            IAsyncResult iar = dn.BeginInvoke(tempInfo, drOperate["PhoneID"].ToString(), false, null,
                                                              null);

                            while (iar.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }
                            iResult = dn.EndInvoke(iar);
                        }
                        //Application.DoEvents();
                        if (iResult.isSuccess)
                        {
                            picWait.Visible = false;
                            //Enabled = true;
                            MessageBox.Show(Resources.UpdateOK + cmbPhone.Text);
                            CleanBox();
                        }
                        else
                        {
                            picWait.Visible = false;

                            MessageBox.Show(Resources.UpdateError + iResult.ErrDesc);
                        }
                        //Application.DoEvents();
                        cmdExecute.Enabled = true;
                    }
                    else
                    {
                        cmdExecute.Enabled = false;
                        var iResult = new MysqlController.ReturnResult();
                        var tempInfo = new MysqlController.SPhoneInfo
                                           {
                                               PhoneClick = txtCount.Text,
                                               isNEW = ckbisNew.Checked,
                                               isBest = ckbisBest.Checked,
                                               isHot = ckbisHot.Checked,
                                               Keywords = txtEKeywords.Text,
                                               TBURL = txtETBURL.Text,
                                               Equipment = txtEEquipment.Text,
                                               Detail = iEPhoneDetail,
                                               PhoneShortName = txtEPhoneShortName.Text
                                           };


                        for (int i = 0; i < EditPhoneDT.Rows.Count; i++)
                        {
                            DataRow drOperate = EditPhoneDT.Rows[i];
                            if (cmbPhone.Text != drOperate["PhoneName"].ToString()) continue;
                            DelegateUpdataPhone dn = DataController.UpdataPhone;

                            IAsyncResult iar = dn.BeginInvoke(tempInfo, drOperate["PhoneID"].ToString(), true, null,
                                                              null);

                            while (iar.IsCompleted == false)
                            {
                                Application.DoEvents();
                            }
                            iResult = dn.EndInvoke(iar);
                        }
                        //Application.DoEvents();
                        if (iResult.isSuccess)
                        {
                            picWait.Visible = false;

                            MessageBox.Show(Resources.UpdateOK + cmbPhone.Text);
                            CleanBox();
                        }
                        else
                        {
                            picWait.Visible = false;

                            MessageBox.Show(Resources.UpdateError + iResult.ErrDesc);
                        }
                        //Application.DoEvents();
                        cmdExecute.Enabled = true;
                    }
                }
            }

            #endregion
        }

        #region Nested type: DelegateAddNewPhone

        private delegate MysqlController.ReturnResult DelegateAddNewPhone(
            MysqlController.PhoneInfo iPhoneInfo, bool iOther);

        #endregion

        #region Nested type: DelegateCheckInfo

        private delegate clsAnalyser.WebPhoneInfo DelegateCheckInfo(string URL1, string URL2, int iNum);

        #endregion

        #region Nested type: DelegateUpdataPhone

        private delegate MysqlController.ReturnResult DelegateUpdataPhone(
            MysqlController.SPhoneInfo iTempInfo, string PhoneID, bool iOther);

        #endregion

        #region Nested type: DelegateUpload

        private delegate bool DelegateUpload(string iFile, string tFile);

        #endregion

        //DataController.UpdataPhone

        #endregion

        #region 修改手机界面的操作事件

        private void cmbAManu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //读取当前厂商下的所有手机
            cmbPhone.Enabled = false;
            picWait.Visible = true;

            DelegateReadPhones dn = DataController.ReadCMSPhones;

            IAsyncResult iar = dn.BeginInvoke(cmbAManu.SelectedIndex, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            EditPhoneDT = dn.EndInvoke(iar);

            cmbPhone.Items.Clear();
            for (int i = 0; i < EditPhoneDT.Rows.Count; i++)
            {
                DataRow drOperate = EditPhoneDT.Rows[i];
                cmbPhone.Items.Add(drOperate["PhoneName"]);
                Application.DoEvents();
            }

            if (cmbAManu.Text == Resources.frmMain_cmbAManu_SelectedIndexChanged_其它)
            {
                gpACAP.Enabled = false;
                //cmdExecute.Enabled = false;
                cmdEPEval.Enabled = false;
                cmdEPhotos.Enabled = false;
            }
            else
            {
                gpACAP.Enabled = true;
                //cmdExecute.Enabled = false;
                cmdEPEval.Enabled = true;
                cmdEPhotos.Enabled = true;
            }
            picWait.Visible = false;
            cmbPhone.Enabled = true;
        }

        private void cmbPhone_SelectedIndexChanged(object sender, EventArgs e)
        {
            //读取选择手机的信息
            //EditPhoneDT
            picWait.Visible = true;
            picPhone.Image = null;
            for (int i = 0; i < 15; i++)
            {
                ((CheckBox) gpACAP.Controls.Find("ckbACA" + (i + 1), false)[0]).Checked = false;
                //txtACAA
                gpACAP.Controls.Find("txtACAA" + (i + 1), false)[0].Text = "";
                gpACAP.Controls.Find("txtACAP" + (i + 1), false)[0].Text = "";
                Application.DoEvents();
            }

            var tempInfo = new MysqlController.SPhoneInfo();
            for (int i = 0; i < EditPhoneDT.Rows.Count; i++)
            {
                DataRow drOperate = EditPhoneDT.Rows[i];
                if (cmbPhone.Text != drOperate["PhoneName"].ToString()) continue;
                DelegateReadExistPhone dn = DataController.ReadExistPhone;

                IAsyncResult iar = dn.BeginInvoke(drOperate["PhoneID"].ToString(), null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                tempInfo = dn.EndInvoke(iar);

                cmdDeletePhone.Tag = drOperate["PhoneID"].ToString();
            }
            if (tempInfo.isError != true)
            {
                //将取到的值赋给界面
                txtEPhoneShortName.Text = tempInfo.PhoneShortName;
                txtEKeywords.Text = tempInfo.Keywords;
                txtETBURL.Text = tempInfo.TBURL;
                txtCount.Text = tempInfo.PhoneClick;
                ckbisNew.Checked = tempInfo.isNEW;
                ckbisBest.Checked = tempInfo.isBest;
                ckbisHot.Checked = tempInfo.isHot;
                txtEEquipment.Text = tempInfo.Equipment;
                for (int i = 0; i < tempInfo.ColorPrice.Length; i++)
                {
                    if (tempInfo.ColorPrice[i].Color == null) continue;
                    //ckbACA
                    ((CheckBox) gpACAP.Controls.Find("ckbACA" + (i + 1), false)[0]).Checked = true;
                    //txtACAA
                    gpACAP.Controls.Find("txtACAA" + (i + 1), false)[0].Text = tempInfo.ColorPrice[i].Color;
                    gpACAP.Controls.Find("txtACAP" + (i + 1), false)[0].Text = tempInfo.ColorPrice[i].Price;
                    Application.DoEvents();
                }
                iPhoneImg = tempInfo.PhonePic;
                iEPhoneDetail = tempInfo.Detail;
                iPhonePhotos = tempInfo.PhoneGallery;
                try
                {
                    picPhone.Image =
                        Image.FromStream(
                            WebRequest.Create("http://skymobile.com.cn/shop/" + tempInfo.PhonePic).GetResponse
                                ().GetResponseStream());
                }
                catch (Exception)
                {
                    picPhone.Image = null;
                }
            }
            else
            {
                MessageBox.Show(Resources.frmMain_cmbPhone_SelectedIndexChanged_ + tempInfo.ErrString, Text,
                                MessageBoxButtons.OK);
            }
            picWait.Visible = false;
        }

        private void cmdEPEval_Click(object sender, EventArgs e)
        {
            var HTMLEditor = new frmHTML {HTMLCode = iEPhoneDetail};

            DialogResult iReturn = HTMLEditor.ShowDialog(this);
            if (iReturn == DialogResult.OK)
            {
                iEPhoneDetail = HTMLEditor.HTMLCode;
            }
        }

        private void cmdEPhotos_Click(object sender, EventArgs e)
        {
            var PhotoEditor = new frmPhotos();
            if (iPhonePhotos == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(iPhonePhotos[0]) || iPhonePhotos.Length <= 0) return;
            PhotoEditor.iAddMode = false;
            PhotoEditor.iMainPhoto = iPhoneImg;
            PhotoEditor.iPhotos = iPhonePhotos;
            DialogResult iResult = PhotoEditor.ShowDialog();

            if (iResult != DialogResult.Cancel) return;
            PhotoEditor.Dispose();
            Directory.Delete(Application.StartupPath + @"\Temp", true);
            Directory.CreateDirectory(Application.StartupPath + @"\Temp"); //创建文件夹
        }

        #region 删除手机

        private void cmdDeletePhone_Click(object sender, EventArgs e)
        {
            //已经将ID绑定到了TAG标记上.直接删除就可以了
            picWait.Visible = true;

            DelegateDeletePhone dn = DataController.DeletePhone;

            IAsyncResult iar = dn.BeginInvoke(cmdDeletePhone.Tag.ToString(), null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            MysqlController.ReturnResult iResult = dn.EndInvoke(iar);

            if (iResult.isSuccess)
            {
                picWait.Visible = false;
                MessageBox.Show(Resources.frmMain_cmdDeletePhone_Click_删除该手机成功_, Application.ProductName,
                                MessageBoxButtons.OK);
                CleanBox();
            }
            else
            {
                picWait.Visible = false;
                MessageBox.Show(Resources.frmMain_cmdDeletePhone_Click_删除该手机失败__失败原因__r_n + iResult.ErrDesc,
                                Application.ProductName, MessageBoxButtons.OK);
            }
        }

        private delegate MysqlController.ReturnResult DelegateDeletePhone(string iPhoneID);

        #endregion

        #region Nested type: DelegateReadExistPhone

        private delegate MysqlController.SPhoneInfo DelegateReadExistPhone(string iID);

        #endregion

        #region Nested type: DelegateReadPhones

        private delegate DataTable DelegateReadPhones(int iNum);

        #endregion

        #endregion

        #region 增加手机界面的操作事件

        private void cmdAPEval_Click(object sender, EventArgs e)
        {
            var HTMLEditor = new frmHTML();
            DialogResult iReturn = HTMLEditor.ShowDialog(this);
            if (iReturn == DialogResult.OK)
            {
                iEnvHTML = HTMLEditor.HTMLCode;
            }
        }

        private void cmdAPhotos_Click(object sender, EventArgs e)
        {
            var PhotoEditor = new frmPhotos {iAddMode = true};
            DialogResult iReturn = PhotoEditor.ShowDialog();
            if (iReturn != DialogResult.OK) return;
            iMainPhoto = PhotoEditor.iMainPhoto;
            iPhotos = PhotoEditor.iPhotos;
            //Do Upload and SQL
        }

        private void cmdSeePhone_Click(object sender, EventArgs e)
        {
            if (iAddedPhoneID > 0)
            {
                //"http://www.skymobile.com.cn/shop/goods.php?id=" + iAddedPhoneID
                Process.Start("http://www.skymobile.com.cn/shop/goods.php?id=" + iAddedPhoneID);
            }
        }

        #endregion

        #region 清空BOX

        private void CleanBox()
        {
            //ADD
            txtPhoneName.Text = "";
            txtYRUrl.Text = "";
            txtPCUrl.Text = "";
            txtEquipment.Text = "";
            txtTBURL.Text = "";
            txtKeywords.Text = "";
            txtPhoneShortName.Text = "";

            for (int i = 0; i < 21; i++)
            {
                ((CheckBox) gpCAP.Controls.Find("ckbCA" + (i + 1), false)[0]).Checked = false;
                Application.DoEvents();
            }


            //EDIT
            cmbPhone.Items.Clear();
            txtCount.Text = "";
            txtEEquipment.Text = "";
            ckbisBest.Checked = false;
            ckbisNew.Checked = false;
            ckbisHot.Checked = false;
            picPhone.Image = null;
            txtEKeywords.Text = "";
            txtETBURL.Text = "";
            txtEPhoneShortName.Text = "";

            for (int i = 0; i < 21; i++)
            {
                ((CheckBox) gpACAP.Controls.Find("ckbACA" + (i + 1), false)[0]).Checked = false;
                Application.DoEvents();
            }

            //Globle

            iPhoneImg = "";
            iPhonePhotos = null;
            iEPhoneDetail = "";
            iMainPhoto = "";
            iPhotos = null;
            iEnvHTML = null;

            //iAddedPhoneID = 0;
        }

        #endregion

        #endregion

        private void cmbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdSeePhone.Visible = false;
        }

        public void SetWindowRegion()
        {
            GraphicsPath FormPath;
            FormPath = new GraphicsPath();
            var rect = new Rectangle(0, 10, Width, Height - 10);
            //this.Left-10,this.Top-10,this.Width-10,this.Height-10);                 
            FormPath = GetRoundedRectPath(rect, 10);
            Region = new Region(FormPath);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            var arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            var path = new GraphicsPath();
            //   左上角   
            path.AddArc(arcRect, 180, 90);
            //   右上角   
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            //   右下角   
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            //   左下角   
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void txtPhoneName_TextChanged(object sender, EventArgs e)
        {
            cmdSeePhone.Visible = false;
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Region = null;
            SetWindowRegion();
        }

        private void cmdEditPhoneByWeb_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.skymobile.com.cn/shop/ToT/goods.php?act=edit&goods_id=" + cmdDeletePhone.Tag);
        }
    }
}