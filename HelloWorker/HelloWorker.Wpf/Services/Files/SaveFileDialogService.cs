using Microsoft.Win32;

namespace HelloWorker.Wpf.Services.Files {

	public class SaveFileDialogService : ISaveFileDialogService {

		public string Filter { get; set; }

		public string GetSavePath(string defaultName) {

			SaveFileDialog saveFileDialog = new SaveFileDialog() {

				Filter = this.Filter,
				FileName = defaultName
			};

			if (saveFileDialog.ShowDialog() != true)
				return null;

			return saveFileDialog.FileName;
		}
	}
}
