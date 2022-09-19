using ClosedXML.Excel;
using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using HelloWorker.Wpf.Structures.Export;
using System.Collections.Generic;
using System.IO;

namespace HelloWorker.Wpf.Services.Export {

	public class XlsxPositionsExportService : IPositionsExportService {

		private readonly int SHEET_NAME_MAX_LENGTH = 30;

		private readonly IWorkplacePositionDataService _dataService;

		public XlsxPositionsExportService(IWorkplacePositionDataService dataService) {
			_dataService = dataService;
		}

		public Stream Export(Workplace workplace, IEnumerable<IExportProperty> exportProperties, CostExport costExport = CostExport.None) {

			decimal? cost = null;

			if (costExport == CostExport.CompanyCost) {

				cost = workplace.Cost;

			} else if (costExport == CostExport.MasterCost) {

				cost = workplace.MasterCost;
			}

			return GetData(workplace.Name, _dataService.GetFromWorkplace(workplace.Id), exportProperties, cost);
		}

		public Stream Export(Act act, IEnumerable<IExportProperty> exportProperties, CostExport costExport = CostExport.None) {

			decimal? cost = null;

			if (costExport == CostExport.CompanyCost) {

				cost = act.Cost;

			} else if (costExport == CostExport.MasterCost) {

				cost = act.MasterCost;
			}

			return GetData(act.Name, _dataService.GetFromAct(act.Id), exportProperties, cost);
		}

		private Stream GetData(string documentName, 
			IEnumerable<WorkplaceWork> positions, 
			IEnumerable<IExportProperty> exportProperties,
			decimal? cost = null
		) {

			IXLWorkbook book = new XLWorkbook(XLEventTracking.Disabled);

			if (documentName.Length > SHEET_NAME_MAX_LENGTH) {

				documentName = documentName.Substring(0, SHEET_NAME_MAX_LENGTH);
			}

			IXLWorksheet sheet = book.Worksheets.Add(documentName);

			int columnIndex = 1;
			int rowIndex = 2;

			sheet.Row(1).Style.Font.Bold = true;

			foreach (IExportProperty exportProperty in exportProperties) {

				sheet.Cell(1, columnIndex).Value = exportProperty.DocumentName;

				rowIndex = 2;

				foreach (WorkplaceWork position in positions) {

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

			if (cost != null) {

				sheet.Cell(rowIndex, columnIndex - 1).Value = cost;
			}

			MemoryStream result = new MemoryStream();

			book.SaveAs(result);

			return result;
		}
	}
}
