using HelloWorker.Domain.Models;
using HelloWorker.Wpf.Commands.ActsCommands;
using HelloWorker.Wpf.Commands.ActsFolderView;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.Services.Notifiers.Sums;
using HelloWorker.Wpf.Stores.ActsStore;
using HelloWorker.Wpf.Stores.CurrentActStore;
using HelloWorker.Wpf.ViewModels.ActContentView;
using HelloWorker.Wpf.ViewModels.ActsFolderView.PopUp;
using HelloWorker.Wpf.ViewModels.Base;
using System.Windows.Input;

namespace HelloWorker.Wpf.ViewModels.ActsFolderView {
	
	public class ActFolderViewModel : ViewModelBase {

		public Act Act { get; set; }

		public string ActName => Act.NumOrder == -1 ? Act.Name : string.Join(" ", "Акт", Act.NumOrder, " - ", Act.Name);
		public long ActNumOrder => Act.NumOrder;
		public bool CanBeEdited => Act.NumOrder != -1;

		public ICommand OpenEditActPopUpCommand { get; set; }
		public ICommand DeleteActCommand { get; set; }
		public ICommand OpenActContentCommand { get; set; }

		public ActFolderViewModel(Act act, 
			IParametrizedPopUpNavigationService<ActAddEditPopUpViewModel, Act> editPopUpNavigationService,
			IActsStore actsStore,
			IMessageService messageService,
			ILogService logService,
			ICurrentActStore currentActStore,
			ISumChangingNotifierService sumChangingNotifierService,
			INavigationService<ActContentViewModel> actContentNavigationService
		) {

			Act = act;

			OpenEditActPopUpCommand = new OpenEditActPopUpCommand(this, editPopUpNavigationService);
			DeleteActCommand = new DeleteSelectedActCommand(this, actsStore, messageService, logService, sumChangingNotifierService);
			OpenActContentCommand = new OpenActContentCommand(currentActStore, actContentNavigationService, messageService, logService);
		}
	}
}
