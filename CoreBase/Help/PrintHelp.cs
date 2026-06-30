using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;

namespace CoreBase.Help
{
    public class PrintHelp
    {
        private List<Stream> m_streams = new List<Stream>();
        int m_currentPageIndex = 0;

        /// <summary>
        /// 自訂義列印設定
        /// 自樣版預設為 A4 直式
        /// </summary>
        public class PageSet : PaperSize
        {
            /// <summary>
            /// 紙張名稱
            /// </summary>
            public string PaperName
            {
                get
                {
                    return Kind.ToString();
                }
            }

            /// <summary>
            /// 單位為mm
            /// </summary>
            public int Height { get; set; } = 297;

            /// <summary>
            /// 單位為mm
            /// </summary>
            public int Width { get; set; } = 210;

            /// <summary>
            /// 是否橫向列印(true)
            /// </summary>
            public bool IsLandScape { get; set; } = true;

            /// <summary>
            /// 列印份數（預設 1 份）
            /// </summary>
            public short Copies { get; set; } = 1;

            /// <summary>
            /// 自訂邊界(單位為mm)
            /// </summary>
            public Margins CustomizeMargins = null;
        }

        /// <summary>
        /// 紙張尺吋對照表
        /// 來源：https://docs.microsoft.com/zh-tw/dotnet/api/system.drawing.printing.paperkind?view=dotnet-plat-ext-3.1
        /// </summary>
        private Dictionary<PaperKind, (int Width, int Height)> PaperSetting = new Dictionary<PaperKind, (int Height, int Width)>()
        {
            { PaperKind.A2, (420, 594)},
            { PaperKind.A3, (297, 420)},
            { PaperKind.A3Extra, (322, 445)},
            { PaperKind.A3ExtraTransverse, (322, 445)},
            { PaperKind.A3Rotated, (420, 297)},
            { PaperKind.A3Transverse, (297, 420)},
            { PaperKind.A4, (210, 297)},
            { PaperKind.A4Extra, (236, 322)},
            { PaperKind.A4Rotated, (297, 210)},
            { PaperKind.A4Small, (210, 297)},
            { PaperKind.A4Transverse, (210, 297)},
            { PaperKind.A5, (148, 210)},
            { PaperKind.A5Extra, (174, 235)},
            { PaperKind.A5Rotated, (210, 148)},
            { PaperKind.A5Transverse, (148, 210)},
            { PaperKind.A6, (105, 148)},
            { PaperKind.A6Rotated, (105, 148)},
            { PaperKind.APlus, (227, 356)},
            { PaperKind.B4, (250, 353)},
            { PaperKind.B4Envelope, (250, 353)},
            { PaperKind.B4JisRotated, (364, 257)},
            { PaperKind.B5, (176, 250)},
            { PaperKind.B5Envelope, (176, 250)},
            { PaperKind.B5JisRotated, (257, 182)},
            { PaperKind.B6Envelope, (176, 125)},
            { PaperKind.B6Jis, (128, 182)},
            { PaperKind.BPlus, (305, 487)},
            { PaperKind.C3Envelope, (324, 458)},
            { PaperKind.C4Envelope, (229, 324)},
            { PaperKind.C5Envelope, (162, 229)},
            { PaperKind.C65Envelope, (114, 229)},
            { PaperKind.C6Envelope, (114, 162)},
            { PaperKind.DLEnvelope, (110, 220)},
            { PaperKind.Letter, (216, 279)},
            { PaperKind.Legal, (216, 356)},
            { PaperKind.InviteEnvelope, (220, 220)},
            { PaperKind.Executive, (184, 267)},
            { PaperKind.Ledger, (297, 432)},
        };

