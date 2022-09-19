using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;
using System.Collections.ObjectModel;

namespace HelloWorker.Wpf.Stores.PositionsStore {

	public class PositionsStore : IPositionsStore {

		private readonly IWorkplacePositionDataService _dataService;
		
		public ObservableCollection<WorkplaceWork> Positions { get; private set; }

		public event Action StateChanged;

		public PositionsStore(IWorkplacePositionDataService dataService) {
			_dataService = dataService;
		}

		public void LoadFromAct(long actId) {

			Positions = new ObservableCollection<WorkplaceWork>(_dataService.GetFromAct(actId));
			OnStateChanged();
		}

		public void LoadFromWorkplace(long workplaceId) {

			Positions = new ObservableCollection<WorkplaceWork>(_dataService.GetFromWorkplace(workplaceId));
			OnStateChanged();
		}

		private void OnStateChanged() {
			StateChanged?.Invoke();
		}

		public void Add(WorkplaceWork position) {

			WorkplaceWork result = _dataService.Add(position);
			Positions.Add(result);
			OnStateChanged();
		}

		public void Delete(WorkplaceWork position) {

			_dataService.Delete(position);
			Positions.Remove(position);
			OnStateChanged();
		}

		public void Update(WorkplaceWork position) {

			_dataService.Update(position);
		}
	}
}
