using HelloWorker.Wpf.ViewModels.Base;
using System;

namespace HelloWorker.Wpf.Stores.PopUp {
	
	/// <summary>
	///	Хранилище данных поп-апа
	/// </summary>
	public interface IPopUpNavigationStore {

		/// <summary>
		/// Нынешняя модель представления прдетсавления, что загружена в поп ап
		/// </summary>
		ViewModelBase CurrentViewModel { get; set; }

		/// <summary>
		///	Имеет ли поп ап содержимое
		/// </summary>
		bool HasContent { get; }

		/// <summary>
		/// Срабатывает при смене содержимого поп апа
		/// </summary>
		event Action StateChanged;

		/// <summary>
		/// Закрыть поп ап
		/// </summary>
		void Close();
	}
}
