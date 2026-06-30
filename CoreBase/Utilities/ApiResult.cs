using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CoreBase.Utilities
{
    /// <summary>
    /// API Model
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// httpClient 需要時候再初始化
        /// </summary>
        private static HttpClient _httpClient = null;

        static ApiResult()
        {
            _httpClient = new HttpClient();
        }
        /// <summary>
        /// 強迫.Net在 10分鐘後關閉httpClient連線，待下次重建連線將會重新解析DNS
        /// </summary>
        /// <param name="_url"></param>
        /// <returns></returns>
        public bool reloadingDNSRecord(Uri _url)
        {
            try
            {
                if (_url is null)
                {
                    return false;
                }
                var sp = ServicePointManager.FindServicePoint(_url);
                sp.ConnectionLeaseTimeout = 600 * 1000;//10分鐘
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        //public ApiResult(bool isInitHttpClient = false)
        //{
        //    _httpClient = new HttpClient();
        //}


        
        /// <summary>
        /// General API Return List Result
        /// </summary>
        /// <typeparam name="T">General T Model</typeparam>
        /// <param name="API_Url">URL 網址</param>
        /// <param name="MethodName">方法:GET, POST</param>
        /// <param name="POST_Data">要POST的資料</param>
        /// <returns></returns>
        public (List<T> ReturnModelList, HttpStatusCode HttpStatusCode) GetAPIReturnListResult<T>(string API_Url, string MethodName, object POST_Data = null, int ResponeTimeOut = 30000)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(API_Url) && !string.IsNullOrWhiteSpace(MethodName))
                {
                    if (new Regex(@"^(https)?:\/\/(.*)", RegexOptions.IgnoreCase).IsMatch(API_Url ?? string.Empty))
                    {
                        ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                        //若出現 "基礎連接已關閉: 無法為 SSL/TLS 安全通道建立信任關係" 錯誤 則啟用下面程式碼    ReferralURL https://blog.darkthread.net/blog/webclient-ssl-dismatch/
                        //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    }
                    HttpWebRequest request = WebRequest.Create($"{API_Url}") as HttpWebRequest;
                    request.ContentType = "application/json";
                    request.Timeout = ResponeTimeOut;
                    switch (MethodName)
                    {
                        case "GET":
                            // 取得回應資料
                            request.Method = MethodName;
                            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                            {
                                var _Reponse = sr.ReadToEnd();
                                var GetResult = JsonConvert.DeserializeObject<List<T>>(_Reponse);
                                if (GetResult != null)
                                {
                                    return (GetResult, response.StatusCode);
                                }
                            }
                            break;
                        case "POST":
                            request.Method = MethodName;
                            using (Stream stream = request.GetRequestStream())
                            {
                                if (POST_Data != null)
                                {
                                    string st = JsonConvert.SerializeObject(POST_Data);
                                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(st);
                                    stream.Write(byteArray, 0, byteArray.Length);
                                    HttpWebResponse getResponse = request.GetResponse() as HttpWebResponse;
                                    using (StreamReader sr = new StreamReader(getResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                                    {
                                        var PostResult = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
                                        if (PostResult != null)
                                        {
                                            return (PostResult, getResponse.StatusCode);
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                return (default, HttpStatusCode.BadRequest);
            }
            catch(Exception ex)
            {
                if (ex is WebException exw)
                {
                    if (exw.Response is null)
                    {
                        throw;
                    }
                    else
                    {
                        using (WebResponse respone = exw.Response)
                        {
                            if (respone is HttpWebResponse httpWebResponse) 
                            {
                                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                                {
                                    List<T> PostResult = default;
                                    try
                                    {
                                        PostResult = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
                                    }
                                    catch
                                    {
                                        return (default, httpWebResponse.StatusCode);
                                    }
                                    if (PostResult != null)
                                    {
                                        return (PostResult, httpWebResponse.StatusCode);
                                    }
                                    else
                                    {
                                        return (default, httpWebResponse.StatusCode);
                                    }
                                }
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }
                else
                {
                    throw;
                }   
            }
        }


        /// <summary>
        ///  General API Return Result
        /// </summary>
        /// <typeparam name="T">General List T Model</typeparam>
        /// <param name="API_Url">URL 網址</param>
        /// <param name="MethodName">方法:GET, POST</param>
        /// <param name="POST_Data">要POST的資料</param>
        /// <returns></returns>
        public (T ReturnModel, HttpStatusCode HttpStatusCode) GetAPIReturnResult<T>(string API_Url, string MethodName, object POST_Data = null, int ResponeTimeOut = 30000)
        {
            HttpWebRequest request = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(API_Url) && !string.IsNullOrWhiteSpace(MethodName))
                {
                    if (new Regex(@"^(https)?:\/\/(.*)", RegexOptions.IgnoreCase).IsMatch(API_Url ?? string.Empty))
                    {
                        ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 ;
                        //若出現 "基礎連接已關閉: 無法為 SSL/TLS 安全通道建立信任關係" 錯誤 則啟用下面程式碼    ReferralURL https://blog.darkthread.net/blog/webclient-ssl-dismatch/
                        //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    }
                    #region WebClient 
                    //WebClient webClient = new WebClient();
                    //webClient.Encoding = Encoding.UTF8;
                    //webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                    //string st1 = JsonConvert.SerializeObject(POST_Data);
                    //byte[] byteArray1 = System.Text.Encoding.UTF8.GetBytes(st1);

                    //byte[] response1 = webClient.UploadData(API_Url, "POST", byteArray1);
                    //string responseStr = Encoding.UTF8.GetString(response1);
                    //T result = JsonConvert.DeserializeObject<T>(responseStr);
                    //var status = webClient.ResponseHeaders.AllKeys;
                    //return (result, HttpStatusCode.OK);
                    #endregion


                    request = WebRequest.Create($"{API_Url}") as HttpWebRequest;
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    if (ResponeTimeOut < 10000)
                    {
                        ResponeTimeOut = 10000;
                    }
                    request.Timeout = ResponeTimeOut;
                    request.ServicePoint.Expect100Continue = false;
                    switch (MethodName)
                    {
                        case "GET":
                            // 取得回應資料
                            request.Method = MethodName;
                            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                            {
                                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                                {
                                    var _Reponse = sr.ReadToEnd();
                                    var GetResult = JsonConvert.DeserializeObject<T>(_Reponse);
                                    if (GetResult != null)
                                    {
                                        return (GetResult, response.StatusCode);
                                    }
                                }
                            }
                            break;
                        case "POST":
                            request.Method = MethodName;
                            //Stream stream = request.GetRequestStream();
                            using (Stream stream = request.GetRequestStream())
                            {
                                if (POST_Data != null)
                                {
                                    string st = JsonConvert.SerializeObject(POST_Data);
                                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(st);
                                    stream.Write(byteArray, 0, byteArray.Length);
                                    HttpWebResponse getResponse = request.GetResponse() as HttpWebResponse;
                                    using (StreamReader sr = new StreamReader(getResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                                    {
                                        var PostResult = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                                        if (PostResult != null)
                                        {
                                            return (PostResult, getResponse.StatusCode);
                                        }
                                    }

                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                return default;
            }
            catch(Exception ex)
            {
                if (ex is WebException exw)
                {
                    if (exw.Response is null)
                    {
                        throw;
                    }
                    else
                    {
                        using (WebResponse respone = exw.Response)
                        {
                            if (respone is HttpWebResponse httpWebResponse)
                            {
                                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                                {
                                    T PostResult = default;
                                    try
                                    {
                                        PostResult = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                                    }
                                    catch
                                    {
                                        return (default, httpWebResponse.StatusCode);
                                    }
                                    if (PostResult != null)
                                    {
                                        return (PostResult, httpWebResponse.StatusCode);
                                    }
                                    else
                                    {
                                        return (default, httpWebResponse.StatusCode);
                                    }
                                }
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }
                else
                {
                    throw;
                }
            }
        }




        #region 非同步 ASYNC METHOD
        /// <summary>
        /// WebClient (非同步)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="API_Url">URL</param>
        /// <param name="MethodName">方法:Get, Post...[WebRequestMethods.Http.]</param>
        /// <param name="POST_Data">Post Data</param>
        /// <param name="ResponeTimeOut">逾時毫秒, 預設30000</param>
        /// <returns></returns>
        public async Task<HttpStatusCode> GetWebClientReturnResultAsync(string API_Url, UploadDataCompletedEventHandler WebClient_UploadDataCompleted, object POST_Data = null, int ResponeTimeOut = 30000)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(API_Url))
                {
                    if (new Regex(@"^(https)?:\/\/(.*)", RegexOptions.IgnoreCase).IsMatch(API_Url ?? string.Empty))
                    {
                        ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                        //若出現 "基礎連接已關閉: 無法為 SSL/TLS 安全通道建立信任關係" 錯誤 則啟用下面程式碼    ReferralURL https://blog.darkthread.net/blog/webclient-ssl-dismatch/
                        //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    }
                    if(ResponeTimeOut < 5000)
                    {
                        ResponeTimeOut = 5000;
                    }
                    WebClient webClient = new WebClient_Cutsom(ResponeTimeOut);
                    webClient.Encoding = Encoding.UTF8;
                    webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    
                    
                    byte[] PostArray = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(POST_Data));
                    if(WebClient_UploadDataCompleted != null)
                    {
                        webClient.UploadDataCompleted += new UploadDataCompletedEventHandler(WebClient_UploadDataCompleted);
                    }
                    webClient.UploadDataAsync(new Uri(API_Url), WebRequestMethods.Http.Post, PostArray);

                }
                return default;
            }
            catch(WebException ex)
            {
                if(ex.Status == WebExceptionStatus.ProtocolError)
                {
                    if(ex.Response is HttpWebResponse response && response != null)
                    {
                        return response.StatusCode;
                    }
                }
                return default;
            }
            catch
            {
                throw;
            }
        }

        

        public class WebClient_Cutsom : WebClient 
        {
            public WebClient_Cutsom(int Timeout)
            {
                Set_Timeout = Timeout;
            }
            private int Set_Timeout { get; set; }
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest webRequest = base.GetWebRequest(address);
                webRequest.Timeout = Set_Timeout;
                return webRequest;
            }
        }


        /// <summary>
        /// HttpClient (非同步)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="API_Url">URL 網址</param>
        /// <param name="POST_Data">要POST的資料</param>
        /// <param name="ActiveErrorThrow">是否在StatusCode非200時候擲出錯誤</param>
        /// <param name="ResponeTimeOut">逾時時間[預設30000毫秒]</param>
        /// <returns>(T, HttpStatusCode HttpStatusCode)</returns>
        public async Task<(T ReturnModel, HttpStatusCode HttpStatusCode, string ErrorMessage)> GetHttpClientPostReturnResultAsync<T>(string API_Url, object POST_Data = null, bool ActiveErrorThrow = true, int ResponeTimeOut = 30000)
        {
            HttpStatusCode errorHttpStatusCode = HttpStatusCode.BadRequest;
            try
            {
                if (!string.IsNullOrWhiteSpace(API_Url))
                {
                    if (new Regex(@"(?i)^https://", RegexOptions.IgnoreCase).IsMatch(API_Url ?? string.Empty))
                    {
                        ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    }
                }
                
                if (ResponeTimeOut < 10000)
                {
                    ResponeTimeOut = 10000;
                }
                //_httpClient.Timeout = TimeSpan.FromMilliseconds(ResponeTimeOut);
                //_httpClient.DefaultRequestHeaders.Accept.Clear();
                //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var CancellationTokenSource_ = new CancellationTokenSource(_httpClient.Timeout);

                HttpContent httpcContent = new StringContent(JsonConvert.SerializeObject(POST_Data), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(API_Url, httpcContent, CancellationTokenSource_.Token);
               
                if (response.IsSuccessStatusCode is false)
                {
                    errorHttpStatusCode = response.StatusCode;
                }
                if (ActiveErrorThrow)
                {
                    response.EnsureSuccessStatusCode();
                }

                if (response.IsSuccessStatusCode is true)
                {
                    var outPutString = await response?.Content?.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(outPutString))
                    {
                        T result = await response?.Content?.ReadAsAsync<T>() ?? default;
                        return (result, response.StatusCode, string.Empty);
                    }
                    else
                    {
                        return (default, response.StatusCode, "回傳訊息為空數值!");
                    }
                }
                else
                {
                    var outPutString = await response?.Content?.ReadAsStringAsync();
                    return (default, response.StatusCode, outPutString);
                }
            }
            catch(Exception ex)
            {
                if (ex is HttpRequestException exhre)
                {
                    return (default, errorHttpStatusCode, exhre.Message);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        ///  General API Return Result (非同步)
        /// </summary>
        /// <typeparam name="T">General List T Model</typeparam>
        /// <param name="API_Url">URL 網址</param>
        /// <param name="MethodName">方法:GET, POST[WebRequestMethods.Http.]</param>
        /// <param name="POST_Data">要POST的資料</param>
        /// <returns></returns>
        public async Task<(T ReturnModel, HttpStatusCode HttpStatusCode)> GetAPIReturnResultAsync<T>(string API_Url, string MethodName, object POST_Data = null, int ResponeTimeOut = 30000)
        {
            HttpWebRequest request = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(API_Url))
                {
                    if (new Regex(@"^(https)?:\/\/(.*)", RegexOptions.IgnoreCase).IsMatch(API_Url ?? string.Empty))
                    {
                        ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                        //若出現 "基礎連接已關閉: 無法為 SSL/TLS 安全通道建立信任關係" 錯誤 則啟用下面程式碼    ReferralURL https://blog.darkthread.net/blog/webclient-ssl-dismatch/
                        //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    }
                    #region WebClient 
                    //WebClient webClient = new WebClient();
                    //webClient.Encoding = Encoding.UTF8;
                    //webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                    //string st1 = JsonConvert.SerializeObject(POST_Data);
                    //byte[] byteArray1 = System.Text.Encoding.UTF8.GetBytes(st1);

                    //byte[] response1 = webClient.UploadData(API_Url, "POST", byteArray1);
                    //string responseStr = Encoding.UTF8.GetString(response1);
                    //T result = JsonConvert.DeserializeObject<T>(responseStr);
                    //var status = webClient.ResponseHeaders.AllKeys;
                    //return (result, HttpStatusCode.OK);
                    #endregion


                    request = WebRequest.Create($"{API_Url}") as HttpWebRequest;
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    if (ResponeTimeOut < 10000)
                    {
                        ResponeTimeOut = 10000;
                    }
                    request.Timeout = ResponeTimeOut;
                    request.ServicePoint.Expect100Continue = false;
                    switch (MethodName?.ToString())
                    {
                        case WebRequestMethods.Http.Get:
                            // 取得回應資料
                            request.Method = MethodName;
                            using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
                            {
                                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                                {
                                    var _Reponse = sr.ReadToEnd();
                                    var GetResult = JsonConvert.DeserializeObject<T>(_Reponse);
                                    if (GetResult != null)
                                    {
                                        return (GetResult, response.StatusCode);
                                    }
                                }
                            }
                            break;
                        case WebRequestMethods.Http.Post:
                            request.Method = MethodName;
                            //Stream stream = request.GetRequestStream();
                            using (Stream stream = request.GetRequestStream())
                            {
                                if (POST_Data != null)
                                {
                                    string st = JsonConvert.SerializeObject(POST_Data);
                                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(st);
                                    stream.Write(byteArray, 0, byteArray.Length);
                                    HttpWebResponse getResponse = await request.GetResponseAsync() as HttpWebResponse;
                                    using (StreamReader sr = new StreamReader(getResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                                    {
                                        var PostResult = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                                        if (PostResult != null)
                                        {
                                            return (PostResult, getResponse.StatusCode);
                                        }
                                    }

                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                return default;
            }
            catch (Exception ex)
            {
                if (ex is WebException exw)
                {
                    if (exw.Response is null)
                    {
                        throw;
                    }
                    else
                    {
                        using (WebResponse respone = exw.Response)
                        {
                            if (respone is HttpWebResponse httpWebResponse)
                            {
                                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                                {
                                    T PostResult = default;
                                    try
                                    {
                                        PostResult = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                                    }
                                    catch
                                    {
                                        return (default, httpWebResponse.StatusCode);
                                    }
                                    if (PostResult != null)
                                    {
                                        return (PostResult, httpWebResponse.StatusCode);
                                    }
                                    else
                                    {
                                        return (default, httpWebResponse.StatusCode);
                                    }
                                }
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }
                else
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// General API Return List Result (非同步)
        /// </summary>
        /// <typeparam name="T">General T Model</typeparam>
        /// <param name="API_Url">URL 網址</param>
        /// <param name="MethodName">方法:GET, POST[WebRequestMethods.Http.]</param>
        /// <param name="POST_Data">要POST的資料</param>
        /// <returns></returns>
        public async Task<(List<T> ReturnModelList, HttpStatusCode HttpStatusCode)> GetAPIReturnListResultAsync<T>(string API_Url, string MethodName, object POST_Data = null, int ResponeTimeOut = 30000)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(API_Url) && !string.IsNullOrWhiteSpace(MethodName))
                {
                    if (new Regex(@"^(https)?:\/\/(.*)", RegexOptions.IgnoreCase).IsMatch(API_Url ?? string.Empty))
                    {
                        ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                        //若出現 "基礎連接已關閉: 無法為 SSL/TLS 安全通道建立信任關係" 錯誤 則啟用下面程式碼    ReferralURL https://blog.darkthread.net/blog/webclient-ssl-dismatch/
                        //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    }
                    HttpWebRequest request = WebRequest.Create($"{API_Url}") as HttpWebRequest;
                    request.ContentType = "application/json";
                    request.Timeout = ResponeTimeOut;
                    switch (MethodName?.ToString())
                    {
                        case WebRequestMethods.Http.Get:
                            // 取得回應資料
                            request.Method = MethodName;
                            HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
                            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                            {
                                var _Reponse = sr.ReadToEnd();
                                var GetResult = JsonConvert.DeserializeObject<List<T>>(_Reponse);
                                if (GetResult != null)
                                {
                                    return (GetResult, response.StatusCode);
                                }
                            }
                            break;
                        case WebRequestMethods.Http.Post:
                            request.Method = MethodName;
                            using (Stream stream = request.GetRequestStream())
                            {
                                if (POST_Data != null)
                                {
                                    string st = JsonConvert.SerializeObject(POST_Data);
                                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(st);
                                    stream.Write(byteArray, 0, byteArray.Length);
                                    HttpWebResponse getResponse = await request.GetResponseAsync() as HttpWebResponse;
                                    using (StreamReader sr = new StreamReader(getResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                                    {
                                        var PostResult = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
                                        if (PostResult != null)
                                        {
                                            return (PostResult, getResponse.StatusCode);
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                return (default, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                if (ex is WebException exw)
                {
                    if (exw.Response is null)
                    {
                        throw;
                    }
                    else
                    {
                        using (WebResponse respone = exw.Response)
                        {
                            if (respone is HttpWebResponse httpWebResponse)
                            {
                                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                                {
                                    List<T> PostResult = default;
                                    try
                                    {
                                        PostResult = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
                                    }
                                    catch
                                    {
                                        return (default, httpWebResponse.StatusCode);
                                    }
                                    if (PostResult != null)
                                    {
                                        return (PostResult, httpWebResponse.StatusCode);
                                    }
                                    else
                                    {
                                        return (default, httpWebResponse.StatusCode);
                                    }
                                }
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }
                else
                {
                    throw;
                }
            }
        }
        #endregion 非同步 ASYNC METHOD

    }
}
