using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Violin.Store.Classes;

namespace Violin.Store.Classes
{
	/// <summary>
	/// 作品目录
	/// </summary>
	[DefaultMember("Title")]
	[DisplayColumn(nameof(Title))]
	public class Discography
	{
		/// <summary>
		/// 以作为数据库表的主键
		/// </summary>
		[Key, Display(Name = "专辑编号")]
		public int DiscographyId { get; set; }

		/// <summary>
		/// 封面图
		/// </summary>
		[Display(Name = "封面图地址")]
		public string CoverImage { get; set; }

		/// <summary>
		/// 标题
		/// </summary>
		[Display(Name = "专辑名")]
		public string Title { get; set; }

		/// <summary>
		/// 副标题
		/// </summary>
		[Display(Name = "专辑副标题")]
		public string Subtitle { get; set; }

		/// <summary>
		/// 简介
		/// </summary>
		[Display(Name = "专辑简介")]
		public string Description { get; set; }

		/// <summary>
		/// 发售时间
		/// </summary>
		[Display(Name = "发售时间")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
		public DateTime OnSaleTime { get; set; }

		/// <summary>
		/// 产品编号
		/// </summary>
		[Display(Name = "产品编号")]
		public string ProductNumber { get; set; }

		/// <summary>
		/// 销售价格
		/// </summary>
		[Display(Name = "销售价格")]
		public double Price { get; set; }

		/// <summary>
		/// 收录曲目
		/// </summary>
		[Display(Name = "收录曲目")]
		public virtual List<IncludedTracks> Tracks { get; set; }

		/// <summary>
		/// 收录数
		/// </summary>
		[Display(Name = "收录数")]
		public int IncludedCount { get { return Tracks?.Count ?? 0; } }

		/// <summary>
		/// 附送赠品
		/// </summary>
		[Display(Name = "附赠品")]
		public virtual List<Giveaways> Giveaway { get; set; }

		public override string ToString()
		{
			return this.Title;
		}
	}
}
