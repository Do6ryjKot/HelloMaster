using HelloWorker.Domain.Models;
using System;
using System.Collections.ObjectModel;

namespace HelloWorker.Wpf.Stores.ActsStore {
	
	/// <summary>
	/// Набор актов определенного объекта
	/// </summary>
	public interface IActsStore {

		ObservableCollection<Act> Acts { get; }

		void Load(long workplaceId);

		event Action StateChanged;

		void Add(Act act);
		void Update(Act act);
		void Delete(Act act);
	}
}
