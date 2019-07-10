using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteCore.Entitys;
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
    [ApiController]
    public class NoteController: ControllerBase
    {
        private AppDbContext Context { get; }

        public NoteController(AppDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet("list")]
        public object GetNotes()
        {
            return new
            {
                Code = "0",
                Data = Context.Notes.Where(a => !a.Deleted).ToList()
            };
        }

        [HttpGet("delete")]
        public object DeleteNote([FromQuery]Note note)
        {
            var entity = Context.Notes.AsNoTracking().Where(a => (!a.Deleted) && a.Id.Equals(note.Id)).FirstOrDefault();
            if (entity == null)
            {
                return new
                {
                    Code = "404",
                    Message = "找不到Note",
                    Data = note
                };
            }
            entity.Deleted = true;
            entity.DeleteTime = DateTime.Now;
            
            Context.Update(entity);
            Context.SaveChanges();
            return new
            {
                Code = "0",
                Data = note
            };
        }

        [HttpGet("save")]
        public object NoteSave([FromQuery]Note note)
        {
            if(note.Id == null)
            {
                note.Id = Guid.NewGuid().ToString();
                var now = DateTime.Now;
                if (note.CreateTime == null)
                {
                    note.CreateTime = now;
                }
                note.UpdateTime = now;
                Context.Add(note);
                Context.SaveChanges();
            }
            else
            {
                var entity = Context.Notes.AsNoTracking().Where(a => (!a.Deleted) && a.Id.Equals(note.Id)).FirstOrDefault();
                if (entity == null)
                {
                    return new
                    {
                        Code = "404",
                        Message = "找不到Note",
                        Data = note
                    };
                }
                entity.Title = note.Title;
                entity.Content = note.Content;
                entity.UpdateTime = DateTime.Now;
                Context.Update(entity);
                Context.SaveChanges();
            }
            return new
            {
                Code = "0",
                Data = note
            };
        }
    }
}
