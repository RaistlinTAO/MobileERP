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

    public partial class frmEquipSellEditor : Form
    {
        private readonly MysqlController MysqlControl = new MysqlController();
        private readonly ToolStripStatusLabel isBusy = new ToolStripStatusLabel();
        public MysqlController.LXEquip iEquip;

        public frmEquipSellEditor(ToolStripStatusLabel iBusy)
        {
            isBusy = iBusy;
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtPrice.Text == "" || !Regex.IsMatch(txtPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmEquipSell_cmdAdd_Click_请填写正确的配件销售价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtRealPrice.Text == "" || !Regex.IsMatch(txtRealPrice.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))
            {
                MessageBox.Show(Resources.frmEquipSell_cmdAdd_Click_请填写正确的配件成本价格_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show(Resources.frmEquipSell_cmdAdd_Click_请填写正确的配件名称_, Application.ProductName,
                                MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show(
                "是否确认如下递交内容?\r\n配件名目:" + txtName.Text + "\r\n销售时间:" + dtpTime.Value.Year +
                dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                dtpTime.Value.Day.ToString().PadLeft(2, '0') + "\r\n销售价格:" + txtPrice.Text + "元\r\n实际成本:" +
                txtRealPrice.Text + "元\r\n供货商:" + txtSupplier.Text + "\r\n销售人:" + cmbSeller.Text + "\r\n备注:" +
                txtBackup.Text, Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                iEquip.EquipDate =
                    dtpTime.Value.Year + dtpTime.Value.Month.ToString().PadLeft(2, '0') +
                    dtpTime.Value.Day.ToString().PadLeft(2, '0');
                iEquip.EquipBackup = txtBackup.Text;
                iEquip.EquipName = txtName.Text;
                iEquip.EquipPrice = double.Parse(txtPrice.Text);
                iEquip.EquipRealPrice = double.Parse(txtRealPrice.Text);
                iEquip.EquipSellers = cmbSeller.Text;
                iEquip.EquipSupplier = txtSupplier.Text;
                iEquip.EquipPayment = cmbPayment.SelectedIndex;
                iEquip.EquipBuyer = txtEquipBuyer.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void frmEquipSellEditor_Shown(object sender, EventArgs e)
        {
            isBusy.Visible = true;
            DelegateSellers dn = MysqlControl.Sellers;

            IAsyncResult iar = dn.BeginInvoke(null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }

            string[] Tempstr = dn.EndInvoke(iar);
            for (int i = 0; i < Tempstr.Length; i++)
            {
                if (Tempstr[i] != null && Tempstr[i] != "")
                {
                    cmbSeller.Items.Add(Tempstr[i]);
                }
            }
            cmbSeller.SelectedIndex = 0;
            //cmbPayment.SelectedIndex = 0;

            dtpTime.Value = new DateTime(int.Parse(iEquip.EquipDate.Substring(0, 4)),
                                         int.Parse(iEquip.EquipDate.Substring(4, 2)),
                                         int.Parse(iEquip.EquipDate.Substring(6, 2)))
                ;
            txtBackup.Text = iEquip.EquipBackup;
            txtName.Text = iEquip.EquipName;
            txtPrice.Text = iEquip.EquipPrice.ToString();
            txtRealPrice.Text = iEquip.EquipRealPrice.ToString();
            cmbSeller.Text = iEquip.EquipSellers;
            txtSupplier.Text = iEquip.EquipSupplier;
            cmbPayment.SelectedIndex = iEquip.EquipPayment;
            txtEquipBuyer.Text = iEquip.EquipBuyer;
            isBusy.Visible = false;
        }

        private void frmEquipSellEditor_Load(object sender, EventArgs e)
        {
        }

        #region Nested type: DelegateSellers

        private delegate string[] DelegateSellers();

        #endregion
    }
}