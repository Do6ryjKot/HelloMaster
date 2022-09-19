using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.ViewModels.PriceListCalculation.PopUp;

namespace HelloWorker.Wpf.Commands.WorkplaceCommands {

	/// <summary>
	/// Открыть поп ап изменения переданного объекта
	/// </summary>
	public class OpenEditSelectedWorkplacePopUpCommand : CommandBase {

		private readonly Workplace _workplace;
		private readonly IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace> _navigationService;

		public OpenEditSelectedWorkplacePopUpCommand(Workplace workplace, 
			IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace> navigationService) {

			_workplace = workplace;
			_navigationService = navigationService;
		}

		public override void Execute(object parameter) {

			_navigationService.Navigate(_workplace);
		}
	}
}
