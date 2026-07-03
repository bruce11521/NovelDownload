using Dapper;
using Dapper.Contrib.Extensions;
using CoreBase.Help;
using CoreBase.Utilities;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static CoreBase.Help.EnumUtility;

namespace CoreBase.DB
{
    /// <summary>
    /// DB 相關擴充
    /// </summary>
    public class DBhelp //: IDisposable
    {
        #region IDisposable 實作
        ////http://webcache.googleusercontent.com/search?q=cache:bZ_t6PwH7nEJ:https://dotblogs.com.tw/larrynung/2011/03/10/21774&hl=zh-TW&gl=tw&strip=1&vwsrc=0
        ////https://coolmandiary.blogspot.com/2020/11/cidisposable.html
        /////// <summary>
        /////// 非託管資源
        /////// </summary>
        ////private IntPtr nativeResource = System.Runtime.InteropServices.Marshal.AllocHGlobal(500);
        /////// <summary>
        /////// 非託管資源
        /////// </summary>
        ////private IntPtr handle;
        /////// <summary>
        /////// Clean up the unmanaged Resource
        /////// </summary>
        /////// <param name="handle"></param>
        /////// <returns></returns>
        ////[System.Runtime.InteropServices.DllImport("kernel32")]
        ////private extern static Boolean CloseHandle(IntPtr handle);
        /////// <summary>
        /////// 其他託管資源
        /////// </summary>
        ////private Component component = new Component();
        ///// <summary>
        ///// 透過旗標方式來了解資源是否釋放
        ///// </summary>
        //private bool disposed = false;

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        ///// <summary>
        ///// 進行Dispose
        ///// </summary>
        //public void Close()
        //{
        //    Dispose();
        //}
        ///// <summary>
        ///// Use C# destructor syntax for finalization code.
        ///// This destructor will run only if the Dispose method
        ///// does not get called.
        ///// It gives your base class the opportunity to finalize.
        ///// Do not provide destructors in types derived from this class.
        ///// </summary>
        //~DBhelp()
        //{
        //    //必須為False
        //    Dispose(false);
        //}
        ///// <summary>
        ///// 非密封類修飾用protected virtual
        ///// 密封類修飾用private 
        ///// </summary>
        ///// <param name="disposing"></param>
        //protected virtual void Dispose(bool disposing)
        //{
        //    /*
        //    託管資源:
        //    1.由CLR管理分配及釋放的資源(例:從CLR中 new出的物件實體)
        //    2.不需要顯式資源釋放，但若引用型別本身含有非託管資源，則需要自行實踐釋放

        //    非託管資源:
        //    1.不受CLR管理的物件(例:檔案、資料庫連接、Windows 核心物件、COM元件、GDI+..etc)
        //    2.需要顯式資源釋放的，也即需要你寫代碼釋放
        //     */
        //    if (disposed)
        //    {
        //        return;
        //    }
        //    if (disposing)
        //    {
        //        //清理託管資源
        //        //component.Dispose();
        //    }
        //    MemoryUtility.SetGCCollectLOHObjectAutoCompaction();
        //    //清理非託管資源
        //    //CloseHandle(handle);
        //    //handle = IntPtr.Zero;
        //    //if (nativeResource != IntPtr.Zero)
        //    //{
        //    //    System.Runtime.InteropServices.Marshal.FreeHGlobal(nativeResource);
        //    //    nativeResource = IntPtr.Zero;
        //    //}
        //    disposed = true;
        //}
        #endregion IDisposable
        /// <summary>
        /// 初始化 info
        /// </summary>
        public InfoUtility _info;
        /// <summary>
        /// HttpClientHelper
        /// </summary>
        private static readonly HttpClientHelper _httpClientHelper = new HttpClientHelper();

        /// <summary>
        /// 已解密連線字串快取(Key: ConfigName)。連線字串於 app.config 啟動讀取後不會於 runtime 變動，
        /// 因此可安全快取，避免重複呼叫解密 HTTP 服務。如有特殊需求需重新解密，可呼叫 <see cref="InvalidateDecypConnectionStringCache(string)"/>。
        /// </summary>
        private static readonly System.Collections.Concurrent.ConcurrentDictionary<string, string> _decryptedConnectionStringCache
            = new System.Collections.Concurrent.ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Init
        /// </summary>
        public DBhelp()
        {
            _info = new InfoUtility();
            if (_info.HomeCare)
            {
                constr = "Data Source=localhost:1521/HIS2DB;User Id=HIS2USER;Password=AbcdHIS;";
                return;
            }
            if (_info.IsWeb == false)
            {
                defaulConnectStringName = _info.EnvironmentType.ToString();
                constr = GetDecypConnectionString(defaulConnectStringName);
            }
            else
            {
                constr = GetDecypConnectionString();
            }
            DBHelpModifyLogList.Add((DateTime.Now, $"初始化，連線字串:「{constr}」"));
        }
        /// <summary>
        /// Init
        /// </summary>
        /// <param name="IsHomeCareConnect">連線是否使用本機資料庫</param>
        public DBhelp(bool IsHomeCareConnect = false)
        {
            _info = new InfoUtility();
            if (_info.HomeCare || IsHomeCareConnect is true)
            {
                constr = "Data Source=localhost:1521/HIS2DB;User Id=HIS2USER;Password=AbcdHIS;";
                return;
            }
            if (_info.IsWeb == false)
            {
                defaulConnectStringName = _info.EnvironmentType.ToString();
                constr = GetDecypConnectionString(defaulConnectStringName);
            }
            else
            {
                constr = GetDecypConnectionString();
            }
            DBHelpModifyLogList.Add((DateTime.Now, $"初始化(是否使用本機資料庫:{IsHomeCareConnect})，連線字串:「{constr}」"));
        }
        /// <summary>
        /// Get Decode Connection string
        /// </summary>
        /// <returns></returns>
        public string GetConstr()
        {
            return constr;
        }

        /// <summary>
        /// 變更資料庫連線區域[請謹慎使用]
        /// </summary>
        /// <param name="environmentType">資料庫連線區域</param>
        /// <returns>回傳新建立之目標連線區域infoUtility, 如果失敗則會傳ServiceResult.Data = Null</returns>
        public ServiceResult<InfoUtility> SetDBhelpInfoUtility(EnumUtility.EnvironmentType environmentType = EnumUtility.EnvironmentType.HIS2USER2)
        {
            ServiceResult<InfoUtility> returnResult = new ServiceResult<InfoUtility>(false, string.Empty);
            try
            {
                if (_info.IsWeb is true || System.Web.HttpRuntime.AppDomainAppId != null)
                {
                    //如果是網頁則跳過檢核
                    returnResult.Message += "[覆寫TsghMenu設定檔]:偵測為網頁故不覆寫TsghMenu設定檔" + Environment.NewLine;
                    DBHelpModifyLogList.Add((DateTime.Now, $"[{nameof(SetDBhelpInfoUtility)}]設定前連線字串:「{constr}」，偵測為網頁不覆寫TsghMenu設定檔[設定檔:{environmentType.ToString()}]"));
                }
                else
                {
                    var overRideXmlFileContentResult = _info.OVERWRITE_TSGHXML_CONTENT(environmentType);
                    if (overRideXmlFileContentResult.IsOk is false)
                    {
                        DBHelpModifyLogList.Add((DateTime.Now, $"[{nameof(SetDBhelpInfoUtility)}]設定前連線字串:「{constr}」，覆寫TsghMenu設定檔[失敗][設定檔:{environmentType.ToString()}][錯誤訊息:{overRideXmlFileContentResult?.Message}][Throw:{(overRideXmlFileContentResult?.Exception != null ? overRideXmlFileContentResult.Exception.GetInnerException().ErrorMessage : string.Empty)}]"));
                        returnResult.Message += "[覆寫TsghMenu設定檔失敗]:" + overRideXmlFileContentResult.Message + Environment.NewLine;
                        if (overRideXmlFileContentResult.Exception != null)
                        {
                            var getExceptionMsg = overRideXmlFileContentResult.Exception.GetInnerException(true);
                            returnResult.Message += "[覆寫TsghMenu設定檔失敗ExceptionThrow]:" + getExceptionMsg.ErrorMessage + getExceptionMsg.Stacktrace + Environment.NewLine;
                        }
                        //if(infoUtility != null && infoUtility.IsWeb is true)
                        //{
                        //    //如果是網頁則跳過檢核
                        //    returnResult.Message += "[覆寫TsghMenu設定檔]:偵測為網頁故不覆寫TsghMenu設定檔" + Environment.NewLine;
                        //}
                        //else 
                        return returnResult;
                    }
                    else
                    {
                        returnResult.Message += "[覆寫TsghMenu設定檔]:成功" + Environment.NewLine;
                        DBHelpModifyLogList.Add((DateTime.Now, $"[{nameof(SetDBhelpInfoUtility)}]設定前連線字串:「{constr}」，覆寫TsghMenu設定檔[成功][設定檔:{environmentType.ToString()}]"));
                    }
                }
                //複寫TSGHMENU XML 後重新抓取設定檔案
                _info = new InfoUtility();
                //設定AppConfig連線區域名稱
                defaulConnectStringName = environmentType.ToString();
                //設定本DBHelp之連線區域
                _info.EnvironmentType = environmentType;
                //依照連線區域設定本DBHelp相關數值
                switch (environmentType)
                {
                    case EnumUtility.EnvironmentType.Default:
                    case EnumUtility.EnvironmentType.HIS2USER2:
                    case EnumUtility.EnvironmentType.Formal:
                    case EnumUtility.EnvironmentType.Online:
                        _info.HomeCare = false;
                        //if (infoUtility != null)
                        //{
                        //    infoUtility.HomeCare = false;
                        //}
                        constr = GetDecypConnectionString(defaulConnectStringName);
                        break;
                    case EnumUtility.EnvironmentType.Offline:
                        _info.HomeCare = true;
                        //if (infoUtility != null)
                        //{
                        //    infoUtility.HomeCare = true;
                        //}
                        constr = "Data Source=localhost:1521/HIS2DB;User Id=HIS2USER;Password=AbcdHIS;";
                        break;
                }
                DBHelpModifyLogList.Add((DateTime.Now, $"[{nameof(SetDBhelpInfoUtility)}]設定後連線字串:「{constr}」，[設定檔:{environmentType.ToString()}]"));

                //if (infoUtility != null)
                //{
                //    infoUtility.EnvironmentType = environmentType;
                //    returnResult.Data = infoUtility;
                //}
                //else
                //{
                //    returnResult.Data = new InfoUtility();
                //}
                returnResult.Data = new InfoUtility();
                returnResult.Message += $"[連線區域]:變更為[{environmentType.GetEnumDisplayName()}]成功" + Environment.NewLine;
                returnResult.IsOk = true;
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message += "[THROW]:" + ex.Message;
            }
            return returnResult;
        }
        /// <summary>
        /// 設定DBHelper 資料庫連線字串
        /// </summary>
        /// <param name="SetConStr">資料庫連線字串明碼</param>
        /// <returns></returns>
        public ServiceResult<string> SetDBhelpConstr(string SetConStr)
        {
            ServiceResult<string> returnResult = new ServiceResult<string>(false, string.Empty);
            if (!string.IsNullOrWhiteSpace(SetConStr))
            {
                DBHelpModifyLogList.Add((DateTime.Now, $"[{nameof(SetDBhelpConstr)}]設定前連線字串:「{constr}」"));
                constr = SetConStr;
                returnResult.Data = constr;
                returnResult.IsOk = true;
                returnResult.Message += "設定新資料庫連線字串完成(目前資料庫連線字串與TsghMenu.xml脫鉤)!";
                DBHelpModifyLogList.Add((DateTime.Now, $"[{nameof(SetDBhelpConstr)}]設定後連線字串:「{constr}」，目前連線字串與TsghMenu.xml脫鉤"));
            }
            else
            {
                returnResult.Message += "傳入資料庫連線字串不可為空或空白!";
                DBHelpModifyLogList.Add((DateTime.Now, $"[{nameof(SetDBhelpConstr)}]設定失敗，連線字串未變更!目前連線字串:「{constr}」"));
            }
            return returnResult;
        }
        /// <summary>
        /// 資料庫連線字串變更LOG
        /// </summary>
        public List<(DateTime ExecuteDateTime, string ExecuteLog)> DBHelpModifyLogList { get; private set; } = new List<(DateTime, string)>();

        const int BATCH_SIZE = 1024;

        /// <summary>
        /// ConnectionTimeout
        /// </summary>
        public int ConnectionTimeout { get; set; } = 20;

        /// <summary>
        /// ConnectionTimeout 使用者自行訂義
        /// </summary>
        public int? ConnectionTimeoutUserDefine { get; set; } = null;

        /// <summary>
        /// 預設DB使用者帳號
        /// </summary>
        public string defaultDBUser { get; set; } = "HIS2USER2";

        /// <summary>
        /// 預設DB連線字名稱
        /// </summary>
        public string defaulConnectStringName { get; set; } = "HIS2USER2";

        /// <summary>
        /// Dump Exec DB Command
        /// </summary>
        public StringBuilder dumpDBCommand { get; set; } = new StringBuilder();

        /// <summary>
        /// 解密完的連線字串
        /// </summary>
        private string constr { get; set; } = string.Empty;

        /// <summary>
        /// 日期相關參數
        /// </summary>
        public enum DateTimeCompare
        {
            /// <summary>
            /// 等於 =
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Name = "等於")]
            [Description("=")]
            EqualTo = 0,

