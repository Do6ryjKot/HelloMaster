using HelloWorker.Domain.Models;
using System;
using System.Collections.ObjectModel;

namespace HelloWorker.Wpf.Stores.CurrentActStore {
	
	/// <summary>
	/// Хранилище акта, с которым производится работа
	/// </summary>
	public interface ICurrentActStore {

		Act CurrentAct { get; }

		event Action StateChanged;

		void Load(long actId);

		void Refresh();
	}
}
