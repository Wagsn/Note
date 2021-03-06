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
    /// <summary>
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // 导入配置文件
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            var host = WebHost.CreateDefaultBuilder(args)
                // 使用配置，可以在Startup的构造函数中接收到
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .UseUrls($"http://*:{config["Port"]}")
                .Build();

            // 数据库初始化
            DbInit(host);

            host.Run();
        }

        /// <summary>
        /// 数据库初始化
        /// </summary>
        /// <param name="host"></param>
        public static void DbInit(IWebHost host, IConfigurationRoot config = null)
        {
            // 数据库初始化
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<AppDbContext>();
                    context.Database.EnsureCreated();
                    if(context.Users.Any() || context.Notes.Any())
                    {
                        return;
                    }
                    var now = DateTime.Now;
                    var wagsn = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        NickName = "Wagsn",
                        Email = "wagsn@foxmail.com",
                        Password = "123456",
                        CreateTime = now
                    };
                    context.Add(wagsn);
                    var admin = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        NickName = "Admin",
                        Email = "wagsn@foxmail.com",
                        Password = "123456",
                        CreateTime = now
                    };
                    context.Add(admin);
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
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occurred while seeding the database.");
                }
            }
        }
    }
}
