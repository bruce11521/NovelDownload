using System;
using System.Threading;

namespace CoreBase.Utilities
{
    /// <summary>
    /// Service處理結果包裝物件
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// 成功 (200000)
        /// </summary>
        public static readonly int SuccessCode = 200000;

        /// <summary>
        /// 非預期 Exception (900000)
        /// </summary>
        public static readonly int ExceptionErrorCode = 900000;

        /// <summary>
        /// 非預期 Faild (400000)
        /// </summary>
        public static readonly int FaildOfErrorCode = 400000;

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        public ServiceResult()
        {
            this.Message = string.Empty;
            this.Content = string.Empty;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        public ServiceResult(bool isOk)
        {
            this.IsOk = isOk;
            this.Message = string.Empty;
            this.Content = string.Empty;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="message">訊息</param>
        /// <param name="content">訊息</param>
        public ServiceResult(bool isOk, string message)
        {
            this.IsOk = isOk;
            this.Message = message;
            this.Content = string.Empty;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="message">訊息</param>
        /// <param name="content">訊息</param>
        public ServiceResult(bool isOk, string message, string content = null)
        {
            this.IsOk = isOk;
            this.Message = message;
            this.Content = content ?? string.Empty;
        }

        /// <summary>
        /// Service處理結果包裝物件.
        /// </summary>
        /// <param name="code">訊息代碼.</param>
        /// <param name="message">訊息.</param>
        public ServiceResult(string message, int code)
        {
            this.Message = message;
            this.Code = code;
            this.Content = string.Empty;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="code">訊息代碼</param>
        public ServiceResult(bool isOk, int code)
        {
            this.IsOk = isOk;
            this.Code = code;
            this.Content = string.Empty;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="code">訊息代碼</param>
        /// <param name="message">訊息</param>
        public ServiceResult(bool isOk, int code, string message)
        {
            this.IsOk = isOk;
            this.Code = code;
            this.Message = message;
            this.Content = string.Empty;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="code">訊息代碼</param>
        /// <param name="ex">例外物件</param>
        public ServiceResult(bool isOk, int code, Exception ex)
        {
            this.IsOk = isOk;
            this.Code = code;
            this.Exception = ex;
            this.Content = string.Empty;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="code">訊息代碼</param>
        /// <param name="message">訊息</param>
        /// <param name="ex">例外物件</param>
        public ServiceResult(bool isOk, int code, string message, Exception ex)
        {
            this.IsOk = isOk;
            this.Code = code;
            this.Message = message;
            this.Exception = ex;
            this.Content = string.Empty;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="code">訊息代碼</param>
        /// <param name="message">訊息</param>
        /// <param name="ex">例外物件</param>
        /// <param name="content">文字物件</param>
        public ServiceResult(bool isOk, int code, string message, string content, Exception ex)
        {
            this.IsOk = isOk;
            this.Code = code;
            this.Message = message;
            this.Exception = ex;
            this.Content = content;
        }


        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk { get; set; }

        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        /// 回傳文字物件
        /// </summary>
        public string Content { get; set; } = string.Empty;

    }

    /// <summary>
    /// 泛型Service處理結果包裝物件
    /// </summary>
    /// <typeparam name="T">任意類別</typeparam>
    public class ServiceResult<T> : ServiceResult
    {
        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        public ServiceResult()
        {
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="data">回傳資料物件</param>
        public ServiceResult(bool isOk, T data)
            : base(isOk)
        {
            this.Data = data;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="message">訊息</param>
        public ServiceResult(bool isOk, string message)
            : base(isOk, message)
        {
            this.Data = default(T);
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="message">訊息</param>
        /// <param name="data">回傳資料物件</param>
        public ServiceResult(bool isOk, string message, T data)
            : base(isOk, message)
        {
            this.Data = data;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="message">訊息</param>
        /// <param name="data">回傳資料物件</param>
        public ServiceResult(bool isOk, string message, string content, T data)
            : base(isOk, message, content)
        {
            this.Data = data;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="code">訊息代碼</param>
        /// <param name="data">回傳資料物件</param>
        public ServiceResult(bool isOk, int code, T data)
            : base(isOk, code)
        {
            this.Data = data;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="code">訊息代碼</param>
        /// <param name="message">訊息</param>
        /// <param name="data">回傳資料物件</param>
        public ServiceResult(bool isOk, int code, string message, T data)
            : base(isOk, code, message)
        {
            this.Data = data;
        }

        /// <summary>
        /// Service處理結果包裝物件.
        /// </summary>
        /// <param name="code">訊息代碼</param>
        /// <param name="message">訊息</param>
        /// <param name="data">回傳資料物件</param>
        public ServiceResult(int code, string message, T data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }

        /// <summary>
        /// Service處理結果包裝物件.
        /// </summary>
        /// <param name="code">訊息代碼</param>
        /// <param name="message">訊息</param>
        /// <param name="data">回傳資料物件</param>
        /// <param name="content">回傳資料物件</param>
        public ServiceResult(int code, string message, T data, string content)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
            this.Content = content;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="code">訊息代碼</param>
        /// <param name="ex">例外物件</param>
        public ServiceResult(bool isOk, int code, Exception ex)
            : base(isOk, code)
        {
            this.Exception = ex;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="code">訊息代碼</param>
        /// <param name="message">訊息</param>
        /// <param name="ex">例外物件</param>
        public ServiceResult(bool isOk, int code, string message, Exception ex)
            : base(isOk, code, message, ex)
        {
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="message">訊息</param>
        /// <param name="code"> Code </param>
        /// <param name="data"> 回傳泛行物件 </param>
        /// <param name="ex">例外物件</param>
        public ServiceResult(bool isOk, string message, int code, T data, Exception ex)
            : base(isOk, message)
        {
            this.Code = code;
            this.Data = data;
            this.Exception = ex;
        }

        /// <summary>
        /// Service處理結果包裝物件
        /// </summary>
        /// <param name="isOk">是否成功</param>
        /// <param name="message">訊息</param>
        /// <param name="code"> Code </param>
        /// <param name="data"> 回傳泛行物件 </param>
        /// <param name="ex">例外物件</param>
        public ServiceResult(bool isOk, string message, int code, T data, string content, Exception ex)
            : base(isOk, message)
        {
            this.Code = code;
            this.Data = data;
            this.Exception = ex;
            this.Content = content;
        }

        /// <summary>
        /// 回傳資料物件
        /// </summary>
        public T Data { get; set; }
        
    }

    #region ReturnResult


    /// <summary>
    /// 處理結果包裝物件
    /// </summary>
    public class ReturnResult
    {
        /// <summary>
        /// Service處理結果包裝物件 初始化
        /// </summary>
        public ReturnResult()
        {
            ExecuteStatus = false;
            ExecuteCode = -1;
            Message = string.Empty;
            ErrorMessage = string.Empty;
            ExceptionThrow = null;
        }
        public ReturnResult(bool ExecuteStatus)
        {
            this.ExecuteStatus = ExecuteStatus;
        }
        public ReturnResult(bool ExecuteStatus, int ExecuteCode)
        {
            this.ExecuteStatus = ExecuteStatus;
            this.ExecuteCode = ExecuteCode;
        }
        public ReturnResult(bool ExecuteStatus, string Message)
        {
            this.ExecuteStatus = ExecuteStatus;
            this.Message = Message;
        }
        public ReturnResult(bool ExecuteStatus, int ExecuteCode, string ErrorMessage)
        {
            this.ExecuteStatus = ExecuteStatus;
            this.ExecuteCode = ExecuteCode;
            this.ErrorMessage = ErrorMessage;
        }
        public ReturnResult(bool ExecuteStatus, string Message, string ErrorMessage)
        {
            this.ExecuteStatus = ExecuteStatus;
            this.Message = Message;
            this.ErrorMessage = ErrorMessage;
        }

        public ReturnResult(bool ExecuteStatus, int ExecuteCode, string ErrorMessage, Exception exception)
        {
            this.ExecuteStatus = ExecuteStatus;
            this.ExecuteCode = ExecuteCode;
            this.ErrorMessage = ErrorMessage;
            this.ExceptionThrow = exception;
        }
        public ReturnResult(bool ExecuteStatus, string Message, string ErrorMessage, Exception exception)
        {
            this.ExecuteStatus = ExecuteStatus;
            this.Message = Message;
            this.ErrorMessage = ErrorMessage;
            this.ExceptionThrow = exception;
        }
        /// <summary>
        /// 執行狀態
        /// </summary>
        public bool ExecuteStatus { get; set; }
        /// <summary>
        /// 執行代碼
        /// </summary>
        public int ExecuteCode { get; set; }
        /// <summary>
        /// 執行回傳訊息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 錯誤擲出
        /// </summary>
        public Exception ExceptionThrow { get; set; }
        /// <summary>
        /// 特定物件
        /// </summary>
        public object Data { get; set; }

    }
    public class ReturnResult<T> : ReturnResult
    {
        public ReturnResult()
        {

        }
        public ReturnResult(bool ExecuteStatus, T Data) : base (ExecuteStatus)
        {
            this.Data = Data;
        }
        public ReturnResult(bool ExecuteStatus, int ExecuteCode, T Data ) : base(ExecuteStatus, ExecuteCode)
        {
            this.Data = Data;
        }
        public ReturnResult(bool ExecuteStatus, string Message, T Data) : base(ExecuteStatus, Message)
        {
            this.Data = Data;
        }
        public ReturnResult(bool ExecuteStatus, int ExecuteCode, string ErrorMessage, T Data) : base(ExecuteStatus, ExecuteCode, ErrorMessage)
        {
            this.Data = Data;
        }
        public ReturnResult(bool ExecuteStatus, string Message, string ErrorMessage, T Data) : base(ExecuteStatus, Message, ErrorMessage)
        {
            this.Data = Data;
        }
        public ReturnResult(bool ExecuteStatus, int ExecuteCode, string ErrorMessage, Exception exception, T Data) : base(ExecuteStatus, ExecuteCode, ErrorMessage, exception)
        {
            this.ExceptionThrow = exception;
            this.Data = Data;
        }
        public ReturnResult(bool ExecuteStatus, string Message, string ErrorMessage, Exception exception, T Data) : base(ExecuteStatus, Message, ErrorMessage, exception)
        {
            this.ExceptionThrow = exception;
            this.Data = Data;
        }
        public T Data { get; set; }
    }

    #endregion ReturnResult

    #region UI DELEGATE EVENT
    /// <summary>
    /// EVENT UI REFERESH
    /// </summary>
    /// <param name="_thread"></param>
    /// <param name="radlabel"></param>
    /// <param name="UI_Text"></param>
    public delegate void UI_Refresh_EventHandler(SynchronizationContext _thread, object radlabel, string UI_Text);
    /// <summary>
    /// UI 刷新
    /// </summary>
    public class UI_Refresh
    {
        private UI_Refresh_EventHandler UI_Refresh_Event;
        public UI_Refresh()
        {
        }
        public UI_Refresh(SynchronizationContext _thread, object radlabel, string UI_Text)
        {
            this._thread = _thread;
            this.radlabel = radlabel;
            this.UI_TEXT = UI_TEXT;
        }
        public event UI_Refresh_EventHandler UI_Refresh_
        {
            add
            {
                UI_Refresh_Event += value;
            }
            remove
            {
                UI_Refresh_Event -= value;
            }
        }

        //protected UI_Refresh OnUI_Refresh_Event(object sender, string UI)
        //{
        //    //UI_Refresh_Event?.Invoke(sender, UI);
        //    return null;
        //}
        private SynchronizationContext _thread;
        private object radlabel;
        private string _TEXT;
        public string UI_TEXT
        {
            get
            {
                return _TEXT;
            }
            set
            {
                _TEXT = value;
                UI_Refresh_Event?.Invoke(_thread, radlabel, _TEXT);
            }
        }
    }

    #endregion UI DELEGATE EVENT
}
