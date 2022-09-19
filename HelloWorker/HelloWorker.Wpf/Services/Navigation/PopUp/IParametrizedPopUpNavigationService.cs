using HelloWorker.Wpf.ViewModels.Base;

namespace HelloWorker.Wpf.Services.Navigation.PopUp {
	
	/// <summary>
	/// Параметризированный сервис навигации на поп ап
	/// </summary>
	/// <typeparam name="TViewModel">Модель представления, что будет загружено в поп ап</typeparam>
	/// <typeparam name="TParameter">Тип параметра</typeparam>
	public interface IParametrizedPopUpNavigationService<TViewModel, TParameter> where TViewModel : ViewModelBase {

		/// <summary>
		///	Переход
		/// </summary>
		void Navigate(TParameter parameter);
	}
}
