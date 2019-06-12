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

    #endregion

    public partial class SearchDialog : Form
    {
        private static string _last;
        private readonly SearchableBrowser _browser;

        public SearchDialog(SearchableBrowser browser)
        {
            _browser = browser;
            InitializeComponent();
            downButton.Checked = true;
            searchString.Text = _last;
            findButton.Enabled = searchString.Text.Length > 0;
            Disposed += SearchDialog_Disposed;
            searchString.TextChanged += searchString_TextChanged;
        }

        private void searchString_TextChanged(object sender, EventArgs e)
        {
            findButton.Enabled = searchString.Text.Length > 0;
        }

        private void SearchDialog_Disposed(object sender, EventArgs e)
        {
            _last = searchString.Text;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if (!_browser.Search(searchString.Text, downButton.Checked, matchWholeWord.Checked, matchCase.Checked))
            {
                MessageBox.Show(this, "Finished searching the document.", "Explorer", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public interface SearchableBrowser
    {
        bool Search(string text, bool forward, bool matchWholeWord, bool matchCase);
    }
}