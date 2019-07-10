using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Entitys
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        public string Id { get; set; }

        /// <summary>
        /// 电子邮箱（唯一）
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 昵称（随便改）
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
