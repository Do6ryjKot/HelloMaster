using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.ViewModels.ActsFolderView;
using HelloWorker.Wpf.ViewModels.WorkplacesFolderView;
using System;

namespace HelloWorker.Wpf.Commands.WorkplacesFolderView {

	/// <summary>
	///	Команда открытья содержимого объекта
	/// </summary>
	public class OpenWorkplaceContentCommand : CommandBase {

		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly INavigationService<ActsFolderViewModel> _navigationService;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public OpenWorkplaceContentCommand(ICurrentWorkplaceStore currentWorkplaceStore, 
			INavigationService<ActsFolderViewModel> navigationService, 
			IMessageService messageService, 
			ILogService logService) {

			_currentWorkplaceStore = currentWorkplaceStore;
			_navigationService = navigationService;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {

			Workplace workplace = (Workplace)parameter;

			try {

				_currentWorkplaceStore.Load(workplace.Id);

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
				return;
			}

			_navigationService.Navigate();
		}
	}
}
