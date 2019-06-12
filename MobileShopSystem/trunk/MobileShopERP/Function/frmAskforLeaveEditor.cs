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
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using MobileShopERP.Properties;

    #endregion

    public partial class frmAskforLeaveEditor : Form
    {
        //private readonly MysqlController MysqlControl = new MysqlController();
        public MysqlController.AskForLeave iAsk;
        public string tempSeller;

        public frmAskforLeaveEditor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmAskforLeaveEditor_Load(object sender, EventArgs e)
        {
            groupBox1.Text = Resources.frmAskforLeaveEditor_frmAskforLeaveEditor_Load_修改请假记录____销售人员__ + tempSeller;
            dtpAskDate.Value = new DateTime(int.Parse(iAsk.AskDate.Substring(0, 4)),
                                            int.Parse(iAsk.AskDate.Substring(4, 2)),
                                            int.Parse(iAsk.AskDate.Substring(6, 2)))
                ;
            cmbAskType.SelectedIndex = iAsk.AskType;
            txtAskDuration.Text = iAsk.AskDuration;
            txtAskResult.Text = iAsk.AskTip;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtAskDuration.Text == "" || !Regex.IsMatch(txtAskDuration.Text.Trim(), @"^[0-9]+$"))
            {
                MessageBox.Show(Resources.frmAskforLeaveEditor_cmdOK_Click_请填写正确的请假时间_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            iAsk.AskDate = dtpAskDate.Value.Year + dtpAskDate.Value.Month.ToString().PadLeft(2, '0') +
                           dtpAskDate.Value.Day.ToString().PadLeft(2, '0');
            iAsk.AskDuration = txtAskDuration.Text;
            iAsk.AskTip = txtAskResult.Text;
            iAsk.AskType = cmbAskType.SelectedIndex;

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n请假人员:" +
                groupBox1.Text.Replace(Resources.frmAskforLeaveEditor_frmAskforLeaveEditor_Load_修改请假记录____销售人员__, "") +
                "\r\n请假时间:" + dtpAskDate.Value.Year +
                dtpAskDate.Value.Month.ToString().PadLeft(2, '0') +
                dtpAskDate.Value.Day.ToString().PadLeft(2, '0') + "\r\n请假类型:" + cmbAskType.Text + "\r\n请假天数:" +
                txtAskDuration.Text + "\r\n请假原因:" + txtAskResult.Text, Application.ProductName,
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                return;
            }
        }
    }
}