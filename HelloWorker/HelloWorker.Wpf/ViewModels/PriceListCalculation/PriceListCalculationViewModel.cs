using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.LastActivity;
using HelloWorker.Wpf.Commands.LoadCommands;
using HelloWorker.Wpf.Commands.PopUp;
using HelloWorker.Wpf.Commands.PriceListCalculation;
using HelloWorker.Wpf.Commands.WorkplaceCommands;
using HelloWorker.Wpf.Services.Export;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.Stores.PriceListStore;
using HelloWorker.Wpf.Stores.WorkCategoriesStore;
using HelloWorker.Wpf.Stores.WorkGroupsStore;
using HelloWorker.Wpf.Stores.WorkplacesStore;
using HelloWorker.Wpf.ViewModels.Base;
using HelloWorker.Wpf.ViewModels.PriceListCalculation.PopUp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace HelloWorker.Wpf.ViewModels.PriceListCalculation {
	
	/// <summary>
	///	Модель представления подсчета прайс-листа
	///	
	/// Deprecated
	/// </summary>
	public class PriceListCalculationViewModel : ViewModelBase {

		private readonly IPriceListStore _priceListStore;
		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;
		private readonly IWorkGroupsStore _workGroupsStore;
		private readonly IWorkplacesStore _workplacesStore;
		private readonly IWorkCategoriesStore _workCategoriesStore;

		private readonly ICommand _loadPriceListCommand;
		private readonly ICommand _loadWorkGroupsCommand;
		private readonly ICommand _loadWorkplacesCommand;
		private readonly ICommand _loadWorkCategoriesCommand;

		public string WorkplaceName => _currentWorkplaceStore.CurrentWorkplace.Name;
		public string WorkplaceAddress => _currentWorkplaceStore.CurrentWorkplace.Address;

		public ObservableCollection<Workplace> Workplaces => _workplacesStore.Workplaces;

		public long CurrentWorkplaceId {

			get => _currentWorkplaceStore.CurrentWorkplace.Id;

			set {

				_currentWorkplaceStore.Load(value);
				OnPropertyChanged(nameof(CurrentWorkplaceId));
			}
		}

		private ObservableCollection<PriceListPositionViewModel> _priceList;
		private ObservableCollection<WorkplacePositionViewModel> _workplacePositions;
		private CollectionViewSource _priceListViewSource;
		private CollectionViewSource _workplacePositionsViewSource;

		public ICollectionView PriceList => _priceListViewSource.View;
		public ICollectionView WorkplacePositions => _workplacePositionsViewSource.View;

		/// <summary>
		/// Категории работ в фильтре
		/// </summary>
		public IEnumerable<WorkCategory> WorkCategories => _workCategoriesStore.Items;

		/// <summary>
		/// Фильтр прайс листа по категории работ
		/// </summary>
		public WorkCategory WorkCategoryFilter {

			get => _priceListStore.WorkCategoryFilter;

			set {

				_priceListStore.WorkCategoryFilter = value;
				_loadPriceListCommand.Execute(null);

				OnPropertyChanged(nameof(WorkCategoryFilter));
			}
		}

		/// <summary>
		/// Группы работ в фильтре
		/// </summary>
		public IEnumerable<WorkGroup> WorkGroups => _workGroupsStore.Items;

		/// <summary>
		/// Фильтр прайс листа по группам
		/// </summary>
		public WorkGroup PriceListWorkGroupFilter {

			get => _priceListStore.WorkGroupFilter;

			set {

				_priceListStore.WorkGroupFilter = value;
				_loadPriceListCommand.Execute(null);

				OnPropertyChanged(nameof(PriceListWorkGroupFilter));
			}
		}

		/// <summary>
		/// Поиск в прайс листе
		/// </summary>
		public string PriceListSearchFilter {

			get => _priceListStore.SearchFilter;

			set {

				_priceListStore.SearchFilter = value;
				_loadPriceListCommand.Execute(null);

				OnPropertyChanged(nameof(PriceListSearchFilter));
			}
		}

		public ICommand AddToWorkplacePositionsCommand { get; }
		public ICommand RefreshWorkplacePositionsCommand { get; }
		public ICommand AddWorkplaceCommand { get; }
		public ICommand EditWorkplaceCommand { get; }
		public ICommand DeleteWorkplaceCommand { get; }
		public ICommand ExportCompanyCostWorkplacePositionsCommand { get; }
		public ICommand ExportMasterCostWorkplacePositionsCommand { get; }

		public PriceListCalculationViewModel(IPriceListStore priceListStore,
			ICurrentWorkplaceStore currentWorkplaceStore,
			IMessageService messageService,
			ILogService logService,
			IWorkGroupsStore workGroupsStore,
			IWorkplacesStore workplacesStore,
			IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace> popUpNavigationService,
			ILastActiveWorkplaceService lastActiveWorkplaceService,
			IWorkplaceWorkXlsxExportService exportService, 
			IWorkCategoriesStore workCategoriesStore) {

			_priceList = new ObservableCollection<PriceListPositionViewModel>();
			_workplacePositions = new ObservableCollection<WorkplacePositionViewModel>();

			_priceListViewSource = new CollectionViewSource();
			_priceListViewSource.Source = _priceList;
			_priceListViewSource.SortDescriptions.Add(new SortDescription("SortOrder", ListSortDirection.Ascending));

			_workplacePositionsViewSource = new CollectionViewSource();
			_workplacePositionsViewSource.Source = _workplacePositions;
			_workplacePositionsViewSource.SortDescriptions.Add(new SortDescription("SortOrder", ListSortDirection.Ascending));

			_priceListStore = priceListStore;
			_currentWorkplaceStore = currentWorkplaceStore;
			_messageService = messageService;
			_logService = logService;
			_workGroupsStore = workGroupsStore;
			_workplacesStore = workplacesStore;
			_workCategoriesStore = workCategoriesStore;

			_priceListStore.StateChanged += PriceListChanged;
			_currentWorkplaceStore.StateChanged += WorkplaceChanged;
			_workplacesStore.StateChanged += WorkplacesChanged;

			// _loadPriceListCommand = new LoadPriceListCommand(this, priceListStore, messageService, logService);
			_loadWorkGroupsCommand = new LoadWorkGroupsCommand(workGroupsStore, messageService, logService);
			_loadWorkplacesCommand = new LoadWorkplacesCommand(workplacesStore, messageService, logService);
			_loadWorkCategoriesCommand = new LoadWorkCategoriesCommand(workCategoriesStore, messageService, logService);

			AddToWorkplacePositionsCommand = new AddToWorkplacePositionsCommand(messageService, currentWorkplaceStore);
			RefreshWorkplacePositionsCommand = new RefreshWorkplacePositionsCommand(currentWorkplaceStore, messageService);
			AddWorkplaceCommand = new OpenAddWorkplacePopUpCommand(popUpNavigationService);
			EditWorkplaceCommand = new OpenEditWorkplacePopUpCommand(currentWorkplaceStore, popUpNavigationService);
			DeleteWorkplaceCommand = new DeleteWorkplaceCommand(workplacesStore,
				currentWorkplaceStore, lastActiveWorkplaceService, messageService, logService);
			ExportCompanyCostWorkplacePositionsCommand = new ExportCompanyCostWorkplacePositionsCommand(exportService,
				currentWorkplaceStore, messageService, logService);
			ExportMasterCostWorkplacePositionsCommand = new ExportMasterCostWorkplacePositionsCommand(exportService,
				currentWorkplaceStore, messageService, logService);

			_loadPriceListCommand.Execute(null);
			_loadWorkGroupsCommand.Execute(null);
			_loadWorkplacesCommand.Execute(null);
			_loadWorkCategoriesCommand.Execute(null);
		}

		/// <summary>
		/// При изменении списка объектов
		/// </summary>
		private void WorkplacesChanged() {

			OnPropertyChanged(nameof(Workplaces));
			OnPropertyChanged(nameof(CurrentWorkplaceId));
			OnPropertyChanged(nameof(WorkplaceName));
			OnPropertyChanged(nameof(WorkplaceAddress));
		}

		/// <summary>
		///	При изменении списка прайс-листа
		/// </summary>
		private void PriceListChanged() {

			_priceList.Clear();

			foreach (Work work in _priceListStore.Works)
				_priceList.Add(new PriceListPositionViewModel(work));

			OnPropertyChanged(nameof(PriceList));
		}

		/// <summary>
		/// При выгрузки данных объекта
		/// </summary>
		private void WorkplaceChanged() {

			_workplacePositions.Clear();

			/*
			foreach (WorkplaceWork work in _currentWorkplaceStore.CurrentWorkplace.WorkplaceWorks)
				_workplacePositions.Add(new WorkplacePositionViewModel(work, _currentWorkplaceStore, _messageService, _logService));
			*/
			OnPropertyChanged(nameof(WorkplacePositions));
			OnPropertyChanged(nameof(WorkplaceName));
			OnPropertyChanged(nameof(WorkplaceAddress));
			OnPropertyChanged(nameof(CurrentWorkplaceId));
		}

		public override void Dispose() {

			_priceListStore.StateChanged -= PriceListChanged;
			_currentWorkplaceStore.StateChanged -= WorkplaceChanged;
			_workplacesStore.StateChanged -= WorkplacesChanged;

			base.Dispose();
		}
	}
}
