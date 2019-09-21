using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NoteWinform
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DbInit();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Views.MainForm());
            //Application.Run(new Views.EditForm());
            //Application.Run(new Views.TableForm());
        }

        static void DbInit()
        {
            using(var context = new NoteWinCore.Stores.AppDbContext())
            {
                context.Database.EnsureCreated();

                if(context.Users.Any() || context.Notes.Any() || context.NoteUserRelations.Any())
                {
                    return;
                }

                var wagsn = new NoteCore.Entitys.User
                {
                    Id = Guid.NewGuid().ToString(),
                    NickName = "Wagsn",
                    Email = "wagsn@foxmail.com",
                    Password = "123456"
                };

                context.Users.AddRange(new List<NoteCore.Entitys.User>
                {
                    wagsn
                });

                var first = new NoteCore.Entitys.Note
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "第一篇笔记",
                    Content = "这是第一篇笔记，开始你的记录之旅吧。",
                    CreateTime = DateTime.Now,
                    Deleted = false
                };

                context.Notes.AddRange(new List<NoteCore.Entitys.Note>
                {
                    first
                });

                context.Add(new NoteCore.Entitys.NoteUserRelation
                {
                    UserId = wagsn.Id,
                    NoteId = first.Id
                });

                context.SaveChanges();
            }
        }
    }
}
