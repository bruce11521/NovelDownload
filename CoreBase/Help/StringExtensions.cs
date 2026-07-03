using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using CoreBase.Utilities;

namespace CoreBase.Help
{
    /// <summary>
    /// String的擴充
    /// </summary>
    public static class StringExtensions
    {
        #region Public Parameter
        /// <summary>
        /// 中華民國身分證號 首碼英文字母對應代碼
        /// </summary>
        private static readonly Dictionary<char, int> TaiwanIdCardNumLetterMappingDic = new Dictionary<char, int>()
        {
            ['A'] = 10,
            ['B'] = 11,
            ['C'] = 12,
            ['D'] = 13,
            ['E'] = 14,
            ['F'] = 15,
            ['G'] = 16,
            ['H'] = 17,
            ['I'] = 34,
            ['J'] = 18,
            ['K'] = 19,
            ['L'] = 20,
            ['M'] = 21,
            ['N'] = 22,
            ['O'] = 35,
            ['P'] = 23,
            ['Q'] = 24,
            ['R'] = 25,
            ['S'] = 26,
            ['T'] = 27,
            ['U'] = 28,
            ['V'] = 29,
            ['W'] = 32,
            ['X'] = 30,
            ['Y'] = 31,
            ['Z'] = 33
        };

        #endregion



        /// <summary>
        /// 民國年月日時分(10701020304)轉西元年月日時分
        /// </summary>
        /// <param name="stringDate">民國年月日時分(0010101235959)</param>
        /// <returns>Formate:[yyyy/MM/dd HH:mm:ss]</returns>
        public static string ToDCFullDateTimeString(this string stringDate)
        {
            CultureInfo culture = new CultureInfo("zh-TW");
            culture.DateTimeFormat.Calendar = new TaiwanCalendar();
            //DateTime dateTime = DateTime.MinValue;
            DateTime? dateTime = stringDate.FromChineseFullStringToDate();

            if (dateTime == null)
            {
                return string.Empty;
            }

            return dateTime.Value.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture); ;
        }

        /// <summary>
        /// 民國年月(10701)轉西元年月
        /// </summary>
        /// <param name="yearMonth">民國年月(00101)</param>
        /// <returns>Formate:[yyyyMM]</returns>
        public static string ToDCYearMonthString(this string yearMonth)
        {
            CultureInfo culture = new CultureInfo("zh-TW");
            culture.DateTimeFormat.Calendar = new TaiwanCalendar();
            DateTime dateTime = DateTime.MinValue;

            // 判斷是否包含日期
            if (yearMonth.Length == 5)
            {
                // 切割年
                var year = yearMonth.Substring(0, 3);

                // 切割月
                var month = yearMonth.Substring(3, 2);

                // 轉成DateTime格式
                var totalDate = year + "/" + month + "/01";

                // 轉成西元年
                dateTime = DateTime.Parse(totalDate, culture);
            }

            string dcYearMonth = dateTime.ToString("yyyyMM", CultureInfo.InvariantCulture);
            return dcYearMonth;
        }

        /// <summary>
        /// 民國年月日時分秒 字串 轉西元日期
        /// </summary>
        /// <param name="value">yyyMMddHHmmss</param>
        /// <returns>如果傳入字串長度小於13則回傳DateTime.MinValue，轉換失敗回傳Null</returns>
        public static DateTime? FromChineseFullStringToDate(this string value)
        {
            try
            {
                const string parseFormate = "yyyyMMddHHmmss";
                string stripped = Regex.Replace(value ?? string.Empty, "[^0-9]", string.Empty);
                if (stripped.Length < 13)
                    return DateTime.MinValue;
                
                stripped = stripped.Substring(0, 13);
                //民國年(3) =>西元年
                int adYear = int.Parse(stripped.Substring(0, 3), CultureInfo.InvariantCulture) + 1911;
                //西元年 yyyy + 後面 MMddHHmmss(10)
                string adString = adYear.ToString("D4", CultureInfo.InvariantCulture) + stripped.Substring(3, 10);

                if (CultureInfo.InvariantCulture.Clone() is CultureInfo ci)
                {
                    ci.DateTimeFormat.Calendar = new GregorianCalendar();
                    if (DateTime.TryParseExact(adString, parseFormate, ci, DateTimeStyles.None, out DateTime dt))
                    {
                        return dt;
                    }
                }
            }
            catch
            {

            }
            return null;
        }

        /// <summary>
        /// 民國年月日時分字串轉西元日期
        /// </summary>
        /// <param name="value">yyyMMddHHmmss</param>
        /// <returns></returns>
        public static DateTime? FromChineseStringToDate(this string value)
        {
            string[] format = { "yyyyMMddHHmm" };
            string stripped = Regex.Replace(value, "[^0-9]", string.Empty);

            if (value.Trim() == string.Empty)
            {
                return null;
            }

            if (stripped.Length < 11)
            {
                return DateTime.MinValue;
            }

            int yearInt = Convert.ToInt16(stripped.Substring(0, 3), CultureInfo.InvariantCulture) + 1911;
            string yearString = Convert.ToString(yearInt, CultureInfo.InvariantCulture);
            string dateString = yearString + stripped.Substring(3, 8);
            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }

