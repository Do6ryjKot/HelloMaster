using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation;
using HelloWorker.Wpf.Stores.CurrentActStore;
using HelloWorker.Wpf.ViewModels.ActContentView;
using System;

namespace HelloWorker.Wpf.Commands.ActsFolderView {
	
	/// <summary>
	/// Команда открытия страницы с содержимым акта
	/// </summary>
	public class OpenActContentCommand : CommandBase {

		private readonly ICurrentActStore _currentActStore;
		private readonly INavigationService<ActContentViewModel> _navigationService;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public OpenActContentCommand(ICurrentActStore currentActStore,
			INavigationService<ActContentViewModel> navigationService,
			IMessageService messageService,
			ILogService logService) {

			_currentActStore = currentActStore;
			_navigationService = navigationService;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {

			Act act = (Act)parameter;

			try {

				_currentActStore.Load(act.Id);

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
				return;
			}

			_navigationService.Navigate();
		}
	}
}
