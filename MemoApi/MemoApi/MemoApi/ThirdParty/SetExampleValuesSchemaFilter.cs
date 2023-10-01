using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MemoApi.ThirdParty
{
    /// <summary>
    /// 提供 Swagger UI 參數範例值設定的 Swagger 擴充類別
    /// </summary>
    public class SetExampleValuesSchemaFilter : ISchemaFilter
    {

        /// <summary>
        /// 應用過濾器
        /// </summary>
        /// <param name="schema"><see cref="Schema"/> 實體</param>
        /// <param name="schemaRegistry"><see cref="SchemaRegistry"/> 實體</param>
        /// <param name="type">物件類型</param>
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            IDictionary<string, object> parameterValuePairs = this.GetParameterValuePairs(type);
            if (schema.properties != null)
            {
                foreach (var kvp in schema.properties)
                {
                    if (parameterValuePairs.ContainsKey(kvp.Key))
                    {
                        kvp.Value.example = parameterValuePairs[kvp.Key];
                    }
                }
            }
        }

        /// <summary>
        /// 取得該類別的所有範例值對應
        /// </summary>
        /// <param name="type">要取得的類別</param>
        /// <returns></returns>
        private IDictionary<string, object> GetParameterValuePairs(Type type)
        {
            IDictionary<string, object> parameterValuePairs = new Dictionary<string, object>();

            foreach (SwaggerExampleValueAttribute defaultValue in TypeDescriptor.GetAttributes(type).OfType<SwaggerExampleValueAttribute>())
            {
                parameterValuePairs.Add(defaultValue.Name, defaultValue.Value);
            }

            foreach (PropertyInfo property in type.GetProperties())
            {
                object defaultValue = this.GetExampleValue(property);

                if (defaultValue != null)
                {
                    parameterValuePairs.Add(property.Name, defaultValue);
                }
            }

            return parameterValuePairs;
        }

        /// <summary>
        /// 嘗試從 <see cref="SwaggerExampleValueAttribute"/> 中取得範例值
        /// </summary>
        /// <param name="property">屬性資訊</param>
        /// <returns></returns>
        private object GetExampleValue(PropertyInfo property)
        {
            SwaggerExampleValueAttribute customAttribute = property.GetCustomAttributes<SwaggerExampleValueAttribute>().FirstOrDefault();

            if (customAttribute != null)
            {
                if (property.PropertyType.IsEnum && customAttribute.Value is String)
                {
                    return customAttribute.Value;
                }
                else if (property.PropertyType.IsAssignableFrom(customAttribute.Value.GetType()))
                {
                    return customAttribute.Value;
                }
                else
                {
                    try
                    {
                        return TypeDescriptor.GetConverter(property.PropertyType).ConvertFrom(customAttribute.Value);
                    }
                    catch
                    {
                        return null;
                    }
                }
            }

            return null;
        }
    }
}