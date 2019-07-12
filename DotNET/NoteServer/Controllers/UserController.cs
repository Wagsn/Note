using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteCore.Entitys;
using NoteCore.Net;
using NoteServer.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteServer.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppDbContext Context { get; }

        public UserController(AppDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet("list")]
        public object GetAll()
        {
            return new
            {
                Code = ResponseCode.Success,
                Data = Context.Users.Where(a => !a.Deleted).ToList()
            };
        }

        [HttpGet("delete")]
        public object Delete([FromQuery]User request)
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
            entity.Deleted = true;
            entity.DeleteTime = DateTime.Now;

            Context.Update(entity);
            Context.SaveChanges();
            return new
            {
                Code = ResponseCode.Success,
                Data = request
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
                        Message = "找不到Note",
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
