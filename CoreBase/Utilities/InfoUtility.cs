using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using CoreBase.Help;
using Newtonsoft.Json;
using static CoreBase.Help.EnumUtility;

namespace CoreBase.Utilities
{
    /// <summary>
    /// 登入者資訊
    /// </summary>
    public class InfoUtility
    {
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 院區
        /// </summary>
        public EnumUtility.HISLOCATION HISLOCATION { get; set; } = HISLOCATION.NeiHu;

        /// <summary>
        /// 登入時間
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 測試模式(資料庫)
        /// </summary>
        public bool TestMode { get; set; } = true;

        /// <summary>
        /// 平測模式(資料庫)
        /// </summary>
        public bool TestMode2 { get; set; } = true;

        /// <summary>
        /// 測試程式
        /// </summary>
        public bool TestAp { get; set; } = true;

        /// <summary>
        /// 平測測試區
        /// </summary>
        public bool TestAp2 { get; set; } = true;

        /// <summary>
        /// 居家照護
        /// </summary>
        public bool HomeCare { get; set; } = false;

        /// <summary>
        /// 電腦IP
        /// </summary>
        public string IP { get; set; } = "0.0.0.0";

        /// <summary>
        /// 電腦名稱
        /// </summary>
        public string MACHINENAME { get; set; } = string.Empty;

        /// <summary>
        /// 呼叫的為網頁
        /// </summary>
        public bool IsWeb { get; set; } = false;

        /// <summary>
        /// Web Domain
        /// </summary>
        public string WebDomain { get; set; } = EnumUtility.EnvironmentUrlType.Web_Developed.GetEnumDescription();

        /// <summary>
        /// API Domain
        /// </summary>
        public string APIDomain { get; set; } = EnumUtility.EnvironmentUrlType.Web_Developed.GetEnumDescription();

        /// <summary>
        /// Dmain List
        /// first: WebDomain, Second: APIDomain
        /// </summary>
        public List<string> DomainList { get; set; } = new List<string> { EnumUtility.EnvironmentUrlType.Web_Online_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.API_Online_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.IPD_API_Online_LoadBalance.GetEnumDescription() };

        /// <summary>
        /// 執行環境
        /// </summary>
        public EnvironmentType EnvironmentType { get; set; } = EnvironmentType.Default;

        /// <summary>
        /// 讀取之XML檔案路徑
        /// </summary>
        public string READ_XML_FILE_PATH { get; set; }

        /// <summary>
        /// 當無法判斷環境區域時候是否使用預設平測區[預設False]
        /// </summary>
        private bool OVERWRITE_XML_SETTING { get; set; } = false;
        /// <summary>
        /// 是否忽略讀取XML設定檔(此設定會導致連線字串與所有設定數值皆為Null或是預設數值，請謹慎使用)
        /// </summary>
        private bool IsIgnoreXmlSettings { get; set; } = false;
        /// <summary>
        /// 當OVERWRITE_XML_SETTING與 IsIgnoreXmlSettings 皆為 True,時候更改USERID 為此ID
        /// </summary>
        private string SetDefaultTSGHMENUUserId { get; set; }



        #region XML 結構
        /// <summary>
        /// XML頂層結構
        /// </summary>
        public class LoginInfo_Structure
        {
            public LoginInfo_Public DocumentElement;
        }

        /// <summary>
        /// XML 結構
        /// </summary>
        private class LoginInfo
        {
            public TB_INF tb_inf { get; set; }
        }

        public class LoginInfo_Public
        {
            public TB_INF tb_inf { get; set; }
        }

        /// <summary>
        /// XML結點
        /// </summary>
        public class TB_INF
        {
            /// <summary>
            /// IP
            /// </summary>
            public string IP { get; set; }

            /// <summary>
            /// 院區
            /// </summary>
            public string HISLOCATION { get; set; }

            /// <summary>
            /// 使用者帳號
            /// </summary>
            public string USER { get; set; }

            /// <summary>
            /// 登入時間
            /// </summary>
            public string LOGIN_IN_DATETIME { get; set; }

            /// <summary>
            /// 測試資料(資料庫)
            /// </summary>
            public string TESTMODE { get; set; }

            /// <summary>
            /// 測試版程式
            /// </summary>
            public string TESTAP { get; set; }

            /// <summary>
            /// 平測資料(資料庫)
            /// </summary>
            public string TESTMODE2 { get; set; }

            /// <summary>
            /// 平測版程式
            /// </summary>
            public string TESTAP2 { get; set; }


            /// <summary>
            /// 居家照護
            /// </summary>
            public string HOMECARE { get; set; }

