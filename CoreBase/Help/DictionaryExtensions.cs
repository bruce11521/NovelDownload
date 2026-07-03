using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CoreBase.Utilities;
using Newtonsoft.Json;

namespace CoreBase.Help
{
    /// <summary>
    /// Dictionary Extensions
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// 使用Reflection從Dictionary&lt;string, object&gt; 轉換成 Class , 並忽略轉換錯誤問題
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        /// <returns>.Code:1=&gt;轉換成功,0=&gt;有發生轉換失敗但忽略並繼續轉換,查看Message</returns>
        public static ServiceResult<T> ConvertDictToClassWithReflection<T>(this Dictionary<string, object> dict) where T : new()
        {
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, new T());
            if (dict == null)
            {
                returnResult.Message = "傳入的Dictionary為Null!";
                return returnResult;
            }
            try
            {
                T obj = new T();
                var type = typeof(T);
                var errorMsgList = new List<string>();
                foreach (var kvp in dict)
                {
                    var prop = type.GetProperty(kvp.Key,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                    if (prop != null && prop.CanWrite)
                    {
                        try
                        {
                            if (kvp.Value == null || prop.PropertyType.IsAssignableFrom(kvp.Value.GetType()))
                            {
                                //若Dict值為null 或 已相容型別，直接設定給class;
                                prop.SetValue(obj, kvp.Value);
                            }
                            else
                            {
                                var converted = Convert.ChangeType(kvp.Value,
                                    Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                                prop.SetValue(obj, converted);
                            }
                        }
                        catch(Exception ex) 
                        {
                            errorMsgList.Add(ex.GetInnerException().ErrorMessage);
                            continue;
                        }
                    }
                }
                returnResult.IsOk = true;
                returnResult.Message = errorMsgList.Any() ? "轉換失敗訊息:" + Environment.NewLine + string.Join(Environment.NewLine, errorMsgList) : "轉換完成!";
                returnResult.Code = errorMsgList.Any() ? 0 : 1;
                returnResult.Data = obj;
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message = "Reflection轉換DictionaryToClass失敗:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            return returnResult;
        }
        /// <summary>
        /// 使用Newtonsoft.Json從Dictionary&lt;string, object&gt; 轉換成 Class , 並忽略轉換錯誤問題
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static ServiceResult<T> ConvertDictToClassWithJson<T>(this Dictionary<string, object> dict)
        {
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
            try
            {
                if (dict == null)
                {
                    returnResult.Message = "傳入的Dictionary為Null!";
                    return returnResult;
                }
                string json = JsonConvert.SerializeObject(dict);
                T result = JsonConvert.DeserializeObject<T>(json) ?? default;
                returnResult.IsOk = true;
                returnResult.Message = "轉換完成!";
                returnResult.Data = result;
                return returnResult;
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message = "JsonConvert轉換DictionaryToClass失敗:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
                return returnResult;
            }
        }


    }
}
