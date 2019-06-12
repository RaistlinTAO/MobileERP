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
namespace DataAssistant.View
{
    #region

    using System;
    using System.IO;
    using System.Management;
    using System.Reflection;
    using System.Windows.Forms;
    using SystemControl.ini;
    using DataAssistant.Properties;
    using SevenZip;

    #endregion

    public partial class frmInstall : Form
    {
        public frmInstall()
        {
            InitializeComponent();
        }

        private static string Distinguish64or32System()
        {
            try
            {
                string addressWidth = String.Empty;
                var mConnOption = new ConnectionOptions();
                var mMs = new ManagementScope("\\\\localhost", mConnOption);
                var mQuery = new ObjectQuery("select AddressWidth from Win32_Processor");
                var mSearcher = new ManagementObjectSearcher(mMs, mQuery);
                ManagementObjectCollection mObjectCollection = mSearcher.Get();
                foreach (ManagementBaseObject mObject in mObjectCollection)
                {
                    addressWidth = mObject["AddressWidth"].ToString();
                }
                return addressWidth;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return String.Empty;
            }
        }

        private void installBaseSQL()
        {
            lblText.Text = DateTime.Now.Hour.ToString("00") + Resources.frmInstall_installBaseSQL__ +
                           DateTime.Now.Minute.ToString("00") + Resources.frmInstall_installBaseSQL______ +
                           Resources.frmInstall_installBaseSQL_正在安装基础包;


            Stream sm = Assembly.GetEntryAssembly().GetManifestResourceStream("DataAssistant.HTC.7z");

            var ext = new SevenZipExtractor(sm);

            for (int i = 0; i < ext.FilesCount; ++i)
            {
                ext.ExtractFiles(Application.StartupPath + @"\core", i);
                prbMain.Value = prbMain.Value + 1;
                Application.DoEvents();
            }
        }


