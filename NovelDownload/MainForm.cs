using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreBase.Help;
using CoreBase.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static CoreBase.Winform.ComponentExtensions;

namespace NovelDownload
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpClientHelper _HttpClientHelper = new HttpClientHelper();
        public MainForm()
        {
            InitializeComponent();
            radMsgboxFont();

            UI_Register();
            UI_Settings();


        }

        private void UI_Settings()
        {
            
        }

        private void UI_Register()
        {
            radButton_Download.Click += RadButton_Download_Click;
            radButton_CancelDownload.Click += RadButton_CancelDownload_Click;
            radButton_ClearLog.Click += RadButton_ClearLog_Click;
            radButton_GetNovel.Click += RadButton_GetNovel_Click;
        }

        private async void RadButton_GetNovel_Click(object sender, EventArgs e)
        {
            var getResult = await GetDownloadInfo();
        }

        private async Task<ServiceResult> GetDownloadInfo()
        {
            ServiceResult returnResult = new ServiceResult(false, string.Empty);
            if (string.IsNullOrWhiteSpace(radTextBoxControl_DownloadUrl.Text))
            {
                returnResult.Message = "下載網址不可為空";
                return returnResult;
            }

            var url = radTextBoxControl_DownloadUrl.Text;
            var result = await _HttpClientHelper.GetAsync<string>(url);
            
            RegexFilter(result.Data);


            return returnResult;
        }

        private void RegexFilter(string HtmlContent)
        {

        }

        private void RadButton_ClearLog_Click(object sender, EventArgs e)
        {
            
        }

        private void RadButton_CancelDownload_Click(object sender, EventArgs e)
        {
            
        }

        private void RadButton_Download_Click(object sender, EventArgs e)
        {
            
        }
    }
}
