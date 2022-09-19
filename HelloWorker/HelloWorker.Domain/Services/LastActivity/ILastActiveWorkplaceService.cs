
using HelloWorker.Domain.Models;

namespace HelloWorker.Domain.Services.LastActivity {
	
	/// <summary>
	///	Сервис получения ид объекта, в котором проводилась последняя активность
	/// </summary>
	public interface ILastActiveWorkplaceService {

		/// <summary>
		///	Возвращает ид объекта, в котором проводилась последняя активность
		/// </summary>
		/// <returns>Ид объекта</returns>
		long GetLastActiveWorkplaceId();

		/// <summary>
		///	Обновить последнюю активность
		/// </summary>
		/// <param name="workplace">Объект, на котором производилась работа</param>
		void UpdateLastActivity(Workplace workplace);
	}
}
