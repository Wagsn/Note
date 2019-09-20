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

        void Log<TState>(TState state, Exception exception, Func<TState, Exception, string> formatter, LogLevel logLevel = LogLevel.Trace);

        void Log<TState>(TState state, Func<TState, string> formatter, LogLevel logLevel = LogLevel.Trace);

        void Log(string message, LogLevel option = LogLevel.Trace);
    }
}
