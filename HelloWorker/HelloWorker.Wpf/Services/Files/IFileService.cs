using System.IO;

namespace HelloWorker.Wpf.Services.Files {
	
	public interface IFileService {

		/// <summary>
		/// Сохранить данные из потока в файл
		/// </summary>
		/// <param name="stream">Поток</param>
		/// <param name="path">Путь сохранения</param>
		void Save(Stream stream, string path);
	}
}
