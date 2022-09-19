using HelloWorker.Domain.Services.Messenger;
using HelloWorker.Wpf.Commands.ExportPositionsPopUp;
using HelloWorker.Wpf.Services.Export;
using HelloWorker.Wpf.Services.Files;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Stores.CurrentActStore;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.Stores.Export;
using HelloWorker.Wpf.Structures.Export;
using HelloWorker.Wpf.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace HelloWorker.Wpf.ViewModels.ExportPositionsPopUpView {
	
	/// <summary>
	/// Модель представления страницы экспорта позиций
	/// </summary>
	public class ExportWorkplacePositionsPopUpViewModel : ViewModelBase {

		private readonly IExportPropertiesStore _exportPropertiesStore;

		public IEnumerable<IExportProperty> ExportProperties => _exportPropertiesStore.ExportProperties;

		#region Формы сохранения

		/// <summary>
		/// Сохранить на диске 
		/// </summary>		
		private bool _saveToDisk = true;
		public bool SaveToDisk {

			get => _saveToDisk;

			set {

				_saveToDisk = value;
				OnPropertyChanged(nameof(SaveToDisk));
			}
		}

		/// <summary>
		/// Отправить на мессенджер
		/// </summary>
		private bool _sendToMessenger;
		public bool SendToMessenger {

			get => _sendToMessenger;

			set {

				_sendToMessenger = value;
				OnPropertyChanged(nameof(SendToMessenger));
			}
		}

		#endregion

		#region Форматы экспорта

		/// <summary>
		/// Сохранить в виде pdf документа
		/// </summary>
		private bool _usePdf = true;
		public bool UsePdf {

			get => _usePdf;

			set {

				_usePdf = value;
				OnPropertyChanged(nameof(UsePdf));
			}
		}

		/// <summary>
		/// Сохранить в виде Эксель документа
		/// </summary>
		private bool _useXlsx;
		public bool UseXlsx {

			get => _useXlsx; 

			set {

				_useXlsx = value;
				OnPropertyChanged(nameof(UseXlsx));
			}
		}

		#endregion

		#region Экспорт итого

		private bool _exportNoCost = true;
		public bool ExportNoCost {

			get => _exportNoCost; 

			set { 
				_exportNoCost = value;
				OnPropertyChanged(nameof(ExportNoCost));
			}
		}

		private bool _exportCompanyCost;
		public bool ExportCompanyCost {

			get => _exportCompanyCost; 

			set { 
				_exportCompanyCost = value;
				OnPropertyChanged(nameof(ExportCompanyCost));
			}
		}

		private bool _exportMasterCost;
		public bool ExportMasterCost {

			get => _exportMasterCost; 

			set { 
				_exportMasterCost = value;
				OnPropertyChanged(nameof(ExportMasterCost));
			}
		}

		#endregion

		public ICommand SubmitCommand { get; }

		public ExportWorkplacePositionsPopUpViewModel(IExportPropertiesStore exportPropertiesStore,
			ICurrentActStore currentActStore,
			ICurrentWorkplaceStore currentWorkplaceStore,
			ISaveFileDialogService saveFileDialogService,
			IMessageService messageService,
			IFileService fileService,
			ILogService logService,
			IPositionsExportService xlsxExportService,
			IPositionsExportService pdfExportService,
			IMessengerService messengerService
		) {

			_exportPropertiesStore = exportPropertiesStore;

			SubmitCommand = new ExportPositionsCommand(this, currentActStore, currentWorkplaceStore, saveFileDialogService, 
				xlsxExportService, pdfExportService, messengerService, fileService, messageService, logService);
		}
	}
}
