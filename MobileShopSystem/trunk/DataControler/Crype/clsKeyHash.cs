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
//        Project Name:                   DataControler
//        Module  Name:                   clsKeyHash.cs
//        Part Of:                        LongXiangTools
//        Last Change Date:               4:10 27/12/2011

#endregion

namespace DataControler.Crype
{
    #region

    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using SystemControl.KSystem;

    #endregion

    public class clsKeyHash
    {
        private readonly SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
        private string Key = ")(*&^%$#@RTYUIOLKGfjkkjdfhjk~!@l876!@#78u38yt587h3ovuhw2boiy231k'][wert[p453][}{Petwrgfd";
        private string iEKey = "g)fd~j&td%gl$u#!i~iuf*v(bj";
        private string iQKey = "9uhjk0987654eyuiol,jol,pljghjkl.p';p09o[;[p09io[p';lko;/l][=-p[";

        #region 内部校验算法

        private static readonly MD5 md5 = MD5.Create();
        private readonly EnDeCrype iCrype = new EnDeCrype();
        private readonly clsEnviron iSystem = new clsEnviron();
        //private string iCDKEY; //序列号
        //private string iHashCode; //激活
        //private string iLocaleCode; //自我读取
        private string GetHash(string inPutStr)
        {
            string tempStr = iCrype.CryptString(inPutStr);
            tempStr = tempStr.Replace(iCrype.CryptStringWithKey(EncryptRijndael(EKey()),
                                                                "7", "8"), "");
            //删除文件头
            return tempStr.Replace(iCrype.CryptString(EKey()), "！");
        }

        private string MD5Hash(string sourceString)
        {
            byte[] source = md5.ComputeHash(Encoding.UTF8.GetBytes(sourceString));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                sBuilder.Append(source[i].ToString("X"));
            }
            return sBuilder.ToString();
        }

        #region Rijndael算法

        /// <summary>
        ///   获得密钥
        /// </summary>
        /// <returns>密钥</returns>
        private byte[] GetLegalKey()
        {
            string sTemp = Key;
            mobjCryptoService.GenerateKey();
            byte[] bytTemp = mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');
            return Encoding.ASCII.GetBytes(sTemp);
        }

        /// <summary>
        ///   获得初始向量IV
        /// </summary>
        /// <returns>初试向量IV</returns>
        private byte[] GetLegalIV()
        {
            string sTemp = "safljkvi235$#%^YHTJMSgspo9065i7ko=-6]]'hRETY$%sgfgh#$%Ebds1!~@#$%^9*&^gdfh";
            mobjCryptoService.GenerateIV();
            byte[] bytTemp = mobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            return Encoding.ASCII.GetBytes(sTemp);
        }

