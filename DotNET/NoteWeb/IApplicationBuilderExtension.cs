using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteWeb
{
    /// <summary>
    /// 应用生成器扩展
    /// </summary>
    public static class IApplicationBuilderExtension
    {
        /// <summary>
        /// 解析HTTP请求头部，注入用户信息
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseUserInfo(this IApplicationBuilder builder)
        {

            return null;
        }
    }
}
