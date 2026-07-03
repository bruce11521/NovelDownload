using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using CoreBase.Help;
using CoreBase.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static CoreBase.Winform.ComponentExtensions;
using static CoreBase.Winform.CoreBaseFontsProxy;

namespace NovelDownload
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpClientHelper _HttpClientHelper = new HttpClientHelper();

        private HtmlParser htmlParser;


        public MainForm()
        {
            InitializeComponent();
            SetControlFont(this, GetFont(PresetFonts.YaHeiConsolasHybrid));
            
            radMsgboxFont();

            htmlParser = new HtmlParser();

            UI_Register();
            UI_Settings();


        }

        private void UI_Settings()
        {
            
        }

        private void UI_Register()
        {
            radButton_Download.Click += RadButton_Download_Click;
            radButton_CancelDownload.Click += RadButton_CancelDownload_Click;
            radButton_ClearLog.Click += RadButton_ClearLog_Click;
            radButton_GetNovel.Click += RadButton_GetNovel_Click;
        }

        private async void RadButton_GetNovel_Click(object sender, EventArgs e)
        {
            var getResult = await GetDownloadInfo();
        }

        private async Task<ServiceResult> GetDownloadInfo()
        {
            ServiceResult returnResult = new ServiceResult(false, string.Empty);
            if (string.IsNullOrWhiteSpace(radTextBoxControl_DownloadUrl.Text))
            {
                returnResult.Message = "下載網址不可為空";
                return returnResult;
            }
            var url = radTextBoxControl_DownloadUrl.Text;
            Uri baseUri = new Uri(url);
            var htmlContent = new ServiceResult<string>(false, string.Empty);
            IHtmlDocument document = null;
            Random r = new Random();
            var GetHTMLTask = Task.Run(async () =>
            {
                var delayminSecond =r.Next(100, 500);
                await Task.Delay(delayminSecond);
                htmlContent = await _HttpClientHelper.GetAsync<string>(url);
                document = htmlParser.ParseDocument(htmlContent.Data);

            });
            var GetHTMLDelayTask = Task.Delay(15 * 1000);
            var GetHTMLResult = await Task.WhenAny(GetHTMLTask, GetHTMLDelayTask);
            if (GetHTMLResult == GetHTMLDelayTask)
            {
                //逾時
            }

            var titleElement = document.QuerySelector(".pic_txt_list span");
            var contentListElement = document.QuerySelectorAll("ul.list li.c3 a");
            var title = titleElement?.TextContent;

            List<(string chapterNumber, string title, string url)> chapterList =
                new List<(string chapterNumber, string title, string url)>();
            var uriGetLeftPart = baseUri.GetLeftPart(UriPartial.Authority);
            foreach (var node in contentListElement)
            {
                string urlStr = node.GetAttribute("href");
                var urlS = uriGetLeftPart + urlStr;
                string titleStr = node.TextContent?.Trim();
                var titleTuple = SplitChapterAndTitle(titleStr);
                chapterList.Add((titleTuple.Chapter, titleTuple.Title, urlS));
            }

            if (chapterList.Any())
            {

            }

            RegexFilter(htmlContent.Data);

            return returnResult;
        }

        private void RegexFilter(string HtmlContent)
        {

        }

        private void RadButton_ClearLog_Click(object sender, EventArgs e)
        {
            
        }

        private void RadButton_CancelDownload_Click(object sender, EventArgs e)
        {
            
        }

        private void RadButton_Download_Click(object sender, EventArgs e)
        {
            
        }

        #region Utility

        /// <summary>
        /// 將章節名稱中的中文數字轉為阿拉伯數字 並保留其他字
        /// </summary>
        public static string ConvertChapterName(string input)
        {
            // 使用 Regex 抓出「第...章」中間的中文數字
            string pattern = @"(?<=第)[一二三四五六七八九十百千零兩]+(?=章)";

            return Regex.Replace(input, pattern, m =>
            {
                int number = ChineseToNumber(m.Value);
                return number.ToString();
            });
        }
        /// <summary>
        /// 只單獨提取出章節，其餘字串全部去掉
        /// </summary>
        public static string ExtractChapterOnly(string input)
        {
            // 1. 正規表示式：抓取「第」+ 中文數字 + 「章」的完整區段
            string pattern = @"第[一二三四五六七八九十百千零兩]+章";

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string fullChapterText = match.Value; // 例如: "第一百章"

                // 2. 取出中間的中文數字部分
                string chineseNum = fullChapterText.Replace("第", "").Replace("章", "");

                // 3. 轉成阿拉伯數字
                int number = ChineseToNumber(chineseNum);

                // 4. 重新組合回需要的格式
                return $"第{number}章";
            }

            return input; // 如果根本沒匹配到第幾章，就回傳原字串
        }

        /// <summary>
        /// 將原始章節名稱切分成（第X章, 標題文字）
        /// </summary>
        public static (string Chapter, string Title) SplitChapterAndTitle(string input)
        {
            // 1. 正規表示式：找出「第...章」
            string pattern = @"第[一二三四五六七八九十百千零兩]+章";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string fullChapterText = match.Value; // 例如: "第一百章"

                // 2. 轉換數字並組合成 "第100章"
                string chineseNum = fullChapterText.Replace("第", "").Replace("章", "");
                int number = ChineseToNumber(chineseNum);
                string firstString = $"第{number}章";

                // 3. 取得「第二個字串」：把原本的字串剪掉「第一百章」的部分，並去除前後空白
                //    例如 "第一百章 少年" 扣掉 "第一百章" -> " 少年" -> Trim() 後變成 "少年"
                string secondString = input.Replace(fullChapterText, "").Trim();

                return (firstString, secondString);
            }

            // 如果格式不符，就把原字串當作標題回傳
            return ("第0章", input.Trim());
        }

        /// <summary>
        /// 純中文數字轉整數的核心演算法
        /// </summary>
        public static int ChineseToNumber(string chineseNum)
        {
            // 定義數字對照
            var numMap = new Dictionary<char, int> {
            {'零', 0}, {'一', 1}, {'二', 2}, {'三', 3}, {'四', 4},
            {'五', 5}, {'六', 6}, {'七', 7}, {'八', 8}, {'九', 9}, {'兩', 2}
        };

            // 定義權重對照
            var unitMap = new Dictionary<char, int> {
            {'十', 10}, {'百', 100}, {'千', 1000}
        };

            int total = 0;    // 總和
            int section = 0;  // 當前小節累計值 (處理百、十)
            int number = 0;   // 剛讀到的數字

            for (int i = 0; i < chineseNum.Length; i++)
            {
                char c = chineseNum[i];

                if (numMap.ContainsKey(c))
                {
                    number = numMap[c];
                    // 如果是最後一個字，直接加到 section
                    if (i == chineseNum.Length - 1)
                    {
                        section += number;
                    }
                }
                else if (unitMap.ContainsKey(c))
                {
                    int unit = unitMap[c];

                    // 特殊處理：如果是開頭第一個字就是「十」（例如：十三章），前面默認是 1
                    if (i == 0 && c == '十')
                    {
                        number = 1;
                    }

                    if (number == 0 && c == '十')
                    {
                        // 處理「零十」或「百十」中間省略一的情況（如：一百一十 的後半段）
                        number = 1;
                    }

                    section += number * unit;
                    number = 0; // 乘完單位後清空數字
                }
            }

            total += section;
            return total;
        }

        #endregion
    }
}
