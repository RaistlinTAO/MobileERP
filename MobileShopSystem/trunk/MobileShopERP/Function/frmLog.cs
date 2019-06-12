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
    using DataControler.Log;
    using DataControler.Mysql;

    #endregion

    public partial class frmLog : Form
    {
        //private readonly MysqlController MysqlControl = new MysqlController();
        private readonly clsLog LogControl = new clsLog();
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();

        public frmLog(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            cmdView.Enabled = false;

            DelegateReadLog dn = LogControl.ReadLog;

            IAsyncResult iar = dn.BeginInvoke(DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0'), null,
                                              null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            clsLog.LogPart[] tempLog = dn.EndInvoke(iar);

            lsvLog.Items.Clear();
            if (tempLog == null) return;
            if (tempLog.Length > 0)
            {
                for (int i = 0; i < tempLog.Length; i++)
                {
                    if (string.IsNullOrEmpty(tempLog[i].LogDate)) continue;
                    lsvLog.Items.Add(tempLog[i].LogID.ToString());
                    lsvLog.Items[i].SubItems.Add(tempLog[i].LogDate);
                    lsvLog.Items[i].SubItems.Add(tempLog[i].LogTime);
                    lsvLog.Items[i].SubItems.Add(tempLog[i].LogUser);
                    lsvLog.Items[i].SubItems.Add(tempLog[i].LogDetail);
                    Application.DoEvents();
                }
            }
            cmdView.Enabled = true;
            isBusy.Visible = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            cmdDelete.Enabled = false;
            isBusy.Visible = true;

            DelegateDelLog dn = LogControl.DelLog;

            IAsyncResult iar =
                dn.BeginInvoke(DateTime.Now.Year + DateTime.Now.AddMonths(-1).Month.ToString().PadLeft(2, '0'), null,
                               null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            dn.EndInvoke(iar);

            isBusy.Visible = false;
            cmdDelete.Enabled = true;
        }

        #region Nested type: DelegateDelLog

        private delegate MysqlController.ReturnResult DelegateDelLog(string DateStr);

        #endregion

        #region Nested type: DelegateReadLog

        private delegate clsLog.LogPart[] DelegateReadLog(String DateStr);

        #endregion
    }
}