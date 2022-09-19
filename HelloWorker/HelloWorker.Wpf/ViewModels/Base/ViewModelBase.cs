using System.ComponentModel;

namespace HelloWorker.Wpf.ViewModels.Base {

	/// <summary>
	///	Основа всех моделей представления
	/// </summary>
	public class ViewModelBase : INotifyPropertyChanged {

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propName) {

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}

		public virtual void Dispose() { }
	}
}
