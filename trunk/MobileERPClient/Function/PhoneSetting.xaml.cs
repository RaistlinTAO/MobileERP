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
//        Created by Raistlin.K @ D.E.M.O.N at  0:07  29/12/2011 .
//        E-Mail:                         DemonVK@Gmail.com
// 
//        Project Name:                   MobileERPClient
//        Module  Name:                   PhoneSetting.xaml.cs
//        Part Of:                        MobileERP
//        Last Change Date:               19:17 30/12/2011

#endregion

namespace MobileERPClient.Function
{
    #region

    using System.Windows;
    using SystemManager;
    using Microsoft.Phone.Controls;

    #endregion

    public partial class PhoneSetting : PhoneApplicationPage
    {
        private readonly ClsConfig iConfig = new ClsConfig();

        public PhoneSetting()
        {
            InitializeComponent();
            //预先判断
            string iIp = "";
            string iName = "";

            iConfig.GetConfig(ref iIp, ref iName);
            txtIP.Text = iIp;
            txtName.Text = iName;
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            iConfig.WriteConfig(txtIP.Text, txtName.Text);
            NavigationService.GoBack();
        }
    }
}