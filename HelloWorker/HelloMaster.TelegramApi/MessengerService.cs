using HelloWorker.Domain.Services.Messenger;
using System;
using System.IO;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace HelloMaster.TelegramApi {

	public class MessengerService : IMessengerService {

		private const string TOKEN = "token";
		private const long RECEIVER = 0;

		public void SendDocument(Stream stream, string documentName) {

			if (stream.Length == 0) {

				throw new Exception("Файл не может быть пустым");
			}

			TelegramBotClient client = new TelegramBotClient(TOKEN);

			stream.Position = 0;

			_ = client.SendDocumentAsync(chatId: new ChatId(RECEIVER), 
				document: new InputOnlineFile(stream, documentName)).Result;
		}
	}
}
