using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ManagerClientDemo.Helper
{
    /// <summary>
    /// ������ҳ�����񣩰�����
    /// </summary>
    public class InternetHepler
    {
        private static InternetHepler _instance = null;
        private static readonly object lockHelper = new object();
        private InternetHepler() { }
        public static InternetHepler Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (null == _instance)
                        {
                            _instance = new InternetHepler();
                        }
                    }
                }
                return _instance;
            }
        }

        

        public bool GetBool(string url)
        {
            string result = Instance.UrlGet(url);
            if (result.Contains("true"))
                return true;
            return false;
        }

        /// <summary>
        /// jObject POST ���󷽷�
        /// </summary>
        /// <param name="jObject"></param>
        /// <param name="controller">url</param>
        /// <returns></returns>
        public string PostJObject(JObject jObject, string controller)
        {
            WebClient c = new WebClient();
            c.Headers[HttpRequestHeader.ContentType] = "application/json";
            c.Encoding = System.Text.Encoding.UTF8; //�������ı�������,�˴�������gb2312
            string result = c.UploadString(Global.url + "/" + controller, jObject.ToString(Newtonsoft.Json.Formatting.None, null));
            return result;
        }

        /// <summary>
        /// �첽 GET��ʽ
        /// ���ص�Task<string>��һ����Task<string>������Ƕ���Json�����л�
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> UrlGetAsync(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);   
                string ds = response.Content.ReadAsStringAsync().Result;
                return ds;
            }
            catch (HttpRequestException x)
            {
                return "�޷����ӷ�����.....";
            }
        }

        /// <summary>
        /// ͬ�� GET��ʽ
        /// ���ص�string��һ����string������Ƕ���Json�����л�
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string UrlGet(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> response = client.GetAsync(url);
                string ds = response.Result.Content.ReadAsStringAsync().Result;
                return ds;
            }
            catch (Exception x)
            {
                return "�޷����ӷ�����.....";
            }
        }
        
    }
}