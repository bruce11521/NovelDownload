using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CoreBase.Help
{
    public class DateTimeHelper
    {

        #region 「西元日期時間字串」轉「DateTime」
        /// <summary>
        /// 「西元日期時間字串」轉「DateTime」
        /// </summary>
        /// <param name="addateStr">西元日期時間字串</param>
        /// <param name="format">日期樣式</param>
        /// <returns>DateTime</returns>
        public static DateTime? ADDateStrToDateTime(string addateStr, string format)
        {
            //使用 CultureInfo.InvariantCulture 解析各種國別不同地區設定；
            //使用 DateTimesStyles.AllowWhiteSpaces 忽略字串一些無意義的空白。
            //如此一來，即使像 " 2008/3 /18 PM 02: 50:23 " 這麼醜陋的字串，也可以成功轉到成 DateTime 型態。
            DateTime? dt = null;
            try
            {
                dt = DateTime.ParseExact(addateStr, format, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }
        #endregion

        #region 檢查是否為「民國日期數字字串」
        /// <summary>
        /// 檢查是否為「民國日期數字字串」 例：1030528,0990103
        /// </summary>
        /// <param name="inputStr">輸入的字串</param>
        /// <returns>是否為民國日期數字字串</returns>
        public static bool IsTWDateNum(String inputStr)
        {
            bool isOK = true;

            String regStr;
            regStr = @"^(([0-9]{3})(0?[1-9]|1[012])(0?[1-9]|[12][0-9]|3[01]))$";
            Regex regDateTime = new System.Text.RegularExpressions.Regex(regStr);
            isOK = regDateTime.IsMatch(inputStr);

            if (isOK)
            {
                inputStr = string.Format("{0}/{1}/{2}",
                    Convert.ToInt32(inputStr.Substring(0, 3)) + 1911,
                    inputStr.Substring(3, 2),
                    inputStr.Substring(5, 2));
                isOK = IsDateStr(inputStr);
            }

            return isOK;
        }
        #endregion

        #region 檢查是否為「時間數字字串」
        /// <summary>
        /// 檢查是否為「時間數字字串」
        /// 時間格式：HHmmss
        /// </summary>
        /// <param name="inputStr">輸入的字串</param>
        /// <returns>是否為「時間數字字串」</returns>
        public static bool IsTimeNum(String inputStr)
        {
            bool isOK = true;

            String regStr;
            regStr = @"^(([0-1]{1}[0-9]{1}|2[0-3]{1})([0-5]{1}[0-9]{1})([0-5]{1}[0-9]{1}))$";
            Regex regDateTime = new System.Text.RegularExpressions.Regex(regStr);
            isOK = regDateTime.IsMatch(inputStr);

            return isOK;
        }
        #endregion

        #region 檢查是否為「西元日期字串」
        /// <summary>
        /// 檢查是否為「西元日期字串」
        /// 日期格式：yyyy/MM/dd HH:mm:ss 或 yyyy/MM/dd
        /// 「/」可換成「.」或「-」
        /// </summary>
        /// <param name="inputStr">輸入的字串</param>
        /// <returns>是否為西元日期字串</returns>
        public static bool IsDateStr(String inputStr)
        {
            bool isOK = true;

            //String regStr;
            //regStr = @"^((19|20)?[0-9]{2}[- /.](0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01]))$|^((19|20)?[0-9]{2}[- /.](0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01]) ([0-1]{1}[0-9]{1}|2[0-3]{1}):([0-5]{1}[0-9]{1}):([0-5]{1}[0-9]{1}))$";
            //Regex regDateTime = new System.Text.RegularExpressions.Regex(regStr);
            //isOK = regDateTime.IsMatch(inputStr);

            try
            {
                DateTime.Parse(inputStr);
                isOK = true;
            }
            catch
            {
                isOK = false;
            }


            return isOK;
        }
        #endregion

        #region 檢查是否為「時間字串」
        /// <summary>
        /// 檢查是否為「時間字串」
        /// 時間格式：HH:mm:ss
        /// </summary>
        /// <param name="inputStr">輸入的字串</param>
        /// <returns>是否為「時間字串」</returns>
        public static bool IsTimeStr(String inputStr)
        {
            bool isOK = true;

            String regStr;
            regStr = @"^(([0-1]{1}[0-9]{1}|2[0-3]{1}):([0-5]{1}[0-9]{1}):([0-5]{1}[0-9]{1}))$";
            Regex regDateTime = new System.Text.RegularExpressions.Regex(regStr);
            isOK = regDateTime.IsMatch(inputStr);

            return isOK;
        }
        #endregion

        #region 「民國日期數字字串」轉「西元日期字串」 例：1041027 --> 2015/10/27

        /// <summary>
        /// 「民國日期數字字串」轉「西元日期字串」例：1041027 --> 2015/10/27
        /// </summary>
        /// <param name="twDateNum">民國日期數字字串</param>
        /// <returns>西元日期字串</returns>
        public static string TWDateNumToADDateStr(string twDateNum)
        {
            string resultStr = "";

            if (!string.IsNullOrEmpty(twDateNum)) 
            {
                twDateNum = twDateNum.Trim();
                if (twDateNum.Length != 7)
                {
                    resultStr = "";
                }
                else if (!IsTWDateNum(twDateNum))
                {
                    resultStr = "";
                }
                else
                {
                    resultStr = string.Format("{0}/{1}/{2}",
                                        Convert.ToInt32(twDateNum.Substring(0, 3)) + 1911,
                                        twDateNum.Substring(3, 2),
                                        twDateNum.Substring(5, 2));

                }
            }           

            return resultStr;
        }

        #endregion

        #region 「西元日期字串」轉「民國日期數字字串」 例：2015/10/27 --> 1041027
        /// <summary>
        /// 「西元日期字串」轉「民國日期數字字串」 例：2015/10/27 --> 1041027
        /// </summary>
        /// <param name="adDateStr">西元日期字串</param>
        /// <returns>民國日期數字字串</returns>
        public static string ADDateStrToTWDateNum(string adDateStr)
        {
            string resultStr = "";
            adDateStr = adDateStr.Trim();
            if (adDateStr.Length != 10)
            {
                resultStr = "";
            }
            else if (!IsDateStr(adDateStr))
            {
                resultStr = "";
            }
            else
            {
                resultStr = string.Format("{0}{1}{2}",
                                    Convert.ToInt32(adDateStr.Substring(0, 4)) - 1911,
                                    adDateStr.Substring(5, 2),
                                    adDateStr.Substring(8, 2));
                resultStr = resultStr.PadLeft(7, '0');
            }

            return resultStr;
        }
        #endregion

        #region 「時間數字字串」轉「時間字串」例：113044 -->  11:30:44
        /// <summary>
        /// 「時間數字字串」轉「時間字串」例：113044 -->  11:30:44、   1130   -->  11:30:00
        /// </summary>
        /// <param name="timeNum">時間數字字串</param>
        /// <returns>時間字串</returns>
        public static string TimeNumToTimeStr(string timeNum)
        {
            string resultStr = "";
            timeNum = timeNum.Trim();
            if (timeNum.Length == 4)
            {
                resultStr = timeNum.Substring(0, 2) + ":" + timeNum.Substring(2, 2) + ":00";
            }
            else if (timeNum.Length != 6)
            {
                resultStr = "";
            }
            else
            {
                resultStr = timeNum.Substring(0, 2) + ":" + timeNum.Substring(2, 2) + ":" + timeNum.Substring(4, 2);
            }

            return resultStr;
        }
        #endregion

        #region 「民國日期時間數字字串」轉「DateTime」 例：1050216 --> DateTime 或 1050216 132344 --> DateTime
        /// <summary>
        /// 「民國日期時間數字字串」轉「DateTime」
        /// 例：1050216 --> DateTime 或 1050216 132344 --> DateTime
        /// </summary>
        /// <param name="twdateStr">民國日期數字字串</param>
        /// <param name="timeStr">時間數字字串</param>
        /// <returns>DateTime</returns>
        public static DateTime? TWDateNumToDateTime(string twdateStr, string timeStr = "")
        {
            DateTime? result = null;
            string tempDate = "";
            string tempTime = "";
            string addateStr = "";
            string format = "";

            tempDate = TWDateNumToADDateStr(twdateStr); // 例：1041027 --> 2015/10/27
            tempTime = TimeNumToTimeStr(timeStr); // 例：113044 -->  11:30:44

            if (tempDate != "") //合法的「民國日期數字字串」
            {

                if (tempTime == "")
                {
                    addateStr = tempDate;
                    format = "yyyy/MM/dd";
                }
                else
                {
                    addateStr = tempDate + " " + tempTime;
                    format = "yyyy/MM/dd HH:mm:ss";
                    
                }

                result = ADDateStrToDateTime(addateStr, format);
            }
            else //不合法的「民國日期數字字串」
            {
                //result = new DateTime(1800, 01, 01);
                result = null;
            }

            return result;
        }
        #endregion

        #region 「民國日期時間數字字串」轉「DateTime」 例：1050216 --> DateTime 或 1050216132344 --> DateTime
        /// <summary>
        /// 「民國日期時間數字字串」轉「DateTime」
        /// 例：1050216 --> DateTime 或 1050216132344 --> DateTime
        /// </summary>
        /// <param name="twdateTimeStr">民國日期時間數字字串</param>
        /// <returns>DateTime</returns>
        public static DateTime? TWDateTimeNumToDateTime(string twdateTimeStr)
        {
            try
            {
                if (string.IsNullOrEmpty(twdateTimeStr))
                {
                    return null;
                }
                string dateTimeStr = Regex.Replace(twdateTimeStr, "[^0-9]", "");
                int length = dateTimeStr.Length;
                if (length < 7)
                {
                    return null;
                }
                int year = Convert.ToInt32(dateTimeStr.Substring(0, 3)) + 1911;
                int month = Convert.ToInt32(dateTimeStr.Substring(3, 2));
                int day = Convert.ToInt32(dateTimeStr.Substring(5, 2));
                if (length >= 7 && length < 11)
                {
                    return new DateTime(year, month, day);
                }
                int hour = Convert.ToInt32(dateTimeStr.Substring(7, 2));
                int minute = Convert.ToInt32(dateTimeStr.Substring(9, 2));
                if (length == 11)
                {
                    return new DateTime(year, month, day, hour, minute, 0);
                }
                if (length >= 13)
                {
                    int second = Convert.ToInt32(dateTimeStr.Substring(11, 2));
                    return new DateTime(year, month, day, hour, minute, second);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region 「DateTime」轉「民國日期時間數字字串」例：DateTime --> 105/02/16 或 DateTime --> 1050216 或 DateTime --> 1050216125225
        /// <summary>
        /// 「DateTime」轉「民國日期時間數字字串」
        /// 例：DateTime --> 105/02/16 或 DateTime --> 1050216 或 DateTime --> 1050216125225
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <param name="format">轉換格式(與DateTime.ToString方法相同)</param>
        /// <returns>民國日期時間數字字串</returns>
        public static string DateTimeToTWDateTimeNum(DateTime dateTime, string format)
        {
            //取得年份的Format
            string yearPattern = @"([yY]+)";
            Match result = Regex.Match(format, yearPattern);
            //取得非年份的Format
            string notYearPattern = @"([^yY]+)";
            Match otherResult = Regex.Match(format, notYearPattern);
            //取得民國年
            int year = new TaiwanCalendar().GetYear(dateTime);
            //把y或Y取代成0 (ToString用法，以0取代預留位置)
            string yearFormat = result.Value.Replace("y", "Y").Replace("Y", "0");
            //回傳格式
            return year.ToString(yearFormat) + dateTime.ToString(otherResult.Value);
        }
        #endregion
    }
}
