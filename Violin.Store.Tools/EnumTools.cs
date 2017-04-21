using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Violin.Store.Classes;
using Violin.Store.Tools.Attributes;

namespace Violin.Store.Tools
{
	public static class EnumTools
	{
		/// <summary>
		/// 获取枚举成员的属性名
		/// </summary>
		/// <param name="enumName">枚举成员</param>
		/// <returns></returns>
		public static string GetDisplayName(this Enum enumName)
		{
			var enumType = enumName.GetType();
			var field = enumType.GetField(Enum.GetName(enumType, enumName));
			var attr = Attribute.GetCustomAttribute(field, typeof(MemberNameAttribute)) as MemberNameAttribute;

			if (attr == null)
				return string.Empty;

			return attr.Name;
		}
	}
}
