using HelloWorker.Domain.Models;
using System;
using System.Collections.ObjectModel;

namespace HelloWorker.Wpf.Stores.WorkplacesStore {
	
	/// <summary>
	///	Хранилище всех объектов
	/// </summary>
	public interface IWorkplacesStore {

		ObservableCollection<Workplace> Workplaces { get; }

		/// <summary>
		///	Выгрузка данных
		/// </summary>
		void Load();

		/// <summary>
		/// Список объектов изменился
		/// </summary>
		event Action StateChanged;

		/// <summary>
		/// Добавление объекта
		/// </summary>
		/// <param name="workplace">Объект, что нужно добавить</param>
		void Add(Workplace workplace);

		/// <summary>
		/// Изменение объекта
		/// </summary>
		/// <param name="workplace">Объект, что нужно изменить</param>
		void Update(Workplace workplace);

		/// <summary>
		/// Удаление объекта
		/// </summary>
		/// <param name="workplace">Объект, что нужно удалить</param>
		void Delete(Workplace workplace);
	}
}
