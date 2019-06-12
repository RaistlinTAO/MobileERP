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
    using System.Windows.Forms;
    using SystemControl.ini;
    using DataControler.Crype;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmSetting : Form
    {
        private readonly EnDeCrype iCrype = new EnDeCrype();
        private readonly clsINI iniControl = new clsINI(Application.StartupPath + @"\BoxSetting.sys");


        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            txtSQLAccount.Text = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlAccount"));
            txtSQLDatabase.Text = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlDatabase"));
            txtSQLIP.Text = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlURL"));
            txtSQLPass.Text = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlPassword"));
            txtFTPAccount.Text = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPAccount"));
            txtFTPIP.Text = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPURL"));
            txtFTPPassword.Text = iCrype.CryptString(iniControl.IniReadValue("Network", "FTPPassword"));
            txtLXCMS.Text = iCrype.CryptString(iniControl.IniReadValue("System", "CMSPassword"));
            txtLXCRMYG.Text = iCrype.CryptString(iniControl.IniReadValue("System", "CRMFakePassword"));
            txtLXCRM.Text = iCrype.CryptString(iniControl.IniReadValue("System", "CRMPassword"));
            txtLXTool.Text = iCrype.CryptString(iniControl.IniReadValue("System", "TOOLSPassword"));

            txtP1.Text = iCrype.CryptString(iniControl.IniReadValue("Pay", "P1"));
            txtP2.Text = iCrype.CryptString(iniControl.IniReadValue("Pay", "P2"));
            txtP3.Text = iCrype.CryptString(iniControl.IniReadValue("Pay", "P3"));
            txtP4.Text = iCrype.CryptString(iniControl.IniReadValue("Pay", "P4"));
            txtP5.Text = iCrype.CryptString(iniControl.IniReadValue("Pay", "P5"));
            txtP6.Text = iCrype.CryptString(iniControl.IniReadValue("Pay", "P6"));
            txtP7.Text = iCrype.CryptString(iniControl.IniReadValue("Pay", "P7"));
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            cmdOK.Enabled = false;
            try
            {
                iniControl.IniWriteValue("Network", "MysqlAccount", iCrype.CryptString(txtSQLAccount.Text));
                iniControl.IniWriteValue("Network", "MysqlDatabase", iCrype.CryptString(txtSQLDatabase.Text));
                iniControl.IniWriteValue("Network", "MysqlURL", iCrype.CryptString(txtSQLIP.Text));
                iniControl.IniWriteValue("Network", "MysqlPassword", iCrype.CryptString(txtSQLPass.Text));
                iniControl.IniWriteValue("Network", "FTPAccount", iCrype.CryptString(txtFTPAccount.Text));
                iniControl.IniWriteValue("Network", "FTPURL", iCrype.CryptString(txtFTPIP.Text));
                iniControl.IniWriteValue("Network", "FTPPassword", iCrype.CryptString(txtFTPPassword.Text));
                iniControl.IniWriteValue("System", "CMSPassword", iCrype.CryptString(txtLXCMS.Text));
                iniControl.IniWriteValue("System", "CRMFakePassword", iCrype.CryptString(txtLXCRMYG.Text));
                iniControl.IniWriteValue("System", "CRMPassword", iCrype.CryptString(txtLXCRM.Text));
                iniControl.IniWriteValue("System", "TOOLSPassword", iCrype.CryptString(txtLXTool.Text));

                iniControl.IniWriteValue("Pay", "P1", iCrype.CryptString(txtP1.Text));
                iniControl.IniWriteValue("Pay", "P2", iCrype.CryptString(txtP2.Text));
                iniControl.IniWriteValue("Pay", "P3", iCrype.CryptString(txtP3.Text));
                iniControl.IniWriteValue("Pay", "P4", iCrype.CryptString(txtP4.Text));
                iniControl.IniWriteValue("Pay", "P5", iCrype.CryptString(txtP5.Text));
                iniControl.IniWriteValue("Pay", "P6", iCrype.CryptString(txtP6.Text));
                iniControl.IniWriteValue("Pay", "P7", iCrype.CryptString(txtP7.Text));
                MessageBox.Show(Resources.frmSetting_cmdOK_Click_修改配置成功_, Application.ProductName, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.frmSetting_cmdOK_Click_ + ex.Message, Application.ProductName,
                                MessageBoxButtons.OK);
            }
            cmdOK.Enabled = true;
            DialogResult = DialogResult.OK;
        }
    }
}