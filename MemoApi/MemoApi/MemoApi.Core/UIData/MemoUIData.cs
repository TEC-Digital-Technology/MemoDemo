using MemoApi.Adapter.DataSource;
using MemoApi.Core.Converters;
using MemoApi.Core.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MemoApi.Core.UIData
{
    /// <summary>
    /// 處理備忘錄相關的商業邏輯層
    /// </summary>
    public class MemoUIData
    {
        /// <summary>
        /// 透過 ID 取得備忘錄資訊
        /// </summary>
        /// <param name="id">備忘錄 ID </param>
        /// <returns></returns>
        public MemoInfo GetMemoById(Guid id)
        {
            return new MemoConverter().Convert(Data.MemoList.SingleOrDefault(t => t.ID == id));
        }

        /// <summary>
        /// 取得備忘錄清單
        /// </summary>
        /// <returns></returns>
        public List<MemoInfo> GetMemoList()
        {
            MemoConverter converter = new MemoConverter();
            return Data.MemoList.Select(t => converter.Convert(t)).ToList();
        }

        /// <summary>
        /// 新增備忘錄資料
        /// </summary>
        /// <param name="memoInfo">欲新增的備忘錄資料實體</param>
        /// <returns></returns>
        public MemoInfo AddMemo(MemoInfo memoInfo)
        {
            MemoConverter converter = new MemoConverter();
            var memoData = new MemoConverter().ConvertBack(memoInfo);
            memoData.ID = Guid.NewGuid();
            Data.MemoList.Add(memoData);
            return converter.Convert(memoData);
        }

        /// <summary>
        /// 更新備忘錄資料
        /// </summary>
        /// <param name="memoInfo">欲更新的備忘錄資料實體</param>
        /// <returns></returns>
        public MemoInfo UpdateMemo(MemoInfo memoInfo)
        {
            MemoConverter converter = new MemoConverter();
            var memoData = Data.MemoList.Single(t => t.ID == memoInfo.ID);
            memoData.Title = memoInfo.Title;
            memoData.Content = memoInfo.Content;
            return converter.Convert(memoData);
        }

        /// <summary>
        /// 透過 ID　刪除備忘錄資料
        /// </summary>
        /// <param name="id">備忘錄 ID</param>
        public void DeleteMemo(Guid id)
        {
            MemoConverter converter = new MemoConverter();
            Data.MemoList.Remove(Data.MemoList.Single(t => t.ID == id));
        }
    }
}
