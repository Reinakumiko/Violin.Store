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

		[Key, Display(Name = "日程编号")]
		public int ScheduleId { get; set; }

		/// <summary>
		/// 日常所属分类
		/// </summary>
		[Display(Name = "日程分类")]
		public ScheduleType Type { get; set; }

		/// <summary>
		/// 日程时间
		/// </summary>
		[Display(Name = "预定开始时间")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
		public DateTime? StartTime { get; set; }

		/// <summary>
		/// 日程时间
		/// </summary>
		[Display(Name = "预定结束时间")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
		public DateTime? EndTime { get; set; }

		/// <summary>
		/// 番组名称
		/// </summary>
		[Display(Name = "节目名称")]
		public string BangumiName { get; set; }

		/// <summary>
		/// 番组节目地址
		/// </summary>
		[Display(Name = "节目地址")]
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
		[Display(Name = "电视节目")]
		TV,

		/// <summary>
		/// 广播节目的日程表
		/// </summary>
		[Display(Name = "广播节目")]
		Radio,
	}
}
