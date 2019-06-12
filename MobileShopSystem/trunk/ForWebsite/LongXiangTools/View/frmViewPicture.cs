#region SOURCE INFORMATION

// COPYRIGHT LICENCE
// 
//  Copyright (c) 2011, D.E.M.O.N Organization
//  All rights reserved.
// 
//  Redistribution and use in source and binary forms, with or without modification,
//  are permitted provided that the following conditions are met:
// 
//      * Redistributions of source code must retain the above copyright notice,
//      this list of conditions and the following disclaimer.
//      * Redistributions in binary form must reproduce the above copyright notice,
//      this list of conditions and the following disclaimer in the documentation
//      and/or other materials provided with the distribution.
//      * Neither D.E.M.O.N Organization nor its contributors
//      may be used to endorse or promote products derived from this
//      software without specific prior written permission.
// 
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
//  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
//  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//  DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
//  FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
//  DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
//  SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
//  CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
//  OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
//  THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 
// 
// 
// CODE DESCRIPTION
// 
//        Created by Raistlin.K @ D.E.M.O.N at  23:47  09/10/2011 .
//        E-Mail:                         DemonVK@Gmail.com
// 
//        Project Name:                   LongXiangTools
//        Module  Name:                   frmViewPicture.cs
//        Part Of:                        LongXiangTools
//        Last Change Date:               4:10 27/12/2011

#endregion

#region

#endregion

namespace LongXiangTools.View
{
    #region

    using System;
    using System.Windows.Forms;
    using DataControler.Mysql;
    using LongXiangTools.Properties;

    #endregion

    public partial class frmViewPicture : Form
    {
        private string[] imageFix;
        private int imageIndex;
        public MysqlController.SecondHands tempPhone;

        public frmViewPicture()
        {
            InitializeComponent();
        }

        private void frmViewPicture_Load(object sender, EventArgs e)
        {
            lblPhoneName.Text = tempPhone.PhoneName;

            imageFix = new string[4];
            imageFix[0] = @"http://www.skymobile.com.cn/attachments/" + tempPhone.PhonePicture;
            imageFix[1] = @"http://www.skymobile.com.cn/attachments/" + tempPhone.PhonePictureBack;
            imageFix[2] = @"http://www.skymobile.com.cn/attachments/" + tempPhone.PhonePictureOther1;
            imageFix[3] = @"http://www.skymobile.com.cn/attachments/" + tempPhone.PhonePictureOther2;

            try
            {
                ChangeText(0);
                picView.ImageLocation = imageFix[0];
            }
            catch (Exception)
            {
                picView.ImageLocation = "";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            imageIndex++;
            if (imageIndex > 3)
            {
                imageIndex--;
            }
            ChangeText(imageIndex);
            picView.ImageLocation = imageFix[imageIndex];
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            imageIndex--;
            if (imageIndex < 0)
            {
                imageIndex++;
            }
            ChangeText(imageIndex);
            picView.ImageLocation = imageFix[imageIndex];
        }

        private void ChangeText(int iindex)
        {
            switch (iindex)
            {
                case 0:
                    txtInfo.Text = Resources.frmViewPicture_ChangeText_正面图;
                    break;
                case 1:
                    txtInfo.Text = Resources.frmViewPicture_ChangeText_背面图;
                    break;
                case 2:
                    txtInfo.Text = Resources.frmViewPicture_ChangeText_其他1;
                    break;
                case 3:
                    txtInfo.Text = Resources.frmViewPicture_ChangeText_其他2;
                    break;
            }
        }
    }
}