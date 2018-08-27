using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ITnet2.Server.BusinessLogic.Core.LMS.View
{
	/// <summary>
	/// Курс
	/// </summary>
	public class CourseView
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		[JsonProperty("courceId")]
		public Guid CourseId { get; set; }

		/// <summary>
		/// Тип курса
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Изображение
		/// </summary>
		[JsonProperty("imageLink")]
		public string ImageLink { get; set; }

		/// <summary>
		/// Цвет фона
		/// </summary>
		[JsonProperty("backgroundColor")]
		public string BackgroundColor { get; set; }

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
		/// В избранном
		/// </summary>
		[JsonProperty("isFavorite")]
		public bool IsFavorite { get; set; }

		/// <summary>
		/// Роли
		/// </summary>
		[JsonProperty("roles")]
		public List<RoleView> Roles { get; set; }

		/// <summary>
		/// Уровени сложности
		/// </summary>
		[JsonProperty("levels")]
		public List<LevelView> Levels { get; set; }

		/// <summary>
		/// Тэги
		/// </summary>
		[JsonProperty("tags")]
		public List<TagView> Tags { get; set; }

		/// <summary>
		/// Количество модулей
		/// </summary>
		[JsonProperty("modulesQt")]
		public int ModulesQt { get; set; }

		/// <summary>
		/// Количество проектов
		/// </summary>
		[JsonProperty("projectsQt")]
		public int ProjectsQt { get; set; }

		/// <summary>
		/// Длительность в минутах
		/// </summary>
		[JsonProperty("durationMinutes")]
		public int Duration { get; set; }

		/// <summary>
		/// Модули
		/// </summary>
		[JsonProperty("modules")]
		public List<ModuleView> Modules { get; set; }
	}
}