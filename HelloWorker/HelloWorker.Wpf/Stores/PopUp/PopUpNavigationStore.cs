using HelloWorker.Wpf.ViewModels.Base;
using System;

namespace HelloWorker.Wpf.Stores.PopUp {

	public class PopUpNavigationStore : IPopUpNavigationStore {

		private ViewModelBase _currentViewModel;
		public ViewModelBase CurrentViewModel {

			get => _currentViewModel; 

			set {

				CurrentViewModel?.Dispose();
				_currentViewModel = value;
				OnStateChanged();
			}
		}


		public bool HasContent => CurrentViewModel != null;

		public event Action StateChanged;

		public void Close() {

			CurrentViewModel = null;
		}

		private void OnStateChanged() {

			StateChanged?.Invoke();
		}
	}
}
