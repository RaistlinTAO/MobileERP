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
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using SystemControl.ini;
    using DataControler.Crype;
    using LongXiangTutorialController.Properties;

    #endregion

    public partial class frmInstallService : Form
    {
        private readonly EnDeCrype iCrype = new EnDeCrype();
        private readonly clsINI iniControl = new clsINI(Application.StartupPath + @"\SoftwareUpdate.bin");

        public frmInstallService()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //发送消息//winuser.h 中有函数原型定义
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void frmInstallService_Load(object sender, EventArgs e)
        {
            txtSavePath.Text = Application.StartupPath + @"\";
            txtCVSPath.Text = Application.StartupPath + @"\";
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            fbdPath.Description =
                Resources.
                    frmInstallService_cmdSelect_Click_选择一个目录用以保存常用软件_程序将自动生成子目录__请注意_该选择在重新安装服务前_无法更改_手动修改该目录将会导致严重的后果_;
            fbdPath.ShowNewFolderButton = true;
            if (fbdPath.ShowDialog() == DialogResult.OK)
            {
                txtSavePath.Text = fbdPath.SelectedPath;
            }
        }

        private void cmdInstall_Click(object sender, EventArgs e)
        {
            //保存配置文件
            iniControl.IniWriteValue(iCrype.CryptString("ServiceInfo"), iCrype.CryptString("Duration"),
                                     iCrype.CryptString(txtTime.Text));
            iniControl.IniWriteValue(iCrype.CryptString("ServiceInfo"), iCrype.CryptString("SavePath"),
                                     iCrype.CryptString(txtSavePath.Text));
            iniControl.IniWriteValue(iCrype.CryptString("ServiceInfo"), iCrype.CryptString("CVSPath"),
                                     iCrype.CryptString(txtCVSPath.Text));
            iniControl.IniWriteValue(iCrype.CryptString("ServiceSetting"), iCrype.CryptString("NotifyMe"),
                                     ckbUpdateNotify.Checked ? iCrype.CryptString("1") : iCrype.CryptString("0"));
            //ckbNoBusy
            iniControl.IniWriteValue(iCrype.CryptString("ServiceSetting"), iCrype.CryptString("NoBusyUpdate"),
                                     ckbNoBusy.Checked ? iCrype.CryptString("1") : iCrype.CryptString("0"));
            //ckbAutoUpdateNotify
            iniControl.IniWriteValue(iCrype.CryptString("ServiceSetting"), iCrype.CryptString("AutoUpdateNotify"),
                                     ckbAutoUpdateNotify.Checked ? iCrype.CryptString("1") : iCrype.CryptString("0"));

            //安装服务


            //按需设置服务

            DialogResult = DialogResult.OK;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmInstallService_Shown(object sender, EventArgs e)
        {
            try
            {
                txtTime.Text =
                    iCrype.CryptString(iniControl.IniReadValue(iCrype.CryptString("ServiceInfo"),
                                                               iCrype.CryptString("Duration")));
                txtSavePath.Text =
                    iCrype.CryptString(iniControl.IniReadValue(iCrype.CryptString("ServiceInfo"),
                                                               iCrype.CryptString("SavePath")));
                //iniControl.IniWriteValue(iCrype.CryptString("ServiceInfo"), iCrype.CryptString("CVSPath"), iCrype.CryptString(txtCVSPath.Text));
                txtCVSPath.Text =
                    iCrype.CryptString(iniControl.IniReadValue(iCrype.CryptString("ServiceInfo"),
                                                               iCrype.CryptString("CVSPath")));
                ckbUpdateNotify.Checked =
                    iCrype.CryptString(iniControl.IniReadValue(iCrype.CryptString("ServiceSetting"),
                                                               iCrype.CryptString("NotifyMe"))) ==
                    "1";
                ckbNoBusy.Checked =
                    iCrype.CryptString(iniControl.IniReadValue(iCrype.CryptString("ServiceSetting"),
                                                               iCrype.CryptString("NoBusyUpdate"))) == "1";
                ckbAutoUpdateNotify.Checked =
                    iCrype.CryptString(iniControl.IniReadValue(iCrype.CryptString("ServiceSetting"),
                                                               iCrype.CryptString("AutoUpdateNotify"))) == "1";
            }
            catch (Exception)
            {
                //Do Nothing
            }
        }

        private void frmInstallService_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 274, 61449, 0);
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 274, 61449, 0);
        }

        private void cmdCVSPath_Click(object sender, EventArgs e)
        {
            fbdPath.Description = "设置读取CVS读取目录";
            fbdPath.ShowNewFolderButton = true;
            if (fbdPath.ShowDialog() == DialogResult.OK)
            {
                txtCVSPath.Text = fbdPath.SelectedPath;
            }
        }
    }
}