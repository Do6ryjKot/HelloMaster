using HelloWorker.Domain.Models;
using HelloWorker.Wpf.ViewModels.Base;

namespace HelloWorker.Wpf.ViewModels.PriceListCalculation {
	
	/// <summary>
	///	Модель представления позиции в прайс-листе
	/// </summary>
	public class PriceListPositionViewModel : ViewModelBase {

		public string WorkGroupName => Work.WorkGroup?.Name;
		public string WorkName => Work.Name;
		public string WorkMeasureUnit => Work.MeasureUnit;
		public decimal WorkPrice => Work.Price;
		public long SortOrder => Work.SortOrder;

		public Work Work { get; set; }

		public PriceListPositionViewModel(Work work) {
			Work = work;
		}
	}
}
