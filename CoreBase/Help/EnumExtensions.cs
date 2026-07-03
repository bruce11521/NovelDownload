using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace CoreBase.Help
{
    /// <summary>
    /// Enum型態擴充功能
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Enum 擴充方法, 取得 Enum Value 並轉成字串
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Enum Value</returns>
        public static string ToNumberString(this Enum enumType)
        {
            return Convert.ToInt32(enumType, CultureInfo.CurrentCulture).ToString(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Enum 擴充方法, 取得 Enum Value 並轉成數字
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Enum Value</returns>
        public static int ToNumberValue(this Enum enumType)
        {
            return Convert.ToInt32(enumType, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Enum 擴充方法, 取得 Enum Value 並轉成布林值
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Enum Value</returns>
        public static bool ToBooleanValue(this Enum enumType)
        {
            return Convert.ToBoolean(enumType.ToNumberValue());
        }

        /// <summary>
        /// Enum 擴充方法，GetDisplay.Name
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Enum Display.Name</returns>
        public static string GetEnumDisplayName(this Enum enumType)
        {
            var i = enumType.GetType().GetMember(enumType.ToString())
                ?.FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>();

            return i == null ? string.Empty : i?.GetName() ?? string.Empty;
        }

        /// <summary>
        /// Enum 擴充方法，GetEnumDisplay.GroupName
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Enum Display.GroupName</returns>
        public static string GetEnumDisplayGroupName(this Enum enumType)
        {
            var i = enumType.GetType().GetMember(enumType.ToString())
                ?.FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>();

            return i == null ? string.Empty : i?.GetGroupName() ?? string.Empty;
        }

        /// <summary>
        /// Enum 擴充方法，GetEnumDisplay.Order
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Enum Display.Order</returns>
        public static int GetEnumDisplayOrder(this Enum enumType)
        {
            var i = enumType.GetType().GetMember(enumType.ToString())
                ?.FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>();

            return i == null ? 0 : i?.GetOrder() ?? 0;
        }

        /// <summary>
        /// Enum 擴充方法，GetEnumDisplay.AutoGenerateField
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Enum Display.AutoGenerateField</returns>
        public static bool GetEnumDisplayAutoGenerateField(this Enum enumType)
        {
            var i = enumType.GetType().GetMember(enumType.ToString())
                ?.FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>();
            if (i is null)
            {
                return false;
            }
            else
            {
                if (i?.GetAutoGenerateField().HasValue is true)
                {
                    return i.GetAutoGenerateField().Value;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Enum 擴充方法，GetEnumDisplay.AutoGenerateFilter
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Enum Display.AutoGenerateFilter</returns>
        public static bool GetEnumDisplayAutoGenerateFilter(this Enum enumType)
        {
            var i = enumType.GetType().GetMember(enumType.ToString())
                ?.FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>();
            if (i is null)
            {
                return false;
            }
            else
            {
                if (i?.GetAutoGenerateFilter().HasValue is true)
                {
                    return i.GetAutoGenerateFilter().Value;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Enum 擴充方法，GetDisplay.Description
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Enum Display.Description</returns>
        public static string GetEnumDisplayDescription(this Enum enumType)
        {
            var i = enumType.GetType().GetMember(enumType.ToString())
                ?.FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>();

            return i == null ? string.Empty : i?.GetDescription() ?? string.Empty;
        }

        /// <summary>
        /// Enum 擴充方法，GetDisplay.ShortName
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Enum Display.ShortName</returns>
        public static string GetEnumDisplayShortName(this Enum enumType)
        {
            var i = enumType.GetType().GetMember(enumType.ToString())
                ?.FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>();

            return i == null ? string.Empty : i?.GetShortName() ?? string.Empty;
        }

        /// <summary>
        /// Enum 擴充方法，GetDisplay.Prompt
        /// </summary>
        /// <param name="enumType">Enum</param>
        /// <returns>Enum Display.Prompt</returns>
        public static string GetEnumDisplayPrompt(this Enum enumType)
        {
            var i = enumType.GetType().GetMember(enumType.ToString())
                ?.FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>();

            return i == null ? string.Empty : i?.GetPrompt() ?? string.Empty;
        }

        /// <summary>
        ///  Enum 擴充方法，Get Description
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum value)     //取Enum中的字串
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null)
            {
                return string.Empty;
            }

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if ((attributes != null) && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        /// <summary>
        /// Enum 轉為 Dictionary
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> GetDictionary<T>()
            where T : struct
        {
            var itemDict = new Dictionary<int, string>();

            foreach (T eVal in Enum.GetValues(typeof(T)))
            {
                FieldInfo fi = eVal.GetType().GetField(eVal.ToString());
                DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);
                itemDict.Add(Convert.ToInt32(eVal, CultureInfo.CurrentCulture), attributes[0].Name);
            }

            return itemDict;
        }

        /// <summary>
        /// Enum 轉為 Dictionary
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static Dictionary<string, string> GetDictionaryString<T>()
            where T : struct
        {
            var itemDict = new Dictionary<string, string>();

            foreach (T eVal in Enum.GetValues(typeof(T)))
            {
                FieldInfo fi = eVal.GetType().GetField(eVal.ToString());
                DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);
                if (attributes.Length > 0)
                {
                    itemDict.Add(fi.Name, attributes[0].Name);
                }
            }

            return itemDict;
        }

        /// <summary>
        /// Enum 轉為 List
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns>List of Enum</returns>
        public static List<T> ToList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList<T>();
        }
    }
}
