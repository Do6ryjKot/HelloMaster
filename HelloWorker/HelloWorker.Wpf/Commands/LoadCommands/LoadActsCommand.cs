using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.ActsStore;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using System;

namespace HelloWorker.Wpf.Commands.LoadCommands {

	/// <summary>
	/// Команда загрузки актов нынешнего объекта
	/// </summary>
	public class LoadActsCommand : CommandBase {

		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly IActsStore _actsStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public LoadActsCommand(ICurrentWorkplaceStore currentWorkplaceStore,
			IActsStore actsStore,
			IMessageService messageService,
			ILogService logService) {

			_currentWorkplaceStore = currentWorkplaceStore;
			_actsStore = actsStore;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {

			try {

				_actsStore.Load(_currentWorkplaceStore.CurrentWorkplace.Id);

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
			}
		}
	}
}
