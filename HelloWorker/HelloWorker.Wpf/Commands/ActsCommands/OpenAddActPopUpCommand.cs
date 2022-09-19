using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.ViewModels.ActsFolderView.PopUp;

namespace HelloWorker.Wpf.Commands.ActsCommands {

	/// <summary>
	/// Переход на поп ап добавления 
	/// </summary>
	public class OpenAddActPopUpCommand : CommandBase {

		private readonly IParametrizedPopUpNavigationService<ActAddEditPopUpViewModel, Act> _navigationService;

		public OpenAddActPopUpCommand(IParametrizedPopUpNavigationService<ActAddEditPopUpViewModel, Act> navigationService) {
			_navigationService = navigationService;
		}

		public override void Execute(object parameter) {

			_navigationService.Navigate(null);
		}
	}
}
