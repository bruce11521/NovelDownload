using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CoreBase.DB;
using CoreBase.Utilities;

namespace CoreBase.Help
{
    /// <summary>
    /// 住院網頁Token
    /// </summary>
    public class LoginTokenHelper
    {

        private readonly object _lock = new();
        private HttpClientHelper _HttpClientHelper;
        private DBhelp _dbhelper;

        /// <summary>
        /// 
        /// </summary>
        public LoginTokenHelper()
        {
            _dbhelper = new DBhelp();
            _HttpClientHelper = new HttpClientHelper();
        }
        /// <summary>
        /// 登入(取得登入token)
        /// </summary>
        /// <param name="USER_ID">使用者帳號</param>
        /// <returns></returns>
        public HIS2_LOGIN_TOKEN GetUserLoginToken(string USER_ID)
        {
            ServiceResult<string> returnResult = _HttpClientHelper.GetClientIp();
            string USER_IP = returnResult.Data;
            string logoutTime = "480";
            HIS2_LOGIN_TOKEN? loginInfo = CheckLoginToken(USER_ID, USER_IP, "");

            if (loginInfo == null)
            {
                string insertSQL = @$"INSERT INTO HIS2USER2.HIS2_LOGIN_TOKEN (LOGIN_ID,LOGIN_TIME,USER_ID,LOGOUT_TIME,USER_IP)
                                        VALUES (HIS2USER2.SEQ_HIS2_LOGIN_TOKEN.NEXTVAL,sysdate,:USER_ID,sysdate + INTERVAL '{logoutTime}' MINUTE,:USER_IP)";
                _dbhelper.Execute(insertSQL, new { USER_ID, USER_IP });
                loginInfo = GetLoginToken(USER_ID, USER_IP, "");
            }
            return loginInfo;
        }

        /// <summary>
        /// 取得 Token 資訊，並判斷登出時間若小於10分鐘便延後登出時間
        /// </summary>
        /// <param name="USER_ID">使用者帳號</param>
        /// <param name="USER_IP">登入者IP</param>
        /// <param name="LOGIN_TOKEN">登入TOKEN</param>
        /// <returns></returns>
        private HIS2_LOGIN_TOKEN? CheckLoginToken(string USER_ID, string USER_IP, string LOGIN_TOKEN)
        {
            short logoutTime = 480; //Convert.ToInt16(new GetSeqNo().GetPubConfigValueByCode("HIS2_NRS", "LogoutTime"));

            HIS2_LOGIN_TOKEN loginInfo = GetLoginToken(USER_ID, USER_IP, LOGIN_TOKEN);

            if (loginInfo != null)
            {
                if ((loginInfo.LOGOUT_TIME - DateTime.Now).TotalMinutes < 10)
                {
                    decimal LOGIN_ID = loginInfo.LOGIN_ID;
                    DateTime NEW_LOGOUT_TIME = loginInfo.LOGOUT_TIME.AddMinutes(logoutTime);
                    string updateSql = "UPDATE HIS2USER2.HIS2_LOGIN_TOKEN SET LOGOUT_TIME = :LOGOUT_TIME WHERE LOGIN_ID = :LOGIN_ID";
                    int count = _dbhelper.Execute(updateSql, new { LOGIN_ID, LOGOUT_TIME = NEW_LOGOUT_TIME });
                    if (count > 0)
                    {
                        loginInfo.LOGOUT_TIME = NEW_LOGOUT_TIME;
                    }
                }
            }
            return loginInfo;
        }

        /// <summary>
        /// 驗證Token
        /// </summary>
        /// <param name="USER_ID">使用者帳號</param>
        /// <param name="LOGIN_TOKEN">登入TOKEN</param>
        /// <param name="USER_IP">登入者IP</param>
        /// <returns></returns>
        public bool VerificationToken(string USER_ID, string LOGIN_TOKEN, string USER_IP = "")
        {
            if (string.IsNullOrWhiteSpace(USER_IP))
            {
                ServiceResult<string> returnResult = _HttpClientHelper.GetClientIp();
                USER_IP = returnResult.Data;
            } 
            HIS2_LOGIN_TOKEN? loginInfo = CheckLoginToken(USER_ID, USER_IP, LOGIN_TOKEN);
            return loginInfo != null;
        }


        /// <summary>
        /// 取得 Token 資訊
        /// </summary>
        /// <param name="USER_ID">使用者帳號</param>
        /// <param name="USER_IP">登入者IP</param>
        /// <param name="LOGIN_TOKEN">登入TOKEN</param>
        /// <param name="checkUser">確認使用者</param>
        /// <returns></returns>
        public HIS2_LOGIN_TOKEN GetLoginToken(string USER_ID, string USER_IP, string LOGIN_TOKEN, bool checkUser = true)
        {
            List<string> condition = new List<string>();
            StringBuilder loginInfoSql = new();
            loginInfoSql.AppendLine("SELECT LOGIN_ID,LOGIN_TIME,USER_ID,LOGIN_TOKEN,LOGOUT_TIME,USER_IP ");
            loginInfoSql.AppendLine(" FROM HIS2USER2.HIS2_LOGIN_TOKEN ");
            if (!string.IsNullOrWhiteSpace(USER_ID) || checkUser) condition.Add(" USER_ID = :USER_ID ");
            if (!string.IsNullOrWhiteSpace(USER_IP)) condition.Add(" USER_IP = :USER_IP ");
            if (!string.IsNullOrWhiteSpace(LOGIN_TOKEN)) condition.Add(" LOGIN_TOKEN = :LOGIN_TOKEN ");
            condition.Add(" LOGIN_TIME <= SYSDATE ");
            condition.Add(" SYSDATE < LOGOUT_TIME ");
            if (condition != null && condition.Count > 0) loginInfoSql.AppendLine(" WHERE " + string.Join(" \nAND ", condition));
            loginInfoSql.AppendLine(" ORDER BY LOGIN_ID DESC ");
            HIS2_LOGIN_TOKEN loginInfo = _dbhelper.Query<HIS2_LOGIN_TOKEN>(loginInfoSql.ToString(), new { USER_ID, USER_IP, LOGIN_TOKEN })?.FirstOrDefault();
            return loginInfo;
        }
        /// <summary>
        /// Token Model
        /// </summary>
        public class HIS2_LOGIN_TOKEN
        {
            /// <summary>
            /// 登入序號
            /// </summary>
            [DisplayName("登入序號")]
            public decimal LOGIN_ID { get; set; }
            /// <summary>
            /// 登入時間
            /// </summary>
            [DisplayName("登入時間")]
            public DateTime LOGIN_TIME { get; set; }
            /// <summary>
            /// 登入者名稱
            /// </summary>
            [DisplayName("登入者名稱")]
            public string USER_ID { get; set; } = string.Empty;
            /// <summary>
            /// 登入TOKEN
            /// </summary>
            [DisplayName("登入TOKEN")]
            public string LOGIN_TOKEN { get; set; } = string.Empty;
            /// <summary>
            /// 登出時間
            /// </summary>
            [DisplayName("登出時間")]
            public DateTime LOGOUT_TIME { get; set; }
            /// <summary>
            /// 登入者IP
            /// </summary>
            [DisplayName("登入者IP")]
            public string USER_IP { get; set; } = string.Empty;
        }
    }
}
