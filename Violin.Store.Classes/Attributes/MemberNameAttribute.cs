using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Store.Tools.Attributes
{
	[AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
	public class MemberNameAttribute : Attribute
	{
		public string Name { get; set; }
	}
}
