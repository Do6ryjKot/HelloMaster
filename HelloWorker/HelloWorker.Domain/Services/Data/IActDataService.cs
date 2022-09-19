using HelloWorker.Domain.Models;
using System.Collections.Generic;

namespace HelloWorker.Domain.Services.Data {
	
	/// <summary>
	/// Сервис работы с актами
	/// </summary>
	public interface IActDataService {

		/// <summary>
		///	Получить список актов по объекту
		/// </summary>
		/// <param name="workplaceId">Ид объекта</param>
		/// <returns>Список объектов</returns>
		IEnumerable<Act> GetByWorkplaceId(long workplaceId);

		/// <summary>
		/// Получить номер последнего акта по объекту
		/// </summary>
		/// <param name="workplaceId">Ид объекта</param>
		/// <returns>Номер последнего акта</returns>
		long GetLastActNum(long workplaceId);

		/// <summary>
		/// Добавление нового акта
		/// </summary>
		/// <param name="act">Акт, что нужно добавить</param>
		/// <returns>Новый акт</returns>
		Act Add(Act act);

		/// <summary>
		/// Изменение акта
		/// </summary>
		/// <param name="act">Акт, что нужно изменить</param>
		/// <returns>Измененный акт</returns>
		Act Update(Act act);

		/// <summary>
		/// Удаление акта
		/// </summary>
		/// <param name="act">Акт, что нужно удалить</param>
		void Delete(Act act);
		
		/// <summary>
		/// Получить акт по ид
		/// </summary>
		/// <param name="actId">Ид акта</param>
		/// <returns>Данные акта</returns>
		Act Get(long actId);

		/// <summary>
		/// Получить акт с позициями
		/// </summary>
		/// <param name="actId">Ид акта</param>
		/// <returns>Акт с позициями</returns>
		Act GetWithPositions(long actId);
	}
}
