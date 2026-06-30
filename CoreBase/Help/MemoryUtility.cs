using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Windows.Forms;

namespace CoreBase.Help
{
    public class MemoryUtility
    {
        /// <summary>
        ///  設定Memory LOH物件 回收時進行壓實  黑暗執行續: https://blog.darkthread.net/blog/managed-heap-study/
        /// </summary>
        public static void SetGCCollectLOHObjectAutoCompaction()
        {
            //設定 GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce，
            //下次 GC.Collect() 時將重新整理搬移 LOH 物件清出連續空間。

            //黑暗執行續  https://blog.darkthread.net/blog/oom-with-adequate-memory/
            try
            {
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect();
            }
            catch
            {

            }
        }

        public static ServiceResult<Dictionary<string, string>> CheckLocalVersion(InfoUtility info, string localFolderPath = null, List<string> checkLocalVersionProgramNameList = null)
        {
            var returnResult =
                new ServiceResult<Dictionary<string, string>>(false, string.Empty, new Dictionary<string, string>());
            try
            {
                var readFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (localFolderPath == null)
                {
                    switch (info.EnvironmentType)
                    {
                        case EnumUtility.EnvironmentType.Online:
                            readFolderPath = "C:\\TSGH\\";
                            break;
                        case EnumUtility.EnvironmentType.Formal:
                        case EnumUtility.EnvironmentType.HIS2USER2:
                            readFolderPath = Path.Combine("C:\\TSGH\\", "test");
                            break;
                    }
#if DEBUG
                    readFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#endif
                }
                else
                {
                    if (Directory.Exists(localFolderPath))
                    {
                        readFolderPath = localFolderPath;
                    }
                    else
                    {
                        if (Directory.Exists(readFolderPath))
                        {
                            readFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        }
                        else
                        {
                            returnResult.Message += $"資料夾路徑:「{readFolderPath}」\n此資料夾不存在!";
                            return returnResult;
                        }
                    }
                }

                if (Directory.Exists(readFolderPath) == false)
                {
                    returnResult.Message += $"資料夾路徑:「{readFolderPath}」\n此資料夾不存在!";
                    return returnResult;
                }

                var fileDic = new Dictionary<string, string>();
                var fileList = new List<string>();

                var DllList = Directory.GetFileSystemEntries(readFolderPath, "*.dll", SearchOption.TopDirectoryOnly);
                fileList.AddRange(DllList);
                var programList =
                    Directory.GetFileSystemEntries(readFolderPath, "*.exe", SearchOption.TopDirectoryOnly);

                fileList.AddRange(programList);
                //排除舊版本 HIS2_FormReports.EXE, 因為同GUID 故會被檢核到
                if (fileList != null && fileList.Any(x =>
                        x?.ToUpper() == Path.Combine(readFolderPath, "HIS2_FORMREPORTS.EXE").ToUpper()))
                {
                    fileList.Remove(fileList.FirstOrDefault(x =>
                        x?.ToUpper() == Path.Combine(readFolderPath, "HIS2_FORMREPORTS.EXE").ToUpper()));
                }

                AssemblyFileManager assemblyInfo_ = null;
                var SerialNumber = 0;
                foreach (var filePath in fileList)
                {
                    if (Directory.Exists(filePath))
                    {
                        //如果是目錄
                    }
                    else
                    {
                        var fileName = Path.GetFileNameWithoutExtension(filePath)?.ToUpper();
                        if (checkLocalVersionProgramNameList != null &&
                            checkLocalVersionProgramNameList.Any(x => x?.ToUpper() == fileName))
                        {
                            assemblyInfo_ = AssemblyFileManager.GetAssemblyInfo(filePath);
                            if (!string.IsNullOrWhiteSpace((assemblyInfo_ != null ? assemblyInfo_.GUID : string.Empty)))
                            {
                                fileDic[assemblyInfo_ != null ? assemblyInfo_.Name : string.Empty] =
                                    assemblyInfo_ != null ? assemblyInfo_.Version : string.Empty;
                            }

                            SerialNumber++;
                        }
                    }
                }

                returnResult.Data = fileDic;
                returnResult.IsOk = true;
            }
            catch (Exception ex)
            {
                returnResult.Exception = ex;
                returnResult.IsOk = false;
                returnResult.Message += "[THROW]:" + ex.Message + Environment.NewLine;
            }

            return returnResult;
        }

