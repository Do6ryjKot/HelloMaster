using HelloWorker.Wpf.ViewModels.Base;

namespace HelloWorker.Wpf.Services.Navigation {
	
	/// <summary>
	/// Сервис навигации
	/// </summary>
	/// <typeparam name="TViewModel">Модель представления на которую нужно перейти</typeparam>
	public interface INavigationService<TViewModel> where TViewModel : ViewModelBase {

		/// <summary>
		/// Переход на новое представление
		/// </summary>
		void Navigate();
	}
}
