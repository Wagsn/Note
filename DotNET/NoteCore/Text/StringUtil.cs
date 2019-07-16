using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Text
{
    /// <summary>
    /// 字符串工具
    /// </summary>
    public class StringUtil
    {
        /// <summary>
        /// 去掉字符串的空格/换行符等非法字符
        /// </summary>
        public static string FilterSpace(string str)
        {
            str = str.Trim();
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s|\t|\r|\n", string.Empty);
            return str;
        }
    }
}
