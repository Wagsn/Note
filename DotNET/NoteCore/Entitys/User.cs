﻿using System;
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
        [MaxLength(36)]
        public string Id { get; set; }
        /// <summary>
        /// 电子邮箱（唯一）
        /// </summary>
        [MaxLength(1023)]
        [Required(ErrorMessage ="不能为空")]
        public string Email { get; set; }
        /// <summary>
        /// 昵称
        /// - 用于描述自己
        /// - 可以任意更改
        /// </summary>
        [MaxLength(63)]
        public string NickName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(511)]
        public string Password { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        [MaxLength(1023)]
        public string AvatarUrl { get; set; }
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

    /// <summary>
    /// 用户资源
    /// </summary>
    public class UserResource
    {
        
    }
}
