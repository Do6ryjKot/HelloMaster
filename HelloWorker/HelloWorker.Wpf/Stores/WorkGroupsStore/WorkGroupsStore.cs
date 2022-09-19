using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System.Collections.ObjectModel;

namespace HelloWorker.Wpf.Stores.WorkGroupsStore {

	public class WorkGroupsStore : IWorkGroupsStore {

		private readonly IWorkGroupDataService _workGroupDataService;
		
		public ObservableCollection<WorkGroup> Items { get; private set; }

		public WorkGroupsStore(IWorkGroupDataService workGroupDataService) {
			_workGroupDataService = workGroupDataService;
		}

		public void Load() {

			Items = new ObservableCollection<WorkGroup>();
			Items.Add(new WorkGroup() { Id = -1, Name = "Все группы" });

			foreach (WorkGroup group in _workGroupDataService.GetAll())
				Items.Add(group);
		}
	}
}
