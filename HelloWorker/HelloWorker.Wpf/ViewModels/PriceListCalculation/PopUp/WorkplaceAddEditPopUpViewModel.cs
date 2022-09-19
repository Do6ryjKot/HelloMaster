using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.WorkplaceCommands.PopUp;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.Stores.WorkplacesStore;
using HelloWorker.Wpf.ViewModels.Base;
using System;
using System.Windows.Input;

namespace HelloWorker.Wpf.ViewModels.PriceListCalculation.PopUp {
	
	/// <summary>
	///	Модель представления окна добавления/изменения объекта
	/// </summary>
	public class WorkplaceAddEditPopUpViewModel : ViewModelBase {

		private const byte WORKPLACE_NAME_MAX_LEN = 255; // Макс. длина имени объекта
		private const byte WORKPLACE_ADDRESS_MAX_LEN = 255; // Макс. длина адреса объекта
		private const string WORKPLACE_NAME_LEN_ERROR = "Название должно содержать от 1 до {0} символов";
		private const string WORKPLACE_ADDRESS_LEN_ERROR = "Адрес должен содержать от 1 до {0} символов";

		internal struct WorkplaceData {

			internal string WorkplaceName;
			internal string WorkplaceAddress;
		}

		private readonly Workplace _workplace;
		private WorkplaceData _inputData;
		
		public string WorkplaceName {

			get => _inputData.WorkplaceName ?? _workplace?.Name;

			set {

				_inputData.WorkplaceName = value;
				OnPropertyChanged(nameof(WorkplaceName));
			}
		}

		public string WorkplaceAddress {

			get => _inputData.WorkplaceAddress ?? _workplace?.Address;

			set {

				_inputData.WorkplaceAddress = value;
				OnPropertyChanged(nameof(WorkplaceAddress));
			}
		}

		public string Title { get; set; }

		public ICommand SubmitCommand { get; }

		public WorkplaceAddEditPopUpViewModel(Workplace workplace, 
			IWorkplacesStore workplacesStore, 
			IMessageService messageService, 
			ILogService logService,
			IClosePopUpService closePopUpService) {

			// _workplace = workplace ?? new Workplace();

			if (workplace == null) {

				Title = "Добавить объект";
				_workplace = new Workplace();
				SubmitCommand = new AddWorkplaceCommand(this, workplacesStore, messageService, logService, closePopUpService);

			} else {

				Title = "Изменить объект";
				_workplace = workplace;
				SubmitCommand = new EditWorkplaceCommand(this, workplacesStore, messageService, logService, closePopUpService);
			}
		}

		public void Validate() {

			if (string.IsNullOrEmpty(WorkplaceName) || WorkplaceName.Length > WORKPLACE_NAME_MAX_LEN) {

				throw new Exception(string.Format(WORKPLACE_NAME_LEN_ERROR, WORKPLACE_NAME_MAX_LEN));
			}

			if (string.IsNullOrEmpty(WorkplaceAddress) || WorkplaceAddress.Length > WORKPLACE_ADDRESS_MAX_LEN) {

				throw new Exception(string.Format(WORKPLACE_ADDRESS_LEN_ERROR, WORKPLACE_ADDRESS_MAX_LEN));
			}
		}

		public Workplace SetUp() {

			Validate();

			_workplace.Name = WorkplaceName;
			_workplace.Address = WorkplaceAddress;

			return _workplace;
		}
	}
}
