using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using System;

namespace HelloWorker.Wpf.Commands.WorkplaceCommands {

	/// <summary>
	///	Обновление позиций объекта
	/// </summary>
	public class RefreshWorkplacePositionsCommand : CommandBase {

		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly IMessageService _messageService;

		public RefreshWorkplacePositionsCommand(ICurrentWorkplaceStore currentWorkplaceStore, IMessageService messageService) {
			_currentWorkplaceStore = currentWorkplaceStore;
			_messageService = messageService;
		}

		public override void Execute(object parameter) {

			try {

				// _currentWorkplaceStore.Load(_currentWorkplaceStore.CurrentWorkplace.Id);

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
			}
		}
	}
}
