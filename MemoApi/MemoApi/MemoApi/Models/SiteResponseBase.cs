using MemoApi.Untils.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using TEC.Core.Web.WebApi.Messaging;
using TEC.Core.Web.WebApi.Response;

namespace MemoApi.Models
{
    /// <summary>
    /// Web Api使用的回應基底型別
    /// </summary>
    public abstract class SiteResponseBase : ResponseBase<StatusCodeEnum>
    {
        /// <summary>
        /// 使用ResponseConfig.ResultCodeDefinition所設定的預設訊息初始化回應物件(目前UI語系)
        /// </summary>
        public SiteResponseBase()
           : base(SiteResponseBase.PreferredResultFormatter, SiteResponseBase.PreferredResultDefinition)
        {
        }
        /// <summary>
        /// 以指定訊息初始化回應物件(目前UI語系)
        /// </summary>
        /// <param name="resultCodeSettingEnum">相關的訊息</param>
        public SiteResponseBase(StatusCodeEnum resultCodeSettingEnum)
           : base(resultCodeSettingEnum, SiteResponseBase.PreferredResultFormatter, SiteResponseBase.PreferredResultDefinition)
        {
        }
        /// <summary>
        /// 以指定訊息及訊息格式化物件初始化回應物件(目前UI語系)
        /// </summary>
        /// <param name="resultCodeSettingEnum">相關的訊息</param>
        /// <param name="resultCodeFormatter">格式化訊息的物件</param>
        public SiteResponseBase(StatusCodeEnum resultCodeSettingEnum, ResultFormatter<StatusCodeEnum> resultCodeFormatter)
            : base(resultCodeSettingEnum, resultCodeFormatter, SiteResponseBase.PreferredResultDefinition)
        {
        }
        /// <summary>
        /// 以指定訊息、語系及訊息格式化物件初始化回應物件
        /// </summary>
        /// <param name="resultCodeSettingEnum">相關的訊息</param>
        /// <param name="resultCodeFormatter">格式化訊息的物件</param>
        /// <param name="cultureInfo">語系</param>
        public SiteResponseBase(StatusCodeEnum resultCodeSettingEnum, CultureInfo cultureInfo, ResultFormatter<StatusCodeEnum> resultCodeFormatter)
            : base(resultCodeSettingEnum, cultureInfo, resultCodeFormatter, SiteResponseBase.PreferredResultDefinition)
        {
        }
        /// <summary>
        /// 設定或取得慣用的回傳訊息格式化物件
        /// </summary>
        internal static ResultFormatter<StatusCodeEnum> PreferredResultFormatter { set; get; }
        /// <summary>
        /// 設定或取得慣用的回傳資料定義
        /// </summary>
        internal static IResultDefinition<StatusCodeEnum> PreferredResultDefinition { set; get; }
    }
}