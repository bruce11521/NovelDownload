namespace CoreBase.Help
{
    /// <summary>
    /// 布林型態擴充功能
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// 轉換為 Y/N
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringYN(this bool value)
        {
            return value ? "Y" : "N";
        }

        /// <summary>
        /// 轉換為 Y/N
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringYN(this bool? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToStringYN();
            }

            return string.Empty;
        }

        /// <summary>
        /// 轉換為0/1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString01(this bool value)
        {
            return value ? "0" : "1";
        }

        /// <summary>
        /// 轉換為0/1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString01(this bool? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString01();
            }

            return string.Empty;
        }

        /// <summary>
        /// 轉換為0/1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToNumber(this bool value)
        {
            return value ? 1 : 0;
        }

        /// <summary>
        /// 轉換為0/1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToNumber(this bool? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToNumber();
            }

            return null;
        }

        /// <summary>
        /// 轉換為 Y/N
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringChinese(this bool value)
        {
            return value ? "是" : "否";
        }

        /// <summary>
        /// 轉換為 Y/N
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringChinese(this bool? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToStringYN();
            }

            return string.Empty;
        }

    }
}
