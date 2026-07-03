using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreBase.Help
{
    /// <summary>
    /// 全系統共用列舉
    /// </summary>
    public class EnumUtility
    {
        /// <summary>
        /// 檔案類型
        /// </summary>
        public enum FileType
        {
            PDF = 1,
            Excel = 2,
            Word = 3,
            PNG = 4,
            JPG = 5,
            JPEG = 6,
            EMF = 7,
        }

        /// <summary>
        /// 醫院代碼
        /// </summary>
        [Display(Name = "醫院代碼")]
        public const string HospitalID = "0501110514";

        /// <summary>
        /// 醫院名稱
        /// </summary>
        [Display(Name = "醫院名稱")]
        public const string Hospital = "三軍總醫院附設民眾診療服務處";

        /// <summary>
        /// 居家照護醫院代碼
        /// </summary>
        [Display(Name = "居家照護醫院代碼")]
        public const string HospitalHomeCareID = "7501110511";

        /// <summary>
        /// 居家照護醫院名稱
        /// </summary>
        [Display(Name = "居家照護醫院名稱")]
        public const string HospitalHomeCare = "三軍總醫院附設民眾診療服務處附設居家護理所";

        /// <summary>
        /// 取號代碼
        /// </summary>
        public enum SequenceName
        {
            [Display(Name = "急診收據取號")]
            ER_IONO = 0,

            [Display(Name = "門診收據取號")]
            OPD_IONO = 1,

            [Display(Name = "住院收據取號")]
            IPD_IONO = 2,
        }

        /// <summary>
        /// 取號重置類型
        /// </summary>
        public enum SequenceType
        {
            [Display(Name = "不循環")]
            [Description("D")]
            None = 0,

            [Display(Name = "日循環")]
            [Description("A")]
            Day = 1,

            [Display(Name = "月循環")]
            [Description("B")]
            Month = 2,

            [Display(Name = "年循環")]
            [Description("C")]
            Year = 3,
        }

        #region CODE_SRC 相關
        /// <summary>
        /// CODE_SRC 代碼表
        /// </summary>
        public enum CodeSrc
        {
            /// <summary>
            /// 就醫來源
            /// </summary>
            VISITKIND = 0,

            /// <summary>
            /// 給付類別
            /// </summary>
            GIVETYPE = 1,

            /// <summary>
            /// 保險類別
            /// </summary>
            INSUTYPE = 2,

            /// <summary>
            /// 醫療院所
            /// </summary>
            HOSPITAL = 3,

            /// <summary>
            /// 診室
            /// </summary>
            ROOM = 4,

            /// <summary>
            /// 國家類別
            /// </summary>
            NATION = 5,

            /// <summary>
            /// 洲名與國家
            /// </summary>
            COUNTRY = 6,

            /// <summary>
            /// 付費方式(即將移除)
            /// </summary>
            FEETYPE = 7,

            /// <summary>
            /// 收費品項分類
            /// </summary>
            PLANA = 8,

            /// <summary>
            /// 性別
            /// </summary>
            SexCode = 9,

            /// <summary>
            /// 病人狀態
            /// </summary>
            PatientStatus = 10,

            /// <summary>
            /// 軍警消(眷)歸屬註記
            /// </summary>
            BELONGCODE = 11,

            /// <summary>
            /// 民診處主任
            /// </summary>
            TSGNAME = 12,

            /// <summary>
            /// 診別(時段) SegTime
            /// </summary>
            TIME = 13,

            /// <summary>
            /// 身份確認
            /// </summary>
            IDENTITYCHECK = 14,

            /// <summary>
            /// 就醫類別
            /// </summary>
            DELFA05 = 15,

            /// <summary>
            /// 其他免部分負擔選項
            /// </summary>
            OTHPAY = 16,

            /// <summary>
            /// 保健服務品項註記
            /// </summary>
            ITEM = 17,

            /// <summary>
            /// 手術申請單_地點(2021/12/2.Bruce.已棄用，改用OPROOM)
            /// </summary>
            INPLACE = 18,

            /// <summary>
            /// 手術申請單_麻醉方法
            /// </summary>
            ANESTHESIA = 19,

            /// <summary>
            /// 關懷藥物清單
            /// </summary>
            NHILIST = 20,

            /// <summary>
            /// 不列印手術通知單_清單
            /// </summary>
            NOTPRINT = 21,

            /// <summary>
            /// 列印手術通知單_清單
            /// </summary>
            CHKTOSUG = 22,

            /// <summary>
            /// 申報拆案註記
            /// </summary>
            CASEDIVIDEDREMARK = 23,

            /// <summary>
            /// 手術申請單_地點
            /// </summary>
            OPROOM = 24,

            /// <summary>
            /// 健保IC卡_醫令類別對照
            /// </summary>
            ORDERKIND_MAP = 25,

            /// <summary>
            /// 申報醫令分類
            /// </summary>
            ORDERKIND = 26,

            /// <summary>
            /// ICDETAIL建檔人員清單對照
            /// </summary>
            ICDETAIL_INSERT_UID = 27,

            /// <summary>
            /// 採檢日報告子類別
            /// </summary>
            COLLECTIONDATE_CLASS = 28,

            /// <summary>
            /// 交付處方註記
            /// </summary>
            ISRXOUT = 29,

            /// <summary>
            /// 身分確認&重大傷病LOG檔
            /// </summary>
            IDENTITY_LOG = 30,

            /// <summary>
            /// 申報用檢核類別
            /// </summary>
            CLAIMCHECKKIND = 31,

            /// <summary>
            /// 院區別
            /// </summary>
            HISLOCATION = 32,

            /// <summary>
            /// 手術
            /// </summary>
            SUGRATIO = 33,

            /// <summary>
            /// 癌症副作用與治療病情變化
            /// </summary>
            SIDEEFFECT = 34,

            /// <summary>
            /// 罕見疾病清單
            /// </summary>
            RareSick = 35,

            /// <summary>
            /// 申報總額類別
            /// </summary>
            HOSPTYPE = 36,

            /// <summary>
            /// 檢驗檢查加計部分負擔清單
            /// </summary>
            CHKPAY = 37,

            /// <summary>
            /// 健保IC卡異常代碼
            /// </summary>
            ERRCODE = 38,

            /// <summary>
            /// JobSource 代碼
            /// </summary>
            JobSource = 39,

            /// <summary>
            /// 牙醫總額特殊照護計畫醫令
            /// </summary>
            DENBudgetSpecial = 40,

            /// <summary>
            /// 牙科就診掛號費優免項目
            /// </summary>
            DENVIP56 = 41,

            /// <summary>
            /// 整合式照護計畫
            /// </summary>
            IntegratedCarePlan = 42,

            /// <summary>
            /// 申報處方調劑方式
            /// </summary>
            PrescriptionNote = 43,

            /// <summary>
            /// 執行醫令是否需要證照
            /// </summary>
            Code2License = 44,

            /// <summary>
            /// 牙科總額特殊照護計畫醫師
            /// </summary>
            DENBudgetSpecDoctor = 45,
            /// <summary>
            /// 列印手術處置單
            /// </summary>
            ORDER_SCH_PRINT = 46,
            /// <summary>
            /// CDC職業別
            /// </summary>
            OCCUPATION = 47,
            /// <summary>
            /// 門診特定藥品重複用藥群組
            /// </summary>
            DUPMED = 48,
            /// <summary>
            /// 預防保健 檢查項目代碼
            /// </summary>
            ITEMCODE = 49,
            /// <summary>
            /// 門診就診日超過四個月允許異動清單
            /// </summary>
            OPDSaveMore4Month = 50,
            /// <summary>
            /// OPD病患評鑑資料-病患歷史獲取對象
            /// </summary>
            PatientHistoryProv = 51,
            /// <summary>
            /// 門診報到紀錄表
            /// </summary>
            CHECKINTYPE = 52,
            /// <summary>
            /// 掛號方式
            /// </summary>
            REGMETHOD = 53,
        }

        /// <summary>
        /// 性別
        /// CodeGroup = SexCode
        /// </summary>
        public enum Sex
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "不明")]
            NoSetting = -9999,

            /// <summary>
            /// 男
            /// </summary>
            [Display(Name = "男")]
            Male = 1,

            /// <summary>
            /// 女
            /// </summary>
            [Display(Name = "女")]
            Female = 2,

            /// <summary>
            /// 不明
            /// </summary>
            [Display(Name = "不明")]
            NonBinary = 3,
        }

        /// <summary>
        /// 就醫來源[Display.Name為中文, Display.Description為3字英文縮寫(3 Word), Descrption為英文首字(1 Word), Groupname為(不分,住院,門診,急診)]
        /// CodeGroup = VISITKIND
        /// </summary>
        public enum VISITKIND
        {
            /// <summary>
            /// 共用
            /// </summary>
            [Display(Name = "共用", Description = "PUB", GroupName = "不分")]
            [Description("P")]
            Public = 0,

            /// <summary>
            /// 住院
            /// </summary>
            [Display(Name = "住院", Description = "IPD", GroupName = "住院")]
            [Description("I")]
            Inpatient = 1,

            /// <summary>
            /// 門診
            /// </summary>
            [Display(Name = "門診", Description = "OPD", GroupName = "門診")]
            [Description("O")]
            Outpatient = 2,

            /// <summary>
            /// 急診
            /// </summary>
            [Display(Name = "急診", Description = "ER", GroupName = "急診")]
            [Description("E")]
            Emergency = 3,
        }

        /// <summary>
        /// 院區別
        /// CodeGroup = HISLOCATION
        /// </summary>
        public enum HISLOCATION
        {
            [Display(Name = "內湖")]
            [Description("1.內湖院區")]
            NeiHu = 1,

            [Display(Name = "汀州")]
            [Description("2.汀州院區")]
            TingJhou = 2,
        }

        /// <summary>
        /// 病人狀態(因為有英文字母，建議取Descrption()來使用)
        /// </summary>
        public enum PatientStatus
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("0")]
            Null = 0,
            /// <summary>
            /// 未掛號(掛號)
            /// </summary>
            [Display(Name = "未掛號")]
            [Description("1")]
            NonRegister = 1,

            /// <summary>
            /// 已掛號(掛號)
            /// </summary>
            [Display(Name = "已掛號")]
            [Description("2")]
            Register = 2,

            /// <summary>
            /// 退掛號(掛號)
            /// </summary>
            [Display(Name = "退掛號")]
            [Description("3")]
            RegiserWithdraw = 3,

            /// <summary>
            /// 報到(掛號)
            /// </summary>
            [Display(Name = "報到未看")]
            [Description("4")]
            CheckIn = 4,

            /// <summary>
            /// 待診(診間)
            /// </summary>
            [Display(Name = "待診")]
            [Description("5")]
            WaitClinic = 5,

            /// <summary>
            /// 保留(診間)
            /// </summary>
            [Display(Name = "保留")]
            [Description("6")]
            ClinicRetention = 6,

            /// <summary>
            /// 醫囑結束(診間)
            /// </summary>
            [Display(Name = "醫囑結束")]
            [Description("7")]
            DoctorOrderFinish = 7,

            /// <summary>
            /// 留觀(診間)
            /// </summary>
            [Display(Name = "留觀")]
            [Description("8")]
            Observation = 8,

            /// <summary>
            /// 待床(診間)
            /// </summary>
            [Display(Name = "待床")]
            [Description("9")]
            WaitingForBed = 9,

            /// <summary>
            /// 未結案(護理)
            /// </summary>
            [Display(Name = "未結案")]
            [Description("10")]
            NotFinish = 10,

            /// <summary>
            /// 記錄中(護理)
            /// </summary>
            [Display(Name = "記錄中")]
            [Description("11")]
            NurseRecording = 11,

            /// <summary>
            /// 已結案(護理)
            /// </summary>
            [Display(Name = "已結案")]
            [Description("12")]
            NurseFinished = 12,

            /// <summary>
            /// 未批價(批價)
            /// </summary>
            [Display(Name = "未批價")]
            [Description("13")]
            UnPayment = 13,

            /// <summary>
            /// 已批價(批價)
            /// </summary>
            [Display(Name = "已批價")]
            [Description("14")]
            Paid = 14,

            /// <summary>
            /// 欠款待收/修帳待還(批價)
            /// </summary>
            [Display(Name = "欠款待收/修帳待還")]
            [Description("15")]
            Owe = 15,

            /// <summary>
            /// 呆帳(批價)
            /// </summary>
            [Display(Name = "呆帳")]
            [Description("16")]
            BadDebt = 16,

            /// <summary>
            /// 轉科(診間)
            /// </summary>
            [Display(Name = "轉科")]
            [Description("17")]
            DeptTransfer = 17,

            /// <summary>
            /// 診療中(診間)
            /// </summary>
            [Display(Name = "診療中")]
            [Description("18")]
            SeeingADoctor = 18,

            /// <summary>
            /// 預約掛號(掛號)
            /// </summary>
            [Display(Name = "預約掛號")]
            [Description("19")]
            RegiserRetention = 19,

            /// <summary>
            /// 過號
            /// </summary>
            [Display(Name = "過號")]
            [Description("23")]
            RegiserOverNumber = 23,

            /// <summary>
            /// 敬老優先 24 RE
            /// </summary>
            [Display(Name = "敬老優先")]
            [Description("24")]
            RespectingTheElderlyFirst = 24,

            /// <summary>
            /// 檢查 26 RE
            /// </summary>
            [Display(Name = "檢查")]
            [Description("26")]
            GoToLISRISCheck = 26,

            /// <summary>
            /// 牙科特殊治療追蹤
            /// </summary>
            [Display(Name = "牙科特殊治療追蹤")]
            [Description("28")]
            DENVIP56 = 28,

            /// <summary>
            /// 補批價
            /// </summary>
            [Display(Name = "補批價")]
            [Description("29")]
            ComplementPay = 29,

            /// <summary>
            /// 已合併帳務
            /// </summary>
            [Display(Name = "已合併帳務")]
            [Description("30")]
            CombinedPay = 30,

            /// <summary>
            /// 診間退掛
            /// </summary>
            [Display(Name = "診間退掛")]
            [Description("32")]
            ReturnRegister = 32,

            /// <summary>
            /// NOCHARGE 回診看報告
            /// </summary>
            [Display(Name = "回診看報告")]
            [Description("33")]
            NoChargeFollowupReport = 33,

            /// <summary>
            /// NOCHARGE 零元帳單
            /// </summary>
            [Display(Name = "零元帳單")]
            [Description("34")]
            NoChargeZeroPay = 34,

            /// <summary>
            /// 補批價(無金額異動)
            /// </summary>
            [Display(Name = "諮詢門診(不產掛號、診察費)")]
            [Description("38")]
            NoChargeConsultation = 38,

            /// <summary>
            /// 護眼護照
            /// </summary>
            [Display(Name = "護眼護照")]
            [Description("39")]
            NoChargeOPH = 39,


            /// <summary>
            /// 補批價(有金額異動)
            /// </summary>
            [Display(Name = "補批價(有金額異動)")]
            [Description("35")]
            ComplementPay_CashReModify = 35,

            /// <summary>
            /// 補批價(無金額異動)
            /// </summary>
            [Display(Name = "補批價(無金額異動)")]
            [Description("36")]
            ComplementPay_CashNoModify = 36,

            /// <summary>
            /// 同療掛號 C
            /// </summary>
            [Display(Name = "同療掛號")]
            [Description("C")]
            TherapyRegister = 67,

            /// <summary>
            /// 回診看報告 E
            /// </summary>
            [Display(Name = "回診看報告")]
            [Description("E")]
            FollowupReport = 69,

            /// <summary>
            /// 慢箋櫃檯掛號 F
            /// </summary>
            [Display(Name = "慢箋櫃檯掛號")]
            [Description("F")]
            SlowSickRegister = 70,

            /// <summary>
            /// 慢箋調劑完成 G
            /// </summary>
            [Display(Name = "慢箋調劑完成")]
            [Description("G")]
            SlowSickMedFinish = 71,

            /// <summary>
            /// 慢箋預約掛號 S
            /// </summary>
            [Display(Name = "慢箋預約掛號")]
            [Description("S")]
            SlowSickPreRegister = 83,
        }
        #endregion CODE_SRC 相關

        #region PUBCode
        /// <summary>
        /// PubCodeType
        /// </summary>
        public enum PubCodeType
        {
            /// <summary>
            /// 預設初始數值
            /// </summary>
            [Display(Name = "預設初始數值")]
            [Description("")]
            _NULL_,
            /// <summary>
            /// 檢核警示代碼
            /// </summary>
            [Display(Name = "檢核警示代碼")]
            [Description("")]
            BOD_SysLockType,
        }

        #endregion

        #region System_Param 相關
        /// <summary>
        /// 系統參數
        /// </summary>
        public enum SystemParam
        {
            [Display(Name = "掛號限制")]
            RegisterLimit = 1,

            [Display(Name = "部門管理者")]
            PERSONNEL_MANAGER = 2,

            [Display(Name = "診察費代碼")]
            DiagnoseFee = 3,

            [Display(Name = "付費方式")]
            FEETYPE = 4,

            [Display(Name = "ICD10處置診斷類別")]
            ICD10_DIAGKIND = 5,
            /// <summary>
            /// 套餐狀態 3.0.0.0已棄用
            /// </summary>
            [Display(Name = "套餐狀態")]
            PackageOrder = 6,

            [Display(Name = "申報復健治療項目")]
            ClaimRehReport = 7,

            /// <summary>
            /// 程式版號檢核
            /// </summary>
            [Display(Name = "程式版號檢核")]
            [Description("程式版號檢核")]
            VersionCheck = 8,

            /// <summary>
            /// 除錯模式檢核
            /// </summary>
            [Display(Name = "除錯模式檢核")]
            [Description("除錯模式檢核")]
            DebugModeCheck = 9,

            /// <summary>
            /// 測試方法啟用狀態
            /// </summary>
            [Display(Name = "測試方法啟用狀態")]
            [Description("測試方法啟用狀態")]
            TestFunctionStatus = 10,

            /// <summary>
            /// 套餐程式讀取相關資料庫啟用狀態 3.0.0.0已棄用
            /// </summary>
            [Display(Name = "套餐程式讀取相關資料庫啟用狀態")]
            [Description("套餐程式讀取相關資料庫啟用狀態")]
            DBConnectStatus = 11,

            /// <summary>
            /// 線上版本號檢核
            /// </summary>
            [Display(Name = "線上版本號檢核")]
            [Description("線上版本號檢核")]
            AssemblyVersion = 12,

            /// <summary>
            /// 驗證密碼
            /// </summary>
            [Display(Name = "驗證密碼")]
            [Description("驗證密碼")]
            Access_Password = 13,

            /// <summary>
            /// 程序檢核_線上鎖控
            /// </summary>
            [Display(Name = "程序檢核_線上鎖控")]
            [Description("程序檢核_線上鎖控")]
            Program_Check = 14,
            /// <summary>
            /// 申報系統
            /// </summary>
            [Display(Name = "申報系統")]
            ClaimSystem = 15,
            /// <summary>
            /// 批價系統
            /// </summary>
            [Display(Name = "批價系統")]
            CashierSystem = 16,
            /// <summary>
            /// 身分別判斷服務
            /// </summary>
            [Display(Name = "身分別判斷服務")]
            IdentityTypeService = 17,
            /// <summary>
            /// 健保署VPN亂數簽章
            /// </summary>
            [Display(Name = "健保署VPN亂數簽章")]
            NHIVPN_SignX = 18,

            [Display(Name = "軍階呈現GRANK")]
            ShowDifferent = 19,


            [Display(Name = "掛特殊號碼之權限")]
            CanRegSpOrderno = 20,


            [Display(Name = "醫師排班系統")]
            DSCSystem = 21,


            [Display(Name = "門診診間除錯模式")]
            OPD_DEBUG_MODE = 22,


            [Display(Name = "急診診間除錯模式")]
            ER_DEBUG_MODE = 23,


            [Display(Name = "門診版號檢核")]
            OPDVersion = 24,

            [Display(Name = "急診版號檢核")]
            ERVersion = 25,

            [Display(Name = "健保署讀卡機軟體版本號")]
            CsfsimVersion = 26,

            [Display(Name = "門診全處方退費角色限制科別")]
            OPD_Refund_RoleDeptOnly = 27,

            [Display(Name = "手術材料加成浮動比率")]
            SUGRATIO = 28,

            /// <summary>
            /// 健保署健保卡資料上傳
            /// </summary>
            [Display(Name = "健保署健保卡資料上傳")]
            NHIICCardDataUpload = 29,

            /// <summary>
            /// 診間科套餐顯示設定
            /// </summary>
            [Display(Name = "診間科套餐顯示設定")]
            PackageOrderDisplayDept = 30,

            /// <summary>
            /// HIS2住院_基本資料維護
            /// </summary>
            [Display(Name = "HIS2住院_基本資料維護")]
            HIS2_IPD_BDM = 31,

            /// <summary>
            /// 套餐維護程式相關設定 
            /// </summary>
            [Display(Name = "套餐維護程式相關設定")]
            HIS2_PackageOrder = 33,
        }

        /// <summary>
        /// 系統參數 ID
        /// </summary>
        public enum SystemParam_Paramid
        {
            /// <summary>
            /// 全部撈取
            /// </summary>
            [Display(Name = "全部撈取")]
            [Description("全部撈取")]
            _ALL_ = 0,
            /// <summary>
            /// 健保卡1.0上傳
            /// </summary>
            [Display(Name = "健保卡1.0上傳")]
            [Description("健保卡1.0上傳")]
            NHI10_XML_UPLOAD,
            /// <summary>
            /// 健保卡2.0上傳
            /// </summary>
            [Display(Name = "健保卡2.0上傳")]
            [Description("健保卡2.0上傳")]
            NHI20_XML_UPLOAD,
            /// <summary>
            /// 線上版本號檢核
            /// </summary>
            [Display(Name = "線上版本號檢核")]
            [Description("線上版本號檢核")]
            ASSEMBLY_FILE_VERSION,
            /// <summary>
            /// 健保署讀卡機軟體版本號
            /// </summary>
            [Display(Name = "健保署讀卡機軟體版本號")]
            [Description("健保署讀卡機軟體版本號")]
            CsfsimVersion,
            /// <summary>
            /// 健保卡上傳程式
            /// </summary>
            [Display(Name = "健保卡上傳程式")]
            [Description("健保卡上傳程式")]
            NHIICardUploadForm,
            /// <summary>
            /// OPD診間登入Master
            /// </summary>
            [Display(Name = "OPD診間登入Master")]
            [Description("OPD診間登入Master")]
            OPD_Dashboard_Master,

            #region Program_Check

            /// <summary>
            /// 門診身分確認IDNO
            /// </summary>
            [Display(Name = "門診身分確認IDNO")]
            [Description("門診身分確認IDNO")]
            OPD_IdentityVerificationForm_IDNO,
            /// <summary>
            /// 門診身分確認存檔並寫卡
            /// </summary>
            [Display(Name = "門診身分確認存檔並寫卡")]
            [Description("門診身分確認存檔並寫卡")]
            OPD_IdentityVerificationForm_SaveDataWithICCard,
            /// <summary>
            /// 門診身分確認存檔不寫卡
            /// </summary>
            [Display(Name = "門診身分確認存檔不寫卡")]
            [Description("門診身分確認存檔不寫卡")]
            OPD_IdentityVerificationForm_SaveDataWithoutICCard,
            /// <summary>
            /// 門診身分確認轉診病人回覆轉診單
            /// </summary>
            [Display(Name = "門診身分確認轉診病人回覆轉診單")]
            [Description("門診身分確認轉診病人回覆轉診單")]
            OPD_IdentityVerificationForm_ReferralRecordFirstFeedBackReplay,
            /// <summary>
            /// 門診病人基本資料菸酒檳榔史
            /// </summary>
            [Display(Name = "門診病人基本資料菸酒檳榔史")]
            [Description("門診病人基本資料菸酒檳榔史")]
            OPD_PatientInfoForm_CigaretteLiquorBetelNutHistory,
            /// <summary>
            /// 門診儀錶板詢問是否要讀取健保卡
            /// </summary>
            [Display(Name = "門診儀錶板詢問是否要讀取健保卡")]
            [Description("門診儀錶板詢問是否要讀取健保卡")]
            OPD_Dashboard_IsCheckNHIHcCard,
            /// <summary>
            /// 門診身分確認健保身分別下拉清單
            /// </summary>
            [Display(Name = "門診身分確認健保身分別下拉清單")]
            [Description("門診身分確認健保身分別下拉清單")]
            OPD_IdentityVerificationForm_NHIIdentityDropDownListCheck,
            /// <summary>
            /// 門診診間開立專用限制
            /// </summary>
            [Display(Name = "門診診間開立專用限制")]
            [Description("門診診間開立專用限制")]
            OPD_ClinicRoom_AddBatchRestrictedOrder,
            /// <summary>
            /// 門診診間是否使用新的事審判斷邏輯
            /// </summary>
            [Display(Name = "門診診間是否使用新的事審判斷邏輯")]
            [Description("門診診間是否使用新的事審判斷邏輯")]
            OPD_ClinicRoom_AddBatch_NewProjectItem,
            /// <summary>
            /// 門診儀錶板病患診療中登入診間檢核
            /// </summary>
            [Display(Name = "門診儀錶板病患診療中登入診間檢核")]
            [Description("門診儀錶板病患診療中登入診間檢核")]
            OPD_Dashboard_CheckInWhenPatientDiagnosis,
            /// <summary>
            /// 門診儀錶板檢核醫師是否出國支援證照
            /// </summary>
            [Display(Name = "門診儀錶板檢核醫師是否出國支援證照")]
            [Description("門診儀錶板檢核醫師是否出國支援證照")]
            OPD_Dashboard_CheckInDoctorGoingAbordSupportLicense,
            /// <summary>
            /// 門診儀錶板是否呼叫醫師是否出國支援證照API
            /// </summary>
            [Display(Name = "門診儀錶板是否呼叫醫師是否出國支援證照API")]
            [Description("門診儀錶板是否呼叫醫師是否出國支援證照API")]
            OPD_Dashboard_CheckInDoctorGoingAbordSupportLicense_EnabledAPICallFunc,
            /// <summary>
            /// 門診身分確認是否啟用已批價狀態鎖定身分別選單
            /// </summary>
            [Display(Name = "門診身分確認是否啟用已批價狀態鎖定身分別選單")]
            [Description("門診身分確認是否啟用已批價狀態鎖定身分別選單")]
            OPD_IdentityVerificationForm_IsCashierFinishDisableList,
            /// <summary>
            /// 門診結案病理檢體標籤列印
            /// </summary>
            [Display(Name = "門診結案病理檢體標籤列印")]
            [Description("門診結案病理檢體標籤列印")]
            OPD_ClinicRoom_Finish_PrintPathology,
            /// <summary>
            /// 門診檢核該次看診是否可在HIS2編輯
            /// </summary>
            [Display(Name = "門診檢核該次看診是否可在HIS2編輯")]
            [Description("門診檢核該次看診是否可在HIS2編輯")]
            OPD_ALL_CheckPatientIsAllowEditOnHIS2,
            /// <summary>
            /// 門診身分確認存檔_健保身份時檢核健保卡是否存在
            /// </summary>
            [Display(Name = "門診身分確認存檔_健保身份時檢核健保卡是否存在")]
            [Description("門診身分確認存檔_健保身份時檢核健保卡是否存在")]
            OPD_IdentityVerificationForm_SaveDataNHITypeCode_IsNHIICCardExist,
            /// <summary>
            /// 門診結案FINAL 如果AfterDRStatus為Null啟動補救措施
            /// </summary>
            [Display(Name = "門診結案FINAL 如果AfterDRStatus為Null啟動補救措施")]
            [Description("門診結案FINAL 如果AfterDRStatus為Null啟動補救措施")]
            OPD_ClinicRoom_Finish_FinalAfterDrstatusFailureSafe,
            /// <summary>
            /// 門診診間醫令寫入啟用批次模式
            /// </summary>
            [Display(Name = "門診診間醫令寫入啟用批次模式")]
            [Description("門診診間醫令寫入啟用批次模式")]
            OPD_ClinicRoom_AddBatchOrderEnabled,
            /// <summary>
            /// 門診診間結案是否紀錄健保卡取256N1狀態_統計用
            /// </summary>
            [Display(Name = "門診診間結案是否紀錄健保卡取256N1狀態_統計用")]
            [Description("門診診間結案是否紀錄健保卡取256N1狀態_統計用")]
            OPD_ClinicRoom_Finish_RecordNHICardReaderState,
            /// <summary>
            /// 門診診間身分確認_自動檢核程序依照EID跳過檢核(PARAMVARCHAR)
            /// </summary>
            [Display(Name = "門診診間身分確認_自動檢核程序依照EID跳過檢核(PARAMVARCHAR)")]
            [Description("門診診間身分確認_自動檢核程序依照EID跳過檢核(PARAMVARCHAR)")]
            OPD_IdentityVerificationForm_AutoCorrectedOverrideByEID,
            /// <summary>
            /// 門診生命徵象-IOT
            /// </summary>
            [Display(Name = "門診生命徵象-IOT")]
            [Description("門診生命徵象-IOT")]
            OPD_PatientInfoForm_IOTVitalsign,
            /// <summary>
            /// 門診儀錶板醫師報到檢核當下時間是位於班別時間內(或提前一小時)
            /// </summary>
            [Display(Name = "醫師報到檢核時間")]
            [Description("門診儀錶板醫師報到檢核當下時間是位於班別時間內(或提前一小時)")]
            OPD_Dashboard_DoctorProcessCheckInValidDateTime,
            /// <summary>
            /// 身分確認_NHI檢核鎖控
            /// </summary>
            [Display(Name = "NHI檢核鎖控")]
            [Description("身分確認_檢核鎖控")]
            OPD_IdentityVerificationForm_NHICheckIsEnabled,
            /// <summary>
            /// 藥物重複檢核是否開啟檢核
            /// </summary>
            [Display(Name = "慢箋、藥物重複檢核是否開啟檢核")]
            [Description("慢箋、藥物重複檢核是否開啟檢核")]
            OPD_EnabledSlowSickDuplicateDragChargeCheckForm,
            /// <summary>
            /// 藥物重複檢核是否啟用健保署API
            /// </summary>
            [Display(Name = "藥物重複檢核是否啟用健保署API")]
            [Description("藥物重複檢核是否啟用健保署API")]
            OPD_DuplicateDragEnabledNHIWebAPI,
            /// <summary>
            /// 身分確認 20230701 新制部分負擔邏輯
            /// </summary>
            [Display(Name = "身分確認 20230701 新制部分負擔邏輯")]
            [Description("身分確認 20230701 新制部分負擔邏輯")]
            OPD_IdentityVerificationForm_20230701NewPayTypeLogical,
            /// <summary>
            /// 身分確認 紙本開立重大傷病清單使用精神科以外之重大傷病ICD
            /// </summary>
            [Display(Name = "身分確認 紙本開立重大傷病清單使用精神科以外之重大傷病ICD")]
            [Description("身分確認 紙本開立重大傷病清單使用精神科以外之重大傷病ICD")]
            OPD_IdentityVerificationForm_HeavysickPaperOnlyUseStartWith_F_ICD,
            /// <summary>
            /// 健保VPN ICCard_DllLibrary底層是否關閉健保主控台讀寫卡功能 
            /// </summary>
            [Display(Name = "健保VPN ICCard_DllLibrary底層是否關閉健保主控台讀寫卡功能 ")]
            [Description("健保VPN ICCard_DllLibrary底層是否關閉健保主控台讀寫卡功能 ")]
            NHIVPN_IsDisabledNHI_Csfsim,

            /// <summary>
            /// 健保讀卡共用元件2.0 指定目前健保讀卡呼叫版本類型
            /// </summary>
            [Display(Name = "健保讀卡共用元件2.0 指定目前健保讀卡呼叫版本類型")]
            [Description("CSHIS50:讀卡控制5.0(主控台), CSHIS60:讀卡控制6.0(API)")]
            NHIVPN_NHIICCard_NHI_CallType,

            /// <summary>
            /// 身分確認 檢核是否正在住院中
            /// </summary>
            [Display(Name = "身分確認 檢核是否正在住院中")]
            [Description("身分確認 檢核是否正在住院中")]
            OPD_IdentityVerificationForm_EnabledNHIICCardIPDRecordCheck,

            /// <summary>
            /// 身分確認 進入時若讀取到重大傷病是否顯示提示視窗
            /// </summary>
            [Display(Name = "身分確認 進入時若讀取到重大傷病是否顯示提示視窗")]
            [Description("身分確認 進入時若讀取到重大傷病是否顯示提示視窗")]
            OPD_IdentityVerificationForm_WhenReadICHeavysickAlertForm,

            /// <summary>
            /// 身分確認 檢核卡片與福保部分負擔與優免身分是否相同
            /// </summary>
            [Display(Name = "身分確認 檢核卡片與福保部分負擔與優免身分是否相同")]
            [Description("身分確認 檢核卡片與福保部分負擔與優免身分是否相同")]
            OPD_IdentityVerificationForm_VerifyNHICardAndLowIncomeOrRongminOrRong,

            /// <summary>
            /// 慢箋重複藥物藥費核扣天數設定
            /// </summary>
            [Display(Name = "慢箋重複藥物藥費核扣天數設定")]
            [Description("慢箋重複藥物藥費核扣天數設定")]
            OPD_ClinicRoom_SlowSickDuplicateDragChargeCheckResult,

            /// <summary>
            /// 門診儀錶板_剔退程式
            /// </summary>
            [Display(Name = "門診儀錶板_剔退程式")]
            [Description("門診儀錶板_剔退程式")]
            OPD_Dashboard_HISEDITFORM,

            /// <summary>
            /// 門診診間_時間檢核
            /// </summary>
            [Display(Name = "門診診間_時間檢核")]
            [Description("門診診間_時間檢核")]
            OPD_ClinicRoom_TaskTimeCheck,

            /// <summary>
            /// 身分確認 IPD CVA 資料抓取開關
            /// </summary>
            [Display(Name = "身分確認 IPD CVA 資料抓取開關")]
            [Description("身分確認 IPD CVA 資料抓取開關")]
            OPD_IdentityVerificationForm_CVA_IPDData,

            /// <summary>
            /// 身分確認關閉時候 檢核是否有填寫轉診單
            /// </summary>
            [Display(Name = "身分確認關閉時 檢核是否有填寫轉診單")]
            [Description("身分確認關閉時 檢核是否有填寫轉診單")]
            OPD_IdentityVerificationForm_FormClosing_ReferralRecordReplayCheck,

            /// <summary>
            /// 門診診間結案時，是否全部醫令都掃過
            /// </summary>
            [Display(Name = "門診診間結案時，是否全部醫令都掃過")]
            [Description("門診診間結案時，是否全部醫令都掃過")]
            OPD_ClinicRoom_Finish_AlwaysScan,

            /// <summary>
            /// 門診診間藥品是否可作為慢籤服用
            /// </summary>
            [Display(Name = "門診診間藥品是否可作為慢籤服用")]
            [Description("門診診間藥品是否可作為慢籤服用")]
            OPD_ClinicRoom_SlowSickMed,

            /// <summary>
            /// 門診診間 列印 CPM999
            /// </summary>
            [Display(Name = "門診診間 列印 CPM999")]
            [Description("門診診間 列印 CPM999")]
            OPD_Print_CPM999,

            /// <summary>
            /// 身分確認 執行時間LOG
            /// </summary>
            [Display(Name = "身分確認 執行時間LOG")]
            [Description("身分確認 執行時間LOG")]
            OPD_IdentityVerificationForm_ExecuteLog,

            /// <summary>
            /// 門診診間 除錯模式 授權者清單
            /// </summary>
            [Display(Name = "門診診間 除錯模式 授權者清單")]
            [Description("門診診間 除錯模式 授權者清單")]
            OPD_Dashboard_AuthUserList,

            /// <summary>
            /// 門診診間 身分確認 不扣卡就醫序號檢核
            /// </summary>
            [Display(Name = "門診診間 身分確認 不扣卡就醫序號檢核")]
            [Description("門診診間 身分確認 不扣卡就醫序號檢核")]
            OPD_IdentityVerificationForm_CheckUncCountTreatItem,
            /// <summary>
            /// 健保卡資料上傳授權者AD清單
            /// </summary>
            [Display(Name = "健保卡資料上傳授權者AD清單")]
            [Description("健保卡資料上傳授權者AD清單")]
            NHIIC_Xml_Upload_AuthorizeUserList,
            /// <summary>
            /// 門診診間醫師報到查詢使用新版本
            /// </summary>
            [Display(Name = "門診診間醫師報到查詢使用新版本")]
            [Description("門診診間醫師報到查詢使用新版本")]
            OPD_DoctorProcessReportDutyNewVersion,
            /// <summary>
            /// 門診身分確認是否執行健保署API雲端重大查詢
            /// </summary>
            [Display(Name = "門診身分確認是否執行健保署API雲端重大查詢")]
            [Description("門診身分確認是否執行健保署API雲端重大查詢")]
            OPD_IdentityVerificationForm_VNHIhisGetCriticalIllnessIsEnable,
            /// <summary>
            /// 門診 檢查是否住院中 切換資料來源為HIS2
            /// </summary>
            [Display(Name = "門診 檢查是否住院中 切換資料來源為HIS2")]
            [Description("門診 檢查是否住院中 切換資料來源為HIS2")]
            OPD_IPDCheck_ChangeDataFromHIS2,
            /// <summary>
            /// 門診病患評鑑資料視窗使用版本
            /// </summary>
            [Display(Name = "門診病患評鑑資料視窗使用版本")]
            [Description("門診病患評鑑資料視窗使用版本")]
            OPD_PatientInfoForm_UseNewVersion,

            /// <summary>
            /// 是否啟用新版身分確認
            /// </summary>
            [Display(Name = "是否啟用新版身分確認")]
            [Description("是否啟用新版身分確認")]
            OPD_IdentityVerificationNewForm_Enabled,
            
            /// <summary>
            /// 門診診間保留時，是否提示當診日內有重複用藥
            /// </summary>
            [Display(Name = "門診診間保留時，是否提示當診日內有重複用藥")]
            [Description("門診診間保留時，是否提示當診日內有重複用藥")]
            OPD_ClinicRoom_Pause_IntradayDuplicateMed,

            /// <summary>
            /// 門診身分確認發送LOG，是否重置次數到1
            /// </summary>
            [Display(Name = "門診身分確認發送LOG，是否重置次數到1")]
            [Description("門診身分確認發送LOG，是否重置次數到1")]
            OPD_IdentityVerificNewForm_SendLogCounterReset,
            #endregion Program_Check

            #region Access_Password
            /// <summary>
            /// 公用診間_開啟剔退程式密碼檢核
            /// </summary>
            [Display(Name = "公用診間_開啟剔退程式密碼檢核")]
            [Description("公用診間_開啟剔退程式密碼檢核")]
            PublicClinicRoom_HISEDITFORM,
            /// <summary>
            /// 公用診間_剔退程式_全部剔退密碼檢核
            /// </summary>
            [Display(Name = "公用診間_剔退程式_全部剔退密碼檢核")]
            [Description("公用診間_剔退程式_全部剔退密碼檢核")]
            PublicClinicRoom_HISEDITFORM_AllCheckOut,

            /// <summary>
            /// 公用診間_SystemParam公用程式
            /// </summary>
            [Display(Name = "公用診間_SystemParam公用程式")]
            [Description("公用診間_SystemParam公用程式")]
            PublicClinicRoom_SystemParamUtilityForm,

            /// <summary>
            /// 健保卡資料上傳 MEMO異動密碼
            /// </summary>
            [Display(Name = "健保卡資料上傳 MEMO異動密碼")]
            [Description("健保卡資料上傳 MEMO異動密碼")]
            NHIUploadForm_MemoUpdate,

            /// <summary>
            /// 居家照護 設定特定拋轉日期
            /// </summary>
            [Display(Name = "居家照護 設定特定拋轉日期")]
            [Description("居家照護 設定特定拋轉日期")]
            HomeCareMainForm_SetTransferDate,
            /// <summary>
            /// 門診結案 資訊視窗 顯示CloseButton Password,需搭配USERID
            /// </summary>
            [Display(Name = "門診結案 資訊視窗 顯示CloseButton Password")]
            [Description("門診結案 資訊視窗 顯示CloseButton Password")]
            AccessPassword_OPDFinishInfoFormShowCloseButtonPassword,
            /// <summary>
            /// 門診診間異動超過四個月病歷資料需要授權碼
            /// </summary>
            [Display(Name = "門診診間異動超過四個月病歷資料需要授權碼")]
            [Description("門診診間異動超過四個月病歷資料需要授權碼")]
            AccessPassword_AuthorizationCodeRequireToSaveReocrdWhenPlanDiagDateMoreThan4MonthsAgo,
            #endregion Access_Password

            #region HomeCare
            /// <summary>
            /// 居家照護 下載 執行SQL
            /// </summary>
            [Display(Name = "居家照護 下載 執行SQL")]
            [Description("居家照護 下載 執行SQL")]
            HomeCare_Download_ExecuteSQL,
            /// <summary>
            /// 居家照護 上傳 執行SQL
            /// </summary>
            [Display(Name = "居家照護 上傳 執行SQL")]
            [Description("居家照護 上傳 執行SQL")]
            HomeCare_Upload_ExecuteSQL,
            #endregion

            /// <summary>
            /// 管理者功能
            /// </summary>
            [Display(Name = "管理者功能")]
            ManagerFunction,

            /// <summary>
            /// 編輯者功能
            /// </summary>
            [Display(Name = "編輯者功能")]
            EditFunction,

            /// <summary>
            /// 使用者功能
            /// </summary>
            [Display(Name = "使用者功能")]

            UserFunction,

            #region 批價使用
            /// <summary>
            /// 門診_身分別必須為非健保身分之科別代碼
            /// </summary>
            [Display(Name = "門診_身分別必須為非健保身分之科別代碼")]
            OPD_SelfPayDept,

            /// <summary>
            /// 部分負擔順序清單
            /// </summary>
            [Display(Name = "部分負擔順序清單")]
            PayTypePriorityList,
            /// <summary>
            /// 部分負擔不異動清單(REGEX)
            /// </summary>
            [Display(Name = "部分負擔不異動清單(REGEX)")]
            NoChangePayTypeList,
            /// <summary>
            /// 免收費部分負擔（判斷是否轉換榮民、福保使用）
            /// </summary>
            [Display(Name = "免收費部分負擔（判斷是否轉換榮民、福保使用）")]
            NoChargePayType,

            /// <summary>
            /// 不可使用門診批價科別
            /// 參數是Json
            /// </summary>
            [Display(Name = "不可使用門診批價科別")]
            OPD_CashierRejectDept,

            #endregion 批價使用

            #region NHIVPN_SignX 健保署VPN亂數簽章
            /// <summary>
            /// 取得就醫識別碼(類似 API 1.56 hisGetTreatNumICCard ) [簽章有效期8小時] 15 (搭配 3.安全模組卡 簽章)
            /// </summary>
            [Display(Name = "取得就醫識別碼(類似 API 1.56 hisGetTreatNumICCard ) [簽章有效期8小時] 15 (搭配 3.安全模組卡 簽章)")]
            Get_hisGetTreatNumNoICCard,
            /// <summary>
            /// 取得就醫識別碼(類似 API 1.54 hisGetTreatNumNoICCard ) [簽章有效期8小時] 17 (搭配 3.安全模組卡 簽章)
            /// </summary>
            [Display(Name = "取得就醫識別碼(類似 API 1.54 hisGetTreatNumNoICCard ) [簽章有效期8小時] 17 (搭配 3.安全模組卡 簽章)")]
            Get_hisGetTreatNumNoICCard2,
            /// <summary>
            /// 取得就醫識別碼 (Web API) 11 (搭配 3.安全模組卡 卡別簽章)
            /// </summary>
            [Display(Name = "取得就醫識別碼 (Web API) 11 (搭配 3.安全模組卡 卡別簽章)")]
            Get_MEDIDENTIFIER_WebAPI,
            /// <summary>
            /// 取得就醫識別碼 (Web API)之 健保測試卡使用 12 (搭配 3.安全模組卡 卡別簽章)
            /// </summary>
            [Display(Name = "取得就醫識別碼 (Web API)之 健保測試卡使用 12 (搭配 3.安全模組卡 卡別簽章)")]
            Get_TestMEDIDENTIFIER_WebAPI,
            #endregion

            #region NHIICCardDataUpload 健保署健保卡資料上傳
            /// <summary>
            /// 健保卡資料上傳健保署1.0 通知者
            /// </summary>
            [Display(Name = "健保卡資料上傳健保署1.0 通知者")]
            NHI10_Notifier,
            #endregion

            #region PackageOrderDisplayDept 診間科套餐顯示設定
            /// <summary>
            /// 門診診間科套餐顯示設定
            /// </summary>
            [Display(Name = "門診診間科套餐顯示設定 ")]
            PackageOrderDept_OPD,

            #endregion

            #region HIS2_IPD_BDM
            /// <summary>
            /// HIS2住院_基本資料維護-常用品項高權限使用者
            /// </summary>
            [Display(Name = "HIS2住院_基本資料維護-常用品項高權限使用者")]
            IPD_BDM_PackageMedicalItems_PowerUser,

            #endregion

            #region HIS2_PackageOrder
            /// <summary>
            /// 套餐維護程式 是否允許存取資料庫
            /// </summary>
            [Display(Name = "是否允許存取資料庫", Description = nameof(SystemParam.HIS2_PackageOrder))]
            PackageOrderAccessStatus,
            /// <summary>
            /// 套餐維護程式 醫令複製功能 線上相關設定
            /// </summary>
            [Display(Name = "醫令複製功能 線上相關設定", Description = nameof(SystemParam.HIS2_PackageOrder))]
            PackageOrderDittoOrdersSetting,
            /// <summary>
            /// 套餐維護程式 是否顯示可登入第二使用者按鈕
            /// </summary>
            [Display(Name = "醫令複製功能 是否顯示可登入第二使用者按鈕", Description = nameof(SystemParam.HIS2_PackageOrder))]
            PackageOrderAllowShownSecondUserIdDittoBtn,
            #endregion
        }
        #endregion System_Param 相關
       
        /// <summary>
        /// ICD.DIAGKIND 診斷碼類別
        /// 20251020經疾分組代芳確認，3 處置碼移除
        /// </summary>
        public enum DIAGKIND
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            NULL = 0,
            /// <summary>
            /// 診斷碼 1
            /// </summary>
            [Display(Name = "診斷碼")]
            DIAG = 1,
            /// <summary>
            /// 手術碼 2
            /// </summary>
            [Display(Name = "手術碼")]
            SUG = 2,
        }

        /// <summary>
        /// 時段
        /// </summary>
        public enum SegTime
        {
            /// <summary>
            /// 上午診
            /// </summary>
            [Display(Name = "上午診")]
            [Description("2")]
            morning = 2,

            /// <summary>
            /// 下午診
            /// </summary>
            [Display(Name = "下午診")]
            [Description("3")]
            afternoon = 3,

            /// <summary>
            /// 晚診
            /// </summary>
            [Display(Name = "晚診")]
            [Description("4")]
            night = 4,

            ///// <summary>
            ///// 中午診
            ///// </summary>
            //[Display(Name = "中午診")]
            //[Description("5")]
            //noon = 5,

            ///// <summary>
            ///// 黃昏診
            ///// </summary>
            //[Display(Name = "黃昏診")]
            //[Description("6")]
            //dusk = 6,

            /// <summary>
            /// A班
            /// </summary>
            [Display(Name = "A班")]
            [Description("A")]
            A = 999,

            /// <summary>
            /// B班
            /// </summary>
            [Display(Name = "B班")]
            [Description("B")]
            B = 998,

            /// <summary>
            /// C班
            /// </summary>
            [Display(Name = "C班")]
            [Description("C")]
            C = 997,
        }

        /// <summary>
        /// 是否作廢
        /// </summary>
        public enum CancelFlag
        {
            /// <summary>
            /// 未作廢
            /// </summary>
            N = 0,

            /// <summary>
            /// 作廢
            /// </summary>
            [Display(Name = "作廢")]
            Y = 1,
        }

        /// <summary>
        /// 是否註記
        /// </summary>
        public enum YesNoFlag
        {
            /// <summary>
            /// 否
            /// </summary>
            [Display(Name = "No", Description = "否")]
            N = 0,

            /// <summary>
            /// 是
            /// </summary>
            [Display(Name = "Yes", Description = "是")]
            Y = 1,
        }

        /// <summary>
        /// 醫令類別 適用於(MAINGroup 及 HOSPCHARGEID1)
        /// 目前MainGroup以.Tostring()取得對應，HOSPCHARGEID1以.ToNumberStringOrderCode()取得對應
        /// </summary>
        public enum OrderCodeType
        {
            /// <summary>
            /// 診察費
            /// </summary>
            [Display(Name = "診察費")]
            [Description("Diagnose Fee")]
            DIA = 01,

            /// <summary>
            /// 病房費
            /// </summary>
            [Display(Name = "病房費")]
            [Description("Ward Fee")]
            ROM = 02,

            /// <summary>
            /// 伙食費
            /// </summary>
            [Display(Name = "伙食費")]
            [Description("Diet Fee")]
            FOD = 03,

            /// <summary>
            /// 檢查費
            /// </summary>
            [Display(Name = "檢查費")]
            [Description("Examination Fee")]
            CHK = 04,

            /// <summary>
            /// 放射線診療費
            /// </summary>
            [Display(Name = "放射線診療費")]
            [Description("X-Ray Fee")]
            RAD = 05,

            /// <summary>
            /// 治療處置費
            /// </summary>
            [Display(Name = "治療處置費")]
            [Description("Therapeutic Treatment Fee")]
            PRO = 06,

            /// <summary>
            /// 手術費
            /// </summary>
            [Display(Name = "手術費")]
            [Description("Surgery Fee")]
            SUG = 07,

            /// <summary>
            /// 復健治療費
            /// </summary>
            [Display(Name = "復健治療費")]
            [Description("Rehabilitation Therapy Fee")]
            REH = 08,

            /// <summary>
            /// 血液血漿費
            /// </summary>
            [Display(Name = "血液血漿費")]
            [Description("Blood/Plasma Fee")]
            BLD = 09,

            /// <summary>
            /// 血液透析費
            /// </summary>
            [Display(Name = "血液透析費")]
            [Description("Hemodialysis Fee")]
            THE = 10,

            /// <summary>
            /// 麻醉費
            /// </summary>
            [Display(Name = "麻醉費")]
            [Description("Anesthesia Fee")]
            ANE = 11,

            /// <summary>
            /// 特殊材料費
            /// </summary>
            [Display(Name = "特殊材料費")]
            [Description("Special Medical Supplies Fee")]
            MAT = 12,

            /// <summary>
            /// 藥費
            /// </summary>
            [Display(Name = "藥費")]
            [Description("Medicine Fee")]
            MED = 13,

            /// <summary>
            /// 藥事服務費
            /// </summary>
            [Display(Name = "藥事服務費")]
            [Description("Pharmacy Service Fee")]
            SER = 14,

            /// <summary>
            /// 精神科治療費
            /// </summary>
            [Display(Name = "精神科治療費")]
            [Description("Psychiatric Treatment Fee")]
            PSY = 15,

            /// <summary>
            /// 注射技術費
            /// </summary>
            [Display(Name = "注射技術費")]
            [Description("Injection Fee")]
            INT = 16,

            /// <summary>
            /// 嬰兒費
            /// </summary>
            [Display(Name = "嬰兒費")]
            [Description("Infant Fee")]
            BAB = 17,

            /// <summary>
            /// 特定健保費
            /// </summary>
            [Display(Name = "特定健保費")]
            [Description("Special N.H.I. Fee")]
            INS = 18,

            /// <summary>
            /// 保留
            /// </summary>
            [Display(Name = "保留")]
            [Description("")]
            RES1 = 19,

            /// <summary>
            /// 電話費
            /// </summary>
            [Display(Name = "電話費")]
            [Description("Telephone Fee")]
            RES2 = 20,

            /// <summary>
            /// 掛號費
            /// </summary>
            [Display(Name = "掛號費")]
            [Description("Registration Fee")]
            REG = 21,

            /// <summary>
            /// 證明費
            /// </summary>
            [Display(Name = "證明費")]
            [Description("Certification Fee")]
            IDT = 22,

            /// <summary>
            /// 車費
            /// </summary>
            [Display(Name = "車費")]
            [Description("Ambulance Fee")]
            CAR = 23,

            /// <summary>
            /// 特定醫療費
            /// </summary>
            [Display(Name = "特定醫療費")]
            [Description("Special Medical Treatment Fee")]
            SPC = 24,

            /// <summary>
            /// 部份負擔費
            /// </summary>
            [Display(Name = "部份負擔費")]
            [Description("Copayment Fee")]
            PAR = 25,
        }

        #region 掛號相關

        /// <summary>
        /// 掛號方式
        /// </summary>
        public enum AppointmentMethod
        {
            [Display(Name = "櫃台掛號")]
            CounterAppointmentNow = 10,

            [Display(Name = "醫師現場約診")]
            DoctorAppointmentNow = 11,

            [Display(Name = "櫃台預約")]
            CounterAppointment = 14,

            [Display(Name = "櫃台初診預約掛號")]
            CounterFirsstAppointment = 15,

            [Display(Name = "住院31日回診")]
            InHospital = 16,

            [Display(Name = "住院31日預約回診")]
            InHospitalAppointment = 17,

            [Display(Name = "醫師現場特約診")]
            DoctorSpecialAppointmentNow = 21,

            [Display(Name = "語音掛號")]
            VoiceAppointmentNow = 20,

            [Display(Name = "語音預約")]
            VoiceAppointment = 24,

            [Display(Name = "語音初診掛號")]
            VoiceFirstAppointment = 25,

            [Display(Name = "自動櫃台")]
            AutoCounter = 30,

            [Display(Name = "自動櫃台預約")]
            AutoCounterAppointment = 34,

            [Display(Name = "IOS 掛號")]
            IOSAppointment = 35,

            [Display(Name = "Win8 掛號")]
            Win8Appointment = 36,

            [Display(Name = "Android 掛號")]
            AndroidAppointment = 37,

            [Display(Name = "LINE 掛號")]
            LINEAppointment = 38,

            [Display(Name = "急診櫃台")]
            EmergencyCounter = 40,

            [Display(Name = "BC肝篩檢特約診")]
            HepatitisCSpecial = 41,

            [Display(Name = "醫師預約")]
            DoctorAppointment = 44,

            [Display(Name = "無掛號批價")]
            Nothing = 50,

            [Display(Name = "新陳代謝科CKD")]
            Metabolism = 52,

            [Display(Name = "醫師預約特約診")]
            DoctorSpecialAppointment = 54,

            [Display(Name = "急診轉區")]
            EmergencyShift = 61,

            [Display(Name = "網路預約掛號")]
            WebAppointment = 64,

            [Display(Name = "網路預約掛號(新版)")]
            WebAppointmentNew = 65,

            [Display(Name = "同一療程")]
            SameTreat = 70,

            [Display(Name = "網路初診掛號")]
            WebFirstAppointment = 74,

            [Display(Name = "網路現場掛號")]
            WebAppointmentNow = 75,

            [Display(Name = "連續處方")]
            ContinuousPrescription = 80,

            [Display(Name = "委託代檢")]
            EntrustInspection = 90
        }

        #endregion

        #region 批價相關
        /// <summary>
        /// 折扣比
        /// </summary>
        public enum DiscountType
        {
            [Display(Name = "現金")]
            Amount = 1,

            [Display(Name = "% 百分比")]
            Percent = 2,
        }

        /// <summary>
        /// 醫令狀態
        /// </summary>
        public enum CureRecState
        {
            /// <summary>
            /// 正常
            /// </summary>
            [Display(Name = "正常")]
            [Description("A")]
            Normal = 1,
            /// <summary>
            /// 作廢
            /// </summary>
            [Display(Name = "作廢")]
            [Description("")]
            Invalid = 2,
            /// <summary>
            /// 沖銷
            /// </summary>
            [Display(Name = "沖銷")]
            [Description("D")]
            WriteOff = 3,
        }

        /// <summary>
        /// 部分負擔類別
        /// </summary>
        public enum CopaymentKind
        {
            /// <summary>
            /// 基本部分負擔
            /// </summary>
            [Display(Name = "基本部分負擔")]
            [Description("Basic Copayment")]
            BASE = 1,

            /// <summary>
            /// 藥品部分負擔
            /// </summary>
            [Display(Name = "藥品部分負擔")]
            [Description("Medicine Copayment")]
            MED = 2,

            /// <summary>
            /// 復健部分負擔
            /// </summary>
            [Display(Name = "復健部分負擔")]
            [Description("Treatment Copayment")]
            REH = 3,

            /// <summary>
            /// 檢驗/查部分負擔
            /// </summary>
            [Display(Name = "檢驗/查部分負擔")]
            [Description("Exeamination Copayment")]
            CHK = 4,
        }

        /// <summary>
        /// 作廢種類
        /// </summary>
        public enum VoidType
        {
            /// <summary>
            /// 一般轉身分作廢
            /// </summary>
            [Display(Name = "一般作廢(轉身分)")]
            [Description("Normal Void")]
            Normal = 1,

            /// <summary>
            /// 全退作廢（全處方退費）
            /// </summary>
            [Display(Name = "全退費作廢")]
            [Description("All Void")]
            All = 2,

        }
        #endregion 批價相關

        #region 申報相關
        /// <summary>
        /// 申報類別
        /// </summary>
        public enum ClaimType
        {
            /// <summary>
            /// 送核
            /// </summary>
            [Display(Name = "送核")]
            Apply = 1,

            /// <summary>
            /// 補報
            /// </summary>
            [Display(Name = "補報")]
            Reapply = 2,
        }

        /// <summary>
        /// 申報月份註記
        /// </summary>
        public enum ClaimMonthFlag
        {
            /// <summary>
            /// 不分(申復使用)
            /// </summary>
            [Display(Name = "不分")]
            NoFalg = 0,

            /// <summary>
            /// 上半月
            /// </summary>
            [Display(Name = "上半月")]
            FirstHalf = 1,

            /// <summary>
            /// 下半月
            /// </summary>
            [Display(Name = "下半月")]
            SecondHalf = 2,

            /// <summary>
            /// 全月
            /// </summary>
            [Display(Name = "全月")]
            Month = 3,

        }

        /// <summary>
        /// 補報原因註記
        /// </summary>
        public enum ReapplyFlag
        {
            /// <summary>
            /// 補報整筆案件
            /// </summary>
            [Display(Name = "整案", Description = "補報整筆案件")]
            All = 1,

            /// <summary>
            /// 補報部分醫令或醫令差額
            /// </summary>
            [Display(Name = "部分", Description = "補報部分醫令或醫令差額")]
            Part = 2,
        }

        /// <summary>
        /// 申報拆案註記
        /// </summary>
        public enum CaseDividedRemark
        {
            /// <summary>
            /// 牙科
            /// </summary>
            [Display(Name = "牙科")]
            Dental = 1,

            /// <summary>
            /// 結核
            /// </summary>
            [Display(Name = "結核")]
            TB = 2,

            /// <summary>
            /// 疫苗
            /// </summary>
            [Display(Name = "疫苗")]
            Vaccine = 3,

            /// <summary>
            /// 兒童疫苗
            /// </summary>
            [Display(Name = "兒童疫苗")]
            ChildVaccine = 4,

            /// <summary>
            /// 新冠肺炎
            /// </summary>
            [Display(Name = "新冠肺炎")]
            COVID19 = 5,

            /// <summary>
            /// 登革熱
            /// </summary>
            [Display(Name = "登革熱")]
            Dengue = 6,

            /// <summary>
            /// 洗腎
            /// </summary>
            [Display(Name = "洗腎")]
            Dialysis = 7,

            /// <summary>
            /// 愛滋
            /// </summary>
            [Display(Name = "愛滋")]
            AIDS = 8,

            /// <summary>
            /// 預防保健
            /// </summary>
            [Display(Name = "預防保健")]
            PreventiveHealthCare = 9,

            /// <summary>
            /// 大腸癌
            /// </summary>
            [Display(Name = "大腸癌")]
            ColonCa = 10,

            /// <summary>
            /// 口腔癌
            /// </summary>
            [Display(Name = "口腔癌")]
            OralCa = 11,

            /// <summary>
            /// 子宮頸癌
            /// </summary>
            [Display(Name = "子宮頸癌")]
            CervixCa = 12,

            /// <summary>
            /// 乳癌
            /// </summary>
            [Display(Name = "乳癌")]
            BreastCa = 13,

            /// <summary>
            /// 肺癌
            /// </summary>
            [Display(Name = "肺癌")]
            LungCa = 14,

            /// <summary>
            /// 長照機構加強型結核病防治計畫
            /// </summary>
            [Display(Name = "長照機構結核病")]
            LongTermCareTB = 15,

            /// <summary>
            /// 小兒聽力篩檢
            /// </summary>
            [Display(Name = "小兒聽力篩檢")]
            ChildHearingScreen = 16,

            /// <summary>
            /// 妊娠糖尿病
            /// </summary>
            [Display(Name = "妊娠糖尿病")]
            GDM = 17,

            /// <summary>
            /// 自定義
            /// </summary>
            [Display(Name = "自定義")]
            Customize = 99,
        }

        /// <summary>
        /// 轉診、處方調劑或資源共享
        /// </summary>
        public enum SharedCase
        {
            /// <summary>
            /// 轉診
            /// </summary>
            [Display(Name = "轉診", Description = "保險對象本次就醫係由他院轉診而來")]
            [Description("1")]
            ReferFromHospital = 1,

            /// <summary>
            /// 慢箋
            /// </summary>
            [Display(Name = "慢箋", Description = "慢性病連續處方調劑")]
            [Description("2")]
            Chronic = 2,

            /// <summary>
            /// 原檢查醫院
            /// </summary>
            [Display(Name = "原檢查醫院", Description = "全民健康保險特殊造影檢查影像及報告申請-原檢查醫院提供")]
            [Description("7")]
            FirstHospital = 7,

            /// <summary>
            /// 第2次處方醫院
            /// </summary>
            [Display(Name = "第2次處方醫院", Description = "全民健康保險特殊造影檢查影像及報告申請-第2次處方醫院")]
            [Description("8")]
            SecondHospital = 8,

            /// <summary>
            /// 在宅急症
            /// </summary>
            [Display(Name = "在宅急症", Description = "在宅急症")]
            [Description("EN")]
            EN = 9,

            //C6:中醫醫療資源不足地區巡迴醫療計畫（原名：無中醫鄉巡迴醫療）之轉診(106.10增訂)
            //G5:西醫基層(醫院支援)醫療資源不足地區改善方案-巡迴醫療之轉診(106.10增訂)
            //G9:全民健康保險山地離島地區醫療給付效益提昇計畫之轉診(106.10增訂)
            //F3:牙醫師至牙醫醫療資源不足地區巡迴醫療服務-巡迴醫療團（原名:牙醫師無牙醫鄉巡迴醫療服務）之轉診(106.10增訂)
            //FT:牙醫師至牙醫醫療資源不足地區巡迴服務計畫-社區醫療站之轉診(106.10增訂)
            //JA:收容對象醫療服務計畫-矯正機關內門診之轉診(106.10增訂)
            //T:無特約診所之鄉(鎮、市、區)逕赴該鄉(鎮、市、區)特約醫院就醫之視同轉診案件(1071106(107AD07265))
            //EC:居家醫療照護整合計劃(1080726(108AD01477))C6、G5、G9、F3、FT、JA限由原院所於計畫服務區域執行醫療服務轉回原院所時填寫
        }

        /// <summary>
        /// 申報方式
        /// </summary>
        public enum NHIClaimType
        {
            /// <summary>
            /// 書面
            /// </summary>
            [Display(Name = "書面")]
            Paper = 1,

            /// <summary>
            /// 媒體
            /// </summary>
            [Display(Name = "媒體")]
            Media = 2,

            /// <summary>
            /// 連線
            /// </summary>
            [Display(Name = "連線")]
            Connect = 3,
        }

        /// <summary>
        /// 總額類別
        /// CodeGroup=HOSPTYPE
        /// </summary>
        public enum HospType
        {
            /// <summary>
            /// 門診西醫診所
            /// </summary>
            [Display(Name = "西醫門診診所", Description = "西醫", ShortName = "11")]
            [Description("N")]
            _11 = 11,

            /// <summary>
            /// 西醫門診
            /// </summary>
            [Display(Name = "西醫門診", Description = "西醫", ShortName = "12")]
            [Description("N")]
            Outpatient = 12,

            /// <summary>
            /// 牙醫門診
            /// </summary>
            [Display(Name = "牙醫門診", Description = "牙醫", ShortName = "13")]
            [Description("T")]
            Dentist = 13,

            /// <summary>
            /// 中醫
            /// </summary>
            [Display(Name = "中醫", Description = "中醫", ShortName = "14")]
            [Description("C")]
            Chinese = 14,

            /// <summary>
            /// 門診洗腎
            /// </summary>
            [Display(Name = "門診洗腎", Description = "洗腎", ShortName = "15")]
            [Description("E")]
            Dialysis = 15,

            /// <summary>
            /// 居家照護
            /// </summary>
            [Display(Name = "居家照護", Description = "居護", ShortName = "19")]
            [Description("H")]
            HomeCare = 19,

            /// <summary>
            /// 住診西醫診所
            /// </summary>
            [Display(Name = "住診西醫診所", Description = "住院", ShortName = "21")]
            [Description("")]
            _21 = 21,

            /// <summary>
            /// 西醫住院
            /// </summary>
            [Display(Name = "西醫住院", Description = "住院", ShortName = "22")]
            [Description("")]
            Inpatient = 22,
        }

        /// <summary>
        /// 轉申報註記
        /// </summary>
        public enum IsDEC
        {
            /// <summary>
            /// 前線資料
            /// </summary>
            [Display(Name = "預設值", ShortName = "No")]
            N = 0,

            /// <summary>
            /// 已轉申報
            /// </summary>
            [Display(Name = "已轉申報", ShortName = "Yes")]
            Y = 1,

            /// <summary>
            /// 前線資料異動
            /// </summary>
            [Display(Name = "前線資料異動", ShortName = "Edit")]
            E = 2,

            /// <summary>
            /// 依健保規則不申報
            /// </summary>
            [Display(Name = "健保不申報", ShortName = "Delete", Description = "依健保規則不申報")]
            D = 3,

            /// <summary>
            /// 合併醫令
            /// </summary>
            [Display(Name = "合併醫令", ShortName = "Combined", Description = "醫令併至別筆")]
            C = 4,

            /// <summary>
            /// 申報調整
            /// </summary>
            [Display(Name = "申報調整", ShortName = "Modify")]
            M = 5,
        }

        /// <summary>
        /// 申報狀態
        /// </summary>
        public enum ClaimState
        {
            /// <summary>
            /// 不申報
            /// </summary>
            [Display(Name = "不申報")]
            NoClaim = 0,

            /// <summary>
            /// 申報
            /// </summary>
            [Display(Name = "申報")]
            Claim = 1,

            /// <summary>
            /// 住院申報
            /// </summary>
            [Display(Name = "住院申報")]
            InpClaim = 2,

            ///// <summary>
            ///// 因應合理量
            ///// </summary>
            //[Display(Name = "因應合理量")]
            //NoClaim = 3,

            /// <summary>
            /// 沒醫令
            /// </summary>
            [Display(Name = "沒醫令")]
            NoOrdfa = 4,

            /// <summary>
            /// 撤案
            /// </summary>
            [Display(Name = "撤案")]
            Withdraw = 5,

            /// <summary>
            /// 不申報、要提成
            /// </summary>
            [Display(Name = "不申報、要提成")]
            PPF = 6,
        }

        /// <summary>
        /// 申報案件分類
        /// </summary>
        public enum ClaimStageTable
        {
            /// <summary>
            /// 一般案件
            /// </summary>
            [Display(Name = "一般案件", ShortName = "一")]
            STAGE_REG = 0,

            /// <summary>
            /// 同療案件
            /// </summary>
            [Display(Name = "同療案件", ShortName = "同")]
            STAGE_SAME = 1,

            /// <summary>
            /// 排檢案件
            /// </summary>
            [Display(Name = "排檢案件", ShortName = "排")]
            STAGE_SCHEDULE = 2,

            /// <summary>
            /// 門診代報案件
            /// </summary>
            [Display(Name = "門診代報案件", ShortName = "住")]
            STAGE_IPD = 3,
        }

        /// <summary>
        /// 申報部分負擔計算模式
        /// </summary>
        public enum ClaimCalcMode
        {
            /// <summary>
            /// 系統計算
            /// </summary>
            [Display(Name = "系統計算")]
            Default = 0,

            /// <summary>
            /// 基本部份負擔不計算
            /// </summary>
            [Display(Name = "基本部份負擔不計算")]
            NoBase = 1,

            /// <summary>
            /// 基本部份負擔不計算
            /// </summary>
            [Display(Name = "藥品部分負擔不計算")]
            NoMed = 2,

            ///// <summary>
            ///// 檢驗檢查部分負擔不計算
            ///// </summary>
            //[Display(Name = "檢驗檢查部分負擔不計算")]
            //NoChk = 3,

            /// <summary>
            /// 全部部分負擔不計算
            /// </summary>
            [Display(Name = "全部部分負擔不計算")]
            Customized = 99,
        }

        /// <summary>
        /// 特殊案件狀態
        /// </summary>
        public enum SPECIALCASE
        {
            /// <summary>
            /// 包裹給付
            /// </summary>
            [Display(Name = "包裹給付")]
            PackagePayment = 1,

            /// <summary>
            /// 人工調整保留
            /// </summary>
            [Display(Name = "人工調整保留")]
            CustomKeep = 2,

            /// <summary>
            /// 上月保留下來
            /// </summary>
            [Display(Name = "上月保留下來")]
            LastMonthKeep = 3,
        }

        /// <summary>
        /// 健保醫療資料傳輸共通介面API TypeCode說明
        /// </summary>
        public enum NHI_RWM_Type
        {
            /// <summary>
            /// 03：醫費申報資料檢核結果回饋資料
            /// </summary>
            [Display(Name = "醫費申報資料檢核結果回饋資料", Description = "03")]
            Claim = 3,

            /// 04：電子轉診資料下載_回復電子轉診單
            
            /// <summary>
            /// 05：預檢醫費申報資料檢核結果回饋資料
            /// </summary>
            [Display(Name = "預檢醫費申報資料檢核結果回饋資料", Description = "05")]
            PreClaim = 5,

            /// <summary>
            /// 06：抽樣回饋資料
            /// </summary>
            [Display(Name = "抽樣回饋資料", Description = "06")]
            Sampling = 6,

            /// <summary>
            /// 07：醫療費用電子申復資料檢核結果回饋資料
            /// </summary>
            [Display(Name = "醫療費用電子申復資料檢核結果回饋資料", Description = "07")]
            ReDeclareDispute = 7,

            /// 08：健保醫療資訊雲端查詢批次下載作業

            /// <summary>
            /// 09：預檢醫療費用電子申復資料檢核結果回饋資料
            /// </summary>
            [Display(Name = "預檢醫療費用電子申復資料檢核結果回饋資料", Description = "09")]
            PreReDeclareDispute = 9,

            /// 10：電子轉診資料下載_開立電子轉診單
            /// 26：檢驗(查)每日上傳資料XML格式檢核結果回饋資料
            /// 27：電子轉診資料下載申請檔_管理作業csv下載
            /// 31：健保醫療資訊雲端查詢批次下載作業(新格式)
            /// 33：居家輕量藍牙就醫資料下載
        }
        #endregion 申報相關

        #region IC卡 定義
        /// <summary>
        /// 保險對象身分註記
        /// reg.INSUMARK
        /// </summary>
        public enum ICNoteInsuredIdentity
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            NULL = 0,

            /// <summary>
            /// 低收入戶
            /// </summary>
            [Display(Name = "低收入戶")]
            LowIncome = 1,

            /// <summary>
            /// 無職業的榮民
            /// </summary>
            [Display(Name = "無職業榮民")]
            RongminOrRong = 2,

            /// <summary>
            /// 一般身分
            /// </summary>
            [Display(Name = "一般身分")]
            Normal = 3,

            /// <summary>
            /// 中低收入戶
            /// </summary>
            [Display(Name = "中低收入戶")]
            MiddleLowIncome = 4,

            /// <summary>
            /// 災民
            /// </summary>
            [Display(Name = "災民")]
            Victims = 8,
        }

        /// <summary>
        /// 健保就醫類別
        /// </summary>
        public enum MedicalCategoryType
        {
            /// <summary>
            /// 無設定
            /// </summary>
            [Display(Name = "-9999")]
            無設定 = 0,

            /// <summary>
            /// 01西醫門診
            /// </summary>
            [Display(Name = "01")]
            西醫門診 = 1,

            /// <summary>
            /// 02牙醫門診
            /// </summary>
            [Display(Name = "02")]
            牙醫門診 = 2,

            /// <summary>
            /// 03中醫門診
            /// </summary>
            [Display(Name = "03")]
            中醫門診 = 3,

            /// <summary>
            /// 04急診
            /// </summary>
            [Display(Name = "04")]
            急診 = 4,

            /// <summary>
            /// 05住院
            /// </summary>
            [Display(Name = "05")]
            住院 = 5,

            /// <summary>
            /// 06門診轉診就醫
            /// </summary>
            [Display(Name = "06")]
            門診轉診就醫 = 6,

            /// <summary>
            /// 07門診手術後之回診
            /// </summary>
            [Display(Name = "07")]
            門診手術後之回診 = 7,

            /// <summary>
            /// 08住院患者出院之回診
            /// </summary>
            [Display(Name = "08")]
            住院患者出院之回診 = 8,

            /// <summary>
            /// AA同一療程項目以6次以內治療為限者
            /// </summary>
            [Display(Name = "AA")]
            同一療程項目以6次以內治療為限者 = 9,

            /// <summary>
            /// AB同一療程項目屬非6次以內治療為限者
            /// </summary>
            [Display(Name = "AB")]
            同一療程項目屬非6次以內治療為限者 = 10,

            /// <summary>
            /// AC預防保健
            /// </summary>
            [Display(Name = "AC")]
            預防保健 = 11,

            /// <summary>
            /// AD職業傷害或職業病門急診
            /// </summary>
            [Display(Name = "AD")]
            職業傷害或職業病門急診 = 12,

            /// <summary>
            /// AE慢性病連續處方箋領藥
            /// </summary>
            [Display(Name = "AE")]
            慢性病連續處方箋領藥 = 13,

            /// <summary>
            /// AF藥局調劑
            /// </summary>
            [Display(Name = "AF")]
            藥局調劑 = 14,

            /// <summary>
            /// AG排程檢查
            /// </summary>
            [Display(Name = "AG")]
            排程檢查 = 15,

            /// <summary>
            /// AH居家照護第二次以後
            /// </summary>
            [Display(Name = "AH")]
            居家照護第二次以後 = 16,

            /// <summary>
            /// AI同日同醫師看診第二次以後
            /// </summary>
            [Display(Name = "AI")]
            同日同醫師看診第二次以後 = 17,

            /// <summary>
            /// BA門急診當次轉住院之入院
            /// </summary>
            [Display(Name = "BA")]
            門急診當次轉住院之入院 = 18,

            /// <summary>
            /// BB出院
            /// </summary>
            [Display(Name = "BB")]
            出院 = 19,

            /// <summary>
            /// BC急診中住院中執行項目
            /// </summary>
            [Display(Name = "BC")]
            急診中住院中執行項目 = 20,

            /// <summary>
            /// BD急診第二日含以後之離院
            /// </summary>
            [Display(Name = "BD")]
            急診第二日含以後之離院 = 21,

            /// <summary>
            /// BE職業傷害或職業病之住院
            /// </summary>
            [Display(Name = "BE")]
            職業傷害或職業病之住院 = 22,

            /// <summary>
            /// BF繼續住院依規定分段結清者
            /// </summary>
            [Display(Name = "BF")]
            繼續住院依規定分段結清者 = 23,

            /// <summary>
            /// CA其他規定不須累計就醫序號即不扣除就醫次數者
            /// </summary>
            [Display(Name = "CA")]
            其他規定不須累計就醫序號即不扣除就醫次數者 = 24,

            /// <summary>
            /// DA門診轉出
            /// </summary>
            [Display(Name = "DA")]
            門診轉出 = 25,

            /// <summary>
            /// DB門診手術後需於7日內之1次回診
            /// </summary>
            [Display(Name = "DB")]
            門診手術後需於7日內之1次回診 = 26,

            /// <summary>
            /// DC住院患者出院後需於7日內之1次回診
            /// </summary>
            [Display(Name = "DC")]
            住院患者出院後需於7日內之1次回診 = 27,

            /// <summary>
            /// XA取消孕婦產前檢查
            /// </summary>
            [Display(Name = "XA")]
            取消孕婦產前檢查 = 28,

            /// <summary>
            /// YA兒童預防保健
            /// </summary>
            [Display(Name = "YA")]
            兒童預防保健 = 29,

            /// <summary>
            /// YB成人預防保健
            /// </summary>
            [Display(Name = "YB")]
            成人預防保健 = 30,

            /// <summary>
            /// YC婦女子宮頸抹片檢查
            /// </summary>
            [Display(Name = "YC")]
            婦女子宮頸抹片檢查 = 31,

            /// <summary>
            /// YD兒童牙齒預防保健
            /// </summary>
            [Display(Name = "YD")]
            兒童牙齒預防保健 = 32,

            /// <summary>
            /// YE婦女乳房檢查
            /// </summary>
            [Display(Name = "YE")]
            婦女乳房檢查 = 33,

            /// <summary>
            /// YF六十五歲老人流行性感冒疫苗
            /// </summary>
            [Display(Name = "YF")]
            六十五歲老人流行性感冒疫苗 = 34,

            /// <summary>
            /// YG定量免疫法糞便潛血檢查
            /// </summary>
            [Display(Name = "YG")]
            定量免疫法糞便潛血檢查 = 35,

            /// <summary>
            /// YH口腔黏膜檢查
            /// </summary>
            [Display(Name = "YH")]
            口腔黏膜檢查 = 36,

            /// <summary>
            /// ZA取消24小時內所有就醫類別
            /// </summary>
            [Display(Name = "ZA")]
            取消24小時內所有就醫類別 = 37,

            /// <summary>
            /// ZB取消24小時內部分就醫類別
            /// </summary>
            [Display(Name = "ZB")]
            取消24小時內部分就醫類別 = 38,

            /// <summary>
            /// 09透析門診 (111年1月1日起新增) 
            /// </summary>
            [Display(Name = "09")]
            透析門診 = 39,

            /// <summary>
            /// AJ透析門診療程第二次(含)以後 (111年1月1日起新增) 
            /// </summary>
            [Display(Name = "AJ")]
            透析門診療程第二次含以後 = 40,

            /// <summary>
            /// BG門診當次轉住院之入院  (110年12月20日起新增) 
            /// </summary>
            [Display(Name = "BG")]
            門診當次轉住院之入院 = 41,

            /// <summary>
            /// EA床號變更或轉床 (110年7月1日起新增) 
            /// </summary>
            [Display(Name = "EA")]
            床號變更或轉床 = 42,

            /// <summary>
            /// AK床號變更或轉床 (110年7月1日起新增) 
            /// </summary>
            [Display(Name = "AK")]
            急診留觀 = 43,
        }

        #region 健保IC卡-卡片別
        /// <summary>
        /// 健保IC卡-卡片別
        /// </summary>
        public enum ICCardType
        {
            /// <summary>
            /// 初始值 = 0
            /// </summary>
            [Display(Name = "初始值")]
            [Description("")]
            Null = 0,
            /// <summary>
            /// 安全模組(SAM) = 1
            /// </summary>
            [Display(Name = "雲端安全模組")]
            [Description("SAM")]
            SAM = 1,
            /// <summary>
            /// 健保IC卡 = 2
            /// </summary>
            [Display(Name = "健保IC卡")]
            [Description("HC")]
            HC = 2,
            /// <summary>
            /// 醫事人員卡 = 3
            /// </summary>
            [Display(Name = "醫事人員卡")]
            [Description("HPC")]
            HPC = 3
        }
        #endregion

        #region NHIICCard_門診處方籤_醫令類別
        /// <summary>
        /// IC1.0 NHIICCard_門診處方籤_醫令類別 A72
        /// </summary>
        public enum OPDPrescription_OrderType
        {
            /// <summary>
            /// 非長期藥品處方箋
            /// </summary>
            [Display(Name = "非長期藥品處方箋")]
            [Description("1")]
            NoneLongPrescription = 1,
            /// <summary>
            /// 長期藥品處方箋
            /// </summary>
            [Display(Name = "長期藥品處方箋")]
            [Description("2")]
            LongPrescription = 2,
            /// <summary>
            /// 診療
            /// </summary>
            [Display(Name = "診療")]
            [Description("3")]
            Diagnosis = 3,
            /// <summary>
            /// 特殊材料
            /// </summary>
            [Display(Name = "特殊材料")]
            [Description("4")]
            SpecialMaterial = 4,
            /// <summary>
            /// 重要醫令(含門住診)
            /// </summary>
            [Display(Name = "重要醫令(含門住診)")]
            [Description("5")]
            ImportationOrderIncludeOPDIPD = 5,
            /// <summary>
            /// 刪除非長期藥品處方箋
            /// </summary>
            [Display(Name = "刪除非長期藥品處方箋")]
            [Description("A")]
            DeleteNoneLongPrescription = 6,
            /// <summary>
            /// 刪除長期藥品處方箋
            /// </summary>
            [Display(Name = "刪除長期藥品處方箋")]
            [Description("B")]
            DeleteLongPrescription = 7,
            /// <summary>
            /// 刪除診療
            /// </summary>
            [Display(Name = "刪除診療")]
            [Description("C")]
            DeleteDiagnosis = 8,
            /// <summary>
            /// 刪除特殊材料
            /// </summary>
            [Display(Name = "刪除特殊材料")]
            [Description("D")]
            DeleteSpecialMaterial = 9,
            /// <summary>
            /// 刪除重要醫令(含門住診)
            /// </summary>
            [Display(Name = "刪除重要醫令(含門住診)")]
            [Description("E")]
            DeleteImportationOrderIncludeOPDIPD = 10,
            /// <summary>
            /// 矯正機關代號
            /// </summary>
            [Display(Name = "矯正機關代號")]
            [Description("J")]
            CorrectionAgencyCode = 11,
            /// <summary>
            /// 刪除矯正機關代號
            /// </summary>
            [Display(Name = "刪除矯正機關代號")]
            [Description("K")]
            DeleteCorrectionAgencyCode = 12,
            /// <summary>
            /// 虛擬醫令[R001~R004]
            /// </summary>
            [Display(Name = "虛擬醫令")]
            [Description("G")]
            VirtualMedicalOrder = 13,
            /// <summary>
            /// 刪除虛擬醫令
            /// </summary>
            [Display(Name = "刪除虛擬醫令")]
            [Description("H")]
            DeleteVirtualMedicalOrder = 14,
        }
        /// <summary>
        /// IC1.0 交付處方註記A78
        /// </summary>
        public enum ISRXOUT_KIND
        {
            /// <summary>
            /// 自行調劑
            /// </summary>
            [Display(Name = "自行調劑")]
            [Description("01")]
            SelfAdjustmentPrescription = 1,
            /// <summary>
            /// 交付調劑
            /// </summary>
            [Display(Name = "交付調劑")]
            [Description("02")]
            DeliveryAdjustmentPresecriptiop = 2,
            /// <summary>
            /// 自行執行
            /// </summary>
            [Display(Name = "自行執行")]
            [Description("03")]
            SelefExecuteOrder = 3,
            /// <summary>
            /// 交付執行
            /// </summary>
            [Display(Name = "交付執行")]
            [Description("04")]
            DeliveryExecuteOrder = 4,
            /// <summary>
            /// 自行調劑之慢性病連續處方箋
            /// </summary>
            [Display(Name = "自行調劑之慢性病連續處方箋")]
            [Description("05")]
            SelfAdjustmentSlowPrescription = 5,
            /// <summary>
            /// 交付調劑之慢性病連續處方箋
            /// </summary>
            [Display(Name = "交付調劑之慢性病連續處方箋")]
            [Description("06")]
            DeliveryAdjustmentSlowPresecriptiop = 6,
        }

        #endregion

        #region NHIICCard_
        /// <summary>
        /// 處方調劑方式 IC20
        /// </summary>
        public enum ISRXOUT_IC20
        {
            /// <summary>
            /// 自行調劑 0
            /// </summary>
            [Display(Name = "自行調劑")]
            [Description("0")]
            SelfAdjustmentPrescription = 1,
            /// <summary>
            /// 交付調劑 1
            /// </summary>
            [Display(Name = "交付調劑")]
            [Description("1")]
            DeliveryAdjustmentPresecription = 2,
            /// <summary>
            /// 未開(藥品)處方 2
            /// </summary>
            [Display(Name = "未開(藥品)處方")]
            [Description("2")]
            NoneMedPresecription = 3,
            /// <summary>
            /// 符合藥事法第102 條規定無藥事人員執業之偏遠地區或緊急急迫情形之自⾏調劑 6
            /// </summary>
            [Display(Name = "符合藥事法第102 條規定無藥事人員執業之偏遠地區或緊急急迫情形之自行調劑")]
            [Description("6")]
            EmergencySelfAdjustmentPrescription = 4,
            /// <summary>
            /// 藥品自⾏調劑,物理（或職能）治療自⾏執⾏ A
            /// </summary>
            [Display(Name = "藥品自⾏調劑,物理（或職能）治療自⾏執⾏")]
            [Description("A")]
            AdjustmentPresecriptionMEDSelfREHSelf,
            /// <summary>
            /// 藥品自⾏調劑,物理（或職能）治療交付執⾏ B
            /// </summary>
            [Display(Name = "藥品自⾏調劑,物理（或職能）治療交付執⾏")]
            [Description("B")]
            AdjustmentPresecriptionMEDSelfREHDelivery,
            /// <summary>
            /// 藥品交付調劑,物理（或職能）治療自⾏執⾏ C
            /// </summary>
            [Display(Name = "藥品交付調劑,物理（或職能）治療自⾏執⾏")]
            [Description("C")]
            AdjustmentPresecriptionMEDDeliveryREHSelf,
            /// <summary>
            /// 藥品交付調劑,物理（或職能）治療交付執⾏ D
            /// </summary>
            [Display(Name = "藥品交付調劑,物理（或職能）治療交付執⾏")]
            [Description("D")]
            AdjustmentPresecriptionMEDDeliveryREHDelivery,
            /// <summary>
            /// 未開處方調劑,物理（或職能）治療自⾏執⾏ E
            /// </summary>
            [Display(Name = "未開處方調劑,物理（或職能）治療自⾏執⾏")]
            [Description("E")]
            AdjustmentPresecriptionMEDNoneREHSelf,
            /// <summary>
            /// 未開處方調劑,物理（或職能）治療交付執⾏ F
            /// </summary>
            [Display(Name = "未開處方調劑,物理（或職能）治療交付執⾏")]
            [Description("F")]
            AdjustmentPresecriptionMEDNoneREHDelivery,
        }

        #endregion
        #endregion IC卡 定義

        #region 身分類別 20210415 Created 林伯翰
        /// <summary>
        /// 身分別 ALL List
        /// </summary>
        public enum IdentityAllType
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = nameof(EnumUtility.IdentityAllType.Null))]
            [Description("初始值")]
            Null,
            /// <summary>
            /// 身分類別.PatientGroup
            /// </summary>
            [Display(Name = nameof(EnumUtility.TypeCode))]
            [Description("身分類別")]
            TYPECODE,
            /// <summary>
            /// 保險類別.CODE_SRC.INSUTYPE
            /// </summary>
            [Display(Name = nameof(EnumUtility.InsType))]
            [Description("保險類別")]
            INSTYPE,
            /// <summary>
            /// PAYTYPE 負擔類別.BASPART.VISITKIND=2.PARTNO!=null
            /// </summary>
            [Display(Name = nameof(EnumUtility.CopaymentType))]
            [Description("負擔類別")]
            PAYTYPE,
            /// <summary>
            /// 優待類別
            /// </summary>
            [Display(Name = nameof(EnumUtility.VipType))]
            [Description("優待類別")]
            VIPTYPE,
            /// <summary>
            /// 就醫類別.CODE_SRC.DELFA05
            /// </summary>
            [Display(Name = nameof(EnumUtility.TreatItem))]
            [Description("就醫類別")]
            TREATITEM,
            /// <summary>
            /// 案件類別
            /// </summary>
            [Display(Name = nameof(EnumUtility.CaseType))]
            [Description("案件類別")]
            CASETYPE,
            /// <summary>
            /// 其他免部分負擔選項
            /// </summary>
            [Display(Name = nameof(EnumUtility.OthPay))]
            [Description("其他免部分負擔選項")]
            OTHPAY,
            /// <summary>
            /// 保健服務項目註記
            /// </summary>
            [Display(Name = nameof(EnumUtility.Item))]
            [Description("保健服務項目註記")]
            ITEM,
            /// <summary>
            /// 給付類別
            /// </summary>
            [Display(Name = nameof(EnumUtility.GiveType))]
            [Description("給付類別")]
            GIVETYPE,
            /// <summary>
            /// 檢查代碼
            /// </summary>
            [Display(Name = nameof(EnumUtility.ItemCode))]
            [Description("檢查代碼")]
            ITEMCODE
        }
        /// <summary>
        /// 身分類別.PatientGroup
        /// 取EnumValue
        /// </summary>
        public enum TypeCode
        {
            /// <summary>
            /// 未選取狀態[不在DB中，程式判斷使用]
            /// </summary>
            [Display(Name = null)]
            None = 0,

            /// <summary>
            /// 軍人(非健保)
            /// </summary>
            [Display(Name = "軍人(非健保)")]
            Military_NonNHI = 10,

            /// <summary>
            /// 民眾
            /// </summary>
            [Display(Name = "民眾")]
            People = 20,

            /// <summary>
            /// 兵役複檢(非健保)
            /// </summary>
            [Display(Name = "兵役複檢(非健保)")]
            MilitaryReview_NonNHI = 22,

            /// <summary>
            /// 健保
            /// </summary>
            [Display(Name = "健保")]
            NHI = 40,

            /// <summary>
            /// 軍人/軍眷(健保)
            /// </summary>
            [Display(Name = "軍人/軍眷(健保)")]
            MilitaryAndMilitaryFamily_NHI = 50,
        }

        /// <summary>
        /// 保險類別.CODE_SRC.INSUTYPE
        /// 取Description當Value
        /// </summary>
        public enum InsType
        {
            /// <summary>
            /// 一般民眾(無任何保險給付)
            /// </summary>
            [Display(Name = "一般民眾(無任何保險給付)")]
            [Description("00")]
            People,

            /// <summary>
            /// 縣巿政府兵役
            /// </summary>
            [Display(Name = "縣巿政府兵役")]
            [Description("AA")]
            CityMilitary,

            /// <summary>
            /// 自費兵役 AB
            /// </summary>
            [Display(Name = "自費兵役")]
            [Description("AB")]
            SelfPayMilitary,

            /// <summary>
            /// 無給付兵役 AC
            /// </summary>
            [Display(Name = "無給付兵役")]
            [Description("AC")]
            NonPayMilitary,

            /// <summary>
            /// 老人健康檢查 B1
            /// </summary>
            [Display(Name = "老人健康檢查")]
            [Description("B1")]
            ELderlyHealthCheck,

            /// <summary>
            /// 成人健康檢查 B2
            /// </summary> 
            [Display(Name = "成人健康檢查")]
            [Description("B2")]
            AdultHealthCheck,

            /// <summary>
            /// 新進員工體檢 B3
            /// </summary>
            [Display(Name = "新進員工體檢")]
            [Description("B3")]
            NewStaffHealthCheck,

            /// <summary>
            /// HIV B7
            /// </summary>
            [Display(Name = "HIV")]
            [Description("B7")]
            HIV,

            /// <summary>
            /// 台北市兒童輔助費用
            /// </summary>
            [Display(Name = "台北市兒童輔助費用")]
            [Description("C3")]
            ChildrenSubsidiesTaipei,

            /// <summary>
            /// 健保局
            /// </summary>
            [Display(Name = "健保局")]
            [Description("CD")]
            HIBureau,

            /// <summary>
            /// 精神科強制入院
            /// </summary>
            [Display(Name = "精神科強制入院")]
            [Description("NB")]
            MandatoryPsychiatricAdmission,

            /// <summary>
            /// 門診研究病房GCRC(W75)
            /// </summary>
            [Display(Name = "門診研究病房GCRC(W75)")]
            [Description("WW")]
            OutpatientResearchWard_GCRC,
        }

        /// <summary>
        /// 負擔類別.BASPART.VISITKIND=2.PARTNO!=null
        /// 取Description當Value
        /// </summary>
        public enum CopaymentType
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("-1")]
            None,

            /// <summary>
            /// 重大傷病
            /// 001
            /// </summary>
            [Display(Name = "重大傷病")]
            [Description("001")]
            MajorInjury,

            /// <summary>
            /// 分娩
            /// 002
            /// </summary>
            [Display(Name = "分娩")]
            [Description("002")]
            ChildBirth,

            /// <summary>
            /// 低收入戶
            /// 003
            /// </summary>
            [Display(Name = "低收入戶")]
            [Description("003")]
            LowIncomeHouseHolds,

            /// <summary>
            /// (無職)榮民、榮民遺眷
            /// 004
            /// </summary>
            [Display(Name = "榮民、榮民遺眷")]
            [Description("004")]
            VenteransAndFamily,

            /// <summary>
            /// 結核病患
            /// 005
            /// </summary>
            [Display(Name = "結核病患")]
            [Description("005")]
            TuberculosisPatients,

            /// <summary>
            /// 勞工職業傷害或職業病
            /// 006
            /// </summary>
            [Display(Name = "勞工職業傷害或職業病")]
            [Description("006")]
            EmploymentInjuryOrOccupationalDisease,

            /// <summary>
            /// 山地離島地區之醫院門急診
            /// 007
            /// </summary>
            [Display(Name = "山地離島地區之醫院門急診")]
            [Description("007")]
            MountainousIslandsOPDAndER,

            /// <summary>
            /// 離島醫院轉診至台灣門急診就醫
            /// 008
            /// </summary>
            [Display(Name = "離島醫院轉診至台灣門急診就醫")]
            [Description("008")]
            OutlyingIslandReferralToTWOPDAndER,

            /// <summary>
            /// 其他
            /// 009
            /// </summary>
            [Display(Name = "其他")]
            [Description("009")]
            Other,

            /// <summary>
            /// HMO
            /// 801
            /// </summary>
            [Display(Name = "HMO巡迴醫療")]
            [Description("801")]
            HMO,

            /// <summary>
            /// 多氯聯苯中毒
            /// 901
            /// </summary>
            [Display(Name = "多氯聯苯中毒")]
            [Description("901")]
            PCBPoisoning,

            /// <summary>
            /// 未滿3足歲兒童
            /// 902
            /// </summary>
            [Display(Name = "未滿3足歲兒童")]
            [Description("902")]
            ChildrenUnder3YearsOld,

            /// <summary>
            /// 新生兒就醫(出生六十日)
            /// 903
            /// </summary>
            [Display(Name = "新生兒就醫(出生六十日)")]
            [Description("903")]
            NewbornsSeekMedicalAttention_60DaysAfterBirth,

            /// <summary>
            /// 愛滋病患
            /// 904
            /// </summary>
            [Display(Name = "愛滋病患")]
            [Description("904")]
            AIDS,

            /// <summary>
            /// 替代役役男
            /// 906
            /// </summary>
            [Display(Name = "替代役役男")]
            [Description("906")]
            AlternativeServiceman,

            /// <summary>
            /// 代辦海巡署輔助部份負擔
            /// 908
            /// </summary>
            [Display(Name = "代辦海巡署輔助部份負擔")]
            [Description("908")]
            CoastGuardPartTypeAgent,

            /// <summary>
            /// 代辦中央警察大學輔助部份負擔
            /// 909
            /// </summary>
            [Display(Name = "代辦中央警察大學輔助部份負擔")]
            [Description("909")]
            CenterPoliceUniversityPartTypeAgent,

            /// <summary>
            /// 代辦內政部消防署輔助部份負擔
            /// 910
            /// </summary>
            [Display(Name = "代辦內政部消防署輔助部份負擔")]
            [Description("910")]
            MinistryOfTheInteriorFireDepartmentPartTypeAgent,

            /// <summary>
            /// 代辦內政部空勤總隊輔助部份負擔
            /// 911
            /// </summary>
            [Display(Name = "代辦內政部空勤總隊輔助部份負擔")]
            [Description("911")]
            MinistryOfTheInteriorAireCrewCorpsPartTypeAgent,

            /// <summary>
            /// 代辦內政部警政署輔助部份負擔
            /// 912
            /// </summary>
            [Display(Name = "代辦內政部警政署輔助部份負擔")]
            [Description("912")]
            MinistryOfTheInteriorPoliceDepartmentPartTypeAgent,

            /// <summary>
            /// 代辦國防部輔助部份負擔
            /// 913
            /// </summary>
            [Display(Name = "代辦國防部輔助部份負擔")]
            [Description("913")]
            MinistryOfNationalDefensePartTypeAgent,

            /// <summary>
            /// 代辦疾管署輔助部份負擔
            /// 914
            /// </summary>
            [Display(Name = "代辦疾管署輔助部份負擔")]
            [Description("914")]
            CDCPartTypeAgent,

            /// <summary>
            /// 代辦移民署輔助部份負擔
            /// 915
            /// </summary>
            [Display(Name = "代辦移民署輔助部份負擔")]
            [Description("915")]
            MinistryOfTheInteriorImmigrationPartTypeAgent,

            /// <summary>
            /// 長照機構結核病防治
            /// 916
            /// </summary>
            [Display(Name = "長照機構結核病防治")]
            [Description("916")]
            LongTermCareTBPrevention,

            /// <summary>
            /// 有職榮民
            /// 917
            /// </summary>
            [Display(Name = "917")]
            [Description("917")]
            EmployedVeterans,

            /// <summary>
            /// 醫學中心急診
            /// A00
            /// </summary>
            [Display(Name = "醫學中心急診")]
            [Description("A00")]
            MedicalCenter_EmergencyRoom,

            /// <summary>
            /// 醫學中心一般門診
            /// A12
            /// </summary>
            [Display(Name = "醫學中心一般門診")]
            [Description("A12")]
            MedicalCenter_OutpatientClinic,

            /// <summary>
            /// 醫學中心一般門診；持殘障手冊
            /// A13
            /// </summary>
            [Display(Name = "醫學中心一般門診；持殘障手冊")]
            [Description("A13")]
            MedicalCenter_OutpatientClinic_WithHandicapHandbook,

            /// <summary>
            /// 醫學中心;藥品.復健
            /// A20
            /// </summary>
            [Display(Name = "醫學中心;藥品.復健")]
            [Description("A20")]
            MedicalCenter_Rehabilitation,

            /// <summary>
            /// 醫學中心;藥品.復健;持殘障手冊
            /// A23
            /// </summary>
            [Display(Name = "醫學中心;藥品.復健;持殘障手冊")]
            [Description("A23")]
            MedicalCenter_RehabilitationWithHandicapHandbook,

            /// <summary>
            /// 醫學中心轉診
            /// A30
            /// </summary>
            [Display(Name = "醫學中心轉診")]
            [Description("A30")]
            MedicalCenter_Referral,

            /// <summary>
            /// 醫學中心第二至五次轉診
            /// A31
            /// </summary>
            [Display(Name = "醫學中心第二至五次轉診")]
            [Description("A31")]
            MedicalCenter_SecondToFifthReferrals,

            /// <summary>
            /// 醫學中心回診
            /// A40
            /// </summary>
            [Display(Name = "醫學中心回診")]
            [Description("A40")]
            MedicalCenter_Visit,

            /// <summary>
            /// 醫學中心牙醫急診
            /// E00
            /// </summary>
            [Display(Name = "醫學中心牙醫急診")]
            [Description("E00")]
            MedicalCenter_DEN_ER,

            /// <summary>
            /// 醫學中心牙醫一般門診
            /// E10
            /// </summary>
            [Display(Name = "醫學中心牙醫一般門診")]
            [Description("E10")]
            MedicalCenter_OutpatientClinicOf_DEN,

            /// <summary>
            /// 醫學中心牙醫一般門診；持殘障手冊
            /// E13
            /// </summary>
            [Display(Name = "醫學中心牙醫一般門診；持殘障手冊")]
            [Description("E13")]
            MedicalCenter_OutpatientClinicOf_DEN_WithHandicapHandbook,

            /// <summary>
            /// 醫學中心;高利用率者(93年1月後停用)
            /// E20
            /// </summary>
            [Display(Name = "醫學中心;高利用率者(93年1月後停用)")]
            [Description("E20")]
            MedicalCenter_HighUtilizationRate_StoppedAfterJan1993,

            /// <summary>
            /// 醫學中心;高利用率者;持殘障手冊(93年1月後停用)
            /// E23
            /// </summary>
            [Display(Name = "醫學中心;高利用率者;持殘障手冊(93年1月後停用)")]
            [Description("E23")]
            MedicalCenter_HighUtilizationRateWithHandicapHandbook_StoppedAfterJan1993,

            /// <summary>
            /// 居家照護(沒有開藥)
            /// K00
            /// </summary>
            [Display(Name = "居家照護(沒有開藥)")]
            [Description("K00")]
            HomeCare_NonMedicationIsPrescribed,

            /// <summary>
            /// 居家照護(有開藥)
            /// K20
            /// </summary>
            [Display(Name = "居家照護(有開藥)")]
            [Description("K20")]
            HomeCare_WithMedication,

            /// <summary>
            /// 戒菸門診
            /// Z00
            /// </summary>
            [Display(Name = "戒菸門診")]
            [Description("Z00")]
            SmokingCessationClinic,

            /// <summary>
            /// 醫學中心急診;持身心障礙證明
            /// A03
            /// </summary>
            [Display(Name = "醫學中心急診;持身心障礙證明")]
            [Description("A03")]
            MedicalCenter_EmergencyRoom_WithHandicapHandbook,

            /// <summary>
            /// 醫學中心急診;中低收入戶
            /// A0F
            /// </summary>
            [Display(Name = "醫學中心急診;中低收入戶")]
            [Description("A0F")]
            MedicalCenter_EmergencyRoom_MiddleLowIncomeHouseHolds,

            /// <summary>
            /// 醫學中心;一般門診僅開立藥品;中低收入註記(112.3 新增)
            /// A1P
            /// </summary>
            [Display(Name = "醫學中心;一般門診僅開立藥品;中低收入註記(112.3 新增)")]
            [Description("A1P")]
            MedicalCenter_Outpatient_OnlyMedicines_MiddleLowIncome,

            /// <summary>
            /// 醫學中心;一般門診加藥品或復健;中低收入註記(112.3 新增)
            /// A2P
            /// </summary>
            [Display(Name = "醫學中心;一般門診加藥品或復健;中低收入註記(112.3 新增)")]
            [Description("A2P")]
            MedicalCenter_Outpatient_MedicinesOrRehabilitation_MiddleLowIncome,

            /// <summary>
            /// 醫學中心;轉診(轉入之院所適用);中低收入註記(112.3 新增)
            /// A3P
            /// </summary>
            [Display(Name = "醫學中心;轉診(轉入之院所適用);中低收入註記(112.3 新增)")]
            [Description("A3P")]
            MedicalCenter_Referrals_MiddleLowIncome,

            /// <summary>
            /// 醫學中心;住院出院或門、急診手術後首次之回診加藥品或復健;中低收入註記(112.3 新增)
            /// A4P
            /// </summary>
            [Display(Name = "醫學中心;住院出院或門、急診手術後首次之回診加藥品或復健;中低收入註記(112.3 新增)")]
            [Description("A4P")]
            MedicalCenter_FirstFollowUp_MedicinesOrRehabilitation_MiddleLowIncome,

            /// <summary>
            /// 醫學中心;藥品
            /// A14
            /// </summary>
            [Display(Name = "醫學中心;藥品")]
            [Description("A14")]
            MedicalCenter_Medicines,

            /// <summary>
            /// 醫學中心;藥品;持殘障手冊
            /// A17
            /// </summary>
            [Display(Name = "醫學中心;藥品;持殘障手冊")]
            [Description("A17")]
            MedicalCenter_Medicines_WithHandicapHandbook,

            /// <summary>
            /// 醫學中心;藥品.復健
            /// A24
            /// </summary>
            [Display(Name = "醫學中心;藥品.復健")]
            [Description("A24")]
            MedicalCenter_Medicines_Rehabilitation,

            /// <summary>
            /// 醫學中心;藥品.復健;持殘障手冊
            /// A27
            /// </summary>
            [Display(Name = "醫學中心;藥品.復健;持殘障手冊")]
            [Description("A27")]
            MedicalCenter_Medicines_RehabilitationWithHandicapHandbook,

            /// <summary>
            /// 醫學中心轉診;復健;持殘障手冊
            /// A33
            /// </summary>
            [Display(Name = "醫學中心轉診;復健;持殘障手冊")]
            [Description("A33")]
            MedicalCenter_Transfer_RehabilitationWithHandicapHandbook,

            /// <summary>
            /// 醫學中心轉診;藥品.復健
            /// A34
            /// </summary>
            [Display(Name = "醫學中心轉診;藥品.復健")]
            [Description("A34")]
            MedicalCenter_Transfer_Medicines_Rehabilitation,

            /// <summary>
            /// 醫學中心轉診;藥品.復健;持殘障手冊
            /// A37
            /// </summary>
            [Display(Name = "醫學中心轉診;藥品.復健;持殘障手冊")]
            [Description("A37")]
            MedicalCenter_Transfer_Medicines_RehabilitationWithHandicapHandbook,

            /// <summary>
            /// 醫學中心回診;復健;持殘障手冊
            /// A43
            /// </summary>
            [Display(Name = "醫學中心回診;復健;持殘障手冊")]
            [Description("A43")]
            MedicalCenter_Return_RehabilitationWithHandicapHandbook,

            /// <summary>
            /// 醫學中心回診;藥品.復健
            /// A44
            /// </summary>
            [Display(Name = "醫學中心回診;藥品.復健")]
            [Description("A44")]
            MedicalCenter_Return_Medicines_Rehabilitation,

            /// <summary>
            /// 醫學中心回診;藥品.復健;持殘障手冊
            /// A47
            /// </summary>
            [Display(Name = "醫學中心回診;藥品.復健;持殘障手冊")]
            [Description("A47")]
            MedicalCenter_Return_Medicines_RehabilitationWithHandicapHandbook
        }

        /// <summary>
        /// 身分別-優待類別
        /// </summary>
        public enum VipType
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("")]
            None,
            /// <summary>
            /// 門診低收入戶及志工掛號費10元、診察費優免
            /// </summary>
            [Display(Name = "門診低收入戶及志工掛號費10元、診察費優免")]
            [Description("002")]
            _002,

            /// <summary>
            /// 門診低收入戶掛號費優免
            /// </summary>
            [Display(Name = "門診低收入戶掛號費優免")]
            [Description("003")]
            _003,

            /// <summary>
            /// 門診軍眷(一般)
            /// </summary>
            [Display(Name = "門診軍眷(一般)")]
            [Description("01")]
            _01,

            /// <summary>
            /// 門診撫卹令（眷屬）
            /// </summary>
            [Display(Name = "門診撫卹令（眷屬）")]
            [Description("01A")]
            _01A,

            /// <summary>
            /// 軍眷減量
            /// </summary>
            [Display(Name = "軍眷減量")]
            [Description("01D")]
            _01D,

            /// <summary>
            /// 門診軍眷台北市兒童
            /// </summary>
            [Display(Name = "門診軍眷台北市兒童")]
            [Description("02")]
            _02,

            /// <summary>
            /// 臺北巿軍眷兒童第二類輪狀病毒疫苗及常規苗(優免2070元、掛號費0元)
            /// </summary>
            [Display(Name = "臺北巿軍眷兒童第二類輪狀病毒疫苗及常規苗(優免2070元、掛號費0元)")]
            [Description("02B")]
            _02B,

            /// <summary>
            /// 臺北巿軍眷兒童第一、三類輪狀病毒疫苗及常規苗(優免1050元、掛號費0元)
            /// </summary>
            [Display(Name = "臺北巿軍眷兒童第一、三類輪狀病毒疫苗及常規苗(優免1050元、掛號費0元)")]
            [Description("02R")]
            _02R,

            /// <summary>
            /// 門診一般台北市兒童
            /// </summary>
            [Display(Name = "門診一般台北市兒童")]
            [Description("03")]
            _03,

            /// <summary>
            /// 北巿未滿12歲(重症/罕病)兒童
            /// </summary>
            [Display(Name = "北巿未滿12歲(重症/罕病)兒童")]
            [Description("03A")]
            _03A,

            /// <summary>
            /// 臺北巿一般兒童兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)
            /// </summary>
            [Display(Name = "臺北巿一般兒童兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)")]
            [Description("03B")]
            _03B,

            /// <summary>
            /// 北市未滿2歲(極低體重)兒童
            /// </summary>
            [Display(Name = "北市未滿2歲(極低體重)兒童")]
            [Description("03C")]
            _03C,

            /// <summary>
            /// 臺北巿一般兒童第一類輪狀病毒疫苗及常規苗(優免1050元、掛號費50元)
            /// </summary>
            [Display(Name = "臺北巿一般兒童第一類輪狀病毒疫苗及常規苗(優免1050元、掛號費50元)")]
            [Description("03R")]
            _03R,

            /// <summary>
            /// 門急診一般僑保
            /// </summary>
            [Display(Name = "門急診一般僑保")]
            [Description("04")]
            _04,

            /// <summary>
            /// 門急診國防醫學院僑保
            /// </summary>
            [Display(Name = "門急診國防醫學院僑保")]
            [Description("05")]
            _05,

            /// <summary>
            /// 軍眷藥品、衛材自費，其他費用優免
            /// </summary>
            [Display(Name = "軍眷藥品、衛材自費，其他費用優免")]
            [Description("09")]
            _09,

            /// <summary>
            /// 現役將級
            /// </summary>
            [Display(Name = "現役將級")]
            [Description("10")]
            _10,

            /// <summary>
            /// 疾管局藥癮記帳
            /// </summary>
            [Display(Name = "疾管局藥癮記帳")]
            [Description("100")]
            _100,

            /// <summary>
            /// 台北地檢署緩起訴藥癮記帳
            /// </summary>
            [Display(Name = "台北地檢署緩起訴藥癮記帳")]
            [Description("101")]
            _101,

            /// <summary>
            /// 士林地檢署緩起訴藥癮記帳
            /// </summary>
            [Display(Name = "士林地檢署緩起訴藥癮記帳")]
            [Description("102")]
            _102,

            /// <summary>
            /// 大陸來台觀光受傷人士(無優免)
            /// </summary>
            [Display(Name = "大陸來台觀光受傷人士(無優免)")]
            [Description("103")]
            _103,

            /// <summary>
            /// 台北巿禽畜業者發燒優免掛號費、部份負擔費用
            /// </summary>
            [Display(Name = "台北巿禽畜業者發燒優免掛號費、部份負擔費用")]
            [Description("104")]
            _104,

            /// <summary>
            /// 疾管局美沙冬特殊篩檢記帳
            /// </summary>
            [Display(Name = "疾管局美沙冬特殊篩檢記帳")]
            [Description("105")]
            _105,

            /// <summary>
            /// 台北巿孕婦唐氏症篩檢(軍人)
            /// </summary>
            [Display(Name = "台北巿孕婦唐氏症篩檢(軍人)")]
            [Description("106")]
            _106,

            /// <summary>
            /// 台北巿孕婦唐氏症篩檢(軍眷、員工--紅)
            /// </summary>
            [Display(Name = "台北巿孕婦唐氏症篩檢(軍眷、員工--紅)")]
            [Description("107")]
            _107,

            /// <summary>
            /// 台北巿孕婦唐氏症篩檢(福保、員工(綠、藍)、國軍聘雇)
            /// </summary>
            [Display(Name = "台北巿孕婦唐氏症篩檢(福保、員工(綠、藍)、國軍聘雇)")]
            [Description("108")]
            _108,

            /// <summary>
            /// 台北巿孕婦唐氏症篩檢(民眾)
            /// </summary>
            [Display(Name = "台北巿孕婦唐氏症篩檢(民眾)")]
            [Description("109")]
            _109,

            /// <summary>
            /// 現役將級眷屬
            /// </summary>
            [Display(Name = "現役將級眷屬")]
            [Description("11")]
            _11,

            /// <summary>
            /// 門診綠色通行證優免
            /// </summary>
            [Display(Name = "門診綠色通行證優免")]
            [Description("110")]
            _110,

            /// <summary>
            /// 孕婦唐氏症篩檢(里民)
            /// </summary>
            [Display(Name = "孕婦唐氏症篩檢(里民)")]
            [Description("112")]
            _112,

            /// <summary>
            /// 孕婦唐氏症篩檢(榮民、備役眷)
            /// </summary>
            [Display(Name = "孕婦唐氏症篩檢(榮民、備役眷)")]
            [Description("113")]
            _113,

            /// <summary>
            /// 內湖區湖興里、寶湖里、石潭里民優免
            /// </summary>
            [Display(Name = "內湖區湖興里、寶湖里、石潭里民優免")]
            [Description("114")]
            _114,

            /// <summary>
            /// 中正區富水里、文盛里、水源里、林興里民優免
            /// </summary>
            [Display(Name = "中正區富水里、文盛里、水源里、林興里民優免")]
            [Description("115")]
            _115,

            /// <summary>
            /// 里民診察費優免
            /// </summary>
            [Display(Name = "里民診察費優免")]
            [Description("116")]
            _116,

            /// <summary>
            /// 孕婦唐氏症篩檢(國軍聘雇)
            /// </summary>
            [Display(Name = "孕婦唐氏症篩檢(國軍聘雇)")]
            [Description("117")]
            _117,

            /// <summary>
            /// 國健局羊膜穿刺補助
            /// </summary>
            [Display(Name = "國健局羊膜穿刺補助")]
            [Description("118")]
            _118,

            /// <summary>
            /// 門診藍色通行證優免
            /// </summary>
            [Display(Name = "門診藍色通行證優免")]
            [Description("119")]
            _119,

            /// <summary>
            /// -10元(福保、國防校友、志工)國健局羊膜穿刺補助
            /// </summary>
            [Display(Name = "-10元(福保、國防校友、志工)國健局羊膜穿刺補助")]
            [Description("11A")]
            _11A,

            /// <summary>
            /// -20元(備役、中研院員工)國健局羊膜穿刺補助
            /// </summary>
            [Display(Name = "-20元(備役、中研院員工)國健局羊膜穿刺補助")]
            [Description("11B")]
            _11B,

            /// <summary>
            /// -50元(里民)國健局羊膜穿刺補助
            /// </summary>
            [Display(Name = "-50元(里民)國健局羊膜穿刺補助")]
            [Description("11C")]
            _11C,

            /// <summary>
            /// 合作學校優免門診掛號費50元(14所)
            /// </summary>
            [Display(Name = "合作學校優免門診掛號費50元(14所)")]
            [Description("11S")]
            _11S,

            /// <summary>
            /// 駐外使節(具退將)
            /// </summary>
            [Display(Name = "駐外使節(具退將)")]
            [Description("12")]
            _12,

            /// <summary>
            /// 外籍人士
            /// </summary>
            [Display(Name = "外籍人士")]
            [Description("121")]
            _121,

            /// <summary>
            /// 外籍勞工
            /// </summary>
            [Display(Name = "外籍勞工")]
            [Description("122")]
            _122,

            /// <summary>
            /// 員工B肝疫苗全額記帳
            /// </summary>
            [Display(Name = "員工B肝疫苗全額記帳")]
            [Description("123")]
            _123,

            /// <summary>
            /// 學生B肝疫苗全額記帳
            /// </summary>
            [Display(Name = "學生B肝疫苗全額記帳")]
            [Description("124")]
            _124,

            /// <summary>
            /// 國健局羊膜穿刺補助(軍眷、本院員工、榮民)
            /// </summary>
            [Display(Name = "國健局羊膜穿刺補助(軍眷、本院員工、榮民)")]
            [Description("125")]
            _125,

            /// <summary>
            /// 居家長照低收入戶優免
            /// </summary>
            [Display(Name = "居家長照低收入戶優免")]
            [Description("126")]
            _126,

            /// <summary>
            /// 居家長照中低收入戶優免
            /// </summary>
            [Display(Name = "居家長照中低收入戶優免")]
            [Description("127")]
            _127,

            /// <summary>
            /// 居家長照一般戶優免
            /// </summary>
            [Display(Name = "居家長照一般戶優免")]
            [Description("128")]
            _128,

            /// <summary>
            /// 員榮醫院國際病人
            /// </summary>
            [Display(Name = "員榮醫院國際病人")]
            [Description("12A")]
            _12A,

            /// <summary>
            /// 自行就醫無健保國際病人
            /// </summary>
            [Display(Name = "自行就醫無健保國際病人")]
            [Description("12B")]
            _12B,

            /// <summary>
            /// 員榮醫院國際病人(第二意見諮詢費)
            /// </summary>
            [Display(Name = "員榮醫院國際病人(第二意見諮詢費)")]
            [Description("12C")]
            _12C,

            /// <summary>
            /// 駐外使節眷屬
            /// </summary>
            [Display(Name = "駐外使節眷屬")]
            [Description("13")]
            _13,

            /// <summary>
            /// 藥癮補助計畫對象
            /// </summary>
            [Display(Name = "藥癮補助計畫對象")]
            [Description("132")]
            _132,

            /// <summary>
            /// 酒癮補助計畫對象
            /// </summary>
            [Display(Name = "酒癮補助計畫對象")]
            [Description("133")]
            _133,

            /// <summary>
            /// 萬華篩檢專案
            /// </summary>
            [Display(Name = "萬華篩檢專案")]
            [Description("135")]
            _135,

            /// <summary>
            /// 外國使節
            /// </summary>
            [Display(Name = "外國使節")]
            [Description("14")]
            _14,

            /// <summary>
            /// 外國使節眷屬
            /// </summary>
            [Display(Name = "外國使節眷屬")]
            [Description("15")]
            _15,

            /// <summary>
            /// 一級上將
            /// </summary>
            [Display(Name = "一級上將")]
            [Description("16")]
            _16,

            /// <summary>
            /// 退將夫人
            /// </summary>
            [Display(Name = "退將夫人")]
            [Description("17")]
            _17,

            /// <summary>
            /// 院內員工(門診優免)
            /// </summary>
            [Display(Name = "院內員工(門診優免)")]
            [Description("18")]
            _18,

            /// <summary>
            /// 員工眷屬門急診掛號費優免
            /// </summary>
            [Display(Name = "員工眷屬門急診掛號費優免")]
            [Description("181")]
            _181,

            /// <summary>
            /// 門診員工員眷義齒治療
            /// </summary>
            [Display(Name = "門診員工員眷義齒治療")]
            [Description("182")]
            _182,

            /// <summary>
            /// 三總之友證門急診掛號費優免
            /// </summary>
            [Display(Name = "三總之友證門急診掛號費優免")]
            [Description("183")]
            _183,

            /// <summary>
            /// 員工減量
            /// </summary>
            [Display(Name = "員工減量")]
            [Description("18D")]
            _18D,

            /// <summary>
            /// 門診橘色通行證優免
            /// </summary>
            [Display(Name = "門診橘色通行證優免")]
            [Description("19A")]
            _19A,

            /// <summary>
            /// 民眾減量
            /// </summary>
            [Display(Name = "民眾減量")]
            [Description("20D")]
            _20D,

            /// <summary>
            /// 門診牙科軍眷費用優免
            /// </summary>
            [Display(Name = "門診牙科軍眷費用優免")]
            [Description("23")]
            _23,

            /// <summary>
            /// 永和區:竹林里、福林里、永福里、河濱里民優免
            /// </summary>
            [Display(Name = "永和區:竹林里、福林里、永福里、河濱里民優免")]
            [Description("234")]
            _234,

            /// <summary>
            /// 門診百歲人瑞
            /// </summary>
            [Display(Name = "門診百歲人瑞")]
            [Description("25")]
            _25,

            /// <summary>
            /// 門診台北市老人健康檢查
            /// </summary>
            [Display(Name = "門診台北市老人健康檢查")]
            [Description("26")]
            _26,

            /// <summary>
            /// 門診研究病房GCRC(W75)
            /// </summary>
            [Display(Name = "門診研究病房GCRC(W75)")]
            [Description("27")]
            _27,

            /// <summary>
            /// 門診民眾營養諮詢(含小兒)
            /// </summary>
            [Display(Name = "門診民眾營養諮詢(含小兒)")]
            [Description("28")]
            _28,

            /// <summary>
            /// 門診軍眷營養諮詢(含小兒)
            /// </summary>
            [Display(Name = "門診軍眷營養諮詢(含小兒)")]
            [Description("29")]
            _29,

            /// <summary>
            /// 軍眷-牙科自費治療
            /// </summary>
            [Display(Name = "軍眷-牙科自費治療")]
            [Description("30")]
            _30,

            /// <summary>
            /// 民眾-牙科自費治療
            /// </summary>
            [Display(Name = "民眾-牙科自費治療")]
            [Description("31")]
            _31,

            /// <summary>
            /// 門診健保產檢加掛婦科
            /// </summary>
            [Display(Name = "門診健保產檢加掛婦科")]
            [Description("32")]
            _32,

            /// <summary>
            /// 門診民眾兒童預防保健
            /// </summary>
            [Display(Name = "門診民眾兒童預防保健")]
            [Description("33")]
            _33,

            /// <summary>
            /// 門診軍眷預防保健(20D)
            /// </summary>
            [Display(Name = "門診軍眷預防保健(20D)")]
            [Description("34")]
            _34,

            /// <summary>
            /// 臺北巿軍眷兒童第二類輪狀病毒疫苗及常規苗(優免2070元、掛號費0元)
            /// </summary>
            [Display(Name = "臺北巿軍眷兒童第二類輪狀病毒疫苗及常規苗(優免2070元、掛號費0元)")]
            [Description("34B")]
            _34B,

            /// <summary>
            /// 臺北巿軍眷兒童第一、三類輪狀病毒疫苗及常規苗(優免1050元、掛號費0元)
            /// </summary>
            [Display(Name = "臺北巿軍眷兒童第一、三類輪狀病毒疫苗及常規苗(優免1050元、掛號費0元)")]
            [Description("34R")]
            _34R,

            /// <summary>
            /// 北巿/新北巿性侵害加害人(採血液檢體)
            /// </summary>
            [Display(Name = "北巿/新北巿性侵害加害人(採血液檢體)")]
            [Description("37")]
            _37,

            /// <summary>
            /// 門診榮民掛號費0元
            /// </summary>
            [Display(Name = "門診榮民掛號費0元")]
            [Description("38")]
            _38,

            /// <summary>
            /// 榮民掛號費0元/診察費0元
            /// </summary>
            [Display(Name = "榮民掛號費0元/診察費0元")]
            [Description("381")]
            _381,

            /// <summary>
            /// 備眷配偶掛號費0元/診察費0元
            /// </summary>
            [Display(Name = "備眷配偶掛號費0元/診察費0元")]
            [Description("382")]
            _382,

            /// <summary>
            /// 備眷父母、子女掛號費10元/診察費0元
            /// </summary>
            [Display(Name = "備眷父母、子女掛號費10元/診察費0元")]
            [Description("383")]
            _383,

            /// <summary>
            /// 門診撫卹令本人掛號費0元
            /// </summary>
            [Display(Name = "門診撫卹令本人掛號費0元")]
            [Description("38C")]
            _38C,

            /// <summary>
            /// 門診後備軍人輔導幹部本人
            /// </summary>
            [Display(Name = "門診後備軍人輔導幹部本人")]
            [Description("38F")]
            _38F,

            /// <summary>
            /// 新進員工體檢
            /// </summary>
            [Display(Name = "新進員工體檢")]
            [Description("39")]
            _39,

            /// <summary>
            /// 將檢病患
            /// </summary>
            [Display(Name = "將檢病患")]
            [Description("40")]
            _40,

            /// <summary>
            /// 汐止防疫門診掛號費優免20元
            /// </summary>
            [Display(Name = "汐止防疫門診掛號費優免20元")]
            [Description("403")]
            _403,

            /// <summary>
            /// 松山防疫門診收費500元
            /// </summary>
            [Display(Name = "松山防疫門診收費500元")]
            [Description("405")]
            _405,

            /// <summary>
            /// 掛號費、部份負擔優免
            /// </summary>
            [Display(Name = "掛號費、部份負擔優免")]
            [Description("41")]
            _41,

            /// <summary>
            /// 北市老人(糖)眼科檢查優免
            /// </summary>
            [Display(Name = "北市老人(糖)眼科檢查優免")]
            [Description("411")]
            _411,

            /// <summary>
            /// 北巿學童高度近視防治計畫補助
            /// </summary>
            [Display(Name = "北巿學童高度近視防治計畫補助")]
            [Description("412")]
            _412,

            /// <summary>
            /// 北市一年級、二年級學童窩溝封填防齲計畫補助
            /// </summary>
            [Display(Name = "北市一年級、二年級學童窩溝封填防齲計畫補助")]
            [Description("413")]
            _413,

            /// <summary>
            /// 北巿二年級學童窩溝封填防齲計畫_掛號費記帳
            /// </summary>
            [Display(Name = "北巿二年級學童窩溝封填防齲計畫_掛號費記帳")]
            [Description("414")]
            _414,

            /// <summary>
            /// 部份負擔優免
            /// </summary>
            [Display(Name = "部份負擔優免")]
            [Description("42")]
            _42,

            /// <summary>
            /// 預防保健及水痘優免
            /// </summary>
            [Display(Name = "預防保健及水痘優免")]
            [Description("43")]
            _43,

            /// <summary>
            /// 軍眷預防保健及水痘優免
            /// </summary>
            [Display(Name = "軍眷預防保健及水痘優免")]
            [Description("44")]
            _44,

            /// <summary>
            /// 北巿民眾兒童水痘優免
            /// </summary>
            [Display(Name = "北巿民眾兒童水痘優免")]
            [Description("45")]
            _45,

            /// <summary>
            /// 軍眷北巿民眾兒童水痘優免
            /// </summary>
            [Display(Name = "軍眷北巿民眾兒童水痘優免")]
            [Description("46")]
            _46,

            /// <summary>
            /// 診察費優免
            /// </summary>
            [Display(Name = "診察費優免")]
            [Description("47")]
            _47,

            /// <summary>
            /// 軍眷、本院眷,1歲以下兒童常規疫苗(掛號費0元、診察費優免)
            /// </summary>
            [Display(Name = "軍眷、本院眷,1歲以下兒童常規疫苗(掛號費0元、診察費優免)")]
            [Description("470")]
            _470,

            /// <summary>
            /// 一般民眾,1歲以下兒童常規疫苗(掛號費100元、診察費優免)
            /// </summary>
            [Display(Name = "一般民眾,1歲以下兒童常規疫苗(掛號費100元、診察費優免)")]
            [Description("471")]
            _471,

            /// <summary>
            /// 備役,1歲以下兒童常規疫苗(掛號費10元、診察費優免)
            /// </summary>
            [Display(Name = "備役,1歲以下兒童常規疫苗(掛號費10元、診察費優免)")]
            [Description("472")]
            _472,

            /// <summary>
            /// 里民,1歲以下兒童常規疫苗(掛號費50元、診察費優免)
            /// </summary>
            [Display(Name = "里民,1歲以下兒童常規疫苗(掛號費50元、診察費優免)")]
            [Description("473")]
            _473,

            /// <summary>
            /// 低收入,1歲以下兒童常規疫苗(掛號費10元，診察費優免)
            /// </summary>
            [Display(Name = "低收入,1歲以下兒童常規疫苗(掛號費10元，診察費優免)")]
            [Description("474")]
            _474,

            /// <summary>
            /// 軍眷、本院眷, 臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費0元)
            /// </summary>
            [Display(Name = "軍眷、本院眷, 臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費0元)")]
            [Description("480")]
            _480,

            /// <summary>
            /// 一般民眾、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費100元)
            /// </summary>
            [Display(Name = "一般民眾、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費100元)")]
            [Description("481")]
            _481,

            /// <summary>
            /// 備役、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費10元)
            /// </summary>
            [Display(Name = "備役、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費10元)")]
            [Description("482")]
            _482,

            /// <summary>
            /// 里民、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費50元)
            /// </summary>
            [Display(Name = "里民、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費50元)")]
            [Description("483")]
            _483,

            /// <summary>
            /// 低收入、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費10元)
            /// </summary>
            [Display(Name = "低收入、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費10元)")]
            [Description("484")]
            _484,

            /// <summary>
            /// 軍眷、本院眷, 臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費0元)
            /// </summary>
            [Display(Name = "軍眷、本院眷, 臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費0元)")]
            [Description("490")]
            _490,

            /// <summary>
            /// 一般民眾、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費100元)
            /// </summary>
            [Display(Name = "一般民眾、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費100元)")]
            [Description("491")]
            _491,

            /// <summary>
            /// 備役、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費10元)
            /// </summary>
            [Display(Name = "備役、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費10元)")]
            [Description("492")]
            _492,

            /// <summary>
            /// 里民、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)
            /// </summary>
            [Display(Name = "里民、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)")]
            [Description("493")]
            _493,

            /// <summary>
            /// 低收入、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費10元)
            /// </summary>
            [Display(Name = "低收入、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費10元)")]
            [Description("494")]
            _494,

            /// <summary>
            /// 門診國軍編制內聘雇人員(軍聘雇)優免
            /// </summary>
            [Display(Name = "門診國軍編制內聘雇人員(軍聘雇)優免")]
            [Description("50")]
            _50,

            /// <summary>
            /// 門診國軍單位內員工(民聘雇)優免
            /// </summary>
            [Display(Name = "門診國軍單位內員工(民聘雇)優免")]
            [Description("50A")]
            _50A,

            /// <summary>
            /// 門診國防部文職人員
            /// </summary>
            [Display(Name = "門診國防部文職人員")]
            [Description("50B")]
            _50B,

            /// <summary>
            /// 門診國防部文職人員（眷屬）
            /// </summary>
            [Display(Name = "門診國防部文職人員（眷屬）")]
            [Description("50C")]
            _50C,

            /// <summary>
            /// 門診國防醫學院碩博士班非軍費研究生優免
            /// </summary>
            [Display(Name = "門診國防醫學院碩博士班非軍費研究生優免")]
            [Description("50D")]
            _50D,

            /// <summary>
            /// 門診持現役軍人眷屬特准證掛號費優免
            /// </summary>
            [Display(Name = "門診持現役軍人眷屬特准證掛號費優免")]
            [Description("50E")]
            _50E,

            /// <summary>
            /// 門診警察局內湖分局員警本人優免
            /// </summary>
            [Display(Name = "門診警察局內湖分局員警本人優免")]
            [Description("50F")]
            _50F,

            /// <summary>
            /// 門診持榮譽證本人掛號費優免
            /// </summary>
            [Display(Name = "門診持榮譽證本人掛號費優免")]
            [Description("50G")]
            _50G,

            /// <summary>
            /// 非在營後備戰士本人-門急診掛號費優免
            /// </summary>
            [Display(Name = "非在營後備戰士本人-門急診掛號費優免")]
            [Description("50H")]
            _50H,

            /// <summary>
            /// 14天召集訓練後一年內之後備軍人-門急診掛號費優免
            /// </summary>
            [Display(Name = "14天召集訓練後一年內之後備軍人-門急診掛號費優免")]
            [Description("50I")]
            _50I,

            /// <summary>
            /// 門診警察局中正二分局員警本人優免
            /// </summary>
            [Display(Name = "門診警察局中正二分局員警本人優免")]
            [Description("51")]
            _51,

            /// <summary>
            /// 門診消防局中正二分局隊員本人優免(古亭泉州忠孝城中華山分隊)
            /// </summary>
            [Display(Name = "門診消防局中正二分局隊員本人優免(古亭泉州忠孝城中華山分隊)")]
            [Description("51A")]
            _51A,

            /// <summary>
            /// 門診消防局內湖分局隊員本人優免(大湖內湖東湖民權分隊）
            /// </summary>
            [Display(Name = "門診消防局內湖分局隊員本人優免(大湖內湖東湖民權分隊")]
            [Description("51B")]
            _51B,

            /// <summary>
            /// 門診北巿替代役中 心職員及替代役男
            /// </summary>
            [Display(Name = "門診北巿替代役中 心職員及替代役男")]
            [Description("51C")]
            _51C,

            /// <summary>
            /// 門診軍眷(居家)優免
            /// </summary>
            [Display(Name = "門診軍眷(居家)優免")]
            [Description("55")]
            _55,

            /// <summary>
            /// 掛號費優免
            /// </summary>
            [Display(Name = "掛號費優免")]
            [Description("56")]
            _56,

            /// <summary>
            /// 新陳代謝科洗牙轉介單-優免100元(掛號費)
            /// </summary>
            [Display(Name = "新陳代謝科洗牙轉介單-優免100元(掛號費)")]
            [Description("561")]
            _561,

            /// <summary>
            /// 婦產科洗牙轉介單-優免100元(掛號費)
            /// </summary>
            [Display(Name = "婦產科洗牙轉介單-優免100元(掛號費)")]
            [Description("562")]
            _562,

            /// <summary>
            /// 社區保健轉診病人掛號費優免
            /// </summary>
            [Display(Name = "社區保健轉診病人掛號費優免")]
            [Description("566")]
            _566,

            /// <summary>
            /// 全額優免
            /// </summary>
            [Display(Name = "全額優免")]
            [Description("57")]
            _57,

            /// <summary>
            /// 全額計帳，暫不付費
            /// </summary>
            [Display(Name = "全額計帳，暫不付費")]
            [Description("577")]
            _577,

            /// <summary>
            /// 北巿計程車體檢優免
            /// </summary>
            [Display(Name = "北巿計程車體檢優免")]
            [Description("58")]
            _58,

            /// <summary>
            /// 原委會核能體檢
            /// </summary>
            [Display(Name = "原委會核能體檢")]
            [Description("59")]
            _59,

            /// <summary>
            /// 健檢優免
            /// </summary>
            [Display(Name = "健檢優免")]
            [Description("62")]
            _62,

            /// <summary>
            /// 替代役男優免
            /// </summary>
            [Display(Name = "替代役男優免")]
            [Description("63")]
            _63,

            /// <summary>
            /// 研發替代男優免
            /// </summary>
            [Display(Name = "研發替代男優免")]
            [Description("633")]
            _633,

            /// <summary>
            /// 門診志工優免
            /// </summary>
            [Display(Name = "門診志工優免")]
            [Description("64")]
            _64,

            /// <summary>
            /// 志工義齒優免
            /// </summary>
            [Display(Name = "志工義齒優免")]
            [Description("641")]
            _641,

            /// <summary>
            /// 法務部體檢
            /// </summary>
            [Display(Name = "法務部體檢")]
            [Description("65")]
            _65,

            /// <summary>
            /// 兵役複檢
            /// </summary>
            [Display(Name = "兵役複檢")]
            [Description("66")]
            _66,

            /// <summary>
            /// 汀州院區兵役複檢
            /// </summary>
            [Display(Name = "汀州院區兵役複檢")]
            [Description("66A")]
            _66A,

            /// <summary>
            /// 新兵驗退
            /// </summary>
            [Display(Name = "新兵驗退")]
            [Description("67")]
            _67,

            /// <summary>
            /// 後備軍人停役
            /// </summary>
            [Display(Name = "後備軍人停役")]
            [Description("68")]
            _68,

            /// <summary>
            /// 軍人優免
            /// </summary>
            [Display(Name = "軍人優免")]
            [Description("69")]
            _69,

            /// <summary>
            /// 癌症專用優免
            /// </summary>
            [Display(Name = "癌症專用優免")]
            [Description("70")]
            _70,

            /// <summary>
            /// 軍人-牙科自費治療或營養諮詢(掛號費+診察費優免)
            /// </summary>
            [Display(Name = "軍人-牙科自費治療或營養諮詢(掛號費+診察費優免)")]
            [Description("700")]
            _700,

            /// <summary>
            /// 肺癌學會計劃-低劑量電腦斷層肺癌篩檢記帳
            /// </summary>
            [Display(Name = "肺癌學會計劃-低劑量電腦斷層肺癌篩檢記帳")]
            [Description("701")]
            _701,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(軍眷/本院員工/榮民不收費)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(軍眷/本院員工/榮民不收費)")]
            [Description("702")]
            _702,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(福保/國軍聘雇收10元)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(福保/國軍聘雇收10元)")]
            [Description("703")]
            _703,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(備眷收20元)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(備眷收20元)")]
            [Description("704")]
            _704,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(里民收50元)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(里民收50元)")]
            [Description("705")]
            _705,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(員工眷屬、榮譽證→收部份負擔費用)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(員工眷屬、榮譽證→收部份負擔費用)")]
            [Description("706")]
            _706,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(檢查結果無異常個案部份負擔費用不收費)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(檢查結果無異常個案部份負擔費用不收費)")]
            [Description("707")]
            _707,

            /// <summary>
            /// HER2-FISH檢測贊助計劃記帳
            /// </summary>
            [Display(Name = "HER2-FISH檢測贊助計劃記帳")]
            [Description("708")]
            _708,

            /// <summary>
            /// 國健署肺癌早期偵測計畫-計帳優免
            /// </summary>
            [Display(Name = "國健署肺癌早期偵測計畫-計帳優免")]
            [Description("709")]
            _709,

            /// <summary>
            /// 掛號費、診察費優免
            /// </summary>
            [Display(Name = "掛號費、診察費優免")]
            [Description("71")]
            _71,

            /// <summary>
            /// 幼稚園健檢優免
            /// </summary>
            [Display(Name = "幼稚園健檢優免")]
            [Description("72")]
            _72,

            /// <summary>
            /// 護理之家病患，掛號費優免
            /// </summary>
            [Display(Name = "護理之家病患，掛號費優免")]
            [Description("73")]
            _73,

            /// <summary>
            /// 軍人藥品、衛材自費、其他費用優免
            /// </summary>
            [Display(Name = "軍人藥品、衛材自費、其他費用優免")]
            [Description("74")]
            _74,

            /// <summary>
            /// 撫卹令（本人）掛號費0元
            /// </summary>
            [Display(Name = "撫卹令（本人）掛號費0元")]
            [Description("74A")]
            _74A,

            /// <summary>
            /// 軍事院校非軍費生優免
            /// </summary>
            [Display(Name = "軍事院校非軍費生優免")]
            [Description("74B")]
            _74B,

            /// <summary>
            /// 軍事訓練役
            /// </summary>
            [Display(Name = "軍事訓練役")]
            [Description("74C")]
            _74C,

            /// <summary>
            /// 軍人減量
            /// </summary>
            [Display(Name = "軍人減量")]
            [Description("74D")]
            _74D,

            /// <summary>
            /// 在營後備戰士本人
            /// </summary>
            [Display(Name = "在營後備戰士本人")]
            [Description("74E")]
            _74E,

            /// <summary>
            /// 現役軍人-角膜屈光雷射手術費用計帳
            /// </summary>
            [Display(Name = "現役軍人-角膜屈光雷射手術費用計帳")]
            [Description("74F")]
            _74F,

            /// <summary>
            /// 牙科軍人專案(限112.10.31前使用)
            /// </summary>
            [Display(Name = "牙科軍人專案(限112.10.31前使用)")]
            [Description("74G")]
            _74G,

            /// <summary>
            /// 設籍北巿流感-一般民眾(掛100元/診優100元)
            /// </summary>
            [Display(Name = "設籍北巿流感-一般民眾(掛100元/診優100元)")]
            [Description("75")]
            _75,

            /// <summary>
            /// 設籍北巿流感-員眷/榮民(掛0元/診優100元)
            /// </summary>
            [Display(Name = "設籍北巿流感-員眷/榮民(掛0元/診優100元)")]
            [Description("751")]
            _751,

            /// <summary>
            /// 設籍北巿流感-福保/國軍聘雇/警察/校友(掛10元/診優100元)
            /// </summary>
            [Display(Name = "設籍北巿流感-福保/國軍聘雇/警察/校友(掛10元/診優100元)")]
            [Description("752")]
            _752,

            /// <summary>
            /// 設籍北巿流感-備眷/中研院/台科大(掛20元/診優100元)
            /// </summary>
            [Display(Name = "設籍北巿流感-備眷/中研院/台科大(掛20元/診優100元)")]
            [Description("753")]
            _753,

            /// <summary>
            /// 設籍北巿流感-里民(掛50元/診優100元)
            /// </summary>
            [Display(Name = "設籍北巿流感-里民(掛50元/診優100元)")]
            [Description("754")]
            _754,

            /// <summary>
            /// 設籍北巿流感-軍人/軍眷(掛0元/診察費0元)
            /// </summary>
            [Display(Name = "設籍北巿流感-軍人/軍眷(掛0元/診察費0元)")]
            [Description("755")]
            _755,

            /// <summary>
            /// 卓越軍眷
            /// </summary>
            [Display(Name = "卓越軍眷")]
            [Description("77")]
            _77,

            /// <summary>
            /// 卓越員工
            /// </summary>
            [Display(Name = "卓越員工")]
            [Description("78")]
            _78,

            /// <summary>
            /// 卓越榮字號榮民
            /// </summary>
            [Display(Name = "卓越榮字號榮民")]
            [Description("80")]
            _80,

            /// <summary>
            /// 國軍官兵因公傷退伍、停役就醫
            /// </summary>
            [Display(Name = "國軍官兵因公傷退伍、停役就醫")]
            [Description("81")]
            _81,

            /// <summary>
            /// 施打疫苗只收藥劑費
            /// </summary>
            [Display(Name = "施打疫苗只收藥劑費")]
            [Description("82")]
            _82,

            /// <summary>
            /// 新移民配偶產前檢查
            /// </summary>
            [Display(Name = "新移民配偶產前檢查")]
            [Description("83")]
            _83,

            /// <summary>
            /// 新移民配偶產前檢查--優免特定健保費
            /// </summary>
            [Display(Name = "新移民配偶產前檢查--優免特定健保費")]
            [Description("833")]
            _833,

            /// <summary>
            /// 北巿新移民配偶產前檢查加唐氏症篩檢
            /// </summary>
            [Display(Name = "北巿新移民配偶產前檢查加唐氏症篩檢")]
            [Description("835")]
            _835,

            /// <summary>
            /// 新移民配偶避孕器裝置
            /// </summary>
            [Display(Name = "新移民配偶避孕器裝置")]
            [Description("84")]
            _84,

            /// <summary>
            /// 新移民配偶輸精管結紮
            /// </summary>
            [Display(Name = "新移民配偶輸精管結紮")]
            [Description("85")]
            _85,

            /// <summary>
            /// 門診國防校友優免掛號費
            /// </summary>
            [Display(Name = "門診國防校友優免掛號費")]
            [Description("86")]
            _86,

            /// <summary>
            /// 門診中研院員工優免掛號費
            /// </summary>
            [Display(Name = "門診中研院員工優免掛號費")]
            [Description("86B")]
            _86B,

            /// <summary>
            /// 門診台科大教職員
            /// </summary>
            [Display(Name = "門診台科大教職員")]
            [Description("86F")]
            _86F,

            /// <summary>
            /// 門診海洋大學教職員掛號費優免80元
            /// </summary>
            [Display(Name = "門診海洋大學教職員掛號費優免80元")]
            [Description("86H")]
            _86H,

            /// <summary>
            /// 本國籍無健保愛滋病(免檢查費及藥費)
            /// </summary>
            [Display(Name = "本國籍無健保愛滋病(免檢查費及藥費)")]
            [Description("87")]
            _87,

            /// <summary>
            /// 取消八仙樂園案件全額記帳
            /// </summary>
            [Display(Name = "取消八仙樂園案件全額記帳")]
            [Description("877")]
            _877,

            /// <summary>
            /// 他院代檢記帳
            /// </summary>
            [Display(Name = "他院代檢記帳")]
            [Description("88")]
            _88,

            /// <summary>
            /// 自費民眾身份藥品費用優免
            /// </summary>
            [Display(Name = "自費民眾身份藥品費用優免")]
            [Description("89")]
            _89,

            /// <summary>
            /// 自費軍眷身份藥品費用優免
            /// </summary>
            [Display(Name = "自費軍眷身份藥品費用優免")]
            [Description("90")]
            _90,

            /// <summary>
            /// 感染肝炎科優免
            /// </summary>
            [Display(Name = "感染肝炎科優免")]
            [Description("91")]
            _91,

            /// <summary>
            /// 公費PrEP計畫HIV檢驗費用減免
            /// </summary>
            [Display(Name = "公費PrEP計畫HIV檢驗費用減免")]
            [Description("91A")]
            _91A,

            /// <summary>
            /// 公費PrEP計畫Truvada20顆費用減免
            /// </summary>
            [Display(Name = "公費PrEP計畫Truvada20顆費用減免")]
            [Description("91B")]
            _91B,

            /// <summary>
            /// 公費PrEP計畫Truvada30顆費用減免
            /// </summary>
            [Display(Name = "公費PrEP計畫Truvada30顆費用減免")]
            [Description("91C")]
            _91C,

            /// <summary>
            /// 公費PrEP計畫(優免7910元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免7910元)")]
            [Description("91D")]
            _91D,

            /// <summary>
            /// 公費PrEP計畫(優免11705元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免11705元)")]
            [Description("91E")]
            _91E,

            /// <summary>
            /// 公費PrEP計畫(優免1436元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免1436元)")]
            [Description("91F")]
            _91F,

            /// <summary>
            /// 公費PrEP計畫(優免7996元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免7996元)")]
            [Description("91G")]
            _91G,

            /// <summary>
            /// 公費PrEP計畫(優免726元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免726元)")]
            [Description("91H")]
            _91H,

            /// <summary>
            /// 公費PrEP計畫(優免8316元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免8316元)")]
            [Description("91I")]
            _91I,

            /// <summary>
            /// 公費PrEP計畫(優免8566元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免8566元)")]
            [Description("91J")]
            _91J,

            /// <summary>
            /// 公費PrEP計畫(優免12111元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免12111元)")]
            [Description("91K")]
            _91K,

            /// <summary>
            /// 公費PrEP計畫(優免9026元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免9026元)")]
            [Description("91L")]
            _91L,

            /// <summary>
            /// 公費PrEP計畫(優免1536元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免1536元)")]
            [Description("91M")]
            _91M,

            /// <summary>
            /// 公費PrEP計畫(優免11791元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免11791元)")]
            [Description("91N")]
            _91N,

            /// <summary>
            /// 公費PrEP計畫(優免12361元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免12361元)")]
            [Description("91O")]
            _91O,

            /// <summary>
            /// 公費PrEP計畫(優免12921元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免12921元)")]
            [Description("91P")]
            _91P,

            /// <summary>
            /// 門診設籍北巿第3胎以上兒童證明卡
            /// </summary>
            [Display(Name = "門診設籍北巿第3胎以上兒童證明卡")]
            [Description("92")]
            _92,

            /// <summary>
            /// 門診北市第三胎以上兒童暨社區轉診優免
            /// </summary>
            [Display(Name = "門診北市第三胎以上兒童暨社區轉診優免")]
            [Description("92A")]
            _92A,

            /// <summary>
            /// 臺北巿一般兒童兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)
            /// </summary>
            [Display(Name = "臺北巿一般兒童兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)")]
            [Description("92B")]
            _92B,

            /// <summary>
            /// 臺北巿一般兒童第三類輪狀病毒疫苗及常規苗(優免1050元、掛號費50元)
            /// </summary>
            [Display(Name = "臺北巿一般兒童第三類輪狀病毒疫苗及常規苗(優免1050元、掛號費50元)")]
            [Description("92R")]
            _92R,

            /// <summary>
            /// 門診備役軍人眷屬優免(配偶)
            /// </summary>
            [Display(Name = "門診備役軍人眷屬優免(配偶)")]
            [Description("94")]
            _94,

            /// <summary>
            /// 門診備役軍人眷屬優免(父母、子女)
            /// </summary>
            [Display(Name = "門診備役軍人眷屬優免(父母、子女)")]
            [Description("94A")]
            _94A,

            /// <summary>
            /// 急診備役軍人眷屬優免(父母、子女)
            /// </summary>
            [Display(Name = "急診備役軍人眷屬優免(父母、子女)")]
            [Description("95A")]
            _95A,

            /// <summary>
            /// 門診新北巿兒童醫療補助-低收入戶
            /// </summary>
            [Display(Name = "門診新北巿兒童醫療補助-低收入戶")]
            [Description("96A")]
            _96A,

            /// <summary>
            /// 門診新北巿兒童醫療補助-重大傷病
            /// </summary>
            [Display(Name = "門診新北巿兒童醫療補助-重大傷病")]
            [Description("96B")]
            _96B,

            /// <summary>
            /// 門診新北巿兒童醫療補助-罕見病病
            /// </summary>
            [Display(Name = "門診新北巿兒童醫療補助-罕見病病")]
            [Description("96C")]
            _96C,

            /// <summary>
            /// 門診新北巿兒童醫療補助-中低收入戶
            /// </summary>
            [Display(Name = "門診新北巿兒童醫療補助-中低收入戶")]
            [Description("96F")]
            _96F,

            /// <summary>
            /// 門診新北巿老人醫療補助-低收入戶
            /// </summary>
            [Display(Name = "門診新北巿老人醫療補助-低收入戶")]
            [Description("96G")]
            _96G,

            /// <summary>
            /// 門診新北巿55-65歲原住民醫療補助-低收入戶
            /// </summary>
            [Display(Name = "門診新北巿55-65歲原住民醫療補助-低收入戶")]
            [Description("96H")]
            _96H,

            /// <summary>
            /// 門診新北巿新希望關懷醫療補助
            /// </summary>
            [Display(Name = "門診新北巿新希望關懷醫療補助")]
            [Description("98")]
            _98,

            /// <summary>
            /// 新店監獄病人看診記帳
            /// </summary>
            [Display(Name = "新店監獄病人看診記帳")]
            [Description("99")]
            _99,

            /// <summary>
            /// 掛號費0元急診器捐費用五折優待
            /// </summary>
            [Display(Name = "掛號費0元急診器捐費用五折優待")]
            [Description("992")]
            _992,

            /// <summary>
            /// 臺北巿、一般民眾、兒補第二類輪狀病毒疫苗((需收診療費、優免2070元、掛號費100元)
            /// </summary>
            [Display(Name = "臺北巿、一般民眾、兒補第二類輪狀病毒疫苗((需收診療費、優免2070元、掛號費100元)")]
            [Description("B")]
            _B,

            /// <summary>
            /// 院部核定醫療費用八折(05、12)
            /// </summary>
            [Display(Name = "院部核定醫療費用八折(05、12)")]
            [Description("C00")]
            _C00,

            /// <summary>
            /// 院部核定醫療費用八折(05、12)及九折(24)
            /// </summary>
            [Display(Name = "院部核定醫療費用八折(05、12)及九折(24)")]
            [Description("C01")]
            _C01,

            /// <summary>
            /// 院部核定醫療費用七五折(04、05、12、13)及優免(21、25)
            /// </summary>
            [Display(Name = "院部核定醫療費用七五折(04、05、12、13)及優免(21、25)")]
            [Description("C02")]
            _C02,

            /// <summary>
            /// 院部核定醫療費用七折(05、12)及優免(21、25)
            /// </summary>
            [Display(Name = "院部核定醫療費用七折(05、12)及優免(21、25)")]
            [Description("C03")]
            _C03,

            /// <summary>
            /// 院部核定醫療費用五折(12)及優免(01、07、21)
            /// </summary>
            [Display(Name = "院部核定醫療費用五折(12)及優免(01、07、21)")]
            [Description("C04")]
            _C04,

            /// <summary>
            /// 院部核定醫療費用折扣29880(12)
            /// </summary>
            [Display(Name = "院部核定醫療費用折扣29880(12)")]
            [Description("C05")]
            _C05,

            /// <summary>
            /// 院部核定醫療費用折扣31078(12)
            /// </summary>
            [Display(Name = "院部核定醫療費用折扣31078(12)")]
            [Description("C06")]
            _C06,

            /// <summary>
            /// 院部核定醫療費用折扣27686(12)
            /// </summary>
            [Display(Name = "院部核定醫療費用折扣27686(12)")]
            [Description("C07")]
            _C07,

            /// <summary>
            /// 院部核定醫療費用九折(07、12)
            /// </summary>
            [Display(Name = "院部核定醫療費用九折(07、12)")]
            [Description("C09")]
            _C09,

            /// <summary>
            /// 普通取件5000元－自費篩檢COVID19
            /// </summary>
            [Display(Name = "普通取件5000元－自費篩檢COVID19")]
            [Description("C10")]
            _C10,

            /// <summary>
            /// 防疫政策4500元－自費篩檢COVID19
            /// </summary>
            [Display(Name = "防疫政策4500元－自費篩檢COVID19")]
            [Description("C11")]
            _C11,

            /// <summary>
            /// 防疫政策3500元－自費篩檢COVID19
            /// </summary>
            [Display(Name = "防疫政策3500元－自費篩檢COVID19")]
            [Description("C12")]
            _C12,

            /// <summary>
            /// 自費篩檢COVID19掛號費及診察費0元
            /// </summary>
            [Display(Name = "自費篩檢COVID19掛號費及診察費0元")]
            [Description("C19")]
            _C19,

            /// <summary>
            /// 團體10人自費篩檢COVID19優惠方案
            /// </summary>
            [Display(Name = "團體10人自費篩檢COVID19優惠方案")]
            [Description("C20")]
            _C20,

            /// <summary>
            /// 團體20人自費篩檢COVID19優惠方案
            /// </summary>
            [Display(Name = "團體20人自費篩檢COVID19優惠方案")]
            [Description("C21")]
            _C21,

            /// <summary>
            /// COVID19因公專案軍人優免
            /// </summary>
            [Display(Name = "COVID19因公專案軍人優免")]
            [Description("C22")]
            _C22,

            /// <summary>
            /// COVID19因公專案軍、民聘雇人員優免
            /// </summary>
            [Display(Name = "COVID19因公專案軍、民聘雇人員優免")]
            [Description("C23")]
            _C23,

            /// <summary>
            /// COVID19因公專案文職人員優免
            /// </summary>
            [Display(Name = "COVID19因公專案文職人員優免")]
            [Description("C24")]
            _C24,

            /// <summary>
            /// COVID19國外受訓學生全額優免
            /// </summary>
            [Display(Name = "COVID19國外受訓學生全額優免")]
            [Description("C25")]
            _C25,

            /// <summary>
            /// COVID19國內受訓學生優免3500元
            /// </summary>
            [Display(Name = "COVID19國內受訓學生優免3500元")]
            [Description("C26")]
            _C26,

            /// <summary>
            /// 預劃門診住院(含手術)之病人，入院前採檢
            /// </summary>
            [Display(Name = "預劃門診住院(含手術)之病人，入院前採檢")]
            [Description("C27")]
            _C27,

            /// <summary>
            /// 門診收住院病人之陪病者(第1位公費)
            /// </summary>
            [Display(Name = "門診收住院病人之陪病者(第1位公費)")]
            [Description("C28")]
            _C28,

            /// <summary>
            /// 急診住院病人陪病者(第1位公費)
            /// </summary>
            [Display(Name = "急診住院病人陪病者(第1位公費)")]
            [Description("C29")]
            _C29,

            /// <summary>
            /// 員工專案-列管員工採檢
            /// </summary>
            [Display(Name = "員工專案-列管員工採檢")]
            [Description("C30")]
            _C30,

            /// <summary>
            /// 員工專案-高風險單位加強採檢
            /// </summary>
            [Display(Name = "員工專案-高風險單位加強採檢")]
            [Description("C31")]
            _C31,

            /// <summary>
            /// 門診透析病人公費採檢
            /// </summary>
            [Display(Name = "門診透析病人公費採檢")]
            [Description("C32")]
            _C32,

            /// <summary>
            /// 企業快篩公費採檢
            /// </summary>
            [Display(Name = "企業快篩公費採檢")]
            [Description("C33")]
            _C33,

            /// <summary>
            /// 非急診之居家隔離/檢疫民眾採檢
            /// </summary>
            [Display(Name = "非急診之居家隔離/檢疫民眾採檢")]
            [Description("C34")]
            _C34,

            /// <summary>
            /// 新進外包廠商員工(自費優免)，收1000元
            /// </summary>
            [Display(Name = "新進外包廠商員工(自費優免)，收1000元")]
            [Description("C35")]
            _C35,

            /// <summary>
            /// 協助臨床作業廠商(自費優免)，收3150元
            /// </summary>
            [Display(Name = "協助臨床作業廠商(自費優免)，收3150元")]
            [Description("C36")]
            _C36,

            /// <summary>
            /// 團體10人自費篩檢，收3300元
            /// </summary>
            [Display(Name = "團體10人自費篩檢，收3300元")]
            [Description("C37")]
            _C37,

            /// <summary>
            /// 新進外包廠商員工(自費優免)，收1000元
            /// </summary>
            [Display(Name = "新進外包廠商員工(自費優免)，收1000元")]
            [Description("C38")]
            _C38,

            /// <summary>
            /// 協助臨床作業廠商(自費優免)，收3150元
            /// </summary>
            [Display(Name = "協助臨床作業廠商(自費優免)，收3150元")]
            [Description("C39")]
            _C39,

            /// <summary>
            /// 高社區傳播風險地區人員採檢(長照機構工作人員)
            /// </summary>
            [Display(Name = "高社區傳播風險地區人員採檢(長照機構工作人員)")]
            [Description("C40")]
            _C40,

            /// <summary>
            /// 陪病者每7日定期篩檢
            /// </summary>
            [Display(Name = "陪病者每7日定期篩檢")]
            [Description("C41")]
            _C41,

            /// <summary>
            /// 國軍入營前公費採檢
            /// </summary>
            [Display(Name = "國軍入營前公費採檢")]
            [Description("C42")]
            _C42,

            /// <summary>
            /// 探病者完成疫苗基礎劑接種14天(含)以上者公費篩檢
            /// </summary>
            [Display(Name = "探病者完成疫苗基礎劑接種14天(含)以上者公費篩檢")]
            [Description("C43")]
            _C43,

            /// <summary>
            /// 藥物研究
            /// </summary>
            [Display(Name = "藥物研究")]
            [Description("C44")]
            _C44,

            /// <summary>
            /// 移民署
            /// </summary>
            [Display(Name = "移民署")]
            [Description("P0")]
            _P0,

            /// <summary>
            /// 門診警消海巡義齒+營養諮詢(掛號費+診察費優免)
            /// </summary>
            [Display(Name = "門診警消海巡義齒+營養諮詢(掛號費+診察費優免)")]
            [Description("P00")]
            _P00,

            /// <summary>
            /// 警察
            /// </summary>
            [Display(Name = "警察")]
            [Description("P4")]
            _P4,

            /// <summary>
            /// 警察中央警察大學
            /// </summary>
            [Display(Name = "警察中央警察大學")]
            [Description("P5")]
            _P5,

            /// <summary>
            /// 消防署
            /// </summary>
            [Display(Name = "消防署")]
            [Description("P6")]
            _P6,

            /// <summary>
            /// 海巡署
            /// </summary>
            [Display(Name = "海巡署")]
            [Description("P7")]
            _P7,

            /// <summary>
            /// 空勤總隊
            /// </summary>
            [Display(Name = "空勤總隊")]
            [Description("P8")]
            _P8,

            /// <summary>
            /// 聘雇飛行教官
            /// </summary>
            [Display(Name = "聘雇飛行教官")]
            [Description("P9")]
            _P9,

            /// <summary>
            /// 臺北巿、一般民眾兒補第一、三類輪狀病毒疫苗((需收診療費、優免1050元、掛號費100元)
            /// </summary>
            [Display(Name = "臺北巿、一般民眾兒補第一、三類輪狀病毒疫苗((需收診療費、優免1050元、掛號費100元)")]
            [Description("R")]
            _R,

            /// <summary>
            /// 111/11/1急診軍人還款使用
            /// </summary>
            [Display(Name = "111/11/1急診軍人還款使用")]
            [Description("Z74")]
            _Z74,

        }

        /// <summary>
        /// 就醫類別.CODE_SRC.DELFA05
        /// 取Description當Value
        /// </summary>
        public enum TreatItem
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("-1")]
            None,

            /// <summary>
            /// 門診指定就醫病人 00
            /// </summary>
            [Display(Name = "門診指定就醫病人")]
            [Description("00")]
            CLinicAppointmentPatient,

            /// <summary>
            /// 西醫門診 01
            /// </summary>
            [Display(Name = "西醫門診")]
            [Description("01")]
            WesternMedicineClinic,

            /// <summary>
            /// 牙醫門診 02
            /// </summary>
            [Display(Name = "牙醫門診")]
            [Description("02")]
            DentistClinic,

            /// <summary>
            /// 中醫門診 03
            /// </summary>
            [Display(Name = "中醫門診")]
            [Description("03")]
            ChineseMedicineClinic,

            /// <summary>
            /// 急診 04
            /// </summary>
            [Display(Name = "急診")]
            [Description("04")]
            EmergencyRoom,

            /// <summary>
            /// 住院 05
            /// </summary>
            [Display(Name = "住院")]
            [Description("05")]
            BeHospitalized,

            /// <summary>
            /// 門診轉診就醫 06
            /// </summary>
            [Display(Name = "門診轉診就醫")]
            [Description("06")]
            OPDReferral,

            /// <summary>
            /// 門診手術後之回診 07
            /// </summary>
            [Display(Name = "門診手術後之回診")]
            [Description("07")]
            FollowUpAfterOPDSurgery,

            /// <summary>
            /// 住院患者出院之回診 08
            /// </summary>
            [Display(Name = "住院患者出院之回診")]
            [Description("08")]
            InpatientFollowUpAfterDischarge,

            /// <summary>
            /// 透析總額門診 09
            /// </summary>
            [Display(Name = "透析總額門診")]
            [Description("09")]
            TotalDialysisClinic,

            /// <summary>
            /// 同一療程(六次內) AA
            /// </summary>
            [Display(Name = "同一療程(六次內)")]
            [Description("AA")]
            SameTreatmentWithinSixTimes,

            /// <summary>
            /// 同一療程(一個月內) AB
            /// </summary>
            [Display(Name = "同一療程(一個月內)")]
            [Description("AB")]
            SameTreatmentWithinOneMonth,

            /// <summary>
            /// 預防保健 AC
            /// </summary>
            [Display(Name = "預防保健")]
            [Description("AC")]
            PreventiveHealthCare,

            /// <summary>
            /// 職業傷害或職業病 AD
            /// </summary>
            [Display(Name = "職業傷害或職業病")]
            [Description("AD")]
            OccupationalInjuryOrDisease,

            /// <summary>
            /// 慢性病連續處方箋領藥 AE
            /// </summary>
            [Display(Name = "慢性病連續處方箋領藥")]
            [Description("AE")]
            ContinuousPrescriptionForChronicDisease,

            /// <summary>
            /// 藥局調劑 AF
            /// </summary>
            [Display(Name = "藥局調劑")]
            [Description("AF")]
            PharmacyRegulation,

            /// <summary>
            /// 排程檢查 AG
            /// </summary>
            [Display(Name = "排程檢查")]
            [Description("AG")]
            ScheduledCheck,

            /// <summary>
            /// 居家照護(第二次以後) AH
            /// </summary>
            [Display(Name = "居家照護(第二次以後)")]
            [Description("AH")]
            HomeCareAfterSecondTime,

            /// <summary>
            /// 同日同醫師看診(第二次以後) AI
            /// </summary>
            [Display(Name = "同日同醫師看診(第二次以後)")]
            [Description("AI")]
            SameDaysSameDoctorAfterSecondTime,

            /// <summary>
            /// 透析門診療程第二次(含) AJ
            /// </summary>
            [Display(Name = "透析門診療程第二次(含)")]
            [Description("AJ")]
            DialysisClinicAfterSecondTime,

            /// <summary>
            /// 急診當次轉住院之入院 BA
            /// </summary>
            [Display(Name = "急診當次轉住院之入院")]
            [Description("BA")]
            ERAdmissionInTheCurrent,

            /// <summary>
            /// 出院 BB
            /// </summary>
            [Display(Name = "出院")]
            [Description("BB")]
            Discharged,

            /// <summary>
            /// 急診中,住院中執行項目 BC
            /// </summary>
            [Display(Name = "急診中,住院中執行項目")]
            [Description("BC")]
            ExecuteProjectInERAndHospital,

            /// <summary>
            /// 急診第二日以後 BD
            /// </summary>
            [Display(Name = "急診第二日以後")]
            [Description("BD")]
            ERAfterSecondDay,

            /// <summary>
            /// 職業傷害或職業病之入院 BE
            /// </summary>
            [Display(Name = "職業傷害或職業病之入院")]
            [Description("BE")]
            AdmissionToHospitalForOccupationalInjuryOrDisease,

            /// <summary>
            /// 繼續住院依規定分段結清者,切帳申報 BF
            /// </summary>
            [Display(Name = "繼續住院依規定分段結清者,切帳申報")]
            [Description("BF")]
            ContinueToBeHospitalized_AccountWillBeCutOff,

            /// <summary>
            /// 門診當次轉住院之入院 BG
            /// </summary>
            [Display(Name = "門診當次轉住院之入院")]
            [Description("BG")]
            OPDAdmissionInTheCurrent,
            /// <summary>
            /// 其他(不扣卡) CA
            /// </summary>
            [Display(Name = "其他(不扣卡)")]
            [Description("CA")]
            Others_NotDeducted,

            /// <summary>
            /// 門診轉出 DA
            /// </summary>
            [Display(Name = "門診轉出")]
            [Description("DA")]
            OPDTransfer,

            /// <summary>
            /// 門診手術需回診 DB
            /// </summary>
            [Display(Name = "門診手術需回診")]
            [Description("DB")]
            OPDSurgeryRequiresReturnVisit,

            /// <summary>
            /// 出院患者需回診 DC
            /// </summary>
            [Display(Name = "出院患者需回診")]
            [Description("DC")]
            DischargedPatientsComeBack,
        }
        /// <summary>
        /// 身分別-案件類別
        /// </summary>
        public enum CaseType
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("")]
            None,
            /// <summary>
            /// 西醫一般案件
            /// </summary>
            [Display(Name = "西醫一般案件")]
            [Description("01")]
            _01,

            /// <summary>
            /// 西醫門診手術
            /// </summary>
            [Display(Name = "西醫門診手術")]
            [Description("03")]
            _03,

            /// <summary>
            /// 西醫慢性病
            /// </summary>
            [Display(Name = "西醫慢性病")]
            [Description("04")]
            _04,

            /// <summary>
            /// 洗腎
            /// </summary>
            [Display(Name = "洗腎")]
            [Description("05")]
            _05,

            /// <summary>
            /// 結核病
            /// </summary>
            [Display(Name = "結核病")]
            [Description("06")]
            _06,

            /// <summary>
            /// 遠距醫療
            /// </summary>
            [Display(Name = "遠距醫療")]
            [Description("07")]
            _07,

            /// <summary>
            /// 慢性病連續處方調劑
            /// </summary>
            [Display(Name = "慢性病連續處方調劑")]
            [Description("08")]
            _08,

            /// <summary>
            /// 西醫其他專案
            /// </summary>
            [Display(Name = "西醫其他專案")]
            [Description("09")]
            _09,

            /// <summary>
            /// 牙醫一般案件
            /// </summary>
            [Display(Name = "牙醫一般案件")]
            [Description("11")]
            _11,

            /// <summary>
            /// 牙醫門診手術
            /// </summary>
            [Display(Name = "牙醫門診手術")]
            [Description("13")]
            _13,

            /// <summary>
            /// 特定身心障礙者牙醫醫療服務
            /// </summary>
            [Display(Name = "特定身心障礙者牙醫醫療服務")]
            [Description("16")]
            _16,

            /// <summary>
            /// 牙醫其他專案
            /// </summary>
            [Display(Name = "牙醫其他專案")]
            [Description("19")]
            _19,

            /// <summary>
            /// 中醫其他專案
            /// </summary>
            [Display(Name = "中醫其他專案")]
            [Description("22")]
            _22,

            /// <summary>
            /// 中醫慢性病
            /// </summary>
            [Display(Name = "中醫慢性病")]
            [Description("24")]
            _24,

            /// <summary>
            /// 中醫針灸、傷科及脫臼整復
            /// </summary>
            [Display(Name = "中醫針灸、傷科及脫臼整復")]
            [Description("29")]
            _29,

            /// <summary>
            /// 居家照護
            /// </summary>
            [Display(Name = "居家照護")]
            [Description("A1")]
            _A1,

            /// <summary>
            /// 精神疾病社區復健
            /// </summary>
            [Display(Name = "精神疾病社區復健")]
            [Description("A2")]
            _A2,

            /// <summary>
            /// 預防保健
            /// </summary>
            [Display(Name = "預防保健")]
            [Description("A3")]
            _A3,

            /// <summary>
            /// 安寧照護
            /// </summary>
            [Display(Name = "安寧照護")]
            [Description("A5")]
            _A5,

            /// <summary>
            /// 護理之家
            /// </summary>
            [Display(Name = "護理之家")]
            [Description("A6")]
            _A6,

            /// <summary>
            /// 安養養護機構院民
            /// </summary>
            [Display(Name = "安養養護機構院民")]
            [Description("A7")]
            _A7,

            /// <summary>
            /// 代辦性病患者全面篩檢愛滋病毒計畫
            /// </summary>
            [Display(Name = "代辦性病患者全面篩檢愛滋病毒計畫")]
            [Description("B1")]
            _B1,

            /// <summary>
            /// 職業災害
            /// </summary>
            [Display(Name = "職業災害")]
            [Description("B6")]
            _B6,

            /// <summary>
            /// 戒菸門診
            /// </summary>
            [Display(Name = "戒菸門診")]
            [Description("B7")]
            _B7,

            /// <summary>
            /// 孕婦篩檢愛滋計劃
            /// </summary>
            [Display(Name = "孕婦篩檢愛滋計劃")]
            [Description("B9")]
            _B9,

            /// <summary>
            /// 愛滋防治替代治療計劃
            /// </summary>
            [Display(Name = "愛滋防治替代治療計劃")]
            [Description("BA")]
            _BA,

            /// <summary>
            /// 論病例計酬
            /// </summary>
            [Display(Name = "論病例計酬")]
            [Description("C1")]
            _C1,

            /// <summary>
            /// 結核病含無健保、接觸者及潛伏結核
            /// </summary>
            [Display(Name = "結核病含無健保、接觸者及潛伏結核")]
            [Description("C4")]
            _C4,

            /// <summary>
            /// 嚴重特殊傳染性肺炎通報且隔離案件
            /// </summary>
            [Display(Name = "嚴重特殊傳染性肺炎通報且隔離案件")]
            [Description("C5")]
            _C5,

            /// <summary>
            /// 愛滋病
            /// </summary>
            [Display(Name = "愛滋病")]
            [Description("D1")]
            _D1,

            /// <summary>
            /// 老人及6個月至6歲兒童流感疫苗注射
            /// </summary>
            [Display(Name = "老人及6個月至6歲兒童流感疫苗注射")]
            [Description("D2")]
            _D2,

            /// <summary>
            /// 登革熱
            /// </summary>
            [Display(Name = "登革熱")]
            [Description("DF")]
            _DF,

            /// <summary>
            /// 健保試辦計劃
            /// </summary>
            [Display(Name = "健保試辦計劃")]
            [Description("E1")]
            _E1,

            /// <summary>
            /// 愛滋病確診服藥滿2年後
            /// </summary>
            [Display(Name = "愛滋病確診服藥滿2年後")]
            [Description("E2")]
            _E2,

            /// <summary>
            /// 愛滋病確診服藥滿2年後之慢性病連續處方再調劑
            /// </summary>
            [Display(Name = "愛滋病確診服藥滿2年後之慢性病連續處方再調劑")]
            [Description("E3")]
            _E3,

            /// <summary>
            /// 流感H1N1病毒抗原快速篩檢
            /// </summary>
            [Display(Name = "流感H1N1病毒抗原快速篩檢")]
            [Description("HN")]
            _HN,

        }
        /// <summary>
        /// 身分別-其他免部分負擔選項
        /// </summary>
        public enum OthPay
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("0")]
            None,
            /// <summary>
            /// 慢性病連續處方
            /// </summary>
            [Display(Name = "慢性病連續處方")]
            [Description("1")]
            SlowSick = 1,
            /// <summary>
            /// 產檢
            /// </summary>
            [Display(Name = "產檢")]
            [Description("2")]
            Predelivery = 2,
            /// <summary>
            /// 預防保健
            /// </summary>
            [Display(Name = "預防保健")]
            [Description("3")]
            PreventHealthCare = 3,
        }
        /// <summary>
        /// 身分別-保健服務項目註記
        /// 使用Description 取得數值
        /// </summary>
        public enum Item
        {
            /// <summary>
            /// 兒童預防保健
            /// </summary>
            [Display(Name = "預設值")]
            [Description("0")]
            None,

            /// <summary>
            /// 兒童預防保健
            /// </summary>
            [Display(Name = "兒童預防保健")]
            [Description("01")]
            _01,

            /// <summary>
            /// 成人預防保健
            /// </summary>
            [Display(Name = "成人預防保健")]
            [Description("02")]
            _02,

            /// <summary>
            /// 婦女抹片檢查
            /// </summary>
            [Display(Name = "婦女抹片檢查")]
            [Description("03")]
            _03,

            /// <summary>
            /// 老人流感
            /// </summary>
            [Display(Name = "老人流感")]
            [Description("04")]
            _04,

            /// <summary>
            /// 兒童牙齒預防保健
            /// </summary>
            [Display(Name = "兒童牙齒預防保健")]
            [Description("05")]
            _05,

            /// <summary>
            /// 婦女乳房檢查服務
            /// </summary>
            [Display(Name = "婦女乳房檢查服務")]
            [Description("06")]
            _06,

            /// <summary>
            /// 定量免疫法大腸糞便潛血檢查
            /// </summary>
            [Display(Name = "定量免疫法大腸糞便潛血檢查")]
            [Description("07")]
            _07,

            /// <summary>
            /// 口腔黏膜檢查
            /// </summary>
            [Display(Name = "口腔黏膜檢查")]
            [Description("08")]
            _08,

            /// <summary>
            /// 兒童常規疫苗
            /// </summary>
            [Display(Name = "兒童常規疫苗")]
            [Description("09")]
            _09,

            /// <summary>
            /// 75歲以上長者肺炎鏈球菌疫苗接種
            /// </summary>
            [Display(Name = "75歲以上長者肺炎鏈球菌疫苗接種")]
            [Description("10")]
            _10,

            /// <summary>
            /// 戒菸服務
            /// </summary>
            [Display(Name = "戒菸服務")]
            [Description("11")]
            _11,

            /// <summary>
            /// COVID-19疫苗
            /// </summary>
            [Display(Name = "COVID-19疫苗")]
            [Description("12")]
            _12,

            /// <summary>
            /// 婦女人類乳突病毒檢測服務
            /// </summary>
            [Display(Name = "婦女人類乳突病毒檢測服務")]
            [Description("13")]
            _13,

            /// <summary>
            /// 胸部低劑量電腦斷層檢查
            /// </summary>
            [Display(Name = "胸部低劑量電腦斷層檢查")]
            [Description("14")]
            _14,

            /// <summary>
            /// 糞便抗原檢測胃幽門螺旋桿菌
            /// </summary>
            [Display(Name = "糞便抗原檢測胃幽門螺旋桿菌")]
            [Description("15")]
            _15,
        }
        /// <summary>
        /// 身分別-給付類別
        /// </summary>
        public enum GiveType
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            [Description("")]
            None,
            /// <summary>
            /// 職業傷害
            /// </summary>
            [Display(Name = "職業傷害")]
            [Description("1")]
            _1,
            /// <summary>
            /// 職業病
            /// </summary>
            [Display(Name = "職業病")]
            [Description("2")]
            _2,
            /// <summary>
            /// 普通傷害
            /// </summary>
            [Display(Name = "普通傷害")]
            [Description("3")]
            _3,
            /// <summary>
            /// 普通疾病
            /// </summary>
            [Display(Name = "普通疾病")]
            [Description("4")]
            _4,
            /// <summary>
            /// 天然災害-巡迴(即指經報備後派遣醫師到災區支援看診)，
            /// </summary>
            [Display(Name = "天然災害-巡迴(即指經報備後派遣醫師到災區支援看診)")]
            [Description("A")]
            _A,
            /// <summary>
            /// 天然災害-非巡迴
            /// </summary>
            [Display(Name = "天然災害-非巡迴")]
            [Description("B")]
            _B,
            /// <summary>
            /// 行政協助法定傳染病通報且隔離案件
            /// </summary>
            [Display(Name = "行政協助法定傳染病通報且隔離案件")]
            [Description("W")]
            _W,

        }
        /// <summary>
        /// 身分別-檢查代碼
        /// 僅有產檢
        /// 使用Description數值
        /// </summary>
        public enum ItemCode
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "", Description = "")]
            [Description("")]
            None,
            /// <summary>
            /// 第一次產檢(第八週)
            /// </summary>
            [Display(Name = "第一次產檢(第八週)", Description = "Predelivery")]
            [Description("40")]
            IC40,
            /// <summary>
            /// 第二次產檢(第十二週)
            /// </summary>
            [Display(Name = "第二次產檢(第十二週)", Description = "Predelivery")]
            [Description("41")]
            IC41,
            /// <summary>
            /// 第三次產檢(第十六週)
            /// </summary>
            [Display(Name = "第三次產檢(第十六週)", Description = "Predelivery")]
            [Description("42")]
            IC42,
            /// <summary>
            /// 第四次產檢(第二十週)
            /// </summary>
            [Display(Name = "第四次產檢(第二十週)", Description = "Predelivery")]
            [Description("43")]
            IC43,
            /// <summary>
            /// 第五次產檢(第二十四週)
            /// </summary>
            [Display(Name = "第五次產檢(第二十四週)", Description = "Predelivery")]
            [Description("44")]
            IC44,
            /// <summary>
            /// 第六次產檢(第二十八週)
            /// </summary>
            [Display(Name = "第六次產檢(第二十八週)", Description = "Predelivery")]
            [Description("45")]
            IC45,
            /// <summary>
            /// 第七次產檢(第三十週)
            /// </summary>
            [Display(Name = "第七次產檢(第三十週)", Description = "Predelivery")]
            [Description("46")]
            IC46,
            /// <summary>
            /// 第八次產檢(第三十二週)
            /// </summary>
            [Display(Name = "第八次產檢(第三十二週)", Description = "Predelivery")]
            [Description("47")]
            IC47,
            /// <summary>
            /// 第九次產檢(第三十四週)
            /// </summary>
            [Display(Name = "第九次產檢(第三十四週)", Description = "Predelivery")]
            [Description("48")]
            IC48,
            /// <summary>
            /// 第十次產檢(第三十六週)
            /// </summary>
            [Display(Name = "第十次產檢(第三十六週)", Description = "Predelivery")]
            [Description("49")]
            IC49,
            /// <summary>
            /// 第十一次產檢(第三七週)
            /// </summary>
            [Display(Name = "第十一次產檢(第三七週)", Description = "Predelivery")]
            [Description("50")]
            IC50,
            /// <summary>
            /// 第十二次產檢(第三八週)
            /// </summary>
            [Display(Name = "第十二次產檢(第三八週)", Description = "Predelivery")]
            [Description("51")]
            IC51,
            /// <summary>
            /// 第十三次產檢(第三九週)
            /// </summary>
            [Display(Name = "第十三次產檢(第三九週)", Description = "Predelivery")]
            [Description("52")]
            IC52,
            /// <summary>
            /// 第十四次產檢(第四十週)
            /// </summary>
            [Display(Name = "第十四次產檢(第四十週)", Description = "Predelivery")]
            [Description("53")]
            IC53,
            /// <summary>
            /// 第十五次(含)以上產檢[不符合健保給付]
            /// </summary>
            [Display(Name = "第十五次(含)以上產檢[不符合健保給付]", Description = "Predelivery")]
            [Description("54")]
            IC54,

        }
        #endregion

        #region 檢核類別 20210701 林威志
        /// <summary>
        /// 申報鎖控檢核類別
        /// </summary>
        public enum CHKFunctionName
        {
            /// <summary>
            /// 權限檢核
            /// </summary>
            AUTHORITY_LIMIT,
            /// <summary>
            /// 機敏性病歷限制
            /// </summary> 
            ALERTNESS_CHART,
            /// <summary>
            /// 住院資訊檢核
            /// </summary> 
            ADMITTED_INF,
            /// <summary>
            /// 病人基本資料
            /// </summary> 
            BASIC_INFO,
            /// <summary>
            /// 收費權限
            /// </summary> 
            CHARGE_AUTHORITY,
            /// <summary>
            /// 案件檢核
            /// </summary> 
            CASETYPE_LIMIT,
            /// <summary>
            /// 醫師
            /// </summary> 
            DOCTOR,
            /// <summary>
            /// 結案檢核
            /// </summary> 
            CASE_FINISHED,
            /// <summary>
            /// 收費型態
            /// </summary> 
            CHARE_TYPE,
            /// <summary>
            /// 診斷檢核
            /// </summary> 
            DIAG_CHECK,
            /// <summary>
            /// 優待類別
            /// </summary> 
            DISCOUNT_TYPE,
            /// <summary>
            /// 欄位檢核
            /// </summary> 
            FIELD_CHECK,
            /// <summary>
            /// 安寧紀錄提示
            /// </summary> 
            HOSPICE_CARE,
            /// <summary>
            /// 申報
            /// </summary> 
            HEALTH_INSURANCE,
            /// <summary>
            /// 傳染病通報
            /// </summary> 
            INF_DISEASE,
            /// <summary>
            /// 藥品檢核
            /// </summary> 
            MED_CHECK,
            /// <summary>
            /// 重大傷病碼註記
            /// </summary> 
            MAJOR_INJURY_DIAG,
            /// <summary>
            /// 藥品限制
            /// </summary> 
            MED_LIMIT,
            /// <summary>
            /// 醫令檢核
            /// </summary> 
            ORDER_CHECK,
            /// <summary>
            /// 醫令限制
            /// </summary> 
            ORDER_LIMIT,
            /// <summary>
            /// 部份負擔
            /// </summary> 
            PARTIAL_PAY,
            /// <summary>
            /// PPF提成
            /// </summary>
            PPF,
            /// <summary>
            /// 病人身分資格
            /// </summary> 
            QUALIFICATION_CHECK,
            /// <summary>
            /// 預防保健
            /// </summary> 
            PREVENTIVE_CARE,
            /// <summary>
            /// 轉診檢核
            /// </summary> 
            REFER_TO,
            /// <summary>
            /// 病人狀態
            /// </summary> 
            STATUS_CHECK,
            /// <summary>
            /// 特殊身分提示
            /// </summary> 
            SPECIAL_ID,
            /// <summary>
            /// 科別限制
            /// </summary>
            DEPT_LIMIT,
            /// <summary>
            /// 檢驗檢查
            /// </summary>
            LABEXM_CHECK
        }

        /// <summary>
        /// 檢核方法代碼
        /// </summary>
        public enum CHKFunctionCode
        {
            /// <summary>
            /// 掛號
            /// </summary>
            _01,
            /// <summary>
            /// 身分確認
            /// </summary> 
            _02,
            /// <summary>
            /// 檢傷
            /// </summary> 
            _03,
            /// <summary>
            /// 問診作業
            /// </summary> 
            _04,
            /// <summary>
            /// 診間開立
            /// </summary> 
            _05,
            /// <summary>
            /// 診間存檔(保留、結案)
            /// </summary> 
            _06,
            /// <summary>
            /// 批價
            /// </summary> 
            _07,
            /// <summary>
            /// 收費
            /// </summary> 
            _08,
            /// <summary>
            /// 收退費
            /// </summary> 
            _09,
            /// <summary>
            /// 同療
            /// </summary> 
            _10,
            /// <summary>
            /// 報到
            /// </summary> 
            _11,
            /// <summary>
            /// 品修
            /// </summary> 
            _12,
        }

        /// <summary>
        /// 檢核系統代碼
        /// </summary>
        public enum CHKSystemCode
        {
            /// <summary>
            /// 門診系統
            /// </summary> 
            O,
            /// <summary>
            /// 急診系統
            /// </summary> 
            E,
            /// <summary>
            /// 牙科診間系統
            /// </summary> 
            D,
        }
        /// <summary>
        /// NHICheck 警示類別
        /// </summary>
        public enum CHKAlertType
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            Null,
            /// <summary>
            /// 強制
            /// </summary>
            [Display(Name = "強制")]
            A,
            /// <summary>
            /// 警示
            /// </summary>
            [Display(Name = "警示")]
            B,
        }
        #endregion

        #region 就醫診療註記 20210708 林伯翰
        /// <summary>
        /// 就醫診療註記
        /// Description:代碼, Display.Name:中文名稱
        /// </summary>
        public enum MedlogKindList
        {
            /// <summary>
            /// 自殺防治 B
            /// </summary>
            [Display(Name = "自殺防治")]
            [Description("B")]
            SuicidePrevention,
            /// <summary>
            /// 高危險跌倒防治 S
            /// </summary>
            [Display(Name = "高危險跌倒防治")]
            [Description("S")]
            HighRiskFallPrevention,
            /// <summary>
            /// 戒菸
            /// </summary>
            [Display(Name = "戒菸")]
            [Description("Q")]
            QuickSmoking,
            /// <summary>
            /// 關懷人員藥物清單
            /// </summary>
            [Display(Name = "關懷人員藥物清單")]
            [Description("PSY")]
            CareWorkerMedList,
            /// <summary>
            /// 遺失慢籤
            /// </summary>
            [Display(Name = "遺失慢籤")]
            [Description("L")]
            LostSlowVisa,
            /// <summary>
            /// 持機票
            /// </summary>
            [Display(Name = "持機票")]
            [Description("K")]
            HoldAirTicket,
            /// <summary>
            /// 離島病人已留存證明文件
            /// </summary>
            [Display(Name = "離島病人已留存證明文件")]
            [Description("3")]
            OutlyingIslandPatientsSupportingDocuments,
        }

        #endregion

        #region 門診 身分確認資料下載使用 
        /// <summary>
        /// 身分確認資料下載 ENUM
        /// </summary>
        public enum IdentityDataLoadingType
        {
            /// <summary>
            /// 身分類別基本
            /// </summary>
            [Description("身分類別基本")]
            PatientGroup,
            /// <summary>
            /// 保險類別基本
            /// </summary>
            [Description("保險類別基本")]
            INSUType,
            /// <summary>
            /// 案件分類基本
            /// </summary>
            [Description("案件分類基本")]
            BasCase,
            /// <summary>
            /// 部分負擔基本
            /// </summary>
            [Description("部分負擔基本")]
            BasPart,
            /// <summary>
            /// 優待類別基本
            /// </summary>
            [Description("優待類別基本")]
            VIPDef,
            /// <summary>
            /// 給付類別基本
            /// </summary>
            [Description("給付類別基本")]
            GiveType,
            /// <summary>
            /// 就醫類別
            /// </summary>
            [Description("就醫類別")]
            TreatItem,
            /// <summary>
            /// 其他免部分負擔選項
            /// </summary>
            [Description("其他免部分負擔選項")]
            OthPay,
            /// <summary>
            /// 保健服務品項註記
            /// </summary>
            [Description("保健服務品項註記")]
            Item,
            /// <summary>
            /// 身份確認CheckBoxData List
            /// </summary>
            [Description("身份確認")]
            IdentityCheck,
            /// <summary>
            /// 醫療院所List
            /// </summary>
            [Description("醫療院所")]
            ReferralHospitalList,
            /// <summary>
            /// 代領藥和掛號身分別Data
            /// </summary>
            [Description("代領藥和掛號身分別資料")]
            AlternativeReceiveMedicineData,
            /// <summary>
            /// 藥袋資訊
            /// </summary>
            [Description("藥袋資訊")]
            MedicineBagInfo,
            [Description("異常拋出")]
            ErrorException
        }
        #endregion

        #region AFTERMAKE 最終動向
        /// <summary>
        /// 最終動向
        /// </summary>
        public enum AFTERMAKE //後續處理List
        {
            /// <summary>
            /// 未勾選
            /// </summary>
            [Display(Name = "Null")]
            [Description("未勾選")]
            Null = 9999,
            /// <summary>
            /// 住院
            /// </summary>
            [Display(Name = "IPD")]
            [Description("住院")]
            IPD = 0,
            /// <summary>
            /// 轉ICU
            /// </summary>
            [Display(Name = "ICU")]
            [Description("加護病房")]
            ICU = 1,
            /// <summary>
            /// 門診複查
            /// </summary>
            [Display(Name = "OPDReview")]
            [Description("門診複查")]
            OPDReview = 2,
            /// <summary>
            /// 觀察（超過一小時)
            /// </summary>
            [Display(Name = "ObserveOverOneHours")]
            [Description("觀察（超過一小時)")]
            ObserveOverOneHours = 3,
            /// <summary>
            /// 未完成治療離院
            /// </summary>
            [Display(Name = "LeaveWithoutTreatment")]
            [Description("未完成治療離院")]
            LeaveWithoutTreatment = 4,
            /// <summary>
            /// 死亡
            /// </summary>
            [Display(Name = "Death")]
            [Description("死亡")]
            Death = 5,
            /// <summary>
            /// 轉至他院
            /// </summary>
            [Display(Name = "ReferringToOtherHospital")]
            [Description("轉至他院")]
            ReferringToOtherHospital = 6,
            /// <summary>
            /// 未完成治療轉院
            /// </summary>
            [Display(Name = "LeaveWithoutTransferHospital")]
            [Description("未完成治療轉院")]
            LeaveWithoutTransferHospital = 7,
            /// <summary>
            /// 逃院
            /// </summary>
            [Display(Name = "Escape")]
            [Description("逃院")]
            Escape = 8,
            /// <summary>
            /// 病人要求轉往他院治療
            /// </summary>
            [Display(Name = "ToOtherHospitalPatient")]
            [Description("病人要求轉往他院治療")]
            ToOtherHospitalPatient = 9,
            /// <summary>
            /// 病危返家
            /// </summary>
            [Display(Name = "GoHomeDeath")]
            [Description("病危返家")]
            GoHomeDeath = 10,
            /// <summary>
            /// 病危返家
            /// </summary>
            [Display(Name = "OPAT")]
            [Description("OPAT")]
            OPAT = 11
        }
        #endregion

        #region ER Observation Bed 急診留觀床位狀態
        /// <summary>
        /// 佔床碼
        /// </summary>
        public enum BedOccupy
        {
            /// <summary>
            /// 特殊佔床
            /// </summary>
            [Description("特殊佔床")]
            D,
            /// <summary>
            /// 佔床
            /// </summary>
            [Description("佔床")]
            G,
            /// <summary>
            /// 隔離佔床
            /// </summary>
            [Description("隔離佔床")]
            I,
            /// <summary>
            /// 空床
            /// </summary>
            [Description("空床")]
            N,
            /// <summary>
            /// 預約床
            /// </summary>
            [Description("預約床")]
            P,
            /// <summary>
            /// 包房佔床
            /// </summary>
            [Description("包房佔床")]
            S
        }
        /// <summary>
        /// 病床狀態
        /// </summary>
        public enum BedStatus
        {
            /// <summary>
            /// 病人已結清帳款,但尚未出院
            /// </summary>
            [Description("病人已結清帳款,但尚未出院")]
            B,
            /// <summary>
            /// 空床
            /// </summary>
            [Description("空床")]
            C,
            /// <summary>
            /// 佔床
            /// </summary>
            [Description("佔床")]
            O,
            /// <summary>
            /// 床位即將空出(結帳中)
            /// </summary>
            [Description("床位即將空出(結帳中)")]
            P,
            /// <summary>
            /// 已預約(床位未報到)
            /// </summary>
            [Description("已預約(床位未報到)")]
            T
        }
        #endregion

        #region OPD Dashboard Enum
        /// <summary>
        /// 上方MenuItem Title Name, Display(Name = "中文名", Description = "階層深度", GroupName = "父階層名稱", Order="階層排序")
        /// </summary>
        public enum OPDDashboard_MenuItemTitle
        {
            /// <summary>
            /// 系統設定
            /// </summary>
            [Display(Name = "系統設定", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            SystemPerformance,
            /// <summary>
            /// 查詢作業
            /// </summary>
            [Display(Name = "查詢作業", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            QueryOperation,
            /// <summary>
            /// 健兒門診
            /// </summary>
            [Display(Name = "健兒門診", AutoGenerateField = false, Description = "1", GroupName = nameof(OPDDashboard_MenuItemTitle.QueryOperation))]
            [Description(nameof(OPDDashboard_MenuItemTitle.QueryOperation))]
            HealthCareChildrenClinic,
            /// <summary>
            /// 統計報表
            /// </summary>
            [Display(Name = "統計報表", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            StatisticalReport,
            /// <summary>
            /// 醫師報到
            /// </summary>
            [Display(Name = "醫師報到", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            DoctorReportDuty,
            /// <summary>
            /// 健保卡設定
            /// </summary>
            [Display(Name = "健保卡設定", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            NHIICcardSettings,
            /// <summary>
            /// 病患清單重新整理秒數
            /// </summary>
            [Display(Name = "病患清單重新整理秒數", AutoGenerateField = true, Description = "1", GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance))]
            //[Description(nameof(OPDDashboard_MenuItemTitle.SystemPerformance))]
            DashboardPatientListReferesh,
            /// <summary>
            /// 病患清單病患姓名字體大小設定
            /// </summary>
            [Display(Name = "病患清單病患姓名字體大小設定", AutoGenerateField = true, Description = "2", GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance))]
            //[Description(nameof(OPDDashboard_MenuItemTitle.SystemPerformance))]
            DashboardPatientListPatientNameFontSize,
            ///// <summary>
            ///// 健保雲端主控台重啟
            ///// </summary>
            //[Display(Name = "健保雲端主控台重啟", AutoGenerateField = true, Description = "0", GroupName = "ROOT")]
            ////[Description(nameof(OPDDashboard_MenuItemTitle.SystemPerformance))]
            //NHIResetCsfsimExe,
        }
        /// <summary>
        /// Display(Name = "中文名", Description = "階層深度", GroupName = "父階層名稱", Order="階層排序"), 
        /// AutoGenerateField = false(UI上已經有，故程式碼不自動產生項目) 
        /// </summary>
        public enum OPDDashboard_MenuItem
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            [Description("ROOT")]
            NULL,
            /// <summary>
            /// 讀寫健保卡是否使用Com Server
            /// </summary>
            [Display(Name = "讀寫健保卡是否使用Com Server(64位元程式專用)"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 1
                , AutoGenerateField = false)]
            [Description("點擊來重新啟動健保卡ComServer元件")]
            SystemPerformance_IsNHIIcCardUseComServerMode,
            /// <summary>
            /// 健保署控制軟體啟動區域:
            /// </summary>
            [Display(Name = "健保署控制軟體啟動區域:"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 2
                , AutoGenerateField = false)]
            [Description("[預設使用本機版],遠端版:院外電腦使用微軟遠端桌面並勾選本機資源->其他->\"智慧卡\"與\"連接埠\"來使用")]
            SystemPerformance_IsNHIIcCardUseLocalType,

            /// <summary>
            /// 套餐
            /// </summary>
            [Display(Name = "套餐維護功能"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 3
                , AutoGenerateField = true)]
            [Description("")]
            SystemPerformance_PackageOrder,
            /// <summary>
            /// 片語
            /// </summary>
            [Display(Name = "片語維護功能"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 4
                , AutoGenerateField = true)]
            [Description("")]
            SystemPerformance_CommonPhrases,
            /// <summary>
            /// 設定健保讀卡機設定檔
            /// </summary>
            [Display(Name = "設定健保(舊)讀卡機設定檔"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 5
                , AutoGenerateField = false)]
            [Description("複製設定檔並關閉健保讀卡主控台")]
            SystemPerformance_NHISettingsNonPCSC,
            /// <summary>
            /// 設定晶片讀卡機設定檔
            /// </summary>
            [Display(Name = "設定晶片(新)讀卡機設定檔"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 6
                , AutoGenerateField = false)]
            [Description("複製設定檔並運行健保讀卡主控台")]
            SystemPerformance_NHISettingsPCSC,
            /// <summary>
            /// 設定N/A讀卡機設定檔
            /// </summary>
            [Display(Name = "設定N/A讀卡機設定檔"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 7
                , AutoGenerateField = false)]
            [Description("複製設定檔並運行健保讀卡程式")]
            SystemPerformance_NHISettingsNA,
            /// <summary>
            /// 安裝健保署雲端讀卡機主控台
            /// </summary>
            [Display(Name = "安裝/修復健保署雲端讀卡機主控台"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 8
                , AutoGenerateField = true)]
            [Description("111/09/25發佈, Ver:5.1.5.7")]
            SystemPerformance_InstalNHIPCSC,
            /// <summary>
            /// 啟動雲端健保署讀卡機主控台
            /// </summary>
            [Display(Name = "啟動(重啟)雲端健保署讀卡機主控台"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 9
                , AutoGenerateField = true)]
            [Description("關閉主控台程式並重新啟動主控台程式")]
            SystemPerformance_ExecuteNHICSFSIM,

            /// <summary>
            /// 啟動雲端健保署讀卡機主控台
            /// </summary>
            [Display(Name = "軟體重啟 健保署讀卡機主控台"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 10
                , AutoGenerateField = true)]
            [Description("軟體重置健保卡主控台API(需重新認證醫師PIN碼)")]
            SystemPerformance_SoftwareResetNHICSFSIM,

            /// <summary>
            /// 相關醫令資料讀取來源:線上
            /// </summary>
            [Display(Name = "相關醫令資料讀取來源:線上", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 11
                , AutoGenerateField = true)]
            [Description("讀取HIS2資料庫，並重新下載資源檔")]
            SystemPerformance_DataDictionarySource_Online,
            /// <summary>
            /// 相關醫令資料讀取來源:離線
            /// </summary>
            [Display(Name = "相關醫令資料讀取來源:離線", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 12
                , AutoGenerateField = false)]
            [Description("讀取離線檔案")]
            SystemPerformance_DataDictionarySource_Offline,
            /// <summary>
            /// 相關醫令資料_離線下載
            /// </summary>
            [Display(Name = "相關醫令資料_離線下載", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 13
                , AutoGenerateField = false)]
            [Description("離線下載相關醫令基本資料")]
            SystemPerformance_DataDictionarySource_Downloader,
            ///// <summary>
            ///// 切換門診診間位元執行環境
            ///// </summary>
            //[Display(Name = "切換門診診間位元執行環境", Description = "1"
            //    , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
            //    , Order = 14
            //    , AutoGenerateField = false)]
            //[Description("須關閉診間來切換32或64位元執行環境[預設32位元]")]
            //SystemPerformance_ManualChangeExecuteBitVersion,

            /// <summary>
            /// 健保署主控台雲端安全模組檔檢核與修復
            /// </summary>
            [Display(Name = "健保主控台5.0雲端安全模組檢核與修復", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 15
                , AutoGenerateField = true)]
            [Description("點擊為檢核5.0使用雲端安全模組，並嘗試修復後再次重啟5.0主控台!")]
            SystemPerformance_RepairCSHIS50SAMFile,

            /// <summary>
            /// 讀取資料庫健保VPN相關讀卡功能狀態註記
            /// </summary>
            [Display(Name = "健保VPN相關讀卡功能狀態[有\u221a為啟用讀寫卡功能]", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 16
                , AutoGenerateField = true)]
            [Description("點擊為重新讀取資料庫健保VPN相關讀卡功能狀態註記")]
            SystemPerformance_ReloadNHIVPN_API_State,

            /// <summary>
            /// 開啟讀卡控制軟體 6.0 主控台公用程式
            /// </summary>
            [Display(Name = "開啟讀卡控制軟體 6.0 主控台公用程式", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 17
                , AutoGenerateField = true)]
            [Description("僅限於有安裝讀卡控制軟體6.0才能呼叫，否則會出現相關錯誤訊息,如果有打勾代表有初始化6.0主控台.")]
            SystemPerformance_CSHIS60_Panel,

            /// <summary>
            /// 更新表單
            /// </summary>
            [Display(Name = "更新表單", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 18
                , AutoGenerateField = true)]
            //[Description(nameof(OPDDashboard_MenuItemTitle.SystemPerformance))]
            ForceUpdateOPDReport,



            /// <summary>
            /// 醫師報到
            /// </summary>
            [Display(Name = "醫師報到", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DoctorReportDuty)
                , Order = 1
                , AutoGenerateField = false)]
            [Description("")]
            DoctorReportDuty_DoctorReportDutyCheckIn,
            /// <summary>
            /// 醫師查詢報到時間
            /// </summary>
            [Display(Name = "查詢報到時間", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DoctorReportDuty)
                , Order = 2
                , AutoGenerateField = false)]
            [Description("")]
            DoctorReportDuty_DoctorReportDutyQueryDateTime,
            /// <summary>
            /// 醫事人員卡PIN碼驗證
            /// </summary>
            [Display(Name = "醫事人員卡PIN碼驗證", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DoctorReportDuty)
                , Order = 3
                , AutoGenerateField = true)]
            [Description("")]
            DoctorReportDuty_HPCPinVerify,


            #region 健保卡設定
            /// <summary>
            /// 總是讀取健保卡
            /// </summary>
            [Display(Name = "總是讀取健保卡", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.NHIICcardSettings)
                , Order = 1
                , AutoGenerateField = false)]
            [Description("不詢問直接讀取健保卡")]
            NHIICcardSettings_EnabledReadNHIIcCard,
            /// <summary>
            /// 總是讀取健保卡
            /// </summary>
            [Display(Name = "詢問是否讀取健保卡", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.NHIICcardSettings)
                , Order = 2
                , AutoGenerateField = false)]
            [Description("詢問是否讀取健保卡")]
            NHIICcardSettings_ReqiureReadNHIIcCard,
            /// <summary>
            /// 總是讀取健保卡
            /// </summary>
            [Display(Name = "不讀取健保卡", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.NHIICcardSettings)
                , Order = 3
                , AutoGenerateField = false)]
            [Description("不讀取健保卡相關資料，易造成健保申報資料缺失")]
            NHIICcardSettings_DisableReadNHIIcCard,

            #endregion 健保卡設定

            #region 查詢作業
            /// <summary>
            /// 查詢病患掛號資料
            /// </summary>
            [Display(Name = "查詢病患掛號資料", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.QueryOperation)
                , Order = 1
                , AutoGenerateField = true)]
            [Description("")]
            QueryOperation_DoctorQueryPatientRegData,
            /// <summary>
            /// 糖尿病＆CKD照護統計
            /// </summary>
            [Display(Name = "糖尿病＆CKD照護統計", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.QueryOperation)
                , Order = 2
                , AutoGenerateField = false)]
            [Description("")]
            QueryOperation_DiabetesAndCKDCareStatistics,
            /// <summary>
            /// 病人名條列印
            /// </summary>
            [Display(Name = "病人名條列印", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.QueryOperation)
                , Order = 3
                , AutoGenerateField = true)]
            [Description("")]
            QueryOperation_PrintPatientLabelView,
            /// <summary>
            /// 胎兒健康評估報告系統
            /// </summary>
            [Display(Name = "胎兒健康評估報告系統", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.QueryOperation)
                , Order = 4
                , AutoGenerateField = true)]
            [Description("")]
            QueryOperation_FetalHealthAssessmentReportingSystem,

            #endregion 查詢作業

            #region 健兒門診 HealthCareChildrenClinic
            /// <summary>
            /// 健兒門診年齡列印
            /// </summary>
            [Display(Name = "健兒門診年齡列印", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
                , Order = 1
                , AutoGenerateField = false)]
            [Description("")]
            HealthCareChildrenClinic_WBCAgePrint,
            /// <summary>
            /// 健兒門診年齡統計
            /// </summary>
            [Display(Name = "健兒門診年齡統計", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
                , Order = 2
                , AutoGenerateField = false)]
            [Description("")]
            HealthCareChildrenClinic_WBCAgeStat,
            /// <summary>
            /// 兒童預防保健衛教統計表
            /// </summary>
            [Display(Name = "兒童預防保健衛教統計表", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
                , Order = 3
                , AutoGenerateField = false)]
            [Description("")]
            HealthCareChildrenClinic_ChildPrevenHealthStat,
            /// <summary>
            /// 台北市兒童諮詢申請總表轉檔
            /// </summary>
            [Display(Name = "台北市兒童諮詢申請總表轉檔", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
                , Order = 4
                , AutoGenerateField = false)]
            [Description("")]
            HealthCareChildrenClinic_TPCChildCA,
            //20231226 林江說不使用此表單
            ///// <summary> 
            ///// 健兒門診預防接種
            ///// </summary>
            //[Display(Name = "健兒門診預防接種", Description = "1"
            //    , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
            //    , Order = 5
            //    , AutoGenerateField = false)]
            //[Description("")]
            //HealthCareChildrenClinic_WBCPrevenInject,
            /// <summary>
            /// 健兒門診病人施打疫苗查詢
            /// </summary>
            [Display(Name = "健兒門診病人施打疫苗查詢", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
                , Order = 6
                , AutoGenerateField = false)]
            [Description("")]
            HealthCareChildrenClinic_WBCVaccination,

            #endregion 健兒門診 HealthCareChildrenClinic

            #region 重新整理秒數
            /// <summary>
            /// 重新整理秒數 60秒
            /// </summary>
            [Display(Name = "一分鐘(60秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 1
                , AutoGenerateField = true)]
            [Description("60")]
            DashboardPatientListReferesh_Refresh60Seconds,
            /// <summary>
            /// 重新整理秒數 90秒
            /// </summary>
            [Display(Name = "一分半鐘(90秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 2
                , AutoGenerateField = true)]
            [Description("90")]
            DashboardPatientListReferesh_Refresh90Seconds,
            /// <summary>
            /// 重新整理秒數 120秒
            /// </summary>
            [Display(Name = "兩分鐘(120秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 3
                , AutoGenerateField = true)]
            [Description("120")]
            DashboardPatientListReferesh_Refresh120Seconds,
            /// <summary>
            /// 重新整理秒數 150秒
            /// </summary>
            [Display(Name = "兩分半鐘(150秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 4
                , AutoGenerateField = true)]
            [Description("150")]
            DashboardPatientListReferesh_Refresh150Seconds,
            /// <summary>
            /// 重新整理秒數 180秒
            /// </summary>
            [Display(Name = "三分鐘(180秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 5
                , AutoGenerateField = true)]
            [Description("180")]
            DashboardPatientListReferesh_Refresh180Seconds,
            /// <summary>
            /// 重新整理秒數 240秒
            /// </summary>
            [Display(Name = "四分鐘(240秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 6
                , AutoGenerateField = true)]
            [Description("240")]
            DashboardPatientListReferesh_Refresh240Seconds,
            /// <summary>
            /// 重新整理秒數 300秒
            /// </summary>
            [Display(Name = "五分鐘(300秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 7
                , AutoGenerateField = true)]
            [Description("300")]
            DashboardPatientListReferesh_Refresh300Seconds,
            /// <summary>
            /// 重新整理秒數 300秒
            /// </summary>
            [Display(Name = "七分鐘(420秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 8
                , AutoGenerateField = true)]
            [Description("420")]
            DashboardPatientListReferesh_Refresh420Seconds,
            /// <summary>
            /// 重新整理秒數 300秒
            /// </summary>
            [Display(Name = "十分鐘(600秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 9
                , AutoGenerateField = true)]
            [Description("600")]
            DashboardPatientListReferesh_Refresh600Seconds,

            #endregion

            #region DashboardPatientListPatientNameFontSize

            /// <summary>
            /// 預設字體大小(12f)
            /// </summary>
            [Display(Name = "預設字體大小(12f)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListPatientNameFontSize)
                , Order = 1
                , AutoGenerateField = true)]
            [Description("12")]
            DashboardPatientListPatientNameFontSize_FontSize12,
            /// <summary>
            /// 稍大字體大小(13f)
            /// </summary>
            [Display(Name = "稍大字體大小(13f)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListPatientNameFontSize)
                , Order = 2
                , AutoGenerateField = true)]
            [Description("13")]
            DashboardPatientListPatientNameFontSize_FontSize13,
            /// <summary>
            /// 加大字體大小(14f)
            /// </summary>
            [Display(Name = "加大字體大小(14f)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListPatientNameFontSize)
                , Order = 3
                , AutoGenerateField = true)]
            [Description("14")]
            DashboardPatientListPatientNameFontSize_FontSize14,

            #endregion
        }
        /// <summary>
        /// 門診診間儀錶板 右鍵選單 MenuItem
        /// </summary>
        public enum OPDDashboard_ContextMenu_Title
        {
            /// <summary>
            /// 表單列印
            /// </summary>
            [Display(Name = "表單列印")]
            [Description("ROOT")]
            PrintDocument
        }
        /// <summary>
        /// 門診診間儀錶板 右鍵選單 Item
        /// </summary>
        public enum OPDDashboard_ContextMenu_Item
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            Null = 0,
            /// <summary>
            /// 批價單
            /// </summary>
            [Display(Name = "批價單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument01,
            /// <summary>
            /// 一般藥品處方箋
            /// </summary>
            [Display(Name = "一般藥品處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument02,
            /// <summary>
            /// 公藥
            /// </summary>
            [Display(Name = "公藥處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument03,
            /// <summary>
            /// 試驗用藥
            /// </summary>
            [Display(Name = "試驗用藥處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument04,
            /// <summary>
            /// 管制藥
            /// </summary>
            [Display(Name = "管制藥處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument05,
            /// <summary>
            /// 化療
            /// </summary>
            [Display(Name = "化療處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument06,
            /// <summary>
            /// TPN
            /// </summary>
            [Display(Name = "TPN")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument07,
            /// <summary>
            /// 慢箋
            /// </summary>
            [Display(Name = "慢箋處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument08,
            /// <summary>
            /// 慢箋管制藥
            /// </summary>
            [Display(Name = "慢箋管制藥處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument09,
            /// <summary>
            /// 美沙東
            /// </summary>
            [Display(Name = "美沙東處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument10,
            /// <summary>
            /// 檢驗檢查單
            /// </summary>
            [Display(Name = "檢驗、檢查單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument11,
            /// <summary>
            /// 手術、處理、檢查申請單
            /// </summary>
            [Display(Name = "手術、處理、檢查申請單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_SugProPsyDocumentApply,
            /// <summary>
            /// 一次領藥切結書
            /// </summary>
            [Display(Name = "一次領藥切結書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument12,
            /// <summary>
            /// 代領藥切結書
            /// </summary>
            [Display(Name = "代領藥切結書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument13,
            /// <summary>
            /// 代領藥切結書(滯留大陸)
            /// </summary>
            [Display(Name = "代領藥切結書(滯留大陸)")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument14,

            /// <summary>
            /// 自費同意書
            /// </summary>
            [Display(Name = "自費同意書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument15,
            /// <summary>
            /// 轉診摘要
            /// </summary>
            [Display(Name = "轉診摘要")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_ReferralSummary,
            /// <summary>
            /// 門診藥物注射暨觀察紀錄單
            /// </summary>
            [Display(Name = "門診藥物注射暨觀察紀錄單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_OMedInjectObserveRPT,
            /// <summary>
            /// 口腔黏膜檢查表
            /// </summary>
            [Display(Name = "口腔黏膜檢查表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_OralMucosaExam,
            /// <summary>
            /// 定量免疫法糞便潛血檢查紀錄表
            /// </summary>
            [Display(Name = "定量免疫法糞便潛血檢查紀錄表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_FecalOccultBloodTest,
            /// <summary>
            /// 糞便抗原檢測胃幽門螺旋桿菌服務紀錄單
            /// </summary>
            [Display(Name = "糞便抗原檢測胃幽門螺旋桿菌服務紀錄單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_GastricCancerRecord,
            /// <summary>
            /// 門診交付調劑處方箋
            /// </summary>
            [Display(Name = "門診交付調劑處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_DEPRPT,
            /// <summary>
            /// 手術通知單-空白單
            /// </summary>
            [Display(Name = "手術通知單-空白單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_SurgeryNoticeForm,
            /// <summary>
            /// 麻醉藥品居家治療用藥紀錄表
            /// </summary>
            [Display(Name = "麻醉藥品居家治療用藥紀錄表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_AnestheticHomeUserec,

            /// <summary>
            /// 吩坦尼穿皮貼片劑使用紀錄表
            /// </summary>
            [Display(Name = "吩坦尼穿皮貼片劑使用紀錄表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_FentanylTDPUserec,

            /// <summary>
            /// 化療醫囑單
            /// </summary>
            [Display(Name = "化療醫囑單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_OCHEMOSheet,

            /// <summary>
            /// 復健治療明細表
            /// </summary>
            [Display(Name = "復健治療明細表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_REHTreatDetail,

            /// <summary>
            /// 六分鐘步行測試前須知暨同意書
            /// </summary>
            [Display(Name = "六分鐘步行測試前須知暨同意書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_SMWTConsent,
            /// <summary>
            /// 入院許可證
            /// </summary>
            [Display(Name = "入院許可證")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_AdmissionPermit,
            /// <summary>
            /// 公費流感抗病毒藥劑申請單
            /// </summary>
            [Display(Name = "公費流感抗病毒藥劑申請單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_PFIADApplication,
            /// <summary>
            /// 公費COVID-19複合式單株抗體Evusheld個案用藥同意書
            /// </summary>
            [Display(Name = "公費COVID-19複合式單株抗體Evusheld個案用藥同意書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_COVID19ECUDConsent,
            /// <summary>
            /// COVID-19口服抗病毒藥物使用評估表
            /// </summary>
            [Display(Name = "COVID-19口服抗病毒藥物使用評估表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_COVID19OADUEForm,
            /// <summary>
            /// 病人治療同意書(Paxlovid、Molnupiravir)
            /// </summary>
            [Display(Name = "病人治療同意書(Paxlovid、Molnupiravir)")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_COVID19PTConsent,
            /// <summary>
            /// 教學門診同意書
            /// </summary>
            [Display(Name = "教學門診同意書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_TCConsentform,
            /// <summary>
            /// 潛伏結核LTBI篩檢流程單
            /// </summary>
            [Display(Name = "潛伏結核LTBI篩檢流程單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_LTBI,
            /// <summary>
            /// 潛伏結核LTBI治療衛教單
            /// </summary>
            [Display(Name = "潛伏結核LTBI治療衛教單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_LTBI_Edu
        }

        #endregion

        #region DataDictionarySourceJsonFileName
        /// <summary>
        /// 離線基本醫令資料JSON檔案名稱,DisplayName = DataDictionary中的屬性名稱 , Description = Model名稱
        /// </summary>
        public enum OPDClinicRoom_DataDictionarySourceJsonFileName
        {
            [Display(Name = "NULL")]
            [Description("NULL")]
            None,

            //ICDData
            [Display(Name = "lDiaglistICD10")]
            [Description("BASDIAG_ICD10_SIMPLIFY")]
            lDiaglistICD10,
            [Display(Name = "lDiaglistICD9")]
            [Description("BASDIAG_ICD10_SIMPLIFY")]
            lDiaglistICD9,

            //ORDERCODEData
            [Display(Name = "RawOrderCodeMasterList")]
            [Description("ORDERCODEMASTER_SIMPLIFY")]
            RawOrderCodeMasterList,

            //BasicData
            [Display(Name = "DeptList")]
            [Description("BASSECH")]
            DeptList,
            [Display(Name = "lSysUserList")]
            [Description("SYSUSER_SIMPLIFY")]
            lSysUserList,
            [Display(Name = "lBASOROPList")]
            [Description("BASOROP_ER")]
            lBASOROPList,

            //Code_SRC
            /// <summary>
            /// CODE_SRC.CODEGROUP in (NHILIST,OPROOM,ANESTHESIA,NOTPRINT,CHKTOSUG,PLANA)
            /// </summary>
            [Display(Name = "AllResultList")]
            [Description("CODE_SRC")]
            AllResultList,

            //身分確認
            [Display(Name = "typeCodeList")]
            [Description("PATIENTGROUP")]
            typeCodeList,
            [Display(Name = "insTypeList")]
            [Description("CODE_SRC")]
            insTypeList,
            [Display(Name = "caseTypeList")]
            [Description("BASCASE")]
            caseTypeList,
            [Display(Name = "partTypeList")]
            [Description("BASPART")]
            partTypeList,
            [Display(Name = "vipdefList")]
            [Description("VIP_DEF")]
            vipdefList,
            [Display(Name = "giveTypeList")]
            [Description("CODE_SRC")]
            giveTypeList,
            [Display(Name = "treatItemList")]
            [Description("CODE_SRC")]
            treatItemList,
            [Display(Name = "identityCheckList")]
            [Description("IDENTITYCHECK")]
            identityCheckList,
            [Display(Name = "othPayList")]
            [Description("CODE_SRC")]
            othPayList,
            [Display(Name = "itemList")]
            [Description("CODE_SRC")]
            itemList,
            [Display(Name = "referralList")]
            [Description("REFERRALRECORD")]
            referralList
        }
        #endregion

        #region OPD ClinicRoom RadMenuItem Enum
        /// <summary>
        /// 上方MenuItem Title Name, Display(Name = "中文名", Description = "階層深度", GroupName = "父階層名稱", Order="階層排序")
        /// </summary>
        public enum OPDClinicRoom_MenuItemTitle
        {
            /// <summary>
            /// 醫師報到
            /// </summary>
            [Display(Name = "醫師報到", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            DoctorCheckIn,
            /// <summary>
            /// 護理功能
            /// </summary>
            [Display(Name = "護理功能", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            NurseFunction,
            /// <summary>
            /// 病患特診
            /// </summary>
            [Display(Name = "病患特診", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            PatientConsultation,
            /// <summary>
            /// 病患特診-牙科
            /// </summary>
            [Display(Name = "牙科", Description = "1", GroupName = nameof(PatientConsultation))]
            [Description(nameof(PatientConsultation))]
            PatientConsultationDentistry,
            /// <summary>
            /// 藥衛材特檢
            /// </summary>
            [Display(Name = "藥衛材特檢", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            MedicineEisaiSpecialInspection,
            /// <summary>
            /// 特殊病歷通報
            /// </summary>
            [Display(Name = "特殊病歷通報", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            SpecialMedicalRecordNotification,
            /// <summary>
            /// 通報篩檢
            /// </summary>
            [Display(Name = "通報篩檢", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            NotificationScreening,
            /// <summary>
            /// 專科功能
            /// </summary>
            [Display(Name = "專科(１)", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            MedicalSpecialtyFunction1,
            /// <summary>
            /// 專科功能
            /// </summary>
            [Display(Name = "專科(２)", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            MedicalSpecialtyFunction2,
            /// <summary>
            /// 健兒門診表單
            /// </summary>
            [Display(Name = "健兒門診表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            PediatricsForm,
            /// <summary>
            /// 腎臟科表單
            /// </summary>
            [Display(Name = "腎臟科表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            NephrologyForm,
            /// <summary>
            /// 糖尿病表單
            /// </summary>
            [Display(Name = "糖尿病表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            DiabetesForm,
            /// <summary>
            /// 精神科表單
            /// </summary>
            [Display(Name = "精神科表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            PsychiatricForm,
            /// <summary>
            /// 轉介單
            /// </summary>
            [Display(Name = "轉介單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            ReferralForm,
            /// <summary>
            /// 復健科表單
            /// </summary>
            [Display(Name = "復健科表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            RehabilitationForm,
            /// <summary>
            /// 其他表單
            /// </summary>
            [Display(Name = "其他表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            OtherForm,
            /// <summary>
            /// 電子病歷
            /// </summary>
            [Display(Name = "電子病歷", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            ElectronicMedicalRecord,
            /// <summary>
            /// 資源共享
            /// </summary>
            [Display(Name = "資源共享", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            ResourceSharing,

            /// <summary>
            /// 設定說明
            /// </summary>
            [Display(Name = "設定說明", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            SettingAssistant,
            /// <summary>
            /// 表單列印-牙科表單
            /// </summary>
            [Display(Name = "牙科表單", Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            MedicalSpecialtyFunction2Dentistry
        }
        /// <summary>
        /// 門診診間 項目 Display(Name = "中文名", Description = "階層深度", GroupName = "父階層名稱", Order="階層排序"), 
        /// AutoGenerateField = false(UI上已經有，故程式碼不自動產生項目) 
        /// ShortName = "IDENTITYCHECK.KIND 子群組編碼(SPECDOCREG特殊掛號使用)"
        /// </summary>
        [Description("")]
        public enum OPDClinicRoom_MenuItem
        {
            /// <summary>
            /// NULL
            /// </summary>
            [Display(Name = "初始值", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            NULL = 0,

            #region MedicalSpecialtyFunction2Dentistry 表單列印-牙科表單

            /// <summary>
            /// 表單下載
            /// </summary>
            [Display(Name = "表單下載", AutoGenerateField = true, Description = "2", GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_DocumentDownload,

            /// <summary>
            /// 門診教學同意書
            /// </summary>
            [Display(Name = "門診教學同意書", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_OPDTeachingConsentForm,

            /// <summary>
            /// 院外影像影像同意書
            /// </summary>
            [Display(Name = "院外影像影像同意書", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_OutOfHospitalRISConsentForm,

            /// <summary>
            /// 院外影像回覆單
            /// </summary>
            [Display(Name = "院外影像回覆單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 4)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_OutOfHospitalRISReplySheet,

            /// <summary>
            /// 健保住院自費門診同意書
            /// </summary>
            [Display(Name = "健保住院自費門診同意書", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 5)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_HealthInsuranceIPDSelfPayOPDConsentForm,

            /// <summary>
            /// 自負住院健保門診同意書
            /// </summary>
            [Display(Name = "自負住院健保門診同意書", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 6)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_SelfPayIPDHealthInsuranceOPDConsentForm,

            /// <summary>
            /// 技工單
            /// </summary>
            [Display(Name = "技工單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 7)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_MechanicSheet,

            /// <summary>
            /// 自費衛材同意書系統
            /// </summary>
            [Display(Name = "自費衛材同意書系統", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 8)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_SelfPayEisaiConsentFormSystem,

            /// <summary>
            /// 牙科就診病人清單
            /// </summary>
            [Display(Name = "牙科就診病人清單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 9)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_DentalVisitPatientCheckList,

            /// <summary>
            /// 牙科申報紀錄
            /// </summary>
            [Display(Name = "牙科申報紀錄", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 10)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_DentalDeclarationRecord,

            /// <summary>
            /// 牙科申報紀錄
            /// </summary>
            [Display(Name = "牙周病檢查紀錄表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 10)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_PeriodontalChart,

            /// <summary>
            /// 牙科申報紀錄
            /// </summary>
            [Display(Name = "牙菌斑控制紀錄表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 10)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_PlaqueControlRecord,

            #endregion MedicalSpecialtyFunction2Dentistry 表單列印-牙科表單

            /// <summary>
            /// 門診已掃描病歷
            /// </summary>
            [Display(Name = "門診已掃描病歷", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            ElectronicMedicalRecord_OPDMedicalRecordsScanned,

            #region PatientConsultation 病患特診
            /// <summary>
            /// 麻醉諮詢約診
            /// </summary>
            [Display(Name = "麻醉諮詢約診", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_AnesthesiaConsultationAppointments,
            /// <summary>
            /// COVID-19 TOCC
            /// </summary>
            [Display(Name = "COVID-19 TOCC", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_COVID19_TOCC,
            /// <summary>
            /// 兒童聽力篩檢掛號
            /// </summary>
            [Display(Name = "兒童聽力篩檢掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_ChildrensHearingScreeningRegistration,
            /// <summary>
            /// 婦女子宮頸抹片掛號
            /// </summary>
            [Display(Name = "婦女子宮頸抹片掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "9")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_WomensPapSmearRegistration,

            /// <summary>
            /// 口腔篩檢特別門診
            /// </summary>
            [Display(Name = "口腔篩檢特別門診", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "1")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_Dentistry_OralScreeningSpecialClinic,
            /// <summary>
            /// 大腸直腸篩檢
            /// </summary>
            [Display(Name = "大腸直腸篩檢", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "11")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_ColorectalScreening,
            /// <summary>
            /// ESRD掛號
            /// </summary>
            [Display(Name = "Pre-ESRD掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_PreESRDRegistration,
            /// <summary>
            /// AKD掛號
            /// </summary>
            [Display(Name = "AKD掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "4")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_AKDRegistration,
            /// <summary>
            /// AKD健保藥事照護掛號
            /// </summary>
            [Display(Name = "AKD健保藥事照護掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "10")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_AKDHealthCarePharmacyCareRegistration,
            /// <summary>
            /// CKD掛號
            /// </summary>
            [Display(Name = "CKD掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_CKDRegistration,
            /// <summary>
            /// CKD健保藥事照護掛號
            /// </summary>
            [Display(Name = "CKD健保藥事照護掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "5")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_PreESRDPharmacyCareRegistration,
            /// <summary>
            /// 抗凝血健保藥事照護掛號
            /// </summary>
            [Display(Name = "抗凝血健保藥事照護掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_ACDrugPharmacyCareRegistration,
            /// <summary>
            /// 代謝症候群特殊照護門診掛號
            /// </summary>
            [Display(Name = "代謝症候群特殊照護門診掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            MatabolicSyndromeSpecialCareRegistration,
            /// <summary>
            /// 弱勢兒童預防保健
            /// </summary>
            [Display(Name = "弱勢兒童預防保健", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry)
                , ShortName = "2")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry))]
            PatientConsultation_Dentistry_PreventiveCareForVulnerableChildren,
            /// <summary>
            /// 國小兒童窩溝封填掛號
            /// </summary>
            [Display(Name = "國小兒童窩溝封填掛號", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry))]
            PatientConsultation_Dentistry_PitAndFissureSealingRegistrationForElementarySchoolChildren,
            /// <summary>
            /// 兒童塗氟掛號
            /// </summary>
            [Display(Name = "兒童塗氟掛號", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry))]
            PatientConsultation_Dentistry_ChildrenFluorideCoatingRegistration,
            /// <summary>
            /// 戒菸門診特殊掛號
            /// </summary>
            [Display(Name = "戒菸門診特殊掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "3")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_Dentistry_SmokingCessationClinicSpecialRegistration,
            /// <summary>
            /// 藥酒癮特約診掛號
            /// </summary>
            [Display(Name = "藥酒癮特約診掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "7")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_DrugAlcoholAddictionSpecialConsultation,

            #endregion PatientConsultation 病患特診

            #region NotificationScreening 通報篩檢
            /// <summary>
            /// 傳染病通報
            /// </summary>
            [Display(Name = "傳染病通報", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            NotificationScreening_InfectiousDiseaseNotification,

            /// <summary>
            /// 性病愛滋篩檢
            /// </summary>
            [Display(Name = "性病愛滋篩檢", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening)
                , ShortName = "8")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            NotificationScreening_STDHIVScreening,

            /// <summary>
            /// 孕婦愛滋篩檢
            /// </summary>
            [Display(Name = "孕婦愛滋篩檢", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            NotificationScreening_HIVScreeningPregnantWomen,

            /// <summary>
            /// 感染肝炎科掛號
            /// </summary>
            [Display(Name = "感染肝炎科掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening)
                , ShortName = "12")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            NotificationScreening_InfectionHepatitisDepartmentRegistration,

            /// <summary>
            /// 登革熱快篩特約掛號
            /// </summary>
            [Display(Name = "登革熱快篩特約掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening)
                , ShortName = "6")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            NotificationScreening_DengueFeverScreening,
            #endregion NotificationScreening 通報篩檢

            #region MedicalSpecialtyFunction2 專科掛號2
            /// <summary>
            /// 列印BioBank保存申請書*1 + 參與者同意書*2
            /// </summary>
            [Display(Name = "列印BioBank保存申請書*1 + 參與者同意書*2", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            MedicalSpecialtyFunction2_BioBankParticipantAndParticipantConsentForm,

            #region PediatricsClinicForm 健兒門診表單
            /// <summary>
            /// 健兒門診預防保健
            /// </summary>
            [Display(Name = "健兒門診預防保健", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm))]
            PediatricsForm_Vaccination,
            /// <summary>
            /// 健兒門診病人施打疫苗查詢與列印報表
            /// </summary>
            [Display(Name = "健兒門診病人施打疫苗查詢與列印報表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm))]
            PediatricsForm_VaccinationInquiryAndPrintReport,
            /// <summary>
            /// 健兒門診年齡統計
            /// </summary>
            [Display(Name = "健兒門診年齡統計", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm))]
            PediatricsForm_AgeStatistics,
            /// <summary>
            /// 台北市兒童諮詢申請總表
            /// </summary>
            [Display(Name = "台北市兒童諮詢申請總表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm))]
            PediatricsForm_TaipeiCityChildrenConsultationApplicationForm,
            #endregion PediatricsClinicForm 健兒門診表單

            #region NephrologyForm 腎臟科表單
            /// <summary>
            /// 列印慢性腎臟病CKD個案照護營養紀錄單
            /// </summary>
            [Display(Name = "列印慢性腎臟病CKD個案照護營養紀錄單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm))]
            NephrologyForm_PrintChronicKidneyDiseaseIndividualCareNutritionRecordSheet,
            /// <summary>
            /// 列印腎臟科CKD個案管理紀錄表
            /// </summary>
            [Display(Name = "列印腎臟科CKD個案管理紀錄表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm))]
            NephrologyForm_PrintTheNephrologyCKDCaseManagementRecordForm,
            /// <summary>
            /// 腎臟科照護檢核
            /// </summary>
            [Display(Name = "腎臟科照護檢核", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm))]
            NephrologyForm_NephrologyCareCheck,
            /// <summary>
            /// CKD個案追蹤照護病歷表
            /// </summary>
            [Display(Name = "CKD個案追蹤照護病歷表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm), Order = 4)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm))]
            NephrologyForm_CKDCaseTraceMedRecord,
            #endregion NephrologyForm 腎臟科表單

            #region DiabetesForm 糖尿病表單
            /// <summary>
            /// 糖尿病病人檢核
            /// </summary>
            [Display(Name = "糖尿病病人檢核", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm))]
            DiabetesForm_DiabetesPatientCheck,
            /// <summary>
            /// 糖尿病病患衛教紀錄檔
            /// </summary>
            [Display(Name = "糖尿病病患衛教紀錄檔", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm))]
            DiabetesForm_DMPHERecord,
            /// <summary>
            /// 糖尿病照護碼與糖尿病收案碼配對檢查
            /// </summary>
            [Display(Name = "糖尿病照護碼與糖尿病收案碼配對檢查", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm))]
            DiabetesForm_DiabetesCareCodeAndAcceptCaseCodePairingCheck,
            /// <summary>
            /// 列印糖尿病衛教紀錄首頁
            /// </summary>
            [Display(Name = "列印糖尿病衛教紀錄首頁", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm), Order = 4)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm))]
            DiabetesForm_PrintFirstPageOfDiabeteshealthEducationRecord,
            #endregion  DiabetesForm 糖尿病表單

            #region PsychiatricForm 精神科表單
            /// <summary>
            /// 列印精神科檢查治療轉介單
            /// </summary>
            [Display(Name = "列印精神科檢查治療轉介單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm))]
            PsychiatricForm_PrintReferralFormForPsychiatricExaminationAndTreatment,
            /// <summary>
            /// 列印精神科RTMS療轉介單
            /// </summary>
            [Display(Name = "列印精神科RTMS治療轉介單", AutoGenerateField = false, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm))]
            PsychiatricForm_PrintReferralFormForPsychiatricRTMSTreatment,
            /// <summary>
            /// 列印精神科檢查治療轉介單(Brain Mapping)
            /// </summary>
            [Display(Name = "列印精神科檢查治療轉介單(Brain Mapping)", AutoGenerateField = false, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm))]
            PsychiatricForm_PrintReferralFormForPsychiatricBrainMappingExaminationAndTreatment,

            #endregion PsychiatricForm 精神科表單

            #region OtherForm 其他表單
            /// <summary>
            /// 禽畜業者發燒通報單
            /// </summary>
            [Display(Name = "禽畜業者發燒通報單", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.OtherForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.OtherForm))]
            OtherForm_LivestockerFeverNotice,

            /// <summary>
            /// 自費藥品退藥條件表
            /// </summary>
            [Display(Name = "自費藥品退藥條件表", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.OtherForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.OtherForm))]
            OtherForm_PayselfMedReturnCondition,
            #endregion OtherForm 其他表單
            /// <summary>
            /// 小兒部生長曲線
            /// </summary>
            [Display(Name = "小兒部生長曲線", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            MedicalSpecialtyFunction2_PediatricGrowthCurve,
            /// <summary>
            /// 列印LDC表單
            /// </summary>
            [Display(Name = "列印LDC表單", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            MedicalSpecialtyFunction2_PrintLDCForm,

            /// <summary>
            /// 列印自殺防治通報單(含BSRS)
            /// </summary>
            [Display(Name = "列印自殺防治通報單(含BSRS)", AutoGenerateField = true, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            MedicalSpecialtyFunction2_PrintBSRSData,

            #region ReferralForm 轉介單
            /// <summary>
            /// 心率睡眠儀檢查轉介單
            /// </summary>
            [Display(Name = "心率睡眠儀檢查轉介單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ReferralForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ReferralForm))]
            ReferralForm_HeartRateSleepMeterExaminationReferralForm,
            /// <summary>
            /// 新陳代謝科洗牙轉介單
            /// </summary>
            [Display(Name = "新陳代謝科洗牙轉介單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ReferralForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ReferralForm))]
            ReferralForm_MetabolismDepartmentTeethCleaningReferralForm,
            /// <summary>
            /// 婦產科洗牙轉介單
            /// </summary>
            [Display(Name = "婦產科洗牙轉介單:", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ReferralForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ReferralForm))]
            ReferralForm_ObstetricsAndGynecologyTeethCleaningReferralForm,
            #endregion ReferralForm 轉介單

            #region 復健科表單
            /// <summary>
            /// 復健治療明細表
            /// </summary>
            [Display(Name = "復健治療明細表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm))]
            RehabilitationForm_REHTreatDetail,
            /// <summary>
            /// 復健醫學部治療紀錄表
            /// </summary>
            [Display(Name = "復健醫學部治療紀錄表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm))]
            RehabilitationForm_REHTreatRecord,
            /// <summary>
            /// 治療紀錄表診斷及處置
            /// </summary>
            [Display(Name = "治療紀錄表診斷及處置", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm))]
            RehabilitationForm_REHTerapyRec,

            #endregion

            #endregion MedicalSpecialtyFunction2 專科掛號2

            #region ResourceSharing 資源共享
            /// <summary>
            /// 醫病共享決策執行紀錄表
            /// </summary>
            [Display(Name = "醫病共享決策執行紀錄表", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ResourceSharing))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ResourceSharing))]
            ResourceSharing_MedicalShareExecuteRecordForm,
            #endregion ResourceSharing 資源共享

            #region ElectronicMedicalRecord 電子病歷
            /// <summary>
            /// 機敏性病歷
            /// </summary>
            [Display(Name = "機敏性病歷", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            ElectronicMedicalRecord_ConfidentialMedicalRecord,
            /// <summary>
            /// 列印報告黏貼單
            /// </summary>
            [Display(Name = "列印報告黏貼單", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            ElectronicMedicalRecord_RPTPasteForm,
            #endregion ElectronicMedicalRecord 電子病歷

            #region NurseFunction 護理功能
            /// <summary>
            /// 預防保健暨戒菸服務
            /// </summary>
            [Display(Name = "預防保健暨戒菸服務", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NurseFunction))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NurseFunction))]
            NurseFunction_PreventiveHealthCareAndSmokingCessationService,

            #endregion NurseFunction 護理功能

            #region 說明

            /// <summary>
            /// 讀取資料庫健保VPN相關讀卡功能狀態註記
            /// </summary>
            [Display(Name = "健保VPN相關讀卡功能狀態[有\u221a為啟用讀寫卡功能]", AutoGenerateField = true, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.SettingAssistant)
                , ShortName = "")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.SettingAssistant))]
            SettingAssistant_ReloadNHIVPN_API_State,

            #endregion

        }
        #endregion OPD ClinicRoom RadMenuItem Enum

        #region OPD ClinicRoom AddBatchOrders Enum 門診診間 統一醫令接口
        /// <summary>
        /// OPD ClinicRoom AddBatchOrders Enum 門診診間 統一醫令接口
        /// </summary>
        public enum OPD_ClinicRoom_AddBatchOrders_Enum
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "Null")]
            [Description("OPD.Null")]
            NULL,
            /// <summary>
            /// AddBatchOrder[由程式新增，跳過手開某些限制規則]
            /// </summary>
            [Display(Name = "新增")]
            [Description("OPD._Order")]
            AddBatchOrder,
            /// <summary>
            /// UserAddingRow[使用者輸入]
            /// </summary>
            [Display(Name = "手動新增")]
            [Description("OPD.Order")]
            UserAddingRow,
            /// <summary>
            /// UserAddedRow[使用者輸入]
            /// </summary>
            [Display(Name = "手動新增")]
            [Description("OPD.Order")]
            UserAddedRow,
            /// <summary>
            /// UserDeletingRow
            /// </summary>
            [Display(Name = "手動刪除")]
            [Description("OPD.Deleting")]
            UserDeletingRow,
            /// <summary>
            /// UserDeletedRow
            /// </summary>
            [Display(Name = "手動刪除")]
            [Description("OPD.Deleted")]
            UserDeletedRow,
            /// <summary>
            /// 進入診間時複查
            /// </summary>
            [Display(Name = "進入診間時複查")]
            [Description("OPD.OpenCheck")]
            OpenAndCheck,
            /// <summary>
            /// 套餐
            /// </summary>
            [Display(Name = "套餐")]
            [Description("OPD.SetMenu")]
            PackageOrder,
            /// <summary>
            /// 一帶多
            /// </summary>
            [Display(Name = "一帶多")]
            [Description("OPD.Pack")]
            PackOrder,
            /// <summary>
            /// LIS檢驗
            /// </summary>
            [Display(Name = "LIS檢驗")]
            [Description("OPD.Lab&Rad")]
            LIS,
            /// <summary>
            /// PACS放射檢查
            /// </summary>
            [Display(Name = "PACS放射檢查")]
            [Description("OPD.Lab&Rad")]
            PACS,
            /// <summary>
            /// 歷次就醫
            /// </summary>
            [Display(Name = "歷次就醫")]
            [Description("OPD.History")]
            TriHistoryMedicalForm,
            /// <summary>
            /// 復健
            /// </summary>
            [Display(Name = "復健")]
            [Description("OPD.Reh")]
            RehabilitationForm,
            /// <summary>
            /// 輸液視窗
            /// </summary>
            [Display(Name = "輸液")]
            [Description("OPD.Infusion")]
            InfusionForm,
            /// <summary>
            /// 常用品項
            /// </summary>
            [Display(Name = "常用品項")]
            [Description("OPD.CommonOrder")]
            CommonOrder,
            /// <summary>
            /// 四癌篩檢
            /// </summary>
            [Display(Name = "四癌篩檢")]
            [Description("OPD.Cancer")]
            Cancer,
            /// <summary>
            /// 出院帶藥帶入
            /// </summary>
            [Display(Name = "出院帶藥帶入")]
            [Description("OPD.OutHospDrug")]
            OutHospDrugOrder,
            /// <summary>
            /// 資源共享
            /// </summary>
            [Display(Name = "資源共享")]
            [Description("OPD.Resource")]
            ResourceShare
        }
        #endregion OPD ClinicRoom AddBatchOrders Enum 門診診間 統一醫令接口

        #region OPD ClinicRoom SpiltOrder

        /// <summary>
        /// OPD.ClinicRoom SplitOrder 使用之 Dictionary Enum
        /// </summary>
        public enum OpdClinicRoomSplitOrder
        {
            /// <summary>
            /// 新增
            /// </summary>
            [Description("A")]
            Add,
            /// <summary>
            /// 刪除
            /// </summary>
            [Description("D")]
            Delete,
            /// <summary>
            /// 先刪除後新增
            /// </summary>
            [Description("U")]
            Update,
            /// <summary>
            /// 未更動之醫令
            /// </summary>
            [Description("S")]
            Source,
        }

        /// <summary>
        /// 一次領慢籤事由
        /// </summary>
        public enum TakeAllReason
        {
            /// <summary>
            /// 預定出國
            /// </summary>
            [Display(Name = "VMCH80002")]
            [Description("預定出國")]
            H8,
            /// <summary>
            /// 返回離島地區
            /// </summary>
            [Display(Name = "VMCHA0002")]
            [Description("返回離島地區")]
            HA,
            /// <summary>
            /// 已出海為遠洋漁船作業船員
            /// </summary>
            [Display(Name = "VMCHB0002")]
            [Description("已出海為遠洋漁船作業船員")]
            HB,
            /// <summary>
            /// 已出海為國際航線船舶作業船員
            /// </summary>
            [Display(Name = "VMCHC0002")]
            [Description("已出海為國際航線船舶作業船員")]
            HC,
            /// <summary>
            /// 罕見疾病病人
            /// </summary>
            [Display(Name = "VMCHD0002")]
            [Description("罕見疾病病人")]
            HD
        }
        /// <summary>
        /// 特殊治療代碼
        /// </summary>
        public enum SID_TYPE
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "")]
            [Description("Null")]
            Null,
            #region A

            /// <summary>
            /// A1 特定治療代碼(超音波檢查)
            /// </summary>
            [Display(Name = "超音波檢查")]
            [Description("A1")]
            A1,
            /// <summary>
            /// A2 特定治療代碼(耳鼻喉科檢查)
            /// </summary>
            [Display(Name = "超音波檢查")]
            [Description("A2")]
            A2,
            /// <summary>
            /// A3 特定治療代碼(內視鏡檢查)
            /// </summary>
            [Display(Name = "內視鏡檢查")]
            [Description("A3")]
            A3,
            /// <summary>
            /// A4 特定治療代碼(病理組織檢查)
            /// </summary>
            [Display(Name = "病理組織檢查")]
            [Description("A4")]
            A4,
            /// <summary>
            /// A5 特定治療代碼(核子醫學檢查)
            /// </summary>
            [Display(Name = "核子醫學檢查")]
            [Description("A5")]
            A5,
            /// <summary>
            /// A6 特定治療代碼(X光檢查)
            /// </summary>
            [Display(Name = "X光檢查")]
            [Description("A6")]
            A6,
            /// <summary>
            /// A7 特定治療代碼(特殊造影檢查)
            /// </summary>
            [Display(Name = "特殊造影檢查")]
            [Description("A7")]
            A7,
            /// <summary>
            /// A8 特定治療代碼(神經科檢查)
            /// </summary>
            [Display(Name = "神經科檢查")]
            [Description("A8")]
            A8,
            #endregion

            #region D

            /// <summary>
            /// D0 特定治療代碼(物理治療簡單、中度治療)
            /// </summary>
            [Display(Name = "物理治療簡單、中度治療")]
            [Description("D0")]
            D0,
            /// <summary>
            /// D1 特定治療代碼(癌症放射線治療)
            /// </summary>
            [Display(Name = "癌症放射線治療")]
            [Description("D1")]
            D1,
            /// <summary>
            /// D2 特定治療代碼(癌症化學治療)
            /// </summary>
            [Display(Name = "癌症化學治療")]
            [Description("D2")]
            D2,
            /// <summary>
            /// D3 特定治療代碼(復健治療（物理治療簡單、中度治療除外）)
            /// </summary>
            [Display(Name = "復健治療（物理治療簡單、中度治療除外）")]
            [Description("D3")]
            D3,
            /// <summary>
            /// D4 特定治療代碼(精神科治療)
            /// </summary>
            [Display(Name = "精神科治療")]
            [Description("D4")]
            D4,
            /// <summary>
            /// D5 特定治療代碼(高壓氧治療)
            /// </summary>
            [Display(Name = "高壓氧治療")]
            [Description("D5")]
            D5,
            /// <summary>
            /// D6 特定治療代碼(眼科鐳射治療)
            /// </summary>
            [Display(Name = "眼科鐳射治療")]
            [Description("D6")]
            D6,
            /// <summary>
            /// D8 特定治療代碼 (血液透析治療)
            /// </summary>
            [Display(Name = "血液透析治療")]
            [Description("D8")]
            D8,
            /// <summary>
            /// D9 特定治療代碼(腹膜透析)
            /// </summary>
            [Display(Name = "腹膜透析")]
            [Description("D9")]
            D9,

            #endregion

            #region E

            /// <summary>
            /// E1 特定治療代碼(腸病毒)
            /// </summary>
            [Display(Name = "腸病毒")]
            [Description("E1")]
            E1,
            /// <summary>
            /// E2 支援長期照護機構提供一般門診案件
            /// </summary>
            [Display(Name = "支援長期照護機構提供一般門診案件")]
            [Description("E2")]
            E2,
            /// <summary>
            /// E4 特定治療代碼(DM糖尿病照護費)
            /// </summary>
            [Display(Name = "DM糖尿病照護費")]
            [Description("E4")]
            E4,
            /// <summary>
            /// E5 週產期論人支付制度試辦計畫
            /// </summary>
            [Display(Name = "週產期論人支付制度試辦計畫")]
            [Description("E5")]
            E5,
            /// <summary>
            /// E6 特定治療代碼(氣喘)
            /// </summary>
            [Display(Name = "氣喘")]
            [Description("E6")]
            E6,
            /// <summary>
            /// E8 特定治療代碼(高血壓)
            /// </summary>
            [Display(Name = "高血壓")]
            [Description("E8")]
            E8,
            /// <summary>
            ///EB 特定治療代碼(初期慢性腎臟病醫療給付改善方案)
            /// </summary>
            [Display(Name = "初期慢性腎臟病醫療給付改善方案")]
            [Description("EB")]
            EB,
            /// <summary>
            /// EC 全民健康保險居家醫療照護整合計畫
            /// </summary>
            [Display(Name = "全民健康保險居家醫療照護整合計畫")]
            [Description("EC")]
            EC,
            /// <summary>
            ///EG 潛伏結核感染治療品質支付服務計畫
            /// </summary>
            [Display(Name = "潛伏結核感染治療品質支付服務計畫")]
            [Description("EG")]
            EG,
            /// <summary>
            ///EH 愛滋照護管理品質計畫
            /// </summary>
            [Display(Name = "愛滋照護管理品質計畫")]
            [Description("EH")]
            EH,
            /// <summary>
            ///EJ 長照機構加強型結核病防治計畫
            /// </summary>
            [Display(Name = "長照機構加強型結核病防治計畫")]
            [Description("EJ")]
            EJ,
            /// <summary>
            ///EK 特定治療代碼(糖尿病合併初期腎臟病照護)
            /// </summary>
            [Display(Name = "糖尿病合併初期腎臟病照護")]
            [Description("EK")]
            EK,
            #endregion

            #region F

            /// <summary>
            /// FP 特定治療代碼(牙周病統合照護第一階段)
            /// </summary>
            [Display(Name = "牙周病統合照護第一階段")]
            [Description("FP")]
            FP,
            /// <summary>
            /// FQ 特定治療代碼(牙周病統合照護第二階段)
            /// </summary>
            [Display(Name = "牙周病統合照護第二階段")]
            [Description("FQ")]
            FQ,
            /// <summary>
            /// FR 特定治療代碼(牙周病統合照護第三階段)
            /// </summary>
            [Display(Name = "牙周病統合照護第三階段")]
            [Description("FR")]
            FR,

            #endregion

            #region H

            /// <summary>
            /// H1 特定治療代碼(肝炎試辦計畫)
            /// </summary>
            [Display(Name = "肝炎試辦計畫")]
            [Description("H1")]
            H1,
            /// <summary>
            /// H2 西醫-行動不便者，經醫師認定或經受託人提供切結文件，慢性病代領藥案件(96.7增訂；101.11修訂文字)
            /// </summary>
            [Display(Name = "慢性病代領藥案件-行動不便者")]
            [Description("H2")]
            H2,
            /// <summary>
            /// H3 西醫-已出海為遠洋漁船作業船員，提供切結文件，慢性病代領藥案件(96.7增訂：101.11修訂文字)
            /// </summary>
            [Display(Name = "慢性病代領藥案件-已出海為遠洋漁船作業船員")]
            [Description("H3")]
            H3,
            /// <summary>
            /// H6 西醫-已出海為國際航線船舶作業船員，提供切結文件，慢性病代領藥案件(97.10增訂；101.11修訂文字)
            /// </summary>
            [Display(Name = "慢性病代領藥案件-已出海為國際航線船舶作業船員")]
            [Description("H6")]
            H6,
            /// <summary>
            /// H7 特定治療代碼(全民健康保險B型肝炎帶原者及C型肝炎感染者醫療給付改善方案)
            /// </summary>
            [Display(Name = "全民健康保險B型肝炎帶原者及C型肝炎感染者醫療給付改善方案")]
            [Description("H7")]
            H7,
            /// <summary>
            /// H8 西醫-持慢性病連續處方箋領藥，預定出國，提供切結文件，一次領取2個月或3個月用藥量案件
            /// </summary>
            [Display(Name = "預定出國")]
            [Description("H8")]
            H8,
            /// <summary>
            /// H9 經保險人認定之特殊情形，慢性病代領藥案件（101.11新增）。
            /// </summary>
            [Display(Name = "慢性病代領藥案件-經保險人認定之特殊情形")]
            [Description("H9")]
            H9,
            /// <summary>
            /// HA 西醫-持慢性病連續處方箋領藥，返回離島地區，提供切結文件，一次領取2個月或3個月用藥量案件（101.11新增）。
            /// </summary>
            [Display(Name = "返回離島地區")]
            [Description("HA")]
            HA,
            /// <summary>
            /// HB 西醫-持慢性病連續處方箋領藥，已出海為遠洋漁船作業船員，提供切結文件，一次領取2個月或3個月用藥量案件（101.11新增）。
            /// </summary>
            [Display(Name = "已出海為遠洋漁船作業船員")]
            [Description("HB")]
            HB,
            /// <summary>
            /// HC 西醫-持慢性病連續處方箋領藥，已出海為國際航線船舶作業船員，提供切結文件，一次領取2個月或3個月用藥案件
            /// </summary>
            [Display(Name = "已出海為國際航線船舶作業船員")]
            [Description("HC")]
            HC,
            /// <summary>
            /// HD 西醫-持慢性病連續處方箋領藥，罕見疾病病人，提供切結文件，一次領取2個月或3個月用藥案件
            /// </summary>
            [Display(Name = "罕見疾病病人")]
            [Description("HD")]
            HD,
            /// <summary>
            /// HE 特定治療代碼(C型肝炎全口服治療)
            /// </summary>
            [Display(Name = "C型肝炎全口服治療")]
            [Description("HE")]
            HE,
            /// <summary>
            /// HF 特定治療代碼(慢性阻塞性肺病醫療給付改善方案)
            /// </summary>
            [Display(Name = "慢性阻塞性肺病醫療給付改善方案")]
            [Description("HF")]
            HF,
            /// <summary>
            /// HM 特定治療代碼(大腸癌追蹤管理)
            /// </summary>
            [Display(Name = "大腸癌追蹤管理")]
            [Description("HM")]
            HM,
            /// <summary>
            /// HN 特定治療代碼(大腸癌診斷品質管理)
            /// </summary>
            [Display(Name = "大腸癌診斷品質管理")]
            [Description("HN")]
            HN,
            /// <summary>
            /// HP 特定治療代碼(口腔癌追蹤管理)
            /// </summary>
            [Display(Name = "口腔癌追蹤管理")]
            [Description("HP")]
            HP,
            /// <summary>
            /// HQ 特定治療代碼(口腔癌診斷品質管理)
            /// </summary>
            [Display(Name = "口腔癌診斷品質管理")]
            [Description("HQ")]
            HQ,
            /// <summary>
            /// HR 特定治療代碼(子宮頸癌追蹤管理)
            /// </summary>
            [Display(Name = "子宮頸癌追蹤管理")]
            [Description("HR")]
            HR,
            /// <summary>
            /// HS 特定治療代碼(子宮頸癌診斷品質管理)
            /// </summary>
            [Display(Name = "子宮頸癌診斷品質管理")]
            [Description("HS")]
            HS,
            /// <summary>
            /// HT 特定治療代碼(乳癌追蹤管理)
            /// </summary>
            [Display(Name = "乳癌追蹤管理")]
            [Description("HT")]
            HT,
            /// <summary>
            /// HW 特定治療代碼(乳癌診斷品質管理)
            /// </summary>
            [Display(Name = "乳癌診斷品質管理")]
            [Description("HW")]
            HW,
            /// <summary>
            /// HX 特定治療代碼(肺癌追蹤管理)
            /// </summary>
            [Display(Name = "肺癌追蹤管理")]
            [Description("HX")]
            HX,
            /// <summary>
            /// HY 特定治療代碼(肺癌診斷品質管理)
            /// </summary>
            [Display(Name = "肺癌診斷品質管理")]
            [Description("HY")]
            HY,

            #endregion

            #region K

            /// <summary>
            /// K1 特定治療代碼(Pre-ESRD預防性計畫及病人衛教計畫)
            /// </summary>
            [Display(Name = "Pre-ESRD預防性計畫及病人衛教計畫")]
            [Description("K1")]
            K1,
            /// <summary>
            /// K3 特定治療代碼(洗腎相關)
            /// </summary>
            [Display(Name = "洗腎相關")]
            [Description("K3")]
            K3,

            #endregion

            #region P

            /// <summary>
            /// P1 特定治療代碼(根管治療)
            /// </summary>
            [Display(Name = "根管治療")]
            [Description("P1")]
            P1,
            /// <summary>
            /// P2 特定治療代碼(銀粉充填)
            /// </summary>
            [Display(Name = "銀粉充填")]
            [Description("P2")]
            P2,
            /// <summary>
            /// P3 特定治療代碼(複合樹脂[玻璃璃子]充填)
            /// </summary>
            [Display(Name = "複合樹脂[玻璃璃子]充填")]
            [Description("P3")]
            P3,
            /// <summary>
            /// P4 特定治療代碼(牙周病手術[含齒齦下刮除術])
            /// </summary>
            [Display(Name = "牙周病手術[含齒齦下刮除術]")]
            [Description("P4")]
            P4,
            /// <summary>
            /// P5 特定治療代碼(兒童斷髓處理)
            /// </summary>
            [Display(Name = "兒童斷髓處理")]
            [Description("P5")]
            P5,
            /// <summary>
            /// P7 特定治療代碼(口腔外科門診手術[包括拔牙])
            /// </summary>
            [Display(Name = "腔外科門診手術[包括拔牙]")]
            [Description("P7")]
            P7,
            /// <summary>
            /// P8 特定治療代碼(治療性牙結石清除)
            /// </summary>
            [Display(Name = "治療性牙結石清除")]
            [Description("P8")]
            P8,

            #endregion

        }



        /// <summary>
        /// 可作為慢籤的事審品項
        /// </summary>
        public enum CanSlowProject
        {
            [Description("005AGR01")]
            VC00007100,

            [Description("005AUB01")]
            VC00038100,

            [Description("005TEC03")]
            VC00039100,

            [Description("005TEC04")]
            VC00040100,

            [Description("005DAC03")]
            BC26354248,

            [Description("005DEM07")]
            BC27930248,

            [Description("005ANA05")] //20241226秀文姊來信新增
            VC00062100
        }

        #endregion OPD ClinicRoom SpiltOrder

        /// <summary>
        /// 商之器上傳類別
        /// </summary>
        public enum EBMRequestType
        {
            /// <summary>
            /// 放射
            /// </summary>
            Radiation,
            
            /// <summary>
            /// 報告
            /// </summary>
            ReportExam,
            
            /// <summary>
            /// 牙科放射
            /// </summary>
            DentalRadiation,
            
            /// <summary>
            /// 自動排程
            /// </summary>
            AutoScheduler
        }

        #region IDENTITYCHECK DROPDOWN CHANGED USE METHOD NAME 身分別下拉選單使用相關規則名稱
        /// <summary>
        /// 身分別下拉選單使用相關規則名稱[命名規則(類別_區域_描述):(VISITKIND)_(SECTIONNAME)_(DESCRIPTION)]
        /// </summary>
        public enum IdentityCheckChanged_UseMethodName
        {
            /// <summary>
            /// 初始值
            /// </summary>
            NULL = 0,
            /// <summary>
            /// 門診 科別清單 身分別 醫令對照就醫序號ICXX
            /// </summary>
            OPD_DEPT_IdentityCheck_OrderCode_CardNum,
            /// <summary>
            /// 門診 牙科 CaseType 預防保健
            /// </summary>
            OPD_DENTAL_CaseType_PreventiveHealthCare,
            /// <summary>
            /// 門診 牙科 CaseType 其他專案
            /// </summary>
            OPD_DENTAL_CaseType_OtherProject,
            /// <summary>
            /// 急診 批價 身分別讀卡
            /// </summary>
            ER_CASHIER_SetIdentityByICCard,
            /// <summary>
            /// 急診 批價 身分別讀卡
            /// </summary>
            OPD_CASHIER_SetIdentityByICCard,
            /// <summary>
            /// 共用 身分別判斷 全部
            /// </summary>
            ALL_IdentityCheck_ReadALLMethod,
            /// <summary>
            /// 共用 身分別判斷 健保卡讀卡
            /// </summary>
            ALL_IdentityCheck_NHIICCard,
            /// <summary>
            /// 共用 身分別判斷 軍警消員工
            /// </summary>
            ALL_IdentityCheck_MilitaryPoliceFireManStuff,
            /// <summary>
            /// 共用 身分別判斷 掛號檔紀錄
            /// </summary>
            ALL_IdentityCheck_REG,
            /// <summary>
            /// 共用 身分別判斷 掛號檔紀錄 門診批價專用
            /// </summary>
            ALL_IdentityCheck_REG_OPDCashier,
            /// <summary>
            /// 共用 身分別判斷 掛號檔紀錄 急診批價專用
            /// </summary>
            ALL_IdentityCheck_REG_ERMCashier,
            /// <summary>
            /// 共用 身分別判斷 罕病兒童
            /// </summary>
            ALL_IdentityCheck_RareSickChildren,
            /// <summary>
            /// 共用 身分別判斷 下拉選單判斷
            /// </summary>
            ALL_IdentityCheck_DropDownListChanged,
            /// <summary>
            /// 共用 身分別判斷 下拉選單 身分類別屬於非健保(10,20,22)
            /// </summary>
            ALL_IdentityCheck_DropDownListChanged_TypeCodeNoneNHI,
            /// <summary>
            /// 牙醫總額特殊照護計畫醫令
            /// </summary>
            OPD_DENTAL_CaseType_DENBudgetSpecial,
            /// <summary>
            /// 牙科 特殊醫令 91023C
            /// </summary>
            OPD_DENTAL_PayType_91023C,
            /// <summary>
            /// 流感疫苗處置接種費
            /// </summary>
            OPD_FluVaccine_ORDERCODE,
            /// <summary>
            /// 西醫手術醫令
            /// </summary>
            OPD_ClinicSurgery_ORDERCODE,
            /// <summary>
            /// 2023/7/1 部分負擔新制規則
            /// </summary>
            OPD_20230701NewPayType,
            /// <summary>
            /// 刪除轉診單時候強制覆蓋Paytype 
            /// </summary>
            OPD_ReferralDeleteOverridePayType,
            /// <summary>
            /// 建立轉診單時,PayType進行優先權檢核
            /// </summary>
            OPD_ReferralRecordGenerate,
            /// <summary>
            /// 檢核轉診單就醫類別與部分負擔，只強制修正這兩個類別
            /// </summary>
            OPD_ReferralRecordFix,
            /// <summary>
            /// LTBI篩檢
            /// </summary>
            OPD_LTBIScreening,
            /// <summary>
            /// LTBI治療
            /// </summary>
            OPD_LTBITreatment,
            /// <summary>
            /// 結核病 ICD10
            /// </summary>
            OPD_TBDiagCodeAndOrderCode,
            /// <summary>
            /// C1論病歷計酬案件DRG
            /// </summary>
            OPD_CaseTypeC1DRG,
            /// <summary>
            /// 慢箋04案件
            /// </summary>
            OPD_CaseType04, 
        }
        #endregion IDENTITYCHECK DROPDOWN CHANGED USE METHOD NAME 身分別下拉選單使用相關規則名稱

        #region 回傳狀態訊息
        /// <summary>
        /// 回傳狀態訊息[Display(Name="中文訊息")]
        /// </summary>
        public enum ReturnMessage
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            NULL = 9999,
            /// <summary>
            /// 成功
            /// </summary>
            [Display(Name = "成功")]
            SUCCESS = 0,
            /// <summary>
            /// 執行
            /// </summary>
            [Display(Name = "執行")]
            EXECUTE = 1,
            /// <summary>
            /// 執行中
            /// </summary>
            [Display(Name = "執行中")]
            EXECUTING = 2,
            /// <summary>
            /// 啟動
            /// </summary>
            [Display(Name = "啟動")]
            ACTIVATE = 3,
            /// <summary>
            /// 取消啟動
            /// </summary>
            [Display(Name = "取消啟動")]
            DEACTIVATE = 4,
            /// <summary>
            /// 警告
            /// </summary>
            [Display(Name = "警告")]
            WARNING = 7,
            /// <summary>
            /// 故障
            /// </summary>
            [Display(Name = "故障")]
            FAULT = 8,
            /// <summary>
            /// 失敗
            /// </summary>
            [Display(Name = "失敗")]
            FAILURE = 9,
            /// <summary>
            /// 失效
            /// </summary>
            [Display(Name = "失效")]
            FAIL = 99,
            /// <summary>
            /// 錯誤
            /// </summary>
            [Display(Name = "錯誤")]
            ERROR = 10,
            /// <summary>
            /// 致命錯誤
            /// </summary>
            [Display(Name = "致命錯誤")]
            FATAL_ERROR = 11,
            /// <summary>
            /// 崩潰
            /// </summary>
            [Display(Name = "崩潰")]
            CRASH = 12,
            /// <summary>
            /// 錯誤擲出
            /// </summary>
            [Display(Name = "錯誤擲出")]
            EXCEPTION = 13,
            /// <summary>
            /// 未執行
            /// </summary>
            [Display(Name = "未執行")]
            NO_PERFORMED = 14,
            /// <summary>
            /// 資料
            /// </summary>
            [Display(Name = "資料")]
            DATA = 15,
            /// <summary>
            /// 需求
            /// </summary>
            [Display(Name = "需求")]
            REQUIRE = 16,
            /// <summary>
            /// 需要
            /// </summary>
            [Display(Name = "詢問")]
            REQUEST = 17,
            /// <summary>
            /// 缺失
            /// </summary>
            [Display(Name = "缺失")]
            MISSING = 18,
            /// <summary>
            /// 初始化
            /// </summary>
            [Display(Name = "初始化")]
            INITIAL = 19,
            /// <summary>
            /// 初始階段
            /// </summary>
            [Display(Name = "初始階段")]
            PHASE0 = 20,
            /// <summary>
            /// 第一階段
            /// </summary>
            [Display(Name = "第一階段")]
            PHASE1 = 21,
            /// <summary>
            /// 第二階段
            /// </summary>
            [Display(Name = "第二階段")]
            PHASE2 = 22,
            /// <summary>
            /// 第三階段
            /// </summary>
            [Display(Name = "第三階段")]
            PHASE3 = 23,
            /// <summary>
            /// 第四階段
            /// </summary>
            [Display(Name = "第四階段")]
            PHASE4 = 24,
            /// <summary>
            /// 第五階段
            /// </summary>
            [Display(Name = "第五階段")]
            PHASE5 = 25,


        }
        #endregion

        #region 健保卡資料上傳版本代碼
        /// <summary>
        /// 健保卡資料上傳版本代碼
        /// </summary>
        public enum NHI_UPLOAD_VERSION
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            [Description("00")]
            NULL,
            /// <summary>
            /// 健保卡1.0
            /// </summary>
            [Display(Name = "1.0")]
            [Description("10")]
            NHI10,
            /// <summary>
            /// 健保卡1.0 重新上傳
            /// </summary>
            [Display(Name = "1.0 重新上傳")]
            [Description("10_XX")]
            NHI10_ReUpload,
            /// <summary>
            /// 健保卡1.0 測試
            /// </summary>
            [Display(Name = "1.0 測試")]
            [Description("10_ZZ")]
            NHI10_ZZ,
            /// <summary>
            /// 健保卡2.0 只在搜尋清單時候使用
            /// </summary>
            [Display(Name = "2.0")]
            [Description("20")]
            NHI20_QueryOnly,
            /// <summary>
            /// 健保卡2.0 正式
            /// </summary>
            [Display(Name = "2.0 正式")]
            [Description("20_A1")]
            NHI20_A1,
            /// <summary>
            /// 健保卡2.0 預檢
            /// </summary>
            [Display(Name = "2.0 預檢")]
            [Description("20_A2")]
            NHI20_A2,
            /// <summary>
            /// 健保卡2.0 介接測試
            /// </summary>
            [Display(Name = "2.0 介接測試")]
            [Description("20_ZZ")]
            NHI20_ZZ,
        }
        #endregion 健保卡資料上傳版本代碼

        #region 健保卡資料上傳旗標
        /// <summary>
        /// 健保卡資料上傳狀態旗標 NHIUPLOAD_REC.UPLOADFLAG
        /// </summary>
        public enum NHI_UPLOADFLAG
        {
            /// <summary>
            /// 未上傳
            /// </summary>
            [Display(Name = "未上傳")]
            N,
            /// <summary>
            /// 已上傳
            /// </summary>
            [Display(Name = "已上傳")]
            Y,
            /// <summary>
            /// 無資料 不須上傳
            /// </summary>
            [Display(Name = "不須上傳")]
            C,
        }

        #endregion

        #region NHIICBase CSHIS x86 DLL Com Server Function Enum
        /*重要設定備註:
          此Enum之 Description 為存放，傳入DLL之相對應 ref Length, 且相同數字之OUTD與LEN，應為相同長度，並使用','來區隔
          此Enum之 Display.Name 為存放讀取DLL之相對應函式名稱，Display.Description 為存放該ref傳入或回傳之相關參數型態，並使用','來區隔
            EX: OUTD為DLL輸出之Buffer, 相對應於CSHIS文件中之 [ [out]pBuffer,為HIS準備之buffer]
                LEN0為DLL輸入及輸出之Buffer的長度, 相對應於CSHIS文件中之 [ [in/out]iBufferLen,為HIS所準備buffer之長度]
                IND為DLL輸入之參數 , 相對應於CSHIS文件中之 [ [in]傳入....]
                INT為DLL輸入或輸出之參數 , 相對應於CSHIS文件中之 [ [in/out]傳入欲讀取之位置 或回傳讀取之....等]
         */
        /// <summary>
        /// 健保卡CSHIS DLL Enum[存放欲取出之DLL函式名稱(Display.Name)與Ref物件長度(Description)及型態(Display.Description),使用','來區分順序]
        /// </summary>
        public enum NHIICBase_CSHIS_Enum
        {
            /// <summary>
            /// 初始數值
            /// </summary>
            NULL = 0,
            /// <summary>
            /// 1.1 讀取不需個人 PIN 碼資料
            /// </summary>
            [Display(Name = nameof(hisGetBasicData), Description = "OUTD0,LEN0")]
            [Description("72,72")]
            hisGetBasicData,
            /// <summary>
            /// 1.2 掛號或報到時讀取基本資料
            /// </summary>
            [Display(Name = nameof(hisGetRegisterBasic), Description = "OUTD0,LEN0")]
            [Description("78,78")]
            hisGetRegisterBasic,
            /// <summary>
            /// 1.3 預防保健掛號作業
            /// </summary>
            [Display(Name = nameof(hisGetRegisterPrevent), Description = "OUTD0,LEN0")]
            [Description("126,126")]
            hisGetRegisterPrevent,
            /// <summary>
            /// 1.4 孕婦產前檢查掛號作業
            /// </summary>
            [Display(Name = nameof(hisGetRegisterPregnant), Description = "OUTD0,LEN0")]
            [Description("209,209")]
            hisGetRegisterPregnant,
            /// <summary>
            /// 1.5 讀取就醫資料不需 HPC 卡的部分
            /// </summary>
            [Display(Name = nameof(hisGetTreatmentNoNeedHPC), Description = "OUTD0,LEN0")]
            [Description("498,498")]
            hisGetTreatmentNoNeedHPC,
            /// <summary>
            /// 1.6 讀取就醫累計資料
            /// </summary>
            [Display(Name = nameof(hisGetCumulativeData), Description = "OUTD0,LEN0")]
            [Description("134,134")]
            hisGetCumulativeData,
            /// <summary>
            /// 1.7 讀取醫療費用總累計
            /// </summary>
            [Display(Name = nameof(hisGetCumulativeFee), Description = "OUTD0,LEN0")]
            [Description("20,20")]
            hisGetCumulativeFee,
            /// <summary>
            /// 1.8 讀取就醫資料需要 HPC 卡的部份[由COM SERVER內部函式使用ParameterOne來區別回傳之ICD種類,故於此不採用BufferLen]
            /// </summary>
            [Display(Name = nameof(hisGetTreatmentNeedHPC), Description = "OUTD0,LEN0")]
            [Description("540,540")]
            hisGetTreatmentNeedHPC,
            /// <summary>
            /// 1.9 取得就醫序號
            /// </summary>
            [Display(Name = nameof(hisGetSeqNumber), Description = "IND0,IND1,OUTD0,LEN0")]
            [Description("0,0,167,167")]
            hisGetSeqNumber,
            /// <summary>
            /// 1.10 讀取處方箋作業
            /// </summary>
            [Display(Name = nameof(hisReadPrescription), Description = "OUTD0,LEN0,OUTD1,LEN1,OUTD2,LEN2,OUTD3,LEN3")]
            [Description("3660,3660,1320,1320,360,360,120,120")]
            hisReadPrescription,
            /// <summary>
            /// 1.11 讀取預防接種資料
            /// </summary>
            [Display(Name = nameof(hisGetInoculateData), Description = "OUTD0,LEN0")]
            [Description("1400,1400")]
            hisGetInoculateData,
            /// <summary>
            /// 1.12 讀取同意器官捐贈及安寧緩和醫療註記
            /// </summary>
            [Display(Name = nameof(hisGetOrganDonate), Description = "OUTD0,LEN0")]
            [Description("1,1")]
            hisGetOrganDonate,
            /// <summary>
            /// 1.13 讀取緊急聯絡電話資料
            /// </summary>
            [Display(Name = nameof(hisGetEmergentTel), Description = "OUTD0,LEN0")]
            [Description("14,14")]
            hisGetEmergentTel,
            /// <summary>
            /// 1.14 讀取最近一次就醫序號
            /// </summary>
            [Display(Name = nameof(hisGetLastSeqNum), Description = "OUTD0,LEN0")]
            [Description("7,7")]
            hisGetLastSeqNum,
            /// <summary>
            /// 1.15 讀取卡片狀態
            /// </summary>
            [Display(Name = nameof(hisGetCardStatus), Description = "INT0")]
            [Description("1")]
            hisGetCardStatus,
            /// <summary>
            /// 1.16 就醫診療資料寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteTreatmentCode), Description = "IND0,IND1,IND2,IND3,OUTD0")]
            [Description("14,11,8,54,11")]
            hisWriteTreatmentCode,
            /// <summary>
            /// 1.17 就醫費用資料寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteTreatmentFee), Description = "IND0,IND1,IND2,IND3")]
            [Description("14,11,8,38")]
            hisWriteTreatmentFee,
            /// <summary>
            /// 1.18 處方箋寫入作業
            /// </summary>
            [Display(Name = nameof(hisWritePrescription), Description = "IND0,IND1,IND2,IND3")]
            [Description("14,11,8,61")]
            hisWritePrescription,
            /// <summary>
            /// 1.19 新生兒註記寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteNewBorn), Description = "IND0,IND1,IND2,IND3")]
            [Description("11,8,8,2")]
            hisWriteNewBorn,
            /// <summary>
            /// 1.20 過敏藥物寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteAllergicMedicines), Description = "IND0,IND1,IND2,OUTD0")]
            [Description("11,8,120,11")]
            hisWriteAllergicMedicines,
            /// <summary>
            /// 1.21 同意器官捐贈及安寧緩和醫療註記寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteOrganDonate), Description = "IND0,IND1,IND2")]
            [Description("11,8,2")]
            hisWriteOrganDonate,
            /// <summary>
            /// 1.22 預防保健資料寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteHealthInsurance), Description = "IND0,IND1,IND2,IND3")]
            [Description("11,8,3,3")]
            hisWriteHealthInsurance,
            /// <summary>
            /// 1.23 緊急聯絡電話資料寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteEmergentTel), Description = "IND0,IND1,IND2")]
            [Description("11,8,15")]
            hisWriteEmergentTel,
            /// <summary>
            /// 1.24 寫入產前檢查資料
            /// </summary>
            [Display(Name = nameof(hisWritePredeliveryCheckup), Description = "IND0,IND1,IND2")]
            [Description("11,8,3")]
            hisWritePredeliveryCheckup,
            /// <summary>
            /// 1.25 清除產前檢查資料
            /// </summary>
            [Display(Name = nameof(hisWritePredeliveryCheckup), Description = "IND0,IND1")]
            [Description("11,8")]
            hisDeletePredeliveryData,
            /// <summary>
            /// 1.26 預防接種資料寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteInoculateData), Description = "IND0,IND1,IND2,IND3")]
            [Description("11,8,7,13")]
            hisWriteInoculateData,
            /// <summary>
            /// 1.27 驗證健保 IC 卡之 PIN 值
            /// </summary>
            [Display(Name = nameof(csVerifyHCPIN), Description = "")]
            [Description("")]
            csVerifyHCPIN,
            /// <summary>
            /// 1.28 輸入新的健保 IC 卡 PIN 值
            /// </summary>
            [Display(Name = nameof(csInputHCPIN), Description = "")]
            [Description("")]
            csInputHCPIN,
            /// <summary>
            /// 1.29 停用健保 IC 卡之 PIN 碼輸入功能
            /// </summary>
            [Display(Name = nameof(csDisableHCPIN), Description = "")]
            [Description("")]
            csDisableHCPIN,
            /// <summary>
            /// 1.30 健保 IC 卡卡片內容更新作業
            /// </summary>
            [Display(Name = nameof(csUpdateHCContents), Description = "")]
            [Description("")]
            csUpdateHCContents,
            /// <summary>
            /// 1.31 開啟讀卡機連結埠
            /// </summary>
            [Display(Name = nameof(csOpenCom), Description = "INT0")]
            [Description("0")]
            csOpenCom,
            /// <summary>
            /// 1.32 關閉讀卡機連結埠
            /// </summary>
            [Display(Name = nameof(csCloseCom), Description = "")]
            [Description("")]
            csCloseCom,
            /// <summary>
            /// 1.33 讀取重大傷病註記資料[ICD9:114, ICD:138]
            /// </summary>
            [Display(Name = nameof(hisGetCriticalIllness), Description = "OUTD0,LEN0")]
            [Description("138,138")]
            hisGetCriticalIllness,
            /// <summary>
            /// 1.34 讀取讀卡機日期時間
            /// </summary>
            [Display(Name = nameof(csGetDateTime), Description = "OUTD0,LEN0")]
            [Description("13,13")]
            csGetDateTime,
            /// <summary>
            /// 1.35 讀取卡片號碼
            /// </summary>
            [Display(Name = nameof(csGetCardNo), Description = "INT0,OUTD0,LEN0")]
            [Description("0,12,12")]
            csGetCardNo,
            /// <summary>
            /// 1.36 檢查健保 IC 卡是否設定密碼
            /// </summary>
            [Display(Name = nameof(csISSetPIN), Description = "")]
            [Description("")]
            csISSetPIN,
            /// <summary>
            /// 1.37 取得就醫序號新版
            /// </summary>
            [Display(Name = nameof(hisGetSeqNumber256), Description = "IND0,IND1,IND2,OUTD0,LEN0")]
            [Description("3,2,1,296,296")]
            hisGetSeqNumber256,
            /// <summary>
            /// 1.38 掛號或報到時讀取基本資料
            /// </summary>
            [Display(Name = nameof(hisGetRegisterBasic2), Description = "OUTD0,LEN0")]
            [Description("9,9")]
            hisGetRegisterBasic2,
            /// <summary>
            /// 1.39 回復就醫資料累計值（退掛）
            /// </summary>
            [Display(Name = nameof(csUnGetSeqNumber), Description = "IND0")]
            [Description("14")]
            csUnGetSeqNumber,
            /// <summary>
            /// 1.40 健保 IC 卡卡片內容更新作業
            /// </summary>
            [Display(Name = nameof(csUpdateHCNoReset), Description = "")]
            [Description("")]
            csUpdateHCNoReset,
            /// <summary>
            /// 1.41 指定就醫資料只讀取門診處方箋
            /// </summary>
            [Display(Name = nameof(hisReadPrescriptMain), Description = "OUTD0,LEN0,INT0,INT1,INT2")]
            [Description("3660,3660,1,60,60")]
            hisReadPrescriptMain,
            /// <summary>
            /// 1.42 指定就醫資料只讀取長期處方箋
            /// </summary>
            [Display(Name = nameof(hisReadPrescriptLongTerm), Description = "OUTD0,LEN0,INT0,INT1,INT2")]
            [Description("1320,1320,1,30,30")]
            hisReadPrescriptLongTerm,
            /// <summary>
            /// 1.43 指定就醫資料只讀取重要醫令
            /// </summary>
            [Display(Name = nameof(hisReadPrescriptHVE), Description = "OUTD0,LEN0,INT0,INT1,INT2")]
            [Description("360,360,1,10,10")]
            hisReadPrescriptHVE,
            /// <summary>
            /// 1.44 指定就醫資料只讀取過敏藥物
            /// </summary>
            [Display(Name = nameof(hisReadPrescriptAllergic), Description = "OUTD0,LEN0,INT0,INT1,INT2")]
            [Description("120,120,1,3,3")]
            hisReadPrescriptAllergic,
            /// <summary>
            /// 1.45 多筆處方箋寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteMultiPrescript), Description = "IND0,IND1,IND2,IND3,INT0")]
            [Description("14,11,8,3660,60")]
            hisWriteMultiPrescript,
            /// <summary>
            /// 1.46 過敏藥物寫入指定欄位作業
            /// </summary>
            [Display(Name = nameof(hisWriteAllergicNum), Description = "IND0,IND1,IND2,OUTD0,INT0")]
            [Description("11,8,40,11,1")]
            hisWriteAllergicNum,
            /// <summary>
            /// 1.47 就醫診療資料及費用寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteTreatmentData), Description = "IND0,IND1,IND2,IND3,OUTD0")]
            [Description("14,11,8,93,11")]
            hisWriteTreatmentData,
            /// <summary>
            /// 1.48 處方箋寫入作業並取得回傳之簽章
            /// </summary>
            [Display(Name = nameof(hisWritePrescriptionSign), Description = "IND0,IND1,IND2,IND3,OUTD0,LEN0")]
            [Description("14,11,8,61,40,40")]
            hisWritePrescriptionSign,
            /// <summary>
            /// 1.49 多筆處方箋寫入作業並取得回傳之簽章
            /// </summary>
            [Display(Name = nameof(hisWriteMultiPrescriptSign), Description = "IND0,IND1,IND2,IND3,INT0,OUTD0,LEN0")]
            [Description("14,11,8,3660,60,3660,3660")]
            hisWriteMultiPrescriptSign,
            /// <summary>
            /// 1.50 讀取重大傷病註記資料身分比對
            /// </summary>
            [Display(Name = nameof(hisGetCriticalIllnessID), Description = "IND0,IND1,OUTD0,LEN0")]
            [Description("11,8,138,138")]
            hisGetCriticalIllnessID,
            /// <summary>
            /// 1.51 取得控制軟體版本
            /// </summary>
            [Display(Name = nameof(csGetVersionEx), Description = "OUTD0")]
            [Description("9999")]
            csGetVersionEx,
            /// <summary>
            /// 1.52 提供 His 重置讀卡機或卡片的 API
            /// </summary>
            [Display(Name = nameof(csSoftwareReset), Description = "INT0")]
            [Description("0")]
            csSoftwareReset,
            /// <summary>
            /// 1.53 取得就醫序號新版-就醫識別碼
            /// </summary>
            [Display(Name = nameof(hisGetSeqNumber256N1), Description = "IND0,IND1,IND2,OUTD0,LEN0")]
            [Description("3,2,1,316,316")]
            hisGetSeqNumber256N1,
            /// <summary>
            /// 1.54 異常時取得就醫識別碼
            /// </summary>
            [Display(Name = nameof(hisGetTreatNumNoICCard), Description = "IND0,IND1,OUTD0,LEN0")]
            [Description("11,11,43,43")]
            hisGetTreatNumNoICCard,
            /// <summary>
            /// 1.55 在保狀態查核
            /// </summary>
            [Display(Name = nameof(hisQuickInsurence), Description = "IND0")]
            [Description("3")]
            hisQuickInsurence,
            /// <summary>
            /// 1.56 單獨取得就醫識別碼
            /// </summary>
            [Display(Name = nameof(hisGetTreatNumICCard), Description = "IND0,OUTD0,LEN0")]
            [Description("14,20,20")]
            hisGetTreatNumICCard,
            /// <summary>
            /// 2.1 安全模組（SAM）認證
            /// </summary>
            [Display(Name = nameof(csVerifySAMDC), Description = "")]
            [Description("")]
            csVerifySAMDC,
            /// <summary>
            /// 2.2 讀取 SAM 院所代碼
            /// </summary>
            [Display(Name = nameof(csGetHospID), Description = "OUTD0,LEN0")]
            [Description("10,10")]
            csGetHospID,
            /// <summary>
            /// 2.3 讀取 SAM 院所名稱
            /// </summary>
            [Display(Name = nameof(csGetHospName), Description = "OUTD0,LEN0")]
            [Description("24,24")]
            csGetHospName,
            /// <summary>
            /// 2.4 讀取 SAM 院所簡稱
            /// </summary>
            [Display(Name = nameof(csGetHospAbbName), Description = "OUTD0,LEN0")]
            [Description("128,128")]
            csGetHospAbbName,
            /// <summary>
            /// 3.1 資料上傳
            /// </summary>
            [Display(Name = nameof(csUploadData), Description = "IND0,IND0,INT0,OUTD0,LEN0")]
            [Description("65536,1073741824,0,50,50")] //1G = 1073741824 bytes
            csUploadData,
            /// <summary>
            /// 4.1 取得醫事人員卡狀態
            /// </summary>
            [Display(Name = nameof(hpcGetHPCStatus), Description = "INT0,INT1")]
            [Description("1,0")]
            hpcGetHPCStatus,
            /// <summary>
            /// 4.2 檢查醫事人員卡之 PIN 值
            /// </summary>
            [Display(Name = nameof(hpcVerifyHPCPIN), Description = "")]
            [Description("")]
            hpcVerifyHPCPIN,
            /// <summary>
            /// 4.3 輸入新的醫事人員卡之 PIN 值
            /// </summary>
            [Display(Name = nameof(hpcInputHPCPIN), Description = "")]
            [Description("")]
            hpcInputHPCPIN,
            /// <summary>
            /// 4.4 解開鎖住的醫事人員卡
            /// </summary>
            [Display(Name = nameof(hpcUnlockHPC), Description = "")]
            [Description("")]
            hpcUnlockHPC,
            /// <summary>
            /// 4.5 取得醫事人員卡序號
            /// </summary>
            [Display(Name = nameof(hpcGetHPCSN), Description = "OUTD0,LEN0")]
            [Description("50,50")]
            hpcGetHPCSN,
            /// <summary>
            /// 4.6 取得醫事人員卡身分證字號
            /// </summary>
            [Display(Name = nameof(hpcGetHPCSSN), Description = "OUTD0,LEN0")]
            [Description("20,20")]
            hpcGetHPCSSN,
            /// <summary>
            /// 4.7 取得醫事人員卡中文姓名
            /// </summary>
            [Display(Name = nameof(hpcGetHPCCNAME), Description = "OUTD0,LEN0")]
            [Description("999,999")]
            hpcGetHPCCNAME,
            /// <summary>
            /// 4.8 取得醫事人員卡英文姓名
            /// </summary>
            [Display(Name = nameof(hpcGetHPCENAME), Description = "OUTD0,LEN0")]
            [Description("999,999")]
            hpcGetHPCENAME,
            /// <summary>
            /// 4.9 虛擬醫師卡登出
            /// </summary>
            [Display(Name = nameof(hpcVHPCLogout), Description = "")]
            [Description("")]
            hpcVHPCLogout,
            /// <summary>
            /// 5.1 進行疾病診斷碼押碼
            /// </summary>
            [Display(Name = nameof(hisGetICD10EnC), Description = "IND0,OUTD")]
            [Description("8,8")]
            hisGetICD10EnC,
            /// <summary>
            /// 5.2 進行疾病診斷碼解押碼
            /// </summary>
            [Display(Name = nameof(hisGetICD10DeC), Description = "IND0,OUTD")]
            [Description("8,8")]
            hisGetICD10DeC,
        }
        #endregion NHIICBase CSHIS x86 DLL Com Server Function Enum  

        #region 健保卡 系統呼叫來源
        /// <summary>
        /// NHI 系統呼叫來源
        /// </summary>
        public enum QUERYNHI_SYSTEM_NAME
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "未知來源")]
            NULL = 0,
            /// <summary>
            /// 急診檢傷
            /// </summary>
            [Display(Name = "急診檢傷")]
            ER_TRIAGE,
            /// <summary>
            /// 急診掛號
            /// </summary>
            [Display(Name = "急診掛號")]
            ER_REGISTER,
            /// <summary>
            /// 急診批價
            /// </summary>
            [Display(Name = "急診批價")]
            ER_CASHIER,
            /// <summary>
            /// 急診自助繳費機
            /// </summary>
            [Display(Name = "急診自助繳費機")]
            ER_SELF_CHECKOUT,
            /// <summary>
            /// 門診結案
            /// </summary>
            [Display(Name = "門診結案")]
            OPD_ClinicRoom_Finish,
            /// <summary>
            /// 門診結案慢箋一次領(依照SLOWSICK.SSCOUNT取相對應次數)
            /// </summary>
            [Display(Name = "門診結案慢箋一次領")]
            OPD_ClinicRoom_FinishSlowSickTakeAll,
            /// <summary>
            /// 門診儀錶板
            /// </summary>
            [Display(Name = "門診儀錶板")]
            OPD_ClinicRoom_Dashboard,
            /// <summary>
            /// 門診掛號
            /// </summary>
            [Display(Name = "門診掛號")]
            OPD_REGISTER,
            /// <summary>
            /// 門診批價
            /// </summary>
            [Display(Name = "門診批價")]
            OPD_CASHIER,
            /// <summary>
            /// 門診批價慢箋
            /// </summary>
            [Display(Name = "門診批價慢箋")]
            OPD_CASHIER_SlowSick,
            /// <summary>
            /// 檢驗檢查報到寫處方籤
            /// </summary>
            [Display(Name = "檢驗檢查報到寫處方籤")]
            LISPACS_WEB_WritePrescription,
            /// <summary>
            /// 網頁API於Windows時呼叫Winform程式進行讀卡 取256N1用
            /// </summary>
            [Display(Name = "網頁API使用本地端讀卡程式")]
            HostService_Get256N1,
            /// <summary>
            /// 網頁API於Windows時呼叫Winform程式進行讀卡 取256N1用
            /// </summary>
            [Display(Name = "網頁API使用本地端讀卡程式")]
            OPD_Cashier_Get256N1,
            /// <summary>
            /// 門診品修
            /// </summary>
            [Display(Name = "門診品修")]
            OPD_CureEditorQuery,
            /// <summary>
            /// 門診品修 補健保上傳醫令資料
            /// </summary>
            [Display(Name = "門診品修 補健保上傳醫令資料")]
            OPD_CureEditorQuery_SupplyOrder,
            /// <summary>
            /// 急診品修
            /// </summary>
            [Display(Name = "急診品修")]
            ER_CureEditorQuery,

        }
        #endregion 健保卡 系統呼叫來源

        #region 呼叫來源
        /// <summary>
        /// 呼叫來源
        /// </summary>
        public enum CALL_SYSTEM
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            NULL,
            /// <summary>
            /// 門診儀錶板
            /// </summary>
            [Display(Name = "門診儀錶板")]
            OPD_Dashboard,
            /// <summary>
            /// 門診診間
            /// </summary>
            [Display(Name = "門診診間")]
            OPD_ClinicRoom,
            /// <summary>
            /// 門診診間套餐
            /// </summary>
            [Display(Name = "門診診間套餐")]
            OPD_ClinicRoom_PackageOrder,
            /// <summary>
            /// 門診診間結案
            /// </summary>
            [Display(Name = "門診診間結案")]
            OPD_ClinicRoom_Finish,
            /// <summary>
            /// 門診診間結案身分確認視窗
            /// </summary>
            [Display(Name = "門診診間結案身分確認視窗")]
            OPD_ClinicRoom_Finish_IdentityVerification,
            /// <summary>
            /// 門診診間非結案身分確認視窗
            /// </summary>
            [Display(Name = "門診診間非結案身分確認視窗")]
            OPD_ClinicRoom_IdentityVerification,
            /// <summary>
            /// 套餐維護程式
            /// </summary>
            [Display(Name = "套餐維護程式")]
            Maintain_PackageOrder,
            /// <summary>
            /// 門診批價品項修正
            /// </summary>
            [Display(Name = "門診批價品項修正")]
            OPD_Cashier_CureEditor,
            /// <summary>
            /// 急診批價品項修正
            /// </summary>
            [Display(Name = "急診批價品項修正")]
            ER_Cashier_CureEditor,
            /// <summary>
            /// 門診化療
            /// </summary>
            [Display(Name = "門診化療")]
            OPD_Chem,
            /// <summary>
            /// 批價底層
            /// </summary>
            [Display(Name = "批價底層")]
            Cashier_Logical,
            /// <summary>
            /// 急診診間
            /// </summary>
            [Display(Name = "急診診間")]
            ER_SOAPClinicRoom,
            /// <summary>
            /// 門診批價
            /// </summary>
            [Display(Name = "門診批價")]
            OPD_Cashier,
            /// <summary>
            /// 急診批價
            /// </summary>
            [Display(Name = "急診批價")]
            ERM_Cashier,
            /// <summary>
            /// 健保卡查詢軟體(穎珊)
            /// </summary>
            [Display(Name = "健保卡查詢軟體")]
            HIS2_ICCardReader,
        }
        #endregion 呼叫來源

        #region REG_CHANGERECORD
        /// <summary>
        /// REG_CHANGERECORD.SYSTEM 
        /// </summary>
        public enum Reg_ChangeRecordSystem
        {
            /// <summary>
            /// 門診診間結案身分確認視窗
            /// </summary>
            [Display(Name = "門診診間結案身分確認視窗")]
            OPD_ClinicRoom_Finish_IdentityVerification,
            /// <summary>
            /// 門診診間結案身分確認視窗 未儲存離開
            /// </summary>
            [Display(Name = "門診診間結案身分確認視窗 未儲存離開")]
            OPD_ClinicRoom_Finish_CancelIdentityVerification,
            /// <summary>
            /// 門診診間結案身分確認視窗 主動發送LOG
            /// </summary>
            [Display(Name = "門診診間結案身分確認視窗 主動發送LOG")]
            OPD_ClinicRoom_Finish_SendLog,

            /// <summary>
            /// 門診診間健保卡讀取紀錄
            /// </summary>
            [Display(Name = "門診診間健保卡讀取紀錄")]
            OPD_ClinicRoom_Finish_NHIRecordReport,
            /// <summary>
            /// 門診診間HISEDIT未異動紀錄(因IP或MachineName或ProcessID不一致)
            /// </summary>
            [Display(Name = "門診診間HISEDIT未異動紀錄")]
            OPD_ClinicRoom_HISEDITUnchange,
            /// <summary>
            /// 門診批價
            /// </summary>
            [Display(Name = "門診批價")]
            OpdCashier,
            /// <summary>
            /// 門診品修
            /// </summary>
            [Display(Name = "門診品修")]
            OpdCureRec,
            /// <summary>
            /// 急診批價
            /// </summary>
            [Display(Name = "急診批價")]
            ErCashier,
            /// <summary>
            /// 門診居家照護於正式區確認病患報到
            /// </summary>
            [Display(Name = "門診居家照護於正式區確認病患報到")]
            OPD_Dashboard_HomeCareConfirmPatientCheckIn,
            /// <summary>
            /// 門診身分確認讀取就醫序號失敗
            /// </summary>
            [Display(Name = "門診身分確認讀取就醫序號失敗")]
            OPD_CR_IdentityVerification_CardNumFailure,
            /// <summary>
            /// 門診身分確認讀取就醫序號成功
            /// </summary>
            [Display(Name = "門診身分確認讀取就醫序號成功")]
            OPD_CR_IdentityVerification_CardNumSuccess,
            /// <summary>
            /// 門診身分確認讀取就醫序號逾時
            /// </summary>
            [Display(Name = "門診身分確認讀取就醫序號逾時")]
            OPD_CR_IdentityVerification_CardNumTimeOut,
            /// <summary>
            /// 共用診間更新ICLOAD相關資料
            /// </summary>
            [Display(Name = "共用診間更新ICLOAD相關資料")]
            PublicClinicRoom_UpdateIcloadData,
            /// <summary>
            /// 門診身分確認執行時間Log
            /// </summary>
            [Display(Name = "門診身分確認執行時間Log")]
            OPD_CR_IdentityVerification_ExecuteLog,
            /// <summary>
            /// 門診診間進入住院檢核時異動身分別為民眾
            /// </summary>
            [Display(Name = "門診診間進入住院檢核時異動身分別為民眾")]
            OPD_CR_REC_INPAT_Change,
            /// <summary>
            /// 健保署重大傷病寫入紀錄
            /// </summary>
            [Display(Name = "健保署重大傷病寫入紀錄")]
            NHIIC_CriticalIllnessInsertRecord,
            /// <summary>
            /// 門診診間身分確認發送視窗載入紀錄
            /// </summary>
            [Display(Name = "門診診間身分確認發送視窗載入紀錄")]
            OPD_IdentityVerify_SendWinformLog,
        }
        #endregion REG_CHANGERECORD

        #region IdentityChangeRecord 身分確認LOG
        /// <summary>
        /// IdentityChangeRecord
        /// </summary>
        public enum IdentityChangeRecord_Category
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            Null,
            /// <summary>
            /// 儀錶板-病患清單右鍵
            /// </summary>
            [Display(Name = "儀錶板-病患清單右鍵")]
            OPD_DashboardForm_PatietListContextMenu,
            /// <summary>
            /// 查詢病患清單右鍵-非結案模式
            /// </summary>
            [Display(Name = "查詢病患清單右鍵-非結案模式")]
            OPD_QueryPatientRegForm_ContextMenu_NoneFinish,
            /// <summary>
            /// 查詢病患清單右鍵-結案模式
            /// </summary>
            [Display(Name = "查詢病患清單右鍵-結案模式")]
            OPD_QueryPatientRegForm_ContextMenu_Finish,
            /// <summary>
            /// 診間-護理功能
            /// </summary>
            [Display(Name = "診間-護理功能")]
            OPD_ClinicRoom_MenuItem,
            /// <summary>
            /// 診間-結案按鈕
            /// </summary>
            [Display(Name = "診間-結案按鈕")]
            OPD_ClinicRoom_FinishButton,

            #region 外部呼叫用
            /// <summary>
            /// 門診批價
            /// </summary>
            OPD_Cashier,
            /// <summary>
            /// 急診批價
            /// </summary>
            ERM_Cashier,

            #endregion
        }
        /// <summary>
        /// IdentityChangeRecord
        /// </summary>
        public enum IdentityChangeRecord_SubCategory
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            Null,
            /// <summary>
            /// 結案寫卡
            /// </summary>
            [Display(Name = "結案寫卡")]
            IdentityVerificationForm_Finish,
            /// <summary>
            /// 結案存檔
            /// </summary>
            [Display(Name = "結案存檔")] 
            IdentityVerificationForm_NoneFinish,
            /// <summary>
            /// 取消結案(存檔)
            /// </summary>
            [Display(Name = "取消結案存檔")]
            IdentityVerificationForm_Cancel,
            /// <summary>
            /// 發送LOG
            /// </summary>
            [Display(Name = "發送LOG")]
            IdentityVerificationForm_SendLog,
            
        }

        #endregion

        #region REGMETHOD
        /// <summary>
        /// 掛號方式 (尚未補完)
        /// </summary>
        public enum REGMETHOD
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            [Description("00")]
            NULL = 0,
            /// <summary>
            /// 國際醫療門診(國內)
            /// </summary>
            [Display(Name = "國際醫療門診(國內)")]
            [Description("01")]
            InternationalMedicalClinic_Domestic,

            /// <summary>
            /// 高階長官門診
            /// </summary>
            [Display(Name = "高階長官門診")]
            [Description("02")]
            SeniorOfficersClinic,

            /// <summary>
            /// 國際醫療門診(國外)
            /// </summary>
            [Display(Name = "國際醫療門診(國外)")]
            [Description("03")]
            InternationalMedicalClinic_Overseas,

            /// <summary>
            /// 國際醫療門診(員榮)
            /// </summary>
            [Display(Name = "國際醫療門診(員榮)")]
            [Description("05")]
            InternationalMedicalClinic_StaffVeterans,

            /// <summary>
            /// 櫃台掛號
            /// </summary>
            [Display(Name = "櫃台掛號")]
            [Description("10")]
            CounterRegistration,

            /// <summary>
            /// 醫師現場約診
            /// </summary>
            [Display(Name = "醫師現場約診")]
            [Description("11")]
            DoctorOnSiteAppointment,

            /// <summary>
            /// 櫃台預約
            /// </summary>
            [Display(Name = "櫃台預約")]
            [Description("14")]
            CounterAppointment,

            /// <summary>
            /// 櫃台初診預約掛號
            /// </summary>
            [Display(Name = "櫃台初診預約掛號")]
            [Description("15")]
            CounterFirstAppointmentRegistration,

            /// <summary>
            /// 住院31日回診
            /// </summary>
            [Display(Name = "住院31日回診")]
            [Description("16")]
            IPDReturnVisitOn31Days,

            /// <summary>
            /// 住院31日預約回診
            /// </summary>
            [Display(Name = "住院31日預約回診")]
            [Description("17")]
            IPDAppointmentVisitOn31Days,

            /// <summary>
            /// 語音掛號
            /// </summary>
            [Display(Name = "語音掛號")]
            [Description("20")]
            VoiceRegistration,

            /// <summary>
            /// 醫師現場特約診
            /// </summary>
            [Display(Name = "醫師現場特約診")]
            [Description("21")]
            DoctorOnSiteSpecialAppointment,

            /// <summary>
            /// 語音預約
            /// </summary>
            [Display(Name = "語音預約")]
            [Description("24")]
            VoiceAppointment,

            /// <summary>
            /// 語音初診掛號
            /// </summary>
            [Display(Name = "語音初診掛號")]
            [Description("25")]
            VoiceFirstAppointmentRegistration,

            /// <summary>
            /// 自動櫃台
            /// </summary>
            [Display(Name = "自動櫃台")]
            [Description("30")]
            AutomaticCounter,

            /// <summary>
            /// 自動櫃台預約
            /// </summary>
            [Display(Name = "自動櫃台預約")]
            [Description("34")]
            AutomaticCounterAppointment,

            /// <summary>
            /// IOS 掛號
            /// </summary>
            [Display(Name = "IOS 掛號")]
            [Description("35")]
            IosRegistration,

            /// <summary>
            /// Win8 掛號
            /// </summary>
            [Display(Name = "Win8 掛號")]
            [Description("36")]
            Win8Registration,

            /// <summary>
            /// Android 掛號
            /// </summary>
            [Display(Name = "Android 掛號")]
            [Description("37")]
            AndroidRegistration,

            /// <summary>
            /// LINE 掛號
            /// </summary>
            [Display(Name = "LINE 掛號")]
            [Description("38")]
            lineRegistration,

            /// <summary>
            /// 急診櫃台
            /// </summary>
            [Display(Name = "急診櫃台")]
            [Description("40")]
            EmergencyCounter,

            /// <summary>
            /// C肝特約診
            /// </summary>
            [Display(Name = "C肝特約診")]
            [Description("41")]
            SpecialAppointmentHepatitisC,

            /// <summary>
            /// COVID19醫師特約診
            /// </summary>
            [Display(Name = "COVID19醫師特約診")]
            [Description("42")]
            COVID19DoctorSpecialAppointment,

            /// <summary>
            /// 醫師預約
            /// </summary>
            [Display(Name = "醫師預約")]
            [Description("44")]
            DoctorAppointment,

            /// <summary>
            /// 無掛號批價
            /// </summary>
            [Display(Name = "無掛號批價")]
            [Description("50")]
            NoRegisteredPricing,

            /// <summary>
            /// 新陳代謝科CKD
            /// </summary>
            [Display(Name = "新陳代謝科CKD")]
            [Description("52")]
            CKD,

            /// <summary>
            /// 腎臟科AKD
            /// </summary>
            [Display(Name = "腎臟科AKD")]
            [Description("53")]
            AKD,

            /// <summary>
            /// 醫師預約特約診
            /// </summary>
            [Display(Name = "醫師預約特約診")]
            [Description("54")]
            DoctorAppointmentSpecialAppointment,

            /// <summary>
            /// 腎臟科Pre_ESRD
            /// </summary>
            [Display(Name = "腎臟科Pre_ESRD")]
            [Description("55")]
            Pre_ESRD,

            /// <summary>
            /// 健保藥事照護科CKD/AKD
            /// </summary>
            [Display(Name = "健保藥事照護科CKD/AKD")]
            [Description("56")]
            NHIPharmaceuticalCareDivisionCKDAKD,

            /// <summary>
            /// 急診轉科
            /// </summary>
            [Display(Name = "急診轉科")]
            [Description("60")]
            EmergencyTransfer,

            /// <summary>
            /// 急診轉區
            /// </summary>
            [Display(Name = "急診轉區")]
            [Description("61")]
            EmergencyTransferArea,

            /// <summary>
            /// HIS2急診掛號紀錄
            /// </summary>
            [Display(Name = "HIS2急診掛號紀錄")]
            [Description("62")]
            HIS2EmergencyRegistrationRecord,

            /// <summary>
            /// 網路預約掛號(舊版)
            /// </summary>
            [Display(Name = "網路預約掛號(舊版)")]
            [Description("64")]
            OldOnlineAppointmentRegistration,

            /// <summary>
            /// 網路預約掛號(新版)
            /// </summary>
            [Display(Name = "網路預約掛號(新版)")]
            [Description("65")]
            OnlineAppointmentRegistration,

            /// <summary>
            /// 同一療程
            /// </summary>
            [Display(Name = "同一療程")]
            [Description("70")]
            SameCourseTreatment,

            /// <summary>
            /// 網路初診掛號
            /// </summary>
            [Display(Name = "網路初診掛號")]
            [Description("74")]
            OnlineFirstRegistration,

            /// <summary>
            /// 網路現場掛號
            /// </summary>
            [Display(Name = "網路現場掛號")]
            [Description("75")]
            OnlineOnSiteRegistration,

            /// <summary>
            /// AIOTCenter
            /// </summary>
            [Display(Name = "AIOTCenter")]
            [Description("76")]
            AIOTCenter,

            /// <summary>
            /// 遠距醫療會診
            /// </summary>
            [Display(Name = "遠距醫療會診")]
            [Description("77")]
            TelemedicineConsultation,

            /// <summary>
            /// 共病LTBI篩檢
            /// </summary>
            [Display(Name = "共病LTBI篩檢")]
            [Description("78")]
            Comorbid_LTBI_Screening,

            /// <summary>
            /// 共病LTBI治療
            /// </summary>
            [Display(Name = "共病LTBI治療")]
            [Description("79")]
            Comorbid_LTBI_Treatment,

            /// <summary>
            /// 連續處方
            /// </summary>
            [Display(Name = "連續處方")]
            [Description("80")]
            ContinuousPrescription,

            /// <summary>
            /// 委託代檢
            /// </summary>
            [Display(Name = "委託代檢")]
            [Description("90")]
            EntrustInspectionAgency,

            /// <summary>
            /// 批次掛號
            /// </summary>
            [Display(Name = "批次掛號")]
            [Description("AA")]
            BatchRegistration,

            /// <summary>
            /// 子宮頸抹片篩檢掛號
            /// </summary>
            [Display(Name = "子宮頸抹片篩檢掛號")]
            [Description("AB")]
            PapSmearScreeningRegistration,

            /// <summary>
            /// 乳癌篩檢掛號
            /// </summary>
            [Display(Name = "乳癌篩檢掛號")]
            [Description("AC")]
            BreastCancerScreeningRegistration,

            /// <summary>
            /// 大腸直腸癌篩檢掛號
            /// </summary>
            [Display(Name = "大腸直腸癌篩檢掛號")]
            [Description("AD")]
            ColorectalCancerScreeningRegistration,

            /// <summary>
            /// 口腔癌篩檢掛號
            /// </summary>
            [Display(Name = "口腔癌篩檢掛號")]
            [Description("AE")]
            OralCancerScreeningRegistration,

            /// <summary>
            /// 病人特別門診
            /// </summary>
            [Display(Name = "病人特別門診")]
            [Description("SP")]
            SpecialPatientClinic,

        }

        #endregion

        #region OsVersion
        /// <summary>
        /// 作業系統代碼(Windows 非伺服器版本)
        /// </summary>
        public enum OsVersion
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            Null = 0,
            /// <summary>
            /// 無法識別之作業系統版本
            /// </summary>
            [Display(Name = "無法識別之作業系統版本")]
            UnknownOsVersion = 1,
            /// <summary>
            /// 版本低於Win2000(Win98, WinNT...等
            /// </summary>
            [Display(Name = "低於 Windows 2000")]
            LessThanWin2000 = 2,
            /// <summary>
            /// Win2000
            /// </summary>
            [Display(Name = "Windows 2000")]
            Win2000 = 3,
            /// <summary>
            /// Windows XP 64位元
            /// </summary>
            [Display(Name = "Windows XP 64位元")]
            WinXPx64 = 4,
            /// <summary>
            /// Windows XP 32位元
            /// </summary>
            [Display(Name = "Windows XP 32位元")]
            WinXPx86 = 5,
            /// <summary>
            /// Windows Vista
            /// </summary>
            [Display(Name = "Windows Vista")]
            WinVista = 6,
            /// <summary>
            /// Windows 7
            /// </summary>
            [Display(Name = "Windows 7")]
            Win7 = 7,
            /// <summary>
            /// Windows 8
            /// </summary>
            [Display(Name = "Windows 8")]
            Win8 = 8,
            /// <summary>
            /// Windows 8.1
            /// </summary>
            [Display(Name = "Windows 8.1")]
            Win8_1 = 9,
            /// <summary>
            /// Windows 10
            /// </summary>
            [Display(Name = "Windows 10")]
            Win10 = 10,
            /// <summary>
            /// Windows 11
            /// </summary>
            [Display(Name = "Windows 11")]
            Win11 = 11,
            /// <summary>
            /// Windows 12
            /// </summary>
            [Display(Name = "Windows 12")]
            Win12 = 12,

        }
        #endregion OsVersion

        #region HeavySickSystem_ID
        /// <summary>
        /// 重大傷病 寫入系統別(字元上限20)
        /// </summary>
        public enum HeavySickSystem_ID
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            Null,
            /// <summary>
            /// 轉檔系統
            /// </summary>
            [Display(Name = "轉檔系統")]
            Data_Transfer,
            /// <summary>
            /// 門診診間系統_身分確認_紙本
            /// </summary>
            [Display(Name = "診間紙本")]
            OPD_CR_Paper,
            /// <summary>
            /// 門診診間系統_身分確認_IC卡讀出
            /// </summary>
            [Display(Name = "診間IC卡")]
            OPD_CR_ICCard,
            /// <summary>
            /// 急診_批價_IC卡讀出
            /// </summary>
            [Display(Name = "急診批價IC卡")]
            ER_Cashier,
            /// <summary>
            /// 門診_批價_IC卡讀出
            /// </summary>
            [Display(Name = "門診批價IC卡")]
            OPD_Cashier,
            /// <summary>
            /// 急診_批價_紙本
            /// </summary>
            [Display(Name = "急診批價紙本")]
            ER_Cashier_Paper,
            /// <summary>
            /// 門診_批價_紙本
            /// </summary>
            [Display(Name = "門診批價紙本")]
            OPD_Cashier_Paper,
            /// <summary>
            /// 門診健保署雲端匯入
            /// </summary>
            [Display(Name = "門診雲端匯入")]
            OPD_CR_NHICloud,
            /// <summary>
            /// 住院健保卡
            /// </summary>
            [Display(Name = "住院健保卡")] 
            INP_ICCard,
            /// <summary>
            /// 住院紙本
            /// </summary>
            [Display(Name = "住院紙本")] 
            INP_Paper,
        }
        #endregion HeavySickSystem_ID

        #region PPFTYPE
        /// <summary>
        /// 提成類別
        /// ORDERCODEMASTER.PPFTYPE
        /// </summary>
        public enum PPFTYPE
        {
            /// <summary>
            /// 預設數值
            /// </summary>
            [Display(Name = "預設數值")]
            Null = 99,
            /// <summary>
            /// 醫院提成
            /// </summary>
            [Display(Name = "醫院提成")]
            Hospital = 0,
            /// <summary>
            /// 主治醫生提成
            /// </summary>
            [Display(Name = "主治醫生提成")]
            VsDoctor = 1,
            /// <summary>
            /// 主治醫生或科室提成
            /// </summary>
            [Display(Name = "主治醫生或科室提成")]
            VsDoctorOrDept = 2,
            /// <summary>
            /// 科室提成
            /// </summary>
            [Display(Name = "科室提成")]
            Dept = 3,

        }
        #endregion PPFTYPE

        #region 診間 特殊掛號身分
        /// <summary>
        /// 診間 特殊掛號身分
        /// </summary>
        public enum OPD_ClinicRoom_SpecialRegister
        {
            /// <summary>
            /// 預設值
            /// </summary>
            NULL,
            /// <summary>
            /// 子宮頸篩檢 IC31
            /// </summary>
            [Display(Name = "使用子宮頸篩檢IC31身分別")]
            IC31,
            /// <summary>
            /// 大腸篩檢 IC85
            /// </summary>
            [Display(Name = "使用大腸篩檢IC85身分別")]
            IC85,
            /// <summary>
            /// 乳房篩檢 IC91
            /// </summary>
            [Display(Name = "使用乳房篩檢IC91身分別")]
            IC91,
            /// <summary>
            /// 大腸篩檢-糞便潛血 IC94
            /// </summary>
            [Display(Name = "使用大腸篩檢IC94身分別")]
            IC94,
            /// <summary>
            /// 口腔篩檢 IC95
            /// </summary>
            [Display(Name = "使用口腔篩檢IC95身分別")]
            IC95,
            /// <summary>
            /// 使用LBTI篩檢 78
            /// </summary>
            [Display(Name = "使用LBTI篩檢")]
            LBTIScreening,
            /// <summary>
            /// 使用LBTI治療 79
            /// </summary>
            [Display(Name = "使用LBTI治療")]
            LBTITreatment,
        }
        /// <summary>
        /// 門診身分確認 特殊規則 不計算身分別(直接載入掛號身分別)
        /// Enum命名規則(_科別_身分別NAME+VALUE_備註):_[DEPT]_[KIND][KIND_VALUE]_[NOTE]
        /// </summary>
        public enum OPD_IdentityVerifitation_SpecialMethodWhitoutCalcID
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "")]
            [Description("")]
            Null,
            /// <summary>
            /// 產科 307 VIPID 107
            /// </summary>
            [Display(Name = "產科特殊優待類別")]
            [Description("")]
            _307_VIPID107,
            /// <summary>
            /// 流感疫苗門診 117,118
            /// </summary>
            [Display(Name = "流感疫苗門診")]
            [Description("")]
            _117118_Flu,
            /// <summary>
            /// 916長照結核計畫身分
            /// </summary>
            [Display(Name = "916長照結核計畫身分")]
            [Description("")]
            _TB_PAYTYPE916,
        }
        #endregion 診間 特殊掛號身分

        #region 住院 IPD

        #region INACARM.GOVERBUDGETCODE
        /// <summary>
        /// 住院IPD主表 INACARM.GOVERBUDGETCODE 身分別
        /// </summary>
        public enum INACARM_GOVERBUDGETCODE
        {
            /// <summary>
            /// 預設數值
            /// </summary>
            NULL,
            /// <summary>
            /// 公務預算病患, (預留)
            /// </summary>
            Y,
            /// <summary>
            /// 自費護理之家病患
            /// </summary>
            C,
            /// <summary>
            /// 一般病患(健保、自費)
            /// </summary>
            N,
        }

        #endregion

        #endregion

        #region HOMECARE_LOG KIND
        /// <summary>
        /// HomeCare_LOG.KIND (Enum.Description為對應之TableName)
        /// </summary>
        public enum HOMECARE_LOG_KIND
        {
            /// <summary>
            /// 初始化
            /// </summary>
            NULL,
            /// <summary>
            /// LOG_APPLICATION_INFO
            /// </summary>
            [Description("LOG_APPLICATION_INFO")]
            INFO,
            /// <summary>
            /// LOG_APPLICATION_DEBUG
            /// </summary>
            [Description("LOG_APPLICATION_DEBUG")]
            DEBUG,
            /// <summary>
            /// LOG_APPLICATION_ERROR
            /// </summary>
            [Description("LOG_APPLICATION_ERROR")]
            ERROR
        }


        #endregion

        #region R00
        /// <summary>
        /// 虛擬醫令代碼 20240701建立 (R00X)
        /// </summary>
        public enum VirtualMedicalOrderCode
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("")]
            Null,
            /// <summary>
            /// 慢箋, 重複藥物, 藥費核扣檢核結果(按Ctrl可多選)
            /// </summary>
            [Display(Name = "慢箋, 重複藥物, 藥費核扣檢核結果(按Ctrl可多選)")]
            [Description("")]
            Source,
            /// <summary>
            /// R001:因處方箋遺失或損毀，提供切結文件，提前回診，且經院所查詢健保雲端藥歷系統，確認病人未領取所稱遺失或毀損處方之藥品
            /// </summary>
            [Display(Name = "因處方箋遺失或損毀，提供切結文件，提前回診，且經院所查詢健保雲端藥歷系統，確認病人未領取所稱遺失或毀損處方之藥品")]
            [Description("")]
            R001,
            /// <summary>
            /// R002:因醫師請假因素，提前回診，醫事服務暨購留存醫師請假證明資料備查
            /// </summary>
            [Display(Name = "因醫師請假因素，提前回診，醫事服務暨購留存醫師請假證明資料備查")]
            [Description("")]
            R002,
            /// <summary>
            /// R003:經醫師專業認定需要改藥或調整藥品劑量或換藥者
            /// </summary>
            [Display(Name = "經醫師專業認定需要改藥或調整藥品劑量或換藥者")]
            [Description("")]
            R003,
            /// <summary>
            /// R004:其他非屬R001~R003之提前回診或慢性病連續處方箋提前領取藥品或其他等病人因素，提供切結文件或於病歷中詳細記載原因備查
            /// </summary>
            [Display(Name = "其他非屬R001~R003之提前回診或慢性病連續處方箋提前領取藥品或其他等病人因素，提供切結文件或於病歷中詳細記載原因備查")]
            [Description("")]
            R004,
            /// <summary>
            /// R005:民眾健保卡加密或其他健保卡問題致無法查詢健保雲端資訊，並於病歷中記載原因備查
            /// </summary>
            [Display(Name = "民眾健保卡加密或其他健保卡問題致無法查詢健保雲端資訊，並於病歷中記載原因備查")]
            [Description("")]
            R005,
            /// <summary>
            /// R006:醫院轉出(或回轉)病人至診所第1次就醫且符合轉診申報規定，經查詢雲端藥歷系統有餘藥，已向病人衛教並於病歷中詳細記載原因備查後處方
            /// </summary>
            [Display(Name = "醫院轉出(或回轉)病人至診所第1次就醫且符合轉診申報規定，經查詢雲端藥歷系統有餘藥，已向病人衛教並於病歷中詳細記載原因備查後處方")]
            [Description("")]
            R006,
            /// <summary>
            /// R007:配合衛福部食品藥物管理署公告藥品回收，重新開立處方給病人，並於病歷中記載原因備查
            /// 114/07/09，新增調整 R007版
            /// </summary>
            [Display(Name = "病人因不可抗力或不可歸責之事由致藥品遺失、損毀或無法使用(如配合衛生福利部食品藥物管理署公告藥品回收)，重新開立處方給病人並於病歷中記載原因備查")]
            [Description("")]
            R007,
            /// <summary>
            /// R008:醫師查詢雲端或API系統提示病人有重複用藥情事，經向病人確認後排除未領藥紀錄，其餘藥天數小於(含)10天開立處方，並於病歷中詳細記載原因備查
            /// </summary>
            [Display(Name = "醫師查詢雲端或API系統提示病人有重複用藥情事，經向病人確認後排除未領藥紀錄，其餘藥天數小於(含)10天開立處方，並於病歷中詳細記載原因備查")]
            [Description("")]
            R008,
        }


        #endregion

        #region ICCARD DNR

        /// <summary>
        /// IC Card DNR 
        /// </summary>
        public enum IcDnrCode
        {
            /// <summary>
            /// 查無資料 0
            /// </summary>
            [Display(Name = "查無資料")]
            [Description("0")]
            Null = 0,
            /// <summary>
            /// 同意器官捐贈 1
            /// </summary>
            [Display(Name = "同意器官捐贈。")]
            [Description("1")]
            ConsentToOrganDonation = 1,
            /// <summary>
            /// 同意安寧緩和醫療 2
            /// </summary>
            [Display(Name = "同意安寧緩和醫療。")]
            [Description("2")]
            AgreeToPeaceAndEaseMedicalCare = 2,
            /// <summary>
            /// 同意不施行心肺復甦術 3
            /// </summary>
            [Display(Name = "同意不施行心肺復甦術。")]
            [Description("3")]
            AgreeNotToImplementCPR = 3,
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療。(舊)。 4
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療。(舊)。")]
            [Description("4")]
            AgreeOrganDonationAndPeaceEaseMedicalCareAndLifeSavingNotCPR = 4,
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療。 5
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療。")]
            [Description("5")]
            AgreeOrganDonationAndPeaceEaseMedicalCare = 5,
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行心肺復甦術 6
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行心肺復甦術。")]
            [Description("6")]
            AgreeOrganDonationNotCPR = 6,
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療。(舊) 7
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療。(舊)。")]
            [Description("7")]
            AgreeOrganDonationAndPeaceEaseMedicalCareNotLifeSavingNotCPR = 7,
            /// <summary>
            /// 同意不施行維生醫療 A
            /// </summary>
            [Display(Name = "同意不施行維生醫療。")]
            [Description("A")]
            AgreeNotLifeSaving = 65,        //ASCII A
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行維生醫療 B
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行維生醫療。")]
            [Description("B")]
            AgreeOrganDonationNotLifeSaving = 66,        //ASCII B
            /// <summary>
            /// 同意安寧緩和醫療 C
            /// </summary>
            [Display(Name = "同意安寧緩和醫療\r\n同意不施行維生醫療。")]
            [Description("C")]
            AgreePeaceEaseMedicalCareNotLifeSaving = 67,        //ASCII C
            /// <summary>
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療 D
            /// </summary>
            [Display(Name = "同意不施行心肺復甦術、\r\n同意不施行維生醫療。")]
            [Description("D")]
            AgreeNotCPRNotLifeSaving = 68,        //ASCII D
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療 E
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療。")]
            [Description("E")]
            AgreeOragonDonationPeaceEaseMedicalCareNotCPRNotLifeSaving = 69,        //ASCII E
            /// <summary>
            /// 同意器官卷贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行維生醫療 F
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行維生醫療。")]
            [Description("F")]
            AgreeOragonDonationPeaceEaseMedicalCareNotLifeSaving = 70,        //ASCII F
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療 G
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療。")]
            [Description("G")]
            AgreeOragonDonationNotCPRNotLifeSaving = 71,        //ASCII G
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療 H
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療。")]
            [Description("H")]
            AgreePeaceEaseMedicalCareNotCPRNotLifeSaving = 72,        //ASCII H
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術。 I
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行心肺復甦術。")]
            [Description("I")]
            AgreeOragonDonationPeaceEaseMedicalCareNotCPR = 73,        //ASCII I
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術。 J
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行心肺復甦術。")]
            [Description("J")]
            AgreePeaceEaseMedicalCareNotCPR = 74,        //ASCII J
            /// <summary>
            /// 同意預立醫療決定 K
            /// </summary>
            [Display(Name = "同意預立醫療決定。")]
            [Description("K")]
            AgreeK = 75,        //ASCII K
            /// <summary>
            /// 同意器官捐贈、
            /// 同意預立醫療決定 L
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意預立醫療決定。")]
            [Description("L")]
            AgreeL = 76,        //ASCII L
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意預立醫療決定 M
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意預立醫療決定。")]
            [Description("M")]
            AgreeM = 77,        //ASCII M
            /// <summary>
            /// 同意不施行心肺復甦術、
            /// 同意預立醫療決定 N
            /// </summary>
            [Display(Name = "同意不施行心肺復甦術、\r\n同意預立醫療決定。")]
            [Description("N")]
            AgreeN = 78,        //ASCII N
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意預立醫療決定 O
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意預立醫療決定。")]
            [Description("O")]
            AgreeO = 79,        //ASCII O
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意預立醫療決定 P
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意預立醫療決定。")]
            [Description("P")]
            AgreeP = 80,        //ASCII P
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行心肺復甦術、
            /// 同意預立醫療決定 Q 
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行心肺復甦術、\r\n同意預立醫療決定。")]
            [Description("Q")]
            AgreeQ = 81,        //ASCII Q
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意預立醫療決定 R
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意預立醫療決定。")]
            [Description("R")]
            AgreeR = 82,        //ASCII R
            /// <summary>
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定 S
            /// </summary>
            [Display(Name = "同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("S")]
            AgreeS = 83,        //ASCII S
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定 T
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("T")]
            AgreeT = 84,        //ASCII T
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定 U
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("U")]
            AgreeU = 85,        //ASCII U
            /// <summary>
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定 V
            /// </summary>
            [Display(Name = "同意不施行心肺復甦術、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("V")]
            AgreeV = 86,        //ASCII V
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定 W 
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("W")]
            AgreeW = 87,        //ASCII W
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定。 X
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("X")]
            AgreeX = 88,        //ASCII X
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定。 Y
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("Y")]
            AgreeY = 89,        //ASCII Y
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定。 Z
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("Z")]
            AgreeZ = 90,        //ASCII Z
        }

        #endregion

        #region ISBU 補卡註記
        /// <summary>
        /// 健保卡 補卡註記(可使用ToNumberString(),GetEnumDescription())
        /// </summary>
        public enum IsBu
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            [Description("0")]
            None = 0,
            /// <summary>
            /// 正常
            /// </summary>
            [Display(Name = "正常")]
            [Description("1")]
            Normal = 1,
            /// <summary>
            /// 補卡
            /// </summary>
            [Display(Name = "補卡")]
            [Description("2")]
            ReIssueCard = 2,
            /// <summary>
            /// 新生兒無身分證號補卡:限出生日期&gt;60日且&lt;=92日
            /// </summary>
            [Display(Name = "新生兒無身分證號補卡:限出生日期>60日且<=92日")]
            [Description("3")]
            NewBornWithoutCard = 3,
            /// <summary>
            /// 無實際就醫識別碼補卡(需登錄及報備):路倒或其他於就醫時無法取得身分字號時使用
            /// </summary>
            [Display(Name = "無實際就醫識別碼補卡(需登錄及報備):路倒或其他於就醫時無法取得身分字號時使用")]
            [Description("4")]
            UnkonwnMedidentificationCode = 4,
        }


        #endregion

        #region 新生兒就醫註記
        /// <summary>
        /// 新生兒就醫註記; 
        /// [性別] [胞胎數] [順位] [數值];
        /// Display.Name="[性別] [胞胎數]",Display.Description="[胞胎數]", Display.GroupName="[性別]", Description="[順位]"
        /// </summary>
        public enum BabyTreatment
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            [Description("0")]
            None,

            /// <summary>
            /// 男 單胞胎 1 A
            /// </summary>
            [Display(Name = "男 單胞胎", Description = "單胞胎", GroupName = "男")]
            [Description("1")]
            A,

            /// <summary>
            /// 女 單胞胎 1 a
            /// </summary>
            [Display(Name = "女 單胞胎", Description = "單胞胎", GroupName = "男")]
            [Description("1")]
            a,

            /// <summary>
            /// 男 雙胞胎 2 B
            /// </summary>
            [Display(Name = "男 雙胞胎", Description = "雙胞胎", GroupName = "男")]
            [Description("2")]
            B,

            /// <summary>
            /// 女 雙胞胎 2 b
            /// </summary>
            [Display(Name = "女 雙胞胎", Description = "雙胞胎", GroupName = "男")]
            [Description("2")]
            b,

            /// <summary>
            /// 男 3胞胎 3 C
            /// </summary>
            [Display(Name = "男 3胞胎", Description = "3胞胎", GroupName = "男")]
            [Description("3")]
            C,

            /// <summary>
            /// 女 3胞胎 3 c
            /// </summary>
            [Display(Name = "女 3胞胎", Description = "3胞胎", GroupName = "男")]
            [Description("3")]
            c,

            /// <summary>
            /// 男 4胞胎 4 D
            /// </summary>
            [Display(Name = "男 4胞胎", Description = "4胞胎", GroupName = "男")]
            [Description("4")]
            D,

            /// <summary>
            /// 女 4胞胎 4 d
            /// </summary>
            [Display(Name = "女 4胞胎", Description = "4胞胎", GroupName = "男")]
            [Description("4")]
            d,

            /// <summary>
            /// 男 5胞胎 5 E
            /// </summary>
            [Display(Name = "男 5胞胎", Description = "5胞胎", GroupName = "男")]
            [Description("5")]
            E,

            /// <summary>
            /// 女 5胞胎 5 e
            /// </summary>
            [Display(Name = "女 5胞胎", Description = "5胞胎", GroupName = "男")]
            [Description("5")]
            e,

            /// <summary>
            /// 男 6胞胎 6 F
            /// </summary>
            [Display(Name = "男 6胞胎", Description = "6胞胎", GroupName = "男")]
            [Description("6")]
            F,

            /// <summary>
            /// 女 6胞胎 6 f
            /// </summary>
            [Display(Name = "女 6胞胎", Description = "6胞胎", GroupName = "男")]
            [Description("6")]
            f,

            /// <summary>
            /// 男 7胞胎 7 G
            /// </summary>
            [Display(Name = "男 7胞胎", Description = "7胞胎", GroupName = "男")]
            [Description("7")]
            G,

            /// <summary>
            /// 女 7胞胎 7 g
            /// </summary>
            [Display(Name = "女 7胞胎", Description = "7胞胎", GroupName = "男")]
            [Description("7")]
            g,

            /// <summary>
            /// 男 8胞胎 8 H
            /// </summary>
            [Display(Name = "男 8胞胎", Description = "8胞胎", GroupName = "男")]
            [Description("8")]
            H,

            /// <summary>
            /// 女 8胞胎 8 h
            /// </summary>
            [Display(Name = "女 8胞胎", Description = "8胞胎", GroupName = "男")]
            [Description("8")]
            h,

            /// <summary>
            /// 男 9胞胎 9 I
            /// </summary>
            [Display(Name = "男 9胞胎", Description = "9胞胎", GroupName = "男")]
            [Description("9")]
            I,

            /// <summary>
            /// 女 9胞胎 9 i
            /// </summary>
            [Display(Name = "女 9胞胎", Description = "9胞胎", GroupName = "男")]
            [Description("9")]
            i,

            /// <summary>
            /// 男 10胞胎 10 J
            /// </summary>
            [Display(Name = "男 10胞胎", Description = "10胞胎", GroupName = "男")]
            [Description("10")]
            J,

            /// <summary>
            /// 女 10胞胎 10 j
            /// </summary>
            [Display(Name = "女 10胞胎", Description = "10胞胎", GroupName = "男")]
            [Description("10")]
            j,

            /// <summary>
            /// 男 11胞胎 11 K
            /// </summary>
            [Display(Name = "男 11胞胎", Description = "11胞胎", GroupName = "男")]
            [Description("11")]
            K,

            /// <summary>
            /// 女 11胞胎 11 k
            /// </summary>
            [Display(Name = "女 11胞胎", Description = "11胞胎", GroupName = "男")]
            [Description("11")]
            k,

            /// <summary>
            /// 男 12胞胎 12 L
            /// </summary>
            [Display(Name = "男 12胞胎", Description = "12胞胎", GroupName = "男")]
            [Description("12")]
            L,

            /// <summary>
            /// 女 12胞胎 12 l
            /// </summary>
            [Display(Name = "女 12胞胎", Description = "12胞胎", GroupName = "男")]
            [Description("12")]
            l,

            /// <summary>
            /// 男 13胞胎 13 M
            /// </summary>
            [Display(Name = "男 13胞胎", Description = "13胞胎", GroupName = "男")]
            [Description("13")]
            M,

            /// <summary>
            /// 女 13胞胎 13 m
            /// </summary>
            [Display(Name = "女 13胞胎", Description = "13胞胎", GroupName = "男")]
            [Description("13")]
            m,

            /// <summary>
            /// 男 14胞胎 14 N
            /// </summary>
            [Display(Name = "男 14胞胎", Description = "14胞胎", GroupName = "男")]
            [Description("14")]
            N,

            /// <summary>
            /// 女 14胞胎 14 n
            /// </summary>
            [Display(Name = "女 14胞胎", Description = "14胞胎", GroupName = "男")]
            [Description("14")]
            n,

            /// <summary>
            /// 男 15胞胎 15 O
            /// </summary>
            [Display(Name = "男 15胞胎", Description = "15胞胎", GroupName = "男")]
            [Description("15")]
            O,

            /// <summary>
            /// 女 15胞胎 15 o
            /// </summary>
            [Display(Name = "女 15胞胎", Description = "15胞胎", GroupName = "男")]
            [Description("15")]
            o,

            /// <summary>
            /// 男 16胞胎 16 P
            /// </summary>
            [Display(Name = "男 16胞胎", Description = "16胞胎", GroupName = "男")]
            [Description("16")]
            P,

            /// <summary>
            /// 女 16胞胎 16 p
            /// </summary>
            [Display(Name = "女 16胞胎", Description = "16胞胎", GroupName = "男")]
            [Description("16")]
            p,

            /// <summary>
            /// 男 17胞胎 17 Q
            /// </summary>
            [Display(Name = "男 17胞胎", Description = "17胞胎", GroupName = "男")]
            [Description("17")]
            Q,

            /// <summary>
            /// 女 17胞胎 17 q
            /// </summary>
            [Display(Name = "女 17胞胎", Description = "17胞胎", GroupName = "男")]
            [Description("17")]
            q,

            /// <summary>
            /// 男 18胞胎 18 R
            /// </summary>
            [Display(Name = "男 18胞胎", Description = "18胞胎", GroupName = "男")]
            [Description("18")]
            R,

            /// <summary>
            /// 女 18胞胎 18 r
            /// </summary>
            [Display(Name = "女 18胞胎", Description = "18胞胎", GroupName = "男")]
            [Description("18")]
            r,

            /// <summary>
            /// 男 19胞胎 19 S
            /// </summary>
            [Display(Name = "男 19胞胎", Description = "19胞胎", GroupName = "男")]
            [Description("19")]
            S,

            /// <summary>
            /// 女 19胞胎 19 s
            /// </summary>
            [Display(Name = "女 19胞胎", Description = "19胞胎", GroupName = "男")]
            [Description("19")]
            s,

            /// <summary>
            /// 男 20胞胎 20 T
            /// </summary>
            [Display(Name = "男 20胞胎", Description = "20胞胎", GroupName = "男")]
            [Description("20")]
            T,

            /// <summary>
            /// 女 20胞胎 20 t
            /// </summary>
            [Display(Name = "女 20胞胎", Description = "20胞胎", GroupName = "男")]
            [Description("20")]
            t,

            /// <summary>
            /// 男 21胞胎 21 U
            /// </summary>
            [Display(Name = "男 21胞胎", Description = "21胞胎", GroupName = "男")]
            [Description("21")]
            U,

            /// <summary>
            /// 女 21胞胎 21 u
            /// </summary>
            [Display(Name = "女 21胞胎", Description = "21胞胎", GroupName = "男")]
            [Description("21")]
            u,

            /// <summary>
            /// 男 22胞胎 22 V
            /// </summary>
            [Display(Name = "男 22胞胎", Description = "22胞胎", GroupName = "男")]
            [Description("22")]
            V,

            /// <summary>
            /// 女 22胞胎 22 v
            /// </summary>
            [Display(Name = "女 22胞胎", Description = "22胞胎", GroupName = "男")]
            [Description("22")]
            v,

            /// <summary>
            /// 男 23胞胎 23 W
            /// </summary>
            [Display(Name = "男 23胞胎", Description = "23胞胎", GroupName = "男")]
            [Description("23")]
            W,

            /// <summary>
            /// 女 23胞胎 23 w
            /// </summary>
            [Display(Name = "女 23胞胎", Description = "23胞胎", GroupName = "男")]
            [Description("23")]
            w,

            /// <summary>
            /// 男 24胞胎 24 X
            /// </summary>
            [Display(Name = "男 24胞胎", Description = "24胞胎", GroupName = "男")]
            [Description("24")]
            X,

            /// <summary>
            /// 女 24胞胎 24 x
            /// </summary>
            [Display(Name = "女 24胞胎", Description = "24胞胎", GroupName = "男")]
            [Description("24")]
            x,

            /// <summary>
            /// 男 25胞胎 25 Y
            /// </summary>
            [Display(Name = "男 25胞胎", Description = "25胞胎", GroupName = "男")]
            [Description("25")]
            Y,

            /// <summary>
            /// 女 25胞胎 25 y
            /// </summary>
            [Display(Name = "女 25胞胎", Description = "25胞胎", GroupName = "男")]
            [Description("25")]
            y,

            /// <summary>
            /// 男 26胞胎 26 Z
            /// </summary>
            [Display(Name = "男 26胞胎", Description = "26胞胎", GroupName = "男")]
            [Description("26")]
            Z,

            /// <summary>
            /// 女 26胞胎 26 z
            /// </summary>
            [Display(Name = "女 26胞胎", Description = "26胞胎", GroupName = "男")]
            [Description("26")]
            z,
        }


        #endregion

        #region MEDCLOUD Name
        /// <summary>
        /// 雲端藥歷名稱
        /// </summary>
        public enum MedCloudName
        {
            [Display(Name = "")]
            NULL,
            [Display(Name = "雲端藥歷")]
            MEDCLOUD01,
            [Display(Name = "檢驗檢查")]
            MEDCLOUD02,
            [Display(Name = "手術紀錄")]
            MEDCLOUD03,
            [Display(Name = "牙科處置")]
            MEDCLOUD04,
            [Display(Name = "過敏藥")]
            MEDCLOUD05,
            [Display(Name = "檢驗檢查結果")]
            MEDCLOUD06,
            [Display(Name = "出院病摘")]
            MEDCLOUD07,
            [Display(Name = "復健醫療")]
            MEDCLOUD08,
            [Display(Name = "中藥用藥")]
            MEDCLOUD09,
            [Display(Name = "旅遊接觸")]
            MEDCLOUD10,
            [Display(Name = "新冠肺炎檢驗結果")]
            MEDCLOUD11,
        }


        #endregion

        #region BELONGCODE
        /// <summary>
        /// 軍眷警消海空身分代碼 20240719 建立
        /// </summary>
        public enum BelongCode
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            [Description("")]
            Null,
            /// <summary>
            /// 軍眷
            /// </summary>
            [Display(Name = "軍眷")]
            [Description("E")]
            E,
            /// <summary>
            /// 海巡署
            /// </summary>
            [Display(Name = "海巡署")]
            [Description("J")]
            J,
            /// <summary>
            /// 警察大學
            /// </summary>
            [Display(Name = "警察大學")]
            [Description("K")]
            K,
            /// <summary>
            /// 消防
            /// </summary>
            [Display(Name = "消防")]
            [Description("L")]
            L,
            /// <summary>
            /// 空勤總隊
            /// </summary>
            [Display(Name = "空勤總隊")]
            [Description("M")]
            M,
            /// <summary>
            /// 警察
            /// </summary>
            [Display(Name = "警察")]
            [Description("N")]
            N,
            /// <summary>
            /// 移民署
            /// </summary>
            [Display(Name = "移民署")]
            [Description("P")]
            P,
        }


        #endregion

        #region FIDRELA
        /// <summary>
        /// HISMEDD.FIDRELA 員工眷屬關係代碼
        /// </summary>
        public enum Fidrela
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("0")]
            Null = 0,
            /// <summary>
            /// 子女 1
            /// </summary>
            [Display(Name = "子女")]
            [Description("1")]
            Children = 1,
            /// <summary>
            /// 父母 2
            /// </summary>
            [Display(Name = "父母")]
            [Description("2")]
            Parents = 2,
            /// <summary>
            /// 本人 3
            /// </summary>
            [Display(Name = "本人")]
            [Description("3")]
            Self = 3,
            /// <summary>
            /// 祖父母 4
            /// </summary>
            [Display(Name = "祖父母")]
            [Description("4")]
            Grandparents = 4,
            /// <summary>
            /// 配偶 5
            /// </summary>
            [Display(Name = "配偶")]
            [Description("5")]
            Spouse = 5
        }
        #endregion FIDRELA

        #region NHI ICCard hisGetCardStatus
        /// <summary>
        /// hisGetCardStatus (讀取卡片狀態)
        /// [Display.Name = 狀態文字, Display.Order=(int)CardType, Dislay.AutoGenerateField=[True:卡片驗證完成, False:卡片驗證失敗], Description=健保函式回傳數字
        /// [CardType:1安全模組檔,2:健保IC卡3:醫事人員卡]
        /// </summary>
        public enum hisGetCardStatus_CardStatus
        {
            /// <summary>
            /// 預設數值
            /// </summary>
            [Display(Name = "預設數值", AutoGenerateField = false, Order = 0)]
            [Description("-1")]
            NULL,
            #region SAM
            /// <summary>
            /// 安全模組檔 4000
            /// </summary>
            [Display(Name = "讀卡機TimeOut", AutoGenerateField = false, Order = 1)]
            [Description("4000")]
            SAM_4000,
            /// <summary>
            /// 安全模組檔 0 卡片未置入
            /// </summary>
            [Display(Name = "卡片未置入", AutoGenerateField = false, Order = 1)]
            [Description("0")]
            SAM_0,
            /// <summary>
            /// 安全模組檔 1 安全模組尚未與健保局IDC認證
            /// </summary>
            [Display(Name = "安全模組尚未與健保局IDC認證", AutoGenerateField = false, Order = 1)]
            [Description("1")]
            SAM_1,
            /// <summary>
            /// 安全模組檔 2 安全模組與健保局IDC認證成功
            /// </summary>
            [Display(Name = "安全模組與健保局IDC認證成功", AutoGenerateField = true, Order = 1)]
            [Description("2")]
            SAM_2,
            /// <summary>
            /// 安全模組檔 9 所置入非安全模組檔
            /// </summary>
            [Display(Name = "所置入非安全模組檔", AutoGenerateField = false, Order = 1)]
            [Description("9")]
            SAM_9,

            #endregion

            #region HC

            /// <summary>
            /// 健保IC卡 4000
            /// </summary>
            [Display(Name = "讀卡機TimeOut", AutoGenerateField = false, Order = 2)]
            [Description("4000")]
            HC_4000,
            /// <summary>
            /// 健保IC卡 0 卡片未置入
            /// </summary>
            [Display(Name = "卡片未置入", AutoGenerateField = false, Order = 2)]
            [Description("0")]
            HC_0,
            /// <summary>
            /// 健保IC卡 1 健保IC卡尚未與安全模組認證
            /// </summary>
            [Display(Name = "健保IC卡尚未與安全模組認證", AutoGenerateField = false, Order = 2)]
            [Description("1")]
            HC_1,
            /// <summary>
            /// 健保IC卡 2 健保IC卡與安全模組認證成功
            /// </summary>
            [Display(Name = "健保IC卡與安全模組認證成功", AutoGenerateField = true, Order = 2)]
            [Description("2")]
            HC_2,
            /// <summary>
            /// 健保IC卡 3 健保IC卡與醫事人員卡認證成功
            /// </summary>
            [Display(Name = "健保IC卡與醫事人員卡認證成功", AutoGenerateField = true, Order = 2)]
            [Description("3")]
            HC_3,
            /// <summary>
            /// 健保IC卡 4 健保IC卡PIN認證成功
            /// </summary>
            [Display(Name = "健保IC卡PIN認證成功", AutoGenerateField = true, Order = 2)]
            [Description("4")]
            HC_4,
            /// <summary>
            /// 健保IC卡 5 健保IC卡與健保局IDC認證成功
            /// </summary>
            [Display(Name = "健保IC卡與健保局IDC認證成功", AutoGenerateField = true, Order = 2)]
            [Description("5")]
            HC_5,
            /// <summary>
            /// 健保IC卡 9 所置入非健保IC卡
            /// </summary>
            [Display(Name = "所置入非健保IC卡", AutoGenerateField = false, Order = 2)]
            [Description("9")]
            HC_9,
            #endregion

            #region HPC

            /// <summary>
            /// 醫事人員卡 4000
            /// </summary>
            [Display(Name = "讀卡機TimeOut", AutoGenerateField = false, Order = 3)]
            [Description("4000")]
            HCP_4000,
            /// <summary>
            /// 醫事人員卡 0 卡片未置入
            /// </summary>
            [Display(Name = "卡片未置入", AutoGenerateField = false, Order = 3)]
            [Description("0")]
            HCP_0,
            /// <summary>
            /// 醫事人員卡 1 醫事人員卡尚未與安全模組認證
            /// </summary>
            [Display(Name = "醫事人員卡尚未與安全模組認證", AutoGenerateField = false, Order = 3)]
            [Description("1")]
            HCP_1,
            /// <summary>
            /// 醫事人員卡 2 醫事人員卡與安全模組認證成功(PIN尚未認證)
            /// </summary>
            [Display(Name = "醫事人員卡與安全模組認證成功(PIN尚未認證)", AutoGenerateField = false, Order = 3)]
            [Description("2")]
            HCP_2,
            /// <summary>
            /// 醫事人員卡 3 醫事人員卡PIN認證成功
            /// </summary>
            [Display(Name = "醫事人員卡PIN認證成功", AutoGenerateField = true, Order = 3)]
            [Description("3")]
            HCP_3,
            /// <summary>
            /// 醫事人員卡 9 所置入非醫事人員卡
            /// </summary>
            [Display(Name = "所置入非醫事人員卡", AutoGenerateField = false, Order = 3)]
            [Description("9")]
            HCP_9,
            #endregion
        }

        #endregion

        #region AppConnectionConfigName
        /// <summary>
        /// 三總行動通訊APP 健保卡資料上傳 MonitorSchedule UUID, AppConfig 中 ConnectionName = EunmName,
        /// Description=UUID
        /// </summary>
        public enum TriAppConfigConnnectionName
        {
            /// <summary>
            /// 健保卡1.0 門診西醫
            /// </summary>
            [Display(Name = "健保卡1.0 門診西醫")]
            [Description("153933f3-09e3-4da1-8dbe-f97e8e417455")]
            NHI10_OPD_WesternMedicine,
            /// <summary>
            /// 健保卡1.0 門診牙科
            /// </summary>
            [Display(Name = "健保卡1.0 門診牙科")]
            [Description("fdf1a5a4-1201-4603-a208-d4ba873dec03")]
            NHI10_OPD_Dentist,
            /// <summary>
            /// 健保卡1.0 急診
            /// </summary>
            [Display(Name = "健保卡1.0 急診")]
            [Description("e44b5d15-3d0b-4f9c-b249-07d8eb21778b")]
            NHI10_ER,
            /// <summary>
            /// 健保卡1.0 門診居家照護
            /// </summary>
            [Display(Name = "健保卡1.0 門診居家照護")]
            [Description("dd86e34c-d270-4bf3-8b6b-a8d8ccdff9f3")]
            NHI10_OPD_HomeCare,
            /// <summary>
            /// 門診申報轉檔
            /// </summary>
            [Display(Name = "門診申報轉檔")]
            [Description("dbc2dc2a-5f80-44c8-bd54-311470decc1e")]
            Claim_OPD,
        }


        #endregion

        #region HIS2_NHIICCard CSHIS50 CSHIS60

        #region CSHIS50 Dll Enum
        /// <summary>
        /// 讀卡控制軟體 5.0 呼叫方法 Enum 
        /// Display.Name=方法中文名稱, Display.Description=方法編號
        /// Description=回傳資料長度
        /// </summary>
        public enum CsHis50DllNameEnum
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值", Description = "")]
            [Description("0")]
            None,
            /// <summary>
            /// 1.1 讀取不需個人 PIN 碼資料 長度:72
            /// </summary>
            [Display(Name = "讀取不需個人 PIN 碼資料", Description = "1.1")]
            [Description("72")]
            hisGetBasicData,

            /// <summary>
            /// 1.2 掛號或報到時讀取基本資料 長度:78
            /// </summary>
            [Display(Name = "掛號或報到時讀取基本資料", Description = "1.2")]
            [Description("78")]
            hisGetRegisterBasic,

            /// <summary>
            /// 1.3 預防保健掛號作業 長度:126
            /// </summary>
            [Display(Name = "預防保健掛號作業", Description = "1.3")]
            [Description("126")]
            hisGetRegisterPrevent,

            /// <summary>
            /// 1.4 孕婦產前檢查掛號作業 長度:209
            /// </summary>
            [Display(Name = "孕婦產前檢查掛號作業", Description = "1.4")]
            [Description("209")]
            hisGetRegisterPregnant,

            /// <summary>
            /// 1.5 讀取就醫資料不需 HPC 卡的部分 長度:498
            /// </summary>
            [Display(Name = "讀取就醫資料不需 HPC 卡的部分", Description = "1.5")]
            [Description("498")]
            hisGetTreatmentNoNeedHPC,

            /// <summary>
            /// 1.6 讀取就醫累計資料 長度:134
            /// </summary>
            [Display(Name = "讀取就醫累計資料", Description = "1.6")]
            [Description("134")]
            hisGetCumulativeData,

            /// <summary>
            /// 1.7 讀取醫療費用累計 長度:20
            /// </summary>
            [Display(Name = "讀取醫療費用累計", Description = "1.7")]
            [Description("20")]
            hisGetCumulativeFee,

            /// <summary>
            /// 1.8 讀取就醫資料需要 HPC 卡的部分 長度:540
            /// </summary>
            [Display(Name = "讀取就醫資料需要 HPC 卡的部分", Description = "1.8")]
            [Description("540")]
            hisGetTreatmentNeedHPC,

            /// <summary>
            /// 1.9 取得就醫序號 長度:167
            /// </summary>
            [Display(Name = "取得就醫序號", Description = "1.9")]
            [Description("167")]
            hisGetSeqNumber,

            /// <summary>
            /// 1.10 讀取處方箋作業 長度:3660
            /// </summary>
            [Display(Name = "讀取處方箋作業", Description = "1.10")]
            [Description("3660")]
            hisReadPrescription,

            /// <summary>
            /// 1.11 讀取預防接種資料 長度:1400
            /// </summary>
            [Display(Name = "讀取預防接種資料", Description = "1.11")]
            [Description("1400")]
            hisGetInoculateData,

            /// <summary>
            /// 1.12 讀取同意器官捐贈及安寧緩和醫療注記資料 長度:1
            /// </summary>
            [Display(Name = "讀取同意器官捐贈及安寧緩和醫療注記資料", Description = "1.12")]
            [Description("1")]
            hisGetOrganDonate,

            /// <summary>
            /// 1.13 讀取緊急聯絡電話資料 長度:14
            /// </summary>
            [Display(Name = "讀取緊急聯絡電話資料", Description = "1.13")]
            [Description("14")]
            hisGetEmergentTel,

            /// <summary>
            /// 1.14 讀取最新一次就醫序號 長度:7
            /// </summary>
            [Display(Name = "讀取最新一次就醫序號", Description = "1.14")]
            [Description("7")]
            hisGetLastSeqNum,

            /// <summary>
            /// 1.15 讀取卡片狀態 長度:4
            /// </summary>
            [Display(Name = "讀取卡片狀態", Description = "1.15")]
            [Description("4")]
            hisGetCardStatus,

            /// <summary>
            /// 1.16 就醫診療資料寫入作業 長度:54
            /// </summary>
            [Display(Name = "就醫診療資料寫入作業", Description = "1.16")]
            [Description("54")]
            hisWriteTreatmentCode,

            /// <summary>
            /// 1.17 就醫費用資料寫入作業 長度:38
            /// </summary>
            [Display(Name = "就醫費用資料寫入作業", Description = "1.17")]
            [Description("38")]
            hisWriteTreatmentFee,

            /// <summary>
            /// 1.18 處方簽寫入作業 長度:4
            /// </summary>
            [Display(Name = "處方簽寫入作業", Description = "1.18")]
            [Description("4")]
            hisWritePrescription,

            /// <summary>
            /// 1.19 新生兒註記寫入作業 長度:4
            /// </summary>
            [Display(Name = "新生兒註記寫入作業", Description = "1.19")]
            [Description("4")]
            hisWriteNewBorn,

            /// <summary>
            /// 1.20 過敏藥物寫入作業 長度:4
            /// [原本此函式會一次寫入所有欄位，但測試發現該函式寫入數值含有中文時，在讀取時會異常，故底層會改用 1.46來實作]
            /// </summary>
            [Display(Name = "過敏藥物寫入作業", Description = "1.20")]
            [Description("120")]
            hisWriteAllergicMedicines,

            /// <summary>
            /// 1.21 同意器官捐贈及安寧緩和醫療註記寫入作業 長度:4
            /// </summary>
            [Display(Name = "同意器官捐贈及安寧緩和醫療註記寫入作業", Description = "1.21")]
            [Description("4")]
            hisWriteOrganDonate,

            /// <summary>
            /// 1.22 預防保健資料寫入作業 長度:4
            /// </summary>
            [Display(Name = "預防保健資料寫入作業", Description = "1.22")]
            [Description("4")]
            hisWriteHealthInsurance,

            /// <summary>
            /// 1.23 緊急聯絡電話資料寫入作業 長度:4
            /// </summary>
            [Display(Name = "緊急聯絡電話資料寫入作業", Description = "1.23")]
            [Description("4")]
            hisWriteEmergentTel,

            /// <summary>
            /// 1.24 寫入產前檢查資料 長度:4
            /// </summary>
            [Display(Name = "寫入產前檢查資料", Description = "1.24")]
            [Description("4")]
            hisWritePredeliveryCheckup,

            /// <summary>
            /// 1.25 清除產前檢查資料 長度:4
            /// </summary>
            [Display(Name = "清除產前檢查資料", Description = "1.25")]
            [Description("4")]
            hisDeletePredeliveryData,

            /// <summary>
            /// 1.26 預防接種資料寫入作業 長度:4
            /// </summary>
            [Display(Name = "預防接種資料寫入作業", Description = "1.26")]
            [Description("4")]
            hisWriteInoculateData,

            /// <summary>
            /// 1.27 驗證健保 IC 卡之 PIN 值 長度:4
            /// </summary>
            [Display(Name = "驗證健保 IC 卡之 PIN 值", Description = "1.27")]
            [Description("4")]
            csVerifyHCPIN,

            /// <summary>
            /// 1.28 輸入新的健保 IC 卡之 PIN 值 長度:4
            /// </summary>
            [Display(Name = "輸入新的健保 IC 卡之 PIN 值", Description = "1.28")]
            [Description("4")]
            csInputHCPIN,

            /// <summary>
            /// 1.29 停用健保 IC 卡之 PIN 值輸入功能 長度:4
            /// </summary>
            [Display(Name = "停用健保 IC 卡之 PIN 值輸入功能", Description = "1.29")]
            [Description("4")]
            csDisableHCPIN,

            /// <summary>
            /// 1.30 健保 IC 卡片內容更新作業 長度:4
            /// </summary>
            [Display(Name = "健保 IC 卡片內容更新作業", Description = "1.30")]
            [Description("4")]
            csUpdateHCContents,

            /// <summary>
            /// 1.31 開啟讀卡機連結 長度:4
            /// </summary>
            [Display(Name = "開啟讀卡機連結", Description = "1.31")]
            [Description("4")]
            csOpenCom,

            /// <summary>
            /// 1.32 關閉讀卡機連結 長度:4
            /// </summary>
            [Display(Name = "關閉讀卡機連結", Description = "1.32")]
            [Description("4")]
            csCloseCom,

            /// <summary>
            /// 1.33 讀取重大傷病註記資料 長度:138
            /// </summary>
            [Display(Name = "讀取重大傷病註記資料", Description = "1.33")]
            [Description("138")]
            hisGetCriticalIllness,

            /// <summary>
            /// 1.34 讀取讀卡機日期時間 長度:13
            /// </summary>
            [Display(Name = "讀取讀卡機日期時間", Description = "1.34")]
            [Description("13")]
            csGetDateTime,

            /// <summary>
            /// 1.35 讀取卡片號碼 長度:12
            /// </summary>
            [Display(Name = "讀取卡片號碼", Description = "1.35")]
            [Description("12")]
            csGetCardNo,

            /// <summary>
            /// 1.36 健保 IC 卡是否設有密碼 長度:4
            /// </summary>
            [Display(Name = "健保 IC 卡是否設有密碼", Description = "1.36")]
            [Description("4")]
            csISSetPIN,

            /// <summary>
            /// 1.37 取得就醫序號版-就醫識別碼 長度:296
            /// </summary>
            [Display(Name = "取得就醫序號版-就醫識別碼", Description = "1.37")]
            [Description("296")]
            hisGetSeqNumber256,

            /// <summary>
            /// 1.38 掛號或報到時讀取基本資料 長度:9
            /// </summary>
            [Display(Name = "掛號或報到時讀取基本資料", Description = "1.38")]
            [Description("9")]
            hisGetRegisterBasic2,

            /// <summary>
            /// 1.39 回復就醫資料累計值---退掛 長度:4
            /// </summary>
            [Display(Name = "回復就醫資料累計值---退掛", Description = "1.39")]
            [Description("4")]
            csUnGetSeqNumber,

            /// <summary>
            /// 1.40 健保 IC 卡片內容更新作業 長度:4
            /// </summary>
            [Display(Name = "健保 IC 卡片內容更新作業", Description = "1.40")]
            [Description("4")]
            csUpdateHCNoReset,

            /// <summary>
            /// 1.41 讀取就醫資料-門診處方簽 長度:3660
            /// </summary>
            [Display(Name = "讀取就醫資料-門診處方簽", Description = "1.41")]
            [Description("3660")]
            hisReadPrescriptMain,

            /// <summary>
            /// 1.42 讀取就醫資料-長期處方簽 長度:1320
            /// </summary>
            [Display(Name = "讀取就醫資料-長期處方簽", Description = "1.42")]
            [Description("1320")]
            hisReadPrescriptLongTerm,

            /// <summary>
            /// 1.43 讀取就醫資料-重大醫療 長度:360
            /// </summary>
            [Display(Name = "讀取就醫資料-重大醫療", Description = "1.43")]
            [Description("360")]
            hisReadPrescriptHVE,

            /// <summary>
            /// 1.44 讀取就醫資料-過敏藥物 長度:120
            /// </summary>
            [Display(Name = "讀取就醫資料-過敏藥物", Description = "1.44")]
            [Description("120")]
            hisReadPrescriptAllergic,

            /// <summary>
            /// 1.45 多筆處方簽寫入作業 長度:4
            /// </summary>
            [Display(Name = "多筆處方簽寫入作業", Description = "1.45")]
            [Description("4")]
            hisWriteMultiPrescript,

            /// <summary>
            /// 1.46 過敏藥物寫入指定欄位作業 長度:4
            /// </summary>
            [Display(Name = "過敏藥物寫入指定欄位作業", Description = "1.46")]
            [Description("4")]
            hisWriteAllergicNum,

            /// <summary>
            /// 1.47 就醫診療資料及費用寫入作業 長度:4
            /// </summary>
            [Display(Name = "就醫診療資料及費用寫入作業", Description = "1.47")]
            [Description("4")]
            hisWriteTreatmentData,

            /// <summary>
            /// 1.48 處方簽寫入作業-回傳簽章 長度:40
            /// </summary>
            [Display(Name = "處方簽寫入作業-回傳簽章", Description = "1.48")]
            [Description("40")]
            hisWritePrescriptionSign,

            /// <summary>
            /// 1.49 多筆處方簽寫入作業-回傳簽章 長度:2400
            /// </summary>
            [Display(Name = "多筆處方簽寫入作業-回傳簽章", Description = "1.49")]
            [Description("2400")]
            hisWriteMultiPrescriptSign,

            /// <summary>
            /// 1.50 取得重大傷病註記資料身份比對 長度:138
            /// </summary>
            [Display(Name = "取得重大傷病註記資料身份比對", Description = "1.50")]
            [Description("138")]
            hisGetCriticalIllnessID,

            /// <summary>
            /// 1.51 取得控制軟體版本 長度:4
            /// </summary>
            [Display(Name = "取得控制軟體版本", Description = "1.51")]
            [Description("4")]
            csGetVersionEx,

            /// <summary>
            /// 1.52 提供 His 重置讀卡機或卡片的 API 長度:4
            /// </summary>
            [Display(Name = "提供 His 重置讀卡機或卡片的 API", Description = "1.52")]
            [Description("4")]
            csSoftwareReset,

            /// <summary>
            /// 1.53 取得就醫序號新版-就醫識別碼 長度:316
            /// </summary>
            [Display(Name = "取得就醫序號新版-就醫識別碼", Description = "1.53")]
            [Description("316")]
            hisGetSeqNumber256N1,

            /// <summary>
            /// 1.54 異常時取得就醫號碼 長度:43
            /// </summary>
            [Display(Name = "異常時取得就醫號碼", Description = "1.54")]
            [Description("43")]
            hisGetTreatNumNoICCard,

            /// <summary>
            /// 1.55 在保狀態查核 長度:4
            /// </summary>
            [Display(Name = "在保狀態查核", Description = "1.55")]
            [Description("4")]
            hisQuickInsurence,

            /// <summary>
            /// 1.56 單獨取得就醫識別碼 長度:20
            /// </summary>
            [Display(Name = "單獨取得就醫識別碼", Description = "1.56")]
            [Description("20")]
            hisGetTreatNumICCard,

            /// <summary>
            /// 2.1 SAM與DC認證 長度:4
            /// </summary>
            [Display(Name = "SAM與DC認證", Description = "2.1")]
            [Description("4")]
            csVerifySAMDC,

            /// <summary>
            /// 2.2 讀取SAM院所代碼 長度:10
            /// </summary>
            [Display(Name = "讀取SAM院所代碼", Description = "2.2")]
            [Description("10")]
            csGetHospID,

            /// <summary>
            /// 2.3 讀取SAM院所名稱 長度:24
            /// </summary>
            [Display(Name = "讀取SAM院所名稱", Description = "2.3")]
            [Description("24")]
            csGetHospName,

            /// <summary>
            /// 2.4 讀取SAM院所簡稱 長度:128
            /// </summary>
            [Display(Name = "讀取SAM院所簡稱", Description = "2.4")]
            [Description("128")]
            csGetHospAbbName,

            /// <summary>
            /// 3.1 資料上傳 長度:50
            /// </summary>
            [Display(Name = "資料上傳", Description = "3.1")]
            [Description("50")]
            csUploadData,

            /// <summary>
            /// 4.1 取得醫事人員卡狀態 長度:4
            /// </summary>
            [Display(Name = "取得醫事人員卡狀態", Description = "4.1")]
            [Description("4")]
            hpcGetHPCStatus,

            /// <summary>
            /// 4.2 檢查醫事人員卡之PIN值 長度:4
            /// </summary>
            [Display(Name = "檢查醫事人員卡之PIN值", Description = "4.2")]
            [Description("4")]
            hpcVerifyHPCPIN,

            /// <summary>
            /// 4.3 輸入新的醫事人員卡之PIN值 長度:4
            /// </summary>
            [Display(Name = "輸入新的醫事人員卡之PIN值", Description = "4.3")]
            [Description("4")]
            hpcInputHPCPIN,

            /// <summary>
            /// 4.4 解開鎖住的醫事人員卡 長度:4
            /// </summary>
            [Display(Name = "解開鎖住的醫事人員卡", Description = "4.4")]
            [Description("4")]
            hpcUnlockHPC,

            /// <summary>
            /// 4.5 取得醫事人員卡序號 長度:20
            /// </summary>
            [Display(Name = "取得醫事人員卡序號", Description = "4.5")]
            [Description("20")]
            hpcGetHPCSN,

            /// <summary>
            /// 4.6 取得醫事人員卡身分證字號 長度:10
            /// </summary>
            [Display(Name = "取得醫事人員卡身分證字號", Description = "4.6")]
            [Description("10")]
            hpcGetHPCSSN,

            /// <summary>
            /// 4.7 取得醫事人員卡中文姓名 長度:128
            /// </summary>
            [Display(Name = "取得醫事人員卡中文姓名", Description = "4.7")]
            [Description("128")]
            hpcGetHPCCNAME,

            /// <summary>
            /// 4.8 取得醫事人員卡英文姓名 長度:128
            /// </summary>
            [Display(Name = "取得醫事人員卡英文姓名", Description = "4.8")]
            [Description("128")]
            hpcGetHPCENAME,

            /// <summary>
            /// 4.9 虛擬醫師卡登出 長度:4
            /// </summary>
            [Display(Name = "虛擬醫師卡登出", Description = "4.9")]
            [Description("4")]
            hpcVHPCLogout,

            /// <summary>
            /// 5.1 進行疾病診斷碼押碼 長度:5
            /// </summary>
            [Display(Name = "進行疾病診斷碼押碼", Description = "5.1")]
            [Description("5")]
            hisGetICD10EnC,

            /// <summary>
            /// 5.2 進行疾病診斷碼解押碼 長度:10
            /// </summary>
            [Display(Name = "進行疾病診斷碼解押碼", Description = "5.2")]
            [Description("10")]
            hisGetICD10DeC,
        }
        #endregion

        #region CSHIS60 Enum WebApiUrl

        #region 讀卡控制6.0 主控台 安全模組,醫事人員,健保卡 文字Enum
        /// <summary>
        /// 安全模組,醫事人員,健保卡 種類(type)
        /// 使用Display.Name=名稱, Display.Description=數值
        /// Description=類型[SAM,HCA,HC]
        /// </summary>
        public enum CSHIS60_ComponmentType
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值", Description = "-1")]
            [Description("")]
            Null,
            /// <summary>
            /// 0: 無 SAM卡
            /// </summary>
            [Display(Name = "無安全模組卡", Description = "0")]
            [Description("SAM")]
            SAM_None,
            /// <summary>
            /// 1: 雲端安全模組
            /// </summary>
            [Display(Name = "雲端安全模組", Description = "1")]
            [Description("SAM")]
            SAM_CloudSam,
            /// <summary>
            /// 2: 實體安全模組
            /// </summary>
            [Display(Name = "實體安全模組", Description = "2")]
            [Description("SAM")]
            SAM_EntitySam,
            /// <summary>
            /// 0: 無醫事人員卡
            /// </summary>
            [Display(Name = "無醫事人員卡", Description = "0")]
            [Description("HPC")]
            HPC_None,
            /// <summary>
            /// 1: 醫師卡
            /// </summary>
            [Display(Name = "醫師卡", Description = "1")]
            [Description("HPC")]
            HPC_Doctor,
            /// <summary>
            /// 2: 醫事人員卡
            /// </summary>
            [Display(Name = "醫事人員卡", Description = "2")]
            [Description("HPC")]
            HPC_Hca,
            /// <summary>
            /// 3: 醫事人員行動憑證
            /// </summary>
            [Display(Name = "醫事人員行動憑證", Description = "3")]
            [Description("HPC")]
            HPC_MobiliHca,
            /// <summary>
            /// 0: 無健保卡
            /// </summary>
            [Display(Name = "無健保卡", Description = "0")]
            [Description("HC")]
            HC_None,
            /// <summary>
            /// 1: 實體健保卡
            /// </summary>
            [Display(Name = "實體健保卡", Description = "1")]
            [Description("HC")]
            HC_RealHc,
            /// <summary>
            /// 2: 虛擬健保卡
            /// </summary>
            [Display(Name = "虛擬健保卡", Description = "2")]
            [Description("HC")]
            HC_VirtualHc,
        }
        /// <summary>
        /// 安全模組,醫事人員,健保卡 狀態(status)
        /// 使用Display.Name=名稱, Display.Description=數值
        /// Description=類型[SAM,HCA,HC]
        /// </summary>
        public enum CSHIS60_ComponmentState
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值", Description = "-1")]
            [Description("")]
            Null,
            /// <summary>
            /// 0: 未置入 SAM卡
            /// </summary>
            [Display(Name = "安全模組未置入", Description = "0")]
            [Description("SAM")]
            SAM_None,
            /// <summary>
            /// 1: SAM 已置入
            /// </summary>
            [Display(Name = "安全模組已置入", Description = "1")]
            [Description("SAM")]
            SAM_Insertion,
            /// <summary>
            /// 2: SAM 已與中心端驗證
            /// </summary>
            [Display(Name = "安全模組已與中心端驗證", Description = "2")]
            [Description("SAM")]
            SAM_InsertedAndVerified,
            /// <summary>
            /// 0: 未置入醫事人員卡
            /// </summary>
            [Display(Name = "未置入醫事人員卡", Description = "0")]
            [Description("HPC")]
            HPC_None,
            /// <summary>
            /// 1: 已置入醫事人員卡
            /// </summary>
            [Display(Name = "已置入醫事人員卡", Description = "1")]
            [Description("HPC")]
            HPC_Insertion,
            /// <summary>
            /// 2: 醫事人員卡已驗證(未驗Pin)
            /// </summary>
            [Display(Name = "醫事人員卡已驗證(未驗Pin)", Description = "2")]
            [Description("HPC")]
            HPC_InsertedAndVerified,
            /// <summary>
            /// 3: 醫事人員卡已驗 PIN
            /// </summary>
            [Display(Name = "醫事人員卡已驗 PIN", Description = "3")]
            [Description("HPC")]
            HPC_InsertedAndVerifiedPin,
            /// <summary>
            /// 0: 未置入健保卡
            /// </summary>
            [Display(Name = "未置入健保卡", Description = "0")]
            [Description("HC")]
            HC_None,
            /// <summary>
            /// 1: 健保卡已置入
            /// </summary>
            [Display(Name = "已置入健保卡", Description = "1")]
            [Description("HC")]
            HC_Insertion,
            /// <summary>
            /// 2: 健保卡已與 SAM 驗證
            /// </summary>
            [Display(Name = "健保卡已驗證", Description = "2")]
            [Description("HC")]
            HC_InsertedAndVerifiedSam,
            /// <summary>
            /// 3: 健保卡已與 HCA 驗證
            /// </summary>
            [Display(Name = "健保卡與醫事人員卡已驗證", Description = "3")]
            [Description("HC")]
            HC_InsertedAndVerifiedHca,

        }

        #endregion

        /// <summary>
        /// 健保署API環境
        /// Description = URL
        /// </summary>
        public enum NHIVPNEnviroment
        {
            /// <summary>
            /// 本地環境 https://localhost:5066
            /// </summary>
            [Display(Name = "本地環境")]
            [Description("https://localhost:5066")]
            Local,
            /// <summary>
            /// 正式環境 https://medvpndc.nhi.gov.tw
            /// </summary>
            [Display(Name = "正式環境")]
            [Description("https://medvpndc.nhi.gov.tw")]
            Formal,
            /// <summary>
            /// 測試環境 https://medvpndct.nhi.gov.tw
            /// </summary>
            [Display(Name = "測試環境")]
            [Description("https://medvpndct.nhi.gov.tw")]
            Test,
            /// <summary>
            /// 測試虛擬健保卡環境 https://medvpndct.nhi.gov.tw
            /// </summary>
            [Display(Name = "測試虛擬健保卡環境")]
            [Description("https://medvpndct.nhi.gov.tw")]
            TestVHC,
        }
        /// <summary>
        /// 簽章種類 
        /// Descripation = URL
        /// </summary>
        public enum NHIVPNICCARD_SignatureType
        {
            /// <summary>
            /// 初始數值
            /// </summary>
            [Display(Name = "初始數值")]
            [Description("")]
            NULL,
            /// <summary>
            /// 安全模組簽章
            /// DisplayName=中文名稱, Description=服務URL
            /// </summary>
            [Display(Name = "安全模組簽章")]
            [Description("/api/sam/v1/Signature")]
            SAM,
            /// <summary>
            /// 安全模組及醫事人員簽章
            /// </summary>
            [Display(Name = "安全模組及醫事人員簽章")]
            [Description("/api/hpc/v1/Signature")]
            SAM_HCP,
            /// <summary>
            /// 安全模組及健保卡簽章
            /// </summary>
            [Display(Name = "安全模組及健保卡簽章")]
            [Description("/api/hc/v1/Signature/Hc")]
            SAM_HC,
            /// <summary>
            /// 安全模組及醫事人員及健保卡簽章
            /// </summary>
            [Display(Name = "安全模組及醫事人員及健保卡簽章")]
            [Description("/api/hc/v1/Signature/HpcHc")]
            SAM_HCP_HC,
        }

        /// <summary>
        /// 簽章服務類別
        /// DisplayName=中文名稱, Description=服務代碼
        /// </summary>
        public enum NHIVPNICCARD_SignKind
        {
            /// <summary>
            /// 初始數值
            /// </summary>
            [Display(Name = "初始數值")]
            [Description("")]
            _Null,
            /// <summary>
            /// 讀取健保卡相關 API 01
            /// </summary>
            [Display(Name = "讀取健保卡相關 API")]
            [Description("01")]
            _01ReadICCard,
            /// <summary>
            /// 寫入健保卡相關 API 02
            /// </summary>
            [Display(Name = "寫入健保卡相關 API")]
            [Description("02")]
            _02WriteICCard,
            /// <summary>
            /// 取號相關 API 03
            /// </summary>
            [Display(Name = "取號相關 API")]
            [Description("03")]
            _03GetTreatNum,
            /// <summary>
            /// 卡片更新相關 API 04 
            /// </summary>
            [Display(Name = "卡片更新相關 API")]
            [Description("04")]
            _04UploadICCard,
            /// <summary>
            /// 就醫資料上傳相關 API 05
            /// </summary>
            [Display(Name = "就醫資料上傳相關 API")]
            [Description("05")]
            _05UploadTeatmentData,
            /// <summary>
            /// 測試虛擬健保卡相關 API 06
            /// </summary>
            [Display(Name = "測試虛擬健保卡相關 API")]
            [Description("06")]
            _06TestVirtualHc,
        }

        #region 健保署 WebApi URL
        /// <summary>
        /// 主控台5.0, 主控台6.0 方法
        /// WebApi URL 呼叫方法網址
        /// Display.Name=名稱,
        /// Display.ShortName = NHIVPNICCARD_SignKind(簽章服務類別).EnumName,
        /// Display.GroupName = NHIVPNICCARD_SignatureType(簽章種類).EnumName
        /// Description=URL
        /// </summary>
        public enum NHIVPNWebApiUrl
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("")]
            None,

            #region 主控台元件

            #region 公用相關 COMMON
            /// <summary>
            /// 主控台5.0- 1.15 hisGetCardStatus (讀取卡片狀態)
            /// 主控台6.0-取得目前控制軟體狀態
            /// </summary>
            [Display(Name = "取得目前控制軟體狀態", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Status")]
            GetCommonV1Status,
            /// <summary>
            /// 主控台5.0- 1.31 csOpenCom (開啟讀卡機連結埠)
            /// 主控台6.0-初始化控制軟體
            /// </summary>
            [Display(Name = "初始化控制軟體", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Initial")]
            PostCommonV1Initial,

            /// <summary>
            /// 主控台5.0- 1.32 csCloseCom (關閉讀卡機連結埠)
            /// 主控台6.0-結束作業，釋放所有資源
            /// </summary>
            [Display(Name = "結束作業，釋放所有資源", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Finalize")]
            PostCommonV1Finalize,

            /// <summary>
            /// 主控台6.0-取得目前可用裝置名稱清單
            /// </summary>
            [Display(Name = "取得目前可用裝置名稱清單", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Name")]
            GetCommonV1Name,

            /// <summary>
            /// 主控台6.0-取得 API 執行記錄
            /// </summary>
            [Display(Name = "取得 API 執行記錄", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Record")]
            GetCommonV1Record,

            /// <summary>
            /// 主控台6.0-刪除 API 執行記錄
            /// </summary>
            [Display(Name = "刪除 API 執行記錄", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Record")]
            DeleteCommonV1Record,

            /// <summary>
            /// 主控台5.0- 1.34 讀取讀卡機日期時間
            /// 主控台6.0-取得讀卡機或伺服器日期時間
            /// </summary>
            [Display(Name = "取得讀卡機或伺服器日期時間", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/ServerDateTime")]
            GetCommonV1ServerDateTime,

            /// <summary>
            /// 主控台5.0- 1.51 csGetVersionEx (取得控制軟體版本)
            /// 主控台6.0-取得目前控制軟體版本資訊
            /// </summary>
            [Display(Name = "取得目前控制軟體版本資訊", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Version")]
            GetCommonV1Version,

            #endregion

            #region 安全模組相關 SAM
            /// <summary>
            /// 主控台5.0- 2.2 csGetHospID (讀取SAM院所代碼)+2.3csGetHospName (讀取SAM院所名稱)+2.4csGetHospAbbName (讀取SAM院所簡稱)
            /// 主控台6.0-讀取安全模組基本資料
            /// </summary>
            [Display(Name = "讀取安全模組基本資料", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/sam/v1/Basic")]
            GetSamV1Basic,

            /// <summary>
            /// 主控台5.0- 2.1 csVerifySAMDC (SAM與DC認證)
            /// 主控台6.0-驗證安全模組
            /// </summary>
            [Display(Name = "驗證安全模組", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/sam/v1/Verification")]
            PostSamV1Verification,

            /// <summary>
            /// 主控台5.0- 1.52 csSoftwareReset (提供His重置讀卡機或卡片的API)
            /// 主控台6.0-登出所有驗證狀態
            /// </summary>
            [Display(Name = "登出所有驗證狀態", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/sam/v1/Logout")]
            DeleteSamV1Logout,

            /// <summary>
            /// 主控台6.0-取得安全模組簽章
            /// </summary>
            [Display(Name = "取得安全模組簽章", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/sam/v1/Signature")]
            PostSamV1Signature,
            #endregion

            #region 醫事人員卡相關 HCA
            /// <summary>
            /// 主控台5.0- 4.5 hpcGetHPCSN (取得醫事人員卡序號)+4.6 hpcGetHPCSSN (取得醫事人員卡身分證字號)+4.7 hpcGetHPCCNAME (取得醫事人員卡中文姓名)+4.8 hpcGetHPCENAME (取得醫事人員卡英文姓名)
            /// 主控台6.0-讀取醫事人員基本資料
            /// </summary>
            [Display(Name = "讀取醫事人員基本資料", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Basic")]
            GetHpcV1Basic,

            /// <summary>
            /// 主控台6.0-登出 HCA 卡片狀態
            /// </summary>
            [Display(Name = "登出 HCA 卡片狀態", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Logout")]
            DeleteHpcV1Logout,

            /// <summary>
            /// 主控台5.0- 4.3 hpcInputHPCPIN (輸入新的醫事人員卡之PIN值)
            /// 主控台6.0-重新設定 PIN 碼
            /// </summary>
            [Display(Name = "重新設定 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Pin")]
            PostHpcV1Pin,

            /// <summary>
            /// 主控台5.0- 4.4 hpcUnlockHPC (解開鎖住的醫事人員卡)
            /// 主控台6.0-使用 PUK 重新設定 PIN 碼
            /// </summary>
            [Display(Name = "使用 PUK 重新設定 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Pin")]
            PutHpcV1Pin,

            /// <summary>
            /// 主控台6.0-取得醫事人員簽章
            /// </summary>
            [Display(Name = "取得醫事人員簽章", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Signature")]
            PostHpcV1Signature,

            /// <summary>
            /// 主控台6.0-驗證醫事人員行動憑證
            /// </summary>
            [Display(Name = "驗證醫事人員行動憑證", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Verification/MobiliHca")]
            PostHpcV1VerificationMobiliHca,

            /// <summary>
            /// 主控台5.0- 4.2 hpcVerifyHPCPIN (檢查醫事人員卡之PIN值)
            /// 主控台6.0-驗證實體醫師或醫事人員卡 PIN 值
            /// </summary>
            [Display(Name = "驗證實體醫師或醫事人員卡 PIN 值", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Verification/Hpc")]
            PostHpcV1VerificationHpc,

            #endregion

            #region 健保卡相關 HC
            /// <summary>
            /// 主控台5.0- 1.2 hisGetRegisterBasic(掛號或報到時讀取基本資料)
            /// 主控台6.0-讀取保險對象基本資料
            /// </summary>
            [Display(Name = "讀取保險對象基本資料", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Basic")]
            GetHcV1Basic,

            /// <summary>
            /// 主控台6.0-登出健保卡資料狀態
            /// </summary>
            [Display(Name = "登出健保卡資料狀態", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Logout")]
            DeleteHcV1Logout,

            /// <summary>
            /// 主控台5.0- 1.36 csISSetPIN (檢查健保IC卡是否設定密碼)
            /// 主控台6.0-健保卡是否有設定 PIN 碼
            /// </summary>
            [Display(Name = "健保卡是否有設定 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Pin")]
            GetHcV1Pin,

            /// <summary>
            /// 主控台5.0- 1.27 csVerifyHCPIN (驗證健保IC卡之PIN值)
            /// 主控台6.0-驗證健保卡 PIN 碼
            /// </summary>
            [Display(Name = "驗證健保卡 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Pin")]
            PostHcV1Pin,

            /// <summary>
            /// 主控台5.0- 1.28 csInputHCPIN (輸入新的健保IC卡PIN值)
            /// 主控台6.0-設定健保卡 PIN 碼
            /// </summary>
            [Display(Name = "設定健保卡 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Pin")]
            PutHcV1Pin,

            /// <summary>
            /// 主控台5.0- 1.29 csDisableHCPIN (停用健保IC卡之Pin碼輸入功能)
            /// 主控台6.0-移除健保卡 PIN 碼
            /// </summary>
            [Display(Name = "移除健保卡 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Pin")]
            DeleteHcV1Pin,

            /// <summary>
            /// 主控台6.0-取得健保卡簽章
            /// </summary>
            [Display(Name = "取得健保卡簽章", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Signature/Hc")]
            PostHcV1SignatureHc,

            /// <summary>
            /// 主控台6.0-取得三卡驗證簽章 (SAM, HPC, HC)
            /// </summary>
            [Display(Name = "取得三卡驗證簽章 (SAM, HPC, HC)", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Signature/HpcHc")]
            PostHcV1SignatureHpcHc,

            #region 虛擬健保卡相關

            /// <summary>
            /// 主控台6.0-驗證虛擬健保卡
            /// </summary>
            [Display(Name = "驗證虛擬健保卡", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Verification/VirtualHc")]
            PostHcV1VerificationVirtualHc,

            /// <summary>
            /// 主控台6.0-讀取虛擬健保卡基本資料(只讀取Token內基本資料，該Token仍然可供後續驗證使用)
            /// </summary>
            [Display(Name = "讀取虛擬健保卡基本資料(只讀取Token內基本資料，該Token仍然可供後續驗證使用)", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/VirtualHc/ReadBasic")]
            PostHcV1VirtualHcReadBasic,

            /// <summary>
            /// 主控台6.0-匯出虛擬健保卡轉移碼
            /// </summary>
            [Display(Name = "匯出虛擬健保卡轉移碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/VirtualHc/Export")]
            PostHcV1VirtualHcExport,

            /// <summary>
            /// 主控台6.0-匯入虛擬健保卡轉移碼
            /// </summary>
            [Display(Name = "匯入虛擬健保卡轉移碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/VirtualHc/Import")]
            PostHcV1VirtualHcImport,

            #endregion

            /// <summary>
            /// 主控台5.0- 1.30 csUpdateHCContents (健保IC卡卡片內容更新作業)
            /// 主控台6.0-實體健保卡更新註記
            /// </summary>
            [Display(Name = "實體健保卡更新註記", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/RealHc/Update")]
            PostHcV1RealHcUpdate,

            #endregion

            #region 設定相關 SETTINGS

            /// <summary>
            /// 主控台6.0-取得本機 PCSC 讀卡機清單
            /// </summary>
            [Display(Name = "取得本機 PCSC 讀卡機清單", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/PcscReader/Readers")]
            GetSettingsV1PcscReaderReaders,

            /// <summary>
            /// 主控台6.0-自動檢測 PCSC 讀卡機
            /// </summary>
            [Display(Name = "自動檢測 PCSC 讀卡機", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/PcscReader/AutoDetected")]
            PostSettingsV1PcscReaderAutoDetected,

            /// <summary>
            /// 主控台6.0-取得目前預設使用 PCSC 讀卡機名稱
            /// </summary>
            [Display(Name = "取得目前預設使用 PCSC 讀卡機名稱", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/PcscReader/Default")]
            GetSettingsV1PcscReaderDefault,

            /// <summary>
            /// 主控台6.0-設定目前預設使用 PCSC 讀卡機名稱
            /// </summary>
            [Display(Name = "設定目前預設使用 PCSC 讀卡機名稱", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/PcscReader/Default")]
            PostSettingsV1PcscReaderDefault,

            /// <summary>
            /// 主控台6.0-清除預設使用 PCSC 讀卡機
            /// </summary>
            [Display(Name = "清除預設使用 PCSC 讀卡機", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/PcscReader/Default")]
            DeleteSettingsV1PcscReaderDefault,

            /// <summary>
            /// 主控台6.0-取得雲端安全模組清單
            /// </summary>
            [Display(Name = "取得雲端安全模組清單", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/CloudSam")]
            GetSettingsV1CloudSam,

            /// <summary>
            /// 主控台6.0-新增雲端安全模組
            /// </summary>
            [Display(Name = "新增雲端安全模組", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/CloudSam")]
            PostSettingsV1CloudSam,

            /// <summary>
            /// 主控台6.0-從安全模組清單移除雲端安全模組
            /// </summary>
            [Display(Name = "從安全模組清單移除雲端安全模組", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/CloudSam")]
            DeleteSettingsV1CloudSam,

            /// <summary>
            /// 主控台6.0-取得允許呼叫主機名稱
            /// </summary>
            [Display(Name = "取得允許呼叫主機名稱", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/Cors")]
            GetSettingsV1Cors,

            /// <summary>
            /// 主控台6.0-新增允許呼叫主機名稱
            /// </summary>
            [Display(Name = "新增允許呼叫主機名稱", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/Cors")]
            PostSettingsV1Cors,

            /// <summary>
            /// 主控台6.0-移除允許呼叫主機名稱清單
            /// </summary>
            [Display(Name = "移除允許呼叫主機名稱清單", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/Cors")]
            DeleteSettingsV1Cors,
            #endregion

            #endregion

            #region 業務端

            #region 過敏藥物相關 (AllergicMedicines)
            /// <summary>
            /// 主控台5.0- 1.20 hisWriteAllergicMedicines (過敏藥物寫入作業); 
            /// 業務端6.0-寫入過敏藥物資料
            /// </summary>
            [Display(Name = "寫入過敏藥物資料", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/AllergicMedicines/Write")]
            PostV1AllergicMedicinesWrite,

            /// <summary>
            /// 主控台5.0- 1.46 hisWriteAllergicNum (過敏藥物寫入指定欄位作業);
            /// 業務端6.0-寫入過敏藥物資料並指定寫入欄位 (WriteByIndex)
            /// </summary>
            [Display(Name = "寫入過敏藥物資料並指定寫入欄位 (WriteByIndex)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/AllergicMedicines/WriteByIndex")]
            PostV1AllergicMedicinesWriteByIndex,

            /// <summary>
            /// 主控台5.0- 1.44 hisReadPrescriptAllergic (讀取就醫資料-過敏藥物);
            /// 業務端6.0-讀取過敏藥物資料 (Query)
            /// </summary>
            [Display(Name = "讀取過敏藥物資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/AllergicMedicines/Query")]
            PostV1AllergicMedicinesQuery,
            #endregion

            #region 基本資料相關 (BasicData)
            /// <summary>
            /// 主控台5.0- 1.1 hisGetBasicData (讀取不需個人PIN碼資料);
            /// 業務端6.0-讀取不需要個人 PIN 碼之基本資料 (Query)
            /// </summary>
            [Display(Name = "讀取不需要個人 PIN 碼之基本資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/BasicData/Query")]
            PostV1BasicDataQuery,

            /// <summary>
            /// 主控台5.0- 1.2 hisGetRegisterBasic (掛號或報到時讀取基本資料);
            /// 業務端6.0-掛號或報到時讀取基本資料 (Register)
            /// </summary>
            [Display(Name = "掛號或報到時讀取基本資料 (Register)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/BasicData/Register")]
            PostV1BasicDataRegister,

            /// <summary>
            /// 主控台5.0- 1.38 hisGetRegisterBasic2(掛號或報到時讀取基本資料);
            /// 業務端6.0-掛號或報到時讀取基本資料 (Register2)
            /// </summary>
            [Display(Name = "掛號或報到時讀取基本資料 (Register2)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/BasicData/Register2")]
            PostV1BasicDataRegister2,

            #endregion

            #region 重大傷病相關 (CriticalIllness)
            /// <summary>
            /// 主控台5.0- 1.33 hisGetCriticalIllness (讀取重大傷病註記資料);
            /// [5.0 備註:如果pPatientID與pPatientBirthDate兩者皆有數值，則會使用1.50 hisGetCriticalIllnessID];
            /// 業務端6.0-讀取重大傷病資料 (Query)
            /// </summary>
            [Display(Name = "讀取重大傷病資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/CriticalIllness/Query")]
            PostV1CriticalIllnessQuery,

            /// <summary>
            /// 主控台5.0- 1.33 hisGetCriticalIllness (讀取重大傷病註記資料);
            /// [5.0 備註:如果pPatientID與pPatientBirthDate兩者皆有數值，則會使用1.50 hisGetCriticalIllnessID];
            /// 業務端6.0-讀取重大傷病資料 – 不需醫事人員卡 (OnlyHcQuery)
            /// </summary>
            [Display(Name = "讀取重大傷病資料 – 不需醫事人員卡 (OnlyHcQuery)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/CriticalIllness/OnlyHcQuery")]
            PostV1CriticalIllnessOnlyHcQuery,

            #endregion

            #region 就醫年度累計資料 (CumulativeData)
            /// <summary>
            /// 主控台5.0- 1.6 hisGetCumulativeData (讀取就醫累計資料);
            /// 業務端6.0-讀取就醫累計資料 (Query)
            /// </summary>
            [Display(Name = "讀取就醫累計資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/CumulativeData/Query")]
            PostV1CumulativeDataQuery,

            #endregion

            #region 醫療費用總累計相關 (CumulativeFee)
            /// <summary>
            /// 主控台5.0- 1.7 hisGetCumulativeFee (讀取醫療費用總累計);
            /// 業務端6.0-讀取就醫總累計資料 (Query)
            /// </summary>
            [Display(Name = "讀取就醫總累計資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/CumulativeFee/Query")]
            PostV1CumulativeFeeQuery,

            #endregion

            #region 緊急聯絡電話相關 (EmergentTel)
            /// <summary>
            /// 主控台5.0- 1.23 hisWriteEmergentTel (緊急聯絡電話資料寫入作業);
            /// 業務端6.0-寫入「EmergencyTel」 (Write)
            /// </summary>
            [Display(Name = "寫入「EmergencyTel」 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/EmergentTel/Write")]
            PostV1EmergentTelWrite,

            /// <summary>
            /// 主控台5.0- 1.13 hisGetEmergentTel (讀取緊急聯絡電話資料)
            /// 業務端6.0-讀取「EmergencyTel」 (Query)
            /// </summary>
            [Display(Name = "讀取「EmergencyTel」 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/EmergentTel/Query")]
            PostV1EmergentTelQuery,

            #endregion

            #region 健保卡卡片內容相關
            /// <summary>
            /// 主控台5.0- 1.30 csUpdateHCContents, 1.40 csUpdateHCNoReset
            /// 業務端6.0-更新健保卡內容(Update)
            /// </summary>
            [Display(Name = "更新健保卡內容(Update)", ShortName = nameof(NHIVPNICCARD_SignKind._04UploadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/HcContent/Update")]
            PostV1HcContentUpdate,

            #endregion

            #region 疾病診斷碼相關(Icd)
            /// <summary>
            /// 主控台5.0- 5.1 hisGetICD10EnC (進行疾病診斷碼押碼)
            /// 業務端6.0-進行疾病診斷碼押碼 (Encode)
            /// </summary>
            [Display(Name = "進行疾病診斷碼押碼 (Encode)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/Icd/Encode")]
            PostV1IcdEncode,

            /// <summary>
            /// 主控台5.0- 5.2hisGetICD10DeC (進行疾病診斷碼解押碼)
            /// 進行疾病診斷碼解押碼 (Decode)
            /// </summary>
            [Display(Name = "進行疾病診斷碼解押碼 (Decode)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/Icd/Decode")]
            PostV1IcdDecode,

            #endregion

            #region 預防接種相關 (Inoculate)
            /// <summary>
            /// 主控台5.0- 1.11 hisGetInoculateData (讀取預防接種資料)
            /// 業務端6.0-讀取預防接種資料 (Query)
            /// </summary>
            [Display(Name = "讀取預防接種資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Inoculate/Query")]
            PostV1InoculateQuery,

            /// <summary>
            /// 主控台5.0- 1.26 hisWriteInoculateData (預防接種資料寫入作業)
            /// 業務端6.0-寫入預防接種資料 (Write)
            /// </summary>
            [Display(Name = "寫入預防接種資料 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Inoculate/Write")]
            PostV1InoculateWrite,

            #endregion

            #region 保險相關 (Insurance)
            /// <summary>
            /// 主控台5.0- 1.55 hisQuickInsurence (在保狀態查核)
            /// 業務端6.0-在保狀態查核(Quick)
            /// </summary>
            [Display(Name = "在保狀態查核(Quick)", ShortName = nameof(NHIVPNICCARD_SignKind._03GetTreatNum), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Insurance/Quick")]
            PostV1InsuranceQuick,

            #endregion

            #region 新生兒相關 (NewBorn)
            /// <summary>
            /// 主控台5.0- 1.19 hisWriteNewBorn (新生兒註記寫入作業)
            /// 業務端6.0-新生兒註記寫入健保卡時使用 (Write)
            /// </summary>
            [Display(Name = "新生兒註記寫入健保卡時使用 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/NewBorn/Write")]
            PostV1NewBornWrite,

            #endregion

            #region 器捐安寧註記相關 (OrganDonate)
            /// <summary>
            /// 主控台5.0- 1.12 hisGetOrganDonate (讀取同意器官捐贈及安寧緩和醫療註記)
            /// 業務端6.0-讀取器捐安寧註記 (OrganDonate)
            /// </summary>
            [Display(Name = "讀取器捐安寧註記 (OrganDonate)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/OrganDonate/Query")]
            PostV1OrganDonateQuery,

            #endregion

            #region 產婦產前檢查相關 (PregnantData)
            /// <summary>
            /// 主控台5.0- 1.4 hisGetRegisterPregnant (孕婦產前檢查掛號作業)
            /// 業務端6.0-取得產前檢查資料 (Query)
            /// </summary>
            [Display(Name = "取得產前檢查資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/PregnantData/Query")]
            PostV1PregnantDataQuery,

            /// <summary>
            /// 主控台5.0- 1.24 hisWritePredeliveryCheckup (寫入產前檢查資料)
            /// 業務端6.0-寫入產前檢查資料 (Write)
            /// </summary>
            [Display(Name = "寫入產前檢查資料 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/PregnantData/Write")]
            PostV1PregnantDataWrite,

            /// <summary>
            /// 主控台5.0- 1.25 hisDeletePredeliveryData (清除產前檢查資料)
            /// 業務端6.0-刪除全部產前檢查資料 (Delete)
            /// </summary>
            [Display(Name = "刪除全部產前檢查資料 (Delete)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/PregnantData/Delete")]
            PostV1PregnantDataDelete,
            #endregion

            #region 醫令相關 (Prescription)
            /// <summary>
            /// 主控台5.0- 1.48hisWritePrescriptionSign (處方箋寫入作業-回傳簽章)[1~60筆]
            /// 業務端6.0-寫入處方箋資料 (Write)
            /// </summary>
            [Display(Name = "寫入處方箋資料 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Prescription/Write")]
            PostV1PrescriptionWrite,

            /// <summary>
            /// 主控台5.0- 1.10 hisReadPrescription (讀取處方箋作業)
            /// 業務端6.0-讀取健保卡的醫令及過敏藥物資料 (Query)
            /// </summary>
            [Display(Name = "讀取健保卡的醫令及過敏藥物資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/Prescription/Query")]
            PostV1PrescriptionQuery,

            /// <summary>
            /// 主控台5.0- 1.41 hisReadPrescriptMain (讀取就醫資料-門診處方箋)
            /// 業務端6.0-讀取就醫資料-門診處方箋 (MainQuery)
            /// </summary>
            [Display(Name = "讀取就醫資料-門診處方箋 (MainQuery)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/Prescription/MainQuery")]
            PostV1PrescriptionMainQuery,

            /// <summary>
            /// 主控台5.0- 1.42hisReadPrescriptLongTerm (讀取就醫資料-長期處方箋)
            /// 業務端6.0-讀取就醫資料-長期處方箋 (LongQuery)
            /// </summary>
            [Display(Name = "讀取就醫資料-長期處方箋 (LongQuery)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/Prescription/LongQuery")]
            PostV1PrescriptionLongQuery,

            /// <summary>
            /// 主控台5.0- 1.43 hisReadPrescriptHVE (讀取就醫資料-重要醫令)
            /// 讀取就醫資料-重要醫令 (HveQuery)
            /// </summary>
            [Display(Name = "讀取就醫資料-重要醫令 (HveQuery)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/Prescription/HveQuery")]
            PostV1PrescriptionHveQuery,
            #endregion

            #region 預防保健相關 (PreventData)
            /// <summary>
            /// 主控台5.0- 1.3 hisGetRegisterPrevent (預防保健掛號作業)
            /// 業務端6.0-取得預防保健資料 (Query)
            /// </summary>
            [Display(Name = "取得預防保健資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/PreventData/Query")]
            PostV1PreventDataQuery,

            /// <summary>
            /// 主控台5.0- 1.22 hisWriteHealthInsurance (預防保健資料寫入作業)
            /// 業務端6.0-寫入預防保健資料 (Write)
            /// </summary>
            [Display(Name = "寫入預防保健資料 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/PreventData/Write")]
            PostV1PreventDataWrite,

            #endregion

            #region 就醫序號相關 (SequelNumber)
            /// <summary>
            /// 主控台5.0- 1.14 hisGetLastSeqNum (讀取最近一次就醫序號)
            /// 業務端6.0-讀出「SequelNumberLast」(Last)
            /// </summary>
            [Display(Name = "讀出「SequelNumberLast」(Last)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/SequelNumber/Last")]
            PostV1SequelNumberLast,

            /// <summary>
            /// 主控台5.0- 1.53 hisGetSeqNumber256N1 (取得就醫序號新版-就醫識別碼)
            /// 業務端6.0-取得就醫序號 (Next)
            /// </summary>
            [Display(Name = "取得就醫序號 (Next)", ShortName = nameof(NHIVPNICCARD_SignKind._03GetTreatNum), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/SequelNumber/Next")]
            PostV1SequelNumberNext,

            /// <summary>
            /// 主控台5.0- 1.39 csUnGetSeqNumber(回復就醫資料累計值---退掛)
            /// 業務端6.0-回復就醫資料累計值 (Rollback)
            /// </summary>
            [Display(Name = "回復就醫資料累計值 (Rollback)", ShortName = nameof(NHIVPNICCARD_SignKind._03GetTreatNum), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/SequelNumber/Rollback")]
            PostV1SequelNumberRollback,

            #endregion

            #region 視訊醫療相關 (TeleMedicine)
            /// <summary>
            /// 業務端6.0-請求視訊醫療虛擬健保卡 (RequestToken)
            /// </summary>
            [Display(Name = "請求視訊醫療虛擬健保卡 (RequestToken)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/TeleMedicine/RequestToken")]
            PostV1TeleMedicineRequestToken,

            /// <summary>
            /// 業務端6.0-取得視訊醫療虛擬健保卡資料授權結果 (ResponseToken)
            /// </summary>
            [Display(Name = "取得視訊醫療虛擬健保卡資料授權結果 (ResponseToken)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/TeleMedicine/ResponseToken")]
            PostV1TeleMedicineResponseToken,

            #endregion

            #region 就醫相關 (Treatment)
            /// <summary>
            /// 主控台5.0- 1.5 hisGetTreatmentNoNeedHPC (讀取就醫資料不需HPC卡的部分)
            /// 業務端6.0-讀取就診資料 – 不需醫事人員卡 (NoNeedHPC)
            /// </summary>
            [Display(Name = "讀取就診資料 – 不需醫事人員卡 (NoNeedHPC)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Treatment/NoNeedHPC")]
            PostV1TreatmentNoNeedHPC,

            /// <summary>
            /// 主控台5.0- 1.8 hisGetTreatmentNeedHPC (讀取就醫資料需要HPC卡的部份)
            /// 業務端6.0-讀取診間就醫資料 (NeedHPC)
            /// </summary>
            [Display(Name = "讀取診間就醫資料 (NeedHPC)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/Treatment/NeedHPC")]
            PostV1TreatmentNeedHPC,

            /// <summary>
            /// 主控台5.0- 1.16 hisWriteTreatmentCode (就醫診療資料寫入作業)
            /// 業務端6.0-寫入就醫診療資料 (WriteCode)
            /// </summary>
            [Display(Name = "寫入就醫診療資料 (WriteCode)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Treatment/WriteCode")]
            PostV1TreatmentWriteCode,

            /// <summary>
            /// 主控台5.0- 1.17 hisWriteTreatmentFee (就醫費用資料寫入作業)
            /// 業務端6.0-寫入就醫費用資料 (WriteFee)
            /// </summary>
            [Display(Name = "寫入就醫費用資料 (WriteFee)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Treatment/WriteFee")]
            PostV1TreatmentWriteFee,

            /// <summary>
            /// 主控台5.0- 1.47 hisWriteTreatmentData (就醫診療資料及費用寫入作業)
            /// 業務端6.0-寫入就醫診療費用資料 (WriteCodeFee)
            /// </summary>
            [Display(Name = "寫入就醫診療費用資料 (WriteCodeFee)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Treatment/WriteCodeFee")]
            PostV1TreatmentWriteCodeFee,
            #endregion

            #region 就醫識別碼相關 (TreatmentNumber)
            /// <summary>
            /// 主控台5.0- 1.54 hisGetTreatNumNoICCard (異常時取得就醫識別碼)
            /// 業務端6.0-異常時取得就醫識別碼 (NoCard)
            /// </summary>
            [Display(Name = "異常時取得就醫識別碼 (NoCard)", ShortName = nameof(NHIVPNICCARD_SignKind._03GetTreatNum), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/TreatmentNumber/NoCard")]
            PostV1TreatmentNumberNoCard,

            /// <summary>
            /// 主控台5.0- 1.56 hisGetTreatNumICCard (單獨取得就醫識別碼)
            /// 業務端6.0-單獨取得就醫識別碼 (Card)
            /// </summary>
            [Display(Name = "單獨取得就醫識別碼 (Card)", ShortName = nameof(NHIVPNICCARD_SignKind._03GetTreatNum), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/TreatmentNumber/Card")]
            PostV1TreatmentNumberCard,

            #endregion

            #region 就醫資料上傳相關 (UploadData)
            /// <summary>
            /// 主控台5.0- 3.1 csUploadData (資料上傳);
            /// 業務端6.0-就醫資料上傳 (Upload)
            /// </summary>
            [Display(Name = "就醫資料上傳 (Upload)", ShortName = nameof(NHIVPNICCARD_SignKind._05UploadTeatmentData), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/UploadData/Upload")]
            PostV1UploadDataUpload,

            #endregion

            #endregion

            #region 測試區 只限於呼叫 測試環境 https://medvpndct.nhi.gov.tw/test
            /// <summary>
            /// 測試區6.0-查詢醫事機構已申請虛擬健保卡 (Query)[需要使用正式 SAM 簽章呼叫]
            /// </summary>
            [Display(Name = "查詢醫事機構已申請虛擬健保卡 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._06TestVirtualHc), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/test/v1/ApplyVirtualHc/Query")]
            PostTestV1ApplyVirtualHcQuery,
            /// <summary>
            /// 測試區6.0-申請測試用虛擬健保卡 (Apply)[需要使用正式 SAM 簽章呼叫]
            /// </summary>
            [Display(Name = "申請測試用虛擬健保卡 (Apply)", ShortName = nameof(NHIVPNICCARD_SignKind._06TestVirtualHc), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/test/v1/ApplyVirtualHc/Apply")]
            PostTestV1ApplyVirtualHcApply,
            /// <summary>
            /// 測試區6.0-產生虛擬健保卡 QR Code (Generate)
            /// </summary>
            [Display(Name = "產生虛擬健保卡 QR Code", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/test/v1/VirtualHc/Generate")]
            PostTestV1VirtualHcGenerate,
            /// <summary>
            /// 測試區6.0-修改測試健保卡器捐註記 (OrganDonate)
            /// </summary>
            [Display(Name = "修改測試健保卡器捐註記", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/test/v1/Hc/OrganDonate")]
            PostTestV1HcOrganDonate,
            /// <summary>
            /// 測試區6.0-修改測試健保卡重大傷病註記 (CriticalIllness)
            /// </summary>
            [Display(Name = "修改測試健保卡重大傷病註記", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/test/v1/Hc/CriticalIllness")]
            PostTestV1HcCriticalIllness,
            /// <summary>
            /// 測試區6.0-修改測試健保卡身份註記 (Identity)
            /// </summary>
            [Display(Name = "修改測試健保卡身份註記", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/test/v1/Hc/Identity")]
            PostTestV1HcIdentity,

            #endregion
        }

        #endregion

        #region Error StatusCode
        /// <summary>
        /// 健保控制軟體6.0 錯誤代碼
        /// Descripation=錯誤代碼(int)
        /// </summary>
        public enum NHIIC_CSHIS60_Error_Code
        {
            /// <summary>
            /// 初始預設錯誤代碼
            /// </summary>
            [Display(Name = "初始預設錯誤代碼")]
            [Description("-1")]
            _Null = 0,
            /// <summary>
            /// 成功
            /// </summary>
            [Display(Name = "成功")]
            [Description("0")]
            _0,

            /// <summary>
            /// 控制軟體尚未初始化
            /// </summary>
            [Display(Name = "控制軟體尚未初始化")]
            [Description("1000")]
            _1000,

            /// <summary>
            /// 控制軟體已初始化
            /// </summary>
            [Display(Name = "控制軟體已初始化")]
            [Description("1001")]
            _1001,

            /// <summary>
            /// 未查詢到指定的或是任何有效的裝置名稱
            /// </summary>
            [Display(Name = "未查詢到指定的或是任何有效的裝置名稱")]
            [Description("1002")]
            _1002,

            /// <summary>
            /// 正式卡與測試卡不能混用
            /// </summary>
            [Display(Name = "正式卡與測試卡不能混用")]
            [Description("1003")]
            _1003,

            /// <summary>
            /// 沒有發現預設 PCSC 讀卡機
            /// </summary>
            [Display(Name = "沒有發現預設 PCSC 讀卡機")]
            [Description("1100")]
            _1100,

            /// <summary>
            /// 目前沒有使用任何 PCSC 讀卡機
            /// </summary>
            [Display(Name = "目前沒有使用任何 PCSC 讀卡機")]
            [Description("1101")]
            _1101,

            /// <summary>
            /// 未置入卡片
            /// </summary>
            [Display(Name = "未置入卡片")]
            [Description("1102")]
            _1102,

            /// <summary>
            /// 切換卡片應用程式失敗
            /// </summary>
            [Display(Name = "切換卡片應用程式失敗")]
            [Description("1103")]
            _1103,

            /// <summary>
            /// PCSC 發生其它錯誤
            /// </summary>
            [Display(Name = "PCSC 發生其它錯誤")]
            [Description("1119")]
            _1119,

            /// <summary>
            /// 無法載入 Reader.dll 檔案
            /// </summary>
            [Display(Name = "無法載入 Reader.dll 檔案")]
            [Description("1200")]
            _1200,

            /// <summary>
            /// 開啟 Comport 失敗
            /// </summary>
            [Display(Name = "開啟 Comport 失敗")]
            [Description("1201")]
            _1201,

            /// <summary>
            /// 操作實體讀卡機失敗
            /// </summary>
            [Display(Name = "操作實體讀卡機失敗")]
            [Description("1202")]
            _1202,

            /// <summary>
            /// 實體讀卡機鍵盤按下取消
            /// </summary>
            [Display(Name = "實體讀卡機鍵盤按下取消")]
            [Description("1203")]
            _1203,

            /// <summary>
            /// SAM 進入模式一失敗
            /// </summary>
            [Display(Name = "SAM 進入模式一失敗")]
            [Description("1300")]
            _1300,

            /// <summary>
            /// SAM 進入模式二失敗
            /// </summary>
            [Display(Name = "SAM 進入模式二失敗")]
            [Description("1301")]
            _1301,

            /// <summary>
            /// 醫事機構已超過合約起迄
            /// </summary>
            [Display(Name = "醫事機構已超過合約起迄")]
            [Description("1302")]
            _1302,

            /// <summary>
            /// 醫事機構已停權
            /// </summary>
            [Display(Name = "醫事機構已停權")]
            [Description("1303")]
            _1303,

            /// <summary>
            /// SAM 已註銷
            /// </summary>
            [Display(Name = "SAM 已註銷")]
            [Description("1304")]
            _1304,

            /// <summary>
            /// 醫事人員卡進入模式一失敗
            /// </summary>
            [Display(Name = "醫事人員卡進入模式一失敗(請重新拔插卡片)")]
            [Description("1400")]
            _1400,

            /// <summary>
            /// 醫事人員卡進入模式二失敗
            /// </summary>
            [Display(Name = "醫事人員卡進入模式二失敗")]
            [Description("1401")]
            _1401,

            /// <summary>
            /// 醫事人員卡進入模式三失敗
            /// </summary>
            [Display(Name = "醫事人員卡進入模式三失敗")]
            [Description("1402")]
            _1402,

            /// <summary>
            /// 醫事人員卡不支援此功能
            /// </summary>
            [Display(Name = "醫事人員卡不支援此功能")]
            [Description("1403")]
            _1403,

            /// <summary>
            /// 醫事人員卡驗證 PIN 碼失敗
            /// </summary>
            [Display(Name = "醫事人員卡驗證 PIN 碼失敗")]
            [Description("1410")]
            _1410,

            /// <summary>
            /// HCA 驗簽失敗
            /// </summary>
            [Display(Name = "HCA 驗簽失敗")]
            [Description("1420")]
            _1420,

            /// <summary>
            /// HCA 簽章逾時
            /// </summary>
            [Display(Name = "HCA 簽章逾時")]
            [Description("1421")]
            _1421,

            /// <summary>
            /// 憑證不在有效期內
            /// </summary>
            [Display(Name = "憑證不在有效期內")]
            [Description("1422")]
            _1422,

            /// <summary>
            /// 未查詢到信任上層憑證
            /// </summary>
            [Display(Name = "未查詢到信任上層憑證")]
            [Description("1423")]
            _1423,

            /// <summary>
            /// 憑證已註消
            /// </summary>
            [Display(Name = "憑證已註消")]
            [Description("1424")]
            _1424,

            /// <summary>
            /// Mobile HCA 驗簽失敗
            /// </summary>
            [Display(Name = "Mobile HCA 驗簽失敗")]
            [Description("1430")]
            _1430,

            /// <summary>
            /// 行動 HCA 驗證，醫事機構代碼與 SAM 不符
            /// </summary>
            [Display(Name = "行動 HCA 驗證，醫事機構代碼與 SAM 不符")]
            [Description("1431")]
            _1431,

            /// <summary>
            /// 健保卡進入模式一失敗
            /// </summary>
            [Display(Name = "健保卡進入模式一失敗(請重新拔插卡片)")]
            [Description("1500")]
            _1500,

            /// <summary>
            /// 健保卡進入模式二失敗
            /// </summary>
            [Display(Name = "健保卡進入模式二失敗")]
            [Description("1501")]
            _1501,

            /// <summary>
            /// 健保卡進入模式三失敗
            /// </summary>
            [Display(Name = "健保卡進入模式三失敗")]
            [Description("1502")]
            _1502,

            /// <summary>
            /// 實體健保卡並無設定 PIN 碼
            /// </summary>
            [Display(Name = "實體健保卡並無設定 PIN 碼")]
            [Description("1510")]
            _1510,

            /// <summary>
            /// 尚未驗證 PIN 碼
            /// </summary>
            [Display(Name = "尚未驗證 PIN 碼")]
            [Description("1511")]
            _1511,

            /// <summary>
            /// 停用 HC PIN 碼失敗
            /// </summary>
            [Display(Name = "停用 HC PIN 碼失敗")]
            [Description("1512")]
            _1512,

            /// <summary>
            /// PIN 碼已驗證
            /// </summary>
            [Display(Name = "PIN 碼已驗證")]
            [Description("1513")]
            _1513,

            /// <summary>
            /// 驗證 HC PIN 碼失敗
            /// </summary>
            [Display(Name = "驗證 HC PIN 碼失敗")]
            [Description("1514")]
            _1514,

            /// <summary>
            /// 呼叫的功能僅支援實體健保卡
            /// </summary>
            [Display(Name = "呼叫的功能僅支援實體健保卡")]
            [Description("1515")]
            _1515,

            /// <summary>
            /// 虛擬健保卡 Token 格式錯誤
            /// </summary>
            [Display(Name = "虛擬健保卡 Token 格式錯誤")]
            [Description("1520")]
            _1520,

            /// <summary>
            /// 虛擬健保卡 Token 已逾時
            /// </summary>
            [Display(Name = "虛擬健保卡 Token 已逾時")]
            [Description("1521")]
            _1521,

            /// <summary>
            /// 虛擬卡 Token 格式不符
            /// </summary>
            [Display(Name = "虛擬卡 Token 格式不符")]
            [Description("1522")]
            _1522,

            /// <summary>
            /// 虛擬卡 Token 驗簽失敗
            /// </summary>
            [Display(Name = "虛擬卡 Token 驗簽失敗")]
            [Description("1523")]
            _1523,

            /// <summary>
            /// 虛擬卡 Token 已逾期
            /// </summary>
            [Display(Name = "虛擬卡 Token 已逾期")]
            [Description("1524")]
            _1524,

            /// <summary>
            /// 虛擬卡 Token 已超過驗證次數
            /// </summary>
            [Display(Name = "虛擬卡 Token 已超過驗證次數")]
            [Description("1525")]
            _1525,

            /// <summary>
            /// 虛擬卡無法呼叫 PIN 相關函式
            /// </summary>
            [Display(Name = "虛擬卡無法呼叫 PIN 相關函式")]
            [Description("1526")]
            _1526,

            /// <summary>
            /// 呼叫的功能僅支援虛擬健保卡
            /// </summary>
            [Display(Name = "呼叫的功能僅支援虛擬健保卡")]
            [Description("1527")]
            _1527,

            /// <summary>
            /// 找不到虛擬健保卡轉移暫存資料
            /// </summary>
            [Display(Name = "找不到虛擬健保卡轉移暫存資料")]
            [Description("1528")]
            _1528,

            /// <summary>
            /// 此虛擬健保卡轉移已被其它狀置使用
            /// </summary>
            [Display(Name = "此虛擬健保卡轉移已被其它狀置使用")]
            [Description("1529")]
            _1529,

            /// <summary>
            /// 虛擬健保卡轉移只能使用在同一家醫事機構
            /// </summary>
            [Display(Name = "虛擬健保卡轉移只能使用在同一家醫事機構")]
            [Description("1530")]
            _1530,

            /// <summary>
            /// 虛擬健保卡已轉移或已失效
            /// </summary>
            [Display(Name = "虛擬健保卡已轉移或已失效")]
            [Description("1531")]
            _1531,

            /// <summary>
            /// 使用讀卡機名稱無法查詢到 PCSC 讀卡機
            /// </summary>
            [Display(Name = "使用讀卡機名稱無法查詢到 PCSC 讀卡機")]
            [Description("1600")]
            _1600,

            /// <summary>
            /// 自動偵測預設讀卡機失敗
            /// </summary>
            [Display(Name = "自動偵測預設讀卡機失敗")]
            [Description("1601")]
            _1601,

            /// <summary>
            /// 雲端安全模組檔案格式錯誤
            /// </summary>
            [Display(Name = "雲端安全模組檔案格式錯誤")]
            [Description("1610")]
            _1610,

            /// <summary>
            /// 沒有查詢到雲端安全模組編號
            /// </summary>
            [Display(Name = "沒有查詢到雲端安全模組編號")]
            [Description("1611")]
            _1611,

            /// <summary>
            /// 與 DC 通訊連線異常
            /// </summary>
            [Display(Name = "與 DC 通訊連線異常")]
            [Description("1700")]
            _1700,

            /// <summary>
            /// 與 DC 通訊命令代碼不存在
            /// </summary>
            [Display(Name = "與 DC 通訊命令代碼不存在")]
            [Description("1701")]
            _1701,

            /// <summary>
            /// 與 DC 通訊回覆 HTTP 相關異常代碼
            /// </summary>
            [Display(Name = "與 DC 通訊回覆 HTTP 相關異常代碼")]
            [Description("1702")]
            _1702,

            /// <summary>
            /// Session 不存在或已逾期
            /// </summary>
            [Display(Name = "Session 不存在或已逾期")]
            [Description("1703")]
            _1703,

            /// <summary>
            /// 參數格式異常
            /// </summary>
            [Display(Name = "參數格式異常")]
            [Description("1704")]
            _1704,

            /// <summary>
            /// 參數格式異常
            /// </summary>
            [Display(Name = "參數格式異常")]
            [Description("1705")]
            _1705,

            /// <summary>
            /// 參數格式異常
            /// </summary>
            [Display(Name = "參數格式異常")]
            [Description("1706")]
            _1706,

            /// <summary>
            /// HCA 卡片已登出或在其它主機登入
            /// </summary>
            [Display(Name = "HCA 卡片已登出或在其它主機登入")]
            [Description("1707")]
            _1707,

            /// <summary>
            /// DC 端未定義錯誤
            /// </summary>
            [Display(Name = "DC 端未定義錯誤")]
            [Description("1799")]
            _1799,

            /// <summary>
            /// 驗證簽章錯誤
            /// </summary>
            [Display(Name = "驗證簽章錯誤")]
            [Description("3100")]
            _3100,

            /// <summary>
            /// 尚未驗證健保卡 PIN 碼
            /// </summary>
            [Display(Name = "尚未驗證健保卡 PIN 碼")]
            [Description("3200")]
            _3200,

            /// <summary>
            /// 超過卡片有期限
            /// </summary>
            [Display(Name = "超過卡片有期限")]
            [Description("3201")]
            _3201,

            /// <summary>
            /// 非醫療院所
            /// </summary>
            [Display(Name = "非醫療院所")]
            [Description("3202")]
            _3202,

            /// <summary>
            /// 卡片已註銷
            /// </summary>
            [Display(Name = "卡片已註銷")]
            [Description("3203")]
            _3203,

            /// <summary>
            /// 就醫識別碼編碼失敗
            /// </summary>
            [Display(Name = "就醫識別碼編碼失敗")]
            [Description("3204")]
            _3204,

            /// <summary>
            /// 限制就醫
            /// </summary>
            [Display(Name = "限制就醫")]
            [Description("3205")]
            _3205,

            /// <summary>
            /// 無新生兒生日
            /// </summary>
            [Display(Name = "無新生兒生日")]
            [Description("3206")]
            _3206,

            /// <summary>
            /// 新生兒依附就醫已逾時
            /// </summary>
            [Display(Name = "新生兒依附就醫已逾時")]
            [Description("3207")]
            _3207,

            /// <summary>
            /// 找不到「就醫資料登錄」中的該組資料
            /// </summary>
            [Display(Name = "找不到「就醫資料登錄」中的該組資料")]
            [Description("3208")]
            _3208,

            /// <summary>
            /// 已寫入診斷碼
            /// </summary>
            [Display(Name = "已寫入診斷碼")]
            [Description("3209")]
            _3209,

            /// <summary>
            /// ICD 10 編碼失敗
            /// </summary>
            [Display(Name = "ICD 10 編碼失敗")]
            [Description("3210")]
            _3210,

            /// <summary>
            /// 非同一家醫事機構
            /// </summary>
            [Display(Name = "非同一家醫事機構")]
            [Description("3211")]
            _3211,

            /// <summary>
            /// 僅用醫師才有權限呼叫此函式
            /// </summary>
            [Display(Name = "僅用醫師才有權限呼叫此函式")]
            [Description("3212")]
            _3212,

            /// <summary>
            /// 就醫可用次數為零
            /// </summary>
            [Display(Name = "就醫可用次數為零")]
            [Description("3213")]
            _3213,

            /// <summary>
            /// 最近 6 次就醫不含就醫類別 AC，不可單獨寫入預防保健或產檢紀錄
            /// </summary>
            [Display(Name = "最近 6 次就醫不含就醫類別 AC，不可單獨寫入預防保健或產檢紀錄")]
            [Description("3214")]
            _3214,

            /// <summary>
            /// 最近 24 小時內同院所未曾執行保健服務項目紀錄，故不可取消保健服務（輸入 YA~YF 時檢查）
            /// </summary>
            [Display(Name = "最近 24 小時內同院所未曾執行保健服務項目紀錄，故不可取消保健服務（輸入 YA~YF 時檢查）")]
            [Description("3215")]
            _3215,

            /// <summary>
            /// 不為女性
            /// </summary>
            [Display(Name = "不為女性")]
            [Description("3216")]
            _3216,

            /// <summary>
            /// 近 24 小時內同院所未曾執行產檢服務紀錄，故不可取消產檢（輸入 XA 時檢查）
            /// </summary>
            [Display(Name = "近 24 小時內同院所未曾執行產檢服務紀錄，故不可取消產檢（輸入 XA 時檢查）")]
            [Description("3217")]
            _3217,

            /// <summary>
            /// 不允許退掛，退掛時間已超過24小時
            /// </summary>
            [Display(Name = "不允許退掛，退掛時間已超過24小時")]
            [Description("3218")]
            _3218,

            /// <summary>
            /// 就醫類別為數值才可退掛
            /// </summary>
            [Display(Name = "就醫類別為數值才可退掛")]
            [Description("3219")]
            _3219,

            /// <summary>
            /// 本筆就醫記錄已經退掛過，不可重覆退掛
            /// </summary>
            [Display(Name = "本筆就醫記錄已經退掛過，不可重覆退掛")]
            [Description("3220")]
            _3220,

            /// <summary>
            /// 就醫可用次數不合理
            /// </summary>
            [Display(Name = "就醫可用次數不合理")]
            [Description("3221")]
            _3221,

            /// <summary>
            /// 最近一次就醫序號不合理
            /// </summary>
            [Display(Name = "最近一次就醫序號不合理")]
            [Description("3222")]
            _3222,

            /// <summary>
            /// 最近一次就醫年不合理
            /// </summary>
            [Display(Name = "最近一次就醫年不合理")]
            [Description("3223")]
            _3223,

            /// <summary>
            /// 最近一次就醫序號不合理
            /// </summary>
            [Display(Name = "最近一次就醫序號不合理")]
            [Description("3224")]
            _3224,

            /// <summary>
            /// 就醫累計資料年不合理
            /// </summary>
            [Display(Name = "就醫累計資料年不合理")]
            [Description("3225")]
            _3225,

            /// <summary>
            /// 門住診就醫累計次數不合理
            /// </summary>
            [Display(Name = "門住診就醫累計次數不合理")]
            [Description("3226")]
            _3226,

            /// <summary>
            /// 就醫日期不一致
            /// </summary>
            [Display(Name = "就醫日期不一致")]
            [Description("3227")]
            _3227,

            /// <summary>
            /// 不在保
            /// </summary>
            [Display(Name = "不在保")]
            [Description("3228")]
            _3228,

            /// <summary>
            /// 已停保
            /// </summary>
            [Display(Name = "已停保")]
            [Description("3229")]
            _3229,

            /// <summary>
            /// 已退保
            /// </summary>
            [Display(Name = "已退保")]
            [Description("3230")]
            _3230,

            /// <summary>
            /// 已停保或已退保(查保)
            /// </summary>
            [Display(Name = "已停保或已退保(查保)")]
            [Description("3231")]
            _3231,

            /// <summary>
            /// 在查保名單中(查保)
            /// </summary>
            [Display(Name = "在查保名單中(查保)")]
            [Description("3232")]
            _3232,

            /// <summary>
            /// 個人及單位均欠費
            /// </summary>
            [Display(Name = "個人及單位均欠費")]
            [Description("3233")]
            _3233,

            /// <summary>
            /// 聲明不實
            /// </summary>
            [Display(Name = "聲明不實")]
            [Description("3234")]
            _3234,

            /// <summary>
            /// 其它原因
            /// </summary>
            [Display(Name = "其它原因")]
            [Description("3235")]
            _3235,

            /// <summary>
            /// 同一時間重覆上傳
            /// </summary>
            [Display(Name = "同一時間重覆上傳")]
            [Description("3236")]
            _3236,

            /// <summary>
            /// 未查詢到 Access Token
            /// </summary>
            [Display(Name = "未查詢到 Access Token")]
            [Description("3237")]
            _3237,

            /// <summary>
            /// Access Token 已逾時
            /// </summary>
            [Display(Name = "Access Token 已逾時")]
            [Description("3238")]
            _3238,

            /// <summary>
            /// Access Token 尚未授權
            /// </summary>
            [Display(Name = "Access Token 尚未授權")]
            [Description("3239")]
            _3239,

            /// <summary>
            /// Access Token 拒絕授權
            /// </summary>
            [Display(Name = "Access Token 拒絕授權")]
            [Description("3240")]
            _3240,

            /// <summary>
            /// 虛擬卡 Token 不存在
            /// </summary>
            [Display(Name = "虛擬卡 Token 不存在")]
            [Description("3241")]
            _3241,

            /// <summary>
            /// 同時就醫時間相同
            /// </summary>
            [Display(Name = "同時就醫時間相同")]
            [Description("3242")]
            _3242,

            /// <summary>
            /// 非醫師或藥師
            /// </summary>
            [Display(Name = "非醫師或藥師")]
            [Description("3243")]
            _3243,

            /// <summary>
            /// 虛擬健保卡 QR Code 已取得就醫資料
            /// </summary>
            [Display(Name = "虛擬健保卡 QR Code 已取得就醫資料")]
            [Description("3244")]
            _3244,

            /// <summary>
            /// 簽章已取得就醫資料
            /// </summary>
            [Display(Name = "簽章已取得就醫資料")]
            [Description("3245")]
            _3245,

            /// <summary>
            /// 金鑰不存在
            /// </summary>
            [Display(Name = "金鑰不存在")]
            [Description("3300")]
            _3300,

            /// <summary>
            /// 無虛擬卡模型資料
            /// </summary>
            [Display(Name = "無虛擬卡模型資料")]
            [Description("3301")]
            _3301,

            /// <summary>
            /// 無 SAM 資料
            /// </summary>
            [Display(Name = "無 SAM 資料")]
            [Description("3302")]
            _3302,

            /// <summary>
            /// 無虛擬健保卡暫存資料
            /// </summary>
            [Display(Name = "無虛擬健保卡暫存資料")]
            [Description("3303")]
            _3303,

            /// <summary>
            /// 無驗簽暫存資料
            /// </summary>
            [Display(Name = "無驗簽暫存資料")]
            [Description("3304")]
            _3304,

            /// <summary>
            /// 卡片更新失敗
            /// </summary>
            [Display(Name = "卡片更新失敗")]
            [Description("3400")]
            _3400,

            /// <summary>
            /// 退掛失敗
            /// </summary>
            [Display(Name = "退掛失敗")]
            [Description("3401")]
            _3401,

            /// <summary>
            /// 查保失敗
            /// </summary>
            [Display(Name = "查保失敗")]
            [Description("3402")]
            _3402,

            /// <summary>
            /// PKI 服務失敗
            /// </summary>
            [Display(Name = "PKI 服務失敗")]
            [Description("3500")]
            _3500,

            /// <summary>
            /// 所傳入的診斷碼不在押碼範圍或所傳入的押碼內容不是有效的資料
            /// </summary>
            [Display(Name = "所傳入的診斷碼不在押碼範圍或所傳入的押碼內容不是有效的資料")]
            [Description("3501")]
            _3501,

            /// <summary>
            /// 相容性元件版本不在白名單中
            /// </summary>
            [Display(Name = "相容性元件版本不在白名單中")]
            [Description("3502")]
            _3502,

            /// <summary>
            /// 相容性元件版本在黑名單中
            /// </summary>
            [Display(Name = "相容性元件版本在黑名單中")]
            [Description("3503")]
            _3503,
        }

        /// <summary>
        /// 健保控制軟體5.0 錯誤代碼
        /// Descripation=錯誤代碼(int)
        /// </summary>
        public enum NHIIC_CSHIS50_Error_Code
        {
            /// <summary>
            /// 初始預設錯誤代碼
            /// </summary>
            [Display(Name = "初始預設錯誤代碼")]
            [Description("-1")]
            _Null = 0,

            /// <summary>
            /// 成功 0 
            /// </summary>
            [Display(Name = "成功")]
            [Description("0")]
            _0,

            /// <summary>
            /// 讀卡機timeout 4000 
            /// </summary>
            [Display(Name = "讀卡機timeout")]
            [Description("4000")]
            _4000,

            /// <summary>
            /// 未置入安全模組卡 4012 
            /// </summary>
            [Display(Name = "未置入安全模組卡")]
            [Description("4012")]
            _4012,

            /// <summary>
            /// 未置入健保IC卡 4013 
            /// </summary>
            [Display(Name = "未置入健保IC卡")]
            [Description("4013")]
            _4013,

            /// <summary>
            /// 未置入醫事人員卡 4014 
            /// </summary>
            [Display(Name = "未置入醫事人員卡")]
            [Description("4014")]
            _4014,

            /// <summary>
            /// IC卡權限不足 4029 
            /// </summary>
            [Display(Name = "IC卡權限不足")]
            [Description("4029")]
            _4029,

            /// <summary>
            /// 所插入非安全模組卡 4032 
            /// </summary>
            [Display(Name = "所插入非安全模組卡")]
            [Description("4032")]
            _4032,

            /// <summary>
            /// 所置入非健保IC卡 4033 
            /// </summary>
            [Display(Name = "所置入非健保IC卡")]
            [Description("4033")]
            _4033,

            /// <summary>
            /// 所置入非醫事人員卡 4034 
            /// </summary>
            [Display(Name = "所置入非醫事人員卡")]
            [Description("4034")]
            _4034,

            /// <summary>
            /// 醫事人員卡PIN尚未認證成功 4042 
            /// </summary>
            [Display(Name = "醫事人員卡PIN尚未認證成功")]
            [Description("4042")]
            _4042,

            /// <summary>
            /// 安全模組尚未與IDC認證 4050 
            /// </summary>
            [Display(Name = "安全模組尚未與IDC認證")]
            [Description("4050")]
            _4050,

            /// <summary>
            /// 安全模組與IDC認證失敗 4051 
            /// </summary>
            [Display(Name = "安全模組與IDC認證失敗")]
            [Description("4051")]
            _4051,

            /// <summary>
            /// 網路不通 4061 
            /// </summary>
            [Display(Name = "網路不通")]
            [Description("4061")]
            _4061,

            /// <summary>
            /// 健保IC卡與IDC認證失敗 4071 
            /// </summary>
            [Display(Name = "健保IC卡與IDC認證失敗")]
            [Description("4071")]
            _4071,

            /// <summary>
            /// 就醫可用次數不足 5001 
            /// </summary>
            [Display(Name = "就醫可用次數不足")]
            [Description("5001")]
            _5001,

            /// <summary>
            /// 卡片已註銷 5002 
            /// </summary>
            [Display(Name = "卡片已註銷")]
            [Description("5002")]
            _5002,

            /// <summary>
            /// 卡片已過有限期限 5003 
            /// </summary>
            [Display(Name = "卡片已過有限期限")]
            [Description("5003")]
            _5003,

            /// <summary>
            /// 非新生兒一個月內就診 5004 
            /// </summary>
            [Display(Name = "非新生兒一個月內就診")]
            [Description("5004")]
            _5004,

            /// <summary>
            /// 讀卡機的日期時間讀取失敗 5005 
            /// </summary>
            [Display(Name = "讀卡機的日期時間讀取失敗")]
            [Description("5005")]
            _5005,

            /// <summary>
            /// 讀取安全模組內的「醫療院所代碼」失敗 5006 
            /// </summary>
            [Display(Name = "讀取安全模組內的「醫療院所代碼」失敗")]
            [Description("5006")]
            _5006,

            /// <summary>
            /// 寫入一組新的「就醫資料登錄」失敗 5007 
            /// </summary>
            [Display(Name = "寫入一組新的「就醫資料登錄」失敗")]
            [Description("5007")]
            _5007,

            /// <summary>
            /// 安全模組簽章失敗 5008 
            /// </summary>
            [Display(Name = "安全模組簽章失敗")]
            [Description("5008")]
            _5008,

            /// <summary>
            /// 無寫入就醫相關紀錄之權限 5009 
            /// </summary>
            [Display(Name = "無寫入就醫相關紀錄之權限")]
            [Description("5009")]
            _5009,

            /// <summary>
            /// 同一天看診兩科(含)以上 5010 
            /// </summary>
            [Display(Name = "同一天看診兩科(含)以上")]
            [Description("5010")]
            _5010,

            /// <summary>
            /// 此人未在保或欠費 5012 
            /// </summary>
            [Display(Name = "此人未在保或欠費")]
            [Description("5012")]
            _5012,

            /// <summary>
            /// 「門診處方箋」讀取失敗。 5015 
            /// </summary>
            [Display(Name = "「門診處方箋」讀取失敗。")]
            [Description("5015")]
            _5015,

            /// <summary>
            /// 「長期處方箋」讀取失敗。 5016 
            /// </summary>
            [Display(Name = "「長期處方箋」讀取失敗。")]
            [Description("5016")]
            _5016,

            /// <summary>
            /// 「重要醫令」讀取失敗。 5017 
            /// </summary>
            [Display(Name = "「重要醫令」讀取失敗。")]
            [Description("5017")]
            _5017,

            /// <summary>
            /// 要寫入的資料和健保IC卡不是屬於同一人。 5020 
            /// </summary>
            [Display(Name = "要寫入的資料和健保IC卡不是屬於同一人。")]
            [Description("5020")]
            _5020,

            /// <summary>
            /// 找不到「就醫資料登錄」中的該組資料。 5022 
            /// </summary>
            [Display(Name = "找不到「就醫資料登錄」中的該組資料。")]
            [Description("5022")]
            _5022,

            /// <summary>
            /// 「就醫資料登錄」寫入失敗。 5023 
            /// </summary>
            [Display(Name = "「就醫資料登錄」寫入失敗。")]
            [Description("5023")]
            _5023,

            /// <summary>
            /// HC卡「就醫費用紀錄」寫入失敗。 5028 
            /// </summary>
            [Display(Name = "HC卡「就醫費用紀錄」寫入失敗。")]
            [Description("5028")]
            _5028,

            /// <summary>
            /// 「門診處方箋」寫入失敗。 5033 
            /// </summary>
            [Display(Name = "「門診處方箋」寫入失敗。")]
            [Description("5033")]
            _5033,

            /// <summary>
            /// 新生兒註記寫入失敗 5051 
            /// </summary>
            [Display(Name = "新生兒註記寫入失敗")]
            [Description("5051")]
            _5051,

            /// <summary>
            /// 有新生兒出生日期，但無新生兒胞胎註記資料 5052 
            /// </summary>
            [Display(Name = "有新生兒出生日期，但無新生兒胞胎註記資料")]
            [Description("5052")]
            _5052,

            /// <summary>
            /// 讀取醫事人員ID失敗 5056 
            /// </summary>
            [Display(Name = "讀取醫事人員ID失敗")]
            [Description("5056")]
            _5056,

            /// <summary>
            /// 過敏藥物寫入失敗。 5057 
            /// </summary>
            [Display(Name = "過敏藥物寫入失敗。")]
            [Description("5057")]
            _5057,

            /// <summary>
            /// 同意器官捐贈及安寧緩和醫療註記寫入失敗寫入失敗 5061 
            /// </summary>
            [Display(Name = "同意器官捐贈及安寧緩和醫療註記寫入失敗寫入失敗")]
            [Description("5061")]
            _5061,

            /// <summary>
            /// 放棄同意器官捐贈及安寧緩和醫療註記輸入 5062 
            /// </summary>
            [Display(Name = "放棄同意器官捐贈及安寧緩和醫療註記輸入")]
            [Description("5062")]
            _5062,

            /// <summary>
            /// 安全模組卡「醫療院所代碼」讀取失敗 5067 
            /// </summary>
            [Display(Name = "安全模組卡「醫療院所代碼」讀取失敗")]
            [Description("5067")]
            _5067,

            /// <summary>
            /// 預防保健資料寫入失敗 5068 
            /// </summary>
            [Display(Name = "預防保健資料寫入失敗")]
            [Description("5068")]
            _5068,

            /// <summary>
            /// 緊急聯絡電話寫失敗。 5071 
            /// </summary>
            [Display(Name = "緊急聯絡電話寫失敗。")]
            [Description("5071")]
            _5071,

            /// <summary>
            /// 產前檢查資料寫入失敗 5078 
            /// </summary>
            [Display(Name = "產前檢查資料寫入失敗")]
            [Description("5078")]
            _5078,

            /// <summary>
            /// 性別不符，健保IC卡記載為男性 5079 
            /// </summary>
            [Display(Name = "性別不符，健保IC卡記載為男性")]
            [Description("5079")]
            _5079,

            /// <summary>
            /// 最近24小時內同院所未曾就醫，故不可取消就醫 5081 
            /// </summary>
            [Display(Name = "最近24小時內同院所未曾就醫，故不可取消就醫")]
            [Description("5081")]
            _5081,

            /// <summary>
            /// 最近24小時內同院所未曾執行產檢服務紀錄，故不可取消產檢 5082 
            /// </summary>
            [Display(Name = "最近24小時內同院所未曾執行產檢服務紀錄，故不可取消產檢")]
            [Description("5082")]
            _5082,

            /// <summary>
            /// 最近6次就醫不含就醫類別AC，不可單獨寫入預防保健或產檢紀錄 5083 
            /// </summary>
            [Display(Name = "最近6次就醫不含就醫類別AC，不可單獨寫入預防保健或產檢紀錄")]
            [Description("5083")]
            _5083,

            /// <summary>
            /// 最近24小時內同院所未曾執行保健服務項目紀錄，故不可取消保健服務 5084 
            /// </summary>
            [Display(Name = "最近24小時內同院所未曾執行保健服務項目紀錄，故不可取消保健服務")]
            [Description("5084")]
            _5084,

            /// <summary>
            /// 刪除「孕婦產前檢查(限女性)」全部11 組的資料失敗。 5087 
            /// </summary>
            [Display(Name = "刪除「孕婦產前檢查(限女性)」全部11 組的資料失敗。")]
            [Description("5087")]
            _5087,

            /// <summary>
            /// 預防接種資料寫入失敗 5093 
            /// </summary>
            [Display(Name = "預防接種資料寫入失敗")]
            [Description("5093")]
            _5093,

            /// <summary>
            /// 使用者所輸入之pin 值，與卡上之pin值不合 5102 
            /// </summary>
            [Display(Name = "使用者所輸入之pin 值，與卡上之pin值不合")]
            [Description("5102")]
            _5102,

            /// <summary>
            /// 原PIN碼尚未通過認證 5105 
            /// </summary>
            [Display(Name = "原PIN碼尚未通過認證")]
            [Description("5105")]
            _5105,

            /// <summary>
            /// 使用者輸入兩次新PIN 值，兩次PIN 值不合 5107 
            /// </summary>
            [Display(Name = "使用者輸入兩次新PIN 值，兩次PIN 值不合")]
            [Description("5107")]
            _5107,

            /// <summary>
            /// 密碼變更失敗 5108 
            /// </summary>
            [Display(Name = "密碼變更失敗")]
            [Description("5108")]
            _5108,

            /// <summary>
            /// 密碼輸入過程按『取消』鍵 5109 
            /// </summary>
            [Display(Name = "密碼輸入過程按『取消』鍵")]
            [Description("5109")]
            _5109,

            /// <summary>
            /// 變更健保IC卡密碼時, 請移除醫事人員卡 5110 
            /// </summary>
            [Display(Name = "變更健保IC卡密碼時, 請移除醫事人員卡")]
            [Description("5110")]
            _5110,

            /// <summary>
            /// 停用失敗，且健保IC卡之Pin 碼輸入功能仍啟用 5111 
            /// </summary>
            [Display(Name = "停用失敗，且健保IC卡之Pin 碼輸入功能仍啟用")]
            [Description("5111")]
            _5111,

            /// <summary>
            /// 被鎖住的醫事人員卡仍未解開 5122 
            /// </summary>
            [Display(Name = "被鎖住的醫事人員卡仍未解開")]
            [Description("5122")]
            _5122,

            /// <summary>
            /// 更新健保IC卡內容失敗。 5130 
            /// </summary>
            [Display(Name = "更新健保IC卡內容失敗。")]
            [Description("5130")]
            _5130,

            /// <summary>
            /// 未置入醫事人員卡, 僅能讀取重大傷病有效起訖日期 5141 
            /// </summary>
            [Display(Name = "未置入醫事人員卡, 僅能讀取重大傷病有效起訖日期")]
            [Description("5141")]
            _5141,

            /// <summary>
            /// 卡片中無此筆就醫記錄 5150 
            /// </summary>
            [Display(Name = "卡片中無此筆就醫記錄")]
            [Description("5150")]
            _5150,

            /// <summary>
            /// 就醫類別為數值才可退掛 5151 
            /// </summary>
            [Display(Name = "就醫類別為數值才可退掛")]
            [Description("5151")]
            _5151,

            /// <summary>
            /// 醫療院所不同，不可退掛 5152 
            /// </summary>
            [Display(Name = "醫療院所不同，不可退掛")]
            [Description("5152")]
            _5152,

            /// <summary>
            /// 本筆就醫記錄已經退掛過，不可重覆退掛 5153 
            /// </summary>
            [Display(Name = "本筆就醫記錄已經退掛過，不可重覆退掛")]
            [Description("5153")]
            _5153,

            /// <summary>
            /// 退掛日期不符合規定 5154 
            /// </summary>
            [Display(Name = "退掛日期不符合規定")]
            [Description("5154")]
            _5154,

            /// <summary>
            /// 就醫可用次數不合理 5160 
            /// </summary>
            [Display(Name = "就醫可用次數不合理")]
            [Description("5160")]
            _5160,

            /// <summary>
            /// 最近一次就醫年不合理 5161 
            /// </summary>
            [Display(Name = "最近一次就醫年不合理")]
            [Description("5161")]
            _5161,

            /// <summary>
            /// 最近一次就醫序號不合理 5162 
            /// </summary>
            [Display(Name = "最近一次就醫序號不合理")]
            [Description("5162")]
            _5162,

            /// <summary>
            /// 住診費用總累計不合理 5163 
            /// </summary>
            [Display(Name = "住診費用總累計不合理")]
            [Description("5163")]
            _5163,

            /// <summary>
            /// 門診費用總累計不合理 5164 
            /// </summary>
            [Display(Name = "門診費用總累計不合理")]
            [Description("5164")]
            _5164,

            /// <summary>
            /// 就醫累計資料年不合理 5165 
            /// </summary>
            [Display(Name = "就醫累計資料年不合理")]
            [Description("5165")]
            _5165,

            /// <summary>
            /// 門住診就醫累計次數不合理 5166 
            /// </summary>
            [Display(Name = "門住診就醫累計次數不合理")]
            [Description("5166")]
            _5166,

            /// <summary>
            /// 門診部分負擔費用累計不合理 5167 
            /// </summary>
            [Display(Name = "門診部分負擔費用累計不合理")]
            [Description("5167")]
            _5167,

            /// <summary>
            /// 住診急性30天、慢性180天以下部分負擔費用累計不合理 5168 
            /// </summary>
            [Display(Name = "住診急性30天、慢性180天以下部分負擔費用累計不合理")]
            [Description("5168")]
            _5168,

            /// <summary>
            /// 住診急性31天、慢性181天以上部分負擔費用累計不合理 5169 
            /// </summary>
            [Display(Name = "住診急性31天、慢性181天以上部分負擔費用累計不合理")]
            [Description("5169")]
            _5169,

            /// <summary>
            /// 門診+住診部分負擔費用累計不合理 5170 
            /// </summary>
            [Display(Name = "門診+住診部分負擔費用累計不合理")]
            [Description("5170")]
            _5170,

            /// <summary>
            /// [門診+住診(急性30天、慢性180天以下)]部分負擔費用累計不合理 5171 
            /// </summary>
            [Display(Name = "[門診+住診(急性30天、慢性180天以下)]部分負擔費用累計不合理")]
            [Description("5171")]
            _5171,

            /// <summary>
            /// 門診醫療費用累計不合理 5172 
            /// </summary>
            [Display(Name = "門診醫療費用累計不合理")]
            [Description("5172")]
            _5172,

            /// <summary>
            /// 住診醫療費用累計不合理 5173 
            /// </summary>
            [Display(Name = "住診醫療費用累計不合理")]
            [Description("5173")]
            _5173,

            /// <summary>
            /// 取就醫識別碼失敗 5174 
            /// </summary>
            [Display(Name = "取就醫識別碼失敗")]
            [Description("5174")]
            _5174,

            /// <summary>
            /// 安全模組卡的外部認證失敗 6005 
            /// </summary>
            [Display(Name = "安全模組卡的外部認證失敗")]
            [Description("6005")]
            _6005,

            /// <summary>
            /// IDC的外部認證失敗 6006 
            /// </summary>
            [Display(Name = "IDC的外部認證失敗")]
            [Description("6006")]
            _6006,

            /// <summary>
            /// 安全模組卡的內部認證失敗 6007 
            /// </summary>
            [Display(Name = "安全模組卡的內部認證失敗")]
            [Description("6007")]
            _6007,

            /// <summary>
            /// 寫入讀卡機日期時間失敗 6008 
            /// </summary>
            [Display(Name = "寫入讀卡機日期時間失敗")]
            [Description("6008")]
            _6008,

            /// <summary>
            /// IDC 驗證簽章失敗 6014 
            /// </summary>
            [Display(Name = "IDC 驗證簽章失敗")]
            [Description("6014")]
            _6014,

            /// <summary>
            /// 檔案大小不合或檔案傳輸失敗 6015 
            /// </summary>
            [Display(Name = "檔案大小不合或檔案傳輸失敗")]
            [Description("6015")]
            _6015,

            /// <summary>
            /// 記憶體空間不足 6016 
            /// </summary>
            [Display(Name = "記憶體空間不足")]
            [Description("6016")]
            _6016,

            /// <summary>
            /// 權限不足無法開啟檔案或找不到檔案 6017 
            /// </summary>
            [Display(Name = "權限不足無法開啟檔案或找不到檔案")]
            [Description("6017")]
            _6017,

            /// <summary>
            /// 傳入參數錯誤  6018 
            /// </summary>
            [Display(Name = "傳入參數錯誤 ")]
            [Description("6018")]
            _6018,

            /// <summary>
            /// 送至IDC Message Header 檢核不符 9001 
            /// </summary>
            [Display(Name = "送至IDC Message Header 檢核不符")]
            [Description("9001")]
            _9001,

            /// <summary>
            /// 送至IDC語法不符 9002 
            /// </summary>
            [Display(Name = "送至IDC語法不符")]
            [Description("9002")]
            _9002,

            /// <summary>
            /// 與IDC作業逾時 9003 
            /// </summary>
            [Display(Name = "與IDC作業逾時")]
            [Description("9003")]
            _9003,

            /// <summary>
            /// IDC異常無法Service 9004 
            /// </summary>
            [Display(Name = "IDC異常無法Service")]
            [Description("9004")]
            _9004,

            /// <summary>
            /// IDC無法驗證該卡片 9010 
            /// </summary>
            [Display(Name = "IDC無法驗證該卡片")]
            [Description("9010")]
            _9010,

            /// <summary>
            /// IDC驗證健保IC卡失敗 9011 
            /// </summary>
            [Display(Name = "IDC驗證健保IC卡失敗")]
            [Description("9011")]
            _9011,

            /// <summary>
            /// IDC無該卡片資料 9012 
            /// </summary>
            [Display(Name = "IDC無該卡片資料")]
            [Description("9012")]
            _9012,

            /// <summary>
            /// 無效的安全模組卡 9013 
            /// </summary>
            [Display(Name = "無效的安全模組卡")]
            [Description("9013")]
            _9013,

            /// <summary>
            /// IDC對安全模組卡認證失敗 9014 
            /// </summary>
            [Display(Name = "IDC對安全模組卡認證失敗")]
            [Description("9014")]
            _9014,

            /// <summary>
            /// 安全模組卡對IDC認證失敗 9015 
            /// </summary>
            [Display(Name = "安全模組卡對IDC認證失敗")]
            [Description("9015")]
            _9015,

            /// <summary>
            /// IDC驗章錯誤 9020 
            /// </summary>
            [Display(Name = "IDC驗章錯誤")]
            [Description("9020")]
            _9020,

            /// <summary>
            /// 無法執行卡片管理系統的認證 9030 
            /// </summary>
            [Display(Name = "無法執行卡片管理系統的認證")]
            [Description("9030")]
            _9030,

            /// <summary>
            /// 無法執行健保IC卡Applet Perso認證 9040 
            /// </summary>
            [Display(Name = "無法執行健保IC卡Applet Perso認證")]
            [Description("9040")]
            _9040,

            /// <summary>
            /// 健保IC卡Applet Perso認證失敗 9041 
            /// </summary>
            [Display(Name = "健保IC卡Applet Perso認證失敗")]
            [Description("9041")]
            _9041,

            /// <summary>
            /// 無法執行安全模組卡世代碼更新認證 9050 
            /// </summary>
            [Display(Name = "無法執行安全模組卡世代碼更新認證")]
            [Description("9050")]
            _9050,

            /// <summary>
            /// 安全模組卡世代碼更新認證失敗 9051 
            /// </summary>
            [Display(Name = "安全模組卡世代碼更新認證失敗")]
            [Description("9051")]
            _9051,

            /// <summary>
            /// 安全模組卡遭停約處罰 9060 
            /// </summary>
            [Display(Name = "安全模組卡遭停約處罰")]
            [Description("9060")]
            _9060,

            /// <summary>
            /// 安全模組卡不在有效期內 9061 
            /// </summary>
            [Display(Name = "安全模組卡不在有效期內")]
            [Description("9061")]
            _9061,

            /// <summary>
            /// 安全模組卡合約逾期或尚未生效 9062 
            /// </summary>
            [Display(Name = "安全模組卡合約逾期或尚未生效")]
            [Description("9062")]
            _9062,

            /// <summary>
            /// 上傳資料大小不符無法接收檔案 9070 
            /// </summary>
            [Display(Name = "上傳資料大小不符無法接收檔案")]
            [Description("9070")]
            _9070,

            /// <summary>
            /// 上傳日期與 Data Center 不一致 9071 
            /// </summary>
            [Display(Name = "上傳日期與 Data Center 不一致")]
            [Description("9071")]
            _9071,

            /// <summary>
            /// 卡片可用次數大於3次, 未達可更新標準 9081 
            /// </summary>
            [Display(Name = "卡片可用次數大於3次, 未達可更新標準")]
            [Description("9081")]
            _9081,

            /// <summary>
            /// 此卡已被註銷, 無法進行卡片更新作業 9082 
            /// </summary>
            [Display(Name = "此卡已被註銷, 無法進行卡片更新作業")]
            [Description("9082")]
            _9082,

            /// <summary>
            /// 不在保 9083 
            /// </summary>
            [Display(Name = "不在保")]
            [Description("9083")]
            _9083,

            /// <summary>
            /// 停保中 9084 
            /// </summary>
            [Display(Name = "停保中")]
            [Description("9084")]
            _9084,

            /// <summary>
            /// 已退保 9085 
            /// </summary>
            [Display(Name = "已退保")]
            [Description("9085")]
            _9085,

            /// <summary>
            /// 個人欠費 9086 
            /// </summary>
            [Display(Name = "個人欠費")]
            [Description("9086")]
            _9086,

            /// <summary>
            /// 負責人欠費 9087 
            /// </summary>
            [Display(Name = "負責人欠費")]
            [Description("9087")]
            _9087,

            /// <summary>
            /// 投保單位欠費 9088 
            /// </summary>
            [Display(Name = "投保單位欠費")]
            [Description("9088")]
            _9088,

            /// <summary>
            /// 個人及單位均欠費 9089 
            /// </summary>
            [Display(Name = "個人及單位均欠費")]
            [Description("9089")]
            _9089,

            /// <summary>
            /// 欠費且未在保 9090 
            /// </summary>
            [Display(Name = "欠費且未在保")]
            [Description("9090")]
            _9090,

            /// <summary>
            /// 聲明不實 9091 
            /// </summary>
            [Display(Name = "聲明不實")]
            [Description("9091")]
            _9091,

            /// <summary>
            /// 其他 9092 
            /// </summary>
            [Display(Name = "其他")]
            [Description("9092")]
            _9092,

            /// <summary>
            /// 藥師藥局無權限 9100 
            /// </summary>
            [Display(Name = "藥師藥局無權限")]
            [Description("9100")]
            _9100,

            /// <summary>
            /// 所置入非醫師卡 9101 
            /// </summary>
            [Display(Name = "所置入非醫師卡")]
            [Description("9101")]
            _9101,

            /// <summary>
            /// 此功能不支援 9102 
            /// </summary>
            [Display(Name = "此功能不支援")]
            [Description("9102")]
            _9102,

            /// <summary>
            /// 保留項目 9103 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9103")]
            _9103,

            /// <summary>
            /// 保留項目 9104 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9104")]
            _9104,

            /// <summary>
            /// 保留項目 9105 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9105")]
            _9105,

            /// <summary>
            /// 保留項目 9106 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9106")]
            _9106,

            /// <summary>
            /// 保留項目 9107 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9107")]
            _9107,

            /// <summary>
            /// 保留項目 9108 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9108")]
            _9108,

            /// <summary>
            /// 保留項目 9109 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9109")]
            _9109,

            /// <summary>
            /// 保留項目 9110 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9110")]
            _9110,

            /// <summary>
            /// 保留項目 9111 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9111")]
            _9111,

            /// <summary>
            /// 保留項目 9112 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9112")]
            _9112,

            /// <summary>
            /// 保留項目 9113 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9113")]
            _9113,

            /// <summary>
            /// 保留項目 9114 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9114")]
            _9114,

            /// <summary>
            /// 保留項目 9115 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9115")]
            _9115,

            /// <summary>
            /// 保留項目 9116 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9116")]
            _9116,

            /// <summary>
            /// 保留項目 9117 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9117")]
            _9117,

            /// <summary>
            /// 保留項目 9118 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9118")]
            _9118,

            /// <summary>
            /// 保留項目 9119 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9119")]
            _9119,

            /// <summary>
            /// 保留項目 9120 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9120")]
            _9120,

            /// <summary>
            /// 保留項目 9121 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9121")]
            _9121,

            /// <summary>
            /// 保留項目 9122 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9122")]
            _9122,

            /// <summary>
            /// 保留項目 9123 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9123")]
            _9123,

            /// <summary>
            /// 保留項目 9124 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9124")]
            _9124,

            /// <summary>
            /// 保留項目 9125 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9125")]
            _9125,

            /// <summary>
            /// 保留項目 9126 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9126")]
            _9126,

            /// <summary>
            /// 保留項目 9127 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9127")]
            _9127,

            /// <summary>
            /// 保留項目 9128 
            /// </summary>
            [Display(Name = "保留項目")]
            [Description("9128")]
            _9128,

            /// <summary>
            /// 持卡人於非限制院所就診 9129 
            /// </summary>
            [Display(Name = "持卡人於非限制院所就診")]
            [Description("9129")]
            _9129,

            /// <summary>
            /// 醫事卡失效 9130 
            /// </summary>
            [Display(Name = "醫事卡失效")]
            [Description("9130")]
            _9130,

            /// <summary>
            /// 醫事卡逾效期 9140 
            /// </summary>
            [Display(Name = "醫事卡逾效期")]
            [Description("9140")]
            _9140,

            /// <summary>
            /// 安全模組檔目錄錯誤或不存在或數量超過一個以上 9200 
            /// </summary>
            [Display(Name = "安全模組檔目錄錯誤或不存在或數量超過一個以上")]
            [Description("9200")]
            _9200,

            /// <summary>
            /// 初始安全模組檔讀取異常，請在C:\NHI\SAM\COMX1目錄下放置健保署正確安全模組檔。 9201 
            /// </summary>
            [Display(Name = "初始安全模組檔讀取異常，請在C:\\NHI\\SAM\\COMX1目錄下放置健保署正確安全模組檔。")]
            [Description("9201")]
            _9201,

            /// <summary>
            /// 安全模組檔讀取異常，已在其它電腦使用過，請在C:\NHI\SAM\COMX1目錄下放置健保署正確安全模組檔。 9202 
            /// </summary>
            [Display(Name = "安全模組檔讀取異常，已在其它電腦使用過，請在C:\\NHI\\SAM\\COMX1目錄下放置健保署正確安全模組檔。")]
            [Description("9202")]
            _9202,

            /// <summary>
            /// 卡片配對錯誤，正式卡與測試卡不能混用 9203 
            /// </summary>
            [Display(Name = "卡片配對錯誤，正式卡與測試卡不能混用")]
            [Description("9203")]
            _9203,

            /// <summary>
            /// 找不到讀卡機，或PCSC環境異常 9204 
            /// </summary>
            [Display(Name = "找不到讀卡機，或PCSC環境異常")]
            [Description("9204")]
            _9204,

            /// <summary>
            /// 開啟讀卡機連結埠失敗 9205 
            /// </summary>
            [Display(Name = "開啟讀卡機連結埠失敗")]
            [Description("9205")]
            _9205,

            /// <summary>
            /// 健保IC卡內部認證失敗 9210 
            /// </summary>
            [Display(Name = "健保IC卡內部認證失敗")]
            [Description("9210")]
            _9210,

            /// <summary>
            /// 雲端安全模組(IDC)對健保IC卡認證失敗 9211 
            /// </summary>
            [Display(Name = "雲端安全模組(IDC)對健保IC卡認證失敗")]
            [Description("9211")]
            _9211,

            /// <summary>
            /// 健保IC卡對雲端安全模組認證失敗 9212 
            /// </summary>
            [Display(Name = "健保IC卡對雲端安全模組認證失敗")]
            [Description("9212")]
            _9212,

            /// <summary>
            /// 雲端安全模組卡片更新逾時 9213 
            /// </summary>
            [Display(Name = "雲端安全模組卡片更新逾時")]
            [Description("9213")]
            _9213,

            /// <summary>
            /// 醫事人員卡內部認證失敗 9220 
            /// </summary>
            [Display(Name = "醫事人員卡內部認證失敗")]
            [Description("9220")]
            _9220,

            /// <summary>
            /// 雲端安全模組(IDC)驗證醫事人員卡失敗 9221 
            /// </summary>
            [Display(Name = "雲端安全模組(IDC)驗證醫事人員卡失敗")]
            [Description("9221")]
            _9221,

            /// <summary>
            /// 安全模組檔「醫療院所名稱」讀取失敗 9230 
            /// </summary>
            [Display(Name = "安全模組檔「醫療院所名稱」讀取失敗")]
            [Description("9230")]
            _9230,

            /// <summary>
            /// 安全模組檔「醫療院所簡稱」讀取失敗 9231 
            /// </summary>
            [Display(Name = "安全模組檔「醫療院所簡稱」讀取失敗")]
            [Description("9231")]
            _9231,

            /// <summary>
            /// 雲端安全模組主控台沒起動 9240 
            /// </summary>
            [Display(Name = "雲端安全模組主控台沒起動")]
            [Description("9240")]
            _9240,

            /// <summary>
            /// 健保卡讀取/寫入作業異常 4043 
            /// </summary>
            [Display(Name = "健保卡讀取/寫入作業異常")]
            [Description("4043")]
            _4043,

            /// <summary>
            /// 醫事人員卡密碼不能為空白 6019 
            /// </summary>
            [Display(Name = "醫事人員卡密碼不能為空白")]
            [Description("6019")]
            _6019,

            /// <summary>
            /// 醫事機構卡PIN碼卡尚未認證 9244 
            /// </summary>
            [Display(Name = "醫事機構卡PIN碼卡尚未認證")]
            [Description("9244")]
            _9244,

            /// <summary>
            /// 無效HCA憑證 9245 
            /// </summary>
            [Display(Name = "無效HCA憑證")]
            [Description("9245")]
            _9245,

            /// <summary>
            /// 虛擬醫師驗PIN失敗 9250 
            /// </summary>
            [Display(Name = "虛擬醫師驗PIN失敗")]
            [Description("9250")]
            _9250,

            /// <summary>
            /// 虛擬醫師卡逾時，請重新登入 9251 
            /// </summary>
            [Display(Name = "虛擬醫師卡逾時，請重新登入")]
            [Description("9251")]
            _9251,

            /// <summary>
            /// 虛擬醫師卡Session HPC ID為空值 9260 
            /// </summary>
            [Display(Name = "虛擬醫師卡Session HPC ID為空值")]
            [Description("9260")]
            _9260,

            /// <summary>
            /// 虛擬醫師卡HPC ID與Session中的HPC ID不一致 9261 
            /// </summary>
            [Display(Name = "虛擬醫師卡HPC ID與Session中的HPC ID不一致")]
            [Description("9261")]
            _9261,

            /// <summary>
            /// 虛擬醫師卡HPC 狀態資料不存在 9262 
            /// </summary>
            [Display(Name = "虛擬醫師卡HPC 狀態資料不存在")]
            [Description("9262")]
            _9262,

            /// <summary>
            /// 虛擬醫師卡HPC 狀態資料中的Session ID 不一致 9263 
            /// </summary>
            [Display(Name = "虛擬醫師卡HPC 狀態資料中的Session ID 不一致")]
            [Description("9263")]
            _9263,

            /// <summary>
            /// 虛擬醫師卡HPC 狀態資料中目前狀態不為2(SAM-HPC 已驗證) 9264 
            /// </summary>
            [Display(Name = "虛擬醫師卡HPC 狀態資料中目前狀態不為2(SAM-HPC 已驗證)")]
            [Description("9264")]
            _9264,

            /// <summary>
            /// 虛擬醫師卡HPC 狀態已逾期 9265 
            /// </summary>
            [Display(Name = "虛擬醫師卡HPC 狀態已逾期")]
            [Description("9265")]
            _9265,

            /// <summary>
            /// 虛擬醫師卡HPC 狀態資料中目前狀態不為3(PC PIN 已驗證) 9266 
            /// </summary>
            [Display(Name = "虛擬醫師卡HPC 狀態資料中目前狀態不為3(PC PIN 已驗證)")]
            [Description("9266")]
            _9266,

            /// <summary>
            /// 同一醫師卡在另外一台電腦登入 9267 
            /// </summary>
            [Display(Name = "同一醫師卡在另外一台電腦登入")]
            [Description("9267")]
            _9267,

            /// <summary>
            /// IDC驗證虛擬醫師卡失敗 9268 
            /// </summary>
            [Display(Name = "IDC驗證虛擬醫師卡失敗")]
            [Description("9268")]
            _9268,

            /// <summary>
            /// 設定csSetComConfig()連結埠失敗 9206 
            /// </summary>
            [Display(Name = "設定csSetComConfig()連結埠失敗")]
            [Description("9206")]
            _9206,

            /// <summary>
            /// 取得csGetComConfig()連結埠失敗 9207 
            /// </summary>
            [Display(Name = "取得csGetComConfig()連結埠失敗")]
            [Description("9207")]
            _9207,

            /// <summary>
            /// 即時查保-投保身分不一致 9093 
            /// </summary>
            [Display(Name = "即時查保-投保身分不一致(流程上要請院所替民眾做一次卡片更新，將卡片內的身份類別更新成與伺服端一致後即可)")]
            [Description("9093")]
            _9093,

            /// <summary>
            /// 即時查保-停保或退保 9094 
            /// </summary>
            [Display(Name = "即時查保-停保或退保")]
            [Description("9094")]
            _9094,

            /// <summary>
            /// 即時查保-欠費 9095 
            /// </summary>
            [Display(Name = "即時查保-欠費")]
            [Description("9095")]
            _9095,

            /// <summary>
            /// HCA讀卡機或憑證未安裝 9056 
            /// </summary>
            [Display(Name = "HCA讀卡機或憑證未安裝")]
            [Description("9056")]
            _9056,

            /// <summary>
            /// HCA密碼(PIN 碼)不正確 9039 
            /// </summary>
            [Display(Name = "HCA密碼(PIN 碼)不正確")]
            [Description("9039")]
            _9039,

            /// <summary>
            /// HCA PIN 碼已鎖住 9043 
            /// </summary>
            [Display(Name = "HCA PIN 碼已鎖住")]
            [Description("9043")]
            _9043,

            /// <summary>
            /// HCA密碼已過期 9042 
            /// </summary>
            [Display(Name = "HCA密碼已過期")]
            [Description("9042")]
            _9042,

            /// <summary>
            /// HCA憑證狀態為已被撤銷 9045 
            /// </summary>
            [Display(Name = "HCA憑證狀態為已被撤銷")]
            [Description("9045")]
            _9045,
            /// <summary>
            /// 自定義錯誤回傳碼 999999 資料庫旗標已關閉呼叫健保署Dll;
            /// 因健保署VPN斷線，目前已設定不讀取健保主控台5.0讀寫卡相關功能
            /// </summary>
            [Display(Name = "因健保署VPN斷線，目前已設定不讀取健保主控台5.0讀寫卡相關功能")]
            [Description("999999")]
            _999999,
        }
        #endregion


        #endregion

        #region CSHIS Unified

        /// <summary>
        /// 健保署主控台呼叫版本
        /// </summary>
        public enum NHI_CallType
        {
            /// <summary>
            /// 未設定
            /// </summary>
            [Display(Name = "未設定")]
            None,
            /// <summary>
            /// 讀卡控制5.0 主控台
            /// </summary>
            [Display(Name = "讀卡控制5.0 主控台")]
            [Description("5.0")]
            CSHIS50,
            /// <summary>
            /// 讀卡控制6.0 API
            /// </summary>
            [Display(Name = "讀卡控制6.0 API")]
            [Description("6.0")]
            CSHIS60
        }
        /// <summary>
        /// 雲端安全模組相關資訊  -
        /// Display.Name:院所名稱, Display.Description:SAMID, Display.ShortName:SAMID末五碼, Display.GroupName:院所HID, Display.Promp:自訂簡碼, 
        /// Description:安全模組檔案名稱(不含.SAM)
        /// </summary>
        public enum NHI_SAMFileName
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "", Description = "", ShortName = "", GroupName = "", Prompt = "")]
            [Description("")]
            None,
            /// <summary>
            /// 三總 正式安全模組 0501110514 001000005367
            /// </summary>
            [Display(Name = "三軍總醫院附設民眾診療服務處", Description = "001000005367", ShortName = "05367", GroupName = "0501110514", Prompt = "TRI")]
            [Description("0501110514001000005367")]
            TRI_001000005367,
            /// <summary>
            /// 三總 正式安全模組 0501110514 001000006443
            /// </summary>
            [Display(Name = "三軍總醫院附設民眾診療服務處", Description = "001000006443", ShortName = "06443", GroupName = "0501110514", Prompt = "TRI")]
            [Description("0501110514001000006443")]
            TRI_001000006443,
            /// <summary>
            /// 三總居護 正式安全模組 7501110511 001000033041
            /// </summary>
            [Display(Name = "三軍總醫院附設民眾診療服務處附設居家護理所", Description = "001000033041", ShortName = "33041", GroupName = "7501110511", Prompt = "TRI")]
            [Description("7501110511001000033041")]
            TRI_001000033041,
            /// <summary>
            /// 台北門診中心 正式安全模組 2501180018 001000011134
            /// </summary>
            [Display(Name = "國軍台北門診中心附設民眾診療服務處", Description = "001000011134", ShortName = "11134", GroupName = "2501180018", Prompt = "TPH")]
            [Description("2501180018001000011134")]
            TPH_001000011134,
            /// <summary>
            /// 健保署 測試安全模組 7777777777 901000000047
            /// </summary>
            [Display(Name = "測試安全模組", Description = "901000000047", ShortName = "00047", GroupName = "7777777777", Prompt = "TEST")]
            [Description("7777777777901000000047")]
            TEST_901000000047,
            /// <summary>
            /// 健保署 測試安全模組 8888888888 901000000048
            /// </summary>
            [Display(Name = "測試安全模組", Description = "901000000048", ShortName = "00048", GroupName = "8888888888", Prompt = "TEST")]
            [Description("8888888888901000000048")]
            TEST_901000000048,
            /// <summary>
            /// 健保署 測試安全模組 9999999999 901000000049
            /// </summary>
            [Display(Name = "測試安全模組", Description = "901000000049", ShortName = "00049", GroupName = "9999999999", Prompt = "TEST")]
            [Description("9999999999901000000046")]
            TEST_901000000049,
        }

        /// <summary>
        /// 讀卡控制軟體 6.0+ 5.0 呼叫方法 Enum 
        /// Display.Name=方法中文名稱, Display.Description=方法編號
        /// Description=回傳資料長度
        /// </summary>
        public enum NHIUnified_CSHISEnum
        {
            #region CSHIS 50 Display.Name=方法中文名稱, Display.Description=方法編號, Description=回傳資料長度

            /// <summary>
            /// 1.1 讀取不需個人 PIN 碼資料 長度:72
            /// </summary>
            [Display(Name = "讀取不需個人 PIN 碼資料", Description = "1.1")]
            [Description("72")]
            hisGetBasicData,

            /// <summary>
            /// 1.2 掛號或報到時讀取基本資料 長度:78
            /// </summary>
            [Display(Name = "掛號或報到時讀取基本資料", Description = "1.2")]
            [Description("78")]
            hisGetRegisterBasic,

            /// <summary>
            /// 1.3 預防保健掛號作業 長度:126
            /// </summary>
            [Display(Name = "預防保健掛號作業", Description = "1.3")]
            [Description("126")]
            hisGetRegisterPrevent,

            /// <summary>
            /// 1.4 孕婦產前檢查掛號作業 長度:209
            /// </summary>
            [Display(Name = "孕婦產前檢查掛號作業", Description = "1.4")]
            [Description("209")]
            hisGetRegisterPregnant,

            /// <summary>
            /// 1.5 讀取就醫資料不需 HPC 卡的部分 長度:498
            /// </summary>
            [Display(Name = "讀取就醫資料不需 HPC 卡的部分", Description = "1.5")]
            [Description("498")]
            hisGetTreatmentNoNeedHPC,

            /// <summary>
            /// 1.6 讀取就醫累計資料 長度:134
            /// </summary>
            [Display(Name = "讀取就醫累計資料", Description = "1.6")]
            [Description("134")]
            hisGetCumulativeData,

            /// <summary>
            /// 1.7 讀取醫療費用累計 長度:20
            /// </summary>
            [Display(Name = "讀取醫療費用累計", Description = "1.7")]
            [Description("20")]
            hisGetCumulativeFee,

            /// <summary>
            /// 1.8 讀取就醫資料需要 HPC 卡的部分 長度:540
            /// </summary>
            [Display(Name = "讀取就醫資料需要 HPC 卡的部分", Description = "1.8")]
            [Description("540")]
            hisGetTreatmentNeedHPC,

            /// <summary>
            /// 1.9 取得就醫序號 長度:167
            /// </summary>
            [Display(Name = "取得就醫序號", Description = "1.9")]
            [Description("167")]
            hisGetSeqNumber,

            /// <summary>
            /// 1.10 讀取處方箋作業 長度:3660
            /// </summary>
            [Display(Name = "讀取處方箋作業", Description = "1.10")]
            [Description("3660")]
            hisReadPrescription,

            /// <summary>
            /// 1.11 讀取預防接種資料 長度:1400
            /// </summary>
            [Display(Name = "讀取預防接種資料", Description = "1.11")]
            [Description("1400")]
            hisGetInoculateData,

            /// <summary>
            /// 1.12 讀取同意器官捐贈及安寧緩和醫療注記資料 長度:1
            /// </summary>
            [Display(Name = "讀取同意器官捐贈及安寧緩和醫療注記資料", Description = "1.12")]
            [Description("1")]
            hisGetOrganDonate,

            /// <summary>
            /// 1.13 讀取緊急聯絡電話資料 長度:14
            /// </summary>
            [Display(Name = "讀取緊急聯絡電話資料", Description = "1.13")]
            [Description("14")]
            hisGetEmergentTel,

            /// <summary>
            /// 1.14 讀取最新一次就醫序號 長度:7
            /// </summary>
            [Display(Name = "讀取最新一次就醫序號", Description = "1.14")]
            [Description("7")]
            hisGetLastSeqNum,

            /// <summary>
            /// 1.15 讀取卡片狀態 長度:4
            /// </summary>
            [Display(Name = "讀取卡片狀態", Description = "1.15")]
            [Description("4")]
            hisGetCardStatus,

            /// <summary>
            /// 1.16 就醫診療資料寫入作業 長度:54
            /// </summary>
            [Display(Name = "就醫診療資料寫入作業", Description = "1.16")]
            [Description("54")]
            hisWriteTreatmentCode,

            /// <summary>
            /// 1.17 就醫費用資料寫入作業 長度:38
            /// </summary>
            [Display(Name = "就醫費用資料寫入作業", Description = "1.17")]
            [Description("38")]
            hisWriteTreatmentFee,

            /// <summary>
            /// 1.18 處方簽寫入作業 長度:4
            /// </summary>
            [Display(Name = "處方簽寫入作業", Description = "1.18")]
            [Description("4")]
            hisWritePrescription,

            /// <summary>
            /// 1.19 新生兒註記寫入作業 長度:4
            /// </summary>
            [Display(Name = "新生兒註記寫入作業", Description = "1.19")]
            [Description("4")]
            hisWriteNewBorn,

            /// <summary>
            /// 1.20 過敏藥物寫入作業 長度:4
            /// </summary>
            [Display(Name = "過敏藥物寫入作業", Description = "1.20")]
            [Description("4")]
            hisWriteAllergicMedicines,

            /// <summary>
            /// 1.21 同意器官捐贈及安寧緩和醫療註記寫入作業 長度:4
            /// </summary>
            [Display(Name = "同意器官捐贈及安寧緩和醫療註記寫入作業", Description = "1.21")]
            [Description("4")]
            hisWriteOrganDonate,

            /// <summary>
            /// 1.22 預防保健資料寫入作業 長度:4
            /// </summary>
            [Display(Name = "預防保健資料寫入作業", Description = "1.22")]
            [Description("4")]
            hisWriteHealthInsurance,

            /// <summary>
            /// 1.23 緊急聯絡電話資料寫入作業 長度:4
            /// </summary>
            [Display(Name = "緊急聯絡電話資料寫入作業", Description = "1.23")]
            [Description("4")]
            hisWriteEmergentTel,

            /// <summary>
            /// 1.24 寫入產前檢查資料 長度:4
            /// </summary>
            [Display(Name = "寫入產前檢查資料", Description = "1.24")]
            [Description("4")]
            hisWritePredeliveryCheckup,

            /// <summary>
            /// 1.25 清除產前檢查資料 長度:4
            /// </summary>
            [Display(Name = "清除產前檢查資料", Description = "1.25")]
            [Description("4")]
            hisDeletePredeliveryData,

            /// <summary>
            /// 1.26 預防接種資料寫入作業 長度:4
            /// </summary>
            [Display(Name = "預防接種資料寫入作業", Description = "1.26")]
            [Description("4")]
            hisWriteInoculateData,

            /// <summary>
            /// 1.27 驗證健保 IC 卡之 PIN 值 長度:4
            /// </summary>
            [Display(Name = "驗證健保 IC 卡之 PIN 值", Description = "1.27")]
            [Description("4")]
            csVerifyHCPIN,

            /// <summary>
            /// 1.28 輸入新的健保 IC 卡之 PIN 值 長度:4
            /// </summary>
            [Display(Name = "輸入新的健保 IC 卡之 PIN 值", Description = "1.28")]
            [Description("4")]
            csInputHCPIN,

            /// <summary>
            /// 1.29 停用健保 IC 卡之 PIN 值輸入功能 長度:4
            /// </summary>
            [Display(Name = "停用健保 IC 卡之 PIN 值輸入功能", Description = "1.29")]
            [Description("4")]
            csDisableHCPIN,

            /// <summary>
            /// 1.30 健保 IC 卡片內容更新作業 長度:4
            /// </summary>
            [Display(Name = "健保 IC 卡片內容更新作業", Description = "1.30")]
            [Description("4")]
            csUpdateHCContents,

            /// <summary>
            /// 1.31 開啟讀卡機連結 長度:4
            /// </summary>
            [Display(Name = "開啟讀卡機連結", Description = "1.31")]
            [Description("4")]
            csOpenCom,

            /// <summary>
            /// 1.32 關閉讀卡機連結 長度:4
            /// </summary>
            [Display(Name = "關閉讀卡機連結", Description = "1.32")]
            [Description("4")]
            csCloseCom,

            /// <summary>
            /// 1.33 讀取重大傷病註記資料 長度:138
            /// </summary>
            [Display(Name = "讀取重大傷病註記資料", Description = "1.33")]
            [Description("138")]
            hisGetCriticalIllness,

            /// <summary>
            /// 1.34 讀取讀卡機日期時間 長度:13
            /// </summary>
            [Display(Name = "讀取讀卡機日期時間", Description = "1.34")]
            [Description("13")]
            csGetDateTime,

            /// <summary>
            /// 1.35 讀取卡片號碼 長度:12
            /// </summary>
            [Display(Name = "讀取卡片號碼", Description = "1.35")]
            [Description("12")]
            csGetCardNo,

            /// <summary>
            /// 1.36 健保 IC 卡是否設有密碼 長度:4
            /// </summary>
            [Display(Name = "健保 IC 卡是否設有密碼", Description = "1.36")]
            [Description("4")]
            csISSetPIN,

            /// <summary>
            /// 1.37 取得就醫序號版-就醫識別碼 長度:296
            /// </summary>
            [Display(Name = "取得就醫序號版-就醫識別碼", Description = "1.37")]
            [Description("296")]
            hisGetSeqNumber256,

            /// <summary>
            /// 1.38 掛號或報到時讀取基本資料 長度:9
            /// </summary>
            [Display(Name = "掛號或報到時讀取基本資料", Description = "1.38")]
            [Description("9")]
            hisGetRegisterBasic2,

            /// <summary>
            /// 1.39 回復就醫資料累計值---退掛 長度:4
            /// </summary>
            [Display(Name = "回復就醫資料累計值---退掛", Description = "1.39")]
            [Description("4")]
            csUnGetSeqNumber,

            /// <summary>
            /// 1.40 健保 IC 卡片內容更新作業 長度:4
            /// </summary>
            [Display(Name = "健保 IC 卡片內容更新作業", Description = "1.40")]
            [Description("4")]
            csUpdateHCNoReset,

            /// <summary>
            /// 1.41 讀取就醫資料-門診處方簽 長度:3660
            /// </summary>
            [Display(Name = "讀取就醫資料-門診處方簽", Description = "1.41")]
            [Description("3660")]
            hisReadPrescriptMain,

            /// <summary>
            /// 1.42 讀取就醫資料-長期處方簽 長度:1320
            /// </summary>
            [Display(Name = "讀取就醫資料-長期處方簽", Description = "1.42")]
            [Description("1320")]
            hisReadPrescriptLongTerm,

            /// <summary>
            /// 1.43 讀取就醫資料-重大醫療 長度:360
            /// </summary>
            [Display(Name = "讀取就醫資料-重大醫療", Description = "1.43")]
            [Description("360")]
            hisReadPrescriptHVE,

            /// <summary>
            /// 1.44 讀取就醫資料-過敏藥物 長度:120
            /// </summary>
            [Display(Name = "讀取就醫資料-過敏藥物", Description = "1.44")]
            [Description("120")]
            hisReadPrescriptAllergic,

            /// <summary>
            /// 1.45 多筆處方簽寫入作業 長度:4
            /// </summary>
            [Display(Name = "多筆處方簽寫入作業", Description = "1.45")]
            [Description("4")]
            hisWriteMultiPrescript,

            /// <summary>
            /// 1.46 過敏藥物寫入指定欄位作業 長度:4
            /// </summary>
            [Display(Name = "過敏藥物寫入指定欄位作業", Description = "1.46")]
            [Description("4")]
            hisWriteAllergicNum,

            /// <summary>
            /// 1.47 就醫診療資料及費用寫入作業 長度:4
            /// </summary>
            [Display(Name = "就醫診療資料及費用寫入作業", Description = "1.47")]
            [Description("4")]
            hisWriteTreatmentData,

            /// <summary>
            /// 1.48 處方簽寫入作業-回傳簽章 長度:40
            /// </summary>
            [Display(Name = "處方簽寫入作業-回傳簽章", Description = "1.48")]
            [Description("40")]
            hisWritePrescriptionSign,

            /// <summary>
            /// 1.49 多筆處方簽寫入作業-回傳簽章 長度:2400
            /// </summary>
            [Display(Name = "多筆處方簽寫入作業-回傳簽章", Description = "1.49")]
            [Description("2400")]
            hisWriteMultiPrescriptSign,

            /// <summary>
            /// 1.50 取得重大傷病註記資料身份比對 長度:138
            /// </summary>
            [Display(Name = "取得重大傷病註記資料身份比對", Description = "1.50")]
            [Description("138")]
            hisGetCriticalIllnessID,

            /// <summary>
            /// 1.51 取得控制軟體版本 長度:4
            /// </summary>
            [Display(Name = "取得控制軟體版本", Description = "1.51")]
            [Description("4")]
            csGetVersionEx,

            /// <summary>
            /// 1.52 提供 His 重置讀卡機或卡片的 API 長度:4
            /// </summary>
            [Display(Name = "提供 His 重置讀卡機或卡片的 API", Description = "1.52")]
            [Description("4")]
            csSoftwareReset,

            /// <summary>
            /// 1.53 取得就醫序號新版-就醫識別碼 長度:316
            /// </summary>
            [Display(Name = "取得就醫序號新版-就醫識別碼", Description = "1.53")]
            [Description("316")]
            hisGetSeqNumber256N1,

            /// <summary>
            /// 1.54 異常時取得就醫號碼 長度:43
            /// </summary>
            [Display(Name = "異常時取得就醫號碼", Description = "1.54")]
            [Description("43")]
            hisGetTreatNumNoICCard,

            /// <summary>
            /// 1.55 在保狀態查核 長度:4
            /// </summary>
            [Display(Name = "在保狀態查核", Description = "1.55")]
            [Description("4")]
            hisQuickInsurence,

            /// <summary>
            /// 1.56 單獨取得就醫識別碼 長度:20
            /// </summary>
            [Display(Name = "單獨取得就醫識別碼", Description = "1.56")]
            [Description("20")]
            hisGetTreatNumICCard,

            /// <summary>
            /// 2.1 SAM與DC認證 長度:4
            /// </summary>
            [Display(Name = "SAM與DC認證", Description = "2.1")]
            [Description("4")]
            csVerifySAMDC,

            /// <summary>
            /// 2.2 讀取SAM院所代碼 長度:10
            /// </summary>
            [Display(Name = "讀取SAM院所代碼", Description = "2.2")]
            [Description("10")]
            csGetHospID,

            /// <summary>
            /// 2.3 讀取SAM院所名稱 長度:24
            /// </summary>
            [Display(Name = "讀取SAM院所名稱", Description = "2.3")]
            [Description("24")]
            csGetHospName,

            /// <summary>
            /// 2.4 讀取SAM院所簡稱 長度:128
            /// </summary>
            [Display(Name = "讀取SAM院所簡稱", Description = "2.4")]
            [Description("128")]
            csGetHospAbbName,

            /// <summary>
            /// 3.1 資料上傳 長度:50
            /// </summary>
            [Display(Name = "資料上傳", Description = "3.1")]
            [Description("50")]
            csUploadData,

            /// <summary>
            /// 4.1 取得醫事人員卡狀態 長度:4
            /// </summary>
            [Display(Name = "取得醫事人員卡狀態", Description = "4.1")]
            [Description("4")]
            hpcGetHPCStatus,

            /// <summary>
            /// 4.2 檢查醫事人員卡之PIN值 長度:4
            /// </summary>
            [Display(Name = "檢查醫事人員卡之PIN值", Description = "4.2")]
            [Description("4")]
            hpcVerifyHPCPIN,

            /// <summary>
            /// 4.3 輸入新的醫事人員卡之PIN值 長度:4
            /// </summary>
            [Display(Name = "輸入新的醫事人員卡之PIN值", Description = "4.3")]
            [Description("4")]
            hpcInputHPCPIN,

            /// <summary>
            /// 4.4 解開鎖住的醫事人員卡 長度:4
            /// </summary>
            [Display(Name = "解開鎖住的醫事人員卡", Description = "4.4")]
            [Description("4")]
            hpcUnlockHPC,

            /// <summary>
            /// 4.5 取得醫事人員卡序號 長度:20
            /// </summary>
            [Display(Name = "取得醫事人員卡序號", Description = "4.5")]
            [Description("20")]
            hpcGetHPCSN,

            /// <summary>
            /// 4.6 取得醫事人員卡身分證字號 長度:10
            /// </summary>
            [Display(Name = "取得醫事人員卡身分證字號", Description = "4.6")]
            [Description("10")]
            hpcGetHPCSSN,

            /// <summary>
            /// 4.7 取得醫事人員卡中文姓名 長度:128
            /// </summary>
            [Display(Name = "取得醫事人員卡中文姓名", Description = "4.7")]
            [Description("128")]
            hpcGetHPCCNAME,

            /// <summary>
            /// 4.8 取得醫事人員卡英文姓名 長度:128
            /// </summary>
            [Display(Name = "取得醫事人員卡英文姓名", Description = "4.8")]
            [Description("128")]
            hpcGetHPCENAME,

            /// <summary>
            /// 4.9 虛擬醫師卡登出 長度:4
            /// </summary>
            [Display(Name = "虛擬醫師卡登出", Description = "4.9")]
            [Description("4")]
            hpcVHPCLogout,

            /// <summary>
            /// 5.1 進行疾病診斷碼押碼 長度:5
            /// </summary>
            [Display(Name = "進行疾病診斷碼押碼", Description = "5.1")]
            [Description("5")]
            hisGetICD10EnC,

            /// <summary>
            /// 5.2 進行疾病診斷碼解押碼 長度:10
            /// </summary>
            [Display(Name = "進行疾病診斷碼解押碼", Description = "5.2")]
            [Description("10")]
            hisGetICD10DeC,

            #endregion

            #region CSHIS 60 WebApi URL 呼叫方法網址, Display.Name=名稱, Display.ShortName = NHIVPNICCARD_SignKind(簽章服務類別).EnumName, Display.GroupName = NHIVPNICCARD_SignatureType(簽章種類).EnumName, Description=URL

            #region 主控台元件

            #region 公用相關 COMMON
            /// <summary>
            /// 取得目前控制軟體狀態
            /// </summary>
            [Display(Name = "取得目前控制軟體狀態", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Status")]
            GetCommonV1Status,
            /// <summary>
            /// 初始化控制軟體
            /// </summary>
            [Display(Name = "初始化控制軟體", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Initial")]
            PostCommonV1Initial,

            /// <summary>
            /// 結束作業，釋放所有資源
            /// </summary>
            [Display(Name = "結束作業，釋放所有資源", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Finalize")]
            PostCommonV1Finalize,

            /// <summary>
            /// 取得目前可用裝置名稱清單
            /// </summary>
            [Display(Name = "取得目前可用裝置名稱清單", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Name")]
            GetCommonV1Name,

            /// <summary>
            /// 取得 API 執行記錄
            /// </summary>
            [Display(Name = "取得 API 執行記錄", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Record")]
            GetCommonV1Record,

            /// <summary>
            /// 刪除 API 執行記錄
            /// </summary>
            [Display(Name = "刪除 API 執行記錄", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Record")]
            DeleteCommonV1Record,

            /// <summary>
            /// 取得讀卡機或伺服器日期時間
            /// </summary>
            [Display(Name = "取得讀卡機或伺服器日期時間", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/ServerDateTime")]
            GetCommonV1ServerDateTime,

            /// <summary>
            /// 取得目前控制軟體版本資訊
            /// </summary>
            [Display(Name = "取得目前控制軟體版本資訊", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/common/v1/Version")]
            GetCommonV1Version,

            #endregion

            #region 安全模組相關 SAM
            /// <summary>
            /// 讀取安全模組基本資料
            /// </summary>
            [Display(Name = "讀取安全模組基本資料", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/sam/v1/Basic")]
            GetSamV1Basic,

            /// <summary>
            /// 驗證安全模組
            /// </summary>
            [Display(Name = "驗證安全模組", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/sam/v1/Verification")]
            PostSamV1Verification,

            /// <summary>
            /// 登出所有驗證狀態
            /// </summary>
            [Display(Name = "登出所有驗證狀態", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/sam/v1/Logout")]
            DeleteSamV1Logout,

            /// <summary>
            /// 取得安全模組簽章
            /// </summary>
            [Display(Name = "取得安全模組簽章", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/sam/v1/Signature")]
            PostSamV1Signature,
            #endregion

            #region 醫事人員卡相關 HCA
            /// <summary>
            /// 讀取醫事人員基本資料
            /// </summary>
            [Display(Name = "讀取醫事人員基本資料", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Basic")]
            GetHpcV1Basic,

            /// <summary>
            /// 登出 HCA 卡片狀態
            /// </summary>
            [Display(Name = "登出 HCA 卡片狀態", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Logout")]
            DeleteHpcV1Logout,

            /// <summary>
            /// 重新設定 PIN 碼
            /// </summary>
            [Display(Name = "重新設定 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Pin")]
            PostHpcV1Pin,

            /// <summary>
            /// 使用 PUK 重新設定 PIN 碼
            /// </summary>
            [Display(Name = "使用 PUK 重新設定 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Pin")]
            PutHpcV1Pin,

            /// <summary>
            /// 取得醫事人員簽章
            /// </summary>
            [Display(Name = "取得醫事人員簽章", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Signature")]
            PostHpcV1Signature,

            /// <summary>
            /// 驗證醫事人員行動憑證
            /// </summary>
            [Display(Name = "驗證醫事人員行動憑證", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Verification/MobiliHca")]
            PostHpcV1VerificationMobiliHca,

            /// <summary>
            /// 驗證實體醫師或醫事人員卡 PIN 值
            /// </summary>
            [Display(Name = "驗證實體醫師或醫事人員卡 PIN 值", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hpc/v1/Verification/Hpc")]
            PostHpcV1VerificationHpc,

            #endregion

            #region 健保卡相關 HC
            /// <summary>
            /// 讀取保險對象基本資料
            /// </summary>
            [Display(Name = "讀取保險對象基本資料", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Basic")]
            GetHcV1Basic,

            /// <summary>
            /// 登出健保卡資料狀態
            /// </summary>
            [Display(Name = "登出健保卡資料狀態", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Logout")]
            DeleteHcV1Logout,

            /// <summary>
            /// 健保卡是否有設定 PIN 碼
            /// </summary>
            [Display(Name = "健保卡是否有設定 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Pin")]
            GetHcV1Pin,

            /// <summary>
            /// 驗證健保卡 PIN 碼
            /// </summary>
            [Display(Name = "驗證健保卡 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Pin")]
            PostHcV1Pin,

            /// <summary>
            /// 設定健保卡 PIN 碼
            /// </summary>
            [Display(Name = "設定健保卡 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Pin")]
            PutHcV1Pin,

            /// <summary>
            /// 移除健保卡 PIN 碼
            /// </summary>
            [Display(Name = "移除健保卡 PIN 碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Pin")]
            DeleteHcV1Pin,

            /// <summary>
            /// 取得健保卡簽章
            /// </summary>
            [Display(Name = "取得健保卡簽章", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Signature/Hc")]
            PostHcV1SignatureHc,

            /// <summary>
            /// 取得三卡驗證簽章 (SAM, HPC, HC)
            /// </summary>
            [Display(Name = "取得三卡驗證簽章 (SAM, HPC, HC)", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Signature/HpcHc")]
            PostHcV1SignatureHpcHc,

            #region 虛擬健保卡相關

            /// <summary>
            /// 驗證虛擬健保卡
            /// </summary>
            [Display(Name = "驗證虛擬健保卡", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/Verification/VirtualHc")]
            PostHcV1VerificationVirtualHc,

            /// <summary>
            /// 讀取虛擬健保卡基本資料(只讀取Token內基本資料，該Token仍然可供後續驗證使用)
            /// </summary>
            [Display(Name = "讀取虛擬健保卡基本資料(只讀取Token內基本資料，該Token仍然可供後續驗證使用)", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/VirtualHc/ReadBasic")]
            PostHcV1VirtualHcReadBasic,

            /// <summary>
            /// 匯出虛擬健保卡轉移碼
            /// </summary>
            [Display(Name = "匯出虛擬健保卡轉移碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/VirtualHc/Export")]
            PostHcV1VirtualHcExport,

            /// <summary>
            /// 匯入虛擬健保卡轉移碼
            /// </summary>
            [Display(Name = "匯入虛擬健保卡轉移碼", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/VirtualHc/Import")]
            PostHcV1VirtualHcImport,

            #endregion

            /// <summary>
            /// 實體健保卡更新註記
            /// </summary>
            [Display(Name = "實體健保卡更新註記", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/hc/v1/RealHc/Update")]
            PostHcV1RealHcUpdate,

            #endregion

            #region 設定相關 SETTINGS

            /// <summary>
            /// 取得本機 PCSC 讀卡機清單
            /// </summary>
            [Display(Name = "取得本機 PCSC 讀卡機清單", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/PcscReader/Readers")]
            GetSettingsV1PcscReaderReaders,

            /// <summary>
            /// 自動檢測 PCSC 讀卡機
            /// </summary>
            [Display(Name = "自動檢測 PCSC 讀卡機", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/PcscReader/AutoDetected")]
            PostSettingsV1PcscReaderAutoDetected,

            /// <summary>
            /// 取得目前預設使用 PCSC 讀卡機名稱
            /// </summary>
            [Display(Name = "取得目前預設使用 PCSC 讀卡機名稱", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/PcscReader/Default")]
            GetSettingsV1PcscReaderDefault,

            /// <summary>
            /// 設定目前預設使用 PCSC 讀卡機名稱
            /// </summary>
            [Display(Name = "設定目前預設使用 PCSC 讀卡機名稱", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/PcscReader/Default")]
            PostSettingsV1PcscReaderDefault,

            /// <summary>
            /// 清除預設使用 PCSC 讀卡機
            /// </summary>
            [Display(Name = "清除預設使用 PCSC 讀卡機", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/PcscReader/Default")]
            DeleteSettingsV1PcscReaderDefault,

            /// <summary>
            /// 取得雲端安全模組清單
            /// </summary>
            [Display(Name = "取得雲端安全模組清單", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/CloudSam")]
            GetSettingsV1CloudSam,

            /// <summary>
            /// 新增雲端安全模組
            /// </summary>
            [Display(Name = "新增雲端安全模組", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/CloudSam")]
            PostSettingsV1CloudSam,

            /// <summary>
            /// 從安全模組清單移除雲端安全模組
            /// </summary>
            [Display(Name = "從安全模組清單移除雲端安全模組", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/CloudSam")]
            DeleteSettingsV1CloudSam,

            /// <summary>
            /// 取得允許呼叫主機名稱
            /// </summary>
            [Display(Name = "取得允許呼叫主機名稱", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/Cors")]
            GetSettingsV1Cors,

            /// <summary>
            /// 新增允許呼叫主機名稱
            /// </summary>
            [Display(Name = "新增允許呼叫主機名稱", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/Cors")]
            PostSettingsV1Cors,

            /// <summary>
            /// 移除允許呼叫主機名稱清單
            /// </summary>
            [Display(Name = "移除允許呼叫主機名稱清單", ShortName = nameof(NHIVPNICCARD_SignKind._Null), GroupName = nameof(NHIVPNICCARD_SignatureType.NULL))]
            [Description("/api/settings/v1/Cors")]
            DeleteSettingsV1Cors,
            #endregion

            #endregion

            #region 業務端

            #region 過敏藥物相關 (AllergicMedicines)
            /// <summary>
            /// 寫入過敏藥物資料
            /// </summary>
            [Display(Name = "寫入過敏藥物資料", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/AllergicMedicines/Write")]
            PostV1AllergicMedicinesWrite,

            /// <summary>
            /// 寫入過敏藥物資料並指定寫入欄位 (WriteByIndex)
            /// </summary>
            [Display(Name = "寫入過敏藥物資料並指定寫入欄位 (WriteByIndex)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/AllergicMedicines/WriteByIndex")]
            PostV1AllergicMedicinesWriteByIndex,

            /// <summary>
            /// 讀取過敏藥物資料 (Query)
            /// </summary>
            [Display(Name = "讀取過敏藥物資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/AllergicMedicines/Query")]
            PostV1AllergicMedicinesQuery,
            #endregion

            #region 基本資料相關 (BasicData)
            /// <summary>
            /// 讀取不需要個人 PIN 碼之基本資料 (Query)
            /// </summary>
            [Display(Name = "讀取不需要個人 PIN 碼之基本資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/BasicData/Query")]
            PostV1BasicDataQuery,

            /// <summary>
            /// 掛號或報到時讀取基本資料 (Register)
            /// </summary>
            [Display(Name = "掛號或報到時讀取基本資料 (Register)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/BasicData/Register")]
            PostV1BasicDataRegister,

            /// <summary>
            /// 掛號或報到時讀取基本資料 (Register2)
            /// </summary>
            [Display(Name = "掛號或報到時讀取基本資料 (Register2)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/BasicData/Register2")]
            PostV1BasicDataRegister2,

            #endregion

            #region 重大傷病相關 (CriticalIllness)
            /// <summary>
            /// 讀取重大傷病資料 (Query)
            /// </summary>
            [Display(Name = "讀取重大傷病資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/CriticalIllness/Query")]
            PostV1CriticalIllnessQuery,

            /// <summary>
            /// 讀取重大傷病資料 – 不需醫事人員卡 (OnlyHcQuery)
            /// </summary>
            [Display(Name = "讀取重大傷病資料 – 不需醫事人員卡 (OnlyHcQuery)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/CriticalIllness/OnlyHcQuery")]
            PostV1CriticalIllnessOnlyHcQuery,

            #endregion

            #region 就醫年度累計資料 (CumulativeData)
            /// <summary>
            /// 讀取就醫累計資料 (Query)
            /// </summary>
            [Display(Name = "讀取就醫累計資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/CumulativeData/Query")]
            PostV1CumulativeDataQuery,

            #endregion

            #region 醫療費用總累計相關 (CumulativeFee)
            /// <summary>
            /// 讀取就醫總累計資料 (Query)
            /// </summary>
            [Display(Name = "讀取就醫總累計資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/CumulativeFee/Query")]
            PostV1CumulativeFeeQuery,

            #endregion

            #region 緊急聯絡電話相關 (EmergentTel)
            /// <summary>
            /// 寫入「EmergencyTel」 (Write)
            /// </summary>
            [Display(Name = "寫入「EmergencyTel」 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/EmergentTel/Write")]
            PostV1EmergentTelWrite,

            /// <summary>
            /// 讀取「EmergencyTel」 (Query)
            /// </summary>
            [Display(Name = "讀取「EmergencyTel」 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/EmergentTel/Query")]
            PostV1EmergentTelQuery,

            #endregion

            #region 健保卡卡片內容相關
            /// <summary>
            /// 更新健保卡內容(Update)
            /// </summary>
            [Display(Name = "更新健保卡內容(Update)", ShortName = nameof(NHIVPNICCARD_SignKind._04UploadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/HcContent/Update")]
            PostV1HcContentUpdate,

            #endregion

            #region 疾病診斷碼相關(Icd)
            /// <summary>
            /// 進行疾病診斷碼押碼 (Encode)
            /// </summary>
            [Display(Name = "進行疾病診斷碼押碼 (Encode)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/Icd/Encode")]
            PostV1IcdEncode,

            /// <summary>
            /// 進行疾病診斷碼解押碼 (Decode)
            /// </summary>
            [Display(Name = "進行疾病診斷碼解押碼 (Decode)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/Icd/Decode")]
            PostV1IcdDecode,

            #endregion

            #region 預防接種相關 (Inoculate)
            /// <summary>
            /// 讀取預防接種資料 (Query)
            /// </summary>
            [Display(Name = "讀取預防接種資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Inoculate/Query")]
            PostV1InoculateQuery,

            /// <summary>
            /// 寫入預防接種資料 (Write)
            /// </summary>
            [Display(Name = "寫入預防接種資料 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Inoculate/Write")]
            PostV1InoculateWrite,

            #endregion

            #region 保險相關 (Insurance)
            /// <summary>
            /// 在保狀態查核(Quick)
            /// </summary>
            [Display(Name = "在保狀態查核(Quick)", ShortName = nameof(NHIVPNICCARD_SignKind._03GetTreatNum), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Insurance/Quick")]
            PostV1InsuranceQuick,

            #endregion

            #region 新生兒相關 (NewBorn)
            /// <summary>
            /// 新生兒註記寫入健保卡時使用 (Write)
            /// </summary>
            [Display(Name = "新生兒註記寫入健保卡時使用 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/NewBorn/Write")]
            PostV1NewBornWrite,

            #endregion

            #region 器捐安寧註記相關 (OrganDonate)
            /// <summary>
            /// 讀取器捐安寧註記 (OrganDonate)
            /// </summary>
            [Display(Name = "讀取器捐安寧註記 (OrganDonate)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/OrganDonate/Query")]
            PostV1OrganDonateQuery,

            #endregion

            #region 產婦產前檢查相關 (PregnantData)
            /// <summary>
            /// 取得產前檢查資料 (Query)
            /// </summary>
            [Display(Name = "取得產前檢查資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/PregnantData/Query")]
            PostV1PregnantDataQuery,

            /// <summary>
            /// 寫入產前檢查資料 (Write)
            /// </summary>
            [Display(Name = "寫入產前檢查資料 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/PregnantData/Write")]
            PostV1PregnantDataWrite,

            /// <summary>
            /// 刪除全部產前檢查資料 (Delete)
            /// </summary>
            [Display(Name = "刪除全部產前檢查資料 (Delete)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/PregnantData/Delete")]
            PostV1PregnantDataDelete,
            #endregion

            #region 醫令相關 (Prescription)
            /// <summary>
            /// 寫入處方箋資料 (Write)
            /// </summary>
            [Display(Name = "寫入處方箋資料 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Prescription/Write")]
            PostV1PrescriptionWrite,

            /// <summary>
            /// 讀取健保卡的醫令及過敏藥物資料 (Query)
            /// </summary>
            [Display(Name = "讀取健保卡的醫令及過敏藥物資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/Prescription/Query")]
            PostV1PrescriptionQuery,

            /// <summary>
            /// 讀取就醫資料-門診處方箋 (MainQuery)
            /// </summary>
            [Display(Name = "讀取就醫資料-門診處方箋 (MainQuery)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/Prescription/MainQuery")]
            PostV1PrescriptionMainQuery,

            /// <summary>
            /// 讀取就醫資料-長期處方箋 (LongQuery)
            /// </summary>
            [Display(Name = "讀取就醫資料-長期處方箋 (LongQuery)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/Prescription/LongQuery")]
            PostV1PrescriptionLongQuery,

            /// <summary>
            /// 讀取就醫資料-重要醫令 (HveQuery)
            /// </summary>
            [Display(Name = "讀取就醫資料-重要醫令 (HveQuery)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/Prescription/HveQuery")]
            PostV1PrescriptionHveQuery,
            #endregion

            #region 預防保健相關 (PreventData)
            /// <summary>
            /// 取得預防保健資料 (Query)
            /// </summary>
            [Display(Name = "取得預防保健資料 (Query)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/PreventData/Query")]
            PostV1PreventDataQuery,

            /// <summary>
            /// 寫入預防保健資料 (Write)
            /// </summary>
            [Display(Name = "寫入預防保健資料 (Write)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/PreventData/Write")]
            PostV1PreventDataWrite,

            #endregion

            #region 就醫序號相關 (SequelNumber)
            /// <summary>
            /// 讀出「SequelNumberLast」(Last)
            /// </summary>
            [Display(Name = "讀出「SequelNumberLast」(Last)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/SequelNumber/Last")]
            PostV1SequelNumberLast,

            /// <summary>
            /// 取得就醫序號 (Next)
            /// </summary>
            [Display(Name = "取得就醫序號 (Next)", ShortName = nameof(NHIVPNICCARD_SignKind._03GetTreatNum), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/SequelNumber/Next")]
            PostV1SequelNumberNext,

            /// <summary>
            /// 回復就醫資料累計值 (Rollback)
            /// </summary>
            [Display(Name = "回復就醫資料累計值 (Rollback)", ShortName = nameof(NHIVPNICCARD_SignKind._03GetTreatNum), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/SequelNumber/Rollback")]
            PostV1SequelNumberRollback,

            #endregion

            #region 視訊醫療相關 (TeleMedicine)
            /// <summary>
            /// 請求視訊醫療虛擬健保卡 (RequestToken)
            /// </summary>
            [Display(Name = "請求視訊醫療虛擬健保卡 (RequestToken)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/TeleMedicine/RequestToken")]
            PostV1TeleMedicineRequestToken,

            /// <summary>
            /// 取得視訊醫療虛擬健保卡資料授權結果 (ResponseToken)
            /// </summary>
            [Display(Name = "取得視訊醫療虛擬健保卡資料授權結果 (ResponseToken)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/TeleMedicine/ResponseToken")]
            PostV1TeleMedicineResponseToken,

            #endregion

            #region 就醫相關 (Treatment)
            /// <summary>
            /// 讀取就診資料 – 不需醫事人員卡 (NoNeedHPC)
            /// </summary>
            [Display(Name = "讀取就診資料 – 不需醫事人員卡 (NoNeedHPC)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Treatment/NoNeedHPC")]
            PostV1TreatmentNoNeedHPC,

            /// <summary>
            /// 讀取診間就醫資料 (NeedHPC)
            /// </summary>
            [Display(Name = "讀取診間就醫資料 (NeedHPC)", ShortName = nameof(NHIVPNICCARD_SignKind._01ReadICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HCP_HC))]
            [Description("/api/v1/Treatment/NeedHPC")]
            PostV1TreatmentNeedHPC,

            /// <summary>
            /// 寫入就醫診療資料 (WriteCode)
            /// </summary>
            [Display(Name = "寫入就醫診療資料 (WriteCode)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Treatment/WriteCode")]
            PostV1TreatmentWriteCode,

            /// <summary>
            /// 寫入就醫費用資料 (WriteFee)
            /// </summary>
            [Display(Name = "寫入就醫費用資料 (WriteFee)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Treatment/WriteFee")]
            PostV1TreatmentWriteFee,

            /// <summary>
            /// 寫入就醫診療費用資料 (WriteCodeFee)
            /// </summary>
            [Display(Name = "寫入就醫診療費用資料 (WriteCodeFee)", ShortName = nameof(NHIVPNICCARD_SignKind._02WriteICCard), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/Treatment/WriteCodeFee")]
            PostV1TreatmentWriteCodeFee,
            #endregion

            #region 就醫識別碼相關 (TreatmentNumber)
            /// <summary>
            /// 異常時取得就醫識別碼 (NoCard)
            /// </summary>
            [Display(Name = "異常時取得就醫識別碼 (NoCard)", ShortName = nameof(NHIVPNICCARD_SignKind._03GetTreatNum), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/TreatmentNumber/NoCard")]
            PostV1TreatmentNumberNoCard,

            /// <summary>
            /// 單獨取得就醫識別碼 (Card)
            /// </summary>
            [Display(Name = "單獨取得就醫識別碼 (Card)", ShortName = nameof(NHIVPNICCARD_SignKind._03GetTreatNum), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM_HC))]
            [Description("/api/v1/TreatmentNumber/Card")]
            PostV1TreatmentNumberCard,

            #endregion

            #region 就醫資料上傳相關 (UploadData)
            /// <summary>
            /// 就醫資料上傳 (Upload)
            /// </summary>
            [Display(Name = "就醫資料上傳 (Upload)", ShortName = nameof(NHIVPNICCARD_SignKind._05UploadTeatmentData), GroupName = nameof(NHIVPNICCARD_SignatureType.SAM))]
            [Description("/api/v1/UploadData/Upload")]
            PostV1UploadDataUpload,

            #endregion

            #endregion

            #endregion
        }

        #endregion

        #region TeleMedicine QRCodeStatus 虛擬健保卡QRCODE狀態
        /// <summary>
        /// 虛擬健保卡QrCode目前狀態
        /// 使用Description轉換
        /// </summary>
        public enum TeleMedicineVhcRecordQRCodeStatus
        {
            /// <summary>
            /// 初始值 0
            /// </summary>
            [Display(Name = "初始值")]
            [Description("0")]
            Null = 0,
            /// <summary>
            /// 1 發送身分證號並取得AccessToken並存回資料庫中[此步驟應在報到機上]
            /// </summary>
            [Display(Name = "發送身分證號取得AccessToken")]
            [Description("1")]
            SendRequest_1 = 1,
            /// <summary>
            /// 2 醫師於等待清單中按右鍵報到時觸發Reponse，
            /// </summary>
            [Display(Name = "發送AccessToken並等待Reponse")]
            [Description("2")]
            WaitResponse_2 = 2,
            /// <summary>
            /// 3 QRCode 可使用[取得虛擬健保卡QRCODE並開始計時四小時同時把資料存回資料庫中, 病患此時於保留清單[DR:待診] 醫師此準備開始看診]
            /// </summary>
            [Display(Name = "虛擬健保卡待使用")]
            [Description("3")]
            QrCodeUnUsed_3 = 3,
            /// <summary>
            /// 4 QRCode 使用中[醫師於儀錶板進入診間時取得QRCODE準備匯入醫師電腦中並押上狀態]
            /// </summary>
            [Display(Name = "虛擬健保卡使用中")]
            [Description("4")]
            QrCodeUsed_4 = 4,
            /// <summary>
            /// 5 QrCode 匯出後可使用[醫師進行保留,結案,退出時，皆先匯出虛擬健保卡轉移碼,並押上狀態]
            /// </summary>
            [Display(Name = "虛擬健保卡匯出後可使用")]
            [Description("5")]
            QrCodeExported_5 = 5,
            /// <summary>
            /// 6 QrCode 不可用[可能在某台電腦中使用，但未被匯出就將其登出，或是被覆蓋掉，或是逾期失效]
            /// </summary>
            [Display(Name = "虛擬健保卡逾期不可用")]
            [Description("6")]
            QrCodeExpired_6 = 6,
            /// <summary>
            /// 7 QrCode 不可用[可能在某台電腦中使用，於保留,結案,退出時匯出失敗]
            /// </summary>
            [Display(Name = "虛擬健保卡匯出失敗不可用")]
            [Description("7")]
            QrCodeExportFailure_7 = 7,
        }


        #endregion

        #endregion

        #region CSHIS50Claim ErrorCode
        /// <summary>
        /// 申報作業異常碼, Display.Name=說明, Display.Description=錯誤代碼
        /// </summary>
        public enum CsHis50Claim_ErrorCode
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值", Description = "")]
            _Null,
            /// <summary>
            /// 申請檔案作業種類(sTypeCode)錯誤 500
            /// </summary>
            [Display(Name = "申請檔案作業種類(sTypeCode)錯誤", Description = "500")]
            _500 = 500,

            /// <summary>
            /// 網路環境載入異常 5000
            /// </summary>
            [Display(Name = "網路環境載入異常", Description = "5000")]
            _5000 = 5000,

            /// <summary>
            /// Windows 取得檔案大小異常或權限不足 5001
            /// </summary>
            [Display(Name = "Windows 取得檔案大小異常或權限不足", Description = "5001")]
            _5001 = 5001,

            /// <summary>
            /// 找不到 Reader.dll 5002
            /// </summary>
            [Display(Name = "找不到 Reader.dll", Description = "5002")]
            _5002 = 5002,

            /// <summary>
            /// 檔名錯誤 5003
            /// </summary>
            [Display(Name = "檔名錯誤", Description = "5003")]
            _5003 = 5003,

            /// <summary>
            /// 系統忙碌中，請稍後再試 5004
            /// </summary>
            [Display(Name = "系統忙碌中，請稍後再試", Description = "5004")]
            _5004 = 5004,

            /// <summary>
            /// 產生簽章錯誤 5005
            /// </summary>
            [Display(Name = "產生簽章錯誤", Description = "5005")]
            _5005 = 5005,

            /// <summary>
            /// 記憶體不足 5006
            /// </summary>
            [Display(Name = "記憶體不足", Description = "5006")]
            _5006 = 5006,

            /// <summary>
            /// 下載路徑不存在 5007
            /// </summary>
            [Display(Name = "下載路徑不存在", Description = "5007")]
            _5007 = 5007,

            /// <summary>
            /// 取得醫療院所代碼錯誤 5008
            /// </summary>
            [Display(Name = "取得醫療院所代碼錯誤", Description = "5008")]
            _5008 = 5008,

            /// <summary>
            /// 檔名有誤 5009
            /// </summary>
            [Display(Name = "檔名有誤", Description = "5009")]
            _5009 = 5009,

            /// <summary>
            /// 認證錯誤 5010
            /// </summary>
            [Display(Name = "認證錯誤", Description = "5010")]
            _5010 = 5010,

            /// <summary>
            /// 連線總數量已超過，請稍後再試。 5020
            /// </summary>
            [Display(Name = "連線總數量已超過，請稍後再試。", Description = "5020")]
            _5020 = 5020,

            /// <summary>
            /// 網路作業錯誤，訊息不完整 5021
            /// </summary>
            [Display(Name = "網路作業錯誤，訊息不完整", Description = "5021")]
            _5021 = 5021,

            /// <summary>
            /// 等待醫療系統處理中 5022
            /// </summary>
            [Display(Name = "等待醫療系統處理中", Description = "5022")]
            _5022 = 5022,

            /// <summary>
            /// 等待 EIIAPI 處理中或交易不存在 5023
            /// </summary>
            [Display(Name = "等待 EIIAPI 處理中或交易不存在", Description = "5023")]
            _5023 = 5023,

            /// <summary>
            /// 無法建立檔案 5024
            /// </summary>
            [Display(Name = "無法建立檔案", Description = "5024")]
            _5024 = 5024,

            /// <summary>
            /// 寫入磁碟異常 5025
            /// </summary>
            [Display(Name = "寫入磁碟異常", Description = "5025")]
            _5025 = 5025,

            /// <summary>
            /// 解密錯誤 5026
            /// </summary>
            [Display(Name = "解密錯誤", Description = "5026")]
            _5026 = 5026,

            /// <summary>
            /// 網路作業錯誤但已完成 5027
            /// </summary>
            [Display(Name = "網路作業錯誤但已完成", Description = "5027")]
            _5027 = 5027,

            /// <summary>
            /// 連線錯誤 5028
            /// </summary>
            [Display(Name = "連線錯誤", Description = "5028")]
            _5028 = 5028,

            /// <summary>
            /// 上傳下載請求檔未成功連線至伺服器 8203
            /// </summary>
            [Display(Name = "上傳下載請求檔未成功連線至伺服器", Description = "8203")]
            _8203 = 8203,

            /// <summary>
            /// 回饋資料下載未成功連線至伺服器 8218
            /// </summary>
            [Display(Name = "回饋資料下載未成功連線至伺服器", Description = "8218")]
            _8218 = 8218,

            /// <summary>
            /// 送至 IDC Message Header 檢核不符 9001
            /// </summary>
            [Display(Name = "送至 IDC Message Header 檢核不符", Description = "9001")]
            _9001 = 9001,

            /// <summary>
            /// 送至 IDC 語法不符 9002
            /// </summary>
            [Display(Name = "送至 IDC 語法不符", Description = "9002")]
            _9002 = 9002,

            /// <summary>
            /// 與 IDC 作業逾時 9003
            /// </summary>
            [Display(Name = "與 IDC 作業逾時", Description = "9003")]
            _9003 = 9003,

            /// <summary>
            /// IDC 異常無法 Service 9004
            /// </summary>
            [Display(Name = "IDC 異常無法 Service", Description = "9004")]
            _9004 = 9004,

            /// <summary>
            /// IDC 無法驗證該卡片 9010
            /// </summary>
            [Display(Name = "IDC 無法驗證該卡片", Description = "9010")]
            _9010 = 9010,

            /// <summary>
            /// IDC 無該卡片資料 9012
            /// </summary>
            [Display(Name = "IDC 無該卡片資料", Description = "9012")]
            _9012 = 9012,

            /// <summary>
            /// 無效的安全模組檔 9013
            /// </summary>
            [Display(Name = "無效的安全模組檔", Description = "9013")]
            _9013 = 9013,

            /// <summary>
            /// IDC 對安全模組檔認證失敗 9014
            /// </summary>
            [Display(Name = "IDC 對安全模組檔認證失敗", Description = "9014")]
            _9014 = 9014,

            /// <summary>
            /// 安全模組檔對 IDC 認證失敗 9015
            /// </summary>
            [Display(Name = "安全模組檔對 IDC 認證失敗", Description = "9015")]
            _9015 = 9015,

            /// <summary>
            /// IDC 驗章錯誤 9020
            /// </summary>
            [Display(Name = "IDC 驗章錯誤", Description = "9020")]
            _9020 = 9020,

            /// <summary>
            /// 無法執行安全模組卡更新認證 9050
            /// </summary>
            [Display(Name = "無法執行安全模組卡更新認證", Description = "9050")]
            _9050 = 9050,

            /// <summary>
            /// 安全模組卡更新認證失敗 9051
            /// </summary>
            [Display(Name = "安全模組卡更新認證失敗", Description = "9051")]
            _9051 = 9051,

            /// <summary>
            /// 安全模組檔遭停約處罰 9060
            /// </summary>
            [Display(Name = "安全模組檔遭停約處罰", Description = "9060")]
            _9060 = 9060,

            /// <summary>
            /// 安全模組檔不在有效期限內 9061
            /// </summary>
            [Display(Name = "安全模組檔不在有效期限內", Description = "9061")]
            _9061 = 9061,

            /// <summary>
            /// 安全模組檔合約逾期或尚未生效 9062
            /// </summary>
            [Display(Name = "安全模組檔合約逾期或尚未生效", Description = "9062")]
            _9062 = 9062,

            /// <summary>
            /// 其他異常 9999
            /// </summary>
            [Display(Name = "其他異常", Description = "9999")]
            _9999 = 9999,
        }

        #endregion

        #region NHIICCard 2.0 健保卡資料上傳2.0
        /// <summary>
        /// 健保卡資料上傳2.0 資料格式 H01
        /// Description=數值
        /// </summary>
        public enum NHIICCard20_DataFormate
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值", Description = "")]
            [Description("")]
            None,
            /// <summary>
            /// 正常上傳 A
            /// </summary>
            [Display(Name = "正常上傳", Description = "")]
            [Description("A")]
            _A,
            /// <summary>
            /// 異常上傳 B
            /// </summary>
            [Display(Name = "異常上傳", Description = "")]
            [Description("B")]
            _B,
            /// <summary>
            /// 註銷未調劑慢連箋處方 C
            /// </summary>
            [Display(Name = "註銷未調劑慢連箋處方", Description = "")]
            [Description("C")]
            _C,
            /// <summary>
            /// 整筆刪除 D
            /// </summary>
            [Display(Name = "整筆刪除", Description = "")]
            [Description("D")]
            _D,
            /// <summary>
            /// 取消「C-註銷未調劑慢連箋處方」 E
            /// </summary>
            [Display(Name = "取消「C-註銷未調劑慢連箋處方」。", Description = "")]
            [Description("E")]
            _E,

        }

        #endregion

        #region 異常就醫序號清單
        /// <summary>
        /// 異常就醫序號代碼
        /// Display.Name=異常原因,Display.Description=是否取得就醫序號, Description=健保署檢核管理說明
        /// </summary>
        public enum AbnormalCardNum
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值", Description = "")]
            [Description("")]
            NULL,
            /// <summary>
            /// 讀卡設備故障 尚未取得就醫序號 A000
            /// </summary>
            [Display(Name = "讀卡設備故障", Description = "尚未取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            A000,
            /// <summary>
            /// 讀卡設備故障 已取得就醫序號 A001
            /// </summary>
            [Display(Name = "讀卡設備故障", Description = "已取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            A001,
            /// <summary>
            /// 讀卡機故障 尚未取得就醫序號 A010
            /// </summary>
            [Display(Name = "讀卡機故障", Description = "尚未取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            A010,
            /// <summary>
            /// 讀卡機故障 已取得就醫序號 A011
            /// </summary>
            [Display(Name = "讀卡機故障", Description = "已取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            A011,
            /// <summary>
            /// 網路故障造成讀卡機無法使用 尚未取得就醫序號 A020
            /// </summary>
            [Display(Name = "網路故障造成讀卡機無法使用", Description = "尚未取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            A020,
            /// <summary>
            /// 網路故障造成讀卡機無法使用 已取得就醫序號 A021
            /// </summary>
            [Display(Name = "網路故障造成讀卡機無法使用", Description = "已取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            A021,
            /// <summary>
            /// 安全模組故障造成讀卡機無法使用 尚未取得就醫序號 A030
            /// </summary>
            [Display(Name = "安全模組故障造成讀卡機無法使用", Description = "尚未取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            A030,
            /// <summary>
            /// 安全模組故障造成讀卡機無法使用 已取得就醫序號 A031
            /// </summary>
            [Display(Name = "安全模組故障造成讀卡機無法使用", Description = "已取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            A031,
            /// <summary>
            /// 卡片不良 (表面正常,晶片異常) 尚未取得就醫序號 B000
            /// </summary>
            [Display(Name = "卡片不良 (表面正常,晶片異常)", Description = "尚未取得就醫序號")]
            [Description("定期與本署發卡系統及民眾抽查比對")]
            B000,
            /// <summary>
            /// 卡片不良 (表面正常,晶片異常) 已取得就醫序號 B001
            /// </summary>
            [Display(Name = "卡片不良 (表面正常,晶片異常)", Description = "已取得就醫序號")]
            [Description("定期與本署發卡系統及民眾抽查比對")]
            B001,
            /// <summary>
            /// 例外就醫者 尚未取得就醫序號 C001
            /// </summary>
            [Display(Name = "例外就醫者", Description = "尚未取得就醫序號")]
            [Description("定期與本署發卡系統比對")]
            C001,
            /// <summary>
            /// 停電 尚未取得就醫序號 C000
            /// </summary>
            [Display(Name = "停電", Description = "尚未取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            C000,
            /// <summary>
            /// 醫療資訊系統(HIS)當機/電腦死當(無法開機) 尚未取得就醫序號 D000
            /// </summary>
            [Display(Name = "醫療資訊系統(HIS)當機/電腦死當(無法開機)", Description = "尚未取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            D000,
            /// <summary>
            /// 醫療資訊系統(HIS)當機/電腦死當(無法開機) 已取得就醫序號 D001
            /// </summary>
            [Display(Name = "醫療資訊系統(HIS)當機/電腦死當(無法開機)", Description = "已取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            D001,
            /// <summary>
            /// 醫療院所電腦故障 尚未取得就醫序號 D010
            /// </summary>
            [Display(Name = "醫療院所電腦故障", Description = "尚未取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            D010,
            /// <summary>
            /// 醫療院所電腦故障 已取得就醫序號 D011
            /// </summary>
            [Display(Name = "醫療院所電腦故障", Description = "已取得就醫序號")]
            [Description("發生健保卡作業異常致無法24 小時內上傳就依資料，需填寫「健保卡作業異常狀況報備單」向本署分區業務組報備")]
            D011,
            /// <summary>
            /// 健保署資訊系統當機 E000
            /// </summary>
            [Display(Name = "健保署資訊系統當機", Description = "尚未取得就醫序號")]
            [Description("限本署確認公布系統當機時間始用")]
            E000,
            /// <summary>
            /// 控卡名單已簽切結書 E001
            /// </summary>
            [Display(Name = "控卡名單已簽切結書", Description = "尚未取得就醫序號")]
            [Description("限異常原因使用")]
            E001,
            /// <summary>
            /// 醫事機構赴偏遠地區因無電話撥接上網設備之居家醫療照護 F000
            /// </summary>
            [Display(Name = "醫事機構赴偏遠地區因無電話撥接上網設備之居家醫療照護", Description = "尚未取得就醫序號")]
            [Description("限異常原因使用")]
            F000,
            /// <summary>
            /// 居家輕量藍牙方案之離線認卡(無法過卡取得就醫序號) F00B
            /// </summary>
            [Display(Name = "居家輕量藍牙方案之離線認卡(無法過卡取得就醫序號)", Description = "尚未取得就醫序號")]
            [Description("限申請居家APP 雲端安全模組通過之院所提供居家照護使用")]
            F00B,
            /// <summary>
            /// 1. 因應COVID-19 慢性病人無法返臺親自就醫代為陳述病情或代領藥之異常就醫序號(使用至112.12.31 止) 
            /// 2. 無法取得健保卡密碼  尚未取得就醫序號 Z000
            /// </summary>
            [Display(Name = "因應COVID-19 慢性病人無法返臺親自就醫代為陳述病情或代領藥之異常就醫序號(使用至112.12.31 止)", Description = "尚未取得就醫序號")]
            [Description("1.比對非設定密碼民眾，需為1 情境;2.為避免誤用，刪除「其他」情境")]
            Z000,
            /// <summary>
            /// 1. 因應COVID-19 慢性病人無法返臺親自就醫代為陳述病情或代領藥之異常就醫序號(使用至112.12.31 止) 
            /// 2. 無法取得健保卡密碼 已取得就醫序號 Z001
            /// </summary>
            [Display(Name = "因應COVID-19 慢性病人無法返臺親自就醫代為陳述病情或代領藥之異常就醫序號(使用至112.12.31 止)", Description = "已取得就醫序號")]
            [Description("1.比對非設定密碼民眾，需為1 情境;2.為避免誤用，刪除「其他」情境")]
            Z001,
            /// <summary>
            /// 新特約60 日內(如VPN 已經開通，可正常過卡後，不可再使用) 尚未取得就醫序號 G000
            /// </summary>
            [Display(Name = "新特約60 日內(如VPN 已經開通，可正常過卡後，不可再使用)", Description = "尚未取得就醫序號")]
            [Description("VPN 已開通可正常過卡不可再使用")]
            G000,
            /// <summary>
            /// 未加保之移植捐贈者 尚未取得就醫序號 IC98
            /// </summary>
            [Display(Name = "未加保之移植捐贈者", Description = "尚未取得就醫序號")]
            [Description("限無健保身分")]
            IC98,
            /// <summary>
            /// 無健保身分愛滋病患就醫、無健保身分之法定傳染病就醫 尚未取得就醫序號 IC09
            /// </summary>
            [Display(Name = "無健保身分愛滋病患就醫、無健保身分之法定傳染病就醫", Description = "尚未取得就醫序號")]
            [Description("限無健保身分")]
            IC09,
            /// <summary>
            /// 限COVID-19 上傳快篩及PCR 結果無法過卡之健保身分民眾(1100521) 尚未取得就醫序號 CV19
            /// </summary>
            [Display(Name = "限COVID-19 上傳快篩及PCR 結果無法過卡之健保身分民眾(1100521)", Description = "尚未取得就醫序號")]
            [Description("限異常原因使用")]
            CV19,
            /// <summary>
            /// 限COVID-19 上傳快篩及PCR 結果無法過卡之無健保身分民眾(1100610) 尚未取得就醫序號 FORE
            /// </summary>
            [Display(Name = "限COVID-19 上傳快篩及PCR 結果無法過卡之無健保身分民眾(1100610)", Description = "尚未取得就醫序號")]
            [Description("限異常原因使用")]
            FORE,
            /// <summary>
            /// 遠距醫療試辦計畫之遠距院所(1091229) 尚未取得就醫序號 TM01
            /// </summary>
            [Display(Name = "遠距醫療試辦計畫之遠距院所(1091229)", Description = "尚未取得就醫序號")]
            [Description("限異常原因使用")]
            TM01,
            /// <summary>
            /// 住院中執行床號變更/轉床及非手術、CT、MRI、PET 時，因辦理住院手續查驗其健保卡後歸還保險對象，無法取得健保卡。
            /// 尚未取得就醫序號 J000
            /// </summary>
            [Display(Name = "住院中執行床號變更/轉床及非手術、CT、MRI、PET 時，因辦理住院手續查驗其健保卡後歸還保險對象，無法取得健保卡。", Description = "尚未取得就醫序號")]
            [Description("1.本項異常就醫序號係考量COVID-19 疫情期間增加多項住院期間應上傳之重要醫令，配套使用。\r\n2.健保手術、CT、MRI、PET 及HLA-B 1502 基因檢測(診療項目代碼_A73：62001C~88054B 、33070B、33071B、33072B、33084B、33085B、33090B、26072B、26073B、12196B)仍須依法規登錄健保卡及上傳。")]
            J000,
            /// <summary>
            /// COVID-19 疫情期間通訊診療無法取得健保卡 尚未取得就醫序號 HVIT
            /// </summary>
            [Display(Name = "COVID-19 疫情期間通訊診療無法取得健保卡", Description = "尚未取得就醫序號")]
            [Description("限異常原因使用")]
            HVIT,
            /// <summary>
            /// 全民健康保險代謝症候群防治計畫之個案收案、追蹤及年度評估 尚未取得就醫序號 HVIT
            /// </summary>
            [Display(Name = "全民健康保險代謝症候群防治計畫之個案收案、追蹤及年度評估", Description = "尚未取得就醫序號")]
            [Description("限異常原因使用")]
            MSPT,
            /// <summary>
            /// 未具健保身分生產案件 尚未取得就醫序號 HVIT
            /// </summary>
            [Display(Name = "未具健保身分生產案件", Description = "尚未取得就醫序號")]
            [Description("限異常原因使用")]
            ICDN,
            /// <summary>
            /// 癌症治療品質計畫之追蹤及診斷品質管理費 尚未取得就醫序號 HVIT
            /// </summary>
            [Display(Name = "癌症治療品質計畫之追蹤及診斷品質管理費", Description = "尚未取得就醫序號")]
            [Description("限異常原因使用")]
            ICC4,
        }


        #endregion

        #region IdentityCheck.MainKind
        /// <summary>
        /// IdentityCheck.Mainkind 意思
        /// </summary>
        public enum IdentityCheck_MainKind
        {
            /// <summary>
            /// 初始值
            /// </summary>
            Null,
            /// <summary>
            /// 原始B
            /// </summary>
            B,
            /// <summary>
            /// B 顯示
            /// </summary>
            B_S,
            /// <summary>
            /// B 不顯示
            /// </summary>
            B_NS,
            /// <summary>
            /// 原始C
            /// </summary>
            C,
            /// <summary>
            /// C 顯示
            /// </summary>
            C_S,
            /// <summary>
            /// C 不顯示
            /// </summary>
            C_NS,
        }

        #endregion

        #region GROUPKIND

        /// <summary>
        /// 群組類別
        /// Display.Name:名稱，Display.Description:中文大寫數字,Description:數字
        /// </summary>
        public enum GROUPKIND
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值", Description = "")]
            [Description("")]
            Null,

            /// <summary>
            /// 醫師
            /// 對應SYSUSER.USERID
            /// </summary>
            [Display(Name = "醫師", Description = "一")]
            [Description("1")]
            _1,

            /// <summary>
            /// 科室
            /// 對應SYSUSER.DEPTNO
            /// </summary>
            [Display(Name = "科室", Description = "二")]
            [Description("2")]
            _2,

            /// <summary>
            /// 病院
            /// 20250722備註目前已經不使用
            /// </summary>
            [Display(Name = "病院", Description = "三")]
            [Description("3")]
            _3,

            /// <summary>
            /// 全院
            /// 僅開放高權限可以維護
            /// </summary>
            [Display(Name = "全院", Description = "四")]
            [Description("4")]
            _4,

            /// <summary>
            /// 院內科別
            /// 對應SYSUSER.SECTIONNO
            /// </summary>
            [Display(Name = "院內科別", Description = "五")]
            [Description("5")]
            _5,
        }

        #endregion

        #region VITALSIGN 生命徵象 類別 VITALKIND
        /// <summary>
        /// VITALSIGN.VITALKIND 生命徵象類別 
        /// Display.Name=中文名稱
        /// </summary>
        public enum VITALKIND

        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            None,
            /// <summary>
            /// 腹圍
            /// </summary>
            [Display(Name = "腹圍")]
            ag,
            /// <summary>
            /// 血糖
            /// </summary>
            [Display(Name = "血糖")]
            bloodsugar,
            /// <summary>
            /// 失血量
            /// </summary>
            [Display(Name = "失血量")]
            blost,
            /// <summary>
            /// 輸血
            /// </summary>
            [Display(Name = "輸血")]
            bt,
            /// <summary>
            /// 中心靜脈壓
            /// </summary>
            [Display(Name = "中心靜脈壓")]
            cvp,
            /// <summary>
            /// 舒張壓
            /// </summary>
            [Display(Name = "舒張壓")]
            dia,
            /// <summary>
            /// 引流量
            /// </summary>
            [Display(Name = "引流量")]
            drain,
            /// <summary>
            /// 飲食量
            /// </summary>
            [Display(Name = "飲食量")]
            food,
            /// <summary>
            /// GCS_E
            /// </summary>
            [Display(Name = "GCS_E")]
            GCS_E,
            /// <summary>
            /// GCS_M
            /// </summary>
            [Display(Name = "GCS_M")]
            GCS_M,
            /// <summary>
            /// GCS_V
            /// </summary>
            [Display(Name = "GCS_V")]
            GCS_V,
            /// <summary>
            /// 頭圍
            /// </summary>
            [Display(Name = "頭圍")]
            hc,
            /// <summary>
            /// 身高
            /// </summary>
            [Display(Name = "身高")]
            height,
            /// <summary>
            /// 沖洗輸入量
            /// </summary>
            [Display(Name = "沖洗輸入量")]
            intake_irrig,
            /// <summary>
            /// 注射量
            /// </summary>
            [Display(Name = "注射量")]
            ivf,
            /// <summary>
            /// 平均壓(*1)
            /// </summary>
            [Display(Name = "平均壓(*1)")]
            map,
            /// <summary>
            /// 沖洗輸入量
            /// </summary>
            [Display(Name = "沖洗輸入量")]
            output_irrig,
            /// <summary>
            /// 疼痛
            /// </summary>
            [Display(Name = "疼痛")]
            pain,
            /// <summary>
            /// 心跳
            /// </summary>
            [Display(Name = "心跳")]
            pulse,
            /// <summary>
            /// 呼吸次數
            /// </summary>
            [Display(Name = "呼吸次數")]
            rr,
            /// <summary>
            /// 大便
            /// </summary>
            [Display(Name = "大便")]
            s,
            /// <summary>
            /// 血氧飽合濃度
            /// </summary>
            [Display(Name = "血氧飽合濃度")]
            spo2,
            /// <summary>
            /// 大便量
            /// </summary>
            [Display(Name = "大便量")]
            stool,
            /// <summary>
            /// 收縮壓
            /// </summary>
            [Display(Name = "收縮壓")]
            sys,
            /// <summary>
            /// 體溫
            /// </summary>
            [Display(Name = "體溫")]
            temp,
            /// <summary>
            /// 全靜脈營養
            /// </summary>
            [Display(Name = "全靜脈營養")]
            tpn,
            /// <summary>
            /// 小便量
            /// </summary>
            [Display(Name = "小便量")]
            urine,
            /// <summary>
            /// 體重
            /// </summary>
            [Display(Name = "體重")]
            weight
        }
        #endregion

        #region ICD碼類別
        /// <summary>
        /// ICD碼版本類別
        /// Display.Name=ICD碼名稱
        /// </summary>
        public enum IcdVersion
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name="未知")]
            Unknown,
            /// <summary>
            /// ICD9
            /// </summary>
            [Display(Name = "ICD9", Description = "")]
            Icd9,
            /// <summary>
            /// ICD10
            /// </summary>
            [Display(Name = "ICD10", Description = "")] 
            Icd10,
        }

        #endregion

        #region 最底層相關，請勿輕易異動

        /// <summary>
        /// 環境類別
        /// 請取用description
        /// </summary>
        public enum EnvironmentType
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("6n19gojE6CZR+TBfaQ6n+M6tG5SiYmoPMQIZBt1SkpPKShn2oxSyn25PRSXtyxp/gm2t8JApYvSVEQUsg+Gqs2C9tLTKtQj7/awdV61hlXl2lLtpOQ6kcZ5wwrPzi8fJ/wGtw3+zgMI=")]
            Default = 0,

            /// <summary>
            /// 正式區
            /// </summary>
            [Display(Name = "正式區")]
            [Description("a6SuGHjglN4rcvXvzS1QYp8r6P6n6V1DFOHEk2qvtdZ587tu7+/0OPuQ10hs1QY7eeJzjhzgEiLTBTF4NOdfL22EWJDAJDO8PPo+Ckn6NmkLucJDt+hlXiKFDqrd1rWtxHoFnQ1oQ5Y=")]
            Online = 1,

            /// <summary>
            /// 平測區
            /// </summary>
            [Display(Name = "平測區")]
            [Description("VdYYC5nPO5wdmWHTbe9hH0YM3UeRDGpPNP38radvemeZ5WRDBFKCUDSt+eERAVjivzfSqQAmpU4WWO/+qFBH6tRuD5bcUHJ8n4m7FffpZwQD0ryQoAmzWNEIT1shJe6CHJv5SLnyFPo=")]
            Formal = 2,

            /// <summary>
            /// 開發區
            /// </summary>
            [Display(Name = "開發區")]
            [Description("6n19gojE6CZR+TBfaQ6n+M6tG5SiYmoPMQIZBt1SkpPKShn2oxSyn25PRSXtyxp/gm2t8JApYvSVEQUsg+Gqs2C9tLTKtQj7/awdV61hlXl2lLtpOQ6kcZ5wwrPzi8fJ/wGtw3+zgMI=")]
            HIS2USER2 = 3,

            /// <summary>
            /// 本機
            /// </summary>
            [Display(Name = "離線區")]
            //1522
            //[Description("hNUPKomY5Mn8DJArfaiw5OG1Kft0HuTGvbyY7Uup4s1PWEnziATvX/LUbKRMCGWL8xTTJkt3bqYA7vr3LzLFt2hXTdcU1gidmO3xXLDJqVymL3JTbkqOkGpFyiwpNtv5jdrJWAmkfNw=")]
            //1521
            [Description("FS+5zl/kkbSmXOyzodJ8Hyzb7g0wOyFQ1dR6xczepRWxAmuKPETOxMtOpf8x9PyB4gtVpXVgu0hwqgrKtA/HlmTGrCJKn32dbMyFsrpBFUG7wnDcOlVzeoWCrk0WlS3PE773g9gUWG0=")]
            Offline = 4,

            /// <summary>
            /// 北門正式區
            /// </summary>
            [Display(Name = "北門正式區")]
            [Description("eZmZDHj1rfpAx11+44I241jCV4teYfKEPK+uX5vqMID1mZPV/Hh/+ou6hSv5RhUd34BLjyqCwE5Tmjj386arfVu+4i4ZUUx4XsDLw4JhpUen7BuHEYeekPHoSPyzKvn7OuihEt47Im4=")]
            TPH_Online = 5,

            /// <summary>
            /// 備份區
            /// </summary>
            [Display(Name = "備份區")]
            [Description("7hDtmpfvHMz/h7Njz4DCrJUZxMslM07NK3R73IL1bBQONe+K7cUyjNWve9l8xcw+CzRcQyMyLzQ6csUYqEA8L20G8ZarxqcidRN6pmBl3sowCBVaIvaz2KR4qUbXBIrHT/xdGIA6gU8=")]
            Backup = 6,
        }

        /// <summary>
        /// Web 相關 domain
        /// 請取用Description:[Ex:https://google.com/]
        /// Display.Description:[Ex:google.com]
        /// </summary>
        public enum EnvironmentUrlType
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值", Description = "his2web.tsgh.ndmctsgh.edu.tw")]
            [Description("http://his2web.tsgh.ndmctsgh.edu.tw/")]
            Web_Default = 0,

            /// <summary>
            /// Web 正式區
            /// </summary>
            [Display(Name = "Web 正式區", Description = "his2apf5.ndmctsgh.edu.tw")]
            [Description("https://his2apf5.ndmctsgh.edu.tw/")]
            Web_Online = 1,

            /// <summary>
            /// Web 平測區
            /// </summary>
            [Display(Name = "Web 平測區", Description = "this2f5.ndmctsgh.edu.tw")]
            [Description("https://this2f5.ndmctsgh.edu.tw/")]
            Web_Formal = 2,

            /// <summary>
            /// Web 開發區
            /// </summary>
            [Display(Name = "Web 開發區", Description = "his2web.tsgh.ndmctsgh.edu.tw")]
            [Description("http://his2web.tsgh.ndmctsgh.edu.tw/")]
            Web_Developed = 3,

            /// <summary>
            /// Web 正式區（門診）
            /// </summary>
            [Display(Name = "Web 正式區（門診）", Description = "his2webf5.ndmctsgh.edu.tw")]
            [Description("http://his2webf5.ndmctsgh.edu.tw/")]
            Web_Online_LoadBalance = 4,

            /// <summary>
            /// API 正式區（門診）
            /// </summary>
            [Display(Name = "API 正式區（門診）", Description = "his2apif5.ndmctsgh.edu.tw")]
            [Description("http://his2apif5.ndmctsgh.edu.tw/")]
            API_Online_LoadBalance = 5,

            /// <summary>
            /// Web 平測區（門診）
            /// </summary>
            [Display(Name = "Web 平測區（門診）", Description = "DEVHIS2WEBF5.ndmctsgh.edu.tw")]
            [Description("https://DEVHIS2WEBF5.ndmctsgh.edu.tw/")]
            Web_Formal_LoadBalance = 6,

            /// <summary>
            /// API 平測區（門診）
            /// </summary>
            [Display(Name = "API 平測區（門診）", Description = "DEVHIS2OPDAPI.ndmctsgh.edu.tw")]
            [Description("https://DEVHIS2OPDAPI.ndmctsgh.edu.tw/")]
            API_Formal_LoadBalance = 7,

            #region 北門
            /// <summary>
            /// 北門 WEB 測試主機
            /// </summary>
            [Display(Name = "北門 WEB 測試主機", Description = "OUTPATIENTWEB1.ndmctsgh.edu.tw")]
            [Description("https://OUTPATIENTWEB1.ndmctsgh.edu.tw/")]
            TPH_WEB_Formal_LoadBalance = 8,
            /// <summary>
            /// 北門 API 測試主機
            /// </summary>
            [Display(Name = "北門 API 測試主機", Description = "OUTPATIENTAPI1.ndmctsgh.edu.tw")]
            [Description("https://OUTPATIENTAPI1.ndmctsgh.edu.tw/")]
            TPH_API_Formal_LoadBalance = 9,
            #endregion
       
            /// <summary>
            /// API 正式區（住院）
            /// </summary>
            [Display(Name = "API 正式區（住院）", Description = "his2ipdapi.ndmctsgh.edu.tw")]
            [Description("https://his2ipdapi.ndmctsgh.edu.tw/")]
            IPD_API_Online_LoadBalance = 10,

            /// <summary>
            /// API 平測區（住院）
            /// </summary>
            [Display(Name = "API 平測區（住院）", Description = "his2admapif5.ndmctsgh.edu.tw")]
            [Description("https://his2admapif5.ndmctsgh.edu.tw/")]
            IPD_API_Formal_LoadBalance = 11,
        }
        #endregion 最底層相關，請勿輕易異動
    }
}
