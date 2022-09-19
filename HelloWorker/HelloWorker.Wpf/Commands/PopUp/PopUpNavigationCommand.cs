using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.ViewModels.Base;

namespace HelloWorker.Wpf.Commands.PopUp {

	/// <summary>
	/// Команда навигации поп апа
	/// </summary>
	/// <typeparam name="TViewModel">Модель представления открываемого окна</typeparam>
	public class PopUpNavigationCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase {

		private readonly IPopUpNavigationService<TViewModel> _navigationService;

		public PopUpNavigationCommand(IPopUpNavigationService<TViewModel> navigationService) {
			_navigationService = navigationService;
		}

		public override void Execute(object parameter) {

			_navigationService.Navigate();
		}
	}
}
