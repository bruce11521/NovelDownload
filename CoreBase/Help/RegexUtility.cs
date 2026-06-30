using System.Text.RegularExpressions;
using static CoreBase.Help.EnumUtility;

namespace CoreBase.Help
{
    /// <summary>
    /// Regex 相關列舉
    /// </summary>
    public class RegexUtility
    {
        /*
         Tip：
            使用 Regex 時，建議IsMatch，要考慮文字為Null會出錯
            使用建議範例 RegexUtility.CaseType01INSRCode.IsMatch(vaildString ?? string.Empty)

            
            建下列資料時，String 一定要在前面段落先宣告完畢
         */

        #region 復健
        /// <summary>
        /// 物理治療 - 簡單治療
        /// 42002B、42003C、42005B、42006C
        /// </summary>
        public static string physicalTherapySimple = "^(4200[2356])([a-z|A-Z])$";

        /// <summary>
        /// 物理治療 - 中度治療
        /// 42008B、42009C、42017C
        /// </summary>
        public static string physicalTherapyModerate = "^(4200[8-9]|42017)([a-z|A-Z])$";
        
        /// <summary>
        /// 物理治療 - 中度治療
        /// 42011B、42012C、42018C
        /// </summary>
        public static string physicalTherapyModerate_NoCharge = "^(4201[128])([a-z|A-Z])$";

        /// <summary>
        /// 物理治療 - 複雜治療
        /// 42014B、42015C、42019C
        /// </summary>
        public static string physicalTherapyComplicated = "^(4201[459])([a-z|A-Z])$";
        #endregion 復健

        #region 檢驗/檢查醫令細類別
        /// <summary>
        /// 特殊造影檢查(33001~33146、P2101~P2104)
        /// 不應含 33090 此為 顯影劑
        /// </summary>
        public static string specialScanning = "^(330[1-8]0|330[0-9][1-9]|331[0-4]0|331[0-3][1-9]|3314[1-7])([a-z|A-Z])$|^P210[1-4]([a-z|A-Z])$";

        /// <summary>
        /// 超音波(19001~19018)
        /// </summary>
        public static string sonography = "^(190)(0[1-9]|1[0-8])([a-z|A-Z])$";

        /// <summary>
        /// 內視鏡檢查(28001~28046)
        /// </summary>
        public static string endoscopyExamination = "^(280)([1-4]0|[0-3][1-9]|4[1-6])([a-z|A-Z])$";

        /// <summary>
        /// 一般尿液檢查(06001-06017)
        /// 尿常規檢查各項點數累積超過75點者，以75點支付。
        /// </summary>
        public static string generalUrineTest = "^(060)(0[1-9]|1[0-7])([a-z|A-Z])$";

        /// <summary>
        /// 特殊尿液檢查(06503~06513)
        /// </summary>
        public static string specialUrineTest = "^(065)(0[3-9]|1[0-3])([a-z|A-Z])$";

        /// <summary>
        /// 糞便檢查(07001~07018)
        /// </summary>
        public static string stoolTest = "^(070)(0[1-9]|1[0-8])([a-z|A-Z])$";

        /// <summary>
        /// 血液學檢查(08001~08135)
        /// </summary>
        public static string hematologyTest = "^(080[1-9]0|080[0-9][1-9]|081[0-3]0|081[0-2][1-9]|0813[1-5])([a-z|A-Z])$";

        /// <summary>
        /// 一般生化學檢查(09001~09140)
        /// </summary>
        public static string generalBiochemistryExamination = "^(090[1-9]0|090[0-9][1-9]|091[0-4]0|091[0-3][1-9])([a-z|A-Z])$";

        /// <summary>
        /// 輸血前檢查(11001~11012)
        /// </summary>
        public static string preTranfusionExamination = "^(110)(0[1-9]|1[0-2])([a-z|A-Z])$";

        /// <summary>
        /// 免疫學檢查(12001~12219)
        /// </summary>
        public static string immunologyExamination = "^(12[0-1][1-9]0|12[0-1][0-9][1-9]|122[0-1][0-9])([a-z|A-Z])$";

        /// <summary>
        /// 細菌學與黴菌檢查(13001~13032)
        /// </summary>
        public static string bacteriologyFumgusTest = "^(130[1-3]0|130[0-2][1-9]|1303[1-2])([a-z|A-Z])$";

        /// <summary>
        /// 病毒學檢查(14001~14086)
        /// </summary>
        public static string virologyExamination = "^(140[0-8]0|140[0-7][1-9]|1408[1-6])([a-z|A-Z])$";

        /// <summary>
        /// 細胞學檢查(15001~15022)
        /// </summary>
        public static string cytologyExamination = "^(150)([1-2]0|[0-1][1-9]|2[1-2])([a-z|A-Z])$";

        /// <summary>
        /// 穿刺液採取液檢查(16001~16013)
        /// </summary>
        public static string fluidExamination = "^(160)(0[1-9]|1[0-3])([a-z|A-Z])$";

        /// <summary>
        /// 呼吸機能檢查(17001~17024)
        /// </summary>
        public static string respiratoryFunctionExamination = "^(170)([1-2]0|[0-1][1-9]|2[1-4])([a-z|A-Z])$";

        /// <summary>
        /// 循環機檢查(18001~18049)
        /// </summary>
        public static string circulativeFunctionExamination = "^(180[0-4][0-9])([a-z|A-Z])$";

        /// <summary>
        /// 神經系統檢查(20001~20049)
        /// </summary>
        public static string neurologicalTest = "^(200[0-4][0-9])([a-z|A-Z])$";

        /// <summary>
        /// 泌尿系統檢查(21001~21012)
        /// </summary>
        public static string urinologyTest = "^(210)(0[1-9]|1[0-2])([a-z|A-Z])$";

        /// <summary>
        /// 耳鼻喉系統檢查(22001~22041)
        /// </summary>
        public static string eNTExamination = "^(220)([1-4]0|[0-3][1-9]|41)([a-z|A-Z])$";

        /// <summary>
        /// 眼部檢查(23001~23813)
        /// </summary>
        public static string ophthalmologyExamination = "^(23[0-8][0-9]0|23[0-7][1-9][1-9]|2380[1-9]|2381[1-3])([a-z|A-Z])$";

        /// <summary>
        /// 負荷試驗(24001~24029)
        /// </summary>
        public static string loadingTest = "^(240)([1-2]0|[0-1][1-9]|2[1-9])([a-z|A-Z])$";

        /// <summary>
        /// 病理組織檢查(25001~25026)
        /// </summary>
        public static string specimenExamination = "^(250)([1-2]0|[0-1][1-9]|2[1-6])([a-z|A-Z])$";

        /// <summary>
        /// 造影(26001~26078、P2105~P2108)
        /// </summary>
        public static string generalScanning = "^(260)([1-7]0|[0-6][1-9]|7[1-8])([a-z|A-Z])$|^(P210[5-8])([a-z|A-Z])$";

        /// <summary>
        /// 試管(27001-27083)
        /// 不可加成
        /// </summary>
        public static string scanningTubeMethod = "(^(2700[1-9]|270[2-6][0-9]|2707[0-6])([a-z|A-Z|0-9]))";

        /// <summary>
        /// 診斷穿刺(29001~29035)
        /// </summary>
        public static string diagnosticPuncture = "^(290)([1-3]0|[0-2][1-9]|3[1-5])([a-z|A-Z])$";

        /// <summary>
        /// 伴隨式診斷(30101~30111)
        /// </summary>
        public static string companionDiagnostics = "^(301)(0[1-9]|11)([a-z|A-Z])$";

        /// <summary>
        /// 其他檢查(30501~30526)
        /// </summary>
        public static string otherTest = "^(305)([1-2]0|[0-1][1-9]|2[1-6])([a-z|A-Z])$";

        /// <summary>
        /// X光(32001~32026)
        /// </summary>
        public static string generalXRayExamination = "^(320)([1-2]0|[0-1][1-9]|2[1-6])([a-z|A-Z])$";

        /// <summary>
        /// X光(第一片)
        /// </summary>
        public static string generalXRayExaminationFirst = "^(320)(0[1|7|9]|1[1|3|5|7]|22)([a-z|A-Z])$";
        #endregion 檢驗/檢查醫令細類別

        #region 案件分類醫令列表
        /// <summary>
        /// 01西醫一般案件
        /// 醫令為15017C
        /// </summary>
        public static Regex CaseType01INSRCode = new Regex("^15017[a-z|A-Z]$");

        /// <summary>
        /// 03西醫門診手術
        /// </summary>
        public static string CaseType03String = "^(6[2-9]|7[0-9]|8[0-8])\\w{3}[A-Z|a-z]$";
        /// <summary>
        /// 13牙醫門診手術
        /// </summary>
        public static string CaseType13String = "^922\\w{2}[A-Z|a-z]$";
        /// <summary>
        /// 03西醫門診手術、13牙醫門診手術案件特有醫令
        /// 手術醫令範圍判斷 健保碼開頭是 62 - 88 (非二碼的) 或 健保碼開頭是 922 (非三碼的)
        /// 碼長6碼，最後一碼為不限定的英文
        /// </summary>
        public static Regex CaseType0313INSRCode = new Regex(CaseType03String +"|"+ CaseType13String);

        /// <summary>
        /// 05洗腎案件特有醫令
        ///  健保碼為 『58001C、58011C、58017C、58019C、58020C、58021C、58022C、58023C、58024C、58025C、58027C、58028C、58029C』
        /// </summary>
        public static string patternCaseType05INSRCode = "^(58001|58017|58019|5802[0-5]|5802[7-9])([a-z|A-Z])$";

        /// <summary>
        /// 05洗腎案件特有醫令
        ///  健保碼為 『58001C、58011C、58017C、58019C、58020C、58021C、58022C、58023C、58024C、58025C、58027C、58028C、58029C』
        /// </summary>
        //public static Regex CaseType05INSRCode = new Regex("^(580[0-1]1|58017|58019|5802[0-5]|5802[7-9])([a-z|A-Z])$");
        public static Regex CaseType05INSRCode = new Regex(patternCaseType05INSRCode);

        /// <summary>
        /// 05洗腎案件特有醫令(技術費)
        /// 健保碼為『58011C、58017C』
        /// 20250908 麗君來信通知P8115C也比照此邏輯 by 貴榕
        /// </summary>
        public static string patternCaseType05INSRCodeTherapy = "^(58011|58017|P8115)([a-z|A-Z])$";

        /// <summary>
        /// 05洗腎案件特有醫令(技術費)
        /// 健保碼為『58011C、58017C』
        /// </summary>
        public static Regex CaseType05INSRCodeTherapy = new Regex(patternCaseType05INSRCodeTherapy);

        /// <summary>
        /// 05洗腎案件特有醫令(機器費)
        /// </summary>
        public static string patternCaseType05INSRCodeAPDDailyFee = "^(58028)([a-z|A-Z])$";

        /// <summary>
        /// 05洗腎案件特有醫令(機器費)
        /// </summary>
        public static Regex CaseType05INSRCodeAPDDailyFee = new Regex(patternCaseType05INSRCodeAPDDailyFee);

        /// <summary>
        /// A1居家照護、A6護理之家、A7安養養護機構院民案件類別特有醫令
        /// </summary>
        //List<string> CaseTypeA1A6A7CureID = new List<string>
        //{
        //    "05301C", "05302C", "05303C", "05304C", "05305C", "05306C", "05307C", "05308C", "05309C", "05310C"
        //    , "05321C", "05322C", "05328C", "05330C", "05332C", "05334C", "05342C", "05344C", "05346C", "05348C"
        //    , "05350C", "05352C", "05354C", "05356C", "05358C", "05360C", "P5407C", "P5401C", "P5402C", "P5403C"
        //    , "P5404C", "P5406C", "P5408C", "P5409C", "P5411C", "P5412C", "P5413C"
        //};
        public static Regex CaseTypeA1A6A7INSRCode = new Regex("^(0530[1-9]|05310|0532[1|2|8]|0533[0|2|4]|053[4-5][2|4|6|8]|053[5-6]0|[p|P]540[1-4|6-9]|[p|P]541[1-3])([a-z|A-Z])$");

        /// <summary>
        /// A2精神疾病社區復健案件類別特有醫令
        /// </summary>
        //List<string> CaseTypeA2CureID = new List<string>
        //{
        //    "05401C", "05402C", "05403C", "05404C", "05405C", "05406C"
        //};
        public static Regex CaseTypeA2INSRCode = new Regex("^(0540[1-6])([a-z|A-Z])$");

        /// <summary>
        /// A3預防保健案件類別特有醫令
        /// </summary>
        //List<string> CaseTypeA3CureID = new List<string>
        //{
        //    "00"      // 子宮頸抹片代檢
        //    , "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"     // 兒童預防保健
        //    , "21", "22", "23", "24", "21+L1001C"                            // 成人預防保健
        //  10911取消'21+L1001C'，改'21','L1001C'分開申報 2023.04.06 Piper調整
        //    , "25", "26"                                                     // 患小兒麻且35歲以上，每年補助乙次
        //    , "27", "28"                                                     // 身分別為原住民且55歲以上未滿65歲，每年補助乙次
        //    , "31", "33", "35"                                               // 婦女子宮頸抹片檢查                 
        //    , "40", "41", "42", "43", "44", "45", "46", "47", "48", "49"
        //    , "50", "51", "52", "53", "54", "55", "56"
        //    , "60", "61", "62", "63", "64", "66", "68", "71", "72", "73"
        //    , "75", "76", "77", "79", "85"
        //    , "81", "87"                                                      // 兒童牙齒塗氟保健服務
        //    , "8A", "8B", "8C", "8D", "8E", "8F", "8G", "8H", "8G", "8H", "8I", "8J", "8K", "8L", "8M", "8N", "8O", "8P" // 窩溝封填
        //    , "91", "93"                                                      // 乳房攝影檢查
        //    , "95"                                                            // 口腔黏膜檢查
        //};
        public static Regex CaseTypeA3INSRCode = new Regex("^(00|1[1-9]|2[0-8]|3[1|3|5|A-E]|4[0-9]|5[0-6PQ]|6[0-4|6|8]|7[1-3|5-7|9]|8[1|5|7|A-P]|9[1|3-5|7]|L1001C|L1002C)$", RegexOptions.IgnoreCase);
        // A3相對應的衛教費
        // 01~07、23、24、33、61、64、66、68、69、85、98、99須保留的資料
        // 20250206 新增3D、3E醫令 by貴榕
        // 2025.03.06 09:41 來信增加 94、97、3A、3B、3C
        // 20250604 跟保險作業組石麗君確認，5P、5Q也要保留在A3案件中 by 貴榕
        // 20260311 新增L1002C

