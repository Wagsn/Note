using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoteCore.Entitys
{
    /// <summary>
    /// 用户信息<br/>
    /// - 身份信息扩展
    /// </summary>
    public class UserExt
    {
        [Key]
        [MaxLength(36)]
        public string Id { get; set; }
        
        [MaxLength(36)]
        public string UserId { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [MaxLength(63)]
        public string RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool? Gender { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [MaxLength(63)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        [MaxLength(31)]
        public string IdNumber { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(255)]
        public string Address { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(255)]
        public string PostBox { get; set; }
    }
}
