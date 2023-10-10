using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.ComponentModel;

namespace MemoApi.Untils.Enums
{
    /// <summary>
    /// 回傳訊息列舉
    /// </summary>
    [DescriptiveEnumEnforcement(DescriptiveEnumEnforcementAttribute.EnforcementTypeEnum.ThrowException)]
    public enum StatusCodeEnum
    {
        #region 系統(0000-0999)
        /// <summary>
        /// 成功
        /// </summary>
        [EnumDescription("0000")]
        Success,

        /// <summary>
        /// 傳入參數有誤
        /// </summary>
        [EnumDescription("0001")]
        InvalidArgument,

        /// <summary>
        /// 無法辨識的語系
        /// </summary>
        [EnumDescription("0002")]
        UnrecognizedLanguage,

        /// <summary>
        /// 存取被拒
        /// </summary>
        [EnumDescription("0003")]
        PermissionDenied,

        /// <summary>
        /// 不支援的語系
        /// </summary>
        [EnumDescription("0004")]
        UnsupportedLanguage,


        #endregion 系統(0000-0999)

        /// <summary>
        /// 系統錯誤
        /// </summary>
        [EnumDescription("9999")]
        SystemError
    }
}
