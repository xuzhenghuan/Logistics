using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.MODEL.Log4;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Logistics.Common.Filter
{
    /// <summary>
    /// 自定义异常过滤器
    /// </summary>
    public class CustomerExceptionFilter : IAsyncExceptionFilter
    {
        readonly ILogger<CustomerExceptionFilter> logger;
        public CustomerExceptionFilter(ILogger<CustomerExceptionFilter> _logger)
        {
            this.logger = _logger;
        }
        /// <summary>
        /// 重写OnExceptionAsync方法，定义自己的处理逻辑
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            //写入异常原因
            logger.LogError($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}报错信息:{context.Exception.Message}");
            // 如果异常没有被处理则进行处理
            if (context.ExceptionHandled == false)
            {
                // 定义返回类型
                var result = new ResultModel<string>
                {
                    ResultCode = 0,
                    ResultMsg = context.Exception.Message
                };
                context.Result = new ContentResult
                {
                    // 返回状态码设置为200，表示成功
                    StatusCode = StatusCodes.Status200OK,
                    // 设置返回格式
                    ContentType = "application/json;charset=utf-8",
                    Content = JsonConvert.SerializeObject(result)
                };
            }
            // 设置为true，表示异常已经被处理了 返回指定格式
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
