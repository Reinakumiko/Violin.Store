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
	/// 用户的收货地址
	/// </summary>
	public class ReceveAddress
	{
		/// <summary>
		/// 收货地址编号
		/// 以作用于数据库表的主键
		/// </summary>
		[Key]
		public int RecevingId { get; set; }

		/// <summary>
		/// 收货人
		/// </summary>
		[Display(Name = "收货人")]
		public string Consignee { get; set; }

		/// <summary>
		/// 收货地址
		/// </summary>
		[Display(Name = "收货地址")]
		public string Address { get; set; }

		/// <summary>
		/// 收货人电话
		/// </summary>
		[Display(Name = "收货人电话")]
		public string PhoneNumber { get; set; }

		/// <summary>
		/// 邮编号码
		/// </summary>
		[Display(Name = "邮编")]
		public string PostCode { get; set; }

		/// <summary>
		/// 默认地址
		/// </summary>
		[Display(Name = "默认地址")]
		public bool Default { get; set; }

		/// <summary>
		/// 地址对应的用户账户
		/// </summary>
		[ForeignKey(nameof(AccountId))]
		public virtual UserAccount Account { get; set; }
		
		/// <summary>
		/// 地址对应的用户编号
		/// </summary>
		public int AccountId { get; set; }
	}
}