            /// <summary>
            /// 其他說明:
            /// </summary>
            public string NOTE { get; set; }

        }
        #endregion XML 結構

        /// <summary>
        /// 宣告
        /// </summary>
        public InfoUtility()
        {
            initInfo();
        }
        /// <summary>
        /// 宣告
        /// </summary>
        /// <param name="OverWrite_Xml_Setting">當無法判斷環境區域時候是否使用預設平測區[預設False]</param>
        public InfoUtility(bool OverWrite_Xml_Setting = false)
        {
            OVERWRITE_XML_SETTING = OverWrite_Xml_Setting;
            initInfo();
        }

        /// <summary>
        /// 宣告
        /// </summary>
        /// <param name="OverWrite_Xml_Setting">當無法判斷環境區域時候是否使用預設平測區[預設False]</param>
        /// <param name="IsIgnoreXmlSettings">是否忽略XML檔案判斷，不讀取任何資料[預設False]</param>
        public InfoUtility(bool OverWrite_Xml_Setting = false, bool IsIgnoreXmlSettings = false)
        {
            OVERWRITE_XML_SETTING = OverWrite_Xml_Setting;
            this.IsIgnoreXmlSettings = IsIgnoreXmlSettings;
            initInfo();
        }

        /// <summary>
        /// 宣告
        /// </summary>
        /// <param name="OverWrite_Xml_Setting">當無法判斷環境區域時候是否使用預設平測區[預設False]</param>
        /// <param name="IsIgnoreXmlSettings">是否忽略XML檔案判斷，不讀取任何資料[預設False]</param>
        public InfoUtility(bool OverWrite_Xml_Setting = false, bool IsIgnoreXmlSettings = false, string SetDefaultUserId = null)
        {
            OVERWRITE_XML_SETTING = OverWrite_Xml_Setting;
            this.IsIgnoreXmlSettings = IsIgnoreXmlSettings;
            if (OverWrite_Xml_Setting)
            {
                if (IsIgnoreXmlSettings)
                {
                    SetDefaultTSGHMENUUserId = SetDefaultUserId ?? string.Empty;
                }
            }
            initInfo();
        }

