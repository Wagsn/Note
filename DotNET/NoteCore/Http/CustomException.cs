using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Http
{
    /// <summary>
    /// 带响应码的异常
    /// </summary>
    public class CodeException : Exception
    {
        public string Code { get; set; }
    }
}
