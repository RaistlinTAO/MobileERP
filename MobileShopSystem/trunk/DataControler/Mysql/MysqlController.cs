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
//        Module  Name:                   MysqlController.cs
//        Part Of:                        LongXiangTools
//        Last Change Date:               4:11 27/12/2011

#endregion

#region

#endregion

namespace DataControler.Mysql
{
    #region

    using System;
    using System.Data;
    using MySql.Data.MySqlClient;

    #endregion

    public class MysqlController
    {
        //"上市时间" + iPhoneInfo.YRInfo.MarketTime + "\r\n" + "网络制式" + iPhoneInfo.YRInfo.NetworkType + "\r\n" + "适用频率" + iPhoneInfo.YRInfo.HzType + "\r\n" + "重　量" + iPhoneInfo.YRInfo.Weight + "\r\n" +
        //                            "尺寸/体积" + iPhoneInfo.YRInfo.Size + "\r\n" + "外观样式" + iPhoneInfo.YRInfo.Look + "\r\n" + "可选颜色" + iPhoneInfo.YRInfo.Color + "\r\n" + "屏幕参数" + iPhoneInfo.YRInfo.Screen + "\r\n" +
        //                             "操作系统" + iPhoneInfo.YRInfo.OS + "\r\n" + "处理器" + iPhoneInfo.YRInfo.CPU + "\r\n" + "内存容量" + iPhoneInfo.YRInfo.Memory + "\r\n" + "通话时间" + iPhoneInfo.YRInfo.PhoneTime + "\r\n" +
        //                            "待机时间" + iPhoneInfo.YRInfo.HoldTime + "\r\n" + "标准配置" + iPhoneInfo.YRInfo.CommonEquip + "\r\n"
        //                            + "详细信息代码" + "\r\n" + iPhoneInfo.Detail

        #region Nested type: LXSellPhone

        public struct LXSellPhone
        {
            public double PhoneBattery;
            public int PhoneBrandid;
            public double PhoneCarCharger;
            public double PhoneCarCradle;
            public double PhoneCommision;
            public string PhoneDate;
            public double PhoneHeadPhone;
            public string PhoneIMEI;
            public string PhoneName;
            public double PhoneOther;
            public int PhonePayment;
            public double PhonePrice;
            public double PhoneProfit;
            public double PhoneRealprice;
            public double PhoneSDCARD;
            public double PhoneScreenGuard;
            public string PhoneSeller;
            public double PhoneShell;
            public string PhoneSupplier;
            public string PhoneUserAddress;
            public string PhoneUserBXKid;
            public string PhoneUserName;
            public string PhoneUserQQ;
            public string PhoneUserTelePhone;
            public string PhoneUserTip;
            public int PhoneUserType;
            public string PhoneUsercellPhone;
            public string PhoneUsercellPhoneback;
            public string PhoneUseremail;
            public bool PhoneWarranty;
            public string PhoneWarrantyDate;
            public int PhoneWarrantyDuration;
            public double PhoneWarrantyPrice;
            public int PhoneWarrantyType;
            public string Phoneid;
            public bool PhoneisDelete;
            public bool PhoneisHKLegal;
            public bool PhoneisLegal;
            public bool PhoneisUnLegal;
        }

        #endregion

        #region Nested type: LXUser

        public struct LXUser
        {
            public string BXKid;
            public string Birthday;
            public LXPhones[] BuyPhones;
            public string ContectAddress;
            public string Email;
            public int GroupID;
            public string LXCredit;
            public string Phone;
            public string QQ;
            public string Telephone;
            public string UserCName;
            public int UserID;
            public string UserName;
            public string UserTip;
            public bool haveBXK;
            public bool iFlag;
            public int userType;
        }

        #endregion

        #region Nested type: PhoneColor

        public struct PhoneColor
        {
            public string Color;
            public string CommonEquip;
            public string Price;
        }

        #endregion

        #region Nested type: PhoneInfo

        public struct PhoneInfo
        {
            public string CPU;
            public PhoneColor[] Color;
            public string CommonEquip;
            public string Detail;
            public string Equipment;
            public string HoldTime;
            public string HzType;
            public string Keywords;
            public string LongXiangPC;

            public string Look;
            public string MarketTime;
            public string Memory;
            public string NetworkType;
            public string OS;
            public string[] PhoneGallery;
            public int PhoneManufacturer;
            public string PhoneName;
            public string PhonePic;
            public string PhoneShortName;
            public string PhoneTime;
            public string Screen;
            public string Size;

            public string TaoBaoURL;
            public string Weight;
        }

        #endregion

        #region Nested type: ReturnResult

        public struct ReturnResult
        {
            public string ErrDesc;
            public int PhoneID;
            public bool isSuccess;
        }

        #endregion

        #region Nested type: ReturnUsers

        public struct ReturnUsers
        {
            public string ErrString;
            public LXUser[] UserInfo;
            public int UserNum;
            public bool isError;
        }

        #endregion

        #region 静态函数

        private static string iMySQLIP;

        private static string iMySQLAccount;

        private static string iMySQLPassword;

        private static string iMySQLDatabase;

        public static string MySQLIP
        {
            set { iMySQLIP = value; }
        }

        public static string MySQLAccount
        {
            set { iMySQLAccount = value; }
        }

        public static string MySQLPassword
        {
            set { iMySQLPassword = value; }
        }

        public static string MySQLDatabase
        {
            set { iMySQLDatabase = value; }
        }

        #endregion

        #region 测试连接

        public bool TestConnect()
        {
            //iMySQLIP//iMySQLAccount//iMySQLPassword//iMySQLDatabase
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            bool TestResult;
            try
            {
                iMySQLconn.Open();
                TestResult = true;
                iMySQLconn.Close();
            }
            catch (Exception)
            {
                TestResult = false;
            }
            iMySQLconn.Dispose();
            return TestResult;
        }

        #endregion

        #region LongXiangBOX 操作

        #region 获取厂商信息

        public string[] Manufacturer()
        {
            var tempManufacturer = new string[200];
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            const string mySelectQuery = "SELECT brand_name FROM ecs_brand";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempManufacturer[i] = (iMySQLReader.GetString(0));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                tempManufacturer = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempManufacturer;
        }

        #endregion

        #region 增加一个手机

        public ReturnResult AddNewPhone(PhoneInfo iPhoneInfo, bool iOther)
        {
            var iResult = new ReturnResult();
            try
            {
                var iMySQLconn =
                    new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                        ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");


                //string iMySQLQuery = "insert  into ecs_goods(@goods_id,@cat_id,@goods_sn,@goods_name,@goods_name_style,@click_count,@brand_id,@provider_name,@goods_number,@goods_weight,@market_price,@shop_price,@promote_price,@promote_start_date,@promote_end_date,@warn_number,@keywords,@goods_brief,@goods_desc,@goods_thumb,@goods_img,@original_img,@is_real,@extension_code,@is_on_sale,@is_alone_sale,@is_shipping,@integral,@add_time,@sort_order,@is_delete,@is_best,@is_new,@is_hot,@is_promote,@bonus_type_id,@last_update,@goods_type,@seller_note,@give_integral,@rank_integral,@suppliers_id,@is_check,@goods_url,@goods_atrdesc)";
                //string iMySQLQuery ="insert  into `ecs_goods`(`goods_id`,`cat_id`,`goods_sn`,`goods_name`,`goods_name_style`,`click_count`,`brand_id`,`provider_name`,`goods_number`,`goods_weight`,`market_price`,`shop_price`,`promote_price`,`promote_start_date`,`promote_end_date`,`warn_number`,`keywords`,`goods_brief`,`goods_desc`,`goods_thumb`,`goods_img`,`original_img`,`is_real`,`extension_code`,`is_on_sale`,`is_alone_sale`,`is_shipping`,`integral`,`add_time`,`sort_order`,`is_delete`,`is_best`,`is_new`,`is_hot`,`is_promote`,`bonus_type_id`,`last_update`,`goods_type`,`seller_note`,`give_integral`,`rank_integral`,`suppliers_id`,`is_check`,`goods_url`,`goods_atrdesc`)";

                if (!iOther)
                {
                    const string iMySQLQueryCheck = "SELECT MAX(goods_id) FROM ecs_goods";
                    const string iMySQLQuery =
                        "insert into ecs_goods(goods_id,cat_id,goods_sn,goods_name,goods_name_style,click_count,brand_id,provider_name,goods_number,goods_weight,market_price,shop_price,promote_price,promote_start_date,promote_end_date,warn_number,keywords,goods_brief,goods_desc,goods_thumb,goods_img,original_img,is_real,extension_code,is_on_sale,is_alone_sale,is_shipping,integral,add_time,sort_order,is_delete,is_best,is_new,is_hot,is_promote,bonus_type_id,last_update,goods_type,seller_note,give_integral,rank_integral,suppliers_id,is_check,goods_url,goods_atrdesc,goods_equip,goods_short_name) values(@goods_id,@cat_id,@goods_sn,@goods_name,@goods_name_style,@click_count,@brand_id,@provider_name,@goods_number,@goods_weight,@market_price,@shop_price,@promote_price,@promote_start_date,@promote_end_date,@warn_number,@keywords,@goods_brief,@goods_desc,@goods_thumb,@goods_img,@original_img,@is_real,@extension_code,@is_on_sale,@is_alone_sale,@is_shipping,@integral,@add_time,@sort_order,@is_delete,@is_best,@is_new,@is_hot,@is_promote,@bonus_type_id,@last_update,@goods_type,@seller_note,@give_integral,@rank_integral,@suppliers_id,@is_check,@goods_url,@goods_atrdesc,@goods_equip,@goods_short_name)";
                    const string iMySQLGalleryMAXQuery =
                        "SELECT MAX(img_id) FROM ecs_goods_gallery";
                    const string iMySQLGalleryQuery =
                        "insert into ecs_goods_gallery(img_id,goods_id,img_url,img_desc,thumb_url,img_original) values(@img_id,@goods_idp,@img_url,@img_desc,@thumb_url,@img_original)";
                    var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                    iMySQLconn.Open();
                    double tempPrice = double.Parse(iPhoneInfo.Color[0].Price);
                    for (int i = 0; i < iPhoneInfo.Color.Length; i++)
                    {
                        if (string.IsNullOrEmpty(iPhoneInfo.Color[i].Color)) continue;
                        if (tempPrice > double.Parse(iPhoneInfo.Color[i].Price))
                        {
                            tempPrice = double.Parse(iPhoneInfo.Color[i].Price);
                        }
                    }
                    double tempMarketPrice = tempPrice*1.2;

                    #region 插入手机基本属性 ecs_goods表

                    MySqlDataReader iMySQLReader = iMySQLCommand.ExecuteReader();
                    string tempGood = "9999";
                    try
                    {
                        while (iMySQLReader.Read())
                        {
                            tempGood = (iMySQLReader.GetString(0));
                        }
                    }
                    catch (Exception)
                    {
                        tempGood = "0";
                    }

                    //这里已经能去到最后一个id了
                    iMySQLReader.Close();
                    //这里取pic id
                    iMySQLCommand.CommandText = iMySQLGalleryMAXQuery;

                    MySqlDataReader iMySQLGalleryReader = iMySQLCommand.ExecuteReader();
                    string tempPicID = "9999";
                    try
                    {
                        while (iMySQLGalleryReader.Read())
                        {
                            tempPicID = (iMySQLGalleryReader.GetString(0));
                        }
                    }
                    catch (Exception)
                    {
                        tempPicID = "0";
                    }


                    iMySQLGalleryReader.Close();

                    string tempPicName = iPhoneInfo.PhoneName;
                    //|:|=|%|&|$|#|@|+|-|*|/|\|<|>|;|,|^|" 
                    tempPicName = tempPicName.Replace(@"\", @"");
                    tempPicName = tempPicName.Replace(@"/", @"");
                    tempPicName = tempPicName.Replace(@"?", @"");
                    tempPicName = tempPicName.Replace(@"!", @"");
                    tempPicName = tempPicName.Replace(@".", @"");
                    tempPicName = tempPicName.Replace(@"!", @"");
                    tempPicName = tempPicName.Replace(@":", @"");
                    tempPicName = tempPicName.Replace(@"=", @"");
                    tempPicName = tempPicName.Replace(@"%", @"");
                    tempPicName = tempPicName.Replace(@"&", @"");
                    tempPicName = tempPicName.Replace(@"$", @"");
                    tempPicName = tempPicName.Replace(@"#", @"");
                    tempPicName = tempPicName.Replace(@"*", @"");
                    tempPicName = tempPicName.Replace(@"+", @"");
                    tempPicName = tempPicName.Replace(@"-", @"");
                    tempPicName = tempPicName.Replace(@"*", @"");
                    tempPicName = tempPicName.Replace(@"|", @"");
                    tempPicName = tempPicName.Replace(@"<", @"");
                    tempPicName = tempPicName.Replace(@">", @"");

                    iMySQLCommand.CommandText = iMySQLQuery;

                    iResult.PhoneID = int.Parse(tempGood) + 1;
                    //从这里开始加入元素
                    iMySQLCommand.Parameters.Add("@goods_id", MySqlDbType.UInt32).Value = int.Parse(tempGood) + 1;
                    iMySQLCommand.Parameters.Add("@cat_id", MySqlDbType.UInt16).Value = 1;
                    iMySQLCommand.Parameters.Add("@goods_sn", MySqlDbType.VarChar, 10).Value = "BOX0" +
                                                                                               (int.Parse(tempGood) + 1);
                    iMySQLCommand.Parameters.Add("@goods_name", MySqlDbType.VarChar, 200).Value = iPhoneInfo.PhoneName;
                    iMySQLCommand.Parameters.Add("@goods_name_style", MySqlDbType.VarChar, 5).Value = "+";

                    iMySQLCommand.Parameters.Add("@click_count", MySqlDbType.UInt24).Value = 150;
                    iMySQLCommand.Parameters.Add("@brand_id", MySqlDbType.UInt16).Value = iPhoneInfo.PhoneManufacturer +
                                                                                          1;
                    iMySQLCommand.Parameters.Add("@provider_name", MySqlDbType.VarChar, 1).Value = "";
                    iMySQLCommand.Parameters.Add("@goods_number", MySqlDbType.UInt16).Value = 1;
                    iMySQLCommand.Parameters.Add("@goods_weight", MySqlDbType.Decimal).Value = 0.000;

                    iMySQLCommand.Parameters.Add("@market_price", MySqlDbType.Decimal).Value = tempMarketPrice;
                    iMySQLCommand.Parameters.Add("@shop_price", MySqlDbType.Decimal).Value = tempPrice;
                    iMySQLCommand.Parameters.Add("@promote_price", MySqlDbType.Decimal).Value = 0.00;
                    iMySQLCommand.Parameters.Add("@promote_start_date", MySqlDbType.UInt24).Value = 0;
                    iMySQLCommand.Parameters.Add("@promote_end_date", MySqlDbType.UInt24).Value = 0;

                    iMySQLCommand.Parameters.Add("@warn_number", MySqlDbType.UInt16).Value = 1;
                    iMySQLCommand.Parameters.Add("@keywords", MySqlDbType.VarChar, 255).Value = iPhoneInfo.Keywords;
                    iMySQLCommand.Parameters.Add("@goods_brief", MySqlDbType.VarChar, 255).Value = "";
                    iMySQLCommand.Parameters.Add("@goods_desc", MySqlDbType.Text).Value = iPhoneInfo.LongXiangPC;
                    //这个就是龙翔评测

                    //图片
                    //images/201010/thumb_img/171_thumb_G_1287080853162.jpg
                    iMySQLCommand.Parameters.Add("@goods_thumb", MySqlDbType.VarChar, 255).Value = "images/BoxImage/" +
                                                                                                   tempPicName +
                                                                                                   "_Main.jpg";

                    iMySQLCommand.Parameters.Add("@goods_img", MySqlDbType.VarChar, 255).Value = "images/BoxImage/" +
                                                                                                 tempPicName +
                                                                                                 "_Main.jpg";
                    iMySQLCommand.Parameters.Add("@original_img", MySqlDbType.VarChar, 255).Value = "images/BoxImage/" +
                                                                                                    tempPicName +
                                                                                                    "_Main.jpg";

                    //图片
                    iMySQLCommand.Parameters.Add("@is_real", MySqlDbType.UInt16).Value = 1;
                    iMySQLCommand.Parameters.Add("@extension_code", MySqlDbType.VarChar, 30).Value = "";
                    iMySQLCommand.Parameters.Add("@is_on_sale", MySqlDbType.UInt16).Value = 1;

                    iMySQLCommand.Parameters.Add("@is_alone_sale", MySqlDbType.UInt16).Value = 1;
                    iMySQLCommand.Parameters.Add("@is_shipping", MySqlDbType.UInt16).Value = 0;
                    iMySQLCommand.Parameters.Add("@integral", MySqlDbType.UInt24).Value = 1; //?
                    iMySQLCommand.Parameters.Add("@add_time", MySqlDbType.UInt24).Value = 1288118918;
                    iMySQLCommand.Parameters.Add("@sort_order", MySqlDbType.UInt16).Value = 100;

                    iMySQLCommand.Parameters.Add("@is_delete", MySqlDbType.UInt16).Value = 0;
                    iMySQLCommand.Parameters.Add("@is_best", MySqlDbType.UInt16).Value = 0;
                    iMySQLCommand.Parameters.Add("@is_new", MySqlDbType.UInt16).Value = 0;
                    iMySQLCommand.Parameters.Add("@is_hot", MySqlDbType.UInt16).Value = 0;
                    iMySQLCommand.Parameters.Add("@is_promote", MySqlDbType.UInt16).Value = 0;

                    iMySQLCommand.Parameters.Add("@bonus_type_id", MySqlDbType.UInt16).Value = 0;
                    iMySQLCommand.Parameters.Add("@last_update", MySqlDbType.UInt24).Value = 1288118918;
                    iMySQLCommand.Parameters.Add("@goods_type", MySqlDbType.UInt16).Value = 1;
                    iMySQLCommand.Parameters.Add("@seller_note", MySqlDbType.VarChar, 255).Value = "";
                    iMySQLCommand.Parameters.Add("@give_integral", MySqlDbType.Int24).Value = -1;

                    iMySQLCommand.Parameters.Add("@rank_integral", MySqlDbType.Int24).Value = -1;
                    iMySQLCommand.Parameters.Add("@suppliers_id", MySqlDbType.UInt16).Value = 0;
                    iMySQLCommand.Parameters.Add("@is_check", MySqlDbType.UInt16).Value = 0;
                    iMySQLCommand.Parameters.Add("@goods_url", MySqlDbType.VarChar, 255).Value = iPhoneInfo.TaoBaoURL;
                    iMySQLCommand.Parameters.Add("@goods_atrdesc", MySqlDbType.Text).Value = iPhoneInfo.Detail;
                    //goods_equip
                    iMySQLCommand.Parameters.Add("@goods_equip", MySqlDbType.VarChar, 255).Value = iPhoneInfo.Equipment;
                    //goods_short_name
                    iMySQLCommand.Parameters.Add("@goods_short_name", MySqlDbType.VarChar, 120).Value =
                        iPhoneInfo.PhoneShortName;
                    iMySQLCommand.ExecuteNonQuery();

                    #endregion 添加基本信息完成

                    //这里开始添加属性
                    //insert  into `ecs_goods_attr`(`goods_attr_id`,`goods_id`,`attr_id`,`attr_value`,`attr_price`)
                    const string iMySQLAttrMaxQuery = "SELECT MAX(goods_attr_id) FROM ecs_goods_attr";
                    const string iMySQLAttrQuery =
                        "insert into ecs_goods_attr(goods_attr_id,goods_id,attr_id,attr_value,attr_price) values(@goods_attr_id,@goods_id2,@attr_id,@attr_value,@attr_price)";

                    iMySQLCommand.CommandText = iMySQLAttrMaxQuery;
                    MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                    string tempGoodAtrr = "9999";
                    try
                    {
                        while (iMySQLReaderAttr.Read())
                        {
                            tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                        }
                    }
                    catch (Exception)
                    {
                        tempGoodAtrr = "0";
                    }

                    iMySQLReaderAttr.Close();

                    iMySQLCommand.CommandText = iMySQLAttrQuery;
                    /*
                     * 通话时间 80
                    待机时间 81
                    可选颜色 82
                    内存容量 79
                    处理器 78
                     * 
                    操作系统77
                    屏幕参数74
                    尺寸/体积72
                    外观样式73
                    适用频率71
                     * 
                    上市时间67
                    网络制式70
                    标准配置83
                    重 量86
                    */


                    var dt = new DataTable("TableAttr");

                    #region 给DT赋值

                    dt.Columns.Add("id", Type.GetType("System.String"));
                    dt.Columns.Add("value", Type.GetType("System.String"));
                    dt.Columns.Add("price", Type.GetType("System.String"));
                    DataRow dr = dt.NewRow();
                    dr["id"] = "67";
                    dr["value"] = iPhoneInfo.MarketTime;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "70";
                    dr["value"] = iPhoneInfo.NetworkType;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "71";
                    dr["value"] = iPhoneInfo.HzType;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "72";
                    dr["value"] = iPhoneInfo.Size;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "73";
                    dr["value"] = iPhoneInfo.Look;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "74";
                    dr["value"] = iPhoneInfo.Screen;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "77";
                    dr["value"] = iPhoneInfo.OS;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "78";
                    dr["value"] = iPhoneInfo.CPU;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "79";
                    dr["value"] = iPhoneInfo.Memory;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "80";
                    dr["value"] = iPhoneInfo.PhoneTime;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "81";
                    dr["value"] = iPhoneInfo.HoldTime;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "83";
                    dr["value"] = iPhoneInfo.CommonEquip;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["id"] = "86";
                    dr["value"] = iPhoneInfo.Weight;
                    dr["price"] = "";
                    dt.Rows.Add(dr);
                    //dr = dt.NewRow();
                    for (int i = 0; i < iPhoneInfo.Color.Length; i++)
                    {
                        if (string.IsNullOrEmpty(iPhoneInfo.Color[i].Color)) continue;
                        dr = dt.NewRow();
                        dr["id"] = "82";
                        dr["value"] = iPhoneInfo.Color[i].Color;
                        dr["price"] = iPhoneInfo.Color[i].Price;
                        dt.Rows.Add(dr);
                    }

                    #endregion

                    //下面考虑如何上传表格

                    iMySQLCommand.Parameters.Add("@goods_attr_id", MySqlDbType.UInt24);
                    iMySQLCommand.Parameters.Add("@goods_id2", MySqlDbType.UInt32);
                    iMySQLCommand.Parameters.Add("@attr_id", MySqlDbType.UInt16);
                    iMySQLCommand.Parameters.Add("@attr_value", MySqlDbType.Text);
                    iMySQLCommand.Parameters.Add("@attr_price", MySqlDbType.VarChar, 255);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow drOperate = dt.Rows[i];
                        iMySQLCommand.Parameters["@goods_attr_id"].Value = int.Parse(tempGoodAtrr) + i + 1;
                        iMySQLCommand.Parameters["@goods_id2"].Value = int.Parse(tempGood) + 1;
                        iMySQLCommand.Parameters["@attr_id"].Value = drOperate["id"];
                        iMySQLCommand.Parameters["@attr_value"].Value = drOperate["value"];
                        iMySQLCommand.Parameters["@attr_price"].Value = drOperate["price"];
                        iMySQLCommand.ExecuteNonQuery();
                    }
                    if (iPhoneInfo.PhoneGallery != null)
                    {
                        if (iPhoneInfo.PhoneGallery.Length > 0)
                        {
                            iMySQLCommand.CommandText = iMySQLGalleryQuery;

                            iMySQLCommand.Parameters.Add("@img_id", MySqlDbType.UInt24);
                            iMySQLCommand.Parameters.Add("@goods_idp", MySqlDbType.UInt24);
                            iMySQLCommand.Parameters.Add("@img_url", MySqlDbType.VarChar, 255);
                            iMySQLCommand.Parameters.Add("@img_desc", MySqlDbType.VarChar, 255);
                            iMySQLCommand.Parameters.Add("@thumb_url", MySqlDbType.VarChar, 255);
                            iMySQLCommand.Parameters.Add("@img_original", MySqlDbType.VarChar, 255);

                            for (int i = 0; i < iPhoneInfo.PhoneGallery.Length; i++)
                            {
                                iMySQLCommand.Parameters["@img_id"].Value = int.Parse(tempPicID) + i + 1;
                                iMySQLCommand.Parameters["@goods_idp"].Value = int.Parse(tempGood) + 1;
                                iMySQLCommand.Parameters["@img_url"].Value = "images/BoxImage/" + tempPicName + "_" + i +
                                                                             ".jpg";
                                iMySQLCommand.Parameters["@img_desc"].Value = "";
                                iMySQLCommand.Parameters["@thumb_url"].Value = "images/BoxImage/" + tempPicName + "_" +
                                                                               i +
                                                                               ".jpg";
                                iMySQLCommand.Parameters["@img_original"].Value = "images/BoxImage/" + tempPicName + "_" +
                                                                                  i + ".jpg";
                                iMySQLCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
                else
                {
                    const string iMySQLQueryCheck = "SELECT MAX(goods_id) FROM ecs_goods";
                    const string iMySQLQuery =
                        "insert into ecs_goods(goods_id,cat_id,goods_sn,goods_name,goods_name_style,click_count,brand_id,goods_short_name) values(@goods_id,@cat_id,@goods_sn,@goods_name,@goods_name_style,@click_count,@brand_id,@goods_short_name)";
                    var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                    iMySQLconn.Open();
                    MySqlDataReader iMySQLReader = iMySQLCommand.ExecuteReader();
                    string tempGood = "9999";
                    try
                    {
                        while (iMySQLReader.Read())
                        {
                            tempGood = (iMySQLReader.GetString(0));
                        }
                    }
                    catch (Exception)
                    {
                        tempGood = "0";
                    }

                    //这里已经能去到最后一个id了
                    iMySQLReader.Close();

                    iMySQLCommand.CommandText = iMySQLQuery;

                    iMySQLCommand.Parameters.Add("@goods_id", MySqlDbType.UInt32).Value = int.Parse(tempGood) + 1;
                    iMySQLCommand.Parameters.Add("@cat_id", MySqlDbType.UInt16).Value = 1;
                    iMySQLCommand.Parameters.Add("@goods_sn", MySqlDbType.VarChar, 10).Value = "BOX0" +
                                                                                               (int.Parse(tempGood) + 1);
                    iMySQLCommand.Parameters.Add("@goods_name", MySqlDbType.VarChar, 100).Value = iPhoneInfo.PhoneName;
                    iMySQLCommand.Parameters.Add("@goods_name_style", MySqlDbType.VarChar, 5).Value = "+";

                    iMySQLCommand.Parameters.Add("@click_count", MySqlDbType.UInt24).Value = 150;
                    iMySQLCommand.Parameters.Add("@brand_id", MySqlDbType.UInt16).Value = iPhoneInfo.PhoneManufacturer +
                                                                                          1;
                    //goods_short_name
                    iMySQLCommand.Parameters.Add("@goods_short_name", MySqlDbType.VarChar, 120).Value =
                        iPhoneInfo.PhoneShortName;
                    iMySQLCommand.ExecuteNonQuery();
                }

                iResult.ErrDesc = "";
                iResult.isSuccess = true;
                //~Dispose

                iMySQLconn.Close();
            }
            catch (MySqlException e)
            {
                iResult.ErrDesc = e.Message;
                iResult.isSuccess = false;
            }
            return iResult;
        }

        #endregion

        #region 读取当前厂商下的所有手机

        public DataTable ReadPhones(int iManu)
        {
            var dt = new DataTable();

            dt.Columns.Add("PhoneId", Type.GetType("System.String"));
            dt.Columns.Add("PhoneName", Type.GetType("System.String"));

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT goods_id,goods_short_name,is_delete FROM ecs_goods WHERE brand_id=" +
                                   (iManu + 1);
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    if (iMySQLReader.GetString(2) != "0") continue;
                    DataRow dr = dt.NewRow();
                    dr["PhoneId"] = iMySQLReader.GetString(0);
                    dr["PhoneName"] = iMySQLReader.GetString(1);
                    dt.Rows.Add(dr);
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
                dt = null;
            }

            return dt;
        }

        public DataTable ReadCMSPhones(int iManu)
        {
            var dt = new DataTable();

            dt.Columns.Add("PhoneId", Type.GetType("System.String"));
            dt.Columns.Add("PhoneName", Type.GetType("System.String"));

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT goods_id,goods_name,is_delete FROM ecs_goods WHERE brand_id=" +
                                   (iManu + 1);
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    if (iMySQLReader.GetString(2) != "0") continue;
                    DataRow dr = dt.NewRow();
                    dr["PhoneId"] = iMySQLReader.GetString(0);
                    dr["PhoneName"] = iMySQLReader.GetString(1);
                    dt.Rows.Add(dr);
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
                dt = null;
            }

            return dt;
        }

        #endregion

        #region 读取一个存在手机的信息,反应到前台

        public SPhoneInfo ReadExistPhone(string PhoneID)
        {
            var tempInfo = new SPhoneInfo {isError = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery =
                "SELECT keywords,goods_url,goods_img,click_count,is_new,is_best,is_hot,goods_equip,goods_desc,goods_short_name FROM ecs_goods WHERE goods_id=" +
                PhoneID;
            string mySelectColorQuery =
                "SELECT attr_value,attr_price FROM ecs_goods_attr WHERE attr_id=82 AND goods_id=" + PhoneID;
            string mySelectGallery =
                "SELECT img_url FROM ecs_goods_gallery WHERE goods_id=" + PhoneID;
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;
            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    tempInfo.Keywords = iMySQLReader.GetString(0);
                    tempInfo.TBURL = iMySQLReader.GetString(1);
                    tempInfo.PhonePic = iMySQLReader.GetString(2);
                    tempInfo.PhoneClick = iMySQLReader.GetString(3);
                    tempInfo.isNEW = iMySQLReader.GetString(4) == "1";
                    tempInfo.isBest = iMySQLReader.GetString(5) == "1";
                    tempInfo.isHot = iMySQLReader.GetString(6) == "1";
                    tempInfo.Equipment = iMySQLReader.GetString(7);
                    try
                    {
                        tempInfo.Detail = iMySQLReader.GetValue(8).ToString();
                    }
                    catch (Exception)
                    {
                        tempInfo.Detail = "";
                    }
                    tempInfo.PhoneShortName = iMySQLReader.GetValue(9).ToString();
                }
                iMySQLReader.Close();

                iMySQLCommand.CommandText = mySelectColorQuery;
                MySqlDataReader iMySQLColorReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                var tempColorPrice = new PhoneColor[21];
                while (iMySQLColorReader.Read())
                {
                    tempColorPrice[i].Color = iMySQLColorReader.GetString(0);
                    tempColorPrice[i].Price = iMySQLColorReader.GetString(1);
                    i++;
                }
                iMySQLColorReader.Close();

                iMySQLCommand.CommandText = mySelectGallery;
                MySqlDataReader iMySQLGalleryReader = iMySQLCommand.ExecuteReader();

                i = 0;
                var tempGallery = new string[100];
                while (iMySQLGalleryReader.Read())
                {
                    tempGallery[i] = iMySQLGalleryReader.GetString(0);
                    i++;
                }
                iMySQLGalleryReader.Close();

                tempInfo.ColorPrice = tempColorPrice;
                tempInfo.PhoneGallery = tempGallery;

                iMySQLconn.Close();

                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (MySqlException e)
            {
                tempInfo.isError = true;
                Console.Write(e.Message);
                tempInfo.ErrString = e.Message;
            }


            return tempInfo;
        }

        #endregion

        #region 修改存在手机的信息入库

        public ReturnResult UpdataPhone(SPhoneInfo iTempInfo, string PhoneID, bool iOther)
        {
            var iReturn = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string myUpdateQuery;
            if (iTempInfo.Detail == "")
            {
                myUpdateQuery =
                    "UPDATE ecs_goods SET click_count = @click_count, is_new = @is_new, shop_price = @shop_price, market_price = @market_price, is_best = @is_best, is_hot = @is_hot, keywords = @keywords, goods_url = @goods_url, goods_equip = @goods_equip,goods_short_name = @goods_short_name WHERE goods_id=" +
                    PhoneID;
            }
            else
            {
                myUpdateQuery =
                    "UPDATE ecs_goods SET click_count = @click_count, is_new = @is_new, shop_price = @shop_price, market_price = @market_price, is_best = @is_best, is_hot = @is_hot,  keywords = @keywords, goods_url = @goods_url, goods_equip = @goods_equip, goods_desc = @goods_desc, goods_short_name = @goods_short_name  WHERE goods_id=" +
                    PhoneID;
            }
            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);
            try
            {
                iMySQLconn.Open();
                double tempPrice;
                double tempMarketPrice;
                if (!iOther)
                {
                    tempPrice = double.Parse(iTempInfo.ColorPrice[0].Price);
                    for (int i = 0; i < iTempInfo.ColorPrice.Length; i++)
                    {
                        if (string.IsNullOrEmpty(iTempInfo.ColorPrice[i].Color)) continue;
                        if (tempPrice > double.Parse(iTempInfo.ColorPrice[i].Price))
                        {
                            tempPrice = double.Parse(iTempInfo.ColorPrice[i].Price);
                        }
                    }
                    tempMarketPrice = tempPrice*1.2;
                }
                else
                {
                    tempPrice = 0;
                    tempMarketPrice = 0;
                }
                iMySQLCommand.Parameters.Add("@click_count", MySqlDbType.UInt24).Value = int.Parse(iTempInfo.PhoneClick);
                iMySQLCommand.Parameters.Add("@is_new", MySqlDbType.UInt16).Value = iTempInfo.isNEW ? 1 : 0;
                iMySQLCommand.Parameters.Add("@is_best", MySqlDbType.UInt16).Value = iTempInfo.isBest ? 1 : 0;
                iMySQLCommand.Parameters.Add("@is_hot", MySqlDbType.UInt16).Value = iTempInfo.isHot ? 1 : 0;
                iMySQLCommand.Parameters.Add("@keywords", MySqlDbType.VarChar, 255).Value = iTempInfo.Keywords;
                iMySQLCommand.Parameters.Add("@goods_url", MySqlDbType.VarChar, 255).Value = iTempInfo.TBURL;
                iMySQLCommand.Parameters.Add("@market_price", MySqlDbType.Decimal).Value = tempMarketPrice;
                iMySQLCommand.Parameters.Add("@shop_price", MySqlDbType.Decimal).Value = tempPrice;
                iMySQLCommand.Parameters.Add("@goods_equip", MySqlDbType.VarChar, 255).Value = iTempInfo.Equipment;

                if (iTempInfo.Detail != "")
                {
                    iMySQLCommand.Parameters.Add("@goods_desc", MySqlDbType.Text).Value = iTempInfo.Detail;
                }
                //goods_short_name
                iMySQLCommand.Parameters.Add("@goods_short_name", MySqlDbType.VarChar, 120).Value =
                    iTempInfo.PhoneShortName;
                iMySQLCommand.ExecuteNonQuery();

                string myDeletePriceQuery = "DELETE FROM ecs_goods_attr WHERE attr_id = 82 AND goods_id=" + PhoneID;
                iMySQLCommand.CommandText = myDeletePriceQuery;
                iMySQLCommand.ExecuteNonQuery();

                //string myUpdateAttrQuery = "UPDATE ecs_goods_attr SET attr_value = @attr_value, attr_price = @attr_price WHERE attr_id = 82 AND goods_id=" + PhoneID;
                if (!iOther)
                {
                    const string iMySQLAttrMaxQuery = "SELECT MAX(goods_attr_id) FROM ecs_goods_attr";

                    iMySQLCommand.CommandText = iMySQLAttrMaxQuery;
                    MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                    string tempGoodAtrr = "9999";
                    try
                    {
                        while (iMySQLReaderAttr.Read())
                        {
                            tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                        }
                    }
                    catch (Exception)
                    {
                        tempGoodAtrr = "0";
                    }

                    iMySQLReaderAttr.Close();

                    const string myUpdateAttrQuery =
                        "insert into ecs_goods_attr(goods_attr_id,goods_id,attr_id,attr_value,attr_price) values(@goods_attr_id,@goods_id2,@attr_id,@attr_value,@attr_price)";

                    iMySQLCommand.CommandText = myUpdateAttrQuery;
                    iMySQLCommand.Parameters.Add("@goods_attr_id", MySqlDbType.UInt24);
                    iMySQLCommand.Parameters.Add("@goods_id2", MySqlDbType.UInt32);
                    iMySQLCommand.Parameters.Add("@attr_id", MySqlDbType.UInt16);
                    iMySQLCommand.Parameters.Add("@attr_value", MySqlDbType.Text);
                    iMySQLCommand.Parameters.Add("@attr_price", MySqlDbType.VarChar, 255);

                    for (int i = 0; i < iTempInfo.ColorPrice.Length; i++)
                    {
                        if (string.IsNullOrEmpty(iTempInfo.ColorPrice[i].Color)) continue;
                        iMySQLCommand.Parameters["@goods_attr_id"].Value = int.Parse(tempGoodAtrr) + 1 + i;
                        iMySQLCommand.Parameters["@goods_id2"].Value = PhoneID;
                        iMySQLCommand.Parameters["@attr_id"].Value = 82;
                        iMySQLCommand.Parameters["@attr_value"].Value = iTempInfo.ColorPrice[i].Color;
                        iMySQLCommand.Parameters["@attr_price"].Value = iTempInfo.ColorPrice[i].Price;
                        iMySQLCommand.ExecuteNonQuery();
                    }
                }
                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                Console.Write(e.Message);
                iReturn.ErrDesc = e.Message;
            }


            return iReturn;
        }

        #endregion

        #region 删除手机

        public ReturnResult DeletePhone(string PhoneID)
        {
            var iResult = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string myUpdateQuery =
                "UPDATE ecs_goods SET is_delete = 1 WHERE goods_id=" +
                PhoneID;
            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);
            try
            {
                iMySQLconn.Open();
                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        public struct SPhoneInfo
        {
            public PhoneColor[] ColorPrice;
            public string Detail;
            public string Equipment;
            public string ErrString;
            public string Keywords;
            public string PhoneClick;
            public string[] PhoneGallery;
            public string PhonePic;
            public string PhoneShortName;
            public string TBURL;
            public bool isBest;
            public bool isError;
            public bool isHot;
            public bool isNEW;
        }

        #endregion

        #region LongXiangERP 操作

        #region 旧版手机销售模块

        #region 通过手机ID获得购买人.OLD

        public LXUser ReadUserByPhoneID(string iPhoneID)
        {
            var tempUser = new LXUser[100000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_users WHERE buyphones LIKE '%" + iPhoneID + "%'";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;
            int targetUserID = 0;

            try
            {
                int i = 0;
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    tempUser[i].UserID = int.Parse(iMySQLReader.GetString(0));
                    tempUser[i].GroupID = int.Parse(iMySQLReader.GetString(1));
                    tempUser[i].Email = iMySQLReader.GetString(2);

                    tempUser[i].Phone = iMySQLReader.GetString(3);
                    tempUser[i].Telephone = iMySQLReader.GetString(4);
                    tempUser[i].QQ = iMySQLReader.GetString(5);

                    string[] tempPhoneID = iMySQLReader.GetString(6).Split('|');

                    var tempPhone = new LXPhones[tempPhoneID.Length];

                    for (int j = 0; j < tempPhone.Length; j++)
                    {
                        tempPhone[j].PhoneID = tempPhoneID[j];
                        if (iPhoneID == tempPhoneID[j])
                        {
                            targetUserID = i;
                        }
                    }

                    tempUser[i].BuyPhones = tempPhone;

                    tempUser[i].UserCName = iMySQLReader.GetString(7);
                    tempUser[i].ContectAddress = iMySQLReader.GetString(8);

                    tempUser[i].Birthday = iMySQLReader.GetString(9);
                    tempUser[i].LXCredit = iMySQLReader.GetString(10);
                    tempUser[i].haveBXK = iMySQLReader.GetString(11) == "1";
                    tempUser[i].BXKid = iMySQLReader.GetString(12);
                    tempUser[i].UserTip = iMySQLReader.GetString(13);
                    tempUser[i].userType = int.Parse(iMySQLReader.GetString(14));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();

                if (tempUser[targetUserID].BuyPhones != null)
                {
                    for (int x = 0; x < tempUser[targetUserID].BuyPhones.Length; x++)
                    {
                        if (tempUser[targetUserID].BuyPhones[x].PhoneID != null)
                        {
                            tempUser[targetUserID].BuyPhones[x] =
                                ReadPhone(int.Parse(tempUser[targetUserID].BuyPhones[x].PhoneID));
                        }
                    }
                }
            }
            catch (Exception)
            {
                tempUser[targetUserID] = default(LXUser);
            }

            return tempUser[targetUserID];
        }

        #endregion

        #region 修改手机.OLD

        public LXPhones[] ReadPhoneByIMEI(string strIMEI)
        {
            var tempPhone = new LXPhones[100];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_phones WHERE phone_IMEI = '" + strIMEI + "' ORDER BY phone_date";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;
            int i = 0;
            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    tempPhone[i].PhoneID = iMySQLReader.GetString(0);
                    tempPhone[i].PhoneDate = iMySQLReader.GetString(1);
                    tempPhone[i].PhoneBrand = iMySQLReader.GetString(2);
                    tempPhone[i].PhoneName = ReadPhoneName(int.Parse(iMySQLReader.GetString(3)));
                    tempPhone[i].PhoneIMEI = iMySQLReader.GetString(4);
                    tempPhone[i].PhonePrice = iMySQLReader.GetString(5);
                    tempPhone[i].PhoneSeller = iMySQLReader.GetString(6);
                    tempPhone[i].PhoneProfit = iMySQLReader.GetString(7);
                    tempPhone[i].PhoneRealPrice = iMySQLReader.GetString(8);
                    tempPhone[i].PhoneCommision = iMySQLReader.GetString(9);
                    tempPhone[i].PhoneHasEquip = iMySQLReader.GetString(10) != "0";
                    tempPhone[i].PhoneHasWarranty = iMySQLReader.GetString(11) != "0";
                    tempPhone[i].PhoneWarrantyType = iMySQLReader.GetString(12);
                    tempPhone[i].PhoneWarrantyDuration = iMySQLReader.GetString(13);
                    tempPhone[i].PhoneWarrantyDate = iMySQLReader.GetString(14);
                    tempPhone[i].PhoneIsDelete = iMySQLReader.GetString(15) != "0";
                    tempPhone[i].phone_supplier = iMySQLReader.GetString(16);
                    tempPhone[i].PhoneEquipPrice = iMySQLReader.GetString(17);
                    tempPhone[i].PhoneEquipRealPrice = iMySQLReader.GetString(18);
                    tempPhone[i].PhoneIsLegal = iMySQLReader.GetString(19) != "0";
                    tempPhone[i].PhoneIsHKLegal = iMySQLReader.GetString(20) != "0";
                    tempPhone[i].PhoneIsUnLegal = iMySQLReader.GetString(21) != "0";
                    tempPhone[i].PhoneWarrantyPrice = iMySQLReader.GetString(22);
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
            }
            catch (Exception)
            {
                tempPhone = null;
            }

            return tempPhone;
        }

        public ReturnResult UpdatePhoneByIMEI(LXPhones tempPhone)
        {
            var iResult = new ReturnResult();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery =
                "UPDATE crm_phones SET phone_warranty = @phone_warranty, phone_warrantyType = @phone_warrantyType, phone_warrantyDuration = @phone_warrantyDuration, phone_warrantyDate = @phone_warrantyDate WHERE phone_IMEI = '" +
                tempPhone.PhoneIMEI + "'";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);


            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@phone_warranty", MySqlDbType.UInt16).Value = tempPhone.PhoneHasWarranty;
                iMySQLCommand.Parameters.Add("@phone_warrantyType", MySqlDbType.UInt16).Value =
                    tempPhone.PhoneWarrantyType;
                iMySQLCommand.Parameters.Add("@phone_warrantyDuration", MySqlDbType.UInt16).Value =
                    tempPhone.PhoneWarrantyDuration;
                iMySQLCommand.Parameters.Add("@phone_warrantyDate", MySqlDbType.VarChar, 20).Value =
                    tempPhone.PhoneWarrantyDate;

                /*
                 iMySQLCommand.Parameters.Add("@phone_warranty", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_warrantyType", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_warrantyDuration", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_warrantyDate", MySqlDbType.VarChar, 20);
                 */

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }


            return iResult;
        }

