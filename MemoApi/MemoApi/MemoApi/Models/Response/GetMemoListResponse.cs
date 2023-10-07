using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoApi.Models.Response
{
    /// <summary>
    /// 取得備忘錄清單的回應
    /// </summary>
    public class GetMemoListResponse : SiteResponseBase
    {
        /// <summary>
        /// 取得或設定 備忘錄清單
        /// </summary>
        public List<GetMemoResponse> MemoList { get; set; }
    }
}