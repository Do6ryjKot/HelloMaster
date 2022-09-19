using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.WorkplaceCommands;
using HelloWorker.Wpf.Commands.WorkplacesFolderView;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.Stores.WorkplacesStore;
using HelloWorker.Wpf.ViewModels.ActsFolderView;
using HelloWorker.Wpf.ViewModels.Base;
using HelloWorker.Wpf.ViewModels.PriceListCalculation.PopUp;
using System;
using System.Windows.Input;

namespace HelloWorker.Wpf.ViewModels.WorkplacesFolderView {

	/// <summary>
	/// Модель представления ячейки в папочном представлении 
	/// </summary>
	public class WorkplaceFolderViewModel : ViewModelBase {

		public Workplace Workplace { get; set; }

		public string WorkplaceName => Workplace.Name;
		public string WorkplaceAddress => Workplace.Address;
		public DateTime WorkplaceLastActivity => Workplace.LastActivity;

		public ICommand OpenEditWorkplacePopUpCommand { get; }
		public ICommand DeleteWorkplaceCommand { get; }

		public ICommand OpenWorkplaceContentCommand { get; }

		public WorkplaceFolderViewModel(Workplace workplace, 
			IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace> navigationService,
			IWorkplacesStore workplacesStore,
			IMessageService messageService,
			ILogService logService,
			ICurrentWorkplaceStore currentWorkplaceStore,
			INavigationService<ActsFolderViewModel> actsNavigationService) {

			Workplace = workplace;

			OpenEditWorkplacePopUpCommand = new OpenEditSelectedWorkplacePopUpCommand(Workplace, navigationService);
			DeleteWorkplaceCommand = new DeleteSelectedWorkplaceCommand(Workplace, workplacesStore, messageService, logService);

			OpenWorkplaceContentCommand = new OpenWorkplaceContentCommand(currentWorkplaceStore,
				actsNavigationService, messageService, logService);
		}
	}
}