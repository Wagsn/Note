using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteCore.Entitys;
using NoteCore.Http;
using NoteServer.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteServer.Controllers
{
    /// <summary>
    /// 登陆控制器<br/>
    /// Created by Wagsn on 2019/07/16.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SignController : ControllerBase
    {
        public AppDbContext Context { get; }

        public SignController(AppDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="request"></param>
        [HttpGet("up")]
        public async Task<object> SignUp (User request)
        {
            var response = new ResponseBody();
            if(await Context.Set<User>().AnyAsync(a => (!a.Deleted) && a.Email.Equals(request.Email)))
            {
                response.Code = ResponseCode.ObjectAlreadyExists;
                response.Message = "该账户已经存在";
            }
            var now = DateTime.Now;
            var user = new User
            {
                Email = request.Email,
                NickName = request.NickName,
                Password = request.Password,
                CreateTime = now,
                UpdateTime = now,
                Id = Guid.NewGuid().ToString()
            };
            Context.Add(user);
            await Context.SaveChangesAsync();
            return new ResponseBody();
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="request"></param>
        [HttpGet("off")]
        public void SignOff(User request)
        {
            Context.Set<User>().Where(a => !a.Deleted);
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="user"></param>
        [HttpGet("in")]
        public void SignIn(User user)
        {
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="user"></param>
        [HttpGet("out")]
        public void SignOut(User user)
        {
        }
    }
}
