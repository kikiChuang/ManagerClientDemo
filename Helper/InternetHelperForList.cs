using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ManagerClientDemo.Helper
{
    public class InternetHelperForList<T> where T:class 
    {
        /// <summary>
        /// POST方式，StringContent，返回bool型
        /// </summary>
        /// <param name="url"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool PostString(string url,T t)
        {
            string str = JsonConvert.SerializeObject(t);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var r = client.PostAsync(url, content).Result.Content.ReadAsStringAsync().Result;
            if (r.Contains("true"))
                return true;
            return false;
        }

        /// <summary>
        /// GET方式 返回对象集合
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<T> GetList(string url)
        {
            string result = InternetHepler.Instance.UrlGet(url);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(result);
            return list;
        }
    }
}
