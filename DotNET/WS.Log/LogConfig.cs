using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Log
{
    public class LogConfig
    {
        /// <summary>
        /// 根路径
        /// </summary>
        public string Root { get; set; } = System.IO.Path.Combine(AppContext.BaseDirectory, "Logs");

        public string Name { get; set; }
    }
}
