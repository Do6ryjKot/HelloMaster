
using HelloWorker.Domain.Models;
using System.Collections.ObjectModel;

namespace HelloWorker.Wpf.Stores.WorkGroupsStore {
	
	/// <summary>
	///	Хранилище справочника списка групп работ
	/// </summary>
	public interface IWorkGroupsStore {

		ObservableCollection<WorkGroup> Items { get; }

		/// <summary>
		///	Загрузка справочника
		/// </summary>
		void Load();
	}
}
