using System;
using System.Collections.Generic;
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
		public int NewsID { get; set; }
		public DateTime ReleaseTime { get; set; }
		public NewsType Type { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
	}

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
