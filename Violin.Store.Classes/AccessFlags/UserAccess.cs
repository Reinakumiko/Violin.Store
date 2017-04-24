using System;
using System.ComponentModel.DataAnnotations;
using Violin.Store.Tools.Attributes;

namespace Violin.Store.Classes.AccessFlags
{
	/// <summary>
	/// 指示用户账户的操作权限
	/// </summary>
    public enum UserAccess
    {
		/// <summary>
		/// 普通用户
		/// </summary>
		[Display(Name = "普通用户")]
		[MemberName(Name = "普通用户")]
		User = 0,

		/// <summary>
		/// 新闻操作权限用户
		/// </summary>
		[Display(Name = "新闻管理员")]
		[MemberName(Name = "新闻管理员")]
		News        = (1 << 1),

		/// <summary>
		/// 仓库操作权限用户
		/// </summary>
		[Display(Name = "仓库管理员")]
		[MemberName(Name = "仓库管理员")]
		Store       = (1 << 2),

		/// <summary>
		/// 管理员权限用户
		/// </summary>
		[Display(Name = "普通管理员")]
		[MemberName(Name = "普通管理员")]
		Admin       = (1 << 4),

		/// <summary>
		/// 主管理权限
		/// </summary>
		[Display(Name = "超级管理员")]
		[MemberName(Name = "超级管理员")]
		Root        = (1 << 5)
    }
}
