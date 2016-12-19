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
    public class ScenicManager
    {
        #region  Instance
        private static ScenicManager _instance = null;
        private static readonly object SyncRoot = new object();

        public static ScenicManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (null == _instance)
                        {
                            _instance = new ScenicManager();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 修改景点信息
        /// </summary>
        /// <param name="scenic"></param>
        /// <returns></returns>
        public bool AlterScenic(Scenic scenic)
        {
            InternetHelperForList<Scenic> helper = new InternetHelperForList<Scenic>();
            return helper.PostString(Global.url + "/AlterScenic", scenic);
        }

        /// <summary>
        /// 添加景点
        /// </summary>
        /// <param name="scenic"></param>
        /// <returns></returns>
        public bool AddScenic(Scenic scenic)
        {
            InternetHelperForList<Scenic> helper=new InternetHelperForList<Scenic>();
            return helper.PostString(Global.url + "/AddScenic", scenic);
        }

        /// <summary>
        /// 删除景点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteScenic(string id)
        {
            return InternetHepler.Instance.GetBool(Global.url + "/DeleteScenic/" + id);
        }

        /// <summary>
        /// 获取景点集合
        /// </summary>
        /// <returns></returns>
        public List<Scenic> GetScenicInfoList()
        {
            InternetHelperForList<Scenic> helper = new InternetHelperForList<Scenic>();
            return helper.GetList(Global.url + "/GetScenicInfoList");
        }
    }
}
