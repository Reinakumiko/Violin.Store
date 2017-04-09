using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// 收货地址
        /// </summary>
        [Display(Name = "收货地址")]
        public ReceveAddress Address { get; set; }

        /// <summary>
        /// 订单内产品列表
        /// </summary>
        [Display(Name = "产品列表")]
        public Goods Goods { get; set; }

        /// <summary>
        /// 购买用户
        /// </summary>
        [Display(Name = "买家用户")]
        public UserAccount Account { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [Display(Name = "订单状态")]
        public OrderState State{ get; set; }
    }

    /// <summary>
    /// 表示订单当前的状态
    /// </summary>
    public enum OrderState
    {
        /// <summary>
        /// 订单已关闭
        /// </summary>
        Closed,

        /// <summary>
        /// 订单已取消
        /// </summary>
        Cancled,

        /// <summary>
        /// 订单已支付
        /// </summary>
        Paid,

        /// <summary>
        /// 订单已发货
        /// </summary>
        Shipped,

        /// <summary>
        /// 订单已签收
        /// 理论上用不到已签收
        /// </summary>
        Signed
    }
}
