using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MemoApi.Controllers
{
    /// <summary>
    /// AAA
    /// </summary>
    /// <returns></returns>
    public class MemoController : ApiController
    {
        /// <summary>
        /// AAA
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Test()
        {
            return "Yes";
        }
    }
}
