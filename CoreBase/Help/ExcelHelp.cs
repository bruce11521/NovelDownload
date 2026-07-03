using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Dapper.Contrib.Extensions;

namespace CoreBase.Help
{
    /// <summary>
    /// Excel 相關
    /// </summary>
    public class ExcelHelp
    {
        #region 使用教學
        // 相關Service Model說明
        //1.Model中不產生至Excel的項目前面請加入[Write(false)]，並using Dapper.Contrib.Extensions;
        //2.要顯示名稱請在Model前加入Attribute，[DisplayName("掛號號碼")]或[Display(Name = "姓名")]，將會將欄位名稱改為『掛號號碼』，並using System.ComponentModel;


        // 直接存檔呼叫法（僅for WinForm）
        //new ExcelHelp().CreateExcel(資料, 完整路徑, Sheet名稱);


        // 直接存檔呼叫法（Web可用）
        // Step1 : Controller中寫下面一行
        // MemoryStream fileStream = new ExcelHelp().GenderExcel(資料, Sheet名稱);
        // Step2 : Controller Return下面的結果
        // return File(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 檔名);
        #endregion 使用教學

        ///// <summary>
        ///// 建立Excel
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="data">資料</param>
        ///// <param name="fileName">完整檔名及路徑</param>
        ///// <param name="sheetName">Sheet Name</param>
        ///// <returns></returns>
        //public void CreateExcel<T>(List<T> data, string fileName = null, string sheetName = null)
        //{
        //    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        //    //在記憶體中建立一個Excel物件
        //    ExcelPackage ep = new ExcelPackage();

        //    if (string.IsNullOrWhiteSpace(fileName))
        //    {
        //        fileName = $"ExcelExport_{DateTime.Today.ToString("yyyy.MM.dd")}.xlsx";
        //    }

        //    if (string.IsNullOrWhiteSpace(sheetName))
        //    {
        //        sheetName = fileName;
        //    }

        //    //加入一個Sheet
        //    ep.Workbook.Worksheets.Add(sheetName);
        //    //取得剛剛加入的Sheet
        //    ExcelWorksheet sheet1 = ep.Workbook.Worksheets[sheetName];//取得Sheet1 

        //    //組Excel
        //    this.BindSheet(data, sheet1, true);

        //    sheet1.View.FreezePanes(2, 1);

        //    FileInfo fileInfo = new FileInfo(fileName);

        //    ep.SaveAs(fileInfo);
        //    ep.Dispose(); //如果這邊不下Dispose，建議此ep要用using包起來，但是要記得先將資料寫進MemoryStream在Dispose。
        //}

        ///// <summary>
        ///// 建立Excel
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="data">資料</param>
        ///// <param name="sheetName">Sheet名稱</param>
        ///// <returns></returns>
        //public MemoryStream GenderExcel<T>(List<T> data, string sheetName)
        //{
        //    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        //    //在記憶體中建立一個Excel物件
        //    ExcelPackage ep = new ExcelPackage();

        //    if (string.IsNullOrWhiteSpace(sheetName))
        //    {
        //        sheetName = $"ExcelExport_{DateTime.Today.ToString("yyyy.MM.dd")} ";
        //    }

        //    //加入一個Sheet
        //    ep.Workbook.Worksheets.Add(sheetName);
        //    //取得剛剛加入的Sheet
        //    ExcelWorksheet sheet1 = ep.Workbook.Worksheets[sheetName];//取得Sheet1 
            
        //    //組Excel
        //    this.BindSheet(data, sheet1, true);

        //    sheet1.View.FreezePanes(2, 1);

        //    MemoryStream fileStream = new MemoryStream();
        //    ep.SaveAs(fileStream);
        //    ep.Dispose(); //如果這邊不下Dispose，建議此ep要用using包起來，但是要記得先將資料寫進MemoryStream在Dispose。
        //    fileStream.Position = 0; //不重新將位置設為0，excel開啟後會出現錯誤

        //    return fileStream;
        //}

        ///// <summary>
        ///// 將資料組成Excel
        ///// </summary>
        ///// <typeparam name="T">傳入的資料型態</typeparam>
        ///// <param name="transData">傳入的資料</param>
        ///// <param name="sheet">sheet</param>
        ///// <param name="withCustomHeader">資料有置換標題名稱</param>
        ///// <param name="intFormat">數值的資料型態</param>
        //public void BindSheet<T>(List<T> transData, ExcelWorksheet sheet, bool withCustomHeader = false, string intFormat = "#,##0", TableStyles tableStyle = TableStyles.None)
        //{
        //    PropertyInfo[] pInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    var rowIndex = 1; // 列的定位
        //    var columnIndex = 1; // 行的定位
        //    var skipColumnCount = 0; // 跳過的行數

