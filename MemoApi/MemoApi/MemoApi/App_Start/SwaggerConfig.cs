using MemoApi.Settings;
using MemoApi.ThirdParty;
using MemoApi.Untils.Enums;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MemoApi.App_Start
{
    public static class SwaggerConfig
    {
        /// <summary>
        /// 設定 <see cref="SwaggerConfig"/>
        /// </summary>
        public static void Register(HttpConfiguration config)
        {
            if (!config.Properties.TryGetValue(typeof(SettingCollectionFactoryInternal), out object settingCollectionInternalObject))
            {
                throw new ArgumentNullException($"必須先註冊 {nameof(SettingCollectionFactoryInternal)}");
            }
            SettingCollectionFactoryInternal settingCollectionInternal = settingCollectionInternalObject as SettingCollectionFactoryInternal;
            if (!(bool)settingCollectionInternal.ApiApplicationSettingCollection[ApiApplicationSettingEnum.IsSwaggerEnabled])
            {
                return;
            }
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            config.EnableSwagger("version/{apiVersion}", c =>
            {
                c.SingleApiVersion("v1", $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.Replace('.', ' ')} Document");
                c.IncludeXmlComments(System.Web.Hosting.HostingEnvironment.MapPath($"~/App_Data/{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                c.UseFullTypeNameInSchemaIds();
                c.DocumentFilter<EnumDescriptionDocumentFilter>();
                c.SchemaFilter<SetExampleValuesSchemaFilter>();
                c.OperationFilter<AuthorizeDescriptionSchemaFilter>();
            })
                .EnableSwaggerUi("docs/{*assetPath}", c =>
                {
                    c.DocumentTitle($"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.Replace('.', ' ')}");
                });
            config.Routes.MapHttpRoute(
                 name: "Swagger UI",
                 routeTemplate: "",
                 defaults: null,
                 constraints: null,
                 handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "docs/index")
            );
        }
    }
}