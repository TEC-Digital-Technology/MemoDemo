using MemoApi.Core.UIData;
using MemoApi.Models.Request;
using MemoApi.Models.Response;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace MemoApi.Controllers
{
    /// <summary>
    /// 處理備忘錄相關的控制器
    /// </summary>
    /// <returns></returns>
    public class MemoController : ApiController
    {
        /// <summary>
        /// 初始化 處理備忘錄相關的控制器
        /// </summary>
        public MemoController()
        {
            this.MemoUIData = new MemoUIData();
        }

        /// <summary>
        /// 取得備忘錄資料
        /// </summary>
        /// <param name="request">取得備忘錄資料的請求實體</param>
        /// <returns></returns>
        [HttpPost]
        public GetMemoResponse GetMemo(GetMemoRequest request)
        {
            return new GetMemoResponse()
            {
                ID = Guid.NewGuid(),
                Title = "Title",
                Content = "Content"
            };
        }

        /// <summary>
        /// 取得備忘錄清單資料
        /// </summary>
        /// <param name="request">取得備忘錄清單資料的請求實體</param>
        /// <returns></returns>
        [HttpPost]
        public GetMemoListResponse GetMemoList(GetMemoListRequest request)
        {
            return new GetMemoListResponse()
            {
                MemoList = new List<Core.Infos.MemoInfo>()
                {
                    new Core.Infos.MemoInfo()
                    {
                        ID = Guid.NewGuid(),
                        Title = "Title",
                        Content = "Content"
                    }
                }
            };
        }

        /// <summary>
        /// 新增備忘錄資料
        /// </summary>
        /// <param name="request">新增備忘錄資料的請求實體</param>
        /// <returns></returns>
        [HttpPost]
        public AddMemoResponse AddMemo(AddMemoRequest request)
        {
            return new AddMemoResponse()
            {
                ID = Guid.NewGuid(),
                Title = "Title",
                Content = "Content"
            };
        }

        /// <summary>
        /// 更新備忘錄資料
        /// </summary>
        /// <param name="request">更新備忘錄資料的請求實體</param>
        /// <returns></returns>
        [HttpPost]
        public UpdateMemoResponse UpdateMemo(UpdateMemoRequest request)
        {
            return new UpdateMemoResponse()
            {
                ID = Guid.NewGuid(),
                Title = "Title",
                Content = "Content"
            };
        }

        /// <summary>
        /// 刪除備忘錄資料
        /// </summary>
        /// <param name="request">刪除備忘錄資料的請求實體</param>
        /// <returns></returns>
        [HttpPost]
        public DeleteMemoResponse DeleteMemo(DeleteMemoRequest request)
        {
            return new DeleteMemoResponse();
        }


        /// <summary>
        /// 處理備忘錄相關的 UIData
        /// </summary>
        public MemoUIData MemoUIData { get; set; }
    }
}
