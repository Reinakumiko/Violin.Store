using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Store.Classes
{
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
        public string Consignee { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 收货人电话
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
