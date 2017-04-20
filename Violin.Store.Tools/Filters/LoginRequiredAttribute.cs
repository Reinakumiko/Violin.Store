using System;
using System.Web.Mvc;
using Violin.Store.Classes;

namespace Violin.Store.Tools.Filters
{
	/// <summary>
	/// 该特性用于限制操作必须处于登录时才可执行，以便于限制用户登录。
	/// <para>
	/// <see cref="AttributeTargets.Method"/> 表示特性可用于方法之上，表示对单独操作进行限制。
	/// <see cref="AttributeTargets.Class"/> 表示特性可用于类之上，表示可对整个控制器操作限制。
	/// </para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
	public class LoginRequiredAttribute : ActionFilterAttribute
	{
		public bool IsBackstage { get; set; } = false;

		private string redirectLink
		{
			get
			{
				return IsBackstage ? "/Home/InvalidPermission"
								   : "/Account/InvalidPermission";
			}
		}

		/// <summary>
		/// 在操作执行前验证用户是否已登录
		/// </summary>
		/// <param name="filterContext">执行上下文</param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var user = filterContext.HttpContext.Session["user"];

			if (user == null || !(user is UserAccount))
			{
				filterContext.HttpContext.Response.Redirect(redirectLink);
				return;
			}

			base.OnActionExecuting(filterContext);
		}
	}
}