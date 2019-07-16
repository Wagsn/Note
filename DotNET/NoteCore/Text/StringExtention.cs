using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Text
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtention
    {
        /// <summary>
        /// 过滤掉空格和制版符
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string FilterSpace(this string src)
        {
            return StringUtil.FilterSpace(src);
        }
    }
}
