using System;

namespace CoreBase.DB
{
    /// <summary>
    /// ORACLE TABLE PROPERTY
    /// </summary>
    public class ORACLE_TABLE_SCHEMA
    {
        /// <summary>
        /// Table Schema Name
        /// </summary>
        public string OWNER { get; set; }
        /// <summary>
        /// 資料表名稱
        /// </summary>
        public string TABLE_NAME { get; set; }
        /// <summary>
        /// 欄位ID
        /// </summary>
        public decimal? COLUMN_ID { get; set; }
        /// <summary>
        /// 欄位名稱
        /// </summary>
        public string COLUMN_NAME { get; set; }
        /// <summary>
        /// 資料型態
        /// </summary>
        public string DATA_TYPE { get; set; }
        /// <summary>
        /// 資料長度(非實際寫入字元數,CLOB與BLOB除外)
        /// </summary>
        public decimal DATA_LENGTH { get; set; }

        /// <summary>
        /// 資料小數點前幾位數
        /// </summary>
        public decimal? DATA_PRECISION { get; set; }

        /// <summary>
        /// 資料小數點後幾位數
        /// </summary>
        public decimal? DATA_SCALE { get; set; }

        /// <summary>
        /// 資料預設值
        /// </summary>
        public string DATA_DEFAULT { get; set; }
        /// <summary>
        /// 資料是否可為空(Y/N)
        /// </summary>
        public string NULLABLE { get; set; }
        /// <summary>
        /// 字元長度(實際能寫入的字元數,CLOB與BLOB除外)
        /// </summary>
        public decimal CHAR_LENGTH { get; set; }
        /// <summary>
        /// 欄位註解
        /// </summary>
        public string COMMENTS { get; set; }
    }
    /// <summary>
    /// Oracle All Table Info(ORALCE DB INFO)
    /// </summary>
    public class ALL_TABLES
    {
        /// <summary>
        /// 擁有者
        /// </summary>
        public string OWNER { get; set; }
        /// <summary>
        /// TABLE NAME
        /// </summary>
        public string TABLE_NAME { get; set; }
        /// <summary>
        /// 狀態 "STATUS" IN ('INVALID', 'VALID')
        /// </summary>
        public string STATUS { get; set; }
        /// <summary>
        /// ROWNUM
        /// </summary>
        public decimal? NUM_ROWS { get; set; }

    }
    /// <summary>
    /// Oracle All Objects(ORALCE DB INFO)
    /// </summary>
    public class ALL_OBJECTS
    {
        /// <summary>
        /// 擁有者
        /// </summary>
        public string OWNER { get; set; }
        /// <summary>
        /// OBJECT NAME(TABLE NAME)
        /// </summary>
        public string OBJECT_NAME { get; set; }
        /// <summary>
        /// "OBJECT_TYPE" IN ('SEQUENCE', 'PROCEDURE', 'TABLE', 'INDEX', 'FUNCTION', 'VIEW', 'TYPE')
        /// </summary>
        public string OBJECT_TYPE { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CREATED { get; set; }
        /// <summary>
        /// 狀態 "STATUS" IN ('INVALID', 'VALID')
        /// </summary>
        public string STATUS { get; set; }
    }
    /// <summary>
    /// ALL_TABLES + ALL_OBJECT (ORACLE DB INFO)
    /// </summary>
    public class AllTableInfo : ALL_TABLES
    {
        /// <summary>
        /// OBJECT NAME(TABLE NAME)
        /// </summary>
        public string OBJECT_NAME { get; set; }
        /// <summary>
        /// "OBJECT_TYPE" IN ('SEQUENCE', 'PROCEDURE', 'TABLE', 'INDEX', 'FUNCTION', 'VIEW', 'TYPE')
        /// </summary>
        public string OBJECT_TYPE { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CREATED { get; set; }
    }

}
