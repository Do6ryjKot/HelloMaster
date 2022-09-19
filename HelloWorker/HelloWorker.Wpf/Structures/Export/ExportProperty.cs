
namespace HelloWorker.Wpf.Structures.Export {

	public class ExportProperty : IExportProperty {
		
		public string[] PropertyName { get; set; }
		public string DocumentName { get; set; }
		public bool IsUsed { get; set; }
		public string ViewName { get; set; }

		// public PropertyType PropertyType { get; set; } = PropertyType.USUAL;

		public ExportProperty(string[] propertyName, string documentName, string viewName = ""/*, PropertyType propertyType = default*/) {
			
			PropertyName = propertyName;
			DocumentName = documentName;
			ViewName = viewName;
			// PropertyType = propertyType;
		}
	}
}
