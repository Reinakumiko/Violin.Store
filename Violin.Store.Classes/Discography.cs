using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Store.Classes
{
	/// <summary>
	/// 作品目录
	/// </summary>
	public class Discography
	{
		/// <summary>
		/// 封面图
		/// </summary>
		public string CoverImage { get; set; }

		/// <summary>
		/// 标题
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// 副标题
		/// </summary>
		public string Subtitle { get; set; }

		/// <summary>
		/// 简介
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// 发售时间
		/// </summary>
		public DateTime OnSaleTime { get; set; }

		/// <summary>
		/// 产品编号
		/// </summary>
		public string ProductNumber { get; set; }

		/// <summary>
		/// 销售价格
		/// </summary>
		public SalePrice Price { get; set; }

		/// <summary>
		/// 收录曲目
		/// </summary>
		public List<IncludedTracks> Tracks { get; set; }

		/// <summary>
		/// 收录数
		/// </summary>
		public int IncludedCount { get; set; }

		/// <summary>
		/// 附送赠品
		/// </summary>
		public List<Giveaway> Giveaway { get; set; }
	}

}
