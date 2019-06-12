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

namespace LongXiangBox.View.HTMLView
{
    #region

    using System;
    using System.Windows.Forms;
    using LongXiangBox.Properties;

    #endregion

    public partial class LinkDialog : Form
    {
        private bool _accepted;

        public LinkDialog()
        {
            InitializeComponent();
            LoadUrls();
            linkEdit.TextChanged += linkEdit_TextChanged;
        }

        public string URL
        {
            get { return comboBox1.Text + linkEdit.Text.Trim(); }
        }

        public string URI
        {
            get { return linkEdit.Text.Trim(); }
        }

        public bool Accepted
        {
            get { return _accepted; }
        }

        private void linkEdit_TextChanged(object sender, EventArgs e)
        {
            label1.Text = URL;
        }

        private void LinkDialog_Load(object sender, EventArgs e)
        {
            label1.Text = URL;
            BeginInvoke((MethodInvoker) delegate { linkEdit.Focus(); });
        }

        private void LoadUrls()
        {
            string glob = Settings.Default.LinkDialogURLs;
            string[] urls = glob.Split(null);
            if (urls != null)
            {
                foreach (string url in urls)
                {
                    linkEdit.Items.Add(url);
                }
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string url = linkEdit.Text;
            string glob = Settings.Default.LinkDialogURLs;
            if (glob == null) glob = "";
            if (!glob.Contains(url))
            {
                if (glob.Length > 0)
                    glob += "\n";
                glob += url;
            }
            Settings.Default.LinkDialogURLs = glob;
            Settings.Default.Save();
            _accepted = true;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _accepted = false;
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = URL;
        }
    }
}