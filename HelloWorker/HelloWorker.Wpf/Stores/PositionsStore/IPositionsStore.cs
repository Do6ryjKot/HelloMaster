using HelloWorker.Domain.Models;
using System;
using System.Collections.ObjectModel;

namespace HelloWorker.Wpf.Stores.PositionsStore {
	
	/// <summary>
	/// Хранилище позиций
	/// </summary>
	public interface IPositionsStore {

		ObservableCollection<WorkplaceWork> Positions { get; }

		void LoadFromWorkplace(long workplaceId);
		void LoadFromAct(long actId);

		event Action StateChanged;

		/// <summary>
		/// Добавление позиции
		/// </summary>
		/// <param name="position">Позиция, что нужно добавить</param>
		void Add(WorkplaceWork position);

		/// <summary>
		/// Удаление позиции
		/// </summary>
		/// <param name="position">Позиция, что должна быть удалена</param>
		void Delete(WorkplaceWork position);

		/// <summary>
		/// Сохранение изменений позиции
		/// </summary>
		/// <param name="position">Позиция, которую необходимо сохранить</param>
		void Update(WorkplaceWork position);
	}
}
