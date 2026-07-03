using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using CoreBase.Utilities;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Runtime.CompilerServices;

namespace CoreBase.Help
{
    /// <summary>
    /// IEnumerable型態擴充功能
    /// </summary>
    public static class EnumerableExtensions
    {
        #region GetFieldValue 主方法與延伸方法
        /// <summary>
        /// 建立快取屬性清單，避免每個方法都進行反射
        /// </summary>
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _propCache = new();
        /// <summary>
        /// 跳過不適合的屬性，略過indexer(get_Item)、沒有public getter的屬性
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static PropertyInfo[] GetProps(Type t) => _propCache.GetOrAdd(t, _ => 
            t.GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.GetIndexParameters().Length == 0 &&
                        p.GetMethod != null &&
                        p.GetMethod.IsPublic).ToArray());

        /// <summary>
        /// 通用方法 預設使用執行階段型別
        /// 用執行階段型別，避免只抓到 T（基底）屬性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="model">Model</param>
        /// <param name="selector"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        private static Dictionary<string, TOut> ToDict<T, TOut>(
            T model
            , Func<PropertyInfo, T?, TOut> selector
            , StringComparer? comparer = null)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));
            var type = model.GetType(); //runtime type
            var props = GetProps(type);
            var dict = new Dictionary<string, TOut>(props.Length, comparer ?? StringComparer.Ordinal);
            foreach (var prop in props)
            {
                dict[prop.Name] = selector(prop, model);
            }
            return dict;
        }
        /// <summary>
        /// 通用方法 可指定要掃描的型別（例如鎖定基底型別）
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="model">Model</param>
        /// <param name="typeToScan">指定要掃描的型別</param>
        /// <param name="selector"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        private static Dictionary<string, TOut> ToDict<T, TOut>(
            T model
            , Type typeToScan
            , Func<PropertyInfo, T?, TOut> selector
            , StringComparer? comparer = null
            )
        {
            if (model is null) throw new ArgumentNullException(nameof(model));
            if (typeToScan is null) throw new ArgumentNullException(nameof(typeToScan));

            var props = GetProps(typeToScan);
            var dict = new Dictionary<string, TOut>(props.Length, comparer ?? StringComparer.Ordinal);
            foreach (var prop in props)
            {
                dict[prop.Name] = selector(prop, model);
            }
            return dict;
        }
        /// <summary>
        /// 快取屬性 Getter 的委派，加速 GetValue
        /// </summary>
        private static readonly ConcurrentDictionary<(Type, string), Func<object?, object?>> _getterCache = new();
        /// <summary>
        /// 取得快取屬性 Getter
        /// </summary>
        /// <param name="type"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private static Func<object?, object?> GetGetter(Type type, PropertyInfo p)
        {
            return _getterCache.GetOrAdd((type, p.Name), _ =>
            {
                // (object? target) => (object?)((T)target).Prop
                var target = Expression.Parameter(typeof(object), "target");
                var cast = Expression.Convert(target, type);
                var prop = Expression.Property(cast, p);
                var box = Expression.Convert(prop, typeof(object));
                return Expression.Lambda<Func<object?, object?>>(box, target).Compile();
            });
        }
        /// <summary>
        /// 所有Display,Description屬性欄位
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ShortName"></param>
        /// <param name="GroupName"></param>
        /// <param name="Description"></param>
        /// <param name="DisplayDescription"></param>
        /// <param name="Order"></param>
        /// <param name="AutoGenerateField"></param>
        /// <param name="AutoGenerateFilter"></param>
        public record DisplayMeta(
            string Name,
            string ShortName,
            string GroupName,
            string Description,
            string DisplayDescription,
            int Order,
            bool AutoGenerateField,
            bool AutoGenerateFilter
        );
        /// <summary>
        /// 取出Model內的Field及所有相關Display屬型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Dictionary<string, DisplayMeta> GetFieldDisplayMeta<T>(this T model, bool IgnoreCase = false)
        {
            var props = GetProps(typeof(T));
            var dict = new Dictionary<string, DisplayMeta>(props.Length);
            foreach (var p in props)
            {
                var disp = p.GetCustomAttribute<DisplayAttribute>(inherit: true);
                var desc = p.GetCustomAttribute<DescriptionAttribute>(inherit: true);
                dict[p.Name] = new DisplayMeta(
                    Name: disp?.GetName() ?? "",
                    ShortName: disp?.GetShortName() ?? "",
                    GroupName: disp?.GetGroupName() ?? "",
                    Description: desc?.Description ?? "",
                    DisplayDescription: disp?.GetDescription() ?? "",
                    Order: disp?.GetOrder() ?? 0,
                    AutoGenerateField: disp?.GetAutoGenerateField() ?? false,
                    AutoGenerateFilter: disp?.GetAutoGenerateFilter() ?? false
                );
            }
            return dict;
        }


        /// <summary>
        /// 取出Model內的Field及Value
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <param name="IgnoreCase">KEY比對時是否忽略大小寫[預設:False]</param>
        /// <param name="typeToScan">指定要掃描的型別[預設:Null,使用Runtime type] EX: typeof(MODEL)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"> 當Model為Null時候 </exception>
        public static Dictionary<string, object?> GetFieldValue<T>(this T model, bool IgnoreCase = false, Type? typeToScan = null)
        {
            /*使用方法
                //預設：掃描執行階段型別（含子類別屬性）
                var dict1 = mySubModel.GetFieldValue(); 
               
                //忽略大小寫的 key
                var dict2 = mySubModel.GetFieldValue(ignoreCase: true);
               
                //只掃描基底型別的屬性
                var dict3 = mySubModel.GetFieldValue(typeToScan: typeof(BaseModel));
             */
            if (model == null) throw new ArgumentNullException(nameof(model));
            StringComparer comparer = IgnoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;
            if (typeToScan is null)
            {
                //用執行階段的型別
                var runtimeType = model!.GetType();
                return ToDict(model, (p, m) => GetGetter(runtimeType, p)(m), comparer);
            }
            else
            {
                // 鎖定特定型別（例如 typeof(BaseModel)）
                return ToDict(model, (p, m) =>
                {
                    //注意：Getter 要用掃描型別建立
                    var getter = GetGetter(typeToScan, p);
                    return getter(m);
                }, comparer);
            }
        }
        /// <summary>
        /// 取出Model內 Field 與 [Display(Name)]
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldDisplayName<T>(this T model)
            => ToDict(model, (p, _) => p.GetCustomAttribute<DisplayAttribute>(inherit: true)?.GetName() ?? string.Empty);

        /// <summary>
        /// 取出Model內 Field 與 [Display(Description)]
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldDisplayDescription<T>(this T model)
            => ToDict(model, (p, _) => p.GetCustomAttribute<DisplayAttribute>(inherit: true)?.GetDescription() ?? string.Empty);

        /// <summary>
        /// 取出Model內 Field 與 [Description(…)]
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldDescription<T>(this T model)
            => ToDict(model, (p, _) => p.GetCustomAttribute<DescriptionAttribute>(inherit: true)?.Description ?? string.Empty);

        /// <summary>
        /// 取出Model內 Field 與 [Display(Order)]
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <param name="defaultOrdersIntValue">當Order不存在時給予預設值[預設:0]</param>
        /// <returns></returns>
        public static Dictionary<string, int> GetFieldDisplayOrders<T>(this T model, int defaultOrdersIntValue = 0)
            => ToDict(model, (p, _) => p.GetCustomAttribute<DisplayAttribute>(inherit: true)?.GetOrder() ?? defaultOrdersIntValue);

        /// <summary>
        /// 取出Model內 Field 與 [Display(AutoGenerateField)]
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <param name="defaultAutoGenerateFieldValue">當AutoGenerateField不存在時給予預設值[預設:False]</param>
        /// <returns></returns>
        public static Dictionary<string, bool> GetFieldDisplayAutoGenerateField<T>(this T model, bool defaultAutoGenerateFieldValue = false)
            => ToDict(model, (p, _) => p.GetCustomAttribute<DisplayAttribute>(inherit: true)?.GetAutoGenerateField() ?? defaultAutoGenerateFieldValue);

        /// <summary>
        /// 取出Model內 Field 與 [Display(AutoGenerateFilter)]
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <param name="defaultAutoGenerateFilterValue">當AutoGenerateFilter不存在時給予預設值[預設:False]</param>
        /// <returns></returns>
        public static Dictionary<string, bool> GetFieldDisplayAutoGenerateFilter<T>(this T model, bool defaultAutoGenerateFilterValue = false)
            => ToDict(model, (p, _) => p.GetCustomAttribute<DisplayAttribute>(inherit: true)?.GetAutoGenerateFilter() ?? defaultAutoGenerateFilterValue);

        /// <summary>
        /// 取出Model內 Field 與 [Display(ShortName)]
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldDisplayShortName<T>(this T model)
            => ToDict(model, (p, _) => p.GetCustomAttribute<DisplayAttribute>(inherit: true)?.GetShortName() ?? string.Empty);

        /// <summary>
        /// 取出Model內 Field 與 [Display(GroupName)]
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldDisplayGroupName<T>(this T model)
            => ToDict(model, (p, _) => p.GetCustomAttribute<DisplayAttribute>(inherit: true)?.GetGroupName() ?? string.Empty);
        #endregion


        /// <summary>
        /// Perform a deep Copy of the object, using Json as a serialisation method. NOTE: Private members are not cloned using this method.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T CloneJson<T>(this T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            // initialize inner objects individually
            // for example in default constructor some list property initialized with some values,
            // but in 'source' these items are cleaned -
            // without ObjectCreationHandling.Replace default constructor values will be added to result
            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, Formatting.None), deserializeSettings);
        }

        /// <summary>
        /// Linq擴充方法By (範例如下)
        /// <code>source.Distinct(Compare.By(a => a.Id));</code>
        /// </summary>
        /// <typeparam name="TSource">來源泛型類別</typeparam>
        /// <typeparam name="TIdentity">識別器泛型類別</typeparam>
        /// <param name="identitySelector">識別器</param>
        /// <returns></returns>
        private static IEqualityComparer<TSource> By<TSource, TIdentity>(Func<TSource, TIdentity> identitySelector)
        {
            return new DelegateComparer<TSource, TIdentity>(identitySelector);
        }

        private class DelegateComparer<T, TIdentity> : IEqualityComparer<T>
        {
            private readonly Func<T, TIdentity> identitySelector;

            public DelegateComparer(Func<T, TIdentity> identitySelector)
            {
                this.identitySelector = identitySelector;
            }

            public bool Equals(T x, T y)
            {
                return Equals(identitySelector(x), identitySelector(y));
            }

            public int GetHashCode(T obj)
            {
                return identitySelector(obj).GetHashCode();
            }
        }

        /// <summary>
        /// Mapping Data (範例如下)
        /// <code> source.MappingData(new Dictionary&gt;string, object>{{"ColumnName1", "ColumnValue1"},{"ColumnName2", "ColumnValue2"},}) </code>
        /// </summary>
        /// <typeparam name="T">Model 態型</typeparam>
        /// <param name="model"></param>
        /// <param name="data"></param>
        /// <param name="IsIgnoreModelNameCase">是否忽略Column Name大小寫</param>
        /// <returns></returns>
        public static T MappingSource<T>(this T model, Dictionary<string, Object> data, bool IsIgnoreModelNameCase = false)
        {
            var modelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var row in data)
            {
                var column = modelInfos.FirstOrDefault(o => (IsIgnoreModelNameCase ? o.Name?.ToUpper() == row.Key.ToString()?.ToUpper() : o.Name == row.Key.ToString()) );

                // 找不到欄位相符的名稱
                if (column == null)
                {
                    continue;
                }

                var valueType = Nullable.GetUnderlyingType(column?.PropertyType) ?? column?.PropertyType;

                object rowValue = null;
                try
                {
                    // 預防型態可Null結果Value Type不可Null時，塞不了Null值
                    if (valueType != null && row.Value == null)
                    {
                        rowValue = null;
                    }
                    else
                    {
                        rowValue = Convert.ChangeType(row.Value, valueType, CultureInfo.CurrentCulture);
                    }
                }
                catch(Exception ex)
                {
                    continue;
                }
                if (column.CanWrite)
                {
                    column.SetValue(model, rowValue);
                }
            }

            return model;
        }
        #region GetFieldValue 舊方法 20250829 Bruce註解 
        ///// <summary>
        ///// 取出Model內的Field及Value
        ///// <code> source.GetFieldValue() </code>
        ///// </summary>
        ///// <typeparam name="T">Model 型態</typeparam>
        ///// <param name="model">Model</param>
        ///// <returns></returns>
        //public static Dictionary<string, object> GetFieldValue<T>(this T model)
        //{
        //    try
        //    {

        //        var result = typeof(T).GetProperties()
        //             .ToDictionary(p => p.Name, p => p.GetValue(model));

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        ///// <summary>
        ///// 取出Model內的Field及 [Display(Name)]
        ///// <code> source.GetFieldValue() </code>
        ///// </summary>
        ///// <typeparam name="T">Model 型態</typeparam>
        ///// <param name="model">Model</param>
        ///// <returns></returns>
        //public static Dictionary<string, string> GetFieldDisplayName<T>(this T model)
        //{
        //    try
        //    {
        //        var result = typeof(T).GetProperties()
        //            .ToDictionary(p => p.Name, p => p?.GetCustomAttribute<DisplayAttribute>()?.GetName() ?? string.Empty);
        //        return result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        ///// <summary>
        ///// 取出Model內的Field及 [Display(Description)]
        ///// <code> source.GetFieldValue() </code>
        ///// </summary>
        ///// <typeparam name="T">Model 型態</typeparam>
        ///// <param name="model">Model</param>
        ///// <returns></returns>
        //public static Dictionary<string, string> GetFieldDisplayDescription<T>(this T model)
        //{
        //    try
        //    {
        //        var result = typeof(T).GetProperties()
        //            .ToDictionary(p => p.Name, p => p?.GetCustomAttribute<DisplayAttribute>()?.GetDescription() ?? string.Empty);
        //        return result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        ///// <summary>
        ///// 取出Model內的Field及 [Description.Description]
        ///// <code> source.GetFieldValue() </code>
        ///// </summary>
        ///// <typeparam name="T">Model 型態</typeparam>
        ///// <param name="model">Model</param>
        ///// <returns></returns>
        //public static Dictionary<string, string> GetFieldDescription<T>(this T model)
        //{
        //    try
        //    {
        //        var result = typeof(T).GetProperties()
        //            .ToDictionary(p => p.Name, p => p?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? string.Empty);
        //        return result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        ///// <summary>
        ///// 取出Model內的Field及 [Display.Orders]
        ///// <code> source.GetFieldValue() </code>
        ///// </summary>
        ///// <typeparam name="T">Model 型態</typeparam>
        ///// <param name="model">Model</param>
        ///// <param name="defaultOrdersIntValue">當未取得Orders時給予預設數值[預設:0]</param>
        ///// <returns></returns>
        //public static Dictionary<string, int> GetFieldDisplayOrders<T>(this T model, int defaultOrdersIntValue = 0)
        //{
        //    try
        //    {
        //        var result = typeof(T).GetProperties()
        //            .ToDictionary(p => p.Name, p => p?.GetCustomAttribute<DisplayAttribute>()?.GetOrder() ?? defaultOrdersIntValue);
        //        return result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        ///// <summary>
        ///// 取出Model內的Field及 [Display.AutoGenerateField]
        ///// <code> source.GetFieldValue() </code>
        ///// </summary>
        ///// <typeparam name="T">Model 型態</typeparam>
        ///// <param name="model">Model</param>
        ///// <param name="defaultAutoGenerateFieldValue">當未取得AutoGenerateField時給予預設數值[預設:false]</param>
        ///// <returns></returns>
        //public static Dictionary<string, bool> GetFieldDisplayAutoGenerateField<T>(this T model, bool defaultAutoGenerateFieldValue = false)
        //{
        //    try
        //    {
        //        var result = typeof(T).GetProperties()
        //            .ToDictionary(p => p.Name, p => p?.GetCustomAttribute<DisplayAttribute>()?.GetAutoGenerateField() ?? defaultAutoGenerateFieldValue);
        //        return result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        ///// <summary>
        ///// 取出Model內的Field及 [Display.AutoGenerateFilter]
        ///// <code> source.GetFieldValue() </code>
        ///// </summary>
        ///// <typeparam name="T">Model 型態</typeparam>
        ///// <param name="model">Model</param>
        ///// <param name="defaultAutoGenerateFilterValue">當未取得AutoGenerateFilter時給予預設數值[預設:false]</param>
        ///// <returns></returns>
        //public static Dictionary<string, bool> GetFieldDisplayAutoGenerateFilter<T>(this T model, bool defaultAutoGenerateFilterValue = false)
        //{
        //    try
        //    {
        //        var result = typeof(T).GetProperties()
        //            .ToDictionary(p => p.Name, p => p?.GetCustomAttribute<DisplayAttribute>()?.GetAutoGenerateFilter() ?? defaultAutoGenerateFilterValue);
        //        return result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        ///// <summary>
        ///// 取出Model內的Field及 [Display.ShortName]
        ///// <code> source.GetFieldValue() </code>
        ///// </summary>
        ///// <typeparam name="T">Model 型態</typeparam>
        ///// <param name="model">Model</param>
        ///// <returns></returns>
        //public static Dictionary<string, string> GetFieldDisplayShortName<T>(this T model)
        //{
        //    try
        //    {
        //        var result = typeof(T).GetProperties()
        //            .ToDictionary(p => p.Name, p => p?.GetCustomAttribute<DisplayAttribute>()?.GetShortName() ?? string.Empty);
        //        return result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        ///// <summary>
        ///// 取出Model內的Field及 [Display.GroupName]
        ///// <code> source.GetFieldValue() </code>
        ///// </summary>
        ///// <typeparam name="T">Model 型態</typeparam>
        ///// <param name="model">Model</param>
        ///// <returns></returns>
        //public static Dictionary<string, string> GetFieldDisplayGroupName<T>(this T model)
        //{
        //    try
        //    {
        //        var result = typeof(T).GetProperties()
        //            .ToDictionary(p => p.Name, p => p?.GetCustomAttribute<DisplayAttribute>()?.GetGroupName() ?? string.Empty);
        //        return result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        #endregion


        /// <summary>
        /// Model轉換，找不到相同的欄位名稱或是可放置的屬性，皆會被略過
        /// <code> target.ConvertModel(source) </code>
        /// </summary>
        /// <typeparam name="T">目標Model 型態</typeparam>
        /// <typeparam name="TSource">資料來源Model 型態</typeparam>
        /// <param name="model">目標Model</param>
        /// <param name="data">資料Model</param>
        /// <param name="isIgnoreModelCase">是否忽略Column Name大小寫</param>
        /// <returns></returns>
        public static T CovertModel<T, TSource>(this T model, TSource data, bool isIgnoreModelCase = false)
        {
            return model.MappingSource(data.GetFieldValue(), isIgnoreModelCase);
        }


        #region Dictionary<string, object> To Model Class
        /// <summary>
        /// Dictionary&lt; string, object &gt; To Model&lt;T&gt;
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="dict">Dictionary</param>
        /// <returns></returns>
        public static T GetObject<T>(this Dictionary<string, object> dict)
        {
            return (T)GetObject(dict, typeof(T));
        }
        /// <summary>
        /// Dictionary&lt; string, object &gt; To Model&lt;T&gt;
        /// </summary>
        /// <param name="dict">Dictionary</param>
        /// <param name="type">T</param>
        /// <returns></returns>
        public static Object GetObject(this Dictionary<string, object> dict, Type type)
        {
            var obj = Activator.CreateInstance(type);
            foreach (var kv in dict)
            {
                var prop = type.GetProperty(kv.Key);
                if(prop == null) continue;
                object value = kv.Value;
                if (value is Dictionary<string, object>)
                {
                    value = GetObject((Dictionary<string, object>)value, prop.PropertyType);
                }
                prop.SetValue(obj, value, null);
            }
            return obj;
        }
        /// <summary>
        /// Dictionary To 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        /// <returns>發生錯誤時候 回傳 default></returns>
        public static T DictionaryToModel<T>(this Dictionary<string, object> dict) where T : new()
        {
            T obj = new T();
            try
            {
                foreach (var item in dict)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(item.Key);
                    if (prop != null && prop.CanWrite)
                    {
                        Type propertType = prop.PropertyType;
                        //Type nullableType = GetNullableType(propertType);

                        if (item.Value == null || item.Value == DBNull.Value)
                        {
                            
                        }
                        else
                        {
                            //var value = Convert.ChangeType(item.Value, nullableType);
                            //prop.SetValue(obj, value, null);

                            if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                var value = Convert.ChangeType(item.Value, Nullable.GetUnderlyingType(prop.PropertyType));
                                prop.SetValue(obj, value, null);
                            }
                            else
                            {
                                var value = Convert.ChangeType(item.Value, prop.PropertyType);
                                prop.SetValue(obj, value, null);
                            }
                        }
                    }
                }
            }
            catch
            {
                obj = default;
            }
            return obj;
        }
        /// <summary>
        /// 取得轉換型態後的Type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetNullableType(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return type;
            }

            if (type.IsValueType is false)
            {
                return type;
            }

            return Nullable.GetUnderlyingType(type);
        }

        #endregion

        #region 抓取Class下所有巢狀Class屬性並扁平化成List
        /// <summary>
        /// 抓取Class下所有巢狀Class屬性並扁平化成List
        /// </summary>
        /// <param name="parentType">目標CLASS</param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> GetClassRecursiveClassAndSelectMany(Type parentType)
        {
            List<Dictionary<string, object>> returnResult = new List<Dictionary<string, object>>();
            try
            {
                var result = new Dictionary<string, object>();
                void ExtractRecursive(Type type, string prefix)
                {
                    var nestedTypes = type.GetNestedTypes(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var nested in nestedTypes)
                    {
                        string key = string.IsNullOrEmpty(prefix) ? nested.Name : $"{prefix}.{nested.Name}";
                        var ctor = nested.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                            .OrderByDescending(c => c.GetParameters().Length)
                            .FirstOrDefault();
                        if (ctor != null)
                        {
                            var parameters = ctor.GetParameters();
                            object[] args = parameters.Select(p => GetDummyValue(p.ParameterType)).ToArray();
                            try
                            {
                                object instance = ctor.Invoke(args);
                                if (result.ContainsKey(key) is false)
                                {
                                    result[key] = instance.GetType().GetProperties().ToDictionary(x => x.Name, x => instance.GetType().Name);
                                }
                                else
                                {
                                    returnResult.Add(result);
                                    result = new Dictionary<string, object>();
                                    //result[key] = instance.GetFieldValue();
                                    result[key] = instance.GetType().GetProperties().ToDictionary(x => x.Name, x => instance.GetType().Name);
                                }
                                ExtractRecursive(nested, key);
                            }
                            catch(Exception ex)
                            {
                                result[key] = $"[建立失敗:{ex.GetInnerException().ErrorMessage}]";
                            }
                        }
                        else
                        {
                            result[key] = $"[無可用建構子]";
                        }
                    }
                    
                }
                ExtractRecursive(parentType, "");
                returnResult.Add(result);
                return returnResult;
            }
            catch
            {
                throw;
            }
        }
        private static object GetDummyValue(Type type)
        {
            if (type == typeof(string)) return "Test";
            if (type == typeof(int)) return 42;
            if (type == typeof(bool)) return true;
            if (type.IsValueType) return Activator.CreateInstance(type);
            return null;
        }

        #endregion

        #region Class 屬性 Description 轉 Dictionary<string, string>
        /// <summary>
        /// Model轉換 CLASS.Description轉成Dictionary(PROPERTY_NAME, PROPERTY_DESCRIPTION)，找不到相對應的Description皆會預設為string.Empoty
        /// </summary>
        /// <typeparam name="T">CLASS</typeparam>
        /// <returns>(PROPERTY_NAME, PROPERTY_DESCRIPTION)</returns>
        public static Dictionary<string, string> GetClassDescriptionDictionary<T>()
            where T : class
        {
            try
            {
                //foreach (var prop in typeof(HeavySickRecord).GetProperties())
                //{
                //    object[] attrs = prop.GetCustomAttributes(true);
                //    foreach (var attr in attrs)
                //    {
                //        DescriptionAttribute da = attr as DescriptionAttribute;
                //        if (da != null)
                //        {
                //            var ssss = da.Description;
                //        }
                //    }
                //}
                //Dictionary<string, string> Class_Description = typeof(T).GetProperties()
                //.ToDictionary(p => p.Name, p => p.GetCustomAttributes(true).Count() > 0 ? ((DescriptionAttribute)p.GetCustomAttributes(true)?.FirstOrDefault()).Description : "");
                var Dict = new Dictionary<string, string>();
                Dict = typeof(T).GetProperties()
                .ToDictionary(p => p.Name, p => p.GetCustomAttributes(true).Count() > 0 ?  
                    (p.GetCustomAttributes(true).Any(x => x is DescriptionAttribute CM ) ? 
                        ((DescriptionAttribute)p.GetCustomAttributes(true).Where(x => x is DescriptionAttribute CM).FirstOrDefault()).Description : 
                        string.Empty ) : 
                string.Empty);
                return Dict;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Model轉換 CLASS.Display Name轉成Dictionary(PROPERTY_NAME, PROPERTY_Display Name)，找不到相對應的Display Name皆會預設為string.Empty
        /// </summary>
        /// <typeparam name="T">CLASS</typeparam>
        /// <returns>(PROPERTY_NAME, PROPERTY_Display Name)</returns>
        public static Dictionary<string, string> GetClassDisplayNameDictionary<T>()
            where T : class
        {
            try
            {
                var Dict = new Dictionary<string, string>();
                Dict = typeof(T).GetProperties()
                .ToDictionary(p => p.Name, p => !string.IsNullOrWhiteSpace(p.GetCustomAttribute<DisplayAttribute>()?.Name) ? p.GetCustomAttribute<DisplayAttribute>().Name : string.Empty);
                return Dict;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// Distinct 去除重複資料時，過濾指定成員屬性
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="Source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> Source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach(TSource element in Source)
            {
                var elementValue = keySelector(element);
                if (seenKeys.Add(elementValue))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// 二個Model相比，是否有異動欄位
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">原本Model</param>
        /// <param name="data">比較Model</param>
        /// <returns></returns>
        public static bool IsModify<T>(this T model, T data)
        {
            var result = false;
            #region 
            //var modelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //foreach (var prop in typeof(T).GetProperties())
            //{
            //    var modelValue = typeof(T).GetProperties()
            //        .Where(o => o.Name == prop.Name)
            //        .ToDictionary(p => p.Name, p => p.GetValue(model)).FirstOrDefault().Value;
            //    var dataValue = typeof(T).GetProperties()
            //        .Where(o => o.Name == prop.Name)
            //        .ToDictionary(p => p.Name, p => p.GetValue(data)).FirstOrDefault().Value;

            //    switch(prop.PropertyType.ToString().ToString().Split('.').Last().TrimEnd(']'))
            //    {
            //        case "Int32":
            //        case "Decimal":
            //        case "Single":
            //        case "Double":
            //            if (modelValue == null && dataValue != null)
            //            {
            //                return true;

            //            }
            //            else if (modelValue != null && dataValue == null)
            //            {
            //                return true;

            //            }
            //            else if(modelValue != null && dataValue != null
            //                && (double.Parse(modelValue?.ToString()) != double.Parse(dataValue?.ToString())))
            //            {
            //                return true;
            //            }

            //            break;
            //        case "DateTime":
            //            if (modelValue == null && dataValue != null)
            //            {
            //                return true;

            //            }
            //            else if (modelValue != null && dataValue == null)
            //            {
            //                return true;

            //            }
            //            else if (modelValue != null && dataValue != null
            //                && (((DateTime)modelValue).ToFullDateTime() != ((DateTime)dataValue).ToFullDateTime()))
            //            {
            //                return true;
            //            }
            //            break;
            //        default:
            //            if (modelValue?.ToString() != dataValue?.ToString())
            //            {
            //                return true;
            //            }

            //            break;
            //    }
            //}
            #endregion 

            var modifyResult = model.ModifyList(data);

            if (modifyResult.Any())
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 取得修改清單(IDictionary&lt;string, object&gt;使用)
        /// </summary>
        /// <typeparam name="T">IDictionary&lt;string, object&gt;</typeparam>
        /// <param name="model">原始資料Dictionary</param>
        /// <param name="data">修改資料Dictionary</param>
        /// <param name="modelColumnType">Dictionary對照表[Key=ColumnName,Value=Oracle Column_Data_Type]</param>
        /// <returns></returns>
        public static ServiceResult<List<(string Column, string ChangeNote)>> ModifyDictioary<T>(this T model, T data, Dictionary<string, string> modelColumnType)
            where T : class
        {
            ServiceResult<List<(string Column, string ChangeNote)>> returnResult = new ServiceResult<List<(string Column, string ChangeNote)>>(false, string.Empty, new List<(string Column, string ChangeNote)>());
            try
            {
                IDictionary<string, object> modelSource = null;
                IDictionary<string, object> dataSource = null;
                try
                {
                    modelSource = model as IDictionary<string, object>;
                    dataSource = data as IDictionary<string, object>;
                }
                catch(Exception ex)
                {
                    var InnerEx = ex.GetInnerException();
                    returnResult.Message += "Dictionary資料陣列轉換失敗[THROW]:" + InnerEx.ErrorMessage + Environment.NewLine;
                    returnResult.Exception = ex;
                }
                List<(string ColumnName, object ColumnValue, OracleDbType DbType)> modelInfoList = new List<(string, object, OracleDbType)>();
                List<(string ColumnName, object ColumnValue, OracleDbType DbType)> dataInfoList = new List<(string, object, OracleDbType)>();

                if (modelSource != null)
                {
                    foreach (KeyValuePair<string, object> item in modelSource)
                    {
                        if (modelColumnType != null && modelColumnType.Any(x => x.Key == item.Key))
                        {
                            modelInfoList.Add((item.Key, item.Value, modelColumnType.FirstOrDefault(x => x.Key == item.Key).Value.GetOracleDbType()));
                        }
                    }
                }
                if (dataSource != null)
                {
                    foreach (KeyValuePair<string, object> item in dataSource)
                    {
                        if (modelColumnType != null && modelColumnType.Any(x => x.Key == item.Key))
                        {
                            dataInfoList.Add((item.Key, item.Value, modelColumnType.FirstOrDefault(x => x.Key == item.Key).Value.GetOracleDbType()));
                        }
                    }
                }
                foreach (var modelItem in modelInfoList)
                {
                    var dataItem = dataInfoList.Any(x => x.ColumnName == modelItem.ColumnName) ?
                        dataInfoList.FirstOrDefault(x => x.ColumnName == modelItem.ColumnName) : (string.Empty, null, OracleDbType.Varchar2);
                    // Inference of DbType, OracleDbType, and .NET Types
                    // https://docs.oracle.com/cd/B19306_01/win.102/b14307/featOraCommand.htm#i1007432
                    //.Net 資料庫 型態轉換 點部落
                    //http://webcache.googleusercontent.com/search?q=cache:QXFyG3VQ2h4J:https://www.dotblogs.com.tw/timothy/2014/06/11/145500&sca_esv=569007408&hl=zh-TW&gl=tw&strip=1&vwsrc=0
                    if (!string.IsNullOrWhiteSpace(modelItem.ColumnName))
                    {
                        switch (modelItem.DbType) 
                        {
                            case OracleDbType.Varchar2:
                            case OracleDbType.NVarchar2:
                            case OracleDbType.Char:
                            case OracleDbType.NChar:
                            case OracleDbType.NClob:
                            case OracleDbType.Long:
                            case OracleDbType.XmlType:
                                var modelValueString = modelItem.ColumnValue as String;
                                var dataValueString = dataItem.ColumnValue as String;
                                if (string.IsNullOrEmpty(modelValueString) && string.IsNullOrEmpty(dataValueString) == false)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueString?.ToString()}"));
                                }
                                else if (string.IsNullOrEmpty(modelValueString) == false && string.IsNullOrEmpty(dataValueString))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueString?.ToString()} → Null"));
                                }
                                else if (string.IsNullOrEmpty(modelValueString) == false && string.IsNullOrEmpty(dataValueString) == false && (modelValueString != dataValueString))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueString?.ToString()} → {dataValueString?.ToString()}"));
                                }
                                break;
                            case OracleDbType.Date:
                            case OracleDbType.TimeStamp:
                            case OracleDbType.TimeStampLTZ:
                            case OracleDbType.TimeStampTZ:
                                var modelValueDateTime = modelItem.ColumnValue as DateTime?;
                                var dataValueDateTime = dataItem.ColumnValue as DateTime?;
                                if (modelValueDateTime.HasValue == false && dataValueDateTime.HasValue)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueDateTime?.ToString()}"));
                                }
                                else if (modelValueDateTime.HasValue && dataValueDateTime.HasValue == false)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDateTime?.ToString()} → Null"));
                                }
                                else if (modelValueDateTime.HasValue && dataValueDateTime.HasValue && (modelValueDateTime.Value.ToFullDateTimeMillisecond() != dataValueDateTime.Value.ToFullDateTimeMillisecond()))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDateTime.Value.ToFullDateTimeMillisecond()} → {dataValueDateTime.Value.ToFullDateTimeMillisecond()}"));
                                }
                                break;
                            case OracleDbType.Decimal:
                                var modelValueDecimal = modelItem.ColumnValue as Decimal?;
                                var dataValueDecimal = dataItem.ColumnValue as Decimal?;
                                if (modelValueDecimal == null && dataValueDecimal != null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueDecimal?.ToString()}"));
                                }
                                else if (modelValueDecimal != null && dataValueDecimal == null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDecimal?.ToString()} → Null"));
                                }
                                else if (modelValueDecimal != null && dataValueDecimal != null && (modelValueDecimal != dataValueDecimal))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDecimal?.ToString()} → {dataValueDecimal?.ToString()}"));
                                }
                                break;
                            case OracleDbType.BinaryDouble:
                            case OracleDbType.Double:
                                if (modelItem.ColumnValue as Double? == null && dataItem.ColumnValue as Double? == null)
                                {
                                    var modelValueDouble = modelItem.ColumnValue as decimal?;
                                    var dataValueDouble = dataItem.ColumnValue as decimal?;
                                    if (modelValueDouble == null && dataValueDouble != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueDouble?.ToString()}"));
                                    }
                                    else if (modelValueDouble != null && dataValueDouble == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDouble?.ToString()} → Null"));
                                    }
                                    else if (modelValueDouble != null && dataValueDouble != null && (modelValueDouble != dataValueDouble))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDouble?.ToString()} → {dataValueDouble?.ToString()}"));
                                    }
                                }
                                else
                                {
                                    var modelValueDouble = modelItem.ColumnValue as Double?;
                                    var dataValueDouble = dataItem.ColumnValue as Double?;
                                    if (modelValueDouble == null && dataValueDouble != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueDouble?.ToString()}"));
                                    }
                                    else if (modelValueDouble != null && dataValueDouble == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDouble?.ToString()} → Null"));
                                    }
                                    else if (modelValueDouble != null && dataValueDouble != null && (modelValueDouble != dataValueDouble))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDouble?.ToString()} → {dataValueDouble?.ToString()}"));
                                    }
                                }
                                break;
                            case OracleDbType.BinaryFloat:
                            case OracleDbType.Single:
                                //如果轉換Float失敗則改轉換成Decimal
                                if(modelItem.ColumnValue as float? == null && dataItem.ColumnValue as float? == null)
                                {
                                    var modelValueFloat = modelItem.ColumnValue as decimal?;
                                    var dataValueFloat = dataItem.ColumnValue as decimal?;
                                    if (modelValueFloat == null && dataValueFloat != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueFloat?.ToString()}"));
                                    }
                                    else if (modelValueFloat != null && dataValueFloat == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueFloat?.ToString()} → Null"));
                                    }
                                    else if (modelValueFloat != null && dataValueFloat != null && (modelValueFloat != dataValueFloat))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueFloat?.ToString()} → {dataValueFloat?.ToString()}"));
                                    }
                                }
                                else
                                {
                                    var modelValueFloat = modelItem.ColumnValue as float?;
                                    var dataValueFloat = dataItem.ColumnValue as float?;
                                    if (modelValueFloat == null && dataValueFloat != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueFloat?.ToString()}"));
                                    }
                                    else if (modelValueFloat != null && dataValueFloat == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueFloat?.ToString()} → Null"));
                                    }
                                    else if (modelValueFloat != null && dataValueFloat != null && (modelValueFloat != dataValueFloat))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueFloat?.ToString()} → {dataValueFloat?.ToString()}"));
                                    }
                                }
                                break;
                            case OracleDbType.Int16:
                                if (modelItem.ColumnValue as Int16? == null && dataItem.ColumnValue as Int16? == null)
                                {
                                    var modelValueInt16 = modelItem.ColumnValue as decimal?;
                                    var dataValueInt16 = dataItem.ColumnValue as decimal?;
                                    if (modelValueInt16 == null && dataValueInt16 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt16?.ToString()}"));
                                    }
                                    else if (modelValueInt16 != null && dataValueInt16 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt16?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt16 != null && dataValueInt16 != null && (modelValueInt16 != dataValueInt16))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt16?.ToString()} → {dataValueInt16?.ToString()}"));
                                    }
                                }
                                else
                                {
                                    var modelValueInt16 = modelItem.ColumnValue as Int16?;
                                    var dataValueInt16 = dataItem.ColumnValue as Int16?;
                                    if (modelValueInt16 == null && dataValueInt16 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt16?.ToString()}"));
                                    }
                                    else if (modelValueInt16 != null && dataValueInt16 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt16?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt16 != null && dataValueInt16 != null && (modelValueInt16 != dataValueInt16))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt16?.ToString()} → {dataValueInt16?.ToString()}"));
                                    }
                                }
                                break;
                            case OracleDbType.Int32:
                                if (modelItem.ColumnValue as Double? == null && dataItem.ColumnValue as Double? == null)
                                {
                                    var modelValueInt32 = modelItem.ColumnValue as decimal?;
                                    var dataValueInt32 = dataItem.ColumnValue as decimal?;
                                    if (modelValueInt32 == null && dataValueInt32 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt32?.ToString()}"));
                                    }
                                    else if (modelValueInt32 != null && dataValueInt32 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt32?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt32 != null && dataValueInt32 != null && (modelValueInt32 != dataValueInt32))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt32?.ToString()} → {dataValueInt32?.ToString()}"));
                                    }
                                }
                                else
                                {
                                    var modelValueInt32 = modelItem.ColumnValue as Int32?;
                                    var dataValueInt32 = dataItem.ColumnValue as Int32?;
                                    if (modelValueInt32 == null && dataValueInt32 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt32?.ToString()}"));
                                    }
                                    else if (modelValueInt32 != null && dataValueInt32 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt32?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt32 != null && dataValueInt32 != null && (modelValueInt32 != dataValueInt32))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt32?.ToString()} → {dataValueInt32?.ToString()}"));
                                    }
                                }
                                break;
                            case OracleDbType.Int64:
                                if (modelItem.ColumnValue as Double? == null && dataItem.ColumnValue as Double? == null)
                                {
                                    var modelValueInt64 = modelItem.ColumnValue as decimal?;
                                    var dataValueInt64 = dataItem.ColumnValue as decimal?;
                                    if (modelValueInt64 == null && dataValueInt64 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt64?.ToString()}"));
                                    }
                                    else if (modelValueInt64 != null && dataValueInt64 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt64?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt64 != null && dataValueInt64 != null && (modelValueInt64 != dataValueInt64))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt64?.ToString()} → {dataValueInt64?.ToString()}"));
                                    }
                                }
                                else
                                {
                                    var modelValueInt64 = modelItem.ColumnValue as Int64?;
                                    var dataValueInt64 = dataItem.ColumnValue as Int64?;
                                    if (modelValueInt64 == null && dataValueInt64 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt64?.ToString()}"));
                                    }
                                    else if (modelValueInt64 != null && dataValueInt64 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt64?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt64 != null && dataValueInt64 != null && (modelValueInt64 != dataValueInt64))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt64?.ToString()} → {dataValueInt64?.ToString()}"));
                                    }
                                }
                                break;
                            case OracleDbType.Boolean:
                                var modelValueBool = modelItem.ColumnValue as Boolean?;
                                var dataValueBool = dataItem.ColumnValue as Boolean?;
                                if (modelValueBool == null && dataValueBool != null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueBool?.ToString()}"));
                                }
                                else if (modelValueBool != null && dataValueBool == null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueBool?.ToString()} → Null"));
                                }
                                else if (modelValueBool != null && dataValueBool != null && (modelValueBool != dataValueBool))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueBool?.ToString()} → {dataValueBool?.ToString()}"));
                                }
                                break;
                            case OracleDbType.Byte:
                                //暫時不知道該如何呈現~故直接轉換成object輸出
                            case OracleDbType.LongRaw:
                            case OracleDbType.BFile:
                            case OracleDbType.Clob:
                            case OracleDbType.Raw:
                            case OracleDbType.RefCursor:
                            default:
                                var modelValueObject = modelItem.ColumnValue;
                                var dataValueObject = dataItem.ColumnValue;
                                if (modelValueObject == null && dataValueObject != null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueObject?.ToString()}"));
                                }
                                else if (modelValueObject != null && dataValueObject == null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueObject?.ToString()} → Null"));
                                }
                                else if (modelValueObject != null && dataValueObject != null && (modelValueObject != dataValueObject))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueObject?.ToString()} → {dataValueObject?.ToString()}"));
                                }
                                break;
                        }
                    }
                }
                if (modelSource != null && dataSource != null && modelColumnType != null && modelInfoList.Any())
                {
                    returnResult.IsOk = true;
                    returnResult.Message += $"原始資料總數[{modelInfoList.Count}]" + Environment.NewLine +
                        $"修改資料總數[{modelInfoList.Count}]" + Environment.NewLine +
                        $"Dictionary對照表總數[{modelColumnType.Count}]" + Environment.NewLine +
                        $"全部資料比對完成.";
                }
                else
                {
                    returnResult.IsOk = false;
                    returnResult.Message += modelSource == null ? $"[原始資料陣列為Null]" + Environment.NewLine : string.Empty;
                    returnResult.Message += dataSource == null ? $"[修改資料陣列為Null]" + Environment.NewLine : string.Empty;
                    returnResult.Message += modelColumnType == null ? $"[修改資料陣列為Null]" + Environment.NewLine : string.Empty;
                }
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message += "[THROW]:" + ex.Message + Environment.NewLine ;
            }
            return returnResult;
        }

        /// <summary>
        /// 取得修改清單(List)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">原始資料</param>
        /// <param name="data">修改資料</param>
        /// <returns></returns>
        public static List<(string Column, string ChangeNote, string ColumnDisplayName)> ModifyList<T>(this T model, T data)
        {
            var resultData = new List<(string Column, string ChangeNote, string ColumnDisplayName)>();

            try
            {
                var modelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var prop in typeof(T).GetProperties())
                {
                    var modelValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(model)).FirstOrDefault().Value;
                    var dataValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(data)).FirstOrDefault().Value;

                    var modelDisplayName = prop.GetCustomAttribute<DisplayAttribute>()?.Name ?? prop.Name;

                    switch (prop.PropertyType.ToString().ToString().Split('.').Last().TrimEnd(']'))
                    {
                        case "Int32":
                        case "Decimal":
                        case "Single":
                        case "Double":
                            if (modelValue == null && dataValue != null)
                            {
                                resultData.Add((prop.Name, $@"Null → {dataValue?.ToString()}", modelDisplayName));
                            }
                            else if (modelValue != null && dataValue == null)
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString()} → Null", modelDisplayName));
                            }
                            else if (modelValue != null && dataValue != null
                                && (double.Parse(modelValue?.ToString()) != double.Parse(dataValue?.ToString())))
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString()} → {dataValue?.ToString()}", modelDisplayName));
                            }

                            break;
                        case "DateTime":
                            if (modelValue == null && dataValue != null)
                            {
                                resultData.Add((prop.Name, $@"Null → {((DateTime)dataValue).ToFullDateTime()}", modelDisplayName));
                            }
                            else if (modelValue != null && dataValue == null)
                            {
                                //return true;
                                resultData.Add((prop.Name, $@"{((DateTime)modelValue).ToFullDateTime()} → Null", modelDisplayName));
                            }
                            else if (modelValue != null && dataValue != null
                                && (((DateTime)modelValue).ToFullDateTime() != ((DateTime)dataValue).ToFullDateTime()))
                            {
                                //return true;
                                resultData.Add((prop.Name, $@"{((DateTime)modelValue).ToFullDateTime()} → {((DateTime)dataValue).ToFullDateTime()}", modelDisplayName));
                            }
                            break;
                        default:
                            if (modelValue?.ToString() != dataValue?.ToString() &&( string.IsNullOrWhiteSpace(modelValue?.ToString()) == false || string.IsNullOrWhiteSpace(dataValue?.ToString()) == false))
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString() ?? "Null"} → {dataValue?.ToString() ?? "Null"}", modelDisplayName));
                            }

                            break;
                    }
                }

                return resultData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 取得修改清單(List)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">原始資料</param>
        /// <param name="data">修改資料</param>
        /// <returns>List&lt;(string Column, string ChangeNote, string ColumnDisplayName, object SourceValue, object ModifyValue)&gt;</returns>
        public static List<(string Column, string ChangeNote, string ColumnDisplayName, object SourceValue, object ModifyValue)> ModifyList_Extract<T>(this T model, T data)
        {
            var resultData = new List<(string Column, string ChangeNote, string ColumnDisplayName, object SourceValue, object ModifyValue)>();

            try
            {
                var modelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var prop in typeof(T).GetProperties())
                {
                    var modelValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(model)).FirstOrDefault().Value;
                    var dataValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(data)).FirstOrDefault().Value;

                    var modelDisplayName = prop.GetCustomAttribute<DisplayAttribute>()?.Name ?? prop.Name;

                    switch (prop.PropertyType.ToString().ToString().Split('.').Last().TrimEnd(']'))
                    {
                        case "Int32":
                        case "Decimal":
                        case "Single":
                        case "Double":
                            if (modelValue == null && dataValue != null)
                            {
                                resultData.Add((prop.Name, $@"Null → {dataValue?.ToString()}", modelDisplayName, modelValue, dataValue));
                            }
                            else if (modelValue != null && dataValue == null)
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString()} → Null", modelDisplayName, modelValue, dataValue));
                            }
                            else if (modelValue != null && dataValue != null
                                && (double.Parse(modelValue?.ToString()) != double.Parse(dataValue?.ToString())))
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString()} → {dataValue?.ToString()}", modelDisplayName, modelValue, dataValue));
                            }

                            break;
                        case "DateTime":
                            if (modelValue == null && dataValue != null)
                            {
                                resultData.Add((prop.Name, $@"Null → {((DateTime)dataValue).ToFullDateTime()}", modelDisplayName, modelValue, dataValue));
                            }
                            else if (modelValue != null && dataValue == null)
                            {
                                //return true;
                                resultData.Add((prop.Name, $@"{((DateTime)modelValue).ToFullDateTime()} → Null", modelDisplayName, modelValue, dataValue));
                            }
                            else if (modelValue != null && dataValue != null
                                && (((DateTime)modelValue).ToFullDateTime() != ((DateTime)dataValue).ToFullDateTime()))
                            {
                                //return true;
                                resultData.Add((prop.Name, $@"{((DateTime)modelValue).ToFullDateTime()} → {((DateTime)dataValue).ToFullDateTime()}", modelDisplayName, modelValue, dataValue));
                            }
                            break;
                        default:
                            if (modelValue?.ToString() != dataValue?.ToString() && (string.IsNullOrWhiteSpace(modelValue?.ToString()) == false || string.IsNullOrWhiteSpace(dataValue?.ToString()) == false))
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString() ?? "Null"} → {dataValue?.ToString() ?? "Null"}", modelDisplayName, modelValue, dataValue));
                            }

                            break;
                    }
                }

                return resultData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改清單
        /// </summary>
        /// <typeparam name="TKey">string</typeparam>
        /// <typeparam name="TValue">object</typeparam>
        /// <param name="model">原始</param>
        /// <param name="data">修改</param>
        /// <returns></returns>
        public static ServiceResult<List<(string Column, string ChangeNote, string ColumnDisplayName)>> ModifyDic_Interface<TKey, TValue>(
            this Dictionary<TKey, TValue> model,
            Dictionary<TKey, TValue> data)
        {
            ServiceResult<List<(string Column, string ChangeNote, string ColumnDisplayName)>> returnResult = 
                new ServiceResult<List<(string Column, string ChangeNote, string ColumnDisplayName)>>
                (false, string.Empty, new List<(string Column, string ChangeNote, string ColumnDisplayName)>()); ;
            try
            {
                var result = model.ModifyDic(data);
                if(result != null)
                {
                    returnResult.Data.AddRange(result);
                    returnResult.IsOk = true;
                }
                else
                {
                    returnResult.Message += "修改清單回傳Null";
                }
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                var errorException = ex.GetInnerException(); 
                returnResult.Message += "[THROW]:" + errorException.ErrorMessage + Environment.NewLine;
                returnResult.Exception = ex;
            }
            return returnResult;
        }

        /// <summary>
        /// 取得修改清單
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="model">原始</param>
        /// <param name="data">修改</param>
        /// <returns></returns>
        public static List<(string Column, string ChangeNote, string ColumnDisplayName)> ModifyDic<TKey, TValue>(
            this Dictionary<TKey, TValue> model,
            Dictionary<TKey, TValue> data)
        {
            var resultData = new List<(string Column, string ChangeNote, string ColumnDisplayName)>();

            try
            {
                foreach (var key in model.Keys)
                {
                    if (!data.TryGetValue(key, out TValue dataValue))
                        continue;

                    var modelValue = model[key];

                    if (modelValue == null && dataValue != null)
                    {
                        resultData.Add((key.ToString(), $@"Null → {dataValue?.ToString()}", key.ToString()));
                    }
                    else if (modelValue != null && dataValue == null)
                    {
                        resultData.Add((key.ToString(), $@"{modelValue?.ToString()} → Null", key.ToString()));
                    }
                    else if (modelValue != null && dataValue != null && !modelValue.Equals(dataValue))
                    {
                        resultData.Add((key.ToString(), $@"{modelValue?.ToString()} → {dataValue?.ToString()}", key.ToString()));
                    }
                }

                return resultData;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 二個Model相比，返回有異動欄位的Dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SourceModel">原始Model</param>
        /// <param name="Data">欲比較之Model</param>
        /// <returns></returns>
        private static ServiceResult<Dictionary<string, object>> IsModifyDictionary<T>(this T SourceModel, T Data)
        {
            ServiceResult<Dictionary<string, object>> ReturnResult = new ServiceResult<Dictionary<string, object>>(true, string.Empty, new Dictionary<string, object>());
            try
            {
                Regex stringRegex = new Regex("string");
                Regex datetimeRegex = new Regex("datetime");
                Regex singleRegex = new Regex("single");
                Regex doubleRegex = new Regex("double");
                Regex decimalRegex = new Regex("decimal");
                Regex intRegex = new Regex("int");
                var SourceModelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var prop in SourceModelInfos)
                {
                    var sourceValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(SourceModel)).FirstOrDefault().Value?.ToString();
                    var dataValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(Data)).FirstOrDefault().Value;
                    Type dataValueType = dataValue?.GetType();
                        //typeof(T).GetProperties()
                        //.Where(o => o.Name == prop.Name)
                        //.ToDictionary(p => p.Name, p => p.GetValue(Data)).FirstOrDefault().Value?.GetType();
                    if (sourceValue != dataValue?.ToString())
                    {
                        if (stringRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as String);
                        }
                        else if (datetimeRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as DateTime?);
                        }
                        else if (singleRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as Single?);
                        }
                        else if (doubleRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as Double?);
                        }
                        else if (decimalRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as Decimal?);
                        }
                        else if (intRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as Int32?);
                        }
                        else
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ReturnResult.IsOk = false;
                ReturnResult.Message = "Throw:" + ex.Message;
            }
            return ReturnResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="newline"></param>
        /// <returns></returns>
        public static string Display(this IEnumerable<string> Source,bool newline = true)
        {
            string result = "";

            foreach (string item in Source)
            {
                result += $"【{item}】";
                if (newline)
                    result += Environment.NewLine;
            }

            return result;
        }

        #region 轉換 使用','間隔的資料 To 特定Model
        /// <summary>
        /// 常用日期格式清單(西元為主) 
        /// </summary>
        private static readonly string[] CommonDateFormats = new[]
        {
            "yyyyMM",
            "yyyyMMdd",
            "yyyyMMddHHmm",
            "yyyyMMddHHmmss",
            "yyyy-MM-dd",
            "yyyy/MM/dd",
            "yyyy-MM-dd HH:mm",
            "yyyy/MM/dd HH:mm",
            "yyyy-MM-dd HH:mm:ss",
            "yyyy/MM/dd HH:mm:ss"
        };

        /// <summary>
        /// 轉換 使用','間隔的資料 To 特定Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T ConvertToModel<T>(string data) where T : new()
        {
            var model = new T();
            var fields = data.Split(',');
            var properties = typeof(T).GetProperties();
            

            for (int i = 0; i < properties.Length && i < fields.Length; i++)
            {
                var property = properties[i];
                var propertyType = property.PropertyType;
                var underlyingType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
                var raw = fields[i]?.Trim();
                if (string.IsNullOrWhiteSpace(raw))
                {
                    if (!propertyType.IsValueType || Nullable.GetUnderlyingType(propertyType) != null)
                    {
                        property.SetValue(model, null);
                    }
                    else
                    {
                        // 非 Nullable 的值型別 → 保持預設值 (new T() 的初始值)，直接跳過
                        // 如果想要特別設 0 或 default，也可以寫：
                        // var defaultValue = Activator.CreateInstance(propertyType);
                        // property.SetValue(model, defaultValue);
                    }
                    continue;
                }
                object value;
                try
                {
                    if (underlyingType.IsEnum)
                    {
                        value = Enum.Parse(underlyingType, raw, true);
                    }
                    else if (underlyingType == typeof(DateTime))
                    {
                        if (DateTime.TryParseExact(raw, CommonDateFormats, CultureInfo.InvariantCulture,
                                DateTimeStyles.None, out var dt))
                        {
                            value = dt;
                        }
                        else
                        {
                            if (Nullable.GetUnderlyingType(propertyType) != null)
                            {
                                value = null;
                            }
                            else
                            {
                                // 非 Nullable DateTime，格式不符 → 不設值，直接略過，避免造成THROW
                                continue;
                            }
                        }
                    }
                    else
                    {
                        // 一般型別直接用 ChangeType
                        value = Convert.ChangeType(raw, underlyingType, CultureInfo.InvariantCulture);
                    }
                    property.SetValue(model, value);
                }
                catch
                {

                }
            }
            return model;
        }
        /// <summary>
        /// 轉換 使用','間隔的資料 To 特定List&lt;Model&gt;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataList"></param>
        /// <returns></returns>
        public static List<T> ConvertListToModel<T>(List<string> dataList) where T : new()
        {
            var modelList = new List<T>();
            foreach (var data in dataList)
            {
                modelList.Add(ConvertToModel<T>(data));
            }
            return modelList;
        }

        #endregion

    }
}