        /// <summary>
        /// 列印
        /// </summary>
        /// <param name="stream">列印的資料，格式須選擇為 EMF 類型</param>
        /// <param name="PrintName">指定印表機名稱，null則使用預設值</param>
        /// <param name="PageSize">指定列印參數，null則使用預設值</param>
        public void Print(List<Stream> stream, string PrintName, PageSet PageSize)
        {
            PrintDocument ptDoc = new PrintDocument();
            //for (short i = 1; i <= PageSize.Copies; i++)
            //{
            // 指定印表機或不指定則為預設值
            if (string.IsNullOrEmpty(PrintName) == false)
            {
                ptDoc.PrinterSettings.PrinterName = PrintName;
            }

            // 先隨興加一下，如果沒設定列印的印表機，也沒有預設值時，試試能不能成功
            if (string.IsNullOrEmpty(ptDoc.PrinterSettings.PrinterName))
            {
                //PrintDocument ptDoc = new PrintDocument();
                //string nowPrinter = pd.PrinterSettings.PrinterName;
                List<String> printersList = new List<String>();
                for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                {
                    if (PrinterSettings.InstalledPrinters[i].Contains("Brother"))
                    {
                         printersList.Add(PrinterSettings.InstalledPrinters[i]);
                    }
                }
                ptDoc.PrinterSettings.PrinterName = printersList?[0];

                if (string.IsNullOrEmpty(ptDoc.PrinterSettings.PrinterName))
                {
                    throw new Exception("沒有可列印之印表機。");
                }
            }

            // 將要列印的清單放置全域變數
            m_streams.AddRange(stream);

            // 指定列印參數
            if (PageSize != null)
            {
                if (PaperSetting.TryGetValue(PageSize.Kind, out (int Width, int Height) paperValue))
                {
                    // paperValue ： 指向系統預設的尺吋
                    ptDoc.DefaultPageSettings.PaperSize = new PaperSize(PageSize.PaperName,
                       (int)((paperValue.Width / 10 * 0.393701) * 100), (int)((paperValue.Height / 10 * 0.393701) * 100));
                }
                else
                {
                    ptDoc.DefaultPageSettings.PaperSize = new PaperSize(PageSize.PaperName,
                        (int)((PageSize.Width / 10 * 0.393701) * 100), (int)((PageSize.Height / 10 * 0.393701) * 100));
                }

                // 是否橫向列印
                ptDoc.DefaultPageSettings.Landscape = PageSize.IsLandScape;

                if (PageSize.CustomizeMargins != null)
                {
                    var customizeMargins = new Margins();
                    customizeMargins.Top = (int)((PageSize.CustomizeMargins.Top / 10 * 0.393701) * 100);
                    customizeMargins.Right = (int)((PageSize.CustomizeMargins.Right / 10 * 0.393701) * 100);
                    customizeMargins.Bottom = (int)((PageSize.CustomizeMargins.Bottom / 10 * 0.393701) * 100);
                    customizeMargins.Left = (int)((PageSize.CustomizeMargins.Left / 10 * 0.393701) * 100);

                    ptDoc.DefaultPageSettings.Margins = customizeMargins;
                }

            }

            if (!ptDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the printer [" + PrintName + "].");
            }
            else
            {
                //宣告PrintDocument物件的PrintPage事件，具體的列印操作需要在這個事件中處理。
                ptDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintPage);
                //設定印表機列印份數
                ptDoc.PrinterSettings.Copies = PageSize.Copies;

                ptDoc.Print();
            }
            //}
        }

        /// <summary>
        /// 提供給 PrintDocument 作業用的 PrintPageEvents
        /// </summary>
        private void PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
            m_streams[m_currentPageIndex].Position = 0;
            // 建立影像Meta 同時把Image Stream 倒入
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            // 調整繪制方塊大小同等印表機可列印空間
            // Rectangle 在 System.Drawing 內
            Rectangle adjustedRect = new Rectangle(
                                     ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                                     ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                                     ev.PageBounds.Width, ev.PageBounds.Height);
            // 報表背景以白色塗刷
            //ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // 繪製報表內容
            ev.Graphics.DrawImage(pageImage, adjustedRect);
            //ev.Graphics.DrawImage(pageImage, 0, 0);

            //
            m_streams[m_currentPageIndex].Close();

            // 準備到下一頁繪製，確保將資料繪製完畢
            m_currentPageIndex++;
            // 設定是否需要繼續列印
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
    }
}
