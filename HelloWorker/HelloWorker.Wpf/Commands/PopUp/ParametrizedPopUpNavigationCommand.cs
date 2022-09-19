using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.ViewModels.Base;

namespace HelloWorker.Wpf.Commands.PopUp {

	/// <summary>
	///	Параметризированная команда перехода на поп-ап
	/// </summary>
	/// <typeparam name="TViewModel">Модель представления что будет загружено в поп ап</typeparam>
	/// <typeparam name="TParameter">Тип параметра</typeparam>
	public class ParametrizedPopUpNavigationCommand<TViewModel, TParameter> : CommandBase
		where TViewModel : ViewModelBase {

		private readonly TParameter _param;
		private readonly IParametrizedPopUpNavigationService<TViewModel, TParameter> _navigationService;

		public ParametrizedPopUpNavigationCommand(TParameter param, IParametrizedPopUpNavigationService<TViewModel, TParameter> navigationService) {

			_param = param;
			_navigationService = navigationService;
		}

		public override void Execute(object parameter) {

			_navigationService.Navigate(_param);
		}
	}
}
