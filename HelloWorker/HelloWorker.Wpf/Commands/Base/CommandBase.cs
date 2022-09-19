using System;
using System.Windows.Input;

namespace HelloWorker.Wpf.Commands.Base {
	
	/// <summary>
	///	Основа для команд
	/// </summary>
	public abstract class CommandBase : ICommand {

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) => true;

		public abstract void Execute(object parameter);
	}
}
