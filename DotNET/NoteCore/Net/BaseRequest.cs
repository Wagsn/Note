using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Net
{
    /// <summary>
    /// 基础请求信息
    /// </summary>
    public class BaseRequest
    {
        /// <summary>
        /// 请求头信息
        /// </summary>
        public class Header
        {
            /// <summary>
            /// 设备id
            /// </summary>
            public string DeviceId { get; set; }
            /// <summary>
            /// 设备名称
            /// </summary>
            public string DeviceName { get; set; }
            /// <summary>
            /// 操作系统及cpu名称
            /// </summary>
            public string OsName { get; set; }
            /// <summary>
            /// 浏览器的信息
            /// </summary>
            public string OsVersion { get; set; }
            /// <summary>
            /// 版本名称
            /// </summary>
            public string VersionName { get; set; }
            /// <summary>
            /// 版本号
            /// </summary>
            public string VersionCode { get; set; }
            /// <summary>
            /// 请求来源 （1-IOS,2-Android,3-web）
            /// </summary>
            public int Source { get; set; }
            /// <summary>
            /// 请求时间戳
            /// </summary>
            public int Timestamp { get; set; }
        }
    }
}
