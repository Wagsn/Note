using NoteCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NoteCore
{
    /// <summary>
    /// IQueryable Extension<br/>
    /// </summary>
    public static class IQueryableExtension
    {
        /// <summary>
        /// 在内存中进行过滤排序操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IQueryable<T> List<T>(this IQueryable<T> source, PageRequest request)
        {
            var query = source;
            BindingFlags flag = BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance;
            // 过滤
            if (request.Filters != null && request.Filters.Count > 0)
            {
                foreach (var filter in request.Filters)
                {
                    query.Where(a => filter.Values.Contains(a.GetType().GetProperty(filter.Field, flag).GetValue(a)));
                }
            }
            // 排序
            if (request.Sorts != null && request.Sorts.Count > 0)
            {
                // 无法被翻译成SQL代码
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
        /// 分页操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static PageResponse<T> Page<T>(this IQueryable<T> source, PageRequest request)
        {
            var query = source;
            var index = request.Index;
            var size = request.Size;
            var total = query.Count();
            var count = (int)Math.Ceiling((double)total / size);
            query = query.Skip(index * size).Take(size);
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
