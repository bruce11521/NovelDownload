using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace CoreBase.DB
{
    public class DBUtilSybase
    {
        //public string connnectString { get; set; } = "SyBaseConnection_IPD";
        //public string SybaseOPD { get; } = "SyBaseConnection";
        //public string SybaseIPD { get; } = "SyBaseConnection_IPD";

        ///// <summary>
        ///// 解密完的連線字串
        ///// </summary>
        //private string constr { get; set; } = string.Empty;

        ///// <summary>
        ///// ConnectionTimeout
        ///// </summary>
        //public int ConnectionTimeout { get; set; } = 20;

        ///// <summary>
        ///// 日期相關參數
        ///// </summary>
        //public enum DateTimeCompare
        //{
        //    /// <summary>
        //    /// 等於
        //    /// </summary>
        //    [System.ComponentModel.DataAnnotations.Display(Name = "等於")]
        //    [Description("=")]
        //    EqualTo = 0,

        //    /// <summary>
        //    /// 大於等於
        //    /// </summary>
        //    [System.ComponentModel.DataAnnotations.Display(Name = "大於等於")]
        //    [Description(">=")]
        //    IsMoreThanOrEqualTo = 1,

        //    /// <summary>
        //    /// 大於
        //    /// </summary>
        //    [System.ComponentModel.DataAnnotations.Display(Name = "大於")]
        //    [Description(">")]
        //    IsMoreThano = 2,

        //    /// <summary>
        //    /// 小於等於
        //    /// </summary>
        //    [System.ComponentModel.DataAnnotations.Display(Name = "小於等於")]
        //    [Description("<=")]
        //    IsLessThanOrEqualTo = 3,

        //    /// <summary>
        //    /// 小於
        //    /// </summary>
        //    [System.ComponentModel.DataAnnotations.Display(Name = "小於")]
        //    [Description("<")]
        //    IsLessThano = 4,
        //}

        ///// <summary>
        ///// 建立資料庫連線
        ///// </summary>
        ///// <param name="readOnlyConnection">是否唯讀</param>
        ///// <returns>資料庫連線</returns>
        //private AseConnection GetDbConnection(bool readOnlyConnection = false)
        //{
        //    constr = ConfigurationManager.ConnectionStrings[connnectString].ConnectionString;
        //    AseConnection aseConnection = new AseConnection(constr);

        //    if (aseConnection.State != ConnectionState.Open)
        //    {
        //        aseConnection.Open();
        //    }

        //    return aseConnection;
        //}

        //#region Query 系列
        ///// <summary>
        ///// 讀取住院Sybase 資料庫
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="convertEncoding">需要轉換成Big5</param>
        ///// <returns></returns>
        //public DataTable syQuery_withASE(string sql, bool convertEncoding = false, bool readOnlyConnection = false)
        //{
        //    DataSet dataSet = new DataSet();
        //    DataTable table = new DataTable();
        //    string conn_str = ConfigurationManager.ConnectionStrings[connnectString].ConnectionString;
        //    try
        //    {
        //        // using (AseConnection aseConn = new AseConnection(conn_str))
        //        using (AseConnection aseConn = GetDbConnection(readOnlyConnection))
        //        {
        //            AseCommand command = new AseCommand(sql, aseConn);
        //            command.CommandTimeout = ConnectionTimeout;
        //            using (AseDataAdapter adapter = new AseDataAdapter(command))
        //            {
        //                adapter.Fill(dataSet);
        //                table = dataSet.Tables[0];
        //                adapter.Dispose();
        //            }
        //            aseConn.Dispose();
        //        }

        //        if (convertEncoding)
        //        {
        //            int rowcnt = table.Rows.Count;
        //            int colucnt = table.Columns.Count;

        //            for (int i = 0; i< rowcnt; i++)
        //            {
        //                for (int j = 0; j < colucnt; j++)
        //                {
        //                    var column = table.Rows[i][j];
        //                    if (new Regex("string").IsMatch(column.GetType().FullName.ToLower())
        //                        || new Regex("varchar").IsMatch(column.GetType().FullName.ToLower()))
        //                    {
        //                        Byte[] mybyte = System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(column.ToString().ToCharArray());
        //                        String value = Encoding.GetEncoding("big5").GetString(mybyte, 0, mybyte.Length);
        //                        table.Rows[i][j] = value;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        dataSet.Dispose();
        //        GC.Collect();
        //    }
        //    return table;
        //}

        ///// <summary>
        ///// 查詢資料 
        ///// 當連線字串含有chartset=big5;有機會造成讀出來的中文變成"?"，當連線字串移除chartset=big5;時，需要手動使用GetBytes轉換編碼(ISO-8859-1) => (big5)才可以得到正常的中文
        ///// </summary>
        ///// <typeparam name="TReturn">回覆的資料類型</typeparam>
        ///// <param name="querySql">SQL敘述</param>
        ///// <param name="param">查詢參數物件</param>
        ///// <param name="timeoutSecs">SQL執行Timeout秒數</param>
        ///// <param name="readOnlyConnection">是否使用 Read Only Connetion</param>
        ///// <param name="commandType">敘述類型</param>
        ///// <returns>資料物件</returns>x
        //public async Task<IEnumerable<TReturn>> QueryAsyncwithTimeoutTime<TReturn>(string querySql, object param = null, int? timeoutSecs = null, bool readOnlyConnection = false, CommandType commandType = CommandType.Text)
        //{
        //    try
        //    {
        //        timeoutSecs = timeoutSecs ?? ConnectionTimeout;

        //        using (IDbConnection con = GetDbConnection(readOnlyConnection))
        //        {
        //            return await con.QueryAsync<TReturn>(querySql, param, null, timeoutSecs, commandType).ConfigureAwait(false);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// 查詢資料
        ///// (keyEntity的name請使用nameof，若想使用like則在Value內使用%，則自動轉換為Like, 若value為陣列則自動轉換為IN, 大於1千筆會自動轉換（但大於一萬筆，會壞掉，請自行切割）, 若value為DateTime則條件自動為大於等於, 若value為!Null則條件自動為Not Null, 若value為!Y則條件自動為 <> 'Y')
        ///// </summary>
        ///// <typeparam name="TResult">資料封裝的物件類型</typeparam>
        ///// <param name="paramDictoionary">查詢條件</param>
        ///// <returns></returns>
        //public async Task<IEnumerable<TResult>> QueryAsync<TResult>(Dictionary<string, object> paramDictoionary)
        //    where TResult : new()
        //{
        //    DynamicParameters keyEntity = new DynamicParameters();
        //    foreach (var item in paramDictoionary)
        //    {
        //        keyEntity.Add(item.Key, item.Value);
        //    }

        //    return await QueryAsync<TResult>(keyEntity).ConfigureAwait(false);
        //}

        ///// <summary>
        ///// 查詢資料
        ///// (keyEntity的name請使用nameof，若想使用like則在Value內使用%，則自動轉換為Like, 若value為陣列則自動轉換為IN, 大於1千筆會自動轉換（但大於一萬筆，會壞掉，請自行切割）, 若value為DateTime則條件自動為大於等於, 若value為!Null則條件自動為Not Null, 若value為!Y則條件自動為 <> 'Y')
        ///// </summary>
        ///// <typeparam name="TResult">資料封裝的物件類型</typeparam>
        ///// <param name="keyEntity">Where的物件</param>
        ///// <param name="readOnlyConnection">是否使用Read Only Connetion</param>
        ///// <returns></returns>
        //public async Task<IEnumerable<TResult>> QueryAsync<TResult>(DynamicParameters keyEntity = null, bool readOnlyConnection = false)
        //    where TResult : new()
        //{
        //    DynamicParameters dynamicParameters = new DynamicParameters();
        //    List<string> keyProperties = new List<string>();
        //    string querySql = string.Empty;

        //    Type modelType = typeof(TResult);
        //    bool hasTableAttribute = modelType.IsDefined(typeof(TableAttribute), true);
        //    string tableName = hasTableAttribute ? ((TableAttribute)modelType.GetCustomAttributes(typeof(TableAttribute), true)[0]).Name : modelType.Name;
        //    bool hasUserAttribute = modelType.IsDefined(typeof(DBUserAttribute), true);

        //    //List<string> queryProperties = (from entityMember in new TResult().GetType().GetProperties() where !entityMember.IsDefined(typeof(WriteAttribute), true) select entityMember.Name).ToList();
        //    List<string> queryProperties = (from entityMember in new TResult().GetType().GetProperties()
        //                                    where !entityMember.IsDefined(typeof(WriteAttribute), true) &&
        //                                          !entityMember.IsDefined(typeof(NoSelect), true)
        //                                    select entityMember.Name).ToList();

        //    querySql += $"SELECT {string.Join($"{Environment.NewLine}, ", queryProperties)} FROM dbo.{tableName} ";

        //    if (keyEntity != null && keyEntity.ParameterNames.Any())
        //    {
        //        var parametersLookup = (SqlMapper.IParameterLookup)keyEntity;

        //        foreach (var keyentityParameterName in keyEntity.ParameterNames)
        //        {
        //            var pValue = parametersLookup[keyentityParameterName];
        //            if (!(pValue is string) && (pValue is ValueTuple<DateTime, DateTime>))
        //            {
        //                keyProperties.Add($"{keyentityParameterName} Between @key_{keyentityParameterName} And @key_{keyentityParameterName}1");
        //            }
        //            else if (!(pValue is string) && (pValue is ValueTuple<DateTimeCompare, DateTime>))
        //            {
        //                var tupleValue = (ValueTuple<DateTimeCompare, DateTime>)pValue;
        //                var descriptionValue = tupleValue.Item1.GetEnumDescription();
        //                keyProperties.Add($"{keyentityParameterName} {descriptionValue} @key_{keyentityParameterName} ");
        //            }
        //            else if (!(pValue is string) && pValue is IEnumerable)
        //            {
        //                keyProperties.Add($"{keyentityParameterName} IN @key_{keyentityParameterName}");
        //            }
        //            else if (!(pValue is string) && pValue is DateTime)
        //            {
        //                keyProperties.Add($"{keyentityParameterName} = @key_{keyentityParameterName}");
        //            }
        //            else if (!(pValue is string) && pValue == null)
        //            {
        //                keyProperties.Add($"{keyentityParameterName} IS NULL");
        //            }
        //            else
        //            {
        //                switch (pValue)
        //                {
        //                    case string _ when pValue.ToString().Contains("%"):
        //                        keyProperties.Add($"{keyentityParameterName} LIKE @key_{keyentityParameterName}");
        //                        break;
        //                    case string _ when pValue.ToString().Equals("!Null"):
        //                        keyProperties.Add($"{keyentityParameterName} IS Not NULL");
        //                        break;
        //                    case string _ when pValue.ToString().Contains("!"):
        //                        keyProperties.Add($"{keyentityParameterName} <> @key_{keyentityParameterName}");
        //                        pValue = pValue.ToString().Replace("!", string.Empty);
        //                        break;
        //                    default:
        //                        keyProperties.Add($"{keyentityParameterName} = @key_{keyentityParameterName}");
        //                        break;
        //                }
        //            }

        //            if (!(pValue is string) && (pValue is ValueTuple<DateTime, DateTime>))
        //            {
        //                var tupleValue = (ValueTuple<DateTime, DateTime>)pValue;
        //                dynamicParameters.Add("key_" + keyentityParameterName, tupleValue.Item1);
        //                dynamicParameters.Add("key_" + keyentityParameterName + "1", tupleValue.Item2);
        //            }
        //            else if (!(pValue is string) && (pValue is ValueTuple<DateTimeCompare, DateTime>))
        //            {
        //                var tupleValue = (ValueTuple<DateTimeCompare, DateTime>)pValue;
        //                dynamicParameters.Add("key_" + keyentityParameterName, tupleValue.Item2);
        //            }
        //            else
        //            {
        //                dynamicParameters.Add("key_" + keyentityParameterName, pValue);
        //            }
        //        }

        //        querySql += $"{Environment.NewLine} WHERE {string.Join($"{Environment.NewLine} AND ", keyProperties)} ";
        //    }

        //    using (IDbConnection con = GetDbConnection(readOnlyConnection))
        //    {
        //        return await con.QueryAsync<TResult>(querySql, dynamicParameters, null, ConnectionTimeout, CommandType.Text).ConfigureAwait(false);
        //    }
        //}
        //#endregion Query 系列

        //#region Execute 系列
        ///// <summary>
        ///// 執行交易 query
        ///// </summary>
        ///// <param name="taskList">任務清單</param>
        ///// <returns></returns>
        //public bool ExecuteTransactionQuery(params Action<AseConnection, AseTransaction>[] taskList)
        ////public bool ExecuteTransactionQuery(params Action<IDbConnection, IDbTransaction>[] taskList)
        //{
        //    using (AseConnection con = GetDbConnection(false) as AseConnection)//var cn = new OracleConnection(CnStr)
        //    //using (IDbConnection con = GetDbConnection())
        //    {
        //        using (AseTransaction transaction = con.BeginTransaction())// IsolationLevel.Serializable))
        //        {
        //            try
        //            {
        //                var ss = 0;
        //                foreach (Action<AseConnection, AseTransaction> act in taskList)
        //                {
        //                    act(con, transaction);
        //                    ss++;
        //                }

        //                transaction.Commit();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}


        ///// <summary>
        ///// 執行用(INSERT、UPDATE、DELETE)
        ///// </summary>
        ///// <param name="sql"></param>
        //public void excute(string sql)
        //{
        //    try
        //    {
        //        using (AseConnection aseConn = GetDbConnection(false))//new AseConnection(constr))
        //        {
        //            aseConn.Execute(sql);
        //            aseConn.Close();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //#endregion Execute 系列


        //#region Bind 系列
        ///// <summary>
        ///// 新增資料（CLOB欄位不能用），建議選用有Parameter的Function
        ///// </summary>
        ///// <typeparam name="T">新增的Model</typeparam>
        ///// <param name="insertInfo">新增的資料</param>
        ///// <param name="sql">Bind完的SQL Script</param>
        //public void BindInsert<T>(IEnumerable<T> insertInfo, out string sql)
        //{
        //    IEnumerable<string> fields = typeof(T).GetProperties()
        //        .Where(p =>
        //            p.CustomAttributes.All(a => a.AttributeType != typeof(KeyAttribute)
        //                && a.AttributeType != typeof(ComputedAttribute)
        //                && a.AttributeType != typeof(NoWrite)))
        //        .Select(p => p.Name); // 資料實體中的所有屬性(欄位)名稱、除了標有自訂屬性的欄位外

        //    var tableAtt = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

        //    // default table name
        //    string tableName = "xxxx";
        //    if (tableAtt != null)
        //    {
        //        // 資料實體對應的資料表名稱;
        //        tableName = tableAtt.Name;
        //    }
        //    else
        //    {
        //        // class name
        //        tableName = typeof(T).Name;
        //    }

        //    string fieldNames = string.Join(", ", fields);
        //    string fieldParameters = string.Join(", @", fields);
        //    sql = $"INSERT INTO dbo.{tableName}({fieldNames}) values(@{fieldParameters})";
        //}

        ///// 新增單筆資料，最好選用有Parameter這組，目前試大量資料的話，一次建議只丟1000筆
        ///// </summary>
        ///// <typeparam name="T">新增的Model</typeparam>
        ///// <param name="insertInfo">新增的資料</param>
        ///// <param name="sql">Bind完的SQL Script</param>
        ///// <param name="param">Bind完的參數</param>
        ///// <param name="count">第幾筆</param>
        //public void BindInsertNew<T>(IEnumerable<T> insertInfo, out string sql, out DynamicParameters param, int count = 0)
        //{
        //    DynamicParameters dynamicParameters = new DynamicParameters();

        //    List<string> columns = new List<string>();
        //    List<string> values = new List<string>();

        //    var tableAtt = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

        //    // default table name
        //    string tableName = "xxxx";
        //    if (tableAtt != null)
        //    {
        //        // 資料實體對應的資料表名稱;
        //        tableName = tableAtt.Name;
        //    }
        //    else
        //    {
        //        // class name
        //        tableName = typeof(T).Name;
        //    }

        //    var props = typeof(T)
        //     .GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
        //    var propNames = props.Select(o => o.Name).ToArray();
        //    var oraParams = props.ToDictionary(o => o.Name, o =>
        //    {
        //        var p = new AseParameter();
        //        p.ParameterName = $"{o.Name}_{count}";
        //        switch (o.PropertyType.ToString().Split('.').Last().TrimEnd(']'))
        //        {
        //            case "String":
        //                p.DbType = DbType.String;
        //                break;
        //            case "DateTime":
        //                p.DbType = DbType.DateTime;
        //                break;
        //            case "Int32":
        //                p.DbType = DbType.Int32;
        //                break;
        //            case "Decimal":
        //                p.DbType = DbType.Decimal;
        //                break;
        //            case "Single":
        //                p.DbType = DbType.Single;
        //                break;
        //            case "Double":
        //                p.DbType = DbType.Double;
        //                break;
        //            default:
        //                throw new NotImplementedException(o.PropertyType.ToString());
        //        }
        //        return p;
        //    });

        //    foreach (var property in props)
        //    {
        //        // 檢查是否有 KeyAttribute 或 WriteAttribute 或 NoWrite 定義，有則排除，不組進SQL裡
        //        if (!property.IsDefined(typeof(KeyAttribute), true) &&
        //            !property.IsDefined(typeof(WriteAttribute), true) &&
        //            !property.IsDefined(typeof(NoWrite), true))
        //        {
        //            columns.Add($"{property.Name}");
        //            values.Add($"@{property.Name}_{count}");

        //            oraParams.TryGetValue(property.Name, out var oraParam);

        //            switch (oraParam.DbType)
        //            {
        //                case DbType.Date:
        //                case DbType.DateTime:
        //                case DbType.DateTime2:
        //                case DbType.DateTimeOffset:
        //                    dynamicParameters.Add($"@{property.Name}_{count}", insertInfo.Select(x => ((DateTime?)property.GetValue(x))?.ToString("yyyy-MM-dd hh:mm:ss")).ToArray(), oraParam.DbType, ParameterDirection.Input);
        //                    //dynamicParameters.Add($":{property.Name}_{count}", insertInfo.Select(x => $"to_date({property.GetValue(x)}, "'yyyy-MM-dd HH24:MI:SS'")").ToArray(), oraParam.DbType,ParameterDirection.Input);
        //                    break;
        //                default:
        //                    dynamicParameters.Add($"@{property.Name}_{count}", insertInfo.Select(x => property.GetValue(x)).ToArray(), oraParam.DbType, ParameterDirection.Input);
        //                    break;
        //            }
        //        }
        //    }

        //    sql = $"INSERT INTO dbo.{tableName} ({string.Join(", ", columns)}) values({string.Join(", ", values)}) ";
        //    param = dynamicParameters;
        //}
        ///// <summary>
        ///// 新增單筆資料
        ///// </summary>
        ///// <typeparam name="T">新增的Model</typeparam>
        ///// <param name="insertInfo">新增的資料</param>
        ///// <param name="sql">Bind完的SQL Script</param>
        ///// <param name="param">Bind完的參數</param>
        ///// <param name="count">第幾筆</param>
        //public void BindInsertSingle<T>(T insertInfo, out string sql)
        //{
        //    DynamicParameters dynamicParameters = new DynamicParameters();

        //    List<string> columns = new List<string>();
        //    List<string> values = new List<string>();

        //    var tableAtt = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

        //    // default table name
        //    string tableName = "xxxx";
        //    if (tableAtt != null)
        //    {
        //        // 資料實體對應的資料表名稱;
        //        tableName = tableAtt.Name;
        //    }
        //    else
        //    {
        //        // class name
        //        tableName = typeof(T).Name;
        //    }

        //    var props = typeof(T)
        //     .GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
        //    var propNames = props.Select(o => o.Name).ToArray();
        //    var oraParams = props.ToDictionary(o => o.Name, o =>
        //    {
        //        var p = new AseParameter();
        //        p.ParameterName = $"{o.Name}";
        //        switch (o.PropertyType.ToString().Split('.').Last().TrimEnd(']'))
        //        {
        //            case "String":
        //                p.DbType = DbType.String;
        //                break;
        //            case "DateTime":
        //                p.DbType = DbType.DateTime;
        //                break;
        //            case "Int32":
        //                p.DbType = DbType.Int32;
        //                break;
        //            case "Int16":
        //                p.DbType = DbType.Int16;
        //                break;
        //            case "Decimal":
        //                p.DbType = DbType.Decimal;
        //                break;
        //            case "Single":
        //                p.DbType = DbType.Single;
        //                break;
        //            case "Double":
        //                p.DbType = DbType.Double;
        //                break;
        //            default:
        //                throw new NotImplementedException(o.PropertyType.ToString());
        //        }
        //        return p;
        //    });

        //    var allValue = insertInfo.GetFieldValue();

        //    foreach (var property in props)
        //    {
        //        // 檢查是否有 KeyAttribute 或 WriteAttribute 或 NoWrite 定義，有則排除，不組進SQL裡
        //        if (!property.IsDefined(typeof(KeyAttribute), true) &&
        //            !property.IsDefined(typeof(WriteAttribute), true) &&
        //            !property.IsDefined(typeof(NoWrite), true))
        //        {
        //            columns.Add($"{property.Name}");
        //            //values.Add($"@{property.Name}");

        //            oraParams.TryGetValue(property.Name, out var oraParam);
        //            allValue.TryGetValue(property.Name, out var oraValue);


        //            switch (oraParam.DbType)
        //            {
        //                case DbType.Date:
        //                case DbType.DateTime:
        //                case DbType.DateTime2:
        //                case DbType.DateTimeOffset:
        //                    values.Add(((DateTime)oraValue).ToString("yyyy-MM-dd hh:mm:ss"));
        //                    //dynamicParameters.Add($"@{property.Name}", insertInfo.Select(x => ((DateTime?)property.GetValue(x))?.ToString("yyyy-MM-dd hh:mm:ss")).ToArray(), oraParam.DbType, ParameterDirection.Input);
        //                    //dynamicParameters.Add($":{property.Name}_{count}", insertInfo.Select(x => $"to_date({property.GetValue(x)}, "'yyyy-MM-dd HH24:MI:SS'")").ToArray(), oraParam.DbType,ParameterDirection.Input);
        //                    break;
        //                case DbType.Decimal:
        //                case DbType.Single:
        //                case DbType.Double:
        //                case DbType.Int16:
        //                case DbType.Int32:
        //                    values.Add(oraValue.ToString());
        //                    break;
        //                default:
        //                    if (oraValue == null)
        //                    {
        //                        values.Add("null");
        //                    }
        //                    else
        //                    {
        //                        values.Add("'" + oraValue.ToString()+ "'");
        //                    }
        //                    break;
        //            }
        //        }
        //    }

        //    sql = $"INSERT INTO dbo.{tableName} ({string.Join(", ", columns)}) values({string.Join(", ", values)}) ";
        //}
        //#endregion Bind 系列

    }
}
