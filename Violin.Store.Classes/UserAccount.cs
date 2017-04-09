using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Violin.Store.Classes.AccessFlags;

namespace Violin.Store.Classes
{
    /// <summary>
    /// 用户的账号信息
    /// </summary>
    public partial class UserAccount
    {
        /// <summary>
        /// 以作为数据库表的主键
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [Display(Name ="用户昵称")]
		public string Nickname { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        [Display(Name = "用户账号")]
		public string Account { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [Display(Name = "用户密码")]
        public string Password { get; set; }

        /// <summary>
        /// 盐
        /// </summary>
        [Display(Name = "盐")]
        public string Salt { get; set; }

        /// <summary>
        /// 邮件地址
        /// </summary>
        [Display(Name = "邮件地址")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [Display(Name = "电话号码")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 账号管理权限
        /// </summary>
        [Display(Name = "账号管理权限")]
        public UserAccess Access { get; set; }

        /// <summary>
        /// 该用户的收货地址
        /// </summary>
        [Display(Name = "用户收货地址")]
        public List<ReceveAddress> ReceiveAddresses { get; set; }
    }
}
