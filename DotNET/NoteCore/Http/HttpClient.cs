using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace NoteCore.Http
{
    /// <summary>
    /// HTTP请求客户端
    /// </summary>
    public class HttpClient
    {
        /// <summary>
        /// 通用GET请求
        /// </summary>
        /// <typeparam name="Res">响应体</typeparam>
        /// <typeparam name="Req">请求体</typeparam>
        /// <param name="url">URL连接</param>
        /// <param name="req">查询条件</param>
        /// <returns></returns>
        public static Res Get<Res, Req>(string url, Req req)
        {
            var query = "?" + HttpUtil.ToQueryString(req);

            var uri = new Uri(url+query);
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            //webRequest.ContentType = "application/json";
            webRequest.Accept = "application/json";
            webRequest.Method = "GET";
            webRequest.Timeout = 1000 * 3600;
            //httpRequest.Headers.Add("key", "value");

            webRequest.ContentLength = 0;

            try
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                //var requestStream = webRequest.GetRequestStream();
                //var jsonByte = Encoding.UTF8.GetBytes("body string");
                //requestStream.Write(jsonByte, 0, jsonByte.Length);

                var webResponse = webRequest.GetResponse();
                using (var streamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Res>(streamReader.ReadToEnd());
                    webResponse.Close();
                    webRequest.Abort();
                    watch.Stop();
                    return result;
                }
            }
            catch (Exception)
            {
                webRequest.Abort();
                //return new ResponseMessage { Code = "500", Message = ex.Message } as T;
                return default(Res);
            }
        }
    }
}
