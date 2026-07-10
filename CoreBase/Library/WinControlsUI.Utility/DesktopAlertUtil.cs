using CoreBase.Help;
using CoreBase.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using CoreBase.Winform;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static CoreBase.Winform.ComponentExtensions;

namespace Library.WinControlsUI.Utility
{
    /// <summary>
    /// UI 訊息提示
    /// </summary>
    public class DesktopAlertUtil
    {
        /// <summary>
        /// Declare
        /// </summary>
        /// <param name="customFont">可自定義 FontFamily[預設使用:MicrosoftJhengHeiUI]</param>
        public DesktopAlertUtil(CoreBaseFontsProxy.PresetFonts customFont = CoreBaseFontsProxy.PresetFonts.MicrosoftJhengHeiUI)
        {
            PresetFonts = customFont;
            ContentFont = CoreBaseFontsProxy.GetFont(PresetFonts);
            CaptionFont = CoreBaseFontsProxy.GetFont(PresetFonts, 16f, true);
        }                          
        /// <summary>
        /// 預設內文字體 12f
        /// </summary>
        private Font ContentFont;
        /// <summary>
        /// 預設標題字體 14f, Bold
        /// </summary>
        private Font CaptionFont;
        /// <summary>
        /// 自訂底色
        /// </summary>
        public Color BackGroupColor = Color.Transparent;

        /// <summary>
        /// 自訂位置
        /// </summary>
        public AlertScreenPosition ASP { get; set; }

        /// <summary>
        /// 錯誤的底色
        /// </summary>
        private Color ErrorColor = Color.PaleVioletRed;
        /// <summary>
        /// 警告的底色
        /// </summary>
        private Color WarningColor = Color.LightYellow;
        /// <summary>
        /// 成功的底色
        /// </summary>
        private Color SuccessColor = Color.LightBlue;

        /// <summary>
        /// Alert Type
        /// CodeGroup = SexCode
        /// </summary>
        public enum Alert
        {
            /// <summary>
            /// 錯誤
            /// 明顯出現，且需人工關閉
            /// 底色紅
            /// </summary>
            [Display(Name = "錯誤")]
            Error = 99, // 後面數字為自動關閉時的秒數，可是警告不會自動關閉

            /// <summary>
            /// 成功
            /// 小小出現3秒，程式自動關閉
            /// 底色藍
            /// </summary>
            [Display(Name = "成功")]
            Success = 3, // 後面數字為自動關閉時的秒數

            /// <summary>
            /// 警告
            /// 出現時間稍久6秒，程式自動關閉
            /// 底色黃
            /// </summary>
            [Display(Name = "警告")]
            Warning = 6, // 後面數字為自動關閉時的秒數
        }
        ///// <summary>
        ///// 自定義FontFamily
        ///// </summary>
        //public Font CustomFont { get; private set; }
        /// <summary>
        /// 預設字體(Microsoft JhengHei UI)
        /// </summary>
        public CoreBaseFontsProxy.PresetFonts PresetFonts { get; private set; } = CoreBaseFontsProxy.PresetFonts.MicrosoftJhengHeiUI;

        /// <summary>
        /// 顯示錯誤訊息
        /// </summary>
        /// <param name="Content">內容</param>
        public void ShowError(string Content)
        {
            ShowAlert(Alert.Error, Content, string.Empty);
        }

        /// <summary>
        /// 顯示錯誤訊息
        /// </summary>
        /// <param name="Content">內容</param>
        /// <param name="Title">標題</param>
        public void ShowError(string Content, string Title)
        {
            ShowAlert(Alert.Error, Content, Title);
        }

        /// <summary>
        /// 顯示成功訊息
        /// </summary>
        /// <param name="Content">內容</param>
        public void ShowSuccess(string Content)
        {
            ShowAlert(Alert.Success, Content, string.Empty);
        }

