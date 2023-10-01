using MemoApi.Messaging;
using MemoApi.Settings;
using MemoApi.Untils.Enums;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TEC.Core.Web.WebApi.Messaging;

namespace MemoApi.App_Start
{
    /// <summary>
    /// 訊息定義相關設定
    /// </summary>
    public class MessagingConfig
    {
        /// <summary>
        /// 初始化紀錄相關設定
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            if (!config.Properties.TryGetValue(typeof(SettingCollectionFactoryInternal), out object settingCollectionInternalObject))
            {
                throw new ArgumentNullException($"必須先註冊 {nameof(SettingCollectionFactoryInternal)}");
            }
            if (!config.Properties.TryGetValue(typeof(IMemoryCache), out object memoryCacheObject))
            {
                throw new ArgumentNullException($"必須先註冊 {nameof(IMemoryCache)}");
            }
            SettingCollectionFactoryInternal settingCollectionInternal = settingCollectionInternalObject as SettingCollectionFactoryInternal;
            ResultDefinition resultDefinition = new ResultDefinition(memoryCacheObject as MemoryCache);
            if (!config.Properties.TryAdd(typeof(ResultFormatter<StatusCodeEnum>), new ResultFormatter<StatusCodeEnum>(
                new TEC.Core.Web.WebApi.Settings.MessagingSettingCollectionFactory<StatusCodeEnum>(resultDefinition))))
            {
                throw new Exception($"無法註冊 {nameof(ResultFormatter<StatusCodeEnum>)} 的執行個體");
            }
            if (!config.Properties.TryAdd(typeof(IResultDefinition<StatusCodeEnum>), resultDefinition))
            {
                throw new Exception($"無法註冊 {nameof(IResultDefinition<StatusCodeEnum>)} 的執行個體");
            }
        }
    }
}