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
            var memoInfo = this.MemoUIData.GetMemoById(request.ID);
            return new GetMemoResponse()
            {
                ID = memoInfo.ID,
                Title = memoInfo.Title,
                Content = memoInfo.Content
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
            var memoInfos = this.MemoUIData.GetMemoList();
            return new GetMemoListResponse()
            {
                MemoList = memoInfos.Select(t => new GetMemoResponse()
                {
                    ID = t.ID,
                    Title = t.Title,
                    Content = t.Content
                }).ToList()
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
            var memoInfo = this.MemoUIData.AddMemo(new Core.Infos.MemoInfo()
            {
                Title = request.Title,
                Content = request.Content
            });
            return new AddMemoResponse()
            {
                ID = memoInfo.ID,
                Title = memoInfo.Title,
                Content = memoInfo.Content
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
            var memoInfo = this.MemoUIData.UpdateMemo(new Core.Infos.MemoInfo()
            {
                ID = request.ID,
                Title = request.Title,
                Content = request.Content
            });
            return new UpdateMemoResponse()
            {
                ID = memoInfo.ID,
                Title = memoInfo.Title,
                Content = memoInfo.Content
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
            this.MemoUIData.DeleteMemo(request.ID);
            return new DeleteMemoResponse();
        }


        /// <summary>
        /// 處理備忘錄相關的 UIData
        /// </summary>
        public MemoUIData MemoUIData { get; set; }
    }
}