        /// <summary>
        /// 檢核本地端版本與線上版本號之差異
        /// </summary>
        /// <param name="dbhelper"></param>
        /// <param name="LocalFolderPath">本地端檔案資料夾路徑[預設看連線區域]</param>
        /// <param name="CheckOnlineVersionProgramNameList">欲檢核之程式名稱[SYSTEM_PARAM.PARAMID]</param>
        /// <returns></returns>
        public static ServiceResult<Dictionary<string, string>> CheckOnlineVersion(DB.DBhelp dbhelper = null, string LocalFolderPath = null, List<string> CheckOnlineVersionProgramNameList = null)
        {
            ServiceResult<Dictionary<string, string>> ReturnResult = new ServiceResult<Dictionary<string, string>>(false, string.Empty, new Dictionary<string, string>());
            try
            {
                DB.DBhelp _dbhelper;
                if (dbhelper == null)
                {
                    _dbhelper = new DB.DBhelp();
                }
                else
                {
                    _dbhelper = dbhelper;
                }
                if(CheckOnlineVersionProgramNameList == null)
                {
                    CheckOnlineVersionProgramNameList = new List<string>();
                }
                var onlineVersinoList = _dbhelper.QueryAsync<SYSTEM_PARAM>(new Dictionary<string, object>
                {
                    {nameof(SYSTEM_PARAM.PARAMGROUP), EnumUtility.SystemParam.AssemblyVersion.ToString() },
                    {nameof(SYSTEM_PARAM.CANCELFLAG), EnumUtility.CancelFlag.N.ToString() },
                }).Result;

                var ONLINE_FILE_LIST = from online in onlineVersinoList
                                       select new VersionCheckList().CovertModel(online);

                var TempList = new List<VersionCheckList>();
                foreach(var item in ONLINE_FILE_LIST)
                {
                    item.ONLINE_VERSION = item.PARAMVARCHAR;
                    item.GUID = item.ENGDESCRIPT;
                    TempList.Add(item);
                }
                ONLINE_FILE_LIST = TempList;

                var ReadFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (LocalFolderPath == null)
                {
                    switch(_dbhelper._info.EnvironmentType)
                    {
                        case EnumUtility.EnvironmentType.Online:
                            ReadFolderPath = "C:\\TSGH\\";
                            break;
                        case EnumUtility.EnvironmentType.Formal:
                        case EnumUtility.EnvironmentType.HIS2USER2:
                            ReadFolderPath = Path.Combine("C:\\TSGH\\","test");
                            break;
                    }
#if DEBUG
                    ReadFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#endif
                }
                else
                {
                    if (Directory.Exists(LocalFolderPath))
                    {
                        ReadFolderPath = LocalFolderPath;
                    }
                    else
                    {
                        if (Directory.Exists(ReadFolderPath))
                        {
                            ReadFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        }
                        else
                        {
                            ReturnResult.Message += $"資料夾路徑:「{ReadFolderPath}」\n此資料夾不存在!";
                            return ReturnResult;
                        }
                    }
                }
                if (Directory.Exists(ReadFolderPath) == false)
                {
                    ReturnResult.Message += $"資料夾路徑:「{ReadFolderPath}」\n此資料夾不存在!";
                    return ReturnResult;
                }
                var LOCAL_FILE_LIST = new List<VersionCheckList>();
                List<string> FileList = new List<string>();

                string[] DllList = Directory.GetFileSystemEntries(ReadFolderPath, "*.dll", SearchOption.TopDirectoryOnly);
                FileList.AddRange(DllList);
                string[] ProgramList = Directory.GetFileSystemEntries(ReadFolderPath, "*.exe", SearchOption.TopDirectoryOnly);
                
                FileList.AddRange(ProgramList);
                //排除舊版本 HIS2_FormReports.EXE, 因為同GUID 故會被檢核到
                if (FileList != null && FileList.Any(x => x?.ToUpper() == Path.Combine(ReadFolderPath, "HIS2_FORMREPORTS.EXE").ToUpper()))
                {
                    FileList.Remove(FileList.FirstOrDefault(x => x?.ToUpper() == Path.Combine(ReadFolderPath, "HIS2_FORMREPORTS.EXE").ToUpper()));
                }
                AssemblyFileManager assemblyInfo_ = null;
                var SerialNumber = 0;
                foreach (var filePath in FileList)
                {
                    if (Directory.Exists(filePath))
                    {
                        //如果是目錄
                    }
                    else
                    {
                        var fileName = Path.GetFileNameWithoutExtension(filePath)?.ToUpper();
                        if (ONLINE_FILE_LIST != null && ONLINE_FILE_LIST.Any(x => x.PARAMID?.ToUpper() == fileName))
                        {
                            //存在於Online對照清單中
                            assemblyInfo_ = AssemblyFileManager.GetAssemblyInfo(filePath);
                            //FileVersionInfo FILE_VersionInfo = FileVersionInfo.GetVersionInfo(filePath);
                            if (!string.IsNullOrWhiteSpace((assemblyInfo_ != null ? assemblyInfo_.GUID : string.Empty)))
                            {
                                if (assemblyInfo_.Name?.ToUpper() == "HIS2_OPD_CASHIER")
                                {
                                    LOCAL_FILE_LIST.Add(new VersionCheckList()
                                    {
                                        PARAMID = assemblyInfo_ != null ? assemblyInfo_.Name : string.Empty,
                                        PROGRAM_PATH = filePath,
                                        //IS_NEED_UPDATE = false,
                                        LOCAL_VERSION = assemblyInfo_ != null ? assemblyInfo_.Version : string.Empty,
                                        //ONLINE_VERSION = string.Empty,
                                        GUID = assemblyInfo_ != null ? assemblyInfo_.GUID : string.Empty,
                                        PROGRAM_MODIDATETIME = File.GetLastWriteTime(filePath).ToFullDateTime() ?? string.Empty,
                                        EXTENSION = Path.GetExtension(filePath)?.ToUpper() ?? string.Empty,
                                    });
                                    LOCAL_FILE_LIST.Add(new VersionCheckList()
                                    {
                                        PARAMID = assemblyInfo_ != null ? "HIS2_OPD_CureRecEditor"?.ToUpper() : string.Empty,
                                        PROGRAM_PATH = filePath,
                                        //IS_NEED_UPDATE = false,
                                        LOCAL_VERSION = assemblyInfo_ != null ? assemblyInfo_.SubVersion : string.Empty,
                                        //ONLINE_VERSION = string.Empty,
                                        GUID = assemblyInfo_ != null ? assemblyInfo_.GUID : string.Empty,
                                        PROGRAM_MODIDATETIME = File.GetLastWriteTime(filePath).ToFullDateTime() ?? string.Empty,
                                        EXTENSION = Path.GetExtension(filePath)?.ToUpper() ?? string.Empty,
                                    });
                                }
                                else
                                {
                                    LOCAL_FILE_LIST.Add(new VersionCheckList()
                                    {
                                        PARAMID = assemblyInfo_ != null ? assemblyInfo_.Name : string.Empty,
                                        PROGRAM_PATH = filePath,
                                        //IS_NEED_UPDATE = false,
                                        LOCAL_VERSION = assemblyInfo_ != null ? assemblyInfo_.Version : string.Empty,
                                        //ONLINE_VERSION = string.Empty,
                                        GUID = assemblyInfo_ != null ? assemblyInfo_.GUID : string.Empty,
                                        PROGRAM_MODIDATETIME = File.GetLastWriteTime(filePath).ToFullDateTime() ?? string.Empty,
                                        EXTENSION = Path.GetExtension(filePath)?.ToUpper() ?? string.Empty,
                                    });

                                }
                            }
                            SerialNumber++;
                        }
                    }
                }
                var NeedUpdateList = new List<VersionCheckList>();
                if (ONLINE_FILE_LIST != null && ONLINE_FILE_LIST.Any())
                {
                    foreach (var online in ONLINE_FILE_LIST)
                    {
                        if (LOCAL_FILE_LIST.Any(x => x.GUID == online.GUID && x.PARAMID?.ToUpper() == online.PARAMID?.ToUpper()) )
                        {
                            foreach (var local in LOCAL_FILE_LIST.Where(x => x.GUID == online.GUID && x.PARAMID?.ToUpper() == online.PARAMID?.ToUpper() ))
                            {
                                if (local != null && CheckOnlineVersionProgramNameList.Any(x => x?.ToUpper() == local.PARAMID?.ToUpper()))
                                {
                                    bool IS_NEED_UPDATE = false;
                                    var IS_VERSION_COMPROMISE = false;
                                    var VersionCompareResult = IsCompareVersionNeedUpdate(local.LOCAL_VERSION, online.ONLINE_VERSION);
                                    if (VersionCompareResult.DifferenceNumber != 0)
                                    {
                                        IS_VERSION_COMPROMISE = true;
                                    }
                                    //如果起始日期有數值且小於等於現在日期時間則會檢核版本號
                                    if (online.BEGINDATETIME != DateTime.MinValue &&
                                        online.BEGINDATETIME <= DateTime.Now)
                                    {
                                        //本地端需與線上相同
                                        if (online.PARAMNUMBER == 0)
                                        {
                                            //線上大於本地端 ，則須更新
                                            if (VersionCompareResult.IsOnlineMoreThanLocal == true)
                                            {
                                                IS_NEED_UPDATE = true;
                                            }
                                        }
                                        //線上可容許 版本差異數 
                                        else
                                        {
                                            if (online.PARAMNUMBER > 0)
                                            {
                                                //本地端版本差異數大於線上容許差異數，則須更新
                                                if (VersionCompareResult.DifferenceNumber > online.PARAMNUMBER)
                                                {
                                                    IS_NEED_UPDATE = true;
                                                }
                                            }
                                        }
                                        NeedUpdateList.Add(new VersionCheckList()
                                        {
                                            DESCRIPT = online.DESCRIPT,
                                            ENGDESCRIPT = online.ENGDESCRIPT,
                                            ONLINE_VERSION = online.ONLINE_VERSION,
                                            LOCAL_VERSION = local.LOCAL_VERSION,
                                            IS_NEED_UPDATE = IS_NEED_UPDATE,
                                            PARAMID = online.PARAMID,
                                            PROGRAM_PATH = local.PROGRAM_PATH,
                                            GUID = online.GUID,
                                            SORT = online.SORT,
                                            PROGRAM_MODIDATETIME = local.PROGRAM_MODIDATETIME,
                                            EXTENSION = local.EXTENSION,
                                            VERSION_COMPROMISE = IS_VERSION_COMPROMISE,
                                            MEMO = online.MEMO,
                                        });
                                    }

                                    
                                }
                            }
                        }
                        else
                        {
                            if(CheckOnlineVersionProgramNameList.Any(x => x == online.PARAMID?.ToUpper()))
                            {
                                NeedUpdateList.Add(new VersionCheckList()
                                {
                                    DESCRIPT = online.DESCRIPT,
                                    ENGDESCRIPT = online.ENGDESCRIPT,
                                    ONLINE_VERSION = online.ONLINE_VERSION,
                                    LOCAL_VERSION = "本地端無此檔案",
                                    IS_NEED_UPDATE = true,
                                    PARAMID = online.PARAMID,
                                    PROGRAM_PATH = string.Empty,
                                    GUID = online.GUID,
                                    SORT = online.SORT,
                                    PROGRAM_MODIDATETIME = string.Empty,
                                    EXTENSION = string.Empty,
                                    VERSION_COMPROMISE = true,
                                    MEMO = online.MEMO,
                                });
                            }
                        }
                    }
                    ReturnResult.IsOk = true;
                    if (NeedUpdateList.Any(x => x.IS_NEED_UPDATE == true))
                    {
                        foreach(var item in NeedUpdateList.Where(x => x.IS_NEED_UPDATE == true))
                        {
                            ReturnResult.Data.Add(item.DESCRIPT, $"線上:[{item.ONLINE_VERSION}],本地:[{item.LOCAL_VERSION}]版本不一致." + (!string.IsNullOrWhiteSpace(item.MEMO) ? Environment.NewLine + "訊息:" + item.MEMO : string.Empty));
                        }
                        ReturnResult.Code = 1;
                        ReturnResult.Message += string.Join(Environment.NewLine, NeedUpdateList.Where(x => x.IS_NEED_UPDATE == true).Select(x => x.DESCRIPT + $"　　線上:[{x.ONLINE_VERSION}],本地:[{x.LOCAL_VERSION}], 版本不一致"));
                    }
                    else
                    {
                        ReturnResult.Code = 0;
                        ReturnResult.Message += "目前皆為最新版本!";
                    }
                }
                else
                {
                    ReturnResult.Message += "線上版本資料取得失敗! \n請確認網路連線是否正常!\n若持續發請聯絡系統管理員!";
                }
            }
            catch(Exception ex)
            {
                ReturnResult.Exception = ex;
                ReturnResult.IsOk = false;
                ReturnResult.Message += "[THROW]:" + ex.Message + Environment.NewLine;
            }
            return ReturnResult;
        }
        #region 解除控制項的所有事件註冊

