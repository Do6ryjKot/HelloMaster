using HelloWorker.Wpf.Stores.Navigation;
using HelloWorker.Wpf.ViewModels.Base;
using System;

namespace HelloWorker.Wpf.Services.Navigation {

	public class NavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase {

		private readonly INavigationStore _navigationStore;
		private readonly Func<TViewModel> _createViewModel;

		public NavigationService(INavigationStore navigationStore, Func<TViewModel> createViewModel) {
			_navigationStore = navigationStore;
			_createViewModel = createViewModel;
		}

		public void Navigate() {

			_navigationStore.CurrentViewModel = _createViewModel();
		}
	}
}
