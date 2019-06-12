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
    using System.Data;
    using System.Windows.Forms;
    using MobileShopERP.Properties;
    using MySql.Data.MySqlClient;

    #endregion

    public partial class frmSellers : Form
    {
        public string MysqlAccount;
        public string MysqlDatabase;
        public string MysqlPassword;
        public string MysqlURL;

        private MySqlCommandBuilder cb;
        private MySqlDataAdapter da;
        private DataTable sellers;

        public frmSellers()
        {
            InitializeComponent();
        }

        private void frmSellers_Load(object sender, EventArgs e)
        {
            sellers = new DataTable();

            var iMySQLconn =
                new MySqlConnection("Server=" + MysqlURL + ";Database=" + MysqlDatabase + ";Uid=" + MysqlAccount +
                                    ";Pwd=" + MysqlPassword + "; CharSet=gbk;");
            try
            {
                iMySQLconn.Open();
                da = new MySqlDataAdapter("SELECT * FROM crm_sellers", iMySQLconn);
                cb = new MySqlCommandBuilder(da);

                da.Fill(sellers);
                iMySQLconn.Close();

                dtSellers.DataSource = sellers;
                dtSellers.Columns[0].HeaderText = Resources.frmSellers_frmSellers_Load_人员编号;
                dtSellers.Columns[1].HeaderText = Resources.frmSellers_frmSellers_Load_人员姓名;
                dtSellers.Columns[2].HeaderText = Resources.frmSellers_frmSellers_Load_职位;
                dtSellers.Columns[3].HeaderText = "CRM登录密码";
                dtSellers.Columns[4].HeaderText = "基本工资";
                dtSellers.Columns[5].HeaderText = "通讯费";
                dtSellers.Columns[6].HeaderText = "房租补贴";
            }
            catch (Exception)
            {
                sellers = null;
                MessageBox.Show(Resources.frmSellers_frmSellers_Load_读取数据库失败_, Application.ProductName,
                                MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            DataTable changes = sellers.GetChanges();
            if (changes != null)
            {
                try
                {
                    da.Update(changes);
                    sellers.AcceptChanges();
                    MessageBox.Show(Resources.frmSellers_button1_Click_用户更改已经成功);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.frmSellers_button1_Click_ + ex.Message);
                }
            }
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            for (int i = 0; i < dtSellers.SelectedRows.Count; i++)
            {
                dtSellers.Rows.Remove(dtSellers.SelectedRows[i]);
            }
            button2.Enabled = true;
        }
    }
}