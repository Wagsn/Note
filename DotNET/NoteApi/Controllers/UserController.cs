using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NoteCore;
using NoteCore.Entitys;
using NoteCore.Http;
using NoteServer.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NoteServer.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [Route("api/[controller]")]
    //[ApiController]  // 会自动拦截模型验证错误，返回400错误
    public class UserController : ControllerBase
    {
        private AppDbContext Context { get; }
        private IConfigurationRoot Config { get; }
        //private ILogger Logger { get; }

        public UserController(AppDbContext context, IConfigurationRoot config)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Config = config ?? throw new ArgumentNullException(nameof(config));
            //Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("test")]
        public object TestDynamicExpression([FromBody]PageRequest request)
        {
            // 键选择器，用户排序
            //var type = typeof(User);
            //var propName = "NickName";
            //var param = Expression.Parameter(type, type.Name);
            //var body = Expression.Property(param, propName);
            //var keySelector = Expression.Lambda(body, param);
            //var list = Queryable.OrderBy(Context.Set<User>(), (dynamic)keySelector);
            //var list2 = Context.Set<User>().OrderBy((Expression<Func<User, string>>)keySelector);
            //var list3 = Context.Set<User>().OrderBy("NickName");
            //var orderStrList = new string[] { "NickName", "Email" };
            //var orderQuery = Context.Set<User>().OrderBy(orderStrList[0]);
            //for(var i=1; i < orderStrList.Count(); i++)
            //{
            //    orderQuery = orderQuery.ThenBy(orderStrList[i]);
            //}
            //var list4 = orderQuery.ToList();
            var list5 = Context.Set<User>().FilterAndSort(request).ToList();

            return new
            {
                Code = 0,
                Data = list5
            };
        }

        /// <summary>
        /// 字段排序和筛选，分页请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public object GetAll([FromQuery]PageRequest request)
        {
            return Context.Set<User>().Where(a => !a.Deleted).OrderByDescending(a => a.CreateTime).FilterAndSort(request).Page(request);
        }

        // http://localhost:5000/api/user/list/ids?[0]=0cab50ab-f571-4945-b3f5-88a3873f0139
        [HttpGet("list/ids")]
        public object GetAll([FromQuery]IList<string> ids)
        {
            if(ids == null || ids.Count == 0)
            {
                return new
                {
                    Code = ResponseCode.Success,
                    Data = Context.Set<User>().Where(a => !a.Deleted).ToList()
                };
            }
            return new
            {
                Code = ResponseCode.Success,
                Data = Context.Set<User>().Where(a => !a.Deleted).Where(a => ids.Contains(a.Id)).ToList()
            };
        }

        [HttpGet("delete/{id}")]
        public object Delete([FromRoute]string id)
        {
            var entity = Context.Set<User>().AsNoTracking().Where(a => (!a.Deleted) && a.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                return new
                {
                    Code = ResponseCode.NotFound,
                    Message = "找不到对象信息",
                };
            }
            entity.Deleted = true;
            entity.DeleteTime = DateTime.Now;

            Context.Update(entity);
            Context.SaveChanges();
            return new
            {
                Code = ResponseCode.Success,
                Data = entity
            };
        }

        [HttpGet("save")]
        public object Save([FromQuery]User request)
        {
            if (request.Id == null)
            {
                request.Id = Guid.NewGuid().ToString();
                var now = DateTime.Now;
                if (request.CreateTime == null)
                {
                    request.CreateTime = now;
                }
                request.UpdateTime = now;
                Context.Add(request);
                Context.SaveChanges();
                return new
                {
                    Code = ResponseCode.Success,
                    Data = request
                };
            }
            else
            {
                var entity = Context.Users.AsNoTracking().Where(a => (!a.Deleted) && a.Id.Equals(request.Id)).FirstOrDefault();
                if (entity == null)
                {
                    return new
                    {
                        Code = ResponseCode.NotFound,
                        Message = "找不到对象信息",
                        Data = request
                    };
                }
                entity.NickName = request.NickName;
                entity.Password = request.Password;
                entity.Email = request.Email;
                entity.UpdateTime = DateTime.Now;
                Context.Update(entity);
                Context.SaveChanges();
                return new
                {
                    Code = ResponseCode.Success,
                    Data = entity
                };
            }
        }
    }
}