        /// <summary>
        /// A3 的33醫令需單拆一件
        /// </summary>
        public static Regex CaseTypeA3INSRCode_CaseDividedreMark = new Regex("^33$");

        /// <summary>
        /// 小兒聽力篩檢20醫令
        /// </summary>
        public static Regex CaseTypeA3INSRCode20_CaseDividedreMark = new Regex("^20$");

        /// <summary>
        /// 妊娠糖尿病醫令
        /// </summary>
        public static Regex CaseTypeE1GDM_CaseDividedreMark = new Regex("^[P]391[12346][A-Z|a-z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// A5安寧照護案件類別特有醫令
        /// </summary>
        //List<string> CaseTypeA5CureID = new List<string>
        //{
        //      "05311C", "05312C", "05313C", "05314C", "05315C", "05316C", "05323C", "05324C", "05325C", "05326C"
        //        , "05327C", "05336C", "05337C", "05338C", "05339C", "05340C", "05341C", "05362C", "05364C", "05366C"
        //        , "05368C", "05370C", "05372C", "05374C", "P5405C"
        //};
        public static Regex CaseTypeA5INSRCode = new Regex("^(0531[1-6]|0532[3-7]|0533[6-9]|0534[0-1]|(0536[2|4|6|8])|(0537[0|2|4])|[p|P]5405)[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// C1論病歷計酬案件DRG：3A_人工水晶體
        /// </summary>
        public static Regex CaseTypeC13AINSRCode = new Regex("^86008[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// C1論病歷計酬案件DRG：1A_腹股溝
        /// </summary>
        public static Regex CaseTypeC11AINSRCode = new Regex("^(75606|75607|75613|75614|75615)[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// C1論病歷計酬案件DRG：2A、2B、2C、2D_體外碎石
        /// </summary>
        public static Regex CaseTypeC123INSRCode = new Regex("^50023[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// C1論病歷計酬案件DRG：2A、2B、2C、2D_體外碎石
        /// </summary>
        public static Regex CaseTypeC124INSRCode = new Regex("^50024[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// C1論病歷計酬案件DRG：4A_喉直達鏡
        /// </summary>
        public static Regex CaseTypeC14AINSRCode = new Regex("^(66002|66032)[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// C4代辦無健保結核病患案件
        /// 醫令E40開頭
        /// </summary>
        public static Regex CaseTypeC4INSRCode = new Regex("^E40");

        /// <summary>
        /// C5嚴重特殊傳染性肺炎通報且隔離案件
        /// ('E5200C','E5201C','E5202C','E5203C','E5204C','E5207C','E5208C','E5209C', 'XCOVID0001', 'XCOVID0002')
        /// </summary>
        public static Regex CaseTypeC5INSRCode = new Regex("^(E520[0-4|7-9])[A-Z]$|^(XCOVID000[1-2])$", RegexOptions.IgnoreCase);
        // new Regex("^(E520[0-4|7-9])([a-z|A-Z])$");

        /// <summary>
        /// D2代辦COVID-19 檢驗費
        /// </summary>
        public static string patternCovidINSRCode = "^(E500[2-5])([a-z|A-Z])$";

        /// <summary>
        /// D2代辦COVID-19 檢驗費
        /// </summary>
        //var CaseDivideD2CovidINSRCode = new List string
        //{
        //    "E5002C","E5003C","E5004C","E5005C"
        //};
        public static Regex CaseTypeD2CovidINSRCode = new Regex(patternCovidINSRCode, RegexOptions.IgnoreCase);

        /// <summary>
        /// D2老人及6個月至6歲兒童流感疫苗注射案件
        /// 此Enum僅可放置 非兒科 專用的疫苗健保碼
        /// </summary>
        public static Regex CaseTypeD2OtharINSRCode = new Regex("^((A[2-3]001)[A-Z]|(J000113265|J000113277|J000138206|K000453265|K000453277|K000492206|K000523206|K000889206|K000901206|K000364206|K001036206|X000209206|K001126206|X000092206|K000906206|J000151206|K000939206|K001277206|K001275206|K000702206|J000151206|K000939206|J000157206|K001272206|K001268206))$", RegexOptions.IgnoreCase);

        /// <summary>
        /// D2老人及6個月至6歲兒童流感疫苗注射案件
        /// 此Enum僅可放置 兒科 專用的疫苗健保碼        
        /// </summary>
        /// 20260113 石麗君通知 KC00452209 不須拆案到D2
        public static Regex CaseTypeD2PediatricsINSRCode = new Regex("^((A2001|A205[1-2])[A-Z]|(J000082209|J000085216|J000113265|J000113277|J000138206|K000301206|K000301209|K000351206|K000351209|K000440206|K000450206|K000453265|K000453277|K000456206|K000456209|K000480206|K000501206|K000501209|K000510206|K000523206|K000821206|K000829206|K000889206|K000901206|K000906206|K000912206|K000967206|K000981206|K001036206|K001126206|KC00452206|KC00452221|X000092206|X000153206|X000154206|X000155229|X000156206|X000157206|X000158206|X000159209|X000160206|X000164206|X000165206|X000209206))$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 登革熱案件
        /// </summary>
        public static Regex CaseTypeDFINSRCode = new Regex("^E5001[A-Z]$", RegexOptions.IgnoreCase);

        ///// <summary>
        ///// E1健保試辦計劃案件
        ///// 醫令有 P1407C, P1408C, P1409C, P1410C, P1411C 轉E1案件
        ///// </summary>
        ///// 與 CaseTypeE1E4INSRCode 重複定義
        //public static Regex CaseTypeE1INSRCode = new Regex("^(P140[7-9]|P141[0-1])[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼EB
        /// EB 全民健康保險初期慢性腎臟病醫療給付改善計劃
        /// 醫令有 P4301C 到 P4303C
        /// </summary>
        public static Regex CaseTypeE1EBINSRCode = new Regex("^P430[1-3][A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼K1
        /// K1 全民健康保險 Pre-ESRD 預防性計畫及病人衛教計畫
        /// 醫令有 P3402C 到 P3417C 、 P6802C 到 P6815C
        /// </summary>
        public static Regex CaseTypeE1K1INSRCode = new Regex("^P(340[2-9]|341[0-7]|680[2-9]|681[0-5])[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼H7
        /// H7 全民健康保險 B型肝炎帶原者及 C型肝炎帶原者及 C型肝炎感染者醫療給付改善方案
        /// 醫令有 P4201C 到 P4205C
        /// </summary>
        public static Regex CaseTypeE1H7INSRCode = new Regex("^P420[1-5][A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼E6
        /// E6 全民健康保險 氣喘 醫療給付改善方案
        /// 醫令有 P1612C 到 P1614B
        /// </summary>
        public static Regex CaseTypeE1E6INSRCode = new Regex("^P161[2-4][A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼HE
        /// HE C 型肝炎全口服治療
        /// 醫令有 HCVDAA0001 到 HCVDAA0017
        /// </summary>
        public static Regex CaseTypeE1HEINSRCode = new Regex("^HCVDAA00((0[1-9])|(1[0-7]))$", RegexOptions.IgnoreCase);

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼HF
        /// HF 慢性阻塞肺病醫療給付改善方案 慢性阻塞肺病醫療給付改善方案
        /// 醫令有P6011C, P6012C, P6013C, P6015C
        /// </summary>
        public static Regex CaseTypeE1HFINSRCode = new Regex("^(P601[1-3]|P6015)[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// E1健保試辦計劃案件、心臟衰竭PAC個案評估費及獎勵費
        /// 醫令有P5114B, P5115B, P5117B, P5135B
        /// 且D13 要為 '5'
        /// </summary>
        public static Regex CaseTypeE1HeartFailure = new Regex("^P(511[4|5|7]|5135)[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// E1後新冠整合照護
        /// 醫令有E5102B, E5103B, E5104B, E5105B, E5106B, E5107B, E5108B, E5109B, E5110B, E5111B, E5112B
        /// 且D13 要為 'C'
        /// </summary>
        public static Regex CaseTypeE1CovidCare = new Regex("^E(510[2-9]|511[0-2])[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// EK 特定治療代碼(糖尿病合併初期腎臟病照護)
        /// P7001C~P7004C
        /// </summary>
        public static Regex CaseTypeE1EKINSRCode = new Regex("^P(700[1-4])[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// E4 特定治療代碼(糖尿病照護方案)
        /// P1407C~P1411C
        /// </summary>
        public static Regex CaseTypeE1E4INSRCode = new Regex("^P(14(0[7-9]|1[0-1]))[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 牙科醫令
        /// </summary>
        //var CaseDivideDentalINSRCode = new List<string>
        //{
        //    "92004C", "92007B", "92008B", "92010B", "92011B", "92014C", "92015C", "92016C", "92020B", "92025B"
        //    , "92026B", "92037B", "92038B", "92039B", "92040B", "92044B", "92059C", "92064C", "92065B", "92093B"
        //    , "92096C"
        //};
        public static Regex CaseDivideDentalINSRCode = new Regex("^(9200[4|7-8]|9201[0-1|4-6]|9202[0|5-6]|9203[7-9]|9204[0|4]|92059|9206[4|5]|9209[3|6])([a-z|A-Z])$");
        #endregion 案件分類醫令列表

        #region 特定治療代碼 因為OPD診間判斷需求，故命名規則應為{SID_INSRCODE_[特殊治療代碼]}
        /// <summary>
        /// A1 特定治療代碼(超音波檢查)
        /// (前五碼健保碼 >= '19001') AND (前五碼健保碼 &lt;= '19007')) OR
        /// (健保碼 = '18005B') OR 
        /// (健保碼 = '18006B') OR 
        /// (健保碼 = '18007B')
        /// </summary>
        public static Regex SID_INSRCODE_A1 = new Regex(sonography + "|(^(1800[5-7][a-z|A-Z])$)", RegexOptions.IgnoreCase);

        /// <summary>
        /// A2 特定治療代碼(耳鼻喉科檢查)
        /// (前五碼健保碼 >= '22001') AND (前五碼健保碼 &lt;= '22023')
        /// </summary>
        public static Regex SID_INSRCODE_A2 = new Regex(eNTExamination, RegexOptions.IgnoreCase);

        /// <summary>
        /// A3 特定治療代碼(內視鏡檢查)
        /// (前五碼健保碼 >= '28001') AND (前五碼健保碼 &lt;= '28046')
        /// </summary>
        public static Regex SID_INSRCODE_A3 = new Regex(endoscopyExamination, RegexOptions.IgnoreCase);

        /// <summary>
        /// A4 特定治療代碼(病理組織檢查)
        /// (前五碼健保碼 >= '25001') AND (前五碼健保碼 &lt;= '25026')
        /// </summary>
        public static Regex SID_INSRCODE_A4 = new Regex(specimenExamination, RegexOptions.IgnoreCase);

        /// <summary>
        /// A5 特定治療代碼(核子醫學檢查)
        /// ((前五碼健保碼 >= '26001') AND (前五碼健保碼 &lt;= '26078')) OR 
        /// ((前五碼健保碼 >= 'P2105') AND (前五碼健保碼 &lt;= 'P2108')) OR 
        /// ((前五碼健保碼 >= '27001') AND (前五碼健保碼 &lt;= '27083'))
        /// 支付標準屬於[造影]、[試管]
        /// </summary>
        public static Regex SID_INSRCODE_A5 = new Regex(generalScanning + "|" + scanningTubeMethod, RegexOptions.IgnoreCase);

        /// <summary>
        /// A6 特定治療代碼(X光檢查)
        /// (前五碼健保碼 >= '32001') AND (前五碼健保碼 &lt;= '32026')
        /// </summary>
        public static Regex SID_INSRCODE_A6 = new Regex(generalXRayExamination, RegexOptions.IgnoreCase);

        /// <summary>
        /// A7 特定治療代碼(特殊造影檢查)
        /// 前五碼健保碼 (33001~33146、P2101~P2104)
        /// </summary>
        public static Regex SID_INSRCODE_A7 = new Regex(specialScanning, RegexOptions.IgnoreCase);

        /// <summary>
        /// A8 特定治療代碼(神經科檢查)
        /// (前五碼健保碼 >= '20001') AND (前五碼健保碼 &lt;= '20045')
        /// </summary>
        public static Regex SID_INSRCODE_A8 = new Regex(neurologicalTest, RegexOptions.IgnoreCase);

        /// <summary>
        /// D0 特定治療代碼(物理治療簡單、中度治療)
        /// (前五碼健保碼 >= '42001') AND (前五碼健保碼 &lt;= '42009')
        /// </summary>
        public static Regex SID_INSRCODE_D0 = new Regex(physicalTherapySimple + "|" + physicalTherapyModerate, RegexOptions.IgnoreCase);
        //public static Regex CureItemD0 = new Regex("^(4200[1-9])([a-z|A-Z])");

        /// <summary>
        /// D1 特定治療代碼(癌症放射線治療)
        /// ((前五碼健保碼 &gt;= '36001') AND (前五碼健保碼 &lt;= '36013')) OR  ((前五碼健保碼 &gt;= '37001') AND (前五碼健保碼 &lt;= '37017'))
        /// </summary>
        //public static Regex SID_INSRCODE_D1 = new Regex("(^(3600[1-9]|3601[1-3])([a-z|A-Z|0-9]))|(^(3700[1-9]|3701[0-7])([a-z|A-Z|0-9]))", RegexOptions.IgnoreCase);
        public static Regex SID_INSRCODE_D1 = new Regex("^(3[67]00[1-9]|3601[1-3]|3701[0-7])[a-z|A-Z|0-9]", RegexOptions.IgnoreCase);

        /// <summary>
        /// D2 特定治療代碼(癌症化學治療)
        /// 前五碼健保碼 = '37005'
        /// </summary>
        public static Regex SID_INSRCODE_D2 = new Regex("^(37005)([a-z|A-Z|0-9])", RegexOptions.IgnoreCase);

        /// <summary>
        /// D3 特定治療代碼(復健治療（物理治療簡單、中度治療除外）)
        /// ((前五碼健保碼 >= '41002') AND (前五碼健保碼 &lt;= '41006')) OR
        /// ((前五碼健保碼 >= '42010') AND (前五碼健保碼 &lt;= '42019')) OR
        /// ((前五碼健保碼 >= '43001') AND (前五碼健保碼 &lt;= '43026')) OR
        /// ((前五碼健保碼 >= '44001') AND (前五碼健保碼 &lt;= '44010'))
        /// </summary>
        public static Regex SID_INSRCODE_D3 = new Regex(physicalTherapyComplicated + "|" + "(^(4100[2-6])([a-z|A-Z|0-9]))|(^(4300[1-9]|4301[0-9]|4302[0-6])([a-z|A-Z|0-9]))|(^(4400[1-9]|44010)([a-z|A-Z|0-9]))", RegexOptions.IgnoreCase);

        /// <summary>
        /// D4 特定治療代碼(精神科治療)
        /// (前五碼健保碼 >= '45001') AND (前五碼健保碼 &lt;= '45083')
        /// </summary>
        public static Regex SID_INSRCODE_D4 = new Regex("^(4500[1-9]|450[1-7][0-9]|4508[0-3])([a-z|A-Z|0-9])", RegexOptions.IgnoreCase);

        /// <summary>
        /// D5 特定治療代碼(高壓氧治療)
        /// (前五碼健保碼 >= '59001') AND (前五碼健保碼 &lt;= '59012')
        /// </summary>
        public static Regex SID_INSRCODE_D5 = new Regex("^(5900[1-9]|5901[0-2])([a-z|A-Z|0-9])", RegexOptions.IgnoreCase);

        /// <summary>
        /// D6 特定治療代碼(眼科鐳射治療)
        /// (前五碼健保碼 >= '60001') AND (前五碼健保碼 &lt;= '60013')
        /// </summary>
        public static Regex SID_INSRCODE_D6 = new Regex("^(6000[1-9]|6001[0-3])([a-z|A-Z|0-9])", RegexOptions.IgnoreCase);

        /// <summary>
        /// D8 特定治療代碼 (血液透析治療), 健保碼 in ('58029C$','58027C$')
        /// </summary>
        public static Regex SID_INSRCODE_D8 = new Regex("^58029C$|^58027C$", RegexOptions.IgnoreCase);

        /// <summary>
        /// D9 特定治療代碼(腹膜透析)
        /// 健保碼 in ('58011C','58017C','58026C','58002C', '58028C')
        /// 58011、58017 含在 patternCaseType05INSRCodeTherapy
        /// </summary>
        public static string patternCureItemD9 = patternCaseType05INSRCodeTherapy + "|" + "(^(58026|58002|58028)([a-z|A-Z]))$";
        public static Regex SID_INSRCODE_D9 = new Regex(patternCureItemD9, RegexOptions.IgnoreCase);

        /// <summary>
        /// E4 特定治療代碼(DM糖尿病照護費)
        /// 健保碼 in ('P1407C','P1408C','P1409C','P1410C','P1411C')
        /// </summary>
        public static Regex SID_INSRCODE_E4 = CaseTypeE1E4INSRCode;

        /// <summary>
        /// E6 特定治療代碼(氣喘)
        /// (健保碼 >= 'P1612C') AND (健保碼 <= 'P1614B')
        /// </summary>
        public static Regex SID_INSRCODE_E6 = CaseTypeE1E6INSRCode;

        /// <summary>
        /// EB 特定治療代碼(初期慢性腎臟病醫療給付改善方案)
        /// (健保碼 &gt;= 'P4301C') AND (健保碼 &lt;= 'P4303C')
        /// </summary>
        public static Regex SID_INSRCODE_EB = CaseTypeE1EBINSRCode;

        /// <summary>
        /// EG 潛伏結核感染治療品質支付服務計畫
        /// (健保碼 &gt;= 'P7801C') AND (健保碼 &lt;= 'P7804C')
        /// (健保碼 &gt;= 'E7801C') AND (健保碼 &lt;= 'E7804C') 2024.12.13 收到通知 2025.01.01 起改用E碼開頭
        /// </summary>
        public static Regex SID_INSRCODE_EG = new Regex("^[EP]780[1-4][A-Z|a-z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// EH 愛滋照護管理品質計畫
        /// (健保碼 >= 'P7901C') AND (健保碼 <= 'P7904C')
        /// (健保碼 >= 'E7901C') AND (健保碼 <= 'E7904C') 2024.12.13 收到通知 2025.01.01 起改用E碼開頭
        /// </summary>
        public static Regex SID_INSRCODE_EH = new Regex("^[PE]790[1-4][A-Z|a-z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// EJ 長照機構加強型結核病防治計畫
        /// (健保碼 >= 'P8001C') AND (健保碼 <= 'P8004C')
        /// (健保碼 >= 'E8001C') AND (健保碼 <= 'E8004C') 2024.12.13 收到通知 2025.01.01 起改用E碼開頭
        /// </summary>
        public static Regex SID_INSRCODE_EJ = new Regex("^[PE]800[1-4][A-Z|a-z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// EK 特定治療代碼(糖尿病合併初期腎臟病照護)
        /// P7001C~P7004C
        /// </summary>
        public static Regex SID_INSRCODE_EK = CaseTypeE1EKINSRCode;

        /// <summary>
        /// EM 代謝症候群防治計畫
        /// (健保碼 >= 'P7501C') AND (健保碼 <= 'P7503C')
        /// </summary>
        public static Regex SID_INSRCODE_EM = new Regex("^[P]750[1-3][A-Z|a-z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// FP 特定治療代碼(牙周病統合照護第一階段)
        /// (前五碼健保碼 = 'P4001')
        /// </summary>
        public static Regex SID_INSRCODE_FP = new Regex("^(P4001)([a-z|A-Z|0-9])", RegexOptions.IgnoreCase);

        /// <summary>
        /// FQ 特定治療代碼(牙周病統合照護第二階段)
        /// (前五碼健保碼 = 'P4002')
        /// </summary>
        public static Regex SID_INSRCODE_FQ = new Regex("^(P4002)([a-z|A-Z|0-9])", RegexOptions.IgnoreCase);

        /// <summary>
        /// FR 特定治療代碼(牙周病統合照護第三階段)
        /// (前五碼健保碼 = 'P4003')
        /// </summary>
        public static Regex SID_INSRCODE_FR = new Regex("^(P4003)([a-z|A-Z|0-9])", RegexOptions.IgnoreCase);

        /// <summary>
        /// H1 特定治療代碼(肝炎試辦計畫)
        /// (健保碼 in(BA24469100','BA24468100','BC23920100','K000696266','KC00589237','B022491221','B022491229','K000752221','B022490216','B022490237','K000753216','B016536209','B016536216','B016536221','B016536299','K000754209','KC00589237','K000591243','A048152100','KC00788277','KC00789277','KC00789277','K000765209','K000766209','KC00667255','K000667255','KC00675257','K000669248','KC00674253','K000816255','K000817257','K000815248','K000818253','BC23208100','BC23208100','AB48027100','AC44650100','K000700220','AB48027100','K000700223','K000700227','K000700216','BC24662100','AC44650100','K000700220','K000700223','K000700227','K000700216','BC24662100','BC24690100','AC43302100','BC27086100'))
        /// 2023/08/25 麗君寄信更新藥品清單(已取消特定治療代碼)
        /// </summary>
        public static Regex SID_INSRCODE_H1 = new Regex(
            "^(A048152100|AA57786100|AB48027100|AC43302100|AC44650100|B016536209|B016536216|B016536221|B016536299|B022490216|B022490237|B022491221|B022491229|BA24468100|BA24469100|BC23208100|BC23208100|BC23920100|BC24662100|BC24690100|BC27086100|K000591243|K000667255|K000669248|K000696266|K000700216|K000700220|K000700223|K000700227|K000752221|K000753216|K000754209|K000765209|K000766209|K000815248|K000816255|K000817257|K000818253|KC00589237|KC00589237|KC00667255|KC00674253|KC00675257|KC00788277|KC00789277)$",
            RegexOptions.IgnoreCase);

        /// <summary>
        /// H7 特定治療代碼(全民健康保險B型肝炎帶原者及C型肝炎感染者醫療給付改善方案)
        /// (健保碼 >= 'P4201C') AND (健保碼 &lt;= 'P4205C')
        /// </summary>
        public static Regex SID_INSRCODE_H7 = CaseTypeE1H7INSRCode;

        /// <summary>
        /// HE 特定治療代碼(C型肝炎全口服治療)
        /// (健保碼 >= 'HCVDAA0001') AND (健保碼 &lt;= 'HCVDAA0017')
        /// </summary>
        public static Regex SID_INSRCODE_HE = CaseTypeE1HEINSRCode;

        /// <summary>
        /// HF 特定治療代碼(慢性阻塞性肺病醫療給付改善方案)
        ///  (健保碼 = 'P6011C') OR (健保碼 = 'P6012C') OR (健保碼 = 'P6013C')OR (健保碼 = 'P6015C')
        /// </summary>
        public static Regex SID_INSRCODE_HF = CaseTypeE1HFINSRCode;

        /// <summary>
        /// HM 特定治療代碼(大腸癌追蹤管理)
        /// </summary>
        public static Regex SID_INSRCODE_HM = new Regex("^P7701[A-Z|0-9]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// HN 特定治療代碼(大腸癌診斷品質管理)
        /// </summary>
        public static Regex SID_INSRCODE_HN = new Regex("^P7709[A-Z|0-9]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// HP 特定治療代碼(口腔癌追蹤管理)
        /// </summary>
        public static Regex SID_INSRCODE_HP = new Regex("^P770[23][A-Z|0-9]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// HQ 特定治療代碼(口腔癌診斷品質管理)
        /// </summary>
        public static Regex SID_INSRCODE_HQ = new Regex("^P7710[A-Z|0-9]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// HR 特定治療代碼(子宮頸癌追蹤管理)
        /// </summary>
        public static Regex SID_INSRCODE_HR = new Regex("^P7704[A-Z|0-9]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// HS 特定治療代碼(子宮頸癌診斷品質管理)
        /// </summary>
        public static Regex SID_INSRCODE_HS = new Regex("^P7711[A-Z|0-9]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// HT 特定治療代碼(乳癌追蹤管理)
        /// </summary>
        public static Regex SID_INSRCODE_HT = new Regex("^P770[56][A-Z|0-9]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// HW 特定治療代碼(乳癌診斷品質管理)
        /// </summary>
        public static Regex SID_INSRCODE_HW = new Regex("^P771[23][A-Z|0-9]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// HX 特定治療代碼(肺癌追蹤管理)
        /// </summary>
        public static Regex SID_INSRCODE_HX = new Regex("^P770[78][A-Z|0-9]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// HY 特定治療代碼(肺癌診斷品質管理)
        /// </summary>
        public static Regex SID_INSRCODE_HY = new Regex("^P771[45][A-Z|0-9]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// K1 特定治療代碼(Pre-ESRD預防性計畫及病人衛教計畫)
        /// P3402C 到 P3417C 、 P6802C 到 P6815C
        /// </summary>
        public static Regex SID_INSRCODE_K1 = CaseTypeE1K1INSRCode;

        /// <summary>
        /// K3 特定治療代碼(洗腎相關)
        /// 健保碼P8101~P8103、P8105、P8107~9、P8110、P8112~7
        /// </summary>
        public static Regex SID_INSRCODE_K3 = new Regex("^P81(0[1-357-9]|1[02-7])[a-z|A-Z|0-9]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// EL 特定治療代碼(高血脂收案相關)
        /// 健保碼P89開頭
        /// </summary>
        public static Regex SID_INSRCODE_EL = new Regex("^P890[1-3][a-z|A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// P1 特定治療代碼(根管治療)
        /// ((前五碼健保碼 >= '90001') AND (前五碼健保碼 &lt;= '90004')) OR
        /// ((前五碼健保碼 >= '90006') AND (前五碼健保碼 &lt;= '90010')) OR
        /// ((前五碼健保碼 >= '90012') AND (前五碼健保碼 &lt;= '90015'))
        /// </summary>
        public static Regex SID_INSRCODE_P1 = new Regex("(^(9000[1-4])([a-z|A-Z|0-9]))|(^(9000[6-9]|90010)([a-z|A-Z|0-9]))|(^(9001[2-5])([a-z|A-Z|0-9]))", RegexOptions.IgnoreCase);

        /// <summary>
        /// P2 特定治療代碼(銀粉充填)
        /// ((前五碼健保碼 >= '89001') AND (前五碼健保碼 &lt;= '89003')) OR(前五碼健保碼 = '89003')
        /// </summary>
        public static Regex SID_INSRCODE_P2 = new Regex("^(8900[1-3])([a-z|A-Z|0-9])", RegexOptions.IgnoreCase);

        /// <summary>
        /// P3 特定治療代碼(複合樹脂[玻璃璃子]充填)
        /// ((前五碼健保碼 >= '89004') AND (前五碼健保碼 &lt;= '89005')) OR 
        /// ((前五碼健保碼 >= '89008') AND (前五碼健保碼 &lt;= '89011'))
        /// </summary>
        public static Regex SID_INSRCODE_P3 = new Regex("(^(8900[4-5])([a-z|A-Z|0-9]))|(^(8900[8-9]|8901[0-1])([a-z|A-Z|0-9]))", RegexOptions.IgnoreCase);

        /// <summary>
        /// P4 特定治療代碼(牙周病手術[含齒齦下刮除術])
        /// ((前五碼健保碼 >= '91001') AND (前五碼健保碼 &lt;= '91002')) OR
        /// ((前五碼健保碼 >= '91006') AND (前五碼健保碼 &lt;= '91012'))
        /// </summary>
        public static Regex SID_INSRCODE_P4 = new Regex("(^(9100[1-2])([a-z|A-Z|0-9]))|(^(9100[6-9]|9101[0-2])([a-z|A-Z|0-9]))", RegexOptions.IgnoreCase);

        /// <summary>
        /// P5 特定治療代碼(兒童斷髓處理)
        /// (前五碼健保碼 = '89006') OR (前五碼健保碼 = '90005') OR(前五碼健保碼 = '90016')
        /// </summary>
        public static Regex SID_INSRCODE_P5 = new Regex("^(89006|90005|90016)([a-z|A-Z|0-9])", RegexOptions.IgnoreCase);

        /// <summary>
        /// P7 特定治療代碼(口腔外科門診手術[包括拔牙])
        /// (前五碼健保碼 = '90011') OR
        /// ((前五碼健保碼 >= '92001') AND (前五碼健保碼 &lt;= '92050')) OR
        /// (前五碼健保碼 = '92055') OR 
        /// ((前五碼健保碼 >= '92221') AND (前五碼健保碼 = '92225'))
        /// </summary>
        public static Regex SID_INSRCODE_P7 = new Regex("(^(90011)([a-z|A-Z|0-9]))|(^(9200[1-9]|920[1-4][0-9]|92050)([a-z|A-Z|0-9]))|(^(92055)([a-z|A-Z|0-9]))|(^(9222[1-5])([a-z|A-Z|0-9]))", RegexOptions.IgnoreCase);

        /// <summary>
        /// P8 特定治療代碼(治療性牙結石清除)
        /// 91003、91004
        /// </summary>
        public static Regex SID_INSRCODE_P8 = new Regex("^(9100[3-4])([a-z|A-Z|0-9])", RegexOptions.IgnoreCase);

        #endregion 特定治療代碼 特定治療代碼 因為OPD診間判斷需求，故命名規則應為{SID_INSRCODE_[特殊治療代碼]}

        #region DRG醫令
        /// <summary>
        /// DRG:1A
        /// </summary>
        public static Regex DRG1A = CaseTypeC11AINSRCode;

        /// <summary>
        /// DRG:2A、2B、2C、2D
        /// </summary>
        public static Regex DRG23 = CaseTypeC123INSRCode;

        /// <summary>
        /// DRG:2A、2B、2C、2D
        /// </summary>
        public static Regex DRG24 = CaseTypeC124INSRCode;

        /// <summary>
        /// DRG:3A
        /// </summary>
        public static Regex DRG3A = CaseTypeC13AINSRCode;

        /// <summary>
        /// DRG:4A
        /// </summary>
        public static Regex DRG4A = CaseTypeC14AINSRCode;
        #endregion DRG醫令

        #region 特定醫令
        /// <summary>
        /// 結核病 特定醫令
        /// </summary>
        public static Regex ORDERCODE_TB = new Regex("^A10[0-1][0-9][A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// CT 品項
        /// 33070B ~ 33072B
        /// </summary>
        public static Regex ORDERCODE_CT = new Regex("^3307[0-2][A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// MRI 品項
        /// 33084B ~ 33085B
        /// </summary>
        public static Regex ORDERCODE_MRI = new Regex("^3308[4-5][A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 核子醫學檢查 品項
        /// 26072B ~ 26073B
        /// </summary>
        public static Regex ORDERCODE_Radioisotope = new Regex("^2607[2-3][A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 放射醫令
        /// 32001C ~ 33133B
        /// </summary>
        public static Regex ORDERCODE_PACS = new Regex("^(32[1-9][0-9]0|32[0-9][1-9]0|32[0-9][0-9][1-9]|330[0-9][0-9]|331[0-2][0-9]|3313[0-3])[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 放射顯影劑 Contrast
        /// 33090B
        /// </summary>
        public static Regex ORDERCODE_Contrast = new Regex("^33090[A-Z]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 注射筒組套 -CT攝影專用顯影劑注射筒＿雙筒 SDS-CTP-QFT
        /// NBS07DCTPQMH
        /// </summary>
        public static Regex ORDERCODE_SDS_CTP_QFT = new Regex("^NBS07DCTPQMH$");

        /// <summary>
        /// 復健費用醫令
        /// </summary>
        public static Regex rehSameCureFeeCure =
            new Regex("^(4200[258]|4201[14]|4300[258]|43030|4400[258]|44014|4450[1-5])B$");
        #endregion

        #region 資源共享
        /// <summary>
        /// CTMRI 資源共享
        /// 健保碼 = 'P2101C', 'P2102C'
        /// </summary>
        public static Regex CTMRIShareINSRCode_1stHospital = new Regex("^[p|P]210[12][a-z|A-Z]$");

        /// <summary>
        /// PET 資源共享
        /// 健保碼 = 'P2105C', 'P2106C'
        /// </summary>
        public static Regex PETShareINSRCode_1stHospital = new Regex("^[p|P]210[5|6][a-z|A-Z]$");

        /// <summary>
        /// CTMRI 資源共享
        /// 健保碼 = 'P2103C', 'P2104C'
        /// </summary>
        public static Regex CTMRIShareINSRCode_2ndHospital = new Regex("^[p|P]210[3|4][a-z|A-Z]$");

        /// <summary>
        /// PET 資源共享
        /// 健保碼 = 'P2107C', 'P2108C'
        /// </summary>
        public static Regex PETShareINSRCode_2ndHospital = new Regex("^[p|P]210[7|8][a-z|A-Z]$");
        #endregion 資源共享

        #region ICD10 診斷
        /// <summary>
        /// 外傷導致之牙齒脫落或脫位
        /// S032、S0242、S0267
        /// </summary>
        public static string ToothLossOrDislocationDueToTrauma = "^[s|S]0(32|242|267)";

        /// <summary>
        /// 顏面及牙齒疼痛，經藥物控制不佳者
        /// K0381、K040、K041~K0499、K050、K052
        /// </summary>
        public static string FacialAndDentalPainPoorlyControlledByMedication = "^[k|K]0(381|4[0-9]|5[0|2])";

        /// <summary>
        /// 外傷導致之牙齒斷裂
        /// S025
        /// </summary>
        public static string FracturedTeethDueToTrauma = "^[s|S]025";

        /// <summary>
        /// 拔牙、腫瘤、手術後等口腔出血
        /// K91840
        /// </summary>
        public static string MouthBleedingAfterToothExtractionTumorSurgeryEtc = "^[k|K]91840$";

        /// <summary>
        /// 下顎關節脫臼
        /// S030
        /// </summary>
        public static string JawDislocation = "^[s|S]030";

        /// <summary>
        /// 顏面與口腔間隙蜂窩性組織炎
        /// K122、L03221、L0201、L03211、L03212
        /// </summary>
        public static string FacialAndOralInterstitialCellulitis = "^([k|K]122|[l|L]0(201|3221|321[1|2]))";

        /// <summary>
        /// 口腔及顏面撕裂傷
        /// S014、S015
        /// </summary>
        public static string OralAndFacialLacerations = "[s|S]01[4|5]";

        /// <summary>
        /// AIDS診斷碼
        /// </summary>
        public static Regex ICD10AIDS = new Regex("^(042|V08|Z21|B20)");

        /// <summary>
        /// 梅毒
        /// A51.X、A52.X、A53.X
        /// </summary>
        [Display(Name = "梅毒", Description = "A51.X、A52.X、A53.X")]
        public static string patternICD10_Syphilis = "^A5[1-3]";
        public static Regex ICD10_Syphilis = new Regex(patternICD10_Syphilis, RegexOptions.IgnoreCase);

        /// <summary>
        /// 淋病
        /// A54.X
        /// </summary>
        [Display(Name = "淋病", Description = "A54.X")]
        public static string patternICD10_Gonococcal = "^A54";
        public static Regex ICD10_Gonococcal = new Regex(patternICD10_Gonococcal, RegexOptions.IgnoreCase);

        /// <summary>
        /// 猴痘
        /// B04
        /// </summary>
        [Display(Name = "猴痘", Description = "B04")]
        public static string patternICD10_Monkeypox = "^B04$";
        public static Regex ICD10_Monkeypox = new Regex(patternICD10_Monkeypox, RegexOptions.IgnoreCase);

        /// <summary>
        /// 生殖器疱疹
        /// A60.X
        /// </summary>
        [Display(Name = "生殖器疱疹", Description = "A60.X")]
        public static string patternICD10_GenitalHerpes = "^A60";

        /// <summary>
        /// 尖型濕疣
        /// A63.0、B07.8
        /// </summary>
        [Display(Name = "尖型濕疣", Description = "A63.0、B07.8")]
        public static string patternICD10_GenitalWarts = "^(A630|B078)$";

        /// <summary>
        /// 披衣菌
        /// A55、A56.X、A74.89
        /// </summary>
        [Display(Name = "披衣菌", Description = "A55、A56.X、A74.89")]
        public static string patternICD10_Chlamydial = "(^A(55|7489)$)|^A56";

        /// <summary>
        /// 陰蝨
        /// B85.2、B85.3、B85.4
        /// </summary>
        [Display(Name = "陰蝨", Description = "B85.2、B85.3、B85.4")]
        public static string patternICD10_Pediculosis = "^B85[2-4]$";

        /// <summary>
        /// 龜頭炎
        /// N47.6、N48.1
        /// </summary>
        [Display(Name = "龜頭炎", Description = "N47.6、N48.1")]
        public static string patternICD10_Balanoposthitis = "^N4(76|81)$";

        /// <summary>
        /// 非淋菌性尿道炎
        /// N34.1
        /// </summary>
        [Display(Name = "非淋菌性尿道炎", Description = "N34.1")]
        public static string patternICD10_NonspecificUrethritis = "^N341$";

        /// <summary>
        /// 其他性病
        /// A57、A58、A63.8、A64
        /// </summary>
        [Display(Name = "其他性病", Description = "A57、A58、A63.8、A64")]
        public static string patternICD10_SexuallyTransmittedDisease = "^A(57|58|638|64)$";

        /// <summary>
        /// 桿菌性痢疾
        /// A03.X
        /// </summary>
        [Display(Name = "桿菌性痢疾", Description = "A03.X")]
        public static string patternICD10_Shigellosis = "^A03";

        /// <summary>
        /// 阿米巴性痢疾 
        /// A06.X
        /// </summary>
        [Display(Name = "阿米巴性痢疾", Description = "A06.X")]
        public static string patternICD10_Amebiasis = "^A06";

        /// <summary>
        /// 急性病毒性A型肝炎 
        /// B15.0、B15.9
        /// </summary>
        [Display(Name = "急性病毒性A型肝炎", Description = "B15.0、B15.9")]
        public static string patternICD10_AcuteHepatitisA = "^B15[09]$";

        /// <summary>
        /// 急性病毒性B型肝炎 
        /// B16.0、B16.1、B16.2、B16.9
        /// </summary>
        [Display(Name = "急性病毒性B型肝炎", Description = "B16.0、B16.1、B16.2、B16.9")]
        public static string patternICD10_AcuteHepatitisB = "^B16[0-29]$";

        /// <summary>
        /// 急性病毒性C型肝炎 
        /// B17.1、B17.10、B17.11
        /// </summary>
        [Display(Name = "急性病毒性C型肝炎", Description = "B17.1、B17.10、B17.11")]
        public static string patternICD10_AcuteHepatitisC = "^B171[01]{0,1}$";  // [01]{0,1} →[]代表這個位置裡面的值僅0或1，且{0,1}代表的是沒出現過，或只出現過一次

        /// <summary>
        /// 非法物質濫用者(藥癮病患)
        /// F11.X、F12.X、F13.X、F14.X、F15.X、F16.X、F18.X、F19.X
        /// </summary>
        [Display(Name = "非法物質濫用者(藥癮病患)", Description = "F11.X、F12.X、F13.X、F14.X、F15.X、F16.X、F18.X、F19.X")]
        public static string patternICD10_DrugDependence = "^F1[1-689]";
        #endregion ICD10 診斷

        #region 健保碼鎖定診斷碼
        /// <summary>
        /// 結核病診斷碼
        /// 前五診斷之前3碼為A15~A19 ，或前五診斷為R7611、R7612、Z201)
        /// </summary>
        public static Regex ICD10TB = new Regex("(^A1[5-9])|(^(R7611|R7612|Z201)$)");

        /// <summary>
        /// P4604B 上轉接收主診斷碼檢核
        /// </summary>
        public static Regex CheckP4604BRegex = new Regex("(^I(21[0-3]|22[0|1|8|9]))|(^I6[3-6])|(^I710[0-2])|(^K7(00|0[1|3-4][0-1]|0[2|9]|3[0-2|8-9]|4[0-5]|46[0|9]|54|581|60|689|69|66))|(^(A40[0|1|3|8|9]|A410[1-2]|A41[1-4]|A415[0-3|9]|A418[1|9]|A419|R651[0-1]|R652[0-1]|R57[1|8]))|((^([t|T]07))|(^S(0[0|1|3]|1[0|1|3-7|9]|2[0|1|3-9]|[3-4][0-9]|[5-9][1|3-9])|^T79)[0-9|A-Z|a-z]{3}A|(^S[0-4|6|9]2)[0-9|A-Z|a-z]{3}[A|B]|^S[5|7|8]2[0-9|A-Z|a-z]{3}[A|B|C])|(^(T3[1|2][2-9][0-9]|T20[3|7][0-9]XA|T26[0-8][0-9]XA|T269[0-2]XA))");

        /// <summary>
        /// P4608B 平轉接收主診斷碼檢核
        /// </summary>
        public static Regex CheckP4608BRegex = new Regex("(^K922)|(^K2[5-7][0-2]|K3182)|(^K56(6[0|9]|7))|(^K8(00[0-1]|01[1-3|8-9]|02[0-1]|03[0-7]|04[0-9]|0[5|7|8][0-1]|06[0-7]|1[0-2|9]|2[0-4|8-9]))|(^K(743|803|83))|(^K85)|(^J189)|(^J44)|(^(K122|L0[2-3]|L983))|(^I50[2-9])|(^509)|(^(N36[0-2|4-5|8]|N39|N139|R31))|(^N12)|(^N18[4-6])|(^K746[0|9])|(^K7291)");

        //【有開立XXXXX醫令，請輸入符合診斷代碼】
        /// <summary>
        /// 開立健保碼92096C前五診斷須符合以下診斷碼
        /// </summary>
        public static Regex Check92096CRegex = new Regex(ToothLossOrDislocationDueToTrauma);

        /// <summary>
        /// 開立健保碼E5001C前三診斷須符合以下診斷碼
        /// A90~A92、A988、Z1159
        /// </summary>
        public static Regex CheckE5001CRegex = new Regex("^([a|A]9[0-2]|[a|A]988|[z|Z]1159)");

        /// <summary>
        /// 開立健保碼33144B前五診斷須符合以下診斷碼
        /// C220~C229、D492、K922
        /// </summary>
        public static Regex Check33144BRegex = new Regex("^([c|C]22[0-9]|[d|D]492|[k|K]922)");

        /// <summary>
        /// 開立健保碼50036B前五診斷須符合以下診斷碼
        /// N31、N3281、N393、N394、R32、R3981、R980
        /// </summary>
        public static Regex Check50036BRegex = new Regex("^([n|N]31|[n|N]3281|[n|N]39[3-4]|[r|R]32|[r|R]3981|[r|R]980)");

        /// <summary>
        /// 開立健保碼92093B前五診斷須符合以下診斷碼
        /// </summary>
        //public static Regex Check92093BRegex = new Regex("^([k|K]0381|[k|K]04[0-9]|[k|K]05[0|2]|[k|K]122|[k|K]91840|[s|S]0(14|15|25|30)|L0201|L032(11|12|21))");
        public static Regex Check92093BRegex = new Regex(FacialAndDentalPainPoorlyControlledByMedication + "|" + FracturedTeethDueToTrauma + "|" + MouthBleedingAfterToothExtractionTumorSurgeryEtc + "|" + JawDislocation + "|" + FacialAndOralInterstitialCellulitis + "|" + OralAndFacialLacerations);
        #endregion 健保碼鎖定診斷碼

        #region 包裹計價
        /// <summary>
        /// 乳癌術後低分次全乳照射 包裏頭
        /// 36022B、36023B、36024B
        /// </summary>
        public static Regex HypofractionatedWholeBreast = new Regex("^3602[2-4][A-Z]$");

        /// <summary>
        /// 乳癌術後低分次全乳照射 包裹頭計次數使用
        /// 36011B、36012B、36013B、36020B
        /// </summary>
        public static string patternHypofractionatedWholeBreastCount = "^(3601[1|2|3]|36020)([a-z|A-Z])$";

        /// <summary>
        /// 乳癌術後低分次全乳照射 包裏身
        /// 33090B、36001B、36002B、36004B、36005B、36011B、36012B、36013B、36015B、36018B、36019B、36020B、36021C、37006B、37013B、37014B、37015B、37016B、37030B、37046B
        /// </summary>
        //public static Regex HypofractionatedWholeBreastDetail = new Regex("^(33090B|36001B|36002B|36004B|36005B|36011B|36012B|36013B|36015B|36018B|36019B|36020B|36021C|37006B|37013B|37014B|37015B|37016B|37030B|37046B)$");
        //public static Regex HypofractionatedWholeBreastDetail = new Regex("^((33090|3600[1|2|4|5]|3601[1-3|5|8|9]|3602[0|1]|37006|3701[3-6]|37030|37046)[a-z|A-Z])$");
        public static string patternHypofractionatedWholeBreastDetail = patternHypofractionatedWholeBreastCount + "|" + "^(33090|3600[1|2|4|5]|3601[5|8|9]|36021|37006|3701[3-6]|37030|37046)([a-z|A-Z])$";
        public static Regex HypofractionatedWholeBreastDetail = new Regex(patternHypofractionatedWholeBreastDetail);
        /// <summary>
        /// 洗腎案件不給藥服費 且 藥品費單價歸0
        /// 58001C、58019C、58020C、58021C、58022C、58023C、58024C、58025C、58027C、58029C
        /// </summary>
        public static Regex Hemodialysis = new Regex("^(580)(01|[1-2]9|2[0-5]|27)([a-z|A-Z])$");
        #endregion 包裹計價

        #region 急作加成類別
        /// <summary>
        /// 1小時內完成可急作加成
        /// </summary>
        public static Regex AnHourEmg = new Regex(generalUrineTest + "|" + specialUrineTest + "|" + stoolTest + "|" + hematologyTest + "|" + generalBiochemistryExamination + "|"
            + preTranfusionExamination + "|" + immunologyExamination + "|" + fluidExamination + "|" + virologyExamination + "|" + bacteriologyFumgusTest + "|" + cytologyExamination
            + "|" + respiratoryFunctionExamination + "|" + circulativeFunctionExamination + "|" + neurologicalTest + "|"+ urinologyTest + "|" + eNTExamination + "|" + ophthalmologyExamination
            + "|" + loadingTest + "|" + specimenExamination + "|" + generalScanning + "|" + diagnosticPuncture + "|" + companionDiagnostics + "|" + otherTest + "|" + generalXRayExamination);

        /// <summary>
        /// 3小時內完成可急作加成
        /// </summary>
        public static Regex ThreeHourEmg = new Regex(specialScanning + "|" + sonography + "|" + endoscopyExamination);
        #endregion 急作加成類別

        #region 醫令分類
        //^(0[6-9][0-9][0-9][1-9]|0[7-9][0-9][0-9]0|10[0-7][0-9][0-9]|108[0-1][0-9])([a-z|A-Z])$
        // '06001C' and '10819C'
        /// <summary>
        /// 檢驗醫令
        /// </summary>
        public static Regex Inspect = new Regex("^(0[6-9][0-9][0-9][1-9]|0[7-9][0-9][0-9]0|10[0-7][0-9][0-9]|108[0-1][0-9])([a-z|A-Z])$");

        /// <summary>
        /// 復健需加收部分負擔醫令
        /// 42002B、42005B、42008B (簡單、中度治療)
        /// </summary>
        //public static Regex RehCopayment = new Regex("^4200[2|5|8][a-z|A-Z]$");
        public static Regex RehCopayment = new Regex(physicalTherapySimple + "|" + physicalTherapyModerate);

        /// <summary>
        /// 一般尿液檢查(06001-06017)
        /// 尿常規檢查各項點數累積超過75點者，以75點支付。
        /// </summary>
        public static Regex GeneralUrineTest = new Regex(generalUrineTest);

        /// <summary>
        /// 特殊尿液檢查(06503~06513)
        /// </summary>
        public static Regex SpecialUrineTest = new Regex(specialUrineTest);

        /// <summary>
        /// 急診留觀費(第一天)
        /// </summary>
        public static Regex FixedOVS_First = new Regex("^(0307[35])[a-z|A-Z]$");

        /// <summary>
        /// 急診留觀費(第二天起)
        /// </summary>
        public static Regex FixedOVS = new Regex("^(03018|03042|02006|02030|05213)[a-z|A-Z]$");
        #endregion 醫令分類

        #region 申報 不計價醫令
        /// <summary>
        /// 居家照護案件 A1,A2,A6,A7,A5
        /// 不改為不計價的醫令，其餘皆改不計價
        /// 健保碼為 CKF03S2100WN, CRT02C0060PX, CRT02U0030PX, CFD02ST000EF, CKF0300142R4, CRT02C0080MA, CFD022020NFM, NAN020031NBD, CKF030513NCL, CRT02C0060UW, CRT02U0025WN,  CRT02U0062UW 醫令類別屬於3
        /// </summary>
        /// 20240802保險作業組秀雯姊信件通知
        /// 健保碼為 CKF03S2100WN, CRT02C0060PX<1130802刪除>, CRT02U0030PX<1130802刪除>, CFD02ST000EF, CKF0300142R4<1130802刪除>, CRT02C0080MA<1130802刪除>, CFD022020NFM, NAN020031NBD<1130802刪除>, CKF030513NCL, CRT02C0060UW<1130802刪除>, CRT02U0025WN,  CRT02U0062UW<1130802刪除>、CFD0222073WN<1130802新增>、CKF0303308P2<1130802新增>、CRT0253065VK<1130802新增>

        public static string patternNoPriceHomeCarePublic = "^(CKF03S2100WN|CFD02ST000EF|CFD022020NFM|CKF030513NCL|CRT02U0025WN|CRT02U0062UW|CFD0222073WN|CKF0303308P2|CRT0253065VK)$";

        /// <summary>
        /// 居家照護案件 A1,A6,A7
        /// 不改為不計價的醫令，其餘皆改不計價
        /// 健保碼為'05301C', '05302C', '05303C', '05304C', '05305C', '05306C', '05307C', '05308C', '05309C', '05310C', '05321C', '05322C','05328C','05330C','05332C','05334C','05342C','05344C','05346C,'05348C','05350C','05352C','05354C','05356C','05358C','05360C','P5407C'醫令類別屬於2
        /// </summary>
        public static string patternNoPriceHomeCareA1A6A7 = "^(0530[1-9]|0532[1|2|8]|0533[0|2|4]|053[4|5][2|4|6|8]|053[1|5|6]0|P5407)([a-z|A-Z])$";

        /// <summary>
        /// 居家照護案件 A2
        /// 不改為不計價的醫令，其餘皆改不計價
        /// 健保碼為'05401C', '05402C', '05403C', '05404C', '05405C', '05406C'醫令類別屬於2
        /// </summary>
        public static string patternNoPriceHomeCareA2 = "^(0540[1-6])([a-z|A-Z])$";

        /// <summary>
        /// 居家照護案件 A5
        /// 不改為不計價的醫令，其餘皆改不計價
        /// 健保碼為'05311C', '05312C', '05313C', '05314C', '05315C', '05316C','05323C','05324C','05325C', '05326C','05327C', '05336C','05337C','05338C','05339C','05340C','05341C','05362C','05364C','05366C','05368C','05370C','05372C','05374C','P5405C'醫令類別屬於2
        /// </summary>
        public static string patternNoPriceHomeCareA5 = "^(0531[1-6]|0532[3-7]|0533[6-9]|0534[0|1]|0536[2|46|8]|0537[0|2|4]|P5405)([a-z|A-Z])$";

        /// <summary>
        /// 論病歷計酬案件 C1
        /// 健保碼不為97開頭，醫令類別屬於1、2、3，全改為不計價，其餘類別不變
        /// </summary>
        public static Regex NoPriceC1 = new Regex("^97");

        /// <summary>
        /// 行政協助流感疫苗及兒童常規疫苗接種案件 D2
        /// 健保碼為''A2051C','A2052C','A2001C','A3001C',' E5003C',' E5004C ',' E5002C',' E5005C'，醫令類別屬於2，
        /// 健保碼為' NCS01A2003ZZ，醫令類別屬於3，
        /// 其餘醫令皆為不計價，醫令類別屬於4
        /// </summary>
        public static Regex NoPriceD2 = new Regex(patternCovidINSRCode + "|" + "^(A205[1|2]|A[2|3]001)([a-z|A-Z])$|^(NCS01A2003ZZ)$");
        #endregion 申報 不計價醫令

        #region ICCard_DllLibrary_Utility 健保卡相關資料判斷
        /// <summary>
        /// 健保卡正常就醫序號
        /// (0000~1500, IC[0-9][0-9], ICK1, ICDF, IC8[A-L], ICC1, ICC4, ICCD, ICD1, ICB6, ICHN, IC3[A-D], IC5[P-D], W001~W999, ICLD
        /// [20251125 Bruce更新]
        /// 20260106新增代謝症候群卡號 MSPT by 貴榕
        /// </summary>
        public static Regex NHICardNum = new Regex("^0[0-9][0-9][1-9]$|^0[1-9][0-9]0$|^00[1-9]0$|^1[0-4][0-9][0-9]$|^1500|^IC[0-9][0-9]$|^ICK1$|^ICDF$|^IC8[A-L]$|^ICC1$|^ICC4$|^ICCD$|^ICD1$|^ICB6$|^ICHN$|^IC3[A-F]$|^IC5[P-Q]$|^APCT$|^W(00[1-9]|0[1-9][0-9]|[1-9][0-9]{2})$|^ICLD$|^MSPT$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 健保卡正常就醫序號 實體:0000~1500, 虛擬:W001~W999
        /// </summary>
        public static Regex NHICardNum_Normal = new Regex("^0[0-9][0-9][1-9]$|^0[1-9][0-9]0$|^00[1-9]0$|^1[0-4][0-9][0-9]$|^1500$|^W(00[1-9]|0[1-9][0-9]|[1-9][0-9]{2})$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 使用非累計就醫類別所產生之特殊就醫序號
        /// IC[0-9][0-9], ICK1, ICDF, IC8[A-L], ICC1, ICC4, ICCD, ICD1, ICB6, ICHN, IC3[A-D], IC5[P-D], ICLD
        /// [20251125 Bruce更新]
        /// 20260106新增代謝症候群卡號 MSPT by 貴榕
        /// </summary>
        public static Regex NHICardNum_SpecialCardNum = new Regex("^IC[0-9][0-9]$|^ICK1$|^ICDF$|^IC8[A-L]$|^ICC1$|^ICC4$|^ICCD$|^ICD1$|^ICB6$|^ICHN$|^IC3[A-F]$|^IC5[P-Q]$|^APCT$|^ICLD$|^MSPT$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 健保卡 例外就醫 就醫序號
        /// C001,C002
        /// </summary>
        public static Regex NHICardNum_ExceptionTreatment = new Regex(@"^C00[1-2]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 健保卡異常就醫序號[於20230704 修改]
        /// (依照健保署規範))
        /// </summary>
        public static Regex NHICardNum_Anomalous = new Regex("^A0[0-3][0-1]$|^B00[0-1]$|^C00[0-2]$|^D0[0-1][0-1]$|^E00[0-1]$|^F000$|^Z00[0-1]$|^G000$|^IC98$|^IC09$|^F00B$|^CV19$|^FORE$|^TM01$|^J000$|^HVIT$|^MSPT$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 判斷健保卡就醫類別 是否在合理範圍
        /// [00~09], [AA-AK], [BA-BG], [CA],[DA-DC], [EA], [ZA-ZB]
        /// </summary>
        public static Regex NHIItemCode_All = new Regex("^[0][0-9]$|^[A][A-K]$|^[B][A-G]$|^[C][A]$|^[D][A-C]$|^[E][A]$|^[Z][A-B]$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 判斷健保卡就醫類別 累計就醫序號
        /// [00~09]
        /// </summary>
        public static Regex NHIItemCode_Count = new Regex("^[0][0-9]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 判斷健保卡就醫類別 不須累計就醫序號
        /// [AA-AK], [BA-BG], [CA],[DA-DC], [EA], [ZA-ZB]
        /// </summary>
        public static Regex NHIItemCode_UnCount = new Regex("^[A][A-K]$|^[B][A-G]$|^[C][A]$|^[D][A-C]$|^[E][A]$|^[Z][A-B]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 新生兒就醫註記, 男[A-Z] | 女[a-z], 英文字母為出生之順序
        /// </summary>
        public static Regex cBabyTreat = new Regex(@"^[a-z]$|^[A-Z]$");

        #endregion ICCard_DllLibrary_Utility 健保卡相關資料判斷

        #region 健保卡上傳2.0 醫事類別
        /// <summary>
        /// 醫事類別_就醫類別_門診⻄醫醫院
        /// </summary>
        public static Regex NHITreatItemKind_12 = new Regex("^(0[0-1]|04|0[6-8]|A[A-E]|A[G-I]|AK|B[C-D]|D[A-B]|CA|EA)$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 醫事類別_就醫類別_門診牙醫
        /// </summary>
        public static Regex NHITreatItemKind_13 = new Regex("^(02|04|0[6-8]|A[A-C]|AI|AK|BC|AD|BD|DA|DB|CA)$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 醫事類別_就醫類別_門診中醫
        /// </summary>
        public static Regex NHITreatItemKind_14 = new Regex("^(03|AD|AA|AE|AI|CA)$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 醫事類別_就醫類別_門診洗腎
        /// </summary>
        public static Regex NHITreatItemKind_15 = new Regex("^(00|0[6-9]|AI|AJ|DA|CA)$", RegexOptions.IgnoreCase);

        #endregion

        #region ICCard_DllLibrary_XmlGenerator 健保資料上傳檢核判斷
        /// <summary>
        /// 新生兒胞胎註記[1-5]
        /// </summary>
        public static Regex NHIXML_NEWBORN_BORNORDER = new Regex("^[1-5]$");

        /// <summary>
        /// 新生兒就醫註記[a-e][A-E]
        /// </summary>
        public static Regex NHIXML_NEWBORN_ISNEW = new Regex("^[a-e]$|^[A-E]$");
        /// <summary>
        /// 健保資料段12-1.保健服務項目註記
        /// 20251125 Bruce更新
        /// </summary>
        public static Regex NHIXML_Item = new Regex("^(0[1-9]|1[0-5])$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 健保資料段12-4.檢查項目代碼(預防保健)
        /// 20251125 Bruce更新
        /// </summary>
        public static Regex NHIXML_CheckItemCode = new Regex("^(0[1-7]|20|5[P-Q]|7[1-3]|7[5-7]|79|2[1-9]|3[D-E]|3[13578]|3[A-C]|8[1A-P]|87|88|89|91|85|94|95|97|LD)$|^Y(A-O)$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 健保資料段15-3.產檢檢查項目代碼 
        /// 依衛生福利部110年12月17日衛授國字第 1100461452號函
        /// 111.1.1起停用醫令代碼：4A、4B、4C、4D、4E、57、58、59、6F、6G、6H
        /// </summary>
        public static Regex NHIXML_MaternityCheckItemCode = new Regex("^(4[0-9])$|^(5[0-6])$|^(6[0-9])$|^(70)$|^(9[8-9])$|^(XA)$|^(6[A-E])$|^(5[E-N])$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 給付類別 (依110年7月1日健保醫字第1100033735號函)
        /// </summary>
        public static Regex NHIXML_GiveType = new Regex(@"^((\s$|^\d?^)[1-4])$|^((\s$|^\d?^)[6-9])$|^(A)$|^(C)$|^(D)$|^(E)$|^(M)$|^(Y)$|^(W)$|^(X)$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 醫療專區1-2-1醫令類別
        /// </summary>
        public static Regex NHIXML_ORDERID = new Regex(@"^([1-5])$|^([A-E])$|^([J-K])$|^([G-H])$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 醫療專區1-2-1醫令類別[NHI2.0]
        /// </summary>
        public static Regex NHIXML_NHI20_ORDERID = new Regex(@"^[0-5]$|^9$|^J$|^G$|^M$|^P$|^Q$|^N$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 重要醫令 (110年8月19日110AD06810號請辦單_修訂「健保卡資料上傳作業」急診及住院上傳資料-問答集)
        /// </summary>
        public static Regex NHIXML_VERYIMPORTANT_ORDERCODE = new Regex(@"^(03010E)$|^(03011F)$|^(03012G)$|^(68036B)$|^(47056B)$|^(47089B)$|^(57001B)$|^(57002B)$|^(57023B)$|^(57030B)$|^(58011C)$|^(58017C)$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 重要醫令 之CT、MRI、PET (需要手動排除62000[A-C] 與 62001[A-B])
        /// </summary>
        public static Regex NHIXML_VERYIMPORTANT_ORDERCODE_CT_MRI_PET = new Regex(@"^(33070B)$|^(33071B)$|^(33072B)$|^(33084B)$|^(33085B)$|^(33090B)$|^(26072B)$|^(26073B)$|^(62[0-9][0-9][0-9][A-C])$|^(6[3-9][0-9][0-9][0-9][A-C])$|^(7[0-9][0-9][0-9][0-9][A-C])$|^(8[0-7][0-9][0-9][0-9][A-C])$|^(880[0-5][0-3][A-C])$|^(88054[A-B])$", RegexOptions.IgnoreCase);


        #region NHIXML CT MRI PET Combine
        /// <summary>
        /// 重要醫令 之CT
        /// 33070B~33072B
        /// </summary>
        public static string NHIXML_VERYIMPORTANT_ORDERCODE_CT = "^3307[0-2][A-Z|a-z]$";
        /// <summary>
        /// 重要醫令 之MRI
        /// 33084B~33085B
        /// </summary>
        public static string NHIXML_VERYIMPORTANT_ORDERCODE_MRI = "^3308[4-5][A-Z|a-z]$";
        /// <summary>
        /// 重要醫令 之MRI 放射顯影劑 Contrast
        /// 33090B
        /// </summary>
        public static string NHIXML_VERYIMPORTANT_ORDERCODE_MRI_2 = "^33090[A-Z|a-z]$";
        /// <summary>
        /// 重要醫令 之PET 核子醫學檢查 品項
        /// 26072B ~ 26073B
        /// </summary>
        public static string NHIXML_VERYIMPORTANT_ORDERCODE_PET = "^2607[2-3][A-Z|a-z]$";
        /// <summary>
        /// 重要醫令 之CT、MRI、PET 組合 [2023/8/14 Bruce新增]
        /// </summary>
        public static Regex NHIXML_VERYIMPORTANT_ORDERCODE_CT_MRI_PET_Combine = new Regex(NHIXML_VERYIMPORTANT_ORDERCODE_CT + "|" + 
            NHIXML_VERYIMPORTANT_ORDERCODE_MRI + "|" + 
            NHIXML_VERYIMPORTANT_ORDERCODE_MRI_2+ "|" + 
            NHIXML_VERYIMPORTANT_ORDERCODE_PET, RegexOptions.IgnoreCase);
        #endregion NHIXML CT MRI PET Combine

        /// <summary>
        /// 醫療專區 1-2-3診療部位
        /// </summary>
        public static Regex NHIXML_DIAGSPOT = new Regex(@"^(.?[A-C])$|^([E-V])$|^(PH)$|^(PM)$|^(PI)$|^(1[1-9])$|^(2[1-9])$|^(3[1-9])$|^(4[1-9])$|^(5[1-5])$|^(6[1-5])$|^(7[1-5])$|^(8[1-5])$|^(99)$|^(FM)$|^(U[A-B])$|^(UR)$|^(UL)$|^(L[A-B])$|^(LR)$|^(LL)$", RegexOptions.IgnoreCase);
        /// <summary>
        ///  醫療專區 1-2-3診療部位 - 牙位
        /// </summary>
        public static Regex NHIXML_DIAGSPOT_TOOTH = new Regex(@"^(1[1-9])$|^(2[1-9])$|^(3[1-9])$|^(4[1-9])$|^(5[1-5])$|^(6[1-5])$|^(7[1-5])$|^(8[1-5])$|^(99)$|^(FM)$|^(U[A-B])$|^(UR)$|^(UL)$|^(L[A-B])$|^(LR)$|^(LL)$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 醫療專區 1-2-2.診療項目代號 - 牙位
        /// </summary>
        public static Regex NHIXML_DIAGCODE_TOOTH = new Regex(@"^(89[0-9a-zA-Z]*\S)$|^(90[0-9a-zA-Z]*\S)$|^(91[0-9a-zA-Z]*\S)$|^(92[0-9a-zA-Z]*\S)$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 院內健保虛擬碼過濾清單
        /// </summary>
        public static Regex NHIXML_DIAGCODE_TRIHOSPITAL_VIRTUALCODE = new Regex(@"^(DNR)$|^(NND009)$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 健保1.0 資料格式 有效資料
        /// </summary>
        public static Regex NHIXML_NHI10_DATAFORMATE_VALID = new Regex(@"^([1])$|^([3])$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 健保1.0 資料格式 無效資料
        /// </summary>
        public static Regex NHIXML_NHI10_DATAFORMATE_INVALID = new Regex(@"^([2])$|^([4])$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 2.0 M23 處方調劑方式
        /// </summary>
        public static Regex NHIXML_NHI20_M23_ORDERID = new Regex(@"^([0-2])$|^6$|^([A-F])$", RegexOptions.IgnoreCase);

        #endregion ICCard_DllLibrary_XmlGenerator 健保資料上傳檢核判斷

        #region Utility
        /// <summary>
        /// 版本號格式檢測
        /// </summary>
        public static Regex AssemblyInfo_Version = new Regex("^[0-9]*.[0-9]*.[0-9]*.[0-9]*$");
        /// <summary>
        /// 抓取AssemblyInfo.中是否為 FileVersion Line使用
        /// </summary>
        public static Regex AssemblyInfo_FileVersionLine = new Regex(@"\[assembly: AssemblyFileVersion\(" + "\"[0-9]*\\.[0-9]*\\.[0-9]*\\.[0-9]*\"" + "\\)\\]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 抓取AssemblyInfo.中是否為 AssemblyDescription FileVersion Line使用
        /// </summary>
        public static Regex AssemblyInfo_AssemblyDescriptionFileVersionLine = new Regex(@"\[assembly: AssemblyDescription\(" + "\"[0-9]*\\.[0-9]*\\.[0-9]*\\.[0-9]*\"" + "\\)\\]$", RegexOptions.IgnoreCase);
        #endregion Utility

        #region 身份證與居留證與新式身分證大略判斷(未驗證檢核碼)
        /// <summary>
        /// 身份證與居留證與新式身分證大略判斷(未驗證尾數檢核碼)
        /// </summary>
        public static Regex IDNO_RPNO_RoughlyVerify = new Regex("^[A-Z|a-z][1289XYxy|A-D|a-d]\\d{8}$", RegexOptions.IgnoreCase);
        #endregion 身份證與居留證與新式身分證大略判斷(未驗證檢核碼)

        #region 牙科 特殊醫令 案件類別
        /// <summary>
        /// 牙科 特殊醫令 CaseTypeA3- 81,85-87,8A-8P
        /// </summary>
        public static Regex CaseTypeA3_DEN_ITEMCODE_8x = new Regex(@"^81$|^8[5-7A-P]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 牙科 特殊醫令 CaseTypeA3- 95-97
        /// </summary>
        public static Regex CaseTypeA3_DEN_ITEMCODE_9x = new Regex(@"^9[5-7]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 牙科 特殊醫令 CaseType13- 62%-88%, 992%
        /// </summary>
        public static Regex CaseType13_DEN_ORDERCODE = new Regex(@"(^6[2-9][a-zA-Z0-9]*$)|(^7[a-zA-Z0-9]*$)|(^8[0-8][a-zA-Z0-9]*$)|(^992[a-zA-Z0-9]*$)", RegexOptions.IgnoreCase);
        #endregion 牙科 特殊醫令 案件類別

        /// <summary>
        /// 西醫 手術醫令 CaseType03- 62%-88%
        /// </summary>
        public static Regex CaseType03_ORDERCODE = new Regex(CaseType03String, RegexOptions.IgnoreCase);

        #region 身分確認 特殊科別 醫令篩選 IC就醫序號 檢核邏輯 {IdentityCheck_OrderCode_[DEPT]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]}
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:P1612C～P1614B
        /// </summary>
        public static Regex IdentityCheck_OrderCode_102 = new Regex(@"^P161[2-4][A-C]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:P4201C～P4205C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_104 = new Regex(@"^P420[1-5][A-C]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:85
        /// </summary>
        public static Regex IdentityCheck_OrderCode_105 = new Regex(@"^85$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:3F
        /// /// </summary>
        public static Regex IdentityCheck_OrderCode_106 = new Regex(@"^3F$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:85
        /// </summary>
        public static Regex IdentityCheck_OrderCode_108_1 = new Regex(@"^85$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber] 
        /// ORDERCODE:P3402C～P3409C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_108_2 = new Regex(@"^P340[2-9][A-C]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber] 
        /// ORDERCODE:P3402C ~ P3417C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_108_3 = new Regex(@"^P340[2-9][A-C]$|^P341[0-7][A-C]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber] 
        /// ORDERCODE:P6802C～P6815C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_108_4 = new Regex(@"^P680[2-9][A-C]$|^P681[0-7][A-C]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber] 
        /// ORDERCODE:P6802C～P6809C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_PreESRD = new Regex(@"^P680[2-9]C$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber] 
        /// ORDERCODE:A2001C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_FluVaccine = new Regex(@"^A2001C$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:85
        /// </summary>
        public static Regex IdentityCheck_OrderCode_109 = new Regex(@"^85$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:P7001C~P7003C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_109_1 = new Regex(@"^P700[1-3][A-C]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:P1407C～P1411C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_109_2 = new Regex(@"^P140[7-9][A-C]$|^P141[0-1][A-C]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:P4301C ~ P4303C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_10B = new Regex(@"^P430[1-3][A-C]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber] 
        /// ORDERCODE:22,L1001C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_119_1 = new Regex(@"(^22$)|(^L1001C$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber] 
        /// ORDERCODE:31,33
        /// </summary>
        public static Regex IdentityCheck_OrderCode_119_2 = new Regex(@"(^31$)|(^33$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:31,33
        /// </summary>
        public static Regex IdentityCheck_OrderCode_306 = new Regex(@"(^31$)|(^33$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:^3[A-C]$
        /// </summary>
        public static Regex IdentityCheck_OrderCode_306_2 = new Regex(@"(^3[A-C]$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:^5P$
        /// </summary>
        public static Regex IdentityCheck_OrderCode_306_3 = new Regex(@"(^5P$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:^5Q$
        /// </summary>
        public static Regex IdentityCheck_OrderCode_306_4 = new Regex(@"(^5Q$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:(^4[0-9]$)|(^5[0-3]$)
        /// </summary>
        public static Regex IdentityCheck_OrderCode_307 = new Regex(@"(^4[0-9]$)|(^5[0-3]$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// </summary>
        public static Regex IdentityCheck_OrderCode_308 = new Regex(@"(^21$)|(^L1001C$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:(^20$)|(^PED045$)
        /// </summary>
        public static Regex IdentityCheck_OrderCode_310 = new Regex(@"(^20$)|(^PED045$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:21
        /// </summary>
        public static Regex IdentityCheck_OrderCode_314_1 = new Regex(@"(^21$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:22
        /// </summary>
        public static Regex IdentityCheck_OrderCode_314_2 = new Regex(@"(^22$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:23 
        /// </summary>
        public static Regex IdentityCheck_OrderCode_314_3 = new Regex(@"(^23$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:24
        /// </summary>
        public static Regex IdentityCheck_OrderCode_314_4 = new Regex(@"^24$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:(^L1001C$)
        /// </summary>
        public static Regex IdentityCheck_OrderCode_314_5 = new Regex(@"(^L1001C$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:(^3D$)
        /// </summary>
        public static Regex IdentityCheck_OrderCode_314_6 = new Regex(@"(^3D$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:(^3E$)
        /// </summary>
        public static Regex IdentityCheck_OrderCode_314_7 = new Regex(@"(^3E$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:(^2[7-8]$)
        /// </summary>
        public static Regex IdentityCheck_OrderCode_314_8 = new Regex(@"^2[7-8]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:(^2[5-6]$)
        /// </summary>
        public static Regex IdentityCheck_OrderCode_314_9 = new Regex(@"^2[5-6]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:91
        /// </summary>
        public static Regex IdentityCheck_OrderCode_315_1 = new Regex(@"(^91$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:P2105C$
        /// </summary>
        public static Regex IdentityCheck_OrderCode_315_2 = new Regex(@"(^P2105C$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:R39999
        /// </summary>
        public static Regex IdentityCheck_OrderCode_315_3 = new Regex(@"(^R39999$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// </summary>
        public static Regex IdentityCheck_OrderCode_316 = new Regex(@"(^P2105C$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:01,71
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_1 = new Regex(@"(^01$)|(^71$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:02,72
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_2 = new Regex(@"(^02$)|(^72$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:03,73
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_3 = new Regex(@"(^03$)|(^73$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE04,75
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_4 = new Regex(@"(^04$)|(^75$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:05,76
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_5 = new Regex(@"(^05$)|(^76$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:06,77
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_6 = new Regex(@"(^06$)|(^77$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:07,79
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_7 = new Regex(@"(^07$)|(^79$)", RegexOptions.IgnoreCase);

        #region 20241120 健康署兒童發展篩檢 7A-7F
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:7A
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_7A = new Regex(@"^7A$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:7B
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_7B = new Regex(@"^7B$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:7C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_7C = new Regex(@"^7C$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:7D
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_7D = new Regex(@"^7D$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:7E
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_7E = new Regex(@"^7E$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:7F
        /// </summary>
        public static Regex IdentityCheck_OrderCode_320_7F = new Regex(@"^7F$", RegexOptions.IgnoreCase);
        #endregion

        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:3F
        /// </summary>
        public static Regex IdentityCheck_OrderCode_3F = new Regex(@"^3F$", RegexOptions.IgnoreCase);


        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// </summary>
        public static Regex IdentityCheck_OrderCode_330 = new Regex(@"(^E3046C$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:85
        /// </summary>
        public static Regex IdentityCheck_OrderCode_364_1 = new Regex(@"(^85$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:91
        /// </summary>
        public static Regex IdentityCheck_OrderCode_364_2 = new Regex(@"(^91$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:91
        /// </summary>
        public static Regex IdentityCheck_OrderCode_365_1 = new Regex(@"(^91$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:93
        /// </summary>
        public static Regex IdentityCheck_OrderCode_365_2 = new Regex(@"(^93$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:E1027C,E1022C
        /// </summary>
        public static Regex IdentityCheck_OrderCode_366 = new Regex(@"(^E1027C$)|(^E1022C$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:21,L1001C$
        /// </summary>
        public static Regex IdentityCheck_OrderCode_388_1 = new Regex(@"(^21$)|(^L1001C$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:22,L1001C$
        /// </summary>
        public static Regex IdentityCheck_OrderCode_388_2 = new Regex(@"(^22$)|(^L1001C$)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:E3046C$
        /// </summary>
        public static Regex IdentityCheck_OrderCode_397 = new Regex(@"^E3046C$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 身分確認特殊科別醫令篩選 IdentityCheck_OrderCode_[SECTIONNO]_[SerialNumber] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]_[SerialNumber]
        /// ORDERCODE:P6305B,P6306B
        /// </summary>
        public static Regex IdentityCheck_OrderCode_418 = new Regex(@"^P6305B$|^P6306B$", RegexOptions.IgnoreCase);

        #region 特殊就醫序號與檢查代碼

        /// <summary>
        /// 身分確認_特殊醫令 新生兒聽力篩檢 IdentityCheck_OrderCode[INSRCODE]
        /// ORDERCODE:20
        /// </summary>
        public static Regex IdentityCheck_OrderCode20 = new Regex(@"^20$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認_特殊醫令 成人健檢第一階段 IdentityCheck_OrderCode[INSRCODE]
        /// ORDERCODE:21
        /// </summary>
        public static Regex IdentityCheck_OrderCode21 = new Regex(@"^21$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 身分確認_特殊醫令 成人健檢第二階段 IdentityCheck_OrderCode[INSRCODE]
        /// ORDERCODE:21
        /// </summary>
        public static Regex IdentityCheck_OrderCode23 = new Regex(@"^23$", RegexOptions.IgnoreCase);


        #endregion 特殊就醫序號與檢查代碼

        #endregion 身分確認 特殊科別 醫令篩選 IC就醫序號 檢核邏輯 {IdentityCheck_OrderCode_[DEPT] / IdentityCheck_OrderCode_INS[INSUSECTIONNO]}

        #region 醫令篩選 IC就醫序號 檢核邏輯
        /// <summary>
        /// 流感疫苗接種處置費 A2001C(兒童) A2051C(兒童) A3001C(長者) A4001C(COVID-19)
        /// </summary>
        //public static Regex FluVaccine_OrderCode = new Regex("^A[2-4]0[0-9][0-9][a-z|A-Z|0-9]$", RegexOptions.IgnoreCase);
        public static Regex FluVaccine_OrderCode = new Regex("^A2001C$|^A2051C$|^A3001C$|^A4001C$", RegexOptions.IgnoreCase);

        #endregion 醫令篩選 IC就醫序號 檢核邏輯

        #region 牙科總額特殊醫療服務計畫 身心障礙等級 REG.SID 範圍
        /// <summary>
        /// 牙科總額特殊醫療服務計畫 身心障礙等級 REG.SID 範圍
        /// </summary>
        public static Regex DENBudgetSpecial_SID_CODE = new Regex(@"(^F[G-J]$)|(^FV$)|(^F[C-D]$)|(^LF$)", RegexOptions.IgnoreCase);
        #endregion 牙科總額特殊醫療服務計畫 身心障礙等級  REG.SID 範圍

        #region 固定費用 MainGroup
        /// <summary>
        /// 固定費用 MainGroup ('DIA', 'ROM', 'SER', 'REG', 'PAR')
        /// </summary>
        public static Regex FixedFeeMainGroup = new Regex(@"^(DIA|ROM|SER|REG|PAR)$", RegexOptions.IgnoreCase);
        //'DIA', 'ROM', 'SER', 'REG', 'PAR'
        #endregion 固定費用 MainGroup

        /// <summary>
        /// 有開立核醫品項需加開藥服費
        /// 26001B、26002B、26003B、26004B、26005B、26011B、26012B、26013B、26014B、26015B
        /// 、26016B、26018B、26019B、26020B、26021B、26023B、26025B、26026B、26027B、26029B
        /// 、26030B、26031B、26035B、26038B、26040B、26047B、26048B、26050B、26051B、26052B
        /// 、26053B、26055B、26057B、26058B、26060B、26062B、26063B、26070B、26071B、26072B
        /// 、26073B
        /// </summary>
        public static Regex RadioisotopeSer_Item = new Regex("^260([0-1][1-5]|1[689]|2[0135-79]|3[0158]|4[078]|5[0-3578]|6[023]|7[0-3])[A-Z]$");

        #region 特定治療代碼 SID1, SID2, SID3, SID4  20231114 1547 Bruce 註解
        ///// <summary>
        ///// SID A1 健保碼
        ///// </summary>
        //public static Regex SID_A1_INSRCODE = new Regex("^1900[1-7][A-C]*$|^18005B$|^19006B$|^18007B$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID A2 健保碼
        ///// </summary>
        //public static Regex SID_A2_INSRCODE = new Regex("^220(0[1-9]|1[0-9]|2[0-3][A-C]*$)", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID A3 健保碼
        ///// </summary>
        //public static Regex SID_A3_INSRCODE = new Regex("^280(0[1-9]|1[0-9]|2[0-8][A-C]*$)", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID A4 健保碼
        ///// </summary>
        //public static Regex SID_A4_INSRCODE = new Regex("^250(0[1-9]|10)[A-C]*$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID A5 健保碼
        ///// </summary>
        //public static Regex SID_A5_INSRCODE = new Regex("(^260(0[1-9]|[1-5][0-9]|6[0-8])[A-C]*$)|(^270(0[1-9]|[1-6][0-9]|7[0-6])[A-C]*$)", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID A6 健保碼
        ///// </summary>
        //public static Regex SID_A6_INSRCODE = new Regex("^320(0[1-9]|1[0-9]|2[0-5])[A-C]*$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID A7 健保碼
        ///// </summary>
        //public static Regex SID_A7_INSRCODE = new Regex("^330(0[1-9]|[1-7][0-9]|8[0-5])[A-C]*$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID A8 健保碼
        ///// </summary>
        //public static Regex SID_A8_INSRCODE = new Regex("^200(0[1-9]|[1-2][0-9]|30)[A-C]*$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID D2 健保碼
        ///// </summary>
        //public static Regex SID_D2_INSRCODE = new Regex("^37005[A-C]*$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID D1 健保碼
        ///// </summary>
        //public static Regex SID_D1_INSRCODE = new Regex("(^360(0[1-9]|1[0-3])[A-C]*$)|(^370(0[1-9]|1[0-7])[A-C]*$)", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID D0 健保碼
        ///// </summary>
        //public static Regex SID_D0_INSRCODE = new Regex("^4200[1-9][A-C]*$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID D3 健保碼
        ///// </summary>
        //public static Regex SID_D3_INSRCODE = new Regex("(^4100[2-6][A-C]*$)|(^420(1[0-9])[A-C]*$)|(^430(0[1-9]|1[0-9]|2[0-6])[A-C]*$)|(^440(0[1-9]|10)[A-C]*$)", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID D4 健保碼
        ///// </summary>
        //public static Regex SID_D4_INSRCODE = new Regex("^450(0[1-9]|[1-7][0-9]|8[0-3])[A-C]*$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID D5 健保碼
        ///// </summary>
        //public static Regex SID_D5_INSRCODE = new Regex("^590(0[1-9]|1[0-2])[A-C]*$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID D6 健保碼
        ///// </summary>
        //public static Regex SID_D6_INSRCODE = new Regex("^600(0[1-9]|1[0-3])[A-C]*$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID EB 健保碼/CaseType=E1
        ///// </summary>
        //public static Regex SID_EB_INSRCODE = new Regex("^P430[1-3]C$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID K1 健保碼/CaseType=E1
        ///// </summary>
        //public static Regex SID_K1_INSRCODE = new Regex("^P340[2-9]C$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID H7 健保碼/CaseType=E1
        ///// </summary>
        //public static Regex SID_H7_INSRCODE = new Regex("^P420[1-5]C$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID E6 健保碼/CaseType=E1
        ///// </summary>
        //public static Regex SID_E6_INSRCODE = new Regex("^P1612C$|^P1613[A-C]$|^P1614[A-B]$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID HE 健保碼/CaseType=E1
        ///// </summary>
        //public static Regex SID_HE_INSRCODE = new Regex("^HCVDAA00(0[1-9]|1[0-6])$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID HF 健保碼/CaseType=E1
        ///// </summary>
        //public static Regex SID_HF_INSRCODE = new Regex("^P601[1-3]C$|^P6015C$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID H1 健保碼, CaseType=E1
        ///// </summary>
        //public static Regex SID_H1_INSRCODE = new Regex("^BA24469100$|^BA24468100$|^BC23920100$|^K000696266'$|^KC00589237$|^B022491221$|^B022491229$|^K000752221$|^B022490216'$|^B022490237$|^K000753216$|^B016536209$|^B016536216$|^B016536221$|^B016536299$|^K000754209$|^KC00589237$|^K000591243$|^A048152100$|^KC00788277$|^KC00789277$|^KC00789277$|^K000765209$|^K000766209$|^KC00667255$|^K000667255$|^KC00675257$|^K000669248$|^KC00674253$|^K000816255$|^K000817257$|^K000815248$|^K000818253$|^BC23208100$|^BC23208100$|^AB48027100$|^AC44650100$|^K000700220$|^AB48027100$|^K000700223$|^K000700227$|^K000700216$|^BC24662100$|^AC44650100$|^K000700220$|^K000700223$|^K000700227$|^K000700216$|^BC24662100$|^BC24690100$|^AC43302100$|^BC27086100$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID D8 健保碼, CaseType&lt;&gt;25
        ///// </summary>
        //public static Regex SID_D8_INSRCODE = new Regex("^58029C$|^58027C$", RegexOptions.IgnoreCase);
        ///// <summary>
        ///// SID D9 健保碼, CaseType&lt;&gt;25
        ///// </summary>
        //public static Regex SID_D9_INSRCODE = new Regex("^58011C$|^58017C$|^58028C$", RegexOptions.IgnoreCase);
        #endregion 特定治療代碼 SID1, SID2, SID3, SID4

        #region 健保署 重大傷病 押碼
        /// <summary>
        /// 健保署 重大傷病 ICD10 押碼
        /// </summary>
        public static Regex HeavySickICD10EncodingSpecific = new Regex(@"[\x21\x22\x23\x24\x25\x26\x28\x29\x2a\x2b\x3a\x3c\x3e\x3f\x40\x5e\x7b\x7c\x7d\x7e]", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        #endregion

        #region ComPort 格式檢核
        /// <summary>
        /// Com Port格式檢核
        /// </summary>
        public static Regex ComPortNumberCheck = new Regex(@"^COM[1-9]$|^COM[1-9][0-9]*$", RegexOptions.IgnoreCase);

        #endregion

        #region FTP ListDirectoryDetail 格式
        /// <summary>
        /// ListDirectoryDetail REGEX GROUP(attrib, links, owner, group, size, month, day, yearTime, fileName)
        /// </summary>
        public static Regex FtpListDirectoryDetailsRegex = new Regex(@"^(?'Attribute'[^\s]+)\s+(?'Links'[^\s]+)\s+(?'Owner'[^\s]+)\s+(?'Group'[^\s]+)\s+(?'FileSize'[^\s]+)\s+.*(?<Month>(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\s*(?<Day>[0-9]*)\s*(?<YearTime>([0-9]|:)*)\s*(?<FileName>.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        /// <summary>
        /// 英文月份簡寫檢核(3字元)
        /// </summary>
        public static Regex MonthShortNameRegex =
            new Regex(@"^(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 日期格式檢核
        /// </summary>
        public static Regex DayRegex =
            new Regex(@"^([1-9]|[12]\d|3[01])$", RegexOptions.IgnoreCase);

        /// <summary>
        /// 西元年檢核(yyyy)
        /// </summary>
        public static Regex YearRegex = new Regex(@"^[0-9][0-9][0-9][0-9]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// 24小時格式檢核(HH:mm)
        /// </summary>
        public static Regex TimeHHmmRegex = new Regex(@"^([01]\d|2[0-3]):?([0-5]\d)$", RegexOptions.IgnoreCase);

        #endregion

        /// <summary>
        /// CVA 腦中風診斷碼
        /// </summary>
        public static Regex CVA_DiagCode = new Regex(@"(^I60[0-9]\d*$|^I6[1-2][0-9]\d*$|^I63[0-9]\d*$)|(^G45[0-2]\d*$|^G45[4-8]\d*$|^I67[0-2]\d*$|^I67[4-7]\d*$|^I678[1-2]\d*$|^I6784[1-8]\d*$|^I6789\d*$|^I679\d*$|^I6780\d*$|^I6788\d*$)", RegexOptions.IgnoreCase);

        #region DIAGCODE ICD碼規則

        /// <summary>
        /// 診斷碼 ICD9碼範圍 (去掉小數點後)
        /// 一般碼：0–9 開頭，後面 2~4 個數字（總長 3~5）;
        /// V、E 開頭碼：V 或 E 開頭，後面 2~4 數字（總長 3~5）
        /// </summary>
        public static readonly Regex DIAGCODE_ICD9NotDotRegex = new Regex(@"^(?:[0-9]{3,5}|[VE][0-9]{2,4})$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        /// <summary>
        /// 診斷碼 ICD10碼範圍 (去掉小數點後)
        /// 1 碼字母 + 1 碼數字 + 後面 1~5 碼英數 → 總長 3~7
        /// </summary>
        public static readonly Regex DIAGCODE_ICD10NotDotRegex = new Regex(@"^[A-Z][0-9][0-9A-Z]{1,5}$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// 檢測ICD碼版本
        /// </summary>
        /// <param name="icdInput">ICD</param>
        /// <returns></returns>
        public static EnumUtility.IcdVersion DetectIcdVersion (string icdInput)
        {
            if(string.IsNullOrWhiteSpace(icdInput)) return EnumUtility.IcdVersion.Unknown;
            string cleanIcdCode = icdInput.Replace(".", "").ToUpper();
            if (cleanIcdCode.StartsWith("E"))
            {
                // 1. 特例攔截：優先排除那些長得像 ICD-9 但其實是 ICD-10 的代碼
                if (SpecificIcd10ERegex.IsMatch(cleanIcdCode))
                {
                    return EnumUtility.IcdVersion.Icd10;
                }
                string numPart = Regex.Match(cleanIcdCode, @"\d+").Value;
                if (!string.IsNullOrWhiteSpace(numPart))
                {
                    string targetNumStr = numPart.Length >= 3 ? numPart.Substring(0,3) : numPart;
                    if (int.TryParse(targetNumStr, out int firstTreeCode))
                    {
                        // 如果前三位數字小於 800 (例如 E00~E79, E119等)，必定為 ICD-10
                        if (firstTreeCode < 800)
                        {
                            return IcdVersion.Icd10;
                        }
                        // 3. ICD-9 的 E 碼最長只到 5 碼 (例如 E800.0 -> E8000)。超過 5 碼必為 ICD-10
                        if (cleanIcdCode.Length > 5)
                        {
                            return IcdVersion.Icd10;
                        }
                    }
                }
            }

            if (cleanIcdCode.StartsWith("V"))
            {
                // ICD-10 的 V 碼通常長度較長(基本上為6碼)，且第二碼後可能出現字母
                if (cleanIcdCode.Length > 5) return IcdVersion.Icd10;
                // 如果是 V01 ~ V89 且長度短，在無時間參考下極難區分，
                // 但重大傷病中，V 碼多為 ICD-9 的追蹤檢查，建議採納為 ICD-9 或是由使用者確認。

                // 重大傷病實務：短 V 碼 (如 V58.6) 優先判定為 ICD-9
                if (DIAGCODE_ICD9NotDotRegex.IsMatch(cleanIcdCode)) return EnumUtility.IcdVersion.Icd9;
            }

            if (DIAGCODE_ICD9NotDotRegex.IsMatch(cleanIcdCode))
            {
                return IcdVersion.Icd9;
            } 
            if(DIAGCODE_ICD10NotDotRegex.IsMatch(cleanIcdCode))
            {
                return IcdVersion.Icd10;
            }
            return IcdVersion.Unknown;
        }
        /// <summary>
        /// 是否為ICD編碼[ICD9/ICD10]格式(不管是否包含小數點)
        /// </summary>
        /// <param name="icdInput">要檢核的字串</param>
        /// <returns></returns>
        public static bool IsICDCodeFormate(string icdInput)
        {
            if (string.IsNullOrWhiteSpace(icdInput)) return false;
            var code = icdInput.Trim().ToUpperInvariant();
            return DIAGCODE_ICD9NotDotRegex.IsMatch(code) || DIAGCODE_ICD10NotDotRegex.IsMatch(code) || DIAGCODE_ICD9ContainDotRegex.IsMatch(code) || DIAGCODE_ICD10ContainDotRegex.IsMatch(code);
        }
        /// <summary>
        /// 是否為ICD編碼[ICD9/ICD10]格式(未包含小數點)
        /// </summary>
        /// <param name="icdInput">要檢核的字串</param>
        /// <returns></returns>
        public static bool IsICDCodeNotDotFormate(string icdInput)
        {
            if (string.IsNullOrWhiteSpace(icdInput)) return false;
            var code = icdInput.Trim().ToUpperInvariant();
            return DIAGCODE_ICD9NotDotRegex.IsMatch(code) || DIAGCODE_ICD10NotDotRegex.IsMatch(code);
        }
        /// <summary>
        /// ICD-9：簡化版，支援 V/E 及小數點
        /// </summary>
        public static readonly Regex DIAGCODE_ICD9ContainDotRegex =
            new Regex(@"^(?:[0-9]{3}(?:\.[0-9A-Z]{0,2})?|[VE][0-9]{2,3}(?:\.[0-9A-Z]{0,2})?)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        /// <summary>
        /// ICD-10：1 碼字母 + 1 碼數字 + 1 碼英數，後面可選 . + 1~4 碼英數
        /// </summary>
        public static readonly Regex DIAGCODE_ICD10ContainDotRegex = new Regex(@"^[A-Z][0-9][0-9A-Z](?:\.[0-9A-Z]{1,4})?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        /// <summary>
        /// 是否為ICD編碼[ICD9/ICD10]格式(包含小數點)
        /// </summary>
        /// <param name="icdInput">要檢核的字串</param>
        /// <returns></returns>
        public static bool IsICDCodeDotFormate(string icdInput)
        {
            if (string.IsNullOrWhiteSpace(icdInput)) return false;
            var code = icdInput.Trim().ToUpperInvariant();
            return DIAGCODE_ICD9ContainDotRegex.IsMatch(code) || DIAGCODE_ICD10ContainDotRegex.IsMatch(code);
        }
        /// <summary>
        /// ICD10,無小數點,E碼 800~999
        /// 此範圍如果落在ICD9時，須強制判斷為ICD10
        /// </summary>
        public static readonly Regex SpecificIcd10ERegex = new Regex(@"^E(80(2[019]|3)|83(0[019]|3[129]|5[0129]|81)|84(0|1[19]|[89])|85[13]|88(01|1|4[0129]|8[19]|9))$", RegexOptions.IgnoreCase  | RegexOptions.Compiled);
        #endregion

        #region 惡性腫瘤 Malignant Neoplasm
        /// <summary>
        /// 惡性腫瘤 Malignant Neoplasm ICD10 STR
        /// </summary>
        public static string MalignantNeoplasm_ICD10_STR = @"^C([0-7][0-9]|8[0-9]|9[0-7])";
        /// <summary>
        /// 惡性腫瘤 Malignant Neoplasm ICD9 STR
        /// </summary>
        public static string MalignantNeoplasm_ICD9_STR = @"^(1[4-9][0-9]|20[0-8])";
        /// <summary>
        /// 惡性腫瘤 Malignant Neoplasm ICD10
        /// </summary>
        public static Regex MalignantNeoplasm_ICD10 = new Regex(MalignantNeoplasm_ICD10_STR, RegexOptions.IgnoreCase);
        /// <summary>
        /// 惡性腫瘤 Malignant Neoplasm ICD9
        /// </summary>
        public static Regex MalignantNeoplasm_ICD9 = new Regex(MalignantNeoplasm_ICD9_STR, RegexOptions.IgnoreCase);
        /// <summary>
        /// 惡性腫瘤 Malignant Neoplasm ICD10+ICD9
        /// </summary>
        public static Regex MalignantNeoplasm_ICD10_ICD9 = new Regex(@"^(" + MalignantNeoplasm_ICD10_STR.Replace("^", string.Empty) + "|" + MalignantNeoplasm_ICD9_STR.Replace("^", string.Empty) + ")", RegexOptions.IgnoreCase);
        #endregion

        #region Unicode 特殊控制字元或不可見符號

        public static Regex UnicodeControlOrInvisibleChar = new Regex(@"[\u0000-\u001F\u007F]");

        #endregion

        #region NGS醫令

        public static Regex NGS_Orders = new Regex("^3030[1-3][A-C]$", RegexOptions.IgnoreCase);

        #endregion

        #region LTBI科別代碼
        /// <summary>
        /// LTBI 篩檢 科別清單
        /// </summary>
        public static Regex LTBI_ScreeningDept = new Regex(@"^38[0-3]$", RegexOptions.IgnoreCase);
        /// <summary>
        /// LTBI 治療 科別清單
        /// </summary>
        public static Regex LTBI_TreatmentDept = new Regex(@"^38[4-5]$", RegexOptions.IgnoreCase);
        #endregion
    }
}
