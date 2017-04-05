using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Violin.Store.Classes;

namespace Violin.Store.Tools
{
    public static class UserTools
    {
        /// <summary>
        /// 获取加密密码
        /// </summary>
        /// <param name="account">需要加密的用户信息</param>
        /// <returns>加密后的密码</returns>
        public static string EncryptPassword(this UserAccount account)
        {
            MD5 md5 = MD5.Create();

            var md5Result = md5.ComputeHash(Encoding.UTF8.GetBytes(account.Password + account.Salt));
            SHA1 sha1 = SHA1.Create();

            var saltBytes = md5Result.ToList();
            saltBytes.AddRange(Encoding.UTF8.GetBytes(account.Salt));

            return Encoding.UTF8.GetString(sha1.ComputeHash(saltBytes.ToArray()));
        }

        /// <summary>
        /// 为账户生成混淆盐
        /// </summary>
        /// <param name="account">需要进行生成混淆盐的账户</param>
        /// <returns>所生成的混淆盐字符串</returns>
        public static string GenerateSalt(this UserAccount account)
        {
            return account.GetHashCode().ToString("x6");
        }
    }
}
