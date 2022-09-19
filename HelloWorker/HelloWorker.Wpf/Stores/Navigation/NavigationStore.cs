using HelloWorker.Wpf.ViewModels.Base;
using System;

namespace HelloWorker.Wpf.Stores.Navigation {

	public class NavigationStore : INavigationStore {

		private ViewModelBase _currentViewModel;

		public ViewModelBase CurrentViewModel {

			get => _currentViewModel;

			set {

				_currentViewModel?.Dispose();
				_currentViewModel = value;
				OnStateChanged();
			}
		}

		public event Action StateChanged;

		private void OnStateChanged() {

			StateChanged?.Invoke();
		}
	}
}
