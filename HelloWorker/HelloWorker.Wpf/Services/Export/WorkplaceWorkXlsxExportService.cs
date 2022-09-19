using ClosedXML.Excel;
using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using HelloWorker.Wpf.Services.Files;
using HelloWorker.Wpf.Stores.Export;
using HelloWorker.Wpf.Structures.Export;
using System.Collections.Generic;

namespace HelloWorker.Wpf.Services.Export {

	/// <summary>
	/// Deprecated
	/// </summary>
	public class WorkplaceWorkXlsxExportService : IWorkplaceWorkXlsxExportService {

		private const string SAVE_FILTER = "Эксель (*.xlsx)|*.xlsx";

		private readonly ISaveFileDialogService _saveFileDialogService;
		private readonly IExportPropertiesStore _exportPropertiesStore;
		private readonly IWorkplaceDataService _workplaceDataService;

		public WorkplaceWorkXlsxExportService(ISaveFileDialogService saveFileDialogService,
			IExportPropertiesStore exportPropertiesStore, 
			IWorkplaceDataService workplaceDataService) {

			_saveFileDialogService = saveFileDialogService;
			_saveFileDialogService.Filter = SAVE_FILTER;

			_exportPropertiesStore = exportPropertiesStore;
			_workplaceDataService = workplaceDataService;
		}

		public void ExportCompanyPrices(Workplace workplace) {

			Export(workplace, _exportPropertiesStore.CompanyPricesExportProps);
		}

		public void ExportMasterPrices(Workplace workplace) {

			Export(workplace, _exportPropertiesStore.MasterPricesExportProps);
		}

		private void Export(Workplace workplace, IEnumerable<IExportProperty> exportProps) {

			string defaultDocumentName = workplace.Name;
			string savePath = _saveFileDialogService.GetSavePath(defaultDocumentName);

			if (string.IsNullOrEmpty(savePath))
				return;

			IEnumerable<WorkplaceWork> exportData = _workplaceDataService.GetWithPositions(workplace.Id).WorkplaceWorks;

			IXLWorkbook book = new XLWorkbook(XLEventTracking.Disabled);
			IXLWorksheet sheet = book.Worksheets.Add(defaultDocumentName);

			int columnIndex = 1;

			sheet.Row(1).Style.Font.Bold = true;

			foreach (IExportProperty exportProperty in exportProps) {

				sheet.Cell(1, columnIndex).Value = exportProperty.DocumentName;

				int rowIndex = 2;

				foreach (WorkplaceWork position in exportData) {

					object propVal = position.GetType()
						.GetProperty(exportProperty.PropertyName[0])
						.GetValue(position);

					for (int i = 1; i < exportProperty.PropertyName.Length; i++) {

						propVal = propVal.GetType()
							.GetProperty(exportProperty.PropertyName[i])
							.GetValue(propVal);
					}

					sheet.Cell(rowIndex, columnIndex).Value = propVal?.ToString();

					rowIndex++;
				}

				sheet.Column(columnIndex).AdjustToContents();

				columnIndex++;
			}

			book.SaveAs(savePath);
		}
	}
}
