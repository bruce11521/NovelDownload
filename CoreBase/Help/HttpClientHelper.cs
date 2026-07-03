using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoreBase.Utilities;
using Newtonsoft.Json;

namespace CoreBase.Help
{
    /// <summary>
    /// HttpClient Helper
    /// </summary>
    public class HttpClientHelper
    {
        #region Parameter

        /// <summary>
        /// 鎖定物件
        /// </summary>
        private static readonly object LockObj = new object();
        /// <summary>
        /// HttpClient Instatnce
        /// </summary>
        private static HttpClient _httpClient = null;
        /// <summary>
        /// HttpClient Instance
        /// </summary>
        public HttpClient HttpClientInstance => _httpClient;
        /// <summary>
        /// httpClientHandler
        /// </summary>
        private static HttpClientHandler httpClientHandler = null;

        /// <summary>
        /// 預設HttpClient逾時時間 預設30秒
        /// </summary>
        private TimeSpan _DefaultTimeOut = new TimeSpan(0, 0, 0, 30);
        
        /// <summary>
        /// 是否啟用 EnsureSuccessStatusCode,當失敗時候擲出錯誤(預設False)
        /// </summary>
        public bool EnabledEnsureSuccessStatusCode = false;
        /// <summary>
        /// HTTPS SSL錯誤LOG, 最多50個
        /// </summary>
        public static List<(string URL, string SSLError, string ErrorMsg, DateTime CallDateTime)> HTTPS_SSL_ERRORLOGLIST =
            new List<(string URL, string SSLError, string ErrorMsg, DateTime CallDateTime)>();
        /// <summary>
        /// 設定呼叫Https 時發生SslPolicyErrors時，該如何判斷憑證 (使用ServerCertificateCustomValidationCallback =>{}判斷) [預設數值:Null]
        /// Null :使用預設邏輯，Return 伺服器端SslPolicyErrors == SslPolicyErrors.None ;
        /// True :忽略所有伺服器端回傳SslPolicyErrors，全部設定為"接受憑證繼續通訊請求" Return True;
        /// False:忽略所有伺服器端回傳SslPolicyErrors，全部設定為"拒絕憑證中斷連線" Return False;
        /// </summary>
        public static bool? SetHttpsSslValidationStatus = null;
        #endregion

        #region Instance
        /// <summary>
        /// Init初始化
        /// 如果 使用 CancellationTokenSource(Timeout)來設定HttpClient Timeout且 > 30 秒時, 建議初始化時將傳入Timeout.InfiniteTimeSpan
        /// 因為HttpClient預設Timeout為100秒，HttpClient是以HttpClient.Timeout 或是 CancellationTokenSource(Timeout) 兩者先碰到時回傳逾時Exception
        /// </summary>
        /// <param name="SetMaxTimeout">若傳入參數需大於 10ms，預設為3秒</param>
        public HttpClientHelper(TimeSpan? SetMaxTimeout = null)
        {
            GetInstance();
            if (SetMaxTimeout.HasValue)
            {
                SetTimeOut(SetMaxTimeout);
            }
        }
        /// <summary>
        /// 錯誤日誌
        /// </summary>
        /// <returns>List&lt;(string URL, string SSLError, string ErrorMsg, DateTime CallDateTime)&gt;</returns>
        public List<(string URL, string SSLError, string ErrorMsg, DateTime CallDateTime)> GetErrorList()
        {
            return HTTPS_SSL_ERRORLOGLIST;
        }
        /// <summary>
        /// 取得呼叫Https 時發生SslPolicyErrors時，該如何判斷憑證 (使用ServerCertificateCustomValidationCallback =>{}判斷) [預設數值:Null]
        /// Null :使用預設邏輯，Return 伺服器端SslPolicyErrors == SslPolicyErrors.None ;
        /// True :忽略所有伺服器端回傳SslPolicyErrors，全部設定為"接受憑證繼續通訊請求" Return True;
        /// False:忽略所有伺服器端回傳SslPolicyErrors，全部設定為"拒絕憑證中斷連線" Return False; 
        /// </summary>
        /// <returns>bool?</returns>
        public bool? Get_SetHttpsSslValidationStatus()
        {
            return SetHttpsSslValidationStatus;
        }
        /// <summary>
        /// 設定呼叫Https 時發生SslPolicyErrors時，該如何判斷憑證 (使用ServerCertificateCustomValidationCallback =>{}判斷) [預設數值:Null]
        /// Null :使用預設邏輯，Return 伺服器端SslPolicyErrors == SslPolicyErrors.None ;
        /// True :忽略所有伺服器端回傳SslPolicyErrors，全部設定為"接受憑證繼續通訊請求" Return True;
        /// False:忽略所有伺服器端回傳SslPolicyErrors，全部設定為"拒絕憑證中斷連線" Return False;
        /// </summary>
        /// <param name="SetValue"></param>
        /// <returns></returns>
        public bool Set_SetHttpsSslValidationStatus(bool? SetValue)
        {
            SetHttpsSslValidationStatus = SetValue;
            return true;
        }

