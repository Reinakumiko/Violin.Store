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
        /// <summary>
        /// 在控制器中抛出错误消息。
        /// </summary>
        /// <param name="controller">于 <see cref="Controller"/> 的扩展方法</param>
        /// <param name="viewThrow">需要抛出的错误信息</param>
        /// <returns></returns>
        public static ActionResult Throw(this Controller controller, ViewThrow viewThrow)
        {
            var jsonResult = JsonConvert.SerializeObject(new { errcode = (int)viewThrow.StatusCode, errmsg = viewThrow.Message });
            controller.Response.Write(jsonResult);

            return new HttpStatusCodeResult(viewThrow.StatusCode, viewThrow.Message);
        }

        /// <summary>
        /// 在控制器中返回请求消息
        /// </summary>
        /// <param name="controller">于 <see cref="Controller"/> 的扩展方法</param>
        /// <param name="viewThrow">需要返回到请求的数据内容</param>
        /// <returns></returns>
        public static ActionResult RequestResult(this Controller controller, ViewThrow viewThrow)
        {
            var jsonResult = JsonConvert.SerializeObject(new { code = (int)viewThrow.StatusCode, result = viewThrow.Result, msg = viewThrow.Message });
            controller.Response.Write(jsonResult);

            return new HttpStatusCodeResult(HttpStatusCode.OK, viewThrow.Message);
        }
    }
}
