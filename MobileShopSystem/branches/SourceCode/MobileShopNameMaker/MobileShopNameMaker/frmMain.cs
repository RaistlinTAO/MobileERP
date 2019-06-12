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
namespace MobileShopNameMaker
{
    #region

    using System;
    using System.Windows.Forms;
    using SystemControl.ini;
    using DataControler.Crype;
    using MobileShopNameMaker.Properties;

    #endregion

    public partial class frmMain : Form
    {
        private readonly EnDeCrype iCrype = new EnDeCrype();
        private readonly clsINI iShopSetting = new clsINI(Application.StartupPath + @"\MobileShop.bin");

        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdMake_Click(object sender, EventArgs e)
        {
            iShopSetting.IniWriteValue(iCrype.CryptString("Setting"), iCrype.CryptString("ShopName"),
                                       iCrype.CryptString(txtShopName.Text));
            iShopSetting.IniWriteValue(iCrype.CryptString("Setting"), iCrype.CryptString("ShopCNName"),
                                       txtShopCNName.Text)
                ;
            MessageBox.Show(Resources.frmMain_cmdMake_Click_Make_Up_Name_File_OK_);
        }
    }
}