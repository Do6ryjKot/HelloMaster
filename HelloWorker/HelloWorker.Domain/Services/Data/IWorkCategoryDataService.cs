using HelloWorker.Domain.Models;
using System.Collections.Generic;

namespace HelloWorker.Domain.Services.Data {
	
	/// <summary>
	/// Сервис работы с категориями работ
	/// </summary>
	public interface IWorkCategoryDataService {

		/// <summary>
		/// Получение всех категорий
		/// </summary>
		/// <returns>Список категорий</returns>
		IEnumerable<WorkCategory> GetAll();
	}
}
