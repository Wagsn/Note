using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoteCore.Entitys
{
    /// <summary>
    /// 本地笔记
    /// </summary>
    public class NoteLocal
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

        // 客户端标记所需字段
        /// <summary>
        /// 是否同步到服务器
        /// </summary>
        public bool Sync { get; set; }
    }
}
