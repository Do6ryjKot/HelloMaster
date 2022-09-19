using HelloWorker.Wpf.Stores.PopUp;

namespace HelloWorker.Wpf.Services.Navigation.PopUp {

	public class ClosePopUpService : IClosePopUpService {

		private readonly IPopUpNavigationStore _popUpNavigationStore;

		public ClosePopUpService(IPopUpNavigationStore popUpNavigationStore) {
			_popUpNavigationStore = popUpNavigationStore;
		}

		public void ClosePopUp() {

			_popUpNavigationStore.Close();
		}
	}
}
