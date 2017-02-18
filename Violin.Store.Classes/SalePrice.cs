using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Store.Classes
{

	/// <summary>
	/// 销售价格
	/// </summary>
	public struct SalePrice
	{
		/// <summary>
		/// 价格
		/// </summary>
		public double Price { get; set; }

		/// <summary>
		/// 是否含税
		/// </summary>
		public bool IsIncludeTax { get; set; }
	}

}
