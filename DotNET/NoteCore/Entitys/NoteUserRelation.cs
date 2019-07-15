using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoteCore.Entitys
{
    public class NoteUserRelation
    {
        [MaxLength(36)]
        public string UserId { get; set; }
        [MaxLength(36)]
        public string NoteId { get; set; }
    }
}
