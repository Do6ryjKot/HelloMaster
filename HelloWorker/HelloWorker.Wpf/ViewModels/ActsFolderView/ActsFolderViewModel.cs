using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.ActsCommands;
using HelloWorker.Wpf.Commands.LoadCommands;
using HelloWorker.Wpf.Commands.Navigation;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.Services.Notifiers.Sums;
using HelloWorker.Wpf.Stores.ActsStore;
using HelloWorker.Wpf.Stores.CurrentActStore;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.ViewModels.ActContentView;
using HelloWorker.Wpf.ViewModels.ActsFolderView.PopUp;
using HelloWorker.Wpf.ViewModels.Base;
using HelloWorker.Wpf.ViewModels.WorkplacesFolderView;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace HelloWorker.Wpf.ViewModels.ActsFolderView {
	
	/// <summary>
	/// Модель представления папочного вида актов объекта
	/// </summary>
	public class ActsFolderViewModel : ViewModelBase {

		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly IActsStore _actStore;
		private readonly IParametrizedPopUpNavigationService<ActAddEditPopUpViewModel, Act> _popUpNavigationService;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;
		private readonly ICurrentActStore _currentActStore;
		private readonly INavigationService<ActContentViewModel> _actContentNavigationService;

		private readonly ISumChangingNotifierService _sumChangingNotifierService;

		private readonly ObservableCollection<ActFolderViewModel> _acts;
		private readonly CollectionViewSource _actsCollectionView;

		private readonly ICommand _loadActsCommand;

		public ICollectionView Acts => _actsCollectionView.View;

		public string WorkplaceName => _currentWorkplaceStore.CurrentWorkplace.Name;

		public ICommand AddActCommand { get; }
		public ICommand WorkplacesNavigationCommand { get; }

		public ActsFolderViewModel(ICurrentWorkplaceStore currentWorkplaceStore,
			INavigationService<WorkplacesFolderViewModel> workplacesNavigationService,
			IActsStore actStore,
			IMessageService messageService,
			ILogService logService,
			IParametrizedPopUpNavigationService<ActAddEditPopUpViewModel, Act> popUpNavigationService, 
			ICurrentActStore currentActStore,
			ISumChangingNotifierService sumChangingNotifierService,
			INavigationService<ActContentViewModel> actContentNavigationService) {

			_acts = new ObservableCollection<ActFolderViewModel>();
			_popUpNavigationService = popUpNavigationService;
			_messageService = messageService;
			_logService = logService;
			_currentActStore = currentActStore;
			_actContentNavigationService = actContentNavigationService;

			_actsCollectionView = new CollectionViewSource();
			_actsCollectionView.Source = _acts;
			_actsCollectionView.SortDescriptions.Add(new SortDescription("ActNumOrder", ListSortDirection.Ascending));

			_currentWorkplaceStore = currentWorkplaceStore;
			_actStore = actStore;

			_sumChangingNotifierService = sumChangingNotifierService;

			_loadActsCommand = new LoadActsCommand(currentWorkplaceStore, actStore, messageService, logService);

			_currentWorkplaceStore.StateChanged += WorkplaceChanged;
			_actStore.StateChanged += ActsChanged;
			_sumChangingNotifierService.SumChanged += SumChanged;

			WorkplacesNavigationCommand = new NavigationCommand<WorkplacesFolderViewModel>(workplacesNavigationService);
			AddActCommand = new OpenAddActPopUpCommand(popUpNavigationService);

			_loadActsCommand.Execute(null);
		}

		private void SumChanged() {

			_currentWorkplaceStore.Refresh();
		}

		private void ActsChanged() {

			_acts.Clear();

			foreach (Act act in _actStore.Acts)
				_acts.Add(new ActFolderViewModel(act, 
					_popUpNavigationService, 
					_actStore, 
					_messageService, 
					_logService, 
					_currentActStore, 
					_sumChangingNotifierService, 
					_actContentNavigationService));

			OnPropertyChanged(nameof(Acts));
		}

		private void WorkplaceChanged() {

			OnPropertyChanged(nameof(WorkplaceName));
			OnPropertyChanged(nameof(Acts));
		}

		public override void Dispose() {

			_currentWorkplaceStore.StateChanged -= WorkplaceChanged;
			_actStore.StateChanged -= ActsChanged;
			_sumChangingNotifierService.SumChanged -= SumChanged;

			base.Dispose();
		}
	}
}
