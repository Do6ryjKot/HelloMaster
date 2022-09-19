
namespace HelloWorker.Wpf.Services.Files {
	
	/// <summary>
	/// Сервис диалога сохранения файла
	/// </summary>
	public interface ISaveFileDialogService {

		/// <summary>
		/// Фильтр при сохранении
		/// </summary>
		string Filter { get; set; }

		/// <summary>
		///	Открыть диалоговое окно
		/// </summary>
		/// <param name="defaultName">Название файла по умл.</param>
		/// <returns>Выбранный путь</returns>
		string GetSavePath(string defaultName);
	}
}
