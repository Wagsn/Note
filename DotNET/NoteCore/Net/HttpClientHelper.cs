using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace NoteCore.Net
{
    /// <summary>
    /// Http请求帮助类
    /// </summary>
    public class HttpClientHelper
    {
        private readonly BaseRequest.Header _header;

        public HttpClientHelper()
        {
            _header = new BaseRequest.Header
            {
                DeviceId = "",
                DeviceName = "Winfrom",
                OsName = "Window WT",
                OsVersion = "",
                Source = 3,
                Timestamp = ConvertHelper.UnixTimestamp.FromDateTime(DateTime.Now),
                VersionCode = "1.0.0",
                VersionName = "1.0.0"
            };
        }

        /// <summary>
        /// Http Get Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>(string cmd, Dictionary<String, Object> args = null) where T : BaseResponse
        {
            return Execute<T>(cmd, HttpMethod.GET, args, string.Empty);
        }

        /// <summary>
        /// Http Get Request
        /// </summary>
        /// <returns></returns>
        public void Get(string cmd, Dictionary<String, Object> args = null)
        {
            Execute<BaseResponse>(cmd, HttpMethod.GET, args, string.Empty);
        }

        public T Post<T, P>(string cmd, P postEntity, Dictionary<String, Object> args = null) where T : BaseResponse
            where P : class
        {
            var body = string.Empty;
            if (postEntity != null && typeof(P).Name != "String")
            {
                body = Newtonsoft.Json.JsonConvert.SerializeObject(postEntity);
            }
            else
            {
                body = postEntity as string;
            }
            return Execute<T>(cmd, HttpMethod.POST, args, body);
        }

        public T Post<T>(string cmd, Dictionary<String, Object> fromArgs) where T : BaseResponse
        {
            var body = ToQueryString(fromArgs);
            return Execute<T>(cmd, HttpMethod.POST, args: null, body: body, contentType: "application/x-www-form-urlencoded");
        }


        public void Post<P>(string cmd, P postEntity, Dictionary<String, Object> args = null) where P : class
        {
            var body = "";
            if (postEntity != null)
            {
                body = Newtonsoft.Json.JsonConvert.SerializeObject(postEntity);
            }
            Execute<ResponseMessage>(cmd, HttpMethod.POST, args, body);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">接口地址</param>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="args">请求的URL参数</param>
        /// <param name="body">请求的BODY参数</param>
        /// <returns></returns>
        private T Execute<T>(string path, HttpMethod httpMethod, Dictionary<String, Object> args, string body, string contentType = "application/json") where T : BaseResponse
        {
            var query = "";
            if (args != null)
            {
                query = ToQueryString(args);
            }
            if (!String.IsNullOrEmpty(query))
            {
                query = "?" + query;
            }
            var uri = new Uri("http://localhost:5001" + "/" + path + query);
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);

            webRequest.ContentType = contentType;
            webRequest.Accept = "application/json";
            webRequest.Method = httpMethod.ToString();
            webRequest.Timeout = 1000 * 3600;
            //webRequest.Headers.Add("authorization", $"{"Bearer"} {" 1635131"}");
            //webRequest.Headers.Add("ReqHeader", Newtonsoft.Json.JsonConvert.SerializeObject(_header));
            try
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                if (httpMethod == HttpMethod.POST && !String.IsNullOrEmpty(body))
                {
                    using (Stream stream = webRequest.GetRequestStream())
                    {
                        var jsonByte = Encoding.UTF8.GetBytes(body);
                        stream.Write(jsonByte, 0, jsonByte.Length);
                    }
                }
                else
                {
                    webRequest.ContentLength = 0;
                }

                var webResponse = webRequest.GetResponse();
                using (var myStreamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(myStreamReader.ReadToEnd());
                    webResponse.Close();
                    webRequest.Abort();
                    watch.Stop();
                    return result;
                }
            }
            catch (Exception ex)
            {
                webRequest.Abort();
                return new ResponseMessage { Code = "500", Message = ex.Message } as T;
            }
        }

        ///// <summary>
        ///// 上传图片
        ///// </summary>
        ///// <param name="cmd"></param>
        ///// <param name="file"></param>
        ///// <returns></returns>
        //public bool Upload(string cmd, XFileInfo file)
        //{
        //    var uri = new Uri("http://localhost:1001/upload" + "/" + cmd);
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        var encoding = Encoding.UTF8;
        //        // 分界线
        //        string boundary = string.Format("{0}", DateTime.Now.Ticks.ToString("x")),       // 分界线可以自定义参数 
        //               beginBoundary = string.Format("--{0}\r\n", boundary),
        //               endBoundary = string.Format("\r\n--{0}--\r\n", boundary);
        //        byte[] beginBoundaryBytes = encoding.GetBytes(beginBoundary),
        //        endBoundaryBytes = encoding.GetBytes(endBoundary);
        //        // 组装开始分界线数据体 到内存流中
        //        memoryStream.Write(beginBoundaryBytes, 0, beginBoundaryBytes.Length);
        //        // 组装 上传文件附加携带的参数 到内存流中

        //        string template = string.Format("Content-Disposition: form-data; name=\"fileGuid\"\r\nContent-Length: {2}\r\n\r\n{0}\r\n{1}", file.Id, beginBoundary, file.Id.Length);
        //        byte[] templateBytes = encoding.GetBytes(template);
        //        memoryStream.Write(templateBytes, 0, templateBytes.Length);

        //        template = string.Format("Content-Disposition: form-data; name=\"name\"\r\nContent-Length: {2}\r\n\r\n{0}\r\n{1}", file.Name, beginBoundary, file.Name.Length);
        //        templateBytes = encoding.GetBytes(template);
        //        memoryStream.Write(templateBytes, 0, templateBytes.Length);

        //        var fileStream = new FileStream(file.Path, FileMode.Open, FileAccess.Read);
        //        var length = fileStream.Length;
        //        // 组装文件头数据体 到内存流中
        //        template = string.Format("Content-Disposition: form-data; name=\"file\"; filename=\"{0}\"\r\nContent-Type: multipart/form-data\r\nContent-Length: {1}\r\n\r\n", file.Name, length);
        //        templateBytes = encoding.GetBytes(template);
        //        memoryStream.Write(templateBytes, 0, templateBytes.Length);
        //        // 组装文件流 到内存流中
        //        byte[] buffer = new byte[length];
        //        int size = fileStream.Read(buffer, 0, buffer.Length);
        //        while (size > 0)
        //        {
        //            memoryStream.Write(buffer, 0, size);
        //            size = fileStream.Read(buffer, 0, buffer.Length);
        //        }
        //        // 组装结束分界线数据体 到内存流中
        //        memoryStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
        //        // 获取二进制数据
        //        byte[] postBytes = memoryStream.ToArray();
        //        // HttpWebRequest 组装
        //        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
        //        webRequest.Method = HttpMethod.POST.ToString();
        //        webRequest.Timeout = 10000;
        //        webRequest.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
        //        webRequest.ContentLength = postBytes.Length;
        //        //webRequest.UserAgent = "okhttp/3.10.0";
        //        //webRequest.KeepAlive = true;

        //        //if (Regex.IsMatch(parameter.Url, "^https://"))
        //        //{
        //        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        //        //    ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
        //        //}
        //        // 写入上传请求数据
        //        try
        //        {
        //            using (Stream requestStream = webRequest.GetRequestStream())
        //            {
        //                requestStream.Write(postBytes, 0, postBytes.Length);
        //                requestStream.Close();
        //            }
        //            // 获取响应
        //            using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
        //            {
        //                using (var reader = new StreamReader(webResponse.GetResponseStream(), encoding))
        //                {
        //                    string body = reader.ReadToEnd();
        //                    if (!string.IsNullOrEmpty(body))
        //                    {
        //                        var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(body);
        //                        if (obj["code"]?.ToString() == "0")
        //                        {
        //                            file.Url = obj["path"]?.ToString();
        //                            file.Status = true;
        //                            file.FileExt = obj["ext"]?.ToString();
        //                        }
        //                    }
        //                    reader.Close();
        //                }
        //                webResponse.Close();
        //                webRequest.Abort();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        static private bool IsBulitinType(Type type)
        {
            return (type == typeof(object) || Type.GetTypeCode(type) != TypeCode.Object);
        }

        private string ToQueryString(Dictionary<String, Object> args)
        {
            var values = args.Where(a => a.Value != null)
                .Select(a => String.Format("{0}={1}", a.Key, HttpUtility.UrlEncode(a.Value.ToString()))).ToArray();

            return String.Join("&", values);
        }


        public enum HttpMethod
        {
            POST,
            GET,
            PUT,
        }
    }
}
