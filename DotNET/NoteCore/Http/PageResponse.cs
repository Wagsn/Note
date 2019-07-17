using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Http
{
    /// <summary>
    /// 分页响应体
    /// </summary>
    public class PageResponse<T> : ResponseBody<IList<T>>
    {
        /// <summary>
        /// 分页索引 PageIndex
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 每页大小 PageSize
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 分页数量 PageCount
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 对象总数 TotalCount
        /// </summary>
        public long Total { get; set; }
    }
}
