using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ITnet2.Server.BusinessLogic.Core.LMS.View
{
	/// <summary>
	/// Модуль
	/// </summary>
	public class ModuleView
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		[JsonProperty("moduleId")]
		public Guid ModuleId { get; set; }

		/// <summary>
		/// Изображение
		/// </summary>
		[JsonProperty("imageLink")]
		public string ImageLink { get; set; }

		/// <summary>
		/// Название
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Описание
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Длительность в минутах
		/// </summary>
		[JsonProperty("durationMinutes")]
		public int Duration { get; set; }

		/// <summary>
		/// В избранном
		/// </summary>
		[JsonProperty("isFavorite")]
		public bool IsFavorite { get; set; }

		/// <summary>
		/// Блоки
		/// </summary>
		[JsonProperty("units")]
		public List<UnitView> Units { get; set; }
	}
}