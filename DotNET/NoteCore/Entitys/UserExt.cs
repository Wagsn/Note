using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Entitys
{
    /// <summary>
    /// 用户信息<br/>
    /// - 身份信息扩展
    /// </summary>
    public class UserExt : User
    {
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string PostBox { get; set; }
    }
}
