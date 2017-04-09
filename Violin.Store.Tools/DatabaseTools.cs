using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Store.Tools
{
    public static class DatabaseTools
    {
        /// <summary>
        /// 检测该对象是否已在 <see cref="DbSet{TEntity}"/> 中存在
        /// </summary>
        /// <typeparam name="T">需要检测的数据类型</typeparam>
        /// <param name="set">已有的 <see cref="DbSet{TEntity}"/> 集合</param>
        /// <param name="func">检测对象存在的测验方式</param>
        /// <returns>该值已存在时为真，否则反之。</returns>
        public static bool CheckRepeat<T>(this DbSet<T> set, Expression<Func<T, bool>> func) where T : class
        {
            return set.Where(func.Compile()).Count() > 0;
        }
    }
}
