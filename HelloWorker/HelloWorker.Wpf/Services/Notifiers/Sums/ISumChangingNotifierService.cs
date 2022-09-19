using HelloWorker.Domain.Services.Data;
using System;

namespace HelloWorker.Wpf.Services.Notifiers.Sums {
	
	/// <summary>
	/// Обертка для сервиса работы с сумами. Используется для оповещения об изменении сумм через событие
	/// </summary>
	public interface ISumChangingNotifierService : ISumsUpdateService {

		event Action SumChanged;
	}
}
