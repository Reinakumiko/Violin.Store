using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Violin.Store.Classes
{
	/// <summary>
	/// 最新消息
	/// </summary>
	public class News
	{
		/// <summary>
		/// 作用于数据库表的主键
		/// KeyAttribute类为标识表主键的属性
		/// </summary>
		[Key] public int NewsID { get; set; }

		/// <summary>
		/// 新闻发布时间
		/// </summary>
		[Display(Name = "新闻发布时间")]
		public DateTime ReleaseTime { get; set; }

		/// <summary>
		/// 新闻类型
		/// </summary>
		[Display(Name = "新闻类型")]
		public NewsType Type { get; set; }

		/// <summary>
		/// 新闻标题
		/// </summary>
		[Display(Name = "新闻标题")]
		public string Title { get; set; }

		/// <summary>
		/// 新闻内容
		/// </summary>
		[Display(Name = "新闻正文")]
		public string Content { get; set; }
	}

	/// <summary>
	/// 新闻可属类型
	/// </summary>
	public enum NewsType
	{
		/// <summary>
		/// 媒体采访
		/// </summary>
		[Display(Name = "媒体采访")]
		Media,

		/// <summary>
		/// 商品通知
		/// </summary>
		[Display(Name = "商品通知")]
		Goods,

		/// <summary>
		/// 专辑发售
		/// </summary>
		[Display(Name = "专辑发售")]
		Release,

		/// <summary>
		/// 其他类型
		/// </summary>
		[Display(Name = "其他类型")]
		Other,

		/// <summary>
		/// 直播类
		/// </summary>
		[Display(Name = "直播类")]
		Web,

		/// <summary>
		/// 巡演相关
		/// </summary>
		[Display(Name = "巡演相关")]
		Live,

		/// <summary>
		/// 特殊活动
		/// </summary>
		[Display(Name = "特殊活动")]
		Event
	}
}
