using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violin.Store.Classes;

namespace Violin.Store.Database
{
	public class DatabaseContext : DbContext
	{
		/// <summary>
		/// 商品表
		/// </summary>
		public DbSet<Goods> Goods { get; set; }

		/// <summary>
		/// 专辑表
		/// </summary>
		public DbSet<Discography> Discography { get; set; }

		/// <summary>
		/// 新闻表
		/// </summary>
		public DbSet<News> News { get; set; }

		/// <summary>
		/// 个人简介表
		/// </summary>
		public DbSet<Profile> Profile { get; set; }

		/// <summary>
		/// 日程表
		/// </summary>
		public DbSet<Schedule> Schedule { get; set; }

		/// <summary>
		/// 账户表
		/// </summary>
		public DbSet<UserAccount> Account { get; set; }


		public DatabaseContext()
			: base("name=LocalConnectionString")
		{
		}
	}
}
