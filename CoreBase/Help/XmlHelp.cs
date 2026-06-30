using System;
using System.IO;
using System.Xml;

namespace CoreBase.Help
{
    /// <summary>
    /// XML 檔案操作
    /// </summary>
    public static class XmlHelp
    {
        /// <summary>
        /// XML 讀取
        /// </summary>
        /// <typeparam name="T">XML Class</typeparam>
        /// <param name="LoadXmlPath">Xml檔案路徑</param>
        /// <param name="SingleNodeName">Xml.Single載入節點名稱</param>
        /// <returns></returns>
        public static ServiceResult<T> LoadXmlFile<T>(string LoadXmlPath, string SingleNodeName)
        {
            ServiceResult<T> ReturnResult = new ServiceResult<T>(false, string.Empty, default);
            try
            {
                if (string.IsNullOrWhiteSpace(LoadXmlPath))
                {
                    ReturnResult.Message = "載入檔案路徑不可為空白";
                    return ReturnResult;
                }

                if (File.Exists(LoadXmlPath))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(LoadXmlPath);
                    XmlNode NHISettings_Node = xmlDoc.SelectSingleNode($"//{SingleNodeName}");
                    //string jsonText = JsonConvert.SerializeXmlNode(NHISettings_Node);
                    if (NHISettings_Node != null && !string.IsNullOrEmpty(NHISettings_Node.InnerText))
                    {
                        var xml = JsonConvert.DeserializeObject<T>(NHISettings_Node.InnerText);
                        if (xml != null)
                        {
                            ReturnResult.Data = xml;
                            ReturnResult.IsOk = true;
                            ReturnResult.Message = "檔案讀取成功!";
                        }
                        else
                        {
                            ReturnResult.Message = "Xml設定檔案讀取失敗，格式不相符!";
                        }
                    }
                    else
                    {
                        ReturnResult.Message = "Xml設定檔案讀取失敗!";
                    }
                }
                else
                {
                    ReturnResult.Message = $"\"{LoadXmlPath}\"\n該路徑檔案不存在!";
                }
            }
            catch (Exception ex)
            {
                ReturnResult.IsOk = false;
                ReturnResult.Exception = ex;
                ReturnResult.Message = ex.Message;
            }
            return ReturnResult;
        }
        /// <summary>
        /// 建立XML檔案
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="WriteDataModel">寫入Xml檔案Model</param>
        /// <param name="SaveXmlPath">Xml建立路徑(若檔案已經存在則覆蓋)</param>
        /// <param name="RootNodeName">Xml寫入根節點名稱</param>
        /// <param name="SubNodeName">Xml寫入子節點名稱</param>
        /// <returns></returns>
        public static ServiceResult<T> CreateXmlFile<T>(this T WriteDataModel, string SaveXmlPath, string RootNodeName, string SubNodeName = null)
        {
            ServiceResult<T> ReturnResult = new ServiceResult<T>(false, string.Empty, default);
            try
            {
                var JSON_Data = string.Empty;
                if (WriteDataModel == null)
                {
                    ReturnResult.Message = "寫入Xml檔案物件為Null";
                    return ReturnResult;
                }
                else
                {
                    JSON_Data = JsonConvert.SerializeObject(WriteDataModel);
                }
                if (string.IsNullOrEmpty(RootNodeName))
                {
                    ReturnResult.Message = "Xml寫入根節點名稱為Null";
                    return ReturnResult;
                }
                if (string.IsNullOrWhiteSpace(SaveXmlPath))
                {
                    ReturnResult.Message = "未指定寫入檔案路徑";
                    return ReturnResult;
                }
                try
                {
                    Path.GetFullPath(SaveXmlPath);
                }catch(Exception ex)
                {
                    throw;
                }
                XmlDocument xmlDoc = new XmlDocument();

                //宣告段落
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmlDeclaration);
                //ROOT
                XmlElement Root = xmlDoc.CreateElement(RootNodeName);

                xmlDoc.AppendChild(Root);
                CreateNode(xmlDoc, Root, SubNodeName, JSON_Data);


                if (File.Exists(SaveXmlPath))
                {
                    ReturnResult.Message = "檔案覆寫成功";
                    //if (DialogResult.Yes == RadMessageBox.Show($"\"{SaveXmlPath}\"\n,設定檔存在，是否覆蓋?", "檔案覆蓋詢問", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                    //{
                    //    ReturnResult.IsOk = true;
                    //    ReturnResult.Message = "檔案覆寫成功";
                    //    xmlDoc.Save(SaveXmlPath);
                    //}
                    //else
                    //{
                    //    ReturnResult.Message = "使用者取消覆寫檔案";
                    //}
                }
                else
                {
                    ReturnResult.Message = "檔案儲存成功";
                }
                ReturnResult.IsOk = true;
                xmlDoc.Save(SaveXmlPath);
            }
            catch (Exception ex)
            {
                ReturnResult.IsOk = false;
                ReturnResult.Exception = ex;
                ReturnResult.Message += "Throw:" + ex.Message + Environment.NewLine;
            }
            return ReturnResult;
        }

        /// <summary>
        /// Add New Node
        /// </summary>
        /// <param name="xmlDoc">MainDocument</param>
        /// <param name="ParentNode">Parent Node</param>
        /// <param name="ChildName">Child Name</param>
        /// <param name="ChildValue">Child Value</param>
        /// <returns>如果ChildName有數值則返回Child XmlElement,否則則返回ParentNode</returns>
        public static XmlElement CreateNode(XmlDocument xmlDoc, XmlElement ParentNode, string ChildName = null, string ChildValue = null)
        {
            if (string.IsNullOrEmpty(ChildName))
            {
                ParentNode.InnerText = ChildValue;
                return ParentNode;
            }
            else
            {
                XmlElement element = xmlDoc.CreateElement(ChildName);
                //避免相關標籤連在一起
                if (!string.IsNullOrEmpty(ChildValue))
                {
                    element.InnerText = ChildValue;
                }
                ParentNode.AppendChild(element);
                return element;
            }
            
        }
    }
}
