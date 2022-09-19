using System.IO;

namespace HelloWorker.Wpf.Services.Files {

	public class FileService : IFileService {

		public void Save(Stream stream, string path) {

			using (FileStream fileStream = File.Create(path)) {

				stream.Position = 0;
				stream.CopyTo(fileStream);
			}
		}
	}
}
