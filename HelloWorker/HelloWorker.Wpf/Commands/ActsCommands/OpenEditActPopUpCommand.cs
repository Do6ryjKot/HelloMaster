using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.ViewModels.ActsFolderView;
using HelloWorker.Wpf.ViewModels.ActsFolderView.PopUp;

namespace HelloWorker.Wpf.Commands.ActsCommands {

	/// <summary>
	/// Команда открытия окна изменения акта
	/// </summary>
	public class OpenEditActPopUpCommand : CommandBase {

		private readonly ActFolderViewModel _viewModel;
		private readonly IParametrizedPopUpNavigationService<ActAddEditPopUpViewModel, Act> _navigationService;

		public OpenEditActPopUpCommand(ActFolderViewModel viewModel,
			IParametrizedPopUpNavigationService<ActAddEditPopUpViewModel, Act> navigationService) {
			_viewModel = viewModel;
			_navigationService = navigationService;
		}

		public override void Execute(object parameter) {

			_navigationService.Navigate(_viewModel.Act);
		}
	}
}
