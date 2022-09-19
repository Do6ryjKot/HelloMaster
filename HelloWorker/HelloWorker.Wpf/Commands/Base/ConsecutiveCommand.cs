using System.Windows.Input;

namespace HelloWorker.Wpf.Commands.Base {

	/// <summary>
	///	Последовательная команда. Вызывает все переданные команды
	/// </summary>
	public class ConsecutiveCommand : CommandBase {

		private ICommand[] _commands;

		public ConsecutiveCommand(params ICommand[] commands) {

			_commands = commands;
		}

		public override void Execute(object parameter) {
			
			foreach (ICommand command in _commands) {
				command.Execute(null);
			}
		}
	}
}
