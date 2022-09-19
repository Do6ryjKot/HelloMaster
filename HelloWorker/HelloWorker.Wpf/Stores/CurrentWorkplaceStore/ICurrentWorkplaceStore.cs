using HelloWorker.Domain.Models;
using System;

namespace HelloWorker.Wpf.Stores.CurrentWorkplaceStore {

	/// <summary>
	///	Хранилище ныне просматриваемого объекта
	/// </summary>
	public interface ICurrentWorkplaceStore {
		
		/// <summary>
		///	Нынешний объект
		/// </summary>
		Workplace CurrentWorkplace { get; }

		/// <summary>
		///	Срабатывает при изменении объекта
		/// </summary>
		event Action StateChanged;

		/// <summary>
		///	Загрузка данных объекта по его ид
		/// </summary>
		/// <param name="id">Ид объекта</param>
		void Load(long id);

		void Refresh();

		/*
		/// <summary>
		///	Добавление позиции
		/// </summary>
		/// <param name="workplaceWork">Позиция, которую необходимо добавить</param>
		void AddPosition(WorkplaceWork workplaceWork);

		/// <summary>
		///	Обновление позиции
		/// </summary>
		/// <param name="workplaceWork">Позиция, что должна быть обновлена</param>
		void UpdatePosition(WorkplaceWork workplaceWork);

		/// <summary>
		///	Удаление позиции
		/// </summary>
		/// <param name="workplaceWork">Позиция, которую нужно удалить</param>
		void DeletePosition(WorkplaceWork workplaceWork);
		*/
	}
}
