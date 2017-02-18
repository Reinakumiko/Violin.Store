using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public string Nickname { get; set; }
		public string Account { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public string EmailAddress { get; set; }
		public string PhoneNumber { get; set; }
	}
}
