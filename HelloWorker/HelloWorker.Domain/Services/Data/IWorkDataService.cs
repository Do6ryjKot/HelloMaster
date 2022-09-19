using HelloWorker.Domain.Models;
using System.Collections.Generic;

namespace HelloWorker.Domain.Services.Data {
	
	/// <summary>
	/// Сервис работы с перечнем работ
	/// </summary>
	public interface IWorkDataService {

		/// <summary>
		///	Фильтр поиска
		/// </summary>
		string SearchFilter { get; set; }

		/// <summary>
		/// Фильтр по группе работ
		/// </summary>
		WorkGroup WorkGroupFilter { get; set; }
		
		/// <summary>
		/// Фильтр по категории работ
		/// </summary>
		WorkCategory WorkCategoryFilter { get; set; }

		/// <summary>
		///	Получить все работы прайслиста
		/// </summary>
		/// <returns>Список работ</returns>
		IEnumerable<Work> GetAll();		
	}
}
