using System;
using System.Collections.Generic;

namespace MemoApi.Adapter.DataSource
{
    /// <summary>
    /// 資料 (模擬)
    /// </summary>
    public static class Data
    {
        static Data()
        {
            Data.MemoList = new List<MemoData>();
        }
        /// <summary>
        /// 取得或設定 備忘錄清單
        /// </summary>
        public static List<MemoData> MemoList { get; set; }
        
        /// <summary>
        /// 備忘錄
        /// </summary>

        public class MemoData
        {
            /// <summary>
            /// 取得或設定 ID
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
}
