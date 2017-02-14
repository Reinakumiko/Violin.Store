using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Store.Classes
{
	/// <summary>
	/// Goods 中的产品信息
	/// </summary>
	public class Products
	{
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
