using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Violin.Store.Classes
{
	public partial class UserAccount
	{
		/// <summary>
		/// 对比两个<see cref="UserAccount"/> 的 账户(不敏感)，密码(敏感) 是否相同。
		/// </summary>
		/// <param name="source">要比较的第一个 <see cref="UserAccount"/></param>
		/// <param name="match">要比较的第二个 <see cref="UserAccount"/></param>
		/// <returns>如果两个<see cref="UserAccount"/> 的账户(不敏感)，密码(敏感) 相同，则为 true；否则为 false。 </returns>
		public static bool operator ==(UserAccount source, UserAccount match)
		{
			return Equals(source, match);
		}

		/// <summary>
		/// 对比两个<see cref="UserAccount"/> 的 账户(不敏感)，密码(敏感) 是否不同。
		/// </summary>
		/// <param name="source">要比较的第一个 <see cref="UserAccount"/></param>
		/// <param name="match">要比较的第二个 <see cref="UserAccount"/></param>
		/// <returns>如果两个<see cref="UserAccount"/> 的账户(不敏感)，密码(敏感) 不同，则为 true；否则为 false。 </returns>
		public static bool operator !=(UserAccount source, UserAccount match)
		{
			return !source.Equals(match);
		}

		public static bool Equals(UserAccount source, UserAccount match)
		{
			if (ReferenceEquals(source, match))
				return true;

			if (object.Equals(source, null) || object.Equals(match, null))
				return false;

			if (!source.Account.Equals(match.Account, StringComparison.CurrentCultureIgnoreCase))
				return false;

			if (EncryptPassword(source) == EncryptPassword(match))
				return true;
			return false;
		}

		public bool Equals(UserAccount match)
		{
			return Equals(this, match);
		}

		public override bool Equals(object obj)
		{
			if (obj is UserAccount)
				return this == obj as UserAccount;
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		/// <summary>
		/// 获取加密密码
		/// </summary>
		/// <param name="account">需要加密的用户信息</param>
		/// <returns>加密后的密码</returns>
		private static string EncryptPassword(UserAccount account)
		{
			MD5 md5 = MD5.Create();

			var md5Result = md5.ComputeHash(Encoding.UTF8.GetBytes(account.Password + account.Salt));
			SHA1 sha1 = SHA1.Create();

			var saltBytes = md5Result.ToList();
			saltBytes.AddRange(Encoding.UTF8.GetBytes(account.Salt));

			return Encoding.UTF8.GetString(sha1.ComputeHash(saltBytes.ToArray()));
		}
	}
}
