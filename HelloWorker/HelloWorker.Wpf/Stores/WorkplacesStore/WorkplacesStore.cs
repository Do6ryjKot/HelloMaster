using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace HelloWorker.Wpf.Stores.WorkplacesStore {

	public class WorkplacesStore : IWorkplacesStore {

		private readonly IWorkplaceDataService _workplaceDataService;
		
		public ObservableCollection<Workplace> Workplaces { get; private set; }

		public event Action StateChanged;

		public WorkplacesStore(IWorkplaceDataService workplaceDataService) {
			_workplaceDataService = workplaceDataService;
		}

		public void Load() {
			Workplaces = new ObservableCollection<Workplace>(_workplaceDataService.GetAll());
			OnStateChanged();
		}

		private void OnStateChanged() {
			StateChanged?.Invoke();
		}

		public void Add(Workplace workplace) {

			DateTime now = DateTime.Now;

			workplace.CreationDate = now;
			workplace.LastActivity = now;

			Workplace result = _workplaceDataService.Add(workplace);

			Workplaces.Add(result);
			OnStateChanged();
		}

		public void Update(Workplace workplace) {

			DateTime now = DateTime.Now;

			// workplace.CreationDate = now;
			workplace.LastActivity = now;

			_workplaceDataService.Update(workplace);

			Load(); // OnStateChanged();
		}

		public void Delete(Workplace workplace) {
			
			if (_workplaceDataService.GetCount() <= 1) {
				throw new Exception("Должен существовать хотя бы 1 объект");
			}

			_workplaceDataService.Delete(workplace);

			Workplace workplaceToRemove = Workplaces.FirstOrDefault(wp => wp.Id == workplace.Id);

			if (workplaceToRemove != null) {

				Workplaces.Remove(workplaceToRemove);
			}

			OnStateChanged();
		}
	}
}