        /// <summary>
        /// 顯示成功訊息
        /// </summary>
        /// <param name="Content">內容</param>
        /// <param name="Title">標題</param>
        public void ShowSuccess(string Content, string Title)
        {
            ShowAlert(Alert.Success, Content, Title);
        }

        /// <summary>
        /// 顯示警告訊息
        /// </summary>
        /// <param name="Content">內容</param>
        public void ShowWarning(string Content)
        {
            ShowAlert(Alert.Warning, Content, string.Empty);
        }

        /// <summary>
        /// 顯示警告訊息
        /// </summary>
        /// <param name="Content">內容</param>
        /// <param name="Title">標題</param>
        public void ShowWarning(string Content, string Title)
        {
            ShowAlert(Alert.Warning, Content, Title);
        }

        /// <summary>
        /// 顯示Alert
        /// </summary>
        /// <param name="alertType">Alert類別</param>
        /// <param name="Content">內容</param>
        public void ShowAlert(Alert alertType, string Content)
        {
            ShowAlert(alertType, Content, string.Empty);
        }

        /// <summary>
        /// 顯示Alert
        /// </summary>
        /// <param name="alertType">Alert類別</param>
        /// <param name="Content">內容</param>
        /// <param name="Title">標題</param>
        public void ShowAlert(Alert alertType, string Content, string Title)
        {
            // TODO 下次是不是要補一下圖示
            RadDesktopAlert radDesktopAlert = new RadDesktopAlert();
            
            DesktopAlertPopup alertpopup = radDesktopAlert.Popup;

            #region 通用排版樣式
            // 提示框上的三點是否要繪制
            radDesktopAlert.Popup.AlertElement.CaptionElement.CaptionGrip.ShouldPaint = false;
            // 是否自動關閉
            radDesktopAlert.AutoClose = alertType != Alert.Error; // Error 不自動關閉
            // 自動關閉的秒數
            radDesktopAlert.AutoCloseDelay = alertType.ToNumberValue();
            radDesktopAlert.Popup.AlertElement.BorderDashStyle = DashStyle.Dot;
            radDesktopAlert.Popup.AlertElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;//.OuterInnerBorders;
            // 底色是否要漸層
            radDesktopAlert.Popup.AlertElement.GradientStyle = GradientStyles.Solid;
            // 標題文字
            radDesktopAlert.CaptionText = Title;
            // 內文
            radDesktopAlert.ContentText = Content;
            // 風格樣式
            //radDesktopAlert.ThemeName = "FluentDatk";

            // 自動尺吋
            radDesktopAlert.AutoSize = true;
            // 關閉鈕
            radDesktopAlert.ShowCloseButton = alertType != Alert.Success;  // Success會一閃而過，就不需要關閉鈕了
            // 選項鈕
            radDesktopAlert.ShowOptionsButton = false;
            // 釘選鈕
            radDesktopAlert.ShowPinButton = false;
            // 內文字型
            radDesktopAlert.Popup.AlertElement.ContentElement.Font = ContentFont;
            // 標題字型
            radDesktopAlert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = CaptionFont;

            // 跳出提示的位置
            //radDesktopAlert.ScreenPosition = AlertScreenPosition.Manual;
            // 跳出提示下方的一排按鈕排版空間
            //radDesktopAlert.Popup.AlertElement.ButtonsPanel 
            // 內文相關設定
            //radDesktopAlert.Popup.AlertElement.ContentElement
            // 標題相關設定
            //radDesktopAlert.Popup.AlertElement.CaptionElement
            #endregion 通用排版樣式

            switch (alertType)
            {
                case Alert.Error:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.BottomRight;
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = ErrorColor;
                    //radDesktopAlert.Popup.AlertElement.ContentImage = RadMessageIcon.Info;
                    // Properties.Resources.envelope
                    break;

                case Alert.Success:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.Manual;
                    if (alertpopup != null)
                    {
                        // 取得呼叫的應用程式位置
                        var apps = Application.OpenForms;
                        var app = apps.Count > 0 ? apps[apps.Count - 1] : null;

                        // app.InvokeRequired 為True時，代表跨執行緒執行
                        // 應用程式所在作用的螢幕
                        var ActiveScreen = (app == null || app.InvokeRequired) ? Screen.PrimaryScreen : Screen.FromControl(app);
                        var screenWidth = ActiveScreen.Bounds.Width;
                        var screenHeight = ActiveScreen.Bounds.Height;
                        // 多螢幕下，將執行設定為視窗的那個螢幕
                        DesktopAlertManager.Instance.SetActiveScreen(ActiveScreen);

                        // TODO 想找找是不是能放畫面正中間，多個訊息好像會重疊
                        // 目前先暫時這樣子，不會太明顯的歪…
                        // 公式：多螢幕的偏移 + 所在螢幕的一半 - 訊息框的大概尺吋(暫時抓不到會多少，先以大概的數字來取)
                        alertpopup.Location = new Point(ActiveScreen.Bounds.X + ((int)(screenWidth / 2)) - 160, ActiveScreen.Bounds.Y + ((int)(screenHeight / 2)) - 80);
                    }
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = SuccessColor;
                    break;

                case Alert.Warning:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.BottomRight;
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = WarningColor;
                    break;
            }

            #region 使用者自訂項目
            // 當有指定底色時，使用指定的底色
            if (BackGroupColor != Color.Transparent)
            {
                radDesktopAlert.Popup.AlertElement.BackColor = BackGroupColor;
            }

            // 當有指定出現位置時，使用指定位置
            if (ASP != AlertScreenPosition.Manual)
            {
                radDesktopAlert.ScreenPosition = ASP;
            }
            #endregion 使用者自訂項目

            radDesktopAlert.Show();
        }

