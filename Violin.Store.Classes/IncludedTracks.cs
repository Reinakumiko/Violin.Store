using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Violin.Store.Classes
{
	/// <summary>
	/// 专辑收录曲目
	/// </summary>
	[DisplayColumn("Discography")]
	public class IncludedTracks
	{
		/// <summary>
		/// 音轨号
		/// </summary>
		[Key, Display(Name = "音轨号")]
		public int Track { get; set; }

		/// <summary>
		/// 曲目名称
		/// </summary>
		[Display(Name = "曲目名称")]
		public string Name { get; set; }

		/// <summary>
		/// 作词
		/// </summary>
		[Display(Name = "作词")]
		public string LyricsBy { get; set; }

		/// <summary>
		/// 作曲
		/// </summary>
		[Display(Name = "作曲")]
		public string Composer { get; set; }

		/// <summary>
		/// 编曲
		/// </summary>
		[Display(Name = "编曲")]
		public string Arranger { get; set; }

		/// <summary>
		/// 曲目所属专辑
		/// </summary>
		[ForeignKey("DiscographyId")]
		[Display(Name = "所属专辑")]
		public Discography Discography { get; set; }

		/// <summary>
		/// 所属专辑编号
		/// 以作用于外键关系关联
		/// </summary>
		[Display(Name = "所属专辑编号")]
		public int DiscographyId { get; set; }
	}
}
