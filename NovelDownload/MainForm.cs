using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using CoreBase.Help;
using CoreBase.Utilities;
using Library.WinControlsUI.Utility;
using NovelDownload.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static CoreBase.Winform.ComponentExtensions;
using static CoreBase.Winform.CoreBaseFontsProxy;
using static NovelDownload.Model.DownloadDataModel;
using static System.Net.Mime.MediaTypeNames;

namespace NovelDownload
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// 
        /// </summary>
        public static HttpClientHelper _HttpClientHelper;

        private HtmlParser htmlParser;
        public DesktopAlertUtil _desktopAlertUtil;
        /// <summary>
        /// 右下角提示視窗，顯示重置按鈕
        /// </summary>
        private RadDesktopAlert _LockFlagDesktopAlert = new RadDesktopAlert();
        /// <summary>
        /// 右下角提示視窗，顯示重置按鈕 設定參數
        /// </summary>
        private DesktopAlertUtil.DesktopAlertUtilSettingsModel _lockFlagDesktopAlertSettingsModel;

        #region Flag

        private bool _DownloadFlag = false;

        #endregion

        private static readonly Random _random = new Random();
        private static readonly object _lockRandom = new object();

        public NovelChapterData[] executeResultList;
        public MainForm()
        {
            InitializeComponent();
            SetControlFont(this, GetFont(PresetFonts.YaHeiConsolasHybrid));
            
            radMsgboxFont();
            _HttpClientHelper = new HttpClientHelper();
            _HttpClientHelper.HttpClientInstance.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
            htmlParser = new HtmlParser();
            _desktopAlertUtil = new DesktopAlertUtil(PresetFonts.YaHeiConsolasHybrid);
            _lockFlagDesktopAlertSettingsModel = new DesktopAlertUtil.DesktopAlertUtilSettingsModel(_LockFlagDesktopAlert);

            UI_Register();
            UI_Settings();


        }

        private void UI_Settings()
        {
            foreach (var item in GetAllControlEnumerate(this))
            {
                if (item is RadTextBoxControl rtbc)
                {
                    rtbc.WordWrap = true;
                    rtbc.Multiline = true;
                    rtbc.AcceptsReturn = true;
                    rtbc.AcceptsTab = true;
                }
            }
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


            radTextBoxControl_NovelName.Clear();
            radTextBoxControl_NovelTotalChapter.Clear();
            if (getResult.IsOk)
            {
                radTextBoxControl_NovelName.Text = getResult.Data.NovelTitle;
                radTextBoxControl_NovelTotalChapter.Text = getResult.Data.NovelChapterNumber.ToString();
            }
            else
            {
                _lockFlagDesktopAlertSettingsModel.Content = getResult.Message;
                _lockFlagDesktopAlertSettingsModel.Title = "抓取小說名稱";
                _lockFlagDesktopAlertSettingsModel.alertType = DesktopAlertUtil.Alert.Warning;
                _desktopAlertUtil.ShowAlert_CustomDesktop(_lockFlagDesktopAlertSettingsModel);
            }
        }

        private async Task<ServiceResult<DownloadDataModel>> GetDownloadInfo()
        {
            ServiceResult<DownloadDataModel> returnResult = new ServiceResult<DownloadDataModel>(false, string.Empty, new());
            if (string.IsNullOrWhiteSpace(radTextBoxControl_DownloadUrl.Text))
            {
                returnResult.Message = "下載網址不可為空";
                return returnResult;
            }
            var url = radTextBoxControl_DownloadUrl.Text;
            returnResult.Data.NovelUrl = url;

            var htmlContent = new ServiceResult<string>(false, string.Empty);
            IHtmlDocument document = null;
            Random r = new Random();
            var GetHTMLTask = Task.Run(async () =>
            {
                htmlContent = await _HttpClientHelper.GetAsync<string>(url);
                document = htmlParser.ParseDocument(htmlContent.Data);

            });
            var GetHTMLDelayTask = Task.Delay(15 * 1000);
            var GetHTMLResult = await Task.WhenAny(GetHTMLTask, GetHTMLDelayTask);
            if (GetHTMLResult == GetHTMLDelayTask)
            {
                //逾時
                returnResult.Message = $"網址:【{returnResult.Data.NovelUrl}】讀取資料逾時!";
                returnResult.IsOk = false;
                return returnResult;
            }

            var titleElement = document.QuerySelector(".pic_txt_list span");
            returnResult.Data.NovelTitle = titleElement?.TextContent;

            var contentListElement = document.QuerySelectorAll("ul.list li.c3 a");
            returnResult.Data.NovelChapterNumber = contentListElement.Length;
            var uri = new Uri(returnResult.Data.NovelUrl);
            var uriGetLeftPart = uri.GetLeftPart(UriPartial.Authority);
            var chapterCount = 1;
            foreach (var node in contentListElement)
            {
                string urlStr = node.GetAttribute("href");
                var urlS = uriGetLeftPart + urlStr;
                string titleStr = node.TextContent?.Trim();
                var titleTuple = SplitChapterAndTitle(titleStr);
                var item = new DownloadDataModel.NovelChapterData();
                item.Chapter = chapterCount++;
                item.URI = new Uri(urlS);
                item.Title = titleTuple.Title;
                item.TitleNumber = titleTuple.Chapter;
                returnResult.Data.NovelData.Add(item);
            }

            if (radCheckBox_Auto_ExportToPreview.CheckState == CheckState.Checked)
            {
                radTextBoxControl_PreviewList.Clear();
                var padLeftLength = returnResult.Data.NovelChapterNumber.ToString().Length;
                if (padLeftLength == 0)
                {
                    padLeftLength = 1;
                }
                radTextBoxControl_PreviewList.AppendText(string.Join(Environment.NewLine,
                    returnResult.Data.NovelData.Select(x =>
                        $"【{x.Chapter.ToString().PadLeft(padLeftLength)}】【{x.TitleNumber}】{x.Title}")));
            }
            //List<(string chapterNumber, string title, string url)> chapterList =
            //    new List<(string chapterNumber, string title, string url)>();
            //var uriGetLeftPart = returnResult.Data.NovelUrl.GetLeftPart(UriPartial.Authority);
            //foreach (var node in contentListElement)
            //{
            //    string urlStr = node.GetAttribute("href");
            //    var urlS = uriGetLeftPart + urlStr;
            //    string titleStr = node.TextContent?.Trim();
            //    var titleTuple = SplitChapterAndTitle(titleStr);
            //    chapterList.Add((titleTuple.Chapter, titleTuple.Title, urlS));
            //}

            //if (chapterList.Any())
            //{

            //}

            //RegexFilter(htmlContent.Data);
            returnResult.IsOk = true;
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

        private async void RadButton_Download_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                var checkExecResult = CheckExecuteStatus(sender);
                if (checkExecResult.IsOk == false || checkExecResult.Data == false)
                {
                    return;
                }
                _DownloadFlag = true;
                var getResult = await GetDownloadInfo();
                radTextBoxControl_NovelName.Clear();
                radTextBoxControl_NovelTotalChapter.Clear();
                if (getResult.IsOk)
                {
                    radTextBoxControl_NovelName.Text = getResult.Data.NovelTitle;
                    radTextBoxControl_NovelTotalChapter.Text = getResult.Data.NovelChapterNumber.ToString();
                }
                else
                {
                    ShowWarn(this, getResult.Message, "下載");
                    return;
                }

                // 2. 設定最大並行數（建議根據目標網站的承受度調整，通常 10~30 是安全範圍）
                int maxConcurrency = 12;
                using var semaphore = new SemaphoreSlim(maxConcurrency);
                var tasks = new List<Task<NovelChapterData>>();
                var downloadContentDic = new Dictionary<string, string>();

                foreach (var item in getResult.Data.NovelData)
                {
                    tasks.Add(DownloadWithSemaphoreAsync(item, semaphore, 10));
                }

                executeResultList = await Task.WhenAll(tasks);
                if (executeResultList.Any())
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in executeResultList)
                    {
                        sb.AppendLine($"第{item.Chapter}章 {item.Title}");
                        sb.AppendLine($"{item.Content}"+ Environment.NewLine);
                    }

                    if (Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OutputText")) == false)
                    {
                        Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OutputText"));
                    }
                    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OutputText",
                        $"{radTextBoxControl_NovelName.Text}.txt");
                    using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
                    {
                        await sw.WriteLineAsync(sb.ToString());
                    }
                }

            }
            catch(Exception ex)
            {
                ShowError(this, ex.GetInnerException().ErrorMessage, "下載小說");
            }
            finally
            {
                Cursor = Cursors.Default;
                _DownloadFlag = false;
            }

            
        }

        #region Utility

        public ServiceResult<bool> CheckExecuteStatus(object control, bool ShowErrorMessage = true)
        {
            ServiceResult<bool> returnResult = new ServiceResult<bool>(false, string.Empty, true);
            string ControlTitle = "未知控制項";
            try
            {
                if (control == null)
                {
                    returnResult.Message = "欲檢核之控制項不可為Null";
                    returnResult.Data = false;
                    return returnResult;
                }

                if (control is RadButton rbtn)
                {
                    ControlTitle = rbtn.Text;
                    #region Lock Flag 阻擋檢核（資料驅動，取代原本重複的 7 組 switch）
                    foreach (var guard in BuildExecuteLockGuards(ControlTitle))
                    {
                        if (guard.IsActive() == false)
                        {
                            continue;
                        }
                        if (guard.BlockMap.TryGetValue(rbtn.Name, out var blockMessage))
                        {
                            returnResult.Message = blockMessage;
                            returnResult.Data = false;
                        }
                    }
                    #endregion

                }

                
                radMsgboxFont();
            }
            catch (Exception ex)
            {
                returnResult.Exception = ex;
                returnResult.IsOk = false;
                returnResult.Message += $"{Environment.NewLine}錯誤擲出:" + ex.GetInnerException().ErrorMessage;
            }
            finally
            {
                if (returnResult.Exception == null)
                {
                    returnResult.IsOk = true;
                }
                if (ShowErrorMessage)
                {
                    if (!string.IsNullOrWhiteSpace(returnResult.Message))
                    {
                        _lockFlagDesktopAlertSettingsModel.Content = returnResult.Message;
                        _lockFlagDesktopAlertSettingsModel.Title = ControlTitle;
                        _lockFlagDesktopAlertSettingsModel.CustomSize = new Size();
                        _lockFlagDesktopAlertSettingsModel.CustomBackColor = true;
                        _lockFlagDesktopAlertSettingsModel.alertType = DesktopAlertUtil.Alert.Warning;
                        _desktopAlertUtil.ShowAlert_CustomDesktop(_lockFlagDesktopAlertSettingsModel);
                    }
                }
            }
            return returnResult;
        }
        /// <summary>
        /// 建立 CheckExecuteStatus 各 Lock Flag 的阻擋規則表（取代原本重複的 switch 區塊）
        /// </summary>
        private List<ExecuteLockGuard> BuildExecuteLockGuards(string controlTitle)
        {
            string download = nameof(radButton_Download);
            //string idClear = nameof(radButton_Identity_ClearValue);
            //string idReload = nameof(radButton_Identity_Reload);
            //string refSearch = nameof(radButton_SearchValidReferralRecord);
            //string refCreate = nameof(radButton_CreateReferralRecord);
            //string refDelete = nameof(radButton_DeleteTodayReferralRecord);
            //string csUpdate = nameof(radButton_csUpdateHCContents);
            //string heavyCreate = nameof(radButton_PaperHeavysickCreate);
            //string heavyDelete = nameof(radButton_PaperHeavysickTodayDelete);
            //string save = nameof(radButton_Save);

            return new List<ExecuteLockGuard>
            {
                new ExecuteLockGuard
                {
                    IsActive = () => _DownloadFlag,
                    BlockMap = new Dictionary<string, string>
                    {
                        { download, "小說正在下載中..." },
                    },
                },
                //new ExecuteLockGuard
                //{
                //    IsActive = () => _EnabledReferralRecordFunc == false,
                //    BlockMap = new Dictionary<string, string>
                //    {
                //        { refSearch, DisabledReferralRecordFuncDisplayMessage },
                //        { refCreate, DisabledReferralRecordFuncDisplayMessage },
                //        { refDelete, DisabledReferralRecordFuncDisplayMessage },
                //    },
                //},
                //new ExecuteLockGuard
                //{
                //    IsActive = () => _Referral_SearchValidReferralRecordFlag,
                //    BlockMap = new Dictionary<string, string>
                //    {
                //        { refSearch, "正在查詢有效轉診紀錄中..." },
                //        { save, $"正在查詢有效轉診紀錄中...{Environment.NewLine}請等待查詢完成後再進行結案寫卡或儲存檔案" },
                //    },
                //},
                //new ExecuteLockGuard
                //{
                //    IsActive = () => _Referral_DeleteTodayReferralRecordFlag,
                //    BlockMap = new Dictionary<string, string>
                //    {
                //        { idClear, $"正在註銷轉診紀錄中...{Environment.NewLine}請等待註銷完成後再清除身分別" },
                //        { idReload, $"正在註銷轉診紀錄中...{Environment.NewLine}請等待註銷完成後再重新讀取身分別" },
                //        { refSearch, "正在註銷轉診紀錄中..." },
                //        { refCreate, "正在註銷轉診紀錄中..." },
                //        { refDelete, "正在註銷轉診紀錄中..." },
                //        { heavyCreate, $"正在註銷轉診紀錄中...{Environment.NewLine}請等待註銷完成後再建立紙本重大傷病" },
                //        { heavyDelete, $"正在註銷轉診紀錄中...{Environment.NewLine}請等待註銷完成後再註銷本日紙本重大傷病" },
                //        { save, $"正在註銷轉診紀錄中...{Environment.NewLine}請等待註銷完成後再進行結案寫卡或儲存檔案" },
                //    },
                //},
                //new ExecuteLockGuard
                //{
                //    IsActive = () => _CsUpdateHCContentsFlag,
                //    BlockMap = new Dictionary<string, string>
                //    {
                //        { idClear, $"正在更新健保卡片內容中...{Environment.NewLine}請等待健保署更新卡片完成後再進行身分別異動" },
                //        { idReload, $"正在更新健保卡片內容中...{Environment.NewLine}請等待健保署更新卡片完成後再進行身分別異動" },
                //        { csUpdate, "正在更新健保卡片內容中..." },
                //        { save, $"正在更新健保卡片內容中...{Environment.NewLine}請等待健保署更新卡片完成後再進行結案寫卡或儲存檔案" },
                //    },
                //},
                //new ExecuteLockGuard
                //{
                //    IsActive = () => _PaperHeavysick_PaperHeavysickTodayDeleteFlag,
                //    BlockMap = new Dictionary<string, string>
                //    {
                //        { heavyCreate, $"正在執行本日門診紙本重大ICD刪除中...{Environment.NewLine}請等待刪除後再建立新紙本重大傷病" },
                //        { heavyDelete, $"正在執行本日門診紙本重大ICD刪除中...{Environment.NewLine}" },
                //        { save, $"正在執行本日門診紙本重大ICD刪除中...{Environment.NewLine}請等待刪除後再進行結案寫卡或儲存檔案" },
                //    },
                //},
                //new ExecuteLockGuard
                //{
                //    IsActive = () => _SaveButtonFlag,
                //    BlockMap = new Dictionary<string, string>
                //    {
                //        { save, $"正在進行{controlTitle}與相關身分別計算檢核中...請勿更動任意資料以免發生檢核錯誤{Environment.NewLine}" },
                //    },
                //},
            };
        }
        private sealed class ExecuteLockGuard
        {
            /// <summary>
            /// 是否使用中
            /// </summary>
            public Func<bool> IsActive;
            /// <summary>
            /// 檢核與提示Dictionary
            /// </summary>
            public Dictionary<string, string> BlockMap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="semaphore"></param>
        /// <param name="cancelTokenSecond"></param>
        /// <returns></returns>
        private static async Task<NovelChapterData> DownloadWithSemaphoreAsync(NovelChapterData novelData, SemaphoreSlim semaphore, int cancelTokenSecond = 10)
        {
            // 等待許可證，如果目前執行的任務滿了，就會在這裡排隊（非同步等待，不卡執行緒）
            await semaphore.WaitAsync();
            var url = novelData?.URI?.ToString();
            try
            {
                int randomDelayMs;
                lock (_lockRandom)
                {
                    randomDelayMs = _random.Next(300, 700);
                }

                await Task.Delay(randomDelayMs);

                if (cancelTokenSecond < 1 )
                {
                    cancelTokenSecond = 15;
                }
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(cancelTokenSecond));
                // 實際執行的下載邏輯
                var htmlResult = await _HttpClientHelper.GetAsync<string>(url, cts.Token);
                if (htmlResult.IsOk)
                {
                    var downloadHtmlParser = new HtmlParser();
                    var documentAsync = await downloadHtmlParser.ParseDocumentAsync(htmlResult.Data);

                    if (documentAsync != null)
                    {
                        var contentNode = documentAsync.QuerySelectorAll("#content p");
                        if (contentNode != null)
                        {
                            var totalText = string.Empty;
                            foreach (var node in contentNode)
                            {
                                string text = node?.TextContent?.Trim();
                                totalText += text;
                            }
                            novelData.Content = totalText;
                        }
                    }
                }
                
                // 模擬儲存檔案
                // await File.WriteAllTextAsync($"page_{Guid.NewGuid()}.html", html);

                Console.WriteLine($"[成功] 已下載: {url}");
            }
            catch (HttpRequestException ex)
            {
                // 處理 HTTP 錯誤（如 404, 500 等）
                Console.WriteLine($"[失敗] HTTP 錯誤 {url}: {ex.Message}");
            }
            catch (TaskCanceledException)
            {
                // 處理 Timeout 逾時
                Console.WriteLine($"[失敗] 逾時 {url}");
            }
            catch (Exception ex)
            {
                // 處理其他未知錯誤（如網路斷線）
                Console.WriteLine($"[失敗] 未知錯誤 {url}: {ex.Message}");
            }
            finally
            {
                // 務必在 finally 釋放許可證，讓下一筆進來
                semaphore.Release();
            }

            return novelData;
        }

        #region 國字數字轉數字

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


        #region ShowMessageBox

        /// <summary>
        /// 警示訊息 (Exclamation + OK) — 等同 RadMessageBox.Show(msg, title, OK, Exclamation)
        /// </summary>
        private static DialogResult ShowWarn(IWin32Window parent, string message, string title)
        {
            radMsgboxFont();
            return RadMessageBox.Show(parent, message, title, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
        }

        /// <summary>
        /// 一般訊息 (Info + OK)
        /// </summary>
        private static DialogResult ShowInfo(IWin32Window parent, string message, string title)
        {
            radMsgboxFont();
            return RadMessageBox.Show(parent, message, title, MessageBoxButtons.OK, RadMessageIcon.Info);
        }

        /// <summary>
        /// 錯誤訊息 (Error + OK)
        /// </summary>
        private static DialogResult ShowError(IWin32Window parent, string message, string title)
        {
            radMsgboxFont();
            return RadMessageBox.Show(parent, message, title, MessageBoxButtons.OK, RadMessageIcon.Error);
        }

        /// <summary>
        /// 是/否 確認視窗 (預設 Question 圖示)
        /// </summary>
        private static DialogResult ConfirmYesNo(IWin32Window parent, string message, string title, RadMessageIcon icon = RadMessageIcon.Question)
        {
            radMsgboxFont();
            return RadMessageBox.Show(parent, message, title, MessageBoxButtons.YesNo, icon);
        }

        /// <summary>
        /// 確定/取消 視窗 (預設 Question 圖示)
        /// </summary>
        private static DialogResult ConfirmOKCancel(IWin32Window parent, string message, string title, RadMessageIcon icon = RadMessageIcon.Question)
        {
            radMsgboxFont();
            return RadMessageBox.Show(parent, message, title, MessageBoxButtons.OKCancel, icon);
        }

        #endregion
        #endregion


    }
}
