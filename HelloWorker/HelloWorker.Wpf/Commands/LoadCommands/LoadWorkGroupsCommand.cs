using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.WorkGroupsStore;
using System;

namespace HelloWorker.Wpf.Commands.LoadCommands {

	/// <summary>
	///	Команда выгрузки справочника групп работ прайслиста
	/// </summary>
	public class LoadWorkGroupsCommand : CommandBase {

		private readonly IWorkGroupsStore _workGroupsStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public LoadWorkGroupsCommand(IWorkGroupsStore workGroupsStore, IMessageService messageService, ILogService logService) {
			_workGroupsStore = workGroupsStore;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {

			try {

				_workGroupsStore.Load();

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
			}
		}
	}
}
