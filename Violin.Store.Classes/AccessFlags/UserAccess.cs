using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Store.Classes.AccessFlags
{
    /// <summary>
    /// 指示用户账户的操作权限
    /// </summary>
    [Flags]
    public enum UserAccess
    {
        /// <summary>
        /// 普通用户
        /// </summary>
        User        = 0,

        /// <summary>
        /// 新闻操作权限用户
        /// </summary>
        News        = (1 << 1),

        /// <summary>
        /// 仓库操作权限用户
        /// </summary>
        Store       = (1 << 2),

        /// <summary>
        /// 管理员权限用户
        /// </summary>
        Admin       = (1 << 4),

        /// <summary>
        /// 主管理权限
        /// </summary>
        Root        = (1 << 5)
    }
}
