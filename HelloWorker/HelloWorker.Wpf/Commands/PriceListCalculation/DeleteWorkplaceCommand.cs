using HelloWorker.Domain.Services.LastActivity;
using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.Stores.WorkplacesStore;
using System;

namespace HelloWorker.Wpf.Commands.PriceListCalculation {

	/// <summary>
	///	Команда удаления объекта
	/// </summary>
	public class DeleteWorkplaceCommand : CommandBase {

		private readonly IWorkplacesStore _workplacesStore;
		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly ILastActiveWorkplaceService _lastActiveWorkplaceService;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public DeleteWorkplaceCommand(IWorkplacesStore workplacesStore, 
			ICurrentWorkplaceStore currentWorkplaceStore, 
			ILastActiveWorkplaceService lastActiveWorkplaceService, 
			IMessageService messageService, 
			ILogService logService) {

			_workplacesStore = workplacesStore;
			_currentWorkplaceStore = currentWorkplaceStore;
			_lastActiveWorkplaceService = lastActiveWorkplaceService;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {
			
			if (!_messageService.Confirm("Вы уверены что хотите удалить объект?")) {
				return;
			}

			try {

				_workplacesStore.Delete(_currentWorkplaceStore.CurrentWorkplace);
			
			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
				return;
			}

			_currentWorkplaceStore.Load(_lastActiveWorkplaceService.GetLastActiveWorkplaceId());
		}
	}
}
