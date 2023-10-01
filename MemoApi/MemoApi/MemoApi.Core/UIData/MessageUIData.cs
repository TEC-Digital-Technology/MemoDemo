using MemoApi.Adapter;
using MemoApi.Core.Converters;
using MemoApi.Core.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApi.Core.UIData
{
    /// <summary>
    /// 訊息 UI 資料層
    /// </summary>
    public class MessageUIData
    {
        /// <summary>
        /// 取得指定國別代號的訊息資料清單
        /// </summary>
        /// <param name="countryCode">語系代號</param>
        /// <returns></returns>
        public List<MessageInfo> GetMessageInfoList(string countryCode)
        {
            MessageConverter messageConverter = new MessageConverter();
            return new MessageAdapter().GetMessageByCountry(countryCode)
                .Select(t => messageConverter.Convert(t)).ToList();

        }
        /// <summary>
        /// 取得系統支援的語系
        /// </summary>
        /// <returns></returns>
        public List<string> GetSupportedCultureCode()
        {
            return new MessageAdapter().GetSupportedCultureCode();
        }
    }
}
