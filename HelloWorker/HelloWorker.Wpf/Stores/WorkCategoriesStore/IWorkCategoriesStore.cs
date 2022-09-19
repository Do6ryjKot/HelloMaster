using HelloWorker.Domain.Models;
using System.Collections.ObjectModel;

namespace HelloWorker.Wpf.Stores.WorkCategoriesStore {
	
	/// <summary>
	/// Хранилище категорий работ
	/// </summary>
	public interface IWorkCategoriesStore {

		ObservableCollection<WorkCategory> Items { get; }

		void Load();
	}
}
