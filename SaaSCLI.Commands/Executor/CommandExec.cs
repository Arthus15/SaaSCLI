using SaaSCLI.Commands.Commands;

namespace SaaSCLI.Commands.Executor
{
	public class CommandExec : ICommandExec
	{
		private readonly IEnumerable<ICommand> _commands;
		public CommandExec(IEnumerable<ICommand> commands)
		{
			_commands = commands;
		}

		public void Run(string command)
		{
			Validate();
			var commandToBeExecute = _commands.First(x => x.CanExecute(GetCommandKey()));

			Console.WriteLine($"Executing {command}...");

			commandToBeExecute.Execute(command);

			void Validate()
			{
				if (string.IsNullOrWhiteSpace(command))
					throw new ArgumentNullException(nameof(command));
			}

			string GetCommandKey()
			{
				return command.Split(" ")[0];
			}
		}
	}
}
