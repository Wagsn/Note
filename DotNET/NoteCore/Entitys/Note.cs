using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoteCore.Entitys
{
    /// <summary>
    /// 笔记实体
    /// </summary>
    public class Note
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [MaxLength(36)]
        public string Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(127)]
        public string Title { get; set; }
        /// <summary>
        /// 正文
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        // 服务器软删除所需字段
        /// <summary>
        /// 已删除
        /// </summary>
        public bool Deleted { get; set; } = false;
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }
    }
}
