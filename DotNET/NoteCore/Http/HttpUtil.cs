using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NoteCore.Http
{
    /// <summary>
    /// HTTP 工具
    /// </summary>
    public class HttpUtil
    {
        /// <summary>
        /// 将对象转换成Query字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string ToQueryString<T>(T query)
        {
            var props = query.GetType().GetProperties();
            var values = props.Where(a => a.GetValue(query) != null)
                .Select(a => $"{a.Name}={HttpUtility.UrlEncode(a.GetValue(query).ToString())}").ToArray();
            return string.Join("&", values);
        }

        /// <summary>
        /// 将字典传唤成Query字符串
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string ToQueryString(Dictionary<string, object> args)
        {
            var values = args.Where(a => a.Value != null)
                .Select(a => string.Format("{0}={1}", a.Key, HttpUtility.UrlEncode(a.Value.ToString()))).ToArray();
            return string.Join("&", values);
        }
    }
}
