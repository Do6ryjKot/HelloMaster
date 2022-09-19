using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.ViewModels.PriceListCalculation.PopUp;

namespace HelloWorker.Wpf.Commands.PriceListCalculation {

	/// <summary>
	///	Открыть поп ап изменения объекта
	/// </summary>
	public class OpenEditWorkplacePopUpCommand : CommandBase {

		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace> _navigationService;

		public OpenEditWorkplacePopUpCommand(ICurrentWorkplaceStore currentWorkplaceStore, 
			IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace> navigationService) {

			_currentWorkplaceStore = currentWorkplaceStore;
			_navigationService = navigationService;
		}

		public override void Execute(object parameter) {

			_navigationService.Navigate(_currentWorkplaceStore.CurrentWorkplace);
		}
	}
}
