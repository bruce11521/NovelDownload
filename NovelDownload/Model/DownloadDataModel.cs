using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelDownload.Model
{
    /// <summary>
    /// 下載資料
    /// </summary>
    public class DownloadDataModel
    {
        /// <summary>
        /// 下載資料
        /// </summary>
        public DownloadDataModel()
        {
            NovelTitle = string.Empty;
            NovelUrl = string.Empty;
            NovelData = new List<NovelChapterData>();
        }
        /// <summary>
        /// 小說名稱
        /// </summary>
        public string NovelTitle { get; set; }
        /// <summary>
        /// 小說網址
        /// </summary>
        public string NovelUrl { get; set; }

        /// <summary>
        /// 小說總章節
        /// </summary>
        public int NovelChapterNumber { get; set; } = 0;
        /// <summary>
        /// 小說內容
        /// </summary>
        public List<NovelChapterData> NovelData { get; set; }
        public class NovelChapterData
        {
            public NovelChapterData()
            {
                Title = string.Empty;
                Content = string.Empty;
                Chapter = 0;
                TitleNumber = string.Empty;
            }
            public string Title { get; set; }
            public string TitleNumber { get; set; }
            public string Content { get; set; }
            public Uri URI { get; set; }
            public int Chapter { get; set; }
        }

        
    }
}
