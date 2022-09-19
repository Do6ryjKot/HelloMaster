using System.IO;

namespace HelloWorker.Domain.Services.Messenger {
	
	/// <summary>
	/// Сервис взаимодейтсвия с месенджером
	/// </summary>
	public interface IMessengerService {

		/// <summary>
		/// Отправить документ
		/// </summary>
		/// <param name="stream">Поток с документом</param>
		/// <param name="documentName">Название документа</param>
		void SendDocument(Stream stream, string documentName);
	}
}
