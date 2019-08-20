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
    //[ApiController]  // 会将模型验证失败转换成400错误返回
    public class SignController : ControllerBase
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public AppDbContext Context { get; }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="context"></param>
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
                response.Code = ResponseCode.AlreadyExists;
                response.Message = "该账户已经存在";
            }
            var now = DateTime.Now;
            var entity = new User
            {
                Email = request.Email,
                NickName = request.NickName,
                Password = request.Password,
                CreateTime = now,
                UpdateTime = now,
                Id = Guid.NewGuid().ToString()
            };
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return new ResponseBody();
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="request"></param>
        [HttpGet("off")]
        public async Task<object> SignOff(User request)
        {
            var response = new ResponseBody();
            if(request.Id == null)
            {
                response.Code = ResponseCode.ArgumentNullError;
                response.Message = "用户标识不能为空";
                return response;
            }
            var entity = await Context.Set<User>().AsNoTracking().Where(a => !a.Deleted).Where(a => a.Id.Equals(request.Id)).SingleOrDefaultAsync();
            if(entity == null)
            {
                response.Code = ResponseCode.NotFound;
                response.Message = "该用户不存在";
                return response;
            }
            entity.Deleted = true;
            entity.DeleteTime = DateTime.Now;
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return response;
        }
        /// <summary>
        /// 登陆<br/>
        /// - 通过Session保存登陆信息？
        /// </summary>
        /// <param name="request"></param>
        [HttpGet("in")]
        public object SignIn(User request)
        {
            var response = new ResponseBody();

            return response;
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="request"></param>
        [HttpGet("out")]
        public object SignOut(User request)
        {
            var response = new ResponseBody();

            return response;
        }
    }
}