        // 解除控制項的所有事件註冊
        public static void UnsubscribeAllEvents(Control control)
        {
            if (control == null)
                return;

            foreach (EventInfo eventInfo in control.GetType().GetEvents())
            {
                FieldInfo field = control.GetType().GetField($"events{eventInfo.Name}", BindingFlags.NonPublic | BindingFlags.Instance);

                if (field != null)
                {
                    object target = field.GetValue(control);

                    if (target is EventHandlerList eventHandlerList)
                    {
                        eventHandlerList?.RemoveHandler(eventInfo, eventHandlerList[eventInfo]);
                    }
                }
            }
            // 遞迴處理子控制項
            foreach (Control childControl in control.Controls)
            {
                UnsubscribeAllEvents(childControl);
            }

            // Dispose 元件
            if (control is IDisposable disposableControl)
            {
                disposableControl.Dispose();
            }

            control = null;
        }
        #endregion

        #region VersionCheckList
        /// <summary>
        /// 版本清單資訊
        /// </summary>
        private class VersionCheckList : SYSTEM_PARAM
        {

            /// <summary>
            /// 本地端版本號
            /// </summary>
            public string LOCAL_VERSION { get; set; }
            /// <summary>
            /// 線上端版本號
            /// </summary>
            public string ONLINE_VERSION { get; set; }
            /// <summary>
            /// 程式路徑
            /// </summary>
            public string PROGRAM_PATH { get; set; }
            /// <summary>
            /// 是否需要更新
            /// </summary>
            public bool IS_NEED_UPDATE { get; set; }
            /// <summary>
            /// 程式 Assembly.GUID
            /// </summary>
            public string GUID { get; set; }
            /// <summary>
            /// 程式修改日期時間
            /// </summary>
            public string PROGRAM_MODIDATETIME { get; set; }
            /// <summary>
            /// 副檔名
            /// </summary>
            public string EXTENSION { get; set; }
            /// <summary>
            /// 線上與本地端版本號是否一致[TRUE:一致,False:不一致]
            /// </summary>
            public bool VERSION_COMPROMISE { get; set; }
        }

