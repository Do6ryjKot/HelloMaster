
namespace HelloWorker.Wpf.Services.Messaging {

	/// <summary>
	///	Сервис работы с сообщениями
	/// </summary>
	public interface IMessageService {

		/// <summary>
		///	Сообщение об ошибке
		/// </summary>
		/// <param name="message">Сообщение</param>
		void Error(string message);

		/// <summary>
		///	Сообщение о чем-либо
		/// </summary>
		/// <param name="message">Сообщение</param>
		void Message(string message);

		/// <summary>
		///	Подтверждение действия
		/// </summary>
		/// <param name="message">Сообщение</param>
		/// <returns>Решение пользователя</returns>
		bool Confirm(string message);
	}
}
