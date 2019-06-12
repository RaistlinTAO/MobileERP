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
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;
    using LongXiangBox.Properties;

    #endregion

    public partial class frmPhotos : Form
    {
        public bool iAddMode;
        public string iMainPhoto;
        public string[] iPhotos;

        public frmPhotos()
        {
            InitializeComponent();
        }

        private void cmdMain_Click(object sender, EventArgs e)
        {
            ofdMain.Title = Resources.frmPhotos_cmdMain_Click_Select_Main_Photo_of_Phone;
            ofdMain.Filter = Resources.frmPhotos_cmdMain_Click_JPEG_FILE___jpg;
            ofdMain.FileName = "";
            ofdMain.Multiselect = false;
            DialogResult iResult = ofdMain.ShowDialog();
            if (iResult != DialogResult.OK) return;
            if (!iAddMode)
            {
            }
            else
            {
                iMainPhoto = ofdMain.FileName;
                picPhoneMain.Image = Image.FromFile(ofdMain.FileName);
            }
        }

        private void cmdPhotos_Click(object sender, EventArgs e)
        {
            ofdMain.Title = Resources.frmPhotos_cmdPhotos_Click_Select_Photos_of_Phone;
            ofdMain.Filter = Resources.frmPhotos_cmdMain_Click_JPEG_FILE___jpg;
            ofdMain.FileName = "";
            ofdMain.Multiselect = true;
            DialogResult iResult = ofdMain.ShowDialog();
            if (iResult != DialogResult.OK) return;
            if (!iAddMode) return;
            iPhotos = ofdMain.FileNames;

            for (int i = 0; i < ofdMain.FileNames.Length; i++)
            {
                imlistPhotos.Images.Add(Image.FromFile(ofdMain.FileNames[i]));
                lsvPhotos.LargeImageList = imlistPhotos;
                lsvPhotos.Items.Add((i + 1).ToString());
                lsvPhotos.Items[i].ImageIndex = i;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            picPhoneMain.Image = null;
            imlistPhotos.Images.Clear();
            lsvPhotos.Items.Clear();
            DialogResult = DialogResult.OK;
        }

        private void frmPhotos_Load(object sender, EventArgs e)
        {
            imlistPhotos.ColorDepth = ColorDepth.Depth24Bit;
            imlistPhotos.ImageSize = new Size(80, 80);

            if (iAddMode) return;
            var mywebclient = new WebClient();
            if (string.IsNullOrEmpty(iMainPhoto)) return;
            if (File.Exists(Application.StartupPath + @"\Temp\tempMain.jpg"))
            {
                File.Delete(Application.StartupPath + @"\Temp\tempMain.jpg");
            }

            mywebclient.DownloadFile("http://skymobile.com.cn/LongXiang/shop/" + iMainPhoto,
                                     Application.StartupPath + @"\Temp\tempMain.jpg");
            picPhoneMain.Image = Image.FromFile(Application.StartupPath + @"\Temp\tempMain.jpg");

            for (int i = 0; i < iPhotos.Length; i++)
            {
                if (string.IsNullOrEmpty(iPhotos[i])) continue;
                if (File.Exists(Application.StartupPath + @"\Temp\tempGallery" + i + ".jpg"))
                {
                    File.Delete(Application.StartupPath + @"\Temp\tempGallery" + i + ".jpg");
                }
                mywebclient.DownloadFile("http://skymobile.com.cn/LongXiang/shop/" + iPhotos[i],
                                         Application.StartupPath + @"\Temp\tempGallery" + i + ".jpg");
                imlistPhotos.Images.Add(
                    Image.FromFile(Application.StartupPath + @"\Temp\tempGallery" + i + ".jpg"));
                lsvPhotos.LargeImageList = imlistPhotos;
                lsvPhotos.Items.Add((i + 1).ToString());
                lsvPhotos.Items[i].ImageIndex = i;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            picPhoneMain.Image = null;
            imlistPhotos.Images.Clear();
            lsvPhotos.Items.Clear();
            DialogResult = DialogResult.Cancel;
        }
    }
}