using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWinCore
{
    /// <summary>
    /// 结果
    /// </summary>
    public class Result
    {
        public bool Ok { get { return Code == "0"; } }

        public string Message { get; set; }

        public string Code { get; set; } = "0";
    }
    public class Result<T> : Result
    {
        T Data { get; set; }
    }
    public class PageResult<T>: Result<List<T>>
    {
        public int Index { get; set; } = 0;
        public int Size { get; set; } = 20;
        public int Total { get; set; }
    }
}
