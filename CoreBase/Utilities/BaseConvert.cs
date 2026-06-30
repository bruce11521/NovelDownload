using System;

namespace CoreBase.Utilities
{
    /// <summary>
    /// 通用Enum轉換
    /// </summary>
    public static class BaseConvert
    {
        /// <summary>
        /// 取得性別的名稱
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetGenderDisplay(this int value)
        {
            var result = string.Empty;
            var dic = EnumExtensions.GetDictionary<Sex>();
            if (dic.TryGetValue(value, out string display))
            {
                result = display;
            }
            else
            {
                result = Sex.NonBinary.GetEnumDisplayName();
            }

            return result;
        }

        /// <summary>
        /// 取得性別的名稱
        /// (以Enum的Name或Value)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetGenderDisplay(this string value)
        {
            var result = string.Empty;
            var dic = EnumExtensions.GetDictionaryString<Sex>();
            if (int.TryParse(value, out int intValue))
            {
                result = intValue.GetGenderDisplay();
            }
            else if (dic.TryGetValue(value ?? string.Empty, out string display))
            {
                result = display;
            }

            return result;
        }

        /// <summary>
        /// 取得就醫來源名稱
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetVisitKindDisplay(this int value)
        {
            var result = string.Empty;
            var dic = EnumExtensions.GetDictionary<VISITKIND>();
            if (dic.TryGetValue(value, out string display))
            {
                result = display;
            }

            return result;
        }

        /// <summary>
        /// 取得就醫來源名稱
        /// (以Enum的Name或Value)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetVisitKindDisplay(this string value)
        {
            var result = string.Empty;
            var dic = EnumExtensions.GetDictionaryString<VISITKIND>();
            if (int.TryParse(value, out int intValue))
            {
                result = intValue.GetVisitKindDisplay();
            }
            else if (dic.TryGetValue(value ?? string.Empty, out string display))
            {
                result = display;
            } 

            return result;
        }

        /// <summary>
        /// intString(value) || string(Name) 取得DisplayName
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string IntStringGetDisplayName<TEnum>(this string value)
            where TEnum : struct, IConvertible
        {
            var result = string.Empty;
            var dic = EnumExtensions.GetDictionaryString<TEnum>();
            if (dic.TryGetValue(value ?? string.Empty, out string display))
            {
                result = display;
            }
            else if (int.TryParse(value, out int intValue))
            {
                result = intValue.GetEnumDisplayName<TEnum>();
            }

            return result;
        }

        /// <summary>
        /// 取得Enum OrderCodeType正確的Int String Value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToNumberStringOrderCode(this OrderCodeType value) 
        {
            return value.ToNumberString().PadLeft(2, '0');
        }

        /// <summary>
        /// 依醫院代碼取得醫院名稱
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetHosptailName (this string value)
        {
            var result = string.Empty;
            if (value == EnumUtility.HospitalID)
            {
                result = EnumUtility.Hospital;
            }
            if (value == EnumUtility.HospitalHomeCareID)
            {
                result = EnumUtility.HospitalHomeCare;
            }
            return result;
        }
    }
}
