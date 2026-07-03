using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using CoreBase.Utilities;
using Newtonsoft.Json;

namespace CoreBase.Help
{
    /*
     批次傳送  使用參考說明
     一、事前準備  
        1. 使用 AddMonitorService  申請服務，並取得UUID
        2. 至專案的App.Config中設定↓，並放入剛取得的 UUID 於 connectionString 位置
	        <add name="Claim_OPD" connectionString="dbc2dc2a-5f80-44c8-bd54-311470decc1e" providerName="GetMonitorList"/>
        3.申請完 服務 後，系統如果沒有任何的Log，會視為異常，所以請在系統服務啟用時，增加基本的Log（Server記錄）
     二、使用方式
        1.傳到Server記錄，而沒傳送到三總通訊App，請使用『AddMonitorLog』
        2.傳到三總通訊App，請使用『AddMonitorLog_Interface』，有分是否有不同訊息，或相同訊息傳送多人

     三、附註
        1.可以開啟emoji視窗的方式為同時按下 『Windows』及『.』即可
     */



    /// <summary>
    /// 三總行動通訊 APP 
    /// </summary>
    public class TriCommunicationHelper
    {
        /// <summary>
        /// _HttpClientHelper
        /// </summary>
        public HttpClientHelper _HttpClientHelper = new HttpClientHelper();

        ///// <summary>
        ///// GetMonitorList
        ///// </summary>
        ///// <returns></returns>
        //public async Task<ServiceResult<List<TriCommunicationApp.SystemMonitor.GetMonitorList>>> GetMonitorList()
        //{
        //    ServiceResult<List<TriCommunicationApp.SystemMonitor.GetMonitorList>> returnResult =
        //        new ServiceResult<List<TriCommunicationApp.SystemMonitor.GetMonitorList>>(false, string.Empty, new List<TriCommunicationApp.SystemMonitor.GetMonitorList>());
        //    try
        //    {
        //        returnResult = await _HttpClientHelper.GetAsync<List<TriCommunicationApp.SystemMonitor.GetMonitorList>>(
        //                "http://10.200.0.86/CDCVaccineAPI/GetMonitorList");
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.IsOk = false;
        //        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
        //        returnResult.Exception = ex;
        //    }
        //    return returnResult;
        //}

        ///// <summary>
        ///// GetMonitorLog
        ///// </summary>
        ///// <returns></returns>
        //public async Task<ServiceResult<List<TriCommunicationApp.SystemMonitor.GetMonitorLog>>> GetMonitorLog()
        //{
        //    ServiceResult<List<TriCommunicationApp.SystemMonitor.GetMonitorLog>> returnResult =
        //        new ServiceResult<List<TriCommunicationApp.SystemMonitor.GetMonitorLog>>(false, string.Empty, new List<TriCommunicationApp.SystemMonitor.GetMonitorLog>());
        //    try
        //    {
        //        returnResult = await _HttpClientHelper.GetAsync<List<TriCommunicationApp.SystemMonitor.GetMonitorLog>>(
        //            "http://10.200.0.86/CDCVaccineAPI/GetMonitorLog");
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.IsOk = false;
        //        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
        //        returnResult.Exception = ex;
        //    }
        //    return returnResult;
        //}

        ///// <summary>
        ///// 新增監控服務
        ///// </summary>
        ///// <returns></returns>
        //public async Task<ServiceResult<bool>> AddMonitorService(TriCommunicationApp.SystemMonitor.AddMonitorService data)
        //{
        //    ServiceResult<bool> returnResult = new ServiceResult<bool>(false, string.Empty, false);
        //    try
        //    {
        //        if (data != null)
        //        {
        //            returnResult = await _HttpClientHelper.PostAsync<bool>(
        //                "http://10.200.0.86/CDCVaccineAPI/AddMonitorService", JsonConvert.SerializeObject(data));
        //        }
        //        else
        //        {
        //            returnResult.IsOk = false;
        //            returnResult.Message += "傳入資料不可為Null !";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.IsOk = false;
        //        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
        //        returnResult.Exception = ex;
        //    }
        //    return returnResult;
        //}