        /// <summary>
        /// Static Instance 
        /// </summary>
        /// <returns></returns>
        public static HttpClient GetInstance()
        {
            if (_httpClient == null)
            {
                lock (LockObj)
                {
                    if (_httpClient == null)
                    {
                        //httpClientHandler = new HttpClientHandler()
                        //{
                        //    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => false,
                        //};
                        httpClientHandler = new HttpClientHandler()
                        {
                            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                            {
                                //Console.WriteLine("呼叫 URL:" + message.RequestUri);
                                //Console.WriteLine("SSL 錯誤:" + errors);
                                var errorMsg = string.Empty;
                                foreach (var status in chain.ChainStatus)
                                {
                                    //Console.WriteLine($"[{status.Status}_{status.Status.ToNumberString()}] 錯誤細節:{status.StatusInformation}");
                                    errorMsg += $"[{status.Status}_{status.Status.ToNumberString()}] 錯誤細節:{status.StatusInformation}" + Environment.NewLine;
                                }
                                //Console.WriteLine($"回傳:{errors == SslPolicyErrors.None}.");
                                if (HTTPS_SSL_ERRORLOGLIST.Count >= 50)
                                {
                                    //若List.Count超過50個則移除第一個
                                    HTTPS_SSL_ERRORLOGLIST.RemoveAt(0);
                                }
                                HTTPS_SSL_ERRORLOGLIST.Add((message.RequestUri.AbsoluteUri, errors.ToString(), errorMsg, DateTime.Now));
                                switch (SetHttpsSslValidationStatus)
                                {
                                    case null:
                                        return errors == SslPolicyErrors.None;
                                    case true:
                                        return true;
                                    case false:
                                        return false;
                                }
                            },
                        };
                        try
                        {
                            var os = Environment.OSVersion.Version;
                            if (os.Major == 6 && os.Minor == 1)
                            {
                                //Win7
                                httpClientHandler.SslProtocols = SslProtocols.Tls12;
                            }
                            else if (os.Major == 10)
                            {
                                //win10 / win11, 
                                //讓OS自行判斷
                            }
                        }
                        catch
                        {
                            httpClientHandler.SslProtocols = SslProtocols.Tls12;

                        }
                        //SslProtocols.Tls13 .NetFramWork 4.8不支援

                        _httpClient = new HttpClient(httpClientHandler);
                        //if (SetMaxTimeout.HasValue)
                        //{
                        //    if (SetMaxTimeout.Value > TimeSpan.FromMilliseconds(10))
                        //    {
                        //        _httpClient.Timeout = SetMaxTimeout.Value;
                        //    }
                        //}
                        //https://blog.yowko.com/httpclient-issue/
                        //共用的 HttpClient 可能會無法即時反應 DNS 的異動
                        //將 HttpClient 的 DefaultRequestHeaders.ConnectionClose 屬性設定為 true，
                        //(也就是將 HTTP 的 keep-alive header 設為 false，讓 socket 在每次處理完 request 即關閉)
                        //這樣增加大約 35 ms 的時間耗損，也失去了重複使用 socket 的好處，比較適用於每次 request 損耗 35 ms 不會造成影響的情境
                        //_httpClient.DefaultRequestHeaders.ConnectionClose = true;

                        //修改 ConnectionLeaseTimeout 時間 : 用來管理 TCP socket 保持開啟的時間，預設為 -1 永遠開啟
                        //ServicePointManager.FindServicePoint(baseUri).ConnectionLeaseTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;

                        //修改 DnsRefreshTimeout 時間: 用來管理 DNS 更新間隔，預設為 120000 (兩分鐘)
                        //ServicePointManager.DnsRefreshTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
                        //兩者皆應視實際使用情境調整
                    }
                }
            }
            return _httpClient;
        }
        /// <summary>
        /// 取得HttpClient逾時秒數
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetTimeOut()
        {
            return _DefaultTimeOut;
        }
        /// <summary>
        /// 設定HttpClient逾時秒數
        /// 可設定逾時區間:100毫秒~600秒
        /// </summary>
        /// <param name="_SetTs">秒</param>
        /// <returns></returns>
        public bool SetTimeOut(int _SetTs = 10)
        {
            if (_SetTs< 0)
            {
                _SetTs = 0;
            }
            var ts = TimeSpan.FromMilliseconds(_SetTs * 1000);
            return SetTimeOut_Interface(ts);
        }
        /// <summary>
        /// 設定HttpClient逾時秒數
        /// 可設定逾時區間:100毫秒~600秒
        /// </summary>
        /// <param name="_SetTs">毫秒</param>
        /// <returns></returns>
        public bool SetTimeOut(TimeSpan? _SetTs = null)
        {
            return SetTimeOut_Interface(_SetTs);
        }
        /// <summary>
        /// 設定HttpClient逾時秒數
        /// 可設定逾時區間:100毫秒~600秒
        /// </summary>
        /// <param name="_SetTs"></param>
        /// <returns></returns>
        private bool SetTimeOut_Interface(TimeSpan? _SetTs = null)
        {
            try
            {
                if (_SetTs.HasValue)
                {
                    if (_SetTs > TimeSpan.FromMilliseconds(600 * 1000))
                    {
                        _SetTs = TimeSpan.FromMilliseconds(600 * 1000);
                    }
                    if (_SetTs < TimeSpan.FromMilliseconds(100))
                    {
                        _SetTs = TimeSpan.FromMilliseconds(100);
                    }
                    _DefaultTimeOut = _SetTs.Value;
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// 設定特定網站，於多久後強迫關閉連線來重新解析DNS
        /// </summary>
        /// <param name="DNS_Server_Uri">特定網站 URI網址</param>
        /// <param name="KeepTCPTime">於多久後逾時，並自動關閉連線</param>
        /// <returns></returns>
        public bool SetHttpClientDefalutRequesterHeaders(string DNS_Server_Uri, TimeSpan? KeepTCPTime)
        {
            var sp = ServicePointManager.FindServicePoint(new Uri(DNS_Server_Uri));
            if (KeepTCPTime.HasValue)
            {
                var timeoutSeconds = KeepTCPTime.Value.TotalMilliseconds.ToInt();
                if (timeoutSeconds > 0)
                {
                    sp.ConnectionLeaseTimeout = timeoutSeconds;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 設定  DNS 更新間隔，預設為 120,000ms (兩分鐘)
        /// </summary>
        /// <param name="RefreshDnsTime">參數需大於 0 ，如未給予則會設定預設數值2分鐘</param>
        /// <returns></returns>
        public bool SetHttpClientDNSRefreshTimeout(TimeSpan? RefreshDnsTime)
        {
            if (RefreshDnsTime.HasValue)
            {
                var timeoutSeconds = RefreshDnsTime.Value.TotalMilliseconds.ToInt();
                if (timeoutSeconds > 0)
                {
                    ServicePointManager.DnsRefreshTimeout = timeoutSeconds;
                    return true;
                }
            }
            else
            {
                ServicePointManager.DnsRefreshTimeout = TimeSpan.FromMinutes(2).TotalMilliseconds.ToInt();
                return true;
            }
            return false;
        }
        #endregion


        #region Get Methods

        /// <summary>
        /// 取得 API 資料 (GetAsync)
        /// 底層已實作 ConfigureAwait(false) 以降低死結風險。
        /// </summary>
        /// <typeparam name="T">回傳之Model</typeparam>
        /// <param name="requestUrl">URL網址</param>
        /// <param name="cancellationToken">取消權杖</param>
        /// <returns>ServiceResult</returns>
        public async Task<ServiceResult<T>> GetAsync<T>(string requestUrl, CancellationToken cancellationToken = default)
        {
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
            var sourceJson = string.Empty;
            HttpResponseMessage response = null;

            try
            {
                // 1. 加入 ConfigureAwait(false) 防止上層阻塞造成的死結
                using (response = await _httpClient.GetAsync(requestUrl, cancellationToken).ConfigureAwait(false))
                {
                    // 2. 若為 .NET 5+，ReadAsStringAsync 也支援傳入 cancellationToken
#if NET5_0_OR_GREATER
            sourceJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
#else
                    sourceJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
                    returnResult.IsOk = response.IsSuccessStatusCode;
                    returnResult.Message += $"API呼叫成功，回傳狀態[{response.StatusCode.ToString()}]" + Environment.NewLine;
                    returnResult.Code = response.StatusCode.ToNumberValue();
                    returnResult.Content = sourceJson;

                    if (EnabledEnsureSuccessStatusCode && returnResult.IsOk == false)
                    {
                        response.EnsureSuccessStatusCode();
                    }
                    if (typeof(T) == typeof(string))
                    {
                        returnResult.Data = (T)(object)sourceJson;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(sourceJson))
                        {
                            returnResult.Data = JsonConvert.DeserializeObject<T>(sourceJson);
                        }
                        else
                        {
                            returnResult.Data = default;
                        }
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                returnResult.IsOk = false;
                returnResult.Content = sourceJson;
                returnResult.Exception = ex;

                // 3. 判斷是主動取消還是逾時
                var err = ex.GetInnerException();
                if (cancellationToken.IsCancellationRequested)
                {
                    returnResult.Message = "作業已被主動取消。" + Environment.NewLine + err.ErrorMessage;
                }
                else
                {
                    returnResult.Message = "連線作業逾時。" + Environment.NewLine + err.ErrorMessage;
                }
            }
            catch (HttpRequestException ex) when (ex?.InnerException is WebException we && we?.InnerException is SocketException se)
            {
                var err = ex.GetInnerException();
                returnResult.IsOk = false;
                returnResult.Code = -1;
                returnResult.Message = "無法建立連線，伺服器未啟動或被阻擋。" + Environment.NewLine + err.ErrorMessage;
                returnResult.Content = sourceJson;
                returnResult.Exception = ex;
            }
            catch (Exception ex)
            {
                if (response != null)
                {
                    returnResult.Code = response.StatusCode.ToNumberValue();
                }
                returnResult.IsOk = false;
                returnResult.Exception = ex;

                // 注意：GetInnerException() 和 ErrorMessage 似乎是您自訂的擴充方法，我保留原寫法
                returnResult.Message += "錯誤擲出:" + Environment.NewLine + ex.GetInnerException().ErrorMessage;
                returnResult.Content = sourceJson;
            }

            return returnResult;
        }

        /// <summary>
        /// 取得 API 資料 (GetAsync)
        /// 底層已實作 ConfigureAwait(false) 以降低死結風險。
        /// </summary>
        /// <typeparam name="T">回傳之Model</typeparam>
        /// <param name="requestUrl">URL網址</param>
        /// <param name="cancellationToken">取消權杖</param>
        /// <returns>ServiceResult</returns>
        public ServiceResult<T> Get<T>(string requestUrl, CancellationToken cancellationToken = default)
        {
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
            var sourceJson = string.Empty;
            HttpResponseMessage response = null;

            try
            {
                // 1. 加入 ConfigureAwait(false) 防止上層阻塞造成的死結
                using (response = _httpClient.GetAsync(requestUrl, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult())
                {
                    sourceJson = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                    returnResult.IsOk = response.IsSuccessStatusCode;
                    returnResult.Message += $"API呼叫成功，回傳狀態[{response.StatusCode.ToString()}]" + Environment.NewLine;
                    returnResult.Code = response.StatusCode.ToNumberValue();
                    returnResult.Content = sourceJson;

                    if (EnabledEnsureSuccessStatusCode && returnResult.IsOk == false)
                    {
                        response.EnsureSuccessStatusCode();
                    }
                    if (typeof(T) == typeof(string))
                    {
                        returnResult.Data = (T)(object)sourceJson;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(sourceJson))
                        {
                            returnResult.Data = JsonConvert.DeserializeObject<T>(sourceJson);
                        }
                        else
                        {
                            returnResult.Data = default;
                        }
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                returnResult.IsOk = false;
                returnResult.Content = sourceJson;
                returnResult.Exception = ex;

                // 3. 判斷是主動取消還是逾時
                var err = ex.GetInnerException();
                if (cancellationToken.IsCancellationRequested)
                {
                    returnResult.Message = "作業已被主動取消。" + Environment.NewLine + err.ErrorMessage;
                }
                else
                {
                    returnResult.Message = "連線作業逾時。" + Environment.NewLine + err.ErrorMessage;
                }
            }
            catch (HttpRequestException ex) when (ex?.InnerException is WebException we && we?.InnerException is SocketException se)
            {
                var err = ex.GetInnerException();
                returnResult.IsOk = false;
                returnResult.Code = -1;
                returnResult.Message = "無法建立連線，伺服器未啟動或被阻擋。" + Environment.NewLine + err.ErrorMessage;
                returnResult.Content = sourceJson;
                returnResult.Exception = ex;
            }
            catch (Exception ex)
            {
                if (response != null)
                {
                    returnResult.Code = response.StatusCode.ToNumberValue();
                }
                returnResult.IsOk = false;
                returnResult.Exception = ex;

                // 注意：GetInnerException() 和 ErrorMessage 似乎是您自訂的擴充方法，我保留原寫法
                returnResult.Message += "錯誤擲出:" + Environment.NewLine + ex.GetInnerException().ErrorMessage;
                returnResult.Content = sourceJson;
            }

            return returnResult;
        }

        #endregion

        #region POST Methods

        /// <summary>
        /// Post 非同步方法
        /// [需確保不能使用UI Thread呼叫，否則會造成死結]
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="url">網址</param>
        /// <param name="contentJson">Post Data</param>
        /// <returns>Model , 失敗或是Exception 回傳 default</returns>
        public async Task<ServiceResult<T>> PostAsync<T>(string url, string contentJson, CancellationToken cts = default)
        {
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
            var sourceJson = string.Empty;
            HttpResponseMessage response = null;
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                //cts.CancelAfter(timeout.Value);
                HttpContent content = new StringContent(contentJson ?? string.Empty, System.Text.Encoding.UTF8, "application/json");
                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await _httpClient.PostAsync(url, content, cts);
                if (EnabledEnsureSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
                sourceJson = await response?.Content?.ReadAsStringAsync() ?? string.Empty;
                returnResult.Message = $"API呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]" + Environment.NewLine;
                returnResult.Code = response?.StatusCode.ToNumberValue() ?? 0;
                returnResult.IsOk = response?.IsSuccessStatusCode ?? false;
                returnResult.Content = sourceJson;
                if (EnabledEnsureSuccessStatusCode && returnResult.IsOk == false)
                {
                    response?.EnsureSuccessStatusCode();
                }
                if (typeof(T) == typeof(string))
                {
                    returnResult.Data = (T)(object)sourceJson;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(sourceJson))
                    {
                        returnResult.Data = JsonConvert.DeserializeObject<T>(sourceJson);
                    }
                    else
                    {
                        returnResult.Data = default;
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                if (response != null)
                {
                    var statusCode = response?.StatusCode;
                    returnResult.Code = statusCode.ToNumberValue();
                }
                returnResult.IsOk = false;
                returnResult.Message = $"連線作業逾時，" + ex.GetOriginalException().Message;
                returnResult.Exception = ex;
                returnResult.Content = sourceJson;
            }
            catch (HttpRequestException ex) when (ex?.InnerException is WebException we && we?.InnerException is SocketException se)
            {
                returnResult.IsOk = false;
                returnResult.Code = -1;
                returnResult.Message = $"無法建立連線，伺服器未啟動或被阻擋。" + Environment.NewLine + ex.GetInnerException().ErrorMessage;
                returnResult.Content = sourceJson;
                returnResult.Exception = ex;
            }
            catch (Exception ex)
            {
                if (response != null)
                {
                    var statusCode = response?.StatusCode;
                    returnResult.Code = statusCode.ToNumberValue();
                }
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message += "錯誤擲出:" + ex.GetInnerException().ErrorMessage;
                returnResult.Content = sourceJson;
                //if (cts.IsCancellationRequested is true)
                //{
                //    returnResult.Message = $"連線作業逾時，" + ex.GetOriginalException().Message;
                //}
                //else
                //{
                //    returnResult.Message = "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                //}
            }
            return returnResult;
        }
        /// <summary>
        /// Post 同步方法
        /// </summary>
        /// <typeparam name="T">Mdoel</typeparam>
        /// <param name="url">網址</param>
        /// <param name="contentJson">Post Data</param>
        /// <returns>Model , 失敗或是Exception 回傳 default</returns>
        public ServiceResult<T> Post<T>(string url, string contentJson, CancellationToken cts = default)
        {
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
            var sourceJson = string.Empty;
            HttpResponseMessage response = null;
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                //cts.CancelAfter(timeout.Value);
                HttpContent content = new StringContent(contentJson ?? string.Empty, System.Text.Encoding.UTF8, "application/json");
                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = _httpClient.PostAsync(url, content, cts).GetAwaiter().GetResult();
                sourceJson = response?.Content?.ReadAsStringAsync().GetAwaiter().GetResult();
                returnResult.Message = $"API呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]" + Environment.NewLine;
                returnResult.Code = response?.StatusCode.ToNumberValue() ?? 0;
                returnResult.IsOk = response?.IsSuccessStatusCode ?? false;
                returnResult.Content = sourceJson;
                if (EnabledEnsureSuccessStatusCode && returnResult.IsOk == false)
                {
                    response?.EnsureSuccessStatusCode();
                }
                if (typeof(T) == typeof(string))
                {
                    returnResult.Data = (T)(object)sourceJson;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(sourceJson))
                    {
                        returnResult.Data = JsonConvert.DeserializeObject<T>(sourceJson);
                    }
                    else
                    {
                        returnResult.Data = default;
                    }
                }
                return returnResult;
            }
            catch (OperationCanceledException ex)
            {
                if (response != null)
                {
                    var statusCode = response?.StatusCode;
                    returnResult.Code = statusCode.ToNumberValue();
                }
                returnResult.IsOk = false;
                returnResult.Message = $"連線作業逾時，" + ex.GetOriginalException().Message;
                returnResult.Exception = ex;
                returnResult.Content = sourceJson;
            }
            catch (HttpRequestException ex) when (ex?.InnerException is WebException we && we?.InnerException is SocketException se)
            {
                returnResult.IsOk = false;
                returnResult.Code = -1;
                returnResult.Message = $"無法建立連線，伺服器未啟動或被阻擋。" + Environment.NewLine + ex.GetInnerException().ErrorMessage;
                returnResult.Content = sourceJson;
                returnResult.Exception = ex;
            }
            catch (Exception ex)
            {
                if (response != null)
                {
                    var statusCode = response?.StatusCode;
                    returnResult.Code = statusCode.ToNumberValue();
                }
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message += "錯誤擲出:" + ex.GetInnerException().ErrorMessage;
                returnResult.Content = sourceJson;
                //if (cts.IsCancellationRequested is true)
                //{
                //    returnResult.Message += $"連線作業逾時，" + ex.GetOriginalException().Message;
                //}
                //else
                //{
                //    returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                //}
            }
            return returnResult;
        }
        #endregion

        #region DELETE Methods

        /// <summary>
        /// Delete 非同步方法
        /// [需確保不能使用UI Thread呼叫(即使使用.Resut也是)，否則會造成死結]
        /// </summary>
        /// <param name="url">網址</param>
        /// <returns>JSON string, 失敗或是Exception時候回傳Null</returns>
        public async Task<ServiceResult<T>> DeletAsync<T>(string url, CancellationToken cts = default)
        {
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
            var sourceJson = string.Empty;
            HttpResponseMessage response = null;
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                //cts.CancelAfter(timeout.Value);
                using (response = await _httpClient.DeleteAsync(url, cts))
                {
                    sourceJson = await response.Content.ReadAsStringAsync();
                    returnResult.Message = $"API呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]" + Environment.NewLine;
                    returnResult.Code = response?.StatusCode.ToNumberValue() ?? 0;
                    returnResult.IsOk = response?.IsSuccessStatusCode ?? false;
                    returnResult.Content = sourceJson;
                    if (EnabledEnsureSuccessStatusCode && returnResult.IsOk == false)
                    {
                        response?.EnsureSuccessStatusCode();
                    }
                    if (typeof(T) == typeof(string))
                    {
                        returnResult.Data = (T)(object)sourceJson;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(sourceJson))
                        {
                            returnResult.Data = JsonConvert.DeserializeObject<T>(sourceJson);
                        }
                        else
                        {
                            returnResult.Data = default;
                        }
                    }
                    return returnResult;
                }
            }
            catch (OperationCanceledException ex)
            {
                if (response != null)
                {
                    var statusCode = response?.StatusCode;
                    returnResult.Code = statusCode.ToNumberValue();
                }
                returnResult.IsOk = false;
                returnResult.Message = $"連線作業逾時，" + ex.GetOriginalException().Message;
                returnResult.Exception = ex;
                returnResult.Content = sourceJson;
            }
            catch (HttpRequestException ex) when (ex?.InnerException is WebException we && we?.InnerException is SocketException se)
            {
                returnResult.IsOk = false;
                returnResult.Code = -1;
                returnResult.Message = $"無法建立連線，伺服器未啟動或被阻擋。" + Environment.NewLine + ex.GetInnerException().ErrorMessage;
                returnResult.Content = sourceJson;
                returnResult.Exception = ex;
            }
            catch (Exception ex)
            {
                if (response != null)
                {
                    var statusCode = response?.StatusCode;
                    returnResult.Code = statusCode.ToNumberValue();
                }
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message += "錯誤擲出:" + ex.GetInnerException().ErrorMessage;
                returnResult.Content = sourceJson;
                //if (cts.IsCancellationRequested is true)
                //{
                //    returnResult.Message += $"連線作業逾時，" + ex.GetOriginalException().Message;
                //}
                //else
                //{
                //    returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                //}
            }
            return returnResult;
        }

        #endregion

        #region PUT Methods

        /// <summary>
        /// Put 非同步方法
        /// [需確保不能使用UI Thread呼叫(即使使用.Resut也是)，否則會造成死結]
        /// </summary>
        /// <param name="url">網址</param>
        /// <param name="contentJson">Put Data</param>
        /// <returns>JSON string, 失敗或是Exception時候回傳Null</returns>
        public async Task<ServiceResult<T>> PutAsync<T>(string url, string contentJson, CancellationToken cts = default)
        {
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
            var sourceJson = string.Empty;
            HttpResponseMessage response = null;
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                //cts.CancelAfter(timeout.Value);
                var content = new StringContent(contentJson ?? string.Empty, Encoding.UTF8, "application/json");
                using (response = await _httpClient.PutAsync(url, content, cts))
                {
                    sourceJson = await response.Content.ReadAsStringAsync();
                    returnResult.Message = $"API呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]" + Environment.NewLine;
                    returnResult.Code = response?.StatusCode.ToNumberValue() ?? 0;
                    returnResult.IsOk = response?.IsSuccessStatusCode ?? false;
                    returnResult.Content = sourceJson;
                    if (EnabledEnsureSuccessStatusCode && returnResult.IsOk == false)
                    {
                        response?.EnsureSuccessStatusCode();
                    }
                    if (typeof(T) == typeof(string))
                    {
                        returnResult.Data = (T)(object)sourceJson;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(sourceJson))
                        {
                            returnResult.Data = JsonConvert.DeserializeObject<T>(sourceJson);
                        }
                        else
                        {
                            returnResult.Data = default;
                        }
                    }
                    return returnResult;
                }
            }
            catch (OperationCanceledException ex)
            {
                if (response != null)
                {
                    var statusCode = response?.StatusCode;
                    returnResult.Code = statusCode.ToNumberValue();
                }
                returnResult.IsOk = false;
                returnResult.Message = $"連線作業逾時，" + ex.GetOriginalException().Message;
                returnResult.Exception = ex;
                returnResult.Content = sourceJson;
            }
            catch (HttpRequestException ex) when (ex?.InnerException is WebException we && we?.InnerException is SocketException se)
            {
                returnResult.IsOk = false;
                returnResult.Code = -1;
                returnResult.Message = $"無法建立連線，伺服器未啟動或被阻擋。" + Environment.NewLine + ex.GetInnerException().ErrorMessage;
                returnResult.Content = sourceJson;
                returnResult.Exception = ex;
            }
            catch (Exception ex)
            {
                if (response != null)
                {
                    var statusCode = response?.StatusCode;
                    returnResult.Code = statusCode.ToNumberValue();
                }
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message += "錯誤擲出:" + ex.GetInnerException().ErrorMessage;
                returnResult.Content = sourceJson;
                //if (cts.IsCancellationRequested is true)
                //{
                //    returnResult.Message += $"連線作業逾時，" + ex.GetOriginalException().Message;
                //}
                //else
                //{
                //    returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                //}
            }
            return returnResult;
        }

        #endregion

        #region Get IP Address Methods
        /// <summary>
        /// 取得Client IP
        /// </summary>
        /// <param name="usePublicIp">取的公用網路IP[預設:False]</param>
        /// <returns></returns>
        public ServiceResult<string> GetClientIp(bool usePublicIp = false)
        {
            ServiceResult<string> returnResult = new ServiceResult<string>(false, string.Empty, string.Empty);
            try
            {
                if (usePublicIp)
                {
                    var publicIp = _httpClient.GetStringAsync("https://google.com.tw").GetAwaiter().GetResult();
                    returnResult.Data = publicIp?.Trim() ?? string.Empty;

                    returnResult.Message = "公網IP取得成功!";
                }
                else
                {
                    var ipInfo = NetworkInterface.GetAllNetworkInterfaces()
                        .Where(x => x.OperationalStatus == OperationalStatus.Up &&
                                    x.NetworkInterfaceType != NetworkInterfaceType.Loopback)// 檢查網卡是否啟用
                        .SelectMany(x => x.GetIPProperties().UnicastAddresses)
                        .Where(ip =>
                            ip.Address.AddressFamily == AddressFamily.InterNetwork &&
                            !ip.Address.ToString().StartsWith("169.254"))//避免取得APIPA
                        .Select(x => x.Address.ToString())
                        ?.FirstOrDefault() ?? string.Empty;
                    returnResult.Data = ipInfo;
                    returnResult.Message = "內網IP取得成功!";
                }
                returnResult.IsOk = true;
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message = "THROW:" + ex.GetInnerException().ErrorMessage;
            }

            return returnResult;
        }

        #endregion


    }



    //public static class HttpClientHelper
    //{
    //    public static async Task<HttpResponseMessage> SendAsyncWithTimeout(this HttpClient httpClient,
    //        HttpRequestMessage request, int timeoutIntMs)
    //    {
    //        return await httpClient.SendAsyncWithTimeout(request, TimeSpan.FromMilliseconds(timeoutIntMs));
    //    }

    //    public static async Task<HttpResponseMessage> SendAsyncWithTimeout(this HttpClient httpClient,
    //        HttpRequestMessage request, TimeSpan timeout)
    //    {
    //        using var cls = new CancellationTokenSource(timeout);
    //        try
    //        {
    //            return await httpClient.SendAsync(request, cls.Token);
    //        }
    //        catch (OperationCanceledException) when (!cls.Token.IsCancellationRequested)
    //        {
    //            throw new TimeoutException();
    //        }
    //    }
    //}


    #region Better timeout handling with HttpClient
    //Title: Better timeout handling with HttpClient
    //https://thomaslevesque.com/2018/02/25/better-timeout-handling-with-httpclient/
    //GitHub Source
    //https://gist.github.com/thomaslevesque/b4fd8c3aa332c9582a57935d6ed3406f

    #region HttpRequestExtensions

    /// <summary>
    /// Timeout Handle
    /// </summary>
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// HttpRequestMessage.Properties["RequestTimeout"] 文字參數
        /// </summary>
        private const string TimeoutPropertKey = "RequestTimeout";
        /// <summary>
        /// 設定Timeout
        /// </summary>
        /// <param name="request">HttpRequestMessage</param>
        /// <param name="timeOut">SetValue</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetTimeout(this HttpRequestMessage request, TimeSpan? timeOut)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            request.Properties[TimeoutPropertKey] = timeOut;
        }
        /// <summary>
        /// 取得Timeout 
        /// </summary>
        /// <param name="request">HttpRequestMessage</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TimeSpan? GetTimeout(this HttpRequestMessage request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Properties.TryGetValue(TimeoutPropertKey, out var value) && value is TimeSpan timeout)
                return timeout;
            return null;
        }
    }

