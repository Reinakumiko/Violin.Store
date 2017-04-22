using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violin.Store.Tools.Attributes;

namespace Violin.Store.Classes
{
	public class Orders
	{
		/// <summary>
		/// 订单编号，主键，自增
		/// </summary>
		[Key]
		public int OrderID { get; set; }

		/// <summary>
		/// 订单号
		/// </summary>
		[Display(Name = "订单号")]
		public string OrderNumber { get; set; }

		/// <summary>
		/// 收货地址
		/// </summary>
		[Display(Name = "收货地址")]
		public virtual ReceveAddress Address { get; set; }

		/// <summary>
		/// 订单内产品列表
		/// </summary>
		[Display(Name = "产品列表")]
		public virtual List<ShoppingProduct> ProductInfos { get; set; }

		/// <summary>
		/// 购买用户
		/// </summary>
		[Display(Name = "买家用户")]
		public virtual UserAccount Account { get; set; }

		/// <summary>
		/// 订单状态
		/// </summary>
		[Display(Name = "订单状态")]
		public OrderState State { get; set; }
	}

	/// <summary>
	/// 表示订单当前的状态
	/// </summary>
	public enum OrderState
	{
		/// <summary>
		/// 订单已关闭
		/// </summary>
		[MemberName(Name = "已关闭")]
		[Display(Name = "已关闭")]
		Closed,

		/// <summary>
		/// 订单已取消
		/// </summary>
		[MemberName(Name = "已取消")]
		[Display(Name = "已取消")]
		Cancled,

		/// <summary>
		/// 订单待支付
		/// </summary>
		[MemberName(Name = "待支付")]
		[Display(Name = "待支付")]
		WaitPayment,

		/// <summary>
		/// 订单已支付
		/// </summary>
		[MemberName(Name = "已支付")]
		[Display(Name = "已支付")]
		Paid,

		/// <summary>
		/// 订单待发货
		/// </summary>
		[MemberName(Name = "待发货")]
		[Display(Name = "待发货")]
		WaitShip,

		/// <summary>
		/// 订单已发货
		/// </summary>
		[MemberName(Name = "已发货")]
		[Display(Name = "已发货")]
		Shipped,

		/// <summary>
		/// 订单已签收
		/// 理论上用不到已签收
		/// </summary>
		[MemberName(Name = "已签收")]
		[Display(Name = "已签收")]
		Signed
	}
}
