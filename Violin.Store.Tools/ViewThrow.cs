using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Violin.Store.Tools
{
    public class ViewThrow
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
        public string Message { get; set; } = "用户发送了一个错误的请求。";
    }
}
