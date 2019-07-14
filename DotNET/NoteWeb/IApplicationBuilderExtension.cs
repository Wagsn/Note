using Microsoft.AspNetCore.Builder;
using NoteCore.Entitys;
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
        public static readonly string UserKey = "User";

        /// <summary>
        /// 解析HTTP请求头部，注入用户信息
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseUserInfo(this IApplicationBuilder builder)
        {
            return builder.Use(next =>
            {
                return async context =>
                {
                    var userInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(context.Request.Headers[UserKey]);
                    if (userInfo != null)
                    {
                        context.Items.Add(UserKey, userInfo);
                    }
                    await next(context);
                };
            });
        }
    }
}
