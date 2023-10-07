using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoApi.Models.Request
{
    /// <summary>
    /// 取得備忘錄資料的請求
    /// </summary>
    public class GetMemoRequest
    {
        /// <summary>
        /// 取得或設定 備忘錄 ID
        /// </summary>
        public Guid ID { get; set; }
    }
}