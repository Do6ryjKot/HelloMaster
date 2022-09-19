using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Navigation;
using HelloWorker.Wpf.ViewModels.Base;

namespace HelloWorker.Wpf.Commands.Navigation {

	/// <summary>
	/// Команда навигации
	/// </summary>
	/// <typeparam name="TViewModel">Модель представления на которую необходимо перейти</typeparam>
	public class NavigationCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase {

		private readonly INavigationService<TViewModel> _navigationService;

		public NavigationCommand(INavigationService<TViewModel> navigationService) {
			_navigationService = navigationService;
		}

		public override void Execute(object parameter) {

			_navigationService.Navigate();
		}
	}
}
