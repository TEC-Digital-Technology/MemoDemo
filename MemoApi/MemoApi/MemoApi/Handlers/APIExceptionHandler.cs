using MemoApi.Core.Exceptions;
using MemoApi.Untils.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http;
using TEC.Core.Web.WebApi.Messaging;
using TEC.Core.Web.WebApi.Response;
using MemoApi.Settings;
using TEC.Core;

namespace MemoApi.Handlers
{
    /// <summary>
    /// API處理發生例外狀況的處理常式
    /// </summary>
    internal class APIExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// 初始化API處理發生例外狀況的處理常式
        /// </summary>
        /// <param name="settingCollectionFactoryInternal">設定檔集合工廠</param>
        /// <param name="resultCodeFormatter">用於格式化回傳資料的物件</param>
        /// <param name="resultCodeDefinition">回傳資料的定義</param>
        internal APIExceptionHandler(SettingCollectionFactoryInternal settingCollectionFactoryInternal,
            ResultFormatter<StatusCodeEnum> resultCodeFormatter,
            IResultDefinition<StatusCodeEnum> resultCodeDefinition)
        {
            this.SettingCollectionFactoryInternal = settingCollectionFactoryInternal ?? throw new ArgumentNullException(nameof(settingCollectionFactoryInternal));
            this.ResultFormatter = resultCodeFormatter ?? throw new ArgumentNullException(nameof(resultCodeFormatter));
            this.ResultDefinition = resultCodeDefinition ?? throw new ArgumentNullException(nameof(resultCodeDefinition));
        }

