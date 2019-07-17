﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NoteCore;
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
    /// 用户
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppDbContext Context { get; }
        //private ILogger Logger { get; }

        public UserController(AppDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            //Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// 字段排序和筛选，分页请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("list")]
        public object GetAll([FromBody]PageRequest request)
        {
            return Context.Set<User>().Where(a => !a.Deleted).OrderByDescending(a => a.CreateTime).List(request).Page(request);
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
                    Data = Context.Users.Where(a => !a.Deleted).ToList()
                };
            }
            return new
            {
                Code = ResponseCode.Success,
                Data = Context.Set<User>().Where(a => !a.Deleted).Where(a => ids.Contains(a.Id)).ToList()
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
