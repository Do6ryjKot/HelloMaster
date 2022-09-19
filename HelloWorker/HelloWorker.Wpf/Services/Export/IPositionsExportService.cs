using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Structures.Export;
using System.Collections.Generic;
using System.IO;

namespace HelloWorker.Wpf.Services.Export {

	/// <summary>
	/// Экспорт итого
	/// 
	/// None - не экспортировать
	/// CompanyCost - Итого по ценам предприятия
	/// MasterCost - Итого по ценам мастера
	/// </summary>
	public enum CostExport { None, CompanyCost, MasterCost }

	/// <summary>
	/// Сервис экспорта позиций
	/// </summary>
	public interface IPositionsExportService {

		/// <summary>
		/// Экспортировать все позиции объекта
		/// </summary>
		/// <param name="workplace">Объект, сервисы которого необходимо экспортировать</param>
		/// <param name="exportProperties">Параметры, которые необходимо экспортировать</param>
		/// <returns>Поток файла, которого необходимо сохранить</returns>
		Stream Export(Workplace workplace, IEnumerable<IExportProperty> exportProperties, CostExport costExport = CostExport.None);

		/// <summary>
		/// Экспортировать позиции акта
		/// </summary>
		/// <param name="act">Акт, позиции которого необходимо экспортировать</param>
		/// <returns>Поток файла, которого необходимо сохранить</returns>
		Stream Export(Act act, IEnumerable<IExportProperty> exportProperties, CostExport costExport = CostExport.None);
	}
}