        //public void ShowAlert_Custom(Alert alertType, string Content, string Title, int AlertSecond = -1, object CustomScreenPosition = null, Point ScreenPositionLocation = new Point(), bool ShowMessageOnScreenCenter = false)
        //{
        //    ShowAlert_Custom_Static(alertType, Content, Title, AlertSecond, CustomScreenPosition, ScreenPositionLocation, ShowMessageOnScreenCenter);
        //}

        /// <summary>
        /// 客製化顯示Alert
        /// </summary>
        /// <param name="alertType">Alert類別</param>
        /// <param name="Content">內容</param>
        /// <param name="Title">標題</param>
        /// <param name="AlertSecond">顯示秒數(-1為使用預設)</param>
        /// <param name="CustomScreenPosition">傳入AlertScreenPosition Type則指定位置，否則使用預設</param>
        /// <param name="ScreenPositionLocation">如果CustomScreenPosition = AlertScreenPosition.Manual，則使用傳入座標</param>
        /// <param name="ShowMessageOnScreenCenter">是否顯示在螢幕中間(目前已知多個訊息會導致訊息重疊)(預設False，會覆寫顯示位置設定)</param>
        public void ShowAlert_Custom(Alert alertType, string Content, string Title, int AlertSecond = -1, object CustomScreenPosition = null, Point ScreenPositionLocation = new Point(), bool ShowMessageOnScreenCenter = false)
        {
            // TODO 下次是不是要補一下圖示
            RadDesktopAlert radDesktopAlert = new RadDesktopAlert();

            
            
            DesktopAlertPopup alertpopup = radDesktopAlert.Popup;

            // 取得呼叫的應用程式位置
            var apps = Application.OpenForms;
            var app = apps.Count > 0 ? apps[apps.Count - 1] : null;

            // app.InvokeRequired 為True時，代表跨執行緒執行
            // 應用程式所在作用的螢幕
            var ActiveScreen = (app == null || app.InvokeRequired) ? Screen.PrimaryScreen : Screen.FromControl(app);
            var screenWidth = ActiveScreen.Bounds.Width;
            var screenHeight = ActiveScreen.Bounds.Height;
            // 多螢幕下，將執行設定為視窗的那個螢幕
            DesktopAlertManager.Instance.SetActiveScreen(ActiveScreen);

            #region 通用排版樣式
            // 提示框上的三點是否要繪制
            radDesktopAlert.Popup.AlertElement.CaptionElement.CaptionGrip.ShouldPaint = false;
            // 是否自動關閉
            radDesktopAlert.AutoClose = alertType != Alert.Error; // Error 不自動關閉
            // 自動關閉的秒數
            radDesktopAlert.AutoCloseDelay = AlertSecond != -1 ? (AlertSecond > 1 ? AlertSecond : 1) : alertType.ToNumberValue();
            radDesktopAlert.Popup.AlertElement.BorderDashStyle = DashStyle.Dot;
            radDesktopAlert.Popup.AlertElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;//.OuterInnerBorders;
            // 底色是否要漸層
            radDesktopAlert.Popup.AlertElement.GradientStyle = GradientStyles.Solid;
            // 標題文字
            radDesktopAlert.CaptionText = Title;
            // 內文
            radDesktopAlert.ContentText = Content;
            // 風格樣式
            //radDesktopAlert.ThemeName = "FluentDatk";

            // 自動尺吋
            radDesktopAlert.AutoSize = true;
            // 關閉鈕
            radDesktopAlert.ShowCloseButton = true;//alertType != Alert.Success;  // Success會一閃而過，就不需要關閉鈕了
            // 選項鈕
            radDesktopAlert.ShowOptionsButton = false;
            // 釘選鈕
            radDesktopAlert.ShowPinButton = false;
            // 內文字型
            radDesktopAlert.Popup.AlertElement.ContentElement.Font = ContentFont;
            // 標題字型
            radDesktopAlert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = CaptionFont;

            // 跳出提示的位置
            //radDesktopAlert.ScreenPosition = AlertScreenPosition.Manual;
            // 跳出提示下方的一排按鈕排版空間
            //radDesktopAlert.Popup.AlertElement.ButtonsPanel 
            // 內文相關設定
            //radDesktopAlert.Popup.AlertElement.ContentElement
            // 標題相關設定
            //radDesktopAlert.Popup.AlertElement.CaptionElement
            #endregion 通用排版樣式

            switch (alertType)
            {
                case Alert.Error:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.BottomRight;
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = ErrorColor;
                    //radDesktopAlert.Popup.AlertElement.ContentImage = RadMessageIcon.Info;
                    // Properties.Resources.envelope
                    break;

                case Alert.Success:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.Manual;
                    if (alertpopup != null)
                    {
                        // TODO 想找找是不是能放畫面正中間，多個訊息好像會重疊
                        // 目前先暫時這樣子，不會太明顯的歪…
                        // 公式：多螢幕的偏移 + 所在螢幕的一半 - 訊息框的大概尺吋(暫時抓不到會多少，先以大概的數字來取)
                        alertpopup.Location = new Point(ActiveScreen.Bounds.X + ((int)(screenWidth / 2)) - 160, ActiveScreen.Bounds.Y + ((int)(screenHeight / 2)) - 80);
                    }
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = SuccessColor;
                    break;

                case Alert.Warning:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.BottomRight;
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = WarningColor;
                    break;
            }

            #region 使用者自訂項目
            // 當有指定底色時，使用指定的底色
            if (BackGroupColor != Color.Transparent)
            {
                radDesktopAlert.Popup.AlertElement.BackColor = BackGroupColor;
            }

            // 當有指定出現位置時，使用指定位置
            if (CustomScreenPosition != null && CustomScreenPosition is AlertScreenPosition)
            {
                if ((AlertScreenPosition)CustomScreenPosition == AlertScreenPosition.Manual)
                {
                    if (ScreenPositionLocation != null)
                    {
                        alertpopup.Location = ScreenPositionLocation;
                    }
                }
                radDesktopAlert.ScreenPosition = (AlertScreenPosition)CustomScreenPosition;
            }
            //訊息是否顯示在螢幕中間
            if (ShowMessageOnScreenCenter)
            {
                radDesktopAlert.ScreenPosition = AlertScreenPosition.Manual;
                // 公式：多螢幕的偏移 + 所在螢幕的一半 - 訊息框的大概尺吋(暫時抓不到會多少，先以大概的數字來取)
                alertpopup.Location = new Point(ActiveScreen.Bounds.X + ((int)(screenWidth / 2)) - 160, ActiveScreen.Bounds.Y + ((int)(screenHeight / 2)) - 80);
            }

            #endregion 使用者自訂項目

            radDesktopAlert.Show();
        }


