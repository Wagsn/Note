﻿using Microsoft.EntityFrameworkCore;
using NoteCore.Entitys;
using NoteCore.Http;
using System;
using System.Linq;
using System.Reflection;

namespace NoteServer.Stores
{
    public class AppDbContext : DbContext
    {
        public AppDbContext():base(){}
        public AppDbContext(DbContextOptions options):base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteUserRelation> NoteUserRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(a =>
            {
                a.HasKey(k => k.Id);
            });
            modelBuilder.Entity<Note>(a =>
            {
                a.HasKey(k => k.Id);
            });
            modelBuilder.Entity<NoteUserRelation>(a =>
            {
                a.HasKey(k => new { k.NoteId, k.UserId });
            });
        }

        /// <summary>
        /// 通用的分页查询工具方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<T> List<T>(PageRequest request) where T : class
        {
            var query = Set<T>().AsQueryable();
            // 过滤
            if (request.Filters != null && request.Filters.Count > 0)
            {
                foreach (var filter in request.Filters)
                {
                    query.Where(a => filter.Values.Contains(a.GetType().GetProperty(filter.Field).GetValue(a)));
                }
            }
            // 排序
            if (request.Sorts != null && request.Sorts.Count > 0)
            {
                // 无法被翻译成SQL代码
                BindingFlags flag = BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance;
                var orderQuery = request.Sorts[0].Desc ? query.OrderByDescending(a => a.GetType().GetProperty(request.Sorts[0].Field, flag).GetValue(a)) : query.OrderBy(a => a.GetType().GetProperty(request.Sorts[0].Field, flag).GetValue(a));
                for (var i = 1; i < request.Sorts.Count; i++)
                {
                    orderQuery = request.Sorts[0].Desc ? orderQuery.ThenByDescending(a => a.GetType().GetProperty(request.Sorts[0].Field, flag).GetValue(a)) : orderQuery.ThenBy(a => a.GetType().GetProperty(request.Sorts[0].Field, flag).GetValue(a));
                }
                query = orderQuery;
                //foreach (var sort in request.Sorts.Reverse())
                //{
                //    query = sort.Desc ? query.OrderByDescending(a => a.GetType().GetProperty(sort.Field).GetValue(a)) : query.OrderBy(a => a.GetType().GetProperty(sort.Field).GetValue(a));
                //}
            }
            return query;
        }

        public PageResponse<T> Page<T>(PageRequest request) where T : class
        {
            var query = List<T>(request);
            var index = request.Index;
            var size = request.Size;
            var total = query.Count();
            var count = (int)Math.Ceiling((double)total / request.Size);
            // 分页
            query = query.Skip(request.Index * request.Size).Take(request.Size);
            return new PageResponse<T>
            {
                Data = query.ToList(),
                Index = index,
                Size = size,
                Total = total,
                Count = count
            };
        }
    }
}
