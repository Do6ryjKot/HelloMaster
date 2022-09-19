using HelloWorker.Domain.Models;
using System;
using System.Collections.ObjectModel;

namespace HelloWorker.Wpf.Stores.PriceListStore {
	
	/// <summary>
	/// Хранилище прайс-листа
	/// </summary>
	public interface IPriceListStore {

		/// <summary>
		///	Набор работ
		/// </summary>
		ObservableCollection<Work> Works { get; }

		/// <summary>
		///	Фильтр поиска по имени
		/// </summary>
		string SearchFilter { get; set; }

		/// <summary>
		/// Фильтр по группе работ
		/// </summary>
		WorkGroup WorkGroupFilter { get; set; } 
		
		/// <summary>
		/// Фильтр по категории работ
		/// </summary>
		WorkCategory WorkCategoryFilter { get; set; } 

		/// <summary>
		///	Загрузка прайс-листа
		/// </summary>
		void Load();

		/// <summary>
		/// Срабатывает при изменении набора работ
		/// </summary>
		event Action StateChanged;
	}
}
