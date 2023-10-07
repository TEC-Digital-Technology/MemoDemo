using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoApi.Models.Request
{
    /// <summary>
    /// 更新備忘錄的請求
    /// </summary>
    public class UpdateMemoRequest
    {
        /// <summary>
        /// 取得或設定 備忘錄 ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 取得或設定 標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 取得或設定 內容
        /// </summary>
        public string Content { get; set; }
    }
}