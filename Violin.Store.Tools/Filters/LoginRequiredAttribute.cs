using System;
using System.Web.Mvc;
using Violin.Store.Classes;

namespace Violin.Store.Tools.Filters
{
	/// <summary>
	/// 该特性用于限制操作必须处于登录时才可执行，以便于限制用户登录。
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class LoginRequiredAttribute : ActionFilterAttribute
	{
		/// <summary>
		/// 在操作执行前验证用户是否已登录
		/// </summary>
		/// <param name="filterContext">执行上下文</param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var user = filterContext.HttpContext.Session["user"];

			if (user == null || !(user is UserAccount))
			{
				filterContext.HttpContext.Response.Redirect("/Account/InvalidPermission");
				return;
			}

			base.OnActionExecuting(filterContext);
		}
	}
}