        /// <summary>
        /// 客製化顯示Alert
        /// </summary>
        /// <param name="_settings">設定值</param>
        public void ShowAlert_CustomDesktop(DesktopAlertUtilSettingsModel _settings)
        {
            if (_settings is null)
            {
                return;
            }

            if (_settings._radDesktopAlert != null)
            {
                _settings._radDesktopAlert.Hide();
                _settings._radDesktopAlert.Dispose();
                _settings._radDesktopAlert = null;
            }

            _settings._radDesktopAlert = new RadDesktopAlert();
            
            
            // 取得呼叫的應用程式位置
            var apps = Application.OpenForms;
            var app = apps.Count > 0 ? apps[apps.Count - 1] : null;

            // app.InvokeRequired 為True時，代表跨執行緒執行
            // 應用程式所在作用的螢幕
            var ActiveScreen = (app == null || app.InvokeRequired) ? Screen.PrimaryScreen : Screen.FromControl(app);
            var screenWidth = ActiveScreen.Bounds.Width;
            var screenHeight = ActiveScreen.Bounds.Height;
            // 多螢幕下，將執行設定為視窗的那個螢幕
            DesktopAlertManager.Instance.SetActiveScreen(ActiveScreen);

            _settings._radDesktopAlert.Popup.AlertElement.BorderDashStyle = DashStyle.Dot;
            _settings._radDesktopAlert.Popup.AlertElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;
            //底色是否要漸層
            _settings._radDesktopAlert.Popup.AlertElement.GradientStyle = GradientStyles.Solid;


            _settings._radDesktopAlert.Popup.AlertElement.CaptionElement.CaptionGrip.GradientStyle = GradientStyles.Solid; //Title列 風格
            if (_settings.CustomBackColor)
            {
                //Title背景色
                _settings._radDesktopAlert.Popup.AlertElement.CaptionElement.CaptionGrip.BackColor = _settings.TitleBackColor;
                //內文背景色
                _settings._radDesktopAlert.Popup.AlertElement.BackColor = _settings.ContentBackColor;
            }
            else
            {
                //Title背景色
                //_settings._radDesktopAlert.Popup.AlertElement.CaptionElement.CaptionGrip.BackColor = Color.LightYellow;
                //內文背景色
                //_settings._radDesktopAlert.Popup.AlertElement.BackColor = Color.LightGoldenrodYellow;
                switch (_settings.alertType)
                {
                    case Alert.Success:
                        _settings._radDesktopAlert.Popup.AlertElement.BackColor = SuccessColor;
                        break;
                    case Alert.Error:
                        _settings._radDesktopAlert.Popup.AlertElement.BackColor = ErrorColor;
                        break;
                    case Alert.Warning:
                    default:
                        _settings._radDesktopAlert.Popup.AlertElement.BackColor = WarningColor;
                        break;
                }
            }

            // 提示框上的三點是否要繪制
            _settings._radDesktopAlert.Popup.AlertElement.CaptionElement.CaptionGrip.ShouldPaint = false;

            
            _settings._radDesktopAlert.CaptionText = $"{_settings.Title}"; //Title
            _settings._radDesktopAlert.ContentText = $"{_settings.Content}"; // Content

            // 內文字型
            _settings._radDesktopAlert.Popup.AlertElement.ContentElement.Font = _settings.ContentFont != null ? _settings.ContentFont : ContentFont;
            // 標題字型
            _settings._radDesktopAlert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = _settings.TitleFont != null ? _settings.TitleFont : CaptionFont;

            if (_settings.buttonItemsList?.Any() is true)
            {
                foreach (var item in _settings.buttonItemsList)
                {
                    _settings._radDesktopAlert.ButtonItems.Add(item);
                }
            }
            
            _settings._radDesktopAlert.AutoSize = _settings.CustomSize.HasValue == false;
            //因為IsTextTruncated()方法會依照字型進行計算，故需要再呼叫前設定好元件字型大小
            var TruncatedResult = IsTextTruncated(_settings._radDesktopAlert);
            if (TruncatedResult.IsOk == false)
            {
                if (_settings.CustomSize.HasValue)
                {
                    if (_settings.CustomSize.Value.Width < 300 || _settings.CustomSize.Value.Height < 80)
                    {
                        _settings._radDesktopAlert.FixedSize = new Size(300, 80); //指定大小
                    }
                    else
                    {
                        _settings._radDesktopAlert.FixedSize = _settings.CustomSize.Value;
                    }
                }
            }

            // Content是否自動換行
            _settings._radDesktopAlert.Popup.AlertElement.ContentElement.TextWrap = true;
            // 關閉鈕
            _settings._radDesktopAlert.ShowCloseButton = _settings.ShowCloseButton;
            // 釘選鈕
            _settings._radDesktopAlert.ShowPinButton = _settings.ShowPinButton;
            // 選項紐
            _settings._radDesktopAlert.ShowOptionsButton = _settings.ShowOptionsButton;
            
            
            // 跳出提示的位置
            if (_settings.PopupScreenPosition != AlertScreenPosition.Manual && _settings.CustomPopupCenterScreen == false)
            {
                _settings._radDesktopAlert.ScreenPosition = _settings.PopupScreenPosition;
            }
            else
            {
                _settings._radDesktopAlert.ScreenPosition = AlertScreenPosition.Manual;
                if (_settings.CustomPopupCenterScreen || 
                    _settings.CustomPopupScreenPositionPoint.IsEmpty || 
                    (_settings.CustomPopupScreenPositionPoint.X < 0 || _settings.CustomPopupScreenPositionPoint.Y < 0))
                {
                    // 公式：多螢幕的偏移 + 所在螢幕的一半 - 訊息框的大概尺吋(暫時抓不到會多少，先以大概的數字來取)
                    _settings._radDesktopAlert.Popup.Location = new Point(ActiveScreen.Bounds.X + ((int)(screenWidth / 2)) - 160, ActiveScreen.Bounds.Y + ((int)(screenHeight / 2)) - 80);
                }
                else
                {
                    _settings._radDesktopAlert.Popup.Location = _settings.CustomPopupScreenPositionPoint;
                }
            }
            //當有按鈕時候
            bool hasButtonItems = _settings._radDesktopAlert.ButtonItems?.Any() is true;
            
            switch (_settings.AutoClose)
            {
                case null:
                    if (hasButtonItems)
                    {
                        _settings._radDesktopAlert.AutoClose = false;
                        _settings._radDesktopAlert.AutoCloseDelay = 99;
                    }
                    else
                    {
                        _settings._radDesktopAlert.AutoClose = true;
                        _settings._radDesktopAlert.AutoCloseDelay = _settings.alertType.ToNumberValue();
                    }
                    break;
                case true:
                    _settings._radDesktopAlert.AutoClose = true;
                    if (_settings.AutoCloseDelay < 0)
                    {
                        _settings._radDesktopAlert.AutoCloseDelay = 8;
                    }
                    else
                    {
                        _settings._radDesktopAlert.AutoCloseDelay = _settings.AutoCloseDelay;
                    }
                    break;
                case false:
                    _settings._radDesktopAlert.AutoClose = false;
                    _settings._radDesktopAlert.AutoCloseDelay = 99;
                    break;
            }
            _settings._radDesktopAlert.Show();

        }
        /// <summary>
        /// 自動依照內文文字大小調整FixedSize
        /// 備註:會依照字型進行計算，故需要再呼叫前設定好元件字型大小
        /// </summary>
        /// <param name="alert">元件</param>
        /// <returns></returns>
        public ServiceResult IsTextTruncated(RadDesktopAlert alert)
        {
            ServiceResult returnResult = new ServiceResult(false, string.Empty);
            try
            {
                if (alert is null)
                {
                    returnResult.Message = "元件不可為Null";
                    return returnResult;
                }

                if (alert.AutoSize)
                {
                    returnResult.IsOk = true;
                    returnResult.Message = "已經設定為自動調整文字大小";
                    return returnResult;
                }

                var minW = 300;
                var maxW = 600;
                var minH = 90;
                var maxH = 600;

                var contentElement = alert.Popup.AlertElement.ContentElement;
                string text = alert.ContentText;
                Font font = alert.Popup.AlertElement.ContentElement.Font;

                int horizontalPadding = 50;
                int verticalPadding = 40;

                // --- 1. 計算理想寬度 ---
                // 先測量在「不限制寬度」的情況下，文字會長多寬
                Size idealSize = TextRenderer.MeasureText(text, font);

                // 最終寬度 = 限制在 minW 與 maxW 之間 (加上 Padding)
                int finalWidth = Math.Max(minW, Math.Min(idealSize.Width + horizontalPadding, maxW));

                // --- 2. 根據最終寬度計算高度 ---
                Size layoutSize = new Size(finalWidth - horizontalPadding, int.MaxValue);
                Size textSize = TextRenderer.MeasureText(text, font, layoutSize, TextFormatFlags.WordBreak);

                // --- 3. 處理按鈕空間 ---
                int buttonHeight = (alert.ButtonItems.Count > 0) ? 40 : 0;

                // --- 4. 總結高度並應用限制 ---
                int requiredHeight = textSize.Height + verticalPadding + buttonHeight;
                int finalHeight = Math.Max(minH, Math.Min(requiredHeight, maxH));

                // 5. 更新尺寸
                alert.FixedSize = new Size(finalWidth, finalHeight);
                // 確保文字換行開啟
                contentElement.TextWrap = true;

                returnResult.IsOk = true;
                returnResult.Message = "自動調整文字完成!";
            }
            catch(Exception ex)
            {
                returnResult.Exception = ex;
                returnResult.IsOk = false;
                returnResult.Message = "RadDesktopAlert自動調整內文文字失敗，錯誤訊息" + ex.GetInnerException().ErrorMessage;
            }
            return returnResult;

        }
        /// <summary>
        /// RadDesktopAlert 設定參數
        /// </summary>
        public class DesktopAlertUtilSettingsModel
        {
            public DesktopAlertUtilSettingsModel(RadDesktopAlert radDesktopAlert, CoreBaseFontsProxy.PresetFonts presetFonts = CoreBaseFontsProxy.PresetFonts.YaHeiConsolasHybrid)
            {
                _radDesktopAlert = radDesktopAlert;
                PresetFonts = presetFonts;
                ContentFont = CoreBaseFontsProxy.GetFont(presetFonts);
                TitleFont = CoreBaseFontsProxy.GetFont(presetFonts, 16f, true);
            }
            public DesktopAlertUtilSettingsModel(RadDesktopAlert radDesktopAlert, Alert alertType, CoreBaseFontsProxy.PresetFonts presetFonts = CoreBaseFontsProxy.PresetFonts.YaHeiConsolasHybrid)
            {
                _radDesktopAlert = radDesktopAlert;
                this.alertType = alertType;
                PresetFonts = presetFonts;
                ContentFont = CoreBaseFontsProxy.GetFont(presetFonts);
                TitleFont = CoreBaseFontsProxy.GetFont(presetFonts, 16f, true);
            }
            /// <summary>
            /// 主體物件
            /// </summary>
            public RadDesktopAlert _radDesktopAlert { get; set; }
            /// <summary>
            /// 顯示型態
            /// </summary>
            public Alert alertType { get; set; } = Alert.Success;
            /// <summary>
            /// 標題
            /// </summary>
            public string Title { get; set; } = string.Empty;
            /// <summary>
            /// 內文
            /// </summary>
            public string Content { get; set; } = string.Empty;

