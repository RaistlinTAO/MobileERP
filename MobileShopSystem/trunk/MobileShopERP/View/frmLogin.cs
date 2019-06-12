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

namespace MobileShopERP.View
{
    #region

    using System;
    using System.Windows.Forms;
    using SystemControl.ini;
    using DataControler.Crype;
    using DataControler.Log;
    using DataControler.Mysql;
    using MobileShopERP.Function;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmLogin : Form
    {
        private readonly clsLog LogControl = new clsLog();
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly string ShopName;
        private readonly int[] TempIndex = new int[100];
        private readonly EnDeCrype iCrype = new EnDeCrype();
        private readonly clsINI iShopSetting = new clsINI(Application.StartupPath + @"\MobileShop.bin");
        private readonly clsINI iniControl = new clsINI(Application.StartupPath + @"\BoxSetting.sys");
        private string ShopCNName;
        private string[] Tempstr;
        private string[] Tempstrp;
        private string[] Tempstrx;

        public frmLogin()
        {
            InitializeComponent();
            MysqlController.MySQLIP = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlURL"));
            MysqlController.MySQLAccount = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlAccount"));
            MysqlController.MySQLPassword = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlPassword"));
            MysqlController.MySQLDatabase = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlDatabase"));
            clsLog.iMySQLIP = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlURL"));
            clsLog.iMySQLAccount = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlAccount"));
            clsLog.iMySQLPassword = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlPassword"));
            clsLog.iMySQLDatabase = iCrype.CryptString(iniControl.IniReadValue("Network", "MysqlDatabase"));
            ShopName =
                iCrype.CryptString(iShopSetting.IniReadValue(iCrype.CryptString("Setting"),
                                                             iCrype.CryptString("ShopName")));
            //ShopCNName = iShopSetting.IniReadValue(iCrype.CryptString("Setting"), iCrype.CryptString("ShopCNName"));
            label1.Text = ShopName + " ERP ";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            //Application.ExitThread();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempStr = iCrype.CryptString(iniControl.IniReadValue("System", "CRMPassword"));
            //string tempFakeStr = iCrype.CryptString(iniControl.IniReadValue("System", "CRMFakePassword"));

            if (cmbUser.Text == "ERP管理员" && textBox1.Text == tempStr)
            {
                Hide();
                var iMain = new frmMain {LoginType = true, LoginUser = cmbUser.Text};
                iMain.ShowDialog();
                Close();
                Application.Exit();
            }
            else if (cmbUser.Text != "ERP管理员" && textBox1.Text == Tempstrp[TempIndex[cmbUser.SelectedIndex]])
            {
                Hide();
                var iMain = new frmMain {LoginType = false, LoginUser = cmbUser.Text};
                iMain.ShowDialog();
                Close();
                Application.Exit();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            label1.Text = label1.Text + Resources.frmLogin_frmLogin_Load__Version_ + Application.ProductVersion;
            //CRM 管理员
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            cmbUser.Items.Clear();

            try
            {
                DelegateSellers dn = MysqlControl.Sellers;

                IAsyncResult iar = dn.BeginInvoke(null, null);

                while (iar.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                Tempstr = dn.EndInvoke(iar);

                DelegateSellersPosition dn1 = MysqlControl.SellersPosition;

                IAsyncResult iar1 = dn1.BeginInvoke(null, null);

                while (iar1.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                Tempstrx = dn1.EndInvoke(iar1);

                DelegateSellersPassword dn2 = MysqlControl.SellersPassword;

                IAsyncResult iar2 = dn2.BeginInvoke(null, null);

                while (iar2.IsCompleted == false)
                {
                    Application.DoEvents();
                }

                Tempstrp = dn2.EndInvoke(iar2);

                //Tempstr = MysqlControl.Sellers();
                //Tempstrx = MysqlControl.SellersPosition();
                //Tempstrp = MysqlControl.SellersPassword();
                int k = 0;
                for (int i = 0; i < Tempstr.Length; i++)
                {
                    if (Tempstr[i] != null && Tempstr[i] != "")
                    {
                        if (Tempstrx[i] == "销售" || Tempstrx[i] == "店长")
                        {
                            TempIndex[k] = i;
                            cmbUser.Items.Add(Tempstr[i]);
                            k++;
                        }
                    }
                }
                cmbUser.Items.Add("ERP管理员");
                cmbUser.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("检测到数据库连接异常,请稍候重试!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tempStr = iCrype.CryptString(iniControl.IniReadValue("System", "CRMPassword"));
            if (textBox1.Text == tempStr)
            {
                var iSetting = new frmSetting();
                iSetting.ShowDialog();
                Show();
            }
        }

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion

        #region Nested type: DelegateSellersPassword

        private delegate string[] DelegateSellersPassword();

        #endregion

        #region Nested type: DelegateSellersPosition

        private delegate string[] DelegateSellersPosition();

        #endregion
    }
}