using System;
using System.Collections.Generic;
using System.Text;

namespace NoteCore.Http
{
    /// <summary>
    /// 基础响应体
    /// </summary>
    public abstract class BaseResponse
    {
    }
    /// <summary>
    /// 响应体
    /// </summary>
    public class ResponseBody : BaseResponse
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public ResponseCode Code { get; set; } = ResponseCode.Success;
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public bool IsSuccess() => Code == ResponseCode.Success;
    }
    /// <summary>
    /// Token 响应体
    /// </summary>
    public class TokenResponseBody : ResponseBody
    {
        /// <summary>
        /// 访问Token
        /// </summary>
        public string Access_token { get; set; }
    }
    /// <summary>
    /// 携带数据的响应体
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ResponseBody<TEntity> : ResponseBody
    {
        /// <summary>
        /// 携带的数据
        /// </summary>
        public TEntity Data { get; set; }
    }
    /// <summary>
    /// 分页响应体
    /// </summary>
    public class PageResponse<T> : ResponseBody<List<T>>
    {
        /// <summary>
        /// 分页索引 PageIndex
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 每页大小 PageSize
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 分页数量 PageCount
        /// </summary>
        public int Count { get => Total > 0 ? (int)Math.Ceiling((double)Total / Size) : 0; }
        /// <summary>
        /// 对象总数 TotalCount
        /// </summary>
        public long Total { get; set; }
    }
}
