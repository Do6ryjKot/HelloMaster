using HelloWorker.Wpf.Structures.Export;
using System.Collections.Generic;

namespace HelloWorker.Wpf.Stores.Export {

	public class ExportPropertiesStore : IExportPropertiesStore {

		private List<IExportProperty> _companyPricesExportProps = new List<IExportProperty>() {

			new ExportProperty(new string[] { "Work", "Name"}, "Вид работ"), //, PropertyType.NESTED)
			new ExportProperty(new string[] { "Quadrature" }, "Квадратура"), // PropertyType.NESTED)
			new ExportProperty(new string[] { "Cost" }, "Стоимость")
		};

		private List<IExportProperty> _masterPricesExportProps = new List<IExportProperty>() {

			new ExportProperty(new string[] { "Work", "Name"}, "Вид работ"), //, PropertyType.NESTED)
			new ExportProperty(new string[] { "Quadrature" }, "Квадратура"), // PropertyType.NESTED)
			new ExportProperty(new string[] { "MasterCost" }, "Стоимость")
		};

		private List<IExportProperty> _exportProperties = new List<IExportProperty>() {

			new ExportProperty(new string[] { "Work", "Name"}, "Вид работ", "Вид работ"), //, PropertyType.NESTED)
			new ExportProperty(new string[] { "Quadrature" }, "Квадратура", "Квадратура"), // PropertyType.NESTED)
			new ExportProperty(new string[] { "Cost" }, "Стоимость", "Стоимость предприятия"),
			new ExportProperty(new string[] { "MasterCost" }, "Стоимость", "Стоимость мастера")
		};

		public IEnumerable<IExportProperty> CompanyPricesExportProps => _companyPricesExportProps;

		public IEnumerable<IExportProperty> MasterPricesExportProps => _masterPricesExportProps;

		public IEnumerable<IExportProperty> ExportProperties => _exportProperties;
	}
}
