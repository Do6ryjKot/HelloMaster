using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Messenger;
using HelloWorker.Wpf.Commands.Base;
using HelloWorker.Wpf.Services.Export;
using HelloWorker.Wpf.Services.Files;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.CurrentActStore;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.Structures.Export;
using HelloWorker.Wpf.ViewModels.ExportPositionsPopUpView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorker.Wpf.Commands.ExportPositionsPopUp {

	/// <summary>
	/// Команда экспорта позиций в поп апе
	/// </summary>
	public class ExportPositionsCommand : CommandBase {

		private const string XLSX_SAVE_FILTER = "Эксель (*.xlsx)|*.xlsx";
		private const string PDF_SAVE_FILTER = "PDF Документ (*.pdf)|*.pdf";

		private readonly ExportWorkplacePositionsPopUpViewModel _viewModel;
		private readonly ICurrentActStore _currentActStore;
		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;
		private readonly ISaveFileDialogService _saveFileDialogService;
		private readonly IPositionsExportService _xlsxExportService;
		private readonly IPositionsExportService _pdfExportService;
		private readonly IMessengerService _messengerService;
		private readonly IFileService _fileService;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		public ExportPositionsCommand(ExportWorkplacePositionsPopUpViewModel viewModel, 
			ICurrentActStore currentActStore, 
			ICurrentWorkplaceStore currentWorkplaceStore, 
			ISaveFileDialogService saveFileDialogService, 
			IPositionsExportService xlsxExportService, 
			IPositionsExportService pdfExportService, 
			IMessengerService messengerService, 
			IFileService fileService, 
			IMessageService messageService, 
			ILogService logService
		) {
			_viewModel = viewModel;
			_currentActStore = currentActStore;
			_currentWorkplaceStore = currentWorkplaceStore;
			_saveFileDialogService = saveFileDialogService;
			_xlsxExportService = xlsxExportService;
			_pdfExportService = pdfExportService;
			_messengerService = messengerService;
			_fileService = fileService;
			_messageService = messageService;
			_logService = logService;
		}

		public override void Execute(object parameter) {

			Stream file = null;
			IPositionsExportService usedExportService;
			IEnumerable<IExportProperty> usedExportProperties = _viewModel.ExportProperties.Where(ep => ep.IsUsed);

			if (usedExportProperties.Count() == 0) {

				_messageService.Error("Выберите поля для экспорта");
				return;
			}

			string fileName;

			if (_viewModel.UsePdf) {

				usedExportService = _pdfExportService;
				fileName = ".pdf";
				_saveFileDialogService.Filter = PDF_SAVE_FILTER;

			} else {

				usedExportService = _xlsxExportService;
				fileName = ".xlsx";
				_saveFileDialogService.Filter = XLSX_SAVE_FILTER;
			}

			CostExport costExport;

			if (_viewModel.ExportNoCost) {

				costExport = CostExport.None;

			} else if (_viewModel.ExportCompanyCost) {

				costExport = CostExport.CompanyCost;

			} else {

				costExport = CostExport.MasterCost;
			}

			try {

				if (_currentActStore.CurrentAct == null) {

					file = usedExportService.Export(_currentWorkplaceStore.CurrentWorkplace, usedExportProperties, costExport);
					fileName = _currentWorkplaceStore.CurrentWorkplace.Name + fileName;

				} else {

					file = usedExportService.Export(_currentActStore.CurrentAct, usedExportProperties, costExport);
					fileName = _currentActStore.CurrentAct.Name + fileName;
				}

				if (_viewModel.SaveToDisk) {

					fileName = _saveFileDialogService.GetSavePath(fileName);

					if (string.IsNullOrEmpty(fileName))
						return;

					_fileService.Save(file, fileName);

				} else {

					_messengerService.SendDocument(file, fileName);

					_messageService.Message("Документ успешно отправлен в телеграм");
				}
				
			} catch (AggregateException ex) {

				string message = "";

				foreach (var exception in ex.InnerExceptions) {

					// message += exception.Message + "\n" + exception.Data + "\n" + exception.StackTrace + "\n";
					message += string.Join("\n", exception.Message, exception.Data, exception.StackTrace, exception.InnerException);
				}

				_messageService.Error(message);
				_messageService.Error(ex.InnerException.Message);

				_logService.Log(message);

			} catch (Exception ex) {

				_messageService.Error(ex.Message);
				_logService.Log(ex.Message);
				
			} finally {

				file?.Close();
			}
		}
	}
}
