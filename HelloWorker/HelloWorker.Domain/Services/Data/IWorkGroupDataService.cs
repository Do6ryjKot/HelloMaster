using HelloWorker.Domain.Models;
using System.Collections.Generic;

namespace HelloWorker.Domain.Services.Data {
	
	/// <summary>
	/// Сервис работы со справочником групп работ
	/// </summary>
	public interface IWorkGroupDataService {

		/// <summary>
		///	Получение всех записей
		/// </summary>
		/// <returns>Список групп работ</returns>
		IEnumerable<WorkGroup> GetAll();
	}
}
