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
//        Project Name:                   SystemControl
//        Module  Name:                   clsEnviron.cs
//        Part Of:                        LongXiangTools
//        Last Change Date:               4:13 27/12/2011

#endregion

namespace SystemControl.KSystem
{
    #region

    using System;
    using System.IO;
    using System.Management;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;

    #endregion

    public class clsEnviron
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int32 mac, ref Int32 length);

        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);


        public string CPUID()
        {
            return Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
        }

        public string CPULevel()
        {
            return Environment.GetEnvironmentVariable("PROCESSOR_LEVEL");
        }

        public string CPUVersion()
        {
            return Environment.GetEnvironmentVariable("PROCESSOR_REVISION");
        }

        public string WinDIR()
        {
            Environment.CurrentDirectory = Environment.GetEnvironmentVariable("windir");
            var info = new DirectoryInfo(".");
            lock (info)
            {
                return info.FullName;
            }
        }

        public string MachineName()
        {
            return Environment.MachineName;
        }

        public string CurrectTime()
        {
            //SNTPTimeClient client = new SNTPTimeClient("210.72.145.44", "123");
            //client.Connect();
            //return client.ToString();
            return DateTime.Now.Year + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
        }

        public string OsVersion()
        {
            return Environment.OSVersion.ToString();
        }

        public string UserDomainName()
        {
            return Environment.UserDomainName;
        }

        public string UserName()
        {
            return Environment.UserName;
        }

        public string SystemDirectory()
        {
            return Environment.SystemDirectory;
        }

        public string MacAddress()
        {
            string strip = "";

            //name      

            string hostInfo = Dns.GetHostName();

            //IP           

            IPAddress[] addressList = Dns.GetHostByName(hostInfo).AddressList;

            strip = addressList[0].ToString();
            //mac 

            string strRet = "Unknown";

            string strIPPattern = @"^\d+\.\d+\.\d+\.\d+$";

            var objRex = new Regex(strIPPattern);

            if (objRex.IsMatch(strip))
            {
                Int32 intDest = inet_addr(strip);

                var arrMAC = new Int32[2];

                Int32 intLen = 6;

                int intResult = SendARP(intDest, 0, ref arrMAC[0], ref intLen);

                if (intResult == 0)
                {
                    var arrbyte = new Byte[8];

                    arrbyte[5] = (Byte) (arrMAC[1] >> 8);

                    arrbyte[4] = (Byte) arrMAC[1];

                    arrbyte[3] = (Byte) (arrMAC[0] >> 24);

                    arrbyte[2] = (Byte) (arrMAC[0] >> 16);

                    arrbyte[1] = (Byte) (arrMAC[0] >> 8);

                    arrbyte[0] = (Byte) arrMAC[0];

                    var strbMAC = new StringBuilder();

                    for (int intIndex = 0; intIndex < 6; intIndex++)
                    {
                        if (intIndex > 0) strbMAC.Append("-");

                        strbMAC.Append(arrbyte[intIndex].ToString("X2"));
                    }

                    strRet = strbMAC.ToString();
                }
            }
            return strRet;
        }


        public string HardDiskID()
        {
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }
    }
}