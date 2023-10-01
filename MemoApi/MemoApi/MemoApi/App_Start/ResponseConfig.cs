using MemoApi.Messaging;
using MemoApi.Untils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEC.Core.Web.WebApi.Messaging;

namespace MemoApi.App_Start
{
    /// <summary>
    /// 用於設定 API 回應訊息的類別
    /// </summary>
    public static class ResponseConfig
    {
        /// <summary>
        /// 取得回應碼集合
        /// </summary>
        /// <remarks>
        /// 相關範例皆可參考 IResultDefinition 以及 ResultFormatter 之說明
        /// </remarks>
        public static IResultDefinition<StatusCodeEnum> ResultDefinition { get; } = new ResultDefinition(CacheConfig.DefaultMemoryCache);
        /// <summary>
        /// 取得用於格式化回應碼的物件
        /// </summary>
        public static ResultFormatter<StatusCodeEnum> ResultFormatter { get; } = new ResultFormatter<StatusCodeEnum>(
               new TEC.Core.Web.WebApi.Settings.MessagingSettingCollectionFactory<StatusCodeEnum>(ResponseConfig.ResultDefinition));
    }
}