using HelloWorker.Wpf.ViewModels.Base;
using System;

namespace HelloWorker.Wpf.Stores.Navigation {
	
	/// <summary>
	///	Хранилище данных навигации
	/// </summary>
	public interface INavigationStore {

		/// <summary>
		///	Модель представления ныне активного представления
		/// </summary>
		ViewModelBase CurrentViewModel { get; set; }

		/// <summary>
		/// Срабатывает при смене нынешней модели представления
		/// </summary>
		event Action StateChanged;
	}
}
