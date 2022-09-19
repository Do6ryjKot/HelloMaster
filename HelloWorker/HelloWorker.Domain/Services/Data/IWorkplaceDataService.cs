using HelloWorker.Domain.Models;
using System.Collections.Generic;

namespace HelloWorker.Domain.Services.Data {
	
	/// <summary>
	///	Сервис работы с объектами (квартирами и т.д)
	/// </summary>
	public interface IWorkplaceDataService {

		/// <summary>
		/// Получение всех объектов
		/// </summary>
		/// <returns>Список объектов</returns>
		IEnumerable<Workplace> GetAll();

		/// <summary>
		///	Deprecated - Получение объекта со всеми своими позициями
		/// </summary>
		/// <param name="id">Ид объекта</param>
		/// <returns>Объект с позициями</returns>
		Workplace GetWithPositions(long id);
		
		/// <summary>
		///	Получение объекта со всеми своими актами
		/// </summary>
		/// <param name="id">Ид объекта</param>
		/// <returns>Объект с актами</returns>
		Workplace GetWithActs(long id);

		/// <summary>
		/// Получение данных об объекте
		/// </summary>
		/// <param name="id">Ид объекта</param>
		/// <returns>Объект</returns>
		Workplace Get(long id);

		/// <summary>
		///	Добавление объекта
		/// </summary>
		/// <param name="workplace">Объект</param>
		/// <returns>Добавленный объект</returns>
		Workplace Add(Workplace workplace);

		/// <summary>
		/// Изменение объекта
		/// </summary>
		/// <param name="workplace">Объект</param>
		/// <returns>Измененный объект</returns>
		Workplace Update(Workplace workplace);

		/// <summary>
		///	Получить количество объектов
		/// </summary>
		/// <returns></returns>
		long GetCount();

		/// <summary>
		/// Удаление объекта
		/// </summary>
		/// <param name="workplace">Объект, что нужно удалить</param>
		void Delete(Workplace workplace);
	}
}
