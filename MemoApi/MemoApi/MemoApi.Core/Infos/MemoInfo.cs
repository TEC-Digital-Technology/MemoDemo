using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApi.Core.Infos
{
    /// <summary>
    /// 備忘錄資料
    /// </summary>
    public class MemoInfo
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
