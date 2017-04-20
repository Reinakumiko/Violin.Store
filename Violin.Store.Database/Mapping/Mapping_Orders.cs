using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violin.Store.Classes;

namespace Violin.Store.Database.Mapping
{
	public class Mapping_Orders : EntityTypeConfiguration<Orders>
	{
		public Mapping_Orders()
		{
			this.ToTable(nameof(Orders));
			/*
			this.HasMany(o => o.ProductInfos)
				.WithMany(g => g.ProductId)
				.Map(m =>
				{
					m.ToTable("OrderProduct");
					m.MapLeftKey(nameof(Orders.OrderID));
					m.MapRightKey(nameof(Goods.ProductId));
				});
			*/
		}
	}
}
