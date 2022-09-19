using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.Stores.WorkplacesStore;
using HelloWorker.Wpf.ViewModels.PriceListCalculation.PopUp;
using System;

namespace HelloWorker.Wpf.Commands.WorkplaceCommands.PopUp {

	/// <summary>
	///	Команда добавления объекта
	/// </summary>
	public class AddWorkplaceCommand : CommandBase {

		private readonly WorkplaceAddEditPopUpViewModel _viewModel;
		private readonly IWorkplacesStore _workplacesStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;
		private readonly IClosePopUpService _closePopUpService;

		public AddWorkplaceCommand(WorkplaceAddEditPopUpViewModel viewModel,
			IWorkplacesStore workplacesStore,
			IMessageService messageService,
			ILogService logService,
			IClosePopUpService closePopUpService) {

			_viewModel = viewModel;
			_workplacesStore = workplacesStore;
			_messageService = messageService;
			_logService = logService;
			_closePopUpService = closePopUpService;
		}

		public override void Execute(object parameter) {

			try {

				_workplacesStore.Add(_viewModel.SetUp());

				_closePopUpService.ClosePopUp();

			} catch (Exception ex) {

				_messageService.Message(ex.Message);
				_logService.Log(ex.Message);
			}
		}
	}
}