        /// <summary>
        /// 在衍生類別中覆寫時，同步處理例外狀況。在DEBUG模式下，不會隱藏非[OperationFailedException]或其衍伸型別之例外
        /// </summary>
        /// <param name="context">例外狀況處理常式內容</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            //DEBUG模式下，不隱藏非OperationFailedException或其衍伸型別之例外
            //在Release Mode下，隱藏所有例外，對於非OperationFailedException或其衍伸型別之例外都以系統錯誤(邏輯在APIExceptionResult類別中)顯示
            OperationFailedException operationFailedException = context.Exception.FromHierarchy(t => t.InnerException, t => t != null).OfType<OperationFailedException>().FirstOrDefault();
            context.Result = new APIExceptionResult(this.SettingCollectionFactoryInternal, this.ResultFormatter,
                this.ResultDefinition, context.Request,
                operationFailedException == null ? context.Exception : operationFailedException, Thread.CurrentThread.CurrentUICulture);
            base.Handle(context);
        }

        /// <summary>
        /// 決定是否應該處理例外狀況。
        /// </summary>
        /// <param name="context">例外狀況處理常式內容</param>
        /// <returns>如果應該處理例外狀況，則為 true，否則為 false。</returns>
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }

        /// <summary>
        /// 設定或取得設定檔集合工廠
        /// </summary>
        private SettingCollectionFactoryInternal SettingCollectionFactoryInternal { set; get; }
        /// <summary>
        /// 設定或取得用於格式化回傳資料的物件
        /// </summary>
        private ResultFormatter<StatusCodeEnum> ResultFormatter { set; get; }
        /// <summary>
        /// 設定或取得回傳資料的定義
        /// </summary>
        private IResultDefinition<StatusCodeEnum> ResultDefinition { set; get; }
        /// <summary>
        /// 當API執行發生例外時，要建立 <see cref="HttpResponseMessage"/> 的命令
        /// </summary>
        private class APIExceptionResult : IHttpActionResult
        {
            /// <summary>
            /// 建立當API執行發生例外時，要建立 <see cref="HttpResponseMessage"/> 的命令
            /// </summary>
            /// <param name="settingCollectionFactoryInternal">設定檔集合工廠</param>
            /// <param name="request">HTTP要求訊息</param>
            /// <param name="exception">例外狀況</param>
            /// <param name="cultureInfo">用於格式化的區域選項</param>
            /// <param name="resultFormatter">用於格式化回傳資料的物件</param>
            /// <param name="resultDefinition">回傳資料的定義</param>
            public APIExceptionResult(SettingCollectionFactoryInternal settingCollectionFactoryInternal,
                ResultFormatter<StatusCodeEnum> resultFormatter,
                IResultDefinition<StatusCodeEnum> resultDefinition,
                HttpRequestMessage request, Exception exception, CultureInfo cultureInfo)
            {
                this.Request = request;
                this.Exception = exception;
                this.CultureInfo = cultureInfo;
                this.SettingCollectionFactoryInternal = settingCollectionFactoryInternal ?? throw new ArgumentNullException(nameof(settingCollectionFactoryInternal));
                this.ResultFormatter = resultFormatter ?? throw new ArgumentNullException(nameof(resultFormatter));
                this.ResultDefinition = resultDefinition ?? throw new ArgumentNullException(nameof(resultDefinition));
            }

            /// <summary>
            /// 非同步建立[System.Net.Http.HttpResponseMessage]
            /// </summary>
            /// <param name="cancellationToken">用於監控取消要求的權杖</param>
            /// <returns>工作完成時，會包含[System.Net.Http.HttpResponseMessage]。</returns>
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                ExceptionResponse<StatusCodeEnum> exceptionResponse;
                if (this.Exception is OperationFailedException operationFailedException)
                {
                    exceptionResponse = new ExceptionResponse<StatusCodeEnum>(operationFailedException, Thread.CurrentThread.CurrentUICulture, this.ResultFormatter, this.ResultDefinition);
                }
                else
                {
                    exceptionResponse = new ExceptionResponse<StatusCodeEnum>(this.Exception, Thread.CurrentThread.CurrentUICulture, this.ResultDefinition.DefaultExceptionResultCode
                        , this.ResultFormatter, this.ResultDefinition);
                }
                if (String.IsNullOrEmpty(exceptionResponse.QueryInfo))
                {
                    exceptionResponse.QueryInfo = String.Empty;
                }
                if (String.IsNullOrEmpty(exceptionResponse.PostInfo))
                {
                    exceptionResponse.PostInfo = String.Empty;
                }
                if (this.Request.Properties.ContainsKey(this.SettingCollectionFactoryInternal.ApiApplicationSettingCollection[ApiApplicationSettingEnum.RequestPropertiesRawContentKeyName].ToString()))
                {
                    // 須要跟 WebApi.Config 中的 DuplicateRequestContentHandler 參數值相同
                    exceptionResponse.PostInfo = this.Request.Properties[this.SettingCollectionFactoryInternal.ApiApplicationSettingCollection[ApiApplicationSettingEnum.RequestPropertiesRawContentKeyName].ToString()].ToString();
                }
                if (!String.IsNullOrWhiteSpace(this.Request.RequestUri.Query))
                {
                    exceptionResponse.QueryInfo = this.Request.RequestUri.Query.First() == '?' ?
                        this.Request.RequestUri.Query.Substring(1) : this.Request.RequestUri.Query;
                }

                HttpResponseMessage httpResponse = this.Request.CreateResponse(System.Net.HttpStatusCode.OK, exceptionResponse);
                #region 紀錄例外

                //HttpResponseEventData data = httpResponse.toEventData();
                //string resource = this.Request.RequestUri.AbsolutePath;

                //LoggingManagerBase<LoggingScope, LoggingSystemScope, LoggingMessageType> logger = this.SettingCollectionFactoryInternal.Log4NetSettingCollection[LoggingSystemScope.Local];

                if (this.Exception is OperationFailedException operationFailedExceptionForLogging)
                {
                    string message = this.ResultFormatter.Format(ResultFormatType.MessageOnly, operationFailedExceptionForLogging.ResultCodeKey, new CultureInfo("zh"));
                    //logger.warn(resource, LoggingMessageType.WebApiError, $"處理 API 請求時發生錯誤：{message}", this.Exception, data);
                }
                else
                {
                    //logger.error(resource, LoggingMessageType.WebApiError, $"處理 API 請求時發生不可預期的錯誤", this.Exception, data);
                }

                #endregion
                return Task.FromResult(httpResponse);
            }

            /// <summary>
            /// 取得HTTP要求訊息
            /// </summary>
            public HttpRequestMessage Request { get; private set; }

            /// <summary>
            /// 取得例外狀況
            /// </summary>
            public Exception Exception { private get; set; }

            /// <summary>
            /// 取得格式化的區域資訊
            /// </summary>
            public CultureInfo CultureInfo { get; private set; }

            /// <summary>
            /// 設定或取得設定檔集合工廠
            /// </summary>
            private SettingCollectionFactoryInternal SettingCollectionFactoryInternal { set; get; }

            /// <summary>
            /// 設定或取得用於格式化回傳資料的物件
            /// </summary>
            private ResultFormatter<StatusCodeEnum> ResultFormatter { set; get; }

            /// <summary>
            /// 設定或取得回傳資料的定義
            /// </summary>
            private IResultDefinition<StatusCodeEnum> ResultDefinition { set; get; }
        }
    }
}