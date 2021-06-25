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
    /// 笔记控制器
    /// </summary>
    [Route("api/[controller]")]
    ////[ApiController]
    public class NoteController: ControllerBase
    {
        private AppDbContext Context { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public NoteController(AppDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public object GetAll()
        {
            return new
            {
                Code = ResponseCode.Success,
                Data = Context.Notes.Where(a => !a.Deleted).ToList()
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("delete")]
        public object Delete([FromQuery]Note request)
        {
            var entity = Context.Notes.AsNoTracking().Where(a => (!a.Deleted) && a.Id.Equals(request.Id)).FirstOrDefault();
            if (entity == null)
            {
                return new
                {
                    Code = ResponseCode.NotFound,
                    Message = "找不到N对象信息",
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("save")]
        public object Save([FromQuery]Note request)
        {
            if(request.Id == null)
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
                var entity = Context.Notes.AsNoTracking().Where(a => (!a.Deleted) && a.Id.Equals(request.Id)).FirstOrDefault();
                if (entity == null)
                {
                    return new
                    {
                        Code = ResponseCode.NotFound,
                        Message = "找不到对象信息",
                        Data = request
                    };
                }
                entity.Title = request.Title;
                entity.Content = request.Content;
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
