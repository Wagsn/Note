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

        public void Log(string message, LogOption option = LogOption.Trace)
        {
            Log(Config.Root, Config.Name, message, option);
        }

        public static void Log(string root, string name, string message, LogOption option)
        {
            var now = DateTime.Now;
            var text = $"[{now.ToString("yyyy-MM-dd HH:mm:ss.FFFFFF")}] [{option.ToString()}] [{name}] {message}";
            Console.WriteLine(text);
            FileHelper.WriteAllText($"{System.IO.Path.Combine(root, now.ToString("yyyyMMdd"), $"{name}.log")}", text+"\r\n");
        }
    }
}
