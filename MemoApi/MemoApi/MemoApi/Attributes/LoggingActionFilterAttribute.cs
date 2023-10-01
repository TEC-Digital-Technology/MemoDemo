using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using TEC.Core.Web.Logging;
using TEC.Core.Web.Logging.AspNet;
using TEC.Core.Web.WebApi.Attributes;

namespace MemoApi.Attributes
{
    /// <summary>
    /// 描述執行及結束執行指定方法時必須要紀錄 LOG
    /// </summary>
    public class LoggingActionFilterAttribute : LoggingActionFilterAttributeBase
    {
        /// <summary>
        /// 非同步紀錄請求資訊
        /// </summary>
        /// <param name="requestUri">請求的 Uri</param>
        /// <param name="request">請求資料</param>
        /// <param name="actionContext">動作內容</param>
        /// <param name="cancellationToken">傳播通知，表示應該取消作業</param>
        protected override async Task LogRequestAsync(Uri requestUri, LogAspNetRequestData request, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            // TODO: 紀錄 HTTP 請求
            await Task.CompletedTask;
        }

        /// <summary>
        /// 非同步紀錄回應資訊
        /// </summary>
        /// <param name="requestUri">請求的 Uri</param>
        /// <param name="response">回應資料</param>
        /// <param name="actionExecutedContext">已執行動作內容</param>
        /// <param name="cancellationToken">傳播通知，表示應該取消作業</param>
        protected override async Task LogResponseAsync(Uri requestUri, LogAspNetResponseData response, HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            // TODO: 紀錄 HTTP 回應
            await Task.CompletedTask;
        }
    }
}
