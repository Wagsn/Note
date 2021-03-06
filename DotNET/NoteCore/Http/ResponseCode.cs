﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NoteCore.Http
{
    /// <summary>
    /// 响应码
    /// </summary>
    public enum ResponseCode
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
        /// 对象已存在<br/>
        /// - 新增的对象已存在与数据库
        /// </summary>
        [Description("对象已存在")]
        AlreadyExists = 102,
        /// <summary>
        /// 局部已失效<br/>
        /// - 复数参数中部分无效
        /// </summary>
        [Description("局部已失效")]
        PartialFailure = 103,
        /// <summary>
        /// 请求体错误
        /// </summary>
        [Description("请求体错误")]
        ArgumentError = 400,
        /// <summary>
        /// 未找到对象信息
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