        #region SYSTEM_PARAM
        private class SYSTEM_PARAM
        {
            /// <summary>
            /// 參數群組
            /// </summary>
            public string PARAMGROUP { get; set; }

            /// <summary>
            /// 參數代碼
            /// </summary>
            public string PARAMID { get; set; }

            /// <summary>
            /// 說明
            /// </summary>
            public string DESCRIPT { get; set; }

            /// <summary>
            /// 英文說明
            /// </summary>
            public string ENGDESCRIPT { get; set; }

            /// <summary>
            /// 文字參數
            /// </summary>
            public string PARAMVARCHAR { get; set; }

            /// <summary>
            /// 數值參數
            /// </summary>
            public decimal? PARAMNUMBER { get; set; }

            /// <summary>
            /// 日期參數
            /// </summary>
            public DateTime? PARAMDATETIME { get; set; }

            /// <summary>
            /// 排序
            /// </summary>
            public int SORT { get; set; }

            /// <summary>
            /// 生效起日
            /// </summary>
            public DateTime BEGINDATETIME { get; set; }

            /// <summary>
            /// 生效迄日
            /// </summary>
            public DateTime ENDDATETIME { get; set; }

            /// <summary>
            /// 取消註記
            /// </summary>
            public string CANCELFLAG { get; set; }

