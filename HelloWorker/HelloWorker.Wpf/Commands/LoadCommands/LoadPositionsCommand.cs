using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.CurrentActStore;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.Stores.PositionsStore;
using System;

namespace HelloWorker.Wpf.Commands.LoadCommands {

	/// <summary>
	/// Загрузка позиций
	/// </summary>
	public class LoadPositionsCommand : CommandBase {

		private readonly ICurrentActStore _currentActStore;
		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly IPositionsStore _positionsStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public LoadPositionsCommand(ICurrentActStore currentActStore, 
			ICurrentWorkplaceStore currentWorkplaceStore, 
			IPositionsStore positionsStore, 
			IMessageService messageService, 
			ILogService logService) {

			_currentActStore = currentActStore;
			_currentWorkplaceStore = currentWorkplaceStore;
			_positionsStore = positionsStore;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {

			try {

				if (_currentActStore.CurrentAct == null) {

					_positionsStore.LoadFromWorkplace(_currentWorkplaceStore.CurrentWorkplace.Id);

				} else {

					_positionsStore.LoadFromAct(_currentActStore.CurrentAct.Id);
				}

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
			}
		}
	}
}
