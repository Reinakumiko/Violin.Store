using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violin.Store.Classes;

namespace Violin.Store.Database.Mapping
{
	public class Mapping_Goods : EntityTypeConfiguration<Goods>
	{
		public Mapping_Goods()
		{
			this.ToTable("Goods");
		}
	}
}