            /// <summary>
            /// 記錄取消時間
            /// </summary>
            public DateTime? CANCELDATETIME { get; set; }

            /// <summary>
            /// 記錄取消人員
            /// </summary>
            public string CANCELEID { get; set; }

            /// <summary>
            /// 記錄建立時間
            /// </summary>
            public DateTime BUILDDATETIME { get; set; }

            /// <summary>
            /// 記錄建立人員
            /// </summary>
            public string BUILDEID { get; set; }

            /// <summary>
            /// 記錄修改時間
            /// </summary>
            public DateTime? MODIDATETIME { get; set; }

            /// <summary>
            /// 記錄修改人員
            /// </summary>
            public string MODIEID { get; set; }
            /// <summary>
            /// 備註
            /// </summary>
            public string MEMO { get; set; }
        }
        #endregion SYSTEM_PARAM
        #endregion VersionCheckList

        #region Version Compare 版本號比較
        /// <summary>
        /// Version Compare 版本號比較
        /// </summary>
        /// <param name="LocalVersion">[X.X.X.X] 本地端</param>
        /// <param name="OnlineVersion">[X.X.X.X] 線上端</param>
        /// <returns>(True:線上大於本地，False: 線上小於或等於本地, int 差異之版本號加權數[0代表版本號相同,1以上代表版本號有差異,-1代表運算錯誤], 詳細差異版本號數)</returns>
        public static (bool IsOnlineMoreThanLocal, int DifferenceNumber, (int Major, int Minor, int Build, int Revision) DifferenceVersionNumber) IsCompareVersionNeedUpdate(string LocalVersion, string OnlineVersion)
        {
            (bool IsOnlineMoreThanLocal, int DifferenceNumber, (int Major, int Minor, int Build, int Revision)) ReturnResult = (false, -1, (0, 0, 0, 0));
            try
            {
                ////是否需要更新
                //var IsNeedUpdate = false;

                //Priority: 1 > 2 > 3 > 4
                //[加權值, 線上 CompareTo 本地]
                Dictionary<int, int> VersionPriority = new Dictionary<int, int>() { { 8, 0 }, { 4, 0 }, { 2, 0 }, { 1, 0 } };

                if (!string.IsNullOrWhiteSpace(LocalVersion) && !string.IsNullOrWhiteSpace(OnlineVersion))
                {
                    var localVersion = LocalVersion.Split('.');
                    var onlineVersion = OnlineVersion.Split('.');
                    if ((localVersion != null && localVersion.Count() == 4) &&
                       (onlineVersion != null && onlineVersion.Count() == 4))
                    {
                        //版本號格式[Major.MINOR.BUILD.REVISION]
                        int MAJOR = 0, MINOR = 0, BUILD = 0, REVISION = 0;
                        for (int index = 0; index < 4; index++)
                        {
                            if (int.TryParse(onlineVersion[index], out int OnlineResult) && int.TryParse(localVersion[index], out int LocalResult))
                            {
                                var it = 0;
                                //加權值 Index[0.1.2.3] = [8,4,2,1]
                                switch (index)
                                {
                                    case 0:
                                        it = 8;
                                        MAJOR = Math.Abs(OnlineResult - LocalResult);
                                        break;
                                    case 1:
                                        it = 4;
                                        MINOR = Math.Abs(OnlineResult - LocalResult);
                                        break;
                                    case 2:
                                        it = 2;
                                        BUILD = Math.Abs(OnlineResult - LocalResult);
                                        break;
                                    case 3:
                                        it = 1;
                                        REVISION = Math.Abs(OnlineResult - LocalResult);
                                        break;
                                }
                                //依照加權值，決定大小
                                if (OnlineResult > LocalResult)
                                {
                                    //線上 > 本地
                                    VersionPriority[it] = 1;
                                }
                                else if (OnlineResult < LocalResult)
                                {
                                    //線上 < 本地
                                    VersionPriority[it] = -1;
                                }
                                else
                                {
                                    //線上 = 本地
                                    VersionPriority[it] = 0;
                                }

                            }
                        }
                        //總加權值計算判斷
                        int loc = 0, online = 0;
                        foreach (var item in VersionPriority)
                        {
                            if (item.Value > 0)
                            {
                                online += item.Value * Math.Abs(item.Key);

                            }
                            else if (item.Value < 0)
                            {
                                loc += Math.Abs(item.Value) * Math.Abs(item.Key);
                            }
                        }
                        if (Math.Abs(online) > Math.Abs(loc))
                        {
                            //線上 大於 本地
                            ReturnResult = (true, Math.Abs(online - loc), (MAJOR, MINOR, BUILD, REVISION));
                        }
                        else if (Math.Abs(online) == Math.Abs(loc))
                        {
                            //線上 = 本地
                            ReturnResult = (false, 0, (MAJOR, MINOR, BUILD, REVISION));
                        }
                        else
                        {
                            //線上 小於 本地 
                            ReturnResult = (false, Math.Abs(online - loc), (MAJOR, MINOR, BUILD, REVISION));
                        }
                    }
                }
                return ReturnResult;
                //return IsNeedUpdate;
            }
            catch
            {
                return ReturnResult;
            }
        }
        #endregion Version Compare 版本號比較
    }

