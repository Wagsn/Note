using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoteCore.Entitys
{
    /// <summary>
    /// 数据库操作日志<br/>
    /// 异步写入
    /// </summary>
    public class DbOperateLog
    {
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// 操作用户ID
        /// </summary>
        [MaxLength(36)]
        public string UserId { get; set; }
        /// <summary>
        /// 数据库操作类型
        /// </summary>
        [MaxLength(63)]
        public string Type { get; set; }
        /// <summary>
        /// 备忘<br/>
        /// 如：封禁账号
        /// </summary>
        [MaxLength(63)]
        public string Memo { get; set; }
        /// <summary>
        /// 操作对象ID<br/>
        /// - 用来追踪操作对象
        /// </summary>
        [MaxLength(36)]
        public string ObjectId { get; set; }
        /// <summary>
        /// 操作对象的类型全名<br/>
        /// - 用于JSON反序列化<br/>
        /// TODO：数据迁移后的反序列化处理方案
        /// </summary>
        [MaxLength(255)]
        public string ObjectType { get; set; }
        /// <summary>
        /// 操作对象的JSON序列化字符串<br/>
        /// - 保存对象信息的副本
        /// </summary>
        public string ObjectJson { get; set; }
    }
}
