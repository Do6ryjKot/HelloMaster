using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.PriceListStore;
using System;

namespace HelloWorker.Wpf.Commands.LoadCommands {

	/// <summary>
	///	Команда выгрузки прайс листа
	/// </summary>
	public class LoadPriceListCommand : CommandBase {

		private readonly IPriceListStore _priceListStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public LoadPriceListCommand(IPriceListStore priceListStore, IMessageService messageService, ILogService logService) {
			_priceListStore = priceListStore;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {

			try {

				_priceListStore.Load();

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
			}
		}
	}
}
