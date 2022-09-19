using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;

namespace HelloWorker.Wpf.Services.Notifiers.Sums {

	public class SumChangingNotifierService : ISumChangingNotifierService {

		private readonly ISumsUpdateService _sumsService;
		
		public event Action SumChanged;

		public SumChangingNotifierService(ISumsUpdateService sumsService) {
			_sumsService = sumsService;
		}

		private void OnSumChanged() {

			SumChanged?.Invoke();
		}

		public void UpdateSums(WorkplaceWork position) {

			_sumsService.UpdateSums(position);
			OnSumChanged();
		}

		public void UpdateSums(Act act) {

			_sumsService.UpdateSums(act);
			OnSumChanged();
		}
	}
}
