using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApi.Core.Infos
{
    /// <summary>
    /// 處理訊息的資訊類別
    /// </summary>
    public class MessageInfo
    {
        /// <summary>
        /// 設定或取得訊息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 設定或取得國別代號
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// 設定或取得訊息代號
        /// </summary>
        public string MessageCode { get; set; }
    }
}
