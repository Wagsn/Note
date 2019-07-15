using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Entitys
{
    /// <summary>
    /// 请求日志
    /// </summary>
    public class RequestLog
    {
        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 请求用户
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 源IP
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }
}
