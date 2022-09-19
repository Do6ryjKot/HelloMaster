using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.LastActivity;
using HelloWorker.Wpf.Commands.ActContentView;
using HelloWorker.Wpf.Commands.LoadCommands;
using HelloWorker.Wpf.Commands.PopUp;
using HelloWorker.Wpf.Commands.PriceListCalculation;
using HelloWorker.Wpf.Commands.WorkplaceCommands;
using HelloWorker.Wpf.Commands.WorkplacesFolderView;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.Services.Notifiers.Sums;
using HelloWorker.Wpf.Stores.ActsStore;
using HelloWorker.Wpf.Stores.CurrentActStore;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.Stores.PositionsStore;
using HelloWorker.Wpf.Stores.PriceListStore;
using HelloWorker.Wpf.Stores.WorkCategoriesStore;
using HelloWorker.Wpf.Stores.WorkGroupsStore;
using HelloWorker.Wpf.Stores.WorkplacesStore;
using HelloWorker.Wpf.ViewModels.ActsFolderView;
using HelloWorker.Wpf.ViewModels.Base;
using HelloWorker.Wpf.ViewModels.ExportPositionsPopUpView;
using HelloWorker.Wpf.ViewModels.PriceListCalculation;
using HelloWorker.Wpf.ViewModels.PriceListCalculation.PopUp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace HelloWorker.Wpf.ViewModels.ActContentView {
	
	/// <summary>
	///	Модель представления содержимого акта объекта
	/// </summary>
	public class ActContentViewModel : ViewModelBase {

		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly ICurrentActStore _currentActStore;
		private readonly IPositionsStore _positionsStore;
		private readonly IPriceListStore _priceListStore;
		private readonly IActsStore _actsStore;
		private readonly IWorkplacesStore _workplacesStore;

		private readonly IWorkGroupsStore _workGroupsStore;
		private readonly IWorkCategoriesStore _workCategoriesStore;

		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		private readonly ISumChangingNotifierService _sumChangingNotifierService;

		private readonly ICommand _loadPositionsCommand;
		private readonly ICommand _loadPriceListCommand;
		private readonly ICommand _loadWorkGroupsCommand;
		private readonly ICommand _loadWorkCategoriesCommand;
		private readonly ICommand _loadWorkplacesCommand;
		private readonly ICommand _loadActsCommad;

		/// <summary>
		/// Объект, с которым производится работа
		/// </summary>
		public Workplace CurrentWorkplace => _currentWorkplaceStore.CurrentWorkplace;

		/// <summary>
		/// Адрес объекта, с которым ведется работа
		/// </summary>
		public string WorkplaceAddress => _currentWorkplaceStore.CurrentWorkplace.Address;

		/// <summary>
		/// Позиции
		/// </summary>
		private readonly ObservableCollection<WorkplacePositionViewModel> _positions;
		private readonly CollectionViewSource _positionsCollectionView;
		public ICollectionView Positions => _positionsCollectionView.View;

		/// <summary>
		/// Прайс-лист
		/// </summary>
		private readonly ObservableCollection<PriceListPositionViewModel> _priceList;
		private readonly CollectionViewSource _priceListCollectionView;
		public ICollectionView PriceList => _priceListCollectionView.View;

		/// <summary>
		/// Выполняется ли редактирование содержимого
		/// </summary>
		private bool _isEditing = false;
		public bool IsEditing {

			get =>_isEditing; 

			set { 

				_isEditing = value;
				OnPropertyChanged(nameof(IsEditing));
			}
		}

		/// <summary>
		/// Поисковая строка
		/// </summary>
		public string PriceListSearchFilter {

			get => _priceListStore.SearchFilter;

			set {

				_priceListStore.SearchFilter = value;
				_loadPriceListCommand.Execute(null);

				OnPropertyChanged(nameof(PriceListSearchFilter));
			}
		}


		#region	Фильтр по группам работ

		/// <summary>
		/// Набор групп работ для фильтра
		/// </summary>
		public IEnumerable<WorkGroup> WorkGroups => _workGroupsStore.Items;

		/// <summary>
		/// Выбранная группа для фильтра
		/// </summary>
		public WorkGroup PriceListWorkGroupFilter {

			get => _priceListStore.WorkGroupFilter;

			set {

				_priceListStore.WorkGroupFilter = value;
				_loadPriceListCommand.Execute(null);

				OnPropertyChanged(nameof(PriceListWorkGroupFilter));
			}
		}

		#endregion

		#region Фильтр по категории работ

		/// <summary>
		/// Набор категорий работ для фильтра
		/// </summary>
		public IEnumerable<WorkCategory> WorkCategories => _workCategoriesStore.Items;

		/// <summary>
		/// Выбранная категория работы для фильтра
		/// </summary>
		public WorkCategory PriceListWorkCategoryFilter {

			get => _priceListStore.WorkCategoryFilter;

			set {

				_priceListStore.WorkCategoryFilter = value;
				_loadPriceListCommand.Execute(null);

				OnPropertyChanged(nameof(PriceListWorkCategoryFilter));
			}
		}

		#endregion


		#region Переключение актов

		/// <summary>
		/// Набор актов
		/// </summary>
		public IEnumerable<Act> Acts => _actsStore.Acts;

		/// <summary>
		/// Ид выбранного акта
		/// </summary>
		public long CurrentActId {

			// Нынешний акт может быть null только в случае если был выбран вариант "Все позиции объекта"
			// -1 - ид фиктивного акта "Все позиции объекта"
			get => _currentActStore.CurrentAct?.Id ?? -1; 

			set {

				_currentActStore.Load(value);
			}
		}

		#endregion

		#region Переключение объектов

		public IEnumerable<Workplace> Workplaces => _workplacesStore.Workplaces;

		public long CurrentWorkplaceId {

			get => _currentWorkplaceStore.CurrentWorkplace.Id;

			set {

				_currentWorkplaceStore.Load(value);
			}
		}

		#endregion


		#region Панель сумм

		/// <summary>
		/// Развернута ли панель сумм
		/// </summary>
		private bool _areSumsShown;
		public bool AreSumsShown {

			get => _areSumsShown; 

			set { 
				_areSumsShown = value;
				OnPropertyChanged(nameof(AreSumsShown));
			}
		}

		/// <summary>
		/// Команда смены состояния панели сумм
		/// </summary>
		public ICommand TurnSumsShowModeCommand { get; }

		/// <summary>
		/// С актом ли производится работа
		/// </summary>
		public bool IsActShown => _currentActStore.CurrentAct != null;

		/// <summary>
		/// Итого по ценам предприятия
		/// </summary>
		public decimal Cost => 
			(IsActShown ? _currentActStore.CurrentAct.Cost : _currentWorkplaceStore.CurrentWorkplace.Cost) ?? 0;

		/// <summary>
		/// Итого по ценам мастера
		/// </summary>
		public decimal MasterCost =>
			(IsActShown ? _currentActStore.CurrentAct.MasterCost : _currentWorkplaceStore.CurrentWorkplace.MasterCost) ?? 0;

		#endregion

		/// <summary>
		/// Команда перехода на страницу актов
		/// </summary>
		public ICommand ActsNavigationCommand { get; }

		/// <summary>
		/// Команда переключения режима редактирования
		/// </summary>
		public ICommand TurnEditModeCommand { get; }

		/// <summary>
		/// Команда добавления позиции
		/// </summary>
		public ICommand AddPositionCommand { get; }

		/// <summary>
		/// Команда добавления объекта
		/// </summary>
		public ICommand AddWorkplaceCommand { get; }

		/// <summary>
		/// Команда изменения объекта
		/// </summary>
		public ICommand EditWorkplaceCommand { get; }

		/// <summary>
		/// Команда удаления объекта
		/// </summary>
		public ICommand DeleteWorkplaceCommand { get; }

		/// <summary>
		/// Команда открытия 
		/// </summary>
		public ICommand OpenExportPositionsPopUpCommand { get; }

		/// <summary>
		/// Команда обновления позиций объекта
		/// </summary>
		public ICommand RefreshWorkplacePositionsCommand { get; }

		public ActContentViewModel(ICurrentWorkplaceStore currentWorkplaceStore,
			ICurrentActStore currentActStore,
			IPriceListStore priceListStore,
			IWorkGroupsStore workGroupsStore,
			IWorkCategoriesStore workCategoriesStore,
			IActsStore actsStore,
			IWorkplacesStore workplacesStore,
			INavigationService<ActsFolderViewModel> workplaceContentNavigationService,
			IMessageService messageService,
			ILogService logService, 
			IPositionsStore positionsStore,
			IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace> workplaceAddEditNavigationService,
			ILastActiveWorkplaceService lastActiveWorkplaceService,
			IPopUpNavigationService<ExportWorkplacePositionsPopUpViewModel> exportPositionsNavigationService,
			ISumChangingNotifierService sumChangingNotifierService) {

			_positions = new ObservableCollection<WorkplacePositionViewModel>();
			_positionsCollectionView = new CollectionViewSource();
			_positionsCollectionView.Source = _positions;
			_positionsCollectionView.SortDescriptions.Add(new SortDescription("SortOrder", ListSortDirection.Ascending));

			_priceList = new ObservableCollection<PriceListPositionViewModel>();
			_priceListCollectionView = new CollectionViewSource();
			_priceListCollectionView.Source = _priceList;
			_priceListCollectionView.SortDescriptions.Add(new SortDescription("SortOrder", ListSortDirection.Ascending));

			_currentWorkplaceStore = currentWorkplaceStore;
			_currentActStore = currentActStore;
			_positionsStore = positionsStore;
			_priceListStore = priceListStore;
			_actsStore = actsStore;
			_workplacesStore = workplacesStore;

			_workGroupsStore = workGroupsStore;
			_workCategoriesStore = workCategoriesStore;

			_messageService = messageService;
			_logService = logService;

			_sumChangingNotifierService = sumChangingNotifierService;

			ActsNavigationCommand = new OpenWorkplaceContentCommand(currentWorkplaceStore,
				workplaceContentNavigationService, messageService, logService);

			TurnEditModeCommand = new TurnEditModeCommand(this);
			TurnSumsShowModeCommand = new TurnSumsShowModeCommand(this);

			AddPositionCommand = new AddPositionCommand(currentActStore, currentWorkplaceStore, messageService, logService, positionsStore);
			AddWorkplaceCommand = new OpenAddWorkplacePopUpCommand(workplaceAddEditNavigationService);
			EditWorkplaceCommand = new OpenEditWorkplacePopUpCommand(currentWorkplaceStore, workplaceAddEditNavigationService);
			DeleteWorkplaceCommand = new DeleteWorkplaceCommand(workplacesStore, currentWorkplaceStore, lastActiveWorkplaceService, messageService, logService);
			OpenExportPositionsPopUpCommand = new PopUpNavigationCommand<ExportWorkplacePositionsPopUpViewModel>(exportPositionsNavigationService);
			RefreshWorkplacePositionsCommand = new RefreshWorkplacePositionsCommand(currentWorkplaceStore, messageService);

			_loadPositionsCommand = new LoadPositionsCommand(currentActStore, currentWorkplaceStore, positionsStore, messageService, logService);
			_loadPriceListCommand = new LoadPriceListCommand(priceListStore, messageService, logService);
			_loadWorkGroupsCommand = new LoadWorkGroupsCommand(workGroupsStore, messageService, logService);
			_loadWorkCategoriesCommand = new LoadWorkCategoriesCommand(workCategoriesStore, messageService, logService);
			_loadWorkplacesCommand = new LoadWorkplacesCommand(workplacesStore, messageService, logService);
			_loadActsCommad = new LoadActsCommand(currentWorkplaceStore, actsStore, messageService, logService);

			_currentWorkplaceStore.StateChanged += CurrentWorkplaceChanged;
			_positionsStore.StateChanged += PositionsChanged;
			_priceListStore.StateChanged += PriceListChanged;
			_workplacesStore.StateChanged += WorkplacesChanged;
			_actsStore.StateChanged += ActsChanged;
			_currentActStore.StateChanged += CurrentActChanged;
			_sumChangingNotifierService.SumChanged += SumsChanged;

			_loadPositionsCommand.Execute(null);
			_loadPriceListCommand.Execute(null);
			_loadWorkGroupsCommand.Execute(null);
			_loadWorkCategoriesCommand.Execute(null);
			_loadWorkplacesCommand.Execute(null);
		}

		private void SumsChanged() {

			_currentActStore.Refresh();
			_currentWorkplaceStore.Refresh();

			OnPropertyChanged(nameof(Cost));
			OnPropertyChanged(nameof(MasterCost));
		}

		private void CurrentActChanged() {

			_loadPositionsCommand.Execute(null);
			OnPropertyChanged(nameof(CurrentActId));
			OnPropertyChanged(nameof(IsActShown));
			OnPropertyChanged(nameof(Cost));
			OnPropertyChanged(nameof(MasterCost));
		}

		private void ActsChanged() {

			OnPropertyChanged(nameof(Acts));
		}

		private void WorkplacesChanged() {

			OnPropertyChanged(nameof(Workplaces));
			OnPropertyChanged(nameof(CurrentWorkplaceId));
			OnPropertyChanged(nameof(WorkplaceAddress));
		}

		private void PriceListChanged() {

			_priceList.Clear();

			foreach (Work work in _priceListStore.Works)
				_priceList.Add(new PriceListPositionViewModel(work));

			OnPropertyChanged(nameof(PriceList));
		}

		private void PositionsChanged() {

			_positions.Clear();

			foreach (WorkplaceWork position in _positionsStore.Positions)
				_positions.Add(new WorkplacePositionViewModel(position, _positionsStore, _messageService, _logService, _sumChangingNotifierService));

			OnPropertyChanged(nameof(Positions));
		}

		private void CurrentWorkplaceChanged() {

			OnPropertyChanged(nameof(CurrentWorkplace));
			OnPropertyChanged(nameof(CurrentWorkplaceId));
			OnPropertyChanged(nameof(WorkplaceAddress));

			_loadActsCommad.Execute(null);
			CurrentActId = -1;
			OnPropertyChanged(nameof(Acts));
			OnPropertyChanged(nameof(IsActShown));
			OnPropertyChanged(nameof(Cost));
			OnPropertyChanged(nameof(MasterCost));
		}

		public override void Dispose() {

			_currentWorkplaceStore.StateChanged -= CurrentWorkplaceChanged;
			_positionsStore.StateChanged -= PositionsChanged;
			_priceListStore.StateChanged -= PriceListChanged;
			_workplacesStore.StateChanged -= WorkplacesChanged;
			_actsStore.StateChanged -= ActsChanged;
			_currentActStore.StateChanged -= CurrentActChanged;
			_sumChangingNotifierService.SumChanged -= SumsChanged;

			base.Dispose();
		}
	}
}
