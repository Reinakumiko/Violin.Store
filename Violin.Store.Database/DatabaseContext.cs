//#define MySQL

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violin.Store.Classes;
using Violin.Store.Database.Mapping;

namespace Violin.Store.Database
{
#if MySQL
 //   [DbConfigurationType(typeof(MySqlConfiguration))]
#endif
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
		//public DbSet<Profile> Profile { get; set; }

		/// <summary>
		/// 日程表
		/// </summary>
		public DbSet<Schedule> Schedule { get; set; }

		/// <summary>
		/// 账户表
		/// </summary>
		public DbSet<UserAccount> Account { get; set; }

		/// <summary>
		/// 曲目表
		/// </summary>
		public DbSet<IncludedTracks> IncludedTracks { get; set; }

		/// <summary>
		/// 订单表
		/// </summary>
		public DbSet<Orders> Orders { get; set; }

		/// <summary>
		/// 购物车表
		/// </summary>
		public DbSet<ShoppingCart> Cart { get; set; }

		public DatabaseContext()
#if MySQL
            :base("name=MySQLConnectionString")
#else
            : base("name=LocalConnectionString")
#endif
        {
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new Mapping_Orders());

			base.OnModelCreating(modelBuilder);
		}

		public System.Data.Entity.DbSet<Violin.Store.Classes.ReceveAddress> ReceveAddresses { get; set; }
	}
}
