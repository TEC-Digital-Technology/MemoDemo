using MemoApi.Untils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEC.Core.Settings.Collections;

namespace MemoApi.Settings.Collections
{
    /// <summary>
    /// 應用程式的 API 設定檔集合
    /// </summary>
    public class ApiApplicationSettingCollection : SettingCollectionBase<ApiApplicationSettingEnum, object, string>
    {
        /// <summary>
        /// 初始化應用程式的 API 設定檔集合
        /// </summary>
        public ApiApplicationSettingCollection()
            : base(nameof(ApiApplicationSettingCollection))
        { }

        /// <summary>
        /// 取得 API 設定檔集合的預設值
        /// </summary>
        /// <param name="key">API 應用程式的設定檔列舉</param>
        /// <returns></returns>
        public override object GetDefaultValue(ApiApplicationSettingEnum key)
        {
            switch (key)
            {
                default:
                    throw new NotImplementedException("不支援以此方法取得預設設定。");
            }
        }
    }
}