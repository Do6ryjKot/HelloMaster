using HelloWorker.Domain.Models;
using System.Collections.Generic;

namespace HelloWorker.Domain.Services.Data {
	
	/// <summary>
	///	Сервис работы с позициями объектов
	/// </summary>
	public interface IWorkplacePositionDataService {

		/// <summary>
		///	Добавление позиции объекту
		/// </summary>
		/// <param name="workplaceWork">Позиция</param>
		/// <returns>Добавленная позиция</returns>
		WorkplaceWork Add(WorkplaceWork workplaceWork);

		/// <summary>
		///	Обновление позиции объекта
		/// </summary>
		/// <param name="workplaceWork">Позиция</param>
		/// <returns>Обновленная позиция</returns>
		WorkplaceWork Update(WorkplaceWork workplaceWork);

		/// <summary>
		///	Удаление позиции объекта
		/// </summary>
		/// <param name="workplaceWork">Позиция</param>
		void Delete(WorkplaceWork workplaceWork);

		/// <summary>
		/// Получить позиции акта
		/// </summary>
		/// <param name="actId">Ид акта</param>
		/// <returns>Список позиций</returns>
		IEnumerable<WorkplaceWork> GetFromAct(long actId);

		/// <summary>
		/// Получить все позции объекта
		/// </summary>
		/// <param name="workplaceId">Ид объекта</param>
		/// <returns>Список позиций</returns>
		IEnumerable<WorkplaceWork> GetFromWorkplace(long workplaceId);
	}
}