            #region 視窗大小

            /// <summary>
            /// 視窗大小
            /// </summary>
            public Size? CustomSize { get; set; } = null;

            /// <summary>
            /// 是否自定義被景色
            /// </summary>
            public bool CustomBackColor { get; set; } = false;
            /// <summary>
            /// 內文 背景色[預設Color.LightGoldenrodYellow;] (CustomBackColor需為True才有效)
            /// </summary>
            public Color ContentBackColor { get; set; } = Color.LightGoldenrodYellow;
            /// <summary>
            /// 標題列 背景色[預設Color.LightYellow;] (CustomBackColor需為True才有效)
            /// </summary>
            public Color TitleBackColor { get; set; } = Color.LightYellow;
            #endregion

            /// <summary>
            /// 是否顯示關閉紐
            /// </summary>
            public bool ShowCloseButton { get; set; } = true;
            /// <summary>
            /// 是否顯示釘選鈕
            /// </summary>
            public bool ShowPinButton { get; set;} = false;
            /// <summary>
            /// 是否顯示選項鈕
            /// </summary>
            public bool ShowOptionsButton { get; set;} = false;

            #region 自動關閉 延遲關閉視窗

            /// <summary>
            /// 是否自動關閉[預設Null, Null=&gt;依照alertType設定、True:自動關閉(依照AutoCloseDelay設定關閉時間)、False:不會自動關閉]
            /// </summary>
            public bool? AutoClose { get; set; } = null;
            /// <summary>
            /// 延遲關閉視窗時間[預設8秒]
            /// 若AutoCloseDelay小於0 ，則會設定為預設數值8秒
            /// </summary>
            public int AutoCloseDelay { get; set; } = 8;

