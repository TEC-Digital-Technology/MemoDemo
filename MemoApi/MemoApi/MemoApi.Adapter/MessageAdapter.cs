using MemoApi.Adapter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApi.Adapter
{
    public class MessageAdapter
    {
        /// <summary>
        /// 依照國別代碼取得相對應的訊息
        /// </summary>
        /// <param name="countryCode">國別代碼</param>
        /// <returns></returns>
        public List<MessageEntity> GetMessageByCountry(string countryCode)
        {
            List<MessageEntity> messageEntityList = new List<MessageEntity>();

            switch (countryCode.ToLower())
            {
                case "zh-tw":
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "0000", Message = "成功" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "0001", Message = "傳入參數有誤，此訊息將被替換成 [{\"ErrorCode\":\"錯誤代號1\",\"ErrorColumnName\":\"錯誤欄位1\",\"ErrorMessage\":\"錯誤訊息1\"},{\"ErrorCode\":\"錯誤代號2\",\"ErrorColumnName\":\"錯誤欄位2\",\"ErrorMessage\":\"錯誤訊息2\"}]之格式" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "0002", Message = "無法辨識的語系" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "0003", Message = "存取被拒" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "0004", Message = "不支援的語系" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "9999", Message = "系統錯誤" });
                    break;

                default:
                    throw new NotSupportedException($"不支援 {countryCode}，目前僅支援下列語言：{String.Join(", ", this.GetSupportedCultureCode())}");
            }

            return messageEntityList;
        }

        /// <summary>
        /// 取得所有系統支援的國別代碼
        /// </summary>
        /// <returns></returns>
        public List<string> GetSupportedCultureCode()
            => new List<string>()
            {
                "zh-tw"
            };
    }
}
