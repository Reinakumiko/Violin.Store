using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Store.Classes
{
	/// <summary>
	/// 个人简历
	/// </summary>
	public class Profile
	{
		/// <summary>
		/// 艺术家
		/// </summary>
		public Artister Artister { get; set; }

		/// <summary>
		/// 简介内容
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// 简介图片
		/// </summary>
		public string Image { get; set; }
	}
}
