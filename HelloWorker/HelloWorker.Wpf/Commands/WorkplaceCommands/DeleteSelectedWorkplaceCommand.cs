using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.WorkplacesStore;
using System;

namespace HelloWorker.Wpf.Commands.WorkplaceCommands {

	/// <summary>
	/// Команда удаления переданного объекта
	/// </summary>
	public class DeleteSelectedWorkplaceCommand : CommandBase {

		private readonly Workplace _workplace;
		private readonly IWorkplacesStore _workplacesStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public DeleteSelectedWorkplaceCommand(Workplace workplace, 
			IWorkplacesStore workplacesStore, 
			IMessageService messageService, 
			ILogService logService) {

			_workplace = workplace;
			_workplacesStore = workplacesStore;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {

			if (!_messageService.Confirm("Вы уверены что хотите удалить объект?")) {
				return;
			}

			try {

				_workplacesStore.Delete(_workplace);

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
				return;
			}
		}
	}
}
