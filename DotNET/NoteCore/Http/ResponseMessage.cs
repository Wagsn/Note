using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Http
{
    public abstract class BaseResponse
    {

    }

    public class TokenResponseMessage : ResponseBody
    {
        public string access_token { get; set; }
    }

    public class ResponseBody : BaseResponse
    {
        public ResponseCode Code { get; set; }
        public string Message { get; set; }

        public ResponseBody()
        {
            Code = 0;
        }

        public bool IsSuccess()
        {
            if (Code == 0)
            {
                return true;
            }
            return false;
        }
    }

    public class ResponseBody<TEntity> : ResponseBody
    {
        public TEntity Data { get; set; }
    }

    public class PagingResponseMessage<TEntity> : ResponseBody<List<TEntity>>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public long TotalCount { get; set; }
    }
}
