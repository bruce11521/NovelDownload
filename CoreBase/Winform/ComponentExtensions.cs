using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CoreBase.Help;
using CoreBase.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.BreadCrumb;
using Telerik.WinControls.UI.Localization;

namespace CoreBase.Winform
{
    /// <summary>
    /// 元件相關擴充
    /// </summary>
    public static class ComponentExtensions
    {
        /// <summary>
        /// 將資料放到元件之中 ( Data → 元件 )
        /// 依據元件的Tag來放，Tag沒寫，改以Name來找，找不到就不會放，裡面遞迴放資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="con">元件</param>
        /// <param name="model">資料</param>
        /// <returns></returns>
        public static Control MappingControls<T>(this Control con, T model)
        {
            //var modelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //con.MappingControls(modelInfos);
            // 預設以 Tag 的名稱對應 Model 欄位
            var MappingKey = con.Tag?.ToString();

            // Tag 沒值，改成 Name 來對應
            if (string.IsNullOrWhiteSpace(MappingKey))
            {
                MappingKey = con.Name;
            }

            var result = typeof(T).GetProperties()
                     .Where(o => o.Name == MappingKey)
                     .ToDictionary(p => p.Name, p => p.GetValue(model));

            if (result.Any())
            {
                if (con is ComboBox)
                {
                    if (result.Values.FirstOrDefault() == null)
                    {
                        ((ComboBox)con).SelectedValue = -1;
                    }
                    else
                    {
                        ((ComboBox)con).SelectedValue = result.Values.FirstOrDefault().ToString();
                    }
                }
                else if (con is Label)
                {
                    ((Label)con).Text = result.Values.FirstOrDefault()?.ToString();
                }
                else if (con is TextBox)
                {
                    ((TextBox)con).Text = result.Values.FirstOrDefault()?.ToString();
                }
                else if (con is NumberTextBox)
                {
                    ((NumberTextBox)con).Text = result.Values.FirstOrDefault().ToString();
                }
                else if (con is MyDateTimePicker)
                {
                    var dateResult = (DateTime?)result.Values.FirstOrDefault();
                    if (dateResult != null && dateResult > DateTime.MinValue && dateResult < DateTime.MaxValue)
                    {
                        if (((MyDateTimePicker)con).ShowCheckBox)
                        {
                            ((MyDateTimePicker)con).Checked = true;
                        }
                        ((MyDateTimePicker)con).Value = dateResult.Value;
                    }
                    else
                    {
                        if (((MyDateTimePicker)con).ShowCheckBox)
                        {
                            ((MyDateTimePicker)con).Checked = false;
                        }
                        // TODO 清掉
                    }
                }
                else if (con is DateTimePicker)
                {
                    var dateResult = (DateTime?)result.Values.FirstOrDefault();
                    if (dateResult != null && dateResult > DateTime.MinValue && dateResult < DateTime.MaxValue)
                    {
                        if (((DateTimePicker)con).ShowCheckBox)
                        {
                            ((DateTimePicker)con).Checked = true;
                        }
                        ((DateTimePicker)con).Value = dateResult.Value;
                    }
                    else
                    {
                        // TODO 清掉
                    }
                }
            }

            // 遞迴
            if (con.Controls.Count > 0)
            {
                foreach (Control son in con.Controls)
                {
                    son.MappingControls(model);
                }
            }

            return con;
        }

        /// <summary>
        /// 將元件中的值放回至Model之中 ( 元件 → Data )
        /// 依據元件的Tag來放，Tag沒寫，改以Name來找，找不到就不會放，裡面遞迴放資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="con"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T ControlMappingModel<T>(this Control con, T model)
        {
            try
            {
                // 預設以 Tag 的名稱對應 Model 欄位
                var MappingKey = con.Tag?.ToString();

                // Tag 沒值，改成 Name 來對應
                if (string.IsNullOrWhiteSpace(MappingKey))
                {
                    MappingKey = con.Name;
                }

                var column = typeof(T).GetProperties().FirstOrDefault(o => o.Name == MappingKey);
                var columnType = column?.PropertyType.ToString().Split('.').Last().TrimEnd(']');
                var isNullable = new Regex("System\\.Nullable").IsMatch(column?.PropertyType.ToString() ?? string.Empty);

                if (column != null)
                {
                    if (con is ComboBox)
                    {
                        if (((ComboBox)con).SelectedIndex == -1)
                        {
                            column.SetValue(model, null);
                        }
                        else
                        {
                            column.SetValue(model, ((ComboBox)con).SelectedValue);
                        }
                    }
                    else if (con is TextBox)
                    {
                        if (string.IsNullOrWhiteSpace(((TextBox)con).Text))
                        {
                            // 可Nullable的放Null，不可Nullable的放0
                            if (isNullable || columnType == "String")
                            {
                                column.SetValue(model, null);
                            }
                            else
                            {
                                column.SetValue(model, 0);
                            }
                        }
                        else
                        {
                            switch (columnType)
                            {
                                case "Int16":
                                case "Int32":
                                    column.SetValue(model, ((TextBox)con).Text.ToInt());
                                    break;
                                case "Int64":
                                    column.SetValue(model, ((TextBox)con).Text.ConvertToInt64());
                                    break;
                                case "Decimal":
                                    column.SetValue(model, ((TextBox)con).Text.ToDecimal());
                                    break;
                                case "Single":
                                    column.SetValue(model, ((TextBox)con).Text.ToSingle());
                                    break;
                                case "Double":
                                    column.SetValue(model, ((TextBox)con).Text.ToDouble());
                                    break;
                                default:
                                    column.SetValue(model, ((TextBox)con).Text);
                                    break;
                            }

                        }

                        //if (string.IsNullOrWhiteSpace(((TextBox)con).Text ))
                        //{
                        //    column.SetValue(model, null);
                        //}
                        //else
                        //{
                        //    column.SetValue(model, ((TextBox)con).Text);
                        //}
                    }
                    else if (con is NumberTextBox)
                    {
                        column.SetValue(model, ((NumberTextBox)con).Text);
                    }
                    else if (con is MyDateTimePicker)
                    {
                        if (((MyDateTimePicker)con).ShowCheckBox && ((MyDateTimePicker)con).Checked == false)
                        {
                            // 沒開CheckBox 或是有開。但有選有修改值的通通都不會進這一段
                            column.SetValue(model, null);
                        }
                        else
                        {
                            column.SetValue(model, ((MyDateTimePicker)con).Value);
                        }
                    }
                    else if (con is DateTimePicker)
                    {
                        if (((DateTimePicker)con).ShowCheckBox && ((DateTimePicker)con).Checked == false)
                        {
                            // 沒開CheckBox 或是有開。但有選有修改值的通通都不會進這一段
                            column.SetValue(model, null);
                        }
                        else
                        {
                            column.SetValue(model, ((DateTimePicker)con).Value);
                        }
                    }
                    else if (con is Label)
                    {
                        var aaa = string.Empty;
                        if (string.IsNullOrWhiteSpace(con.Text))
                        {
                            column.SetValue(model, null);
                        }
                        else
                        {
                            column.SetValue(model, con.Text);
                        }
                    }
                }

                if (con.Controls.Count > 0)
                {
                    foreach (Control son in con.Controls)
                    {
                        son.ControlMappingModel(model);
                    }
                }
            }
            catch(Exception ex)
            {
                
            }

            return model;
        }

        /// <summary>
        ///  Version Compare 版本號比較
        /// </summary>
        /// <param name="LocalVersion">[X.X.X.X] 本地端</param>
        /// <param name="OnlineVersion">[X.X.X.X] 線上端</param>
        /// <returns>(True:線上大於本地，False: 線上小於或等於本地, int 差異之版本號加權數[0代表版本號相同,1以上代表版本號有差異,-1代表運算錯誤], 詳細差異版本號數)</returns>
        public static ServiceResult<(bool IsOnlineMoreThanLocal, int DifferenceNumber, (int Major, int Minor, int Build, int Revision) DifferenceVersionNumber)> IsCompareVersionNeedUpdate(string LocalVersion, string OnlineVersion)
        {
            (bool IsOnlineMoreThanLocal, int DifferenceNumber, (int Major, int Minor, int Build, int Revision)) ReturnResult = (false, -1, (0, 0, 0, 0));
            ServiceResult<(bool IsOnlineMoreThanLocal, int DifferenceNumber, (int Major, int Minor, int Build, int Revision))> result = new ServiceResult<(bool IsOnlineMoreThanLocal, int DifferenceNumber, (int Major, int Minor, int Build, int Revision))> { IsOk = false, Data = ReturnResult };

            try
            {
                //Priority: 1 > 2 > 3 > 4
                //[加權值, 線上 CompareTo 本地]
                Dictionary<int, int> VersionPriority = new Dictionary<int, int>() { { 8, 0 }, { 4, 0 }, { 2, 0 }, { 1, 0 } };

                if (!string.IsNullOrWhiteSpace(LocalVersion) && !string.IsNullOrWhiteSpace(OnlineVersion))
                {
                    var localVersion = LocalVersion.Split('.');
                    var onlineVersion = OnlineVersion.Split('.');

                    if ((localVersion?.Any() ?? false )&& localVersion.Count() == 4
                        && (onlineVersion?.Any() ?? false) && onlineVersion.Count() == localVersion.Count())
                    {
                        //版本號格式[Major.MINOR.BUILD.REVISION]
                        int MAJOR = 0, MINOR = 0, BUILD = 0, REVISION = 0;
                        for (int index = 0; index < 4; index++)
                        {
                            if (int.TryParse(onlineVersion[index], out int OnlineResult) && int.TryParse(localVersion[index], out int LocalResult))
                            {
                                var it = 0;
                                //加權值 Index[0.1.2.3] = [8,4,2,1]
                                switch (index)
                                {
                                    case 0:
                                        it = 8;
                                        MAJOR = Math.Abs(OnlineResult - LocalResult);
                                        break;
                                    case 1:
                                        it = 4;
                                        MINOR = Math.Abs(OnlineResult - LocalResult);
                                        break;
                                    case 2:
                                        it = 2;
                                        BUILD = Math.Abs(OnlineResult - LocalResult);
                                        break;
                                    case 3:
                                        it = 1;
                                        REVISION = Math.Abs(OnlineResult - LocalResult);
                                        break;
                                }
                                //依照加權值，決定大小
                                if (OnlineResult > LocalResult)
                                {
                                    //線上 > 本地
                                    VersionPriority[it] = 1;
                                }
                                else if (OnlineResult < LocalResult)
                                {
                                    //線上 < 本地
                                    VersionPriority[it] = -1;
                                }
                                else
                                {
                                    //線上 = 本地
                                    VersionPriority[it] = 0;
                                }

                            }
                        }
                        //總加權值計算判斷
                        int loc = 0, online = 0;
                        foreach (var item in VersionPriority)
                        {
                            if (item.Value > 0)
                            {
                                online += item.Value * Math.Abs(item.Key);

                            }
                            else if (item.Value < 0)
                            {
                                loc += Math.Abs(item.Value) * Math.Abs(item.Key);
                            }
                        }

                        if (Math.Abs(online) > Math.Abs(loc))
                        {
                            //線上 大於 本地
                            ReturnResult = (true, Math.Abs(online - loc), (MAJOR, MINOR, BUILD, REVISION));
                            result.Message = $"版本過舊{LocalVersion}，線上版本為{OnlineVersion}，請重新開啟HIS2 Menu{Environment.NewLine}謝謝。";
                        }
                        else if (Math.Abs(online) == Math.Abs(loc))
                        {
                            //線上 = 本地
                            ReturnResult = (false, 0, (MAJOR, MINOR, BUILD, REVISION));
                        }
                        else
                        {
                            //線上 小於 本地 
                            ReturnResult = (false, Math.Abs(online - loc), (MAJOR, MINOR, BUILD, REVISION));
                        }

                        result.IsOk = !ReturnResult.IsOnlineMoreThanLocal;
                        result.Data = ReturnResult;
                    }
                }            
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Message = $"無法比對版本，請重新開啟HIS2 Menu{Environment.NewLine}";
            }

            return result;
        }
        /// <summary>
        /// Windows作業系統資訊(Win10含以上 IsOk = true, 其他則false)
        /// </summary>
        /// <returns></returns>
        public static ServiceResult OperateSystemVersionInfo()
        {
            ServiceResult<EnumUtility.OsVersion> ReturnResult = new ServiceResult<EnumUtility.OsVersion>(false, string.Empty, EnumUtility.OsVersion.Null);
            try
            {
                var OsVersion = Environment.OSVersion;
                if (OsVersion != null)
                {
                    switch (OsVersion?.Version?.Major)
                    {
                        case 12:
                            //Win12 ?
                            ReturnResult.Data = EnumUtility.OsVersion.Win12;
                            ReturnResult.IsOk = true;
                            break;
                        case 11:
                            //Win11
                            ReturnResult.Data = EnumUtility.OsVersion.Win11;
                            ReturnResult.IsOk = true;
                            break;
                        case 10:
                            //Win10
                            ReturnResult.Data = EnumUtility.OsVersion.Win10;
                            ReturnResult.IsOk = true;
                            break;
                        case 6 when OsVersion.Version.Minor == 1:
                            //Win7
                            ReturnResult.Data = EnumUtility.OsVersion.Win7;
                            break;
                        case 6 when OsVersion.Version.Minor == 2:
                            //Win8
                            ReturnResult.Data = EnumUtility.OsVersion.Win8;
                            break;
                        case 6 when OsVersion.Version.Minor == 3:
                            //WIn8.1
                            ReturnResult.Data = EnumUtility.OsVersion.Win8_1;
                            break;
                        case 6:
                            //Vista
                            ReturnResult.Data = EnumUtility.OsVersion.WinVista;
                            break;
                        case 5 when OsVersion.Version.Minor == 1:
                            //XP-x86
                            ReturnResult.Data = EnumUtility.OsVersion.WinXPx86;
                            break;
                        case 5 when OsVersion.Version.Minor == 2:
                            //XP-x64
                            ReturnResult.Data = EnumUtility.OsVersion.WinXPx64;
                            break;
                        case 5:
                            //Win2000
                            ReturnResult.Data = EnumUtility.OsVersion.Win2000;
                            break;
                        default:
                            if(OsVersion?.Version?.Major < 5)
                            {
                                ReturnResult.Data = EnumUtility.OsVersion.LessThanWin2000;
                            }
                            else
                            {
                                ReturnResult.Data = EnumUtility.OsVersion.UnknownOsVersion;
                            }
                            break;
                    }
                    ReturnResult.Message += $"目前作業系統版本:{ReturnResult.Data.GetEnumDisplayName()}";
                    ReturnResult.Code = OsVersion?.Version?.Major ?? -1;
                }
            }
            catch(Exception ex)
            {
                ReturnResult.IsOk = false;
                ReturnResult.Message += "[THROW]:" + ex.Message;
                ReturnResult.Exception = ex;
            }
            return ReturnResult;
        }

