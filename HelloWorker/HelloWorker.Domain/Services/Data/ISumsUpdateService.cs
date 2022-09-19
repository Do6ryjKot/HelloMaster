using HelloWorker.Domain.Models;

namespace HelloWorker.Domain.Services.Data {
	
	/// <summary>
	/// Сервис обновления сумм на основе позиции
	/// </summary>
	public interface ISumsUpdateService {

		/// <summary>
		/// Изменение сумм объекта и акта позиции (акта в случае если позиция привязана к акту)
		/// </summary>
		/// <param name="position">Позиция для которой необходимо менять суммы</param>
		void UpdateSums(WorkplaceWork position);
		
		/// <summary>
		/// Изменение сумм объекта на основании акта
		/// </summary>
		/// <param name="act">Акт для которого необходимо обновить сумму</param>
		void UpdateSums(Act act);
	}
}