    #region AssemblyFileManager
    //// 程式碼參考自 https://www.codeproject.com/Tips/836907/Loading-Assembly-to-Leave-Assembly-File-Unlocked
    /*  TITLE : Loading Assembly to Leave Assembly File Unlocked
     *  
Loading assembly in a separate AppDomain
(Also described in Sacha Barber's Blog in 2009)
The only way to unload an assembly from an application domain is by unloading the Application Domain
Application Domain is a unit of isolation in .NET that is like a subprocess in the process of application.

The solution is to create a temporary AppDomain, read assembly data in it and then unload the temporary domain from memory.

First, we need to create a class that holds assembly information.
Class must be marked as [Serializable] since it travels between domain boundaries.
    
    [SOURCECODE SECTION 1: public class AssemblyInfo  .....]

    Then, we need to create a proxy class that will do stuff in another domain and return data to the current domain.
It must inherit from MarshalByRefObject.
Only classes inherited from MarshalByRefObject can be accessed between different application domain boundaries.

    [SOURCECODE SECTION 2: public class AssemblyLoader : MarshalByRefObject  .....]

    Then, we need to create a proxy class that will do stuff in another domain and return data to the current domain.
It must inherit from MarshalByRefObject.
Only classes inherited from MarshalByRefObject can be accessed between different application domain boundaries.

    [SOURCECODE SECTION 3: public static AssemblyInfo GetAssemblyInfo(string assemblyPath)  .....]
    */

