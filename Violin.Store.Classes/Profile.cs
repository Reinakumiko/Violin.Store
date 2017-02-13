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

	/// <summary>
	/// 艺人信息
	/// </summary>
	public class Artister
	{
		/// <summary>
		/// 名字
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 英文名
		/// </summary>
		public string EnglishName { get; set; }

		/// <summary>
		/// 出生日期
		/// </summary>
		public DateTime BirthDay { get; set; }

		/// <summary>
		/// 血型
		/// </summary>
		public string BloodType { get; set; }

		/// <summary>
		/// 身高
		/// </summary>
		public int Height { get; set; }

		/// <summary>
		/// 出生地
		/// </summary>
		public string BrithIn { get; set; }

		/// <summary>
		/// 特长
		/// </summary>
		public string Specialty { get; set; }

		/// <summary>
		/// 兴趣爱好
		/// </summary>
		public string Hobby { get; set; }
	}
}
