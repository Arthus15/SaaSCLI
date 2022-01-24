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

			var result = commandToBeExecute.Execute(command);

			if (result == 0)
				Console.WriteLine("Command finished successfully");
			else
				Console.Error.WriteLine("Something went wrong");

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
