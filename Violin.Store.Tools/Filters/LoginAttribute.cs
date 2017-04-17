using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Violin.Store.Classes;

namespace Violin.Store.Tools.Filters
{
	/// <summary>
	/// 该特性用于限制操作必须处于登录时才可执行
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class LoginAttribute : ActionFilterAttribute
	{
		/// <summary>
		/// 在操作执行前验证用户是否已登录
		/// </summary>
		/// <param name="filterContext">执行上下文</param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var user = filterContext.HttpContext.Session["user"];

			if (user == null || !(user is UserAccount))
				filterContext.HttpContext.Response.Redirect("/Account/InvalidPermission");

			base.OnActionExecuting(filterContext);
		}
	}
}