        ///// <summary>
        ///// 新增監控紀錄
        ///// </summary>
        ///// <returns></returns>
        //public async Task<ServiceResult<bool>> AddMonitorLog(AddMonitorLog data)
        //{
        //    ServiceResult<bool> returnResult = new ServiceResult<bool>(false, string.Empty, false);
        //    try
        //    {
        //        if (data != null)
        //        {
        //            returnResult = await _HttpClientHelper.PostAsync<bool>(
        //                "http://10.200.0.86/CDCVaccineAPI/AddMonitorLog", JsonConvert.SerializeObject(data));
        //        }
        //        else
        //        {
        //            returnResult.IsOk = false;
        //            returnResult.Message += "傳入資料不可為Null !";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.IsOk = false;
        //        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
        //        returnResult.Exception = ex;
        //    }
        //    return returnResult;
        //}

        ///// <summary>
        ///// 新增監控紀錄 , 
        ///// 發送者通道:網路電話系統
        ///// </summary>
        ///// <param name="ConfigName">App.Config中ConfigureName(放入UUID)</param>
        ///// <param name="PagerList">通知者清單</param>
        ///// <param name="Content">通知內容</param>
        ///// <returns></returns>
        //public async Task<ServiceResult<bool>> AddMonitorLog(string ConfigName, List<string> PagerList, string Content)
        //{
        //    return await AddMonitorLog_Interface(ConfigName, PagerList, Content);
        //}

        ///// <summary>
        ///// 新增監控紀錄 , 
        ///// 發送者通道:網路電話系統
        ///// </summary>
        ///// <param name="ConfigName">App.Config中ConfigureName(放入UUID)</param>
        ///// <param name="PagerList">通知者清單(使用','進行Pager分隔)</param>
        ///// <param name="Content">通知內容</param>
        ///// <returns></returns>
        //public async Task<ServiceResult<bool>> AddMonitorLog(string ConfigName, string PagerList, string Content)
        //{
        //    List<string> pagerList = new List<string>();
        //    try
        //    {
        //        if (!string.IsNullOrWhiteSpace(PagerList))
        //        {
        //            var pagerSplitList = PagerList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //            if (pagerSplitList.Length > 0)
        //            {
        //                pagerList.AddRange(pagerSplitList);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }

        //    return await AddMonitorLog_Interface(ConfigName, pagerList, Content);
        //}

        ///// <summary>
        ///// 新增監控紀錄 , 
        ///// 發送者通道:網路電話系統  
        ///// （要批次傳送不同的人，有不同的訊息）
        ///// </summary>
        ///// <param name="ConfigName">App.Config中ConfigureName(放入UUID)</param>
        ///// <param name="SendModel">送出的Model，Pager：通知者清單，Content：通知內容</param>
        ///// <returns></returns>
        //private async Task<ServiceResult<bool>> AddMonitorLog_Interface(string ConfigName, List<SendMessageModel> SendModel)
        //{
        //    ServiceResult<bool> returnResult = new ServiceResult<bool>(false, string.Empty, false);
        //    try
        //    {
        //        AddMonitorLog data = new AddMonitorLog();
        //        var list = ConfigurationManager.ConnectionStrings;
        //        var connectionString = string.Empty;
        //        foreach (ConnectionStringSettings item in list)
        //        {
        //            if (item.Name == ConfigName)
        //            {
        //                connectionString = item.ConnectionString;
        //                break;
        //            }
        //        }
        //        if (string.IsNullOrWhiteSpace(connectionString))
        //        {
        //            returnResult.Message += $"[{nameof(ConfigName)}:{ConfigName}],於App.Config中未找到對應文字!";
        //            return returnResult;
        //        }
        //        data.c1 = connectionString;
        //        if (SendModel.Any(x => !string.IsNullOrWhiteSpace(x.Content)) is true)
        //        {
        //            returnResult.Message += $"通知內容不可為空!";
        //            return returnResult;
        //        }
        //        if (SendModel.Any(x => !string.IsNullOrWhiteSpace(x.Pager)) is true)
        //        {
        //            returnResult.Message += $"通知者清單不可為Null或是內部元素需任一有值(不包含空白)!";
        //            return returnResult;
        //        }

