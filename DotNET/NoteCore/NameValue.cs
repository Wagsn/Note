using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore
{
    /// <summary>
    /// 名值描述
    /// </summary>
    public class NameValue<TName, TValue>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public TName Name { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public TValue Value { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
