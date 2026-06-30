using System;

namespace CoreBase.Help
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// 抓取最底層之原始InnerException
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception GetOriginalException(this Exception ex)
        {
            if (ex.InnerException == null) return ex;
            return ex.InnerException.GetOriginalException();
        }

        /// <summary>
        /// 取得內部深層錯誤資訊(InnerException)並以LVx來區分
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="IS_Display_Title">是否加上標題，"ErrorMessage:"與"StatckTrack:"</param>
        /// <returns></returns>
        public static (string ErrorMessage, string Stacktrace) GetInnerException(this Exception ex, bool IS_Display_Title = false)
        {
            (string ErrorMessage, string Stacktrace) ERROR_MSG = (string.Empty, string.Empty);
            try
            {
                if (IS_Display_Title == true)
                {
                    ERROR_MSG = ("ErrorMessage:" + Environment.NewLine, "StackTrack:" + Environment.NewLine);
                }
                if(ex != null)
                {
                    int LEVEL_COUNT = 0;
                    ERROR_MSG.Stacktrace += $"LV{LEVEL_COUNT}:" + ex.StackTrace + Environment.NewLine;
                    ERROR_MSG.ErrorMessage += $"LV{LEVEL_COUNT}:" + ex.Message + Environment.NewLine;
                    LEVEL_COUNT++;
                    Exception InnerEx = ex.InnerException != null ?  ex.InnerException : null;
                    while (InnerEx != null)
                    {
                        ERROR_MSG.Stacktrace += $"LV{LEVEL_COUNT}:" + InnerEx.StackTrace + Environment.NewLine;
                        ERROR_MSG.ErrorMessage += $"LV{LEVEL_COUNT}:" + InnerEx.Message + Environment.NewLine;
                        LEVEL_COUNT++;
                        InnerEx = InnerEx.InnerException;
                        //最多抓到第10層
                        if(LEVEL_COUNT > 10)
                        {
                            break;
                        }
                    }
                }
            }
            catch(Exception exx)
            {
                ERROR_MSG.Stacktrace += $"[THROW]:" + exx.StackTrace + Environment.NewLine;
                ERROR_MSG.ErrorMessage += $"[THROW]:" + exx.Message + Environment.NewLine;
            }
            return ERROR_MSG;
        }

        
    }
}
