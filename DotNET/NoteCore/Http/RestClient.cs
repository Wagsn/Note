using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NoteCore.Http
{
    /// <summary>
    /// REST Client
    /// 对 HTTP Client 做的一层封装
    /// </summary>
    public class RestClient
    {
        //ILogger Logger = LoggerManager.GetLogger("ApiClient");
        //ILogger Logger = new Logger<RestClient>(Lo);

        private static System.Net.Http.HttpClient _httpClient = null;

        static RestClient()
        {
            if (_httpClient == null)
            {
                _httpClient = new System.Net.Http.HttpClient();
                _httpClient.DefaultRequestHeaders.Connection.Clear();
                _httpClient.DefaultRequestHeaders.ConnectionClose = false;
                _httpClient.Timeout = TimeSpan.FromSeconds(15);
                // _httpClient.DefaultRequestHeaders.Accept?.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        public RestClient() { }

        /// <summary>
        /// POST请求
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <param name="method"></param>
        /// <param name="queryString"></param>
        /// <param name="timeout"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public async Task<TResponse> Post<TResponse>(string url, object body, string method = "POST", NameValueCollection queryString = null, int timeout = 60, NameValueCollection headers = null)
            where TResponse : class, new()
        {
            TResponse response = null;
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                System.Net.Http.HttpClient client = _httpClient;
                if (queryString == null)
                {
                    queryString = new NameValueCollection();
                }
                if (string.IsNullOrEmpty(method))
                {
                    method = "POST";
                }
                url = CreateUrl(url, queryString);
                //Logger.Debug("请求：{0} {1}", method, url);
                byte[] strData = Encoding.UTF8.GetBytes(json);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(strData);
                StreamContent sc = new StreamContent(ms);
                sc.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                if (headers != null)
                {
                    var keys = headers.AllKeys;
                    for (var i = 0; i < keys.Length; i++)
                    {
                        sc.Headers.Add(keys[i], headers[keys[i]]);
                    }
                }

                var res = await client.PostAsync(url, sc);
                res.EnsureSuccessStatusCode();
                byte[] rData = await res.Content.ReadAsByteArrayAsync();
                string rJson = Encoding.UTF8.GetString(rData);
                //Logger.Debug("应答：\r\n{0}", rJson);
                response = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(rJson);
                return response;
            }
            catch (System.Exception e)
            {
                TResponse r = new TResponse();
                //Logger.Error("请求异常：\r\n{0}", e.ToString());
                throw;
            }
        }

        public async Task<string> Post(string url, string body, string method = "POST", NameValueCollection queryString = null, int timeout = 60, NameValueCollection headers = null)
        {
            string response = null;
            try
            {
                string json = body;
                System.Net.Http.HttpClient client = _httpClient;
                if (queryString == null)
                {
                    queryString = new NameValueCollection();
                }
                if (String.IsNullOrEmpty(method))
                {
                    method = "POST";
                }
                url = CreateUrl(url, queryString);
                //Logger.Debug("请求：{0} {1}", method, url);
                byte[] strData = Encoding.UTF8.GetBytes(json);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(strData);
                StreamContent sc = new StreamContent(ms);
                sc.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                if (headers != null)
                {
                    var keys = headers.AllKeys;
                    for (var i = 0; i < keys.Length; i++)
                    {
                        sc.Headers.Add(keys[i], headers[keys[i]]);
                    }
                }

                var res = await client.PostAsync(url, sc);

                if (res.Content == null || res.Content.Headers.ContentLength == 0)
                {
                    response = "";
                }
                else
                {
                    byte[] rData = await res.Content.ReadAsByteArrayAsync();
                    string rJson = Encoding.UTF8.GetString(rData);
                    //Logger.Debug("应答：\r\n{0}", rJson);
                    response = rJson;
                }
            }
            catch (System.Exception e)
            {
                response = "ERROR";
                //Logger.Error("请求异常：\r\n{0}", e.ToString());
            }
            return response;
        }

        public async Task<TResponse> Get<TResponse>(string url, NameValueCollection queryString, NameValueCollection headers = null)
                    where TResponse : class, new()
        {
            TResponse response = null;
            try
            {
                System.Net.Http.HttpClient client = _httpClient;
                if (queryString == null)
                {
                    queryString = new NameValueCollection();
                }
                url = CreateUrl(url, queryString);

                if (headers != null)
                {
                    var keys = headers.AllKeys;
                    for (var i = 0; i < keys.Length; i++)
                    {
                        client.DefaultRequestHeaders.Add(keys[i], headers[keys[i]]);
                    }
                }

                //Logger.Debug("请求：{0} {1}", "GET", url);
                byte[] rData = await client.GetByteArrayAsync(url);
                string rJson = Encoding.UTF8.GetString(rData);
                //Logger.Debug("应答：\r\n{0}", rJson);
                response = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(rJson);
            }
            catch (System.Exception e)
            {
                TResponse r = new TResponse();
                //Logger.Error("请求异常：\r\n{0}", e.ToString());
                return r;
            }
            return response;
        }

        /// <summary>
        /// GET方法获取
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="queryString"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<TResponse> GetWithToken<TResponse>(string url, string token, NameValueCollection queryString = null, string userId = "", NameValueCollection headers = null)
                    where TResponse : class, new()
        {
            if (queryString != null)
            {
                url = CreateUrl(url, queryString);
            }
            HttpMethod hm = new HttpMethod("GET");

            var request = new HttpRequestMessage(hm, url);
            if (!String.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            }
            if (!String.IsNullOrEmpty(userId))
            {
                request.Headers.Add("User", userId);
            }

            if (headers != null)
            {
                var keys = headers.AllKeys;
                for (var i = 0; i < keys.Length; i++)
                {
                    request.Headers.Add(keys[i], headers[keys[i]]);
                }
            }

            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);
            string str = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException("请求失败");
            }
            var statusCode = (int)response.StatusCode;
            if (statusCode >= 300)
            {
                //throw new ApiCore.Models.RestClientException(statusCode, str);
            }

            try
            {
                if (typeof(TResponse) == typeof(string))
                {
                    return (TResponse)(object)str;
                }
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(str);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task<string> Post(string url, object body, string method, NameValueCollection queryString, NameValueCollection headers = null)
        {
            string response = null;
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                System.Net.Http.HttpClient client = _httpClient;
                if (queryString == null)
                {
                    queryString = new NameValueCollection();
                }

                url = CreateUrl(url, queryString);
                if (string.IsNullOrEmpty(method))
                {
                    method = "POST";
                }
                //Logger.Debug("请求：{0} {1}", method, url);
                byte[] strData = Encoding.UTF8.GetBytes(json);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(strData);
                StreamContent sc = new StreamContent(ms);
                sc.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                if (headers != null)
                {
                    var keys = headers.AllKeys;
                    for (var i = 0; i < keys.Length; i++)
                    {
                        sc.Headers.Add(keys[i], headers[keys[i]]);
                    }
                }

                var res = await client.PostAsync(url, sc);
                byte[] rData = await res.Content.ReadAsByteArrayAsync();
                string rJson = Encoding.UTF8.GetString(rData);
                //Logger.Debug("应答：\r\n{0}", rJson);
                response = rJson;
                return response;

            }
            catch (System.Exception e)
            {
                //Logger.Error("请求异常：\r\n{0}", e.ToString());
                throw;
            }
        }


        public async Task<TResult> PostWithToken<TResult>(string url, object body, string token, string userId = null, string method = "POST", NameValueCollection headers = null)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            string apiUrl = $"{url}";
            HttpMethod hm = new HttpMethod(method.ToUpper());

            var request = new HttpRequestMessage(hm, apiUrl);
            if (!String.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            }
            if (!String.IsNullOrEmpty(userId))
            {
                request.Headers.Add("User", userId);
            }

            if (headers != null)
            {
                var keys = headers.AllKeys;
                for (var i = 0; i < keys.Length; i++)
                {
                    request.Headers.Add(keys[i], headers[keys[i]]);
                }
            }

            string json = "";
            if (body != null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(body);
            }
            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);
            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException("请求失败");
            }
            var statusCode = (int)response.StatusCode;
            if (statusCode >= 300)
            {
                //throw new ApiCore.Models.RestClientException(statusCode, content);
            }
            try
            {
                if (typeof(TResult) == typeof(string))
                {
                    return (TResult)(object)content;
                }
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(content);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<TResult> PostWithTokenEx<TResult>(string url, object body, string token, NameValueCollection queryString = null, string userId = null, string method = "POST", NameValueCollection headers = null)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            if (queryString == null)
            {
                queryString = new NameValueCollection();
            }
            if (String.IsNullOrEmpty(method))
            {
                method = "POST";
            }
            string apiUrl = CreateUrl(url, queryString);
            HttpMethod hm = new HttpMethod(method.ToUpper());

            var request = new HttpRequestMessage(hm, apiUrl);
            if (!String.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            }
            if (!String.IsNullOrEmpty(userId))
            {
                request.Headers.Add("User", userId);
            }
            if (headers != null)
            {
                var keys = headers.AllKeys;
                for (var i = 0; i < keys.Length; i++)
                {
                    request.Headers.Add(keys[i], headers[keys[i]]);
                }
            }

            string json = "";
            if (body != null)
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(body);
            }
            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);
            string str = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException("请求失败");
            }
            var statusCode = (int)response.StatusCode;
            if (statusCode >= 300)
            {
                //throw new ApiCore.Models.RestClientException(statusCode, str);
            }
            //if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden) {
            //    throw new UnauthorizedAccessException("请求失败");
            //}

            //if ((int)response.StatusCode >= 300) {
            //    //var str2 = await response.Content.ReadAsStringAsync();
            //    //using (var fileStream = new FileStream("c:\\exception.txt", FileMode.OpenOrCreate)) {
            //    //    var data = $"statusCode = {response.StatusCode}，body = {str2}，token = {token} ";
            //    //    var bytes = Encoding.UTF8.GetBytes(data);
            //    //    await fileStream.WriteAsync(bytes, 0, bytes.Length);

            //    //    fileStream.Close();
            //    //    fileStream.Dispose();
            //    //};
            //    throw new ApiCore.Models.RestClientException(((int)response.StatusCode).ToString(), str);
            //}
            try
            {
                //  response.EnsureSuccessStatusCode();

                //sw.Stop();
                //if (sw.ElapsedMilliseconds >= 1000)
                //{
                //slowLogger.Warn("请求时间超过一秒：POST {0} {1}", apiUrl, sw.ElapsedMilliseconds);
                //}
                if (typeof(TResult) == typeof(string))
                {
                    return (TResult)(object)str;
                }
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(str);
            }
            catch (Exception e)
            {
                //logger.Error("Post 失败：{0}\r\n{1}", url, e.ToString());
                //string str = await response.Content.ReadAsStringAsync();
                //logger.Error(str);
                throw;
            }
        }


        public async Task<TResult> SubmitForm<TResult>(string url, Dictionary<string, string> formData, string method = "POST")
        {
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                var asdsd = await httpClient.PostAsync(url, new FormUrlEncodedContent(formData));

                if (asdsd.StatusCode == System.Net.HttpStatusCode.Unauthorized
                    || asdsd.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new UnauthorizedAccessException("请求失败");
                }
                var statusCode = (int)asdsd.StatusCode;
                if (statusCode >= 300)
                {
                    //throw new ApiCore.Models.RestClientException(statusCode);
                }

                //if ((int)asdsd.StatusCode >= 300) {
                //    throw new UnauthorizedAccessException("请求失败");
                //}
                asdsd.EnsureSuccessStatusCode();
                string str1 = await asdsd.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(str1);
            }

            //HttpMethod hm = new HttpMethod(method);
            //var request = new HttpRequestMessage(hm, url);
            //request.Content = new FormUrlEncodedContent(formData);
            //var response = await _httpClient.SendAsync(request);
            //if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
            //    response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            //{
            //    throw new UnauthorizedAccessException("验证失败");
            //}
            //response.EnsureSuccessStatusCode();
            //string str = await response.Content.ReadAsStringAsync();
            //return Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(str);
        }


        public static string CreateUrl(string url, NameValueCollection qs)
        {
            if (qs != null && qs.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                List<string> kl = qs.AllKeys.ToList();
                foreach (string k in kl)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append("&");
                    }
                    sb.Append(k).Append("=");
                    if (!String.IsNullOrEmpty(qs[k]))
                    {

                        sb.Append(System.Net.WebUtility.UrlEncode(qs[k]));
                    }
                }


                if (url.Contains("?"))
                {
                    url = url + "&" + sb.ToString();
                }
                else
                {
                    url = url + "?" + sb.ToString();
                }
            }

            return url;

        }


    }
}
