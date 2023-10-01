using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.ComponentModel;

namespace MemoApi.Untils.Enums
{
    /// <summary>
    /// API 應用程式的設定檔列舉
    /// </summary>
    [DescriptiveEnumEnforcement(DescriptiveEnumEnforcementAttribute.EnforcementTypeEnum.ThrowException)]
    public enum ApiApplicationSettingEnum
    {
        #region 系統設定
        /// <summary>
        /// 處理後資料的參數名稱，屬於<see cref="System.String"/>
        /// </summary>
        RequestPropertiesParsedContentKeyName,

        /// <summary>
        /// 原始資料的參數名稱，屬於<see cref="System.String"/>
        /// </summary>
        RequestPropertiesRawContentKeyName,
        /// <summary>
        /// 是否開啟 Swagger，屬於<see cref="System.Boolean"/>
        /// </summary>
        IsSwaggerEnabled,

        /// <summary>
        /// 用於全域(WebApi, Web Mvc, etc.)的日期格式化，屬於<see cref="System.String"/>
        /// </summary>
        DateTimeFormat,
        #endregion
    }
}
