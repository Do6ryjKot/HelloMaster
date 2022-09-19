using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Notifiers.Sums;
using HelloWorker.Wpf.Stores.ActsStore;
using HelloWorker.Wpf.ViewModels.ActsFolderView;
using System;

namespace HelloWorker.Wpf.Commands.ActsCommands {

	public class DeleteSelectedActCommand : CommandBase {

		private readonly ActFolderViewModel _viewModel;
		private readonly IActsStore _actsStore;
		private readonly ISumChangingNotifierService _sumChangingNotifierService;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public DeleteSelectedActCommand(ActFolderViewModel viewModel,
			IActsStore actsStore,
			IMessageService messageService,
			ILogService logService, 
			ISumChangingNotifierService sumChangingNotifierService
		) {

			_viewModel = viewModel;
			_actsStore = actsStore;
			_messageService = messageService;
			_logService = logService;
			_sumChangingNotifierService = sumChangingNotifierService;
		}

		public override void Execute(object parameter) {
			
			if (!_messageService.Confirm("Вы уверены, что хотите удалить акт?")) {
				return;
			}

			try {

				_actsStore.Delete(_viewModel.Act);
				_sumChangingNotifierService.UpdateSums(_viewModel.Act);

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
				return;
			}
		}
	}
}