        public ReturnResult UpdatePhoneByID(LXPhones tempPhone)
        {
            string[] iPosition = SellersPosition();
            var iResult = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery =
                "UPDATE crm_phones SET phone_date = @phone_date, brand_id = @brand_id, phone_name = @phone_name, phone_IMEI = @phone_IMEI, phone_price = @phone_price, phone_seller = @phone_seller, phone_profit = @phone_profit, phone_realprice = @phone_realprice, phone_commision = @phone_commision, phone_equip = @phone_equip, phone_warranty = @phone_warranty, phone_warrantyType = @phone_warrantyType, phone_warrantyDuration = @phone_warrantyDuration, phone_warrantyDate = @phone_warrantyDate, phone_isDelete = @phone_isDelete, phone_supplier = @phone_supplier, phone_equipPrice = @phone_equipPrice, phone_equipRealPrice = @phone_equipRealPrice, phone_isLegal = @phone_isLegal, phone_isHKLegal = @phone_isHKLegal ,phone_isUnLegal = @phone_isUnLegal ,phone_WarrantyPrice = @phone_WarrantyPrice WHERE phone_id = '" +
                tempPhone.PhoneID + "'";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);


            try
            {
                iMySQLconn.Open();

                int Profit = (int.Parse(tempPhone.PhonePrice) - int.Parse(tempPhone.PhoneRealPrice)) +
                             (int.Parse(tempPhone.PhoneEquipPrice) - int.Parse(tempPhone.PhoneEquipRealPrice));
                int Commision;

                iMySQLCommand.Parameters.Add("@phone_date", MySqlDbType.VarChar, 20).Value = tempPhone.PhoneDate;
                iMySQLCommand.Parameters.Add("@brand_id", MySqlDbType.UInt16).Value = int.Parse(tempPhone.PhoneBrand);
                iMySQLCommand.Parameters.Add("@phone_name", MySqlDbType.UInt16).Value = ReadPhoneID(tempPhone.PhoneName);
                iMySQLCommand.Parameters.Add("@phone_IMEI", MySqlDbType.VarChar, 50).Value = tempPhone.PhoneIMEI;
                iMySQLCommand.Parameters.Add("@phone_price", MySqlDbType.UInt32).Value = int.Parse(tempPhone.PhonePrice);

                iMySQLCommand.Parameters.Add("@phone_seller", MySqlDbType.UInt16).Value =
                    int.Parse(tempPhone.PhoneSeller);

                iMySQLCommand.Parameters.Add("@phone_profit", MySqlDbType.Int32).Value = Profit;

                iMySQLCommand.Parameters.Add("@phone_realprice", MySqlDbType.UInt32).Value =
                    int.Parse(tempPhone.PhoneRealPrice);
                /*100 10
                 * 200 20
                 * 
                 * 500 100
                */
                if (Profit < 100)
                {
                    Commision = 0;
                }
                else if (100 <= Profit && Profit < 500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0");
                }
                else if (500 <= Profit && Profit < 1000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 50;
                }
                else if (1000 <= Profit && Profit < 1500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 100;
                }
                else if (1500 <= Profit && Profit < 2000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 15150;
                }
                else
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 200;
                }

                if (iPosition[int.Parse(tempPhone.PhoneSeller)] != "店长" &&
                    iPosition[int.Parse(tempPhone.PhoneSeller)] != "销售")
                {
                    iMySQLCommand.Parameters.Add("@phone_commision", MySqlDbType.Int32).Value = 0;
                }
                else
                {
                    iMySQLCommand.Parameters.Add("@phone_commision", MySqlDbType.Int32).Value = Commision;
                }

                //iMySQLCommand.Parameters.Add("@phone_commision", MySqlDbType.Int32).Value = Commision;
                iMySQLCommand.Parameters.Add("@phone_equip", MySqlDbType.UInt16).Value = tempPhone.PhoneHasEquip ? 1 : 0;
                iMySQLCommand.Parameters.Add("@phone_warranty", MySqlDbType.UInt16).Value = tempPhone.PhoneHasEquip
                                                                                                ? 1
                                                                                                : 0;
                iMySQLCommand.Parameters.Add("@phone_warrantyType", MySqlDbType.UInt16).Value =
                    int.Parse(tempPhone.PhoneWarrantyType);
                iMySQLCommand.Parameters.Add("@phone_warrantyDuration", MySqlDbType.UInt16).Value =
                    int.Parse(tempPhone.PhoneWarrantyDuration);
                iMySQLCommand.Parameters.Add("@phone_warrantyDate", MySqlDbType.VarChar, 20).Value =
                    tempPhone.PhoneWarrantyDate;
                iMySQLCommand.Parameters.Add("@phone_isDelete", MySqlDbType.UInt16).Value = tempPhone.PhoneIsDelete
                                                                                                ? 1
                                                                                                : 0;
                iMySQLCommand.Parameters.Add("@phone_supplier", MySqlDbType.VarChar, 50).Value =
                    tempPhone.phone_supplier;
                iMySQLCommand.Parameters.Add("@phone_equipPrice", MySqlDbType.UInt32).Value =
                    int.Parse(tempPhone.PhoneEquipPrice);

                iMySQLCommand.Parameters.Add("@phone_equipRealPrice", MySqlDbType.UInt32).Value =
                    int.Parse(tempPhone.PhoneEquipRealPrice);

                iMySQLCommand.Parameters.Add("@phone_isLegal", MySqlDbType.UInt16).Value = tempPhone.PhoneIsLegal
                                                                                               ? 1
                                                                                               : 0;
                iMySQLCommand.Parameters.Add("@phone_isHKLegal", MySqlDbType.UInt16).Value = tempPhone.PhoneIsHKLegal
                                                                                                 ? 1
                                                                                                 : 0;
                iMySQLCommand.Parameters.Add("@phone_isUnLegal", MySqlDbType.UInt16).Value = tempPhone.PhoneIsUnLegal
                                                                                                 ? 1
                                                                                                 : 0;
                iMySQLCommand.Parameters.Add("@phone_WarrantyPrice", MySqlDbType.UInt32).Value =
                    int.Parse(tempPhone.PhoneWarrantyPrice);
                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #region 读取手机.OLD

        private static string ReadPhoneID(string PhoneName)
        {
            string tempID = "";
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT goods_id FROM ecs_goods WHERE goods_short_name = '" + PhoneName + "'";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    tempID = iMySQLReader.GetString(0);
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
            }
            catch (Exception)
            {
                tempID = "";
            }

            return tempID;
        }

        private static string ReadPhoneName(int PhoneID)
        {
            string tempName = "";
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT goods_short_name FROM ecs_goods WHERE goods_id=" + PhoneID;
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    tempName = iMySQLReader.GetString(0);
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
            }
            catch (Exception)
            {
                tempName = "";
            }