        //        data.c2 = SendModel;
        //        returnResult = await _HttpClientHelper.PostAsync<bool>(
        //            "http://10.200.0.86/CDCVaccineAPI/AddMonitorLogFromBody", JsonConvert.SerializeObject(data));
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.IsOk = false;
        //        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
        //        returnResult.Exception = ex;
        //    }
        //    return returnResult;
        //}

        ///// <summary>
        ///// 新增監控紀錄 , 
        ///// 發送者通道:網路電話系統  
        ///// （要批次傳送不同的人，相同訊息）
        ///// </summary>
        ///// <param name="ConfigName">App.Config中ConfigureName(放入UUID)</param>
        ///// <param name="PagerList">通知者清單（以,相接多個人）</param>
        ///// <param name="Content">通知內容</param>
        ///// <returns></returns>
        //private async Task<ServiceResult<bool>> AddMonitorLog_Interface(string ConfigName, List<string> PagerList, string Content)
        //{
        //    ServiceResult<bool> returnResult = new ServiceResult<bool>(false, string.Empty, false);
        //    try
        //    {
        //        AddMonitorLog data = new AddMonitorLog();
        //        var list = ConfigurationManager.ConnectionStrings;
        //        var connectionString = string.Empty;
        //        foreach (ConnectionStringSettings item in list)
        //        {
        //            if (item.Name == ConfigName)
        //            {
        //                connectionString = item.ConnectionString;
        //                break;
        //            }
        //        }
        //        if (string.IsNullOrWhiteSpace(connectionString))
        //        {
        //            returnResult.Message += $"[{nameof(ConfigName)}:{ConfigName}],於App.Config中未找到對應文字!";
        //            return returnResult;
        //        }
        //        data.c1 = connectionString;
        //        if (string.IsNullOrEmpty(Content))
        //        {
        //            returnResult.Message += $"通知內容不可為空!";
        //            return returnResult;
        //        }
        //        SendMessageModel snedModel =
        //            new SendMessageModel();
        //        if (PagerList?.Any(x => !string.IsNullOrWhiteSpace(x)) is true)
        //        {

        //            PagerList = PagerList?.Where(x => !string.IsNullOrWhiteSpace(x))?.ToList();
        //            snedModel.Pager = string.Join(",", PagerList);
        //            snedModel.Content = Content;
        //        }
        //        else
        //        {
        //            returnResult.Message += $"{nameof(PagerList)}:通知者清單不可為Null或是內部元素需任一有值(不包含空白)!";
        //            return returnResult;
        //        }
        //        data.c2 = new List<SendMessageModel> { snedModel };
        //        returnResult = await _HttpClientHelper.PostAsync<bool>(
        //            "http://10.200.0.86/CDCVaccineAPI/AddMonitorLogFromBody", JsonConvert.SerializeObject(data));
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.IsOk = false;
        //        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
        //        returnResult.Exception = ex;
        //    }
        //    return returnResult;
        //}

        ///// <summary>
        ///// 新增監控紀錄 , 
        ///// 發送者通道:網路電話系統
        ///// </summary>
        ///// <param name="ConfigName">App.Config中ConfigureName(放入UUID)</param>
        ///// <param name="Content">通知內容</param>
        ///// <returns></returns>
        //public async Task<ServiceResult<bool>> AddMonitorLog(string ConfigName, string Content)
        //{
        //    ServiceResult<bool> returnResult = new ServiceResult<bool>(false, string.Empty, false);
        //    try
        //    {
        //        TriCommunicationApp.SystemMonitor.AddMonitorLog data =
        //            new TriCommunicationApp.SystemMonitor.AddMonitorLog();
        //        var list = ConfigurationManager.ConnectionStrings;
        //        var connectionString = string.Empty;
        //        foreach (ConnectionStringSettings item in list)
        //        {
        //            if (item.Name == ConfigName)
        //            {
        //                connectionString = item.ConnectionString;
        //                break;
        //            }
        //        }
        //        if (string.IsNullOrWhiteSpace(connectionString))
        //        {
        //            returnResult.Message += $"[{nameof(ConfigName)}:{ConfigName}],於App.Config中未找到對應文字!";
        //            return returnResult;
        //        }
        //        if (string.IsNullOrEmpty(Content))
        //        {
        //            returnResult.Message += $"通知內容不可為空或空白!";
        //            return returnResult;
        //        }
        //        data.c1 = connectionString;
        //        data.c2 = new List<SendMessageModel> { new SendMessageModel { Content = Content ?? string.Empty} };
        //        returnResult = await _HttpClientHelper.PostAsync<bool>(
        //            "http://10.200.0.86/CDCVaccineAPI/AddMonitorLogFromBody", JsonConvert.SerializeObject(data));
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.IsOk = false;
        //        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
        //        returnResult.Exception = ex;
        //    }
        //    return returnResult;
        //}

