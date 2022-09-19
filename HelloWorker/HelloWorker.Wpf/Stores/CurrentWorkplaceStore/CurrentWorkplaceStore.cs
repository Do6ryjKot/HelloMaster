using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using HelloWorker.Domain.Services.LastActivity;
using System;

namespace HelloWorker.Wpf.Stores.CurrentWorkplaceStore {

	public class CurrentWorkplaceStore : ICurrentWorkplaceStore {

		private readonly IWorkplaceDataService _workplaceDataService;
		// private readonly IWorkplacePositionDataService _workplacePositionDataService;
		private readonly ILastActiveWorkplaceService _lastActiveWorkplaceService;
		
		public Workplace CurrentWorkplace { get; private set; }		

		public event Action StateChanged;

		public CurrentWorkplaceStore(IWorkplaceDataService workplaceDataService, 
			// IWorkplacePositionDataService workplacePositionDataService, 
			ILastActiveWorkplaceService lastActiveWorkplaceService) {

			_workplaceDataService = workplaceDataService;
			// _workplacePositionDataService = workplacePositionDataService;
			_lastActiveWorkplaceService = lastActiveWorkplaceService;
		}

		public void Load(long id) {

			CurrentWorkplace = _workplaceDataService.Get(id);
			_lastActiveWorkplaceService.UpdateLastActivity(CurrentWorkplace);
			OnStateChanged();
		}

		private void OnStateChanged() {
			StateChanged?.Invoke();
		}

		public void Refresh() {

			if (CurrentWorkplace == null)
				return;

			CurrentWorkplace = _workplaceDataService.Get(CurrentWorkplace.Id);
		}
		/*
public void AddPosition(WorkplaceWork workplaceWork) {
	<!--
	WorkplaceWork result = _workplacePositionDataService.Add(new WorkplaceWork() {

		WorkId = work.Id,
		WorkplaceId = CurrentWorkplace.Id
	});-->

	workplaceWork.WorkplaceId = CurrentWorkplace.Id;

	// CurrentWorkplace.WorkplaceWorks.Add(workplaceWork);
	_lastActiveWorkplaceService.UpdateLastActivity(CurrentWorkplace);
	StateChanged();
}

public void UpdatePosition(WorkplaceWork workplaceWork) {

	_workplacePositionDataService.Update(workplaceWork);
	_lastActiveWorkplaceService.UpdateLastActivity(CurrentWorkplace);
}

public void DeletePosition(WorkplaceWork workplaceWork) {

	_workplacePositionDataService.Delete(workplaceWork);

	_lastActiveWorkplaceService.UpdateLastActivity(CurrentWorkplace);

	CurrentWorkplace.WorkplaceWorks.Remove(workplaceWork);
	StateChanged();
}
*/
	}
}
