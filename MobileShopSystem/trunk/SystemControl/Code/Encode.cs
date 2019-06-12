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
namespace SystemControl.Code
{
    #region

    using System;
    using System.Text;

    #endregion

    public class Encode
    {
        public static string GetUtf8(string gbk)
        {
            return System.Text.Encoding.GetEncoding("UTF-8").GetString(System.Text.Encoding.GetEncoding("GBK").GetBytes(gbk));
        }
        public static  string GetGBK(string utf8)
        {
            return System.Text.Encoding.GetEncoding("GBK").GetString(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(utf8));
        }
    }
}