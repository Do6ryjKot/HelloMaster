using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.PriceListCalculation;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Notifiers.Sums;
using HelloWorker.Wpf.Stores.PositionsStore;
using HelloWorker.Wpf.ViewModels.Base;
using System;
using System.Windows.Input;

namespace HelloWorker.Wpf.ViewModels.PriceListCalculation {
	
	/// <summary>
	///	Модель представления позиции в содержании объекта
	/// </summary>
	public class WorkplacePositionViewModel : ViewModelBase {

		private readonly IPositionsStore _positionsStore;
		private readonly IMessageService _messageService;
		private readonly ILogService _logService;

		private readonly ISumChangingNotifierService _sumChangingNotifierService;

		public WorkplaceWork Position { get; set; }

		public string WorkGroupName => Position.Work.WorkGroup.Name;
		public string WorkName => Position.Work.Name;
		public decimal? Quadrature {

			get => Position.Quadrature;

			set {

				Position.Quadrature = value >= 0 ? value : 0;
				Position.Cost = Position.Quadrature * Position.Work.Price;
				Position.MasterCost = Position.Cost * 2;

				try {

					_positionsStore.Update(Position);

					_sumChangingNotifierService.UpdateSums(Position);

				} catch (Exception ex) {

					_messageService.Error(ex.Message);
					_logService.Log(ex.Message);
				}

				OnPropertyChanged(nameof(Quadrature));
				OnPropertyChanged(nameof(Cost));
				OnPropertyChanged(nameof(MasterCost));
			}
		}
		public decimal? Cost => Position.Cost;
		public decimal? MasterCost => Position.MasterCost;
		public long SortOrder => Position.Work.SortOrder;

		public ICommand DeletePositionCommand { get; }

		public WorkplacePositionViewModel(WorkplaceWork position,
			IPositionsStore positionsStore,
			IMessageService messageService,
			ILogService logService, 
			ISumChangingNotifierService sumChangingNotifierService) {

			Position = position;
			_positionsStore = positionsStore;
			_messageService = messageService;
			_logService = logService;

			_sumChangingNotifierService = sumChangingNotifierService;

			DeletePositionCommand = new DeletePositionCommand(this, messageService, logService, positionsStore, _sumChangingNotifierService);			
		}
	}
}