        /// <summary>
        ///   加密方法
        /// </summary>
        /// <param name = "Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        public string EncryptRijndael(string Source)
        {
            byte[] bytIn = Encoding.UTF8.GetBytes(Source);
            var ms = new MemoryStream();
            mobjCryptoService.Key = GetLegalKey();
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            var cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            byte[] bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut);
        }

        /// <summary>
        ///   解密方法
        /// </summary>
        /// <param name = "Source">待解密的串</param>
        /// <returns>经过解密的串</returns>
        public string DecryptRijndael(string Source)
        {
            byte[] bytIn = Convert.FromBase64String(Source);
            var ms = new MemoryStream(bytIn, 0, bytIn.Length);
            mobjCryptoService.Key = GetLegalKey();
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
            var cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        #endregion

        #endregion

        #region 对外接口

        public string QKey()
        {
            return iQKey;
        }

        public string EKey()
        {
            return iEKey;
        }

        public struct ActiveInfo
        {
            public string ActTime;
            public int aDuration;
            public bool isSuccess;
        }

        #region 本地校验代码

        public string GetLocaleCode()
        {
            //此函数得到根据硬件信息获取的一串密钥
            //获取各种信息进行加密
            string itemp = EncryptRijndael(QKey());
            itemp = itemp + iCrype.CryptString(EncryptRijndael(iSystem.MacAddress()));
            itemp = itemp + iCrype.CryptString(EKey());
            itemp = itemp + iCrype.CryptString(EncryptRijndael(iSystem.CPUID()));
            itemp = itemp + iCrype.CryptString(EKey());
            itemp = itemp + iCrype.CryptString(EncryptRijndael(iSystem.CPULevel()));
            itemp = itemp + iCrype.CryptString(EKey());
            itemp = itemp + iCrype.CryptString(EncryptRijndael(iSystem.CPUVersion()));
            itemp = itemp + iCrype.CryptString(EKey());
            itemp = itemp + iCrype.CryptString(EncryptRijndael(iSystem.HardDiskID()));
            itemp = itemp + iCrype.CryptString(EKey());
            itemp = itemp + iCrype.CryptString(EncryptRijndael(iSystem.WinDIR()));
            itemp = itemp + iCrype.CryptString(EKey());
            itemp = itemp + iCrype.CryptString(EncryptRijndael(iSystem.MachineName()));
            itemp = itemp + iCrype.CryptString(EKey());
            itemp = itemp + iCrype.CryptString(EncryptRijndael(iSystem.CurrectTime()));
            return itemp;
        }

        #endregion

        #region 检测CDKEY

        public bool CheckCDEKY(string CDKEY, string TimeStr)
        {
            string tempStr = "";
            bool tempBool = false;
            for (int i = 0; i <= 999; i++)
            {
                tempStr = MD5Hash(i.ToString("000") + TimeStr);
                tempStr = tempStr.Substring(0, 25);
                tempStr = tempStr.Substring(0, 5) + "-" + tempStr.Substring(5, 5) + "-" + tempStr.Substring(10, 5) + "-" +
                          tempStr.Substring(15, 5) + "-" + tempStr.Substring(20, 5);
                if (tempStr == CDKEY)
                {
                    tempBool = true;
                    break;
                }
            }
            return tempBool;
        }

        #endregion

        #region 生成CDKEY

        public string MakeCDKEY(string TimeStr)
        {
            string tempStr = MD5Hash(DateTime.Now.Millisecond.ToString("000") + TimeStr);
            ///CDKEY在000~999 + 7 通过MD5hash完成 此处用碰撞可解
            tempStr = tempStr.Substring(0, 25);
            tempStr = tempStr.Substring(0, 5) + "-" + tempStr.Substring(5, 5) + "-" + tempStr.Substring(10, 5) + "-" +
                      tempStr.Substring(15, 5) + "-" + tempStr.Substring(20, 5);
            return tempStr;
        }

        #endregion

        #region 软件激活

        /// <summary>
        ///   校验是否激活
        /// </summary>
        /// <param name = "str1">CDKEY</param>
        /// <param name = "str2">HashCode</param>
        /// <returns></returns>
        public ActiveInfo CheckActive(string str1, string str2)
        {
            //检验成功为false
            //失败为true = =恶趣味
            //此处设计需要进行加强 以免爆破

            //拆包str2
            var iInfo = new ActiveInfo();

            string[] tempArr = Regex.Split(GetHash(str2), "！");
            iInfo.isSuccess = false;
            //iSystem.CPUID() 1
            if (DecryptRijndael(iCrype.CryptString(tempArr[1])) == iSystem.CPUID())
            {
                if (DecryptRijndael(iCrype.CryptString(tempArr[2])) == iSystem.HardDiskID())
                {
                    if (DecryptRijndael(iCrype.CryptString(tempArr[3])) == iSystem.WinDIR())
                    {
                        if (DecryptRijndael(iCrype.CryptString(tempArr[4])) == iSystem.MachineName())
                        {
                            if (DecryptRijndael(iCrype.CryptString(tempArr[5])) == str1)
                            {
                                //这里测试时间!注意 长度和激活开始时间

                                //(DecryptRijndael(iCrype.CryptString(tempArr[6])) //ReqTime
                                //(DecryptRijndael(iCrype.CryptString(tempArr[7])) //ActTime

                                //全对 那么表示校验完全正确
                                iInfo.ActTime = DecryptRijndael(iCrype.CryptString(tempArr[7]));
                                iInfo.isSuccess = true;
                                iInfo.aDuration = int.Parse(tempArr[0]);
                            }
                        }
                    }
                }
            }
            return iInfo;
        }

        #endregion

        #endregion
    }
}