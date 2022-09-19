using HelloWorker.Wpf.Stores.PopUp;
using HelloWorker.Wpf.ViewModels.Base;
using System;

namespace HelloWorker.Wpf.Services.Navigation.PopUp {

	public class ParametrizedPopUpNavigationService<TViewModel, TParameter> : 
		IParametrizedPopUpNavigationService<TViewModel, TParameter> where TViewModel : ViewModelBase {

		private readonly IPopUpNavigationStore _popUpNavigationStore;
		private readonly Func<TParameter, TViewModel> _createViewModel;

		public ParametrizedPopUpNavigationService(IPopUpNavigationStore popUpNavigationStore, Func<TParameter, TViewModel> createViewModel) {
			_popUpNavigationStore = popUpNavigationStore;
			_createViewModel = createViewModel;
		}

		public void Navigate(TParameter parameter) {

			_popUpNavigationStore.CurrentViewModel = _createViewModel(parameter);
		}
	}
}
