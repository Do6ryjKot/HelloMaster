using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.ViewModels.PriceListCalculation;

namespace HelloWorker.Wpf.Commands.PriceListCalculation {

	/// <summary>
	/// Deprecated
	/// </summary>
	public class AddToWorkplacePositionsCommand : CommandBase {

		private readonly IMessageService _messageService;
		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;

		public AddToWorkplacePositionsCommand(IMessageService messageService, ICurrentWorkplaceStore currentWorkplaceStore) {
			_messageService = messageService;
			_currentWorkplaceStore = currentWorkplaceStore;
		}

		public override void Execute(object parameter) {

			PriceListPositionViewModel viewModel = (PriceListPositionViewModel)parameter;

			// _currentWorkplaceStore.AddPosition(viewModel.Work);
		}
	}
}
