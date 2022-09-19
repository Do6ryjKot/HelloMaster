using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using HelloWorker.Wpf.Structures.Export;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorker.Wpf.Services.Export {

	public class PdfPositionsExportService : IPositionsExportService {

		private readonly IWorkplacePositionDataService _dataService;
		private readonly IWorkplaceDataService _workplaceDataService;

		// Фонт текста в документе
		private readonly string _mainFont;

		// Стиль заголовка
		private readonly TextStyle _titleStyle;

		// Стиль текста в таблице
		private readonly TextStyle _textStyle;

		public PdfPositionsExportService(IWorkplacePositionDataService dataService, IWorkplaceDataService workplaceDataService) {

			_dataService = dataService;
			_workplaceDataService = workplaceDataService;

			_mainFont = Fonts.Verdana;

			_titleStyle = TextStyle
				.Default
				.SemiBold()
				.FontFamily(_mainFont); ;

			_textStyle = TextStyle.Default
				.FontSize(12)
				.FontFamily(Fonts.Verdana);			
		}

		// Стиль ячеек в заголовке таблицы
		private IContainer HeaderCellStyle(IContainer container) {

			return container.DefaultTextStyle(x => x.SemiBold().FontFamily(_mainFont))
				.PaddingTop(20)
				.BorderBottom(1)
				.BorderColor(Colors.Black)
				.AlignCenter();
		}

		// Стиль ячеек таблицы
		private IContainer CellStyle(IContainer container) {

			return container.DefaultTextStyle(x => x.FontFamily(_mainFont))
				.PaddingVertical(5)
				.BorderBottom(1)
				.BorderColor(Colors.Grey.Lighten2);
		}

		// Стиль ячеек таблицы, содержащие цифровые значения
		private IContainer DecimalCellStyle(IContainer container) {

			return CellStyle(container).AlignMiddle().AlignRight().PaddingRight(10);
		}

		public Stream Export(Workplace workplace, IEnumerable<IExportProperty> exportProperties, CostExport costExport = CostExport.None) {

			decimal? cost = null;

			if (costExport == CostExport.CompanyCost) {

				cost = workplace.Cost;

			} else if (costExport == CostExport.MasterCost) {

				cost = workplace.MasterCost;
			}

			return GetData(workplace, _dataService.GetFromWorkplace(workplace.Id), exportProperties, cost);
		}

		public Stream Export(Act act, IEnumerable<IExportProperty> exportProperties, CostExport costExport = CostExport.None) {

			decimal? cost = null;

			if (costExport == CostExport.CompanyCost) {

				cost = act.Cost;

			} else if (costExport == CostExport.MasterCost) {

				cost = act.MasterCost;
			}

			Workplace workplace = _workplaceDataService.Get(act.WorkplaceId);

			return GetData(workplace, _dataService.GetFromAct(act.Id), exportProperties, cost);
		}

		private Stream GetData(Workplace workplace, IEnumerable<WorkplaceWork> positions, IEnumerable<IExportProperty> exportProperties, decimal? cost = null) {

			MemoryStream result = new MemoryStream();

			Document.Create(container => {

				container.Page(page => {

					page.Margin(50);

					page.Header().Element(headerContainer => {

						headerContainer.Row(row => {

							row.RelativeItem().Column(column => {

								column.Item().Text($"Объект: {workplace.Name}").Style(_titleStyle).FontSize(16);
								column.Item().Text($"Адрес: {workplace.Address}").Style(_titleStyle).FontSize(14);

								if (cost != null)
									column.Item().Text($"Итого: {cost} руб.").Style(_titleStyle).FontSize(14);
							});
						});
					});

					page.Content().Element(contentContainer => {

						contentContainer.Table(table => {

							table.ColumnsDefinition(columns => {

								columns.ConstantColumn(25);

								foreach (IExportProperty exportProperty in exportProperties) {

									columns.RelativeColumn();
								}
							});

							table.Header(header => {

								header.Cell().Element(HeaderCellStyle).Text("№").Style(_textStyle);

								foreach (IExportProperty exportProperty in exportProperties) {

									header.Cell().Element(HeaderCellStyle).Text(exportProperty.DocumentName).Style(_textStyle);
								}
							});

							int n = 1;

							foreach (WorkplaceWork position in positions) {

								table.Cell().Element(cell => CellStyle(cell).AlignCenter().AlignMiddle()).Text(n).Style(_textStyle);

								foreach (IExportProperty exportProperty in exportProperties) {

									object propVal = position.GetType()
										.GetProperty(exportProperty.PropertyName[0])
										.GetValue(position);

									for (int i = 1; i < exportProperty.PropertyName.Length; i++) {

										propVal = propVal.GetType()
											.GetProperty(exportProperty.PropertyName[i])
											.GetValue(propVal);
									}

									if (propVal is decimal)

										table.Cell().Element(DecimalCellStyle).Text(propVal?.ToString()).Style(_textStyle);

									else
										table.Cell().Element(CellStyle).Text(propVal?.ToString()).Style(_textStyle);
								}

								n++;
							}
						});
					});

					page.Footer().AlignCenter().Text(text => {

						text.DefaultTextStyle(style => style.FontFamily(_mainFont).FontSize(10));

						text.CurrentPageNumber();
						text.Span(" / ");
						text.TotalPages();
					});
				});

			}).GeneratePdf(result);

			return result;
		}
	}
}
