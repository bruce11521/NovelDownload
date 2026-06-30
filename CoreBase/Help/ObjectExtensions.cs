using System;

namespace CoreBase.Help
{
    /// <summary>
    /// Object Extensions
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Object物件，內部型別感知與Null-Safe 比較方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool ObjectValueEquals(this object a, object b)
        {
            // 1️⃣ 兩個都是 null
            if (ReferenceEquals(a, b))
                return true;

            // 2️⃣ 其中一個是 null
            if (a is null || b is null)
                return false;

            // 3️⃣ 同型別 → 用 Equals
            if (a.GetType() == b.GetType())
                return a.Equals(b);

            // 4️⃣ 不同型別，但可能是數值（int / decimal / double…）
            if (IsNumericType(a) && IsNumericType(b))
            {
                try
                {
                    // 轉成 decimal 再比，避免 1 vs 1.0 問題
                    return Convert.ToDecimal(a) == Convert.ToDecimal(b);
                }
                catch
                {
                    return false;
                }
            }
            // 5️⃣ 其他情況 → 當不相等
            return false;
        }
        /// <summary>
        /// 物件是否為數字型別?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumericType(object value)
        {
            return value is byte || value is sbyte
                                 || value is short || value is ushort
                                 || value is int || value is uint
                                 || value is long || value is ulong
                                 || value is float || value is double
                                 || value is decimal;
        }

        /// <summary>
        /// 物件轉Boolean
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBoolean(this object value)
        {
            if (value == null || value == DBNull.Value)
                return false;

            // 如果已經是 bool，直接轉型
            if (value is bool b)
                return b;

            // 處理字串轉型 (支援 "true", "false", "1", "0")
            string str = value.ToString().Trim().ToLower();
            if (str == "true" || str == "1" || str == "yes") return true;

            return false;
        }
    }
}
