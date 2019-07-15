using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using NoteCore.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteServer.Filters
{
    /// <summary>
    /// 登陆过滤器
    /// </summary>
    public class SignFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 当动作执行中 
        /// </summary>
        /// <param name="context">动作执行上下文</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 判断是否需要检查权限
            var noNeedCheck = false;
            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                noNeedCheck = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                  .Any(a => a.GetType().Equals(typeof(NoSignAttribute)));
            }
            if (noNeedCheck) return;

            // 检查登陆
            // 获取登陆信息
            User user = null;
            StringValues userJsons;
            if (context.HttpContext.Request.Headers.TryGetValue("User", out userJsons))
            {
                var userJson = userJsons.FirstOrDefault();
                if (userJson != null)
                {
                    user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(userJson);
                }
            }
            //var userid = context.HttpContext.Session.GetString("user.id");
            //var email = context.HttpContext.Session.GetString("user.email");
            //var password = context.HttpContext.Session.GetString("user.password");

            var userInfo = new User();

            // 检查登陆信息
            if (user == null && user.Id == null)
            {
                context.Result = new ContentResult()
                {
                    Content = "当前用户无效",
                    StatusCode = 403,
                };
            }
            context.ActionArguments.Add("User", userInfo);

            base.OnActionExecuting(context);
        }
    }
    /// <summary>
    /// 不需要权限登陆的地方加个特性
    /// </summary>
    public class NoSignAttribute : ActionFilterAttribute { }
}
