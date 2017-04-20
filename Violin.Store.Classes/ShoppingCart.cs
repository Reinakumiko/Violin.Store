using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
		[ForeignKey(nameof(_idAccounts))]
		public virtual UserAccount Account { get; set; }

		/// <summary>
		/// 购物车中商品的信息
		/// </summary>
		[ForeignKey(nameof(_idInfos))]
		public virtual ShoppingProduct ProductInfo { get; set; }

		/// <summary>
		/// 与商品信息关联的外键编号
		/// </summary>
		public int _idInfos { get; set; }

		/// <summary>
		/// 与关联账户的外键编号
		/// </summary>
		public int _idAccounts { get; set; }
	}
}
