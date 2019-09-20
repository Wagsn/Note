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
        public static ILogger Get<CategoryName>()
        {
            return new DefaultLogger
            {
                Config = new LogConfig
                {
                    Name = typeof(CategoryName).FullName,
                    Root = System.IO.Path.Combine(AppContext.BaseDirectory, "Log")
                }
            };
        }

        public static ILogger GetLogger(string categoryName)
        {
            return new DefaultLogger
            {
                Config = new LogConfig
                {
                    Name = categoryName,
                    Root = System.IO.Path.Combine(AppContext.BaseDirectory, "Log")
                }
            };
        }
    }
}
