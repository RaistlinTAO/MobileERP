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
    using System.Windows.Forms;
    using SystemControl.ini;
    using DataControler.Crype;
    using LongXiangBox.Properties;

    #endregion

    public partial class frmLogin : Form
    {
        private readonly clsINI iSetting = new clsINI(Application.StartupPath + @"\BoxSetting.sys");

        public frmLogin()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string iTemp = iSetting.IniReadValue("System", "CMSPassword");
            var iCrype = new EnDeCrype();

            iTemp = iCrype.CryptString(iTemp);
            if (textBox1.Text != iTemp) return;
            var newForm = new frmMain();
            Hide();
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            label3.Text = label3.Text + Resources.frmLogin_frmLogin_Load__V + Application.ProductVersion;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}