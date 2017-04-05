using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Violin.Store.Tools
{
    public static class ViewThrowTools
    {
        public static ActionResult Throw(this Controller controller, ViewThrow viewThrow)
        {
            var jsonResult = JsonConvert.SerializeObject(new { errcode = (int)viewThrow.StatusCode, errmsg = viewThrow.Message });
            controller.Response.Write(jsonResult);

            return new HttpStatusCodeResult(viewThrow.StatusCode, viewThrow.Message);
        }

        public static ActionResult RequestResult(this Controller controller, ViewThrow viewThrow)
        {
            var jsonResult = JsonConvert.SerializeObject(new { code = (int)viewThrow.StatusCode, msg = viewThrow.Message });
            controller.Response.Write(jsonResult);

            return new HttpStatusCodeResult(HttpStatusCode.OK, viewThrow.Message);
        }
    }
}
