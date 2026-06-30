using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBase.Help
{
    /// <summary>
    /// StringBuilder 擴充方法
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// 輸入欄位與數值，並補上冒號=&gt; {labelName：value}
        /// 備註:如果輸入文字含有全形則補全形空白，反之則補半形空白
        /// </summary>
        /// <param name="sb">StringBuilder</param>
        /// <param name="labelName">欄位名稱</param>
        /// <param name="value">數值</param>
        /// <param name="labelWidth">欄位名稱寬度PadRight[計算方式:中文2寬,英文1寬,判斷文字全半形補對應空白]</param>
        /// <param name="AutoChangeLine">是否換行[預設:True]</param>
        public static void AppendFieldValue(this StringBuilder sb, string labelName, object value, int labelWidth = 8, bool AutoChangeLine = true)
        {
            if (sb == null) throw new ArgumentNullException($"傳入{nameof(AppendFieldValue)}之 StringBuilder 參數不可為Null !");
            if (labelWidth < 0) labelWidth = 0;

            var labelText = (labelName ?? string.Empty).PadRightByFullWidth(labelWidth);
            if (AutoChangeLine)
            {
                sb.AppendLine($"{labelText}：{value}");
            }
            else
            {
                sb.Append($"{labelText}：{value}");
            }
        }
        /// <summary>
        /// 從Dictionary&lt;string, string&gt; 透過propertyName當KEY取得VALUE，如找不到則使用欄位名稱(propertyName) =&gt; {Dic.Value||propertyName：modelValue}
        /// 備註:如果輸入文字含有全形則補全形空白，反之則補半形空白
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="sb">StringBuilder</param>
        /// <param name="dic">字典檔</param>
        /// <param name="propertyName">字典Key或預設欄位名稱</param>
        /// <param name="modelValue">數值</param>
        /// <param name="labelWidth">欄位名稱寬度PadRight</param>
        /// <param name="AutoChangeLine">是否換行[預設:True]</param>
        public static void AppendFieldFormDictionary<TModel>(this StringBuilder sb, Dictionary<string, string> dic, string propertyName, TModel modelValue, int labelWidth = 16, bool AutoChangeLine = true)
        {
            if (sb == null) throw new ArgumentNullException($"傳入{nameof(AppendFieldFormDictionary)}之 StringBuilder 參數不可為Null !");
            if (labelWidth < 0) labelWidth = 0;
            string label = string.Empty;
            if (!string.IsNullOrEmpty(propertyName))
            {
                label = propertyName;
                if (dic.TryGetValue(propertyName, out var dicValue))
                {
                    label = dicValue;
                }
            }
            //var label = string.IsNullOrEmpty(propertyName)
            //    ? string.Empty
            //    : (dic?.TryGetValue(propertyName, out var dicValue) == true ? dicValue : propertyName);
            sb.AppendFieldValue(label, modelValue, labelWidth, AutoChangeLine);
        }
    }
}
