
namespace HelloWorker.Wpf.Structures.Export {
	
	/// <summary>
	/// Тип свойства.
	/// USUAL - обычное.
	/// NESTED - вложенное.
	/// </summary>
	// public enum PropertyType { USUAL, NESTED }

	/// <summary>
	/// Свойство для экспорта
	/// </summary>
	public interface IExportProperty {

		/// <summary>
		/// Свойство используется для экспорта
		/// </summary>
		bool IsUsed { get; set; }

		/// <summary>
		/// Программное название свойства
		/// </summary>
		string[] PropertyName { get; set; }

		/// <summary>
		///	Название свойства в результирующем документе
		/// </summary>
		string DocumentName { get; set; }

		/// <summary>
		/// Название свойства в интерфейсе
		/// </summary>
		string ViewName { get; set; }

		/// <summary>
		/// Тип свойства
		/// </summary>
		// PropertyType PropertyType { get; set; }
	}
}
