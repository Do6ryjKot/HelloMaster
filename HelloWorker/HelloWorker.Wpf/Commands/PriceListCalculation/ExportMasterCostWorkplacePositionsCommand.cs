using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Export;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using System;

namespace HelloWorker.Wpf.Commands.PriceListCalculation {

	/// <summary>
	/// Экспорт позиций объекта в эксель с использованием стоимости мастера
	/// </summary>
	public class ExportMasterCostWorkplacePositionsCommand : CommandBase {

		private readonly IWorkplaceWorkXlsxExportService _exportService;
		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public ExportMasterCostWorkplacePositionsCommand(IWorkplaceWorkXlsxExportService exportService,
			ICurrentWorkplaceStore currentWorkplaceStore,
			IMessageService messageService,
			ILogService logService) {

			_exportService = exportService;
			_currentWorkplaceStore = currentWorkplaceStore;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {

			try {

				_exportService.ExportMasterPrices(_currentWorkplaceStore.CurrentWorkplace);

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
			}
		}
	}
}
