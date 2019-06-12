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

namespace SoftwareUpdater
{
    #region

    using System.ServiceProcess;
    using SystemControl.ini;
    using DataControler.Crype;

    #endregion

    internal partial class LongXiangSoftwareUpdater : ServiceBase
    {
        #region 数据准备

        private readonly string iniPath;
        private bool iAutoUpdateNotify;
        private string iDuration;
        private bool iNoBusyUpdate;
        private bool iNotifyME;
        private string iSavePath;

        public LongXiangSoftwareUpdater(string PathFile)
        {
            iniPath = PathFile;
            InitializeComponent();
        }

        #endregion

        #region 重载服务

        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            var iCrype = new EnDeCrype();
            var iniControl = new clsINI(iniPath + @"\SoftwareUpdate.bin");
            //读取配置文件
            iDuration = iCrype.CryptString(iniControl.IniReadValue("ServiceInfo", "Duration"));
            iSavePath = iCrype.CryptString(iniControl.IniReadValue("ServiceInfo", "SavePath"));
            iNotifyME = iCrype.CryptString(iniControl.IniReadValue("ServiceSetting", "NotifyMe")) ==
                        "1";
            iNoBusyUpdate = iCrype.CryptString(iniControl.IniReadValue("ServiceSetting", "NoBusyUpdate")) == "1";
            iAutoUpdateNotify =
                iCrype.CryptString(iniControl.IniReadValue("ServiceSetting", "AutoUpdateNotify")) == "1";

            //开启服务进行软件更新
        }


        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
        }

        #endregion

        #region 软件升级选项

        #endregion
    }
}