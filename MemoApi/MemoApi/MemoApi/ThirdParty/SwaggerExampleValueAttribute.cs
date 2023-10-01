using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoApi.ThirdParty
{
    /// <summary>
    /// 提供 Swagger UI 參數範例值設定
    /// </summary>
    public class SwaggerExampleValueAttribute : Attribute
    {
        /// <summary>
        /// 初始化新的 <see cref="SwaggerExampleValueAttribute"/>
        /// </summary>
        /// <param name="value">變數預設值</param>
        public SwaggerExampleValueAttribute(object value)
        {
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// 初始化新的 <see cref="SwaggerExampleValueAttribute"/>
        /// </summary>
        /// <param name="name">變數名稱</param>
        /// <param name="value">變數預設值</param>
        public SwaggerExampleValueAttribute(string name, object value) : this(value)
        {
            this.Name = name;
        }

        /// <summary>
        /// 取得或設定變數名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 取得或設定變數值
        /// </summary>
        public object Value { get; set; }
    }
}