using HelloMaster.TelegramApi;
using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using HelloWorker.Domain.Services.LastActivity;
using HelloWorker.Domain.Services.Messenger;
using HelloWorker.EntityFramework;
using HelloWorker.EntityFramework.Services.Data;
using HelloWorker.EntityFramework.Services.LastActivity;
using HelloWorker.Wpf.Services.Export;
using HelloWorker.Wpf.Services.Files;
using HelloWorker.Wpf.Services.Logging;
using HelloWorker.Wpf.Services.Messaging;
using HelloWorker.Wpf.Services.Navigation;
using HelloWorker.Wpf.Services.Navigation.PopUp;
using HelloWorker.Wpf.Services.Notifiers.Sums;
using HelloWorker.Wpf.Stores.ActsStore;
using HelloWorker.Wpf.Stores.CurrentActStore;
using HelloWorker.Wpf.Stores.CurrentWorkplaceStore;
using HelloWorker.Wpf.Stores.Export;
using HelloWorker.Wpf.Stores.Navigation;
using HelloWorker.Wpf.Stores.PopUp;
using HelloWorker.Wpf.Stores.PositionsStore;
using HelloWorker.Wpf.Stores.PriceListStore;
using HelloWorker.Wpf.Stores.WorkCategoriesStore;
using HelloWorker.Wpf.Stores.WorkGroupsStore;
using HelloWorker.Wpf.Stores.WorkplacesStore;
using HelloWorker.Wpf.ViewModels.ActContentView;
using HelloWorker.Wpf.ViewModels.ActsFolderView;
using HelloWorker.Wpf.ViewModels.ActsFolderView.PopUp;
using HelloWorker.Wpf.ViewModels.ExportPositionsPopUpView;
using HelloWorker.Wpf.ViewModels.Main;
using HelloWorker.Wpf.ViewModels.PriceListCalculation.PopUp;
using HelloWorker.Wpf.ViewModels.WorkplacesFolderView;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Windows;

