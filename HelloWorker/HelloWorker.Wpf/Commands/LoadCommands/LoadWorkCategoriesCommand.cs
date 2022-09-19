using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.WorkCategoriesStore;
using System;

namespace HelloWorker.Wpf.Commands.LoadCommands {

	public class LoadWorkCategoriesCommand : CommandBase {

		private readonly IWorkCategoriesStore _workCategoriesStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public LoadWorkCategoriesCommand(IWorkCategoriesStore workGroupsStore, IMessageService messageService, ILogService logService) {
			_workCategoriesStore = workGroupsStore;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {

			try {

				_workCategoriesStore.Load();

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
			}
		}
	}
}
