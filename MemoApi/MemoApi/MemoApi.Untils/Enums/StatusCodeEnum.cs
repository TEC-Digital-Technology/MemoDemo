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
        /// 參數驗證錯誤
        /// </summary>
        [EnumDescription("0001")]
        InvalidArgument,

        /// <summary>
        /// 欄位為必填
        /// </summary>
        [EnumDescription("0002")]
        ValueRequired,

        /// <summary>
        /// 值未落在預期的範圍內
        /// </summary>
        [EnumDescription("0003")]
        ValueNotExpected,

        /// <summary>
        /// 值的長度有誤
        /// </summary>
        [EnumDescription("0004")]
        ValueLenghtError,

        /// <summary>
        /// 必須先登入
        /// </summary>
        [EnumDescription("0005")]
        LoginRequired,
        /// <summary>
        /// 登入票證已過期，請重新登入
        /// </summary>
        [EnumDescription("0006")]
        AccessTokenExpired,
        /// <summary>
        /// 登入票證不合法
        /// </summary>
        [EnumDescription("0007")]
        InvalidAccessToken,
        /// <summary>
        /// 登入的帳號或密碼錯誤
        /// </summary>
        [EnumDescription("0008")]
        LoginFailed,
        /// <summary>
        /// 查無此資料
        /// </summary>
        [EnumDescription("0009")]
        DataNotFound,
        /// <summary>
        /// 授權發生錯誤，詳細資料請參考相關訊息：{0}
        /// </summary>
        [EnumDescription("0010")]
        AuthorizationFailed,

        #endregion

        #region Account(1001~1100)
        /// <summary>
        /// 帳號已經存在
        /// </summary>
        [EnumDescription("1001")]
        AccountIsExists,
        /// <summary>
        /// 帳號不存在
        /// </summary>
        [EnumDescription("1002")]
        AccountNotExists,
        /// <summary>
        /// 密碼與確認密碼不一致
        /// </summary>
        [EnumDescription("1010")]
        PasswordConfirmError,
        /// <summary>
        /// 密碼錯誤
        /// </summary>
        [EnumDescription("1011")]
        PasswordIncorrect,

        /// <summary>
        /// 密碼格式錯誤
        /// </summary>
        [EnumDescription("1012")]
        PasswordFormatError,
        #endregion

        #region IPLimit(1101~1200)
        /// <summary>
        /// 輸入的IP無效
        /// </summary>
        [EnumDescription("1101")]
        IpIsInvalid,
        #endregion

        #region 服務 (3000-4000)
        /// <summary>
        /// 尚未連接至遠端伺服器
        /// </summary>
        [EnumDescription("3001")]
        NotConnectedRemoteServer,
        #endregion

        /// <summary>
        /// 系統錯誤
        /// </summary>
        [EnumDescription("9999")]
        SystemError
    }
}