            /// <summary>
            /// 大於等於 &gt;=
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Name = "大於等於")]
            [Description(">=")]
            IsMoreThanOrEqualTo = 1,

            /// <summary>
            /// 大於 &gt;
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Name = "大於")]
            [Description(">")]
            IsMoreThano = 2,

            /// <summary>
            /// 小於等於  &lt;=
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Name = "小於等於")]
            [Description("<=")]
            IsLessThanOrEqualTo = 3,

            /// <summary>
            /// 小於 &lt;
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Name = "小於")]
            [Description("<")]
            IsLessThano = 4,
        }
        /// <summary>
        /// 組SQL使用之SYSDATE特定轉換語法 可於BindUpdate(),UpdateAsync()時使用
        /// </summary>
        public string _SYSDATE_ { get; private set; } = "__SYSDATE__";

        /// <summary>
        /// 取得解密後的連線字串
        /// </summary>
        /// <param name="ConfigName">Config Name(若為 null 或空白則使用 <c>defaulConnectStringName</c>)</param>
        /// <returns>解密後的連線字串</returns>
        public string GetDecypConnectionString(string ConfigName = null)
        {
            if (string.IsNullOrWhiteSpace(ConfigName))
            {
                ConfigName = defaulConnectStringName;
            }

            //連線字串於 app.config 啟動載入後不會在 runtime 變動，已解密過的結果可直接重用
            return _decryptedConnectionStringCache.GetOrAdd(ConfigName, DecryptConnectionStringFromRemote);
        }

        /// <summary>
        /// 清除指定(或全部)連線字串解密快取，下次呼叫 <see cref="GetDecypConnectionString(string)"/> 將重新解密。
        /// </summary>
        /// <param name="ConfigName">指定要清除的 ConfigName，傳 null 則清除全部</param>
        public static void InvalidateDecypConnectionStringCache(string ConfigName = null)
        {
            if (string.IsNullOrWhiteSpace(ConfigName))
            {
                _decryptedConnectionStringCache.Clear();
            }
            else
            {
                _decryptedConnectionStringCache.TryRemove(ConfigName, out _);
            }
        }

        /// <summary>
        /// 實際呼叫遠端 TSGH 解密服務取得明文連線字串
        /// </summary>
        private static string DecryptConnectionStringFromRemote(string ConfigName)
        {
            var connectionStringSetting = ConfigurationManager.ConnectionStrings[ConfigName];
            if (connectionStringSetting is null)
            {
                throw new ConfigurationErrorsException(
                    $"找不到名為 [{ConfigName}] 的 連線設定。");
            }

            //參數 URL 編碼(改用 BCL Uri.EscapeDataString，避免依賴 System.Web)
            string p1 = Uri.EscapeDataString(connectionStringSetting.ConnectionString);
            string p2 = Uri.EscapeDataString("tsghmis");
            string p3 = Uri.EscapeDataString("mis88630!");
            // 2023.03.14 公告 解密 Domain 更換為 F5-TsghDecrypt.ndmctsgh.edu.tw
            string url = $"http://F5-TsghDecrypt.ndmctsgh.edu.tw/tsghDecrypt/Home/Decrypt?txt={p1}&user={p2}&passwd={p3}";

            return _httpClientHelper.GetAsync<string>(url).GetAwaiter().GetResult().Data;
        }

        /// <summary>
        /// 多筆SQL執行用(INSERT、UPDATE、DELETE)
        /// </summary>
        /// <param name="sql"></param>
        public void batchExcute(List<string> sqlList)
        {
            //string constr = HIS2_PUB.DecryptUtility.Instance.GetDecypConnectionString(defaulConnectStringName);
            //string constr =  GetDecypConnectionString(defaulConnectStringName);;
            try
            {
                using (OracleConnection oracleConn = new OracleConnection(constr))
                {

                    oracleConn.Open();
                    IDbTransaction transaction = oracleConn.BeginTransaction();
                    try
                    {
                        foreach (string sql in sqlList)
                        {
                            oracleConn.Execute(sql, null, transaction, ConnectionTimeoutUserDefine ?? ConnectionTimeout);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                    oracleConn.Close();
                    oracleConn.Dispose();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 建立資料庫連線
        /// </summary>
        /// <param name="readOnlyConnection">是否唯讀</param>
        /// <returns>資料庫連線</returns>
        public OracleConnection GetDbConnection(bool readOnlyConnection = false)
        {
            //string constr = HIS2_PUB.DecryptUtility.Instance.GetDecypConnectionString(defaulConnectStringName);
            //string constr = GetDecypConnectionString(defaulConnectStringName);
            OracleConnection dBConnection = new OracleConnection(constr);

            if (dBConnection.State != ConnectionState.Open)
            {
                dBConnection.Open();
            }

            return dBConnection;
        }
        /// <summary>
        /// 只建立資料庫物件，先不進行OPEN連線
        /// </summary>
        /// <returns></returns>
        private OracleConnection GetDbConnectionWithoutOpen()
        {
            return new OracleConnection(constr);
        }
        /// <summary>
        /// 需要開啟連線時候自動判斷 同時支援取消與非Oracle連線
        /// </summary>
        /// <param name="con"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        private static async Task OpenDbConnectionAsyncIfNeeded(IDbConnection con, CancellationToken ct)
        {
            if (con is System.Data.Common.DbConnection dbc)
            {
                //先手動 OpenAsync(token) 的好處：
                // 連線階段就能取消。
                // 把「連線成本」跟「查詢成本」分開，較好診斷（連線慢 vs 查詢慢）。
                // 在連線池壓力大時，非同步開啟可降低 UI 卡頓
                if (dbc.State != ConnectionState.Open)
                {
                    await dbc.OpenAsync(ct).ConfigureAwait(false);
                }
            }
            else
            {
                if(con.State != ConnectionState.Open)
                    con.Open();
            }
        }


        #region 連線字串相關

        /// <summary>
        /// 檢查
        /// </summary>
        public void CheckAppConfigList()
        {
            CheckAppConfig(EnumUtility.EnvironmentType.HIS2USER2);
            CheckAppConfig(EnumUtility.EnvironmentType.Formal);
        }

        /// <summary>
        /// Enum 轉到 App.Config
        /// </summary>
        /// <param name="environmentType"></param>
        private void CheckAppConfig(EnumUtility.EnvironmentType environmentType)
        {

            bool isModified = ConfigurationManager.ConnectionStrings[environmentType.ToString()] != null;    //記錄該連接串是否已經存在

            ConnectionStringSettings mySettings = new ConnectionStringSettings(environmentType.ToString(), environmentType.GetEnumDescription(), "Oracle.ManagedDataAccess.Client");
            // 打開可執行的配置文件*.exe.config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // 如果連接串已存在，首先刪除它
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(environmentType.ToString());
            }

            // 將新的連接串添加到配置文件中.
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存對配置文件所作的更改
            config.Save(ConfigurationSaveMode.Modified);
            // 強制重新載入配置文件的ConnectionStrings配置節 
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }

        /// <summary>
        /// 修改連線字串
        /// 統一只用HIS2USER2的名稱，只改內容物
        /// </summary>
        /// <param name="environmentType"></param>
        private void ChangeAppConfig(EnumUtility.EnvironmentType environmentType)
        {
            bool isModified = ConfigurationManager.ConnectionStrings[EnumUtility.EnvironmentType.HIS2USER2.ToString()] != null;    //記錄該連接串是否已經存在

            ConnectionStringSettings mySettings = new ConnectionStringSettings(EnumUtility.EnvironmentType.HIS2USER2.ToString(), environmentType.GetEnumDescription(), "Oracle.ManagedDataAccess.Client");
            // 打開可執行的配置文件*.exe.config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // 如果連接串已存在，首先刪除它
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(EnumUtility.EnvironmentType.HIS2USER2.ToString());
            }

            // 將新的連接串添加到配置文件中.
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存對配置文件所作的更改
            config.Save(ConfigurationSaveMode.Modified);
            // 強制重新載入配置文件的ConnectionStrings配置節 
            ConfigurationManager.RefreshSection("ConnectionStrings");

        }
        #endregion 連線字串相關

        #region Query 系列
        /// <summary>
        /// 查詢用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IEnumerable<T> query<T>(string sql)
        {
            //string constr = HIS2_PUB.DecryptUtility.Instance.GetDecypConnectionString(defaulConnectStringName);
            //string constr =  GetDecypConnectionString(defaulConnectStringName);
            try
            {
                using (OracleConnection oracleConn = new OracleConnection(constr))
                {
                    IEnumerable<T> result = oracleConn.Query<T>(sql);
                    oracleConn.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查詢用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object parameters = null)
        {
            IEnumerable<T> result = null;

            try
            {
                using (OracleConnection oracleConn = new OracleConnection(constr))
                {
                    result = oracleConn.Query<T>(sql, parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// 查詢用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">Script</param>
        /// <param name="readOnlyConnection">唯讀參數</param>
        /// <param name="param">參數</param>
        /// <returns></returns>
        public DataTable Query(string sql, bool readOnlyConnection = false, OracleParameter[] param = null)
        {
            //string constr = HIS2_PUB.DecryptUtility.Instance.GetDecypConnectionString(defaulConnectStringName);
            //string constr =  GetDecypConnectionString(defaulConnectStringName);;
            DataSet dataSet = new DataSet();
            DataTable datatable = new DataTable();

            try
            {
                using (var conn = GetDbConnection(readOnlyConnection) as OracleConnection)
                {
                    OracleCommand command = new OracleCommand(sql, conn);
                    if (param != null)
                    {
                        command.Parameters.AddRange(param);
                    }
                    new OracleDataAdapter(command).Fill(dataSet);
                    datatable = dataSet.Tables[0];
                }
            }
            catch (Exception)
            {
                throw;
            }
            return datatable;
        }
        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <typeparam name="TReturn">回覆的資料類型</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="param">查詢參數物件</param>
        /// <param name="timeoutSecs">SQL執行Timeout秒數</param>
        /// <param name="readOnlyConnection">是否使用 Read Only Connetion</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>x
        public async Task<IEnumerable<TReturn>> QueryAsyncwithTimeoutTime<TReturn>(string querySql, object param = null, int? timeoutSecs = null, bool readOnlyConnection = false, CommandType commandType = CommandType.Text)
        {
            try
            {
                timeoutSecs = timeoutSecs ?? (ConnectionTimeoutUserDefine ?? ConnectionTimeout);

                using (IDbConnection con = GetDbConnection(readOnlyConnection))
                {
                    return await con.QueryAsync<TReturn>(querySql, param, null, timeoutSecs, commandType).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <typeparam name="TReturn">回覆的資料類型</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="param">查詢參數物件</param>
        /// <param name="timeoutSecs">SQL執行Timeout秒數</param>
        /// <param name="readOnlyConnection">是否使用 Read Only Connetion</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>x
        public async Task<IEnumerable<TReturn>> QueryAsyncwithTimeoutTimeToken<TReturn>(string querySql, object param = null,
            int? timeoutSecs = null, CommandType commandType = CommandType.Text,
            CancellationToken cancellationToken = default)
        {
            var effectiveTimeoutSecs = timeoutSecs ?? (ConnectionTimeoutUserDefine ?? ConnectionTimeout);
            using var con = GetDbConnectionWithoutOpen(); //建立資料庫物件
            await OpenDbConnectionAsyncIfNeeded(con, cancellationToken); //自動判斷是否建立非同步可取消連線
                                                                             //using (IDbConnection con = GetDbConnection(readOnlyConnection))
                                                                             //{
            var cmd = new CommandDefinition(
                querySql,
                parameters: param,
                commandType: commandType,
                commandTimeout: effectiveTimeoutSecs,
                cancellationToken: cancellationToken);
            return await con.QueryAsync<TReturn>(cmd).ConfigureAwait(false);
            //return await con.QueryAsync<TReturn>(querySql, param, null, timeoutSecs, commandType).ConfigureAwait(false);
            //}
        }

        /// <summary>
        /// 查詢資料
        /// (keyEntity的name請使用nameof，若想使用like則在Value內使用%，則自動轉換為Like, 若value為陣列則自動轉換為IN, 大於1千筆會自動轉換（但大於一萬筆，會壞掉，請自行切割）, 若value為DateTime則條件自動為大於等於, 若value為!Null則條件自動為Not Null, 若value為!Y則條件自動為 &lt;&gt; 'Y')
        /// </summary>
        /// <typeparam name="TResult">資料封裝的物件類型</typeparam>
        /// <param name="paramDictoionary">查詢條件</param>
        /// <returns></returns>
        public async Task<IEnumerable<TResult>> QueryAsync<TResult>(Dictionary<string, object> paramDictoionary)
            where TResult : new()
        {
            DynamicParameters keyEntity = new DynamicParameters();
            foreach (var item in paramDictoionary)
            {
                keyEntity.Add(item.Key, item.Value);
            }

            BindQuery<TResult>(keyEntity, out var bindSql, out var bindDp);

            using (IDbConnection con = GetDbConnection(false))
            {
                return await con.QueryAsync<TResult>(bindSql, bindDp, null, ConnectionTimeoutUserDefine ?? ConnectionTimeout, CommandType.Text).ConfigureAwait(false);
            }

            //return await QueryAsync<TResult>(keyEntity).ConfigureAwait(false);
        }

        /// <summary>
        /// 查詢資料
        /// (keyEntity的name請使用nameof，若想使用like則在Value內使用%，則自動轉換為Like, 若value為陣列則自動轉換為IN, 大於1千筆會自動轉換（但大於一萬筆，會壞掉，請自行切割）, 若value為DateTime則條件自動為大於等於, 若value為!Null則條件自動為Not Null, 若value為!Y則條件自動為 &lt;&gt; 'Y')
        /// </summary>
        /// <typeparam name="TResult">資料封裝的物件類型</typeparam>
        /// <param name="paramDictoionary">查詢條件</param>
        /// <returns></returns>
        public async Task<IEnumerable<TResult>> QueryAsyncToken<TResult>(Dictionary<string, object> paramDictoionary
        , CancellationToken cancellationToken = default)
            where TResult : new()
        {
            DynamicParameters keyEntity = new DynamicParameters();
            foreach (var item in paramDictoionary)
            {
                keyEntity.Add(item.Key, item.Value);
            }

            BindQuery<TResult>(keyEntity, out var bindSql, out var bindDp);
            using var con = GetDbConnectionWithoutOpen(); //建立資料庫物件
            await OpenDbConnectionAsyncIfNeeded(con, cancellationToken); //自動判斷是否建立非同步可取消連線
                                                             // 連線階段就能取消。
                                                             // 把「連線成本」跟「查詢成本」分開，較好診斷（連線慢 vs 查詢慢）。
                                                             // 在連線池壓力大時，非同步開啟可降低 UI 卡頓
                                                             //using (IDbConnection con = GetDbConnection(false))
                                                             //{
            var cmd = new CommandDefinition(
                bindSql,
                parameters: bindDp,
                commandType: CommandType.Text,
                commandTimeout: ConnectionTimeoutUserDefine ?? ConnectionTimeout,
                cancellationToken: cancellationToken);
            return await con.QueryAsync<TResult>(cmd).ConfigureAwait(false);
            //return await con.QueryAsync<TResult>(bindSql, bindDp, null, ConnectionTimeoutUserDefine ?? ConnectionTimeout, CommandType.Text).ConfigureAwait(false);
            //}

            //return await QueryAsync<TResult>(keyEntity).ConfigureAwait(false);
        }
        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <typeparam name="TFirst">回覆的資料類型1</typeparam>
        /// <typeparam name="TSecond">回覆的資料類型2</typeparam>
        /// <typeparam name="TReturn">回覆的資料類型</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="map">資料物件的組成方法</param>
        /// <param name="param">查詢參數物件</param>
        /// <param name="splitOn">使用join條件時，回傳資料的切分欄位</param>
        /// <param name="readOnlyConnection">是否使用 Read Only Connetion</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string querySql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "Id", bool readOnlyConnection = false, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection con = GetDbConnection(readOnlyConnection))
            {
                return await con.QueryAsync(querySql, map, param: param, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <typeparam name="TFirst">回覆的資料類型1</typeparam>
        /// <typeparam name="TSecond">回覆的資料類型2</typeparam>
        /// <typeparam name="TReturn">回覆的資料類型</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="map">資料物件的組成方法</param>
        /// <param name="param">查詢參數物件</param>
        /// <param name="splitOn">使用join條件時，回傳資料的切分欄位</param>
        /// <param name="readOnlyConnection">是否使用 Read Only Connetion</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>
        public async Task<IEnumerable<TReturn>> QueryAsyncToken<TFirst, TSecond, TReturn>(string querySql,
            Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "Id",
            bool readOnlyConnection = false, CommandType commandType = CommandType.Text,
            int? timeoutSecs = null,
            CancellationToken cancellationToken = default)
        {
            using var con = GetDbConnectionWithoutOpen(); //建立資料庫物件
            await OpenDbConnectionAsyncIfNeeded(con, cancellationToken); //自動判斷是否建立非同步可取消連線
            var cmd = new CommandDefinition(
                querySql,
                parameters: param,
                commandType: commandType,
                commandTimeout: timeoutSecs ?? (ConnectionTimeoutUserDefine ?? ConnectionTimeout),
                cancellationToken: cancellationToken);

            return await con.QueryAsync<TFirst, TSecond, TReturn>(
                cmd, map, splitOn: splitOn).ConfigureAwait(false);
            //using (IDbConnection con = GetDbConnection(readOnlyConnection))
            //{
            //    return await con.QueryAsync(querySql, map, param: param, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
            //}
        }

        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <typeparam name="TFirst">回覆的資料類型1</typeparam>
        /// <typeparam name="TSecond">回覆的資料類型2</typeparam>
        /// <typeparam name="TThird">回覆的資料類型3</typeparam>
        /// <typeparam name="TReturn">回覆的資料類型</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="map">資料物件的組成方法</param>
        /// <param name="param">查詢參數</param>
        /// <param name="splitOn">使用join條件時，回傳資料的切分欄位</param>
        /// <param name="readOnlyConnection">是否使用 Read Only Connetion</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string querySql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, string splitOn = "Id", bool readOnlyConnection = true, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection con = GetDbConnection(readOnlyConnection))
            {
                return await con.QueryAsync(querySql, map, param: param, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
            }
        }
        

        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <typeparam name="TFirst">回覆的資料類型1</typeparam>
        /// <typeparam name="TSecond">回覆的資料類型2</typeparam>
        /// <typeparam name="TThird">回覆的資料類型3</typeparam>
        /// <typeparam name="TReturn">回覆的資料類型</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="map">資料物件的組成方法</param>
        /// <param name="param">查詢參數</param>
        /// <param name="splitOn">使用join條件時，回傳資料的切分欄位</param>
        /// <param name="readOnlyConnection">是否使用 Read Only Connetion</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>
        public async Task<IEnumerable<TReturn>> QueryAsyncToken<TFirst, TSecond, TThird, TReturn>(string querySql,
            Func<TFirst, TSecond, TThird, TReturn> map, object param = null, string splitOn = "Id",
            bool readOnlyConnection = true, CommandType commandType = CommandType.Text, int? timeoutSecs = null,
            CancellationToken cancellationToken = default)
        {
            using var con = GetDbConnectionWithoutOpen(); //建立資料庫物件
            await OpenDbConnectionAsyncIfNeeded(con, cancellationToken); //自動判斷是否建立非同步可取消連線
            var cmd = new CommandDefinition(
                querySql,
                parameters: param,
                commandType: commandType,
                commandTimeout: timeoutSecs ?? (ConnectionTimeoutUserDefine ?? ConnectionTimeout),
                cancellationToken: cancellationToken);

            return await con.QueryAsync<TFirst, TSecond, TThird, TReturn>(
                cmd, map, splitOn: splitOn).ConfigureAwait(false);
            //using (IDbConnection con = GetDbConnection(readOnlyConnection))
            //{
            //    return await con.QueryAsync(querySql, map, param: param, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
            //}
        }

        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <typeparam name="TFirst">回覆的資料類型1</typeparam>
        /// <typeparam name="TSecond">回覆的資料類型2</typeparam>
        /// <typeparam name="TThird">回覆的資料類型3</typeparam>
        /// <typeparam name="TFourth">回覆的資料類型4</typeparam>
        /// <typeparam name="TReturn">回覆的資料類型</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="map">資料物件的組成方法</param>
        /// <param name="param">查詢參數</param>
        /// <param name="splitOn">使用join條件時，回傳資料的切分欄位</param>
        /// <param name="readOnlyConnection">是否使用 Read Only Connetion</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string querySql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, string splitOn = "Id", bool readOnlyConnection = true, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection con = GetDbConnection(readOnlyConnection))
            {
                return await con.QueryAsync(querySql, map, param: param, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <typeparam name="TFirst">回覆的資料類型1</typeparam>
        /// <typeparam name="TSecond">回覆的資料類型2</typeparam>
        /// <typeparam name="TThird">回覆的資料類型3</typeparam>
        /// <typeparam name="TFourth">回覆的資料類型4</typeparam>
        /// <typeparam name="TReturn">回覆的資料類型</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="map">資料物件的組成方法</param>
        /// <param name="param">查詢參數</param>
        /// <param name="splitOn">使用join條件時，回傳資料的切分欄位</param>
        /// <param name="readOnlyConnection">是否使用 Read Only Connetion</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>
        public async Task<IEnumerable<TReturn>> QueryAsyncToken<TFirst, TSecond, TThird, TFourth, TReturn>(string querySql,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, string splitOn = "Id",
            bool readOnlyConnection = true, CommandType commandType = CommandType.Text,
            int? timeoutSecs = null,
            CancellationToken cancellationToken = default)
        {
            using var con = GetDbConnectionWithoutOpen(); //建立資料庫物件
            await OpenDbConnectionAsyncIfNeeded(con, cancellationToken); //自動判斷是否建立非同步可取消連線

            var cmd = new CommandDefinition(
                querySql,
                parameters: param,
                commandType: commandType,
                commandTimeout: timeoutSecs ?? (ConnectionTimeoutUserDefine ?? ConnectionTimeout),
                cancellationToken: cancellationToken);

            return await con.QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
                cmd, map, splitOn: splitOn).ConfigureAwait(false);
            //using (IDbConnection con = GetDbConnection(readOnlyConnection))
            //{
            //    return await con.QueryAsync(querySql, map, param: param, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
            //}
        }

        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <typeparam name="TFirst">回覆的資料類型1</typeparam>
        /// <typeparam name="TSecond">回覆的資料類型2</typeparam>
        /// <typeparam name="TThird">回覆的資料類型3</typeparam>
        /// <typeparam name="TFourth">回覆的資料類型4</typeparam>
        /// <typeparam name="TFifth">回覆的資料類型5</typeparam>
        /// <typeparam name="TReturn">回覆的資料類型</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="map">資料物件的組成方法</param>
        /// <param name="param">查詢參數</param>
        /// <param name="splitOn">使用join條件時，回傳資料的切分欄位</param>
        /// <param name="readOnlyConnection">是否使用 Read Only Connetion</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string querySql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, string splitOn = "Id", bool readOnlyConnection = true, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection con = GetDbConnection(readOnlyConnection))
            {
                return await con.QueryAsync(querySql, map, param: param, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <typeparam name="TFirst">回覆的資料類型1</typeparam>
        /// <typeparam name="TSecond">回覆的資料類型2</typeparam>
        /// <typeparam name="TThird">回覆的資料類型3</typeparam>
        /// <typeparam name="TFourth">回覆的資料類型4</typeparam>
        /// <typeparam name="TFifth">回覆的資料類型5</typeparam>
        /// <typeparam name="TReturn">回覆的資料類型</typeparam>
        /// <param name="querySql">SQL敘述</param>
        /// <param name="map">資料物件的組成方法</param>
        /// <param name="param">查詢參數</param>
        /// <param name="splitOn">使用join條件時，回傳資料的切分欄位</param>
        /// <param name="readOnlyConnection">是否使用 Read Only Connetion</param>
        /// <param name="commandType">敘述類型</param>
        /// <returns>資料物件</returns>
        public async Task<IEnumerable<TReturn>> QueryAsyncToken<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            string querySql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null,
            string splitOn = "Id", bool readOnlyConnection = true, CommandType commandType = CommandType.Text,
            int? timeoutSecs = null,
            CancellationToken cancellationToken = default)
        {
            using var con = GetDbConnectionWithoutOpen(); //建立資料庫物件
            await OpenDbConnectionAsyncIfNeeded(con, cancellationToken); //自動判斷是否建立非同步可取消連線

            var cmd = new CommandDefinition(
                querySql,
                parameters: param,
                commandType: commandType,
                commandTimeout: timeoutSecs ?? (ConnectionTimeoutUserDefine ?? ConnectionTimeout),
                cancellationToken: cancellationToken);

            return await con.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
                cmd, map, splitOn: splitOn).ConfigureAwait(false);
            //using (IDbConnection con = GetDbConnection(readOnlyConnection))
            //{
            //    return await con.QueryAsync(querySql, map, param: param, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
            //}
        }

        /// <summary>
        /// 查詢資料
        /// (keyEntity的name請使用nameof，若想使用like則在Value內使用%，則自動轉換為Like, 若value為陣列則自動轉換為IN, 大於1千筆會自動轉換（但大於一萬筆，會壞掉，請自行切割）, 若value為DateTime則條件自動為大於等於, 若value為!Null則條件自動為Not Null, 若value為!Y則條件自動為 &lt;&gt; 'Y')
        /// </summary>
        /// <typeparam name="TResult">資料封裝的物件類型</typeparam>
        /// <param name="keyEntity">Where的物件</param>
        /// <param name="readOnlyConnection">是否使用Read Only Connetion</param>
        /// <returns></returns>
        public async Task<IEnumerable<TResult>> QueryAsync<TResult>(DynamicParameters keyEntity = null, bool readOnlyConnection = false)
            where TResult : new()
        {
            DynamicParameters KeyEntity = new DynamicParameters();

            if (keyEntity != null)
            {
                KeyEntity = keyEntity;
            }

            BindQuery<TResult>(KeyEntity, out var bindSql, out var bindDp);

            using (IDbConnection con = GetDbConnection(readOnlyConnection))
            {
                return await con.QueryAsync<TResult>(bindSql, bindDp, null, ConnectionTimeoutUserDefine ?? ConnectionTimeout, CommandType.Text).ConfigureAwait(false);
            }
            /*
            DynamicParameters dynamicParameters = new DynamicParameters();
            List<string> keyProperties = new List<string>();
            string querySql = string.Empty;

            Type modelType = typeof(TResult);
            bool hasTableAttribute = modelType.IsDefined(typeof(TableAttribute), true);
            string tableName = hasTableAttribute ? ((TableAttribute)modelType.GetCustomAttributes(typeof(TableAttribute), true)[0]).Name : modelType.Name;
            bool hasUserAttribute = modelType.IsDefined(typeof(DBUserAttribute), true);
            string userName = hasUserAttribute ? ((DBUserAttribute)modelType.GetCustomAttributes(typeof(DBUserAttribute), true)[0]).Name : defaultDBUser;

            //List<string> queryProperties = (from entityMember in new TResult().GetType().GetProperties() where !entityMember.IsDefined(typeof(WriteAttribute), true) select entityMember.Name).ToList();
            List<string> queryProperties = (from entityMember in new TResult().GetType().GetProperties() 
                                            where !entityMember.IsDefined(typeof(WriteAttribute), true) && 
                                                  !entityMember.IsDefined(typeof(NoSelect), true) 
                                            select entityMember.Name).ToList();

            querySql += $"SELECT {string.Join($"{Environment.NewLine}, ", queryProperties)} FROM {userName}.{tableName} ";

            if (keyEntity != null && keyEntity.ParameterNames.Any())
            {
                var parametersLookup = (SqlMapper.IParameterLookup)keyEntity;

                foreach (var keyentityParameterName in keyEntity.ParameterNames)
                {
                    var pValue = parametersLookup[keyentityParameterName];
                    if (!(pValue is string) && (pValue is ValueTuple<DateTime, DateTime>))
                    {
                        keyProperties.Add($"{keyentityParameterName} Between :key_{keyentityParameterName} And :key_{keyentityParameterName}1");
                    }
                    else if (!(pValue is string) && (pValue is ValueTuple<DateTimeCompare, DateTime>))
                    {
                        var tupleValue = (ValueTuple<DateTimeCompare, DateTime>)pValue;
                        var descriptionValue = tupleValue.Item1.GetEnumDescription();
                        keyProperties.Add($"{keyentityParameterName} {descriptionValue} :key_{keyentityParameterName} ");
                    }
                    else if (!(pValue is string) && pValue is IEnumerable)
                    {

                        (List<string> keyProp, DynamicParameters keyValue, Dictionary<string, object> keyDic) resultList = (new List<string> { }, new DynamicParameters(), new Dictionary<string, object> { });

                        if (new Regex("string").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<object>);
                        }
                        else if (new Regex("datetime").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<DateTime>);
                        }
                        else if (new Regex("single").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Single>);
                        }
                        else if (new Regex("double").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Double>);
                        }
                        else if (new Regex("decimal").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Decimal>);
                        }
                        else if (new Regex("int").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Int32>);
                        }
                        //switch (pValue.GetType().FullName.Split('[').Last().Split(',').First().Split('.').Last())
                        //{

                        //    case "DateTime":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<DateTime>);
                        //        break;
                        //    case "String":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<object>);
                        //        break;
                        //    case "Int16":
                        //    case "Int32":
                        //    case "Int64":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Int32>);
                        //        break;
                        //    case "Decimal":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Decimal>);
                        //        break;
                        //    case "Single":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Single>);
                        //        break;
                        //    case "Double":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Double>);
                        //        break;
                        //}

                        keyProperties.Add(" ( " + string.Join(" Or ", resultList.keyProp) + " ) ");
                        dynamicParameters.AddDynamicParams(resultList.keyValue);

                        //keyProperties.Add($"{keyentityParameterName} IN :key_{keyentityParameterName}");
                    }
                    else if (!(pValue is string) && pValue is DateTime)
                    {
                        keyProperties.Add($"{keyentityParameterName} = :key_{keyentityParameterName}");
                    }
                    else if (!(pValue is string) && pValue == null)
                    {
                        keyProperties.Add($"{keyentityParameterName} IS NULL");
                    }
                    else if (!(pValue is string) && pValue is Regex)
                    {
                        keyProperties.Add($"RegexP_Like({keyentityParameterName}, '{(pValue as Regex).ToString()}' )");
                    }
                    else
                    {
                        switch (pValue)
                        {
                            case string _ when pValue.ToString().Contains("%"):
                                keyProperties.Add($"{keyentityParameterName} LIKE :key_{keyentityParameterName}");
                                break;
                            case string _ when pValue.ToString().Equals("!Null"):
                                keyProperties.Add($"{keyentityParameterName} IS Not NULL");
                                break;
                            case string _ when pValue.ToString().Contains("!"):
                                keyProperties.Add($"{keyentityParameterName} <> :key_{keyentityParameterName}");
                                pValue = pValue.ToString().Replace("!", string.Empty);
                                break;
                            default:
                                keyProperties.Add($"{keyentityParameterName} = :key_{keyentityParameterName}");
                                break;
                        }
                    }

                    if (!(pValue is string) && (pValue is ValueTuple<DateTime, DateTime>))
                    {
                        var tupleValue = (ValueTuple<DateTime, DateTime>)pValue;
                        dynamicParameters.Add("key_" + keyentityParameterName, tupleValue.Item1);
                        dynamicParameters.Add("key_" + keyentityParameterName + "1", tupleValue.Item2);
                    }
                    else if (!(pValue is string) && (pValue is ValueTuple<DateTimeCompare, DateTime>))
                    {
                        var tupleValue = (ValueTuple<DateTimeCompare, DateTime>)pValue;
                        dynamicParameters.Add("key_" + keyentityParameterName, tupleValue.Item2);
                        //dynamicParameters.Add("key_" + keyentityParameterName, $@"to_date('{tupleValue.Item2.ToString("yyyyMMddHHmmss")}', 'yyyyMMddHH24MIss')");
                    }
                    else if (!(pValue is string) 
                        && (pValue is IEnumerable || pValue is Regex))
                        {
                        // 上面已加入參數了
                    }
                    else
                    {
                        dynamicParameters.Add("key_" + keyentityParameterName, pValue);
                    }
                }

                querySql += $"{Environment.NewLine} WHERE {string.Join($"{Environment.NewLine} AND ", keyProperties)} ";
            }

            using (IDbConnection con = GetDbConnection(readOnlyConnection))
            {
                return await con.QueryAsync<TResult>(querySql, dynamicParameters, null, ConnectionTimeoutUserDefine ?? ConnectionTimeout, CommandType.Text).ConfigureAwait(false);
            }
            */
        }
        /// <summary>
        /// 查詢資料
        /// (keyEntity的name請使用nameof，若想使用like則在Value內使用%，則自動轉換為Like, 若value為陣列則自動轉換為IN, 大於1千筆會自動轉換（但大於一萬筆，會壞掉，請自行切割）, 若value為DateTime則條件自動為大於等於, 若value為!Null則條件自動為Not Null, 若value為!Y則條件自動為 &lt;&gt; 'Y')
        /// </summary>
        /// <typeparam name="TResult">資料封裝的物件類型</typeparam>
        /// <param name="keyEntity">Where的物件</param>
        /// <param name="readOnlyConnection">是否使用Read Only Connetion</param>
        /// <param name="cancellationToken">CancelToken</param>
        /// <returns></returns>
        public async Task<IEnumerable<TResult>> QueryAsyncToken<TResult>(DynamicParameters keyEntity = null, bool readOnlyConnection = false
        , CancellationToken cancellationToken = default)
            where TResult : new()
        {
            DynamicParameters KeyEntity = keyEntity ?? new DynamicParameters();

            BindQuery<TResult>(KeyEntity, out var bindSql, out var bindDp);

            using var con = GetDbConnectionWithoutOpen(); //建立資料庫物件
            await OpenDbConnectionAsyncIfNeeded(con, cancellationToken); //自動判斷是否建立非同步可取消連線

            var cmd = new CommandDefinition(
                bindSql,
                parameters: bindDp,
                commandType: CommandType.Text,
                commandTimeout: ConnectionTimeoutUserDefine ?? ConnectionTimeout,
                cancellationToken: cancellationToken);

            return await con.QueryAsync<TResult>(cmd).ConfigureAwait(false);

            //using (IDbConnection con = GetDbConnection(readOnlyConnection))
            //{
            //    return await con.QueryAsync<TResult>(bindSql, bindDp, null, ConnectionTimeoutUserDefine ?? ConnectionTimeout, CommandType.Text).ConfigureAwait(false);
            //}
        }

        /// <summary>
        /// ExecuteScalar 查詢第一列資料 
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="parameters">Parameter</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, object parameters = null)
        {
            //string conStr = HIS2_PUB.DecryptUtility.Instance.GetDecypConnectionString(defaulConnectStringName);
            //string conStr =  GetDecypConnectionString(defaulConnectStringName);
            string conStr = this.constr;
            OracleConnection oracleConn = new OracleConnection();
            try
            {
                using (oracleConn = new OracleConnection(conStr))
                {
                    return oracleConn.ExecuteScalar(sql, parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oracleConn.Close();
                oracleConn.Dispose();
            }
        }

        #region Query MAPPING
        /// <summary>
        /// Query Mapping 查詢資料 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="splitOn"></param>
        /// <param name="param"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TResult>> QueryMapping<T1, T2, TResult>(string sql,
            Func<T1, T2, TResult> map, string splitOn, object param = null, CancellationToken cancellationToken = default)
        {
            using var con = GetDbConnectionWithoutOpen(); //建立資料庫物件
            await OpenDbConnectionAsyncIfNeeded(con, cancellationToken).ConfigureAwait(false); //自動判斷是否建立非同步可取消連線
            return await con.QueryAsync<T1, T2, TResult>(sql, map, param, splitOn: splitOn);
        }
        /// <summary>
        /// Query Mapping 查詢資料
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="splitOn"></param>
        /// <param name="param"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TResult>> QueryMapping<T1, T2, T3, TResult>(string sql,
            Func<T1, T2, T3, TResult> map, string splitOn, object param = null, CancellationToken cancellationToken = default)
        {
            using var con = GetDbConnectionWithoutOpen(); //建立資料庫物件
            await OpenDbConnectionAsyncIfNeeded(con, cancellationToken).ConfigureAwait(false); //自動判斷是否建立非同步可取消連線
            return await con.QueryAsync<T1, T2, T3, TResult>(sql, map, param, splitOn: splitOn);
        }
        /// <summary>
        /// Query Mapping 查詢資料
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="splitOn"></param>
        /// <param name="param"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TResult>> QueryMapping<T1, T2, T3, T4, TResult>(string sql,
            Func<T1, T2, T3, T4, TResult> map, string splitOn, object param = null, CancellationToken cancellationToken = default)
        {
            using var con = GetDbConnectionWithoutOpen(); //建立資料庫物件
            await OpenDbConnectionAsyncIfNeeded(con, cancellationToken).ConfigureAwait(false); //自動判斷是否建立非同步可取消連線
            return await con.QueryAsync<T1, T2, T3, T4, TResult>(sql, map, param, splitOn: splitOn);
        }
        /// <summary>
        /// Query Mapping 查詢資料
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="splitOn"></param>
        /// <param name="param"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TResult>> QueryMapping<T1, T2, T3, T4, T5, TResult>(string sql,
            Func<T1, T2, T3, T4, T5, TResult> map, string splitOn, object param = null, CancellationToken cancellationToken = default)
        {
            using var con = GetDbConnectionWithoutOpen(); //建立資料庫物件
            await OpenDbConnectionAsyncIfNeeded(con, cancellationToken).ConfigureAwait(false); //自動判斷是否建立非同步可取消連線
            return await con.QueryAsync<T1, T2, T3, T4, T5, TResult>(sql, map, param, splitOn: splitOn);
        }

        #endregion

        #endregion  Query 系列

        #region Insert 系列

        /// <summary>
        /// 新增單筆或多筆資料
        /// </summary>
        /// <typeparam name="T">新增資料物件類型</typeparam>
        /// <param name="insertEntity">新增物件</param>
        /// <returns>The ID(primary key) of the newly inserted record if it is identity using the defined type, otherwise null</returns>
        public async Task<long> InsertDueToLongAsync<T>(IEnumerable<T> insertEntity)
            where T : class
        {
            BindInsert<T>(insertEntity, out string sql);
            using (IDbConnection con = GetDbConnection() as IDbConnection)
            {
                return await con.ExecuteAsync(sql, insertEntity, null, ConnectionTimeoutUserDefine ?? ConnectionTimeout, CommandType.Text).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// 批次執行（並不適用於Query）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd">Script 語法</param>
        /// <param name="oraParams">參數</param>
        /// <param name="props"></param>
        /// <param name="data"></param>
        private void InsertWithArrayBinding<T>(OracleCommand cmd,
            Dictionary<string, OracleParameter> oraParams,
            Dictionary<string, PropertyInfo> props,
            T[] data)
        {
            //// 測試資料時用
            //List<string> paramListString = new List<string>();
            cmd.ArrayBindCount = data.Length;
            cmd.Parameters.Clear();

            // 收集本批次建立的 temporary CLOB，於 ExecuteNonQuery 後釋放
            var tempClobs = new List<OracleClob>();
            try
            {
                foreach (var pn in oraParams.Keys)
                {
                    var p = oraParams[pn];

                    if (p.OracleDbType == OracleDbType.Clob)
                    {
                        // CLOB 欄位：array binding 必須使用 OracleClob[]，不可直接傳 string[]
                        // 否則文字超過 4000 byte 會觸發 ORA-01461 / ORA-01460
                        var clobs = new OracleClob[data.Length];
                        for (int i = 0; i < data.Length; i++)
                        {
                            var s = props[pn].GetValue(data[i])?.ToString();
                            if (s == null)
                            {
                                clobs[i] = null;
                            }
                            else
                            {
                                var clob = new OracleClob(cmd.Connection);
                                if (s.Length > 0)
                                {
                                    clob.Write(s.ToCharArray(), 0, s.Length);
                                }
                                clobs[i] = clob;
                                tempClobs.Add(clob);
                            }
                        }
                        p.Value = clobs;
                    }
                    else
                    {
                        p.Value = data.Select(o => props[pn].GetValue(o)).ToArray();
                    }

                    //paramListString.AddRange(data.Select(o => props[pn].GetValue(o)?.ToString() ?? string.Empty).ToList());
                    cmd.Parameters.Add(p);

                    //Console.WriteLine("---------------------------------------組資料---------------------------------------");
                    // CLOB 欄位（OracleClob）內含無法序列化的屬性（如 ReadTimeout），
                    // 直接 JsonConvert.SerializeObject 會丟 JsonSerializationException，
                    // 因此 CLOB 僅 dump 欄位名與長度資訊，其餘型別維持原本完整 dump。
                    if (p.OracleDbType == OracleDbType.Clob)
                    {
                        dumpDBCommand.AppendLine($"{{\"ParameterName\":\"{p.ParameterName}\",\"OracleDbType\":\"Clob\",\"ArrayCount\":{data.Length}}}");
                        var lens = ((OracleClob[])p.Value)
                            .Select(c => c == null ? -1L : c.Length)
                            .ToArray();
                        dumpDBCommand.AppendLine(JsonConvert.SerializeObject(lens));
                    }
                    else
                    {
                        dumpDBCommand.AppendLine(JsonConvert.SerializeObject(p));
                        dumpDBCommand.AppendLine(JsonConvert.SerializeObject(p.Value));
                    }
                    //Console.WriteLine("---------------------------------------組資料結束---------------------------------------");
                }
                //var convertScriptString = string.Join("','", paramListString);
                cmd.ExecuteNonQuery();
                dumpDBCommand.Clear();
            }
            finally
            {
                // 釋放 temporary CLOB，避免 server-side temp segment 累積
                foreach (var clob in tempClobs)
                {
                    try { clob?.Dispose(); }
                    catch { /* 忽略個別 LOB 釋放失敗 */ }
                }
            }
        }

        /// <summary>
        /// 批次寫入資料庫 (支援 CLOB 欄位，需於 entity 屬性加上 [Clob] attribute)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<int> ImportToOra<T>(IEnumerable<T> entities)
        {
            var tableName = typeof(T).Name;
            var userAtt = ((DBUserAttribute)typeof(T).GetCustomAttribute(typeof(DBUserAttribute), true))?.Name ?? defaultDBUser;

            // Nvarchar 欄位清單，後續更換判斷用
            var nvarcharList = new List<string>();

            var props = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            var propNames = props.Select(o => o.Name).ToArray();
            var propDict = props.ToDictionary(o => o.Name, o => o);
            var oraParams = props.ToDictionary(o => o.Name, o =>
            {
                OracleParameter p = new OracleParameter { ParameterName = o.Name };
                switch (o.PropertyType.ToString().Split('.').Last().TrimEnd(']'))
                {
                    case "String":
                        if (o.GetCustomAttribute(typeof(Clob), true) != null)
                        {
                            // CLOB 欄位：使用 OracleDbType.Clob，避免 VARCHAR2 4000 byte 上限
                            // 實際綁定值會在 InsertWithArrayBinding 內以 OracleClob[] 形式塞入
                            p.OracleDbType = OracleDbType.Clob;
                        }
                        else if (o.GetCustomAttribute(typeof(NVarchar), true) != null)
                        {
                            nvarcharList.Add(o.Name);
                            p.OracleDbType = OracleDbType.NVarchar2;
                            var changeCharacter = entities.ToList();
                            changeCharacter.ForEach(d =>
                            {
                                propDict[o.Name].SetValue(d, StringExtensions.CharacterToHex(propDict[o.Name].GetValue(d)?.ToString()));
                                
                            });
                            entities = changeCharacter;
                        }
                        else
                        {
                            p.DbType = DbType.String;
                        }
                        break;
                    case "DateTime":
                        p.DbType = DbType.DateTime;
                        //p.OracleDbType = OracleDbType.Date;
                        break;
                    case "Int32":
                        p.DbType = DbType.Int32;
                        break;
                    case "Int64":
                        p.DbType = DbType.Int64;
                        break;
                    case "Decimal":
                        p.DbType = DbType.Decimal;
                        break;
                    case "Single":
                        p.DbType = DbType.Single;
                        break;
                    case "Double":
                        p.DbType = DbType.Double;
                        break;
                    default:
                        throw new NotImplementedException(o.PropertyType.ToString());
                }
                return p;
            });

            string insertSql = $"Insert Into {userAtt}.{tableName} ({string.Join(",", propNames)}) Values ( {string.Join(" , ", propNames.Select(o => $":{o}").ToArray())} )";
            var count = 0;
            var sw = new Stopwatch();

            nvarcharList.ForEach(o =>
            {
                insertSql = insertSql.Replace($@" :{o} ", $@" UTL_RAW.cast_to_nvarchar2(:{o}) ");
            });

            using (var conn = GetDbConnection(false) as OracleConnection)//var cn = new OracleConnection(CnStr)
            {
                var cmd = conn.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandTimeout = ConnectionTimeoutUserDefine ?? ConnectionTimeout;
                cmd.CommandText = insertSql;
                OracleTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    sw.Start();
                    Console.WriteLine($"開始寫入資料 - {tableName}...{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss fff")}");

                    //foreach (var batchData in SplitBatch<T>(entities.Skip(63), 1))
                    foreach (var batchData in SplitBatch<T>(entities, BATCH_SIZE))
                    {
                        //Console.WriteLine(JsonConvert.SerializeObject(batchData));
                        count += batchData.Length;
                        var num = count - batchData.Length < 0 ? 0 : count - batchData.Length;
                        dumpDBCommand.AppendLine($"第{num}筆開始，寫入{batchData.Length}筆");
                        InsertWithArrayBinding<T>(cmd, oraParams, propDict, batchData);
                        Console.Write($"\r{count}/{entities.Count()}({count * 1.0 / entities.Count():p0})");
                    }
                    trans.Commit();
                    Console.WriteLine($"資料寫入完成 - {sw.ElapsedMilliseconds:n0}ms");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
                finally
                {
                    sw.Stop();
                }
            }
            return count;
        }

        /// <summary>
        /// 新增多筆資料 (CLOB欄位不可用)
        /// </summary>
        /// <typeparam name="T">資料物件類別</typeparam>
        /// <param name="entities">資料物件集合</param>
        /// <returns>新增資料筆數</returns>
        public async Task<int> BulkInsertAsync<T>(IEnumerable<T> entities)
        where T : class
        {
            int insertedRows = -1;
            int numb = entities.Count();
            if (entities.Count() >= 200)
            {
                var result = await ImportToOra(entities).ConfigureAwait(false);
                return result;
            }

            using (IDbConnection conn = GetDbConnection())
            {
                using (IDbTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        BindInsert(entities, out string sql);

                        insertedRows = await conn.ExecuteAsync(sql, entities, transaction, ConnectionTimeoutUserDefine ?? ConnectionTimeout).ConfigureAwait(false);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return insertedRows;
        }

        /// <summary>
        /// 新增多筆資料 (CLOB欄位可用)
        /// </summary>
        /// <typeparam name="T">資料物件類別</typeparam>
        /// <param name="entities">資料物件集合</param>
        /// <returns>新增資料筆數</returns>
        public async Task<int> BulkInsertAsyncCLOB<T>(IEnumerable<T> entities)
        where T : class
        {
            int numb = entities.Count();
            if (numb >= 200)
            {
                var result = await ImportToOra(entities).ConfigureAwait(false);
                return result;
            }

            using (var con = GetDbConnection(false) as OracleConnection)//var cn = new OracleConnection(CnStr)
            //using (IDbConnection con = GetDbConnection())
            {
                using (var transaction = con.BeginTransaction())// IsolationLevel.Serializable))
                {
                    try
                    {
                        for (int i = 0; i < numb; i++)
                        {
                            BindInsert(entities.Skip(i), out string sql, out DynamicParameters param, i);
                            con.Execute(sql, param, transaction, ConnectionTimeoutUserDefine ?? ConnectionTimeout);
                        }

                        transaction.Commit();
                        return numb;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        #endregion Insert 系列

        #region Update 系列
        /// <summary>
        /// 更新單筆資料(可自訂更新欄位與更新條件)
        /// </summary>
        /// <typeparam name="TDalModel">更新的 Dal Model Type</typeparam>
        /// <param name="updateInfo">更新的欄位名稱(kay)與資料(value)</param>
        /// <param name="conditionInfo">更新的欄位名稱(kay)與條件(value)</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync<TDalModel>(Dictionary<string, object> updateInfo, Dictionary<string, object> conditionInfo)
        {
            BindUpdate<TDalModel>(updateInfo, conditionInfo, out string sql, out DynamicParameters dynamicParameters);

            using (IDbConnection con = GetDbConnection())
            {
                return await con.ExecuteAsync(sql, dynamicParameters, null, ConnectionTimeoutUserDefine ?? ConnectionTimeout, CommandType.Text).ConfigureAwait(false) > 0;
            }
        }

        /// <summary>
        /// 更新單筆資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateRow"></param>
        /// <param name="conditionInfo"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync<T>(T updateRow, Dictionary<string, object> conditionInfo)
        {
            BindUpdate<T>(updateRow, conditionInfo, out string sql, out DynamicParameters dynamicParameters);

            using (IDbConnection con = GetDbConnection())
            {
                return await con.ExecuteAsync(sql, dynamicParameters, null, ConnectionTimeoutUserDefine ?? ConnectionTimeout, CommandType.Text).ConfigureAwait(false) > 0;
            }
        }

        /// <summary>
        /// 更新整批資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="conditionInfo"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync<T>(IEnumerable<T> entities, Dictionary<string, object> conditionInfo)
        {
            bool result = true;
            using (IDbConnection con = GetDbConnection())
            {
                using (var transaction = con.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        foreach (var row in entities)
                        {
                            BindUpdate<T>(row, conditionInfo, out string sql, out DynamicParameters dynamicParameters);

                            var exeResult = await con.ExecuteAsync(sql, dynamicParameters, transaction, ConnectionTimeoutUserDefine ?? ConnectionTimeout, CommandType.Text).ConfigureAwait(false) > 0;

                            if (exeResult == false)
                            {
                                result = false;
                                break;
                            }
                        }

                        if (result)
                        {
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return result;
        }
        #endregion Update 系列

        #region Bind 系列
        /// <summary>
        /// 新增資料（CLOB欄位不能用），建議選用有Parameter的Function
        /// </summary>
        /// <typeparam name="T">新增的Model</typeparam>
        /// <param name="insertInfo">新增的資料</param>
        /// <param name="sql">Bind完的SQL Script</param>
        public void BindInsert<T>(IEnumerable<T> insertInfo, out string sql)
        {
            IEnumerable<string> fields = typeof(T).GetProperties()
                .Where(p =>
                    p.CustomAttributes.All(a => a.AttributeType != typeof(KeyAttribute)
                        && a.AttributeType != typeof(ComputedAttribute)
                        && a.AttributeType != typeof(NoWrite)))
                .Select(p => p.Name); // 資料實體中的所有屬性(欄位)名稱、除了標有自訂屬性的欄位外

            var tableAtt = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
            var userAtt = ((DBUserAttribute)typeof(T).GetCustomAttribute(typeof(DBUserAttribute), true))?.Name ?? defaultDBUser;

            // Nvarchar 欄位清單，後續更換判斷用
            var nvarcharList = new List<string>();
            // SQL 語法
            var strSql = string.Empty;

            // default table name
            string tableName = "xxxx";
            if (tableAtt != null)
            {
                // 資料實體對應的資料表名稱;
                tableName = tableAtt.Name;
            }
            else
            {
                // class name
                tableName = typeof(T).Name;
            }

            var props = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            var propDict = props.ToDictionary(o => o.Name, o => o);
            var oraParams = props.ToDictionary(o => o.Name, o =>
            {
                OracleParameter p = new OracleParameter { ParameterName = o.Name };
                switch (o.PropertyType.ToString().Split('.').Last().TrimEnd(']'))
                {
                    case "String":
                        if (o.GetCustomAttribute(typeof(NVarchar), true) != null)
                        {
                            nvarcharList.Add(o.Name);
                            var changeCharacter = insertInfo.ToList();
                            changeCharacter.ForEach(d =>
                            {
                                propDict[o.Name].SetValue(d, StringExtensions.CharacterToHex(propDict[o.Name].GetValue(d)?.ToString()));

                            });
                            insertInfo = changeCharacter;
                        }
                        break;
                }
                return p;
            });

            string fieldNames = string.Join(", ", fields);
            string fieldParameters = string.Join(" , :", fields);
            strSql = $"INSERT INTO {userAtt}.{tableName}({fieldNames}) values( :{fieldParameters} )";

            nvarcharList.ForEach(o =>
            {
                strSql = strSql.Replace($@" :{o} ", $@" UTL_RAW.cast_to_nvarchar2(:{o}) ");
            });

            sql = strSql;
        }

        /// <summary>
        /// 新增單筆資料（CLOB欄位不可這組），最好選用有Parameter這組，目前試大量資料的話，一次建議只丟1000筆
        /// </summary>
        /// <typeparam name="T">新增的Model</typeparam>
        /// <param name="insertInfo">新增的資料</param>
        /// <param name="sql">Bind完的SQL Script</param>
        /// <param name="param">Bind完的參數</param>
        /// <param name="count">第幾筆</param>
        public void BindInsertNew<T>(IEnumerable<T> insertInfo, out string sql, out DynamicParameters param, int count = 0)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            List<string> columns = new List<string>();
            List<string> values = new List<string>();

            var tableAtt = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
            var userAtt = ((DBUserAttribute)typeof(T).GetCustomAttribute(typeof(DBUserAttribute), true))?.Name ?? defaultDBUser;

            // Nvarchar 欄位清單，後續更換判斷用
            var nvarcharList = new List<string>();
            // SQL 語法
            var strSql = string.Empty;

            // default table name
            string tableName = "xxxx";
            if (tableAtt != null)
            {
                // 資料實體對應的資料表名稱;
                tableName = tableAtt.Name;
            }
            else
            {
                // class name
                tableName = typeof(T).Name;
            }

            var props = typeof(T)
             .GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            var propNames = props.Select(o => o.Name).ToArray();
            var oraParams = props.ToDictionary(o => o.Name, o =>
            {
                var p = new OracleParameter();
                p.ParameterName = $"{o.Name}_{count}";
                switch (o.PropertyType.ToString().Split('.').Last().TrimEnd(']'))
                {
                    case "String":
                        p.DbType = DbType.String;
                        break;
                    case "DateTime":
                        p.DbType = DbType.DateTime;
                        break;
                    case "Int32":
                        p.DbType = DbType.Int32;
                        break;
                    case "Decimal":
                        p.DbType = DbType.Decimal;
                        break;
                    case "Single":
                        p.DbType = DbType.Single;
                        break;
                    case "Double":
                        p.DbType = DbType.Double;
                        break;
                    default:
                        throw new NotImplementedException(o.PropertyType.ToString());
                }
                return p;
            });

            foreach (var property in props)
            {
                // 檢查是否有 KeyAttribute 或 WriteAttribute 或 NoWrite 定義，有則排除，不組進SQL裡
                if (!property.IsDefined(typeof(KeyAttribute), true) &&
                    !property.IsDefined(typeof(WriteAttribute), true) &&
                    !property.IsDefined(typeof(NoWrite), true))
                {
                    columns.Add($"{property.Name}");
                    values.Add($":{property.Name}_{count}");

                    oraParams.TryGetValue(property.Name, out var oraParam);

                    switch (oraParam.DbType)
                    {
                        case DbType.Date:
                        case DbType.DateTime:
                        case DbType.DateTime2:
                        case DbType.DateTimeOffset:
                            dynamicParameters.Add($":{property.Name}_{count}", insertInfo.Select(x => ((DateTime?)property.GetValue(x))?.ToString("yyyy-MM-dd hh:mm:ss")).ToArray(), oraParam.DbType, ParameterDirection.Input);
                            //dynamicParameters.Add($":{property.Name}_{count}", insertInfo.Select(x => $"to_date({property.GetValue(x)}, "'yyyy-MM-dd HH24:MI:SS'")").ToArray(), oraParam.DbType,ParameterDirection.Input);
                            break;
                        case DbType.String:
                            if (property.GetCustomAttribute(typeof(NVarchar), true) != null)
                            {
                                nvarcharList.Add($"{property.Name}_{count}");
                                dynamicParameters.Add($":{property.Name}_{count}", StringExtensions.CharacterToHex(property.GetValue(insertInfo.FirstOrDefault())?.ToString()));
                            }
                            else
                            {
                                dynamicParameters.Add($":{property.Name}_{count}", insertInfo.Select(x => property.GetValue(x)).ToArray(), oraParam.DbType, ParameterDirection.Input);
                            }
                            break;
                        default:
                            dynamicParameters.Add($":{property.Name}_{count}", insertInfo.Select(x => property.GetValue(x)).ToArray(), oraParam.DbType, ParameterDirection.Input);
                            break;
                    }
                }
            }

            strSql = $"INSERT INTO {userAtt}.{tableName} ({string.Join(", ", columns)}) values({string.Join(", ", values)}) ";

            nvarcharList.ForEach(o =>
            {
                strSql = strSql.Replace($@" :{o} ", $@" UTL_RAW.cast_to_nvarchar2(:{o}) ");
            });

            sql = strSql;
            param = dynamicParameters;
        }

        /// <summary>
        /// 新增單筆資料（CLOB欄位應用這組）
        /// </summary>
        /// <typeparam name="T">新增的Model</typeparam>
        /// <param name="insertInfo">新增的資料</param>
        /// <param name="insertSql">Bind完的SQL Script</param>
        /// <param name="insertParam">Bind完的參數</param>
        /// <param name="count">第幾筆</param>
        /// <param name="ChangeColumnToSYSDATEList">組SQL時的VALUE{Column.Name,...} 將找到的ColumnName從:變數改成 SYSDATE</param>
        public void BindInsert<T>(T insertInfo, out string insertSql, out DynamicParameters insertParam, int count = 0, List<string> ChangeColumnToSYSDATEList = null)
        {
            IEnumerable<T> insertInfoList = new List<T>() { insertInfo };
            BindInsert_Logical(insertInfoList, out insertSql, out insertParam, count, ChangeColumnToSYSDATEList);
        }

        /// <summary>
        /// 新增單筆資料（CLOB欄位應用這組）(請用迴圈取，並於取完時候馬上執行Execute，於執行後再繼續取得)
        /// </summary>
        /// <typeparam name="T">新增的Model</typeparam>
        /// <param name="insertInfo">新增的資料</param>
        /// <param name="sql">Bind完的SQL Script</param>
        /// <param name="param">Bind完的參數</param>
        /// <param name="count">第幾筆</param>
        /// <param name="ChangeColumnToSYSDATEList">組SQL時的VALUE{Column.Name,...} 將找到的ColumnName從:變數改成 SYSDATE</param>
        public void BindInsert<T>(IEnumerable<T> insertInfo, out string sql, out DynamicParameters param, int count = 0, List<string> ChangeColumnToSYSDATEList = null)
        {
            BindInsert_Logical(insertInfo, out sql, out param, count);
        }

        /// <summary>
        /// 新增單筆資料（CLOB欄位應用這組）(請用迴圈取) 邏輯
        /// </summary>
        /// <typeparam name="T">新增的Model</typeparam>
        /// <param name="insertInfo">新增的資料</param>
        /// <param name="sql">Bind完的SQL Script</param>
        /// <param name="param">Bind完的參數</param>
        /// <param name="count">第幾筆</param>
        /// <param name="ColumnParamChangeToSYSDATEList">組SQL時的VALUE{Column.Name,...} 將找到的ColumnName從變數改成 SYSDATE</param>
        private void BindInsert_Logical<T>(IEnumerable<T> insertInfo, out string sql, out DynamicParameters param,
            int count = 0, List<string> ColumnParamChangeToSYSDATEList = null)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            List<string> columns = new List<string>();
            List<string> values = new List<string>();

            var tableAtt = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
            var userAtt = ((DBUserAttribute)typeof(T).GetCustomAttribute(typeof(DBUserAttribute), true))?.Name ?? defaultDBUser;

            // Nvarchar 欄位清單，後續更換判斷用
            var nvarcharList = new List<string>();
            // SQL 語法
            var strSql = string.Empty;

            // default table name
            string tableName = "xxxx";
            if (tableAtt != null)
            {
                // 資料實體對應的資料表名稱;
                tableName = tableAtt.Name;
            }
            else
            {
                // class name
                tableName = typeof(T).Name;
            }

            string no = count == 0 ? string.Empty : count.ToString();
            var props = typeof(T)
             .GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            var propNames = props.Select(o => o.Name).ToArray();
            //新增SYSDATE字典，當VALUE{Column1,Column2...} 中有Columns名稱與 ChangeColumnToSYSDATEList中相同，則將該變數改成 "SYSDATE"
            var ColumnToSysdateDic = new Dictionary<string, string>();
            if (ColumnParamChangeToSYSDATEList != null && ColumnParamChangeToSYSDATEList?.Any() is true)
            {
                foreach (var item in ColumnParamChangeToSYSDATEList)
                {
                    if (ColumnToSysdateDic.TryGetValue(item, out var changeColumns) == false)
                    {
                        ColumnToSysdateDic.Add(item, _SYSDATE_);
                    }
                }
            }
            foreach (var property in props)
            {
                // 檢查是否有 KeyAttribute 或 WriteAttribute 定義，有則排除，不組進SQL裡
                if (!property.IsDefined(typeof(KeyAttribute), true) &&
                    !property.IsDefined(typeof(WriteAttribute), true) &&
                    !property.IsDefined(typeof(NoWrite), true))
                {
                    columns.Add($"{property.Name}");
                    if (ColumnToSysdateDic.TryGetValue(property.Name, out var toSYSDATEColumn))
                    {
                        values.Add($"SYSDATE");
                    }
                    else
                    {
                        values.Add($":{property.Name}{no}");
                    }
                    
                    if (property.GetCustomAttribute(typeof(NVarchar), true) != null)
                    {
                        nvarcharList.Add($"{property.Name}{no}");
                        dynamicParameters.Add($":{property.Name}{no}", StringExtensions.CharacterToHex(property.GetValue(insertInfo.FirstOrDefault())?.ToString()));
                    }
                    else
                    {
                        
                        //dynamicParameters.Add($"{property.Name}{no}", insertInfo.Select(o => property.GetValue(o)).FirstOrDefault(), p.DbType);
                        dynamicParameters.Add($":{property.Name}{no}", property.GetValue(insertInfo.FirstOrDefault()));
                    }
                }
            }

            strSql = $"INSERT INTO {userAtt}.{tableName} ({string.Join(", ", columns)}) values( {string.Join(" , ", values)} ) ";

            nvarcharList.ForEach(o =>
            {
                strSql = strSql.Replace($@" :{o} ", $@" UTL_RAW.cast_to_nvarchar2(:{o}) ");
            });

            sql = strSql;
            param = dynamicParameters;
        }

        /// <summary>
        /// 更新資料(可自訂更新欄位與更新條件) [object可使用 DBUtil._SYSDATE_ 來指定該欄位使用SQL.SYSDATE語法]
        /// </summary>
        /// <typeparam name="TDalModel">更新的 Dal Model Type</typeparam>
        /// <param name="updateInfo">更新的欄位名稱(kay)與資料(value)</param>
        /// <param name="conditionInfo">更新的欄位名稱(kay)與條件(value)</param>
        /// <param name="sql">Bind完的SQL Script</param>
        /// <param name="parameters">Bind完的參數</param>
        /// <returns></returns>
        public void BindUpdate<TDalModel>(Dictionary<string, object> updateInfo, Dictionary<string, object> conditionInfo, out string sql, out DynamicParameters parameters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            List<string> updateProperties = new List<string>();
            List<string> conditionProperties = new List<string>();

            var modelType = typeof(TDalModel);
            var hasTableAttribute = modelType.IsDefined(typeof(TableAttribute), true);
            var tableName = hasTableAttribute ? ((TableAttribute)modelType.GetCustomAttributes(typeof(TableAttribute), true)[0]).Name : modelType.Name;

            bool hasUserAttribute = modelType.IsDefined(typeof(DBUserAttribute), true);
            string userName = hasUserAttribute ? ((DBUserAttribute)modelType.GetCustomAttributes(typeof(DBUserAttribute), true)[0]).Name : defaultDBUser;
            // TODO db型態 NVarchar2 的處理

            string SqlStrUpdate(KeyValuePair<string, object> item, string alias)
            {
                
                if (item.Value?.ToString() == _SYSDATE_)
                {
                    //直接更改組SQL語法，故不加入dynamicParameters中
                    return $"{item.Key} = SYSDATE";
                }
                else
                {
                    dynamicParameters.Add($"{alias}_{item.Key}", item.Value);
                    return $"{item.Key} = :{alias}_{item.Key}";
                }
            }

            string SqlStrWhere(KeyValuePair<string, object> item, string alias)
            {
                var sql = string.Empty;

                if (!(item.Value is string) && (item.Value is ValueTuple<DateTime, DateTime>))
                {
                    sql = $"{item.Key} Between :{alias}_{item.Key} And :{alias}_{item.Key}1";
                }
                else if (!(item.Value is string) && (item.Value is ValueTuple<DateTimeCompare, DateTime> ))
                {
                    var tupleValue = (ValueTuple<DateTimeCompare, DateTime>)item.Value;
                    var descriptionValue = tupleValue.Item1.GetEnumDescription();
                    sql = $"{item.Key} {descriptionValue} :{alias}_{item.Key} ";
                }
                else if (!(item.Value is string) && item.Value is IEnumerable)
                {
                    (List<string> keyProp, DynamicParameters keyValue, Dictionary<string, object> keyDic) resultList = (new List<string> { }, new DynamicParameters(), new Dictionary<string, object> { });

                    if (new Regex("string").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<object>);
                    }
                    else if (new Regex("datetime").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<DateTime>);
                    }
                    else if (new Regex("single").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Single>);
                    }
                    else if (new Regex("double").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Double>);
                    }
                    else if (new Regex("decimal").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Decimal>);
                    }
                    else if (new Regex("int").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Int32>);
                    }

                    sql = " ( " + string.Join(" Or ", resultList.keyProp) + " ) ";
                    dynamicParameters.AddDynamicParams(resultList.keyValue);
                }
                else
                {
                    if (item.Value is string && item.Value.ToString().Contains("%"))
                    {
                        sql = $"{item.Key} LIKE :{alias}_{item.Key}";
                    }
                    //else if (item.Value is string && item.Value?.ToString() == _SYSDATE_)
                    //{
                    //    sql = $"{item.Key} = SYSDATE";
                    //}
                    else if (item.Value == null)
                    {
                        sql = $"{item.Key} IS NULL";
                    }
                    else
                    {
                        sql = $"{item.Key} = :{alias}_{item.Key}";
                    }
                }

                if (!(item.Value is string) && (item.Value is ValueTuple<DateTime, DateTime>))
                {
                    var tupleValue = (ValueTuple<DateTime, DateTime>)item.Value;
                    dynamicParameters.Add($"{alias}_{item.Key}", tupleValue.Item1);
                    dynamicParameters.Add($"{alias}_{item.Key}1", tupleValue.Item2);
                }
                else if (!(item.Value is string) && (item.Value is ValueTuple<DateTimeCompare, DateTime>))
                {
                    var tupleValue = (ValueTuple<DateTimeCompare, DateTime>)item.Value;
                    dynamicParameters.Add($"{alias}_{item.Key}", tupleValue.Item2);
                }
                else if (!(item.Value is string) && item.Value is IEnumerable)
                {
                    // 上面已加入參數了
                }
                //else if (item.Value is string && item.Value?.ToString() == _SYSDATE_)
                //{
                //    // 直接在組SQL時候使用 專用語法，故此段不加入 dynamicParameters中
                //}
                else
                {
                    dynamicParameters.Add($"{alias}_{item.Key}", item.Value);
                }

                return sql;
            }

            updateProperties = updateInfo.Select(s => SqlStrUpdate(s, "set")).ToList();
            conditionProperties = conditionInfo.Select(s => SqlStrWhere(s, "key")).ToList();

            sql = $"Update {userName}.{tableName} {Environment.NewLine}Set {string.Join($"{Environment.NewLine}, ", updateProperties)} {Environment.NewLine} Where {string.Join($"{Environment.NewLine} And ", conditionProperties)}";
            parameters = dynamicParameters;
        }

        /// <summary>
        /// 更新資料(可自訂更新條件)  [object可使用常數_SYSDATE_來指定該欄位使用SQL SYSDATE語法]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateValue"></param>
        /// <param name="conditionInfo"></param>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        public void BindUpdate<T>(T updateValue, Dictionary<string, object> conditionInfo, out string sql, out DynamicParameters parameter)
        {
            Dictionary<string, object> updateInfo = new Dictionary<string, object>();

            var props = typeof(T)
             .GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            // TODO db型態 NVarchar2 的處理

            foreach (var property in props)
            {
                // 檢查是否有 KeyAttribute 或 WriteAttribute 定義，有則排除，不組進SQL裡
                if (!property.IsDefined(typeof(KeyAttribute), true) &&
                    !property.IsDefined(typeof(WriteAttribute), true))
                {
                    updateInfo.Add(property.Name, property.GetValue(updateValue));
                }
            }

            // 移除 Key的更新
            if (conditionInfo.Any())
            {
                foreach (var rowCondition in conditionInfo)
                {
                    if (updateInfo.TryGetValue(rowCondition.Key, out object value))
                    {
                        updateInfo.Remove(rowCondition.Key);
                    }
                }
            }

            this.BindUpdate<T>(updateInfo, conditionInfo, out sql, out parameter);
        }

        /// <summary>
        /// 刪除資料(可自訂刪除條件)
        /// </summary>
        /// <typeparam name="TDalModel">更新的 Dal Model Type</typeparam>
        /// <param name="conditionInfo">更新的欄位名稱(kay)與條件(value)</param>
        /// <param name="sql">Bind完的SQL Script</param>
        /// <param name="parameters">Bind完的參數</param>
        /// <returns></returns>
        public void BindDelete<TDalModel>(Dictionary<string, object> conditionInfo, out string sql, out DynamicParameters parameters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            List<string> conditionProperties = new List<string>();

            var modelType = typeof(TDalModel);
            var hasTableAttribute = modelType.IsDefined(typeof(TableAttribute), true);
            var tableName = hasTableAttribute ? ((TableAttribute)modelType.GetCustomAttributes(typeof(TableAttribute), true)[0]).Name : modelType.Name;

            bool hasUserAttribute = modelType.IsDefined(typeof(DBUserAttribute), true);
            string userName = hasUserAttribute ? ((DBUserAttribute)modelType.GetCustomAttributes(typeof(DBUserAttribute), true)[0]).Name : defaultDBUser;

            string SqlStrWhere(KeyValuePair<string, object> item, string alias)
            {
                var sql = string.Empty;

                if (!(item.Value is string) && (item.Value is ValueTuple<DateTime, DateTime>))
                {
                    sql = $"{item.Key} Between :{alias}_{item.Key} And :{alias}_{item.Key}1";
                }
                else if (!(item.Value is string) && (item.Value is ValueTuple<DateTimeCompare, DateTime>))
                {
                    var tupleValue = (ValueTuple<DateTimeCompare, DateTime>)item.Value;
                    var descriptionValue = tupleValue.Item1.GetEnumDescription();
                    sql = $"{item.Key} {descriptionValue} :{alias}_{item.Key} ";
                }
                else if (!(item.Value is string) && item.Value is IEnumerable)
                {
                    (List<string> keyProp, DynamicParameters keyValue, Dictionary<string, object> keyDic) resultList = (new List<string> { }, new DynamicParameters(), new Dictionary<string, object> { });

                    if (new Regex("string").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<object>);
                    }
                    else if (new Regex("datetime").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<DateTime>);
                    }
                    else if (new Regex("single").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Single>);
                    }
                    else if (new Regex("double").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Double>);
                    }
                    else if (new Regex("decimal").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Decimal>);
                    }
                    else if (new Regex("int").IsMatch(item.Value.GetType().FullName.ToLower()))
                    {
                        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Int32>);
                    }

                    //switch (item.Value.GetType().FullName.Split('[').Last().Split(',').First().Split('.').Last())
                    //{

                    //    case "DateTime":
                    //        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<DateTime>);
                    //        break;
                    //    case "String":
                    //        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<object>);
                    //        break;
                    //    case "Int32":
                    //        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Int32>);
                    //        break;
                    //    case "Decimal":
                    //        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Decimal>);
                    //        break;
                    //    case "Single":
                    //        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Single>);
                    //        break;
                    //    case "Double":
                    //        resultList = ConvertCompose(item.Key, item.Value as IEnumerable<Double>);
                    //        break;
                    //}

                    sql = " ( " + string.Join(" Or ", resultList.keyProp) + " ) ";
                    dynamicParameters.AddDynamicParams(resultList.keyValue);
                    //sql = $"{item.Key} IN :{alias}_{item.Key}";
                }
                else
                {
                    if (item.Value is string && item.Value.ToString().Contains("%"))
                    {
                        sql = $"{item.Key} LIKE :{alias}_{item.Key}";
                    }
                    else if (item.Value is string && item.Value.ToString().Equals("!Null"))
                    {
                        sql = $"{item.Key} Is Not Null";
                    }
                    else if (item.Value is string && item.Value.ToString().Contains("!"))
                    {
                        sql = $"{item.Key} <> :{alias}_{item.Key}";
                    }
                    else if (item.Value == null)
                    {
                        sql = $"{item.Key} IS NULL";
                    }
                    else
                    {
                        sql = $"{item.Key} = :{alias}_{item.Key}";
                    }
                }

                if (!(item.Value is string) && (item.Value is ValueTuple<DateTime, DateTime>))
                {
                    var tupleValue = (ValueTuple<DateTime, DateTime>)item.Value;
                    dynamicParameters.Add($"{alias}_{item.Key}", tupleValue.Item1);
                    dynamicParameters.Add($"{alias}_{item.Key}1", tupleValue.Item2);
                }
                else if (!(item.Value is string) && (item.Value is ValueTuple<DateTimeCompare, DateTime>))
                {
                    var tupleValue = (ValueTuple<DateTimeCompare, DateTime>)item.Value;
                    dynamicParameters.Add($"{alias}_{item.Key}", tupleValue.Item2);
                }
                else if (!(item.Value is string) && item.Value is IEnumerable)
                {
                    // 上面已加入參數了
                }
                else if (item.Value is string && item.Value.ToString().Contains("!"))
                {
                    dynamicParameters.Add($"{alias}_{item.Key}", item.Value.ToString().Replace("!", string.Empty));
                }
                else
                {
                    dynamicParameters.Add($"{alias}_{item.Key}", item.Value);
                }

                return sql;
            }

            conditionProperties = conditionInfo.Select(s => SqlStrWhere(s, "key")).ToList();

            sql = $"Delete {userName}.{tableName} Where {string.Join($"{Environment.NewLine} And ", conditionProperties)}";

            if (conditionProperties.Any() == false)
            {
                sql = sql.Replace(" Where ", string.Empty);
            }

            parameters = dynamicParameters;
        }

        /// <summary>
        /// 移動資料(可自訂移動條件)
        /// 回饋新增及刪除語法
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="sourceModel"></param>
        /// <param name="targetModel"></param>
        /// <param name="conditionInfo"></param>
        /// <param name="sqlInsertInto"></param>
        /// <param name="sqlDelete"></param>
        /// <param name="parameters"></param>
        public void BindMove<TSource, TTarget>(TSource sourceModel, TTarget targetModel, Dictionary<string, object> conditionInfo, out string sqlInsertInto, out string sqlDelete, out DynamicParameters parameters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            List<string> columns = new List<string>();
            string tableNameSource = "xxxx";
            string tableNameTarget = "xxxx";
            string strCondition = string.Empty;

            var tableAttSource = (TableAttribute)typeof(TSource).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
            var userAttSource = ((DBUserAttribute)typeof(TSource).GetCustomAttribute(typeof(DBUserAttribute), true))?.Name ?? defaultDBUser;

            var tableAttTarget = (TableAttribute)typeof(TTarget).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
            var userAttTarget = ((DBUserAttribute)typeof(TTarget).GetCustomAttribute(typeof(DBUserAttribute), true))?.Name ?? defaultDBUser;

            // default table name
            if (tableAttSource != null)
            {
                // 資料實體對應的資料表名稱;
                tableNameSource = tableAttSource.Name;
            }
            else
            {
                // class name
                tableNameSource = typeof(TSource).Name;
            }
            // default table name
            if (tableAttTarget != null)
            {
                // 資料實體對應的資料表名稱;
                tableNameTarget = tableAttTarget.Name;
            }
            else
            {
                // class name
                tableNameTarget = typeof(TSource).Name;
            }

            // 取來源Model的全欄位
            var propsSource = typeof(TSource)
             .GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            // 取目標Model的全欄位
            var propsTarget = typeof(TTarget)
             .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach(var prop in propsSource)
            {
                var propTarget = propsTarget.FirstOrDefault(o => o.Name == prop.Name);
                // 來源 及 目標 欄位 名稱一致且 型態一致，即可抄錄
                if (propTarget != null && prop.PropertyType == propTarget.PropertyType)
                {
                    columns.Add(prop.Name);
                }
            }

            BindDelete<TSource>(conditionInfo, out sqlDelete, out dynamicParameters);

            if (sqlDelete.IndexOf("Where")>=0)
            {
                strCondition = sqlDelete.Substring(sqlDelete.IndexOf("Where"));
            }

            sqlInsertInto = $@"Insert Into {userAttTarget}.{tableNameTarget} ({string.Join(", ", columns)})
                        Select {string.Join(", ", columns)}
                        From {userAttSource}.{tableNameSource}
                        {strCondition}
                        ";

            parameters = dynamicParameters;
        }

        /// <summary>
        /// 查詢資料 回傳SQL與DynamicParameters
        /// (keyEntity的name請使用nameof，若想使用like則在Value內使用%，則自動轉換為Like, 若value為陣列則自動轉換為IN, 大於1千筆會自動轉換（但大於一萬筆，會壞掉，請自行切割）, 若value為DateTime則條件自動為大於等於, 若value為!Null則條件自動為Not Null, 若value為!Y則條件自動為 &lt;&gt; 'Y')
        /// </summary>
        /// <typeparam name="TResult">資料封裝的物件類型</typeparam>
        /// <param name="ParamDictoionary">Where的物件</param>
        /// <param name="BindSql">輸出SQL</param>
        /// <param name="BindParameters">輸出DynamicParameters</param>
        /// <returns></returns>
        public void BindQuery<TResult>(Dictionary<string, object> ParamDictoionary, out string BindSql,
            out DynamicParameters BindParameters)
            where TResult : new()
        {
            DynamicParameters keyEntity = new DynamicParameters();
            if (ParamDictoionary != null)
            {
                foreach (var item in ParamDictoionary)
                {
                    keyEntity.Add(item.Key, item.Value);
                }
            }
            BindQuery<TResult>(keyEntity, out var bindSql, out var bindDp);

            BindSql = bindSql;
            BindParameters = bindDp;

        }

        /// <summary>
        /// 查詢資料 回傳SQL與DynamicParameters
        /// (keyEntity的name請使用nameof，若想使用like則在Value內使用%，則自動轉換為Like, 若value為陣列則自動轉換為IN, 大於1千筆會自動轉換（但大於一萬筆，會壞掉，請自行切割）, 若value為DateTime則條件自動為大於等於, 若value為!Null則條件自動為Not Null, 若value為!Y則條件自動為 &lt;&gt; 'Y')
        /// </summary>
        /// <typeparam name="TResult">資料封裝的物件類型</typeparam>
        /// <param name="keyEntity">Where的物件</param>
        /// <param name="BindSql">輸出SQL</param>
        /// <param name="BindParameters">輸出DynamicParameters</param>
        /// <returns></returns>
        public void BindQuery<TResult>(DynamicParameters keyEntity , out string BindSql, out DynamicParameters BindParameters)
            where TResult : new()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            List<string> keyProperties = new List<string>();
            string querySql = string.Empty;

            Type modelType = typeof(TResult);
            bool hasTableAttribute = modelType.IsDefined(typeof(TableAttribute), true);
            string tableName = hasTableAttribute ? ((TableAttribute)modelType.GetCustomAttributes(typeof(TableAttribute), true)[0]).Name : modelType.Name;
            bool hasUserAttribute = modelType.IsDefined(typeof(DBUserAttribute), true);
            string userName = hasUserAttribute ? ((DBUserAttribute)modelType.GetCustomAttributes(typeof(DBUserAttribute), true)[0]).Name : defaultDBUser;

            //List<string> queryProperties = (from entityMember in new TResult().GetType().GetProperties() where !entityMember.IsDefined(typeof(WriteAttribute), true) select entityMember.Name).ToList();
            List<string> queryProperties = (from entityMember in new TResult().GetType().GetProperties()
                                            where !entityMember.IsDefined(typeof(WriteAttribute), true) &&
                                                  !entityMember.IsDefined(typeof(NoSelect), true)
                                            select entityMember.Name).ToList();

            querySql += $"SELECT {string.Join($"{Environment.NewLine}, ", queryProperties)} {Environment.NewLine}FROM {userName}.{tableName} ";

            if (keyEntity != null && keyEntity.ParameterNames.Any())
            {
                var parametersLookup = (SqlMapper.IParameterLookup)keyEntity;

                foreach (var keyentityParameterName in keyEntity.ParameterNames)
                {
                    var pValue = parametersLookup[keyentityParameterName];
                    if (!(pValue is string) && (pValue is ValueTuple<DateTime, DateTime>))
                    {
                        keyProperties.Add($"{keyentityParameterName} Between :key_{keyentityParameterName} And :key_{keyentityParameterName}1");
                    }
                    else if (!(pValue is string) && (pValue is ValueTuple<DateTimeCompare, DateTime>))
                    {
                        var tupleValue = (ValueTuple<DateTimeCompare, DateTime>)pValue;
                        var descriptionValue = tupleValue.Item1.GetEnumDescription();
                        keyProperties.Add($"{keyentityParameterName} {descriptionValue} :key_{keyentityParameterName} ");
                    }
                    else if (!(pValue is string) && (pValue is ValueTuple<DateTimeCompare, string>))
                    {//
                        var tupleValue = (ValueTuple<DateTimeCompare, string>)pValue;
                        var descriptionValue = tupleValue.Item1.GetEnumDescription();
                        if (tupleValue.Item2 == _SYSDATE_)
                        {
                            keyProperties.Add($"{keyentityParameterName} {descriptionValue} SYSDATE ");
                        }
                        else
                        {
                            keyProperties.Add($"{keyentityParameterName} {descriptionValue} :key_{keyentityParameterName} ");
                        }
                    }
                    else if (!(pValue is string) && pValue is IEnumerable)
                    {

                        (List<string> keyProp, DynamicParameters keyValue, Dictionary<string, object> keyDic) resultList = (new List<string> { }, new DynamicParameters(), new Dictionary<string, object> { });

                        if (new Regex("int32").IsMatch(pValue.GetType().BaseType.FullName.ToLower()))
                        {
                            resultList =  ConvertCompose(keyentityParameterName, pValue as IEnumerable<Int32>);
                        }
                        else if (new Regex("string").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<object>);
                        }
                        else if (new Regex("datetime").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<DateTime>);
                        }
                        else if (new Regex("single").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Single>);
                        }
                        else if (new Regex("double").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Double>);
                        }
                        else if (new Regex("decimal").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Decimal>);
                        }
                        else if (new Regex("int").IsMatch(pValue.GetType().FullName.ToLower()))
                        {
                            resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Int32>);
                        }
                        //switch (pValue.GetType().FullName.Split('[').Last().Split(',').First().Split('.').Last())
                        //{

                        //    case "DateTime":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<DateTime>);
                        //        break;
                        //    case "String":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<object>);
                        //        break;
                        //    case "Int16":
                        //    case "Int32":
                        //    case "Int64":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Int32>);
                        //        break;
                        //    case "Decimal":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Decimal>);
                        //        break;
                        //    case "Single":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Single>);
                        //        break;
                        //    case "Double":
                        //        resultList = ConvertCompose(keyentityParameterName, pValue as IEnumerable<Double>);
                        //        break;
                        //}

                        keyProperties.Add(" ( " + string.Join(" Or ", resultList.keyProp) + " ) ");
                        dynamicParameters.AddDynamicParams(resultList.keyValue);

                        //keyProperties.Add($"{keyentityParameterName} IN :key_{keyentityParameterName}");
                    }
                    else if (!(pValue is string) && pValue is DateTime)
                    {
                        keyProperties.Add($"{keyentityParameterName} = :key_{keyentityParameterName}");
                    }
                    else if (!(pValue is string) && pValue == null)
                    {
                        keyProperties.Add($"{keyentityParameterName} IS NULL");
                    }
                    else if (!(pValue is string) && pValue is Regex)
                    {
                        keyProperties.Add($"RegexP_Like({keyentityParameterName}, '{(pValue as Regex).ToString()}' )");
                    }
                    else
                    {
                        switch (pValue)
                        {
                            case string _ when pValue.ToString().Contains("%"):
                                keyProperties.Add($"{keyentityParameterName} LIKE :key_{keyentityParameterName}");
                                break;
                            case string _ when pValue.ToString().Equals("!Null"):
                                keyProperties.Add($"{keyentityParameterName} IS Not NULL");
                                break;
                            case string _ when pValue.ToString().Contains("!"):
                                keyProperties.Add($"{keyentityParameterName} <> :key_{keyentityParameterName}");
                                pValue = pValue.ToString().Replace("!", string.Empty);
                                break;
                            default:
                                keyProperties.Add($"{keyentityParameterName} = :key_{keyentityParameterName}");
                                break;
                        }
                    }

                    if (!(pValue is string) && (pValue is ValueTuple<DateTime, DateTime>))
                    {
                        var tupleValue = (ValueTuple<DateTime, DateTime>)pValue;
                        dynamicParameters.Add("key_" + keyentityParameterName, tupleValue.Item1);
                        dynamicParameters.Add("key_" + keyentityParameterName + "1", tupleValue.Item2);
                    }
                    else if (!(pValue is string) && (pValue is ValueTuple<DateTimeCompare, DateTime>))
                    {
                        var tupleValue = (ValueTuple<DateTimeCompare, DateTime>)pValue;
                        dynamicParameters.Add("key_" + keyentityParameterName, tupleValue.Item2);
                        //dynamicParameters.Add("key_" + keyentityParameterName, $@"to_date('{tupleValue.Item2.ToString("yyyyMMddHHmmss")}', 'yyyyMMddHH24MIss')");
                    }
                    else if (!(pValue is string) && (pValue is ValueTuple<DateTimeCompare, string>))
                    {//
                        //var tupleValue = (ValueTuple<DateTimeCompare, string>)pValue;
                        //dynamicParameters.Add("key_" + keyentityParameterName, tupleValue.Item2);
                    }
                    else if (!(pValue is string)
                        && (pValue is IEnumerable || pValue is Regex))
                    {
                        // 上面已加入參數了
                    }
                    else
                    {
                        dynamicParameters.Add("key_" + keyentityParameterName, pValue);
                    }
                }

                querySql += $"{Environment.NewLine} WHERE {string.Join($"{Environment.NewLine} AND ", keyProperties)} ";
            }

            BindParameters = dynamicParameters;
            BindSql = querySql;
        }

        #endregion Bind 系列

        #region Execute 系列
        /// <summary>
        /// 執行交易 query
        /// </summary>
        /// <param name="taskList">任務清單</param>
        /// <returns></returns>
        public bool ExecuteTransactionQuery(params Action<OracleConnection, OracleTransaction>[] taskList)
        //public bool ExecuteTransactionQuery(params Action<IDbConnection, IDbTransaction>[] taskList)
        {
            using (OracleConnection con = GetDbConnection(false) as OracleConnection)//var cn = new OracleConnection(CnStr)
            //using (IDbConnection con = GetDbConnection())
            {
                using (OracleTransaction transaction = con.BeginTransaction())// IsolationLevel.Serializable))
                {
                    try
                    {
                        var ss = 0;
                        foreach (Action<OracleConnection, OracleTransaction> act in taskList)
                        {
                            act(con, transaction);
                            ss++;
                        }
                        // 2024.02.21 By Piper
                        // 故意留下的檢查，有些需求是中間去檢查資料，異常的話，會RollBack前面執行的，且取消後面的執行
                        // 在中間下了RollBack之後，Connection竟然順道被關掉了
                        if (transaction.Connection != null)
                        {
                            transaction.Commit();
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (transaction.Connection != null)
                        {
                            transaction.Rollback();
                        }
                        else
                        {
                            throw new Exception("DB連線已被關閉。");
                        }
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 執行用(INSERT、UPDATE、DELETE)
        /// </summary>
        /// <param name="sql"></param>
        public void excute(string sql)
        {
            //string constr = HIS2_PUB.DecryptUtility.Instance.GetDecypConnectionString(defaulConnectStringName);
            //string constr =  GetDecypConnectionString(defaulConnectStringName);
            try
            {
                using (OracleConnection oracleConn = new OracleConnection(constr))
                {
                    oracleConn.Execute(sql);
                    oracleConn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Execute 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns>int</returns>
        public int Execute(string sql, object parameters = null)
        {
            //string constr = HIS2_PUB.DecryptUtility.Instance.GetDecypConnectionString(defaulConnectStringName);
            //string constr = GetDecypConnectionString(defaulConnectStringName); ;
            IDbConnection oracleConn = null;
            IDbTransaction _trans = null;
            int row = 0;
            try
            {
                using (oracleConn = new OracleConnection(constr))
                {
                    oracleConn.Open();
                    using (_trans = oracleConn.BeginTransaction())
                    {
                        row = oracleConn.Execute(sql, parameters, _trans);
                        _trans.Commit();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _trans.Dispose();
                oracleConn.Close();
                oracleConn.Dispose();
            }

            return row;
        }

        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            return await ExecuteAsync(sql, parameters, ConnectionTimeout);

            //IDbConnection oracleConn = null;
            //Task<int> result = null;
            //try
            //{
            //    using (oracleConn = new OracleConnection(constr))
            //    {
            //        oracleConn.Open();
            //        result = oracleConn.ExecuteAsync(sql, parameters);
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally
            //{
            //    oracleConn.Close();
            //    oracleConn.Dispose();
            //}
            //return await result;
        }

        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, object parameters = null, int timeout = 20)
        {
            IDbConnection oracleConn = null;
            Task<int> result = null;
            try
            {
                using (oracleConn = new OracleConnection(constr))
                {
                    oracleConn.Open();
                    result = oracleConn.ExecuteAsync(sql, parameters, commandTimeout: timeout);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oracleConn.Close();
                oracleConn.Dispose();
            }
            return await result;
        }

        #endregion Execute 系列

        #region GetClass  
        /// <summary>
        /// Dictionary To Class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        /// <returns></returns>
        public T GetClass<T>(Dictionary<string, object> dict)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);
            foreach (var kv in dict)
            {
                switch (type.GetProperty(kv.Key).PropertyType.ToString().Split('.').Last().TrimEnd(']'))
                {
                    case "String":
                        type.GetProperty(kv.Key).SetValue(obj, kv.Value.ToString().Trim());
                        break;
                    default:
                        type.GetProperty(kv.Key).SetValue(obj, kv.Value);
                        break;
                }
            }
            return (T)obj;
        }
        #endregion GetClass

        #region Public Function
        /// <summary>
        /// 分割清單
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="batchSize"></param>
        /// <returns></returns>
        public IEnumerable<T[]> SplitBatch<T>(IEnumerable<T> items, int batchSize)
        {
            return items.Select((item, idx) => new { item, idx })
                .GroupBy(o => o.idx / batchSize)
                .Select(o => o.Select(p => p.item).ToArray());
        }

        /// <summary>
        /// 將 語法 In 後面的清單拆成最多1000個一組
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propName">參數的名稱</param>
        /// <param name="prop">參數的清單</param>
        /// <returns></returns>
        public (List<string> keyProp, DynamicParameters keyValue, Dictionary<string, object> keyDic) ConvertCompose<T>(string propName, IEnumerable<T> prop)
        {
            var list = new List<string>();
            var para = new DynamicParameters();
            var dic = new Dictionary<string, object>();

            int count = 1;
            foreach (var row in SplitBatch<T>(prop, 1000))
            {
                list.Add($"{propName} IN :key_{propName}_{count}");
                para.Add($"key_{propName}_{count}", row);
                dic.Add($"key_{propName}_{count}", row);
                count++;
            }

            return (list, para, dic);
        }

        /// <summary>
        /// 將 語法 In 後面的清單拆成最多1000個一組[當總物件超過10000筆以上專用]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propName">參數的名稱</param>
        /// <param name="prop">參數的清單</param>
        /// <returns></returns>
        public List<(List<string> keyProp, DynamicParameters keyValue, Dictionary<string, object> keyDic)> ConvertComposeAndItemOver10000<T>(string propName, IEnumerable<T> prop)
        {
            var list = new List<string>();
            var para = new DynamicParameters();
            var dic = new Dictionary<string, object>();
            List<(List<string> keyProp, DynamicParameters keyValue, Dictionary<string, object> keyDic)> result =
                new List<(List<string> keyProp, DynamicParameters keyValue, Dictionary<string, object> keyDic)>(); 
            int count = 1;
            foreach (var row in SplitBatch<T>(prop, 1000))
            {
                if (count % 10 == 0)
                {
                    list.Add($"{propName} IN :key_{propName}_{count}");
                    para.Add($"key_{propName}_{count}", row);
                    dic.Add($"key_{propName}_{count}", row);
                    result.Add((list, para, dic));
                    list = new List<string>();
                    para = new DynamicParameters();
                    dic = new Dictionary<string, object>();
                }
                else
                {
                    list.Add($"{propName} IN :key_{propName}_{count}");
                    para.Add($"key_{propName}_{count}", row);
                    dic.Add($"key_{propName}_{count}", row);
                }
                count++;
            }

            if (list?.Any() is true)
            {
                result.Add((list, para, dic));
            }

            
            
            return result;
        }
        #endregion Public Function

        #region Query Table Schema Property
        /// <summary>t
        /// 查詢TableSchema相關屬性名稱長度等,並使用&lt;HIS2.SQL_Model.DBModel.ORACLE_TABLE_SCHEMA || HIS2.CoreBase.DB.ORACLE_TABLE_SCHEMA&gt;接回資料
        /// </summary>
        /// <param name="TableName">名稱</param>
        /// <param name="TableOwner">擁有者(不給值時預設為HIS2USER2)</param>
        /// <returns>可使用IEnumerable&lt;HIS2.SQL_Model.DBModel.ORACLE_TABLE_SCHEMA&gt;來接回資料</returns>
        public async Task<IEnumerable<TResult>> QueryTableSchema<TResult>(string TableName, string TableOwner = null)
            where TResult : new()
        {
            try
            {
                IEnumerable<TResult> ReturnResult = null;
                if(TableOwner == null)
                {
                    TableOwner = defaultDBUser;
                }
                if (string.IsNullOrWhiteSpace(TableName))
                {
                    return ReturnResult;
                }
                
                var querySql = @"SELECT
  C.OWNER
, C.TABLE_NAME
, C.COLUMN_ID
, C.COLUMN_NAME
, C.DATA_TYPE
, C.DATA_LENGTH
, C.CHAR_LENGTH
, C.DATA_PRECISION
, C.DATA_DEFAULT
, C.NULLABLE
, D.COMMENTS
FROM
  ALL_TAB_COLUMNS C
  JOIN ALL_COL_COMMENTS D ON C.TABLE_NAME = D.TABLE_NAME AND C.COLUMN_NAME =  D.COLUMN_NAME
WHERE
  C.OWNER =:OWNER AND C.TABLE_NAME =:TABLE_NAME 
ORDER BY C.TABLE_NAME, C.COLUMN_ID";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("TABLE_NAME", TableName?.ToUpper());
                dynamicParameters.Add("OWNER", TableOwner);
                
                using (IDbConnection con = GetDbConnection(true))
                {
                    return await con.QueryAsync<TResult>(querySql, dynamicParameters, null, ConnectionTimeoutUserDefine ?? ConnectionTimeout, CommandType.Text).ConfigureAwait(false);
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Combine TableName SQL 
        /// </summary>
        /// <typeparam name="TResult">Model</typeparam>
        /// <returns> [Owner].[TableName] => HIS2USER2.REG, 失敗回傳String.Empty </returns>
        public ServiceResult<string> GetTableName<TResult>()
        {
            ServiceResult<string> returnResult = new ServiceResult<string>(false, string.Empty, string.Empty);
            string tableName = string.Empty;
            string userName = string.Empty;
            try
            {
                Type modelType = typeof(TResult);
                bool hasTableAttribute = modelType.IsDefined(typeof(TableAttribute), true);
                tableName = hasTableAttribute ? ((TableAttribute)modelType.GetCustomAttributes(typeof(TableAttribute), true)[0]).Name : modelType.Name;
                bool hasUserAttribute = modelType.IsDefined(typeof(DBUserAttribute), true);
                userName = hasUserAttribute ? ((DBUserAttribute)modelType.GetCustomAttributes(typeof(DBUserAttribute), true)[0]).Name : defaultDBUser;
                returnResult.Data = userName + "." + tableName;
                returnResult.IsOk = true;
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Data = string.Empty;
            }
            return returnResult;
        }

        /// <summary>
        /// Combine Table Column Name SQL 
        /// </summary>
        /// <typeparam name="TResult">Model</typeparam>
        /// <param name="PreFixName">前綴修飾詞 [PreFixName.Column] => R.RID</param>
        /// <returns> [Column1],[Column2]...  , 失敗回傳String.Empty </returns>
        public ServiceResult<string> GetTableColumnName<TResult>(string PreFixName = null) where TResult : new()
        {
            ServiceResult<string> returnResult = new ServiceResult<string>(false, string.Empty, string.Empty);
            try
            {
                List<string> queryProperties = (from entityMember in new TResult().GetType().GetProperties()
                    where !entityMember.IsDefined(typeof(WriteAttribute), true) &&
                          !entityMember.IsDefined(typeof(NoSelect), true)
                    select entityMember.Name)?.ToList();
                if (!string.IsNullOrWhiteSpace(PreFixName))
                {
                    queryProperties = (from item in queryProperties
                                       select PreFixName + "." + item).ToList();
                }
                if (queryProperties?.Any() is true)
                {
                    returnResult.Data = string.Join(",", queryProperties);
                    returnResult.IsOk = true;
                }
                else
                {
                    returnResult.Message += "Model轉換陣列中無任一元素存在!";
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Data = string.Empty;
            }
            return returnResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="TableName"></param>
        /// <param name="TableOwner"></param>
        /// <param name="OBJECT_TYPE"> "OBJECT_TYPE" IN ('SEQUENCE', 'PROCEDURE', 'TABLE', 'INDEX', 'FUNCTION', 'VIEW', 'TYPE') </param>
        /// <returns>可使用IEnumerable &lt;HIS2.SQL_Model.DBModel.ORACLE_TABLE_SCHEMA.AllTableInfo &gt;來接回資料</returns>
        public ServiceResult<IEnumerable<TResult>> GetTableInfoList<TResult>(string TableName, string TableOwner = "HIS2USER2", string OBJECT_TYPE = "TABLE") where TResult : new()
        {
            ServiceResult<IEnumerable<TResult>> returnResult = new ServiceResult<IEnumerable<TResult>>(false, string.Empty, default);
            try
            {
                if (!string.IsNullOrWhiteSpace(TableName))
                {
                    var querySql = @"select ALT.OWNER, ALT.TABLE_NAME, ALT.STATUS, ALT.NUM_ROWS, ALO.OBJECT_TYPE, ALO.CREATED from ALL_TABLES ALT 
LEFT JOIN ALL_OBJECTS ALO ON ALO.OWNER = ALT.OWNER AND ALO.OBJECT_NAME = ALT.TABLE_NAME
WHERE ALT.OWNER =:OWNER
AND ALT.TABLE_NAME like :TABLE_NAME ";
                    DynamicParameters dynamicParameters = new DynamicParameters();

                    dynamicParameters.Add("TABLE_NAME", TableName?.ToUpper());
                    if (string.IsNullOrWhiteSpace(TableOwner))
                    {
                        TableOwner = "HIS2USER2";
                    }
                    dynamicParameters.Add("OWNER", TableOwner);

                    if (!string.IsNullOrWhiteSpace(OBJECT_TYPE))
                    {
                        querySql += " AND ALO.OBJECT_TYPE =:OBJECT_TYPE";
                        dynamicParameters.Add("OBJECT_TYPE", OBJECT_TYPE);
                    }
                    
                    using (IDbConnection con = GetDbConnection(true))
                    {
                        returnResult.Data = con.QueryAsync<TResult>(querySql, dynamicParameters, null, ConnectionTimeoutUserDefine ?? ConnectionTimeout, CommandType.Text)
                            .Result;
                    }

                    returnResult.IsOk = true;
                    returnResult.Message += "查詢成功!";
                }
                else
                {
                    returnResult.Message += "未輸入查詢Table名稱";
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
            }
            return returnResult;
        }
        /// <summary>
        /// 轉換DB Table Schema To Dictionary
        /// </summary>
        /// <param name="SchemaList"></param>
        /// <returns></returns>
        public ServiceResult<Dictionary<string, (Type, object Value, string DisplayName)>> ConvertTableSchemaToDictionary(
            IEnumerable<ORACLE_TABLE_SCHEMA> SchemaList)
        {
            ServiceResult<Dictionary<string, (Type, object, string)>> returnResult =
                new ServiceResult<Dictionary<string, (Type, object, string)>>(false, string.Empty,
                    new Dictionary<string, (Type, object, string)>());
            try
            {
                if (SchemaList?.Any() is false)
                {
                    returnResult.Message += "傳入TABLE SCHEMA 為空數值 或是 陣列中無任意資料!";
                    return returnResult;
                }

                foreach (var Column in SchemaList)
                {
                    Type type = null;
                    var oracleDbType = Column.DATA_TYPE.GetOracleDbType();
                    switch (oracleDbType)
                    {
                        case OracleDbType.Varchar2:
                        case OracleDbType.NVarchar2:
                            type = typeof(string);
                            break;
                        case OracleDbType.Char:
                        case OracleDbType.NChar:
                            type = typeof(char);
                            break;
                        case OracleDbType.Date:
                        case OracleDbType.TimeStamp:
                        case OracleDbType.TimeStampLTZ:
                        case OracleDbType.TimeStampTZ:
                            type = Column.NULLABLE == EnumUtility.YesNoFlag.N.ToString()
                                ? typeof(DateTime)
                                : typeof(DateTime?);
                            break;
                        case OracleDbType.Decimal:
                            type = Column.NULLABLE == EnumUtility.YesNoFlag.N.ToString()
                                ? typeof(decimal)
                                : typeof(decimal?);
                            break;
                        case OracleDbType.Double:
                            type = Column.NULLABLE == EnumUtility.YesNoFlag.N.ToString()
                                ? typeof(double)
                                : typeof(double?);
                            break;
                        case OracleDbType.Int16:
                            type = Column.NULLABLE == EnumUtility.YesNoFlag.N.ToString()
                                ? typeof(Int16)
                                : typeof(Int16?);
                            break;
                        case OracleDbType.Int32:
                            type = Column.NULLABLE == EnumUtility.YesNoFlag.N.ToString()
                                ? typeof(Int32)
                                : typeof(Int32?);
                            break;
                        case OracleDbType.Int64:
                            type = Column.NULLABLE == EnumUtility.YesNoFlag.N.ToString()
                                ? typeof(Int64)
                                : typeof(Int64?);
                            break;
                        case OracleDbType.Raw:
                        case OracleDbType.LongRaw:
                        case OracleDbType.Blob:
                            type = typeof(byte);
                            break;
                        case OracleDbType.Clob:
                            type = typeof(string);
                            break;
                        case OracleDbType.Single:
                            type = Column.NULLABLE == EnumUtility.YesNoFlag.N.ToString()
                                ? typeof(float)
                                : typeof(float?);
                            break;
                    }

                    if (type is null)
                    {
                        returnResult.Message +=
                            $"[ID:{Column.COLUMN_ID}][欄位名稱:{Column.COLUMN_NAME}][DB型態:{Column.DATA_TYPE}][是否可Null:{Column.NULLABLE}][註解:{Column.COMMENTS}], 該欄位Type轉換失敗!";
                        return returnResult;
                    }

                    returnResult.Data.Add(Column.COLUMN_NAME, (type, null, Column.COMMENTS));
                }

                returnResult.IsOk = true;
                returnResult.Message += $"[{SchemaList?.FirstOrDefault().TABLE_NAME}] DB Schema => Dictionary 轉換完成!";
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
            }

            return returnResult;
        }


        #endregion Query Table Schema Property

        #region Query SYSDATE
        /// <summary>
        /// 取得資料庫當下時間
        /// </summary>
        /// <returns></returns>
        public ServiceResult<DateTime> GetSysDateTime()
        {
            ServiceResult<DateTime> returnResult = new ServiceResult<DateTime>(false, string.Empty, DateTime.MinValue);
            try
            {
                var returnDateTimes = QueryAsyncwithTimeoutTime<DateTime>("SELECT SYSDATE FROM DUAL", null, null, false, CommandType.Text).GetAwaiter().GetResult()?.FirstOrDefault();
                if (returnDateTimes.HasValue)
                {
                    returnResult.IsOk = true;
                    returnResult.Data = returnDateTimes.Value;
                    returnResult.Message += "資料庫時間取得成功!";
                }
                else
                {
                    returnResult.Message += "資料庫時間取得失敗!";
                }
            }
            catch(Exception ex) 
            {
                returnResult.IsOk = true;
                returnResult.Data = DateTime.MinValue;
                returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            return returnResult;
        }
        /// <summary>
        /// 取得資料庫當下時間
        /// </summary>
        /// <returns>取得失敗則回傳DateTime.MinValue</returns>
        public async Task<ServiceResult<DateTime>> GetSysDateTimeAsync(CancellationToken ct = default)
        {
            ServiceResult<DateTime> returnResult = new ServiceResult<DateTime>(false, string.Empty, DateTime.MinValue);
            try
            {
                var queryResult = await QueryAsyncwithTimeoutTimeToken<DateTime>("SELECT SYSDATE FROM DUAL", null,
                    null, CommandType.Text, ct);
                if (queryResult != null && queryResult?.Any() is true)
                {
                    returnResult.IsOk = true;
                    returnResult.Data = queryResult.First();
                    returnResult.Message += "資料庫時間取得成功!";
                }
                else
                {
                    returnResult.Message += "資料庫時間取得失敗!";
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Data = DateTime.MinValue;
                returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            return returnResult;
        }

        #endregion

    }
}
