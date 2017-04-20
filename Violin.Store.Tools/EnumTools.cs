using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violin.Store.Classes;

namespace Violin.Store.Tools
{
	public static class EnumTools
	{
		public static string GetDisplayName(this OrderState enumName)
		{
			var attrs = enumName.GetType().GetField(enumName.ToString()).CustomAttributes;
			return string.Empty;
		}
	}
}
