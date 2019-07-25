namespace NoteCore.Text
{
    /// <summary>
    /// 字符串工具
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        /// 去掉字符串的空格/换行符等非法字符
        /// </summary>
        public static string FilterSpace(string str) => str.TrimAll();

        /// <summary>
        /// 去掉所有排版符<br/>
        /// - 空格、制表符、换行回车
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimAll(this string str) => System.Text.RegularExpressions.Regex.Replace(str, @"\s|\t|\r|\n", string.Empty);
    }
}
