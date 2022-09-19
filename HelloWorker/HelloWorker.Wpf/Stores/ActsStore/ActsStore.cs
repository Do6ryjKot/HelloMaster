using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace HelloWorker.Wpf.Stores.ActsStore {

	public class ActsStore : IActsStore {

		private readonly IActDataService _actDataService;

		public ObservableCollection<Act> Acts { get; private set; }

		public event Action StateChanged;

		public ActsStore(IActDataService actDataService) {
			_actDataService = actDataService;
		}

		public void Load(long workplaceId) {

			Acts = new ObservableCollection<Act>() {
				new Act() { Id = -1, Name = "Все позиции объекта", NumOrder = -1, WorkplaceId = workplaceId } };

			foreach (Act act in _actDataService.GetByWorkplaceId(workplaceId)) {

				Acts.Add(act);
			}

			StateChanged();
		}

		private void OnStateChanged() {

			StateChanged?.Invoke();
		}

		public void Add(Act act) {

			act.NumOrder = _actDataService.GetLastActNum(act.WorkplaceId) + 1;
			act.CreationDate = DateTime.Now;

			Act result = _actDataService.Add(act);

			Acts.Add(result);

			OnStateChanged();
		}

		public void Update(Act act) {

			_actDataService.Update(act);

			Load(act.WorkplaceId);
		}

		public void Delete(Act act) {

			_actDataService.Delete(act);

			Act actToRemove= Acts.FirstOrDefault(a => a.Id == act.Id);
			
			if (actToRemove != null) {

				Acts.Remove(actToRemove);
			}

			OnStateChanged();
		}
	}
}
