using HelloWorker.Wpf.Commands.PopUp;
using HelloWorker.Wpf.Stores.PopUp;
using HelloWorker.Wpf.ViewModels.Base;
using System.Windows.Input;

namespace HelloWorker.Wpf.ViewModels.PopUp {
	
	/// <summary>
	///	Модель представления поп апа
	/// </summary>
	public class PopUpViewModel : ViewModelBase {

		private readonly IPopUpNavigationStore _popUpNavStore;

		public ViewModelBase CurrentViewModel => _popUpNavStore.CurrentViewModel;
		public bool HasContent => _popUpNavStore.HasContent;

		public ICommand ClosePopUpCommand { get; }
		
		public PopUpViewModel(IPopUpNavigationStore popUpNavStore) {

			_popUpNavStore = popUpNavStore;
			_popUpNavStore.StateChanged += PopUpViewModelChanged;

			ClosePopUpCommand = new ClosePopUpCommand(popUpNavStore);
		}

		private void PopUpViewModelChanged() {

			OnPropertyChanged(nameof(CurrentViewModel));
			OnPropertyChanged(nameof(HasContent));
		}

		public override void Dispose() {

			_popUpNavStore.StateChanged -= PopUpViewModelChanged;

			base.Dispose();
		}
	}
}
