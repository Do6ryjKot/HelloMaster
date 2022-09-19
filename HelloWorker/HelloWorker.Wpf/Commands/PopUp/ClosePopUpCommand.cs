using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Stores.PopUp;

namespace HelloWorker.Wpf.Commands.PopUp {

	/// <summary>
	/// Команда закрытия поп апа
	/// </summary>
	public class ClosePopUpCommand : CommandBase {

		private readonly IPopUpNavigationStore _popUpNavigationStore;

		public ClosePopUpCommand(IPopUpNavigationStore popUpNavigationStore) {
			_popUpNavigationStore = popUpNavigationStore;
		}

		public override void Execute(object parameter) {

			_popUpNavigationStore.Close();
		}
	}
}