            #endregion


            #region Font 字型
            /// <summary>
            /// 標題字型
            /// </summary>
            public Font TitleFont { get; set; }
            /// <summary>
            /// 內文字型
            /// </summary>
            public Font ContentFont { get; set; }
            /// <summary>
            /// 預設字體(YaHeiConsolasHybrid) 如果ContentFont || TitleFont為Null 則使用此字體
            /// </summary>
            public CoreBaseFontsProxy.PresetFonts PresetFonts { get; set; } = CoreBaseFontsProxy.PresetFonts.YaHeiConsolasHybrid;

            #endregion


            #region Popup 位置

            /// <summary>
            /// 彈出顯示位置[預設BottomRight]
            /// </summary>
            public AlertScreenPosition PopupScreenPosition { get; set; } = AlertScreenPosition.BottomRight;
            /// <summary>
            /// 自訂彈出顯示位置[PopupScreenPosition須為Manual，此設定才有效]
            /// </summary>
            public Point CustomPopupScreenPositionPoint { get; set; } = new Point();
            /// <summary>
            /// 設定螢幕中心為彈出顯示位置[PopupScreenPosition須為Manual，此設定才有效]
            /// </summary>
            public bool CustomPopupCenterScreen { get; set; } = false;

            #endregion

            /// <summary>
            /// 元件顯示按鈕
            /// </summary>
            public List<RadButtonElement> buttonItemsList { get; set; } = new List<RadButtonElement>();

        }
    }
}