        ///// <summary>
        ///// 即時呼叫 三總行動分機APP , 
        ///// 發送者通道:三總通報
        ///// </summary>
        ///// <param name="IDNO"></param>
        ///// <param name="Content"></param>
        ///// <returns></returns>
        //public async Task<ServiceResult<string>> WapiOTPSendMsg(string IDNO, string Content)
        //{
        //    return await WapiOTPSendMsg_Interface(IDNO, Content);
        //}

        ///// <summary>
        ///// 即時呼叫 三總行動分機APP , 
        ///// 發送者通道:三總通報
        ///// </summary>
        ///// <param name="IDNOList">多筆IDNO</param>
        ///// <param name="Content"></param>
        ///// <returns></returns>
        //public async Task<ServiceResult<string>> WapiOTPSendMsg(List<string> IDNOList, string Content)
        //{
        //    ServiceResult<string> returnResult = new ServiceResult<string>(false, string.Empty);
        //    try
        //    {
        //        List<string> resultDataList = new List<string>();
        //        List<string> resultMessageList = new List<string>();
        //        if (IDNOList?.Any() is true)
        //        {
        //            foreach (var item in IDNOList)
        //            {
        //                var result = await WapiOTPSendMsg_Interface(item, Content);
        //                resultDataList.Add(result.Data);
        //                resultMessageList.Add(result.Message);
        //            }
        //        }
        //        returnResult.IsOk = true;
        //        returnResult.Data = string.Join(",", resultDataList);
        //        returnResult.Message = string.Join(",", resultMessageList);
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.IsOk = false;
        //        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
        //        returnResult.Exception = ex;
        //    }
        //    return returnResult;
        //}

        ///// <summary>
        ///// 即時呼叫 三總行動分機APP , 
        ///// 發送者通道:三總通報
        ///// </summary>
        ///// <param name="IDNO"></param>
        ///// <param name="Content"></param>
        ///// <returns></returns>
        //private async Task<ServiceResult<string>> WapiOTPSendMsg_Interface(string IDNO, string Content)
        //{
        //    ServiceResult<string> returnResult = new ServiceResult<string>(false, string.Empty, string.Empty);
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(IDNO))
        //        {
        //            returnResult.Message += "未輸入接收訊息人的身份證字號";
        //            return returnResult;
        //        }
        //        if (string.IsNullOrEmpty(Content))
        //        {
        //            returnResult.Message += "發送訊息內容不可為空!";
        //            return returnResult;
        //        }

        //        var apiUrl = "http://10.226.1.88/Wapi_OTP/home/SendMsg";
        //        var parameters = new Dictionary<string, string>();
        //        parameters.Add("user", "999005");
        //        parameters.Add("IDNO", IDNO);
        //        parameters.Add("Msg", Content);
        //        var encodeParams = string.Join("&",
        //            parameters.Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}"));
        //        if (!string.IsNullOrWhiteSpace(encodeParams))
        //        {
        //            apiUrl += "?" + encodeParams;
        //        } 
        //        returnResult = await _HttpClientHelper.GetAsync<string>(apiUrl);
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResult.IsOk = false;
        //        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage;
        //        returnResult.Exception = ex;
        //    }
        //    return returnResult;
        //}
    }
}
