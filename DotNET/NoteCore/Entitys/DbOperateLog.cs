using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Entitys
{
    /// <summary>
    /// 数据库操作日志<br/>
    /// 异步写入
    /// </summary>
    public class DbOperateLog
    {
        public string Id { get; set; }
        /// <summary>
        /// 操作用户
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 数据库操作类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 操作对象的类型全名<br/>
        /// - 用于JSON反序列化<br/>
        /// TODO：数据迁移后的反序列化处理方案
        /// </summary>
        public string ObjectType { get; set; }
        /// <summary>
        /// 操作对象的JSON序列化字符串
        /// </summary>
        public string ObjectJson { get; set; }

    }
}