    #region SECTION 1
    /// <summary>
    /// 取得組件資訊[經由AppDomain載入]
    /// </summary>
    [Serializable]
    public class AssemblyFileManager
    {
        /// <summary>
        /// 組件名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 組件版本號
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 組件GUID
        /// </summary>
        public string GUID { get; set; }
        /// <summary>
        /// 組件執行版本號
        /// </summary>
        public string RuntimeVersion { get; set; }
        /// <summary>
        /// 組件平台
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        /// SubVersion Version
        /// </summary>
        public string SubVersion { get; set; }

        public AssemblyFileManager()
        {

        }
        public AssemblyFileManager(AssemblyName assemblyName, Assembly assembly)
        {
            Name = assemblyName.Name;
            Version = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
            RuntimeVersion = string.Empty;
            Platform = assemblyName.ProcessorArchitecture.ToString();
            GUID = string.Empty;
        }
        /// <summary>
        /// 組件版本資訊
        /// </summary>
        /// <param name="assembly"></param>
        public AssemblyFileManager(Assembly assembly) : this(assembly.GetName(), assembly)
        {
            /*
             * Pros: You have access to full assembly info including Assembly.Codebase and Assembly.Location
             * Cons: Method requires much more code including 3 separate classes.
             */
            try
            {
                var CustomAttributeData = assembly.GetCustomAttributesData();
                if (CustomAttributeData != null && CustomAttributeData.Any(x => x.AttributeType == typeof(System.Runtime.InteropServices.GuidAttribute)))
                {
                    if (CustomAttributeData.FirstOrDefault(x => x.AttributeType == typeof(System.Runtime.InteropServices.GuidAttribute)).ConstructorArguments.Any())
                    {
                        GUID = CustomAttributeData.FirstOrDefault(x => x.AttributeType == typeof(System.Runtime.InteropServices.GuidAttribute)).ConstructorArguments.FirstOrDefault().Value?.ToString();
                    }
                }
                if (CustomAttributeData != null && CustomAttributeData.Any(x => x.AttributeType == typeof(System.Reflection.AssemblyDescriptionAttribute)))
                {
                    if (CustomAttributeData.FirstOrDefault(x => x.AttributeType == typeof(System.Reflection.AssemblyDescriptionAttribute)).ConstructorArguments.Any())
                    {
                        SubVersion = CustomAttributeData.FirstOrDefault(x => x.AttributeType == typeof(System.Reflection.AssemblyDescriptionAttribute)).ConstructorArguments.FirstOrDefault().Value?.ToString();
                    }
                }
                RuntimeVersion = assembly.ImageRuntimeVersion;
            }
            catch
            {

            }


        }

