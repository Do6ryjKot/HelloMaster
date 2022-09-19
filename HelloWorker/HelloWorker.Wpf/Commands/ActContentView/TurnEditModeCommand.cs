using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.ViewModels.ActContentView;

namespace HelloWorker.Wpf.Commands.ActContentView {

	/// <summary>
	/// Команда переключения режима редактирования
	/// </summary>
	public class TurnEditModeCommand : CommandBase {

		private readonly ActContentViewModel _viewModel;

		public TurnEditModeCommand(ActContentViewModel viewModel) {
			_viewModel = viewModel;
		}

		public override void Execute(object parameter) {

			_viewModel.IsEditing = !_viewModel.IsEditing;
		}
	}
}
