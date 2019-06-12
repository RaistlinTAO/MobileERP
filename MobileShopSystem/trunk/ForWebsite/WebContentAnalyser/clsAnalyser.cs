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

namespace WebContentAnalyser
{
    #region

    using System;
    using System.Collections.Specialized;
    using System.Net;
    using System.Text.RegularExpressions;

    #endregion

    public class clsAnalyser
    {
        /*
83	标准配置	手机	手工录入		15	  
81	待机时间	手机	手工录入		14	  
80	通话时间	手机	手工录入		13	  
79	内存容量	手机	手工录入		12	  
78	处理器	手机	手工录入		11	  
77	操作系统	手机	手工录入		10	  
74	屏幕参数	手机	手工录入		7	  
82	可选颜色	手机	手工录入		6	  
73	外观样式	手机	手工录入		5	  
72	尺寸/体积	手机	手工录入		4	  
86	重 量	手机	手工录入		3	  
71	适用频率	手机	手工录入		2	  
70	网络制式	手机	手工录入		1	  
67	上市时间
         */

        public WebPhoneInfo CheckInfo(string YRURL, string PCURL, int flag)
        {
            var tempinfo = new WebPhoneInfo();
            try
            {
                if (YRURL.IndexOf("younet.com") > -1)
                {
                    tempinfo.Error = false;
                    tempinfo.YRInfo = ParseYRURL(YRURL);
                    switch (flag)
                    {
                        case 0:
                            tempinfo.Detail = ParsePCURL(PCURL);
                            break;
                        case 1:
                            tempinfo.Detail = ParsePOPURL(PCURL);
                            break;
                        case 2:
                            tempinfo.Detail = ParseZOLURL(PCURL);
                            break;
                        case 3:
                            tempinfo.Detail = ParsePC168URL(PCURL);
                            break;
                    }
                }
                else
                {
                    tempinfo.Error = true;
                }
            }
            catch (Exception)
            {
                tempinfo.Error = true;
            }


            return tempinfo;
        }

        #region 采集友人数据

        private static WebPhoneYRInfo ParseYRURL(string YRURL)
        {
            var tempInfo = new WebPhoneYRInfo();
            var client = new WebClient();
            string tempStr = client.DownloadString(YRURL);

            tempStr =
                Regex.Match(tempStr, @"<div class=""show-more"">[\s\S]*?<div class=""parameters-box"">",
                            RegexOptions.Singleline).Value;
            //tempStr = Regex.Replace(tempStr, "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline);
            var regexObj = new Regex("<dt>.+?</dt>.*?<dd.*?>.*?</dd>", RegexOptions.Singleline);
            Match matchResult = regexObj.Match(tempStr);
            while (matchResult.Success)
            {
                //<dt>上市时间：</dt><dd>2010年10月</dd>
                string[] tempArray = matchResult.Value.Split(matchResult.Value.IndexOf("：") > -1 ? '：' : ':');
                string tempFlag = Regex.Replace(tempArray[0], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline);
                switch (tempFlag)
                {
                    case "上市时间":
                        tempInfo.MarketTime =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "网络制式":
                        tempInfo.NetworkType =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "适用频率":
                        tempInfo.HzType =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "重　量　":
                        tempInfo.Weight =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "尺寸/体积":
                        tempInfo.Size =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "外观样式":
                        tempInfo.Look =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "可选颜色":
                        tempInfo.Color =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "屏幕参数":
                        tempInfo.Screen =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "操作系统":
                        tempInfo.OS =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "处理器":
                        tempInfo.CPU =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "内存容量":
                        tempInfo.Memory =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "通话时间":
                        tempInfo.PhoneTime =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "待机时间":
                        tempInfo.HoldTime =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                    case "标准配置":
                        tempInfo.CommonEquip =
                            Regex.Replace(tempArray[1], "</?[a-z][a-z0-9]*[^<>]*>", "", RegexOptions.Singleline).Trim();
                        break;
                }
                matchResult = matchResult.NextMatch();
            }

            return tempInfo;
        }

        #endregion

        #region 采集PCONLINE数据

