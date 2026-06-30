using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CoreBase.Help
{
    public class DataTableExtensionsSybase
    {
        /// <summary>
        /// DataTable To Dictionary (Only For Sybase)
        /// 將每一個資料，都同時取欄位名稱及內容
        /// </summary>
        /// <param name="datatable"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> getTableListObject(DataTable datatable)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = null;
            int rowcnt = datatable.Rows.Count;
            int colucnt = datatable.Columns.Count;
            for (int i = 0; i < rowcnt; i++)
            {
                dic = new Dictionary<string, object>();
                //儲存舊資料表的一列欄位名稱，欄位值，至Dictionary<string, string> 物件
                for (int j = 0; j < colucnt; j++)
                {
                    String columnName = datatable.Columns[j].ToString();
                    Byte[] mybyte = System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(datatable.Rows[i][columnName].ToString().ToCharArray());
                    String value = Encoding.GetEncoding("big5").GetString(mybyte, 0, mybyte.Length);
                    dic.Add(columnName, value);
                }
                list.Add(dic);
            }

            return list;
        }
    }
}