        private void frmInstall_Shown(object sender, EventArgs e)
        {
            lblText.Text = DateTime.Now.Hour.ToString("00") + Resources.frmInstall_installBaseSQL__ +
                           DateTime.Now.Minute.ToString("00") + Resources.frmInstall_installBaseSQL______ +
                           Resources.frmInstall_frmInstall_Shown_系统初始化结束;
            prbMain.Value = prbMain.Value + 1;
            lblText.Text = DateTime.Now.Hour.ToString("00") + Resources.frmInstall_installBaseSQL__ +
                           DateTime.Now.Minute.ToString("00") + Resources.frmInstall_installBaseSQL______ +
                           Resources.frmInstall_frmInstall_Shown_请等待完成;
            prbMain.Value = prbMain.Value + 1;
            lblText.Text = DateTime.Now.Hour.ToString("00") + Resources.frmInstall_installBaseSQL__ +
                           DateTime.Now.Minute.ToString("00") + Resources.frmInstall_installBaseSQL______ +
                           Resources.frmInstall_frmInstall_Shown_正在判别操作系统版本_;
            prbMain.Value = prbMain.Value + 1;

            installBaseSQL();

            Stream sm;

            if (Distinguish64or32System() == "32")
            {
                //32位
                lblText.Text = DateTime.Now.Hour.ToString("00") + Resources.frmInstall_installBaseSQL__ +
                               DateTime.Now.Minute.ToString("00") + Resources.frmInstall_installBaseSQL______ +
                               Resources.frmInstall_frmInstall_Shown_正在为32位系统初始化_;
                sm = Assembly.GetEntryAssembly().GetManifestResourceStream("DataAssistant.X86.7z");
            }
            else
            {
                //64位
                lblText.Text = DateTime.Now.Hour.ToString("00") + Resources.frmInstall_installBaseSQL__ +
                               DateTime.Now.Minute.ToString("00") + Resources.frmInstall_installBaseSQL______ +
                               Resources.frmInstall_frmInstall_Shown_正在为64位系统初始化_;
                sm = Assembly.GetEntryAssembly().GetManifestResourceStream("DataAssistant.X64.7z");
            }

            var ext = new SevenZipExtractor(sm);
            for (int i = 0; i < ext.FilesCount; ++i)
            {
                ext.ExtractFiles(Application.StartupPath + @"\core", i);
                prbMain.Value = prbMain.Value + 1;
                Application.DoEvents();
            }

            lblText.Text = DateTime.Now.Hour.ToString("00") + Resources.frmInstall_installBaseSQL__ +
                           DateTime.Now.Minute.ToString("00") + Resources.frmInstall_installBaseSQL______ +
                           Resources.frmInstall_frmInstall_Shown_初始化完毕_等待写入数据文件;
            //////////所有定制文件解压完毕
            prbMain.Value = prbMain.Value + 1;

            sm = Assembly.GetEntryAssembly().GetManifestResourceStream("DataAssistant.SQLdata.7z");
            lblText.Text = DateTime.Now.Hour.ToString("00") + Resources.frmInstall_installBaseSQL__ +
                           DateTime.Now.Minute.ToString("00") + Resources.frmInstall_installBaseSQL______ +
                           Resources.frmInstall_frmInstall_Shown_正在写入数据文件;
            ext = new SevenZipExtractor(sm);
            for (int i = 0; i < ext.FilesCount; ++i)
            {
                ext.ExtractFiles(Application.StartupPath + @"\core", i);
                prbMain.Value = prbMain.Value + 1;
                Application.DoEvents();
            }
            lblText.Text = DateTime.Now.Hour.ToString("00") + Resources.frmInstall_installBaseSQL__ +
                           DateTime.Now.Minute.ToString("00") + Resources.frmInstall_installBaseSQL______ +
                           Resources.frmInstall_frmInstall_Shown_数据文件写入完毕_等待配置;

            prbMain.Value = prbMain.Value + 1;
            //数据文件写入完毕,下面进行配置
            //先写入my.ini 然后对my.ini进行配置
            sm = Assembly.GetEntryAssembly().GetManifestResourceStream("DataAssistant.my.ini");
            var sr = new StreamReader(sm);
            var sw = new StreamWriter(Application.StartupPath + @"\core\bin\my.ini");
            sw.Write(sr.ReadToEnd());
            sw.Flush();
            sw.Close();
            sr.Close();

            var iniControl = new clsINI(Application.StartupPath + @"\core\bin\my.ini");

            iniControl.IniWriteValue("mysqld", "basedir",
                                     "\"" + (Application.StartupPath + @"\core\").Replace(@"\", @"/") + "\"");

            lblText.Text = DateTime.Now.Hour.ToString("00") + Resources.frmInstall_installBaseSQL__ +
                           DateTime.Now.Minute.ToString("00") + Resources.frmInstall_installBaseSQL______ +
                           Resources.frmInstall_frmInstall_Shown_配置完毕;
            prbMain.Value = prbMain.Value + 1;
            //然后写入start.bat 用于启动sql 当然 这个只是预设.现在没考虑如何实现数据库
            sm = Assembly.GetEntryAssembly().GetManifestResourceStream("DataAssistant.start.bat");
            var sr1 = new StreamReader(sm);
            var sw1 = new StreamWriter(Application.StartupPath + @"\core\start.bat");
            sw1.Write(sr1.ReadToEnd());
            sw1.Flush();
            sw1.Close();
            sr1.Close();
            prbMain.Value = prbMain.Value + 1;
            lblText.Text = DateTime.Now.Hour.ToString("00") + Resources.frmInstall_installBaseSQL__ +
                           DateTime.Now.Minute.ToString("00") + Resources.frmInstall_installBaseSQL______ +
                           Resources.frmInstall_frmInstall_Shown_所有操作全部完毕;
            MessageBox.Show(Resources.frmInstall_frmInstall_Shown_所有操作全部完毕, Application.ProductName,
                            MessageBoxButtons.OK);
            Application.Exit();
        }
    }
}