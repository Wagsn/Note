using Microsoft.EntityFrameworkCore;
using NoteCore.Entitys;
using NoteCore.Http;
using System;
using System.Linq;
using System.Reflection;

namespace NoteServer.Stores
{
    /// <summary>
    /// 应用数据库上下文
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// 无参构造器
        /// </summary>
        public AppDbContext():base(){}
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions options):base(options){}
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// 用户扩展
        /// </summary>
        public DbSet<UserExt> UserExts { get; set; }
        /// <summary>
        /// 笔记
        /// </summary>
        public DbSet<Note> Notes { get; set; }
        /// <summary>
        /// 笔记用户关联
        /// </summary>
        public DbSet<NoteUserRelation> NoteUserRelations { get; set; }
        /// <summary>
        /// 模型创建时
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(a =>
            {
                a.HasKey(k => k.Id);
            });
            modelBuilder.Entity<UserExt>(a =>
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
        ///// <summary>
        ///// 配置 - 用户数据库迁移 - 用于基架生成
        ///// </summary>
        ///// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseMySql("server=localhost;database=ws_note;user=admin;password=123456;");
        //}

        /// <summary>
        /// 过滤与筛选
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
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public PageResponse<T> Page<T>(PageRequest request) where T : class
        {
            var query = List<T>(request);
            var index = request.Index;
            var size = request.Size;
            var total = query.Count();
            // 分页
            query = query.Skip(request.Index * request.Size).Take(request.Size);
            return new PageResponse<T>
            {
                Data = query.ToList(),
                Index = index,
                Size = size,
                Total = total,
            };
        }
    }
}
