using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using TEC.Core.ComponentModel;

namespace MemoApi.ThirdParty
{
    /// <summary>
    /// 顯示列舉為「顯示名稱(值)」的 Swagger 文件擴充類別
    /// </summary>
    public class EnumDescriptionDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// 應用過濾器
        /// </summary>
        /// <param name="swaggerDoc"><see cref="SwaggerDocument"/> 實體</param>
        /// <param name="schemaRegistry"><see cref="SchemaRegistry"/> 實體</param>
        /// <param name="apiExplorer"><see cref="IApiExplorer"/> 實體</param>
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            foreach (var schemaDictionaryItem in swaggerDoc.definitions)
            {
                var schema = schemaDictionaryItem.Value;
                foreach (var propertyDictionaryItem in schema.properties)
                {
                    var property = propertyDictionaryItem.Value;
                    var propertyEnums = property.@enum;
                    if (propertyEnums == null && property.@type == "array")
                    {
                        propertyEnums = property.items.@enum;
                    }
                    if (propertyEnums != null && propertyEnums.Count > 0)
                    {
                        var enumDescriptions = new List<string>();
                        for (int i = 0; i < propertyEnums.Count; i++)
                        {
                            var enumOption = propertyEnums[i];
                            try
                            {
                                enumDescriptions.Add(String.Format("{1}({0})", Convert.ToInt64(enumOption), ((System.Enum)enumOption).GetEnumDescription()));
                            }
                            catch (InvalidOperationException)
                            {
                                enumDescriptions.Add(((System.Enum)enumOption).ToString());
                            }
                        }
                        property.description += String.Format(" ({0})", String.Join(", ", enumDescriptions.ToArray()));
                    }
                }
            }
        }
    }
}