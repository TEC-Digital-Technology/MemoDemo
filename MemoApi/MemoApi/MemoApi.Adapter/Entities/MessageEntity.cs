using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApi.Adapter.Entities
{
    /// <summary>
    /// 處理訊息的資訊資料類別
    /// </summary>
    public class MessageEntity
    {
        /// <summary>
        /// 設定或取得訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 設定或取得國別ISO兩碼代號
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// 設定或取得訊息代號
        /// </summary>
        public string MessageCode { get; set; }
    }
}