        #region 抓取該Control全域中的所有Type
        /// <summary>
        /// 抓取該 Form 全域 Control
        /// </summary>
        /// <param name="control">欲抓取的Control(Ex:this)</param>
        /// <param name="type">欲抓取的Type(Ex:typeof(Button))</param>
        /// <returns></returns>
        public static IEnumerable<Control> GetAllControl(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControl(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }
        /// <summary>
        /// 抓取該 Form 全域 Control
        /// </summary>
        /// <param name="control">欲抓取的Control(Ex:this)</param>
        /// <returns></returns>
        public static List<Control> GetAllControlList(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls?.SelectMany(ctrl => GetAllControlList(ctrl))?.Concat(controls)?.ToList();
        }
        /// <summary>
        /// 列舉該控制項下所有子控制項（不回傳 null）
        /// </summary>
        /// <param name="rootControl">欲抓取的Control(Ex:this)</param>
        /// <returns></returns>
        public static IEnumerable<Control> GetAllControlEnumerate(Control rootControl)
        {
            if (rootControl != null)
            {
                var stack = new Stack<Control>();
                stack.Push(rootControl);
                while (stack.Count > 0)
                {
                    var c = stack.Pop();
                    foreach (Control child in c.Controls)
                    {
                        yield return child;
                        stack.Push(child);
                    }
                }
            }
        }
        #endregion

        #region SetControlFont
        /// <summary>
        /// 回傳輸入的Font
        /// </summary>
        /// <param name="FontSizeFloat">字體大小(預設12f)</param>
        /// <param name="IsBold">是否為粗體(預設否)</param>
        /// <param name="IsItalics">是否為斜體(預設否)</param>
        /// <param name="IsUnderLine">是否為底線(預設否)</param>
        /// <param name="IsStrikeout">是否為刪除線(預設否)</param>
        public static Font SetFontSize(float FontSizeFloat = 12f
            , bool IsBold = false
            , bool IsItalics = false
            , bool IsUnderLine = false
            , bool IsStrikeout = false)
        {
            return SetFontSizeLogical(CoreBaseFontsProxy.PresetFonts.YaHeiConsolasHybrid, FontSizeFloat, IsBold, IsItalics, IsUnderLine, IsStrikeout);
        }
        /// <summary>
        /// 回傳輸入的Font
        /// </summary>
        /// <param name="PresetFont">預設字體(CoreBaseFontsProxy.PresetFonts.SarasaUiTC_Regular)</param>
        /// <param name="FontSizeFloat">字體大小(預設12f)</param>
        /// <param name="IsBold">是否為粗體(預設否)</param>
        /// <param name="IsItalics">是否為斜體(預設否)</param>
        /// <param name="IsUnderLine">是否為底線(預設否)</param>
        /// <param name="IsStrikeout">是否為刪除線(預設否)</param>
        public static Font SetFontSize(CoreBaseFontsProxy.PresetFonts PresetFont = CoreBaseFontsProxy.PresetFonts.SarasaUiTC_Regular,
            float FontSizeFloat = 12f
            , bool IsBold = false
            , bool IsItalics = false
            , bool IsUnderLine = false
            , bool IsStrikeout = false)
        {
            return SetFontSizeLogical(PresetFont, FontSizeFloat, IsBold, IsItalics, IsUnderLine, IsStrikeout);
        }

        /// <summary>
        /// 回傳輸入的Font
        /// </summary>
        /// <param name="PresetFont">預設字體(CoreBaseFontsProxy.PresetFonts.SarasaUiTC_Regular)</param>
        /// <param name="FontSizeFloat">字體大小(預設12f)</param>
        /// <param name="IsBold">是否為粗體(預設否)</param>
        /// <param name="IsItalics">是否為斜體(預設否)</param>
        /// <param name="IsUnderLine">是否為底線(預設否)</param>
        /// <param name="IsStrikeout">是否為刪除線(預設否)</param>
        /// <returns></returns>
        private static Font SetFontSizeLogical(CoreBaseFontsProxy.PresetFonts PresetFont = CoreBaseFontsProxy.PresetFonts.SarasaUiTC_Regular, 
            float FontSizeFloat = 12f
            , bool IsBold = false
            , bool IsItalics = false
            , bool IsUnderLine = false
            , bool IsStrikeout = false
            )
        {
            if (FontSizeFloat <= 0f)
            {
                FontSizeFloat = 12f;
            }
            try
            {
                return CoreBaseFontsProxy.GetFont(PresetFont, FontSizeFloat, IsBold, IsItalics, IsUnderLine, IsStrikeout);
            }
            catch
            {
                return new Font("細明體", FontSizeFloat);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private static List<string> TelerikControlNameList = new List<string>()
        {

            nameof(RadLabel), nameof(RadButton), nameof(RadTextBox), nameof(RadTextBoxControl), nameof(RadDropDownList),
            nameof(RadMultiColumnComboBox), nameof(RadRadioButton), nameof(RadGridView), nameof(RadGroupBox),
            nameof(RadPageView), nameof(RadCheckBox), nameof(RadTaskDialogPage), nameof(RadMenuItem), nameof(RadMenu),
            nameof(RadStatusStrip), nameof(RadLabelElement), nameof(RadDateTimePicker), nameof(RadDropDownButton),
            nameof(RadListControl), nameof(RadSplitButton), nameof(RadOpenFileDialog), nameof(RadOpenFolderDialog),
            nameof(RadSaveFileDialog), nameof(RadCollapsiblePanel), nameof(RadProgressBar)
        };
        /// <summary>
        /// 設定控制項字體
        /// </summary>
        /// <param name="rootControl"></param>
        /// <param name="targetFont"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static ServiceResult SetControlFont(Control rootControl, Font targetFont = null, Type targetType = null)
        {
            ServiceResult returnResult = new ServiceResult(false, string.Empty);
            try
            {
                if (rootControl == null)
                {
                    returnResult.Message = $"{nameof(rootControl)}控制項不可為空!";
                    return returnResult;
                }
                if (targetFont == null)
                {
                    targetFont = SetFontSize(CoreBaseFontsProxy.PresetFonts.SarasaUiTC_Regular);
                }

                if (targetType == null || targetType.IsInstanceOfType(rootControl))
                {
                    SetControlItemFont(rootControl, targetFont);
                    rootControl.Font = targetFont;
                }

                int affectedCount = 0;
                foreach (Control child in GetAllControlEnumerate(rootControl))
                {
                    if (targetType == null || targetType.IsInstanceOfType(child))
                    {
                        SetControlItemFont(child, targetFont);
                        child.Font = targetFont;
                        affectedCount++;
                    }
                }
                returnResult.IsOk = true;
                returnResult.Message = targetType != null
                    ? $"根控制項下共 {affectedCount} 個【{targetType.Name}】型別控制項設定Font完成"
                    : $"{nameof(rootControl)}下全控制項設定Font完成";
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message = "THROW" + ex.GetInnerException().ErrorMessage;
            }
            return returnResult;
        }
        /// <summary>
        /// Control Item Font
        /// </summary>
        /// <param name="child"></param>
        /// <param name="targetFont"></param>
        private static void SetControlItemFont(Control child, Font targetFont)
        {
            if (child == null || targetFont == null) return;

            if (child is RadCheckBox itemCheckBox)
            {
                itemCheckBox.ButtonElement.CheckMarkPrimitive.CheckElement.UseFixedCheckSize = false;
                itemCheckBox.ButtonElement.CheckMarkPrimitive.CheckElement.CheckPrimitiveStyle = Telerik.WinControls.Enumerations.CheckPrimitiveStyleEnum.Mac;
                itemCheckBox.ButtonElement.CheckMarkPrimitive.CheckElement.MinSize = new Size(Convert.ToInt32(targetFont.Size * 1.5), Convert.ToInt32(targetFont.Size * 1.5));
                itemCheckBox.Font = targetFont;
            }
            else if (child is RadMultiColumnComboBox itemRMCCB)
            {
                itemRMCCB.Font = targetFont;
                itemRMCCB.MultiColumnComboBoxElement.TextboxContentElement.Font = targetFont;
                itemRMCCB.MultiColumnComboBoxElement.TextBoxElement.Font = targetFont;
                itemRMCCB.EditorControl.TableElement.Font = targetFont;  //下拉選單Font Size
                itemRMCCB.EditorControl.ViewCellFormatting -= EditorControlOnViewCellFormatting;
                itemRMCCB.EditorControl.ViewCellFormatting += EditorControlOnViewCellFormatting;
            }
            else if (child is RadDropDownList itemRDDL)
            {
                itemRDDL.Font = targetFont;
                itemRDDL.ListElement.Font = targetFont;
                itemRDDL.DropDownListElement.Font = targetFont;
                if (targetFont.Name == CoreBaseFontsProxy.PresetFonts.SarasaUiTC_Regular.GetEnumDisplayName())
                {
                    switch (targetFont.Size)
                    {
                        case 12f:
                            itemRDDL.ListElement.ItemHeight = 21;
                            itemRDDL.DropDownListElement.ItemHeight = 21;
                            break;
                        case 13f:
                            itemRDDL.ListElement.ItemHeight = 23;
                            itemRDDL.DropDownListElement.ItemHeight = 23;
                            break;
                        case 14f:
                            itemRDDL.ListElement.ItemHeight = 25;
                            itemRDDL.DropDownListElement.ItemHeight = 25;
                            break;
                    }
                    
                }
            }
            else if (child is RadRadioButton itemRadioButton)
            {
                itemRadioButton.Font = targetFont;
                //RadRadioButton 框框變大
                itemRadioButton.ButtonElement.CheckMarkPrimitive.MinSize = targetFont.Size == 12f ?
                    new Size(16, 16) :
                    new Size(Convert.ToInt32(16 * targetFont.Size / 12), Convert.ToInt32(16 * targetFont.Size / 12));
                //RadRadioButton 框框內的原點也變大&置中
                if (itemRadioButton.ButtonElement.CheckMarkPrimitive.FindDescendant<RadioPrimitive>() is RadioPrimitive rrbRP)
                {
                    rrbRP.MinSize = targetFont.Size == 12f
                        ? new Size(16, 16)
                        : new Size(Convert.ToInt32(16 * targetFont.Size / 12),
                            Convert.ToInt32(16 * targetFont.Size / 12));
                    rrbRP.Alignment = ContentAlignment.MiddleCenter;
                }
            }
            else if (child is RadGroupBox itemGroupBox)
            {
                itemGroupBox.Font = targetFont;
                itemGroupBox.GroupBoxElement.Header.Font = targetFont;
                itemGroupBox.GroupBoxElement.Content.Font = targetFont;
            }
            else if (child is RadPageView itemPageView)
            {
                itemPageView.Font = targetFont;
                foreach (RadPageViewPage itemPageViewPage in itemPageView.Pages)
                {
                    itemPageViewPage.Font = targetFont;
                }
            }
            else if (child is RadGridView rgv)
            {
                rgv.Font = targetFont;
                if (targetFont.Name == CoreBaseFontsProxy.PresetFonts.SarasaUiTC_Regular.GetEnumDisplayName())
                {
                    var textAlignment = rgv.TableElement.TextAlignment;
                    switch (targetFont.Size)
                    {
                        case 12f:
                            rgv.TableElement.RowHeight = 26;
                            break;
                        case 13f:
                            rgv.TableElement.RowHeight = 26;
                            break;
                        case 14f:
                            rgv.TableElement.RowHeight = 29;
                            break;
                    }
                    if (textAlignment.ToString().Contains("Left"))
                    {
                        textAlignment = ContentAlignment.BottomLeft;
                    }
                    else if (textAlignment.ToString().Contains("Right"))
                    {
                        textAlignment = ContentAlignment.BottomRight;
                    }
                    else if (textAlignment.ToString().Contains("Center"))
                    {
                        textAlignment = ContentAlignment.BottomCenter;
                    }
                    rgv.TableElement.TextAlignment = textAlignment;
                    if (rgv.Columns?.Any() is true)
                    {
                        ContentAlignment cellTextAlignment = ContentAlignment.MiddleLeft;
                        foreach (var col in rgv.Columns)
                        {
                            cellTextAlignment = col.TextAlignment;
                            if (cellTextAlignment.ToString().Contains("Left"))
                            {
                                cellTextAlignment = ContentAlignment.BottomLeft;
                            }
                            else if (cellTextAlignment.ToString().Contains("Right"))
                            {
                                cellTextAlignment = ContentAlignment.BottomRight;
                            }
                            else if (cellTextAlignment.ToString().Contains("Center"))
                            {
                                cellTextAlignment = ContentAlignment.BottomCenter;
                            }
                            col.TextAlignment = cellTextAlignment;
                        }
                    }
                }
                
            }
            else if (child is RadSplitButton rsb)
            {
                rsb.Font = targetFont;
            }
            else if (child is RadStatusStrip rss)
            {
                foreach (var item in rss.Items)
                {
                    item.Font = targetFont;
                }
            }
            else if (child is RadDateTimePicker rdtp)
            {
                rdtp.Font = targetFont;
                rdtp.DateTimePickerElement.Calendar.Font = targetFont;   //月份大小
                RadDateTimePickerCalendar calendarBehavior = (rdtp.DateTimePickerElement.GetCurrentBehavior() as RadDateTimePickerCalendar);
                //calendarBehavior.DropDownSizingMode = SizingMode.None;
                if (calendarBehavior != null)
                {
                    RadCalendarElement calenderElement = calendarBehavior.Calendar.CalendarElement;
                    calenderElement.CalendarNavigationElement.Font = targetFont; //符號大小
                    MonthViewElement monthview = calendarBehavior.Calendar.CalendarElement.CalendarVisualElement as MonthViewElement;
                    foreach (RadItem item in monthview.TableElement.Children)    //日期大小
                    {
                        item.Font = targetFont;
                    }
                    calenderElement.Calendar.HeaderNavigationMode = HeaderNavigationMode.Zoom;  //啟用HeaderNavigationMode=縮放模式
                    var CalenderVisualElementFontSize = targetFont;
                    calenderElement.Calendar.ZoomChanged += (sender, e) =>
                    {
                        if (sender is RadCalendar radCalendar)
                        {
                            MonthViewElement month_view = radCalendar.CalendarElement.CalendarVisualElement as MonthViewElement;
                            foreach (RadItem item in month_view?.TableElement?.Children)    //日期大小
                            {
                                item.Font = CalenderVisualElementFontSize != null ? CalenderVisualElementFontSize : SetFontSize(12f);
                            }
                        }
                    };   //設定Header縮放模式
                }
            }
            else if (child is RadDropDownButton itemDropDownButton)
            {
                itemDropDownButton.Font = targetFont;
                foreach (var item in itemDropDownButton.Items)
                {
                    item.Font = targetFont;
                }
            }
            else if (child is RadListControl itemListControl)
            {
                itemListControl.ListElement.Font = targetFont;
            }
            else
            {
                var typeItem = child.GetType();
                switch (typeItem.Name)
                {
                    case nameof(RadTaskDialogPage):
                        foreach (var itemTaskDialog in GetAllControlEnumerate(child))
                        {
                            if (itemTaskDialog is RadTaskDialogControl rtdc)
                            {
                                rtdc.Page.Font = targetFont;
                            }
                            else
                            {
                                itemTaskDialog.Font = targetFont;
                            }
                        }
                        break;
                    case nameof(RadLabelElement):
                        foreach (var itemLabelElement in GetAllControlEnumerate(child))
                        {
                            itemLabelElement.Font = targetFont;
                        }
                        break;
                    case nameof(RadMenuItem):
                        if (child is RadMenu rm)
                        {
                            if (rm.Items != null)
                            {
                                foreach (var itemMenuItem in rm.Items)
                                {
                                    itemMenuItem.Font = targetFont;
                                    if (itemMenuItem is RadMenuItem rmi)
                                    {
                                        foreach (var rmiItem in rmi.Items)
                                        {
                                            rmiItem.Font = targetFont;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (var itemMenuItem in GetAllControl(child, typeof(RadMenuItem)))
                            {
                                itemMenuItem.Font = targetFont;
                            }
                        }
                        break;
                    case nameof(RadOpenFileDialog):
                    case nameof(RadOpenFolderDialog):
                    case nameof(RadSaveFileDialog):
                        foreach (var itemFileDialogControl in GetAllControlEnumerate(child))
                        {
                            if (itemFileDialogControl is RadListView rlv)
                            {
                                rlv.VisualItemFormatting -= RadListView_VisualItemFormatting;
                                rlv.VisualItemFormatting += RadListView_VisualItemFormatting;
                                rlv.CellFormatting -= RadListView_CellFormatting;
                                rlv.CellFormatting += RadListView_CellFormatting;
                            }
                            else if (itemFileDialogControl is RadTreeView rtv)
                            {
                                rtv.NodeFormatting -= RadTreeView_NodeFormatting;
                                rtv.NodeFormatting += RadTreeView_NodeFormatting;
                            }
                            else if (itemFileDialogControl is RadBreadCrumb rbc)
                            {
                                rbc.HistoryItemCreated -= RadBreadCrumb_OnHistoryItemCreated;
                                rbc.HistoryItemCreated += RadBreadCrumb_OnHistoryItemCreated;

                                rbc.AutoCompleteSuggestHelper.DropDownList.ItemDataBound -= RadBreadCrumb_DropDownListOnItemDataBound;
                                rbc.AutoCompleteSuggestHelper.DropDownList.ItemDataBound += RadBreadCrumb_DropDownListOnItemDataBound;

                                rbc.SplitButtonCreated -= RadBreadCrumb_SplitButtonCreated;
                                rbc.SplitButtonCreated += RadBreadCrumb_SplitButtonCreated;

                                rbc.BreadCrumbElement.HeaderDropDownButtonElement.DropDownOpening -= RadBreadCrumb_HeaderDropDownButtonElement_DropDownOpening;
                                rbc.BreadCrumbElement.HeaderDropDownButtonElement.DropDownOpening += RadBreadCrumb_HeaderDropDownButtonElement_DropDownOpening;

                            }
                            else if (itemFileDialogControl is RadDropDownButton rddb)
                            {
                                rddb.DropDownOpening -= RadDropDownButton_DropDownOpening;
                                rddb.DropDownOpening += RadDropDownButton_DropDownOpening;
                            }
                        }
                        break;
                    case nameof(RadCollapsiblePanel):
                        foreach (var itemCollapsiblePanel in GetAllControlList(child))
                        {
                            if (itemCollapsiblePanel is RadCollapsiblePanel rcsp)
                            {
                                rcsp.Font = targetFont;
                            }
                        }
                        break;
                    case nameof(RadProgressBar):
                        foreach (var itemProgress in GetAllControlList(child))
                        {
                            if (itemProgress is RadProgressBar rp)
                            {
                                rp.Font = targetFont;
                            }
                        }
                        break;
                }
            }
        }





        #region 獨立出的具名事件方法 (徹底防止 Memory Leak 的仙丹)

        private static void RadCalendar_ZoomChanged(object sender, EventArgs e)
        {
            if (sender is RadCalendar radCalendar)
            {
                var month_view = radCalendar.CalendarElement.CalendarVisualElement as MonthViewElement;
                foreach (RadItem item in month_view?.TableElement?.Children)
                {
                    // 這裡抓取 Calendar 本身的 Font 作為基準
                    item.Font = radCalendar.Font;
                }
            }
        }

        private static void RadListView_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        {
            if (sender is RadListView rlv) e.VisualItem.Font = rlv.Font;
        }

        private static void RadListView_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
        {
            if (sender is RadListView rlv) e.CellElement.Font = rlv.Font;
        }

        private static void RadTreeView_NodeFormatting(object sender, TreeNodeFormattingEventArgs e)
        {
            if (sender is RadTreeView rtv) e.NodeElement.ContentElement.Font = rtv.Font;
        }
        private static void RadBreadCrumb_OnHistoryItemCreated(object sender, AssociatedMenuItemEventArgs e)
        {
            if (sender is RadBreadCrumb rbc) e.MenuItem.Font = rbc.Font;
        }
        private static void RadBreadCrumb_DropDownListOnItemDataBound(object sender, ListItemDataBoundEventArgs e)
        {
            if (sender is RadBreadCrumb rbc) e.NewItem.Font = rbc.Font;
        }
        private static void RadDropDownButton_DropDownOpening(object sender, EventArgs e)
        {
            if (sender is RadDropDownButton rddb)
            {
                foreach (RadItem item in rddb.Items)
                {
                    item.Font = rddb.Font;
                }
            }
        }

        private static void RadBreadCrumb_HeaderDropDownButtonElement_DropDownOpening(object sender, CancelEventArgs e)
        {
            if (sender is BreadCrumbDropDownButtonElement bcddbe)
            {
                foreach (RadItem item in bcddbe.Items)
                {
                    item.Font = bcddbe.Font;
                }
            }
        }

        private static void RadBreadCrumb_SplitButtonCreated(object sender, SplitButtonCreatedEventArgs e)
        {
            if (sender is RadBreadCrumb rbc)
            {
                foreach (RadItem item in e.SplitButtonElement.Items)
                {
                    item.Font = rbc.Font;
                }
            }
        }


        private static void EditorControlOnViewCellFormatting(object sender, CellFormattingEventArgs args)
        {
            if (sender is RadGridView gv)
            {
                args.CellElement.Font = gv.Font;
            }
        }

        #endregion

        /// <summary>
        /// 設定所有Control Font (預設12f)
        /// </summary>
        /// <param name="object_">Object (Form || Control)</param>
        /// <param name="SetFont">字型大小(預設12f)</param>
        /// <param name="OverrideThemeName">是否複寫主題名稱</param>
        /// <param name="ThemeName">主題名稱(預設ControlDefault),空值傳入也預設為ControlDefault</param>
        /// <param name="ControlName">控制像名稱:只更改該控制項之字形大小(ALL為清單中全部Control皆改變)</param>
        public static bool SetControlFont(object object_, float SetFont = 12f, bool OverrideThemeName = false, string ThemeName = "ControlDefault", string ControlName = "ALL")
        {
            if (string.IsNullOrWhiteSpace(ThemeName))
            {
                ThemeName = "ControlDefault";
            }
            Control TypeOfControl_ = null;
            if (object_ is Form form)
            {
                TypeOfControl_ = form;
            }
            else if (object_ is Control control)
            {
                TypeOfControl_ = control;
            }
            else
            {
                return false;
            }
            if (ControlName == "ALL")
            {
                foreach (var item in TelerikControlNameList)
                {
                    SetControlFont_Custom(TypeOfControl_, SetFont, OverrideThemeName, ThemeName, item);
                }
                if (object_ is Form form_)
                {
                    form_.Font = SetFontSize(12f);
                }
            }
            else
            {
                SetControlFont_Custom(TypeOfControl_, SetFont, OverrideThemeName, ThemeName, ControlName);
            }
            return true;
        }
        private static bool SetControlFont_Custom(Control TypeOfControl, float SetFont = 12f, bool OverrideThemeName = false, string ThemeName = "ControlDefault", string ControlName = "_DEFAULT_")
        {
            Font Fonts = SetFontSize(SetFont);
            switch (ControlName)
            {
                case nameof(RadLabel):
                    foreach (RadLabel itemLabel in GetAllControl(TypeOfControl, typeof(RadLabel)))
                    {
                        if (itemLabel.Name == "radLabel_MainTitle")
                        {
                            if (itemLabel.LabelElement.Font.Size > SetFontSize(18f).Size)
                            {
                                itemLabel.LabelElement.Font = SetFontSize(26f);
                            }
                            else if (itemLabel.LabelElement.Font.FontFamily.Name == "Segoe UI")
                            {
                                itemLabel.LabelElement.Font = SetFontSize(26f);
                            }
                            if (OverrideThemeName)
                            {
                                itemLabel.ThemeName = ThemeName;
                            }
                        }
                        else
                        {
                            itemLabel.LabelElement.Font = Fonts;
                            if (OverrideThemeName)
                                itemLabel.ThemeName = ThemeName;
                        }
                    }
                    break;
                case nameof(RadButton):
                    foreach (RadButton itemButton in GetAllControl(TypeOfControl, typeof(RadButton)))
                    {
                        itemButton.Font = Fonts;
                        if (OverrideThemeName)
                            itemButton.ThemeName = ThemeName;
                    }
                    break;
                case nameof(RadTextBox):
                    foreach (RadTextBox itemTextBox in GetAllControl(TypeOfControl, typeof(RadTextBox)))
                    {
                        itemTextBox.Font = Fonts;
                        if (OverrideThemeName)
                            itemTextBox.ThemeName = ThemeName;
                    }
                    break;
                case nameof(RadTextBoxControl):
                    foreach (RadTextBoxControl itemTextBoxControl in GetAllControl(TypeOfControl, typeof(RadTextBoxControl)))
                    {
                        itemTextBoxControl.Font = Fonts;
                        if (OverrideThemeName)
                            itemTextBoxControl.ThemeName = ThemeName;
                    }
                    break;
                case nameof(RadDropDownList):
                    foreach (RadDropDownList itemRDDL in GetAllControl(TypeOfControl, typeof(RadDropDownList)))
                    {
                        itemRDDL.Font = Fonts;
                        itemRDDL.ListElement.Font = Fonts;
                        itemRDDL.DropDownListElement.Font = Fonts;
                        if (OverrideThemeName)
                            itemRDDL.ThemeName = ThemeName;

                    }
                    break;
                case nameof(RadMultiColumnComboBox):
                    foreach (RadMultiColumnComboBox itemRMCCB in GetAllControl(TypeOfControl, typeof(RadMultiColumnComboBox)))
                    {
                        itemRMCCB.Font = Fonts;
                        itemRMCCB.MultiColumnComboBoxElement.TextboxContentElement.Font = Fonts;
                        itemRMCCB.MultiColumnComboBoxElement.TextBoxElement.Font = Fonts;
                        itemRMCCB.EditorControl.TableElement.Font = Fonts;  //下拉選單Font Size
                        if (OverrideThemeName)
                            itemRMCCB.ThemeName = ThemeName;
                    }
                    break;
                case nameof(RadRadioButton):
                    foreach (RadRadioButton itemRadioButton in GetAllControl(TypeOfControl, typeof(RadRadioButton)))
                    {
                        itemRadioButton.Font = Fonts;
                        if (OverrideThemeName)
                            itemRadioButton.ThemeName = ThemeName;

                        //RadRadioButton 框框變大
                        itemRadioButton.ButtonElement.CheckMarkPrimitive.MinSize = SetFont == 12f ? new Size(16, 16) : new Size(Convert.ToInt32(16 * SetFont / 12), Convert.ToInt32(16 * SetFont / 12));
                        //RadRadioButton 框框內的原點也變大&置中
                        if (itemRadioButton.ButtonElement.CheckMarkPrimitive.FindDescendant<RadioPrimitive>() is RadioPrimitive rrbRP)
                        {
                            rrbRP.MinSize = SetFont == 12f ? new Size(16, 16) : new Size(Convert.ToInt32(16 * SetFont / 12), Convert.ToInt32(16 * SetFont / 12));
                            rrbRP.Alignment = ContentAlignment.MiddleCenter;
                        }
                    }
                    break;
                case nameof(RadGridView):
                    foreach (RadGridView itemGridView in GetAllControl(TypeOfControl, typeof(RadGridView)))
                    {
                        itemGridView.Font = Fonts;
                        if (OverrideThemeName)
                            itemGridView.ThemeName = ThemeName;
                    }
                    break;
                case nameof(RadGroupBox):
                    foreach (RadGroupBox itemGroupBox in GetAllControl(TypeOfControl, typeof(RadGroupBox)))
                    {
                        itemGroupBox.Font = Fonts;
                        itemGroupBox.GroupBoxElement.Header.Font = Fonts;
                        itemGroupBox.GroupBoxElement.Content.Font = Fonts;
                        if (OverrideThemeName)
                            itemGroupBox.ThemeName = ThemeName;
                    }
                    break;
                case nameof(RadCheckBox):
                    foreach (RadCheckBox itemCheckBox in GetAllControl(TypeOfControl, typeof(RadCheckBox)))
                    {
                        itemCheckBox.ButtonElement.CheckMarkPrimitive.CheckElement.UseFixedCheckSize = false;
                        itemCheckBox.ButtonElement.CheckMarkPrimitive.CheckElement.CheckPrimitiveStyle = Telerik.WinControls.Enumerations.CheckPrimitiveStyleEnum.Mac;
                        itemCheckBox.ButtonElement.CheckMarkPrimitive.CheckElement.MinSize = new Size(Convert.ToInt32(SetFont * 1.5), Convert.ToInt32(SetFont * 1.5));
                        itemCheckBox.Font = Fonts;
                        if (OverrideThemeName)
                            itemCheckBox.ThemeName = ThemeName;
                    }
                    break;
                case nameof(RadPageView):
                    foreach (RadPageView itemPageView in GetAllControl(TypeOfControl, typeof(RadPageView)))
                    {
                        itemPageView.Font = Fonts;
                        foreach (RadPageViewPage itemPageViewPage in itemPageView.Pages)
                        {
                            itemPageViewPage.Font = Fonts;
                        }
                        //itemPageViewPage.ThemeName = ThemeName;
                    }
                    break;
                case nameof(RadTaskDialogPage):
                    foreach (var itemTaskDialog in GetAllControl(TypeOfControl, typeof(RadTaskDialogPage)))
                    {
                        if (itemTaskDialog is RadTaskDialogControl rtdc)
                        {
                            rtdc.Page.Font = Fonts;
                        }
                        else
                        {
                            itemTaskDialog.Font = Fonts;
                        }
                        //itemTaskDialog.ThemeName = ThemeName;
                    }
                    break;
                case nameof(RadMenuItem):
                    if (TypeOfControl is RadMenu rm)
                    {
                        if (rm.Items != null)
                        {
                            foreach (var itemMenuItem in rm.Items)
                            {
                                itemMenuItem.Font = Fonts;
                                if (itemMenuItem is RadMenuItem rmi)
                                {
                                    foreach (var rmiItem in rmi.Items)
                                    {
                                        rmiItem.Font = Fonts;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var itemMenuItem in GetAllControl(TypeOfControl, typeof(RadMenuItem)))
                        {
                            itemMenuItem.Font = Fonts;
                        }
                    }
                    break;
                case nameof(RadMenu):
                    foreach (var itemMenu in GetAllControl(TypeOfControl, typeof(RadMenu)))
                    {
                        itemMenu.Font = Fonts;
                    }
                    break;
                case nameof(RadStatusStrip):
                    if (TypeOfControl is RadStatusStrip rss)
                    {
                        foreach (var item in rss.Items)
                        {
                            item.Font = Fonts;
                        }
                    }
                    //foreach (var itemStatusStrip in GetAllControl(TypeOfControl, typeof(RadStatusStrip)))
                    //{

                    //    itemStatusStrip.Font = Fonts;
                    //}
                    break;
                case nameof(RadLabelElement):
                    foreach (var itemLabelElement in GetAllControl(TypeOfControl, typeof(RadLabelElement)))
                    {
                        itemLabelElement.Font = Fonts;
                    }
                    break;
                case nameof(RadDateTimePicker):
                    if (TypeOfControl is RadDateTimePicker rdtp)
                    {
                        rdtp.Font = Fonts;
                        rdtp.DateTimePickerElement.Calendar.Font = Fonts;   //月份大小
                        RadDateTimePickerCalendar calendarBehavior = (rdtp.DateTimePickerElement.GetCurrentBehavior() as RadDateTimePickerCalendar);
                        //calendarBehavior.DropDownSizingMode = SizingMode.None;
                        if (calendarBehavior != null)
                        {
                            RadCalendarElement calenderElement = calendarBehavior.Calendar.CalendarElement;
                            calenderElement.CalendarNavigationElement.Font = Fonts; //符號大小
                            MonthViewElement monthview = calendarBehavior.Calendar.CalendarElement.CalendarVisualElement as MonthViewElement;
                            foreach (RadItem item in monthview.TableElement.Children)    //日期大小
                            {
                                item.Font = Fonts;
                            }
                            calenderElement.Calendar.HeaderNavigationMode = HeaderNavigationMode.Zoom;  //啟用HeaderNavigationMode=縮放模式
                            var CalenderVisualElementFontSize = Fonts;
                            calenderElement.Calendar.ZoomChanged += (sender, e) =>
                            {
                                if (sender is RadCalendar radCalendar)
                                {
                                    MonthViewElement month_view = radCalendar.CalendarElement.CalendarVisualElement as MonthViewElement;
                                    foreach (RadItem item in month_view.TableElement.Children)    //日期大小
                                    {
                                        item.Font = CalenderVisualElementFontSize != null ? CalenderVisualElementFontSize : SetFontSize(12f);
                                    }
                                }
                            };   //設定Header縮放模式
                        }
                    }
                    break;
                case nameof(RadDropDownButton):
                    foreach (RadDropDownButton itemDropDownButton in GetAllControl(TypeOfControl, typeof(RadDropDownButton)))
                    {
                        itemDropDownButton.Font = Fonts;
                        foreach (var item in itemDropDownButton.Items)
                        {
                            item.Font = Fonts;
                        }
                    }
                    break;
                case nameof(RadListControl):
                    foreach (RadListControl itemListControl in GetAllControl(TypeOfControl, typeof(RadListControl)))
                    {
                        itemListControl.ListElement.Font = Fonts;
                        //itemListControl.ListElement.ItemSpacing = 2;
                        //itemListControl.ListElement.ItemHeight = 26;
                    }
                    break;
                case nameof(RadSplitButton):
                    foreach (RadSplitButton itemSplitButton in GetAllControl(TypeOfControl, typeof(RadSplitButton)))
                    {
                        itemSplitButton.DropDownButtonElement.Font = Fonts;
                        //itemListControl.ListElement.ItemSpacing = 2;
                        //itemListControl.ListElement.ItemHeight = 26;
                    }
                    break;
                case nameof(RadOpenFileDialog):
                case nameof(RadOpenFolderDialog):
                case nameof(RadSaveFileDialog):
                    foreach (var itemFileDialogControl in GetAllControlList(TypeOfControl))
                    {
                        if (itemFileDialogControl is RadListView rlv)
                        {
                            rlv.VisualItemFormatting += (sender, e) =>
                            {
                                e.VisualItem.Font = Fonts;
                            };
                            rlv.CellFormatting += (sender, e) =>
                            {
                                e.CellElement.Font = Fonts;
                            };
                        }
                        else if (itemFileDialogControl is RadTreeView rtv)
                        {
                            rtv.NodeFormatting += (sender, e) =>
                            {
                                e.NodeElement.ContentElement.Font = Fonts;
                            };
                        }else if (itemFileDialogControl is RadBreadCrumb rbc)
                        {
                            rbc.HistoryItemCreated += (sender, e) =>
                            {
                                e.MenuItem.Font = Fonts;
                            };
                            rbc.AutoCompleteSuggestHelper.DropDownList.ItemDataBound += (sender, e) =>
                            {
                                e.NewItem.Font = Fonts;
                            };
                            rbc.SplitButtonCreated += (sender, e) =>
                            {
                                foreach (RadItem item in e.SplitButtonElement.Items)
                                {
                                    item.Font = Fonts;
                                }
                            };
                            rbc.BreadCrumbElement.HeaderDropDownButtonElement.DropDownOpening += (sender, e) =>
                            {
                                if (sender is BreadCrumbDropDownButtonElement bcddbe)
                                {
                                    foreach (RadItem item in bcddbe.Items)
                                    {
                                        item.Font = Fonts;
                                    }
                                }
                            };
                        }else if (itemFileDialogControl is RadDropDownButton rddb)
                        {
                            rddb.DropDownOpening += (sender, e) =>
                            {
                                foreach (RadItem item in rddb.Items)
                                {
                                    item.Font = Fonts;
                                }
                            };
                        }
                    }
                    break;
                case nameof(RadCollapsiblePanel):
                    foreach (var itemCollapsiblePanel in GetAllControlList(TypeOfControl))
                    {
                        if (itemCollapsiblePanel is RadCollapsiblePanel rcsp)
                        {
                            rcsp.Font = Fonts;
                        }
                    }
                    break;
                case nameof(RadProgressBar):
                    foreach (var itemProgress in GetAllControlList(TypeOfControl))
                    {
                        if (itemProgress is RadProgressBar rp)
                        {
                            rp.Font = Fonts;
                        }
                    }
                    break;
                default:
                    break;
            }

            return true;
        }
        
        #endregion

        #region RadDateTimePicker UISetting
        /// <summary>
        /// 修改RadDateTimePicker UI, FontSize = 12f
        /// </summary>
        /// <param name="rdtp">Control</param>
        /// <param name="CustomDateFormate">可自訂格式[預設:yyyy/MM/dd]</param>
        /// <param name="CalendarSize">可自訂大小[預設:Size(300,250)]</param>
        public static void UI_SetDateTimePicker(RadDateTimePicker rdtp, string CustomDateFormate = "yyyy/MM/dd", Size CalendarSize = new Size(), bool IsShowDateTimePicker = false)
        {

            if (CalendarSize == new Size())
            {
                CalendarSize = new Size(300, 250);
            }

            Font DateTimeFonts = SetFontSize(12f);
            rdtp.NullText = CustomDateFormate + "...";
            rdtp.Value = DateTime.Now;
            rdtp.Format = DateTimePickerFormat.Custom;
            rdtp.Font = DateTimeFonts;
            rdtp.DateTimePickerElement.Calendar.Font = DateTimeFonts;   //月份大小
            rdtp.CustomFormat = CustomDateFormate;
            //rdtp.CustomFormat = "yyyy/MM/dd";
            rdtp.DateTimePickerElement.CalendarSize = CalendarSize; //日曆視窗大小
            //rdtp.DateTimePickerElement.CalendarSize = new Size(300, 250);

            RadDateTimePickerCalendar calendarBehavior = (rdtp.DateTimePickerElement.GetCurrentBehavior() as RadDateTimePickerCalendar);
            calendarBehavior.DropDownSizingMode = SizingMode.None;
            rdtp.DateTimePickerElement.ShowTimePicker = IsShowDateTimePicker;
            if (IsShowDateTimePicker)
            {
                calendarBehavior.DropDownMinSize = new Size(500, 350); //最小視窗大小
                calendarBehavior.Calendar.Size = new Size(230, 150); //日曆視窗大小
                calendarBehavior.TimePicker.Font = DateTimeFonts;//時間文字大小
            }


            RadCalendarElement calenderElement = calendarBehavior.Calendar.CalendarElement as RadCalendarElement;
            calenderElement.CalendarNavigationElement.Font = DateTimeFonts; //符號大小

            calenderElement.Calendar.HeaderNavigationMode = HeaderNavigationMode.Zoom;  //啟用HeaderNavigationMode=縮放模式
            calenderElement.Calendar.ZoomChanged += Calendar_ZoomChanged;   //設定Header縮放模式

            CalendarLocalizationProvider.CurrentProvider = new RadCalendarLocalizationProvider_Taiwan();
            if (calendarBehavior.Calendar.CalendarElement.CalendarVisualElement is MonthViewElement monthview)
            {
                //monthview.TableElement.Calendar
                foreach (CalendarCellElement item in monthview.TableElement.Children)
                {
                    item.Font = DateTimeFonts;
                }

                rdtp.DateTimePickerElement.Calendar.ShowFooter = true;
                rdtp.DateTimePickerElement.Calendar.ClearButton.Visibility = ElementVisibility.Hidden;

                rdtp.DateTimePickerElement.Calendar.ElementRender += (sender, e) =>
                {
                    var displayText = string.Empty;
                    switch (e.Element.Text)
                    {
                        case "Jan":
                            displayText = "1月";
                            break;
                        case "Feb":
                            displayText = "2月";
                            break;
                        case "Mar":
                            displayText = "3月";
                            break;
                        case "Apr":
                            displayText = "4月";
                            break;
                        case "May":
                            displayText = "5月";
                            break;
                        case "Jun":
                            displayText = "6月";
                            break;
                        case "Jul":
                            displayText = "7月";
                            break;
                        case "Aug":
                            displayText = "8月";
                            break;
                        case "Sep":
                            displayText = "9月";
                            break;
                        case "Oct":
                            displayText = "10月";
                            break;
                        case "Nov":
                            displayText = "11月";
                            break;
                        case "Dec":
                            displayText = "12月";
                            break;
                    }
                    switch (e.Element.ToolTipText)
                    {
                        case "Monday":
                            displayText = "一";
                            break;
                        case "Tuesday":
                            displayText = "二";
                            break;
                        case "Wednesday":
                            displayText = "三";
                            break;
                        case "Thursday":
                            displayText = "四";
                            break;
                        case "Friday":
                            displayText = "五";
                            break;
                        case "Saturday":
                            displayText = "六";
                            break;
                        case "Sunday":
                            displayText = "日";
                            break;
                    }

                    if (!string.IsNullOrWhiteSpace(displayText))
                    {
                        e.Element.Text = displayText;
                    }
                };
            }


        }

        private static void Calendar_ZoomChanged(object sender, CalendarZoomChangedEventArgs e)
        {
            RadCalendar radCalendar = sender as RadCalendar;
            if (radCalendar != null)
            {
                MonthViewElement monthview = radCalendar.CalendarElement.CalendarVisualElement as MonthViewElement;
                foreach (RadItem item in monthview.TableElement.Children)    //日期大小
                {
                    item.Font = SetFontSize(12f);
                }
            }
        }
        public class RadTimePickerLocalizationProvider_Taiwan : RadTimePickerLocalizationProvider
        {
            public override string GetLocalizedString(string id)
            {
                return base.GetLocalizedString(id);
            }
        }
        public class RadCalendarLocalizationProvider_Taiwan : CalendarLocalizationProvider
        {
            public override string GetLocalizedString(string id)
            {
                switch (id)
                {
                    case CalendarStringId.CalendarTodayButton: return "今日";
                    case CalendarStringId.CalendarClearButton: return "清除";
                    default:
                        return base.GetLocalizedString(id);
                }
            }
        }
        #endregion

        #region Utility Tool
        ///// <summary>
        ///// RadMessageBox樣式設定
        ///// </summary>
        ///// <param name="size">字體大小</param>
        //public static void radMsgboxFont(int? FontSize = null, int? ButtonSize = null, int? DetailFontSize = null)
        //{
        //    float fontsize = float.Parse((FontSize != null ? FontSize.Value : 13).ToString());
        //    float buttonsize = float.Parse((ButtonSize != null ? ButtonSize.Value : 13).ToString());
        //    float detailsize = float.Parse((DetailFontSize != null ? DetailFontSize.Value : 13).ToString());
        //    if (RadMessageBox.Instance != null)
        //    {
        //        RadMessageBox.Instance.ThemeName = "ControlDefault";
        //        RadMessageBox.Instance.FormElement.TitleBar.Font = new Font(CoreBaseFontsProxy.GetFontFamily(), 12, FontStyle.Regular);//變更TitleBar 字大小
        //        RadMessageBox.Instance.Controls["radLabel1"].Font = new Font(CoreBaseFontsProxy.GetFontFamily(), fontsize, FontStyle.Regular);
        //        RadMessageBox.Instance.Controls["radButton1"].Font = new Font(CoreBaseFontsProxy.GetFontFamily(), buttonsize, FontStyle.Regular);
        //        RadMessageBox.Instance.Controls["radButton2"].Font = new Font(CoreBaseFontsProxy.GetFontFamily(), buttonsize, FontStyle.Regular);
        //        RadMessageBox.Instance.Controls["radButton3"].Font = new Font(CoreBaseFontsProxy.GetFontFamily(), buttonsize, FontStyle.Regular);
        //        RadMessageBox.Instance.Controls["radButtonDetails"].Font = new Font(CoreBaseFontsProxy.GetFontFamily(), buttonsize, FontStyle.Regular);
        //        RadMessageBox.Instance.Controls["radButtonDetails"].Size = new Size(110, 27);
        //        RadMessageBox.Instance.Controls["radTextBoxDetials"].Font = new Font(CoreBaseFontsProxy.GetFontFamily(), detailsize, FontStyle.Regular);
        //        RadMessageLocalizationProvider.CurrentProvider = new ResetRadMessageBoxLocalizationProvider();
        //        RadMessageBox.Instance.AutoScaleMode = AutoScaleMode.None;
        //        RadMessageBox.Instance.TopMost = true;
        //        RadMessageBox.Instance.ShowInTaskbar = true;
        //    }
        //}

        private static Font RadMessageBoxLabelFont = new Font(CoreBaseFontsProxy.GetFontFamily(), 13f);
        private static Font RadMessageBoxButtonFont = new Font(CoreBaseFontsProxy.GetFontFamily(), 13f);
        private static Font RadMessageBoxTextBoxFont = new Font(CoreBaseFontsProxy.GetFontFamily(), 13f);

        /// <summary>
        /// RadMessageBox樣式設定
        /// </summary>
        /// <param name="MinWidth"></param>
        /// <param name="labelFontSize"></param>
        /// <param name="buttonFontSize"></param>
        /// <param name="detailTextBoxFontSize"></param>
        public static void radMsgboxFont(float? labelFontSize = null, float? buttonFontSize = null, float? detailTextBoxFontSize= null)
        {
            if (RadMessageBox.Instance != null)
            {
                var msgBox = RadMessageBox.Instance;
                msgBox.ThemeName = "ControlDefault";
                msgBox.AutoScaleMode = AutoScaleMode.Font;
                if (labelFontSize.HasValue)
                {
                    RadMessageBoxLabelFont = CoreBaseFontsProxy.GetFont(CoreBaseFontsProxy.PresetFonts.SarasaUiTC_Regular, labelFontSize.Value);
                }
                if (buttonFontSize.HasValue)
                {
                    RadMessageBoxButtonFont = CoreBaseFontsProxy.GetFont(CoreBaseFontsProxy.PresetFonts.SarasaUiTC_Regular, buttonFontSize.Value);
                }
                if (detailTextBoxFontSize.HasValue)
                {
                    RadMessageBoxTextBoxFont = CoreBaseFontsProxy.GetFont(CoreBaseFontsProxy.PresetFonts.SarasaUiTC_Regular, detailTextBoxFontSize.Value);
                }
                //// 【新功能】如果外部有指定最小寬度 (例如傳入 600)，強迫變寬
                //if (MinWidth.HasValue)
                //{
                //    msgBox.MinimumSize = new Size(MinWidth.Value, 0); // 高度維持 0 代表讓它自動算
                //}
                //else
                //{
                //    //自動縮放
                //    msgBox.MinimumSize = new Size(0, 0);
                //}
                msgBox.MinimumSize = new Size(0, 0);
                // 2. 安全變更 TitleBar 字型 (記得先 Dispose 舊的)
                if (msgBox.FormElement?.TitleBar != null)
                {
                    var oldTitleFont = msgBox.FormElement.TitleBar.Font;
                    if (oldTitleFont == null || oldTitleFont.Name != RadMessageBoxLabelFont.FontFamily.Name ||
                        (labelFontSize.HasValue && oldTitleFont.Size != labelFontSize))
                    {
                        msgBox.FormElement.TitleBar.Font = RadMessageBoxLabelFont;
                        if (oldTitleFont != null && (oldTitleFont.Name != RadMessageBoxLabelFont.FontFamily.Name &&
                                                     labelFontSize.HasValue && oldTitleFont.Size != labelFontSize))
                        {
                            oldTitleFont?.Dispose();
                        }
                    }
                }

                // 3. 【核心安全優化】不要用 Controls["名稱"] 死綁，改用安全遍歷防崩潰
                foreach (Control control in msgBox.Controls)
                {
                    if (control == null) continue;

                    // 抓取原本的舊 Font 用於後續 Dispose
                    var oldFont = control.Font;

                    if (control is RadLabel || control.Name == "radLabel1")
                    {
                        if (oldFont == null || oldFont.Name != RadMessageBoxLabelFont.FontFamily.Name ||
                            (labelFontSize.HasValue && oldFont.Size != labelFontSize))
                        {
                            control.Font = RadMessageBoxLabelFont;
                            if (oldFont != null && (oldFont.Name != RadMessageBoxLabelFont.FontFamily.Name &&
                                                    labelFontSize.HasValue && oldFont.Size != labelFontSize))
                            {
                                oldFont?.Dispose();
                            }
                        }
                    }
                    else if (control is RadButton btn)
                    {
                        if (btn.Name == "radButtonDetails")
                        {
                            btn.Size = new Size(110, 27);
                        }
                        else // 包含 radButton1, radButton2, radButton3...
                        {
                            btn.Size = new Size(75, 27);
                        }
                        if (oldFont == null || oldFont.Name != RadMessageBoxButtonFont.FontFamily.Name ||
                            (buttonFontSize.HasValue && oldFont.Size != buttonFontSize))
                        {
                            btn.Font = RadMessageBoxButtonFont;
                            if (oldFont != null && (oldFont.Name != RadMessageBoxButtonFont.FontFamily.Name &&
                                                    buttonFontSize.HasValue && oldFont.Size != buttonFontSize))
                            {
                                oldFont?.Dispose();
                            }
                        }
                    }
                    else if (control is RadTextBox || control.Name == "radTextBoxDetial")
                    {
                        if (oldFont == null || oldFont.Name != RadMessageBoxTextBoxFont.FontFamily.Name ||
                            (detailTextBoxFontSize.HasValue && oldFont.Size != detailTextBoxFontSize))
                        {
                            control.Font = RadMessageBoxTextBoxFont;
                            if (oldFont != null && (oldFont.Name != RadMessageBoxTextBoxFont.FontFamily.Name &&
                                                    detailTextBoxFontSize.HasValue && oldFont.Size != detailTextBoxFontSize))
                            {
                                oldFont?.Dispose();
                            }
                        }
                    }
                }
                // 4. 語系提供者設定
                RadMessageLocalizationProvider.CurrentProvider = new ResetRadMessageBoxLocalizationProvider();
            }
        }
        /// <summary>
        /// RadMessagebox Button文字
        /// </summary>
        public class RadMessageBoxLocalizationText
        {
            public RadMessageBoxLocalizationText()
            {
                YES = "是";
                NO = "否";
                OK = "確認";
                CANCEL = "取消";
                RETRY = "重試";
                IGNORE = "忽略";
                ABORT = "放棄";
                DETAILS = "詳細資訊";
            }
            public string YES { get; set; }
            public string NO { get; set; }
            public string OK { get; set; }
            public string CANCEL { get; set; }
            public string RETRY { get; set; }
            public string ABORT { get; set; }
            public string IGNORE { get; set; }
            public string DETAILS { get; set; }
        }

        /// <summary>
        /// 自訂RadMessageBox Button DisplayText(留空則使用預設文字)
        /// </summary>
        /// <param name="ManualButtonText"></param>
        /// <param name="ReDrawButton">是否需要重新繪製Button(功能測試中，尚未穩定，一旦啟用，在該程式結束前都會持續有效)[預設False]</param>
        public static void SetMsgBoxText_Manual(RadMessageBoxLocalizationText ManualButtonText, bool ReDrawButton = false)
        {
            string Yes = "是";
            string No = "否";
            string OK = "確認";
            string Cancel = "取消";
            string Retry = "重試";
            string Ignore = "忽略";
            string Abort = "放棄";
            string Details = "詳細資訊";

            string YesButton = string.IsNullOrWhiteSpace(ManualButtonText.YES) ? Yes : ManualButtonText.YES;
            string NoButton = string.IsNullOrWhiteSpace(ManualButtonText.NO) ? No : ManualButtonText.NO;
            string CancelButton = string.IsNullOrWhiteSpace(ManualButtonText.CANCEL) ? Cancel : ManualButtonText.CANCEL;
            string OKButton = string.IsNullOrWhiteSpace(ManualButtonText.OK) ? OK : ManualButtonText.OK;
            string RetryButton = string.IsNullOrWhiteSpace(ManualButtonText.RETRY) ? Retry : ManualButtonText.RETRY;
            string IgnoreButton = string.IsNullOrWhiteSpace(ManualButtonText.IGNORE) ? Ignore : ManualButtonText.IGNORE;
            string AbortButton = string.IsNullOrWhiteSpace(ManualButtonText.ABORT) ? Abort : ManualButtonText.ABORT;
            string DetailsButton = string.IsNullOrWhiteSpace(ManualButtonText.DETAILS) ? Details : ManualButtonText.DETAILS;

            RadMessageLocalizationProvider.CurrentProvider = new ManualRadMessageBoxLocalizationProvider()
            {
                YesButton = YesButton,
                NoButton = NoButton,
                CancelButton = CancelButton,
                OKButton = OKButton,
                RetryButton = RetryButton,
                IgnoreButton = IgnoreButton,
                AbortButton = AbortButton,
                DetailsButton = DetailsButton,
            };
            if (ReDrawButton)
            {
                RadMessageBox.Instance.Shown -= RadMessageBox_Instance_Shown;   //重新繪製Button框 大小
                RadMessageBox.Instance.Shown += RadMessageBox_Instance_Shown;
            }
        }

        /// <summary>
        /// MessageBox Shown事件(重新繪製Button框 大小)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void RadMessageBox_Instance_Shown(object sender, EventArgs e)
        {
            try
            {
                var FirstButtonFlag = false;
                var CounterX = 0;
                var CounterY = 0;
                RadMessageBoxForm MsgForm = sender as RadMessageBoxForm;
                if (MsgForm != null)
                {
                    List<Point> ButtonsList = new List<Point>();
                    var EachButtonWidth = 30;   //每個Button間距
                    var EachButtonTextPaddingWidth = 20;    //每個Button中文字與左右邊框的距離
                    var ButtonTotalWidth = 0;

                    foreach (var itx in MsgForm.Controls)
                    {
                        if (itx is RadButton)
                        {
                            if ((itx as RadButton) != null && (itx as RadButton).Name == "radButtonDetails" && (itx as RadButton).Visible)
                            {
                                return;
                            }
                        }
                    }

                    foreach (var item in MsgForm.Controls)
                    {
                        if (item is RadButton)
                        {
                            var rbtn = item as RadButton;

                            if (rbtn != null && rbtn.Name != "radButtonDetails" && rbtn.Visible)
                            {
                                if (!FirstButtonFlag)
                                {//第一個Button 
                                    FirstButtonFlag = !FirstButtonFlag;
                                    CounterX = rbtn.Location.X; //X軸
                                    CounterY = rbtn.Location.Y; //Y軸
                                    ButtonsList.Add(rbtn.Location);//位置加入
                                }
                                else
                                {//
                                    ButtonsList.Add(new Point(CounterX, CounterY));//加入各BUTTON起始點
                                }

                                var textSize = TextRenderer.MeasureText(rbtn.Text + "", rbtn.Font); //經由Font算出 Button 大小寬度
                                rbtn.Size = new Size(textSize.Width + EachButtonTextPaddingWidth, textSize.Height);//調整Button大小
                                CounterX += textSize.Width + EachButtonWidth;   //算出下一個Button X軸座標 
                                ButtonTotalWidth += textSize.Width + EachButtonWidth;   //算出目前從第一個Button左側起始座標到最後一個Button右側的最後一個座標()
                            }
                        }
                    }
                    var Counter = 0;
                    //var StartPoint = (MsgForm.Width - ButtonTotalWidth) / 2;
                    if (MsgForm.Width <= (ButtonTotalWidth + 50))
                    {//如果視窗寬度 < 所有Button總寬度
                        MsgForm.Width += 100;
                        var StartPoint = (MsgForm.Width - ButtonTotalWidth) / 2;
                        var Offset1 = ButtonsList[0].X - StartPoint;
                        foreach (var item in MsgForm.Controls)
                        {
                            var rbtn = item as RadButton;
                            if (rbtn != null && rbtn.Name != "radButtonDetails" && rbtn.Visible)
                            {

                                rbtn.Location = new Point(ButtonsList[Counter].X - Offset1, ButtonsList[Counter].Y);
                                Counter++;
                            }
                        }
                    }
                    else
                    {// 如果視窗寬度 > 所有Button總寬度
                        var StartPoint2 = (MsgForm.Width - ButtonTotalWidth) / 2;
                        var Offset = ButtonsList[0].X - StartPoint2;
                        foreach (var item in MsgForm.Controls)
                        {
                            var rbtn = item as RadButton;
                            if (rbtn != null && rbtn.Name != "radButtonDetails" && rbtn.Visible)
                            {
                                rbtn.Location = new Point(ButtonsList[Counter].X - Offset, ButtonsList[Counter].Y);
                                Counter++;
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("RadMessageBox異常，請聯繫系統管理員!", "訊息框異常", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //throw;
            }

        }
        public static void SetMsgBoxText_FormShiftRecord()
        {
            RadMessageLocalizationProvider.CurrentProvider = new CustomFormShiftRecordRadMessageBoxLocalizationProvider();
        }
        /// <summary>
        /// 重設RadMessageBox預設文字(中文)
        /// </summary>
        /// <param name="ReDrawButton">是否需要重新繪製Button(功能測試中，尚未穩定，一旦啟用，在該程式結束前都會持續有效)[預設False]</param>
        public static void ResetMsgBoxText(bool ReDrawButton = false)
        {
            //List<string> temp = new List<string>() { YesButton, NoButton, CancelButton, OKButton, RetryButton, IgnoreButton, AbortButton };
            //int btnWidth = 0;
            //foreach (string item in temp)
            //{
            //    if (item.Length > btnWidth)
            //    {
            //        btnWidth = item.Length;
            //    }
            //}

            RadMessageLocalizationProvider.CurrentProvider = new ResetRadMessageBoxLocalizationProvider();
            if (ReDrawButton)
            {
                RadMessageBox.Instance.Shown -= RadMessageBox_Instance_Shown;   //重新繪製Button框 大小
                RadMessageBox.Instance.Shown += RadMessageBox_Instance_Shown;
            }

            //RadMessageBox.Instance.ButtonSize = new Size(75, RadMessageBox.Instance.ButtonSize.Height);
            //RadMessageBox.Instance.ResetFormBehavior(true);
        }


        public class ManualRadMessageBoxLocalizationProvider : RadMessageLocalizationProvider
        {
            public string YesButton { get; set; }
            public string NoButton { get; set; }
            public string OKButton { get; set; }
            public string CancelButton { get; set; }
            public string RetryButton { get; set; }
            public string IgnoreButton { get; set; }
            public string AbortButton { get; set; }
            public string DetailsButton { get; set; }
            public override string GetLocalizedString(string id)
            {
                switch (id)
                {
                    case RadMessageStringID.YesButton:
                        return YesButton;
                    case RadMessageStringID.NoButton:
                        return NoButton;
                    case RadMessageStringID.OKButton:
                        return OKButton;
                    case RadMessageStringID.CancelButton:
                        return CancelButton;
                    case RadMessageStringID.RetryButton:
                        return RetryButton;
                    case RadMessageStringID.IgnoreButton:
                        return IgnoreButton;
                    case RadMessageStringID.AbortButton:
                        return AbortButton;
                    case RadMessageStringID.DetailsButton:
                        return DetailsButton;
                    default:
                        return base.GetLocalizedString(id);
                }
            }
        }

        /// <summary>
        /// 更改FormShiftRecord Button字詞
        /// </summary>
        public class CustomFormShiftRecordRadMessageBoxLocalizationProvider : RadMessageLocalizationProvider
        {
            //需加入這段RadMessageLocalizationProvider.CurrentProvider = new CustomRadMessageBoxLocalizationProvider();
            public override string GetLocalizedString(string id)
            {
                switch (id)
                {
                    case RadMessageStringID.YesButton:
                        return "檢視";
                    case RadMessageStringID.NoButton:
                        return "列印";
                    case RadMessageStringID.OKButton:
                        return "確認";
                    case RadMessageStringID.CancelButton:
                        return "離開";
                    case RadMessageStringID.RetryButton:
                        return "重試";
                    case RadMessageStringID.IgnoreButton:
                        return "忽略";
                    case RadMessageStringID.AbortButton:
                        return "放棄";
                    case RadMessageStringID.DetailsButton:
                        return "詳細資訊";
                    default:
                        return base.GetLocalizedString(id);
                }
                /*
                 
                 */
            }
        }

        /// <summary>
        /// 更改Button字詞
        /// </summary>
        public class ResetRadMessageBoxLocalizationProvider : RadMessageLocalizationProvider
        {
            //需加入這段RadMessageLocalizationProvider.CurrentProvider = new CustomRadMessageBoxLocalizationProvider();
            public override string GetLocalizedString(string id)
            {
                RadMessageBoxLocalizationText SetText = new RadMessageBoxLocalizationText();
                switch (id)
                {
                    case RadMessageStringID.YesButton:
                        return "是";
                    case RadMessageStringID.NoButton:
                        return "否";
                    case RadMessageStringID.OKButton:
                        return "確認";
                    case RadMessageStringID.CancelButton:
                        return "取消";
                    case RadMessageStringID.RetryButton:
                        return "重試";
                    case RadMessageStringID.IgnoreButton:
                        return "忽略";
                    case RadMessageStringID.AbortButton:
                        return "放棄";
                    case RadMessageStringID.DetailsButton:
                        return "詳細資訊";
                    default:
                        return base.GetLocalizedString(id);
                }
                /*
                    case RadMessageStringID.YesButton:
                        return "是";
                    case RadMessageStringID.NoButton:
                        return "否";
                    case RadMessageStringID.OKButton:
                        return "確認";
                    case RadMessageStringID.CancelButton:
                        return "取消";
                    case RadMessageStringID.RetryButton:
                        return "重試";
                    case RadMessageStringID.IgnoreButton:
                        return "忽略";
                    case RadMessageStringID.AbortButton:
                        return "放棄";
                    case RadMessageStringID.DetailsButton:
                        return "詳細資訊";
                 */
            }
        }
        /// <summary>
        /// RadTaskDialog Localization 
        /// </summary>
        public class ResetRadTaskDialogLocalizationProvider : RadTaskDialogLocalizationProvider
        {
            public override string GetLocalizedString(string id)
            {
                switch (id)
                {
                    case RadTaskDialogStringId.ExpanderCollapsedButtonText: return "顯示詳細資訊";
                    case RadTaskDialogStringId.ExpanderExpandedButtonText: return "隱藏詳細資訊";
                    case RadTaskDialogStringId.ContinueButtonText: return "繼續";
                    case RadTaskDialogStringId.TryAgainButtonText: return "再試一次";
                    case RadTaskDialogStringId.HelpButtonText: return "幫助";
                    case RadTaskDialogStringId.CloseButtonText: return "關閉";
                    case RadTaskDialogStringId.NoButtonText: return "否";
                    case RadTaskDialogStringId.YesButtonText: return "是";
                    case RadTaskDialogStringId.RetryButtonText: return "重試";
                    case RadTaskDialogStringId.AbortButtonText: return "中止";
                    case RadTaskDialogStringId.IgnoreButtonText: return "拒絕";
                    case RadTaskDialogStringId.OKButtonText: return "確定";
                    case RadTaskDialogStringId.CancelButtonText: return "取消";
                    default: return base.GetLocalizedString(id);
                }
            }
        }
        /// <summary>
        /// RadGridView 部分文字中文化
        /// RadGridLocalizationProvider.CurrentProvider = new RadGridLocalizationProvider_Taiwan();
        /// </summary>
        public class RadGridLocalizationProvider_Taiwan : RadGridLocalizationProvider
        {
            public override string GetLocalizedString(string id)
            {
                ///ReferralURL https://docs.telerik.com/devtools/winforms/controls/gridview/localization/localization
                switch (id)
                {
                    case RadGridStringId.ConditionalFormattingPleaseSelectValidCellValue: return "Please select valid cell value";
                    case RadGridStringId.ConditionalFormattingPleaseSetValidCellValue: return "Please set a valid cell value";
                    case RadGridStringId.ConditionalFormattingPleaseSetValidCellValues: return "Please set a valid cell values";
                    case RadGridStringId.ConditionalFormattingPleaseSetValidExpression: return "Please set a valid expression";
                    case RadGridStringId.ConditionalFormattingItem: return "Item";
                    case RadGridStringId.ConditionalFormattingInvalidParameters: return "Invalid parameters";
                    case RadGridStringId.FilterFunctionBetween: return "Between";
                    case RadGridStringId.FilterFunctionContains: return "Contains";
                    case RadGridStringId.FilterFunctionDoesNotContain: return "Does not contain";
                    case RadGridStringId.FilterFunctionEndsWith: return "Ends with";
                    case RadGridStringId.FilterFunctionEqualTo: return "Equals";
                    case RadGridStringId.FilterFunctionGreaterThan: return "Greater than";
                    case RadGridStringId.FilterFunctionGreaterThanOrEqualTo: return "Greater than or equal to";
                    case RadGridStringId.FilterFunctionIsEmpty: return "Is empty";
                    case RadGridStringId.FilterFunctionIsNull: return "Is null";
                    case RadGridStringId.FilterFunctionLessThan: return "Less than";
                    case RadGridStringId.FilterFunctionLessThanOrEqualTo: return "Less than or equal to";
                    case RadGridStringId.FilterFunctionNoFilter: return "No filter";
                    case RadGridStringId.FilterFunctionNotBetween: return "Not between";
                    case RadGridStringId.FilterFunctionNotEqualTo: return "Not equal to";
                    case RadGridStringId.FilterFunctionNotIsEmpty: return "Is not empty";
                    case RadGridStringId.FilterFunctionNotIsNull: return "Is not null";
                    case RadGridStringId.FilterFunctionStartsWith: return "Starts with";
                    case RadGridStringId.FilterFunctionCustom: return "Custom";
                    case RadGridStringId.FilterOperatorBetween: return "Between";
                    case RadGridStringId.FilterOperatorContains: return "Contains";
                    case RadGridStringId.FilterOperatorDoesNotContain: return "NotContains";
                    case RadGridStringId.FilterOperatorEndsWith: return "EndsWith";
                    case RadGridStringId.FilterOperatorEqualTo: return "Equals";
                    case RadGridStringId.FilterOperatorGreaterThan: return "GreaterThan";
                    case RadGridStringId.FilterOperatorGreaterThanOrEqualTo: return "GreaterThanOrEquals";
                    case RadGridStringId.FilterOperatorIsEmpty: return "IsEmpty";
                    case RadGridStringId.FilterOperatorIsNull: return "IsNull";
                    case RadGridStringId.FilterOperatorLessThan: return "LessThan";
                    case RadGridStringId.FilterOperatorLessThanOrEqualTo: return "LessThanOrEquals";
                    case RadGridStringId.FilterOperatorNoFilter: return "No filter";
                    case RadGridStringId.FilterOperatorNotBetween: return "NotBetween";
                    case RadGridStringId.FilterOperatorNotEqualTo: return "NotEquals";
                    case RadGridStringId.FilterOperatorNotIsEmpty: return "NotEmpty";
                    case RadGridStringId.FilterOperatorNotIsNull: return "NotNull";
                    case RadGridStringId.FilterOperatorStartsWith: return "StartsWith";
                    case RadGridStringId.FilterOperatorIsLike: return "Like";
                    case RadGridStringId.FilterOperatorNotIsLike: return "NotLike";
                    case RadGridStringId.FilterOperatorIsContainedIn: return "ContainedIn";
                    case RadGridStringId.FilterOperatorNotIsContainedIn: return "NotContainedIn";
                    case RadGridStringId.FilterOperatorCustom: return "Custom";
                    case RadGridStringId.CustomFilterMenuItem: return "Custom";
                    case RadGridStringId.CustomFilterDialogCaption: return "RadGridView Filter Dialog [{0}]";
                    case RadGridStringId.CustomFilterDialogLabel: return "Show rows where:";
                    case RadGridStringId.CustomFilterDialogRbAnd: return "And";
                    case RadGridStringId.CustomFilterDialogRbOr: return "Or";
                    case RadGridStringId.CustomFilterDialogBtnOk: return "OK";
                    case RadGridStringId.CustomFilterDialogBtnCancel: return "Cancel";
                    case RadGridStringId.CustomFilterDialogCheckBoxNot: return "Not";
                    case RadGridStringId.CustomFilterDialogTrue: return "True";
                    case RadGridStringId.CustomFilterDialogFalse: return "False";
                    case RadGridStringId.FilterMenuBlanks: return "Empty";
                    case RadGridStringId.FilterMenuAvailableFilters: return "Available Filters";
                    case RadGridStringId.FilterMenuSearchBoxText: return "Search...";
                    case RadGridStringId.FilterMenuClearFilters: return "Clear Filter";
                    case RadGridStringId.FilterMenuButtonOK: return "OK";
                    case RadGridStringId.FilterMenuButtonCancel: return "Cancel";
                    case RadGridStringId.FilterMenuSelectionAll: return "All";
                    case RadGridStringId.FilterMenuSelectionAllSearched: return "All Search Result";
                    case RadGridStringId.FilterMenuSelectionNull: return "Null";
                    case RadGridStringId.FilterMenuSelectionNotNull: return "Not Null";
                    case RadGridStringId.FilterFunctionSelectedDates: return "Filter by specific dates:";
                    case RadGridStringId.FilterFunctionToday: return "Today";
                    case RadGridStringId.FilterFunctionYesterday: return "Yesterday";
                    case RadGridStringId.FilterFunctionDuringLast7days: return "During last 7 days";
                    case RadGridStringId.FilterLogicalOperatorAnd: return "AND";
                    case RadGridStringId.FilterLogicalOperatorOr: return "OR";
                    case RadGridStringId.FilterCompositeNotOperator: return "NOT";
                    case RadGridStringId.DeleteRowMenuItem: return "刪除資料列";
                    case RadGridStringId.SortAscendingMenuItem: return "升序排序(Asc)";
                    case RadGridStringId.SortDescendingMenuItem: return "降序排序(Desc)";
                    case RadGridStringId.ClearSortingMenuItem: return "清除排序";
                    case RadGridStringId.ConditionalFormattingMenuItem: return "格式化條件";
                    case RadGridStringId.GroupByThisColumnMenuItem: return "按此欄位分組";
                    case RadGridStringId.UngroupThisColumn: return "取消此欄位的分組";
                    case RadGridStringId.ColumnChooserMenuItem: return "選擇欄位";
                    case RadGridStringId.HideMenuItem: return "隱藏欄位";
                    case RadGridStringId.HideGroupMenuItem: return "隱藏群組";
                    case RadGridStringId.UnpinMenuItem: return "取消訂選欄位";
                    case RadGridStringId.UnpinRowMenuItem: return "取消訂選橫列";
                    case RadGridStringId.PinMenuItem: return "訂選狀態";
                    case RadGridStringId.PinAtLeftMenuItem: return "靠左訂選";
                    case RadGridStringId.PinAtRightMenuItem: return "靠右訂選";
                    case RadGridStringId.PinAtBottomMenuItem: return "置底訂選";
                    case RadGridStringId.PinAtTopMenuItem: return "置頂訂選";
                    case RadGridStringId.BestFitMenuItem: return "自動調整";
                    case RadGridStringId.PasteMenuItem: return "貼上";
                    case RadGridStringId.EditMenuItem: return "編輯";
                    case RadGridStringId.ClearValueMenuItem: return "清除數值";
                    case RadGridStringId.CopyMenuItem: return "複製";
                    case RadGridStringId.CutMenuItem: return "剪下";
                    case RadGridStringId.AddNewRowString: return "點擊此來新增資料列";
                    case RadGridStringId.ConditionalFormattingSortAlphabetically: return "Sort columns alphabetically";
                    case RadGridStringId.ConditionalFormattingCaption: return "Conditional Formatting Rules Manager";
                    case RadGridStringId.ConditionalFormattingLblColumn: return "Format only cells with";
                    case RadGridStringId.ConditionalFormattingLblName: return "Rule name";
                    case RadGridStringId.ConditionalFormattingLblType: return "Cell value";
                    case RadGridStringId.ConditionalFormattingLblValue1: return "Value 1";
                    case RadGridStringId.ConditionalFormattingLblValue2: return "Value 2";
                    case RadGridStringId.ConditionalFormattingGrpConditions: return "Rules";
                    case RadGridStringId.ConditionalFormattingGrpProperties: return "Rule Properties";
                    case RadGridStringId.ConditionalFormattingChkApplyToRow: return "Apply this formatting to entire row";
                    case RadGridStringId.ConditionalFormattingChkApplyOnSelectedRows: return "Apply this formatting if the row is selected";
                    case RadGridStringId.ConditionalFormattingBtnAdd: return "Add new rule";
                    case RadGridStringId.ConditionalFormattingBtnRemove: return "Remove";
                    case RadGridStringId.ConditionalFormattingBtnOK: return "OK";
                    case RadGridStringId.ConditionalFormattingBtnCancel: return "Cancel";
                    case RadGridStringId.ConditionalFormattingBtnApply: return "Apply";
                    case RadGridStringId.ConditionalFormattingRuleAppliesOn: return "Rule applies to";
                    case RadGridStringId.ConditionalFormattingCondition: return "Condition";
                    case RadGridStringId.ConditionalFormattingExpression: return "Expression";
                    case RadGridStringId.ConditionalFormattingChooseOne: return "[Choose one]";
                    case RadGridStringId.ConditionalFormattingEqualsTo: return "equals to [Value1]";
                    case RadGridStringId.ConditionalFormattingIsNotEqualTo: return "is not equal to [Value1]";
                    case RadGridStringId.ConditionalFormattingStartsWith: return "starts with [Value1]";
                    case RadGridStringId.ConditionalFormattingEndsWith: return "ends with [Value1]";
                    case RadGridStringId.ConditionalFormattingContains: return "contains [Value1]";
                    case RadGridStringId.ConditionalFormattingDoesNotContain: return "does not contain [Value1]";
                    case RadGridStringId.ConditionalFormattingIsGreaterThan: return "is greater than [Value1]";
                    case RadGridStringId.ConditionalFormattingIsGreaterThanOrEqual: return "is greater than or equal [Value1]";
                    case RadGridStringId.ConditionalFormattingIsLessThan: return "is less than [Value1]";
                    case RadGridStringId.ConditionalFormattingIsLessThanOrEqual: return "is less than or equal to [Value1]";
                    case RadGridStringId.ConditionalFormattingIsBetween: return "is between [Value1] and [Value2]";
                    case RadGridStringId.ConditionalFormattingIsNotBetween: return "is not between [Value1] and [Value1]";
                    case RadGridStringId.ConditionalFormattingLblFormat: return "Format";
                    case RadGridStringId.ConditionalFormattingBtnExpression: return "Expression editor";
                    case RadGridStringId.ConditionalFormattingTextBoxExpression: return "Expression";
                    case RadGridStringId.ConditionalFormattingPropertyGridCaseSensitive: return "CaseSensitive";
                    case RadGridStringId.ConditionalFormattingPropertyGridCellBackColor: return "CellBackColor";
                    case RadGridStringId.ConditionalFormattingPropertyGridCellForeColor: return "CellForeColor";
                    case RadGridStringId.ConditionalFormattingPropertyGridEnabled: return "Enabled";
                    case RadGridStringId.ConditionalFormattingPropertyGridRowBackColor: return "RowBackColor";
                    case RadGridStringId.ConditionalFormattingPropertyGridRowForeColor: return "RowForeColor";
                    case RadGridStringId.ConditionalFormattingPropertyGridRowTextAlignment: return "RowTextAlignment";
                    case RadGridStringId.ConditionalFormattingPropertyGridTextAlignment: return "TextAlignment";
                    case RadGridStringId.ConditionalFormattingPropertyGridCellFont: return "My Cell Font";
                    case RadGridStringId.ConditionalFormattingPropertyGridCellFontDescription: return "My Font Description";
                    case RadGridStringId.ConditionalFormattingPropertyGridCaseSensitiveDescription: return "Determines whether case-sensitive comparisons will be made when evaluating string values.";
                    case RadGridStringId.ConditionalFormattingPropertyGridCellBackColorDescription: return "Enter the background color to be used for the cell.";
                }
                return base.GetLocalizedString(id);
            }
        }

        ///// <summary>
        ///// 滑鼠點擊視窗取得座標
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public static void Form_MouseDown(object sender, MouseEventArgs e)
        //{
        //    mouseOffset = new Point(-e.X, -e.Y);
        //}
        ///// <summary>
        ///// 滑鼠按住時候拖曳視窗
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public static void Form_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        Point mousePos = Control.MousePosition;
        //        mousePos.Offset(mouseOffset.X, mouseOffset.Y);
        //        ((Form)sender).Location = mousePos;
        //    }
        //}

        /// <summary>
        /// 檢查螢幕解析度
        /// </summary>
        /// <param name="LimitMonitorWidth">自定義限制最小螢幕寬度(預設1024)</param>
        /// <param name="LimitMonitorHeight">自定義限制最小螢幕高度(預設768)</param>
        /// <returns>ServiceResult.Message 錯誤訊息, IsOk:是否檢核通過</returns>
        public static ServiceResult<(int MonitorWidth,int MonitorHeight)> CheckMonitorSize(int LimitMonitorWidth = 1024, int LimitMonitorHeight = 768, bool ShowMessageBox = true)
        {
            ServiceResult<(int MonitorWidth, int MonitorHeight)> returnResult = new ServiceResult<(int MonitorWidth, int MonitorHeight)>(false, string.Empty, (0,0));
            try
            {
                int MonitorWidth = SystemInformation.PrimaryMonitorSize.Width;      //抓當下系統的螢幕解析度寬
                int MonitorHeight = SystemInformation.PrimaryMonitorSize.Height;    //抓當下系統的螢幕解析度長
                returnResult.Data = (MonitorWidth, MonitorHeight);
                if (LimitMonitorHeight > 0 && LimitMonitorWidth > 0)
                {
                    if (MonitorWidth < LimitMonitorWidth || MonitorHeight < LimitMonitorHeight)
                    {
                        var displayText = $"您目前螢幕解析度為{MonitorWidth}*{MonitorHeight}設定值太低" + Environment.NewLine +
                                          $"導致可能會無法正確顯示表單，建議該改為{LimitMonitorWidth}*{LimitMonitorHeight}以上，以達到最佳解析度!" + Environment.NewLine;
                        if (ShowMessageBox)
                        {
                            RadMessageBox.Show(displayText, "螢幕解析度過低警告", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        }
                        returnResult.Message = displayText;
                    }
                    else
                    {
                        returnResult.IsOk = true;
                        returnResult.Message = "螢幕解析度檢核通過!";
                    }
                }
                else
                {
                    returnResult.Message = "輸入之檢核解析度長寬不可小於 0 !";
                }
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message += "THROW" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            return returnResult;
        }


        /// <summary>
        /// 執行時間計算
        /// </summary>
        /// <param name="Start">(TimeSpan)開始</param>
        /// <param name="End">(TimeSpan)結束</param>
        /// <param name="DisplayConsoleStr">是否在Console顯示</param>
        /// <param name="DisplayTitle">是否顯示標題? 格式:[標題],執行時間:[回傳時間]</param>
        /// <returns></returns>
        public static string TimeDifferent(TimeSpan Start, TimeSpan End, bool DisplayConsoleStr = false, string DisplayTitle = "")
        {
            string dateDiff = null;
            TimeSpan ts_Start = new TimeSpan(Start.Ticks);
            TimeSpan ts_End = new TimeSpan(End.Ticks);
            TimeSpan ts_Shift = ts_Start.Subtract(ts_End).Duration();
            dateDiff = (ts_Shift.Hours != 0 ? ts_Shift.Hours.ToString() + "小時" : "") + (ts_Shift.Minutes != 0 ? ts_Shift.Minutes.ToString() + "分" : "") + (ts_Shift.Seconds != 0 ? ts_Shift.Seconds.ToString() + "秒" : "") + (ts_Shift.Milliseconds != 0 ? ts_Shift.Milliseconds.ToString() + "毫秒." : "0毫秒") + "." + Environment.NewLine;
            if (DisplayConsoleStr)
            {
                Console.WriteLine(DisplayTitle + dateDiff);
            }
            return DisplayTitle + ",執行時間:" + dateDiff;
        }
        //TimeSpan tsStart, tsEnd;
        //tsStart = TimeSpan.FromTicks(DateTime.Now.Ticks);
        //tsEnd = TimeSpan.FromTicks(DateTime.Now.Ticks);
        //RadMessageBox.Show($"SQL 執行秒數:{TimeDifferent(tsStart, tsEnd)}", "sysTime");
        //Console.WriteLine($"Detail SQL 執行秒數:{TimeDifferent(tsStart, tsEnd)}.");


        #endregion Utility Tool

        #region DropDownList Utility
        /// <summary>
        /// DropDownList設定檔
        /// </summary>
        public class DropDownListSettings
        {
            /// <summary>
            /// 點擊下拉按鈕的一般下拉選單 DisplayMember
            /// </summary>
            public string DisplayMember { get; set; } = "DISPLAYTEXT";
            /// <summary>
            /// 點擊下拉按鈕的一般下拉選單 ValueMember
            /// </summary>
            public string ValueMember { get; set; } = "VALUE";
            /// <summary>
            /// 忽略大小寫
            /// </summary>
            public bool CaseSensitive { get; set; } = false;
            /// <summary>
            /// 自動完成模式
            /// </summary>
            public AutoCompleteMode autoCompleteMode { get; set; } = AutoCompleteMode.SuggestAppend;
            /// <summary>
            /// 自動完成下拉選單 DisplayMember
            /// </summary>
            public string AutoCompleteDisplayMember { get; set; } = "DISPLAYTEXT";
            /// <summary>
            /// 自動完成下拉選單 ValueMember
            /// </summary>
            public string AutoCompleteValueMember { get; set; } = "VALUE";
            /// <summary>
            /// 項目間距
            /// </summary>
            public int ItemHeight { get; set; } = 28;
            /// <summary>
            /// 預設下拉選單數量(超過會出現滾動條) 預設10
            /// </summary>
            public int DefaultItemsCountInDropDown { get; set; } = 10;
            /// <summary>
            /// 下拉選單寬度
            /// </summary>
            public int DropDownWidth { get; set; } = 500;
            /// <summary>
            /// 是否啟用自動完成
            /// </summary>
            public bool AutoCompleteFlag { get; set; } = true;
            /// <summary>
            /// 是否於下拉選單中插入空值(預設False)
            /// </summary>
            public bool InsertEmptyData { get; set; } = false;
            /// <summary>
            /// 是否於綁定DataSource後預設選擇空值(預設True)
            /// </summary>
            public bool SelectedEmpty { get; set; } = true;

            /// <summary>
            /// 下拉選單數量(超過會出現滾動條) 預設10
            /// </summary>
            public int DropDownItemCount { get; set; } = 10;
            /// <summary>
            /// 輸入模式
            /// </summary>
            public RadDropDownStyle DropDownStyle { get; set; } = RadDropDownStyle.DropDown;
            /// <summary>
            /// 顯示模式Event
            /// </summary>
            public VisualListItemFormattingEventHandler VisualItemFormattingEvent { get; set; }
            /// <summary>
            /// 當顯示模式Event 為Null 時候使用預設Event(預設False)
            /// </summary>
            public bool WhenVisualItemFormattingEventIsNullUseDefaultEvent { get; set; } = true;
            /// <summary>
            /// 自動完成Helper Override
            /// </summary>
            public AutoCompleteSuggestHelper autoCompleteSuggestHelper { get; set; }
            /// <summary>
            /// 下拉選單預設最大ITEM數量(預設10列)
            /// </summary>
            public int MaxDropDownItems { get; set; } = 10;
            /// <summary>
            /// 是否可以調整下拉選單邊框大小
            /// </summary>
            public SizingMode DropDownSizingMode { get; set; } = SizingMode.None;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rddl"></param>
        /// <param name="modelList"></param>
        /// <param name="dropDownListSettings"></param>
        public static ServiceResult DropDownListSet<T>(RadDropDownList rddl, IEnumerable<T> modelList, DropDownListSettings dropDownListSettings = null)
            where T : class, new()
        {
            ServiceResult returnResult = new ServiceResult(false, string.Empty);
            try
            {

                if (rddl == null)
                {
                    returnResult.Message = $"{nameof(RadDropDownList)} 元件不可為Null!" + Environment.NewLine;
                }
                if (modelList == null)
                {
                    returnResult.Message = $"{nameof(IEnumerable)} 資料物件不可為Null!" + Environment.NewLine;
                }
                if (!string.IsNullOrWhiteSpace(returnResult.Message))
                {
                    return returnResult;
                }

                if (dropDownListSettings == null)
                {
                    returnResult.Message = $"下拉選單設定檔未提供，使用預設設定值" + Environment.NewLine;
                }
                DropDownListSettings dropDownListSetting = new DropDownListSettings();
                if (dropDownListSettings != null)
                {
                    dropDownListSetting = dropDownListSettings;
                }

                var element = rddl.DropDownListElement;
                var listElement = element.ListElement;


                rddl.DisplayMember = dropDownListSetting.DisplayMember;
                rddl.ValueMember = dropDownListSetting.ValueMember;
                if (dropDownListSetting.AutoCompleteFlag)
                {
                    rddl.AutoCompleteMode = dropDownListSetting.autoCompleteMode;
                    rddl.AutoCompleteDisplayMember = dropDownListSetting.AutoCompleteDisplayMember;
                    rddl.AutoCompleteValueMember = dropDownListSetting.AutoCompleteValueMember;
                }
                var dataList = modelList?.ToList() ?? new List<T>();
                if (dropDownListSetting.InsertEmptyData)
                {
                    dataList.Insert(0, new T());
                }
                rddl.DataSource = dataList;
                rddl.DropDownStyle = dropDownListSetting.DropDownStyle;
                rddl.CaseSensitive = dropDownListSetting.CaseSensitive;
                if (dropDownListSetting.AutoCompleteFlag)
                {
                    rddl.DropDownListElement.AutoCompleteMode = dropDownListSetting.autoCompleteMode;
                    rddl.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
                    rddl.DropDownListElement.AutoCompleteSuggest.DropDownList.AutoCompleteMode = dropDownListSetting.autoCompleteMode;
                    rddl.DropDownListElement.AutoCompleteSuggest.DropDownList.DisplayMember = dropDownListSetting.AutoCompleteDisplayMember;
                    rddl.DropDownListElement.AutoCompleteSuggest.DropDownList.ValueMember = dropDownListSetting.AutoCompleteValueMember;
                    rddl.DropDownListElement.AutoCompleteSuggest.DropDownList.ItemHeight = dropDownListSetting.ItemHeight;
                    rddl.DropDownListElement.AutoCompleteSuggest.DropDownList.DefaultItemsCountInDropDown = dropDownListSetting.DefaultItemsCountInDropDown;
                    rddl.DropDownListElement.AutoCompleteSuggest.DropDownList.DropDownSizingMode = dropDownListSetting.DropDownSizingMode;
                    rddl.DropDownListElement.AutoCompleteSuggest.DropDownList.DropDownWidth = dropDownListSetting.DropDownWidth;
                    if (dropDownListSetting.autoCompleteSuggestHelper != null)
                    {
                        rddl.DropDownListElement.AutoCompleteSuggest = dropDownListSetting.autoCompleteSuggestHelper;
                        //new ContainAutoCompleteSuggestHelper(rddl.DropDownListElement, 10, rddl.ItemHeight,// rddl.DropDownListElement.DropDownWidth);
                    }
                }

                rddl.DropDownListElement.ListElement.ItemHeight = dropDownListSetting.ItemHeight;
                rddl.DropDownListElement.DefaultItemsCountInDropDown = dropDownListSetting.DefaultItemsCountInDropDown;
                rddl.DropDownListElement.DropDownWidth = dropDownListSetting.DropDownWidth;


                if (dropDownListSetting.VisualItemFormattingEvent != null)
                {
                    rddl.DropDownListElement.VisualItemFormatting -= dropDownListSetting.VisualItemFormattingEvent;
                    rddl.ListElement.VisualItemFormatting -= dropDownListSetting.VisualItemFormattingEvent;
                    rddl.DropDownListElement.VisualItemFormatting += dropDownListSetting.VisualItemFormattingEvent;
                    rddl.ListElement.VisualItemFormatting += dropDownListSetting.VisualItemFormattingEvent;
                    if (dropDownListSetting.AutoCompleteFlag)
                    {
                        rddl.DropDownListElement.AutoCompleteSuggest.DropDownList.VisualItemFormatting -= dropDownListSetting.VisualItemFormattingEvent;
                        rddl.DropDownListElement.AutoCompleteSuggest.DropDownList.VisualItemFormatting += dropDownListSetting.VisualItemFormattingEvent;
                    }
                }
                else if (dropDownListSetting.WhenVisualItemFormattingEventIsNullUseDefaultEvent)
                {
                    rddl.DropDownListElement.VisualItemFormatting -= RadDropDownListElemet_VisulItemFormatting;
                    rddl.ListElement.VisualItemFormatting -= RadDropDownListElemet_VisulItemFormatting;
                    rddl.DropDownListElement.VisualItemFormatting += RadDropDownListElemet_VisulItemFormatting;
                    rddl.ListElement.VisualItemFormatting += RadDropDownListElemet_VisulItemFormatting;
                    if (dropDownListSetting.AutoCompleteFlag)
                    {
                        rddl.DropDownListElement.AutoCompleteSuggest.DropDownList.VisualItemFormatting -= RadDropDownListElemet_VisulItemFormatting;
                        rddl.DropDownListElement.AutoCompleteSuggest.DropDownList.VisualItemFormatting += RadDropDownListElemet_VisulItemFormatting;
                    }
                }
                rddl.DefaultItemsCountInDropDown = dropDownListSetting.DefaultItemsCountInDropDown;
                rddl.MaxDropDownItems = dropDownListSetting.MaxDropDownItems;
                rddl.DropDownSizingMode = dropDownListSetting.DropDownSizingMode;
                if (dropDownListSetting.SelectedEmpty)
                {
                    //rddl.SelectedValue = string.Empty;
                    rddl.SelectedIndex = dropDownListSetting.InsertEmptyData ? 0 : -1;
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message = "THROW:" + ex.GetInnerException().ErrorMessage;
            }
            return returnResult;
        }
        private static void RadDropDownListElemet_VisulItemFormatting(object sender, VisualItemFormattingEventArgs e)
        {
            e.VisualItem.Font = CoreBaseFontsProxy.GetFont(CoreBaseFontsProxy.PresetFonts.YaHeiConsolasHybrid);
            e.VisualItem.ToolTipText = e.VisualItem.Text;
            if (e.VisualItem.Selected)
            {
                e.VisualItem.NumberOfColors = 1;
                e.VisualItem.BackColor = Color.OldLace;
                e.VisualItem.BorderColor = Color.RoyalBlue;
            }
            else
            {
                e.VisualItem.ResetValue(LightVisualElement.NumberOfColorsProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.VisualItem.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.VisualItem.ResetValue(LightVisualElement.BorderColorProperty, Telerik.WinControls.ValueResetFlags.Local);
            }

        }

        /// <summary>
        /// 下拉選單設定
        /// </summary>
        /// <param name="modelList">List資料</param>
        /// <param name="ddl">下拉選單元件</param>
        /// <param name="autoCompleteFlag">是否Auto-Complete +FontSize 13f</param>
        /// <param name="selectEmpty">預設選擇空值</param>
        /// <param name="insertEmptyData">modelList是否塞入空值</param>
        /// <param name="DropDownItemCount">下拉選單數量</param>
        /// <param name="DropDownStyle">下拉選單風格(是否可編輯)</param>
        public static void DropDownListSet<T>(List<T> modelList, RadDropDownList ddl, bool autoCompleteFlag, bool selectEmpty
            , bool insertEmptyData, int DropDownItemCount = 10, RadDropDownStyle DropDownStyle = RadDropDownStyle.DropDown)
        {
            if (insertEmptyData)
            {
                modelList.Insert(0, default);
            }
            ddl.DisplayMember = "DISPLAYTEXT";
            ddl.ValueMember = "VALUE";
            ddl.DataSource = modelList;
            //DropDownList From Arrow Button
            ddl.DropDownListElement.DropDownStyle = DropDownStyle;
            ddl.DropDownListElement.DropDownSizingMode = SizingMode.UpDown;
            ddl.DropDownListElement.ListElement.ItemHeight = 25;
            ddl.DropDownListElement.DefaultItemsCountInDropDown = DropDownItemCount;       //預設下拉選單數量
            //ddl.DropDownListElement.DropDownHeight = DropDownItemCount * (ddl.Font.Height + 8);       //下拉選單高
            ddl.DropDownListElement.ListElement.VisualItemFormatting += ListElemet_VisulItemFormatting;  //按鈕下拉選單
            if (autoCompleteFlag)
            {
                ddl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //ddl.DropDownSizingMode = SizingMode.UpDown;

                ddl.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

                ddl.DropDownListElement.AutoCompleteSuggest.DropDownList.ItemHeight = 25;

                ddl.DropDownListElement.AutoCompleteSuggest.DropDownList.DefaultItemsCountInDropDown = DropDownItemCount;

                //ddl.DropDownListElement.AutoCompleteSuggest.DropDownList.DropDownHeight = DropDownItemCount * (ddl.Font.Height + 8);

                ddl.DropDownListElement.AutoCompleteSuggest.DropDownList.DropDownSizingMode = SizingMode.UpDown;

                ddl.DropDownListElement.AutoCompleteSuggest.DropDownList.VisualItemFormatting += ListElemet_VisulItemFormatting;    //自動完成下拉

            }
            if (selectEmpty)
            {
                ddl.SelectedValue = "";

            }
        }
        private static void ListElemet_VisulItemFormatting(object sender, VisualItemFormattingEventArgs e)
        {
            e.VisualItem.Font = SetFontSize(12f);
            e.VisualItem.ToolTipText = e.VisualItem.Text;
            if (e.VisualItem.Selected)
            {
                e.VisualItem.NumberOfColors = 1;
                e.VisualItem.BackColor = Color.Yellow;
                e.VisualItem.BorderColor = Color.Blue;
            }
            else
            {
                e.VisualItem.ResetValue(LightVisualElement.NumberOfColorsProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.VisualItem.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.VisualItem.ResetValue(LightVisualElement.BorderColorProperty, Telerik.WinControls.ValueResetFlags.Local);
            }

        }

        #endregion

        #region Program Create RadTextBox Input Form
        /// <summary>
        /// 建立輸入視窗
        /// </summary>
        /// <param name="Password">密碼(正確回傳True,否則False)</param>
        /// <param name="FormTitleBarText">視窗標題文字</param>
        /// <param name="FormTitleBarIcon">視窗標題ICON</param>
        /// <param name="RadTextBoxTitleLabel">輸入框左側顯示之文字(會自動調整寬度)</param>
        /// <param name="IsInputTextBoxHasPasswordChar">輸入密碼框是否進行遮罩(預設True)</param>
        /// <param name="FormSize">視窗大小[長與寬皆需大於Size(280,76)才會進行調整]</param>
        /// <returns></returns>
        public static bool CreatePasswordRadTextBoxForm(string Password
            , string FormTitleBarText = null
            , Icon FormTitleBarIcon = null
            , string RadTextBoxTitleLabel = null
            , bool IsInputTextBoxHasPasswordChar = true
            , Size? FormSize = null)
        {
            try
            {
                return CreatePasswordRadTextBoxForm_Logic(Password, FormTitleBarText, FormTitleBarIcon, RadTextBoxTitleLabel, IsInputTextBoxHasPasswordChar, FormSize).IsOk;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 建立輸入視窗
        /// </summary>
        /// <param name="Password">密碼(正確回傳True,否則False)</param>
        /// <param name="FormTitleBarText">視窗標題文字</param>
        /// <param name="FormTitleBarIcon">視窗標題ICON</param>
        /// <param name="RadTextBoxTitleLabel">輸入框左側顯示之文字(會自動調整寬度)</param>
        /// <param name="IsInputTextBoxHasPasswordChar">輸入密碼框是否進行遮罩(預設True)</param>
        /// <param name="FormSize">視窗大小[長與寬皆需大於Size(280,76)才會進行調整]</param>
        /// <returns></returns>
        public static ServiceResult<string> CreatePasswordRadTextBoxFormResult(string Password
            , string FormTitleBarText = null
            , Icon FormTitleBarIcon = null
            , string RadTextBoxTitleLabel = null
            , bool IsInputTextBoxHasPasswordChar = true
            , Size? FormSize = null)
        {
            try
            {
                return CreatePasswordRadTextBoxForm_Logic(Password, FormTitleBarText, FormTitleBarIcon, RadTextBoxTitleLabel, IsInputTextBoxHasPasswordChar, FormSize);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 建立輸入視窗
        /// </summary>
        /// <param name="PasswordList">密碼陣列(正確回傳True,否則False)</param>
        /// <param name="FormTitleBarText">視窗標題文字</param>
        /// <param name="FormTitleBarIcon">視窗標題ICON</param>
        /// <param name="RadTextBoxTitleLabel">輸入框左側顯示之文字(會自動調整寬度)</param>
        /// <param name="IsInputTextBoxHasPasswordChar">輸入密碼框是否進行遮罩(預設True)</param>
        /// <param name="FormSize">視窗大小[長與寬皆需大於Size(280,76)才會進行調整]</param>
        /// <returns></returns>
        public static bool CreatePasswordRadTextBoxForm(List<string> PasswordList
            , string FormTitleBarText = null
            , Icon FormTitleBarIcon = null
            , string RadTextBoxTitleLabel = null
            , bool IsInputTextBoxHasPasswordChar = true
            , Size? FormSize = null)
        {
            try
            {
                return CreatePasswordRadTextBoxForm_Logic(PasswordList, FormTitleBarText, FormTitleBarIcon, RadTextBoxTitleLabel, IsInputTextBoxHasPasswordChar, FormSize).IsOk;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 建立輸入視窗
        /// </summary>
        /// <param name="PasswordList">密碼陣列(正確回傳True,否則False)</param>
        /// <param name="FormTitleBarText">視窗標題文字</param>
        /// <param name="FormTitleBarIcon">視窗標題ICON</param>
        /// <param name="RadTextBoxTitleLabel">輸入框左側顯示之文字(會自動調整寬度)</param>
        /// <param name="IsInputTextBoxHasPasswordChar">輸入密碼框是否進行遮罩(預設True)</param>
        /// <param name="FormSize">視窗大小[長與寬皆需大於Size(280,76)才會進行調整]</param>
        /// <returns></returns>
        public static ServiceResult<string> CreatePasswordRadTextBoxFormResult(List<string> PasswordList
            , string FormTitleBarText = null
            , Icon FormTitleBarIcon = null
            , string RadTextBoxTitleLabel = null
            , bool IsInputTextBoxHasPasswordChar = true
            , Size? FormSize = null)
        {
            try
            {
                return CreatePasswordRadTextBoxForm_Logic(PasswordList, FormTitleBarText, FormTitleBarIcon, RadTextBoxTitleLabel, IsInputTextBoxHasPasswordChar, FormSize);
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 建立輸入視窗
        /// </summary>
        /// <param name="Password">密碼(正確回傳True,否則False)</param>
        /// <param name="FormTitleBarText">視窗標題文字</param>
        /// <param name="FormTitleBarIcon">視窗標題ICON</param>
        /// <param name="RadTextBoxTitleLabel">輸入框左側顯示之文字(會自動調整寬度)</param>
        /// <param name="IsInputTextBoxHasPasswordChar">輸入密碼框是否進行遮罩(預設True)</param>
        /// <param name="FormSize">視窗大小[長與寬皆需大於Size(280,76)才會進行調整]</param>
        /// <returns></returns>
        public static ServiceResult<string> CreatePasswordRadTextBoxForm_Logic(object Password
            , string FormTitleBarText = null
            , Icon FormTitleBarIcon = null
            , string RadTextBoxTitleLabel = null
            , bool IsInputTextBoxHasPasswordChar = true
            , Size? FormSize = null)
        {
            ServiceResult<string> ReturnResult = new ServiceResult<string>(false, 0, string.Empty, string.Empty);
            try
            {
                List<string> _PasswordList = new List<string>();
                string _Password = string.Empty;
                if (Password != null && Password is List<string> _passwordList && _passwordList?.Any() is true)
                {
                    _PasswordList = _passwordList;
                }
                else if (Password is string _password)
                {
                    if (string.IsNullOrEmpty(_password) == false)
                    {
                        _Password = _password;
                    }
                }
                else
                {
                    ReturnResult.Message += "密碼陣列物件傳遞錯誤";
                    return ReturnResult;
                }
                //var ReutrnResult = false;
                RadForm VerifyCodeForm = new RadForm
                {
                    Name =nameof(VerifyCodeForm),
                    StartPosition = FormStartPosition.CenterScreen,
                    Text = "密碼輸入視窗",
                    ThemeName = "Fluent",
                    Font = SetFontSize(11f),
                    ImeMode = ImeMode.Disable
                };
                if (FormTitleBarIcon != null)
                {
                    VerifyCodeForm.Icon = FormTitleBarIcon;
                }
                if (!string.IsNullOrWhiteSpace(FormTitleBarText))
                {
                    VerifyCodeForm.Text = FormTitleBarText;
                }
                RadLabel radLabelTitle = new RadLabel()
                {
                    Name = nameof(radLabelTitle),
                    Text = "密碼:",
                    Font = SetFontSize(13f),
                    Dock = DockStyle.Fill,
                    Anchor = AnchorStyles.Right,
                    TextAlignment = ContentAlignment.MiddleCenter,
                };
                var PW_LENGTH = 10;
                if (_PasswordList.Any())
                {
                    PW_LENGTH += _PasswordList.Max(x => x.Length);
                }
                else
                {
                    PW_LENGTH += _Password.Length;
                }

                RadTextBoxControl radTextBoxControlPassword = new RadTextBoxControl()
                {
                    Name = nameof(radTextBoxControlPassword),
                    Font = SetFontSize(16f),
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    //PasswordChar = '*',
                    BackColor = Color.Black,
                    ForeColor = Color.LightGreen,
                    MaxLength = PW_LENGTH,
                };
                if (IsInputTextBoxHasPasswordChar)
                {
                    radTextBoxControlPassword.PasswordChar = '*';
                }
                //rlbTitle.MouseDoubleClick += (sender, e) =>
                //{
                //    rtbc_TEST_FUNCTION.PasswordChar = rtbc_TEST_FUNCTION.PasswordChar == '*' ? char.MinValue : '*';
                //};
                radTextBoxControlPassword.KeyDown += (sender, e) =>
                {
                    try
                    {
                        if (sender is RadTextBoxControl rtbc)
                        {
                            if (e.KeyCode == Keys.Enter)
                            {
                                if (!string.IsNullOrEmpty(rtbc.Text))
                                {
                                    if (_PasswordList?.Any() is true)
                                    {
                                        if (_PasswordList.Any(x => rtbc.Text == x))
                                        {
                                            ReturnResult.IsOk = true;
                                            ReturnResult.Code = 1;
                                            //ReturnResult.Data = rtbc.Text;
                                        }
                                    }
                                    else
                                    {
                                        if (rtbc.Text == _Password)
                                        {
                                            ReturnResult.IsOk = true;
                                            ReturnResult.Code = 2;
                                            //ReturnResult.Data = rtbc.Text;
                                        }
                                    }
                                    ReturnResult.Data = rtbc.Text;
                                }
                                if(rtbc.Parent is TableLayoutPanel tlp)
                                {
                                    if (tlp.Parent is RadForm form)
                                    {
                                        form.Close();
                                    }
                                }
                                //((RadForm)((TableLayoutPanel)((RadTextBoxControl)sender).Parent).Parent).Close();
                            }
                            else if (e.KeyCode == Keys.Escape)
                            {
                                ReturnResult.Message += "使用者手動Esc關閉視窗";
                                ReturnResult.IsOk = false;
                                ReturnResult.Code = 0;
                                ReturnResult.Data = rtbc.Text;
                                if (rtbc.Parent is TableLayoutPanel tlp)
                                {
                                    if (tlp.Parent is RadForm form)
                                    {
                                        form.Close();
                                    }
                                }
                                //((RadForm)((TableLayoutPanel)((RadTextBoxControl)sender).Parent).Parent).Close();
                            }
                        }
                    }
                    catch
                    {
                        throw;
                    }
                };
                TableLayoutPanel _tableLayout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    BackColor = SystemColors.ControlLight
                };
                //_tableLayout.Controls.Clear();
                //_tableLayout.RowStyles.Clear();
                //_tableLayout.ColumnStyles.Clear();

                var textSize = new Size(58, 30);
                if (!string.IsNullOrWhiteSpace(RadTextBoxTitleLabel))
                {
                    radLabelTitle.Text = RadTextBoxTitleLabel;
                    textSize = TextRenderer.MeasureText(RadTextBoxTitleLabel + " ", SetFontSize(13f));
                }

                _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, textSize.Width + 30));
                _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                _tableLayout.ColumnCount = _tableLayout.ColumnStyles.Count;

                _tableLayout.Controls.Add(radLabelTitle);
                _tableLayout.SetCellPosition(radLabelTitle, new TableLayoutPanelCellPosition(0, 0));

                _tableLayout.Controls.Add(radTextBoxControlPassword);
                _tableLayout.SetCellPosition(radTextBoxControlPassword, new TableLayoutPanelCellPosition(1, 0));

                Size debugFormSize = new Size(280, 76);
                if (FormSize != null && FormSize.Value.Width >= debugFormSize.Width && FormSize.Value.Height >= debugFormSize.Height)
                {
                    if ((textSize.Width + 200) > FormSize.Value.Width)
                    {
                        var NewSize = (Size)FormSize;
                        NewSize.Width = (textSize.Width + 10 + 200);
                        debugFormSize = NewSize;
                    }
                    else
                    {
                        debugFormSize = (Size)FormSize;
                    }
                }
                else
                {
                    if ((textSize.Width + 200) > debugFormSize.Width)
                    {
                        var NewSize = (Size)debugFormSize;
                        NewSize.Width = (textSize.Width + 200);
                        debugFormSize = NewSize;
                    }
                }
                VerifyCodeForm.Size = debugFormSize;
                VerifyCodeForm.MaximumSize = debugFormSize;
                VerifyCodeForm.MinimumSize = debugFormSize;

                VerifyCodeForm.Controls.Add(_tableLayout);
                VerifyCodeForm.StartPosition = FormStartPosition.CenterScreen;
                VerifyCodeForm.TopLevel = true;
                VerifyCodeForm.ShowDialog();
                return ReturnResult;
                //((RadForm)((TableLayoutPanel)((RadButton)sender).Parent).Parent).Close();
            }
            catch
            {
                throw;
            }
        }
        ///// <summary>
        ///// 建立輸入視窗
        ///// </summary>
        ///// <param name="Password">是否顯示預設文字</param>
        ///// <param name="FormTitleBarText">視窗標題文字</param>
        ///// <param name="FormTitleBarIcon">視窗標題ICON</param>
        ///// <param name="RadTextBoxTitleLabel">輸入框左側顯示之文字(會自動調整寬度)</param>
        ///// <param name="IsInputTextBoxHasPasswordChar">輸入密碼框是否進行遮罩(預設False)</param>
        ///// <param name="FormSize">視窗大小[長與寬皆需大於Size(280,76)才會進行調整]</param>
        ///// <returns></returns>
        //public string CreateRadTextBoxForm(string DefaultString = null
        //    , string FormTitleBarText = null
        //    , Icon FormTitleBarIcon = null
        //    , string RadTextBoxTitleLabel = null
        //    , bool IsInputTextBoxHasPasswordChar = false
        //    , Size? FormSize = null)
        //{
        //    //回傳輸入之文字
        //    var ReturnResult = string.Empty;
        //    try
        //    {
        //        var RTBC_ShowNullString = false;
        //        if (!string.IsNullOrWhiteSpace(DefaultString))
        //        {
        //            RTBC_ShowNullString = true;
        //        }
        //        RadForm DebugForm = new RadForm
        //        {
        //            StartPosition = FormStartPosition.CenterScreen,
        //            Text = "輸入視窗",
        //            ThemeName = "Fluent",
        //            Font = SetFontSize(12f),
        //            ImeMode = ImeMode.Disable
        //        };
        //        if (FormTitleBarIcon != null)
        //        {
        //            DebugForm.Icon = FormTitleBarIcon;
        //        }
        //        if (!string.IsNullOrWhiteSpace(FormTitleBarText))
        //        {
        //            DebugForm.Text = FormTitleBarText;
        //        }
        //        RadLabel rlbTitle = new RadLabel()
        //        {
        //            Name = "INPUT_TITLE",
        //            Text = "輸入:",
        //            Font = SetFontSize(13f),
        //            Dock = DockStyle.Fill,
        //            Anchor = AnchorStyles.Right,
        //            TextAlignment = ContentAlignment.MiddleCenter,
        //        };

        //        RadTextBoxControl rtbc_TEST_FUNCTION = new RadTextBoxControl()
        //        {
        //            Name = "INPUT",
        //            Font = SetFontSize(16f),
        //            Dock = DockStyle.Fill,
        //            AutoSize = true,
        //            //PasswordChar = '*',
        //            BackColor = Color.Black,
        //            ForeColor = Color.LightGreen,
        //            NullText = DefaultString ?? string.Empty,
        //            ShowNullText = RTBC_ShowNullString
        //        };
        //        if (IsInputTextBoxHasPasswordChar)
        //        {
        //            rtbc_TEST_FUNCTION.PasswordChar = '*';
        //        }
        //        rtbc_TEST_FUNCTION.KeyDown += (sender, e) =>
        //        {
        //            try
        //            {
        //                if (e.KeyCode == Keys.Enter)
        //                {
        //                    if (sender is RadTextBoxControl rtbc && !string.IsNullOrEmpty(rtbc.Text))
        //                    {
        //                        ReturnResult = rtbc.Text;
        //                    }
        //                    ((RadForm)((TableLayoutPanel)((RadTextBoxControl)sender).Parent).Parent).Close();
        //                }
        //                else if (e.KeyCode == Keys.Escape)
        //                {
        //                    ReturnResult = string.Empty;
        //                    ((RadForm)((TableLayoutPanel)((RadTextBoxControl)sender).Parent).Parent).Close();
        //                }
        //            }
        //            catch
        //            {
        //                throw;
        //            }
        //        };
        //        TableLayoutPanel _tableLayout = new TableLayoutPanel
        //        {
        //            Dock = DockStyle.Fill,
        //            BackColor = SystemColors.ControlLight
        //        };
        //        _tableLayout.Controls.Clear();
        //        _tableLayout.RowStyles.Clear();
        //        _tableLayout.ColumnStyles.Clear();

        //        var textSize = new Size(58, 30);
        //        if (!string.IsNullOrWhiteSpace(RadTextBoxTitleLabel))
        //        {
        //            rlbTitle.Text = RadTextBoxTitleLabel;
        //            textSize = TextRenderer.MeasureText(RadTextBoxTitleLabel + "", SetFontSize(13f));
        //        }

        //        _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, textSize.Width));
        //        _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        //        _tableLayout.ColumnCount = 2;

        //        _tableLayout.Controls.Add(rlbTitle);
        //        _tableLayout.SetCellPosition(rlbTitle, new TableLayoutPanelCellPosition(0, 0));

        //        _tableLayout.Controls.Add(rtbc_TEST_FUNCTION);
        //        _tableLayout.SetCellPosition(rtbc_TEST_FUNCTION, new TableLayoutPanelCellPosition(1, 0));

        //        Size debugFormSize = new Size(280, 76);
        //        if (FormSize != null && FormSize.Value.Width >= debugFormSize.Width && FormSize.Value.Height >= debugFormSize.Height)
        //        {
        //            if ((textSize.Width + 200) > FormSize.Value.Width)
        //            {
        //                var NewSize = (Size)FormSize;
        //                NewSize.Width = (textSize.Width + 10 + 200);
        //                debugFormSize = NewSize;
        //            }
        //            else
        //            {
        //                debugFormSize = (Size)FormSize;
        //            }
        //        }
        //        else
        //        {
        //            if ((textSize.Width + 200) > debugFormSize.Width)
        //            {
        //                var NewSize = (Size)debugFormSize;
        //                NewSize.Width = (textSize.Width + 200);
        //                debugFormSize = NewSize;
        //            }
        //        }
        //        DebugForm.Size = debugFormSize;
        //        DebugForm.MaximumSize = debugFormSize;
        //        DebugForm.MinimumSize = debugFormSize;

        //        DebugForm.Controls.Add(_tableLayout);
        //        DebugForm.StartPosition = FormStartPosition.CenterScreen;
        //        DebugForm.TopLevel = true;
        //        DebugForm.ShowDialog();
        //        return ReturnResult;
        //        //((RadForm)((TableLayoutPanel)((RadButton)sender).Parent).Parent).Close();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        #endregion
    }


    #region FontProxy
    /// <summary>
    /// FontProxy
    /// </summary>
    public static class CoreBaseFontsProxy
    {
        /// <summary>
        /// 字型
        /// DisplayName="FontFamily Name", Display.Description="檔案名稱.ttf"
        /// </summary>
        public enum PresetFonts
        {
            /// <summary>
            /// Sarasa Fixed TC
            /// </summary>
            [Display(Name= "Sarasa Fixed TC", Description = "SarasaFixedTC-Regular.ttf")]
            [Description("Sarasa Fixed TC")]
            SarasaFixedTC_Regular,
            /// <summary>
            /// 更紗黑體 UI TC
            /// </summary>
            [Display(Name = "更紗黑體 UI TC", Description = "SarasaUiTC-Regular.ttf")]
            [Description("更紗黑體 UI TC")] 
            SarasaUiTC_Regular,
            /// <summary>
            /// 等距更紗黑體 TC
            /// </summary>
            [Display(Name = "等距更紗黑體 TC", Description = "SarasaMonoTC-Regular.ttf")]
            [Description("等距更紗黑體 TC")]
            SarasaMonoTC_Regular,
            /// <summary>
            /// YaHei Consolas Hybrid
            /// </summary>
            [Display(Name = "YaHei Consolas Hybrid", Description = "YaHeiConsolasHybrid.ttf")]
            [Description("YaHei Consolas Hybrid")] 
            YaHeiConsolasHybrid,
            /// <summary>
            /// Microsoft JhengHei UI
            /// </summary>
            [Display(Name = "Microsoft JhengHei UI", Description = "")]
            [Description("Microsoft JhengHei UI")]
            MicrosoftJhengHeiUI,
            /// <summary>
            /// Cascadia Mono (從 Fonts\CascaidaMono.ttf 載入的等寬字型)
            /// </summary>
            [Display(Name = "Cascadia Mono", Description = "CascadiaMono.ttf")]
            [Description("Cascadia Mono")]
            CascadiaMono,
        }

        /// <summary>
        /// Windows API
        /// </summary>
        /// <param name="pbFont"></param>
        /// <param name="cbFont"></param>
        /// <param name="pdv"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceExW", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int AddFontResourceEx(string pbFont, uint cbFont, IntPtr pdv);

        /// <summary>
        ///  FR_PRIVATE: 指定這個字型只有當前 Process 可以使用，程式關閉後自動清除
        /// </summary>
        private const uint FR_PRIVATE = 0x10;

        private static readonly FontFamily _defaultFallbackFont = new FontFamily("微軟正黑體");

        private static readonly Lazy<PrivateFontCollection> _fontCollection = new Lazy<PrivateFontCollection>(InitializeFonts);

        private static readonly Font _alertLabelFont = new Font("微軟正黑體", 12f, FontStyle.Regular);
        private static readonly Font _alertCaptionFont = new Font("微軟正黑體", 14f, FontStyle.Bold);

        private static readonly FontFamily _MicrosoftJhengHeiUIFontFamily = new FontFamily("Microsoft JhengHei UI");

        private static PrivateFontCollection InitializeFonts()
        {
            var collection = new PrivateFontCollection();

            string[] targetDirectories =
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources"),
            };
            
            bool anyFontLoaded = false;

            foreach (var directory in targetDirectories)
            {
                if(Directory.Exists(directory) is false) continue;

                var fontFiles = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(f => f.EndsWith(".ttf", StringComparison.OrdinalIgnoreCase) ||
                                f.EndsWith(".otf", StringComparison.OrdinalIgnoreCase));

                foreach (var fontPath in fontFiles)
                {
                    try
                    {
                        // 1. 加入 GDI+ 記憶體
                        collection.AddFontFile(fontPath);
                        // 2. 註冊到作業系統當前 Process (解 Telerik bug)
                        AddFontResourceEx(fontPath, FR_PRIVATE, IntPtr.Zero);
                        anyFontLoaded = true;
                    }
                    catch(Exception ex)
                    {
                        ShowDesktopAlert("字體載入異常",
                            $"檔名:{Path.GetFileName(fontPath)} 載入失敗。\n{ex.GetInnerException().ErrorMessage}", 6);
                    }
                }

            }


            if (!anyFontLoaded)
            {
                ShowDesktopAlert("字體設定",
                    "找不到任何字體檔案，系統將使用預設字體(微軟正黑體)！", 6);
            }

            return collection;
        }
        /// <summary>
        /// 
        /// </summary>
        public static FontFamily[] AllFonts
        {
            get
            {
                var families = _fontCollection.Value.Families;
                return families?.Any() is true
                    ? families.Concat(new[] { _MicrosoftJhengHeiUIFontFamily }).ToArray()
                    : new[] { _defaultFallbackFont, _MicrosoftJhengHeiUIFontFamily };
            }
        }
        /// <summary>
        /// 取得特定字型
        /// </summary>
        /// <param name="familyName"></param>
        /// <returns></returns>
        public static FontFamily GetFontFamily(string familyName)
        {
            if (string.IsNullOrWhiteSpace(familyName)) return _defaultFallbackFont;

            if (familyName.Equals(PresetFonts.MicrosoftJhengHeiUI.GetEnumDisplayName(), StringComparison.OrdinalIgnoreCase))
            {
                return _MicrosoftJhengHeiUIFontFamily;
            }
            var targetFont = _fontCollection.Value.Families
                .FirstOrDefault(f => f.Name.Equals(familyName, StringComparison.OrdinalIgnoreCase));
            return targetFont ?? _defaultFallbackFont;
        }
        /// <summary>
        /// 取得特定字型
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        public static FontFamily GetFontFamily(PresetFonts font = PresetFonts.SarasaUiTC_Regular)
        {
            if (font == PresetFonts.MicrosoftJhengHeiUI)
            {
                return _MicrosoftJhengHeiUIFontFamily;
            }
            var targetFont = _fontCollection.Value.Families
                .FirstOrDefault(f => f.Name.Equals(font.GetEnumDisplayName(), StringComparison.OrdinalIgnoreCase));
            return targetFont ?? _defaultFallbackFont;
        }
        /// <summary>
        /// 取得所有預設字型的名稱清單
        /// </summary>
        /// <returns></returns>
        public static List<string> GetPresetFontNames()
        {
            return AllFonts.Select(x => x.Name).ToList();
        }

        /// <summary>
        /// 檢查系統是否已安裝指定的字型。
        /// </summary>
        /// <param name="fontFamilyName">字型家族名稱</param>
        /// <returns>若已安裝回傳 true，否則回傳 false</returns>
        public static bool IsFontInstalled(string fontFamilyName)
        {
            try
            {
                using (var testFont = new Font(fontFamilyName, 10f))
                {
                    // 若字型不存在，.NET 會 fallback 到 Microsoft Sans Serif
                    return testFont.Name.Equals(fontFamilyName, StringComparison.OrdinalIgnoreCase);
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 取得Font
        /// </summary>
        /// <param name="fontFamily"></param>
        /// <param name="FontSize"></param>
        /// <param name="IsBold"></param>
        /// <param name="IsItalics"></param>
        /// <param name="IsUnderLine"></param>
        /// <param name="IsStrikeout"></param>
        /// <returns></returns>
        public static Font GetFont(PresetFonts fontFamily = PresetFonts.YaHeiConsolasHybrid
            , float FontSize = 12f
            , bool IsBold = false
            , bool IsItalics = false
            , bool IsUnderLine = false
            , bool IsStrikeout = false)
        {
            FontFamily targetFont = _defaultFallbackFont;
            FontStyle fontStyle = FontStyle.Regular;
            try
            {
                var getFont = GetFontFamily(fontFamily);
                targetFont = getFont ?? _defaultFallbackFont;
                if (IsBold) fontStyle |= FontStyle.Bold;
                if (IsItalics) fontStyle |= FontStyle.Italic;
                if (IsUnderLine) fontStyle |= FontStyle.Underline;
                if (IsStrikeout) fontStyle |= FontStyle.Strikeout;
            }
            catch
            {

            }
            //這裡會產生新的實例，頻繁呼叫需小心 Memory Leak
            return new Font(targetFont ?? _defaultFallbackFont, FontSize, fontStyle);
        }

        /// <summary>
        /// 右下角顯示警告提示
        /// </summary>
        /// <param name="Title">標題</param>
        /// <param name="Content">內容</param>
        /// <param name="CloseDelayTime">自動消失秒數(預設6秒)</param>
        /// <param name="ScreenDisplayPosition">提示顯示位置(Enum AlertScreenPosition)</param>
        /// <param name="PopupLocation">提示位置手動設定(new Point())</param>
        private static void ShowDesktopAlert(string Title, string Content, int CloseDelayTime = 6, AlertScreenPosition ScreenDisplayPosition = AlertScreenPosition.BottomRight, Point PopupLocation = new Point())
        {
            try
            {
                RadDesktopAlert radDesktopAlert = new RadDesktopAlert
                {
                    ScreenPosition = ScreenDisplayPosition,
                    AutoClose = true,
                    AutoCloseDelay = CloseDelayTime,
                    CaptionText = Title,
                    ContentText = Content,
                    AutoSize = true,
                    ShowCloseButton = true,
                    ShowOptionsButton = false,
                    ShowPinButton = false
                };

                if (ScreenDisplayPosition == AlertScreenPosition.Manual)
                {
                    if (radDesktopAlert.Popup is DesktopAlertPopup alertpopup)
                    {
                        alertpopup.Location = PopupLocation;
                    }
                }

                // 使用快取的 Font，避免 GDI 資源無限增長
                radDesktopAlert.Popup.AlertElement.ContentElement.Font = _alertLabelFont;
                radDesktopAlert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = _alertCaptionFont;
                radDesktopAlert.Show();
            }
            catch (Exception)
            {
                // 由於這是底層提示工具，若 Telerik UI 繪製失敗，不應 throw 導致應用程式直接崩潰
                // 實務上這裡可以寫入 Log 檔 (例如 NLog 或 txt)
            }
        }






        //////載入自訂字型ttf檔
        //////PrivateFontCollection 的AddFontFile()可把ttf檔直接讀入使用
        ////string FontName = "YaHeiConsolasHybrid.ttf";
        //private const string FontName = "SarasaFixedTC-Regular.ttf";
        //string FontsFolderPath = Application.StartupPath + "\\Fonts";
        //string ResourceFolderPath = Application.StartupPath + "\\Resources";

        //private PrivateFontCollection CreateFonts()
        //{
        //    // 字型檔載入策略：
        //    // HIS2_Library 已將 YaHeiConsolasHybrid.ttf 以 CopyToOutputDirectory=Always 部署到 Resources\，
        //    // 過往會再 File.Copy 一份到 Fonts\，造成同一份字型 (~13.8MB) 被存兩次。
        //    // 現改為直接從現有路徑讀取，優先 Fonts\ (向下相容舊部署)，否則改讀 Resources\。
        //    string fontPath = null;
        //    string fontsCopy    = Path.Combine(FontsFolderPath,    FontName);
        //    string resourceCopy = Path.Combine(ResourceFolderPath, FontName);

        //    if (File.Exists(fontsCopy))         fontPath = fontsCopy;
        //    else if (File.Exists(resourceCopy)) fontPath = resourceCopy;

        //    if (fontPath == null)
        //    {
        //        ShowDesktopAlert("字體設定", "找不到字體檔案，使用預設字體(微軟正黑體)來顯示!", 3);
        //        return new PrivateFontCollection();
        //    }

        //    var result = new PrivateFontCollection();
        //    result.AddFontFile(fontPath);
        //    return result;

        //    //載入到Memory 
        //    //var result = new PrivateFontCollection();
        //    //var bytes = Properties.Resource.YaHeiConsolasHybrid;
        //    //System.IntPtr pointer = Marshal.AllocCoTaskMem(bytes.Length);
        //    //Marshal.Copy(bytes, 0, pointer, bytes.Length);
        //    //result.AddMemoryFont(pointer, bytes.Length);
        //    //return result;
        //}
        ///// <summary>
        ///// 全域唯一的字型集合與
        ///// </summary>
        //private static PrivateFontCollection _fontsCollection;
        ///// <summary>
        ///// 全域唯一的執行緒鎖
        ///// </summary>
        //private static readonly object _lock = new object();
        ///// <summary>
        ///// 預先快取警告視窗專用的字型，防止每次 ShowDesktopAlert 都 new Font 造成記憶體洩漏
        ///// </summary>
        //private static readonly Font _alertLabelFont = new Font("微軟正黑體", 12f, FontStyle.Regular);
        ///// <summary>
        ///// 預先快取警告視窗專用的字型，防止每次 ShowDesktopAlert 都 new Font 造成記憶體洩漏
        ///// </summary>
        //private static readonly Font _alertCaptionFont = new Font("微軟正黑體", 14f, FontStyle.Bold);

        //private static void EnsureFontLoaded()
        //{
        //    if (_fontsCollection != null) return;
        //    lock (_lock)
        //    {
        //        if (_fontsCollection != null) return;

        //        _fontsCollection = new PrivateFontCollection();

        //        string fontsFolderPath = Path.Combine(Application.StartupPath, "Fonts", FontName);
        //        string resourceFolderPath = Path.Combine(Application.StartupPath, "Resources", FontName);

        //        // 優先找 Fonts 資料夾，若無則找 Resources 資料夾
        //        string fontPath = File.Exists(fontsFolderPath) ? fontsFolderPath :
        //            File.Exists(resourceFolderPath) ? resourceFolderPath : null;

        //        if (fontPath == null)
        //        {
        //            ShowDesktopAlert("字體設定", "找不到字體檔案，使用預設字體(微軟正黑體)來顯示!", 3);
        //            return; // 找不到檔案，直接中斷，Fonts 屬性會自動 fallback 到微軟正黑體
        //        }

        //        try
        //        {
        //            // 【重點 1】：加到 PrivateFontCollection，供標準 WinForms 與繪圖使用
        //            _fontsCollection.AddFontFile(fontPath);

        //            // 【重點 2】：加到作業系統的當前 Process 字型表中！
        //            // 這是解決 Telerik 報錯 "找不到字型 'YaHei Consolas Hybrid'" 的唯一解藥
        //            AddFontResourceEx(fontPath, FR_PRIVATE, IntPtr.Zero);
        //        }
        //        catch (Exception ex)
        //        {
        //            ShowDesktopAlert("字體載入異常", $"字型檔讀取失敗，將使用預設字型。\n錯誤: {ex.Message}", 5);
        //        }
        //    }
        //}


        //public static FontFamily[] Fonts
        //{
        //    get
        //    {
        //        EnsureFontLoaded();
        //        if (_fontsCollection == null)
        //        {
        //            _fontsCollection = new CoreBaseFontsProxy().CreateFonts();
        //        }
        //        if (_fontsCollection.Families.Any() == false)
        //        {
        //            FontFamily[] DefaultFonts = new FontFamily[] { new FontFamily("微軟正黑體") };
        //            return DefaultFonts;
        //            //_fontsCollection.Families = new FontFamily("微軟正黑體");
        //        }

        //        return _fontsCollection.Families;
        //    }
        //}


    }
    #endregion

}
