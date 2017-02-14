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
		[Key]
		public int NewsID { get; set; }

		/// <summary>
		/// 新闻发布时间
		/// </summary>
		public DateTime ReleaseTime { get; set; }

		/// <summary>
		/// 新闻类型
		/// </summary>
		public NewsType Type { get; set; }

		/// <summary>
		/// 新闻标题
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// 新闻内容
		/// </summary>
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
		Media,

		/// <summary>
		/// 商品通知
		/// </summary>
		Goods,

		/// <summary>
		/// 专辑发售
		/// </summary>
		Release,

		/// <summary>
		/// 其他类型
		/// </summary>
		Other,

		/// <summary>
		/// 直播类
		/// </summary>
		Web,

		/// <summary>
		/// 巡回演唱会相关
		/// </summary>
		Live,

		/// <summary>
		/// 特殊活动
		/// </summary>
		Event
	}
}
