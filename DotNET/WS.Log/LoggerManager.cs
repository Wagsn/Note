using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Log
{
    /// <summary>
    /// 日志器管理器
    /// </summary>
    public class LoggerManager
    {
        public static ILogger Get<Name>()
        {
            return new DefaultLogger
            {
                Config = new LogConfig
                {
                    Name = typeof(Name).FullName,
                    Root = System.IO.Path.Combine(AppContext.BaseDirectory, "Log")
                }
            };
        }
    }
}
