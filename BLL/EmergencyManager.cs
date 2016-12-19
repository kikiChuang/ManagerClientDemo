using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ManagerClientDemo.Entities;
using ManagerClientDemo.Helper;
using Newtonsoft.Json;

namespace ManagerClientDemo.BLL
{
    /// <summary>
    /// 紧急情况管理业务类
    /// </summary>
    public class EmergencyManager
    {
        #region  Instance
        private static EmergencyManager _instance = null;
        private static readonly object SyncRoot = new object();

        public static EmergencyManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (null == _instance)
                        {
                            _instance = new EmergencyManager();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 注意url参数不要有空格
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public List<EmergencyCall> GetEmergencyCalls(DateTime startTime, DateTime endTime)
        {
            string start = startTime.ToString().Split(' ').FirstOrDefault().Replace("/", "-");    //只要年月日
            string end = endTime.ToString().Split(' ').FirstOrDefault().Replace("/", "-");
            string url = Global.url + "/GetEmergencyCalls/"+ start + "/"+ end;
            InternetHelperForList<EmergencyCall> helper = new InternetHelperForList<EmergencyCall>();
            return helper.GetList(url);
        }

        /// <summary>
        /// 对全景区在线用户发送紧急消息
        /// todo 后期可改为针对特定用户
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool SendEmergencyMsg(string content)
        {
            string url = Global.url + "/SendEmergencyMsg";
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            string result = client.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
            if (result.Contains("true"))
                return true;
            return false;
        }
    }
}
