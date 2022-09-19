using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.WorkplacesStore;
using System;

namespace HelloWorker.Wpf.Commands.LoadCommands {

	/// <summary>
	/// Команда выгрузки объектов
	/// </summary>
	public class LoadWorkplacesCommand : CommandBase {

		private readonly IWorkplacesStore _workplacesStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public LoadWorkplacesCommand(IWorkplacesStore workplacesStore, IMessageService messageService, ILogService logService) {
			_workplacesStore = workplacesStore;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {

			try {

				_workplacesStore.Load();

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
			}
		}
	}
}
