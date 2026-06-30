using System;
using System.Globalization;

namespace CoreBase.Help
{
    /// <summary>
    /// 日期型態擴充功能
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日)("yyyy/MM/dd")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime">日期時間</param>
        /// <returns>Birthday date in string format</returns>
        /// <example>2017/08/04</example>
        public static string ToDateTimeString(this DateTime dateTime)
        {
            //CultureInfo culture = CultureInfo.GetCultureInfo("zh-TW");, culture
            //, CultureInfo.InvariantCulture 避免使用者系統使用民國曆導致轉換失敗
            return dateTime.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日)("yyyy/MM/dd")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime">日期時間</param>
        /// <returns>yyyy/MM/dd, 轉換失敗則回傳Null</returns>
        /// <example>2017/08/04</example>
        public static string ToDateTimeString(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToDateTimeString() : null;
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年月日)("yyyyMMdd")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime">日期時間</param>
        /// <returns>Birthday date in string format</returns>
        /// <example>2017/08/04</example>
        public static string ToDateTimeString2(this DateTime dateTime)
        {
            //CultureInfo culture = CultureInfo.GetCultureInfo("zh-TW");, culture
            //, CultureInfo.InvariantCulture 避免使用者系統使用民國曆導致轉換失敗
            return dateTime.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年月日)("yyyyMMdd")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime">日期時間</param>
        /// <returns>yyyyMMdd, 轉換失敗則回傳Null</returns>
        /// <example>2017/08/04</example>
        public static string ToDateTimeString2(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToDateTimeString2() : null;
        }

        /// <summary>
        /// 轉換為 客製化的時間字串(時:分:秒)("HH:mm:ss")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime">時間</param>
        /// <returns>23:59:59, 轉換失敗則回傳Null</returns>
        /// <example>23:59:59, 轉換失敗則回傳Null</example>
        public static string ToTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 轉換為 客製化的時間字串(時:分:秒)("HH:mm:ss")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime">時間</param>
        /// <returns>HH:mm:ss, 轉換失敗則回傳Null</returns>
        /// <example>23:59:59, 轉換失敗則回傳Null</example>
        public static string ToTimeString(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToTimeString() : null;
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日 時:分:秒)("yyyy/MM/dd HH:mm:ss")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFullDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日 時:分:秒)("yyyy/MM/dd HH:mm:ss")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>yyyy/MM/dd HH:mm:ss, 轉換失敗則回傳Null</returns>
        public static string ToFullDateTime(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToFullDateTime() : null;
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年月日時分秒)("yyyyMMddHHmmss")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFullDateTime2(this DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年月日時分秒)("yyyyMMddHHmmss")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>yyyy/MM/dd HH:mm:ss, 轉換失敗則回傳Null</returns>
        public static string ToFullDateTime2(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToFullDateTime2() : null;
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日 時:分:秒 毫秒)("yyyy/MM/dd HH:mm:ss fff")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFullDateTimeMillisecond(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy/MM/dd HH:mm:ss fff", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日 時:分:秒 毫秒)("yyyy/MM/dd HH:mm:ss fff")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>yyyy/MM/dd HH:mm:ss fff, 轉換失敗則回傳Null</returns>
        public static string ToFullDateTimeMillisecond(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToFullDateTimeMillisecond() : null;
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(時:分:秒 毫秒)("HH:mm:ss fff")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>HH:mm:ss fff</returns>
        /// <example>23:59:59 001</example>
        public static string ToFullTimeMillisecond(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm:ss fff", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(時:分:秒 毫秒)("HH:mm:ss fff")
        /// [新增CultureInfo判斷]
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>23:59:59 001, 轉換失敗則回傳Null</returns>
        /// <example>23:59:59 001, 轉換失敗則回傳Null</example>
        public static string ToFullTimeMillisecond(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToFullTimeMillisecond() : null;
        }

        /// <summary>
        /// 民國年月日(yyyMMdd)
        /// </summary>
        /// <param name="dateTime">Datetime</param>
        /// <param name="OutputSeparateLine">是否輸出 / (yyy/MM/dd)</param>
        /// <returns></returns>
        public static string ToClaimTaiwanDate(this DateTime dateTime, bool OutputSeparateLine = false)
        {
            if (dateTime == DateTime.MinValue)
            {
                return string.Empty;
            }
            return string.Format(
                    CultureInfo.CurrentCulture, (OutputSeparateLine ? "{0}/{1}/{2}" : "{0}{1}{2}"),
                    dateTime.ToClaimTaiwanYearNumber(),
                    dateTime.Month.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Day.ToString("D2", CultureInfo.CurrentCulture)
                   );
            //return string.Format(
            //        CultureInfo.CurrentCulture, "{0}{1}{2}",
            //        dateTime.ToClaimTaiwanYearNumber(),
            //        dateTime.Month.ToString("D2", CultureInfo.CurrentCulture),
            //       dateTime.Day.ToString("D2", CultureInfo.CurrentCulture)
            //       );
        }

        /// <summary>
        /// 民國年月日(yyyMMdd)
        /// </summary>
        /// <param name="dateTime">Nullable Datetime</param>
        /// <param name="OutputSeparateLine">是否輸出 / (yyy/MM/dd)</param>
        /// <returns></returns>
        public static string ToClaimTaiwanDate(this DateTime? dateTime, bool OutputSeparateLine = false)
        {
            if (!dateTime.HasValue)
            {
                return string.Empty;
            }

            return dateTime.Value.ToClaimTaiwanDate(OutputSeparateLine);
        }

        /// <summary>
        /// 民國年月日時分(yyyMMddHHmm)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanDateTimeHHmm(this DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return string.Empty;
            }

            return string.Format(
                   CultureInfo.CurrentCulture, "{0}{1}{2}{3}{4}",
                   dateTime.ToClaimTaiwanYearNumber(),
                   dateTime.Month.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Day.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Hour.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Minute.ToString("D2", CultureInfo.CurrentCulture)
                   );
        }
        /// <summary>
        /// 民國年月日時分秒(yyyMMddHHmmss)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanDateTimeHHmmss(this DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return string.Empty;
            }

            return string.Format(
                CultureInfo.CurrentCulture, "{0}{1}{2}{3}{4}{5}",
                dateTime.ToClaimTaiwanYearNumber(),
                dateTime.Month.ToString("D2", CultureInfo.CurrentCulture),
                dateTime.Day.ToString("D2", CultureInfo.CurrentCulture),
                dateTime.Hour.ToString("D2", CultureInfo.CurrentCulture),
                dateTime.Minute.ToString("D2", CultureInfo.CurrentCulture),
                dateTime.Second.ToString("D2", CultureInfo.CurrentCulture)
            );
        }

        /// <summary>
        /// 民國年月日時分(yyyMMddHHmm)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>失敗回傳String.Empty</returns>
        public static string ToClaimTaiwanDateTimeHHmm(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return string.Empty;
            }

            return dateTime.Value.ToClaimTaiwanDateTimeHHmm();
        }
        /// <summary>
        /// 民國年月日時分秒(yyyMMddHHmmss)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>失敗回傳String.Empty</returns>
        public static string ToClaimTaiwanDateTimeHHmmss(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return string.Empty;
            }

            return dateTime.Value.ToClaimTaiwanDateTimeHHmmss();
        }

        /// <summary>
        /// 民國年月日時分秒(yyyMMddHHmmss)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanDateTime(this DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return string.Empty;
            }

            return string.Format(
                   CultureInfo.CurrentCulture, "{0}{1}{2}{3}{4}{5}",
                   dateTime.ToClaimTaiwanYearNumber(),
                   dateTime.Month.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Day.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Hour.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Minute.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Second.ToString("D2", CultureInfo.CurrentCulture)
                   );
        }

        /// <summary>
        /// 民國年月日時分秒(yyyMMddHHmmss)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanDateTime(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return string.Empty;
            }

            return dateTime.Value.ToClaimTaiwanDateTime();
        }

        /// <summary>
        /// 取得民國年(國字樣式ex:1911→前1；1912→元；1913→2)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanYear(this DateTime dateTime)
        {
            var taiwanCalendar = new TaiwanCalendar();

            if (dateTime >= new DateTime(1913, 1, 1))
            {
                return taiwanCalendar.GetYear(dateTime).ToString();
            }
            if (dateTime >= new DateTime(1912, 1, 1))
            {
                return "元";
            }
            else
            {
                return "前" + Math.Abs(dateTime.Year - 1912).ToString(CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// 取得民國年(數值樣式ex:1911→-01；1912→001；1913→002)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanYearNumber(this DateTime dateTime)
        {
            var taiwanCalendar = new TaiwanCalendar();

            if (dateTime >= new DateTime(1912, 1, 1))
            {
                return taiwanCalendar.GetYear(dateTime).ToString("D3");
            }
            else
            {
                return "-" + Math.Abs(dateTime.Year - 1912).ToString(CultureInfo.CurrentCulture).PadLeft(2, '0');
            }
        }

        /// <summary>
        /// 取得月份最後一天最後一秒
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime getLastDayLastMoment(this DateTime datetime)
        {
            return datetime.getLastDay().getDateEnd();
        }

        /// <summary>
        /// 取得月份最後一天
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <returns></returns>
        public static DateTime getLastDay(this DateTime dateTime)
        {
            var days = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            return new DateTime(dateTime.Year, dateTime.Month, days);
        }

        /// <summary>
        /// 取得月份第一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getFirstDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// 取得月份上個月最後一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getLastMonthLasttDay(this DateTime dateTime)
        {
            return dateTime.getFirstDay().AddDays(-1);
        }

        /// <summary>
        /// 取得月份上個月第一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getLastMonthFirstDay(this DateTime dateTime)
        {
            return dateTime.getLastMonthLasttDay().getFirstDay();
        }

        /// <summary>
        /// 取得當日一開始那一秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getDateStart(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// 取得當日一開始那一秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? getDateStart(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return dateTime;
            }

            return dateTime.Value.getDateStart();
        }

        /// <summary>
        /// 取得當日最後那一秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getDateEnd(this DateTime dateTime)
        {
            // 因為 Oracle 好像會吃到毫秒之類的更細的細節，為了保險起見，從-1秒，變-1Ticks
            // 時間就會變成 23:59:59.9999999
            return dateTime.Date.AddDays(1).AddTicks(-1);
        }

        /// <summary>
        /// 取得當日最後那一秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? getDateEnd(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return dateTime;
            }

            return dateTime.Value.getDateEnd();
        }

        /// <summary>
        /// 去掉毫秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getDateToSec(this DateTime dateTime)
        {
            string[] format = { "yyyy/MM/dd HH:mm" };
            DateTime.TryParseExact(dateTime.ToFullDateTime(), format, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dt);

            return dt;
        }

        /// <summary>
        /// 去掉毫秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? getDateToSec(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return dateTime;
            }

            return dateTime.Value.getDateToSec();
        }

        /// <summary>
        /// 取得兩日期差異之年、月、日
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static (int years, int months, int days) TimespanToDate(this DateTime self, DateTime target)
        {
            int years, months, days;
            // 因為只需取量，不決定誰大誰小，所以如果self < target時要交換將大的擺前面
            if (self < target)
            {
                var tmp = target;
                target = self;
                self = tmp;
            }

            // 將年轉換成月份以便用來計算
            months = 12 * (self.Year - target.Year) + (self.Month - target.Month);

            // 如果天數要相減的量不夠時要向月份借天數補滿該月再來相減
            if (self.Day < target.Day)
            {
                months--;
                days = DateTime.DaysInMonth(target.Year, target.Month) - target.Day + self.Day;
            }
            else
            {
                days = self.Day - target.Day;
            }

            // 天數計算完成後將月份轉成年
            years = months / 12;
            months = months % 12;

            return (years, months, days);
        }

        /// <summary>
        /// 健保年齡計算(精確到月)
        /// Example: 2018/05/05 ~ 2019/05/01 => (0, 11, 26)
        /// Example: 2018/05/05 ~ 2019/05/05 => (1, 0, 0)
        /// </summary>
        /// <param name="birthday">生日</param>
        /// <param name="specificDate">指定日期</param>
        /// <returns>(年, 月, 日)</returns>
        public static (int years, int months, int days) ConvertToNHIAges(this DateTime birthday, DateTime specificDate)
        {
            int enoughOneMonthDays = 30; // 足月天數
            int enoughOneYearMonths = 12; // 足年月數

            int birthdayYear = birthday.Year;
            int birthdayMonth = birthday.Month;
            int birthdayDay = birthday.Day;

            int specificYear = specificDate.Year;
            int specificMonth = specificDate.Month;
            int specificDay = specificDate.Day;

            int resultYear = 0;
            int resultMonth = 0;
            int resultDay = 0;

            // 年月日相減
            resultYear = specificYear - birthdayYear;
            resultMonth = specificMonth - birthdayMonth;
            resultDay = specificDay - birthdayDay;

            // 天數不足 則往前借一個月
            if (resultDay < 0)
            {
                resultDay += enoughOneMonthDays;
                resultMonth--;
            }

            // 月份不足 則往前借一年
            if (resultMonth < 0)
            {
                resultMonth += enoughOneYearMonths;
                resultYear--;
            }

            // 超過30天則為足月 換成多一個月
            if (resultDay >= enoughOneMonthDays)
            {
                resultDay -= enoughOneMonthDays;
                resultMonth++;

                // 超過12月則足年 換成多一年
                if (resultMonth >= enoughOneYearMonths)
                {
                    resultMonth -= enoughOneYearMonths;
                    resultYear++;
                }
            }

            return (resultYear, resultMonth, resultDay);
        }

        /// <summary>
        /// 健保年齡計算
        /// Example: 2018/05/05 ~ 2019/05/01 => (0, 11, 26)
        /// Example: 2018/05/05 ~ 2019/05/05 => (1, 0, 0)
        /// </summary>
        /// <param name="birthday">生日</param>
        /// <param name="specificDate">指定日期</param>
        /// <returns>(年, 月, 日)</returns>
        public static (int years, int months, int days) ConvertToNHIAges(this DateTime birthday, DateTime specificDate, string returnUnit)
        {
	        int enoughOneMonthDays = 30; // 足月天數
	        int enoughOneYearMonths = 12; // 足年月數

	        int birthdayYear = birthday.Year;
	        int birthdayMonth = birthday.Month;
	        int birthdayDay = birthday.Day;

	        int specificYear = specificDate.Year;
	        int specificMonth = specificDate.Month;
	        int specificDay = specificDate.Day;

	        int resultYear = 0;
	        int resultMonth = 0;
	        int resultDay = 0;

	        // 年月日相減
	        resultYear = specificYear - birthdayYear;
	        resultMonth = specificMonth - birthdayMonth;
	        resultDay = specificDay - birthdayDay;

	        // 天數不足 則往前借一個月
	        if (resultDay < 0)
	        {
		        resultDay += enoughOneMonthDays;
		        resultMonth--;
	        }

	        // 月份不足 則往前借一年
	        if (resultMonth < 0)
	        {
		        resultMonth += enoughOneYearMonths;
		        resultYear--;
	        }

	        return (resultYear, resultMonth, resultDay);
        }

        /// <summary>
        /// 健保年齡計算(精確到日)
        /// Example: 2018/05/05 ~ 2019/05/01 => (0, 11, 26)
        /// Example: 2018/05/05 ~ 2019/05/05 => (1, 0, 1)
        /// </summary>
        /// <param name="birthday">生日</param>
        /// <param name="specificDate">指定日期</param>
        /// <returns>(年, 月, 日)</returns>
        public static (int years, int months, int days) ConvertToNHIAgesToDay(this DateTime birthday, DateTime specificDate)
        {
            int enoughOneYearDays = 365; // 一年365天
            int enoughSixMonthDays = 180; // 六個月180天
            int enoughOneMonthDays = 30; // 一個月30天

            int resultYear = 0;
            int resultMonth = 0;
            int resultDay = 0;

            // 使用 年定義的天數 去計算 共有幾年及剩餘天數
            var getTimeResult = getTimes((specificDate.getDateStart() - birthday.getDateStart()).Days, enoughOneYearDays, resultYear);
            // 取得總共幾歲
            resultYear = getTimeResult.times;

            // 使用 六個月定義的天數 去計算 是否有滿六個月及剩餘天數
            getTimeResult = getTimes(getTimeResult.days, enoughSixMonthDays, resultMonth);
            if (getTimeResult.times > 0)
            {
                // 只能計算一次滿六個月
                resultMonth = 6;

                // 如果滿二次六個月必須要歸還剩餘天數
                if (getTimeResult.times == 2)
                {
                    getTimeResult.days += enoughSixMonthDays;
                }
            }

            // 使用 一個月定義的天數 報計算 是否有滿一個月及剩餘天數
            getTimeResult = getTimes(getTimeResult.days, enoughOneMonthDays, resultMonth);
            resultMonth = getTimeResult.times;

            // 如果為12個月，則須進行特殊處理
            if (resultMonth == 12)
            {
                // 因為 12個月應該要進位，但未滿365日，所以需進行微調
                var days = 360 + getTimeResult.days;
                resultMonth = 11;
                resultDay = new DateTime(2023, 1, 1).AddDays(days).AddDays(-2).Day;
            }
            else
            {
                // 將剩餘天數 回傳
                resultDay = getTimeResult.days;
            }

            return (resultYear, resultMonth, resultDay);
        }

        /// <summary>
        /// 健保年齡計算(精確到年)
        /// Example: 2018/05/05 ~ 2019/05/01 => (1, X, X)
        /// Example: 2018/05/05 ~ 2019/05/05 => (1, X, X)
        /// </summary>
        /// <param name="birthday">生日</param>
        /// <param name="specificDate">指定日期</param>
        /// <returns>(年, 月, 日)</returns>
        public static int ConvertToNHIAgesToYear(this DateTime birthday, DateTime specificDate)
        {
            int birthdayYear = birthday.Year;
            int specificYear = specificDate.Year;

            int resultYear = 0;
            resultYear = specificYear - birthdayYear;

            return resultYear;
        }

        /// <summary>
        /// 遞回計算能算幾次
        /// </summary>
        /// <param name="totalDays"></param>
        /// <param name="specificDays"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        private static (int times, int days) getTimes(int totalDays, int specificDays, int times)
        {
            var resultTimes = times;
            var resultDays = totalDays;

            // 如果總天數 大於 差異天數
            if (totalDays >= specificDays)
            {
                // 次數 + 1
                resultTimes += 1;
                // 剩餘天數 為 總天數 減 定義天數
                resultDays = totalDays - specificDays;

                // 如果剩餘天數 大於 差異天數
                // 進遞迴
                if (resultDays >= specificDays)
                {
                    var result = getTimes(resultDays, specificDays, resultTimes);
                    resultTimes = result.times;
                    resultDays = result.days;
                }
            }

            // 回傳次數 及 剩餘天數
            return (resultTimes, resultDays);
        }

        /// <summary>
        /// 取得當年最後一天
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <returns></returns>
        public static DateTime getYearLastDay(this DateTime dateTime)
        {            
            return new DateTime(dateTime.Year, 12, 31);
        }

        /// <summary>
        /// 取得當年第一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getYearFirstDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 1, 1);
        }
    }
}