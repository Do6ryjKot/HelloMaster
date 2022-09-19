using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.LoadCommands;
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace HelloWorker.Wpf.ViewModels.WorkplacesFolderView {
	
	public class WorkplacesFolderViewModel : ViewModelBase {

		private readonly IWorkplacesStore _workplacesStore;
		private readonly IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace> _addEditPopUpNavigationService;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;
		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly INavigationService<ActsFolderViewModel> _actsNavigationService;


		private readonly ICommand _loadWorkplacesCommand;

		public ObservableCollection<WorkplaceFolderViewModel> _workplaces;
		private CollectionViewSource _workplacesCollectionView;

		public ICollectionView Workplaces => _workplacesCollectionView.View;

		public ICommand AddWorkplaceCommand { get; }	
		
		public WorkplacesFolderViewModel(IWorkplacesStore workplacesStore, 
			IMessageService messageService, 
			ILogService logService,
			IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace> navigationService,
			ICurrentWorkplaceStore currentWorkplaceStore,
			INavigationService<ActsFolderViewModel> actsNavigationService) {

			_workplaces = new ObservableCollection<WorkplaceFolderViewModel>();
			_workplacesCollectionView = new CollectionViewSource();
			_workplacesCollectionView.Source = _workplaces;
			_workplacesCollectionView.SortDescriptions.Add(new SortDescription("WorkplaceLastActivity", ListSortDirection.Descending));

			_addEditPopUpNavigationService = navigationService;
			_workplacesStore = workplacesStore;
			_messageService = messageService;
			_logService = logService;
			_actsNavigationService = actsNavigationService;
			_currentWorkplaceStore = currentWorkplaceStore;

			_loadWorkplacesCommand = new LoadWorkplacesCommand(workplacesStore, messageService, logService);

			AddWorkplaceCommand = new OpenAddWorkplacePopUpCommand(navigationService);
			
			_workplacesStore.StateChanged += WorkplacesChanged;

			_loadWorkplacesCommand.Execute(null);
		}

		private void WorkplacesChanged() {

			_workplaces.Clear();

			foreach (Workplace workplace in _workplacesStore.Workplaces)
				_workplaces.Add(new WorkplaceFolderViewModel(workplace, 
					_addEditPopUpNavigationService, _workplacesStore, _messageService, _logService, _currentWorkplaceStore, _actsNavigationService));

			OnPropertyChanged(nameof(Workplaces));
		}
	}
}
