using System;
using System.ComponentModel.DataAnnotations;

namespace Violin.Store.Classes
{
	/// <summary>
	/// 日程表
	/// </summary>
	public class Schedule
	{
		/// <summary>
		/// 以作为数据库表的主键
		/// </summary>
		[Key] public int ScheduleId { get; set; }

		/// <summary>
		/// 日常所属分类
		/// </summary>
		public ScheduleType Type { get; set; }

		/// <summary>
		/// 日程时间
		/// </summary>
		public DateTime DateTime { get; set; }

		/// <summary>
		/// 番组名称
		/// </summary>
		public string BangumiName { get; set; }

		/// <summary>
		/// 番组节目地址
		/// </summary>
		public string BangumiUrl { get; set; }
	}

	/// <summary>
	/// 日程表的所属类型
	/// </summary>
	public enum ScheduleType
	{
		/// <summary>
		/// 电视节目的日程表
		/// </summary>
		TV,

		/// <summary>
		/// 广播节目的日程表
		/// </summary>
		Radio,
	}
}
