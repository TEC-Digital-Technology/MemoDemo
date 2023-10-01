using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MemoApi.App_Start
{
    /// <summary>
    /// 快取相關設定
    /// </summary>
    public class CacheConfig
    {
        /// <summary>
        /// 初始化快取相關設定
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
            CacheConfig.DefaultMemoryCache = new MemoryCache(new MemoryCacheOptions());
            if (!config.Properties.TryAdd(typeof(IMemoryCache), memoryCache))
            {
                throw new Exception($"無法註冊 {nameof(MemoryCache)} 的執行個體");
            }
        }

        /// <summary>
        /// 取得全域共用的快取
        /// </summary>
        public static MemoryCache DefaultMemoryCache { private set; get; }
    }
}