        /// <summary>
        /// 資訊初始化
        /// </summary>
        public void initInfo()
        {
            try
            {
                if (System.Web.HttpRuntime.AppDomainAppId != null)
                {
                    // Web 時資料抓何處
                    IsWeb = true;
                }
                else
                {
                    // WinForm時抓xml

                    //LoginInfo xml;
                    //var PackageOrderRoot = GetType().Assembly.Location.Substring(0,
                    //    (GetType().Assembly.Location.Length - GetType().Assembly.ManifestModule.Name.Length - 1));

                    if (IsIgnoreXmlSettings is false)
                    {
                        var DirectoryFull = Directory.GetCurrentDirectory();
                        var XmlPath = Path.Combine(DirectoryFull, "tsghMenu.xml");
                        if (File.Exists(XmlPath) == false)
                        {
                            XmlPath = "C:\\TSGH\\tsghMenu.xml";
                        }
                        READ_XML_FILE_PATH = XmlPath.CloneJson();
                        #region 解析XML檔
                        if (File.Exists(XmlPath))
                        {
                            XmlDocument reader = new XmlDocument();
                            reader.Load(XmlPath);
                            if (reader != null)
                            {
                                XmlNode node = reader.SelectSingleNode("//tb_inf");
                                if (node != null)
                                {
                                    string jsonText = JsonConvert.SerializeXmlNode(node);
                                    if (string.IsNullOrWhiteSpace(jsonText) == false)
                                    {
                                        LoginInfo xml = JsonConvert.DeserializeObject<LoginInfo>(jsonText);

                                        if (xml == null)
                                        {
                                            return;
                                        }

                                        if (string.IsNullOrWhiteSpace(xml.tb_inf.USER) == false)
                                        {
                                            UserId = xml?.tb_inf.USER?.ToUpper();
                                        }

                                        if (EnumUtility.YesNoFlag.N.ToString().Equals(xml.tb_inf.TESTMODE))
                                        {
                                            TestMode = false;
                                        }

                                        if (EnumUtility.YesNoFlag.N.ToString().Equals(xml.tb_inf.TESTMODE2))
                                        {
                                            TestMode2 = false;
                                        }

                                        if ((xml.tb_inf?.HISLOCATION ?? string.Empty).Contains(HISLOCATION.TingJhou.GetEnumDisplayName()))
                                        {
                                            HISLOCATION = HISLOCATION.TingJhou;
                                        }

                                        if (DateTime.TryParse(xml.tb_inf?.LOGIN_IN_DATETIME, out DateTime LoginDate))
                                        {
                                            LoginTime = LoginDate;
                                        }

                                        if (string.IsNullOrEmpty(xml.tb_inf.IP) == false)
                                        {
                                            IP = xml.tb_inf.IP;
                                        }

                                        if (EnumUtility.YesNoFlag.N.ToString().Equals(xml.tb_inf.TESTAP))
                                        {
                                            TestAp = false;
                                        }

                                        if (EnumUtility.YesNoFlag.N.ToString().Equals(xml.tb_inf.TESTAP2))
                                        {
                                            TestAp2 = false;
                                        }

                                        if (EnumUtility.YesNoFlag.Y.ToString().Equals(xml.tb_inf.HOMECARE))
                                        {
                                            HomeCare = true;
                                        }
                                    }
                                }
                            }
                        }
                        #endregion 解析XML檔

                        //string IPADDRESS = "";
                        //var host = Dns.GetHostEntry(Dns.GetHostName());
                        //foreach (var ip in host.AddressList)
                        //{
                        //    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        //    {
                        //        IPADDRESS = ip.ToString();
                        //    }
                        //}

                        try
                        {
                            MACHINENAME = Environment.MachineName;

                            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                            {
                                //socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 100); //socket UDP 接收資料時會block(阻塞模式)住直到收到資料為止 , 沒收到資料就可能UI Thread 會被 Hold住, 參考:https://dotblogs.com.tw/naisu/2016/03/09/socket_udp
                                socket.Connect("8.8.8.8", 65530);
                                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                                IP = endPoint.Address.ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                        if (string.IsNullOrEmpty(UserId))
                        {
                            string[] args = Environment.GetCommandLineArgs();
                            //系統指定寫法
                            //有參數傳入 >1 是因為 程式名稱算是第一個就是args(0)
                            if (args?.Length > 2)
                            {
                                UserId = args[1];
                            }
                        }

                    }



                    if (HomeCare)
                    {
                        EnvironmentType = EnvironmentType.Offline;
                        WebDomain = EnumUtility.EnvironmentUrlType.Web_Online.GetEnumDescription();
                        APIDomain = EnumUtility.EnvironmentUrlType.Web_Online.GetEnumDescription();
                        DomainList = new List<string> { EnumUtility.EnvironmentUrlType.Web_Online_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.API_Online_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.IPD_API_Online_LoadBalance.GetEnumDescription() };
                        OVERWRITE_TSGHXML_CONTENT(EnvironmentType);
                    }
                    else
                    {
                        /*
                                    DB 切換規則 (舊)

                        test AP  ｜                ｜
                        test DB  ｜       Y        ｜       N
                        －－－－－－－－－－－－－－－－－－－－－－－－－   
                                 ｜                ｜
                            Y    ｜     開發DB     ｜      平測DB
                                 ｜                ｜
                        －－－－－－－－－－－－－－－－－－－－－－－－－
                                 ｜                ｜
                            N    ｜     開發DB     ｜      正式DB
                                 ｜                ｜
                    */
                        /*
                                       DB 切換規則(2022/10/18生效)

                           test AP  ｜                ｜
                           test DB  ｜       Y        ｜       N
                           －－－－－－－－－－－－－－－－－－－－－－－－－   
                                    ｜                ｜
                               Y    ｜     開發DB     ｜      平測DB
                                    ｜                ｜
                           －－－－－－－－－－－－－－－－－－－－－－－－－
                                    ｜                ｜
                               N    ｜     平測DB     ｜      正式DB
                                    ｜                ｜
                         */

                        //if (TestAp && TestMode)
                        //{
                        //    // 開發區
                        //    EnvironmentType = EnvironmentType.HIS2USER2;
                        //    WebDomain = EnvironmentUrlType.Web_Developed.GetEnumDescription();
                        //}
                        //else if (TestAp != TestMode)
                        //{
                        //    // 平測區
                        //    EnvironmentType = EnvironmentType.Formal;
                        //    WebDomain = EnvironmentUrlType.Web_Formal.GetEnumDescription();
                        //}
                        //else
                        //{
                        //    // 正式區
                        //    EnvironmentType = EnvironmentType.Online;
                        //    WebDomain = EnvironmentUrlType.Web_Online.GetEnumDescription();
                        //}

                        /*
                              Domain 、 DB  切換規則  (2022/10/20生效)

                       項次| XML TAG   | AP | TESTMODE  | AP2 | TESTMODE2 | Result
                        1  |  正式區   | N  |    N      |  N  |     N     | 正式資料庫、正式exe、正式web
                        2  |  正式區   | N  |    N      |  N  |     Y     | 平測資料庫、正式exe、平測web
                        3  |  正式區   | N  |    Y      |  N  |     N     | 測試資料庫、正式exe、測試web
                       －－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
                        4  |  平測區   | N  |    N      |  Y  |     N     | 正式資料庫、平測exe、正式web
                        5  |  平測區   | N  |    N      |  Y  |     Y     | 平測資料庫、平測exe、平測web
                        6  |  平測區   | N  |    Y      |  Y  |     N     | 測試資料庫、平測exe、測試web
                       －－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
                        7  |  測試區   | Y  |    N      |  N  |     N     | 正式資料庫、測試exe、正式web
                        8  |  測試區   | Y  |    Y      |  N  |     N     | 測試資料庫、測試exe、測試web
                        9  |  測試區   | Y  |    N      |  N  |     Y     | 平測資料庫、測試exe、平測web
                        */

                        switch ($@"{TestAp.ToStringYN()}|{TestMode.ToStringYN()}|{TestAp2.ToStringYN()}|{TestMode2.ToStringYN()}")
                        {
                            case "N|N|N|N": // 項次1
                            case "N|N|Y|N": // 項次4
                            case "Y|N|N|N": // 項次7
                                            // 正式區
                                EnvironmentType = EnvironmentType.Online;
                                WebDomain = EnumUtility.EnvironmentUrlType.Web_Online.GetEnumDescription();
                                APIDomain = EnumUtility.EnvironmentUrlType.Web_Online.GetEnumDescription();
                                DomainList = new List<string> { EnumUtility.EnvironmentUrlType.Web_Online_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.API_Online_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.IPD_API_Online_LoadBalance.GetEnumDescription() };
                                break;

                            case "N|N|N|Y": // 項次2
                            case "N|N|Y|Y": // 項次5
                            case "Y|N|N|Y": // 項次9
                                            // 平測區
                                EnvironmentType = EnvironmentType.Formal;
                                WebDomain = EnumUtility.EnvironmentUrlType.Web_Formal.GetEnumDescription();
                                APIDomain = EnumUtility.EnvironmentUrlType.Web_Formal.GetEnumDescription();
                                DomainList = new List<string> { EnumUtility.EnvironmentUrlType.Web_Formal_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.API_Formal_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.IPD_API_Formal_LoadBalance.GetEnumDescription() };
                                break;

                            case "N|Y|N|N": // 項次3
                            case "N|Y|Y|N": // 項次6
                            case "Y|Y|N|N": // 項次8
                                            // 測試區(開發區)
                                EnvironmentType = EnvironmentType.HIS2USER2;
                                WebDomain = EnumUtility.EnvironmentUrlType.Web_Developed.GetEnumDescription();
                                APIDomain = EnumUtility.EnvironmentUrlType.Web_Developed.GetEnumDescription();
                                DomainList = new List<string> { EnumUtility.EnvironmentUrlType.Web_Formal_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.API_Formal_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.IPD_API_Formal_LoadBalance.GetEnumDescription() };
                                break;
                            default:
#if DEBUG
                                //使用平測區, 且更新至XML中
                                EnvironmentType = EnvironmentType.Formal;
                                WebDomain = EnumUtility.EnvironmentUrlType.Web_Formal.GetEnumDescription();
                                APIDomain = EnumUtility.EnvironmentUrlType.Web_Formal.GetEnumDescription();
                                DomainList = new List<string> { EnumUtility.EnvironmentUrlType.Web_Formal_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.API_Formal_LoadBalance.GetEnumDescription(), EnumUtility.EnvironmentUrlType.IPD_API_Formal_LoadBalance.GetEnumDescription() };
                                OVERWRITE_TSGHXML_CONTENT(EnvironmentType);

#else
                                if (OVERWRITE_XML_SETTING is false)
                                {
                                    if(IsIgnoreXmlSettings is false)
                                    {                               
                                        throw new ArgumentException($@"設定檔XML組合錯誤{Environment.NewLine}請確定是否依正常的操作行為由 HIS2Menu 進入系統。"
                                    , $"{nameof(EnumUtility.EnvironmentType)}");
                                    }
                                }
                                else
                                {
                                    //使用平測區, 且更新至XML中
                                    EnvironmentType = EnvironmentType.Formal;
                                    WebDomain = EnvironmentUrlType.Web_Formal.GetEnumDescription();
                                    APIDomain = EnvironmentUrlType.Web_Formal.GetEnumDescription();
                                    DomainList = new List<string> { EnvironmentUrlType.Web_Formal_LoadBalance.GetEnumDescription(), EnvironmentUrlType.API_Formal_LoadBalance.GetEnumDescription() };
                                    OVERWRITE_TSGHXML_CONTENT(EnvironmentType);
                                    if (IsIgnoreXmlSettings)
                                    {
                                        OVERWRITE_TSGHXML_CONTENT_INTERFACE(nameof(TB_INF.USER), SetDefaultTSGHMENUUserId);
                                    }
                                }

#endif
                                break;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        ///// <summary>
        ///// 設定XML屬性
        ///// </summary>
        ///// <param name="NAME">HISLOCATION, HOMECARE, EnvironmentType</param>
        ///// <param name="VALUE">boolean, string, deciaml, int, 使用EnvironmentType時需用EnumUtility.EnvironmentType</param>
        ///// <returns></returns>
        //public ServiceResult SetXmlProperty(string NAME, object VALUE)
        //{
        //    ServiceResult<InfoUtility> returnResult = new ServiceResult<InfoUtility>(false, string.Empty);
        //    try
        //    {
        //        var DirectoryFull = Directory.GetCurrentDirectory();
        //        var XmlPath = Path.Combine(DirectoryFull, "tsghMenu.xml");
        //        if (File.Exists(XmlPath) == false)
        //        {
        //            XmlPath = "C:\\TSGH\\tsghMenu.xml";
        //        }
        //        var overRideXmlFileContentResult = OVERWRITE_TSGHXML_CONTENT_INTERFACE(XmlPath, NAME, VALUE);
        //        returnResult.IsOk = overRideXmlFileContentResult.IsOk;
        //        if (overRideXmlFileContentResult.IsOk == false)
        //        {
        //            returnResult.Message += "[覆寫TsghMenu設定檔失敗]:" + overRideXmlFileContentResult.Message + Environment.NewLine;
        //            if (overRideXmlFileContentResult.Exception != null)
        //            {
        //                var getExceptionMsg = overRideXmlFileContentResult.Exception.GetInnerException(true);
        //                returnResult.Message += "[覆寫TsghMenu設定檔失敗ExceptionThrow]:" + getExceptionMsg.ErrorMessage + getExceptionMsg.Stacktrace + Environment.NewLine;
        //            }
        //        }
        //        else
        //        {
        //            returnResult.Message += "[覆寫TsghMenu設定檔成功]:" + overRideXmlFileContentResult.Message + Environment.NewLine;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        returnResult.Exception = ex;
        //        returnResult.IsOk = false;
        //        returnResult.Message += "[THROW]:" + ex.GetInnerException().ErrorMessage + Environment.NewLine;
        //    }
        //    return returnResult;
        //}

        /// <summary>
        /// 修改TSGH XML 檔案 
        /// </summary>
        /// <param name="NAME">Xml Property Name(HISLOCATION, HOMECARE, EnvironmentType)</param>
        /// <param name="VALUE">Property Value(EnumUtility.HISLOCATION,  Y/N, EnumUtility.EnvironmentType)</param>
        /// <returns></returns>
        public ServiceResult OVERWRITE_TSGHXML_CONTENT_INTERFACE(string NAME, object VALUE)
        {
            ServiceResult ReturnResult = new ServiceResult(false, 0, string.Empty);
            try
            {
                var DirectoryFull = Directory.GetCurrentDirectory();
                var XML_FILE_PATH = Path.Combine(DirectoryFull, "tsghMenu.xml");
                if (File.Exists(XML_FILE_PATH) == false)
                {
                    XML_FILE_PATH = "C:\\TSGH\\tsghMenu.xml";
                }
                if (!string.IsNullOrWhiteSpace(XML_FILE_PATH))
                {
                    try
                    {
                        Path.GetFullPath(XML_FILE_PATH);
                    }
                    catch (Exception ex)
                    {
                        ReturnResult.Message += "[檔案路徑THROW]:" + ex.Message + Environment.NewLine;
                    }
                    if (File.Exists(XML_FILE_PATH))
                    {
                        if (Path.GetExtension(XML_FILE_PATH)?.ToUpper() == ".XML")
                        {
                            XmlDocument reader = new XmlDocument();
                            reader.Load(XML_FILE_PATH);
                            if (reader != null)
                            {
                                XmlNode node = reader.SelectSingleNode("//tb_inf");
                                if (node != null)
                                {
                                    var JSON_TEXT = JsonConvert.SerializeXmlNode(node);
                                    if (!string.IsNullOrWhiteSpace(JSON_TEXT))
                                    {
                                        InfoUtility.LoginInfo_Public xml = JsonConvert.DeserializeObject<InfoUtility.LoginInfo_Public>(JSON_TEXT);
                                        if (xml != null)
                                        {
                                            var SourceXml = xml.CloneJson();
                                            switch (NAME)
                                            {
                                                case nameof(LoginInfo_Public.tb_inf.HISLOCATION):
                                                    if (VALUE is EnumUtility.HISLOCATION hislocation)
                                                    {
                                                        switch (hislocation)
                                                        {
                                                            case HISLOCATION.NeiHu:
                                                            case HISLOCATION.TingJhou:
                                                                xml.tb_inf.HISLOCATION = hislocation.GetEnumDescription();
                                                                break;
                                                        }
                                                    }
                                                    else if (VALUE is int valueHislocation)
                                                    {
                                                        switch (valueHislocation)
                                                        {
                                                            case 1:
                                                                xml.tb_inf.HISLOCATION = HISLOCATION.NeiHu.GetEnumDescription();
                                                                break;
                                                            case 2:
                                                                xml.tb_inf.HISLOCATION = HISLOCATION.TingJhou.GetEnumDescription();
                                                                break;
                                                            default:
                                                                ReturnResult.Code = -1;
                                                                ReturnResult.Message += $"[{nameof(LoginInfo_Public.tb_inf.HISLOCATION)}:{valueHislocation}][{nameof(Int32)}],名稱定義與數值不相符" + Environment.NewLine;
                                                                break;
                                                        }
                                                    }
                                                    else if (VALUE is decimal valueHislocation2)
                                                    {
                                                        switch (valueHislocation2)
                                                        {
                                                            case 1:
                                                                xml.tb_inf.HISLOCATION = HISLOCATION.NeiHu.GetEnumDescription();
                                                                break;
                                                            case 2:
                                                                xml.tb_inf.HISLOCATION = HISLOCATION.TingJhou.GetEnumDescription();
                                                                break;
                                                            default:
                                                                ReturnResult.Code = -1;
                                                                ReturnResult.Message += $"[{nameof(LoginInfo_Public.tb_inf.HISLOCATION)}:{valueHislocation2}][{nameof(Decimal)}],名稱定義與數值不相符" + Environment.NewLine;
                                                                break;
                                                        }
                                                    }
                                                    else if (VALUE is string strValue)
                                                    {
                                                        switch (strValue?.Trim())
                                                        {
                                                            case "1":
                                                                xml.tb_inf.HISLOCATION = HISLOCATION.NeiHu.GetEnumDescription();
                                                                break;
                                                            case "2":
                                                                xml.tb_inf.HISLOCATION = HISLOCATION.TingJhou.GetEnumDescription();
                                                                break;
                                                            default:
                                                                ReturnResult.Code = -1;
                                                                ReturnResult.Message += $"[{nameof(LoginInfo_Public.tb_inf.HISLOCATION)}:{strValue}][{nameof(String)}],名稱定義與數值不相符" + Environment.NewLine;
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ReturnResult.Code = -1;
                                                        ReturnResult.Message += $"[{nameof(LoginInfo_Public.tb_inf.HISLOCATION)}:{VALUE?.ToString()}][{nameof(Object)}],名稱定義與數值不相符" + Environment.NewLine;
                                                    }
                                                    break;
                                                case nameof(LoginInfo_Public.tb_inf.HOMECARE):
                                                    if (VALUE is bool boolValue)
                                                    {
                                                        switch (boolValue)
                                                        {
                                                            case true:
                                                                xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.Y.ToString();
                                                                break;
                                                            case false:
                                                                xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.N.ToString();
                                                                break;
                                                        }
                                                    }
                                                    else if (VALUE is string strValue)
                                                    {
                                                        if (strValue?.ToUpper()?.Trim() == EnumUtility.YesNoFlag.Y.ToString())
                                                        {
                                                            xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.Y.ToString();
                                                        }
                                                        else if (strValue?.ToUpper()?.Trim() == EnumUtility.YesNoFlag.N.ToString())
                                                        {
                                                            xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.N.ToString();
                                                        }
                                                        else
                                                        {
                                                            ReturnResult.Code = -1;
                                                            ReturnResult.Message += $"[{nameof(LoginInfo_Public.tb_inf.HOMECARE)}:{strValue}][{nameof(String)}],名稱定義與數值不相符" + Environment.NewLine;
                                                        }
                                                    }
                                                    else if (VALUE is EnumUtility.YesNoFlag enumValue1)
                                                    {
                                                        switch (enumValue1)
                                                        {
                                                            case EnumUtility.YesNoFlag.Y:
                                                                xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.Y.ToString();
                                                                break;
                                                            case EnumUtility.YesNoFlag.N:
                                                                xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.N.ToString();
                                                                break;
                                                        }
                                                    }
                                                    else if (VALUE is EnumUtility.CancelFlag enumValue2)
                                                    {
                                                        switch (enumValue2)
                                                        {
                                                            case EnumUtility.CancelFlag.Y:
                                                                xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.Y.ToString();
                                                                break;
                                                            case EnumUtility.CancelFlag.N:
                                                                xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.N.ToString();
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ReturnResult.Code = -1;
                                                        ReturnResult.Message += $"[{nameof(LoginInfo_Public.tb_inf.HOMECARE)}:{VALUE?.ToString()}][{nameof(Object)}],名稱定義與數值不相符" + Environment.NewLine;
                                                    }
                                                    break;
                                                case nameof(EnvironmentType):
                                                    if (VALUE is EnumUtility.EnvironmentType environmentType)
                                                    {
                                                        switch (environmentType)
                                                        {
                                                            case EnvironmentType.HIS2USER2:
                                                            case EnvironmentType.Default:
                                                                xml.tb_inf.TESTAP = EnumUtility.YesNoFlag.Y.ToString();
                                                                xml.tb_inf.TESTMODE = EnumUtility.YesNoFlag.Y.ToString();
                                                                xml.tb_inf.TESTAP2 = EnumUtility.YesNoFlag.N.ToString();
                                                                xml.tb_inf.TESTMODE2 = EnumUtility.YesNoFlag.N.ToString();
                                                                xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.N.ToString();
                                                                break;
                                                            case EnvironmentType.Formal:
                                                                xml.tb_inf.TESTAP = EnumUtility.YesNoFlag.Y.ToString();
                                                                xml.tb_inf.TESTMODE = EnumUtility.YesNoFlag.N.ToString();
                                                                xml.tb_inf.TESTAP2 = EnumUtility.YesNoFlag.N.ToString();
                                                                xml.tb_inf.TESTMODE2 = EnumUtility.YesNoFlag.Y.ToString();
                                                                xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.N.ToString();
                                                                break;
                                                            case EnvironmentType.Online:
                                                                xml.tb_inf.TESTAP = EnumUtility.YesNoFlag.Y.ToString();
                                                                xml.tb_inf.TESTMODE = EnumUtility.YesNoFlag.N.ToString();
                                                                xml.tb_inf.TESTAP2 = EnumUtility.YesNoFlag.N.ToString();
                                                                xml.tb_inf.TESTMODE2 = EnumUtility.YesNoFlag.N.ToString();
                                                                xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.N.ToString();
                                                                break;
                                                            case EnvironmentType.Offline:
                                                                /*   直接切正式區資料庫   */
                                                                xml.tb_inf.TESTAP = EnumUtility.YesNoFlag.Y.ToString();
                                                                xml.tb_inf.TESTMODE = EnumUtility.YesNoFlag.N.ToString();
                                                                xml.tb_inf.TESTAP2 = EnumUtility.YesNoFlag.N.ToString();
                                                                xml.tb_inf.TESTMODE2 = EnumUtility.YesNoFlag.N.ToString();
                                                                xml.tb_inf.HOMECARE = EnumUtility.YesNoFlag.Y.ToString();
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ReturnResult.Code = -1;
                                                        ReturnResult.Message += $"[{nameof(EnvironmentType)}:{VALUE?.ToString()}][{nameof(Enum)}],名稱定義與數值不相符" + Environment.NewLine;
                                                    }
                                                    break;
                                                case nameof(LoginInfo_Public.tb_inf.USER):
                                                    if (!string.IsNullOrWhiteSpace(VALUE?.ToString()))
                                                    {
                                                        xml.tb_inf.USER = VALUE?.ToString();
                                                    }
                                                    else
                                                    {
                                                        ReturnResult.Code = -1;
                                                        ReturnResult.Message += $"[{nameof(LoginInfo_Public.tb_inf.USER)}:{VALUE?.ToString()}][{nameof(Enum)}],數值不可為空值或空白" + Environment.NewLine;
                                                    }
                                                    break;
                                                default:
                                                    ReturnResult.Code = -1;
                                                    ReturnResult.Message += $"[{nameof(NAME)}:{NAME?.ToString()}],未找到相符之名稱定義" + Environment.NewLine;
                                                    break;
                                            }
                                            if (ReturnResult.Code != -1)
                                            {
                                                XmlDocument xmlDoc = new XmlDocument();
                                                //宣告段落
                                                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", null, "yes");
                                                xmlDoc.AppendChild(xmlDeclaration);
                                                XmlElement Root = xmlDoc.CreateElement(nameof(InfoUtility.LoginInfo_Structure.DocumentElement));
                                                xmlDoc.AppendChild(Root);

                                                var tb_INF = XmlHelp.CreateNode(xmlDoc, Root, nameof(InfoUtility.LoginInfo_Structure.DocumentElement.tb_inf), null);
                                                foreach (var item in xml.tb_inf.GetFieldValue())
                                                {
                                                    XmlHelp.CreateNode(xmlDoc, tb_INF, item.Key, item.Value?.ToString());
                                                }
                                                //var BackupFileFullPath = Path.GetFullPath(XML_FILE_PATH.Replace(Path.GetFileName(XML_FILE_PATH), Path.GetFileNameWithoutExtension(XML_FILE_PATH) + "_BACKUP.xml"));
                                                //File.Copy(XML_FILE_PATH, BackupFileFullPath, true);
                                                xmlDoc.Save(XML_FILE_PATH);
                                                ReturnResult.IsOk = true;
                                                var modifyList = SourceXml.tb_inf.GetFieldValue().ModifyDic_Interface(xml.tb_inf.GetFieldValue());
                                                if (modifyList.IsOk)
                                                {
                                                    ReturnResult.Message += "異動紀錄:" + string.Join(Environment.NewLine, modifyList.Data.Select(x => x.Column + ":" + x.ChangeNote));
                                                }
                                                else
                                                {
                                                    ReturnResult.Message += modifyList.Message + Environment.NewLine;
                                                }
                                                //ReturnResult.Message += $"連線區域轉換至[{environmentType.GetEnumDisplayName()}]成功!, 原始XML檔案已經備份至\"{BackupFileFullPath}\"" + Environment.NewLine;
                                                //ReturnResult.Message += $"連線區域轉換至[{environmentType.GetEnumDisplayName()}]成功!" + Environment.NewLine;
                                            }
                                        }
                                        else
                                        {
                                            ReturnResult.Message += "XML檔案轉換成相關Model失敗!" + Environment.NewLine;
                                        }
                                    }
                                    else
                                    {
                                        ReturnResult.Message += "XML檔案序列化失敗!" + Environment.NewLine;
                                    }
                                }
                                else
                                {
                                    ReturnResult.Message += "XML檔案節點讀取失敗!" + Environment.NewLine;
                                }
                            }
                            else
                            {
                                ReturnResult.Message += "XML檔案讀取失敗!" + Environment.NewLine;
                            }
                        }
                        else
                        {
                            ReturnResult.Message += "該路徑之副檔名必須為XML!" + Environment.NewLine;
                        }
                    }
                    else
                    {
                        ReturnResult.Message += "該路徑之檔案不存在!" + Environment.NewLine;
                    }
                }
                else
                {
                    ReturnResult.Message += "XML路徑不可為空值!" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                //if (!string.IsNullOrWhiteSpace(XML_FILE_PATH))
                //{
                //    var BackupFileFullPath = Path.GetFullPath(XML_FILE_PATH.Replace(Path.GetFileName(XML_FILE_PATH), Path.GetFileNameWithoutExtension(XML_FILE_PATH) + "_BACKUP.xml"));
                //    if (File.Exists(BackupFileFullPath))
                //    {
                //        try
                //        {
                //            File.Copy(BackupFileFullPath, XML_FILE_PATH, true);
                //            ReturnResult.Code = 1;
                //            ReturnResult.Message += $"XML備份檔案復原至\"{XML_FILE_PATH}\"成功!，備份檔案路徑:\"{BackupFileFullPath}\"";
                //        }
                //        catch
                //        {
                //            ReturnResult.Message += $"XML備份檔案復原失敗!，備份檔案路徑:\"{BackupFileFullPath}\"";
                //        }
                //    }
                //}
                ReturnResult.Exception = ex;
                ReturnResult.IsOk = false;
                ReturnResult.Message += "[THROW]:" + ex.GetInnerException().ErrorMessage + Environment.NewLine;
            }
            return ReturnResult;
        }


        /// <summary>
        /// 修改TSGH XML 檔案 
        /// </summary>
        /// <param name="environmentType">欲變更之連線區域</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult OVERWRITE_TSGHXML_CONTENT(EnumUtility.EnvironmentType environmentType)
        {
            return OVERWRITE_TSGHXML_CONTENT_INTERFACE(nameof(EnvironmentType), environmentType);
        }
    }
}
