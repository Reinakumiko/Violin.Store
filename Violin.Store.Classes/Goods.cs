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
        [Display(Name = "商品名称")]
        public string Name { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        [Display(Name = "商品价格")]
        public double Price { get; set; }

        /// <summary>
        /// 商品备注
        /// </summary>
        [Display(Name = "商品备注")]
        public string Note { get; set; }

		/// <summary>
		/// 商品预览图
		/// </summary>
		[Display(Name = "预览图地址")]
		public string ImageUrl { get; set; }

		/// <summary>
		/// 指示当前商品的可购买状态
		/// </summary>
		[Display(Name = "可购买状态")]
		public ProductState State { get; set; }
	}

	/// <summary>
	/// 表示一个商品当前的可购买状态
	/// </summary>
	public enum ProductState
	{
		/// <summary>
		/// 已上架
		/// </summary>
		[Display(Name = "已上架")]
		OnSale,

		/// <summary>
		/// 已下架
		/// </summary>
		[Display(Name = "已下架")]
		OffSale,

		/// <summary>
		/// 不可购买
		/// </summary>
		[Display(Name = "不可购买")]
		Unbuyable,
	}
}
