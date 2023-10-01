using MemoApi.Settings.Collections;
using MemoApi.Untils.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MemoApi.Settings
{
    /// <summary>
    /// 專案內部使用的設定檔集合工廠
    /// </summary>
    internal class SettingCollectionFactoryInternal
    {
        private Lazy<ApiApplicationSettingCollection> apiApplicationSettingCollectionLazy;
        internal SettingCollectionFactoryInternal()
        {
            this.apiApplicationSettingCollectionLazy = new Lazy<ApiApplicationSettingCollection>(() => new ApiApplicationSettingCollection()
            {
                [ApiApplicationSettingEnum.IsSwaggerEnabled] = Boolean.Parse(ConfigurationManager.AppSettings["IsSwaggerEnabled"]),
                [ApiApplicationSettingEnum.RequestPropertiesParsedContentKeyName] = ConfigurationManager.AppSettings["RequestPropertiesParsedContentKeyName"],
                [ApiApplicationSettingEnum.RequestPropertiesRawContentKeyName] = ConfigurationManager.AppSettings["RequestPropertiesRawContentKeyName"],
                [ApiApplicationSettingEnum.DateTimeFormat] = ConfigurationManager.AppSettings["DateTimeFormat"],
            },
            System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
        }

        /// <summary>
        /// 取得 API站台的設定檔集合
        /// </summary>
        internal ApiApplicationSettingCollection ApiApplicationSettingCollection => this.apiApplicationSettingCollectionLazy.Value;
    }
}