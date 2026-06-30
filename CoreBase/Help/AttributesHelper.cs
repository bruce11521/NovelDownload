using System;

namespace CoreBase.Help
{
    public class AttributeHelper
    {
    }

    /// <summary>
    /// DB User 重新導向處
    /// </summary>
    public class DBUserAttribute : Attribute
    {
        public string Name
        {
            get; set;
        }

        public DBUserAttribute(string UserName)
        {
            Name = UserName;
        }

    }

    /// <summary>
    /// 不組進DB Insert Script中   EX:[NoWrite],[Write],[Key]
    /// </summary>
    public class NoWrite : Attribute
    {

    }
    /// <summary>
    /// 不組進DB Query Script中   EX:[NoSelect]
    /// </summary>
    public class NoSelect : Attribute
    {

    }

    /// <summary>
    /// 指定資料庫型態為 Nvarchar2
    /// </summary>
    public class NVarchar : Attribute
    {

    }

    /// <summary>
    /// 指定資料庫型態為 CLOB
    /// 適用於文字內容可能超過 4000 byte 之欄位。
    /// </summary>
    public class Clob : Attribute
    {

    }

    /// <summary>
    /// 指定欄位隱藏
    /// </summary>
    public class Hide : Attribute
    {

    }
}
