using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Entitys
{
    /// <summary>
    /// 笔记实体
    /// </summary>
    public class Note
    {
        public string Id { get; set; }

        public string Title { get; set; }
        
        public string Content { get; set; }


        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeleteTime { get; set; }
    }
}
