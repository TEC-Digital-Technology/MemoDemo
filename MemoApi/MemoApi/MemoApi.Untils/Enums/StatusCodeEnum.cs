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

        /// <summary>
        /// 無效的 IP 地址
        /// </summary>
        [EnumDescription("0005")]
        InvalidIpAddress,

        /// <summary>
        /// 無法判別的國別代碼或文化特性
        /// </summary>
        [EnumDescription("0006")]
        UnrecognizedRegionName,

        /// <summary>
        /// 管制類帳號無法執行此作業
        /// </summary>
        [EnumDescription("0014")]
        CannotPerformOperationForRegulatedAccount,

        /// <summary>
        /// 橘子支API錯誤
        /// </summary>
        [EnumDescription("0100")]
        GamaPayApiError,


        #endregion 系統(0000-0999)

        #region 驗證 (1000-2999)
        /// <summary>
        /// 欄位為必填
        /// </summary>
        [EnumDescription("1000")]
        FieldRequired,

        /// <summary>
        /// 值區間不符規定
        /// </summary>
        [EnumDescription("1001")]
        InvalidRange,

        /// <summary>
        /// 必須先登入
        /// </summary>
        [EnumDescription("1002")]
        LoginRequired,

        /// <summary>
        /// 登入票證已過期，請重新登入
        /// </summary>
        [EnumDescription("1003")]
        AccessTokenExpired,

        /// <summary>
        /// 登入票證不合法
        /// </summary>
        [EnumDescription("1004")]
        InvalidToken,

        /// <summary>
        /// 登入的帳號或密碼錯誤
        /// </summary>
        [EnumDescription("1005")]
        LoginFailed,

        /// <summary>
        /// 查無此資料
        /// </summary>
        [EnumDescription("1006")]
        DataNotFound,

        /// <summary>
        /// 授權發生錯誤，詳細資料請參考相關訊息：{0}
        /// </summary>
        [EnumDescription("1007")]
        AuthorizationFailed,

        /// <summary>
        /// Email 已經被註冊
        /// </summary>
        [EnumDescription("1008")]
        EmailAlreadyRegistered,

        /// <summary>
        /// 輸入的資訊至少包含一個值
        /// </summary>
        [EnumDescription("1009")]
        ItemRequired,

        /// <summary>
        /// Email 格式錯誤
        /// </summary>
        [EnumDescription("1010")]
        InvalidEmailFormat,

        /// <summary>
        /// 資料已存在
        /// </summary>
        [EnumDescription("1011")]
        DataExist,

        /// <summary>
        /// 超過每個產品的最大可購買數，目前限制為: {0} 個
        /// </summary>
        [EnumDescription("1012")]
        ExceedMaxBuyCountPerProduct,

        /// <summary>
        /// 密碼錯誤
        /// </summary>
        [EnumDescription("1013")]
        PasswordIncorrect,

        /// <summary>
        /// 無法接受空字串或空格
        /// </summary>
        [EnumDescription("1014")]
        CannotAcceptWhiteSpace,

        /// <summary>
        /// 電話號碼格式錯誤
        /// </summary>
        [EnumDescription("1015")]
        InvalidPhoneFormat,

        /// <summary>
        /// 電子發票愛心碼格式錯誤
        /// </summary>
        [EnumDescription("1016")]
        InvalidInvoiceLoveCodeFormat,

        /// <summary>
        /// 電子發票自然人憑證格式錯誤
        /// </summary>
        [EnumDescription("1017")]
        InvalidInvoicePersonalCertificateFormat,

        /// <summary>
        /// 電子發票手機條碼格式錯誤
        /// </summary>
        [EnumDescription("1018")]
        InvalidMobileBarcodeFormat,

        /// <summary>
        /// 驗證碼檢核失敗
        /// </summary>
        [EnumDescription("1019")]
        InvalidVerifyCode,

        /// <summary>
        /// 傳送信件的間隔太短
        /// </summary>
        [EnumDescription("1020")]
        SendMailDurationNotElasped,

        /// <summary>
        /// Email 已驗證通過
        /// </summary>
        [EnumDescription("1021")]
        EmailAlreadyVerified,

        /// <summary>
        /// Token 需要被更新
        /// </summary>
        [EnumDescription("1022")]
        TokenShouldBeRenew,

        /// <summary>
        /// 必須設定密碼
        /// </summary>
        [EnumDescription("1023")]
        PasswordMustBeSet,

        /// <summary>
        /// 密碼必須為空
        /// </summary>
        [EnumDescription("1024")]
        PasswordMustBeEmpty,

        /// <summary>
        /// 超過每張訂單的最大產品總量
        /// </summary>
        [EnumDescription("1025")]
        ExceedMaxProductCountPerOrder,

        /// <summary>
        /// 非公司員工
        /// </summary>
        [EnumDescription("1026")]
        IsNotEmployee,

        /// <summary>
        /// 帳號已被鎖定
        /// </summary>
        [EnumDescription("1027")]
        LockedAccount,

        /// <summary>
        /// 無法使用一次性信箱
        /// </summary>
        [EnumDescription("1028")]
        DisposableEmailNotAllowed,

        /// <summary>
        /// 第三方登入方式不支援
        /// </summary>
        [EnumDescription("1029")]
        ThirdPartyLoginTypeNotSupport,

        /// <summary>
        /// 查無指定的資料，共{0}筆。參數名稱:{1}。資料內容:{2}
        /// </summary>
        [EnumDescription("1030")]
        SpecificDataNotFound,

        /// <summary>
        /// 固定手續費值區間不符，應為大於等於 0 的整數
        /// </summary>
        [EnumDescription("1031")]
        FixedFeeValueInvalidRange,

        /// <summary>
        /// 百分比手續費值區間不符，應為 0~100 的整數或小數
        /// </summary>
        [EnumDescription("1032")]
        PercentageFeeValueInvalidRange,
        #endregion

        #region 帳戶(3000-3999)

        /// <summary>
        /// OAuth提供者未提供Email
        /// </summary>
        [EnumDescription("3000")]
        OAuthNotProvideEmail,

        /// <summary>
        /// OAuth提供者提供的Email已被註冊
        /// </summary>
        [EnumDescription("3001")]
        OAuthEmailAlreadyRegistered,

        /// <summary>
        /// OAuth註冊失敗
        /// </summary>
        [EnumDescription("3002")]
        OAuthRegisterFail,

        /// <summary>
        /// Email 未驗證
        /// </summary>
        [EnumDescription("3003")]
        EmailNotVerify,

        /// <summary>
        /// 註冊時，Email 為必要欄位
        /// </summary>
        [EnumDescription("3004")]
        EmailRequiredForRegister,

        /// <summary>
        /// 無法背景更新 Token，須重新登入
        /// </summary>
        [EnumDescription("3005")]
        SilentTokenAcquisitionFailed,

        #endregion

        #region 交易 (4000-4999)

        /// <summary>
        /// 選購的商品的狀態為關閉時無法建立訂單
        /// </summary>
        [EnumDescription("4000")]
        ProductClose,
        /// <summary>
        /// 商品狀態為完售時無法建立訂單
        /// </summary>
        [EnumDescription("4001")]
        ProductSoldOut,
        /// <summary>
        /// 商品狀態為停止銷售時無法建立訂單
        /// </summary>
        [EnumDescription("4002")]
        ProductStopSelling,
        /// <summary>
        /// 訂單的付款狀態不合法
        /// </summary>
        [EnumDescription("4003")]
        TransactionPaymentStatusInvalid,
        /// <summary>
        /// 具備未付款訂單時無法建單
        /// </summary>
        [EnumDescription("4004")]
        HasUnpaidTransaction,
        /// <summary>
        /// 訂單已取消
        /// </summary>
        [EnumDescription("4005")]
        TransactionCanceled,
        /// <summary>
        /// 查無此商品
        /// </summary>
        [EnumDescription("4006")]
        ProductNotFound,
        /// <summary>
        /// 查無此商品價格
        /// </summary>
        [EnumDescription("4007")]
        ProductPriceNotFound,
        /// <summary>
        /// 輸入的商品必須為序號商品
        /// </summary>
        [EnumDescription("4008")]
        ProductTypeMustBeSerialProduct,
        /// <summary>
        /// 輸入序號商品的製造廠商不合法
        /// </summary>
        [EnumDescription("4009")]
        InvalidProductSerialManufacturer,
        /// <summary>
        /// 商品序號已配發
        /// </summary>
        [EnumDescription("4010")]
        ProductSerialAlreadyAssigned,
        /// <summary>
        /// 商品序號未配發
        /// </summary>
        [EnumDescription("4011")]
        ProductSerialNotAssigned,
        /// <summary>
        /// 商品序號格式有誤
        /// </summary>
        [EnumDescription("4012")]
        InvalidProductSerialFormat,
        /// <summary>
        /// 不支援以此幣別交易
        /// </summary>
        [EnumDescription("4013")]
        CurrencyNotSupportedForTransaction,
        /// <summary>
        /// 優惠券已過期
        /// </summary>
        [EnumDescription("4014")]
        CouponExpired,
        /// <summary>
        /// 優惠券已達最大使用數
        /// </summary>
        [EnumDescription("4015")]
        CouponUseCountExceed,
        /// <summary>
        /// 無效的優惠卷序號
        /// </summary>
        [EnumDescription("4016")]
        InvalidCouponNumber,
        /// <summary>
        /// 不符合優惠卷使用限制
        /// </summary>
        [EnumDescription("4017")]
        CouponConstraintNotMet,
        /// <summary>
        /// 無效的優惠券庫存量
        /// </summary>
        [EnumDescription("4018")]
        InvalidCouponInventory,
        /// <summary>
        /// 指定的付款通路目前無法使用
        /// </summary>
        [EnumDescription("4019")]
        TargetPaymentGatewayNotAvailable,
        /// <summary>
        /// 訂單已通過審核
        /// </summary>
        [EnumDescription("4020")]
        TransactionApproved,
        /// <summary>
        /// 訂單已未通過審核
        /// </summary>
        [EnumDescription("4021")]
        TransactionUnapproved,
        /// <summary>
        /// 訂單不需審核
        /// </summary>
        [EnumDescription("4022")]
        TransactionApprovelUnrequired,
        /// <summary>
        /// 未設定批價
        /// </summary>
        [EnumDescription("4023")]
        WholesalePriceIsNull,

        /// <summary>
        /// 查無此交易訂單號
        /// </summary>
        [EnumDescription("4024")]
        TransactionNumberNotFound,

        /// <summary>
        /// 發票已開立
        /// </summary>
        [EnumDescription("4200")]
        InvoiceAlreadyCerated,
        /// <summary>
        /// 發票未開立
        /// </summary>
        [EnumDescription("4201")]
        InvoiceNotCerated,
        /// <summary>
        /// 派對兔主題或模式商品已購買
        /// </summary>
        [EnumDescription("4202")]
        PartyTuThemeOrModeAlreadyPurchased,

        /// <summary>
        /// 訂單已付款
        /// </summary>
        [EnumDescription("4300")]
        TransactionPaid,
        /// <summary>
        /// 無效的 IPN 資料
        /// </summary>
        [EnumDescription("4400")]
        PayPal_InvalidIpn,

        /// <summary>
        /// 取得歐付寶結帳資料錯誤
        /// </summary>
        [EnumDescription("4500")]
        OPay_GetCheckoutStringFailed,
        /// <summary>
        /// 無法取得歐付寶訂單資料
        /// </summary>
        [EnumDescription("4501")]
        OPay_QueryTradeFailed,
        /// <summary>
        /// 歐付寶主動通知處理失敗
        /// </summary>
        [EnumDescription("4502")]
        OPay_NotifyHandlingFailed,
        /// <summary>
        /// 此兌換碼已兌換
        /// </summary>
        [EnumDescription("4601")]
        AlreadyRedeemed,
        /// <summary>
        /// 兌換碼不在可兌換的時間範圍內
        /// </summary>
        [EnumDescription("4602")]
        RedeemTimeNotInRange,
        /// <summary>
        /// 兌換碼暫停兌換
        /// </summary>
        [EnumDescription("4603")]
        RedeemSerialIsSuspend,
        /// <summary>
        /// 創建交易的源 IP 地址無效
        /// </summary>
        [EnumDescription("4604")]
        CreationTransactionInvalidSourceIp,
        /// <summary>
        /// 街口訂單交易尚未完成
        /// </summary>
        [EnumDescription("4605")]
        JkopayTransactionNotComplete,
        #endregion

        /// <summary>
        /// 系統錯誤
        /// </summary>
        [EnumDescription("9999")]
        SystemError
    }
}
