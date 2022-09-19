using HelloWorker.Wpf.ViewModels.Base;

namespace HelloWorker.Wpf.Services.Navigation.PopUp {
	
	/// <summary>
	///	Сервис перехода на поп ап
	/// </summary>
	/// <typeparam name="TViewModel">Модель представления открываемого окна</typeparam>
	public interface IPopUpNavigationService<TViewModel> where TViewModel : ViewModelBase {

		/// <summary>
		///	Переход
		/// </summary>
		void Navigate();
	}
}
