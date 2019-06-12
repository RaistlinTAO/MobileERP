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
namespace MobileShopERP.View
{
    #region

    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using DataControler.Crype;

    #endregion

    public partial class frmActive : Form
    {
        private readonly EnDeCrype iCrype = new EnDeCrype();
        private readonly clsKeyHash iHash = new clsKeyHash();

        public frmActive()
        {
            InitializeComponent();
        }

        private void frmActive_Load(object sender, EventArgs e)
        {
            txtReqInfo.Text = iHash.EncryptRijndael(iHash.GetLocaleCode());
        }

        private void cmdQQ_Click(object sender, EventArgs e)
        {
            string qq = "35333120";
            Process.Start("tencent://message/?uin=" + qq + "&Site=www.baidu.com&Menu=yes");
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtReqInfo.Text);
        }

        private void cmdPaste_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();

            if (iData.GetDataPresent(DataFormats.Text))
            {
                txtActiveInfo.Text = (String) iData.GetData(DataFormats.Text);
            }
        }

        private void cmdCopyCDKEY_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtCDKEY.Text);
        }

        private void cmdTaoBao_Click(object sender, EventArgs e)
        {
            //aliim:sendmsg?uid=cntaobao&touid=cntaobaoXXX
            Process.Start("aliim:sendmsg?uid=cntaobao&touid=cntaobao以她念月");
        }

        private void cmdBuy_Click(object sender, EventArgs e)
        {
            Process.Start("http://shop60672130.taobao.com/");
        }

        private void txtActiveInfo_TextChanged(object sender, EventArgs e)
        {
            cmdActive.Enabled = true;
        }
    }
}