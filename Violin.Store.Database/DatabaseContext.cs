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
		public DbSet<Goods> Goods { get; set; }
		public DbSet<Discography> Discography { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Profile> Profile { get; set; }
		public DbSet<Schedule> Schedule { get; set; }
		public DbSet<UserAccount> Account { get; set; }


		public DatabaseContext()
			: base("name=LocalConnectionString")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{


			base.OnModelCreating(modelBuilder);
		}
	}
}