        private static string ParsePCURL(string PCURL)
        {
            string DetailURL = "";
            var client = new WebClient();
            //WebClient client2 = new WebClient();
            string tempStr = client.DownloadString(PCURL);

            var resultList = new StringCollection();

            var regexObj = new Regex("<li>.+</li>");
            Match matchResult = regexObj.Match(tempStr);
            while (matchResult.Success)
            {
                resultList.Add(matchResult.Value);
                matchResult = matchResult.NextMatch();
            }
            foreach (string strMarth in resultList)
            {
                if (strMarth.IndexOf("detail.html") <= -1) continue;
                //详细的参数
                //<li ><a href="http://product.pconline.com.cn/mobile/nokia/352446_detail.html" title="诺基亚N8参数" target="_self"><i>参数</i></a></li> 
                string[] tempGroup = strMarth.Split('"');
                DetailURL = tempGroup[1];
                break;
            }

            if (DetailURL != "")
            {
                tempStr = Regex.Match(DetailURL, @"\d+").Value;

                tempStr = "http://pdlib.pconline.com.cn/product/service2011/product_parameter_preview.jsp?productId=" + tempStr;

                tempStr = client.DownloadString(tempStr);

                tempStr = Regex.Match(tempStr, "<table id=\"Jtable\".*</table>", RegexOptions.Singleline).Value;

            }
            client.Dispose();
            return tempStr;
        }

        #endregion

        #region 采集PCPOP数据

        private string ParsePOPURL(string POPURL)
        {
            string DetailURL = "";
            var client = new WebClient();
            //WebClient client2 = new WebClient();
            string tempStr = client.DownloadString(POPURL);

            tempStr =
                Regex.Match(tempStr, @"<div class=zs>.+?</div>",
                            RegexOptions.Singleline).Value;

            var resultList = new StringCollection();

            var regexObj = new Regex(@"\b(https?|ftp|file)://[-A-Z0-9+&@#/%?=~_|!:,.;]*[A-Z0-9+&@#/%=~_|]",
                                     RegexOptions.IgnoreCase);
            Match matchResult = regexObj.Match(tempStr);
            while (matchResult.Success)
            {
                resultList.Add(matchResult.Value);
                matchResult = matchResult.NextMatch();
            }
            foreach (string strMarth in resultList)
            {
                if (strMarth.IndexOf("Detail.html") <= -1) continue;
                //详细的参数
                //<li ><a href="http://product.pconline.com.cn/mobile/nokia/352446_detail.html" title="诺基亚N8参数" target="_self"><i>参数</i></a></li> 
                DetailURL = strMarth;
                break;
            }

            if (DetailURL != "")
            {
                tempStr = client.DownloadString(DetailURL);
                /*
                 jQuery("#copyBut").click(function(){
                 jQuery("#copyIframe").attr("src","http://product.pconline.com.cn/pdlib/service2009/product_simple_parameter.jsp?pId=352446");
                 });
                 */
                //http://product\.pconline\.com\.cn/pdlib/service2009/product_simple_parameter\.jsp\?pId=.+?"
                tempStr =
                    Regex.Match(tempStr, "<div class='cs' id=\"Para_tab\">.*?</TABLE></div></div>",
                                RegexOptions.Singleline).Value;

                tempStr = Regex.Replace(tempStr, "\b(https?|ftp|file)://[-A-Z0-9+&@#/%?=~_|$!:,.;]*[A-Z0-9+&@#/%=~_|$]",
                                        "", RegexOptions.IgnoreCase);

                tempStr = Regex.Replace(tempStr, "查看.*?报价", "");
            }
            client.Dispose();
            return tempStr;
        }

        #endregion

        #region 采集ZOL数据

