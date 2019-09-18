using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Log
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum LogOption
    {
        /// <summary>
        /// 调试
        /// </summary>
        Debug,
        /// <summary>
        /// 痕迹
        /// </summary>
        Trace,
        /// <summary>
        /// 提示
        /// </summary>
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        Warn,
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 致命
        /// </summary>
        Fatal
    }
}
