using HelloWorker.Domain.Models;

namespace HelloWorker.Wpf.Services.Export {
	
	/// <summary>
	///	Сервис экспорта позиций объекта в эксель
	///	
	/// Deprecated
	/// </summary>
	public interface IWorkplaceWorkXlsxExportService {

		/// <summary>
		/// Экспорт данных с ценами компании
		/// </summary>
		/// <param name="workplace">Объект, позиции которого необходимо экспортировать</param>
		void ExportCompanyPrices(Workplace workplace);

		/// <summary>
		/// Экспорт данных с ценами мастера
		/// </summary>
		/// <param name="workplace">Объект, позиции которого необходимо экспортировать</param>
		void ExportMasterPrices(Workplace workplace);
	}
}
