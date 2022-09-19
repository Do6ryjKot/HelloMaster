using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.ActsCommands.PopUp;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.Stores.ActsStore;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.ViewModels.Base;
using System;
using System.Windows.Input;

namespace HelloWorker.Wpf.ViewModels.ActsFolderView.PopUp {

	public class ActAddEditPopUpViewModel : ViewModelBase {

		private const byte ACT_NAME_MAX_LEN = 255;
		private const string ACT_NAME_LEN_ERROR = "Название акта должно содерждать от 1 до {0} символов";

		internal struct ActData {

			internal string ActName;
		}

		private readonly Act _act;
		private readonly ICurrentWorkplaceStore _currentWorkplaceStore;

		private ActData _inputData;

		public string ActName {

			get => _inputData.ActName ?? _act?.Name;

			set {

				_inputData.ActName = value;
				OnPropertyChanged(nameof(ActName));
			}
		}

		public string Title { get; set; }
		
		public ICommand SubmitCommand { get; }

		public ActAddEditPopUpViewModel(Act act, ICurrentWorkplaceStore currentWorkplaceStore, 
			IActsStore actsStore,
			IMessageService messageService, 
			ILogService logService, 
			IClosePopUpService closePopUpService) {

			if (act == null) {

				Title = "Добавить акт";
				_act = new Act();
				SubmitCommand = new AddActCommand(this, actsStore, messageService, logService, closePopUpService);

			} else {

				Title = "Изменить акт";
				_act = act;
				SubmitCommand = new EditActCommand(this, actsStore, messageService, logService, closePopUpService);
			}
			_currentWorkplaceStore = currentWorkplaceStore;
		}
		public void Validate() {

			if (string.IsNullOrEmpty(ActName) || ActName.Length > ACT_NAME_MAX_LEN) {

				throw new Exception(string.Format(ACT_NAME_LEN_ERROR, ACT_NAME_MAX_LEN));
			}
		}

		public Act SetUp() {

			Validate();

			_act.Name = ActName;
			_act.WorkplaceId = _currentWorkplaceStore.CurrentWorkplace.Id;

			return _act;
		}
	}
}
