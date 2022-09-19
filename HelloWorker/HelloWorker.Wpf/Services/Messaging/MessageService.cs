using System.Windows;

namespace HelloWorker.Wpf.Services.Messaging {

	public class MessageService : IMessageService {

		public bool Confirm(string message) {

			return MessageBox.Show(message, "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
		}

		public void Error(string message) {

			MessageBox.Show(message, "Ошибка");
		}

		public void Message(string message) {

			MessageBox.Show(message, "Сообщение");
		}
	}
}
