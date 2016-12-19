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
    public class ServerLogsManager
    {
        #region  Instance
        private static ServerLogsManager _instance = null;
        private static readonly object SyncRoot = new object();

        public static ServerLogsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (null == _instance)
                        {
                            _instance = new ServerLogsManager();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        public bool DeleteServerLogs(List<int> logIDs)
        {
            InternetHelperForList<List<int>> helper = new InternetHelperForList<List<int>>();
            return helper.PostString(Global.url + "/DeleteServerLogs", logIDs);
        }

        /// <summary>
        /// 注意url参数不要有空格
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public List<ServerLog> GetServerLogs(DateTime startTime, DateTime endTime)
        {
            string start = startTime.ToString().Split(' ').FirstOrDefault().Replace("/", "-");    //只要年月日
            string end = endTime.ToString().Split(' ').FirstOrDefault().Replace("/", "-");
            InternetHelperForList<ServerLog> helper = new InternetHelperForList<ServerLog>();
            return helper.GetList(Global.url + "/GetServerLogs/"+start+"/"+end);
        }
    }
}
