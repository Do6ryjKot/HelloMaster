using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;

namespace HelloWorker.Wpf.Stores.CurrentActStore {

	public class CurrentActStore : ICurrentActStore {

		private readonly IActDataService _actDataService;
		
		public Act CurrentAct { get; private set; }

		public event Action StateChanged;

		public CurrentActStore(IActDataService actDataService) {
			_actDataService = actDataService;
		}

		public void Load(long actId) {

			if (actId == -1) {

				CurrentAct = null;

			} else { 

				CurrentAct = _actDataService.Get(actId);
			}

			OnStateChanged();
		}

		private void OnStateChanged() {
			StateChanged?.Invoke();
		}

		public void Refresh() {

			if (CurrentAct == null)
				return;

			CurrentAct = _actDataService.Get(CurrentAct.Id);
		}
	}
}
