using MemoApi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MemoApi.App_Start
{
    /// <summary>
    /// 設定檔集合的相關設定
    /// </summary>
    public class SettingCollectionConfig
    {
        /// <summary>
        /// 初始化設定檔集合的相關設定
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            if (!config.Properties.TryAdd(typeof(SettingCollectionFactoryInternal), new SettingCollectionFactoryInternal()))
            {
                throw new Exception($"無法註冊 {nameof(SettingCollectionFactoryInternal)} 的執行個體");
            }
        }
    }
}