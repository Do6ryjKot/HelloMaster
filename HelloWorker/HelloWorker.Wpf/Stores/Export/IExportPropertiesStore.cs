using HelloWorker.Wpf.Structures.Export;
using System.Collections.Generic;

namespace HelloWorker.Wpf.Stores.Export {
	
	/// <summary>
	/// Хранилище свойств для экспорта
	/// </summary>
	public interface IExportPropertiesStore {

		/// <summary>
		/// Все свойства, доступные для экспорта
		/// </summary>
		IEnumerable<IExportProperty> ExportProperties { get; }

		/// <summary>
		///	Получить свойства для экспорта с ценами компании
		/// </summary>
		IEnumerable<IExportProperty> CompanyPricesExportProps { get; }

		/// <summary>
		///	Получить свойства для экспорта с ценами мастера
		/// </summary>
		IEnumerable<IExportProperty> MasterPricesExportProps { get; }
	}
}
