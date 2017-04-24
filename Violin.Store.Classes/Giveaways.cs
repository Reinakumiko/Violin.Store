using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Violin.Store.Classes
{
    /// <summary>
    /// 附送赠品
    /// </summary>
    public class Giveaways
	{
        /// <summary>
        /// 以作为数据库表的主键
        /// </summary>
        [Key, Display(Name = "赠品编号")]
        public int GivewayId { get; set; }

        /// <summary>
        /// 赠品名称
        /// </summary>
        [Display(Name = "赠品名称")]
        public string Name { get; set; }

		/// <summary>
		/// 赠品对应的专辑
		/// </summary>
		[Display(Name = "所属专辑")]
		[ForeignKey(nameof(_idDiscography))]
		public virtual Discography Discography { get; set; }

		/// <summary>
		/// 对应专辑的编号, 外键
		/// </summary>
		[Display(Name = "专辑编号")]
		public int _idDiscography { get; set; }
	}
}
