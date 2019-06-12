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
//        Created by Raistlin.K @ D.E.M.O.N at  0:23  12/12/2011 .
//        E-Mail:                         DemonVK@Gmail.com
// 
//        Project Name:                   SystemManager
//        Module  Name:                   ClsConfig.cs
//        Part Of:                        MobileERP
//        Last Change Date:               19:17 30/12/2011

#endregion

namespace SystemManager
{
    #region

    using System.IO;
    using System.IO.IsolatedStorage;

    #endregion

    public class ClsConfig
    {
        internal const string FileName = "AppSetting.cfg";
        internal readonly IsolatedStorageFile AppStorage = IsolatedStorageFile.GetUserStoreForApplication();

        public void WriteConfig(string iIp, string iName)
        {
            AppStorage.DeleteFile(FileName);
            using (
                IsolatedStorageFileStream file = AppStorage.OpenFile(FileName, FileMode.OpenOrCreate,
                                                                     FileAccess.Write))
            {
                using (var writer = new StreamWriter(file))
                {
                    writer.WriteLine(iIp + "|" + iName);
                    writer.Close();
                    writer.Dispose();
                    file.Close();
                    file.Dispose();
                }
            }
        }

        public void GetConfig(ref string iIP, ref string iName)
        {
            string iSetting;
            if (AppStorage.FileExists(FileName))
            {
                //存在设置则读取
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (var reader = new StreamReader(store.OpenFile(FileName, FileMode.Open, FileAccess.Read)))
                    {
                        iSetting = reader.ReadToEnd();
                        reader.Close();
                        reader.Dispose();
                        store.Dispose();
                    }
                }
            }
            else
            {
                //不存在 新建
                using (
                    IsolatedStorageFileStream file = AppStorage.OpenFile(FileName, FileMode.OpenOrCreate,
                                                                         FileAccess.Write))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        iSetting = "192.168.7.50" + "|" + "D.E.M.O.N ERP Client";
                        writer.Write(iSetting);
                        writer.Close();
                        writer.Dispose();
                        file.Close();
                        file.Dispose();
                    }
                }
            }
            string[] tempArr = iSetting.Split('|');
            iIP = tempArr[0];
            iName = tempArr[1];
        }
    }
}