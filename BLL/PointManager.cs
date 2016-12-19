using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerClientDemo.Entities;
using ManagerClientDemo.Helper;

namespace ManagerClientDemo.BLL
{
    public class PointManager
    {
        #region  Instance
        private static PointManager _instance = null;
        private static readonly object SyncRoot = new object();

        public static PointManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (null == _instance)
                        {
                            _instance = new PointManager();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 统计固定时间人流量
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int StatisticsPedestrianVolume(string startTime, string endTime)
        {
            string start = startTime.Split(' ').FirstOrDefault().Replace("/","-");
            string end= endTime.Split(' ').FirstOrDefault().Replace("/", "-");
            string url = Global.url + "/StatisticsPedestrianVolume/" + start + "/" + end;
            string r = InternetHepler.Instance.UrlGet(url);
            return int.Parse(r);
        }

        /// <summary>
        /// 获取符合条件的游客们的当前位置（根据手机号/姓名）
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Tourist> GetTouristLocation(string filter)
        {
            string url = Global.url + "/GetTouristLocation/" + filter;
            InternetHelperForList<Tourist> helper = new InternetHelperForList<Tourist>();
            return helper.GetList(url);
        }

        /// <summary>
        /// 获取符合条件的游客们的当天行迹（根据手机号/姓名）
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<Schedule> GetTouristsSchedules(string filter, DateTime startTime, DateTime endTime)
        {
            string start = startTime.ToString().Split(' ').FirstOrDefault().Replace("/", "-");    //只要年月日,2016/6/17->2016-6-17
            string end = endTime.ToString().Split(' ').FirstOrDefault().Replace("/", "-");
            string url = Global.url + "/GetTouristsSchedules/"+ filter+"/" + start + "/" + end;
            InternetHelperForList<Schedule> helper = new InternetHelperForList<Schedule>();
            return helper.GetList(url);
        }

        /// <summary>
        /// 获取景区所有用户位置
        /// </summary>
        /// <returns></returns>
        public List<Tourist> GetTouristsLocations()
        {
            string url = Global.url + "/GetTouristsLocations";
            InternetHelperForList<Tourist> helper = new InternetHelperForList<Tourist>();
            return helper.GetList(url);
        }
    }
}
