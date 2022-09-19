using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.Stores.ActsStore;
using HelloWorker.Wpf.ViewModels.ActsFolderView.PopUp;
using System;

namespace HelloWorker.Wpf.Commands.ActsCommands.PopUp {

	/// <summary>
	/// Команда добавления акта
	/// </summary>
	public class AddActCommand : CommandBase {

		private readonly ActAddEditPopUpViewModel _viewModel;
		private readonly IActsStore _actsStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;
		private readonly IClosePopUpService _closePopUpService;

		public AddActCommand(ActAddEditPopUpViewModel viewModel,
			IActsStore actsStore,
			IMessageService messageService,
			ILogService logService,
			IClosePopUpService closePopUpService) {

			_viewModel = viewModel;
			_actsStore = actsStore;
			_messageService = messageService;
			_logService = logService;
			_closePopUpService = closePopUpService;
		}

		public override void Execute(object parameter) {

			try {

				_actsStore.Add(_viewModel.SetUp());

				_closePopUpService.ClosePopUp();

			} catch (Exception ex) {

				_messageService.Message(ex.Message);
				_logService.Log(ex.Message);
			}
		}
	}
}
