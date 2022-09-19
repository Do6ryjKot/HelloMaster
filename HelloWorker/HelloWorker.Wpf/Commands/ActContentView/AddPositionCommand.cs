using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.CurrentActStore;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.Stores.PositionsStore;
using HelloWorker.Wpf.ViewModels.PriceListCalculation;
using System;

namespace HelloWorker.Wpf.Commands.ActContentView {
	
	/// <summary>
	/// Команда добаления новой позиции в акт/напрямую в объект
	/// </summary>
	public class AddPositionCommand : CommandBase {

		private readonly ICurrentActStore _currentActStore;
		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly IPositionsStore _positionsStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public AddPositionCommand(ICurrentActStore currentActStore,
			ICurrentWorkplaceStore currentWorkplaceStore,
			IMessageService messageService,
			ILogService logService, 
			IPositionsStore positionsStore) {

			_currentActStore = currentActStore;
			_currentWorkplaceStore = currentWorkplaceStore;
			_messageService = messageService;
			_logService = logService;
			_positionsStore = positionsStore;
		}

		public override void Execute(object parameter) {

			PriceListPositionViewModel position = (PriceListPositionViewModel)parameter;

			WorkplaceWork newPosition = new WorkplaceWork() { 
				
				WorkplaceId = _currentWorkplaceStore.CurrentWorkplace.Id,
				WorkId = position.Work.Id
			};

			if (_currentActStore.CurrentAct != null) {

				newPosition.ActId = _currentActStore.CurrentAct.Id;
			}

			try {

				// _currentWorkplaceStore.AddPosition(newPosition);
				_positionsStore.Add(newPosition);

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
			}
		}
	}
}
