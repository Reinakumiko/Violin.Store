using System;
using System.ComponentModel.DataAnnotations;

namespace Violin.Store.Classes
{

	/// <summary>
	/// 艺人信息
	/// </summary>
	public class Artister
	{
		/// <summary>
		/// 以作为数据库表的主键
		/// </summary>
		[Key] public int ArtisterId { get; set; }

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
