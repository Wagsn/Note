using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NoteServer.Filters
{
    /// <summary>
    /// 异常处理 中间件
    /// </summary>
    public class ExceptionHanderMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHanderMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.OK;
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(new { code = NoteCore.Http.ResponseCode.ServiceError, message = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
