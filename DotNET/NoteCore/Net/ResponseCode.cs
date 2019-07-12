using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NoteCore.Net
{
    /// <summary>
    /// 响应码
    /// </summary>
    public class ResponseCode
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        public static readonly string Success = ((int)ResponseCodeEnum.Success).ToString();
        /// <summary>
        /// 找不到
        /// </summary>
        public static readonly string NotFound = ((int)ResponseCodeEnum.NotFound).ToString();
        /// <summary>
        /// 服务器错误
        /// </summary>
        public static readonly string ServerError = ((int)ResponseCodeEnum.ServiceError).ToString();
    }
    public enum ResponseCodeEnum
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        [Description("请求成功")]
        Success = 0,
        /// <summary>
        /// 对象请求不合法
        /// </summary>
        [Description("对象请求不合法")]
        ModelInvalid = 100,
        /// <summary>
        /// 参数不能为空
        /// </summary>
        [Description("参数不能为空")]
        ArgumentNullError = 101,
        /// <summary>
        /// 对象已存在
        /// </summary>
        [Description("对象已存在")]
        ObjectAlreadyExists = 102,
        /// <summary>
        /// 局部已失效
        /// </summary>
        [Description("局部已失效")]
        PartialFailure = 103,
        /// <summary>
        /// 请求体错误
        /// </summary>
        [Description("请求体错误")]
        ArgumentError = 400,
        /// <summary>
        /// 未找到对应信息
        /// </summary>
        [Description("未找到对应信息")]
        NotFound = 404,
        /// <summary>
        /// 授权失效
        /// </summary>
        [Description("授权失效")]
        NotAllow = 403,
        /// <summary>
        /// 服务器内部错误
        /// </summary>
        [Description("服务器内部错误")]
        ServiceError = 500
    }
}
