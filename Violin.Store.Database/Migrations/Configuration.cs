using MySql.Data.Entity;
using System.Data.Entity.Migrations;
using Violin.Store.Classes;
using Violin.Store.Tools;

namespace Violin.Store.Database.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			var sqlGenerator = new MySqlMigrationSqlGenerator();

			SetSqlGenerator("MySql.Data.MySqlClient", sqlGenerator);
		}

		protected override void Seed(DatabaseContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//

			var root = new UserAccount
			{
				Account = "root",
				EmailAddress = "root@sayaka.com",
				Nickname = "Root",
				Access = Classes.AccessFlags.UserAccess.Root
			};

			root.Salt = root.GenerateSalt();
			root.Password = root.EncryptPassword();

			//插入root管理员
			if (!context.Account.CheckRepeat(user => root.Account == user.Account))
				context.Account.AddOrUpdate(root);
		}
	}
}
