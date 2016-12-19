using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ManagerClientDemo.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ManagerClientDemo.Helper;

namespace ManagerClientDemo.BLL
{
    public class AdministratorManager
    {
        #region  Instance
        private static AdministratorManager _instance = null;
        private static readonly object SyncRoot = new object();

        public static AdministratorManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (null == _instance)
                        {
                            _instance = new AdministratorManager();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 修改密码
        /// </summary>
        public bool AlterPassword(string account,string newPassword)
        {
            //todo 加密 
            JObject json = new JObject(); //包装请求
            json.Add("account", account);
            json.Add("newPassword", newPassword);
            string result=InternetHepler.Instance.PostJObject(json, "AlterPassword");
            if (result.Contains("true"))
                return true;
            return false;
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        public bool AddAdministrator(Administrator admin)
        {
            string str = JsonConvert.SerializeObject(admin);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            string result = client.PostAsync(Global.url + "/AddAdministrator", content).Result.Content.ReadAsStringAsync().Result;
            if (result.Contains("true"))
                return true;
            return false;
        }

        /// <summary>
        /// 登录
        /// </summary>
        public bool LogInAdmin(string account,string password)
        {
            //todo 待密码加密
            JObject json = new JObject(); //包装请求
            json.Add("account", account);
            json.Add("password", password);
            string result = InternetHepler.Instance.PostJObject(json, "LogInAdmin");
            if (string.IsNullOrEmpty(result))
                return false;
            Global.LogAdministrator= JsonConvert.DeserializeObject<Administrator>(result);   //将登陆者信息放入全局变量
            return true;
        }

        /// <summary>
        /// 获取所有管理员信息
        /// </summary>
        /// <returns></returns>
        public List<Administrator> GetAdministrators()
        {
            string url = Global.url + "/GetAdministrators";
            InternetHelperForList<Administrator> helper=new InternetHelperForList<Administrator>();
            return helper.GetList(url);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="position">职位</param>
        /// <returns></returns>
        public bool AlterInfo(string account, string name, string sex, string position)
        {
            string url = Global.url + "/AlterInfo/"+string.Format("{0}/{1}/{2}/{3}",account,name,sex, position);
            return InternetHepler.Instance.GetBool(url);
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool DeleteAdministrator(string account)
        {
            string url = Global.url + "/DeleteAdministrator/" + account;
            return InternetHepler.Instance.GetBool(url);
        }
    }
}