            return null;
        }

        /// <summary>
        /// 民國年(1070101)轉西元年
        /// </summary>
        /// <param name="rOCYear">民國年字串</param>
        /// <returns>格式不正確回傳null</returns>
        public static DateTime? ConvertDCYear(this string rOCYear)
        {
            DateTime? gongYuanyan;
            try
            {
                // 轉成西元年
                CultureInfo culture = new CultureInfo("zh-TW");
                culture.DateTimeFormat.Calendar = new TaiwanCalendar();

                // 本身轉入的資料已經符號分隔年月日
                if (new Regex("^\\d{2,3}[/-]\\d{2}[/-]\\d{2}$").IsMatch(rOCYear ?? string.Empty))
                {
                    gongYuanyan = DateTime.Parse(rOCYear, culture);
                }
                // 六、七碼純數字就來試著轉轉看能不能轉成西元年
                else if (new Regex("^\\d{6,7}$").IsMatch(rOCYear ?? string.Empty))
                // 判斷是否是民國年
                //else if (rOCYear.Length == 7)
                {
                    //// 切割年
                    //var year = rOCYear.Substring(0, 3);

                    //// 切割月
                    //var month = rOCYear.Substring(3, 2);

                    //// 切割日
                    //var day = rOCYear.Substring(5, 2);

                    //// 轉成DateTime格式
                    //var totalDate = year + "/" + month + "/" + day;

                    // 從右邊的數字抓二碼為日，再往右邊抓二碼為月，最後剩下2至3碼為年
                    var totalDate = Regex.Replace(rOCYear, "(\\d{2,3})(\\d{2})(\\d{2})$", "$1/$2/$3");

                    gongYuanyan = DateTime.Parse(totalDate, culture);
                }
                else
                {
                    // 如果字串傳入字串不等於7，則回傳null
                    gongYuanyan = null;
                }
            }
            catch
            {
                // 如果字串傳入字串格式不正確(ex:英文)，則回傳null
                gongYuanyan = null;
            }

            return gongYuanyan;
        }

        /// <summary>
        /// 民國年(107/01/01 or 1070101)轉西元[建議使用ConvertDCYear,非安全寫法]
        /// </summary>
        /// <param name="rocYear">民國年(107/01/01)</param>
        /// <returns></returns>
        public static DateTime ToDCYear(this string rocYear)
        {
            CultureInfo tc = new CultureInfo("zh-TW");
            tc.DateTimeFormat.Calendar = new TaiwanCalendar();
            if (!rocYear.Contains("/"))
            {
                string Date = rocYear.Substring(0, 3) + "/" + rocYear.Substring(3, 2) + "/" + rocYear.Substring(5, 2);
                return DateTime.Parse(Date, tc).Date;
            }
            else
            { 
                return DateTime.Parse(rocYear, tc).Date; 
            }
        }

        /// <summary>
        /// 字串轉DateTime
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns></returns>
        public static DateTime? StringToDateTime(this string value)
        {
            if (DateTime.TryParse(value, out DateTime dt))
            {
                return dt;
            }

            return null;
        }

        /// <summary>
        /// 將所有可能字串轉DateTime
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns></returns>
        public static DateTime? StringDCToDateTime(this string value)
        {
            string[] format =
            {
                // ==========================================
                // 1. 純數字連續字串 (西元年)
                // ==========================================
                "yyyyMMddHHmmssfff",  // 20260602104000123
                "yyyyMMddHHmmss",     // 20260602104000
                "yyyyMMddHHmm",       // 202606021040
                "yyyyMMddHH",         // 2026060210
                "yyyyMMdd",           // 20260602
                "yyyyMM",             // 202606
                "yyyy",               // 2026

                // ==========================================
                // 2. 斜線分隔格式 (最常見的 UI 與一般資料庫格式)
                // ==========================================
                "yyyy/MM/dd HH:mm:ss.fff", // 2026/06/02 10:40:00.123 (注意毫秒通常是 .fff)
                "yyyy/MM/dd HH:mm:ss fff",  // 2026/06/02 10:40:00 123
                "yyyy/MM/dd HH:mm:ss",      // 2026/06/02 10:40:00
                "yyyy/MM/dd HH:mm",         // 2026/06/02 10:40 (已修正原本 dd 後方多餘的斜線)
                "yyyy/MM/dd HH",            // 2026/06/02 10
                "yyyy/MM/dd",               // 2026/06/02
                "yyyy/MM",                  // 2026/06

                // ==========================================
                // 3. 橫線分隔格式 (標準 ISO 8601，常見於 Web API / JSON)
                // ==========================================
                "yyyy-MM-dd HH:mm:ss.fff", // 2026-06-02 10:40:00.123
                "yyyy-MM-dd HH:mm:ss",      // 2026-06-02 10:40:00
                "yyyy-MM-dd HH:mm",         // 2026-06-02 10:40
                "yyyy-MM-dd",               // 2026-06-02
                "yyyy-MM",                  // 2026-06

                // ==========================================
                // 4. 點號分隔格式 (部分醫療儀器、檢驗設備匯出格式)
                // ==========================================
                "yyyy.MM.dd HH:mm:ss",      // 2026.06.02 10:40:00
                "yyyy.MM.dd",               // 2026.06.02
    
                // ==========================================
                // 5. 單碼相容格式 (預防 2026/6/2 這種沒有補零的狀況)
                // ==========================================
                "yyyy/M/d H:m:s",           // 2026/6/2 10:40:0
                "yyyy/M/d",                 // 2026/6/2
                "yyyy-M-d H:m:s",           // 2026-6-2 10:40:0
                "yyyy-M-d"                  // 2026-6-2
            };
            if (!string.IsNullOrEmpty(value) && DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
            {
                return dt;
            }

            return null;
        }
        /// <summary>
        /// 字串yyyy/MM/dd hh:mm轉DateTime
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns></returns>
        public static DateTime? StringDCToDateTime2(this string value)
        {
            string[] format = { "yyyy/MM/dd HH:mm" };
            if (!string.IsNullOrEmpty(value) && DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
            {
                return dt;
            }

            return null;
        }
        /// <summary>
        /// 字串yyyyMMddHHmmss轉DateTime
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns></returns>
        public static DateTime? StringDCToDateTime3(this string value)
        {
            string[] format = { "yyyyMMddHHmmss" };
            if (!string.IsNullOrEmpty(value) && DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
            {
                return dt;
            }

            return null;
        }
        /// <summary>
        /// 字串yyyyMMddHHmmssfff轉DateTime
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns></returns>
        public static DateTime? StringDCToDateTime4(this string value)
        {
            string[] format = { "yyyyMMddHHmmssfff" };
            if (!string.IsNullOrEmpty(value) && DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
            {
                return dt;
            }

            return null;
        }

        /// <summary>
        /// 字串轉布林
        /// (不能保證值只有0/1/N/Y，就用這組)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool? ToBooleanNull(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            else if (value == "0" || value.ToUpper() == "N" || value.ToUpper() == "FALSE")
            {
                return false;
            }
            else if (value == "1" || value.ToUpper() == "Y" || value.ToUpper() == "TRUE")
            {
                return true;
            }

            return null;
        }

        /// <summary>
        /// 字串轉布林
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string value)
        {
            if (value != null && (value == "1" || value == "-1" || value.ToUpper() == "Y" || value.ToUpper() == "TRUE"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 取得目前 string 物件中字元的數目，Null 和 Empty 回傳0。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetNullLength(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            else
            {
                return value.Length;
            }
        }

        /// <summary>
        /// 依指定長度取回字串內容
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLen"></param>
        /// <returns></returns>
        public static string GetMaxLengthString(this string value , int maxLen)
        {
            if (value.GetNullLength() > maxLen)
            {
                return value.Substring(0, maxLen);
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 字元轉數值(失敗回傳0)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this char value)
        {
            return int.TryParse(value.ToString(), out var number) ? number : 0;
        }

        /// <summary>
        /// 字串轉數值(失敗回傳0)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this string value)
        {
            return int.TryParse(value, out var number) ? number : 0;
        }
        /// <summary>
        /// 字串轉數值(失敗回傳-1或是傳入之預設數值，透過參數控制)
        /// </summary>
        /// <param name="value">string</param>
        /// <param name="isDefaultNegativeValue">失敗是回傳-1? [True:-1, False:回傳傳入之參數defaultNumber]</param>
        /// <param name="defaultNumber">當轉換失敗且 isDefaultnegativeValue = False時 回傳該參數數值[預設-1]</param>
        /// <returns></returns>
        public static int ToInt(this string value, bool isDefaultNegativeValue, int defaultNumber = -1)
        {
            return int.TryParse(value, out var number) ? number : isDefaultNegativeValue ? -1 : defaultNumber;
        }

        /// <summary>
        /// 字串轉數值(失敗回傳0)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value)
        {
            return value.ToDecimalNull() ?? 0;
        }

        /// <summary>
        /// 字串轉數值(失敗回傳NULL))
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? ToDecimalNull(this string value)
        {
            if (decimal.TryParse(value, out decimal number))
            {
                return number;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 字串轉數值(失敗回傳0)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Single ToSingle(this string value)
        {
            return value.ToSingleNull() ?? 0;
        }

        /// <summary>
        /// 字串轉數值(失敗回傳NULL))
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Single? ToSingleNull(this string value)
        {
            if (Single.TryParse(value, out Single number))
            {
                return number;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 字串轉數值(失敗回傳0)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(this string value)
        {
            return value.ToDoubleNull() ?? 0;
        }

        /// <summary>
        /// 字串轉數值(失敗回傳NULL))
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double? ToDoubleNull(this string value)
        {
            if (double.TryParse(value, out double number))
            {
                return number;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 文字 轉為 Enums(以Display.Name)
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static T DisplayNameToEnum<T>(this string value)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            foreach (T eVal in Enum.GetValues(enumType))
            {
                FieldInfo fi = eVal.GetType().GetField(eVal.ToString());
                DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

                if (attributes.Length > 0 && attributes[0].Name == value)
                {
                    result = eVal;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 文字 轉為 Enums(以Display.Description)
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static T DisplayDescriptionToEnum<T>(this string value)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            foreach (T eVal in Enum.GetValues(enumType))
            {
                FieldInfo fi = eVal.GetType().GetField(eVal.ToString());
                DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

                if (attributes.Length > 0 && attributes[0].Description == value)
                {
                    result = eVal;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 文字 轉為 Enums(以Display.Description), 比較時候忽略大小寫[以大寫去判斷] 
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static T DisplayDescriptionToEnum_IgnoreCase<T>(this string value)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            foreach (T eVal in Enum.GetValues(enumType))
            {
                FieldInfo fi = eVal.GetType().GetField(eVal.ToString());
                DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

                if (attributes.Length > 0 && attributes[0].Description?.ToUpper() == value?.ToUpper())
                {
                    result = eVal;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 文字 轉為 Enums(以Description)
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static T DescriptionToEnum<T>(this string value)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            foreach (T eVal in Enum.GetValues(enumType))
            {
                FieldInfo fi = eVal.GetType().GetField(eVal.ToString());

                // 這段取用的是 單純宣告為 Description 的
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0 && attributes[0].Description == value)
                {
                    result = eVal;
                    break;
                }

                //// 這段取用的是 附加在 Display 後面的 Description
                //var attributesString = fi.GetCustomAttribute<DisplayAttribute>().Description;
                //if (attributesString != null && attributesString == value)
                //{
                //    result = eVal;
                //    break;
                //}
            }
            return result;
        }

        /// <summary>
        /// 文字 轉為 Enums(以Description), 比較時候忽略大小寫[以大寫去判斷] 
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static T DescriptionToEnum_IgnoreCase<T>(this string value)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            foreach (T eVal in Enum.GetValues(enumType))
            {
                FieldInfo fi = eVal.GetType().GetField(eVal.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0 && attributes[0].Description?.ToUpper() == value?.ToUpper())
                {
                    result = eVal;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 文字 轉為 Enums(以Name)
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static T NameToEnum<T>(this string value)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            foreach (T eVal in Enum.GetValues(enumType))
            {
                if (eVal.ToString() == value)
                {
                    result = eVal;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 文字 轉為 Enums(以Name 依照參數轉大小寫去比對)
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="IsUpper">是否轉大寫[True:ToUpper, False:ToLower]</param>
        /// <returns></returns>
        public static T NameLetterToEnum<T>(this string value, bool IsUpper = true)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            foreach (T eVal in Enum.GetValues(enumType))
            {
                if (IsUpper)
                {
                    if (eVal.ToString().ToUpper() == value)
                    {
                        result = eVal;
                        break;
                    }
                }
                else
                {
                    if (eVal.ToString().ToLower() == value)
                    {
                        result = eVal;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 文字 轉為 Enums(以值)
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static T ValueToEnum<T>(this string value)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            if (int.TryParse(value, out int intValue))
            {
                result = intValue.ToEnum<T>();
            }
            return result;
        }

        /// <summary>
        /// 字串文字遮罩
        /// </summary>
        /// <param name="sensitiveData">來源字串</param>
        /// <param name="startMaskIndex">遮罩起始位置</param>
        /// <param name="maskCount">遮罩字元數</param>
        /// <param name="maskChar">遮罩替代字元(預設為'*')</param>
        /// <returns></returns>
        public static string Mask(this string sensitiveData, int startMaskIndex, int maskCount, char maskChar = '*')
        {
            try
            {
                var stringBuilder = new StringBuilder(sensitiveData)
                    .Remove(startMaskIndex, maskCount)
                    .Insert(startMaskIndex, new string(maskChar, maskCount));
                return Convert.ToString(stringBuilder, null);
            }
            catch
            {
                return sensitiveData;
            }
        }

        /// <summary>
        /// 身分證字號隱碼
        /// </summary>
        /// <param name="idNo">身分證字號</param>
        /// <returns></returns>
        public static string MaskIdNo(this string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return value;
                }

                return value.Mask(3, 4);
            }
            catch
            {
                return value;
            }
        }

        /// <summary>
        /// 填空白至左右對齊
        /// (英文沒測試過)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="num">總文字長度</param>
        /// <returns></returns>
        public static string AppendSpace(this string text, int num)
        {
            try
            {
                string value = string.Empty;
                // 半形空白
                string spaceString = " ";
                // 全形空白
                string fullSpaceString = "　";
                // 文字長度
                int len = text.Length;
                // 差多少欄位
                int diffSpace = num - len;
                // 文字有幾個間距
                int charSpace = len - 1;

                if (diffSpace > 0)
                {
                    if (len == 1)
                    {
                        // 文字只有一字元的話，置中放
                        var space = string.Empty;
                        for (int i = 0; i < (diffSpace / 2); i++)
                        {
                            space += fullSpaceString;
                        }
                        if (diffSpace % 2 > 0)
                        {
                            space += spaceString;
                        }
                        value = space + text + space;
                    }
                    else if (len == 2)
                    {
                        // 文字只有二字元的話，中間補滿空白
                        var space = string.Empty;
                        for (int i = 0; i < diffSpace; i++)
                        {
                            space += fullSpaceString;
                        }
                        value = text.Substring(0, 1) + space + text.Substring(1, 1);
                    }
                    else if (diffSpace % charSpace == 0 || charSpace == 2)
                    {
                        // 欠缺的長度，可以平均分配到字元中或是總共三字元的話，平均分配全空白
                        var space = string.Empty;
                        for (int i = 0; i < (diffSpace / charSpace); i++)
                        {
                            space += fullSpaceString;
                        }
                        if (diffSpace % 2 > 0)
                        {
                            space += spaceString;
                        }
                        for (int i = 0; i < len; i++)
                        {
                            value += text.Substring(i, 1) + space;
                        }
                    }
                    else if (((decimal)diffSpace / (decimal)charSpace) == 0.5m)
                    {
                        // 欠缺的長度，和可分配字元間距為一半的話，平均分配半形空白
                        var space = string.Empty;
                        for (int i = 0; i < (charSpace / diffSpace) - 1; i++)
                        {
                            space += spaceString;
                        }
                        for (int i = 0; i < len; i++)
                        {
                            value += text.Substring(i, 1) + space;
                        }
                    }
                    else if (num == len + 1)
                    {
                        // 文字長度與總長度只差一格的話，前/後補一個半形空白
                        value = text.Substring(0, 1) + spaceString + text.Substring(1, len - 2) + spaceString + text.Substring(len - 1, 1);
                    }
                    else
                    {
                        // 無法均分的內容，只將前/後字元對齊，第二字元及倒數第二字元開始往中間補空白
                        var space = string.Empty;
                        for (int i = 0; i < (diffSpace / 2); i++)
                        {
                            space += fullSpaceString;
                        }
                        if (space.Length + len - 1 == num)
                        {
                            space += spaceString;
                        }

                        value = text.Substring(0, 1) + space + text.Substring(1, len - 2) + space + text.Substring(len - 1, 1);
                    }
                }
                else
                {
                    // 超過可補長度的，不補
                    value = text;
                }

                return value;
            }
            catch
            {
                return text;
            }
        }

        /// <summary>
        /// String To StringBuilder
        /// </summary> 
        /// <param name="value">傳入之String</param>
        /// <returns></returns>
        public static StringBuilder ToStringBuilder(this string value, int? Capacity = null)
        {
            try
            {
                StringBuilder Result = null;
                if (!string.IsNullOrEmpty(value) && value.Length >= 0 && value.Length < int.MaxValue)
                {
                    if (Capacity != null && Capacity.HasValue && Capacity.Value > 0 && Capacity.Value >  value.Length )
                    {
                        Result = new StringBuilder(Capacity.Value);
                    }
                    else
                    {
                        Result = new StringBuilder(value.Length);
                    }
                }
                else
                {
                    if (Capacity != null && Capacity.HasValue && Capacity.Value > 0 && Capacity.Value < int.MaxValue)
                    {
                        Result = new StringBuilder(Capacity.Value);
                    }
                    else
                    {
                        Result = new StringBuilder();
                    }
                }
                if (string.IsNullOrEmpty(value))
                {
                    Result.Append("");
                    
                }
                else
                {
                    Result.Append(value);
                }
                return Result;
            }
            catch
            {
                return new StringBuilder(string.Empty);
            }
        }
        /// <summary>
        /// string自動切割多於指定長度之字串，若指定長度小於傳入數值，則自動從字串後面(PadRight)補空格到指定長度, Null時回傳string.Empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="TargetLength"></param>
        /// <returns></returns>
        public static String SubStringFromZeroToTargetLength(this string value, int TargetLength)
        {
            string returnResult = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= TargetLength)
                {
                    returnResult = value.Substring(0, TargetLength);
                }
                else
                {
                    if (string.IsNullOrEmpty(value) && TargetLength > 0)
                    {
                        return returnResult.PadRight(TargetLength);
                    }
                    else if(string.IsNullOrEmpty(value))
                    {
                        return returnResult;
                    }
                    else if(!string.IsNullOrEmpty(value))
                    {
                        // value.Length < TargetLength
                        return value.PadRight(TargetLength);
                    }
                }
                return returnResult;
            }
            catch 
            {
                return returnResult;
            }
        }
        /// <summary>
        /// string自動切割多於指定長度之字串，若指定長度小於傳入數值，則自動從字串後面(PadRight)補空格到指定長度, Null時回傳string.Empty
        /// </summary>
        /// <param name="ValueStringBuilder"></param>
        /// <param name="TargetLength"></param>
        /// <returns></returns>
        public static StringBuilder SubStringFromZeroToTargetLength(this StringBuilder ValueStringBuilder, int TargetLength)
        {
            var value = ValueStringBuilder?.ToString();
            StringBuilder returnResult = new StringBuilder();
            try
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= TargetLength)
                {
                    returnResult = value.Substring(0, TargetLength).ToStringBuilder();
                }
                else
                {
                    if (string.IsNullOrEmpty(value) && TargetLength > 0)
                    {
                        return value?.PadRight(TargetLength)?.ToStringBuilder();
                    }
                    else if (string.IsNullOrEmpty(value))
                    {
                        return returnResult;
                    }
                    else if (!string.IsNullOrEmpty(value))
                    {
                        // value.Length < TargetLength
                        return value.PadRight(TargetLength)?.ToStringBuilder();
                    }
                }
                return returnResult;
            }
            catch
            {
                return returnResult;
            }
        }
        /// <summary>
        /// String To StringBuilder[Object]
        /// </summary> 
        /// <param name="value">傳入之String</param>
        /// <returns></returns>
        public static StringBuilder ToStringBuilder(this object value, int? Capacity = null)
        {
            try
            {
                StringBuilder Result = null;
                if (value != null && value is string StrValue && StrValue.Length >= 0 && StrValue.Length < int.MaxValue)
                {
                    if (Capacity != null && Capacity.HasValue && Capacity.Value > 0 && Capacity.Value > StrValue.Length)
                    {
                        Result = new StringBuilder(Capacity.Value);
                    }
                    else
                    {
                        Result = new StringBuilder(StrValue.Length);
                    }
                }
                else
                {
                    if (Capacity != null && Capacity.HasValue && Capacity.Value > 0 && Capacity.Value < int.MaxValue)
                    {
                        Result = new StringBuilder(Capacity.Value);
                    }
                    else
                    {
                        Result = new StringBuilder();
                    }
                }
                if (value != null && value is string StrValue2 && StrValue2.Length >= 0)
                {
                    Result.Append(StrValue2);
                }
                else
                {
                    Result.Append("");
                }
                return Result;
            }
            catch
            {
                return new StringBuilder(string.Empty);
            }
        }

        /// <summary>
        /// 檢核路徑下沒重複的檔名組合
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static string getFileName(this string fileName, string folderPath)
        {
            // 複製出來原始的檔名及副檔名
            string result = fileName.Clone().ToString().GetLegalFileName();
            // 遞增序號
            var count = 1;

            string cloneFolder = folderPath.CloneJson();

            if (cloneFolder.EndsWith("\\") == false)
            {
                cloneFolder += "\\";
            }

            while (fileName.StartsWith("\\"))
            {
                fileName = fileName.Remove(0, 1);
            }

            // 檢查資料夾是否存在
            if (Directory.Exists(cloneFolder) == false)
            {
                // 沒資料夾時，建立此資料夾
                Directory.CreateDirectory(cloneFolder);
            }

            // 檢查檔案是否存在，不成立時，離開迴圈
            while (File.Exists(cloneFolder + result))
            {
                // 將原始檔名依小數點分隔成陣列
                var arr = fileName.Clone().ToString().Split('.');

                // 在副檔名前的加上『_流水號』
                arr[arr.Length - 2] = arr[arr.Length - 2] + "_" + count.ToString();

                // 將陣列組回檔名
                result = string.Join(".", arr);

                // 流水序 + 1
                count += 1;
            }

            return result.GetLegalFileName(true);
        }

        /// <summary>
        /// 取得合法的檔名
        /// </summary>
        /// <param name="value">原始字串</param>
        /// <param name="isFullShape">是否將不合法的字元置換成全形，否則予以刪除</param>
        /// <returns></returns>
        public static string GetLegalFileName(this string value, bool isFullShape = false)
        {
            // 非法檔名字元
            var illegalChar = new List<string> { "\\", "/", ":", "*", "?", "\"", "<", ">", "|" };
            // 非法檔名字元的全形字
            var fullShape = new List<string> { "＼", "／", "：", "＊", "？", "＂", "＜", "＞", "｜" };
            // 置換的字
            var replaceChar = string.Empty;

            for (int i = 0; i < illegalChar.Count; i++)
            {
                if (isFullShape)
                {
                    replaceChar = fullShape[i];
                }
                value = value.Replace(illegalChar[i], replaceChar);
            }

            return value.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ');
        }

        /// <summary>
        ///     字串轉換為Unicode16進制(可用於難字寫入資料庫)
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static string CharacterToHex(this string character)
        {
            string resultString = "";

            if (string.IsNullOrWhiteSpace(character))
            {
                return character;
            }

            // 取得字元的UTF16編碼
	        byte[] bytes = System.Text.Encoding.Unicode.GetBytes(character);

	        // 將字元的UTF16編碼分別放到陣列中
	        int[] resultArray = new int[bytes.Length / 2];
	        for (int i = 0; i < resultArray.Length; i++)
	        {
                resultString += ((bytes[i * 2 + 1] << 8) | bytes[i * 2]).ToString("x4");
            }
            
	        return resultString;
        }

        /// <summary>
        ///     Unicode16進制轉換為字串
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string HexToCharacter(this string text)
        {
            if (string.IsNullOrEmpty(text)) return null;

            string temp = null;
            bool flag = false;

            int len = text.Length / 4;
            if (text.StartsWith("0x") || text.StartsWith("0X"))
            {
                len = text.Length / 6;//0x in Unicode string
                flag = true;
            }

            StringBuilder sb = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                if (flag)
                    temp = text.Substring(i * 6, 6).Substring(2);
                else
                    temp = text.Substring(i * 4, 4);

                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(temp.Substring(0, 2), NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(temp.Substring(2, 2), NumberStyles.HexNumber).ToString());
                sb.Append(Encoding.Unicode.GetString(bytes));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 將指定之數字的字串表示，轉換為相等的 64 位元帶正負號的整數。(如果string.IsNullOrWhiteSpace(如果Value) == True, 則回 0(零))
        /// </summary>
        /// <param name="text">Value</param>
        /// <returns>與 value 中之數字相等的 64 位元帶正負號的整數；如果 value 為 null或空白或string.Empty，則為 0 (零); 如果 value 文字格式轉換Int64失敗則為 -1。</returns>
        public static Int64 ConvertToInt64(this string text)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(text))
                {
                    return 0;
                }
                else
                {
                    if(Int64.TryParse(text, out long Result))
                    {
                        return Result;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #region Word BYTE COUNTER 
        /// <summary>
        /// 編碼位數轉換比對
        /// </summary>
        /// <param name="Str">輸入欲比較之字串</param>
        /// <param name="MaxColumnCount">是否大於(預設值:0)輸入DB欄位長度</param>
        /// <param name="IsNVARCHAR2_EnCoding"> 是否為 NVARCHAR2 編碼?[中英文字符皆是 2 Byes]，故使用.Length來判斷</param>
        /// <param name="InputEncoding">輸入字串之編碼(預設值:Encoding.Default)[中文:BIG5:2 Bytes,UTF-8:3 Bytes, 英文:1 Bytes]</param>
        /// <returns>[IsWordCountValid 是否合法(Str &gt; MaxWordCount == false), InputStrWordCount 輸入字串之文字字數(無效數:-1)]</returns>
        public static (bool IsWordCountValid, int InputStrWordCount) WordCounter(this string Str, int MaxColumnCount = 0, bool IsNVARCHAR2_EnCoding = false, Encoding InputEncoding = null)
        {
            try
            {
                //if (Str is string)
                //{
                if (!string.IsNullOrEmpty(Str))
                {
                    byte[] Source = null;
                    if (IsNVARCHAR2_EnCoding)
                    {
                        if (Str.Length > MaxColumnCount)
                        {
                            return (false, Str.Length);
                        }
                        else
                        {
                            return (true, Str.Length);
                        }
                    }
                    else
                    {
                        if (InputEncoding == null)
                        {
                            InputEncoding = Encoding.Default;
                        }
                        switch (InputEncoding.BodyName)
                        {
                            case "utf-8":
                                Source = Encoding.UTF8.GetBytes(Str);
                                break;
                            case "big5":
                                Source = Encoding.Default.GetBytes(Str);
                                break;
                            case "utf-16":
                                Source = Encoding.Unicode.GetBytes(Str);
                                break;
                            case "utf-16BE":
                                Source = Encoding.BigEndianUnicode.GetBytes(Str);
                                break;
                            default:
                                Source = InputEncoding.GetBytes(Str);
                                break;
                        }
                        if (Source != null)
                        {
                            if (Source.Length > MaxColumnCount)
                            {
                                return (false, Source.Length);
                            }
                            else
                            {
                                return (true, Source.Length);
                            }
                        }
                        else
                        {
                            return (false, -1);
                        }
                    }
                }
                else
                {
                    if (MaxColumnCount >= 0)
                    {
                        return (true, 0);
                    }
                    else
                    {
                        return (false, 0);
                    }

                }
                //}
                //else
                //{
                //    return (false, -1);
                //}
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 將字串截至指定編碼下的指定長度
        /// 並判斷是否Nvarchar
        /// </summary>
        /// <param name="input">輸入字串</param>
        /// <param name="maxLength">指定長度</param>
        /// <param name="isNVarchar">寫入欄位是否為NVarchar</param>
        /// <returns></returns>
        public static string TrimToMaxLength(this string input, int maxLength, bool isNVarchar = false)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            return isNVarchar
                ? (input.Length <= maxLength ? input : input.Substring(0, maxLength))
                : input.TrimAndSplitToString(maxLength);
        }
        /// <summary>
        /// 將字串截至指定編碼下的指定長度(bytes.Length)
        /// </summary>
        /// <param name="InputStr">輸入字串</param>
        /// <param name="InputLen">指定長度</param>
        /// <param name="_Encoding">輸入字串之編碼(如未輸入使用Encoding.Default)</param>
        /// <param name="IsPadRightWhiteSpace">是否將右側補上空白至指定長度?</param>
        /// <returns></returns>
        public static string TrimAndSplitToString(this string InputStr, int InputLen, Encoding _Encoding = null, bool IsPadRightWhiteSpace = false)
        {
            if (string.IsNullOrEmpty(InputStr))
            {
                if (IsPadRightWhiteSpace)
                {
                    return (InputStr ?? string.Empty).PadRight(InputLen, ' ');
                }
                return string.Empty;
            }
            if(InputLen > 0)
            {
                Encoding encoding = null;
                if (_Encoding is null)
                {
                    encoding = Encoding.Default;
                }
                else
                {
                    encoding = _Encoding;
                }
                byte[] b = encoding.GetBytes(InputStr);
                if (b.Length <= InputLen)
                {
                    //未超過指定長度，直接回傳
                    if (IsPadRightWhiteSpace)
                    {
                        var newStrBytes = encoding.GetBytes(InputStr);
                        if (newStrBytes.Length < InputLen)
                        {
                            var padRightLength = InputLen - newStrBytes.Length;
                            for (int index = 0; index < padRightLength; index++)
                            {
                                InputStr += " ";
                            }
                        }
                        //InputStr = InputStr.PadRight(InputLen, ' ');
                    }
                    return InputStr;
                }
                else
                {
                    //由於可能最後一個字元可能切到中文字的前一碼形成亂碼
                    //透過截斷的亂碼與完整轉換結果會有出入的原理來偵測
                    string res = encoding.GetString(b, 0, InputLen);
                    if (encoding.GetString(b).StartsWith(res) is false)
                    {
                        res = encoding.GetString(b, 0, InputLen - 1);
                    }
                    //因為超過指定長度就不再另外計算PadRight
                    if (IsPadRightWhiteSpace)
                    {
                        var newStrBytes = encoding.GetBytes(res);
                        if (newStrBytes.Length < InputLen)
                        {
                            var padRightLength = InputLen - newStrBytes.Length;
                            for (int index = 0; index < padRightLength; index++)
                            {
                                res += " ";
                            }
                        }
                    }
                    return res;
                }
            }
            else
            {
                return InputStr;
            }
        }
        /// <summary>
        /// 輸入字串依照Byte長度進行分割
        /// </summary>
        /// <param name="InputStr">輸入字串</param>
        /// <param name="SplitLen">分割長度(欲分割之Byte的長度=DB Column Varchar Length)</param>
        /// <param name="_Encoding">輸入字串之編碼(如未輸入使用Encoding.Default)</param>
        /// <param name="AddToFirstSplitString">每一筆在起始位置加入之 特殊顯示字串，
        /// 使用"#INDEX#"來標示第X筆,[Ex:自動分筆-第#INDEX#筆]=>[自動分筆-第1筆]... </param>
        /// <returns></returns>
        public static ServiceResult<List<string>> TrimAndSplitToListString(this string InputStr, int SplitLen, Encoding _Encoding = null, string AddToFirstSplitString = null)
        {
            ServiceResult<List<string>> returnResult = new ServiceResult<List<string>>(false, string.Empty, new List<string>());
            try
            {
                if (string.IsNullOrEmpty(InputStr))
                {
                    return returnResult;
                }
                if (SplitLen > 0)
                {
                    Encoding encoding = null;
                    if (_Encoding is null)
                    {
                        encoding = Encoding.Default;
                    }
                    else
                    {
                        encoding = _Encoding;
                    }
                    byte[] inputStrB = encoding.GetBytes(InputStr);
                    if (inputStrB.Length <= SplitLen)
                    {
                        //未超過指定長度，直接回傳
                        returnResult.Message += $"輸入字串長度[{inputStrB.Length}] 不可小於等於 分割長度[{SplitLen}]!";
                        returnResult.Data.Add(InputStr);
                        return returnResult;
                    }
                    else
                    {
                        #region 參考連結
                        //參考連結 http://webcache.googleusercontent.com/search?q=cache:D73Ky-IB0XgJ:https://www.cnblogs.com/klm-kain/p/15907387.html&sca_esv=576472481&hl=zh-TW&gl=tw&strip=1&vwsrc=0
                        /*
                         * 方法：字符串按字节固定长度分割数组
                         * startPos 子串在原字符串字节数组的开始截取下标
                         * startStrPos 子串在原字符串开始截取的下标
                         * strLen 原字符串字节数组长度
                         * 背景：由于编码格式不同，直接截取可能会拿到一个被砍一半的乱码，如utf-8 4byte 一个中文，如果截取的时候是5byte，就会出现乱码
                         * 原理：1、先按字节数组进行截取，获得一个长度不大于固定截取长度的字节数组
                         *      2、把字节数组转字符串得到一个新子串，再转byte数组后，两数组长度进行比较（新子串再转byte数组时，会对截取了一半的字符进行补全为对应编码集一个字符的长度），
                         *         如果新子串的字节数组比按长度截取的子串字节数组长，说明存在截取一半的字符，这个字符会在最后一个位置，要舍弃
                         *         所以，新子串按字符串长度截取减少1位，得到的字符串就是没有截取一半的字符，且长度小于等于需要的字节长度的子串。
                         *
                         * 1.当 子串字节数组开始截取下标 小于 原字符串字节数组长度 一直循环
                         * 2.子串字节数组大小 需要根据 当前父串字节数组的截取下标和长度差值 与 预想截取的字节长度 比较来创建（否则用System.arraycopy会报错）
                         * 3.根据 子串在原字符串字节数组的开始截取下标 拷贝父字节数组的内容到子字节数组
                         * 4.根据 子串在原字符串开始截取的下标 与 子字节数组转为字符串的长度 在父字符串截取一个伪子串（可能最后一个字符被截取一半是乱码）
                         * 5.比较伪子串转字节数组后长度 与 预想截取的字节数组长度，大于，则伪子串截取字符串长度-1
                         * 6.子串字节数组开始截取下标 + 得到的子串字节长度；子串在原字符串开始截取的下标 + 得到子串的字符长度
                         * @param str 原字符串
                         * @param len 分割字串字节长度
                         * @param charSet 编码字符集
                         * @return List<String> 分割后的子串
                         * @throws UnsupportedEncodingException
                         */
                        /* 以下為JAVA寫法
                        public static final List<String> divideStrByBytes(String str, int len, String charSet) throws UnsupportedEncodingException{
                            List<String> strSection = new ArrayList<>();
                            byte[] bt = str.getBytes(charSet);
                            int strLen = bt.length;
                            int startPos = 0;
                            int startStrPos = 0;
                            while (startPos < strLen)
                            {
                                Integer subSectionLen = len;
                                if (strLen - startPos < len)
                                {
                                    subSectionLen = strLen - startPos;
                                }
                                byte[] br = new byte[subSectionLen];
                                System.arraycopy(bt, startPos, br, 0, subSectionLen);
                                String res = new String(br, charSet);
                                int resLen = res.length();
                                if (str.substring(startStrPos, startStrPos + resLen).getBytes(charSet).length > len)
                                {
                                    res = res.substring(0, resLen - 1);
                                }
                                startStrPos += res.length();
                                strSection.add(res);
                                startPos += res.getBytes(charSet).length;
                            }
                            return strSection;
                        }
                        */
                        #endregion 參考連結
                        //區隔每一筆編號之特殊字元
                        var specialText = new Regex(@"\#INDEX\#", RegexOptions.IgnoreCase);
                        //每一筆在起始位置加入之 特殊顯示字串
                        var AddSplitStringLen = 0;
                        //特殊顯示字串中之運算長度
                        var SpecialTextLen = 0;
                        //特殊顯示字串 是否含有編碼特殊字元
                        var HasSpecialText = false;
                        //每一筆特殊顯示字串
                        var ReplaceString = string.Empty;
                        if (!string.IsNullOrWhiteSpace(AddToFirstSplitString))
                        {
                            if (specialText.IsMatch(AddToFirstSplitString ?? string.Empty))
                            {
                                SpecialTextLen = AddToFirstSplitString.Replace("#INDEX#", "0").Length;
                                HasSpecialText = true;
                            }
                            if ( (HasSpecialText ? SpecialTextLen : AddToFirstSplitString.Length) > SplitLen)
                            {
                                returnResult.Message += $"分割多筆時指定加入字串長度[{AddToFirstSplitString.Length}] 不可大於 分割長度[{SplitLen}]!";
                                return returnResult;
                            }
                            AddSplitStringLen = (HasSpecialText ? SpecialTextLen : AddToFirstSplitString.Length);
                        }
                        

                        //每一次分割後之起始Index位置,  上一次分割後之起始Index位置
                        int startPos = 0, startStrPos = 0;
                        //回傳文字陣列
                        var TempList = new List<string>();
                        var ListCount = 1;

                        //當每一次分割後之起始Index位置 小於 輸入字串長度
                        while (startPos < inputStrB.Length)
                        {
                            //運算即將插入之 特殊顯示字串長度
                            if (specialText.IsMatch(AddToFirstSplitString ?? string.Empty))
                            {
                                ReplaceString = AddToFirstSplitString.Replace("#INDEX#", ListCount.ToString());
                                AddSplitStringLen = encoding.GetBytes(ReplaceString).Length;
                            }
                            else
                            {
                                ReplaceString = AddToFirstSplitString;
                                AddSplitStringLen = encoding.GetBytes(ReplaceString??string.Empty).Length;
                            }
                            
                            //本次分割長度
                            var subSectionLen = SplitLen;
                            //如果運算特殊顯示字串長度 大於零則修正 選取之剩餘長度
                            if (AddSplitStringLen > 0)
                            {
                                subSectionLen = SplitLen - AddSplitStringLen;
                            }
                            if (inputStrB.Length - startPos < subSectionLen)
                            {
                                //當字串剩餘長度(inputStrB.Length-startPos) 小於 欲分割長度(SplitLen)，則取 剩餘長度
                                subSectionLen = inputStrB.Length - startPos;
                            }


                            //本次分割之byte陣列
                            byte[] br = new byte[subSectionLen];
                            //從輸入字串byte陣列(inputStrB)中之 起始Index位置(startPos) 取得 起始位置(0) ~ 本次分割長度(subSectionLen)中陣列數值 並複製到本次分割之byte陣列(br)中
                            Array.Copy(inputStrB, startPos, br, 0, subSectionLen);
                            //取得本次分割之byte陣列並轉譯成string, 用來比較
                            string res = encoding.GetString(br);

                            //當從輸入字串byte陣列(inputStrB) 依照 上一次分割後之起始Index位置(startStrPos),取 本次分割之byte陣列長度(res.Length) 之 byte陣列長度
                            //如果 從輸入字串取得 本次分割之byte陣列長度之SubString 大於 分割長度 => 代表 本次分割之byte陣列有字元被切割掉，需把長度-1
                            if (encoding.GetBytes(InputStr.Substring(startStrPos, res.Length )).Length > subSectionLen)
                            {
                                res = res.Substring(0, res.Length - 1);
                            }
                            //上一次分割後之起始Index位置 += 本次分割之byte陣列並轉譯成string 長度
                            startStrPos += res.Length;
                            TempList.Add(ReplaceString += res);
                            //每一次分割後之起始Index位置 += 本次分割之byte陣列長度
                            startPos += encoding.GetBytes(res).Length;
                            ListCount++;

                        };
                        //if (TempList.Count > 1)
                        //{
                        //    var lastString = TempList.LastOrDefault();
                        //    if (lastString != null && lastString.Contains(ReplaceString ?? string.Empty))
                        //    {
                        //        var result = TempList.LastOrDefault().Substring(0, lastString.Length - ReplaceString.Length);
                        //        TempList.RemoveAt(TempList.Count-1);
                        //        TempList.Add(result);
                        //    }
                            
                        //}
                        
                        returnResult.Data = TempList;
                        returnResult.IsOk = true;
                        return returnResult;
                    }
                }
                else
                {
                    return returnResult;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion Word BYTE COUNTER

        #region 網址URL處理
        /// <summary>
        /// 使用外部軟體開啟URL編碼後之網址列[編碼以及解碼]
        /// </summary>
        /// <param name="FileName">預設使用Chrome瀏覽器</param>
        /// <param name="URL">網址列[將會自動進行編碼轉換]</param>
        public static ServiceResult<string> OpenExternalWebBrowser(this string URL, string FileName = "chrome.exe")
        {
            ServiceResult<string> ReturnResult = new ServiceResult<string>(true, string.Empty, string.Empty);
            var ExecuteFileName = "chrome.exe";
            try
            {
                if (!string.IsNullOrWhiteSpace(FileName))
                {
                    ExecuteFileName = FileName;
                    ReturnResult.Message += "瀏覽器名稱未給予，使用預設CHROME" + Environment.NewLine;
                }
                if (string.IsNullOrWhiteSpace(URL))
                {
                    URL = "https://tsghwww.ndmctsgh.edu.tw/";
                    ReturnResult.Message += "URL網址為空值，使用預設網頁(三總網站)" + Environment.NewLine;
                }
                //URL是否包含空白 或 URL格式錯誤(如果有逸出字元也會錯誤)
                if (StringExtensions.HasInvalidUrlFormateOrUrlContainWhiteSpace(URL) || StringExtensions.HasUrlEscapeError(URL))
                {
                    if (StringExtensions.HasUrlContainWhiteSpace(URL))
                    {//包含空白
                        if (StringExtensions.HasUrlEscapeError(URL))
                        {
                            //有空白及逸出字元
                            ReturnResult.Data = StringExtensions.UrlDecode(URL);
                            Process.Start(ExecuteFileName, StringExtensions.UrlDecode(URL));
                        }
                        else
                        {
                            //僅有空白
                            ReturnResult.Data = StringExtensions.UrlEncode(URL);
                            Process.Start(ExecuteFileName, StringExtensions.UrlEncode(URL));
                            //if (Uri.TryCreate(StringExtensions.UrlEncode(URL), UriKind.RelativeOrAbsolute, out var ResultUri))
                            //{ 
                            //}
                        }
                    }
                    else if (StringExtensions.HasUrlEscapeError(URL))
                    {//包含逸出字元
                        ReturnResult.Data = StringExtensions.UrlDecode(URL);
                        Process.Start(ExecuteFileName, StringExtensions.UrlDecode(URL));
                    }
                    else
                    {//格式錯誤
                        ReturnResult.IsOk = false;
                        ReturnResult.Message += "網址格式錯誤!" + Environment.NewLine;
                    }
                }
                else
                {
                    //正確格式且不包含空白
                    ReturnResult.Data = StringExtensions.UrlEncode(URL);
                    Process.Start(ExecuteFileName, StringExtensions.UrlEncode(URL));
                }
                if (ReturnResult.IsOk)
                {
                    ReturnResult.Message += "網址編碼解析正常" + Environment.NewLine;
                }
            }
            catch(Exception ex)
            {
                ReturnResult.IsOk = false;
                ReturnResult.Message += "URL編碼轉換發生錯誤,故使用原始URL開啟連結視窗.\nThrow:" + ex.Message + Environment.NewLine;
                ReturnResult.Data = URL;
                try
                {
                    Process.Start(ExecuteFileName, URL);
                }
                catch(Exception SecondEx)
                {
                    ReturnResult.Message += "使用原始URL開啟連結視窗錯誤,故未執行開啟視窗.\nInnerThrow:" + SecondEx.Message + Environment.NewLine;
                }
            }
            return ReturnResult;
        }
        /// <summary>
        /// URL編碼
        /// </summary>
        /// <param name="urlInput"></param>
        /// <returns></returns>
        public static string UrlEncode(this string urlInput)
        {
            if (string.IsNullOrWhiteSpace(urlInput))
            {
                return string.Empty;
            }
            if (Uri.TryCreate(urlInput, UriKind.RelativeOrAbsolute, out var SourceUrl))
            {
                //根網址
                //var RootUrl = new Uri(SourceUrl.GetLeftPart(UriPartial.Authority));
                Uri RootUrl = SourceUrl.IsAbsoluteUri ? new Uri(SourceUrl.GetLeftPart(UriPartial.Authority)) : new Uri("http://localhost");
                //相對網址
                var GetRelativeUri = SourceUrl.AbsolutePath;
                if (!string.IsNullOrWhiteSpace(SourceUrl.Query))
                {
                    //抓取Query String
                    var ReturnResult = System.Web.HttpUtility.ParseQueryString(SourceUrl.Query);
                    List<string> QueryStringList = new List<string>();
                    foreach (var keyItem in ReturnResult.AllKeys)
                    {
                        QueryStringList.Add(keyItem + "=" + Uri.EscapeDataString(ReturnResult[keyItem]));
                    }
                    var QueryString = string.Join("&", QueryStringList);
                    if (!string.IsNullOrWhiteSpace(QueryString))
                    {
                        GetRelativeUri += (!string.IsNullOrWhiteSpace(QueryString) ? "?" : string.Empty) + QueryString;
                    }
                }else if (!string.IsNullOrWhiteSpace(SourceUrl.Fragment))
                {
                    GetRelativeUri += SourceUrl.Fragment;
                }
                return new Uri(RootUrl, GetRelativeUri).AbsoluteUri;
            }
            else
            {
                return urlInput;
            }
        }
        /// <summary>
        /// URL解碼(逸出字元)[僅對於非根目錄網址進行解碼]
        /// </summary>
        /// <param name="urlInput"></param>
        /// <returns></returns>
        public static string UrlDecode(this string urlInput)
        {
            if (string.IsNullOrWhiteSpace(urlInput))
            {
                return string.Empty;
            }
            //if (Uri.TryCreate(Uri.UnescapeDataString(urlInput), UriKind.RelativeOrAbsolute, out var SourceUrl))
            if (Uri.TryCreate(urlInput, UriKind.RelativeOrAbsolute, out var SourceUrl))
            {
                //根網址
                var RootUrl = new Uri(SourceUrl.GetLeftPart(UriPartial.Authority));
                //相對網址
                var GetRelativeUri = Uri.UnescapeDataString(SourceUrl.AbsolutePath);

                if (!string.IsNullOrWhiteSpace(SourceUrl.Query))
                {
                    //抓取Query String
                    var ReturnResult = System.Web.HttpUtility.ParseQueryString(SourceUrl.Query);
                    List<string> QueryStringList = new List<string>();
                    foreach (var keyItem in ReturnResult.AllKeys)
                    {
                        QueryStringList.Add(Uri.UnescapeDataString(keyItem) + "=" + Uri.UnescapeDataString(ReturnResult[keyItem]));
                    }
                    var QueryString = string.Join("&", QueryStringList);
                    if (!string.IsNullOrWhiteSpace(QueryString))
                    {
                        GetRelativeUri += (!string.IsNullOrWhiteSpace(QueryString) ? "?" : string.Empty) + QueryString;
                    }
                }else if (!string.IsNullOrWhiteSpace(SourceUrl.Fragment))
                {
                    GetRelativeUri += SourceUrl.Fragment;
                }
                return new Uri(RootUrl, GetRelativeUri).AbsoluteUri;
            }
            else
            {
                return urlInput;
            }
            
        }
        /// <summary>
        /// URL是否包含空白 或 URL格式錯誤
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool HasInvalidUrlFormateOrUrlContainWhiteSpace(this string url)
        {
            Regex urlContainWhiteSpaceRegex = new Regex(@"\s");
            return !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute) || urlContainWhiteSpaceRegex.IsMatch(url ?? string.Empty);
        }
        /// <summary>
        /// URL是否包含空白
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool HasUrlContainWhiteSpace(this string url)
        {
            Regex urlContainWhiteSpaceRegex = new Regex(@"\s");
            return urlContainWhiteSpaceRegex.IsMatch(url ?? string.Empty);
        }
        /// <summary>
        /// URL是否包含逸出字元
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool HasUrlEscapeError(this string url)
        {
            return !string.Equals(url, Uri.EscapeDataString(url ?? string.Empty));
        }
        //public static Dictionary<string, string> SplitUrlKeyValuePairs(string QueryStr)
        //{
        //    Dictionary<string, string> ReturnResult = new Dictionary<string, string>();
        //    if (string.IsNullOrWhiteSpace(QueryStr))
        //    {
        //        return ReturnResult;
        //    }
        //    var SplitParam = QueryStr.Split('&');
        //    foreach (var item in SplitParam)
        //    {
        //        var KeyValue = item.Split('=');
        //        if (KeyValue != null && KeyValue.Length == 2 && !string.IsNullOrEmpty(KeyValue[0]))
        //        {
        //            if (ReturnResult.TryGetValue(KeyValue[0], out var itemValue) == false)
        //            {
        //                ReturnResult.Add(KeyValue[0], Uri.EscapeDataString(KeyValue[1]));
        //            }
        //        }
        //    }
        //    return ReturnResult;
        //}
        #endregion 網址URL處理

        #region Base64 Convert
        /// <summary>
        /// 文字字串使用 EncodingName 編碼成Base64字串 , 若傳入Null或是解碼失敗皆回傳string.Empty
        /// </summary>
        /// <param name="Source">明文文字字串</param>
        /// <param name="EncodingName">使用之編碼[預設使用UTF8]</param>
        /// <returns>經過 EncodingName 編碼之 加密Base64字串, 若傳入Null或是解碼失敗皆回傳string.Empty</returns>
        public static string StringConvertToBase64String(this string Source, Encoding EncodingName = null)
        {
            if (string.IsNullOrEmpty(Source))
            {
                return string.Empty;
            }
            if (EncodingName == null)
            {
                EncodingName = Encoding.UTF8;
            }
            byte[] ByteList = EncodingName.GetBytes(Source);
            if (ByteList != null)
            {
                return Convert.ToBase64String(ByteList);
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Base64字串使用 DecodingName 解碼成文字字串 , 若傳入Null或是解碼失敗皆回傳string.Empty
        /// </summary>
        /// <param name="Source">Base64字串</param>
        /// <param name="DecodingName">使用之解碼[預設使用UTF8]</param>
        /// <returns>經過 DecodingName 編碼之 解碼文字字串, 若傳入Null或是解碼失敗皆回傳string.Empty</returns>
        public static string Base64StringConvertToString(this string Source, Encoding DecodingName = null)
        {
            if (string.IsNullOrEmpty(Source))
            {
                return string.Empty;
            }
            if (DecodingName == null)
            {
                DecodingName = Encoding.UTF8;
            }
            byte[] BASE64DECODE_DATA = Convert.FromBase64String(Source);
            if (BASE64DECODE_DATA != null)
            {
                return DecodingName.GetString(BASE64DECODE_DATA);
            }
            else
            {
                return string.Empty;
            }

        }
        #endregion Base64 Convert

        #region Oracle.ALL_TAB_COLUMNS.DATA_TYPE 文字 轉 OracleDbType 

        /// <summary>
        /// Oracle.ALL_TAB_COLUMNS.DATA_TYPE 文字 轉 OracleDbType 
        /// </summary>
        /// <param name="OracleColumnDataType">ALL_TAB_COLUMNS.DATA_TYPE 文字</param>
        /// <returns></returns>
        public static Oracle.ManagedDataAccess.Client.OracleDbType GetOracleDbType(this string OracleColumnDataType)
        {
            try
            {
                Oracle.ManagedDataAccess.Client.OracleDbType oracleDbType;
                switch (OracleColumnDataType?.ToUpper())
                {
                    case "VARCHAR2":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2;
                        break;
                    case "NVARCHAR2":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.NVarchar2;
                        break;
                    case "NUMBER":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Decimal;
                        break;
                    case "FLOAT":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Single;
                        break;
                    case "LONG":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Long;
                        break;
                    case "DATE":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Date;
                        break;
                    case "BINARY_FLOAT":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.BinaryFloat;
                        break;
                    case "BINARY_DOUBLE":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.BinaryDouble;
                        break;
                    case "TIMESTAMP(3)":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.TimeStamp;
                        break;
                    case "TIMESTAMP(6)":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.TimeStamp;
                        break;
                    case "TIMESTAMP(9)":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.TimeStamp;
                        break;
                    case "RAW":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Raw;
                        break;
                    case "LONG RAW":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.LongRaw;
                        break;
                    case "ROWID":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2;
                        break;
                    case "UROWID":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2;
                        break;
                    case "CHAR":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Char;
                        break;
                    case "NCHAR":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.NChar;
                        break;
                    case "CLOB":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Clob;
                        break;
                    case "NCLOB":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.NClob;
                        break;
                    case "BLOB":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Blob;
                        break;
                    case "BFILE":
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.BFile;
                        break;
                    default:
                        oracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2;
                        break;
                }
                return oracleDbType;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region SQL INJECTION CHECK
        /// <summary>
        /// 過濾危險字串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ServiceResult<string> FilterSQLString(this string input)
        {
            bool containSQLInjectionAttack = false;
            ServiceResult<string> returnResult = new ServiceResult<string>(false, string.Empty, string.Empty);
            if (!string.IsNullOrWhiteSpace(input))
            {
                
                var inputStr = input.ToUpper();

                List<string> dangousSqlList = new List<string>()
                {
                    "DELETE FROM",
                    "INSERT INTO",
                    "TRUNCATE",
                    "DROP",
                };

                foreach (var item in dangousSqlList)
                {
                    var indexStart = 0;
                    var indexLength = 0;
                    if (inputStr?.Contains(item) is true)
                    {
                        indexStart = inputStr.IndexOf(item);
                        indexLength = item.Length;
                    }
                    if (indexStart > 0 && indexLength > 0)
                    {
                        input = input.Remove(indexStart, indexLength);
                        containSQLInjectionAttack = true;
                    }
                }

                var splitSpaceStrList = input.Split(new string[] { " ", Environment.NewLine, "　" }, StringSplitOptions.RemoveEmptyEntries);
                if (splitSpaceStrList?.Any() is true)
                {
                    
                    string previousStr1 = string.Empty;
                    var previousStr1IndexStart = 0;
                    var previousStr1IndexLength = 0;
                    string previousStr2 = string.Empty;
                    var previousStr2IndexStart = 0;
                    var previousStr2IndexLength = 0;
                    string previousStr3 = string.Empty;
                    var previousStr3IndexStart = 0;
                    var previousStr3IndexLength = 0;
                    int index = 0;
                    foreach (var item in splitSpaceStrList)
                    {
                        switch (index%3)
                        {
                            case 0:
                                previousStr1 = item?.ToUpper();
                                previousStr1IndexStart = input.IndexOf(item);
                                previousStr1IndexLength = item.Length;
                                break;
                            case 1:
                                previousStr2 = item?.ToUpper();
                                previousStr2IndexStart = input.IndexOf(item);
                                previousStr2IndexLength = item.Length;
                                break;
                            case 2:
                                previousStr3 = item?.ToUpper();
                                previousStr3IndexStart = input.IndexOf(item);
                                previousStr3IndexLength = item.Length;
                                break;
                        }

                        if (previousStr3?.ToUpper() == "SET" && (previousStr1?.ToUpper() == "UPDATE" || previousStr2?.ToUpper() == "UPDATE"))
                        {
                            if (previousStr3?.ToUpper() == "SET")
                            {
                                input = input.Remove(previousStr3IndexStart, previousStr3IndexLength);
                            }
                            if (previousStr2?.ToUpper() == "UPDATE")
                            {
                                input = input.Remove(previousStr2IndexStart, previousStr2IndexLength);
                            }
                            if (previousStr1?.ToUpper() == "UPDATE")
                            {
                                input = input.Remove(previousStr1IndexStart, previousStr1IndexLength);
                            }
                            
                            
                            //input = input.Remove(input.IndexOf(item), item.Length);
                            //input = input?.ToUpper()?.Replace(previousStr1, "");
                            //input = input?.ToUpper()?.Replace(previousStr2, "");
                            //input = input?.ToUpper()?.Replace(item, "");
                            containSQLInjectionAttack = true;
                            break;
                        }
                        index++;
                    }
                }
                
                returnResult.Data = input;
                returnResult.IsOk = !containSQLInjectionAttack;
            }
            return returnResult;
        }
        #endregion

        #region 台灣身份證,居留證 合法性檢查（邏輯直接複製小宇提供的舊code）

        /// <summary>
        /// 台灣身份證,居留證 合法性檢查
        /// </summary>
        /// <param name="IDNO">身分證號</param>
        /// <returns>Message:簡略錯誤說明, Content:詳細錯誤說明, Data:[第二碼判斷,True:本國人, False:外國人]</returns>
        public static ServiceResult<bool> VerifyIdnoInfo(this string IDNO)
        {
            return VerifyIdnoInfo_Interface(IDNO);
        }
        /// <summary>
        /// 台灣身份證,居留證 合法性檢查
        /// </summary>
        /// <param name="idno">欲檢查之字串</param>
        /// <returns>Message:簡略錯誤說明, Content:詳細錯誤說明, Data:[第二碼判斷,True:本國人, False:外國人]</returns>
        private static ServiceResult<bool> VerifyIdnoInfo_Interface(this string idno)
        {
            ServiceResult<bool> returnResult = new ServiceResult<bool>(false, string.Empty, false);
            returnResult.Content = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(idno))
                {
                    returnResult.Message = "身分證號不可為空白或空值!";
                    returnResult.Content = "身分證號不可為空白或空值!";
                    return returnResult;
                }
                if (idno?.Length != 10)
                {
                    returnResult.Message = $"身分證號長度:{idno?.Length}碼，正常須為10碼!";
                    returnResult.Content = $"身分證號長度:{idno?.Length}碼，正常須為10碼!";
                    return returnResult;
                }
                idno = idno?.ToUpper();
                char secondChar = idno[1];
                //身分證號第二碼
                HashSet<char> ValidSecondChars = new HashSet<char> { '1', '2', '8', '9', 'A', 'B', 'C', 'D' };
                if (TaiwanIdCardNumLetterMappingDic.ContainsKey(idno[0]) == false)
                {
                    returnResult.Message = $"身分證號，檢核未通過!";
                    returnResult.Content += $"身分證號首碼錯誤，[{idno[0]}]不在規定範圍內!" + Environment.NewLine;
                }else if (ValidSecondChars.Contains(secondChar) == false)
                {
                    returnResult.Message = $"身分證號，檢核未通過!";
                    returnResult.Content += $"身分證號第2碼錯誤，[{secondChar}]不在規定範圍內!" + Environment.NewLine;
                }else if (RegexUtility.IDNO_RPNO_RoughlyVerify.IsMatch(idno ?? string.Empty) == false)
                {
                    returnResult.Message = $"身分證號，檢核未通過!"; 
                    returnResult.Content += $"身分證號整體格式有誤，含有不合法的字元!" + Environment.NewLine;
                }

                int[] idNumbers = new int[11];
                int code = TaiwanIdCardNumLetterMappingDic[idno[0]];
                idNumbers[0] = code / 10;
                idNumbers[1] = code % 10;

                if (char.IsDigit(secondChar))
                {
                    if (secondChar == '1' || secondChar == '2')
                    {
                        returnResult.Data = true;
                    }
                    idNumbers[2] = secondChar - '0';
                }else if (TaiwanIdCardNumLetterMappingDic.TryGetValue(secondChar, out int secondCode))
                {
                    idNumbers[2] = secondChar % 10; //取個位數作為檢查用
                }
                else
                {
                    returnResult.Message = $"身分證號，檢核未通過!";
                    returnResult.Content += $"身分證號第2碼[{secondChar}]轉換檢查碼失敗!" + Environment.NewLine;
                }

                var errorIdnoMessage = new Dictionary<int, string>();
                var intNumberStr = string.Empty;
                for (int i = 2; i < 10; i++)
                {
                    if (char.IsDigit(idno[i]) == false)
                    {
                        errorIdnoMessage.Add(i, idno[i].ToString());
                        idNumbers[i + 1] = '_';
                        intNumberStr += idno[i];
                    }
                    else
                    {
                        idNumbers[i + 1] = idno[i] - '0';
                        intNumberStr += idNumbers[i + 1].ToString();
                    }
                }

                if (errorIdnoMessage.Any())
                {
                    returnResult.Message = $"身分證號，檢核未通過!";
                    returnResult.Content += $"身分證號第3~10碼[{intNumberStr}]有非數字，轉換失敗!" + Environment.NewLine;
                }

                //加權係數
                int[] weights = new int[] { 1, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 };
                int sum = 0;
                for (int i = 0; i < weights.Length; i++)
                {
                    sum += idNumbers[i] * weights[i];
                }

                if (sum % 10 == 0)
                {

                }
                else
                {
                    returnResult.Message = $"身分證號，檢核未通過!";
                    returnResult.Content += $"身分證號總加權碼[{sum}%10={sum%10}] != 0，驗證失敗!" + Environment.NewLine;
                }

                if (!string.IsNullOrWhiteSpace(returnResult.Content))
                {
                    
                }
                else
                {
                    returnResult.IsOk = true;
                }
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message = "THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Data = false;
                returnResult.Exception = ex;
            }

            return returnResult;
            



            ////判斷是否為身分證字號
            //bool IsIDNO = false;
            //Dictionary<int, string> ErrorDictionary = new Dictionary<int, string>()
            //{
            //    {0, "驗證正確" }
            //    ,{1, "字數不是10碼"}
            //    ,{2, "第二碼非[國民身分證:1,2],[居留證:A,B,C,D],[新式居留證:8,9]" }
            //    ,{3, "首碼錯誤" }
            //    ,{4, "檢查碼錯誤" }
            //    ,{5, "傳入數值為空或NULL" }
            //};
            ////第二碼,新式居留證[8:男,9:女]; 舊式居留證[A,B,C,D]於120/1/1停用
            //if (string.IsNullOrWhiteSpace(idno))
            //{
            //    return (5, ErrorDictionary.FirstOrDefault(x => x.Key == 5).Value, IsIDNO);
            //}
            //List<string> FirstEng =
            //    new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "J",
            //                   "K", "L", "M", "N", "P", "Q", "R", "S", "T",
            //                   "U", "V", "X", "Y", "W", "Z", "I", "O" };

            //string aa = idno.ToUpper();
            //int intFst1 = 0, intFst2 = 0;
            //if (aa.Trim().Length != 10)
            //    return (1, ErrorDictionary.FirstOrDefault(x => x.Key == 1).Value, IsIDNO);
            //for (int x = 0; x < FirstEng.Count; x++)
            //{
            //    if (aa.Substring(0, 1) == FirstEng[x])
            //    {
            //        intFst1 = x + 10;
            //        break;
            //    }
            //}
            //if (intFst1 == 0)
            //    return (3, ErrorDictionary.FirstOrDefault(x => x.Key == 3).Value, IsIDNO);

            //string strTmp = aa.Substring(1, 1);
            //if (strTmp == "1" || strTmp == "2")
            //{
            //    intFst2 = int.Parse(strTmp);
            //    IsIDNO = true;
            //}
            //else
            //{
            //    //for 外國人統一證號
            //    switch (strTmp)
            //    {
            //        case "A":
            //            intFst2 = 10; break;
            //        case "B":
            //            intFst2 = 11; break;
            //        case "C":
            //            intFst2 = 12; break;
            //        case "D":
            //            intFst2 = 13; break;
            //        // 新式居留證
            //        case "8":
            //            intFst2 = 8; break;
            //        case "9":
            //            intFst2 = 9; break;
            //    }
            //}
            //if (intFst2 == 0)
            //    return (2, ErrorDictionary.FirstOrDefault(x => x.Key == 2).Value, IsIDNO);

            //aa = string.Format("{0}{1}{2}", intFst1, intFst2 % 10, aa.Substring(2, 8));
            //int ss = int.Parse(aa.Substring(0, 1));

            //for (int i = 1; aa.Length > i; i++)
            //    ss = ss + (int.Parse(aa.Substring(i, 1)) * (10 - i));

            //aa = ss.ToString();
            //if (idno.Substring(9, 1) == "0")
            //{
            //    return aa.Substring(aa.Length - 1, 1) == "0" ? (0, ErrorDictionary.FirstOrDefault(x => x.Key == 0).Value, IsIDNO) : (4, ErrorDictionary.FirstOrDefault(x => x.Key == 4).Value, IsIDNO);
            //}
            //return idno.Substring(9, 1) == (10 - int.Parse(aa.Substring(aa.Length - 1, 1))).ToString() ? (0, ErrorDictionary.FirstOrDefault(x => x.Key == 0).Value, IsIDNO) : (4, ErrorDictionary.FirstOrDefault(x => x.Key == 4).Value, IsIDNO);
        }
        #endregion

        #region 文字切割運算(使用Big5 Byte計算)
        /// <summary>
        /// 文字切割運算(使用Big5 Byte計算)
        /// </summary>
        /// <param name="Source">切割字串</param>
        /// <param name="startPos">起始位置</param>
        /// <param name="endPos">結束位置</param>
        /// <returns></returns>
        public static string StrSubsting(this string Source, int startPos, int endPos)
        {
            try
            {
                if (string.IsNullOrEmpty(Source))
                {
                    return string.Empty;
                }
                if (startPos < 0 || endPos < 0)
                {
                    return string.Empty;
                }
                if (endPos < startPos)
                {
                    return string.Empty;
                }
                if (Source.Length - (endPos - startPos) < 0)
                {
                    var strByteLimit = Encoding.GetEncoding("big5").GetBytes(Source);
                    int beginIndexLimit = startPos - 1;
                    int lengthLimit = strByteLimit.Length - startPos + 1;
                    var resultLimit = strByteLimit.Where((ascii, indexLimit) => indexLimit >= beginIndexLimit && indexLimit < beginIndexLimit + lengthLimit).ToArray();
                    var big5Limit = Encoding.GetEncoding("big5").GetString(resultLimit);
                    //去除UniCode 控制字元或不可見字元
                    if (!string.IsNullOrEmpty(big5Limit))
                    {
                        var cleanStr = RegexUtility.UnicodeControlOrInvisibleChar.Replace(big5Limit ?? string.Empty, string.Empty);
                        big5Limit = cleanStr;
                    }
                    return big5Limit;
                }
                var strByte = Encoding.GetEncoding("big5").GetBytes(Source);
                int beginIndex = startPos - 1;
                int length = endPos - startPos + 1;
                var result = strByte.Where((ascii, index) => index >= beginIndex && index < beginIndex + length).ToArray();
                var big5 = Encoding.GetEncoding("big5").GetString(result);
                if (!string.IsNullOrEmpty(big5))
                {
                    var cleanStr = RegexUtility.UnicodeControlOrInvisibleChar.Replace(big5 ?? string.Empty, string.Empty);
                    big5 = cleanStr;
                }
                return big5;
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 文字切割運算(使用Big5 Byte計算)
        /// </summary>
        /// <param name="source">切割字串</param>
        /// <param name="startPos">起始位置</param>
        /// <param name="endPos">結束位置</param>
        /// <param name="isNeedTrimResult">是否需要將運算字串進行Trim(預設:False)</param>
        /// <returns></returns>
        public static string StrSubsting(this StringBuilder source, int startPos, int endPos, bool isNeedTrimResult = false)
        {
            try
            {
                string Source = source?.ToString();
                if (string.IsNullOrEmpty(Source))
                {
                    return string.Empty;
                }
                if (startPos < 0 || endPos < 0)
                {
                    return string.Empty;
                }
                if (endPos < startPos)
                {
                    return string.Empty;
                }
                if (Source.Length - (endPos - startPos) < 0)
                {
                    var strByteLimit = Encoding.GetEncoding("big5").GetBytes(Source);
                    int beginIndexLimit = startPos - 1;
                    int lengthLimit = strByteLimit.Length - startPos + 1;
                    var resultLimit = strByteLimit.Where((ascii, indexLimit) => indexLimit >= beginIndexLimit && indexLimit < beginIndexLimit + lengthLimit).ToArray();
                    var big5Limit = Encoding.GetEncoding("big5").GetString(resultLimit);
                    if (isNeedTrimResult)
                    {
                        big5Limit = big5Limit?.Trim();
                    }
                    //去除UniCode 控制字元或不可見字元
                    if (!string.IsNullOrEmpty(big5Limit))
                    {
                        var cleanStr = RegexUtility.UnicodeControlOrInvisibleChar.Replace(big5Limit ?? string.Empty, string.Empty);
                        big5Limit = cleanStr;
                    }
                    return big5Limit;
                }
                var strByte = Encoding.GetEncoding("big5").GetBytes(Source);
                int beginIndex = startPos - 1;
                int length = endPos - startPos + 1;
                var result = strByte.Where((ascii, index) => index >= beginIndex && index < beginIndex + length).ToArray();
                var big5 = Encoding.GetEncoding("big5").GetString(result);
                if (isNeedTrimResult)
                {
                    big5 = big5?.Trim();
                }
                //去除UniCode 控制字元或不可見字元
                if (!string.IsNullOrEmpty(big5))
                {
                    var cleanStr = RegexUtility.UnicodeControlOrInvisibleChar.Replace(big5 ?? string.Empty, string.Empty);
                    big5 = cleanStr;
                }
                return big5;
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 轉換String Array
        /// </summary>
        /// <param name="InputStringArray">輸入</param>
        /// <param name="index">Index</param>
        /// <param name="result">輸出</param>
        /// <param name="IsResultNeedTrim">是否需要將輸出Trim?</param>
        /// <returns></returns>
        public static bool TryGetStringArray(this string[] InputStringArray, int index, out string result, bool IsResultNeedTrim = false)
        {
            result = default;
            if (InputStringArray == null)
            {
                return false;
            }
            if (index < 0 || index >= InputStringArray.Length)
            {
                return false;
            }
            result = InputStringArray[index];
            if (IsResultNeedTrim)
            {
                result = result?.Trim();
            }
            return true;
        }
        #endregion

        #region 根據中文與半形字的寬度 補足指定顯示長度(中文視為2寬，英數字視為1寬)
        /// <summary>
        /// 根據中文與半形字的寬度 補足指定顯示長度(中文視為2寬，英數字視為1寬)
        /// 如果數入文字含有全形則補全形空白，反之則補半形空白
        /// </summary>
        /// <param name="inputStr">輸入文字</param>
        /// <param name="totalDisplayWidth">顯示長度</param>
        /// <param name="StrContainFullWidthWithFullSpace">如果輸入文字含有全形則補全形空白，反之則補半形空白[預設:True]</param>
        /// <returns></returns>
        public static string PadRightByFullWidth(this string inputStr, int totalDisplayWidth, bool StrContainFullWidthWithFullSpace = true)
        {
            if (inputStr == null) new string(' ', Math.Max(0, totalDisplayWidth));
            
            int currentWidth = inputStr.Sum(c => IsFullWidth(c) ? 2 : 1);
            var ContainFullWidth = inputStr.Any(c => IsFullWidth(c));
            int paddingWidth = totalDisplayWidth - currentWidth;
            if (StrContainFullWidthWithFullSpace)
            {
                return inputStr + new string((ContainFullWidth ? '　' : ' '), Math.Max(0, (ContainFullWidth ? paddingWidth / 2 : paddingWidth)));
            }
            else
            {
                return inputStr + new string(' ', Math.Max(0, paddingWidth));
            }
        }
        /// <summary>
        /// 判斷字元是否為全形（中文字含標點符號、日文、韓文等）
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsFullWidth(char c)
        {
            //中日韓統一表意文字區間
            return (c >= 0x2E80 && c <= 0x9FFF) || // 中日韓
                   (c >= 0xFF01 && c <= 0xFF60) || // 全形標點
                   (c >= 0xFFE0 && c <= 0xFFE6);   // 全形符號
        }
        #endregion
        /// <summary>
        /// 取得IPV4 位置
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIPAddress()
        {
            try
            {
                // 取得所有網路介面（網卡）
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    // 排除非運作中、迴路地址 (Loopback)、虛擬機網卡
                    if (ni.OperationalStatus == OperationalStatus.Up &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        !ni.Description.Contains("Virtual") &&
                        !ni.Description.Contains("VMware"))
                    {
                        var props = ni.GetIPProperties();
                        // 找 IPv4
                        var ip = props.UnicastAddresses
                            .FirstOrDefault(x => x.Address.AddressFamily == AddressFamily.InterNetwork);

                        if (ip != null)
                        {
                            return ip.Address.ToString();
                        }
                    }
                }
            }
            catch
            {
                return "0.0.0.0";
            }
            return "0.0.0.0";
        }

    }


    /// <summary>
    /// 自定義LogWriter
    /// </summary>
    public class LogWriter : StreamWriter
    {
        private readonly TextWriter _textWriter;
        /// <summary>
        /// 自定義LogWriter
        /// </summary>
        /// <param name="path">路徑</param>
        /// <param name="textWriter">Console.Out</param>
        public LogWriter(string path, TextWriter textWriter) : base(path)
        {
            _textWriter = textWriter;
        }
        public override void WriteLine(string? value)
        {
            var message = $"[{DateTime.Now.ToFullDateTimeMillisecond()}]{value}";
            base.WriteLine(message);
            //輸出到 Console.Out用
            //_textWriter.WriteLine(message);
            //當AutoFlush == true, 會自動Flush 緩衝區字串
            if(AutoFlush == true)
            {
                //輸出到VS Console
                System.Diagnostics.Debugger.Log(0, null, message + Environment.NewLine);
            }
        }
        public override void Write(string? value)
        {
            var message = $"[{DateTime.Now.ToFullDateTimeMillisecond()}]{value}";
            base.Write(message);
            //輸出到 Console.Out用
            _textWriter.Write(message);
            //當AutoFlush == true, 會自動Flush 緩衝區字串
            if (AutoFlush == true)
            {
                //輸出到VS Console
                System.Diagnostics.Debugger.Log(0, null, message + Environment.NewLine);
            }
        }
    }

    

}
