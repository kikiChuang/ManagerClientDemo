using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ManagerClientDemo.Entities;
using Newtonsoft.Json.Linq;
using ManagerClientDemo.Helper;
using Newtonsoft.Json;

namespace ManagerClientDemo.BLL
{
    public class LostContactManager
    {
        #region  Instance
        private static LostContactManager _instance = null;
        private static readonly object SyncRoot = new object();

        public static LostContactManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (null == _instance)
                        {
                            _instance = new LostContactManager();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 录入失联人员调查情况
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool EditState(int id,string state)
        {
            JObject json = new JObject(); //包装请求
            json.Add("id", id);
            json.Add("state", state);
            string result=InternetHepler.Instance.PostJObject(json, "EditState");
            if (result.Contains("true"))
                return true;
            return false;
        }



        /// <summary>
        /// 获取异常情况记录
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="hasSolved">是否包含已解决的记录</param>
        public List<LostContact> GetLostContacts(DateTime startTime, DateTime endTime,bool hasSolved)
        {
            string start = startTime.ToString().Split(' ').FirstOrDefault().Replace("/", "-");    //只要年月日
            string end = endTime.ToString().Split(' ').FirstOrDefault().Replace("/", "-");
            InternetHelperForList<LostContact> helper=new InternetHelperForList<LostContact>();
            return helper.GetList(Global.url + "/GetLostContacts/" + start + "/" + end + "/" + hasSolved);
        }

        /// <summary>
        /// 记录该异常已解决
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RecordSolved(string id)
        {
            return InternetHepler.Instance.GetBool(Global.url + "/RecordSolved/" + id);
        }
    }
}
