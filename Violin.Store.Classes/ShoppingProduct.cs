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
	/// 购物产品信息
	/// </summary>
	public class ShoppingProduct
	{
		/// <summary>
		/// 信息编号
		/// </summary>
		[Key]
		public int InfoId { get; set; }

		/// <summary>
		/// 对应的产品信息
		/// </summary>
		[ForeignKey(nameof(ProductId))]
		public virtual Goods Goods { get; set; }

		/// <summary>
		/// 产品数量
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// 对应的产品编号
		/// </summary>
		public int ProductId { get; set; }
	}
}
