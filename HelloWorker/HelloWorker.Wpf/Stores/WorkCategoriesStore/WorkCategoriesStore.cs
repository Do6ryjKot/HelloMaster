using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System.Collections.ObjectModel;

namespace HelloWorker.Wpf.Stores.WorkCategoriesStore {

	public class WorkCategoriesStore : IWorkCategoriesStore {

		private readonly IWorkCategoryDataService _workCategoryDataService;

		public WorkCategoriesStore(IWorkCategoryDataService workCategoryDataService) {
			_workCategoryDataService = workCategoryDataService;
		}

		public ObservableCollection<WorkCategory> Items { get; private set; }

		public void Load() {

			Items = new ObservableCollection<WorkCategory>();
			Items.Add(new WorkCategory() { Id = -1, Name = "Все категории" });

			foreach (WorkCategory category in _workCategoryDataService.GetAll()) {

				Items.Add(category);
			}
		}
	}
}
