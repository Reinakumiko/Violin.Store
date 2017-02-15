using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Store.Classes
{
	/// <summary>
	/// 附送赠品
	/// </summary>
	public class Giveaway
	{
		/// <summary>
		/// 以作为数据库表的主键
		/// </summary>
		[Key] public int GivewayId { get; set; }

		/// <summary>
		/// 赠品名称
		/// </summary>
		public string Name { get; set; }
	}
}
