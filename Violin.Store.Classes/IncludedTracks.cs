using System.ComponentModel.DataAnnotations;

namespace Violin.Store.Classes
{
	/// <summary>
	/// 专辑收录曲目
	/// </summary>
	public class IncludedTracks
	{
		/// <summary>
		/// 音轨号
		/// </summary>
		[Key] public int Track { get; set; }

		/// <summary>
		/// 曲目名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 作词
		/// </summary>
		public string LyricsBy { get; set; }

		/// <summary>
		/// 作曲
		/// </summary>
		public string Composer { get; set; }

		/// <summary>
		/// 编曲
		/// </summary>
		public string Arranger { get; set; }
	}
}