    #endregion

    #region TimeoutHandler
    /// <summary>
    /// HttpResponseMessage Timeout Handler
    /// When Create HttpClient, it's possible to specify the first handler of the pipline.
    /// 當建立HttpClient時候，需 new Timeouthandler(){ InnerHandler = new HttpClientHandler() } 並把 Timeouthandler 當作參數傳入HttpClient建構子中
    /// </summary>
    public class TimeoutHandler : DelegatingHandler
    {
        /*
         *
         */


        /// <summary>
        /// 逾時時間 (預設100秒)
        /// </summary>
        public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromSeconds(100);
        /// <summary>
        /// Override method to throwing the correct Exception! 
        /// If the request’s timeout is infinite, we don’t create a CancellationTokenSource; it would never be canceled, so we save a useless allocation.
        /// If not, we create a CancellationTokenSource that will be canceled after the timeout is elapsed (CancelAfter).
        /// Note that this CTS is linked to the CancellationToken we receive as a parameter in SendAsync: this way,
        /// it will be canceled either when the timeout expires, or when the CancellationToken parameter will itself be canceled.
        /// You can get more details on linked cancellation tokens in this article.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="TimeoutException"></exception>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            using (var cts = GetCancellationTokenSource(request, cancellationToken))
            {
                try
                {
                    return await base.SendAsync(request, cts?.Token ?? cancellationToken);
                }
                catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                {
                    throw new TimeoutException();
                }
                catch
                {
                    throw;
                }
            }
        }

        

        /// <summary>
        /// 抓取 Timeout CancellationTokenSource
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private CancellationTokenSource GetCancellationTokenSource(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var timeout = request.GetTimeout() ?? DefaultTimeout;
            if (timeout == Timeout.InfiniteTimeSpan)
            {
                // No need to create a CTS if there' no timeout
                return null;
            }
            else
            {
                var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                cts.CancelAfter(timeout);
                return cts;
            }
        }
    }

    #endregion

    #endregion

}
