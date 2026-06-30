using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace CoreBase.Help
{
    /// <summary>
    /// FTP Helper
    /// </summary>
    public class FTPHelp
    {
        /// <summary>
        /// FTP Attribute
        /// </summary>
        public FtpAttribute _FtpAttribute = new FtpAttribute();

        #region Public Class
        /// <summary>
        /// Ftp Attribute
        /// </summary>
        public class FtpAttribute
        {
            /// <summary>
            /// init
            /// </summary>
            public FtpAttribute()
            {
                Port = 21;
                KeepAliveIntSecond = 60 * 1000;
            }
            /// <summary>
            /// 主機名稱
            /// </summary>
            public string HostName { get; set; }
            /// <summary>
            /// 連接埠
            /// </summary>
            public int Port { get; set; }
            /// <summary>
            /// 使用者ID
            /// </summary>
            public string UserID { get; set; }
            /// <summary>
            /// 使用者密碼
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// 連結存活秒數(預設60秒,最大10分鐘)
            /// </summary>
            public int KeepAliveSecond
            {
                get
                {
                    return KeepAliveIntSecond / 1000;
                }
                set
                {
                    if (value < 0)
                    {
                        KeepAliveIntSecond = 1 * 1000;
                    }
                    else if (value > 600)
                    {
                        KeepAliveIntSecond = 600 * 1000;
                    }
                    else
                    {
                        KeepAliveIntSecond = value * 1000;
                    }
                }
            }
            /// <summary>
            /// 秒數 * 1000
            /// </summary>
            public int KeepAliveIntSecond { get; private set; }

            /// <summary>
            /// FTP簡短網址(不含帳密)
            /// </summary>
            public string URL
            {
                get
                {
                    return string.Format("ftp://{0}:{1}", HostName, Port);
                }
            }
            /// <summary>
            /// FTP完整網址(包含帳密)
            /// </summary>
            public string FullURL
            {
                get
                {
                    return string.Format("ftp://{0}:{1}@{2}:{3}", UserID, Password, HostName, Port);
                }
            }
        }
        /// <summary>
        /// FtpResult 
        /// </summary>
        public class FTPResult : ServiceResult
        {
            /// <summary>
            /// FtpResult
            /// </summary>
            public FTPResult()
            {
                this.IsOk = false;
                this.Message = string.Empty;
                statusCode = FtpStatusCode.Undefined;
                statusDescription = FtpStatusCode.Undefined.ToString();
                contentLength = 0;
                directoryList = new List<FTPListDirectoryDetail>();
                executeLog = new List<string>();
            }
            /// <summary>
            /// FtpResult
            /// </summary>
            /// <param name="isOk"></param>
            /// <param name="Message"></param>
            public FTPResult(bool isOk, string Message)
            {
                this.IsOk = isOk;
                this.Message = Message;
                statusCode = FtpStatusCode.Undefined;
                statusDescription = FtpStatusCode.Undefined.ToString();
                contentLength = 0;
                directoryList = new List<FTPListDirectoryDetail>();
                executeLog = new List<string>();
            }

            /// <summary>
            /// FTP StatusCode 狀態Code
            /// </summary>
            public FtpStatusCode statusCode { get; set; }
            /// <summary>
            /// FTP StatusCode 狀態碼文字
            /// </summary>
            public string statusDescription { get; set; }
            /// <summary>
            /// FTP 資料長度
            /// </summary>
            public long contentLength { get; set; }
            /// <summary>
            /// FTP 回傳列表
            /// </summary>
            public List<FTPListDirectoryDetail> directoryList { get; set; }
            /// <summary>
            /// 執行步驟
            /// </summary>
            public List<string> executeLog { get; set; }
        }

        public class FTPListDirectoryDetail
        {
            /// <summary>
            /// 權限(drexrexrex)
            /// </summary>
            public string Attribute { get; set; }
            /// <summary>
            /// 檔案或目錄類型
            /// </summary>
            public string Type { get; set; }
            /// <summary>
            /// 連結
            /// </summary>
            public string Links { get; set; }
            /// <summary>
            /// 擁有者
            /// </summary>
            public string Owner { get; set; }
            /// <summary>
            /// 群組
            /// </summary>
            public string Group { get; set; }
            /// <summary>
            /// 檔案大小
            /// </summary>
            public string FileSize { get; set; }
            /// <summary>
            /// 最後修改時間-月
            /// </summary>
            public string Month { get; set; }
            /// <summary>
            /// 最後修改時間-日
            /// </summary>
            public string Day { get; set; }
            /// <summary>
            /// 最後修改時間-年或時間
            /// </summary>
            public string YearTime { get; set; }
            /// <summary>
            /// 最後修改時間
            /// </summary>
            public DateTime? LastModifyDateTime { get; set; }
            /// <summary>
            /// 檔案名稱
            /// </summary>
            public string FileName { get; set; }
            /// <summary>
            /// 清單轉換失敗 原始字串
            /// </summary>
            public string RowString { get; set; }
        }

        #endregion



        #region Constructor

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="HostName"></param>
        /// <param name="Port"></param>
        /// <param name="UserID"></param>
        /// <param name="Password"></param>
        public FTPHelp(string HostName, int Port, string UserID, string Password)
        {
            _FtpAttribute.HostName = HostName;
            if (Port > 0 && Port <= 65536)
            {
                _FtpAttribute.Port = Port;
            }
            else
            {
                _FtpAttribute.Port = 21;
            }
            _FtpAttribute.UserID = UserID;
            _FtpAttribute.Password = Password;
        }
        /// <summary>
        /// LocalHost + Anonymous
        /// </summary>
        public FTPHelp() : this("localhost", 21, "anonymous", string.Empty)
        {
        }
        /// <summary>
        /// 使用預設21連接埠
        /// </summary>
        /// <param name="HostName"></param>
        /// <param name="UserID"></param>
        /// <param name="Password"></param>
        public FTPHelp(string HostName, string UserID, string Password) : this(HostName, 21, UserID, Password)
        {
        }

        #endregion

        #region Private Method

        /// <summary>
        /// 取得FtpWebRequest
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="keepAlive"></param>
        /// <param name="timeout"></param>
        /// <returns> 當URL 建立失敗則會回傳Null</returns>
        private FtpWebRequest GetFtpWebRequest(string url, string method, bool keepAlive, int timeout = 60 * 1000)
        {
            if (FtpWebRequest.Create(url) is FtpWebRequest request)
            {
                request.Credentials = new NetworkCredential(_FtpAttribute.UserID, _FtpAttribute.Password);
                request.Method = method;
                request.KeepAlive = keepAlive;
                if (timeout < 1000)
                {
                    timeout = 1000;
                }
                request.Timeout = timeout;
                return request;
            }
            else
            {
                return null;
            }
        }

        private string PathToUri(string path)
        {
            //傳入絕對路徑，不變
            if (path.Length >= 6 && "ftp://".Equals(path?.Substring(0, 6)?.ToLower()) is true)
            {
                return path;
            }
            //傳入空字串或根目錄符號，改成URL
            if (string.IsNullOrEmpty(path) || ".".Equals(path) || "/".Equals(path))
            {
                return _FtpAttribute.URL;
            }
            //傳入其他相對路徑，URL+path
            return _FtpAttribute.URL + path;

        }

        #endregion

        #region Public Method
        /// <summary>
        /// 登入
        /// </summary>
        /// <returns></returns>
        public FTPResult Login()
        {
            FTPResult returnResult = new FTPResult(false, string.Empty);
            FtpWebRequest request = null;
            FtpWebResponse response = null;
            try
            {
                request = GetFtpWebRequest(_FtpAttribute.URL, WebRequestMethods.Ftp.ListDirectory, true, _FtpAttribute.KeepAliveIntSecond);
                if (request == null)
                {
                    returnResult.IsOk = false;
                    returnResult.Message += $"[URI:{_FtpAttribute.URL}], FTP伺服器未回應或是建立連線失敗! Request = null!";
                    return returnResult;
                }
                using (response = request.GetResponse() as FtpWebResponse)
                {
                    returnResult.IsOk = true;
                    returnResult.Message = "連線成功!";
                    returnResult.statusCode = response.StatusCode;
                    returnResult.statusDescription = response.StatusDescription;
                    returnResult.contentLength = response.ContentLength;
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message = "連線失敗";
                returnResult.Exception = ex;
            }
            finally
            {
                request = null;
                response = null;
            }
            return returnResult;
        }
        /// <summary>
        /// 下載檔案
        /// </summary>
        /// <param name="downloadPath">FTP 下載檔案路徑</param>
        /// <param name="savePath">本地儲存路徑(完整檔案路徑)</param>
        /// <param name="progressDecimal">進度</param>
        /// <returns></returns>
        public FTPResult DownloadFile(string downloadPath, string savePath, ref decimal progressDecimal)
        {
            FTPResult returnResult = new FTPResult(false, string.Empty);
            FtpWebRequest request = null;
            FtpWebResponse response = null;
            Stream ftpStream = null;
            //顯示用檔案大小
            int FileSize = 0;
            //計算下載進度之檔案大小
            double CountFileSize = 0;
            try
            {
                string URI = PathToUri(downloadPath);
                savePath = "H:\\";
                var previousPath = Directory.GetParent(savePath);
                if (previousPath == null || previousPath?.Exists is false)
                {
                    var displayPath = string.Empty;
                    if (previousPath == null)
                    {
                        displayPath = Directory.GetDirectoryRoot(savePath);
                    }
                    else
                    {
                        displayPath = previousPath?.FullName;
                    }
                    returnResult.Message = $"[儲存目錄:{displayPath}]\n不存在!";
                    return returnResult;
                }
                request = GetFtpWebRequest(URI, WebRequestMethods.Ftp.GetFileSize, true, _FtpAttribute.KeepAliveIntSecond);
                var fileSizeLong = request.GetResponse().ContentLength;
                returnResult.executeLog.Add($"取得FTP伺服器上檔案大小:{fileSizeLong}.");
                if (fileSizeLong >= 0)
                {
                    FileSize = Convert.ToInt32(fileSizeLong);
                    CountFileSize = Convert.ToDouble(fileSizeLong);
                }
                else
                {
                    returnResult.Message = $"FTP遠端伺服器上該檔案大小:{fileSizeLong},小於 0 bytes!";
                    return returnResult;
                }
                progressDecimal = 0m;
                request = GetFtpWebRequest(URI, WebRequestMethods.Ftp.DownloadFile, true, _FtpAttribute.KeepAliveIntSecond);
                if (request == null)
                {
                    returnResult.IsOk = false;
                    returnResult.Message += $"[URI:{URI}], FTP伺服器未回應或是建立連線失敗! Request = null!";
                    return returnResult;
                }
                returnResult.executeLog.Add($"開始下載FTP伺服器上檔案.");

                using (response = request.GetResponse() as FtpWebResponse)
                {
                    returnResult.statusCode = response.StatusCode;
                    returnResult.statusDescription = response.StatusDescription;
                    returnResult.executeLog.Add($"取得FTP伺服器上檔案Response成功.");
                    using (ftpStream = response.GetResponseStream() as Stream)
                    {
                        returnResult.executeLog.Add($"取得FTP伺服器上檔案串流成功.");
                        using (FileStream fileStream = new FileStream(savePath, FileMode.Create))
                        {
                            returnResult.executeLog.Add($"本地端檔案I/O建立寫入串流成功[預設緩衝區大小2048 bytes].");
                            int buffersize = 2048;
                            byte[] buffer = new byte[buffersize];
                            double progressValue = 0;
                            int readCount = ftpStream.Read(buffer, 0, buffersize);
                            returnResult.executeLog.Add($"[{DateTime.Now.ToFullDateTimeMillisecond()}]開始讀取FTP檔案串流,並寫入至本地端中...");
                            while (readCount > 0)
                            {
                                fileStream.Write(buffer, 0, readCount);
                                readCount = ftpStream.Read(buffer, 0, buffersize);
                                progressValue += Convert.ToDouble(fileStream.Length);
                                progressDecimal = Convert.ToDecimal(progressValue / CountFileSize).ToRound(5) * 100;
                            }
                            returnResult.executeLog.Add($"[{DateTime.Now.ToFullDateTimeMillisecond()}]FTP檔案串流寫入至本地端完成![FTP伺服器上檔案大小:{FileSize},實際下載檔案大小:{Convert.ToInt32(fileStream.Length)}]");
                            if (fileStream.Length == FileSize)
                            {
                                returnResult.IsOk = true;
                                returnResult.Message = "下載成功!";
                                returnResult.statusCode = response.StatusCode;
                                returnResult.statusDescription = response.StatusDescription;
                                returnResult.contentLength = response.ContentLength;
                            }
                            else
                            {
                                returnResult.IsOk = false;
                                returnResult.Message = $"下載失敗!\nFTP檔案大小:{FileSize}.\n實際下載檔案大小:{Convert.ToInt32(fileStream.Length)}.";
                                returnResult.statusCode = response.StatusCode;
                                returnResult.statusDescription = response.StatusDescription;
                                returnResult.contentLength = response.ContentLength;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message += "FTP檔案下載失敗! THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            finally
            {
                request = null;
                response = null;
                ftpStream = null;
            }
            return returnResult;
        }
        /// <summary>
        /// 上傳檔案
        /// </summary>
        /// <param name="uploadPath">上傳FTP路徑</param>
        /// <param name="filePath">本地端上傳檔案路徑</param>
        /// <param name="progressDecimal">進度</param>
        /// <returns></returns>
        public FTPResult UploadFile(string uploadPath, string filePath, ref decimal progressDecimal)
        {
            FTPResult returnResult = new FTPResult(false, string.Empty);
            FtpWebRequest request = null;
            FtpWebResponse response = null;
            Stream ftpStream = null;
            //檔案大小
            int FileSize = 0;
            //計算上傳進度之檔案大小
            double CountFileSize = 0;
            try
            {
                string URI = PathToUri(uploadPath);
                var fileInfo = new FileInfo(filePath);
                if (fileInfo.Exists is false)
                {
                    returnResult.Message = $"上傳檔案:{filePath}.\n不存在!";
                    return returnResult;
                }

                var fileSizeLong = fileInfo.Length;
                returnResult.executeLog.Add($"取得欲上傳檔案大小:{fileSizeLong}.");
                FileSize = Convert.ToInt32(fileSizeLong);
                CountFileSize = Convert.ToDouble(fileSizeLong);

                progressDecimal = 0m;
                request = GetFtpWebRequest(URI, WebRequestMethods.Ftp.UploadFile, true, _FtpAttribute.KeepAliveIntSecond);
                if (request == null)
                {
                    returnResult.IsOk = false;
                    returnResult.Message += $"[URI:{URI}], FTP伺服器未回應或是建立連線失敗! Request = null!";
                    return returnResult;
                }
                returnResult.executeLog.Add($"開始傳送上傳檔案需求到FTP伺服器.");
                using (ftpStream = request.GetRequestStream() as Stream)
                {
                    returnResult.executeLog.Add($"取得FTP伺服器上檔案串流成功.");
                    using (FileStream fileStream = File.OpenRead(filePath))
                    {
                        returnResult.executeLog.Add($"本地端檔案I/O建立上傳串流成功[預設緩衝區大小2048 bytes].");
                        int buffersize = 2048;
                        byte[] buffer = new byte[buffersize];
                        double progressValue = 0;
                        int readCount = fileStream.Read(buffer, 0, buffersize);
                        returnResult.executeLog.Add($"[{DateTime.Now.ToFullDateTimeMillisecond()}]開始上傳檔案串流到FTP伺服器中...");
                        while (readCount > 0)
                        {
                            ftpStream.Write(buffer, 0, readCount);
                            readCount = fileStream.Read(buffer, 0, buffersize);
                            progressValue += Convert.ToDouble(fileStream.Length);
                            progressDecimal = Convert.ToDecimal(progressValue / CountFileSize).ToRound(5) * 100;
                        }

                        returnResult.executeLog.Add(
                            $"[{DateTime.Now.ToFullDateTimeMillisecond()}]上傳檔案串流到FTP伺服器完成![實際上傳檔案大小:{Convert.ToInt32(fileStream.Length)}]");
                    }

                    using (response = request.GetResponse() as FtpWebResponse)
                    {
                        returnResult.IsOk = true;
                        returnResult.Message = "上傳檔案成功!";
                        returnResult.statusCode = response.StatusCode;
                        returnResult.statusDescription = response.StatusDescription;
                        returnResult.executeLog.Add($"取得上傳檔案到FTP伺服器Response成功.");
                        returnResult.contentLength = response.ContentLength;
                    }
                }

            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message += "FTP檔案上傳失敗! THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            finally
            {
                request = null;
                response = null;
                ftpStream = null;
            }
            return returnResult;
        }
        /// <summary>
        /// 刪除檔案
        /// </summary>
        /// <param name="deleteFilePath">刪除檔案路徑</param>
        /// <param name="progressDecimal">進度</param>
        /// <returns></returns>
        public FTPResult DeleteFile(string deleteFilePath)
        {
            FTPResult returnResult = new FTPResult(false, string.Empty);
            FtpWebRequest request = null;
            FtpWebResponse response = null;
            try
            {
                string URI = PathToUri(deleteFilePath);
                request = GetFtpWebRequest(URI, WebRequestMethods.Ftp.DeleteFile, true, _FtpAttribute.KeepAliveIntSecond);
                if (request == null)
                {
                    returnResult.IsOk = false;
                    returnResult.Message += $"[URI:{URI}], FTP伺服器未回應或是建立連線失敗! Request = null!";
                    return returnResult;
                }
                returnResult.executeLog.Add($"開始傳送刪除檔案需求到FTP伺服器.");
                using (response = request.GetResponse() as FtpWebResponse)
                {
                    returnResult.IsOk = true;
                    returnResult.Message = "刪除檔案成功!";
                    returnResult.statusCode = response.StatusCode;
                    returnResult.statusDescription = response.StatusDescription;
                    returnResult.executeLog.Add($"取得FTP伺服器刪除檔案Response成功.");
                    returnResult.contentLength = response.ContentLength;
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message += "刪除FTP檔案失敗! THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            finally
            {
                request = null;
                response = null;

            }
            return returnResult;
        }
        /// <summary>
        /// 取得檔案大小
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public FTPResult GetFileSize(string filePath)
        {
            FTPResult returnResult = new FTPResult(false, string.Empty);
            FtpWebRequest request = null;
            FtpWebResponse response = null;
            try
            {
                string URI = PathToUri(filePath);
                request = GetFtpWebRequest(URI, WebRequestMethods.Ftp.GetFileSize, true, _FtpAttribute.KeepAliveIntSecond);
                if (request == null)
                {
                    returnResult.IsOk = false;
                    returnResult.Message += $"[URI:{URI}], FTP伺服器未回應或是建立連線失敗! Request = null!";
                    return returnResult;
                }
                using (response = request.GetResponse() as FtpWebResponse)
                {
                    returnResult.IsOk = true;
                    returnResult.Message = "檔案大小取得成功!";
                    returnResult.statusCode = response.StatusCode;
                    returnResult.statusDescription = response.StatusDescription;
                    returnResult.contentLength = response.ContentLength;
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message += "FTP檔案大小取得失敗! THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            finally
            {
                request = null;
                response = null;
            }
            return returnResult;
        }
        /// <summary>
        /// 更改檔案或目錄名稱
        /// </summary>
        /// <param name="oldName">欲更改之檔案或目錄名稱</param>
        /// <param name="newName">新命名名稱</param>
        /// <returns></returns>
        public FTPResult ReName(string oldName, string newName)
        {
            FTPResult returnResult = new FTPResult(false, string.Empty);
            FtpWebRequest request = null;
            FtpWebResponse response = null;
            try
            {
                string URI = PathToUri(oldName);

                request = GetFtpWebRequest(URI, WebRequestMethods.Ftp.Rename, true, _FtpAttribute.KeepAliveIntSecond);
                if (request == null)
                {
                    returnResult.IsOk = false;
                    returnResult.Message += $"[URI:{URI}], FTP伺服器未回應或是建立連線失敗! Request = null!";
                    return returnResult;
                }
                returnResult.executeLog.Add($"FTP伺服器上檔案或目錄重新命名Request成功.");
                request.RenameTo = newName;
                using (response = request.GetResponse() as FtpWebResponse)
                {
                    returnResult.IsOk = true;
                    returnResult.Message = "檔案或目錄重新命名成功!";
                    returnResult.statusCode = response.StatusCode;
                    returnResult.statusDescription = response.StatusDescription;
                    returnResult.contentLength = response.ContentLength;
                    returnResult.executeLog.Add($"FTP伺服器上檔案或目錄重新命名Response成功.[異動前:{oldName}][異動後:{newName}]");
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message += "FTP檔案或目錄重新命名失敗! THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            finally
            {
                request = null;
                response = null;
            }
            return returnResult;
        }
        /// <summary>
        /// 取得目錄清單
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public FTPResult ListDirectory(string path, string type)
        {
            FTPResult returnResult = new FTPResult(false, string.Empty);
            FtpWebRequest request = null;
            FtpWebResponse response = null;
            try
            {
                string URI = string.Empty;
                if (string.IsNullOrEmpty(path) || ".".Equals(path) || "/".Equals(path))
                {
                    URI = _FtpAttribute.URL;
                }
                else
                {
                    URI = PathToUri(path);
                }
                request = GetFtpWebRequest(URI, WebRequestMethods.Ftp.ListDirectoryDetails, true, -1);
                if (request == null)
                {
                    returnResult.IsOk = false;
                    returnResult.Message += $"[URI:{URI}], FTP伺服器未回應或是建立連線失敗! Request = null!";
                    return returnResult;
                }
                returnResult.executeLog.Add($"取得FTP伺服器上檔案目錄清單Request成功.");
                using (response = request.GetResponse() as FtpWebResponse)
                {
                    var directoryList = new List<string>();
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string directory = reader.ReadLine();
                        while (directory != null)
                        {
                            if (directory.Contains(type))
                            {
                                directoryList.Add(directory);
                            }
                            directory = reader.ReadLine();
                        }
                    }
                    var ftpDirectoryDetailList = ConvertToFtpClass(directoryList);
                    if (ftpDirectoryDetailList.IsOk is false)
                    {
                        returnResult.Message = "取得FTP檔案目錄清單成功!" + ftpDirectoryDetailList.Message;
                    }
                    else
                    {
                        returnResult.Message = "取得FTP檔案目錄清單成功!";
                    }
                    returnResult.directoryList = ftpDirectoryDetailList.Data;

                    returnResult.IsOk = true;
                    //returnResult.Message = "取得檔案目錄清單成功!";
                    returnResult.statusCode = response.StatusCode;
                    returnResult.statusDescription = response.StatusDescription;
                    returnResult.contentLength = response.ContentLength;
                    returnResult.executeLog.Add($"取得FTP伺服器上檔案目錄清單Response成功.");
                    returnResult.directoryList = ftpDirectoryDetailList.Data;
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message += "取得FTP檔案目錄清單失敗! THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            finally
            {
                request = null;
                response = null;
            }
            return returnResult;
        }
        /// <summary>
        /// 建立目錄
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public FTPResult MakeDirectory(string directoryPath)
        {
            FTPResult returnResult = new FTPResult(false, string.Empty);
            FtpWebRequest request = null;
            FtpWebResponse response = null;
            try
            {
                string URI = PathToUri(directoryPath);

                request = GetFtpWebRequest(URI, WebRequestMethods.Ftp.MakeDirectory, true, _FtpAttribute.KeepAliveIntSecond);
                if (request == null)
                {
                    returnResult.IsOk = false;
                    returnResult.Message += $"[URI:{URI}], FTP伺服器未回應或是建立連線失敗! Request = null!";
                    return returnResult;
                }
                using (response = request.GetResponse() as FtpWebResponse)
                {
                    returnResult.IsOk = true;
                    returnResult.Message = "新增目錄成功!";
                    returnResult.statusCode = response.StatusCode;
                    returnResult.statusDescription = response.StatusDescription;
                    returnResult.contentLength = response.ContentLength;
                    returnResult.executeLog.Add($"取得FTP伺服器新增目錄Request成功.");
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message += "新增目錄失敗! THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            finally
            {
                request = null;
                response = null;
            }
            return returnResult;
        }
        /// <summary>
        /// 移除目錄
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public FTPResult RemoveDirectory(string directoryPath)
        {
            FTPResult returnResult = new FTPResult(false, string.Empty);
            FtpWebRequest request = null;
            FtpWebResponse response = null;
            try
            {
                string URI = PathToUri(directoryPath);

                request = GetFtpWebRequest(URI, WebRequestMethods.Ftp.RemoveDirectory, true, _FtpAttribute.KeepAliveIntSecond);
                if (request == null)
                {
                    returnResult.IsOk = false;
                    returnResult.Message += $"[URI:{URI}], FTP伺服器未回應或是建立連線失敗! Request = null!";
                    return returnResult;
                }
                using (response = request.GetResponse() as FtpWebResponse)
                {
                    returnResult.IsOk = true;
                    returnResult.Message = "移除目錄成功!";
                    returnResult.statusCode = response.StatusCode;
                    returnResult.statusDescription = response.StatusDescription;
                    returnResult.contentLength = response.ContentLength;
                    returnResult.executeLog.Add($"取得FTP伺服器移除目錄Request成功.");
                }
            }
            catch (Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Message += "移除目錄失敗! THROW:" + ex.GetInnerException().ErrorMessage;
                returnResult.Exception = ex;
            }
            finally
            {
                request = null;
                response = null;
            }
            return returnResult;
        }
        /// <summary>
        /// 轉換FTP List清單
        /// </summary>
        /// <param name="directoryList"></param>
        /// <returns>isOk:True=轉換成功且有資料, False=轉換失敗或是無資料; Code:1=成功,-1=部分資料轉換失敗,0=未進行轉換</returns>
        public ServiceResult<List<FTPListDirectoryDetail>> ConvertToFtpClass(List<string> directoryList)
        {
            ServiceResult<List<FTPListDirectoryDetail>> returnResult = new ServiceResult<List<FTPListDirectoryDetail>>(false, string.Empty, new List<FTPListDirectoryDetail>());
            if (directoryList?.Any() is true)
            {
                //取的Match.Group.Names
                var groupNames = RegexUtility.FtpListDirectoryDetailsRegex.GetGroupNames();
                foreach (var item in directoryList)
                {
                    //match.Groups[0~2] =>Alwasy [0]=Match.Value, [1]=Entire Match, [2]=Last Match, 每一個RegexMatchGroups至少會有1~3個Group
                    Match match = RegexUtility.FtpListDirectoryDetailsRegex.Match(item ?? string.Empty);
                    
                    if (match.Success)
                    {
                        if (match.Groups.Count > 0)
                        {
                            FTPListDirectoryDetail ftpItem = new FTPListDirectoryDetail();
                            var nameCaptureDirctory = new Dictionary<string, object>();
                            foreach (string groupName in groupNames)
                            {
                                if (match.Groups[groupName].Captures.Count > 0)
                                {
                                    nameCaptureDirctory.Add(groupName, match.Groups[groupName].Value);
                                }
                            }
                            ftpItem = new FTPListDirectoryDetail().MappingSource(nameCaptureDirctory);

                            if (RegexUtility.MonthShortNameRegex.IsMatch(ftpItem.Month ?? string.Empty))
                            {
                                if (RegexUtility.DayRegex.IsMatch(ftpItem.Day ?? string.Empty))
                                {
                                    if (DateTime.TryParseExact(ftpItem.Month, "MMM", CultureInfo.InvariantCulture, DateTimeStyles.None,
                                            out var month))
                                    {
                                        if (RegexUtility.YearRegex.IsMatch(ftpItem.YearTime ?? string.Empty))
                                        {
                                            //非今年
                                            ftpItem.LastModifyDateTime = new DateTime(ftpItem.YearTime.ToInt(),
                                                month.Month, ftpItem.Day.ToInt());
                                        }
                                        else if (RegexUtility.TimeHHmmRegex.IsMatch(ftpItem.YearTime ?? string.Empty))
                                        {
                                            //今年
                                            var hours = ftpItem.YearTime.Split(':');
                                            if (hours.Length == 2)
                                            {
                                                ftpItem.LastModifyDateTime = new DateTime(DateTime.Now.Year,
                                                    month.Month, ftpItem.Day.ToInt(), hours[0].ToInt(), hours[1].ToInt(), 0);
                                            }
                                            else
                                            {
                                                ftpItem.LastModifyDateTime = new DateTime(DateTime.Now.Year,
                                                    month.Month, ftpItem.Day.ToInt());
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ftpItem.RowString = item;
                                    }
                                }
                                else
                                {
                                    ftpItem.RowString = item;
                                }
                            }
                            else
                            {
                                ftpItem.RowString = item;
                            }
                            returnResult.Data.Add(ftpItem);
                        }
                        else
                        {
                            returnResult.Data.Add(new FTPListDirectoryDetail()
                            {
                                RowString= item,
                            });
                        }
                    }
                    else
                    {
                        returnResult.Data.Add(new FTPListDirectoryDetail()
                        {
                            RowString = item,
                        });
                    }
                }

                if (returnResult.Data.Any(x => !string.IsNullOrWhiteSpace(x.RowString)))
                {
                    returnResult.IsOk = false;
                    returnResult.Code = -1;
                    returnResult.Message += $"部分資料轉換格式失敗，失敗資料已經存到{nameof(FTPListDirectoryDetail.RowString)}中.";
                }
                else
                {
                    returnResult.IsOk = true;
                    returnResult.Code = 1;
                    returnResult.Message += "資料轉換成功!";
                }
            }
            else
            {
                returnResult.IsOk = false;
                returnResult.Message += "傳入陣列中無資料!";
            }

            return returnResult;
        }


        #endregion




    }
}
