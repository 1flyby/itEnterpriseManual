using Newtonsoft.Json;

namespace ITnet2.Server.BusinessLogic.Core.LMS.View
{
	/// <summary>
	/// Тэг
	/// </summary>
	public class TagView
	{
		/// <summary>
		/// Код
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }

		/// <summary>
		/// Имя
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}

	/// <summary>
	/// Уровень сложности
	/// </summary>
	public class LevelView
	{
		/// <summary>
		/// Код
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }

		/// <summary>
		/// Имя
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}

	/// <summary>
	/// Роль
	/// </summary>
	public class RoleView
	{
		/// <summary>
		/// Код
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }

		/// <summary>
		/// Имя
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}