using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Store.Classes
{
	/// <summary>
	/// 购物车表
	/// </summary>
	public class ShoppingCart
	{
		/// <summary>
		/// 购物车编号, 自增, 主键
		/// </summary>
		[Key, Display(Name = "购物车编号")]
		public int CartId { get; set; }

		/// <summary>
		/// 购物车数据对应的账户
		/// </summary>
		[Display(Name = "对应账户")]
		public UserAccount Account { get; set; }

		/// <summary>
		/// 购物车数据对应的商品
		/// </summary>
		[Display(Name = "对应商品")]
		public Goods Goods { get; set; }

		/// <summary>
		/// 商品数量
		/// </summary>
		[Display(Name = "商品数量")]
		public int Quantity { get; set; }
	}
}