        #region SECTION 3
        /// <summary>
        /// 取得組件資訊
        /// </summary>
        /// <param name="assemblyPath"></param>
        /// <param name="lite"></param>
        /// <returns></returns>
        public static AssemblyFileManager GetAssemblyInfo(string assemblyPath)
        {
            try
            {
                AssemblyFileManager assemblyInfo = null;
                //create a temporary app domain
                AppDomain tempAppDomain = AppDomain.CreateDomain("TempDomain" + Guid.NewGuid());
                // create proxy instance in temporary domain
                var asmLoader = (AssemblyLoader)tempAppDomain.CreateInstanceAndUnwrap(typeof(AssemblyLoader).Assembly.FullName, typeof(AssemblyLoader).FullName);
                // load assembly in other domain
                tempAppDomain.ReflectionOnlyAssemblyResolve += (sender, e) =>
                {
                    var child = Assembly.ReflectionOnlyLoad(e.Name);
                    if (child == null)
                    {
                        throw new TypeLoadException("載入依賴性組件失敗(Depandency Assembly Not Found.), " + e.Name);
                    }
                    return child;
                };
                assemblyInfo = asmLoader.LoadAssemblyInfo(assemblyPath);

                // unload temporary domain and free assembly resources
                AppDomain.Unload(tempAppDomain);
                return assemblyInfo;
            }
            catch
            {
                throw;
            }
        }
        #endregion SECTION 3

    }
    #endregion SECTION 1

    #region SECTION 2
    internal class AssemblyLoader : MarshalByRefObject
    {
        /// <summary>
        /// 經由反射取得AssemblyInfo
        /// </summary>
        /// <param name="assemblyPath"></param>
        /// <returns></returns>
        public AssemblyFileManager LoadAssemblyInfo(string assemblyPath)
        {
            try
            {
                return new AssemblyFileManager(Assembly.ReflectionOnlyLoadFrom(assemblyPath));
            }
            catch
            {
                return null;
            }
        }
    }
    #endregion SECTION 2

    #endregion AssemblyFileManager
}