            return tempName;
        }

        public LXPhones ReadPhone(int PhoneID)
        {
            var tempPhone = new LXPhones();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_phones WHERE phone_id =" + PhoneID;

            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();

                while (iMySQLReader.Read())
                {
                    tempPhone.PhoneID = iMySQLReader.GetString(0);
                    tempPhone.PhoneDate = iMySQLReader.GetString(1);
                    tempPhone.PhoneBrand = iMySQLReader.GetString(2);
                    tempPhone.PhoneName = ReadPhoneName(int.Parse(iMySQLReader.GetString(3)));
                    tempPhone.PhoneIMEI = iMySQLReader.GetString(4);
                    tempPhone.PhonePrice = iMySQLReader.GetString(5);
                    tempPhone.PhoneSeller = iMySQLReader.GetString(6);
                    tempPhone.PhoneProfit = iMySQLReader.GetString(7);
                    tempPhone.PhoneRealPrice = iMySQLReader.GetString(8);
                    tempPhone.PhoneCommision = iMySQLReader.GetString(9);
                    tempPhone.PhoneHasEquip = iMySQLReader.GetString(10) != "0";
                    tempPhone.PhoneHasWarranty = iMySQLReader.GetString(11) != "0";
                    tempPhone.PhoneWarrantyType = iMySQLReader.GetString(12);
                    tempPhone.PhoneWarrantyDuration = iMySQLReader.GetString(13);
                    tempPhone.PhoneWarrantyDate = iMySQLReader.GetString(14);
                    tempPhone.PhoneIsDelete = iMySQLReader.GetString(15) != "0";
                    tempPhone.phone_supplier = iMySQLReader.GetString(16);
                    tempPhone.PhoneEquipPrice = iMySQLReader.GetString(17);
                    tempPhone.PhoneEquipRealPrice = iMySQLReader.GetString(18);
                    tempPhone.PhoneIsLegal = iMySQLReader.GetString(19) != "0";
                    tempPhone.PhoneIsHKLegal = iMySQLReader.GetString(20) != "0";
                    tempPhone.PhoneIsUnLegal = iMySQLReader.GetString(21) != "0";
                    tempPhone.PhoneWarrantyPrice = iMySQLReader.GetString(22);
                }
                iMySQLReader.Close();
                iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempPhone = default(LXPhones);
            }

            return tempPhone;
        }

        #endregion

        #region 彻底删除手机.OLD

        public ReturnResult DeletePhone(int phone_id, int userid)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "DELETE FROM crm_phones WHERE phone_id = " + phone_id;
            string iMySQLUserPhones = "SELECT buyphones FROM crm_users WHERE cuid = " + userid;
            string iMySQLUpdateUserPhones = "UPDATE crm_users SET buyphones = @buyphones WHERE cuid=" + userid;

            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);

            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLCommand.ExecuteNonQuery();
                iMySQLCommand.CommandText = iMySQLUserPhones;
                //完成删除
                string buyPhoneStr = "";
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    buyPhoneStr = iMySQLReader.GetString(0);
                }

                iMySQLReader.Close();

                string[] buyPhones = buyPhoneStr.Split('|');

                for (int i = 0; i < buyPhones.Length; i++)
                {
                    if (buyPhones[i] == phone_id.ToString())
                    {
                        buyPhones[i] = "";
                    }
                }

                buyPhoneStr = "";

                for (int i = 0; i < buyPhones.Length; i++)
                {
                    if (buyPhones[i] != "")
                    {
                        buyPhoneStr = buyPhoneStr + "|" + buyPhones[i];
                    }
                }

                try
                {
                    buyPhoneStr = buyPhoneStr.Substring(1);
                }
                catch (Exception)
                {
                    buyPhoneStr = "";
                }


                iMySQLCommand.CommandText = iMySQLUpdateUserPhones;

                iMySQLCommand.Parameters.Add("@buyphones", MySqlDbType.Text).Value = buyPhoneStr;

                iMySQLCommand.ExecuteNonQuery();


                iMySQLconn.Close();
                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #region 搜索用户.OLD

        public ReturnUsers SearchUser(int UserGroup, int UserIsBXK)
        {
            var tempReturn = new ReturnUsers();
            var tempUser = new LXUser[500000];
            string SQLUserGroup = "1";
            string SQLUserBXK;

            for (int i = 0; i < tempUser.Length; i++)
            {
                tempUser[i].iFlag = false;
            }


            if (UserGroup == 0 || UserGroup == -1)
            {
                //UserGroup 不作为判断条件
                SQLUserGroup = "1";
            }
            else
            {
                switch (UserGroup)
                {
                    case 1:
                        SQLUserGroup = "groupid = 15";
                        break;
                    case 2:
                        SQLUserGroup = "groupid = 16";
                        break;
                    case 3:
                        SQLUserGroup = "groupid = 17";
                        break;
                    case 4:
                        SQLUserGroup = "groupid = 18";
                        break;
                }
            }


            switch (UserIsBXK)
            {
                case -1:
                case 0:
                    SQLUserBXK = "1";
                    break;
                case 1:
                    SQLUserBXK = "haveBXK = 1";
                    break;
                default:
                    SQLUserBXK = "haveBXK = 0";
                    break;
            }

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_users WHERE " + SQLUserGroup + " AND " + SQLUserBXK;
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempUser[i].iFlag = true;

                    tempUser[i].UserName = iMySQLReader.GetString(2);
                    //tempUser[i].Email = iMySQLReader.GetString(4);

                    tempUser[i].Phone = iMySQLReader.GetString(17);
                    //tempUser[i].Telephone = iMySQLReader.GetString(18);
                    //tempUser[i].QQ = iMySQLReader.GetString(19);

                    string[] tempPhoneID = iMySQLReader.GetString(20).Split('|');

                    var tempPhone = new LXPhones[tempPhoneID.Length];

                    for (int j = 0; j < tempPhone.Length; j++)
                    {
                        tempPhone[j].PhoneID = tempPhoneID[j];
                    }

                    tempUser[i].BuyPhones = tempPhone;
                    tempUser[i].UserCName = iMySQLReader.GetString(21);
                    tempUser[i].ContectAddress = iMySQLReader.GetString(22);

                    tempUser[i].Birthday = iMySQLReader.GetString(23);
                    tempUser[i].LXCredit = iMySQLReader.GetString(24);
                    tempUser[i].haveBXK = iMySQLReader.GetString(25) == "1";
                    tempUser[i].BXKid = iMySQLReader.GetString(26);
                    tempUser[i].UserTip = iMySQLReader.GetString(27);

                    i++;
                }
                tempReturn.UserNum = i;
                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();

                for (int j = 0; j < tempReturn.UserNum; j++)
                {
                    if (tempUser[j].BuyPhones == null) continue;
                    for (int x = 0; x < tempUser[j].BuyPhones.Length; x++)
                    {
                        if (tempUser[j].BuyPhones[x].PhoneID != null)
                        {
                            tempUser[j].BuyPhones[x] = ReadPhone(int.Parse(tempUser[j].BuyPhones[x].PhoneID));
                        }
                    }
                }


                tempReturn.UserInfo = tempUser;
                tempReturn.isError = false;
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
                tempReturn.isError = true;
                tempReturn.ErrString = e.Message;
            }

            return tempReturn;
        }

        #endregion

        #region 修改用户.OLD

        public ReturnUsers GetSingleUser(string UserCName, string UserPhone, string UserBXKId)
        {
            var tempReturn = new ReturnUsers();
            var tempUserInfo = new LXUser[20];

            for (int i = 0; i < tempUserInfo.Length; i++)
            {
                tempUserInfo[i].iFlag = false;
            }

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string mySelectQuery;

            if (UserPhone == "")
            {
                mySelectQuery = "SELECT * FROM crm_users WHERE userCName LIKE '%" + UserCName + "%'" + " AND BXKid='" +
                                UserBXKId + "'";
            }
            else
            {
                mySelectQuery = "SELECT * FROM crm_users WHERE userCName LIKE '%" + UserCName + "%'" + " AND phone='" +
                                UserPhone +
                                "'";
            }


            /*

            if (Groupid.ToString() != "0")
            {
                if (UserName == "")
                {
                    mySelectQuery = "SELECT * FROM crm_users WHERE groupid=" + Groupid + " AND userCName='" +
                                    UserCName + "'";
                }
                if (UserCName == "")
                {
                    mySelectQuery = "SELECT * FROM crm_users WHERE groupid=" + Groupid + " AND username='" + UserName +
                                    "'";
                }
            }
            else
            {
                if (UserName == "")
                {
                    mySelectQuery = "SELECT * FROM crm_users WHERE userCName='" + UserCName + "'";
                }
                if (UserCName == "")
                {
                    mySelectQuery = "SELECT * FROM crm_users WHERE username='" + UserName + "'";
                }
            }
            */

            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;
            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    //iMySQLColorReader.GetString(0)
                    tempUserInfo[i].iFlag = true;
                    tempUserInfo[i].UserID = int.Parse(iMySQLReader.GetString(0));
                    tempUserInfo[i].GroupID = int.Parse(iMySQLReader.GetString(1));
                    //tempUserInfo[i].UserName = iMySQLReader.GetString(2);
                    tempUserInfo[i].Email = iMySQLReader.GetString(2);

                    tempUserInfo[i].Phone = iMySQLReader.GetString(3);
                    tempUserInfo[i].Telephone = iMySQLReader.GetString(4);
                    tempUserInfo[i].QQ = iMySQLReader.GetString(5);

                    string[] tempPhoneID = iMySQLReader.GetString(6).Split('|');

                    var tempPhone = new LXPhones[tempPhoneID.Length];

                    for (int j = 0; j < tempPhone.Length; j++)
                    {
                        tempPhone[j].PhoneID = tempPhoneID[j];
                    }

                    tempUserInfo[i].BuyPhones = tempPhone;
                    tempUserInfo[i].UserCName = iMySQLReader.GetString(7);
                    tempUserInfo[i].ContectAddress = iMySQLReader.GetString(8);

                    tempUserInfo[i].Birthday = iMySQLReader.GetString(9);
                    tempUserInfo[i].LXCredit = iMySQLReader.GetString(10);
                    tempUserInfo[i].haveBXK = iMySQLReader.GetString(11) == "1";
                    tempUserInfo[i].BXKid = iMySQLReader.GetString(12);
                    tempUserInfo[i].UserTip = iMySQLReader.GetString(13);
                    tempUserInfo[i].userType = int.Parse(iMySQLReader.GetString(14));
                    i++;
                }
                tempReturn.UserNum = i;
                iMySQLReader.Close();

                //这里去请求手机


                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();

                for (int j = 0; j < tempReturn.UserNum; j++)
                {
                    if (tempUserInfo[j].BuyPhones == null) continue;
                    for (int x = 0; x < tempUserInfo[j].BuyPhones.Length; x++)
                    {
                        if (!string.IsNullOrEmpty(tempUserInfo[j].BuyPhones[x].PhoneID))
                        {
                            tempUserInfo[j].BuyPhones[x] = ReadPhone(int.Parse(tempUserInfo[j].BuyPhones[x].PhoneID));
                        }
                    }
                }

                tempReturn.UserInfo = tempUserInfo;
                tempReturn.isError = false;
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
                tempReturn.isError = true;
                tempReturn.ErrString = e.Message;
            }

            return tempReturn;
        }

        public ReturnResult EditUser(LXUser TempUser)
        {
            var iReturn = new ReturnResult {isSuccess = false};
            string[] iPosition = SellersPosition();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            /*
            var mySelectQuery =
                "UPDATE crm_users SET groupid = @groupid, email = @email, phone = @phone, Telephone = @Telephone, QQ = @QQ, userCName = @userCName, contectAddress = @contectAddress, birthday = @birthday, LXcredit = @LXcredit, haveBXK = @haveBXK, BXKid = @BXKid, userTip = @userTip, userType = @userType WHERE groupid=" +
                TempUser.GroupID + " AND UserCName='" + TempUser.UserCName + "' AND phone ='" + TempUser.Phone + "'";
            */
            string mySelectQuery =
                "UPDATE crm_users SET groupid = @groupid, email = @email, phone = @phone, Telephone = @Telephone, QQ = @QQ, userCName = @userCName, contectAddress = @contectAddress, birthday = @birthday, LXcredit = @LXcredit, haveBXK = @haveBXK, BXKid = @BXKid, userTip = @userTip, userType = @userType WHERE cuid=" +
                TempUser.UserID;

            const string iMySQLPhoneCheck = "SELECT MAX(phone_id) FROM crm_phones";
            const string iMySQLPhonesQuery =
                "insert into crm_phones(phone_id,phone_date,brand_id,phone_name,phone_IMEI,phone_price,phone_seller,phone_profit,phone_realprice,phone_commision,phone_equip,phone_warranty,phone_warrantyType,phone_warrantyDuration, phone_warrantyDate, phone_isDelete, phone_supplier,phone_equipPrice,phone_equipRealPrice,phone_isLegal,phone_isHKLegal,phone_isUnLegal,phone_WarrantyPrice) values(@phone_id,@phone_date,@brand_id,@phone_name,@phone_IMEI,@phone_price,@phone_seller,@phone_profit,@phone_realprice,@phone_commision,@phone_equip,@phone_warranty,@phone_warrantyType,@phone_warrantyDuration,@phone_warrantyDate,@phone_isDelete,@phone_supplier,@phone_equipPrice,@phone_equipRealPrice,@phone_isLegal,@phone_isHKLegal,@phone_isUnLegal,@phone_WarrantyPrice)";

            /*
            string ReadUserBuyPhone = "SELECT buyphones FROM crm_users WHERE groupid= '" +
                                      TempUser.GroupID + "' AND userCName='" +
                                      TempUser.UserCName +
                                      "'";
            */

            string UpdateUserBuyPhone = "UPDATE crm_users SET buyphones = @buyphones WHERE groupid= '" +
                                        TempUser.GroupID + "' AND userCName='" +
                                        TempUser.UserCName +
                                        "'";

            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                //iMySQLColorReader.GetString(0)
                iMySQLCommand.Parameters.Add("@groupid", MySqlDbType.UInt16).Value = TempUser.GroupID;
                iMySQLCommand.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = TempUser.Email;
                iMySQLCommand.Parameters.Add("@phone", MySqlDbType.VarChar, 20).Value = TempUser.Phone;
                iMySQLCommand.Parameters.Add("@Telephone", MySqlDbType.VarChar, 20).Value = TempUser.Telephone;
                iMySQLCommand.Parameters.Add("@QQ", MySqlDbType.VarChar, 12).Value = TempUser.QQ;
                iMySQLCommand.Parameters.Add("@userCName", MySqlDbType.VarChar, 20).Value = TempUser.UserCName;
                iMySQLCommand.Parameters.Add("@contectAddress", MySqlDbType.Text).Value = TempUser.ContectAddress;
                iMySQLCommand.Parameters.Add("@birthday", MySqlDbType.VarChar, 8).Value = TempUser.Birthday;
                iMySQLCommand.Parameters.Add("@LXcredit", MySqlDbType.VarChar, 11).Value = TempUser.LXCredit;
                iMySQLCommand.Parameters.Add("@haveBXK", MySqlDbType.UInt16).Value = TempUser.haveBXK ? 1 : 0;
                iMySQLCommand.Parameters.Add("@BXKid", MySqlDbType.VarChar, 10).Value = TempUser.BXKid;
                iMySQLCommand.Parameters.Add("@userTip", MySqlDbType.Text).Value = TempUser.UserTip;
                iMySQLCommand.Parameters.Add("@userType", MySqlDbType.UInt16).Value = TempUser.userType;
                iMySQLCommand.ExecuteNonQuery();

                //这里开始处理手机部分

                iMySQLCommand.CommandText = iMySQLPhoneCheck;
                MySqlDataReader iMySQLReaderPhone = iMySQLCommand.ExecuteReader();
                string tempPhoneID = "9999";
                try
                {
                    while (iMySQLReaderPhone.Read())
                    {
                        tempPhoneID = (iMySQLReaderPhone.GetString(0));
                    }
                }
                catch (Exception)
                {
                    tempPhoneID = "0";
                }

                iMySQLReaderPhone.Close();

                iMySQLCommand.CommandText = iMySQLPhonesQuery;

                iMySQLCommand.Parameters.Add("@phone_id", MySqlDbType.UInt32);
                iMySQLCommand.Parameters.Add("@phone_date", MySqlDbType.VarChar, 20);
                iMySQLCommand.Parameters.Add("@brand_id", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_name", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_IMEI", MySqlDbType.VarChar, 50);
                iMySQLCommand.Parameters.Add("@phone_price", MySqlDbType.UInt32);
                iMySQLCommand.Parameters.Add("@phone_seller", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_profit", MySqlDbType.Int32);
                iMySQLCommand.Parameters.Add("@phone_realprice", MySqlDbType.UInt32);
                iMySQLCommand.Parameters.Add("@phone_commision", MySqlDbType.Int32);
                iMySQLCommand.Parameters.Add("@phone_equip", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_warranty", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_warrantyType", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_warrantyDuration", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_warrantyDate", MySqlDbType.VarChar, 20);
                iMySQLCommand.Parameters.Add("@phone_isDelete", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_supplier", MySqlDbType.VarChar, 50);
                iMySQLCommand.Parameters.Add("@phone_equipPrice", MySqlDbType.UInt32);
                iMySQLCommand.Parameters.Add("@phone_equipRealPrice", MySqlDbType.UInt32);
                iMySQLCommand.Parameters.Add("@phone_isLegal", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_isHKLegal", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_isUnLegal", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_WarrantyPrice", MySqlDbType.UInt32);
                int lolNum = 0;
                var tempPhoneIDArr = new string[100];
                for (int i = 0; i < TempUser.BuyPhones.Length; i++)
                {
                    LXPhones tempPhone = TempUser.BuyPhones[i];

                    if (tempPhone.PhoneID != "") continue;
                    int Profit = int.Parse(tempPhone.PhonePrice) - int.Parse(tempPhone.PhoneRealPrice);
                    int Commision;
                    iMySQLCommand.Parameters["@phone_id"].Value = int.Parse(tempPhoneID) + 1 + lolNum;
                    iMySQLCommand.Parameters["@phone_date"].Value = tempPhone.PhoneDate;
                    iMySQLCommand.Parameters["@brand_id"].Value = int.Parse(tempPhone.PhoneBrand);
                    iMySQLCommand.Parameters["@phone_name"].Value = ReadPhoneID(tempPhone.PhoneName);
                    iMySQLCommand.Parameters["@phone_IMEI"].Value = tempPhone.PhoneIMEI;
                    iMySQLCommand.Parameters["@phone_price"].Value = int.Parse(tempPhone.PhonePrice);
                    iMySQLCommand.Parameters["@phone_seller"].Value = int.Parse(tempPhone.PhoneSeller);
                    iMySQLCommand.Parameters["@phone_profit"].Value = Profit;
                    iMySQLCommand.Parameters["@phone_realprice"].Value = int.Parse(tempPhone.PhoneRealPrice);
                    /*100 10
                         * 200 20
                         * 
                         * 500 100
                        */
                    if (Profit < 100)
                    {
                        Commision = 0;
                    }
                    else if (100 <= Profit && Profit < 500)
                    {
                        Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0");
                    }
                    else if (500 <= Profit && Profit < 1000)
                    {
                        Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 50;
                    }
                    else if (1000 <= Profit && Profit < 1500)
                    {
                        Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 100;
                    }
                    else if (1500 <= Profit && Profit < 2000)
                    {
                        Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 150;
                    }
                    else
                    {
                        Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 200;
                    }

                    if (iPosition[int.Parse(tempPhone.PhoneSeller)] != "店长" &&
                        iPosition[int.Parse(tempPhone.PhoneSeller)] != "销售")
                    {
                        iMySQLCommand.Parameters["@phone_commision"].Value = 0;
                    }
                    else
                    {
                        iMySQLCommand.Parameters["@phone_commision"].Value = Commision;
                    }

                    iMySQLCommand.Parameters["@phone_equip"].Value = tempPhone.PhoneHasEquip ? 1 : 0;
                    iMySQLCommand.Parameters["@phone_warranty"].Value = tempPhone.PhoneHasWarranty ? 1 : 0;
                    iMySQLCommand.Parameters["@phone_warrantyType"].Value =
                        int.Parse(tempPhone.PhoneWarrantyType);
                    iMySQLCommand.Parameters["@phone_warrantyDuration"].Value =
                        int.Parse(tempPhone.PhoneWarrantyDuration);
                    iMySQLCommand.Parameters["@phone_warrantyDate"].Value = tempPhone.PhoneWarrantyDate;
                    iMySQLCommand.Parameters["@phone_isDelete"].Value = tempPhone.PhoneIsDelete ? 1 : 0;
                    iMySQLCommand.Parameters["@phone_supplier"].Value = tempPhone.phone_supplier;
                    iMySQLCommand.Parameters["@phone_equipPrice"].Value = tempPhone.PhoneEquipPrice;
                    iMySQLCommand.Parameters["@phone_equipRealPrice"].Value = tempPhone.PhoneEquipRealPrice;
                    iMySQLCommand.Parameters["@phone_isLegal"].Value = tempPhone.PhoneIsLegal ? 1 : 0;
                    iMySQLCommand.Parameters["@phone_isHKLegal"].Value = tempPhone.PhoneIsHKLegal ? 1 : 0;
                    iMySQLCommand.Parameters["@phone_isUnLegal"].Value = tempPhone.PhoneIsUnLegal ? 1 : 0;
                    iMySQLCommand.Parameters["@phone_WarrantyPrice"].Value = tempPhone.PhoneWarrantyPrice;

                    iMySQLCommand.ExecuteNonQuery();

                    tempPhoneIDArr[i] = (int.Parse(tempPhoneID) + 1 + lolNum).ToString();

                    lolNum++;
                }

                string tempPhoneBuys = "";

                for (int i = 0; i < TempUser.BuyPhones.Length; i++)
                {
                    if (!string.IsNullOrEmpty(TempUser.BuyPhones[i].PhoneID))
                    {
                        tempPhoneBuys = tempPhoneBuys + "|" + TempUser.BuyPhones[i].PhoneID;
                    }
                }
                try
                {
                    tempPhoneBuys = tempPhoneBuys.Substring(1);
                }
                catch (Exception)
                {
                    tempPhoneBuys = "";
                }


                string[] tempPhoneBuysArray = tempPhoneBuys.Split('|');

                string tempPhoneBuyUpdateString = "";

                for (int i = 0; i < tempPhoneBuysArray.Length; i++)
                {
                    tempPhoneBuyUpdateString = tempPhoneBuyUpdateString + "|" + tempPhoneBuysArray[i];
                }

                tempPhoneBuyUpdateString = tempPhoneBuyUpdateString.Substring(1);

                for (int i = 0; i < tempPhoneIDArr.Length; i++)
                {
                    if (tempPhoneIDArr[i] != "" && tempPhoneIDArr[i] != null)
                    {
                        tempPhoneBuyUpdateString = tempPhoneBuyUpdateString + "|" + tempPhoneIDArr[i];
                    }
                }

                try
                {
                    if (tempPhoneBuyUpdateString.Substring(0, 1) == "|")
                    {
                        tempPhoneBuyUpdateString = tempPhoneBuyUpdateString.Substring(1);
                    }
                }
                catch (Exception)
                {
                    tempPhoneBuyUpdateString = "";
                }


                iMySQLCommand.CommandText = UpdateUserBuyPhone;

                iMySQLCommand.Parameters.Add("@buyphones", MySqlDbType.Text).Value = tempPhoneBuyUpdateString;

                iMySQLCommand.ExecuteNonQuery();


                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                iReturn.ErrDesc = e.Message;
            }

            return iReturn;
        }

        #endregion

        #region 添加用户.OLD

        public ReturnResult AddUser(LXUser tempUser)
        {
            string[] iPosition = SellersPosition();
            var iResult = new ReturnResult {isSuccess = false};
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            const string iMySQLQueryCheck = "SELECT MAX(cuid) FROM crm_users";
            const string iMySQLQuery =
                "insert into crm_users(cuid,groupid,email,phone,Telephone,QQ,buyphones,userCName,contectAddress,birthday,LXcredit,haveBXK,BXKid,userTip,userType) values(@cuid,@groupid,@email,@phone,@Telephone,@QQ,@buyphones,@userCName,@contectAddress,@birthday,@LXcredit,@haveBXK,@BXKid,@userTip,@userType)";
            const string iMySQLPhoneCheck = "SELECT MAX(phone_id) FROM crm_phones";
            const string iMySQLPhonesQuery =
                "insert into crm_phones(phone_id,phone_date,brand_id,phone_name,phone_IMEI,phone_price,phone_seller,phone_profit,phone_realprice,phone_commision,phone_equip,phone_warranty,phone_warrantyType,phone_warrantyDuration,phone_warrantyDate,phone_isDelete,phone_supplier,phone_equipPrice,phone_equipRealPrice,phone_isLegal,phone_isHKLegal,phone_isUnLegal,phone_WarrantyPrice) values(@phone_id,@phone_date,@brand_id,@phone_name,@phone_IMEI,@phone_price,@phone_seller,@phone_profit,@phone_realprice,@phone_commision,@phone_equip,@phone_warranty,@phone_warrantyType,@phone_warrantyDuration,@phone_warrantyDate,@phone_isDelete,@phone_supplier,@phone_equipPrice,@phone_equipRealPrice,@phone_isLegal,@phone_isHKLegal,@phone_isUnLegal,@phone_WarrantyPrice)";

            try
            {
                var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                iMySQLconn.Open();

                MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                string tempGoodAtrr = "9999";
                while (iMySQLReaderAttr.Read())
                {
                    try
                    {
                        tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                    }
                    catch (Exception)
                    {
                        tempGoodAtrr = "0";
                    }
                }
                iMySQLReaderAttr.Close();

                iMySQLCommand.CommandText = iMySQLPhoneCheck;
                MySqlDataReader iMySQLReaderPhone = iMySQLCommand.ExecuteReader();
                string tempPhoneID = "9999";
                while (iMySQLReaderPhone.Read())
                {
                    try
                    {
                        tempPhoneID = (iMySQLReaderPhone.GetString(0));
                    }
                    catch (Exception)
                    {
                        tempPhoneID = "0";
                    }
                }
                iMySQLReaderPhone.Close();

                iMySQLCommand.CommandText = iMySQLPhonesQuery;

                LXPhones tempPhone = tempUser.BuyPhones[0];
                int Profit = (int.Parse(tempPhone.PhonePrice) - int.Parse(tempPhone.PhoneRealPrice)) +
                             (int.Parse(tempPhone.PhoneEquipPrice) - int.Parse(tempPhone.PhoneEquipRealPrice));
                int Commision;
                iMySQLCommand.Parameters.Add("@phone_id", MySqlDbType.UInt32).Value = int.Parse(tempPhoneID) + 1;
                //phone_date
                iMySQLCommand.Parameters.Add("@phone_date", MySqlDbType.VarChar, 20).Value = tempPhone.PhoneDate;
                iMySQLCommand.Parameters.Add("@brand_id", MySqlDbType.UInt16).Value = int.Parse(tempPhone.PhoneBrand);
                iMySQLCommand.Parameters.Add("@phone_name", MySqlDbType.UInt16).Value = ReadPhoneID(tempPhone.PhoneName);
                iMySQLCommand.Parameters.Add("@phone_IMEI", MySqlDbType.VarChar, 50).Value = tempPhone.PhoneIMEI;
                iMySQLCommand.Parameters.Add("@phone_price", MySqlDbType.UInt32).Value = int.Parse(tempPhone.PhonePrice);

                iMySQLCommand.Parameters.Add("@phone_seller", MySqlDbType.UInt16).Value =
                    int.Parse(tempPhone.PhoneSeller);

                iMySQLCommand.Parameters.Add("@phone_profit", MySqlDbType.Int32).Value = Profit;

                iMySQLCommand.Parameters.Add("@phone_realprice", MySqlDbType.UInt32).Value =
                    int.Parse(tempPhone.PhoneRealPrice);
                /*100 10
                 * 200 20
                 * 
                 * 500 100
                */
                if (Profit < 100)
                {
                    Commision = 0;
                }
                else if (100 <= Profit && Profit < 500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0");
                }
                else if (500 <= Profit && Profit < 1000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 50;
                }
                else if (1000 <= Profit && Profit < 1500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 100;
                }
                else if (1500 <= Profit && Profit < 2000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 15150;
                }
                else
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 200;
                }

                if (iPosition[int.Parse(tempPhone.PhoneSeller)] != "店长" &&
                    iPosition[int.Parse(tempPhone.PhoneSeller)] != "销售")
                {
                    iMySQLCommand.Parameters.Add("@phone_commision", MySqlDbType.Int32).Value = 0;
                }
                else
                {
                    iMySQLCommand.Parameters.Add("@phone_commision", MySqlDbType.Int32).Value = Commision;
                }
                //iMySQLCommand.Parameters.Add("@phone_commision", MySqlDbType.Int32).Value = Commision;
                iMySQLCommand.Parameters.Add("@phone_equip", MySqlDbType.UInt16).Value = tempPhone.PhoneHasEquip ? 1 : 0;
                iMySQLCommand.Parameters.Add("@phone_warranty", MySqlDbType.UInt16).Value = tempPhone.PhoneHasEquip
                                                                                                ? 1
                                                                                                : 0;
                iMySQLCommand.Parameters.Add("@phone_warrantyType", MySqlDbType.UInt16).Value =
                    int.Parse(tempPhone.PhoneWarrantyType);
                iMySQLCommand.Parameters.Add("@phone_warrantyDuration", MySqlDbType.UInt16).Value =
                    int.Parse(tempPhone.PhoneWarrantyDuration);
                iMySQLCommand.Parameters.Add("@phone_warrantyDate", MySqlDbType.VarChar, 20).Value =
                    tempPhone.PhoneWarrantyDate;
                iMySQLCommand.Parameters.Add("@phone_isDelete", MySqlDbType.UInt16).Value = tempPhone.PhoneIsDelete
                                                                                                ? 1
                                                                                                : 0;
                iMySQLCommand.Parameters.Add("@phone_supplier", MySqlDbType.VarChar, 50).Value =
                    tempPhone.phone_supplier;
                iMySQLCommand.Parameters.Add("@phone_equipPrice", MySqlDbType.UInt32).Value =
                    int.Parse(tempPhone.PhoneEquipPrice);

                iMySQLCommand.Parameters.Add("@phone_equipRealPrice", MySqlDbType.UInt32).Value =
                    int.Parse(tempPhone.PhoneEquipRealPrice);

                iMySQLCommand.Parameters.Add("@phone_isLegal", MySqlDbType.UInt16).Value = tempPhone.PhoneIsLegal
                                                                                               ? 1
                                                                                               : 0;
                iMySQLCommand.Parameters.Add("@phone_isHKLegal", MySqlDbType.UInt16).Value = tempPhone.PhoneIsHKLegal
                                                                                                 ? 1
                                                                                                 : 0;
                iMySQLCommand.Parameters.Add("@phone_isUnLegal", MySqlDbType.UInt16).Value = tempPhone.PhoneIsUnLegal
                                                                                                 ? 1
                                                                                                 : 0;
                iMySQLCommand.Parameters.Add("@phone_WarrantyPrice", MySqlDbType.UInt32).Value =
                    int.Parse(tempPhone.PhoneWarrantyPrice);
                iMySQLCommand.ExecuteNonQuery();

                iMySQLCommand.CommandText = iMySQLQuery;

                iMySQLCommand.Parameters.Add("@cuid", MySqlDbType.UInt32).Value = int.Parse(tempGoodAtrr) + 1;
                iMySQLCommand.Parameters.Add("@groupid", MySqlDbType.UInt16).Value = tempUser.GroupID;

                iMySQLCommand.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = tempUser.Email;
                iMySQLCommand.Parameters.Add("@phone", MySqlDbType.VarChar, 20).Value = tempUser.Phone;
                iMySQLCommand.Parameters.Add("@Telephone", MySqlDbType.VarChar, 20).Value = tempUser.Telephone;
                iMySQLCommand.Parameters.Add("@QQ", MySqlDbType.VarChar, 12).Value = tempUser.QQ;
                iMySQLCommand.Parameters.Add("@buyphones", MySqlDbType.Text).Value =
                    (int.Parse(tempPhoneID) + 1).ToString();

                iMySQLCommand.Parameters.Add("@userCName", MySqlDbType.VarChar, 20).Value = tempUser.UserCName;

                iMySQLCommand.Parameters.Add("@contectAddress", MySqlDbType.Text).Value = tempUser.ContectAddress;
                iMySQLCommand.Parameters.Add("@birthday", MySqlDbType.VarChar, 8).Value = tempUser.Birthday;
                iMySQLCommand.Parameters.Add("@LXcredit", MySqlDbType.VarChar, 11).Value = tempUser.LXCredit;
                iMySQLCommand.Parameters.Add("@haveBXK", MySqlDbType.UInt16).Value = tempUser.haveBXK;
                iMySQLCommand.Parameters.Add("@BXKid", MySqlDbType.VarChar, 10).Value = tempUser.BXKid;
                iMySQLCommand.Parameters.Add("@userTip", MySqlDbType.Text).Value = tempUser.UserTip;
                //userType
                iMySQLCommand.Parameters.Add("@userType", MySqlDbType.UInt16).Value = tempUser.userType;
                iMySQLCommand.ExecuteNonQuery();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        public struct LXPhones
        {
            public string PhoneBrand;
            public string PhoneCommision;
            public string PhoneDate;

            public string PhoneEquipPrice;
            public string PhoneEquipRealPrice;
            public bool PhoneHasEquip;

            public bool PhoneHasWarranty;
            public string PhoneID;
            public string PhoneIMEI;
            public bool PhoneIsDelete;
            public bool PhoneIsHKLegal;
            public bool PhoneIsLegal;
            public bool PhoneIsUnLegal;
            public string PhoneName;
            public int PhonePayment;
            public string PhonePrice;

            public string PhoneProfit;
            public string PhoneRealPrice;
            public string PhoneSeller;

            public string PhoneWarrantyDate;
            public string PhoneWarrantyDuration;
            public string PhoneWarrantyPrice;
            public string PhoneWarrantyType;
            public string phoneUnDebtPrice;
            public string phone_supplier;
        }

        #endregion

        #region 删除用户.OLD

        public ReturnResult DeleteUser(int UserID)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "DELETE FROM crm_users WHERE cuid = " + UserID;
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #endregion

        #region 手机销售操作

        #region 读取

        public LXSellPhone ReadPhoneByID(string iID)
        {
            var tempPayout = new LXSellPhone();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_phonesell WHERE phone_id='" +
                                   iID + "'";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    tempPayout.Phoneid = iMySQLReader.GetString(0);
                    tempPayout.PhoneDate = iMySQLReader.GetString(1);
                    tempPayout.PhoneBrandid = int.Parse(iMySQLReader.GetString(2));
                    tempPayout.PhoneName = ReadPhoneName(int.Parse(iMySQLReader.GetString(3)));
                    tempPayout.PhoneIMEI = iMySQLReader.GetString(4);
                    tempPayout.PhonePrice = double.Parse(iMySQLReader.GetString(5));
                    tempPayout.PhoneSeller = ReadSellerName(iMySQLReader.GetString(6));
                    tempPayout.PhoneRealprice = double.Parse(iMySQLReader.GetString(7));
                    tempPayout.PhoneSupplier = iMySQLReader.GetString(8);
                    tempPayout.PhoneScreenGuard = double.Parse(iMySQLReader.GetString(9));
                    tempPayout.PhoneBattery = double.Parse(iMySQLReader.GetString(10));
                    tempPayout.PhoneSDCARD = double.Parse(iMySQLReader.GetString(11));
                    tempPayout.PhoneShell = double.Parse(iMySQLReader.GetString(12));
                    tempPayout.PhoneCarCradle = double.Parse(iMySQLReader.GetString(13));
                    //tempPayout.PhoneBattery = double.Parse(iMySQLReader.GetString(14));
                    tempPayout.PhoneCarCharger = double.Parse(iMySQLReader.GetString(14));
                    tempPayout.PhoneHeadPhone = double.Parse(iMySQLReader.GetString(15));
                    tempPayout.PhoneOther = double.Parse(iMySQLReader.GetString(16));

                    tempPayout.PhoneWarranty = iMySQLReader.GetString(17) != "0";
                    tempPayout.PhoneWarrantyPrice = double.Parse(iMySQLReader.GetString(18));
                    tempPayout.PhoneWarrantyType = int.Parse(iMySQLReader.GetString(19));
                    tempPayout.PhoneWarrantyDate = iMySQLReader.GetString(20);
                    tempPayout.PhoneWarrantyDuration = int.Parse(iMySQLReader.GetString(21));
                    tempPayout.PhoneProfit = double.Parse(iMySQLReader.GetString(22));
                    tempPayout.PhoneCommision = double.Parse(iMySQLReader.GetString(23));
                    tempPayout.PhoneisLegal = iMySQLReader.GetString(24) != "0";
                    tempPayout.PhoneisHKLegal = iMySQLReader.GetString(25) != "0";
                    tempPayout.PhoneisUnLegal = iMySQLReader.GetString(26) != "0";

                    tempPayout.PhoneUserName = iMySQLReader.GetString(27);
                    tempPayout.PhoneUserType = int.Parse(iMySQLReader.GetString(28));
                    //
                    tempPayout.PhoneUseremail = iMySQLReader.GetString(29);
                    tempPayout.PhoneUsercellPhone = iMySQLReader.GetString(30);
                    tempPayout.PhoneUsercellPhoneback = iMySQLReader.GetString(31);
                    tempPayout.PhoneUserTelePhone = iMySQLReader.GetString(32);
                    tempPayout.PhoneUserQQ = iMySQLReader.GetString(33);
                    tempPayout.PhoneUserAddress = iMySQLReader.GetString(34);
                    tempPayout.PhoneUserBXKid = iMySQLReader.GetString(35);
                    tempPayout.PhoneUserTip = iMySQLReader.GetString(36);
                    tempPayout.PhonePayment = int.Parse(iMySQLReader.GetString(37));
                    tempPayout.PhoneisDelete = iMySQLReader.GetString(38) != "0";
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                tempPayout = default(LXSellPhone);
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempPayout;
        }

        public LXSellPhone[] ReadPhoneSell(string reqDate)
        {
            var tempPayout = new LXSellPhone[1000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_phonesell WHERE phone_date  LIKE '%" + reqDate +
                                   "%'  ORDER BY phone_date";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempPayout[i].Phoneid = iMySQLReader.GetString(0);
                    tempPayout[i].PhoneDate = iMySQLReader.GetString(1);
                    tempPayout[i].PhoneBrandid = int.Parse(iMySQLReader.GetString(2));
                    tempPayout[i].PhoneName = ReadPhoneName(int.Parse(iMySQLReader.GetString(3)));
                    tempPayout[i].PhoneIMEI = iMySQLReader.GetString(4);
                    tempPayout[i].PhonePrice = double.Parse(iMySQLReader.GetString(5));
                    tempPayout[i].PhoneSeller = ReadSellerName(iMySQLReader.GetString(6));
                    tempPayout[i].PhoneRealprice = double.Parse(iMySQLReader.GetString(7));
                    tempPayout[i].PhoneSupplier = iMySQLReader.GetString(8);
                    tempPayout[i].PhoneScreenGuard = double.Parse(iMySQLReader.GetString(9));
                    tempPayout[i].PhoneBattery = double.Parse(iMySQLReader.GetString(10));
                    tempPayout[i].PhoneSDCARD = double.Parse(iMySQLReader.GetString(11));
                    tempPayout[i].PhoneShell = double.Parse(iMySQLReader.GetString(12));
                    tempPayout[i].PhoneCarCradle = double.Parse(iMySQLReader.GetString(13));
                    //tempPayout[i].PhoneBattery = double.Parse(iMySQLReader.GetString(14));
                    tempPayout[i].PhoneCarCharger = double.Parse(iMySQLReader.GetString(14));
                    tempPayout[i].PhoneHeadPhone = double.Parse(iMySQLReader.GetString(15));
                    tempPayout[i].PhoneOther = double.Parse(iMySQLReader.GetString(16));

                    tempPayout[i].PhoneWarranty = iMySQLReader.GetString(17) != "0";
                    tempPayout[i].PhoneWarrantyPrice = double.Parse(iMySQLReader.GetString(18));
                    tempPayout[i].PhoneWarrantyType = int.Parse(iMySQLReader.GetString(19));
                    tempPayout[i].PhoneWarrantyDate = iMySQLReader.GetString(20);
                    tempPayout[i].PhoneWarrantyDuration = int.Parse(iMySQLReader.GetString(21));
                    tempPayout[i].PhoneProfit = double.Parse(iMySQLReader.GetString(22));
                    tempPayout[i].PhoneCommision = double.Parse(iMySQLReader.GetString(23));
                    tempPayout[i].PhoneisLegal = iMySQLReader.GetString(24) != "0";
                    tempPayout[i].PhoneisHKLegal = iMySQLReader.GetString(25) != "0";
                    tempPayout[i].PhoneisUnLegal = iMySQLReader.GetString(26) != "0";

                    tempPayout[i].PhoneUserName = iMySQLReader.GetString(27);
                    tempPayout[i].PhoneUserType = int.Parse(iMySQLReader.GetString(28));
                    //
                    tempPayout[i].PhoneUseremail = iMySQLReader.GetString(29);
                    tempPayout[i].PhoneUsercellPhone = iMySQLReader.GetString(30);
                    tempPayout[i].PhoneUsercellPhoneback = iMySQLReader.GetString(31);
                    tempPayout[i].PhoneUserTelePhone = iMySQLReader.GetString(32);
                    tempPayout[i].PhoneUserQQ = iMySQLReader.GetString(33);
                    tempPayout[i].PhoneUserAddress = iMySQLReader.GetString(34);
                    tempPayout[i].PhoneUserBXKid = iMySQLReader.GetString(35);
                    tempPayout[i].PhoneUserTip = iMySQLReader.GetString(36);
                    tempPayout[i].PhonePayment = int.Parse(iMySQLReader.GetString(37));
                    tempPayout[i].PhoneisDelete = iMySQLReader.GetString(38) != "0";
                    //tempPayout[i].PhoneProfit = double.Parse(iMySQLReader.GetString(39));
                    //tempPayout[i].PhoneCommision = double.Parse(iMySQLReader.GetString(40));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                tempPayout = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempPayout;
        }

        public LXSellPhone[] ReadPhoneSellByIMEI(string iIMEI)
        {
            var tempPayout = new LXSellPhone[100];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_phonesell WHERE phone_IMEI =" + iIMEI +
                                   " ORDER BY phone_date";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempPayout[i].Phoneid = iMySQLReader.GetString(0);
                    tempPayout[i].PhoneDate = iMySQLReader.GetString(1);
                    tempPayout[i].PhoneBrandid = int.Parse(iMySQLReader.GetString(2));
                    tempPayout[i].PhoneName = ReadPhoneName(int.Parse(iMySQLReader.GetString(3)));
                    tempPayout[i].PhoneIMEI = iMySQLReader.GetString(4);
                    tempPayout[i].PhonePrice = double.Parse(iMySQLReader.GetString(5));
                    tempPayout[i].PhoneSeller = ReadSellerName(iMySQLReader.GetString(6));
                    tempPayout[i].PhoneRealprice = double.Parse(iMySQLReader.GetString(7));
                    tempPayout[i].PhoneSupplier = iMySQLReader.GetString(8);
                    tempPayout[i].PhoneScreenGuard = double.Parse(iMySQLReader.GetString(9));
                    tempPayout[i].PhoneBattery = double.Parse(iMySQLReader.GetString(10));
                    tempPayout[i].PhoneSDCARD = double.Parse(iMySQLReader.GetString(11));
                    tempPayout[i].PhoneShell = double.Parse(iMySQLReader.GetString(12));
                    tempPayout[i].PhoneCarCradle = double.Parse(iMySQLReader.GetString(13));
                    //tempPayout[i].PhoneBattery = double.Parse(iMySQLReader.GetString(14));
                    tempPayout[i].PhoneCarCharger = double.Parse(iMySQLReader.GetString(14));
                    tempPayout[i].PhoneHeadPhone = double.Parse(iMySQLReader.GetString(15));
                    tempPayout[i].PhoneOther = double.Parse(iMySQLReader.GetString(16));

                    tempPayout[i].PhoneWarranty = iMySQLReader.GetString(17) != "0";
                    tempPayout[i].PhoneWarrantyPrice = double.Parse(iMySQLReader.GetString(18));
                    tempPayout[i].PhoneWarrantyType = int.Parse(iMySQLReader.GetString(19));
                    tempPayout[i].PhoneWarrantyDate = iMySQLReader.GetString(20);
                    tempPayout[i].PhoneWarrantyDuration = int.Parse(iMySQLReader.GetString(21));
                    tempPayout[i].PhoneProfit = double.Parse(iMySQLReader.GetString(22));
                    tempPayout[i].PhoneCommision = double.Parse(iMySQLReader.GetString(23));
                    tempPayout[i].PhoneisLegal = iMySQLReader.GetString(24) != "0";
                    tempPayout[i].PhoneisHKLegal = iMySQLReader.GetString(25) != "0";
                    tempPayout[i].PhoneisUnLegal = iMySQLReader.GetString(26) != "0";

                    tempPayout[i].PhoneUserName = iMySQLReader.GetString(27);
                    tempPayout[i].PhoneUserType = int.Parse(iMySQLReader.GetString(28));
                    //
                    tempPayout[i].PhoneUseremail = iMySQLReader.GetString(29);
                    tempPayout[i].PhoneUsercellPhone = iMySQLReader.GetString(30);
                    tempPayout[i].PhoneUsercellPhoneback = iMySQLReader.GetString(31);
                    tempPayout[i].PhoneUserTelePhone = iMySQLReader.GetString(32);
                    tempPayout[i].PhoneUserQQ = iMySQLReader.GetString(33);
                    tempPayout[i].PhoneUserAddress = iMySQLReader.GetString(34);
                    tempPayout[i].PhoneUserBXKid = iMySQLReader.GetString(35);
                    tempPayout[i].PhoneUserTip = iMySQLReader.GetString(36);
                    tempPayout[i].PhonePayment = int.Parse(iMySQLReader.GetString(37));
                    tempPayout[i].PhoneisDelete = iMySQLReader.GetString(38) != "0";

                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                tempPayout = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempPayout;
        }

        public LXSellPhone[] ReadPhoneSellByBXKid(string iBXKid)
        {
            var tempPayout = new LXSellPhone[100];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_phonesell WHERE phone_userBXKid =" + iBXKid +
                                   " ORDER BY phone_date";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempPayout[i].Phoneid = iMySQLReader.GetString(0);
                    tempPayout[i].PhoneDate = iMySQLReader.GetString(1);
                    tempPayout[i].PhoneBrandid = int.Parse(iMySQLReader.GetString(2));
                    tempPayout[i].PhoneName = ReadPhoneName(int.Parse(iMySQLReader.GetString(3)));
                    tempPayout[i].PhoneIMEI = iMySQLReader.GetString(4);
                    tempPayout[i].PhonePrice = double.Parse(iMySQLReader.GetString(5));
                    tempPayout[i].PhoneSeller = ReadSellerName(iMySQLReader.GetString(6));
                    tempPayout[i].PhoneRealprice = double.Parse(iMySQLReader.GetString(7));
                    tempPayout[i].PhoneSupplier = iMySQLReader.GetString(8);
                    tempPayout[i].PhoneScreenGuard = double.Parse(iMySQLReader.GetString(9));
                    tempPayout[i].PhoneBattery = double.Parse(iMySQLReader.GetString(10));
                    tempPayout[i].PhoneSDCARD = double.Parse(iMySQLReader.GetString(11));
                    tempPayout[i].PhoneShell = double.Parse(iMySQLReader.GetString(12));
                    tempPayout[i].PhoneCarCradle = double.Parse(iMySQLReader.GetString(13));
                    //tempPayout[i].PhoneBattery = double.Parse(iMySQLReader.GetString(14));
                    tempPayout[i].PhoneCarCharger = double.Parse(iMySQLReader.GetString(14));
                    tempPayout[i].PhoneHeadPhone = double.Parse(iMySQLReader.GetString(15));
                    tempPayout[i].PhoneOther = double.Parse(iMySQLReader.GetString(16));

                    tempPayout[i].PhoneWarranty = iMySQLReader.GetString(17) != "0";
                    tempPayout[i].PhoneWarrantyPrice = double.Parse(iMySQLReader.GetString(18));
                    tempPayout[i].PhoneWarrantyType = int.Parse(iMySQLReader.GetString(19));
                    tempPayout[i].PhoneWarrantyDate = iMySQLReader.GetString(20);
                    tempPayout[i].PhoneWarrantyDuration = int.Parse(iMySQLReader.GetString(21));
                    tempPayout[i].PhoneProfit = double.Parse(iMySQLReader.GetString(22));
                    tempPayout[i].PhoneCommision = double.Parse(iMySQLReader.GetString(23));
                    tempPayout[i].PhoneisLegal = iMySQLReader.GetString(24) != "0";
                    tempPayout[i].PhoneisHKLegal = iMySQLReader.GetString(25) != "0";
                    tempPayout[i].PhoneisUnLegal = iMySQLReader.GetString(26) != "0";

                    tempPayout[i].PhoneUserName = iMySQLReader.GetString(27);
                    tempPayout[i].PhoneUserType = int.Parse(iMySQLReader.GetString(28));
                    //
                    tempPayout[i].PhoneUseremail = iMySQLReader.GetString(29);
                    tempPayout[i].PhoneUsercellPhone = iMySQLReader.GetString(30);
                    tempPayout[i].PhoneUsercellPhoneback = iMySQLReader.GetString(31);
                    tempPayout[i].PhoneUserTelePhone = iMySQLReader.GetString(32);
                    tempPayout[i].PhoneUserQQ = iMySQLReader.GetString(33);
                    tempPayout[i].PhoneUserAddress = iMySQLReader.GetString(34);
                    tempPayout[i].PhoneUserBXKid = iMySQLReader.GetString(35);
                    tempPayout[i].PhoneUserTip = iMySQLReader.GetString(36);
                    tempPayout[i].PhonePayment = int.Parse(iMySQLReader.GetString(37));
                    tempPayout[i].PhoneisDelete = iMySQLReader.GetString(38) != "0";

                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                tempPayout = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempPayout;
        }

        public LXSellPhone[] ReadPhoneSell(string SellerName, string reqDate)
        {
            var tempPayout = new LXSellPhone[1000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_phonesell WHERE phone_date  LIKE '%" + reqDate +
                                   "%' " + "AND  phone_seller =" + ReadSellerID(SellerName) + " ORDER BY phone_date";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempPayout[i].Phoneid = iMySQLReader.GetString(0);
                    tempPayout[i].PhoneDate = iMySQLReader.GetString(1);
                    tempPayout[i].PhoneBrandid = int.Parse(iMySQLReader.GetString(2));
                    tempPayout[i].PhoneName = ReadPhoneName(int.Parse(iMySQLReader.GetString(3)));
                    tempPayout[i].PhoneIMEI = iMySQLReader.GetString(4);
                    tempPayout[i].PhonePrice = double.Parse(iMySQLReader.GetString(5));
                    tempPayout[i].PhoneSeller = ReadSellerName(iMySQLReader.GetString(6));
                    tempPayout[i].PhoneRealprice = double.Parse(iMySQLReader.GetString(7));
                    tempPayout[i].PhoneSupplier = iMySQLReader.GetString(8);
                    tempPayout[i].PhoneScreenGuard = double.Parse(iMySQLReader.GetString(9));
                    tempPayout[i].PhoneBattery = double.Parse(iMySQLReader.GetString(10));
                    tempPayout[i].PhoneSDCARD = double.Parse(iMySQLReader.GetString(11));
                    tempPayout[i].PhoneShell = double.Parse(iMySQLReader.GetString(12));
                    tempPayout[i].PhoneCarCradle = double.Parse(iMySQLReader.GetString(13));
                    //tempPayout[i].PhoneBattery = double.Parse(iMySQLReader.GetString(14));
                    tempPayout[i].PhoneCarCharger = double.Parse(iMySQLReader.GetString(14));
                    tempPayout[i].PhoneHeadPhone = double.Parse(iMySQLReader.GetString(15));
                    tempPayout[i].PhoneOther = double.Parse(iMySQLReader.GetString(16));

                    tempPayout[i].PhoneWarranty = iMySQLReader.GetString(17) != "0";
                    tempPayout[i].PhoneWarrantyPrice = double.Parse(iMySQLReader.GetString(18));
                    tempPayout[i].PhoneWarrantyType = int.Parse(iMySQLReader.GetString(19));
                    tempPayout[i].PhoneWarrantyDate = iMySQLReader.GetString(20);
                    tempPayout[i].PhoneWarrantyDuration = int.Parse(iMySQLReader.GetString(21));
                    tempPayout[i].PhoneProfit = double.Parse(iMySQLReader.GetString(22));
                    tempPayout[i].PhoneCommision = double.Parse(iMySQLReader.GetString(23));
                    tempPayout[i].PhoneisLegal = iMySQLReader.GetString(24) != "0";
                    tempPayout[i].PhoneisHKLegal = iMySQLReader.GetString(25) != "0";
                    tempPayout[i].PhoneisUnLegal = iMySQLReader.GetString(26) != "0";

                    tempPayout[i].PhoneUserName = iMySQLReader.GetString(27);
                    tempPayout[i].PhoneUserType = int.Parse(iMySQLReader.GetString(28));
                    //
                    tempPayout[i].PhoneUseremail = iMySQLReader.GetString(29);
                    tempPayout[i].PhoneUsercellPhone = iMySQLReader.GetString(30);
                    tempPayout[i].PhoneUsercellPhoneback = iMySQLReader.GetString(31);
                    tempPayout[i].PhoneUserTelePhone = iMySQLReader.GetString(32);
                    tempPayout[i].PhoneUserQQ = iMySQLReader.GetString(33);
                    tempPayout[i].PhoneUserAddress = iMySQLReader.GetString(34);
                    tempPayout[i].PhoneUserBXKid = iMySQLReader.GetString(35);
                    tempPayout[i].PhoneUserTip = iMySQLReader.GetString(36);
                    tempPayout[i].PhonePayment = int.Parse(iMySQLReader.GetString(37));
                    tempPayout[i].PhoneisDelete = iMySQLReader.GetString(38) != "0";
                    //tempPayout[i].PhoneProfit = double.Parse(iMySQLReader.GetString(39));
                    //tempPayout[i].PhoneCommision = double.Parse(iMySQLReader.GetString(40));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                tempPayout = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempPayout;
        }

        #endregion

        #region 增加

        public ReturnResult AddNewSell(LXSellPhone tempPhone)
        {
            string[] iPosition = SellersPosition();
            var iResult = new ReturnResult {isSuccess = false};
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            const string iMySQLQueryCheck = "SELECT MAX(phone_id) FROM crm_phonesell";
            const string iMySQLQuery =
                "insert into crm_phonesell(phone_id,phone_date,phone_brand_id,phone_name,phone_IMEI,phone_price,phone_seller,phone_realprice,phone_supplier,phone_ScreenGuard,phone_Battery,phone_SDCARD,phone_Shell,phone_CarCradle,phone_CarCharger,phone_headphone,phone_other,phone_warranty,phone_WarrantyPrice,phone_warrantyType,phone_warrantyDate,phone_warrantyDuration,phone_profit,phone_commision,phone_isLegal,phone_isHKLegal,phone_isUnLegal,phone_userName,phone_userType,phone_useremail,phone_usercellphone,phone_usercellphoneback,phone_userTelephone,phone_userQQ,phone_userAddress,phone_userBXKid,phone_userTip,phone_payment,phone_isDelete) values(@phone_id,@phone_date,@phone_brand_id,@phone_name,@phone_IMEI,@phone_price,@phone_seller,@phone_realprice,@phone_supplier,@phone_ScreenGuard,@phone_Battery,@phone_SDCARD,@phone_Shell,@phone_CarCradle,@phone_CarCharger,@phone_headphone,@phone_other,@phone_warranty,@phone_WarrantyPrice,@phone_warrantyType,@phone_warrantyDate,@phone_warrantyDuration,@phone_profit,@phone_commision,@phone_isLegal,@phone_isHKLegal,@phone_isUnLegal,@phone_userName,@phone_userType,@phone_useremail,@phone_usercellphone,@phone_usercellphoneback,@phone_userTelephone,@phone_userQQ,@phone_userAddress,@phone_userBXKid,@phone_userTip,@phone_payment,@phone_isDelete)";

            try
            {
                var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                iMySQLconn.Open();

                MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                string tempGoodAtrr = "9999";
                while (iMySQLReaderAttr.Read())
                {
                    try
                    {
                        tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                    }
                    catch (Exception)
                    {
                        tempGoodAtrr = "0";
                    }
                }
                iMySQLReaderAttr.Close();

                iMySQLCommand.CommandText = iMySQLQuery;

                double Profit = Math.Round(tempPhone.PhonePrice - tempPhone.PhoneRealprice, 2);
                Profit = Math.Round(Profit - tempPhone.PhoneScreenGuard, 2);
                Profit = Math.Round(Profit -
                                    tempPhone.PhoneBattery, 2);
                Profit = Math.Round(Profit - tempPhone.PhoneSDCARD, 2);
                Profit = Math.Round(Profit - tempPhone.PhoneShell, 2);
                Profit = Math.Round(Profit -
                                    tempPhone.PhoneCarCharger, 2);
                Profit = Math.Round(Profit - tempPhone.PhoneHeadPhone, 2);
                Profit = Math.Round(Profit - tempPhone.PhoneCarCradle, 2);
                Profit = Math.Round(Profit -
                                    tempPhone.PhoneOther, 2);
                int Commision;
                iMySQLCommand.Parameters.Add("@phone_id", MySqlDbType.UInt32).Value = int.Parse(tempGoodAtrr) + 1;
                iMySQLCommand.Parameters.Add("@phone_date", MySqlDbType.VarChar, 8).Value = tempPhone.PhoneDate;
                iMySQLCommand.Parameters.Add("@phone_brand_id", MySqlDbType.UInt16).Value = tempPhone.PhoneBrandid;
                iMySQLCommand.Parameters.Add("@phone_name", MySqlDbType.UInt16).Value = ReadPhoneID(tempPhone.PhoneName);
                iMySQLCommand.Parameters.Add("@phone_IMEI", MySqlDbType.VarChar, 20).Value = tempPhone.PhoneIMEI;

                iMySQLCommand.Parameters.Add("@phone_price", MySqlDbType.VarChar, 10).Value = tempPhone.PhonePrice;
                iMySQLCommand.Parameters.Add("@phone_seller", MySqlDbType.VarChar, 100).Value =
                    ReadSellerID(tempPhone.PhoneSeller);
                iMySQLCommand.Parameters.Add("@phone_realprice", MySqlDbType.VarChar, 10).Value =
                    tempPhone.PhoneRealprice;
                iMySQLCommand.Parameters.Add("@phone_supplier", MySqlDbType.VarChar, 255).Value =
                    tempPhone.PhoneSupplier;
                iMySQLCommand.Parameters.Add("@phone_ScreenGuard", MySqlDbType.VarChar, 255).Value =
                    tempPhone.PhoneScreenGuard;

                iMySQLCommand.Parameters.Add("@phone_Battery", MySqlDbType.VarChar, 255).Value = tempPhone.PhoneBattery;
                iMySQLCommand.Parameters.Add("@phone_SDCARD", MySqlDbType.VarChar, 255).Value = tempPhone.PhoneSDCARD;
                iMySQLCommand.Parameters.Add("@phone_Shell", MySqlDbType.VarChar, 255).Value = tempPhone.PhoneShell;
                iMySQLCommand.Parameters.Add("@phone_CarCradle", MySqlDbType.VarChar, 255).Value =
                    tempPhone.PhoneCarCradle;
                iMySQLCommand.Parameters.Add("@phone_CarCharger", MySqlDbType.VarChar, 255).Value =
                    tempPhone.PhoneCarCharger;

                iMySQLCommand.Parameters.Add("@phone_headphone", MySqlDbType.VarChar, 255).Value =
                    tempPhone.PhoneHeadPhone;
                iMySQLCommand.Parameters.Add("@phone_other", MySqlDbType.VarChar, 255).Value = tempPhone.PhoneOther;
                iMySQLCommand.Parameters.Add("@phone_warranty", MySqlDbType.UInt16).Value = tempPhone.PhoneWarranty
                                                                                                ? 1
                                                                                                : 0;
                iMySQLCommand.Parameters.Add("@phone_WarrantyPrice", MySqlDbType.VarChar, 6).Value =
                    tempPhone.PhoneWarrantyPrice;
                iMySQLCommand.Parameters.Add("@phone_warrantyType", MySqlDbType.UInt16).Value =
                    tempPhone.PhoneWarrantyType;

                iMySQLCommand.Parameters.Add("@phone_warrantyDate", MySqlDbType.VarChar, 8).Value =
                    tempPhone.PhoneWarrantyDate;
                iMySQLCommand.Parameters.Add("@phone_warrantyDuration", MySqlDbType.UInt16).Value =
                    tempPhone.PhoneWarrantyDuration;

                iMySQLCommand.Parameters.Add("@phone_profit", MySqlDbType.VarChar, 6).Value = Profit;

                /*100 10
                 * 200 20
                 * 
                 * 500 100
                */
                if (Profit < 100)
                {
                    Commision = 0;
                }
                else if (100 <= Profit && Profit < 500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0");
                }
                else if (500 <= Profit && Profit < 1000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 50;
                }
                else if (1000 <= Profit && Profit < 1500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 100;
                }
                else if (1500 <= Profit && Profit < 2000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 15150;
                }
                else
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 200;
                }

                if (ReadSellerPosition(tempPhone.PhoneSeller) != "店长" &&
                    ReadSellerPosition(tempPhone.PhoneSeller) != "销售")
                {
                    iMySQLCommand.Parameters.Add("@phone_commision", MySqlDbType.VarChar, 6).Value = 0;
                }
                else
                {
                    iMySQLCommand.Parameters.Add("@phone_commision", MySqlDbType.VarChar, 6).Value = Commision;
                }

                iMySQLCommand.Parameters.Add("@phone_isLegal", MySqlDbType.UInt16).Value = tempPhone.PhoneisLegal
                                                                                               ? 1
                                                                                               : 0;
                iMySQLCommand.Parameters.Add("@phone_isHKLegal", MySqlDbType.UInt16).Value = tempPhone.PhoneisHKLegal
                                                                                                 ? 1
                                                                                                 : 0;
                iMySQLCommand.Parameters.Add("@phone_isUnLegal", MySqlDbType.UInt16).Value = tempPhone.PhoneisUnLegal
                                                                                                 ? 1
                                                                                                 : 0;
                iMySQLCommand.Parameters.Add("@phone_userName", MySqlDbType.VarChar, 8).Value = tempPhone.PhoneUserName;

                iMySQLCommand.Parameters.Add("@phone_userType", MySqlDbType.UInt16).Value = tempPhone.PhoneUserType;
                iMySQLCommand.Parameters.Add("@phone_useremail", MySqlDbType.VarChar, 50).Value =
                    tempPhone.PhoneUseremail;
                iMySQLCommand.Parameters.Add("@phone_usercellphone", MySqlDbType.VarChar, 12).Value =
                    tempPhone.PhoneUsercellPhone;
                iMySQLCommand.Parameters.Add("@phone_usercellphoneback", MySqlDbType.VarChar, 12).Value =
                    tempPhone.PhoneUsercellPhoneback;
                iMySQLCommand.Parameters.Add("@phone_userTelephone", MySqlDbType.VarChar, 25).Value =
                    tempPhone.PhoneUserTelePhone;
                iMySQLCommand.Parameters.Add("@phone_userQQ", MySqlDbType.VarChar, 12).Value = tempPhone.PhoneUserQQ;
                iMySQLCommand.Parameters.Add("@phone_userAddress", MySqlDbType.VarChar, 100).Value =
                    tempPhone.PhoneUserAddress;
                iMySQLCommand.Parameters.Add("@phone_userBXKid", MySqlDbType.VarChar, 10).Value =
                    tempPhone.PhoneUserBXKid;
                iMySQLCommand.Parameters.Add("@phone_userTip", MySqlDbType.VarChar, 255).Value = tempPhone.PhoneUserTip;

                iMySQLCommand.Parameters.Add("@phone_payment", MySqlDbType.UInt16).Value = tempPhone.PhonePayment;
                iMySQLCommand.Parameters.Add("@phone_isDelete", MySqlDbType.UInt16).Value = tempPhone.PhoneisDelete
                                                                                                ? 1
                                                                                                : 0;

                iMySQLCommand.ExecuteNonQuery();
                iResult.PhoneID = int.Parse(tempGoodAtrr) + 1;
                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #region 修改

        public ReturnResult UpdatePhoneWarrantyByID(LXSellPhone tempPhone)
        {
            var iResult = new ReturnResult();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery =
                "UPDATE crm_phonesell SET phone_warranty = @phone_warranty,  phone_warrantyType = @phone_warrantyType, phone_warrantyDate = @phone_warrantyDate, phone_warrantyDuration=@phone_warrantyDuration WHERE phone_id = '" +
                tempPhone.Phoneid + "'";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@phone_warranty", MySqlDbType.UInt16).Value = tempPhone.PhoneWarranty
                                                                                                ? 1
                                                                                                : 0;
                iMySQLCommand.Parameters.Add("@phone_warrantyType", MySqlDbType.UInt16).Value =
                    tempPhone.PhoneWarrantyType;
                iMySQLCommand.Parameters.Add("@phone_warrantyDate", MySqlDbType.VarChar, 8).Value =
                    tempPhone.PhoneWarrantyDate;
                iMySQLCommand.Parameters.Add("@phone_warrantyDuration", MySqlDbType.UInt16).Value =
                    tempPhone.PhoneWarrantyDuration;
                /*
                 iMySQLCommand.Parameters.Add("@phone_warranty", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_warrantyType", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_warrantyDuration", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_warrantyDate", MySqlDbType.VarChar, 20);
                 */

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        public ReturnResult EditPhoneSell(LXSellPhone tempPhone)
        {
            var iReturn = new ReturnResult {isSuccess = false};
            string[] iPosition = SellersPosition();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string mySelectQuery =
                "UPDATE crm_phonesell SET phone_date=@phone_date,phone_brand_id=@phone_brand_id,phone_name=@phone_name,phone_IMEI=@phone_IMEI,phone_price=@phone_price,phone_seller=@phone_seller,phone_realprice=@phone_realprice,phone_supplier=@phone_supplier,phone_ScreenGuard=@phone_ScreenGuard,phone_Battery=@phone_Battery,phone_SDCARD=@phone_SDCARD,phone_Shell=@phone_Shell,phone_CarCradle=@phone_CarCradle,phone_CarCharger=@phone_CarCharger,phone_headphone=@phone_headphone,phone_other=@phone_other,phone_warranty=@phone_warranty,phone_WarrantyPrice=@phone_WarrantyPrice,phone_warrantyType=@phone_warrantyType,phone_warrantyDate=@phone_warrantyDate,phone_warrantyDuration=@phone_warrantyDuration,phone_profit=@phone_profit,phone_commision=@phone_commision,phone_isLegal=@phone_isLegal,phone_isHKLegal=@phone_isHKLegal,phone_isUnLegal=@phone_isUnLegal,phone_userName=@phone_userName,phone_userType=@phone_userType,phone_useremail=@phone_useremail,phone_usercellphone=@phone_usercellphone,phone_usercellphoneback=@phone_usercellphoneback,phone_userTelephone=@phone_userTelephone,phone_userQQ=@phone_userQQ,phone_userAddress=@phone_userAddress,phone_userBXKid=@phone_userBXKid,phone_userTip=@phone_userTip,phone_payment=@phone_payment,phone_isDelete=@phone_isDelete WHERE phone_id = " +
                tempPhone.Phoneid;


            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                //iMySQLCommand.Parameters.Add("@phone_id", MySqlDbType.UInt32);
                iMySQLCommand.Parameters.Add("@phone_date", MySqlDbType.VarChar, 8);
                iMySQLCommand.Parameters.Add("@phone_brand_id", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_name", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_IMEI", MySqlDbType.VarChar, 20);

                iMySQLCommand.Parameters.Add("@phone_price", MySqlDbType.VarChar, 6);
                iMySQLCommand.Parameters.Add("@phone_seller", MySqlDbType.VarChar, 100);
                iMySQLCommand.Parameters.Add("@phone_realprice", MySqlDbType.VarChar, 6);
                iMySQLCommand.Parameters.Add("@phone_supplier", MySqlDbType.VarChar, 255);
                iMySQLCommand.Parameters.Add("@phone_ScreenGuard", MySqlDbType.VarChar, 255);
                //
                iMySQLCommand.Parameters.Add("@phone_Battery", MySqlDbType.VarChar, 255);
                iMySQLCommand.Parameters.Add("@phone_SDCARD", MySqlDbType.VarChar, 255);
                iMySQLCommand.Parameters.Add("@phone_Shell", MySqlDbType.VarChar, 255);
                iMySQLCommand.Parameters.Add("@phone_CarCradle", MySqlDbType.VarChar, 255);
                iMySQLCommand.Parameters.Add("@phone_CarCharger", MySqlDbType.VarChar, 255);

                iMySQLCommand.Parameters.Add("@phone_headphone", MySqlDbType.VarChar, 255);
                iMySQLCommand.Parameters.Add("@phone_other", MySqlDbType.VarChar, 255);
                iMySQLCommand.Parameters.Add("@phone_warranty", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_WarrantyPrice", MySqlDbType.VarChar, 6);
                iMySQLCommand.Parameters.Add("@phone_warrantyType", MySqlDbType.UInt16);
                //
                iMySQLCommand.Parameters.Add("@phone_warrantyDate", MySqlDbType.VarChar, 8);
                iMySQLCommand.Parameters.Add("@phone_warrantyDuration", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_profit", MySqlDbType.VarChar, 6);
                iMySQLCommand.Parameters.Add("@phone_commision", MySqlDbType.VarChar, 6);
                iMySQLCommand.Parameters.Add("@phone_isLegal", MySqlDbType.UInt16);

                iMySQLCommand.Parameters.Add("@phone_isHKLegal", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_isUnLegal", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_userName", MySqlDbType.VarChar, 8);
                iMySQLCommand.Parameters.Add("@phone_userType", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_useremail", MySqlDbType.VarChar, 50);
                //
                iMySQLCommand.Parameters.Add("@phone_usercellphone", MySqlDbType.VarChar, 12);
                iMySQLCommand.Parameters.Add("@phone_usercellphoneback", MySqlDbType.VarChar, 12);
                iMySQLCommand.Parameters.Add("@phone_userTelephone", MySqlDbType.VarChar, 25);
                iMySQLCommand.Parameters.Add("@phone_userQQ", MySqlDbType.VarChar, 12);
                iMySQLCommand.Parameters.Add("@phone_userAddress", MySqlDbType.VarChar, 100);

                iMySQLCommand.Parameters.Add("@phone_userBXKid", MySqlDbType.VarChar, 10);
                iMySQLCommand.Parameters.Add("@phone_userTip", MySqlDbType.VarChar, 255);
                iMySQLCommand.Parameters.Add("@phone_payment", MySqlDbType.UInt16);
                iMySQLCommand.Parameters.Add("@phone_isDelete", MySqlDbType.UInt16);


                double Profit = Math.Round(tempPhone.PhonePrice - tempPhone.PhoneRealprice, 2);
                Profit = Math.Round(Profit - tempPhone.PhoneScreenGuard, 2);
                Profit = Math.Round(Profit -
                                    tempPhone.PhoneBattery, 2);
                Profit = Math.Round(Profit - tempPhone.PhoneSDCARD, 2);
                Profit = Math.Round(Profit - tempPhone.PhoneShell, 2);
                Profit = Math.Round(Profit -
                                    tempPhone.PhoneCarCharger, 2);
                Profit = Math.Round(Profit - tempPhone.PhoneHeadPhone, 2);
                Profit = Math.Round(Profit - tempPhone.PhoneCarCradle, 2);
                Profit = Math.Round(Profit -
                                    tempPhone.PhoneOther, 2);
                int Commision;

                //iMySQLCommand.Parameters["@phone_id"].Value = tempPhone.Phoneid;
                iMySQLCommand.Parameters["@phone_date"].Value = tempPhone.PhoneDate;
                iMySQLCommand.Parameters["@phone_brand_id"].Value = tempPhone.PhoneBrandid;
                iMySQLCommand.Parameters["@phone_name"].Value = ReadPhoneID(tempPhone.PhoneName);
                iMySQLCommand.Parameters["@phone_IMEI"].Value = tempPhone.PhoneIMEI;
                iMySQLCommand.Parameters["@phone_price"].Value = tempPhone.PhonePrice;
                iMySQLCommand.Parameters["@phone_seller"].Value = ReadSellerID(tempPhone.PhoneSeller);
                iMySQLCommand.Parameters["@phone_realprice"].Value = tempPhone.PhoneRealprice;
                iMySQLCommand.Parameters["@phone_supplier"].Value = tempPhone.PhoneSupplier;


                iMySQLCommand.Parameters["@phone_ScreenGuard"].Value = tempPhone.PhoneScreenGuard;
                iMySQLCommand.Parameters["@phone_Battery"].Value = tempPhone.PhoneBattery;
                iMySQLCommand.Parameters["@phone_SDCARD"].Value = tempPhone.PhoneSDCARD;
                iMySQLCommand.Parameters["@phone_Shell"].Value =
                    tempPhone.PhoneShell;
                iMySQLCommand.Parameters["@phone_CarCradle"].Value = tempPhone.PhoneCarCradle;
                iMySQLCommand.Parameters["@phone_CarCharger"].Value = tempPhone.PhoneCarCharger;
                iMySQLCommand.Parameters["@phone_headphone"].Value = tempPhone.PhoneHeadPhone;
                iMySQLCommand.Parameters["@phone_other"].Value = tempPhone.PhoneOther;
                iMySQLCommand.Parameters["@phone_warranty"].Value = tempPhone.PhoneWarranty
                                                                        ? 1
                                                                        : 0;
                iMySQLCommand.Parameters["@phone_WarrantyPrice"].Value = tempPhone.PhoneWarrantyPrice;
                iMySQLCommand.Parameters["@phone_warrantyType"].Value = tempPhone.PhoneWarrantyType;
                iMySQLCommand.Parameters["@phone_warrantyDate"].Value = tempPhone.PhoneWarrantyDate;
                iMySQLCommand.Parameters["@phone_warrantyDuration"].Value = tempPhone.PhoneWarrantyDuration;
                iMySQLCommand.Parameters["@phone_profit"].Value = Profit;

                /*100 10
                 * 200 20
                 * 
                 * 500 100
                */
                if (Profit < 100)
                {
                    Commision = 0;
                }
                else if (100 <= Profit && Profit < 500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0");
                }
                else if (500 <= Profit && Profit < 1000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 50;
                }
                else if (1000 <= Profit && Profit < 1500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 100;
                }
                else if (1500 <= Profit && Profit < 2000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 150;
                }
                else
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 200;
                }

                if (ReadSellerPosition(tempPhone.PhoneSeller) != "店长" &&
                    ReadSellerPosition(tempPhone.PhoneSeller) != "销售")
                {
                    iMySQLCommand.Parameters["@phone_commision"].Value = 0;
                }
                else
                {
                    iMySQLCommand.Parameters["@phone_commision"].Value = Commision;
                }


                iMySQLCommand.Parameters["@phone_isLegal"].Value = tempPhone.PhoneisLegal
                                                                       ? 1
                                                                       : 0;
                iMySQLCommand.Parameters["@phone_isHKLegal"].Value = tempPhone.PhoneisHKLegal
                                                                         ? 1
                                                                         : 0;
                iMySQLCommand.Parameters["@phone_isUnLegal"].Value = tempPhone.PhoneisUnLegal
                                                                         ? 1
                                                                         : 0;
                iMySQLCommand.Parameters["@phone_userName"].Value = tempPhone.PhoneUserName;

                iMySQLCommand.Parameters["@phone_userType"].Value = tempPhone.PhoneUserType;
                iMySQLCommand.Parameters["@phone_useremail"].Value = tempPhone.PhoneUseremail;
                iMySQLCommand.Parameters["@phone_usercellphone"].Value = tempPhone.PhoneUsercellPhone;
                iMySQLCommand.Parameters["@phone_usercellphoneback"].Value = tempPhone.PhoneUsercellPhoneback;
                iMySQLCommand.Parameters["@phone_userTelephone"].Value = tempPhone.PhoneUserTelePhone;
                iMySQLCommand.Parameters["@phone_userQQ"].Value = tempPhone.PhoneUserQQ;

                iMySQLCommand.Parameters["@phone_userAddress"].Value = tempPhone.PhoneUserAddress;
                iMySQLCommand.Parameters["@phone_userBXKid"].Value = tempPhone.PhoneUserBXKid;
                iMySQLCommand.Parameters["@phone_userTip"].Value = tempPhone.PhoneUserTip;
                iMySQLCommand.Parameters["@phone_payment"].Value = tempPhone.PhonePayment;
                iMySQLCommand.Parameters["@phone_isDelete"].Value = tempPhone.PhoneisDelete
                                                                        ? 1
                                                                        : 0;
                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                iReturn.ErrDesc = e.Message;
            }

            return iReturn;
        }

        #endregion

        #region 删除

        public ReturnResult DeletePhoneSell(int PhoneID)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "DELETE FROM crm_phonesell WHERE phone_id = " + PhoneID;
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #endregion

        #region 支出操作

        #region 读取支出

        public Payout[] ReadPayout(string reqDate)
        {
            var tempPayout = new Payout[500];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_payout WHERE payout_time  LIKE '%" + reqDate +
                                   "%'  ORDER BY payout_time";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempPayout[i].PayoutName = iMySQLReader.GetString(0);
                    tempPayout[i].PayoutPrice = iMySQLReader.GetString(1);
                    tempPayout[i].PayoutDate = iMySQLReader.GetString(2);
                    tempPayout[i].PayoutType = iMySQLReader.GetString(3);
                    tempPayout[i].PayoutBackup = iMySQLReader.GetString(4);
                    tempPayout[i].PayoutID = int.Parse(iMySQLReader.GetString(5));
                    tempPayout[i].PayoutInCase = iMySQLReader.GetString(6) != "0";
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempPayout = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempPayout;
        }

        public Payout ReadPayoutByID(string iID)
        {
            var tempPayout = new Payout();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_payout WHERE payout_id  = " + iID;
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();

                while (iMySQLReader.Read())
                {
                    tempPayout.PayoutName = iMySQLReader.GetString(0);
                    tempPayout.PayoutPrice = iMySQLReader.GetString(1);
                    tempPayout.PayoutDate = iMySQLReader.GetString(2);
                    tempPayout.PayoutType = iMySQLReader.GetString(3);
                    tempPayout.PayoutBackup = iMySQLReader.GetString(4);
                    tempPayout.PayoutID = int.Parse(iMySQLReader.GetString(5));
                    tempPayout.PayoutInCase = iMySQLReader.GetString(6) != "0";
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempPayout = default(Payout);
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempPayout;
        }

        public struct Payout
        {
            public string PayoutBackup;
            public string PayoutDate;
            public int PayoutID;
            public bool PayoutInCase;
            public string PayoutName;
            public string PayoutPrice;
            public string PayoutType;
        }

        #endregion

        #region 修改支出

        public ReturnResult EditPayout(Payout iPayout)
        {
            var iReturn = new ReturnResult {isSuccess = false};
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string myUpdateQuery =
                "UPDATE crm_payout SET  payout_name = @payout_name, payout_price = @payout_price , payout_time = @payout_time , payout_type = @payout_type, payout_backup = @payout_backup, payout_incash = @payout_incash WHERE payout_id = " +
                iPayout.PayoutID;

            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@payout_name", MySqlDbType.VarChar, 255).Value = iPayout.PayoutName;
                iMySQLCommand.Parameters.Add("@payout_price", MySqlDbType.VarChar, 10).Value = iPayout.PayoutPrice;
                iMySQLCommand.Parameters.Add("@payout_time", MySqlDbType.VarChar, 20).Value = iPayout.PayoutDate;
                iMySQLCommand.Parameters.Add("@payout_type", MySqlDbType.UInt16).Value = int.Parse(iPayout.PayoutType);
                iMySQLCommand.Parameters.Add("@payout_backup", MySqlDbType.VarChar, 255).Value = iPayout.PayoutBackup;
                iMySQLCommand.Parameters.Add("@payout_incash", MySqlDbType.UInt16).Value = iPayout.PayoutInCase ? 1 : 0;

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                Console.Write(e.Message);
                iReturn.ErrDesc = e.Message;
            }

            return iReturn;
        }

        #endregion

        #region 添加支出

        public ReturnResult AddPayout(Payout iPayout)
        {
            var iResult = new ReturnResult();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            const string iMySQLQueryCheck = "SELECT MAX(payout_id) FROM crm_payout";
            const string iMySQLQuery =
                "insert into crm_payout(payout_name,payout_price,payout_time,payout_type,payout_backup,payout_id,payout_incash) values(@payout_name,@payout_price,@payout_time,@payout_type,@payout_backup,@payout_id,@payout_incash)";

            try
            {
                var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                iMySQLconn.Open();

                MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                string tempGoodAtrr = "9999";
                while (iMySQLReaderAttr.Read())
                {
                    try
                    {
                        tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                    }
                    catch (Exception)
                    {
                        tempGoodAtrr = "0";
                    }
                }
                iMySQLReaderAttr.Close();
                iMySQLCommand.CommandText = iMySQLQuery;

                iMySQLCommand.Parameters.Add("@payout_name", MySqlDbType.VarChar, 255).Value = iPayout.PayoutName;
                iMySQLCommand.Parameters.Add("@payout_price", MySqlDbType.VarChar, 10).Value = iPayout.PayoutPrice;
                iMySQLCommand.Parameters.Add("@payout_time", MySqlDbType.VarChar, 20).Value = iPayout.PayoutDate;
                iMySQLCommand.Parameters.Add("@payout_type", MySqlDbType.UInt16).Value = int.Parse(iPayout.PayoutType);
                iMySQLCommand.Parameters.Add("@payout_backup", MySqlDbType.VarChar, 255).Value = iPayout.PayoutBackup;
                iMySQLCommand.Parameters.Add("@payout_id", MySqlDbType.UInt16).Value = int.Parse(tempGoodAtrr) + 1;
                iMySQLCommand.Parameters.Add("@payout_incash", MySqlDbType.UInt16).Value = iPayout.PayoutInCase ? 1 : 0;

                iMySQLCommand.ExecuteNonQuery();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.ErrDesc = e.Message;
                iResult.isSuccess = false;
            }

            return iResult;
        }

        #endregion

        #region 删除支出

        public ReturnResult DeletePayout(int id)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "DELETE FROM crm_payout WHERE payout_id = " + id;
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.ExecuteNonQuery();


                iMySQLconn.Close();


                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #endregion

        #region 客户欠款操作

        public struct LXCustomDebt
        {
            public int DebtBinID;
            public string DebtCustom;
            public int DebtCustomID;
            public string DebtDate;
            public string DebtDetail;
            public int DebtEquipID;
            public string DebtFixBackup;
            public string DebtFixDate;
            public int DebtFixType;
            public int DebtID;
            public int DebtPhoneID;
            //public string DebtBackup;
            public double DebtPrice;
            public int DebtType;
            public double DebtUnFixPrice;
            public bool DebtisFix;
            public bool DebtisInCircle;
        }

        #region 读取

        public LXCustomDebt[] ReadCustomDebt(string reqDate)
        {
            var tempCDebt = new LXCustomDebt[1000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_customdebt WHERE DebtDate LIKE '%" + reqDate +
                                   "%' ORDER BY DebtDate";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempCDebt[i].DebtID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt[i].DebtDate = iMySQLReader.GetString(1);
                    tempCDebt[i].DebtCustom = iMySQLReader.GetString(2);
                    tempCDebt[i].DebtDetail = iMySQLReader.GetString(3);
                    tempCDebt[i].DebtPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt[i].DebtType = int.Parse(iMySQLReader.GetString(5));
                    try
                    {
                        tempCDebt[i].DebtPhoneID = int.Parse(iMySQLReader.GetString(6));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtPhoneID = 0;
                    }
                    try
                    {
                        tempCDebt[i].DebtCustomID = int.Parse(iMySQLReader.GetString(7));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtCustomID = 0;
                    }

                    tempCDebt[i].DebtisFix = iMySQLReader.GetString(8) == "1";
                    try
                    {
                        tempCDebt[i].DebtFixDate = iMySQLReader.GetString(9);
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtFixDate = "";
                    }

                    try
                    {
                        tempCDebt[i].DebtUnFixPrice = double.Parse(iMySQLReader.GetString(10));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtUnFixPrice = double.Parse(iMySQLReader.GetString(4));
                    }

                    try
                    {
                        tempCDebt[i].DebtFixType = int.Parse(iMySQLReader.GetString(11));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtFixType = 0;
                    }

                    try
                    {
                        tempCDebt[i].DebtFixBackup = iMySQLReader.GetString(12);
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtFixBackup = "";
                    }
                    tempCDebt[i].DebtisInCircle = iMySQLReader.GetString(13) == "1";
                    try
                    {
                        tempCDebt[i].DebtEquipID = int.Parse(iMySQLReader.GetString(14));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtEquipID = 0;
                    }
                    try
                    {
                        tempCDebt[i].DebtBinID = int.Parse(iMySQLReader.GetString(15));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtBinID = 0;
                    }
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        public LXCustomDebt[] ReadCustomDebtByName(string iName)
        {
            var tempCDebt = new LXCustomDebt[1000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = @"SELECT * FROM crm_customdebt WHERE DebtCustom LIKE ""%" + iName +
                                   @"%"" ORDER BY DebtDate";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempCDebt[i].DebtID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt[i].DebtDate = iMySQLReader.GetString(1);
                    tempCDebt[i].DebtCustom = iMySQLReader.GetString(2);
                    tempCDebt[i].DebtDetail = iMySQLReader.GetString(3);
                    tempCDebt[i].DebtPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt[i].DebtType = int.Parse(iMySQLReader.GetString(5));
                    try
                    {
                        tempCDebt[i].DebtPhoneID = int.Parse(iMySQLReader.GetString(6));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtPhoneID = 0;
                    }
                    try
                    {
                        tempCDebt[i].DebtCustomID = int.Parse(iMySQLReader.GetString(7));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtCustomID = 0;
                    }

                    tempCDebt[i].DebtisFix = iMySQLReader.GetString(8) == "1";
                    try
                    {
                        tempCDebt[i].DebtFixDate = iMySQLReader.GetString(9);
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtFixDate = "";
                    }

                    try
                    {
                        tempCDebt[i].DebtUnFixPrice = double.Parse(iMySQLReader.GetString(10));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtUnFixPrice = double.Parse(iMySQLReader.GetString(4));
                    }

                    try
                    {
                        tempCDebt[i].DebtFixType = int.Parse(iMySQLReader.GetString(11));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtFixType = 0;
                    }

                    try
                    {
                        tempCDebt[i].DebtFixBackup = iMySQLReader.GetString(12);
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtFixBackup = "";
                    }
                    tempCDebt[i].DebtisInCircle = iMySQLReader.GetString(13) == "1";
                    try
                    {
                        tempCDebt[i].DebtEquipID = int.Parse(iMySQLReader.GetString(14));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtEquipID = 0;
                    }
                    try
                    {
                        tempCDebt[i].DebtBinID = int.Parse(iMySQLReader.GetString(15));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtBinID = 0;
                    }
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        public LXCustomDebt[] ReadCustomDebt(int DebtID)
        {
            var tempCDebt = new LXCustomDebt[1];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_customdebt WHERE DebtID = " + DebtID;
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempCDebt[i].DebtID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt[i].DebtDate = iMySQLReader.GetString(1);
                    tempCDebt[i].DebtCustom = iMySQLReader.GetString(2);
                    tempCDebt[i].DebtDetail = iMySQLReader.GetString(3);
                    tempCDebt[i].DebtPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt[i].DebtType = int.Parse(iMySQLReader.GetString(5));
                    try
                    {
                        tempCDebt[i].DebtPhoneID = int.Parse(iMySQLReader.GetString(6));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtPhoneID = 0;
                    }
                    try
                    {
                        tempCDebt[i].DebtCustomID = int.Parse(iMySQLReader.GetString(7));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtCustomID = 0;
                    }

                    tempCDebt[i].DebtisFix = iMySQLReader.GetString(8) == "1";
                    try
                    {
                        tempCDebt[i].DebtFixDate = iMySQLReader.GetString(9);
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtFixDate = "";
                    }

                    try
                    {
                        tempCDebt[i].DebtUnFixPrice = double.Parse(iMySQLReader.GetString(10));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtUnFixPrice = double.Parse(iMySQLReader.GetString(4));
                    }

                    try
                    {
                        tempCDebt[i].DebtFixType = int.Parse(iMySQLReader.GetString(11));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtFixType = 0;
                    }

                    try
                    {
                        tempCDebt[i].DebtFixBackup = iMySQLReader.GetString(12);
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtFixBackup = "";
                    }
                    tempCDebt[i].DebtisInCircle = iMySQLReader.GetString(13) == "1";
                    try
                    {
                        tempCDebt[i].DebtEquipID = int.Parse(iMySQLReader.GetString(14));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtEquipID = 0;
                    }
                    try
                    {
                        tempCDebt[i].DebtBinID = int.Parse(iMySQLReader.GetString(15));
                    }
                    catch (Exception)
                    {
                        tempCDebt[i].DebtBinID = 0;
                    }
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        public LXCustomDebt SearchCustomDebt(string reqdate, string customdebt, string DebtDetail)
        {
            var tempCDebt = new LXCustomDebt();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_customdebt WHERE DebtDate LIKE '%" + reqdate +
                                   "%' AND DebtCustom LIKE '%" + customdebt + "%' AND DebtDetail LIKE '%" + DebtDetail +
                                   "%'";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    tempCDebt.DebtID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt.DebtDate = iMySQLReader.GetString(1);
                    tempCDebt.DebtCustom = iMySQLReader.GetString(2);
                    tempCDebt.DebtDetail = iMySQLReader.GetString(3);
                    tempCDebt.DebtPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt.DebtType = int.Parse(iMySQLReader.GetString(5));
                    try
                    {
                        tempCDebt.DebtPhoneID = int.Parse(iMySQLReader.GetString(6));
                    }
                    catch (Exception)
                    {
                        tempCDebt.DebtPhoneID = 0;
                    }
                    try
                    {
                        tempCDebt.DebtCustomID = int.Parse(iMySQLReader.GetString(7));
                    }
                    catch (Exception)
                    {
                        tempCDebt.DebtCustomID = 0;
                    }

                    tempCDebt.DebtisFix = iMySQLReader.GetString(8) == "1";
                    try
                    {
                        tempCDebt.DebtFixDate = iMySQLReader.GetString(9);
                    }
                    catch (Exception)
                    {
                        tempCDebt.DebtFixDate = "";
                    }

                    try
                    {
                        tempCDebt.DebtUnFixPrice = double.Parse(iMySQLReader.GetString(10));
                    }
                    catch (Exception)
                    {
                        tempCDebt.DebtUnFixPrice = double.Parse(iMySQLReader.GetString(4));
                    }

                    try
                    {
                        tempCDebt.DebtFixType = int.Parse(iMySQLReader.GetString(11));
                    }
                    catch (Exception)
                    {
                        tempCDebt.DebtFixType = 0;
                    }

                    try
                    {
                        tempCDebt.DebtFixBackup = iMySQLReader.GetString(12);
                    }
                    catch (Exception)
                    {
                        tempCDebt.DebtFixBackup = "";
                    }
                    tempCDebt.DebtisInCircle = iMySQLReader.GetString(13) == "1";
                    try
                    {
                        tempCDebt.DebtEquipID = int.Parse(iMySQLReader.GetString(14));
                    }
                    catch (Exception)
                    {
                        tempCDebt.DebtEquipID = 0;
                    }
                    try
                    {
                        tempCDebt.DebtBinID = int.Parse(iMySQLReader.GetString(15));
                    }
                    catch (Exception)
                    {
                        tempCDebt.DebtBinID = 0;
                    }
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = default(LXCustomDebt);
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        #endregion

        #region 修改

        //public ReturnResult EditCustomDebt()

        public ReturnResult EditCustomDebt(LXCustomDebt iDebt)
        {
            var iReturn = new ReturnResult {isSuccess = false};
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string myUpdateQuery =
                "UPDATE crm_customdebt SET  DebtDate = @DebtDate, DebtCustom = @DebtCustom , DebtDetail = @DebtDetail , DebtPrice = @DebtPrice, DebtType = @DebtType, DebtUnFixPrice= @DebtUnFixPrice, DebtInCircle=@DebtInCircle WHERE DebtID = " +
                iDebt.DebtID;

            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@DebtDate", MySqlDbType.VarChar, 10).Value = iDebt.DebtDate;
                iMySQLCommand.Parameters.Add("@DebtCustom", MySqlDbType.VarChar, 100).Value = iDebt.DebtCustom;
                iMySQLCommand.Parameters.Add("@DebtDetail", MySqlDbType.VarChar, 255).Value = iDebt.DebtDetail;
                iMySQLCommand.Parameters.Add("@DebtPrice", MySqlDbType.VarChar, 10).Value = iDebt.DebtPrice;
                iMySQLCommand.Parameters.Add("@DebtType", MySqlDbType.UInt16).Value = iDebt.DebtType;
                iMySQLCommand.Parameters.Add("@DebtUnFixPrice", MySqlDbType.VarChar, 10).Value = iDebt.DebtUnFixPrice;
                iMySQLCommand.Parameters.Add("@DebtInCircle", MySqlDbType.UInt16).Value = iDebt.DebtisInCircle ? 1 : 0;
                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                Console.Write(e.Message);
                iReturn.ErrDesc = e.Message;
            }

            return iReturn;
        }

        public ReturnResult ChangeSplitDebt(string DebtID, double UnPrice)
        {
            var iReturn = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string mySelectQuery =
                "UPDATE crm_customdebt SET DebtUnFixPrice = @DebtUnFixPrice WHERE DebtID=" + DebtID;

            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@DebtUnFixPrice", MySqlDbType.VarChar, 10).Value = UnPrice;

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                iReturn.ErrDesc = e.Message;
            }

            return iReturn;
        }

        public ReturnResult FixCustomDebt(string DebtID, string FixDate, int FixType, string FixBackup)
        {
            var iReturn = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string mySelectQuery =
                "UPDATE crm_customdebt SET DebtisFix = @DebtisFix, DebtFixDate = @DebtFixDate , DebtFixType =@DebtFixType , DebtFixBackup=@DebtFixBackup WHERE DebtID=" +
                DebtID;

            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@DebtisFix", MySqlDbType.UInt16).Value = 1;
                iMySQLCommand.Parameters.Add("@DebtFixDate", MySqlDbType.VarChar, 10).Value = FixDate;
                iMySQLCommand.Parameters.Add("@DebtFixType", MySqlDbType.UInt16).Value = FixType;
                iMySQLCommand.Parameters.Add("@DebtFixBackup", MySqlDbType.VarChar, 255).Value = FixBackup;

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                iReturn.ErrDesc = e.Message;
            }

            return iReturn;
        }

        #endregion

        #region 增加

        public ReturnResult AddCustomDebt(LXCustomDebt iCustomDebt)
        {
            var iResult = new ReturnResult();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            const string iMySQLQueryCheck = "SELECT MAX(DebtID) FROM crm_customdebt";
            const string iMySQLQuery =
                "insert into crm_customdebt(DebtID,DebtDate,DebtCustom,DebtDetail,DebtPrice,DebtType,DebtPhoneID,DebtCustomID,DebtisFix,DebtFixDate,DebtUnFixPrice,DebtFixType,DebtFixBackup,DebtInCircle,DebtEquipID,DebtBinID) values(@DebtID,@DebtDate,@DebtCustom,@DebtDetail,@DebtPrice,@DebtType,@DebtPhoneID,@DebtCustomID,@DebtisFix,@DebtFixDate,@DebtUnFixPrice,@DebtFixType,@DebtFixBackup,@DebtInCircle,@DebtEquipID,@DebtBinID)";

            try
            {
                var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                iMySQLconn.Open();

                MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                string tempGoodAtrr = "9999";
                try
                {
                    while (iMySQLReaderAttr.Read())
                    {
                        tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                    }
                }
                catch (Exception)
                {
                    tempGoodAtrr = "0";
                }

                iMySQLReaderAttr.Close();
                iMySQLCommand.CommandText = iMySQLQuery;

                iMySQLCommand.Parameters.Add("@DebtID", MySqlDbType.UInt24).Value = int.Parse(tempGoodAtrr) + 1;
                iMySQLCommand.Parameters.Add("@DebtDate", MySqlDbType.VarChar, 10).Value = iCustomDebt.DebtDate;
                iMySQLCommand.Parameters.Add("@DebtCustom", MySqlDbType.VarChar, 100).Value = iCustomDebt.DebtCustom;
                iMySQLCommand.Parameters.Add("@DebtDetail", MySqlDbType.VarChar, 255).Value = iCustomDebt.DebtDetail;
                iMySQLCommand.Parameters.Add("@DebtPrice", MySqlDbType.VarChar, 10).Value = iCustomDebt.DebtPrice;
                iMySQLCommand.Parameters.Add("@DebtType", MySqlDbType.UInt16).Value = iCustomDebt.DebtType;
                try
                {
                    iMySQLCommand.Parameters.Add("@DebtPhoneID", MySqlDbType.UInt24).Value = iCustomDebt.DebtPhoneID;
                }
                catch (Exception)
                {
                    iMySQLCommand.Parameters.Add("@DebtPhoneID", MySqlDbType.UInt24).Value = 0;
                }
                try
                {
                    iMySQLCommand.Parameters.Add("@DebtCustomID", MySqlDbType.UInt24).Value = iCustomDebt.DebtCustomID;
                }
                catch (Exception)
                {
                    iMySQLCommand.Parameters.Add("@DebtCustomID", MySqlDbType.UInt24).Value = 0;
                }

                iMySQLCommand.Parameters.Add("@DebtisFix", MySqlDbType.UInt16).Value = iCustomDebt.DebtisFix ? 1 : 0;
                iMySQLCommand.Parameters.Add("@DebtFixDate", MySqlDbType.VarChar, 10).Value = iCustomDebt.DebtFixDate;
                iMySQLCommand.Parameters.Add("@DebtUnFixPrice", MySqlDbType.VarChar, 10).Value = iCustomDebt.DebtPrice;

                iMySQLCommand.Parameters.Add("@DebtFixType", MySqlDbType.UInt16).Value = iCustomDebt.DebtFixType;
                iMySQLCommand.Parameters.Add("@DebtFixBackup", MySqlDbType.VarChar, 255).Value =
                    iCustomDebt.DebtFixBackup;
                iMySQLCommand.Parameters.Add("@DebtInCircle", MySqlDbType.UInt16).Value = iCustomDebt.DebtisInCircle
                                                                                              ? 1
                                                                                              : 0;
                try
                {
                    iMySQLCommand.Parameters.Add("@DebtEquipID", MySqlDbType.UInt24).Value = iCustomDebt.DebtEquipID;
                }
                catch (Exception)
                {
                    iMySQLCommand.Parameters.Add("@DebtEquipID", MySqlDbType.UInt24).Value = 0;
                }
                try
                {
                    iMySQLCommand.Parameters.Add("@DebtBinID", MySqlDbType.UInt24).Value = iCustomDebt.DebtBinID;
                }
                catch (Exception)
                {
                    iMySQLCommand.Parameters.Add("@DebtBinID", MySqlDbType.UInt24).Value = 0;
                }

                iMySQLCommand.ExecuteNonQuery();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.ErrDesc = e.Message;
                iResult.isSuccess = false;
            }

            return iResult;
        }

        #endregion

        #region 删除

        public ReturnResult DeleteCustomDebtByPhoneID(int Phoneid)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "SELECT DebtID FROM crm_customdebt WHERE DebtPhoneID = " + Phoneid;


            MySqlDataReader iMySQLReader;
            //
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
            int iDebtID = 9999;
            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();

                while (iMySQLReader.Read())
                {
                    iDebtID = int.Parse(iMySQLReader.GetString(0));
                }

                var iDResult = new ReturnResult {isSuccess = false};
                while (!iDResult.isSuccess)
                {
                    iDResult = DeleteCustomDebt(iDebtID);
                }

                iMySQLReader.Close();
                iMySQLconn.Close();
                iMySQLReader.Dispose();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        public ReturnResult DeleteCustomDebtByEquipID(int EquipID)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "SELECT DebtID FROM crm_customdebt WHERE DebtEquipID = " + EquipID;


            MySqlDataReader iMySQLReader;
            //
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
            int iDebtID = 9999;
            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();

                while (iMySQLReader.Read())
                {
                    iDebtID = int.Parse(iMySQLReader.GetString(0));
                }

                var iDResult = new ReturnResult {isSuccess = false};
                while (!iDResult.isSuccess)
                {
                    iDResult = DeleteCustomDebt(iDebtID);
                }

                iMySQLReader.Close();
                iMySQLconn.Close();
                iMySQLReader.Dispose();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        public ReturnResult DeleteCustomDebtByBinID(int BinID)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "SELECT DebtID FROM crm_customdebt WHERE DebtBinID = " + BinID;


            MySqlDataReader iMySQLReader;
            //
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
            int iDebtID = 9999;
            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();

                while (iMySQLReader.Read())
                {
                    iDebtID = int.Parse(iMySQLReader.GetString(0));
                }

                var iDResult = new ReturnResult {isSuccess = false};
                while (!iDResult.isSuccess)
                {
                    iDResult = DeleteCustomDebt(iDebtID);
                }

                iMySQLReader.Close();
                iMySQLconn.Close();
                iMySQLReader.Dispose();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        public ReturnResult DeleteCustomDebt(int Debtid)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "DELETE FROM crm_customdebt WHERE DebtID = " + Debtid;
            string iMySQLKillSplitDebt = "DELETE FROM crm_splitdebt WHERE SplitDebtID = " + Debtid;
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.ExecuteNonQuery();

                iMySQLCommand.CommandText = iMySQLKillSplitDebt;

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();


                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #endregion

        #region 分期付款操作

        public struct LXSplitDebt
        {
            public string SplitDebtBackup;
            public string SplitDebtDate;
            public int SplitDebtID;
            public double SplitDebtPrice;
            public int SplitDebtType;
            public int SplitID;
        }

        #region 读取

        public LXSplitDebt[] ReadSplitDebt(int SplitDebtID)
        {
            var tempCDebt = new LXSplitDebt[24];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_splitdebt WHERE SplitDebtID = " + SplitDebtID +
                                   " ORDER BY SplitDebtDate";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempCDebt[i].SplitID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt[i].SplitDebtID = int.Parse(iMySQLReader.GetString(1));
                    tempCDebt[i].SplitDebtDate = iMySQLReader.GetString(2);
                    tempCDebt[i].SplitDebtBackup = iMySQLReader.GetString(3);
                    tempCDebt[i].SplitDebtPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt[i].SplitDebtType = int.Parse(iMySQLReader.GetString(5));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        #endregion

        #region 增加

        public ReturnResult AddSplitDebt(LXSplitDebt iCustomDebt)
        {
            var iResult = new ReturnResult();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            const string iMySQLQueryCheck = "SELECT MAX(SplitID) FROM crm_splitdebt";
            const string iMySQLQuery =
                "insert into crm_splitdebt(SplitID,SplitDebtID,SplitDebtDate,SplitDebtBackup,SplitDebtPrice,SplitDebtType) values(@SplitID,@SplitDebtID,@SplitDebtDate,@SplitDebtBackup,@SplitDebtPrice,@SplitDebtType)";

            try
            {
                var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                iMySQLconn.Open();

                MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                string tempGoodAtrr = "9999";
                try
                {
                    while (iMySQLReaderAttr.Read())
                    {
                        tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                    }
                }
                catch (Exception)
                {
                    tempGoodAtrr = "0";
                }

                iMySQLReaderAttr.Close();
                iMySQLCommand.CommandText = iMySQLQuery;

                iMySQLCommand.Parameters.Add("@SplitID", MySqlDbType.UInt24).Value = int.Parse(tempGoodAtrr) + 1;
                iMySQLCommand.Parameters.Add("@SplitDebtID", MySqlDbType.UInt24).Value = iCustomDebt.SplitDebtID;
                iMySQLCommand.Parameters.Add("@SplitDebtDate", MySqlDbType.VarChar, 10).Value =
                    iCustomDebt.SplitDebtDate;
                iMySQLCommand.Parameters.Add("@SplitDebtBackup", MySqlDbType.VarChar, 255).Value =
                    iCustomDebt.SplitDebtBackup;
                iMySQLCommand.Parameters.Add("@SplitDebtPrice", MySqlDbType.VarChar, 10).Value =
                    iCustomDebt.SplitDebtPrice;
                iMySQLCommand.Parameters.Add("@SplitDebtType", MySqlDbType.UInt16).Value = iCustomDebt.SplitDebtType;

                iMySQLCommand.ExecuteNonQuery();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.ErrDesc = e.Message;
                iResult.isSuccess = false;
            }

            return iResult;
        }

        #endregion

        #region 修改

        #endregion

        #region 删除

        public ReturnResult DeleteSplitDebt(int Debtid)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "DELETE FROM crm_splitdebt WHERE SplitID = " + Debtid;
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.ExecuteNonQuery();


                iMySQLconn.Close();


                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #endregion

        #region 配件销售

        public struct LXEquip
        {
            public string EquipBackup;
            public string EquipBuyer;
            public double EquipCommision;
            public string EquipDate;
            public int EquipID;
            public string EquipName;
            public int EquipPayment;
            public double EquipPrice;
            public double EquipProfit;
            public double EquipRealPrice;
            public string EquipSellers;
            public string EquipSupplier;
        }

        #region 读取

        public LXEquip[] ReadSoldEquip(string reqDate)
        {
            var tempCDebt = new LXEquip[2000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_equips WHERE EquipDate LIKE '%" + reqDate +
                                   "%' ORDER BY EquipDate";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempCDebt[i].EquipID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt[i].EquipDate = iMySQLReader.GetString(1);
                    tempCDebt[i].EquipName = iMySQLReader.GetString(2);
                    tempCDebt[i].EquipPrice = double.Parse(iMySQLReader.GetString(3));
                    tempCDebt[i].EquipRealPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt[i].EquipSupplier = iMySQLReader.GetString(5);
                    tempCDebt[i].EquipBackup = iMySQLReader.GetString(6);
                    tempCDebt[i].EquipSellers = ReadSellerName(iMySQLReader.GetString(7));
                    tempCDebt[i].EquipProfit = double.Parse(iMySQLReader.GetString(8));
                    tempCDebt[i].EquipCommision = double.Parse(iMySQLReader.GetString(9));
                    tempCDebt[i].EquipPayment = int.Parse(iMySQLReader.GetString(10));
                    tempCDebt[i].EquipBuyer = iMySQLReader.GetString(11);
                    //
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        public LXEquip ReadSoldEquipByID(string iID)
        {
            var tempCDebt = new LXEquip();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_equips WHERE EquipID =" + iID;
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();

                while (iMySQLReader.Read())
                {
                    tempCDebt.EquipID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt.EquipDate = iMySQLReader.GetString(1);
                    tempCDebt.EquipName = iMySQLReader.GetString(2);
                    tempCDebt.EquipPrice = double.Parse(iMySQLReader.GetString(3));
                    tempCDebt.EquipRealPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt.EquipSupplier = iMySQLReader.GetString(5);
                    tempCDebt.EquipBackup = iMySQLReader.GetString(6);
                    tempCDebt.EquipSellers = ReadSellerName(iMySQLReader.GetString(7));
                    tempCDebt.EquipProfit = double.Parse(iMySQLReader.GetString(8));
                    tempCDebt.EquipCommision = double.Parse(iMySQLReader.GetString(9));
                    tempCDebt.EquipPayment = int.Parse(iMySQLReader.GetString(10));
                    tempCDebt.EquipBuyer = iMySQLReader.GetString(11);
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = default(LXEquip);
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        #endregion

        #region 增加

        public ReturnResult AddSellEquip(LXEquip iCustomDebt)
        {
            string[] iPosition = SellersPosition();
            var iResult = new ReturnResult();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            const string iMySQLQueryCheck = "SELECT MAX(EquipID) FROM crm_equips";
            const string iMySQLQuery =
                "insert into crm_equips(EquipID,EquipDate,EquipName,EquipPrice,EquipRealPrice,EquipSupplier,EquipBackup,EquipSellers,EquipProfit,EquipCommision,EquipPayment,EquipBuyer) values(@EquipID,@EquipDate,@EquipName,@EquipPrice,@EquipRealPrice,@EquipSupplier,@EquipBackup,@EquipSellers,@EquipProfit,@EquipCommision,@EquipPayment,@EquipBuyer)";

            try
            {
                var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                iMySQLconn.Open();

                MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                string tempGoodAtrr = "9999";
                while (iMySQLReaderAttr.Read())
                {
                    try
                    {
                        tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                    }
                    catch (Exception)
                    {
                        tempGoodAtrr = "0";
                    }
                }
                iMySQLReaderAttr.Close();
                iMySQLCommand.CommandText = iMySQLQuery;

                iMySQLCommand.Parameters.Add("@EquipID", MySqlDbType.UInt24).Value = int.Parse(tempGoodAtrr) + 1;
                iMySQLCommand.Parameters.Add("@EquipDate", MySqlDbType.VarChar, 10).Value = iCustomDebt.EquipDate;
                iMySQLCommand.Parameters.Add("@EquipName", MySqlDbType.VarChar, 200).Value = iCustomDebt.EquipName;
                iMySQLCommand.Parameters.Add("@EquipPrice", MySqlDbType.VarChar, 10).Value = iCustomDebt.EquipPrice;
                iMySQLCommand.Parameters.Add("@EquipRealPrice", MySqlDbType.VarChar, 10).Value =
                    iCustomDebt.EquipRealPrice;
                iMySQLCommand.Parameters.Add("@EquipSupplier", MySqlDbType.VarChar, 50).Value =
                    iCustomDebt.EquipSupplier;
                iMySQLCommand.Parameters.Add("@EquipBackup", MySqlDbType.VarChar, 255).Value = iCustomDebt.EquipBackup;
                iMySQLCommand.Parameters.Add("@EquipSellers", MySqlDbType.VarChar, 100).Value =
                    ReadSellerID(iCustomDebt.EquipSellers);


                //这里要处理利润和提成

                double Profit = Math.Round(iCustomDebt.EquipPrice - iCustomDebt.EquipRealPrice, 2);
                int Commision;

                if (Profit < 100)
                {
                    Commision = 0;
                }
                else if (100 <= Profit && Profit < 500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0");
                }
                else if (500 <= Profit && Profit < 1000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 50;
                }
                else if (1000 <= Profit && Profit < 1500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 100;
                }
                else if (1500 <= Profit && Profit < 2000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 150;
                }
                else
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 200;
                }

                iMySQLCommand.Parameters.Add("@EquipProfit", MySqlDbType.VarChar, 10).Value = Profit;

                if (ReadSellerPosition(iCustomDebt.EquipSellers) != "店长" &&
                    ReadSellerPosition(iCustomDebt.EquipSellers) != "销售")
                {
                    iMySQLCommand.Parameters.Add("@EquipCommision", MySqlDbType.VarChar, 10).Value = 0;
                }
                else
                {
                    iMySQLCommand.Parameters.Add("@EquipCommision", MySqlDbType.VarChar, 10).Value = Commision;
                }


                iMySQLCommand.Parameters.Add("@EquipPayment", MySqlDbType.UInt16).Value = iCustomDebt.EquipPayment;

                iMySQLCommand.Parameters.Add("@EquipBuyer", MySqlDbType.VarChar, 100).Value =
                    iCustomDebt.EquipBuyer;

                iMySQLCommand.ExecuteNonQuery();
                iResult.PhoneID = int.Parse(tempGoodAtrr) + 1;
                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.ErrDesc = e.Message;
                iResult.isSuccess = false;
            }

            return iResult;
        }

        #endregion

        #region 修改

        public ReturnResult EditSoldEquip(LXEquip iEquip)
        {
            var iReturn = new ReturnResult {isSuccess = false};
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string myUpdateQuery =
                "UPDATE crm_equips SET  EquipDate = @EquipDate, EquipName = @EquipName , EquipPrice = @EquipPrice , EquipRealPrice = @EquipRealPrice, EquipSupplier = @EquipSupplier, EquipBackup= @EquipBackup, EquipSellers= @EquipSellers, EquipProfit= @EquipProfit, EquipCommision= @EquipCommision, EquipPayment=@EquipPayment, EquipBuyer=@EquipBuyer WHERE EquipID = " +
                iEquip.EquipID;

            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@EquipDate", MySqlDbType.VarChar, 10).Value = iEquip.EquipDate;
                iMySQLCommand.Parameters.Add("@EquipName", MySqlDbType.VarChar, 200).Value = iEquip.EquipName;
                iMySQLCommand.Parameters.Add("@EquipPrice", MySqlDbType.VarChar, 10).Value = iEquip.EquipPrice;
                iMySQLCommand.Parameters.Add("@EquipRealPrice", MySqlDbType.VarChar, 10).Value = iEquip.EquipRealPrice;
                iMySQLCommand.Parameters.Add("@EquipSupplier", MySqlDbType.VarChar, 50).Value =
                    iEquip.EquipSupplier;
                iMySQLCommand.Parameters.Add("@EquipBackup", MySqlDbType.VarChar, 255).Value = iEquip.EquipBackup;
                iMySQLCommand.Parameters.Add("@EquipSellers", MySqlDbType.VarChar, 100).Value =
                    ReadSellerID(iEquip.EquipSellers);

                double Profit = Math.Round(iEquip.EquipPrice - iEquip.EquipRealPrice, 2);
                int Commision;

                if (Profit < 100)
                {
                    Commision = 0;
                }
                else if (100 <= Profit && Profit < 500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0");
                }
                else if (500 <= Profit && Profit < 1000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 50;
                }
                else if (1000 <= Profit && Profit < 1500)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 100;
                }
                else if (1500 <= Profit && Profit < 2000)
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 150;
                }
                else
                {
                    Commision = int.Parse(Profit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 200;
                }

                iMySQLCommand.Parameters.Add("@EquipProfit", MySqlDbType.VarChar, 10).Value = Profit;
                iMySQLCommand.Parameters.Add("@EquipCommision", MySqlDbType.VarChar, 10).Value = Commision;

                iMySQLCommand.Parameters.Add("@EquipPayment", MySqlDbType.UInt16).Value = iEquip.EquipPayment;
                iMySQLCommand.Parameters.Add("@EquipBuyer", MySqlDbType.VarChar, 100).Value =
                    iEquip.EquipBuyer;

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                Console.Write(e.Message);
                iReturn.ErrDesc = e.Message;
            }

            return iReturn;
        }

        #endregion

        #region 删除

        public ReturnResult DeleteSellEquip(int Debtid)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "DELETE FROM crm_equips WHERE EquipID = " + Debtid;
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.ExecuteNonQuery();


                iMySQLconn.Close();


                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #endregion

        #region 收手机操作

        public struct RefundPhone
        {
            public string RefundBackup;
            public string RefundDate;
            public double RefundFixCommision;
            public string RefundFixDate;
            public double RefundFixPrice;
            public double RefundFixProfit;
            public string RefundFixSeller;
            public int RefundFixType;
            public int RefundID;
            public string RefundIMEI;
            public bool RefundIsFix;
            public string RefundName;
            public double RefundPrice;
            public int RefundRefundType;
            public double RefundRepairPrice;
            public string RefundSeller;
        }

        #region 读取

        public RefundPhone ReadRefundPhoneByID(string iID)
        {
            var tempRefundPhone = new RefundPhone();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_refund WHERE RefundID = " + iID;
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();

                while (iMySQLReader.Read())
                {
                    tempRefundPhone.RefundID = int.Parse(iMySQLReader.GetString(0));
                    tempRefundPhone.RefundDate = iMySQLReader.GetString(1);
                    tempRefundPhone.RefundName = iMySQLReader.GetString(2);
                    tempRefundPhone.RefundPrice = double.Parse(iMySQLReader.GetString(3));
                    tempRefundPhone.RefundRepairPrice = double.Parse(iMySQLReader.GetString(4));
                    tempRefundPhone.RefundSeller = ReadSellerName(iMySQLReader.GetString(5));
                    tempRefundPhone.RefundIMEI = iMySQLReader.GetString(6);
                    tempRefundPhone.RefundBackup = iMySQLReader.GetString(7);
                    tempRefundPhone.RefundIsFix = iMySQLReader.GetString(8) == "1";
                    tempRefundPhone.RefundFixDate = iMySQLReader.GetString(9);
                    tempRefundPhone.RefundFixPrice = double.Parse(iMySQLReader.GetString(10));
                    tempRefundPhone.RefundFixProfit = double.Parse(iMySQLReader.GetString(11));
                    tempRefundPhone.RefundFixCommision = double.Parse(iMySQLReader.GetString(12));
                    tempRefundPhone.RefundRefundType = int.Parse(iMySQLReader.GetString(13));
                    tempRefundPhone.RefundFixType = int.Parse(iMySQLReader.GetString(14));
                    tempRefundPhone.RefundFixSeller = ReadSellerName(iMySQLReader.GetString(15));
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempRefundPhone = default(RefundPhone);
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempRefundPhone;
        }

        public RefundPhone[] ReadRefundPhone(string reqDate, bool reqFix)
        {
            var tempCDebt = new RefundPhone[1000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            //var mySelectQuery;
            string mySelectQuery = reqFix
                                       ? "SELECT * FROM crm_refund WHERE RefundDate LIKE '%" + reqDate +
                                         "%' AND RefundIsFix = 1 ORDER BY RefundDate"
                                       : "SELECT * FROM crm_refund WHERE RefundDate LIKE '%" + reqDate +
                                         "%' AND RefundIsFix = 0 ORDER BY RefundDate";

            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempCDebt[i].RefundID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt[i].RefundDate = iMySQLReader.GetString(1);
                    tempCDebt[i].RefundName = iMySQLReader.GetString(2);
                    tempCDebt[i].RefundPrice = double.Parse(iMySQLReader.GetString(3));
                    tempCDebt[i].RefundRepairPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt[i].RefundSeller = ReadSellerName(iMySQLReader.GetString(5));
                    tempCDebt[i].RefundIMEI = iMySQLReader.GetString(6);
                    tempCDebt[i].RefundBackup = iMySQLReader.GetString(7);
                    tempCDebt[i].RefundIsFix = iMySQLReader.GetString(8) == "1";
                    tempCDebt[i].RefundFixDate = iMySQLReader.GetString(9);
                    tempCDebt[i].RefundFixPrice = double.Parse(iMySQLReader.GetString(10));
                    tempCDebt[i].RefundFixProfit = double.Parse(iMySQLReader.GetString(11));
                    tempCDebt[i].RefundFixCommision = double.Parse(iMySQLReader.GetString(12));
                    tempCDebt[i].RefundRefundType = int.Parse(iMySQLReader.GetString(13));
                    tempCDebt[i].RefundFixType = int.Parse(iMySQLReader.GetString(14));
                    tempCDebt[i].RefundFixSeller = ReadSellerName(iMySQLReader.GetString(15));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        public RefundPhone[] ReadRefundPhone(string reqDate)
        {
            var tempCDebt = new RefundPhone[1000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_refund WHERE RefundDate LIKE '%" + reqDate +
                                   "%' ORDER BY RefundDate";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempCDebt[i].RefundID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt[i].RefundDate = iMySQLReader.GetString(1);
                    tempCDebt[i].RefundName = iMySQLReader.GetString(2);
                    tempCDebt[i].RefundPrice = double.Parse(iMySQLReader.GetString(3));
                    tempCDebt[i].RefundRepairPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt[i].RefundSeller = ReadSellerName(iMySQLReader.GetString(5));
                    tempCDebt[i].RefundIMEI = iMySQLReader.GetString(6);
                    tempCDebt[i].RefundBackup = iMySQLReader.GetString(7);
                    tempCDebt[i].RefundIsFix = iMySQLReader.GetString(8) == "1";
                    tempCDebt[i].RefundFixDate = iMySQLReader.GetString(9);
                    tempCDebt[i].RefundFixPrice = double.Parse(iMySQLReader.GetString(10));
                    tempCDebt[i].RefundFixProfit = double.Parse(iMySQLReader.GetString(11));
                    tempCDebt[i].RefundFixCommision = double.Parse(iMySQLReader.GetString(12));
                    tempCDebt[i].RefundRefundType = int.Parse(iMySQLReader.GetString(13));
                    tempCDebt[i].RefundFixType = int.Parse(iMySQLReader.GetString(14));
                    tempCDebt[i].RefundFixSeller = ReadSellerName(iMySQLReader.GetString(15));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        public RefundPhone[] ReadRefundPhoneByFixDate(string fixDate)
        {
            var tempCDebt = new RefundPhone[1000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_refund WHERE RefundFixDate LIKE '%" + fixDate +
                                   "%' ORDER BY RefundDate";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempCDebt[i].RefundID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt[i].RefundDate = iMySQLReader.GetString(1);
                    tempCDebt[i].RefundName = iMySQLReader.GetString(2);
                    tempCDebt[i].RefundPrice = double.Parse(iMySQLReader.GetString(3));
                    tempCDebt[i].RefundRepairPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt[i].RefundSeller = ReadSellerName(iMySQLReader.GetString(5));
                    tempCDebt[i].RefundIMEI = iMySQLReader.GetString(6);
                    tempCDebt[i].RefundBackup = iMySQLReader.GetString(7);
                    tempCDebt[i].RefundIsFix = iMySQLReader.GetString(8) == "1";
                    tempCDebt[i].RefundFixDate = iMySQLReader.GetString(9);
                    tempCDebt[i].RefundFixPrice = double.Parse(iMySQLReader.GetString(10));
                    tempCDebt[i].RefundFixProfit = double.Parse(iMySQLReader.GetString(11));
                    tempCDebt[i].RefundFixCommision = double.Parse(iMySQLReader.GetString(12));
                    tempCDebt[i].RefundRefundType = int.Parse(iMySQLReader.GetString(13));
                    tempCDebt[i].RefundFixType = int.Parse(iMySQLReader.GetString(14));
                    tempCDebt[i].RefundFixSeller = ReadSellerName(iMySQLReader.GetString(15));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        #endregion

        #region 增加

        public ReturnResult AddRefundPhone(RefundPhone iRefundPhone)
        {
            var iResult = new ReturnResult();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            const string iMySQLQueryCheck = "SELECT MAX(RefundID) FROM crm_refund";
            const string iMySQLQuery =
                "insert into crm_refund(RefundID,RefundDate,RefundName,RefundPrice,RefundRepairPrice,RefundSeller,RefundIMEI,RefundBackup,RefundIsFix,RefundFixDate,RefundFixPrice,RefundFixProfit,RefundFixCommision,RefundRefundType,RefundFixType) values(@RefundID,@RefundDate,@RefundName,@RefundPrice,@RefundRepairPrice,@RefundSeller,@RefundIMEI,@RefundBackup,@RefundIsFix,@RefundFixDate,@RefundFixPrice,@RefundFixProfit,@RefundFixCommision,@RefundRefundType,@RefundFixType)";

            try
            {
                var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                iMySQLconn.Open();

                MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                string tempGoodAtrr = "9999";
                while (iMySQLReaderAttr.Read())
                {
                    try
                    {
                        tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                    }
                    catch (Exception)
                    {
                        tempGoodAtrr = "0";
                    }
                }
                iMySQLReaderAttr.Close();
                iMySQLCommand.CommandText = iMySQLQuery;

                iMySQLCommand.Parameters.Add("@RefundID", MySqlDbType.UInt24).Value = int.Parse(tempGoodAtrr) + 1;
                iMySQLCommand.Parameters.Add("@RefundDate", MySqlDbType.VarChar, 10).Value = iRefundPhone.RefundDate;
                iMySQLCommand.Parameters.Add("@RefundName", MySqlDbType.VarChar, 100).Value = iRefundPhone.RefundName;
                iMySQLCommand.Parameters.Add("@RefundPrice", MySqlDbType.VarChar, 10).Value = iRefundPhone.RefundPrice;
                iMySQLCommand.Parameters.Add("@RefundRepairPrice", MySqlDbType.VarChar, 10).Value =
                    iRefundPhone.RefundRepairPrice;
                iMySQLCommand.Parameters.Add("@RefundSeller", MySqlDbType.VarChar, 100).Value =
                    ReadSellerID(iRefundPhone.RefundSeller);

                iMySQLCommand.Parameters.Add("@RefundIMEI", MySqlDbType.VarChar, 30).Value = iRefundPhone.RefundIMEI;
                iMySQLCommand.Parameters.Add("@RefundBackup", MySqlDbType.VarChar, 255).Value =
                    iRefundPhone.RefundBackup;
                iMySQLCommand.Parameters.Add("@RefundIsFix", MySqlDbType.UInt16).Value = iRefundPhone.RefundIsFix
                                                                                             ? 1
                                                                                             : 0;
                iMySQLCommand.Parameters.Add("@RefundFixDate", MySqlDbType.VarChar, 10).Value =
                    iRefundPhone.RefundFixDate;
                iMySQLCommand.Parameters.Add("@RefundFixPrice", MySqlDbType.VarChar, 10).Value =
                    iRefundPhone.RefundFixPrice;
                iMySQLCommand.Parameters.Add("@RefundFixProfit", MySqlDbType.VarChar, 10).Value =
                    iRefundPhone.RefundFixProfit;
                iMySQLCommand.Parameters.Add("@RefundFixCommision", MySqlDbType.VarChar, 10).Value =
                    iRefundPhone.RefundFixCommision;
                iMySQLCommand.Parameters.Add("@RefundRefundType", MySqlDbType.UInt16).Value =
                    iRefundPhone.RefundRefundType;
                iMySQLCommand.Parameters.Add("@RefundFixType", MySqlDbType.UInt16).Value = iRefundPhone.RefundFixType;
                iMySQLCommand.ExecuteNonQuery();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.ErrDesc = e.Message;
                iResult.isSuccess = false;
            }

            return iResult;
        }

        public ReturnResult AddIndieRefundPhone(RefundPhone iRefundPhone)
        {
            var iResult = new ReturnResult();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            const string iMySQLQueryCheck = "SELECT MAX(RefundID) FROM crm_refund";
            const string iMySQLQuery =
                "insert into crm_refund(RefundID,RefundDate,RefundName,RefundPrice,RefundRepairPrice,RefundSeller,RefundIMEI,RefundBackup,RefundIsFix,RefundFixDate,RefundFixPrice,RefundFixProfit,RefundFixCommision,RefundRefundType,RefundFixType,RefundFixSeller) values(@RefundID,@RefundDate,@RefundName,@RefundPrice,@RefundRepairPrice,@RefundSeller,@RefundIMEI,@RefundBackup,@RefundIsFix,@RefundFixDate,@RefundFixPrice,@RefundFixProfit,@RefundFixCommision,@RefundRefundType,@RefundFixType,@RefundFixSeller)";

            try
            {
                var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                iMySQLconn.Open();

                MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                string tempGoodAtrr = "9999";
                while (iMySQLReaderAttr.Read())
                {
                    try
                    {
                        tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                    }
                    catch (Exception)
                    {
                        tempGoodAtrr = "0";
                    }
                }
                iMySQLReaderAttr.Close();
                iMySQLCommand.CommandText = iMySQLQuery;


                iMySQLCommand.Parameters.Add("@RefundID", MySqlDbType.UInt24).Value = int.Parse(tempGoodAtrr) + 1;
                iMySQLCommand.Parameters.Add("@RefundDate", MySqlDbType.VarChar, 10).Value = iRefundPhone.RefundDate;
                iMySQLCommand.Parameters.Add("@RefundName", MySqlDbType.VarChar, 100).Value = iRefundPhone.RefundName;
                iMySQLCommand.Parameters.Add("@RefundPrice", MySqlDbType.VarChar, 10).Value = iRefundPhone.RefundPrice;
                iMySQLCommand.Parameters.Add("@RefundRepairPrice", MySqlDbType.VarChar, 10).Value =
                    iRefundPhone.RefundRepairPrice;
                iMySQLCommand.Parameters.Add("@RefundSeller", MySqlDbType.VarChar, 100).Value =
                    ReadSellerID(iRefundPhone.RefundSeller);

                iMySQLCommand.Parameters.Add("@RefundIMEI", MySqlDbType.VarChar, 30).Value = iRefundPhone.RefundIMEI;
                iMySQLCommand.Parameters.Add("@RefundBackup", MySqlDbType.VarChar, 255).Value =
                    iRefundPhone.RefundBackup;


                double RefundProfit = Math.Round(iRefundPhone.RefundFixPrice - iRefundPhone.RefundPrice, 2);
                RefundProfit = Math.Round(RefundProfit - iRefundPhone.RefundRepairPrice, 2);
                double RefundCommision;
                if (RefundProfit < 100)
                {
                    RefundCommision = 0;
                }
                else if (100 <= RefundProfit && RefundProfit < 500)
                {
                    RefundCommision = int.Parse(RefundProfit.ToString().PadLeft(4, '0').Substring(0, 2) + "0");
                }
                else if (500 <= RefundProfit && RefundProfit < 1000)
                {
                    RefundCommision = int.Parse(RefundProfit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 50;
                }
                else if (1000 <= RefundProfit && RefundProfit < 1500)
                {
                    RefundCommision = int.Parse(RefundProfit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 100;
                }
                else if (1500 <= RefundProfit && RefundProfit < 2000)
                {
                    RefundCommision = int.Parse(RefundProfit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 15150;
                }
                else
                {
                    RefundCommision = int.Parse(RefundProfit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 200;
                }

                iMySQLCommand.Parameters.Add("@RefundIsFix", MySqlDbType.UInt16).Value = 1;
                iMySQLCommand.Parameters.Add("@RefundFixDate", MySqlDbType.VarChar, 10).Value =
                    iRefundPhone.RefundFixDate;
                iMySQLCommand.Parameters.Add("@RefundFixPrice", MySqlDbType.VarChar, 10).Value =
                    iRefundPhone.RefundFixPrice;
                iMySQLCommand.Parameters.Add("@RefundFixProfit", MySqlDbType.VarChar, 10).Value = RefundProfit;

                if (ReadSellerPosition(iRefundPhone.RefundFixSeller) != "店长" &&
                    ReadSellerPosition(iRefundPhone.RefundFixSeller) != "销售")
                {
                    iMySQLCommand.Parameters.Add("@RefundFixCommision", MySqlDbType.VarChar, 10).Value = 0;
                }
                else
                {
                    iMySQLCommand.Parameters.Add("@RefundFixCommision", MySqlDbType.VarChar, 10).Value = RefundCommision;
                }
                iMySQLCommand.Parameters.Add("@RefundFixType", MySqlDbType.UInt16).Value = iRefundPhone.RefundFixType;
                iMySQLCommand.Parameters.Add("@RefundFixSeller", MySqlDbType.VarChar, 100).Value =
                    ReadSellerID(iRefundPhone.RefundFixSeller);

                iMySQLCommand.ExecuteNonQuery();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.ErrDesc = e.Message;
                iResult.isSuccess = false;
            }

            return iResult;
        }

        #endregion

        #region 修改

        public ReturnResult EditRefundPhone(RefundPhone iRefundPhone)
        {
            var iReturn = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string myUpdateQuery =
                "UPDATE crm_refund SET RefundDate = @RefundDate, RefundName = @RefundName, RefundPrice = @RefundPrice, RefundRepairPrice = @RefundRepairPrice, RefundSeller = @RefundSeller, RefundIMEI = @RefundIMEI, RefundBackup = @RefundBackup, RefundRefundType=@RefundRefundType WHERE RefundID=" +
                iRefundPhone.RefundID;

            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@RefundDate", MySqlDbType.VarChar, 10).Value = iRefundPhone.RefundDate;
                iMySQLCommand.Parameters.Add("@RefundName", MySqlDbType.VarChar, 100).Value = iRefundPhone.RefundName;
                iMySQLCommand.Parameters.Add("@RefundPrice", MySqlDbType.VarChar, 10).Value = iRefundPhone.RefundPrice;
                iMySQLCommand.Parameters.Add("@RefundRepairPrice", MySqlDbType.VarChar, 10).Value =
                    iRefundPhone.RefundRepairPrice;
                iMySQLCommand.Parameters.Add("@RefundSeller", MySqlDbType.VarChar, 100).Value =
                    ReadSellerID(iRefundPhone.RefundSeller);

                iMySQLCommand.Parameters.Add("@RefundIMEI", MySqlDbType.VarChar, 30).Value = iRefundPhone.RefundIMEI;
                iMySQLCommand.Parameters.Add("@RefundBackup", MySqlDbType.VarChar, 255).Value =
                    iRefundPhone.RefundBackup;

                iMySQLCommand.Parameters.Add("@RefundRefundType", MySqlDbType.UInt16).Value =
                    iRefundPhone.RefundRefundType;
                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                iReturn.ErrDesc = e.Message;
            }

            return iReturn;
        }

        public ReturnResult FixRefundPhone(bool isFix, string FixDate, double FixPrice, int RefundID, int FixType,
                                           string FixSeller)
        {
            string[] iPosition = SellersPosition();
            var iReturn = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string mySelectQuery =
                "SELECT RefundPrice,RefundRepairPrice FROM crm_refund WHERE RefundID = " + RefundID +
                " ORDER BY RefundDate";

            string myUpdateQuery =
                "UPDATE crm_refund SET RefundIsFix = @RefundIsFix, RefundFixDate = @RefundFixDate, RefundFixPrice = @RefundFixPrice, RefundFixProfit = @RefundFixProfit, RefundFixCommision = @RefundFixCommision, RefundFixType = @RefundFixType, RefundFixSeller=@RefundFixSeller WHERE RefundID=" +
                RefundID;

            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;
            try
            {
                iMySQLconn.Open();
                string SellerPos = "";
                double RefundPrice = 0;
                double RefundRepairPrice = 0;
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    //SellerPos = ReadSellerName(iMySQLReader.GetString(0));
                    RefundPrice = double.Parse(iMySQLReader.GetString(0));
                    RefundRepairPrice = double.Parse(iMySQLReader.GetString(1));
                }

                iMySQLReader.Close();
                iMySQLCommand.CommandText = myUpdateQuery;
                double RefundProfit = Math.Round(FixPrice - RefundPrice, 2);
                RefundProfit = Math.Round(RefundProfit - RefundRepairPrice, 2);
                double RefundCommision;
                if (RefundProfit < 100)
                {
                    RefundCommision = 0;
                }
                else if (100 <= RefundProfit && RefundProfit < 500)
                {
                    RefundCommision = int.Parse(RefundProfit.ToString().PadLeft(4, '0').Substring(0, 2) + "0");
                }
                else if (500 <= RefundProfit && RefundProfit < 1000)
                {
                    RefundCommision = int.Parse(RefundProfit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 50;
                }
                else if (1000 <= RefundProfit && RefundProfit < 1500)
                {
                    RefundCommision = int.Parse(RefundProfit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 100;
                }
                else if (1500 <= RefundProfit && RefundProfit < 2000)
                {
                    RefundCommision = int.Parse(RefundProfit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 15150;
                }
                else
                {
                    RefundCommision = int.Parse(RefundProfit.ToString().PadLeft(4, '0').Substring(0, 2) + "0") + 200;
                }

                iMySQLCommand.Parameters.Add("@RefundIsFix", MySqlDbType.UInt16).Value = isFix ? 1 : 0;
                iMySQLCommand.Parameters.Add("@RefundFixDate", MySqlDbType.VarChar, 10).Value = FixDate;
                iMySQLCommand.Parameters.Add("@RefundFixPrice", MySqlDbType.VarChar, 10).Value = FixPrice;
                iMySQLCommand.Parameters.Add("@RefundFixProfit", MySqlDbType.VarChar, 10).Value = RefundProfit;

                if (ReadSellerPosition(FixSeller) != "店长" && ReadSellerPosition(FixSeller) != "销售")
                {
                    iMySQLCommand.Parameters.Add("@RefundFixCommision", MySqlDbType.VarChar, 10).Value = 0;
                }
                else
                {
                    iMySQLCommand.Parameters.Add("@RefundFixCommision", MySqlDbType.VarChar, 10).Value = RefundCommision;
                }
                iMySQLCommand.Parameters.Add("@RefundFixType", MySqlDbType.UInt16).Value = FixType;
                iMySQLCommand.Parameters.Add("@RefundFixSeller", MySqlDbType.VarChar, 100).Value =
                    ReadSellerID(FixSeller);

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                iReturn.ErrDesc = e.Message;
            }

            return iReturn;
        }

        #endregion

        #region 删除

        public ReturnResult DeleteRefundPhone(int RefundID)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "DELETE FROM crm_refund WHERE RefundID = " + RefundID;
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();


                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #endregion

        #region 市场欠款

        public struct LXMarketDebt
        {
            public string DebtBackup;
            public string DebtDate;
            public string DebtDetail;
            public string DebtFixDate;
            public int DebtID;
            public string DebtMaster;
            public double DebtPrice;
            public string DebtSeller;
            public bool DebtisCashCircle;
            public bool DebtisFix;
        }

        #region 读取

        public LXMarketDebt[] ReadMarketDebt(string reqDate)
        {
            var tempCDebt = new LXMarketDebt[1000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_marketdebt WHERE DebtDate LIKE '%" + reqDate +
                                   "%' ORDER BY DebtDate";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempCDebt[i].DebtID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt[i].DebtDate = iMySQLReader.GetString(1);
                    tempCDebt[i].DebtMaster = iMySQLReader.GetString(2);
                    tempCDebt[i].DebtDetail = iMySQLReader.GetString(3);
                    tempCDebt[i].DebtPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt[i].DebtSeller = ReadSellerName(iMySQLReader.GetString(5));
                    tempCDebt[i].DebtBackup = iMySQLReader.GetString(6);
                    tempCDebt[i].DebtisFix = iMySQLReader.GetString(7) == "1";
                    tempCDebt[i].DebtFixDate = iMySQLReader.GetString(8);
                    tempCDebt[i].DebtisCashCircle = iMySQLReader.GetString(9) == "1";
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        public LXMarketDebt ReadMarketDebtByID(string iID)
        {
            var tempCDebt = new LXMarketDebt();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_marketdebt WHERE DebtID =" + iID;
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();

                while (iMySQLReader.Read())
                {
                    tempCDebt.DebtID = int.Parse(iMySQLReader.GetString(0));
                    tempCDebt.DebtDate = iMySQLReader.GetString(1);
                    tempCDebt.DebtMaster = iMySQLReader.GetString(2);
                    tempCDebt.DebtDetail = iMySQLReader.GetString(3);
                    tempCDebt.DebtPrice = double.Parse(iMySQLReader.GetString(4));
                    tempCDebt.DebtSeller = ReadSellerName(iMySQLReader.GetString(5));
                    tempCDebt.DebtBackup = iMySQLReader.GetString(6);
                    tempCDebt.DebtisFix = iMySQLReader.GetString(7) == "1";
                    tempCDebt.DebtFixDate = iMySQLReader.GetString(8);
                    tempCDebt.DebtisCashCircle = iMySQLReader.GetString(9) == "1";
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempCDebt = default(LXMarketDebt);
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempCDebt;
        }

        #endregion

        #region 增加

        public ReturnResult AddMarketDebt(LXMarketDebt iMarketDebt)
        {
            var iResult = new ReturnResult();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            const string iMySQLQueryCheck = "SELECT MAX(DebtID) FROM crm_marketdebt";
            const string iMySQLQuery =
                "insert into crm_marketdebt(DebtID,DebtDate,DebtMaster,DebtDetail,DebtPrice,DebtSeller,DebtBackup,DebtisFix,DebtFixDate,DebtisCashCircle) values(@DebtID,@DebtDate,@DebtMaster,@DebtDetail,@DebtPrice,@DebtSeller,@DebtBackup,@DebtisFix,@DebtFixDate,@DebtisCashCircle)";

            try
            {
                var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                iMySQLconn.Open();

                MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                string tempGoodAtrr = "9999";
                try
                {
                    while (iMySQLReaderAttr.Read())
                    {
                        tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                    }
                }
                catch (Exception)
                {
                    tempGoodAtrr = "0";
                }

                iMySQLReaderAttr.Close();
                iMySQLCommand.CommandText = iMySQLQuery;

                iMySQLCommand.Parameters.Add("@DebtID", MySqlDbType.UInt24).Value = int.Parse(tempGoodAtrr) + 1;
                iMySQLCommand.Parameters.Add("@DebtDate", MySqlDbType.VarChar, 10).Value = iMarketDebt.DebtDate;
                iMySQLCommand.Parameters.Add("@DebtMaster", MySqlDbType.VarChar, 100).Value = iMarketDebt.DebtMaster;
                iMySQLCommand.Parameters.Add("@DebtDetail", MySqlDbType.VarChar, 255).Value = iMarketDebt.DebtDetail;
                iMySQLCommand.Parameters.Add("@DebtPrice", MySqlDbType.VarChar, 10).Value = iMarketDebt.DebtPrice;
                iMySQLCommand.Parameters.Add("@DebtSeller", MySqlDbType.VarChar, 100).Value =
                    ReadSellerID(iMarketDebt.DebtSeller);
                iMySQLCommand.Parameters.Add("@DebtBackup", MySqlDbType.VarChar, 255).Value = iMarketDebt.DebtBackup;
                iMySQLCommand.Parameters.Add("@DebtisFix", MySqlDbType.UInt16).Value = iMarketDebt.DebtisFix ? 1 : 0;
                iMySQLCommand.Parameters.Add("@DebtFixDate", MySqlDbType.VarChar, 10).Value = iMarketDebt.DebtFixDate;
                iMySQLCommand.Parameters.Add("@DebtisCashCircle", MySqlDbType.UInt16).Value =
                    iMarketDebt.DebtisCashCircle ? 1 : 0;
                iMySQLCommand.ExecuteNonQuery();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.ErrDesc = e.Message;
                iResult.isSuccess = false;
            }

            return iResult;
        }

        #endregion

        #region 修改

        public ReturnResult EditMarketDebt(LXMarketDebt iDebt)
        {
            var iReturn = new ReturnResult {isSuccess = false};
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string myUpdateQuery =
                "UPDATE crm_marketdebt SET  DebtDate = @DebtDate, DebtMaster = @DebtMaster , DebtDetail = @DebtDetail , DebtPrice = @DebtPrice, DebtSeller = @DebtSeller, DebtBackup=@DebtBackup, DebtisFix=@DebtisFix, DebtFixDate=@DebtFixDate, DebtisCashCircle=@DebtisCashCircle WHERE DebtID = " +
                iDebt.DebtID;

            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@DebtDate", MySqlDbType.VarChar, 10).Value = iDebt.DebtDate;
                iMySQLCommand.Parameters.Add("@DebtMaster", MySqlDbType.VarChar, 100).Value = iDebt.DebtMaster;
                iMySQLCommand.Parameters.Add("@DebtDetail", MySqlDbType.VarChar, 255).Value = iDebt.DebtDetail;
                iMySQLCommand.Parameters.Add("@DebtPrice", MySqlDbType.VarChar, 10).Value = iDebt.DebtPrice;
                iMySQLCommand.Parameters.Add("@DebtSeller", MySqlDbType.VarChar, 100).Value =
                    ReadSellerID(iDebt.DebtSeller);
                iMySQLCommand.Parameters.Add("@DebtBackup", MySqlDbType.VarChar, 255).Value = iDebt.DebtBackup;
                iMySQLCommand.Parameters.Add("@DebtisFix", MySqlDbType.UInt16).Value = iDebt.DebtisFix ? 1 : 0;
                iMySQLCommand.Parameters.Add("@DebtFixDate", MySqlDbType.VarChar, 10).Value = iDebt.DebtFixDate;
                iMySQLCommand.Parameters.Add("@DebtisCashCircle", MySqlDbType.UInt16).Value = iDebt.DebtisCashCircle
                                                                                                  ? 1
                                                                                                  : 0;
                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                Console.Write(e.Message);
                iReturn.ErrDesc = e.Message;
            }

            return iReturn;
        }

        public ReturnResult FixMarketDebt(string DebtID, string FixDate)
        {
            var iReturn = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string mySelectQuery =
                "UPDATE crm_marketdebt SET DebtisFix = @DebtisFix,DebtFixDate = @DebtFixDate WHERE DebtID=" + DebtID;

            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@DebtisFix", MySqlDbType.UInt16).Value = 1;
                iMySQLCommand.Parameters.Add("@DebtFixDate", MySqlDbType.VarChar, 10).Value = FixDate;

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                iReturn.ErrDesc = e.Message;
            }

            return iReturn;
        }

        #endregion

        #region 删除

        public ReturnResult DeleteMarketDebt(int Debtid)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "DELETE FROM crm_marketdebt WHERE DebtID = " + Debtid;
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.ExecuteNonQuery();


                iMySQLconn.Close();


                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #endregion

        #region 私人支出操作

        #region 读取支出

        public Payout[] ReadPrivatePayout(string reqDate)
        {
            var tempPayout = new Payout[500];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_ppayout WHERE ppayout_time  LIKE '%" + reqDate +
                                   "%' ORDER BY ppayout_time";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempPayout[i].PayoutName = iMySQLReader.GetString(0);
                    tempPayout[i].PayoutPrice = iMySQLReader.GetString(1);
                    tempPayout[i].PayoutDate = iMySQLReader.GetString(2);
                    tempPayout[i].PayoutType = iMySQLReader.GetString(3);
                    tempPayout[i].PayoutBackup = iMySQLReader.GetString(4);
                    tempPayout[i].PayoutID = int.Parse(iMySQLReader.GetString(5));
                    tempPayout[i].PayoutInCase = iMySQLReader.GetString(6) != "0";
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempPayout = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempPayout;
        }

        #endregion

        #region 添加支出

        public ReturnResult AddPrivatePayout(Payout iPayout)
        {
            var iResult = new ReturnResult();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            const string iMySQLQueryCheck = "SELECT MAX(ppayout_id) FROM crm_ppayout";
            const string iMySQLQuery =
                "insert into crm_ppayout(ppayout_name,ppayout_price,ppayout_time,ppayout_type,ppayout_backup,ppayout_id,ppayout_incash) values(@ppayout_name,@ppayout_price,@ppayout_time,@ppayout_type,@ppayout_backup,@ppayout_id,@ppayout_incash)";

            try
            {
                var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                iMySQLconn.Open();

                MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                string tempGoodAtrr = "9999";
                while (iMySQLReaderAttr.Read())
                {
                    try
                    {
                        tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                    }
                    catch (Exception)
                    {
                        tempGoodAtrr = "0";
                    }
                }
                iMySQLReaderAttr.Close();
                iMySQLCommand.CommandText = iMySQLQuery;

                iMySQLCommand.Parameters.Add("@ppayout_name", MySqlDbType.VarChar, 255).Value = iPayout.PayoutName;
                iMySQLCommand.Parameters.Add("@ppayout_price", MySqlDbType.VarChar, 10).Value = iPayout.PayoutPrice;
                iMySQLCommand.Parameters.Add("@ppayout_time", MySqlDbType.VarChar, 20).Value = iPayout.PayoutDate;
                iMySQLCommand.Parameters.Add("@ppayout_type", MySqlDbType.UInt16).Value = int.Parse(iPayout.PayoutType);
                iMySQLCommand.Parameters.Add("@ppayout_backup", MySqlDbType.VarChar, 255).Value = iPayout.PayoutBackup;
                iMySQLCommand.Parameters.Add("@ppayout_id", MySqlDbType.UInt16).Value = int.Parse(tempGoodAtrr) + 1;
                iMySQLCommand.Parameters.Add("@ppayout_incash", MySqlDbType.UInt16).Value = iPayout.PayoutInCase
                                                                                                ? "1"
                                                                                                : "0";
                iMySQLCommand.ExecuteNonQuery();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.ErrDesc = e.Message;
                iResult.isSuccess = false;
            }

            return iResult;
        }

        #endregion

        #region 删除支出

        public ReturnResult DeletePrivatePayout(int id)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "DELETE FROM crm_ppayout WHERE ppayout_id = " + id;
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.ExecuteNonQuery();


                iMySQLconn.Close();


                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #endregion

        #region 读取销售人员

        public string[] SellersPassword()
        {
            var tempManufacturer = new string[200];
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            const string mySelectQuery = "SELECT seller_password FROM crm_sellers ORDER BY seller_id";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempManufacturer[i] = (iMySQLReader.GetString(0));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempManufacturer = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempManufacturer;
        }

        public string[] SellersPosition()
        {
            var tempManufacturer = new string[200];
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            const string mySelectQuery = "SELECT seller_position FROM crm_sellers ORDER BY seller_id";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempManufacturer[i] = (iMySQLReader.GetString(0));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempManufacturer = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempManufacturer;
        }

        public string[] SellersIndex()
        {
            var tempManufacturer = new string[200];
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            const string mySelectQuery = "SELECT seller_name FROM crm_sellers ORDER BY seller_id";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempManufacturer[i] = (iMySQLReader.GetString(0));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempManufacturer = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempManufacturer;
        }

        public string[] Sellers()
        {
            var tempManufacturer = new string[200];
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            const string mySelectQuery = "SELECT seller_name FROM crm_sellers ORDER BY seller_id";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempManufacturer[i] = (iMySQLReader.GetString(0));
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempManufacturer = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempManufacturer;
        }

        private static string ReadSellerID(string SellerName)
        {
            string iSellerID = "";
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT seller_id FROM crm_sellers WHERE seller_name = '" + SellerName + "'";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    iSellerID = iMySQLReader.GetString(0);
                }

                iMySQLReader.Close();
                iMySQLconn.Close();
                iMySQLReader.Dispose();
            }
            catch (Exception)
            {
                iSellerID = "";
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return iSellerID;
        }

        private static string ReadSellerName(string SellerID)
        {
            string iSellerID = "";
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT seller_name FROM crm_sellers WHERE seller_id = '" + SellerID + "'";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    iSellerID = iMySQLReader.GetString(0);
                }

                iMySQLReader.Close();
                iMySQLconn.Close();
                iMySQLReader.Dispose();
            }
            catch (Exception)
            {
                iSellerID = "";
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return iSellerID;
        }

        public string ReadSellerPosition(string SellerName)
        {
            string SellerPosition = "";
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT seller_position FROM crm_sellers WHERE seller_name = '" + SellerName + "'";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    SellerPosition = iMySQLReader.GetString(0);
                }

                iMySQLReader.Close();
                iMySQLconn.Close();
                iMySQLReader.Dispose();
            }
            catch (Exception)
            {
                SellerPosition = "";
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return SellerPosition;
        }

        #endregion

        #region 读取提成.OLD

        public LXPhones[] ReadCommision_OLD(int SellerID, string Smonth)
        {
            var tempPhones = new LXPhones[10000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_phones WHERE phone_seller = " + SellerID +
                                   " AND phone_date LIKE '%" + Smonth + "%' ORDER BY phone_date";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempPhones[i].PhoneDate = iMySQLReader.GetString(1);
                    tempPhones[i].PhoneBrand = iMySQLReader.GetString(2);
                    tempPhones[i].PhoneName = ReadPhoneName(int.Parse(iMySQLReader.GetString(3)));
                    tempPhones[i].PhoneIMEI = iMySQLReader.GetString(4);
                    tempPhones[i].PhonePrice = iMySQLReader.GetString(5);

                    tempPhones[i].PhoneProfit = iMySQLReader.GetString(7);
                    tempPhones[i].PhoneRealPrice = iMySQLReader.GetString(8);
                    tempPhones[i].PhoneCommision = iMySQLReader.GetString(9);
                    switch (iMySQLReader.GetString(10))
                    {
                        case "0":
                            tempPhones[i].PhoneHasEquip = false;
                            break;
                        case "1":
                            tempPhones[i].PhoneHasEquip = true;
                            break;
                    }
                    switch (iMySQLReader.GetString(11))
                    {
                        case "0":
                            tempPhones[i].PhoneHasWarranty = false;
                            break;
                        case "1":
                            tempPhones[i].PhoneHasWarranty = true;
                            break;
                    }
                    tempPhones[i].PhoneWarrantyType = iMySQLReader.GetString(12);
                    tempPhones[i].PhoneWarrantyDuration = iMySQLReader.GetString(13);
                    tempPhones[i].PhoneIsDelete = iMySQLReader.GetString(15) != "0";
                    tempPhones[i].phone_supplier = iMySQLReader.GetString(16);

                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
            }
            catch (Exception)
            {
                tempPhones = null;
            }
            return tempPhones;
        }

        #endregion

        #region 读取利润.OLD

        public LXPhones[] ReadProfit_old(string Smonth)
        {
            var tempPhones = new LXPhones[10000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_phones WHERE phone_date LIKE '%" + Smonth +
                                   "%' ORDER BY phone_date";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;


            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempPhones[i].PhoneID = iMySQLReader.GetString(0);
                    tempPhones[i].PhoneDate = iMySQLReader.GetString(1);
                    tempPhones[i].PhoneBrand = iMySQLReader.GetString(2);
                    tempPhones[i].PhoneName = ReadPhoneName(int.Parse(iMySQLReader.GetString(3)));
                    tempPhones[i].PhoneIMEI = iMySQLReader.GetString(4);
                    tempPhones[i].PhonePrice = iMySQLReader.GetString(5);
                    tempPhones[i].PhoneSeller = iMySQLReader.GetString(6);
                    tempPhones[i].PhoneProfit = iMySQLReader.GetString(7);
                    tempPhones[i].PhoneRealPrice = iMySQLReader.GetString(8);
                    tempPhones[i].PhoneCommision = iMySQLReader.GetString(9);
                    tempPhones[i].PhoneHasEquip = iMySQLReader.GetString(10) != "0";
                    tempPhones[i].PhoneHasWarranty = iMySQLReader.GetString(11) != "0";
                    tempPhones[i].PhoneWarrantyType = iMySQLReader.GetString(12);
                    tempPhones[i].PhoneWarrantyDuration = iMySQLReader.GetString(13);
                    tempPhones[i].PhoneWarrantyDate = iMySQLReader.GetString(14);
                    tempPhones[i].PhoneIsDelete = iMySQLReader.GetString(15) != "0";
                    tempPhones[i].phone_supplier = iMySQLReader.GetString(16);
                    tempPhones[i].PhoneEquipPrice = iMySQLReader.GetString(17);
                    tempPhones[i].PhoneEquipRealPrice = iMySQLReader.GetString(18);
                    tempPhones[i].PhoneIsLegal = iMySQLReader.GetString(19) != "0";
                    tempPhones[i].PhoneIsHKLegal = iMySQLReader.GetString(20) != "0";
                    tempPhones[i].PhoneIsUnLegal = iMySQLReader.GetString(21) != "0";
                    tempPhones[i].PhoneWarrantyPrice = iMySQLReader.GetString(22);
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
            }
            catch (Exception)
            {
                tempPhones = null;
            }
            return tempPhones;
        }

        #endregion

        #region 请假管理

        public struct AskForLeave
        {
            public string AskDate;
            public string AskDuration;
            public int AskID;
            public string AskSeller;
            public string AskTip;
            public int AskType;
        }

        #region 修改请假

        public ReturnResult EditAsk(AskForLeave iAsk)
        {
            var iReturn = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string myUpdateQuery =
                "UPDATE crm_ask SET  ask_date = @ask_date, ask_type = @ask_type , ask_duration = @ask_duration , ask_tip = @ask_tip WHERE ask_id = " +
                iAsk.AskID;

            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);
            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@ask_date", MySqlDbType.VarChar, 10).Value = iAsk.AskDate;
                iMySQLCommand.Parameters.Add("@ask_type", MySqlDbType.UInt16).Value = iAsk.AskType;
                iMySQLCommand.Parameters.Add("@ask_duration", MySqlDbType.VarChar, 255).Value = iAsk.AskDuration;
                iMySQLCommand.Parameters.Add("@ask_tip", MySqlDbType.Text).Value = iAsk.AskTip;

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                Console.Write(e.Message);
                iReturn.ErrDesc = e.Message;
            }


            return iReturn;
        }

        #endregion

        #region 读取请假

        public AskForLeave[] ReadAsk(string Seller)
        {
            var tempAskForLeave = new AskForLeave[50000];

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_ask WHERE ask_seller = '" + ReadSellerID(Seller) +
                                   "' ORDER BY ask_date";
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReader.Read())
                {
                    tempAskForLeave[i].AskID = int.Parse(iMySQLReader.GetString(0));
                    tempAskForLeave[i].AskSeller = ReadSellerName(iMySQLReader.GetString(1));
                    tempAskForLeave[i].AskDate = iMySQLReader.GetString(2);
                    tempAskForLeave[i].AskType = int.Parse(iMySQLReader.GetString(3));
                    tempAskForLeave[i].AskDuration = iMySQLReader.GetString(4);
                    tempAskForLeave[i].AskTip = iMySQLReader.GetString(5);
                    i++;
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempAskForLeave = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempAskForLeave;
        }

        public AskForLeave ReadAskByID(string iID)
        {
            var tempAskForLeave = new AskForLeave();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "SELECT * FROM crm_ask WHERE ask_id = " + iID;
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    tempAskForLeave.AskID = int.Parse(iMySQLReader.GetString(0));
                    tempAskForLeave.AskSeller = ReadSellerName(iMySQLReader.GetString(1));
                    tempAskForLeave.AskDate = iMySQLReader.GetString(2);
                    tempAskForLeave.AskType = int.Parse(iMySQLReader.GetString(3));
                    tempAskForLeave.AskDuration = iMySQLReader.GetString(4);
                    tempAskForLeave.AskTip = iMySQLReader.GetString(5);
                }

                iMySQLReader.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempAskForLeave = default(AskForLeave);
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempAskForLeave;
        }

        #endregion

        #region 增加请假

        public ReturnResult AddAsk(AskForLeave iAsk)
        {
            var iResult = new ReturnResult();
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            const string iMySQLQueryCheck = "SELECT MAX(ask_id) FROM crm_ask";
            const string iMySQLQuery =
                "insert into crm_ask(ask_id,ask_seller,ask_date,ask_type,ask_duration,ask_tip) values(@ask_id,@ask_seller,@ask_date,@ask_type,@ask_duration,@ask_tip)";

            try
            {
                var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
                iMySQLconn.Open();

                MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                string tempGoodAtrr = "9999";
                while (iMySQLReaderAttr.Read())
                {
                    try
                    {
                        tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                    }
                    catch (Exception)
                    {
                        tempGoodAtrr = "0";
                    }
                }
                iMySQLReaderAttr.Close();
                iMySQLCommand.CommandText = iMySQLQuery;

                iMySQLCommand.Parameters.Add("@ask_id", MySqlDbType.UInt24).Value = int.Parse(tempGoodAtrr) + 1;
                iMySQLCommand.Parameters.Add("@ask_seller", MySqlDbType.VarChar, 100).Value =
                    ReadSellerID(iAsk.AskSeller);
                iMySQLCommand.Parameters.Add("@ask_date", MySqlDbType.VarChar, 10).Value = iAsk.AskDate;
                iMySQLCommand.Parameters.Add("@ask_type", MySqlDbType.UInt16).Value = iAsk.AskType;
                iMySQLCommand.Parameters.Add("@ask_duration", MySqlDbType.VarChar, 255).Value = iAsk.AskDuration;
                iMySQLCommand.Parameters.Add("@ask_tip", MySqlDbType.Text).Value = iAsk.AskTip;
                iMySQLCommand.ExecuteNonQuery();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.ErrDesc = e.Message;
                iResult.isSuccess = false;
            }

            return iResult;
        }

        #endregion

        #region 删除请假

        public ReturnResult DeleteAsk(string iID)
        {
            var iResult = new ReturnResult();

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string iMySQLQueryCheck = "DELETE FROM crm_ask WHERE ask_id = " + iID;
            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);

            try
            {
                iMySQLconn.Open();

                iMySQLCommand.ExecuteNonQuery();


                iMySQLconn.Close();


                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #endregion

        #endregion

        #region LongXiangTools 操作

        #region 修改存在手机的信息入库

        public string UpdataPhonePrice(SPhoneInfo iTempInfo, string PhoneID)
        {
            //var iReturn = new ReturnResult { isSuccess = false };
            string retrunStr = "";

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string myUpdateQuery =
                "UPDATE ecs_goods SET click_count = shop_price = @shop_price, market_price = @market_price WHERE goods_id=" +
                PhoneID;

            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);
            try
            {
                iMySQLconn.Open();
                if (iTempInfo.ColorPrice != null)
                {
                    double tempPrice = double.Parse(iTempInfo.ColorPrice[0].Price);
                    for (int i = 0; i < iTempInfo.ColorPrice.Length; i++)
                    {
                        if (string.IsNullOrEmpty(iTempInfo.ColorPrice[i].Color)) continue;
                        if (tempPrice > double.Parse(iTempInfo.ColorPrice[i].Price))
                        {
                            tempPrice = double.Parse(iTempInfo.ColorPrice[i].Price);
                        }
                    }
                    double tempMarketPrice = tempPrice*1.2;


                    iMySQLCommand.Parameters.Add("@market_price", MySqlDbType.Decimal).Value = tempMarketPrice;
                    iMySQLCommand.Parameters.Add("@shop_price", MySqlDbType.Decimal).Value = tempPrice;

                    iMySQLCommand.ExecuteNonQuery();

                    string myDeletePriceQuery = "DELETE FROM ecs_goods_attr WHERE attr_id = 82 AND goods_id=" + PhoneID;
                    iMySQLCommand.CommandText = myDeletePriceQuery;
                    iMySQLCommand.ExecuteNonQuery();

                    //string myUpdateAttrQuery = "UPDATE ecs_goods_attr SET attr_value = @attr_value, attr_price = @attr_price WHERE attr_id = 82 AND goods_id=" + PhoneID;

                    const string iMySQLAttrMaxQuery = "SELECT MAX(goods_attr_id) FROM ecs_goods_attr";

                    iMySQLCommand.CommandText = iMySQLAttrMaxQuery;
                    MySqlDataReader iMySQLReaderAttr = iMySQLCommand.ExecuteReader();
                    string tempGoodAtrr = "9999";
                    while (iMySQLReaderAttr.Read())
                    {
                        try
                        {
                            tempGoodAtrr = (iMySQLReaderAttr.GetString(0));
                        }
                        catch (Exception)
                        {
                            tempGoodAtrr = "0";
                        }
                    }
                    iMySQLReaderAttr.Close();

                    const string myUpdateAttrQuery =
                        "insert into ecs_goods_attr(goods_attr_id,goods_id,attr_id,attr_value,attr_price) values(@goods_attr_id,@goods_id2,@attr_id,@attr_value,@attr_price)";

                    iMySQLCommand.CommandText = myUpdateAttrQuery;
                    iMySQLCommand.Parameters.Add("@goods_attr_id", MySqlDbType.UInt24);
                    iMySQLCommand.Parameters.Add("@goods_id2", MySqlDbType.UInt32);
                    iMySQLCommand.Parameters.Add("@attr_id", MySqlDbType.UInt16);
                    iMySQLCommand.Parameters.Add("@attr_value", MySqlDbType.Text);
                    iMySQLCommand.Parameters.Add("@attr_price", MySqlDbType.VarChar, 255);

                    for (int i = 0; i < iTempInfo.ColorPrice.Length; i++)
                    {
                        if (string.IsNullOrEmpty(iTempInfo.ColorPrice[i].Color)) continue;
                        iMySQLCommand.Parameters["@goods_attr_id"].Value = int.Parse(tempGoodAtrr) + 1 + i;
                        iMySQLCommand.Parameters["@goods_id2"].Value = PhoneID;
                        iMySQLCommand.Parameters["@attr_id"].Value = 82;
                        iMySQLCommand.Parameters["@attr_value"].Value = iTempInfo.ColorPrice[i].Color;
                        iMySQLCommand.Parameters["@attr_price"].Value = iTempInfo.ColorPrice[i].Price;
                        iMySQLCommand.ExecuteNonQuery();
                    }
                }
                iMySQLconn.Close();
                //iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                //iReturn.isSuccess = false;
                Console.Write(e.Message);
                //iReturn.ErrDesc = e.Message;
                retrunStr = e.Message;
            }


            return retrunStr;
        }

        #endregion

        #region 清空缓存

        public ReturnResult CleanDB(string DBName)
        {
            var iResult = new ReturnResult {isSuccess = false};
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery = "truncate table " + DBName;
            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);


            try
            {
                iMySQLconn.Open();

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #region 转换UC产品的时间

        private static string GetUCTime(string UCstring)
        {
            DateTime iUCBaseTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(int.Parse(UCstring));
            // iUCBaseTime.AddSeconds(100);
            return (iUCBaseTime.Year + iUCBaseTime.Month.ToString().PadLeft(2, '0') +
                    iUCBaseTime.Day.ToString().PadLeft(2, '0'));
        }

        #endregion

        #region 二手信息管理

        public struct SecondHands
        {
            public string PhoneBrand; //手机品牌
            public string PhoneBuyPlace; //1
            public string PhoneBuyTime; //1
            //public string PhoneClass; //审核登记
            //public string PhoneContect; // 1
            public string PhoneEquip; //配件 1
            public bool PhoneHasCheck; //发票 1
            public string PhoneID; //ID 1
            // ReSharper disable MemberHidesStaticFromOuterClass
            public string PhoneInfo; //手机信息 1
            // ReSharper restore MemberHidesStaticFromOuterClass
            public string PhoneName; //手机型号 1
            public string PhoneNew; //手机新旧 1
            //public string PhoneNewsType; //手机分类 1
            public string PhonePicture; //手机图片 1

            public string PhonePictureBack;
            public string PhonePictureOther1;
            public string PhonePictureOther2;
            public string PhonePictureOther3;

            public string PhonePrice;
            public string PhonePublicTime;
            //public string PhoneQQ;
            public string PhoneType; //手机类型 1
            public string PublicName; //上传者名称 1
        }

        #region 获取二手信息

        public SecondHands[] GetSecondHands(int NumLimit)
        {
            //
            int TempInt = 0;
            SecondHands[] tempSecondHands;
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            const string iMySQLQueryCheck = "SELECT COUNT(*) FROM site_secondhanditems";
            string mySelectItemQuery = "SELECT * FROM site_secondhanditems LIMIT " + NumLimit;
            string mySelectMessageQuery = "SELECT * FROM site_secondhandmessage LIMIT " + NumLimit;

            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    TempInt = int.Parse(iMySQLReader.GetString(0));
                }

                iMySQLReader.Close();

                tempSecondHands = NumLimit > TempInt ? new SecondHands[TempInt] : new SecondHands[NumLimit];

                iMySQLCommand.CommandText = mySelectItemQuery;
                MySqlDataReader iMySQLReaderCommonAttr = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReaderCommonAttr.Read())
                {
                    tempSecondHands[i].PhoneID = iMySQLReaderCommonAttr.GetString(0);
                    //tempSecondHands[i].PhoneNewsType = iMySQLReaderCommonAttr.GetString(1);
                    tempSecondHands[i].PublicName = iMySQLReaderCommonAttr.GetString(4);
                    tempSecondHands[i].PhoneName = iMySQLReaderCommonAttr.GetString(5);
                    tempSecondHands[i].PhonePicture = iMySQLReaderCommonAttr.GetString(6);
                    tempSecondHands[i].PhonePublicTime = GetUCTime(iMySQLReaderCommonAttr.GetString(8));

                    //tempSecondHands[i].PhoneBuyTime = GetUCTime(iMySQLReaderCommonAttr.GetString(15));
                    //tempSecondHands[i].PhoneType = iMySQLReaderCommonAttr.GetString(16);
                    //tempSecondHands[i].PhoneHasCheck = iMySQLReaderCommonAttr.GetString(17) == "是";

                    i++;
                }
                iMySQLReaderCommonAttr.Close();

                iMySQLCommand.CommandText = mySelectMessageQuery;

                MySqlDataReader iMySQLReaderAdvAttr = iMySQLCommand.ExecuteReader();
                i = 0;
                while (iMySQLReaderAdvAttr.Read())
                {
                    tempSecondHands[i].PhoneInfo = iMySQLReaderAdvAttr.GetString(2);
                    tempSecondHands[i].PhoneBrand = iMySQLReaderAdvAttr.GetString(5);
                    tempSecondHands[i].PhoneEquip = iMySQLReaderAdvAttr.GetString(6);
                    tempSecondHands[i].PhoneHasCheck = iMySQLReaderAdvAttr.GetString(7) == "是";
                    tempSecondHands[i].PhoneNew = iMySQLReaderAdvAttr.GetString(8);

                    tempSecondHands[i].PhoneBuyPlace = iMySQLReaderAdvAttr.GetString(9);
                    tempSecondHands[i].PhoneBuyTime = iMySQLReaderAdvAttr.GetString(10);
                    tempSecondHands[i].PhonePictureBack = iMySQLReaderAdvAttr.GetString(11);
                    tempSecondHands[i].PhonePictureOther1 = iMySQLReaderAdvAttr.GetString(12);
                    tempSecondHands[i].PhonePictureOther2 = iMySQLReaderAdvAttr.GetString(13);

                    //tempSecondHands[i].PhoneQQ = iMySQLReaderAdvAttr.GetString(14);
                    //tempSecondHands[i].PhonePrice = iMySQLReaderAdvAttr.GetString(14);
                    i++;
                }
                iMySQLReaderAdvAttr.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempSecondHands = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempSecondHands;
        }

        #endregion

        #region 删除二手信息

        public ReturnResult DelSecondHands(int SDIndex)
        {
            var iResult = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string myDeleteQueryBasic = "DELETE FROM site_secondhanditems WHERE itemid =" + SDIndex;
            string myDeleteQueryAdvance = "DELETE FROM site_secondhandmessage WHERE itemid =" + SDIndex;
            var iMySQLCommand = new MySqlCommand(myDeleteQueryBasic, iMySQLconn);
            try
            {
                iMySQLconn.Open();
                iMySQLCommand.ExecuteNonQuery();

                iMySQLCommand.CommandText = myDeleteQueryAdvance;
                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #region 修改二手价格

        public ReturnResult ChangeSecondHands(string SHid, string Price)
        {
            var iReturn = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string myUpdateQuery =
                "UPDATE site_secondhandmessage SET price = @price WHERE itemid = " +
                SHid;

            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);
            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@price", MySqlDbType.VarChar, 10).Value = Price;

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                Console.Write(e.Message);
                iReturn.ErrDesc = e.Message;
            }


            return iReturn;
        }

        #endregion

        #endregion

        #region 核查网站新闻

        public ReturnResult CheckSiteNews()
        {
            var iResult = new ReturnResult();
            iResult.isSuccess = false;

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery =
                "SELECT COUNT(*) FROM site_spaceitems";

            string mySelectItemSubjectQuery =
                "SELECT itemid,subject FROM site_spaceitems";

            string DeleteItemsQuery = "DELETE FROM site_spaceitems WHERE itemid = ";
            string DeleteNewsQuery = "DELETE FROM site_spacenews WHERE itemid = ";

            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;
            MySqlDataReader iMySQLSubjectReader;
            int iItem = 0;
            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    iItem = int.Parse(iMySQLReader.GetString(0));
                }

                iMySQLReader.Close();
                var tempSubject = new string[iItem];
                var tempItemID = new int[iItem];
                int i = 0;
                iMySQLCommand.CommandText = mySelectItemSubjectQuery;
                iMySQLSubjectReader = iMySQLCommand.ExecuteReader();
                while (iMySQLSubjectReader.Read())
                {
                    tempItemID[i] = int.Parse(iMySQLSubjectReader.GetString(0));
                    tempSubject[i] = iMySQLSubjectReader.GetString(1);
                    i++;
                }
                iMySQLSubjectReader.Close();

                for (int j = 0; j < iItem; j++)
                {
                    if (tempSubject[j].Substring(0, 1) == "<")
                    {
                        iMySQLCommand.CommandText = DeleteItemsQuery + tempItemID[j];
                        iMySQLCommand.ExecuteNonQuery();
                        iMySQLCommand.CommandText = DeleteNewsQuery + tempItemID[j];
                        iMySQLCommand.ExecuteNonQuery();
                    }
                }

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return iResult;
        }

        #endregion

        #region 核查市场价格

        public void EditPrice(double iPrice, string[] tempID, int j)
        {
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string myUpdateItemPrice =
                "UPDATE ecs_goods SET market_price = @market_price, shop_price = @shop_price WHERE goods_id= ";
            var iMySQLCommand = new MySqlCommand(myUpdateItemPrice, iMySQLconn);
            try
            {
                iMySQLconn.Open();
                iMySQLCommand.CommandText = myUpdateItemPrice + tempID[j];

                double tempPrice = iPrice;
                double tempMarketPrice = iPrice*1.2;

                iMySQLCommand.Parameters.Add("@market_price", MySqlDbType.Decimal).Value = tempMarketPrice;
                iMySQLCommand.Parameters.Add("@shop_price", MySqlDbType.Decimal).Value = tempPrice;

                iMySQLCommand.ExecuteNonQuery();
                iMySQLconn.Close();
                //iMySQLconn.Dispose();
            }
            catch (Exception)
            {
                return;
            }
        }

        public ReturnResult CheckMarketPrice()
        {
            var iResult = new ReturnResult();
            iResult.isSuccess = false;

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string mySelectQuery =
                "SELECT COUNT(*) FROM ecs_goods";

            string mySelectItemIDQuery =
                "SELECT goods_id FROM ecs_goods";
            //SELECT attr_price FROM ecs_goods_attr WHERE attr_id = 82 AND goods_id = 28 ORDER BY attr_price 
            string mySelectItemPriceQuery = "SELECT attr_price FROM ecs_goods_attr WHERE attr_id = 82 AND goods_id = ";
            string mySelectItemPriceAddQuery = " ORDER BY attr_price DESC";

            var iMySQLCommand = new MySqlCommand(mySelectQuery, iMySQLconn);
            MySqlDataReader iMySQLReader;
            MySqlDataReader iMySQLIDReader;
            MySqlDataReader iMySQLPriceReader;
            int iItem = 0;
            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    iItem = int.Parse(iMySQLReader.GetString(0));
                }

                iMySQLReader.Close();
                iMySQLCommand.CommandText = mySelectItemIDQuery;
                iMySQLIDReader = iMySQLCommand.ExecuteReader();
                var tempID = new string[iItem];
                int i = 0;
                while (iMySQLIDReader.Read())
                {
                    tempID[i] = iMySQLIDReader.GetString(0);
                    i++;
                }
                iMySQLIDReader.Close();

                for (int j = 0; j < iItem; j++)
                {
                    iMySQLCommand.CommandText = mySelectItemPriceQuery + tempID[j] + mySelectItemPriceAddQuery;
                    iMySQLPriceReader = iMySQLCommand.ExecuteReader();
                    double iPrice = 0;
                    while (iMySQLPriceReader.Read())
                    {
                        iPrice = double.Parse(iMySQLPriceReader.GetString(0));
                    }

                    iMySQLPriceReader.Close();
                    EditPrice(iPrice, tempID, j);
                }


                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return iResult;
        }

        #endregion

        #region 用户咨询

        public struct QnA
        {
            public string QAAnswer;
            public string QAImage;
            public string QAPublicEmail;
            public string QAPublicName;
            public string QAPublicTime;
            public string QAQuestion;
            public string QAQuestionDetail;
            public string QAid;
        }

        #region 获取用户咨询

        public QnA[] GetQnA(int NumLimit)
        {
            int TempInt = 0;
            QnA[] tempSecondHands;
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            const string iMySQLQueryCheck = "SELECT COUNT(*) FROM site_qaaitems";
            string mySelectItemQuery = "SELECT * FROM site_qaaitems LIMIT " + NumLimit;
            string mySelectMessageQuery = "SELECT * FROM site_qaamessage LIMIT " + NumLimit;

            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    TempInt = int.Parse(iMySQLReader.GetString(0));
                }

                iMySQLReader.Close();

                tempSecondHands = NumLimit > TempInt ? new QnA[TempInt] : new QnA[NumLimit];

                iMySQLCommand.CommandText = mySelectItemQuery;
                MySqlDataReader iMySQLReaderCommonAttr = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReaderCommonAttr.Read())
                {
                    tempSecondHands[i].QAid = iMySQLReaderCommonAttr.GetString(0);
                    tempSecondHands[i].QAPublicName = iMySQLReaderCommonAttr.GetString(4);
                    tempSecondHands[i].QAQuestion = iMySQLReaderCommonAttr.GetString(5);
                    tempSecondHands[i].QAImage = iMySQLReaderCommonAttr.GetString(6);
                    tempSecondHands[i].QAPublicTime = GetUCTime(iMySQLReaderCommonAttr.GetString(8));

                    i++;
                }
                iMySQLReaderCommonAttr.Close();

                iMySQLCommand.CommandText = mySelectMessageQuery;

                MySqlDataReader iMySQLReaderAdvAttr = iMySQLCommand.ExecuteReader();
                i = 0;
                while (iMySQLReaderAdvAttr.Read())
                {
                    tempSecondHands[i].QAQuestionDetail = iMySQLReaderAdvAttr.GetString(2);
                    tempSecondHands[i].QAPublicEmail = iMySQLReaderAdvAttr.GetString(5);
                    tempSecondHands[i].QAAnswer = iMySQLReaderAdvAttr.GetString(6);
                    i++;
                }
                iMySQLReaderAdvAttr.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempSecondHands = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempSecondHands;
        }

        #endregion

        #region 删除用户咨询

        public ReturnResult DelQA(int SDIndex)
        {
            var iResult = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string myDeleteQueryBasic = "DELETE FROM site_qaaitems WHERE itemid =" + SDIndex;
            string myDeleteQueryAdvance = "DELETE FROM site_qaamessage WHERE itemid =" + SDIndex;
            var iMySQLCommand = new MySqlCommand(myDeleteQueryBasic, iMySQLconn);
            try
            {
                iMySQLconn.Open();
                iMySQLCommand.ExecuteNonQuery();

                iMySQLCommand.CommandText = myDeleteQueryAdvance;
                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #region 修改用户咨询

        public ReturnResult ChangeQA(string SHid, string Answer)
        {
            var iReturn = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string myUpdateQuery =
                "UPDATE site_qaamessage SET answer = @answer WHERE itemid = " +
                SHid;

            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);
            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@answer", MySqlDbType.Text).Value = Answer;

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                Console.Write(e.Message);
                iReturn.ErrDesc = e.Message;
            }


            return iReturn;
        }

        #endregion

        #endregion

        #endregion

        #region LongXiangTutorial 操作

        #region 教程操作

        public struct LXTutorial
        {
            public string iImage;
            public string iSubType;
            public string iTContent;
            public string iTID;
            public string iTPublicTime;
            public string iTTitle;
            public string iType;
        }

        #region 读取教程

        private string iReadTutorialType(string catid)
        {
            string iReturn = "";
            string iTemp = "";
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string CheckTypeName = "SELECT name,upid FROM site_categories WHERE catid = ";

            string iTempUpid = "0";

            var iMySQLCommand = new MySqlCommand(CheckTypeName + catid, iMySQLconn);
            MySqlDataReader iMySQLReader;
            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    iReturn = iMySQLReader.GetString(0); //subType
                    iTempUpid = iMySQLReader.GetString(1);
                }

                iMySQLReader.Close();

                iMySQLCommand.CommandText = CheckTypeName + iTempUpid;

                MySqlDataReader iMySQLReaderType = iMySQLCommand.ExecuteReader();
                while (iMySQLReaderType.Read())
                {
                    iTemp = iMySQLReaderType.GetString(0);
                }
                iMySQLReaderType.Close();
                iReturn = iReturn + "|" + iTemp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                iReturn = "";
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return iReturn;
        }


        public LXTutorial[] GetLXTutorial()
        {
            int TempInt = 0;
            LXTutorial[] tempSecondHands;
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            const string iMySQLQueryCheck = "SELECT COUNT(*) FROM site_courseitems";
            string mySelectItemQuery = "SELECT * FROM site_courseitems";
            string mySelectMessageQuery = "SELECT * FROM site_coursemessage";
            string iTempCatid = "0";

            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    TempInt = int.Parse(iMySQLReader.GetString(0));
                }

                iMySQLReader.Close();
                tempSecondHands = new LXTutorial[TempInt];
                //tempSecondHands = NumLimit > TempInt ? new LXTutorial[TempInt] : new LXTutorial[NumLimit];

                iMySQLCommand.CommandText = mySelectItemQuery;
                MySqlDataReader iMySQLReaderCommonAttr = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReaderCommonAttr.Read())
                {
                    tempSecondHands[i].iTID = iMySQLReaderCommonAttr.GetString(0);
                    iTempCatid = iMySQLReaderCommonAttr.GetString(1);
                    tempSecondHands[i].iTTitle = iMySQLReaderCommonAttr.GetString(5);
                    tempSecondHands[i].iImage = iMySQLReaderCommonAttr.GetString(6);
                    tempSecondHands[i].iTPublicTime = GetUCTime(iMySQLReaderCommonAttr.GetString(8));
                    string iTemp = iReadTutorialType(iTempCatid);
                    string[] iArray = iTemp.Split('|');
                    tempSecondHands[i].iSubType = iArray[0];
                    tempSecondHands[i].iType = iArray[1];
                    i++;
                }
                iMySQLReaderCommonAttr.Close();
                /////////////////////
                iMySQLCommand.CommandText = mySelectMessageQuery;

                MySqlDataReader iMySQLReaderAdvAttr = iMySQLCommand.ExecuteReader();
                i = 0;
                while (iMySQLReaderAdvAttr.Read())
                {
                    tempSecondHands[i].iTContent = iMySQLReaderAdvAttr.GetString(2);
                    i++;
                }
                iMySQLReaderAdvAttr.Close();

                //////////////////////////


                iMySQLconn.Close();
                iMySQLReader.Dispose();
                //tempManufacturer = null;
                //iMySQLconn.Close();
            }
            catch (Exception)
            {
                tempSecondHands = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempSecondHands;
        }

        #endregion

        #region 删除教程

        public ReturnResult DelLXTutorial(int SDIndex)
        {
            var iResult = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string myDeleteQueryBasic = "DELETE FROM site_courseitems WHERE itemid =" + SDIndex;
            string myDeleteQueryAdvance = "DELETE FROM site_coursemessage WHERE itemid =" + SDIndex;
            var iMySQLCommand = new MySqlCommand(myDeleteQueryBasic, iMySQLconn);
            try
            {
                iMySQLconn.Open();
                iMySQLCommand.ExecuteNonQuery();

                iMySQLCommand.CommandText = myDeleteQueryAdvance;
                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #region 添加教程

        public ReturnResult AddLXTutorial(string iTitle, string iImage, string iContent)
        {
            var iReturn = new ReturnResult {isSuccess = false};


            return iReturn;
        }

        #endregion

        #region 修改教程

        public ReturnResult ChangeLXTutorial(string SHid, string message)
        {
            var iReturn = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            string myUpdateQuery =
                "UPDATE site_coursemessage SET message = @message WHERE itemid = " +
                SHid;

            var iMySQLCommand = new MySqlCommand(myUpdateQuery, iMySQLconn);
            try
            {
                iMySQLconn.Open();

                iMySQLCommand.Parameters.Add("@answer", MySqlDbType.Text).Value = message;

                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();
                iReturn.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iReturn.isSuccess = false;
                Console.Write(e.Message);
                iReturn.ErrDesc = e.Message;
            }


            return iReturn;
        }

        #endregion

        #endregion

        #region 常用软件下载

        public struct LXDownload
        {
            public string iDownloadlink;
            public string iImage;
            public string iTContent;
            public string iTID;
            public string iTTitle;
        }

        #region 删除软件

        public ReturnResult DelLXDownload(int SDIndex)
        {
            var iResult = new ReturnResult {isSuccess = false};

            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");

            string myDeleteQueryBasic = "DELETE FROM site_downloaditems WHERE itemid =" + SDIndex;
            string myDeleteQueryAdvance = "DELETE FROM site_downloadmessage WHERE itemid =" + SDIndex;
            var iMySQLCommand = new MySqlCommand(myDeleteQueryBasic, iMySQLconn);
            try
            {
                iMySQLconn.Open();
                iMySQLCommand.ExecuteNonQuery();

                iMySQLCommand.CommandText = myDeleteQueryAdvance;
                iMySQLCommand.ExecuteNonQuery();

                iMySQLconn.Close();

                iResult.isSuccess = true;
            }
            catch (MySqlException e)
            {
                iResult.isSuccess = false;
                iResult.ErrDesc = e.Message;
            }

            return iResult;
        }

        #endregion

        #region 查看软件

        public LXDownload[] GetLXDownload()
        {
            int TempInt = 0;
            LXDownload[] tempSecondHands;
            var iMySQLconn =
                new MySqlConnection("Server=" + iMySQLIP + ";Database=" + iMySQLDatabase + ";Uid=" + iMySQLAccount +
                                    ";Pwd=" + iMySQLPassword + ";CharSet=gbk;Compress=true;Encrypt=true;");
            const string iMySQLQueryCheck = "SELECT COUNT(*) FROM site_downloaditems";
            string mySelectItemQuery = "SELECT * FROM site_downloaditems";
            string mySelectMessageQuery = "SELECT * FROM site_downloadmessage";

            var iMySQLCommand = new MySqlCommand(iMySQLQueryCheck, iMySQLconn);
            MySqlDataReader iMySQLReader;

            try
            {
                iMySQLconn.Open();
                iMySQLReader = iMySQLCommand.ExecuteReader();
                while (iMySQLReader.Read())
                {
                    TempInt = int.Parse(iMySQLReader.GetString(0));
                }

                iMySQLReader.Close();
                tempSecondHands = new LXDownload[TempInt];
                //tempSecondHands = NumLimit > TempInt ? new LXTutorial[TempInt] : new LXTutorial[NumLimit];

                iMySQLCommand.CommandText = mySelectItemQuery;
                MySqlDataReader iMySQLReaderCommonAttr = iMySQLCommand.ExecuteReader();
                int i = 0;
                while (iMySQLReaderCommonAttr.Read())
                {
                    tempSecondHands[i].iTID = iMySQLReaderCommonAttr.GetString(0);
                    tempSecondHands[i].iTTitle = iMySQLReaderCommonAttr.GetString(5);
                    tempSecondHands[i].iImage = iMySQLReaderCommonAttr.GetString(6);
                    i++;
                }
                iMySQLReaderCommonAttr.Close();
                /////////////////////
                iMySQLCommand.CommandText = mySelectMessageQuery;

                MySqlDataReader iMySQLReaderAdvAttr = iMySQLCommand.ExecuteReader();
                i = 0;
                while (iMySQLReaderAdvAttr.Read())
                {
                    tempSecondHands[i].iTContent = iMySQLReaderAdvAttr.GetString(2);
                    tempSecondHands[i].iDownloadlink = iMySQLReaderAdvAttr.GetString(5);
                    i++;
                }
                iMySQLReaderAdvAttr.Close();

                iMySQLconn.Close();
                iMySQLReader.Dispose();
            }
            catch (Exception)
            {
                tempSecondHands = null;
            }

            iMySQLCommand.Dispose();
            iMySQLconn.Dispose();

            return tempSecondHands;
        }

        #endregion

        #endregion

        #endregion

        #region 初始化数据

        #endregion
    }
}