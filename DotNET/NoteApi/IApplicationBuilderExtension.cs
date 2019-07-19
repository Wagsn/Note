using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NoteCore.Http;
using NoteServer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteServer
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class IApplicationBuilderExtension
    {
        /// <summary>
        /// 添加异常处理中间件(Crash Handler)
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCrashHandler(this IApplicationBuilder builder)
        {
            return builder.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception e)
                {
                    ResponseBody response = new ResponseBody
                    {
                        Code = ResponseCode.ServiceError,
                        Message = e.Message
                    };

                    var resBody = Newtonsoft.Json.JsonConvert.SerializeObject(response);
                    context.Response.StatusCode = 200;
                    context.Response.ContentType = "application/json";
                    //context.Response.ContentLength = Encoding.Default.GetByteCount(resBody);
                    await context.Response.WriteAsync(resBody);
                }
            });

            //return builder.UseMiddleware(typeof(ExceptionHanderMiddleware));

            //return builder.Use(next =>
            //{
            //    return async context =>
            //    {
            //        // 异常处理
            //        try
            //        {
            //            await next(context);
            //        }
            //        catch (Exception e)
            //        {
            //            ResponseMessage response = new ResponseMessage();
            //            response.Code = ResponseCode.ServerError;
            //            response.Message = e.Message;

            //            var resBody = Newtonsoft.Json.JsonConvert.SerializeObject(response);
            //            context.Response.StatusCode = 200;
            //            context.Response.ContentType = "application/json";
            //            context.Response.ContentLength = Encoding.UTF8.GetByteCount(resBody);
            //            await context.Response.WriteAsync(resBody);
            //        }
            //    };
            //});
        }
    }
}