        private string ParseZOLURL(string ZOLURL)
        {
            //var DetailURL = "";
            var client = new WebClient();
            //http://detail.zol.com.cn/cell_phone/index207959.shtml
            //http://detail.zol.com.cn/param_copy_207959_blue_1_0_100.html

            ZOLURL = ZOLURL.Replace("http://detail.zol.com.cn/cell_phone/index", "");
            ZOLURL = ZOLURL.Replace(".shtml", "");
            ZOLURL = "http://detail.zol.com.cn/param_copy_" + ZOLURL + "_blue_1_0_100.html";
            //WebClient client2 = new WebClient();
            string tempStr = client.DownloadString(ZOLURL);

            var regexObj = new Regex("<table style=\"border:2px solid #aac4e5;font-size:12px;color:#333;\".*",
                                     RegexOptions.Singleline);
            tempStr = regexObj.Match(tempStr).Groups[0].Value;

            //Console.Write(tempStr);

            string[] tempArray = Regex.Split(tempStr, @"</div>", RegexOptions.IgnoreCase);

            tempStr = Regex.Replace(tempArray[0],
                                    "<td height=\"25\" colspan=\"2\" bgcolor=\"#ffffff\" align=\"right\" >.*?</td>", "",
                                    RegexOptions.Singleline);
            tempStr = Regex.Replace(tempStr, "<tr>.*<td colspan=\"2\"  bgcolor=\"#ffffff\">.*?</td></tr>", "",
                                    RegexOptions.Singleline);
            client.Dispose();

            return tempStr;
        }

        #endregion

        #region 采集PC168数据

        private string ParsePC168URL(string PC168URL)
        {
            string DetailURL = "";
            var client = new WebClient();
            //WebClient client2 = new WebClient();
            string tempStr = client.DownloadString(PC168URL);

            tempStr =
                Regex.Match(tempStr, @"<div class='zs'>.+?</div>",
                            RegexOptions.IgnoreCase).Value;

            var resultList = new StringCollection();

            var regexObj = new Regex(@"\b(https?|ftp|file)://[-A-Z0-9+&@#/%?=~_|!:,.;]*[A-Z0-9+&@#/%=~_|]",
                                     RegexOptions.IgnoreCase);
            Match matchResult = regexObj.Match(tempStr);
            while (matchResult.Success)
            {
                resultList.Add(matchResult.Value);
                matchResult = matchResult.NextMatch();
            }
            foreach (string strMarth in resultList)
            {
                if (strMarth.IndexOf("detail.shtml") <= -1) continue;
                //详细的参数
                //<li ><a href="http://product.pconline.com.cn/mobile/nokia/352446_detail.html" title="诺基亚N8参数" target="_self"><i>参数</i></a></li> 
                DetailURL = strMarth;
                break;
            }

            if (DetailURL != "")
            {
                tempStr = client.DownloadString(DetailURL);
                /*
                 jQuery("#copyBut").click(function(){
                 jQuery("#copyIframe").attr("src","http://product.pconline.com.cn/pdlib/service2009/product_simple_parameter.jsp?pId=352446");
                 });
                 */
                //http://product\.pconline\.com\.cn/pdlib/service2009/product_simple_parameter\.jsp\?pId=.+?"
                tempStr = Regex.Match(tempStr, "<table class=\"table2\">.*?</table>", RegexOptions.Singleline).Value;

                tempStr = Regex.Replace(tempStr, "\b(https?|ftp|file)://[-A-Z0-9+&@#/%?=~_|$!:,.;]*[A-Z0-9+&@#/%=~_|$]",
                                        "", RegexOptions.IgnoreCase);

                tempStr = Regex.Replace(tempStr, "查看.*?报价", "");
            }
            client.Dispose();
            return tempStr;
        }

        #endregion

        #region Nested type: WebPhoneInfo

        public struct WebPhoneInfo
        {
            public string Detail;
            public bool Error;
            public WebPhoneYRInfo YRInfo;
        }

        #endregion

        #region Nested type: WebPhoneYRInfo

        public struct WebPhoneYRInfo
        {
            public string CPU;
            public string Color;
            public string CommonEquip;
            public string HoldTime;
            public string HzType;

            public string Look;
            public string MarketTime;

            public string Memory;
            public string NetworkType;
            public string OS;
            public string PhoneTime;
            public string Screen;
            public string Size;
            public string Weight;
        }

        #endregion
    }
}