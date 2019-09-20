using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Log
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 没有
        /// </summary>
        None = 0,
        /// <summary>
        /// 痕迹
        /// </summary>
        Trace = 1,
        /// <summary>
        /// 调试
        /// </summary>
        Debug = 2,
        /// <summary>
        /// 提示
        /// </summary>
        Info = 4,
        /// <summary>
        /// 警告
        /// </summary>
        Warn = 8,
        /// <summary>
        /// 错误
        /// </summary>
        Error = 16,
        /// <summary>
        /// 致命
        /// </summary>
        Fatal = 32,
        /// <summary>
        /// 所有
        /// </summary>
        All = 63
    }
}
