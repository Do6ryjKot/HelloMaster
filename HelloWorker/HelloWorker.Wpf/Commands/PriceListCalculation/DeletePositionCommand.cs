using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Notifiers.Sums;
using HelloWorker.Wpf.Stores.PositionsStore;
using HelloWorker.Wpf.ViewModels.PriceListCalculation;
using System;

namespace HelloWorker.Wpf.Commands.PriceListCalculation {

	/// <summary>
	///	Команда удаления позиций
	/// </summary>
	public class DeletePositionCommand : CommandBase {

		private readonly WorkplacePositionViewModel _positionViewModel;
		private readonly ISumChangingNotifierService _sumChangingNotifierService;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;
		private readonly IPositionsStore _positionsStore;

		public DeletePositionCommand(WorkplacePositionViewModel positionViewModel,
			IMessageService messageService,
			ILogService logService,
			IPositionsStore positionsStore, 
			ISumChangingNotifierService sumChangingNotifierService
		) {

			_positionViewModel = positionViewModel;
			_messageService = messageService;
			_logService = logService;
			_positionsStore = positionsStore;
			_sumChangingNotifierService = sumChangingNotifierService;
		}

		public override void Execute(object parameter) {

			if (!_messageService.Confirm("Вы уверены, что хотите удалить позицию?")) {
				return;
			}

			try {

				_positionsStore.Delete(_positionViewModel.Position);
				_sumChangingNotifierService.UpdateSums(_positionViewModel.Position);

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(string.Concat("Error: " + ex.Message));
			}
		}
	}
}
