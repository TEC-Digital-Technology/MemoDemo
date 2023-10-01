using MemoApi.Handlers;
using MemoApi.Settings;
using MemoApi.Untils.Enums;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;
using TEC.Core.Web.WebApi.Filters;
using TEC.Core.Web.WebApi.Handlers;
using TEC.Core.Web.WebApi.Messaging;

namespace MemoApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            if (!config.Properties.TryGetValue(typeof(SettingCollectionFactoryInternal), out object settingCollectionInternalObject))
            {
                throw new ArgumentNullException($"必須先註冊 {nameof(SettingCollectionFactoryInternal)}");
            }
            SettingCollectionFactoryInternal settingCollectionInternal = settingCollectionInternalObject as SettingCollectionFactoryInternal;
            // Web API 設定和服務
            #region Serializer
            // 設定 Web API 使用 newtonsoft.json 套件進行全站序列化程序
            //------------------------------------------------------------------------------
            var serializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.DateFormatString = settingCollectionInternal.ApiApplicationSettingCollection[ApiApplicationSettingEnum.DateTimeFormat].ToString();
            serializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
            serializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            serializerSettings.DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTime;
            serializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            serializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Populate;
            var contractResolver = (DefaultContractResolver)serializerSettings.ContractResolver;
            contractResolver.IgnoreSerializableAttribute = true;
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            #endregion
            #region 訊息處理器
            config.MessageHandlers.Add(new DuplicateRequestContentHandler(
                settingCollectionInternal.ApiApplicationSettingCollection[ApiApplicationSettingEnum.RequestPropertiesRawContentKeyName].ToString(),
                settingCollectionInternal.ApiApplicationSettingCollection[ApiApplicationSettingEnum.RequestPropertiesParsedContentKeyName].ToString(),
                (mimeType, rawContent) =>
                {
                    //處理非JSON以及Url Encoded的文字傳輸內容
                    return new List<KeyValuePair<string, object>>();
                }));
            config.Formatters.Add(new TEC.Core.Web.WebApi.Formatting.MultipartFormDataMediaTypeFormatter(System.IO.Path.GetTempPath()));
            #endregion
            #region Exception
            if (!config.Properties.TryGetValue(typeof(IResultDefinition<StatusCodeEnum>), out object resultDefinitionObject))
            {
                throw new Exception($"必須先註冊 {nameof(IResultDefinition<StatusCodeEnum>)}");
            }
            IResultDefinition<StatusCodeEnum> resultDefinition = resultDefinitionObject as IResultDefinition<StatusCodeEnum>;
            if (!config.Properties.TryGetValue(typeof(ResultFormatter<StatusCodeEnum>), out object resultFormatterObject))
            {
                throw new Exception($"必須先註冊 {nameof(ResultFormatter<StatusCodeEnum>)}");
            }
            ResultFormatter<StatusCodeEnum> resultFormatter = resultFormatterObject as ResultFormatter<StatusCodeEnum>;
            config.Services.Replace(typeof(IExceptionHandler), new APIExceptionHandler(settingCollectionInternal, resultFormatter, resultDefinition));
            #endregion
            #region 設定排序方法篩選
            //使用排序篩選器
            config.Services.Replace(typeof(IFilterProvider), new OrderedFilterProvider() { IgnoreFilterScope = true });
            #endregion

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
