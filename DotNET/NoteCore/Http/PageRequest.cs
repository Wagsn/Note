using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteCore.Http
{
    /// <summary>
    /// 分页请求
    /// </summary>
    public class PageRequest
    {
        /// <summary>
        /// 索引 PageIndex
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 每页大小 PageSize
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public IList<SortItem> Sorts { get; set; }
    }

    public class SortItem
    {
        /// <summary>
        /// 所在字段
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 是否降序
        /// </summary>
        public bool Dsc { get; set; }
    }
}
