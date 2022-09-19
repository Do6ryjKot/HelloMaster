using HelloWorker.Wpf.Stores.Navigation;
using HelloWorker.Wpf.Stores.PopUp;
using HelloWorker.Wpf.ViewModels.Base;
using HelloWorker.Wpf.ViewModels.PopUp;

namespace HelloWorker.Wpf.ViewModels.Main {
	
	/// <summary>
	/// Модель представления основного окна
	/// </summary>
	public class MainViewModel : ViewModelBase {

		private readonly INavigationStore _navigationStore;
		
		public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

		public PopUpViewModel PopUpViewModel { get; }

		public MainViewModel(INavigationStore navigationStore, 
			IPopUpNavigationStore popUpNavStore) {

			_navigationStore = navigationStore;
			_navigationStore.StateChanged += CurrentViewModelChanged;

			PopUpViewModel = new PopUpViewModel(popUpNavStore);
		}

		private void CurrentViewModelChanged() {			

			OnPropertyChanged(nameof(CurrentViewModel));
		}

		public override void Dispose() {

			PopUpViewModel.Dispose();

			base.Dispose();
		}
	}
}