using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static CoreBase.Help.PrintHelp;

namespace CoreBase.Help
{
    public class RDLCExtensions
    {
//        #region 全域變數
//        /// <summary>
//        /// 檔案格式參考
//        /// </summary>
//        private Dictionary<EnumUtility.FileType, (string ReportType, string Format)> formatList = new Dictionary<EnumUtility.FileType, (string, string)>
//        {
//            // {Key, Value<ReportType, Format>}
//            {EnumUtility.FileType.PDF, ( "PDF", "PDF")},
//            {EnumUtility.FileType.Excel, ( "Excel", "Excel")},
//            {EnumUtility.FileType.Word, ("Word", "Word")},
//            {EnumUtility.FileType.PNG, ( "PNG", "Image")},
//            {EnumUtility.FileType.JPG, ( "JPG", "Image")},
//            {EnumUtility.FileType.JPEG, ( "JPG", "Image")},
//            {EnumUtility.FileType.EMF, ( "EMF", "Image")},
//        };

//        /// <summary>
//        /// 子表單的Table清單
//        /// </summary>
//        private Dictionary<string, object> dataTable = new Dictionary<string, object>();

//        /// <summary>
//        /// Stream清單
//        /// </summary>
//        private IList<Stream> m_streams = new List<Stream>();

//        #endregion 全域變數

//        /// <summary>
//        /// 傳入的參數值
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        public class RDLCModel
//        {
//            /// <summary>
//            /// RDLC 樣版
//            /// </summary>
//            public RDLCModel()
//            {
//            }

//            /// <summary>
//            /// RDLC 樣版
//            /// </summary>
//            /// <param name="reportPath">RDLC樣版路徑</param>
//            /// <param name="fileType">產出檔案格式</param>
//            /// <param name="fileName">檔案名稱</param>
//            /// <param name="data">資料集</param>
//            public RDLCModel(string reportPath, EnumUtility.FileType fileType, string fileName, Dictionary<string, object> data)
//            {
//                this.ReportPath = reportPath;
//                this.Filetype = fileType;
//                this.FileName = fileName;
//                this.SourceData = data;
//            }

//            ///// <summary>
//            ///// RDLC 樣版
//            ///// </summary>
//            ///// <param name="reportPath">RDLC樣版路徑</param>
//            ///// <param name="fileType">產出檔案格式</param>
//            ///// <param name="fileName">檔案名稱</param>
//            ///// <param name="parameters">參數</param>
//            //public RDLCModel(string reportPath, EnumUtility.FileType fileType, string fileName, Dictionary<string, object> parameters)
//            //{
//            //    this.ReportPath = reportPath;
//            //    this.Filetype = fileType;
//            //    this.FileName = fileName;
//            //    this.Parameters = parameters;
//            //}

//            /// <summary>
//            /// RDLC 樣版
//            /// </summary>
//            /// <param name="reportPath">RDLC樣版路徑</param>
//            /// <param name="fileType">產出檔案格式</param>
//            /// <param name="fileName">檔案名稱</param>
//            /// <param name="data">資料集</param>
//            /// <param name="parameters">參數</param>
//            public RDLCModel(string reportPath, EnumUtility.FileType fileType, string fileName, Dictionary<string, object> data, Dictionary<string, object> parameters)
//            {
//                this.ReportPath = reportPath;
//                this.Filetype = fileType;
//                this.FileName = fileName;
//                this.SourceData = data;
//                this.Parameters = parameters;
//            }

//            ///// <summary>
//            ///// RDLC 樣版
//            ///// </summary>
//            ///// <param name="reportPath">RDLC樣版路徑</param>
//            ///// <param name="fileType">產出檔案格式</param>
//            ///// <param name="fileName">檔案名稱</param>
//            ///// <param name="parameters">參數</param>
//            ///// <param name="subData">子報表</param>
//            //public RDLCModel(string reportPath, EnumUtility.FileType fileType, string fileName, Dictionary<string, object> parameters, Dictionary<string, object> subData)
//            //{
//            //    this.ReportPath = reportPath;
//            //    this.Filetype = fileType;
//            //    this.FileName = fileName;
//            //    this.Parameters = parameters;
//            //    this.SubData = subData;
//            //}

//            ///// <summary>
//            ///// RDLC 樣版
//            ///// </summary>
//            ///// <param name="reportPath">RDLC樣版路徑</param>
//            ///// <param name="fileType">產出檔案格式</param>
//            ///// <param name="fileName">檔案名稱</param>
//            ///// <param name="data">資料集</param>
//            ///// <param name="parameters">參數</param>
//            ///// <param name="subData">子報表</param>
//            //public RDLCModel(string reportPath, EnumUtility.FileType fileType, string fileName, IEnumerable<T> data, Dictionary<string, object> parameters, Dictionary<string, object> subData)
//            //{
//            //    this.ReportPath = reportPath;
//            //    this.Filetype = fileType;
//            //    this.FileName = fileName;
//            //    this.Data = data;
//            //    this.Parameters = parameters;
//            //    this.SubData = subData;
//            //}

//            /// <summary>
//            /// RDLC 樣版
//            /// </summary>
//            /// <param name="reportPath">RDLC樣版路徑</param>
//            /// <param name="fileType">產出檔案格式</param>
//            /// <param name="fileName">檔案名稱</param>
//            /// <param name="SourceData">資料集　可以自定義資料集名稱及資料集</param>
//            /// <param name="parameters">參數</param>
//            /// <param name="subData">子報表</param>
//            public RDLCModel(string reportPath, EnumUtility.FileType fileType, string fileName, Dictionary<string, object> SourceData, Dictionary<string, object> parameters, Dictionary<string, object> subData)
//            {
//                this.ReportPath = reportPath;
//                this.Filetype = fileType;
//                this.FileName = fileName;
//                this.SourceData = SourceData;
//                this.Parameters = parameters;
//                this.SubData = subData;
//            }

//            /// <summary>
//            /// RDLC樣版路徑
//            /// </summary>
//            public string ReportPath { get; set; }

//            /// <summary>
//            /// 產出檔案格式
//            /// </summary>
//            public EnumUtility.FileType Filetype { get; set; }

//            /// <summary>
//            /// 檔案名稱
//            /// </summary>
//            public string FileName { get; set; }

//            /// <summary>
//            /// 資料集
//            /// </summary>
//            public Dictionary<string, object> SourceData { get; set; }

//            /// <summary>
//            /// 參數
//            /// </summary>
//            public Dictionary<string, object> Parameters { get; set; }

//            /// <summary>
//            /// 子報表 <DataSetName, DataTable>
//            /// </summary>
//            public Dictionary<string, object> SubData { get; set; }
//        }

//        /// <summary>
//        /// Parameters 範例
//        /// </summary>
//        //  Dictionary<string, object> parameters = new Dictionary<string, object>
//        //  {
//        //      { "Name ", "張三"},
//        //      { "List", new string[2]{"張三清單1", "張三清單二" } }
//        //  };

//        /// <summary>列印</summary>
//        /// <param name="ReportPath">報表樣版路徑</param>
//        /// <param name="sourceData">資料</param>
//        /// <param name="parameters">參數（可給Null）</param>
//        /// <param name="PrintName">指定印表機名稱，null則使用預設值</param>
//        /// <param name="PageSize">指定列印參數，null則使用預設值</param>
//        public void Print(string ReportPath, Dictionary<string, object> sourceData, Dictionary<string, object> parameters, string PrintName = null, PageSet PageSize = null)
//        {
//            var Rdlc = new RDLCModel { ReportPath = ReportPath, SourceData = sourceData, Parameters = parameters };
//            Print(Rdlc, PrintName, PageSize);
//        }

//        /// <summary>列印</summary>
//        /// <param name="Rdlc">RDLC</param>
//        /// <param name="PrintName">指定印表機名稱，null則使用預設值</param>
//        /// <param name="PageSize">指定列印參數，null則使用預設值</param>
//        public void Print(RDLCModel Rdlc, string PrintName = null, PageSet PageSize = null)
//        {
//            // 列印固定給 EMF 類型
//            Rdlc.Filetype = EnumUtility.FileType.EMF;
//            var stream = GetStreams(Rdlc);
//            new PrintHelp().Print(stream.ToList(), PrintName, PageSize);
//        }

//        /// <summary>產生能列印的檔案</summary>
//        /// <param name="ReportPath">報表樣版路徑</param>
//        /// <param name="filetype">檔案類型</param>
//        /// <param name="fileName">檔案名稱</param>
//        /// <param name="sourceData">資料</param>
//        /// <param name="parameters">參數（可給Null）</param>
//        public List<Stream> GetStreams(string ReportPath, EnumUtility.FileType filetype, string fileName, Dictionary<string, object> sourceData, Dictionary<string, object> parameters)
//        {
//            var rdlcModel = new RDLCModel { ReportPath = ReportPath, Filetype = filetype, FileName = fileName, SourceData = sourceData, Parameters = parameters };
//            return GetStreams(rdlcModel);
//        }

//        /// <summary>
//        /// 產生能列印的檔案
//        /// </summary>
//        public List<Stream> GetStreams(RDLCModel rdlcModel)
//        {
//            //filetype
//            var getFileInfo = formatList.TryGetValue(rdlcModel.Filetype, out (string ReportType, string Format) fileInfo);
//            if (getFileInfo == false)
//            {
//                throw new Exception("格式輸入錯誤");
//            }

//            LocalReport Lr = new LocalReport();
//            Lr.ReportPath = rdlcModel.ReportPath;

//            //設定報表資訊
//            string deviceInfo = $@"
//<DeviceInfo>
//    <OutputFormat>{fileInfo.ReportType}</OutputFormat>
//</DeviceInfo>";

//            //設定資料來源
//            Lr.DataSources.Clear();
//            foreach (var row in rdlcModel.SourceData)
//            {
//                Lr.DataSources.Add(new ReportDataSource(row.Key, row.Value));
//            }
//            Lr.Refresh();

//            if (rdlcModel.SubData != null && rdlcModel.SubData.Count > 0)
//            {
//                dataTable = rdlcModel.SubData;

//                Lr.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandle);
//            }

//            //設定報表參數
//            if (rdlcModel.Parameters != null)
//            {
//                //ReportParameter rp1 = new ReportParameter("wocode", "WO201312060001");
//                //ReportParameter rp2 = new ReportParameter("oemname", "PrimeEagle Studio");
//                Lr.SetParameters(getParameter(rdlcModel.Parameters));
//            }

//            m_streams = new List<Stream>();

//            Lr.Render(fileInfo.Format, deviceInfo, CreateStream, out Microsoft.Reporting.WinForms.Warning[] warnings);

//            // 釋放資源
//            foreach (Stream stream in m_streams)
//            {
//                stream.Position = 0;
//            }

//            return m_streams.ToList();
//        }

//        /// <summary>產生PDF or Excel</summary>
//        /// <param name="ReportPath">報表樣版路徑</param>
//        /// <param name="filetype">檔案類型</param>
//        /// <param name="fileName">檔案名稱</param>
//        /// <param name="sourceData">資料</param>
//        /// <param name="parameters">參數（可給Null）</param>
//        /// <param name="isPrint">是否要列印(選填，預設否)</param>
//        /// <param name="PrintName">印表機名稱(選填，如要列印，且沒填，預設為本機)</param>
//        /// <param name="PageSize">印表機紙張設定(選填，如要列印，且沒填，預設為A4直式)</param>
//        public byte[] GenerateFileBytes(string ReportPath, EnumUtility.FileType filetype, string fileName, Dictionary<string, object> sourceData, Dictionary<string, object> parameters, bool isPrint = false, string PrintName = null, PageSet PageSize = null)
//        {
//            var rdlcModel = new RDLCModel { ReportPath = ReportPath, Filetype = filetype, FileName = fileName, SourceData = sourceData, Parameters = parameters };
//            return GenerateFileBytes(rdlcModel, isPrint, out string mimeType, out string encoding, out string extension, out string[] streamIds, out Microsoft.Reporting.WinForms.Warning[] warnings, PrintName, PageSize);
//        }

//        /// <summary>產生PDF or Excel</summary>
//        /// <param name="rdlcModel">報表參數</param>
//        /// <param name="isPrint">是否要列印(選填，預設否)</param>
//        /// <param name="PrintName">印表機名稱(選填，如要列印，且沒填，預設為本機)</param>
//        /// <param name="PageSize">印表機紙張設定(選填，如要列印，且沒填，預設為A4直式)</param>
//        public byte[] GenerateFileBytes(RDLCModel rdlcModel, bool isPrint, string PrintName = null, PageSet PageSize = null)
//        {
//            return GenerateFileBytes(rdlcModel, isPrint, out string mimeType, out string encoding, out string extension, out string[] streamIds, out Warning[] warnings, PrintName, PageSize);
//        }

//        /// <summary>產生PDF or Excel</summary>
//        /// <param name="rdlcModel">報表參數</param>
//        /// <param name="mimeType">報表的 MIME 類型 ex:如果輸出為PDF,則會傳回 "application/pdf"</param>
//        /// <param name="encoding">報表的 Encoding</param>
//        /// <param name="extension">輸出檔所用的副檔名 ex 如果輸出為PDF,則會傳回 "pdf"</param>
//        /// <param name="streamIds"></param>
//        /// <param name="warnings">紀錄 產生報表時發生的錯誤訊息</param>
//        public byte[] GenerateFileBytes(RDLCModel rdlcModel, bool isPrint
//            , out string mimeType, out string encoding, out string extension, out string[] streamIds, out Warning[] warnings, string PrintName = null, PageSet PageSize = null)
//        {
//            //filetype
//            var getFileInfo = formatList.TryGetValue(rdlcModel.Filetype, out (string ReportType, string Format) fileInfo);
//            if (getFileInfo == false)
//            {
//                throw new Exception("格式輸入錯誤");
//            }

//            //宣告ReportViewer物件
//            ReportViewer viewer = new ReportViewer();
//            viewer.ProcessingMode = ProcessingMode.Local;
//            viewer.LocalReport.ReportPath = rdlcModel.ReportPath;

//            //設定報表資訊
//            string deviceInfo = $@"
//<DeviceInfo>
//    <OutputFormat>{fileInfo.ReportType}</OutputFormat>
//</DeviceInfo>";

//            //設定資料來源
//            viewer.LocalReport.DataSources.Clear();
//            foreach (var row in rdlcModel.SourceData)
//            {
//                viewer.LocalReport.DataSources.Add(new ReportDataSource(row.Key, row.Value));
//            }
//            viewer.LocalReport.Refresh();

//            if (rdlcModel.SubData != null && rdlcModel.SubData.Count > 0)
//            {
//                dataTable = rdlcModel.SubData;

//                viewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandle);
//            }

//            //設定報表參數
//            if (rdlcModel.Parameters != null)
//            {
//                //ReportParameter rp1 = new ReportParameter("wocode", "WO201312060001");
//                //ReportParameter rp2 = new ReportParameter("oemname", "PrimeEagle Studio");

//                viewer.LocalReport.SetParameters(getParameter(rdlcModel.Parameters));
//            }

//            //透過Render的方式取得PDF二進位檔案
//            byte[] bytes = viewer.LocalReport.Render(fileInfo.Format, deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);

//            // 是否要列印
//            if (isPrint)
//            {
//                var printModel = rdlcModel;
//                printModel.Filetype = EnumUtility.FileType.EMF;
//                var stream = GetStreams(printModel);
//                new PrintHelp().Print(stream, PrintName, PageSize);
//            }

//            //產生下載檔
//            //Response.Buffer = true;
//            //Response.Clear();
//            //Response.ContentType = mimeType;
//            //Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
//            //Response.BinaryWrite(bytes);
//            //Response.Flush();
//            return bytes;
//        }

//        /// <summary>
//        /// 加入子報表的資料表
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        void SubreportProcessingEventHandle(object sender, SubreportProcessingEventArgs e)
//        {
//            var num = 2;
//            foreach (var data in dataTable)
//            {
//                e.DataSources.Add(new ReportDataSource(data.Key, data.Value));
//                num++;
//            }
//        }

//        /// Routine to provide to the report renderer, in order to
//        /// save an image for each page of the report.
//        /// <summary>
//        /// 單純拿來建多個Stream用
//        /// </summary>
//        /// <param name="fileName"></param>
//        /// <param name="fileNameExtension"></param>
//        /// <param name="encoding"></param>
//        /// <param name="mimeType"></param>
//        /// <param name="willSeek"></param>
//        /// <returns></returns>
//        private Stream CreateStream(string fileName, string fileNameExtension, Encoding encoding,
//                            string mimeType, bool willSeek)
//        {
//            Stream stream = new MemoryStream();
//            m_streams.Add(stream);
//            return stream;
//        }

//        /// <summary>
//        /// 參數轉換
//        /// </summary>
//        /// <param name="para"></param>
//        /// <returns></returns>
//        private ReportParameter[] getParameter (Dictionary<string, object> para)
//        {
//            ReportParameter[] result = new ReportParameter[para.Count];

//            int i = 0;
//            foreach (KeyValuePair<string, object> item in para)
//            {

//                if (item.Value == null)
//                {
//                    result[i] = new ReportParameter(item.Key, string.Empty);
//                }
//                else
//                {
//                    switch (item.Value.GetType().Name)
//                    {
//                        case "String":
//                            result[i] = new ReportParameter(item.Key, (string)item.Value);
//                            break;
//                        case "String[]":
//                            result[i] = new ReportParameter(item.Key, (string[])item.Value);
//                            break;
//                        default:
//                            throw new Exception("Parameters只能輸入String或String[]");
//                    }
//                }

//                i++;
//            }

//            return result;
//        }
    }
}