namespace HelloWorker.Wpf {

	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application {

		private readonly IHost _host;
		// private IServiceProvider _services;

		public App() {

			_host = CreateHostBuilder().Build();
		}

		protected override void OnStartup(StartupEventArgs e) {

			_host.Start();

			_host.Services.GetRequiredService<INavigationService<WorkplacesFolderViewModel>>().Navigate();

			/*
			ILastActiveWorkplaceService lastActiveWorkplaceService = 
				_host.Services.GetRequiredService<ILastActiveWorkplaceService>();
			ICurrentWorkplaceStore currentWorkplaceStore = _host.Services.GetRequiredService<ICurrentWorkplaceStore>();

			try {

				currentWorkplaceStore.Load(lastActiveWorkplaceService.GetLastActiveWorkplaceId());

			} catch (Exception ex) {

				ILogService logService = _host.Services.GetRequiredService<ILogService>();
				logService.Log("Ошибка при загрузке объекта с последней активностю (Код: 1) - " + ex.Message);

				IWorkplacesStore workplacesStore = _host.Services.GetRequiredService<IWorkplacesStore>();
				workplacesStore.Add(new Workplace() { Name = "Новый объект", Address = "Адрес нового объекта" });

				currentWorkplaceStore.Load(lastActiveWorkplaceService.GetLastActiveWorkplaceId());
			}*/

			Window window = _host.Services.GetRequiredService<MainWindow>();
			window.Show();

			base.OnStartup(e);
		}

		private IHostBuilder CreateHostBuilder() {
			
			return Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) => {

					// Клиентские сервисы
					services.AddSingleton<ILogService, LogService>();
					services.AddSingleton<IMessageService, MessageService>();
					services.AddSingleton<IClosePopUpService, ClosePopUpService>();
					services.AddSingleton<ISaveFileDialogService, SaveFileDialogService>();
					services.AddSingleton<IWorkplaceWorkXlsxExportService, WorkplaceWorkXlsxExportService>();
					services.AddSingleton<IFileService, FileService>();

					services.AddSingleton<ISumChangingNotifierService, SumChangingNotifierService>();

					services.AddSingleton<XlsxPositionsExportService>();
					services.AddSingleton<PdfPositionsExportService>();

					// Сервисы работы с данными
					services.AddSingleton<IWorkDataService, WorkDataService>();
					services.AddSingleton<IWorkplaceDataService, WorkplaceDataService>();
					services.AddSingleton<IWorkplacePositionDataService, WorkplacePositionDataService>();
					services.AddSingleton<IWorkGroupDataService, WorkGroupDataService>();
					services.AddSingleton<IWorkplacesStore, WorkplacesStore>();
					services.AddSingleton<IWorkCategoryDataService, WorkCategoryDataService>();
					services.AddSingleton<IActDataService, ActDataService>();

					services.AddSingleton<ILastActiveWorkplaceService, LastActiveWorkplaceService>();

					services.AddSingleton<ISumsUpdateService, SumsUpdateService>();

					// Сторонние сервисы
					services.AddSingleton<IMessengerService, MessengerService>();

					// Хранилища данных
					services.AddSingleton<INavigationStore, NavigationStore>();
					services.AddSingleton<IPopUpNavigationStore, PopUpNavigationStore>();
					services.AddSingleton<IExportPropertiesStore, ExportPropertiesStore>();

					services.AddSingleton<IPriceListStore, PriceListStore>();
					services.AddSingleton<ICurrentWorkplaceStore, CurrentWorkplaceStore>();
					services.AddSingleton<IWorkGroupsStore, WorkGroupsStore>();
					services.AddSingleton<IWorkCategoriesStore, WorkCategoriesStore>();
					services.AddSingleton<IActsStore, ActsStore>();
					services.AddSingleton<ICurrentActStore, CurrentActStore>();
					services.AddSingleton<IPositionsStore, PositionsStore>();

					// Модели представления
					services.AddSingleton<MainViewModel>();
					// services.AddSingleton<PriceListCalculationViewModel>();
					services.AddTransient<WorkplacesFolderViewModel>();
					services.AddTransient<ActsFolderViewModel>();
					services.AddTransient<ActContentViewModel>();
					// services.AddTransient<ExportWorkplacePositionsPopUpViewModel>();



					// Фабричные функции моделей представления страниц и Переходы меж страниц
					services.AddSingleton<Func<WorkplacesFolderViewModel>>(s => () => s.GetRequiredService<WorkplacesFolderViewModel>());
					services.AddSingleton<INavigationService<WorkplacesFolderViewModel>, NavigationService<WorkplacesFolderViewModel>>();

					services.AddSingleton<Func<ActsFolderViewModel>>(s => () => s.GetRequiredService<ActsFolderViewModel>());
					services.AddSingleton<INavigationService<ActsFolderViewModel>, NavigationService<ActsFolderViewModel>>();

					services.AddSingleton<Func<ActContentViewModel>>(s => () => s.GetRequiredService<ActContentViewModel>());
					services.AddSingleton<INavigationService<ActContentViewModel>, NavigationService<ActContentViewModel>>();

					// Фабричные функции моделей представления поп апов и переходы на поп апы
					services.AddSingleton<Func<Workplace, WorkplaceAddEditPopUpViewModel>>(s =>
						workplace => new WorkplaceAddEditPopUpViewModel(workplace,
							s.GetRequiredService<IWorkplacesStore>(),
							s.GetRequiredService<IMessageService>(),
							s.GetRequiredService<ILogService>(),
							s.GetRequiredService<IClosePopUpService>()));

					services.AddSingleton<IParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace>,
						ParametrizedPopUpNavigationService<WorkplaceAddEditPopUpViewModel, Workplace>>();

					services.AddSingleton<Func<Act, ActAddEditPopUpViewModel>>(s =>
						act => new ActAddEditPopUpViewModel(act, 
							s.GetRequiredService<ICurrentWorkplaceStore>(),
							s.GetRequiredService<IActsStore>(),
							s.GetRequiredService<IMessageService>(),
							s.GetRequiredService<ILogService>(),
							s.GetRequiredService<IClosePopUpService>()));

					services.AddSingleton<IParametrizedPopUpNavigationService<ActAddEditPopUpViewModel, Act>,
						ParametrizedPopUpNavigationService<ActAddEditPopUpViewModel, Act>>();

					/*
					services.AddSingleton<Func<ExportWorkplacePositionsPopUpViewModel>>(s => 
						() => s.GetRequiredService<ExportWorkplacePositionsPopUpViewModel>());
					*/

					services.AddSingleton<Func<ExportWorkplacePositionsPopUpViewModel>>(s =>
						() => new ExportWorkplacePositionsPopUpViewModel(s.GetRequiredService<IExportPropertiesStore>(),
							s.GetRequiredService<ICurrentActStore>(),
							s.GetRequiredService<ICurrentWorkplaceStore>(),
							s.GetRequiredService<ISaveFileDialogService>(),
							s.GetRequiredService<IMessageService>(),
							s.GetRequiredService<IFileService>(),
							s.GetRequiredService<ILogService>(),
							s.GetRequiredService<XlsxPositionsExportService>(),
							s.GetRequiredService<PdfPositionsExportService>(),
							s.GetRequiredService<IMessengerService>()));

					services.AddSingleton<IPopUpNavigationService<ExportWorkplacePositionsPopUpViewModel>, 
						PopUpNavigationService<ExportWorkplacePositionsPopUpViewModel>>();



					// Окна
					services.AddSingleton<MainWindow>(s => new MainWindow() {

						DataContext = s.GetRequiredService<MainViewModel>()
					});

					// Контекст БД
					services.AddSingleton<Func<HelloWorkerDbContext>>(() => new HelloWorkerDbContext());
				});
		}

		protected override async void OnExit(ExitEventArgs e) {

			await _host.StopAsync();
			_host.Dispose();

			base.OnExit(e);
		}
	}
}
