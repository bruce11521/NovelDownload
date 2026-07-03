using System;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CoreBase.Utilities
{
    /// <summary>
    /// Newtonsoft.Json JsonConvert.SerializeObject 時，使用這個 ContractResolver 可以同時忽略掉 null 和空字串的屬性，讓輸出的 JSON 更精簡
    /// </summary>
    public class JsonIgnoreNullAndStringResolver : DefaultContractResolver
    {

        /// <summary>
        ///  自訂的過濾器類別，
        /// 使用這個 ContractResolver 可以同時忽略掉 null 和空字串的屬性，讓輸出的 JSON 更精簡
        /// 使用範例如下:
        /// var settings = new JsonSerializerSettings{ ContractResolver = new JsonIgnoreNullAndStringResolver() }
        /// </summary>
        /// <param name="member"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            // 針對字串型態的欄位進行客製化檢查
            if (property.PropertyType == typeof(string))
            {
                property.ShouldSerialize = instance =>
                {
                    // 取得目前該屬性的實質數值
                    string value = property.ValueProvider.GetValue(instance) as string;
                    // 只有當數值「不是 null」且「不是空字串」時，才允許序列化輸出
                    return !string.IsNullOrEmpty(value);
                };
            }
            else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
            {
                property.ShouldSerialize = instance =>
                {
                    var collection = property.ValueProvider.GetValue(instance) as IEnumerable;
                    if (collection == null) return false;

                    // 檢查這個集合裡面，是否「存在」任何一個不是 null 且不是空字串的實質內容
                    foreach (var item in collection)
                    {
                        if (item != null)
                        {
                            // 如果裡面包的是字串，進一步檢查是否為空字串
                            if (item is string str && string.IsNullOrEmpty(str))
                                continue;

                            // 只要找到任意一個欄位有實質資料 (例如有數字、有其他物件)，這個陣列就必須保留
                            return true;
                        }
                    }

                    // 繞完一圈發現裡面全都是 null 或空字串，或者根本是空的 (Count = 0)，直接隱藏不輸出
                    return false;
                };
            }
            //針對所有欄位：如果是 null，一律忽略
            property.NullValueHandling = NullValueHandling.Ignore;
            return property;
            //return base.CreateProperty(member, memberSerialization);
        }
    }
    /// <summary>
    /// 處理深層物件或陣列內部「空字串轉為 null」進而觸發忽略的轉換器
    /// </summary>
    public class FilterEmptyStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // 只處理字串型態
            return objectType == typeof(string);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string str = value as string;
            if (string.IsNullOrEmpty(str))
            {
                // 如果是空字串，輸出為 null，配合全域 Ignore 就會被抹除
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(str);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value?.ToString();
        }
    }
}
