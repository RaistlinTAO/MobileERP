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
namespace MobileShopKeygen
{
    #region

    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Crype;
    using MobileShopKeygen.Properties;

//using SystemControl.KSystem;

    #endregion

    public partial class frmMain : Form
    {
        private readonly EnDeCrype iCrype = new EnDeCrype();
        private readonly clsKeyHash iHash = new clsKeyHash();
        //private readonly clsEnviron iSystem = new clsEnviron();


        public frmMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //txtReqCode.Text = iHash.EncryptRijndael(iHash.GetLocaleCode());
            MessageBox.Show(iHash.CheckCDEKY(txtCDKEY.Text, "7") ? "CDKEY OK!" : "CDKEY WRONG!");
        }

        private void cmdReadInfo_Click(object sender, EventArgs e)
        {
            if (txtReqCode.Text != "")
            {
                try
                {
                    string itemp = iHash.DecryptRijndael(txtReqCode.Text);
                    itemp = itemp.Replace(iHash.EncryptRijndael(iHash.QKey()), "");
                    itemp = itemp.Replace(iCrype.CryptString(iHash.EKey()), "！");
                    string[] iArray = Regex.Split(itemp, "！");
                    lblMACAddr.Text = iHash.DecryptRijndael(iCrype.CryptString(iArray[0]));
                    lblCPUID.Text = iHash.DecryptRijndael(iCrype.CryptString(iArray[1]));
                    lblCPULevel.Text = iHash.DecryptRijndael(iCrype.CryptString(iArray[2]));
                    lblCPUVersion.Text = iHash.DecryptRijndael(iCrype.CryptString(iArray[3]));
                    lblHDID.Text = iHash.DecryptRijndael(iCrype.CryptString(iArray[4]));
                    lblWinDir.Text = iHash.DecryptRijndael(iCrype.CryptString(iArray[5]));
                    lblMarchineName.Text = iHash.DecryptRijndael(iCrype.CryptString(iArray[6]));
                    txtReqTime.Text = iHash.DecryptRijndael(iCrype.CryptString(iArray[7]));
                }
                catch (Exception)
                {
                    MessageBox.Show(Resources.frmMain_cmdReadInfo_Click_WRONG_REQ_CODE_);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbMonth.SelectedIndex = 0;
            Text = Text + Resources.frmMain_frmMain_Load__Version_ + Application.ProductVersion;
            txtActTime.Text = DateTime.Now.Year + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
        }

        private void cmdGen_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCDKEY.Text == "" || txtReqCode.Text == "") return;
                if (txtHashCode.Text != "") return;
                //CryptStringWithKey
                string itemp = iCrype.CryptStringWithKey(iHash.EncryptRijndael(iHash.EKey()),
                                                         "7", "8");

                itemp = itemp + cmbMonth.Text;
                itemp = itemp + iCrype.CryptString(iHash.EKey());

                itemp = itemp + iCrype.CryptString(iHash.EncryptRijndael(lblCPUID.Text));
                itemp = itemp + iCrype.CryptString(iHash.EKey());

                itemp = itemp + iCrype.CryptString(iHash.EncryptRijndael(lblHDID.Text));
                itemp = itemp + iCrype.CryptString(iHash.EKey());

                itemp = itemp + iCrype.CryptString(iHash.EncryptRijndael(lblWinDir.Text));
                itemp = itemp + iCrype.CryptString(iHash.EKey());

                itemp = itemp + iCrype.CryptString(iHash.EncryptRijndael(lblMarchineName.Text));
                itemp = itemp + iCrype.CryptString(iHash.EKey());

                itemp = itemp + iCrype.CryptString(iHash.EncryptRijndael(txtCDKEY.Text));
                itemp = itemp + iCrype.CryptString(iHash.EKey());

                itemp = itemp + iCrype.CryptString(iHash.EncryptRijndael(txtReqTime.Text));
                itemp = itemp + iCrype.CryptString(iHash.EKey());

                itemp = itemp + iCrype.CryptString(iHash.EncryptRijndael(txtActTime.Text));

                itemp = iCrype.CryptString(itemp);
                txtHashCode.Text = itemp;
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.frmMain_cmdGen_Click_Need_Information_To_Gen_);
            }
        }

        private static void button1_Click(object sender, EventArgs e)
        {
            var iNew = new frmKeyMaker();
            iNew.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtReqCode.Text = iHash.EncryptRijndael(iHash.GetLocaleCode());
        }
    }
}