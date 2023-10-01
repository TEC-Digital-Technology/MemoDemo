using MemoApi.Untils.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Web.WebApi.Exceptions;

namespace MemoApi.Core.Exceptions
{
    /// <summary>
    /// 代表操作不正確所發生的例外
    /// </summary>
    public class OperationFailedException : ResultCodeException<StatusCodeEnum>
    {

        /// <summary>
        /// 使用指定的錯誤代碼和造成這個例外狀況原因的內部例外參考，初始化 [OperationFailedException] 類別的新執行個體
        /// </summary>
        /// <param name="statusCodeEnum">解釋例外狀況原因的錯誤代碼列舉</param>
        /// <param name="innerException">造成目前例外狀況的例外狀況，若未指定內部例外狀況，則為 null 參考 (Visual Basic 中為 Nothing)</param>
        /// <param name="data">關於此例外的相關參數</param>
        /// <param name="cultureInfo">與此例外相關的文化特性，若輸入<c>null</c>時則會使用[Thread.CurrentThread]的[Thread.CurrentUICulture]</param>
        public OperationFailedException(StatusCodeEnum statusCodeEnum, Exception innerException, Dictionary<object, object> data = null, CultureInfo cultureInfo = null)
            : base(statusCodeEnum, innerException, data, cultureInfo)
        {
        }

        /// <summary>
        /// 使用指定的錯誤代碼，初始化 [OperationFailedException] 類別的新執行個體
        /// </summary>
        /// <param name="statusCodeEnum">解釋例外狀況原因的錯誤代碼列舉</param>
        /// <param name="data">關於此例外的相關參數</param>
        /// <param name="cultureInfo">與此例外相關的文化特性，若輸入<c>null</c>時則會使用[Thread.CurrentThread]的[Thread.CurrentUICulture]</param>
        public OperationFailedException(StatusCodeEnum statusCodeEnum, Dictionary<object, object> data = null, CultureInfo cultureInfo = null) :
            base(statusCodeEnum, null, data, cultureInfo)
        {
        }
    }
}
