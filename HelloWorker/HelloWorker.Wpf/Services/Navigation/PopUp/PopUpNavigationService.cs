using HelloWorker.Wpf.Stores.PopUp;
using HelloWorker.Wpf.ViewModels.Base;
using System;

namespace HelloWorker.Wpf.Services.Navigation.PopUp {

	public class PopUpNavigationService<TViewModel> : IPopUpNavigationService<TViewModel> where TViewModel : ViewModelBase {

		private readonly IPopUpNavigationStore _popUpNavigationStore;
		private readonly Func<TViewModel> _createViewModel;

		public PopUpNavigationService(IPopUpNavigationStore popUpNavigationStore, Func<TViewModel> createViewModel) {
			_popUpNavigationStore = popUpNavigationStore;
			_createViewModel = createViewModel;
		}

		public void Navigate() {

			_popUpNavigationStore.CurrentViewModel = _createViewModel();
		}
	}
}