        //    foreach (var propertyInfo in pInfos)
        //    {
        //        if (propertyInfo.IsDefined(typeof(WriteAttribute), true)
        //            || propertyInfo.IsDefined(typeof(NoWrite), true))
        //        {
        //            skipColumnCount++;
        //            continue;
        //        }
                
        //        if (withCustomHeader)
        //        {
        //            // 依Model 的 DisplayName顯示欄位名稱
        //            var displayName = propertyInfo.GetCustomAttribute<DisplayNameAttribute>();
        //            var titleName = displayName?.DisplayName;
        //            if (string.IsNullOrWhiteSpace(titleName))
        //            {
        //                var info = propertyInfo.GetCustomAttribute<DisplayAttribute>();
        //                titleName = info?.Name;
        //            }
        //            sheet.Cells[rowIndex, columnIndex].Value = string.Format(CultureInfo.CurrentCulture, "{0}", (titleName ?? propertyInfo.Name));  //寫入Column name
        //        }
        //        else
        //        {
        //            sheet.Cells[rowIndex, columnIndex].Value = string.Format(CultureInfo.CurrentCulture, "{0}", propertyInfo.Name);  //寫入Column name
        //        }

        //        sheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;  //文字置中
        //        columnIndex++;
        //    }

        //    rowIndex = 2;

        //    // 將資料組出來
        //    #region 將資料放到Column中
        //    foreach (var item in transData)
        //    {
        //        columnIndex = 1; // column歸位

        //        foreach (var propertyInfo in pInfos)
        //        {
        //            if (propertyInfo.IsDefined(typeof(WriteAttribute), true)
        //            || propertyInfo.IsDefined(typeof(NoWrite), true))
        //            {
        //                continue;
        //            }

        //            var pType = propertyInfo.PropertyType;
        //            if (pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Nullable<>))
        //            {
        //                pType = pType.GetGenericArguments()[0];
        //            }

        //            var val = propertyInfo.GetValue(item, null);
        //            if (val != null)
        //            {
        //                switch (Type.GetTypeCode(pType))
        //                {
        //                    case TypeCode.Int16:
        //                    case TypeCode.Int32:
        //                    case TypeCode.Int64:
        //                    case TypeCode.Single:
        //                    case TypeCode.Double:
        //                    case TypeCode.Decimal:
        //                        sheet.Cells[rowIndex, columnIndex].Value = val;
        //                        sheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;  //文字置中
        //                        sheet.Cells[rowIndex, columnIndex].Style.Numberformat.Format = intFormat;
        //                        break;
        //                    case TypeCode.DateTime:
        //                        sheet.Cells[rowIndex, columnIndex].Value = ((DateTime)val).ToString("yyyy/MM/dd");
        //                        sheet.Cells[rowIndex, columnIndex].Style.Numberformat.Format = "yyyy/mm/dd";
        //                        sheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;  //文字置中
        //                        break;
        //                    default:
        //                        sheet.Cells[rowIndex, columnIndex].Value = string.Format(CultureInfo.CurrentCulture, "{0}", val.ToString().Replace("\"", "\"\""));
        //                        sheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;  //文字置中
        //                        break;
        //                }
        //            }
        //            else
        //            {
        //                sheet.Cells[rowIndex, columnIndex].Value = string.Empty;
        //            }

        //            columnIndex++; // column位移一格
        //        }

        //        rowIndex++; // row位移一列
        //    }
        //    #endregion 將資料放到Column中

        //    if (tableStyle != TableStyles.None)
        //    {
        //        // 先設定範圍
        //        //ExcelRange rg = sheet.Cells[1, 1, rowIndex, pInfos.Count()];
        //        // 設定至資料表
        //        sheet.Tables.Add(sheet.Cells[1, 1, rowIndex, (pInfos.Count()- skipColumnCount)], sheet.Name);
        //        // 設定資料樣式
        //        sheet.Tables[sheet.Name].TableStyle = tableStyle;
        //    }

        //    sheet.Cells[1, 1, rowIndex, (pInfos.Count() - skipColumnCount)].AutoFitColumns();
        //}
    }
}