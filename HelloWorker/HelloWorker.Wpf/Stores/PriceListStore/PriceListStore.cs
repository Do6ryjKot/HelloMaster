using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;
using System.Collections.ObjectModel;

namespace HelloWorker.Wpf.Stores.PriceListStore {

	public class PriceListStore : IPriceListStore {

		private readonly IWorkDataService _workDataService;

		public ObservableCollection<Work> Works { get; private set; }

		public string SearchFilter {

			get => _workDataService.SearchFilter;

			set => _workDataService.SearchFilter = value;
		}

		public WorkGroup WorkGroupFilter {

			get => _workDataService.WorkGroupFilter;

			set => _workDataService.WorkGroupFilter = value;
		}
		public WorkCategory WorkCategoryFilter {

			get => _workDataService.WorkCategoryFilter;

			set => _workDataService.WorkCategoryFilter = value;
		}

		public event Action StateChanged;

		public PriceListStore(IWorkDataService workDataService) {

			_workDataService = workDataService;
		}

		public void Load() {

			Works = new ObservableCollection<Work>(_workDataService.GetAll());
			OnStateChanged();
		}
		public void OnStateChanged() {

			StateChanged?.Invoke();
		}
	}
}
