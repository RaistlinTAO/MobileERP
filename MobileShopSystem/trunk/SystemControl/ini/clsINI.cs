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
//        Module  Name:                   clsINI.cs
//        Part Of:                        LongXiangTools
//        Last Change Date:               4:13 27/12/2011

#endregion

#region

#endregion

namespace SystemControl.ini
{
    #region

    using System.Runtime.InteropServices;
    using System.Text;

    #endregion

    #region

    #endregion

    public class clsINI
    {
        private readonly string path;

        /// <summary>
        ///   INIFile Constructor.
        /// </summary>
        /// <PARAM name = "INIPath"></PARAM>
        public clsINI(string INIPath)
        {
            path = INIPath;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
                                                             string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                                                          string key, string def, StringBuilder retVal,
                                                          int size, string filePath);

        /// <summary>
        ///   Write Data to the INI File
        /// </summary>
        /// <PARAM name = "Section"></PARAM>
        /// Section name
        /// <PARAM name = "Key"></PARAM>
        /// Key Name
        /// <PARAM name = "Value"></PARAM>
        /// Value Name
        public void IniWriteValue(string sSection, string sKey, string Value)
        {
            WritePrivateProfileString(sSection, sKey, Value, path);
        }

        /// <summary>
        ///   Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name = "Section"></PARAM>
        /// <PARAM name = "Key"></PARAM>
        /// <PARAM name = "Path"></PARAM>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            var temp = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", temp,
                                    255, path);
            return temp.ToString();
        }
    }
}