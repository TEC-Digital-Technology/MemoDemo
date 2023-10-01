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
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "0005", Message = "無效的網際網路通訊協定（IP）位址：{0}" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "0006", Message = "無法辨識的地區代碼或文化特性。" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "0014", Message = "管制類帳號無法執行此作業" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "0100", Message = "橘子支API錯誤，錯誤代碼:{0}，{1}" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1000", Message = "欄位為必填" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1001", Message = "值區間不符規定" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1002", Message = "必須先登入" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1003", Message = "登入票證已過期，請先更新登入票證後再呼叫其他API" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1004", Message = "登入票證不合法，請將登入票證帶入Request的Header並確定其值為正確格式" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1005", Message = "登入的帳號或密碼錯誤" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1006", Message = "查無此資料" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1007", Message = "授權發生錯誤，詳細資料請參考相關訊息：{0}" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1008", Message = "Email 已經被註冊" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1009", Message = "輸入的資訊至少包含一個值" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1010", Message = "Email 格式錯誤" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1011", Message = "資料已存在" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1012", Message = "超過每個產品的最大可購買數，目前限制為: {0} 個" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1013", Message = "密碼錯誤" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1014", Message = "無法接受空字串或空格" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1015", Message = "電話號碼格式錯誤" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1016", Message = "電子發票愛心碼格式錯誤" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1017", Message = "電子發票自然人憑證格式錯誤" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1018", Message = "電子發票手機條碼格式錯誤" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1019", Message = "驗證碼檢核失敗" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1020", Message = "傳送信件的間隔太短" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1021", Message = "Email 已驗證通過" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1022", Message = "Token 需要被更新" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1023", Message = "必須設定密碼" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1024", Message = "密碼必須為空" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1025", Message = "超過每張訂單的最大產品總量" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1026", Message = "非公司員工" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1027", Message = "帳號已被鎖定" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1028", Message = "無法使用一次性信箱" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1029", Message = "第三方登入方式不支援" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1030", Message = "查無指定的資料，共{0}筆。參數名稱:{1}。資料內容:{2}。" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1031", Message = "固定手續費值區間不符，應為大於等於 0 的整數。" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "1032", Message = "百分比手續費值區間不符，應為 0~100 的整數或小數。" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "3000", Message = "OAuth 提供者未提供 Email" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "3001", Message = "OAuth 提供者提供的 Email 已被註冊" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "3002", Message = "OAuth 註冊失敗" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "3003", Message = "Email 未驗證" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "3004", Message = "註冊時，Email 為必要欄位" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "3005", Message = "無法背景更新 Token，須重新登入" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4000", Message = "選購的商品的狀態為關閉時無法建立訂單" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4001", Message = "商品狀態為完售時無法建立訂單，此訊息將會被替換成 {\"不足庫存的商品ID1\":可購買的商品數量,\"不足庫存的商品ID2\":可購買的商品數量}之格式" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4002", Message = "商品狀態為停止銷售時無法建立訂單" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4003", Message = "訂單的付款狀態不合法" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4004", Message = "具備未付款訂單時無法建單" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4005", Message = "訂單已取消" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4006", Message = "查無此商品" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4007", Message = "查無此商品價格" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4008", Message = "輸入的商品必須為序號商品" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4009", Message = "輸入序號商品的製造廠商不合法" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4010", Message = "商品序號已配發" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4011", Message = "商品序號未配發" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4012", Message = "商品序號格式有誤" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4013", Message = "不支援以此幣別交易" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4014", Message = "優惠券已過期" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4015", Message = "優惠券已達最大使用數" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4016", Message = "無效的優惠卷序號" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4017", Message = "不符合優惠卷或付款方式使用限制" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4018", Message = "無效的優惠券庫存量" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4019", Message = "指定的付款通路目前無法使用" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4020", Message = "訂單已通過審核" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4021", Message = "訂單已未通過審核" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4022", Message = "訂單不需審核" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4023", Message = "未設定批價" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4024", Message = "查無此交易訂單號：{0}" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4200", Message = "發票已開立" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4201", Message = "發票未開立" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4202", Message = "已擁有相同的派對兔主題或模式商品" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4300", Message = "訂單已付款" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4400", Message = "無效的 IPN 資料" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4500", Message = "無法產生歐付寶建立訂單所需資料" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4501", Message = "無法取得歐付寶訂單資料" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4502", Message = "歐付寶主動通知處理失敗" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4601", Message = "兌換碼已兌換。" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4602", Message = "兌換碼不在可兌換的時間範圍內。" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4603", Message = "兌換碼暫停兌換。" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4604", Message = "建立交易的源 IP 地址無效。IP：{0}" });
                    messageEntityList.Add(new MessageEntity() { CountryCode = countryCode, MessageCode = "4605", Message = "街口訂單交易尚未完成。訂單編號：{0}" });
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
