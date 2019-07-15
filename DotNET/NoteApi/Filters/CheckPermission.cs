using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using NoteCore.Entitys;
using NoteServer.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteServer.Filters
{
    public class CheckPermission : IAsyncActionFilter
    {
        public CheckPermission(AppDbContext dbContext, string permissionItem = "")
        {
            Context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.PermissionItem = permissionItem;
        }
        //public CheckPermission(Microsoft.AspNetCore.Identity.UserManager<Users> extendUserManager, PermissionExpansionManager permissionExpansionManager, string permissionitem = "")
        //{
        //    PermissionItem = permissionitem;
        //    _userManager = extendUserManager;
        //    _permissionExpansionManager = permissionExpansionManager;
        //}
        //public CheckPermission(PermissionExpansionManager permissionExpansionManager, UserManager userManager, ValidationLoginUser validationLoginUser, string permissionitem = "")
        //{
        //    PermissionItem = permissionitem;

        //    _userManager = userManager;
        //    _permissionExpansionManager = permissionExpansionManager;
        //    _validationLoginUser = validationLoginUser ?? throw new ArgumentNullException(nameof(validationLoginUser));
        //}
        private string PermissionItem { get; }
        private AppDbContext Context { get; }
        //private UserManager _userManager { get; }
        //private PermissionExpansionManager _permissionExpansionManager { get; }

        ///// <summary>
        ///// 验证用户登录设备
        ///// </summary>
        //private ValidationLoginUser _validationLoginUser;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
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

            if (!context.ActionArguments.ContainsKey("UserId"))
            {
                context.ActionArguments.Add("UserId", user.Id);
            }
            if (context.ActionArguments.ContainsKey("User"))
            {
                context.ActionArguments["User"] = user;
            }

            await next();
            //do something after the action executes; resultContext.Result will be set
        }


    }
}
