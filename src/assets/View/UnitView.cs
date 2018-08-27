using System;
using Newtonsoft.Json;

namespace ITnet2.Server.BusinessLogic.Core.LMS.View
{
	/// <summary>
	/// Блок
	/// </summary>
	public class UnitView
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		[JsonProperty("unitId")]
		public Guid UnitId { get; set; }

		/// <summary>
		/// Название
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Длительность в минутах
		/// </summary>
		[JsonProperty("durationMinutes")]
		public int Duration { get; set; }
	}
}