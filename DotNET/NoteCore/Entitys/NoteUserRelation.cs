using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoteCore.Entitys
{
    /// <summary>
    /// 笔记用户关系
    /// </summary>
    public class NoteUserRelation
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [MaxLength(36)]
        public string UserId { get; set; }
        /// <summary>
        /// 笔记ID
        /// </summary>
        [MaxLength(36)]
        public string NoteId { get; set; }
    }
}
