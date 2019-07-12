﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NoteCore.Entitys;
using NoteServer.Stores;

namespace NoteServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().Build();

            // 数据库初始化
            DbInit(host);

            host.Run();
        }

        /// <summary>
        /// 数据库初始化
        /// </summary>
        /// <param name="host"></param>
        public static void DbInit(IWebHost host)
        {
            // 数据库初始化
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    context.Database.EnsureCreated();
                    var wagsn = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        NickName = "Wagsn",
                        Email = "wagsn@foxmail.com",
                        Password = "123456"
                    };
                    context.Add(wagsn);
                    var admin = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        NickName = "Admin",
                        Email = "wagsn@foxmail.com",
                        Password = "123456"
                    };
                    context.Add(admin);
                    var now = DateTime.Now;
                    var first = new Note
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "第一篇笔记",
                        Content = "这是我的第一篇笔记",
                        CreateTime = now,
                        UpdateTime = now
                    };
                    context.Add(first);
                    context.AddRange(new List<NoteUserRelation>
                    {
                        new NoteUserRelation{UserId =wagsn.Id, NoteId =first.Id}
                    });
                    context.SaveChanges();

                }
                catch (Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occurred while seeding the database.");
                }
            }
        }
    }
}