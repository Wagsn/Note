using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Log
{
    /// <summary>
    /// 日志器
    /// </summary>
    public interface ILogger
    {
        LogConfig Config { get; set; }

        void Log(string message, LogOption option = default(LogOption));
    }
}
