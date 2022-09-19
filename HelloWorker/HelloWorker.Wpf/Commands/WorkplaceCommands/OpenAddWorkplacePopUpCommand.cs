using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.ViewModels.PriceListCalculation.PopUp;

namespace HelloWorker.Wpf.Commands.WorkplaceCommands {

	/// <summary>
	///	Открыть поп ап добавления объекта
	/// </summary>
	public class OpenAddWorkplacePopUpCommand : CommandBase {

		private readonly IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace> _navigationService;

		public OpenAddWorkplacePopUpCommand(IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace> navigationService) {
			_navigationService = navigationService;
		}

		public override void Execute(object parameter) {

			_navigationService.Navigate(null);
		}
	}
}
