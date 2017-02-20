using System.ComponentModel.DataAnnotations;

namespace Violin.Store.Classes
{
	/// <summary>
	/// 大概叫做发现好货的商城吧
	/// </summary>
	public class Goods
	{
		/// <summary>
		/// 以作为数据库表的主键
		/// </summary>
		[Key] public int ProductId { get; set; }

		/// <summary>
		/// 商品名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 商品价格
		/// </summary>
		public SalePrice Price { get; set; }

		/// <summary>
		/// 商品备注
		/// </summary>
		public string Note { get; set; }
	}
}
