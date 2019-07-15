using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Http
{
    public abstract class BaseResponse
    {

    }

    public class TokenResponseMessage : ResponseMessage
    {
        public string access_token { get; set; }
    }

    public class ResponseMessage : BaseResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public ResponseMessage()
        {
            Code = "0";
        }

        public bool IsSuccess()
        {
            if (Code == "0")
            {
                return true;
            }
            return false;
        }
    }

    public class ResponseMessage<TEx> : ResponseMessage
    {
        public TEx Extension { get; set; }
    }

    public class PagingResponseMessage<Tentity> : ResponseMessage<List<Tentity>>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public long TotalCount { get; set; }
    }
}
