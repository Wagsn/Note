using System;
using System.Collections.Generic;
using System.Text;

namespace WS.IO
{
    /// <summary>
    /// 文件写入操作
    /// </summary>
    public enum FileOption
    {
        /// <summary>
        /// 追加到文件末尾
        /// </summary>
        Append = 1,
        /// <summary>
        /// 如果文件不存在则新建
        /// </summary>
        Create = 2
    }
}
