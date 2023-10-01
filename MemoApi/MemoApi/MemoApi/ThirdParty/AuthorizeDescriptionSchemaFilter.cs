using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace MemoApi.ThirdParty
{
    /// <summary>
    /// 提供 Swagger UI 參數範例值設定的 Swagger 擴充類別
    /// </summary>
    public class AuthorizeDescriptionSchemaFilter : IOperationFilter
    {

        /// <summary>
        /// 應用過濾器
        /// </summary>
        /// <param name="operation"><see cref="Operation"/> 實體</param>
        /// <param name="schemaRegistry"><see cref="SchemaRegistry"/> 實體</param>
        /// <param name="apiDescription"><see cref="ApiDescription"/> 實體</param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (this.GetIsAuthorizationRequired(apiDescription))
            {
                operation.summary = $"🔑 {operation.summary}";
            }
        }

        /// <summary>
        /// 取得該類別是否需要驗證
        /// </summary>
        /// <param name="apiDescription">API 描述</param>
        /// <returns></returns>
        private bool GetIsAuthorizationRequired(ApiDescription apiDescription)
        {
            if (apiDescription.GetControllerAndActionAttributes<AllowAnonymousAttribute>().Any())
            {
                return false;
            }
            if (apiDescription.GetControllerAndActionAttributes<AuthorizeAttribute>().Any())
            {
                return true;
            }
            return false;
        }
    }
}