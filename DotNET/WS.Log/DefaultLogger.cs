using System;
using System.Collections.Generic;
using System.Text;
using WS.IO;

namespace WS.Log
{
    /// <summary>
    /// 默认日志器
    /// </summary>
    class DefaultLogger : ILogger
    {
        public LogConfig Config { get; set; }

        public void Log(string message, LogLevel option = LogLevel.Trace)
        {
            Log(Config.Root, Config.Name, message, option);
        }

        public void Log<TState>(TState state, Exception exception, Func<TState, Exception, string> formatter, LogLevel logLevel = LogLevel.Trace)
        {
            Log(formatter(state, exception), logLevel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TState">应该指的是配置文件</typeparam>
        /// <param name="state"></param>
        /// <param name="formatter"></param>
        /// <param name="logLevel"></param>
        public void Log<TState>(TState state, Func<TState, string> formatter, LogLevel logLevel = LogLevel.Trace)
        {
            Log(formatter(state), logLevel);
        }

        public static void Log(string root, string name, string message, LogLevel option)
        {
            var now = DateTime.Now;
            var text = $"[{now.ToString("yyyy-MM-dd HH:mm:ss.FFFFFF")}] [{option.ToString()}] [{name}] {message}";
            Console.WriteLine(text);
            FileHelper.WriteAllText($"{System.IO.Path.Combine(root, now.ToString("yyyyMMdd"), $"{name}.log")}", text+"\r\n");
        }
    }
}
