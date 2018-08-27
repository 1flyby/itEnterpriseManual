using System;
using Newtonsoft.Json;

namespace ITnet2.Server.BusinessLogic.Core.LMS.View
{
	/// <summary>
	/// Описание блока
	/// </summary>
	public class UnitTaskView
	{
		/// <summary>
		/// Идентификатор блока
		/// </summary>
		[JsonProperty("unitId")]
		public Guid UnitId { get; set; }

		/// <summary>
		/// Описание задания блока
		/// </summary>
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}