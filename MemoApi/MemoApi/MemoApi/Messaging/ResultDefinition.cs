using MemoApi.App_Start;
using MemoApi.Core.UIData;
using MemoApi.Untils.Enums;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using TEC.Core.ComponentModel;
using TEC.Core.Settings.Collections;
using TEC.Core.Web.WebApi.Messaging;
using TEC.Core.Web.WebApi.Settings;

namespace MemoApi.Messaging
{
    /// <summary>
    /// 訊息回傳定義
    /// </summary>
    public class ResultDefinition : IResultDefinition<StatusCodeEnum>
    {
        public ResultDefinition()
        {
            this.MemoryCache = CacheConfig.DefaultMemoryCache;
        }

        /// <summary>
        /// 初始化處理回傳訊息的定義資料
        /// </summary>
        /// <param name="memoryCache"></param>
        /// <exception cref="ArgumentNullException"></exception>ㄞ
        public ResultDefinition(MemoryCache memoryCache)
        {
            this.MemoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        /// <summary>
        /// 取得預設例外的訊息列舉
        /// </summary>
        public StatusCodeEnum DefaultExceptionResultCode => StatusCodeEnum.SystemError;

        /// <summary>
        /// 取得預設的回傳訊息列舉
        /// </summary>
        public StatusCodeEnum DefaultResultCode => StatusCodeEnum.Success;

        /// <summary>
        /// 取得當參數驗證失敗時要傳回的訊息列舉
        /// </summary>
        public StatusCodeEnum InvalidArgumentResultCode => StatusCodeEnum.InvalidArgument;

        /// <summary>
        /// 取得記憶體快取
        /// </summary>
        public MemoryCache MemoryCache { private set; get; }

        /// <summary>
        /// 取得回傳代號支援的語系清單
        /// </summary>
        public List<CultureInfo> SupportedCultureInfoList
        {
            get
            {
                MessageUIData messageUIData = new MessageUIData();
                return messageUIData.GetSupportedCultureCode().Select(t => new CultureInfo(t)).ToList();
            }
        }

        /// <summary>
        /// 取得預設語系
        /// </summary>
        public CultureInfo DefaultCultureInfo => new CultureInfo("zh-TW");

        /// <summary>
        /// 取得指定語系的訊息代碼設定檔集合
        /// </summary>
        /// <param name="cultureKey"></param>
        /// <returns></returns>
        public Func<CachedValueConfig<ResultCodeSettingCollection<StatusCodeEnum>>> GetSpecificCultureResultCodeCachedValueConfig(string cultureKey)
        {
            return () =>
            {
                var resultCodeSettingCollection = new ResultCodeSettingCollection<StatusCodeEnum>(cultureKey);
                new MessageUIData().GetMessageInfoList(cultureKey).ForEach(messageEnity =>
                {
                    resultCodeSettingCollection.Add(messageEnity.MessageCode.GetEnum<StatusCodeEnum>()[0], messageEnity.Message);
                });
                return new CachedValueConfig<ResultCodeSettingCollection<StatusCodeEnum>>(resultCodeSettingCollection, new Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromMinutes(30)//30分鐘清除一次
                });
            };
        }
    }
}