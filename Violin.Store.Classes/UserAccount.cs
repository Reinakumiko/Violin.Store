using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Violin.Store.Classes
{
	/// <summary>
	/// 用户的账号信息
	/// </summary>
	public class UserAccount
	{
		/// <summary>
		/// 以作为数据库表的主键
		/// </summary>
		[Key] public int UserId { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
		public string Nickname { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
		public string Account { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
		public string Password { get; set; }

        /// <summary>
        /// 盐
        /// </summary>
		public string Salt { get; set; }

        /// <summary>
        /// 邮件地址
        /// </summary>
		public string EmailAddress { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
		public string PhoneNumber { get; set; }

        /// <summary>
        /// 账号管理权限
        /// </summary>
        public UserAccount Access { get; set; }

        /// <summary>
        /// 该用户的收货地址
        /// </summary>
        public List<ReceveAddress> ReceiveAddresses { get; set; }
    }
}
