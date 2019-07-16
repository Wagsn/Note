using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoteCore.Entitys
{
    /// <summary>
    /// 用户（核心信息）
    /// </summary>
    public class User
    {
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 电子邮箱（唯一）
        /// </summary>
        [MaxLength(1023)]
        public string Email { get; set; }

        /// <summary>
        /// 昵称（随便改）
        /// </summary>
        [MaxLength(63)]
        public string NickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(511)]
        public string Password { get; set; }
        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        
        // 服务器端软删除所需字段
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
