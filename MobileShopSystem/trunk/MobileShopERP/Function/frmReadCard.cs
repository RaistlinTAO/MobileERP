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
namespace MobileShopERP.Function
{
    #region

    using System;
    using System.Windows.Forms;

    #endregion

    public partial class frmReadCard : Form
    {
        public string iCardNum = "";


        public frmReadCard()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtReadCard_TextChanged(object sender, EventArgs e)
        {
            if (txtReadCard.Text.Length == 6)
            {
                lblBXKid.Text = txtReadCard.Text;
                txtReadCard.Text = "";
                cmdOK.Enabled = true;
            }
        }

        private void frmReadCard_Load(object sender, EventArgs e)
        {
            txtReadCard.Text = "";
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            iCardNum = lblBXKid.Text;
            DialogResult = DialogResult.OK;
        }
    }
}