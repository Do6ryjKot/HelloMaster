using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.ViewModels.ActContentView;

namespace HelloWorker.Wpf.Commands.ActContentView {

	public class TurnSumsShowModeCommand : CommandBase {

		private readonly ActContentViewModel _viewModel;

		public TurnSumsShowModeCommand(ActContentViewModel viewModel) {
			_viewModel = viewModel;
		}

		public override void Execute(object parameter) {

			_viewModel.AreSumsShown = !_viewModel.AreSumsShown;
		}
	}
}
