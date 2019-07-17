using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteCore.Http
{
    /// <summary>
    /// 分页请求 <br/>
    /// - 排序(Sorts) <br/>
    /// - 筛选(Filters)
    /// </summary>
    public class PageRequest
    {
        /// <summary>
        /// 索引(PageIndex)
        /// </summary>
        public int Index { get; set; } = 0;
        /// <summary>
        /// 每页大小(PageSize) <br/>
        /// - 默认20
        /// </summary>
        public int Size { get; set; } = 20;
        /// <summary>
        /// 排序
        /// </summary>
        public IList<SortItem> Sorts { get; set; }
        /// <summary>
        /// 筛选
        /// </summary>
        public IList<FilterItem> Filters { get; set; }
    }

    /// <summary>
    /// 筛选项描述
    /// </summary>
    public class FilterItem
    {
        /// <summary>
        /// 所在字段
        /// </summary>
        [MaxLength(63)]
        public string Field { get; set; }
        /// <summary>
        /// 筛选方式<br/>
        /// - false 包含(Include)<br/>
        /// - true 排除(Exclude)
        /// </summary>
        public bool Exclude { get; set; } = false;
        /// <summary>
        /// 筛选值
        /// </summary>
        public IList<object> Values { get; set; }
    }

    /// <summary>
    /// 排序项描述
    /// </summary>
    public class SortItem
    {
        /// <summary>
        /// 所在字段
        /// </summary>
        [MaxLength(63)]
        public string Field { get; set; }
        /// <summary>
        /// 是否降序 <br/>
        /// - false (默认)升序(ASC) <br/>
        /// - true 降序(DESC)
        /// </summary>
        public bool Desc { get; set; } = false;
    }
}
