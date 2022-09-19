
namespace HelloWorker.Wpf.Services.Logging {

	/// <summary>
	///	Сервис логирования
	/// </summary>
	public interface ILogService {

		/// <summary>
		///	Записать лог
		/// </summary>
		/// <param name="message">Сообщение лога</param>
		void Log(string message);
	}
}
