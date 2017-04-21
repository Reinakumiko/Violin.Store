using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Violin.Store.Classes;
using Violin.Store.Classes.AccessFlags;

namespace Violin.Store.Tools.Filters
{
	public class AccessRequiredAttribute : ActionFilterAttribute
	{
		/// <summary>
		/// 指示可通过验证的用户权限
		/// </summary>
		public UserAccess[] Access { get; set; }

		public AccessRequiredAttribute(params UserAccess[] _access)
		{
			Access = _access;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var user = filterContext.HttpContext.Session["user"] as UserAccount;

			var accessFlags = new List<UserAccess>() { UserAccess.Root };
			accessFlags.AddRange(Access);

			var hasAccess = user == null
						  ? false
						  : accessFlags.Contains(user.Access);

			if (!hasAccess)
			{
				filterContext.HttpContext.Response.Redirect("/Home/InvalidPermission");
				return;
			}


			base.OnActionExecuting(filterContext);
		}
	}
}
