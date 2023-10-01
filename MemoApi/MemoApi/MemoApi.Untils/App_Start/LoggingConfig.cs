using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TEC.Core.Web.WebApi.Handlers;
using MemoApi.Untils.Attributes;

namespace MemoApi.Untils
{
    /// <summary>
    /// 紀錄相關設定
    /// </summary>
    public class LoggingConfig
    {
        /// <summary>
        /// 初始化紀錄相關設定
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // TODO: 註冊到 Global.asax.cs: GlobalConfiguration.Configure(LoggingConfig.Register);
            // TODO: 初始化其他紀錄邏輯...

            // 啟用每次請求前紀錄一些相關參數至 HttpContext 中
            config.MessageHandlers.Add(new LoggingHandler());

            // 若要啟用紀錄 Web API 全部請求可使用下方程式碼註冊 LoggingActionFilterAttribute
            // config.Filters.Add(new LoggingActionFilterAttribute());
        }
    }
}
